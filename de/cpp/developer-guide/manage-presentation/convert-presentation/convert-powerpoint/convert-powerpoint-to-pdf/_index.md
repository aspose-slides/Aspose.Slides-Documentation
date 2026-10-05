---
title: "PPT und PPTX in PDF konvertieren in C++ [Erweiterte Funktionen enthalten]"
linktitle: "PowerPoint zu PDF"
type: docs
weight: 40
url: /de/cpp/convert-powerpoint-to-pdf/
keywords:
- "PowerPoint konvertieren"
- "Präsentation konvertieren"
- "PowerPoint zu PDF"
- "Präsentation zu PDF"
- "PPT zu PDF"
- "PPT zu PDF konvertieren"
- "PPTX zu PDF"
- "PPTX zu PDF konvertieren"
- "PowerPoint als PDF speichern"
- "PPT als PDF speichern"
- "PPTX als PDF speichern"
- "PPT zu PDF exportieren"
- "PPTX zu PDF exportieren"
- "Anhang"
- "PDF/A1a"
- "PDF/A1b"
- "PDF/UA"
- "C++"
- "Aspose.Slides"
description: "Konvertieren Sie PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in C++ mit Aspose.Slides, inklusive schneller Code‑Beispiele und erweiterter Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint-Präsentationen (PPT, PPTX, ODP usw.) in das PDF-Format in C++ bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und die Erhaltung des Layouts und der Formatierung Ihrer Präsentation. Diese Anleitung zeigt, wie Präsentationen in PDF-Dokumente konvertiert werden, wie verschiedene Optionen zur Steuerung der Bildqualität verwendet werden, versteckte Folien einbezogen, PDF-Dateien passwortgeschützt werden, Font-Substitutionen erkannt, bestimmte Folien für die Konvertierung ausgewählt und Konformitätsstandards auf Ausgabedokumente angewendet werden.

## **PowerPoint zu PDF-Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse und speichern die Präsentation anschließend mit einer [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)‑Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse stellt die [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Note" %}}
Aspose.Slides für C++ fügt seinen API-Informationen und die Versionsnummer in Ausgabedokumente ein. Beispielsweise füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld Application mit „*Aspose.Slides*“ und das Feld PDF Producer mit einem Wert in der Form „*Aspose.Slides v XX.XX*“. **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen in Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht die Konvertierung:

* Gesamte Präsentationen in PDF
* Bestimmte Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs eng mit den Originalpräsentationen übereinstimmen. Elemente und Attribute werden in der Konvertierung genau wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint zu PDF konvertieren**

Der Standard‑Konvertierungsprozess von PowerPoint zu PDF verwendet die Standardeinstellungen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualität in PDF zu konvertieren.

Das folgende Beispiel lädt eine Präsentation und speichert alle sichtbaren Folien mit den Standard‑Export‑Einstellungen als PDF.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) an, der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test durchführen, um die hier beschriebene Vorgehensweise live zu sehen.
{{% /alert %}}

## **PowerPoint zu PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) – bereit, mit denen Sie das resultierende PDF anpassen, es mit einem Passwort schützen oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint zu PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugten Qualitätseinstellungen für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden sollen, ein Kompressionsniveau für Text setzen, die DPI für Bilder konfigurieren und mehr.

Das folgende Beispiel exportiert eine Präsentation nach PDF 1.5 mit einer JPEG‑Qualität von 90, einer Bildauflösung von 300 DPI, Metadateien als PNG gespeichert und Flate‑Textkompression.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Eingebettete OLE‑Dateien als PDF‑Anhänge beibehalten**

Enthält eine Präsentation eine eingebettete Excel‑Arbeitsmappe, möchten Sie möglicherweise, dass PDF‑Empfänger sowohl die Daten der Arbeitsmappe als auch die Folien einsehen können. Rufen Sie [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) mit `true` auf, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF beizubehalten.

Der Standardwert ist `false`: Das Vorschaubild oder Symbol des OLE‑Objekts wird auf der PDF‑Seite dargestellt, aber die eingebettete Datei wird nicht als Anhang eingeschlossen. Wird die Option auf `true` gesetzt, werden zusätzlich die Dateidaten eingebettet. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht es Empfängern, die eingebettete Datei separat zu öffnen oder zu speichern. Das OLE‑Objekt wird nicht zu einem interaktiven Excel‑Arbeitsblatt auf der PDF‑Seite.

Das folgende Beispiel lädt eine Präsentation, die bereits eine eingebettete Excel‑Arbeitsmappe enthält, und exportiert sie nach PDF mit angehängter Arbeitsmappe.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Um das Ergebnis zu prüfen:

1. Öffnen Sie das exportierte PDF in einem Viewer, der Dateianhänge unterstützt, wie z. B. Adobe Acrobat Reader.
2. Öffnen Sie das **Attachments**‑Panel des Viewers und suchen Sie die eingebettete Arbeitsmappe.
3. Speichern Sie den Anhang und öffnen Sie ihn in Excel, um die Daten zu prüfen, oder öffnen Sie ihn direkt, falls der Viewer dies erlaubt. Die Vorschau auf der PDF‑Seite ist vom Anhang getrennt.

{{% alert color="info" title="Note" %}}
Die PDF/A‑Standards legen Beschränkungen für Anhänge fest: PDF/A‑1 verbietet eingebettete Dateien, PDF/A‑2 erlaubt nur PDF/A‑Anhänge, und PDF/A‑3 erlaubt andere Dateitypen, einschließlich Excel‑Arbeitsmappen. Dies sind Anforderungen der Standards, nicht Einschränkungen von Aspose.Slides. Dieses Beispiel verwendet die Standard‑PDF‑Konformitätseinstellung und demonstriert keinen PDF/A‑Export.
{{% /alert %}}

### **PowerPoint zu PDF mit versteckten Folien konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie die Methode [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) der Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) verwenden, um die versteckten Folien als Seiten im resultierenden PDF einzuschließen.

Das folgende Beispiel exportiert eine Präsentation nach PDF und schließt dabei alle versteckten Folien ein.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **PowerPoint zu einem passwortgeschützten PDF konvertieren**

Das folgende Beispiel exportiert eine Präsentation in ein PDF, das das Passwort `password` zum Öffnen erfordert. Die Zugriffsberechtigungen erlauben das Drucken, einschließlich Hochqualitätsdruck.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Font‑Substitutionen erkennen**

Aspose.Slides stellt die Methode [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) in der Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) bereit, mit der Sie Font‑Substitutionen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Das folgende Beispiel exportiert eine Präsentation nach PDF und gibt Font‑Substitutions‑Warnungen in die Konsole aus. Eine Warnung wird nur ausgegeben, wenn während des Exports eine nicht verfügbare Schriftart substituiert wird.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Weitere Informationen zu Font‑Substitutionen finden Sie im Artikel [Font Substitution](/slides/de/cpp/font-substitution/).
{{% /alert %}} 

## **Ausgewählte Folien von PowerPoint zu PDF konvertieren**

Das folgende Beispiel exportiert die Folien 1 und 3 einer Präsentation nach PDF. Die Foliennummern in diesem Array beginnen bei eins, und die Eingabepräsentation muss mindestens drei Folien enthalten.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **PowerPoint zu PDF mit benutzerdefinierter Foliengröße konvertieren**

Das folgende Beispiel kopiert die erste Folie einer Präsentation in eine neue Präsentation mit einer Foliengröße von 612 × 792 Punkten (8,5 × 11 Zoll). Es skaliert den Folieninhalt, sodass er passt, und exportiert die einzelne Folie nach PDF.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **PowerPoint zu PDF im Folien‑Notizen‑Ansichtsmodus konvertieren**

Das folgende Beispiel exportiert eine Präsentation nach PDF und platziert die Sprecher‑Notizen jeder Folie unterhalb der Folie. Verwenden Sie eine Präsentation, die Sprecher‑Notizen enthält, um das Ergebnis zu sehen.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **Barrierefreiheits‑ und Konformitätsstandards für PDF**

Aspose.Slides ermöglicht die Verwendung eines Konvertierungsverfahrens, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument mit einem dieser Konformitätsstandards in PDF exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser C++‑Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf verschiedenen Konformitätsstandards erzeugt:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

{{% alert color="info" title="Note" %}}
Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, mit denen Sie PDF‑Dateien in gängige Formate konvertieren können. Sie können [PDF zu HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) konvertieren. Weitere PDF‑Konvertierungen in spezialisierte Formate – [PDF zu SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/) und [PDF zu XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Export nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; Alternativtext wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?**  
Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien in PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF passwortzuschützen?**  
Ja. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), um ein Passwort festzulegen und Zugriffsberechtigungen während des Konvertierungsprozesses zu definieren.

**Wie kann ich versteckte Folien in das PDF einbinden?**  
Verwenden Sie die Methode [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) in der Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), um versteckte Folien in das resultierende PDF aufzunehmen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**  
Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) und [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) in der Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) verwenden, um hochwertige Bilder in Ihrem PDF zu gewährleisten.

**Unterstützt Aspose.Slides die PDF/A‑Konformitätsstandards?**  
Ja, Aspose.Slides ermöglicht den Export von PDFs, die verschiedenen Standards entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente die Anforderungen an Barrierefreiheit und Archivierung erfüllen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für C++ Dokumentation](/slides/de/cpp/)
- [Aspose.Slides für C++ API-Referenz](https://reference.aspose.com/slides/cpp/)
- [Aspose kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)