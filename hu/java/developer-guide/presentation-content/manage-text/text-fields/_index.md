---
title: PowerPoint-prezentációk szövegmezőinek kezelése Java-ban
linktitle: Szövegmezők
type: docs
weight: 52
url: /hu/java/text-fields/
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
- Java
- Aspose.Slides
description: "Készítsen, vizsgáljon, módosítson és távolítson el szövegmezőket PowerPoint-prezentációkban az Aspose.Slides for Java segítségével. Tartsa meg a formázást, és ellenőrizze a mentett PPTX és PPT fájlokat."
---
## **Áttekintés**

Egy szöveges bekezdés részekből áll. Egy szokványos [IPortion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/) literál szöveget tartalmaz; egy mező résznek van egy [IField](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifield/) is, amelynek típusa automatikusan frissített értéket jelöl, például diaszámot vagy dátumot. Két rész ugyanazokat a karaktereket jelenítheti meg, miközben csak az egyik tartalmaz mezőt.

Használja a [IPortion.getField](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/#getField--) a megkülönböztetéshez: szokványos szöveg esetén `null`. Az [IPortion.addField](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) egy létező részt mezővé konvertál. Tartsa a címkét és annak dinamikus értékét külön részekben, hogy az érték konvertálása ne cserélje le a címkét is.

Ez az útmutató a szövegen belüli mezőket, azok formázását és mentését PPTX és PPT formátumban tárgyalja. A szövegkeretekkel és bekezdésekkel kapcsolatban lásd a [Manage Text](/slides/hu/java/manage-text/) oldalt.

## **Dia szám mező létrehozása**

Az alábbi teljes példa egy szövegdobozt hoz létre, amely egy literális `Slide ` címkét tartalmaz, melyet egy automatikusan frissített szám követ. A mező hozzáadása előtt beállítja a szám méretét, vastagságát és színét, majd újra megnyitja a mentett prezentációt és ellenőrzi a mező típusát, szövegét és formázását. Bemeneti fájl nem szükséges.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    Color numberColor = new Color(0, 0, 139);
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
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

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

Az új prezentáció az 1. diával indul, így a szöveg `Slide 1`, és mindkét ellenőrzés `true` értéket ad. A szám a megnyitás után is mező marad; nem literális `1`. A verifikációban szereplő átalakítások és indexek az ebben a példában létrehozott alakzatokra és részekre vonatkoznak.

## **Mező típus kiválasztása**

A [FieldType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fieldtype/) megvalósítja az [IFieldType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifieldtype/) interfészt, és a következő metódusokat biztosítja előre definiált értékek lekéréséhez. Adja át a megfelelő értéket az [addField](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) metódusnak.

| Módszer | Cél |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fieldtype/#getSlideNumber--) | Az aktuális dia száma. |
| [getDateTime](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fieldtype/#getDateTime--) | Dátum/idő a renderelő alkalmazás alapértelmezett formátumában. |
| [getDateTime1](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fieldtype/#getDateTime9--) | Előre definiált dátum vagy kombinált dátum/idő formátumok. |
| [getDateTime10](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fieldtype/#getDateTime13--) | Előre definiált időformátumok, másodpercekkel és 12‑órás órával. |
| [getHeader](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fieldtype/#getHeader--) | Fejlécmező; lásd az alább található helyőrző és formátum korlátozásokat. |
| [getFooter](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fieldtype/#getFooter--) | Lábjegyzetmező. |

Például a [getDateTime3](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fieldtype/#getDateTime3--) egy napot, teljes hónapnevet és évet jelenít meg angolul. Ezek előre definiált mezőformátumok, nem tetszőleges Java dátumformátum-karakterláncok. A [setLanguageId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)‑vel beállított nyelv és a prezentációt feldolgozó alkalmazás befolyásolhatja a megjelenített eredményt.

## **Mező létrehozása belső karakterláncból**

Az [addField](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/#addField-java.lang.String-) karakterlánc‑túlterhelése egy belső mezőazonosítót fogad. Használja, ha meg kell őrizni egy másik alkalmazás által biztosított, előre definiált értékkel nem rendelkező azonosítót. Az azonosítóból közvetlenül is létrehozható egy [FieldType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-). A [IFieldType.getInternalString](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifieldtype/#getInternalString--) azonosítót vizsgálatra teszi hozzáférhetővé.

Ez a példa egy alkalmazás‑specifikus `custom-report-id` mezőt tárol az `Report-042` tartalék szöveggel. Az azonosító nem regisztrál számítást: az Aspose.Slides nem generál jelentés‑azonosítókat ismeretlen típushoz. Az alkalmazásnak, amely ismeri ezt az azonosítót, kell biztosítania a jelentését és frissítenie az értékét.

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

A PPTX körkörös mentés után a típus `custom-report-id`, a szöveg pedig `Report-042`. Egy `yyyy-MM-dd` karakterlánc átadása mező típust nevezne, nem egy egyedi dátumformátumot konfigurálna. Rögzített dátum tetszőleges formátumban használjon szokványos szöveget.

## **Dátum/idő mezők ellenőrzése, módosítása és eltávolítása**

Módosítson egy meglévő mezőt a [IField.setType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-) segítségével. Ellenőrizze, hogy a mező létezik, mielőtt a típusához hozzáférne. Az automatikus frissítések leállításához hívja a [IPortion.removeField](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/#removeField--) metódust. Ez megtartja a részt és az aktuális szövegét, miközben eltávolítja a mező kapcsolatot. Ha egy konkrét rögzített értékre van szükség, a mező eltávolítása után adja hozzá a szöveget.

A dátum/idő mező feldolgozásához kapcsolódó API beállítást megtalálja a [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-) oldalon. Az alábbi példa egy kifejezett jóváhagyási dátumot használ, amikor egy mezőt szokványos szöveggé konvertál.

Töltse le a [sample.pptx](sample.pptx) fájlt, és helyezze a munkakönyvtárba. Két elnevezett szöveges alakzatot tartalmaz, `UpdatedAt` és `ApprovedDate`, mindegyik dátum/idő mezővel, valamint szokványos szövegcímkékkel. Az alábbi példa végigjárja a normál diák felső szintű szöveges alakzatait. A dátum/idő mezőket hosszú dátumformátumra módosítja és dőlté teszi őket, miközben megőrzi a többi formázást. Csak a `ApprovedDate` mezők válnak rögzített szöveggé.

A minta felismertíti a beépített belső azonosítókat `datetime` és `datetime1`‑től `datetime13`‑ig. Csoportok, táblázatok, jegyzetek, elrendezések és mester‑diák saját szövegtárolóik bejárását igénylik, és ez kívül esik a példa hatókörén.

```java
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    LocalDate approvalDate = LocalDate.of(2030, 4, 5);
    DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMMM yyyy", Locale.US);

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
                        String fixedDate = approvalDate.format(dateFormat);
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

A megnyitás után az `UpdatedAt` típusa `datetime3` és dinamikus marad. Az `ApprovedDate` nem tartalmaz mezőt, és `05 April 2030` szöveget tartalmaz. Mindkét dátum rész dőlt, és az eredeti betűméret, félkövér beállítás és szín megmarad. A szokványos szövegcímkék változatlanok. A verifikáció a mintában szereplő két ismert alakzat első részét olvassa.

## **Szövegformázás megőrzése**

Dolgozzon a meglévő résszel mező hozzáadásakor, típusának módosításakor vagy eltávolításakor. Ezek a műveletek megőrzik a rész formázását. Használja az [IPortion.getPortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/#getPortionFormat--)‑t csak a szükséges tulajdonságok módosítására, ahogy a példák a szín vagy dőlt esetében teszik.

Kerülje el egy teljes szövegkeret újbóli felépítését csak egy mező frissítéséhez: ez elveszítheti az eredeti rész határait és egyedi formázását. Továbbá különböztesse meg a kifejezetten beállított formázást a bekezdésből, elrendezésből vagy témából örökölt formázástól. Lásd a [Text Formatting](/slides/hu/java/text-formatting/) oldalt a szélesebb formázási lehetőségekért.

## **Mezők és fejléc/lábléc helyőrzők**

Egy mező a szöveg részének része. Egy helyőrző egy alakzat, amely prezentációs szereppel bír, például lábléccel vagy diaszámmal. Mező hozzáadása egy szokványos szövegdobozhoz nem alakítja azt helyőrzővé.

A fejléc/lábléc kezelők szabályozzák a helyőrző szöveget és láthatóságot diákon, elrendezéseken és mester‑diákon, beleértve a függő diákra való terjedést. Egy számmező egy egyedi szövegdobozban ezért hasznos lehet, még ha a diaszám helyőrzőt nem is használja. Ezzel ellentétben a helyőrző láthatóságának módosítása nem távolít el egy mezőt egy nem kapcsolódó szövegdobozból.

Az előre definiált fejléc és lábléc típusok nem hoznak létre a megfelelő helyőrzőket, és nem szolgáltatják a tartalmat. Különösen, egy szabályos PowerPoint dia nem rendelkezik fejléc helyőrzővel; a fejlécek a jegyzetoldalakhoz és a szórólapokhoz tartoznak. Ne feltételezze, hogy egy fejléc vagy lábléc mező egy tetszőleges alakzatban automatikusan megkapja a helyőrzőkezelő által beállított szöveget. Ehhez a munkafolyamathoz lásd a [Presentation Headers and Footers](/slides/hu/java/presentation-header-and-footer/) oldalt.

## **PPTX és PPT korlátozások**

Ellenőrizze mind a mező típusát, mind a keletkezett szöveget a mentés és a megnyitás után. Az azonosító megőrzése nem bizonyítja, hogy egy alkalmazás képes kiszámítani vagy megjeleníteni az értékét.

| Formátum | Mező viselkedése és korlátozások |
|---|---|
| PPTX | Belső mezőazonosítókat tárol a mező szövegével együtt. A körkörös ellenőrzések során az előre definiált típusok és a fent használt egyéni azonosító is megmaradt a mentés és a megnyitás után. Az ismeretlen egyéni típus megtartotta a tartalék szöveget; nem kapott automatikus számítási logikát. Egy másik alkalmazás eltérően kezelheti a nem támogatott azonosítókat. |
| PPT | Örökölt mezőábrázolást használ, és korlátozottabb a kompatibilitása. A körkörös ellenőrzések során a dia szám és az előre definiált dátum/idő mezők megmaradtak a mentés és a megnyitás után. Egy egyéni mező egy szokványos dia szövegdobozban azonosítóval nyílt meg, de `*` karakterként jelenik meg; egy fejlécmező ugyanabban a környezetben szintén `*` eredményt ad. Ne támaszkodjon arra, hogy az egyéni mezők vagy a nem támogatott mező kontextusok megtartják a látható szöveget. |

Portábilis, rögzített kimenethez konvertálja a nem támogatott mezőket szokványos szöveggé, és mentés előtt adja meg kifejezetten a kívánt értéket. Ez megőrzi a kiválasztott szöveget, de szándékosan leállítja az automatikus frissítéseket. Tesztelje a célalkalmazást is, ha annak saját mező-újraszámítása része a munkafolyamatnak.

## **GYIK**

**Hogyan tudom megállapítani, hogy egy megjelenített szám vagy dátum mező?**  
Vizsgálja meg a [IPortion.getField](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/#getField--). A nem null érték mezőt jelez; a megjelenített szöveg önmagában nem mondja meg.

**Eltávolítja-e a mező eltávolítása a szöveget vagy a formázást?**  
Nem. A [removeField](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/#removeField--) a meglévő részt szokványos szöveggé alakítja. Ha egy konkrét rögzített dátumra vagy tartalék értékre van szüksége, a mező eltávolítása után adjon meg egy explicit értéket.

**Határozhat-e egy belső karakterlánc új dátumformátumot vagy képletet?**  
Nem. Ez egy mezőtípust azonosít. Egy ismeretlen azonosító nem biztosít értékelőt vagy Java dátumformátum-mintát. Használjon támogatott előre definiált típust, vagy formázzon egy értéket saját maga szokványos szövegként.

**Miért ellenőrizze újra a prezentációt a mentés után?**  
A mezőazonosítók, a számított szöveg és a formázás külön ellenőrzendő dolgok. A formátum konverzió megváltoztathatja a látható eredményt, még ha a mezőazonosító továbbra is jelen van.