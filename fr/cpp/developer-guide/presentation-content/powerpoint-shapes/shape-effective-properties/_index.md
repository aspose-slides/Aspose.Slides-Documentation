---
title: Obtenir les propriétés effectives des formes à partir de présentations en C++
linktitle: Propriétés effectives
type: docs
weight: 50
url: /fr/cpp/shape-effective-properties/
keywords:
- propriétés de forme
- propriétés de caméra
- système d'éclairage
- forme chanfreinée
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Découvrez comment Aspose.Slides pour C++ calcule et applique les propriétés effectives des formes pour un rendu précis de PowerPoint."
---
## **Vue d'ensemble**

Ce sujet explique la différence entre les propriétés **locales** et **effectives**. Les valeurs locales sont des valeurs définies directement à un niveau de mise en forme spécifique, comme :

1. Propriétés de portion sur une diapositive.
1. Styles de texte de forme prototype sur une diapositive de mise en page ou maîtresse, lorsque la forme du cadre de texte de la portion en possède un.
1. Paramètres de texte globaux dans une présentation.

Les valeurs locales peuvent être définies ou omises à n’importe quel niveau. Lorsque Aspose.Slides a besoin du formatage final "as rendered", il résout la chaîne d’héritage et renvoie des valeurs **effectives**. Vous pouvez les obtenir en appelant la méthode `GetEffective` sur l’objet de format local.

L'exemple suivant montre comment obtenir les valeurs effectives. Il suppose que la première forme de la première diapositive est une [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) avec un cadre de texte et au moins une portion.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="info" %}}
Les données de formatage effectif représentent le formatage calculé actuel après application de l'héritage. Dans l'implémentation actuelle, certains objets de données effectives, tels que [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportionformateffectivedata/), peuvent être mis en cache en interne. Rappeler `GetEffective` après avoir modifié le formatage parent ou hérité peut rafraîchir les données mises en cache, et un objet précédemment obtenu peut ne plus représenter l’état antérieur. Si vous devez conserver les valeurs effectives pour une réutilisation ultérieure, copiez les propriétés requises, comme la hauteur de police, la couleur de remplissage, le style de police ou l'alignement, dans votre propre objet de données.
{{% /alert %}}

## **Obtenir les propriétés effectives d'une caméra**

Aspose.Slides permet d'obtenir les propriétés effectives d'une caméra. L'interface [ICameraEffectiveData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icameraeffectivedata/) représente un objet immuable contenant les propriétés de caméra effectives. Une instance de [ICameraEffectiveData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icameraeffectivedata/) est exposée via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformateffectivedata/), qui fournit les valeurs effectives pour [IThreeDFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/).

L'exemple de code suivant montre comment obtenir les propriétés effectives pour la caméra. Il suppose que la première forme de la première diapositive possède un format 3D.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto camera = threeDEffectiveData->get_Camera();

System::Console::WriteLine(u"= Effective camera properties =");
auto cameraType = System::ObjectExt::ToString(camera->get_CameraType());
System::Console::WriteLine(System::String(u"Type: ") + cameraType);

auto fieldOfViewAngle = camera->get_FieldOfViewAngle();
System::Console::WriteLine(System::String(u"Field of view: ") + fieldOfViewAngle);

auto cameraZoom = camera->get_Zoom();
System::Console::WriteLine(System::String(u"Zoom: ") + cameraZoom);

presentation->Dispose();
```

## **Obtenir les propriétés effectives d'un système d'éclairage**

Aspose.Slides permet d'obtenir les propriétés effectives d'un système d'éclairage. L'interface [ILightRigEffectiveData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilightrigeffectivedata/) représente un objet immuable contenant les propriétés du système d'éclairage effectives. Une instance de [ILightRigEffectiveData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilightrigeffectivedata/) est exposée via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformateffectivedata/), qui fournit les valeurs effectives pour [IThreeDFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/).

L'exemple de code suivant montre comment obtenir les propriétés effectives pour le système d'éclairage. Il suppose que la première forme de la première diapositive possède un format 3D.

```cpp
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto lightRig = threeDEffectiveData->get_LightRig();

System::Console::WriteLine(u"= Effective light rig properties =");
auto lightType = System::ObjectExt::ToString(lightRig->get_LightType());
System::Console::WriteLine(System::String(u"Type: ") + lightType);

auto lightDirection = System::ObjectExt::ToString(lightRig->get_Direction());
System::Console::WriteLine(System::String(u"Direction: ") + lightDirection);

presentation->Dispose();
```

## **Obtenir les propriétés effectives d'un chanfrein de forme**

Aspose.Slides permet d'obtenir les propriétés effectives d'un chanfrein de forme. L'interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapebeveleffectivedata/) représente un objet immuable contenant les propriétés de relief de forme effectives. Une instance de [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapebeveleffectivedata/) est exposée via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformateffectivedata/), qui fournit les valeurs effectives pour [IThreeDFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/).

L'exemple de code suivant montre comment obtenir les propriétés effectives pour le chanfrein supérieur d'une forme. Il suppose que la première forme de la première diapositive possède un format 3D.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto bevelTop = threeDEffectiveData->get_BevelTop();

System::Console::WriteLine(u"= Effective shape's top face relief properties =");
auto bevelType = System::ObjectExt::ToString(bevelTop->get_BevelType());
System::Console::WriteLine(System::String(u"Type: ") + bevelType);

auto bevelWidth = bevelTop->get_Width();
System::Console::WriteLine(System::String(u"Width: ") + bevelWidth);

auto bevelHeight = bevelTop->get_Height();
System::Console::WriteLine(System::String(u"Height: ") + bevelHeight);

presentation->Dispose();
```

## **Obtenir les propriétés effectives d'un cadre de texte**

Avec Aspose.Slides, vous pouvez obtenir les propriétés effectives d'un cadre de texte. L'interface [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframeformateffectivedata/) contient les propriétés de formatage effectif du cadre de texte.

L'exemple de code suivant montre comment obtenir les propriétés de formatage effectif du cadre de texte. Il suppose que la première forme de la première diapositive est une [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) avec un cadre de texte.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextFrameFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto effectiveTextFrameFormat = shape->get_TextFrame()->get_TextFrameFormat()->GetEffective();

auto anchoringType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AnchoringType());
System::Console::WriteLine(System::String(u"Anchoring type: ") + anchoringType);

auto autofitType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AutofitType());
System::Console::WriteLine(System::String(u"Autofit type: ") + autofitType);

auto textVerticalType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_TextVerticalType());
System::Console::WriteLine(System::String(u"Text vertical type: ") + textVerticalType);

System::Console::WriteLine(u"Margins");
auto marginLeft = effectiveTextFrameFormat->get_MarginLeft();
System::Console::WriteLine(System::String(u"   Left: ") + marginLeft);

auto marginTop = effectiveTextFrameFormat->get_MarginTop();
System::Console::WriteLine(System::String(u"   Top: ") + marginTop);

auto marginRight = effectiveTextFrameFormat->get_MarginRight();
System::Console::WriteLine(System::String(u"   Right: ") + marginRight);

auto marginBottom = effectiveTextFrameFormat->get_MarginBottom();
System::Console::WriteLine(System::String(u"   Bottom: ") + marginBottom);

presentation->Dispose();
```

## **Obtenir les propriétés effectives d'un style de texte**

Avec Aspose.Slides, vous pouvez obtenir les propriétés effectives d'un style de texte. L'interface [ITextStyleEffectiveData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextstyleeffectivedata/) contient les propriétés de style de texte effectives.

L'exemple de code suivant montre comment obtenir les propriétés effectives du style de texte. Il suppose que la première forme de la première diapositive est une [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) avec un cadre de texte.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/ITextStyleEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto effectiveTextStyle = shape->get_TextFrame()->get_TextFrameFormat()->get_TextStyle()->GetEffective();
int levelCount = 9;

for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    auto effectiveStyleLevel = effectiveTextStyle->GetLevel(levelIndex);

    auto depth = effectiveStyleLevel->get_Depth();
    auto indent = effectiveStyleLevel->get_Indent();
    auto alignment = System::ObjectExt::ToString(effectiveStyleLevel->get_Alignment());
    auto fontAlignment = System::ObjectExt::ToString(effectiveStyleLevel->get_FontAlignment());

    System::Console::WriteLine(System::String(u"= Effective paragraph formatting for style level #") + levelIndex + u" =");
    System::Console::WriteLine(System::String(u"Depth: ") + depth);
    System::Console::WriteLine(System::String(u"Indent: ") + indent);
    System::Console::WriteLine(System::String(u"Alignment: ") + alignment);
    System::Console::WriteLine(System::String(u"Font alignment: ") + fontAlignment);
}

presentation->Dispose();
```

## **Obtenir la valeur effective de la hauteur de police**

Avec Aspose.Slides, vous pouvez obtenir la hauteur de police effective. L'exemple suivant montre comment la hauteur de police effective d'une portion change après que des valeurs locales de hauteur de police ont été définies à différents niveaux de la structure de la présentation.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 400.0f, 75.0f, false);
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portions = paragraph->get_Portions();
portions->Clear();

auto firstPortion = System::MakeObject<Portion>(u"Sample text with first portion");
auto secondPortion = System::MakeObject<Portion>(u" and second portion.");

portions->Add(firstPortion);
portions->Add(secondPortion);

System::Console::WriteLine(u"Effective font height just after creation:");
auto firstPortionFormat = firstPortion->get_PortionFormat();
auto secondPortionFormat = secondPortion->get_PortionFormat();

auto printEffectiveFontHeights = [&]()
{
    auto firstPortionFontHeight = firstPortionFormat->GetEffective()->get_FontHeight();
    auto secondPortionFontHeight = secondPortionFormat->GetEffective()->get_FontHeight();

    System::Console::WriteLine(System::String(u"Portion #0: ") + firstPortionFontHeight);
    System::Console::WriteLine(System::String(u"Portion #1: ") + secondPortionFontHeight);
};

printEffectiveFontHeights();

presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(24.0f);

System::Console::WriteLine(u"Effective font height after setting the presentation default font height:");
printEffectiveFontHeights();

paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(40.0f);

System::Console::WriteLine(u"Effective font height after setting paragraph default font height:");
printEffectiveFontHeights();

firstPortionFormat->set_FontHeight(55.0f);

System::Console::WriteLine(u"Effective font height after setting portion #0 font height:");
printEffectiveFontHeights();

secondPortionFormat->set_FontHeight(18.0f);

System::Console::WriteLine(u"Effective font height after setting portion #1 font height:");
printEffectiveFontHeights();

presentation->Save(u"SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Obtenir le format de remplissage effectif d'un tableau**

Avec Aspose.Slides, vous pouvez obtenir le format de remplissage effectif pour différentes parties d'un tableau. L'interface [IFillFormatEffectiveData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifillformateffectivedata/) contient les propriétés de formatage de remplissage effectif. Le formatage des cellules a une priorité plus élevée que le formatage des lignes, le formatage des lignes a une priorité plus élevée que le formatage des colonnes, et le formatage des colonnes a une priorité plus élevée que le formatage du tableau entier.

En conséquence, les propriétés de [ICellFormatEffectiveData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icellformateffectivedata/) sont utilisées pour dessiner la cellule du tableau. L'exemple de code suivant montre comment obtenir le format de remplissage effectif pour différentes parties du tableau. Il suppose que la première forme de la première diapositive est une [ITable](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itable/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/ICellFormatEffectiveData.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IColumnFormatEffectiveData.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/IRowFormatEffectiveData.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <DOM/Table/ITableFormatEffectiveData.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto tableFillFormatEffective = table->get_TableFormat()->GetEffective()->get_FillFormat();
auto rowFillFormatEffective = table->get_Row(0)->get_RowFormat()->GetEffective()->get_FillFormat();
auto columnFillFormatEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective()->get_FillFormat();
auto cellFillFormatEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective()->get_FillFormat();

presentation->Dispose();
```

## **FAQ**

### `GetEffective` renvoie-t-il un instantané ?

Pas toujours. Les données effectives représentent le formatage calculé après application de l'héritage, mais certains objets de données effectives peuvent être mis en cache en interne. Un appel ultérieur à `GetEffective` peut recalculer le formatage et actualiser le cache, de sorte qu'un objet précédemment obtenu ne doit pas être considéré comme un instantané durable.

### Quand faut‑il relire les propriétés effectives ?

Appelez `GetEffective` à nouveau après avoir modifié le formatage local, les styles parents, le formatage de la mise en page, le formatage du maître ou les paramètres par défaut de la présentation. L'appel suivant réévalue la hiérarchie de formatage et renvoie le résultat effectif actuel.

### La modification ou la suppression d'une diapositive de mise en page/maître affecte‑t‑elle les propriétés effectives déjà récupérées ?

Oui, mais le changement se reflète lors du prochain appel à `GetEffective`. Si une source de formatage parent est modifiée ou supprimée, les données effectives précédemment obtenues peuvent devenir obsolètes. Une fois `GetEffective` rappelé, Aspose.Slides réévalue l'arbre de formatage et les polices, couleurs, tailles ou autres valeurs peuvent changer.

### Puis‑je modifier les valeurs via les objets de données effectives ?

Non. Les objets de données effectives exposent uniquement les valeurs calculées. Apportez les modifications aux objets de formatage local, puis obtenez à nouveau les valeurs effectives.

### Que se passe‑t‑il si une propriété n'est pas définie au niveau de la forme, ni dans la mise en page/maître, ni dans les paramètres globaux ?

La valeur effective est déterminée par le mécanisme par défaut, qui inclut les valeurs par défaut de PowerPoint et d'Aspose.Slides. Cette valeur résolue devient alors partie des données effectives courantes.

### À partir d'une valeur de police effective, puis‑je savoir quel niveau a fourni la taille ou la police ?

Pas directement. Les données effectives renvoient la valeur finale. Pour identifier la source, vérifiez les valeurs locales au niveau de la portion, du paragraphe, du cadre de texte et des styles de texte sur la mise en page, le maître et la présentation afin de voir où apparaît la première définition explicite.

### Pourquoi les valeurs effectives ressemblent parfois à celles locales ?

Parce que la valeur locale s'est avérée finale (aucune héritage de niveau supérieur n'était nécessaire). Dans ce cas, la valeur effective correspond à la valeur locale.

### Quand faut‑il utiliser les propriétés effectives et quand se contenter des locales ?

Utilisez les données effectives lorsque vous avez besoin du résultat « tel qu'affiché » après l'application de tout héritage, par exemple pour aligner les couleurs, retraits ou tailles. Si vous devez conserver ces valeurs indépendamment des changements de formatage ultérieurs, copiez les propriétés requises dans votre propre objet. Si vous devez modifier le formatage à un niveau spécifique, modifiez les propriétés locales puis, si nécessaire, relisez les données effectives pour vérifier le résultat.