---
title: Gérer les cellules de tableau dans les présentations avec C++
linktitle: Gérer les cellules
type: docs
weight: 30
url: /fr/cpp/manage-cells/
keywords:
- cellule de tableau
- fusion de cellules
- supprimer la bordure
- division de cellules
- image dans la cellule
- couleur d'arrière-plan
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Gérez les cellules de tableau PowerPoint en C++: identifiez les cellules fusionnées, supprimez les bordures, scindez les cellules, et définissez les couleurs d'arrière-plan et les images avec Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Aspose.Slides vous permet d'accéder aux cellules de tableau et de les modifier dans les présentations PowerPoint. Cet article explique comment identifier les cellules de tableau fusionnées, supprimer les bordures des cellules, travailler avec la numérotation des cellules après fusion ou séparation, changer la couleur d'arrière-plan d'une cellule et ajouter une image à l'intérieur d'une cellule de tableau. Les exemples montrent comment créer ou ouvrir une présentation, obtenir un tableau à partir d'une diapositive, mettre à jour le formatage des cellules via les propriétés des cellules et enregistrer la présentation modifiée au format PPTX.

Aspose.Slides utilise des indices zéro-bas pour accéder aux cellules de tableau dans l'ordre `(column, row)`.

## **Identifier une cellule de tableau fusionnée**

L'exemple ouvre une présentation existante et accède à la première forme de la première diapositive en tant que tableau. Il suppose que la diapositive et la forme existent et que la forme est un tableau. Il parcourt ensuite toutes les lignes et colonnes et utilise [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) pour identifier les cellules dans les régions fusionnées. Pour chaque correspondance, il affiche les coordonnées de la cellule dans l'ordre `row;column`, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), et les coordonnées de départ de la région, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) et [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_table.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto rowCount = table->get_Rows()->get_Count();
for (auto rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    auto columnCount = table->get_Columns()->get_Count();
    for (auto columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        auto cell = table->idx_get(columnIndex, rowIndex);
        if (cell->get_IsMergedCell())
        {
            Console::WriteLine(u"Cell {0};{1} belongs to a merged region with RowSpan={2} and ColSpan={3} starting at {4};{5}.", rowIndex, columnIndex, cell->get_RowSpan(), cell->get_ColSpan(), cell->get_FirstRowIndex(), cell->get_FirstColumnIndex());
        }
    }
}
```

## **Supprimer les bordures des cellules de tableau**

Créez une [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) et ajoutez un tableau à la première diapositive avec [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/). Les largeurs de colonnes, hauteurs de lignes et la position du tableau sont spécifiées en points. L'exemple définit les quatre bordures de la cellule sur [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), les rendant invisibles.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <system/enumerator_adapter.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({50, 50, 50, 50});
auto rowHeights = MakeArray<double>({50, 30, 30, 30, 30});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

for (const auto& row : IterateOver(table->get_Rows()))
    for (const auto& cell : IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Fusionner des cellules de tableau**

Utilisez [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) pour combiner une plage rectangulaire de cellules de tableau en une seule cellule. Spécifiez les cellules aux coins supérieur gauche et inférieur droit de la plage. Le dernier argument contrôle si la fusion peut inclure des cellules en dehors de la plage spécifiée ; `false` maintient la fusion à l'intérieur de cette plage.

L'exemple crée un tableau 4 × 4 avec des colonnes et des lignes de 70 points, puis fusionne les quatre cellules centrales de `(1, 1)` à `(2, 2)`. La cellule résultante s'étend sur deux colonnes et deux lignes, tandis que la grille sous‑jacente du tableau conserve quatre colonnes et quatre lignes. Pour accéder au contenu ou au formatage de la cellule fusionnée, utilisez sa position supérieure gauche : `table->idx_get(1, 1)` dans cet exemple. Les autres positions de la plage fusionnée restent parties de la grille du tableau, de sorte que les indices des cellules en dehors de la plage ne changent pas.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 2), false);

presentation->Save(u"merged_cells.pptx", SaveFormat::Pptx);
```

## **Diviser les cellules de tableau**

La fusion des cellules dans l'exemple précédent préserve la grille du tableau. Diviser une cellule peut introduire une nouvelle colonne de grille et modifier les indices de colonne des cellules situées à droite. Aspose.Slides suit le modèle de grille de tableau de PowerPoint.

Cet exemple crée un tableau 4 × 4 avec des colonnes et des lignes de 70 points et appelle [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) sur la cellule `(1, 1)`. La moitié de la largeur de 70 points de la cellule est utilisée pour créer deux cellules de largeur égale.

Après cette division, les deux moitiés sont accessibles via `table->idx_get(1, 1)` et `table->idx_get(2, 1)`. La grille du tableau possède maintenant cinq colonnes : les cellules initialement dans les colonnes 2 et 3 se déplacent respectivement vers les colonnes 3 et 4. Les indices de ligne restent inchangés. Utilisez ces nouveaux indices de colonne lorsque vous accédez aux cellules après la division.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(1, 1)->SplitByWidth(table->idx_get(1, 1)->get_Width() / 2);

presentation->Save(u"split_cells.pptx", SaveFormat::Pptx);
```

### **Diviser les cellules fusionnées par étendue de ligne ou de colonne**

Pour préparer des cellules de modèle fusionnées à la population de données, utilisez [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) pour découper le long d'une frontière de ligne existante, ou [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) pour découper le long d'une frontière de colonne.

L'argument `index` compte les lignes dans la partie supérieure ou les colonnes dans la partie gauche de la division ; il est relatif à la région fusionnée :

- Fractionnement de ligne : `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- Fractionnement de colonne : `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

L'exemple suppose qu'une présentation possède un tableau comme première forme sur la première diapositive, avec `(1, 2)` et `(1, 3)` fusionnés verticalement. En partant de la position inférieure, il utilise [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) et [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) pour localiser l'origine et vérifie les deux étendues. `SplitByRowSpan(1)` sépare alors les lignes 2 et 3 pour les noms de produits. Pour une fusion horizontale de deux colonnes, utilisez `SplitByColSpan(1)` à la place.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table_template.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto selectedCell = table->idx_get(1, 3);
auto firstColumnIndex = selectedCell->get_FirstColumnIndex();
auto firstRowIndex = selectedCell->get_FirstRowIndex();
auto mergedCell = table->idx_get(firstColumnIndex, firstRowIndex);

if (mergedCell->get_IsMergedCell() && mergedCell->get_RowSpan() == 2 && mergedCell->get_ColSpan() == 1)
{
    mergedCell->SplitByRowSpan(1);

    // Récupérer les cellules résultantes du tableau après la division.
    auto upperCell = table->idx_get(firstColumnIndex, firstRowIndex);
    auto lowerCell = table->idx_get(firstColumnIndex, firstRowIndex + 1);
    Console::WriteLine(u"Upper cell merged: {0}", upperCell->get_IsMergedCell());
    Console::WriteLine(u"Lower cell merged: {0}", lowerCell->get_IsMergedCell());

    upperCell->get_TextFrame()->set_Text(u"Product A");
    lowerCell->get_TextFrame()->set_Text(u"Product B");

    presentation->Save(u"split_template.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Select a merged region spanning exactly two rows and one column.");
}
```

La grille du tableau et les indices des cellules environnantes restent inchangés. Récupérez les cellules résultantes par leurs coordonnées ; ici, les deux ont une étendue de 1 et [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) indique `False`. Des régions plus grandes peuvent rester partiellement fusionnées après une division.

Le texte original et son formatage restent dans la cellule supérieure (ou gauche) ; la nouvelle cellule est vide mais hérite du formatage de la cellule comme le remplissage, les bordures et les marges. Remplissez les cellules après la division et définissez explicitement tout formatage de texte requis.

La présentation enregistrée contient des cellules séparées « Product A » et « Product B » avec le formatage du modèle conservé. Consultez la [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) pour plus de détails.

## **Modifier la couleur d'arrière-plan d'une cellule de tableau**

Cet exemple crée un tableau avec des colonnes de 150 points et des lignes de 50 points. Il utilise [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) pour sélectionner un remplissage uni et [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) pour accéder à la couleur de remplissage et la définir sur rouge pour la cellule `(2, 3)`, dans la troisième colonne et la quatrième ligne.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <drawing/color.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({50, 50, 50, 50, 50});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"cell_background_color.pptx", SaveFormat::Pptx);
```

## **Ajouter une image à l'intérieur d'une cellule de tableau**

Placez l'image d'entrée dans le répertoire de travail avant d'exécuter cet exemple. Elle charge l'image avec [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) et l'ajoute à la collection d'images de la présentation avec [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). Elle assigne ensuite l'image au remplissage image de la cellule `(0, 0)`, la première cellule du tableau.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) étire l'image pour remplir la cellule, ce qui peut modifier son ratio d'aspect. Les largeurs de colonnes et les hauteurs de lignes sont exprimées en points. L'image chargée est libérée après avoir été ajoutée à la présentation.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IImageCollection.h>
#include <IImage.h>
#include <DOM/IPPImage.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Table/ICellFormat.h>
#include <Util/Images.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({100, 100, 100, 100, 90});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto image = Images::FromFile(u"aspose_logo.jpg");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Picture);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

presentation->Save(u"table_cell_with_image.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Puis-je définir des épaisseurs et styles de ligne différents pour chaque côté d'une même cellule ?**

Oui. Les bordures [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) possèdent des propriétés distinctes, de sorte que l'épaisseur et le style de chaque côté peuvent différer.

**Que se passe-t-il pour l'image si je modifie la taille de la colonne/ligne après avoir défini une image comme arrière-plan de la cellule ?**

Le comportement dépend du [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile). En mode étirement, l'image s'ajuste à la nouvelle cellule ; en mode mosaïque, les tuiles sont recalculées.

**Puis-je attribuer un hyperlien à tout le contenu d'une cellule ?**

[Hyperlinks](/slides/fr/cpp/manage-hyperlinks/) sont définis au niveau du texte (portion) à l'intérieur du cadre texte de la cellule ou au niveau de l'ensemble du tableau/forme. En pratique, vous attribuez le lien à une portion ou à l'ensemble du texte de la cellule.

**Puis-je définir des polices différentes au sein d'une même cellule ?**

Oui. Le cadre texte d'une cellule prend en charge les [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (runs) avec un formatage indépendant — famille de police, style, taille et couleur.