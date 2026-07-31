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
- PPT zu PDF konvertieren
- PPTX zu PDF
- PPTX zu PDF konvertieren
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
description: "Konvertieren Sie PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in C++ mit Aspose.Slides, mit schnellen Codebeispielen und erweiterten Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format in C++ bietet mehrere Vorteile, darunter die Kompatibilität mit verschiedenen Geräten und das Erhalten des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden demonstriert, wie Präsentationen in PDF‑Dokumente konvertiert werden, verschiedene Optionen zur Steuerung der Bildqualität verwendet werden, versteckte Folien einbezogen, PDF‑Dateien passwortgeschützt werden, Schriftart‑Ersetzungen erkannt, bestimmte Folien für die Konvertierung ausgewählt und Compliance‑Standards auf Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse und speichern Sie die Präsentation anschließend mit der `Save`‑Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse stellt die `Save`‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{%  alert title="HINWEIS"  color="warning"   %}} 

Aspose.Slides für C++ fügt seinen API‑Informationen und die Versionsnummer in Ausgabedokumente ein. Beim Konvertieren einer Präsentation in PDF befüllt Aspose.Slides das Feld „Application“ mit „*Aspose.Slides*“ und das Feld „PDF Producer“ mit einem Wert in der Form „*Aspose.Slides v XX.XX*“. **Hinweis**, dass Sie Aspose.Slides nicht anweisen können, diese Informationen in Ausgabedokumenten zu ändern oder zu entfernen.

{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren von:

* Gesamten Präsentationen in PDF
* Bestimmten Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und sorgt dafür, dass die resultierenden PDFs dem Original sehr nahekommen. Elemente und Attribute werden bei der Konvertierung exakt gerendert, darunter:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der Standard‑PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet die Standardeinstellungen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen bei maximaler Qualitätsstufe in PDF zu konvertieren.

Dieser C++‑Code zeigt, wie eine Präsentation (PPT, PPTX, ODP usw.) in PDF konvertiert wird:

```c++
// Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei darstellt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Speichern Sie die Präsentation als PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/de/conversion/ppt-to-pdf), der den Konvertierungsprozess von Präsentation zu PDF demonstriert. Sie können mit diesem Konverter einen Test für eine Live‑Implementierung des hier beschriebenen Verfahrens durchführen.

{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der [PdfOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pdfoptions/)‑Klasse – zur Verfügung, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Passwort schützen oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint in PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Rasterbilder festlegen, festlegen, wie Metadateien behandelt werden, ein Komprimierungsniveau für Text setzen, die DPI für Bilder konfigurieren und vieles mehr.

Das untenstehende Code‑Beispiel demonstriert, wie eine PowerPoint‑Präsentation mit mehreren benutzerdefinierten Optionen in PDF konvertiert wird:

```c++
// Instanziieren Sie die PdfOptions-Klasse.
auto pdfOptions = MakeObject<PdfOptions>();

// Setzen Sie die Qualität für JPG-Bilder.
pdfOptions->set_JpegQuality(90);

// Setzen Sie die DPI für Bilder.
pdfOptions->set_SufficientResolution(300);

// Legen Sie das Verhalten für Metadateien fest.
pdfOptions->set_SaveMetafilesAsPng(true);

// Setzen Sie das Textkomprimierungsniveau für textuellen Inhalt.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Definieren Sie den PDF-Compliance-Modus.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Speichern Sie die Präsentation als PDF-Dokument.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **PowerPoint in PDF mit versteckten Folien konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie die Methode [set_ShowHiddenSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) der [PdfOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pdfoptions/)‑Klasse verwenden, um die versteckten Folien als Seiten in das resultierende PDF einzuschließen.

Dieser C++‑Code zeigt, wie eine PowerPoint‑Präsentation mit einbezogenen versteckten Folien in PDF konvertiert wird:

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

### **PowerPoint in passwortgeschütztes PDF konvertieren**

Dieser C++‑Code demonstriert, wie eine PowerPoint‑Präsentation mithilfe der Schutzparameter der [PdfOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pdfoptions/)‑Klasse in ein passwortgeschütztes PDF konvertiert wird:

```c++
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instanziieren Sie die PdfOptions-Klasse.
auto pdfOptions = MakeObject<PdfOptions>();

// Setzen Sie ein PDF-Passwort und Zugriffsberechtigungen.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Speichern Sie die Präsentation als PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Schriftart‑Ersetzungen erkennen**

Aspose.Slides stellt die Methode [set_WarningCallback](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveoptions/set_warningcallback/) unter der [PdfOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pdfoptions/)‑Klasse bereit, mit der Sie Schriftart‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Dieser C++‑Code zeigt, wie Schriftart‑Ersetzungen erkannt werden:

```c++
// Implementierung des Warn-Callbacks.
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

    // Setzen Sie das Warn-Callback in den PDF-Optionen.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Speichern Sie die Präsentation als PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

Weitere Informationen zum Empfangen von Callback‑Benachrichtigungen für Schriftart‑Ersetzungen während des Rendering‑Vorgangs finden Sie unter [Abrufen von Warn‑Callbacks für Schriftart‑Ersetzungen](/slides/de/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Weitere Informationen zur Schriftart‑Ersetzung finden Sie im Artikel [Font Substitution](/slides/de/cpp/font-substitution/).

{{% /alert %}} 

## **Ausgewählte Folien einer PowerPoint‑Präsentation in PDF konvertieren**

Dieser C++‑Code demonstriert, wie nur bestimmte Folien einer PowerPoint‑Präsentation in PDF konvertiert werden:

```C++
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Array von Foliennummern festlegen.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Präsentation als PDF speichern.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **PowerPoint in PDF mit benutzerdefinierter Foliengröße konvertieren**

Dieser C++‑Code demonstriert, wie eine PowerPoint‑Präsentation mit einer angegebenen Foliengröße in PDF konvertiert wird:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei darstellt.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Erstellen Sie eine neue Präsentation mit angepasster Foliengröße.
auto resizedPresentation = MakeObject<Presentation>();

// Legen Sie die benutzerdefinierte Foliengröße fest.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Klonen Sie die erste Folie der Originalpräsentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Speichern Sie die skalierte Präsentation als PDF mit Notizen.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **PowerPoint in PDF im Notizfolien‑Ansicht konvertieren**

Dieser C++‑Code demonstriert, wie eine PowerPoint‑Präsentation in ein PDF konvertiert wird, das Notizen enthält:

```C++
// Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei darstellt.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Konfigurieren Sie die PDF‑Optionen mit Notizenlayout.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Speichern Sie die Präsentation als PDF mit Notizen.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Barrierefreiheit und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht Ihnen ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument mit jedem der folgenden Compliance‑Standards in PDF exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

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

{{% alert title="Hinweis" color="warning" %}} 

Aspose.Slides unterstützt PDF‑Konvertierungs‑Operationen, mit denen Sie PDF‑Dateien in gängige Formate konvertieren können. Sie können [PDF zu HTML](https://products.aspose.com/slides/de/cpp/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/de/cpp/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/de/cpp/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/de/cpp/conversion/pdf-to-png/) Konvertierungen durchführen. Weitere PDF‑Konvertierungs‑Operationen zu speziellen Formaten – [PDF zu SVG](https://products.aspose.com/slides/de/cpp/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/de/cpp/conversion/pdf-to-tiff/) und [PDF zu XML](https://products.aspose.com/slides/de/cpp/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.

{{% /alert %}}

> **Hinweis:** Beim Export nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; alternativer Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Batch‑Konvertierung mehrerer PPT‑ oder PPTX‑Dateien in PDF. Sie können Ihre Dateien iterativ verarbeiten und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**

Absolut. Verwenden Sie die [PdfOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pdfoptions/)-Klasse, um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie kann ich versteckte Folien in das PDF einbinden?**

Verwenden Sie die Methode `set_ShowHiddenSlides` in der [PdfOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pdfoptions/)-Klasse, um versteckte Folien im resultierenden PDF einzuschließen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie `set_JpegQuality` und `set_SufficientResolution` in der [PdfOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pdfoptions/)-Klasse verwenden, um qualitativ hochwertige Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die verschiedenen Standards entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente die Anforderungen an Barrierefreiheit und Archivierung erfüllen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für C++ Dokumentation](/slides/de/cpp/)
- [Aspose.Slides für C++ API‑Referenz](https://reference.aspose.com/slides/de/cpp/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/de/conversion)