---
title: Vytvořit a použít efekty WordArt v C++
linktitle: WordArt
type: docs
weight: 110
url: /cs/cpp/wordart/
keywords:
- WordArt
- vytvořit WordArt
- šablona WordArt
- efekt WordArt
- efekt stínu
- efekt zobrazení
- efekt záře
- transformace WordArt
- 3D efekt
- efekt vnějšího stínu
- efekt vnitřního stínu
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Vytvořte a přizpůsobte efekty WordArt v Aspose.Slides pro C++. Tento krok za krokem průvodce pomáhá vývojářům vylepšit prezentace profesionálním textem v C++."
---
## **Přehled**

Efekty WordArt vám umožňují přidávat vizuálně atraktivní, stylizovaný text do vašich prezentací PowerPoint. S Aspose.Slides mohou vývojáři programově vytvářet, přizpůsobovat a spravovat WordArt stejně jako v Microsoft PowerPoint — aniž by bylo nutné mít nainstalovaný Office. Tento článek poskytuje přehled práce s WordArt, včetně toho, jak použít textové transformace, výplňové styly, obrysy, stíny a další možnosti formátování, aby byl obsah vaší prezentace výražnější a poutavější. WordArt vám umožňuje zacházet s textem jako s grafickým objektem. Skládá se z efektů nebo speciálních úprav aplikovaných na text, aby byl atraktivnější nebo výraznější.

## **Vytvořte jednoduchou šablonu WordArt a aplikujte ji na text**

**Použití Aspose.Slides** 

Nejprve vytvoříme jednoduchý text pomocí tohoto C++ kódu: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

Nyní nastavíme výšku písma textu na větší hodnotu, aby byl efekt výraznější, pomocí tohoto kódu:

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**Použití Microsoft PowerPoint**

Jděte do nabídky efektů WordArt v Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

V pravém menu můžete vybrat předdefinovaný efekt WordArt. V levém menu můžete zadat nastavení pro nový WordArt. 

Zde jsou některé z dostupných parametrů nebo možností:

![todo:image_alt_text](image-20200930114015-3.png)

**Použití Aspose.Slides**

Zde aplikujeme barvu vzoru SmallGrid na text a přidáme černý ohraničení textu šířky 1 pomocí tohoto kódu:

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

Výsledný text:

![todo:image_alt_text](image-20200930114108-4.png)

## **Použít další efekty WordArt**

**Použití Microsoft PowerPoint**

Z rozhraní programu můžete tyto efekty aplikovat na text, blok textu, tvar nebo podobný prvek:

![todo:image_alt_text](image-20200930114129-5.png)

Příklad: efekty Stín, Odraz a Záře lze aplikovat na text; efekty 3D Formát a 3D Rotace lze aplikovat na blok textu; vlastnost Měkké hrany lze aplikovat na objekt Tvar (má efekt i když není nastavena vlastnost 3D Formát).

### **Použít stínové efekty na text**

Zde chceme nastavit pouze vlastnosti týkající se textu. Použijeme stínový efekt na text pomocí tohoto C++ kódu:

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

Aspose.Slides API podporuje tři typy stínů: OuterShadow, InnerShadow a PresetShadow.  
S PresetShadow můžete aplikovat stín na text (použitím přednastavených hodnot).  

**Použití Microsoft PowerPoint**

V PowerPoint můžete použít jeden typ stínu. Zde je příklad:

![todo:image_alt_text](image-20200930114225-6.png)

**Použití Aspose.Slides**

Aspose.Slides ve skutečnosti umožňuje aplikovat dva typy stínů najednou: InnerShadow a PresetShadow.

**Poznámky:**

- Když jsou použity OuterShadow a PresetShadow dohromady, aplikuje se pouze efekt OuterShadow.  
- Pokud jsou OuterShadow a InnerShadow použity současně, výsledný nebo aplikovaný efekt závisí na verzi PowerPointu. Například v PowerPoint 2013 se efekt zdvojnásobí. V PowerPoint 2007 se aplikuje efekt OuterShadow.  

### **Použít odrazové efekty**

Přidáme odraz do textu pomocí tohoto ukázkového C++ kódu:

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

### **Použít zářivé efekty**

Aplikujeme efekt záře na text, aby zářil nebo vynikl, pomocí tohoto kódu:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

Výsledek operace:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Můžete změnit parametry pro stín, zobrazení a záři. Vlastnosti efektů jsou nastaveny na každou část textu zvlášť. 

{{% /alert %}} 

### **Použít transformace ve WordArt**

Použijeme metodu set_Transform (vlastní pro celý blok textu) pomocí tohoto kódu:

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

Výsledek:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Jak Microsoft PowerPoint, tak Aspose.Slides pro C++ poskytují určité množství předdefinovaných typů transformací. 

{{% /alert %}} 

**Použití PowerPoint**

Pro přístup k předdefinovaným typům transformací přejděte na: **Formát** -> **TextEffect** -> **Transform**

**Použití Aspose.Slides**

Pro výběr typu transformace použijte výčtový typ TextShapeType. 

### **Použít 3D efekty na text a tvary**

Nastavíme 3D efekt na tvar textu pomocí tohoto ukázkového kódu:

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

Výsledný text a jeho tvar:

![todo:image_alt_text](image-20200930114816-9.png)

Aplikujeme 3D efekt na text tímto C++ kódem:

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

Výsledek operace:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Aplikace 3D efektů na texty nebo jejich tvary a interakce mezi efekty jsou založeny na určitých pravidlech. 

Zvažte scénu pro text a tvar, který text obsahuje. 3D efekt obsahuje reprezentaci 3D objektu a scénu, na kterou je objekt umístěn. 

- Když je scéna nastavena jak pro tvar, tak pro text, má scéna tvaru vyšší prioritu — scéna textu je ignorována.  
- Když tvar nemá vlastní scénu, ale má 3D reprezentaci, použije se scéna textu.  
- Jinak — když tvar původně nemá 3D efekt — je tvar plochý a 3D efekt se aplikuje pouze na text.  

Tyto popisy jsou spojeny s metodami ThreeDFormat.getLightRig() a ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Aplikovat vnější stínové efekty na tvary**
Aspose.Slides pro C++ poskytuje třídy [**IOuterShadow**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.effects.i_outer_shadow) a [**IInnerShadow**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.effects.i_inner_shadow), které umožňují aplikovat stínové efekty na text obsažený v TextFrame. Proveďte tyto kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte k snímku AutoShape typu Obdélník.
4. Získejte přístup k TextFrame přiřazenému k AutoShape.
5. Nastavte FillType AutoShape na NoFill.
6. Instancujte třídu OuterShadow
7. Nastavte BlurRadius stínu.
8. Nastavte Direction (směr) stínu.
9. Nastavte Distance (vzdálenost) stínu.
10. Nastavte RectanglelAlign na TopLeft.
11. Nastavte PresetColor stínu na Black.
12. Uložte prezentaci jako soubor PPTX.

Tento ukázkový kód v C++ — implementace výše uvedených kroků — ukazuje, jak aplikovat vnější stínový efekt na text:

``` cpp
auto pres = System::MakeObject<Presentation>();
// Získat odkaz na snímek
auto sld = pres->get_Slides()->idx_get(0);

// Přidat AutoShape typu Obdélník
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Přidat TextFrame k obdélníku
ashp->AddTextFrame(u"Aspose TextBox");

// Zakázat výplň tvaru pro případ, že chceme získat stín textu
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Přidat vnější stín a nastavit všechny potřebné parametry
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// Uložit prezentaci na disk
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```

## **Aplikovat vnitřní stínové efekty na tvary**
Proveďte tyto kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Získejte odkaz na snímek.
3. Přidejte AutoShape typu Obdélník.
4. Povolte InnerShadowEffect.
5. Nastavte všechny potřebné parametry.
6. Nastavte ColorType na Scheme.
7. Nastavte Scheme Color.
8. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/).

Tento ukázkový kód (na základě výše uvedených kroků) ukazuje, jak přidat spojku mezi dvěma tvary v C++:

``` cpp
auto presentation = System::MakeObject<Presentation>();
// Získat odkaz na snímek
auto slide = presentation->get_Slides()->idx_get(0);

// Přidat AutoShape typu Obdélník
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Přidat TextFrame k obdélníku
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// Povolit InnerShadowEffect    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// Nastavit všechny potřebné parametry
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// Nastavit ColorType na Scheme
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Nastavit barvu schématu
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// Uložit prezentaci
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Mohu použít efekty WordArt s různými fonty nebo písmy (např. arabština, čínština)?**

Ano, Aspose.Slides podporuje Unicode a funguje se všemi hlavními fonty a písmy. Efekty WordArt jako stín, výplň a obrys lze aplikovat bez ohledu na jazyk, i když dostupnost fontu a vykreslování mohou záviset na systémových fontech.

**Mohu aplikovat efekty WordArt na prvky master snímku?**

Ano, můžete aplikovat efekty WordArt na tvary v master snímcích, včetně zástupců titulků, zápatí nebo textu na pozadí. Změny provedené v rozložení masteru se projeví ve všech souvisejících snímcích.

**Ovlivňují efekty WordArt velikost souboru prezentace?**

Mírně. Efekty WordArt, jako jsou stíny, záře a gradientové výplně, mohou mírně zvýšit velikost souboru kvůli přidaným metadatům formátování, ale rozdíl je obvykle zanedbatelný.

**Mohu si prohlédnout výsledek efektů WordArt bez uložení prezentace?**

Ano, můžete vykreslovat snímky obsahující WordArt do obrázků (např. PNG, JPEG) pomocí metody `GetImage` z rozhraní [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides.ishape/) nebo [ISlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides.islide/). To vám umožní náhled výsledku v paměti nebo na obrazovce před uložením nebo exportem celé prezentace.