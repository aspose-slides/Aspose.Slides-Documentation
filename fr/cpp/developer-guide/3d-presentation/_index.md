---
title: Créer des effets 3D dans les présentations en C++
linktitle: Présentation 3D
type: docs
weight: 232
url: /fr/cpp/3d-presentation/
keywords:
- PowerPoint 3D
- présentation 3D
- rotation 3D
- profondeur 3D
- extrusion 3D
- dégradé 3D
- texte 3D
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Appliquer et rendre des effets 3D pour les formes et le texte PowerPoint en C++ avec Aspose.Slides. Configurer la caméra, l'éclairage, le matériau, l'extrusion, les remplissages et le texte 3D."
---
## **Vue d'ensemble**

Aspose.Slides for C++ peut créer, modifier, conserver et rendre le formatage 3D de style PowerPoint pour les formes et le texte. Cet article couvre les effets 3D tels que la rotation, l'extrusion, les chanfreins, l'éclairage, le matériau, les remplissages en dégradé ou image, et le texte 3D.

{{% alert color="info" %}}
Cet article porte sur les effets de formatage 3D appliqués aux formes et au texte PowerPoint. Il ne concerne pas l’insertion ou la modification de fichiers de modèle 3D autonomes. Lorsque vous exportez une diapositive vers une image, un PDF ou du HTML, Aspose.Slides rend ces effets 3D dans la sortie 2D exportée.
{{% /alert %}}

## **Concepts de formatage 3D**

Utilisez la méthode [get_ThreeDFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/get_threedformat/) de l’interface [IShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/) pour appliquer un formatage 3D à une forme. La méthode renvoie un [IThreeDFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/), qui contrôle la scène 3D pour cette forme.

Pour le texte, utilisez la méthode [get_ThreeDFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframeformat/get_threedformat/) de l’interface [ITextFrameFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframeformat/). Cela applique le formatage 3D au cadre de texte plutôt qu’au corps de la forme.

Les méthodes les plus importantes sont :

| Méthode | Ce qu'elle contrôle | Quand l'utiliser |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/get_camera/) | Point de vue, type de caméra prédéfini, rotation, zoom et perspective. | Faire pivoter l'objet dans l'espace 3D ou correspondre à un préréglage de rotation 3D de PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/get_lightrig/) | Préréglage de lumière, direction et rotation de la lumière. | Modifier l'apparition des reflets et des ombres sur la surface 3D. |
| [set_Material](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/set_material/) | Matériau de la surface, comme plat, mat, plastique ou métal. | Faire apparaître la même géométrie plus plate, plus douce, brillante ou métallique. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Distance à laquelle la forme s'étend vers l'arrière depuis sa face avant. | Transformer une forme plate en un objet 3D visiblement épais. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Couleur des côtés extrudés. | Rendre la profondeur visible ou coordonner la couleur des côtés avec le remplissage frontal. |
| [set_Depth](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/set_depth/) | Profondeur 3D supplémentaire utilisée par le formatage 3D de PowerPoint. | Ajuster finement la profondeur pour les formes ou le texte, notamment avec les réglages de chanfrein et de matériau. |
| [get_BevelTop](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/get_beveltop/) et [get_BevelBottom](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Bords relevés ou arrondis sur les faces avant et arrière. | Ajouter un bord adouci ou moulé au lieu d'une face plate et pointue. |
| [get_ContourColor](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/get_contourcolor/) et [set_ContourWidth](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Contour autour de l'objet 3D. | Mettre en évidence les limites de l'objet dans la sortie rendue. |

## **Créer une forme 3D**

Une forme nécessite généralement quatre types de paramètres avant d'apparaître de façon convaincante en 3D :

- Paramètres de la caméra, car la vue frontale par défaut peut cacher l'extrusion.  
- Paramètres de lumière, car l'éclairage rend les faces et les côtés lisibles.  
- Paramètres de matériau, car la surface influence le rendu de la lumière.  
- Paramètres d'extrusion ou de profondeur, car une forme plate nécessite de l'épaisseur.

L'exemple suivant crée un rectangle, ajoute du texte à sa face avant, applique un formatage 3D, enregistre la présentation au format PPTX et rend la diapositive en image PNG.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = System::Drawing::Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = System::Drawing::Color::get_Blue();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"shape_3d.png");
thumbnail->Dispose();

presentation->Save(u"shape_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

L'image de la diapositive rendue montre le rectangle comme un bloc 3D épais :

![Rectangle 3D bleu rendu avec texte 3D blanc sur la face avant](img_01_01.png)

## **Faire pivoter une forme avec la caméra**

Dans PowerPoint, la rotation 3D est configurée depuis le volet Rotation 3D. Les valeurs de rotation X, Y et Z correspondent à la rotation que vous définissez via l’API caméra.

![Volet Rotation 3D de PowerPoint avec les valeurs de rotation X, Y et Z mises en évidence](img_02_01.png)

Dans Aspose.Slides, définissez le type de caméra et la rotation via [IThreeDFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/) :

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
<DOM/ShapeType.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

Utilisez la caméra lorsque vous devez modifier la façon dont le spectateur voit l'objet. Cela ne modifie pas la géométrie 2D de la forme sur la diapositive. Cela change le point de vue 3D utilisé par PowerPoint et par Aspose.Slides lors du rendu.

## **Ajouter extrusion et profondeur**

L'extrusion rend une forme épaisse en l'étendant derrière la face avant. Dans PowerPoint, le contrôle de profondeur définit cette épaisseur visible, et le contrôle de couleur définit la couleur des faces latérales.

![Contrôles de profondeur de PowerPoint associés aux propriétés couleur d'extrusion et hauteur d'extrusion](img_02_02.png)

Définissez [set_ExtrusionHeight](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/set_extrusionheight/) pour l'épaisseur et [get_ExtrusionColor](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) pour la couleur des côtés :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Utilisez [set_Depth](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/set_depth/) lorsque vous devez travailler directement avec la valeur de profondeur de PowerPoint ou combiner profondeur avec les réglages de chanfrein, de matériau et d'effets de texte. Dans de nombreux scénarios de forme, `set_ExtrusionHeight` est le réglage le plus clair car il exprime directement l'extrusion visible.

## **Utiliser des remplissages en dégradé ou image avec des effets 3D**

Le formatage 3D est indépendant du remplissage de la forme. Vous pouvez appliquer une couleur unie, un dégradé, un motif ou une image à la face avant tout en conservant les mêmes réglages de caméra, lumière, matériau et extrusion.

Cet exemple applique un remplissage en dégradé à la forme et une couleur d'extrusion plus sombre aux côtés :

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = System::Drawing::Color::get_Blue();
auto secondGradientColor = System::Drawing::Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"gradient_3d.png");
thumbnail->Dispose();

presentation->Dispose();
```

Le rendu conserve le dégradé sur la face avant et rend séparément l'extrusion :

![Rectangle 3D rendu avec un remplissage en dégradé du bleu à l'orange et une extrusion orange](img_02_03.png)

Pour utiliser un remplissage image à la place, ajoutez l’image à la présentation et affectez‑la au remplissage de la forme :

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

L'image est rendue sur la face avant, tandis que l'extrusion est rendue comme surface latérale 3D :

![Rectangle 3D rendu avec un remplissage photo sur la face avant et une extrusion orange](img_02_04.png)

## **Appliquer le formatage 3D au texte**

Le formatage 3D d’une forme agit sur le corps de la forme. Le formatage 3D du texte agit sur le cadre de texte. Cela est utile pour des effets de type WordArt où les lettres elles‑mêmes ont besoin d’extrusion, de matériau, d’éclairage et de réglages de caméra.

L'exemple suivant crée du texte avec un remplissage motif, applique une transformation WordArt et configure les réglages 3D sur [ITextFrameFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframeformat/) :

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = System::Drawing::Color::get_DarkOrange();
auto backgroundColor = System::Drawing::Color::get_White();
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(foregroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(backgroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_Transform(TextShapeType::ArchUp);
textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);
textFrameFormat->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text_3d.png");
thumbnail->Dispose();

presentation->Save(u"text_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le texte est rendu comme des lettres 3D courbées et extrudées :

![Texte 3D rendu avec une transformation WordArt en arche, remplissage en motif orange et extrusion foncée](img_02_05.png)

## **Comportement d'exportation et de rendu**

Aspose.Slides conserve le formatage 3D lors de l’enregistrement aux formats PowerPoint tels que PPTX. Lors du rendu ou de l’exportation vers des formats à mise en page fixe, la scène 3D est rasterisée ou dessinée dans la sortie en tant que résultat 2D. Cela s’applique lorsque vous rendez des diapositives en [PNG](/slides/fr/cpp/convert-powerpoint-to-png/), exportez en [PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/), exportez en [HTML](/slides/fr/cpp/convert-powerpoint-to-html/), ou générez des images pour la [conversion vidéo](/slides/fr/cpp/convert-powerpoint-to-video/).

Gardez ces points à l’esprit :

- Les images et les PDF exportés ne sont pas interactifs. L'objet ne peut pas être tourné par le spectateur après l'exportation.  
- L'apparence finale dépend de la combinaison de la caméra, du dispositif d'éclairage, du matériau, de l'extrusion, du remplissage et du redimensionnement de la diapositive.  
- Si vous devez inspecter les valeurs de formatage héritées ou basées sur le thème, lisez les [propriétés de forme effectives](/slides/fr/cpp/shape-effective-properties/).  
- Certains formats de sortie ne peuvent pas stocker le formatage 3D éditable de PowerPoint. Dans ces formats, le résultat visuel est rendu plutôt que conservé comme réglages 3D éditables.

## **FAQ**

### Aspose.Slides peut-il créer des présentations 3D interactives ?

Aspose.Slides crée et rend les effets 3D PowerPoint pour les formes et le texte. Il ne rend pas les images, PDF ou pages HTML exportés interactifs ; ils ne peuvent pas être tournés par le spectateur. Dans le PPTX, le formatage 3D reste éditable dans PowerPoint lorsque le format le prend en charge.

### Quelle est la différence entre un modèle 3D et un effet 3D ?

Un modèle 3D est un objet 3D distinct inséré dans une présentation. Un effet 3D est un formatage appliqué à une forme ou à du texte PowerPoint ordinaire, tel que rotation, extrusion, chanfrein, éclairage et matériau. Cet article traite des effets 3D.

### Quels réglages sont nécessaires pour une forme 3D visible ?

Au minimum, définissez une rotation de caméra et soit l'extrusion soit la profondeur. En pratique, il faut également définir un dispositif d'éclairage et un matériau afin que les faces rendues présentent des reflets et des ombres clairs.

### Puis-je appliquer des effets 3D aux formes et au texte ?

Oui. Utilisez [IShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/) pour le corps de la forme et [ITextFrameFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframeformat/) pour le texte.

### Les effets 3D apparaîtront-ils lors de l'exportation vers des images, PDF, HTML ou des images vidéo ?

Oui. Aspose.Slides rend les effets 3D lors de la génération d’images de diapositives, de sorties PDF, HTML et des images utilisées pour la conversion vidéo. Le résultat exporté contient l’apparence rendue, pas un objet 3D éditable.

### Puis-je lire les valeurs 3D finales après l'application de l'héritage et des paramètres du thème ?

Oui. Utilisez les API de formatage effectif décrites dans [Propriétés de forme effectives](/slides/fr/cpp/shape-effective-properties/) pour lire les valeurs finales de caméra, dispositif d'éclairage, chanfrein et autres paramètres 3D.