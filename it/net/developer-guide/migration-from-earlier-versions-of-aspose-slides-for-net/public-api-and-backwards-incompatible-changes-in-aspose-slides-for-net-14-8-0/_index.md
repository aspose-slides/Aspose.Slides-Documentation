---
title: API Pubbliche e Modifiche Incompatibili con le Versioni Precedenti in Aspose.Slides per .NET 14.8.0
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
description: "Rivedi gli aggiornamenti delle API pubbliche e le modifiche breaking in Aspose.Slides per .NET per migrare senza problemi le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 
Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunte](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) o [rimosse](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/), nonché le altre modifiche introdotte con l'API Aspose.Slides for .NET 14.8.0.  
{{% /alert %}} 

## **Modifiche all'API Pubblica**
### **Proprietà Modificate**
#### **Aggiunta l'interfaccia IVbaProject, Modificata la proprietà Presentation.VbaProject**
La proprietà VbaProject della classe Presentation è stata sostituita. Invece della rappresentazione grezza in byte del progetto VBA, è stata aggiunta l'implementazione della nuova interfaccia IVbaProject.

Utilizza la proprietà IVbaProject per gestire i progetti VBA incorporati in una presentazione. Puoi aggiungere nuovi riferimenti al progetto, modificare i moduli esistenti e crearne di nuovi.

Inoltre, puoi creare un nuovo progetto VBA utilizzando la classe VbaProject che implementa l'interfaccia IVbaProject.

L'esempio seguente mostra la creazione di un semplice progetto VBA contenente un modulo e l'aggiunta di due riferimenti richiesti alle librerie.

``` csharp

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

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **Aggiunte di Interfacce, Proprietà e Opzioni di Enumerazione**
#### **Aggiunta la proprietà Aspose.Slides.Charts.IChartSeries.Overlap**
La proprietà Aspose.Slides.Charts.IChartSeries.Overlap specifica quanto le barre e le colonne devono sovrapporsi nei grafici 2D (da -100 a 100).

Questa proprietà non si applica solo a questa serie, ma a tutte le serie nel gruppo di serie padre – è una proiezione della proprietà corrispondente del gruppo. Pertanto, la proprietà è di sola lettura.

- Usa la proprietà ParentSeriesGroup per accedere al gruppo di serie padre.  
- Usa la proprietà ParentSeriesGroup.Overlap (lettura/scrittura) per modificare il valore.

``` csharp

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
La proprietà Aspose.Slides.Charts.IChartSeriesGroup.Overlap specifica quanto le barre e le colonne devono sovrapporsi nei grafici 2D (da -100 a 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **Aggiunto il valore Enum Aspose.Slides.Charts.ShapeThumbnailBounds.Appearance**
Questo metodo di creazione delle miniature di forma consente di generare una miniatura della forma nel contorno della sua apparizione. Tiene conto di tutti gli effetti della forma. La miniatura della forma generata è limitata dai bordi della diapositiva.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```