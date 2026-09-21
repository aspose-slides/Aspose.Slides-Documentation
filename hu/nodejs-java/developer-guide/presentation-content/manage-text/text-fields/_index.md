---
title: PowerPoint bemutatók szövegmezőinek kezelése JavaScript-ben
linktitle: Szövegmezők
type: docs
weight: 52
url: /hu/nodejs-java/text-fields/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Hozzon létre, ellenőrizzen, módosítson és távolítson el szövegmezőket PowerPoint bemutatókban az Aspose.Slides for Node.js Java használatával. Őrizze a formázást és ellenőrizze a mentett PPTX és PPT fájlokat."
---
## **Áttekintés**

A szöveges bekezdés részekből áll. Egy szokásos [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) tartalmazza a szó szerinti szöveget; egy mező-résznek van egy [Field](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/field/), amelynek típusa egy automatikusan frissített értéket jelöl, például diaszámot vagy dátumot. Két rész is ugyanazokat a karaktereket jelenítheti meg, de csak az egyik tartalmaz mezőt.

Használja a [Portion.getField](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/#getField) függvényt a megkülönböztetéshez: szokásos szöveg esetén `null`. A [Portion.addField](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/#addField) egy meglévő részt mezővé alakít. Tartsa a címkét és a dinamikus értékét külön részekben, hogy az érték konvertálása ne cserélje le a címkét.

Ez az útmutató a szövegen belüli mezőket, azok formázását és a PPTX illetve PPT mentését tárgyalja. Szövegkeretek és bekezdések esetén lásd a [Manage Text](/slides/hu/nodejs-java/manage-text/) témát.

## **Dia szám mező létrehozása**

Az alábbi teljes példa egy szövegdobozt hoz létre, amelyben egy szó szerinti `Slide ` címke után egy automatikusan frissített szám jelenik meg. A szám méretét, vastagságát és színét beállítja a mező hozzáadása előtt, majd újra megnyitja a mentett prezentációt, és ellenőrzi a mező típusát, szövegét és formázását. Bemeneti fájl nem szükséges.

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

Az új prezentáció az 1. diával indul, így a szöveg `Slide 1`, és mindkét ellenőrzés `true` értéket ad. Az újranyitás után a szám továbbra mező marad; nem szó szerinti `1`. Az ellenőrzésben szereplő indexek a példában létrehozott alakzatot és részeket jelölik.

## **Válasszon mező típust**

[FieldType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fieldtype/) a következő módszereket biztosít az előre definiált értékek lekéréséhez. Adja át a megfelelő értéket a [addField](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/#addField) hívásnak.

| Módszer | Cél |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | Az aktuális diaszám. |
| [getDateTime](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fieldtype/#getDateTime) | Dátum/idő az alkalmazás alapértelmezett formátumában. |
| [getDateTime1](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | Előre definiált dátum vagy kombinált dátum/idő formátumok. |
| [getDateTime10](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | Előre definiált időformátumok, másodperccel és 12‑órás órával. |
| [getHeader](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fieldtype/#getHeader) | Fejlécmező; lásd a helyőrző és formátum korlátozásait lent. |
| [getFooter](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fieldtype/#getFooter) | Láblécmező. |

Például a [getDateTime3](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fieldtype/#getDateTime3) egy napot, a hónap teljes nevét és az évet angolul jelöli. Ezek előre definiált mezőformátumok, nem tetszőleges dátumformátum karakterláncok. A [setLanguageId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) által beállított nyelv és a prezentációt feldolgozó alkalmazás befolyásolhatja a megjelenített eredményt.

## **Mező létrehozása belső karakterláncból**

Az [addField](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/#addField) karakterlánc‑túlterhelése belső mezőazonosítót fogad. Olyan esetekben használja, amikor egy másik alkalmazás által megadott azonosítót kell megőrizni, amelyhez nincs előre definiált érték. Az azonosítóból közvetlenül is létrehozható egy [FieldType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fieldtype/). A [FieldType.getInternalString](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fieldtype/#getInternalString) ezt az azonosítót teszi elérhetővé vizsgálatra.

Ez a példa egy alkalmazás‑specifikus `custom-report-id` mezőt tárol a visszaeső szöveggel `Report-042`. Az azonosító nem regisztrál számítást: az Aspose.Slides nem generál jelentés‑azonosítókat ismeretlen típushoz. Az azonosítót értelmező alkalmazásnak kell biztosítania a jelentését és frissítenie az értékét.

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

A PPTX körúton keresztül a típus `custom-report-id`, a szöveg pedig `Report-042` marad. Egy `yyyy-MM-dd` karakterlánc átadása mező típust nevezne, nem egy saját dátumformátumot állítana be. Rögzített dátum tetszőleges formátummal való megjelenítéséhez használjon egyszerű szöveget.

## **Dátum/idő mezők vizsgálata, módosítása és eltávolítása**

Módosítsa a meglévő mezőt a [Field.setType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/field/#setType) segítségével. Ellenőrizze, hogy a mező létezik-e, mielőtt a típusához hozzáférne. Az automatikus frissítések leállításához hívja a [Portion.removeField](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/#removeField) függvényt. Ez megtartja a részt és a jelenlegi szöveget, miközben eltávolítja a mezőkapcsolatot. Ha konkrét rögzített értékre van szükség, a mező eltávolítása után rendelje hozzá a kívánt szöveget.

A dátum/idő mezőfeldolgozáshoz kapcsolódó API‑beállítást lásd a [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#setCurrentDateTime) dokumentációban. Az alábbi példa egy kifejezett jóváhagyási dátumot használ, amikor egy mezőt szokásos szöveggé alakít.

Töltse le a [sample.pptx](sample.pptx) fájlt, és helyezze el a munkakönyvtárban. A fájl két névvel ellátott szöveges alakzatot tartalmaz: `UpdatedAt` és `ApprovedDate`, mindkettőnek van egy dátum/idő mezője, valamint szokásos szövegcímkék. A következő példa a normál diák felső szintű szöveges alakzatait járja be. A dátum/idő mezőket hosszú dátumformátumra alakítja, dőlté teszi őket, miközben a többi formázásukat megőrzi. Csak a `ApprovedDate` mezők válnak rögzített szöveggé.

A jóváhagyási dátum 2030. április 5.; a JavaScript hónapindexek nullától indulnak, így április `3`. UTC‑t használunk mind a létrehozás, mind a formázás során, hogy a dátum független legyen a helyi időzónától.

A minta felismeri a beépített belső azonosítókat `datetime` és `datetime1`‑től `datetime13`‑ig. Csoportok, táblázatok, jegyzetek, elrendezések és mester‑lapok saját szövegtárolóinak bejárását igénylik, ezért kívül esnek a példán.

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

Az újranyitás után az `UpdatedAt` típusa `datetime3` és dinamikus marad. Az `ApprovedDate` már nem tartalmaz mezőt, a szövege `05 April 2030`. Mindkét dátumrész dőlt, eredeti betűméretük, félkövér beállításuk és színük változatlan. A szokásos szövegcímkék nem módosultak. Az ellenőrzés a két ismert alakzat első részét olvassa a mellékelt mintából.

## **Szöveg formázásának megőrzése**

A mező hozzáadása, típusának módosítása vagy eltávolítása során dolgozzon a meglévő részen. Ezek a műveletek megőrzik a rész formázását. Használja a [Portion.getPortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/#getPortionFormat) függvényt csak a szükséges tulajdonságok módosításához, ahogy a példák a szín vagy dőlt módosításánál teszik.

Kerülje el egy teljes szövegkeret újjáépítését csak egy mező frissítéséhez: ez elveszítheti az eredeti részhatárokat és azok egyedi formázását. Emellett különböztesse az explicit módon beállított formázást a bekezdésből, elrendezésből vagy témából örökölt formázástól. Lásd a [Text Formatting](/slides/hu/nodejs-java/text-formatting/) témát a szélesebb formázási lehetőségekért.

## **Mezők és fejléc/lábléc helyőrzők**

A mező egy szövegrész része. A helyőrző egy olyan alakzat, amely prezentációs szereppel bír, például lábléccel vagy diaszámmal. A mező hozzáadása egy szokásos szövegdobozhoz nem alakítja át az alakzatot helyőrzővé.

A fejléc/lábléc kezelők a helyőrző szöveget és láthatóságot szabályozzák diaokon, elrendezéseken és mestereken, beleértve a függő diákra való kiterjesztést is. Egy egyéni szövegdobozban lévő számmező hasznos lehet akkor is, ha a diaszám helyőrzőt nem használja. Ezzel szemben a helyőrző láthatóságának módosítása nem távolít el egy mezőt egy nem kapcsolódó szövegdobozból.

Az előre definiált fejléc‑ és lábléc típusok nem hoznak létre a megfelelő helyőrzőket, és nem biztosítják azok tartalmát. Különösen egy szabályos PowerPoint dia nem rendelkezik fejléchelyőrzővel; a fejléc a jegyzetoldalakon és a kiosztott anyagokon jelenik meg. Ne feltételezze, hogy egy fejléc‑ vagy láblécmező egy tetszőleges alakzatban automatikusan megkapja a helyőrző‑kezelőben konfigurált szöveget. Az ehhez kapcsolódó munkafolyamatért lásd a [Presentation Headers and Footers](/slides/hu/nodejs-java/presentation-header-and-footer/) dokumentumot.

## **PPTX és PPT korlátozások**

Mentés és újranyitás után ellenőrizze mind a mező típusát, mind a keletkező szöveget. Az azonosító megőrzése önmagában nem bizonyítja, hogy egy alkalmazás képes számítani vagy megjeleníteni annak értékét.

| Formátum | Mező viselkedése és korlátozások |
|---|---|
| PPTX | A belső mezőazonosítókat a mezőszöveggel együtt tárolja. A körúton végzett ellenőrzések során az előre definiált típusok és a fenti egyedi azonosító is megmaradt a mentés után. Az ismeretlen egyedi típus megtartotta a visszaeső szöveget; nem kapott automatikus számítási logikát. Egy másik alkalmazás eltérően kezelheti a nem támogatott azonosítókat. |
| PPT | Régi mezőábrázolásokat használ, és korlátozottabb kompatibilitással bír. A körúton végzett ellenőrzések során a diaszám és az előre definiált dátum/idő mezők megmaradtak. Egy egyedi mező egy szokásos diaszövegben a megnyitáskor azonosítóval, de `*` szöveggel jelenik meg; egy fejlécmező ugyanabban a kontextusban is `*` eredményt ad. Ne támaszkodjon arra, hogy az egyedi mezők vagy nem támogatott mezőkörnyezetek megtartják látható szövegüket. |

Hordozható, rögzített kimenethez konvertálja a nem támogatott mezőket szokásos szöveggé, és a mentés előtt adja meg expliciten a kívánt értéket. Ez megőrzi a kiválasztott szöveget, de szándékosan leállítja az automatikus frissítéseket. Tesztelje a célalkalmazást is, ha annak saját mező‑újraszámítása része a munkafolyamatnak.

## **GYIK**

**Hogyan tudom megállapítani, hogy egy megjelenített szám vagy dátum mező?**

Vizsgálja meg a [Portion.getField](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/#getField) értékét. A nem‑null érték mezőt jelez; a megjelenő szöveg önmagában nem árulja el.

**A mező eltávolítása eltávolítja a szöveget vagy a formázást?**

Nem. A [removeField](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/#removeField) a meglévő részt szokásos szöveggé alakítja. Ha egy konkrét fagyasztott dátumot vagy visszaeső értéket akar, a mező eltávolítása után rendelje hozzá a kívánt szöveget.

**Egy belső karakterlánc definiálhat új dátumformátumot vagy képletet?**

Nem. Ez csak egy mező típust azonosít. Egy ismeretlen azonosító nem biztosít kiértékelőt vagy dátumformátum‑mintát. Használjon támogatott előre definiált típust, vagy formázza a kívánt értéket egyszerű szövegként.

**Miért ellenőrzöm újra a prezentációt a mentés után?**

A mezőazonosítók, a kiszámított szöveg és a formázás különálló elemek, amelyeket mind ellenőrizni kell. A formátumkonverzió megváltoztathatja a látható eredményt, még ha a mezőazonosító továbbra is jelen van.