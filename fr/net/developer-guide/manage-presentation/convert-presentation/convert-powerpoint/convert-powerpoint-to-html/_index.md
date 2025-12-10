---
title: Convertir les présentations PowerPoint en HTML avec .NET
linktitle: PowerPoint en HTML
type: docs
weight: 30
url: /fr/net/convert-powerpoint-to-html/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en HTML
- présentation en HTML
- diapositive en HTML
- PPT en HTML
- PPTX en HTML
- enregistrer PowerPoint en HTML
- enregistrer présentation en HTML
- enregistrer diapositive en HTML
- enregistrer PPT en HTML
- enregistrer PPTX en HTML
- exporter PPT en HTML
- exporter PPTX en HTML
- .NET
- C#
- Aspose.Slides
description: "Convertir les présentations PowerPoint en HTML réactif avec .NET. Conservez la mise en page, les liens et les images grâce au guide de conversion Aspose.Slides pour des résultats rapides et impeccables."
---

## **Vue d'ensemble**

Améliorez votre flux de travail en convertissant les présentations PowerPoint et OpenDocument en HTML avec Aspose.Slides pour .NET. Ce guide propose des instructions détaillées, des exemples de code robustes et des méthodes testées pour garantir un processus de conversion fiable et efficace, optimisé pour la visualisation Web.

Aspose.Slides fournit de nombreuses options—principalement de la classe [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions)—qui définissent le processus de conversion du format PowerPoint (ou OpenDocument) vers HTML :

* Convertir une présentation PowerPoint complète en HTML.  
* Convertir une diapositive spécifique d’une présentation PowerPoint en HTML.  
* Convertir les médias de la présentation (images, vidéos, etc.) en HTML.  
* Convertir une présentation PowerPoint en HTML réactif.  
* Convertir une présentation PowerPoint en HTML avec ou sans notes du présentateur.  
* Convertir une présentation PowerPoint en HTML avec ou sans commentaires.  
* Convertir une présentation PowerPoint en HTML avec les polices d’origine ou incorporées.  
* Convertir une présentation PowerPoint en HTML en utilisant le nouveau style CSS.  

## **Convertir une présentation en HTML**

Avec Aspose.Slides, vous pouvez convertir une présentation PowerPoint ou OpenDocument complète en HTML comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
1. Utilisez la méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) pour enregistrer l’objet sous forme de fichier HTML.  

Ce code montre comment convertir une présentation PowerPoint en HTML en C# :
```c#
// Instancier la classe Presentation qui représente un fichier de présentation (par exemple PPT, PPTX, ODP, etc.).
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // Enregistrer la présentation au format HTML.
    presentation.Save("output.html", SaveFormat.Html);
}
```


## **Convertir une présentation en HTML réactif**

Aspose.Slides fournit la classe [ResponsiveHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller) qui permet de générer des fichiers HTML réactifs. Ce code montre comment convertir une présentation PowerPoint en HTML réactif en C# :
```c#
// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    ResponsiveHtmlController controller = new ResponsiveHtmlController();

    HtmlOptions htmlOptions = new HtmlOptions 
    { 
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller) 
    };

    // Enregistrer la présentation au format HTML.
    presentation.Save("responsive.html", SaveFormat.Html, htmlOptions);
}
```


## **Convertir une présentation en HTML avec des notes du présentateur**

Lors de la conversion d’une présentation PowerPoint ou OpenDocument en HTML avec les notes du présentateur, il est essentiel de capturer l’intégralité du document d’origine. Ce processus garantit que non seulement les éléments visuels des diapositives sont reproduits avec précision, mais que les notes du présentateur sont également préservées, enrichissant le contenu d’un contexte supplémentaire.

Imaginons que nous disposions d’une présentation PowerPoint contenant la diapositive suivante :

![Une diapositive de présentation avec des notes du présentateur](slide_with_notes.png)

Ce code montre comment convertir une présentation PowerPoint en HTML avec les notes du présentateur en C# :
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // Définir les options pour les notes du présentateur.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Définir les options pour le document HTML de sortie.
    HtmlOptions htmlOptions = new HtmlOptions
    {
        SlidesLayoutOptions = notesOptions
    };

    // Enregistrer la présentation au format HTML avec les notes du présentateur.
    presentation.Save("slide_with_notes.html", SaveFormat.Html, htmlOptions);
}
```


Le résultat :

![Un document HTML avec la diapositive et les notes du présentateur](HTML_with_notes.png)

## **Convertir une présentation en HTML avec les polices d'origine**

Aspose.Slides fournit la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) qui permet d’incorporer toutes les polices d’une présentation lors de sa conversion en HTML.

Pour empêcher l’incorporation de certaines polices, vous pouvez passer un tableau de noms de polices à un constructeur paramétré de la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller). Les polices populaires, telles que Calibri ou Arial, n’ont pas besoin d’être incorporées car la plupart des systèmes les incluent déjà. Les incorporer augmenterait inutilement la taille du document HTML résultant.

La classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) prend en charge l’héritage et fournit la méthode [WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont), qui est destinée à être remplacée.
```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    // Exclure les polices par défaut de la présentation.
    string[] excludeFonts = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(excludeFonts);

    HtmlOptions htmlOptions = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(fontController)
    };

    presentation.Save("embedded_fonts.html", SaveFormat.Html, htmlOptions);
}
```


## **Convertir une présentation en HTML avec des images haute qualité**

Par défaut, lors de la conversion d’une présentation PowerPoint en HTML, Aspose.Slides génère un petit fichier HTML avec des images à 72 DPI et supprime les zones recadrées. Pour obtenir des fichiers HTML avec des images de meilleure qualité, vous devez définir la propriété `PicturesCompression` (de la classe `HtmlOptions`) sur 96 (c’est‑à‑dire `PicturesCompression.Dpi96`) ou une valeur supérieure, comme indiqué dans [cette référence](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression).

Ce code C# montre comment convertir une présentation PowerPoint en HTML tout en obtenant des images haute qualité à 150 DPI (c’est‑à‑dire `PicturesCompression.Dpi150`) :
```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    HtmlOptions htmlOptions = new HtmlOptions
    {
        PicturesCompression = PicturesCompression.Dpi150
    };

    presentation.Save("output_dpi_150.html", SaveFormat.Html, htmlOptions);
}
```


Ce code C# montre comment convertir une présentation PowerPoint en HTML sans supprimer les zones recadrées :
```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    HtmlOptions htmlOptions = new HtmlOptions
    {
        DeletePicturesCroppedAreas = false
    };

    presentation.Save("output_no_crop.html", SaveFormat.Html, htmlOptions);
}
```


## **Convertir une diapositive de présentation en HTML**

Pour convertir une diapositive spécifique d’une présentation PowerPoint en HTML, vous devez instancier la même classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) (utilisée pour convertir des présentations complètes en HTML) puis utiliser la méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) pour enregistrer le fichier au format HTML. La classe [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) peut être utilisée pour spécifier des options de conversion supplémentaires.

Ce code C# montre comment convertir une diapositive avec des notes du présentateur d’une présentation PowerPoint en HTML :
```c#
public static void Run()
{
    using (Presentation presentation = new Presentation("sample.pptx"))
    {
        NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull
        };

        HtmlOptions htmlOptions = new HtmlOptions
        {
            SlidesLayoutOptions = notesOptions,
            HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new CustomFormattingController())
        };

        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            int slideIndex = i + 1;

            // Enregistrer la diapositive dans un fichier HTML.
            string fileName = $"output_slide_{slideIndex}.html";
            presentation.Save(fileName, new[] { slideIndex }, SaveFormat.Html, htmlOptions);
        }
    }
}

public class CustomFormattingController : IHtmlFormattingController
{
    void IHtmlFormattingController.WriteDocumentStart(IHtmlGenerator generator, IPresentation presentation)
    {}

    void IHtmlFormattingController.WriteDocumentEnd(IHtmlGenerator generator, IPresentation presentation)
    {}

    void IHtmlFormattingController.WriteSlideStart(IHtmlGenerator generator, ISlide slide)
    {
        generator.AddHtml(string.Format(SlideHeader, generator.SlideIndex + 1));
    }

    void IHtmlFormattingController.WriteSlideEnd(IHtmlGenerator generator, ISlide slide)
    {
        generator.AddHtml(SlideFooter);
    }

    void IHtmlFormattingController.WriteShapeStart(IHtmlGenerator generator, IShape shape)
    {}

    void IHtmlFormattingController.WriteShapeEnd(IHtmlGenerator generator, IShape shape)
    {}

    private const string SlideHeader = "<div class=\"slide\" name=\"slide\" id=\"slide{0}\">";
    private const string SlideFooter = "</div>";
}
```


## **Enregistrer le CSS et les images lors de l’exportation en HTML**

En utilisant les nouveaux fichiers de style CSS, vous pouvez modifier facilement l’apparence du fichier HTML généré à partir du processus de conversion PowerPoint‑vers‑HTML.

Le code C# de cet exemple montre comment utiliser des méthodes pouvant être remplacées afin de créer un document HTML personnalisé incluant un lien vers un fichier CSS :
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
	CustomHeaderAndFontsController htmlController = new CustomHeaderAndFontsController("styles.css");

	HtmlOptions options = new HtmlOptions
	{
		HtmlFormatter = HtmlFormatter.CreateCustomFormatter(htmlController),
	};
	presentation.Save("pres.html", SaveFormat.Html, options);
}
```

```c#
public class CustomHeaderAndFontsController : EmbedAllFontsHtmlController
{
    // Modèle d'en-tête personnalisé.
    const string Header = "<!DOCTYPE html>\n" +
                            "<html>\n" +
                            "<head>\n" +
                            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n" +
                            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" +
                            "<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}\">\n" +
                            "</head>";

    private readonly string m_cssFileName;

    public CustomHeaderAndFontsController(string cssFileName)
    {
        m_cssFileName = cssFileName;
    }

    public override void WriteDocumentStart(IHtmlGenerator generator, IPresentation presentation)
    {
        generator.AddHtml(string.Format(Header, m_cssFileName));
        WriteAllFonts(generator, presentation);
    }

    public override void WriteAllFonts(IHtmlGenerator generator, IPresentation presentation)
    {
        generator.AddHtml("<!-- Embedded fonts -->");
        base.WriteAllFonts(generator, presentation);
    }
}
```


## **Lier toutes les polices lors de la conversion d’une présentation en HTML**

Si vous ne souhaitez pas incorporer les polices (pour éviter d’augmenter la taille du HTML résultant), vous pouvez lier toutes les polices en implémentant votre propre version `LinkAllFontsHtmlController`.

Ce code C# montre comment convertir une présentation PowerPoint en HTML tout en liant toutes les polices et en excluant « Calibri » et « Arial » (car elles sont déjà installées sur le système) :
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    // Exclure les polices par défaut de la présentation.
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList, @"C:\Windows\Fonts\");;

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(linkcont)
    };

    presentation.Save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
```


Ce code C# montre comment la classe `LinkAllFontsHtmlController` est implémentée :
```c#
public class LinkAllFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string m_basePath;

    public LinkAllFontsHtmlController(string[] fontNameExcludeList, string basePath) : base(fontNameExcludeList)
    {
        m_basePath = basePath;
    }

    public override void WriteFont
    (
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            string fontStyle,
            string fontWeight,
            byte[] fontData)
    {
        try
        {
            string fontName = substitutedFont == null ? originalFont.FontName : substitutedFont.FontName;
            string path = fontName + ".woff"; // Un certain nettoyage du chemin peut être nécessaire.

            File.WriteAllBytes(Path.Combine(m_basePath, path), fontData);
            
            generator.AddHtml("<style>");
            generator.AddHtml("@font-face { ");
            generator.AddHtml("font-family: '" + fontName + "'; ");
            generator.AddHtml("src: url('" + path + "')");

            generator.AddHtml(" }");
            generator.AddHtml("</style>");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
```


## **Convertir une présentation avec des images SVG en HTML réactif**

Ce code C# montre comment convertir une présentation PowerPoint en HTML réactif :
```c#
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    HtmlOptions saveOptions = new HtmlOptions
    {
        SvgResponsiveLayout = true
    };

    presentation.Save("SvgResponsiveLayout-out.html", SaveFormat.Html, saveOptions);
}
```


## **Exporter les fichiers multimédias en HTML**

Avec Aspose.Slides pour .NET, vous pouvez exporter les fichiers multimédias comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
1. Obtenez une référence à la diapositive.  
1. Ajoutez une vidéo à la diapositive.  
1. Enregistrez la présentation sous forme de fichier HTML.  

Ce code C# montre comment ajouter une vidéo à la présentation puis l’enregistrer en HTML : 
```c#
// Créer une nouvelle présentation.
using (Presentation presentation = new Presentation())
{
    string path = "C:/out/";
    const string fileName = "ExportMediaFiles_out.html";
    const string baseUri = "http://www.example.com/";

    using (FileStream fileStream = new FileStream("my_video.avi", FileMode.Open, FileAccess.Read))
    {
        IVideo video = presentation.Videos.AddVideo(fileStream, LoadingStreamBehavior.ReadStreamAndRelease);
        
        ISlide slide = presentation.Slides[0];
        slide.Shapes.AddVideoFrame(10, 10, 100, 100, video);
    }
        
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // Définir les options HTML.
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    // Enregistrer la présentation dans un fichier HTML.
    presentation.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);
}
```


{{% alert color="primary" %}} 

Aspose a développé des convertisseurs gratuits [présentation vers HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) : [PPT vers HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX vers HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP vers HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Découvrez les autres [convertisseurs gratuits d’Aspose](https://products.aspose.app/slides/conversion). 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Outre les processus de conversion décrits ici, Aspose.Slides prend également en charge les opérations de conversion suivantes impliquant le format HTML : 

* [HTML vers image](https://products.aspose.com/slides/net/conversion/html-to-image/)  
* [HTML vers JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)  
* [HTML vers XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)  
* [HTML vers TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)  

{{% /alert %}}

## **FAQ**

**Quelle est la performance d’Aspose.Slides lors de la conversion de plusieurs présentations en HTML ?**  

La performance dépend de la taille et de la complexité des présentations. Aspose.Slides est très efficace et évolutif pour les opérations par lots. Pour obtenir des performances optimales lors de la conversion d’un grand nombre de présentations, il est recommandé d’utiliser le multithreading ou le traitement parallèle chaque fois que cela est possible.

**Aspose.Slides prend‑il en charge l’exportation des hyperliens vers HTML ?**  

Oui, Aspose.Slides prend pleinement en charge l’exportation des hyperliens incorporés vers HTML. Lors de la conversion des présentations au format HTML, les hyperliens sont conservés automatiquement et restent cliquables.

**Existe‑t‑il une limite au nombre de diapositives lors de la conversion de présentations en HTML ?**  

Il n’y a aucune limite au nombre de diapositives lorsque vous utilisez Aspose.Slides. Vous pouvez convertir des présentations de toute taille. Cependant, pour les présentations contenant un très grand nombre de diapositives, les performances peuvent dépendre des ressources disponibles sur votre serveur ou votre système.