---
title: Mise en forme des formes
type: docs
weight: 20
url: /cpp/shape-formatting/
keywords: "Mise en forme de forme, mise en forme des lignes, styles de jointure, remplissage dégradé, remplissage de motif, remplissage d'image, remplissage couleur unie, rotation des formes, effets de biseau 3D, effet de rotation 3D, présentation PowerPoint, C++, Aspose.Slides pour C++"
description: "Mise en forme des formes dans une présentation PowerPoint en C++"
---

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Étant donné que les formes sont constituées de lignes, vous pouvez formater les formes en modifiant ou en appliquant certains effets à leurs lignes constitutives. De plus, vous pouvez formater les formes en spécifiant des paramètres qui déterminent comment elles (la zone en elles) sont remplies.

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides pour C++** fournit des interfaces et des propriétés qui vous permettent de formater des formes en fonction des options connues dans PowerPoint.

## **Mise en forme des lignes**

Avec Aspose.Slides, vous pouvez spécifier votre style de ligne préféré pour une forme. Ces étapes décrivent une telle procédure :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d'une diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) à la diapositive.
4. Définissez une couleur pour les lignes de la forme.
5. Définissez la largeur des lignes de la forme.
6. Définissez le [style de ligne](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a837c78839bf6ebb16979455cd1de59e4) pour la ligne de la forme.
7. Définissez le [style de tiret](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a7eaad354a35a3b567a7327d625be3c6e) pour la ligne de la forme.
8. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code C++ illustre une opération où nous avons formaté un rectangle `AutoShape` :

```cpp
// Instancie une classe de présentation représentant un fichier de présentation
auto pres = MakeObject<Presentation>();

// Obtient la première diapositive
auto slide = pres->get_Slides()->idx_get(0);

// Ajoute une autoshape de type rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Définit la couleur de remplissage pour la forme rectangle
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_White());

// Applique une certaine mise en forme sur les lignes du rectangle
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Définit la couleur pour la ligne du rectangle
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Écrit le fichier PPTX sur le disque
pres->Save(u"RectShpLn_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Styles de jointure**
Ce sont les 3 options de type de jointure :

* Arrondi
* Miter
* Biseau

Par défaut, lorsque PowerPoint joint deux lignes à un angle (ou un coin de forme), il utilise le réglage **Arrondi**. Cependant, si vous souhaitez dessiner une forme avec des angles très vifs, vous voudrez peut-être sélectionner **Miter**.

![join-style-powerpoint](join-style-powerpoint.png)

Ce code C++ illustre une opération où 3 rectangles (l'image ci-dessus) ont été créés avec les paramètres de type de jointure Miter, Bevel et Round :

```cpp
// Instancie une classe de présentation représentant un fichier de présentation
auto pres = MakeObject<Presentation>();

// Obtient la première diapositive
auto slide = pres->get_Slides()->idx_get(0);

// Ajoute 3 autoshapes rectangulaires
SharedPtr<IAutoShape> shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);
SharedPtr<IAutoShape> shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 300, 100, 150, 75);
SharedPtr<IAutoShape> shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 250, 150, 75);

// Définit la couleur de remplissage pour la forme rectangle
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Définit la largeur de ligne
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Définit la couleur pour la ligne du rectangle
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Définit le style de jointure
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Ajoute du texte à chaque rectangle
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Écrit le fichier PPTX sur le disque
pres->Save(u"RectShpLnJoin_out.pptx", Export::SaveFormat::Pptx);
```

## **Remplissage dégradé**
Dans PowerPoint, le remplissage dégradé est une option de mise en forme qui vous permet d'appliquer un mélange continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus dans un paramètre où une couleur s'estompe progressivement et se transforme en une autre couleur.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage dégradé à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d'une diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) à la diapositive.
4. Réglez le [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) de la forme sur `Gradient`.
5. Ajoutez vos 2 couleurs préférées avec des positions définies à l'aide des méthodes `Add` exposées par la collection `GradientStops` associée à la classe `GradientFormat`.
6. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce C++ illustre une opération où l'effet de remplissage dégradé a été utilisé sur une ellipse :

```cpp
// Instancie une classe de présentation représentant un fichier de présentation
auto pres = MakeObject<Presentation>();

// Obtient la première diapositive
auto slide = pres->get_Slides()->idx_get(0);
    
// Ajoute une autoshape ellipse
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 150, 75, 150);

// Applique la mise en forme dégradée à l'ellipse
autoShape->get_FillFormat()->set_FillType(FillType::Gradient);
autoShape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Définit la direction du dégradé
autoShape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Ajoute 2 arrêts de dégradé
autoShape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
autoShape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Écrit le fichier PPTX sur le disque
pres->Save(u"FillShapesGradient_out.pptx", Export::SaveFormat::Pptx);
```

## **Remplissage de motif**
Dans PowerPoint, le remplissage de motif est une option de mise en forme qui vous permet d'appliquer un design bi-couleur composé de points, de rayures, de hachures croisées ou de quadrillés à une forme. De plus, vous pouvez choisir vos couleurs préférées pour le premier plan et l'arrière-plan de votre motif.

Aspose.Slides propose plus de 45 styles prédéfinis pouvant être utilisés pour formater des formes et enrichir des présentations. Même après avoir choisi un motif prédéfini, vous pouvez toujours spécifier les couleurs que le motif doit contenir.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage de motif à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d'une diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) à la diapositive.
4. Réglez le [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) de la forme sur `Pattern`.
5. Définissez votre style de motif préféré pour la forme.
6. Définissez la [couleur d'arrière-plan](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_pattern_format#af55b6343b7bd80d0ad95070e96b8766e) pour le [PatternFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.pattern_format).
7. Définissez la [couleur de premier plan](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_pattern_format#a4121d8c2233df4b90cbfd6ea4c312cbe) pour le [PatternFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.pattern_format).
8. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code C++ illustre une opération où un remplissage de motif a été utilisé pour embellir un rectangle :

```cpp
// Instancie une classe de présentation représentant un fichier de présentation
auto pres = MakeObject<Presentation>();

// Obtient la première diapositive
auto slide = pres->get_Slides()->idx_get(0);

// Ajoute une autoshape rectangle
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// Définit le type de remplissage sur Motif
autoShape->get_FillFormat()->set_FillType(FillType::Pattern);

// Définit le style de motif
autoShape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Définit les couleurs d'arrière-plan et de premier plan du motif
autoShape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color ( Color::get_LightGray());
autoShape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Écrit le fichier PPTX sur le disque
pres->Save(u"RectShpPatt_out.pptx", Export::SaveFormat::Pptx);
```

## **Remplissage d'image**
Dans PowerPoint, le remplissage d'image est une option de mise en forme qui vous permet de placer une image à l'intérieur d'une forme. En gros, vous utilisez une image comme arrière-plan d'une forme.

Voici comment utiliser Aspose.Slides pour remplir une forme avec une image :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d'une diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) à la diapositive.
4. Réglez le [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) de la forme sur `Picture`.
5. Définissez le mode de remplissage d'image sur Carrelage.
6. Créez un objet `IPPImage` en utilisant l'image qui sera utilisée pour remplir la forme.
7. Réglez la propriété `Picture.Image` de l'objet `PictureFillFormat` sur l'`IPPImage` récemment créé.
8. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code C++ vous montre comment remplir une forme avec une image :

```cpp
// Instancie une classe de présentation représentant un fichier de présentation
auto pres = MakeObject<Presentation>();

// Obtient la première diapositive
auto slide = pres->get_Slides()->idx_get(0);

// Ajoute une autoshape rectangle
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// Définit le type de remplissage sur Image
autoShape->get_FillFormat()->set_FillType(FillType::Picture);

// Définit le mode de remplissage d'image
autoShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Définit l'image
auto img = Images::FromFile(u"Tulips.jpg");
auto imgx = pres->get_Images()->AddImage(img);
autoShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Écrit le fichier PPTX sur le disque
pres->Save(u"RectShpPic_out.pptx", Export::SaveFormat::Pptx);
```

## **Remplissage couleur unie**
Dans PowerPoint, le remplissage couleur unie est une option de mise en forme qui vous permet de remplir une forme avec une seule couleur. La couleur choisie est généralement une couleur unie. La couleur est appliquée à l'arrière-plan de la forme avec tous les effets ou modifications spéciaux.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage couleur unie à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d'une diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) à la diapositive.
4. Réglez le [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) de la forme sur `Solid`.
5. Définissez votre couleur préférée pour la forme.
6. Écrivez la présentation modifiée en tant que fichier PPTX.

Les étapes ci-dessus sont mises en œuvre dans l'exemple ci-dessous.

```cpp
// Instancie une classe de présentation représentant un fichier de présentation
auto pres = MakeObject<Presentation>();

// Obtient la première diapositive
auto slide = pres->get_Slides()->idx_get(0);

// Ajoute une autoshape rectangle
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// Définit le type de remplissage sur Image
autoShape->get_FillFormat()->set_FillType(FillType::Solid);

// Définit la couleur pour le rectangle
autoShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Écrit le fichier PPTX sur le disque
pres->Save(u"RectShpSolid_out.pptx", Export::SaveFormat::Pptx);
```

## **Définir la transparence**

Dans PowerPoint, lorsque vous remplissez des formes avec des couleurs unies, des dégradés, des images ou des textures, vous pouvez spécifier le niveau de transparence qui détermine l'opacité d'un remplissage. De cette façon, par exemple, si vous définissez un faible niveau de transparence, l'objet de diapositive ou l'arrière-plan derrière (la forme) s'affiche à travers.

Aspose.Slides vous permet de définir le niveau de transparence pour une forme de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d'une diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) à la diapositive.
4. Utilisez `Color.FromArgb` avec le composant alpha défini.
5. Enregistrez l'objet en tant que fichier PowerPoint.

Ce code C++ illustre le processus :

```cpp
// Instancie une classe de présentation représentant un fichier de présentation
auto pres = MakeObject<Presentation>();

// Obtient la première diapositive
auto slide = pres->get_Slides()->idx_get(0);

// Ajoute une forme solide
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 175, 75, 150);

// Ajoute une forme transparente sur la forme solide
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(128, 204, 102, 0));
   
// Écrit le fichier PPTX sur le disque
pres->Save(u"ShapeTransparentOverSolid_out.pptx", Export::SaveFormat::Pptx);
```

## **Faire pivoter les formes**
Aspose.Slides vous permet de faire pivoter une forme ajoutée à une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d'une diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) à la diapositive.
4. Faites pivoter la forme de l'angle nécessaire.
5. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code C++ vous montre comment faire pivoter une forme de 90 degrés :

```cpp
// Instancie une classe de présentation représentant un fichier de présentation
auto pres = MakeObject<Presentation>();

// Obtient la première diapositive
auto slide = pres->get_Slides()->idx_get(0);

// Ajoute une autoshape rectangle
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// Fait pivoter la forme de 90 degrés
autoShape->set_Rotation(90.f);

// Écrit le fichier PPTX sur le disque
pres->Save(u"RectShpRot_out.pptx", Export::SaveFormat::Pptx);
```

## **Ajouter des effets de biseau 3D**
Aspose.Slides vous permet d'ajouter des effets de biseau 3D à une forme en modifiant ses propriétés [ThreeDFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format) de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d'une diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) à la diapositive.
4. Définissez vos paramètres préférés pour les propriétés [ThreeDFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format) de la forme.
5. Écrivez la présentation sur le disque.

Ce code C++ vous montre comment ajouter des effets de biseau 3D à une forme :

```cpp
// Instancie une classe de présentation représentant un fichier de présentation
auto pres = MakeObject<Presentation>();

// Obtient la première diapositive
auto slide = pres->get_Slides()->idx_get(0);

// Ajoute une forme à la diapositive
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
auto format = shape->get_LineFormat()->get_FillFormat();
format->set_FillType(FillType::Solid);
format->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Définit les propriétés ThreeDFormat de la forme
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Écrit la présentation en tant que fichier PPTX
pres->Save(u"Bavel_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ajouter un effet de rotation 3D**
Aspose.Slides vous permet d'appliquer des effets de rotation 3D à une forme en modifiant ses propriétés [ThreeDFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format) de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d'une diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) à la diapositive.
4. Spécifiez vos figures préférées pour [CameraType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_camera#aea0717e8ef5f3199df99ed2cb2ea2dcb) et [LightType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_light_rig#a2cd12029664967d0e2f93eee25a4963f).
5. Écrivez la présentation sur le disque.

Ce code C++ vous montre comment appliquer des effets de rotation 3D à une forme :

```cpp
// Instancie une classe de présentation représentant un fichier de présentation
auto pres = MakeObject<Presentation>();

// Obtient la première diapositive
auto slide = pres->get_Slides()->idx_get(0);
    
// Ajoute une forme à la diapositive
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);

// Définit les propriétés ThreeDFormat de la forme
shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Ajoute une forme à la diapositive
shape = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 30, 300, 200, 200);

// Définit les propriétés ThreeDFormat de la forme
shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(0, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Écrit la présentation en tant que fichier PPTX
pres->Save(u"Rotation_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Réinitialiser la mise en forme**

Ce code C++ vous montre comment réinitialiser la mise en forme dans une diapositive et rétablir la position, la taille et la mise en forme de chaque forme qui a un espace réservé sur le [LayoutSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.layout_slide) à leurs valeurs par défaut :

```c++
auto pres = System::MakeObject<Presentation>();

for (auto slide : pres->get_Slides())
{
    // chaque forme sur la diapositive qui a un espace réservé sur la mise en page sera rétablie
    slide->Reset();
}
```