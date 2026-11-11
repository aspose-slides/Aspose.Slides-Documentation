---
title: Dia bemutatók renderelése SVG képekként C++-ban
linktitle: Dia SVG-hez
type: docs
weight: 50
url: /hu/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint SVG‑vé
- prezentáció SVG‑vé
- dia SVG‑hez
- PPT SVG‑vé
- PPTX SVG‑vé
- SVG exportálási beállítások
- interaktív SVG
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Exportálja a PowerPoint diákat SVG képekként C++-ban, és szabályozza a betűtípusokat, szöveget, képeket, azonosítókat és eseményeket az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy skálázható XML-alapú képfájlformátum, amely jól működik webes kiadványokhoz, diavetítőkhez, akadálymentesítési munkafolyamatokhoz és automatizált utófeldolgozáshoz. Az Aspose.Slides for C++ minden diát külön SVG fájlba exportál, és lehetővé teszi, hogy szabályozza, hogyan kerülnek kiírásra a szöveg, betűtípusok, képek és SVG elemek.

Használja a [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) akkor, amikor az exportált SVG-nek kompaktnak, böngészők között kiszámíthatónak vagy interaktív használatra készen kell állnia.

## **Dia exportálása SVG-ként**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) objektumot, válasszon ki egy dia, és írja ki egy adatfolyamba. Az alábbi példa a prezentáció minden diaját külön SVG fájlba exportálja.

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

A fájlnév a [ISlide::get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_slidenumber/) értékét használja a ciklusindex helyett. Egyetlen alakzatot is exportálhat a [IShape::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/) segítségével, ha egy diavetítő vagy weboldal csak azt az alakzatot igényli.

## **SVG kimenet konfigurálása**

[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) szabályozza az SVG renderelését. Szövegkeretek esetén a [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframesize/) a szövegkeretet belefoglalja a renderelési területbe, a [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframerotation/) pedig meghatározza, hogy a keret forgatását alkalmazzák-e. Állítsa a [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) értékét `true`-ra, ha a szöveget ligatúrák nélkül kell renderelni.

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

SVG-re történő diaexportáláskor szabályozhatja, hogy a szöveg szövegként maradjon vagy vektorgrafikává alakuljon, valamint hogy a külső betűtípusok hogyan legyenek belefoglalva vagy hivatkozva. A következő beállítások segítenek egyensúlyba hozni a vizuális konzisztenciát, a szövegkijelölést és a betűtípusfüggőségeket az exportált SVG-ben.

### **Minden szöveg vektorizálása**

Állítsa a [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) értékét `true`-ra, hogy a dia minden szövegét vektorgrafikaként írja ki. Ez megszünteti a betűtípusfüggőségeket, és a vizuális eredményt konzisztenssé teszi a böngészők között, azonban a szöveg már nem lesz kijelölhető vagy kereshető SVG-szövegként.

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

### **Válassza ki a külső betűtípusok kezelését**

A [SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) értéket használ a külsőleg betöltött betűtípusokhoz. Válassza az `AddLinksToFontFiles` lehetőséget, ha külön betűtípusfájlokra szeretne hivatkozni, az `Embed`-et, ha a betűtípus adatát be szeretné ágyazni az SVG-be, vagy a `Vectorize`-t, ha csak a külső betűtípusokat használó szöveget szeretné grafikaként renderelni. Ellenőrizze a betűtípus licencelését a beágyazás előtt.

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

Használja a [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) beállítást a beágyazott képek felbontásának csökkentésére, a [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) beállítást a levágott forrásterületek kihagyására, valamint a [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) beállítást a JPEG kódolás minőségének szabályozására. Ezek a beállítások a fájlméretet csökkentik a kép pontosságának vagy a megőrzött képadatok költségén.

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

## **Metafájl raszterizálási felbontásának szabályozása**

A [SVGOptions::set_MetafileRasterizationDpi](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_metafilerasterizationdpi/) beállítja a metafájlok raszterizálásának alsó felbontási határát az SVG exportálás során. Ezt használja a részletesség és a fájlméret egyensúlyozására, amikor egy EMF vagy WMF kép raszterizálódik. Nem határoz meg globális DPI‑t az SVG számára, illetve nem kényszeríti minden dián lévő objektumot raszterképpé.

Töltse le a [metafile-rasterization.pptx](metafile-rasterization.pptx) fájlt, amely egy EMF képet tartalmaz szorosan elhelyezett átlós vonalakkal. Az alábbi példa az első diát három raszterizálási felbontásban exportálja a [ISlide::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeassvg/) segítségével. Minden egyéb exportbeállítás változatlan marad, hogy az eredményeket össze lehessen hasonlítani.

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

A kimenetben az EMF minden SVG-ben egy beágyazott PNG‑vé vált. Az alábbi mérések a mellékelt prezentációra vonatkoznak; nem általános képletet jelentenek a DPI‑ről pixelméretekre történő átszámításhoz.

| Metafájl raszterizálási DPI | Beágyazott PNG méretei | SVG fájlméret (bájt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Az alábbi összehasonlítás ugyanazt a beágyazott rasztert mutatja ugyanakkora nagyított megjelenítési méreten. A diagonális vonalak látható pixelesedést mutatnak 72 DPI-n, míg magasabb felbontásoknál simább élőket, miközben az SVG fájl mérete nő. Az érték növelése nem feltétlenül javít minden részletet, vagy nem módosít minden exportált képet.

![Nagyított átlós vonal részlete 72, 150 és 300 DPI‑n](metafile-rasterization-comparison.png)

A [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) szabályozza a képfelbontás csökkentését, és elrejtheti a metafájl raszterizálási felbontás változtatásának hatását. A [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) a JPEG kódolás minőségét állítja, nem a metafájl raszterizálási felbontását.

## **Stabil azonosítók hozzárendelése alakzatokhoz és szöveghez**

Használja az [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) osztályt a [ISvgShape::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/set_id/) beállításához minden SVG alakzatra. A szöveg `tspan` elemeire is a [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgtspan/set_id/) értékek beállításához valósítsa meg az [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/) interfészt. Bármelyik vezérlőt a [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) segítségével rendelheti hozzá.

Az alábbi vezérlő a [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/) értékét használja, amely az alakzat élettartama alatt stabil, valamint egy ismételhető számlálót a szövegtartományokhoz. Ez a generált azonosítókat alkalmasá teszi egy módosítatlan prezentáció utófeldolgozására.

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

Egy [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) esetén hívja meg a [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/seteventhandler/) módszert egy [SvgEvent](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgevent/) értékkel, hogy JavaScript eseménykezelőt adjon egy exportált alakzathoz. A vezérlőt a [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) segítségével rendelje hozzá, és definiálja a JavaScript függvényt az eredményt tartalmazó oldalon vagy SVG dokumentumban.

A fogadó oldal definiálhatja a kezelő által hivatkozott JavaScript függvényt. Azonosítók és eseménykezelők hozzárendelése lehetővé teszi a diavetítőket, az akadálymentesítési fejlesztéseket és egyéb interaktív SVG munkafolyamatokat.

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

## **GYIK**

**Mikor kell a [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) használni a [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) helyett?**

Használja a [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) beállítást, amikor minden szövegnek függetlennek kell lennie a betűtípusoktól. Használja a [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) beállítást, amikor csak a külső betűtípusokat használó szöveget kell grafikává konvertálni.

**Mi a legjobb módja az SVG méretének csökkentésére?**

Kezdje a beágyazott képek tömörítésével, a levágott képterületek törlésével, és a hivatkozott betűtípusfájlok választásával, ha a célkörnyezet képes azokat szolgáltatni. Tesztelje az eredményt, mivel az alacsonyabb képfelbontás, az alacsonyabb JPEG minőség és a vektorizált szöveg mind különböző minőség‑ és méret‑kompromisszumokkal jár.

**Módosíthatom az exportált SVG elemeket az export után?**

Igen. Rendeljen ID‑ket egy formázó vezérlő segítségével, majd válassza ki a megfelelő SVG elemeket az utófeldolgozó eszközében vagy böngészőszkriptben.