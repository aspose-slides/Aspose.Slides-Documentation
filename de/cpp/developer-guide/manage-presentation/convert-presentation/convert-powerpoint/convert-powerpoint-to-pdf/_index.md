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
- PPT exportieren nach PDF
- PPTX exportieren nach PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Konvertieren Sie PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in C++ mit Aspose.Slides, inklusive schneller Codebeispiele und erweiterter Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format in C++ bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und das Bewahren des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF‑Dokumente umgewandelt werden, wie verschiedene Optionen zur Steuerung der Bildqualität verwendet werden, wie versteckte Folien einbezogen, PDF‑Dateien passwortgeschützt, Schriftartsubstitutionen erkannt, bestimmte Folien zur Konvertierung ausgewählt und Compliance‑Standards auf Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse und speichern Sie die Präsentation anschließend mit der `Save`‑Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse stellt die `Save`‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides für C++ fügt API‑Informationen und Versionsnummer in Ausgabedokumente ein. Beispielsweise füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld „Application“ mit "*Aspose.Slides*" und das Feld „PDF Producer“ mit einem Wert im Format "*Aspose.Slides v XX.XX*" aus. **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren von:

* gesamten Präsentationen in PDF
* einzelnen Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und sorgt dafür, dass die resultierenden PDFs dem Original sehr nahe kommen. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der Standard‑PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet die Standardeinstellungen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen auf höchstem Qualitätsniveau in PDF zu konvertieren.

Der folgende C++‑Code zeigt, wie eine Präsentation (PPT, PPTX, ODP usw.) in PDF umgewandelt wird:

```c++
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Speichern Sie die Präsentation als PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 
Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/de/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Testlauf für eine Live‑Implementierung des hier beschriebenen Verfahrens durchführen.
{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der [PdfOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pdfoptions/)‑Klasse – bereit, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Passwort schützen oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint in PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Rasterbilder festlegen, definieren, wie Metadateien behandelt werden, einen Komprimierungsgrad für Text setzen, DPI für Bilder konfigurieren usw.

Das nachstehende Codebeispiel demonstriert, wie eine PowerPoint‑Präsentation mit mehreren benutzerdefinierten Optionen in PDF konvertiert wird:

```c++
// Instanziieren Sie die PdfOptions-Klasse.
auto pdfOptions = MakeObject<PdfOptions>();

// Legen Sie die Qualität für JPG-Bilder fest.
pdfOptions->set_JpegQuality(90);

// DPI für Bilder festlegen.
pdfOptions->set_SufficientResolution(300);

// Verhalten für Metadateien festlegen.
pdfOptions->set_SaveMetafilesAsPng(true);

// Textkomprimierungsgrad für Textinhalt festlegen.
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

Enthält eine Präsentation versteckte Folien, können Sie die Methode [set_ShowHiddenSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) der [PdfOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pdfoptions/)‑Klasse verwenden, um die versteckten Folien als Seiten in das resultierende PDF aufzunehmen.

Der folgende C++‑Code zeigt, wie eine PowerPoint‑Präsentation unter Einbeziehung versteckter Folien in PDF konvertiert wird:

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

Der folgende C++‑Code demonstriert, wie eine PowerPoint‑Präsentation mithilfe der Schutzparameter der [PdfOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pdfoptions/)‑Klasse in ein passwortgeschütztes PDF umgewandelt wird:

```c++
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instanziieren Sie die PdfOptions-Klasse.
auto pdfOptions = MakeObject<PdfOptions>();

// Setzen Sie ein PDF-Passwort und Zugriffsrechte.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Speichern Sie die Präsentation als PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Schriftartsubstitutionen erkennen**

Aspose.Slides bietet die Methode [set_WarningCallback](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveoptions/set_warningcallback/) in der [PdfOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pdfoptions/)‑Klasse, mit der Sie Schriftartsubstitutionen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Der nachstehende C++‑Code zeigt, wie Schriftartsubstitutionen erkannt werden:

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

    // Warn-Callback in den PDF-Optionen festlegen.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Präsentation als PDF speichern.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 
Weitere Informationen zum Empfangen von Callbacks für Schriftartsubstitutionen während des Rendering‑Prozesses finden Sie unter [Getting Warning Callbacks for Fonts Substitution](/slides/de/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Weitere Details zur Schriftartsubstitution finden Sie im Artikel [Font Substitution](/slides/de/cpp/font-substitution/).
{{% /alert %}} 

## **Ausgewählte Folien aus PowerPoint in PDF konvertieren**

Der folgende C++‑Code demonstriert, wie nur bestimmte Folien einer PowerPoint‑Präsentation in PDF konvertiert werden:

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

Der folgende C++‑Code demonstriert, wie eine PowerPoint‑Präsentation mit einer festgelegten Foliengröße in PDF konvertiert wird:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Erstellen Sie eine neue Präsentation mit einer angepassten Foliengröße.
auto resizedPresentation = MakeObject<Presentation>();

// Legen Sie die benutzerdefinierte Foliengröße fest.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Klone die erste Folie der Originalpräsentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Speichern Sie die skalierte Präsentation als PDF mit Notizen.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **PowerPoint in PDF im Notizfolien‑Ansicht konvertieren**

Der folgende C++‑Code demonstriert, wie eine PowerPoint‑Präsentation in ein PDF konvertiert wird, das Notizen enthält:

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

## **Barrierefreiheit und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument mit einem der folgenden Compliance‑Standards in PDF exportieren: **PDF/A‑1a**, **PDF/A‑1b** und **PDF/UA**.

Der folgende C++‑Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs anhand verschiedener Compliance‑Standards erzeugt:

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
Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, mit denen Sie PDF‑Dateien in gängige Formate umwandeln können. Sie können [PDF zu HTML](https://products.aspose.com/slides/de/cpp/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/de/cpp/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/de/cpp/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/de/cpp/conversion/pdf-to-png/) konvertieren. Weitere PDF‑Konvertierungsoperationen zu spezialisierten Formaten – [PDF zu SVG](https://products.aspose.com/slides/de/cpp/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/de/cpp/conversion/pdf-to-tiff/) und [PDF zu XML](https://products.aspose.com/slides/de/cpp/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Export nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als eine einzige Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte gekennzeichnet werden; alternativer Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Batch‑Konvertierung mehrerer PPT‑ oder PPTX‑Dateien in PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF zu schützen?**

Absolut. Verwenden Sie die [PdfOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pdfoptions/)‑Klasse, um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie nehme ich versteckte Folien in das PDF auf?**

Verwenden Sie die Methode `set_ShowHiddenSlides` in der [PdfOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pdfoptions/)‑Klasse, um versteckte Folien im resultierenden PDF zu integrieren.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie `set_JpegQuality` und `set_SufficientResolution` in der [PdfOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pdfoptions/)‑Klasse verwenden, um hochwertige Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die verschiedenen Standards entsprechen, darunter PDF/A‑1a, PDF/A‑1b und PDF/UA, sodass Ihre Dokumente Barrierefreiheit und Archivierungsanforderungen erfüllen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für C++‑Dokumentation](/slides/de/cpp/)
- [Aspose.Slides für C++ API‑Referenz](https://reference.aspose.com/slides/de/cpp/)
- [Aspose kostenlose Online‑Konverter](https://products.aspose.app/slides/de/conversion)