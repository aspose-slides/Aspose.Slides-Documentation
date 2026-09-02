---
title: Récupérer et mettre à jour les informations de présentation en .NET
linktitle: Informations sur la présentation
type: docs
weight: 30
url: /fr/net/examine-presentation/
keywords:
- format de présentation
- propriétés de présentation
- propriétés du document
- obtenir les propriétés
- lire les propriétés
- changer les propriétés
- modifier les propriétés
- mettre à jour les propriétés
- examiner PPTX
- examiner PPT
- examiner ODP
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Explorez les diapositives, la structure et les métadonnées des présentations PowerPoint et OpenDocument avec .NET pour des analyses plus rapides et des audits de contenu plus intelligents."
---
## **Vue d'ensemble**

Aspose.Slides peut identifier le format d'une présentation et lire ses métadonnées de document sans créer un modèle d'objet de présentation complet. Ceci est utile lorsque vous devez classifier des fichiers, établir un inventaire ou inspecter les propriétés avant de décider de charger et de traiter le contenu de la présentation.

Cet article montre une inspection légère via [PresentationFactory](https://reference.aspose.com/slides/fr/net/aspose.slides/presentationfactory/) et [IPresentationInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/), ainsi que des mises à jour ciblées via [IDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/idocumentproperties/).

## **Vérifier le format d'une présentation**

Utilisez [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/presentationfactory/getpresentationinfo/) pour inspecter un fichier sans créer une instance [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/). La propriété [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/loadformat/) signale le format détecté, tel que PPTX, PPT ou ODP.

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **Construire un inventaire de présentations léger**

Lorsque vous traitez de nombreux fichiers de présentation, il peut être nécessaire de disposer d'un inventaire compact pour la validation, l'indexation ou un système de gestion de documents. Dans ce scénario, utilisez [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/presentationfactory/getpresentationinfo/) pour obtenir un objet [IPresentationInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/), puis appelez [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/readdocumentproperties/) pour lire les métadonnées du document. Cette approche ne crée pas d'instance [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) et ne nécessite pas de parcourir le modèle d'objet complet de la présentation.

Les propriétés étendues exposées par [IDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/idocumentproperties/) fournissent les valeurs d'inventaire suivantes :

| Propriété | Valeur d'inventaire |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/fr/net/aspose.slides/idocumentproperties/slides/fr/) | Nombre total de diapositives. |
| [HiddenSlides](https://reference.aspose.com/slides/fr/net/aspose.slides/idocumentproperties/hiddenslides/) | Nombre de diapositives masquées. |
| [Notes](https://reference.aspose.com/slides/fr/net/aspose.slides/idocumentproperties/notes/) | Nombre de diapositives contenant des notes. |
| [Paragraphs](https://reference.aspose.com/slides/fr/net/aspose.slides/idocumentproperties/paragraphs/) | Nombre total de paragraphes, lorsqu'ils sont disponibles. |
| [Words](https://reference.aspose.com/slides/fr/net/aspose.slides/idocumentproperties/words/) | Nombre total de mots. |
| [MultimediaClips](https://reference.aspose.com/slides/fr/net/aspose.slides/idocumentproperties/multimediaclips/) | Nombre total de clips audio et vidéo. |

L'exemple suivant lit ces valeurs sans créer d'objet [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) et imprime un inventaire compact. Il combine également [HeadingPairs](https://reference.aspose.com/slides/fr/net/aspose.slides/idocumentproperties/headingpairs/) avec [TitlesOfParts](https://reference.aspose.com/slides/fr/net/aspose.slides/idocumentproperties/titlesofparts/) pour afficher des groupes de contenu tels que les polices, les thèmes et les titres de diapositives.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

Chaque [IHeadingPair](https://reference.aspose.com/slides/fr/net/aspose.slides/iheadingpair/) fournit un nom de groupe et le nombre d'éléments dans ce groupe. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/fr/net/aspose.slides/idocumentproperties/titlesofparts/) est un tableau plat et ordonné, il faut donc consommer le nombre de titres consécutifs indiqué par chaque paire d'en-tête.

### **Métadonnées stockées et limitations de format**

Les propriétés d'inventaire renvoyées par [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/readdocumentproperties/) reflètent les métadonnées disponibles dans le document source. Aspose.Slides ne charge pas et ne parcourt pas le modèle d'objet de la présentation pour recalculer ces valeurs lors de cet appel. Les propriétés manquantes sont représentées par des valeurs par défaut, et les valeurs stockées peuvent être obsolètes si l'application qui a enregistré le fichier en dernier n'a pas mis à jour ses propriétés de document.

- **PPTX :** Le format fournit des propriétés de document étendues pour le nombre de diapositives, de notes, de diapositives masquées, de paragraphes, de mots et de multimédias, ainsi que les paires d'en-têtes et les titres de parties. La disponibilité dépend des propriétés écrites par le producteur du document.
- **PPT :** Le format binaire peut stocker les propriétés de résumé de document correspondantes. Si une propriété est absente ou n'a pas été actualisée par le producteur du document, Aspose.Slides renvoie sa valeur stockée ou la valeur par défaut plutôt que de la calculer à partir des diapositives.
- **ODP :** Les métadonnées OpenDocument fournissent des statistiques générales du document, telles que le nombre de pages, de paragraphes et de mots, mais ces valeurs ne correspondent pas à chaque propriété étendue spécifique à PowerPoint. Les métadonnées des diapositives masquées, des notes, des multimédias, des paires d'en-têtes et des titres de parties peuvent être indisponibles, et les propriétés d'inventaire peuvent renvoyer des valeurs par défaut. Ne considérez pas une valeur zéro ou un tableau vide comme une preuve définitive de l'absence du contenu correspondant.

Utilisez l'approche de métadonnées légères pour les inventaires et les vérifications préliminaires. Chargez la présentation et inspectez son modèle d'objet en mémoire lorsque le résultat doit refléter les modifications en mémoire ou lorsque vous devez vérifier le contenu réel de la présentation.

## **Mettre à jour les propriétés de la présentation**

Les propriétés renvoyées par [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/readdocumentproperties/) peuvent également être modifiées sans créer d'instance [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/). Appliquez les changements avec [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/updatedocumentproperties/), puis écrivez la présentation liée avec [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/writebindedpresentation/).

L'image suivante montre les propriétés du document original.

![Propriétés du document original de la présentation PowerPoint](input_properties.png)

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

L'image suivante montre les propriétés du document modifiées.

![Propriétés du document modifiées de la présentation PowerPoint](output_properties.png)

## **Liens utiles**

Pour les contrôles de sécurité associés et les paramètres de protection, voir les articles suivants :

- [Protéger les présentations par mot de passe](/slides/fr/net/password-protected-presentation/)
- [Protéger les présentations en écriture](/slides/fr/net/write-protected-presentation/)

## **FAQ**

**Comment vérifier si les polices sont incorporées et lesquelles ?**

Chargez la présentation et utilisez [Presentation.FontsManager](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/fontsmanager/). Appelez [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsmanager/getembeddedfonts/) pour obtenir les polices incorporées et [FontsManager.GetFonts](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsmanager/getfonts/) pour obtenir les polices utilisées par la présentation. Comparez les deux résultats pour trouver les polices requises pour le rendu mais non incorporées.

**Comment savoir rapidement si le fichier possède des diapositives masquées et combien ?**

Lorsque les métadonnées du document stockées sont suffisantes, lisez [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/fr/net/aspose.slides/idocumentproperties/hiddenslides/) via [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/presentationfactory/getpresentationinfo/) et [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/readdocumentproperties/). Cela convient à un inventaire léger. Si la présentation a été modifiée en mémoire, les métadonnées stockées peuvent être manquantes ou obsolètes, ou vous devez vérifier les valeurs en direct, parcourez alors [Presentation.Slides](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/slides/fr/) et inspectez la propriété [Slide.Hidden](https://reference.aspose.com/slides/fr/net/aspose.slides/slide/hidden/) de chaque diapositive.

**Puis-je détecter si une taille de diapositive personnalisée et son orientation sont utilisées, et si elles diffèrent des valeurs par défaut ?**

Oui. Chargez la présentation et lisez [Presentation.SlideSize](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/slidesize/). Inspectez [ISlideSize.Type](https://reference.aspose.com/slides/fr/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/fr/net/aspose.slides/islidesize/size/) et [ISlideSize.Orientation](https://reference.aspose.com/slides/fr/net/aspose.slides/islidesize/orientation/) pour comparer les paramètres actuels avec le préréglage et les dimensions attendus.

**Existe-t-il un moyen rapide de voir si les graphiques font référence à des sources de données externes ?**

Oui. Localisez chaque [Chart](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/chart/) et inspectez [ChartData.DataSourceType](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/chartdata/datasourcetype/). Pour un classeur externe, lisez [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/chartdata/externalworkbookpath/). Le type de source de données et le chemin indiquent une référence externe, mais vérifier la disponibilité de la cible nécessite une vérification de ressource distincte.

**Comment évaluer les diapositives « lourdes » qui peuvent ralentir le rendu ou l'export PDF ?**

Il n'existe pas de propriété unique de complexité. Parcourez [Presentation.Slides](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/slides/fr/) et la collection [IBaseSlide.Shapes](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseslide/shapes/) de chaque diapositive. Utilisez le nombre de formes et la présence d'images volumineuses, d'effets, d'animations ou de multimédias comme indicateurs de filtrage, et mesurez un rendu ou une exportation représentatif avant de considérer une diapositive comme un goulet d'étranglement de performance confirmé.