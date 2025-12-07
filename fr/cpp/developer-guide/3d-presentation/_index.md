---
title: Créer des présentations 3D en C++
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
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Générez des présentations 3D interactives en C++ avec Aspose.Slides sans effort. Exportez rapidement aux formats PowerPoint et OpenDocument pour une utilisation polyvalente."
---

## **Vue d'ensemble**
Depuis Aspose.Slides 20.9 il est possible de créer et de modifier des modèles 3D PowerPoint. Cela peut être réalisé en appliquant à des formes 2D un ensemble d'effets 3D. En créant une vue caméra sur la forme, vous pouvez la faire pivoter autour de l'axe. Créez une extrusion ou une profondeur sur la forme, ce qui transformera la forme 2D en modèle 3D. 
Définir l'effet de lumière sur la forme 3D ou modifier les matériaux peut la rendre plus vivante. Modifier les couleurs des modèles 3D en un dégradé 3D, modifier le contour des formes, ajouter un biseau rend le modèle 3D plus volumineux. Tous les effets 3D peuvent être appliqués aux modèles 3D PowerPoint ainsi qu'aux textes.

Observons le premier exemple de création de modèles 3D, qui comprend toutes les fonctionnalités susmentionnées:
``` cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto imageScale = 2;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Matte);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_Blue());

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();

presentation->Save(u"sandbox_3d.pptx", Export::SaveFormat::Pptx);
presentation->Dispose();
```


Le modèle 3D PowerPoint résultant:
![todo:image_alt_text](img_01_01.png)

## **Rotation 3D**
Dans PowerPoint, la rotation des formes est disponible via:
![todo:image_alt_text](img_02_01.png)

Pour faire pivoter les modèles 3D PowerPoint, il faut créer une vue caméra sur la forme. Cela se fait avec la méthode [IThreeDFormat.get_Camera()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#ad2f989bd1fd64fd4136e1f17660035d4). La méthode de rotation est appelée depuis la classe caméra comme si vous faisiez pivoter la caméra. En fait, lorsque vous faites pivoter la caméra par rapport à la forme, vous faites pivoter la forme sur le plan 3D.
``` cpp
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
// ... définir d'autres paramètres de la scène 3D

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


## **Profondeur et extrusion 3D**
Pour ajouter de la profondeur et de l'extrusion à un modèle 3D PowerPoint, utilisez la méthode [IThreeDFormat.set_ExtrusionHeight()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#adf0bad4894b1c36d9e4b044ef4978295). Pour modifier la couleur de l'extrusion, utilisez la méthode [IThreeDFormat.get_ExtrusionColor()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#aa7db8859d23a9b4eb2f35f3a42025e9e) :
``` cpp
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_Purple());
// ... définir d'autres paramètres de la scène 3D

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


Menu Profondeur dans PowerPoint:
![todo:image_alt_text](img_02_02.png)


## **Dégradé 3D**
Dessiner un dégradé 3D sur un modèle 3D PowerPoint peut être fait via la méthode [Shape.get_FillFormat().get_GradientFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a1f075336cb7a0e05cd5d7a706b6f4f58):
``` cpp
using namespace Aspose::Slides;

auto imageScale = 2;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0, System::Drawing::Color::get_Blue());
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, System::Drawing::Color::get_Orange());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_DarkOrange());

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


Modèle 3D avec dégradé 3D:
![todo:image_alt_text](img_02_03.png)
  
Pour créer un dégradé d'image, utilisez la méthode [Shape.get_FillFormat().get_PictureFillFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#ac01c9a38197ddcd80c180aceeaf155cb):
``` cpp
auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
// .. configuration 3D: Caméra, LightRig, Extrusion

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


Modèle 3D avec dégradé d'image:
![todo:image_alt_text](img_02_04.png)

## **Texte 3D (WordArt)**
Pour appliquer la rotation, l'extrusion, la lumière, le dégradé sur du texte et le transformer en texte 3D (WordArt), vous devez accéder à la méthode [IAutoShape.get_TextFrame().get_TextFrameFormat().get_ThreeDFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5e681109403c2e57aa76a500fe508b30):
``` cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto imageScale = 2;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(System::Drawing::Color::get_DarkOrange());
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(System::Drawing::Color::get_White());
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
// configurer l'effet de transformation WordArt "Arch Up"

textFrameFormat->set_Transform(TextShapeType::ArchUp);

textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

textFrame->get_TextFrameFormat()->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text3d.png");
thumbnail->Dispose();

presentation->Save(u"text3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Exemple de texte 3D (WordArt):
![todo:image_alt_text](img_02_05.png)

## **FAQ**

**Les effets 3D seront-ils conservés lors de l'exportation d'une présentation vers des images/PDF/HTML ?**

Oui. Le moteur 3D de Slides rend les effets 3D lors de l'exportation vers les formats pris en charge ([images](/slides/fr/cpp/convert-powerpoint-to-png/), [PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/fr/cpp/convert-powerpoint-to-html/), etc.).

**Puis-je récupérer les valeurs « effectives » (finales) des paramètres 3D qui tiennent compte des thèmes, de l'héritage, etc. ?**

Oui. Slides propose des API pour [lire les valeurs effectives](/slides/fr/cpp/shape-effective-properties/) (y compris pour la 3D - éclairage, biseaux, etc.) afin que vous puissiez voir les paramètres finaux appliqués.

**Les effets 3D fonctionnent-ils lors de la conversion d'une présentation en vidéo ?**

Oui. Lors de la [génération des images pour la vidéo](/slides/fr/cpp/convert-powerpoint-to-video/), les effets 3D sont rendus de la même façon que pour les [images exportées](/slides/fr/cpp/convert-powerpoint-to-png/).