---
title: Opérations de présentation Low-Code en .NET
linktitle: API Low-Code
type: docs
weight: 50
url: /fr/net/low-code-presentation-operations/
keywords:
- API de présentation low-code
- convertir une présentation
- fusionner des présentations
- parcourir les diapositives
- parcourir les formes
- parcourir le texte
- collecter les formes
- compresser la présentation
- supprimer les diapositives maître inutilisées
- supprimer les diapositives de mise en page inutilisées
- compresser les polices incorporées
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Utilisez l'API low-code d'Aspose.Slides en .NET pour convertir et fusionner des présentations, parcourir le contenu, collecter des formes et réduire la taille de la présentation."
---
## **Vue d'ensemble**

Le namespace [Aspose.Slides.LowCode](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/) fournit des classes d'aide statiques pour les opérations courantes sur les présentations. Ces aides encapsulent les flux de travail du modèle d'objet fréquemment utilisés dans des méthodes ciblées, vous permettant de convertir ou de fusionner des fichiers, de traiter les éléments de présentation, de collecter des formes et de supprimer le contenu inutilisé avec moins de code.

Les aides low‑code sont les plus utiles lorsque l'opération s'applique à un fichier ou une présentation complète et que le flux de travail par défaut correspond à vos exigences. Utilisez le modèle d'objet complet [Aspose.Slides](https://reference.aspose.com/slides/fr/net/aspose.slides/) lorsque vous avez besoin d'un contrôle fin sur les diapositives individuelles, les maîtres, les mises en page, les formes, les paramètres d'exportation ou les relations entre les éléments de la présentation.

Le tableau suivant résume les aides disponibles :

| Aide | À quoi elle sert |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/convert/) | Conversion d'une présentation vers un autre format avec un appel direct fichier à fichier. |
| [Merger](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/merger/) | Combinaison de fichiers de présentation complets du même format. |
| [ForEach](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/) | Exécution d'une action pour chaque diapositive, forme, paragraphe ou portion de texte. |
| [Collect](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/collect/) | Récupération des formes de l'ensemble de la présentation pour un traitement ou une analyse répétés. |
| [Compress](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/compress/) | Suppression des maîtres et mises en page inutilisés et réduction des données de polices incorporées. |

## **Convertir une présentation**

Utilisez [Convert.AutoByExtension](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/convert/autobyextension/) lorsque l'extension du fichier de sortie suffit à sélectionner le format d'exportation. La méthode ouvre la présentation source, détermine le format requis à partir du chemin de sortie et écrit le résultat.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

La classe [Convert](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/convert/) fournit également des méthodes dédiées pour les sorties PDF, SVG, JPEG, PNG et TIFF. Utilisez le modèle d'objet complet lorsque vous devez inspecter ou modifier la présentation avant l'exportation ou configurer une option d'exportation qui n'est pas exposée par l'aide sélectionnée. Voir [Convert Presentation](/slides/fr/net/convert-presentation/) pour les flux de travail et options spécifiques à chaque format.

## **Fusionner des présentations**

Utilisez [Merger.Process](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/merger/process/) pour combiner des fichiers de présentation complets en un seul appel. Les présentations d'entrée doivent avoir le même format de fichier.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

L'aide est adaptée lorsque toutes les diapositives doivent être ajoutées à un résultat unique sans les sélectionner ou les remapper individuellement. Utilisez le modèle d'objet complet lorsque vous devez fusionner des diapositives sélectionnées, appliquer un master ou une mise en page de destination, conserver explicitement les sections, ou harmoniser des tailles de diapositive différentes. Voir [Merge Presentations](/slides/fr/net/merge-presentation/) pour ces scénarios.

## **Parcourir les éléments de la présentation**

La classe [ForEach](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/) invoque un rappel pour chaque type d'élément de présentation demandé. Elle évite les boucles de collection imbriquées et est pratique pour l'inspection ou les modifications de formatage à l'échelle de la présentation.

L'exemple suivant utilise [ForEach.Slide](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/paragraph/), et [ForEach.Portion](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/portion/) pour inspecter les éléments correspondants :

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

Par défaut, le parcours des formes et du texte à l'échelle de la présentation inclut les diapositives normales, maîtres et de mise en page. Les surcharges avec un paramètre `includeNotes` peuvent également traiter les diapositives de notes. Utilisez des boucles de collection directes lorsque l'ordre de parcours, la sortie anticipée, le filtrage avant l'invocation du rappel ou le contrôle détaillé parent‑enfant est important.

## **Collecter les formes**

Utilisez [Collect.Shapes](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/collect/shapes/) lorsque vous avez besoin d'une collection de toutes les formes d'une présentation plutôt que d'un rappel pour chaque forme. Cela est utile lorsque le même ensemble sera filtré, compté ou traité plusieurs fois.

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

Utilisez plutôt [ForEach.Shape](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/shape/) lorsque chaque forme peut être traitée immédiatement et que vous n'avez pas besoin de conserver le résultat collecté.

## **Compresser le contenu de la présentation**

La classe [Compress](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/compress/) peut supprimer les éléments structurels inutilisés et réduire les données de polices incorporées :

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) Supprime les diapositives de mise en page qui ne sont référencées par aucune diapositive normale.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) Supprime les diapositives maîtres qui ne sont plus utilisées.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/compress/compressembeddedfonts/) Supprime les caractères inutilisés des polices incorporées.

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

Supprimez d'abord les mises en page inutilisées avant les maîtres inutilisés afin qu'un master devenu non référencé après le nettoyage des mises en page puisse également être supprimé. Enregistrez la présentation optimisée dans un nouveau fichier si vous avez besoin ultérieurement des maîtres, mises en page ou des données complètes de polices incorporées d'origine. Pour plus de détails, consultez [Slide Master](/slides/fr/net/slide-master/) et [Embedded Font](/slides/fr/net/embedded-font/).

## **FAQ**

**Quand devrais-je utiliser l'API low-code plutôt que le modèle d'objet complet ?**  
Utilisez les aides low‑code lorsqu'une opération standard s'applique à un fichier ou une présentation complète et ne nécessite pas de contrôle détaillé sur les éléments individuels. Utilisez le modèle d'objet complet lorsque vous devez sélectionner des diapositives spécifiques, contrôler les relations entre maîtres et mises en page, inspecter l'état intermédiaire, ou configurer un comportement que l'aide ne rend pas accessible.

**Le Merger peut‑il combiner des présentations de différents formats de fichier ?**  
Non. [Merger.Process](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/merger/process/) nécessite que les présentations d'entrée soient dans le même format. Convertissez d'abord les fichiers d'entrée dans un format commun, par exemple avec [Convert.AutoByExtension](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/convert/autobyextension/), puis fusionnez les fichiers convertis.

**Le ForEach traite‑t‑il les diapositives master, mise en page et notes ?**  
[ForEach.Slide](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/slide/) parcourt les diapositives de présentation normales. Les opérations à l'échelle de la présentation [ForEach.Shape](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/paragraph/) et [ForEach.Portion](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/portion/) incluent par défaut les diapositives normales, maîtres et de mise en page. Utilisez leurs surcharges avec `includeNotes` réglé sur `true` pour inclure les diapositives de notes.

**Quelle est la différence entre ForEach.Shape et Collect.Shapes ?**  
Utilisez [ForEach.Shape](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/shape/) pour traiter chaque forme immédiatement via un rappel. Utilisez [Collect.Shapes](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/collect/shapes/) lorsque vous avez besoin d'un résultat énumérable qui peut être conservé, filtré, compté ou parcouru plusieurs fois.

**Le Compress réduit‑il toujours la taille du fichier de présentation ?**  
Pas nécessairement. Le résultat dépend du fait que la présentation contienne ou non des mises en page inutilisées, des maîtres inutilisés ou des polices incorporées avec des caractères inutilisés. Si aucun de ces éléments n'est présent, les opérations [Compress](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/compress/) correspondantes peuvent ne pas réduire la taille du fichier.

**Les modifications effectuées par ForEach ou Compress sont‑elles enregistrées automatiquement ?**  
Non. Ces aides opèrent sur l'objet [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) chargé en mémoire. Après avoir modifié des éléments dans un rappel [ForEach](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/) ou exécuté [Compress](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/compress/), appelez [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/) pour écrire le résultat.

## **Articles associés**

- [Convertir une présentation](/slides/fr/net/convert-presentation/)
- [Fusionner des présentations](/slides/fr/net/merge-presentation/)
- [Maître de diapositive](/slides/fr/net/slide-master/)
- [Gérer la zone de texte](/slides/fr/net/manage-textbox/)
- [Police incorporée](/slides/fr/net/embedded-font/)