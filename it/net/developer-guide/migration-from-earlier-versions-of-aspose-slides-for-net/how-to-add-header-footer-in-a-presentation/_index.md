---
title: Come aggiungere intestazioni e piè di pagina alle presentazioni in .NET
linktitle: Aggiungi intestazione e piè di pagina
type: docs
weight: 20
url: /it/net/how-to-add-header-footer-in-a-presentation/
keywords:
- migrazione
- aggiungere intestazione
- aggiungere piè di pagina
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come aggiungere intestazioni e piè di pagina nelle presentazioni PowerPoint PPT, PPTX e ODP in .NET utilizzando sia le API legacy che quelle moderne di Aspose.Slides."
---
{{% alert color="primary" %}}
È stata rilasciata una nuova [Aspose.Slides for .NET API](/slides/it/net/) e ora questo unico prodotto supporta la generazione di documenti PowerPoint da zero e la modifica di quelli esistenti.
{{% /alert %}}
## **Supporto per il codice legacy**
Per utilizzare il codice legacy sviluppato con le versioni di Aspose.Slides per .NET precedenti alla 13.x, è necessario apportare alcune piccole modifiche al proprio codice affinché continui a funzionare come prima. Tutte le classi presenti nella vecchia Aspose.Slides per .NET nei namespace Aspose.Slide e Aspose.Slides.Pptx sono ora unite in un unico namespace Aspose.Slides. Si prega di consultare il seguente semplice snippet di codice per aggiungere intestazione e piè di pagina nella presentazione nell'API legacy di Aspose.Slides e seguire i passaggi che descrivono come migrare alla nuova API unificata.
## **Approccio legacy di Aspose.Slides per .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Impostazione delle proprietà di visibilità dell'intestazione e del piè di pagina
sourcePres.UpdateSlideNumberFields = true;

//Aggiorna i campi data e ora
sourcePres.UpdateDateTimeFields = true;

//Mostra il segnaposto data e ora
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Mostra il segnaposto piè di pagina
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Mostra il numero della diapositiva
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Imposta la visibilità dell'intestazione e del piè di pagina nella diapositiva titolo
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Scrivi la presentazione su disco
sourcePres.Write("NewSource.pptx");
```

```c#
//Crea la presentazione
Presentation pres = new Presentation();

//Ottieni la prima diapositiva
Slide sld = pres.GetSlideByPosition(1);

//Accedi all'intestazione / piè di pagina della diapositiva
HeaderFooter hf = sld.HeaderFooter;

//Imposta la visibilità del numero di pagina
hf.PageNumberVisible = true;

//Imposta la visibilità del piè di pagina
hf.FooterVisible = true;

//Imposta la visibilità dell'intestazione
hf.HeaderVisible = true;

//Imposta la visibilità della data e ora
hf.DateTimeVisible = true;

//Imposta il formato della data e ora
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Imposta il testo dell'intestazione
hf.HeaderText = "Header Text";

//Imposta il testo del piè di pagina
hf.FooterText = "Footer Text";

//Scrivi la presentazione su disco
pres.Write("HeadFoot.ppt");
```


## **Nuovo approccio di Aspose.Slides per .NET 13.x**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Impostazione delle proprietà di visibilità dell'intestazione e del piè di pagina
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Aggiorna i campi data e ora
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Mostra il segnaposto data e ora
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Mostra il segnaposto del piè di pagina
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Imposta la visibilità dell'intestazione e del piè di pagina nella diapositiva titolo
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Scrivi la presentazione su disco
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```