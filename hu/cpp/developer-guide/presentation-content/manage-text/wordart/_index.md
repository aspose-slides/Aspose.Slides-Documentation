---
title: WordArt hatások létrehozása és alkalmazása C++-ban
linktitle: WordArt
type: docs
weight: 110
url: /hu/cpp/wordart/
keywords:
- WordArt
- WordArt létrehozása
- WordArt sablon
- WordArt hatás
- árnyékhatás
- tükrözés hatás
- ragyogás hatás
- WordArt átalakítás
- 3D hatás
- külső árnyék hatás
- belső árnyék hatás
- C++
- Aspose.Slides
description: "WordArt hatások létrehozása és testreszabása az Aspose.Slides for C++-ban. Ez a lépésről lépésre útmutató segít a fejlesztőknek a prezentációk professzionális szövegekkel való gazdagításában C++-ban."
---
## **Áttekintés**

A WordArt hatások lehetővé teszik a szöveg formázását kitöltésekkel, körvonalakkal, árnyékokkal, tükrözésekkel, ragyogással, átalakításokkal és 3D formázással. Ez a cikk bemutatja, hogyan hozhatók létre és testreszabhatók ezek a hatások PowerPoint‑prezentációkban az Aspose.Slides for C++ használatával, anélkül, hogy a Microsoft Office telepítve lenne.

## **Egyszerű WordArt sablon létrehozása és alkalmazása szövegre**

Az alábbi példák egy egyszerű WordArt stílust építenek fel a szöveg, a betűtípus, a minta kitöltés és a körvonal beállításával.

Minden példa új prezentációt hoz létre, és egy téglalapot ad hozzá az első diához; bemeneti fájl nem szükséges. Az első példában a szöveget "Aspose.Slides"-re állítja. Az alakzat pozíciója és méretei pontban vannak megadva:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

Állítsa a betűtípust Arial Black-ra 36 pontra, hogy a formázás jobban látható legyen:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

Alkalmazzon egy [SmallGrid](https://reference.aspose.com/slides/hu/cpp/aspose.slides/patternstyle/) mintát sötét narancssárga előtérrel és fehér háttérrel, majd adjon hozzá egy 1 pont széles fekete szövegkörvonalat:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IPatternFormat.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

portion->get_PortionFormat()->get_LineFormat()->set_Width(1);
auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

Az eredményül kapott szöveg:

![Az egyszerű WordArt sablon](WordArt_template.png)

## **Más WordArt hatások alkalmazása**

Az alábbi példák bemutatják, hogyan alkalmazhatók árnyékok, tükrözések, ragyogás, átalakítások és 3D hatások a szövegre.

### **Külső árnyékhatások alkalmazása**

A külső árnyék mélységet ad a szöveg mögé helyezett árnyékkal. A színét, irányát, távolságát, elmosódási sugarát, méretezését és ferdeségét testreszabhatja.

Ez a példa meghívja a [EnableOuterShadowEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ieffectformat/enableoutershadoweffect/) metódust, és egy fekete árnyékot állít be 4 pontos elmosódási sugárral, 230 fokos iránnyal és 30 pont távolsággal. A 100-as méretezési értékek megőrzik az árnyék méretét, míg a vízszintes ferde eltolás 20 fokkal dönti el. Az alfa transzformáció 32 %-ra állítja az átlátszatlanságot:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(100);
outerShadowEffect->set_BlurRadius(4);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(30);
outerShadowEffect->set_SkewHorizontal(20);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

Az eredményül kapott szöveg:

![A külső árnyék hatás](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Ha a külső és az előre definiált árnyékok együtt vannak használva, csak a külső árnyék lesz alkalmazva.
- Ha a külső és a belső árnyékok egyszerre vannak használva, a kapott hatás a PowerPoint verziójától függ. Például a PowerPoint 2013-ban a hatás duplázódik, míg a PowerPoint 2007-ben csak a külső árnyék kerül alkalmazásra.
{{% /alert %}}

### **Tükrözés hatások alkalmazása**

A tükrözés a szöveg tükörképét hozza létre. Állítsa be a pozícióját, méretezését, elmosódását és átlátszatlanságát a megjelenés szabályozásához.

Ez a példa meghívja a [EnableReflectionEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ieffectformat/enablereflectioneffect/) metódust, és függőlegesen tükrözi a visszatükröződést -100 %-os méretezéssel. 0,5 pontos elmosódási sugarat és 4,72 pont távolságot használ. Az átlátszatlanság 60 %-ról 0,9 %-ra csökken a 0 % és 60 % közötti pozíciók között a tükrözés során:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```

Az eredményül kapott szöveg:

![A tükrözés hatás](reflection_effect.png)

### **Ragyogás hatások alkalmazása**

A ragyogás lágy színes körvonalat ad a szöveg köré. Állítsa be a színét, átlátszatlanságát és sugarát a hatás szabályozásához.

Ez a példa meghívja a [EnableGlowEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ieffectformat/enablegloweffect/) metódust, és egy 54 %-os átlátszatlanságú, 7 pont sugarú piros ragyogást alkalmaz:

```cpp
#include <drawing/color.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(Color::get_Red());
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

Az eredményül kapott szöveg:

![A ragyogás hatás](glow_effect.png)

### **WordArt átalakítások alkalmazása**

A WordArt átalakítások hajlítják, nyújtják vagy torzítják a szövegtömböt.

Állítsa be a [ITextFrameFormat::set_Transform](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/set_transform/) elemet a [ArchUpPour](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textshapetype/) értékre, hogy az egész szövegdoboz felfelé íveljen:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);

auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

Az eredményül kapott szöveg:

![A WordArt átalakítás](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for C++ előre definiált [átalakítási típusok](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textshapetype/) készletet biztosít.
{{% /alert %}}

### **3D hatások alkalmazása alakzatokra és szövegre**

Alkalmazhat 3D hatásokat egy alakzatra vagy annak szövegére. A lekerekítések, kihúzás, megvilágítás és kamerabeállítások szabályozzák az eredményes megjelenést.

Az alábbi példa a [IThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/) használatával körkörös lekerekítéseket, narancssárga kihúzást és sötétvörös körvonalat ad a téglalaphoz. A lekerekítések, kihúzás magassága, körvonal szélessége és mélysége pontban van megadva. Egy műanyag anyag, 40 fokkal a Z tengely körül elforgatott kiegyensúlyozott megvilágítás és egy perspektív kamera határozza meg a megjelenést:

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
autoShape->get_TextFrame()->set_Text(u"Aspose.Slides");

auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

![Az alakzat 3D hatása](shape_3D_effect.png)

Ez a példa hasonló 3D formázást alkalmaz a szövegre a [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/get_threedformat/) segítségével. A kisebb lekerekítések a betűk széleit formálják, míg a kihúzás és a megvilágítás mélységet ad a szövegnek:

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);

auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");

auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

![A szöveg 3D hatása](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
A 3D hatások szövegre vagy azok alakzataira való alkalmazását – és ezeknek a hatásoknak az interakcióját – meghatározott szabályok irányítják. Vegyük figyelembe a jelenetet, amely magában foglalja a szöveget és azt az alakzatot, amely tartalmazza. Egy 3D hatás magában foglalja az objektum 3D ábrázolását és azt a jelenetet, amelyben elhelyezkedik.

- Ha a jelenet mind az alakzatra, mind a szövegre be van állítva, az alakzat jelenete elsőbbséget élvez, és a szöveg jelenete figyelmen kívül marad.
- Ha az alakzatnak nincs saját jelenete, de van 3D ábrázolása, a szöveg jelenete kerül használatra.
- Ha az alakzat egyáltalán nem rendelkezik 3D hatással, laposnak tekintik, és a 3D hatás csak a szövegre kerül alkalmazásra.

Ezek a viselkedések a [IThreeDFormat::get_LightRig](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_lightrig/) és a [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_camera/) metódusokra vonatkoznak.
{{% /alert %}}

Ahhoz, hogy a szöveg lapos és olvasható maradjon, miközben megtartja az alakzat 3D formázását, lásd a [Keep Text Flat on a 3D Shape](/slides/hu/cpp/3d-presentation/) oldalt a két beállítás összehasonlításáért és egy teljes C++ példáért.

## **GYIK**

**Használhatok WordArt hatásokat különböző betűtípusokkal vagy írásrendszerekkel (pl. arab, kínai)?**

Igen, az Aspose.Slides for C++ támogatja az Unicode‑ot, és működik minden főbb betűtípussal és írásrendszerrel. A WordArt hatások, mint az árnyék, a kitöltés és a körvonal, a nyelvtől függetlenül alkalmazhatók, bár a betűtípus elérhetősége és a renderelés a rendszerbetűtípusoktól függhet.

**Alkalmazhatok WordArt hatásokat a dia mester elemeire?**

Igen, a WordArt hatásokat alkalmazhatja a mesterdiák alakzataira, beleértve a címhelyettesítőket, láblécet vagy háttérszöveget. A mester elrendezésén végzett módosítások az összes kapcsolódó diára kihatnak.

**A WordArt hatások befolyásolják a prezentáció fájlméretét?**

Igen, de csak enyhén. Az olyan WordArt hatások, mint az árnyékok, a ragyogás és a színátmenetes kitöltések, a formázási metaadatok hozzáadása miatt kissé növelhetik a fájlméretet, de a különbség általában elhanyagolható.

**Megtekinthetem a WordArt hatások eredményét a prezentáció mentése nélkül?**

Igen, a WordArt‑ot tartalmazó diákat képekbe (pl. PNG, JPEG) renderelheti a [ISlide::GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/getimage/) metódussal, vagy az egyes alakzatokat a [IShape::GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/getimage/) segítségével. Ez lehetővé teszi az eredmény megtekintését memóriában vagy a képernyőn a teljes prezentáció mentése vagy exportálása előtt.