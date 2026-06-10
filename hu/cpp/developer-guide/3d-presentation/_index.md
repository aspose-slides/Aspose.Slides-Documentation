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
description: "Alkalmazza és renderelje a 3D hatásokat PowerPoint alakzatokra és szövegre C++-ban az Aspose.Slides segítségével. Állítsa be a kamerát, megvilágítást, anyagot, extrudálást, kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for C++ képes 3D formázást létrehozni, szerkeszteni, megőrizni és megjeleníteni PowerPoint‑stílusú alakzatokra és szövegre. Ez a cikk a 3D hatásokat tárgyalja, például forgatás, kitüremkedés, lekerekítések, megvilágítás, anyag, színátmenetes vagy képes kitöltés, valamint 3D szöveg.

{{% alert color="primary" %}}
Ez a cikk a PowerPoint alakzatok és szövegek 3D formázási hatásairól szól. Nem a különálló 3D modellfájlok beszúrásáról vagy szerkesztéséről. Ha egy diát képre, PDF‑re vagy HTML‑re exportál, az Aspose.Slides ezeket a 3D hatásokat a exportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D formázási fogalmak**

Használja az [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) interfész [get_ThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_threedformat/) metódusát a 3D formázás alkalmazásához egy alakzaton. A metódus egy [IThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/) objektumot ad vissza, amely az adott alakzat 3D jelenetét vezérli.

Szöveg esetén használja az [ITextFrameFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/) interfész [get_ThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/get_threedformat/) metódusát. Ez a 3D formázást a szövegkeretre alkalmazza, nem az alakzat testére.

A legfontosabb metódusok:

| Metódus | Mit irányít | Mikor használjuk |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_camera/) | Kamera nézetpont, előre beállított kamera típusa, forgatás, zoom és perspektíva. | Forgassa az objektumot 3D térben vagy illessze egy PowerPoint 3D forgatás előre beállított értékéhez. |
| [get_LightRig](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_lightrig/) | Fény előre beállított érték, irány és fényforgatás. | Módosítsa, hogyan jelennek meg a fények és árnyékok a 3D felületen. |
| [set_Material](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/set_material/) | Felület anyaga, például lapos, matt, műanyag vagy fém. | A geometria laposabbá, puhábbá, fényesebbé vagy fémesebbé tétele. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Mennyi távolságra nyúlik ki a forma a frontális felületétől hátrafelé. | Átalakít egy lapos alakzatot láthatóan vastag 3D objektummá. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Az extrudált oldalak színe. | Láthatóvá teszi a mélységet vagy a színt egyezteti a frontális kitöltéssel. |
| [set_Depth](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/set_depth/) | További 3D mélység, amelyet a PowerPoint 3D formázás használ. | Finomhangolja a mélységet alakzatok vagy szöveg esetén, különösen a lekerekítés és anyag beállításokkal együtt. |
| [get_BevelTop](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_beveltop/) és [get_BevelBottom](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Emelt vagy lekerekített élek a front és hátoldalon. | Lágyabb vagy formázott élt ad a szúrós lapos felület helyett. |
| [get_ContourColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_contourcolor/) és [set_ContourWidth](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Körvonal a 3D objektum körül. | Kiemeli az objektum határát a renderelt kimenetben. |

## **3D alakzat létrehozása**

Egy alakzathoz általában négyféle beállítás szükséges, hogy meggyőzően 3D‑nek tűnjön:

- Kamera beállítások, mert az alapértelmezett elülső nézet elrejtheti az extrudálást.
- Fény beállítások, mert a megvilágítás teszi olvashatóvá a felületeket és oldalakat.
- Anyag beállítások, mert a felület befolyásolja, hogyan jelenik meg a fény.
- Extrudálás vagy mélység beállítások, mert egy lapos alakzathoz vastagságra van szükség.

A következő példa egy téglalapot hoz létre, szöveget ad a frontális felülethez, alkalmaz 3D formázást, PPTX‑ként menti a prezentációt, és a diát PNG‑képként rendereli.

```cpp
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

A renderelt dia képén a téglalap vastag 3D blokkként jelenik meg:

![Megjelenített kék 3D téglalap fehér 3D szöveggel a frontális felületen](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPointban a 3D forgatás a 3‑D Forgatás panelen állítható be. Az X, Y és Z forgatási értékek megfelelnek a kamera API‑val beállított forgatásnak.

![PowerPoint 3‑D Forgatás panel X, Y és Z forgatási értékek kiemelve](img_02_01.png)

Aspose.Slides‑ban a kamera típusa és forgatása a [IThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/) segítségével állítható:

```cpp
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

A kamerát akkor használja, amikor meg akarja változtatni, hogyan látja a néző az objektumot. Nem módosítja a 2D alakzati geometriát a dián. A PowerPoint és az Aspose.Slides által a renderelésnél használt 3D nézetpontot változtatja.

## **Extrudálás és mélység hozzáadása**

Az extrudálás egy alakzatot vastagnak láttat, ha kiterjeszti a frontális felület mögé. PowerPointban a mélység szabályozó állítja be ezt a látható vastagságot, a szín szabályozó pedig az oldalfelületek színét határozza meg.

![PowerPoint mélység szabályozók leképezve az extrudálás színére és magasságára vonatkozó tulajdonságokra](img_02_02.png)

Állítsa be a [set_ExtrusionHeight](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/set_extrusionheight/)‑et a vastagsághoz és a [get_ExtrusionColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/get_extrusioncolor/)‑t az oldal színéhez:

```cpp
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Használja a [set_Depth](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/set_depth/)‑et, ha közvetlenül a PowerPoint mélységértékével szeretne dolgozni, vagy a mélységet lekerekítéssel, anyaggal és szöveghatásokkal kombinálni kívánja. Sok alakzati esetben a `set_ExtrusionHeight` egyértelműbb, mert közvetlenül kifejezi a látható extrudálást.

## **Színátmenetes vagy képes kitöltés használata 3D hatásokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhat szilárd színt, színátmenetet, mintát vagy képet a frontális felületre, miközben ugyanazokat a kamera, fény, anyag és extrudálás beállításokat használja.

Ez a példa színátmenetes kitöltést alkalmaz az alakzatra és sötétebb extrudálási színt a oldalakra:

```cpp
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

A renderelt eredmény megtartja a színátmenetet a frontális felületen, és az extrudálást külön rendereli:

![Megjelenített 3D téglalap kék‑narancssárga színátmenetes kitöltéssel és narancssárga extrudálással](img_02_03.png)

Képes kitöltés használatához adja hozzá a képet a prezentációhoz, és rendelje hozzá az alakzat kitöltéséhez:

```cpp
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

A kép a frontális felületen jelenik meg, míg az extrudálás a 3D oldalfelületként renderelődik:

![Megjelenített 3D téglalap fotó kitöltéssel a frontális felületen és narancssárga extrudálással](img_02_04.png)

## **3D formázás alkalmazása szövegre**

Az alakzat 3D formázása az alakzat testét érinti. A szöveg 3D formázása a szövegkeretet. Ez hasznos WordArt‑szerű hatásokhoz, ahol maguk a betűknek is szükségük van extrudálásra, anyagra, megvilágításra és kamera beállításokra.

A következő példa mintás kitöltésű szöveget hoz létre, WordArt átalakítást alkalmaz, és 3D beállításokat konfigurál az [ITextFrameFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/)-on:

```cpp
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

A szöveg íves, extrudált 3D betűként jelenik meg:

![Megjelenített 3D szöveg íves WordArt átalakítással, narancssárga minta kitöltéssel és sötét extrudálással](img_02_05.png)

## **Exportálási és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást, amikor PowerPoint formátumokba (például PPTX) ment,. Fix elrendezésű formátumokba történő renderelés vagy exportálás során a 3D jelenet raszterizálódik vagy 2D‑ként kerül be a kimenetbe. Ez akkor is érvényes, amikor a diákat [PNG](/slides/hu/cpp/convert-powerpoint-to-png/)-ra rendereli, [PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/)-ra exportálja, [HTML](/slides/hu/cpp/convert-powerpoint-to-html/)-ra exportálja, vagy [videókonverzió](/slides/hu/cpp/convert-powerpoint-to-video/) kereteket generál.

Figyelje a következőkre:

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot a néző nem forgathatja a exportálás után.
- A végső megjelenés a kamera, fényrig, anyag, extrudálás, kitöltés és dia méretezés kombinációjától függ.
- Ha meg kell vizsgálnia az örökölt vagy sablon‑alapú formázási értékeket, olvassa el a [hatékony alakzatel属性](/slides/hu/cpp/shape-effective-properties/)‑et.
- Néhány kimeneti formátum nem képes szerkeszthető PowerPoint 3D formázást tárolni. Ilyen formátumok esetén a vizuális eredmény renderelt, nem szerkeszthető 3D beállítás.

## **GYIK**

**Készíthet-e az Aspose.Slides interaktív 3D prezentációkat?**  
Az Aspose.Slides PowerPoint 3D hatásokat hoz létre és renderel alakzatokra és szövegre. Nem tesz exportált képeket, PDF‑eket vagy HTML‑oldalakat interaktív 3D jelenetekké, amelyet a néző forgathat. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPoint‑ban, ha a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D effektus között?**  
A 3D modell egy különálló 3D objektum, amelyet a prezentációba szúrnak be. A 3D effektus egy szabványos PowerPoint alakzatra vagy szövegre alkalmazott formázás, mint például forgatás, extrudálás, lekerekítés, megvilágítás és anyag. Ez a cikk a 3D effektusokról szól.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**  
Legalább egy kamera forgatás és vagy extrudálás vagy mélység beállítása kötelező. Gyakran használják a fényriget és az anyagot is, hogy a renderelt felületeknek tiszta kiemelései és árnyékai legyenek.

**Alkalmazhatok‑e 3D hatásokat alakzatokra és szövegre egyaránt?**  
Igen. Használja az [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/)-t az alakzat testéhez és az [ITextFrameFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/)-t a szöveghez.

**Megjelennek‑e a 3D hatások képekre, PDF‑re, HTML‑re vagy videókeretekre exportáláskor?**  
Igen. Az Aspose.Slides a 3D hatásokat rendereli dia képek, PDF‑kimenet, HTML‑kimenet és videókonverzióhoz használt keretek előállítása során. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Kiolvashatom‑e a végső 3D értékeket az öröklődés és a sablon beállítások után?**  
Igen. Használja a [Shape Effective Properties](/slides/hu/cpp/shape-effective-properties/)‑ben leírt hatékony formázási API‑kat a végső kamera, fényrig, lekerekítés és kapcsolódó 3D értékek olvasásához.