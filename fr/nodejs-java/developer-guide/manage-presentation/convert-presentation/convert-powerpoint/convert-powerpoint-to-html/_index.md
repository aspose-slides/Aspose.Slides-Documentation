---
title: Convertir des présentations PowerPoint en HTML avec JavaScript
linktitle: PowerPoint en HTML
type: docs
weight: 30
url: /fr/nodejs-java/convert-powerpoint-to-html/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir des présentations PowerPoint en HTML responsive. Conserver la mise en page, les liens et les images grâce au guide de conversion Aspose.Slides pour des résultats rapides et impeccables."
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format HTML en utilisant JavaScript. Il couvre les sujets suivants.

- Convertir PowerPoint en HTML avec JavaScript
- Convertir PPT en HTML avec JavaScript
- Convertir PPTX en HTML avec JavaScript
- Convertir ODP en HTML avec JavaScript
- Convertir une diapositive PowerPoint en HTML avec JavaScript

## **PowerPoint JavaScript en HTML**

Pour le code d'exemple JavaScript permettant de convertir PowerPoint en HTML, veuillez consulter la section ci‑dessous, à savoir [Convertir PowerPoint en HTML](#convert-powerpoint-to-html). Le code peut charger plusieurs formats tels que PPT, PPTX et ODP dans l'objet Presentation et les enregistrer au format HTML.

## **À propos de la conversion PowerPoint en HTML**
En utilisant [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/), les applications et les développeurs peuvent convertir une présentation PowerPoint en HTML : **PPTX en HTML** ou **PPT en HTML**.

**Aspose.Slides** propose de nombreuses options (principalement de la classe [**HtmlOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions)) qui définissent le processus de conversion PowerPoint en HTML :

* Convertir une présentation PowerPoint complète en HTML.
* Convertir une diapositive spécifique d’une présentation PowerPoint en HTML.
* Convertir les médias de la présentation (images, vidéos, etc.) en HTML.
* Convertir une présentation PowerPoint en HTML responsive.
* Convertir une présentation PowerPoint en HTML avec ou sans notes du présentateur.
* Convertir une présentation PowerPoint en HTML avec ou sans commentaires.
* Convertir une présentation PowerPoint en HTML avec les polices originales ou incorporées.
* Convertir une présentation PowerPoint en HTML en utilisant le nouveau style CSS.

{{% alert color="primary" %}} 

En utilisant sa propre API, Aspose a développé des convertisseurs gratuits [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) : [PPT en HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX en HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP en HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Vous pouvez consulter d’autres [convertisseurs gratuits d’Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

## **Convertir PowerPoint en HTML**
Avec Aspose.Slides, vous pouvez convertir une présentation PowerPoint complète en HTML de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Utilisez la méthode [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) pour enregistrer l’objet sous forme de fichier HTML.

Ce code montre comment convertir un PowerPoint en HTML avec JavaScript:
```javascript
// Instancier un objet Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("Convert_HTML.pptx");
try {
    var htmlOpt = new aspose.slides.HtmlOptions();
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    htmlOpt.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
    // Enregistrer la présentation en HTML
    pres.save("ConvertWholePresentationToHTML_out.html", aspose.slides.SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convertir PowerPoint en HTML responsive**
Aspose.Slides fournit la classe [ResponsiveHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ResponsiveHtmlController) qui permet de générer des fichiers HTML responsive. Ce code montre comment convertir une présentation PowerPoint en HTML responsive avec JavaScript :
```javascript
// Instancier un objet Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("Convert_HTML.pptx");
try {
    var controller = new aspose.slides.ResponsiveHtmlController();
    var htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(controller));
    // Enregistrement de la présentation en HTML
    pres.save("ConvertPresentationToResponsiveHTML_out.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convertir PowerPoint en HTML avec notes**
Ce code montre comment convertir un PowerPoint en HTML avec notes en JavaScript :
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var opt = new aspose.slides.HtmlOptions();
    var options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Enregistrement des pages de notes
    pres.save("Output.html", aspose.slides.SaveFormat.Html, opt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convertir PowerPoint en HTML avec les polices originales**
Aspose.Slides fournit la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) qui permet d’intégrer toutes les polices d’une présentation lors de la conversion de celle‑ci en HTML.

Pour empêcher l’intégration de certaines polices, vous pouvez passer un tableau de noms de polices à un constructeur paramétré de la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController). Les polices populaires, telles que Calibri ou Arial, lorsqu’elles sont utilisées dans une présentation, n’ont pas besoin d’être intégrées car la plupart des systèmes les contiennent déjà. Lorsque ces polices sont intégrées, le document HTML résultant devient inutilement volumineux.

La classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) prend en charge l’héritage et fournit la méthode [WriteFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-aspose.slides.IHtmlGenerator-aspose.slides.IFontData-aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) qui est destinée à être surchargée.
```javascript
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // exclure les polices par défaut de la présentation
    var fontNameExcludeList = java.newArray("java.lang.String", ["Calibri", "Arial"]));
    var embedFontsController = new aspose.slides.EmbedAllFontsHtmlController(fontNameExcludeList);
    var htmlOptionsEmbed = new aspose.slides.HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(embedFontsController));
    pres.save("input-PFDinDisplayPro-Regular-installed.html", aspose.slides.SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convertir PowerPoint en HTML avec images de haute qualité**
Par défaut, lorsque vous convertissez PowerPoint en HTML, Aspose.Slides génère un petit HTML avec des images à 72 DPI et supprime les zones recadrées. Pour obtenir des fichiers HTML avec des images de meilleure qualité, vous devez passer `96` à la méthode `setPicturesCompression` de la classe `HtmlOptions` (c’est‑à‑dire, `PicturesCompression.Dpi96`) ou des [valeurs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PicturesCompression) supérieures.

Ce code JavaScript montre comment convertir une présentation PowerPoint en HTML tout en obtenant des images de haute qualité à 150 DPI (c’est‑à‑dire `PicturesCompression.Dpi150`) :
```javascript
var pres = new aspose.slides.Presentation("InputDoc.pptx");
try {
    var htmlOpts = new aspose.slides.HtmlOptions();
    htmlOpts.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);
    pres.save("OutputDoc-dpi150.html", aspose.slides.SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Ce code JavaScript montre comment générer du HTML avec des images en pleine qualité :
```javascript
var pres = new aspose.slides.Presentation("InputDoc.pptx");
try {
    var htmlOpts = new aspose.slides.HtmlOptions();
    htmlOpts.setDeletePicturesCroppedAreas(false);
    pres.save("Outputdoc-noCrop.html", aspose.slides.SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convertir une diapositive en HTML**
Pour convertir une diapositive spécifique d’un PowerPoint en HTML, vous devez instancier la même classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) (utilisée pour convertir des présentations complètes en HTML) puis utiliser la méthode [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) pour enregistrer le fichier au format HTML. La classe [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions) peut être utilisée pour spécifier des options de conversion supplémentaires :
```javascript
var pres = new aspose.slides.Presentation("Individual-Slide.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    
    const CustomFormattingController = java.newProxy("com.aspose.slides.IHtmlFormattingController", {
        writeDocumentStart: function(generator, presentation) {

        },

        writeDocumentEnd: function(generator, presentation) {

        },

        writeSlideStart: function(generator, slide) {
            const slideIndex = generator.getSlideIndex() + 1;
            const slideHeaderHtml = `<div class="slide" name="slide" id="slide${slideIndex}">`;
            generator.addHtml(slideHeaderHtml);
        },

        writeSlideEnd: function(generator, slide) {
            const slideFooterHtml = "</div>";
            generator.addHtml(slideFooterHtml);
        },

        writeShapeStart: function(generator, shape) {
        },

        writeShapeEnd: function(generator, shape) {
        }
    });
    
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(CustomFormattingController));
    // Enregistrement du fichier
    for (var i = 0; i < pres.getSlides().size(); i++) {
        pres.save(("Individual Slide" + (i + 1)) + "_out.html", java.newArray("int", [i + 1]), aspose.slides.SaveFormat.Html, htmlOptions);
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Enregistrer CSS et images lors de l’exportation en HTML**
En utilisant de nouveaux fichiers de style CSS, vous pouvez facilement modifier le style du fichier HTML résultant du processus de conversion PowerPoint en HTML.

Le code JavaScript de cet exemple montre comment utiliser des méthodes surchargeables pour créer un document HTML personnalisé avec un lien vers un fichier CSS :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var htmlController = java.newInstanceSync("CustomHeaderAndFontsController", "styles.css");
    var options = new aspose.slides.HtmlOptions();
    options.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(htmlController));
    pres.save("pres.html", aspose.slides.SaveFormat.Html, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Vous devrez implémenter CustomHeaderAndFontsController en Java, le compiler et le ajouter à l’emplacement du module \aspose.slides.via.java\lib\.
Ce code Java montre comment `CustomHeaderAndFontsController` est implémenté :
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

Ce code JavaScript montre comment convertir un PowerPoint en HTML tout en liant toutes les polices et en excluant « Calibri » et « Arial » (puisqu’elles existent déjà sur le système) :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Exclure les polices par défaut de la présentation
    var fontNameExcludeList = java.newArray("java.lang.String", ["Calibri", "Arial"]));
    var linkcont = java.newInstanceSync("LinkAllFontsHtmlController", fontNameExcludeList, "C:/Windows/Fonts/");
    var htmlOptionsEmbed = new aspose.slides.HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(linkcont));
    pres.save("pres.html", aspose.slides.SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Vous devrez implémenter LinkAllFontsHtmlController en Java, le compiler et le ajouter à l’emplacement du module \aspose.slides.via.java\lib\.
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
            String path = fontName + ".woff"; // une désinfection du chemin peut être nécessaire
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


## **Convertir PowerPoint en HTML responsive**
Ce code JavaScript montre comment convertir une présentation PowerPoint en HTML responsive :
```javascript
var pres = new aspose.slides.Presentation("SomePresentation.pptx");
try {
    var saveOptions = new aspose.slides.HtmlOptions();
    saveOptions.setSvgResponsiveLayout(true);
    pres.save("SomePresentation-out.html", aspose.slides.SaveFormat.Html, saveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Exporter des fichiers multimédia en HTML**
Avec Aspose.Slides for Node.js via Java, vous pouvez exporter des fichiers multimédia de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenez une référence à la diapositive.
3. Ajoutez une vidéo à la diapositive.
4. Enregistrez la présentation sous forme de fichier HTML.

Ce code JavaScript montre comment ajouter une vidéo à la présentation puis l’enregistrer en HTML :
```javascript
// Chargement d'une présentation
var pres = new aspose.slides.Presentation();
try {
    var path = "./out/";
    final var fileName = "ExportMediaFiles_out.html";
    final var baseUri = "http://www.example.com/";
    var videoData = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "my_video.avi"));
    var video = pres.getVideos().addVideo(videoData);
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    var controller = new aspose.slides.VideoPlayerHtmlController(path, fileName, baseUri);
    // Définition des options HTML
    var htmlOptions = new aspose.slides.HtmlOptions(controller);
    var svgOptions = new aspose.slides.SVGOptions(controller);
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(controller));
    htmlOptions.setSlideImageFormat(aspose.slides.SlideImageFormat.svg(svgOptions));
    // Enregistrement du fichier
    pres.save(fileName, aspose.slides.SaveFormat.Html, htmlOptions);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Quelle est la performance d’Aspose.Slides lors de la conversion de plusieurs présentations en HTML ?**

La performance dépend de la taille et de la complexité des présentations. Aspose.Slides est très efficace et évolutif pour les traitements par lots. Pour obtenir des performances optimales lors de la conversion d’un grand nombre de présentations, il est recommandé d’utiliser le multithreading ou le traitement parallèle dès que possible.

**Aspose.Slides prend‑il en charge l’exportation des hyperliens vers HTML ?**

Oui, Aspose.Slides prend entièrement en charge l’exportation des hyperliens intégrés vers HTML. Lors de la conversion des présentations au format HTML, les hyperliens sont automatiquement conservés et restent cliquables.

**Existe‑t‑il une limite au nombre de diapositives lors de la conversion de présentations en HTML ?**

Il n’y a aucune limite au nombre de diapositives avec Aspose.Slides. Vous pouvez convertir des présentations de toute taille. Cependant, pour des présentations contenant un très grand nombre de diapositives, la performance peut dépendre des ressources disponibles sur votre serveur ou votre système.