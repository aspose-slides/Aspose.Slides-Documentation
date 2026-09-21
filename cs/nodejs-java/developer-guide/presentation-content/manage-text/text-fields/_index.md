---
title: Správa textových polí v prezentacích PowerPoint v JavaScriptu
linktitle: Textová pole
type: docs
weight: 52
url: /cs/nodejs-java/text-fields/
keywords:
- textové pole
- automatický text
- číslo snímku
- datum a čas
- hlavička
- patička
- textová část
- PowerPoint
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvářejte, kontrolujte, upravujte a odstraňujte textová pole v prezentacích PowerPoint pomocí Aspose.Slides pro Node.js prostřednictvím Javy. Zachovejte formátování a ověřte uložené soubory PPTX a PPT."
---
## **Přehled**

Textový odstavec se skládá z částí. Běžná [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/) obsahuje doslovný text; část pole má také [Field](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/field/), jehož typ určuje automaticky aktualizovanou hodnotu, jako je číslo snímku nebo datum. Dvě části mohou zobrazovat stejné znaky, ale jen jedna obsahuje pole.

Použijte [Portion.getField](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/#getField) k jejich rozlišení: pro běžný text je `null`. [Portion.addField](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/#addField) převádí existující část na pole. Uložte popisek a jeho dynamickou hodnotu v samostatných částech, aby převod hodnoty nezasáhl i popisek.

Tento průvodce popisuje pole v textu, jejich formátování a ukládání do formátů PPTX a PPT. Pro textové rámečky a odstavce viz [Manage Text](/slides/cs/nodejs-java/manage-text/).

## **Vytvořte pole čísla snímku**

Následující kompletní příklad vytvoří textové pole s doslovným popiskem `Slide ` a automaticky aktualizovaným číslem. Nastaví velikost, tloušťku a barvu čísla před přidáním pole, poté znovu otevře uloženou prezentaci a zkontroluje typ pole, text a formátování. Žádný vstupní soubor není vyžadován.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    const numberPortion = new aspose.slides.Portion();
    const numberColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    numberPortion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(aspose.slides.FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("slide_number.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        const savedField = savedNumber.getField();
        const hasNumberField = savedField != null && aspose.slides.FieldType.getSlideNumber().getInternalString() === savedField.getType().getInternalString();
        const format = savedNumber.getPortionFormat();
        let formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == aspose.slides.NullableBool.True;
        formattingPreserved = formattingPreserved && format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        console.log("Text: " + savedShape.getTextFrame().getText());
        console.log("Slide number field: " + hasNumberField);
        console.log("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Nová prezentace začíná číslem snímku 1, takže text je `Slide 1` a oba testy vrátí `true`. Číslo zůstane polem po znovuotevření; není to doslovné `1`. Indexy ve verifikaci odkazují na tvar a části vytvořené tímto příkladem.

## **Vyberte typ pole**

[FieldType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fieldtype/) poskytuje následující metody pro získání předdefinovaných hodnot. Předávejte vhodnou hodnotu metodě [addField](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/#addField).

| Metoda | Účel |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | Aktuální číslo snímku. |
| [getDateTime](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fieldtype/#getDateTime) | Datum/čas ve výchozím formátu aplikace vykreslování. |
| [getDateTime1](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | Předdefinované formáty data nebo kombinovaného data/času. |
| [getDateTime10](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | Předdefinované formáty času s možností sekund a 12‑hodinového formátu. |
| [getHeader](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fieldtype/#getHeader) | Pole hlavičky; viz omezení zástupce a formátu níže. |
| [getFooter](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fieldtype/#getFooter) | Pole patičky. |

Například [getDateTime3](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fieldtype/#getDateTime3) představuje den, celý název měsíce a rok v angličtině. Jedná se o předdefinované formáty polí, nikoli o libovolné řetězce formátování data. Jazyk nastavený pomocí [setLanguageId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) a aplikace zpracovávající prezentaci mohou ovlivnit zobrazený výsledek.

## **Vytvořte pole z interního řetězce**

Přetížení metody [addField](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/#addField) pro řetězec přijímá interní identifikátor pole. Použijte jej, když chcete zachovat identifikátor poskytnutý jinou aplikací, která nemá žádnou předdefinovanou hodnotu. Můžete také vytvořit [FieldType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fieldtype/) z identifikátoru. [FieldType.getInternalString](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fieldtype/#getInternalString) tento identifikátor odhalí pro kontrolu.

Tento příklad ukládá aplikací specifikované pole `custom-report-id` s náhradním textem `Report-042`. Identifikátor nevytváří výpočet: Aspose.Slides negeneruje ID zpráv pro neznámý typ. Aplikace, která tento identifikátor rozpozná, musí dodat jeho význam a aktualizovat jeho hodnotu.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("custom_field.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const savedField = savedPortion.getField();
        const typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        console.log("Type: " + typeName);
        console.log("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Po tomto kolotoči PPTX je typ `custom-report-id` a text je `Report-042`. Předání řetězce jako `yyyy-MM-dd` by nazvalo typ pole; nenastaví vlastní formát data. Pro pevné datum v libovolném formátu použijte běžný text.

## **Prohlédněte, upravte a odstraňte pole datum/čas**

Změňte existující pole pomocí [Field.setType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/field/#setType). Ověřte, že pole existuje, než získáte jeho typ. Pro zastavení automatických aktualizací zavolejte [Portion.removeField](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/#removeField). Tím se zachová část a její aktuální text, zatímco se odstraní vazba na pole. Pokud potřebujete konkrétní pevnou hodnotu, přiřaďte tento text po odstranění pole.

Pro nastavení API souvisejícího se zpracováním pole datum/čas viz [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#setCurrentDateTime). Níže uvedený příklad používá explicitní datum schválení při převodu pole na běžný text.

Stáhněte [sample.pptx](sample.pptx) a umístěte jej do pracovního adresáře. Obsahuje dva pojmenované textové tvary, `UpdatedAt` a `ApprovedDate`, chacun s polem datum/čas a běžné textové popisky. Následující příklad prochází textové tvary nejvyšší úrovně na běžných snímcích. Mění pole datum/čas na dlouhý formát data a nastavuje kurzívu, přičemž zachovává ostatní formátování. Pouze pole v `ApprovedDate` se stane pevně daným textem.

Datum schválení je 5. dubna 2030; indexy měsíců v JavaScriptu začínají nulou, takže duben je `3`. Pro konstrukci i formátování se používá UTC, aby datum nebylo závislé na místní časové zóně.

Ukázka rozpoznává vestavěné interní identifikátory `datetime` a `datetime1` až po `datetime13`. Skupiny, tabulky, poznámky, rozvržení a master‑snímky vyžadují procházení jejich vlastních textových kontejnerů a nejsou v tomto příkladu zahrnuty.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const approvalDate = new Date(Date.UTC(2030, 3, 5));
    const dateFormat = new Intl.DateTimeFormat("en-GB", { day: "2-digit", month: "long", year: "numeric", timeZone: "UTC" });

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < shape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    const typeName = field.getType().getInternalString();
                    const isDateTime = typeName != null && /^datetime([1-9]|1[0-3])?$/.test(typeName);
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(aspose.slides.FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

                    if (shape.getName() === "ApprovedDate") {
                        portion.removeField();
                        const fixedDate = dateFormat.format(approvalDate);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("updated_dates.pptx");
    try {
        for (let shapeIndex = 0; shapeIndex < reopened.getSlides().get_Item(0).getShapes().size(); shapeIndex++) {
            const shape = reopened.getSlides().get_Item(0).getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }
            if (shape.getName() !== "UpdatedAt" && shape.getName() !== "ApprovedDate") {
                continue;
            }

            const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            const field = portion.getField();
            const typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            console.log(shape.getName() + ": " + typeName + "; " + portion.getText());
            console.log("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Po opětovném otevření má `UpdatedAt` typ `datetime3` a zůstává dynamické. `ApprovedDate` nemá pole a obsahuje `05 April 2030`. Obě datumové části jsou kurzívou a zachovávají původní velikost písma, nastavení tučnosti a barvu. Běžné textové popisky zůstávají beze změny. Ověření čte první část ze dvou známých tvarů ve vzorovém souboru.

## **Zachování formátování textu**

Pracujte s existující částí při přidávání pole, změně jeho typu nebo odstraňování. Tyto operace zachovávají formátování části. Použijte [Portion.getPortionFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/#getPortionFormat) k úpravě jen potřebných vlastností, jak ukazují příklady pro barvu nebo kurzívu.

Vyhněte se přestavbě celého textového rámce jen kvůli aktualizaci jednoho pole: může dojít ke ztrátě původních hranic částí a jejich individuálního formátování. Rozlišujte také výslovně nastavené formátování od formátování zděděného od odstavce, rozvržení nebo motivu. Viz [Text Formatting](/slides/cs/nodejs-java/text-formatting/) pro širší možnosti formátování.

## **Pole a zástupci hlavičky/patičky**

Pole je součástí textové části. Zástupce je tvar s rolí v prezentaci, například patička nebo číslo snímku. Přidání pole do běžného textového pole nepromění tvar na zástupce.

Správci hlavičky/patičky řídí text zástupců a jejich viditelnost na snímcích, rozvrženích a master‑šablonách, včetně propagace na závislé snímky. Číselné pole v uživatelském textovém poli tak může být užitečné i když nepoužíváte zástupce čísla snímku. Naopak změna viditelnosti zástupce neodstraní pole z nesouvisejícího textového pole.

Předdefinované typy hlavičky a patičky nevytvářejí odpovídající zástupce ani neposkytují jejich obsah. Konkrétně běžný snímek PowerPointu nemá zástupce hlavičky; hlavičky patří k poznámkovým stránkám a výstřižkům. Nepředpokládejte, že hlavičkové či patičkové pole v libovolném tvaru automaticky získá text nakonfigurovaný přes správce zástupců. Pro tento postup viz [Presentation Headers and Footers](/slides/cs/nodejs-java/presentation-header-and-footer/).

## **Omezení PPTX a PPT**

Po uložení a opětovném otevření zkontrolujte jak typ pole, tak výsledný text. Zachování identifikátoru neprokazuje, že aplikace může vypočítat nebo zobrazit jeho hodnotu.

| Formát | Chování pole a omezení |
|---|---|
| PPTX | Ukládá interní identifikátory polí vedle textu pole. V kontrolách po kolech přežití přežily předdefinované typy i vlastní identifikátor použitý výše. Neznámý vlastní typ zachoval svůj náhradní text; nezískal logiku automatického výpočtu. Jiná aplikace může s nepodporovanými identifikátory zacházet odlišně. |
| PPT | Používá starší reprezentaci polí a má omezenější kompatibilitu. V kontrolách po kolech přežití přežily pole čísla snímku a předdefinovaná pole datum/čas. Vlastní pole v běžném textovém poli snímku se po otevření zobrazilo s identifikátorem, ale text byl `*`; stejně tak pole hlavičky v tomtéž kontextu také vrátilo `*`. Nespoléhejte se na to, že vlastní pole nebo nepodporované kontexty polí zachovají jejich viditelný text. |

Pro přenosný, pevný výstup převádějte nepodporovaná pole na běžný text a před uložením přiřaďte požadovanou hodnotu. Tím zachováte vybraný text a úmyslně zastavíte automatické aktualizace. Otestujte také cílovou aplikaci, pokud je součástí vašeho pracovního postupu vlastní přepočet polí.

## **Často kladené otázky**

**Jak zjistím, zda je zobrazené číslo nebo datum pole?**

Prohlédněte si [Portion.getField](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/#getField). Hodnota různá od `null` identifikuje pole; samotný zobrazený text to neodhalí.

**Odstraňuje odstranění pole i jeho text nebo formátování?**

Ne. [removeField](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/#removeField) převede existující část na běžný text. Pokud potřebujete konkrétní zamrzlý datum nebo náhradní hodnotu, přiřaďte ji po odstranění pole.

**Může interní řetězec definovat nový formát data nebo vzorec?**

Ne. Identifikuje typ pole. Neznámý identifikátor neposkytuje hodnotící engine ani vzor pro formát data. Použijte podporovaný předdefinovaný typ nebo naformátujte hodnotu sami jako běžný text.

**Proč po uložení prezentaci znovu kontrolovat?**

Identifikátory polí, vypočtený text a formátování jsou oddělené věci, které je třeba ověřit. Převod formátu může změnit viditelný výsledek, i když identifikátor pole zůstane.