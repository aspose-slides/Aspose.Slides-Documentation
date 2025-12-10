---
title: Créer des vignettes de formes de présentation en C++
linktitle: Vignettes de formes
type: docs
weight: 70
url: /fr/cpp/shape-thumbnails/
keywords:
- vignette de forme
- image de forme
- rendu de forme
- rendu de forme
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Générez des vignettes de formes de haute qualité à partir des diapositives PowerPoint avec Aspose.Slides pour C++ – créez et exportez facilement des vignettes de présentation."
---

## **Créer une vignette de forme**
Aspose.Slides for C++ est utilisé pour créer des fichiers de présentation où chaque page est une diapositive. Ces diapositives peuvent être visualisées en ouvrant les fichiers de présentation avec Microsoft PowerPoint. Mais parfois, les développeurs ont besoin de voir les images des formes séparément dans un visualiseur d’images. Dans ce cas, Aspose.Slides for C++ vous aide à générer des images miniatures des formes de diapositive. Le mode d’emploi de cette fonctionnalité est décrit dans cet article.
Cet article explique comment générer des miniatures de diapositive de différentes manières :

- Génération d’une vignette de forme à l’intérieur d’une diapositive.
- Génération d’une vignette de forme pour une forme de diapositive avec des dimensions définies par l’utilisateur.
- Génération d’une vignette de forme dans les limites de l’apparence d’une forme.
- Génération d’une vignette d’un nœud enfant SmartArt.

## **Générer une vignette de forme à partir d’une diapositive**
Pour générer une vignette de forme à partir de n’importe quelle diapositive à l’aide d’Aspose.Slides for C++ :

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) classe.
1. Obtenez la référence de n’importe quelle diapositive en utilisant son ID ou son index.
1. Récupérez l’image vignette de la forme de la diapositive référencée avec l’échelle par défaut.
1. Enregistrez l’image vignette dans le format d’image souhaité.

L’exemple ci‑dessous génère une vignette de forme.
```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Générer une vignette avec facteur d’échelle défini par l’utilisateur**
Pour générer la vignette d’une forme quelconque à l’aide d’Aspose.Slides for C++ :

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) classe.
1. Obtenez la référence de n’importe quelle diapositive en utilisant son ID ou son index.
1. Récupérez l’image vignette de la diapositive référencée avec les limites de la forme.
1. Enregistrez l’image vignette dans le format d’image souhaité.

L’exemple ci‑dessous génère une vignette avec un facteur d’échelle défini par l’utilisateur.
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


## **Créer une vignette d’apparence de forme basée sur les limites**
Cette méthode de création de miniatures de formes permet aux développeurs de générer une vignette dans les limites de l’apparence de la forme. Elle prend en compte tous les effets de forme. La vignette de forme générée est restreinte par les limites de la diapositive. Pour générer une vignette de n’importe quelle forme de diapositive dans les limites de son apparence, utilisez le code d’exemple suivant :

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) classe.
1. Obtenez la référence de n’importe quelle diapositive en utilisant son ID ou son index.
1. Récupérez l’image vignette de la diapositive référencée avec les limites de la forme comme apparence.
1. Enregistrez l’image vignette dans le format d’image souhaité.

L’exemple ci‑dessous crée une vignette avec un facteur d’échelle défini par l’utilisateur.
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


## **FAQ**

**Quels formats d’image peuvent être utilisés lors de l’enregistrement des vignettes de forme ?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/), et d’autres. Les formes peuvent également être [exportées en SVG vectoriel](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) en enregistrant le contenu de la forme au format SVG.

**Quelle est la différence entre les limites Shape et Appearance lors du rendu d’une vignette ?**

`Shape` utilise la géométrie de la forme ; `Appearance` prend en compte les [effets visuels](/slides/fr/cpp/shape-effect/) (ombres, lueurs, etc.).

**Que se passe‑t‑il si une forme est marquée comme cachée ? Sera‑t‑elle tout de même rendue en vignette ?**

Une forme cachée reste partie du modèle et peut être rendue ; le drapeau caché affecte l’affichage du diaporama mais n’empêche pas la génération de l’image de la forme.

**Les formes groupées, graphiques, SmartArt et autres objets complexes sont‑ils pris en charge ?**

Oui. Tout objet représenté comme [Shape](https://reference.aspose.com/slides/cpp/aspose.slides/shape/) (y compris [GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/), et [SmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/)) peut être enregistré en vignette ou en SVG.

**Les polices installées sur le système affectent‑elles la qualité des vignettes pour les formes de texte ?**

Oui. Vous devez [fournir les polices requises](/slides/fr/cpp/custom-font/) (ou [configurer les substitutions de polices](/slides/fr/cpp/font-substitution/)) pour éviter les substitutions indésirables et le remaniement du texte.