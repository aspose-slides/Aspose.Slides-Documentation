---
title: Präsentationsfolien als SVG‑Bilder in C++ rendern
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
- SVG‑Exportoptionen
- interaktives SVG
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Exportieren Sie PowerPoint‑Folien als SVG‑Bilder in C++ und steuern Sie Schriftarten, Text, Bilder, IDs und Ereignisse mit Aspose.Slides."
---
## **Übersicht**

SVG ist ein skalierbares, XML-basiertes Bildformat, das sich gut für die Webveröffentlichung, Folienbetrachter, Barrierefreiheits‑Workflows und die automatisierte Nachbearbeitung eignet. Aspose.Slides für C++ exportiert jede Folie in eine separate SVG‑Datei und ermöglicht die Kontrolle darüber, wie Text, Schriftarten, Bilder und SVG‑Elemente geschrieben werden.

Verwenden Sie [SVGOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/svgoptions/) , wenn das exportierte SVG kompakt, über verschiedene Browser hinweg vorhersagbar oder für interaktive Verwendung bereit sein muss.

## **Eine Folie als SVG exportieren**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) , wählen Sie eine Folie aus und schreiben Sie sie in einen Stream. Das folgende Beispiel exportiert jede Folie einer Präsentation in eine separate SVG‑Datei.

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

Der Dateiname verwendet [ISlide::get_SlideNumber](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/get_slidenumber/) anstelle des Schleifenindex. Sie können außerdem eine einzelne Form mit [IShape::WriteAsSvg](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/writeassvg/) exportieren, wenn ein Folienbetrachter oder eine Webseite nur diese Form benötigt.

## **SVG-Ausgabe konfigurieren**

[SVGOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/svgoptions/) steuert das Rendern von SVG. Für Textrahmen sorgt [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/svgoptions/set_useframesize/) dafür, dass der Textrahmen in den Renderbereich einbezogen wird, und [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/svgoptions/set_useframerotation/) bestimmt, ob die Rahmendrehung angewendet wird. Setzen Sie [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) auf `true`, wenn Text ohne Ligaturen gerendert werden muss.

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

### **Gesamten Text vektorisieren**

Setzen Sie [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) auf `true`, um den gesamten Folientext als Vektorgrafiken zu schreiben. Dies eliminiert Schriftartabhängigkeiten und sorgt für ein über Browser hinweg konsistenteres visuelles Ergebnis, jedoch ist der Text nicht mehr als SVG‑Text auswähl‑ oder durchsuchbar.

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

### **Auswahl, wie externe Schriftarten verarbeitet werden**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) verwendet einen [SvgExternalFontsHandling](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/svgexternalfontshandling/)‑Wert für Schriftarten, die extern geladen werden. Wählen Sie `AddLinksToFontFiles`, um separate Schriftdateien zu referenzieren, `Embed`, um Schriftartdaten in das SVG einzubetten, oder `Vectorize`, um nur Text, der externe Schriftarten verwendet, als Grafik zu rendern. Prüfen Sie die Lizenzierung der Schriftarten, bevor Sie sie einbetten.

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

## **Eingebettete Bildgröße reduzieren**

Verwenden Sie [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/svgoptions/set_picturescompression/) , um die Auflösung eingebetteter Bilder zu reduzieren, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) , um beschnittene Quellbereiche wegzulassen, und [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/svgoptions/set_jpegquality/) , um die JPEG‑Kodierungsqualität zu steuern. Diese Einstellungen verringern die Dateigröße zugunsten der Bildtreue oder der erhaltenen Bilddaten.

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

## **Stabile IDs für Formen und Text zuweisen**

Verwenden Sie [ISvgShapeFormattingController](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/isvgshapeformattingcontroller/) , um [ISvgShape::set_Id](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/isvgshape/set_id/) für jede SVG‑Form festzulegen. Um ebenfalls [ISvgTSpan::set_Id](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/isvgtspan/set_id/)‑Werte für Text‑`tspan`‑Elemente zu setzen, implementieren Sie [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/) . Weisen Sie einen der Controller mit [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) zu.

Der folgende Controller verwendet [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_officeinteropshapeid/) , das während der Lebensdauer der Form stabil bleibt, und einen wiederholbaren Zähler für ihre Text‑Spans. Dadurch eignen sich die erzeugten IDs für die Nachbearbeitung einer unveränderten Präsentation.

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

## **SVG-Ereignis‑Handler hinzufügen**

Rufen Sie in einem [ISvgShapeFormattingController](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/isvgshapeformattingcontroller/) [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/isvgshape/seteventhandler/) mit einem [SvgEvent](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/svgevent/)‑Wert auf, um einem exportierten Shape einen JavaScript‑Ereignis‑Handler hinzuzufügen. Weisen Sie den Controller mit [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) zu und definieren Sie die JavaScript‑Funktion auf der Seite oder im SVG‑Dokument, das das Ergebnis hostet.

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

**Wann sollte ich [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) anstelle von [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/svgexternalfontshandling/) verwenden?**

Verwenden Sie [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) , wenn sämtlicher Text unabhängig von Schriftarten sein muss. Verwenden Sie [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/svgexternalfontshandling/) , wenn nur Text, der externe Schriftarten verwendet, in Grafiken konvertiert werden soll.

**Wie kann ich ein SVG am besten verkleinern?**

Beginnen Sie mit der Komprimierung eingebetteter Bilder, dem Entfernen beschnittener Bildbereiche und der Wahl verlinkter Schriftdateien, wenn die Zielumgebung diese bereitstellen kann. Testen Sie das Ergebnis, da niedrige Bildauflösung, geringere JPEG‑Qualität und vektorisierter Text jeweils unterschiedliche Qualitäts‑ und Größenkompromisse mit sich bringen.

**Kann ich exportierte SVG‑Elemente nach dem Export ändern?**

Ja. Weisen Sie IDs über einen Formatierungs‑Controller zu und wählen Sie anschließend die entsprechenden SVG‑Elemente in Ihrem Nachbearbeitungs‑Tool oder Browser‑Skript aus.