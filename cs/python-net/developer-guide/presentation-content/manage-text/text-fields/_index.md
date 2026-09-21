---
title: Spravovat textová pole v prezentacích PowerPoint v Pythonu
linktitle: Textová pole
type: docs
weight: 52
url: /cs/python-net/text-fields/
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
- Aspose.Slides
description: "Vytvořte, prohlédněte, upravte a odstraňte textová pole v prezentacích PowerPoint pomocí Aspose.Slides pro Python na .NET. Zachovejte formátování a ověřte uložené soubory PPTX a PPT."
---
## **Přehled**

Textový odstavec se skládá z částí. Běžná [Portion](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/) obsahuje doslovný text; část s polem má také [Field](https://reference.aspose.com/slides/cs/python-net/aspose.slides/field/), jejíž typ identifikuje automaticky aktualizovanou hodnotu, například číslo snímku nebo datum. Dvě části mohou zobrazovat stejné znaky, přičemž jen jedna obsahuje pole.

Použijte [Portion.field](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/field/) k rozlišení: pro běžný text je `None`. [Portion.add_field](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/add_field/) převádí existující část na pole. Uchovávejte popisek a jeho dynamickou hodnotu v samostatných částech, aby převod hodnoty nevedl k nahrazení popisku.

Tato příručka pokrývá pole v textu, jejich formátování a ukládání do PPTX a PPT. Pro textová pole a odstavce viz [Manage Text](/slides/cs/python-net/manage-text/).

## **Vytvoření pole čísla snímku**

Následující úplný příklad vytvoří textové pole obsahující doslovný popisek `Slide ` následovaný automaticky aktualizovaným číslem. Před přidáním pole nastaví velikost, tučnost a barvu čísla, poté znovu otevře uloženou prezentaci a ověří typ pole, text a formátování. Vstupní soubor není vyžadován.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

Nová prezentace začíná číslem snímku 1, takže text je `Slide 1`, a oba ověření vypíšou `True`. Číslo zůstane polem po opětovném otevření; není to doslovné `1`. Indexy v ověření odkazují na tvar a části vytvořené v tomto příkladu.

## **Vyberte typ pole**

[FieldType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fieldtype/) poskytuje následující předdefinované hodnoty. Při volání [add_field](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/add_field/) předávejte příslušnou hodnotu.

| Hodnota | Účel |
|---|---|
| [slide_number](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fieldtype/slide_number/) | Aktuální číslo snímku. |
| [date_time](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fieldtype/date_time/) | Datum/čas ve výchozím formátu aplikačního vykreslování. |
| [date_time1](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fieldtype/date_time9/) | Předdefinované formáty data nebo kombinované formáty data/času. |
| [date_time10](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fieldtype/date_time13/) | Předdefinované formáty času, s možnostmi sekund a 12‑hodinového formátu. |
| [header](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fieldtype/header/) | Pole záhlaví; viz omezení zástupného symbolu a formátu níže. |
| [footer](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fieldtype/footer/) | Pole zápatí. |

Například [date_time3](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fieldtype/date_time3/) představuje den, celé jméno měsíce a rok v angličtině. Jedná se o předdefinované formáty pole, nikoli o libovolné řetězce formátu data v Pythonu. Na zobrazovaný výsledek může mít vliv [language_id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseportionformat/language_id/) části a aplikace zpracovávající prezentaci.

## **Vytvoření pole z interního řetězce**

Přetížení metody s řetězcem pro [add_field](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/add_field/) přijímá interní identifikátor pole. Použijte jej, když chcete zachovat identifikátor poskytnutý jinou aplikací, která nemá předdefinovanou hodnotu. Můžete také vytvořit [FieldType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fieldtype/__init__) z identifikátoru. [FieldType.internal_string](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fieldtype/internal_string/) poskytuje tento identifikátor k prohlédnutí.

Tento příklad ukládá aplikační specifické pole `custom-report-id` s nouzovým textem `Report-042`. Identifikátor nezaregistruje výpočet: Aspose.Slides nevytváří ID zpráv pro neznámý typ. Aplikace, která tento identifikátor rozumí, musí dodat jeho význam a aktualizovat jeho hodnotu.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

Po tomto kole PPTX je typ `custom-report-id` a text je `Report-042`. Předání řetězce jako `%Y-%m-%d` by pojmenovalo typ pole; nekonfigurovalo by vlastní formát data. Pro pevné datum v libovolném formátu použijte běžný text.

## **Prohlédnutí, úprava a odstranění polí datum/čas**

Čtěte a měňte existující pole přes [Field.type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/field/type/). Ověřte, že pole existuje, než získáte jeho typ. Pro zastavení automatických aktualizací zavolejte [Portion.remove_field](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/remove_field/). Tím se zachová část a její aktuální text, zatímco se odstraní asociace s polem. Pokud potřebujete konkrétní pevnou hodnotu, přiřaďte tento text po odstranění pole.

Pro nastavení API související se zpracováním polí datum/čas viz [Presentation.current_date_time](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/current_date_time/). Níže uvedený příklad používá explicitní datum schválení při převodu pole na běžný text. Anglický n-tice názvů měsíců udržuje pevné datum nezávislé na systémovém jazyce.

Stáhněte [sample.pptx](sample.pptx) a umístěte jej do pracovního adresáře. Obsahuje dva pojmenované textové tvary `UpdatedAt` a `ApprovedDate`, každý s polem datum/čas, plus běžné textové popisky. Následující příklad prochází textové tvary nejvyšší úrovně na běžných snímcích. Mění pole datum/čas na formát dlouhého data a nastavuje kurzívu, přičemž zachovává ostatní formátování. Pouze pole v `ApprovedDate` se změní na pevný text.

Ukázka rozpoznává vestavěné interní identifikátory `datetime` a `datetime1` až `datetime13`. Skupiny, tabulky, poznámky, rozvržení a mastery vyžadují procházení vlastních kontejnerů textu a jsou mimo rozsah tohoto příkladu.

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

Po opětovném otevření má `UpdatedAt` typ `datetime3` a zůstává dynamický. `ApprovedDate` nemá pole a obsahuje `05 April 2030`. Obě části data jsou kurzívou a jejich původní velikost písma, tučné nastavení a barva zůstaly nedotčeny. Běžné textové popisky jsou beze změny. Ověření čte první část dvou známých tvarů v dodaném vzorku.

## **Zachování formátování textu**

Pracujte s existující částí při přidávání pole, změně jeho typu nebo odstraňování. Tyto operace zachovávají formátování části. Použijte [Portion.portion_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/portion_format/) k úpravě jen požadovaných vlastností, jak ukazují příklady pro barvu nebo kurzívu.

Vyhněte se přestavování celého textového rámce jen kvůli aktualizaci jednoho pole: může tak dojít ke ztrátě původních hranic částí a jejich individuálního formátování. Také rozlišujte explicitně nastavené formátování od formátování zděděného z odstavce, rozvržení nebo tématu. Viz [Text Formatting](/slides/cs/python-net/text-formatting/) pro širší možnosti formátování.

## **Pole a zástupné symboly záhlaví/zápatí**

Pole je součástí textové části. Zástupný symbol je tvar s rolí v prezentaci, například zápatí nebo číslo snímku. Přidání pole do běžného textového pole nepromění tento tvar na zástupný symbol.

Správci záhlaví/zápatí řídí text a viditelnost zástupných symbolů na snímcích, rozvrženích a masterech, včetně šíření na podřízené snímky. Číselné pole v uživatelském textovém poli může být užitečné i když nepoužíváte zástupný symbol čísla snímku. Naopak změna viditelnosti zástupného symbolu neodstraní pole z nesouvisejícího textového pole.

Předdefinované typy záhlaví a zápatí nevytvářejí odpovídající zástupné symboly ani neposkytují jejich obsah. Konkrétně běžný snímek PowerPointu nemá zástupný symbol záhlaví; záhlaví patří k poznámkovým stránkám a výstřižkům. Nepředpokládejte, že pole záhlaví nebo zápatí v libovolném tvaru automaticky získá text nastavený prostřednictvím správce zástupných symbolů. Pro tento postup viz [Presentation Headers and Footers](/slides/cs/python-net/presentation-header-and-footer/).

## **Omezení PPTX a PPT**

Ověřte jak typ pole, tak jeho výsledný text po uložení a opětovném otevření. Zachování identifikátoru neprokazuje, že aplikace může vypočítat nebo zobrazit jeho hodnotu.

| Formát | Chování pole a omezení |
|---|---|
| PPTX | Ukládá interní identifikátory pole spolu s textem pole. V kontrolách po kole se předdefinované typy a vlastní identifikátor použité výše zachovaly při uložení a opětovném otevření. Neznámý vlastní typ si ponechal nouzový text; nezískal automatickou logiku výpočtu. Jiná aplikace může s nepodporovanými identifikátory zacházet odlišně. |
| PPT | Používá starší reprezentace polí a má omezenější kompatibilitu. V kontrolách po kole přežily pole čísla snímku a předdefinovaná pole datum/čas při uložení a opětovném otevření. Vlastní pole v běžném textovém poli snímku se po otevření zobrazilo s identifikátorem, ale s textem `*`; pole záhlaví ve stejném kontextu také vrátilo `*`. Nespoléhejte se, že vlastní pole nebo nepodporované kontexty polí si zachovají viditelný text. |

Pro přenosný, pevný výstup převádějte nepodporovaná pole na běžný text a před uložením výslovně přiřaďte požadovanou hodnotu. Tím se zachová zvolený text, ale úmyslně se zastaví automatické aktualizace. Otestujte také cílovou aplikaci, pokud je její vlastní přepočet polí součástí vašeho postupu.

## **Často kladené otázky**

**Jak mohu zjistit, zda je zobrazené číslo nebo datum pole?**

Prohlédněte si [Portion.field](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/field/). Hodnota odlišná od `None` identifikuje pole; samotný zobrazený text to nedokáže určit.

**Odstraní odstranění pole jeho text nebo formátování?**

Ne. [remove_field](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/remove_field/) převádí existující část na běžný text. Pokud potřebujete konkrétní zamrzlý datum nebo náhradní text, přiřaďte ho po odstranění pole.

**Může interní řetězec definovat nový formát data nebo vzorec?**

Ne. Identifikuje typ pole. Neznámý identifikátor neposkytuje vyhodnocovač ani vzorový řetězec formátu data v Pythonu. Použijte podporovaný předdefinovaný typ nebo formátujte hodnotu sami jako běžný text.

**Proč kontrolovat prezentaci znovu po jejím uložení?**

Identifikátory polí, vypočtený text a formátování jsou samostatné věci, které je třeba ověřit. Převod formátu může změnit viditelný výsledek, i když identifikátor pole stále existuje.