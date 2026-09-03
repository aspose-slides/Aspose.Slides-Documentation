---
title: Bemutató figyelmeztetések kezelése Node.js‑ben
type: docs
weight: 90
url: /hu/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- figyelmeztetési visszahívás
- figyelmeztetési szabályzat
- adatvesztés
- forrássérülés
- kompatibilitási probléma
- betűtípus helyettesítés
- digitális aláírás
- bemutató betöltése
- bemutató megjelenítése
- bemutató konvertálása
- bemutató mentése
- PowerPoint
- OpenDocument
- JavaScript
- Node.js
- Aspose.Slides
description: "Ismerje meg, hogyan gyűjtsön, osztályozzon és kezeljen figyelmeztetéseket a bemutatók betöltése, megjelenítése, konvertálása és mentése során az Aspose.Slides for Node.js Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides jelentheti a helyreállítható problémákat, amikor betölt, megjelenít, konvertál vagy ment egy bemutatót. Példák a sérült forrásrekordokra, a megőrizhetetlen tartalomra, a betűtípus helyettesítésére és a célformátum korlátaira. A figyelmeztetési visszahívás lehetővé teszi, hogy az alkalmazás rögzítse ezeket a feltételeket, és döntse el, hogy a jelenlegi művelet folytatódhat-e.

Használja a `java.newProxy`-t az [IWarningCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarningcallback/) Java interfész megvalósításához JavaScriptben, és vizsgálja meg a [getWarningType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarninginfo/#getWarningType--) és a [getDescription](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarninginfo/#getDescription--) értékeket, amelyeket az [IWarningInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarninginfo/) szolgáltat. Adja vissza a [ReturnAction.Continue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/returnaction/#Continue) értéket a figyelmeztetés elfogadásához, vagy a [ReturnAction.Abort](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/returnaction/#Abort) értéket a művelet leállításához.

Használja a [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) metódust a bemutató megnyitása során keletkező figyelmeztetésekhez. A megjelenítési és exportálási opcióosztályok öröklik a [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) metódust, amely a dia megjelenítése, konvertálása és mentése közben érkező figyelmeztetéseket kapja. Mivel a figyelmezetés önmagában nem azonosítja az alkalmazás műveletét, a kombinált jelentés építésekor társítsa minden visszahívás‑példányt egy műveleti szakaszhoz.

## **Figyelmeztetések és Kivételek**

A figyelmeztetés egy olyan feltételt ír le, amelyből az Aspose.Slides helyreállíthat, ha a visszahívás `ReturnAction.Continue` értéket ad vissza. A kivétel azt jelenti, hogy a kért művelet nem fejezhető be normál módon; a kivételeket nem alakítják figyelmeztetésekké, és egy figyelmeztetési szabályzat nem tudja kezelni őket.

A `ReturnAction.Abort` visszaadása azt kéri a figyelmeztetés‑kezelőt, hogy a jelenlegi műveletet egy kivétel dobásával állítsa le. A nyilvános kivétel a művelettől és a bemutató formátumától függ. Például a betöltés során megjelenhet a [PptxReadException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxreadexception/) vagy a [PptReadException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptreadexception/), míg a mentés vagy exportálás során a [PptxException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxexception/) léphet fel. Ragadja meg a hibát a Java hídon a művelet határán, és használja a figyelmeztetési jelentést annak meghatározására, hogy az alkalmazás szabályzata okozta-e a leállást, ahelyett, hogy egyetlen kivétel alosztályra vagy üzenetre támaszkodna. A visszahívás a figyelmeztetést rögzíti a `ReturnAction.Abort` visszaadása előtt, biztosítva, hogy az ok elérhető maradjon az alkalmazás számára.

## **Figyelmeztetési Kategóriák**

A [WarningType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/warningtype/) osztály egész számú konstansokat biztosít a következő kategóriákhoz:

| Figyelmeztetés típusa | Jelentés | Tipikus szabályzat |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | A forrásbemutató sérülést tartalmaz, amely azt okozhatja, hogy az eredeti formátumban mentett dokumentum használhatatlanná válik. | Megszakítás. |
| [DataLoss](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/warningtype/#DataLoss) | Szöveg, diagramok, képek vagy egyéb adatok hiányozhatnak a betöltés vagy mentés után. | Megszakítás. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | A bemutató elveszítheti a fontos formázásokat. | Megszakítás szigorú validálási módban; egyébként rögzítés és folytatás. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | Korlátozott formázási eltérés léphet fel. | Rögzítés diagnosztikához és folytatás. |
| [CompatibilityIssue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | Az eredmény egyes alkalmazásokban vagy régebbi verziókban esetleg nem nyílik meg, vagy nem működik helyesen. | Naplózás és folytatás, hacsak a kompatibilitás nem kötelező. |
| [UnexpectedContent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | A forrás nem támogatott vagy ismeretlen tartalmat tartalmaz, amelynek hatása még ismeretlen lehet. | Rögzítés és folytatás, vagy szigorú szabályzat esetén hibaként kezelése. |

A kategóriának kell irányítania a szabályzat döntését. Tárolja a [getDescription](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarninginfo/#getDescription--) által visszaadott értéket diagnosztikához, de ne függjön a szövegformulációtól az alkalmazáslogikában, mivel az üzenetszöveg az egyes figyelmeztetési helyzetek és a termékverziók között változhat.

## **Figyelmeztetések Gyűjtése és Osztályozása**

A következő JavaScript példa egy alkalmazásszintű jelentést használ a teljes feldolgozási csővezetékhez. Egy külön visszahívás‑példány jelöli a betöltés, megjelenítés, PDF‑konvertálás és PPTX‑mentés során keletkező figyelmeztetéseket. A szabályzat megállítja a műveletet forrás‑sérülés vagy adatvesztés esetén, opcionálisan megállítja a nagy formázási veszteség esetén, és a többi figyelmeztetésnél folytatja.

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

Adjon meg `false` értéket az `abortOnMajorFormattingLoss` paraméternek a `WarningPolicy` létrehozásakor, ha a nagy formázási eltérések elfogadhatóak. A kompatibilitási problémák, a kisebb formázási veszteség és a nem várt tartalom továbbra is megmarad a jelentésben, még ha a művelet folytatódik is. Bővítse a `WarningPolicy.getAction` metódust, ha az alkalmazásnak el kell utasítania bármelyik ilyen kategóriát.

## **Gyakori Figyelmeztetési Forgatókönyvek**

A figyelmeztetések a munkafolyamat különböző szakaszaiban jelentkezhetnek:

- **Digitális aláírások:** Egy aláírt bemutató betöltéskor figyelmeztetést adhat, hogy az aláírás a feldolgozás során elveszik. Az Aspose.Slides ezt a `DataLoss` állapotot az [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationsignedwarninginfo/) segítségével jelzi. A betöltési szakasz visszahívása lehetővé teszi az alkalmazásnak a fájl elutasítását vagy a jelzett adatvesztés kifejezett elfogadását.
- **Betűtípus helyettesítés:** Egy nem elérhető betűtípust helyettesíthetnek, amikor egy diát megjelenítenek vagy exportálnak. A betűtípus helyettesítési figyelmeztetéseket `DataLoss`‑ként jelzi, így a fenti szigorú szabályzat még akkor is megszakít, ha az alkalmazás a helyettesítést vizuálisan elfogadhatónak tartja. Ennek a viselkedésnek a megfigyeléséhez használjon egy bemeneti bemutatót, amely olyan betűtípust tartalmaz, amely nem érhető el a futtatókörnyezetről. A figyelmeztetés leírása azonosítja a helyettesítést; konfigurálja a szükséges betűtípusokat vagy a [betűtípus helyettesítési szabályokat](/slides/hu/nodejs-java/font-substitution/) a újbóli próbálkozás előtt.
- **Nem támogatott vagy nem várt tartalom:** Egy betöltő olyan prezentációs rekordokkal vagy funkciókkal találkozhat, amelyeket nem ismer fel. Ilyen figyelmeztetések használhatják a `UnexpectedContent`‑t, vagy súlyosabb kategóriát, ha adat vagy formázás ismert módon érintett.
- **Formátum kompatibilitás:** Egy másik prezentációformátumba való mentés elhagyhat funkciókat, vagy olyan eredményt hozhat létre, amely bizonyos alkalmazásokban másként viselkedik. Például, ha egy bemutató több mint nyolc vízszintes vagy nyolc függőleges rajzúj útmutatót tartalmaz, a régi PPT formátumba mentés `CompatibilityIssue`‑t jelent. A mentési szakasz visszahívása rögzítheti a veszteséget és folytathatja, vagy elutasíthatja, ha az összes útmutató megőrzése kötelező.
- **Betöltési viselkedés:** A betöltési beállítások és régi viselkedések is okozhatnak figyelmeztetéseket. Például az [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) a elavult prezentáció‑zárolási viselkedés használatát `CompatibilityIssue`‑ként azonosítja.

A figyelmeztetések a forrásdokumentumtól, a célformátumtól, a művelettől és az Aspose.Slides verziójától függenek. Ne feltételezze, hogy minden fájl figyelmeztetést eredményez, vagy hogy egy forgatókönyv mindig csak egy kategóriába tartozik.

## **Megszakított Műveletek Biztonságos Kezelése**

Ha egy visszahívás `ReturnAction.Abort` értéket ad vissza, ne használja a betöltése során sikertelen objektumot, és ne feltételezze, hogy a megjelenítési vagy mentési kimenet kész. A művelet befejeződhet egy kimeneti fájl létrehozása után, de a befejezés előtt.

Mentse a validált eredményeket egy külön útvonalra, például `validated-output.pptx`. Cserélje le a meglévő bemutatót csak akkor, ha a művelet sikeresen befejeződött, a figyelmeztetési jelentés megfelel az alkalmazás szabályzatának, és a kimenet megnyitható és ellenőrizhető. Ez megakadályozza, hogy egy érvényes forrásfájlt egy részleges vagy elutasított eredménnyel felülírja.

Az üres figyelmeztetési jelentés nem garancia arra, hogy minden forrásfunkció megmaradt. Alkalmazza az alkalmazás által megkövetelt további tartalom- és vizuális ellenőrzéseket. Lásd még a [Open Presentations](/slides/hu/nodejs-java/open-presentation/) és a [Save Presentations](/slides/hu/nodejs-java/save-presentation/) oldalakat.

## **GYIK**

**Kezelhet-e egy figyelmeztetési visszahívás minden Aspose.Slides hibát?**

Nem. Csak a figyelmeztetésként jelentett helyreállítható állapotokat kezeli. A visszahívástól függetlenül előforduló kivételeket az alkalmazásnak a betöltés, megjelenítés, konvertálás vagy mentés hívása körül kell kezelnie.

**Garantálja a `ReturnAction.Continue` visszaadása az azonos kimenetet?**

Nem. Csak azt engedélyezi, hogy a feldolgozás folytatódjon. A jelentett állapot továbbra is adat-, formázási vagy kompatibilitási eltéréseket okozhat, ezért tekintse át a gyűjtött figyelmeztetési típusokat és leírásokat.

**Hogyan tudja egy alkalmazás azonosítani azt a műveletet, amely a figyelmeztetést előidézte?**

Hozzon létre egy visszahívás‑példányt minden művelethez, és tárolja az alkalmazás által definiált szakaszt a [getWarningType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarninginfo/#getWarningType--) és a [getDescription](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarninginfo/#getDescription--) által visszaadott értékekkel együtt, ahogy a példában látható.