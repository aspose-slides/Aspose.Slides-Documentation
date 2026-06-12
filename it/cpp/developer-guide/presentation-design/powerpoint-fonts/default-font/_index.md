---
title: Specificare i caratteri predefiniti della presentazione in C++
linktitle: Carattere predefinito
type: docs
weight: 30
url: /it/cpp/default-font/
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
- C++
- Aspose.Slides
description: "Imposta i caratteri predefiniti in Aspose.Slides per C++ per garantire la corretta conversione di PowerPoint (PPT, PPTX) e OpenDocument (ODP) in PDF, XPS e immagini."
---
## **Panoramica**

Aspose.Slides consente di specificare i caratteri predefiniti utilizzati quando una presentazione viene renderizzata. Questo è utile durante la generazione di miniature delle diapositive o l'esportazione di una presentazione in formati come PDF e XPS. I caratteri predefiniti vengono configurati tramite `LoadOptions` prima del caricamento della presentazione.

Il metodo `set_DefaultRegularFont` definisce il carattere predefinito per il testo normale, mentre `set_DefaultAsianFont` definisce il carattere predefinito per il testo asiatico. Dopo aver impostato queste opzioni, la presentazione può essere caricata e renderizzata usando i caratteri specificati.

## **Usare i caratteri predefiniti per il rendering di una presentazione**
Aspose.Slides consente di impostare il carattere predefinito per il rendering della presentazione in PDF, XPS o miniature. Questo articolo mostra come definire DefaultRegularFont e DefaultAsianFont per usarli come caratteri predefiniti. Segui i passaggi seguenti per caricare i caratteri da directory esterne utilizzando l'API Aspose.Slides per C++:

1. Crea un'istanza di LoadOptions.  
1. Imposta DefaultRegularFont sul carattere desiderato. Nell'esempio seguente, ho usato Wingdings.  
1. Imposta DefaultAsianFont sul carattere desiderato. Ho usato Wingdings nel campione seguente.  
1. Carica la presentazione usando Presentation e impostando le opzioni di caricamento.  
1. Ora, genera la miniatura della diapositiva, PDF e XPS per verificare i risultati.

L'implementazione di quanto sopra è fornita di seguito.

```cpp
// Usa le opzioni di caricamento per specificare i caratteri predefiniti regolari e asiatici
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```

## **FAQ**

**Che cosa influenzano esattamente DefaultRegularFont e DefaultAsianFont — solo l'esportazione o anche le miniature, PDF, XPS, HTML e SVG?**

Partecipano al pipeline di rendering per tutti gli output supportati. Questo include le miniature delle diapositive, [PDF](/slides/it/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/it/cpp/convert-powerpoint-to-xps/), [immagini raster](/slides/it/cpp/convert-powerpoint-to-png/), [HTML](/slides/it/cpp/convert-powerpoint-to-html/), e [SVG](/slides/it/cpp/render-a-slide-as-an-svg-image/), perché Aspose.Slides utilizza la stessa logica di layout e risoluzione dei glifi per questi target.

**I caratteri predefiniti vengono applicati quando si legge e salva semplicemente un PPTX senza alcun rendering?**

No. I caratteri predefiniti entrano in gioco quando il testo deve essere misurato e disegnato. Un semplice salvataggio aperto‑chiuso di una presentazione non modifica le sequenze di caratteri memorizzate né la struttura del file. I caratteri predefiniti sono usati durante le operazioni che renderizzano o riformattano il testo.

**Se aggiungo le mie cartelle di font o fornisco font dalla memoria, verranno considerati nella scelta dei caratteri predefiniti?**

Sì. [Custom font sources](/slides/it/cpp/custom-font/) ampliano il catalogo di famiglie e glifi disponibili per il motore. I caratteri predefiniti e qualsiasi [fallback rules](/slides/it/cpp/fallback-font/) verranno risolti contro tali font prima, garantendo una copertura più affidabile su server e container.

**I caratteri predefiniti influiscono sulle metriche del testo (kerning, advance) e quindi su interruzioni di riga e avvolgimento?**

Sì. Cambiare il carattere modifica le metriche dei glifi e può alterare le interruzioni di riga, l'avvolgimento e la paginazione durante il rendering. Per una stabilità del layout, [embed the original fonts](/slides/it/cpp/embedded-font/) o scegli famiglie predefinite e di fallback metricamente compatibili.

**Ha senso impostare i caratteri predefiniti se tutti i caratteri usati nella presentazione sono incorporati?**

Spesso non è necessario, perché [embedded fonts](/slides/it/cpp/embedded-font/) assicurano già un aspetto coerente. I caratteri predefiniti servono comunque come rete di sicurezza per i caratteri non coperti dal sottoinsieme incorporato o quando un file mescola testo incorporato e non incorporato.