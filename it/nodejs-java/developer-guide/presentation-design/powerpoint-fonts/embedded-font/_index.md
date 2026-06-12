---
title: Incorporare i caratteri nelle presentazioni usando JavaScript
linktitle: Incorporamento del carattere
type: docs
weight: 40
url: /it/nodejs-java/embedded-font/
keywords:
- aggiungi carattere
- incorpora carattere
- incorporamento del carattere
- ottieni carattere incorporato
- aggiungi carattere incorporato
- rimuovi carattere incorporato
- comprimi carattere incorporato
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Incorpora caratteri TrueType in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Node.js via Java, garantendo un rendering accurato su tutte le piattaforme."
---
## **Introduzione**

**I caratteri incorporati in PowerPoint** sono utili quando vuoi che la tua presentazione appaia correttamente su qualsiasi sistema o dispositivo. Se hai usato un carattere di terze parti o non standard perché sei stato creativo con il tuo lavoro, hai ancora più motivi per incorporare il carattere. Altrimenti (senza caratteri incorporati), il testo o i numeri nelle tue diapositive, il layout, lo stile, ecc. possono cambiare o trasformarsi in rettangoli confusi. 

Le classi [FontsManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FontsManager) , [FontData](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontdata/) , [Compress](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/) e le loro classi contengono la maggior parte delle proprietà e dei metodi di cui hai bisogno per lavorare con i caratteri incorporati nelle presentazioni PowerPoint.

## **Ottenere o rimuovere i caratteri incorporati dalla presentazione**

Aspose.Slides fornisce il metodo [getEmbeddedFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (esposto dalla classe [FontsManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FontsManager)) per consentirti di ottenere (o scoprire) i caratteri incorporati in una presentazione. Per rimuovere i caratteri, viene utilizzato il metodo [removeEmbeddedFont](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) (esposto dalla stessa classe).

Questo codice JavaScript mostra come ottenere e rimuovere i caratteri incorporati da una presentazione:

```javascript
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // Renderizza una diapositiva contenente un frame di testo che utilizza il carattere incorporato "FunSized"
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Salva l'immagine su disco in formato JPEG
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // Ottiene tutti i caratteri incorporati
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // Trova il carattere "Calibri"
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // Rimuove il carattere "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // Renderizza la presentazione; il carattere "Calibri" è sostituito da uno esistente
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Salva l'immagine su disco in formato JPEG
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Salva la presentazione senza il carattere "Calibri" incorporato su disco
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aggiungere caratteri incorporati alla presentazione**

Utilizzando l’enumerazione [EmbedFontCharacters](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/embedfontcharacters/) e due overload del metodo [addEmbeddedFont](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-), puoi selezionare la regola di incorporamento preferita per incorporare i caratteri in una presentazione. Questo codice JavaScript mostra come incorporare e aggiungere caratteri a una presentazione:

```javascript
// Carica la presentazione
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // Salva la presentazione su disco
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Comprimere i caratteri incorporati**

Per consentirti di comprimere i caratteri incorporati in una presentazione e ridurne le dimensioni del file, Aspose.Slides fornisce il metodo [compressEmbeddedFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) (esposto dalla classe [Compress](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/)).

Questo codice JavaScript mostra come comprimere i caratteri PowerPoint incorporati:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Come posso capire se un carattere specifico nella presentazione verrà comunque sostituito durante il rendering nonostante sia stato incorporato?**

Verifica le [informazioni sulla sostituzione](/slides/it/nodejs-java/font-substitution/) nel gestore dei caratteri e le [regole di fallback/sostituzione](/slides/it/nodejs-java/fallback-font/): se il carattere non è disponibile o è limitato, verrà utilizzato un fallback.

**Vale la pena incorporare i caratteri "di sistema" come Arial/Calibri?**

Di solito no—sono quasi sempre disponibili. Tuttavia, per una piena portabilità in ambienti "leggeri" (Docker, un server Linux senza caratteri preinstallati), incorporare i caratteri di sistema può eliminare il rischio di sostituzioni inaspettate.