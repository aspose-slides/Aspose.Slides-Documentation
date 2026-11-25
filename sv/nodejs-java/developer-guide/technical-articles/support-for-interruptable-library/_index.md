---
title: Avbryt långvariga presentationsoperationer i Node.js
linktitle: Avbryt presentationsoperationer
type: docs
weight: 120
url: /sv/nodejs-java/support-for-interruptable-library/
keywords:
- avbrytbara operationer
- avbrottstoken
- avbokningstoken
- konverteringstimeout
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Avbryt långvariga presentationsoperationer i Aspose.Slides för Node.js via Java, ange en konverteringstimeout och håll reda på bilder som exporterats innan avbrytning."
---
## **Översikt**

Aspose.Slides för Node.js via Java stöder avbrott när en presentation laddas, sparas eller renderas. Du kan också kontrollera samma token i din egen exportloop för att stoppa innan nästa bild och returnera numren på de bilder som redan har sparats.

## **Avbryt en presentationsoperation**

Skapa en [InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/), hämta dess token med [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken), och skicka den till [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken). Använd dessa alternativ när du konstruerar [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Att anropa [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) på källan begär avbrytning av den pågående operationen. Aspose.Slides stoppar när den nästa gången kontrollerar token.

### **Ange en konverteringstimeout**

Följande exempel tillåter 20 sekunder för att öppna `sample.pptx` och spara den som `sample.pdf`. Både konstruktorn och sparandet körs asynkront via Java-bron så att Node.js-timern kan avfyras under någon av operationerna. Exemplet kontrollerar token efter inläsning och igen efter sparande, eftersom ett biblioteksanrop kan returnera efter en avbokningsbegäran. Det släpper presentationen när operationen är avklarad och rensar timern om konverteringen avslutas tidigt. Om avbrytning sker under ett sparande kan utdatafilen redan finnas och vara ofullständig.

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

För att konvertera till det äldre PowerPoint‑formatet med en 10‑sekunders gräns, skicka `"sample.ppt"`, `slides.SaveFormat.Ppt` och `10000` som de sista tre argumenten.

## **Stoppa innan nästa bild bearbetas**

Använd [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) före varje export när anroparen kan använda ett partiellt resultat. Överlagringen [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) för valda bilder tar emot en Java `int[]` med bildnummer med start på 1. Registrera varje nummer först efter att dess PDF har sparats framgångsrikt.

Kör exemplet med en presentation som heter `sample.pptx` och innehåller minst två bilder. För att demonstrera avbrytning mellan exporter begär exemplet det omedelbart efter att den första bilden har sparats.

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

Exemplet skriver `slide-1.pdf` och skriver ut `Starting slide 1` följt av `Completed: [1]`. Loopen observerar avbrytning innan bild 2 påbörjas. Om ett sparande avbryts själv innehåller den returnerade listan endast de tidigare lyckade exporterna.

För att låta anroparen hantera avbrytning som ett fel, ersätt kontrollen och dess `break` högst upp i loopen med [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested), anropad som `token.throwIfInterruptionRequested()`. Använd samma kastkontroll efter sparandet och ta bort `try`/`catch`‑blocket runt den. Med samma indata skrivs den första PDF‑filen fortfarande, och den andra iterationen kastar ett undantag innan funktionen kan returnera en lista.

## **FAQ**

**När bör jag begära avbrytning?**

Begär avbrytning när en tidsgräns har löpt ut eller när applikationen inte längre behöver resultatet. Laddning, sparning och rendering kan alla använda token som skickas till presentationen vid konstruktion.

**Hur skiljer sig källan och token?**

Källan låter applikationen begära avbrytning. Token låter Aspose.Slides och din egen kod kontrollera den begäran.

**Kan en Node.js-timer avbryta en synkron sparning?**

En synkron sparning blockerar JavaScript på anropstråden. Använd de asynkrona Java‑bridge‑anropen som visas i timeout‑exemplet så att timern kan begära avbrytning medan sparandet pågår.

**Går avbrytning i kraft omedelbart?**

Avbrytning är samarbetsbaserad. En pågående operation stoppar när den observerar begäran. En operation som redan har avslutats behåller sitt resultat.

**Kan flera operationer dela en källa?**

Ja. Att anropa `interrupt()` begär avbrytning för varje operation som använder en token från den källan. Använd en separat källa för varje operation du vill avbryta oberoende.