---
title: Bemutatók importálása PDF‑ből vagy HTML‑ből Java‑ban
linktitle: Bemutató importálása
type: docs
weight: 60
url: /hu/java/import-presentation/
keywords:
- bemutató importálása
- dia importálása
- PDF importálása
- HTML importálása
- PDF bemutatóvá
- PDF PPT‑vé
- PDF PPTX‑vé
- PDF ODP‑vé
- HTML bemutatóvá
- HTML PPT‑vé
- HTML PPTX‑vé
- HTML ODP‑vé
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Könnyedén importálhat PDF és HTML dokumentumokat PowerPoint és OpenDocument bemutatókba Java‑ban az Aspose.Slides segítségével, zökkenőmentes és nagy teljesítményű dia feldolgozást biztosítva."
---
## **Bevezetés**

Az Aspose.Slides segítségével importálhat bemutatókat más formátumú fájlokból. Az Aspose.Slides biztosítja a [SlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slidecollection/) osztályt, amely lehetővé teszi, hogy PDF és HTML dokumentumokból importáljon bemutatókat.

## **PowerPoint importálása PDF‑ből**

Ebben az esetben egy PDF-et PowerPoint‑prezentációvá konvertálhat.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/) osztályból. 
2. Hívja meg a [addFromPdf()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) metódust, és adja meg a PDF fájlt. 
3. Használja a [save()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#save-java.lang.String-int-) metódust a fájl PowerPoint formátumban történő mentéséhez.

Ez a Java kód bemutatja a PDF‑ről PowerPoint‑ra történő átalakítást:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tip" color="primary" %}} 
Érdemes megtekinteni az **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/hu/import/pdf-to-powerpoint) webalkalmazást, mivel ez élő megvalósítása a leírt folyamatnak. 
{{% /alert %}} 

## **PowerPoint importálása HTML‑ből**

Ebben az esetben egy HTML dokumentumot PowerPoint‑prezentációvá konvertálhat.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/) osztályból. 
2. Hívja meg a [addFromHtml()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) metódust, és adja meg a HTML fájlt. 
3. Használja a [save()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#save-java.lang.String-int-) metódust a fájl PowerPoint formátumban történő mentéséhez.

Ez a Java kód bemutatja a HTML‑ról PowerPoint‑ra történő átalakítást: 

```java
Presentation presentation = new Presentation();
try {
    FileInputStream htmlStream = new FileInputStream("page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) htmlStream.close();
    }

    presentation.save("MyPresentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **GYIK**

**Megmaradnak a táblázatok a PDF importálása során, és javítható-e a felismerésük?**

A táblázatok importálás közben felismerhetők; a [PdfImportOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pdfimportoptions/) tartalmaz egy [setDetectTables](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) metódust, amely lehetővé teszi a táblázatok felismerését. A hatékonyság a PDF struktúrájától függ.

{{% alert title="Megjegyzés" color="warning" %}} 
Az Aspose.Slides-t továbbá használhatja a HTML más népszerű fájlformátumokra történő konvertálására: 

* [HTML képre](https://products.aspose.com/slides/hu/java/conversion/html-to-image/)
* [HTML JPG‑re](https://products.aspose.com/slides/hu/java/conversion/html-to-jpg/)
* [HTML XML‑re](https://products.aspose.com/slides/hu/java/conversion/html-to-xml/)
* [HTML TIFF‑re](https://products.aspose.com/slides/hu/java/conversion/html-to-tiff/)

{{% /alert %}}