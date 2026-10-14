---
title: "Formater les formes PowerPoint en C++"
linktitle: "Mise en forme des formes"
type: docs
weight: 20
url: /fr/cpp/shape-formatting/
keywords:
- format de forme
- format de ligne
- effet de croquis
- ligne de forme en croquis
- format du style de jointure
- remplissage en dégradé
- remplissage de motif
- remplissage d'image
- remplissage de texture
- remplissage couleur unie
- transparence de forme
- rendu noir et blanc de la forme
- rendu en niveaux de gris de la forme
- rotation de forme
- effet de biseau 3D
- effet de rotation 3D
- réinitialiser le formatage
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à formater les formes PowerPoint en C++ avec Aspose.Slides — définissez les styles de remplissage, de ligne et d’effet pour les fichiers PPT, PPTX et ODP avec précision et contrôle total."
---
## **Introduction**

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Comme les formes sont composées de lignes, vous pouvez les mettre en forme en modifiant ou en appliquant des effets à leurs contours. De plus, vous pouvez mettre en forme les formes en spécifiant des paramètres qui contrôlent la façon dont leurs intérieurs sont remplis.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ fournit des interfaces et des méthodes qui vous permettent de mettre en forme les formes en utilisant les mêmes options disponibles dans PowerPoint.

## **Format des lignes**

Avec Aspose.Slides, vous pouvez spécifier un style de ligne personnalisé pour une forme. Les étapes suivantes décrivent la procédure :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Définir le [style de ligne](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) de la forme.
1. Définir la largeur de la ligne.
1. Définir le [style de tirets](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) de la ligne.
1. Définir la couleur de ligne pour la forme.
1. Enregistrer la présentation modifiée au format PPTX.

Le code suivant montre comment formater un rectangle `AutoShape` :

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instancier la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Obtenir la première diapositive.
auto slide = presentation->get_Slide(0);

// Ajouter une forme auto du type Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Définir la couleur de remplissage pour la forme rectangle.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Appliquer le formatage aux lignes du rectangle.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Définir la couleur de la ligne du rectangle.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Enregistrer le fichier PPTX sur le disque.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![The formatted lines in the presentation](formatted-lines.png)

## **Appliquer des effets de croquis aux lignes de forme**

Un effet de croquis rend la ligne d’une forme semblable à un trait dessiné à la main. Utilisez [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) pour accéder aux paramètres de ligne, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) pour accéder aux paramètres du croquis, et [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) pour sélectionner une valeur dans l’énumération [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/).

Le code C++ suivant montre comment appliquer un effet [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) , lire la valeur explicitement assignée et supprimer l’effet avec [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) :

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Apply a sketch effect.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Read the sketch effect assigned directly to the shape.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Remove the sketch effect.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

La valeur retournée par [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) représente le paramètre attribué directement à la forme. Si le formatage de la ligne peut être hérité d’un thème, d’une diapositive maîtresse ou d’une diapositive de mise en page, utilisez [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/), accédez à [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/), et lisez [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). La valeur effective reflète le formatage réellement appliqué après résolution de l’héritage :

```cpp
auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto lineFormat = shape->get_LineFormat();

auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);

presentation->Dispose();
```

## **Formater les styles de jointure**

Voici les trois options de type de jointure :

* Arrondi
* Biseau
* Chanfrein

Par défaut, lorsque PowerPoint joint deux lignes à un angle (par exemple au coin d’une forme), il utilise le paramètre **Arrondi**. Cependant, si vous dessinez une forme avec des angles prononcés, vous pouvez préférer l’option **Biseau**.

![The join style in the presentation](join-style-powerpoint.png)

Le code C++ suivant démontre comment trois rectangles (comme illustré sur l’image ci‑above) ont été créés en utilisant les paramètres de jointure Miter, Bevel et Round :

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instancier la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Obtenir la première diapositive.
auto slide = presentation->get_Slide(0);

// Ajouter trois formes auto du type Rectangle.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Définir la couleur de remplissage pour chaque forme rectangle.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Définir la largeur de la ligne.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Définir la couleur de la ligne de chaque rectangle.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Définir le style de jointure.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Ajouter du texte à chaque rectangle.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Enregistrer le fichier PPTX sur le disque.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Remplissage en dégradé**

Dans PowerPoint, le remplissage en dégradé est une option de formatage qui vous permet d’appliquer un mélange continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus de façon à ce que l’une s’estompe progressivement dans l’autre.

Voici comment appliquer un remplissage en dégradé à une forme en utilisant Aspose.Slides :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) de la forme sur `Gradient`.
1. Ajouter vos deux couleurs préférées avec des positions définies en utilisant les méthodes `Add` de la collection d’arrêts de dégradé exposée par l’interface [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/).
1. Enregistrer la présentation modifiée au format PPTX.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instancier la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Obtenir la première diapositive.
auto slide = presentation->get_Slide(0);

// Ajouter une forme auto du type Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Appliquer le formatage du dégradé à l'ellipse.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Définir la direction du dégradé.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Ajouter deux arrêts de dégradé.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Enregistrer le fichier PPTX sur le disque.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![The ellipse with gradient fill](gradient-fill.png)

Si un dégradé apparaît différemment dans une image exportée que dans PowerPoint, consultez [Choisir un style de rendu du dégradé](/slides/fr/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Vous pouvez sélectionner un style de rendu sans modifier le remplissage en dégradé stocké dans la présentation.

## **Remplissage de motif**

Dans PowerPoint, le remplissage de motif est une option de formatage qui vous permet d’appliquer un motif bicolore — comme des points, des bandes, des croisillons ou des damiers — à une forme. Vous pouvez choisir des couleurs personnalisées pour le premier plan et l’arrière‑plan du motif.

Aspose.Slides propose plus de 45 styles de motif prédéfinis que vous pouvez appliquer aux formes pour améliorer l’attrait visuel de vos présentations. Même après avoir sélectionné un motif prédéfini, vous pouvez toujours spécifier les couleurs exactes à utiliser.

Voici comment appliquer un remplissage de motif à une forme en utilisant Aspose.Slides :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) de la forme sur `Pattern`.
1. Choisir un style de motif parmi les options prédéfinies.
1. Définir la [Background Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) du motif.
1. Définir la [Foreground Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) du motif.
1. Enregistrer la présentation modifiée au format PPTX.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instancier la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Obtenir la première diapositive.
auto slide = presentation->get_Slide(0);

// Ajouter une forme auto du type Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Définir le type de remplissage sur Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Définir le style de motif.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Définir les couleurs d'arrière-plan et de premier plan du motif.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Enregistrer le fichier PPTX sur le disque.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![The rectangle with pattern fill](pattern-fill.png)

## **Remplissage d'image**

Dans PowerPoint, le remplissage d'image est une option de formatage qui vous permet d’insérer une image à l’intérieur d’une forme — en utilisant effectivement l’image comme arrière‑plan de la forme.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage d'image à une forme :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) de la forme sur `Picture`.
1. Définir le mode de remplissage d’image sur `Tile` (ou un autre mode préféré).
1. Créer un objet [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) à partir de l’image que vous souhaitez utiliser.
1. Passer l’image à la méthode `ISlidesPicture.set_Image`.
1. Enregistrer la présentation modifiée au format PPTX.

![The lotus picture](lotus.png)

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instancier la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Obtenir la première diapositive.
auto slide = presentation->get_Slide(0);

// Ajouter une forme auto du type Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Définir le type de remplissage sur Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Définir le mode de remplissage d'image.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Charger une image et l'ajouter aux ressources de la présentation.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Définir l'image.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Enregistrer le fichier PPTX sur le disque.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Le résultat :

![The shape with picture fill](picture-fill.png)

### **Image en mosaïque comme texture**

Si vous souhaitez définir une image en mosaïque comme texture et personnaliser le comportement de la mosaïque, vous pouvez utiliser les méthodes suivantes de l’interface [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) et de la classe [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) :

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) : Définit le mode de remplissage d’image — soit `Tile` soit `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/) : Spécifie l’alignement des tuiles à l’intérieur de la forme.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/) : Contrôle si la tuile est retournée horizontalement, verticalement, ou les deux.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/) : Définit le décalage horizontal de la tuile (en points) depuis l’origine de la forme.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/) : Définit le décalage vertical de la tuile (en points) depuis l’origine de la forme.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/) : Définit l’échelle horizontale de la tuile en pourcentage.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/) : Définit l’échelle verticale de la tuile en pourcentage.

Le code d’exemple suivant montre comment ajouter une forme rectangle avec un remplissage d’image en mosaïque et configurer les options de mosaïque :

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instancier la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Obtenir la première diapositive.
auto firstSlide = presentation->get_Slide(0);

// Ajouter une forme auto rectangle.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Définir le type de remplissage de la forme sur Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Charger l'image et l'ajouter aux ressources de la présentation.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Assigner l'image à la forme.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Configurer le mode de remplissage d'image et les propriétés de mosaïquage.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Enregistrer le fichier PPTX sur le disque.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![The tile options](tile-options.png)

## **Remplissage couleur unie**

Dans PowerPoint, le remplissage couleur unie est une option de formatage qui remplit une forme avec une couleur unique et uniforme. Cette couleur de fond simple est appliquée sans aucun dégradé, texture ou motif.

Pour appliquer un remplissage couleur unie à une forme en utilisant Aspose.Slides, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) de la forme sur `Solid`.
1. Assigner votre couleur de remplissage préférée à la forme.
1. Enregistrer la présentation modifiée au format PPTX.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instancier la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Obtenir la première diapositive.
auto slide = presentation->get_Slide(0);

// Ajouter une forme auto du type Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Définir le type de remplissage sur Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Définir la couleur de remplissage.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Enregistrer le fichier PPTX sur le disque.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![The shape with solid color fill](solid-color-fill.png)

## **Définir la transparence**

Dans PowerPoint, lorsque vous appliquez un remplissage couleur unie, un dégradé, une image ou une texture à des formes, vous pouvez également définir un niveau de transparence pour contrôler l’opacité du remplissage. Une valeur de transparence plus élevée rend la forme plus translucide, permettant au fond ou aux objets sous‑jacent d’être partiellement visibles.

Aspose.Slides vous permet de définir le niveau de transparence en ajustant la composante alpha de la couleur utilisée pour le remplissage. Voici comment faire :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) sur `Solid`.
1. Utiliser `Color` pour définir une couleur avec transparence (la composante `alpha` contrôle la transparence).
1. Enregistrer la présentation.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instancier la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Obtenir la première diapositive.
auto slide = presentation->get_Slide(0);

// Ajouter une forme auto rectangle solide.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Ajouter une forme auto rectangle transparent au-dessus de la forme solide.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Enregistrer le fichier PPTX sur le disque.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![The transparent shape](shape-transparency.png)

## **Faire pivoter les formes**

Aspose.Slides vous permet de faire pivoter des formes dans les présentations PowerPoint. Cela peut être utile lors du positionnement d’éléments visuels nécessitant un alignement ou un design spécifiques.

Pour faire pivoter une forme sur une diapositive, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Définir la propriété de rotation de la forme à l’angle souhaité.
1. Enregistrer la présentation.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instancier la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Obtenir la première diapositive.
auto slide = presentation->get_Slide(0);

// Ajouter une forme auto du type Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Faire pivoter la forme de 5 degrés.
shape->set_Rotation(5);

// Enregistrer le fichier PPTX sur le disque.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![The shape rotation](shape-rotation.png)

## **Ajouter des effets de biseau 3D**

Aspose.Slides permet d’appliquer des effets de biseau 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/).

Pour ajouter des effets de biseau 3D à une forme, suivez ces étapes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Configurer le [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) de la forme pour définir les paramètres de biseau.
1. Enregistrer la présentation.

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Create an instance of the Presentation class.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Add a shape to the slide.
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

// Save the presentation as a PPTX file.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![The 3D bevel effect](3D-bevel-effect.png)

## **Ajouter des effets de rotation 3D**

Aspose.Slides permet d’appliquer des effets de rotation 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/).

Pour appliquer une rotation 3D à une forme :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) à la diapositive.
1. Utiliser [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) et [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) pour définir la rotation 3D.
1. Enregistrer la présentation.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Créer une instance de la classe Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Enregistrer la présentation au format PPTX.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![The 3D rotation effect](3D-rotation-effect.png)

## **Contrôler le rendu noir et blanc pour les formes**

La méthode [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) spécifie comment une forme individuelle est rendue lorsqu’une présentation est affichée ou traitée en mode noir et blanc. Elle n’active pas l’affichage noir et blanc en soi et ne modifie pas le remplissage, la ligne ou tout autre formatage en mode couleur normale.

Utilisez une valeur de l’énumération [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) pour sélectionner le comportement souhaité. Par exemple, `Automatic` laisse l’application de rendu choisir la conversion, `Gray` et `LightGray` utilisent le gris, `BlackWhite` n’utilise que le noir et le blanc, `Black` et `White` forcent une couleur unique, `Color` préserve les couleurs normales, et `Hidden` omet la forme en mode noir et blanc. `NotDefined` signifie qu’aucun mode au niveau de la forme n’est attribué.

Le code C++ suivant crée une forme colorée et la rend grise en mode d’affichage noir et blanc :

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

// Conserver le remplissage orange en mode couleur, mais rendre la forme en gris en mode noir et blanc.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

En mode couleur normale, le rectangle conserve son remplissage orange. En mode d’affichage noir et blanc, il utilise le gris parce que son mode est défini sur `Gray`. Cela vous permet de conserver une diapositive en couleurs complètes tout en définissant un aspect distinct pour l’impression, l’aperçu ou d’autres flux de travail qui respectent les paramètres d’affichage noir et blanc de la présentation.

## **Réinitialiser le formatage**

Le code C++ suivant montre comment réinitialiser le formatage d’une diapositive et ramener la position, la taille et le formatage de toutes les formes avec espaces réservés sur le [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) à leurs paramètres par défaut :

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    // Réinitialiser chaque forme sur la diapositive qui possède un espace réservé sur la disposition.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Le formatage des formes affecte-t-il la taille finale du fichier de présentation ?**

Seulement légèrement. Les images et les médias incorporés occupent la majeure partie de l’espace du fichier, tandis que les paramètres de forme tels que les couleurs, les effets et les dégradés sont stockés comme métadonnées et n’ajoutent pratiquement aucune taille supplémentaire.

**Comment détecter les formes d’une diapositive qui partagent un formatage identique afin de pouvoir les regrouper ?**

Comparez les propriétés clés de formatage de chaque forme — remplissage, ligne et paramètres d’effet. Si toutes les valeurs correspondantes sont identiques, considérez leurs styles comme identiques et regroupez logiquement ces formes, ce qui simplifie la gestion ultérieure des styles.

**Puis‑je enregistrer un ensemble de styles de forme personnalisés dans un fichier séparé pour les réutiliser dans d’autres présentations ?**

Oui. Stockez des formes d’exemple avec les styles souhaités dans un diaporama modèle ou un fichier modèle .POTX. Lors de la création d’une nouvelle présentation, ouvrez le modèle, clonez les formes stylisées dont vous avez besoin et réappliquez leur formatage où cela est requis.