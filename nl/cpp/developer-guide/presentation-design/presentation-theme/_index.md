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
- extern thema
- THMX
- themakleur
- aanvullend palet
- themalettertype
- themastijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheer presentatiethema's in Aspose.Slides voor C++ om PowerPoint-bestanden te maken, aan te passen en te converteren met een consistente branding."
---
## **Introductie**

Een presentatie‑thema definieert een gecoördineerde set van kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een thema‑wijziging veel objecten tegelijk kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_mastertheme/). Een presentatie kan ook thema‑overrides op lagere niveaus bevatten. Een master kan het presentatie‑thema overschrijven via [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), terwijl een lay‑out of een individuele dia [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) kan gebruiken. In de praktijk wordt het effectieve thema voor een dia opgelost via deze erfingsketen: presentatie‑thema, master‑override, lay‑out‑override en dia‑override.

![Themaonderdelen: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De onderstaande secties laten de meest voorkomende thema‑werkstromen zien: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat erfelijkheid en overrides zijn opgelost.

## **Inspecteer een thema**

Het [MasterTheme](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/mastertheme/)‑object stelt de thema‑methoden [get_ColorScheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) en [get_FormatScheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) bloot. Deze collecties inspecteren vóórdat u ze wijzigt is vooral nuttig wanneer een presentatie uit een externe bron komt, omdat het aantal en de inhoud van stijl‑items kan variëren.

Het volgende voorbeeld leest de hoofd‑thema‑eigenschappen en meldt hoeveel achtergrond‑, vul‑, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

```cpp
#include <DOM/IColorFormat.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto theme = presentation->get_MasterTheme();
auto formatScheme = theme->get_FormatScheme();

Console::WriteLine(u"Theme name: {0}", theme->get_Name());
Console::WriteLine(u"Accent 1: {0}", theme->get_ColorScheme()->get_Accent1()->get_Color());
Console::WriteLine(u"Major Latin font: {0}", theme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Minor Latin font: {0}", theme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Background fill styles: {0}", formatScheme->get_BackgroundFillStyles()->get_Count());
Console::WriteLine(u"Fill styles: {0}", formatScheme->get_FillStyles()->get_Count());
Console::WriteLine(u"Line styles: {0}", formatScheme->get_LineStyles()->get_Count());
Console::WriteLine(u"Effect styles: {0}", formatScheme->get_EffectStyles()->get_Count());
```

Als een bestand meerdere masters gebruikt, ga er dan niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort en gebruik de effectieve‑thema‑werkstroom die later in dit artikel wordt getoond wanneer lay‑out‑ of dia‑overrides aanwezig kunnen zijn.

## **Themakleuren wijzigen**

Thema‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de enumeratie [SchemeColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/schemecolor/). Wanneer u het overeenkomstige item in het thema‑[IColorScheme](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/icolorscheme/) wijzigt, worden alle objecten die nog naar die thema‑kleur verwijzen, geëvalueerd tegen de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet aangepast door een thema‑kleurupdate.

Het volgende end‑to‑end voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de `Accent4`‑kleur van het thema naar rood, slaat de presentatie op, opent deze opnieuw en drukt de effectieve vulkleur af:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
presentation->Save(u"theme-color.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"theme-color.pptx");
auto savedSlide = savedPresentation->get_Slide(0);
auto savedShape = savedSlide->get_Shape(0);
auto effectiveFill = savedShape->get_FillFormat()->GetEffective();
Console::WriteLine(u"Effective fill color: {0}", effectiveFill->get_SolidFillColor());
```

Omdat de rechthoek gekoppeld blijft aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Als u de scheme‑kleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen aan `Accent4` die vul niet meer beïnvloeden.

### **Kleuren uit het aanvullende palet gebruiken**

PowerPoint genereert lichtere en donkerdere varianten vanuit een themakleur door kleurtransformaties toe te passen. Aspose.Slides maakt deze transformaties bloot via [ColorTransformOperation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/colortransformoperation/).

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren die gegenereerd zijn uit het aanvullende palet](additional-palette-colors.png)

**1** - Hoofdkleuren van het thema.  
**2** - Lichtere en donkerdere varianten afgeleid van de hoofdkleuren van het thema.

Het volgende voorbeeld maakt zes rechthoeken gebaseerd op `Accent4`, past luminantietransformaties toe op vijf ervan, en slaat het resultaat op:

```cpp
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
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();
fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();
fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();
fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();
fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();
fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();
fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"theme-color-palette.pptx", SaveFormat::Pptx);
```

Deze varianten blijven gebaseerd op de themakleur. Als `Accent4` later verandert, worden de getransformeerde kleuren opnieuw berekend vanuit de nieuwe `Accent4`‑waarde.

### **`SchemeColor`‑waarden toewijzen aan `IColorScheme`‑posities**

Enumeratie [SchemeColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/schemecolor/) gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl [IColorScheme](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/icolorscheme/) dezelfde themaposities blootstelt als `Dark1`, `Light1`, `Dark2` en `Light2`. De toewijzing is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaposities; ze zijn geen waarden die dynamisch van het ene naar het andere formaat worden geconverteerd.

## **Themale lettertypen wijzigen**

Een thema‑lettertype‑schema bevat een hoofd‑lettertype‑set voor koppen en een minder‑belangrijke lettertype‑set voor de body‑tekst. De methoden [FontScheme::get_Major()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/fontscheme/get_major/) en [FontScheme::get_Minor()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/fontscheme/get_minor/) onthullen die sets.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen worden gebruikt bij tekstopmaak:

* `+mn-lt` – Bodylettertype Latin (Minor Latin Font)
* `+mj-lt` – Koplettertype Latin (Major Latin Font)
* `+mn-ea` – Bodylettertype Oost‑Aziatisch (Minor East Asian Font)
* `+mj-ea` – Koplettertype Oost‑Aziatisch (Major East Asian Font)

Het volgende voorbeeld maakt één koptekst die het major Latin‑thema‑lettertype gebruikt en één body‑regel die het minor Latin‑thema‑lettertype gebruikt. Het wijzigt daarna de thema‑lettertypen en slaat het resultaat op:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto heading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 500.0f, 60.0f);
heading->get_TextFrame()->set_Text(u"Theme heading");
heading->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mj-lt"));

auto body = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 120.0f, 500.0f, 60.0f);
body->get_TextFrame()->set_Text(u"Theme body text");
body->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

presentation->get_MasterTheme()->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Aptos Display"));
presentation->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
presentation->Save(u"theme-fonts.pptx", SaveFormat::Pptx);
```

De kop volgt het major‑lettertype en de body‑tekst volgt het minor‑lettertype. Tekst met een expliciete lettertype‑naam in plaats van een thema‑identifier zal niet automatisch wisselen wanneer het thema‑lettertype‑schema verandert.

De major‑ en minor‑lettertypecollecties kunnen ook lettertype‑toewijzingen bevatten voor individuele schriftsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Zie [Script‑Specific Theme Fonts](/slides/nl/cpp/script-specific-font-mappings/) om deze toewijzingen te inspecteren, toe te voegen, te vervangen of te verwijderen.

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatie‑lettertypen, zie [PowerPoint‑lettertypen](/slides/nl/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Een thema kopiëren of toepassen**

De onderstaande werkstromen lossen verschillende thema‑gerelateerde problemen op.

### **Een extern thema toepassen op dia's die afhankelijk zijn van een master**

Gebruik [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) wanneer u een PowerPoint‑thema‑bestand (`.thmx`) heeft en elke dia die afhankelijk is van een bepaalde master wilt restylen. Selecteer de master uit de [Presentation::get_Masters](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_masters/)‑collectie, die [IMasterSlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslidecollection/) implementeert, en geef het pad van het thema‑bestand door aan de methode.

De methode voert de volgende bewerkingen uit:

1. Maakt een nieuwe masterslide op basis van de geselecteerde master.  
2. Past het externe thema toe op de nieuwe master.  
3. Koppelt de nieuwe master aan alle dia’s die eerder afhankelijk waren van de geselecteerde master.  
4. Retourneert de nieuw aangemaakte [IMasterSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslide/).

Het volgende voorbeeld past een extern thema toe op de dia’s die afhankelijk zijn van de eerste master en slaat de presentatie op:

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto selectedMaster = presentation->get_Master(0);
auto themedMaster = selectedMaster->ApplyExternalThemeToDependingSlides(u"corporate-theme.thmx");

Console::WriteLine(u"Created master: {0}", themedMaster->get_Name());
presentation->Save(u"presentation-with-external-theme.pptx", SaveFormat::Pptx);
```

Een ongeldig, corrupt of niet‑ondersteund thema kan een [PptxException](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pptxexception/) of een van de gerelateerde subklassen veroorzaken. Valideer paden die door gebruikers worden opgegeven, behandel fouten bij bestandstoegang en sla de presentatie pas op nadat het thema succesvol is toegepast.

Alleen de dia’s die afhankelijk waren van de geselecteerde master worden opnieuw toegewezen. Dia’s die bij andere masters horen behouden hun bestaande masters en thema’s. Thema‑bewuste kleuren, lettertypen, vullingen, lijnen, achtergronden en effecten worden geëvalueerd tegen het externe thema. Direct toegewezen kleuren, lettertypen, vullingen en andere expliciete opmaak kunnen ongewijzigd blijven. Overrides op lay‑out‑ en dia‑niveau kunnen ook voorrang krijgen boven waarden die van de nieuwe master zijn geërfd.

Het thema kan lettertypen refereren die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente weergave en export, installeer de benodigde lettertypen, lever ze via [custom font sources](/slides/nl/cpp/custom-font/), of configureer [font substitution](/slides/nl/cpp/font-substitution/).

Dit is een directe master‑niveau‑werkstroom: de methode accepteert een bestands‑pad naar een `.thmx`‑bestand en vereist geen handmatige creatie van dia‑ of lay‑out‑thema‑overrides.

### **Verschillende externe thema’s toepassen in een presentatie met meerdere masters**

Wanneer de relevante master niet van tevoren bekend is, verkrijg deze dan via een representatieve dia met [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/get_layoutslide/) en [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/get_masterslide/). Sla de oorspronkelijke master‑referenties op vóór het toepassen van thema’s, want elke aanroep maakt een extra master in de presentatie.

Het volgende voorbeeld gebruikt dia’s uit twee secties om hun masters te bepalen en past een ander extern thema toe op elke groep:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"multi-master-presentation.pptx");

if (presentation->get_Slides()->get_Count() < 5)
{
    std::cout << "The presentation does not contain the expected representative slides." << std::endl;
}
else
{
    auto firstGroupMaster = presentation->get_Slide(0)->get_LayoutSlide()->get_MasterSlide();
    auto secondGroupMaster = presentation->get_Slide(4)->get_LayoutSlide()->get_MasterSlide();

    if (firstGroupMaster->get_SlideId() == secondGroupMaster->get_SlideId())
    {
        std::cout << "The representative slides use the same master." << std::endl;
    }
    else
    {
        auto firstThemedMaster = firstGroupMaster->ApplyExternalThemeToDependingSlides(u"blue-theme.thmx");
        auto secondThemedMaster = secondGroupMaster->ApplyExternalThemeToDependingSlides(u"green-theme.thmx");

        Console::WriteLine(u"First themed master: {0}", firstThemedMaster->get_Name());
        Console::WriteLine(u"Second themed master: {0}", secondThemedMaster->get_Name());
        presentation->Save(u"multi-master-with-external-themes.pptx", SaveFormat::Pptx);
    }
}
```

De eerste aanroep beïnvloedt alleen dia’s die afhankelijk waren van `firstGroupMaster`, en de tweede aanroep beïnvloedt alleen dia’s die afhankelijk waren van `secondGroupMaster`. Dia’s die bij een andere master horen, worden niet restyled.

### **Een bronthema behouden bij het verplaatsen van dia’s**

Wilt u een dia naar een andere presentatie verplaatsen en het oorspronkelijke ontwerp behouden, kloon dan de bron‑master naar de doelpresentatie met [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslidecollection/addclone/), kloon daarna de dia met [ISlideCollection::AddClone()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) en de gekloonde master. Hiermee worden de master, de lay‑outs en het bijbehorende thema meegenomen.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto sourceSlide = source->get_Slide(0);
auto sourceMaster = sourceSlide->get_LayoutSlide()->get_MasterSlide();
auto clonedMaster = target->get_Masters()->AddClone(sourceMaster);
target->get_Slides()->AddClone(sourceSlide, clonedMaster, true);
target->Save(u"theme-preserved.pptx", SaveFormat::Pptx);
```

Dit is de aanbevolen werkstroom wanneer de brondia er in de bestemming precies hetzelfde uit moet zien. Het eenvoudigweg klonen van inhoud naar een ongekoppelde doel‑master kan thema‑gedreven kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑waarden toepassen op een bestaande dia**

Wanneer de doel‑dia op zijn huidige master en lay‑out moet blijven, initialiseert u een dia‑level override vanuit het bron‑thema. De methoden [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) en [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) kopiëren de drie hoofd‑thema‑componenten naar de override.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto overrideTheme = targetSlide->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-slide.pptx", SaveFormat::Pptx);
```

Dit wijzigt het thema dat door die dia wordt gebruikt zonder het thema dat door andere dia’s wordt geërfd te wijzigen. Om de lokale override te verwijderen en terug te keren naar geërfde waarden, roept u [OverrideTheme::Clear()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/overridetheme/clear/) aan.

### **Een thema‑override toepassen op een lay‑out**

Een lay‑out‑level override geldt voor dia’s die die lay‑out gebruiken, tenzij een specifieke dia een eigen override heeft. Dezelfde initialisatiemethoden kunnen via de lay‑out‑[IOverrideThemeManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/ioverridethememanager/) worden aangeroepen:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto targetLayout = targetSlide->get_LayoutSlide();
auto overrideTheme = targetLayout->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-layout.pptx", SaveFormat::Pptx);
```

Gebruik een master‑ of presentatie‑level thema wanneer veel lay‑outs en dia’s hetzelfde basisonwerp moeten delen, een lay‑out‑override wanneer één lay‑out‑familie een andere styling nodig heeft, en een dia‑override alleen voor echte uitzonderingen. Overmatige dia‑level overrides maken latere globale thema‑wijzigingen moeilijker te voorspellen.

## **Achtergrondstijlen van het thema bijwerken**

De achtergrondvullingen van het thema worden opgeslagen in [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint kan meer achtergrondkeuzes in de gebruikersinterface tonen dan het aantal vullingsdefinities dat fysiek in deze collectie is opgeslagen, omdat de UI thema‑vullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint‑galerij met achtergrondstijlen voor een presentatie‑thema](presentation-design_8.png)

Voordat u een achtergrondstijl gebruikt, inspecteert u de opgeslagen collectie en de huidige [Background::get_StyleIndex()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` gebruikt `0` voor geen thematische vul; positieve waarden zijn thematische achtergrond‑stijl‑referenties. Dit verschilt van het indexeren van een C++‑collectie direct met `idx_get(0)`, waar `0` het eerste opgeslagen item betekent. Ga er niet van uit dat elke presentatie evenveel achtergrondvullingsstijlen bevat.

Het volgende voorbeeld meldt het aantal beschikbare achtergrondvullingen, kent een thematische achtergrondreferentie toe aan de eerste master en slaat de presentatie op:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto backgroundStyles = presentation->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles();
Console::WriteLine(u"Background fill styles: {0}", backgroundStyles->get_Count());

if (backgroundStyles->get_Count() > 0)
{
    auto masterSlide = presentation->get_Master(0);
    masterSlide->get_Background()->set_Type(BackgroundType::Themed);
    masterSlide->get_Background()->set_StyleIndex(1);
    presentation->Save(u"theme-background.pptx", SaveFormat::Pptx);
}
```

Het zichtbare resultaat hangt af van het themaitem dat door de master wordt gerefereerd en van eventuele achtergrond‑overrides op lay‑out‑ of dia‑niveau. Als een dia een eigen achtergrond gebruikt, verandert een wijziging alleen van de master‑achtergrond die dia mogelijk niet. Gebruik [Background::GetEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/background/geteffective/) wanneer u de uiteindelijke achtergrond na erfelijkheid moet weten.

{{% alert color="warning" title="Warning" %}}
Behandel `StyleIndex` niet als een nul‑gebaseerde collectie‑index. Vermijd ook het hard‑coderen van een stijlnummer uit één bestand en ervan uitgaan dat het dezelfde weergave heeft in een ander bestand; themastijl‑definities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑erfelijkheid, zie [Presentation Background](/slides/nl/cpp/presentation-background/).
{{% /alert %}}

## **Thema‑effecten bijwerken**

Een thema‑format‑scheme bevat afzonderlijke collecties [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/formatscheme/get_linestyles/) en [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Typische Office‑thema’s bevatten vaak drie hoofd‑stijl‑items die visueel overeenkomen met subtiele, matige en intense opmaak, maar code moet elke collectie inspecteren in plaats van een vast aantal aan te nemen.

![Subtiele, matige en intense thema‑effecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer u deze collecties in C++ benadert, is de collectie‑index nul‑gebaseerd: `idx_get(0)` is de eerste opgeslagen stijl en `idx_get(2)` de derde. Een vorm‑stijl‑referentie‑index is een apart concept, blootgesteld via [IShapeStyle](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die stijl refereren; vormen met directe opmaak blijven mogelijk ongewijzigd.

Het volgende voorbeeld controleert of de vereiste stijl‑items bestaan, wijzigt de eerste lijneffect, wijzigt de derde vulstijl, schakelt een buitenste schaduw in bij de derde effectstijl, en slaat het resultaat op:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
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
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
auto formatScheme = presentation->get_MasterTheme()->get_FormatScheme();
auto lineStyles = formatScheme->get_LineStyles();
auto fillStyles = formatScheme->get_FillStyles();
auto effectStyles = formatScheme->get_EffectStyles();

if (lineStyles->get_Count() < 1 || fillStyles->get_Count() < 3 || effectStyles->get_Count() < 3)
{
    Console::WriteLine(u"The theme does not contain the style entries required by this example.");
}
else
{
    auto lineStyle = lineStyles->idx_get(0);
    lineStyle->get_FillFormat()->set_FillType(FillType::Solid);
    lineStyle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

    auto fillStyle = fillStyles->idx_get(2);
    fillStyle->set_FillType(FillType::Solid);
    fillStyle->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

    auto effectFormat = effectStyles->idx_get(2)->get_EffectFormat();
    effectFormat->EnableOuterShadowEffect();
    effectFormat->get_OuterShadowEffect()->set_Distance(10.0f);

    presentation->Save(u"theme-effects.pptx", SaveFormat::Pptx);
}
```

Voor vormen die deze slots refereren, wordt de eerste themalijneffect rood, de derde themavulstijl een effen bosgroen, en krijgt de derde effectstijl een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat blijft afhankelijk van welke stijl‑slots elke vorm refereren en of directe opmaak de thema‑instelling overschrijft.

![Thema‑effectstijlen na het aanpassen van lijn‑, vul‑ en schaduwinstellingen](presentation-design_11.png)

## **Bepalen of een effectieve effen vul een thema‑kleur gebruikt**

Een vul kan direct op een object worden opgeslagen of geërfd van een paragraaf, lay‑out, master, thema‑stijl of een ander opmaakniveau. Roep [IFillFormat::GetEffective](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifillformat/geteffective/) aan om die hiërarchie te resolven tot een onveranderlijk [IFillFormatEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifillformateffectivedata/). Controleer eerst [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifillformateffectivedata/get_filltype/). Alleen wanneer dit `FillType::Solid` is, mag u de eigenschappen van een effen vul lezen.

Voor een effen vul retourneert [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) de definitieve RGB‑waarde na erfelijkheid, themazoek en kleurtransformaties. [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) geeft de overeenkomstige logische [SchemeColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/schemecolor/)‑slot terug, zoals `Text1` of `Accent6`. Een waarde van `SchemeColor::NotDefined` betekent dat de effectieve effen vul niet op een scheme‑kleur is gebaseerd. In een werkstroom waarbij vullingen ofwel themakleuren ofwel directe RGB‑kleuren zijn, identificeert deze waarde een directe RGB‑vul.

Gebruik de lokale [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icolorformat/get_schemecolor/) niet alleen om een vul te classificeren. Een tekstdeel kan bijvoorbeeld geen lokaal gedefinieerde scheme‑kleur hebben, dus is de lokale waarde `NotDefined`, terwijl de effectieve vul een themakleur erft en resolveert naar `Text1` of `Accent6`. Omgekeerd vertelt `get_SolidFillSchemeColor` u welke logische themaslot de effectieve kleur heeft geproduceerd, maar niet van welk niveau (object, paragraaf, lay‑out, master, enz.) deze afkomstig is.

Het volgende voorbeeld laadt een presentatie, controleert zowel vormvullingen als tekst‑gedeelten, drukt elke eind‑RGB‑waarde en bijbehorende scheme‑kleur af, en markeert effen vullingen die geen themakleur volgen:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto auditFill = [](const String& objectName, const SharedPtr<IFillFormat>& localFill)
{
    auto effectiveFill = localFill->GetEffective();

    if (effectiveFill->get_FillType() != FillType::Solid)
    {
        Console::WriteLine(u"{0}: fill type = {1}; not a solid fill.", objectName, effectiveFill->get_FillType());
        return;
    }

    auto rgb = effectiveFill->get_SolidFillColor();
    auto effectiveSchemeColor = effectiveFill->get_SolidFillSchemeColor();
    auto localSchemeColor = localFill->get_SolidFillColor()->get_SchemeColor();

    Console::WriteLine(u"{0}: RGB = #{1:X2}{2:X2}{3:X2}", objectName, rgb.get_R(), rgb.get_G(), rgb.get_B());
    Console::WriteLine(u"{0}: local scheme = {1}, effective scheme = {2}", objectName, localSchemeColor, effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor::NotDefined)
    {
        Console::WriteLine(u"{0}: direct RGB or another non-scheme fill; audit as theme-independent.", objectName);
    }
    else
    {
        Console::WriteLine(u"{0}: theme-dependent through {1}.", objectName, effectiveSchemeColor);
    }
};

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int32_t slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    auto shapeCount = slide->get_Shapes()->get_Count();
    for (int32_t shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        auto shapeName = String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex + 1);
        auditFill(shapeName, shape->get_FillFormat());

        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
            for (int32_t paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                auto paragraph = textFrame->get_Paragraph(paragraphIndex);

                auto portionCount = paragraph->get_Portions()->get_Count();
                for (int32_t portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    auto portion = paragraph->get_Portion(portionIndex);
                    auto portionName = String::Format(u"{0}, paragraph {1}, portion {2}", shapeName, paragraphIndex + 1, portionIndex + 1);
                    auditFill(portionName, portion->get_PortionFormat()->get_FillFormat());
                }
            }
        }
    }
}
```

De `NotDefined`‑tak geeft een audit‑lijst van effen vullingen die niet reageren op wijzigingen in themakleur‑slots. Bekijk die objecten wanneer een presentatie een nieuw merkpallet moet volgen. De gerapporteerde RGB‑waarde toont nog steeds het huidige uiterlijk, terwijl de scheme‑waarde uitlegt of dat uiterlijk met het thema is verbonden.

Effectieve‑format‑objecten zijn momentopnamen. Na het wijzigen van het presentatie‑thema, een thema‑override of enige geërfde opmaak, roep opnieuw `GetEffective` aan en lees een nieuw `IFillFormatEffectiveData`‑object voordat u kleuren vergelijkt of rapporteert.

## **Effectieve themawaarden lezen**

Ruwe thema‑objecten vertellen u wat er op een bepaald niveau is gedefinieerd. Effectieve waarden vertellen u wat een dia of vorm daadwerkelijk gebruikt na erfelijkheid en lokale overrides. Voor een dia roept u [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) aan. Voor een achtergrond gebruikt u [Background::GetEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/background/geteffective/), en voor een vul gebruikt u [FillFormat::GetEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fillformat/geteffective/).

Het volgende voorbeeld leest het effectieve thema, de achtergrond en de eerste vormvulling van een dia:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IFontsEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontSchemeEffectiveData.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto effectiveTheme = slide->CreateThemeEffective();
auto effectiveBackground = slide->get_Background()->GetEffective();

Console::WriteLine(u"Effective major Latin font: {0}", effectiveTheme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective minor Latin font: {0}", effectiveTheme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective background fill type: {0}", effectiveBackground->get_FillFormat()->get_FillType());

if (slide->get_Shapes()->get_Count() > 0)
{
    auto effectiveFill = slide->get_Shape(0)->get_FillFormat()->GetEffective();
    Console::WriteLine(u"First shape effective fill type: {0}", effectiveFill->get_FillType());
    if (effectiveFill->get_FillType() == FillType::Solid)
    {
        Console::WriteLine(u"First shape effective fill color: {0}", effectiveFill->get_SolidFillColor());
    }
}
```

Gebruik effectieve data voor weergavediagnostiek, validatie en vergelijkingen. Als u alleen [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_mastertheme/) inspecteert, kunt u een master‑, lay‑out‑, dia‑ of vorm‑override missen die het uiteindelijke uiterlijk verandert.

## **Veelgestelde vragen**

**Heeft het toepassen van een extern thema effect op elke dia in de presentatie?**

Nee. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) wijzigt alleen de dia’s die afhankelijk zijn van de geselecteerde master. Dia’s die andere masters gebruiken behouden hun bestaande thema’s.

**Kan ik een thema toepassen op één enkele dia zonder de master te wijzigen?**

Ja. Gebruik de dia‑[IOverrideThemeManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/ioverridethememanager/) en initialiseert zijn override‑thema. De wijziging blijft lokaal voor die dia; andere dia’s blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

Wanneer u een dia verplaatst en het oorspronkelijke uiterlijk wilt behouden, kloont u de bron‑master naar de bestemming en kloont u de dia met die master via [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslidecollection/addclone/) en [ISlideCollection::AddClone()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/). Hiermee blijven master, lay‑outs en thema samen.

**Hoe kan ik de effectieve waarden zien na erfelijkheid en overrides?**

Gebruik [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) voor een dia‑ of lay‑out‑thema en de bijbehorende effectieve‑data‑methoden voor format‑objecten, zoals [Background::GetEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/background/geteffective/) en [FillFormat::GetEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fillformat/geteffective/). Deze API’s retourneren de opgeloste waarden na erfelijkheid en overrides.