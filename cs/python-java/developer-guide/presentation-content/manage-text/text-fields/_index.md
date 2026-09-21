---
title: "Správa textových polí v prezentacích PowerPoint v Pythonu prostřednictvím Javy"
linktitle: "Textová pole"
type: docs
weight: 52
url: /cs/python-java/text-fields/
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
- Python
- Java
- Aspose.Slides
description: "Vytvářejte, kontrolujte, upravujte a odstraňujte textová pole v prezentacích PowerPoint pomocí Aspose.Slides pro Python prostřednictvím Javy. Zachovejte formátování a ověřte uložené soubory PPTX a PPT."
---
## **Přehled**

Textový odstavec se skládá z částí. Obyčejná [Portion](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/) obsahuje doslovný text; část pole má také [Field](https://reference.aspose.com/slides/cs/python-java/aspose.slides/field/) jejíž typ určuje automaticky aktualizovanou hodnotu, například číslo snímku nebo datum. Dvaja části mohou zobrazovat stejné znaky, přičemž jen jedna obsahuje pole.

Použijte [Portion.getField](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/#getField), abyste je rozlišili: pro obyčejný text je to `None`. [Portion.addField](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/#addField) převádí existující část na pole. Uchovávejte popisek a jeho dynamickou hodnotu v samostatných částech, aby převod hodnoty také nenahradil popisek.

Tento průvodce pokrývá pole v textu, jejich formátování a ukládání v PPTX a PPT. Pro textové rámy a odstavce viz [Manage Text](/slides/cs/python-java/manage-text/).

## **Vytvoření pole čísla snímku**

Následující úplný příklad vytvoří textové políčko obsahující doslovný popisek `Slide ` následovaný automaticky aktualizovaným číslem. Nejprve nastaví velikost, tloušťku a barvu čísla před přidáním pole, poté znovu otevře uloženou prezentaci a zkontroluje typ pole, text a formátování. Vstupní soubor není vyžadován.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Nová prezentace začíná číslem snímku 1, takže text je `Slide 1` a oba testy vytisknou `True`. Číslo zůstává polem po opětovném otevření; není to doslovná `1`. Indexy v ověření odkazují na tvar a části vytvořené tímto příkladem.

## **Zvolte typ pole**

[FieldType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fieldtype/) poskytuje následující metody pro získání předdefinovaných hodnot. Předávejte vhodnou hodnotu metodě [addField](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/#addField).

| Metoda | Účel |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fieldtype/#getSlideNumber) | Aktuální číslo snímku. |
| [getDateTime](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fieldtype/#getDateTime) | Datum/čas ve výchozím formátu aplikace vykreslující. |
| [getDateTime1](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fieldtype/#getDateTime9) | Předdefinované formáty data nebo kombinované datum/čas. |
| [getDateTime10](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fieldtype/#getDateTime13) | Předdefinované formáty času s možnostmi sekund a 12‑hodinového času. |
| [getHeader](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fieldtype/#getHeader) | Pole záhlaví; viz omezení zástupce a formátu níže. |
| [getFooter](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fieldtype/#getFooter) | Pole zápatí. |

Například [getDateTime3](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fieldtype/#getDateTime3) představuje den, úplný název měsíce a rok v angličtině. Jedná se o předdefinované formáty pole, ne libovolné řetězce formátu data v Pythonu. Jazyk nastavený pomocí [setLanguageId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setLanguageId) a aplikace zpracovávající prezentaci mohou ovlivnit zobrazený výsledek.

## **Vytvoření pole z interního řetězce**

Přetížení řetězcem metody [addField](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/#addField) přijímá interní identifikátor pole. Použijte jej při zachování identifikátoru poskytnutého jinou aplikací, která nemá předdefinovanou hodnotu. Můžete také vytvořit [FieldType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fieldtype/#FieldType) z tohoto identifikátoru. [FieldType.getInternalString](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fieldtype/#getInternalString) odhalí tento identifikátor pro kontrolu.

Tento příklad ukládá aplikací specifické pole `custom-report-id` s náhradním textem `Report-042`. Identifikátor neregistruje výpočet: Aspose.Slides negeneruje ID zpráv pro neznámý typ. Aplikace, která tento identifikátor rozpozná, musí poskytnout jeho význam a aktualizovat jeho hodnotu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Po tomto PPTX průchodu je typ `custom-report-id` a text `Report-042`. Předání řetězce jako `yyyy-MM-dd` by pojmenovalo typ pole; nenastaví vlastní formát data. Pro pevné datum v libovolném formátu použijte obyčejný text.

## **Zkoumání, úprava a odstranění polí datum/čas**

Změňte existující pole pomocí [Field.setType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/field/#setType). Ověřte, že pole existuje, než získáte jeho typ. Pro zastavení automatických aktualizací zavolejte [Portion.removeField](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/#removeField). Tím zachováte část a její aktuální text při odebrání spoje s polem. Pokud potřebujete konkrétní pevnou hodnotu, přiřaďte tento text po odstranění pole.

Pro nastavení API související se zpracováním polí datum/čas viz [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#setCurrentDateTime). Níže uvedený příklad používá explicitní datum schválení při převodu pole na obyčejný text.

Stáhněte [sample.pptx](sample.pptx) a umístěte jej do pracovního adresáře. Obsahuje dva pojmenované textové tvary, `UpdatedAt` a `ApprovedDate`, každý s polem datum/čas, plus obyčejné textové popisky. Následující příklad prochází textové tvary nejvyšší úrovně na běžných snímcích. Převádí pole datum/čas na formát dlouhého data a nastaví kurzívu, přičemž zachovává ostatní formátování. Pouze pole v `ApprovedDate` se stane pevným textem.

Ukázka rozpoznává vestavěné interní identifikátory `datetime` a `datetime1` až `datetime13`. Skupiny, tabulky, poznámky, rozvržení a hlavní šablony vyžadují procházení jejich vlastních textových kontejnerů a spadají mimo rozsah tohoto příkladu.

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # Použijte anglické názvy měsíců nezávisle na nastavení systému.
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Po opětovném otevření má `UpdatedAt` typ `datetime3` a zůstává dynamický. `ApprovedDate` nemá pole a obsahuje `05 April 2030`. Obě částky data jsou kurzívou a jejich původní velikost písma, nastavení tučného a barva zůstávají nezměněny. Obyčejné textové popisky jsou beze změny. Ověření načte první část dvou známých tvarů ve dodaném vzorku.

## **Zachování formátování textu**

Pracujte s existující částí při přidávání pole, změně jeho typu nebo odstraňování. Tyto operace zachovávají formátování této části. Použijte [Portion.getPortionFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/#getPortionFormat) pro změnu pouze požadovaných vlastností, jak ukazují příklady pro barvu nebo kurzívu.

Vyhněte se přestavování celého textového rámce jen kvůli aktualizaci jednoho pole: může to ztratit původní hranice částí a jejich individuální formátování. Také rozlište explicitně nastavené formátování od formátování zděděného od odstavce, rozvržení nebo motivu. Viz [Text Formatting](/slides/cs/python-java/text-formatting/) pro širší možnosti formátování.

## **Pole a zástupci záhlaví/zápatí**

Pole je součástí textové části. Zástupce je tvar s rolí v prezentaci, například zápatí nebo číslo snímku. Přidání pole do obyčejného textového políčka nepromění tento tvar na zástupce.

Správci záhlaví/zápatí řídí text zástupců a jejich viditelnost na snímcích, rozvrženích a hlavních šablonách, včetně šíření na závislé snímky. Číselné pole v uživatelském textovém políčku může být užitečné i když nepoužíváte zástupce čísla snímku. Naopak změna viditelnosti zástupce neodstraňuje pole z nesouvisejícího textového políčka.

Předdefinované typy záhlaví a zápatí nevytvářejí odpovídající zástupce ani nepřidávají jejich obsah. Konkrétně běžný snímek PowerPointu nemá zástupce záhlaví; záhlaví patří k poznámkovým stránkám a podkladům. Nepředpokládejte, že pole záhlaví nebo zápatí v libovolném tvaru automaticky získá text nastavený prostřednictvím správce zástupců. Pro tento postup viz [Presentation Headers and Footers](/slides/cs/python-java/presentation-header-and-footer/).

## **Omezení PPTX a PPT**

Ověřte jak typ pole, tak výsledný text po uložení a opětovném otevření. Zachování identifikátoru neprokazuje, že aplikace dokáže spočítat nebo zobrazit jeho hodnotu.

| Formát | Chování pole a omezení |
|---|---|
| PPTX | Ukládá interní identifikátory pole vedle textu pole. V testech při průchodu se předdefinované typy a výše použité vlastní identifikátory přežily uložení a opětovné otevření. Neznámý vlastní typ zachoval svůj náhradní text; nezískal automatickou logiku výpočtu. Jiná aplikace může s nepodporovanými identifikátory zacházet odlišně. |
| PPT | Používá staré reprezentace polí a má omezenější kompatibilitu. V testech při průchodu přežily pole čísla snímku a předdefinovaná pole datum/čas. Vlastní pole v obyčejném textovém políčku snímku se po otevření zobrazilo s jeho identifikátorem, ale s textem `*`; pole záhlaví ve stejném kontextu také vrátilo `*`. Nespoléhejte se na to, že vlastní pole nebo nepodporované kontexty polí si zachovají viditelný text. |

Pro přenosný, pevný výstup převádějte nepodporovaná pole na obyčejný text a před uložením explicitně přiřaďte požadovanou hodnotu. Tím zachováte zvolený text, ale úmyslně zastavíte automatické aktualizace. Otestujte také cílovou aplikaci, pokud je její vlastní přepočet polí součástí vašeho pracovního postupu.

## **Často kladené otázky**

**Jak zjistit, zda je zobrazené číslo nebo datum pole?**

Zkontrolujte [Portion.getField](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/#getField). Hodnota jiná než `None` identifikuje pole; samotný zobrazený text to neprokáže.

**Odstraní odstranění pole jeho text nebo formátování?**

Ne. [removeField](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/#removeField) převádí existující část na obyčejný text. Pokud potřebujete konkrétní pevné datum nebo náhradní hodnotu, přiřaďte ji následně.

**Může interní řetězec definovat nový formát data nebo vzorec?**

Ne. Identifikuje typ pole. Neznámý identifikátor neposkytuje evaluátor ani vzorový řetězec formátu data v Pythonu. Použijte podporovaný předdefinovaný typ nebo naformátujte hodnotu sami jako obyčejný text.

**Proč po uložení prezentaci znovu kontrolovat?**

Identifikátory polí, vypočítaný text a formátování jsou samostatné věci, které je třeba ověřit. Převod formátu může změnit viditelný výsledek, i když identifikátor pole zůstává.