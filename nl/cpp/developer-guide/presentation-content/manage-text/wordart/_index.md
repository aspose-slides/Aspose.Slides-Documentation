---
title: Maak en pas WordArt-effecten toe in C++
linktitle: WordArt
type: docs
weight: 110
url: /nl/cpp/wordart/
keywords:
- WordArt
- WordArt maken
- WordArt-sjabloon
- WordArt-effect
- schaduw-effect
- weergave-effect
- gloeieffect
- WordArt-transformatie
- 3D-effect
- buitenste schaduw-effect
- binnenste schaduw-effect
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Maak en pas WordArt-effecten aan in Aspose.Slides voor C++. Deze stapsgewijze handleiding helpt ontwikkelaars om presentaties te verbeteren met professionele tekst in C++."
---
## **Overzicht**

WordArt-effecten stellen u in staat om visueel aantrekkelijke, gestileerde tekst toe te voegen aan uw PowerPoint‑presentaties. Met Aspose.Slides kunnen ontwikkelaars programmaticus WordArt maken, aanpassen en beheren, net als in Microsoft PowerPoint—zonder dat Office geïnstalleerd hoeft te zijn. Dit artikel geeft een overzicht van het werken met WordArt, inclusief hoe u teksttransformaties, opvulstijlen, contouren, schaduwen en andere opmaakopties toepast om de inhoud van uw presentatie expressiever en boeiender te maken. WordArt stelt u in staat om tekst als een grafisch object te behandelen. Het bestaat uit effecten of speciale aanpassingen die op tekst worden toegepast om deze aantrekkelijker of opvallender te maken.

## **Maak een eenvoudige WordArt‑sjabloon en pas deze toe op tekst**

**Gebruik Aspose.Slides** 

Eerst maken we een eenvoudige tekst met deze C++‑code: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

Vervolgens stellen we de letterhoogte van de tekst in op een hogere waarde om het effect beter zichtbaar te maken met deze code:

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**Gebruik Microsoft PowerPoint**

Ga naar het WordArt‑effectenmenu in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Via het menu aan de rechterkant kunt u een vooraf gedefinieerd WordArt‑effect kiezen. Via het menu aan de linkerkant kunt u de instellingen voor een nieuw WordArt specificeren. 

Dit zijn enkele van de beschikbare parameters of opties:

![todo:image_alt_text](image-20200930114015-3.png)

**Gebruik Aspose.Slides**

Hier passen we de SmallGrid‑patroonkleur toe op de tekst en voegen we een zwarte rand van 1‑punt breedte toe met deze code:

``` cpp 
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

De resulterende tekst:

![todo:image_alt_text](image-20200930114108-4.png)

## **Pas andere WordArt‑effecten toe**

**Gebruik Microsoft PowerPoint**

Via de interface van het programma kunt u deze effecten toepassen op tekst, een tekstdelen, vorm of een soortgelijk element:

![todo:image_alt_text](image-20200930114129-5.png)

Bijvoorbeeld, schaduw-, reflectie‑ en gloeieffecten kunnen op tekst worden toegepast; 3D‑formaat‑ en 3D‑rotatie‑effecten kunnen op een tekstdelen worden toegepast; de eigenschap Soft Edges kan op een Shape‑object worden toegepast (het heeft nog steeds effect wanneer geen 3D‑formaat‑eigenschap is ingesteld). 

### **Pas schaduweffecten toe op tekst**

Hier willen we alleen de eigenschappen van een tekst instellen. We passen het schaduweffect toe op een tekst met deze C++‑code:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(65);
outerShadowEffect->set_BlurRadius(4.73);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(2);
outerShadowEffect->set_SkewHorizontal(30);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

De Aspose.Slides‑API ondersteunt drie soorten schaduwen: OuterShadow, InnerShadow en PresetShadow. 

Met PresetShadow kunt u een schaduw op tekst toepassen (met vooraf ingestelde waarden). 

**Gebruik Microsoft PowerPoint**

In PowerPoint kunt u één type schaduw gebruiken. Hier is een voorbeeld:

![todo:image_alt_text](image-20200930114225-6.png)

**Gebruik Aspose.Slides**

Aspose.Slides stelt u in staat om twee soorten schaduwen tegelijk toe te passen: InnerShadow en PresetShadow.

Opmerkingen:

- Wanneer OuterShadow en PresetShadow samen worden gebruikt, wordt alleen het OuterShadow‑effect toegepast. 
- Als OuterShadow en InnerShadow gelijktijdig worden gebruikt, hangt het resulterende of toegepaste effect af van de PowerPoint‑versie. Bijvoorbeeld, in PowerPoint 2013 wordt het effect verdubbeld. In PowerPoint 2007 wordt echter het OuterShadow‑effect toegepast. 

### **Pas reflectie‑effecten toe**

We voegen een reflectie toe aan de tekst met dit C++‑voorbeeld:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```

### **Pas gloeieffecten toe**

We passen het gloeieffect toe op de tekst om deze te laten stralen of opvallend te maken met deze code:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

Het resultaat van de bewerking:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

U kunt de parameters voor schaduw, weergave en glow wijzigen. De eigenschappen van de effecten worden afzonderlijk ingesteld voor elk gedeelte van de tekst. 

{{% /alert %}} 

### **Gebruik transformaties in WordArt**

We gebruiken de set_Transform‑methode (toegepast op het volledige tekstblok) met deze code:

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

Het resultaat:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Zowel Microsoft PowerPoint als Aspose.Slides voor C++ bieden een aantal vooraf gedefinieerde transformatietypen. 

{{% /alert %}} 

**Gebruik PowerPoint**

Om toegang te krijgen tot vooraf gedefinieerde transformatietypen, gaat u via: **Format** -> **TextEffect** -> **Transform**

**Gebruik Aspose.Slides**

Om een transformatietype te selecteren, gebruikt u de enum TextShapeType. 

### **Pas 3D‑effecten toe op tekst en vormen**

We stellen een 3D‑effect in voor een tekstvorm met deze voorbeeldcode:

``` cpp 
auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

De resulterende tekst en vorm:

![todo:image_alt_text](image-20200930114816-9.png)

We passen een 3D‑effect toe op de tekst met deze C++‑code:

``` cpp 
auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Het resultaat van de bewerking:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Het toepassen van 3D‑effecten op teksten of hun vormen en de interacties tussen effecten zijn gebaseerd op bepaalde regels. 

Beschouw een scène voor een tekst en de vorm die die tekst bevat. Het 3D‑effect bevat een 3D‑objectrepresentatie en de scène waarop het object geplaatst is. 

- Wanneer de scène zowel voor de figuur als voor de tekst is ingesteld, krijgt de figuur‑scène de hogere prioriteit—de tekst‑scène wordt genegeerd. 
- Wanneer de figuur geen eigen scène heeft maar wel een 3D‑representatie, wordt de tekst‑scène gebruikt. 
- Anders—wanneer de vorm oorspronkelijk geen 3D‑effect heeft—blijft de vorm plat en wordt het 3D‑effect alleen op de tekst toegepast. 

Deze beschrijvingen zijn gekoppeld aan de methoden ThreeDFormat.getLightRig() en ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Pas Outer‑Shadow‑effecten toe op vormen**
Aspose.Slides voor C++ biedt de [**IOuterShadow**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.effects.i_outer_shadow) en [**IInnerShadow**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.effects.i_inner_shadow) klassen waarmee u schaduweffecten kunt toepassen op tekst die zich in een TextFrame bevindt. Volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation)‑klasse.
2. Verkrijg de referentie naar een dia door zijn index te gebruiken.
3. Voeg een AutoShape van het type Rectangle toe aan de dia.
4. Toegang tot het TextFrame dat bij de AutoShape hoort.
5. Stel de FillType van de AutoShape in op NoFill.
6. Instantieer de OuterShadow‑klasse
7. Stel de BlurRadius van de schaduw in.
8. Stel de Direction van de schaduw in
9. Stel de Distance van de schaduw in.
10. Stel de RectanglelAlign in op TopLeft.
11. Stel de PresetColor van de schaduw in op Black.
12. Schrijf de presentatie weg als een PPTX‑bestand.

Deze voorbeeldcode in C++—een implementatie van de bovenstaande stappen—laat zien hoe u het outer‑shadow‑effect op tekst toepast:

``` cpp
auto pres = System::MakeObject<Presentation>();
// Haal referentie van de dia op
auto sld = pres->get_Slides()->idx_get(0);

// Voeg een AutoShape van het type Rechthoek toe
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Voeg TextFrame toe aan de rechthoek
ashp->AddTextFrame(u"Aspose TextBox");

// Schakel vormvulling uit voor het geval we de schaduw van de tekst willen krijgen
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Voeg uiterste schaduw toe en stel alle benodigde parameters in
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// Write the presentation to disk
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```

## **Pas Inner‑Shadow‑effecten toe op vormen**
Volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation)‑klasse.
2. Verkrijg een referentie naar de dia.
3. Voeg een AutoShape van het type Rectangle toe.
4. Schakel InnerShadowEffect in.
5. Stel alle benodigde parameters in.
6. Stel ColorType in op Scheme.
7. Stel de Scheme‑kleur in.
8. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.

Deze voorbeeldcode (gebaseerd op bovenstaande stappen) laat zien hoe u een connector tussen twee vormen toevoegt in C++:

``` cpp
auto presentation = System::MakeObject<Presentation>();
// Haal referentie van een dia op
auto slide = presentation->get_Slides()->idx_get(0);

// Voeg een AutoShape van het type Rechthoek toe
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Voeg TextFrame toe aan de rechthoek
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// Schakel InnerShadowEffect in    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// Stel alle benodigde parameters in
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// Stel ColorType in als Scheme
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Stel Scheme-kleur in
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// Sla presentatie op
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Kan ik WordArt‑effecten gebruiken met verschillende lettertypen of scripts (bijv. Arabisch, Chinees)?**

Ja, Aspose.Slides ondersteunt Unicode en werkt met alle gangbare lettertypen en scripts. WordArt‑effecten zoals schaduw, opvulling en omtrek kunnen worden toegepast ongeacht de taal, hoewel de beschikbaarheid van lettertypen en de weergave kunnen afhangen van de systeemlettertypen.

**Kan ik WordArt‑effecten toepassen op elementen van de dia‑master?**

Ja, u kunt WordArt‑effecten toepassen op vormen op masterslides, inclusief titel‑plaatsaanduidingen, voetteksten of achtergrondtekst. Wijzigingen in de master‑indeling worden doorgevoerd naar alle bijbehorende dia’s.

**Hebben WordArt‑effecten invloed op de bestandsgrootte van de presentatie?**

Enigszins. WordArt‑effecten zoals schaduwen, gloed en verloopvullingen kunnen de bestandsgrootte een beetje verhogen door extra opmaakmetadata, maar het verschil is meestal verwaarloosbaar.

**Kan ik het resultaat van WordArt‑effecten bekijken zonder de presentatie op te slaan?**

Ja, u kunt dia’s die WordArt bevatten renderen naar afbeeldingen (bijv. PNG, JPEG) met de `GetImage`‑methode van de [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/) of [ISlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/)‑interfaces. Hiermee kunt u het resultaat in‑geheugen of op het scherm bekijken voordat u de volledige presentatie opslaat of exporteert.