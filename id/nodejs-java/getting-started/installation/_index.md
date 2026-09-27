---
title: Instalasi
type: docs
weight: 70
url: /id/nodejs-java/installation/
keywords:
- instal Aspose.Slides
- unduh Aspose.Slides
- gunakan Aspose.Slides
- instalasi Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Instal Aspose.Slides untuk Node.js via Java dari npm pada Windows, Linux, dan macOS: JDK, Python, dan alat build C++ yang dibutuhkan, perintah npm, serta skrip pertama untuk memeriksa instalasi."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menginstal Aspose.Slides for Node.js via Java pada Windows, Linux, dan macOS, serta cara memeriksa bahwa instalasi berhasil.

Aspose.Slides for Node.js via Java didistribusikan sebagai paket `aspose.slides.via.java` di npm. Paket ini menjalankan Aspose.Slides di dalam mesin virtual Java melalui paket [`java`](https://github.com/joeferner/node-java), sebuah addon native Node.js yang dikompilasi npm di komputer Anda selama instalasi. Karena itu, selain Node.js, instalasi memerlukan:

- **Java Development Kit (JDK) 8 atau yang lebih baru.** Runtime Java saja tidak cukup: proses build memerlukan file header JDK.
- **Python 3**, yang digunakan oleh alat build [node-gyp](https://github.com/nodejs/node-gyp).
- **Toolchain build C++** untuk sistem operasi Anda.

## **Instal Prasyarat**

### **Windows**

1. Instal [Node.js](https://nodejs.org/en/download) 20 atau yang lebih baru.  
2. Instal JDK, misalnya [Eclipse Temurin](https://adoptium.net/), dan atur variabel lingkungan `JAVA_HOME` ke folder instalasinya. Build menggunakan JDK yang ditunjuk oleh `JAVA_HOME`.  
3. Instal [Python 3](https://www.python.org/downloads/).  
4. Instal [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) dengan workload **Desktop development with C++**. Pertahankan komponen default workload, yang mencakup **MSVC v143 - VS 2022 C++ x64/x86 build tools** dan **Windows 11 SDK**. Visual Studio 2026 tidak berfungsi: versi node-gyp yang dikompilasi oleh paket `java` tidak mengenalinya.

### **Linux**

Instal Node.js 20 atau yang lebih baru dari [nodejs.org](https://nodejs.org/en/download) atau sumber paket distribusi Anda. Kemudian instal JDK, Python 3, dan toolchain build C++. Pada Debian dan Ubuntu:

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

Di Linux, build secara otomatis menemukan JDK yang terpasang tanpa konfigurasi tambahan. Jika beberapa JDK terpasang, atur `JAVA_HOME` ke JDK yang ingin Anda gunakan.

### **macOS**

Instal Node.js 20 atau yang lebih baru, JDK, dan Xcode Command Line Tools, yang mencakup Python 3 serta kompiler C++. Lihat [Troubleshooting Installation](/slides/id/nodejs-java/troubleshooting-installation/) untuk catatan khusus macOS.

## **Instal dari npm**

Buat folder proyek dan instal paket:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm mengunduh Aspose.Slides dan mengompilasi bridge `java`, yang dapat memakan waktu beberapa menit. Jika kompilasi gagal, lihat [Troubleshooting Installation](/slides/id/nodejs-java/troubleshooting-installation/).

## **Periksa Instalasi**

Buat file bernama *hello.js* di folder proyek dengan kode berikut. Kode ini membuat presentasi, menambahkan kotak teks ke slide pertama, dan menyimpan hasilnya sebagai *hello.pptx*:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides berjalan di dalam mesin virtual Java yang membuat Node.js tetap berjalan, jadi akhiri proses secara eksplisit.
process.exit(0);
```

Jalankan skrip:

```bash
node hello.js
```

Jika *hello.pptx* muncul di folder proyek, instalasi berhasil. Mesin virtual Java yang menjalankan Aspose.Slides mencegah Node.js keluar dengan sendirinya, sehingga skrip diakhiri dengan `process.exit(0)`. [Create Presentations](/slides/id/nodejs-java/create-presentation/) menjelaskan kode tersebut.

## **Instal dari Arsip ZIP**

Paket ini juga tersedia sebagai arsip ZIP dengan isi yang sama dengan paket npm. Untuk menginstalnya dari arsip:

1. Instal prasyarat untuk sistem operasi Anda, seperti dijelaskan di atas.  
2. Unduh arsip dari [halaman unduhan Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-java/).  
3. Buat folder proyek:

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

4. Ekstrak arsip ke subfolder bernama *aspose.slides.via.java* di dalam folder proyek, sehingga *package.json* arsip berada di *hello-slides/aspose.slides.via.java/package.json*.  
5. Instal paket dari folder tersebut:

    ```bash
    npm install ./aspose.slides.via.java
    ```

    npm menginstal bridge `java` yang menjadi dependensi paket dan mengompilasinya, sama seperti pada paket npm.  
6. Periksa instalasi seperti dijelaskan di [Periksa Instalasi](#check-the-installation).

## **FAQ**

**Apakah ada versi gratis atau batasan trial?**

Ya. Tanpa lisensi, Aspose.Slides berjalan dalam mode evaluasi: menambahkan watermark evaluasi pada setiap slide yang disimpan dan memotong teks yang dibaca dari presentasi. Untuk menghilangkan batasan ini, terapkan [lisensi](/slides/id/nodejs-java/licensing/) yang valid.

**Mengapa skrip saya tidak keluar setelah selesai?**

Paket `java` memulai mesin virtual Java di dalam proses Node.js, dan mesin virtual tersebut menjaga proses tetap berjalan. Panggil `process.exit` ketika skrip Anda telah menyelesaikan pekerjaannya.