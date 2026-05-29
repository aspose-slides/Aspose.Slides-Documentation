---
title: Créer des effets 3D dans les présentations avec C++
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
description: "Appliquez et rendez les effets 3D pour les formes et le texte PowerPoint en C++ avec Aspose.Slides. Configurez la caméra, l’éclairage, le matériau, l’extrusion, les remplissages et le texte 3D."
---
## **Aperçu**

Aspose.Slides for C++ peut créer, modifier, conserver et rendre le formatage 3D de type PowerPoint pour les formes et le texte. Cet article traite des effets 3D tels que la rotation, l'extrusion, les biseaux, l'éclairage, le matériau, les remplissages en dégradé ou image, et le texte 3D.

{{% alert color="primary" %}}
Cet article porte sur les effets de formatage 3D appliqués aux formes et au texte PowerPoint. Il ne traite pas de l'insertion ou de la modification de fichiers de modèle 3D autonomes. Lorsque vous exportez une diapositive vers une image, un PDF ou du HTML, Aspose.Slides rend ces effets 3D dans la sortie 2D exportée.
{{% /alert %}}

## **Concepts de formatage 3D**

Utilisez la méthode [get_ThreeDFormat] de l'interface [IShape] pour appliquer un formatage 3D à une forme. Cette méthode renvoie [IThreeDFormat], qui contrôle la scène 3D pour cette forme.

Pour le texte, utilisez la méthode [get_ThreeDFormat] de l'interface [ITextFrameFormat]. Cela applique le formatage 3D au cadre de texte plutôt qu'au corps de la forme.

Les méthodes les plus importantes sont :

| Méthode | Ce qu'elle contrôle | Quand l'utiliser |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/get_camera/) | Point de vue, type de caméra prédéfini, rotation, zoom et perspective. | Faire pivoter l'objet dans l'espace 3D ou correspondre à un préréglage de rotation 3D de PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/get_lightrig/) | Préréglage de lumière, direction et rotation de la lumière. | Modifier l'apparence des reflets et des ombres sur la surface 3D. |
| [set_Material](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/set_material/) | Matériau de surface, comme plat, mat, plastique ou métal. | Rendre la même géométrie plus plate, plus douce, brillante ou métallique. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Distance à laquelle la forme s'étend vers l'arrière à partir de sa face avant. | Transformer une forme plate en un objet 3D visiblement épais. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Couleur des côtés extrudés. | Rendre la profondeur visible ou coordonner la couleur des côtés avec le remplissage avant. |
| [set_Depth](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/set_depth/) | Profondeur 3D supplémentaire utilisée par le formatage 3D de PowerPoint. | Affiner la profondeur pour les formes ou le texte, notamment avec les paramètres de biseau et de matériau. |
| [get_BevelTop](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/get_beveltop/) et [get_BevelBottom](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Bords relevés ou arrondis sur les faces avant et arrière. | Ajouter un bord adouci ou moulé au lieu d'une face plane et tranchante. |
| [get_ContourColor](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/get_contourcolor/) et [set_ContourWidth](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Contour autour de l'objet 3D. | Mettre en évidence les limites de l'objet dans le rendu. |

## **Créer une forme 3D**

Une forme nécessite généralement quatre sortes de paramètres avant d'apparaître de manière convaincante en 3D :

- Paramètres de la caméra, car la vue frontale par défaut peut masquer l'extrusion.
- Paramètres d'éclairage, car l'éclairage rend les faces et les côtés lisibles.
- Paramètres de matériau, car la surface influence le rendu de la lumière.
- Paramètres d'extrusion ou de profondeur, car une forme plate a besoin d'épaisseur.

L'exemple suivant crée un rectangle, ajoute du texte à sa face avant, applique le formatage 3D, enregistre la présentation au format PPTX et rend la diapositive en image PNG.

```cpp
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

Dans PowerPoint, la rotation 3D est configurée à partir du volet Rotation 3-D. Les valeurs de rotation X, Y et Z correspondent à la rotation que vous définissez via l'API de la caméra.

![Volet Rotation 3-D de PowerPoint avec les valeurs de rotation X, Y et Z mises en évidence](img_02_01.png)

Dans Aspose.Slides, définissez le type de caméra et la rotation via [IThreeDFormat] :

```cpp
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

Utilisez la caméra lorsque vous devez modifier la façon dont le spectateur voit l'objet. Cela ne modifie pas la géométrie 2D de la forme sur la diapositive. Cela change le point de vue 3D utilisé par PowerPoint et par Aspose.Slides lors du rendu.

## **Ajouter une extrusion et une profondeur**

L'extrusion rend une forme épaisse en l'étendant derrière la face avant. Dans PowerPoint, le contrôle de profondeur définit cette épaisseur visible, et le contrôle de couleur définit la couleur des faces latérales.

![Contrôles de profondeur de PowerPoint associés aux propriétés couleur d'extrusion et hauteur d'extrusion](img_02_02.png)

Définissez [set_ExtrusionHeight] pour l'épaisseur et [get_ExtrusionColor] pour la couleur des côtés :

```cpp
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Utilisez [set_Depth] lorsque vous devez travailler directement avec la valeur de profondeur de PowerPoint ou combiner la profondeur avec le biseau, le matériau et les effets de texte. Dans de nombreux scénarios de formes, `set_ExtrusionHeight` est le réglage le plus clair car il exprime directement l'extrusion visible.

## **Utiliser des remplissages en dégradé ou image avec des effets 3D**

Le formatage 3D est indépendant du remplissage de la forme. Vous pouvez appliquer une couleur unie, un dégradé, un motif ou un remplissage image à la face avant tout en conservant les mêmes paramètres de caméra, lumière, matériau et extrusion.

Cet exemple applique un remplissage en dégradé à la forme et une couleur d'extrusion plus foncée aux côtés :

```cpp
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

Le rendu conserve le dégradé sur la face avant et rend l'extrusion séparément :

![Rectangle 3D rendu avec un remplissage dégradé du bleu à l'orange et une extrusion orange](img_02_03.png)

Pour utiliser un remplissage image à la place, ajoutez l'image à la présentation et affectez‑la au remplissage de la forme :

```cpp
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

L'image est rendue sur la face avant, tandis que l'extrusion est rendue comme la surface latérale 3D :

![Rectangle 3D rendu avec un remplissage photo sur la face avant et une extrusion orange](img_02_04.png)

## **Appliquer le formatage 3D au texte**

Le formatage 3D d'une forme affecte le corps de la forme. Le formatage 3D du texte affecte le cadre de texte. Cela est utile pour des effets de type WordArt où les lettres elles‑mêmes nécessitent extrusion, matériau, éclairage et paramètres de caméra.

L'exemple suivant crée du texte avec un remplissage en motif, applique une transformation WordArt et configure les paramètres 3D sur [ITextFrameFormat] :

```cpp
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

Le texte est rendu comme une lettrine 3D courbée et extrudée :

![Texte 3D rendu avec une transformation WordArt en arche, remplissage motif orange et extrusion sombre](img_02_05.png)

## **Comportement d'exportation et de rendu**

Aspose.Slides conserve le formatage 3D lors de l'enregistrement aux formats PowerPoint tels que PPTX. Lors du rendu ou de l'exportation vers des formats à mise en page fixe, la scène 3D est rasterisée ou dessinée dans la sortie sous forme de résultat 2D. Cela s'applique lorsque vous rendez des diapositives en [PNG](/slides/fr/cpp/convert-powerpoint-to-png/), exportez en [PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/), exportez en [HTML](/slides/fr/cpp/convert-powerpoint-to-html/), ou générez des images pour la [conversion vidéo](/slides/fr/cpp/convert-powerpoint-to-video/).

Gardez ces points à l'esprit :

- Les images et PDF exportés ne sont pas interactifs. L'objet ne peut pas être pivoté par le spectateur après l'exportation.
- L'apparence finale dépend de la combinaison de la caméra, du système d'éclairage, du matériau, de l'extrusion, du remplissage et du redimensionnement de la diapositive.
- Si vous devez inspecter les valeurs de formatage héritées ou basées sur le thème, lisez les [propriétés de forme effectives](/slides/fr/cpp/shape-effective-properties/).
- Certains formats de sortie ne peuvent pas stocker le formatage 3D éditable de PowerPoint. Dans ces formats, le résultat visuel est rendu plutôt que conservé comme paramètres 3D éditables.

## **FAQ**

**Aspose.Slides peut‑il créer des présentations 3D interactives ?**

Aspose.Slides crée et rend les effets 3D de PowerPoint pour les formes et le texte. Il ne rend pas les images, PDF ou pages HTML exportés interactifs sous forme de scènes 3D que le spectateur pourrait faire pivoter. Dans le format PPTX, le formatage 3D reste modifiable dans PowerPoint lorsque le format le prend en charge.

**Quelle est la différence entre un modèle 3D et un effet 3D ?**

Un modèle 3D est un objet 3D distinct inséré dans une présentation. Un effet 3D est un formatage appliqué à une forme ou à du texte PowerPoint standard, comme la rotation, l'extrusion, le biseau, l'éclairage et le matériau. Cet article traite des effets 3D.

**Quels paramètres sont requis pour une forme 3D visible ?**

Au minimum, définissez une rotation de caméra et soit l'extrusion, soit la profondeur. En pratique, définissez également un système d'éclairage et un matériau afin que les faces rendues présentent des reflets et des ombres nets.

**Puis‑je appliquer des effets 3D aux formes et au texte ?**

Oui. Utilisez [IShape] pour le corps de la forme et [ITextFrameFormat] pour le texte.

**Les effets 3D apparaîtront‑ils lors de l'exportation vers des images, PDF, HTML ou des images vidéo ?**

Oui. Aspose.Slides rend les effets 3D lors de la génération d'images de diapositives, de la sortie PDF, de la sortie HTML et des images utilisées pour la conversion vidéo. La sortie exportée contient l'apparence rendue, pas un objet 3D éditable.

**Puis‑je lire les valeurs finales 3D après l'application de l'héritage et des paramètres de thème ?**

Oui. Utilisez les API de formatage effectif décrites dans [Shape Effective Properties] pour lire les valeurs finales de caméra, de système d'éclairage, de biseau et les valeurs 3D associées.