---
title: Convertir des présentations PowerPoint en HTML sur Android
linktitle: PowerPoint en HTML
type: docs
weight: 30
url: /fr/androidjava/convert-powerpoint-to-html/
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
- enregistrer PowerPoint au format HTML
- enregistrer présentation au format HTML
- enregistrer diapositive au format HTML
- enregistrer PPT au format HTML
- enregistrer PPTX au format HTML
- exporter PPT en HTML
- exporter PPTX en HTML
- Android
- Java
- Aspose.Slides
description: "Convertir des présentations PowerPoint en HTML réactif avec Java. Conserver la mise en page, les liens et les images grâce à Aspose.Slides pour Android, guide de conversion pour des résultats rapides et impeccables."
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format HTML en utilisant Java. Il couvre les sujets suivants.

- Convertir PowerPoint en HTML avec Java
- Convertir PPT en HTML avec Java
- Convertir PPTX en HTML avec Java
- Convertir ODP en HTML avec Java
- Convertir une diapositive PowerPoint en HTML avec Java

## **PowerPoint en HTML sur Android**

Pour le code d'exemple Java permettant de convertir PowerPoint en HTML, veuillez consulter la section ci‑dessus, c’est‑à‑dire [Convertir PowerPoint en HTML](#convert-powerpoint-to-html). Le code peut charger plusieurs formats tels que PPT, PPTX et ODP dans l'objet Presentation et les enregistrer au format HTML.

## **À propos de la conversion PowerPoint en HTML**

En utilisant [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/), les applications et les développeurs peuvent convertir une présentation PowerPoint en HTML : **PPTX en HTML** ou **PPT en HTML**.

**Aspose.Slides** fournit de nombreuses options (principalement depuis la classe [**HtmlOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions)) qui définissent le processus de conversion PowerPoint en HTML :

* Convertir une présentation PowerPoint entière en HTML.
* Convertir une diapositive spécifique d’une présentation PowerPoint en HTML.
* Convertir les médias de la présentation (images, vidéos, etc.) en HTML.
* Convertir une présentation PowerPoint en HTML réactif.
* Convertir une présentation PowerPoint en HTML avec les notes du présentateur incluses ou exclues.
* Convertir une présentation PowerPoint en HTML avec les commentaires inclus ou exclus.
* Convertir une présentation PowerPoint en HTML avec les polices originales ou incorporées.
* Convertir une présentation PowerPoint en HTML tout en utilisant le nouveau style CSS.

{{% alert color="primary" %}} 

En utilisant sa propre API, Aspose a développé des convertisseurs gratuits [présentation vers HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) : [PPT en HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX en HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP en HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Vous pouvez également consulter d’autres [convertisseurs gratuits d’Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

## **Convertir PowerPoint en HTML**

En utilisant Aspose.Slides, vous pouvez convertir une présentation PowerPoint entière en HTML de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Utilisez la méthode [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) pour enregistrer l’objet sous forme de fichier HTML.

Ce code montre comment convertir un PowerPoint en HTML avec Java :
```java
// Instancier un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    HtmlOptions htmlOpt = new HtmlOptions();
	
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOpt.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));

    // Enregistrer la présentation en HTML
    pres.save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Convertir PowerPoint en HTML réactif**

Aspose.Slides fournit la classe [ResponsiveHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ResponsiveHtmlController) qui permet de générer des fichiers HTML réactifs. Ce code montre comment convertir une présentation PowerPoint en HTML réactif avec Java :
```java
// Instancier un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));

    // Enregistrer la présentation en HTML
    pres.save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Convertir PowerPoint en HTML avec notes**

Ce code montre comment convertir un PowerPoint en HTML avec notes en Java :
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


## **Convertir PowerPoint en HTML avec les polices originales**

Aspose.Slides fournit la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) qui permet d’incorporer toutes les polices d’une présentation lors de sa conversion en HTML.

Pour éviter d’incorporer certaines polices, vous pouvez transmettre un tableau de noms de police à un constructeur paramétré de la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController). Les polices populaires, telles que Calibri ou Arial, lorsqu’elles sont utilisées dans une présentation, n’ont pas besoin d’être incorporées car la plupart des systèmes les possèdent déjà. Lorsque ces polices sont incorporées, le document HTML résultant devient inutilement volumineux.

La classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) prend en charge l’héritage et fournit la méthode [WriteFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-), destinée à être surchargée.
```java
Presentation pres = new Presentation("input.pptx");
try {
    // exclure les polices par défaut de la présentation
    String[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(HtmlFormatter.createCustomFormatter(embedFontsController));

    pres.save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Convertir PowerPoint en HTML avec images de haute qualité**

Par défaut, lors de la conversion de PowerPoint en HTML, Aspose.Slides génère un petit fichier HTML avec des images à 72 dpi et supprime les zones recadrées. Pour obtenir des fichiers HTML avec des images de meilleure qualité, vous devez définir la propriété `PicturesCompression` (de la classe `HtmlOptions`) à 96 (c’est‑à‑dire `PicturesCompression.Dpi96`) ou à une valeur supérieure [valeurs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PicturesCompression).

Ce code Java montre comment convertir une présentation PowerPoint en HTML tout en obtenant des images de haute qualité à 150 dpi (c’est‑à‑dire `PicturesCompression.Dpi150`) :
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


Ce code Java montre comment générer du HTML avec des images en pleine qualité :
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

Pour convertir une diapositive spécifique d’un PowerPoint en HTML, vous devez instancier la même classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) (utilisée pour convertir des présentations complètes en HTML), puis utiliser la méthode [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) pour enregistrer le fichier au format HTML. La classe [HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions) peut être utilisée pour spécifier des options de conversion supplémentaires :

Ce code Java montre comment convertir une diapositive d’une présentation PowerPoint en HTML :
```java
Presentation pres = new Presentation("Individual-Slide.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(new CustomFormattingController()));

    // Enregistrement du fichier
    for (int i = 0; i < pres.getSlides().size(); i++)
        pres.save("Individual Slide" + (i + 1) + "_out.html", new int[]{i + 1},SaveFormat.Html, htmlOptions);
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


## **Enregistrer le CSS et les images lors de l’exportation en HTML**

En utilisant de nouveaux fichiers de style CSS, vous pouvez facilement modifier le style du fichier HTML résultant du processus de conversion PowerPoint en HTML. 

Le code Java de cet exemple montre comment utiliser des méthodes surchargables pour créer un document HTML personnalisé avec un lien vers un fichier CSS :
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
        generator.addHtml("<!-- Embedded fonts -->");
        super.writeAllFonts(generator, presentation);
    }
}
```


## **Lier toutes les polices lors de la conversion d’une présentation en HTML**

Si vous ne souhaitez pas incorporer les polices (pour éviter d’augmenter la taille du HTML résultant), vous pouvez lier toutes les polices en implémentant votre propre version de `LinkAllFontsHtmlController`.

Ce code Java montre comment convertir un PowerPoint en HTML tout en liant toutes les polices et en excluant « Calibri » et « Arial » (puisqu’elles existent déjà dans le système) :
```java
Presentation pres = new Presentation("pres.pptx");
try
{
    //Exclure les polices par défaut de la présentation
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
            String path = fontName + ".woff"; // une certaine désinfection du chemin peut être nécessaire
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

Ce code Java montre comment convertir une présentation PowerPoint en HTML réactif :
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


## **Exporter les fichiers multimédia en HTML**

En utilisant Aspose.Slides for Android via Java, vous pouvez exporter les fichiers multimédia de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez une référence à la diapositive.
3. Ajoutez une vidéo à la diapositive.
4. Enregistrez la présentation sous forme de fichier HTML.

Ce code Java montre comment ajouter une vidéo à la présentation puis l’enregistrer en HTML :
```java
// Chargement d'une présentation
Presentation pres = new Presentation();
try {
    String path = "./out/";
    final String fileName = "ExportMediaFiles_out.html";
    final String baseUri = "http://www.example.com/";

    byte[] videoData = Files.readAllBytes(Paths.get("my_video.avi"));
    IVideo video = pres.getVideos().addVideo(videoData);
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // Définition des options HTML
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


## **FAQ**

**Quelle est la performance d’Aspose.Slides lors de la conversion de plusieurs présentations en HTML ?**

La performance dépend de la taille et de la complexité des présentations. Aspose.Slides est très efficace et évolutif pour les opérations par lots. Pour obtenir des performances optimales lors de la conversion d’un grand nombre de présentations, il est recommandé d’utiliser le multithreading ou le traitement parallèle dès que possible.

**Aspose.Slides prend‑t‑il en charge l’exportation des hyperliens vers HTML ?**

Oui, Aspose.Slides supporte pleinement l’exportation des hyperliens intégrés vers HTML. Lors de la conversion des présentations au format HTML, les hyperliens sont automatiquement conservés et restent cliquables.

**Y a‑t‑il une limite au nombre de diapositives lors de la conversion de présentations en HTML ?**

Il n’y a aucune limite au nombre de diapositives lors de l’utilisation d’Aspose.Slides. Vous pouvez convertir des présentations de toute taille. Cependant, pour les présentations contenant un très grand nombre de diapositives, les performances peuvent dépendre des ressources disponibles sur votre serveur ou système.