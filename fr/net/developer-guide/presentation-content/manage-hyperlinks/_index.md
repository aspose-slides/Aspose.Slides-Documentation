---
title: Gérer les Hyperliens
type: docs
weight: 20
url: /net/manage-hyperlinks/
keywords: "Ajouter un hyperlien, Présentation PowerPoint, Hyperlien PowerPoint, hyperlien texte, hyperlien diapositive, hyperlien forme, hyperlien image, hyperlien vidéo, .NET, C#, Csharp"
description: "Ajouter un hyperlien à une Présentation PowerPoint en C# ou .NET"
---

Un hyperlien est une référence à un objet ou des données ou un endroit dans quelque chose. Voici des hyperliens courants dans les Présentations PowerPoint :

* Liens vers des sites web à l'intérieur de textes, de formes ou de médias
* Liens vers des diapositives

Aspose.Slides pour .NET vous permet d'effectuer de nombreuses tâches impliquant des hyperliens dans des présentations.

{{% alert color="primary" %}}

Vous voudrez peut-être jeter un œil à l'[éditeur PowerPoint en ligne simple et gratuit d'Aspose.](https://products.aspose.app/slides/editor)

{{% /alert %}}

## **Ajout d'Hyperliens URL**

### **Ajout d'Hyperliens URL aux Textes**

Ce code C# vous montre comment ajouter un hyperlien de site web à un texte :

```c#
using (Presentation presentation = new Presentation())
{
	IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.AddTextFrame("Aspose : API de formats de fichiers");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Plus de 70 % des entreprises du Fortune 100 font confiance aux API d'Aspose";
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

	presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

### **Ajout d'Hyperliens URL aux Formes ou Cadres**

Ce code exemple en C# vous montre comment ajouter un hyperlien de site web à une forme :

```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "Plus de 70 % des entreprises du Fortune 100 font confiance aux API d'Aspose";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **Ajout d'Hyperliens URL aux Médias**

Aspose.Slides vous permet d'ajouter des hyperliens aux images, aux fichiers audio et vidéo.

Ce code exemple vous montre comment ajouter un hyperlien à une **image** :

```c#
using (Presentation pres = new Presentation())
{
    // Ajoute une image à la présentation
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Crée un cadre d'image sur la diapositive 1 basé sur l'image précédemment ajoutée
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "Plus de 70 % des entreprises du Fortune 100 font confiance aux API d'Aspose";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Ce code exemple vous montre comment ajouter un hyperlien à un **fichier audio** :

```c#
using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "Plus de 70 % des entreprises du Fortune 100 font confiance aux API d'Aspose";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Ce code exemple vous montre comment ajouter un hyperlien à une **vidéo** :

```csharp
using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "Plus de 70 % des entreprises du Fortune 100 font confiance aux API d'Aspose";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

{{%  alert  title="Astuce"  color="primary"  %}} 

Vous pouvez voir *[Gérer OLE](https://docs.aspose.com/slides/net/manage-ole/)*.

{{% /alert %}}


## **Utiliser des Hyperliens pour Créer une Table des Matières**

Étant donné que les hyperliens vous permettent d'ajouter des références à des objets ou à des lieux, vous pouvez les utiliser pour créer une table des matières.

Ce code exemple vous montre comment créer une table des matières avec des hyperliens :

```c#
using (var presentation = new Presentation())
{
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

    var contentTable = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.FillFormat.FillType = FillType.NoFill;
    contentTable.LineFormat.FillFormat.FillType = FillType.NoFill;
    contentTable.TextFrame.Paragraphs.Clear();

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    paragraph.Text = "Titre de la diapositive 2 .......... ";

    var linkPortion = new Portion();
    linkPortion.Text = "Page 2";
    linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

    paragraph.Portions.Add(linkPortion);
    contentTable.TextFrame.Paragraphs.Add(paragraph);

    presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
}
```

## **Formatage des Hyperliens**

### **Couleur**

Avec la propriété [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/colorsource) dans l'interface [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink), vous pouvez définir la couleur des hyperliens et également obtenir les informations de couleur des hyperliens. La fonctionnalité a été introduite pour la première fois dans PowerPoint 2019, donc les changements impliquant la propriété ne s'appliquent pas aux versions antérieures de PowerPoint.

Ce code exemple démontre une opération où des hyperliens de différentes couleurs ont été ajoutés à la même diapositive :

```c#
using (Presentation presentation = new Presentation())
{
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.AddTextFrame("Ceci est un exemple d'hyperlien coloré.");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

    IAutoShape shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.AddTextFrame("Ceci est un exemple d'hyperlien habituel.");
    shape2.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

    presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
}
```
### **Son**

Aspose.Slides fournit ces propriétés pour vous permettre de mettre en valeur un hyperlien avec un son :
- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Ajouter un Son à l'Hypelien**

Ce code C# vous montre comment définir l'hyperlien qui joue un son et l'arrête avec un autre hyperlien :

```c#
using (Presentation pres = new Presentation())
{
	// Ajoute un nouveau son audio à la collection audio de la présentation
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Ajoute une nouvelle forme avec l'hyperlien vers la diapositive suivante
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Vérifie l'hyperlien pour "Aucun Son"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Définit l'hyperlien qui joue le son
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Ajoute la diapositive vide 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Ajoute une nouvelle forme avec l'hyperlien NoAction
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Définit l'hyperlien "Arrêter le son précédent"
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **Extraire le Son de l'Hypelien**

Ce code C# vous montre comment extraire le son utilisé dans un hyperlien :

```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Récupère le premier hyperlien de forme
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Extrait le son hyperlien dans un tableau d'octets
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **Supprimer des Hyperliens dans les Présentations**

### **Supprimer des Hyperliens des Textes**

Ce code C# vous montre comment supprimer l'hyperlien d'un texte dans une diapositive de présentation :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        IAutoShape autoShape = shape as IAutoShape;
        if (autoShape != null)
        {
            foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
            {
                foreach (IPortion portion in paragraph.Portions)
                {
                    portion.PortionFormat.HyperlinkManager.RemoveHyperlinkClick();
                }
            }
        }
    }
    
    pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
```

### **Supprimer des Hyperliens des Formes ou Cadres**

Ce code C# vous montre comment supprimer l'hyperlien d'une forme dans une diapositive de présentation :

```csharp
using (Presentation pres = new Presentation("demo.pptx")) 
{ 
   ISlide slide = pres.Slides[0]; 
   foreach (IShape shape in slide.Shapes) 
     { 
       shape.HyperlinkManager.RemoveHyperlinkClick(); 
     } 
   pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx); 
}
```

## **Hyperlien Mutable**

La classe [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink) est mutable. Avec cette classe, vous pouvez changer les valeurs de ces propriétés :

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/highlightclick)

Le code d'exemple vous montre comment ajouter un hyperlien à une diapositive et modifier son info-bulle plus tard :

```c#
using (Presentation presentation = new Presentation())
{   
   IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);    
    
   shape1.AddTextFrame("Aspose : API de formats de fichiers");
    
   shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Plus de 70 % des entreprises du Fortune 100 font confiance aux API d'Aspose";
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;
    
 presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Propriétés prises en charge dans IHyperlinkQueries**

Vous pouvez accéder à IHyperlinkQueries à partir d'une présentation, d'une diapositive ou de textes pour lesquels l'hyperlien est défini.

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/properties/hyperlinkqueries)

La classe IHyperlinkQueries prend en charge ces méthodes et propriétés :

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)