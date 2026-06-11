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
- 3D-extrusion
- 3D-gradient
- 3D-text
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Applicera och rendera 3D‑effekter för PowerPoint‑former och -text i C++ med Aspose.Slides. Konfigurera kamera, belysning, material, extrusion, fyllningar och 3D‑text."
---
## **Översikt**

Aspose.Slides för C++ kan skapa, redigera, bevara och rendera PowerPoint‑liknande 3D‑formatering för former och text. Denna artikel behandlar 3D‑effekter såsom rotation, extrusion, fasningar, belysning, material, gradient‑ eller bildfyllningar samt 3D‑text.

{{% alert color="primary" %}}
Denna artikel handlar om 3D‑formateringseffekter på PowerPoint‑former och -text. Den handlar inte om att infoga eller redigera fristående 3D‑modellfiler. När du exporterar en bild till ett bildformat, PDF eller HTML renderar Aspose.Slides dessa 3D‑effekter i den exporterade 2D‑utdata.
{{% /alert %}}

## **3D‑formateringskoncept**

Använd gränssnittet [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/)s [get_ThreeDFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_threedformat/)‑metod för att tillämpa 3D‑formatering på en form. Metoden returnerar [IThreeDFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/), som styr 3D‑scenen för den formen.

För text, använd gränssnittet [ITextFrameFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/)s [get_ThreeDFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/get_threedformat/)-metod. Detta tillämpar 3D‑formatering på textramen istället för formkroppen.

De viktigaste metoderna är:

| Metod | Vad den styr | När den ska användas |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/get_camera/) | Vypunkt, förinställd kameratyp, rotation, zoom och perspektiv. | Rotera objektet i 3D‑utrymme eller matcha en PowerPoint‑3D‑rotationsförinställning. |
| [get_LightRig](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/get_lightrig/) | Ljusförinställning, riktning och ljusrotation. | Ändra hur högdagrar och skuggor visas på 3D‑ytan. |
| [set_Material](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/set_material/) | Ytmaterial, t.ex. slätt, matt, plast eller metall. | Få samma geometri att se plattare, mjukare, glänsande eller metallisk ut. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Hur långt formen sträcker sig bakåt från dess framsida. | Omvandla en plan form till ett tydligt tjockt 3D‑objekt. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Färg på de extruderade sidorna. | Gör djupet synligt eller samordna sidofärgen med frontfyllningen. |
| [set_Depth](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/set_depth/) | Extra 3D‑djup som används av PowerPoint‑3D‑formatering. | Finjustera djup för former eller text, särskilt i kombination med fasning- och materialinställningar. |
| [get_BevelTop](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/get_beveltop/) och [get_BevelBottom](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Upphöjda eller runda kanter på front- och baksidorna. | Lägg till en mjukad eller formad kant istället för en skarp platt yta. |
| [get_ContourColor](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/get_contourcolor/) och [set_ContourWidth](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Kontur runt 3D‑objektet. | Betona objektets gräns i renderad utdata. |

## **Skapa en 3D‑form**

En form behöver vanligtvis fyra typer av inställningar innan den ser trovärdigt 3D‑utseende ut:

- Kamerainställningar, eftersom standardframsidan kan dölja extrusionen.
- Ljusinställningar, eftersom belysning gör ansiktena och sidorna läsbara.
- Materialinställningar, eftersom ytan påverkar hur ljus renderas.
- Extrusions- eller djupinställningar, eftersom en plan form behöver tjocklek.

Följande exempel skapar en rektangel, lägger till text på dess framsida, tillämpar 3D‑formatering, sparar presentationen som PPTX och renderar bilden till en PNG‑fil.

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

Den renderade bildspelet visar rektangeln som ett tjockt 3D‑block:

![Renderad blå 3D‑rektangel med vit 3D‑text på framsidan](img_01_01.png)

## **Rotera en form med kameran**

I PowerPoint konfigureras 3D‑rotation från panelen 3‑D‑Rotation. X‑, Y‑ och Z‑rotationsvärdena motsvarar den rotation du anger via kamera‑API:et.

![PowerPoint‑panelen 3‑D‑Rotation med X‑, Y‑ och Z‑rotationsvärden markerade](img_02_01.png)

I Aspose.Slides, ställ in kamratyp och rotation via [IThreeDFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/):

```cpp
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

Använd kameran när du behöver ändra hur betraktaren ser objektet. Den ändrar inte 2D‑formgeometrin på bilden. Den ändrar 3D‑vypunkten som används av PowerPoint och av Aspose.Slides vid rendering.

## **Lägg till extrusion och djup**

Extrusion får en form att se tjock ut genom att den sträcker sig bakom framsidan. I PowerPoint anger djupkontrollen denna synliga tjocklek, och färgkontrollen anger färgen på sidoytorna.

![PowerPoint‑djupkontroller mappade till extrusion‑färg och extrusion‑höjd‑egenskaper](img_02_02.png)

Ställ in [set_ExtrusionHeight](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/set_extrusionheight/) för tjockleken och [get_ExtrusionColor](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) för sidofärgen:

```cpp
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Använd [set_Depth](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/set_depth/) när du behöver arbeta direkt med PowerPoints djupvärde eller kombinera djup med fasning, material och texteffekter. I många formscenarier är `set_ExtrusionHeight` den tydligare inställningen eftersom den direkt uttrycker den synliga extrusionen.

## **Använd gradient‑ eller bildfyllningar med 3D‑effekter**

3D‑formatering är oberoende av formens fyllning. Du kan använda en enfärgad färg, gradient, mönster eller bildfyllning på framsidan och fortfarande använda samma kamera, ljus, material och extrusionsinställningar.

Detta exempel tillämpar en gradientfyllning på formen och en mörkare extrusionsfärg på sidorna:

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

Den renderade utskriften behåller gradienten på framsidan och renderar extrusionen separat:

![Renderad 3D‑rektangel med en blå‑till‑orange gradientfyllning och orange extrusion](img_02_03.png)

För att använda en bildfyllning istället, lägg till bilden i presentationen och tilldela den till formens fyllning:

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

Bilden renderas på framsidan, medan extrusionen renderas som 3D‑sidoyta:

![Renderad 3D‑rektangel med ett fotofyllning på framsidan och orange extrusion](img_02_04.png)

## **Tillämpa 3D‑formatering på text**

Formens 3D‑formatering påverkar formkroppen. Textens 3D‑formatering påverkar textramen. Detta är användbart för WordArt‑liknande effekter där bokstäverna själva behöver extrusion, material, belysning och kamerainställningar.

Följande exempel skapar text med en mönsterfyllning, tillämpar en WordArt‑transform och konfigurerar 3D‑inställningarna på [ITextFrameFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/):

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

Texten renderas som krökt, extruderad 3D‑bokstavsgrafik:

![Renderad 3D‑text med en bågformad WordArt‑transform, orange mönsterfyllning och mörk extrusion](img_02_05.png)

## **Export‑ och renderingsbeteende**

Aspose.Slides bevarar 3D‑formatering vid sparande till PowerPoint‑format som PPTX. Vid rendering eller export till fasta layout‑format rasteriseras 3D‑scenen eller ritas in i utdata som ett 2D‑resultat. Detta gäller när du renderar bilder till [PNG](/slides/sv/cpp/convert-powerpoint-to-png/), exporterar till [PDF](/slides/sv/cpp/convert-powerpoint-to-pdf/), exporterar till [HTML](/slides/sv/cpp/convert-powerpoint-to-html/), eller genererar ramar för [video conversion](/slides/sv/cpp/convert-powerpoint-to-video/).

- Exporterade bilder och PDF‑filer är inte interaktiva. Objektet kan inte roteras av betraktaren efter export.
- Det slutgiltiga utseendet beror på kombinationen av kamera, ljusrigg, material, extrusion, fyllning och bildskalning.
- Om du behöver inspektera ärvda eller temabaserade formateringsvärden, läs de [effective shape properties](/slides/sv/cpp/shape-effective-properties/).
- Vissa utdataformat kan inte lagra redigerbar PowerPoint‑3D‑formatering. I de formaten renderas det visuella resultatet istället för att bevaras som redigerbara 3D‑inställningar.

## **FAQ**

**Kan Aspose.Slides skapa interaktiva 3D‑presentationer?**

Aspose.Slides skapar och renderar PowerPoint‑3D‑effekter för former och text. Det gör inte exporterade bilder, PDF‑filer eller HTML‑sidor till interaktiva 3D‑scener som en betraktare kan rotera. I PPTX förblir 3D‑formateringen redigerbar i PowerPoint där formatet stödjer det.

**Vad är skillnaden mellan en 3D‑modell och en 3D‑effekt?**

En 3D‑modell är ett separat 3D‑objekt som infogas i en presentation. En 3D‑effekt är formatering som tillämpas på en vanlig PowerPoint‑form eller -text, såsom rotation, extrusion, fasning, belysning och material. Denna artikel behandlar 3D‑effekter.

**Vilka inställningar krävs för en synlig 3D‑form?**

I minsta fall måste du sätta en kamerarotation och antingen extrusion eller djup. I praktiken bör du också sätta en ljusrigg och material så att de renderade ytorna har tydliga högdagrar och skuggor.

**Kan jag tillämpa 3D‑effekter på både former och text?**

Ja. Använd [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/) för formkroppen och [ITextFrameFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/) för text.

**Kommer 3D‑effekter att visas vid export till bilder, PDF, HTML eller videoramar?**

Ja. Aspose.Slides renderar 3D‑effekter när den producerar bildspelet, PDF‑utdata, HTML‑utdata och ramar som används för videokonvertering. Den exporterade utdata innehåller den renderade utsikten, inte ett redigerbart 3D‑objekt.

**Kan jag läsa de slutliga 3D‑värdena efter att arv och temainställningar har tillämpats?**

Ja. Använd de effektiva formaterings‑API:erna som beskrivs i [Shape Effective Properties](/slides/sv/cpp/shape-effective-properties/) för att läsa slutlig kamera, ljusrigg, fasning och relaterade 3D‑värden.