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
- externt tema
- THMX
- temafärg
- extra palett
- temafont
- temastil
- temaeffekt
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Huvudpresentationsteman i Aspose.Slides för C++ för att skapa, anpassa och konvertera PowerPoint-filer med konsekvent varumärkesprofil."
---
## **Introduktion**

Ett presentationstema definierar en samordnad uppsättning färger, teckensnitt, bakgrundsstilar, fyllningar, linjer och effekter. Temamedvetna objekt hänvisar till dessa delade definitioner istället för att lagra varje visuellt egenskap som ett fast värde, så ett temabyte kan uppdatera många objekt på en gång.

I Aspose.Slides är temat på presentationsnivå tillgängligt via [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_mastertheme/). En presentation kan också innehålla temaarvodingar på lägre nivåer. En master kan åsidosätta presentations‑temat via [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), medan en layout eller en enskild bild kan använda [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). I praktiken löses det effektiva temat för en bild genom denna arvkedja: presentations‑tema, master‑åsidosättning, layout‑åsidosättning och bild‑åsidosättning.

![Tema komponenter: färger, teckensnitt, bakgrundsstilar och effekter](theme-constituents.png)

Avsnitten nedan visar de vanligaste temaarbetsflödena: inspektera ett tema, ändra färger och teckensnitt, kopiera eller tillämpa ett tema, uppdatera bakgrunds‑ och effektstilar samt läsa effektiva värden efter att arv och åsidosättningar har lösts.

## **Inspektera ett tema**

Objektet [MasterTheme](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/mastertheme/) exponerar temats [get_ColorScheme()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) och [get_FormatScheme()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/mastertheme/get_formatscheme/)‑metoder. Att inspektera dessa samlingar innan de ändras är särskilt användbart när en presentation kommer från en extern källa eftersom antalet och innehållet i stilposterna kan variera.

Följande exempel läser huvudtemats egenskaper och rapporterar hur många bakgrunds‑, fyllnings‑, linje‑ och effektstilar som lagras i temat:

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

Om en fil använder flera masters, anta inte att varje bild har samma effektiva tema. Inspektera den master som är associerad med bilden och använd arbetsflödet för effektiva teman som visas senare i den här artikeln när layout‑ eller bild‑åtsåtgärder kan finnas.

## **Ändra temafärger**

Temamedvetna fyllningar, linjer och text kan referera till en logisk färg från uppräkningen [SchemeColor](https://reference.aspose.com/slides/sv/cpp/aspose.slides/schemecolor/). När du ändrar motsvarande post i temats [IColorScheme](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/icolorscheme/), löses alla objekt som fortfarande refererar till den temafärgen mot det nya värdet. Objekt som använder en direkt RGB‑färg förändras inte av en temafärgsuppdatering.

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

Eftersom rektangeln förblir länkad till `Accent4` blir dess synliga färg röd efter att temat har ändrats. Om du ersätter schema‑färgen med en direkt färg på formen, kommer senare ändringar av `Accent4` inte längre att påverka den fyllningen.

### **Använd färger från den extra paletten**

PowerPoint härleder ljusare och mörkare varianter från en temafärg genom att tillämpa färgtransformeringar. Aspose.Slides exponerar dessa transformeringar via [ColorTransformOperation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/colortransformoperation/).

![Huvudtemafärger och ljusare samt mörkare färger genererade från den extra paletten](additional-palette-colors.png)

**1** – Huvudtemafärger.

**2** – Ljusare och mörkare varianter som produceras från huvudtemafärgerna.

Följande exempel skapar sex rektanglar baserade på `Accent4`, tillämpar luminans‑transformeringar på fem av dem och sparar resultatet:

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

Dessa varianter förblir baserade på temafärgen. Om `Accent4` ändras senare, beräknas de transformerade färgerna om från det nya `Accent4`‑värdet.

### **Mappa `SchemeColor`‑värden till `IColorScheme`‑platser**

Uppräkningen [SchemeColor](https://reference.aspose.com/slides/sv/cpp/aspose.slides/schemecolor/) använder `Text1`, `Background1`, `Text2` och `Background2`, medan [IColorScheme](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/icolorscheme/) exponerar samma temaplatser som `Dark1`, `Light1`, `Dark2` och `Light2`. Mappningen är fast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Detta är alternativa namn för samma temaplatser; de är inte värden som konverteras dynamiskt från en form till en annan.

## **Ändra temateckensnitt**

Ett temateckensnittsschema innehåller en huvudteckensnittssamling för rubriker och en mindre teckensnittssamling för brödtext. Metoderna [FontScheme::get_Major()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/fontscheme/get_major/) och [FontScheme::get_Minor()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/fontscheme/get_minor/) exponerar dessa samlingar.

PowerPoint‑kompatibla temateckensnittsidentifierare kan användas i textformatering:

* `+mn-lt` – Brödtext Latin (Minor Latin Font)
* `+mj-lt` – Rubrikfont Latin (Major Latin Font)
* `+mn-ea` – Brödtext Östasien (Minor East Asian Font)
* `+mj-ea` – Rubrikfont Östasien (Major East Asian Font)

Följande exempel skapar en rubrik som använder det stora Latin‑temateckensnittet och en brödtextrad som använder det mindre Latin‑temateckensnittet. Därefter ändras temateckensnitten och resultatet sparas:

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

Rubriken följer det stora teckensnittet och brödtexten följer det mindre teckensnittet. Text som har ett explicit teckensnittsnamn i stället för en temidentifierare byter inte automatiskt när temateckensnittsschemat ändras.

De stora och små teckensnittssamlingarna kan också innehålla teckensnittsmappningar för enskilda skriftsystem, såsom kyrilliska, arabiska, japanska, georgiska och thaana. För att inspektera, lägga till, ersätta eller ta bort dessa mappningar, se [Script‑Specific Theme Fonts](/slides/sv/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

För mer information om presentations‑teckensnitt, se [PowerPoint Fonts](/slides/sv/cpp/powerpoint-fonts/).

{{% /alert %}}

## **Kopiera eller tillämpa ett tema**

Arbetsflödena nedan löser olika temarelaterade problem.

### **Tillämpa ett externt tema på en masters beroende bilder**

Använd [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) när du har en PowerPoint‑temafil (`.thmx`) och vill omstyla varje bild som beror på en viss master. Välj mastern från samlingen [Presentation::get_Masters](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_masters/), som implementerar [IMasterSlideCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslidecollection/), och skicka temafilens sökväg till metoden.

Metoden utför följande operationer:

1. Skapar en ny master‑bild baserad på den valda mastern.
1. Tillämpar det externa temat på den nya mastern.
1. Tilldelar den nya mastern till alla bilder som tidigare berodde på den valda mastern.
1. Returnerar den nyskapade [IMasterSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslide/).

Följande exempel tillämpar ett externt tema på de bilder som beror på den första mastern och sparar presentationen:

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

Ett ogiltigt, korrupt eller ej stödd tema kan orsaka [PptxException](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pptxexception/) eller någon av dess formatrelaterade underklasser. Validera sökvägar som tillhandahålls av användare, hantera misslyckade filsystemstillträden och spara presentationen först när temat har tillämpats framgångsrikt.

Endast de bilder som berodde på den valda mastern omfördelas. Bilder som är associerade med andra masters behåller sina befintliga masters och teman. Temamedvetna färger, teckensnitt, fyllningar, linjer, bakgrunder och effekter löses mot det externa temat. Direkt tilldelade färger, teckensnitt, fyllningar och annan explicit formatering kan förbli oförändrade. Override‑nivåer på layout‑ och bildnivå kan också ha företräde framför värden som ärvts från den nya mastern.

Temat kan referera till teckensnitt som inte finns i körningsmiljön. För konsistent rendering och export, installera de nödvändiga teckensnitten, tillhandahåll dem via [custom font sources](/slides/sv/cpp/custom-font/), eller konfigurera [font substitution](/slides/sv/cpp/font-substitution/).

Detta är ett direkt master‑nivå‑arbetsflöde: metoden accepterar en filsökväg till en `.thmx`‑fil och kräver inte att du manuellt skapar overrides på bild‑ eller layout‑nivå.

### **Tillämpa olika externa teman i en multi‑master‑presentation**

När den relevanta mastern inte är känd i förväg, erhåll den från en representativ bild via [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/get_layoutslide/) och [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutslide/get_masterslide/). Spara de ursprungliga master‑referenserna innan du tillämpar några teman, eftersom varje anrop skapar en ny master i presentationen.

Följande exempel använder bilder från två sektioner för att lokalisera deras masters och tillämpar ett olika externt tema på varje grupp:

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

Det första anropet påverkar endast de bilder som berodde på `firstGroupMaster`, och det andra anropet påverkar endast de bilder som berodde på `secondGroupMaster`. Bilder som tillhör någon annan master omstylar inte.

### **Bevara ett källtema vid flytt av bilder**

Om du vill flytta en bild till en annan presentation och bevara dess ursprungliga design, klona källmastern till mål‑presentationen med [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslidecollection/addclone/), klona sedan bilden med [ISlideCollection::AddClone()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/) och den klonade mastern. Detta för med master, dess layouter och det associerade temat tillsammans.

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

Detta är det föredragna arbetsflödet när källbilden måste se likadan ut i destinationen. Att bara klona innehåll till en orelaterad destinations‑master kan ändra temadrivna färger, teckensnitt, bakgrunder och effekter.

### **Tillämpa temavärden på en befintlig bild**

Om målbilden måste förbli på sin nuvarande master och layout, initiera en bild‑nivå‑override från källtemat. Metoderna [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) och [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) kopierar de tre huvudtema‑komponenterna till override‑temat.

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

Detta ändrar temat som den bilden använder utan att ändra temat som ärvs av andra bilder. För att ta bort den lokala override‑en och återgå till ärvda värden, anropa [OverrideTheme::Clear()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/overridetheme/clear/).

### **Tillämpa ett temaarv på en layout**

En layout‑nivå‑override gäller för bilder som använder den layouten, såvida inte en specifik bild har sin egen override. Samma initieringsmetoder kan användas via layoutens [IOverrideThemeManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/ioverridethememanager/):

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

Använd ett master‑ eller presentations‑tema när många layouter och bilder ska dela samma grunddesign, en layout‑override när en layout‑familj behöver annan styling, och en bild‑override endast för verkliga undantag. Överdrivna bild‑level‑overrides gör senare globala temaförändringar svårare att förutsäga.

## **Uppdatera temats bakgrundsstilar**

Temats bakgrundsfyllningar lagras i [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint kan presentera fler bakgrundsalternativ i sitt UI än antalet fyllningsdefinitioner som fysiskt lagras i denna samling, eftersom UI kan kombinera temafyllningar med temafärger och andra stilreferenser.

![PowerPoint bakgrundsstilsgalleri för ett presentations‑tema](presentation-design_8.png)

Innan du använder en bakgrundsstil, inspektera den lagrade samlingen och den aktuella [Background::get_StyleIndex()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` använder `0` för ingen temafyllning; positiva värden är temabakgrund‑stilreferenser. Detta skiljer sig från att indexera en C++‑samling direkt med `idx_get(0)`, där `0` betyder det första lagrade objektet. Anta inte att varje presentation innehåller samma antal bakgrundsfyllningsstilar.

Följande exempel rapporterar antalet tillgängliga bakgrundsfyllningar, tilldelar en temabakgrundsreferens till den första mastern och sparar presentationen:

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

Det synliga resultatet beror på temapostens referens som mastern pekar på samt eventuella bakgrundsoverrides på layout‑ eller bildnivå. Om en bild använder sin egen bakgrund kan en ändring av enbart master‑bakgrunden misslyckas med att ändra den bilden. Använd [Background::GetEffective()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/background/geteffective/) när du behöver veta den slutgiltiga bakgrunden efter arv har tillämpats.

{{% alert color="warning" title="Warning" %}}

Behandla inte `StyleIndex` som ett nollbaserat samlingsindex. Undvik också att hårdkoda ett stilnummer från en fil och anta att det har samma utseende i en annan fil; temastildefinitioner är presentationsspecifika.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

För direkt bakgrundsformatering och bakgrundsarv, se [Presentation Background](/slides/sv/cpp/presentation-background/).

{{% /alert %}}

## **Uppdatera temaeffekter**

Ett temas format‑schema innehåller separata samlingar för [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/formatscheme/get_linestyles/) och [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Vanliga Office‑teman innehåller ofta tre huvudstilsposter som visuellt motsvarar subtil, måttlig och intensiv formatering, men kod bör inspektera varje samling istället för att anta ett fast antal.

![Subtila, måttliga och intensiva temaeffekter som tillämpas på samma form](presentation-design_10.png)

När du åtkommer till dessa samlingar i C++ är samlingsindexet nollbaserat: `idx_get(0)` är den första lagrade stilen och `idx_get(2)` är den tredje. En forms stilreferens‑index är ett separat koncept, exponerat via [IShapeStyle](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapestyle/). Att modifiera en temastil påverkar former som refererar till den temastilen; former med direkt formatering kan förbli oförändrade.

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

För former som refererar till dessa platser blir den första temalinjestilen röd, den tredje temafyllningsstilen blir solid skoggrön, och den tredje effektstilen får en yttre skugga med ett avstånd på 10 punkter. Det exakta visuella resultatet beror fortfarande på vilka stilplatser varje form refererar till och huruvida direkt formatering åsidosätter temat.

![Temaeffektstilar efter ändring av linje, fyllning och skugga](presentation-design_11.png)

## **Bestäm om en effektiv solid fyllning använder en temafärg**

En fyllning kan lagras direkt på ett objekt eller ärvas från ett stycke, en layout, en master, en temastil eller en annan formateringsnivå. Anropa [IFillFormat::GetEffective](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifillformat/geteffective/) för att lösa den hierarkin till en oföränderlig [IFillFormatEffectiveData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifillformateffectivedata/). Kontrollera först [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifillformateffectivedata/get_filltype/). Endast när den är `FillType::Solid` bör du läsa solid‑fyllningsegenskaperna.

För en solid fyllning returnerar [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) det slutliga renderade RGB‑värdet efter arv, temauppsökning och färgtransformeringar. [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) returnerar motsvarande logiska [SchemeColor](https://reference.aspose.com/slides/sv/cpp/aspose.slides/schemecolor/)‑slot, såsom `Text1` eller `Accent6`. Ett värde `SchemeColor::NotDefined` betyder att den effektiva solida fyllningen inte bygger på en schema‑färg. I ett arbetsflöde där fyllningar antingen är temafärger eller direkta RGB‑färger identifierar detta värde en direkt RGB‑fyllning.

Använd inte enbart det lokala värdet från [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icolorformat/get_schemecolor/) för att klassificera en fyllning. Till exempel kan en textdel sakna lokalt definierad schema‑färg, så dess lokala värde är `NotDefined`, men dess effektiva fyllning ärvs från ett temafärg och löser till `Text1` eller `Accent6`. Omvänt visar `get_SolidFillSchemeColor` vilken logisk temaplatsslot som producerade den effektiva färgen, men den säger inte om den slottet kom från objektet, stycket, layouten, mastern eller någon annan nivå i formateringshierarkin.

Följande exempel laddar en presentation, granskar både form‑fyllningar och text‑del‑fyllningar, skriver ut varje slutgiltigt RGB‑värde och tillhörande schema‑färg, och flaggar solida fyllningar som inte följer temafärgförändringar:

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

Grenen `NotDefined` ger en granskningslista över solida fyllningar som inte kommer att reagera på förändringar i temafärgs‑slottar. Granska dessa objekt när en presentation måste följa en ny varumärkes‑palett. Det rapporterade RGB‑värdet visar fortfarande det aktuella utseendet, medan schema‑värdet förklarar om utseendet är kopplat till temat.

Effektiva format‑objekt är ögonblicksbilder. Efter att ha ändrat presentations‑temat, en temaarv eller någon ärvd formatering, anropa `GetEffective` igen och läs ett nytt `IFillFormatEffectiveData`‑objekt innan du jämför eller rapporterar färger.

## **Läs effektiva temavärden**

Råa temaobjekt visar vad som är definierat på en viss nivå. Effektiva värden visar vad en bild eller form faktiskt använder efter att arv och lokala åsidosättningar har lösts. För en bild, anropa [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). För en bakgrund, använd [Background::GetEffective()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/background/geteffective/), och för en fyllning, använd [FillFormat::GetEffective()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fillformat/geteffective/).

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

Använd effektiva data för renderingsdiagnostik, validering och jämförelser. Om du endast inspekterar [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_mastertheme/), kan du missa en master‑, layout‑, bild‑ eller form‑override som förändrar det slutgiltiga utseendet.

## **FAQ**

**Påverkar tillämpning av ett externt tema varje bild i presentationen?**

Nej. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) omfördelar endast de bilder som beror på den valda mastern. Bilder som använder andra masters behåller sina befintliga teman.

**Kan jag tillämpa ett tema på en enstaka bild utan att ändra mastern?**

Ja. Använd bildens [IOverrideThemeManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/ioverridethememanager/) och initiera dess override‑tema. Ändringen förblir lokal för den bilden; andra bilder fortsätter att ärva sina befintliga teman.

**Vad är det säkraste sättet att föra ett tema från en presentation till en annan?**

När du flyttar en bild och bevarar dess källutseende, klona källmastern till destinationen och klona bilden med den mastern med hjälp av [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslidecollection/addclone/) och [ISlideCollection::AddClone()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/). Detta behåller master, layouter och tema tillsammans.

**Hur kan jag se de effektiva värdena efter arv och åsidosättningar?**

Använd [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) för en bild eller layout‑tema samt motsvarande effektiva‑datametoder för formatobjekt såsom [Background::GetEffective()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/background/geteffective/) och [FillFormat::GetEffective()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fillformat/geteffective/). Dessa API:er returnerar de lösta värdena efter att arv och åsidosättningar har tillämpats.