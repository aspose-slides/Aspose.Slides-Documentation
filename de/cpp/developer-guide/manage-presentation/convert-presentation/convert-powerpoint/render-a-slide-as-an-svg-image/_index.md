---
title: Rendern von Präsentationsfolien als SVG-Bilder in C++
linktitle: Folie zu SVG
type: docs
weight: 50
url: /de/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint zu SVG
- Präsentation zu SVG
- Folie zu SVG
- PPT zu SVG
- PPTX zu SVG
- SVG-Exportoptionen
- interaktives SVG
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Exportieren Sie PowerPoint-Folien als SVG-Bilder in C++ und steuern Sie Schriftarten, Text, Bilder, IDs und Ereignisse mit Aspose.Slides."
---
## **Übersicht**

SVG ist ein skalierbares, XML-basiertes Bildformat, das sich gut für Webveröffentlichungen, Folienbetrachter, Barrierefreiheits‑Workflows und automatisierte Nachbearbeitung eignet. Aspose.Slides für C++ exportiert jede Folie in eine separate SVG‑Datei und ermöglicht die Kontrolle darüber, wie Text, Schriftarten, Bilder und SVG‑Elemente geschrieben werden.

Verwenden Sie [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) wenn das exportierte SVG kompakt, über Browser hinweg vorhersehbar oder für interaktive Nutzung bereit sein muss.

## **Eine Folie als SVG exportieren**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), wählen Sie eine Folie aus und schreiben Sie sie in einen Stream. Das folgende Beispiel exportiert jede Folie einer Präsentation als separate SVG‑Datei.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    auto svgFileName = String::Format(u"slide-{0}.svg", slide->get_SlideNumber());
    auto svgStream = File::Create(svgFileName);

    slide->WriteAsSvg(svgStream);
    svgStream->Dispose();
}

presentation->Dispose();
```

Der Dateiname verwendet [ISlide::get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_slidenumber/) anstatt des Schleifenindexes. Sie können außerdem ein einzelnes Shape mit [IShape::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/) exportieren, wenn ein Folienbetrachter oder eine Webseite nur dieses Shape benötigt.

## **SVG‑Ausgabe konfigurieren**

[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) steuert das SVG‑Rendering. Für Textframe‑Objekte fügt [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframesize/) den Textframe in den Renderbereich ein, und [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframerotation/) bestimmt, ob die Frame‑Rotation angewendet wird. Setzen Sie [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) auf `true`, wenn Text ohne Ligaturen gerendert werden muss.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_DisableFontLigatures(true);
svgOptions->set_UseFrameSize(true);
svgOptions->set_UseFrameRotation(false);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-custom-options.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Text und Schriftarten steuern**

Beim Export von Folien nach SVG können Sie steuern, ob Text als Text erhalten bleibt oder in Vektorgrafiken umgewandelt wird, und wie externe Schriftarten eingebunden oder referenziert werden. Die folgenden Optionen helfen Ihnen, visuelle Konsistenz, Textauswahl und Schriftart‑Abhängigkeiten im exportierten SVG auszubalancieren.

### **Gesamten Text vektorisieren**

Setzen Sie [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) auf `true`, um den gesamten Folientext als Vektorgrafiken zu schreiben. Dadurch entfallen Schriftarten‑Abhängigkeiten und das visuelle Ergebnis wird über Browser hinweg konsistenter, jedoch ist der Text nicht mehr auswähl- oder durchsuchbar als SVG‑Text.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_VectorizeText(true);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-vectorized-text.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

### **Auswahl der Behandlung externer Schriftarten**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) verwendet einen [SvgExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/)‑Wert für extern geladene Schriftarten. Wählen Sie `AddLinksToFontFiles`, um separate Schriftdateien zu referenzieren, `Embed`, um Schriftartdaten in das SVG einzubetten, oder `Vectorize`, um nur Text, der externe Schriftarten verwendet, als Grafiken zu rendern. Prüfen Sie die Lizenzierung der Schriftarten, bevor Sie sie einbetten.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <Export/SvgExternalFontsHandling.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto linkedFontsOptions = MakeObject<SVGOptions>();
linkedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
auto linkedFontsStream = File::Create(u"slide-with-font-links.svg");
slide->WriteAsSvg(linkedFontsStream, linkedFontsOptions);
linkedFontsStream->Dispose();

auto embeddedFontsOptions = MakeObject<SVGOptions>();
embeddedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Embed);
auto embeddedFontsStream = File::Create(u"slide-with-embedded-fonts.svg");
slide->WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);
embeddedFontsStream->Dispose();

auto vectorizedExternalFontsOptions = MakeObject<SVGOptions>();
vectorizedExternalFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
auto vectorizedExternalFontsStream = File::Create(u"slide-with-vectorized-external-fonts.svg");
slide->WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
vectorizedExternalFontsStream->Dispose();

presentation->Dispose();
```

## **Größe eingebetteter Bilder reduzieren**

Verwenden Sie [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/), um die Auflösung eingebetteter Bilder zu reduzieren, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/), um beschnittene Quellbereiche wegzulassen, und [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/), um die JPEG‑Kodierungsqualität zu steuern. Diese Einstellungen verringern die Dateigröße auf Kosten der Bildtreue oder gespeicherten Bilddaten.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_PicturesCompression(PicturesCompression::Dpi150);
svgOptions->set_DeletePicturesCroppedAreas(true);
svgOptions->set_JpegQuality(80);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"compressed-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Auflösung der Metadatei‑Rasterisierung steuern**

[SVGOptions::set_MetafileRasterizationDpi](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_metafilerasterizationdpi/) legt die untere Auflösungsgrenze für die Rasterisierung von Metadateien beim SVG‑Export fest. Verwenden Sie sie, um Detailgrad und Dateigröße auszubalancieren, wenn ein EMF‑ oder WMF‑Bild rasterisiert wird. Sie definiert kein globales DPI für das SVG und zwingt nicht jedes Objekt auf der Folie, ein Rasterbild zu werden.

Laden Sie [metafile-rasterization.pptx](metafile-rasterization.pptx) herunter, das ein EMF‑Bild mit eng beabstandeten Diagonal­linien enthält. Das folgende Beispiel exportiert dessen erste Folie mit drei Rasterisierungsauflösungen über [ISlide::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeassvg/). Alle anderen Exporteinstellungen bleiben identisch, damit die Ergebnisse verglichen werden können.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"metafile-rasterization.pptx");
auto slide = presentation->get_Slide(0);
const int resolutions[] = { 72, 150, 300 };

for (auto dpi : resolutions)
{
    auto svgOptions = MakeObject<SVGOptions>();
    svgOptions->set_MetafileRasterizationDpi(dpi);
    svgOptions->set_PicturesCompression(PicturesCompression::Dpi330);
    svgOptions->set_JpegQuality(90);

    auto svgFileName = String::Format(u"slide-{0}.svg", dpi);
    auto svgStream = File::Create(svgFileName);
    slide->WriteAsSvg(svgStream, svgOptions);
    svgStream->Dispose();
}

presentation->Dispose();
```

Im Ergebnis wurde das EMF zu einem eingebetteten PNG in jedem SVG. Die folgenden Messwerte beziehen sich auf die bereitgestellte Präsentation; sie stellen keine allgemeine Formel zur Umrechnung von DPI in Pixelmaße dar.

| Metadatei‑Rasterisierungs‑DPI | Eingebettete PNG‑Abmessungen | SVG‑Dateigröße (Bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Der Vergleich unten zeigt denselben Bereich des eingebetteten Rasters bei gleicher vergrößerter Anzeigegröße. Die Diagonal‑linien zeigen bei 72 DPI sichtbare Pixelbildung und bei höheren Auflösungen glattere Kanten, während die SVG‑Datei wächst. Eine Erhöhung des Wertes verbessert nicht zwingend jedes Detail oder ändert jedes exportierte Bild.

![Vergrößerte Diagonal‑Linien‑Detail bei 72, 150 und 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) steuert die Reduzierung der Bildauflösung und kann den Effekt einer Änderung der Metadatei‑Rasterisierungs‑Auflösung verdecken. [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) steuert die JPEG‑Kodierungsqualität, nicht die Metadatei‑Rasterisierungs‑Auflösung.

## **Stabile IDs für Shapes und Text zuweisen**

Verwenden Sie [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/), um [ISvgShape::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/set_id/) für jedes SVG‑Shape festzulegen. Um ebenfalls [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgtspan/set_id/)‑Werte für Text‑`tspan`‑Elemente zu setzen, implementieren Sie [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Weisen Sie einen der Controller mit [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) zu.

Der folgende Controller verwendet [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/), das für die Lebensdauer des Shapes stabil ist, sowie einen wiederholbaren Zähler für seine Text‑Spans. Dadurch eignen sich die erzeugten IDs für die Nachbearbeitung einer unveränderten Präsentation.

```cpp
#include <DOM/IPortion.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeAndTextFormattingController.h>
#include <Export/ISvgTSpan.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class StableSvgIdController : public ISvgShapeAndTextFormattingController
{
private:
    String m_currentShapeId;
    int m_textSpanIndex = 0;

public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        m_currentShapeId = String::Format(u"shape-{0}", shape->get_OfficeInteropShapeId());
        m_textSpanIndex = 0;
        svgShape->set_Id(m_currentShapeId);
    }

    void FormatText(SharedPtr<ISvgTSpan> svgTSpan, SharedPtr<IPortion> portion,
                    SharedPtr<ITextFrame> textFrame) override
    {
        auto currentTextSpanIndex = m_textSpanIndex;
        m_textSpanIndex++;
        svgTSpan->set_Id(String::Format(u"{0}-text-{1}", m_currentShapeId, currentTextSpanIndex));
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<StableSvgIdController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-stable-ids.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **SVG‑Ereignis‑Handler hinzufügen**

In einem [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) rufen Sie [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/seteventhandler/) mit einem [SvgEvent](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgevent/)‑Wert auf, um einem exportierten Shape einen JavaScript‑Ereignis‑Handler hinzuzufügen. Weisen Sie den Controller mit [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) zu und definieren Sie die JavaScript‑Funktion in der Seite oder im SVG‑Dokument, das das Ergebnis hostet.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeFormattingController.h>
#include <Export/SVGOptions.h>
#include <Export/SvgEvent.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class SvgEventController : public ISvgShapeFormattingController
{
public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        if (shape->get_Name() == u"ActionButton")
        {
            svgShape->set_Id(u"action-button");
            svgShape->SetEventHandler(SvgEvent::OnClick, u"handleShapeClick(event)");
        }
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<SvgEventController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"interactive-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

Die Host‑Seite kann die vom Handler referenzierte JavaScript‑Funktion definieren. Das Zuweisen von IDs und Ereignis‑Handlern ermöglicht Folienbetrachter, Barrierefreiheits‑Verbesserungen und andere interaktive SVG‑Workflows.

## **FAQ**

**Wann sollte ich [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) anstelle von [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) verwenden?**

Verwenden Sie [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/), wenn sämtlicher Text unabhängig von Schriftarten sein muss. Verwenden Sie [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/), wenn nur Text, der externe Schriftarten verwendet, in Grafiken umgewandelt werden soll.

**Was ist der beste Weg, ein SVG zu verkleinern?**

Beginnen Sie mit der Komprimierung eingebetteter Bilder, dem Löschen beschnittener Bildbereiche und der Wahl verlinkter Schriftdateien, wenn die Zielumgebung diese bereitstellen kann. Testen Sie das Ergebnis, da niedrigere Bildauflösung, geringere JPEG‑Qualität und vektorisierter Text jeweils unterschiedliche Qualitäts‑ und Größenkompromisse darstellen.

**Kann ich exportierte SVG‑Elemente nach dem Export ändern?**

Ja. Weisen Sie IDs über einen Formatierungs‑Controller zu und wählen Sie dann die passenden SVG‑Elemente in Ihrem Nachbearbeitungs‑Werkzeug oder Browserskript aus.