### Pratinjau Teks Isi `README.md`:

```markdown
# Dokumen Konfigurasi SDK .NET

Repositori ini dikunci untuk menggunakan versi SDK .NET spesifik demi menjaga konsistensi komersial dan kecocokan perakitan (*build*) di seluruh lingkungan pengembangan.

## Spesifikasi SDK
* **Target SDK Version:** `8.0.204`
* **Target Framework:** .NET 8.0 (LTS)

## Cara Mengunci Versi SDK di Lokal
Jika Anda perlu mengonfigurasi atau membuat ulang file `global.json` pada folder utama (*root*) proyek ini, jalankan perintah berikut di Terminal / Command Prompt Anda:

```bash
dotnet new globaljson --sdk-version 8.0.204
```

## Verifikasi Konfigurasi
Untuk memastikan bahwa sistem perakit (compiler) lokal Anda sudah mematuhi file `global.json` ini, jalankan perintah pengecekan versi di dalam folder proyek:

```bash
dotnet --version
```
Output yang harus keluar wajib menunjukkan angka: 8.0.204

## 📌 PENTING: Catatan Keselarasan Versi SDK
Sebelum menjalankan perintah di atas, pastikan versi `SDK 8.0.204` sudah benar-benar terinstal di komputer Anda.

### 1. Periksa daftar SDK yang terpasang di perangkat Anda dengan perintah:
```bash
dotnet --list-sdks
```

### 2. Pastikan baris bertuliskan `8.0.204 [...]` ada di dalam daftar output tersebut.
### 3. Jika versi yang terinstal di laptop Anda sedikit berbeda (misalnya `8.0.202` atau `8.0.400`), Anda wajib menyesuaikan parameter `--sdk-version` pada perintah `dotnet new globaljson` di atas dengan versi spesifik yang Anda miliki agar tidak terjadi error SDK tidak ditemukan.