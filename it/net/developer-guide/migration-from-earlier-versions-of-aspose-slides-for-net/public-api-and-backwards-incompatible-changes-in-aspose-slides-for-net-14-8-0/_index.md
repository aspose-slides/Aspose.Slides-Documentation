---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per .NET 14.8.0
linktitle: Aspose.Slides per .NET 14.8.0
type: docs
weight: 100
url: /it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
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
description: "Rivedi gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per .NET per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunti](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) o [rimossi](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/), nonché le altre modifiche introdotte con l'API Aspose.Slides for .NET 14.8.0.

{{% /alert %}} 
## **Modifiche all'API Pubblica**
### **Proprietà Modificate**
#### **Aggiunta l'interfaccia IVbaProject, modificata la proprietà Presentation.VbaProject**
La proprietà VbaProject della classe Presentation è stata sostituita. Invece della rappresentazione in byte grezzo del progetto VBA, è stata aggiunta l'implementazione dell'interfaccia IVbaProject.

Utilizza la proprietà IVbaProject per gestire i progetti VBA incorporati in una presentazione. È possibile aggiungere nuovi riferimenti a progetti, modificare i moduli esistenti e crearne di nuovi.

Inoltre, è possibile creare un nuovo progetto VBA utilizzando la classe VbaProject che implementa l'interfaccia IVbaProject.

Il seguente esempio mostra la creazione di un semplice progetto VBA contenente un modulo e l'aggiunta di due riferimenti richiesti alle librerie.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())

{

    // Crea nuovo progetto VBA
    pres.VbaProject = new VbaProject();
    // Aggiungi modulo vuoto al progetto VBA
    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");
    // Imposta il codice sorgente del modulo
    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Crea riferimento a <stdole>
    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Crea riferimento a Office
    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Aggiungi riferimenti al progetto VBA
    pres.VbaProject.References.Add(stdoleReference);
    pres.VbaProject.References.Add(officeReference);
    pres.Save("test.pptm", SaveFormat.Pptm);

}
``` 

Questo esempio mostra come copiare un progetto VBA da una presentazione esistente a una nuova.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **Aggiunte di Interfacce, Proprietà e Opzioni di Enumerazione**
#### **Aggiunta la proprietà Aspose.Slides.Charts.IChartSeries.Overlap**
La proprietà Aspose.Slides.Charts.IChartSeries.Overlap specifica quanto barre e colonne devono sovrapporsi nei grafici 2D (da -100 a 100).

Questa proprietà non è solo di questa serie ma di tutte le serie nel gruppo di serie genitore – è una proiezione della proprietà del gruppo appropriato. Pertanto, questa proprietà è di sola lettura.

- Usa la proprietà ParentSeriesGroup per accedere al gruppo di serie genitore.
- Usa la proprietà ParentSeriesGroup.Overlap in lettura/scrittura per modificare il valore.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;


 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   if (series[0].Overlap == 0)

      {

            series[0].ParentSeriesGroup.Overlap = -30;

      }

}
``` 
#### **Aggiunta la proprietà Aspose.Slides.Charts.IChartSeriesGroup.Overlap**
La proprietà Aspose.Slides.Charts.IChartSeriesGroup.Overlap specifica quanto barre e colonne devono sovrapporsi nei grafici 2D (da -100 a 100).

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}
``` 
#### **Aggiunto il valore Enum ShapeThumbnailBounds.Appearance**
Questo metodo di creazione di miniature di forma consente di generare una miniatura della forma nei limiti della sua apparenza. Tiene conto di tutti gli effetti della forma. La miniatura generata è limitata ai limiti della diapositiva.

``` csharp
using Aspose.Slides;

using (Presentation p = new Presentation("Presentation.pptx"))
{
    using (IImage image = p.Slides[0].Shapes[0].GetImage(ShapeThumbnailBounds.Appearance, 1, 1))
    {
        image.Save("ShapeThumbnail.png", ImageFormat.Png);
    }
}
```