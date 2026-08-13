---
title: 3D hatások létrehozása prezentációkban C++ használatával
linktitle: 3D prezentáció
type: docs
weight: 232
url: /hu/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentáció
- 3D forgatás
- 3D mélység
- 3D extrudálás
- 3D színátmenet
- 3D szöveg
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Alkalmazd és rendereld a 3D hatásokat a PowerPoint alakzatokra és szövegre C++-ban az Aspose.Slides segítségével. Állítsd be a kamerát, a megvilágítást, az anyagot, az extrudálást, a kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for C++ képes létrehozni, szerkeszteni, megőrizni és renderelni a PowerPoint‑szerű 3D formázást alakzatokra és szövegre. Ez a cikk a 3D‑hatásokat, például a forgatást, az extrudálást, a gereblyéket, a megvilágítást, az anyagot, a színátmenetes vagy képes kitöltéseket, valamint a 3D szöveget tárgyalja.

{{% alert color="info" %}}
Ez a cikk a PowerPoint‑alakzatok és szövegek 3D formázási hatásairól szól. Nem a különálló 3D modellfájlok beillesztéséről vagy szerkesztéséről.
Amikor egy diát képnek, PDF‑nek vagy HTML‑nek exportálsz, az Aspose.Slides ezeket a 3D‑hatásokat a kiexportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D formázási fogalmak**

Használd a [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) interfész [get_ThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_threedformat/) metódusát 3D formázás alkalmazásához egy alakzatra. A metódus egy [IThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/) példányt ad vissza, amely az alakzat 3D jelenetét vezérli.

A szöveg esetében a [ITextFrameFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/) interfész [get_ThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/get_threedformat/) metódusát használd. Ez a szövegkeretre vonatkozik, nem az alakzat testeire.

A legfontosabb metódusok:

| Metódus | Mit vezérel | Mikor használjuk |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_camera/) | Nézőpont, előre definiált kamera típus, forgatás, zoom és perspektíva. | Az objektum 3D térben való forgatásához vagy PowerPoint 3D forgatási előbeállításának követéséhez. |
| [get_LightRig](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_lightrig/) | Fény előbeállítás, irány és fényforgás. | A kiemelések és árnyékok megjelenésének módosításához a 3D felületen. |
| [set_Material](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/set_material/) | Felületi anyag, például lapos, matt, műanyag vagy fém. | Ugyanazon geometria laposabbá, puhábbá, fényesebbé vagy fémesebbé tételéhez. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Mennyi távolságra nyúlik ki az alakzat a frontális felület mögött. | Egy lapos alakzatot láthatóan vastag 3D objektummá alakít. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Az extrudált oldalak színe. | Mélység láthatóvá tételéhez vagy az oldal színének a frontális kitöltéshez igazításához. |
| [set_Depth](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/set_depth/) | További 3D mélység, amelyet a PowerPoint 3D formázás használ. | A mélység finomhangolása alakzatok vagy szöveg esetén, különösen a gereblye és anyag beállításokkal együtt. |
| [get_BevelTop](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_beveltop/) és [get_BevelBottom](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Emelt vagy lekerekített él a front és a hátoldalon. | Lágyabb vagy formázott él hozzáadása egy éles, lapos felület helyett. |
| [get_ContourColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_contourcolor/) és [set_ContourWidth](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Körvonal a 3D objektum körül. | Az objektum határának hangsúlyozása a renderelt kimenetben. |

## **3D alakzat létrehozása**

Egy alakzat általában négyféle beállítást igényel, mielőtt meggyőzően 3D‑nek tűnik:

- Kamera beállítások, mert az alapértelmezett frontális nézet elrejtheti az extrudálást.
- Fény beállítások, mert a megvilágítás teszi olvashatóvá a felületeket és oldalakat.
- Anyag beállítások, mert a felület befolyásolja, hogyan jelenik meg a fény.
- Extrudálás vagy mélység beállítások, mert egy lapos alakzatnak vastagságra van szüksége.

Az alábbi példa egy téglalapot hoz létre, szöveget ad a frontális felülethez, alkalmaz 3D formázást, PPTX‑ként menti a prezentációt, és a diát PNG képre rendereli.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = System::Drawing::Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = System::Drawing::Color::get_Blue();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"shape_3d.png");
thumbnail->Dispose();

presentation->Save(u"shape_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A renderelt dia kép a téglalapot egy vastag 3D blokként mutatja:

![Renderelt kék 3D téglalap fehér 3D szöveggel a frontális felületen](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPointban a 3D forgatás a **3‑D Rotation** ablaktáblán állítható be. Az X, Y és Z forgatási értékek megfelelnek a kamera API‑n keresztül beállított forgatásnak.

![PowerPoint 3‑D Rotation ablaktábla X, Y és Z forgatási értékek kiemelve](img_02_01.png)

Az Aspose.Slides‑nél a kamera típusát és forgását a [IThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/) segítségével állíthatod:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

Használd a kamerát, amikor meg akarod változtatni, hogyan látja a néző az objektumot. Nem módosítja a 2D alakzat geometriáját a dián, csak a PowerPoint és az Aspose.Slides által a rendereléshez használt 3D nézőpontot.

## **Extrudálás és mélység hozzáadása**

Az extrudálás egy alakzatot vastagabbá tesz azzal, hogy a frontális felület mögé nyúlik. PowerPointban a mélység vezérlő beállítja ezt a látható vastagságot, a szín vezérlő beállítja az oldalak színét.

![PowerPoint mélység vezérlők leképezve az extrudálás színére és extrudálás magasságára](img_02_02.png)

Állítsd be a [set_ExtrusionHeight](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/set_extrusionheight/)‑t a vastagsághoz és a [get_ExtrusionColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_extrusioncolor/)‑t az oldal színéhez:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Használd a [set_Depth](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/set_depth/)‑t, ha közvetlenül a PowerPoint mélységértékével szeretnél dolgozni, vagy a mélységet gereblyével, anyaggal és szöveghatásokkal kombinálnád. Sok alakzatszituációban a `set_ExtrusionHeight` egyértelműbb beállítás, mivel közvetlenül az látható extrudálást fejezi ki.

## **Gradiens vagy képkitöltés használata 3D hatásokkal**

A 3D formázás független a forma kitöltésétől. Alkalmazhatsz egyetlen színt, színátmenetet, mintát vagy képet a frontális felületre, miközben ugyanazt a kamerát, fényt, anyagot és extrudálást használod.

Ez a példa színátmenetes kitöltést alkalmaz a formára, és sötétebb extrudálás színt az oldalakon:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = System::Drawing::Color::get_Blue();
auto secondGradientColor = System::Drawing::Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"gradient_3d.png");
thumbnail->Dispose();

presentation->Dispose();
```

A renderelt kimenet megőrzi a színátmenetet a frontális felületen, és külön rendereli az extrudálást:

![Renderelt 3D téglalap kék‑narancs színátmenetes kitöltéssel és narancs extrudálással](img_02_03.png)

Képkitöltés használatához add hozzá a képet a prezentációhoz, és rendeld hozzá a forma kitöltéséhez:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

A kép a frontális felületen jelenik meg, míg az extrudálás a 3D oldal felületként renderelődik:

![Renderelt 3D téglalap fotó kitöltéssel a frontális felületen és narancs extrudálással](img_02_04.png)

## **3D formázás alkalmazása a szövegre**

Az alakzat 3D formázása a forma testét érinti. A szöveg 3D formázása a szövegkeretet. Ez hasznos WordArt‑szerű hatásokhoz, ahol maguk a betűknek is szükségük van extrudálásra, anyagra, megvilágításra és kamera beállításokra.

Az alábbi példa szöveget hoz létre mintás kitöltéssel, WordArt átalakítást alkalmaz, és 3D beállításokat konfigurál a [ITextFrameFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/) számára:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = System::Drawing::Color::get_DarkOrange();
auto backgroundColor = System::Drawing::Color::get_White();
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(foregroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(backgroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_Transform(TextShapeType::ArchUp);
textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);
textFrameFormat->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text_3d.png");
thumbnail->Dispose();

presentation->Save(u"text_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A szöveg ívelt, extrudált 3D betűként jelenik meg:

![Renderelt 3D szöveg ívelt WordArt átalakítással, narancs mintás kitöltéssel és sötét extrudálással](img_02_05.png)

## **Exportálási és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást, amikor PowerPoint formátumokba, például PPTX‑be menti. Fix elrendezésű formátumokba történő renderelés vagy exportálás esetén a 3D jelenet raszterizálódik vagy a kimenetbe 2D‑ként kerül beágyazásra. Ez akkor is érvényes, amikor a diákot **[PNG](/slides/hu/cpp/convert-powerpoint-to-png/)**‑re rendereled, **[PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/)**‑ra exportálod, **[HTML](/slides/hu/cpp/convert-powerpoint-to-html/)**‑ra exportálod, vagy **[videó konverzió](/slides/hu/cpp/convert-powerpoint-to-video/)** kereteket generálsz.

Fontos szempontok:

- Az exportált képek és PDF‑ek nem interaktívak. Az objektum export után nem forgatható a néző által.
- A végső megjelenés a kamera, a fényrig, az anyag, az extrudálás, a kitöltés és a dia méretezésének kombinációjától függ.
- Ha az örökölt vagy sablonalapú formázási értékeket szeretnéd ellenőrizni, olvasd el a **[hatékony alakzat tulajdonságok](/slides/hu/cpp/shape-effective-properties/)** dokumentációját.
- Egyes kimeneti formátumok nem tudják tárolni a szerkeszthető PowerPoint 3D formázást. Ezekben a formátumokban a vizuális eredmény renderelve lesz, nem szerkeszthető 3D beállításként.

## **GYIK**

### Képes-e az Aspose.Slides interaktív 3D prezentációk létrehozására?

Az Aspose.Slides PowerPoint 3D hatásokat hoz létre és renderel alakzatokra és szövegre. Nem tesz interaktív 3D jeleneteket exportált képek, PDF‑ek vagy HTML oldalak esetén, amelyeket a néző forgathat. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPointban, ahol a formátum támogatja.

### Mi a különbség egy 3D modell és egy 3D hatás között?

A 3D modell egy különálló 3D objektum, amely a prezentációba van beillesztve. A 3D hatás egy formázás, amelyet egy szabályos PowerPoint alakzatra vagy szövegre alkalmaznak, például forgatás, extrudálás, gereblye, megvilágítás és anyag. Ez a cikk a 3D hatásokat tárgyalja.

### Mely beállítások szükségesek egy látható 3D alakzathoz?

Minimum egy kamera forgatás és vagy extrudálás vagy mélység beállítása szükséges. Gyakorlatban érdemes egy fényriget és anyagot is beállítani, hogy a renderelt felületeknek legyenek tiszta kiemelései és árnyékai.

### Alkalmazhatok‑e 3D hatásokat alakzatokra és szövegre egyaránt?

Igen. Használd a [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/)‑t az alakzat testére és a [ITextFrameFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/)‑t a szövegre.

### Megjelennek‑e a 3D hatások képekre, PDF‑re, HTML‑re vagy videó keretekre exportálva?

Igen. Az Aspose.Slides a 3D hatásokat rendereli a dia képek, PDF‑kimenet, HTML‑kimenet és a videó konverzióhoz használt keretek előállításakor. Az exportált kimenet a renderelt megjelenést tartalmazza, nem egy szerkeszthető 3D objektumot.

### Kiolvashatom‑e a végső 3D értékeket a öröklődés és a sablon beállítások alkalmazása után?

Igen. Használd a **[Shape Effective Properties](/slides/hu/cpp/shape-effective-properties/)**‑ben leírt hatékony formázási API‑kat a végső kamera, fényrig, gereblye és a kapcsolódó 3D értékek lekérdezéséhez.