---
title: PDF vagy HTML prezentációk importálása C++-ban
linktitle: Prezentáció importálása
type: docs
weight: 60
url: /hu/cpp/import-presentation/
keywords:
- prezentáció importálása
- dia importálása
- PDF importálása
- HTML importálása
- PDF prezentációvá konvertálás
- PDF PPT-vé
- PDF PPTX-vé
- PDF ODP-vé
- HTML prezentációvá konvertálás
- HTML PPT-vé
- HTML PPTX-vé
- HTML ODP-vé
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Könnyedén importálhat PDF és HTML dokumentumokat PowerPoint és OpenDocument prezentációkba C++-ban az Aspose.Slides segítségével, zavartalan és nagy teljesítményű diafeldolgozás érdekében."
---
## **Bevezetés**

Az [**Aspose.Slides for C++**](https://products.aspose.com/slides/hu/cpp/) használatával importálhat prezentációkat más formátumú fájlokból. Aspose.Slides biztosítja a [SlideCollection](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.slide_collection) osztályt, amely lehetővé teszi prezentációk importálását PDF, HTML dokumentumok stb. formátumból.

## **PowerPoint importálása PDF-ből**

Ebben az esetben egy PDF-et PowerPoint prezentációvá konvertálhat.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Hozzon létre egy példányt a Presentation osztályból. 
2. Hívja meg a [AddFromPdf()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) metódust, és adja meg a PDF fájlt. 
3. Használja a [Save()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) metódust a fájl PowerPoint formátumban történő mentéséhez.

Ez a C++ kód bemutatja a PDF‑ről PowerPoint‑ra történő átalakítást:

```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Tipp" color="primary" %}} 

Érdemes kipróbálni az **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/hu/import/pdf-to-powerpoint) webalkalmazást, mivel ez egy élő megvalósítása az itt leírt folyamatnak. 

{{% /alert %}} 

## **PowerPoint importálása HTML-ből**

Ebben az esetben egy HTML dokumentumot PowerPoint prezentációvá konvertálhat.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation/) osztályból. 
2. Hívja meg a [AddFromHtml()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) metódust, és adja meg a HTML fájlt. 
3. Használja a [Save()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) metódust a fájl PowerPoint formátumban történő mentéséhez.

Ez a C++ kód bemutatja a HTML‑ről PowerPoint‑ra történő átalakítást:

```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Megjegyzés" color="warning" %}} 

Az Aspose.Slides-t más népszerű fájlformátumokra is használhatja a HTML konvertálásához: 

* [HTML képre](https://products.aspose.com/slides/hu/cpp/conversion/html-to-image/)
* [HTML JPG‑re](https://products.aspose.com/slides/hu/cpp/conversion/html-to-jpg/)
* [HTML XML‑re](https://products.aspose.com/slides/hu/cpp/conversion/html-to-xml/)
* [HTML TIFF‑re](https://products.aspose.com/slides/hu/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **GYIK**

**Megmaradnak-e a táblázatok a PDF importálásakor, és javítható-e a felismerésük?**

Az importálás során felismerhetők a táblázatok; a [PdfImportOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.import/pdfimportoptions/) tartalmaz egy [set_DetectTables](https://reference.aspose.com/slides/hu/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) metódust, amely lehetővé teszi a táblázatok azonosítását. A hatékonyság a PDF struktúrájától függ.