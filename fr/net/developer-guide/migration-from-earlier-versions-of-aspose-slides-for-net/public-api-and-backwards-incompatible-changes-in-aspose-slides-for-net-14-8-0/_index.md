---
title: API public et changements non compatibles en arrière dans Aspose.Slides pour .NET 14.8.0
type: docs
weight: 100
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc. [ajoutées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) ou [supprimées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) et autres changements introduits avec l'API Aspose.Slides pour .NET 14.8.0.

{{% /alert %}} 
## **Changements de l'API publique**
### **Propriétés modifiées**
#### **Ajout de l'interface IVbaProject, changement de la propriété Presentation.VbaProject**
La propriété VbaProject de la classe Presentation a été remplacée. Au lieu de la représentation brute en bytes du projet VBA, la nouvelle implémentation de l'interface IVbaProject a été ajoutée.

Utilisez la propriété IVbaProject pour gérer les projets VBA intégrés dans une présentation. Vous pouvez ajouter de nouvelles références de projet, modifier des modules existants et en créer de nouveaux.

De plus, vous pouvez créer un nouveau projet VBA en utilisant la classe VbaProject qui implémente l'interface IVbaProject.

L'exemple suivant montre la création d'un simple projet VBA contenant un module et ajoutant deux références requises aux bibliothèques.

``` csharp

 using (Presentation pres = new Presentation())

{

    // Créer un nouveau projet VBA

    pres.VbaProject = new VbaProject();

    // Ajouter un module vide au projet VBA

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Définir le code source du module

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Créer une référence à <stdole>

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Créer une référence à Office

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Ajouter des références au projet VBA

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}

``` 

Cet exemple montre comment copier un projet VBA d'une présentation existante à une nouvelle.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **Ajout d'interfaces, de propriétés et d'options d'énumération**
#### **Ajout de la propriété Aspose.Slides.Charts.IChartSeries.Overlap**
La propriété Aspose.Slides.Charts.IChartSeries.Overlap spécifie dans quelle mesure les barres et les colonnes doivent se chevaucher sur les graphiques 2D (allant de -100 à 100).

C'est la propriété non seulement de cette série mais de toutes les séries dans le groupe de séries parent - c'est une projection de la propriété de groupe appropriée. Et donc, cette propriété est en lecture seule.

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
La propriété Aspose.Slides.Charts.IChartSeriesGroup.Overlap spécifie dans quelle mesure les barres et les colonnes doivent se chevaucher sur les graphiques 2D (allant de -100 à 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **Ajout de la valeur d'énumération ShapeThumbnailBounds.Appearance**
Cette méthode de création de miniatures de forme vous permet de générer une miniature de forme dans les limites de son apparence. Elle prend en compte tous les effets de forme. La miniature de forme générée est restreinte par les limites de diapositive.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

``` 