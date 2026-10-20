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
- Anhang
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in C++ mit Aspose.Slides konvertieren, mit schnellen Codebeispielen und erweiterten Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format in C++ bietet mehrere Vorteile, darunter die Kompatibilität über verschiedene Geräte hinweg und das Beibehalten von Layout und Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF‑Dokumente konvertiert werden, verschiedene Optionen zur Steuerung der Bildqualität verwendet, versteckte Folien einbezogen, PDF‑Dateien mit Passwort geschützt, Schriftartersetzungen erkannt, bestimmte Folien für die Konvertierung ausgewählt und Compliance‑Standards auf Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse und speichern die Präsentation anschließend als PDF mithilfe der [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) Methode. Die [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse stellt die [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Hinweis" %}}
Aspose.Slides für C++ fügt API‑Informationen und Versionsnummer in Ausgabedokumente ein. Zum Beispiel, wenn eine Präsentation in PDF konvertiert wird, füllt Aspose.Slides das Feld Application mit "*Aspose.Slides*" und das Feld PDF Producer mit einem Wert in der Form "*Aspose.Slides v XX.XX*". **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides erlaubt es Ihnen, zu konvertieren:

* gesamte Präsentationen in PDF
* bestimmte Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs der Originalpräsentation sehr nahe kommen. Elemente und Attribute werden bei der Konvertierung exakt dargestellt, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint zu PDF konvertieren**

Der standardmäßige PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualität in PDF zu konvertieren.

Das folgende Beispiel lädt eine Präsentation und speichert alle sichtbaren Folien mit den Standard‑Exporteinstellungen in PDF.

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

{{% alert color="info" title="Hinweis" %}}
Aspose bietet einen kostenlosen Online-[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test für eine Live‑Implementierung des hier beschriebenen Verfahrens durchführen.
{{% /alert %}}

## **PowerPoint zu PDF mit Optionen**

Aspose.Slides stellt benutzerdefinierte Optionen—Eigenschaften der [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) Klasse—zur Verfügung, die es ermöglichen, das resultierende PDF anzupassen, das PDF mit einem Passwort zu schützen oder festzulegen, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint zu PDF mit benutzerdefinierten Optionen**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Rasterbilder festlegen, festlegen, wie Metadateien behandelt werden sollen, ein Komprimierungsniveau für Text einstellen, DPI für Bilder konfigurieren und mehr.

Das folgende Beispiel exportiert eine Präsentation nach PDF 1.5 mit JPEG‑Qualität 90, Bildauflösung 300 DPI, Metadateien als PNG gespeichert und Flate‑Textkomprimierung.

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

### **Bildkompression automatisch auswählen**

Enthält eine Präsentation viele Fotos oder Screenshots, kann das Reduzieren der Größe des exportierten PDFs das Versenden per E‑Mail oder Herunterladen erleichtern. Rufen Sie [PdfOptions::set_BestImagesCompressionRatio](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_bestimagescompressionratio/) mit `true` auf, um während des PDF‑Exports automatisch den am besten geeigneten Kompressionsalgorithmus für jedes Bild auszuwählen.

Das folgende Beispiel lädt eine vorhandene Präsentation, aktiviert die automatische Auswahl der Bildkompression und speichert sie als PDF‑Dokument. Alle anderen PDF‑Exporteinstellungen behalten ihre Standardwerte bei.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_BestImagesCompressionRatio(true);

auto presentation = MakeObject<Presentation>(u"image-heavy.pptx");
presentation->Save(u"image-heavy.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Diese Option wählt für jedes Bild einen Kompressionsalgorithmus aus. Das Senken der JPEG‑Qualität mit [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) reduziert hingegen die JPEG‑Bildqualität, während das Verringern der Auflösung mit [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) ermöglicht, Bilder auf eine niedrigere Auflösung herunterzusampeln, was Details reduzieren kann. Das Aktivieren der automatischen Kompressionsauswahl reduziert diese Einstellungen nicht.

Die Auswahl von Bildkompressionsalgorithmen erfordert zusätzlichen Verarbeitungszeit und Speicher. Die Größenreduktion hängt von den Bildern und Exporteinstellungen der Präsentation ab; eine feste Reduktion ist für jede Präsentation nicht garantiert.

### **Eingebettete OLE‑Dateien als PDF‑Anhänge erhalten**

Enthält eine Präsentation ein eingebettetes Excel‑Arbeitsbuch, möchten Sie möglicherweise, dass PDF‑Empfänger sowohl auf die Daten des Arbeitsbuchs zugreifen als auch die Folien ansehen können. Rufen Sie [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) mit `true` auf, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF zu erhalten.

Der Standardwert ist `false`: Das Vorschaubild oder Symbol des OLE‑Objekts wird auf der PDF‑Seite dargestellt, aber die eingebettete Datei wird nicht als Anhang hinzugefügt. Das Setzen der Option auf `true` fügt zusätzlich die Dateidaten ein. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht es Empfängern, die eingebettete Datei separat zu öffnen oder zu speichern. Das OLE‑Objekt wird nicht zu einem interaktiven Excel‑Arbeitsblatt auf der PDF‑Seite.

Das folgende Beispiel lädt eine Präsentation, die bereits ein eingebettetes Excel‑Arbeitsbuch enthält, und exportiert sie nach PDF mit dem angehängten Arbeitsbuch.

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

1. Öffnen Sie das exportierte PDF in einem Viewer, der Datei‑Anhänge unterstützt, z. B. Adobe Acrobat Reader.
2. Öffnen Sie das **Attachments**‑Panel des Viewers und suchen Sie das eingebettete Arbeitsbuch.
3. Speichern Sie den Anhang und öffnen Sie ihn in Excel, um die Daten zu prüfen, oder öffnen Sie ihn direkt, falls der Viewer dies zulässt. Die Vorschau auf der PDF‑Seite ist vom Anhang getrennt.

{{% alert color="info" title="Hinweis" %}}
Die PDF/A‑Standards legen Einschränkungen für Anhänge fest: PDF/A‑1 verbietet eingebettete Dateien, PDF/A‑2 erlaubt nur PDF/A‑Anhänge, und PDF/A‑3 erlaubt andere Dateitypen, einschließlich Excel‑Arbeitsbücher. Dies sind Vorgaben der Standards, nicht spezifische Beschränkungen von Aspose.Slides. Dieses Beispiel verwendet die Standard‑PDF‑Compliance‑Einstellung und demonstriert keinen PDF/A‑Export.
{{% /alert %}}

### **PowerPoint zu PDF mit versteckten Folien**

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

### **PowerPoint zu einem passwortgeschützten PDF**

Das folgende Beispiel exportiert eine Präsentation in ein PDF, das das Passwort `password` zum Öffnen erfordert. Die Zugriffsberechtigungen erlauben das Drucken, einschließlich hochwertigem Druck.

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

### **Schriftartersetzungen erkennen**

Aspose.Slides stellt die Methode [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) unter der Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) bereit, die es ermöglicht, Schriftartersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses zu erkennen.

Das folgende Beispiel exportiert eine Präsentation nach PDF und gibt Schriftartersetzungswarnungen in der Konsole aus. Eine Warnung wird nur ausgegeben, wenn während des Exports eine nicht verfügbare Schriftart ersetzt wird.

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

{{% alert color="info" title="Hinweis" %}}
Weitere Informationen zur Schriftartersetzung finden Sie im Artikel [Schriftartersetzung](/slides/de/cpp/font-substitution/).
{{% /alert %}}

### **Umgang mit Schriftarten ohne eigene fette Schriftart**

Eine Präsentation kann Text fett formatieren, selbst wenn die Schriftart keinen dedizierten Fettschriftstil besitzt. Der Text kann dennoch durch synthetisches Fettdrucken fett erscheinen, wobei die regulären Glyphen künstlich verdickt werden. Wenn dieser Text in PDF zu schwer oder anders erscheint als beabsichtigt, versuchen Sie, die Methode [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) mit `true` aufzurufen. Diese Option rendert den betroffenen Text während des PDF‑Exports als Bitmap und kann das Aussehen für bestimmte Schriftarten verbessern. Der Standardwert ist `false`.

Die Beispielpräsentation enthält zwei Textfelder: eines mit normalem Text und eines mit Fettdarstellung derselben Schriftart, die keinen dedizierten Fettschriftstil hat. Das folgende Beispiel lädt die Präsentation, aktiviert die Rasterisierung nicht unterstützter Schriftstil‑Varianten und exportiert sie nach PDF:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_RasterizeUnsupportedFontStyles(true);

auto presentation = MakeObject<Presentation>(u"unsupported-bold.pptx");
presentation->Save(u"rasterized.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Die folgenden Vorschaubilder zeigen die Ausgabe mit deaktivierter und aktivierter Option. In diesem Beispiel hat der fette Text bei deaktivierter Option stärkere Striche. Bei aktivierter Option sind die Striche leichter; der normale Text bleibt unverändert. Vergleichen Sie die Ergebnisse, bevor Sie die Einstellung für Ihre Präsentation wählen.

| Option deaktiviert (`false`, standard) | Option aktiviert (`true`) |
|---|---|
| ![PDF mit deaktivierter Rasterisierung des nicht unterstützten Schriftstils](unsupported-bold-disabled.png) | ![PDF mit aktivierter Rasterisierung des nicht unterstützten Schriftstils](unsupported-bold-enabled.png) |

In diesem Beispiel wandelt das Aktivieren der Option nur den fetten Text in eine Bitmap um: Er kann nicht ausgewählt, kopiert oder als Text ohne OCR durchsucht werden und seine Kanten erscheinen bei 800 % Zoom weicher. Der normale Text bleibt durchsuchbar. Bei deaktivierter Option bleiben beide Zeichenketten als Text.

Diese Option rasterisiert als fett formatierte Texte, wenn die Schriftart keinen dedizierten Fettschriftstil hat. [Schriftartersetzung](/slides/de/cpp/font-substitution/) wählt stattdessen eine andere Schriftart, wenn die Originalschriftart nicht verfügbar ist.

## **Ausgewählte Folien von PowerPoint zu PDF konvertieren**

Das folgende Beispiel exportiert die Folien 1 und 3 einer Präsentation nach PDF. Die Foliennummern in diesem Array sind 1‑basiert, und die Eingabepäsentation muss mindestens drei Folien enthalten.

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

Das folgende Beispiel kopiert die erste Folie einer Präsentation in eine neue Präsentation mit einer Foliengröße von 612 × 792 Punkten (8,5 × 11 Zoll). Es skaliert den Folieninhalt, damit er passt, und exportiert die einzelne Folie nach PDF.

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

## **PowerPoint zu PDF im Notizfolien‑Modus konvertieren**

Das folgende Beispiel exportiert eine Präsentation nach PDF und platziert die Redner‑Notizen jeder Folie unterhalb der Folie. Verwenden Sie eine Präsentation mit Redner‑Notizen, um das Ergebnis zu sehen.

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

## **Barrierefreiheit und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument nach PDF exportieren und dabei einen dieser Compliance‑Standards verwenden: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser C++‑Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Compliance‑Standards erzeugt:

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

{{% alert color="info" title="Hinweis" %}}
Aspose.Slides unterstützt PDF‑Konvertierungsoperationen und ermöglicht das Konvertieren von PDF‑Dateien in gängige Formate. Sie können [PDF zu HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) Konvertierungen durchführen. Weitere PDF‑Konvertierungsoperationen zu Spezialformaten—[PDF zu SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), und [PDF zu XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Export nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; Alternativtext wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?**  
Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien nach PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**  
Ja. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) um ein Passwort festzulegen und Zugriffsberechtigungen während des Konvertierungsprozesses zu definieren.

**Wie füge ich versteckte Folien in das PDF ein?**  
Verwenden Sie die Methode [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) in der Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) um versteckte Folien in das resultierende PDF einzuschließen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**  
Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) und [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) in der Klasse [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) verwenden, um hochwertige Bilder in Ihrem PDF zu gewährleisten.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**  
Ja, Aspose.Slides ermöglicht den Export von PDFs, die verschiedenen Standards entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, wodurch Ihre Dokumente die Anforderungen an Barrierefreiheit und Archivierung erfüllen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für C++ Dokumentation](/slides/de/cpp/)
- [Aspose.Slides für C++ API‑Referenz](https://reference.aspose.com/slides/cpp/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)