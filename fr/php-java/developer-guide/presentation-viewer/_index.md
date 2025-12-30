---
title: Créer un visualiseur de présentation en PHP
linktitle: Visualiseur de présentation
type: docs
weight: 50
url: /fr/php-java/presentation-viewer/
keywords:
- visualiser une présentation
- visualiseur de présentation
- créer un visualiseur de présentation
- visualiser un PPT
- visualiser un PPTX
- visualiser un ODP
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Créer un visualiseur de présentation personnalisé à l'aide d'Aspose.Slides pour PHP via Java. Affichez facilement les fichiers PowerPoint et OpenDocument sans Microsoft PowerPoint."
---

Aspose.Slides pour PHP via Java est utilisé pour créer des fichiers de présentation contenant des diapositives. Ces diapositives peuvent être visualisées en ouvrant les présentations dans Microsoft PowerPoint, par exemple. Cependant, il arrive que les développeurs souhaitent afficher les diapositives sous forme d'images dans leur visionneur d'images préféré ou créer leur propre visionneur de présentation. Dans ces cas, Aspose.Slides vous permet d'exporter une diapositive individuelle en tant qu'image. Cet article décrit comment procéder.

## **Générer une image SVG à partir d'une diapositive**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtenez la référence de la diapositive à l'aide de son index.
1. Ouvrez un flux de fichier.
1. Enregistrez la diapositive en tant qu'image SVG dans le flux de fichier.
```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```


## **Générer un SVG avec un ID de forme personnalisé**

Aspose.Slides peut être utilisé pour générer un [SVG](https://docs.fileformat.com/page-description-language/svg/) à partir d'une diapositive avec un ID de forme personnalisé. Pour cela, utilisez la méthode `setId` de la classe [SvgShape](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` peut être utilisé pour définir l'ID de la forme.
```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```

```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```


## **Créer une image miniature d'une diapositive**

Aspose.Slides vous aide à générer des images miniatures de diapositives. Pour générer une miniature d'une diapositive à l'aide d'Aspose.Slides, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtenez la référence de la diapositive à l'aide de son index.
1. Obtenez l'image miniature de la diapositive référencée à une échelle définie.
1. Enregistrez l'image miniature dans le format d'image souhaité.
```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```


## **Créer une miniature de diapositive avec des dimensions définies par l'utilisateur**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtenez la référence de la diapositive à l'aide de son index.
1. Obtenez l'image miniature de la diapositive référencée avec les dimensions définies.
1. Enregistrez l'image miniature dans le format d'image souhaité.
```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```


## **Créer une miniature de diapositive avec des notes du présentateur**

1. Créez une instance de la classe [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/).
1. Utilisez la méthode `RenderingOptions.setSlidesLayoutOptions` pour définir la position des notes du présentateur.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtenez la référence de la diapositive à l'aide de son index.
1. Obtenez l'image miniature de la diapositive référencée avec les options de rendu.
1. Enregistrez l'image miniature dans le format d'image souhaité.
```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```


## **Exemple en direct**

Vous pouvez essayer l'application gratuite [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) pour voir ce que vous pouvez implémenter avec l'API Aspose.Slides :

![Visionneur PowerPoint en ligne](online-PowerPoint-viewer.png)

## **FAQ**

**Puis-je intégrer un visionneur de présentation dans une application Web ?**

Oui. Vous pouvez utiliser Aspose.Slides côté serveur pour rendre les diapositives sous forme d'images ou de HTML et les afficher dans le navigateur. Les fonctions de navigation et de zoom peuvent être implémentées avec JavaScript pour offrir une expérience interactive.

**Quelle est la meilleure façon d'afficher les diapositives dans un visionneur personnalisé ?**

L'approche recommandée consiste à rendre chaque diapositive sous forme d'image (par ex., PNG ou SVG) ou à la convertir en HTML à l'aide d'Aspose.Slides, puis à afficher le résultat dans une zone d'image (pour le bureau) ou un conteneur HTML (pour le web).

**Comment gérer de grandes présentations contenant de nombreuses diapositives ?**

Pour les présentations volumineuses, envisagez le chargement paresseux ou le rendu à la demande des diapositives. Cela signifie générer le contenu d'une diapositive uniquement lorsque l'utilisateur y navigue, ce qui réduit la consommation de mémoire et le temps de chargement.