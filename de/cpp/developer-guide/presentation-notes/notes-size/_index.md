---
title: Notizseitengröße und -orientierung in C++ ändern
linktitle: Notizseitengröße
type: docs
weight: 10
url: /de/cpp/notes-size/
keywords:
- Notizseitengröße
- Notizorientierung
- Notizen im Querformat
- Notizen im Hochformat
- Handout-Größe
- PowerPoint
- Präsentation
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Lesen und Ändern der Notizseitendimensionen in Aspose.Slides für C++, Ausrichtung wechseln, gespeicherte Größen überprüfen und Notizen oder Handouts in PDF und Bilder exportieren."
---
## **Übersicht**

Verwenden Sie [Presentation::get_NotesSize](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_notessize/), um auf die Notizseiteneinstellungen der Präsentation zuzugreifen. Sie gibt ein [INotesSize](https://reference.aspose.com/slides/de/cpp/aspose.slides/inotessize/)-Objekt zurück, dessen [set_Size](https://reference.aspose.com/slides/de/cpp/aspose.slides/inotessize/set_size/)-Methode die Abmessungen festlegt. Obwohl das Notiz‑Einstellungsobjekt nicht ersetzt werden kann, können Sie seine Größe ändern.

Breite und Höhe werden in **Punkten** angegeben, wobei 72 Punkte einem Zoll entsprechen. Zum Beispiel entsprechen 900 × 600 Punkte 12,5 × 8 ⅓ Zoll. Diese Einstellungen gelten für die gesamte Präsentation und nicht für die Notizen einer einzelnen Folie.

| Einstellung | Zweck |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_notessize/) | Steuert die Abmessungen der Notizseite und die für den Handout‑Export verwendeten Seitengrößen. |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_slidesize/) | Steuert die regulären Folienabmessungen der Präsentation über [ISlideSize](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidesize/). |

Das Ändern einer der Einstellungen ändert die andere nicht automatisch. Das Ändern der Ausrichtung der Notizseite dreht die regulären Folien ebenfalls nicht. Siehe [Foliengröße](/slides/de/cpp/slide-size/), um reguläre Folien zu skalieren.

Die nachstehenden Beispiele verwenden ein vorhandenes `sample.pptx`. Für die Exportbeispiele verwenden Sie eine Präsentation mit mindestens einer Folie, die Sprecher‑Notizen enthält. Jedes Beispiel kann unabhängig ausgeführt werden.

## **Lesen der Notizseitengröße und -ausrichtung**

Lese die Breite und Höhe und vergleiche sie, um die Ausrichtung zu bestimmen: Eine breitere Seite ist im Querformat, eine höhere Seite im Hochformat, und gleiche Abmessungen beschreiben eine quadratische Seite. Dieses Beispiel gibt die tatsächlichen Abmessungen in Punkten aus, ohne eine Standardpapiergröße anzunehmen.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **Wechsel zu Querformat ohne Änderung der Papiergröße**

Um nur die Ausrichtung zu ändern, vertauschen Sie die vorhandene Breite und Höhe. Dadurch bleiben die Längen beider Seiten erhalten, einschließlich einer benutzerdefinierten Papiergröße. Die nachstehende Bedingung verhindert, dass eine bereits im Querformat befindliche Seite zurück ins Hochformat wechselt, und lässt eine quadratische Seite unverändert.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

Für das Hochformat verwenden Sie die gleiche Zuweisung, wenn `size.get_Width() > size.get_Height()`. Ersetzen Sie nicht die A4‑ oder Letter‑Abmessungen, sofern Sie nicht ebenfalls die Papiergröße ändern möchten.

## **Festlegen und Überprüfen einer benutzerdefinierten Notizseitengröße**

Weisen Sie beide Abmessungen gemeinsam zu und verwenden Sie dann [Presentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/), um die Präsentation zu speichern. Dieses Beispiel legt eine 900 × 600‑Punkt‑Querformatseite fest, speichert sie als PPTX und öffnet die gespeicherte Datei erneut, um die persistierten Werte zu prüfen. Der Vergleich erlaubt eine Toleranz von 0,01 Punkt für Gleitkommawerte; er ist keine Garantie für Präzision in jedem Dateiformat.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

Das erwartete Ergebnis ist `900 x 600 points` und `Size preserved: True`. Das Überprüfen einer neu geöffneten Präsentation verifiziert die gespeicherte Datei und nicht nur die im Speicher gehaltenen Einstellungen.

## **Exportieren von Notizen und Handouts**

Die Seitenabmessungen definieren den verfügbaren Bereich für Notizen‑ oder Handout‑Layouts. Sie aktivieren diese Layouts nicht von selbst: Konfigurieren Sie auch die Exportoptionen. Der reguläre Folienexport verwendet weiterhin die Folienabmessungen.

### **Notizen nach PDF und PNG exportieren**

Weisen Sie [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/notescommentslayoutingoptions/) [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) zu, um Notizen in das PDF einzuschließen. Dieses Beispiel rendert außerdem die erste Folie mit Notizen nach PNG unter Verwendung von [Slide::GetImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/slide/getimage/) und [RenderingOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/renderingoptions/).

Der Modus [BottomTruncated](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/notespositions/) hält die Notizen auf einer Seite; nicht passende Notizen können abgeschnitten werden. Das PDF verwendet 900 × 600‑Punkt‑Seiten. Bei dem unten verwendeten Bildmaßstab von 1 × 1 ist das PNG 900 × 600 Pixel. Punkte beschreiben die Seitengeometrie; Pixel beschreiben die Rasterausgabe, deren Abmessungen ebenfalls vom Rendermaßstab abhängen.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

Für den PDF‑Export mit langen Notizen erlaubt [BottomFull](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/notespositions/) bei Bedarf zusätzliche Seiten. Verwenden Sie diesen Modus nicht mit dem oben genannten Einzel‑Folien‑Bildaufruf, da dieser ihn nicht unterstützt. Nach dem Ändern der Größe prüfen Sie die Ausgabe auf abgeschnittene Notizen und die Platzierung vorhandener notes‑master‑Objekte; das alleinige Ändern der Seitenabmessungen sollte nicht als Garantie dafür angesehen werden, dass sämtlicher Inhalt passt. Siehe [PowerPoint mit Notizen nach PDF konvertieren](/slides/de/cpp/convert-powerpoint-to-pdf-with-notes/) für weitere Informationen zum Notizen‑Export.

### **Handouts nach PDF exportieren**

Verwenden Sie [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/handoutlayoutingoptions/) für mehrere Folienminiaturansichten auf einer Seite. Das folgende Beispiel legt eine 900 × 600‑Punkt‑Seite fest und nutzt [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/handouttype/), um bis zu vier Folien pro Seite anzuordnen. Die horizontale Vorgabe steuert die Folienreihenfolge; die Seitenorientierung ergibt sich aus ihrer Breite und Höhe.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

Das Ändern der Seitengröße ändert den für das Handout‑Raster verfügbaren Bereich, ohne die Abmessungen der Quellfolien zu verändern. Für Handout‑Bilder verwenden Sie [Presentation::GetImages](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/getimages/) mit dem Handout‑Layout, anstatt die Bild‑Methode einer einzelnen Folie zu nutzen. In Aspose.Slides verwendet das handout‑Rendering auf Präsentationsebene die Notizseitengrößen, während der einzelne Folien‑Bildaufruf keine Handout‑Seite erzeugt. Siehe [Handout‑Modus](/slides/de/cpp/convert-powerpoint-in-handout-mode/) für Layout‑Optionen.

## **Seitengröße in Viewern, Export und Druck**

- **Präsentations‑Viewer:** Ein Viewer kann Notizen mit seinen eigenen Layout‑Regeln anzeigen oder drucken. Wenn eine andere Anwendung die Datei speichert, öffnen Sie sie erneut und prüfen Sie die Abmessungen; die Formatkonvertierung dieser Anwendung kann sie normalisieren.
- **Exportformate:** Die obigen PDF‑Beispiele für Notizen und Handouts verwenden die konfigurierten Seitenabmessungen. Rasterbilder verwenden ganzzahlige Pixelabmessungen und einen Render‑Maßstab, sodass dezimale Punktwerte im Bildeoutput gerundet werden können. Der Export regulärer Folien berücksichtigt die Notizseitengröße nicht.
- **Druckertreiber:** Die Papierauswahl, automatische Drehung und Fit‑to‑Page‑Einstellungen können die physische Ausgabe ändern, ohne die in der Präsentation oder im PDF gespeicherten Abmessungen zu verändern. Für eine bestimmte Papiergröße passen Sie die Druckereinstellungen an und prüfen Sie die Druckvorschau.

## **FAQ**

**Kann ich die Notizseitengröße nur für eine Folie festlegen?**

Die Notizseitengröße ist eine Einstellung auf Präsentationsebene. Einzelne Folien können unterschiedliche Notizinhalte haben, aber diese Eigenschaft bietet keine separate Seitengröße für jede Folie.

**Warum hat das Ändern der Notizseiten‑Ausrichtung meine Folien nicht verändert?**

Notizseiten und reguläre Folien haben unabhängige Abmessungen. Verwenden Sie die regulären Foliengrößeneinstellungen, wenn Sie die Folien selbst skalieren möchten.

**Warum hat mein gespeichertes oder gedrucktes Ergebnis eine andere Größe?**

Öffnen Sie zunächst die gespeicherte Präsentation erneut und vergleichen Sie deren Notizabmessungen. Wenn sich diese geändert haben, prüfen Sie, ob das Speichern oder Konvertieren der Datei in einer anderen Anwendung die Seiteneinstellungen geändert hat. Wenn nicht, überprüfen Sie das Export‑Layout, den Bild‑Maßstab, die Viewer‑Einstellungen und die Drucker‑Papierauswahl.