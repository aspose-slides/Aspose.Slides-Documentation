---
title: Gérer les cellules de tableau dans les présentations avec C++
linktitle: Gérer les cellules
type: docs
weight: 30
url: /fr/cpp/manage-cells/
keywords:
- cellule de tableau
- fusionner des cellules
- supprimer la bordure
- diviser la cellule
- image dans la cellule
- couleur d'arrière-plan
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Gérer les cellules de tableau PowerPoint en C++ : identifier les cellules fusionnées, supprimer les bordures, diviser les cellules et définir les couleurs d'arrière-plan ainsi que les images avec Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Aspose.Slides vous permet d'accéder et de modifier les cellules de tableau dans les présentations PowerPoint. Cet article explique comment identifier les cellules de tableau fusionnées, supprimer les bordures des cellules, travailler avec la numérotation des cellules après fusion ou séparation, changer la couleur d’arrière‑plan d’une cellule, et ajouter une image à l’intérieur d’une cellule de tableau. Les exemples montrent comment créer ou ouvrir une présentation, obtenir un tableau à partir d’une diapositive, mettre à jour le formatage des cellules via les propriétés de la cellule, et enregistrer la présentation modifiée au format PPTX.

Aspose.Slides utilise des indices zéro‑base pour accéder aux cellules du tableau dans l’ordre `(colonne, ligne)`.

## **Identifier une cellule de tableau fusionnée**

L’exemple ouvre une présentation existante et accède à la première forme de la première diapositive en tant que tableau. Il suppose que la diapositive et la forme existent et que la forme est bien un tableau. Il parcourt ensuite toutes les lignes et toutes les colonnes et utilise [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) pour identifier les cellules situées dans des zones fusionnées. Pour chaque correspondance, il affiche les coordonnées de la cellule dans l’ordre `ligne;colonne`, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), ainsi que les coordonnées de départ de la région, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) et [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/).

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

## **Supprimer les bordures d’une cellule de tableau**

Créez une [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) et ajoutez un tableau à sa première diapositive avec [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/). Les largeurs de colonne, hauteurs de ligne et la position du tableau sont spécifiées en points. L’exemple définit les quatre bordures de la cellule sur [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), les rendant invisibles.

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

## **Ajouter des bordures de cellule diagonales**

Utilisez [get_BorderDiagonalDown](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonaldown/) pour tracer une ligne du coin supérieur gauche au coin inférieur droit, et [get_BorderDiagonalUp](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonalup/) pour tracer une ligne du coin inférieur gauche au coin supérieur droit. Une diagonale peut marquer un en‑tête d’angle ; les deux diagonales peuvent former un X pour indiquer qu’une cellule n’est pas applicable.

Chaque diagonale est un [ILineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/). Utilisez [get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_fillformat/) pour accéder à son remplissage, appelez [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/set_filltype/) avec [FillType::Solid](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) et choisissez une couleur via [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/get_solidfillcolor/). Définissez l’épaisseur de la ligne avec [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) en points.

L’exemple crée trois cellules dans une même ligne : une diagonale rouge vers le bas, une diagonale bleue vers le haut, et les deux diagonales. Les bordures supérieure, inférieure, gauche et droite de la cellule restent inchangées.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({210, 210, 210});
auto rowHeights = MakeArray<double>({160});
auto table = slide->get_Shapes()->AddTable(45, 130, columnWidths, rowHeights);

auto downwardBorder = table->idx_get(0, 0)->get_CellFormat()->get_BorderDiagonalDown();
downwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
downwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
downwardBorder->set_Width(3);

auto upwardBorder = table->idx_get(1, 0)->get_CellFormat()->get_BorderDiagonalUp();
upwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
upwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
upwardBorder->set_Width(5);

auto crossDownwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalDown();
crossDownwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossDownwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
crossDownwardBorder->set_Width(3);

auto crossUpwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalUp();
crossUpwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossUpwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
crossUpwardBorder->set_Width(5);

presentation->Save(u"diagonal_cell_borders.pptx", SaveFormat::Pptx);
```

Une diagonale est une propriété de formatage, pas une division de cellule. Chaque cellule conserve un seul cadre de texte accessible via [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/); les régions de part et d’autre d’une diagonale ne peuvent pas être éditées indépendamment.

Le tableau enregistré, rendu dans Microsoft PowerPoint :

![Trois cellules de tableau montrant une diagonale rouge du coin supérieur gauche au coin inférieur droit, une diagonale bleue du coin inférieur gauche au coin supérieur droit, et les deux diagonales formant un X.](diagonal-cell-borders.png)

*De gauche à droite : diagonale descendante (rouge, 3 pt), diagonale ascendante (bleu, 5 pt) et les deux diagonales.*

## **Fusionner des cellules de tableau**

Utilisez [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) pour combiner une plage rectangulaire de cellules de tableau en une seule cellule. Spécifiez les cellules aux coins supérieur gauche et inférieur droit de la plage. Le dernier argument contrôle si la fusion peut inclure des cellules en dehors de la plage spécifiée ; `false` maintient la fusion à l’intérieur de cette plage.

L’exemple crée un tableau 4 × 4 avec des colonnes et lignes de 70 points, puis fusionne les quatre cellules centrales de `(1, 1)` à `(2, 2)`. La cellule résultante s’étend sur deux colonnes et deux lignes, tandis que la grille sous‑jacente du tableau conserve quatre colonnes et quatre lignes. Pour accéder au contenu ou au formatage de la cellule fusionnée, utilisez sa position supérieure gauche : `table->idx_get(1, 1)` dans cet exemple. Les autres positions de la plage fusionnée restent parties de la grille du tableau, de sorte que les indices des cellules situées hors de la plage ne changent pas.

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

## **Diviser des cellules de tableau**

La fusion des cellules dans l’exemple précédent préserve la grille du tableau. Diviser une cellule peut introduire une nouvelle colonne de grille et modifier les indices de colonne des cellules situées à sa droite. Aspose.Slides suit le modèle de grille des tableaux de PowerPoint.

Cet exemple crée un tableau 4 × 4 avec des colonnes et lignes de 70 points et appelle [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) sur la cellule `(1, 1)`. La moitié de la largeur de 70 points de la cellule est transmise pour créer deux cellules de largeur égale.

Après cette division, les deux moitiés sont accessibles via `table->idx_get(1, 1)` et `table->idx_get(2, 1)`. La grille du tableau possède maintenant cinq colonnes : les cellules originellement dans les colonnes 2 et 3 se déplacent respectivement vers les colonnes 3 et 4. Les indices de ligne demeurent inchangés. Utilisez ces indices de colonne mis à jour lors de l’accès aux cellules après la division.

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

<!-- visual-explanation:manage-cells:start -->
[![Une cellule non fusionnée de 70 points se divise en deux cellules de 35 points, ajoutant une cinquième colonne de grille et décalant les indices à sa droite.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*La division de largeur affecte la cellule (1, 1), en utilisant des indices zéro‑base (colonne, ligne). Les autres lignes conservent une cellule occupant les deux nouvelles positions de colonne.*
<!-- visual-explanation:manage-cells:end -->

### **Diviser les cellules fusionnées par étendue de ligne ou de colonne**

Pour préparer les cellules de modèle fusionnées à la population de données, utilisez [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) pour diviser le long d’une frontière de ligne existante, ou [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) pour diviser le long d’une frontière de colonne.

L’argument `index` compte les lignes dans la partie supérieure ou les colonnes dans la partie gauche de la division ; il est relatif à la région fusionnée :

- Division de ligne : `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- Division de colonne : `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

L’exemple suppose qu’une présentation possède un tableau comme première forme de la première diapositive, avec les cellules `(1, 2)` et `(1, 3)` fusionnées verticalement. En partant de la position inférieure, il utilise [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) et [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) pour localiser l’origine et vérifier les deux étendues. `SplitByRowSpan(1)` sépare alors les lignes 2 et 3 pour les noms de produit. Pour une fusion horizontale de deux colonnes, utilisez `SplitByColSpan(1)` à la place.

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

La grille du tableau et les indices des cellules environnantes restent inchangés. Récupérez les cellules résultantes par leurs coordonnées ; ici, les deux ont une étendue de 1 et [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) renvoie `False`. Des régions plus larges peuvent rester partiellement fusionnées après une division.

Le texte original et son formatage restent dans la cellule supérieure (ou gauche) ; la nouvelle cellule est vide mais hérite du formatage de la cellule tel que remplissage, bordures et marges. Remplissez les cellules après la division et définissez explicitement tout formatage de texte requis.

La présentation enregistrée contient des cellules distinctes « Product A » et « Product B » avec le formatage du modèle conservé. Consultez la [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) pour plus de détails.

### **Diviser une cellule à une hauteur spécifique**

[SplitByHeight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyheight/) prend la hauteur de la partie supérieure en points. [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) prend le nombre de lignes de grille existantes dans la partie supérieure. Pour centrer une cellule de 40 points dans la colonne de droite, soustrayez 40 de la hauteur réelle de la cellule et répartissez l’espace restant de façon égale au-dessus et au-dessous.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/ITextFrame.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({160, 160});
auto rowHeights = MakeArray<double>({140});

auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Left");

auto height = table->idx_get(1, 0)->get_Height();
auto margin = (height - 40) / 2;

table->idx_get(1, 0)->SplitByHeight(margin);
table->idx_get(1, 1)->SplitByHeight(40);
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Middle");

presentation->Save(u"split_by_height.pptx", SaveFormat::Pptx);
```

La première division ajoute une ligne de grille, laissant les 90 points inférieurs à `(1, 1)`. La seconde division cible cette cellule et ajoute une autre ligne en dessous. La colonne de droite contient maintenant `(1, 0)` à 50 points (`margin`), `(1, 1)` à 40 points, et `(1, 2)` à 50 points (`margin`). La cellule de gauche s’étend sur les trois lignes à sa hauteur originale de 140 points.

![La cellule de gauche occupe toute la hauteur du tableau à côté de trois cellules avec « Middle » au centre.](split-by-height.png)

## **Modifier la couleur d’arrière‑plan d’une cellule de tableau**

Cet exemple crée un tableau avec des colonnes de 150 points et des lignes de 50 points. Il utilise [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) pour sélectionner un remplissage plein et [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) pour accéder à la couleur de remplissage et la définir sur rouge pour la cellule `(2, 3)`, dans la troisième colonne et la quatrième ligne.

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

## **Ajouter une image à l’intérieur d’une cellule de tableau**

Placez l’image d’entrée dans le répertoire de travail avant d’exécuter cet exemple. Elle charge l’image avec [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) et l’ajoute à la collection d’images de la présentation avec [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). Elle affecte ensuite l’image au remplissage image de la cellule `(0, 0)`, la première cellule du tableau.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) étire l’image pour remplir la cellule, ce qui peut modifier son rapport d’aspect. Les largeurs de colonne et hauteurs de ligne sont exprimées en points. L’image chargée est libérée après son ajout à la présentation.

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

**Puis‑je définir des épaisseurs et des styles de ligne différents pour chaque côté d’une même cellule ?**

Oui. Les bordures [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/), [bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/), [left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/) et [right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) possèdent des propriétés séparées, de sorte que l’épaisseur et le style de chaque côté peuvent différer.

**Que se passe‑t‑il avec l’image si je modifie la taille de la colonne/ligne après avoir défini une image comme arrière‑plan de la cellule ?**

Le comportement dépend du [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile). Avec l’étirement, l’image s’adapte à la nouvelle cellule ; avec le carrelage, les carreaux sont recalculés.

**Puis‑je affecter un hyperlien à tout le contenu d’une cellule ?**

[Hyperlinks](/slides/fr/cpp/manage-hyperlinks/) sont définis au niveau du texte (portion) à l’intérieur du cadre de texte de la cellule ou au niveau de la table/forme entière. En pratique, vous affectez le lien à une portion ou à tout le texte de la cellule.

**Puis‑je définir des polices différentes au sein d’une même cellule ?**

Oui. Le cadre de texte d’une cellule prend en charge les [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (runs) avec un formatage indépendant — famille de police, style, taille et couleur.