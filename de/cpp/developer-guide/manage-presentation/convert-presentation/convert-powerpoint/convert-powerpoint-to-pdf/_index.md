---
title: PowerPoint in PDF umwandeln in C++
linktitle: PowerPoint in PDF umwandeln
type: docs
weight: 40
url: /cpp/convert-powerpoint-to-pdf/
keywords:
- PowerPoint umwandeln
- Präsentation
- PowerPoint in PDF
- PPT in PDF
- PPTX in PDF
- PowerPoint als PDF speichern
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides für C++
description: "PowerPoint-Präsentationen in PDF in C++ umwandeln. PowerPoint als PDF mit Compliance- oder Zugänglichkeitsstandards speichern."
---

## **Übersicht**

Das Umwandeln von PowerPoint-Dokumenten in PDF-Format bietet mehrere Vorteile, einschließlich der Sicherstellung der Kompatibilität über verschiedene Geräte hinweg sowie der Erhaltung des Layouts und der Formatierung Ihrer Präsentation. Dieser Artikel zeigt Ihnen, wie Sie Präsentationen in PDF-Dokumente umwandeln, verschiedene Optionen zur Steuerung der Bildqualität verwenden, versteckte Folien einbeziehen, PDF-Dokumente passwortschützen, Schriftartsubstitutionen erkennen, Folien zur Umwandlung auswählen und Compliance-Standards auf Ausgabedokumente anwenden.

## **PowerPoint in PDF Umwandlungen**

Mit Aspose.Slides können Sie Präsentationen in diesen Formaten in PDF umwandeln:

* PPT
* PPTX
* ODP

Um eine Präsentation in PDF umzuwandeln, müssen Sie einfach den Dateinamen als Argument in der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) Klasse übergeben und dann die Präsentation mit der [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) Methode als PDF speichern. Die [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) Klasse stellt die [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) Methode bereit, die typischerweise verwendet wird, um eine Präsentation in PDF umzuwandeln.

{{%  alert title="HINWEIS"  color="warning"   %}} 

Aspose.Slides für C++ schreibt API-Informationen und Versionsnummern direkt in Ausgabedokumente. Wenn es beispielsweise eine Präsentation in PDF umwandelt, füllt Aspose.Slides für C++ das Anwendungsfeld mit dem Wert '*Aspose.Slides*' und das PDF-Produzentenfeld mit einem Wert im Format '*Aspose.Slides v XX.XX*'. **Hinweis**: Sie können Aspose.Slides für C++ nicht anweisen, diese Informationen aus den Ausgabedokumenten zu ändern oder zu entfernen.

{{% /alert %}}

Aspose.Slides ermöglicht es Ihnen, zu konvertieren:

* eine gesamte Präsentation in PDF
* spezifische Folien in einer Präsentation in PDF
* eine Präsentation 

Aspose.Slides exportiert Präsentationen in PDF auf eine Weise, die den Inhalt der resultierenden PDFs sehr ähnlich den Originalpräsentationen macht. Diese bekannten Elemente und Attribute werden oft korrekt bei der Umwandlung von Präsentation in PDF gerendert:

* Bilder
* Textfelder und andere Formen
* Texte und deren Formatierung
* Absätze und deren Formatierung
* Hyperlinks
* Kopf- und Fußzeilen
* Aufzählungen
* Tabellen

## **PowerPoint in PDF umwandeln**

Der standardmäßige PowerPoint-PDF-Umwandlungsprozess wird mit Standardoptionen durchgeführt. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen in PDF mit maximaler Qualität umzuwandeln.

<a name="cpp-powerpoint-to-pdf" id="cpp-powerpoint-to-pdf"><strong>Schritte: PowerPoint in PDF umwandeln in C++</strong></a> |
<a name="cpp-ppt-to-pdf" id="cpp-ppt-to-pdf"><strong>Schritte: PPT in PDF umwandeln in C++</strong></a> |
<a name="cpp-pptx-to-pdf" id="cpp-pptx-to-pdf"><strong>Schritte: PPTX in PDF umwandeln in C++</strong></a> |
<a name="cpp-odp-to-pdf" id="cpp-odp-to-pdf"><strong>Schritte: ODP in PDF umwandeln in C++</strong></a>

Dieser C++-Code zeigt Ihnen, wie Sie eine PowerPoint in PDF umwandeln:

```c++
// Instanziiert eine Presentation-Klasse, die eine PowerPoint-Datei repräsentiert
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.ppt");

// Speichert die Präsentation als PDF
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose bietet einen kostenlosen Online-[**PowerPoint zu PDF-Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Umwandlungsprozess von Präsentation zu PDF demonstriert. Für eine Live-Demonstration des hier beschriebenen Verfahrens können Sie einen Test mit dem Konverter durchführen.

{{% /alert %}}

## **PowerPoint in PDF mit Optionen umwandeln**

Aspose.Slides bietet benutzerdefinierte Optionen – Eigenschaften unter der [PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/) Klasse – die es Ihnen ermöglichen, die PDF (die aus dem Umwandlungsprozess resultiert) anzupassen, die PDF mit einem Passwort zu schützen oder sogar anzugeben, wie der Umwandlungsprozess ablaufen soll.

### **PowerPoint in PDF mit benutzerdefinierten Optionen umwandeln**

Mit benutzerdefinierten Umwandlungsoptionen können Sie Ihre bevorzugte Qualitätseinstellung für Rasterbilder festlegen, angeben, wie Metadateien behandelt werden sollen, ein Komprimierungsniveau für Texte festlegen, DPI für Bilder festlegen usw.

Das folgende Codebeispiel demonstriert einen Vorgang, bei dem eine PowerPoint-Präsentation mit mehreren benutzerdefinierten Optionen in PDF umgewandelt wird:

```c++
// Instanziiert die PdfOptions-Klasse
auto pdfOptions = System::MakeObject<PdfOptions>();

// Setzt die Qualität für JPG-Bilder
pdfOptions->set_JpegQuality(90);

// Setzt DPI für Bilder
pdfOptions->set_SufficientResolution(300);

// Setzt das Verhalten für Metadateien
pdfOptions->set_SaveMetafilesAsPng(true);

// Setzt das Komprimierungsniveau für textuelle Inhalte
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Definiert den PDF-Compliance-Modus
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Instanziiert die Presentation-Klasse, die ein PowerPoint-Dokument darstellt
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// Speichert die Präsentation als PDF-Dokument
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **PowerPoint in PDF mit versteckten Folien umwandeln**

Wenn eine Präsentation versteckte Folien enthält, können Sie eine benutzerdefinierte Option - die [ShowHiddenSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options#ad11e5a17110d70456df91cc1a5dade23) Eigenschaft aus der [PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/) Klasse - verwenden, um Aspose.Slides anzuweisen, die versteckten Folien als Seiten in der resultierenden PDF einzuschließen.

Dieser C++-Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in PDF umwandeln, wobei versteckte Folien einbezogen sind:

```c++
// Instanziiert eine Presentation-Klasse, die eine PowerPoint-Datei repräsentiert
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// Instanziiert die PdfOptions-Klasse
auto pdfOptions = System::MakeObject<PdfOptions>();

// Fügt versteckte Folien hinzu
pdfOptions->set_ShowHiddenSlides(true);

// Speichert die Präsentation als PDF
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
```

### **PowerPoint in passwortgeschützte PDF umwandeln**

Dieser C++-Code zeigt Ihnen, wie Sie eine PowerPoint in eine passwortgeschützte PDF umwandeln (mit Schutzparametern aus der [PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/) Klasse):

```c++
// Instanziiert ein Presentation-Objekt, das eine PowerPoint-Datei repräsentiert
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

/// Instanziiert die PdfOptions-Klasse
auto pdfOptions = System::MakeObject<PdfOptions>();

// Setzt das PDF-Passwort und die Zugriffsberechtigungen
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Speichert die Präsentation als PDF
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
```

### **Schriftartsubstitutionen erkennen**

Aspose.Slides bietet die [get_WarningCallback()](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/get_warningcallback/) Methode unter der [SaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/) Klasse, um Ihnen zu ermöglichen, Schriftartsubstitutionen im Umwandlungsprozess von Präsentationen in PDF zu erkennen. 

Dieser C++-Code zeigt Ihnen, wie Sie Schriftartsubstitutionen erkennen:

```c++
class FontSubstSendsWarningCallback : public Warnings::IWarningCallback
{
public:
    Warnings::ReturnAction Warning(System::SharedPtr<Warnings::IWarningInfo> warning) override;
};

Warnings::ReturnAction FontSubstSendsWarningCallback::Warning(System::SharedPtr<Warnings::IWarningInfo> warning)
{
    if (warning->get_WarningType() == Warnings::WarningType::CompatibilityIssue)
    {
        return Warnings::ReturnAction::Continue;
    }

    if (warning->get_WarningType() == Warnings::WarningType::DataLoss && warning->get_Description().StartsWith(u"Schriftart wird substituiert"))
    {
        System::Console::WriteLine(u"Schriftartsubstitution-Warnung: {0}", warning->get_Description());
    }

    return Warnings::ReturnAction::Continue;
}
```

und der nächste C++-Code zeigt, wie man die vorherige Klasse verwendet:

```c++
int main()
{
    System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
    System::SharedPtr<FontSubstSendsWarningCallback> warningCallback = System::MakeObject<FontSubstSendsWarningCallback>();
    loadOptions->set_WarningCallback(warningCallback);

    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);
    return 0;
}
```

{{%  alert color="primary"  %}} 

Für weitere Informationen zum Erhalten von Rückmeldungen über Schriftartsubstitutionen im Rendering-Prozess siehe [Erhalten von Warnungs-Rückmeldungen zu Schriftartsubstitutionen](https://docs.aspose.com/slides/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Für weitere Informationen zur Schriftartsubstitution siehe den Artikel [Schriftartsubstitution](https://docs.aspose.com/slides/cpp/font-substitution/).

{{% /alert %}} 

## **Ausgewählte Folien in PowerPoint in PDF umwandeln**

Dieser C++-Code zeigt Ihnen, wie Sie spezifische Folien in einer PowerPoint-Präsentation in PDF umwandeln:

```C++
// Instanziiert ein Presentation-Objekt, das eine PowerPoint-Datei repräsentiert
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// Setzt ein Array von Folienpositionen
auto slides = System::MakeArray<int32_t>({1, 3});

// Speichert die Präsentation als PDF
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
```

## **PowerPoint in PDF mit benutzerdefinierter Foliengröße umwandeln**

Dieser C++-Code zeigt Ihnen, wie Sie eine PowerPoint umwandeln, wenn ihre Foliengröße spezifiziert ist:

```C++
// Der Pfad zum Dokumentenverzeichnis.
String dataDir = GetDataPath()

// Instanziiert ein Presentation-Objekt, das eine PowerPoint-Datei darstellt 
auto presentation = System::MakeObject<Presentation>(dataDir + u"SelectedSlides.pptx");
auto auxPresentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auxPresentation->get_Slides()->InsertClone(0, slide);

// Setzt den Folientyp und die Größe 
auxPresentation->get_SlideSize()->SetSize(612.F, 792.F, SlideSizeScaleType::EnsureFit);

auto pdfOptions = System::MakeObject<PdfOptions>();
auto options = pdfOptions->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

auxPresentation->Save(dataDir + u"PDFnotes_out.pdf", SaveFormat::Pdf, pdfOptions);
```

## **PowerPoint in PDF im Notizen-Folien-Layout umwandeln**

Dieser C++-Code zeigt Ihnen, wie Sie eine PowerPoint in PDF-Notizen umwandeln:

```C++
// Der Pfad zum Dokumentenverzeichnis.
System::String dataDir = u"";

// Instanziiert eine Presentation-Klasse, die eine PowerPoint-Datei repräsentiert
auto presentation = System::MakeObject<Presentation>(dataDir + u"NotesFile.pptx");

auto pdfOptions = System::MakeObject<PdfOptions>();
auto options = pdfOptions->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// Speichert die Präsentation als PDF-Notizen
presentation->Save(dataDir + u"Pdf_Notes_out.tiff", SaveFormat::Pdf, pdfOptions);
```

## **Zugänglichkeits- und Compliance-Standards für PDF**

Aspose.Slides erlaubt Ihnen die Nutzung eines Umwandlungsverfahrens, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint-Dokument in PDF umwandeln, wobei Sie einer dieser Compliance-Standards verwenden: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser C++-Code demonstriert einen PowerPoint-in-PDF-Umwandlungsprozess, bei dem mehrere PDFs basierend auf verschiedenen Compliance-Standards erstellt werden:

```C++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = System::MakeObject<PdfOptions>();
pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
pres->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = System::MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
pres->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = System::MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);
pres->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);
```

{{% alert title="Hinweis" color="warning" %}} 

Die Unterstützung von Aspose.Slides für PDF-Umwandlungsoperationen erstreckt sich auch auf die Möglichkeit, PDF in die gängigsten Dateiformate zu konvertieren. Sie können [PDF zu HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) Umwandlungen durchführen. Weitere PDF-Umwandlungsoperationen in spezialisierte Formate – [PDF zu SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/) und [PDF zu XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.

{{% /alert %}}