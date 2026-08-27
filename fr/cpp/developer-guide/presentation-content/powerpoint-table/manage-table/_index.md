---
title: Gestion des tableaux de présentation en C++
linktitle: Gérer le tableau
type: docs
weight: 10
url: /fr/cpp/manage-table/
keywords:
- ajouter un tableau
- créer un tableau
- accéder au tableau
- ratio d'aspect
- aligner le texte
- formatage du texte
- style de tableau
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Créez et modifiez des tableaux dans les diapositives PowerPoint avec Aspose.Slides pour C++. Découvrez des exemples de code simples pour rationaliser vos flux de travail de tableaux."
---
## **Introduction**

Un tableau dans PowerPoint est un moyen efficace d'afficher et de présenter des informations. Les informations dans une grille de cellules (organisées en lignes et colonnes) sont simples et faciles à comprendre.

Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/fr/cpp/aspose.slides/table/) l'interface [ITable](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itable/) la classe [Cell](https://reference.aspose.com/slides/fr/cpp/aspose.slides/cell/) l'interface [ICell](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icell/) ainsi que d'autres types pour vous permettre de créer, mettre à jour et gérer des tableaux dans tous les types de présentations. 

## **Créer un tableau à partir de zéro**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive via son indice. 
3. Définissez un tableau de `columnWidth`.
4. Définissez un tableau de `rowHeight`.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itable/) à la diapositive via la méthode [AddTable()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/addtable/).
6. Itérez chaque [ICell](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icell/) pour appliquer le formatage aux bordures supérieure, inférieure, droite et gauche.
7. Fusionnez les deux premières cellules de la première ligne du tableau. 
8. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/textframe/) d'un [ICell](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icell/).
9. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/textframe/).
10. Enregistrez la présentation modifiée.

Ce code C++ montre comment créer un tableau dans une présentation :

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Instancie une classe Presentation qui représente un fichier PPTX
// Accède à la première diapositive
// Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
// Ajoute une forme de tableau à la diapositive
// Définit le format de bordure pour chaque cellule
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
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
// Fusionne les cellules 1 et 2 de la ligne 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Ajoute du texte à la cellule fusionnée
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Enregistre la présentation sur le disque
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Numérotation dans un tableau standard**

Dans un tableau standard, la numérotation des cellules est simple et commence à zéro. La première cellule d'un tableau est indexée comme 0,0 (colonne 0, ligne 0). 

Par exemple, les cellules d'un tableau de 4 colonnes et 4 lignes sont numérotées ainsi :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ce code C++ montre comment spécifier la numérotation des cellules dans un tableau :

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Instancie une classe Presentation qui représente un fichier PPTX
auto pres = System::MakeObject<Presentation>();

// Accède à la première diapositive
auto sld = pres->get_Slides()->idx_get(0);

// Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Ajoute une forme de tableau à la diapositive
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Définit le format de bordure pour chaque cellule
for (const auto& row : tbl->get_Rows())
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

// Enregistre la présentation sur le disque
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Accéder à un tableau existant**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).

2. Obtenez une référence à la diapositive contenant le tableau via son indice. 

3. Créez un objet [ITable](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itable/) et définissez-le sur null.

4. Itérez tous les objets [IShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/) jusqu'à ce que le tableau soit trouvé.

   Si vous pensez que la diapositive que vous traitez contient un seul tableau, vous pouvez simplement vérifier toutes les formes qu'elle contient. Lorsqu'une forme est identifiée comme un tableau, vous pouvez la convertir en objet [Table](https://reference.aspose.com/slides/fr/cpp/aspose.slides/table/) . Cependant, si la diapositive contient plusieurs tableaux, il vaut mieux rechercher le tableau requis via son [set_AlternativeText()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/set_alternativetext/).

5. Utilisez l'objet [ITable](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itable/) pour travailler avec le tableau. Dans l'exemple ci‑dessus, nous avons ajouté une nouvelle ligne au tableau.

6. Enregistrez la présentation modifiée.

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Instancie une classe Presentation qui représente un fichier PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Accède à la première diapositive
auto sld = pres->get_Slides()->idx_get(0);

// Initialise une Table nulle
System::SharedPtr<ITable> tbl;

// Parcourt les formes et définit une référence vers le tableau trouvé
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Définit le texte pour la première colonne de la deuxième ligne
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Enregistre la présentation modifiée sur le disque
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Trouver la cellule qui possède un TextFrame**

Lorsque du code générique de traitement de texte reçoit un [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) d'un tableau, utilisez [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/get_parentcell/) pour récupérer la [ICell](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icell/) propriétaire. Pour un cadre de texte d'une cellule de tableau, [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/get_parentcell/) renvoie le propriétaire et [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/get_parentshape/) renvoie `nullptr`, même si le tableau lui‑même est une forme.

Les coordonnées de la cellule sont disponibles via les méthodes en lecture seule [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icell/get_firstcolumnindex/) et [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icell/get_firstrowindex/). [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/get_parentcell/) fournit également une navigation en lecture seule : il renvoie le propriétaire sans modifier la propriété. Vérifiez toujours que la cellule renvoyée n'est pas `nullptr` avant de l'utiliser.

Pour un exemple complet qui identifie les propriétaires de cellules de tableau et de formes, y compris les formes associées aux nœuds SmartArt, consultez [Search and Replace Text](/slides/fr/cpp/search-and-replace-text/).

## **Aligner le texte dans un tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive via son indice. 
3. Ajoutez un objet [ITable](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itable/) à la diapositive. 
4. Accédez à un objet [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) depuis le tableau. 
5. Accédez au [IParagraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/) de l'[ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/).
6. Alignez le texte verticalement.
7. Enregistrez la présentation modifiée.

```c++
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
#include <DOM/ISlideCollection.h>
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

// Crée une instance de la classe Presentation
auto presentation = System::MakeObject<Presentation>();

// Obtient la première diapositive
auto slide = presentation->get_Slides()->idx_get(0);

// Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Ajoute la forme de tableau à la diapositive
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Accède au cadre de texte
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Crée l'objet Paragraph pour le cadre de texte
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Crée l'objet Portion pour le paragraphe
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Aligne le texte verticalement
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Enregistre la présentation sur le disque
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Définir le format du texte au niveau du tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive via son indice. 
3. Accédez à un objet [ITable](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itable/) depuis la diapositive.
4. Définissez la [set_FontHeight()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/baseportionformat/set_fontheight/) pour le texte. 
5. Définissez les [set_Alignment()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_alignment/) et [set_MarginRight()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Définissez la [set_TextVerticalType()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Enregistrez la présentation modifiée. 

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Crée une instance de la classe Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Supposons que la première forme sur la première diapositive soit un tableau
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Définit la hauteur de police des cellules du tableau
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Définit l'alignement du texte des cellules du tableau et la marge droite en un seul appel
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Définit le type de texte vertical des cellules du tableau
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Obtenir les propriétés de style du tableau**

Aspose.Slides vous permet de récupérer les propriétés de style d'un tableau afin de pouvoir utiliser ces informations pour un autre tableau ou ailleurs. Ce code C++ montre comment obtenir les propriétés de style à partir d'un style de tableau prédéfini :

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Verrouiller le ratio d'aspect d'un tableau**

Le ratio d'aspect d'une forme géométrique est le rapport de ses dimensions. Aspose.Slides fournit la propriété `AspectRatioLocked()` pour vous permettre de verrouiller le paramètre de ratio d'aspect pour les tableaux et autres formes. 

```c++
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Puis-je activer la direction de lecture de droite à gauche (RTL) pour un tableau entier et le texte de ses cellules ?**

Oui. Le tableau expose une méthode [set_RightToLeft](https://reference.aspose.com/slides/fr/cpp/aspose.slides/table/set_righttoleft/) et les paragraphes disposent de [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/fr/cpp/aspose.slides/paragraphformat/set_righttoleft/). L'utilisation des deux garantit l'ordre RTL correct et le rendu à l'intérieur des cellules.

**Comment empêcher les utilisateurs de déplacer ou de redimensionner un tableau dans le fichier final ?**

Utilisez les [shape locks](/slides/fr/cpp/applying-protection-to-presentation/) pour désactiver le déplacement, le redimensionnement, la sélection, etc. Ces verrous s'appliquent également aux tableaux.

**L'insertion d'une image à l'intérieur d'une cellule comme arrière‑plan est‑elle prise en charge ?**

Oui. Vous pouvez définir un [picture fill](https://reference.aspose.com/slides/fr/cpp/aspose.slides/picturefillformat/) pour une cellule ; l'image couvrira la zone de la cellule selon le mode choisi (étirement ou mosaïque).