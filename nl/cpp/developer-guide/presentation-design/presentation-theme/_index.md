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
- extra palet
- themalettertype
- themastijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheer presentatiethema's in Aspose.Slides voor C++ om PowerPoint-bestanden te maken, aanpassen en converteren met consistente branding."
---
## **Inleiding**

Een presentatiethema definieert een gecoördineerde verzameling van kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Theme‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een themawijziging veel objecten in één keer kan bijwerken.

In Aspose.Slides is het themaniveau van de presentatie beschikbaar via [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_mastertheme/). Een presentatie kan ook themabewijzigingen op lagere niveaus bevatten. Een master kan het presentatiethema overschrijven via [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), terwijl een lay‑out of een individuele dia [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) kan gebruiken. In de praktijk wordt het effectieve thema voor een dia opgelost via deze overervingsketen: presentatiethema, master‑override, lay‑out‑override en dia‑override.

![Themagebieden: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De onderstaande secties tonen de meest voorkomende themaworkflows: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat overerving en overrides zijn verwerkt.

## **Een Thema Inspecteren**

Het [MasterTheme](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/mastertheme/)‑object biedt de methoden [get_ColorScheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) en [get_FormatScheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Het inspecteren van deze collecties voordat ze worden gewijzigd, is vooral nuttig wanneer een presentatie uit een externe bron komt, omdat het aantal en de inhoud van stijl‑items kunnen variëren.

Het volgende voorbeeld leest de belangrijkste themaeigenschappen en meldt hoeveel achtergrond‑, vul‑, lijn‑ en effectstijlen in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, ga er dan niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort, en gebruik de effectieve‑thema‑workflow die later in dit artikel wordt getoond wanneer lay‑out‑ of dia‑overrides aanwezig kunnen zijn.

## **Themakleuren Wijzigen**

Theme‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/schemecolor/)‑enumeratie. Wanneer u de overeenkomstige entry in de [IColorScheme](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/icolorscheme/) van het thema wijzigt, worden alle objecten die nog steeds naar die themakleur verwijzen, bijgewerkt met de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet gewijzigd door een themakleur‑update.

Het volgende end‑to‑end‑voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de themakleur `Accent4` naar rood, slaat de presentatie op, opent deze opnieuw, en drukt de effectieve vulkleur af:

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

Omdat het rechthoek nog steeds gekoppeld is aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Als u de scheme‑color vervangt door een directe kleur op de vorm, hebben latere wijzigingen aan `Accent4` geen effect meer op die vul.

### **Kleuren uit het Extra Palet Gebruiken**

PowerPoint genereert lichtere en donkerdere varianten van een themakleur door kleurovergangen toe te passen. Aspose.Slides maakt deze overgangen beschikbaar via [ColorTransformOperation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/colortransformoperation/).

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren gegenereerd uit het extra palet](additional-palette-colors.png)

**1** - Hoofdkleuren van het thema.  
**2** - Lichtere en donkerdere varianten gegenereerd uit de hoofdkleuren.

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

### **`SchemeColor`‑Waarden Toewijzen aan `IColorScheme`‑Slots**

De [SchemeColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/schemecolor/)‑enumeratie gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl [IColorScheme](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/icolorscheme/) dezelfde themaslots exposeert als `Dark1`, `Light1`, `Dark2` en `Light2`. De mapping is vast:

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaslots; het zijn geen waarden die dynamisch van de ene vorm naar de andere worden geconverteerd.

## **Themale Lettertypen Wijzigen**

Een thema‑lettertype‑schema bevat een hoofdlettertype‑set voor koppen en een secundaire lettertype‑set voor de hoofdtekst. De methoden [FontScheme::get_Major()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/fontscheme/get_major/) en [FontScheme::get_Minor()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/fontscheme/get_minor/) exposeren die sets.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen worden gebruikt bij tekstopmaak:

* `+mn-lt` - Body Font Latin (Minor Latin Font)  
* `+mj-lt` - Heading Font Latin (Major Latin Font)  
* `+mn-ea` - Body Font East Asian (Minor East Asian Font)  
* `+mj-ea` - Heading Font East Asian (Major East Asian Font)

Het volgende voorbeeld maakt één kop die het hoofd‑Latin‑themale lettertype gebruikt en één body‑regel die het secundaire Latin‑themale lettertype gebruikt. Het wijzigt vervolgens de thema‑lettertypen en slaat het resultaat op:

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

De kop volgt het hoofdlettertype en de body‑tekst volgt het secundaire lettertype. Tekst die een expliciete lettertype‑naam heeft in plaats van een thema‑identifier, zal niet automatisch wisselen wanneer het thema‑lettertype‑schema verandert.

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatietekst, zie [PowerPoint Fonts](/slides/nl/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Een Thema Kopiëren of Toepassen**

Er zijn twee veelvoorkomende workflows, en ze lossen verschillende problemen op.

### **Een Bron‑Thema Behouden bij het Verplaatsen van Dia’s**

Wilt u een dia naar een andere presentatie verplaatsen en het oorspronkelijke ontwerp behouden, kloon dan de bron‑master in de doelpresentatie met [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslidecollection/addclone/), en kloon daarna de dia met [ISlideCollection::AddClone()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) en de gekloonde master. Hierdoor worden de master, zijn lay‑outs en het bijbehorende thema samen meegenomen.

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

Dit is de aanbevolen workflow wanneer de bron‑dia er in de bestemming precies hetzelfde uit moet zien. Het simpelweg klonen van inhoud op een niet‑gerelateerde doel‑master kan themagestuurde kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑Waarden Toepassen op een Bestaande Dia**

Moet de doel‑dia op zijn huidige master en lay‑out blijven, initialiseert u een dia‑niveau‑override vanuit het bron‑thema. De methoden [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) en [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) kopiëren de drie hoofd‑thema‑componenten naar de override.

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

Dit wijzigt het thema dat door die dia wordt gebruikt zonder het door andere dia’s geërfde thema te veranderen. Om de lokale override te verwijderen en terug te gaan naar geërfde waarden, roep [OverrideTheme::Clear()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/overridetheme/clear/) aan.

### **Een Thema‑Override Toepassen op een Lay‑out**

Een lay‑out‑niveau‑override geldt voor dia’s die die lay‑out gebruiken, tenzij een specifieke dia een eigen override heeft. Dezelfde initialisatiemethoden kunnen via de lay‑out‑[IOverrideThemeManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/ioverridethememanager/) worden aangeroepen:

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

Gebruik een master‑ of presentatieniveau‑thema wanneer veel lay‑outs en dia’s hetzelfde basisonwerp moeten delen, een lay‑out‑override wanneer één lay‑outfamilie een andere styling nodig heeft, en een dia‑override alleen voor echte uitzonderingen. Overmatige dia‑niveau‑overrides maken latere globale themawijzigingen moeilijker te voorspellen.

## **Achtergrondstijlen van het Thema Bijwerken**

De achtergrondvullingen van het thema worden opgeslagen in [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint kan in de UI meer achtergrondkeuzes presenteren dan het aantal vuldefinities dat fysiek in deze collectie is opgeslagen, omdat de UI themavullingen kan combineren met themakleuren en overige stijl‑referenties.

![PowerPoint‑achtergrondstijlgallerij voor een presentatiethema](presentation-design_8.png)

Voordat u een achtergrondstijl gebruikt, inspecteer de opgeslagen collectie en de huidige [Background::get_StyleIndex()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` gebruikt `0` voor geen themavulling; positieve waarden zijn referenties naar themabackground‑stijlen. Dit verschilt van het indexeren van een C++‑collectie met `idx_get(0)`, waarbij `0` het eerste opgeslagen item betekent. Ga niet ervan uit dat elke presentatie evenveel achtergrondvullingsstijlen bevat.

Het volgende voorbeeld meldt het beschikbare aantal achtergrondvullingen, kent een thematische achtergrondreferentie toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de themareferentie die door de master wordt gebruikt en van eventuele achtergrond‑overrides op lay‑out‑ of dia‑niveau. Als een dia zijn eigen achtergrond heeft, kan het wijzigen van alleen de master‑achtergrond die dia niet beïnvloeden. Gebruik [Background::GetEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/background/geteffective/) wanneer u de uiteindelijke achtergrond na overerving wilt weten.

{{% alert color="warning" title="Waarschuwing" %}}
Beschouw `StyleIndex` niet als een nul‑gebaseerde collectiesindex. Vermijd ook hard‑coderen van een stelnummer uit één bestand en aannemen dat het dezelfde weergave heeft in een ander bestand; themastijl‑definities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑overerving, zie [Presentation Background](/slides/nl/cpp/presentation-background/).
{{% /alert %}}

## **Thema‑Effecten Bijwerken**

Een thema‑format‑schema bevat afzonderlijke collecties voor [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/formatscheme/get_linestyles/) en [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Typische Office‑thema’s bevatten vaak drie hoofd‑stijl‑items die visueel overeenkomen met subtiele, matige en intense opmaak, maar de code moet elke collectie inspecteren in plaats van een vast aantal aan te nemen.

![Subtiele, matige en intense themaeffecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer u deze collecties in C++ benadert, is de collectie‑index nul‑gebaseerd: `idx_get(0)` is de eerste opgeslagen stijl en `idx_get(2)` de derde. Een vorm‑stijl‑referentie‑index is een apart concept, blootgelegd via [IShapeStyle](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die themastijl refereren; vormen met directe opmaak kunnen ongewijzigd blijven.

Het volgende voorbeeld controleert of de vereiste stijl‑items bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, schakelt een buitenste schaduw in bij de derde effectstijl, en slaat het resultaat op:

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

Voor vormen die deze slots refereren, wordt de eerste themalijnstijl rood, de derde themavulstijl een effen bosgroen, en krijgt de derde effectstijl een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat blijft afhangen van welke stijl‑slots elke vorm referereert en of directe opmaak de themastijl overschrijft.

![Thema‑effectstijlen na wijziging van lijn, vul en schaduwinstellingen](presentation-design_11.png)

## **Effectieve Thema‑Waarden Lezen**

Ruwe thema‑objecten vertellen wat er op een bepaald niveau is gedefinieerd. Effectieve waarden vertellen wat een dia of vorm daadwerkelijk gebruikt nadat overerving en lokale overrides zijn verwerkt. Voor een dia, roep [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) aan. Voor een achtergrond, gebruik [Background::GetEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/background/geteffective/), en voor een vul, gebruik [FillFormat::GetEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fillformat/geteffective/).

Het volgende voorbeeld leest het effectieve thema, de achtergrond, en de eerste vormvulling van een dia:

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

Gebruik effectieve data voor weergavediagnostiek, validatie en vergelijkingen. Als u alleen [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_mastertheme/) inspecteert, kunt u een master‑, lay‑out‑, dia‑ of vorm‑override missen die het uiteindelijke uiterlijk wijzigt.

## **FAQ**

**Kan ik een thema toepassen op één dia zonder de master te wijzigen?**

Ja. Gebruik de dia‑[IOverrideThemeManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/ioverridethememanager/) en initialiseert zijn override‑thema. De wijziging blijft lokaal voor die dia; andere dia’s blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

Wanneer u een dia verplaatst en het bron‑ontwerp wilt behouden, kloont u de bron‑master naar de bestemming en kloont u de dia met die master via [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslidecollection/addclone/) en [ISlideCollection::AddClone()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/). Hiermee blijven master, lay‑outs en thema samen.

**Hoe kan ik de effectieve waarden zien na overerving en overrides?**

Gebruik [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) voor een dia‑ of lay‑out‑thema en de corresponderende effectieve‑data‑methoden voor format‑objecten zoals [Background::GetEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/background/geteffective/) en [FillFormat::GetEffective()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fillformat/geteffective/). Deze API’s geven de opgeloste waarden terug nadat overerving en overrides zijn toegepast.