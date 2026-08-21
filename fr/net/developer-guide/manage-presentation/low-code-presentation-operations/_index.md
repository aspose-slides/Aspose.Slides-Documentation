---
title: Opérations de présentation low-code en .NET
linktitle: API low-code
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
- collecter des formes
- compresser la présentation
- supprimer les diapositives maîtres inutilisées
- supprimer les diapositives de mise en page inutilisées
- compresser les polices incorporées
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Utilisez l'API low-code Aspose.Slides en .NET pour convertir et fusionner des présentations, parcourir le contenu, collecter des formes et réduire la taille de la présentation."
---
## **Vue d'ensemble**

L'espace de noms [Aspose.Slides.LowCode](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/) fournit des classes d'assistance statiques pour les opérations courantes sur les présentations. Ces assistants encapsulent les flux de travail du modèle d'objet fréquemment utilisés dans des méthodes ciblées, vous permettant de convertir ou de fusionner des fichiers, de traiter les éléments de la présentation, de collecter des formes et de supprimer le contenu inutilisé avec moins de code.

Les assistants low-code sont les plus utiles lorsque l'opération s'applique à un fichier ou une présentation entière et que le flux de travail par défaut correspond à vos besoins. Utilisez le [modèle d'objet complet Aspose.Slides](https://reference.aspose.com/slides/fr/net/aspose.slides/) lorsque vous avez besoin d'un contrôle granulaire sur les diapositives individuelles, les maîtres, les dispositions, les formes, les paramètres d'exportation ou les relations entre les éléments de la présentation.

Le tableau suivant résume les assistants disponibles :

| Assistant | Utilisation |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/convert/) | Conversion d'une présentation vers un autre format avec un appel direct fichier‑à‑fichier. |
| [Merger](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/merger/) | Combinaison de fichiers de présentation complets du même format. |
| [ForEach](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/) | Exécution d'une action pour chaque diapositive, forme, paragraphe ou portion de texte. |
| [Collect](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/collect/) | Récupération des formes de l'ensemble de la présentation pour un traitement ou une analyse répétés. |
| [Compress](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/compress/) | Suppression des maîtres et dispositions inutilisés et réduction des données de polices incorporées. |

## **Convertir une présentation**

Utilisez [Convert.AutoByExtension](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/convert/autobyextension/) lorsque l'extension du fichier de sortie suffit à sélectionner le format d'exportation. La méthode ouvre la présentation source, détermine le format requis à partir du chemin de sortie et écrit le résultat.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

La classe [Convert](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/convert/) propose également des méthodes dédiées pour la sortie PDF, SVG, JPEG, PNG et TIFF. Utilisez le modèle d'objet complet lorsque vous devez inspecter ou modifier la présentation avant l'exportation ou configurer une option d'exportation qui n'est pas exposée par l'assistant sélectionné. Consultez [Convert Presentation](/net/convert-presentation/) pour les flux de travail et les options spécifiques à chaque format.

## **Fusionner des présentations**

Utilisez [Merger.Process](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/merger/process/) pour combiner des fichiers de présentation complets en un seul appel. Les présentations d'entrée doivent avoir le même format de fichier.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Cet assistant convient lorsque toutes les diapositives doivent être ajoutées à un résultat unique sans les sélectionner ou les remapper individuellement. Utilisez le modèle d'objet complet lorsque vous devez fusionner des diapositives sélectionnées, appliquer un maître ou une disposition de destination, préserver explicitement les sections ou concilier des tailles de diapositives différentes. Consultez [Merge Presentations](/net/merge-presentation/) pour ces scénarios.

## **Parcourir les éléments de la présentation**

La classe [ForEach](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/) invoque une fonction de rappel pour chaque type d'élément de présentation demandé. Elle évite les boucles de collection imbriquées et est pratique pour l'inspection ou les modifications de formatage à l'échelle de la présentation.

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

Par défaut, le parcours des formes et du texte à l'échelle de la présentation inclut les diapositives normales, maîtres et de mise en page. Les surcharges avec un paramètre `includeNotes` peuvent également traiter les diapositives de notes. Utilisez des boucles de collection directes lorsque l'ordre de parcours, la sortie anticipée, le filtrage avant l'appel du rappel ou le contrôle détaillé parent‑enfant sont importants.

## **Collecter des formes**

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

Utilisez [ForEach.Shape](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/shape/) à la place lorsque chaque forme peut être traitée immédiatement et que vous n'avez pas besoin de conserver le résultat collecté.

## **Compresser le contenu de la présentation**

La classe [Compress](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/compress/) peut supprimer les éléments structurels inutilisés et réduire les données de polices incorporées :

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) supprime les diapositives de mise en page qui ne sont référencées par aucune diapositive normale.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) supprime les diapositives maîtres qui ne sont plus utilisées.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/compress/compressembeddedfonts/) supprime les caractères inutilisés des polices incorporées.

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

Supprimez d'abord les mises en page inutilisées avant les maîtres inutilisés afin qu'un maître devenu non référencé après le nettoyage des mises en page puisse également être supprimé. Enregistrez la présentation optimisée dans un nouveau fichier si vous avez besoin plus tard des maîtres, mises en page ou données complètes de polices incorporées d'origine. Pour plus de détails, consultez [Slide Master](/net/slide-master/) et [Embedded Font](/net/embedded-font/).

## **FAQ**

**Quand devrais-je utiliser l'API low-code au lieu du modèle d'objet complet ?**

Utilisez les assistants low-code lorsqu'une opération standard s'applique à un fichier ou une présentation complète et ne nécessite pas de contrôle détaillé sur les éléments individuels. Utilisez le modèle d'objet complet lorsque vous devez sélectionner des diapositives spécifiques, contrôler les relations entre maîtres et mises en page, inspecter l'état intermédiaire ou configurer un comportement que l'assistant n'expose pas.

**Le Merger peut-il combiner des présentations dans différents formats de fichier ?**

Non. [Merger.Process](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/merger/process/) nécessite que les présentations d'entrée soient dans le même format. Convertissez d'abord les fichiers d'entrée dans un format commun, par exemple avec [Convert.AutoByExtension](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/convert/autobyextension/), puis fusionnez les fichiers convertis.

**ForEach traite-t-il les diapositives maître, mise en page et notes ?**

[ForEach.Slide](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/slide/) parcourt les diapositives de présentation normales. Les opérations [ForEach.Shape](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/paragraph/) et [ForEach.Portion](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/portion/) à l'échelle de la présentation incluent, par défaut, les diapositives normales, maîtres et de mise en page. Utilisez leurs surcharges avec `includeNotes` fixé à `true` pour inclure les diapositives de notes.

**Quelle est la différence entre ForEach.Shape et Collect.Shapes ?**

Utilisez [ForEach.Shape](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/shape/) pour traiter chaque forme immédiatement via un rappel. Utilisez [Collect.Shapes](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/collect/shapes/) lorsque vous avez besoin d'un résultat énumérable pouvant être conservé, filtré, compté ou parcouru plusieurs fois.

**Compress réduit-il toujours la taille du fichier de présentation ?**

Pas nécessairement. Le résultat dépend de la présence ou non de mises en page inutilisées, de maîtres inutilisés ou de polices incorporées contenant des caractères non utilisés. Si aucun de ces éléments n'est présent, les opérations [Compress](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/compress/) correspondantes peuvent ne pas réduire la taille du fichier.

**Les modifications effectuées par ForEach ou Compress sont-elles enregistrées automatiquement ?**

Non. Ces assistants opèrent sur l'objet [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) chargé en mémoire. Après avoir modifié des éléments dans un rappel [ForEach](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/foreach/) ou exécuté [Compress](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/compress/), appelez [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/) pour écrire le résultat.

## **Articles associés**

- [Convertir une présentation](/net/convert-presentation/)
- [Fusionner des présentations](/net/merge-presentation/)
- [Slide Master](/net/slide-master/)
- [Gérer la zone de texte](/net/manage-textbox/)
- [Police incorporée](/net/embedded-font/)