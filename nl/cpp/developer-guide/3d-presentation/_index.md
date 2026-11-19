---
title: 3D-effecten maken in presentaties met C++
linktitle: 3D-presentatie
type: docs
weight: 232
url: /nl/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D-presentatie
- 3D-rotatie
- 3D-diepte
- 3D-extrusie
- 3D-verloop
- 3D-tekst
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Pas 3D‑effecten toe en render ze voor PowerPoint‑vormen en -tekst in C++ met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D‑tekst."
---
## **Overzicht**

Met Aspose.Slides voor C++ kunt u PowerPoint‑achtige 3D‑opmaak voor vormen en tekst maken, bewerken, behouden en renderen. Dit artikel behandelt 3D‑effecten zoals draaien, extrusie, afschuiningen, verlichting, materiaal, verloop‑ of afbeeldingsvullingen en 3D‑tekst.

{{% alert color="info" title="Note" %}}
Dit artikel gaat over 3D‑opmaak‑effecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van zelfstandige 3D‑modellen. Wanneer u een dia exporteert naar een afbeelding, PDF of HTML, rendert Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑output.
{{% /alert %}}

## **Concepten van 3D‑opmaak**

Gebruik de [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) methode om 3D‑opmaak op een vorm toe te passen. De methode retourneert [IThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/), die de 3D‑scene voor die vorm beheert.

Voor tekst gebruikt u de [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) methode. Deze past 3D‑opmaak toe op het tekstkader in plaats van op het vormlichaam.

De belangrijkste methoden zijn:

| Methode | Wat het regelt | Wanneer te gebruiken |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) | Kijkpunt, vooraf ingestelde cameratype, rotatie, zoom en perspectief. | Draai het object in 3D‑ruimte of stem een PowerPoint‑3D‑rotatie‑preset af. |
| [get_LightRig](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_lightrig/) | Licht‑preset, richting en lichtrotatie. | Verander hoe hoogtepunten en schaduwen verschijnen op het 3D‑oppervlak. |
| [set_Material](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_material/) | Oppervlakte‑materiaal, zoals vlak, mat, kunststof of metaal. | Laat dezelfde geometrie er vlakker, zachter, glanzender of metallic uitzien. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Hoe ver de vorm achterwaarts uitstrekt vanaf het voorste vlak. | Zet een platte vorm om in een zichtbaar dik 3D‑object. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Kleur van de geëxtrudeerde zijkanten. | Maak diepte zichtbaar of stem de kleur van de zijkant af op de voorvulling. |
| [set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) | Extra 3D‑diepte gebruikt door PowerPoint‑3D‑opmaak. | Fijn afstellen van diepte voor vormen of tekst, vooral in combinatie met afschuinings‑ en materiaalinstellingen. |
| [get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) and [get_BevelBottom](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Verhoogde of afgeronde randen op de voor- en achterkant. | Voeg een verzachte of gevormde rand toe in plaats van een scherpe vlakke rand. |
| [get_ContourColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_contourcolor/) and [set_ContourWidth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Omtrek rond het 3D‑object. | Benadruk de grenzen van het object in de gerenderde output. |

## **Maak een 3D‑vorm**

Een vorm heeft meestal vier soorten instellingen nodig voordat hij overtuigend 3D lijkt:

- Camera‑instellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.
- Licht‑instellingen, omdat verlichting de vlakken en zijden leesbaar maakt.
- Materiaal‑instellingen, omdat het oppervlak invloed heeft op hoe licht wordt weergegeven.
- Extrusie‑ of diepte‑instellingen, omdat een platte vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan het voorste vlak en past 3D‑opmaak toe. De camerarotatiewaarden staan in graden en de extrusiehoogte is 100 punten. Het voorbeeld rendert de dia naar een PNG‑afbeelding op het dubbele van de standaardafmetingen en slaat de presentatie op als PPTX.

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

De gerenderde dia‑afbeelding toont de rechthoek als een dikke 3D‑blok:

![Gerenderde blauwe 3D‑rechthoek met witte 3D‑tekst op het voorste vlak](img_01_01.png)

## **Draai een vorm met de camera**

In PowerPoint wordt 3D‑rotatie geconfigureerd via het paneel 3‑D Rotatie. De X‑, Y‑ en Z‑rotatiewaarden komen overeen met de rotatie die u via de camera‑API instelt.

![PowerPoint‑paneel 3‑D Rotatie met gemarkeerde X‑, Y‑ en Z‑rotatiewaarden](img_02_01.png)

In Aspose.Slides krijgt u toegang tot de camera via [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/). Dit voorbeeld maakt een rechthoek, selecteert een orthografisch vooraanzicht en stelt de X‑, Y‑ en Z‑rotaties in op respectievelijk 20, 30 en 40 graden. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

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

Gebruik de camera wanneer u de weergave van het object voor de kijker wilt wijzigen. Het verandert de 2D‑vormgeometrie op de dia niet. Het verandert het 3D‑viewpoint dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

### **Kopieer camera‑oriëntatie van een sjabloon‑vorm**

Om de camera‑oriëntatie van een sjabloon‑vorm te evenaren, lees u de preset met [get_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/get_cameratype/) en past u deze toe met [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/). Het voorbeeld opent `template.pptx` en kopieert de camera‑oriëntatie van de eerste vorm op de eerste dia naar de tweede vorm. Beide vormen hebben al 3D‑verlichting, en de tweede vorm heeft geen expliciete camera‑rotatie.

[GetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/getrotation/) retourneert de hoeken in graden. Index `0` is breedtegraad, index `1` is lengtegraad, en index `2` is rotatie. Geef de hoeken in die volgorde door aan [SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/). Als de bron geen expliciete rotatie heeft, retourneert `GetRotation` een null‑pointer, dus laat u de hoeken van de tweede vorm ongedefinieerd. Een expliciete rotatie van `(0, 0, 0)` geeft een array met drie nullen terug en moet worden gekopieerd.

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

Wanneer u `camera-copy.pptx` opnieuw opent in PowerPoint, heeft de pijl aan de rechterkant dezelfde camera‑preset en rotatie als de rechthoek aan de linkerkant. Beide vormen gebruiken dezelfde verlichting en extrusiediepte.

![Een blauwe 3D‑rechthoek en een rechts‑wijzende pijl met overeenkomende camera‑oriëntatie, bekeken van boven en van rechts](camera-orientation.png)

## **Voeg extrusie en diepte toe**

Extrusie laat een vorm dikker lijken door deze achter het voorste vlak uit te breiden. In PowerPoint bepaalt de diepte‑instelling deze zichtbare dikte, en de kleur‑instelling bepaalt de kleur van de zijvlakken.

![PowerPoint‑diepte‑instellingen gekoppeld aan extrusiekleur‑ en extrusiehoogte‑eigenschappen](img_02_02.png)

Stel [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) in voor de dikte en [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) voor de kleur van de zijkanten. Dit voorbeeld geeft een rechthoek een extrusie van 100 punten met paarse zijkanten en draait de camera om de dikte zichtbaar te maken. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

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

De [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) methode stelt de diepte van een 3D‑vorm in. De [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) methode regelt de hoogte van het extrusie‑effect, zoals in dit voorbeeld wordt getoond.

## **Gebruik verloop‑ of afbeelding‑vullingen met 3D‑effecten**

3D‑opmaak staat los van de vorm‑vulling. U kunt een effen kleur, een verloop, een patroon of een afbeelding‑vulling op het voorste vlak toepassen en toch dezelfde camera‑, licht‑, materiaal‑ en extrusie‑instellingen gebruiken.

Dit voorbeeld past een blauw‑naar‑oranje verloop toe op het voorste vlak en een donkeroranje kleur op de extrusie van 150 punten. De verloopstops bij 0 en 100 markeren respectievelijk het begin en einde van het verloop. De camerarotatiewaarden staan in graden. De dia wordt gerenderd naar een PNG‑afbeelding op het dubbele van de standaardafmetingen:

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

De gerenderde uitvoer behoudt het verloop op het voorste vlak en rendert de extrusie afzonderlijk:

![Gerenderde 3D‑rechthoek met een blauw‑naar‑oranje verloopvulling en oranje extrusie](img_02_03.png)

Om in plaats daarvan een afbeelding‑vulling te gebruiken, voegt u de afbeelding toe aan de presentatie en koppelt u deze aan de vorm‑vulling. Dit voorbeeld vereist een bestaand bestand met de naam "image.jpg" in de werkmap. Het strekt de afbeelding uit om de rechthoek te vullen, past een extrusie van 150 punten toe en stelt de camerarotatie in graden in. Het configureert de vorm in het geheugen zonder een bestand op te slaan of te renderen:

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

De afbeelding wordt gerenderd op het voorste vlak, terwijl de extrusie wordt gerenderd als het 3D‑zijvlak:

![Gerenderde 3D‑rechthoek met een foto‑vulling op het voorste vlak en oranje extrusie](img_02_04.png)

## **Pas 3D‑opmaak toe op tekst**

3D‑opmaak van een vorm beïnvloedt het vormlichaam. 3D‑opmaak van tekst beïnvloedt het tekstkader. Dit is handig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een oranje‑en‑wit rasterpatroon, past een opwaartse boog toe en configureert 3D‑instellingen via [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/). De extrusiehoogte en diepte staan in punten en de lichtrotatie in graden. De vorm‑vulling en -omtrek zijn verborgen zodat alleen de tekst zichtbaar is. Het voorbeeld rendert een PNG‑afbeelding op het dubbele van de standaarddia‑afmetingen en slaat de presentatie op als PPTX:

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

De tekst wordt gerenderd als gebogen, geëxtrudeerde 3D‑letters:

![Gerenderde 3D‑tekst met een gebogen WordArt‑transformatie, oranje patroonvulling en donkere extrusie](img_02_05.png)

## **Houd tekst plat op een 3D‑vorm**

Om tekst leesbaar te houden terwijl de 3D‑uiterlijk van een vorm behouden blijft, roept u [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_keeptextflat/) aan via [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_textframeformat/). Wanneer de waarde `true` is, blijft de tekst buiten de 3D‑scene. Wanneer deze `false` is, neemt de tekst deel aan de scene en volgt hij de 3D‑oriëntatie.

Deze instelling verwijdert de 3D‑opmaak van de vorm niet: de camera, verlichting, materiaal en extrusie blijven geconfigureerd via [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/). Het verschilt ook van gewone rotatie. [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) roteert de vorm in het dia‑vlak, terwijl [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) de aangepaste rotatie van de tekst binnen de begrenzende box regelt. Tekst buiten de 3D‑scene houden reset geen van beide hoeken.

Het volgende zelfstandige voorbeeld maakt een blauwe rechthoek met tekst en kloont deze naast de originele. Beide vormen hebben dezelfde 3D‑opmaak; alleen de tekstopstelling verschilt: `false` links en `true` rechts. De camera‑hoeken staan in graden en de extrusiehoogte is 40 punten. Het voorbeeld slaat de presentatie op als PPTX en rendert de vergelijkingsdia naar PNG op het dubbele van de standaardafmetingen.

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

Aan de linkerkant volgt de tekst de 3D‑oriëntatie. Aan de rechterkant blijft hij plat en beter leesbaar. Beide rechthoeken behouden dezelfde zichtbare extrusie en 3D‑oriëntatie.

![Zij‑aan‑zij 3D‑rechthoeken: KeepTextFlat is false links en true rechts](keep_text_flat.png)

## **Export‑ en rendergedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan naar PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑layoutformaten wordt de 3D‑scene gerasterd of in de uitvoer getekend als een 2D‑resultaat. Dit geldt wanneer u dia's rendert naar [PNG](/slides/nl/cpp/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/cpp/convert-powerpoint-to-html/), of frames genereert voor [video conversion](/slides/nl/cpp/convert-powerpoint-to-video/).

- Exporteerde afbeeldingen en PDF's zijn niet interactief. Het object kan na export niet door de kijker worden gedraaid.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, licht‑rig, materiaal, extrusie, vulling en dia‑schaling.
- Als u geërfde of thema‑gebaseerde opmaakwaarden wilt inspecteren, lees dan de [effectieve vormeigenschappen](/slides/nl/cpp/shape-effective-properties/).
- Sommige uitvoerformaten kunnen bewerkbare PowerPoint‑3D‑opmaak niet opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**  
Aspose.Slides maakt en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt geen geëxporteerde afbeeldingen, PDF's of HTML‑pagina's tot interactieve 3D‑scènes die een kijker kan draaien. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint wanneer het formaat dit ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**  
Een 3D‑model is een afzonderlijk 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die op een gewone PowerPoint‑vorm of -tekst wordt toegepast, zoals rotatie, extrusie, afschuining, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?**  
Minstens moet u een camera‑rotatie en ofwel extrusie of diepte instellen. In de praktijk stelt u ook een licht‑rig en materiaal in zodat de gerenderde vlakken duidelijke hooglichten en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**  
Ja. Gebruik [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) voor het vormlichaam en [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) voor tekst.

**Zullen 3D‑effecten verschijnen bij exporteren naar afbeeldingen, PDF, HTML of video‑frames?**  
Ja. Aspose.Slides rendert 3D‑effecten bij het maken van dia‑afbeeldingen, PDF‑output, HTML‑output en frames die worden gebruikt voor videoconversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de uiteindelijke 3D‑waarden lezen nadat overerving en thema‑instellingen zijn toegepast?**  
Ja. Gebruik de effectieve opmaak‑API's beschreven in [Effectieve vormeigenschappen](/slides/nl/cpp/shape-effective-properties/) om de uiteindelijke camera‑, licht‑rig‑, afschuining‑ en gerelateerde 3D‑waarden te lezen.