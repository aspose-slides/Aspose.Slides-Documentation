---
title: Získání efektivních vlastností tvaru z prezentací v C++
linktitle: Efektivní vlastnosti
type: docs
weight: 50
url: /cs/cpp/shape-effective-properties/
keywords:
- vlastnosti tvaru
- vlastnosti kamery
- světelná sestava
- tvar se zkosením
- textový rámec
- textový styl
- výška písma
- formát výplně
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro C++ počítá a aplikuje efektivní vlastnosti tvarů pro přesné vykreslení PowerPointu."
---
## **Přehled**

Toto téma vysvětluje rozdíl mezi **lokálními** a **efektivními** vlastnostmi. Lokální hodnoty jsou hodnoty, které jsou nastaveny přímo na konkrétní úrovni formátování, například:

1. Vlastnosti úseku na snímku.
1. Prototypové styly textu tvaru na rozložení nebo hlavním snímku, pokud má textový rámec úseku vlastní tvar.
1. Globální nastavení textu v prezentaci.

Lokální hodnoty mohou být definovány nebo vynechané na libovolné úrovni. Když Aspose.Slides potřebuje finální „jako vykreslené“ formátování, projde řetězec dědičnosti a vrátí **efektivní** hodnoty. Ty získáte voláním metody `GetEffective` na objektu lokálního formátu.

Následující příklad ukazuje, jak získat efektivní hodnoty. Předpokládá, že první tvar na prvním snímku je [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) s textovým rámcem a alespoň jedním úsekem.

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
Efektivní data formátování představují aktuální vypočtené formátování po aplikaci dědičnosti. V současné implementaci mohou být některé objekty efektivních dat, například [IPortionFormatEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportionformateffectivedata/), uloženy v interní cache. Opětovné volání `GetEffective` po změně nadřazeného nebo zděděného formátování může vyprázdnit tuto cache a dříve získaný objekt už nemusí představovat předchozí stav. Pokud potřebujete zachovat efektivní hodnoty pro pozdější použití, zkopírujte požadované vlastnosti, jako je výška písma, barva výplně, styl písma nebo zarovnání, do vlastního datového objektu.
{{% /alert %}}

## **Získání efektivních vlastností kamery**

Aspose.Slides umožňuje získat efektivní vlastnosti kamery. Rozhraní [ICameraEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icameraeffectivedata/) představuje neměnný objekt, který obsahuje efektivní vlastnosti kamery. Instance [ICameraEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icameraeffectivedata/) je vystavena přes [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformateffectivedata/), které poskytuje efektivní hodnoty pro [IThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/).

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti kamery. Předpokládá se, že první tvar na prvním snímku má 3D formátování.

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

## **Získání efektivních vlastností světelné sestavy**

Aspose.Slides umožňuje získat efektivní vlastnosti světelné sestavy. Rozhraní [ILightRigEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilightrigeffectivedata/) představuje neměnný objekt, který obsahuje efektivní vlastnosti světelné sestavy. Instance [ILightRigEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilightrigeffectivedata/) je vystavena přes [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformateffectivedata/), které poskytuje efektivní hodnoty pro [IThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/).

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti světelné sestavy. Předpokládá se, že první tvar na prvním snímku má 3D formátování.

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

## **Získání efektivních vlastností zkosení tvaru**

Aspose.Slides umožňuje získat efektivní vlastnosti zkosení tvaru. Rozhraní [IShapeBevelEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapebeveleffectivedata/) představuje neměnný objekt, který obsahuje efektivní vlastnosti reliéfu pro tvar. Instance [IShapeBevelEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapebeveleffectivedata/) je vystavena přes [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformateffectivedata/), které poskytuje efektivní hodnoty pro [IThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/).

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti horního zkosení tvaru. Předpokládá se, že první tvar na prvním snímku má 3D formátování.

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

## **Získání efektivních vlastností textového rámce**

Pomocí Aspose.Slides můžete získat efektivní vlastnosti textového rámce. Rozhraní [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformateffectivedata/) obsahuje efektivní vlastnosti formátování textového rámce.

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti formátování textového rámce. Předpokládá se, že první tvar na prvním snímku je [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) s textovým rámcem.

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

## **Získání efektivních vlastností textového stylu**

Pomocí Aspose.Slides můžete získat efektivní vlastnosti textového stylu. Rozhraní [ITextStyleEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextstyleeffectivedata/) obsahuje efektivní vlastnosti textového stylu.

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti textového stylu. Předpokládá se, že první tvar na prvním snímku je [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) s textovým rámcem.

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

## **Získání efektivní hodnoty výšky písma**

Pomocí Aspose.Slides můžete získat efektivní výšku písma. Následující kód demonstruje, jak se efektivní výška písma úseku mění po nastavení lokálních hodnot výšky písma na různých úrovních struktury prezentace.

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

## **Získání efektivního formátu výplně pro tabulku**

Pomocí Aspose.Slides můžete získat efektivní formátování výplně pro různé části tabulky. Rozhraní [IFillFormatEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifillformateffectivedata/) obsahuje efektivní vlastnosti formátování výplně. Formátování buňky má vyšší prioritu než formátování řádku, řádkové formátování má vyšší prioritu než formátování sloupce a formátování sloupce má vyšší prioritu než formátování celé tabulky.

Výsledkem je, že vlastnosti [ICellFormatEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icellformateffectivedata/) jsou použity při vykreslování buňky tabulky. Následující ukázkový kód ukazuje, jak získat efektivní formátování výplně pro různé části tabulky. Předpokládá se, že první tvar na prvním snímku je [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/).

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

## **Často kladené otázky**

### Vrací `GetEffective` snímek?

Ne vždy. Efektivní data představují vypočtené formátování po aplikaci dědičnosti, ale některé objekty efektivních dat mohou být interně uloženy v cache. Následující volání `GetEffective` může znovu vypočítat formátování a obnovit cache, takže dříve získaný objekt by neměl být považován za trvalý snímek.

### Kdy mám znovu načíst efektivní vlastnosti?

Zavolejte `GetEffective` znovu po změně lokálního formátování, nadřazených stylů, formátování rozložení, formátování hlavního snímku nebo výchozích nastavení na úrovni celé prezentace. Další volání znovu vyhodnotí hierarchii formátování a vrátí aktuální efektivní výsledek.

### Ovlivní změna nebo odstranění rozložení/hlavního snímku efektivní vlastnosti, které již byly získány?

Ano, změna se projeví při dalším volání `GetEffective`. Pokud je změněn nebo odstraněn zdroj nadřazeného formátování, dříve získaná efektivní data mohou být zastaralá. Po opětovném volání `GetEffective` Aspose.Slides přehodnotí strom formátování a výsledná písma, barvy, velikosti či jiné hodnoty se mohou změnit.

### Mohu měnit hodnoty prostřednictvím objektů efektivních dat?

Ne. Objektům efektivních dat jsou k dispozici pouze vypočtené hodnoty. Změny provádějte v lokálních objektech formátování a poté znovu získávejte efektivní hodnoty.

### Co se stane, pokud není vlastnost nastavena na úrovni tvaru, ani v rozložení/hlavním snímku, ani v globálním nastavení?

Efektivní hodnota je určena výchozím mechanismem, který zahrnuje výchozí hodnoty PowerPointu i Aspose.Slides. Tato vyřešená hodnota se stane součástí aktuálních efektivních dat.

### Z efektivní hodnoty písma, dokážu zjistit, na které úrovni byla velikost nebo typ písma určena?

Ne přímo. Efektivní data vracejí konečnou hodnotu. Pro zjištění zdroje zkontrolujte lokální hodnoty na úrovni úseku, odstavce, textového rámce a textových stylů na rozložení, hlavním snímku a úrovni prezentace, abyste našli první explicitní definici.

### Proč vypadají efektivní hodnoty někdy identicky jako lokální?

Protože lokální hodnota se ukázala jako konečná (není potřeba žádná vyšší úroveň dědičnosti). V takových případech se efektivní hodnota shoduje s lokální.

### Kdy mám používat efektivní vlastnosti a kdy jen lokální?

Používejte efektivní data, když potřebujete výsledek „jako vykreslený“ po všech aplikacích dědičnosti, například pro sladění barev, odsazení nebo velikostí. Pokud potřebujete tyto hodnoty zachovat nezávisle na pozdějších změnách formátování, zkopírujte požadované vlastnosti do vlastního objektu. Pokud chcete měnit formátování na konkrétní úrovni, upravte lokální vlastnosti a poté, pokud je to potřeba, znovu načtěte efektivní data k ověření výsledku.