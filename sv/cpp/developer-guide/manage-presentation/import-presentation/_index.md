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
description: "Importera enkelt PDF- och HTML-dokument till PowerPoint- och OpenDocument-presentationer i C++ med Aspose.Slides för smidig, högpresterande bildbehandling."
---
## **Introduktion**

Med [**Aspose.Slides for C++**](https://products.aspose.com/slides/sv/cpp/), kan du importera presentationer från filer i andra format. Aspose.Slides tillhandahåller klassen [SlideCollection](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.slide_collection) för att låta dig importera presentationer från PDF, HTML-dokument etc.

## **Importera PowerPoint från PDF**

I detta fall konverterar du en PDF till en PowerPoint‑presentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Skapa en instans av presentationsklassen. 
2. Anropa metoden [AddFromPdf()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) och skicka PDF‑filen. 
3. Använd metoden [Save()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) för att spara filen i PowerPoint‑format.

Denna C++‑kod visar PDF‑till‑PowerPoint‑operationen:

```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Tip" color="primary" %}} 

Du kanske vill kolla in **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/sv/import/pdf-to-powerpoint) webbapp eftersom den är en live‑implementation av processen som beskrivs här. 

{{% /alert %}} 

## **Importera PowerPoint från HTML**

I detta fall konverterar du ett HTML‑dokument till en PowerPoint‑presentation.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation/). 
2. Anropa metoden [AddFromHtml()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) och skicka HTML‑filen. 
3. Använd metoden [Save()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) för att spara filen i PowerPoint‑format.

Denna C++‑kod visar HTML‑till‑PowerPoint‑operationen:

```c++
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

## **FAQ**

**Behålls tabeller när man importerar en PDF, och kan deras upptäckt förbättras?**

Tabeller kan upptäckas vid import; [PdfImportOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.import/pdfimportoptions/) innehåller en [set_DetectTables](https://reference.aspose.com/slides/sv/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/)‑metod som möjliggör tabelligenkänning. Effektiviteten beror på PDF:ns struktur.