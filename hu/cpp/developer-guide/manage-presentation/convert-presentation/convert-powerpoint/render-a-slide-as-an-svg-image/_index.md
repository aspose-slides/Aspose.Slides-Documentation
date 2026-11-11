---
title: Dia bemutatók renderelése SVG képekként C++-ban
linktitle: Dia SVG-re
type: docs
weight: 50
url: /hu/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint SVG-re
- bemutató SVG-re
- dia SVG-re
- PPT SVG-re
- PPTX SVG-re
- SVG exportálási beállítások
- interaktív SVG
- PowerPoint
- bemutató
- C++
- Aspose.Slides
description: "Exportálja a PowerPoint diákat SVG képekként C++-ban, és vezérelje a betűkészleteket, szöveget, képeket, azonosítókat és eseményeket az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy méretezhető XML-alapú képfájl formátum, amely jól működik webes publikálásnál, diavetítőkben, hozzáférhetőségi munkafolyamatokban és automatizált utófeldolgozásban. Az Aspose.Slides for C++ minden diát külön SVG-fájlba exportál, és lehetővé teszi a szöveg, a betűkészletek, a képek és az SVG-elemek írásának vezérlését.

Használja a [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) elemet, ha az exportált SVG-nek kompakt, böngészők között kiszámítható vagy interaktív használatra késznek kell lennie.

## **Dia exportálása SVG-ként**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) objektumot, válasszon ki egy diát, és írja egy adatfolyamba. A következő példa a prezentáció minden diáját külön SVG-fájlba exportálja.

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

A fájlnév a [ISlide::get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_slidenumber/) metódust használja a ciklusindex helyett. Egyetlen alakzatot is exportálhat a [IShape::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/) segítségével, ha egy diavetítő vagy weboldal csak azt az alakzatot igényli.

## **SVG kimenet konfigurálása**

[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) szabályozza az SVG megjelenítését. Szövegkereteknél a [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframesize/) a szövegkeretet a megjelenítési területbe veszi, és a [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframerotation/) meghatározza, hogy a keret forgatását alkalmazzák-e. Állítsa a [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) értékét `true`-ra, ha a szöveget ligatúrák nélkül kell megjeleníteni.

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

## **Vonalvégi levágás vezérlése nyílhegyeknél**

Az SVG 1.1 nem rendelkezik marker inset beállítással, amely meghatározná, hol álljon le a vonal egy nyílhegy alatt. Alapértelmezés szerint az Aspose.Slides lerövidíti az exportált vonalat, hogy a vonalstílus ne lógjon ki a markerből. Állítsa a [SVGOptions::set_DisableLineEndCropping](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablelineendcropping/) értékét `true`-ra, hogy a vonal teljes egészében a vonal eredeti végpontjáig rajzolódjon. Ez a beállítás csak az SVG kimenetet érinti. A vonal a dián megőrzi a pozícióját és hosszát.

A példa háromszög és rombusz nyílhegyet rajzol 2‑ és 10‑pont széles vonalakon. Kétszer exportálja ugyanazt a diát, csak a levágási beállítást változtatva.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/ShapeType.h>
#include <Export/SVGOptions.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto y = 40;
const LineArrowheadStyle styles[] = { LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond };
const int widths[] = { 2, 10 };

for (auto style : styles)
{
    for (auto width : widths)
    {
        auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 40, y, 200, 0);
        auto format = line->get_LineFormat();
        format->get_FillFormat()->set_FillType(FillType::Solid);
        format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
        format->set_Width(width);
        format->set_EndArrowheadStyle(style);
        y += 50;
    }
}

auto options = MakeObject<SVGOptions>();
options->set_DisableLineEndCropping(false);
auto cropped = File::Create(u"cropped.svg");
slide->WriteAsSvg(cropped, options);
cropped->Dispose();

options->set_DisableLineEndCropping(true);
auto uncropped = File::Create(u"uncropped.svg");
slide->WriteAsSvg(uncropped, options);
uncropped->Dispose();

presentation->Dispose();
```

Az összehasonlítás a 10‑pontos vonalon a háromszög alakú nyílhegyet mutatja. Levágás engedélyezve a csúcs éles. Levágás letiltva a vonal kinyúlik a marker ferde oldalain, és lapos véget hagy.

![Nagyított 10‑pontos háromszög éles csúccsal, amikor a levágás engedélyezett, és lapos véggel, amikor a levágás le van tiltva](line-end-cropping.png)

A példában szereplő további vonalakon a kiálló vonal kevésbé látható a 2‑pontos háromszögnél. A kitöltött rombusz mindkét szélességnél lefedi a vonal végét.

## **Szöveg és betűkészletek vezérlése**

Dia SVG-be exportálásakor vezérelheti, hogy a szöveg szövegként maradjon-e vagy vektorgrafikává alakuljon, valamint hogy a külső betűkészletek hogyan legyenek beágyazva vagy hivatkozva. A következő beállítások segítenek egyensúlyt teremteni a vizuális konzisztencia, a szövegkijelölés és a betűkészlet-függőségek között az exportált SVG-ben.

### **Minden szöveg vektorizálása**

Állítsa a [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) értékét `true`‑ra, hogy a diák összes szövege vektorgrafikaként kerüljön kiírásra. Ez megszünteti a betűkészlet-függőségeket, és a vizuális eredményt böngészők között egységesebbé teszi, de a szöveg már nem lesz kijelölhető vagy kereshető SVG-szövegként.

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

### **Válassza ki a külső betűkészletek kezelésének módját**

A [SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) értéket használ a külsőleg betöltött betűkészletekhez. Válassza a `AddLinksToFontFiles`‑t, ha külön betűfájlokra szeretne hivatkozni, a `Embed`‑et, ha a betűkészlet adatát be szeretné ágyazni az SVG-be, vagy a `Vectorize`‑t, ha csak a külső betűkészletet használó szöveget grafikai formában szeretné megjeleníteni. Ellenőrizze a betűkészlet licencét a beágyazás előtt.

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

## **Beágyazott kép méretének csökkentése**

Használja a [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/)‑t a beágyazott képek felbontásának csökkentésére, a [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/)‑t a levágott forrásterületek kihagyására, valamint a [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/)‑t a JPEG kódolási minőség szabályozására. Ezek a beállítások a fájlméretet csökkentik a kép hűség vagy a megőrzött képadatok költségén.

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

## **Metafájl raszterezési felbontásának vezérlése**

A [SVGOptions::set_MetafileRasterizationDpi](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_metafilerasterizationdpi/) beállítja az alacsonyabb felbontási határt a metafájlok raszterizálásához SVG exportálás közben. Használja a részletek és a fájlméret egyensúlyozására, amikor EMF vagy WMF kép kerül raszterizálásra. Nem definiál globális DPI‑t az SVG-hez, és nem kényszeríti minden dián lévő objektumot raszterképpé.

Töltse le a [metafile-rasterization.pptx](metafile-rasterization.pptx) fájlt, amely egy szorosan elhelyezkedő átlós vonalakkal rendelkező EMF képet tartalmaz. A következő példa az első diát három raszterizálási felbontásban exportálja a [ISlide::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeassvg/) segítségével. Minden más exportbeállítás azonos marad, hogy az eredményeket össze lehessen hasonlítani.

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

A kimenetben az EMF minden SVG-ben egy beágyazott PNG‑vé alakult. Az alábbi mérések a mellékelt prezentációra vonatkoznak; nem általános képlet a DPI‑ról pixelméretekre való átszámításra.

| Metafájl raszterizálási DPI | Beágyazott PNG méretek | SVG fájlméret (bájt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Az alábbi összehasonlítás ugyanazt a beágyazott rasztert mutatja azonos nagyított megjelenítési méreten. A átlós vonalak látható pixelesedést mutatnak 72 DPI-nél, míg magasabb felbontásoknál simábbak a szélek, eközben az SVG-fájl mérete nő. Az érték növelése nem feltétlenül javít minden részletet vagy változtat minden exportált képet.

![Nagyított átlós vonal részletek 72, 150 és 300 DPI‑nál](metafile-rasterization-comparison.png)

A [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) szabályozza a képfelbontás csökkentését, és elrejtheti a metafájl raszterizálási felbontás változtatásának hatását. A [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) a JPEG kódolási minőséget szabályozza, nem a metafájl raszterizálási felbontást.

## **Stabil azonosítók hozzárendelése alakzatokhoz és szöveghez**

Használja az [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/)‑t, hogy az [ISvgShape::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/set_id/)‑t minden SVG‑alakzatra beállítsa. A `tspan` szövegelemek [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgtspan/set_id/) értékeinek beállításához is, valósítsa meg az [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). A vezérlőt a [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/)‑val rendelje hozzá.

A következő vezérlő a [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/)‑t használja, amely az alakzat élettartama alatt stabil, valamint egy ismételhető számlálót a szövegtartományokhoz. Ez a generált azonosítókat alkalmasá teszi egy változatlan prezentáció utófeldolgozásához.

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

Egy [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/)‑ben hívja meg a [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/seteventhandler/)‑t egy [SvgEvent](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgevent/) értékkel, hogy JavaScript eseménykezelőt adjon egy exportált alakzathoz. Rendelje hozzá a vezérlőt a [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/)‑vel, és definiálja a JavaScript függvényt az eredményt tartalmazó oldalon vagy SVG-dokumentumban.

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

A fogadó oldal definiálhatja a kezelő által hivatkozott JavaScript függvényt. Az azonosítók és eseménykezelők hozzárendelése lehetővé teszi a diavetítőket, a hozzáférhetőségi fejlesztéseket és egyéb interaktív SVG munkafolyamatokat.

## **GYIK**

**Mikor kell a [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/)‑t használni a [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) helyett?**

Használja a [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/)‑t, amikor minden szövegnek függetlennek kell lennie a betűkészletektől. Használja a [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/)‑t, amikor csak a külső betűkészleteket használó szöveget kell grafikává konvertálni.

**Mi a legjobb módja egy SVG kisebbé tételének?**

Kezdje a beágyazott képek tömörítésével, a levágott képrészek törlésével, és a hivatkozott betűfájlok kiválasztásával, ha a célkörnyezet képes ezeket kiszolgálni. Tesztelje az eredményt, mert az alacsonyabb képfelbontás, alacsonyabb JPEG minőség és a vektorizált szöveg mind más-más minőség‑ és méretkompromisszumot jelent.

**Módosíthatom-e az exportált SVG elemeket az export után?**

Igen. Rendelje hozzá az azonosítókat egy formázó vezérlő segítségével, majd válassza ki a megfelelő SVG elemeket az utófeldolgozó eszközében vagy böngésző‑scriptjében.