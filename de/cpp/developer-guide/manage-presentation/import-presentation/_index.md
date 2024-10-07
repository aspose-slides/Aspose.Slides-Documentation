---
title: Präsentation importieren - C++ PowerPoint API
linktitle: Präsentation importieren
type: docs
weight: 60
url: /cpp/import-presentation/
keywords: "PowerPoint importieren, PDF zu Präsentation, PDF zu PPTX, PDF zu PPT, C++, Aspose.Slides für C++"
description: "Importieren Sie eine PowerPoint-Präsentation aus PDF. Konvertieren Sie PDF in PowerPoint"
---

Mit [**Aspose.Slides für C++**](https://products.aspose.com/slides/cpp/) können Sie Präsentationen aus Dateien in anderen Formaten importieren. Aspose.Slides stellt die [SlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection) Klasse zur Verfügung, um Ihnen zu ermöglichen, Präsentationen aus PDF, HTML-Dokumenten usw. zu importieren.

## **PowerPoint aus PDF importieren**

In diesem Fall konvertieren Sie ein PDF in eine PowerPoint-Präsentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Erstellen Sie ein Objekt der Präsentationsklasse.
2. Rufen Sie die [AddFromPdf()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) Methode auf und übergeben Sie die PDF-Datei.
3. Verwenden Sie die [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) Methode, um die Datei im PowerPoint-Format zu speichern.

Dieser C++-Code demonstriert die PDF-zu-PowerPoint-Operation:

```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Tipp" color="primary" %}} 

Sie möchten vielleicht die **Aspose kostenlose** [PDF zu PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) Web-App ausprobieren, da dies eine direkte Umsetzung des hier beschriebenen Prozesses ist. 

{{% /alert %}} 

## **PowerPoint aus HTML importieren**

In diesem Fall konvertieren Sie ein HTML-Dokument in eine PowerPoint-Präsentation.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) Klasse.
2. Rufen Sie die [AddFromHtml()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) Methode auf und übergeben Sie die HTML-Datei.
3. Verwenden Sie die [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) Methode, um die Datei im PowerPoint-Format zu speichern.

Dieser C++-Code demonstriert die HTML-zu-PowerPoint-Operation:

```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Hinweis" color="warning" %}} 

Sie können Aspose.Slides auch verwenden, um HTML in andere gängige Dateiformate zu konvertieren:

* [HTML zu Bild](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}