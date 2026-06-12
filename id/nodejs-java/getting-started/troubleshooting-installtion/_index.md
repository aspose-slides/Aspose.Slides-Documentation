---
title: Pemecahan Masalah Instalasi Aspose.Slides untuk Node.js via Java
linktitle: Pemecahan Masalah Instalasi
type: docs
weight: 75
url: /id/nodejs-java/troubleshooting-installation/
keywords:
- unduh Aspose.Slides
- instal Aspose.Slides
- pemecahan masalah instalasi
- persyaratan versi
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Memecahkan masalah instalasi Aspose.Slides untuk Node.js via Java, memperbaiki kesalahan umum dan dependensi, serta memastikan kerja lancar dengan PPT, PPTX, dan ODP."
---
## **Pendahuluan**

Saat [menginstal](/slides/id/nodejs-java/installation/) `aspose.slides.via.java` menggunakan `npm`, ada kasus dimana terjadi kesalahan selama kompilasi modul `java` dan `node-gyp`. Kami telah menyelidiki kesalahan ini lebih detail dan mengidentifikasi persyaratan khusus untuk versi program dan paket yang diinstal. 

## **Persyaratan versi**

1. Untuk Node.js 12 dan sebelumnya:
   - Python tidak lebih tinggi dari 3.10.
   - Untuk Windows, disarankan menginstal Visual Studio Build Tools tidak lebih baru dari 2017.
   - Versi paket npm java: 0.12.1.

2. Untuk Node.js 13:
   - Persyaratan yang sama seperti untuk Node.js 12.

3. Untuk Node.js 14:
   - Python 3.10.
   - Versi paket npm java: 0.14.0.

4. Untuk Node.js 15:
   - Python 3.12.
   - Versi paket npm java: 0.14.0.

5. Untuk Node.js 16 dan yang lebih baru:
   - Python 3.12.
   - Versi paket npm java: 0.14.0.

**Ikuti petunjuk di bawah ini untuk menginstal program yang diperlukan.**

### **Instalasi di Unix**

- Instál [Node.js](https://nodejs.org/en/download).
- Instál [Python](https://devguide.python.org/versions).
- Instál Java (JDK 1.8).
- Instál rantai alat kompilator C/C++ yang tepat, seperti [GCC](https://gcc.gnu.org).

### **Instalasi di macOS**

- Instál [Node.js](https://nodejs.org/en/download).
- Instál [Python](https://devguide.python.org/versions).
- Instál Java (JDK 1.8) dan modifikasi bagian JVMCapabilities di /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist dengan hak istimewa root. jdk1.8.x_xxx.jdk tergantung pada versi jdk Anda. Buat seperti ini: 
```
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
- Instál `Xcode Command Line Tools` secara terpisah dengan menjalankan `xcode-select --install`. -- ATAU -- Atau, jika Anda sudah memiliki [Xcode lengkap terinstal](https://developer.apple.com/xcode/download/), Anda dapat menginstal Command Line Tools melalui menu `Xcode -> Open Developer Tool -> More Developer Tools...`.

### **Instalasi di Windows**

- Instál [Node.js](https://nodejs.org/en/download).
- Instál [Python](https://devguide.python.org/versions) dari [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- Instál Java (JDK 1.8).
- Instál [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (gunakan "Visual C++ build tools" jika memakai versi lebih lama dari VS2019, jika tidak gunakan beban kerja "Desktop development with C++" atau [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) dengan beban kerja "Desktop development with C++").

Pastikan Node.js, Python, dan Java ditambahkan ke variabel PATH.

## **Instalasi Aspose.Slides untuk Node.js via Java pada versi Node.js 14 dan yang lebih baru**

Cukup gunakan perintah berikut:
```
npm i aspose.slides.via.java
```

## **Instalasi Aspose.Slides untuk Node.js via Java pada versi Node.js 12 atau 13**

Aspose.Slides untuk Node.js via Java harus diinstal secara manual. Gunakan perintah berikut:

- Untuk Node.js 12:
```
npm i java@0.12.1
```
- Untuk Node.js 13: 
```
npm i java@0.13.0
```

Setelah itu, unduh [aspose.slides.via.java](https://releases.aspose.com/slides/id/nodejs-java/) dan ekstrak ke folder `node_modules/aspose.slides.via.java`.

## **Validasi instalasi**

Untuk memvalidasi instalasi, buat file `index.js` di root proyek Anda dengan konten berikut:
```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

Jalankan file ini menggunakan perintah `node index.js`.

## **Informasi Tambahan**

Tidak mungkin mencakup semua masalah yang mungkin terjadi dalam artikel ini. Karena masalah muncul akibat kompilasi modul `java` dan `node-gyp`, tautan berikut juga akan berguna:
- [instalasi java](https://www.npmjs.com/package/java#installation)
- [instalasi node-gyp](https://www.npmjs.com/package/node-gyp#installation)