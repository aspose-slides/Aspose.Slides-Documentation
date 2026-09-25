---
title: 3D hatások létrehozása prezentációkban C++-ban
linktitle: 3D prezentáció
type: docs
weight: 232
url: /hu/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentáció
- 3D forgatás
- 3D mélység
- 3D extrúzió
- 3D színátmenet
- 3D szöveg
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Alkalmazza és renderelje a 3D hatásokat PowerPoint alakzatokra és szövegre C++-ban az Aspose.Slides segítségével. Állítsa be a kamerát, a megvilágítást, az anyagot, az extrúziót, a kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for C++ képes létrehozni, szerkeszteni, megőrizni és megjeleníteni a PowerPoint-szerű 3D formázást alakzatokhoz és szöveghez. Ez a cikk olyan 3D hatásokat fed le, mint a forgás, extrúzió, rézsút, megvilágítás, anyag, színátmenetes vagy képes kitöltések, valamint a 3D szöveg.

{{% alert color="info" title="Note" %}}
Ez a cikk a PowerPoint alakzatok és szöveg 3D formázási hatásairól szól. Nem a önálló 3D modellfájlok beszúrásáról vagy szerkesztéséről van szó. Ha egy diát képre, PDF-re vagy HTML-re exportál, az Aspose.Slides ezeket a 3D hatásokat a exportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D formázási koncepciók**

Használja az [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_threedformat/) metódust a 3D formázás alkalmazásához egy alakzatra. A metódus egy [IThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/) objektumot ad vissza, amely az adott alakzat 3D jelenetét vezérli.

Szöveghez használja az [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/get_threedformat/) metódust. Ez a szövegkeretre alkalmaz 3D formázást, nem pedig az alakzat testére.

A legfontosabb metódusok a következők:

| Metódus | Mit irányít | Mikor kell használni |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_camera/) | Nézőpont, előre beállított kamera típusa, forgás, nagyítás és perspektíva. | Forgassa az objektumot 3D térben, vagy egyeztesse a PowerPoint 3D forgatási előbeállítással. |
| [get_LightRig](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_lightrig/) | Fény előbeállítás, irány, és fényforgatás. | Módosítsa, hogyan jelennek meg a kiemelések és árnyékok a 3D felületen. |
| [set_Material](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/set_material/) | Felületi anyag, például sík, matt, műanyag vagy fém. | Tegye ugyanazt a geometriát laposabbá, lágyabbá, fényesebbé vagy fémesebbé. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Milyen messze nyúlik visszafelé az alakzat az előoldalától. | Alakítsa a lapos alakzatot láthatóan vastag 3D objektummá. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Az extrudált oldalak színe. | Tegye a mélységet láthatóvá, vagy egyeztesse az oldal színét az előoldali kitöltéssel. |
| [set_Depth](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/set_depth/) | További 3D mélység, amelyet a PowerPoint 3D formázás használ. | Finomhangolja a mélységet alakzatoknál vagy szövegnél, különösen a rézsút és az anyag beállításokkal együtt. |
| [get_BevelTop](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_beveltop/) és [get_BevelBottom](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Emelkedett vagy lekerekített élek az elő- és hátoldalon. | Adjon hozzá lágy vagy formázott élt ahelyett, hogy éles sík felület lenne. |
| [get_ContourColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_contourcolor/) és [set_ContourWidth](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Körvonal a 3D objektum körül. | Emelje ki az objektum határát a renderelt kimenetben. |

## **3D alakzat létrehozása**

Egy alakzat általában négyféle beállítást igényel, mielőtt meggyőzően 3D-nek tűnik:

- Kamera beállítások, mert az alapértelmezett előnézet elrejtheti az extrúziót.
- Fény beállítások, mert a világítás teszi olvashatóvá az elő- és oldalfelületeket.
- Anyag beállítások, mert a felület befolyásolja a fény megjelenítését.
- Extrúzió vagy mélység beállítások, mert egy lapos alakzatnak vastagságra van szüksége.

A következő példa egy téglalapot hoz létre, szöveget ad az előoldalához, és alkalmaz 3D formázást. A kamera forgatási értékei fokban vannak megadva, az extrúzió magasság 100 pont. A példa a diát PNG képre rendereli a alapértelmezett méret kétszeresére, és a prezentációt PPTX formátumban menti.

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = Color::get_Blue();
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

A renderelt diakép a téglalapot vastag 3D blokként mutatja:

![Renderelt kék 3D téglalap fehér 3D szöveggel az előoldalon](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPointban a 3D forgatás a 3‑D Forgatás panelen konfigurálható. Az X, Y és Z forgatási értékek megfelelnek a kamera API-n keresztül beállított forgatásnak.

![PowerPoint 3‑D Forgatás panel X, Y és Z forgatási értékek kiemelve](img_02_01.png)

Aspose.Slides-ban a kamerához az [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_camera/) metódussal férhet hozzá. Ez a példa egy téglalapot hoz létre, ortográfiai előnézetet választ, és az X, Y, Z forgatásait 20, 30, 40 fokra állítja be, sorrendben. A kód a memóriában konfigurálja az alakzatot fájl mentése nélkül:

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

presentation->Dispose();
```

Használja a kamerát, amikor meg kell változtatni, hogy a néző hogyan lássa az objektumot. Nem módosítja a 2D alakzat geometriáját a dián. A PowerPoint és az Aspose.Slides által a rendereléskor használt 3D nézőpontot változtatja.

## **Extrúzió és mélység hozzáadása**

Az extrúzió egy alakzatot vastagnak mutat azzal, hogy kinyújtja a előoldal mögé. PowerPointban a mélység vezérlő állítja be ezt a látható vastagságot, a szín vezérlő pedig az oldalfelületek színét.

![PowerPoint mélység vezérlők leképezve az extrúzió színre és magasságra](img_02_02.png)

Állítsa be a [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/set_extrusionheight/) metódussal a vastagságot és a [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) metódussal az oldal színét. Ez a példa egy 100 pontos extrúziót ad a téglalaphoz lila oldalakkal, és forgatja a kamerát, hogy látható legyen a vastagság. A kód a memóriában konfigurálja az alakzatot fájl mentése nélkül:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

A [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/set_depth/) metódus beállítja egy 3D alakzat mélységét. A [set_ExtrusionHeight](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/set_extrusionheight/) metódus szabályozza az extrúzió hatás magasságát, ahogy ez a példában látható.

## **Színátmenetes vagy képes kitöltés használata 3D hatásokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhat egy egyenletes színt, színátmenetet, mintát vagy képi kitöltést az előoldalon, és továbbra is használhatja ugyanazokat a kamera, fény, anyag és extrúzió beállításokat.

Ez a példa kék‑narancssárga színátmenetet alkalmaz az előoldalon és sötét narancssárga színt a 150 pontos extrúzióra. A színátmenet megállításai a 0 és 100 jelölik a színátmenet elejét és végét. A kamera forgatási értékei fokban vannak. A dia PNG képre renderelődik a alapértelmezett méret kétszeresére:

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = Color::get_Blue();
auto secondGradientColor = Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = Color::get_DarkOrange();
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

A renderelt kimenet megtartja a színátmenetet az előoldalon, és külön rendereli az extrúziót:

![Renderelt 3D téglalap kék‑narancssárga színátmenetes kitöltéssel és narancssárga extrúzióval](img_02_03.png)

A képes kitöltés használatához adja a képet a prezentációhoz, és rendelje hozzá az alakzat kitöltéséhez. Ez a példa egy meglévő, a munkakönyvtárban lévő "image.jpg" fájlt feltételez. A képet a téglalap kitöltéséhez nyújtja, 150 pontos extrúziót alkalmaz, és a kamera forgatását fokban állítja be. A kód a memóriában konfigurálja az alakzatot fájl mentése vagy renderelése nélkül:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

auto imageData = File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

A kép az előoldalon kerül renderelésre, míg az extrúzió a 3D oldalfelületként jelenik meg:

![Renderelt 3D téglalap fotó kitöltéssel az előoldalon és narancssárga extrúzióval](img_02_04.png)

## **3D formázás alkalmazása szövegre**

A forma 3D formázása a forma testére, a szöveg 3D formázása pedig a szövegkeretre hat. Ez hasznos WordArt-szerű hatásoknál, ahol a betűknek maguknak kell extrúzióval, anyaggal, megvilágítással és kamera beállításokkal rendelkezniük.

A következő példa egy narancssárga‑fehér rácsmintával ellátott szöveget hoz létre, felfelé ívelt ívet alkalmaz, és a 3D beállításokat az [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/get_threedformat/) segítségével konfigurálja. Az extrúzió magassága és mélysége pontban, a fény forgatása fokban van megadva. Az alakzat kitöltése és körvonala rejtve van, hogy csak a szöveg látható legyen. A példa egy PNG képet renderel a diák alapértelmezett méretének kétszeresére, és a prezentációt PPTX formátumban menti:

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = Color::get_DarkOrange();
auto backgroundColor = Color::get_White();
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

A szöveg görbe, extrudált 3D betűként renderelődik:

![Renderelt 3D szöveg ívelt WordArt átalakítással, narancssárga mintás kitöltéssel és sötét extrúzióval](img_02_05.png)

## **Szöveg lapos tartása 3D alakzaton**

Ahhoz, hogy a szöveg olvasható maradjon, miközben az alakzat 3D megjelenését megőrzi, hívja meg az [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/set_keeptextflat/) metódust az [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/get_textframeformat/) segítségével. Ha az érték `true`, a szöveg kívül marad a 3D jelenetből. Ha `false`, a szöveg részt vesz a jelenetben és követi annak 3D orientációját.

Ez a beállítás nem távolítja el az alakzat 3D formázását: a kamera, a megvilágítás, az anyag és az extrúzió továbbra is az [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_threedformat/) segítségével van beállítva. Emellett különbözik a szokásos forgatástól. Az [IShape::set_Rotation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/set_rotation/) a formát a diáksíkban forgatja, míg az [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/set_rotationangle/) a szöveg saját forgatását szabályozza a körülhatároló kereten belül. A szöveg 3D jelenetből való kivétele nem állítja vissza ezeket a szögeket.

A következő önálló példa egy kék téglalapot hoz létre szöveggel, és klónozza az eredeti mellett. Mindkét forma ugyanazzal a 3D formázással rendelkezik; csak a szöveg beállítása különbözik: `false` a bal oldalon és `true` a jobb oldalon. A kamera szögek fokban vannak, az extrúzió magassága 40 pont. A példa PPTX formátumban menti a prezentációt, és a összehasonlító diát PNG-re rendereli a alapértelmezett méret kétszeresére.

```cpp
#include <DOM/ITextFrameFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
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

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 70.0f, 160.0f, 240.0f, 140.0f);

shape->get_TextFrame()->set_Text(u"Readable text");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);
shape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Center);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_CornflowerBlue());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(30.0f, 30.0f, 0.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(40.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(Color::get_RoyalBlue());
shape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(false);

auto clonedShape = slide->get_Shapes()->AddClone(shape, 400.0f, 160.0f);
auto flatTextShape = System::ExplicitCast<IAutoShape>(clonedShape);
flatTextShape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(true);

presentation->Save(u"keep_text_flat.pptx", SaveFormat::Pptx);
auto image = slide->GetImage(2.0f, 2.0f);
image->Save(u"keep_text_flat.png");
image->Dispose();
presentation->Dispose();
```

A bal oldalon a szöveg követi a 3D orientációt. A jobb oldalon lapos marad és könnyebben olvasható. Mindkét téglalap megtartja ugyanazt a látható extrúziót és 3D orientációt.

![Melléklelt 3D téglalapok: KeepTextFlat hamis a bal oldalon és igaz a jobb oldalon](keep_text_flat.png)

## **Exportálási és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást a PowerPoint formátumokba, például PPTX-be mentéskor. Amikor rögzített elrendezésű formátumokba renderel vagy exportál, a 3D jelenetet rasterizálja vagy a kimenetbe 2D eredményként rajzolja. Ez akkor érvényes, amikor a diákat [PNG](/slides/hu/cpp/convert-powerpoint-to-png/), [PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/hu/cpp/convert-powerpoint-to-html/), vagy [video conversion](/slides/hu/cpp/convert-powerpoint-to-video/) keretként generálja.

Ez a következő pontokra figyeljen:

- Az exportált képek és PDF-ek nem interaktívak. Az objektumot a néző nem forgathatja az export után.
- A végső megjelenés a kamera, a fény rig, az anyag, az extrúzió, a kitöltés és a dia méretezés kombinációjától függ.
- Ha meg kell vizsgálnia az örökölt vagy sablontól függő formázási értékeket, olvassa el a [effective shape properties](/slides/hu/cpp/shape-effective-properties/) dokumentációt.
- Néhány kimeneti formátum nem képes tárolni a szerkeszthető PowerPoint 3D formázást. Ezekben a formátumokban a vizuális eredmény renderelt, nem szerkeszthető 3D beállításként tárolódik.

## **FAQ**

**Képes az Aspose.Slides interaktív 3D prezentációkat létrehozni?**

Az Aspose.Slides létrehozza és rendereli a PowerPoint 3D hatásokat alakzatokhoz és szöveghez. Nem teszi az exportált képeket, PDF-eket vagy HTML-oldalakat interaktív 3D jelenetekké, amelyeket a néző forgathat. PPTX esetén a 3D formázás szerkeszthető marad a PowerPointban, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D hatás között?**

A 3D modell egy különálló 3D objektum, amelyet a prezentációba szúrnak be. A 3D hatás egy szabványos PowerPoint alakzatra vagy szövegre alkalmazott formázás, például forgatás, extrúzió, rézsút, megvilágítás és anyag. Ez a cikk a 3D hatásokat tárgyalja.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**

Legalább egy kamera forgatást és vagy extrúziót vagy mélységet kell beállítani. Gyakorlatban érdemes a fény riget és az anyagot is beállítani, hogy a renderelt felületeknek egyértelmű kiemelései és árnyékai legyenek.

**Alkalmazhatok 3D hatásokat alakzatokra és szövegre is?**

Igen. Használja az [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_threedformat/) metódust az alakzat testére és az [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/get_threedformat/) metódust a szövegre.

**Megjelennek a 3D hatások exportáláskor képekre, PDF-re, HTML-re vagy videó keretekre?**

Igen. Az Aspose.Slides rendereli a 3D hatásokat dia képek, PDF kimenet, HTML kimenet és a videó konvertáláshoz használt keretek előállításakor. Az exportált kimenet a renderelt megjelenést tartalmazza, nem pedig szerkeszthető 3D objektumot.

**Ki tudom olvasni a végső 3D értékeket az öröklődés és a téma beállítások alkalmazása után?**

Igen. Használja a [Shape Effective Properties](/slides/hu/cpp/shape-effective-properties/) leírt hatékony formázási API-kat a végső kamera, fény rig, rézsút és a kapcsolódó 3D értékek olvasásához.