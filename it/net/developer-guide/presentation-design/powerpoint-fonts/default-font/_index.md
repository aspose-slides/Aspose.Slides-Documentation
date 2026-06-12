---
title: Specifica i font predefiniti della presentazione in .NET
linktitle: Font predefinito
type: docs
weight: 30
url: /it/net/default-font/
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
- .NET
- C#
- Aspose.Slides
description: "Imposta i font predefiniti in Aspose.Slides per .NET per garantire una corretta conversione di PowerPoint (PPT, PPTX) e OpenDocument (ODP) in PDF, XPS e immagini."
---
## **Panoramica**

Aspose.Slides consente di specificare i caratteri predefiniti che vengono utilizzati quando una presentazione viene renderizzata. Questo è utile durante la generazione di miniature delle diapositive o l'esportazione di una presentazione in formati come PDF e XPS. I caratteri predefiniti vengono configurati attraverso `LoadOptions` prima che la presentazione venga caricata.

La proprietà `DefaultRegularFont` definisce il carattere predefinito per il testo normale, mentre `DefaultAsianFont` definisce il carattere predefinito per il testo asiatico. Dopo aver impostato queste opzioni, la presentazione può essere caricata e renderizzata utilizzando i caratteri specificati.

## **Usare i caratteri predefiniti per il rendering di una presentazione**
Aspose.Slides consente di impostare il carattere predefinito per il rendering della presentazione in PDF, XPS o miniature. Questo articolo mostra come definire DefaultRegularFont e DefaultAsianFont per usarli come caratteri predefiniti. Si prega di seguire i passaggi seguenti per caricare i caratteri da directory esterne utilizzando l'API Aspose.Slides per .NET:

1. Creare un'istanza di LoadOptions.  
1. Impostare DefaultRegularFont sul carattere desiderato. Nell'esempio seguente, ho usato Wingdings.  
1. Impostare DefaultAsianFont sul carattere desiderato. Ho usato Wingdings nel campione seguente.  
1. Caricare la presentazione usando Presentation e impostando le opzioni di caricamento.  
1. Ora, generare la miniatura della diapositiva, PDF e XPS per verificare i risultati.  

L'implementazione di quanto sopra è mostrata di seguito.

```c#
 // Utilizza le opzioni di caricamento per specificare i font regolari e asiatici predefiniti
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    using (IImage image = pptx.Slides[0].GetImage(1, 1))
    {
        image.Save("DefaultFonts_out.png", ImageFormat.Png);
    }

    pptx.Save("DefaultFonts_out.pdf", SaveFormat.Pdf);
    pptx.Save("DefaultFonts_out.xps", SaveFormat.Xps);
}
```

## **FAQ**

**Cosa influenzano esattamente DefaultRegularFont e DefaultAsianFont—solo l'esportazione o anche miniature, PDF, XPS, HTML e SVG?**

Partecipano al pipeline di rendering per tutti gli output supportati. Questo include miniature delle diapositive, [PDF](/slides/it/net/convert-powerpoint-to-pdf/), [XPS](/slides/it/net/convert-powerpoint-to-xps/), [immagini raster](/slides/it/net/convert-powerpoint-to-png/), [HTML](/slides/it/net/convert-powerpoint-to-html/), e [SVG](/slides/it/net/render-a-slide-as-an-svg-image/), poiché Aspose.Slides utilizza la stessa logica di layout e risoluzione dei glifi per questi target.

**I caratteri predefiniti vengono applicati quando si legge e si salva semplicemente un PPTX senza alcun rendering?**

No. I caratteri predefiniti sono rilevanti quando il testo deve essere misurato e disegnato. Un semplice salvataggio aperto‑chiuso di una presentazione non modifica le sequenze di caratteri memorizzate né la struttura del file. I caratteri predefiniti entrano in gioco durante le operazioni che renderizzano o riformattano il testo.

**Se aggiungo le mie cartelle di caratteri o fornisco caratteri dalla memoria, verranno considerati nella scelta dei caratteri predefiniti?**

Sì. [Custom font sources](/slides/it/net/custom-font/) espandono il catalogo delle famiglie e dei glifi disponibili che il motore può utilizzare. I caratteri predefiniti e qualsiasi [regola di fallback](/slides/it/net/fallback-font/) verranno risolti prima contro queste fonti, fornendo una copertura più affidabile su server e container.

**I caratteri predefiniti influenzeranno le metriche del testo (kerning, avanzamenti) e quindi le interruzioni di riga e l’avvolgimento?**

Sì. Cambiare il carattere modifica le metriche dei glifi e può alterare le interruzioni di riga, l’avvolgimento e l’impaginazione durante il rendering. Per la stabilità del layout, [incorporare i caratteri originali](/slides/it/net/embedded-font/) o selezionare famiglie predefinite e di fallback metricamente compatibili.

**Ha senso impostare i caratteri predefiniti se tutti i caratteri usati nella presentazione sono incorporati?**

Spesso non è necessario, perché i [caratteri incorporati](/slides/it/net/embedded-font/) garantiscono già un aspetto coerente. I caratteri predefiniti sono comunque utili come rete di sicurezza per i caratteri non coperti dal sottoinsieme incorporato o quando un file mescola testo incorporato e non incorporato.