---
title: Szövegmezők kezelése PowerPoint prezentációkban Androidon
linktitle: Szövegmezők
type: docs
weight: 52
url: /hu/androidjava/text-fields/
keywords:
- szövegmező
- automatikus szöveg
- dia száma
- dátum és idő
- fejléc
- lábléc
- szövegrész
- PowerPoint
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Hozzon létre, vizsgáljon, módosítson és távolítson el szövegmezőket PowerPoint prezentációkban az Androidra készült Aspose.Slides Java használatával. Tartsa meg a formázást és ellenőrizze a mentett PPTX és PPT fájlokat."
---
## **Áttekintés**

Egy szövegbekezdés részekből áll. Egy hagyományos [IPortion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/) szó szerinti szöveget tartalmaz; egy mező‑résznek van egy [IField](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifield/) is, amelynek típusa meghatározza az automatikusan frissülő értéket, például a dia számát vagy a dátumot. Két rész is megjelenítheti ugyanazokat a karaktereket, de csak az egyik tartalmaz mezőt.

Használja az [IPortion.getField](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/#getField--) metódust a megkülönböztetéshez: a hagyományos szöveg esetén ez `null`. Az [IPortion.addField](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) egy meglévő részt mezővé alakít. Tartsa a címkét és annak dinamikus értékét külön részekben, hogy a mező átalakítása ne cserélje le a címkét is.

Ez az útmutató a szövegen belüli mezőket, azok formázását és a PPTX illetve PPT mentését tárgyalja. A szövegkeretek és bekezdések kezeléséről lásd a [Manage Text](/slides/hu/androidjava/manage-text/) oldalt.

## **Dia száma mező létrehozása**

Az alábbi teljes példa egy szövegdobozt hoz létre, amelyben egy szó szerinti `Slide ` címke követi egy automatikusan frissülő szám. A szám méretét, vastagságát és színét a mező hozzáadása előtt állítja be, majd a mentett prezentációt újra megnyitja, és ellenőrzi a mező típusát, szövegét és formázását. Bemeneti fájl nem szükséges.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    int numberColor = Color.rgb(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor() == numberColor;

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Az új prezentáció az 1. diával indul, így a szöveg `Slide 1`, és mindkét ellenőrzés `true` értéket ad. A szám a megnyitás után is mező marad; nem szó szerinti `1`. A verifikációban szereplő cast-ek és indexek az ebben a példában létrehozott alakzatokra és részekre mutatnak.

## **Mező típusának kiválasztása**

[FieldType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fieldtype/) a [IFieldType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifieldtype/) implementációja, és a következő metódusokkal ad előre definiált értékeket. A megfelelő értéket adja át az [addField](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) metódusnak.

| Method | Purpose |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fieldtype/#getSlideNumber--) | A jelenlegi dia száma. |
| [getDateTime](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fieldtype/#getDateTime--) | Dátum/idő a megjelenítő alkalmazás alapértelmezett formátumában. |
| [getDateTime1](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fieldtype/#getDateTime9--) | Előre definiált dátum- vagy kombinált dátum/idő formátumok. |
| [getDateTime10](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fieldtype/#getDateTime13--) | Előre definiált időformátumok, másodpercek és 12‑órás óra opciókkal. |
| [getHeader](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fieldtype/#getHeader--) | Fejlécmező; lásd az alább felsorolt helyőrző‑ és formátumkorlátozásokat. |
| [getFooter](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fieldtype/#getFooter--) | Láblécmező. |

Például a [getDateTime3](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fieldtype/#getDateTime3--) egy napot, a teljes hónap nevét és az évet angolul jeleníti meg. Ezek előre definiált mezőformátumok, nem tetszőleges Java dátumformátum‑karakterláncok. A [setLanguageId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)‑vel beállított nyelv és a prezentációt feldolgozó alkalmazás befolyásolhatja a megjelenített eredményt.

## **Mező létrehozása belső karakterláncból**

Az [addField](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/#addField-java.lang.String-) karakterlánc‑túlterhelése egy belső mezőazonosítót fogad. Olyankor használja, amikor egy másik alkalmazás által biztosított azonosítót kell megőrizni, amelyhez nincs előre definiált érték. A [FieldType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) is létrehozható az azonosítóból. Az [IFieldType.getInternalString](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifieldtype/#getInternalString--) exponálja az azonosítót ellenőrzés céljából.

Ez a példa egy alkalmazás‑specifikus `custom-report-id` mezőt tárol a tartalék `Report-042` szöveggel. Az azonosító nem indít számítást: az Aspose.Slides ismeretlen típusra nem generál jelentés‑azonosítót. Az azonosítót értelmező alkalmazásnak kell biztosítani a jelentés jelentését és frissíteni az értékét.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

A PPTX körúton keresztül a típus `custom-report-id`, a szöveg pedig `Report-042` marad. Egy `yyyy-MM-dd`‑szű karakterlánc mező‑típust nevezne, de nem konfigurálna egyedi dátumformátumot. Egy rögzített, tetszőleges formátumú dátumhoz használjon egyszerű szöveget.

## **Dátum/Idő mezők vizsgálata, módosítása és eltávolítása**

Módosítsa a meglévő mezőt az [IField.setType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-) metódussal. Mielőtt a típushoz hozzáférne, ellenőrizze, hogy a mező létezik-e. Az automatikus frissítések leállításához hívja az [IPortion.removeField](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/#removeField--) metódust. Ez megőrzi a részt és a jelenlegi szövegét, miközben eltávolítja a mezőkapcsolatot. Ha egy konkrét rögzített értékre van szükség, távolítsa el a mezőt, majd rendelje hozzá a kívánt szöveget.

A dátum/idő mezőfeldolgozással kapcsolatos API beállításhoz lásd a [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-) leírást. Az alábbi példa egy kifejezett jóváhagyási dátumot használ a mező szokásos szöveggé alakításakor.

Töltse le a [sample.pptx](sample.pptx) fájlt, és helyezze a munkakönyvtárba. A fájl két elnevezett szöveges alakzatot tartalmaz, `UpdatedAt` és `ApprovedDate` neven, mindkettőben dátum/idő mező, valamint szó szerinti címkéket. Az alábbi példa a szabályos diák felső‑szintű szöveges alakzatait járja be. A dátum/idő mezőket hosszú dátum formátumra alakítja, dőlt betűvé teszi őket, miközben a többi formázásukat változatlanul hagyja. Csak az `ApprovedDate` mező alakított szöveggé.

A minta a beépített belső azonosítókat `datetime` és `datetime1`‑től `datetime13`‑ig ismeri. Csoportok, táblázatok, jegyzetek, elrendezések és főalapok saját szövegtárolóik bejárását igénylik, és ezeken kívül esnek a példán kívül.

```java
import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Date;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    Calendar approvalDate = Calendar.getInstance();
    approvalDate.clear();
    approvalDate.set(2030, Calendar.APRIL, 5);
    SimpleDateFormat dateFormat = new SimpleDateFormat("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        Date dateValue = approvalDate.getTime();
                        String fixedDate = dateFormat.format(dateValue);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

A megnyitás után az `UpdatedAt` típus `datetime3`, és dinamikus marad. Az `ApprovedDate` már nem mező, és a szövege `05 April 2030`. Mindkét dátum‑rész dőlt, az eredeti betűméret, félkövér beállítás és szín változatlan. A szokásos szövegcímkék érintetlenek. A verifikáció a megadott mintában található két ismert alakzat első részét olvassa.

## **Szövegformázás megőrzése**

Dolgozzon a meglévő résszel mező hozzáadásakor, típusának módosításakor vagy eltávolításakor. Ezek a műveletek megtartják a rész formázását. Használja az [IPortion.getPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/#getPortionFormat--) metódust csak a szükséges tulajdonságok módosításához, ahogy a példák a szín vagy dőlt betű esetén mutatják.

Kerülje el egy teljes szövegkeret újbóli felépítését csak egy mező frissítése miatt: ez elveszítheti a részhatárokat és egyedi formázásukat. Emellett különböztesse a kifejezetten beállított formázást a bekezdésből, elrendezésből vagy sablonból örökölt formázástól. A [Text Formatting](/slides/hu/androidjava/text-formatting/) oldal a szélesebb formázási lehetőségeket mutatja be.

## **Mezők és fejléc/lábléc helyőrzők**

A mező egy szövegrész része. A helyőrző egy olyan alakzat, amely prezentációs szereppel bír, például lábléc vagy dia szám. Egy mező hozzáadása egy szokásos szövegdobozhoz nem változtatja azt helyőrzővé.

A fejléc/lábléc kezelők a helyőrző szöveget és láthatóságot szabályozzák diákon, elrendezéseken és főalapokon, beleértve a függő diákra való kiterjesztést. Egy egyéni szövegdobozban lévő szám mező ezért akkor is hasznos lehet, ha nem a dia‑szám helyőrzőt használja. Ezzel szemben a helyőrző láthatóságának módosítása nem távolít el egy mezőt egy nem kapcsolódó szövegdobozból.

Az előre definiált fejléc‑ és lábléc‑típusok nem hoznak létre a megfelelő helyőrzőket, és nem biztosítják azok tartalmát. Különösen, egy szokásos PowerPoint dia nem tartalmaz fejléc‑helyőrzőt; a fejlécek a jegyzet‑oldalakra és előlapokra vonatkoznak. Ne gondolja, hogy egy tetszőleges alakzatban lévő fejléc‑ vagy lábléc‑mező automatikusan megkapja a helyőrzőkezelő által konfigurált szöveget. Erről a munkafolyamatról lásd a [Presentation Headers and Footers](/slides/hu/androidjava/presentation-header-and-footer/) oldalt.

## **PPTX és PPT korlátai**

Mentés és újra­nyitás után ellenőrizze mind a mező típusát, mind a keletkezett szöveget. Az azonosító megőrzése nem bizonyítja, hogy egy alkalmazás képes kiszámítani vagy megjeleníteni az értékét.

| Format | Field behavior and limitations |
|---|---|
| PPTX | Belső mezőazonosítókat tárol a mezőszöveggel együtt. A körülmenetes ellenőrzések során az előre definiált típusok és a fent használt egyedi azonosító is megmaradt a mentés és újranyitás után. Az ismeretlen egyedi típus a tartalék szöveget megtartotta; nem kapott automatikus számítási logikát. Egy másik alkalmazás eltérően kezelheti a nem támogatott azonosítókat. |
| PPT | Régi mezőábrázolást használ, és kevésbé kompatibilis. A körülmenetes ellenőrzések során a dia‑szám és az előre definiált dátum/idő mezők megmaradtak a mentés és újranyitás után. Egy egyedi mező egy szokásos dia‑szövegdobozban azonosítóval, de `*` szöveggel nyílt meg; egy fejléc‑mező ugyanabban a kontextusban is `*`-ot adott. Ne számítson arra, hogy egyedi mezők vagy nem támogatott mezőkontextusok megtartják a látható szövegüket. |

A hordozható, rögzített kimenet érdekében konvertálja a nem támogatott mezőket szokásos szöveggé, és a mentés előtt állítson be explicit módon olyan értéket, amelyet meg szeretne őrizni. Ez megőrzi a választott szöveget, de szándékosan leállítja az automatikus frissítéseket. Tesztelje a célalkalmazást is, ha annak saját mező‑újraszámolása része a munkafolyamatnak.

## **GYIK**

**Hogyan tudom megállapítani, hogy a megjelenített szám vagy dátum mező?**

Vizsgálja meg az [IPortion.getField](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/#getField--) értékét. A nem null érték mezőt jelez; a megjelenített szöveg önmagában nem árul el semmit.

**A mező eltávolítása eltávolítja a szöveget vagy a formázást?**

Nem. A [removeField](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/#removeField--) a meglévő részt szokásos szöveggé alakítja. Ha egy adott fagyasztott dátumra vagy tartalék értékre van szüksége, az eltávolítás után rendelje hozzá az explicit értéket.

**Egy belső karakterlánc definiálhat új dátumformátumot vagy képletet?**

Nem. Ez csak egy mezőtípust azonosít. Egy ismeretlen azonosító nem biztosít kiértékelőt vagy Java dátumformátum‑mintát. Használjon támogatott előre definiált típust, vagy formázza a kívánt értéket egyszerű szövegként.

**Miért kell a prezentációt újra ellenőrizni a mentés után?**

A mezőazonosítók, a kiszámított szöveg és a formázás különálló dolgok, amelyeket mind ellenőrizni kell. A formátumkonverzió megváltoztathatja a látható eredményt, még akkor is, ha a mezőazonosító továbbra is jelen van.