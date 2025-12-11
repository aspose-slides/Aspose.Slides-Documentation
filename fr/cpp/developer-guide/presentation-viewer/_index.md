---
title: Créer un visualiseur de présentation en C++
linktitle: Visualiseur de présentation
type: docs
weight: 50
url: /fr/cpp/presentation-viewer/
keywords: 
- visualiser la présentation
- visualiseur de présentation
- créer un visualiseur de présentation
- visualiser PPT
- visualiser PPTX
- visualiser ODP
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Créer un visualiseur de présentation personnalisé en C++ avec Aspose.Slides. Affichez facilement les fichiers PowerPoint et OpenDocument sans Microsoft PowerPoint."
---

Aspose.Slides pour C++ est utilisé pour créer des fichiers de présentation contenant des diapositives. Ces diapositives peuvent être affichées en ouvrant les présentations dans Microsoft PowerPoint, par exemple. Cependant, il arrive que les développeurs aient besoin de visualiser les diapositives sous forme d'images dans leur visualiseur d'images préféré ou de créer leur propre visualiseur de présentation. Dans de tels cas, Aspose.Slides vous permet d'exporter une diapositive individuelle en tant qu'image. Cet article décrit comment procéder.

## **Générer une image SVG à partir d'une diapositive**

Pour générer une image SVG à partir d'une diapositive de présentation avec Aspose.Slides, veuillez suivre les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenir la référence de la diapositive par son indice.
1. Ouvrir un flux de fichier.
1. Enregistrer la diapositive en tant qu'image SVG dans le flux de fichier.
```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```


## **Générer un SVG avec un ID de forme personnalisé**

Aspose.Slides peut être utilisé pour générer un [SVG](https://docs.fileformat.com/page-description-language/svg/) à partir d'une diapositive avec un ID de forme personnalisé. Pour ce faire, utilisez la méthode `set_Id` de [ISvgShape](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/). `CustomSvgShapeFormattingController` peut être utilisé pour définir l'ID de la forme.
```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```


## **Créer une image miniature d'une diapositive**

Aspose.Slides vous aide à générer des images miniatures de diapositives. Pour générer une miniature d'une diapositive avec Aspose.Slides, veuillez suivre les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenir la référence de la diapositive par son indice.
1. Obtenir l'image miniature de la diapositive référencée à une échelle définie.
1. Enregistrer l'image miniature dans le format d'image souhaité.
```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Créer une miniature de diapositive avec des dimensions définies par l'utilisateur**

Pour créer une image miniature de diapositive avec des dimensions définies par l'utilisateur, veuillez suivre les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenir la référence de la diapositive par son indice.
1. Obtenir l'image miniature de la diapositive référencée avec les dimensions définies.
1. Enregistrer l'image miniature dans le format d'image souhaité.
```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Créer une miniature de diapositive avec les notes du présentateur**

Pour générer la miniature d'une diapositive avec les notes du présentateur en utilisant Aspose.Slides, veuillez suivre les étapes ci‑dessous :

1. Créer une instance de la classe [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/).
1. Utiliser la méthode `RenderingOptions.set_SlidesLayoutOptions` pour définir la position des notes du présentateur.
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenir la référence de la diapositive par son indice.
1. Obtenir l'image miniature de la diapositive référencée avec les options de rendu.
1. Enregistrer l'image miniature dans le format d'image souhaité.
```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Exemple en direct**

Vous pouvez essayer l'application gratuite [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) pour voir ce que vous pouvez implémenter avec l'API Aspose.Slides :

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Puis-je intégrer un visualiseur de présentation dans une application web ?**

Oui. Vous pouvez utiliser Aspose.Slides côté serveur pour rendre les diapositives sous forme d'images ou de HTML et les afficher dans le navigateur. Les fonctions de navigation et de zoom peuvent être implémentées avec JavaScript pour une expérience interactive.

**Quelle est la meilleure façon d'afficher les diapositives dans un visualiseur personnalisé ?**

L'approche recommandée consiste à rendre chaque diapositive sous forme d'image (par ex., PNG ou SVG) ou à la convertir en HTML à l'aide d'Aspose.Slides, puis à afficher le résultat dans une zone d'image (pour le bureau) ou un conteneur HTML (pour le web).

**Comment gérer de grandes présentations contenant de nombreuses diapositives ?**

Pour les présentations volumineuses, envisagez le chargement différé ou le rendu à la demande des diapositives. Cela signifie générer le contenu d'une diapositive uniquement lorsque l'utilisateur y accède, réduisant ainsi la consommation de mémoire et le temps de chargement.