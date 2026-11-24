---
title: Hantera presentationstema i C++
linktitle: Presentationstema
type: docs
weight: 10
url: /sv/cpp/presentation-theme/
keywords:
- PowerPoint-tema
- presentationstema
- bildtema
- sätt tema
- ändra tema
- hantera tema
- externt tema
- THMX
- temafärg
- extra palett
- temateckensnitt
- temastil
- temaeffekt
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Behärska presentationsteman i Aspose.Slides för C++ för att skapa, anpassa och konvertera PowerPoint-filer med konsekvent varumärkesprofil."
---
## **Introduktion**

Ett presentationstema definierar en koordinerad uppsättning färger, teckensnitt, bakgrundsstilar, fyllningar, linjer och effekter. Temamedvetna objekt hänvisar till dessa delade definitioner istället för att lagra varje visuellt egenskap som ett fast värde, så en temaförändring kan uppdatera många objekt på en gång.

I Aspose.Slides är presentationens tema på presentationsnivå tillgängligt via [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/). En presentation kan också innehålla temaarbeten på lägre nivåer. En master kan åsidosätta presentations‑temat via [MasterThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), medan en layout eller en enskild bild kan använda [IOverrideThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). I praktiken löses det effektiva temat för en bild upp genom denna arvskedja: presentationstema, master‑åsidosättning, layout‑åsidosättning och bild‑åsidosättning.

![Temakomponenter: färger, teckensnitt, bakgrundsstilar och effekter](theme-constituents.png)

Avsnitten nedan visar de vanligaste temaarbetssätten: inspektera ett tema, ändra färger och teckensnitt, kopiera eller tillämpa ett tema, uppdatera bakgrunds- och effektstilar samt läsa effektiva värden efter att arv och åsidosättningar har lösts.

## **Inspektera ett tema**

Objektet [MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/) exponerar temats [get_ColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) och [get_FormatScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) metoder. Att inspektera dessa samlingar innan du ändrar dem är särskilt användbart när en presentation kommer från en extern källa eftersom antal och innehåll i stilposter kan variera.

Följande exempel läser huvudtemapropärterna och rapporterar hur många bakgrunds-, fyllnings-, linje‑ och effektstilar som lagras i temat:

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

Om en fil använder flera masters, anta inte att varje bild har samma effektiva tema. Inspektera den master som är associerad med bilden, och använd det effektiva temaarbetssätt som visas senare i den här artikeln när layout‑ eller bild‑åsidosättningar kan finnas.

## **Ändra temafärger**

Temamedvetna fyllningar, linjer och text kan referera till en logisk färg från [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/)‑enumerationen. När du ändrar motsvarande post i temats [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/), löses alla objekt som fortfarande refererar till den temafärgen mot det nya värdet. Objekt som använder en direkt RGB‑färg ändras inte av en temafärgsuppdatering.

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

Eftersom rektangeln fortfarande är länkad till `Accent4` blir dess synliga färg röd efter att temat ändrats. Om du ersätter schemafärgen med en direkt färg på formen kommer senare ändringar av `Accent4` inte längre påverka den fyllningen.

### **Använd färger från den extra paletten**

PowerPoint härleder ljusare och mörkare varianter från en temafärg genom att applicera färgtransformeringar. Aspose.Slides exponerar dessa transformationer via [ColorTransformOperation](https://reference.aspose.com/slides/cpp/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Huvudtemafärger.  
**2** - Ljusare och mörkare varianter skapade från huvudtemafärgerna.

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

Dessa varianter förblir baserade på temafärgen. Om `Accent4` ändras senare, beräknas de transformerade färgerna om från det nya `Accent4`‑värdet.

### **Mappa `SchemeColor`‑värden till `IColorScheme`‑platser**

[SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/)‑enumerationen använder `Text1`, `Background1`, `Text2` och `Background2`, medan [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) exponerar samma temaplatser som `Dark1`, `Light1`, `Dark2` och `Light2`. Mappningen är fast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Detta är alternativa namn för samma temaplatser; de är inte värden som dynamiskt konverteras från en form till en annan.

## **Ändra temateckensnitt**

Ett temateckensnittsschema innehåller en huvudteckensnittssats för rubriker och en mindre teckensnittssats för brödtext. Metoderna [FontScheme::get_Major](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_major/) och [FontScheme::get_Minor](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_minor/) exponerar dessa satser.

PowerPoint‑kompatibla temateckensnittsidentifierare kan användas i textformatering:

* `+mn-lt` - Brödtextteckensnitt Latin (Minor Latin Font)
* `+mj-lt` - Rubrikteckensnitt Latin (Major Latin Font)
* `+mn-ea` - Brödtextteckensnitt Östasiatiskt (Minor East Asian Font)
* `+mj-ea` - Rubrikteckensnitt Östasiatiskt (Major East Asian Font)
* `+mn-cs` - Brödtextteckensnitt Komplex Skript (Minor Complex Script Font)
* `+mj-cs` - Rubrikteckensnitt Komplex Skript (Major Complex Script Font)

Följande exempel skapar en rubrik som använder det stora Latin‑temateckensnittet och en brödtextlinje som använder det lilla Latin‑temateckensnittet. Det ändrar sedan temateckensnitten och sparar resultatet:

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

Rubriken följer det stora teckensnittet och brödtexten följer det lilla teckensnittet. Text som har ett explicit teckensnittsnamn istället för en temaidentifierare kommer inte automatiskt att bytas när temateckensnittsschemat ändras.

De stora och små teckensnittssamlingarna kan också innehålla teckensnittsmappningar för enskilda skriftsystem, såsom Kyrilliska, Arabiska, Japanska, Georgiska och Thaana. För att inspektera, lägga till, ersätta eller ta bort dessa mappningar, se [Script‑Specific Theme Fonts](/slides/sv/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
För mer information om presentationsteckensnitt, se [PowerPoint Fonts](/slides/sv/cpp/powerpoint-fonts/).
{{% /alert %}}

### **Lösa temateckensnittreferenser**

När du inspekterar text kan [IFontData::get_FontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/get_fontname/) innehålla en temareferens som `+mn-lt` istället för ett teckensnittsfamiljenamn. Anropa [IFontData::GetFontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/getfontname/) med lämplig [IThemeEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeeffectivedata/) för att lösa den referensen. Prefixen `+mj` och `+mn` väljer de stora respektive små teckensnittssatserna; suffixen `-lt`, `-ea` och `-cs` väljer deras Latin, Östasiatiska och Komplexa skript‑teckensnitt, respektive.

Hämta det effektiva temat via [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) på objektet vars tema gäller för den inspekterade texten. För vanlig text på en bild, använd `slide->CreateThemeEffective()` så att kontexten inkluderar bildens ärvda tema och lokala åsidosättningar. När du inspekterar en layout eller master själv, använd dess eget effektiva tema. Anta inte att den första masterns tema gäller för varje bild.

Följande exempel skapar en textdel som explicit refererar till det lilla Latin‑teckensnittet. Det initierar en bildteckensnittsschema via [IOverrideTheme::InitFontSchemeFromInherited](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) och sätter de stora och små Latin‑familjerna till `Arial` och `Calibri`, vilket gör resultatet reproducerbart utan en indatafil.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto theme = slide->get_ThemeManager()->get_OverrideTheme();
theme->InitFontSchemeFromInherited();
theme->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Arial"));
theme->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Calibri"));

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 60.0f);
shape->get_TextFrame()->set_Text(u"Text using the minor theme font");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

auto font = portion->get_PortionFormat()->get_LatinFont();
auto effectiveTheme = slide->CreateThemeEffective();
auto resolvedFontName = font->GetFontName(effectiveTheme);
Console::WriteLine(u"{0} -> {1}", font->get_FontName(), resolvedFontName);

auto explicitFont = MakeObject<FontData>(u"Verdana");
auto explicitFontName = explicitFont->GetFontName(effectiveTheme);
Console::WriteLine(u"{0} -> {1}", explicitFont->get_FontName(), explicitFontName);
```

Resultatet är `+mn-lt -> Calibri` följt av `Verdana -> Verdana`. Den lagrade referensen förblir oförändrad, medan ett explicit familjenamn returneras som det är. Om delen använde `+mj-lt` skulle den lösa till `Arial` i detta tema.

Att lösa en temareferens identifierar den teckensnittsfamilj som temat specificerar. Det kontrollerar inte teckensnittstillgänglighet eller avgör vilken teckensnittfil som slutligen används efter ersättning eller teckenfallback under rendering. Se [Font Selection Sequence](/slides/sv/cpp/font-selection-sequence/) och [Font Substitution](/slides/sv/cpp/font-substitution/) för dessa separata steg.

## **Kopiera eller tillämpa ett tema**

Arbetssätten nedan löser olika temarelaterade problem.

### **Tillämpa ett externt tema på en masters beroende bilder**

Använd [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) när du har en PowerPoint‑temafil (`.thmx`) och vill omstyla varje bild som beror på en viss master. Välj masteren från [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/)‑samlingen, som implementerar [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/), och skicka temafilens sökväg till metoden.

Metoden utför följande åtgärder:

1. Skapar en ny master‑bild baserad på den valda masteren.
1. Tillämpar det externa temat på den nya masteren.
1. Tilldelar den nya masteren till alla bilder som tidigare berodde på den valda masteren.
1. Returnerar den nyskapade [IMasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/).

Följande exempel tillämpar ett externt tema på de bilder som beror på den första masteren och sparar presentationen:

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

Ett ogiltigt, korrupt eller ej stödd tema kan orsaka [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/) eller någon av dess formatrelaterade underklasser. Validera sökvägar som tillhandahålls av användare, hantera filsystemsåtkomstfel, och spara presentationen först när temat har tillämpats framgångsrikt.

Endast de bilder som berodde på den valda masteren återtilldelas. Bilder som är associerade med andra masters behåller sina befintliga masters och teman. Temamedvetna färger, teckensnitt, fyllningar, linjer, bakgrunder och effekter löses mot det externa temat. Direkt tilldelade färger, teckensnitt, fyllningar och annan explicit formatering kan förbli oförändrade. Åsidosättningar på layout‑ och bildnivå kan också ha företräde framför värden som ärvts från den nya masteren.

Temat kan referera till teckensnitt som inte är tillgängliga i körmiljön. För konsekvent rendering och export, installera de nödvändiga teckensnitten, tillhandahåll dem via [custom font sources](/slides/sv/cpp/custom-font/), eller konfigurera [font substitution](/slides/sv/cpp/font-substitution/).

Detta är ett direkt master‑nivåarbetsflöde: metoden accepterar en filsökväg till en `.thmx`‑fil och kräver inte att man manuellt skapar temåsidosättningar på bild‑ eller layoutnivå.

### **Tillämpa olika externa teman i en multi‑master‑presentation**

När den relevanta masteren inte är känd i förväg, hämta den från en representativ bild via [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) och [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_masterslide/). Spara de ursprungliga masterreferenserna innan du tillämpar några teman eftersom varje anrop skapar ytterligare en master i presentationen.

Följande exempel använder bilder från två sektioner för att lokalisera deras masters och tillämpar ett annat externt tema på varje grupp:

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

Det första anropet påverkar endast de bilder som berodde på `firstGroupMaster`, och det andra anropet påverkar endast de bilder som berodde på `secondGroupMaster`. Bilder som tillhör någon annan master omstylas inte.

### **Bevara ett källtema vid flytt av bilder**

Om du vill flytta en bild till en annan presentation och bevara dess ursprungliga design, klona källmasteren till målpresentationen med [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/), klona sedan bilden med [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) och den klonade masteren. Detta tar med masteren, dess layouter och det associerade temat tillsammans.

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

Detta är det föredragna arbetsflödet när källbilden måste se likadan ut i destinationen. Att bara klona innehåll till en orelaterad målmaster kan ändra temadrivna färger, teckensnitt, bakgrunder och effekter.

### **Tillämpa temavärden på en befintlig bild**

Om målbilden måste behålla sin nuvarande master och layout, initiera en bildnivååsidosättning från källtemat. Metoderna [OverrideTheme::InitColorSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/), och [OverrideTheme::InitFormatSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) kopierar de tre huvudsakliga temakomponenterna till åsidosättningen.

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

Detta ändrar temat som används av den bilden utan att ändra temat som ärvs av andra bilder. För att ta bort den lokala åsidosättningen och återgå till ärvda värden, anropa [OverrideTheme::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/clear/).

### **Tillämpa en tema‑åsidosättning på en layout**

En layout‑nivååsidosättning gäller för bilder som använder den layouten, såvida en viss bild inte har sin egen åsidosättning. Samma initieringsmetoder kan användas via layoutens [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/):

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

Använd ett master‑ eller presentationsnivåtema när många layouter och bilder ska dela samma grunddesign, en layout‑åsidosättning när en layoutfamilj behöver annan styling, och en bild‑åsidosättning endast för verkliga undantag. Överdrivna bild‑nivååsidosättningar gör senare globala temaförändringar svårare att förutsäga.

## **Uppdatera temats bakgrundsstilar**

Temats bakgrundsfyllningar lagras i [FormatScheme::get_BackgroundFillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint kan presentera fler bakgrundsalternativ i sitt UI än antalet fyllningsdefinitioner som fysiskt lagras i denna samling eftersom UI kan kombinera temafyllningar med temafärger och andra stilreferenser.

![PowerPoint bakgrundsstilsgalleri för ett presentationstema](presentation-design_8.png)

Innan du använder en bakgrundsstil, inspektera den lagrade samlingen och den aktuella [Background::get_StyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` använder `0` för ingen temafyllning; positiva värden är temabakgrundsstilsreferenser. Detta skiljer sig från att indexera en C++‑samling direkt med `idx_get(0)`, där `0` betyder det första lagrade elementet. Anta inte att varje presentation innehåller samma antal bakgrundsfyllningsstilar.

Följande exempel rapporterar antalet tillgängliga bakgrundsfyllningar, tilldelar en temabakgrundsreferens till den första masteren och sparar presentationen:

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

Det synliga resultatet beror på temaposten som refereras av masteren och på eventuella bakgrundsåsidosättningar på layout‑ eller bildnivå. Om en bild använder sin egen bakgrund kanske en ändring av endast masterbakgrunden inte förändrar den bilden. Använd [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) när du behöver veta den slutgiltiga bakgrunden efter att arv har tillämpats.

{{% alert color="warning" title="Warning" %}}
Behandla inte `StyleIndex` som ett nollbaserat samlingsindex. Undvik också att hårdkoda ett stilnummer från en fil och anta att det har samma utseende i en annan fil; temastilsdefinitioner är presentationsspecifika.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
För direkt bakgrundsformatering och bakgrundsarv, se [Presentation Background](/slides/sv/cpp/presentation-background/).
{{% /alert %}}

## **Uppdatera temaeffekter**

Ett temaformatschema innehåller separata [FormatScheme::get_FillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_linestyles/), och [FormatScheme::get_EffectStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) samlingar. Typiska Office‑teman innehåller ofta tre huvudstilposter som visuellt motsvarar subtil, måttlig och intensiv formatering, men kod bör inspektera varje samling istället för att anta ett fast antal.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

När du får åtkomst till dessa samlingar i C++ är samlingsindexet nollbaserat: `idx_get(0)` är den första lagrade stilen och `idx_get(2)` är den tredje. En formes stilreferensindex är ett separat koncept, exponerat via [IShapeStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/). Att modifiera en temastil påverkar former som refererar till den temastilen; former med direkt formatering kan förbli oförändrade.

Följande exempel kontrollerar att de erforderliga stilposterna finns, ändrar den första linjestilen, ändrar den tredje fyllningsstilen, aktiverar en yttre skugga i den tredje effektstilen och sparar resultatet:

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

För former som refererar till dessa platser blir den första temalinjestilen röd, den tredje temafyllningsstilen blir solid skogsgrön, och den tredje effektstilen får en yttre skugga med ett avstånd på 10 punkter. Det exakta visuella resultatet beror fortfarande på vilka stilplatser varje form refererar till och om direkt formatering åsidosätter temat.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Välj temafyllnings‑ och linjestilar för en form**

En form kan välja sin fyllning och kontur oberoende via [IShapeStyle::set_FillStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_fillstyleindex/) och [IShapeStyle::set_LineStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_linestyleindex/). För båda settarna väljer index `1` den första posten i motsvarande tematsamling (`idx_get(0)`), och index `2` väljer den andra posten.

Följande exempel ställer in två fyllningsstilar (guld och himmelsblå) och två linjestilar (mörkblå på 6 pt och mörkröd på 12 pt) i standardtemat för en ny presentation. Det sparar bilden i tre steg så att du kan jämföra resultaten i PowerPoint.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeStyle.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto styles = presentation->get_MasterTheme()->get_FormatScheme();

auto goldFill = styles->get_FillStyles()->idx_get(0);
goldFill->set_FillType(FillType::Solid);
goldFill->get_SolidFillColor()->set_Color(Color::get_Gold());
auto blueFill = styles->get_FillStyles()->idx_get(1);
blueFill->set_FillType(FillType::Solid);
blueFill->get_SolidFillColor()->set_Color(Color::get_SkyBlue());

auto thinLine = styles->get_LineStyles()->idx_get(0);
thinLine->get_FillFormat()->set_FillType(FillType::Solid);
thinLine->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
thinLine->set_Width(6.0);
auto thickLine = styles->get_LineStyles()->idx_get(1);
thickLine->get_FillFormat()->set_FillType(FillType::Solid);
thickLine->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkRed());
thickLine->set_Width(12.0);

auto shapes = presentation->get_Slide(0)->get_Shapes();
auto left = shapes->AddAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
auto right = shapes->AddAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
auto leftStyle = left->get_ShapeStyle();
auto rightStyle = right->get_ShapeStyle();
leftStyle->set_FillStyleIndex(1);
rightStyle->set_FillStyleIndex(2);
leftStyle->set_LineStyleIndex(1);
rightStyle->set_LineStyleIndex(1);
presentation->Save(u"01-initial.pptx", SaveFormat::Pptx);

rightStyle->set_LineStyleIndex(2);
presentation->Save(u"02-line-changed.pptx", SaveFormat::Pptx);

goldFill->get_SolidFillColor()->set_Color(Color::get_SeaGreen());
presentation->Save(u"03-theme-changed.pptx", SaveFormat::Pptx);
```

| Initiala stilar | Ändra högra konturen | Redigera den första temafyllningen |
|:---:|:---:|:---:|
| ![Guld- och himmelsblå rektanglar med matchande tunna mörkblå konturer](theme-style-initial.png) | ![Den himmelsblå rektangeln har nu en tjock mörkröd kontur](theme-style-line-changed.png) | ![Den vänstra rektangeln är nu grön och båda konturerna är oförändrade](theme-style-fill-changed.png) |

Att välja en annan linjestil ändrar endast den högra rektangelns kontur. Att redigera den första temafyllningen uppdaterar varje form som använder den. Här blir endast den vänstra rektangeln grön.

På en befintlig form kan en lokal fyllningsfärg, linjefärg eller linjebredd åsidosätta den delen av temastilen. Om en ändring av stilindexet inte ger någon synlig effekt, kontrollera formens [direct formatting](/slides/sv/cpp/shape-formatting/).

## **Bestäm om en effektiv solid fyllning använder en temafärg**

En fyllning kan lagras direkt på ett objekt eller ärvas från ett stycke, en layout, en master, temastil eller en annan formateringsnivå. Anropa [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/) för att lösa den hierarkin till en oföränderlig [IFillFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/). Kontrollera först [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_filltype/). Endast när den är `FillType::Solid` bör du läsa solid‑fyllningsegenskaperna.

För en solid fyllning returnerar [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) det slutliga renderade RGB‑värdet efter att arv, temauppslagning och färgtransformeringar har tillämpats. [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) returnerar motsvarande logiska [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/)‑slot, såsom `Text1` eller `Accent6`. Ett värde av `SchemeColor::NotDefined` betyder att den effektiva solida fyllningen inte baseras på en schemafärg. I ett arbetsflöde där fyllningar antingen är temafärger eller direkta RGB‑färger identifierar detta värde en direkt RGB‑fyllning.

Använd inte det lokala [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_schemecolor/)‑värdet ensamt för att klassificera en fyllning. Till exempel kan en textdel sakna en lokalt definierad schemafärg, så dess lokala värde är `NotDefined`, medan dess effektiva fyllning ärver en temafärg och löser upp till `Text1` eller `Accent6`. Omvänt visar `get_SolidFillSchemeColor` vilken logisk temaslot som producerade den effektiva färgen, men den säger inte om den sloten kom från objektet, stycket, layouten, masteren eller en annan nivå i formateringshierarkin.

Följande exempel laddar en presentation, granskar både formfyllningar och textdel‑fyllningar, skriver ut varje slutgiltigt RGB‑värde och tillhörande schemafärg, och flaggar solida fyllningar som inte kommer att följa temafärgförändringar:

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

`NotDefined`‑grenen ger en granskningslista över solida fyllningar som inte kommer att svara på förändringar i temafärgsplatser. Granska dessa objekt när en presentation måste följa en ny varumärkespalett. Det rapporterade RGB‑värdet visar fortfarande det aktuella utseendet, medan schemavärdet förklarar om det utseendet är kopplat till temat.

Effektiva formatobjekt är ögonblicksbilder. Efter att ha ändrat presentationstemat, en temaåsidosättning eller någon ärvd formatering, anropa `GetEffective` igen och läs ett nytt `IFillFormatEffectiveData`‑objekt innan du jämför eller rapporterar färger.

## **Läs effektiva temavärden**

Råa temobjekt visar vad som är definierat på en viss nivå. Effektiva värden visar vad en bild eller form faktiskt använder efter att arv och lokala åsidosättningar har lösts. För en bild, anropa [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). För en bakgrund, använd [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/), och för en fyllning, använd [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/).

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

Använd effektiva data för renderingsdiagnostik, validering och jämförelser. Om du endast inspekterar [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/), kan du missa en master-, layout-, bild- eller form‑åsidosättning som ändrar det slutgiltiga utseendet.

## **FAQ**

**Påverkar tillämpning av ett externt tema varje bild i presentationen?**

Nej. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) återtilldelar endast de bilder som beror på den valda masteren. Bilder som använder andra masters behåller sina befintliga teman.

**Kan jag tillämpa ett tema på en enskild bild utan att ändra masteren?**

Ja. Använd bildens [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/) och initiera dess åsidosättningstema. Ändringen förblir lokal för den bilden; andra bilder fortsätter att ärva sina befintliga teman.

**Vad är det säkraste sättet att föra över ett tema från en presentation till en annan?**

När du flyttar en bild och bevarar dess källutseende, klona källmasteren till destinationen och klona bilden med den masteren med hjälp av [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/) och [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/). Detta behåller masteren, layouterna och temat tillsammans.

**Hur kan jag se de effektiva värdena efter arv och åsidosättningar?**

Använd [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) för en bild‑ eller layout‑tema och motsvarande effektiva‑datametoder för formatobjekt såsom [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) och [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/). Dessa API‑er returnerar de lösta värdena efter att arv och åsidosättningar har tillämpats.