---
title: PPT und PPTX nach PDF in C++ konvertieren [Erweiterte Funktionen enthalten]
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
description: "PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in C++ konvertieren mit Aspose.Slides, inklusive schneller Codebeispiele und erweiterten Konvertierungsoptionen."
---

## **Übersicht**

Das Konvertieren von PowerPoint-Präsentationen (PPT, PPTX, ODP usw.) in das PDF-Format in C++ bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und die Erhaltung des Layouts und der Formatierung Ihrer Präsentation. Dieses Handbuch zeigt, wie man Präsentationen in PDF-Dokumente konvertiert, verschiedene Optionen zur Steuerung der Bildqualität verwendet, ausgeblendete Folien einschließt, PDF-Dateien mit Passwort schützt, Schriftartsubstitutionen erkennt, bestimmte Folien für die Konvertierung auswählt und Compliance-Standards auf Ausgabedokumente anwendet.

## **PowerPoint-zu-PDF-Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse und speichern Sie die Präsentation anschließend als PDF mit der Methode `Save`. Die [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse stellt die `Save`‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides für C++ fügt in Ausgabedokumente seine API‑Informationen und Versionsnummer ein. Zum Beispiel füllt Aspose.Slides beim Konvertieren einer Präsentation zu PDF das Feld Application mit „*Aspose.Slides*“ und das Feld PDF Producer mit einem Wert in der Form „*Aspose.Slides v XX.XX*“. **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren von:

* Gesamte Präsentationen zu PDF
* Bestimmte Folien einer Präsentation zu PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs den Originalpräsentationen sehr nahe kommen. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint zu PDF konvertieren**

Der Standard‑PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualität in PDF zu konvertieren.

Dieser C++‑Code zeigt, wie man eine Präsentation (PPT, PPTX, ODP usw.) in PDF konvertiert:
```c++
// Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei repräsentiert.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Speichern Sie die Präsentation als PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```


{{%  alert  color="primary"  %}} 
Aspose bietet einen kostenlosen Online‑**PowerPoint‑zu‑PDF‑Konverter**(https://products.aspose.app/slides/conversion/ppt-to-pdf) an, der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test durchführen, um die hier beschriebene Vorgehensweise live umzusetzen.
{{% /alert %}}

## **PowerPoint zu PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen—Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)—zur Verfügung, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Passwort sperren oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint zu PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie die gewünschte Qualitätseinstellung für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden sollen, ein Komprimierungslevel für Text setzen, die DPI für Bilder konfigurieren und vieles mehr.

Das nachstehende Codebeispiel demonstriert, wie man eine PowerPoint‑Präsentation mit mehreren benutzerdefinierten Optionen in PDF konvertiert.
```c++
// Instanziieren Sie die PdfOptions‑Klasse.
auto pdfOptions = MakeObject<PdfOptions>();

// Legen Sie die Qualität für JPG‑Bilder fest.
pdfOptions->set_JpegQuality(90);

// Legen Sie die DPI für Bilder fest.
pdfOptions->set_SufficientResolution(300);

// Legen Sie das Verhalten für Metadateien fest.
pdfOptions->set_SaveMetafilesAsPng(true);

// Legen Sie die Textkomprimierungsstufe für Textinhalte fest.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Definieren Sie den PDF‑Compliance‑Modus.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei darstellt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Speichern Sie die Präsentation als PDF‑Dokument.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **PowerPoint zu PDF mit ausgeblendeten Folien konvertieren**

Enthält eine Präsentation ausgeblendete Folien, können Sie die Methode [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) der Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) verwenden, um die ausgeblendeten Folien als Seiten im resultierenden PDF aufzunehmen.

Dieser C++‑Code zeigt, wie man eine PowerPoint‑Präsentation mit einbezogenen ausgeblendeten Folien in PDF konvertiert:
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

Dieser C++‑Code demonstriert, wie man eine PowerPoint‑Präsentation mithilfe der Schutzparameter der Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) in ein passwortgeschütztes PDF konvertiert:
```c++
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instanziieren Sie die PdfOptions-Klasse.
auto pdfOptions = MakeObject<PdfOptions>();

// Legen Sie ein PDF-Passwort und Zugriffsberechtigungen fest.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Speichern Sie die Präsentation als PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **Schriftartsubstitutionen erkennen**

Aspose.Slides stellt die Methode [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) der Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) bereit, die es Ihnen ermöglicht, während des Präsentation‑zu‑PDF‑Konvertierungsprozesses Schriftartsubstitutionen zu erkennen.

Dieser C++‑Code zeigt, wie man Schriftartsubstitutionen erkennt:
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

    // Setzen Sie den Warnungs-Callback in den PDF-Optionen.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Speichern Sie die Präsentation als PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```


{{%  alert color="primary"  %}} 
Weitere Informationen zum Empfangen von Callback‑Funktionen für Schriftartsubstitutionen während des Rendering‑Vorgangs finden Sie unter [Getting Warning Callbacks for Fonts Substitution](/slides/de/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Weitere Informationen zu Schriftartsubstitutionen finden Sie im Artikel [Font Substitution](/slides/de/cpp/font-substitution/).
{{% /alert %}} 

## **Ausgewählte Folien von PowerPoint zu PDF konvertieren**

Dieser C++‑Code demonstriert, wie man nur bestimmte Folien einer PowerPoint‑Präsentation in PDF konvertiert:
```C++
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei repräsentiert.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Array von Foliennummern festlegen.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Speichern Sie die Präsentation als PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```


## **PowerPoint zu PDF mit benutzerdefinierter Foliengröße konvertieren**

Dieser C++‑Code demonstriert, wie man eine PowerPoint‑Präsentation mit einer angegebenen Foliengröße in PDF konvertiert:
```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Erstellen Sie eine neue Präsentation mit einer angepassten Foliengröße.
auto resizedPresentation = MakeObject<Presentation>();

// Legen Sie die benutzerdefinierte Foliengröße fest.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Klonen Sie die erste Folie aus der Originalpräsentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Speichern Sie die skalierte Präsentation als PDF mit Notizen.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```


## **PowerPoint zu PDF im Notizfolien‑Modus konvertieren**

Dieser C++‑Code demonstriert, wie man eine PowerPoint‑Präsentation in ein PDF konvertiert, das Notizen enthält:
```C++
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Konfigurieren Sie die PDF-Optionen mit Notizen-Layout.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Speichern Sie die Präsentation als PDF mit Notizen.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


## **Barrierefreiheits‑ und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht die Verwendung eines Konvertierungsverfahrens, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument in PDF exportieren und dabei einen dieser Compliance‑Standards verwenden: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser C++‑Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der basierend auf verschiedenen Compliance‑Standards mehrere PDFs erzeugt:
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
Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, mit denen Sie PDF‑Dateien in gängige Dateiformate konvertieren können. Sie können [PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/) und [PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) Konvertierungen durchführen. Weitere PDF‑Konvertierungsoperationen zu speziellen Formaten—[PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), und [PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—werden ebenfalls unterstützt.
{{% /alert %}}

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien batchweise in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien in PDF. Sie können Ihre Dateien iterieren und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**

Auf jeden Fall. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie füge ich ausgeblendete Folien in das PDF ein?**

Verwenden Sie die Methode `set_ShowHiddenSlides` in der Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), um ausgeblendete Folien im resultierenden PDF zu berücksichtigen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie `set_JpegQuality` und `set_SufficientResolution` in der Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) verwenden, um hochqualitative Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die verschiedenen Standards entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente die Anforderungen an Barrierefreiheit und Archivierung erfüllen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für C++ Dokumentation](/slides/de/cpp/)
- [Aspose.Slides für C++ API‑Referenz](https://reference.aspose.com/slides/cpp/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)