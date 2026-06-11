---
title: Hämta effektiva egenskaper för former från presentationer i C++
linktitle: Effektiva egenskaper
type: docs
weight: 50
url: /sv/cpp/shape-effective-properties/
keywords:
- formegenskaper
- kameraegenskaper
- ljusrigg
- fasettform
- textram
- textstil
- teckenhöjd
- fyllningsformat
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för C++ beräknar och tillämpar effektiva formegenskaper för exakt PowerPoint-rendering."
---
## **Översikt**

Detta ämne förklarar skillnaden mellan **lokala** och **effektiva** egenskaper. Lokala värden är värden som ställs in direkt på en specifik formateringsnivå, exempelvis:

1. Portionegenskaper på en bild.
1. Prototypsformen textstilar på en layout‑ eller huvudbild, när bildens textramhär har en sådan.
1. Globala textinställningar i en presentation.

Lokala värden kan definieras eller utelämnas på vilken nivå som helst. När Aspose.Slides behöver den slutgiltiga “som renderad” formateringen löser den ärvd kedja och returnerar **effektiva** värden. Du kan hämta dem genom att anropa `GetEffective`‑metoden på det lokala formateringsobjektet.

Följande exempel visar hur man får effektiva värden. Det förutsätter att den första formen på den första bilden är en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) med en textram och minst en portion.

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
Effektiva formateringsdata representerar den aktuella beräknade formateringen efter att arv har tillämpats. I den nuvarande implementeringen kan vissa effektiva dataobjekt, såsom [IPortionFormatEffectiveData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportionformateffectivedata/), cachas internt. Att anropa `GetEffective` igen efter att ha ändrat föräldra‑ eller ärvd formatering kan uppdatera den cachade datan, och ett tidigare erhållet objekt kanske inte längre representerar det tidigare tillståndet. Om du behöver bevara effektiva värden för senare återanvändning, kopiera de nödvändiga egenskaperna, såsom teckenhöjd, fyllningsfärg, teckensnittsstil eller justering, till ditt eget dataobjekt.
{{% /alert %}}

## **Hämta effektiva egenskaper för en kamera**

Aspose.Slides låter dig hämta effektiva egenskaper för en kamera. Interface‑n [ICameraEffectiveData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icameraeffectivedata/) representerar ett oföränderligt objekt som innehåller effektiva kameraegenskaper. En [ICameraEffectiveData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icameraeffectivedata/)‑instans exponeras via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformateffectivedata/), som tillhandahåller effektiva värden för [IThreeDFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/).

Följande kodexempel visar hur man hämtar effektiva egenskaper för kameran. Det förutsätter att den första formen på den första bilden har 3D‑formatering.

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

## **Hämta effektiva egenskaper för en ljusrigg**

Aspose.Slides låter dig hämta effektiva egenskaper för en ljusrigg. Interface‑n [ILightRigEffectiveData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilightrigeffectivedata/) representerar ett oföränderligt objekt som innehåller effektiva ljusriggsegenskaper. En [ILightRigEffectiveData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilightrigeffectivedata/)‑instans exponeras via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformateffectivedata/), som tillhandahåller effektiva värden för [IThreeDFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/).

Följande kodexempel visar hur man hämtar effektiva egenskaper för ljusriggen. Det förutsätter att den första formen på den första bilden har 3D‑formatering.

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

## **Hämta effektiva egenskaper för en fasettform**

Aspose.Slides låter dig hämta effektiva egenskaper för en fasett på en form. Interface‑n [IShapeBevelEffectiveData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapebeveleffectivedata/) representerar ett oföränderligt objekt som innehåller effektiva fasettrelief‑egenskaper för en form. En [IShapeBevelEffectiveData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapebeveleffectivedata/)‑instans exponeras via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformateffectivedata/), som tillhandahåller effektiva värden för [IThreeDFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/).

Följande kodexempel visar hur man hämtar effektiva egenskaper för den övre fasetten på en form. Det förutsätter att den första formen på den första bilden har 3D‑formatering.

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

## **Hämta effektiva egenskaper för en textram**

Med Aspose.Slides kan du hämta effektiva egenskaper för en textram. Interface‑n [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformateffectivedata/) innehåller effektiva formateringsegenskaper för textram.

Följande kodexempel visar hur man hämtar effektiva formateringsegenskaper för en textram. Det förutsätter att den första formen på den första bilden är en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) med en textram.

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

## **Hämta effektiva egenskaper för en textstil**

Med Aspose.Slides kan du hämta effektiva egenskaper för en textstil. Interface‑n [ITextStyleEffectiveData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextstyleeffectivedata/) innehåller effektiva textstilegenskaper.

Följande kodexempel visar hur man hämtar effektiva textstilegenskaper. Det förutsätter att den första formen på den första bilden är en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) med en textram.

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

## **Hämta den effektiva teckenhöjden**

Med Aspose.Slides kan du hämta den effektiva teckenhöjden. Följande kod demonstrerar hur en portions effektiva teckenhöjd förändras efter att lokala teckenhöjdsvärden har satts på olika nivåer i presentationsstrukturen.

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

## **Hämta den effektiva fyllningsformatet för en tabell**

Med Aspose.Slides kan du hämta effektiva fyllningsformat för olika tabelldelar. Interface‑n [IFillFormatEffectiveData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifillformateffectivedata/) innehåller effektiva fyllningsformatsegenskaper. Cellformat har högre prioritet än radformat, radformat har högre prioritet än kolumnformat, och kolumnformat har högre prioritet än format för hela tabellen.

Som ett resultat används [ICellFormatEffectiveData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icellformateffectivedata/)‑egenskaper för att rita tabellcellen. Följande kodexempel visar hur man hämtar effektiva fyllningsformat för olika tabelldelar. Det förutsätter att den första formen på den första bilden är en [ITable](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itable/).

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

**Returnerar `GetEffective` ett ögonblicksbilder?**

Inte alltid. Effektiva data representerar den beräknade formateringen efter att arv har tillämpats, men vissa effektiva dataobjekt kan cachas internt. Ett efterföljande anrop till `GetEffective` kan beräkna om formateringen och uppdatera den cachade datan, så ett tidigare erhållet objekt bör inte betraktas som en beständig ögonblicksbild.

**När bör jag läsa effektiva egenskaper igen?**

Anropa `GetEffective` igen efter att ha ändrat lokal formatering, föräldraklasser, layoutformatering, huvudformatering eller presentationsnivåns standardinställningar. Nästa anrop utvärderar formateringshierarkin på nytt och returnerar det aktuella effektiva resultatet.

**Påverkar ändring eller borttagning av en layout‑/huvudbild effektiva egenskaper som redan har hämtats?**

Ja, men förändringen reflekteras vid nästa `GetEffective`‑anrop. Om en föräldrakällas formatering ändras eller tas bort kan tidigare erhållna effektiva data vara föråldrade. När `GetEffective` anropas igen utvärderar Aspose.Slides formateringsträdet på nytt och de resulterande teckensnitten, färgerna, storlekarna eller andra värden kan förändras.

**Kan jag modifiera värden via effektiva dataobjekt?**

Nej. Effektiva dataobjekt exponerar endast beräknade värden. Gör ändringar i de lokala formateringsobjekten och hämta sedan de effektiva värdena igen.

**Vad händer om en egenskap inte är satt på formnivå, inte i layout‑/huvudbilden och inte i globala inställningar?**

Det effektiva värdet bestäms av standardmekanismen, som inkluderar PowerPoint‑ och Aspose.Slides‑standardvärden. Det lösta värdet blir en del av den aktuella effektiva datan.

**Kan jag, utifrån ett effektivt teckenvärde, avgöra vilken nivå som tillhandahöll storleken eller teckensnittet?**

Inte direkt. Effektiva data returnerar bara det slutgiltiga värdet. För att hitta källan, kontrollera lokala värden på portion, stycke, textram och textstilar på layout‑, huvud‑ och presentationsnivå för att se var den första explicita definitionen förekommer.

**Varför ser effektiva värden ibland identiska ut med de lokala?**

För att det lokala värdet blev det slutgiltiga (ingen högre nivå av arv behövdes). I sådana fall matchar det effektiva värdet det lokala.

**När bör jag använda effektiva egenskaper och när bör jag bara arbeta med lokala?**

Använd effektiva data när du behöver resultatet “som renderat” efter att all arv har tillämpats, till exempel för att synkronisera färger, indrag eller storlekar. Om du behöver bevara dessa värden oavsett framtida formateringsändringar, kopiera de nödvändiga egenskaperna till ditt eget objekt. Om du ska ändra formatering på en specifik nivå, modifiera de lokala egenskaperna och läs sedan, om så behövs, de effektiva data igen för att verifiera resultatet.