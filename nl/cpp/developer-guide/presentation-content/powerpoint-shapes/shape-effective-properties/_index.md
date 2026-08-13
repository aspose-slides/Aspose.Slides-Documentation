---
title: Effectieve vormeigenschappen ophalen uit presentaties in C++
linktitle: Effectieve eigenschappen
type: docs
weight: 50
url: /nl/cpp/shape-effective-properties/
keywords:
- vormeigenschappen
- camera-eigenschappen
- lichtrig
- bevel-vorm
- tekstkader
- tekststijl
- letterhoogte
- opvulopmaak
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor C++ effectieve vormeigenschappen berekent en toepast voor nauwkeurige PowerPoint-weergave."
---
## **Overzicht**

Dit onderwerp legt het verschil uit tussen **lokale** en **effectieve** eigenschappen. Lokale waarden zijn waarden die rechtstreeks op een specifiek opmaakniveau worden ingesteld, zoals:

1. Portie‑eigenschappen op een dia.  
2. Prototype‑vormtekststijlen op een lay‑out‑ of masterslide, wanneer de tekstframe‑vorm van de portie er een heeft.  
3. Globale tekstopmaakinstellingen in een presentatie.

Lokale waarden kunnen op elk niveau worden gedefinieerd of weggelaten. Wanneer Aspose.Slides de uiteindelijke “as rendered” opmaak nodig heeft, lost het de overervingsketen op en retourneert **effectieve** waarden. Je kunt ze verkrijgen door de `GetEffective`‑methode aan te roepen op het lokale opmaakobject.

Het volgende voorbeeld toont hoe je effectieve waarden kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) is met een tekstframe en minstens één portie.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="info" %}}
Effectieve opmaakgegevens vertegenwoordigen de momenteel berekende opmaak nadat overerving is toegepast. In de huidige implementatie kunnen sommige effectieve gegevensobjecten, zoals [IPortionFormatEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportionformateffectivedata/), intern worden gecached. Het opnieuw aanroepen van `GetEffective` na het wijzigen van ouder‑ of geërfde opmaak kan de gecachete gegevens vernieuwen, en een eerder verkregen object vertegenwoordigt mogelijk niet langer de eerdere staat. Als je effectieve waarden later opnieuw wilt gebruiken, kopieer dan de benodigde eigenschappen, zoals letterhoogte, opvulkleur, lettertype‑stijl of uitlijning, naar je eigen gegevensobject.
{{% /alert %}}

## **Effectieve eigenschappen van een camera ophalen**

Aspose.Slides maakt het mogelijk om de effectieve eigenschappen van een camera op te halen. De [ICameraEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icameraeffectivedata/) interface vertegenwoordigt een onveranderlijk object dat effectieve camera‑eigenschappen bevat. Een [ICameraEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icameraeffectivedata/)‑instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformateffectivedata/), die effectieve waarden levert voor [IThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/).

De volgende codevoorbeeld laat zien hoe je de effectieve eigenschappen van de camera kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto camera = threeDEffectiveData->get_Camera();

System::Console::WriteLine(u"= Effective camera properties =");
auto cameraType = System::ObjectExt::ToString(camera->get_CameraType());
System::Console::WriteLine(System::String(u"Type: ") + cameraType);

auto fieldOfViewAngle = camera->get_FieldOfViewAngle();
System::Console::WriteLine(System::String(u"Field of view: ") + fieldOfViewAngle);

auto cameraZoom = camera->get_Zoom();
System::Console::WriteLine(System::String(u"Zoom: ") + cameraZoom);

presentation->Dispose();
```

## **Effectieve eigenschappen van een Light Rig ophalen**

Aspose.Slides maakt het mogelijk om de effectieve eigenschappen van een Light Rig op te halen. De [ILightRigEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilightrigeffectivedata/) interface vertegenwoordigt een onveranderlijk object dat effectieve Light Rig‑eigenschappen bevat. Een [ILightRigEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilightrigeffectivedata/)‑instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformateffectivedata/), die effectieve waarden levert voor [IThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/).

De volgende codevoorbeeld laat zien hoe je de effectieve eigenschappen van de Light Rig kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```cpp
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto lightRig = threeDEffectiveData->get_LightRig();

System::Console::WriteLine(u"= Effective light rig properties =");
auto lightType = System::ObjectExt::ToString(lightRig->get_LightType());
System::Console::WriteLine(System::String(u"Type: ") + lightType);

auto lightDirection = System::ObjectExt::ToString(lightRig->get_Direction());
System::Console::WriteLine(System::String(u"Direction: ") + lightDirection);

presentation->Dispose();
```

## **Effectieve eigenschappen van een Bevel Shape ophalen**

Aspose.Slides maakt het mogelijk om de effectieve eigenschappen van een Shape Bevel op te halen. De [IShapeBevelEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapebeveleffectivedata/) interface vertegenwoordigt een onveranderlijk object dat effectieve face‑relief‑eigenschappen voor een vorm bevat. Een [IShapeBevelEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapebeveleffectivedata/)‑instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformateffectivedata/), die effectieve waarden levert voor [IThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/).

De volgende codevoorbeeld laat zien hoe je de effectieve eigenschappen voor de bovenste bevel van een vorm kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto bevelTop = threeDEffectiveData->get_BevelTop();

System::Console::WriteLine(u"= Effective shape's top face relief properties =");
auto bevelType = System::ObjectExt::ToString(bevelTop->get_BevelType());
System::Console::WriteLine(System::String(u"Type: ") + bevelType);

auto bevelWidth = bevelTop->get_Width();
System::Console::WriteLine(System::String(u"Width: ") + bevelWidth);

auto bevelHeight = bevelTop->get_Height();
System::Console::WriteLine(System::String(u"Height: ") + bevelHeight);

presentation->Dispose();
```

## **Effectieve eigenschappen van een tekstframe ophalen**

Met Aspose.Slides kun je de effectieve eigenschappen van een tekstframe ophalen. De [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformateffectivedata/) interface bevat effectieve tekstframe‑opmaak‑eigenschappen.

De volgende codevoorbeeld laat zien hoe je de effectieve tekstframe‑opmaak‑eigenschappen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) is met een tekstframe.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextFrameFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto effectiveTextFrameFormat = shape->get_TextFrame()->get_TextFrameFormat()->GetEffective();

auto anchoringType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AnchoringType());
System::Console::WriteLine(System::String(u"Anchoring type: ") + anchoringType);

auto autofitType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AutofitType());
System::Console::WriteLine(System::String(u"Autofit type: ") + autofitType);

auto textVerticalType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_TextVerticalType());
System::Console::WriteLine(System::String(u"Text vertical type: ") + textVerticalType);

System::Console::WriteLine(u"Margins");
auto marginLeft = effectiveTextFrameFormat->get_MarginLeft();
System::Console::WriteLine(System::String(u"   Left: ") + marginLeft);

auto marginTop = effectiveTextFrameFormat->get_MarginTop();
System::Console::WriteLine(System::String(u"   Top: ") + marginTop);

auto marginRight = effectiveTextFrameFormat->get_MarginRight();
System::Console::WriteLine(System::String(u"   Right: ") + marginRight);

auto marginBottom = effectiveTextFrameFormat->get_MarginBottom();
System::Console::WriteLine(System::String(u"   Bottom: ") + marginBottom);

presentation->Dispose();
```

## **Effectieve eigenschappen van een tekststijl ophalen**

Met Aspose.Slides kun je de effectieve eigenschappen van een tekststijl ophalen. De [ITextStyleEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextstyleeffectivedata/) interface bevat effectieve tekststijl‑eigenschappen.

De volgende codevoorbeeld laat zien hoe je de effectieve tekststijl‑eigenschappen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) is met een tekstframe.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/ITextStyleEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto effectiveTextStyle = shape->get_TextFrame()->get_TextFrameFormat()->get_TextStyle()->GetEffective();
int levelCount = 9;

for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    auto effectiveStyleLevel = effectiveTextStyle->GetLevel(levelIndex);

    auto depth = effectiveStyleLevel->get_Depth();
    auto indent = effectiveStyleLevel->get_Indent();
    auto alignment = System::ObjectExt::ToString(effectiveStyleLevel->get_Alignment());
    auto fontAlignment = System::ObjectExt::ToString(effectiveStyleLevel->get_FontAlignment());

    System::Console::WriteLine(System::String(u"= Effective paragraph formatting for style level #") + levelIndex + u" =");
    System::Console::WriteLine(System::String(u"Depth: ") + depth);
    System::Console::WriteLine(System::String(u"Indent: ") + indent);
    System::Console::WriteLine(System::String(u"Alignment: ") + alignment);
    System::Console::WriteLine(System::String(u"Font alignment: ") + fontAlignment);
}

presentation->Dispose();
```

## **De effectieve letterhoogtewaarde ophalen**

Met Aspose.Slides kun je de effectieve letterhoogte ophalen. De volgende code demonstreert hoe de effectieve letterhoogte van een portie verandert nadat lokale letterhoogte‑waarden op verschillende niveaus van de presentatiestructuur zijn ingesteld.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 400.0f, 75.0f, false);
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portions = paragraph->get_Portions();
portions->Clear();

auto firstPortion = System::MakeObject<Portion>(u"Sample text with first portion");
auto secondPortion = System::MakeObject<Portion>(u" and second portion.");

portions->Add(firstPortion);
portions->Add(secondPortion);

System::Console::WriteLine(u"Effective font height just after creation:");
auto firstPortionFormat = firstPortion->get_PortionFormat();
auto secondPortionFormat = secondPortion->get_PortionFormat();

auto printEffectiveFontHeights = [&]()
{
    auto firstPortionFontHeight = firstPortionFormat->GetEffective()->get_FontHeight();
    auto secondPortionFontHeight = secondPortionFormat->GetEffective()->get_FontHeight();

    System::Console::WriteLine(System::String(u"Portion #0: ") + firstPortionFontHeight);
    System::Console::WriteLine(System::String(u"Portion #1: ") + secondPortionFontHeight);
};

printEffectiveFontHeights();

presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(24.0f);

System::Console::WriteLine(u"Effective font height after setting the presentation default font height:");
printEffectiveFontHeights();

paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(40.0f);

System::Console::WriteLine(u"Effective font height after setting paragraph default font height:");
printEffectiveFontHeights();

firstPortionFormat->set_FontHeight(55.0f);

System::Console::WriteLine(u"Effective font height after setting portion #0 font height:");
printEffectiveFontHeights();

secondPortionFormat->set_FontHeight(18.0f);

System::Console::WriteLine(u"Effective font height after setting portion #1 font height:");
printEffectiveFontHeights();

presentation->Save(u"SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Effectieve opvulopmaak voor een tabel ophalen**

Met Aspose.Slides kun je de effectieve opvulopmaak voor verschillende tabelonderdelen ophalen. De [IFillFormatEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifillformateffectivedata/) interface bevat effectieve opvulopmaak‑eigenschappen. Cel‑opmaak heeft een hogere prioriteit dan rij‑opmaak, rij‑opmaak heeft een hogere prioriteit dan kolom‑opmaak, en kolom‑opmaak heeft een hogere prioriteit dan de opmaak van de volledige tabel.

Als gevolg daarvan worden de [ICellFormatEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icellformateffectivedata/)‑eigenschappen gebruikt om de tabelcel te tekenen. De volgende codevoorbeeld laat zien hoe je de effectieve opvulopmaak voor verschillende tabelonderdelen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/) is.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/ICellFormatEffectiveData.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IColumnFormatEffectiveData.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/IRowFormatEffectiveData.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <DOM/Table/ITableFormatEffectiveData.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto tableFillFormatEffective = table->get_TableFormat()->GetEffective()->get_FillFormat();
auto rowFillFormatEffective = table->get_Row(0)->get_RowFormat()->GetEffective()->get_FillFormat();
auto columnFillFormatEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective()->get_FillFormat();
auto cellFillFormatEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective()->get_FillFormat();

presentation->Dispose();
```

## **FAQ**

### Retourneert `GetEffective` een snapshot?

Niet altijd. Effectieve gegevens vertegenwoordigen de berekende opmaak nadat overerving is toegepast, maar sommige effectieve gegevensobjecten kunnen intern worden gecached. Een latere `GetEffective`‑aanroep kan de opmaak opnieuw berekenen en de gecachete gegevens vernieuwen, zodat een eerder verkregen object niet moet worden beschouwd als een blijvende snapshot.

### Wanneer moet ik de effectieve eigenschappen opnieuw lezen?

Roep `GetEffective` opnieuw aan nadat je lokale opmaak, ouder‑stijlen, lay‑out‑opmaak, master‑opmaak of standaardinstellingen op presentatieniveau hebt gewijzigd. De volgende aanroep evalueert de opmaakhiërarchie opnieuw en geeft het huidige effectieve resultaat terug.

### Heeft het wijzigen of verwijderen van een lay‑out/master‑dia invloed op reeds opgehaalde effectieve eigenschappen?

Ja, maar de wijziging wordt pas zichtbaar bij de volgende `GetEffective`‑aanroep. Als een ouder‑opmaakbron wordt gewijzigd of verwijderd, kan eerder verkregen effectieve data verouderd zijn. Zodra `GetEffective` opnieuw wordt aangeroepen, evalueert Aspose.Slides de opmaakboom opnieuw en kunnen lettertypen, kleuren, groottes of andere waarden veranderen.

### Kan ik waarden wijzigen via effectieve data‑objecten?

Nee. Effectieve data‑objecten geven alleen berekende waarden weer. Breng wijzigingen aan in de lokale opmaakobjecten en haal vervolgens de effectieve waarden opnieuw op.

### Wat gebeurt er als een eigenschap niet is ingesteld op vormniveau, noch in de lay‑out/master, noch in globale instellingen?

De effectieve waarde wordt bepaald door het standaardmechanisme, dat de standaardinstellingen van PowerPoint en Aspose.Slides omvat. Die berekende waarde wordt onderdeel van de huidige effectieve gegevens.

### Kan ik vanuit een effectieve letterwaarde afleiden op welk niveau de grootte of het lettertype is ingesteld?

Niet rechtstreeks. Effectieve gegevens retourneren alleen de uiteindelijke waarde. Om de bron te vinden, moet je de lokale waarden controleren op portie‑, alinea‑, tekstframe‑ en tekststijlniveau in de lay‑out, master en presentatie, om te zien waar de eerste expliciete definitie voorkomt.

### Waarom lijken effectieve waarden soms identiek aan de lokale waarden?

Omdat de lokale waarde uiteindelijk de definitieve uitkomst is (er was geen hogere‑niveau‑overerving nodig). In dat geval komt de effectieve waarde overeen met de lokale waarde.

### Wanneer moet ik effectieve eigenschappen gebruiken en wanneer alleen lokale eigenschappen?

Gebruik effectieve gegevens wanneer je het “as rendered” resultaat nodig hebt nadat alle overerving is toegepast, bijvoorbeeld om kleuren, inspringen of groottes uit te lijnen. Als je die waarden wilt bewaren ongeacht latere opmaakwijzigingen, kopieer dan de benodigde eigenschappen naar je eigen object. Als je op een specifiek niveau wilt formatteren, wijzig dan de lokale eigenschappen en lees eventueel de effectieve data opnieuw om het resultaat te verifiëren.