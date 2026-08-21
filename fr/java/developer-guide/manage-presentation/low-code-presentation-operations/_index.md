---
title: Opérations de présentation low-code en Java
linktitle: API low-code
type: docs
weight: 50
url: /fr/java/low-code-presentation-operations/
keywords:
- API de présentation low-code
- convertir une présentation
- fusionner des présentations
- parcourir les diapositives
- parcourir les formes
- parcourir le texte
- collecter des formes
- compresser la présentation
- supprimer les maîtres inutilisés
- supprimer les mises en page inutilisées
- compresser les polices intégrées
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Utilisez l'API low-code d'Aspose.Slides en Java pour convertir et fusionner des présentations, parcourir le contenu, collecter des formes et réduire la taille de la présentation."
---
## **Vue d'ensemble**

Le package [com.aspose.slides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/) fournit des classes d'assistance statiques pour les opérations courantes de présentation. Ces assistants encapsulent les flux de travail du modèle d'objet fréquemment utilisés dans des méthodes ciblées, ce qui vous permet de convertir ou de fusionner des fichiers, de traiter les éléments d'une présentation, de collecter des formes et de supprimer le contenu inutilisé avec moins de code.

Les assistants low-code sont les plus utiles lorsque l'opération s'applique à un fichier ou une présentation entière et que le flux de travail par défaut correspond à vos besoins. Utilisez le modèle d'objet complet [Aspose.Slides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/) lorsque vous avez besoin d'un contrôle granulaire sur les diapositives individuelles, les maîtres, les mises en page, les formes, les paramètres d'exportation ou les relations entre les éléments de la présentation.

Le tableau suivant résume les assistants disponibles :

| Assistant | À utiliser pour |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fr/java/com.aspose.slides/convert/) | Conversion d'une présentation vers un autre format avec un appel direct fichier à fichier. |
| [Merger](https://reference.aspose.com/slides/fr/java/com.aspose.slides/merger/) | Combinaison de fichiers de présentation complets du même format. |
| [ForEach](https://reference.aspose.com/slides/fr/java/com.aspose.slides/foreach/) | Exécution d'une action pour chaque diapositive, forme, paragraphe ou portion de texte. |
| [Collect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/collect/) | Récupération des formes de l'ensemble de la présentation pour un traitement ou une analyse répétés. |
| [Compress](https://reference.aspose.com/slides/fr/java/com.aspose.slides/compress/) | Suppression des maîtres et mises en page inutilisés et réduction des données de polices intégrées. |

## **Convertir une présentation**

Utilisez [Convert.autoByExtension](https://reference.aspose.com/slides/fr/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) lorsque l'extension du fichier de destination suffit à sélectionner le format d'exportation. La méthode ouvre la présentation source, détermine le format requis à partir du chemin de sortie et écrit le résultat.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

La classe [Convert](https://reference.aspose.com/slides/fr/java/com.aspose.slides/convert/) propose également des méthodes dédiées pour la sortie PDF, SVG, JPEG, PNG et TIFF. Utilisez le modèle d'objet complet lorsque vous devez inspecter ou modifier la présentation avant l'exportation ou configurer une option d'exportation qui n'est pas exposée par l'assistant sélectionné. Consultez [Convertir une présentation](/java/convert-presentation/) pour les flux de travail et les options spécifiques à chaque format.

## **Fusionner des présentations**

Utilisez [Merger.process](https://reference.aspose.com/slides/fr/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) pour combiner des fichiers de présentation complets en un seul appel. Les présentations d'entrée doivent être au même format de fichier.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Cet assistant est approprié lorsque toutes les diapositives doivent être ajoutées à un résultat unique sans les sélectionner ou les remapper individuellement. Utilisez le modèle d'objet complet lorsque vous devez fusionner des diapositives sélectionnées, appliquer un maître ou une mise en page de destination, préserver explicitement les sections, ou concilier des tailles de diapositive différentes. Consultez [Fusionner des présentations](/java/merge-presentation/) pour ces scénarios.

## **Parcourir les éléments de la présentation**

La classe [ForEach](https://reference.aspose.com/slides/fr/java/com.aspose.slides/foreach/) invoque un rappel pour chaque type d'élément de présentation demandé. Elle évite les boucles de collection imbriquées et est pratique pour l'inspection ou les modifications de mise en forme à l'échelle de la présentation.

L'exemple suivant utilise [ForEach.slide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), et [ForEach.portion](https://reference.aspose.com/slides/fr/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) pour inspecter les éléments correspondants :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

Par défaut, le parcours des formes et du texte à l'échelle de la présentation inclut les diapositives normales, maîtres et de mise en page. Les surcharges avec un paramètre `includeNotes` peuvent également traiter les diapositives de notes. Utilisez des boucles de collection directes lorsque l'ordre de parcours, la sortie anticipée, le filtrage avant l'appel du rappel ou le contrôle détaillé parent‑enfant sont importants.

## **Collecter les formes**

Utilisez [Collect.shapes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) lorsque vous avez besoin d'une collection de toutes les formes d'une présentation plutôt que d'un rappel pour chaque forme. Cela est utile lorsque le même jeu sera filtré, compté ou traité plusieurs fois.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

Utilisez [ForEach.shape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) à la place lorsque chaque forme peut être traitée immédiatement et que vous n'avez pas besoin de conserver le résultat collecté.

## **Compresser le contenu de la présentation**

La classe [Compress](https://reference.aspose.com/slides/fr/java/com.aspose.slides/compress/) peut supprimer les éléments structurels inutilisés et réduire les données de polices intégrées :

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) supprime les diapositives de mise en page qui ne sont référencées par aucune diapositive normale.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) supprime les diapositives maîtres qui ne sont plus utilisées.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/fr/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) supprime les caractères inutilisés des polices intégrées.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Supprimez d'abord les mises en page inutilisées, puis les maîtres inutilisés afin qu'un maître devenu non référencé après le nettoyage des mises en page puisse également être supprimé. Enregistrez la présentation optimisée dans un nouveau fichier si vous devez éventuellement conserver les maîtres, les mises en page ou les données complètes de polices intégrées d'origine. Pour plus de détails, consultez [Slide Master](/java/slide-master/) et [Embedded Font](/java/embedded-font/).

## **FAQ**

**Quand dois-je utiliser l'API low-code au lieu du modèle d'objet complet ?**

Utilisez les assistants low-code lorsqu'une opération standard s'applique à un fichier ou une présentation complète et ne nécessite pas de contrôle détaillé sur les éléments individuels. Utilisez le modèle d'objet complet lorsque vous devez sélectionner des diapositives spécifiques, contrôler les relations maître‑mise en page, inspecter l'état intermédiaire ou configurer un comportement que l'assistant n'expose pas.

**Le Merger peut-il combiner des présentations dans différents formats de fichier ?**

Non. [Merger.process](https://reference.aspose.com/slides/fr/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) nécessite que les présentations d'entrée soient dans le même format. Convertissez d'abord les fichiers d'entrée vers un format commun, par exemple avec [Convert.autoByExtension](https://reference.aspose.com/slides/fr/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), puis fusionnez les fichiers convertis.

**Le ForEach traite-t-il les diapositives maître, mise en page et notes ?**

[ForEach.slide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) parcourt les diapositives normales de la présentation. Les opérations à l'échelle de la présentation [ForEach.shape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) et [ForEach.portion](https://reference.aspose.com/slides/fr/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) incluent par défaut les diapositives normales, maîtres et de mise en page. Utilisez leurs surcharges avec `includeNotes` à `true` pour inclure les diapositives de notes.

**Quelle est la différence entre ForEach.shape et Collect.shapes ?**

Utilisez [ForEach.shape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) pour traiter chaque forme immédiatement via un rappel. Utilisez [Collect.shapes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) lorsque vous avez besoin d'un résultat itérable qui peut être conservé, filtré, compté ou parcouru plusieurs fois.

**Compress réduit-il toujours la taille du fichier de présentation ?**

Pas nécessairement. Le résultat dépend de la présence ou non de mises en page inutilisées, de maîtres inutilisés ou de polices intégrées contenant des caractères inutilisés. Si aucune de ces situations n'existe, les opérations [Compress](https://reference.aspose.com/slides/fr/java/com.aspose.slides/compress/) correspondantes peuvent ne pas diminuer la taille du fichier.

**Les modifications apportées par ForEach ou Compress sont-elles enregistrées automatiquement ?**

Non. Ces assistants agissent sur l'objet [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) chargé en mémoire. Après avoir modifié des éléments dans un rappel [ForEach](https://reference.aspose.com/slides/fr/java/com.aspose.slides/foreach/) ou exécuté [Compress](https://reference.aspose.com/slides/fr/java/com.aspose.slides/compress/), appelez [Presentation.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) pour écrire le résultat.

## **Articles associés**

- [Convertir une présentation](/java/convert-presentation/)
- [Fusionner des présentations](/java/merge-presentation/)
- [Slide Master](/java/slide-master/)
- [Gérer la zone de texte](/java/manage-textbox/)
- [Embedded Font](/java/embedded-font/)