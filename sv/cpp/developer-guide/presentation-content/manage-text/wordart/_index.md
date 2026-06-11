---
title: Skapa och tillämpa WordArt‑effekter i C++
linktitle: WordArt
type: docs
weight: 110
url: /sv/cpp/wordart/
keywords:
- WordArt
- skapa WordArt
- WordArt‑mall
- WordArt‑effekt
- skuggeffekt
- visningseffekt
- glödeffekt
- WordArt‑transformation
- 3D‑effekt
- yttre skuggeffekt
- inre skuggeffekt
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Skapa och anpassa WordArt‑effekter i Aspose.Slides för C++. Denna steg‑för‑steg‑guide hjälper utvecklare att förbättra presentationer med professionell text i C++."
---
## **Översikt**

WordArt‑effekter låter dig lägga till visuellt tilltalande, styliserad text i dina PowerPoint‑presentationer. Med Aspose.Slides kan utvecklare programatiskt skapa, anpassa och hantera WordArt precis som i Microsoft PowerPoint—utan att behöva ha Office installerat. Den här artikeln ger en översikt över hur du arbetar med WordArt, inklusive hur du tillämpar texttransformeringar, fyllningsstilar, konturer, skuggor och andra formateringsalternativ för att göra ditt presentationsinnehåll mer uttrycksfullt och engagerande. WordArt låter dig behandla text som ett grafiskt objekt. Det består av effekter eller speciella modifieringar som appliceras på text för att göra den mer attraktiv eller märkbar.

## **Skapa en enkel WordArt‑mall och tillämpa den på text**

**Använda Aspose.Slides** 

Först skapar vi en enkel text med den här C++‑koden: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

Nu sätter vi textens teckenhöjd till ett större värde för att göra effekten mer märkbar med den här koden:

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**Använda Microsoft PowerPoint**

Gå till WordArt‑effektmenyn i Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Från menyn till höger kan du välja en fördefinierad WordArt‑effekt. Från menyn till vänster kan du specificera inställningarna för en ny WordArt. 

Det här är några av de tillgängliga parametrarna eller alternativen:

![todo:image_alt_text](image-20200930114015-3.png)

**Använda Aspose.Slides**

Här applicerar vi SmallGrid‑mönsterfärgen på texten och lägger till en svart textram med bredden 1 med den här koden:

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

Den resulterande texten:

![todo:image_alt_text](image-20200930114108-4.png)

## **Tillämpa andra WordArt‑effekter**

**Använda Microsoft PowerPoint**

Från programmets gränssnitt kan du applicera dessa effekter på en text, textblock, form eller liknande element:

![todo:image_alt_text](image-20200930114129-5.png)

Till exempel kan skugga-, reflektion- och glödeffekter appliceras på en text; 3D‑format- och 3D‑roterings‑effekter kan appliceras på ett textblock; egenskapen Mjuka kanter kan appliceras på ett formobjekt (den har fortfarande en effekt när ingen 3D‑format‑egenskap är inställd). 

### **Applicera skuggeffekter på text**

Här avser vi att bara sätta egenskaper som gäller för en text. Vi applicerar skuggeffekten på en text med den här koden i C++:

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

Aspose.Slides‑API stöder tre typer av skuggor: OuterShadow, InnerShadow och PresetShadow. 
Med PresetShadow kan du applicera en skugga på en text (med förinställda värden). 

**Använda Microsoft PowerPoint**

I PowerPoint kan du använda en typ av skugga. Här är ett exempel:

![todo:image_alt_text](image-20200930114225-6.png)

**Använda Aspose.Slides**

Aspose.Slides låter dig faktiskt applicera två typer av skuggor samtidigt: InnerShadow och PresetShadow.

**Obs:** 

- När OuterShadow och PresetShadow används tillsammans, appliceras endast OuterShadow‑effekten. 
- Om OuterShadow och InnerShadow används samtidigt beror den resulterande eller applicerade effekten på vilken PowerPoint‑version som används. Till exempel, i PowerPoint 2013 fördubblas effekten. Men i PowerPoint 2007 appliceras OuterShadow‑effekten. 

### **Applicera reflektionseffekter**

Vi lägger till en reflektion på texten med detta kodexempel i C++:

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

### **Applicera glödeffekter**

Vi applicerar glödeffekten på texten för att få den att skina eller sticka ut med den här koden:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

Resultatet av operationen:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Du kan ändra parametrarna för skugga, reflektion och glow. Effekternas egenskaper sätts på varje del av texten separat. 
{{% /alert %}} 

### **Använd transformationer i WordArt**

Vi använder set_Transform‑metoden (gäller hela textblocket) med den här koden:

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

Resultatet:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Både Microsoft PowerPoint och Aspose.Slides för C++ erbjuder ett antal fördefinierade transformationstyper. 
{{% /alert %}} 

**Använda PowerPoint**

För att komma åt fördefinierade transformationstyper, gå till: **Format** -> **TextEffect** -> **Transform**

**Använda Aspose.Slides**

För att välja en transformationstyp, använd TextShapeType‑enum.

### **Applicera 3D‑effekter på text och former**

Vi sätter en 3D‑effekt på en textform med detta exempel på kod:

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

Den resulterande texten och dess form:

![todo:image_alt_text](image-20200930114816-9.png)

Vi applicerar en 3D‑effekt på texten med den här C++‑koden:

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

Resultatet av operationen:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
Appliceringen av 3D‑effekter på texter eller deras former och interaktioner mellan effekter baseras på vissa regler. 
Tänk på en scen för en text och den form som innehåller texten. 3D‑effekten innehåller en 3D‑objektrepresentation och scenen där objektet placerades. 
- När scenen är inställd för både figuren och texten får figurscenen högre prioritet—textscenen ignoreras. 
- När figuren saknar egen scen men har 3D‑representation, används textscenen. 
- Annars—när formen ursprungligen saknar 3D‑effekt—är formen platt och 3D‑effekten appliceras endast på texten. 
Dessa beskrivningar är kopplade till metoderna ThreeDFormat.getLightRig() och ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **Applicera yttre skuggeffekter på former**
Aspose.Slides för C++ tillhandahåller klasserna [**IOuterShadow**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.effects.i_outer_shadow) och [**IInnerShadow**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.effects.i_inner_shadow) som låter dig applicera skuggeffekter på text som finns i en TextFrame. Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
2. Hämta referensen till en bild genom att använda dess index.
3. Lägg till en AutoShape av typen Rectangle på bilden.
4. Få åtkomst till TextFrame som är associerad med AutoShape.
5. Ställ in FillType för AutoShape till NoFill.
6. Instansiera OuterShadow‑klassen
7. Ställ in BlurRadius för skuggan.
8. Ställ in Direction för skuggan
9. Ställ in Distance för skuggan.
10. Ställ in RectanglelAlign till TopLeft.
11. Ställ in PresetColor för skuggan till Black.
12. Skriv presentationen som en PPTX‑fil.

Detta exempel på C++‑kod—en implementering av stegen ovan—visar hur du applicerar den yttre skuggeffekten på en text:

``` cpp
auto pres = System::MakeObject<Presentation>();
// Hämta referens till bilden
auto sld = pres->get_Slides()->idx_get(0);

// Lägg till en AutoShape av typen Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Lägg till TextFrame till rektangeln
ashp->AddTextFrame(u"Aspose TextBox");

// Inaktivera fyllning av formen ifall vi vill ha skugga på texten
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Lägg till yttre skugga och sätt alla nödvändiga parametrar
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// Spara presentationen till disk
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```

## **Applicera inre skuggeffekter på former**
Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
2. Hämta en referens till bilden.
3. Lägg till en AutoShape av typen Rectangle.
4. Aktivera InnerShadowEffect.
5. Ställ in alla nödvändiga parametrar.
6. Ställ in ColorType till Scheme.
7. Ställ in Scheme Color.
8. Skriv presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil.

Detta exempel på kod (baserat på stegen ovan) visar hur du lägger till en anslutning mellan två former i C++:

``` cpp
auto presentation = System::MakeObject<Presentation>();
// Hämta referens till en bild
auto slide = presentation->get_Slides()->idx_get(0);

// Lägg till en AutoShape av typen Rectangle
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Lägg till TextFrame till rektangeln
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// Aktivera InnerShadowEffect    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// Ställ in alla nödvändiga parametrar
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// Ställ in ColorType till Scheme
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Ställ in Scheme Color
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// Spara presentation
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```

## **Vanliga frågor**

**Kan jag använda WordArt‑effekter med olika teckensnitt eller skript (t.ex. arabiska, kinesiska)?**

Ja, Aspose.Slides stöder Unicode och fungerar med alla större teckensnitt och skript. WordArt‑effekter som skugga, fyllning och kontur kan appliceras oavsett språk, även om teckensnittens tillgänglighet och rendering kan bero på systemets teckensnitt.

**Kan jag applicera WordArt‑effekter på element i bildens master?**

Ja, du kan applicera WordArt‑effekter på former i masterbilder, inklusive platshållare för titel, sidfot eller bakgrundstext. Ändringar som görs i masterlayouten kommer att reflekteras på alla associerade bilder.

**Påverkar WordArt‑effekter filstorleken på presentationen?**

Lite grann. WordArt‑effekter som skuggor, glöd och gradientfyllningar kan något öka filstorleken på grund av extra formateringsmetadata, men skillnaden är vanligtvis försumbar.

**Kan jag förhandsgranska resultatet av WordArt‑effekter utan att spara presentationen?**

Ja, du kan rendera bilder som innehåller WordArt till bilder (t.ex. PNG, JPEG) med hjälp av `GetImage`‑metoden från gränssnitten [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides.ishape/) eller [ISlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides.islide/). Detta låter dig förhandsgranska resultatet i minnet eller på skärmen innan du sparar eller exporterar hela presentationen.