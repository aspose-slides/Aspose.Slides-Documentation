---
title: API publique et changements incompatibles rétroactifs dans Aspose.Slides for .NET 16.2.0
linktitle: Aspose.Slides pour .NET 16.2.0
type: docs
weight: 230
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
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
description: "Passez en revue les mises à jour de l'API publique et les changements majeurs dans Aspose.Slides for .NET afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---
{{% alert color="info" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés et ainsi de suite [ajoutées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) ou [supprimées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) et d’autres changements introduits avec l’API Aspose.Slides for .NET 16.2.0.

{{% /alert %}} 
## **Modifications de l'API publique**
#### **Les propriétés UpdateDateTimeFields et UpdateSlideNumberFields ont été supprimées**
Les propriétés UpdateDateTimeFields et UpdateSlideNumberFields ont été supprimées de la classe Aspose.Slides.Presentation et de l'interface Aspose.Slides.IPresentation.  
La propriété Text des classes Aspose.Slides.TextFrame, Paragraph, Portion et des interfaces Aspose.Slides.ITextFrame, IParagraph, IPortion renvoie le texte avec les champs « datetime » mis à jour.  
De plus, les propriétés Presentation.DocumentProperties.CreatedTime, LastSavedTime et LastPrinted sont devenues en lecture seule.  
#### **L'énumération Slides.Charts.CategoryAxisType est passée au public**
Utilisée dans les propriétés IAxis.CategoryAxisType et Axis.CategoryAxisType pour déterminer le type d'axe de catégorie.  
CategoryAxisType.Auto - le type d'axe de catégorie sera déterminé automatiquement lors de la sérialisation (ce comportement n'est pas encore implémenté)  
CategoryAxisType.Text - le type d'axe de catégorie est Text  
CategoryAxisType.Date - le type d'axe de catégorie est DateTime  
#### **Extraction rapide de texte**
La nouvelle méthode statique GetPresentationText a été ajoutée à la classe Presentation. Il existe deux surcharges pour cette méthode :

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

L'argument enum ExtractionMode indique le mode d'organisation du résultat textuel et peut être défini sur les valeurs suivantes :  
Unarranged - Le texte brut sans tenir compte de la position sur la diapositive  
Arranged - Le texte est positionné dans le même ordre que sur la diapositive  

Le mode Unarranged peut être utilisé lorsque la vitesse est cruciale, il est plus rapide que le mode Arranged.  

PresentationText représente le texte brut extrait de la présentation. Il contient une propriété SlidesText du namespace Aspose.Slides.Util qui renvoie un tableau d'objets ISlideText. Chaque objet représente le texte de la diapositive correspondante. L'objet ISlideText possède les propriétés suivantes :

ISlideText.Text - Le texte des formes de la diapositive  
ISlideText.MasterText - Le texte des formes de la page maître pour cette diapositive  
ISlideText.LayoutText - Le texte des formes de la page de mise en page pour cette diapositive  
ISlideText.NotesText - Le texte des formes de la page de notes pour cette diapositive  

Il existe également une classe SlideText qui implémente l'interface ISlideText.  

La nouvelle API peut être utilisée ainsi :

``` csharp
using System;
using Aspose.Slides;

// Extraire le texte sans tenir compte de sa position sur la diapositive (le mode le plus rapide).
IPresentationText text1 = PresentationFactory.Instance.GetPresentationText(
    "presentation.ppt", TextExtractionArrangingMode.Unarranged);

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

// Extraire le texte positionné dans le même ordre que sur la diapositive.
IPresentationText text2 = PresentationFactory.Instance.GetPresentationText(
    "presentation.pptx", TextExtractionArrangingMode.Arranged);

Console.WriteLine(text2.SlidesText[0].Text);
``` 
#### **L'interface ILegacyDiagram et la classe LegacyDiagram ont été ajoutées**
L'interface Aspose.Slides.ILegacyDiagram et la classe Aspose.Slides.LegacyDiagram ont été ajoutées pour représenter l'objet diagramme hérité. L'objet diagramme hérité est un ancien format de diagrammes de PowerPoint 97-2003.  
La nouvelle classe fournit des méthodes pour convertir le diagramme hérité en objet SmartArt moderne éditable ou en GroupShape éditable.  
#### **Nouvel élément d'énumération Aspose.Slides.TextAlignment ajouté (JustifyLow)**
Un nouveau membre de l'énumération TextAlignment a été ajouté :  
JustifyLow - Justification Kashida basse.  
#### **Nouvelles propriétés pour Aspose.Slides.IOleObjectFrame et OleObjectFrame**
De nouvelles propriétés ont été ajoutées à l'interface IOleObjectFrame et à la classe OleObjectFrame qui implémente cette interface. Ces propriétés servent à fournir des informations sur un objet incorporé dans la présentation :  
EmbeddedFileExtension - Renvoie l'extension de fichier de l'objet incorporé actuel ou une chaîne vide si l'objet n'est pas un lien  
EmbeddedFileLabel - Renvoie le nom de fichier de l'objet OLE incorporé  
EmbeddedFileName - Renvoie le chemin de l'objet OLE incorporé  
#### **Nouvelle propriété CategoryAxisType ajoutée aux classes IAxis et Axis**
La propriété CategoryAxisType spécifie le type d'axe de catégorie.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string sourcePptxFileName = "chart.pptx";
string pptxOutPath = "chart_out.pptx";

using (Presentation pres = new Presentation(sourcePptxFileName))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;

    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

    pres.Save(pptxOutPath, SaveFormat.Pptx);
}
``` 
#### **Nouvelle propriété ShowLabelAsDataCallout ajoutée à la classe DataLabelFormat et à l'interface IDataLabelFormat**
La propriété ShowLabelAsDataCallout détermine si l'étiquette de données du graphique spécifié sera affichée comme appel de données ou comme étiquette de données.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string pptxFileName = "callout_labels.pptx";

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
    chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

    pres.Save(pptxFileName, SaveFormat.Pptx);
}
``` 
#### **La propriété DrawSlidesFrame a été ajoutée à PdfOptions et XpsOptions**
La propriété booléenne DrawSlidesFrame a été ajoutée aux interfaces Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions ainsi qu'aux classes associées Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions.  
Le cadre noir autour de chaque diapositive sera dessiné si cette propriété est définie sur « true ».

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}
```