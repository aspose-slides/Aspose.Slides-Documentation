---
title: Skapa 3D-effekter i presentationer med C++
linktitle: 3D-presentation
type: docs
weight: 232
url: /sv/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D-presentation
- 3D-rotation
- 3D-djup
- 3D-extrudering
- 3D-färggradient
- 3D-text
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Applicera och rendera 3D-effekter för PowerPoint-former och -text i C++ med Aspose.Slides. Konfigurera kamera, belysning, material, extrudering, fyllningar och 3D-text."
---
## **Översikt**

Aspose.Slides for C++ kan skapa, redigera, bevara och rendera PowerPoint‑liknande 3D‑formatering för former och text. Denna artikel täcker 3D‑effekter såsom rotation, extrudering, avfasningar, belysning, material, gradient‑ eller bildfyllningar samt 3D‑text.

{{% alert color="info" %}}
Denna artikel handlar om 3D‑formateringseffekter på PowerPoint‑former och text. Den handlar inte om att infoga eller redigera fristående 3D‑modelfiler. När du exporterar en bild till en bild, PDF eller HTML renderar Aspose.Slides dessa 3D‑effekter i den exporterade 2D‑utmatningen.
{{% /alert %}}

## **3D‑formateringskoncept**

Använd gränssnittet [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/)'s [get_ThreeDFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_threedformat/)‑metod för att tillämpa 3D‑formatering på en form. Metoden returnerar [IThreeDFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/), som styr 3D‑scenen för den formen.

För text, använd gränssnittet [ITextFrameFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/)'s [get_ThreeDFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/get_threedformat/)‑metod. Detta tillämpar 3D‑formatering på textramen istället för på formkroppen.

De viktigaste metoderna är:

| Metod | Vad den styr | När den ska användas |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/get_camera/) | Synvinkel, förinställd kameratyp, rotation, zoom och perspektiv. | Rotera objektet i 3D‑rymden eller matcha en PowerPoint‑3D‑rotationsförinställning. |
| [get_LightRig](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/get_lightrig/) | Ljusförinställning, riktning och ljusrotation. | Ändra hur höjdpunkter och skuggor visas på 3D‑ytan. |
| [set_Material](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/set_material/) | Ytmaterial, såsom slätt, matt, plast eller metall. | Få samma geometri att se plattare, mjukare, glansigare eller metallisk ut. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Hur långt formen sträcker sig bakåt från sin främre yta. | Förvandla en platt form till ett synligt tjockt 3D‑objekt. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Färg på de extruderade sidorna. | Gör djupet synligt eller koordinera sidans färg med frontens fyllning. |
| [set_Depth](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/set_depth/) | Ytterligare 3D‑djup som används av PowerPoint‑3D‑formatering. | Finjustera djupet för former eller text, särskilt tillsammans med avfasning och materialinställningar. |
| [get_BevelTop](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/get_beveltop/) och [get_BevelBottom](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Höjda eller avrundade kanter på främre och bakre ytor. | Lägg till en mjuk eller formad kant istället för en skarp platt yta. |
| [get_ContourColor](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/get_contourcolor/) och [set_ContourWidth](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Kontur runt 3D‑objektet. | Betona objektets gräns i den renderade utmatningen. |

## **Skapa en 3D‑form**

En form behöver vanligtvis fyra typer av inställningar innan den ser trovärdig 3D‑ut:

- Kamerainställningar, eftersom standard‑framsidan kan dölja extruderingen.
- Ljusetinställningar, eftersom belysning gör ytor och sidor läsbara.
- Materialinställningar, eftersom ytan påverkar hur ljuset renderas.
- Extruderings‑ eller djupinställningar, eftersom en platt form behöver tjocklek.

Följande exempel skapar en rektangel, lägger till text på dess främre yta, tillämpar 3D‑formatering, sparar presentationen som PPTX och renderar sliden till en PNG‑bild.

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

Den renderade slide‑bilden visar rektangeln som ett tjockt 3D‑block:

![Renderad blå 3D-rektangel med vit 3D-text på främre ytan](img_01_01.png)

## **Rotera en form med kameran**

I PowerPoint konfigureras 3D‑rotation i rutan 3‑D‑Rotation. X‑, Y‑ och Z‑rotationsvärdena motsvarar den rotation du anger via kamera‑API‑t.

![PowerPoint‑rutan 3‑D‑Rotation med X, Y och Z rotationsvärden markerade](img_02_01.png)

I Aspose.Slides, sätt kameratyp och rotation via [IThreeDFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/):

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

Använd kameran när du behöver ändra hur betraktaren ser objektet. Det ändrar inte 2D‑geometrin på sliden. Det ändrar 3D‑vyn som används av PowerPoint och av Aspose.Slides vid rendering.

## **Lägg till extrudering och djup**

Extrudering får en form att se tjock ut genom att den sträcks bakom den främre ytan. I PowerPoint styr djupkontrollen detta synliga tjocklek, och färgkontrollen styr färgen på sidoytorna.

![PowerPoint‑djupkontroller mappade till extruderingsfärg‑ och extruderingshöjdsegenskaper](img_02_02.png)

Ställ in [set_ExtrusionHeight](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/set_extrusionheight/) för tjockleken och [get_ExtrusionColor](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) för sidofärgen:

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

Använd [set_Depth](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/set_depth/) när du behöver arbeta med PowerPoints djupvärde direkt eller kombinera djup med avfasning, material och texteffekter. I många form‑scenarier är `set_ExtrusionHeight` den tydligare inställningen eftersom den uttrycker den synliga extruderingen direkt.

## **Använd gradient‑ eller bildfyllningar med 3D‑effekter**

3D‑formatering är oberoende av formens fyllning. Du kan tillämpa en solid färg, gradient, mönster eller bildfyllning på den främre ytan och ändå använda samma kamera, ljus, material och extruderingsinställningar.

Detta exempel tillämpar en gradientfyllning på formen och en mörkare extruderingsfärg på sidorna:

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

Det renderade resultatet behåller gradienten på den främre ytan och renderar extruderingen separat:

![Renderad 3D‑rektangel med en blå‑till‑orange gradientfyllning och orange extrudering](img_02_03.png)

För att använda en bildfyllning istället, lägg till bilden i presentationen och tilldela den till formens fyllning:

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

Bilden renderas på den främre ytan, medan extruderingen renderas som den 3D‑sidoytan:

![Renderad 3D‑rektangel med en fotofyllning på den främre ytan och orange extrudering](img_02_04.png)

## **Tillämpa 3D‑formatering på text**

Formens 3D‑formatering påverkar formkroppen. Textens 3D‑formatering påverkar textramen. Detta är användbart för WordArt‑liknande effekter där bokstäverna själva behöver extrudering, material, belysning och kamerainställningar.

Följande exempel skapar text med en mönsterfyllning, tillämpar en WordArt‑transform och konfigurerar 3D‑inställningar på [ITextFrameFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/):

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

Texten renderas som böjda, extruderade 3D‑bokstäver:

![Renderad 3D‑text med en bågad WordArt‑transform, orange mönsterfyllning och mörk extrudering](img_02_05.png)

## **Export‑ och renderingsbeteende**

Aspose.Slides bevarar 3D‑formatering när den sparas till PowerPoint‑format som PPTX. När den renderas eller exporteras till fasta layout‑format rasteriseras 3D‑scenen eller ritas in i utdata som ett 2D‑resultat. Detta gäller när du renderar slides till [PNG](/slides/sv/cpp/convert-powerpoint-to-png/), exporterar till [PDF](/slides/sv/cpp/convert-powerpoint-to-pdf/), exporterar till [HTML](/slides/sv/cpp/convert-powerpoint-to-html/), eller genererar bildrutor för [videokonvertering](/slides/sv/cpp/convert-powerpoint-to-video/).

Kom ihåg följande:

- Exporterade bilder och PDF‑filer är inte interaktiva. Objektet kan inte roteras av betraktaren efter export.
- Det slutgiltiga utseendet beror på kombinationen av kamera, ljusrigg, material, extrudering, fyllning och bildskalning.
- Om du behöver inspektera ärvda eller temabaserade formateringsvärden, läs de [effektiva formategenskaperna för former](/slides/sv/cpp/shape-effective-properties/).
- Vissa exportformat kan inte lagra redigerbar PowerPoint‑3D‑formatering. I dessa format renderas det visuella resultatet istället för att bevaras som redigerbara 3D‑inställningar.

## **FAQ**

### Kan Aspose.Slides skapa interaktiva 3D‑presentationer?

Aspose.Slides skapar och renderar PowerPoint‑3D‑effekter för former och text. Det gör inte exporterade bilder, PDF‑filer eller HTML‑sidor till interaktiva 3D‑scener som en betraktare kan rotera. I PPTX förblir 3D‑formateringen redigerbar i PowerPoint där formatet stödjer det.

### Vad är skillnaden mellan en 3D‑modell och en 3D‑effekt?

En 3D‑modell är ett separat 3D‑objekt som infogas i en presentation. En 3D‑effekt är formatering som appliceras på en vanlig PowerPoint‑form eller text, såsom rotation, extrudering, avfasning, belysning och material. Denna artikel behandlar 3D‑effekter.

### Vilka inställningar krävs för en synlig 3D‑form?

Minst en kamerarotation och antingen extrudering eller djup måste anges. I praktiken bör även en ljusrigg och material sättas så att de renderade ytorna har tydliga högdagrar och skuggor.

### Kan jag tillämpa 3D‑effekter på både former och text?

Ja. Använd [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/) för formkroppen och [ITextFrameFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/) för text.

### Kommer 3D‑effekter att visas när jag exporterar till bilder, PDF, HTML eller videobildrutor?

Ja. Aspose.Slides renderar 3D‑effekter när den producerar slide‑bilder, PDF‑utdata, HTML‑utdata och bildrutor som används för videokonvertering. Den exporterade utdata innehåller den renderade bilden, inte ett redigerbart 3D‑objekt.

### Kan jag läsa de slutgiltiga 3D‑värdena efter arv och temainställningar har tillämpats?

Ja. Använd de effektiva formaterings‑API:erna som beskrivs i [Shape Effective Properties](/slides/sv/cpp/shape-effective-properties/) för att läsa den slutgiltiga kameran, ljusriggen, avfasningen och relaterade 3D‑värden.