---
title: Esporta presentazioni in XAML con JavaScript
linktitle: Presentazione in XAML
type: docs
weight: 30
url: /it/nodejs-java/export-to-xaml/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti diapositive PowerPoint e OpenDocument in XAML con JavaScript usando Aspose.Slides per Node.js—soluzione rapida, senza Office, che mantiene intatto il layout."
---
## **Panoramica**

Questo articolo spiega come esportare presentazioni PowerPoint in XAML utilizzando Aspose.Slides. Include una breve introduzione a XAML, mostra come salvare una presentazione in XAML con le impostazioni predefinite e dimostra come personalizzare l'esportazione tramite [XamlOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/xamloptions/), inclusa l'esportazione delle diapositive nascoste. L'articolo risponde anche ad alcune domande comuni relative ai caratteri di fallback, alla compatibilità con le stack XAML e al comportamento di esportazione delle diapositive nascoste.

## **Informazioni su XAML**

XAML è un linguaggio di programmazione descrittivo che consente di creare o scrivere classi utente per le app, in particolare quelle che utilizzano WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin.Forms.

XAML, che è un linguaggio basato su XML, è la variante Microsoft per descrivere un'interfaccia grafica. È probabile che la maggior parte delle volte utilizzi un designer per lavorare sui file XAML, ma puoi comunque scrivere e modificare la tua interfaccia grafica. 

## **Esportare le presentazioni in XAML con le opzioni predefinite**

Questo codice JavaScript mostra come esportare una presentazione in XAML con le impostazioni predefinite:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Esportare le presentazioni in XAML con opzioni personalizzate**

Puoi selezionare le opzioni dalla classe XamlOptions che controllano il processo di esportazione e determinano come Aspose.Slides esporta la tua presentazione in XAML.

Ad esempio, se desideri che Aspose.Slides aggiunga le diapositive nascoste della tua presentazione durante l'esportazione in XAML, puoi impostare il metodo [setExportHiddenSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) su true. Vedi questo esempio di codice JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Come posso garantire caratteri prevedibili se il carattere originale non è disponibile sulla macchina?**

Utilizza [setDefaultRegularFont](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [XamlOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/xamloptions/) — viene usato come carattere di fallback quando quello originale è mancante. Questo aiuta a evitare sostituzioni inaspettate.

**Il XAML esportato è destinato solo a WPF o può essere utilizzato anche in altri stack XAML?**

XAML è un linguaggio di markup UI generico usato in WPF, UWP e Xamarin.Forms. L'esportazione mira alla compatibilità con gli stack XAML di Microsoft; il comportamento preciso e il supporto per costrutti specifici dipendono dalla piattaforma di destinazione. Prova il markup nel tuo ambiente.

**Le diapositive nascoste sono supportate e come posso impedire che vengano esportate per impostazione predefinita?**

Per impostazione predefinita, le diapositive nascoste non sono incluse. Puoi controllare questo comportamento tramite [setExportHiddenSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/xamloptions/) — lascialo disabilitato se non è necessario esportarle.