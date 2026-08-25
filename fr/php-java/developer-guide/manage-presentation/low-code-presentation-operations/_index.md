---
title: Opérations de présentation low-code en PHP
linktitle: API low-code
type: docs
weight: 50
url: /fr/php-java/low-code-presentation-operations/
keywords:
- API de présentation low-code
- convertir une présentation
- fusionner des présentations
- parcourir les diapositives
- parcourir les formes
- parcourir le texte
- collecter les formes
- compresser la présentation
- supprimer les maîtres de diapositives inutilisés
- supprimer les mises en page inutilisées
- compresser les polices incorporées
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Utilisez l'API low-code Aspose.Slides en PHP pour convertir et fusionner des présentations, parcourir le contenu, collecter les formes et réduire la taille de la présentation."
---
## **Vue d'ensemble**

Le espace de noms [aspose.slides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/) fournit des classes d'assistance statiques pour les opérations courantes sur les présentations. Ces assistants enveloppent les flux de travail du modèle d'objet fréquemment utilisés dans des méthodes ciblées, ce qui vous permet de convertir ou fusionner des fichiers, de traiter les éléments de la présentation, de collecter des formes et de supprimer le contenu inutilisé avec moins de code.

Les assistants low‑code sont les plus utiles lorsque l'opération s'applique à un fichier ou une présentation entière et que le flux de travail par défaut correspond à vos exigences. Utilisez le [modèle d'objet Aspose.Slides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/) complet lorsque vous avez besoin d'un contrôle granulaire sur les diapositives individuelles, les maîtres, les mises en page, les formes, les paramètres d'exportation ou les relations entre les éléments de la présentation.

Le tableau suivant résume les assistants disponibles :

| Assistant | Utilisation |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fr/php-java/aspose.slides/convert/) | Convertir une présentation vers un autre format avec un appel direct fichier‑à‑fichier. |
| [Merger](https://reference.aspose.com/slides/fr/php-java/aspose.slides/merger/) | Combiner des fichiers de présentation complets du même format. |
| [ForEach_](https://reference.aspose.com/slides/fr/php-java/aspose.slides/foreach_/) | Exécuter un rappel pour chaque diapositive, forme, paragraphe ou portion de texte. |
| [Collect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/collect/) | Récupérer les formes de l'ensemble de la présentation pour un traitement ou une analyse répétés. |
| [Compress](https://reference.aspose.com/slides/fr/php-java/aspose.slides/compress/) | Supprimer les maîtres et mises en page inutilisés et réduire les données de police incorporées. |

## **Convertir une présentation**

Utilisez [Convert::autoByExtension](https://reference.aspose.com/slides/fr/php-java/aspose.slides/convert/#autoByExtension) lorsque l'extension du fichier de sortie suffit à sélectionner le format d'exportation. La méthode ouvre la présentation source, détermine le format requis à partir du chemin de sortie et écrit le résultat.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

La classe [Convert](https://reference.aspose.com/slides/fr/php-java/aspose.slides/convert/) propose également des méthodes dédiées pour les sorties PDF, SVG, JPEG, PNG et TIFF. Utilisez le modèle d'objet complet lorsque vous devez inspecter ou modifier la présentation avant l'exportation ou configurer une option d'exportation qui n'est pas exposée par l'assistant sélectionné. Voir [Convert Presentation](/slides/fr/php-java/convert-presentation/) pour les flux de travail et options spécifiques à chaque format.

## **Fusionner des présentations**

Utilisez [Merger::process](https://reference.aspose.com/slides/fr/php-java/aspose.slides/merger/#process) pour combiner des fichiers de présentation complets en un seul appel. Les présentations d'entrée doivent avoir le même format de fichier.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

L'assistant est approprié lorsque toutes les diapositives doivent être ajoutées à un seul résultat sans les sélectionner ou les remapper individuellement. Utilisez le modèle d'objet complet lorsque vous devez fusionner des diapositives sélectionnées, appliquer un maître ou une mise en page de destination, préserver explicitement les sections ou concilier des tailles de diapositives différentes. Voir [Merge Presentations](/slides/fr/php-java/merge-presentation/) pour ces scénarios.

## **Parcourir les éléments de la présentation**

La classe [ForEach_](https://reference.aspose.com/slides/fr/php-java/aspose.slides/foreach_/) invoque un rappel pour chaque type d'élément de présentation demandé. Elle évite les boucles de collection imbriquées et est pratique pour l'inspection ou les modifications de format à l'échelle de la présentation.

L'exemple suivant utilise [ForEach_::slide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/foreach_/#paragraph) et [ForEach_::portion](https://reference.aspose.com/slides/fr/php-java/aspose.slides/foreach_/#portion) pour inspecter les éléments correspondants :

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

Par défaut, le parcours des formes et du texte à l'échelle de la présentation inclut les diapositives normales, maîtres et de mise en page. Les surcharges avec un paramètre `includeNotes` peuvent également traiter les diapositives de notes. Utilisez des boucles de collection directes lorsque l'ordre de parcours, la sortie anticipée, le filtrage avant l'invocation du rappel ou le contrôle détaillé parent‑enfant sont importants.

## **Collecter les formes**

Utilisez [Collect::shapes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/collect/#shapes) lorsque vous avez besoin d'une collection de toutes les formes d'une présentation plutôt que d'un rappel pour chaque forme. Cela est utile lorsque le même ensemble sera filtré, compté ou traité plusieurs fois.

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Utilisez plutôt [ForEach_::shape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/foreach_/#shape) lorsque chaque forme peut être traitée immédiatement et que vous n'avez pas besoin de conserver le résultat collecté.

## **Compresser le contenu de la présentation**

La classe [Compress](https://reference.aspose.com/slides/fr/php-java/aspose.slides/compress/) peut supprimer les éléments structurels inutilisés et réduire les données de polices incorporées :

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) supprime les diapositives de mise en page qui ne sont référencées par aucune diapositive normale.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/compress/#removeUnusedMasterSlides) supprime les maîtres de diapositives qui ne sont plus utilisés.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/fr/php-java/aspose.slides/compress/#compressEmbeddedFonts) supprime les caractères inutilisés des polices incorporées.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Supprimez d'abord les mises en page inutilisées, puis les maîtres inutilisés afin qu'un maître devenu non référencé après le nettoyage des mises en page puisse également être supprimé. Enregistrez la présentation optimisée dans un nouveau fichier si vous devez éventuellement conserver les maîtres, mises en page ou l'intégralité des données de polices incorporées d'origine. Pour plus de détails, consultez [Slide Master](/slides/fr/php-java/slide-master/) et [Embedded Font](/slides/fr/php-java/embedded-font/).

## **FAQ**

**Quand devrais‑je utiliser l'API low‑code plutôt que le modèle d'objet complet ?**

Utilisez les assistants low‑code lorsqu'une opération standard s'applique à un fichier ou une présentation complète et ne nécessite pas de contrôle détaillé sur les éléments individuels. Utilisez le modèle d'objet complet lorsque vous devez sélectionner des diapositives spécifiques, contrôler les relations maître‑mise en page, inspecter l'état intermédiaire ou configurer un comportement que l'assistant n'expose pas.

**Le Merger peut‑il combiner des présentations dans différents formats de fichier ?**

Non. [Merger::process](https://reference.aspose.com/slides/fr/php-java/aspose.slides/merger/#process) nécessite que les présentations d'entrée soient dans le même format. Convertissez d'abord les fichiers d'entrée dans un format commun, par exemple avec [Convert::autoByExtension](https://reference.aspose.com/slides/fr/php-java/aspose.slides/convert/#autoByExtension), puis fusionnez les fichiers convertis.

**Le ForEach_ traite‑t‑il les diapositives maître, mise en page et notes ?**

[ForEach_::slide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/foreach_/#slide) parcourt les diapositives normales de la présentation. Les opérations [ForEach_::shape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/foreach_/#paragraph) et [ForEach_::portion](https://reference.aspose.com/slides/fr/php-java/aspose.slides/foreach_/#portion) à l'échelle de la présentation incluent, par défaut, les diapositives normales, maîtres et de mise en page. Utilisez leurs surcharges avec `includeNotes` à `true` pour inclure les diapositives de notes.

**Quelle est la différence entre ForEach_::shape et Collect::shapes ?**

Utilisez [ForEach_::shape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/foreach_/#shape) pour traiter chaque forme immédiatement via un rappel. Utilisez [Collect::shapes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/collect/#shapes) lorsque vous avez besoin d'un résultat itérable pouvant être conservé, filtré, compté ou parcouru plusieurs fois.

**Compress réduit‑il toujours la taille du fichier de présentation ?**

Pas nécessairement. Le résultat dépend du fait que la présentation contienne ou non des mises en page inutilisées, des maîtres inutilisés ou des polices incorporées avec des caractères inutilisés. Si aucun de ces éléments n'est présent, les opérations [Compress](https://reference.aspose.com/slides/fr/php-java/aspose.slides/compress/) correspondantes peuvent ne pas réduire la taille du fichier.

**Les modifications effectuées par ForEach_ ou Compress sont‑elles enregistrées automatiquement ?**

Non. Ces assistants opèrent sur l'objet [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) chargé en mémoire. Après avoir modifié des éléments dans un rappel [ForEach_](https://reference.aspose.com/slides/fr/php-java/aspose.slides/foreach_) ou exécuté [Compress](https://reference.aspose.com/slides/fr/php-java/aspose.slides/compress/), appelez [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#save) pour écrire le résultat.

## **Articles associés**

- [Convert Presentation](/slides/fr/php-java/convert-presentation/)
- [Merge Presentations](/slides/fr/php-java/merge-presentation/)
- [Slide Master](/slides/fr/php-java/slide-master/)
- [Manage Text Box](/slides/fr/php-java/manage-textbox/)
- [Embedded Font](/slides/fr/php-java/embedded-font/)