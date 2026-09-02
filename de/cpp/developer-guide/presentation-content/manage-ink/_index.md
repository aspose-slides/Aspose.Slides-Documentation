---
title: Ink-Objekte in PowerPoint mit C++ verwalten
linktitle: Ink verwalten
type: docs
weight: 95
url: /de/cpp/manage-ink/
keywords:
- Tinte
- Tintenobjekt
- Tintenspur
- Ink verwalten
- Ink zeichnen
- Zeichnung
- Ink-Export
- Ink-Rendering
- Ink verbergen
- IInkOptions
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Verwalten Sie PowerPoint-Ink-Objekte, bearbeiten Sie Spuren und Pinsel‑Eigenschaften und steuern Sie das Aussehen von Ink beim Export von PDF, HTML, SVG, TIFF und Bildern mit Aspose.Slides für C++."
---
## **Einleitung**

PowerPoint bietet eine Ink‑Funktion, die es Ihnen ermöglicht, Freihand‑Striche zu zeichnen. Ink kann verwendet werden, um andere Objekte hervorzuheben, Verbindungen und Prozesse anzuzeigen und die Aufmerksamkeit auf bestimmte Elemente einer Folie zu lenken.

Der [Aspose.Slides.Ink](https://reference.aspose.com/slides/de/cpp/aspose.slides.ink/) Namespace enthält die Klassen und Schnittstellen, die zum Arbeiten mit Ink‑Objekten erforderlich sind. Zum Beispiel repräsentiert die [IInk](https://reference.aspose.com/slides/de/cpp/aspose.slides.ink/iink/) Schnittstelle ein Ink‑Objekt auf einer Folie.

## **Unterschiede zwischen regulären Objekten und Ink‑Objekten**

Objekte auf einer PowerPoint‑Folien werden typischerweise durch Shape‑Objekte dargestellt. In seiner einfachsten Form ist ein Shape ein Container, der den Bereich des eigentlichen Objekts (seinen Rahmen) definiert sowie Eigenschaften wie Containergröße, Form und Hintergrund enthält. Weitere Informationen finden Sie unter [Shape Layout Format](https://docs.aspose.com/slides/de/cpp/shape-manipulations/#access-layout-formats-for-shape).

Wenn PowerPoint jedoch ein Ink‑Objekt verarbeitet, ignoriert es alle Eigenschaften des Objekt‑Rahmens (Containers) außer seiner Größe. Die Größe des Container‑Bereichs wird durch die Standardmethoden [IShape::get_Width](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_width/) und [IShape::get_Height](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_height/) bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Ink‑Spuren**

Eine Ink‑Spur ist ein Basiselement, das verwendet wird, um die Bahn eines Stifts zu erfassen, während ein Benutzer digitale Tinte schreibt. Eine Spur speichert eine Sequenz verbundener Punkte.

Die einfachste Form der Kodierung gibt die X‑ und Y‑Koordinaten jedes Abtastpunkts an. Wenn alle verbundenen Punkte gerendert werden, entsteht ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## **Pinsel‑Eigenschaften zum Zeichnen**

Ein Pinsel wird verwendet, um Linien zu zeichnen, die die Punkte einer Ink‑Spur verbinden. Der Pinsel besitzt eigene Farbe und Größe, die durch die Methoden [IInkBrush::get_Color](https://reference.aspose.com/slides/de/cpp/aspose.slides.ink/iinkbrush/get_color/) und [IInkBrush::get_Size](https://reference.aspose.com/slides/de/cpp/aspose.slides.ink/iinkbrush/get_size/) repräsentiert werden.

### **Farbe des Ink‑Pinsels festlegen**

Dieser C++‑Code zeigt, wie die Farbe eines Ink‑Pinsels festgelegt wird:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **Größe des Ink‑Pinsels festlegen**

Dieser C++‑Code zeigt, wie die Größe eines Ink‑Pinsels festgelegt wird:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

Im Allgemeinen stimmen Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinselgröße nicht anzeigt (der entsprechende Datenbereich ist ausgegraut). Wenn Breite und Höhe des Pinsels übereinstimmen, zeigt PowerPoint die Größe wie folgt an:

![ink_powerpoint3](ink_powerpoint3.png)

Zur Verdeutlichung erhöhen wir die Höhe des Ink‑Objekts und betrachten die wichtigen Abmessungen:

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Rahmen) berücksichtigt die Größe der Pinsel nicht – er geht stets davon aus, dass die Linienstärke null ist (siehe das vorherige Bild).

Daher muss zur Bestimmung des sichtbaren Bereichs des gesamten Ink‑Objekts die Pinselgröße seiner Spuren berücksichtigt werden. Hier wurde das Zielobjekt (die handschriftliche Textspur) auf die Größe des Containers (Rahmens) skaliert. Ändert sich die Größe des Containers, bleibt die Pinselgröße konstant und umgekehrt.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint verwendet ein ähnliches Verhalten für Textobjekte:

![ink_powerpoint6](ink_powerpoint6.png)

## **Steuerung des Ink‑Erscheinungsbildes während Export und Rendering**

Aspose.Slides stellt die Schnittstelle [IInkOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/iinkoptions/) bereit, um zu steuern, wie Ink‑Objekte in exportierten oder gerenderten Ausgaben erscheinen. Sie können deren Methoden verwenden, um Ink vollständig zu verbergen oder zu ändern, wie Maskenoperationen von Ink‑Pinseln interpretiert werden.

Ink‑Optionen sind über die Export‑ oder Rendering‑Optionen für mehrere Ausgabetypen verfügbar:

| Ausgabe | Ink‑Optionen‑Methode |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| Folien‑Bild | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

Über diese Methoden stehen dieselben beiden Einstellungen zur Verfügung:

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/iinkoptions/set_hideink/) bestimmt, ob Ink‑Objekte in die Ausgabe einbezogen werden. Der Standardwert ist `false`.
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) bestimmt, ob eine Maskenoperation beim Rendern eines Ink‑Pinsels als Deckkraft interpretiert wird. Der Standardwert ist `true`; setzen Sie ihn auf `false`, um stattdessen die ROP‑Operation zu verwenden.

### **Ink‑Objekte im PDF‑Output verbergen**

Standardmäßig bleiben Ink‑Objekte beim Export sichtbar. Rufen Sie [IInkOptions::set_HideInk](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/iinkoptions/set_hideink/) mit `true` auf, wenn Sie eine saubere Ausgabe ohne handschriftliche Anmerkungen oder andere Ink‑Inhalte benötigen.

Das folgende C++‑Beispiel exportiert eine Präsentation nach PDF, während alle Ink‑Objekte verborgen werden:

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Ink‑Objekte beim Rendern einer Folie als Bild verbergen**

Um Ink‑Objekte beim Rendern von Folien als Bitmap‑Bilder zu verbergen, konfigurieren Sie [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) und übergeben Sie die Rendering‑Optionen an die Methode [ISlide::GetImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/getimage/).

Das folgende C++‑Beispiel rendert die erste Folie als PNG‑Bild ohne Ink‑Objekte:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **Steuerung der Ink‑Masken‑Renderung**

Die Methode [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) kontrolliert, wie Maskenoperationen beim Rendern von Ink‑Pinseln interpretiert werden. Der Standardwert ist `true`, wodurch Deckkraft verwendet wird. Rufen Sie die Methode mit `false` auf, um stattdessen die ROP‑Operation zu nutzen.

Das folgende C++‑Beispiel exportiert eine Folie nach SVG und verwendet ROP‑basiertes Rendering für Ink‑Masken‑Operationen:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

Die gleiche Einstellung kann über [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) angewendet werden, wenn eine Präsentation nach TIFF exportiert oder eine Folie nach TIFF gerendert wird.

### **Wählen Sie, ob Ink verborgen oder erhalten bleiben soll**

Verwenden Sie [IInkOptions::set_HideInk](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/iinkoptions/set_hideink/) mit `true`, wenn die exportierte Datei eine saubere Version einer annotierten Präsentation sein soll, z. B. eine endgültige Kopie zur Verteilung ohne Prüfnachweise.

Lassen Sie Ink sichtbar (Standardwert `false`), wenn Ink‑Anmerkungen Teil des beabsichtigten Inhalts sind, etwa Prüfkomen­tar, handschriftliche Notizen, Hervorhebungen oder Zeichnungen, die im Export‑Ergebnis sichtbar bleiben sollen. So können Anwendungen getrennte Prüf‑ und Endausgaben aus derselben Präsentation erzeugen, ohne die Quell‑Ink‑Objekte zu ändern.

## **FAQ**

**Kann ich die Farbe oder Größe eines bestehenden Ink‑Strichs ändern?**

Ja. Holen Sie die Spur über [IInk::get_Traces](https://reference.aspose.com/slides/de/cpp/aspose.slides.ink/iink/get_traces/), ändern Sie dann deren [IInkTrace::get_Brush](https://reference.aspose.com/slides/de/cpp/aspose.slides.ink/iinktrace/get_brush/). Sie können [IInkBrush::set_Color](https://reference.aspose.com/slides/de/cpp/aspose.slides.ink/iinkbrush/set_color/) und [IInkBrush::set_Size](https://reference.aspose.com/slides/de/cpp/aspose.slides.ink/iinkbrush/set_size/) am Pinsel aufrufen.

**Verändert das Verbergen von Ink die Quellpräsentation?**

Nein. [IInkOptions::set_HideInk](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/iinkoptions/set_hideink/) wirkt sich nur auf das gerenderte oder exportierte Ergebnis aus; es entfernt oder ändert keine Ink‑Objekte in der Quellpräsentation.

**Welche Exportformate unterstützen Ink‑Optionen?**

Sie können Ink‑Optionen für PDF, HTML, SVG, TIFF und Bitmap‑Folienbilder über die jeweiligen Export‑ bzw. Rendering‑Optionen, die oben gezeigt werden, konfigurieren.

**Weiterführende Informationen**

* Um allgemeine Informationen zu Shapes zu erhalten, siehe den Abschnitt [PowerPoint Shapes](https://docs.aspose.com/slides/de/cpp/powerpoint-shapes/).
* Für weitere Details zu effektiven Werten siehe [Shape Effective Properties](https://docs.aspose.com/slides/de/cpp/shape-effective-properties/#get-effective-font-height-value).
* Für Details zum PDF‑Export siehe [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/de/cpp/convert-powerpoint-to-pdf/).
* Für Details zum HTML‑Export siehe [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/de/cpp/convert-powerpoint-to-html/).
* Für Details zum SVG‑Export siehe [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/de/cpp/render-a-slide-as-an-svg-image/).
* Für Details zum TIFF‑Export siehe [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/de/cpp/convert-powerpoint-to-tiff/).
* Für Details zum Rendern von Folien zu Bildern siehe [Convert Presentation Slides to Images](https://docs.aspose.com/slides/de/cpp/convert-slide/).