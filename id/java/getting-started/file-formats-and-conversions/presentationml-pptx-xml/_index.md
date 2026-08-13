---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /id/java/presentationml-pptx-xml/
---
{{% alert color="info" %}} 

PresentationML adalah nama untuk keluarga format berbasis XML bagi dokumen presentasi. Office OpenXML (OOXML) adalah format berbasis XML yang diperkenalkan dalam aplikasi Microsoft Office 2007. Office OpenXML adalah format kontainer untuk beberapa bahasa markup berbasis XML yang khusus. PresentationML adalah bahasa markup yang digunakan oleh Microsoft Office PowerPoint 2007 untuk menyimpan dokumen.

{{% /alert %}} 

## **PresentationML di Aspose.Slides untuk Java**
Dokumen OOXML PresentationML hadir sebagai file PPTX, paket XML terkompresi yang mengikuti spesifikasi [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides untuk Java secara ekstensif mendukung pembuatan, pembacaan, manipulasi, dan penulisan dokumen PresentationML. Selain itu, Aspose.Slides untuk Java mampu mengekspor dokumen PresentationML ke format dokumen yang banyak digunakan seperti PDF. Hal ini memungkinkan karena Aspose.Slides untuk Java dirancang dengan tujuan untuk menangani dokumen presentasi secara menyeluruh dan PresentationML pada dasarnya menyimpan presentasi internal dokumen sebagai paket XML terkompresi.

**Dokumen PPTX yang dihasilkan oleh Aspose.Slides untuk Java dan dibuka di Microsoft PowerPoint** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Melihat dokumen PPTX yang sama yang dihasilkan oleh Aspose.Slides untuk Java dalam bentuk ZIP** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML bersifat terbuka, Mengapa Memilih Aspose.Slides untuk Java?**
Karena PresentationML berbasis XML, sangat memungkinkan untuk membuat aplikasi yang memproses dan menghasilkan dokumen PresentationML menggunakan kelas XML tanpa bergantung pada perpustakaan kelas pihak ketiga seperti Aspose.Slides untuk Java. Namun, ada beberapa keunggulan menggunakan Aspose.Slides untuk Java dibandingkan kelas XML saat bekerja dengan dokumen PresentationML.

Spesifikasi OOXML terdiri dari beberapa ribu halaman sehingga untuk menangani dokumen PresentationML dengan tepat, Anda harus menghabiskan banyak waktu dan upaya untuk memahami format tersebut. Di sisi lain, dengan Aspose.Slides untuk Java, Anda cukup menggunakan kelas, metode, dan properti mereka untuk melakukan operasi yang tampak kompleks bila dilakukan melalui kelas XML.

Beberapa fitur yang ditawarkan Aspose.Slides bahkan tidak tersedia ketika Anda bekerja dengan dokumen PresentationML melalui kelas XML:

- Mengekspor dokumen PPT ke format PDF.
- Merender slide ke format gambar apa pun yang didukung oleh Java Framework.
- Menyalin master secara otomatis dari presentasi sumber menggunakan fitur cloning.
- Menerapkan perlindungan pada shape.

Berikut adalah contoh dokumen PresentationML dengan satu slide yang berisi kotak teks berisi teks “Hello World”. Untuk membaca teks tersebut menggunakan kelas XML, Anda harus menulis program yang dapat mem-parsing teks sederhana ini dari fragmen berikut. Aspose.Slides melakukannya untuk Anda.

**XML**

``` xml
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