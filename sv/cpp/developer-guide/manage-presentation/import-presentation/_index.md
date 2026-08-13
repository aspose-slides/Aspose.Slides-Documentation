---
title: Importera presentationer från PDF eller HTML i C++
linktitle: Importera presentation
type: docs
weight: 60
url: /sv/cpp/import-presentation/
keywords:
- importera presentation
- importera bild
- importera PDF
- importera HTML
- PDF till presentation
- PDF till PPT
- PDF till PPTX
- PDF till ODP
- HTML till presentation
- HTML till PPT
- HTML till PPTX
- HTML till ODP
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Importera PDF- och HTML-dokument till PowerPoint- och OpenDocument-presentationer i C++ med Aspose.Slides på ett smidigt och högpresterande sätt för bildbehandling."
---
## **Introduktion**

Genom att använda [**Aspose.Slides for C++**](https://products.aspose.com/slides/sv/cpp/), kan du importera presentationer från filer i andra format. Aspose.Slides tillhandahåller klassen [SlideCollection](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.slide_collection) för att låta dig importera presentationer från PDF, HTML‑dokument etc.

## **Importera PowerPoint från PDF**

I det här fallet konverterar du en PDF till en PowerPoint‑presentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Skapa en instans av presentationsklassen. 
2. Anropa metoden [AddFromPdf()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) och skicka PDF‑filen. 
3. Använd metoden [Save()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) för att spara filen i PowerPoint‑format.

Den här C++‑koden visar PDF‑till‑PowerPoint‑operationen:

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

{{% alert  title="Tip" color="info" %}} 
Du kanske vill prova **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/sv/import/pdf-to-powerpoint) webbapp eftersom den är en live‑implementation av processen som beskrivs här. 
{{% /alert %}} 

## **Importera PowerPoint från HTML**

I det här fallet konverterar du ett HTML‑dokument till en PowerPoint‑presentation.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation/). 
2. Anropa metoden [AddFromHtml()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) och skicka HTML‑filen. 
3. Använd metoden [Save()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) för att spara filen i PowerPoint‑format.

Den här C++‑koden visar HTML‑till‑PowerPoint‑operationen:

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

{{% alert title="Note" color="warning" %}} 
Du kan också använda Aspose.Slides för att konvertera HTML till andra populära filformat: 

* [HTML till bild](https://products.aspose.com/slides/sv/cpp/conversion/html-to-image/)
* [HTML till JPG](https://products.aspose.com/slides/sv/cpp/conversion/html-to-jpg/)
* [HTML till XML](https://products.aspose.com/slides/sv/cpp/conversion/html-to-xml/)
* [HTML till TIFF](https://products.aspose.com/slides/sv/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **Vanliga frågor**

### Behålls tabeller vid import av en PDF, och kan deras detektering förbättras?

Tabeller kan upptäckas under import; [PdfImportOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.import/pdfimportoptions/) innehåller en metod [set_DetectTables](https://reference.aspose.com/slides/sv/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) som möjliggör tabelligenkänning. Effektiviteten beror på PDF‑filens struktur.