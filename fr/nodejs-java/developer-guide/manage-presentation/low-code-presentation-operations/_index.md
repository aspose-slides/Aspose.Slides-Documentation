---
title: Opérations de présentation low-code en JavaScript
linktitle: API low-code
type: docs
weight: 50
url: /fr/nodejs-java/low-code-presentation-operations/
keywords:
- API de présentation low-code
- convertir une présentation
- fusionner des présentations
- parcourir les diapositives
- parcourir les formes
- parcourir le texte
- collecter les formes
- compresser la présentation
- supprimer les diapositives maîtres inutilisées
- supprimer les diapositives de mise en page inutilisées
- compresser les polices incorporées
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Utilisez l'API low-code d'Aspose.Slides en JavaScript pour convertir et fusionner des présentations, parcourir le contenu, collecter les formes et réduire la taille de la présentation."
---
## **Vue d'ensemble**

Le namespace `aspose.slides` fournit des classes d'assistance statiques pour les opérations courantes sur les présentations. Ces assistants encapsulent les flux de travail du modèle d'objet fréquemment utilisés dans des méthodes ciblées, de sorte que vous pouvez convertir ou fusionner des fichiers, traiter les éléments de la présentation, collecter des formes et supprimer le contenu inutilisé avec moins de code.

Les assistants low-code sont les plus utiles lorsque l'opération s'applique à un fichier ou une présentation complète et que le flux de travail par défaut correspond à vos exigences. Utilisez le modèle d'objet complet [modèle d'objet Aspose.Slides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/) lorsque vous avez besoin d'un contrôle granulaire sur les diapositives individuelles, les maîtres, les dispositions, les formes, les paramètres d'exportation ou les relations entre les éléments de la présentation.

Le tableau suivant résume les assistants disponibles :

| Assistant | À utiliser pour |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/convert/) | Conversion d'une présentation vers un autre format avec un appel direct fichier à fichier. |
| [Merger](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/merger/) | Combinaison de fichiers de présentation complets du même format. |
| [ForEach](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/foreach/) | Exécution d'une action pour chaque diapositive, forme, paragraphe ou portion de texte. |
| [Collect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/collect/) | Récupération des formes de l'intégralité de la présentation pour un traitement ou une analyse répétés. |
| [Compress](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compress/) | Suppression des maîtres et dispositions inutilisés et réduction des données de police incorporées. |

## **Convertir une présentation**

Utilisez [Convert.autoByExtension](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/convert/#autoByExtension) lorsque l'extension du fichier de sortie suffit à sélectionner le format d'exportation. La méthode ouvre la présentation source, détermine le format requis à partir du chemin de sortie et écrit le résultat.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

La classe [Convert](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/convert/) fournit également des méthodes dédiées pour la sortie PDF, SVG, JPEG, PNG et TIFF. Utilisez le modèle d'objet complet lorsque vous devez inspecter ou modifier la présentation avant l'exportation ou configurer une option d'exportation qui n'est pas exposée par l'assistant sélectionné. Voir [Convertir une présentation](/slides/fr/nodejs-java/convert-presentation/) pour les flux de travail et les options spécifiques à chaque format.

## **Fusionner des présentations**

Utilisez [Merger.process](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/merger/#process) pour combiner des fichiers de présentation complets en un seul appel. Les présentations d'entrée doivent avoir le même format de fichier.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

L'assistant est approprié lorsque toutes les diapositives doivent être ajoutées à un résultat unique sans les sélectionner ou les remapper individuellement. Utilisez le modèle d'objet complet lorsque vous devez fusionner des diapositives sélectionnées, appliquer un maître ou une disposition de destination, conserver explicitement les sections, ou concilier des tailles de diapositives différentes. Voir [Fusionner des présentations](/slides/fr/nodejs-java/merge-presentation/) pour ces scénarios.

## **Parcourir les éléments de la présentation**

La classe [ForEach](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/foreach/) invoque un rappel pour chaque type d'élément de présentation demandé. Elle évite les boucles de collection imbriquées et est pratique pour l'inspection ou les modifications de format à l'échelle de la présentation. En Node.js, créez des implémentations des interfaces de rappel avec `java.newProxy`.

L'exemple suivant utilise [ForEach.slide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/foreach/#paragraph) et [ForEach.portion](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/foreach/#portion) pour inspecter les éléments correspondants :

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

Par défaut, le parcours des formes et du texte à l'échelle de la présentation inclut les diapositives normales, maîtres et dispositions. Les surcharges avec un paramètre `includeNotes` peuvent également traiter les diapositives de notes. Utilisez des boucles de collection directes lorsque l'ordre de parcours, la sortie précoce, le filtrage avant l'invocation du rappel ou le contrôle détaillé parent‑enfant sont importants.

## **Collecter les formes**

Utilisez [Collect.shapes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/collect/#shapes) lorsque vous avez besoin d'une collection de toutes les formes d'une présentation plutôt que d'un rappel pour chaque forme. Ceci est utile lorsque le même ensemble sera filtré, compté ou traité plusieurs fois.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

Utilisez [ForEach.shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/foreach/#shape) à la place lorsque chaque forme peut être traitée immédiatement et que vous n'avez pas besoin de conserver le résultat collecté.

## **Compresser le contenu de la présentation**

La classe [Compress](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compress/) peut supprimer les éléments structuraux inutilisés et réduire les données de police incorporées :

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) supprime les diapositives de disposition qui ne sont référencées par aucune diapositive normale.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) supprime les diapositives maîtres qui ne sont plus utilisées.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) supprime les caractères inutilisés des polices incorporées.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Supprimez d'abord les dispositions inutilisées avant les maîtres inutilisés afin qu'un maître devenu non référencé après le nettoyage des dispositions puisse également être supprimé. Enregistrez la présentation optimisée dans un nouveau fichier si vous devez conserver ultérieurement les maîtres, dispositions ou l'intégralité des données de police incorporées. Pour plus de détails, consultez [Maître de diapositive](/slides/fr/nodejs-java/slide-master/) et [Police incorporée](/slides/fr/nodejs-java/embedded-font/).

## **FAQ**

**Quand devrais‑je utiliser l'API low‑code plutôt que le modèle d'objet complet ?**

Utilisez les assistants low-code lorsqu'une opération standard s'applique à un fichier ou une présentation complète et ne nécessite pas de contrôle détaillé sur des éléments individuels. Utilisez le modèle d'objet complet lorsque vous devez sélectionner des diapositives spécifiques, contrôler les relations entre maîtres et dispositions, inspecter l'état intermédiaire ou configurer un comportement que l'assistant n'expose pas.

**Le Merger peut‑il combiner des présentations dans différents formats de fichier ?**

Non. [Merger.process](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/merger/#process) nécessite que les présentations d'entrée soient dans le même format. Convertissez d'abord les fichiers d'entrée vers un format commun, par exemple avec [Convert.autoByExtension](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/convert/#autoByExtension), puis fusionnez les fichiers convertis.

**ForEach traite‑t‑il les diapositives master, layout et notes ?**

[ForEach.slide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/foreach/#slide) parcourt les diapositives normales de la présentation. Les opérations à l'échelle de la présentation [ForEach.shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/foreach/#paragraph) et [ForEach.portion](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/foreach/#portion) incluent par défaut les diapositives normales, maîtres et dispositions. Utilisez leurs surcharges avec `includeNotes` réglé sur `true` pour inclure les diapositives de notes.

**Quelle est la différence entre ForEach.shape et Collect.shapes ?**

Utilisez [ForEach.shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/foreach/#shape) pour traiter chaque forme immédiatement via un rappel. Utilisez [Collect.shapes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/collect/#shapes) lorsque vous avez besoin d'un résultat itérable qui peut être conservé, filtré, compté ou parcouru plusieurs fois.

**Compress réduit‑il toujours la taille du fichier de la présentation ?**

Pas nécessairement. Le résultat dépend de la présence ou non de dispositions inutilisées, de maîtres inutilisés ou de polices incorporées contenant des caractères inutilisés. Si aucun de ces éléments n'est présent, les opérations [Compress](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compress/) correspondantes peuvent ne pas diminuer la taille du fichier.

**Les modifications effectuées par ForEach ou Compress sont‑elles enregistrées automatiquement ?**

Non. Ces assistants opèrent sur l'objet [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) chargé en mémoire. Après avoir modifié des éléments dans un rappel [ForEach](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/foreach/) ou exécuté [Compress](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compress/), appelez [Presentation.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#save) pour écrire le résultat.

## **Articles associés**

- [Convertir une présentation](/slides/fr/nodejs-java/convert-presentation/)
- [Fusionner des présentations](/slides/fr/nodejs-java/merge-presentation/)
- [Maître de diapositive](/slides/fr/nodejs-java/slide-master/)
- [Gérer la zone de texte](/slides/fr/nodejs-java/manage-textbox/)
- [Police incorporée](/slides/fr/nodejs-java/embedded-font/)