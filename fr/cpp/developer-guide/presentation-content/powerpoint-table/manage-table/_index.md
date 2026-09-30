---
title: Gérer les tables de présentation en C++
linktitle: Gérer la table
type: docs
weight: 10
url: /fr/cpp/manage-table/
keywords:
- ajouter une table
- créer une table
- accéder à la table
- rapport d'aspect
- aligner le texte
- formatage du texte
- style de table
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Créer et modifier des tables dans les diapositives PowerPoint avec Aspose.Slides pour C++. Découvrez des exemples de code simples pour rationaliser vos flux de travail de tables."
---
## **Introduction**

Les tables dans PowerPoint organisent les informations en lignes et colonnes, ce qui facilite la lecture et la comparaison des valeurs.

Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) , l'interface [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) , la classe [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) , l'interface [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) , et d'autres types pour vous permettre de créer, mettre à jour et gérer les tables dans les présentations.

## **Créer une table à partir de zéro**

Créez une table en spécifiant sa position, les largeurs des colonnes et les hauteurs des lignes. Après l'avoir ajoutée à une diapositive, vous pouvez formater les bordures des cellules, fusionner les cellules et insérer du texte.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Obtenez une référence à la diapositive par son indice.
3. Définissez un tableau des largeurs de colonnes en points.
4. Définissez un tableau des hauteurs de lignes en points.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) à la diapositive via la méthode [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) .
6. Parcourez chaque [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) pour appliquer un formatage aux bordures supérieure, inférieure, droite et gauche.
7. Fusionnez les deux premières cellules de la première ligne du tableau.
8. Accédez à la cellule fusionnée via sa méthode [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) .
9. Définissez le texte dans la cellule fusionnée.
10. Enregistrez la présentation modifiée.

L'exemple ci‑dessus crée une table avec trois colonnes et cinq lignes à (100, 50) points. Il applique des bordures rouges d'une largeur de 5 points, fusionne les deux premières cellules de la première ligne, et enregistre le résultat sous le nom `table.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 50, 50, 50 });
auto rowHeights = System::MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 0), false);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Merged Cells");

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Numérotation dans une table standard**

Dans une table standard, les indices des cellules commencent à zéro et utilisent l'ordre (colonne, ligne). La première cellule a l'indice (0, 0).

Par exemple, les cellules d'une table de 4 colonnes et 4 lignes sont numérotées ainsi :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Cet exemple crée la table 4 × 4 illustrée ci‑dessus, avec des largeurs de colonnes et hauteurs de lignes de 70 points et des bordures de cellules rouges d'une largeur de 5 points. Les coordonnées illustrent les indices des cellules ; l'exemple laisse les cellules vides et enregistre la table sous le nom `StandardTables_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 70, 70, 70, 70 });
auto rowHeights = System::MakeArray<double>({ 70, 70, 70, 70 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

presentation->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Accéder à une table existante**

Les tables sont stockées dans la collection de formes d'une diapositive. Parcourez les formes pour localiser une table, puis utilisez l'interface [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) pour lire ou mettre à jour ses cellules.

1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Obtenez une référence à la diapositive contenant la table par son indice.
3. Parcourez les objets [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) et arrêtez‑vous lorsqu'une table est trouvée. Si la diapositive contient plusieurs tables, utilisez [get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/) pour identifier celle dont vous avez besoin.
4. Mettez à jour le texte dans la cellule cible.
5. Enregistrez la présentation modifiée.

L'exemple ci‑dessus ouvre `UpdateExistingTable.pptx` et trouve la première table de la première diapositive. Il définit la cellule à la colonne 0, ligne 1 à `New` et enregistre le résultat sous le nom `table1_out.pptx`. Le fichier d'entrée doit contenir au moins une diapositive, et la première table de cette diapositive doit avoir au moins une colonne et deux lignes.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");
auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (const auto& shape : System::IterateOver(slide->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shape))
    {
        table = System::ExplicitCast<ITable>(shape);
        break;
    }
}

if (table != nullptr)
{
    table->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");
    presentation->Save(u"table1_out.pptx", SaveFormat::Pptx);
}
```

Pour redimensionner une ligne dans une table existante et comprendre pourquoi sa hauteur réelle peut dépasser la hauteur minimale demandée, consultez [Contrôler la hauteur des lignes](/slides/fr/cpp/manage-rows-and-columns/#control-row-height).

## **Trouver la cellule qui possède un cadre de texte**

Lorsque du code générique de traitement de texte reçoit un [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) d'une table, utilisez [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) pour récupérer la [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) propriétaire. Pour un cadre de texte de cellule de table, [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) renvoie le propriétaire et [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) renvoie `nullptr`, même si la table elle‑même est une forme.

Les coordonnées de la cellule sont disponibles via les méthodes en lecture seule [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) et [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) . [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) fournit également une navigation en lecture seule : il renvoie le propriétaire mais ne change pas la propriété. Vérifiez toujours que la cellule renvoyée n'est pas `nullptr` avant de l'utiliser.

Pour un exemple complet qui identifie les propriétaires de cellules de tableau et de formes, y compris les formes associées aux nœuds SmartArt, voir [Recherche et remplacement de texte](/slides/fr/cpp/search-and-replace-text/) .

## **Aligner le texte dans une table**

Vous pouvez contrôler l'ancrage vertical et la direction du texte des cellules individuelles d'une table. L'exemple de cette section centre le texte dans la première cellule et le fait pivoter de 270 degrés.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Obtenez une référence à la diapositive par son indice.
3. Ajoutez un objet [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) à la diapositive.
4. Accédez à un objet [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) provenant de la table.
5. Accédez au premier [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) et définissez son texte et sa couleur.
6. Définissez l'ancrage vertical et la direction du texte de la cellule en utilisant [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) et [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/) .
7. Enregistrez la présentation modifiée.

Cet exemple crée une table 4 × 4 avec des largeurs de colonnes de 120 points et des hauteurs de lignes de 100 points. Il formate le texte dans la cellule (0, 0), ajoute des valeurs aux cellules restantes de la première ligne, et enregistre le résultat sous le nom `Vertical_Align_Text_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 120, 120, 120, 120 });
auto rowHeights = System::MakeArray<double>({ 100, 100, 100, 100 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

auto cell = table->idx_get(0, 0);
auto paragraph = cell->get_TextFrame()->get_Paragraphs()->idx_get(0);

auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Définir le format du texte au niveau du tableau**

Utilisez [SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/) pour appliquer le formatage du texte à toutes les cellules d'un tableau. Ses surcharges acceptent le formatage de portion, de paragraphe et de cadre de texte, ce qui vous permet de définir ces propriétés sans parcourir chaque cellule individuellement.

1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Obtenez une référence à la diapositive par son indice.
3. Accédez à un objet [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) depuis la diapositive.
4. Définissez la taille de la police en utilisant [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) pour le texte.
5. Définissez l'alignement du paragraphe et la marge droite en utilisant [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) et [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) .
6. Définissez la direction du texte en utilisant [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) .
7. Enregistrez la présentation modifiée.

L'exemple ci‑dessous ouvre `table.pptx`, qui doit contenir au moins une diapositive avec une table comme première forme. Il définit la taille de la police à 25 points, aligne les paragraphes à droite avec une marge droite de 20 points, et rend le texte vertical. La présentation formatée est enregistrée sous le nom `result.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
table->SetTextFormat(portionFormat);

auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
table->SetTextFormat(paragraphFormat);

auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Obtenir les propriétés du style de table**

Utilisez [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) pour lire le style prédéfini d'une table et [set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/) pour le définir. Cet exemple applique [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) à une table, affiche le nom du style prédéfini, et assigne le même style à une deuxième table. Les deux tables sont enregistrées dans `table-style.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 100, 150 });
auto rowHeights = System::MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

auto stylePreset = table->get_StylePreset();
System::Console::WriteLine(u"Table style preset: {0}", stylePreset);

auto anotherTable = slide->get_Shapes()->AddTable(10, 100, columnWidths, rowHeights);
anotherTable->set_StylePreset(stylePreset);

presentation->Save(u"table-style.pptx", SaveFormat::Pptx);
```

## **Verrouiller le rapport d'aspect d'une table**

Le rapport d'aspect d'une table est le rapport entre sa largeur et sa hauteur. Utilisez [set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/) pour verrouiller ce rapport pour une table.

L'exemple ci‑dessous ouvre `pres.pptx`, qui doit contenir au moins une diapositive avec une table comme première forme. Il affiche l'état actuel du verrouillage, active le verrouillage du rapport d'aspect, affiche l'état mis à jour (`True`), et enregistre le résultat sous le nom `pres-out.pptx`.

```cpp
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(true);
Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

presentation->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Puis-je activer la direction de lecture de droite à gauche (RTL) pour une table entière et le texte dans ses cellules ?**

Oui. La table expose une méthode [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/) , et les paragraphes possèdent [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/) . L'utilisation des deux garantit le bon ordre RTL et le rendu correct à l'intérieur des cellules.

**Comment puis‑je empêcher les utilisateurs de déplacer ou de redimensionner une table dans le fichier final ?**

Utilisez [shape locks](/slides/fr/cpp/applying-protection-to-presentation/) pour désactiver le déplacement, le redimensionnement, la sélection, etc. Ces verrous s'appliquent également aux tables.

**L'insertion d'une image à l'intérieur d'une cellule comme arrière‑plan est‑elle prise en charge ?**

Oui. Vous pouvez définir un [picture fill](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) pour une cellule ; l'image couvrira la zone de la cellule selon le mode choisi (étirement ou mosaïque).