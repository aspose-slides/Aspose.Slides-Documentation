---
title: Convertir PowerPoint en HTML en C# .NET
linktitle: Convertir PowerPoint en HTML
type: docs
weight: 30
url: /fr/net/convert-powerpoint-to-html/
keywords: "C# PowerPoint en HTML, C# PPT en HTML, C# ODP en HTML, C# Diapositive en HTML, Convertir Présentation PowerPoint, PPTX, PPT, PPT en HTML, PPTX en HTML, PowerPoint en HTML, Enregistrer PowerPoint en tant que HTML, Enregistrer PPT en tant que HTML, Enregistrer PPTX en tant que HTML, C#, Csharp, .NET, Aspose.Slides, exportation HTML"
description: "Convertir PowerPoint HTML : Enregistrer PPTX ou PPT en tant que HTML. Enregistrer des diapositives en tant que HTML"
---

## **Aperçu**

Cet article explique comment convertir une Présentation PowerPoint au format HTML en utilisant C#. Il couvre les sujets suivants.

- [Convertir PowerPoint en HTML en C#](#convert-powerpoint-to-html)
- [Convertir PPT en HTML en C#](#convert-powerpoint-to-html)
- [Convertir PPTX en HTML en C#](#convert-powerpoint-to-html)
- [Convertir ODP en HTML en C#](#convert-powerpoint-to-html)
- [Convertir Diapositive PowerPoint en HTML en C#](#convert-slide-to-html)

## **C# PowerPoint en HTML**

Pour le code d'exemple C# pour convertir PowerPoint en HTML, veuillez consulter la section ci-dessous c'est-à-dire [Convertir PowerPoint en HTML](#convert-powerpoint-to-html). Le code peut charger plusieurs formats comme PPT, PPTX et ODP dans l'objet Présentation et l'enregistrer au format HTML.

## **À propos de la conversion PowerPoint en HTML**
En utilisant [**Aspose.Slides pour .NET**](https://products.aspose.com/slides/net/), les applications et les développeurs peuvent convertir une présentation PowerPoint en HTML : **PPTX en HTML** ou **PPT en HTML**. 

**Aspose.Slides** fournit de nombreuses options (principalement de la classe [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions)) qui définissent le processus de conversion de PowerPoint en HTML :

* Convertir l'ensemble d'une présentation PowerPoint en HTML.
* Convertir une diapositive spécifique dans une présentation PowerPoint en HTML.
* Convertir les médias de présentation (images, vidéos, etc.) en HTML.
* Convertir une présentation PowerPoint en HTML réactif. 
* Convertir une présentation PowerPoint en HTML avec des notes de conférencier incluses ou exclues. 
* Convertir une présentation PowerPoint en HTML avec des commentaires inclus ou exclus. 
* Convertir une présentation PowerPoint en HTML avec des polices originales ou intégrées. 
* Convertir une présentation PowerPoint en HTML en utilisant le nouveau style CSS. 

{{% alert color="primary" %}} 

En utilisant sa propre API, Aspose a développé des convertisseurs gratuits [présentation en HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) : [PPT en HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX en HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP en HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc.

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Vous pouvez consulter d'autres [convertisseurs gratuits d'Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Outre les processus de conversion décrits ici, Aspose.Slides prend également en charge ces opérations de conversion ayant trait au format HTML : 

* [HTML en image](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML en JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML en XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML en TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}


## **Convertir PowerPoint en HTML**
En utilisant Aspose.Slides, vous pouvez convertir une présentation PowerPoint entière en HTML de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Utilisez la méthode [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) pour enregistrer l'objet en tant que fichier HTML.

Ce code vous montre comment convertir un PowerPoint en HTML en C# :

```c#
// Instancie un objet de présentation qui représente un fichier de présentation e.g. PPT, PPTX, ODP etc.
using (Presentation presentation = new Presentation("Convert_HTML.pptx"))
{
    HtmlOptions htmlOpt = new HtmlOptions();
    
    INotesCommentsLayoutingOptions options = htmlOpt.NotesCommentsLayouting;
    options.NotesPosition = NotesPositions.BottomFull;
    
    htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

    // Enregistre la présentation en tant que HTML
    presentation.Save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
}
```


## **Convertir PowerPoint en HTML réactif**
Aspose.Slides fournit la classe [ResponsiveHtmlController ](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller) qui vous permet de générer des fichiers HTML réactifs. Ce code vous montre comment convertir une présentation PowerPoint en HTML réactif en C# :

```c#
// Instancie un objet Presentation qui représente un fichier de présentation
using (Presentation presentation = new Presentation("Convert_HTML.pptx"))
{
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions { HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller) };

    // Enregistre la présentation en tant que HTML
    presentation.Save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
}
```

## **Convertir PowerPoint en HTML avec notes**
Ce code vous montre comment convertir un PowerPoint en HTML avec des notes en C# :

```c#
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    HtmlOptions opt = new HtmlOptions();

    INotesCommentsLayoutingOptions options = opt.NotesCommentsLayouting;
    options.NotesPosition = NotesPositions.BottomFull;

    // Enregistre les pages de notes
    pres.Save("Output.html", SaveFormat.Html, opt);
}
```

## **Convertir PowerPoint en HTML avec polices originales**

Aspose.Slides fournit la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) qui permet d'intégrer toutes les polices dans une présentation lors de la conversion de la présentation en HTML.

Pour empêcher certaines polices d'être intégrées, vous pouvez passer un tableau de noms de polices à un constructeur paramétré de la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller). Des polices populaires, telles que Calibri ou Arial, lorsqu'elles sont utilisées dans une présentation, n'ont pas à être intégrées car la plupart des systèmes contiennent déjà de telles polices. Lorsque ces polices sont intégrées, le document HTML résultant devient inutilement volumineux.

La classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) prend en charge l'héritage et fournit la méthode [WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont) qui est destinée à être écrasée. 

```c#
using (Presentation pres = new Presentation("input.pptx"))
{
    // Exclut les polices de présentation par défaut
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(embedFontsController)
    };

    pres.Save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
}
```

## **Convertir PowerPoint en HTML avec images de haute qualité**

Par défaut, lorsque vous convertissez PowerPoint en HTML, Aspose.Slides génère un petit HTML avec des images à 72 DPI et des zones recadrées supprimées. Pour obtenir des fichiers HTML avec des images de haute qualité, vous devez définir la propriété `PicturesCompression` (de la classe `HtmlOptions`) sur 96 (c'est-à-dire, `PicturesCompression.Dpi96`) ou des [valeurs supérieures](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression).

Ce code C# vous montre comment convertir une présentation PowerPoint en HTML tout en obtenant des images de haute qualité à 150 DPI (c'est-à-dire `PicturesCompression.Dpi150`) :

```c#
Presentation pres = new Presentation("InputDoc.pptx");
HtmlOptions htmlOpts = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};
pres.Save("OutputDoc-dpi150.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpts); 
```

Ce code en C# vous montre comment générer du HTML avec des images de pleine qualité :

```c#
Presentation pres = new Presentation("InputDoc.pptx");
HtmlOptions htmlOpts = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};
pres.Save("Outputdoc-noCrop.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpts);
```

## **Convertir Diapositive en HTML**
Pour convertir une diapositive spécifique dans un PowerPoint en HTML, vous devez instancier la même classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) (utilisée pour convertir des présentations entières en HTML) et ensuite utiliser la méthode [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) pour enregistrer le fichier en tant que HTML. La classe [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions**) peut être utilisée pour spécifier des options de conversion supplémentaires :

Ce code C# vous montre comment convertir une diapositive dans une présentation PowerPoint en HTML :

```c#
public static void Run()
{
    using (Presentation presentation = new Presentation("Individual-Slide.pptx"))
    {
        HtmlOptions htmlOptions = new HtmlOptions();

        INotesCommentsLayoutingOptions options = htmlOptions.NotesCommentsLayouting;
        options.NotesPosition = NotesPositions.BottomFull;

        htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new CustomFormattingController());

        // Enregistre le fichier              
        for (int i = 0; i < presentation.Slides.Count; i++)
            presentation.Save("Diapositive Individuelle" + (i + 1) + "_out.html", new[] { i + 1 }, SaveFormat.Html, htmlOptions);
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


## **Enregistrer CSS et Images lors de l'exportation en HTML**
À l'aide de nouveaux fichiers de style CSS, vous pouvez facilement modifier le style du fichier HTML résultant du processus de conversion PowerPoint en HTML.

Le code C# dans cet exemple vous montre comment utiliser des méthodes surchargées pour créer un document HTML personnalisé avec un lien vers un fichier CSS :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	CustomHeaderAndFontsController htmlController = new CustomHeaderAndFontsController("styles.css");
	HtmlOptions options = new HtmlOptions
	{
		HtmlFormatter = HtmlFormatter.CreateCustomFormatter(htmlController),
	};
	pres.Save("pres.html", SaveFormat.Html, options);
}
```

```c#
public class CustomHeaderAndFontsController : EmbedAllFontsHtmlController
{
    // Modèle d'en-tête personnalisé
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
        generator.AddHtml("<!-- Polices intégrées -->");
        base.WriteAllFonts(generator, presentation);
    }
}
```

## **Lier toutes les polices lors de la conversion de la présentation en HTML**

Si vous ne voulez pas intégrer les polices (pour éviter d'augmenter la taille du HTML résultant), vous pouvez lier toutes les polices en implémentant votre propre version de `LinkAllFontsHtmlController`.

Ce code C# vous montre comment convertir un PowerPoint en HTML tout en liant toutes les polices et en excluant "Calibri" et "Arial" (puisqu'elles existent déjà dans le système) : 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Exclut les polices de présentation par défaut
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    Paragraph para = new Paragraph();
    ITextFrame txt;

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList, @"C:\Windows\Fonts\");;

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(linkcont)
    };

    pres.Save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
```

Ce code C# montre comment `LinkAllFontsHtmlController` est implémenté :

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
            string path = fontName + ".woff"; // Une certaine sanitisation du chemin peut être nécessaire

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

## **Convertir PowerPoint en HTML réactif**
Ce code C# vous montre comment convertir une présentation PowerPoint en HTML réactif :

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
HtmlOptions saveOptions = new HtmlOptions();
saveOptions.SvgResponsiveLayout = true;
presentation.Save("SomePresentation-out.html", SaveFormat.Html, saveOptions);
```


## **Exporter des fichiers multimédias en HTML**
En utilisant Aspose.Slides pour .NET, vous pouvez exporter des fichiers multimédias de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence à la diapositive.
1. Ajoutez une vidéo à la diapositive.
1. Écrivez la présentation en tant que fichier HTML.

Ce code C# vous montre comment ajouter une vidéo à la présentation puis l'enregistrer en tant que HTML : 

```c#
// Charge une présentation
using (Presentation pres = new Presentation())
{
    string path = "C:/out/";
    const string fileName = "ExportMediaFiles_out.html";
    const string baseUri = "http://www.example.com/";

    using (FileStream fileStream = new FileStream("my_video.avi", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.ReadStreamAndRelease);
        
        ISlide slide = pres.Slides[0];
        slide.Shapes.AddVideoFrame(10, 10, 100, 100, video);
    }
        
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // Définit les options HTML
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    // Enregistre le fichier
    pres.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);
}
```