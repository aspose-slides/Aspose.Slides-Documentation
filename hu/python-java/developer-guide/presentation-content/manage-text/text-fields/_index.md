---
title: Szövegmezők kezelése PowerPoint prezentációkban Pythonban Java-n keresztül
linktitle: Szövegmezők
type: docs
weight: 52
url: /hu/python-java/text-fields/
keywords:
- szövegmező
- automatikus szöveg
- diaszám
- dátum és idő
- fejléc
- lábléc
- szöverrész
- PowerPoint
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Szövegmezők létrehozása, ellenőrzése, módosítása és eltávolítása PowerPoint prezentációkban az Aspose.Slides for Python via Java használatával. Formázás megőrzése és a mentett PPTX és PPT fájlok ellenőrzése."
---
## **Áttekintés**

Egy szöveges bekezdés részekből áll. Egy szokásos [Portion](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/) szó szerinti szöveget tartalmaz; egy mező résznél egy [Field](https://reference.aspose.com/slides/hu/python-java/aspose.slides/field/) is van, amelynek típusa egy automatikusan frissített értéket azonosít, például a dia számát vagy a dátumot. Két rész megjelenítheti ugyanazokat a karaktereket, miközben csak az egyik tartalmaz mezőt.

Használja a [Portion.getField](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/#getField) metódust a megkülönböztetéshez: szokásos szövegnél `None`. A [Portion.addField](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/#addField) egy meglévő részt mezővé alakít. Tartsa a címkét és a dinamikus értéket külön részekben, hogy az érték konvertálása ne cserélje le a címkét is.

Ez az útmutató a szövegen belüli mezőket, azok formázását és a PPTX valamint PPT mentését tárgyalja. A szövegkeretekkel és bekezdésekkel kapcsolatban lásd a [Manage Text](/slides/hu/python-java/manage-text/) oldalt.

## **Dia számozás mező létrehozása**

Az alábbi teljes példa egy szövegdobozt hoz létre, amely egy szó szerint írt `Slide ` feliratot tartalmaz, majd egy automatikusan frissített számot. Beállítja a szám méretét, vastagságát és színét a mező hozzáadása előtt, majd újra megnyitja a mentett prezentációt, és ellenőrzi a mező típusát, szövegét és formázását. Bemeneti fájl nem szükséges.

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

Az új prezentáció az 1. diával kezdődik, ezért a szöveg `Slide 1`, és mindkét ellenőrzés `True` értéket ír ki. A szám a visszaoldás után is mező marad; nem szó szerinti `1`. A hitelesítésben szereplő indexek a példában létrehozott alakzatot és részeket jelölik.

## **Válasszon mező típust**

[A FieldType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fieldtype/) a következő módszereket biztosít az előre definiált értékek lekéréséhez. Adja át a megfelelő értéket a [addField](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/#addField) hívásnak.

| Módszer | Cél |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fieldtype/#getSlideNumber) | Az aktuális dia száma. |
| [getDateTime](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fieldtype/#getDateTime) | Dátum/idő az alkalmazás alapértelmezett formátumában. |
| [getDateTime1](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fieldtype/#getDateTime9) | Előre definiált dátum vagy kombinált dátum/idő formátumok. |
| [getDateTime10](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fieldtype/#getDateTime13) | Előre definiált időformátumok, másodpercek és 12‑órás óra opciókkal. |
| [getHeader](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fieldtype/#getHeader) | Fejléc mező; lásd alább a helykitöltő és formátumkorlátozások. |
| [getFooter](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fieldtype/#getFooter) | Lábléc mező. |

Például a [getDateTime3](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fieldtype/#getDateTime3) egy napot, a hónap teljes nevét és az évet angolul jelöli. Ezek előre definiált mezőformátumok, nem tetszőleges Python dátumformázó karakterláncok. A [setLanguageId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setLanguageId) segítségével beállított nyelv és a prezentációt feldolgozó alkalmazás befolyásolhatja a megjelenített eredményt.

## **Mező létrehozása belső karakterláncból**

A [addField](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/#addField) karakterlánc túlterhelése egy belső mezőazonosítót fogad. Olyankor használja, ha egy másik alkalmazás által biztosított azonosítót szeretne megőrizni, amelynek nincs előre definiált értéke. Egy [FieldType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fieldtype/#FieldType) objektumot is létrehozhat az azonosítóból. A [FieldType.getInternalString](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fieldtype/#getInternalString) segítségével megtekintheti az azonosítót.

Ez a példa egy alkalmazás‑specifikus `custom-report-id` mezőt tárol a tartalék szöveggel `Report-042`. Az azonosító nem regisztrál számítást: az Aspose.Slides nem generál jelentés‑azonosítókat ismeretlen típusnál. Az azonosítót értelmező alkalmazásnak kell biztosítania a jelentését és frissítenie az értékét.

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

A PPTX körbefuttatás után a típus `custom-report-id`, a szöveg pedig `Report-042`. Egy `yyyy-MM-dd` típusú karakterlánc mezőtípusként lenne kezelve, nem pedig egyedi dátumformátumként. Rögzített dátumot tetszőleges formátumban szeretne, használjon egyszerű szöveget.

## **Dátum/idő mezők vizsgálata, módosítása és eltávolítása**

Módosítsa a meglévő mezőt a [Field.setType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/field/#setType) segítségével. Ellenőrizze, hogy a mező létezik-e, mielőtt a típusához férne hozzá. Az automatikus frissítések leállításához hívja meg a [Portion.removeField](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/#removeField) metódust. Ez megőrzi a részt és a jelenlegi szöveget, miközben eltávolítja a mezőkapcsolatot. Ha konkrét rögzített értékre van szükség, távolítsa el a mezőt, majd adja meg a kívánt szöveget.

A dátum/idő mezőfeldolgozással kapcsolatos API beállításért lásd a [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#setCurrentDateTime) leírását. Az alábbi példa egy kifejezett jóváhagyási dátumot használ a mező szokásos szöveggé alakításakor.

Töltse le a [sample.pptx](sample.pptx) fájlt, és helyezze a munkakönyvtárba. A fájl két nevű szövegalakzatot tartalmaz, `UpdatedAt` és `ApprovedDate`, mindkettő dátum/idő mezővel, valamint szokásos szövegcímkékkel. Az alábbi példa a normál diák felső szintű szövegalakzatait járja be. A dátum/idő mezőket hosszú dátumformátumra változtatja, és dőlt stílusra állítja, miközben a többi formázást megőrzi. Csak az `ApprovedDate` mező válik rögzített szöveggé.

A minta felismeri a beépített belső azonosítókat `datetime` és `datetime1`‑től `datetime13`‑ig. Csoportok, táblázatok, jegyzetek, elrendezések és mester diák saját szövegtárolóikat igénylik, ezért ez a példa nem terjed ki rájuk.

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
    # Használja az angol hónapneveket a rendszer helyi beállításától függetlenül.
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

A visszaolvasás után az `UpdatedAt` típusa `datetime3` és továbbra is dinamikus. Az `ApprovedDate` már nem mező, és a szövege `05 April 2030`. Mindkét dátumrész dőlt, az eredeti betűméret, félkövér beállítás és szín változatlan marad. A szokásos szövegcímkék nem változnak. A hitelesítés az első részt olvassa a két ismert alakzatról a mellékelt mintában.

## **Szövegformázás megőrzése**

Dolgozzon a meglévő résszel mező hozzáadásakor, típusváltoztatáskor vagy eltávolításakor. Ezek a műveletek megtartják a rész formázását. Használja a [Portion.getPortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/#getPortionFormat) metódust a szükséges tulajdonságok módosításához, ahogy a példák a szín vagy dőlt esetén teszik.

Kerülje el egy egész szövegkeret újraépítését csak egy mező frissítése miatt: ez elveszítheti az eredeti részhatárokat és azok egyéni formázását. Emellett különböztesse meg a kifejezetten beállított formázást a bekezdésből, elrendezésből vagy sablonból örökölt formázástól. Lásd a [Text Formatting](/slides/hu/python-java/text-formatting/) oldalt a szélesebb formázási lehetőségekért.

## **Mezők és fejléc/lábléc helykitöltők**

A mező egy szövegrész része. A helykitöltő egy prezentációs szereppel rendelkező alakzat, például lábléc vagy dia száma. Egy mező hozzáadása egy szokásos szövegdobozhoz nem változtatja azt helykitöltővé.

A fejléc/lábléc kezelők szabályozzák a helykitöltő szöveget és láthatóságot diaikon, elrendezéseken és fő sablonokon, beleértve a függő diákra való kiterjesztést. Egy egyéni szövegdobozban lévő szám mező tehát hasznos lehet akkor is, ha nem a dia‑szám helykitöltőt használja. Ezzel szemben a helykitöltő láthatóságának módosítása nem távolít el egy mezőt egy nem kapcsolódó szövegdobozból.

Az előre definiált fejléc‑ és lábléc‑típusok nem hoznak létre megfelelő helykitöltőket, és nem szolgáltatják azok tartalmát. Különösen, egy normál PowerPoint dia nem rendelkezik fejléc helykitöltővel; a fejlécek a jegyzet‑oldalakhoz és a segédlethez tartoznak. Ne feltételezze, hogy egy tetszőleges alakzatban lévő fejléc vagy lábléc mező automatikusan megkapja a helykitöltőkezelőben beállított szöveget. Erről a munkafolyamatról lásd a [Presentation Headers and Footers](/slides/hu/python-java/presentation-header-and-footer/) oldalt.

## **PPTX és PPT korlátozások**

Ellenőrizze a mező típusát és a keletkezett szöveget a mentés és újbóli megnyitás után. Egy azonosító megőrzése nem bizonyítja, hogy egy alkalmazás ki tudja számolni vagy meg tudja jeleníteni az értékét.

| Formátum | Mező viselkedése és korlátozások |
|---|---|
| PPTX | Belső mezőazonosítókat tárol a mező szövegével együtt. A körbefuttatási ellenőrzésekben az előre definiált típusok és a fent alkalmazott egyedi azonosító is megmaradt a mentés és újraolvasás során. Az ismeretlen egyedi típus megtartotta a tartalék szöveget; nem kapott automatikus számítási logikát. Egy másik alkalmazás másként kezelheti a nem támogatott azonosítókat. |
| PPT | Régi mezőábrázolásokat használ, és korlátozottabb kompatibilitással bír. A körbefuttatási ellenőrzésekben a dia‑szám és az előre definiált dátum/idő mezők megmaradtak. Egy egyedi mező egy szokásos szövegdobozban újraolvasáskor az azonosítót megtartotta, de a szövege `*` lett; egy fejléc mező ugyanabban a kontextusban is `*`-ot adott. Ne számítson arra, hogy egyedi mezők vagy nem támogatott mezőkontextusok megőrzik a látható szöveget. |

A hordozható, rögzített kimenet érdekében konvertálja a nem támogatott mezőket szokásos szöveggé, és a mentés előtt állítsa be a kívánt értéket. Ez megőrzi a kívánt szöveget, de szándékosan leállítja az automatikus frissítéseket. Tesztelje a célalkalmazást is, ha annak saját mező‑újraszámítása része a munkafolyamatnak.

## **GYIK**

**Hogyan tudom megmondani, hogy a megjelenített szám vagy dátum mező‑e?**  
Vizsgálja meg a [Portion.getField](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/#getField) értékét. A `None`‑tól eltérő érték mezőt jelez; a megjelenített szöveg önmagában nem árulja el.

**Eltávolítja-e egy mező eltávolítása a szöveget vagy a formázást?**  
Nem. A [removeField](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/#removeField) a meglévő részt szokásos szöveggé alakítja. Ha konkrét fagyasztott dátumra vagy tartalék szövegre van szüksége, adja meg azt a mező eltávolítása után.

**Egy belső karakterlánc definiálhat‑e új dátumformátumot vagy képletet?**  
Nem. Egy azonosítót ad meg, nem pedig egy értékelőt vagy Python dátumformázó mintát. Használjon támogatott előre definiált típust, vagy formázza a kívánt értéket egyszerű szövegként.

**Miért ellenőrizze újra a prezentációt a mentés után?**  
A mezőazonosítók, a számított szöveg és a formázás különálló elemek, amelyeket ellenőrizni kell. A formátumváltás megváltoztathatja a látható eredményt, még ha a mezőazonosító megmarad is.