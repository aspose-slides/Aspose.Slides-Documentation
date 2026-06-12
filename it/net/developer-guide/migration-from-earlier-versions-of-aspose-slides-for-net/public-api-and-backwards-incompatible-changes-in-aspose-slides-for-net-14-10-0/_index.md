---
title: API pubbliche e modifiche non retrocompatibili in Aspose.Slides per .NET 14.10.0
linktitle: Aspose.Slides per .NET 14.10.0
type: docs
weight: 120
url: /it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
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
description: "Rivedi gli aggiornamenti dell'API pubblica e le modifiche breaking in Aspose.Slides per .NET per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunti](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) o [rimossi](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/), e le altre modifiche introdotte con l'API di Aspose.Slides per .NET 14.10.0 API.

{{% /alert %}} 
## **Modifiche API Pubblica**
#### **Il tipo di campo Aspose.Slides.FieldType.Footer è stato aggiunto**
Il tipo di campo Footer è stato aggiunto per consentire l'implementazione della possibilità di creare campi di questo tipo e per una corretta serializzazione delle presentazioni.
#### **Elemento enum ShapeElementFillSource.Own eliminato**
L'elemento enum ShapeElementFillSource.Own è stato eliminato perché duplicato. Utilizzare ShapeElementFillSource.Shape al posto di ShapeElementFillSource.Own.
#### **Aggiunti metodi per rimuovere punti dati e categorie del grafico**
Sono stati aggiunti i seguenti metodi, che consentono di rimuovere un punto dati del grafico da una raccolta di punti dati del grafico:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

È stato aggiunto il seguente metodo, che consente di rimuovere una categoria del grafico dalla raccolta contenente:

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);
    chart.ChartData.Categories[0].Remove(); //rimuovi con ChartCategory.Remove()
    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //rimuovi con ChartCategoryCollection.Remove()
    foreach (var ser in chart.ChartData.Series)
    {
        ser.DataPoints[0].Remove();//rimuovi con ChartDataPoint.Remove()
        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()
    }
    pres.Save(outPath, SaveFormat.Pptx);
}
``` 
#### **Rimosse proprietà obsolete di Aspose.Slides.ParagraphFormat**
Le proprietà BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle sono state rimosse. Erano state segnate come obsolete molto tempo fa.
#### **Rimossi costruttori inutili e obsoleti**
Sono stati rimossi i seguenti costruttori:

- Aspose.Slides.Effects.AlphaBiLevel(System.Single)
- Aspose.Slides.Effects.AlphaModulateFixed(System.Single)
- Aspose.Slides.Effects.AlphaReplace(System.Single)
- Aspose.Slides.Effects.BiLevel(System.Single)
- Aspose.Slides.Effects.Blur(System.Double,System.Boolean)
- Aspose.Slides.Effects.HSL(System.Single,System.Single,System.Single)
- Aspose.Slides.Effects.ImageTransformOperation(Aspose.Slides.Effects.ImageTransformOperationCollection)
- Aspose.Slides.Effects.Luminance(System.Single,System.Single)
- Aspose.Slides.Effects.Tint(System.Single,System.Single)
- Aspose.Slides.PortionFormat(Aspose.Slides.ParagraphFormat)
- Aspose.Slides.PortionFormat(Aspose.Slides.Portion)
- Aspose.Slides.PortionFormat(Aspose.Slides.PortionFormat)