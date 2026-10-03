---
title: "PresentationML (PPTX, XML) (Sejarah)"
type: docs
weight: 20
url: /id/java/presentationml-pptx-xml/
keywords:
- PresentationML
- PPTX
- Office Open XML
- sejarah
- Java
- Aspose.Slides
description: "Sejarah: ikhtisar lama format PresentationML (PPTX) dalam Aspose.Slides untuk Java, disimpan untuk tautan yang ada. Daftar format yang didukung saat ini ada di Supported File Formats."
---
{{% alert color="info" title="Note" %}}

Ini adalah halaman historis, disimpan untuk tautan yang ada. Halaman ini tidak menggambarkan versi terbaru Aspose.Slides for Java. Untuk format yang dimuat, diimpor, disimpan, dan dirender oleh Aspose.Slides for Java, serta API untuk masing‑masing, lihat [Supported File Formats](/slides/id/java/supported-file-formats/). Untuk membandingkan PPTX dengan PPT, lihat [Understanding the Difference: PPT vs PPTX](/slides/id/java/ppt-vs-pptx/).

{{% /alert %}}

{{% alert color="info" title="Note" %}}

PresentationML adalah nama untuk keluarga format berbasis XML untuk dokumen presentasi. Office OpenXML (OOXML) adalah format berbasis XML yang diperkenalkan di aplikasi Microsoft Office 2007. Office OpenXML adalah format container untuk beberapa bahasa markup berbasis XML khusus. PresentationML adalah bahasa markup yang digunakan oleh Microsoft Office PowerPoint 2007 untuk menyimpan dokumen.

{{% /alert %}}

## **PresentationML di Aspose.Slides for Java**
Dokumen OOXML PresentationML hadir sebagai file PPTX, paket XML terkompresi yang mengikuti spesifikasi [OOXML ECMA-376](https://ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides for Java secara luas mendukung pembuatan, pembacaan, manipulasi, dan penulisan dokumen PresentationML. Selain itu, Aspose.Slides for Java dapat mengekspor dokumen PresentationML ke format dokumen yang banyak digunakan seperti PDF. Hal ini memungkinkan karena Aspose.Slides for Java dirancang dengan tujuan untuk menangani dokumen presentasi secara komprehensif dan PresentationML pada dasarnya menyimpan presentasi internal dokumen sebagai paket XML terkompresi.

**Dokumen PPTX yang dihasilkan oleh Aspose.Slides for Java dan dibuka di Microsoft PowerPoint**

![Dokumen PPTX yang dihasilkan oleh Aspose.Slides for Java dan dibuka di Microsoft PowerPoint](presentationml-pptx-xml_1.png)


**Melihat dokumen PPTX yang sama yang dihasilkan oleh Aspose.Slides for Java dalam format ZIP**

![The same PPTX document viewed as a ZIP package](presentationml-pptx-xml_2.jpg)


## **PresentationML Bersifat Terbuka, Mengapa Menggunakan Aspose.Slides for Java?**
Karena PresentationML berbasis XML, sangat memungkinkan untuk membangun aplikasi yang memproses dan menghasilkan dokumen PresentationML menggunakan kelas XML tanpa bergantung pada pustaka kelas pihak ketiga seperti Aspose.Slides for Java. Namun, ada beberapa keunggulan menggunakan Aspose.Slides for Java dibandingkan kelas XML ketika bekerja dengan dokumen PresentationML.

Spesifikasi OOXML memiliki panjang beberapa ribu halaman sehingga untuk menangani dokumen PresentationML dengan tepat, Anda harus menghabiskan banyak waktu dan upaya untuk memahami format tersebut. Di sisi lain, dengan Aspose.Slides for Java, Anda cukup menggunakan kelas serta metode dan properti mereka untuk melakukan operasi yang tampak kompleks jika dilakukan melalui kelas XML.

Beberapa fitur yang ditawarkan Aspose.Slides bahkan tidak tersedia ketika Anda bekerja dengan dokumen PresentationML melalui kelas XML:

- Ekspor dokumen PPT ke format PDF.
- Render slide ke format gambar apa pun yang didukung oleh Java Framework.
- Salin master secara otomatis dari presentasi sumber menggunakan fitur kloning.
- Terapkan perlindungan pada shape.

Berikut adalah contoh dokumen PresentationML dengan satu slide yang berisi kotak teks dengan teks “Hello World”. Untuk membaca teks tersebut menggunakan kelas XML, Anda harus menulis program yang dapat mengurai teks sederhana ini dari fragmen berikut. Aspose.Slides melakukan hal itu untuk Anda.

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