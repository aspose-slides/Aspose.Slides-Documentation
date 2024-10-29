---
title: Thème de présentation
type: docs
weight: 10
url: /fr/cpp/presentation-theme/
keywords: "Thème, thème PowerPoint, présentation PowerPoint, CPP, C++, Aspose.Slides pour C++"
description: "Thème de présentation PowerPoint en C++"
---

Un thème de présentation définit les propriétés des éléments de design. Lorsque vous sélectionnez un thème de présentation, vous choisissez essentiellement un ensemble spécifique d'éléments visuels et leurs propriétés.

Dans PowerPoint, un thème est composé de couleurs, de [polices](/slides/fr/cpp/powerpoint-fonts/), de [styles d'arrière-plan](/slides/fr/cpp/presentation-background/) et d'effets.

![theme-constituents](theme-constituents.png)

## **Changer la couleur du thème**

Un thème PowerPoint utilise un ensemble spécifique de couleurs pour différents éléments sur une diapositive. Si vous n'aimez pas les couleurs, vous pouvez les changer en appliquant de nouvelles couleurs au thème. Pour vous permettre de sélectionner une nouvelle couleur de thème, Aspose.Slides fournit des valeurs sous l'énumération [SchemeColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28).

Ce code C++ vous montre comment changer la couleur d'accent d'un thème :

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

Vous pouvez déterminer la valeur effective de la couleur résultante de cette manière :

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Couleur [A=255, R=128, G=100, B=162])
```

Pour démontrer davantage l'opération de changement de couleur, nous créons un autre élément et y assignons la couleur d'accent (de l'opération initiale). Ensuite, nous changeons la couleur dans le thème :

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

La nouvelle couleur est appliquée automatiquement aux deux éléments.

### **Définir la couleur du thème à partir d'une palette supplémentaire**

Lorsque vous appliquez des transformations de luminance à la couleur de thème principale(1), des couleurs de la palette supplémentaire(2) sont formées. Vous pouvez ensuite définir et obtenir ces couleurs de thème. 

![additional-palette-colors](additional-palette-colors.png)

**1**- Couleurs de thème principales

**2** - Couleurs de la palette supplémentaire.

Ce code C++ démontre une opération où les couleurs de la palette supplémentaire sont obtenues à partir de la couleur de thème principale et ensuite utilisées dans des formes :

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Accent 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Accent 4, Lighter 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Accent 4, Lighter 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Accent 4, Lighter 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Accent 4, Darker 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Accent 4, Darker 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

## **Changer la police du thème**

Pour vous permettre de sélectionner des polices pour les thèmes et d'autres usages, Aspose.Slides utilise ces identifiants spéciaux (similaires à ceux utilisés dans PowerPoint) :

* **+mn-lt** - Police de corps Latin (police minoritaire Latin)
* **+mj-lt** - Police de titre Latin (police majoritaire Latin)
* **+mn-ea** - Police de corps Asiatique de l'Est (police minoritaire Asiatique de l'Est)
* **+mj-ea** - Police de titre Asiatique de l'Est (police majoritaire Asiatique de l'Est)

Ce code C++ vous montre comment assigner la police Latin à un élément de thème :

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Format de texte du thème");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

Ce code C++ vous montre comment changer la police du thème de présentation :

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

La police de tous les zones de texte sera mise à jour.

{{% alert color="primary" title="ASTUCE" %}} 

Vous pouvez consulter les [polices PowerPoint](/slides/fr/cpp/powerpoint-fonts/).

{{% /alert %}}

## **Changer le style d'arrière-plan du thème**

Par défaut, l'application PowerPoint fournit 12 arrière-plans prédéfinis mais seulement 3 de ces 12 arrière-plans sont enregistrés dans une présentation typique. 

![todo:image_alt_text](presentation-design_8.png)

Par exemple, après avoir enregistré une présentation dans l'application PowerPoint, vous pouvez exécuter ce code C++ pour découvrir le nombre d'arrière-plans prédéfinis dans la présentation :

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Le nombre de styles de remplissage d'arrière-plan pour le thème est {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 

En utilisant la propriété [BackgroundFillStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) de la classe [FormatScheme](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme/), vous pouvez ajouter ou accéder au style d'arrière-plan dans un thème PowerPoint. 

{{% /alert %}}

Ce code C++ vous montre comment définir l'arrière-plan d'une présentation :

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Guide des index** : 0 est utilisé pour aucun remplissage. L'index commence à partir de 1.

{{% alert color="primary" title="ASTUCE" %}} 

Vous pouvez consulter [l'Arrière-plan PowerPoint](/slides/fr/cpp/presentation-background/).

{{% /alert %}}

## **Changer l'effet du thème**

Un thème PowerPoint contient généralement 3 valeurs pour chaque tableau de style. Ces tableaux sont combinés en 3 effets : subtil, modéré et intense. Par exemple, voici le résultat lorsque les effets sont appliqués à une forme spécifique :

![todo:image_alt_text](presentation-design_10.png)

En utilisant 3 propriétés ([FillStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) de la classe [FormatScheme](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme/) vous pouvez changer les éléments dans un thème (même plus flexiblement que les options dans PowerPoint).

Ce code C++ vous montre comment changer un effet de thème en modifiant des parties des éléments :

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

Les changements résultants dans la couleur de remplissage, le type de remplissage, l'effet d'ombre, etc :

![todo:image_alt_text](presentation-design_11.png)