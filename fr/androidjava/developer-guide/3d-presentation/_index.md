---
title: Présentation 3D
type: docs
weight: 232
url: /androidjava/3d-presentation/
keywords:
- 3D
- PowerPoint 3D
- présentation 3D
- rotation 3D
- profondeur 3D
- extrusion 3D
- dégradé 3D
- texte 3D
- présentation PowerPoint
- Android
- Aspose.Slides pour Android via Java
description: "Présentation PowerPoint 3D sur Android"
---

## Aperçu
Depuis Aspose.Slides Java 20.9, il est possible de créer des 3D dans les présentations. PowerPoint 3D est un moyen de donner vie aux présentations. Montrez des objets du monde réel avec une présentation 3D, démontrez un modèle 3D de votre futur projet d'affaires, un modèle 3D du bâtiment ou de son intérieur, un modèle 3D d'un personnage de jeu, ou simplement une représentation 3D de vos données.

Les modèles 3D PowerPoint peuvent être créés à partir de formes 2D, en appliquant des effets tels que : rotation 3D, profondeur 3D et extrusion, dégradé 3D, texte 3D, etc. La liste des fonctionnalités 3D appliquées aux formes peut être trouvée dans la classe **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)**. L'instance de la classe peut être obtenue par :

- La méthode **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getThreeDFormat--)** pour créer un modèle 3D PowerPoint.
- La méthode **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getThreeDFormat--)** pour créer un texte 3D (WordArt).

Tous les effets mis en œuvre dans **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)** peuvent être utilisés tant pour les formes que pour le texte. Jetons un coup d'œil rapide aux principales méthodes de la classe **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)**. Dans l'exemple suivant, nous créons une forme rectangulaire 2D avec un texte dessus. En obtenant la vue de la caméra sur la forme, nous changeons sa rotation et la faisons ressembler à un modèle 3D. En réglant une lumière plate et sa direction vers le sommet du modèle 3D, nous apportons plus de volume au modèle. Des matériaux, une hauteur d'extrusion et une couleur modifiés rendent le modèle 3D plus vivant.  
``` java 
final float imageScale = 2;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getTextFrame().setText("3D");
shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();

presentation.save("sandbox_3d.pptx", SaveFormat.Pptx);
presentation.dispose();
```

Voici le modèle 3D résultant :

![todo:image_alt_text](img_01_01.png)

## Rotation 3D
La rotation du modèle 3D dans PowerPoint peut se faire via le menu :

![todo:image_alt_text](img_02_01.png)

Pour faire tourner un modèle 3D avec l'API Aspose.Slides, utilisez la méthode **[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getCamera--)**, définissez la rotation de la caméra par rapport à la forme 3D :

``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... définir d'autres paramètres de scène 3D

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

## Profondeur et Extrusion 3D
Les méthodes **[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getExtrusionHeight--)** et **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getExtrusionColor--)** sont utilisées pour créer une extrusion sur une forme :

``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
// ... définir d'autres paramètres de scène 3D

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

Dans PowerPoint, la profondeur de la forme est réglée via :

![todo:image_alt_text](img_02_02.png)

## Dégradé 3D
Le dégradé 3D peut apporter plus de volume à la forme 3D PowerPoint :

``` java
final float imageScale = 2;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.getTextFrame().setText("3D");
shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

shape.getFillFormat().setFillType(FillType.Gradient);
shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();

presentation.dispose();
```

Voilà à quoi cela ressemble :

![todo:image_alt_text](img_02_03.png)
  
Vous pouvez également créer un dégradé d'image :
``` java
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
// ... configurer 3D : shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* propriétés

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

Voici le résultat :

![todo:image_alt_text](img_02_04.png)

## Texte 3D (WordArt)
Pour créer un texte 3D (WordArt), procédez comme suit :
``` java
final float imageScale = 2;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getFillFormat().setFillType(FillType.NoFill);
shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
shape.getTextFrame().setText("Texte 3D");

Portion portion = (Portion)shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
// définir l'effet de transformation "Arc vers le Hauteur"
textFrameFormat.setTransform(TextShapeType.ArchUp);

textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
textFrameFormat.getThreeDFormat().setDepth(3);
textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("text3d.png", ImageFormat.Png);
thumbnail.dispose();

presentation.save("text3d.pptx", SaveFormat.Pptx);
presentation.dispose();
```

Voici le résultat :

![todo:image_alt_text](img_02_05.png)

## Non pris en charge - À venir
Les fonctionnalités 3D suivantes de PowerPoint ne sont pas encore prises en charge : 
- Bisel
- Matériau
- Contour
- Éclairage