---
title: PowerPoint diák PNG-re konvertálása C++-ban
linktitle: PowerPoint PNG-re
type: docs
weight: 30
url: /hu/cpp/convert-powerpoint-to-png/
keywords:
- PowerPoint átalakítása
- bemutató átalakítása
- dia átalakítása
- PPT átalakítása
- PPTX átalakítása
- PowerPoint PNG-re
- bemutató PNG-re
- dia PNG-re
- PPT PNG-re
- PPTX PNG-re
- PPT mentése PNG-ként
- PPTX mentése PNG-ként
- PPT exportálása PNG-be
- PPTX exportálása PNG-be
- C++
- Aspose.Slides
description: "Konvertálja a PowerPoint prezentációkat gyorsan magas minőségű PNG képekké az Aspose.Slides for C++ segítségével, biztosítva a pontos, automatizált eredményeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a bemutató diákot PNG képekké konvertálni az Aspose.Slides for C++ használatával. Betöltheti a prezentációkat olyan formátumokban, mint a PPT, PPTX és ODP, renderelheti az egyes diát, és külön PNG képként mentheti el.  
Az alábbi példák bemutatják a renderelést alapértelmezett méretezésben, a méretek növelését, a kimeneti méretek pixelben való megadását, valamint egy gradient renderelési stílus kiválasztását.

## **PowerPoint konvertálása PNG-be**

Töltsön be egy prezentációt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztállyal, és a diákhoz a [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) accessoron keresztül férhet hozzá. A példa minden diát a [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) paraméter nélküli hívásával rendereli, hogy bélyegkép készüljön. Ezután meghívja a [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) metódust a [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) értékkel, hogy minden renderelt diát PNG képként mentse.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage();
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
A paraméter nélküli [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) túlterhelés 0,2-s méretezésben renderel. Például egy 720 × 540 pont méretű dia 144 × 108 pixeles bélyegképet eredményez. A kimeneti méretek szabályozásához használja a méretarányokkal vagy egy explicit képmérettel ellátott túlterheléseket, ahogy alább látható.
{{% /alert %}}

## **PowerPoint konvertálása PNG-be egyéni méretekkel**

Adja meg a vízszintes és függőleges méretarányokat a [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) hívásakor a renderelt méretek szabályozásához. Ebben a példában mindkét arány 2, így egy 720 × 540 pont méretű dia 1440 × 1080 pixeles képet eredményez. Azonos méretarányok megőrzik a dia képarányát. Minden kép PNG formátumban kerül mentésre az [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) metódussal.
```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto scaleX = 2.f;
auto scaleY = scaleX;

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **PowerPoint konvertálása PNG-be egyéni mérettel**

A kimeneti méretek pixelben való megadásához egy méretet adjon át a [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) hívásakor a méretarányok helyett. Ez a példa minden diát 960 × 720 pixelben renderel, és az eredményt az [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) metódussal menti. Válasszon olyan méreteket, amelyek a dia képarányával megegyeznek, hogy elkerülje a kép nyújtását.
```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <drawing/size.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto imageSize = System::Drawing::Size(960, 720);

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(imageSize);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Gradient renderelési stílus választása**

Tegyük fel, hogy egy dián gradient kitöltések vannak, de az exportált PNG-ben a átmenetek világosabbak vagy másképp néznek ki, mint a PowerPointban. A [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) metódust a [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) osztályon keresztül használhatja arra, hogy kiválassza, hogyan kerülnek renderelésre a gradientek.  

Töltse le a [gradient-styles.pptx](gradient-styles.pptx) fájlt, és helyezze el az alkalmazás munkakönyvtárában. Az első dián két lineáris gradient található: a tetején ciánból narancssárgába, az alján kékről sárgára. Minden gradient két színtű állomást (stop) tartalmaz, 0 % és 100 % pozícióban.  

A következő példában betölti ezt a prezentációt, és a [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) metódussal a két módon rendereli ugyanazt az első diát.
```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <DOM/GradientStyle.h>
#include <Export/RenderingOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"gradient-styles.pptx");
auto slide = presentation->get_Slide(0);

auto gradientStyles = { GradientStyle::Default, GradientStyle::PowerPointUI };
for (auto style : gradientStyles)
{
    auto options = MakeObject<RenderingOptions>();
    options->set_GradientStyle(style);

    auto image = slide->GetImage(options, 1.f, 1.f);
    auto styleName = style == GradientStyle::Default ? u"Default" : u"PowerPointUI";
    image->Save(String::Format(u"gradient-{0}.png", styleName), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

A lenti képek az ugyanabból a diából származó kimenetet mutatják, mindkét gradienttel minden képen:

| Alapértelmezett | PowerPointUI |
| --- | --- |
| ![Cián-narancssárga és kék-sárga gradientek alapértelmezett rendereléssel](gradient-Default.png) | ![Ugyanazok a gradientek PowerPointUI-val renderelve](gradient-PowerPointUI.png) |

Ebben a példában a `Default` világosabb köztes színeket eredményez, míg a `PowerPointUI` sötétebb köztes színeket. A különbség a gradient színeitől és állomásaitól függ.  

Válassza a `Default` beállítást, ha a szabványos Aspose.Slides kimenet megfelel az igényeinek. Próbálja ki a `PowerPointUI` beállítást, ha az a prioritás, hogy a megjelenés megegyezzen a PowerPointtal. Hasonlítsa össze mindkét kimenetet a kívánt eredménnyel; egyik mód sem általánosan előnyösebb.

## **Gyakran ismételt kérdések**

**Hogyan exportálhatok egy adott alakzatot, például diagramot vagy képet, a teljes dia helyett?**  
Az Aspose.Slides támogatja az [egyéni alakzatok bélyegképének generálását](/slides/hu/cpp/shape-thumbnails/), amely lehetővé teszi egy alakzat PNG képként történő renderelését.

**Támogatott a párhuzamos konvertálás szerveren?**  
Igen. Használjon külön prezentációs példányt minden szálhoz vagy folyamathoz; [ne osszon meg egyetlen példányt a szálak között](/slides/hu/cpp/multithreading/).

**Mik a kiértékelési korlátozások PNG exportálásakor?**  
Az értékelési mód vízjelet helyez a kimeneti képekre, és [egyéb korlátozásokat](/slides/hu/cpp/licensing/) alkalmaz, amíg a licenc nincs aktiválva.