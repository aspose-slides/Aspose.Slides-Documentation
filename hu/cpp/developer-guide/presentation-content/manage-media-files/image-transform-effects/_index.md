---
title: Képartranszformációs hatások kezelése prezentációkban C++-ban
linktitle: Képartranszformációs hatások
type: docs
weight: 11
url: /hu/cpp/image-transform-effects/
keywords:
- képartranszformáció
- képhatás
- fényerő
- kontraszt
- szürkeárnyalatos
- kétárnyalatos
- színtónus
- HSL
- színcsere
- elmosás
- átlátszóság
- alfa hatás
- hatámlánc
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Alkalmazza, láncolja, vizsgálja, távolítsa el és ellenőrizze a képartranszformációs hatásokat képkockákhoz az Aspose.Slides for C++-val."
---
## **Áttekintés**

Az Aspose.Slides a képállításokat képek transzformációs műveleteinek rendezett gyűjteményeként ábrázolja. Egy képkerethez kezdje a keret [ISlidesPicture](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidespicture/) lekérdezésével, majd érje el a [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidespicture/get_imagetransform/) metódust. A visszaadott [IImageTransformOperationCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/) lehetővé teszi hatások hozzáadását, felsorolását, vizsgálatát, eltávolítását és törlését anélkül, hogy az eredeti kép bájtjait újraírná.

Ez a cikk egy teljes munkafolyamatot mutat be a fényerő és kontraszt, színtranszformációk, elmosás, átlátszóság, rendezett hatámláncok, hatékony értékek, eltávolítás és PPTX körútpont-ellenőrzés kezelésére.

## **Értse meg a hatás tulajdonjogát és a képek újrafelhasználását**

Egy képernyőforrás és a megjelenítő kép két külön objektum:

- [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) tárolja vagy hivatkozik a prezentációnak a tulajdonában álló forráskép adataira.
- [ISlidesPicture](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidespicture/) egy kép kitöltéshez tartozik, és egy képernyőforrásra hivatkozik, miközben a kép transzformációs gyűjteményt tárolja.
- [IPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframe/) a dián lévő alakzat, amely a megfelelő képkitöltést, geometriát, vágóbeállításokat és egyéb keretszintű formázásokat birtokolja.

Ezért a kép transzformációs műveletek **nem** módosítják a [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) bájtjait. Ha ugyanazt az `IPPImage`-et többször adjuk át a [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addpictureframe/) metódusnak, minden új képkeret saját `ISlidesPicture`-et és saját transzformációs gyűjteményt kap. Az egyik keretre alkalmazott szürkeárnyalatos hatás **nem** lesz a többi keretre, még akkor sem, ha mindegyik ugyanazt a beágyazott képernyőforrást használja.

Ugyanez a `ISlidesPicture::get_ImageTransform` modell más képkitöltéseknél is használható, például alakzat vagy dia háttér esetén. Az alábbi példák csak képkeretekre fókuszálnak.

## **Használjon érvényes paramétertartományokat és egységeket**

A bemutatott módszerek a következő szemantikus tartományokat és egységeket alkalmazzák. Tartsa a értékeket ezekben a tartományokban, még akkor is, ha egy adott könyvtárverzió nem utasítja el azonnal a tartományon kívüli értékeket; a célprezentáció formátuma normalizálhatja, elhagyhatja vagy elutasíthatja a hibás adatokat mentéskor vagy amikor a PowerPoint megnyitja a fájlt.

| Művelet | Paraméterek | Érvényes tartomány és egység |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` és `100` között, százalékban; a `0` változatlanul hagyja az összetevőt. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Nincs | Nincsenek numerikus paraméterek. Az alfa változatlan marad. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Két szín a sötét és világos képpontokhoz. A `System::Drawing::Color` RGB és alfa csatornái `0`‑tól `255`‑ig terjednek. |
| [AddTintEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | A árnyalat `0` (záró) és `360` (nyílt) fok között; a mennyiség `-100` és `100` között, százalékban. |
| [AddHSLEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | A árnyalat `0` és `360` fok között; a telítettség és fényerő `-100` és `100` között, százalékban. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | A helyettesítő szín csatornaértékei `0`‑tól `255`‑ig terjednek. A meglévő alfa értékek változatlanok. |
| [AddBlurEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | A sugár nemnegatív, pontban mérve; a `grow` határozza, hogy a elmosott tartalom meghaladhatja‑e az eredeti határokat. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nemnegatív százalék. Az általános átlátszóság skálázásához használja a `0`‑tól `100`‑ig tartományt: a `0` teljesen átlátszó, a `100` megőrzi a meglévő alfát. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0`‑tól `100`‑ig, százalékos átlátszóság. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0`‑tól `100`‑ig, százalékos alfa küszöb. Az alatta lévő értékek átlátszóvá válnak; a küszöbnél vagy afelett lévők átlátszatlanok lesznek. |

A fix alfa moduláció esetén az átlátszóság és az opacitás egymás kiegészítői. Például a 35 % átlátszóság 65 % alfa modulációs értéknek felel meg.

## **Fényerő és kontraszt alkalmazása**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) egy [IBrightnessContrast](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/ibrightnesscontrast/) műveletet ad vissza. Skáláris beállításait a művelet létrehozásakor kell megadni. Az `IBrightnessContrast::GetEffective` metódus kiszámított, csak olvasható értékeket ad, amelyeket ellenőrizhet vagy naplózhat.

Az alábbi példa 15 % fényerőt és 20 % kontrasztot ad hozzá, majd előnézetet generál a beágyazott kép módosítása nélkül:

```cpp
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto brightnessContrast = imageTransform->AddBrightnessContrastEffect(15.0f, 20.0f);

auto effectiveValues = brightnessContrast->GetEffective();
Console::WriteLine(u"Brightness: {0}%", effectiveValues->get_Brightness());
Console::WriteLine(u"Contrast: {0}%", effectiveValues->get_Contrast());

auto preview = slide->GetImage();
preview->Save(u"brightness-contrast-preview.png", ImageFormat::Png);

presentation->Dispose();
```

A [BrightnessContrast](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/brightnesscontrast/) egy Office 2010 kép‑effekt kiterjesztés, és kevésbé hordozható, mint a szabványos DrawingML fényerő hatás. Ha a fényerő és kontraszt szerkeszthetőnek kell maradnia egy PPTX körútnál, használja az [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) metódust, és ellenőrizze az eredményt a fájl újbóli megnyitása után. A formátumkorlátozások szakaszban részletesebben kifejtésre kerül a különbség.

## **Színtranszformációk alkalmazása**

A színeffektusok függetlenül alkalmazhatók különböző képkeretekre, amelyek ugyanazt a képernyőforrást használják. Az alábbi példa öt keretet hoz létre, és szürkeárnyalatos, duotone, tint, HSL‑korrekció és színhelyettesítés hatásokat alkalmaz.

[IDuotone](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iduotone/) két önállóan szerkeszthető színparaméterrel rendelkezik: a `get_Color1` a sötét képpontokat, a `get_Color2` a világos képpontokat térképezi. Ez jól mutatja, hogy egy effektus beállításai bonyolultabbak lehetnek egy egyszerű skáláris értéknél.

```cpp
#include <DOM/Effects/IColorReplace.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto grayFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 120.0f, image);
grayFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddGrayScaleEffect();

auto duotoneFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 180.0f, 120.0f, image);
auto duotone = duotoneFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddDuotoneEffect();
duotone->get_Color1()->set_Color(Color::get_Navy());
duotone->get_Color2()->set_Color(Color::get_Gold());

auto tintFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 420.0f, 20.0f, 180.0f, 120.0f, image);
tintFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddTintEffect(210.0f, 35.0f);

auto hslFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 120.0f, 170.0f, 180.0f, 120.0f, image);
hslFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddHSLEffect(30.0f, 20.0f, -10.0f);

auto replacementFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 320.0f, 170.0f, 180.0f, 120.0f, image);
auto colorReplacement = replacementFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddColorReplaceEffect();
colorReplacement->get_Color()->set_Color(Color::get_CornflowerBlue());

presentation->Save(u"color-transformations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) minden képpont színét egy fix színre cseréli, miközben megőrzi az alfat. Ez eltér a [AddColorChangeEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/)-tól, amely egy forrásszínt egy másikra térképezi, és mind a forrás, mind a cél színformátumot feltárja.

## **Elmosás, átlátszóság és alfa‑hatások hozzáadása**

[AddBlurEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) az összes színcsatornát, beleértve az alfat is érinti. Ha a elmosott él túlnyúlhat az eredeti kép határain, állítsa a `grow` értékét `true`‑ra.

Az egységes átlátszósághoz használja a [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) metódust. Ez minden meglévő alfaértéket megszoroz, így a részben átlátszó képpontok arányosan különböznek. Az [AddAlphaReplaceEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) ehelyett egyetlen alfaértéket rendel minden képponthoz. A [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) két szintű alfát hoz létre egy küszöb alapján.

```cpp
#include <DOM/Effects/IAlphaBiLevel.h>
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto blurredFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 140.0f, image);
auto blur = blurredFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBlurEffect(4.5, true);
blur->set_Radius(5.0);

auto transparentFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 20.0f, 200.0f, 140.0f, image);
auto alphaModulate = transparentFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(65.0f);
alphaModulate->set_Amount(60.0f);

auto uniformAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 180.0f, 200.0f, 140.0f, image);
uniformAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaReplaceEffect(55.0f);

auto binaryAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 180.0f, 200.0f, 140.0f, image);
auto binaryAlphaTransform = binaryAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto alphaBiLevel = binaryAlphaTransform->AddAlphaBiLevelEffect(50.0f);
alphaBiLevel->set_Threshold(45.0f);
binaryAlphaTransform->AddAlphaInverseEffect();

presentation->Save(u"blur-and-alpha-effects.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Más, paraméter nélküli alfa‑műveletek: a [AddAlphaCeilingEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/) minden nemnulla alfat teljesen átlátszatlanná teszi; az [AddAlphaFloorEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/) minden 100 % alatti alfat teljesen átlátszóvá változtat; az [AddAlphaInverseEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/) az alfat `100% - alfa` értékre módosítja.

## **Rendezett hatámlánc felépítése**

Minden `Add...Effect` metódus új műveletet fűz a gyűjtemény végéhez. A renderelő a gyűjteményt rendezett csővezetéknek tekinti: a 0‑s művelet kimenete lesz az 1‑es bemenete, és így tovább. Ennek következtében ugyanazok a műveletek más sorrendben más képet eredményezhetnek.

Például a szürkeárnyalatos hatás, majd a tint eltávolítja a színinformációt, majd újra színezi a fényerő eredményt. Ha előbb tint, majd szürkeárnyalatos, a tint újból eltűnik. Hasonlóképpen az alfa‑helyettesítés felülírhatja a korábbi műveletek által kiszámított alfaértékeket, míg az alfa‑moduláció megőrzi azok relatív különbségeit.

Az alábbi példa egy négy műveletből álló láncot épít, PPTX‑ként menti, újra megnyitja a prezentációt, ellenőrzi a művelettípusokat és azok sorrendjét, majd a megnyitott eredményt rendereli:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IGrayScale.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ITint.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
imageTransform->AddGrayScaleEffect();
imageTransform->AddTintEffect(220.0f, 25.0f);
imageTransform->AddBlurEffect(2.5, false);
imageTransform->AddAlphaModulateFixedEffect(80.0f);

presentation->Save(u"image-transform-chain.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto reopenedShape = reopenedPresentation->get_Slide(0)->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(reopenedShape))
{
    auto reopenedFrame = ExplicitCast<IPictureFrame>(reopenedShape);
    auto reopenedTransform = reopenedFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto orderIsPreserved = reopenedTransform->get_Count() == 4 && 
            ObjectExt::Is<IGrayScale>(reopenedTransform->idx_get(0)) && 
            ObjectExt::Is<ITint>(reopenedTransform->idx_get(1)) && 
            ObjectExt::Is<IBlur>(reopenedTransform->idx_get(2)) && 
            ObjectExt::Is<IAlphaModulateFixed>(reopenedTransform->idx_get(3));
    Console::WriteLine(orderIsPreserved ? u"The effect chain was preserved." : u"The effect chain changed during the round trip.");

    auto renderedSlide = reopenedPresentation->get_Slide(0)->GetImage();
    renderedSlide->Save(u"reopened-effect-chain.png", ImageFormat::Png);
}
else
{
    Console::WriteLine(u"The reopened shape is not a picture frame.");
}

reopenedPresentation->Dispose();
```

A gyűjtemény nem kényszerít kompatibilitási mátrixot, amely szín, alfa és elmosás műveleteket külön láncokra korlátozna. Kombinálhatók, de a kombinációk nem mindig hasznosak. Egy fix színhelyettesítés eltávolítja a korábbi színhatások által előállított RGB‑variációt; a duotone után alkalmazott szürkeárnyalatos a két kiválasztott színt szünteti meg; az alfa‑ceil, floor, replace vagy bi‑level műveletek eldobhatják a korábban keletkezett alfa‑részleteket. Építse a láncot a kívánt pixel‑feldolgozási sorrend szerint, ne pedig a tételeket rendezetlen formázási zászlókként kezelje.

## **Szerkeszthető és hatékony értékek ellenőrzése**

Egy szerkeszthető művelet a `ISlidesPicture::get_ImageTransform`‑ben tárolt objektum. A hatástól függően közvetlenül elérhetők a írható tagok. Például a [IBlur](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iblur/) a `set_Radius` és `set_Grow` tagokat, az [IAlphaModulateFixed](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/ialphamodulatefixed/) a `set_Amount` tagot, az [IAlphaBiLevel](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/ialphabilevel/) a `set_Threshold` tagot teszi elérhetővé. A [IDuotone](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iduotone/) pedig módosítható [IColorFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icolorformat/) objektumokat biztosít.

Néhány művelet‑interfész, például a [IBrightnessContrast](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/itint/) és az [IAlphaReplace](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/ialphareplace/), nem teszi a létrehozási skalárokat írható tulajdonságokká. Ezeknek a beállításához távolítsa el a műveletet, és a kívánt pozícióban adjon hozzá egy újat.

A `GetEffective()` által visszaadott hatékony adatok kiszámított és csak olvashatóak. Hasznosak a téma‑függő színek feloldásához és a renderelő által használt normalizált értékek olvasásához, de nem jelentenek újabb szerkesztési felületet. Az alábbi példa felsorolja a láncot, és több gyakori művelet hatékony értékeit vizsgálja:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IAlphaModulateFixedEffectiveData.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IBlurEffectiveData.h>
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IDuotoneEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& operation : imageTransform)
    {
        if (ObjectExt::Is<IBrightnessContrast>(operation))
        {
            auto brightnessContrast = ExplicitCast<IBrightnessContrast>(operation);
            auto data = brightnessContrast->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<ILuminance>(operation))
        {
            auto luminance = ExplicitCast<ILuminance>(operation);
            auto data = luminance->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<IDuotone>(operation))
        {
            auto duotone = ExplicitCast<IDuotone>(operation);
            auto data = duotone->GetEffective();
            Console::WriteLine(u"Dark color: {0}; light color: {1}", data->get_Color1(), data->get_Color2());
        }
        else if (ObjectExt::Is<IBlur>(operation))
        {
            auto blur = ExplicitCast<IBlur>(operation);
            auto data = blur->GetEffective();
            Console::WriteLine(u"Blur radius: {0} pt", data->get_Radius());
        }
        else if (ObjectExt::Is<IAlphaModulateFixed>(operation))
        {
            auto alphaModulate = ExplicitCast<IAlphaModulateFixed>(operation);
            auto data = alphaModulate->GetEffective();
            Console::WriteLine(u"Alpha amount: {0}%", data->get_Amount());
        }
    }
}

presentation->Dispose();
```

A paraméter nélküli hatások, mint a szürkeárnyalatos, alfa‑ceil és alfa‑inverse, szintén rendelkeznek hatékony‑adat objektummal, de nincs kiírható skaláris beállításuk. Jelenlétük és pozíciójuk a gyűjteményben a lényeges információ.

## **Képtranszformációk eltávolítása vagy törlése**

Használja a [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) metódust egy művelet index szerinti eltávolításához. Mivel a indexek az eltávolítás után eltolódnak, először keresse meg a célelemet, majd a felsorolás után távolítsa el. A `Clear()` segítségével az egész láncot törölheti.

```cpp
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto blurIndex = -1;

    for (auto index = 0; index < imageTransform->get_Count(); ++index)
    {
        if (ObjectExt::Is<IBlur>(imageTransform->idx_get(index)))
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform->RemoveAt(blurIndex);
        Console::WriteLine(u"The blur operation was removed.");
    }

    imageTransform->Clear();
    Console::WriteLine(u"Remaining operations: {0}", imageTransform->get_Count());
    presentation->Save(u"image-transforms-cleared.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

A transzformációk eltávolítása vagy törlése csak a kép formázását módosítja. Nem törli, nem tömöríti újra, és nem változtatja meg a újrahasznosított [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) forrást.

## **A prezentációformátumok és exportcélok figyelembevétele**

A képtranszformációk a DrawingML‑ből származnak, ezért a PPTX a legjobb szerkeszthető formátum a hatámláncok számára. Még a PPTX‑nél sem minden művelet rendelkezik azonos hordozhatósággal:

- A szabványos DrawingML műveletek, mint a luminance, szürkeárnyalatos, duotone, tint, HSL, elmosás és általános alfa műveletek a legnagyobb eséllyel maradnak meg egy PPTX körútnál. Mindig nyissa meg újból a generált fájlt, és ellenőrizze a gyűjteményt, ha a megőrzés kritikus.
- A [BrightnessContrast](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/brightnesscontrast/) egy Office 2010 kiterjesztés, nem a szabványos DrawingML luminance művelet. Memóriabeli renderelésre használható, de nem garantált, hogy a mentés és újbóli megnyitás után szerkeszthető [IBrightnessContrast](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/ibrightnesscontrast/) marad. Tartós fényerő‑kontraszt beállításokhoz részesítse előnyben az [AddLuminanceEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) használatát.
- A bináris PPT formátum idő előtt keletkezett a teljes DrawingML hatásmodellhez képest. PPT‑re mentéskor a nem támogatott műveletek elhagyhatók, egy lánc egy támogatott részhalmazra csökkenhet, vagy a megjelenés becsült változata kerül mentésre. Ne használja a PPT‑t ellenőrzési formátumként összetett szerkeszthető láncok esetén.
- PNG, JPEG, TIFF, PDF, SVG, HTML vagy más vizuális kimenetek a támogatott láncot alkalmazzák a renderelt megjelenésre. Ezek a kimenetek nem tartalmaznak szerkeszthető `IImageTransformOperationCollection` objektumot; a raszteres formátumok a eredményt pixelekre lapítják, a dokumentum‑ vagy vektorsejtes exportok pedig saját renderelési reprezentációt tárolnak.
- A hatások nem teszik önállóvá a hivatkozott képet. Egy hivatkozott kép renderelése továbbra is a hivatkozott erőforrás elérhetőségétől függ, amikor a prezentáció betöltődik.

A különböző prezentációfogyasztók eltérő módon jeleníthetik meg a szélsőséges eseteket, különösen, ha több alfa vagy szín‑kvantálás művelet van kombinálva. Kritikus kimenetek esetén tesztelje mind a szerkeszthető körutat, mind a végső exportformátumot ugyanazzal az Aspose.Slides verzióval, amely a termelésben használatos.

## **GYIK**

**Módosítják a kép transzformációs hatások a beágyazott kép adatokat?**

Nem. A műveletek a képkitöltéshez tartozó `ISlidesPicture`‑hez tartoznak. Az alatta lévő `IPPImage` bájtjai változatlanok maradnak.

**Két ugyanazt a képet újrafelhasználó képkeret megosztja a hatásokat?**

Nem. Az `IPPImage` újrafelhasználása megakadályozza a duplikált képadatot, de minden képkeretnek általában saját `ISlidesPicture`‑e és saját kép‑transzformációs gyűjteménye van.

**Kombinálhatók a szín, elmosás és alfa hatások?**

Igen. A gyűjtemény egy rendezett láncban fogadja őket. Vegye figyelembe, hogy az egyes műveletek milyen hatással vannak az előző kimenetére, mivel a helyettesítő és küszöb műveletek eldobhatják a korábbi szín‑ vagy alfa‑részleteket.

**Miért olvasható csak a hatékony érték?**

A hatékony adat a renderelés során használt kiszámított értékeket tartalmazza, beleértve a feloldott színeket is. Szerkessze azt a műveletet, amely a transzformációs gyűjteményben tárolva van, ahol vannak írható tagok; egyébként távolítsa el, és adjon hozzá egy újat a kívánt létrehozási paraméterekkel.

**Melyik formátumot használjam a transzformációs lánc megtartásához?**

Használjon PPTX‑et, és ellenőrizze a fájlt újbóli megnyitással. A régi PPT nem képes a teljes DrawingML hatásmodellt ábrázolni, és a renderelt exportformátumok csak a megjelenést őrzik meg, nem pedig a szerkeszthető transzformációs műveleteket.