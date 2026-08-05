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
- limites visuelles
- limites de forme
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Générez des vignettes de formes de haute qualité à partir des diapositives PowerPoint avec Aspose.Slides pour C++ - créez et exportez facilement des vignettes de présentations."
---
## **Introduction**

Aspose.Slides est utilisé pour créer des fichiers de présentation où chaque page est une diapositive. Ces diapositives peuvent être visualisées en ouvrant les fichiers de présentation avec Microsoft PowerPoint. Mais parfois, les développeurs peuvent avoir besoin de voir les images des formes séparément dans un visualiseur d'images. Dans de tels cas, Aspose.Slides vous aide à générer des images miniatures des formes de la diapositive. La façon d'utiliser cette fonctionnalité est décrite dans cet article.

Cet article explique comment générer des miniatures de diapositives de différentes manières :

- Générer une vignette de forme à l'intérieur d'une diapositive.
- Générer une vignette de forme pour une forme de diapositive avec des dimensions définies par l'utilisateur.
- Générer une vignette de forme dans les limites de l'apparence d'une forme.

## **Générer une vignette de forme à partir d'une diapositive**

Pour générer une vignette de forme à partir de n'importe quelle diapositive en utilisant Aspose.Slides pour C++ :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Obtenez la référence d'une quelconque diapositive en utilisant son ID ou son indice.
3. Obtenez l'image miniature de forme de la diapositive référencée à l'échelle par défaut.
4. Enregistrez l'image miniature dans le format d'image souhaité.

L'exemple ci-dessous génère une vignette de forme.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Générer une vignette avec facteur d'échelle défini par l'utilisateur**

Pour générer la vignette de forme de n'importe quelle forme de diapositive en utilisant Aspose.Slides pour C++ :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Obtenez la référence d'une quelconque diapositive en utilisant son ID ou son indice.
3. Obtenez l'image miniature de la diapositive référencée avec les limites de la forme.
4. Enregistrez l'image miniature dans le format d'image souhaité.

L'exemple ci-dessous génère une vignette avec un facteur d'échelle défini par l'utilisateur.

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

## **Créer une vignette d'apparence de forme basée sur les limites**

Cette méthode de création de vignettes de formes permet aux développeurs de générer une vignette dans les limites de l'apparence de la forme. Elle prend en compte tous les effets de la forme. La vignette de forme générée est limitée par les limites de la diapositive. Pour générer une vignette de n'importe quelle forme de diapositive dans les limites de son apparence, utilisez le code d'exemple suivant :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Obtenez la référence d'une quelconque diapositive en utilisant son ID ou son indice.
3. Obtenez l'image miniature de la diapositive référencée avec les limites de forme en tant qu'apparence.
4. Enregistrez l'image miniature dans le format d'image souhaité.

L'exemple ci-dessous crée une vignette en générant une vignette avec un facteur d'échelle défini par l'utilisateur.

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

## **Obtenir les limites visuelles réelles d'une forme**

Les propriétés de cadre de [IShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/)—`IShape::get_X()`, `IShape::get_Y()`, `IShape::get_Width()` et `IShape::get_Height()`—décrivent le rectangle stocké dans le modèle de présentation. Le contenu réellement rendu peut s'étendre au-delà de ce cadre ou occuper un rectangle aligné différemment. La rotation, les contours, les pointes de flèche, la mise en page et le débordement du texte, la géométrie SmartArt générée et d'autres effets de rendu peuvent tous modifier la zone occupée.

Utilisez [Shape::GetVisualBounds](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shape/getvisualbounds/) pour calculer cette zone occupée sans créer d'image. La méthode renvoie un [RectangleF](https://reference.aspose.com/slides/fr/cpp/system.drawing/rectanglef/) en coordonnées de diapositive. Le rectangle renvoyé n'est pas découpé à la diapositive, ses coordonnées peuvent donc être négatives lorsque le contenu dépasse l'origine de la diapositive.

[Shape::GetVisualBounds](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shape/getvisualbounds/) n'est pas actuellement déclaré par l'interface [IShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/). Par conséquent, conservez la forme obtenue à partir de la collection de formes de la diapositive comme une valeur d'interface et ne la convertissez qu'au moment d'appeler la méthode.

L'exemple suivant obtient et compare les limites de cadre et les limites visuelles :

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

Le même [RectangleF](https://reference.aspose.com/slides/fr/cpp/system.drawing/rectanglef/) peut être utilisé pour aligner les formes proches à son bord `RectangleF::get_Left()`, `RectangleF::get_Right()`, `RectangleF::get_Top()` ou `RectangleF::get_Bottom()` ; réserver suffisamment d'espace dans une mise en page générée ; ou détecter du contenu en dehors d'une région autorisée. Les limites visuelles sont particulièrement utiles pour SmartArt, les zones de texte, les flèches, les images, les formes tournées et les formes groupées, où le cadre stocké peut ne pas représenter le résultat rendu complet.

Utilisez [Shape::GetVisualBounds](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shape/getvisualbounds/) lorsque vous avez besoin de coordonnées pour la mise en page ou la validation et que vous n'avez pas besoin d'un bitmap. Utilisez [IShape::GetImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/getimage/) lorsque vous devez rendre la forme. Avec [ShapeThumbnailBounds](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds::Shape` dimensionne l'image à partir des limites de la forme, y compris les paramètres de contour, tandis que `ShapeThumbnailBounds::Appearance` la dimensionne à partir de l'apparence de la forme et restreint le résultat aux limites de la diapositive. En revanche, [Shape::GetVisualBounds](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shape/getvisualbounds/) ne renvoie que le rectangle calculé et ne le découpe pas à la diapositive.

## **FAQ**

**Quels formats d'image peuvent être utilisés lors de l'enregistrement des vignettes de forme ?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imageformat/), et d'autres. Les formes peuvent également être [exportées au format vectoriel SVG](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shape/writeassvg/) en enregistrant le contenu de la forme au format SVG.

**Quelle est la différence entre les limites Shape et Appearance lors du rendu d'une vignette ?**

`Shape` utilise la géométrie de la forme ; `Appearance` prend en compte les [effets visuels](/slides/fr/cpp/shape-effect/) (ombres, lueurs, etc.).

**Que se passe-t-il si une forme est marquée comme cachée ? Sera-t-elle toujours rendue en tant que vignette ?**

Une forme cachée reste faisant partie du modèle et peut être rendue ; le drapeau caché affecte l'affichage du diaporama mais n'empêche pas la génération de l'image de la forme.

**Les formes groupées, les graphiques, SmartArt et d'autres objets complexes sont-ils pris en charge ?**

Oui. Tout objet représenté comme [Shape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shape/) (y compris [GroupShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/chart/), et [SmartArt](https://reference.aspose.com/slides/fr/cpp/aspose.slides.smartart/smartart/)) peut être enregistré en tant que vignette ou en tant que SVG.

**Les polices installées sur le système affectent-elles la qualité des vignettes pour les formes de texte ?**

Oui. Vous devez [fournir les polices requises](/slides/fr/cpp/custom-font/) (ou [configurer les substitutions de polices](/slides/fr/cpp/font-substitution/)) afin d'éviter les substitutions indésirables et le réarrangement du texte.