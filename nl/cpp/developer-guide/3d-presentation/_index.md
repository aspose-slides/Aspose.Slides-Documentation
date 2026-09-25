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
- 3D-gradient
- 3D-tekst
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Pas 3D-effecten toe en render ze voor PowerPoint-vormen en -tekst in C++ met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D-tekst."
---
## **Overzicht**

Aspose.Slides for C++ kan 3D-opmaak in PowerPoint-stijl maken, bewerken, behouden en renderen voor vormen en tekst. Dit artikel behandelt 3D-effecten zoals draaien, extrusie, schuine randen, verlichting, materiaal, gradient- of afbeeldingvullingen, en 3D-tekst.

{{% alert color="info" title="Note" %}}
Dit artikel gaat over 3D-opmaak effecten op PowerPoint-vormen en -tekst. Het gaat niet over het invoegen of bewerken van afzonderlijke 3D-modelbestanden. Wanneer je een dia exporteert naar een afbeelding, PDF of HTML, rendert Aspose.Slides die 3D-effecten in de geëxporteerde 2D-uitvoer.
{{% /alert %}}

## **Concepten voor 3D-opmaak**

Gebruik de [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_threedformat/) methode om 3D-opmaak op een vorm toe te passen. De methode retourneert [IThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/), die de 3D-scène voor die vorm beheert.

Voor tekst, gebruik de [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/get_threedformat/) methode. Deze past 3D-opmaak toe op het tekstvak in plaats van op het lichaam van de vorm.

De belangrijkste methoden zijn:

| Methode | Wat het regelt | Wanneer te gebruiken |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_camera/) | Kijkpunt, vooraf ingestelde cameratype, rotatie, zoom en perspectief. | Draai het object in 3D-ruimte of stem overeen met een PowerPoint 3D-rotatiepreset. |
| [get_LightRig](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_lightrig/) | Lichtpreset, richting en lichtrotatie. | Verander hoe highlights en schaduwen verschijnen op het 3D-oppervlak. |
| [set_Material](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/set_material/) | Oppervlaktermateriaal, bijvoorbeeld vlak, mat, plastic of metaal. | Laat dezelfde geometrie er vlakker, zachter, glanzender of meer metallic uitzien. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Hoe ver de vorm naar achteren uitsteekt vanaf het voorste vlak. | Maak van een vlakke vorm een duidelijk dikke 3D-object. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Kleur van de uitgeschoten zijden. | Maak diepte zichtbaar of stem de zijkleur af op de voorste vulling. |
| [set_Depth](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/set_depth/) | Extra 3D-diepte gebruikt door PowerPoint 3D-opmaak. | Fijn afstellen van de diepte voor vormen of tekst, vooral in combinatie met bevel- en materiaalinstellingen. |
| [get_BevelTop](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_beveltop/) en [get_BevelBottom](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Verhoogde of afgeronde randen op het voor- en achtervlak. | Voeg een verzachte of gevormde rand toe in plaats van een scherpe vlakke rand. |
| [get_ContourColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_contourcolor/) en [set_ContourWidth](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Omtrek rond het 3D-object. | Benadruk de objectgrens in de gerenderde uitvoer. |

## **Een 3D‑vorm maken**

Een vorm heeft meestal vier soorten instellingen nodig voordat hij overtuigend 3D lijkt:

- Camerainstellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.
- Lichtinstellingen, omdat verlichting de vlakken en zijden leesbaar maakt.
- Materiaalinstellingen, omdat het oppervlak beïnvloedt hoe licht wordt weergegeven.
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

De gerenderde dia-afbeelding toont de rechthoek als een dikke 3D‑blok:

![Render van blauwe 3D-rechthoek met witte 3D-tekst op het voorste vlak](img_01_01.png)

## **Een vorm roteren met de camera**

In PowerPoint wordt 3D-rotatie geconfigureerd via het paneel 3‑D Rotatie. De X-, Y- en Z-rotatiewaarden komen overeen met de rotatie die je instelt via de camera‑API.

![PowerPoint 3‑D Rotatie paneel met gemarkeerde X-, Y- en Z-rotatiewaarden](img_02_01.png)

In Aspose.Slides, krijg je toegang tot de camera via [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_camera/). Dit voorbeeld maakt een rechthoek, selecteert een orthografisch vooraanzicht, en stelt de X-, Y- en Z-rotaties in op respectievelijk 20, 30 en 40 graden. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

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

Gebruik de camera wanneer je wil veranderen hoe de kijker het object ziet. Het verandert niet de 2D-vormgeometrie op de dia. Het verandert het 3D‑kijkpunt dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

## **Extrusie en diepte toevoegen**

Extrusie maakt een vorm dikker door deze achter het voorste vlak uit te breiden. In PowerPoint bepaalt de diepte‑instelling deze zichtbare dikte, en de kleur‑instelling bepaalt de kleur van de zijvlakken.

![PowerPoint diepte‑controles gekoppeld aan extrusiekleur‑ en extrusiehoogte‑eigenschappen](img_02_02.png)

Stel [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/set_extrusionheight/) in voor de dikte en [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) voor de zijkleur. Dit voorbeeld geeft een rechthoek een extrusie van 100 punten met paarse zijkanten en roteert de camera om de dikte te onthullen. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

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

De [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/set_depth/) methode bepaalt de diepte van een 3D‑vorm. De [set_ExtrusionHeight](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/set_extrusionheight/) methode regelt de hoogte van het extrusie‑effect, zoals in dit voorbeeld getoond.

## **Gradient‑ of afbeeldingvullingen gebruiken met 3D‑effecten**

3D-opmaak staat los van de vormvulling. Je kunt een effen kleur, gradient, patroon of afbeeldingvulling op het voorste vlak toepassen en toch dezelfde camera-, licht‑, materiaal‑ en extrusie‑instellingen gebruiken.

Dit voorbeeld past een blauw‑naar‑oranje gradient toe op het voorste vlak en een donkere oranje kleur op de 150‑punt extrusie. De gradient‑stops op 0 en 100 markeren het begin en einde van de gradient. De camerarotatiewaarden staan in graden. De dia wordt gerenderd naar een PNG‑afbeelding op het dubbele van de standaardafmetingen:

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

De gerenderde uitvoer behoudt de gradient op het voorste vlak en rendert de extrusie apart:

![Render van 3D-rechthoek met een blauw‑naar‑oranje gradientvulling en oranje extrusie](img_02_03.png)

Om in plaats daarvan een afbeeldingvulling te gebruiken, voeg je de afbeelding toe aan de presentatie en wijs je deze toe aan de vormvulling. Dit voorbeeld vereist een bestaand bestand met de naam "image.jpg" in de werkmap. Het rekent de afbeelding uit om de rechthoek te vullen, past een extrusie van 150 punten toe en stelt de camerarotatie in graden in. Het configureert de vorm in het geheugen zonder een bestand op te slaan of te renderen:

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

De afbeelding wordt gerenderd op het voorste vlak, terwijl de extrusie wordt weergegeven als het 3D‑zijvlak:

![Render van 3D-rechthoek met een foto‑vulling op het voorste vlak en oranje extrusie](img_02_04.png)

## **3D‑opmaak toepassen op tekst**

3D-opmaak van een vorm beïnvloedt het lichaam van de vorm. 3D-opmaak van tekst beïnvloedt het tekstvak. Dit is nuttig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een oranje‑en‑witte rasterpatroon, past een opwaartse boog toe en configureert 3D‑instellingen via [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/get_threedformat/). De extrusiehoogte en diepte staan in punten, en de lichtrotatie in graden. De vormvulling en omtrek zijn verborgen zodat alleen de tekst zichtbaar is. Het voorbeeld rendert een PNG‑afbeelding op het dubbele van de standaard dia‑afmetingen en slaat de presentatie op als PPTX:

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

![Render van 3D-tekst met een gebogen WordArt‑transformatie, oranje patroonvulling en donkere extrusie](img_02_05.png)

## **Tekst plat houden op een 3D‑vorm**

Om tekst leesbaar te houden terwijl je de 3D‑uitstraling van een vorm behoudt, roep je [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/set_keeptextflat/) aan via [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/get_textframeformat/). Wanneer de waarde `true` is, blijft de tekst buiten de 3D‑scene. Wanneer deze `false` is, neemt de tekst deel aan de scene en volgt hij de 3D‑oriëntatie.

Deze instelling verwijdert de 3D‑opmaak van de vorm niet: de camera, verlichting, materiaal en extrusie blijven geconfigureerd via [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_threedformat/). Het verschilt ook van gewone rotatie. [IShape::set_Rotation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/set_rotation/) roteert de vorm in het dia‑vlak, terwijl [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/set_rotationangle/) de aangepaste rotatie van de tekst binnen het omvattende vak regelt. Tekst buiten de 3D‑scene houden reset geen van beide hoeken.

Het volgende zelfstandige voorbeeld maakt een blauwe rechthoek met tekst en kloont deze naast het origineel. Beide vormen hebben dezelfde 3D‑opmaak; alleen de tekstopstelling verschilt: `false` links en `true` rechts. De camera‑hoeken staan in graden en de extrusiehoogte is 40 punten. Het voorbeeld slaat de presentatie op als PPTX en rendert de vergelijkingsdia naar PNG op het dubbele van de standaardafmetingen.

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

Links volgt de tekst de 3D‑oriëntatie. Rechts blijft hij plat en makkelijker leesbaar. Beide rechthoeken behouden dezelfde zichtbare extrusie en 3D‑oriëntatie.

![Zij‑aan‑zij 3D-rechthoeken: KeepTextFlat is false aan de linkerkant en true aan de rechterkant](keep_text_flat.png)

## **Export‑ en rendergedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan naar PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑lay-outformaten wordt de 3D‑scene gerasterd of getekend in de uitvoer als een 2D‑resultaat. Dit geldt wanneer je dia's rendert naar [PNG](/slides/nl/cpp/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/cpp/convert-powerpoint-to-html/), of frames genereert voor [videoconversie](/slides/nl/cpp/convert-powerpoint-to-video/).

Houd deze punten in gedachten:

- Geëxporteerde afbeeldingen en PDF's zijn niet interactief. Het object kan na export niet door de kijker worden gedraaid.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, licht‑rig, materiaal, extrusie, vulling en dia‑schaling.
- Als je geërfde of themagebaseerde opmaakwaarden wilt inspecteren, lees je de [effectieve vormeigenschappen](/slides/nl/cpp/shape-effective-properties/).
- Sommige uitvoerformaten kunnen geen bewerkbare PowerPoint 3D‑opmaak opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**

Aspose.Slides maakt en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt de geëxporteerde afbeeldingen, PDF's of HTML‑pagina's niet tot interactieve 3D‑scènes die een kijker kan draaien. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint waar het formaat dit ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**

Een 3D‑model is een afzonderlijk 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak toegepast op een gewone PowerPoint‑vorm of -tekst, zoals draaien, extrusie, bevel, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?**

Minimaal moet je een camerarotatie en ofwel extrusie of diepte instellen. In de praktijk stel je ook een licht‑rig en materiaal in zodat de gerenderde vlakken duidelijke highlights en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**

Ja. Gebruik [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_threedformat/) voor het vormlichaam en [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/get_threedformat/) voor tekst.

**Zullen 3D‑effecten verschijnen bij export naar afbeeldingen, PDF, HTML of video‑frames?**

Ja. Aspose.Slides rendert 3D‑effecten bij het produceren van dia‑afbeeldingen, PDF‑output, HTML‑output en frames die worden gebruikt voor videoconversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de definitieve 3D‑waarden lezen nadat overerving en themainstellingen zijn toegepast?**

Ja. Gebruik de effectieve opmaak‑API’s beschreven in [Shape Effective Properties](/slides/nl/cpp/shape-effective-properties/) om de uiteindelijke camera-, licht‑rig-, bevel‑ en gerelateerde 3D‑waarden te lezen.