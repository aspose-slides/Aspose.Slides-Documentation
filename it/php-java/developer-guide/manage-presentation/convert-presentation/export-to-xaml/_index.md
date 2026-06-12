---
title: Esporta presentazioni in XAML in PHP
linktitle: Presentazione in XAML
type: docs
weight: 30
url: /it/php-java/export-to-xaml/
keywords:
- esporta PowerPoint
- esporta OpenDocument
- esporta presentazione
- converti PowerPoint
- converti OpenDocument
- converti presentazione
- PowerPoint in XAML
- OpenDocument in XAML
- presentazione in XAML
- PPT in XAML
- PPTX in XAML
- ODP in XAML
- salva PPT come XAML
- salva PPTX come XAML
- salva ODP come XAML
- esporta PPT in XAML
- esporta PPTX in XAML
- esporta ODP in XAML
- PHP
- Aspose.Slides
description: "Converti diapositive PowerPoint e OpenDocument in XAML usando Aspose.Slides per PHP via Java — soluzione rapida, senza Office, che mantiene intatto il layout."
---
## **Panoramica**

Questo articolo spiega come esportare presentazioni PowerPoint in XAML usando Aspose.Slides. Include una breve introduzione a XAML, mostra come salvare una presentazione in XAML con le impostazioni predefinite e dimostra come personalizzare l'esportazione tramite [XamlOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/xamloptions/), inclusa l'esportazione delle diapositive nascoste. L'articolo risponde anche a qualche domanda frequente relativa ai font di fallback, alla compatibilità con gli stack XAML e al comportamento dell'esportazione delle diapositive nascoste.

## **Informazioni su XAML**

XAML è un linguaggio di programmazione descrittivo che consente di creare o scrivere interfacce utente per le app, in particolare quelle che utilizzano WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin Forms.  
XAML, che è un linguaggio basato su XML, è la variante Microsoft per descrivere un'interfaccia grafica. È probabile che tu utilizzi un designer per lavorare sui file XAML nella maggior parte dei casi, ma puoi comunque scrivere e modificare la tua interfaccia grafica.

## **Esporta presentazioni in XAML con opzioni predefinite**

Questo codice PHP mostra come esportare una presentazione in XAML con le impostazioni predefinite:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Esporta presentazioni in XAML con opzioni personalizzate**

Puoi selezionare le opzioni dalla classe [XamlOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/xamloptions/) che controllano il processo di esportazione e determinano come Aspose.Slides esporta la tua presentazione in XAML.

Ad esempio, se desideri che Aspose.Slides aggiunga le diapositive nascoste dalla tua presentazione durante l'esportazione in XAML, puoi usare il metodo [setExportHiddenSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/xamloptions/setexporthiddenslides/) con il valore `true`. Vedi questo esempio di codice PHP:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Come posso garantire l'uso di font prevedibili se il font originale non è disponibile sulla macchina?**

Imposta [un font regolare predefinito](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [XamlOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/xamloptions/) — viene utilizzato come font di fallback quando quello originale è mancante. Questo aiuta a evitare sostituzioni inaspettate.

**L'XAML esportato è destinato solo a WPF o può essere utilizzato anche in altri stack XAML?**

XAML è un linguaggio di markup UI generico usato in WPF, UWP e Xamarin.Forms. L'esportazione punta alla compatibilità con gli stack XAML di Microsoft; il comportamento esatto e il supporto per costrutti specifici dipendono dalla piattaforma di destinazione. Verifica il markup nel tuo ambiente.

**Le diapositive nascoste sono supportate e come posso impedirne l'esportazione per impostazione predefinita?**

Per impostazione predefinita, le diapositive nascoste non sono incluse. Puoi controllare questo comportamento tramite [setExportHiddenSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/xamloptions/setexporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/xamloptions/) — mantienilo disabilitato se non è necessario esportarle.