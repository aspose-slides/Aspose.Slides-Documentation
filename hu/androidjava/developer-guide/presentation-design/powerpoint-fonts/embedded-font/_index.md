---
title: Betűkészletek beágyazása prezentációkba Androidon
linktitle: Beágyazott betűkészletek
type: docs
weight: 40
url: /hu/androidjava/embedded-font/
keywords:
- betűkészlet hozzáadása
- betűkészlet beágyazása
- betűkészlet beágyazás
- beágyazott betűkészlet lekérése
- beágyazott betűkészlet hozzáadása
- beágyazott betűkészlet eltávolítása
- beágyazott betűkészlet tömörítése
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Kezelje a beágyazott betűkészleteket PowerPointban az Aspose.Slides for Android via Java segítségével. Adjon hozzá, kérje le, távolítsa el és tömörítse a betűkészleteket a szöveg megjelenésének megőrzése és a fájlméret csökkentése érdekében."
---
## **Bevezetés**

A betűkészletek beágyazása betűkészlet‑adatokat tárol a PowerPoint‑prezentációban. Ha a megjelenítő támogatja a beágyazott betűkészleteket, meg tudja jeleníteni a szöveget a betűkkel még akkor is, ha azok nincsenek telepítve a célrendszeren. Ez segít megőrizni a sortöréseket, a szöveg távolságait és a dia elrendezését.

Az Aspose.Slides for Android via Java lehetővé teszi a beágyazott betűkészletek lekérését, hozzáadását és eltávolítását az [IFontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsmanager/) felületen keresztül, amelyet a [Presentation.getFontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getFontsManager--) ad vissza. Emellett csökkentheti a beágyazott betűkészlet‑adat méretét az olyan karakterek eltávolításával, amelyeket a prezentáció nem használ.

Az alábbi példák PPTX fájlokkal működnek. Betűkészlet beágyazása előtt győződjön meg arról, hogy a betűkészlet‑adatai elérhetők az Aspose.Slides számára, és a licenc lehetővé teszi a beágyazást.

## **Beágyazott betűkészletek lekérése és eltávolítása**

Használja a [getEmbeddedFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) metódust a prezentációban tárolt betűkészletek listázásához. Egy betűkészlet eltávolításához adja át a listából a betűkészletet a [removeEmbeddedFont](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) metódusnak, majd mentse a prezentációt.

Az alábbi példa listázza a beágyazott betűkészleteket a `EmbeddedFonts.pptx` fájlban, és eltávolítja a Calibrít, ha jelen van:

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

Egy beágyazott betűkészlet eltávolítása törli a tárolt betűkészlet‑adatokat; nem módosítja a szöveghez rendelt betűtípust. Ha a betűkészlet telepítve van a célrendszeren, a szöveg továbbra is használhatja. Ellenkező esetben a rendereléshez [betűtípus helyettesítés](/slides/hu/androidjava/font-substitution/) lehet szükséges, ami befolyásolhatja az elrendezést.

## **Betűkészlet‑adatok és beágyazási engedélyek ellenőrzése**

Használja az [IFontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsmanager/) felületet a betűkészletek beágyazás előtti ellenőrzéséhez. Hívja meg a [IFontsManager.getFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) metódust a prezentációban használt betűkészletek lekéréséhez. Minden egyes betűkészlethez adjon át egy [IFontData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontdata/) objektumot és a szükséges [FontStyleType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontstyletype/) értéket a [IFontsManager.getFontBytes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-) metódusnak. A metódus visszaadja a betűkészlet stílusának bináris adatait, vagy `null`‑t, ha a kért betűkészlet vagy stílus nem érhető el. Ne adjon át `null` eredményt a [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-) metódusnak, mivel ez a metódus byte‑tömböt igényel.

[EmbeddingLevel](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/embeddinglevel/) egy zászló‑enumeráció, amely a betűkészletben tárolt beágyazási korlátozásokat jelzi:

- `` `Installable` `` engedélyezi a beágyazást és a tartós telepítést egy másik rendszeren, a betűkészlet licencétől függően.
- `` `Restricted` `` tiltja a beágyazást, kivéve ha a betűkészlet jogtulajdonosától engedélyt kapunk, amikor ez az egyetlen használati‑engedély zászló.
- `` `PreviewPrint` `` engedélyezi az ideiglenes használatot megtekintéshez és nyomtatáshoz; a betűkészletet tartalmazó dokumentum csak olvasásra van korlátozva.
- `` `Editable` `` engedélyezi az ideiglenes használatot, és lehetővé teszi a dokumentum szerkesztését és mentését.
- `` `NoSubsetting` `` további korlátozás, amely megtiltja a csak a glifek részhalmazának beágyazását. Ha ez a zászló jelen van, minden karaktert be kell ágyazni.
- `` `BitmapOnly` `` további korlátozás, amely csak bitmap‑változatok beágyazását engedélyezi, nem az outline adatot. Ha a betűkészletnek nincs bitmap változata, nem ágyazható be.

Az első négy érték a használati engedélyt írja le, míg a `` `NoSubsetting` `` és `` `BitmapOnly` `` ezekhez kombinálható. Ellenőrizze a módosítókat bitműveletekkel. Mivel a `` `Installable` `` nulla, maszkolja a használati‑engedély biteket, és hasonlítsa össze az eredményt a `` `Installable` `` értékével ahelyett, hogy zászlóként ellenőrizné. A jelenlegi betűkészleteknek legfeljebb egy használati‑engedély bitet kell beállítaniuk. A régebbi, több bitet beállító betűkészletekkel való kompatibilitás érdekében az alábbi segédfüggvény a legkevésbé korlátozó engedélyt választja: `` `Editable` ``, majd `` `PreviewPrint` ``, majd `` `Restricted` ``.

Az alábbi példa auditálja a normál, félkövér, dőlt és félkövér‑dőlt adatokat minden betűkészlethez, amelyet a `getFonts` visszaad. Kihagyja a nem elérhető stílusokat, a korlátozott betűkészleteket, a csak bitmap‑betűkészleteket, a megtekintésre és nyomtatásra korlátozott betűkészleteket, mivel a kimenet szerkeszthető marad, valamint a már beágyazott betűkészleteket. Ha bármely elérhető stílus rendelkezik `` `NoSubsetting` `` értékkel, minden karaktert beágyaz a betűkészlet családhoz.

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

Ez az ellenőrzés jelentéseket készít a betűkészlet‑fájlokban kódolt korlátozásokról. Nem ad licencet, nem bizonyítja, hogy a betűkészletet jogszerűen szerezte be, és nem helyettesíti a betűkészlet licencszerződésének ellenőrzését a beágyazott másolat terjesztése előtt.

## **Beágyazott betűkészletek hozzáadása**

Használja a [addEmbeddedFont](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) metódust egy betűkészlet beágyazásához. A túlterhelései elfogadnak vagy egy [IFontData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontdata/) objektumot, vagy egy byte‑tömböt, amely a betűkészlet adatokat tartalmazza. Az [EmbedFontCharacters](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/embedfontcharacters/) enumeráció határozza meg, mely karakterek legyenek belefoglalva:

- [All](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/embedfontcharacters/) embeds all characters in the font. Use this option when recipients need to edit the presentation and enter new text.
- [OnlyUsed](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/embedfontcharacters/) embeds only the characters used in the presentation to reduce file size. Choose this option for a finished presentation that is primarily intended for viewing.

Az alábbi példa a [getFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) metódust használja a `Fonts.pptx` fájlban használt betűkészletek lekérésére, és beágyazza azokat, amelyek még nincsenek beágyazva. A hozzáadandó betűkészleteknek elérhetőnek kell lenniük az Android‑eszközön vagy regisztrálva kell lenniük az Aspose.Slides‑ben. A már létező beágyazott betűkészletek megtartják a jelenlegi karakterkészletüket.

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

## **Beágyazott betűkészletek tömörítése**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) csökkenti a beágyazott betűkészlet‑adatokat a nem használt karakterek eltávolításával. Már beágyazott betűkészleteken működik, így a méretcsökkentés a prezentációban található nem használt betűkészlet‑adat mennyiségétől függ.

Az alábbi példa tömöríti a `EmbeddedFonts.pptx` betűkészleteit, és a eredményt külön fájlba menti:

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

Tartsa meg az eredeti fájlt, ha a címzetteknek később szöveget kell hozzáadniuk. A tömörítés során eltávolított karakterek már nem elérhetőek a beágyazott betűkészletből, még akkor sem, ha eredetileg az összes karaktert beágyazta.

## **GYIK**

**Hogyan ellenőrizhetem, hogy egy beágyazott betűkészlet továbbra is helyettesítésre kerül-e a renderelés során?**

Hívja meg a [getSubstitutions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) metódust abban a környezetben, ahol a prezentációt rendereli, hogy lássa, mely betűkészleteket cseréli le az Aspose.Slides. Ellenőrizze továbbá a [betűtípus helyettesítés](/slides/hu/androidjava/font-substitution/) beállításokat és a [betűkészlet helyettesítő](/slides/hu/androidjava/fallback-font/) szabályokat. A fallback kezeli a hiányzó karaktereket, így egy betűkészlet beágyazása nem oldja meg azokat a karaktereket, amelyeket a betűkészlet maga sem tartalmaz.

**Érdemes-e általános betűkészleteket, például az Arial‑t és a Calibri‑t beágyazni?**

A döntést a célkörnyezet alapján hozza meg. Ha a szükséges betűkészletek minden olyan eszközön elérhetők, amely megnyitja vagy rendereli a prezentációt, a beágyazás csak felesleges fájlméretet adhat hozzá. Ha a címzettek vagy szerverek esetleg nem rendelkeznek ezekkel a betűkészletekkel, a beágyazás segíthet megőrizni a kívánt megjelenést, feltéve hogy a licencek lehetővé teszik.