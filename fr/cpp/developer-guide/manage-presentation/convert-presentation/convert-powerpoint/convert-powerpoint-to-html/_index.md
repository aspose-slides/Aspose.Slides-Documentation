---
title: Convertir des présentations PowerPoint en HTML en C++
linktitle: PowerPoint en HTML
type: docs
weight: 30
url: /fr/cpp/convert-powerpoint-to-html/
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
- enregistrer la présentation en HTML
- enregistrer la diapositive en HTML
- enregistrer PPT en HTML
- enregistrer PPTX en HTML
- exporter PPT en HTML
- exporter PPTX en HTML
- C++
- Aspose.Slides
description: "Convertir des présentations PowerPoint en HTML en C++. Utilisez Aspose.Slides pour exporter des fichiers PPT et PPTX, des diapositives sélectionnées, des notes, des polices, des images, SVG et des médias."
---
## **Vue d'ensemble**

Aspose.Slides for C++ peut enregistrer des présentations PowerPoint au format HTML sans Microsoft PowerPoint. La conversion de base consiste en un seul chargement de [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) et un appel `Save` avec [SaveFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/saveformat/). Utilisez [HtmlOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/htmloptions/) lorsque vous devez contrôler la mise en page exportée, les polices, les images, les notes, les commentaires, la sortie SVG ou les ressources liées.

Ce guide se concentre sur des scénarios pratiques d'exportation HTML :

- Exporter une présentation complète ou des diapositives sélectionnées.
- Générer du HTML à mise en page fixe, réactif ou basé sur SVG.
- Inclure les notes du présentateur et les commentaires.
- Contrôler la qualité des images et les données d'image recadrées.
- Intégrer les polices ou enregistrer les fichiers de polices séparément.
- Choisir comment les ressources externes et les fichiers multimédias sont écrits et référencés.

Par défaut, l'exportation HTML produit un document HTML autonome où la plupart des ressources sont intégrées. Cela est pratique pour partager un seul fichier, mais cela peut augmenter la taille du résultat. Pour la publication web, envisagez d'utiliser des ressources externes, de réduire le DPI des images et d'intégrer uniquement les polices qui ne sont pas fiables dans l'environnement cible.

## **Convertir une présentation en HTML**

Pour exporter une présentation au format HTML, chargez‑la avec [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) et enregistrez‑la avec `SaveFormat::Html`.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

Cet exemple écrit un fichier HTML. L'appel à `Dispose` libère les poignées de fichiers et les ressources de rendu après l'exportation.

## **Utiliser HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/htmloptions/) est la classe de configuration principale pour l'exportation HTML. Les paramètres courants comprennent :

- `SlidesLayoutOptions` : ajoute des notes, des commentaires, des supports de cours ou d'autres informations de mise en page.
- `HtmlFormatter` : modifie la structure du document HTML ou délègue le formatage à un contrôleur.
- `SlideImageFormat` : change la façon dont les diapositives sont représentées, par exemple en SVG.
- `PicturesCompression` : contrôle le DPI des images et la taille du résultat.
- `DeletePicturesCroppedAreas` : conserve ou supprime les données d'images recadrées.
- `SvgResponsiveLayout` : rend le contenu SVG exporté adaptable à son conteneur.
- `ShowHiddenSlides` : inclut les diapositives masquées lorsque cela est requis.

Les sections suivantes affichent séparément les options les plus courantes afin que vous puissiez combiner uniquement celles dont votre flux de travail a besoin.

## **Convertir des diapositives sélectionnées en HTML**

La surcharge `Presentation::Save` qui accepte les numéros de diapositives utilise des positions de diapositives indexées à partir de 1. La boucle ci‑dessous enregistre chaque diapositive dans un fichier HTML distinct.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slideNumber = slideIndex + 1;
    auto slideNumbers = System::MakeArray<int>({ slideNumber });
    auto htmlFileName = System::String::Format(u"slide-{0}.html", slideNumber);

    presentation->Save(htmlFileName, slideNumbers, SaveFormat::Html);
}

presentation->Dispose();
```

Utilisez ce modèle lorsqu'un site Web ou une application a besoin d'une page HTML par diapositive. Si chaque diapositive doit avoir la même mise en page, créez une instance de [HtmlOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/htmloptions/) et transmettez‑la à chaque appel `Save`.

## **Créer du HTML réactif**

[ResponsiveHtmlController](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/responsivehtmlcontroller/) fournit une sortie HTML réactive via [HtmlFormatter](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/htmlformatter/). Utilisez‑le lorsque la page exportée doit mieux s'adapter à la largeur du navigateur.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Pour une mise en page réactive basée sur SVG, définissez `SvgResponsiveLayout` sur [HtmlOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/htmloptions/). Cela est utile lorsque le contenu des diapositives est exporté sous forme de balisage SVG évolutif.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Inclure les notes du présentateur et les commentaires**

Utilisez [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/notescommentslayoutingoptions/) via `HtmlOptions.SlidesLayoutOptions` pour inclure les notes du présentateur ou les commentaires. Les notes et les commentaires sont masqués par défaut, sauf si vous choisissez leurs positions.

Supposons que la présentation source contienne des notes du présentateur :

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Le code suivant exporte le contenu de la diapositive avec les notes du présentateur sous la diapositive.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Le HTML exporté inclut la zone des notes :

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Pour exporter les commentaires, définissez `CommentsPosition`, par exemple à `CommentsPositions::Right` ou `CommentsPositions::Bottom`. Si vous avez besoin uniquement des commentaires, omettez `NotesPosition`. Si vous avez besoin à la fois des notes et des commentaires, définissez les deux propriétés.

## **Contrôler la qualité des images et les zones recadrées**

L'exportation HTML peut compresser les images des diapositives pour réduire la taille du résultat. Définissez `PicturesCompression` sur une valeur provenant de [PicturesCompression](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/picturescompression/) lorsque vous avez besoin d'une meilleure qualité d'image.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Par défaut, les zones recadrées des images peuvent être supprimées du résultat exporté. Conservez les données recadrées uniquement lorsque les utilisateurs doivent pouvoir récupérer ou inspecter ces parties d'image masquées. Les conserver peut augmenter la taille du HTML.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Ajouter du CSS**

Pour un style simple, transmettez une chaîne CSS à `HtmlFormatter::CreateDocumentFormatter`. Cela modifie le document HTML entourant tout en permettant à Aspose.Slides de continuer à rendre le contenu des diapositives.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Pour un en‑tête de document personnalisé, un fichier CSS lié ou un balisage personnalisé autour des diapositives et des formes, implémentez [IHtmlFormattingController](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/ihtmlformattingcontroller/) et transmettez‑le à [HtmlFormatter](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/htmlformatter/) avec `CreateCustomFormatter`.

## **Intégrer des polices**

Si l'environnement cible n'a pas les polices de la présentation installées, intégrez les polices dans le HTML avec [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/embedallfontshtmlcontroller/). L'intégration améliore la fidélité visuelle mais augmente la taille du résultat.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontNamesToExclude = System::MakeArray<System::String>({ u"Arial" });
auto fontController = System::MakeObject<EmbedAllFontsHtmlController>(fontNamesToExclude);
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-embedded-fonts.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Excluez les polices uniquement lorsque vous êtes certain que les navigateurs ou systèmes cibles les fournissent déjà. Pour les polices de marque ou les polices moins courantes, l'intégration est généralement plus sûre.

## **Lier les fichiers de polices au lieu de les intégrer**

Pour réduire la taille du fichier HTML, vous pouvez écrire les données de police dans des fichiers WOFF séparés et ajouter des règles `@font-face` au HTML. L'assistant ci‑dessous étend [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/embedallfontshtmlcontroller/) et surcharge `WriteFont`.

```cpp
class LinkedFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkedFontsHtmlController(
        System::String fontOutputDirectory,
        System::String fontUrlPrefix)
        : EmbedAllFontsHtmlController(System::MakeArray<System::String>(0)),
          m_fontOutputDirectory(fontOutputDirectory),
          m_fontUrlPrefix(fontUrlPrefix.TrimEnd(u'/') + u"/")
    {
        System::IO::Directory::CreateDirectory_(m_fontOutputDirectory);
    }

    void WriteFont(
        System::SharedPtr<IHtmlGenerator> generator,
        System::SharedPtr<IFontData> originalFont,
        System::SharedPtr<IFontData> substitutedFont,
        System::String fontStyle,
        System::String fontWeight,
        System::ArrayPtr<uint8_t> fontData) override
    {
        auto font = substitutedFont == nullptr ? originalFont : substitutedFont;
        auto safeFontName = MakeSafeFileName(font->get_FontName());
        auto safeFontStyle = System::String::IsNullOrWhiteSpace(fontStyle) ? u"normal" : fontStyle;
        auto safeFontWeight = System::String::IsNullOrWhiteSpace(fontWeight) ? u"normal" : fontWeight;
        auto fontFileName = System::String::Format(u"{0}-{1}-{2}.woff", safeFontName, safeFontStyle, safeFontWeight);
        auto fontFilePath = System::IO::Path::Combine(m_fontOutputDirectory, fontFileName);

        System::IO::File::WriteAllBytes(fontFilePath, fontData);

        auto fontUrl = m_fontUrlPrefix + System::Uri::EscapeDataString(fontFileName);
        auto fontFamily = font->get_FontName().Replace(u"\\", u"\\\\").Replace(u"'", u"\\'");

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face {");
        generator->AddHtml(System::String::Format(u"font-family: '{0}';", fontFamily));
        generator->AddHtml(System::String::Format(u"font-style: {0};", safeFontStyle));
        generator->AddHtml(System::String::Format(u"font-weight: {0};", safeFontWeight));
        generator->AddHtml(System::String::Format(u"src: url('{0}') format('woff');", fontUrl));
        generator->AddHtml(u"}");
        generator->AddHtml(u"</style>");
    }

private:
    System::String m_fontOutputDirectory;
    System::String m_fontUrlPrefix;

    System::String MakeSafeFileName(System::String fileName)
    {
        auto invalidCharacters = System::IO::Path::GetInvalidFileNameChars();
        auto safeCharacters = fileName.ToCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters->get_Length(); characterIndex++)
        {
            if (System::Array<int16_t>::IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = u'_';
            }
        }

        return System::String(safeCharacters);
    }
};

auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto fontsDirectory = System::IO::Path::Combine(outputDirectory, u"fonts");
System::IO::Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontController = System::MakeObject<LinkedFontsHtmlController>(fontsDirectory, u"fonts");
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Dans cet exemple, les fichiers de polices sont enregistrés dans `html-output/fonts`, et le HTML les référence avec des URL comme `fonts/BrandFont-normal-400.woff`. Si le fichier HTML et les polices sont déployés à un autre emplacement, choisissez `fontUrlPrefix` de façon à ce qu'il corresponde au chemin d'URL déployé.

## **Enregistrer les ressources de manière externe**

Le HTML autonome est facile à déplacer, mais les ressources Base64 intégrées peuvent rendre le fichier volumineux. Si votre application a besoin de fichiers image externes, implémentez [ILinkEmbedController](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/ilinkembedcontroller/) et transmettez‑le au constructeur de [HtmlOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/htmloptions/).

Lorsque vous externalisez les ressources, choisissez deux chemins délibérément :

- Le chemin de sortie du système de fichiers, où votre application écrit les images, polices, audio ou vidéo générés.
- Le chemin URL, qui est celui que le navigateur utilise depuis le document HTML pour charger ces fichiers.

## **Exporter les fichiers multimédias**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/videoplayerhtmlcontroller/) exporte les fichiers vidéo et audio et écrit du HTML qui peut les lire dans un navigateur. Son constructeur prend :

- `path` : le répertoire où les fichiers multimédias générés seront écrits.
- `fileName` : le nom du fichier HTML en cours de génération.
- `baseUri` : le préfixe d'URI absolu utilisé dans les liens HTML vers les fichiers multimédias.

Si le fichier HTML est `html-output/presentation.html` et les fichiers multimédias sont enregistrés dans `html-output/media`, `path` doit pointer vers le répertoire multimédia sur le disque, tandis que `baseUri` doit pointer vers le même répertoire du point de vue du navigateur. Pour un aperçu local, vous pouvez créer une URI `file:///` à partir du répertoire multimédia. Pour une application déployée, utilisez l'URL absolue du répertoire multimédia publié.

```cpp
auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto mediaDirectory = System::IO::Path::Combine(outputDirectory, u"media");
System::IO::Directory::CreateDirectory_(outputDirectory);
System::IO::Directory::CreateDirectory_(mediaDirectory);

auto htmlFileName = u"presentation.html";
auto mediaBaseUri = System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri();

auto presentation = System::MakeObject<Presentation>();
auto videoStream = System::MakeObject<System::IO::FileStream>(u"intro.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);

auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddVideoFrame(20.0f, 20.0f, 480.0f, 270.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(mediaDirectory, htmlFileName, mediaBaseUri);
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(formatter);
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, htmlFileName);
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

videoStream->Dispose();
presentation->Dispose();
```

Utilisez des répertoires de sortie uniques par travail d'exportation, surtout dans les applications serveur. Des chemins de sortie partagés peuvent entraîner l'écrasement de fichiers provenant de conversions différentes.

## **Performance et gestion des ressources**

La conversion HTML est une opération de rendu, de sorte que le temps de traitement et l'utilisation de la mémoire dépendent du nombre de diapositives, de la résolution des images, des polices, des effets, des graphiques et des médias intégrés. Des valeurs DPI plus élevées pour `PicturesCompression`, les polices intégrées, la sortie SVG et la conservation des zones d'images recadrées peuvent améliorer la fidélité mais augmentent généralement la taille du résultat.

Pour la conversion par lots :

- Libérez chaque instance de [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) rapidement.
- Utilisez des répertoires de sortie distincts pour chaque tâche.
- Évitez d'intégrer les polices communes sauf si la fidélité l'exige.
- Réduisez le DPI des images lorsque le HTML est destiné à la prévisualisation ou aux vignettes.
- Conservez la présentation source, le HTML généré et les ressources externes ensemble jusqu'à ce que les chemins de déploiement soient définitifs.

## **FAQ**

**Les hyperliens sont-ils conservés dans la sortie HTML ?**

Oui. Les hyperliens de la présentation sont exportés vers le HTML et restent cliquables lorsque l'URL cible est valide.

**Puis‑je convertir plusieurs présentations en HTML en parallèle ?**

Oui, mais ne partagez pas une même instance de [Presentation] entre plusieurs threads. Traitez différents fichiers avec des instances de présentation distinctes, des flux séparés et des répertoires de sortie séparés. Consultez les [instructions sur le multithreading](/slides/fr/cpp/multithreading/) pour plus de détails.

**L'objet Presentation est‑il thread‑safe ?**

Non. Une seule instance de [Presentation] doit être chargée, modifiée, enregistrée et libérée sur un même thread. Pour un travail parallèle, créez une instance indépendante par thread ou processus.

**Pourquoi le fichier HTML généré est‑il volumineux ?**

L'exportation par défaut peut intégrer les ressources directement dans le HTML. L'intégration des polices, des images à haute résolution, des médias, du contenu SVG et la conservation des zones d'images recadrées augmentent également la taille. Utilisez des ressources externes, excluez les polices courantes de l'intégration et réduisez `PicturesCompression` lorsque la taille réduite est plus importante que la fidélité maximale.

**Comment devrais‑je choisir baseUri pour l'exportation des médias ?**

Choisissez `baseUri` du point de vue du navigateur et transmettez‑le comme URI absolue. Pour un aperçu local, vous pouvez le dériver du répertoire de sortie avec `System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()`. Pour le déploiement, utilisez l'URL absolue du répertoire multimédia publié. Le `path` du système de fichiers et le `baseUri` du navigateur n'ont pas besoin d'être identiques, mais ils doivent décrire le même emplacement de ressource.

**Puis‑je inclure les diapositives masquées ?**

Oui. Définissez `ShowHiddenSlides` à `true` sur [HtmlOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/htmloptions/) lorsque les diapositives masquées doivent être exportées.