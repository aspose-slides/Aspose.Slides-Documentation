---
title: Spravovat textová pole v prezentacích PowerPoint v .NET
linktitle: Textová pole
type: docs
weight: 52
url: /cs/net/text-fields/
keywords:
- textové pole
- automatický text
- číslo snímku
- datum a čas
- záhlaví
- zápatí
- textová část
- PowerPoint
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Vytvářejte, kontrolujte, upravujte a odstraňujte textová pole v prezentacích PowerPoint pomocí Aspose.Slides pro .NET. Zachovejte formátování a ověřte uložené soubory PPTX a PPT."
---
## **Přehled**

Odstavec textu se skládá z částí. Běžná [IPortion](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/) obsahuje doslovný text; část pole má také [IField](https://reference.aspose.com/slides/cs/net/aspose.slides/ifield/), jejíž typ určuje automaticky aktualizovanou hodnotu, například číslo snímku nebo datum. Dvě části mohou zobrazovat stejné znaky, přičemž pouze jedna obsahuje pole.

K rozlišení použijte [IPortion.Field](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/field/), která je `null` pro běžný text. [IPortion.AddField](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/addfield/) převádí existující část na pole. Uchovávejte štítek a jeho dynamickou hodnotu v samostatných částech, aby převod hodnoty také nenahrazoval štítek.

Tento průvodce popisuje pole uvnitř textu, jejich formátování a ukládání do formátů PPTX a PPT. Pro textové rámečky a odstavce viz [Manage Text](/slides/cs/net/manage-text/).

## **Vytvoření pole čísla snímku**

Následující kompletní příklad vytvoří textové pole obsahující doslovný štítek `Slide ` následovaný automaticky aktualizovaným číslem. Nastaví velikost, tloušťku a barvu čísla před přidáním pole, poté znovu otevře uloženou prezentaci a zkontroluje typ pole, text a formátování. Vstupní soubor není vyžadován.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

Nová prezentace začíná číslem snímku 1, takže text je `Slide 1`, a oba testy vytisknou `True`. Číslo zůstane polem po opětovném otevření; není to doslovné `1`. Přetypování a indexy v ověření odkazují na tvar a části vytvořené tímto příkladem.

## **Volba typu pole**

[FieldType](https://reference.aspose.com/slides/cs/net/aspose.slides/fieldtype/) implementuje [IFieldType](https://reference.aspose.com/slides/cs/net/aspose.slides/ifieldtype/) a poskytuje následující předdefinované hodnoty. Předávejte vhodnou hodnotu metodě [AddField](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/addfield/).

| Value | Purpose |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/cs/net/aspose.slides/fieldtype/slidenumber/) | Aktuální číslo snímku. |
| [DateTime](https://reference.aspose.com/slides/cs/net/aspose.slides/fieldtype/datetime/) | Datum/čas ve výchozím formátu aplikace pro vykreslování. |
| [DateTime1](https://reference.aspose.com/slides/cs/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/cs/net/aspose.slides/fieldtype/datetime9/) | Předdefinované formáty data nebo kombinace data/času. |
| [DateTime10](https://reference.aspose.com/slides/cs/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/cs/net/aspose.slides/fieldtype/datetime13/) | Předdefinované formáty času, s možností vteřin a 12‑hodinového formátu. |
| [Header](https://reference.aspose.com/slides/cs/net/aspose.slides/fieldtype/header/) | Pole záhlaví; viz omezení zástupného symbolu a formátu níže. |
| [Footer](https://reference.aspose.com/slides/cs/net/aspose.slides/fieldtype/footer/) | Pole zápatí. |

Například [DateTime3](https://reference.aspose.com/slides/cs/net/aspose.slides/fieldtype/datetime3/) představuje den, úplný název měsíce a rok v angličtině. Jedná se o předdefinované formáty polí, nikoli o libovolné řetězce .NET pro formátování data. [LanguageId](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/languageid/) části a aplikace zpracovávající prezentaci mohou ovlivnit zobrazený výsledek.

## **Vytvoření pole z interního řetězce**

Přetížení metody [AddField](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/addfield/) pro řetězec přijímá interní identifikátor pole. Použijte jej při zachování identifikátoru poskytnutého jinou aplikací, která nemá předdefinovanou hodnotu. Můžete také vytvořit [FieldType](https://reference.aspose.com/slides/cs/net/aspose.slides/fieldtype/fieldtype/) z identifikátoru. [IFieldType.InternalString](https://reference.aspose.com/slides/cs/net/aspose.slides/ifieldtype/internalstring/) odhaluje tento identifikátor pro kontrolu.

Tento příklad ukládá aplikací specifické pole `custom-report-id` s náhradním textem `Report-042`. Identifikátor nezaregistruje žádný výpočet: Aspose.Slides negeneruje ID reportů pro neznámý typ. Aplikace, která tento identifikátor rozumí, musí poskytnout jeho význam a aktualizovat jeho hodnotu.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

Po tomto průchodu PPTX je typ `custom-report-id` a text je `Report-042`. Předání řetězce jako `yyyy-MM-dd` by pojmenovalo typ pole; nenastaví vlastní formát data. Pro pevné datum v libovolném formátu použijte běžný text.

## **Prohlížení, úprava a odstranění polí datum/čas**

Čtěte a měňte existující pole pomocí [IField.Type](https://reference.aspose.com/slides/cs/net/aspose.slides/ifield/type/). Zkontrolujte, že pole existuje, než přistoupíte k jeho typu. Pro zastavení automatických aktualizací zavolejte [IPortion.RemoveField](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/removefield/). Tím zachováte část a její aktuální text a odstraníte spojení pole. Pokud potřebujete konkrétní pevnou hodnotu, přiřaďte tento text po odstranění pole.

Pro nastavení API související se zpracováním pole datum/čas viz [Presentation.CurrentDateTime](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/currentdatetime/). Níže uvedený příklad používá explicitní datum schválení při převodu pole na běžný text.

Stáhněte [sample.pptx](sample.pptx) a umístěte jej do pracovního adresáře. Obsahuje dva pojmenované textové tvary, `UpdatedAt` a `ApprovedDate`, každý s polem datum/čas, plus běžné textové štítky. Následující příklad prochází textové tvary nejvyšší úrovně na běžných snímcích. Změní pole datum/čas na dlouhý formát data a nastaví kurzívu, přičemž zachová jejich další formátování. Pouze pole v `ApprovedDate` se stanou pevným textem.

Ukázka rozpoznává vestavěné interní identifikátory `datetime` a `datetime1` až `datetime13`. Skupiny, tabulky, poznámky, rozložení a hlavní snímky vyžadují procházení jejich vlastních textových kontejnerů a jsou mimo rozsah tohoto příkladu.

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

Po opětovném otevření má `UpdatedAt` typ `datetime3` a zůstává dynamický. `ApprovedDate` nemá pole a obsahuje `05 April 2030`. Obě části data jsou kurzívou a jejich původní velikost písma, nastavení tučnosti a barva zůstávají zachovány. Běžné textové štítky zůstávají beze změny. Ověření čte první část dvou známých tvarů v dodané ukázce.

## **Zachování formátování textu**

Pracujte s existující částí při přidávání pole, změně jeho typu nebo jeho odstranění. Tyto operace zachovávají formátování části. Použijte [IPortion.PortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/portionformat/) abyste změnili pouze požadované vlastnosti, jak ukazují příklady pro barvu nebo kurzívu.

Vyhněte se přestavování celého textového rámce jen kvůli aktualizaci jednoho pole: může to ztratit původní hranice částí a jejich individuální formátování. Také rozlišujte explicitně nastavené formátování od formátování zděděného od odstavce, rozložení nebo motivu. Viz [Text Formatting](/slides/cs/net/text-formatting/) pro širší možnosti formátování.

## **Pole a zástupné symboly záhlaví/zápatí**

Pole je částí textové části. Zástupný symbol je tvar s rolí v prezentaci, například zápatí nebo číslo snímku. Přidání pole do běžného textového pole tvar nepromění na zástupný symbol.

Správci záhlaví/zápatí řídí text zástupných symbolů a jejich viditelnost na snímcích, rozloženích a hlavních šablonách, včetně propagace na závislé snímky. Číselné pole v uživatelském textovém poli může být užitečné i tehdy, když nepoužíváte zástupný symbol čísla snímku. Naopak změna viditelnosti zástupného symbolu neodstraní pole z nesouvisejícího textového pole.

Předdefinované typy záhlaví a zápatí nevytvářejí odpovídající zástupné symboly ani neposkytují jejich obsah. Konkrétně běžný snímek PowerPoint nemá zástupný symbol záhlaví; záhlaví patří k poznámkovým stránkám a výstřižkům. Neočekávejte, že pole záhlaví nebo zápatí v libovolném tvaru automaticky získá text nastavený správcem zástupných symbolů. Pro tento postup viz [Presentation Headers and Footers](/slides/cs/net/presentation-header-and-footer/).

## **Omezení PPTX a PPT**

Zkontrolujte jak typ pole, tak jeho výsledný text po uložení a opětovném otevření. Zachování identifikátoru neprokazuje, že aplikace dokáže vypočítat nebo zobrazit jeho hodnotu.

| Format | Field behavior and limitations |
|---|---|
| PPTX | Ukládá interní identifikátory pole spolu s textem pole. V kontrolách při průchodu zachovaly předdefinované typy a výše použitý vlastní identifikátor po uložení a opětovném otevření. Neznámý vlastní typ si zachoval náhradní text; nezískal automatickou výpočetní logiku. Jiná aplikace může s nepodporovanými identifikátory zacházet odlišně. |
| PPT | Používá starší reprezentace polí a má omezenější kompatibilitu. V kontrolách při průchodu přežily pole čísla snímku a předdefinovaná pole datum/čas po uložení a opětovném otevření. Vlastní pole v běžném textovém poli snímku se po otevření zobrazilo s identifikátorem, ale s textem `*`; pole záhlaví ve stejném kontextu také vyprodukovalo `*`. Nespoléhejte se, že vlastní pole nebo nepodporované kontexty polí si zachovají viditelný text. |

Pro přenosný, pevný výstup převeďte nepodporovaná pole na běžný text a před uložením explicitně přiřaďte požadovanou hodnotu. Tím zachováte vybraný text, ale úmyslně zastavíte automatické aktualizace. Otestujte také cílovou aplikaci, pokud je součástí vašeho postupu její vlastní přepočet polí.

## **FAQ**

**Jak mohu zjistit, zda je zobrazené číslo nebo datum polem?**

Prohlédněte [IPortion.Field](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/field/). Hodnota různá od null identifikuje pole; samotný zobrazený text to neprozradí.

**Odstraní odstranění pole jeho text nebo formátování?**

Není. [RemoveField](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/removefield/) převádí existující část na běžný text. Pokud potřebujete konkrétní zamrzlé datum nebo náhradní hodnotu, přiřaďte ji následně.

**Může interní řetězec definovat nový formát data nebo vzorec?**

Není. Identifikuje typ pole. Neznámý identifikátor neposkytuje vyhodnocovač ani .NET vzor pro formátování data. Použijte podporovaný předdefinovaný typ nebo formátujte hodnotu sami jako běžný text.

**Proč po uložení prezentaci znovu zkontrolovat?**

Identifikátory polí, vypočtený text a formátování jsou oddělené věci, které je potřeba ověřit. Převod formátu může změnit viditelný výsledek, i když identifikátor pole zůstane.