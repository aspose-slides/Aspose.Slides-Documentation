---
title: Esporta presentazioni in XAML in Java
linktitle: Presentazione in XAML
type: docs
weight: 30
url: /it/java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Converti le diapositive PowerPoint e OpenDocument in XAML con Java usando Aspose.Slides - soluzione rapida, senza Office, che mantiene intatto il layout."
---
## **Panoramica**

Questo articolo spiega come esportare presentazioni PowerPoint in XAML utilizzando Aspose.Slides. Include una breve introduzione a XAML, mostra come salvare una presentazione in XAML con le impostazioni predefinite e dimostra come personalizzare l'esportazione tramite [XamlOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/xamloptions/), includendo l'esportazione delle diapositive nascoste. L'articolo risponde anche a alcune domande comuni relative ai caratteri di fallback, alla compatibilità con le stack XAML e al comportamento dell'esportazione delle diapositive nascoste.

## **Informazioni su XAML**

XAML è un linguaggio di programmazione descrittivo che consente di creare o scrivere interfacce utente per le app, soprattutto per quelle che utilizzano WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin Forms.  

XAML, che è un linguaggio basato su XML, è la variante Microsoft per descrivere un'interfaccia grafica. È probabile che la maggior parte del tempo tu utilizzi un designer per lavorare sui file XAML, ma puoi comunque scrivere e modificare la tua interfaccia grafica. 

## **Esporta presentazioni in XAML con opzioni predefinite**

Questo codice Java mostra come esportare una presentazione in XAML con le impostazioni predefinite:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **Esporta presentazioni in XAML con opzioni personalizzate**

Puoi selezionare le opzioni dall'interfaccia [IXamlOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/IXamlOptions) che controllano il processo di esportazione e determinano come Aspose.Slides esporta la tua presentazione in XAML. 

Ad esempio, se desideri che Aspose.Slides aggiunga le diapositive nascoste dalla tua presentazione durante l'esportazione in XAML, puoi impostare la proprietà [ExportHiddenSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) su true. Vedi questo esempio di codice Java: 

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

Imposta [un carattere regolare predefinito](https://reference.aspose.com/slides/it/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) in [XamlOptions] — viene utilizzato come carattere di fallback quando quello originale è mancante. Ciò aiuta a evitare sostituzioni inaspettate.

**L'XAML esportato è destinato solo a WPF o può essere utilizzato anche in altre stack XAML?**

XAML è un linguaggio di markup UI generale utilizzato in WPF, UWP e Xamarin.Forms. L'esportazione punta alla compatibilità con le stack XAML di Microsoft; il comportamento esatto e il supporto per costrutti specifici dipendono dalla piattaforma di destinazione. Prova il markup nel tuo ambiente.

**Le diapositive nascoste sono supportate e come posso impedire che vengano esportate per impostazione predefinita?**

Per impostazione predefinita, le diapositive nascoste non sono incluse. Puoi controllare questo comportamento tramite [setExportHiddenSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) in [XamlOptions] — mantienila disabilitata se non è necessario esportarle.