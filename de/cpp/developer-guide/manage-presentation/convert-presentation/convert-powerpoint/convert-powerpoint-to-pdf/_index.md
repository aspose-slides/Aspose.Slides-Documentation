---
title: PPT und PPTX in PDF konvertieren in C++ [Erweiterte Funktionen enthalten]
linktitle: PowerPoint zu PDF
type: docs
weight: 40
url: /de/cpp/convert-powerpoint-to-pdf/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- PowerPoint zu PDF
- Präsentation zu PDF
- PPT zu PDF
- PPT in PDF konvertieren
- PPTX zu PDF
- PPTX in PDF konvertieren
- PowerPoint als PDF speichern
- PPT als PDF speichern
- PPTX als PDF speichern
- PPT nach PDF exportieren
- PPTX nach PDF exportieren
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in C++ mit Aspose.Slides konvertieren, mit schnellen Codebeispielen und erweiterten Konvertierungsoptionen."
---

## **Übersicht**

Das Konvertieren von PowerPoint-Präsentationen (PPT, PPTX, ODP usw.) in das PDF-Format in C++ bietet mehrere Vorteile, darunter die Kompatibilität über verschiedene Geräte hinweg und die Bewahrung des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF-Dokumente konvertiert werden, wie verschiedene Optionen zur Steuerung der Bildqualität verwendet werden, versteckte Folien einbezogen, PDF-Dateien mit einem Passwort geschützt, Schriftarten‑Ersetzungen erkannt, bestimmte Folien zur Konvertierung ausgewählt und Compliance‑Standards auf Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) und speichern Sie die Präsentation anschließend mit einer `Save`‑Methode als PDF. Die Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) stellt die `Save`‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides für C++ fügt seinen API‑Informationen und die Versionsnummer in Ausgabedokumente ein. Beispielsweise füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld „Application“ mit „*Aspose.Slides*“ und das Feld „PDF Producer“ mit einem Wert in der Form „*Aspose.Slides v XX.XX*“. **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus den Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren von:

* Kompletten Präsentationen zu PDF
* Bestimmten Folien einer Präsentation zu PDF

Aspose.Slides exportiert Präsentationen zu PDF und stellt sicher, dass die resultierenden PDFs dem Original sehr nahe kommen. Elemente und Attribute werden dabei exakt wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der Standard‑PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet die Standardeinstellungen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualität in PDF zu konvertieren.

Dieser C++‑Code zeigt, wie Sie eine Präsentation (PPT, PPTX, ODP usw.) in PDF konvertieren:
```c++
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Speichern Sie die Präsentation als PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```


{{%  alert  color="primary"  %}} 
Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test durchführen, um die hier beschriebene Vorgehensweise live zu sehen.
{{% /alert %}}

## **PowerPoint zu PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) – bereit, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Passwort schützen oder das Vorgehen des Konvertierungsprozesses festlegen können.

### **PowerPoint zu PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitäts‑Einstellung für Raster‑Bilder festlegen, festlegen, wie Metadateien behandelt werden, eine Kompressionsstufe für Text setzen, DPI für Bilder konfigurieren und vieles mehr.

Der nachfolgende Code‑Beispiel zeigt, wie Sie eine PowerPoint‑Präsentation mit mehreren benutzerdefinierten Optionen in PDF konvertieren.
```c++
// Instanziieren Sie die PdfOptions-Klasse.
auto pdfOptions = MakeObject<PdfOptions>();

// Legen Sie die Qualität für JPG-Bilder fest.
pdfOptions->set_JpegQuality(90);

// Legen Sie die DPI für Bilder fest.
pdfOptions->set_SufficientResolution(300);

// Legen Sie das Verhalten für Metadateien fest.
pdfOptions->set_SaveMetafilesAsPng(true);

// Legen Sie die Textkompressionsstufe für Textinhalte fest.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Definieren Sie den PDF-Konformitätsmodus.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Speichern Sie die Präsentation als PDF-Dokument.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **PowerPoint zu PDF mit versteckten Folien konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie die Methode [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) der Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) verwenden, um die versteckten Folien als Seiten in das resultierende PDF aufzunehmen.

Dieser C++‑Code zeigt, wie Sie eine PowerPoint‑Präsentation mit einbezogenen versteckten Folien in PDF konvertieren:
```c++
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instanziieren Sie die PdfOptions-Klasse.
auto pdfOptions = MakeObject<PdfOptions>();

// Versteckte Folien hinzufügen.
pdfOptions->set_ShowHiddenSlides(true);

// Speichern Sie die Präsentation als PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **PowerPoint zu passwortgeschütztem PDF konvertieren**

Dieser С++‑Code demonstriert, wie Sie eine PowerPoint‑Präsentation mit den Schutz‑Parametern aus der Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) in ein passwortgeschütztes PDF konvertieren:
```c++
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instanziieren Sie die PdfOptions-Klasse.
auto pdfOptions = MakeObject<PdfOptions>();

// PDF-Passwort und Zugriffsberechtigungen festlegen.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Präsentation als PDF speichern.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **Schriftarten‑Ersetzungen erkennen**

Aspose.Slides stellt die Methode [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) unter der Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) bereit, mit der Sie während des Präsentation‑zu‑PDF‑Konvertierungsprozesses Schriftarten‑Ersetzungen erkennen können.

Dieser C++‑Code zeigt, wie Sie Schriftarten‑Ersetzungen erkennen:
```c++
// Implementierung des Warnungs-Callbacks.
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss && 
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Warnungs-Callback in den PDF-Optionen festlegen.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Präsentation als PDF speichern.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```


{{%  alert color="primary"  %}} 
Weitere Informationen zum Empfangen von Callbacks für Schriftarten‑Ersetzungen während des Rendering‑Vorgangs finden Sie unter [Getting Warning Callbacks for Fonts Substitution](/slides/de/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Weitere Informationen zur Schriftarten‑Ersetzung finden Sie im Artikel [Font Substitution](/slides/de/cpp/font-substitution/).
{{% /alert %}} 

## **Ausgewählte Folien von PowerPoint zu PDF konvertieren**

Dieser C++‑Code demonstriert, wie Sie nur bestimmte Folien einer PowerPoint‑Präsentation in PDF konvertieren:
```C++
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Array von Foliennummern festlegen.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Präsentation als PDF speichern.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```


## **PowerPoint zu PDF mit benutzerdefinierter Foliengröße konvertieren**

Dieser C++‑Code demonstriert, wie Sie eine PowerPoint‑Präsentation mit einer angegebenen Foliengröße in PDF konvertieren:
```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
auto resizedPresentation = MakeObject<Presentation>();

// Set the custom slide size.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone the first slide from the original presentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```


## **PowerPoint zu PDF im Notizfolien‑Modus konvertieren**

Dieser C++‑Code demonstriert, wie Sie eine PowerPoint‑Präsentation in ein PDF konvertieren, das Notizen enthält:
```C++
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Konfigurieren Sie die PDF-Optionen mit Notiz-Layout.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Speichern Sie die Präsentation als PDF mit Notizen.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


## **Barrierefreiheit und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument mit einem dieser Compliance‑Standards in PDF exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser C++‑Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Compliance‑Standards erzeugt:
```C++
auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```


{{% alert title="Note" color="warning" %}} 
Aspose.Slides unterstützt PDF‑Konvertierungs‑Operationen, mit denen Sie PDF‑Dateien in gängige Dateiformate konvertieren können. Sie können [PDF zu HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF zu image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) Konvertierungen durchführen. Weitere PDF‑Konvertierungs‑Operationen zu spezialisierten Formaten – [PDF zu SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/) und [PDF zu XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.
{{% /alert %}}

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien massenweise in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien zu PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**

Absolut. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie füge ich versteckte Folien in das PDF ein?**

Verwenden Sie die Methode `set_ShowHiddenSlides` in der Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), um versteckte Folien in das resultierende PDF aufzunehmen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie `set_JpegQuality` und `set_SufficientResolution` der Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) verwenden, um hochqualitative Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides die PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die verschiedenen Standards entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente den Anforderungen an Barrierefreiheit und Langzeitarchivierung genügen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für C++ Dokumentation](/slides/de/cpp/)
- [Aspose.Slides für C++ API‑Referenz](https://reference.aspose.com/slides/cpp/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)