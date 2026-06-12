---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /id/cpp/presentationml-pptx-xml/
---
## **Tentang PresentationML**
PresentationML adalah nama untuk keluarga format berbasis XML untuk dokumen presentasi. Office OpenXML (OOXML) adalah format berbasis XML yang diperkenalkan dalam aplikasi Microsoft Office 2007. Office OpenXML adalah format kontainer untuk beberapa bahasa markup berbasis XML yang khusus. PresentationML adalah bahasa markup yang digunakan oleh Microsoft Office PowerPoint 2007 untuk menyimpan dokumennya. 

## **PresentationML dalam Aspose.Slides untuk C++**
Dokumen OOXML PresentationML hadir sebagai file PPTX yang merupakan paket XML terkompresi mengikuti spesifikasi [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides untuk C++ secara luas mendukung pembuatan, pembacaan, manipulasi, dan penulisan dokumen PresentationML. Selain itu, Aspose.Slides untuk C++ mampu mengekspor dokumen PresentationML ke berbagai format dokumen yang banyak digunakan seperti PDF, TIFF, dan XPS. Hal ini memungkinkan karena Aspose.Slides untuk C++ dirancang dengan tujuan untuk menangani dokumen presentasi secara komprehensif dan PresentationML pada dasarnya menyimpan presentasi internal dokumen sebagai paket XML terkompresi. 

## **PresentationML Bersifat Terbuka, Mengapa Menggunakan Aspose.Slides untuk C++**
Karena PresentationML berbasis XML, sangat memungkinkan untuk membangun aplikasi yang memproses dan menghasilkan dokumen PresentationML dengan menggunakan kelas XML tanpa bergantung pada pustaka kelas pihak ketiga seperti Aspose.Slides untuk C++. Namun, ada beberapa keunggulan menggunakan Aspose.Slides untuk C++ dibandingkan kelas XML ketika bekerja dengan dokumen PresentationML. 

Spesifikasi OOXML sangat panjang, mencapai beberapa ribu halaman. Artinya, untuk menangani dokumen PresentationML dengan tepat, Anda harus menghabiskan banyak waktu dan upaya untuk memahami format dokumen tersebut. Di sisi lain, dengan menggunakan Aspose.Slides untuk C++, Anda cukup menggunakan kelas yang relevan serta metode/properti masing‑masing untuk melakukan operasi yang tampaknya cukup kompleks jika dikerjakan melalui kelas XML. 

Berikut adalah beberapa fitur yang bahkan tidak tersedia saat menangani dokumen PresentationML melalui kelas XML: 

- Mengekspor dokumen PPT ke format PDF, TIFF, XPS
- Mengekspor slide dalam dokumen PPT ke format SVG
- Merender slide ke format gambar apa pun yang didukung oleh Framework C++
- Menyalin master secara otomatis dari presentasi sumber menggunakan fitur kloning
- Menerapkan perlindungan pada shape

Ambil contoh dokumen PresentationML yang memiliki satu slide dengan satu kotak teks yang berisi teks “Hello World”. Untuk membaca teks tersebut melalui kelas XML, Anda harus menulis program yang dapat menguraikan teks sederhana ini dari fragmen berikut: 
## **Contoh**


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