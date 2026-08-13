---
title: Vytvoření 3D efektů v prezentacích pomocí C++
linktitle: 3D prezentace
type: docs
weight: 232
url: /cs/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentace
- 3D otáčení
- 3D hloubka
- 3D extruze
- 3D přechod
- 3D text
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Použijte a renderujte 3D efekty pro tvary a text v PowerPointu v C++ s Aspose.Slides. Nakonfigurujte kameru, osvětlení, materiál, extruzi, výplně a 3D text."
---
## **Přehled**

Aspose.Slides pro C++ může vytvářet, upravovat, zachovávat a vykreslovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek pokrývá 3D efekty, jako jsou otáčení, extruze, zkosení, osvětlení, materiál, přechodové nebo obrázkové výplně a 3D text.

{{% alert color="info" %}}
Tento článek se zabývá 3D formátovacími efekty na tvary a text v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných souborů 3D modelů. Když exportujete snímek jako obrázek, PDF nebo HTML, Aspose.Slides vykreslí tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

## **Koncepty 3D formátování**

Použijte metodu [get_ThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_threedformat/) rozhraní [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/), abyste na tvaru použili 3D formátování. Metoda vrací [IThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/), který řídí 3D scénu pro daný tvar.

Pro text použijte metodu [get_ThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/get_threedformat/) rozhraní [ITextFrameFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/). Tím se použije 3D formátování na rám textu místo na tělo tvaru.

Nejdůležitější metody jsou:

| Metoda | Co řídí | Kdy ji použít |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/get_camera/) | Pohled, přednastavený typ kamery, otáčení, přiblížení a perspektiva. | Otáčet objekt ve 3D prostoru nebo použít přednastavené 3D otáčení v PowerPointu. |
| [get_LightRig](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/get_lightrig/) | Přednastavené osvětlení, směr a rotace světla. | Změnit, jak se zvýraznění a stíny objevují na 3D povrchu. |
| [set_Material](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/set_material/) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Způsobit, aby stejná geometrie vypadala plochěji, měkčeji, leskleji nebo kovově. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Jak daleko se tvar prodlužuje dozadu od přední plochy. | Proměnit plochý tvar na viditelně silný 3D objekt. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Barva extrudovaných stran. | Zviditelnit hloubku nebo sladit barvu stran s výplní přední plochy. |
| [set_Depth](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/set_depth/) | Další 3D hloubka používaná v 3D formátování PowerPointu. | Jemně doladit hloubku pro tvary nebo text, zejména v kombinaci s nastavením zkosení a materiálu. |
| [get_BevelTop](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/get_beveltop/) a [get_BevelBottom](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Vyvýšené nebo zaoblené hrany na přední a zadní ploše. | Přidat zjemněný nebo formovaný okraj místo ostré ploché strany. |
| [get_ContourColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/get_contourcolor/) a [set_ContourWidth](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Obrys kolem 3D objektu. | Zdůraznit hranici objektu ve vykresleném výstupu. |

## **Vytvoření 3D tvaru**

Tvar obvykle potřebuje čtyři typy nastavení, aby vypadal opravdu 3D:

- Nastavení kamery, protože výchozí přední pohled může skrývat extruzi.
- Nastavení osvětlení, protože osvětlení umožňuje čitelnost ploch a stran.
- Nastavení materiálu, protože povrch ovlivňuje, jak se světlo vykresluje.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na jeho přední stranu, použije 3D formátování, uloží prezentaci jako PPTX a vykreslí snímek do PNG obrázku.

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

Vykreslený obrázek snímku ukazuje obdélník jako silný 3D blok:

![Vykreslený modrý 3D obdélník s bílým 3D textem na přední straně](img_01_01.png)

## **Otáčení tvaru pomocí kamery**

V PowerPointu se 3D otočení nastavuje v podokně 3‑D otočení. Hodnoty otáčení X, Y a Z odpovídají otáčení, které nastavíte přes API kamery.

![Podokno 3‑D otočení v PowerPointu s vyznačenými hodnotami otáčení X, Y a Z](img_02_01.png)

V Aspose.Slides nastavte typ kamery a otáčení přes [IThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/):

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

Použijte kameru, když potřebujete změnit, jak divák objekt vidí. Nemění to 2D geometrii tvaru na snímku. Mění to 3D pohled, který používá PowerPoint i Aspose.Slides při vykreslování.

## **Přidání extruze a hloubky**

Extruze způsobí, že tvar vypadá silně tím, že se prodlouží za přední plochu. V PowerPointu ovládání hloubky nastavuje tuto viditelnou tloušťku a ovládání barvy nastavuje barvu bočních ploch.

![Ovládání hloubky v PowerPointu přiřazené k vlastnostem barvy extruze a výšky extruze](img_02_02.png)

Nastavte [set_ExtrusionHeight](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/set_extrusionheight/) pro tloušťku a [get_ExtrusionColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) pro barvu stran:

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

Použijte [set_Depth](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/set_depth/), když potřebujete pracovat přímo s hodnotou hloubky v PowerPointu nebo kombinovat hloubku se zkosením, materiálem a textovými efekty. V mnoha scénářích tvarů je `set_ExtrusionHeight` přehlednější nastavení, protože přímo vyjadřuje viditelnou extruzi.

## **Použití přechodových nebo obrázkových výplní s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete použít jednolitou barvu, přechod, vzor nebo obrázkovou výplň na přední stranu a stále použít stejná nastavení kamery, osvětlení, materiálu a extruze.

Tento příklad použije přechodovou výplň na tvar a tmavší barvu extruze na strany:

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

Vykreslený výstup zachovává přechod na přední straně a vykresluje extruzi samostatně:

![Vykreslený 3D obdélník s modro‑oranžovou přechodovou výplní a oranžovou extruzí](img_02_03.png)

Pro použití obrázkové výplně místo toho přidejte obrázek do prezentace a přiřaďte jej výplni tvaru:

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

Obrázek se vykreslí na přední stranu, zatímco extruze se vykreslí jako 3D boční povrch:

![Vykreslený 3D obdélník s fotografickou výplní na přední straně a oranžovou extruzí](img_02_04.png)

## **Použití 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje rám textu. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text se vzorovou výplní, použije transformaci WordArt a nastaví 3D parametry na [ITextFrameFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/):

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

Text se vykreslí jako zakřivené, extrudované 3D písmo:

![Vykreslený 3D text s zakřivenou WordArt transformací, oranžovou vzorovanou výplní a tmavou extruzí](img_02_05.png)

## **Chování exportu a vykreslování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při vykreslování nebo exportu do formátů s pevnou rozložením se 3D scéna rasterizuje nebo vloží do výstupu jako 2D výsledek. To platí, když vykreslujete snímky do [PNG](/slides/cs/cpp/convert-powerpoint-to-png/), exportujete do [PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/), exportujete do [HTML](/slides/cs/cpp/convert-powerpoint-to-html/), nebo generujete snímky pro [video conversion](/slides/cs/cpp/convert-powerpoint-to-video/).

Mějte na paměti tyto body:

- Exportované obrázky a PDF nejsou interaktivní. Objekt nelze po exportu otáčet.
- Konečný vzhled závisí na kombinaci kamery, osvětlení, materiálu, extruze, výplně a měřítka snímku.
- Pokud potřebujete zkontrolovat zděděné nebo tématem definované hodnoty formátování, přečtěte si [effective shape properties](/slides/cs/cpp/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit upravitelný PowerPoint 3D formát. V těchto formátech se vizuální výsledek vykreslí místo toho, aby byl zachován jako upravitelná 3D nastavení.

## **Často kladené otázky**

### Může Aspose.Slides vytvářet interaktivní 3D prezentace?

Aspose.Slides vytváří a vykresluje 3D efekty PowerPointu pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML stránkách, které by divák mohl otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, pokud formát podporuje úpravy.

### Jaký je rozdíl mezi 3D modelem a 3D efektem?

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný tvar nebo text v PowerPointu, jako je otáčení, extruze, zkosení, osvětlení a materiál. Tento článek se zabývá 3D efekty.

### Jaká nastavení jsou potřebná pro viditelný 3D tvar?

Minimálně nastavte rotaci kamery a buď extruzi, nebo hloubku. V praxi také nastavte osvětlení a materiál, aby vykreslené plochy měly jasné zvýraznění a stínování.

### Mohu použít 3D efekty na tvary i text?

Ano. Použijte [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/) pro tělo tvaru a [ITextFrameFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/) pro text.

### Budou 3D efekty viditelné při exportu do obrázků, PDF, HTML nebo video snímků?

Ano. Aspose.Slides vykreslí 3D efekty při tvorbě obrázků snímků, PDF výstupu, HTML výstupu a snímcích používaných pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, nikoli editovatelný 3D objekt.

### Mohu přečíst finální 3D hodnoty po aplikaci dědičných a tématických nastavení?

Ano. Použijte API pro efektivní formátování popsaná v [effective shape properties](/slides/cs/cpp/shape-effective-properties/), abyste získali konečné hodnoty kamery, osvětlení, zkosení a souvisejících 3D parametrů.