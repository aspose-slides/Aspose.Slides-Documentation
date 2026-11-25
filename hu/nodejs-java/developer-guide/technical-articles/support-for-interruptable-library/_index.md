---
title: Hosszú futási idejű prezentációs műveletek megszakítása Node.js-ben
linktitle: Prezentációs műveletek megszakítása
type: docs
weight: 120
url: /hu/nodejs-java/support-for-interruptable-library/
keywords:
- megszakítható műveletek
- megszakítási token
- lemondási token
- konverziós időkorlát
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Szakítsa meg a hosszú futási idejű prezentációs műveleteket az Aspose.Slides for Node.js via Java könyvtárban, állítson be konverziós időkorlátot, és kövesse nyomon a megszakítás előtt exportált diák számát."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java támogatja a megszakítást a prezentáció betöltése, mentése vagy renderelése közben. Ugyanezt a tokent a saját exportciklusában is ellenőrizheti, hogy megálljon a következő dia előtt, és visszaadja a már mentett diák számát.

## **Prezentáció művelet megszakítása**

Hozzon létre egy [InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/), szerezze meg a tokenjét a [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken) segítségével, és adja át a [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken) metódusnak. Ezeket a beállításokat használja a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) létrehozásakor. A [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) meghívása a forráson a jelenlegi művelet megszakítását kéri. Az Aspose.Slides akkor áll le, amikor legközelebb ellenőrzi a tokent.

### **Átalakítási időkorlát beállítása**

Az alábbi példa 20 másodpercet enged a `sample.pptx` megnyitására és a `sample.pdf` mentésére. A konstruktor és a mentés is aszinkron módon fut a Java hídon keresztül, így a Node.js időzítő mindkét művelet közben aktiválódhat. A példa a token ellenőrzését elvégzi a betöltés után és a mentés után is, mivel egy könyvtári hívás a megszakítási kérés után is visszatérhet. A prezentációt felszabadítja, amikor a művelet befejeződik, és törli az időzítőt, ha a konverzió korábban befejeződik. Ha a mentés közben megszakítás történik, a kimeneti fájl már létezhet, és lehet, hogy hiányos.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const { promisify } = require("node:util");

async function convertWithTimeout(inputPath, outputPath, format, timeoutMs) {
    const source = new slides.InterruptionTokenSource();
    const options = new slides.LoadOptions();
    const token = source.getToken();
    options.setInterruptionToken(token);
    const createInstance = promisify(java.newInstance.bind(java));
    const timer = setTimeout(() => source.interrupt(), timeoutMs);
    let presentation = null;
    try {
        presentation = await createInstance("com.aspose.slides.Presentation", inputPath, options);
        token.throwIfInterruptionRequested();
        const save = promisify(presentation.saveAsync.bind(presentation));
        await save(outputPath, format);
        token.throwIfInterruptionRequested();
        console.log("Conversion completed");
    } catch (error) {
        if (error.cause?.getClass().getName() !== "com.aspose.slides.exceptions.OperationCanceledException") {
            throw error;
        }
        console.log("Conversion canceled");
    } finally {
        clearTimeout(timer);
        if (presentation) {
            presentation.dispose();
        }
    }
}

convertWithTimeout("sample.pptx", "sample.pdf", slides.SaveFormat.Pdf, 20000).catch(error => {
    console.error(error);
    process.exitCode = 1;
});
```

A régebbi PowerPoint formátumba 10 másodperces határidővel való konvertáláshoz adja át a `"sample.ppt"`, `slides.SaveFormat.Ppt` és `10000` értékeket az utolsó három paraméterként.

## **Állj meg a következő dia feldolgozása előtt**

Használja a [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) metódust minden exportálás előtt, ha a hívó részleges eredményt tud felhasználni. A [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) túlterhelése a kiválasztott diákhoz Java `int[]` típusú dia‑számokat vár, amely 1‑től kezdődik. Minden számot csak akkor rögzítsen, miután a PDF sikeresen mentésre került.

Futtassa a példát egy `sample.pptx` nevű prezentációval, amely legalább két diát tartalmaz. A példában a megszakítási kérés az első dia mentése után azonnal megtörténik, hogy bemutassa a exportok közötti megszakítást.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function exportSlides(path, source) {
    const completed = [];
    const token = source.getToken();
    const options = new slides.LoadOptions();
    options.setInterruptionToken(token);
    const presentation = new slides.Presentation(path, options);
    try {
        const count = presentation.getSlides().size();
        for (let number = 1; number <= count; number++) {
            if (token.isInterruptionRequested()) {
                break;
            }

            console.log("Starting slide " + number);
            const selection = java.newArray("int", [number]);
            try {
                presentation.save("slide-" + number + ".pdf", selection, slides.SaveFormat.Pdf);
            } catch (error) {
                if (error.cause?.getClass().getName() === "com.aspose.slides.exceptions.OperationCanceledException") {
                    break;
                }
                throw error;
            }

            if (token.isInterruptionRequested()) {
                break;
            }
            completed.push(number);
            if (number === 1) {
                source.interrupt();
            }
        }
        return completed;
    } finally {
        presentation.dispose();
    }
}

const source = new slides.InterruptionTokenSource();
const completed = exportSlides("sample.pptx", source);
console.log("Completed: " + JSON.stringify(completed));
```

A példa `slide-1.pdf`‑t ír és a `Starting slide 1` üzenetet, majd a `Completed: [1]` szöveget írja ki. A ciklus a 2. dia indítása előtt észleli a megszakítást. Ha a mentés maga megszakad, a visszaadott lista csak a korábban sikeresen exportált fájlokat tartalmazza.

Ahhoz, hogy a hívó a megszakítást hibaként kezelje, cserélje le a ciklus elején lévő ellenőrzést és a `break`‑et a [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) meghívására, `token.throwIfInterruptionRequested()` formában. Használja ugyanezt a dobó ellenőrzést a mentés után, és távolítsa el a `try`/`catch` blokkot körülötte. Ugyanazzal a bemenettel az első PDF továbbra is mentésre kerül, a második iteráció pedig a függvény lista visszaadása előtt dobásra kerül.

## **GYIK**

**Mikor kell kérni a megszakítást?**

Kérjen megszakítást, ha a határidő lejár vagy az alkalmazás már nem igényli az eredményt. A betöltés, mentés és renderelés mind használhatja a prezentáció létrehozásakor átadott tokent.

**Miben különbözik a forrás és a token?**

A forrás lehetővé teszi az alkalmazás számára a megszakítás kérését. A token pedig az Aspose.Slides‑nek és az ön saját kódjának adja meg a lehetőséget, hogy ellenőrizze a kérést.

**Meg tudja szakítani egy Node.js időzítő a szinkron mentést?**

A szinkron mentés blokkolja a JavaScript‑et a hívó szálon. Használja a timeout példában bemutatott aszinkron Java híd hívásokat, hogy az időzítő a mentés futása közben kérhesse a megszakítást.

**Azonnal életbe lép a megszakítás?**

A megszakítás együttműködésen alapul. A futó művelet akkor áll le, amikor észleli a kérést. A már befejezett művelet megtartja az eredményét.

**Több művelet is megoszthat egy forrást?**

Igen. A `interrupt()` meghívása megszakítást kér minden olyan művelethez, amely ugyanabból a forrásból származó tokent használ. Használjon külön forrást minden olyan művelethez, amelyet függetlenül kíván megszakítani.