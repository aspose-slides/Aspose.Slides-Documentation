---
title: Präsentationen aus PDF oder HTML in C++ importieren
linktitle: Präsentation importieren
type: docs
weight: 60
url: /de/cpp/import-presentation/
keywords:
- Präsentation importieren
- Folien importieren
- PDF importieren
- HTML importieren
- PDF zu Präsentation
- PDF zu PPT
- PDF zu PPTX
- PDF zu ODP
- HTML zu Präsentation
- HTML zu PPT
- HTML zu PPTX
- HTML zu ODP
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Importieren Sie mühelos PDF- und HTML-Dokumente in PowerPoint- und OpenDocument-Präsentationen in C++ mit Aspose.Slides für nahtlose, leistungsstarke Folienverarbeitung."
---

Mit [**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/) können Sie Präsentationen aus Dateien anderer Formate importieren. Aspose.Slides stellt die Klasse [SlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection) zur Verfügung, um Präsentationen aus PDF-, HTML-Dokumenten usw. zu importieren.

## **PowerPoint aus PDF importieren**

In diesem Fall können Sie ein PDF in eine PowerPoint-Präsentation konvertieren.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Instanziieren Sie ein Objekt der Presentation-Klasse. 
2. Rufen Sie die Methode [AddFromPdf()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) auf und übergeben Sie die PDF-Datei. 
3. Verwenden Sie die Methode [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) um die Datei im PowerPoint-Format zu speichern.

Dieser C++-Code demonstriert die PDF-zu-PowerPoint-Operation:
```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```


{{% alert  title="Tip" color="primary" %}} 

Vielleicht möchten Sie die kostenlose **Aspose** [PDF zu PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) Web‑App ausprobieren, da sie eine Live‑Implementierung des hier beschriebenen Vorgangs bietet. 

{{% /alert %}} 

## **PowerPoint aus HTML importieren**

In diesem Fall können Sie ein HTML-Dokument in eine PowerPoint-Präsentation konvertieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). 
2. Rufen Sie die Methode [AddFromHtml()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) auf und übergeben Sie die HTML-Datei. 
3. Verwenden Sie die Methode [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) um die Datei im PowerPoint-Format zu speichern.

Dieser C++-Code demonstriert die HTML‑zu‑PowerPoint-Operation:
```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```


{{% alert title="Note" color="warning" %}} 

Sie können Aspose.Slides auch verwenden, um HTML in andere gängige Dateiformate zu konvertieren: 

* [HTML zu Bild](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **FAQ**

**Werden Tabellen beim Importieren eines PDFs erhalten und kann ihre Erkennung verbessert werden?**

Tabellen können beim Import erkannt werden; [PdfImportOptions](https://reference.aspose.com/slides/cpp/aspose.slides.import/pdfimportoptions/) enthält die Methode [set_DetectTables](https://reference.aspose.com/slides/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/), die die Tabellenerkennung aktiviert. Die Wirksamkeit hängt von der Struktur des PDFs ab.