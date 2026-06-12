---
title: Maak 3D-effecten in presentaties met C++
linktitle: 3D Presentatie
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
description: "Pas 3D-effecten toe en render ze voor PowerPoint-vormen en -tekst in C++ met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D-tekst."
---
## **Overzicht**

Aspose.Slides for C++ kan vormen en tekst 3D‑opmaak in PowerPoint‑stijl maken, bewerken, behouden en renderen. Dit artikel behandelt 3D‑effecten zoals rotatie, extrusie, afgeronde randen, verlichting, materiaal, verloop‑ of afbeeldingvullingen en 3D‑tekst.

{{% alert color="primary" %}}
Dit artikel gaat over 3D‑opmaak effecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van afzonderlijke 3D‑modelbestanden. Wanneer je een dia exporteert naar een afbeelding, PDF of HTML, rendert Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑uitvoer.
{{% /alert %}}

## **3D‑opmaakconcepten**

Gebruik de [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/) interface's [get_ThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_threedformat/) methode om 3D‑opmaak toe te passen op een vorm. De methode retourneert [IThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/), die de 3D‑scene voor die vorm beheert.

Voor tekst gebruik je de [ITextFrameFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/) interface's [get_ThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/get_threedformat/) methode. Deze past 3D‑opmaak toe op het tekstkader in plaats van op het vormlichaam.

De belangrijkste methoden zijn:

| Methode | Wat het regelt | Wanneer te gebruiken |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_camera/) | Kijkpunt, vooraf ingestelde cameratype, rotatie, zoom en perspectief. | Draai het object in 3D‑ruimte of stem overeen met een PowerPoint 3D‑rotatievoorinstelling. |
| [get_LightRig](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_lightrig/) | Lichtvoorinstelling, richting en lichtrotatie. | Verander hoe highlights en schaduwen verschijnen op het 3D‑oppervlak. |
| [set_Material](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/set_material/) | Oppervlaktmateriaal, zoals plat, mat, plastic of metaal. | Laat dezelfde geometrie er platter, zachter, glanzender of metallic uitzien. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Hoe ver de vorm zich naar achteren uitstrekt vanaf het voorvlak. | Maak van een platte vorm een zichtbaar dik 3D‑object. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Kleur van de uitgeschoven zijden. | Maak diepte zichtbaar of stem de kleur van de zijden af op de voorvulling. |
| [set_Depth](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/set_depth/) | Extra 3D‑diepte die door PowerPoint 3D‑opmaak wordt gebruikt. | Fijn afstemmen van diepte voor vormen of tekst, vooral in combinatie met bevel‑ en materiaalin­stellingen. |
| [get_BevelTop](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_beveltop/) en [get_BevelBottom](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Verhoogde of afgeronde randen op voor‑ en achtervlakken. | Voeg een verzachte of gevormde rand toe in plaats van een scherpe platte rand. |
| [get_ContourColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_contourcolor/) en [set_ContourWidth](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Omranding rond het 3D‑object. | Benadruk de objectgrens in de gerenderde output. |

## **Maak een 3D‑vorm**

Een vorm heeft meestal vier soorten instellingen nodig voordat deze overtuigend 3D lijkt:

- Camerainstellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.
- Lichtinstellingen, omdat verlichting de gezichten en zijkanten leesbaar maakt.
- Materiaalinstellingen, omdat het oppervlak beïnvloedt hoe licht wordt gerenderd.
- Extrusie‑ of diepte‑instellingen, omdat een platte vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan het voorvlak, past 3D‑opmaak toe, slaat de presentatie op als PPTX en rendert de dia naar een PNG‑afbeelding.

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

De gerenderde dia‑afbeelding toont de rechthoek als een dikke 3D‑blok:

![Gerenderde blauwe 3D‑rechthoek met witte 3D‑tekst op het voorvlak](img_01_01.png)

## **Draai een vorm met de camera**

In PowerPoint wordt 3D‑rotatie geconfigureerd via het 3‑D Rotatiepaneel. De X‑, Y‑ en Z‑rotatiewaarden komen overeen met de rotatie die je via de camera‑API instelt.

![PowerPoint 3‑D Rotatiepaneel met gemarkeerde X‑, Y‑ en Z‑rotatiewaarden](img_02_01.png)

In Aspose.Slides stel je het cameratype en de rotatie in via [IThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/):

```cpp
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

Gebruik de camera wanneer je moet wijzigen hoe de kijker het object ziet. Het verandert niet de 2D‑vormgeometrie op de dia. Het wijzigt het 3D‑kijkpunt dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

## **Voeg extrusie en diepte toe**

Extrusie maakt een vorm dikker door deze achter het voorvlak uit te breiden. In PowerPoint bepaalt de diepte‑instelling deze zichtbare dikte, en de kleur‑instelling bepaalt de kleur van de zijvlakken.

![PowerPoint diepte‑instellingen gekoppeld aan extrusiekleur‑ en extrusiehoogte‑eigenschappen](img_02_02.png)

Stel [set_ExtrusionHeight](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/set_extrusionheight/) in voor de dikte en [get_ExtrusionColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) voor de zijkleur:

```cpp
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Gebruik [set_Depth](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/set_depth/) wanneer je direct met de dieptewaarde van PowerPoint wilt werken of diepte wilt combineren met bevel, materiaal en texteffecten. In veel vormscenario's is `set_ExtrusionHeight` de duidelijkere instelling omdat deze de zichtbare extrusie direct uitdrukt.

## **Gebruik verloop‑ of afbeeldingvullingen met 3D‑effecten**

3D‑opmaak is onafhankelijk van de vormvulling. Je kunt een effen kleur, verloop, patroon of afbeeldingvulling toepassen op het voorvlak en toch dezelfde camera-, licht-, materiaal‑ en extrusie‑instellingen gebruiken.

Dit voorbeeld past een verloopvulling toe op de vorm en een donkerdere extrusiekleur op de zijkanten:

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

![Gerenderde 3D‑rechthoek met een blauw‑naar‑oranje verloopvulling en oranje extrusie](img_02_03.png)

Om in plaats daarvan een afbeeldingvulling te gebruiken, voeg je de afbeelding toe aan de presentatie en wijs je deze toe aan de vormvulling:

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

![Gerenderde 3D‑rechthoek met een foto‑vulling op het voorvlak en oranje extrusie](img_02_04.png)

## **Pas 3D‑opmaak toe op tekst**

Vorm‑3D‑opmaak beïnvloedt het vormlichaam. Tekst‑3D‑opmaak beïnvloedt het tekstkader. Dit is nuttig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een patroonvulling, past een WordArt‑transformatie toe, en configureert 3D‑instellingen op [ITextFrameFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/):

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

![Gerenderde 3D‑tekst met een gebogen WordArt‑transformatie, oranje patroonvulling en donkere extrusie](img_02_05.png)

## **Export‑ en rendergedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan naar PowerPoint‑formaten zoals PPTX. Bij renderen of exporteren naar vaste‑indeling formaten wordt de 3D‑scene gerasterd of in de output getekend als een 2D‑resultaat. Dit geldt wanneer je dia's rendert naar [PNG](/slides/nl/cpp/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/cpp/convert-powerpoint-to-html/), of frames genereert voor [video conversion](/slides/nl/cpp/convert-powerpoint-to-video/).

Houd deze punten in gedachten:

- Geëxporteerde afbeeldingen en PDF's zijn niet interactief. Het object kan na export niet door de kijker worden gedraaid.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, lichtrig, materiaal, extrusie, vulling en dia‑schaal.
- Als je geërfde of themagebaseerde opmaakwaarden wilt inspecteren, lees dan de [effectieve vormeigenschappen](/slides/nl/cpp/shape-effective-properties/).
- Sommige uitvoerformaten kunnen bewerkbare PowerPoint 3D‑opmaak niet opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**

Aspose.Slides maakt en rendert PowerPoint 3D‑effecten voor vormen en tekst. Het maakt geen geëxporteerde afbeeldingen, PDF's of HTML‑pagina's interactieve 3D‑scènes die een kijker kan draaien. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint wanneer het formaat dit ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**

Een 3D‑model is een afzonderlijk 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die wordt toegepast op een gewone PowerPoint‑vorm of -tekst, zoals rotatie, extrusie, bevel, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?**

Minimaal moet je een camera‑rotatie instellen en ofwel extrusie of diepte. In de praktijk stel je ook een lichtrig en materiaal in zodat de gerenderde gezichten duidelijke highlights en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**

Ja. Gebruik [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/) voor het vormlichaam en [ITextFrameFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/) voor tekst.

**Zullen 3D‑effecten verschijnen bij exporteren naar afbeeldingen, PDF, HTML of videoframes?**

Ja. Aspose.Slides rendert 3D‑effecten bij het produceren van dia‑afbeeldingen, PDF‑uitvoer, HTML‑uitvoer en frames die worden gebruikt voor video‑conversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de uiteindelijke 3D‑waarden lezen nadat overerving en themainstellingen zijn toegepast?**

Ja. Gebruik de effectieve opmaak‑API's beschreven in [effectieve vormeigenschappen](/slides/nl/cpp/shape-effective-properties/) om de uiteindelijke camera-, lichtrig-, bevel‑ en gerelateerde 3D‑waarden te lezen.