---
title: Szövegmezők kezelése PowerPoint prezentációkban PHP-vel
linktitle: Szövegmezők
type: docs
weight: 52
url: /hu/php-java/text-fields/
keywords:
- szövegmező
- automatikus szöveg
- diaszám
- dátum és idő
- fejléc
- lábléc
- szövegrész
- PowerPoint
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Szövegmezők létrehozása, vizsgálata, módosítása és eltávolítása PowerPoint prezentációkban az Aspose.Slides for PHP via Java használatával. Formázás megőrzése és a mentett PPTX és PPT fájlok ellenőrzése."
---
## **Áttekintés**

Egy szöveges bekezdés részekből áll. Egy szokásos [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/) literális szöveget tartalmaz; egy mező résznek továbbá van egy [Field](https://reference.aspose.com/slides/hu/php-java/aspose.slides/field/), amelynek típusa egy automatikusan frissülő értéket azonosít, például diaszámot vagy dátumot. Két rész is megjeleníthet ugyanazokat a karaktereket, de csak az egyik tartalmaz mezőt.

Használd a [Portion::getField](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/#getField) metódust a megkülönböztetéshez: szokásos szöveg esetén `null`. A [Portion::addField](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/#addField) egy meglévő részt mezővé konvertál. Tarts egy címkét és annak dinamikus értékét külön részekben, hogy az érték konvertálása ne cserélje le a címkét is.

Ez az útmutató a szövegen belüli mezőket, azok formázását és PPTX‑ben illetve PPT‑ben történő mentését tárgyalja. A szövegkeretekkel és bekezdésekkel kapcsolatban lásd a [Szöveg kezelése](/slides/hu/php-java/manage-text/) oldalt.

## **Dia szám mező létrehozása**

Az alábbi teljes példa egy szövegdobozt hoz létre, amely egy literális `Slide ` címkét tartalmaz, majd egy automatikusan frissülő számot. A mező hozzáadása előtt beállítja a szám méretét, vastagságát és színét, majd újra megnyitja a mentett prezentációt és ellenőrzi a mező típusát, szövegét és formázását. Bemeneti fájl nem szükséges.

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

Az új prezentáció az 1-es diaszámmal kezdődik, így a szöveg `Slide 1`, és mindkét ellenőrzés `true`‑t ad ki. A szám a megnyitás után is mező marad; nem egy literális `1`. A ellenőrzésben szereplő indexek a példában létrehozott alakzatot és részeket jelölik.

## **Mező típusának kiválasztása**

[FieldType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fieldtype/) a következő metódusokat biztosít előre definiált értékek lekéréséhez. A megfelelő értéket add át az [addField](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/#addField) metódusnak.

| Módszer | Leírás |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fieldtype/#getSlideNumber) | A jelenlegi diaszám. |
| [getDateTime](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fieldtype/#getDateTime) | A dátum/idő az alkalmazás alapértelmezett formátumában. |
| [getDateTime1](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fieldtype/#getDateTime9) | Előre definiált dátum vagy kombinált dátum/idő formátumok. |
| [getDateTime10](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fieldtype/#getDateTime13) | Előre definiált időformátumok, másodpercel és 12 órás órajel opcióval. |
| [getHeader](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fieldtype/#getHeader) | Fejlécmező; lásd az alább szereplő helyőrző és formátumkorlátozások. |
| [getFooter](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fieldtype/#getFooter) | Láblécmező. |

Például a [getDateTime3](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fieldtype/#getDateTime3) egy napot, a teljes hónap nevét és évet angolul jelenít meg. Ezek előre definiált mezőformátumok, nem tetszőleges PHP dátumformátum‑karakterláncok. A [setLanguageId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setLanguageId)‑vel beállított nyelv és a prezentációt feldolgozó alkalmazás befolyásolhatja a megjelenített eredményt.

## **Mező létrehozása belső karakterláncból**

Az [addField](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/#addField) karakterlánc‑túlterhelése belső mezőazonosítót fogad. Akkor használd, amikor egy másik alkalmazás által megadott, előre definiált értékkel nem rendelkező azonosítót szeretnéd megőrizni. Létrehozhatsz egy [FieldType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fieldtype/#FieldType)-t is az azonosítóból. A [FieldType::getInternalString](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fieldtype/#getInternalString) ezt az azonosítót teszi láthatóvá ellenőrzés céljából.

Ez a példa egy alkalmazás‑specifikus `custom-report-id` mezőt tárol a tartalék szöveggel `Report-042`. Az azonosító nem regisztrál számítást: az Aspose.Slides nem generál jelentés‑azonosítókat ismeretlen típus esetén. Az azonosítót értő alkalmazásnak kell biztosítania a jelentését és frissítenie az értékét.

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

A PPTX körbejárás után a típus `custom-report-id` és a szöveg `Report-042`. Egy `Y-m-d` karakterlánc átadása mezőtípust nevezne; nem hozna létre egy egyedi dátumformátumot. Rögzített dátum tetszőleges formátumban a szokásos szöveget kell használni.

## **Dátum/idő mezők ellenőrzése, módosítása és eltávolítása**

Módosíts egy meglévő mezőt a [Field::setType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/field/#setType) segítségével. Ellenőrizd, hogy a mező létezik-e, mielőtt a típusához férnél hozzá. Az automatikus frissítések leállításához hívd a [Portion::removeField](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/#removeField) metódust. Ez megőrzi a részt és a jelenlegi szövegét, miközben eltávolítja a mezőkapcsolatot. Ha egy konkrét rögzített értékre van szükség, a mező eltávolítása után rendeld hozzá azt a szöveget.

A dátum/idő mező feldolgozásával kapcsolatos API-beállításért lásd a [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#setCurrentDateTime) metódust. Az alábbi példa egy kifejezett jóváhagyási dátumot használ a mező szokásos szöveggé alakításakor.

Töltsd le a [sample.pptx](sample.pptx) fájlt, és helyezd el a JavaBridge munkakönyvtárában, vagy add meg abszolút elérési útját a prezentáció konstruktornak. A fájl két elnevezett szöveges alakzatot tartalmaz, `UpdatedAt` és `ApprovedDate`, mindegyik egy dátum/idő mezővel, valamint szokásos szövegcímkékkel. Az alábbi példa végigjárja a felső szintű szöveges alakzatokat a normál diákon. A dátum/idő mezőket hosszú dátumformátumra módosítja és dőlté teszi őket, miközben a többi formázásuk változatlan marad. Csak a `ApprovedDate` mezők válnak rögzített szöveggé.

A minta felismert a beépített belső azonosítókat `datetime` és `datetime1`‑től `datetime13`‑ig. Csoportok, táblák, jegyzetek, elrendezések és fő sablonok saját szövegtárolóik bejárását igénylik, és kívül esnek ennek a példának a hatókörén.

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

A megnyitás után az `UpdatedAt` típusa `datetime3` és dinamikus marad. Az `ApprovedDate` nem tartalmaz mezőt és a `05 April 2030` szöveget tartalmazza. Mindkét dátumrész dőlt, és az eredeti betűméret, félkövér beállítás és szín változatlan marad. A szokásos szövegcímkék nem változnak. Az ellenőrzés a megadott mintában a két ismert alakzat első részét olvassa.

## **Szövegformázás megőrzése**

A meglévő résszel dolgozz a mező hozzáadásakor, típusának módosításakor vagy eltávolításakor. Ezek a műveletek megőrzik a rész formázását. Használd a [Portion::getPortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/#getPortionFormat) metódust csak a szükséges tulajdonságok módosításához, ahogy a példák a szín vagy dőlt esetében teszik.

Kerüld el egy egész szövegkeret újjáépítését csak egy mező frissítése miatt: ez elveszítheti az eredeti részek határait és egyedi formázását. Emellett különböztetd meg a kifejezetten beállított formázást a bekezdésből, elrendezésből vagy témából örökölt formázástól. Lásd a [Szövegformázás](/slides/hu/php-java/text-formatting/) oldalt a szélesebb formázási lehetőségekért.

## **Mezők és fejléc/lábléc helyőrzők**

Egy mező a szöveg részének része. Egy helyőrző egy olyan alakzat, amely a prezentációban szerepet kap, például lábléc vagy diaszám. Egy mező hozzáadása egy szokásos szövegdobozhoz nem alakítja azt helyőrzővé.

A fejléc-/lábléc kezelők szabályozzák a helyőrző szöveget és láthatóságot a diákon, elrendezéseken és fő sablonokon, beleértve a függő diákra való terjesztést. Egy számmező egy egyéni szövegdobozban ezért hasznos lehet akkor is, ha nem használod a diaszám helyőrzőt. Ezzel szemben a helyőrző láthatóságának módosítása nem távolítja el a mezőt egy nem kapcsolódó szövegdobozból.

Az előre definiált fejléc és lábléc típusok nem hoznak létre a megfelelő helyőrzőket, és nem biztosítják azok tartalmát. Különösen, egy szabványos PowerPoint dia nem rendelkezik fejléc helyőrzővel; a fejlécek a jegyzetoldalakhoz és a szórólapokhoz tartoznak. Ne tévedj, hogy egy fejléc vagy lábléc mező egy tetszőleges alakzatban automatikusan megkapja a helyőrzőkezelő által beállított szöveget. Ehhez a munkafolyamathoz lásd a [Prezentáció fejlécek és láblécek](/slides/hu/php-java/presentation-header-and-footer/) oldalt.

## **PPTX és PPT korlátai**

Ellenőrizd a mező típusát és a kapott szöveget a mentés és újra megnyitás után is. Egy azonosító megőrzése nem bizonyítja, hogy egy alkalmazás ki tudja számolni vagy megjeleníteni az értékét.

| Formátum | Mező viselkedése és korlátai |
|---|---|
| PPTX | A PPTX a belső mezőazonosítókat tárolja a mező szövegével együtt. A körbehajtás ellenőrzéseknél a fenti előre definiált típusok és a saját azonosító megmaradt a mentés és újra megnyitás során. Az ismeretlen egyedi típus megtartotta a tartalék szöveget; nem kapott automatikus számítási logikát. Egy másik alkalmazás másként kezelheti a nem támogatott azonosítókat. |
| PPT | A PPT régi mezőábrázolásokat használ és korlátozottabb kompatibilitással rendelkezik. A körbehajtás ellenőrzéseknél a diaszám- és előre definiált dátum/idő mezők megmaradtak a mentés és újra megnyitás után. Egy egyéni mező egy szokásos diaszövegdobozban azonosítóval nyílt meg, de szövege `*` volt; egy fejlécmező ugyanabban a kontextusban szintén `*`-ot adott. Ne számíts az egyedi mezőkre vagy a nem támogatott mezőkontextusokra, hogy megtartják a látható szöveget. |

Hordozható, rögzített kimenethez alakítsd át a nem támogatott mezőket szokásos szöveggé, és a mentés előtt add meg a kívánt értéket. Ez megőrzi a kiválasztott szöveget, de szándékosan leállítja az automatikus frissítéseket. Teszteld a célalkalmazást is, ha a saját mező újraszámítása része a munkafolyamatnak.

## **GYIK**

**Hogyan tudom megállapítani, hogy a megjelenített szám vagy dátum mező?**

Vizsgáld meg a [Portion::getField](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/#getField) metódust. A nem null érték mezőt jelöl; a megjelenített szöveg önmagában nem árul el semmit.

**Eltávolítja-e egy mező a szöveget vagy a formázást?**

Nem. A [removeField](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/#removeField) a meglévő részt szokásos szöveggé alakítja. Ha egy konkrét rögzített dátumra vagy tartalék értékre van szükség, rendelj hozzá egy explicit értéket utána.

**Határozhat‑e egy belső karakterlánc új dátumformátumot vagy képletet?**

Nem. Az egy mező típust azonosít. Egy ismeretlen azonosító nem biztosít kiértékelőt vagy PHP dátumformátum‑mintát. Használj egy támogatott előre definiált típust, vagy formázd a értéket saját magad szokásos szövegként.

**Miért ellenőrizd újra a prezentációt a mentés után?**

A mezőazonosítók, a számított szöveg és a formázás különálló elemek, amelyeket ellenőrizni kell. A formátumkonverzió megváltoztathatja a látható eredményt, még ha a mezőazonosító továbbra is jelen van.