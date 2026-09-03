---
title: Betűkészletek beágyazása prezentációkba JavaScriptben
linktitle: Beágyazott betűkészletek
type: docs
weight: 40
url: /hu/nodejs-java/embedded-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Kezeld a beágyazott betűkészleteket a PowerPointban az Aspose.Slides for Node.js via Java segítségével. Adj hozzá, kérdezd le, távolítsd el és tömörítsd a betűkészleteket a szöveg megjelenésének megőrzése és a fájlméret csökkentése érdekében."
---
## **Bevezetés**

A betűkészletek beágyazása a betűkészlet‑adatokat a PowerPoint‑prezentáción belül tárolja. Ha egy megjelenítő támogatja a beágyazott betűkészleteket, akkor a szöveget azokkal a betűkészletekkel jelenítheti meg, még akkor is, ha a célrendszeren nincsenek telepítve. Ez segít megőrizni a sortöréseket, a szövegtávolságokat és a diaelrendezést.

Az Aspose.Slides for Node.js via Java lehetővé teszi a beágyazott betűkészletek lekérdezését, hozzáadását és eltávolítását a [FontsManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/) osztályon keresztül, amelyet a [Presentation.getFontsManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getfontsmanager/) metódus ad vissza. A beágyazott betűkészlet‑adat méretét is csökkentheted a prezentáció által nem használt karakterek eltávolításával.

Az alábbi példák PPTX fájlokkal működnek. A betűkészlet beágyazása előtt győződj meg arról, hogy a betűkészlet‑adatok elérhetők az Aspose.Slides számára, és a licenc lehetővé teszi a beágyazást.

## **Beágyazott betűkészletek lekérése és eltávolítása**

Használd a [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) metódust a prezentációban tárolt betűkészletek felsorolásához. Egy betűkészlet eltávolításához add át a listából a kívánt betűkészletet a [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/) metódusnak, majd mentse el a prezentációt.

Az alábbi példa felsorolja a `EmbeddedFonts.pptx` fájlban lévő beágyazott betűkészleteket, és eltávolítja a Calibrít, ha jelen van:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

A beágyazott betűkészlet eltávolítása a tárolt betűkészlet‑adatot távolítja el; nem változtatja meg a szöveghez rendelt betűtípust. Ha a betűkészlet telepítve van a célrendszeren, a szöveg továbbra is használhatja azt. Ellenkező esetben a megjelenítéshez szükség lehet [betűkészlet helyettesítésre](/slides/hu/nodejs-java/font-substitution/), ami befolyásolhatja az elrendezést.

## **Betűkészlet‑adatok és beágyazási engedélyek vizsgálata**

Használd a [FontsManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/) osztályt a betűkészletek beágyazása előtti vizsgálatához. A prezentációban használt betűkészletek lekéréséhez hívd a [FontsManager.getFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/getfonts/) metódust. Minden betűkészlethez add át egy [FontData](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontdata/) objektumot és a szükséges [FontStyleType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontstyletype/) értéket a [FontsManager.getFontBytes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/#getFontBytes) metódusnak. A metódus a betűkészlet stílusához tartozó bináris adatot adja vissza, vagy `null`‑t, ha a kért betűkészlet vagy stílus nem érhető el. Ne add át a `null` eredményt a [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel) metódusnak, mivel ez a metódus byte tömböt igényel. Node.js‑ben konvertáld a visszakapott JavaScript tömböt Java byte tömbbé a `java.newArray` segítségével, mielőtt átadnád a `getFontEmbeddingLevel`‑nek.

Az [EmbeddingLevel](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/embeddinglevel/) jelenti a betűkészletben tárolt beágyazási korlátozásokat jelző zászlók halmazát:

- `Installable` hozzáférést biztosít a beágyazáshoz és a másik rendszerbe történő állandó telepítéshez, a betűkészlet licencétől függően.
- `Restricted` megtiltja a beágyazást, kivéve ha a betűkészlet jogtulajdonosától engedélyt kap, ha ez az egyetlen használati engedély zászló.
- `PreviewPrint` átmeneti használatot engedélyez megtekintésre és nyomtatásra; a betűkészletet tartalmazó dokumentumnak csak olvashatónak kell lennie.
- `Editable` átmeneti használatot engedélyez, és lehetővé teszi a dokumentum szerkesztését és mentését.
- `NoSubsetting` további korlátozás, amely megtiltja a betűkészlet csak részhalmazának beágyazását. Ha ez a zászló jelen van, az összes karaktert be kell ágyazni.
- `BitmapOnly` további korlátozás, amely csak bitmap változatok beágyazását engedélyezi, nem pedig a kontúr adatokat. Ha a betűkészletnek nincs bitmap változata, nem ágyazható be.

Az első négy érték a használati engedélyt írja le, míg a `NoSubsetting` és a `BitmapOnly` ezekkel kombinálható. A módosítókat bitenkénti műveletekkel ellenőrizd. Mivel az `Installable` értéke nulla, maszkolni kell a használati engedély biteket, és az eredményt az `Installable`‑lel kell összehasonlítani, ahelyett, hogy zászlóként ellenőriznéd. A jelenlegi betűkészleteknek legfeljebb egy használati engedély bitet kell beállítaniuk. A régebbi, több bitet állító betűkészletekkel való kompatibilitás érdekében az alábbi segédfüggvény a legkevésbé szigorú engedélyt választja: először `Editable`, aztán `PreviewPrint`, végül `Restricted`.

Az alábbi példa áttekinti a `getFonts` által visszaadott minden betűkészlethez elérhető normál, félkövér, dőlt és félkövér‑dőlt adatokat. Kihagyja a nem elérhető stílusokat, a korlátozott betűkészleteket, a csak bitmap változatot tartalmazó betűkészleteket, a csak megtekintésre és nyomtatásra korlátozott betűkészleteket, mivel a kimenet szerkeszthető marad, valamint a már beágyazott betűkészleteket. Ha bármely elérhető stílus rendelkezik `NoSubsetting` zászlóval, akkor az összes karaktert beágyazza az adott betűkészletcsaládhoz.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ez a vizsgálat a betűkészletfájlokban kódolt korlátozásokat jelzi. Nem ad licencet, nem bizonyítja, hogy a betűkészletet jogszerűen szerezted be, és nem helyettesíti a betűkészlet licencszerződésének ellenőrzését a beágyazott másolat terjesztése előtt.

## **Beágyazott betűkészletek hozzáadása**

Használd a [FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/) metódust egy betűkészlet beágyazásához. A túlterhelései vagy egy [FontData](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontdata/) objektumot, vagy a betűkészlet‑adatot tartalmazó byte‑tömböt fogadnak. Az [EmbedFontCharacters](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/embedfontcharacters/) szabályozza, hogy mely karakterek legyenek belefoglalva:

- `All` beágyazza a betűkészlet összes karakterét. Ezt a lehetőséget használd, amikor a címzetteknek szerkeszteniük kell a prezentációt és új szöveget kell beírniuk.
- `OnlyUsed` csak a prezentációban használt karaktereket ágyazza be, a fájlméret csökkentése érdekében. Válaszd ezt a lehetőséget egy kész prezentációhoz, amely elsősorban megtekintésre szolgál.

Az alábbi példa a [FontsManager.getFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/getfonts/) metódust használja a `Fonts.pptx` fájlban használt betűkészletek lekéréséhez, és beágyazza azokat, amelyek még nincsenek beágyazva. A hozzáadandó betűkészleteknek elérhetőnek kell lenniük azon a gépen, amelyen a kód fut. A meglévő beágyazott betűkészletek megtartják aktuális karakterkészletüket.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Beágyazott betűkészletek tömörítése**

A [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/compressembeddedfonts/) eltávolítja a nem használt karaktereket, csökkentve a beágyazott betűkészlet adatát. Már beágyazott betűkészleteken működik, így a méretcsökkenés a prezentációban lévő nem használt betűkészlet‑adat mennyiségétől függ.

Az alábbi példa tömöríti a `EmbeddedFonts.pptx` fájlban lévő betűkészleteket, és a végeredményt egy külön fájlba menti:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tartsd meg az eredeti fájlt, ha a címzettek később szöveget szeretnének hozzáadni. A tömörítés során eltávolított karakterek már nem érhetők el a beágyazott betűkészletből, még akkor sem, ha eredetileg minden karaktert beágyaztál.

## **GYIK**

**Hogyan ellenőrizhetem, hogy egy beágyazott betűkészlet továbbra is helyettesítésre kerül-e a megjelenítés során?**

Hívd meg a [FontsManager.getSubstitutions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) metódust abban a környezetben, ahol a prezentációt rendereled, hogy láthasd, mely betűkészleteket fogja az Aspose.Slides helyettesíteni. Ellenőrizd továbbá a [betűkészlet helyettesítés](/slides/hu/nodejs-java/font-substitution/) beállításokat és a [betűkészlet tartalék](/slides/hu/nodejs-java/fallback-font/) szabályokat. A tartalék kezeli a hiányzó karaktereket, így egy betűkészlet beágyazása nem oldja meg azokat a karaktereket, amelyeket a betűkészlet maga nem tartalmaz.

**Be kellene ágyaznom gyakori betűkészleteket, például az Arial‑t és a Calibri‑t?**

A döntést a célkörnyezet alapján hozd meg. Ha a szükséges betűkészletek minden olyan gépen elérhetők, amely megnyitja vagy rendereli a prezentációt, a beágyazás felesleges fájlméret‑növekedést okozhat. Ha a címzettek vagy a szerverek esetleg nem rendelkeznek ezekkel a betűkészletekkel, a beágyazás segíthet megőrizni a kívánt megjelenést, feltéve hogy a licencük ezt megengedi.