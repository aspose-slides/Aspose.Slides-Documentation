---
title: Créer un visionneur de présentation sur Android
linktitle: Visionneur de présentation
type: docs
weight: 50
url: /fr/androidjava/presentation-viewer/
keywords:
- afficher une présentation
- visionneuse de présentation
- créer une visionneuse de présentation
- afficher PPT
- afficher PPTX
- afficher ODP
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Créer une visionneuse de présentation personnalisée en Java avec Aspose.Slides pour Android. Affichez facilement les fichiers PowerPoint et OpenDocument sans Microsoft PowerPoint."
---

Aspose.Slides for Android via Java est utilisé pour créer des fichiers de présentation contenant des diapositives. Ces diapositives peuvent être visualisées en ouvrant les présentations dans Microsoft PowerPoint, par exemple. Cependant, il arrive parfois que les développeurs souhaitent voir les diapositives sous forme d'images dans leur visionneuse d'images préférée ou créer leur propre visionneur de présentation. Dans ces cas, Aspose.Slides permet d'exporter une diapositive individuelle en tant qu'image. Cet article décrit comment procéder.

## **Générer une image SVG à partir d’une diapositive**

Pour générer une image SVG à partir d'une diapositive de présentation avec Aspose.Slides, veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtenir la référence de la diapositive par son indice.
1. Ouvrir un flux de fichier.
1. Enregistrer la diapositive en tant qu'image SVG dans le flux de fichier.
```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```


## **Générer un SVG avec un identifiant de forme personnalisé**

Aspose.Slides peut être utilisé pour générer un [SVG](https://docs.fileformat.com/page-description-language/svg/) à partir d'une diapositive avec un identifiant de forme personnalisé. Pour ce faire, utilisez la méthode `setId` de [ISvgShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/). `CustomSvgShapeFormattingController` peut être utilisé pour définir l'identifiant de forme.
```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```

```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```


## **Créer une image miniature d’une diapositive**

Aspose.Slides vous aide à générer des images miniatures de diapositives. Pour générer une miniature d'une diapositive avec Aspose.Slides, veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtenir la référence de la diapositive par son indice.
1. Obtenir l'image miniature de la diapositive référencée à une échelle définie.
1. Enregistrer l'image miniature dans le format d'image souhaité.
```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **Créer une miniature de diapositive avec des dimensions définies par l’utilisateur**

Pour créer une image miniature de diapositive avec des dimensions définies par l'utilisateur, veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtenir la référence de la diapositive par son indice.
1. Obtenir l'image miniature de la diapositive référencée avec les dimensions définies.
1. Enregistrer l'image miniature dans le format d'image souhaité.
```java
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **Créer une miniature de diapositive avec des notes du présentateur**

Pour générer la miniature d'une diapositive avec des notes du présentateur en utilisant Aspose.Slides, veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/).
1. Utiliser la méthode `RenderingOptions.setSlidesLayoutOptions` pour définir la position des notes du présentateur.
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtenir la référence de la diapositive par son indice.
1. Obtenir l'image miniature de la diapositive référencée avec les options de rendu.
1. Enregistrer l'image miniature dans le format d'image souhaité.
```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```


## **Exemple en direct**

Vous pouvez essayer l'application gratuite [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) pour voir ce que vous pouvez implémenter avec l'API Aspose.Slides :

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Puis-je intégrer un visionneur de présentation dans une application web ?**

Oui. Vous pouvez utiliser Aspose.Slides côté serveur pour rendre les diapositives sous forme d'images ou de HTML et les afficher dans le navigateur. Les fonctions de navigation et de zoom peuvent être implémentées avec JavaScript pour offrir une expérience interactive.

**Quelle est la meilleure façon d'afficher les diapositives dans un visionneur personnalisé ?**

L'approche recommandée consiste à rendre chaque diapositive sous forme d'image (par ex., PNG ou SVG) ou à la convertir en HTML à l'aide d'Aspose.Slides, puis à afficher le résultat dans une zone d'image (pour le bureau) ou un conteneur HTML (pour le web).

**Comment gérer de grandes présentations contenant de nombreuses diapositives ?**

Pour de grands jeux de diapositives, envisagez le chargement différé ou le rendu à la demande des diapositives. Cela signifie générer le contenu d'une diapositive uniquement lorsque l'utilisateur y accède, ce qui réduit la consommation de mémoire et le temps de chargement.