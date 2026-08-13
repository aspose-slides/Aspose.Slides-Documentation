---
title: Créer et appliquer des effets WordArt en C++
linktitle: WordArt
type: docs
weight: 110
url: /fr/cpp/wordart/
keywords:
- WordArt
- créer WordArt
- modèle WordArt
- effet WordArt
- effet d'ombre
- effet d'affichage
- effet de lueur
- transformation WordArt
- effet 3D
- effet d'ombre extérieure
- effet d'ombre intérieure
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: Créez et personnalisez les effets WordArt dans Aspose.Slides pour C++. Ce guide étape par étape aide les développeurs à améliorer les présentations avec du texte professionnel en C++.
---
## **Vue d'ensemble**

Les effets WordArt vous permettent d'ajouter du texte visuellement attrayant et stylisé à vos présentations PowerPoint. Avec Aspose.Slides, les développeurs peuvent créer, personnaliser et gérer WordArt de façon programmatique comme dans Microsoft PowerPoint — sans avoir besoin d'Office installé. Cet article fournit un aperçu du travail avec WordArt, y compris comment appliquer des transformations de texte, des styles de remplissage, des contours, des ombres et d'autres options de mise en forme pour rendre le contenu de votre présentation plus expressif et engageant. WordArt vous permet de traiter le texte comme un objet graphique. Il se compose d'effets ou de modifications spéciales appliquées au texte pour le rendre plus attrayant ou visible.

## **Créer un modèle WordArt simple et l'appliquer au texte**

**Using Aspose.Slides** 

Tout d'abord, nous créons un texte simple en utilisant ce code C++ :

``` cpp 
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

Ensuite, nous définissons la hauteur de police du texte à une valeur plus grande pour rendre l'effet plus visible à l'aide de ce code :

``` cpp 
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**Using Microsoft PowerPoint**

Accédez au menu des effets WordArt dans Microsoft PowerPoint :

![todo:image_alt_text](image-20200930113926-1.png)

Dans le menu de droite, vous pouvez choisir un effet WordArt prédéfini. Dans le menu de gauche, vous pouvez spécifier les paramètres d'un nouveau WordArt. 

Voici quelques‑uns des paramètres ou options disponibles :

![todo:image_alt_text](image-20200930114015-3.png)

**Using Aspose.Slides**

Ici, nous appliquons la couleur de motif SmallGrid au texte et ajoutons une bordure de texte noire d'une largeur de 1 en utilisant ce code :

``` cpp 
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/IPatternFormat.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

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

## **Appliquer d'autres effets WordArt**

**Using Microsoft PowerPoint**

Depuis l'interface du programme, vous pouvez appliquer ces effets à un texte, un bloc de texte, une forme ou un élément similaire :

![todo:image_alt_text](image-20200930114129-5.png)

Par exemple, les effets Ombre, Réflexion et Lueur peuvent être appliqués à un texte ; les effets Format 3D et Rotation 3D peuvent être appliqués à un bloc de texte ; la propriété Bords doux peut être appliquée à un objet forme (elle reste active même lorsqu'aucune propriété Format 3D n'est définie). 

### **Appliquer des effets d'ombre au texte**

Ici, nous avons l'intention de définir les propriétés relatives uniquement au texte. Nous appliquons l'effet d'ombre à un texte en utilisant ce code C++ :

``` cpp 
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

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

L'API Aspose.Slides prend en charge trois types d'ombres : OuterShadow, InnerShadow et PresetShadow. 

Avec PresetShadow, vous pouvez appliquer une ombre à un texte (en utilisant des valeurs prédéfinies). 

**Using Microsoft PowerPoint**

Dans PowerPoint, vous ne pouvez utiliser qu'un type d'ombre. Voici un exemple :

![todo:image_alt_text](image-20200930114225-6.png)

**Using Aspose.Slides**

Aspose.Slides permet en fait d'appliquer simultanément deux types d'ombres : InnerShadow et PresetShadow.

**Notes:**

- Lorsque OuterShadow et PresetShadow sont utilisés ensemble, seul l'effet OuterShadow est appliqué. 
- Si OuterShadow et InnerShadow sont utilisés simultanément, l'effet résultant ou appliqué dépend de la version de PowerPoint. Par exemple, dans PowerPoint 2013, l'effet est doublé. Mais dans PowerPoint 2007, l'effet OuterShadow est appliqué. 

### **Appliquer des effets de réflexion**

Nous ajoutons une réflexion au texte à l'aide de cet exemple de code C++ :

``` cpp 
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

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

### **Appliquer des effets de lueur**

Nous appliquons l'effet de lueur au texte pour le faire briller ou le mettre en évidence en utilisant ce code :

``` cpp 
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

Le résultat de l'opération :

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 

Vous pouvez modifier les paramètres d'ombre, d'affichage et de lueur. Les propriétés des effets sont définies séparément pour chaque portion du texte. 

{{% /alert %}} 

### **Utiliser les transformations dans WordArt**

Nous utilisons la méthode set_Transform (applicable à l'ensemble du bloc de texte) à l'aide de ce code :

``` cpp 
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");

textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

Le résultat :

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 

Toutes les deux, Microsoft PowerPoint et Aspose.Slides pour C++, offrent un certain nombre de types de transformation prédéfinis. 

{{% /alert %}} 

**Using PowerPoint**

Pour accéder aux types de transformation prédéfinis, suivez : **Format** -> **Effet de texte** -> **Transformation**

**Using Aspose.Slides**

Pour sélectionner un type de transformation, utilisez l'énumération TextShapeType. 

### **Appliquer des effets 3D au texte et aux formes**

Nous appliquons un effet 3D à une forme de texte à l'aide de cet exemple de code :

``` cpp 
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
autoShape->get_TextFrame()->set_Text(u"Aspose.Slides");

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

Le texte résultant et sa forme :

![todo:image_alt_text](image-20200930114816-9.png)

Nous appliquons un effet 3D au texte avec ce code C++ :

``` cpp 
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");

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

{{% alert color="info" %}} 

L'application d'effets 3D aux textes ou à leurs formes ainsi que les interactions entre effets sont basées sur certaines règles. 

Considérez une scène pour un texte et la forme contenant ce texte. L'effet 3D comprend la représentation d'objet 3D et la scène sur laquelle l'objet a été placé. 

- Lorsque la scène est définie à la fois pour la forme et pour le texte, la scène de la forme a la priorité supérieure — la scène du texte est ignorée. 
- Si la forme ne possède pas de scène propre mais a une représentation 3D, la scène du texte est utilisée. 
- Sinon—lorsque la forme n'a initialement aucun effet 3D—la forme reste plate et l'effet 3D n'est appliqué qu'au texte. 

Ces descriptions sont liées aux méthodes ThreeDFormat.getLightRig() et ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Appliquer des effets d'ombre extérieure aux formes**
Aspose.Slides pour C++ fournit les classes [**IOuterShadow**](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.effects.i_outer_shadow) et [**IInnerShadow**](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.effects.i_inner_shadow) qui permettent d'appliquer des effets d'ombre à un texte contenu dans un TextFrame. Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation).  
2. Obtenez la référence d'une diapositive en utilisant son index.  
3. Ajoutez un AutoShape de type Rectangle à la diapositive.  
4. Accédez au TextFrame associé à l'AutoShape.  
5. Définissez la propriété FillType de l'AutoShape sur NoFill.  
6. Instanciez la classe OuterShadow  
7. Définissez le BlurRadius de l'ombre.  
8. Définissez la Direction de l'ombre  
9. Définissez la Distance de l'ombre.  
10. Définissez RectanglelAlign sur TopLeft.  
11. Définissez PresetColor de l'ombre sur Black.  
12. Enregistrez la présentation au format PPTX.  

Ce code d'exemple en C++ — une implémentation des étapes ci‑dessus — montre comment appliquer l'effet d'ombre extérieure à un texte :

``` cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
// Obtenir la référence de la diapositive
auto sld = pres->get_Slides()->idx_get(0);

// Ajouter une AutoShape de type Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Ajouter un TextFrame au Rectangle
ashp->AddTextFrame(u"Aspose TextBox");

// Désactiver le remplissage de la forme au cas où nous voulons obtenir l'ombre du texte
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Ajouter une ombre extérieure et définir tous les paramètres nécessaires
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// Enregistrer la présentation sur le disque
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```

## **Appliquer des effets d'ombre intérieure aux formes**
Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation).  
2. Obtenez une référence de la diapositive.  
3. Ajoutez un AutoShape de type Rectangle.  
4. Activez InnerShadowEffect.  
5. Définissez tous les paramètres nécessaires.  
6. Définissez ColorType sur Scheme.  
7. Définissez la couleur du schéma.  
8. Enregistrez la présentation au format [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Ce code d'exemple (basé sur les étapes ci‑dessus) montre comment ajouter un connecteur entre deux formes en C++ :

``` cpp
#include <DOM/ColorType.h>
#include <DOM/Effects/IInnerShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
// Obtenir la référence d'une diapositive
auto slide = presentation->get_Slides()->idx_get(0);

// Ajouter une AutoShape de type Rectangle
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Ajouter un TextFrame au rectangle
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// Activer InnerShadowEffect    
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

// Définir la couleur du schéma
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// Enregistrer la présentation
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

### Puis‑je utiliser les effets WordArt avec différentes polices ou scripts (par ex., arabe, chinois) ?
Oui, Aspose.Slides prend en charge Unicode et fonctionne avec toutes les principales polices et scripts. Les effets WordArt tels que l'ombre, le remplissage et le contour peuvent être appliqués quel que soit la langue, bien que la disponibilité des polices et le rendu puissent dépendre des polices du système.

### Puis‑je appliquer les effets WordArt aux éléments du masque de diapositive ?
Oui, vous pouvez appliquer les effets WordArt aux formes des masques de diapositives, y compris les espaces réservés au titre, les pieds de page ou le texte d'arrière‑plan. Les modifications apportées à la mise en page du masque se refléteront sur toutes les diapositives associées.

### Les effets WordArt affectent-ils la taille du fichier de présentation ?
Légèrement. Les effets WordArt tels que les ombres, les lueurs et les remplissages en dégradé peuvent légèrement augmenter la taille du fichier en raison des métadonnées de formatage supplémentaires, mais la différence est généralement négligeable.

### Puis‑je prévisualiser le résultat des effets WordArt sans enregistrer la présentation ?
Oui, vous pouvez rendre les diapositives contenant du WordArt en images (par ex., PNG, JPEG) en utilisant la méthode `GetImage` des interfaces [IShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/) ou [ISlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/). Cela vous permet de prévisualiser le résultat en mémoire ou à l'écran avant d'enregistrer ou d'exporter la présentation complète.