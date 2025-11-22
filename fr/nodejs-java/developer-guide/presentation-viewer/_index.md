---
title: Visionneuse de présentation
type: docs
weight: 50
url: /fr/nodejs-java/presentation-viewer/
keywords:
- voir la présentation
- visionneuse de présentation
- voir PPT
- voir PPTX
- voir ODP
- PowerPoint
- OpenDocument
- Node.js
- Java
- Aspose.Slides pour Node.js via Java
description: "Visionneuse de présentation PowerPoint en JavaScript"
---

Aspose.Slides pour Node.js via Java est utilisé pour créer des fichiers de présentation contenant des diapositives. Ces diapositives peuvent être visualisées en ouvrant les présentations dans Microsoft PowerPoint, par exemple. Cependant, il arrive parfois que des développeurs souhaitent afficher les diapositives sous forme d'images dans leur visualiseur d'images préféré ou créer leur propre visualiseur de présentation. Dans ce cas, Aspose.Slides vous permet d'exporter une diapositive individuelle en tant qu'image. Cet article explique comment le faire.

## **Générer une image SVG à partir d'une diapositive**

Pour générer une image SVG à partir d'une diapositive de présentation avec Aspose.Slides, veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenir la référence de la diapositive par son indice.
1. Ouvrir un flux de fichier.
1. Enregistrer la diapositive en tant qu'image SVG dans le flux de fichier.
```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```


## **Générer un SVG avec un ID de forme personnalisé**

Aspose.Slides peut être utilisé pour générer un [SVG](https://docs.fileformat.com/page-description-language/svg/) à partir d'une diapositive avec un ID de forme personnalisé. Pour ce faire, utilisez la méthode `setId` de [SvgShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` peut être utilisé pour définir l'ID de la forme.
```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```

```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```


## **Créer une image miniature d'une diapositive**

Aspose.Slides vous aide à générer des images miniatures des diapositives. Pour générer une miniature d'une diapositive avec Aspose.Slides, veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenir la référence de la diapositive par son indice.
1. Obtenir l'image miniature de la diapositive référencée à une échelle définie.
1. Enregistrer l'image miniature dans le format d'image souhaité.
```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **Créer une miniature de diapositive avec des dimensions définies par l'utilisateur**

Pour créer une image miniature de diapositive avec des dimensions définies par l'utilisateur, veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenir la référence de la diapositive par son indice.
1. Obtenir l'image miniature de la diapositive référencée avec les dimensions définies.
1. Enregistrer l'image miniature dans le format d'image souhaité.
```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **Créer une miniature de diapositive avec les notes du présentateur**

Pour générer la miniature d'une diapositive avec les notes du présentateur en utilisant Aspose.Slides, veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/).
1. Utilisez la méthode `RenderingOptions.setSlidesLayoutOptions` pour définir la position des notes du présentateur.
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenir la référence de la diapositive par son indice.
1. Obtenir l'image miniature de la diapositive référencée avec les options de rendu.
1. Enregistrer l'image miniature dans le format d'image souhaité.
```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```


## **Exemple en direct**

Vous pouvez essayer l'application gratuite [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) pour voir ce que vous pouvez implémenter avec l'API Aspose.Slides :

![Visionneuse PowerPoint en ligne](online-PowerPoint-viewer.png)

## **FAQ**

**Puis-je intégrer un visualiseur de présentation dans une application Web Node.js ?**

Oui. Vous pouvez utiliser Aspose.Slides côté serveur pour rendre les diapositives sous forme d'images ou de HTML et les afficher dans le navigateur. Les fonctionnalités de navigation et de zoom peuvent être implémentées avec JavaScript pour offrir une expérience interactive.

**Quelle est la meilleure façon d'afficher des diapositives dans un visualiseur personnalisé ?**

L'approche recommandée consiste à rendre chaque diapositive sous forme d'image (par ex., PNG ou SVG) ou à la convertir en HTML à l'aide d'Aspose.Slides, puis à afficher le résultat dans une zone d'image (pour le bureau) ou un conteneur HTML (pour le Web).

**Comment gérer de grandes présentations contenant de nombreuses diapositives ?**

Pour les présentations volumineuses, envisagez le chargement différé ou le rendu à la demande des diapositives. Cela signifie générer le contenu d'une diapositive uniquement lorsque l'utilisateur y accède, ce qui réduit la consommation de mémoire et le temps de chargement.