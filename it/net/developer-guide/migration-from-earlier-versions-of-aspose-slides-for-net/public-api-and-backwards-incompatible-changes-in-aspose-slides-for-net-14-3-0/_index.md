---
title: API Pubblica e Modifiche Incompatibili Retroattive in Aspose.Slides per .NET 14.3.0
linktitle: Aspose.Slides per .NET 14.3.0
type: docs
weight: 50
url: /it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- migrazione
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
description: "Rivedi gli aggiornamenti dell'API pubblica e le modifiche breaking in Aspose.Slides per .NET per migrare senza problemi le soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
## **API Pubblica e Modifiche Incompatibili Retroattive**
### **Enumerazione Aspose.Slides.ShapeThumbnailBounds e Metodi Aspose.Slides.IShape.GetThumbnail() aggiunti**
I metodi GetThumbnail() e GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) sono utilizzati per creare una miniatura separata di forma. L'enumerazione ShapeThumbnailBounds definisce i possibili tipi di limiti della miniatura della forma.

### **Proprietà UniqueId aggiunta a Aspose.Slides.IShape**
La proprietà Aspose.Slides.IShape.UniqueId fornisce un identificatore di forma unico nell'ambito della presentazione. Questi identificatori unici sono memorizzati nei tag personalizzati della forma.

### **Firma del metodo SetGroupingItem modificata in IChartCategoryLevelsManager**
Firma del metodo IChartCategoryLevelsManager

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 
è ora obsoleta e sostituita dalla firma

``` csharp

 void SetGroupingItem(int level, object value);

``` 
Ora le chiamate come

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 
devono essere modificate in chiamate come

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 
Passare un valore come "Group 1" a SetGroupingItem ma non un valore di tipo IChartDataCell. La creazione di IChartDataCell con un foglio di lavoro, riga e colonna definiti per i livelli di categoria deve soddisfare alcuni requisiti ed è stata incapsulata nel metodo SetGroupingItem(int, object).

### **Proprietà SlideId aggiunta all'interfaccia Aspose.Slides.IBaseSlide**
La proprietà SlideId fornisce un identificatore di diapositiva unico.

### **Proprietà SoundName aggiunta a ISlideShowTransition**
Stringa leggibile e scrivibile. Specifica un nome leggibile dall'utente per il suono della transizione. La proprietà Sound deve essere assegnata per ottenere o impostare il nome del suono. Questo nome appare nell'interfaccia utente di PowerPoint quando si configura manualmente il suono della transizione. Può generare PptxException se la proprietà Sound non è assegnata.

### **Tipo della proprietà ChartSeriesGroup.Type modificato**
La proprietà ChartSeriesGroup.Type è stata modificata dall'enumerazione ChartType alla nuova enumerazione CombinableSeriesTypesGroup. L'enumerazione CombinableSeriesTypesGroup rappresenta i gruppi di tipi di serie combinabili.

### **Aggiunto il supporto per la generazione di miniature individuali di forma**
Aspose.Slides.ShapeThumbnailBounds

Nuovi membri in Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)