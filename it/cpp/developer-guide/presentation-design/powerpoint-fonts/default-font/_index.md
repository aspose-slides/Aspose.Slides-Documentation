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
description: "Imposta i caratteri predefiniti in Aspose.Slides per C++ per garantire una corretta conversione di PowerPoint (PPT, PPTX) e OpenDocument (ODP) in PDF, XPS e immagini."
---
## **Panoramica**

Aspose.Slides consente di specificare i caratteri predefiniti che vengono usati quando una presentazione viene renderizzata. Questo è utile durante la generazione di miniature delle diapositive o l'esportazione di una presentazione in formati come PDF e XPS. I caratteri predefiniti sono configurati tramite `LoadOptions` prima del caricamento della presentazione.

Il metodo `set_DefaultRegularFont` definisce il carattere predefinito per il testo normale, mentre `set_DefaultAsianFont` definisce il carattere predefinito per il testo asiatico. Dopo aver impostato queste opzioni, la presentazione può essere caricata e renderizzata utilizzando i caratteri specificati.

## **Utilizzare i caratteri predefiniti per il rendering di una presentazione**
Aspose.Slides ti permette di impostare il carattere predefinito per il rendering della presentazione in PDF, XPS o miniature. Questo articolo mostra come definire DefaultRegularFont e DefaultAsianFont da utilizzare come caratteri predefiniti. Segui i passaggi seguenti per caricare i caratteri da directory esterne usando l'API Aspose.Slides per C++:

1. Creare un'istanza di LoadOptions.  
2. Impostare DefaultRegularFont sul carattere desiderato. Nell'esempio seguente ho usato Wingdings.  
3. Impostare DefaultAsianFont sul carattere desiderato. Ho usato Wingdings nel campione seguente.  
4. Caricare la presentazione usando Presentation e impostando le opzioni di caricamento.  
5. Ora, generare la miniatura della diapositiva, PDF e XPS per verificare i risultati.

L'implementazione di quanto sopra è mostrata di seguito.

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

**Cosa influenzano esattamente DefaultRegularFont e DefaultAsianFont—solo l'esportazione o anche le miniature, PDF, XPS, HTML e SVG?**

Partecipano al flusso di rendering per tutti gli output supportati. Ciò include le miniature delle diapositive, [PDF](/slides/it/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/it/cpp/convert-powerpoint-to-xps/), [immagini raster](/slides/it/cpp/convert-powerpoint-to-png/), [HTML](/slides/it/cpp/convert-powerpoint-to-html/) e [SVG](/slides/it/cpp/render-a-slide-as-an-svg-image/), perché Aspose.Slides utilizza la stessa logica di layout e risoluzione dei glifi per questi target.

**Le font predefinite vengono applicate quando si legge e si salva semplicemente un PPTX senza alcun rendering?**

No. Le font predefinite entrano in gioco quando il testo deve essere misurato e disegnato. Un semplice salvataggio aperto‑chiuso di una presentazione non modifica le sequenze di carattere memorizzate né la struttura del file. Le font predefinite vengono utilizzate durante operazioni che renderizzano o riorganizzano il testo.

**Se aggiungo le mie cartelle di font o fornisco font dalla memoria, verranno considerati nella scelta dei font predefiniti?**

Sì. [Font personalizzati](/slides/it/cpp/custom-font/) ampliano il catalogo di famiglie e glifi disponibili che il motore può utilizzare. Le font predefinite e qualsiasi [regole di fallback](/slides/it/cpp/fallback-font/) verranno risolte prima contro tali font, garantendo una copertura più affidabile su server e container.

**Le font predefinite influenzeranno le metriche del testo (kerning, advance) e quindi le interruzioni di linea e l'avvolgimento?**

Sì. Cambiare il carattere modifica le metriche dei glifi e può alterare le interruzioni di linea, l'avvolgimento e la paginazione durante il rendering. Per la stabilità del layout, [incorporare i font originali](/slides/it/cpp/embedded-font/) o selezionare famiglie predefinite e di fallback metricamente compatibili.

**C'è qualche motivo per impostare font predefiniti se tutti i caratteri usati nella presentazione sono incorporati?**

Spesso non è necessario, perché [font incorporati](/slides/it/cpp/embedded-font/) assicurano già un aspetto coerente. Le font predefinite sono comunque utili come rete di sicurezza per i caratteri non coperti dal sottoinsieme incorporato o quando un file mescola testo incorporato e non incorporato.