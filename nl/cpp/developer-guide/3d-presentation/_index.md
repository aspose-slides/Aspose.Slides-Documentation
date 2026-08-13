---
title: Maak 3D-effecten in presentaties met C++
linktitle: 3D-presentatie
type: docs
weight: 232
url: /nl/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D presentatie
- 3D rotatie
- 3D diepte
- 3D extrusie
- 3D verloop
- 3D tekst
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Pas 3D-effecten toe en render deze voor PowerPoint-vormen en -tekst in C++ met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D-tekst."
---
## **Overzicht**

Aspose.Slides for C++ kan 3D‑opmaak in PowerPoint‑stijl maken, bewerken, behouden en weergeven voor vormen en tekst. Dit artikel behandelt 3D‑effecten zoals rotatie, extrusie, schuine randen, verlichting, materiaal, verloop‑ of afbeeldingsvullingen en 3D‑tekst.

{{% alert color="info" %}}
Dit artikel gaat over 3D‑opmaak‑effecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van afzonderlijke 3D‑modellen. Wanneer je een dia exporteert naar een afbeelding, PDF of HTML, renderen Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑output.
{{% /alert %}}

## **Concepten van 3D‑opmaak**

Gebruik de interface [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/) en de methode [get_ThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_threedformat/) om 3D‑opmaak toe te passen op een vorm. De methode retourneert [IThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/), die de 3D‑scene voor die vorm bestuurt.

Voor tekst gebruik je de interface [ITextFrameFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/) en de methode [get_ThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/get_threedformat/). Deze past 3D‑opmaak toe op het tekstkader in plaats van op het vormlichaam.

De belangrijkste methoden zijn:

| Methode | Wat het controleert | Wanneer te gebruiken |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_camera/) | Kijkpunt, voorinstelling cameratype, rotatie, zoom en perspectief. | Draai het object in 3D‑ruimte of stem overeen met een PowerPoint‑3D‑rotatie‑preset. |
| [get_LightRig](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_lightrig/) | Lichtvoorinstelling, richting en lichtrotatie. | Wijzig hoe hooglichten en schaduwen verschijnen op het 3D‑oppervlak. |
| [set_Material](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/set_material/) | Oppervlaktmateriaal, zoals plat, mat, plastic of metaal. | Laat dezelfde geometrie er platter, zachter, glanzender of metaalachtig uitzien. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Hoe ver de vorm naar achteren uitstrekt vanaf de voorzijde. | Maak van een platte vorm een duidelijk dik 3D‑object. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Kleur van de geëxtrudeerde zijden. | Maak diepte zichtbaar of stem de kleur van de zijkanten af op de voorvulling. |
| [set_Depth](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/set_depth/) | Extra 3D‑diepte die door PowerPoint‑3D‑opmaak wordt gebruikt. | Fijn afstemmen van diepte voor vormen of tekst, vooral samen met schuine randen en materiaalinstellingen. |
| [get_BevelTop](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_beveltop/) en [get_BevelBottom](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Verhoogde of afgeronde randen op de voor- en achtervlakken. | Voeg een verzachte of gevormde rand toe in plaats van een scherpe platte vlak. |
| [get_ContourColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_contourcolor/) en [set_ContourWidth](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Omtrek rond het 3D‑object. | Benadruk de objectgrens in de gerenderde uitvoer. |

## **Maak een 3D‑vorm**

Een vorm heeft doorgaans vier soorten instellingen nodig voordat hij overtuigend 3D uitziet:

- Camerainstellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.
- Lichtinstellingen, omdat verlichting de vlakken en zijkanten leesbaar maakt.
- Materiaalinstellingen, omdat het oppervlak bepaalt hoe licht wordt weergegeven.
- Extrusie‑ of diepte‑instellingen, omdat een platte vorm dikte nodig heeft.

Het onderstaande voorbeeld maakt een rechthoek, voegt tekst toe aan de voorzijde, past 3D‑opmaak toe, slaat de presentatie op als PPTX en rendert de dia naar een PNG‑afbeelding.

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

De gerenderde dia‑afbeelding toont de rechthoek als een dik 3D‑blok:

![Gerenderde blauwe 3D‑rechthoek met witte 3D‑tekst op de voorzijde](img_01_01.png)

## **Roteer een vorm met de camera**

In PowerPoint wordt 3D‑rotatie geconfigureerd via het paneel 3‑D‑rotatie. De X‑, Y‑ en Z‑rotatiewaarden komen overeen met de rotatie die je via de camera‑API instelt.

![PowerPoint‑paneel 3‑D‑rotatie met gemarkeerde X‑, Y‑ en Z‑rotatiewaarden](img_02_01.png)

In Aspose.Slides stel je het cameratype en de rotatie in via [IThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/):

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

Gebruik de camera wanneer je wilt wijzigen hoe de kijker het object ziet. Het verandert niet de 2D‑vormgeometrie op de dia. Het wijzigt het 3D‑kijkpunt dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

## **Voeg extrusie en diepte toe**

Extrusie laat een vorm dikker lijken door deze achter de voorzijde uit te breiden. In PowerPoint bepaalt de diepte‑instelling deze zichtbare dikte en de kleur‑instelling de kleur van de zijvlakken.

![PowerPoint‑diepte‑instellingen gekoppeld aan extrusiekleur‑ en extrusiehoogte‑eigenschappen](img_02_02.png)

Stel [set_ExtrusionHeight](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/set_extrusionheight/) in voor de dikte en [get_ExtrusionColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) voor de zijkleur:

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

Gebruik [set_Depth](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/set_depth/) wanneer je direct met de diepte‑waarde van PowerPoint wilt werken of diepte wilt combineren met schuine randen, materiaal en texteffecten. In veel vormscenario's is `set_ExtrusionHeight` de duidelijkere instelling omdat deze de zichtbare extrusie direct weergeeft.

## **Gebruik verloop‑ of afbeeldingsvullingen met 3D‑effecten**

3D‑opmaak staat los van de vormvulling. Je kunt een effen kleur, verloop, patroon of afbeeldingsvulling op de voorzijde toepassen en toch dezelfde camera‑, licht‑, materiaal‑ en extrusie‑instellingen gebruiken.

Dit voorbeeld past een verloopvulling toe op de vorm en een donkerdere extrusiekleur op de zijkanten:

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

![Gerenderde 3D‑rechthoek met een blauw‑naar‑oranje verloopvulling en oranje extrusie](img_02_03.png)

Om in plaats daarvan een afbeeldingsvulling te gebruiken, voeg je de afbeelding toe aan de presentatie en wijs je deze toe aan de vormvulling:

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

![Gerenderde 3D‑rechthoek met een foto‑vulling op de voorzijde en oranje extrusie](img_02_04.png)

## **Pas 3D‑opmaak toe op tekst**

3D‑opmaak van een vorm beïnvloedt het vormlichaam. 3D‑opmaak van tekst beïnvloedt het tekstkader. Dit is nuttig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camerainstellingen nodig hebben.

Het onderstaande voorbeeld maakt tekst met een patroonvulling, past een WordArt‑transformatie toe en configureert 3D‑instellingen op [ITextFrameFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/):

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

![Gerenderde 3D‑tekst met een gebogen WordArt‑transformatie, oranje patroonvulling en donkere extrusie](img_02_05.png)

## **Export‑ en rendergedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan naar PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑indelingsformaten wordt de 3D‑scene gerasterd of in de uitvoer getekend als een 2D‑resultaat. Dit geldt wanneer je dia's rendert naar [PNG](/slides/nl/cpp/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/cpp/convert-powerpoint-to-html/), of frames genereert voor [video‑conversie](/slides/nl/cpp/convert-powerpoint-to-video/).

Houd de volgende punten in gedachten:

- Geëxporteerde afbeeldingen en PDF's zijn niet interactief. Het object kan na export niet door de kijker worden gedraaid.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, lichtinstelling, materiaal, extrusie, vulling en dia‑schaling.
- Als je de geërfde of themagebaseerde opmaakwaarden wilt inspecteren, lees dan de [effectieve vormeigenschappen](/slides/nl/cpp/shape-effective-properties/).
- Sommige uitvoerformaten kunnen bewerkbare PowerPoint‑3D‑opmaak niet opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **Veelgestelde vragen**

### Kan Aspose.Slides interactieve 3D‑presentaties maken?

Aspose.Slides maakt en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt niet van geëxporteerde afbeeldingen, PDF's of HTML‑pagina's interactieve 3D‑scènes die een kijker kan draaien. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint waar het formaat dit ondersteunt.

### Wat is het verschil tussen een 3D‑model en een 3D‑effect?

Een 3D‑model is een afzonderlijk 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die wordt toegepast op een gewone PowerPoint‑vorm of -tekst, zoals rotatie, extrusie, schuine rand, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

### Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?

Minimaal moet je een camera‑rotatie en óf extrusie óf diepte instellen. In de praktijk stel je ook een licht‑rig en materiaal in zodat de gerenderde vlakken duidelijke hooglichten en schaduwen hebben.

### Kan ik 3D‑effecten toepassen op zowel vormen als tekst?

Ja. Gebruik [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/) voor het vormlichaam en [ITextFrameFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/) voor tekst.

### Zullen 3D‑effecten verschijnen bij het exporteren naar afbeeldingen, PDF, HTML of videoframes?

Ja. Aspose.Slides rendert 3D‑effecten bij het produceren van dia‑afbeeldingen, PDF‑output, HTML‑output en frames die worden gebruikt voor video‑conversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

### Kan ik de uiteindelijke 3D‑waarden lezen nadat erfelijkheid en themainstellingen zijn toegepast?

Ja. Gebruik de effectieve opmaak‑API's beschreven in [Shape Effective Properties](/slides/nl/cpp/shape-effective-properties/) om de uiteindelijke camera-, licht‑rig-, schuine‑rand‑ en gerelateerde 3D‑waarden te lezen.