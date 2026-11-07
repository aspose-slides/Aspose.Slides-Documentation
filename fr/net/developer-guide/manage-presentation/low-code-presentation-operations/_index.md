---
title: Opérations de présentation low-code en .NET
linktitle: API low-code
type: docs
weight: 50
url: /fr/net/low-code-presentation-operations/
keywords:
- API de présentation low-code
- conversion de présentation
- fusion de présentations
- parcourir les diapositives
- parcourir les formes
- parcourir le texte
- collecter les formes
- compresser la présentation
- supprimer les diapositives maîtres inutilisées
- supprimer les diapositives de disposition inutilisées
- compresser les polices intégrées
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Utilisez l'API low-code d'Aspose.Slides en .NET pour convertir et fusionner des présentations, parcourir le contenu, collecter des formes et réduire la taille de la présentation."
---
## **Vue d'ensemble**

Le [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) espace de noms fournit des classes d’assistance statiques pour les opérations courantes sur les présentations. Ces assistants encapsulent les flux de travail fréquemment utilisés du modèle d’objets dans des méthodes ciblées, ce qui vous permet de convertir ou fusionner des fichiers, de traiter les éléments de la présentation, de rassembler des formes et de supprimer le contenu inutilisé avec moins de code.

Les assistants low‑code sont les plus utiles lorsque l’opération s’applique à un fichier ou une présentation entière et que le flux de travail par défaut correspond à vos besoins. Utilisez le modèle d’objet complet [Aspose.Slides](https://reference.aspose.com/slides/net/aspose.slides/) lorsque vous avez besoin d’un contrôle fin sur des diapositives individuelles, des maîtres, des dispositions, des formes, des paramètres d’exportation ou des relations entre les éléments de la présentation.

Le tableau suivant résume les assistants disponibles :

| Assistant | À quoi il sert |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | Convertir une présentation vers un autre format avec un appel direct fichier‑à‑fichier. |
| [Merger](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | Combiner des fichiers de présentation complets du même format. |
| [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | Exécuter une action pour chaque diapositive, forme, paragraphe ou portion de texte. |
| [Collect](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | Récupérer les formes de l’ensemble de la présentation pour un traitement ou une analyse répétés. |
| [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | Supprimer les maîtres/dispositions inutilisés, réduire les données de polices intégrées et compresser les images. |

## **Convertir une présentation**

Utilisez [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/) lorsque l’extension du fichier de sortie suffit à sélectionner le format d’exportation. La méthode ouvre la présentation source, détermine le format requis à partir du chemin de sortie et écrit le résultat.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

La classe [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) propose également des méthodes dédiées pour la sortie PDF, SVG, JPEG, PNG et TIFF. Utilisez le modèle d’objet complet lorsque vous devez inspecter ou modifier la présentation avant l’exportation ou configurer une option d’exportation qui n’est pas exposée par l’assistant sélectionné. Voir [Convert Presentation](/slides/fr/net/convert-presentation/) pour les flux de travail et options spécifiques à chaque format.

## **Fusionner des présentations**

Utilisez [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) pour combiner des fichiers de présentation complets en un seul appel. Les présentations d’entrée doivent avoir le même format de fichier.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

L’assistant est approprié lorsque toutes les diapositives doivent être ajoutées à un résultat unique sans les sélectionner ou les remapper individuellement. Utilisez le modèle d’objet complet lorsque vous devez fusionner des diapositives sélectionnées, appliquer un maître ou une disposition de destination, préserver explicitement les sections, ou harmoniser des tailles de diapositives différentes. Voir [Merge Presentations](/slides/fr/net/merge-presentation/) pour ces scénarios.

## **Parcourir les éléments de la présentation**

La classe [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) invoque un rappel pour chaque type d’élément de présentation demandé. Elle évite les boucles de collections imbriquées et est pratique pour l’inspection ou les modifications de format à l’échelle de la présentation.

L’exemple suivant utilise [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/) et [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) pour inspecter les éléments correspondants :

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

Par défaut, le parcours des formes et du texte à l’échelle de la présentation inclut les diapositives normales, maîtres et dispositions. Les surcharges avec un paramètre `includeNotes` peuvent également traiter les diapositives de notes. Utilisez des boucles de collection directes lorsque l’ordre de parcours, la sortie anticipée, le filtrage avant l’invocation du rappel ou le contrôle détaillé parent‑enfant sont importants.

## **Collecter les formes**

Utilisez [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) lorsque vous avez besoin d’une collection de toutes les formes d’une présentation plutôt que d’un rappel pour chaque forme. Cela est utile lorsque le même ensemble sera filtré, compté ou traité plusieurs fois.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

Utilisez [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) à la place lorsque chaque forme peut être traitée immédiatement et que vous n’avez pas besoin de conserver le résultat collecté.

## **Compresser le contenu de la présentation**

La classe [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) peut supprimer les éléments structurels inutilisés et réduire les données de polices intégrées :

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) supprime les diapositives de disposition qui ne sont référencées par aucune diapositive normale.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) supprime les diapositives maîtres qui ne sont plus utilisées.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) supprime les caractères inutilisés des polices intégrées.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

Supprimez d’abord les dispositions inutilisées, puis les maîtres inutilisés afin qu’un maître devenu non référencé après le nettoyage des dispositions puisse également être supprimé. Enregistrez la présentation optimisée dans un nouveau fichier si vous avez besoin ultérieurement des maîtres, dispositions ou de la totalité des données de polices intégrées. Pour plus de détails, consultez [Slide Master](/slides/fr/net/slide-master/) et [Embedded Font](/slides/fr/net/embedded-font/).

### **Compresser toute la présentation**

Aspose.Slides for .NET 26.11 ajoute [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/). Il combine la suppression des diapositives de disposition/maître inutilisées, le sous‑ensemble des polices intégrées aux caractères utilisés et la compression des images à 150 DPI. Utilisez les opérations individuelles ci‑dessus lorsque vous devez contrôler les modifications appliquées.

Installez [Aspose.Slides for .NET](/slides/fr/net/installation/) 26.11 ou une version ultérieure et fournissez `input.pptx`. Enregistrez dans un fichier séparé : les dispositions supprimées, les caractères de police et les pixels d’image recadrés peuvent être nécessaires pour une modification ultérieure.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **Compresser les images à une résolution choisie**

Utilisez [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) pour traiter les images admissibles sans supprimer également les dispositions ou sous‑ensembles de polices. Cet exemple utilise 96 DPI ; choisissez une autre valeur [PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) pour vos besoins de sortie.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressImages(presentation, PicturesCompression.Dpi96);
presentation.Save("compressed-images.pptx", SaveFormat.Pptx);
```

Les deux assistants utilisent la portée de traitement d’image suivante :

| Contenu | Traitement |
| --- | --- |
| Images matricielles et remplissages d’image de forme sur les diapositives normales, maîtres et dispositions, y compris les formes groupées | Éligibles à la compression. |
| Images déjà à la résolution demandée ou inférieure | Non agrandies. Les zones recadrées peuvent encore être supprimées. |
| Zones d’image recadrées | Les pixels masqués sont supprimés définitivement et les décalages de recadrage sont réinitialisés. |
| Arrière‑plans de diapositive et remplissages de cellules de tableau | Non traités par ces assistants. |
| Internes des graphiques/SmartArt, GIF et formats vectoriels tels que SVG, EMF et WMF | En dehors du périmètre documenté de compression d’image. |

Dans la version 26.11, [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) évite le sous‑échantillonnage basé sur la résolution d’une image non recadrée, mais **ne préserve pas les pixels recadrés**. Une image recadrée peut toujours être réécrite avec ses zones masquées supprimées. Aucun des deux assistants n’expose une option de préservation du recadrage. Pour un contrôle individuel, voir l’[exemple de compression image par image](/slides/fr/net/examples/optimization-batch/compression/).

Comparez l’aspect et la taille du fichier de sortie avant de remplacer l’original. Les économies dépendent des images sources, de leur taille affichée et du contenu inutilisé ; la compression ne garantit pas un fichier plus petit. Consultez [Embedded Fonts](/slides/fr/net/embedded-font/) pour les implications du sous‑ensemble de polices.

## **FAQ**

**Quand dois‑je utiliser l’API low‑code plutôt que le modèle d’objet complet ?**

Utilisez les assistants low‑code lorsqu’une opération standard s’applique à un fichier ou une présentation complète et ne nécessite pas de contrôle détaillé des éléments individuels. Utilisez le modèle d’objet complet lorsque vous devez sélectionner des diapositives spécifiques, contrôler les relations maître/disposition, inspecter l’état intermédiaire ou configurer un comportement que l’assistant n’expose pas.

**Le Merger peut‑il combiner des présentations de formats de fichier différents ?**

Non. [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) exige que les présentations d’entrée soient dans le même format. Convertissez d’abord les fichiers d’entrée vers un format commun, par exemple avec [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/), puis fusionnez les fichiers convertis.

**ForEach traite‑t‑il les diapositives maître, disposition et notes ?**

[ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) parcourt les diapositives de présentation normales. Les opérations [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/) et [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) à l’échelle de la présentation incluent par défaut les diapositives normales, maîtres et dispositions. Utilisez leurs surcharges avec `includeNotes` réglé sur `true` pour inclure les diapositives de notes.

**Quelle est la différence entre ForEach.Shape et Collect.Shapes ?**

Utilisez [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) pour traiter chaque forme immédiatement via un rappel. Utilisez [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) lorsque vous avez besoin d’un résultat énumérable qui peut être conservé, filtré, compté ou traversé plusieurs fois.

**Compress rend‑il toujours le fichier de présentation plus petit ?**

Pas nécessairement. Les économies dépendent des dispositions/maîtres inutilisés, des polices intégrées avec des caractères inutilisés et des images qui bénéficient de la compression. Les assistants [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) peuvent laisser la taille inchangée ou produire un fichier plus lourd pour certains entrées. Comparez la taille et la qualité rendue, et conservez l’original.

**Les modifications effectuées par ForEach ou Compress sont‑elles enregistrées automatiquement ?**

Non. Ces assistants opèrent sur l’objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) chargé en mémoire. Après avoir modifié des éléments dans un rappel [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) ou exécuté [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/), appelez [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) pour écrire le résultat.

## **Articles associés**

- [Convert Presentation](/slides/fr/net/convert-presentation/)
- [Merge Presentations](/slides/fr/net/merge-presentation/)
- [Slide Master](/slides/fr/net/slide-master/)
- [Manage Text Box](/slides/fr/net/manage-textbox/)
- [Embedded Font](/slides/fr/net/embedded-font/)