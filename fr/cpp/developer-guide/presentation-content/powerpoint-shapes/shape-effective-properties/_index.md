---
title: Obtenir les propriétés effectives des formes à partir des présentations en C++
linktitle: Propriétés effectives
type: docs
weight: 50
url: /fr/cpp/shape-effective-properties/
keywords:
- propriétés de forme
- propriétés de caméra
- rig d'éclairage
- forme biseautée
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à utiliser Aspose.Slides pour C++ afin de distinguer le formatage local, hérité et effectif des formes dans les présentations PowerPoint."
---
## **Comprendre les propriétés locales, héritées et effectives**

Le formatage PowerPoint peut provenir de plusieurs sources. La valeur stockée directement sur un objet est sa **valeur locale**. Si cette valeur n’est pas définie, PowerPoint examine les sources de formatage parentes, telles qu’une valeur par défaut de paragraphe, un style de texte, une diapositive de disposition ou maître, un thème ou les valeurs par défaut au niveau de la présentation. Ces valeurs sont des **valeurs héritées**. La valeur qui reste après la résolution de toute la hiérarchie est la **valeur effective** — la valeur utilisée pour afficher l’objet.

Par exemple, une portion de texte peut ne pas définir sa propre **hauteur de police**. Sa **[hauteur de police](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseportionformat/)** locale est alors `std::numeric_limits<float>::quiet_NaN()`, ce qui signifie « non définie ici ». La portion peut hériter d’une hauteur de son paragraphe, du style de texte par défaut de la présentation ou d’une autre source applicable. Appeler **[GetEffective](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportionformat/)** sur le format de la portion renvoie la hauteur finale résolue.

Utilisez les deux types de données de formatage à des fins différentes :

- Lire ou modifier un objet de format local, tel que **[IPortionFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportionformat/)**, lorsque vous devez contrôler où une valeur est définie.  
- Lire un objet de données effectives, tel que **[IPortionFormatEffectiveData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportionformateffectivedata/)**, lorsque vous avez besoin du résultat final rendu. Les données effectives sont en lecture seule.

## **Comparer les valeurs locales, héritées et effectives**

L’exemple complet suivant crée une forme et applique des hauteurs de police au niveau de la présentation, du paragraphe et de la portion. Chaque étape affiche les valeurs définies à ces niveaux ainsi que la valeur effective résultante pour la même portion de texte. Il montre également pourquoi les données effectives doivent être relues après des modifications de formatage.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// Définir les valeurs héritées à deux niveaux différents.
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // Lire les données effectives après les modifications précédentes.
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// Une valeur locale sur la portion remplace les deux valeurs héritées.
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// Modifier une valeur héritée ne remplace pas une valeur locale existante.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// Effacer la valeur locale. La portion hérite maintenant à nouveau du paragraphe.
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// Effacer la valeur du paragraphe. La valeur par défaut de la présentation fournit maintenant le résultat.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La priorité dans cet exemple est le formatage local de la portion, puis le formatage du paragraphe, puis la valeur par défaut de la présentation. D’autres objets peuvent avoir des chaînes d’héritage différentes, mais le principe reste le même : une valeur explicite plus spécifique l’emporte, et **[GetEffective](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportionformat/)** renvoie le résultat final.

## **Obtenir les propriétés de texte effectives**

Le formatage du texte est réparti sur plusieurs objets :

- **[ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframeformat/)** résout les propriétés du cadre de texte telles que les marges, l’ancrage, l’ajustement automatique et la direction verticale du texte.  
- **[ITextStyle::GetEffective](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextstyle/)** résout le formatage des paragraphes pour chaque niveau de style de texte.  
- **[IParagraphFormat::GetEffective](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/)** résout les propriétés du paragraphe telles que l’alignement, le retrait et les puces.  
- **[IPortionFormat::GetEffective](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportionformat/)** résout les propriétés de caractère telles que la hauteur de police, le type de police, la couleur, le gras et l’italique.

Pour l’exemple suivant, le fichier `text-formatting.pptx` doit contenir au moins une diapositive et une **[IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/)** avec un cadre de texte non vide. L’IAutoShape peut se trouver à n’importe quelle position dans la collection de formes ; le code recherche un objet approprié et le valide avant utilisation.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **Obtenir les propriétés 3D effectives**

**[IThreeDFormat::GetEffective](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformat/)** renvoie un objet **[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ithreedformateffectivedata/)** qui regroupe tous les paramètres 3D résolus. Ses données **[camera](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icameraeffectivedata/)**, **[light rig](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilightrigeffectivedata/)**, **[top bevel](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapebeveleffectivedata/)** et **[bottom bevel](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapebeveleffectivedata/)** exposent les paramètres effectifs correspondants. Lire ces réglages associés ensemble facilite la compréhension de l’apparence 3D finale d’une forme.

Pour cet exemple, le fichier `shape-3d.pptx` doit contenir au moins une forme sur sa première diapositive. Appliquez des paramètres de caméra 3D, d’éclairage ou de chanfrein à cette forme si vous souhaitez que la sortie contienne des valeurs autres que les valeurs par défaut.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **Obtenir le format de tableau effectif**

Le formatage d’un tableau peut provenir du style de tableau et des formats appliqués à l’ensemble du tableau, à une colonne, à une ligne ou à une cellule individuelle. En cas de conflit entre des remplissages définis explicitement, la priorité est : cellule, ligne, colonne, puis tableau complet. Le format effectif d’une cellule est le format final utilisé pour dessiner cette cellule.

Pour cet exemple, le fichier `table-formatting.pptx` doit contenir au moins un tableau sur sa première diapositive. Le tableau doit comporter au moins une ligne et une colonne. Le code recherche un **[ITable](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itable/)** au lieu de supposer que la première forme est un tableau.

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

Si vous avez besoin de la couleur plutôt que du seul type de remplissage, vérifiez d’abord le **[FillType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifillformateffectivedata/)** effectif, puis lisez la propriété correspondant à ce type — par exemple, **[SolidFillColor](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifillformateffectivedata/)** pour un remplissage uni.

## **Relire les données effectives après les modifications**

Les données effectives décrivent la hiérarchie de formatage au moment où elles sont résolues. Appelez **GetEffective** à nouveau après avoir modifié quoi que ce soit pouvant participer à cette hiérarchie, y compris :

- le formatage local de l’objet ;  
- les valeurs par défaut du paragraphe ou du cadre de texte ;  
- le style de tableau, le tableau, la colonne, la ligne ou le format de cellule ;  
- le formatage de la disposition ou de la diapositive maître ;  
- les données du thème ou les valeurs par défaut au niveau de la présentation ;  
- la disposition ou le maître assigné à une diapositive.

Ne conservez pas un objet de données effectives comme un instantané permanent. Aspose.Slides peut mettre en cache certaines données effectives en interne, et un appel ultérieur à **GetEffective** peut rafraîchir ces données. Si vous devez comparer des valeurs avant et après une modification, copiez les valeurs scalaires dont vous avez besoin — par exemple, une hauteur de police, une couleur, un alignement ou une largeur de chanfrein—dans vos propres variables avant d’effectuer la modification.

Pour modifier une valeur, mettez à jour l’objet de format local approprié, puis appelez **GetEffective** pour vérifier le résultat. Les objets de données effectives eux‑mêmes sont en lecture seule.

## **FAQ**

**Comment savoir quel niveau a fourni une valeur effective ?**  
Les données effectives contiennent la valeur finale, pas sa source. Inspectez les objets locaux applicables du niveau le plus spécifique vers l’extérieur. Pour le texte, cela peut inclure la portion, le paragraphe, le cadre de texte, la disposition, le maître, le thème et les valeurs par défaut de la présentation. Les valeurs non définies telles que `std::numeric_limits<float>::quiet_NaN()` ou `nullptr` indiquent que la recherche se poursuit à un autre niveau.

**Que se passe‑t‑il lorsqu’aucun niveau ne définit une propriété ?**  
Aspose.Slides résout la valeur par défaut appropriée de PowerPoint ou de la bibliothèque. Cette valeur résolue apparaît dans les données effectives même si aucun objet local ne la définit explicitement.

**Pourquoi une valeur effective est‑elle parfois égale à la valeur locale ?**  
La valeur locale a remporté le calcul d’héritage. Cela est attendu lorsque la propriété est explicitement définie sur l’objet et qu’aucune règle plus spécifique ne la surpasse.

**Quand faut‑il utiliser les données locales plutôt que les données effectives ?**  
Utilisez les données locales pour inspecter ou modifier un niveau de formatage spécifique. Utilisez les données effectives lorsque vous avez besoin de l’apparence finale après l’héritage, les règles de thème et les styles applicables. Le **[exemple complet de comparaison](#compare-local-inherited-and-effective-values)** montre les deux approches dans le même flux de travail.