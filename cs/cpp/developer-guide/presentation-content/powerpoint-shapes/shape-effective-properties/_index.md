---
title: Získat efektivní vlastnosti tvaru z prezentací v C++
linktitle: Efektivní vlastnosti
type: docs
weight: 50
url: /cs/cpp/shape-effective-properties/
keywords:
- vlastnosti tvaru
- vlastnosti kamery
- světelný rig
- zkosený tvar
- textový rámec
- styl textu
- výška písma
- formát výplně
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak pomocí Aspose.Slides pro C++ rozlišovat lokální, zděděné a efektivní formátování tvarů v prezentacích PowerPoint."
---
## **Rozumět lokálním, zděděným a efektivním vlastnostem**

Formátování PowerPointu může pocházet z několika míst. Hodnota uložená přímo na objektu je jeho **lokální hodnota**. Pokud tato hodnota není nastavena, PowerPoint se podívá na nadřazené zdroje formátování, jako je výchozí odstavec, styl textu, rozvržení nebo hlavní snímek, motiv nebo výchozí nastavení na úrovni prezentace. Tyto hodnoty jsou **zděděné hodnoty**. Hodnota, která zůstane po vyřešení celé hierarchie, je **efektivní hodnota** — hodnota použitá k vykreslení objektu.

Například část textu nemusí definovat vlastní [výška písma](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseportionformat/). Její lokální hodnota je pak `std::numeric_limits<float>::quiet_NaN()`, což znamená „není zde nastavena“. Část může zdědit výšku ze svého odstavce, výchozího stylu textu prezentace nebo jiného relevantního zdroje. Volání [GetEffective](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportionformat/) na formát části vrátí finální vyřešenou výšku.

Použijte dva typy formátovacích dat pro různé účely:

- Čtěte nebo měňte lokální formátovací objekt, jako je [IPortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportionformat/), když potřebujete kontrolovat, kde je hodnota definována.
- Čtěte efektivní datový objekt, jako je [IPortionFormatEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportionformateffectivedata/), když potřebujete finální, vykreslený výsledek. Efektivní data jsou jen ke čtení.

## **Porovnat lokální, zděděné a efektivní hodnoty**

Následující úplný příklad vytvoří tvar a použije výšky písma na úrovních prezentace, odstavce a části. Každý krok vytiskne hodnoty definované na těchto úrovních a výslednou efektivní hodnotu pro stejnou část textu. také ukazuje, proč je třeba po změnách formátování znovu načíst efektivní data.

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

// Definujte zděděné hodnoty na dvou různých úrovních.
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

    // Načtěte efektivní data po předchozích změnách.
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// Lokální hodnota v části přepíše obě zděděné hodnoty.
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// Změna zděděné hodnoty nepřepíše existující lokální hodnotu.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// Vymažte lokální hodnotu. Část nyní znovu dědí z odstavce.
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// Vymažte hodnotu odstavce. Výchozí nastavení prezentace nyní poskytuje výsledek.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Priorita v tomto příkladu je lokální formátování části, pak formátování odstavce a nakonec výchozí nastavení prezentace. Ostatní objekty mohou mít odlišné dědické řetězce, ale princip je stejný: konkrétnější explicitní hodnota vítězí a [GetEffective](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportionformat/) vrátí konečný výsledek.

## **Získat efektivní textové vlastnosti**

Formátování textu je rozděleno mezi několik objektů:

- [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/) řeší vlastnosti textového rámce, jako jsou okraje, ukotvení, automatické přizpůsobení a svislý směr textu.
- [ITextStyle::GetEffective](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextstyle/) řeší formátování odstavce pro každou úroveň textového stylu.
- [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/) řeší vlastnosti odstavce, jako jsou zarovnání, odsazení a odrážky.
- [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportionformat/) řeší vlastnosti znaků, jako jsou výška písma, typ písma, barva, tučné a kurzíva.

Pro následující příklad musí `text-formatting.pptx` obsahovat alespoň jeden snímek a jednu [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) s neprázdným textovým rámcem. IAutoShape může být kdekoliv ve sbírce tvarů; kód vyhledá vhodný objekt a před použitím jej ověří.

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

## **Získat efektivní 3D vlastnosti**

[IThreeDFormat::GetEffective](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/) vrací jeden objekt [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformateffectivedata/), který sdružuje všechna vyřešená 3D nastavení. Jeho [camera](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icameraeffectivedata/), [light rig](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilightrigeffectivedata/), [top bevel](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapebeveleffectivedata/) a [bottom bevel](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapebeveleffectivedata/) data zveřejňují odpovídající efektivní nastavení. Čtení těchto souvisejících nastavení najednou usnadňuje pochopení konečného 3D vzhledu tvaru.

Pro tento příklad musí `shape-3d.pptx` obsahovat alespoň jeden tvar na prvním snímku. Použijte 3D kameru, osvětlení nebo nastavení zkosení na tento tvar, pokud chcete, aby výstup obsahoval jiné hodnoty než výchozí.

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

## **Získat efektivní formátování tabulky**

Formátování tabulky může pocházet ze stylu tabulky a z formátů aplikovaných na celou tabulku, sloupec, řádek nebo jednotlivou buňku. Při konfliktech mezi explicitně definovanými výplněmi je priority: buňka, řádek, sloupec a pak celá tabulka. Efektivní formát buňky je finální formát použitý k vykreslení této buňky.

Pro tento příklad musí `table-formatting.pptx` obsahovat alespoň jednu tabulku na prvním snímku. Tabulka musí mít alespoň jeden řádek a jeden sloupec. Kód hledá [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) místo toho, aby předpokládal, že první tvar je tabulka.

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

Pokud potřebujete barvu místo jen typu výplně, nejprve zkontrolujte efektivní [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifillformateffectivedata/), a pak přečtěte vlastnost, která se k tomuto typu vztahuje — například [SolidFillColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifillformateffectivedata/) pro plnou výplň.

## **Znovu načíst efektivní data po změnách**

Efektivní data popisují hierarchii formátování v okamžiku, kdy je vyřešena. Zavolejte `GetEffective` znovu po změně čehokoliv, co může v této hierarchii participovat, včetně:

- lokálního formátování objektu;
- výchozích hodnot odstavce nebo textového rámce;
- stylu tabulky, tabulky, sloupce, řádku nebo formátu buňky;
- formátování rozvržení nebo hlavního snímku;
- dat motivu nebo výchozích hodnot na úrovni prezentace;
- rozvržení nebo hlavního snímku přiřazeného k snímku.

Neuchovávejte efektivní datový objekt jako trvalý snímek. Aspose.Slides může interně cacheovat některá efektivní data a pozdější volání `GetEffective` může tato data obnovit. Pokud potřebujete porovnat hodnoty před a po změně, zkopírujte skalární hodnoty, které potřebujete — například výšku písma, barvu, zarovnání nebo šířku zkosení — do vlastních proměnných před provedením změny.

Pro změnu hodnoty aktualizujte příslušný lokální formátovací objekt a pak zavolejte `GetEffective` k ověření výsledku. Efektivní datové objekty jsou samy o sobě jen ke čtení.

## **Často kladené otázky**

**Jak mohu zjistit, která úroveň poskytla efektivní hodnotu?**

Efektivní data obsahují finální hodnotu, ne její zdroj. Prozkoumejte příslušné lokální objekty od nejkonkrétnější úrovně směrem ven. Pro text to může zahrnovat část, odstavec, textový rámec, rozvržení, hlavní snímek, motiv a výchozí nastavení prezentace. Neurčené hodnoty jako `std::numeric_limits<float>::quiet_NaN()` nebo `nullptr` naznačují, že hledání pokračuje na další úroveň.

**Co se stane, když žádná úroveň nedefinuje vlastnost?**

Aspose.Slides vyřeší příslušnou výchozí hodnotu PowerPointu nebo knihovny. Tato vyřešená hodnota se objeví v efektivních datech, i když žádný lokální objekt ji explicitně nedefinuje.

**Proč se efektivní hodnota někdy rovná lokální hodnotě?**

Lokální hodnota vyhrála výpočet dědičnosti. To je očekávané, když je vlastnost explicitně nastavena na objektu a žádné konkrétnější pravidlo ji nepřebije.

**Kdy bych měl použít lokální data místo efektivních dat?**

Používejte lokální data k inspekci nebo úpravě konkrétní úrovně formátování. Používejte efektivní data, když potřebujete finální vzhled po aplikaci dědičnosti, pravidel motivu a relevantních stylů. [Kompletní příklad porovnání](#compare-local-inherited-and-effective-values) ukazuje obojí ve stejném pracovním postupu.