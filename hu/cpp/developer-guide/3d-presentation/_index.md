---
title: 3D hatások létrehozása prezentációkban C++-vel
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
description: "Alkalmazza és renderelje a 3D effektusokat PowerPoint alakzatokhoz és szöveghez C++-ban az Aspose.Slides segítségével. Állítsa be a kamerát, megvilágítást, anyagot, extrudálást, kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for C++ képes létrehozni, szerkeszteni, megőrizni és megjeleníteni a PowerPoint‑stílusú 3D formázást alakzatokra és szövegre. Ez a cikk olyan 3D effektusokat fed le, mint a forgás, extrudálás, bevel, megvilágítás, anyag, színátmenetes vagy képes kitöltés, valamint a 3D szöveg.

{{% alert color="info" title="Note" %}}
Ez a cikk a PowerPoint alakzatok és szöveg 3D formázási effektusairól szól. Nem az önálló 3D modellfájlok beillesztéséről vagy szerkesztéséről szól. Amikor egy diát képre, PDF‑re vagy HTML‑re exportál, az Aspose.Slides ezeket a 3D effektusokat a kiexportált 2D kimenetbe jeleníti meg.
{{% /alert %}}

## **3D Formázási Fogalmak**

Használja a [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) metódust 3D formázás alkalmazásához egy alakzatra. A metódus egy [IThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/) objektumot ad vissza, amely az adott alakzat 3D jelenetét szabályozza.

Szövegnél használja a [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) metódust. Ez a szövegkeretre alkalmaz 3D formázást, nem az alakzat testére.

A legfontosabb metódusok:

| Módszer | Mit szabályoz | Mikor használjuk |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) | Nézőpont, előre beállított kamera típus, forgatás, zoom és perspektíva. | Az objektum forgatása 3D térben vagy egy PowerPoint 3D forgatás előre beállított értékének megfeleltetése. |
| [get_LightRig](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_lightrig/) | Fény előre beállított, irány és a fény forgatása. | Megváltoztatja, hogyan jelennek meg a kiemelések és árnyékok a 3D felületen. |
| [set_Material](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_material/) | Felület anyaga, például lapos, matt, műanyag vagy fém. | Ugyanazt a geometriát laposabbá, puhábbá, fényesebbé vagy fémesebbé teszi. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Milyen messzire nyúlik az alakzat hátrafelé az első oldalától. | Egy lapos alakzatot láthatóan vastag 3D objektummá alakít. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Az extrudált oldalak színe. | Láthatóvá teszi a mélységet vagy összehangolja az oldal színét az első kitöltéssel. |
| [set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) | További 3D mélység, amelyet a PowerPoint 3D formázás használ. | Az alakzatok vagy szöveg mélységének finomhangolása, különösen a bevel és anyag beállításokkal együtt. |
| [get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) és [get_BevelBottom](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Megemelt vagy lekerekített élek az első és hátsó felületeken. | Lágyabb vagy öntött él hozzáadása a szögletes, lapos felület helyett. |
| [get_ContourColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_contourcolor/) és [set_ContourWidth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Körvonal a 3D objektum körül. | Az objektum határvonalának kiemelése a megjelenített kimenetben. |

## **3D Alakzat Létrehozása**

Egy alakzat általában négyféle beállítást igényel, mielőtt hitelesen 3D‑nak tűnik:

- Kamera beállítások, mivel az alapértelmezett előnézet elrejtheti az extrudálást.
- Fény beállítások, mivel a megvilágítás teszi olvashatóvá az oldalakat.
- Anyag beállítások, mivel a felület befolyásolja a fény megjelenítését.
- Extrudálás vagy mélység beállítások, mivel egy lapos alakzatnak vastagságra van szüksége.

Az alábbi példa egy téglalapot hoz létre, szöveget ad hozzá az első felülethez, és alkalmaz 3D formázást. A kamera forgatási értékek fokban vannak megadva, az extrudálás magassága pedig 100 pont. A példa a diát PNG‑képre rendereli, kétszeres méretben, majd a bemutatót PPTX‑ként menti.

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

A renderelt dia képe a téglalapot vastag 3D blokként mutatja:

![Renderelt kék 3D téglalap fehér 3D szöveggel az első felületen](img_01_01.png)

## **Alakzat Forgatása a Kamerával**

PowerPoint‑ban a 3D forgatást a **3‑D Rotation** ablaktáblán állítják be. Az X, Y és Z forgatási értékek megfelelnek a kamera API‑n keresztül beállított forgatásnak.

![PowerPoint 3‑D Rotation ablaktábla kiemelt X, Y és Z forgatási értékekkel](img_02_01.png)

Aspose.Slides‑ben a kamerához a [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) használatával fér hozzá. Ez a példa egy téglalapot hoz létre, ortográfiai elölnézetet választ, és X, Y, Z forgatásait 20, 30, 40 fokra állítja. A alakzatot memóriában konfigurálja fájlmentés nélkül:

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

A kamerát akkor használja, amikor meg szeretné változtatni, hogyan látja a néző az objektumot. Nem változtatja meg a 2D alakzat geometriáját a dián, csak a PowerPoint és az Aspose.Slides által a renderelés során használt 3D nézőpontot.

### **Kamera Orientáció Másolása Sablon Alakzatról**

Egy sablon alakzat kameraorientációjának másolásához olvassa ki előre beállított értékét a [get_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/get_cameratype/) metódussal, és alkalmazza a [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) segítségével. A példa megnyitja a `template.pptx`‑et, és a első dián lévő első alakzatról a második alakzatra másolja a kameraorientációt. Mindkét alakzat már rendelkezik 3D megvilágítással, a második alakzatnak nincs explicit kamera forgatása.

A [GetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/getrotation/) fokban adja vissza a szögeket. Az index `0` a szélesség, az `1` a hosszúság, a `2` a revolúció. Az értékeket ebben a sorrendben adja át a [SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/)‑nek. Ha a forrás nem tartalmaz explicite forgatást, a `GetRotation` null mutatót ad vissza, ezért a második alakzat szögeit hagyja beállítatlanul. Egy `(0, 0, 0)` explicite forgatás három nullás tömböt ad vissza, és másolni kell.

```cpp
#include <DOM/ICamera.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

auto sourceCamera = slide->get_Shape(0)->get_ThreeDFormat()->get_Camera();
auto destinationCamera = slide->get_Shape(1)->get_ThreeDFormat()->get_Camera();

destinationCamera->set_CameraType(sourceCamera->get_CameraType());
auto angles = sourceCamera->GetRotation();
if (angles != nullptr)
{
    destinationCamera->SetRotation(angles[0], angles[1], angles[2]);
}

presentation->Save(u"camera-copy.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Amikor a `camera-copy.pptx`‑et újra megnyitja PowerPoint‑ban, a jobb oldali nyíl ugyanazt a kamera előbeállítást és forgatást mutatja, mint a bal oldali téglalap. Mindkét alakzat ugyanazt a megvilágítást és extrudálási mélységet használja.

![Kék 3D téglalap és jobb nyíl egyező kameraorientációval, felülről és oldalról nézve](camera-orientation.png)

## **Extrudálás és Mélység Hozzáadása**

Az extrudálás vastagabbá teszi az alakzatot az első felület mögé nyújtva. PowerPoint‑ban a mélység vezérlő állítja be ezt a látható vastagságot, a szín vezérlő az oldalak színét.

![PowerPoint mélység vezérlők leképezve az extrudálás szín és magasság tulajdonságaira](img_02_02.png)

Állítsa be az [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/)‑et a vastagságra, és az [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/)‑t az oldal színére. Ez a példa egy 100 pont magas extrudálással, lila oldalakkal rendelkező téglalapot hoz létre, majd a kamerát elforgatja, hogy a vastagság látható legyen. A formátumot memóriában konfigurálja mentés nélkül:

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

Az [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) metódus állítja be egy 3D alakzat mélységét. A [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) metódus szabályozza az extrudálási hatás magasságát, ahogy a példában látható.

## **Színátmenetes vagy Képes Kitöltés Használata 3D Effektekkel**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhat egy szilárd színt, színátmenetet, mintát vagy képet az első felületre, miközben ugyanazt a kamera, fény, anyag és extrudálás beállítást használja.

Ez a példa egy kék‑narancssárga színátmenetet alkalmaz az első felületre, és egy sötét narancssárga színt a 150 pont magas extrudálásra. A színátmenet állomásai a 0‑nál és 100‑nál jelölik a kezdetet és a végét. A kamera forgatási értékek fokban vannak. A dia PNG‑képre kerül renderelésre kétszeres alapméretben:

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

A renderelt kimenet megtartja a színátmenetet az első felületen, míg az extrudálást külön rendereli:

![Renderelt 3D téglalap kék‑narancssárga színátmenetes kitöltéssel és narancssárga extrudálással](img_02_03.png)

Képes kitöltés használatához adja hozzá a képet a bemutatóhoz, és rendelje hozzá az alakzat kitöltéséhez. Ez a példa egy már létező, `image.jpg` nevű fájlt feltételez a munkakönyvtárban. A képet kinyújtja, hogy kitöltse a téglalapot, 150 pont extrudálást alkalmaz, és fokban állítja be a kamera forgatását. A formátumot memóriában konfigurálja mentés vagy renderelés nélkül:

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

A kép az első felületen jelenik meg, míg az extrudálás a 3D oldalfelületként renderelődik:

![Renderelt 3D téglalap fotó kitöltéssel az első felületen és narancssárga extrudálással](img_02_04.png)

## **3D Formázás Alkalmazása Szövegre**

Az alakzat 3D formázása az alakzat testét érinti. A szöveg 3D formázása a szövegkeretet. Ez hasznos WordArt‑szerű hatásokhoz, ahol a betűknek maguknak kell extrudálás, anyag, megvilágítás és kamera beállítások.

Az alábbi példa egy narancssárga‑fehér rácsmintával ellátott szöveget hoz létre, felülre ívelt ívet ad, és a 3D beállításokat a [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/)‑en keresztül állítja be. Az extrudálás magassága és a mélység pontban, a fény forgatása fokban van. A alakzat kitöltése és körvonala rejtve van, hogy csak a szöveg legyen látható. A példa PNG‑képet renderel kétszeres alapdiamérettel, és PPTX‑ként menti a bemutatót:

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

A szöveg görbült, extrudált 3D betűkként jelenik meg:

![Renderelt 3D szöveg ívelt WordArt transzformációval, narancssárga mintával és sötét extrudálással](img_02_05.png)

## **Szöveg Lapos Tartása 3D Alakzaton**

A szöveg lapos tartásához hívja meg a [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_keeptextflat/)‑t a [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_textframeformat/)‑en keresztül. Ha az érték `true`, a szöveg kikerül a 3D jelenetből. Ha `false`, a szöveg a jelenetben részt vesz és követi annak 3D orientációját.

Ez a beállítás nem távolítja el az alakzat 3D formázását: kamera, fény, anyag és extrudálás továbbra is a [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/)‑en keresztül van konfigurálva. Emellett eltér a szokásos forgatástól. A [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) a alakzatot a dia síkjában forgatja, míg a [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) a szöveg egyéni forgatását szabályozza a kerete határán belül. A szöveg 3D jelenetből való eltávolítása nem állítja vissza ezeket a szögeket.

Az alábbi önálló példa egy kék téglalapot hoz létre szöveggel, majd egy másolatot helyez el mellette. Mindkét alakzat ugyanazt a 3D formázást használja; csak a szöveg beállítása különbözik: bal oldalon `false`, jobb oldalon `true`. A kamera szögei fokban, az extrudálás magassága 40 pont. A bemutatót PPTX‑ként menti, és a összehasonlító diát PNG‑re rendereli kétszeres alapmérettel.

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

Bal oldalon a szöveg követi a 3D orientációt. Jobb oldalon lapos marad, így könnyebben olvasható. Mindkét téglalap megtartja ugyanazt a látható extrudálást és 3D orientációt.

![Egymás mellé helyezett 3D téglalapok: KeepTextFlat bal oldalon `false`, jobb oldalon `true`](keep_text_flat.png)

## **Exportálás és Renderelési Viselkedés**

Az Aspose.Slides megőrzi a 3D formázást, amikor PowerPoint formátumokba (például PPTX) ment. Rögzített oldalméretű formátumok renderelésekor vagy exportálásakor a 3D jelenet raszterképpé vagy 2D‑re rajzolt eredménnyé alakul. Ez akkor is igaz, ha a diát [PNG](/slides/hu/cpp/convert-powerpoint-to-png/), [PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/hu/cpp/convert-powerpoint-to-html/) formátumba rendereli, vagy [videó konverzióhoz](/slides/hu/cpp/convert-powerpoint-to-video/) kereteket generál.

Figyeljen ezekre a pontokra:

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot az export után a néző nem forgathatja.
- A végső megjelenés a kamera, fényrendszer, anyag, extrudálás, kitöltés és diaskálázás kombinációjától függ.
- Ha a örökölt vagy téma‑alapú formázási értékeket szeretné megvizsgálni, olvassa el a [Alakzat Hatékony Tulajdonságok](/slides/hu/cpp/shape-effective-properties/) dokumentációt.
- Egyes kimeneti formátumok nem képesek szerkeszthető PowerPoint 3D formázást tárolni. Ilyen formátumokban a vizuális eredmény renderelt, nem szerkeszthető 3D beállításként marad meg.

## **GYIK**

**Létrehozhat‑e az Aspose.Slides interaktív 3D prezentációkat?**  
Az Aspose.Slides létrehozza és rendereli a PowerPoint 3D effektusokat alakzatokra és szövegre. Nem tesz interaktív 3D jeleneteket exportált képekben, PDF‑ekben vagy HTML‑oldalakon, amelyeket a néző forgathat. PPTX‑ben a 3D formázás szerkeszthető marad PowerPoint‑ban, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D effektus között?**  
A 3D modell egy önálló 3D objektum, amely a bemutatóba kerül. A 3D effektus egy szabványos PowerPoint alakzatra vagy szövegre alkalmazott formázás, például forgatás, extrudálás, bevel, megvilágítás és anyag. Ez a cikk a 3D effektusokra koncentrál.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**  
Legalább egy kamera forgatás és vagy extrudálás vagy mélység beállítása szükséges. Gyakran szükség van fényrendszerre és anyagra is, hogy a renderelt felületeknek legyenek kiemelései és árnyékai.

**Alkalmazhat‑ok‑e 3D effektusokat alakzatokra és szövegre egyaránt?**  
Igen. Használja a [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/)‑t az alakzat testére, és a [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/)‑t a szövegre.

**Megjelennek‑e a 3D effektusok képek, PDF, HTML vagy videó keretek exportálásakor?**  
Igen. Az Aspose.Slides rendereli a 3D effektusokat dia képek, PDF, HTML és videó konverzióhoz használt keretek készítésekor. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Kiolvashatom‑e a végleges 3D értékeket az öröklődés és téma beállítások után?**  
Igen. Használja a hatékony formázási API‑kat, amelyeket a [Alakzat Hatékony Tulajdonságok](/slides/hu/cpp/shape-effective-properties/) leírás részletez, a végső kamera, fényrendszer, bevel és kapcsolódó 3D értékek lekérdezéséhez.