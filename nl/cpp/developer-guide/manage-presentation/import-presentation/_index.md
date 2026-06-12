---
title: Importeer presentaties van PDF of HTML in C++
linktitle: Importeer presentatie
type: docs
weight: 60
url: /nl/cpp/import-presentation/
keywords:
- import presentatie
- import dia
- import PDF
- import HTML
- PDF naar presentatie
- PDF naar PPT
- PDF naar PPTX
- PDF naar ODP
- HTML naar presentatie
- HTML naar PPT
- HTML naar PPTX
- HTML naar ODP
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Importeer moeiteloos PDF- en HTML-documenten naar PowerPoint- en OpenDocument-presentaties in C++ met Aspose.Slides voor naadloze, high-performance dia-verwerking."
---
## **Introductie**

Met [**Aspose.Slides for C++**](https://products.aspose.com/slides/nl/cpp/) kunt u presentaties importeren uit bestanden in andere formaten. Aspose.Slides biedt de [SlideCollection](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.slide_collection)‑klasse om presentaties te importeren vanuit PDF, HTML‑documenten, enz.

## **PowerPoint importeren vanuit PDF**

In dit geval converteert u een PDF naar een PowerPoint‑presentatie.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Instantieer een object van de presentatieklasse.  
2. Roep de [AddFromPdf()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5)‑methode aan en geef het PDF‑bestand door.  
3. Gebruik de [Save()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e)‑methode om het bestand op te slaan in PowerPoint‑formaat.

Deze C++‑code demonstreert de PDF‑naar‑PowerPoint‑bewerking:

```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Tip" color="primary" %}} 

U kunt de gratis **Aspose**‑webapp [PDF naar PowerPoint](https://products.aspose.app/slides/nl/import/pdf-to-powerpoint) uitproberen, omdat deze een live‑implementatie van het hier beschreven proces biedt. 

{{% /alert %}} 

## **PowerPoint importeren vanuit HTML**

In dit geval converteert u een HTML‑document naar een PowerPoint‑presentatie.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation/)‑klasse.  
2. Roep de [AddFromHtml()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965)‑methode aan en geef het HTML‑bestand door.  
3. Gebruik de [Save()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e)‑methode om het bestand op te slaan in PowerPoint‑formaat.

Deze C++‑code demonstreert de HTML‑naar‑PowerPoint‑bewerking:

```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

U kunt Aspose.Slides ook gebruiken om HTML naar andere populaire bestandsformaten te converteren: 

* [HTML naar afbeelding](https://products.aspose.com/slides/nl/cpp/conversion/html-to-image/)
* [HTML naar JPG](https://products.aspose.com/slides/nl/cpp/conversion/html-to-jpg/)
* [HTML naar XML](https://products.aspose.com/slides/nl/cpp/conversion/html-to-xml/)
* [HTML naar TIFF](https://products.aspose.com/slides/nl/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **FAQ**

**Worden tabellen behouden bij het importeren van een PDF, en kan hun detectie worden verbeterd?**

Tabellen kunnen tijdens het importeren worden gedetecteerd; [PdfImportOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.import/pdfimportoptions/) bevat een [set_DetectTables](https://reference.aspose.com/slides/nl/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/)‑methode die tabelherkenning inschakelt. De effectiviteit hangt af van de structuur van de PDF.