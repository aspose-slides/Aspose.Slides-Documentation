---
title: Prezentációk importálása PDF‑ből vagy HTML‑ből C++‑ban
linktitle: Prezentáció importálása
type: docs
weight: 60
url: /hu/cpp/import-presentation/
keywords:
- prezentáció importálása
- dia importálása
- PDF importálása
- HTML importálása
- PDF prezentációvá
- PDF PPT‑vá
- PDF PPTX‑vá
- PDF ODP‑vá
- HTML prezentációvá
- HTML PPT‑vá
- HTML PPTX‑vá
- HTML ODP‑vá
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "PDF és HTML dokumentumok könnyed importálása PowerPoint és OpenDocument prezentációkba C++-ban az Aspose.Slides segítségével a zökkenőmentes, nagy teljesítményű diafeldolgozásért."
---
## **Bevezetés**

Az [**Aspose.Slides for C++**](https://products.aspose.com/slides/hu/cpp/) használatával prezentációkat importálhat más formátumú fájlokból. Az Aspose.Slides a [SlideCollection](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.slide_collection) osztályt biztosítja, amely lehetővé teszi prezentációk importálását PDF‑ből, HTML‑dokumentumokból stb.

## **PowerPoint importálása PDF‑ből**

Ebben az esetben egy PDF‑et konvertál PowerPoint prezentációvá.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Hozzon létre egy példányt a presentation osztályból. 
2. Hívja meg az [AddFromPdf()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) metódust, és adja meg a PDF fájlt. 
3. Használja a [Save()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) metódust a fájl PowerPoint formátumban való mentéséhez.

Ez a C++ kód bemutatja a PDF‑ról PowerPointra történő átalakítást:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Tipp" color="info" %}} 

Érdemes kipróbálni az **Aspose ingyenes** [PDF to PowerPoint](https://products.aspose.app/slides/hu/import/pdf-to-powerpoint) webalkalmazást, mivel ez élő példája a leírt folyamatnak. 

{{% /alert %}} 

## **PowerPoint importálása HTML‑ből**

Ebben az esetben egy HTML‑dokumentumot konvertál PowerPoint prezentációvá.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation/) osztályból. 
2. Hívja meg a [AddFromHtml()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) metódust, és adja meg a HTML fájlt. 
3. Használja a [Save()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) metódust a fájl PowerPoint formátumban való mentéséhez.

Ez a C++ kód bemutatja a HTML‑ról PowerPointra történő átalakítást:

```c++
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Megjegyzés" color="warning" %}} 

Az Aspose.Slides segítségével a HTML‑t más népszerű formátumokra is konvertálhatja: 

* [HTML képre](https://products.aspose.com/slides/hu/cpp/conversion/html-to-image/)
* [HTML JPG‑re](https://products.aspose.com/slides/hu/cpp/conversion/html-to-jpg/)
* [HTML XML‑re](https://products.aspose.com/slides/hu/cpp/conversion/html-to-xml/)
* [HTML TIFF‑re](https://products.aspose.com/slides/hu/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **GYIK**

### Megmaradnak-e a táblázatok PDF importálása során, és javítható‑e a felismerésük?

A táblázatokat importálás közben fel lehet ismerni; a [PdfImportOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.import/pdfimportoptions/) tartalmaz egy [set_DetectTables](https://reference.aspose.com/slides/hu/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) metódust, amely engedélyezi a táblázatok felismerését. A hatékonyság a PDF szerkezetétől függ.