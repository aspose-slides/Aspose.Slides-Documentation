---
title: Specificare i Font Predefiniti della Presentazione su Android
linktitle: Font Predefinito
type: docs
weight: 30
url: /it/androidjava/default-font/
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
- Android
- Java
- Aspose.Slides
description: "Impostare i font predefiniti in Aspose.Slides per Android tramite Java per garantire la corretta conversione di PowerPoint (PPT, PPTX) e OpenDocument (ODP) in PDF, XPS e immagini."
---
## **Panoramica**

Aspose.Slides consente di specificare i font predefiniti che vengono utilizzati quando una presentazione viene renderizzata. Ciò è utile durante la generazione di miniature delle diapositive o l'esportazione di una presentazione in formati come PDF e XPS. I font predefiniti vengono configurati tramite `LoadOptions` prima del caricamento della presentazione.

Il metodo `setDefaultRegularFont` definisce il font predefinito per il testo normale, mentre `setDefaultAsianFont` definisce il font predefinito per il testo asiatico. Una volta impostate queste opzioni, la presentazione può essere caricata e renderizzata utilizzando i font specificati.

## **Utilizzare i Font Predefiniti per il Rendering di una Presentazione**
Aspose.Slides consente di impostare il font predefinito per il rendering della presentazione in PDF, XPS o miniature. Questo articolo mostra come definire DefaultRegularFont e DefaultAsianFont da utilizzare come font predefiniti. Segui i passaggi seguenti per caricare i font da directory esterne utilizzando Aspose.Slides per Android tramite l'API Java:

1. Crea un'istanza di [LoadOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/LoadOptions).
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) al font desiderato. Nell'esempio seguente, ho usato Wingdings.
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) al font desiderato. Ho usato Wingdings nel campione seguente.
1. Carica la presentazione usando Presentation e impostando le opzioni di caricamento.
1. Ora, genera la miniatura della diapositiva, il PDF e l'XPS per verificare i risultati.

L'implementazione di quanto sopra è mostrata di seguito.

```java
// Usa le opzioni di caricamento per definire i font predefiniti regolari e asiatici
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Carica la presentazione
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Genera miniatura della diapositiva
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // salva l'immagine su disco.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // Genera PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // Genera XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Cosa influenzano esattamente DefaultRegularFont e DefaultAsianFont—solo l'esportazione o anche le miniature, PDF, XPS, HTML e SVG?**

Partecipano al processo di rendering per tutti gli output supportati. Ciò include le miniature delle diapositive, [PDF](/slides/it/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/it/androidjava/convert-powerpoint-to-xps/), [immagini raster](/slides/it/androidjava/convert-powerpoint-to-png/), [HTML](/slides/it/androidjava/convert-powerpoint-to-html/), e [SVG](/slides/it/androidjava/render-a-slide-as-an-svg-image/), perché Aspose.Slides utilizza la stessa logica di layout e risoluzione dei glifi per questi target.

**I font predefiniti vengono applicati quando si legge e si salva semplicemente un PPTX senza alcun rendering?**

No. I font predefiniti sono importanti quando il testo deve essere misurato e disegnato. Un semplice apri‑salva di una presentazione non modifica le sequenze di font memorizzate né la struttura del file. I font predefiniti entrano in gioco durante le operazioni che renderizzano o riformattano il testo.

**Se aggiungo le mie cartelle di font o fornisco font dalla memoria, verranno considerati nella scelta dei font predefiniti?**

Sì. [Custom font sources](/slides/it/androidjava/custom-font/) ampliano il catalogo di famiglie e glifi disponibili che il motore può utilizzare. I font predefiniti e qualsiasi [fallback rules](/slides/it/androidjava/fallback-font/) verranno risolti prima contro queste fonti, garantendo una copertura più affidabile su server e in contenitori.

**I font predefiniti influenzeranno le metriche del testo (kerning, avanzamenti) e quindi le interruzioni di linea e il wrapping?**

Sì. Cambiare il font modifica le metriche dei glifi e può alterare le interruzioni di riga, il wrapping e l'impaginazione durante il rendering. Per la stabilità del layout, [embed the original fonts](/slides/it/androidjava/embedded-font/) o selezionare famiglie predefinite e di fallback metricamente compatibili.

**Ha senso impostare i font predefiniti se tutti i font utilizzati nella presentazione sono incorporati?**

Spesso non è necessario, poiché i [embedded fonts](/slides/it/androidjava/embedded-font/) garantiscono già un aspetto coerente. I font predefiniti sono comunque utili come rete di sicurezza per i caratteri non coperti dal sottoinsieme incorporato o quando un file mescola testo incorporato e non incorporato.