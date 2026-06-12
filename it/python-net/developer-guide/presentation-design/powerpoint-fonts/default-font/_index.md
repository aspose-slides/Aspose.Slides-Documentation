---
title: "Personalizza i caratteri predefiniti nelle presentazioni con Python"
linktitle: "Carattere predefinito"
type: docs
weight: 30
url: /it/python-net/default-font/
keywords:
- "carattere predefinito"
- "carattere regolare"
- "carattere normale"
- "carattere asiatico"
- "esportazione PDF"
- "esportazione XPS"
- "esportazione immagine"
- "PowerPoint"
- "OpenDocument"
- "presentazione"
- "Python"
- "Aspose.Slides"
description: "Imposta i caratteri predefiniti in Aspose.Slides per Python per garantire una corretta conversione di PowerPoint (PPT, PPTX) e OpenDocument (ODP) in PDF, XPS e immagini."
---
## **Panoramica**

Aspose.Slides consente di specificare i caratteri predefiniti da utilizzare quando una presentazione viene renderizzata. Questo è utile durante la generazione di miniature delle diapositive o l'esportazione di una presentazione in formati come PDF e XPS. I caratteri predefiniti sono configurati tramite `LoadOptions` prima del caricamento della presentazione.

La proprietà `default_regular_font` definisce il carattere predefinito per il testo normale, mentre `default_asian_font` definisce il carattere predefinito per il testo asiatico. Dopo aver impostato queste opzioni, è possibile caricare e renderizzare la presentazione usando i caratteri specificati.

## **Utilizzare i caratteri predefiniti per la renderizzazione della presentazione**
Aspose.Slides permette di impostare il carattere predefinito per la renderizzazione della presentazione in PDF, XPS o miniature. Questo articolo mostra come definire DefaultRegularFont e DefaultAsianFont da utilizzare come caratteri predefiniti. Segui i passaggi seguenti per caricare i caratteri da directory esterne usando Aspose.Slides per Python via .NET API:

1. Crea un'istanza di LoadOptions.
1. Imposta DefaultRegularFont sul carattere desiderato. Nell'esempio seguente, è stato usato Wingdings.
1. Imposta DefaultAsianFont sul carattere desiderato. Nell'esempio seguente è stato usato Wingdings.
1. Carica la presentazione usando Presentation e impostando le opzioni di caricamento.
1. Ora genera la miniatura della diapositiva, il PDF e l'XPS per verificare i risultati.

L'implementazione di quanto sopra è mostrata di seguito.

```py
import aspose.slides as slides

# Usa le opzioni di caricamento per definire i caratteri predefiniti regolari e asiatici# Usa le opzioni di caricamento per definire i caratteri predefiniti regolari e asiatici
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Carica la presentazione
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Genera la miniatura della diapositiva
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # Genera PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # Genera XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```

## **FAQ**

**Che cosa influenzano esattamente default_regular_font e default_asian_font—solo l'esportazione o anche miniature, PDF, XPS, HTML e SVG?**

Partecipano al pipeline di renderizzazione per tutti gli output supportati. Questo include le miniature delle diapositive, [PDF](/slides/it/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/it/python-net/convert-powerpoint-to-xps/), [immagini raster](/slides/it/python-net/convert-powerpoint-to-png/), [HTML](/slides/it/python-net/convert-powerpoint-to-html/), e [SVG](/slides/it/python-net/render-a-slide-as-an-svg-image/), perché Aspose.Slides utilizza la stessa logica di layout e risoluzione dei glifi per questi target.

**I caratteri predefiniti vengono applicati quando si legge e si salva semplicemente un PPTX senza alcuna renderizzazione?**

No. I caratteri predefiniti sono rilevanti quando il testo deve essere misurato e disegnato. Un semplice salvataggio aperto‑chiuso di una presentazione non modifica i run di carattere memorizzati né la struttura del file. I caratteri predefiniti entrano in gioco durante le operazioni che renderizzano o riformattano il testo.

**Se aggiungo cartelle di caratteri personalizzate o fornisco caratteri dalla memoria, verranno considerati nella scelta dei caratteri predefiniti?**

Sì. [Custom font sources](/slides/it/python-net/custom-font/) espandono il catalogo di famiglie e glifi disponibili che il motore può utilizzare. I caratteri predefiniti e qualsiasi [fallback rules](/slides/it/python-net/fallback-font/) verranno risolti prima contro tali font, garantendo una copertura più affidabile su server e container.

**I caratteri predefiniti influenzeranno le metriche del testo (kerning, avanzamenti) e quindi le interruzioni di riga e l'andamento?**

Sì. Cambiare il carattere modifica le metriche dei glifi e può alterare interruzioni di riga, avvolgimento e paginazione durante la renderizzazione. Per mantenere la stabilità del layout, [embed the original fonts](/slides/it/python-net/embedded-font/) o scegli famiglie predefinite e di fallback metricamente compatibili.

**Ha senso impostare i caratteri predefiniti se tutti i caratteri usati nella presentazione sono incorporati?**

Spesso non è necessario, perché i [embedded fonts](/slides/it/python-net/embedded-font/) garantiscono già un aspetto coerente. I caratteri predefiniti sono comunque utili come rete di sicurezza per caratteri non coperti dal sottoinsieme incorporato o quando un file combina testo incorporato e non incorporato.