---
title: Specificare i caratteri predefiniti della presentazione in PHP
linktitle: Carattere predefinito
type: docs
weight: 30
url: /it/php-java/default-font/
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
- PHP
- Aspose.Slides
description: "Imposta i caratteri predefiniti in Aspose.Slides per PHP tramite Java per garantire una corretta conversione di PowerPoint (PPT, PPTX) e OpenDocument (ODP) in PDF, XPS e immagini."
---
## **Panoramica**

Aspose.Slides consente di specificare i caratteri predefiniti utilizzati quando una presentazione viene renderizzata. Ciò è utile durante la generazione delle miniature delle diapositive o l'esportazione di una presentazione in formati come PDF e XPS. I caratteri predefiniti vengono configurati tramite `LoadOptions` prima del caricamento della presentazione.

Il metodo `setDefaultRegularFont` definisce il carattere predefinito per il testo normale, mentre `setDefaultAsianFont` definisce il carattere predefinito per il testo asiatico. Dopo aver impostato queste opzioni, la presentazione può essere caricata e renderizzata utilizzando i caratteri specificati.

## **Utilizzare i caratteri predefiniti per la renderizzazione di una presentazione**
Aspose.Slides consente di impostare il carattere predefinito per la renderizzazione della presentazione in PDF, XPS o miniature. Questo articolo mostra come definire DefaultRegularFont e DefaultAsianFont per l'uso come caratteri predefiniti. Si prega di seguire i passaggi seguenti per caricare i caratteri da directory esterne utilizzando Aspose.Slides per PHP tramite l'API Java:

1. Creare un'istanza di [LoadOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/LoadOptions).
1. [Imposta il DefaultRegularFont](https://reference.aspose.com/slides/it/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) al carattere desiderato. Nell'esempio seguente, ho usato Wingdings.
1. [Imposta il DefaultAsianFont](https://reference.aspose.com/slides/it/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) al carattere desiderato. Ho usato Wingdings nel campione seguente.
1. Caricare la presentazione utilizzando Presentation e impostando le opzioni di caricamento.
1. Ora, generare la miniatura della diapositiva, PDF e XPS per verificare i risultati.

L'implementazione di quanto sopra è fornita di seguito.

```php
  # Usa le opzioni di caricamento per definire i caratteri predefiniti regolari e asiatici
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # Carica la presentazione
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # Genera la miniatura della diapositiva
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # salva l'immagine su disco.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Genera PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # Genera XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Che cosa influiscono esattamente DefaultRegularFont e DefaultAsianFont — solo l'esportazione o anche le miniature, PDF, XPS, HTML e SVG?**

Partecipano al pipeline di renderizzazione per tutti gli output supportati. Ciò include le miniature delle diapositive, [PDF](/slides/it/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/it/php-java/convert-powerpoint-to-xps/), [immagini raster](/slides/it/php-java/convert-powerpoint-to-png/), [HTML](/slides/it/php-java/convert-powerpoint-to-html/), e [SVG](/slides/it/php-java/render-a-slide-as-an-svg-image/), perché Aspose.Slides utilizza la stessa logica di layout e risoluzione dei glifi tra questi target.

**I caratteri predefiniti vengono applicati durante la semplice lettura e salvataggio di un PPTX senza alcuna renderizzazione?**

No. I caratteri predefiniti sono rilevanti quando il testo deve essere misurato e disegnato. Un semplice apri‑salva di una presentazione non modifica le sequenze di carattere memorizzate né la struttura del file. I caratteri predefiniti entrano in gioco durante le operazioni che renderizzano o riformattano il testo.

**Se aggiungo le mie cartelle di caratteri o fornisco caratteri dalla memoria, verranno considerati nella scelta dei caratteri predefiniti?**

Sì. [Custom font sources](/slides/it/php-java/custom-font/) ampliano il catalogo delle famiglie e dei glifi disponibili che il motore può utilizzare. I caratteri predefiniti e qualsiasi [fallback rules](/slides/it/php-java/fallback-font/) verranno risolti prima rispetto a queste sorgenti, garantendo una copertura più affidabile su server e nei container.

**I caratteri predefiniti influiranno sulle metriche del testo (kerning, avanzamenti) e quindi su interruzioni di riga e avvolgimento?**

Sì. Cambiare il carattere modifica le metriche dei glifi e può alterare le interruzioni di riga, l'avvolgimento e l'impaginazione durante la renderizzazione. Per la stabilità del layout, [embed the original fonts](/slides/it/php-java/embedded-font/) o seleziona famiglie predefinite e di fallback metricamente compatibili.

**Ha senso impostare i caratteri predefiniti se tutti i caratteri usati nella presentazione sono incorporati?**

Spesso non è necessario, perché [embedded fonts](/slides/it/php-java/embedded-font/) garantiscono già un aspetto coerente. I caratteri predefiniti sono comunque utili come rete di sicurezza per i caratteri non coperti dal sottoinsieme incorporato o quando un file mescola testo incorporato e non incorporato.