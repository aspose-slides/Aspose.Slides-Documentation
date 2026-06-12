---
title: Specifica i caratteri predefiniti della presentazione in Java
linktitle: Carattere predefinito
type: docs
weight: 30
url: /it/java/default-font/
keywords:
- carattere predefinito
- carattere regolare
- carattere normale
- carattere asiatico
- esportazione PDF
- esportazione XPS
- esportazione immagine
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Imposta i caratteri predefiniti in Aspose.Slides per Java per garantire una corretta conversione di PowerPoint (PPT, PPTX) e OpenDocument (ODP) in PDF, XPS e immagini."
---
## **Panoramica**

Aspose.Slides consente di specificare i caratteri predefiniti che vengono utilizzati quando una presentazione viene renderizzata. Ciò è utile durante la generazione di miniature delle diapositive o l'esportazione di una presentazione in formati come PDF e XPS. I caratteri predefiniti sono configurati tramite `LoadOptions` prima del caricamento della presentazione.

Il metodo `setDefaultRegularFont` definisce il carattere predefinito per il testo normale, mentre `setDefaultAsianFont` definisce il carattere predefinito per il testo asiatico. Dopo aver impostato queste opzioni, la presentazione può essere caricata e renderizzata utilizzando i caratteri specificati.

## **Utilizzare i caratteri predefiniti per il rendering di una presentazione**
Aspose.Slides consente di impostare il carattere predefinito per il rendering della presentazione in PDF, XPS o miniature. Questo articolo mostra come definire DefaultRegularFont e DefaultAsianFont per l'uso come caratteri predefiniti. Segui i passaggi seguenti per caricare i caratteri da directory esterne utilizzando l'API Aspose.Slides per Java:

1. Crea un'istanza di [LoadOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/LoadOptions).
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/it/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) al carattere desiderato. Nell'esempio seguente ho usato Wingdings.
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/it/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) al carattere desiderato. Ho usato Wingdings nel campione seguente.
1. Carica la presentazione usando Presentation e impostando le opzioni di caricamento.
1. Ora, genera la miniatura della diapositiva, PDF e XPS per verificare i risultati.

L'implementazione di quanto sopra è mostrata di seguito.

```java
// Usa le opzioni di caricamento per definire i caratteri predefiniti regolari e asiatici
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Carica la presentazione
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Genera la miniatura della diapositiva
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

**Che cosa influiscono esattamente DefaultRegularFont e DefaultAsianFont—solo l'esportazione o anche miniature, PDF, XPS, HTML e SVG?**

Essi partecipano alla pipeline di rendering per tutti gli output supportati. Questo include le miniature delle diapositive, [PDF](/slides/it/java/convert-powerpoint-to-pdf/), [XPS](/slides/it/java/convert-powerpoint-to-xps/), [raster images](/slides/it/java/convert-powerpoint-to-png/), [HTML](/slides/it/java/convert-powerpoint-to-html/), e [SVG](/slides/it/java/render-a-slide-as-an-svg-image/), perché Aspose.Slides utilizza la stessa logica di layout e risoluzione dei glifi per questi target.

**Le font predefinite vengono applicate quando si legge e si salva semplicemente un PPTX senza alcun rendering?**

No. Le font predefinite sono rilevanti quando il testo deve essere misurato e disegnato. Un semplice salvataggio aperto‑chiuso di una presentazione non modifica le corse di carattere memorizzate né la struttura del file. Le font predefinite entrano in gioco durante le operazioni che renderizzano o riformattano il testo.

**Se aggiungo le mie cartelle di caratteri o fornisco caratteri dalla memoria, saranno considerati nella scelta delle font predefinite?**

Sì. Le [custom font sources](/slides/it/java/custom-font/) ampliano il catalogo di famiglie e glifi disponibili che il motore può utilizzare. Le font predefinite e qualsiasi [regola di fallback](/slides/it/java/fallback-font/) si risolveranno prima contro tali font, offrendo una copertura più affidabile su server e in container.

**Le font predefinite influiranno sulle metriche del testo (kerning, advance) e quindi su interruzioni di riga e avvolgimento?**

Sì. Cambiare il carattere modifica le metriche dei glifi e può alterare le interruzioni di riga, l'avvolgimento e la paginazione durante il rendering. Per la stabilità del layout, [incorpora i caratteri originali](/slides/it/java/embedded-font/) o scegli famiglie di fallback metricamente compatibili.

**Ha senso impostare le font predefinite se tutti i caratteri usati nella presentazione sono incorporati?**

Spesso non è necessario, perché i [font incorporati](/slides/it/java/embedded-font/) garantiscono già un aspetto coerente. Le font predefinite sono comunque utili come rete di sicurezza per caratteri non coperti dal sottoinsieme incorporato o quando un file mescola testo incorporato e non incorporato.