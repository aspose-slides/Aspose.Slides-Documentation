---
title: Prezentációs diák renderelése SVG képekként C++-ban
linktitle: Dia SVG-re
type: docs
weight: 50
url: /hu/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint SVG-re
- prezentáció SVG-re
- dia SVG-re
- PPT SVG-re
- PPTX SVG-re
- SVG exportálási beállítások
- interaktív SVG
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Exportálja a PowerPoint diákat SVG képekként C++-ban, és irányítsa a betűtípusokat, szöveget, képeket, azonosítókat és eseményeket az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy méretezhető XML-alapú képfájl-formátum, amely jól működik webes közzétételhez, diavetítők számára, akadálymentesítési munkafolyamatokhoz és automatizált utófeldolgozáshoz. Az Aspose.Slides for C++ minden diát külön SVG fájlba exportál, és lehetővé teszi a szöveg, betűtípusok, képek és SVG elemek írásának vezérlését.

Használja a [SVGOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/svgoptions/) elemet, ha az exportált SVG-nek kompakt, böngészők között kiszámítható, vagy interaktív használatra készen kell lennie.

## **Dia exportálása SVG-ként**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektumot, válasszon ki egy diát, és írja egy stream-be. Az alábbi példa a bemutató minden diáját külön SVG fájlba exportálja.

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

A fájlnév a [ISlide::get_SlideNumber](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/get_slidenumber/) metódust használja a ciklus indexe helyett. Egy adott alakzatot is exportálhat a [IShape::WriteAsSvg](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/writeassvg/) metódussal, ha egy diavetítő vagy weboldal csak azt az alakzatot igényli.

## **SVG kimenet konfigurálása**

[A SVGOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/svgoptions/) szabályozza az SVG renderelését. A szövegkereteknél a [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/svgoptions/set_useframesize/) a szövegkeretet is belefoglalja a renderelési területbe, a [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/svgoptions/set_useframerotation/) pedig meghatározza, hogy a keret forgatása alkalmazásra kerüljön-e. Állítsa a [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) értékét `true`-ra, ha a szöveget ligatúrák nélkül kell renderelni.

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

## **Szöveg és betűtípusok vezérlése**

### **Minden szöveg vektorizálása**

A [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) értékét `true`‑ra állítva az összes diaszöveget vektoros grafikaként írja ki. Ez eltávolítja a betűtípus‑függőségeket és a megjelenést egységesebbé teszi a böngészők között, de a szöveg már nem lesz kiválasztható vagy kereshető SVG szövegként.

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

### **Válassza ki, hogyan kezelje a külső betűtípusokat**

[A SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/svgexternalfontshandling/) értéket használ a külsőleg betöltött betűtípusokhoz. Válassza a `AddLinksToFontFiles` lehetőséget külön betűtípusfájlok hivatkozásához, a `Embed` lehetőséget a betűtípus adatok SVG‑be ágyazásához, vagy a `Vectorize` lehetőséget, hogy csak a külső betűtípusokat használó szöveget grafikai formában renderelje. Ellenőrizze a betűtípus licencelését az ágyazás előtt.

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

## **Beágyazott képek méretének csökkentése**

[A SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/svgoptions/set_picturescompression/) segítségével csökkentheti a beágyazott képek felbontását, a [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) eltávolíthatja a levágott forrásterületeket, a [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/svgoptions/set_jpegquality/) pedig szabályozza a JPEG kódolás minőségét. Ezek a beállítások a fájlméretet csökkentik a kép pontosságának vagy a megmaradt képadatok költségén.

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

## **Stabil azonosítók hozzárendelése alakzatokhoz és szöveghez**

A [ISvgShapeFormattingController](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/isvgshapeformattingcontroller/) használatával beállíthatja a [ISvgShape::set_Id](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/isvgshape/set_id/) értékét minden SVG alakzatra. A szöveg `tspan` elemeinek [ISvgTSpan::set_Id](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/isvgtspan/set_id/) értékét is beállíthatja, ha megvalósítja a [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/) interfészt. Bármelyik vezérlőt hozzárendelheti a [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) segítségével.

A következő vezérlő a [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_officeinteropshapeid/) metódust használja, amely az alakzat élettartama alatt stabil, és egy ismételhető számlálót a szövegspánkokhoz. Ez a generált azonosítókat alkalmasá teszi egy változatlan bemutató utófeldolgozásához.

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

## **SVG eseménykezelők hozzáadása**

Egy [ISvgShapeFormattingController](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/isvgshapeformattingcontroller/) esetén hívja meg az [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/isvgshape/seteventhandler/) metódust egy [SvgEvent](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/svgevent/) értékkel, hogy JavaScript eseménykezelőt adjon az exportált alakzathoz. A vezérlőt a [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) segítségével rendelje hozzá, és definiálja a JavaScript függvényt az oldalon vagy az SVG dokumentumban, amely a kimenetet tartalmazza.

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

A fogadó oldal definiálhatja a kezelő által hivatkozott JavaScript függvényt. Az azonosítók és eseménykezelők hozzárendelése lehetővé teszi a diavetítők, akadálymentesítési bővítmények és egyéb interaktív SVG munkafolyamatok használatát.

## **GYIK**

**Mikor kell használni a [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) metódust a [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/svgexternalfontshandling/) helyett?**

A [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) használatos, ha az összes szövegnek függetlennek kell lennie a betűtípusoktól. A [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/svgexternalfontshandling/) akkor alkalmazandó, ha csak a külső betűtípusokat használó szöveget szeretné grafikává konvertálni.

**Mi a leghatékonyabb módja egy SVG méretének csökkentésére?**

Kezdje a beágyazott képek tömörítésével, a levágott képterületek eltávolításával, és válasszon linkelt betűtípusfájlokat, ha a célkörnyezet képes ezeket szolgáltatni. Tesztelje az eredményt, mivel a képfelbontás csökkentése, az alacsonyabb JPEG minőség és a vektorizált szöveg mind más‑más minőség‑ és méret‑kompromisszumokat jelent.

**Módosíthatom-e az exportált SVG elemeket az export után?**

Igen. Azonosítókat rendelhet a formázási vezérlőn keresztül, majd kiválaszthatja a megfelelő SVG elemeket az utófeldolgozó eszközében vagy böngészői szkriptben.