---
title: Správa textových polí v prezentacích PowerPoint v PHP
linktitle: Textová pole
type: docs
weight: 52
url: /cs/php-java/text-fields/
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
- PHP
- Aspose.Slides
description: "Vytvářejte, prohlížejte, upravujte a odstraňujte textová pole v prezentacích PowerPoint pomocí Aspose.Slides pro PHP přes Java. Zachovejte formátování a ověřte uložené soubory PPTX a PPT."
---
## **Přehled**

Odstavec textu se skládá z částí. Běžná [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/) obsahuje doslovný text; část pole také obsahuje [Field](https://reference.aspose.com/slides/cs/php-java/aspose.slides/field/), jehož typ identifikuje automaticky aktualizovanou hodnotu, například číslo snímku nebo datum. Dvě části mohou zobrazovat stejné znaky, přičemž pouze jedna obsahuje pole.

Použijte [Portion::getField](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/#getField) k jejich rozlišení: pro běžný text je `null`. [Portion::addField](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/#addField) převádí existující část na pole. Udržujte popisek a jeho dynamickou hodnotu v oddělených částech, aby převod hodnoty nepřepsal i popisek.

Tento průvodce popisuje pole v textu, jejich formátování a ukládání do formátů PPTX a PPT. Pro textové rámečky a odstavce viz [Manage Text](/slides/cs/php-java/manage-text/).

## **Vytvoření pole čísla snímku**

Následující kompletní příklad vytvoří textové pole obsahující doslovný popisek `Slide ` následovaný automaticky aktualizovaným číslem. Před přidáním pole nastaví velikost, tloušťku a barvu čísla, poté znovu otevře uloženou prezentaci a ověří typ pole, text a formátování. Vstupní soubor není vyžadován.

```php
use aspose\slides\FieldType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
    $shape->addTextFrame("Slide ");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);

    $numberPortion = new Portion();
    $numberColor = new Java("java.awt.Color", 0, 0, 139);
    $numberPortion->getPortionFormat()->setFontHeight(24);
    $numberPortion->getPortionFormat()->setFontBold(NullableBool::True);
    $numberPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $numberPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($numberColor);
    $paragraph->getPortions()->add($numberPortion);
    $numberPortion->addField(FieldType::getSlideNumber());

    $presentation->save("slide_number.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("slide_number.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedNumber = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1);
        $savedField = $savedNumber->getField();
        $hasNumberField = !java_is_null($savedField) && java_values(FieldType::getSlideNumber()->getInternalString()) === java_values($savedField->getType()->getInternalString());
        $format = $savedNumber->getPortionFormat();
        $formattingPreserved = java_values($format->getFontHeight()) == 24 && java_values($format->getFontBold()) == NullableBool::True;
        $formattingPreserved = $formattingPreserved && java_values($format->getFillFormat()->getSolidFillColor()->getColor()->getRGB()) == java_values($numberColor->getRGB());

        echo "Text: " . $savedShape->getTextFrame()->getText() . PHP_EOL;
        echo "Slide number field: " . ($hasNumberField ? "true" : "false") . PHP_EOL;
        echo "Formatting preserved: " . ($formattingPreserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Nová prezentace začíná číslem snímku 1, takže text je `Slide 1`, a obě kontroly vytisknou `true`. Číslo zůstává polem po opětovném otevření; není to doslovné `1`. Indexy v ověření odkazují na tvar a části vytvořené tímto příkladem.

## **Zvolte typ pole**

[FieldType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fieldtype/) poskytuje následující metody pro získání předdefinovaných hodnot. Předávejte vhodnou hodnotu metodě [addField](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/#addField).

| Metoda | Účel |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fieldtype/#getSlideNumber) | Aktuální číslo snímku. |
| [getDateTime](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fieldtype/#getDateTime) | Datum/čas ve výchozím formátu aplikace vykreslující prezentaci. |
| [getDateTime1](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fieldtype/#getDateTime9) | Předdefinované formáty data nebo kombinované formáty data/času. |
| [getDateTime10](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fieldtype/#getDateTime13) | Předdefinované formáty času s možností sekund a 12‑hodinového formátu. |
| [getHeader](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fieldtype/#getHeader) | Pole záhlaví; viz omezení zástupného symbolu a formátu níže. |
| [getFooter](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fieldtype/#getFooter) | Pole zápatí. |

Například [getDateTime3](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fieldtype/#getDateTime3) představuje den, úplný název měsíce a rok v angličtině. Jedná se o předdefinované formáty polí, nikoli o libovolné řetězce formátu data v PHP. Jazyk nastavený pomocí [setLanguageId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setLanguageId) a aplikace zpracovávající prezentaci mohou ovlivnit zobrazený výsledek.

## **Vytvoření pole z interního řetězce**

Přetížení metody [addField](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/#addField) pro řetězec přijímá interní identifikátor pole. Použijte jej při zachování identifikátoru poskytnutého jinou aplikací, která nemá předdefinovanou hodnotu. Můžete také vytvořit [FieldType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fieldtype/#FieldType) z tohoto identifikátoru. [FieldType::getInternalString](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fieldtype/#getInternalString) umožňuje tento identifikátor prohlédnout.

Tento příklad ukládá aplikací specifické pole `custom-report-id` s náhradním textem `Report-042`. Identifikátor nezaregistruje žádný výpočet: Aspose.Slides negeneruje ID zpráv pro neznámý typ. Aplikace, která tento identifikátor rozumí, musí poskytnout jeho význam a aktualizovat jeho hodnotu.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
    $shape->addTextFrame("Report-042");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->addField("custom-report-id");

    $presentation->save("custom_field.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom_field.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedPortion = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $savedField = $savedPortion->getField();
        $typeName = java_is_null($savedField) ? "ordinary text" : java_values($savedField->getType()->getInternalString());
        echo "Type: " . $typeName . PHP_EOL;
        echo "Text: " . $savedPortion->getText() . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Po tomto okruhu PPTX je typ `custom-report-id` a text je `Report-042`. Předání řetězce jako `Y-m-d` by pojmenovalo typ pole; nenastavilo by vlastní formát data. Pro pevné datum v libovolném formátu použijte běžný text.

## **Kontrola, úprava a odstranění polí datum/čas**

Změňte existující pole pomocí [Field::setType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/field/#setType). Před přístupem k jeho typu ověřte, že pole existuje. Pro zastavení automatických aktualizací zavolejte [Portion::removeField](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/#removeField). Tím se zachová část a její aktuální text při odstranění asociace pole. Pokud potřebujete konkrétní pevnou hodnotu, přiřaďte tento text po odstranění pole.

Pro nastavení API související se zpracováním polí datum/čas viz [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#setCurrentDateTime). Níže uvedený příklad používá explicitní datum schválení při převodu pole na běžný text.

Stáhněte [sample.pptx](sample.pptx) a umístěte jej do pracovního adresáře JavaBridge, nebo předáte jeho absolutní cestu konstruktoru prezentace. Obsahuje dva pojmenované textové tvary `UpdatedAt` a `ApprovedDate`, každý s polem datum/čas, a také běžné popisky. Následující příklad prochází textové tvary nejvyšší úrovně na běžných snímcích. Změní pole datum/čas na formát dlouhého data a nastaví je kurzívou, přičemž zachová jejich další formátování. Pouze pole v `ApprovedDate` se stane pevně daným textem.

Ukázka rozpoznává vestavěné interní identifikátory `datetime` a `datetime1` až po `datetime13`. Skupiny, tabulky, poznámky, rozvržení a hlavní snímky vyžadují procházení jejich vlastních textových kontejnerů a jsou mimo rozsah tohoto příkladu.

```php
use aspose\slides\FieldType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $approvalDate = new DateTimeImmutable("2030-04-05");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {

        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textShape->getTextFrame()->getParagraphs()->getCount()); $paragraphIndex++) {

                $paragraph = $textShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $field = $portion->getField();
                    if (java_is_null($field)) {
                        continue;
                    }

                    $typeName = java_values($field->getType()->getInternalString());
                    $isDateTime = $typeName != null && preg_match("/\Adatetime([1-9]|1[0-3])?\z/", $typeName) === 1;
                    if (!$isDateTime) {
                        continue;
                    }

                    $field->setType(FieldType::getDateTime3());
                    $portion->getPortionFormat()->setLanguageId("en-US");
                    $portion->getPortionFormat()->setFontItalic(NullableBool::True);

                    if (java_values($textShape->getName()) === "ApprovedDate") {
                        $portion->removeField();
                        $fixedDate = $approvalDate->format("d F Y");
                        $portion->setText($fixedDate);
                    }
                }
            }
        }
    }

    $presentation->save("updated_dates.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("updated_dates.pptx");
    try {
        for ($shapeIndex = 0; $shapeIndex < java_values($reopened->getSlides()->get_Item(0)->getShapes()->size()); $shapeIndex++) {
            $shape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }
            if (java_values($textShape->getName()) !== "UpdatedAt" && java_values($textShape->getName()) !== "ApprovedDate") {
                continue;
            }

            $portion = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $field = $portion->getField();
            $typeName = java_is_null($field) ? "ordinary text" : java_values($field->getType()->getInternalString());
            echo $textShape->getName() . ": " . $typeName . "; " . $portion->getText() . PHP_EOL;
            echo "Italic: " . $portion->getPortionFormat()->getFontItalic() . PHP_EOL;
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Po opětovném otevření má `UpdatedAt` typ `datetime3` a zůstává dynamický. `ApprovedDate` nemá pole a obsahuje `05 April 2030`. Obě datumové části jsou kurzívou a jejich původní velikost písma, nastavení tučnosti a barva zůstávají zachovány. Běžné textové popisky jsou nezměněny. Ověření čte první část dvou známých tvarů v dodané ukázce.

## **Zachování formátování textu**

Pracujte s existující částí při přidávání pole, změně jeho typu nebo odstranění. Tyto operace zachovávají formátování této části. Použijte [Portion::getPortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/#getPortionFormat), abyste změnili jen požadované vlastnosti, jak ukazují příklady pro barvu nebo kurzívu.

Vyhněte se přestavování celého textového rámečku jen kvůli aktualizaci jednoho pole: takové zacházení může ztratit původní hranice částí a jejich individuální formátování. Také rozlišujte explicitně nastavené formátování od formátování zděděného z odstavce, rozvržení nebo motivu. Viz [Text Formatting](/slides/cs/php-java/text-formatting/) pro širší možnosti formátování.

## **Pole a zástupci záhlaví/zápatí**

Pole je součástí textové části. Zástupce je tvar s rolí v prezentaci, například zápatí nebo číslo snímku. Přidání pole do běžného textového pole nepřemění tento tvar na zástupce.

Správci záhlaví/zápatí řídí text zástupců a jejich viditelnost na snímcích, rozvrženích a hlavních šablonách, včetně šíření na závislé snímky. Pole s číslem v uživatelském textovém poli může být tedy užitečné i když nepoužíváte zástupce čísla snímku. Naopak změna viditelnosti zástupce neodstraní pole z nesouvisejícího textového pole.

Předdefinované typy záhlaví a zápatí nevytvářejí odpovídající zástupce ani neposkytují jejich obsah. Konkrétně běžný snímek PowerPointu nemá zástupce záhlaví; záhlaví patří k poznámkovým stránkám a letákům. Nepředpokládejte, že pole záhlaví nebo zápatí v libovolném tvaru automaticky získá text nastavený prostřednictvím správce zástupců. Pro tento postup viz [Presentation Headers and Footers](/slides/cs/php-java/presentation-header-and-footer/).

## **Omezení PPTX a PPT**

Po uložení a opětovném otevření zkontrolujte jak typ pole, tak jeho výsledný text. Zachování identifikátoru neprokazuje, že aplikace dokáže vypočítat nebo zobrazit jeho hodnotu.

| Formát | Chování pole a omezení |
|---|---|
| PPTX | Ukládá interní identifikátory polí vedle textu pole. V kontrolách během okruhu přežití předdefinované typy a výše použité vlastní identifikátory uložení a opětovné otevření. Neznámý vlastní typ zachoval svůj náhradní text; nezískal automatickou logiku výpočtu. Jiná aplikace může s nepodporovanými identifikátory zacházet odlišně. |
| PPT | Používá starší reprezentace polí a má omezenější kompatibilitu. V kontrolách během okruhu přežily číslo snímku a předdefinovaná pole datum/čas po uložení a opětovném otevření. Vlastní pole v běžném textovém poli snímku se po otevření zobrazilo s jeho identifikátorem, ale s textem `*`; pole záhlaví ve stejném kontextu také vygenerovalo `*`. Nespoléhejte se, že vlastní pole nebo nepodporované kontexty polí zachovají jejich viditelný text. |

Pro přenosný, pevný výstup převádějte nepodporovaná pole na běžný text a před uložením explicitně přiřaďte požadovanou hodnotu. Tím se zachová vybraný text, ale úmyslně se zastaví automatické aktualizace. Otestujte také cílovou aplikaci, pokud je její vlastní přepočítání polí součástí vašeho pracovního postupu.

## **Často kladené otázky**

**Jak zjistit, zda je zobrazené číslo nebo datum pole?**

Prohlédněte [Portion::getField](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/#getField). Ne‑nulová hodnota identifikuje pole; samotný zobrazený text to neukáže.

**Odstraní odstranění pole jeho text nebo formátování?**

Ne. [removeField](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/#removeField) převádí existující část na běžný text. Pokud potřebujete konkrétní pevné datum nebo náhradní hodnotu, přiřaďte ji po odstranění.

**Může interní řetězec definovat nový formát data nebo vzorec?**

Ne. Identifikuje typ pole. Neznámý identifikátor neposkytuje vyhodnocovač ani vzor PHP formátu data. Použijte podporovaný předdefinovaný typ nebo formátujte hodnotu sami jako běžný text.

**Proč po uložení prezentaci znovu zkontrolovat?**

Identifikátory polí, vypočtený text a formátování jsou samostatné věci, které je třeba ověřit. Konverze formátu může změnit viditelný výsledek, i když identifikátor pole stále existuje.