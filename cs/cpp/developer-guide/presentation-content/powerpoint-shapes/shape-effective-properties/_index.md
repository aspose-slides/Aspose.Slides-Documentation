---
title: Získání efektivních vlastností tvaru z prezentací v C++
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
- textový styl
- výška písma
- formát výplně
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro C++ vypočítává a aplikuje efektivní vlastnosti tvaru pro přesné vykreslování v PowerPointu."
---
## **Přehled**

Toto téma vysvětluje rozdíl mezi **lokálními** a **efektivními** vlastnostmi. Lokální hodnoty jsou hodnoty, které jsou nastaveny přímo na konkrétní úrovni formátování, například:

1. Vlastnosti úseku na snímku.
1. Textové styly prototypových tvarů na rozvržení nebo hlavním snímku, pokud má tvar textového rámce úseku.
1. Globální nastavení textu v prezentaci.

Lokální hodnoty mohou být na libovolné úrovni definovány nebo vynechány. Když Aspose.Slides potřebuje konečné „tak, jak je vykresleno“ formátování, rozřeší řetězec dědičnosti a vrátí **efektivní** hodnoty. Můžete je získat zavoláním metody `GetEffective` na objekt lokálního formátu.

Následující příklad ukazuje, jak získat efektivní hodnoty. Předpokládá, že první tvar na prvním snímku je [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) s textovým rámcem a alespoň jedním úsekem.

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
Údaje o efektivním formátování představují aktuální vypočítané formátování po aplikaci dědičnosti. V aktuální implementaci mohou být některé objekty efektivních dat, například [IPortionFormatEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportionformateffectivedata/), uloženy vnitřně do mezipaměti. Zavolání `GetEffective` znovu po změně nadřazeného nebo zděděného formátování může obnovit data v mezipaměti a dříve získaný objekt už nemusí představovat předchozí stav. Pokud potřebujete zachovat efektivní hodnoty pro pozdější opětovné použití, zkopírujte požadované vlastnosti, jako je výška písma, barva výplně, styl písma nebo zarovnání, do vlastního datového objektu.
{{% /alert %}}

## **Získání efektivních vlastností kamery**

Aspose.Slides umožňuje získat efektivní vlastnosti kamery. Rozhraní [ICameraEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icameraeffectivedata/) představuje neměnný objekt, který obsahuje efektivní vlastnosti kamery. Instance [ICameraEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icameraeffectivedata/) je zpřístupněna prostřednictvím [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformateffectivedata/), který poskytuje efektivní hodnoty pro [IThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/).

Následující ukázka kódu ukazuje, jak získat efektivní vlastnosti kamery. Předpokládá, že první tvar na prvním snímku má 3D formátování.

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

## **Získání efektivních vlastností světelného zařízení**

Aspose.Slides umožňuje získat efektivní vlastnosti světelného zařízení. Rozhraní [ILightRigEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilightrigeffectivedata/) představuje neměnný objekt, který obsahuje efektivní vlastnosti světelného zařízení. Instance [ILightRigEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilightrigeffectivedata/) je zpřístupněna prostřednictvím [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformateffectivedata/), který poskytuje efektivní hodnoty pro [IThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/).

Následující ukázka kódu ukazuje, jak získat efektivní vlastnosti světelného zařízení. Předpokládá, že první tvar na prvním snímku má 3D formátování.

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

## **Získání efektivních vlastností zkoseného tvaru**

Aspose.Slides umožňuje získat efektivní vlastnosti zkosení tvaru. Rozhraní [IShapeBevelEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapebeveleffectivedata/) představuje neměnný objekt, který obsahuje efektivní vlastnosti povrchových reliéfů tvaru. Instance [IShapeBevelEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapebeveleffectivedata/) je zpřístupněna prostřednictvím [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformateffectivedata/), který poskytuje efektivní hodnoty pro [IThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/).

Následující ukázka kódu ukazuje, jak získat efektivní vlastnosti horního zkosení tvaru. Předpokládá, že první tvar na prvním snímku má 3D formátování.

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

## **Získání efektivních vlastností textového rámce**

Pomocí Aspose.Slides můžete získat efektivní vlastnosti textového rámce. Rozhraní [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformateffectivedata/) obsahuje efektivní vlastnosti formátování textového rámce.

Následující ukázka kódu ukazuje, jak získat efektivní vlastnosti formátování textového rámce. Předpokládá, že první tvar na prvním snímku je [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) s textovým rámcem.

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

## **Získání efektivních vlastností textového stylu**

Pomocí Aspose.Slides můžete získat efektivní vlastnosti textového stylu. Rozhraní [ITextStyleEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextstyleeffectivedata/) obsahuje efektivní vlastnosti textového stylu.

Následující ukázka kódu ukazuje, jak získat efektivní vlastnosti textového stylu. Předpokládá, že první tvar na prvním snímku je [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) s textovým rámcem.

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

## **Získání efektivní výšky písma**

Pomocí Aspose.Slides můžete získat efektivní výšku písma. Následující kód ukazuje, jak se efektivní výška písma úseku mění po nastavení lokálních hodnot výšky písma na různých úrovních struktury prezentace.

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

## **Získání efektivního formátu výplně pro tabulku**

Pomocí Aspose.Slides můžete získat efektivní formátování výplně pro různé části tabulky. Rozhraní [IFillFormatEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifillformateffectivedata/) obsahuje efektivní vlastnosti formátování výplně. Formátování buňky má vyšší prioritu než formátování řádku, formátování řádku má vyšší prioritu než formátování sloupce a formátování sloupce má vyšší prioritu než formátování celé tabulky.

Výsledkem jsou vlastnosti [ICellFormatEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icellformateffectivedata/), které se používají k vykreslení buňky tabulky. Následující ukázka kódu ukazuje, jak získat efektivní formátování výplně pro různé části tabulky. Předpokládá, že první tvar na prvním snímku je [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/).

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

## **Často kladené otázky**

**Vrací `GetEffective` statický snímek?**

Ne vždy. Efektivní data představují vypočítané formátování po aplikaci dědičnosti, ale některé objekty efektivních dat mohou být uloženy v interní mezipaměti. Následující volání `GetEffective` může formátování přepočítat a aktualizovat mezipaměť, takže dříve získaný objekt již nemusí představovat předchozí stav.

**Kdy bych měl znovu načíst efektivní vlastnosti?**

Volání `GetEffective` znovu po změně lokálního formátování, nadřazených stylů, formátování rozvržení, hlavního formátování nebo výchozích nastavení na úrovni prezentace. Další volání znovu vyhodnotí hierarchii formátování a vrátí aktuální efektivní výsledek.

**Ovlivňuje změna nebo odebrání rozvržení/hlavního snímku efektivní vlastnosti, které již byly získány?**

Ano, ale změna se projeví při dalším volání `GetEffective`. Pokud se změní nebo odstraní zdroj nadřazeného formátování, dříve získaná efektivní data mohou být zastaralá. Po opětovném volání `GetEffective` Aspose.Slides přehodnotí formátovací strom a výsledné písma, barvy, velikosti nebo jiné hodnoty se mohou změnit.

**Mohu měnit hodnoty pomocí objektů efektivních dat?**

Ne. Objekty efektivních dat poskytují pouze vypočítané hodnoty. Změny provádějte v lokálních objektech formátování a poté opět získávejte efektivní hodnoty.

**Co se stane, pokud není vlastnost nastavena na úrovni tvaru, ani v rozvržení/hlavním snímku, ani v globálním nastavení?**

Efektivní hodnota je určena výchozím mechanismem, který zahrnuje výchozí nastavení PowerPointu a Aspose.Slides. Tato rozpoznaná hodnota se stane součástí aktuálních efektivních dat.

**Z efektivní hodnoty písma mohu zjistit, která úroveň poskytla velikost nebo typ písma?**

Ne přímo. Efektivní data vracejí finální hodnotu. Pro zjištění zdroje zkontrolujte lokální hodnoty v úseku, odstavci, textovém rámci a textových stylech na úrovni rozvržení, hlavního snímku a celé prezentace, abyste zjistili, kde se objeví první explicitní definice.

**Proč se efektivní hodnoty někdy shodují s lokálními?**

Protože lokální hodnota se stala konečnou (nebyla potřeba vyšší úroveň dědičnosti). V takových případech se efektivní hodnota shoduje s lokální.

**Kdy bych měl používat efektivní vlastnosti a kdy pracovat jen s lokálními?**

Používejte efektivní data, když potřebujete výsledek „tak, jak je vykreslen“ po aplikaci veškeré dědičnosti, například pro sladění barev, odsazení nebo velikostí. Pokud chcete tyto hodnoty zachovat nezávisle na pozdějších změnách formátování, zkopírujte požadované vlastnosti do vlastního objektu. Pokud potřebujete změnit formátování na konkrétní úrovni, upravte lokální vlastnosti a poté, pokud je to nutné, znovu načtěte efektivní data k ověření výsledku.