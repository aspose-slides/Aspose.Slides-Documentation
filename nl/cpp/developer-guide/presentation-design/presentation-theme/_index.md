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
- extra palet
- thema-lettertype
- themastijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheer presentatiethema's in Aspose.Slides voor C++ om PowerPoint-bestanden te maken, aanpassen en converteren met een consistente branding."
---
## **Introductie**

Een presentatiethema definieert een gecoördineerde set van kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een themawijziging vele objecten tegelijk kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_mastertheme/). Een presentatie kan ook themaatheerses op lagere niveaus bevatten. Een master kan het presentatiethema overschrijven via [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), terwijl een lay‑out of een individuele dia [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) kan gebruiken. In de praktijk wordt het effectieve thema voor een dia bepaald via deze overervingsketen: presentatiethema, master‑override, lay‑out‑override en dia‑override.

![Themakelementen: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De onderstaande secties laten de meest voorkomende thema‑workflows zien: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat overerving en overschrijvingen zijn verwerkt.

## **Een thema inspecteren**

Het [MasterTheme](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/mastertheme/)‑object biedt toegang tot de thema‑[get_ColorScheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) en [get_FormatScheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) methoden. Deze collecties inspecteren voordat ze worden gewijzigd is vooral handig wanneer een presentatie uit een externe bron komt, omdat het aantal en de inhoud van stijl‑items kan variëren.

Het volgende voorbeeld leest de hoofdthema‑eigenschappen en rapporteert hoeveel achtergrond‑, vul‑, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

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

Als een bestand meerdere masters bevat, ga er dan niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort, en gebruik de effectieve‑thema‑workflow die later in dit artikel wordt getoond wanneer er lay‑out‑ of dia‑overwrites aanwezig kunnen zijn.

## **Themakleuren wijzigen**

Thema‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/schemecolor/)‑enumeratie. Wanneer u de bijbehorende entry in het thema‑[IColorScheme](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/icolorscheme/) wijzigt, worden alle objecten die nog naar die themakleur verwijzen, bijgewerkt naar de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet gewijzigd door een thema‑kleurupdate.

Het volgende end‑to‑end voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de thema‑kleur `Accent4` naar rood, slaat de presentatie op, opent deze opnieuw, en print de effectieve vulkleur:

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

Omdat het rechthoekige object nog gekoppeld is aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Als u de schema‑kleur vervangt door een directe kleur op de vorm, hebben latere wijzigingen van `Accent4` geen effect meer op die vul.

### **Kleuren uit het aanvullende palet gebruiken**

PowerPoint creëert lichtere en donkerdere varianten van een themakleur door kleurtransformaties toe te passen. Aspose.Slides exposeert deze transformaties via [ColorTransformOperation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/colortransformoperation/).

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren gegenereerd uit het aanvullende palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.

**2** – Lichtere en donkerdere varianten die uit de hoofdkleuren zijn afgeleid.

Het volgende voorbeeld maakt zes rechthoeken gebaseerd op `Accent4`, past luminantie‑transformaties toe op vijf ervan, en slaat het resultaat op:

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

Deze varianten blijven gebaseerd op de themakleur. Als `Accent4` later verandert, worden de getransformeerde kleuren opnieuw berekend op basis van de nieuwe `Accent4`‑waarde.

### **`SchemeColor`‑waarden naar `IColorScheme`‑slots mappen**

De [SchemeColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/schemecolor/)‑enumeratie gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl [IColorScheme](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/icolorscheme/) dezelfde themaslots exposeert als `Dark1`, `Light1`, `Dark2` en `Light2`. De mapping is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaslots; het zijn geen waarden die dynamisch van de ene vorm naar de andere worden omgezet.

## **Thema‑lettertypen wijzigen**

Een thema‑lettertype‑schema bevat een hoofdlettertype‑set voor koppen en een secundaire lettertype‑set voor de hoofdtekst. De methoden [FontScheme::get_Major()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/fontscheme/get_major/) en [FontScheme::get_Minor()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/fontscheme/get_minor/) exposen deze sets.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen in tekstopmaak worden gebruikt:

* `+mn-lt` – Body‑lettertype Latijn (Minor Latin Font)
* `+mj-lt` – Kop‑lettertype Latijn (Major Latin Font)
* `+mn-ea` – Body‑lettertype Oost‑Aziatisch (Minor East Asian Font)
* `+mj-ea` – Kop‑lettertype Oost‑Aziatisch (Major East Asian Font)

Het volgende voorbeeld maakt één kop die het hoofd‑Latijn‑themalettertype gebruikt en één body‑regel die het secundaire Latijn‑themalettertype gebruikt. Vervolgens worden de thema‑lettertypen gewijzigd en het resultaat opgeslagen:

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

De kop volgt het hoofdlettertype en de body‑tekst volgt het secundaire lettertype. Tekst met een expliciete lettertype‑naam in plaats van een thema‑identifier zal niet automatisch schakelen wanneer het thema‑lettertype‑schema verandert.

De hoofd‑ en secundaire lettertype‑collecties kunnen ook lettertype‑koppelingen bevatten voor individuele schriftsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Om deze koppelingen te inspecteren, toe te voegen, te vervangen of te verwijderen, zie [Script‑Specific Theme Fonts](/slides/nl/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

Voor meer informatie over presentatietekstlettertypen, zie [PowerPoint Fonts](/slides/nl/cpp/powerpoint-fonts/).

{{% /alert %}}

## **Een thema kopiëren of toepassen**

De onderstaande workflows lossen verschillende thema‑gerelateerde problemen op.

### **Een extern thema toepassen op dia’s die afhankelijk zijn van een master**

Gebruik [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) wanneer u een PowerPoint‑thema‑bestand (`.thmx`) hebt en elke dia die afhankelijk is van een bepaalde master wilt restylen. Selecteer de master uit de [Presentation::get_Masters](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_masters/)‑collectie, die een [IMasterSlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslidecollection/) implementeert, en geef het pad naar het themabestand door aan de methode.

De methode voert de volgende handelingen uit:

1. Maakt een nieuwe masterslide op basis van de geselecteerde master.
1. Past het externe thema toe op de nieuwe master.
1. Koppelt de nieuwe master aan alle dia’s die voorheen afhankelijk waren van de geselecteerde master.
1. Retourneert de nieuw gemaakte [IMasterSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslide/).

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

Een ongeldig, corrupt of niet‑ondersteund thema kan een [PptxException](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pptxexception/) of een van zijn format‑gerelateerde subklassen veroorzaken. Valideer paden die door gebruikers worden opgegeven, behandel fouten bij bestands‑systeem‑toegang, en sla de presentatie pas op nadat het thema met succes is toegepast.

Alleen de dia’s die afhankelijk waren van de geselecteerde master worden opnieuw toegewezen. Dia’s die gekoppeld zijn aan andere masters behouden hun bestaande masters en thema’s. Thema‑bewuste kleuren, lettertypen, vullingen, lijnen, achtergronden en effecten worden afgehandeld ten opzichte van het externe thema. Direct toegewezen kleuren, lettertypen, vullingen en andere expliciete opmaak kunnen ongewijzigd blijven. Lay‑out‑ en dia‑overwrites kunnen eveneens voorrang krijgen op waarden die van de nieuwe master zijn geërfd.

Het thema kan verwijzen naar lettertypen die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente weergave en export, installeer de vereiste lettertypen, lever ze via [custom font sources](/slides/nl/cpp/custom-font/), of configureer [font substitution](/slides/nl/cpp/font-substitution/).

Dit is een directe master‑level workflow: de methode accepteert een bestands­pad naar een `.thmx`‑bestand en vereist geen handmatige creatie van dia‑ of lay‑out‑thema‑overwrites.

### **Verschillende externe thema’s toepassen in een multi‑master presentatie**

Wanneer de relevante master niet van tevoren bekend is, haal deze dan op via een representatieve dia met [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/get_layoutslide/) en [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/get_masterslide/). Sla de oorspronkelijke master‑referenties op vóór het toepassen van thema’s, want elke oproep creëert een nieuwe master in de presentatie.

Het volgende voorbeeld gebruikt dia’s uit twee secties om hun masters te vinden en past een verschillend extern thema toe op elke groep:

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

De eerste oproep beïnvloedt alleen de dia’s die afhankelijk waren van `firstGroupMaster`, en de tweede oproep alleen de dia’s die afhankelijk waren van `secondGroupMaster`. Dia’s die bij een andere master horen, worden niet restyled.

### **Een bron‑thema behouden bij het verplaatsen van dia’s**

Wilt u een dia naar een andere presentatie verplaatsen en het oorspronkelijke ontwerp behouden, kloon dan de bron‑master naar de doelpresentatie met [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslidecollection/addclone/), kloon vervolgens de dia met [ISlideCollection::AddClone()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) en de gekloonde master. Hierdoor worden de master, de lay‑outs en het bijbehorende thema samen meegenomen.

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

Dit is de aanbevolen workflow wanneer de bron‑dia er in de bestemming exact hetzelfde uit moet zien. Het simpelweg klonen van inhoud naar een ongekoppelde doeldia‑master kan thema‑gedreven kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑waarden toepassen op een bestaande dia**

Wanneer de doeldia op zijn huidige master en lay‑out moet blijven, initialiseert u een dia‑niveau override vanaf het bron‑thema. De methoden [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) en [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) kopiëren de drie hoofd‑thema‑componenten naar de override.

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

Dit wijzigt het thema dat door die dia wordt gebruikt zonder het thema dat andere dia’s erven te wijzigen. Om de lokale override te verwijderen en terug te keren naar geërfde waarden, roep [OverrideTheme::Clear()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/overridetheme/clear/) aan.

### **Een thema‑override toepassen op een lay‑out**

Een lay‑out‑niveau override geldt voor alle dia’s die die lay‑out gebruiken, tenzij een specifieke dia zijn eigen override heeft. Dezelfde initialisatiemethoden kunnen worden gebruikt via de lay‑out‑[IOverrideThemeManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/ioverridethememanager/):

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

Gebruik een master‑ of presentatiethema wanneer veel lay‑outs en dia’s hetzelfde basisonwerp moeten delen, een lay‑out‑override wanneer één lay‑out‑familie een andere styling nodig heeft, en een dia‑override alleen voor echte uitzonderingen. Overmatig gebruik van dia‑level overrides maakt latere globale thema‑wijzigingen moeilijk voorspelbaar.

## **Achtergrondstijlen van het thema bijwerken**

De achtergrond‑vullingen van het thema worden opgeslagen in [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint kan in de UI meer achtergrondkeuzes presenteren dan het aantal vullingsdefinities dat fysiek in deze collectie is opgeslagen, omdat de UI themavullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint‑achtergrondstijlgalerie voor een presentatiethema](presentation-design_8.png)

Voordat u een achtergrondstijl gebruikt, inspecteer de opgeslagen collectie en de huidige [Background::get_StyleIndex()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` gebruikt `0` voor geen themavulling; positieve waarden zijn referenties naar themabackground‑stijlen. Dit verschilt van indexeren van een C++‑collectie met `idx_get(0)`, waarbij `0` het eerste opgeslagen item betekent. Ga er niet van uit dat elke presentatie evenveel achtergrondvullingsstijlen bevat.

Het volgende voorbeeld rapporteert het aantal beschikbare achtergrondvullingen, kent een thematische achtergrondreferentie toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de thema‑entry waarnaar de master verwijst en van eventuele achtergrond‑overwrites op lay‑out‑ of dia‑niveau. Als een dia zijn eigen achtergrond gebruikt, verandert een wijziging van alleen de master‑achtergrond die dia mogelijk niet. Gebruik [Background::GetEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/background/geteffective/) wanneer u de uiteindelijke achtergrond na toepassing van overerving moet weten.

{{% alert color="warning" title="Waarschuwing" %}}

Behandel `StyleIndex` niet als een nul‑gebaseerde collectie‑index. Vermijd ook het hard‑coderen van een stijlnummer uit één bestand en ervan uitgaan dat het dezelfde weergave heeft in een ander bestand; themastijl‑definities zijn specifiek per presentatie.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Voor directe achtergrondopmaak en achtergrond‑overerving, zie [Presentation Background](/slides/nl/cpp/presentation-background/).

{{% /alert %}}

## **Thema‑effecten bijwerken**

Een thema‑formatschema bevat afzonderlijke collecties voor [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/formatscheme/get_linestyles/) en [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Typische Office‑thema’s bevatten vaak drie hoofd‑stijl‑entries die visueel overeenkomen met subtiele, gematigde en intensieve opmaak, maar code moet elke collectie inspecteren in plaats van een vast aantal aan te nemen.

![Subtiele, gematigde en intensieve thema‑effecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer u deze collecties in C++ benadert, is de index nul‑gebaseerd: `idx_get(0)` is de eerste opgeslagen stijl en `idx_get(2)` de derde. Een vorm‑style‑reference index is een apart concept, blootgelegd via [IShapeStyle](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die naar die stijl verwijzen; vormen met directe opmaak blijven ongewijzigd.

Het volgende voorbeeld controleert of de benodigde stijl‑entries bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, activeert een buitenste schaduw in de derde effectstijl, en slaat het resultaat op:

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

Voor vormen die naar deze slots verwijzen, wordt de eerste themalijnstijl rood, de derde themavulstijl een effen bosgroen, en krijgt de derde effectstijl een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat blijft afhankelijk van welke stijl‑slots elke vorm referereert en of directe opmaak de thema‑instelling overschrijft.

![Thema‑effectstijlen na wijziging van lijn, vul en schaduwinstellingen](presentation-design_11.png)

## **Effectieve themawaarden lezen**

Ruwe themobjecten vertellen u wat er op een bepaald niveau is gedefinieerd. Effectieve waarden geven aan wat een dia of vorm daadwerkelijk gebruikt nadat overerving en lokale overrides zijn verwerkt. Voor een dia roept u [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) aan. Voor een achtergrond gebruikt u [Background::GetEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/background/geteffective/), en voor een vul vlot [FillFormat::GetEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fillformat/geteffective/).

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

Gebruik effectieve gegevens voor weergavediagnostiek, validatie en vergelijkingen. Als u alleen [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_mastertheme/) inspecteert, kunt u een master‑, lay‑out‑, dia‑ of vorm‑override missen die het uiteindelijke uiterlijk verandert.

## **FAQ**

**Heeft het toepassen van een extern thema invloed op elke dia in de presentatie?**

Nee. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) wijzigt alleen de dia’s die afhankelijk zijn van de geselecteerde master. Dia’s die andere masters gebruiken, behouden hun bestaande thema’s.

**Kan ik een thema op één enkele dia toepassen zonder de master te wijzigen?**

Ja. Gebruik de dia‑[IOverrideThemeManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/ioverridethememanager/) en initialiseert zijn override‑thema. De wijziging blijft lokaal voor die dia; andere dia’s blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te brengen?**

Wanneer u een dia verplaatst en het oorspronkelijke uiterlijk wilt behouden, kloont u de bron‑master naar de doelpresentatie en kloont u de dia met die master via [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslidecollection/addclone/) en [ISlideCollection::AddClone()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/). Dit houdt de master, lay‑outs en thema samen.

**Hoe kan ik de effectieve waarden zien na overerving en overrides?**

Gebruik [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) voor een dia‑ of lay‑out‑thema en de overeenkomstige effectieve‑datamethoden voor format‑objecten zoals [Background::GetEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/background/geteffective/) en [FillFormat::GetEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fillformat/geteffective/). Deze API‑s retourneren de opgeloste waarden na toepassing van overerving en overrides.