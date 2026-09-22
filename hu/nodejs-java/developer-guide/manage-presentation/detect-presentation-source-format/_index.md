---
title: Határozza meg az eredeti prezentáció formátumát Node.js-ben
linktitle: Forrásformátum
type: docs
weight: 35
url: /hu/nodejs-java/detect-presentation-source-format/
keywords:
- forrásformátum
- prezentáció formátumának felismerése
- PowerPoint
- OpenDocument
- prezentáció
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Olvassa el egy betöltött prezentáció eredeti formátumát Node.js-ben az Aspose.Slides for Node.js Java-n keresztül, hasonlítsa össze a felismerési API-kat, és kezelje a fájlokat, folyamokat és régi formátumokat."
---
## **Áttekintés**

Prezentáció betöltése után hívja meg a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getSourceFormat) metódust, hogy meghatározza az eredeti formátumát. Használja, ha a későbbi feldolgozás attól a formátumtól függ, amelyből a jelenlegi példány betöltődött.

A forrásformátum eltér a kimeneti fájlhoz kiválasztott [SaveFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveformat/) formátumtól. Egy másik formátumba mentés nem változtatja meg a meglévő példány forrásformátumát.

## **A fájl forrásformátumának olvasása**

Ez a példa egy meglévő `sample.pptx` fájlt igényel. Betölti a fájlt, és a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getSourceFormat) használatával választja ki az alkalmazás feldolgozási szabályát a fájlnév helyett. A bemeneti útvonalat módosítva kipróbálhat más formátumokat. A példa kiírja a kiválasztott szabályt; cserélje le az üzeneteket saját alkalmazáslogikájára.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **A támogatott értékek felismerése**

A [SourceFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sourceformat/) osztály egész számú konstansokat határoz meg, amelyek megkülönböztetik a következő prezentációformátumokat. Az alábbi kiterjesztések szokásos kiterjesztések, nem a fájl eredeti nevének rekonstrukciója.

| SourceFormat érték | Kiterjesztés | Formátum |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 bemutató |
| `Pptx` | `.pptx` | Office Open XML bemutató |
| `Pptm` | `.pptm` | Makróval bővített Office Open XML bemutató |
| `Pps` | `.pps` | PowerPoint 97–2003 diavetítés |
| `Ppsx` | `.ppsx` | Office Open XML diavetítés |
| `Ppsm` | `.ppsm` | Makróval bővített Office Open XML diavetítés |
| `Pot` | `.pot` | PowerPoint 97–2003 sablon |
| `Potx` | `.potx` | Office Open XML sablon |
| `Potm` | `.potm` | Makróval bővített Office Open XML sablon |
| `Odp` | `.odp` | OpenDocument bemutató |
| `Otp` | `.otp` | OpenDocument bemutató sablon |
| `Fodp` | `.fodp` | Flat XML ODF bemutató |
| `Xml` | `.xml` | PowerPoint XML bemutató |

## **A forrásformátum beolvasása folyamról**

Ez a példa egy meglévő `sample.pps` fájlt igényel. A bájtok memóriába történő beolvasása olyan bemenetet modellez, amely fájlnév nélkül érkezik, például adatbázisértékként vagy feltöltött byte tömbként. A [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) konstruktora csak a folyamot kapja meg.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

A PPT, PPS és POT azonos alapszintű bináris formátumot használnak. Fájlúton történő betöltéskor a kiterjesztés segíthet megkülönböztetni a diavetítést vagy sablont. Fájlnév nélkül a régi PPS és POT tartalom `SourceFormat.Ppt`‑ként jelenthető; a fenti PPS példa az `SourceFormat.Ppt` egész értékét írja ki.

Ha az alkalmazásnak meg kell tartania a különbséget, tartsa meg az eredeti fájlnevet vagy a részlet metaadatait külön. A kiterjesztés hasznos jelzés lehet ezekhez a régi alformátumokhoz, de nem szabad, hogy egyedüli alapja legyen a prezentáció tartalmának azonosításának.

## **Az észlelés összehasonlítása betöltés előtt és után**

Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) és a [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat) metódusokat, ha egy fájlt a teljes prezentációs objektummodel betöltése előtt kell vizsgálni. Használja a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getSourceFormat) metódust, ha a példány már létezik.

Ez a példa `sample.pptx`‑et igényel, és kiírja a `LoadFormat.Pptx` és a `SourceFormat.Pptx` egész értékeit. Éles környezetben válassza a feldolgozási szakaszának megfelelő API‑t; egy már betöltött prezentációnak nincs szüksége második vizsgálatra csak a forrásformátum lekéréséhez.

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Az eredmények különböző osztályok konstansaiból származnak: [LoadFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadformat/) és [SourceFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sourceformat/). Ne hasonlítsa össze a numerikus értékeket, és ne tételezze fel, hogy minden formátum azonos észlelési eredményt ad. A PowerPoint XML betöltés előtt `LoadFormat.Unknown`‑ként, betöltés után `SourceFormat.Xml`‑ként jelenthető.

## **A forrás- és a kimeneti formátumok szétválasztása**

Ez a példa `sample.pptx`‑et igényel, és `converted.odp`‑t ír. Kiírja a `SourceFormat.Pptx` egész értékét a mentés előtti és utáni állapotban is. Csak az ODP kimenetből betöltött új példány jelent `Odp`‑t.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Az `new Presentation()`‑ből nulláról létrehozott prezentáció `SourceFormat.Pptx`‑ként jelentkezik. Nincs bemeneti fájl: ez az alapértelmezett érték az újonnan létrehozott példány számára, nem bizonyítja, hogy PPTX fájlt töltöttek be. Kövesse nyomon, hogy az alkalmazás létrehozta vagy betöltötte a példányt, ha ez a megkülönböztetés fontos.

## **A forrásformátum leképezése kiterjesztésre**

A következő példa `sample.pptx`‑et igényel. Minden jelenleg támogatott [SourceFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sourceformat/) értéket leképez egy szokásos kiterjesztésre, a bemeneti fájlnév elemzése nélkül. A visszaesés megakadályozza, hogy egy fel nem ismert értékhez némahanggal kiterjesztést rendeljünk.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Ez a leképezés nem konvertál fájlt, és nem állítja vissza a folyam betöltése során elveszett régi PPS/POT alformátumot. Valódi mentéshez válasszon egy [SaveFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveformat/) értéket kifejezetten, vagy használja a [Save Presentations in Their Original Format](/slides/hu/nodejs-java/save-presentation/#save-presentations-in-their-original-format) példában bemutatott konverziót.

## **Formátumok ellenőrzése mentéssel és újranyitással**

Ez az önálló példa létrehoz egy prezentációt, és három fájlt ír a munkakönyvtárba, felülírva az azonos nevű fájlokat. Mindegyik kimenetet újra megnyitja úton és memóriában lévő folyamként is. PPTX és ODP esetén mindkét útvonal a mentett formátumot jelzi. PPS esetén az útvonallal történő betöltés `Pps`‑t, a fájlnév nélküli bájtok betöltése `Ppt`‑t jelent.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

| Mentett formátum | SourceFormat fájl útvonalból | SourceFormat névtelen folyamról |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` | Ugyanaz, mint a fájl útvonalból |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` | Ugyanaz, mint a fájl útvonalból |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` | Ugyanaz, mint a fájl útvonalból |
| ODP, OTP | `Odp`, `Otp` | Ugyanaz, mint a fájl útvonalból |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

A PPS/POT tartalom névtelen folyamok esetén `Ppt`‑ként azonosítható. A táblázat a formátum azonosítását írja le, nem a prezentáció minden tulajdonságának megőrzését konverzió közben.

## **GYIK**

**A PPTX‑ből betöltött prezentáció ODP‑be mentése megváltoztatja a forrásformátumot?**

Nem. A meglévő példány továbbra is `Pptx`‑ként jelentkezik. Az ODP‑be mentett fájlból betöltött példány `Odp`‑t jelent.

**Képes-e egy folyam mindig megkülönböztetni egy örökölt prezentációt, diavetítést és sablont?**

Nem. A PPT, PPS és POT ugyanazt a bináris formátumot osztják meg. Ha szükség van a megkülönböztetésre, tartsa meg a fájlnevet vagy a részlet metaadatait külön.

**Melyik API‑t kell használni, ha a prezentáció már betöltött?**

Olvassa el a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getSourceFormat) metódust. Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) metódust a betöltés előtti vizsgálathoz.