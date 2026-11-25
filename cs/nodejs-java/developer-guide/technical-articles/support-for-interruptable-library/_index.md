---
title: Přerušení dlouhotrvajících operací s prezentací v Node.js
linktitle: Přerušení operací s prezentací
type: docs
weight: 120
url: /cs/nodejs-java/support-for-interruptable-library/
keywords:
- přerušitelné operace
- token přerušení
- token zrušení
- časový limit konverze
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Zrušte dlouhotrvající operace s prezentací v Aspose.Slides pro Node.js přes Java, nastavte časový limit konverze a sledujte snímky exportované před zrušením."
---
## **Přehled**

Aspose.Slides pro Node.js přes Java podporuje zrušení operace při načítání, ukládání nebo vykreslování prezentace. Také můžete ve svém vlastním exportním cyklu kontrolovat stejný token, abyste zastavili před dalším snímkem a vrátili čísla již uložených snímků.

## **Přerušení operace s prezentací**

Vytvořte [InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/), získejte jeho token pomocí [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken) a předávejte jej metodě [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken). Použijte tyto možnosti při vytváření [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Volání [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) na zdroji požaduje zrušení aktuální operace. Aspose.Slides se zastaví, až token znovu zkontroluje.

### **Nastavení časového limitu konverze**

Následující příklad umožňuje 20 sekund k otevření souboru `sample.pptx` a uložení jako `sample.pdf`. Jak konstruktor, tak i metoda uložení běží asynchronně přes Java most, takže časovač Node.js může být spuštěn během kterékoliv operace. Příklad kontroluje token po načtení a znovu po uložení, protože volání knihovny může vrátit po požadavku na zrušení. Uvolní prezentaci, až se operace stabilizuje, a vymaže časovač, pokud konverze skončí dříve. Pokud dojde ke zrušení během ukládání, výstupní soubor může již existovat a může být neúplný.

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

Pro konverzi do staršího formátu PowerPoint s limitem 10 sekund předávejte `"sample.ppt"`, `slides.SaveFormat.Ppt` a `10000` jako poslední tři argumenty.

## **Zastavit před zpracováním dalšího snímku**

Použijte [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) před každým exportem, když volající může využít částečný výsledek. Přetížení metody [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) pro vybrané snímky přijímá v Javě `int[]` čísel snímků začínajících od 1. Zaznamenejte každé číslo až po úspěšném uložení jeho PDF.

Spusťte příklad s prezentací pojmenovanou `sample.pptx`, která obsahuje alespoň dva snímky. Pro demonstraci zrušení mezi exporty příklad požaduje zrušení ihned po uložení prvního snímku.

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

Příklad zapíše `slide-1.pdf` a vypíše `Starting slide 1` následované `Completed: [1]`. Smyčka zaznamená zrušení před zahájením snímku 2. Pokud je ukládání samo přerušeno, vrácený seznam obsahuje pouze dříve úspěšně exportované snímky.

Aby volající mohl zrušení zpracovat jako chybu, nahraďte kontrolu a její `break` na začátku smyčky voláním [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested), tj. `token.throwIfInterruptionRequested()`. Použijte stejnou kontrolu po uložení a odstraňte `try`/`catch` kolem ní. Se stejným vstupem se první PDF stále zapíše a druhá iterace vyhodí výjimku ještě před tím, než funkce může vrátit seznam.

## **Často kladené otázky**

**Kdy bych měl požádat o zrušení?**

Požádejte o zrušení, když vyprší termín nebo aplikace již výsledek nepotřebuje. Načítání, ukládání i renderování mohou všechny použít token předaný prezentaci při jejím vytvoření.

**Jak se liší zdroj a token?**

Zdroj umožňuje aplikaci požádat o zrušení. Token umožňuje Aspose.Slides i vašemu vlastnímu kódu zkontrolovat tento požadavek.

**Může časovač Node.js přerušit synchronní uložení?**

Synchronní uložení blokuje JavaScript na volajícím vlákně. Použijte asynchronní volání Java mostu ukázaná v příkladu s časovým limitem, aby časovač mohl požádat o zrušení během běhu ukládání.

**Nastane zrušení okamžitě?**

Zrušení je kooperativní. Probíhající operace se zastaví, až zaznamená požadavek. Operace, která již skončila, si výsledek ponechá.

**Mohou si více operací sdílet zdroj?**

Ano. Volání `interrupt()` požaduje zrušení pro každou operaci, která používá token z tohoto zdroje. Pro každou operaci, kterou chcete zrušit samostatně, použijte oddělený zdroj.