---
title: Renderizza presentazioni con font di fallback in JavaScript
linktitle: Renderizza presentazioni
type: docs
weight: 30
url: /it/nodejs-java/render-presentation-with-fallback-font/
keywords:
- font di fallback
- renderizzare PowerPoint
- renderizzare presentazione
- renderizzare diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Renderizza le presentazioni con font di fallback in Aspose.Slides per Node.js - mantieni il testo coerente tra PPT, PPTX e ODP con esempi di codice JavaScript passo-passo."
---
## **Panoramica**

Aspose.Slides consente di renderizzare presentazioni utilizzando le regole di font di fallback. Questo articolo mostra come creare una raccolta di regole di font di fallback, modificare le sue regole rimuovendo o aggiungendo font di fallback e assegnare la raccolta utilizzando il metodo `FontsManager.setFontFallBackRulesCollection`.

Una volta che la raccolta di regole di font di fallback è assegnata al `FontsManager` della presentazione, le regole vengono applicate durante operazioni come il salvataggio, il rendering e la conversione della presentazione. L'esempio dimostra come utilizzare le regole configurate durante il rendering di una miniatura di diapositiva e il salvataggio come immagine PNG.

## **Esegui il rendering di una diapositiva utilizzando le regole di font di fallback**

1. We [creiamo una raccolta di regole di font di fallback](/slides/it/nodejs-java/create-fallback-fonts-collection/).
1. [Rimuovi](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) una regola di font di fallback e [addFallBackFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) a un'altra regola.
1. Imposta la raccolta di regole su [getFontsManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) metodo.
1. Con il metodo [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) possiamo salvare la presentazione nello stesso formato o salvarla in un altro. Dopo che la raccolta di regole di font di fallback è impostata su [FontsManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FontsManager), queste regole vengono applicate durante tutte le operazioni sulla presentazione: salvataggio, rendering, conversione, ecc.

```javascript
// Crea una nuova istanza di una raccolta di regole
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// crea un certo numero di regole
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // Tentativo di rimuovere il font di fallback "Tahoma" dalle regole caricate
    fallBackRule.remove("Tahoma");
    // E aggiornare le regole per l'intervallo specificato
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// Possiamo anche rimuovere qualsiasi regola esistente dall'elenco
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // Assegnazione di un elenco di regole preparato per l'uso
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // Rendering della miniatura utilizzando la raccolta di regole inizializzate e salvataggio in JPEG
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Salva l'immagine su disco in formato JPEG
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
Leggi di più su come [Convertire PPT e PPTX in JPG in JavaScript](/slides/it/nodejs-java/convert-powerpoint-to-jpg/).
{{% /alert %}}