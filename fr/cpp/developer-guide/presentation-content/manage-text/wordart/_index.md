---
title: WordArt
type: docs
weight: 110
url: /fr/cpp/wordart/
---

## **À propos de WordArt ?**
WordArt ou Art de Texte est une fonctionnalité qui vous permet d'appliquer des effets aux textes pour les faire ressortir. Avec WordArt, par exemple, vous pouvez contourer un texte ou le remplir avec une couleur (ou un dégradé), ajouter des effets 3D, etc. Vous pouvez également incliner, plier et étirer la forme d'un texte. 

{{% alert color="primary" %}} 

WordArt vous permet de traiter un texte comme un objet graphique. En général, WordArt se compose d'effets ou de modifications spéciales apportées aux textes pour les rendre plus attrayants ou visibles. 

{{% /alert %}} 

**WordArt dans Microsoft PowerPoint**

Pour utiliser WordArt dans Microsoft PowerPoint, vous devez sélectionner l'un des modèles WordArt prédéfinis. Un modèle WordArt est un ensemble d'effets qui est appliqué à un texte ou à sa forme. 

**WordArt dans Aspose.Slides**

Dans Aspose.Slides pour C++ 20.10, nous avons mis en œuvre le support de WordArt et apporté des améliorations à la fonctionnalité dans les versions ultérieures d'Aspose.Slides pour C++. 

Avec Aspose.Slides pour C++, vous pouvez facilement créer votre propre modèle WordArt (un effet ou une combinaison d'effets) en C++ et l'appliquer aux textes. 

## Création d'un modèle WordArt simple et application à un texte

**Utilisation d'Aspose.Slides** 

Tout d'abord, nous créons un texte simple en utilisant ce code C++ : 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

Maintenant, nous augmentons la hauteur de la police du texte pour rendre l'effet plus visible grâce à ce code :

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**Utilisation de Microsoft PowerPoint**

Accédez au menu des effets WordArt dans Microsoft PowerPoint :

![todo:image_alt_text](image-20200930113926-1.png)

Dans le menu de droite, vous pouvez choisir un effet WordArt prédéfini. Dans le menu de gauche, vous pouvez spécifier les paramètres d'un nouveau WordArt. 

Voici quelques-uns des paramètres ou options disponibles :

![todo:image_alt_text](image-20200930114015-3.png)

**Utilisation d'Aspose.Slides**

Ici, nous appliquons la couleur du motif SmallGrid au texte et ajoutons une bordure de texte noire de 1 pixel de largeur grâce à ce code :

``` cpp 
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

Le texte résultant :

![todo:image_alt_text](image-20200930114108-4.png)

## Application d'autres effets WordArt

**Utilisation de Microsoft PowerPoint**

Depuis l'interface du programme, vous pouvez appliquer ces effets à un texte, un bloc de texte, une forme ou un élément similaire :

![todo:image_alt_text](image-20200930114129-5.png)

Par exemple, les effets d'Ombre, de Réflexion et de Brillance peuvent être appliqués à un texte ; les effets de Format 3D et de Rotation 3D peuvent être appliqués à un bloc de texte ; la propriété Bords adoucis peut être appliquée à un objet de forme (elle a toujours un effet même lorsque aucune propriété de format 3D n'est définie). 

### Application d'effets d'ombre

Ici, nous avons l'intention de définir les propriétés relatives uniquement à un texte. Nous appliquons l'effet d'ombre à un texte en utilisant ce code en C++ :

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(65);
outerShadowEffect->set_BlurRadius(4.73);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(2);
outerShadowEffect->set_SkewHorizontal(30);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

L'API Aspose.Slides supporte trois types d'ombres : OuterShadow, InnerShadow et PresetShadow. 

Avec PresetShadow, vous pouvez appliquer une ombre à un texte (en utilisant des valeurs prédéfinies). 

**Utilisation de Microsoft PowerPoint**

Dans PowerPoint, vous pouvez utiliser un type d'ombre. Voici un exemple :

![todo:image_alt_text](image-20200930114225-6.png)

**Utilisation d'Aspose.Slides**

Aspose.Slides permet en réalité d'appliquer deux types d'ombres à la fois : InnerShadow et PresetShadow.

**Notes :**

- Lorsque OuterShadow et PresetShadow sont utilisés ensemble, seul l'effet OuterShadow est appliqué. 
- Si OuterShadow et InnerShadow sont utilisés simultanément, l'effet résultant ou appliqué dépend de la version de PowerPoint. Par exemple, dans PowerPoint 2013, l'effet est doublé. Mais dans PowerPoint 2007, l'effet OuterShadow est appliqué. 

### Application de la brillance aux textes

Nous ajoutons de la brillance au texte à l'aide de cet exemple de code en C++ :

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```

### Application de l'effet de brillance aux textes

Nous appliquons l'effet de brillance au texte pour le faire briller ou ressortir en utilisant ce code :

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

Le résultat de l'opération :

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Vous pouvez modifier les paramètres pour l'ombre, la brillance et la brillance. Les propriétés des effets sont définies pour chaque portion du texte séparément. 

{{% /alert %}} 

### Utilisation des transformations dans WordArt

Nous utilisons la méthode set_Transform (inhérente à l'ensemble du bloc de texte) grâce à ce code :

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

Le résultat :

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint et Aspose.Slides pour C++ fournissent un certain nombre de types de transformations prédéfinis. 

{{% /alert %}} 

**Utilisation de PowerPoint**

Pour accéder aux types de transformation prédéfinis, allez à : **Format** -> **Effet de texte** -> **Transformer**

**Utilisation d'Aspose.Slides**

Pour sélectionner un type de transformation, utilisez l'énumération TextShapeType. 

### Application d'effets 3D aux textes et aux formes

Nous définissons un effet 3D à une forme de texte en utilisant cet exemple de code :

``` cpp 
auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Le texte et sa forme résultants :

![todo:image_alt_text](image-20200930114816-9.png)

Nous appliquons un effet 3D au texte avec ce code C++ :

``` cpp 
auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Le résultat de l'opération :

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

L'application d'effets 3D aux textes ou à leurs formes et les interactions entre les effets reposent sur certaines règles. 

Considérez une scène pour un texte et la forme contenant ce texte. L'effet 3D contient une représentation de l'objet 3D et la scène sur laquelle l'objet est placé. 

- Lorsque la scène est définie pour à la fois la figure et le texte, la scène de la figure a la priorité la plus élevée : la scène du texte est ignorée. 
- Lorsque la figure n'a pas sa propre scène mais a une représentation 3D, la scène du texte est utilisée. 
- Sinon — lorsque la forme n'a pas d'effet 3D d'origine — la forme est plate et l'effet 3D n'est appliqué qu'au texte. 

Ces descriptions sont liées aux méthodes ThreeDFormat.getLightRig() et ThreeDFormat.getCamera().

{{% /alert %}} 

## **Appliquer des effets d'ombre extérieure aux textes**
Aspose.Slides pour C++ fournit les classes [**IOuterShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_outer_shadow) et [**IInnerShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_inner_shadow) qui vous permettent d'appliquer des effets d'ombre à un texte porté par TextFrame. Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d'une diapositive à l'aide de son index.
3. Ajoutez une forme AutoShape de type Rectangle à la diapositive.
4. Accédez au TextFrame associé à la forme AutoShape.
5. Définissez le FillType de la forme AutoShape sur NoFill.
6. Instanciez la classe OuterShadow.
7. Définissez le BlurRadius de l'ombre.
8. Définissez la Direction de l'ombre.
9. Définissez la Distance de l'ombre.
10. Définissez le RectangleAlign sur TopLeft.
11. Définissez la couleur prédéfinie de l'ombre sur Noir.
12. Écrivez la présentation en tant que fichier PPTX.

Cet exemple de code en C++ — une implémentation des étapes ci-dessus — vous montre comment appliquer l'effet d'ombre extérieure à un texte :

``` cpp
auto pres = System::MakeObject<Presentation>();
// Obtenir la référence de la diapositive
auto sld = pres->get_Slides()->idx_get(0);

// Ajouter une forme AutoShape de type Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Ajouter TextFrame au Rectangle
ashp->AddTextFrame(u"Aspose TextBox");

// Désactiver le remplissage de la forme au cas où nous voudrions obtenir l'ombre du texte
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Ajouter une ombre extérieure et définir tous les paramètres nécessaires
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// Écrire la présentation sur le disque
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```


## **Appliquer l'effet d'ombre intérieure aux formes**
Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez une référence de la diapositive.
3. Ajoutez une AutoShape de type Rectangle.
4. Activez l'effet InnerShadowEffect.
5. Définissez tous les paramètres nécessaires.
6. Définissez le ColorType comme Scheme.
7. Définissez la couleur de l'échantillon.
8. Écrivez la présentation en tant que fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

Cet exemple de code (basé sur les étapes ci-dessus) vous montre comment ajouter un connecteur entre deux formes en C++ :

``` cpp
auto presentation = System::MakeObject<Presentation>();
// Obtenir la référence d'une diapositive
auto slide = presentation->get_Slides()->idx_get(0);

// Ajouter une AutoShape de type Rectangle
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Ajouter TextFrame au Rectangle
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// Activer l'effet InnerShadowEffect    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// Définir tous les paramètres nécessaires
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// Définir ColorType comme Scheme
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Définir la couleur de l'échantillon
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// Enregistrer la présentation
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```