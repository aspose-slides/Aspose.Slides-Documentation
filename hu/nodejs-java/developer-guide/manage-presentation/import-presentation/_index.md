---
title: "Prezentációk importálása PDF vagy HTML formátumból JavaScriptben"
linktitle: "Prezentáció importálása"
type: docs
weight: 60
url: /hu/nodejs-java/import-presentation/
keywords:
- prezentáció importálása
- dia importálása
- PDF importálása
- HTML importálása
- PDF prezentációvá
- PDF PPT-vel
- PDF PPTX-vel
- PDF ODP-vel
- HTML prezentációvá
- HTML PPT-vel
- HTML PPTX-vel
- HTML ODP-vel
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Importálja a PDF és HTML dokumentumokat PowerPoint és OpenDocument prezentációkba az Aspose.Slides for Node.js segítségével zökkenőmentes, nagy teljesítményű diakezeléshez."
---
## **Bevezetés**

A [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/hu/nodejs-java/) használatával importálhat prezentációkat más formátumú fájlokból. Az Aspose.Slides a [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/) osztályt biztosítja, amely lehetővé teszi a prezentációk importálását PDF‑ekből, HTML‑dokumentumokból stb.

## **PowerPoint importálása PDF‑ből**

Ebben az esetben egy PDF fájlt PowerPoint prezentációvá konvertálhat.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/) osztályból.
2. Hívja meg az [addFromPdf()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) metódust, és adja meg a PDF fájlt.
3. Használja a [save()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) metódust a fájl PowerPoint formátumban való mentéséhez.

Ez a JavaScript kód bemutatja a PDF‑ról PowerPoint‑ra konvertálást:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert  title="Tipp" color="primary" %}} 
Érdemes kipróbálni az **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/hu/import/pdf-to-powerpoint) webalkalmazást, mivel ez egy élő megvalósítása a leírt folyamatnak. 
{{% /alert %}} 

## **PowerPoint importálása HTML‑ből**

Ebben az esetben egy HTML dokumentumot PowerPoint prezentációvá konvertálhat.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/) osztályból.
2. Hívja meg az [addFromHtml()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) metódust, és adja meg a PDF fájlt.
3. Használja a [save()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) metódust a fájl PowerPoint formátumban való mentéséhez.

Ez a JavaScript kód bemutatja a HTML‑ról PowerPoint‑ra konvertálást:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var htmlStream = java.newInstanceSync("java.io.FileInputStream", "page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) {
            htmlStream.close();
        }
    }
    presentation.save("MyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Megmaradnak-e a táblázatok a PDF importálásakor, és javítható-e a felismerésük?**

Az importálás során a táblázatok felderíthetők; a [PdfImportOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pdfimportoptions/) tartalmaz egy [setDetectTables](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables) metódust, amely lehetővé teszi a táblázatok felismerését. A hatékonyság a PDF szerkezetétől függ.