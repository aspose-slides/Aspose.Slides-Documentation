---
title: Instalasi
type: docs
weight: 70
url: /id/cpp/installation/
keywords:
- instal Aspose.Slides
- unduh Aspose.Slides
- gunakan Aspose.Slides
- instalasi Aspose.Slides
- NuGet
- CMake
- Windows
- Linux
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Instal Aspose.Slides untuk C++ di Windows melalui NuGet di Visual Studio, atau di Linux melalui paket ZIP dengan CMake, dan verifikasi instalasi dengan program pertama."
---
## **Ikhtisar**

Aspose.Slides for C++ didistribusikan dalam dua bentuk:

| Bentuk | Gunakan untuk | Di mana mendapatkannya |
|---|---|---|
| Paket NuGet: [Aspose.Slides.Cpp](https://www.nuget.org/packages/Aspose.Slides.Cpp/) (64-bit) dan [Aspose.Slides.Cpp.x86](https://www.nuget.org/packages/Aspose.Slides.Cpp.x86/) (32-bit) | proyek Visual Studio C++ di Windows | NuGet |
| Paket ZIP untuk Windows, Linux, dan macOS | Build tanpa NuGet, seperti proyek CMake | Halaman [unduhan](https://releases.aspose.com/slides/cpp/) |

Artikel ini menunjukkan cara menginstal paket NuGet di Visual Studio pada Windows dan cara menggunakan paket ZIP dengan CMake di Linux. Kedua jalur diakhiri dengan pemeriksaan yang sama: membangun dan menjalankan contoh pertama di [Buat Presentasi](/slides/id/cpp/create-presentation/).

## **Windows**

Di Windows, tambahkan paket NuGet ke proyek Visual Studio C++. Paket tersebut juga menginstal dependensinya, CodePorting.Translator.Cs2Cpp.Framework, dan menyalin DLL yang dibutuhkan program Anda ke folder output build.

Pilih paket berdasarkan platform yang Anda bangun: **Aspose.Slides.Cpp** untuk x64, dan **Aspose.Slides.Cpp.x86** untuk Win32 (x86). Paket Aspose.Slides.Cpp tidak diterapkan pada build Win32, sehingga kompilator tidak dapat menemukan headernya di sana.

Paket ZIP Windows juga tersedia di [halaman unduhan](https://releases.aspose.com/slides/cpp/).

### **Metode 1: Instal atau Perbarui Aspose.Slides dari NuGet Package Manager**

1. Buka Microsoft Visual Studio.
2. Buat proyek **Console App** C++, atau buka proyek yang sudah ada.
3. Di **Solution Explorer**, klik kanan proyek dan pilih **Manage NuGet Packages** (atau pergi ke **Project** > **Manage NuGet Packages**).
4. Di bawah **Browse**, cari *Aspose.Slides.Cpp*.
![Mencari Aspose.Slides.Cpp di NuGet Package Manager](installation_1.png)
5. Klik **Aspose.Slides.Cpp** (atau **Aspose.Slides.Cpp.x86** untuk build 32-bit) lalu klik **Install**.
   * Jika Anda sudah menginstal Aspose.Slides dan ingin memperbaruinya, klik **Update** sebagai gantinya.

Paket diunduh dan direferensikan dalam proyek Anda.

### **Metode 2: Instal atau Perbarui Aspose.Slides Melalui Package Manager Console**

1. Buka Microsoft Visual Studio.
2. Buat proyek **Console App** C++, atau buka proyek yang sudah ada.
3. Pergi ke **Tools** > **NuGet Package Manager** > **Package Manager Console**.
![Membuka Package Manager Console](installation_2.png)
4. Jalankan perintah ini:

   ```powershell
   Install-Package Aspose.Slides.Cpp
   ```

   Untuk build 32-bit (Win32), instal paket x86 sebagai gantinya:

   ```powershell
   Install-Package Aspose.Slides.Cpp.x86
   ```

![Menjalankan perintah Install-Package](installation_3.png)

Saat instalasi selesai, pesan konfirmasi muncul. Paket didistribusikan di bawah [Aspose EULA](https://about.aspose.com/legal/eula).
![Pesan konfirmasi instalasi](installation_4.png)

Untuk memperbarui paket, jalankan `Update-Package Aspose.Slides.Cpp` (atau `Update-Package Aspose.Slides.Cpp.x86`) di Package Manager Console.

### **Periksa Instalasi**

1. Ganti isi file *.cpp* utama proyek (file yang berisi `main`) dengan contoh pertama di [Buat Presentasi](/slides/id/cpp/create-presentation/).
2. Di toolbar, pilih platform **x64**, atau **x86** jika Anda menginstal Aspose.Slides.Cpp.x86.
3. Tekan **Ctrl+F5** untuk membangun dan menjalankan program.

Program menyimpan *hello.pptx* di folder proyek, yang merupakan direktori kerja default saat Visual Studio menjalankan program.

## **Linux**

Di Linux, gunakan paket ZIP Linux dengan CMake. Paket tersebut berisi pustaka Aspose.Slides, dependensinya CodePorting.Translator.Cs2Cpp.Framework, dan file konfigurasi CMake untuk masing‑masing. Pustaka dibangun untuk Linux x86_64 dengan glibc 2.23 atau lebih baru.

1. Instal kompiler C++, make, CMake, unzip, dan pustaka fontconfig, yang menjadi dependensi pustaka Aspose.Slides. Pada Debian dan Ubuntu:

   ```bash
   sudo apt-get update && sudo apt-get install -y g++ make cmake unzip libfontconfig1
   ```

2. Buat folder proyek dan masuk ke dalamnya:

   ```bash
   mkdir hello-slides
   cd hello-slides
   ```

3. Unduh paket ZIP Linux (**Aspose.Slides for C++ Linux**) dari [halaman unduhan](https://releases.aspose.com/slides/cpp/) ke folder proyek, lalu unzip ke subfolder *aspose-slides-cpp*:

   ```bash
   unzip aspose-slides-cpp-linux-*.zip -d aspose-slides-cpp
   ```

4. Buat file bernama *CMakeLists.txt* di folder proyek dengan konten ini:

   ```cmake
   cmake_minimum_required(VERSION 3.13)
   project(HelloSlides CXX)

   set(CMAKE_CXX_STANDARD 14)
   set(CMAKE_CXX_STANDARD_REQUIRED ON)

   set(ASPOSE_SLIDES_DIR "${CMAKE_CURRENT_SOURCE_DIR}/aspose-slides-cpp")
   find_package(CodePorting.Translator.Cs2Cpp.Framework REQUIRED CONFIG PATHS "${ASPOSE_SLIDES_DIR}" NO_DEFAULT_PATH)
   find_package(Aspose.Slides.Cpp REQUIRED CONFIG PATHS "${ASPOSE_SLIDES_DIR}" NO_DEFAULT_PATH)

   add_executable(hello main.cpp)
   target_link_libraries(hello PRIVATE Aspose.Slides.Cpp)
   ```

   Dua panggilan `find_package` memuat file konfigurasi CMake dari paket yang telah diekstrak. Framework ditemukan terlebih dahulu karena Aspose.Slides bergantung padanya. Menautkan target `Aspose.Slides.Cpp` menambahkan folder include dan kedua pustaka ke proses build.

5. Simpan contoh pertama di [Buat Presentasi](/slides/id/cpp/create-presentation/) sebagai *main.cpp* di folder proyek.
6. Bangun dan jalankan program:

   ```bash
   cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
   cmake --build build
   ./build/hello
   ```

Program menyimpan *hello.pptx* di folder saat ini. CMake mencatat lokasi pustaka di dalam program, sehingga Anda tidak perlu mengatur `LD_LIBRARY_PATH` selama folder *aspose-slides-cpp* tetap berada di tempat.

Font yang digunakan dalam presentasi Anda, atau pengganti yang sesuai, harus diinstal di sistem agar teks dirender dengan benar saat Anda mengonversi slide ke PDF atau gambar.

## **FAQ**

**Apakah ada versi gratis atau batasan percobaan?**

Ya. Tanpa lisensi, Aspose.Slides berjalan dalam mode evaluasi: menambahkan watermark evaluasi pada setiap slide yang disimpan dan memotong teks yang dibaca dari presentasi. Untuk menghapus batasan ini, terapkan [lisensi](/slides/id/cpp/licensing/) yang valid.

**Mengapa kompilator melaporkan tidak dapat membuka *DOM/Presentation.h*?**

Paket yang diinstal tidak cocok dengan platform yang Anda bangun. Aspose.Slides.Cpp hanya berlaku untuk build x64, dan Aspose.Slides.Cpp.x86 hanya untuk build Win32. Pilih platform yang cocok di Visual Studio, atau instal paket lain.