---
title: Beheer presentatiethema's in C++
linktitle: Presentatiethema
type: docs
weight: 10
url: /nl/cpp/presentation-theme/
keywords:
- PowerPoint‑thema
- presentatiethema
- dia‑thema
- thema instellen
- thema wijzigen
- thema beheren
- themakleur
- extra palet
- themalettertype
- themastijl
- thema‑effect
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheer presentatiethema's in Aspose.Slides voor C++ om PowerPoint‑bestanden te maken, aan te passen en te converteren met een consistente merkidentiteit."
---
## **Introductie**

Een presentatiethema definieert de eigenschappen van ontwerpelementen. Wanneer u een presentatiethema selecteert, kiest u in feite een specifieke set visuele elementen en hun eigenschappen.

In PowerPoint bestaat een thema uit kleuren, [lettertypen](/slides/nl/cpp/powerpoint-fonts/), [achtergrondstijlen](/slides/nl/cpp/presentation-background/), en effecten.

![theme-constituents](theme-constituents.png)

## **Themakleur wijzigen**

Een PowerPoint‑thema gebruikt een specifieke set kleuren voor verschillende elementen op een dia. Als u de kleuren niet bevalt, kunt u ze wijzigen door nieuwe kleuren voor het thema toe te passen. Om een nieuwe themakleur te selecteren, biedt Aspose.Slides waarden onder de [SchemeColor](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28) enumeratie.

Deze C++‑code laat zien hoe u de accentkleur voor een thema wijzigt:

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

Zo kunt u de effectieve waarde van de resulterende kleur bepalen:

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Kleur [A=255, R=128, G=100, B=162])
```

Om de kleuraanpassing verder te demonstreren, maken we een ander element aan en wijzen we de accentkleur (van de eerste bewerking) toe. Vervolgens wijzigen we de kleur in het thema:

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

De nieuwe kleur wordt automatisch toegepast op beide elementen.

### **Themakleur instellen vanuit een extra palet**

Wanneer u luminantietransformaties toepast op de hoofdkleur van het thema(1), ontstaan kleuren uit het extra palet(2). U kunt vervolgens die themakleuren instellen en opvragen.

![additional-palette-colors](additional-palette-colors.png)

**1**- Hoofdkleuren van thema  
**2** - Kleuren uit het extra palet.

Deze C++‑code toont een bewerking waarbij kleuren uit het extra palet worden verkregen van de hoofdkleur van het thema en vervolgens in vormen worden gebruikt:

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Accent 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Accent 4, lichter 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Accent 4, lichter 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Accent 4, lichter 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Accent 4, donkerder 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Accent 4, donkerder 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **`SchemeColor` naar `IColorScheme` kleuren toewijzen**

Wanneer u werkt met [SchemeColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides.schemecolor/), zult u merken dat het de volgende themakleurwaarden bevat:

`Background1`, `Background2`, `Text1` en `Text2`.

Echter, `Presentation::get_MasterTheme()::get_ColorScheme()` retourneert [IColorScheme](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/icolorscheme/), die de corresponderende kleuren toont als:

`Dark1`, `Dark2`, `Light1` en `Light2`.

Dit verschil zit alleen in de benaming. Deze waarden verwijzen naar dezelfde themakleur‑posities en de toewijzing is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Er is geen dynamische conversie tussen `Text`/`Background` en `Dark`/`Light`. Het zijn simpelweg alternatieve namen voor dezelfde themakleuren.

Dit verschil in benamingen komt voort uit de terminologie van Microsoft Office. Oudere Office‑versies gebruikten `Dark 1`, `Light 1`, `Dark 2` en `Light 2`, terwijl nieuwere UI‑versies dezelfde posities tonen als `Text 1`, `Background 1`, `Text 2` en `Background 2`.

## **Themalettertype wijzigen**

Om u in staat te stellen lettertypen voor thema's en andere doeleinden te selecteren, gebruikt Aspose.Slides deze speciale identifiers (vergelijkbaar met die in PowerPoint):

* **+mn-lt** - Body Font Latin (Minor Latin Font)
* **+mj-lt** - Heading Font Latin (Major Latin Font)
* **+mn-ea** - Body Font East Asian (Minor East Asian Font)
* **+mj-ea** - Body Font East Asian (Major East Asian Font)

Deze C++‑code laat zien hoe u het Latijnse lettertype toewijst aan een thema‑element:

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

Deze C++‑code laat zien hoe u het presentatiethema‑lettertype wijzigt:

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

Het lettertype in alle tekstvakken wordt bijgewerkt.

{{% alert color="primary" title="TIP" %}} 
U wilt wellicht [PowerPoint fonts](/slides/nl/cpp/powerpoint-fonts/) bekijken.
{{% /alert %}}

## **Thema‑achtergrondstijl wijzigen**

Standaard biedt de PowerPoint‑app 12 vooraf gedefinieerde achtergronden, maar slechts 3 van die 12 achtergronden worden opgeslagen in een gewone presentatie. 

![todo:image_alt_text](presentation-design_8.png)

Bijvoorbeeld, nadat u een presentatie hebt opgeslagen in de PowerPoint‑app, kunt u deze C++‑code uitvoeren om het aantal vooraf gedefinieerde achtergronden in de presentatie te achterhalen:

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
Met de [BackgroundFillStyles](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) eigenschap van de [FormatScheme](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.theme.i_format_scheme/) klasse kunt u de achtergrondstijl in een PowerPoint‑thema toevoegen of benaderen. 
{{% /alert %}}

Deze C++‑code laat zien hoe u de achtergrond voor een presentatie instelt:

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Indexgids**: 0 staat voor geen vulling. De index begint bij 1.

{{% alert color="primary" title="TIP" %}} 
U wilt wellicht [PowerPoint Background](/slides/nl/cpp/presentation-background/) bekijken.
{{% /alert %}}

## **Thema‑effect wijzigen**

Een PowerPoint‑thema bevat meestal 3 waarden voor elke stijl‑array. Die arrays worden gecombineerd tot deze 3 effecten: subtiel, gematigd en intens. Bijvoorbeeld, dit is het resultaat wanneer de effecten op een specifieke vorm worden toegepast:

![todo:image_alt_text](presentation-design_10.png)

Door 3 eigenschappen ([FillStyles](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) van de [FormatScheme](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.theme.i_format_scheme/)‑klasse te gebruiken, kunt u de elementen in een thema aanpassen (nog flexibeler dan de opties in PowerPoint).

Deze C++‑code laat zien hoe u een thema‑effect wijzigt door delen van elementen aan te passen:

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

De resulterende wijzigingen in vulkleur, vultype, schaduweffect, enz.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Kan ik een thema toepassen op één dia zonder de master te wijzigen?**

Ja. Aspose.Slides ondersteunt thema‑overschrijvingen op dia‑niveau, zodat u een lokaal thema kunt toepassen op die specifieke dia terwijl het master‑thema intact blijft (via de [SlideThemeManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/slidethememanager/)).

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

[Clone slides](/slides/nl/cpp/clone-slides/) samen met hun master naar de doelpresentatie. Dit behoudt de originele master, indelingen en het bijbehorende thema, zodat het uiterlijk consistent blijft.

**Hoe kan ik de "effectieve" waarden zien na alle overerving en overschrijvingen?**

Gebruik de ["effective" weergaven](/slides/nl/cpp/shape-effective-properties/) van de API voor thema/kleur/lettertype/effect. Deze geven de uiteindelijke, opgeloste eigenschappen terug na het toepassen van de master plus eventuele lokale overschrijvingen.