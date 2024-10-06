---
title: Présentation 3D
type: docs
weight: 232
url: /java/3d-presentation/
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
- Java
- Aspose.Slides pour Java
description: "Présentation PowerPoint 3D en Java"
---

## Vue d'ensemble
Depuis Aspose.Slides Java 20.9, il est possible de créer des 3D dans les présentations. Les modèles 3D PowerPoint sont un moyen de donner vie aux présentations. Montrez des objets du monde réel avec une présentation 3D, démontrez le modèle 3D de votre futur projet d'affaires, le modèle 3D du bâtiment ou de son intérieur, le modèle 3D du personnage de jeu, ou simplement une représentation 3D de vos données.

Les modèles 3D PowerPoint peuvent être créés à partir de formes 2D, en leur appliquant des effets tels que : rotation 3D, profondeur 3D et extrusion, dégradé 3D, texte 3D, etc. La liste des fonctionnalités 3D appliquées aux formes peut être trouvée dans la classe **[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)**. L'instance de la classe peut être obtenue par :

- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/java/com.aspose.slides/Shape#getThreeDFormat--)** méthode pour créer un modèle 3D PowerPoint.
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getThreeDFormat--)** méthode pour créer un texte 3D (WordArt).

Tous les effets implémentés dans **[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)** peuvent être utilisés pour les formes et le texte. Jetons un rapide coup d'œil aux principales méthodes de la classe **[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)**. Dans l'exemple suivant, nous créons une forme rectangulaire 2D avec un texte dessus. En obtenant la vue de la caméra sur la forme, nous changeons sa rotation et faisons en sorte qu'elle ressemble à un modèle 3D. En définissant une lumière plate et sa direction vers le haut du modèle 3D, nous donnons plus de volume au modèle. Les matériaux modifiés, la hauteur d'extrusion et la couleur font que le modèle 3D paraît plus vivant.
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

Pour faire pivoter le modèle 3D avec l'API Aspose.Slides, utilisez la méthode **[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getCamera--)**, définissez la rotation de la caméra par rapport à la forme 3D :

``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... définissez d'autres paramètres de scène 3D

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

## Profondeur et extrusion 3D
Les méthodes **[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getExtrusionHeight--)** et **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getExtrusionColor--)** sont utilisées pour créer l'extrusion sur la forme :

``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
// ... définissez d'autres paramètres de scène 3D

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

Dans PowerPoint, la profondeur de la forme est définie via :

![todo:image_alt_text](img_02_02.png)

## Dégradé 3D
Le dégradé 3D peut apporter plus de volume à la forme 3D dans PowerPoint :

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

Voici à quoi cela ressemble :

![todo:image_alt_text](img_02_03.png)

Vous pouvez également créer un dégradé d'image :
``` java
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
// ... configuration 3D : shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion*

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
// définissez l'effet de transformation WordArt "Arc vers le haut"
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

## Non supporté - À venir
Les fonctionnalités 3D suivantes de PowerPoint ne sont pas encore supportées :
- Biseautage
- Matériau
- Contour
- Éclairage