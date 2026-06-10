---
title: "Prezentációk importálása PDF vagy HTML fájlokból Androidon"
linktitle: "Prezentáció importálása"
type: docs
weight: 60
url: /hu/androidjava/import-presentation/
keywords:
- "prezentáció importálása"
- "dia importálása"
- "PDF importálása"
- "HTML importálása"
- "PDF prezentációvá"
- "PDF PPT‑vé"
- "PDF PPTX‑vé"
- "PDF ODP‑vé"
- "HTML prezentációvá"
- "HTML PPT‑vé"
- "HTML PPTX‑vé"
- "HTML ODP‑vé"
- "PowerPoint"
- "OpenDocument"
- "Android"
- "Java"
- "Aspose.Slides"
description: "PDF és HTML dokumentumok importálása PowerPoint és OpenDocument prezentációkba Java-ban az Aspose.Slides for Android segítségével a zökkenőmentes és nagy teljesítményű diafeldolgozás érdekében."
---
## **Bevezetés**

Az [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/hu/androidjava/) használatával importálhat bemutatókat más formátumú fájlokból. Az Aspose.Slides a [SlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidecollection/) osztályt biztosítja, amely lehetővé teszi a bemutatók importálását PDF‑ekből, HTML‑dokumentumokból stb.

## **PowerPoint importálása PDF‑ből**

Ebben az esetben egy PDF‑et PowerPoint‑bemutatóvá konvertálhat.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/) osztályból.  
2. Hívja meg az [addFromPdf()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) metódust, és adja meg a PDF‑fájlt.  
3. Használja a [save()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) metódust a fájl PowerPoint formátumban való mentéséhez.

Ez a Java kód bemutatja a PDF‑ről PowerPoint‑ra történő konverziót:

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
Érdemes kipróbálni az **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/hu/import/pdf-to-powerpoint) webalkalmazást, mivel ez egy élő megvalósítása az itt leírt folyamatnak. 
{{% /alert %}} 

## **PowerPoint importálása HTML‑ből**

Ebben az esetben egy HTML‑dokumentumot PowerPoint‑bemutatóvá konvertálhat.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/) osztályból.  
2. Hívja meg az [addFromHtml()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) metódust, és adja meg a HTML‑fájlt.  
3. Használja a [save()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) metódust a fájl PowerPoint formátumban való mentéséhez.

Ez a Java kód bemutatja a HTML‑ről PowerPoint‑ra történő konverziót: 

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

**Megmaradnak-e a táblázatok a PDF importálásakor, és javítható-e a felismerésük?**

Az importálás során a táblázatok felismerhetők; a [PdfImportOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pdfimportoptions/) tartalmaz egy [setDetectTables](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) metódust, amely lehetővé teszi a táblázatok felismerését. A hatékonyság a PDF szerkezetétől függ.