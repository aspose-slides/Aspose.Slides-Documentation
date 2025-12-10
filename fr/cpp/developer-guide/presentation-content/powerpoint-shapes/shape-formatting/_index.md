---
title: Formater les formes PowerPoint en C++
linktitle: Mise en forme des formes
type: docs
weight: 20
url: /fr/cpp/shape-formatting/
keywords:
- format de forme
- format de ligne
- format de style de jointure
- remplissage en dégradé
- remplissage de motif
- remplissage d'image
- remplissage de texture
- remplissage de couleur unie
- transparence de forme
- rotation de forme
- effet de biseau 3D
- effet de rotation 3D
- réinitialiser le formatage
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à formater les formes PowerPoint en C++ avec Aspose.Slides — définissez les styles de remplissage, de ligne et d'effet pour les fichiers PPT, PPTX et ODP avec précision et un contrôle total."
---

## **Vue d'ensemble**

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Les formes étant constituées de lignes, vous pouvez les mettre en forme en modifiant ou en appliquant des effets à leurs contours. De plus, vous pouvez mettre en forme les formes en spécifiant des paramètres qui contrôlent la manière dont leurs intérieurs sont remplis.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ fournit des interfaces et des méthodes qui permettent de mettre en forme les formes en utilisant les mêmes options disponibles dans PowerPoint.

## **Formater les lignes**

Avec Aspose.Slides, vous pouvez spécifier un style de ligne personnalisé pour une forme. Les étapes suivantes décrivent la procédure :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [line style](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) de la forme.
1. Définissez la largeur de la ligne.
1. Définissez le [dash style](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) de la ligne.
1. Définissez la couleur de la ligne pour la forme.
1. Enregistrez la présentation modifiée au format PPTX.

Le code suivant montre comment formater un `AutoShape` rectangle :
```cpp
// Instanciez la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Récupérez la première diapositive.
auto slide = presentation->get_Slide(0);

// Ajoutez une forme auto de type Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Définissez la couleur de remplissage pour la forme rectangle.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Appliquez le formatage aux lignes du rectangle.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Définissez la couleur de la ligne du rectangle.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Enregistrez le fichier PPTX sur le disque.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Le résultat :

![Les lignes formatées dans la présentation](formatted-lines.png)

## **Formater les styles de jointure**

Voici les trois options de type de jointure :

* Round
* Miter
* Bevel

Par défaut, lorsque PowerPoint joint deux lignes à un angle (par exemple au coin d’une forme), il utilise le réglage **Round**. Cependant, si vous dessinez une forme avec des angles vifs, vous pouvez préférer l’option **Miter**.

![Le style de jointure dans la présentation](join-style-powerpoint.png)

Le code C++ suivant montre comment trois rectangles (comme indiqué sur l’image ci‑dessus) ont été créés en utilisant les réglages de jointure Miter, Bevel et Round :
```cpp
// Instanciez la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Récupérez la première diapositive.
auto slide = presentation->get_Slide(0);

// Ajoutez trois formes automatiques de type Rectangle.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Définissez la couleur de remplissage pour chaque forme rectangle.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Définissez la largeur de la ligne.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Définissez la couleur de la ligne de chaque rectangle.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Définissez le style de jointure.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Ajoutez du texte à chaque rectangle.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Enregistrez le fichier PPTX sur le disque.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Remplissage en dégradé**

Dans PowerPoint, le remplissage en dégradé est une option de mise en forme qui vous permet d’appliquer un mélange continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus de façon à ce que l’une s’estompe progressivement dans l’autre.

Voici comment appliquer un remplissage en dégradé à une forme avec Aspose.Slides :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) de la forme sur `Gradient`.
1. Ajoutez vos deux couleurs préférées avec des positions définies en utilisant les méthodes `Add` de la collection de points d’arrêt de dégradé exposée par l’interface [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/).
1. Enregistrez la présentation modifiée au format PPTX.

Le code C++ suivant montre comment appliquer un effet de remplissage en dégradé à une ellipse :
```cpp
// Instanciez la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Récupérez la première diapositive.
auto slide = presentation->get_Slide(0);

// Ajoutez une forme auto de type Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Appliquez un formatage de dégradé à l'ellipse.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Définissez la direction du dégradé.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Ajoutez deux points d'arrêt du dégradé.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Enregistrez le fichier PPTX sur le disque.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Le résultat :

![L’ellipse avec remplissage en dégradé](gradient-fill.png)

## **Remplissage de motif**

Dans PowerPoint, le remplissage de motif est une option de mise en forme qui vous permet d’appliquer un motif bicolore—tel que des points, rayures, croisillons ou carreaux—à une forme. Vous pouvez choisir des couleurs personnalisées pour le premier plan et l’arrière‑plan du motif.

Aspose.Slides propose plus de 45 styles de motifs prédéfinis que vous pouvez appliquer aux formes pour améliorer l’apparence visuelle de vos présentations. Même après avoir sélectionné un motif prédéfini, vous pouvez toujours spécifier les couleurs exactes à utiliser.

Voici comment appliquer un remplissage de motif à une forme avec Aspose.Slides :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) de la forme sur `Pattern`.
1. Choisissez un style de motif parmi les options prédéfinies.
1. Définissez la [Background Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) du motif.
1. Définissez la [Foreground Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) du motif.
1. Enregistrez la présentation modifiée au format PPTX.

Le code C++ suivant montre comment appliquer un remplissage de motif à un rectangle :
```cpp
// Instanciez la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Récupérez la première diapositive.
auto slide = presentation->get_Slide(0);

// Ajoutez une forme auto de type Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Définissez le type de remplissage sur Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Définissez le style du motif.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Définissez les couleurs d'arrière-plan et de premier plan du motif.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Enregistrez le fichier PPTX sur le disque.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Le résultat :

![Le rectangle avec remplissage de motif](pattern-fill.png)

## **Remplissage d’image**

Dans PowerPoint, le remplissage d’image est une option de mise en forme qui vous permet d’insérer une image à l’intérieur d’une forme—utilisant ainsi l’image comme arrière‑plan de la forme.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage d’image à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) de la forme sur `Picture`.
1. Définissez le mode de remplissage d’image sur `Tile` (ou tout autre mode préféré).
1. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) à partir de l’image que vous souhaitez utiliser.
1. Passez l’image à la méthode `ISlidesPicture.set_Image`.
1. Enregistrez la présentation modifiée au format PPTX.

Supposons que nous ayons un fichier “lotus.png” avec l’image suivante :

![L’image lotus](lotus.png)

Le code C++ suivant montre comment remplir une forme avec l’image :
```cpp
// Instanciez la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Récupérez la première diapositive.
auto slide = presentation->get_Slide(0);

// Ajoutez une forme auto de type Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Définissez le type de remplissage sur Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Définissez le mode de remplissage d'image.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Chargez une image et ajoutez‑la aux ressources de la présentation.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Définissez l'image.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Enregistrez le fichier PPTX sur le disque.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```



Le résultat :

![La forme avec remplissage d’image](picture-fill.png)

### **Image en mosaïque comme texture**

Si vous souhaitez définir une image en mosaïque comme texture et personnaliser le comportement du carrelage, vous pouvez utiliser les méthodes suivantes de l’interface [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) et de la classe [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) :

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): définit le mode de remplissage d’image—`Tile` ou `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): spécifie l’alignement des carreaux dans la forme.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): contrôle si le carreau est retourné horizontalement, verticalement ou les deux.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): définit le décalage horizontal du carreau (en points) par rapport à l’origine de la forme.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): définit le décalage vertical du carreau (en points) par rapport à l’origine de la forme.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): définit l’échelle horizontale du carreau en pourcentage.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): définit l’échelle verticale du carreau en pourcentage.

Le fragment de code suivant montre comment ajouter une forme rectangulaire avec un remplissage d’image en mosaïque et configurer les options de mosaïquage :
```cpp
// Instanciez la classe Presentation qui représente un fichier de presentation.
auto presentation = MakeObject<Presentation>();

// Recuperez la premiere diapositive.
auto firstSlide = presentation->get_Slide(0);

// Ajoutez une forme auto de type Rectangle.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Definissez le type de remplissage de la forme sur Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Chargez l'image et ajoutez-la aux ressources de la presentation.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Assignez l'image a la forme.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Configurez le mode de remplissage d'image et les proprietes de mosaïquage.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Enregistrez le fichier PPTX sur le disque.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Le résultat :

![Les options de mosaïquage](tile-options.png)

## **Remplissage de couleur unie**

Dans PowerPoint, le remplissage de couleur unie est une option de mise en forme qui remplit une forme avec une seule couleur uniforme. Cette couleur d’arrière‑plan simple est appliquée sans dégradés, textures ou motifs.

Pour appliquer un remplissage de couleur unie à une forme avec Aspose.Slides, suivez les étapes suivantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) de la forme sur `Solid`.
1. Attribuez la couleur de remplissage souhaitée à la forme.
1. Enregistrez la présentation modifiée au format PPTX.

Le code C++ suivant montre comment appliquer un remplissage de couleur unie à un rectangle dans une diapositive PowerPoint :
```cpp
// Instanciez la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Récupérez la première diapositive.
auto slide = presentation->get_Slide(0);

// Ajoutez une forme auto de type Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Définissez le type de remplissage sur Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Définissez la couleur de remplissage.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Enregistrez le fichier PPTX sur le disque.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Le résultat :

![La forme avec remplissage de couleur unie](solid-color-fill.png)

## **Définir la transparence**

Dans PowerPoint, lorsque vous appliquez un remplissage de couleur unie, de dégradé, d’image ou de texture à des formes, vous pouvez également définir un niveau de transparence pour contrôler l’opacité du remplissage. Une valeur de transparence plus élevée rend la forme plus translucide, laissant le fond ou les objets sous‑jacent partiellement visibles.

Aspose.Slides vous permet de définir le niveau de transparence en ajustant la valeur alpha de la couleur utilisée pour le remplissage. Voici comment procéder :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) sur `Solid`.
1. Utilisez `Color` pour définir une couleur avec transparence (le composant `alpha` contrôle la transparence).
1. Enregistrez la présentation.

Le code C++ suivant montre comment appliquer une couleur de remplissage transparente à un rectangle :
```cpp
// Instanciez la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Récupérez la première diapositive.
auto slide = presentation->get_Slide(0);

// Ajoutez une forme auto rectangle solide.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Ajoutez une forme auto rectangle transparente au-dessus de la forme solide.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Enregistrez le fichier PPTX sur le disque.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Le résultat :

![La forme transparente](shape-transparency.png)

## **Faire pivoter les formes**

Aspose.Slides vous permet de faire pivoter les formes dans les présentations PowerPoint. Cela peut être utile pour positionner des éléments visuels avec des exigences spécifiques d’alignement ou de conception.

Pour faire pivoter une forme sur une diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Définissez la propriété de rotation de la forme sur l’angle souhaité.
1. Enregistrez la présentation.

Le code C++ suivant montre comment faire pivoter une forme de 5 degrés :
```cpp
// Instanciez la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Récupérez la première diapositive.
auto slide = presentation->get_Slide(0);

// Ajoutez une forme auto de type Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Faites pivoter la forme de 5 degrés.
shape->set_Rotation(5);

// Enregistrez le fichier PPTX sur le disque.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Le résultat :

![La rotation de la forme](shape-rotation.png)

## **Ajouter des effets de biseau 3D**

Aspose.Slides vous permet d’appliquer des effets de biseau 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/).

Pour ajouter des effets de biseau 3D à une forme, suivez ces étapes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Configurez le [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) de la forme pour définir les paramètres de biseau.
1. Enregistrez la présentation.

Le code C++ suivant montre comment appliquer des effets de biseau 3D à une forme :
```cpp
// Créez une instance de la classe Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Ajoutez une forme à la diapositive.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Set the shape's ThreeDFormat properties.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Enregistrez la présentation au format PPTX.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Le résultat :

![L’effet de biseau 3D](3D-bevel-effect.png)

## **Ajouter des effets de rotation 3D**

Aspose.Slides vous permet d’appliquer des effets de rotation 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/).

Pour appliquer une rotation 3D à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Utilisez [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) et [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) pour définir la rotation 3D.
1. Enregistrez la présentation.

Le code C++ suivant montre comment appliquer des effets de rotation 3D à une forme :
```cpp
// Créez une instance de la classe Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Enregistrez la présentation au format PPTX.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Le résultat :

![L’effet de rotation 3D](3D-rotation-effect.png)

## **Réinitialiser la mise en forme**

Le code C++ suivant montre comment réinitialiser la mise en forme d’une diapositive et revenir aux positions, tailles et mises en forme par défaut de toutes les formes contenant des espaces réservés sur le [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) :
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Réinitialiser chaque forme sur la diapositive qui possède un espace réservé sur la mise en page.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **FAQ**

**Le formatage des formes affecte‑t‑il la taille finale du fichier de présentation ?**

Seulement de manière minime. Les images et les médias incorporés occupent la majeure partie de l’espace du fichier, tandis que les paramètres de forme tels que les couleurs, les effets et les dégradés sont stockés comme métadonnées et n’ajoutent pratiquement aucune taille supplémentaire.

**Comment puis‑je détecter les formes d’une diapositive qui partagent exactement le même formatage afin de les regrouper ?**

Comparez les propriétés de formatage clés de chaque forme — remplissage, ligne et paramètres d’effet. Si toutes les valeurs correspondantes sont identiques, considérez leurs styles comme identiques et regroupez logiquement ces formes, ce qui simplifie la gestion ultérieure des styles.

**Puis‑je enregistrer un ensemble de styles de forme personnalisés dans un fichier séparé pour les réutiliser dans d’autres présentations ?**

Oui. Enregistrez des formes d’exemple avec les styles souhaités dans un jeu de diapositives modèle ou un fichier modèle .POTX. Lors de la création d’une nouvelle présentation, ouvrez le modèle, clonez les formes stylisées dont vous avez besoin et réappliquez leur formatage là où c’est nécessaire.