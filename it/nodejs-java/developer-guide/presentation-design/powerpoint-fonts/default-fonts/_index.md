---
title: Specifica i font predefiniti della presentazione in JavaScript
linktitle: Font predefinito
type: docs
weight: 30
url: /it/nodejs-java/default-font/
keywords:
- font predefinito
- font regolare
- font normale
- font asiatico
- esportazione PDF
- esportazione XPS
- esportazione immagine
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Imposta i font predefiniti in Aspose.Slides per Node.js tramite Java per garantire una corretta conversione di PowerPoint (PPT, PPTX) e OpenDocument (ODP) in PDF, XPS e immagini."
---
## **Panoramica**

Aspose.Slides consente di specificare i caratteri predefiniti che vengono utilizzati quando una presentazione viene renderizzata. Questo è utile durante la generazione di miniature delle diapositive o l'esportazione di una presentazione in formati come PDF e XPS. I caratteri predefiniti sono configurati tramite `LoadOptions` prima del caricamento della presentazione.

Il metodo `setDefaultRegularFont` definisce il carattere predefinito per il testo normale, mentre `setDefaultAsianFont` definisce il carattere predefinito per il testo asiatico. Dopo aver impostato queste opzioni, la presentazione può essere caricata e renderizzata utilizzando i caratteri specificati.

## **Utilizzo dei caratteri predefiniti per il rendering della presentazione**
Aspose.Slides consente di impostare il carattere predefinito per il rendering della presentazione in PDF, XPS o miniature. Questo articolo mostra come definire DefaultRegularFont e DefaultAsianFont da utilizzare come caratteri predefiniti. Segui i passaggi seguenti per caricare i caratteri da directory esterne utilizzando Aspose.Slides per Node.js tramite l'API Java:

1. Crea un'istanza di [LoadOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/LoadOptions).
2. Imposta il [DefaultRegularFont](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) sul carattere desiderato. Nell'esempio seguente, ho usato Wingdings.
3. Imposta il [DefaultAsianFont](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) sul carattere desiderato. Ho usato Wingdings nel campione seguente.
4. Carica la presentazione utilizzando Presentation e impostando le opzioni di caricamento.
5. Ora, genera la miniatura della diapositiva, il PDF e l'XPS per verificare i risultati.

L'implementazione di quanto sopra è mostrata di seguito.

```javascript
// Usa le opzioni di caricamento per definire i font regolari e asiatici predefiniti
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// Carica la presentazione
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Genera la miniatura della diapositiva
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // salva l'immagine su disco.
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Genera PDF
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // Genera XPS
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Domande frequenti**

**Cosa influenzano esattamente DefaultRegularFont e DefaultAsianFont—solo l'esportazione o anche le miniature, PDF, XPS, HTML e SVG?**

Essi partecipano al pipeline di rendering per tutti gli output supportati. Questo include le miniature delle diapositive, [PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/it/nodejs-java/convert-powerpoint-to-xps/), [immagini raster](/slides/it/nodejs-java/convert-powerpoint-to-png/), [HTML](/slides/it/nodejs-java/convert-powerpoint-to-html/), e [SVG](/slides/it/nodejs-java/render-a-slide-as-an-svg-image/), perché Aspose.Slides utilizza la stessa logica di layout e risoluzione dei glifi per questi target.

**Le font predefinite vengono applicate quando si legge e si salva semplicemente un PPTX senza alcun rendering?**

No. Le font predefinite sono rilevanti quando il testo deve essere misurato e disegnato. Un semplice apertura‑salvataggio di una presentazione non modifica le sequenze di caratteri memorizzate né la struttura del file. Le font predefinite entrano in gioco durante le operazioni che renderizzano o riformattano il testo.

**Se aggiungo le mie cartelle di font o fornisco font dalla memoria, saranno considerati nella scelta delle font predefinite?**

Sì. [Font personalizzati](/slides/it/nodejs-java/custom-font/) ampliano il catalogo di famiglie e glifi disponibili che il motore può usare. Le font predefinite e eventuali [regole di fallback](/slides/it/nodejs-java/fallback-font/) verranno risolte prima su queste fonti, offrendo una copertura più affidabile su server e container.

**Le font predefinite influenzeranno le metriche del testo (kerning, avanzamenti) e quindi le interruzioni di linea e il word‑wrap?**

Sì. Cambiare il carattere modifica le metriche dei glifi e può alterare le interruzioni di riga, l'avvolgimento e la paginazione durante il rendering. Per la stabilità del layout, [incorpora i font originali](/slides/it/nodejs-java/embedded-font/) o seleziona famiglie predefinite e di fallback metricamente compatibili.

**Ha senso impostare le font predefinite se tutti i font utilizzati nella presentazione sono incorporati?**

Spesso non è necessario, perché i [font incorporati](/slides/it/nodejs-java/embedded-font/) garantiscono già un aspetto coerente. Le font predefinite sono comunque utili come rete di sicurezza per i caratteri non coperti dal sottoinsieme incorporato o quando un file mescola testo incorporato e non incorporato.