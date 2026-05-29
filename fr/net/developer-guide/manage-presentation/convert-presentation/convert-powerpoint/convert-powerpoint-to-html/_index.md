---
title: Convertir des présentations PowerPoint en HTML avec .NET
linktitle: PowerPoint en HTML
type: docs
weight: 30
url: /fr/net/convert-powerpoint-to-html/
keywords:
- convertir PowerPoint
- convertir la présentation
- convertir la diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en HTML
- présentation en HTML
- diapositive en HTML
- PPT en HTML
- PPTX en HTML
- enregistrer PowerPoint en HTML
- enregistrer la présentation en HTML
- enregistrer la diapositive en HTML
- enregistrer PPT en HTML
- enregistrer PPTX en HTML
- exporter PPT en HTML
- exporter PPTX en HTML
- .NET
- C#
- Aspose.Slides
description: "Convertir des présentations PowerPoint en HTML avec .NET. Utilisez Aspose.Slides pour exporter des fichiers PPT et PPTX, des diapositives sélectionnées, des notes, des polices, des images, du SVG et des médias."
---
## **Vue d'ensemble**

Aspose.Slides for .NET peut enregistrer les présentations PowerPoint au format HTML sans Microsoft PowerPoint. La conversion de base consiste en un seul chargement de [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) et un appel à [Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/) avec [SaveFormat](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveformat/). Utilisez [HtmlOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/htmloptions/) lorsque vous devez contrôler la mise en page exportée, les polices, les images, les notes, les commentaires, la sortie SVG ou les ressources liées.

Ce guide se concentre sur des scénarios pratiques d’exportation HTML :

- Exporter une présentation complète ou des diapositives sélectionnées.
- Générer du HTML à mise en page fixe, réactif ou basé sur SVG.
- Inclure les notes du présentateur et les commentaires.
- Contrôler la qualité des images et les données d’images recadrées.
- Incorporer les polices ou enregistrer les fichiers de police séparément.
- Choisir comment les ressources externes et les fichiers multimédia sont écrits et référencés.

Par défaut, l’exportation HTML produit un document HTML autonome où la plupart des ressources sont incorporées. Cela facilite le partage d’un seul fichier, mais peut augmenter la taille du résultat. Pour la publication Web, envisagez des ressources externes, une résolution d’image plus basse et n’incorporez que les polices qui ne sont pas disponibles de façon fiable dans l’environnement cible.

## **Convertir une présentation en HTML**

Pour exporter une présentation au format HTML, chargez‑la avec [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) et enregistrez‑la avec [SaveFormat.Html](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveformat/).

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

Cet exemple crée un seul fichier HTML. L’objet présentation est libéré par la déclaration `using`, qui ferme les poignées de fichiers et libère les ressources de rendu après l’exportation.

## **Utiliser HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/htmloptions/) est la classe principale de configuration pour l’exportation HTML. Les paramètres courants comprennent :

- `SlidesLayoutOptions` : ajoute des notes, des commentaires, des documents de distribution ou d’autres informations de mise en page.
- `HtmlFormatter` : modifie la structure du document HTML ou délègue le formatage à un contrôleur.
- `SlideImageFormat` : change la façon dont les diapositives sont représentées, par exemple en SVG.
- `PicturesCompression` : contrôle le DPI des images et la taille du résultat.
- `DeletePicturesCroppedAreas` : conserve ou supprime les données d’images recadrées.
- `SvgResponsiveLayout` : fait en sorte que le contenu SVG exporté s’adapte à son conteneur.
- `ShowHiddenSlides` : inclut les diapositives masquées lorsque cela est requis.

Les sections suivantes montrent les options les plus courantes séparément afin que vous puissiez combiner uniquement celles dont votre flux de travail a besoin.

## **Convertir les diapositives sélectionnées en HTML**

La surcharge [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/) qui accepte des numéros de diapositives utilise des positions de diapositives basées sur 1. La boucle ci‑dessous enregistre chaque diapositive dans un fichier HTML distinct.

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

Utilisez ce modèle lorsqu’un site Web ou une application a besoin d’une page HTML par diapositive. Si chaque diapositive doit avoir la même mise en page, créez une instance [HtmlOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/htmloptions/) et transmettez‑la à chaque appel `Save`.

## **Créer du HTML réactif**

[ResponsiveHtmlController](https://reference.aspose.com/slides/fr/net/aspose.slides.export/responsivehtmlcontroller/) fournit une sortie HTML réactive via [HtmlFormatter](https://reference.aspose.com/slides/fr/net/aspose.slides.export/htmlformatter/). Utilisez‑le lorsque la page exportée doit mieux s’adapter à la largeur du navigateur.

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

Pour une mise en page réactive basée sur SVG, définissez `SvgResponsiveLayout` sur [HtmlOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/htmloptions/). Cela est utile lorsque le contenu des diapositives est exporté sous forme de balisage SVG évolutif.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **Inclure les notes du présentateur et les commentaires**

Utilisez [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/notescommentslayoutingoptions/) via `HtmlOptions.SlidesLayoutOptions` pour inclure les notes du présentateur ou les commentaires. Les notes et les commentaires sont masqués par défaut, sauf si vous choisissez leurs positions.

Supposons que la présentation source contienne des notes du présentateur :

![Diapositive avec notes du présentateur dans PowerPoint](slide_with_notes.png)

Le code suivant exporte le contenu de la diapositive avec les notes du présentateur sous la diapositive.

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

Le HTML exporté inclut la zone des notes :

![Sortie HTML avec la diapositive et les notes du présentateur](HTML_with_notes.png)

Pour exporter les commentaires, définissez `CommentsPosition`, par exemple `CommentsPositions.Right` ou `CommentsPositions.Bottom`. Si vous ne voulez que les commentaires, omettez `NotesPosition`. Si vous avez besoin à la fois des notes et des commentaires, définissez les deux propriétés.

## **Contrôler la qualité des images et les zones recadrées**

L’exportation HTML peut compresser les images des diapositives afin de réduire la taille du résultat. Définissez `PicturesCompression` sur une valeur provenant de [PicturesCompression](https://reference.aspose.com/slides/fr/net/aspose.slides.export/picturescompression/) lorsque vous avez besoin d’une meilleure qualité d’image.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

Par défaut, les zones recadrées des images peuvent être supprimées du résultat exporté. Conservez les données recadrées uniquement lorsque les utilisateurs doivent pouvoir récupérer ou inspecter ces parties d’image masquées. Les conserver peut augmenter la taille du HTML.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **Ajouter du CSS**

Pour un style simple, transmettez une chaîne CSS à [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/fr/net/aspose.slides.export/htmlformatter/createdocumentformatter/). Cela modifie le document HTML environnant tandis qu’Aspose.Slides continue de rendre le contenu des diapositives.

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

Pour un en‑tête de document personnalisé, un fichier CSS lié ou un balisage personnalisé autour des diapositives et des formes, implémentez [IHtmlFormattingController](https://reference.aspose.com/slides/fr/net/aspose.slides.export/ihtmlformattingcontroller/) et transmettez‑le à [HtmlFormatter](https://reference.aspose.com/slides/fr/net/aspose.slides.export/htmlformatter/) avec `CreateCustomFormatter`.

## **Incorporer des polices**

Si l’environnement cible ne dispose pas forcément des polices de la présentation, incorporez les polices dans le HTML avec [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fr/net/aspose.slides.export/embedallfontshtmlcontroller/). L’incorporation améliore la fidélité visuelle mais augmente la taille du résultat.

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

Excluez les polices uniquement lorsque vous êtes certain que les navigateurs ou systèmes cibles les fournissent déjà. Pour les polices de marque ou moins courantes, l’incorporation est généralement plus sûre.

## **Lier les fichiers de police au lieu de les incorporer**

Pour réduire la taille du fichier HTML, vous pouvez écrire les données des polices dans des fichiers WOFF séparés et ajouter des règles `@font-face` au HTML. L’assistant ci‑dessous étend [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fr/net/aspose.slides.export/embedallfontshtmlcontroller/) et surcharge `WriteFont`.

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

Dans cet exemple, les fichiers de police sont enregistrés dans `html-output/fonts`, et le HTML les référence avec des URL telles que `fonts/BrandFont-normal-400.woff`. Si le fichier HTML et les polices sont déployés à un autre emplacement, choisissez `fontUrlPrefix` afin qu’il corresponde au chemin d’URL déployé.

## **Enregistrer les ressources en externe**

Le HTML autonome est facile à déplacer, mais les ressources Base64 incorporées peuvent rendre le fichier volumineux. Si votre application a besoin de fichiers d’image externes, implémentez [ILinkEmbedController](https://reference.aspose.com/slides/fr/net/aspose.slides.export/ilinkembedcontroller/) et transmettez‑le au constructeur [HtmlOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/htmloptions/htmloptions/).

Lorsque vous externalisez les ressources, choisissez délibérément deux chemins :

- Le chemin de sortie du système de fichiers, où votre application écrit les images, polices, audio ou vidéo générés.
- Le chemin URL, qui est celui que le navigateur utilise depuis le document HTML pour charger ces fichiers.

Pour une implémentation complète de liaison d’images, consultez [Export Presentations to HTML with Externally Linked Images](/slides/fr/net/exporting-presentations-to-html-with-externally-linked-images/).

## **Exporter les fichiers multimédia**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/fr/net/aspose.slides.export/videoplayerhtmlcontroller/) exporte les fichiers vidéo et audio et génère du HTML capable de les lire dans un navigateur. Son constructeur prend :

- `path` : le répertoire où les fichiers multimédia générés seront écrits.
- `fileName` : le nom du fichier HTML en cours de génération.
- `baseUri` : le préfixe d’URI absolu utilisé dans les liens HTML vers les fichiers multimédia.

Si le fichier HTML est `html-output/presentation.html` et que les fichiers multimédia sont enregistrés dans `html-output/media`, `path` doit pointer vers le répertoire multimédia sur le disque, tandis que `baseUri` doit pointer vers le même répertoire du point de vue du navigateur. Pour un aperçu local, vous pouvez créer une URI `file:///` à partir du répertoire multimédia. Pour une application déployée, utilisez l’URL absolue du répertoire multimédia publié.

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

Utilisez des répertoires de sortie uniques par tâche d’exportation, en particulier dans les applications serveur. Des chemins de sortie partagés peuvent entraîner le remplacement de fichiers provenant de conversions différentes.

## **Performances et gestion des ressources**

La conversion HTML est une opération de rendu, de sorte que le temps de traitement et l’utilisation de la mémoire dépendent du nombre de diapositives, de la résolution des images, des polices, des effets, des graphiques et des médias incorporés. Des valeurs DPI plus élevées pour `PicturesCompression`, les polices incorporées, la sortie SVG et la conservation des zones d’image recadrées peuvent améliorer la fidélité mais augmentent généralement la taille du résultat.

Pour la conversion par lots :

- Libérez chaque instance [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) rapidement.
- Utilisez des répertoires de sortie séparés pour des travaux distincts.
- Évitez d’incorporer les polices courantes, sauf si la fidélité l’exige.
- Réduisez le DPI des images lorsque le HTML est destiné à un aperçu ou à des miniatures.
- Conservez la présentation source, le HTML généré et les ressources externes ensemble jusqu’à ce que les chemins de déploiement soient définitifs.

## **FAQ**

**Les hyperliens sont-ils conservés dans la sortie HTML ?**

Oui. Les hyperliens de la présentation sont exportés vers le HTML et restent cliquables tant que l’URL cible est valide.

**Puis‑je convertir des présentations en HTML en parallèle ?**

Oui, mais ne partagez pas une même instance [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) entre plusieurs threads. Traitez des fichiers différents avec des instances de présentation distinctes, des flux séparés et des répertoires de sortie différents. Consultez les directives de [multithreading](/slides/fr/net/multithreading/).

**L'objet Presentation est‑il thread‑safe ?**

Non. Une instance unique de [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) doit être chargée, modifiée, enregistrée et libérée sur un seul thread. Pour un travail parallèle, créez une instance indépendante par thread ou processus.

**Pourquoi le fichier HTML généré est‑il volumineux ?**

L’exportation par défaut peut incorporer les ressources directement dans le HTML. Les polices incorporées, les images haute résolution, les médias, le contenu SVG et la conservation des zones d’image recadrées augmentent également la taille. Utilisez des ressources externes, excluez les polices communes de l’incorporation et réduisez `PicturesCompression` lorsque la taille réduite prime sur la fidélité maximale.

**Comment choisir le baseUri pour l’exportation des médias ?**

Choisissez `baseUri` du point de vue du navigateur et transmettez‑le sous forme d’URI absolue. Pour un aperçu local, vous pouvez le dériver du répertoire de sortie avec `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri`. En production, utilisez l’URL absolue du répertoire multimédia publié. Le `path` du système de fichiers et le `baseUri` du navigateur n’ont pas besoin d’être identiques, mais ils doivent désigner le même emplacement de ressource.

**Puis‑je inclure les diapositives masquées ?**

Oui. Définissez `ShowHiddenSlides = true` sur [HtmlOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/htmloptions/) lorsque les diapositives masquées doivent être exportées.