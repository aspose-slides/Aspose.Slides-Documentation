---
title: Specifica i caratteri predefiniti della presentazione in Python tramite Java
linktitle: Carattere predefinito
type: docs
weight: 30
url: /it/python-java/default-font/
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
- Python
- Java
- Aspose.Slides
description: "Imposta i caratteri predefiniti in Aspose.Slides per Python tramite Java per garantire una corretta conversione di PowerPoint (PPT, PPTX) e OpenDocument (ODP) in PDF, XPS e immagini."
---
## **Panoramica**

Aspose.Slides consente di specificare i caratteri predefiniti che vengono utilizzati quando una presentazione viene renderizzata. Questo è utile durante la generazione di anteprime delle diapositive o l'esportazione di una presentazione in formati come PDF e XPS. I caratteri predefiniti vengono configurati tramite [LoadOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/) prima che la presentazione venga caricata.

Il metodo [setDefaultRegularFont](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) definisce il carattere predefinito per il testo normale, mentre [setDefaultAsianFont](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) definisce il carattere predefinito per il testo asiatico. Dopo aver impostato queste opzioni, la presentazione può essere caricata e renderizzata utilizzando i caratteri specificati.

## **Utilizzare i caratteri predefiniti per la renderizzazione di una presentazione**

Aspose.Slides permette di impostare i caratteri predefiniti per la renderizzazione di una presentazione in PDF, XPS o anteprime. Questa sezione mostra come definire i caratteri predefiniti per il testo normale e asiatico usando Aspose.Slides per Python tramite Java:

1. Crea un'istanza di [LoadOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/).
1. Usa [setDefaultRegularFont](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) per specificare il carattere desiderato. L'esempio seguente utilizza Wingdings.
1. Usa [setDefaultAsianFont](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) per specificare il carattere desiderato. Anche in questo caso l'esempio utilizza Wingdings.
1. Carica la presentazione usando [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) con le opzioni di caricamento.
1. Genera l'anteprima della diapositiva, il PDF e l'XPS per verificare i risultati.

Il seguente esempio implementa questi passaggi:

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# Utilizza le opzioni di caricamento per definire i caratteri predefiniti regolari e asiatici.
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# Carica la presentazione.
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # Genera una miniatura della diapositiva.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Salva l'immagine su disco.
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # Genera un PDF.
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # Genera un documento XPS.
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **FAQ**

**Cosa influenzano esattamente i caratteri predefiniti regolari e asiatici—solo l'esportazione o anche le anteprime, PDF, XPS, HTML e SVG?**

Partecipano alla pipeline di rendering per tutti gli output supportati. Questo include le anteprime delle diapositive, [PDF](/slides/it/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/it/python-java/convert-powerpoint-to-xps/), [raster images](/slides/it/python-java/convert-powerpoint-to-png/), [HTML](/slides/it/python-java/convert-powerpoint-to-html/), e [SVG](/slides/it/python-java/render-a-slide-as-an-svg-image/), perché Aspose.Slides utilizza la stessa logica di layout e risoluzione dei glifi per questi target.

**I caratteri predefiniti vengono applicati quando si legge e si salva semplicemente un PPTX senza alcuna renderizzazione?**

No. I caratteri predefiniti sono rilevanti quando il testo deve essere misurato e disegnato. Un semplice salvataggio aperto‑chiuso di una presentazione non modifica le sequenze di caratteri memorizzate né la struttura del file. I caratteri predefiniti entrano in gioco durante le operazioni che renderizzano o riformattano il testo.

**Se aggiungo le mie cartelle di caratteri o fornisco caratteri dalla memoria, saranno considerati nella scelta dei caratteri predefiniti?**

Sì. Le [Custom font sources](/slides/it/python-java/custom-font/) ampliano il catalogo di famiglie e glifi disponibili che il motore può utilizzare. I caratteri predefiniti e le eventuali [fallback rules](/slides/it/python-java/fallback-font/) verranno risolti contro tali sorgenti prima, offrendo una copertura più affidabile su server e container.

**I caratteri predefiniti influenzeranno le metriche del testo (kerning, avanzamenti) e quindi le interruzioni di riga e l'avvolgimento?**

Sì. Cambiare il carattere modifica le metriche dei glifi e può alterare le interruzioni di riga, l'avvolgimento e la paginazione durante il rendering. Per mantenere la stabilità del layout, [embed the original fonts](/slides/it/python-java/embedded-font/) o seleziona famiglie predefinite e di fallback compatibili metricamente.

**Ha senso impostare i caratteri predefiniti se tutti i caratteri utilizzati nella presentazione sono incorporati?**

Spesso non è necessario, perché i [embedded fonts](/slides/it/python-java/embedded-font/) garantiscono già un aspetto coerente. I caratteri predefiniti sono comunque utili come rete di sicurezza per i caratteri non coperti dal sottoinsieme incorporato o quando un file combina testo incorporato e non incorporato.