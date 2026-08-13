---
title: Beheer presentatiethema's in C++
linktitle: Presentatiethema
type: docs
weight: 10
url: /nl/cpp/presentation-theme/
keywords:
- PowerPoint-thema
- presentatiethema
- dia-thema
- thema instellen
- thema wijzigen
- thema beheren
- themakleur
- aanvullende palet
- themalettertype
- themastijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheer presentatiethema's in Aspose.Slides voor C++ om PowerPoint-bestanden te maken, aan te passen en te converteren met consistente branding."
---
## **Inleiding**

Een presentatiethema definieert de eigenschappen van ontwerpelementen. Wanneer u een presentatiethema selecteert, kiest u in feite een specifieke set visuele elementen en hun eigenschappen.

In PowerPoint bestaat een thema uit kleuren, [lettertypen](/slides/nl/cpp/powerpoint-fonts/), [achtergrondstijlen](/slides/nl/cpp/presentation-background/) en effecten.

![theme-constituents](theme-constituents.png)

## **Themakleur wijzigen**

Een PowerPoint‑thema gebruikt een specifieke set kleuren voor verschillende elementen op een dia. Als u de kleuren niet bevalt, kunt u ze wijzigen door nieuwe kleuren toe te passen op het thema. Om u een nieuwe themakleur te laten kiezen, biedt Aspose.Slides waarden onder de enumeratie [SchemeColor](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28).

Deze C++‑code toont hoe u de accentkleur voor een thema wijzigt:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

U kunt de effectieve waarde van de resulterende kleur op deze manier bepalen:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto fillEffective = shape->get_FillFormat()->GetEffective();

Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Kleur [A=255, R=128, G=100, B=162])
```

Om de kleuraanpassing verder te demonstreren, maken we een ander element aan en wijzen de accentkleur (van de eerste bewerking) toe. Vervolgens wijzigen we de kleur in het thema:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();

auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);

otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

De nieuwe kleur wordt automatisch toegepast op beide elementen.

### **Themakleur instellen vanuit een aanvullende palet**

Wanneer u luminantietransformaties toepast op de hoofdkleuren van het thema (1), ontstaan kleuren uit het aanvullende palet (2). Deze themakleuren kunt u vervolgens instellen en ophalen. 

![additional-palette-colors](additional-palette-colors.png)

**1**‑ Hoofdkleuren van het thema  

**2**‑ Kleuren uit het aanvullende palet.

Deze C++‑code laat een bewerking zien waarbij aanvullende paletkleuren worden afgeleid van de hoofdkleuren van het thema en vervolgens in vormen worden gebruikt:

```c++
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Accent 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Accent 4, Lichter 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Accent 4, Lichter 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Accent 4, Lichter 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Accent 4, Donkerder 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Accent 4, Donkerder 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **`SchemeColor` koppelen aan `IColorScheme`‑kleuren**

Wanneer u werkt met [SchemeColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/schemecolor/), zult u merken dat deze de volgende themakleurwaarden bevat:

`Background1`, `Background2`, `Text1` en `Text2`.

Echter, `Presentation::get_MasterTheme()::get_ColorScheme()` retourneert een [IColorScheme](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/icolorscheme/), die de overeenkomstige kleuren blootlegt als:

`Dark1`, `Dark2`, `Light1` en `Light2`.

Dit verschil zit alleen in de benaming. Deze waarden verwijzen naar dezelfde themakleur‑posities en de koppeling is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Er is geen dynamische omzetting tussen `Text`/`Background` en `Dark`/`Light`. Het zijn gewoon alternatieve benamingen voor dezelfde themakleuren.

Dit benoemingsverschil komt voort uit de terminologie van Microsoft Office. Oudere Office‑versies gebruikten `Dark 1`, `Light 1`, `Dark 2` en `Light 2`, terwijl nieuwere UI‑versies dezelfde posities weergeven als `Text 1`, `Background 1`, `Text 2` en `Background 2`.

## **Thema‑lettertype wijzigen**

Om u toe te staan lettertypen voor thema’s en andere doeleinden te selecteren, gebruikt Aspose.Slides deze speciale identifiers (vergelijkbaar met die in PowerPoint):

* **+mn-lt** – Body‑lettertype Latin (Minor Latin Font)  
* **+mj-lt** – Kop‑lettertype Latin (Major Latin Font)  
* **+mn-ea** – Body‑lettertype Oost‑Aziaat (Minor East Asian Font)  
* **+mj-ea** – Body‑lettertype Oost‑Aziaat (Major East Asian Font)

Deze C++‑code laat zien hoe u het Latin‑lettertype toewijst aan een themaelement:

```c++
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

Deze C++‑code laat zien hoe u het presentatiethema‑lettertype wijzigt:

```c++
#include <DOM/Fonts/FontData.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");

pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

Het lettertype in alle tekstvakken wordt aangepast.

{{% alert color="info" title="TIP" %}} 

U wilt misschien [PowerPoint‑lettertypen](/slides/nl/cpp/powerpoint-fonts/) bekijken.

{{% /alert %}}

## **Thema‑achtergrondstijl wijzigen**

Standaard biedt de PowerPoint‑applicatie 12 voorgedefinieerde achtergronden, maar in een typische presentatie worden slechts 3 van die 12 achtergronden opgeslagen. 

![todo:image_alt_text](presentation-design_8.png)

Bijvoorbeeld, nadat u een presentatie hebt opgeslagen in de PowerPoint‑app, kunt u deze C++‑code uitvoeren om het aantal voorgedefinieerde achtergronden in de presentatie te bepalen:

```c++
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Theme;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 

Met de eigenschap [BackgroundFillStyles](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) van de [FormatScheme](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.theme.i_format_scheme/)‑klasse kunt u de achtergrondstijl toevoegen of benaderen in een PowerPoint‑thema. 

{{% /alert %}}

Deze C++‑code laat zien hoe u de achtergrond voor een presentatie instelt:

```c++
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");

pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Indexgids**: 0 betekent geen vulling. De index begint bij 1.

{{% alert color="info" title="TIP" %}} 

U wilt misschien [PowerPoint‑achtergrond](/slides/nl/cpp/presentation-background/) bekijken.

{{% /alert %}}

## **Thema‑effect wijzigen**

Een PowerPoint‑thema bevat doorgaans 3 waarden voor elk stijl‑array. Deze arrays worden gecombineerd tot de 3 effecten: subtiel, gematigd en intens. Bijvoorbeeld, dit is het resultaat wanneer de effecten worden toegepast op een specifieke vorm:

![todo:image_alt_text](presentation-design_10.png)

Met 3 eigenschappen ([FillStyles](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) van de [FormatScheme](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.theme.i_format_scheme/)‑klasse kunt u de elementen in een thema wijzigen (nog flexibeler dan de opties in PowerPoint).

Deze C++‑code toont hoe u een thema‑effect wijzigt door delen van elementen aan te passen:

```c++
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");

pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

De resulterende wijzigingen in vulkleur, vullingstype, schaduweffect, enz.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

### Kan ik een thema toepassen op één dia zonder de master te wijzigen?

Ja. Aspose.Slides ondersteunt thema‑overschrijvingen op dia‑niveau, zodat u een lokaal thema kunt toepassen alleen op die dia terwijl het master‑thema onaangeroerd blijft (via de [SlideThemeManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/slidethememanager/)).

### Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?

[Dia’s klonen](/slides/nl/cpp/clone-slides/) samen met hun master naar de doelpresentatie. Dit behoudt de oorspronkelijke master, lay‑outs en het bijbehorende thema zodat het uiterlijk consistent blijft.

### Hoe kan ik de “effectieve” waarden zien na alle overerving en overschrijvingen?

Gebruik de “effectieve” weergaven van de API [/slides/nl/cpp/shape-effective-properties/] voor thema/kleur/lettertype/effect. Deze geven de definitieve, berekende eigenschappen terug na toepassing van de master en eventuele lokale overschrijvingen.