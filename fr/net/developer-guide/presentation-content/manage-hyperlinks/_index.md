---
title: Gérer les hyperliens de présentation dans .NET
linktitle: Gérer le lien hypertexte
type: docs
weight: 20
url: /fr/net/manage-hyperlinks/
keywords:
- ajouter URL
- ajouter un hyperlien
- créer un hyperlien
- formater un hyperlien
- supprimer un hyperlien
- mettre à jour un hyperlien
- hyperlien texte
- hyperlien diapositive
- hyperlien forme
- hyperlien image
- hyperlien vidéo
- hyperlien mutable
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Gérez facilement les hyperliens dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour .NET — améliorez l'interactivité et le flux de travail en quelques minutes."
---

Un hyperlien est une référence à un objet, à des données ou à un emplacement dans quelque chose. Voici des hyperliens courants dans les présentations PowerPoint :

* Liens vers des sites Web dans le texte, les formes ou les médias
* Liens vers des diapositives

Aspose.Slides for .NET vous permet d'effectuer de nombreuses tâches liées aux hyperliens dans les présentations. 

{{% alert color="primary" %}} 

Vous voudrez peut-être découvrir Aspose simple, [éditeur PowerPoint en ligne gratuit.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Ajouter des hyperliens URL**

### **Ajouter des hyperliens URL au texte**

Ce code C# montre comment ajouter un hyperlien vers un site Web à un texte :
```c#
using (Presentation presentation = new Presentation())
{
	IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.AddTextFrame("Aspose: File Format APIs");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

	presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


### **Ajouter des hyperliens URL aux formes ou aux cadres**

Ce code d'exemple en C# montre comment ajouter un hyperlien vers un site Web à une forme :
```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


### **Ajouter des hyperliens URL aux médias**

Aspose.Slides vous permet d'ajouter des hyperliens aux images, aux fichiers audio et aux vidéos. 

Ce code d'exemple montre comment ajouter un hyperlien à une **image** :
```c#
using (Presentation pres = new Presentation())
{
    // Ajoute une image à la présentation
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Crée un cadre image sur la diapositive 1 basé sur l'image ajoutée précédemment
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


Ce code d'exemple montre comment ajouter un hyperlien à un **fichier audio** :
```c#
using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


Ce code d'exemple montre comment ajouter un hyperlien à une **vidéo** :
``` csharp
using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


{{%  alert  title="Tip"  color="primary"  %}} 

Vous voudrez peut-être consulter *[Gérer OLE](https://docs.aspose.com/slides/net/manage-ole/)*.

{{% /alert %}}

## **Utiliser les hyperliens pour créer une table des matières**

Puisque les hyperliens vous permettent d'ajouter des références à des objets ou des emplacements, vous pouvez les utiliser pour créer une table des matières. 

Ce code d'exemple montre comment créer une table des matières avec des hyperliens :
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
    paragraph.Text = "Title of slide 2 .......... ";

    var linkPortion = new Portion();
    linkPortion.Text = "Page 2";
    linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

    paragraph.Portions.Add(linkPortion);
    contentTable.TextFrame.Paragraphs.Add(paragraph);

    presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
}
```


## **Mettre en forme les hyperliens**

### **Couleur**

Avec la propriété [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/colorsource) dans l'interface [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink), vous pouvez définir la couleur des hyperliens et également obtenir les informations de couleur des hyperliens. La fonctionnalité a été introduite pour la première fois dans PowerPoint 2019, de sorte que les modifications concernant la propriété ne s'appliquent pas aux versions antérieures de PowerPoint.

Ce code d'exemple montre une opération où des hyperliens de différentes couleurs ont été ajoutés à la même diapositive :
```c#
using (Presentation presentation = new Presentation())
{
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.AddTextFrame("This is a sample of colored hyperlink.");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

    IAutoShape shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.AddTextFrame("This is a sample of usual hyperlink.");
    shape2.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

    presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
}
```

### **Son**

Aspose.Slides fournit ces propriétés pour vous permettre de souligner un hyperlien avec un son :
- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Ajouter un son à un hyperlien**

Ce code C# montre comment définir l'hyperlien qui joue un son et l'arrêter avec un autre hyperlien :
```c#
using (Presentation pres = new Presentation())
{
	// Ajoute un nouvel audio à la collection audio de la présentation
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Ajoute une nouvelle forme avec le lien hypertexte vers la diapositive suivante
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Vérifie le lien hypertexte pour "No Sound"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Définit le lien hypertexte qui lit le son
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Ajoute la diapositive vide 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Ajoute une nouvelle forme avec le lien hypertexte NoAction
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Définit le drapeau du lien hypertexte "Stop previous sound"
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```


#### **Extraire le son d'un hyperlien**

Ce code C# montre comment extraire le son utilisé dans un hyperlien :
```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Obtient le lien hypertexte de la première forme
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Extrait le son du lien hypertexte sous forme de tableau d'octets
		byte[] audioData = link.Sound.BinaryData;
	}
}
```


## **Supprimer les hyperliens des présentations**

### **Supprimer les hyperliens du texte**

Ce code C# montre comment supprimer l'hyperlien d'un texte dans une diapositive de présentation :
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


### **Supprimer les hyperliens des formes ou des cadres**

Ce code C# montre comment supprimer l'hyperlien d'une forme dans une diapositive de présentation :
``` csharp
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


## **Hyperlien mutable**

La classe [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink) est mutable. Avec cette classe, vous pouvez modifier les valeurs de ces propriétés :
- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/highlightclick)

L'extrait de code montre comment ajouter un hyperlien à une diapositive et modifier son info-bulle plus tard :
```c#
using (Presentation presentation = new Presentation())
{   
   IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);    
    
   shape1.AddTextFrame("Aspose: File Format APIs");
    
   shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;
    
 presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **Propriétés prises en charge dans IHyperlinkQueries**

Vous pouvez accéder à IHyperlinkQueries depuis une présentation, une diapositive ou un texte pour lequel l'hyperlien est défini. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/properties/hyperlinkqueries)

La classe IHyperlinkQueries prend en charge ces méthodes et propriétés :
- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **FAQ**

**Comment créer une navigation interne non seulement vers une diapositive, mais vers une « section » ou la première diapositive d’une section ?**

Les sections dans PowerPoint sont des regroupements de diapositives ; la navigation cible techniquement une diapositive spécifique. Pour « naviguer vers une section », vous créez généralement un lien vers sa première diapositive.

**Puis‑je attacher un hyperlien aux éléments de la diapositive maîtresse afin qu’il fonctionne sur toutes les diapositives ?**

Oui. Les éléments de la diapositive maîtresse et des mises en page prennent en charge les hyperliens. Ces liens apparaissent sur les diapositives dérivées et sont cliquables pendant le diaporama.

**Les hyperliens seront‑ils conservés lors de l’exportation en PDF, HTML, images ou vidéo ?**

Dans [PDF](/slides/fr/net/convert-powerpoint-to-pdf/) et [HTML](/slides/fr/net/convert-powerpoint-to-html/), oui — les liens sont généralement conservés. Lors de l'exportation vers [images](/slides/fr/net/convert-powerpoint-to-png/) et [vidéo](/slides/fr/net/convert-powerpoint-to-video/), la possibilité de cliquer n'est pas conservée en raison de la nature de ces formats (les trames raster/vidéo ne prennent pas en charge les hyperliens).