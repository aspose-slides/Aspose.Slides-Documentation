---
title: Gérer les lignes et les colonnes dans les tableaux PowerPoint avec C++
linktitle: Lignes et colonnes
type: docs
weight: 20
url: /fr/cpp/manage-rows-and-columns/
keywords:
- ligne de tableau
- colonne de tableau
- première ligne
- en-tête de tableau
- cloner ligne
- cloner colonne
- copier ligne
- copier colonne
- supprimer ligne
- supprimer colonne
- formatage du texte de ligne
- formatage du texte de colonne
- style de tableau
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Gérez les lignes et colonnes de tableau dans PowerPoint avec Aspose.Slides pour C++ et accélérez la modification des présentations et la mise à jour des données."
---
## **Introduction**

Aspose.Slides for C++ vous permet de gérer la structure et le formatage des tableaux dans les présentations PowerPoint via la classe [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) et l’interface [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/). Vous pouvez désigner une ligne d’en‑tête, cloner ou supprimer des lignes et des colonnes, et appliquer un formatage de texte à une ligne ou une colonne entière.

Cet article explique ces opérations avec des exemples C++. Il montre également comment récupérer le préréglage de style d’un tableau pour le réutiliser. Les index des lignes et des colonnes sont basés sur zéro.

## **Control Row Height**

Utilisez [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) pour définir la hauteur minimale d’une ligne en points. Il s’agit d’une borne inférieure, pas d’une hauteur fixe. [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) renvoie la hauteur réelle ; cette valeur ne peut pas être définie directement. Accédez à la ligne via [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/).

L’exemple charge [row-height-input.pptx](row-height-input.pptx), qui contient un tableau comme première forme sur la première diapositive. Sa première ligne commence à 70 points. Les cellules utilisent du texte Arial de 18 points, avec retour à la ligne et des marges supérieures et inférieures de 6 points ; le texte plus long de la deuxième colonne se répartit sur plusieurs lignes. L’exemple augmente le minimum à 100 points, puis le réduit à 20 points, affiche la hauteur réelle après chaque modification et enregistre les deux résultats.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRow.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"row-height-input.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
auto row = table->get_Rows()->idx_get(0);

row->set_MinimalHeight(100);
Console::WriteLine(u"Increased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-increased.pptx", SaveFormat::Pptx);

row->set_MinimalHeight(20);
Console::WriteLine(u"Decreased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-decreased.pptx", SaveFormat::Pptx);
```

Avec la présentation fournie, augmenter le minimum ajoute de l’espace à la ligne. Le réduire supprime cet espace supplémentaire, mais la hauteur réelle reste supérieure à 20 points parce que le texte et les marges des cellules nécessitent plus de place. Réduire uniquement le minimum ne peut pas forcer la ligne en dessous de l’espace requis par son contenu.

Plusieurs facteurs influencent la hauteur réelle :

- **Texte et taille de police :** un texte plus long, des sauts de ligne explicites ou une police plus grande peuvent nécessiter plus d’espace vertical.  
- **Enveloppement et largeur de colonne :** avec l’enveloppement actif, réduire la largeur de colonne avec [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) peut produire davantage de lignes. Une colonne plus large peut réduire l’espace vertical nécessaire.  
- **Marges des cellules :** [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) et [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) contrôlent les marges qui ajoutent de l’espace vertical. [ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) et [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) contrôlent les marges qui réduisent la largeur disponible pour le texte et peuvent entraîner un nouvel enveloppement.

Pour ce tableau sans cellules fusionnées, la cellule qui nécessite le plus d’espace vertical détermine la limite inférieure dictée par le contenu pour toute la ligne. Pour raccourcir la ligne, il peut également être nécessaire de réduire le texte, la taille de la police ou les marges, ou d’élargir une colonne.

Les images ci‑dessous montrent le même tableau à la même échelle. Dans l’exécution .NET de référence affichée ici, les hauteurs réelles étaient de 70, 100 et 55,2 points : la ligne finale est restée plus haute que son minimum de 20 points. Les mesures précises du texte peuvent varier selon les polices disponibles dans votre environnement. Téléchargez les résultats enregistrés : [increased minimum](row-height-increased.pptx) et [decreased minimum](row-height-decreased.pptx).

| Original : minimum 70 pt, hauteur réelle 70 pt | Augmenté : minimum 100 pt, hauteur réelle 100 pt | Réduit : minimum 20 pt, hauteur réelle 55,2 pt |
| --- | --- | --- |
| ![Tableau original avec une première ligne de 70 points.](row-height-before.png) | ![Tableau après avoir augmenté le minimum de la première ligne à 100 points.](row-height-increased.png) | ![Tableau après avoir réduit le minimum de la première ligne à 20 points ; le texte enveloppé maintient la ligne plus haute que le minimum.](row-height-decreased.png) |

## **Set the First Row as a Header**

Utilisez la méthode [set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) pour marquer la première ligne comme en‑tête. Son apparence dépend du style de tableau appliqué au tableau.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
2. Accédez à la première diapositive.  
3. Accédez au tableau stocké comme première forme sur la diapositive.  
4. Activez le format d’en‑tête pour sa première ligne.  
5. Enregistrez la présentation modifiée.

L’exemple nécessite `table.pptx` contenant un tableau comme première forme sur la première diapositive. Il active le format d’en‑tête pour la première ligne et enregistre `First_row_header.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
table->set_FirstRow(true);

presentation->Save(u"First_row_header.pptx", SaveFormat::Pptx);
```

## **Clone a Table Row or Column**

Clonez des lignes ou des colonnes pour réutiliser leur contenu et leur formatage. Vous pouvez ajouter une copie à la fin du tableau ou l’insérer à une position précise.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
2. Accédez à la première diapositive.  
3. Définissez les largeurs des colonnes et les hauteurs des lignes.  
4. Ajoutez un tableau avec la méthode [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).  
5. Clonez les lignes requises.  
6. Clonez les colonnes requises.  
7. Enregistrez la présentation modifiée.

L’exemple nécessite `Test.pptx` avec au moins une diapositive. Il crée un tableau de trois colonnes et cinq lignes, avec des dimensions exprimées en points. Il ajoute des copies de la première ligne et de la première colonne, puis insère des copies de la deuxième ligne et de la deuxième colonne à l’index 3 (quatrième position). Le tableau résultant comporte sept lignes et cinq colonnes. L’argument `false` désactive le clonage dans les lignes ou colonnes fusionnées adjacentes ; ce tableau n’a pas de cellules fusionnées.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 50, 50, 50 });
auto rowHeights = MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 1");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 2");
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

table->idx_get(0, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 1");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 2");
table->get_Rows()->InsertClone(3, table->get_Rows()->idx_get(1), false);

table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);
table->get_Columns()->InsertClone(3, table->get_Columns()->idx_get(1), false);

presentation->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Remove a Row or Column from a Table**

Supprimez les lignes ou colonnes qui ne sont plus nécessaires dans un tableau. La suppression d’un élément décale les index des lignes ou colonnes qui le suivent.

1. Créez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
2. Accédez à la première diapositive.  
3. Définissez les largeurs des colonnes et les hauteurs des lignes.  
4. Ajoutez un tableau avec la méthode [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).  
5. Supprimez la deuxième ligne et la deuxième colonne.  
6. Enregistrez la présentation modifiée.

Cet exemple crée un tableau trois‑par‑trois et supprime la ligne et la colonne à l’index 1, laissant un tableau deux‑par‑deux dans `TestTable_out.pptx`. Les dimensions sont en points. L’argument `false` désactive la suppression des lignes ou colonnes fusionnées adjacentes ; ce tableau n’a pas de cellules fusionnées.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 50, 30 });
auto rowHeights = MakeArray<double>({ 30, 50, 30 });
auto table = slide->get_Shapes()->AddTable(100, 100, columnWidths, rowHeights);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

presentation->Save(u"TestTable_out.pptx", SaveFormat::Pptx);
```

## **Set Text Formatting on the Table Row Level**

Appliquez le formatage du texte à une ligne entière pour garder la cohérence de ses cellules. Vous pouvez définir les propriétés de police, le format de paragraphe et la direction du texte sans formater chaque cellule individuellement.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
2. Accédez au tableau sur la première diapositive.  
3. Définissez la hauteur de police avec [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) pour la première ligne.  
4. Définissez l’alignement et la marge droite du paragraphe avec [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) et [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) pour la première ligne.  
5. Définissez la direction du texte avec [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) pour la deuxième ligne.  
6. Enregistrez la présentation modifiée.

L’exemple nécessite `table.pptx` contenant un tableau comme première forme sur la première diapositive et au moins deux lignes. Il applique du texte de 25 points, un alignement à droite et une marge droite de paragraphe de 20 points à la première ligne, puis définit du texte vertical dans la deuxième ligne.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IRow.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"row_formatting.pptx", SaveFormat::Pptx);
```

## **Set Text Formatting on the Table Column Level**

Appliquez le formatage du texte à une colonne entière pour garder la cohérence de ses cellules. Vous pouvez définir les propriétés de police, le format de paragraphe et la direction du texte sans formater chaque cellule individuellement.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
2. Accédez au tableau sur la première diapositive.  
3. Définissez la hauteur de police avec [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) pour la première colonne.  
4. Définissez l’alignement et la marge droite du paragraphe avec [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) et [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) pour la première colonne.  
5. Définissez la direction du texte avec [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) pour la deuxième colonne.  
6. Enregistrez la présentation modifiée.

L’exemple nécessite `table.pptx` contenant un tableau comme première forme sur la première diapositive et au moins deux colonnes. Il applique du texte de 25 points, un alignement à droite et une marge droite de paragraphe de 20 points à la première colonne, puis définit du texte vertical dans la deuxième colonne.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IColumn.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"column_formatting.pptx", SaveFormat::Pptx);
```

## **Get Table Style Properties**

Utilisez la méthode [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) pour récupérer le préréglage appliqué à un tableau et le réutiliser sur un autre tableau. Cela identifie le préréglage plutôt que les remplacements de formatage de cellule individuels.

L’exemple crée un tableau, applique [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) et lit le préréglage. Il affiche `DarkStyle1` et enregistre le tableau dans `table.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <DOM/TableStylePreset.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 150 });
auto rowHeights = MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

Console::WriteLine(u"{0}", table->get_StylePreset());

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Puis‑je appliquer les thèmes/styles PowerPoint à un tableau déjà créé ?**

Oui. Le tableau hérite du thème de la diapositive/disposition/maître, et vous pouvez toujours remplacer les remplissages, bordures et couleurs de texte au‑dessus de ce thème.

**Puis‑je trier les lignes d’un tableau comme dans Excel ?**

Non, les tableaux Aspose.Slides ne possèdent pas de fonction de tri ou de filtres intégrée. Triez d’abord vos données en mémoire, puis reconstituez les lignes du tableau dans cet ordre.

**Puis‑je avoir des colonnes à bandes (alternées) tout en conservant des couleurs personnalisées sur des cellules spécifiques ?**

Oui. Activez les colonnes à bandes, puis remplacez les cellules spécifiques avec un formatage local ; le formatage au niveau de la cellule l’emporte sur le style du tableau.