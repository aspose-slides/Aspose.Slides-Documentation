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
- avfasad form
- textram
- textstil
- teckensnittshöjd
- fyllformat
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du använder Aspose.Slides för C++ för att särskilja lokal, ärvd och effektiv formatering av former i PowerPoint-presentationer."
---
## **Förstå lokala, ärvda och effektiva egenskaper**

PowerPoint‑formatering kan komma från flera ställen. Värdet som lagras direkt på ett objekt är dess **lokala värde**. Om det värdet inte är satt, tittar PowerPoint på föräldra‑formateringskällor, såsom ett standardvärde för ett stycke, en textstil, en layout‑ eller mästerval, ett tema eller standardvärden på presentationsnivå. Dessa värden är **ärvda värden**. Värdet som återstår efter att hela hierarkin har lösts är **det effektiva värdet** – värdet som används för att rendera objektet.

Till exempel kanske ett textavsnitt inte definierar sin egen teckensnittshöjd. Dess lokala [fonthöjd](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseportionformat/) är då `std::numeric_limits<float>::quiet_NaN()`, vilket betyder "inte satt här". Avsnittet kan ärva en höjd från sitt stycke, presentationens standard‑textstil eller en annan tillämplig källa. Att anropa [GetEffective](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportionformat/) på avsnittsformatet returnerar den slutgiltiga lösta höjden.

Använd de två typerna av formateringsdata för olika ändamål:

- Läs eller ändra ett lokalt formatobjekt, såsom [IPortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportionformat/), när du behöver styra var ett värde definieras.
- Läs ett effektivt dataobjekt, såsom [IPortionFormatEffectiveData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportionformateffectivedata/), när du behöver det slutgiltiga, renderade resultatet. Effektiva data är skrivskyddade.

## **Jämför lokala, ärvda och effektiva värden**

Följande kompletta exempel skapar en form och tillämpar teckensnittshöjder på presentations-, stycke- och avsnivå. Varje steg skriver ut värdena som definierats på dessa nivåer och det resulterande effektiva värdet för samma textavsnitt. Det demonstrerar också varför effektiva data måste läsas igen efter formateringsändringar.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// Definiera ärvda värden på två olika nivåer.
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // Läs effektiva data efter de föregående ändringarna.
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// Ett lokalt värde på avsnittet åsidosätter båda ärvda värden.
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// Att ändra ett ärvt värde ersätter inte ett befintligt lokalt värde.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// Rensa det lokala värdet. Avsnittet ärver nu igen från stycket.
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// Rensa styckets värde. Presentationens standardvärde levererar nu resultatet.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Prioriteten i detta exempel är avsnittets lokala formatering, därefter styckeformatering och sedan presentationens standard. Andra objekt kan ha olika arvskedjor, men principen är densamma: ett mer specifikt explicit värde vinner, och [GetEffective](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportionformat/) returnerar det slutgiltiga resultatet.

## **Hämta effektiva textegenskaper**

Textformatering är uppdelad över flera objekt:

- [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/) löser text‑ram‑egenskaper såsom marginaler, förankring, autofit och vertikal textorientering.
- [ITextStyle::GetEffective](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextstyle/) löser styckeformatering för varje textstilsnivå.
- [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/) löser styckeegenskaper såsom justering, indrag och punktlistor.
- [IPortionFormat::GetEffective](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportionformat/) löser teckengenskaper såsom teckensnittshöjd, teckensnitt, färg, fetstil och kursiv.

För nästa exempel måste `text-formatting.pptx` innehålla minst en bild och en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) med en icke‑tom textruta. IAutoShape kan finnas på vilken position som helst i formsamlingen; koden söker efter ett lämpligt objekt och validerar det innan det används.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **Hämta effektiva 3D‑egenskaper**

[IThreeDFormat::GetEffective](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/) returnerar ett [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformateffectivedata/)‑objekt som samlar alla lösta 3D‑inställningar. Dess [camera](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icameraeffectivedata/), [light rig](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilightrigeffectivedata/), [top bevel](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapebeveleffectivedata/) och [bottom bevel](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapebeveleffectivedata/)‑data visar de motsvarande effektiva inställningarna. Att läsa dessa relaterade inställningar tillsammans gör det lättare att förstå den slutgiltiga 3D‑utseendet på en form.

För detta exempel måste `shape-3d.pptx` innehålla minst en form på den första bilden. Tillämpa 3D‑kamera, belysning eller fasningsinställningar på den formen om du vill att resultatet ska innehålla andra värden än standardvärdena.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **Hämta effektiv tabellformatering**

Tabellformatering kan komma från tabellstilen och från format som tillämpas på hela tabellen, en kolumn, en rad eller en enskild cell. Vid konflikter mellan explicit definierade fyllningar är prioriteten cell, rad, kolumn och sedan hela tabellen. Det effektiva formatet för en cell är det slutgiltiga formatet som används för att rita den cellen.

För detta exempel måste `table-formatting.pptx` innehålla minst en tabell på den första bilden. Tabellen måste ha minst en rad och en kolumn. Koden söker efter en [ITable](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itable/) istället för att anta att den första formen är en tabell.

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

Om du behöver färgen snarare än enbart fyllningstypen, kontrollera först den effektiva [FillType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifillformateffectivedata/), och läs sedan egenskapen som gäller för den typen – till exempel [SolidFillColor](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifillformateffectivedata/) för en solid fyllning.

## **Läs om effektiva data efter ändringar**

Effektiva data beskriver formateringshierarkin vid den tidpunkt den har lösts. Anropa `GetEffective` igen efter att ha ändrat något som kan delta i den hierarkin, inklusive:

- objektets lokala formatering;
- stycke‑ eller textramsstandarder;
- en tabellstil, tabell, kolumn, rad eller cellformat;
- layout‑ eller mästerval‑formatering;
- temadata eller standardvärden på presentationsnivå;
- layouten eller mästerval som tilldelats en bild.

Behåll inte ett effektivt dataobjekt som en permanent ögonblicksbild. Aspose.Slides kan cache:a vissa effektiva data internt, och ett senare `GetEffective`‑anrop kan uppdatera dessa data. Om du behöver jämföra värden före och efter en ändring, kopiera de skalära värden du behöver – exempelvis teckensnittshöjd, färg, justering eller fasningsbredd – till egna variabler innan du gör ändringen.

För att ändra ett värde, uppdatera det lämpliga lokala formatobjektet och anropa sedan `GetEffective` för att verifiera resultatet. Effektiva dataobjekt är själva skrivskyddade.

## **FAQ**

**Hur kan jag avgöra vilken nivå som levererade ett effektivt värde?**

Effektiva data innehåller det slutgiltiga värdet, inte dess källa. Inspektera de tillämpliga lokala objekten från den mest specifika nivån och utåt. För text kan detta inkludera avsnittet, stycket, textramen, layouten, mästervärdet, temat och presentationens standardvärden. Odefinierade värden som `std::numeric_limits<float>::quiet_NaN()` eller `nullptr` indikerar att sökningen fortsätter till en annan nivå.

**Vad händer när ingen nivå definierar en egenskap?**

Aspose.Slides löser den lämpliga PowerPoint‑ eller biblioteksstandardvärdet. Det lösta värdet visas i de effektiva data även om inget lokalt objekt uttryckligen definierar det.

**Varför kan ett effektivt värde ibland vara lika med det lokala värdet?**

Det lokala värdet vann ärvsberäkningen. Detta är förväntat när egenskapen är explicit satt på objektet och ingen mer specifik regel överskrider det.

**När bör jag använda lokala data istället för effektiva data?**

Använd lokala data för att inspektera eller redigera en specifik formateringsnivå. Använd effektiva data när du behöver det slutgiltiga utseendet efter arv, temaregel och tillämpliga stilar har lösts. Det [fullständiga jämförelseexempel](#compare-local-inherited-and-effective-values) demonstrerar båda i samma arbetsflöde.