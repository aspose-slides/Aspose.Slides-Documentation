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
description: "Beheers de masterpresentatiethema's in Aspose.Slides voor C++ om PowerPoint-bestanden te maken, aanpassen en converteren met een consistente huisstijl."
---
## **Inleiding**

Een presentatiethema definieert een gecoördineerde set van kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een themawijziging veel objecten in één keer kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/). Een presentatie kan ook thema‑overwrites bevatten op lagere niveaus. Een master kan het presentatiethema overschrijven via [MasterThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), terwijl een lay‑out of een individuele dia [IOverrideThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) kan gebruiken. In de praktijk wordt het effectieve thema voor een dia opgelost via deze overervingsketen: presentatiethema, master‑override, lay‑out‑override en dia‑override.

![Themakelementen: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De onderstaande secties tonen de meest voorkomende thema‑werkstromen: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat overerving en overrides zijn verwerkt.

## **Inspecteer een thema**

Het [MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/)‑object biedt de methoden [get_ColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_fontscheme/), en [get_FormatScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) aan. Het inspecteren van deze collecties voordat ze worden gewijzigd is vooral nuttig wanneer een presentatie afkomstig is uit een externe bron, omdat het aantal en de inhoud van stijl‑items kan variëren.

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

Als een bestand meerdere masters gebruikt, ga er dan niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort, en gebruik de effectieve‑thema‑werkstroom die later in dit artikel wordt getoond wanneer lay‑out‑ of dia‑overrides aanwezig kunnen zijn.

## **Themakleuren wijzigen**

Thema‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/)‑enumeratie. Wanneer je het overeenkomstige element in het thema’s [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) wijzigt, worden alle objecten die nog naar die themakleur verwijzen, opgelost tegen de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet gewijzigd door een thema‑kleurupdate.

Het volgende end‑to‑end voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de `Accent4`‑kleur van het thema naar rood, slaat de presentatie op, opent deze opnieuw, en print de effectieve vulkleur:

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

Omdat het rechthoek nog steeds gekoppeld is aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Als je de schemacleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen aan `Accent4` die vulkleur niet meer beïnvloeden.

### **Gebruik kleuren uit het aanvullende palet**

PowerPoint haalt lichtere en donkerdere varianten af van een themakleur door kleurtransformaties toe te passen. Aspose.Slides maakt deze transformaties beschikbaar via [ColorTransformOperation](https://reference.aspose.com/slides/cpp/aspose.slides/colortransformoperation/).

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren gegenereerd uit het aanvullende palet](additional-palette-colors.png)

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

Deze varianten blijven gebaseerd op de themakleur. Als `Accent4` later wijzigt, worden de getransformeerde kleuren opnieuw berekend op basis van de nieuwe `Accent4`‑waarde.

### **Map `SchemeColor`‑waarden naar `IColorScheme`‑slots**

De [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/)‑enumeratie gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) dezelfde themaslots exposeert als `Dark1`, `Light1`, `Dark2` en `Light2`. De mapping is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaslots; het zijn geen waarden die dynamisch van de ene vorm naar de andere worden omgezet.

## **Themale lettertypen wijzigen**

Een themaletterschema bevat een hoofdlettertype‑set voor koppen en een secundaire (minor) lettertype‑set voor de hoofdtekst. De methoden [FontScheme::get_Major](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_major/) en [FontScheme::get_Minor](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_minor/) geven die sets weer.

* `+mn-lt` - Bodylettertype Latin (Minor Latin Font)
* `+mj-lt` - Koplettertype Latin (Major Latin Font)
* `+mn-ea` - Bodylettertype Oost‑Aziatisch (Minor East Asian Font)
* `+mj-ea` - Koplettertype Oost‑Aziatisch (Major East Asian Font)
* `+mn-cs` - Bodylettertype Complex Script (Minor Complex Script Font)
* `+mj-cs` - Koplettertype Complex Script (Major Complex Script Font)

Het volgende voorbeeld maakt één kop die het hoofd‑Latin‑themabetlettertype gebruikt en één regel hoofdtekst die het secundaire Latin‑themabetlettertype gebruikt. Vervolgens wijzigt het de themabetlettertypen en slaat het resultaat op:

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

De kop volgt het hoofdlettertype en de hoofdtekst volgt het secundaire lettertype. Tekst die een expliciete lettertype‑naam heeft in plaats van een thema‑identificator, zal niet automatisch wijzigen wanneer het themaletterschema verandert.

De hoofd‑ en secundaire lettertype‑collecties kunnen ook lettertype‑toewijzingen bevatten voor individuele schriftsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Om deze toewijzingen te inspecteren, toe te voegen, te vervangen of te verwijderen, zie [Script‑Specific Theme Fonts](/slides/nl/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatie‑lettertypen, zie [PowerPoint Fonts](/slides/nl/cpp/powerpoint-fonts/).
{{% /alert %}}

### **Themareferenties voor lettertypen oplossen**

Wanneer je inspecteert, kan [IFontData::get_FontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/get_fontname/) een themareferentie bevatten zoals `+mn-lt` in plaats van een lettertype‑familienaam. Roep [IFontData::GetFontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/getfontname/) aan met de juiste [IThemeEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeeffectivedata/) om die referentie op te lossen. De `+mj`‑ en `+mn`‑prefixen selecteren respectievelijk de hoofd‑ en secundaire lettertype‑sets; de suffixen `-lt`, `-ea` en `-cs` selecteren hun Latin, Oost‑Aziatische en Complex Script‑lettertypen.

Verkrijg het effectieve thema via [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) op het object waarvan het thema van toepassing is. Voor gewone tekst op een dia gebruik je `slide->CreateThemeEffective()` zodat de context die dia‑specifieke erfenisthema en lokale overrides bevat. Bij het inspecteren van een lay‑out of master zelf, gebruik je het eigen effectieve thema. Ga niet ervan uit dat het thema van de eerste master op elke dia van toepassing is.

Het volgende voorbeeld maakt een tekstdeling die expliciet verwijst naar het secundaire Latin‑lettertype. Het initialiseert een dia‑lettertypeschema via [IOverrideTheme::InitFontSchemeFromInherited](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) en stelt de hoofd‑ en secundaire Latin‑families in op `Arial` en `Calibri`, zodat het resultaat reproduceerbaar is zonder een invoerbestand.

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

De uitvoer is `+mn-lt -> Calibri` gevolgd door `Verdana -> Verdana`. De opgeslagen referentie blijft ongewijzigd, terwijl een expliciete familienaam ongewijzigd wordt teruggegeven. Als de tekstdeling `+mj-lt` had gebruikt, zou deze naar `Arial` resolven in dit thema.

Het oplossen van een themareferentie identificeert de lettertype‑familie die door het thema is opgegeven. Het controleert niet de beschikbaarheid van het lettertype of bepaalt het uiteindelijke lettertype‑bestand dat wordt gebruikt na substitutie of glyph‑fallback tijdens het renderen. Zie [Font Selection Sequence](/slides/nl/cpp/font-selection-sequence/) en [Font Substitution](/slides/nl/cpp/font-substitution/) voor die aparte stappen.

## **Kopiëren of toepassen van een thema**

De onderstaande werkstromen lossen verschillende thema‑gerelateerde problemen op.

### **Een extern thema toepassen op dia's die afhankelijk zijn van een master**

Gebruik [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) wanneer je een PowerPoint‑thema‑bestand (`.thmx`) hebt en elke dia die afhankelijk is van een bepaalde master wilt herstylen. Selecteer de master uit de [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/)‑collectie, die [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/) implementeert, en geef het pad naar het themabestand door aan de methode.

De methode voert de volgende bewerkingen uit:

1. Maakt een nieuwe masterslide gebaseerd op de geselecteerde master.  
1. Past het externe thema toe op de nieuwe master.  
1. Wijst de nieuwe master toe aan alle dia's die eerder afhankelijk waren van de geselecteerde master.  
1. Retourneert de nieuw aangemaakte [IMasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/).

Het volgende voorbeeld past een extern thema toe op de dia's die afhankelijk zijn van de eerste master en slaat de presentatie op:

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

Een ongeldige, corrupte of niet‑ondersteunde thema kan een [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/) of een van zijn op het formaat gerelateerde subklassen veroorzaken. Valideer paden die door gebruikers worden opgegeven, behandel fouten bij bestands‑systeemtoegang en sla de presentatie pas op nadat het thema succesvol is toegepast.

Alleen de dia's die afhankelijk waren van de geselecteerde master worden opnieuw toegewezen. Dia's gekoppeld aan andere masters behouden hun bestaande masters en thema’s. Thema‑bewuste kleuren, lettertypen, vullingen, lijnen, achtergronden en effecten worden opgelost ten opzichte van het externe thema. Direct toegewezen kleuren, lettertypen, vullingen en andere expliciete opmaak kunnen ongewijzigd blijven. Overrides op lay‑out‑niveau en dia‑niveau kunnen eveneens voorrang krijgen op waarden die van de nieuwe master zijn geërfd.

Het thema kan lettertypen refereren die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente weergave en export, installeer de vereiste lettertypen, lever ze via [custom font sources](/slides/nl/cpp/custom-font/) of configureer [font substitution](/slides/nl/cpp/font-substitution/).

Dit is een directe workflow op master‑niveau: de methode accepteert een bestandspad naar een `.thmx`‑bestand en vereist geen handmatige creatie van thema‑overrides op dia‑ of lay‑out‑niveau.

### **Verschillende externe thema’s toepassen in een multi‑master presentatie**

Wanneer de relevante master niet vooraf bekend is, haal je deze op van een representatieve dia via [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) en [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_masterslide/). Sla de oorspronkelijke master‑referenties op voordat je thema’s toepast, omdat elke aanroep een nieuwe master in de presentatie creëert.

Het volgende voorbeeld gebruikt dia’s uit twee secties om hun masters te lokaliseren en past een verschillend extern thema toe op elke groep:

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

De eerste oproep beïnvloedt alleen dia's die afhankelijk waren van `firstGroupMaster`, en de tweede oproep beïnvloedt alleen dia's die afhankelijk waren van `secondGroupMaster`. Dia's die bij een andere master horen, worden niet opnieuw gestyled.

### **Een bron‑thema behouden bij het verplaatsen van dia’s**

Als je een dia naar een andere presentatie wilt verplaatsen en het oorspronkelijke ontwerp wilt behouden, kloon je de bron‑master in de doelpresentatie met [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/), en kloon je vervolgens de dia met [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) en de gekloonde master. Dit draagt de master, zijn lay‑outs en het gekoppelde thema mee.

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

Dit is de voorkeursworkflow wanneer de bron‑dia er in de bestemming precies hetzelfde uit moet zien. Het simpelweg klonen van content naar een niet‑gerelateerde bestemmings‑master kan thema‑gedreven kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑waarden toepassen op een bestaande dia**

Als de doel‑dia op zijn huidige master en lay‑out moet blijven, initialiseert u een dia‑niveau override vanuit het bron‑thema. De methoden [OverrideTheme::InitColorSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) en [OverrideTheme::InitFormatSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) kopiëren de drie hoofdthema‑componenten naar de override.

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

Dit wijzigt het thema dat door die dia wordt gebruikt zonder het thema dat door andere dia’s wordt geërfd te wijzigen. Om de lokale override te verwijderen en terug te keren naar geërfde waarden, roep [OverrideTheme::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/clear/) aan.

### **Een thema‑override toepassen op een lay‑out**

Een lay‑out‑niveau override is van toepassing op dia's die die lay‑out gebruiken, tenzij een specifieke dia zijn eigen override heeft. Dezelfde initialisatiemethoden kunnen worden gebruikt via de lay‑out's [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/):

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

Gebruik een master‑ of presentatie‑niveau thema wanneer veel lay‑outs en dia's hetzelfde basisonwerp moeten delen, een lay‑out‑override wanneer één lay‑out‑familie een andere styling nodig heeft, en een dia‑override alleen voor echte uitzonderingen. Overmatige dia‑niveau overrides maken latere globale thema‑wijzigingen moeilijker te voorspellen.

## **Achtergrondstijlen van het thema bijwerken**

De achtergrondvullingen van het thema worden opgeslagen in [FormatScheme::get_BackgroundFillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint kan in de UI meer achtergrondkeuzes presenteren dan het aantal vuldefinities dat fysiek in deze collectie is opgeslagen, omdat de UI themavullingen kan combineren met themakleuren en andere stijlreferenties.

![PowerPoint galerij voor achtergrondstijlen voor een presentatiethema](presentation-design_8.png)

Voordat je een achtergrondstijl gebruikt, inspecteer je de opgeslagen collectie en de huidige [Background::get_StyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` gebruikt `0` voor geen themavulling; positieve waarden zijn verwijzingen naar themabackground‑stijlen. Dit is anders dan het indexeren van een C++‑collectie rechtstreeks met `idx_get(0)`, waarbij `0` het eerste opgeslagen item betekent. Ga er niet van uit dat elke presentatie hetzelfde aantal achtergrondvulstijlen bevat.

Het volgende voorbeeld rapporteert het aantal beschikbare achtergrondvullingen, wijst een thematische achtergrondreferentie toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de themainvoer die door de master wordt gerefereerd en van eventuele achtergrond‑overrides op lay‑out‑ of dia‑niveau. Als een dia zijn eigen achtergrond gebruikt, kan het wijzigen van alleen de master‑achtergrond die dia niet veranderen. Gebruik [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) wanneer je de uiteindelijke achtergrond moet weten nadat overerving is toegepast.

{{% alert color="warning" title="Warning" %}}
Doe `StyleIndex` niet behandelen als een nul‑gebaseerde collectie‑index. Vermijd ook het hard‑coderen van een stijlnummer uit één bestand en ervan uitgaan dat het dezelfde weergave heeft in een ander bestand; themastijl‑definities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑erfenis, zie [Presentation Background](/slides/nl/cpp/presentation-background/).
{{% /alert %}}

## **Thema‑effecten bijwerken**

Een thema‑formaatschema bevat afzonderlijke collecties [FormatScheme::get_FillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_linestyles/) en [FormatScheme::get_EffectStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Typische Office‑thema’s bevatten vaak drie hoofd‑stijlitems die visueel overeenkomen met subtiele, gematigde en intensieve opmaak, maar code moet elke collectie inspecteren in plaats van uit te gaan van een vast aantal.

![Subtiele, gematigde en intensieve thema‑effecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer je deze collecties in C++ benadert, is de collectie‑index nul‑gebaseerd: `idx_get(0)` is de eerste opgeslagen stijl en `idx_get(2)` is de derde. Een vorm‑stijl‑referentie‑index is een apart concept, blootgelegd via [IShapeStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die themastijl refereren; vormen met directe opmaak kunnen onveranderd blijven.

Het volgende voorbeeld controleert of de vereiste stijlitems bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, schakelt een buitenste schaduw in bij de derde effectstijl, en slaat het resultaat op:

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

Voor vormen die deze slots refereren, wordt de eerste themalijnstijl rood, de derde themavulstijl wordt een solide bosgroen, en de derde effectstijl krijgt een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat hangt nog steeds af van welke stijl‑slots elke vorm referereert en of directe opmaak de thema‑instellingen overschrijft.

![Thema‑effectstijlen na het wijzigen van lijn-, vul‑ en schaduwinstellingen](presentation-design_11.png)

## **Thema‑vul‑ en lijnstijlen selecteren voor een vorm**

Een vorm kan zijn vul‑ en omtrek­stijl onafhankelijk selecteren via [IShapeStyle::set_FillStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_fillstyleindex/) en [IShapeStyle::set_LineStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_linestyleindex/). Voor beide setters selecteert index `1` het eerste item in de corresponderende themacollectie (`idx_get(0)`), en selecteert index `2` het tweede item.

Het volgende voorbeeld zet twee vulstijlen (goud en hemelsblauw) en twee lijnstijlen (donkerblauw op 6 pt en donkerrood op 12 pt) op in het standaardthema van een nieuwe presentatie. Het slaat de dia op in drie fasen zodat je de resultaten in PowerPoint kunt vergelijken.

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

| Initiële stijlen | Verander de rechteromtrek | Bewerk de eerste themavulling |
|:---:|:---:|:---:|
| ![Goldkleurige en hemelsblauwe rechthoeken met bijpassende dunne donkerblauwe omtrekken](theme-style-initial.png) | ![De hemelsblauwe rechthoek heeft nu een dikke donkerrode omtrek](theme-style-line-changed.png) | ![De linker rechthoek is nu groen en beide omtrekken blijven ongewijzigd](theme-style-fill-changed.png) |

Het selecteren van een andere lijnstijl wijzigt alleen de omtrek van de rechterrechthoek. Het bewerken van de eerste themavulling werkt elke vorm bij die deze gebruikt. Hier wordt alleen de linkerrechthoek groen.

Bij een bestaande vorm kan een lokale vulkleur, lijnkleur of lijndikte dat deel van de thema‑stijl overschrijven. Als het wijzigen van een stijl‑index geen zichtbaar effect heeft, controleer dan de [directe opmaak](/slides/nl/cpp/shape-formatting/) van de vorm.

## **Bepalen of een effectieve effen vulling een themakleur gebruikt**

Een vulling kan direct op een object worden opgeslagen of geërfd van een alinea, lay‑out, master, themastijl, of een ander opmaakniveau. Roep [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/) aan om die hiërarchie op te lossen naar een onveranderlijk [IFillFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/). Controleer eerst [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_filltype/). Alleen wanneer deze `FillType::Solid` is, mag je de eigenschappen van de effen vulling lezen.

Voor een effen vulling geeft [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) de uiteindelijke gerenderde RGB‑waarde terug na erfenis, themazoeking en kleurtransformaties. [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) geeft de overeenkomstige logische [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/)‑slot terug, zoals `Text1` of `Accent6`. Een waarde van `SchemeColor::NotDefined` betekent dat de effectieve effen vulling niet gebaseerd is op een schemacleur. In een workflow waarin vullingen ofwel themakleuren ofwel directe RGB‑kleuren zijn, identificeert deze waarde een directe RGB‑vulling.

Gebruik de lokale [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_schemecolor/)‑waarde niet alleen om een vulling te classificeren. Bijvoorbeeld, een tekstdeling kan geen lokaal gedefinieerde schemacleur hebben, dus is de lokale waarde `NotDefined`, terwijl de effectieve vulling een themakleur erft en resolveert naar `Text1` of `Accent6`. Omgekeerd vertelt `get_SolidFillSchemeColor` je welke logische themaslot de effectieve kleur heeft geproduceerd, maar het vertelt niet of die slot afkomstig is van het object, de alinea, lay‑out, master of een ander niveau van de opmaak‑hiërarchie.

Het volgende voorbeeld laadt een presentatie, controleert zowel vormvullingen als tekstdeling‑vullingen, print elke uiteindelijke RGB‑waarde en de bijbehorende schemacleur, en markeert effen vullingen die niet reageren op thema‑kleurwijzigingen:

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

De `NotDefined`‑tak biedt een audit‑lijst van effen vullingen die niet zullen reageren op wijzigingen in themakleur‑slots. Controleer die objecten wanneer een presentatie moet voldoen aan een nieuw merkkleurenpalet. De gerapporteerde RGB‑waarde toont nog steeds het huidige uiterlijk, terwijl de schemacleur uitlegt of dat uiterlijk verbonden is aan het thema.

Effectieve opmaak‑objecten zijn momentopnames. Na het wijzigen van het presentatiethema, een thema‑override, of enige geërfde opmaak, roep je opnieuw `GetEffective` aan en lees je een nieuw `IFillFormatEffectiveData`‑object voordat je kleuren vergelijkt of rapporteert.

## **Effectieve themawaarden lezen**

Ruwe themobjecten vertellen je wat er op een bepaald niveau is gedefinieerd. Effectieve waarden vertellen je wat een dia of vorm daadwerkelijk gebruikt nadat erfenis en lokale overrides zijn verwerkt. Voor een dia roep je [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) aan. Voor een achtergrond gebruik je [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/), en voor een vulling gebruik je [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/).

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

Gebruik effectieve gegevens voor renderingsdiagnostiek, validatie en vergelijkingen. Als je alleen [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/) inspecteert, kun je een master‑, lay‑out‑, dia‑ of vorm‑override missen die de uiteindelijke weergave verandert.

## **FAQ**

**Heeft het toepassen van een extern thema effect op elke dia in de presentatie?**

Nee. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) wijst alleen de dia's die afhankelijk zijn van de geselecteerde master opnieuw toe. Dia's die andere masters gebruiken behouden hun bestaande thema's.

**Kan ik een thema toepassen op één enkele dia zonder de master te veranderen?**

Ja. Gebruik de [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/) van de dia en initialiseert zijn override‑thema. De wijziging blijft lokaal voor die dia; andere dia's blijven hun bestaande thema's erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

Wanneer je een dia verplaatst en de bronweergave wilt behouden, kloon je de bron‑master naar de bestemming en kloon je de dia met die master via [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/) en [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/). Hierdoor blijven master, lay‑outs en thema samen.

**Hoe kan ik de effectieve waarden zien na erfenis en overrides?**

Gebruik [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) voor een dia‑ of lay‑out‑thema en de bijbehorende effectieve‑data‑methoden voor formaatobjecten zoals [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) en [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/). Deze API’s retourneren de opgeloste waarden nadat erfenis en overrides zijn toegepast.