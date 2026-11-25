---
title: Onderbreek langlopende presentatiewerkzaamheden in Node.js
linktitle: Onderbreek presentatiewerkzaamheden
type: docs
weight: 120
url: /nl/nodejs-java/support-for-interruptable-library/
keywords:
- onderbreekbare bewerkingen
- onderbrekingstoken
- annuleringstoken
- conversietimeout
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Annuleer langlopende presentatiewerkzaamheden in Aspose.Slides voor Node.js via Java, stel een conversietimeout in en houd bij welke dia's zijn geëxporteerd vóór annulering."
---
## **Overzicht**

Aspose.Slides voor Node.js via Java ondersteunt annulering bij het laden, opslaan of renderen van een presentatie. U kunt dezelfde token ook in uw eigen exportlus controleren om te stoppen vóór de volgende dia en de nummers van de reeds opgeslagen dia's terug te geven.

## **Onderbreek een Presentatie‑bewerking**

Maak een [InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/), verkrijg de token met [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken), en geef deze door aan [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken). Gebruik deze opties bij het construeren van de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Een aanroep van [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) op de bron vraagt om annulering van de huidige bewerking. Aspose.Slides stopt wanneer het de token de volgende keer controleert.

### **Stel een Conversietime-out In**

Het volgende voorbeeld staat 20 seconden toe om `sample.pptx` te openen en op te slaan als `sample.pdf`. Zowel de constructor als het opslaan worden asynchroon uitgevoerd via de Java‑bridge zodat de Node.js‑timer kan afgaan tijdens een van beide bewerkingen. Het voorbeeld controleert de token na het laden en opnieuw na het opslaan, omdat een bibliotheekaanroep kan terugkeren na een annuleringsverzoek. Het maakt de presentatie vrij wanneer de bewerking voltooid is en wist de timer als de conversie vroegtijdig eindigt. Als annulering optreedt tijdens het opslaan, kan het uitvoerbestand al bestaan en onvolledig zijn.

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

Om naar het oudere PowerPoint‑formaat te converteren met een limiet van 10 seconden, geef `"sample.ppt"`, `slides.SaveFormat.Ppt` en `10000` door als de laatste drie argumenten.

## **Stop Voor het Verwerken van de Volgende Dia**

Gebruik [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) vóór elke export wanneer de aanroeper een gedeeltelijk resultaat kan gebruiken. De [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) overload voor geselecteerde dia's neemt een Java `int[]` van dianummers beginnend bij 1. Noteer elk nummer pas nadat de bijbehorende PDF succesvol is opgeslagen.

Voer het voorbeeld uit met een presentatie genaamd `sample.pptx` die minstens twee dia's bevat. Om annulering tussen exports te demonstreren, vraagt het voorbeeld deze direct na het opslaan van de eerste dia.

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

Het voorbeeld schrijft `slide-1.pdf` en geeft `Starting slide 1` weer, gevolgd door `Completed: [1]`. De lus ziet de annulering vóór het starten van dia 2. Als een opslaan zelf wordt onderbroken, bevat de teruggegeven lijst alleen de eerder succesvolle exports.

Om de aanroeper annulering als fout te laten afhandelen, vervang de controle en de `break` aan het begin van de lus door [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested), aangeroepen als `token.throwIfInterruptionRequested()`. Gebruik dezelfde throw‑controle na het opslaan en verwijder het `try`/`catch`‑blok eromheen. Met dezelfde invoer wordt de eerste PDF nog steeds geschreven, en de tweede iteratie gooit een uitzondering voordat de functie een lijst kan teruggeven.

## **FAQ**

**Wanneer moet ik annulering aanvragen?**

Vraag annulering aan wanneer een deadline verstrijkt of de applicatie het resultaat niet meer nodig heeft. Laden, opslaan en renderen kunnen allemaal de token gebruiken die bij het construeren van de presentatie is meegegeven.

**Hoe verschillen de bron en de token?**

De bron stelt de applicatie in staat om annulering aan te vragen. De token stelt Aspose.Slides en uw eigen code in staat om die aanvraag te controleren.

**Kan een Node.js‑timer een synchronische opslag onderbreken?**

Een synchronische opslag blokkeert JavaScript op de aanroepende thread. Gebruik de asynchrone Java‑bridge‑oproepen die in het time‑out‑voorbeeld worden getoond, zodat de timer een annulering kan aanvragen terwijl de opslag loopt.

**Heeft annulering direct effect?**

Annulering is coöperatief. Een lopende bewerking stopt wanneer zij de aanvraag ziet. Een bewerking die al voltooid is, behoudt haar resultaat.

**Kunnen meerdere bewerkingen een bron delen?**

Ja. Het aanroepen van `interrupt()` vraagt annulering voor elke bewerking die een token van die bron gebruikt. Gebruik een aparte bron voor elke bewerking die u onafhankelijk wilt annuleren.