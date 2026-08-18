---
title: Hantera presentationsteman i C++
linktitle: Presentationstema
type: docs
weight: 10
url: /sv/cpp/presentation-theme/
keywords:
- PowerPoint-tema
- presentationstema
- bildtema
- ange tema
- ändra tema
- hantera tema
- temafärg
- extra palett
- tematypsnitt
- temastil
- temaeffekt
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Masterpresentationsteman i Aspose.Slides för C++ för att skapa, anpassa och konvertera PowerPoint-filer med konsekvent varumärkesprofil."
---
## **Introduktion**

Ett presentations­tema definierar en koordinerad uppsättning färger, typsnitt, bakgrundsstilar, fyllningar, linjer och effekter. Temamedvetna objekt hänvisar till dessa delade definitioner istället för att lagra varje visuellt attribut som ett fast värde, så att ett temabyte kan uppdatera många objekt på en gång.

I Aspose.Slides är presentationens tema tillgängligt via [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_mastertheme/). En presentation kan också innehålla tema‑överskrivningar på lägre nivåer. En master kan åsidosätta presentations­temat via [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), medan en layout eller en enskild bild kan använda [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). I praktiken löses det effektiva temat för en bild genom denna arvskedja: presentationstema, master‑överskrivning, layout‑överskrivning och bild‑överskrivning.

![Tema komponenter: färger, typsnitt, bakgrundsstilar och effekter](theme-constituents.png)

Avsnitten nedan visar de vanligaste temaarbetsflödena: inspektera ett tema, ändra färger och typsnitt, kopiera eller tillämpa ett tema, uppdatera bakgrunds‑ och effektstilar samt läsa effektiva värden efter att arv och överskrivningar har lösts.

## **Inspektera ett tema**

[MasterTheme](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/mastertheme/)‑objektet exponerar temats [get_ColorScheme()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) och [get_FormatScheme()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/mastertheme/get_formatscheme/)‑metoder. Att inspektera dessa samlingar innan du ändrar dem är särskilt användbart när en presentation kommer från en extern källa eftersom antal och innehåll i stilposter kan variera.

Följande exempel läser huvudtema‑egenskaperna och rapporterar hur många bakgrunds‑, fyllnings‑, linje‑ och effekstilar som lagras i temat:

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

Om en fil använder flera masters, anta inte att varje bild har samma effektiva tema. Inspektera den master som är kopplad till bilden och använd det effektiva‑temaarbetsflöde som visas senare i artikeln när layout‑ eller bild‑överskrivningar kan finnas.

## **Ändra temafärger**

Temamedvetna fyllningar, linjer och text kan hänvisa till en logisk färg från [SchemeColor](https://reference.aspose.com/slides/sv/cpp/aspose.slides/schemecolor/)-enumerationen. När du ändrar motsvarande post i temats [IColorScheme](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/icolorscheme/), löses alla objekt som fortfarande refererar till den temafärgen mot det nya värdet. Objekt som använder en direkt RGB‑färg ändras inte av en temafärgsuppdatering.

Följande end‑to‑end‑exempel skapar en form som använder `Accent4`, ändrar temats `Accent4`‑färg till röd, sparar presentationen, öppnar den igen och skriver ut den effektiva fyllningsfärgen:

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

Eftersom rektangeln förblir länkad till `Accent4` blir dess synliga färg röd efter att temat har ändrats. Om du ersätter schemafärgen med en direkt färg på formen kommer senare förändringar av `Accent4` inte längre att påverka den fyllningen.

### **Använd färger från den extra paletten**

PowerPoint härleder ljusare och mörkare varianter från en temafärg genom att tillämpa färgtransformeringar. Aspose.Slides exponerar dessa transformeringar via [ColorTransformOperation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/colortransformoperation/).

![Huvudtema färger och ljusare och mörkare färger genererade från den extra paletten](additional-palette-colors.png)

**1** – Huvudtema färger.  

**2** – Ljusare och mörkare varianter som produceras från huvudtema färgerna.

Följande exempel skapar sex rektanglar baserade på `Accent4`, applicerar luminans‑transformeringar på fem av dem och sparar resultatet:

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

Dessa varianter förblir baserade på temafärgen. Om `Accent4` ändras senare beräknas de transformerade färgerna om från det nya `Accent4`‑värdet.

### **Mappa `SchemeColor`‑värden till `IColorScheme`‑platser**

[Sche​meColor](https://reference.aspose.com/slides/sv/cpp/aspose.slides/schemecolor/)-enumerationen använder `Text1`, `Background1`, `Text2` och `Background2`, medan [IColorScheme](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/icolorscheme/) exponerar samma temaplatser som `Dark1`, `Light1`, `Dark2` och `Light2`. Mappningen är fast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Detta är alternativa namn för samma temaplatser; de är inte värden som dynamiskt konverteras från en form till en annan.

## **Ändra tematypsnitt**

Ett tematypsnittsschema innehåller en huvudtypsnittssats för rubriker och en mindre typsnittssats för brödtext. Metoderna [FontScheme::get_Major()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/fontscheme/get_major/) och [FontScheme::get_Minor()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/fontscheme/get_minor/) exponerar dessa satser.

PowerPoint‑kompatibla tematypsnittsidentifikatorer kan användas i textformatering:

* `+mn‑lt` – Brödtext Latin (Minor Latin Font)
* `+mj‑lt` – Rubrikfont Latin (Major Latin Font)
* `+mn‑ea` – Brödtext Östasiatisk (Minor East Asian Font)
* `+mj‑ea` – Rubrikfont Östasiatisk (Major East Asian Font)

Följande exempel skapar en rubrik som använder det stora latinska tematypsnittet och en brödtextlinje som använder det mindre latinska tematypsnittet. Därefter ändras tematypsnitten och resultatet sparas:

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

Rubriken följer det stora typsnittet och brödtexten följer det mindre typsnittet. Text som har ett explicit typsnittsnamn istället för ett temaidentifierare kommer inte att byta automatiskt när tematypsnittsschemat förändras.

{{% alert color="info" title="Tip" %}}
För mer information om presentations‑typsnitt, se [PowerPoint Fonts](/slides/sv/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Kopiera eller tillämpa ett tema**

Det finns två vanliga arbetsflöden, och de löser olika problem.

### **Bevara ett källtema vid flytt av bilder**

Om du vill flytta en bild till en annan presentation och bevara dess ursprungliga design, klona käll‑mastern till mål‑presentationen med [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslidecollection/addclone/), klona sedan bilden med [ISlideCollection::AddClone()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/) och den klonade mastern. Detta för med sig mastern, dess layouter och det associerade temat tillsammans.

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

Detta är det föredragna arbetsflödet när käll‑bilden måste se identisk ut i destinationen. Att bara klona innehåll till en orelaterad destinations‑master kan förändra temadrivna färger, typsnitt, bakgrunder och effekter.

### **Tillämpa temavärden på en befintlig bild**

Om målbilder måste stanna på sin nuvarande master och layout, initiera en bild‑nivå‑överskrivning från källtemat. Metoderna [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) och [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) kopierar de tre huvudtema‑komponenterna till överskrivningen.

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

Detta ändrar temat som används av just den bilden utan att förändra temat som ärvs av andra bilder. För att ta bort den lokala överskrivningen och återgå till ärvda värden, anropa [OverrideTheme::Clear()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/overridetheme/clear/).

### **Tillämpa en tema‑överskrivning på en layout**

En layout‑nivå‑överskrivning gäller för bilder som använder den layouten, såvida inte en specifik bild har sin egen överskrivning. Samma initieringsmetoder kan användas via layoutens [IOverrideThemeManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/ioverridethememanager/):

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

Använd ett master‑ eller presentations‑tema när många layouter och bilder ska dela samma grunddesign, en layout‑överskrivning när en layoutfamilj behöver annan styling, och en bild‑överskrivning endast för egentliga undantag. Överdrivna bild‑nivå‑överskrivningar gör senare globala temaförändringar svårare att förutsäga.

## **Uppdatera temats bakgrundsstilar**

Temats bakgrundsfyllningar lagras i [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint kan presentera fler bakgrundsalternativ i sitt UI än antalet fyllningsdefinitioner som fysiskt lagras i denna samling, eftersom UI kan kombinera temafyllningar med temafärger och andra stilreferenser.

![PowerPoint bakgrundsstils galleri för ett presentations tema](presentation-design_8.png)

Innan du använder en bakgrundsstil, inspektera den lagrade samlingen och den aktuella [Background::get_StyleIndex()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` använder `0` för ingen temafyllning; positiva värden är referenser till temats bakgrundsstil. Detta skiljer sig från indexering av en C++‑samling direkt med `idx_get(0)`, där `0` betyder den första lagrade posten. Anta inte att varje presentation innehåller samma antal bakgrundsfyllningsstilar.

Följande exempel rapporterar antalet tillgängliga bakgrundsfyllningar, tilldelar en temabaserad bakgrundsreferens till den första mastern och sparar presentationen:

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

Det synliga resultatet beror på temaposten som mastern refererar till samt eventuella bakgrunds‑överskrivningar på layout‑ eller bildnivå. Om en bild använder sin egen bakgrund kanske enbart master‑bakgrundsändringen inte påverkar den bilden. Använd [Background::GetEffective()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/background/geteffective/) när du behöver veta den slutgiltiga bakgrunden efter arv.

{{% alert color="warning" title="Warning" %}}
Behandla inte `StyleIndex` som ett nollbaserat samlingsindex. Undvik också att hårdkoda ett stilnummer från en fil och anta att det har samma utseende i en annan fil; temastilsdefinitioner är presentationsspecifika.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
För direkt bakgrundsformatering och bakgrundsarv, se [Presentation Background](/slides/sv/cpp/presentation-background/).
{{% /alert %}}

## **Uppdatera temaeffekter**

Ett temats format‑schema innehåller separata samlingar för [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/formatscheme/get_linestyles/) och [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Vanliga Office‑teman innehåller ofta tre huvudstilposter som visuellt motsvarar subtil, måttlig och intensiv formatering, men kod bör inspektera varje samling istället för att anta ett fast antal.

![Diskreta, måttliga och intensiva temaeffekter tillämpade på samma form](presentation-design_10.png)

När du får åtkomst till dessa samlingar i C++ är samlingsindexet nollbaserat: `idx_get(0)` är den första lagrade stilen och `idx_get(2)` är den tredje. En forms stil‑referens‑index är ett separat koncept, exponerat via [IShapeStyle](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapestyle/). Att modifiera en temastil påverkar former som refererar till den temastilen; former med direkt formatering kan förbli oförändrade.

Följande exempel kontrollerar att de nödvändiga stilposterna finns, ändrar den första linjestilen, ändrar den tredje fyllningsstilen, aktiverar en yttre skugga i den tredje effektstilen och sparar resultatet:

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

För former som refererar till dessa platser blir den första temalinjestilen röd, den tredje temafyllningsstilen blir solid skoggrön, och den tredje effektstilen får en yttre skugga med ett avstånd på 10 punkter. Det exakta visuella resultatet beror fortfarande på vilka stilplatser varje form refererar till och om direkt formatering åsidosätter temat.

![Temaeffektstilar efter att ha ändrat linje-, fyllnings- och skugginställningar](presentation-design_11.png)

## **Läsa effektiva temavärden**

Råa temaobjekt visar vad som är definierat på en viss nivå. Effektiva värden visar vad en bild eller form faktiskt använder efter att arv och lokala överskrivningar har lösts. För en bild, anropa [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). För en bakgrund, använd [Background::GetEffective()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/background/geteffective/), och för en fyllning, använd [FillFormat::GetEffective()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fillformat/geteffective/).

Följande exempel läser det effektiva temat, bakgrunden och den första formens fyllning från en bild:

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

Använd effektiva data för renderingsdiagnostik, validering och jämförelser. Om du bara inspekterar [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_mastertheme/), kan du missa en master‑, layout‑, bild‑ eller form‑överskrivning som förändrar det slutgiltiga utseendet.

## **FAQ**

**Kan jag tillämpa ett tema på en enskild bild utan att ändra mastern?**

Ja. Använd bildens [IOverrideThemeManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/ioverridethememanager/) och initiera dess överskrivningstema. Ändringen förblir lokal för den bilden; andra bilder fortsätter att ärva sina befintliga teman.

**Vad är det säkraste sättet att föra ett tema från en presentation till en annan?**

När du flyttar en bild och bevarar dess ursprungliga utseende, klona käll‑mastern till destinationen och klona bilden med den mastern via [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslidecollection/addclone/) och [ISlideCollection::AddClone()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/). Detta behåller master, layouter och tema tillsammans.

**Hur kan jag se de effektiva värdena efter arv och överskrivningar?**

Använd [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) för en bild‑ eller layout‑tema och de motsvarande effektiva‑datametoderna för formatobjekt såsom [Background::GetEffective()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/background/geteffective/) och [FillFormat::GetEffective()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fillformat/geteffective/). Dessa API:er returnerar de lösta värdena efter att arv och överskrivningar har tillämpats.