---
title: Berbagai Format File dan Konversi
type: docs
weight: 50
url: /id/cpp/different-file-formats-and-conversions/
---
## **Microsoft PowerPoint (PPT)**
### **Tentang PPT**
[PPT](https://en.wikipedia.org/wiki/Microsoft_PowerPoint) adalah format file dokumen presentasi yang dapat dibuat, dibaca, dimanipulasi, dan ditulis oleh berbagai versi Microsoft PowerPoint. Ini adalah format biner untuk dokumen presentasi yang dikembangkan oleh Microsoft.
### **PPT di Aspose.Slides for C++**
Aspose.Slides for C++ dapat membaca file PPT yang dibuat oleh perangkat lunak yang tercantum di bawah ini.

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

Demikian pula, file PPT yang dibuat oleh Aspose.Slides for C++ dapat dibaca oleh perangkat lunak di atas.
### **Dukungan Komprehensif untuk PPT**
Aspose.Slides for C++ menyediakan dukungan untuk hampir semua fitur yang berhubungan dengan format file dokumen PPT. Ia tidak hanya mencakup fitur dasar / lanjutan yang disediakan oleh berbagai versi Microsoft PowerPoint untuk manipulasi dokumen PPT, tetapi juga beberapa fitur yang bahkan tidak didukung oleh Microsoft PowerPoint. Keuntungan utama menggunakan pustaka API Aspose.Slides for C++ adalah kemudahan penggunaan untuk menangani fitur-fitur tersebut.

Selain tugas dasar terkait pembuatan, pembacaan, dan penulisan file dokumen PPT, terdapat beberapa fitur yang disediakan oleh Aspose.Slides for C++ seperti:

- Impor format file MS Office lainnya sebagai OLE Objects dalam dokumen PPT.
- Ekspor dokumen PPT ke format PDF, TIFF, XPS.
- Ekspor slide dalam dokumen PPT ke format SVG.
- Render slide ke format gambar apa pun yang didukung oleh C++ Framework.
- Atur ukuran slide dalam dokumen PPT.
- Kelola animasi pada bentuk.
- Kelola pertunjukan slide.
- Format teks pada slide.
- Pindai teks dari dokumen PPT.
- Tangani tabel pada slide.
- Penyalinan otomatis master menggunakan fitur kloning.

File PPT yang dihasilkan oleh Aspose.Slides for C++ dan dibuka di Microsoft PowerPoint
## **PresentationML (PPTX, XML)**
### **Tentang PresentationML**
PresentationML adalah nama untuk keluarga format berbasis XML untuk dokumen presentasi. Office OpenXML (OOXML) adalah format berbasis XML yang diperkenalkan dalam aplikasi Microsoft Office 2007. Office OpenXML adalah format wadah untuk beberapa bahasa markup berbasis XML khusus. PresentationML adalah bahasa markup yang digunakan oleh Microsoft Office PowerPoint 2007 untuk menyimpan dokumennya.
### **PresentationML di Aspose.Slides for C++**
Dokumen OOXML PresentationML hadir sebagai file PPTX yang merupakan paket XML terkompresi mengikuti spesifikasi [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides for C++ secara luas mendukung pembuatan, pembacaan, manipulasi, dan penulisan dokumen PresentationML. Selain itu, Aspose.Slides for C++ dapat mengekspor dokumen PresentationML ke berbagai format dokumen yang banyak digunakan seperti PDF, TIFF, dan XPS. Hal ini dimungkinkan karena Aspose.Slides for C++ dirancang dengan tujuan menangani dokumen presentasi secara komprehensif dan PresentationML pada dasarnya menyimpan presentasi internal dokumen sebagai paket XML terkompresi.

Dokumen PPTX yang dihasilkan oleh Aspose.Slides for C++ dan dibuka di Microsoft PowerPoint

Melihat dokumen PPTX yang dihasilkan oleh Aspose.Slides for C++ dalam aplikasi Zip
### **PresentationML bersifat terbuka, Mengapa Menggunakan Aspose.Slides for C++**
Karena PresentationML berbasis XML, sangat memungkinkan untuk membangun aplikasi pemrosesan dan pembuatan dokumen PresentationML dengan menggunakan kelas XML tanpa bergantung pada perpustakaan kelas pihak ketiga seperti Aspose.Slides for C++. Namun, terdapat beberapa keuntungan menggunakan Aspose.Slides for C++ dibandingkan kelas XML saat bekerja dengan dokumen PresentationML.

Spesifikasi OOXML terlalu panjang hingga beberapa ribu halaman. Artinya, untuk menangani dokumen PresentationML dengan tepat, Anda harus menghabiskan banyak waktu dan usaha untuk memahami format dokumen tersebut. Di sisi lain, dengan menggunakan Aspose.Slides for C++, Anda cukup memakai kelas yang relevan serta metode / properti masing‑masing untuk melakukan operasi yang tampak cukup kompleks bila dilakukan lewat kelas XML.

Berikut adalah beberapa fitur yang bahkan tidak tersedia ketika menangani dokumen PresentationML melalui kelas XML:

- Ekspor dokumen PPT ke format PDF, TIFF, XPS
- Ekspor slide dalam dokumen PPT ke format SVG
- Render slide ke format gambar apa pun yang didukung oleh C++ Framework
- Penyalinan otomatis master dari presentasi sumber menggunakan fitur kloning
- Menerapkan perlindungan pada bentuk

Misalnya, ambil sebuah dokumen PresentationML yang memiliki satu slide dengan satu kotak teks yang berisi teks “Hello World”. Untuk membaca teks tersebut melalui kelas XML, Anda harus menulis program yang dapat menguraikan teks sederhana ini dari fragmen berikut:

``` cpp

 <?xml version="1.0" encoding="UTF-8" standalone="yes"?>

<p:sld xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:p="http://schemas.openxmlformats.org/presentationml/2006/main">

  <p:cSld>

    <p:spTree>

      <p:nvGrpSpPr>

        <p:cNvPr id="1" name=""/>

        <p:cNvGrpSpPr/>

        <p:nvPr/>

      </p:nvGrpSpPr>

      <p:grpSpPr>

        <a:xfrm>

          <a:off x="0" y="0"/>

          <a:ext cx="0" cy="0"/>

          <a:chOff x="0" y="0"/>

          <a:chExt cx="0" cy="0"/>

        </a:xfrm></p:grpSpPr><p:sp>

          <p:nvSpPr><p:cNvPr id="4" name="TextBox 3"/>

          <p:cNvSpPr txBox="1"/>

            <p:nvPr/>

          </p:nvSpPr>

          <p:spPr>

            <a:xfrm>

              <a:off x="2819400" y="2590800"/>

              <a:ext cx="1297086" cy="369332"/>

            </a:xfrm>

            <a:prstGeom prst="rect">

              <a:avLst/>

            </a:prstGeom>

            <a:noFill/>

          </p:spPr>

          <p:txBody>

            <a:bodyPr wrap="none" rtlCol="0">

              <a:spAutoFit/>

            </a:bodyPr>

            <a:lstStyle/>

            <a:p>

              <a:r>

                <a:rPr lang="en-US"/>

                <a:t>Hello World

                </a:t>

              </a:r>

              <a:endParaRPr lang="en-US"/>

            </a:p>

          </p:txBody>

        </p:sp>

    </p:spTree>

  </p:cSld>

  <p:clrMapOvr>

    <a:masterClrMapping/>

  </p:clrMapOvr>

</p:sld>

```
## **Konversi PPT ke PPTX**
### **Tentang Konversi**
Aspose.Slides sekarang juga mendukung konversi PPT ke PPTX.
### **Fitur yang Didukung dalam Konversi**
Aspose.Slides for C++ menyediakan dukungan parsial untuk mengonversi presentasi berformat file PPT ke presentasi berformat file PPTX. Karena dukungan fitur konversi presentasi yang disebutkan baru saja diperkenalkan dalam Aspose.Slides for C++, saat ini kemampuannya masih terbatas dan hanya bekerja untuk bentuk presentasi yang sederhana. Keuntungan utama yang diberikan pustaka API Aspose.Slides for C++ untuk mengonversi presentasi PPT ke format PPTX adalah kemudahan penggunaan API dalam mencapai tujuan yang diinginkan. Silakan lanjutkan ke this[link]() ke bagian cuplikan kode untuk detail lebih lanjut. Bagian berikut dengan jelas menggambarkan fitur mana yang didukung dan tidak didukung saat mengonversi presentasi format PPT ke format PPTX.
### **Fitur yang Didukung**
Berikut fitur yang didukung selama konversi:

- Konversi struktur master, tata letak, dan slide
- Konversi struktur master, tata letak, dan slide
- Konversi Diagram
- Bentuk grup
- Konversi Auto-shape termasuk Persegi Panjang dan Elips. Namun, kemungkinan Auto-shape memiliki nilai penyesuaian yang salah
- Bentuk dengan geometri khusus. Terkadang mungkin tidak dikonversi
- Tekstur dan gaya isi Gambar untuk Auto-shape. Terkadang mungkin tidak dikonversi
- Konversi Placeholder
- Konversi teks dalam bingkai teks dan pemegang teks. Namun, bullet, perataan, dan tabulasi tidak sepenuhnya diimplementasikan
### **Fitur yang Tidak Didukung**
Berikut fitur yang tidak didukung selama konversi:

- Slide dengan catatan karena pembacaan Catatan belum diimplementasikan dalam PPTX. Jika PPT memiliki catatan, maka tidak dapat disimpan sebagai PPTX saat ini* Konversi Garis dan Polyline
- Format garis dan isi
- Gaya isi gradasi
- Frame OLE, Tabel, Video, dan Audio, dll
- Animasi dan properti slideshow lainnya diabaikan
Fitur baru atau yang belum ada akan ditambahkan pada rilis Aspose.Slides for C++ berikutnya.

Presentasi PPT Sumber

Presentasi PPTX yang Dikonversi
## **Format Dokumen Portabel (PDF)**
### **Tentang PDF**
 [Portable Document Format](https://en.wikipedia.org/wiki/PDF) adalah format file yang dibuat oleh Adobe System untuk pertukaran dokumen antar berbagai organisasi. Tujuan format ini adalah memungkinkan isi dokumen direpresentasikan sedemikian rupa sehingga tampilan visualnya tidak bergantung pada platform tempat dokumen tersebut dilihat.
### **PDF di Aspose.Slides for C++**
Dokumen presentasi apa pun yang dapat dimuat ke Aspose.Slides for C++ dapat dikonversi ke dokumen PDF yang dapat mematuhi [PDF 1.5](https://en.wikipedia.org/wiki/PDF/A) atau [PDF /A-1b](https://en.wikipedia.org/wiki/PDF/A) tergantung pilihan Anda. Aspose.Slides for C++ mengekspor dokumen presentasi ke PDF dengan cara sehingga sebagian besar waktu, dokumen PDF yang diekspor tampak hampir serupa dengan dokumen presentasi asli. Solusi Aspose mendukung fitur-fitur berikut dari dokumen presentasi saat mengonversi ke dokumen PDF:

- Gambar, Kotak Teks, dan Bentuk lainnya
- Teks dan Pemformatan
- Paragraf dan Pemformatan
- Tautan hiper
- Header dan Footer
- Bullet
- Tabel

Anda dapat mengekspor dokumen presentasi ke dokumen PDF secara langsung menggunakan komponen Aspose.Slides for C++ saja. Artinya, Anda tidak memerlukan pihak ketiga lain atau komponen Aspose.Pdf untuk tujuan ini. Selanjutnya, Anda dapat menyesuaikan ekspor presentasi ke PDF dengan berbagai opsi sebagaimana dijelaskan di [this topic](/slides/id/cpp/convert-powerpoint-to-pdf/).

Dokumen Presentasi yang Dikonversi menjadi Dokumen PDF melalui Aspose.Slides for C++
## **Spesifikasi XML Parser (XPS)**
### **Tentang XPS**
[XML Parser Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) adalah bahasa deskripsi halaman dan format dokumen tetap yang awalnya dikembangkan oleh Microsoft. Seperti PDF, XPS adalah format dokumen tata letak tetap yang dirancang untuk menjaga kesetiaan dokumen dan menyediakan tampilan dokumen yang independen dari perangkat.
### **XPS di Aspose.Slides for C++**
Dokumen presentasi apa pun yang dapat dimuat oleh Aspose.Slides for C++ dapat dikonversi ke format XPS. Aspose.Slides for C++ menggunakan mesin tata letak halaman dan render berkualitas tinggi untuk menghasilkan output dalam format dokumen XPS berlayout tetap. Perlu disebutkan bahwa Aspose.Slides for C++ langsung menghasilkan XPS tanpa bergantung pada kelas Windows Presentation Foundation (WPF) yang disertakan dengan C++ Framework 3.5, sehingga memungkinkan Aspose.Slides for C++ menghasilkan dokumen XPS pada mesin yang menjalankan versi C++ Framework lebih lama dari 3.5. Anda dapat mempelajari cara mengekspor dokumen presentasi ke dokumen XPS melalui Aspose.Slides for C++ di [this topic](https://docs.aspose.com/slides/id/cpp/convert-powerpoint-to-xps/).

Dokumen Presentasi yang Dikonversi menjadi Dokumen XPS melalui Aspose.Slides for C++