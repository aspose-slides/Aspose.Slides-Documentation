---
title: Haal effectieve vormeigenschappen op uit presentaties in C++
linktitle: Effectieve eigenschappen
type: docs
weight: 50
url: /nl/cpp/shape-effective-properties/
keywords:
- vormeigenschappen
- camera-eigenschappen
- lichtinstallatie
- bevelvorm
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

Dit onderwerp legt het verschil uit tussen **lokale** en **effectieve** eigenschappen. Lokale waarden zijn waarden die direct op een specifiek opmaakniveau worden ingesteld, zoals:

1. Portioneigenschappen op een dia.
1. Prototype‑vormtekstopmaakstijlen op een lay-out of masterslide, wanneer de vorm van het tekstkader van de portion er een heeft.
1. Globale tekstopmaakinstellingen in een presentatie.

Lokale waarden kunnen op elk niveau worden gedefinieerd of weggelaten. Wanneer Aspose.Slides de uiteindelijke “zoals weergegeven” opmaak nodig heeft, lost het de erfelijkheidsketen op en retourneert **effectieve** waarden. Je kunt ze verkrijgen door de `GetEffective`‑methode aan te roepen op het lokale opmaakobject.

Het volgende voorbeeld laat zien hoe je effectieve waarden krijgt. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) is met een tekstkader en ten minste één portion.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="primary" %}}
Effectieve opmaakgegevens vertegenwoordigen de momenteel berekende opmaak nadat erfelijkheid is toegepast. In de huidige implementatie kunnen sommige effectieve gegevensobjecten, zoals [IPortionFormatEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportionformateffectivedata/), intern worden gecached. Het opnieuw aanroepen van `GetEffective` na het wijzigen van bovenliggende of geërfde opmaak kan de cache vernieuwen, en een eerder verkregen object vertegenwoordigt mogelijk niet langer de eerdere toestand. Als je effectieve waarden later opnieuw wilt gebruiken, kopieer dan de benodigde eigenschappen, zoals letterhoogte, opvulkleur, lettertype‑stijl of uitlijning, naar je eigen gegevensobject.
{{% /alert %}}

## **Effectieve eigenschappen van een camera ophalen**

Aspose.Slides stelt je in staat om effectieve eigenschappen van een camera op te halen. De interface [ICameraEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icameraeffectivedata/) vertegenwoordigt een onveranderlijk object dat effectieve camera‑eigenschappen bevat. Een instantie van [ICameraEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icameraeffectivedata/) wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformateffectivedata/), die effectieve waarden levert voor [IThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/).

Het volgende codevoorbeeld toont hoe je effectieve eigenschappen voor de camera kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```cpp
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

## **Effectieve eigenschappen van een lichtinstallatie ophalen**

Aspose.Slides stelt je in staat om effectieve eigenschappen van een lichtinstallatie op te halen. De interface [ILightRigEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilightrigeffectivedata/) vertegenwoordigt een onveranderlijk object dat effectieve lichtinstallatie‑eigenschappen bevat. Een instantie van [ILightRigEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilightrigeffectivedata/) wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformateffectivedata/), die effectieve waarden levert voor [IThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/).

Het volgende codevoorbeeld toont hoe je effectieve eigenschappen voor de lichtinstallatie kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```cpp
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

## **Effectieve eigenschappen van een bevelvorm ophalen**

Aspose.Slides stelt je in staat om effectieve eigenschappen van een bevelvorm op te halen. De interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapebeveleffectivedata/) vertegenwoordigt een onveranderlijk object dat effectieve face‑relief‑eigenschappen voor een vorm bevat. Een instantie van [IShapeBevelEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapebeveleffectivedata/) wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformateffectivedata/), die effectieve waarden levert voor [IThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/).

Het volgende codevoorbeeld toont hoe je effectieve eigenschappen voor het bovenste bevel van een vorm kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```cpp
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

## **Effectieve eigenschappen van een tekstkader ophalen**

Met Aspose.Slides kun je effectieve eigenschappen van een tekstkader ophalen. De interface [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformateffectivedata/) bevat effectieve tekstkader‑opmaak‑eigenschappen.

Het volgende codevoorbeeld toont hoe je effectieve tekstkader‑opmaak‑eigenschappen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) met een tekstkader is.

```cpp
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

Met Aspose.Slides kun je effectieve eigenschappen van een tekststijl ophalen. De interface [ITextStyleEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextstyleeffectivedata/) bevat effectieve tekststijl‑eigenschappen.

Het volgende codevoorbeeld toont hoe je effectieve tekststijl‑eigenschappen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) met een tekstkader is.

```cpp
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

## **De effectieve letterhoogte ophalen**

Met Aspose.Slides kun je de effectieve letterhoogte ophalen. De volgende code demonstreert hoe de effectieve letterhoogte van een portion verandert nadat lokale letterhoogte‑waarden op verschillende presentatiestructuurniveaus zijn ingesteld.

```cpp
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

## **Effectieve opvulling van een tabel ophalen**

Met Aspose.Slides kun je effectieve opvul‑opmaak voor verschillende tabelonderdelen ophalen. De interface [IFillFormatEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifillformateffectivedata/) bevat effectieve opvul‑opmaak‑eigenschappen. Cel‑opmaak heeft hogere prioriteit dan rij‑opmaak, rij‑opmaak heeft hogere prioriteit dan kolom‑opmaak, en kolom‑opmaak heeft hogere prioriteit dan opmaak van de volledige tabel.

Als gevolg daarvan worden de eigenschappen van [ICellFormatEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icellformateffectivedata/) gebruikt om de tabelcel te tekenen. Het volgende codevoorbeeld toont hoe je effectieve opvul‑opmaak voor verschillende tabelonderdelen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/) is.

```cpp
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

**Geeft `GetEffective` een momentopname terug?**

Niet altijd. Effectieve gegevens vertegenwoordigen de berekende opmaak nadat erfelijkheid is toegepast, maar sommige effectieve gegevensobjecten kunnen intern worden gecached. Een volgende `GetEffective`‑aanroep kan de opmaak opnieuw berekenen en de cache vernieuwen, zodat een eerder verkregen object niet moet worden beschouwd als een duurzame momentopname.

**Wanneer moet ik effectieve eigenschappen opnieuw uitlezen?**

Roep `GetEffective` opnieuw aan nadat je lokale opmaak, bovenliggende stijlen, lay‑out‑opmaak, master‑opmaak of presentatieniveau‑standaardinstellingen hebt gewijzigd. De volgende aanroep herziet de opmaakhiërarchie en retourneert het huidige effectieve resultaat.

**Heeft het wijzigen of verwijderen van een lay‑out/master‑dia invloed op reeds opgehaalde effectieve eigenschappen?**

Ja, maar de wijziging wordt pas zichtbaar bij de volgende `GetEffective`‑aanroep. Als een bovenliggende opmaakbron wordt gewijzigd of verwijderd, kan eerder verkregen effectieve data verouderd zijn. Zodra `GetEffective` opnieuw wordt aangeroepen, evalueert Aspose.Slides de opmaakboom opnieuw en kunnen lettertypen, kleuren, groottes of andere waarden wijzigen.

**Kan ik waarden wijzigen via effectieve gegevensobjecten?**

Nee. Effectieve gegevensobjecten geven alleen berekende waarden weer. Breng wijzigingen aan in de lokale opmaakobjecten en haal vervolgens de effectieve waarden opnieuw op.

**Wat gebeurt er als een eigenschap niet is ingesteld op vormniveau, noch in de lay‑out/master, noch in de globale instellingen?**

De effectieve waarde wordt bepaald door het standaardmechanisme, dat zowel PowerPoint‑ als Aspose.Slides‑standaardwaarden omvat. Die opgeloste waarde wordt onderdeel van de huidige effectieve data.

**Kan ik aan een effectieve letterwaarde afleiden op welk niveau de grootte of het lettertype is ingesteld?**

Niet rechtstreeks. Effectieve data geven alleen de uiteindelijke waarde terug. Om de bron te vinden, controleer je lokale waarden op portion‑, alinea‑, tekstkader‑ en tekststijlniveau op de lay‑out, master en presentatieniveau om te zien waar de eerste expliciete definitie voorkomt.

**Waarom lijken effectieve waarden soms identiek aan de lokale waarden?**

Omdat de lokale waarde uiteindelijk de definitieve bleek te zijn (er was geen hogere‑niveau erfelijkheid nodig). In dat geval komt de effectieve waarde overeen met de lokale waarde.

**Wanneer moet ik effectieve eigenschappen gebruiken en wanneer moet ik alleen met lokale werken?**

Gebruik effectieve data wanneer je het “zoals weergegeven” resultaat nodig hebt na het toepassen van alle erfelijkheid, bijvoorbeeld om kleuren, inspringen of groottes uit te lijnen. Als je deze waarden wilt behouden, ongeacht latere opmaakwijzigingen, kopieer je de benodigde eigenschappen naar je eigen object. Als je op een specifiek niveau wilt aanpassen, wijzig dan de lokale eigenschappen en lees vervolgens, indien nodig, de effectieve data opnieuw om het resultaat te verifiëren.