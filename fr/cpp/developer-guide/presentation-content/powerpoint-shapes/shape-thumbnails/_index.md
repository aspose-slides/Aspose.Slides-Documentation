---
title: Miniatures de Forme
type: docs
weight: 70
url: /cpp/shape-thumbnails/
keywords: 
- miniature de forme
- image de forme
- PowerPoint
- présentation
- C++
- Aspose.Slides for С++
description: "Extraire des miniatures de forme à partir de présentations PowerPoint en C++"
---


## **Créer Miniature de Forme**
Aspose.Slides for C++ est utilisé pour créer des fichiers de présentation où chaque page est une diapositive. Ces diapositives peuvent être visualisées en ouvrant les fichiers de présentation avec Microsoft PowerPoint. Mais parfois, les développeurs peuvent avoir besoin de visualiser les images des formes séparément dans un visualiseur d'images. Dans de tels cas, Aspose.Slides for C++ vous aide à générer des images miniatures des formes de diapositives. Comment utiliser cette fonctionnalité est décrit dans cet article.
Cet article explique comment générer des miniatures de diapositives de différentes manières :

- Générer une miniature de forme à l'intérieur d'une diapositive.
- Générer une miniature de forme pour une forme de diapositive avec des dimensions définies par l'utilisateur.
- Générer une miniature de forme dans les limites d'apparence d'une forme.
- Générer une miniature d'un nœud enfant SmartArt.

## **Générer Miniature de Forme à partir de Diapositive**
Pour générer une miniature de forme à partir de n'importe quelle diapositive utilisant Aspose.Slides for C++ :

1. Créer une instance de la [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) classe.
1. Obtenir la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. Obtenir l'image miniature de forme de la diapositive référencée à l'échelle par défaut.
1. Sauvegarder l'image miniature dans n'importe quel format d'image souhaité.

L'exemple ci-dessous génère une miniature de forme.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Générer Miniature avec Facteur de Mise à l'Échelle Défini par l'Utilisateur**
Pour générer la miniature de forme de n'importe quelle forme de diapositive en utilisant Aspose.Slides for C++ :

1. Créer une instance de la [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) classe.
1. Obtenir la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. Obtenir l'image miniature de la diapositive référencée avec les limites de forme.
1. Sauvegarder l'image miniature dans n'importe quel format d'image souhaité.

L'exemple ci-dessous génère une miniature avec un facteur de mise à l'échelle défini par l'utilisateur.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Mise à l'échelle le long des axes X et Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Créer Miniature des Limites d'Apparence de la Forme**
Cette méthode pour créer des miniatures de formes permet aux développeurs de générer une miniature dans les limites de l'apparence de la forme. Elle prend en compte tous les effets de forme. La miniature de forme générée est limitée par les limites de la diapositive. Pour générer une miniature de n'importe quelle forme de diapositive dans les limites de son apparence, utilisez le code exemple suivant :

1. Créer une instance de la [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) classe.
1. Obtenir la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. Obtenir l'image miniature de la diapositive référencée avec les limites de la forme comme apparence.
1. Sauvegarder l'image miniature dans n'importe quel format d'image souhaité.

L'exemple ci-dessous crée une miniature avec un facteur de mise à l'échelle défini par l'utilisateur.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Mise à l'échelle le long des axes X et Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```