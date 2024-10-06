---
title: Convertir PowerPoint en HTML en Java
linktitle: Convertir PowerPoint en HTML
type: docs
weight: 30
url: /androidjava/convert-powerpoint-to-html/
keywords: "Java PowerPoint en HTML, Convertir présentation PowerPoint, PPTX, PPT, PPT en HTML, PPTX en HTML, PowerPoint en HTML, Enregistrer PowerPoint en tant qu'HTML, Enregistrer PPT en tant qu'HTML, Enregistrer PPTX en tant qu'HTML, Java, Aspose.Slides, exportation HTML"
description: "Convertir PowerPoint HTML en Java : Enregistrer PPTX ou PPT en tant qu'HTML en Java. Enregistrer des diapositives en tant qu'HTML en Java"
---

## **Aperçu**

Cet article explique comment convertir une présentation PowerPoint au format HTML à l'aide de Java. Il couvre les sujets suivants.

- Convertir PowerPoint en HTML en Java
- Convertir PPT en HTML en Java
- Convertir PPTX en HTML en Java
- Convertir ODP en HTML en Java
- Convertir une diapositive PowerPoint en HTML en Java

## **Java PowerPoint en HTML**

Pour un exemple de code Java pour convertir PowerPoint en HTML, veuillez consulter la section ci-dessous c'est-à-dire [Convertir PowerPoint en HTML](#convertir-powerpoint-en-html). Le code peut charger plusieurs formats comme PPT, PPTX et ODP dans un objet Presentation et l'enregistrer au format HTML.

## **À propos de la conversion PowerPoint en HTML**
À l'aide de [**Aspose.Slides pour Android via Java**](https://products.aspose.com/slides/androidjava/), les applications et les développeurs peuvent convertir une présentation PowerPoint en HTML : **PPTX en HTML** ou **PPT en HTML**.

**Aspose.Slides** propose de nombreuses options (principalement issues de la classe [**HtmlOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions)) qui définissent le processus de conversion de PowerPoint en HTML :

* Convertir l'ensemble d'une présentation PowerPoint en HTML.
* Convertir une diapositive spécifique dans une présentation PowerPoint en HTML.
* Convertir les médias de présentation (images, vidéos, etc.) en HTML.
* Convertir une présentation PowerPoint en HTML réactif. 
* Convertir une présentation PowerPoint en HTML avec des notes de conférencier incluses ou exclues. 
* Convertir une présentation PowerPoint en HTML avec des commentaires inclus ou exclus. 
* Convertir une présentation PowerPoint en HTML avec des polices originales ou intégrées. 
* Convertir une présentation PowerPoint en HTML tout en utilisant le nouveau style CSS. 

{{% alert color="primary" %}} 

À l'aide de sa propre API, Aspose a développé des convertisseurs [présentation en HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) gratuits : [PPT en HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX en HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP en HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc.

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Vous voudrez peut-être consulter d'autres [convertisseurs gratuits d'Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Remarque" color="warning" %}} 

En plus des processus de conversion décrits ici, Aspose.Slides prend également en charge ces opérations de conversion impliquant le format HTML : 

* [HTML en image](https://products.aspose.com/slides/androidjava/conversion/html-to-image/)
* [HTML en JPG](https://products.aspose.com/slides/androidjava/conversion/html-to-jpg/)
* [HTML en XML](https://products.aspose.com/slides/androidjava/conversion/html-to-xml/)
* [HTML en TIFF](https://products.aspose.com/slides/androidjava/conversion/html-to-tiff/)

{{% /alert %}}


## **Convertir PowerPoint en HTML**
À l'aide d'Aspose.Slides, vous pouvez convertir l'ensemble d'une présentation PowerPoint en HTML de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Utilisez la méthode [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) pour enregistrer l'objet en tant que fichier HTML.

Ce code vous montre comment convertir un PowerPoint en HTML en Java :

```java
// Instancier un objet Presentation représentant un fichier de présentation
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    HtmlOptions htmlOpt = new HtmlOptions();
	
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOpt.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));

    // Enregistrement de la présentation en HTML
    pres.save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Convertir PowerPoint en HTML réactif**
Aspose.Slides fournit la classe [ResponsiveHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ResponsiveHtmlController) qui vous permet de générer des fichiers HTML réactifs. Ce code vous montre comment convertir une présentation PowerPoint en HTML réactif en Java :

```java
// Instancier un objet Presentation représentant un fichier de présentation
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));

    // Enregistrement de la présentation en HTML
    pres.save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint en HTML avec des notes**
Ce code vous montre comment convertir un PowerPoint en HTML avec des notes en Java :

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    HtmlOptions opt = new HtmlOptions();
	
    INotesCommentsLayoutingOptions options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);

    // Enregistrement des pages de notes
    pres.save("Output.html", SaveFormat.Html, opt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint en HTML avec des polices originales**

Aspose.Slides fournit la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) qui vous permet d'incorporer toutes les polices dans une présentation lors de la conversion de la présentation en HTML.

Pour empêcher certaines polices d'être intégrées, vous pouvez passer un tableau de noms de polices à un constructeur paramétré de la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController). Les polices populaires, telles que Calibri ou Arial, lorsqu'elles sont utilisées dans une présentation, n'ont pas besoin d'être intégrées car la plupart des systèmes contiennent déjà de telles polices. Lorsque ces polices sont intégrées, le document HTML résultant devient inutilement volumineux.

La classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) prend en charge l'héritage et fournit la méthode [WriteFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) qui est destinée à être remplacée.

```java
Presentation pres = new Presentation("input.pptx");
try {
    // exclure les polices de présentation par défaut
    String[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(HtmlFormatter.createCustomFormatter(embedFontsController));

    pres.save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint en HTML avec des images de haute qualité**

Par défaut, lorsque vous convertissez PowerPoint en HTML, Aspose.Slides génère un petit HTML avec des images à 72 DPI et supprime les zones recadrées. Pour obtenir des fichiers HTML avec des images de meilleure qualité, vous devez définir la propriété `PicturesCompression` (de la classe `HtmlOptions`) sur 96 (c'est-à-dire `PicturesCompression.Dpi96`) ou des [valeurs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PicturesCompression) supérieures.

Ce code Java vous montre comment convertir une présentation PowerPoint en HTML tout en obtenant des images de haute qualité à 150 DPI (c'est-à-dire `PicturesCompression.Dpi150`) :

```java
Presentation pres = new Presentation("InputDoc.pptx");
try {
    HtmlOptions htmlOpts = new HtmlOptions();
    htmlOpts.setPicturesCompression(PicturesCompression.Dpi150);
    
    pres.save("OutputDoc-dpi150.html", SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) pres.dispose();
}
```

Ce code en Java vous montre comment produire du HTML avec des images de pleine qualité :

```java
Presentation pres = new Presentation("InputDoc.pptx");
try {
    HtmlOptions htmlOpts = new HtmlOptions();
    htmlOpts.setDeletePicturesCroppedAreas(false);

    pres.save("Outputdoc-noCrop.html", SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir une diapositive en HTML**
Pour convertir une diapositive spécifique d'un PowerPoint en HTML, vous devez instancier la même classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) (utilisée pour convertir des présentations entières en HTML) et ensuite utiliser la méthode [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) pour enregistrer le fichier en tant que HTML. La classe [HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions) peut être utilisée pour spécifier des options de conversion supplémentaires :

Ce code Java vous montre comment convertir une diapositive dans une présentation PowerPoint en HTML :

```java
Presentation pres = new Presentation("Individual-Slide.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(new CustomFormattingController()));

    // Enregistrement du fichier
    for (int i = 0; i < pres.getSlides().size(); i++)
        pres.save("Diapositive Individuelle" + (i + 1) + "_out.html", new int[]{i + 1},SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
public class CustomFormattingController implements IHtmlFormattingController
{
    @Override
    public void writeDocumentStart(IHtmlGenerator generator, IPresentation presentation) { }

    @Override
    public void writeDocumentEnd(IHtmlGenerator generator, IPresentation presentation) { }

    @Override
    public void writeSlideStart(IHtmlGenerator generator, ISlide slide) 
	{
        generator.addHtml(String.format(SlideHeader, generator.getSlideIndex() + 1));
    }

    @Override
    public void writeSlideEnd(IHtmlGenerator generator, ISlide slide) 
	{
        generator.addHtml(SlideFooter);
    }

    @Override
    public void writeShapeStart(IHtmlGenerator generator, IShape shape) { }

    @Override
    public void writeShapeEnd(IHtmlGenerator generator, IShape shape) { }

    private final String SlideHeader = "<div class=\"slide\" name=\"slide\" id=\"slide%d\">";
    private final String SlideFooter = "</div>";
}
```


## **Enregistrer CSS et images lors de l'exportation vers HTML**
À l'aide de nouveaux fichiers de styles CSS, vous pouvez facilement changer le style du fichier HTML résultant du processus de conversion PowerPoint en HTML. 

Le code Java dans cet exemple vous montre comment utiliser des méthodes remplaçables pour créer un document HTML personnalisé avec un lien vers un fichier CSS :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    CustomHeaderAndFontsController htmlController = new CustomHeaderAndFontsController("styles.css");
    HtmlOptions options = new HtmlOptions();
    options.setHtmlFormatter(HtmlFormatter.createCustomFormatter(htmlController));

    pres.save("pres.html", SaveFormat.Html, options);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public class CustomHeaderAndFontsController extends EmbedAllFontsHtmlController
{
    private final int m_basePath = 0;

    // Modèle d'en-tête personnalisé
    final static String Header = "<!DOCTYPE html>\n" +
            "<html>\n" +
            "<head>\n" +
            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n" +
            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" +
            "<link rel=\"stylesheet\" type=\"text/css\" href=\"%s\">\n" +
            "</head>";

    private final String m_cssFileName;

    public CustomHeaderAndFontsController(String cssFileName) 
    {
        m_cssFileName = cssFileName;
    }

    public void writeDocumentStart(IHtmlGenerator generator, IPresentation presentation) 
    {
        generator.addHtml(String.format(Header, m_cssFileName));
        writeAllFonts(generator, presentation);
    }

    public void writeAllFonts(IHtmlGenerator generator, IPresentation presentation) 
    {
        generator.addHtml("<!-- Polices intégrées -->");
        super.writeAllFonts(generator, presentation);
    }
}
```

## **Lier toutes les polices lors de la conversion de présentation en HTML**

Si vous ne souhaitez pas intégrer les polices (pour éviter d'augmenter la taille du HTML résultant), vous pouvez lier toutes les polices en implémentant votre propre version de `LinkAllFontsHtmlController`. 

Ce code Java vous montre comment convertir un PowerPoint en HTML tout en liant toutes les polices et en excluant "Calibri" et "Arial" (puisqu'elles existent déjà dans le système) : 

```java
Presentation pres = new Presentation("pres.pptx");
try
{
    //Exclure les polices de présentation par défaut
    String[] fontNameExcludeList = { "Calibri", "Arial" };

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList,"C:/Windows/Fonts/");

    HtmlOptions htmlOptionsEmbed = new HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(HtmlFormatter.createCustomFormatter((IHtmlFormattingController) linkcont));

    pres.save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
finally {
    if (pres != null) pres.dispose();
}
```

Ce code Java montre comment `LinkAllFontsHtmlController` est implémenté :

```java
public class LinkAllFontsHtmlController extends EmbedAllFontsHtmlController
{
    private final String m_basePath;

    public LinkAllFontsHtmlController(String[] fontNameExcludeList, String basePath)
    {
        super(fontNameExcludeList);
        m_basePath = basePath;
    }

    public void writeFont
    (
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData)
    {
        try {
            String fontName = substitutedFont == null ? originalFont.getFontName() : substitutedFont.getFontName();
            String path = fontName + ".woff"; // une certaine sanitation de chemin peut être nécessaire
            Files.write(new File(m_basePath + path).toPath(), fontData, StandardOpenOption.CREATE);

            generator.addHtml("<style>");
            generator.addHtml("@font-face { ");
            generator.addHtml("font-family: '" + fontName + "'; ");
            generator.addHtml("src: url('" + path + "')");

            generator.addHtml(" }");
            generator.addHtml("</style>");
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }
}
```

## **Convertir PowerPoint en HTML réactif**
Ce code Java vous montre comment convertir une présentation PowerPoint en HTML réactif :

```java
Presentation pres = new Presentation("SomePresentation.pptx");
try {
    HtmlOptions saveOptions = new HtmlOptions();
    saveOptions.setSvgResponsiveLayout(true);
    pres.save("SomePresentation-out.html", SaveFormat.Html, saveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Exporter des fichiers multimédias vers HTML**
En utilisant Aspose.Slides pour Android via Java, vous pouvez exporter des fichiers multimédias de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtenez une référence à la diapositive.
1. Ajoutez une vidéo à la diapositive.
1. Écrivez la présentation en tant que fichier HTML.

Ce code Java vous montre comment ajouter une vidéo à la présentation et ensuite l'enregistrer en tant que HTML : 

```java
// Charger une présentation
Presentation pres = new Presentation();
try {
    String path = "./out/";
    final String fileName = "ExportMediaFiles_out.html";
    final String baseUri = "http://www.example.com/";

    byte[] videoData = Files.readAllBytes(Paths.get("my_video.avi"));
    IVideo video = pres.getVideos().addVideo(videoData);
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // Définir les options HTML
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));
    htmlOptions.setSlideImageFormat(SlideImageFormat.svg(svgOptions));

    // Enregistrement du fichier
    pres.save(fileName, SaveFormat.Html, htmlOptions);
} catch(Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```