---
title: API public et changements incompatibles avec les versions précédentes dans Aspose.Slides pour .NET 16.2.0
type: docs
weight: 230
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les [ajouts](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) ou [suppressions](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) de classes, méthodes, propriétés, etc., ainsi que d'autres changements introduits avec l'API Aspose.Slides pour .NET 16.2.0.

{{% /alert %}} 
## **Changements de l'API publique**
#### **Les propriétés UpdateDateTimeFields et UpdateSlideNumberFields ont été supprimées**
Les propriétés UpdateDateTimeFields et UpdateSlideNumberFields ont été supprimées de la classe Aspose.Slides.Presentation et de l'interface Aspose.Slides.IPresentation.
La propriété Text des classes Aspose.Slides.TextFrame, Paragraph, Portion et des interfaces Aspose.Slides.ITextFrame, IParagraph, IPortion renvoie du texte avec des champs "datetime" mis à jour.
De plus, les propriétés Presentation.DocumentProperties.CreatedTime, LastSavedTime et LastPrinted sont devenues en lecture seule.
#### **L'énumération Slides.Charts.CategoryAxisType a été rendue publique**
Utilisée dans les propriétés IAxis.CategoryAxisType et Axis.CategoryAxisType pour déterminer le type d'axe des catégories.
CategoryAxisType.Auto - le type d'axe des catégories sera déterminé automatiquement lors de la sérialisation (ce comportement n'est pas implémenté actuellement)
CategoryAxisType.Text - le type d'axe des catégories est Text
CategoryAxisType.Date - le type d'axe des catégories est DateTime
#### **Extraction rapide de texte**
Une nouvelle méthode statique GetPresentationText a été ajoutée à la classe Presentation. Il existe deux surcharges pour cette méthode :

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

L'argument enum ExtractionMode indique le mode pour organiser la sortie du texte résultant et peut être défini sur les valeurs suivantes :
Non organisé - Le texte brut sans tenir compte de la position sur la diapositive
Organisé - Le texte est positionné dans le même ordre que sur la diapositive

Le mode Non organisé peut être utilisé lorsque la vitesse est critique, il est plus rapide que le mode Organisé.

PresentationText représente le texte brut extrait de la présentation. Il contient une propriété SlidesText du namespace Aspose.Slides.Util qui renvoie un tableau d'objets ISlideText. Chaque objet représente le texte sur la diapositive correspondante. L'objet ISlideText a les propriétés suivantes :

ISlideText.Text - Le texte sur les formes de la diapositive
ISlideText.MasterText - Le texte sur les formes de la page maître pour cette diapositive
ISlideText.LayoutText - Le texte sur les formes de la page de mise en page pour cette diapositive
ISlideText.NotesText - Le texte sur les formes de la page de notes pour cette diapositive

Il y a aussi une classe SlideText qui implémente l'interface ISlideText.

La nouvelle API peut être utilisée comme ceci :

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **L'interface ILegacyDiagram et la classe LegacyDiagram ont été ajoutées**
L'interface Aspose.Slides.ILegacyDiagram et la classe Aspose.Slides.LegacyDiagram ont été ajoutées pour représenter l'objet de diagramme hérité. L'objet de diagramme hérité est un ancien format de diagrammes provenant de PowerPoint 97-2003.
La nouvelle classe fournit des méthodes pour convertir le diagramme hérité en un objet SmartArt modifiable ou en un GroupShape modifiable.
#### **Un nouveau membre de l'énumération Aspose.Slides.TextAlignment a été ajouté (JustifyLow)**
Un nouveau membre de l'énumération TextAlignment a été ajouté :
JustifyLow - Justification Kashida basse.
#### **Nouvelles propriétés pour Aspose.Slides.IOleObjectFrame et OleObjectFrame**
Une nouvelle propriété a été ajoutée à l'interface IOleObjectFrame et à la classe OleObjectFrame implémentant cette interface. Ces propriétés sont utilisées pour fournir des informations sur un objet intégré dans la présentation :
EmbeddedFileExtension - Renvoie l'extension de fichier pour l'objet intégré actuel ou une chaîne vide si l'objet n'est pas un lien
EmbeddedFileLabel - Renvoie le nom de fichier de l'objet OLE intégré
EmbeddedFileName - Renvoie le chemin de l'objet OLE intégré
#### **Une nouvelle propriété CategoryAxisType a été ajoutée aux classes IAxis et Axis**
La propriété CategoryAxisType spécifie le type d'axe des catégories.

``` csharp

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
#### **Une nouvelle propriété ShowLabelAsDataCallout a été ajoutée à la classe DataLabelFormat et à l'interface IDataLabelFormat**
La propriété ShowLabelAsDataCallout détermine si le label de données spécifié du graphique sera affiché en tant que callout de données ou en tant que label de données.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

   chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

   pres.Save(pptxFileName, SaveFormat.Pptx);

}

``` 
#### **La propriété DrawSlidesFrame a été ajoutée aux PdfOptions et XpsOptions**
La propriété booléenne DrawSlidesFrame a été ajoutée aux interfaces Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions et aux classes associées Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions.
Le cadre noir autour de chaque diapositive sera dessiné si cette propriété est définie sur 'true'.

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

``` 