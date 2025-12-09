---
title: API publique et modifications incompatibles rétroactives dans Aspose.Slides pour .NET 14.8.0
linktitle: Aspose.Slides pour .NET 14.8.0
type: docs
weight: 100
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Examinez les mises à jour de l'API publique et les changements majeurs dans Aspose.Slides pour .NET afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc. [ajoutées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) ou [supprimées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) ainsi que les autres modifications introduites avec l'API Aspose.Slides pour .NET 14.8.0.

{{% /alert %}} 
## **Modifications de l'API publique**
### **Propriétés modifiées**
#### **Ajout de l'interface IVbaProject, Modification de la propriété Presentation.VbaProject**
La propriété VbaProject de la classe Presentation a été remplacée. Au lieu de la représentation brute en octets du projet VBA, une implémentation de la nouvelle interface IVbaProject a été ajoutée.

Utilisez la propriété IVbaProject pour gérer les projets VBA intégrés à une présentation. Vous pouvez ajouter de nouvelles références de projet, modifier des modules existants et en créer de nouveaux.

De plus, vous pouvez créer un nouveau projet VBA en utilisant la classe VbaProject qui implémente l'interface IVbaProject.

L'exemple suivant montre la création d'un projet VBA simple contenant un module et ajoutant deux références requises aux bibliothèques.

``` csharp

 using (Presentation pres = new Presentation())

{

    // Create new VBA Project

    pres.VbaProject = new VbaProject();

    // Add empty module to the VBA project

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Set module source code

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Create reference to <stdole>

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Create reference to Office

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Add references to the VBA project

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}

``` 

Cet exemple montre comment copier un projet VBA d'une présentation existante vers une nouvelle.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **Interfaces, propriétés et options d'énumération ajoutées**
#### **Ajout de la propriété Aspose.Slides.Charts.IChartSeries.Overlap**
La propriété Aspose.Slides.Charts.IChartSeries.Overlap indique le degré de chevauchement des barres et des colonnes sur les graphiques 2D (allant de -100 à 100).

Il s'agit de la propriété non seulement de cette série mais de toutes les séries du groupe parent - il s'agit d'une projection de la propriété du groupe correspondant. Ainsi, cette propriété est en lecture seule.

- Utilisez la propriété ParentSeriesGroup pour accéder au groupe de séries parent.
- Utilisez la propriété ParentSeriesGroup.Overlap en lecture/écriture pour modifier la valeur.

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
#### **Ajout de la propriété Aspose.Slides.Charts.IChartSeriesGroup.Overlap**
La propriété Aspose.Slides.Charts.IChartSeriesGroup.Overlap indique le degré de chevauchement des barres et des colonnes sur les graphiques 2D (de -100 à 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **Ajout de la valeur d'énumération ShapeThumbnailBounds.Appearance**
Cette méthode de création de vignette de forme vous permet de générer une vignette de forme dans les limites de son apparence. Elle prend en compte tous les effets de forme. La vignette de forme générée est limitée par les limites de la diapositive.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```