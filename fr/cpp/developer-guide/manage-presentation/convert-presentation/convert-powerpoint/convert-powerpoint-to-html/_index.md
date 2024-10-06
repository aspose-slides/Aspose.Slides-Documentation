---
title: Convertir PowerPoint en HTML en C++
linktitle: Convertir PowerPoint en HTML
type: docs
weight: 30
url: /cpp/convert-powerpoint-to-html/
keywords: "C++ PowerPoint en HTML, Convertir présentation PowerPoint, PPTX, PPT, PPT en HTML, PPTX en HTML, PowerPoint en HTML, Enregistrer PowerPoint en tant qu'HTML, Enregistrer PPT en tant qu'HTML, Enregistrer PPTX en tant qu'HTML, C++, CPP, Aspose.Slides, exportation HTML"
description: "Convertir PowerPoint en HTML en C++. Enregistrer PPTX ou PPT sous forme d'HTML en C++. Enregistrer les diapositives en tant qu'HTML en C++"
---

## **Aperçu**

Cet article explique comment convertir une présentation PowerPoint au format HTML en utilisant C++. Il couvre les sujets suivants.

- [Convertir PowerPoint en HTML en C++](#convertir-powerpoint-en-html)
- [Convertir PPT en HTML en C++](#convertir-powerpoint-en-html)
- [Convertir PPTX en HTML en C++](#convertir-powerpoint-en-html)
- [Convertir ODP en HTML en C++](#convertir-powerpoint-en-html)
- [Convertir diapositive PowerPoint en HTML en C++](#convertir-diapositive-en-html)

## **C++ PowerPoint en HTML**

Pour un exemple de code C++ pour convertir PowerPoint en HTML, veuillez consulter la section ci-dessous, c'est-à-dire [Convertir PowerPoint en HTML](#convertir-powerpoint-en-html). Le code peut charger plusieurs formats comme PPT, PPTX et ODP dans l'objet Presentation et le sauvegarder au format HTML.

## **À propos de la conversion PowerPoint en HTML**
En utilisant [**Aspose.Slides pour C++**](https://products.aspose.com/slides/cpp/), les applications et les développeurs peuvent convertir une présentation PowerPoint en HTML : **PPTX en HTML** ou **PPT en HTML**. 

**Aspose.Slides** propose de nombreuses options (principalement de la classe [**HtmlOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options)) qui définissent le processus de conversion de PowerPoint en HTML :

* Convertir toute une présentation PowerPoint en HTML.
* Convertir une diapositive spécifique d’une présentation PowerPoint en HTML.
* Convertir le média de présentation (images, vidéos, etc.) en HTML.
* Convertir une présentation PowerPoint en HTML réactif. 
* Convertir une présentation PowerPoint en HTML avec les notes du présentateur incluses ou exclues. 
* Convertir une présentation PowerPoint en HTML avec les commentaires inclus ou exclus. 
* Convertir une présentation PowerPoint en HTML avec des polices originales ou intégrées. 
* Convertir une présentation PowerPoint en HTML tout en utilisant le nouveau style CSS. 

{{% alert color="primary" %}} 

En utilisant sa propre API, Aspose a développé des convertisseurs gratuits [présentation en HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) : [PPT en HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX en HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP en HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Vous voudrez peut-être consulter d'autres [convertisseurs gratuits d'Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

En plus des processus de conversion décrits ici, Aspose.Slides prend également en charge ces opérations de conversion impliquant le format HTML : 

* [HTML vers image](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML vers JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML vers XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML vers TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}


## **Convertir PowerPoint en HTML**
En utilisant Aspose.Slides, vous pouvez convertir une présentation PowerPoint entière en HTML de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
   * Chargez **.ppt** dans la classe _Presentation_ pour **Convertir PPT en HTML en C++**
   * Chargez **.pptx** dans la classe _Presentation_ pour **Convertir PPTX en HTML en C++**
   * Chargez **.odp** dans la classe _Presentation_ pour **Convertir ODP en HTML en C++**
3. Utilisez la méthode [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) pour enregistrer l'objet sous forme de fichier HTML.

Ce code vous montre comment convertir un PowerPoint en HTML en C++ :

```cpp
// Instancier un objet Presentation qui représente un fichier de présentation
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");
    
auto htmlOpt = System::MakeObject<HtmlOptions>();
htmlOpt->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(u"", false));

// Sauvegarder la présentation en HTML
presentation->Save(u"ConvertWholePresentationToHTML_out.html", SaveFormat::Html, htmlOpt);
```

## **Convertir PowerPoint en HTML réactif**
Aspose.Slides propose la classe [ResponsiveHtmlController ](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.responsive_html_controller) qui vous permet de générer des fichiers HTML réactifs. Ce code vous montre comment convertir une présentation PowerPoint en HTML réactif en C++ :

```cpp
// Instancier un objet Presentation qui représente un fichier de présentation
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));

// Sauvegarder la présentation en HTML
presentation->Save(u"ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, htmlOptions);
```

## **Convertir PowerPoint en HTML avec notes**
Ce code vous montre comment convertir un PowerPoint en HTML avec des notes en C++ :

```cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

auto opt = System::MakeObject<HtmlOptions>();

auto options = opt->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// Sauvegarder les pages de notes
pres->Save(u"Output.html", SaveFormat::Html, opt);
```

## **Convertir PowerPoint en HTML avec des polices originales**
Aspose.Slides propose la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) qui vous permet d'incorporer toutes les polices dans une présentation lors de la conversion de la présentation en HTML.

Pour empêcher certaines polices d'être intégrées, vous pouvez passer un tableau de noms de polices à un constructeur paramétré de la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller). Les polices populaires, telles que Calibri ou Arial, lorsqu'elles sont utilisées dans une présentation, n'ont pas besoin d'être intégrées car la plupart des systèmes contiennent déjà ces polices. Lorsque ces polices sont intégrées, le document HTML résultant devient inutilement volumineux.

La classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) prend en charge l'héritage et fournit la méthode [WriteFont](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller#a1dfd1c26bb181c8581ec67d270ce0b77), qui est destinée à être écrasée. 

```cpp
auto pres = System::MakeObject<Presentation>(u"input.pptx");

// exclure les polices par défaut de la présentation
auto fontNameExcludeList = System::MakeArray<System::String>({ u"Calibri", u"Arial" });

auto embedFontsController = System::MakeObject<EmbedAllFontsHtmlController>(fontNameExcludeList);

auto htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(embedFontsController));

pres->Save(u"input-PFDinDisplayPro-Regular-installed.html", SaveFormat::Html, htmlOptionsEmbed);
```

## **Convertir PowerPoint en HTML avec des images de haute qualité**
Par défaut, lorsque vous convertissez PowerPoint en HTML, Aspose.Slides génère un petit HTML avec des images à 72 DPI et supprime les zones recadrées. Pour obtenir des fichiers HTML avec des images de qualité supérieure, vous devez définir la propriété `PicturesCompression` (de la classe `HtmlOptions`) à 96 (c'est-à-dire `PicturesCompression::Dpi96`) ou des [valeurs](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.export#adc51ca67b7e5c99f6fad75b02ebfd6d8) supérieures.

Ce code C++ vous montre comment convertir une présentation PowerPoint en HTML tout en obtenant des images de haute qualité à 150 DPI (c'est-à-dire `PicturesCompression::Dpi150`) :

```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_PicturesCompression(PicturesCompression::Dpi150);

pres->Save(u"OutputDoc-dpi150.html", SaveFormat::Html, htmlOpts);
```

Ce code en C++ vous montre comment générer un HTML avec des images de pleine qualité :

```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_DeletePicturesCroppedAreas(false);

pres->Save(u"Outputdoc-noCrop.html", SaveFormat::Html, htmlOpts);
```

## **Convertir une diapositive en HTML**
Pour convertir une diapositive spécifique d'un PowerPoint en HTML, vous devez instancier la même classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) (utilisée pour convertir des présentations entières en HTML) et ensuite utiliser la méthode [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) pour enregistrer le fichier en tant qu'HTML. La classe [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) peut être utilisée pour spécifier des options de conversion supplémentaires :

Ce code C++ vous montre comment convertir une diapositive d'une présentation PowerPoint en HTML :

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

``` cpp
void Run()
{
    String dataDir = GetDataPath();
    
    auto presentation = System::MakeObject<Presentation>(dataDir + u"Individual-Slide.pptx");

    auto formatter = HtmlFormatter::CreateCustomFormatter(MakeObject<CustomFormattingController>());
    auto htmlOptions = System::MakeObject<HtmlOptions>();
    htmlOptions->set_HtmlFormatter(formatter);

    // Sauvegarder le fichier              
    for (int32_t i = 0; i < presentation->get_Slides()->get_Count(); i++)
    {
        presentation->Save(dataDir + u"Individual Slide" + (i + 1) + u"_out.html", 
            MakeArray<int32_t>({ i + 1 }), SaveFormat::Html, htmlOptions);
    }
}
```

## **Enregistrer CSS et images lors de l'exportation en HTML**
En utilisant de nouveaux fichiers de style CSS, vous pouvez facilement changer le style du fichier HTML résultant du processus de conversion de PowerPoint en HTML. 

Le code C++ dans cet exemple vous montre comment utiliser des méthodes surchargées pour créer un document HTML personnalisé avec un lien vers un fichier CSS :

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
        generator->AddHtml(u"<!-- Polices embarquées -->");
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
    // Le chemin vers le répertoire des documents.
    System::String dataDir = GetDataPath();

    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    auto htmlController = System::MakeObject<CustomHeaderAndFontsController>(u"styles.css");
    auto options = System::MakeObject<HtmlOptions>();
    options->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(htmlController));
    pres->Save(u"pres.html", SaveFormat::Html, options);
}
```

## **Lier toutes les polices lors de la conversion de la présentation en HTML**
Si vous ne souhaitez pas incorporer les polices (pour éviter d'augmenter la taille du HTML résultant), vous pouvez lier toutes les polices en implémentant votre propre version de `LinkAllFontsHtmlController`. 

Ce code C++ vous montre comment convertir un PowerPoint en HTML tout en liant toutes les polices et en excluant "Calibri" et "Arial" (puisqu'elles existent déjà dans le système) : 

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
        String path = String::Format(u"{0}.woff", fontName); // une certaine sanitation de chemin peut être nécessaire
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


## **Exporter des fichiers multimédias en HTML**
En utilisant Aspose.Slides pour C++, vous pouvez exporter des fichiers multimédias de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenez une référence à la diapositive.
1. Ajoutez une vidéo à la diapositive.
1. Écrivez la présentation sous forme de fichier HTML.

Ce code C++ vous montre comment ajouter une vidéo à la présentation et ensuite la sauvegarder sous forme de HTML : 

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