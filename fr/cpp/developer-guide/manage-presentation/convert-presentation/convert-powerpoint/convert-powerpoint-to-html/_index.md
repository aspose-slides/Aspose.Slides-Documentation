---
title: Convertir les présentations PowerPoint en HTML en C++
linktitle: PowerPoint vers HTML
type: docs
weight: 30
url: /fr/cpp/convert-powerpoint-to-html/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint vers HTML
- présentation vers HTML
- diapositive vers HTML
- PPT vers HTML
- PPTX vers HTML
- enregistrer PowerPoint en HTML
- enregistrer présentation en HTML
- enregistrer diapositive en HTML
- enregistrer PPT en HTML
- enregistrer PPTX en HTML
- exporter PPT en HTML
- exporter PPTX en HTML
- C++
- Aspose.Slides
description: "Convertir les présentations PowerPoint en HTML réactif en C++. Conservez la mise en page, les liens et les images avec le guide de conversion Aspose.Slides pour des résultats rapides et impeccables."
---

## **À propos de la conversion PowerPoint vers HTML**
En utilisant [**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/), les applications et les développeurs peuvent convertir une présentation PowerPoint en HTML : **PPTX vers HTML** ou **PPT vers HTML**. 

**Aspose.Slides** offre de nombreuses options (principalement à partir de la classe [**HtmlOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options)) qui définissent le processus de conversion PowerPoint en HTML :

* Convertir une présentation PowerPoint complète en HTML.  
* Convertir une diapositive spécifique d’une présentation PowerPoint en HTML.  
* Convertir les médias de la présentation (images, vidéos, etc.) en HTML.  
* Convertir une présentation PowerPoint en HTML réactif.  
* Convertir une présentation PowerPoint en HTML avec les notes du présentateur incluses ou exclues.  
* Convertir une présentation PowerPoint en HTML avec les commentaires inclus ou exclus.  
* Convertir une présentation PowerPoint en HTML avec les polices originales ou incorporées.  
* Convertir une présentation PowerPoint en HTML en utilisant le nouveau style CSS. 

{{% alert color="primary" %}} 

En utilisant son API propre, Aspose a développé des convertisseurs gratuits [présentation vers HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) : [PPT vers HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX vers HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP vers HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Vous souhaiterez peut‑être consulter d’autres [convertisseurs gratuits d’Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

En plus des processus de conversion décrits ici, Aspose.Slides prend également en charge les opérations de conversion suivantes impliquant le format HTML :

* [HTML vers image](https://products.aspose.com/slides/cpp/conversion/html-to-image/)  
* [HTML vers JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)  
* [HTML vers XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)  
* [HTML vers TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}


## **Convertir PowerPoint en HTML**
Avec Aspose.Slides, vous pouvez convertir une présentation PowerPoint complète en HTML de la manière suivante :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).  
   * Charger **.ppt** dans la classe _Presentation_ pour **Convertir PPT en HTML en C++**  
   * Charger **.pptx** dans la classe _Presentation_ pour **Convertir PPTX en HTML en C++**  
   * Charger **.odp** dans la classe _Presentation_ pour **Convertir ODP en HTML en C++**  
3. Utiliser la méthode [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) pour enregistrer l’objet sous forme de fichier HTML.

Ce code vous montre comment convertir un PowerPoint en HTML en C++ :
```cpp
// Instancier un objet Presentation qui représente un fichier de présentation
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");
    
auto htmlOpt = System::MakeObject<HtmlOptions>();
htmlOpt->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(u"", false));

// Enregistrement de la présentation en HTML
presentation->Save(u"ConvertWholePresentationToHTML_out.html", SaveFormat::Html, htmlOpt);
```


## **Convertir PowerPoint en HTML réactif**
Aspose.Slides fournit la classe [ResponsiveHtmlController ](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.responsive_html_controller) qui vous permet de générer des fichiers HTML réactifs. Ce code vous montre comment convertir une présentation PowerPoint en HTML réactif en C++ :
```cpp
// Instancier un objet Presentation qui représente un fichier de présentation
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));

// Enregistrement de la présentation en HTML
presentation->Save(u"ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, htmlOptions);
```


## **Convertir PowerPoint en HTML avec notes**
Ce code vous montre comment convertir un PowerPoint en HTML avec notes en C++ :
```cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

auto opt = System::MakeObject<HtmlOptions>();

auto options = opt->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// Saving notes pages
pres->Save(u"Output.html", SaveFormat::Html, opt);
```


## **Convertir PowerPoint en HTML avec polices originales**
Aspose.Slides fournit la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedallfontshtmlcontroller/) qui vous permet d’incorporer toutes les polices d’une présentation lors de la conversion de la présentation en HTML.

Pour empêcher l’incorporation de certaines polices, vous pouvez transmettre un tableau de noms de polices à un constructeur paramétré de la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedallfontshtmlcontroller/). Les polices courantes, comme Calibri ou Arial, lorsqu’elles sont utilisées dans une présentation, n’ont pas besoin d’être incorporées car la plupart des systèmes les possèdent déjà. Lorsque ces polices sont incorporées, le document HTML résultant devient inutilement volumineux.

La classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedallfontshtmlcontroller/) prend en charge l’héritage et fournit la méthode [WriteFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedallfontshtmlcontroller/writefont/) qui est destinée à être surchargée. 
```cpp
auto pres = System::MakeObject<Presentation>(u"input.pptx");

// exclure les polices par défaut de la présentation
auto fontNameExcludeList = System::MakeArray<System::String>({ u"Calibri", u"Arial" });

auto embedFontsController = System::MakeObject<EmbedAllFontsHtmlController>(fontNameExcludeList);

auto htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(embedFontsController));

pres->Save(u"input-PFDinDisplayPro-Regular-installed.html", SaveFormat::Html, htmlOptionsEmbed);
```


## **Convertir PowerPoint en HTML avec images haute qualité**
Par défaut, lors de la conversion d’un PowerPoint en HTML, Aspose.Slides génère un HTML léger avec des images à 72 DPI et supprime les zones recadrées. Pour obtenir des fichiers HTML avec des images de meilleure qualité, vous devez définir la propriété `PicturesCompression` (de la classe `HtmlOptions`) à 96 (c’est‑à‑dire `PicturesCompression::Dpi96`) ou à une valeur supérieure [valeurs](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.export#adc51ca67b7e5c99f6fad75b02ebfd6d8).

Ce code C++ vous montre comment convertir une présentation PowerPoint en HTML tout en obtenant des images de haute qualité à 150 DPI (c’est‑à‑dire `PicturesCompression::Dpi150`) :
```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_PicturesCompression(PicturesCompression::Dpi150);

pres->Save(u"OutputDoc-dpi150.html", SaveFormat::Html, htmlOpts);
```


Ce code en C++ vous montre comment générer du HTML avec des images en pleine qualité :
```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_DeletePicturesCroppedAreas(false);

pres->Save(u"Outputdoc-noCrop.html", SaveFormat::Html, htmlOpts);
```


## **Convertir une diapositive en HTML**
Pour convertir une diapositive spécifique d’un PowerPoint en HTML, vous devez instancier la même classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) (utilisée pour convertir des présentations entières en HTML) puis utiliser la méthode [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) afin d’enregistrer le fichier au format HTML. La classe [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) peut être utilisée pour spécifier des options de conversion supplémentaires :

Ce code C++ vous montre comment convertir une diapositive d’une présentation PowerPoint en HTML :
``` cpp
class CustomFormattingController : public IHtmlFormattingController
{
public:
    void WriteDocumentStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override{}
    void WriteDocumentEnd(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override{}
    void WriteSlideStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<ISlide> slide) override
    {
        generator->AddHtml(String::Format(SlideHeader, generator->get_SlideIndex() + 1));
    }
    void WriteSlideEnd(SharedPtr<IHtmlGenerator> generator, SharedPtr<ISlide> slide) override
    {
        generator->AddHtml(SlideFooter);
    }
    void WriteShapeStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<IShape> shape) override{}
    void WriteShapeEnd(SharedPtr<IHtmlGenerator> generator, SharedPtr<IShape> shape) override{}

private:
    static const String SlideHeader;
    static const String SlideFooter;
};

const String CustomFormattingController::SlideHeader = u"<div class=\"slide\" name=\"slide\" id=\"slide{0}\">";
const String CustomFormattingController::SlideFooter = u"</div>";
```

```cpp
void Run()
{
    String dataDir = GetDataPath();
    
    auto presentation = System::MakeObject<Presentation>(dataDir + u"Individual-Slide.pptx");

    auto formatter = HtmlFormatter::CreateCustomFormatter(MakeObject<CustomFormattingController>();
    auto htmlOptions = System::MakeObject<HtmlOptions>();
    htmlOptions->set_HtmlFormatter(formatter);

    // Enregistrement du fichier
    for (int32_t i = 0; i < presentation->get_Slides()->get_Count(); i++)
    {
        presentation->Save(dataDir + u"Individual Slide" + (i + 1) + u"_out.html", 
            MakeArray<int32_t>({ i + 1 }), SaveFormat::Html, htmlOptions);
    }
}
```


## **Enregistrer le CSS et les images lors de l’exportation en HTML**
En utilisant de nouveaux fichiers de style CSS, vous pouvez facilement modifier le style du fichier HTML résultant du processus de conversion PowerPoint en HTML. 

Le code C++ de cet exemple montre comment utiliser des méthodes surchargeables pour créer un document HTML personnalisé avec un lien vers un fichier CSS :
``` cpp
class CustomHeaderAndFontsController : public EmbedAllFontsHtmlController
{
public:
    CustomHeaderAndFontsController(String cssFileName)
        : m_cssFileName(cssFileName)
    {
    }

    void WriteDocumentStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override
    {
        generator->AddHtml(System::String::Format(Header, m_cssFileName));
        WriteAllFonts(generator, presentation);
    }

    void WriteAllFonts(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override
    {
        generator->AddHtml(u"<!-- Embedded fonts -->");
        EmbedAllFontsHtmlController::WriteAllFonts(generator, presentation);
    }

private:
    static const String Header;
    String m_cssFileName;
};

const String CustomHeaderAndFontsController::Header = String(u"<!DOCTYPE html>\n") + 
u"<html>\n" + u"<head>\n" + 
u"<meta http-equiv=\"Content-Type\" content=\"text/html;charset=UTF-8\">\n" + 
u"<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" + 
u"<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}\">\n" + u"</head>";
```

``` cpp
void Run()
{
    // Le chemin du répertoire des documents.
    System::String dataDir = GetDataPath();

    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    auto htmlController = System::MakeObject<CustomHeaderAndFontsController>(u"styles.css");
    auto options = System::MakeObject<HtmlOptions>();
    options->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(htmlController));
    pres->Save(u"pres.html", SaveFormat::Html, options);
}
```


## **Lier toutes les polices lors de la conversion d’une présentation en HTML**
Si vous ne souhaitez pas incorporer les polices (afin d’éviter d’augmenter la taille du HTML résultant), vous pouvez lier toutes les polices en implémentant votre propre version du `LinkAllFontsHtmlController`. 

Ce code C++ vous montre comment convertir un PowerPoint en HTML tout en liant toutes les polices et en excluant "Calibri" et "Arial" (puisqu’elles existent déjà dans le système) :
```cpp
class LinkAllFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkAllFontsHtmlController(ArrayPtr<String> fontNameExcludeList, String basePath)
        :   EmbedAllFontsHtmlController(fontNameExcludeList)
    {
        m_basePath = basePath;
    }

    void WriteFont(SharedPtr<IHtmlGenerator> generator, SharedPtr<IFontData> originalFont, SharedPtr<IFontData> substitutedFont,
        String fontStyle, String fontWeight, ArrayPtr<uint8_t> fontData)
    {
        String fontName = substitutedFont == nullptr ? originalFont->get_FontName() : substitutedFont->get_FontName();
        String path = String::Format(u"{0}.woff", fontName); // une certaine désinfection du chemin peut être nécessaire
        IO::File::WriteAllBytes(IO::Path::Combine(m_basePath, path), fontData);

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face { ");
        generator->AddHtml(String::Format(u"font-family: '{0}'; ", fontName));
        generator->AddHtml(String::Format(u"src: url('{0}')", path));

        generator->AddHtml(u" }");
        generator->AddHtml(u"</style>");
    }

private:
    String m_basePath;
};
```

``` cpp
void Run()
{
    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    // exclure les polices par défaut de la présentation
    auto fontNameExcludeList = System::MakeArray<String>({ u"Calibri", u"Arial" });
    
    auto linkcont = System::MakeObject<LinkAllFontsHtmlController>(fontNameExcludeList, u"C://Windows//Fonts//");

    System::SharedPtr<HtmlOptions> htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
    htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(linkcont));
    
    pres->Save(u"pres.html", SaveFormat::Html, htmlOptionsEmbed);
}
```


## **Convertir PowerPoint en HTML réactif**
Ce code C++ vous montre comment convertir une présentation PowerPoint en HTML réactif :
```cpp
auto presentation = System::MakeObject<Presentation>(u"SomePresentation.pptx");
auto saveOptions = System::MakeObject<HtmlOptions>();
saveOptions->set_SvgResponsiveLayout(true);
presentation->Save(u"SomePresentation-out.html", SaveFormat::Html, saveOptions);
```



## **Exporter les fichiers multimédias en HTML**
En utilisant Aspose.Slides for C++, vous pouvez exporter des fichiers multimédias de la manière suivante :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).  
2. Obtenir une référence à la diapositive.  
3. Ajouter une vidéo à la diapositive.  
4. Enregistrer la présentation sous forme de fichier HTML.  

Ce code C++ montre comment ajouter une vidéo à la présentation puis l’enregistrer en HTML :
```cpp
 // Charge une présentation
auto pres = System::MakeObject<Presentation>();

const System::String path = u"C:/out/";
const System::String fileName = u"ExportMediaFiles_out.html";
const System::String baseUri = u"http://www.example.com/";

auto fileStream = System::MakeObject<IO::FileStream>(u"my_video.avi", IO::FileMode::Open, IO::FileAccess::Read);

auto video = pres->get_Videos()->AddVideo(fileStream, Aspose::Slides::LoadingStreamBehavior::ReadStreamAndRelease);

auto slide = pres->get_Slides()->idx_get(0);
slide->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(path, fileName, baseUri);

// Définit les options HTML
auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);

htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(svgOptions));

// Enregistre le fichier
pres->Save(IO::Path::Combine(path, fileName), SaveFormat::Html, htmlOptions);
```


## **FAQ**

**Quel est les performances d’Aspose.Slides lors de la conversion de plusieurs présentations en HTML ?**

Les performances dépendent de la taille et de la complexité des présentations. Aspose.Slides est très efficace et évolutif pour les opérations par lots. Pour obtenir des performances optimales lors de la conversion d’un grand nombre de présentations, il est recommandé d’utiliser le multithreading ou le traitement parallèle chaque fois que possible.

**Aspose.Slides prend‑il en charge l’exportation des hyperliens vers HTML ?**

Oui, Aspose.Slides prend pleinement en charge l’exportation des hyperliens incorporés vers HTML. Lors de la conversion des présentations au format HTML, les hyperliens sont conservés automatiquement et restent cliquables.

**Existe‑t‑il une limite au nombre de diapositives lors de la conversion de présentations en HTML ?**

Il n’y a aucune limite au nombre de diapositives avec Aspose.Slides. Vous pouvez convertir des présentations de toute taille. Cependant, pour des présentations contenant un très grand nombre de diapositives, les performances peuvent dépendre des ressources disponibles sur votre serveur ou votre système.