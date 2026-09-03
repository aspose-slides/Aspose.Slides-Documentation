---
title: Betűtípusok beágyazása prezentációkba Java-ban
linktitle: Beágyazott betűtípusok
type: docs
weight: 40
url: /hu/java/embedded-font/
keywords:
- betűtípus hozzáadása
- betűtípus beágyazása
- betűtípus beágyazás
- beágyazott betűtípus lekérése
- beágyazott betűtípus hozzáadása
- beágyazott betűtípus eltávolítása
- beágyazott betűtípus tömörítése
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Kezelje a beágyazott betűtípusokat PowerPoint-ban az Aspose.Slides for Java segítségével. Adjon hozzá, kérdezze le, távolítsa el és tömörítse a betűtípusokat a szöveg megjelenésének megőrzése és a fájlméret csökkentése érdekében."
---
## **Bevezetés**

A betűtípusok beágyazása a betűtípus‑adatokat a PowerPoint‑prezentációba menti. Ha egy megjelenítő támogatja a beágyazott betűtípusokat, képes a szöveget ezekkel a betűtípusokkal megjeleníteni akkor is, ha nincsenek telepítve a célrendszeren. Ez segít megőrizni a sortöréseket, a szövegtávolságot és a diaelrendezést.

Az Aspose.Slides for Java lehetővé teszi a beágyazott betűtípusok lekérdezését, hozzáadását és eltávolítását az [IFontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/) felületen keresztül, amelyet a [Presentation.getFontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getFontsManager--) ad vissza. A beágyazott betűtípus‑adat méretét is csökkentheti a prezentáció által nem használt karakterek eltávolításával.

Az alábbi példák PPTX fájlokkal működnek. A betűtípus beágyazása előtt győződjön meg arról, hogy a betűtípus adat elérhető az Aspose.Slides számára, és a licenc engedélyezi a beágyazást.

## **Beágyazott betűtípusok lekérése és eltávolítása**

Használja a [getEmbeddedFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) metódust a prezentációban tárolt betűtípusok felsorolásához. Egy betűtípus eltávolításához adja át a listából egy betűtípust a [removeEmbeddedFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) metódusnak, majd mentse a prezentációt.

Az alábbi példa felsorolja a beágyazott betűtípusokat a `EmbeddedFonts.pptx` fájlban, és eltávolítja a Calibri-t, ha jelen van:

```java
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    for (IFontData font : embeddedFonts) {
        System.out.println(font.getFontName());
    }

    IFontData fontToRemove = null;
    for (IFontData font : embeddedFonts) {
        if ("Calibri".equalsIgnoreCase(font.getFontName())) {
            fontToRemove = font;
            break;
        }
    }

    if (fontToRemove != null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

A beágyazott betűtípus eltávolítása a tárolt betűtípus‑adatot törli; nem változtatja meg a szöveghez rendelt betűtípust. Ha a betűtípus telepítve van a célrendszeren, a szöveg továbbra is használhatja azt. Egyébként a megjelenítés [font substitution](/slides/hu/java/font-substitution/) igényelhet, ami befolyásolhatja az elrendezést.

## **Betűtípus adat és beágyazási engedélyek ellenőrzése**

Használja az [IFontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/) felületet a betűtípusok beágyazás előtti ellenőrzéséhez. Hívja a [IFontsManager.getFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getFonts--) metódust a prezentációban használt betűtípusok lekérdezéséhez. Minden betűtípushoz adjon át egy [IFontData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontdata/) objektumot és a szükséges [FontStyleType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontstyletype/) értéket a [IFontsManager.getFontBytes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-) metódusnak. A metódus visszaadja a betűtípus adott stílusának bináris adatait, vagy `null`‑t, ha a kért betűtípus vagy stílus nem érhető el. Ne adjon át `null` eredményt a [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-) metódusnak, mivel ez a metódus bájt tömböt igényel.

[EmbeddingLevel](https://reference.aspose.com/slides/hu/java/com.aspose.slides/embeddinglevel/) egy zászló enumeráció, amely a betűtípusba tárolt beágyazási korlátozásokat jelzi:

- `Installable` engedélyezi a beágyazást és a tartós telepítést egy másik rendszeren, a betűtípus licencétől függően.
- `Restricted` tiltja a beágyazást, hacsak nem szerez engedélyt a betűtípus jogtulajdonosától, ha ez az egyetlen használati‑engedély zászló.
- `PreviewPrint` ideiglenes használatot enged a megtekintéshez és nyomtatáshoz; a betűtípust tartalmazó dokumentumnak csak olvashatónak kell lennie.
- `Editable` ideiglenes használatot enged és lehetővé teszi a dokumentum szerkesztését és mentését.
- `NoSubsetting` egy további korlátozás, amely megtiltja a betűtípus csak egy részhalmazának beágyazását. Ha ez a zászló jelen van, az összes karaktert be kell ágyazni.
- `BitmapOnly` egy további korlátozás, amely csak bitmap (raszteres) betűtípust enged beágyazni, nem az outline (váz) adatot. Ha a betűtípusnak nincsenek bitmap változatai, nem lehet beágyazni.

Az első négy érték a használati engedélyt írja le, míg a `NoSubsetting` és a `BitmapOnly` kombinálható velük. A módosítókat bitműveletekkel ellenőrizze. Mivel az `Installable` értéke nulla, maszkolja a használati engedély biteket, és hasonlítsa össze az eredményt az `Installable`‑lel, ahelyett, hogy zászlóként ellenőrizné. A jelenlegi betűtípusoknak legfeljebb egy használati engedély bitet kell beállítaniuk. Az idősebb, több bitet beállító betűtípusok kompatibilitása érdekében az alábbi segédprogram a legkevésbé korlátozó engedélyt választja: `Editable`, majd `PreviewPrint`, végül `Restricted`.

Az alábbi példa ellenőrzi a `getFonts` által visszaadott minden betűtípushoz elérhető normál, félkövér, dőlt és félkövér‑dőlt adatokat. Kihagyja a nem elérhető stílusokat, a korlátozott betűtípusokat, a csak bitmap betűtípusokat, a csak előnézetre és nyomtatásra korlátozott betűtípusokat, mivel a kimenet szerkeszthető marad, valamint a már beágyazott betűtípusokat. Ha bármely elérhető stílus rendelkezik `NoSubsetting`‑tel, beágyazza az összes karaktert az adott betűtípuscsaládhoz.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.EmbeddingLevel;
import com.aspose.slides.FontStyleType;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;

class EmbeddingPermission {
    int getUsagePermission(int level) {
        int permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
        int permissions = level & permissionMask;

        if ((permissions & EmbeddingLevel.Editable) != 0) {
            return EmbeddingLevel.Editable;
        }

        if ((permissions & EmbeddingLevel.PreviewPrint) != 0) {
            return EmbeddingLevel.PreviewPrint;
        }

        if ((permissions & EmbeddingLevel.Restricted) != 0) {
            return EmbeddingLevel.Restricted;
        }

        return EmbeddingLevel.Installable;
    }
}

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    int[] fontStyles = {
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic
    };

    Set<String> embeddedFontNames = new HashSet<String>();
    for (IFontData embeddedFont : fontsManager.getEmbeddedFonts()) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    EmbeddingPermission permissionHelper = new EmbeddingPermission();
    List<IFontData> fontsToEmbed = new ArrayList<IFontData>();
    List<Integer> embeddingRules = new ArrayList<Integer>();
    for (IFontData font : fontsManager.getFonts()) {
        if (embeddedFontNames.contains(font.getFontName().toLowerCase(Locale.ROOT))) {
            System.out.println(font.getFontName() + ": already embedded.");
            continue;
        }

        boolean hasAvailableData = false;
        boolean allAvailableStylesCanBeEmbedded = true;
        boolean previewPrintOnly = false;
        boolean requiresFullFont = false;

        for (int fontStyle : fontStyles) {
            byte[] fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes == null) {
                System.out.println(font.getFontName() + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            int embeddingLevel = fontsManager.getFontEmbeddingLevel(fontBytes, font.getFontName());
            int usagePermission = permissionHelper.getUsagePermission(embeddingLevel);
            boolean noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
            boolean bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

            requiresFullFont |= noSubsetting;
            previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

            System.out.println(font.getFontName() + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            System.out.println(font.getFontName() + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            System.out.println(font.getFontName() + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            System.out.println(font.getFontName() + ": skipped because this example produces an editable presentation.");
        } else {
            int rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.add(font);
            embeddingRules.add(rule);
        }
    }

    for (int i = 0; i < fontsToEmbed.size(); i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed.get(i), embeddingRules.get(i));
    }

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ez az ellenőrzés jelentései a betűtípusfájlokban kódolt korlátozásokat. Nem ad licencet, nem bizonyítja, hogy a betűtípust legálisan szerezte be, és nem helyettesíti a betűtípus licencszerződésének ellenőrzését a beágyazott másolat terjesztése előtt.

## **Beágyazott betűtípusok hozzáadása**

Használja a [addEmbeddedFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) metódust egy betűtípus beágyazásához. A túlterhelései elfogadnak egy [IFontData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontdata/) objektumot vagy a betűtípus adatot tartalmazó bájt tömböt. Az [EmbedFontCharacters](https://reference.aspose.com/slides/hu/java/com.aspose.slides/embedfontcharacters/) enumeráció szabályozza, hogy mely karakterek legyenek belefoglalva:

- [All](https://reference.aspose.com/slides/hu/java/com.aspose.slides/embedfontcharacters/) beágyazza a betűtípus összes karakterét. Ezt a lehetőséget használja, ha a címzetteknek szerkeszteniük kell a prezentációt és új szöveget kell beírniuk.
- [OnlyUsed](https://reference.aspose.com/slides/hu/java/com.aspose.slides/embedfontcharacters/) csak a prezentációban használt karaktereket ágyazza be a fájlméret csökkentése érdekében. Válassza ezt a lehetőséget egy kész prezentációhoz, amely elsősorban megtekintésre szolgál.

Az alábbi példa a [getFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getFonts--) metódust használja a `Fonts.pptx` fájlban használt betűtípusok lekérdezéséhez, és beágyazza azokat, amelyek még nincsenek beágyazva. A hozzáadandó betűtípusoknak elérhetőnek kell lenniük a kódot futtató gépen. A már létező beágyazott betűtípusok megőrzik aktuális karakterkészletüket.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] allFonts = fontsManager.getFonts();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();
    Set<String> embeddedFontNames = new HashSet<String>();

    for (IFontData embeddedFont : embeddedFonts) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    for (IFontData font : allFonts) {
        String fontName = font.getFontName().toLowerCase(Locale.ROOT);
        if (!embeddedFontNames.contains(fontName)) {
            fontsManager.addEmbeddedFont(font, EmbedFontCharacters.All);
            embeddedFontNames.add(fontName);
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Beágyazott betűtípusok tömörítése**

A [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) a beágyazott betűtípus‑adatot csökkenti a nem használt karakterek eltávolításával. Már beágyazott betűtípusokon működik, így a méretcsökkentés attól függ, mennyi fel nem használt betűtípus‑adatot tartalmaz a prezentáció.

Az alábbi példa tömöríti a `EmbeddedFonts.pptx` fájl betűtípusait, és az eredményt külön fájlként menti:

```java
import com.aspose.slides.Compress;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tartsa meg az eredeti fájlt, ha a címzettek később szöveget kell hozzáadniuk. A tömörítés során eltávolított karakterek már nem állnak rendelkezésre a beágyazott betűtípusból, még akkor sem, ha eredetileg az összes karaktert beágyazta.

## **GYIK**

**Hogyan ellenőrizhetem, hogy egy beágyazott betűtípus továbbra is helyettesítésre kerül-e a megjelenítés során?**

Hívja meg a [getSubstitutions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) metódust abban a környezetben, ahol a prezentációt megjeleníti, hogy lássa, mely betűtípusokat cseréli le az Aspose.Slides. Ellenőrizze a [font substitution](/slides/hu/java/font-substitution/) beállításokat és a [font fallback](/slides/hu/java/fallback-font/) szabályokat is. A fallback kezeli a hiányzó karaktereket, így a betűtípus beágyazása nem oldja meg azokat a karaktereket, amelyeket a betűtípus önmagában nem tartalmaz.

**Be kellene-e ágyazni általános betűtípusokat, például az Arial‑t és a Calibri‑t?**

A döntést a célkörnyezet alapján hozza meg. Ha a szükséges betűtípusok minden gépen elérhetők, amely megnyitja vagy megjeleníti a prezentációt, a beágyazás felesleges fájlméret növekedést eredményezhet. Ha a címzettek vagy a szerverek esetleg nem rendelkeznek ezekkel a betűtípusokkal, a beágyazás segíthet megőrizni a kívánt megjelenést, amennyiben a licencük ezt engedélyezi.