---
title: Esporta presentazioni in XAML su Android
linktitle: Presentazione in XAML
type: docs
weight: 30
url: /it/androidjava/export-to-xaml/
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
- Android
- Java
- Aspose.Slides
description: "Converti diapositive PowerPoint e OpenDocument in XAML con Java usando Aspose.Slides per Android—soluzione veloce e senza Office che mantiene intatto il layout."
---
## **Panoramica**

Questo articolo spiega come esportare presentazioni PowerPoint in XAML utilizzando Aspose.Slides. Include una breve introduzione a XAML, mostra come salvare una presentazione in XAML con le impostazioni predefinite e dimostra come personalizzare l'esportazione tramite [XamlOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/xamloptions/), includendo l'esportazione delle diapositive nascoste. L'articolo risponde anche a diverse domande comuni relative ai caratteri di riserva, alla compatibilità con i vari stack XAML e al comportamento dell'esportazione delle diapositive nascoste.

## **Informazioni su XAML**

XAML è un linguaggio di programmazione descrittivo che consente di creare o scrivere interfacce utente per app, soprattutto quelle che utilizzano WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin Forms.  

XAML, che è un linguaggio basato su XML, è la variante Microsoft per descrivere una GUI. È probabile che la maggior parte del tempo utilizzi un designer per lavorare sui file XAML, ma puoi comunque scrivere e modificare la tua interfaccia grafica.

## **Esporta le presentazioni in XAML con le opzioni predefinite**

Questo codice Java mostra come esportare una presentazione in XAML con le impostazioni predefinite:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **Esporta le presentazioni in XAML con opzioni personalizzate**

Puoi selezionare le opzioni dall'interfaccia [IXamlOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IXamlOptions) che controllano il processo di esportazione e determinano come Aspose.Slides esporta la tua presentazione in XAML.

Ad esempio, se desideri che Aspose.Slides aggiunga le diapositive nascoste dalla tua presentazione durante l'esportazione in XAML, puoi impostare la proprietà [ExportHiddenSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) su true. Vedi questo codice Java di esempio:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

## **FAQ**

**Come posso garantire caratteri prevedibili se il carattere originale non è disponibile sulla macchina?**

Imposta un [carattere regolare predefinito](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) in [XamlOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/xamloptions/) — viene usato come carattere di riserva quando quello originale è assente. Questo aiuta a evitare sostituzioni inattese.

**Lo XAML esportato è destinato solo a WPF o può essere utilizzato anche in altri stack XAML?**

XAML è un linguaggio di markup UI generico usato in WPF, UWP e Xamarin.Forms. L'esportazione mira alla compatibilità con gli stack XAML di Microsoft; il comportamento esatto e il supporto per costrutti specifici dipendono dalla piattaforma di destinazione. Verifica il markup nel tuo ambiente.

**Le diapositive nascoste sono supportate e come posso impedire che vengano esportate per impostazione predefinita?**

Per impostazione predefinita, le diapositive nascoste non sono incluse. Puoi controllare questo comportamento tramite [setExportHiddenSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) in [XamlOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/xamloptions/) — mantienila disabilitata se non è necessario esportarle.