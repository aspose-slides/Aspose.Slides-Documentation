---
title: Esporta presentazioni in XAML in .NET
linktitle: Presentazione in XAML
type: docs
weight: 30
url: /it/net/export-to-xaml/
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
- .NET
- C#
- Aspose.Slides
description: "Converti le diapositive PowerPoint e OpenDocument in XAML su .NET utilizzando Aspose.Slides—soluzione rapida, senza Office, che conserva intatto il layout."
---
## **Panoramica**

Questo articolo spiega come esportare le presentazioni PowerPoint in XAML utilizzando Aspose.Slides. Include una breve introduzione a XAML, mostra come salvare una presentazione in XAML con le impostazioni predefinite e dimostra come personalizzare l'esportazione tramite [XamlOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export.xaml/xamloptions/), inclusa l'esportazione delle diapositive nascoste. L'articolo risponde inoltre a alcune domande comuni relative ai font di fallback, alla compatibilità con gli stack XAML e al comportamento dell'esportazione delle diapositive nascoste.

## **Informazioni su XAML**

XAML è un linguaggio di programmazione descrittivo che consente di creare o scrivere interfacce utente per le app, specialmente per quelle che utilizzano WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin Forms.  

XAML, che è un linguaggio basato su XML, è la variante Microsoft per descrivere un'interfaccia grafica. È probabile che la maggior parte del tempo utilizzi un designer per lavorare sui file XAML, ma è comunque possibile scrivere e modificare la tua interfaccia grafica.

## **Esporta presentazioni in XAML con opzioni predefinite**

Questo codice C# mostra come esportare una presentazione in XAML con le impostazioni predefinite:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## **Esporta presentazioni in XAML con opzioni personalizzate**

Puoi selezionare le opzioni dall'interfaccia [IXamlOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export.xaml/ixamloptions) che controllano il processo di esportazione e determinano come Aspose.Slides esporta la tua presentazione in XAML. 

Ad esempio, se desideri che Aspose.Slides aggiunga le diapositive nascoste dalla tua presentazione durante l'esportazione in XAML, puoi impostare la proprietà [ExportHiddenSlides](https://reference.aspose.com/slides/it/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) su true. Vedi questo esempio di codice C#:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```

## **FAQ**

**Come posso garantire font prevedibili se il font originale non è disponibile sul computer?**

Imposta [DefaultRegularFont](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveoptions/defaultregularfont/) in [XamlOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export.xaml/xamloptions/) — viene usato come font di riserva quando l'originale è mancante. Questo aiuta a evitare sostituzioni inattese.

**Il XAML esportato è destinato solo a WPF o può essere utilizzato anche in altri stack XAML?**

XAML è un linguaggio di markup UI generico usato in WPF, UWP e Xamarin.Forms. L'esportazione mira alla compatibilità con gli stack XAML di Microsoft; il comportamento esatto e il supporto per costrutti specifici dipendono dalla piattaforma di destinazione. Verifica il markup nel tuo ambiente.

**Le diapositive nascoste sono supportate e come posso impedirne l'esportazione per impostazione predefinita?**

Per impostazione predefinita, le diapositive nascoste non sono incluse. Puoi controllare questo comportamento tramite [ExportHiddenSlides](https://reference.aspose.com/slides/it/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export.xaml/xamloptions/) — mantienila disabilitata se non hai bisogno di esportarle.