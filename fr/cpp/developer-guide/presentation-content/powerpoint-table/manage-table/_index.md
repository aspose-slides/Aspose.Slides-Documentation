---
title: Gérer les Tableaux
type: docs
weight: 10
url: /cpp/manage-table/
keywords: "Tableau, créer un tableau, accéder au tableau, rapport d'aspect du tableau, présentation PowerPoint, C++, Aspose.Slides pour C++"
description: "Créer et gérer des tableaux dans les présentations PowerPoint en C++"
---

Un tableau dans PowerPoint est un moyen efficace d'afficher et de représenter des informations. L'information dans une grille de cellules (organisées en lignes et en colonnes) est simple et facile à comprendre.

Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/), l'interface [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/), la classe [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/), l'interface [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) et d'autres types qui vous permettent de créer, mettre à jour et gérer des tableaux dans tous types de présentations.

## **Créer un Tableau à Partir de Rien**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive par son index.
3. Définissez un tableau de `columnWidth`.
4. Définissez un tableau de `rowHeight`.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) à la diapositive via la méthode [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
6. Parcourez chaque [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) pour appliquer la mise en forme aux bordures supérieure, inférieure, droite et gauche.
7. Fusionnez les deux premières cellules de la première ligne du tableau.
8. Accédez au [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) d'un [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/).
9. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/).
10. Enregistrez la présentation modifiée.

Ce code C++ vous montre comment créer un tableau dans une présentation :

```c++
// Instancie une classe Presentation représentant un fichier PPTX
auto pres = System::MakeObject<Presentation>();

// Accède à la première diapositive
auto sld = pres->get_Slides()->idx_get(0);

// Définit des colonnes avec des largeurs et des lignes avec des hauteurs
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Ajoute une forme de tableau à la diapositive
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Définit le format des bordures pour chaque cellule
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
// Fuse les cellules 1 et 2 de la ligne 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Ajoute du texte à la cellule fusionnée
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Cellules Fusionnées");

// Enregistre la présentation sur le disque
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Numérotation dans un Tableau Standard**

Dans un tableau standard, la numérotation des cellules est simple et basée sur zéro. La première cellule d'un tableau est indexée comme 0,0 (colonne 0, ligne 0).

Par exemple, les cellules d'un tableau avec 4 colonnes et 4 lignes sont numérotées de cette manière :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ce code C++ vous montre comment spécifier la numérotation pour des cellules dans un tableau :

```c++
// Instancie une classe Presentation représentant un fichier PPTX
auto pres = System::MakeObject<Presentation>();

// Accède à la première diapositive
auto sld = pres->get_Slides()->idx_get(0);

// Définit des colonnes avec des largeurs et des lignes avec des hauteurs
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Ajoute une forme de tableau à la diapositive
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Définit le format des bordures pour chaque cellule
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

## **Accéder à un Tableau Existant**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).

2. Obtenez une référence à la diapositive contenant le tableau par son index.

3. Créez un objet [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) et définissez-le sur null.

4. Parcourez tous les objets [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) jusqu'à ce que le tableau soit trouvé.

   Si vous suspectez que la diapositive avec laquelle vous traitez contient un seul tableau, vous pouvez simplement vérifier toutes les formes qu'elle contient. Lorsqu'une forme est identifiée comme un tableau, vous pouvez la convertir en objet [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/). Mais si la diapositive que vous traitez contient plusieurs tableaux, il vaut mieux chercher le tableau dont vous avez besoin via son [set_AlternativeText()](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_alternativetext/).

5. Utilisez l'objet [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) pour travailler avec le tableau. Dans l'exemple ci-dessous, nous avons ajouté une nouvelle ligne au tableau.

6. Enregistrez la présentation modifiée.

Ce code C++ vous montre comment accéder à un tableau existant et y travailler :

```c++
// Instancie une classe Presentation représentant un fichier PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Accède à la première diapositive
auto sld = pres->get_Slides()->idx_get(0);

// Initialise un tableau nulle
System::SharedPtr<ITable> tbl;

// Parcourt les formes et définit une référence au tableau trouvé
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Définit le texte pour la première colonne de la deuxième ligne
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"Nouveau");

// Enregistre la présentation modifiée sur le disque
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Aligner le Texte dans le Tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive par son index.
3. Ajoutez un objet [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) à la diapositive.
4. Accédez à un objet [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) à partir du tableau.
5. Accédez au [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/).
6. Alignez le texte verticalement.
7. Enregistrez la présentation modifiée.

Ce code C++ vous montre comment aligner le texte dans un tableau :

```c++
// Crée une instance de la classe Presentation
auto presentation = System::MakeObject<Presentation>();

// Obtient la première diapositive 
auto slide = presentation->get_Slides()->idx_get(0);

// Définit des colonnes avec des largeurs et des lignes avec des hauteurs
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Ajoute la forme du tableau à la diapositive
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
portion->set_Text(u"Texte ici");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Aligne le texte verticalement
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Enregistre la présentation sur le disque
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Définir le Formatage du Texte au Niveau du Tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive par son index. 
3. Accédez à un objet [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) à partir de la diapositive.
4. Définissez le [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) pour le texte. 
5. Définissez le [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) et le [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Définissez le [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Enregistrez la présentation modifiée. 

Ce code C++ vous montre comment appliquer vos options de formatage préférées au texte dans un tableau :

```c++
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

## **Obtenir les Propriétés de Style du Tableau**

Aspose.Slides vous permet de récupérer les propriétés de style pour un tableau afin que vous puissiez utiliser ces détails pour un autre tableau ou ailleurs. Ce code C++ vous montre comment obtenir les propriétés de style d'un style de tableau prédéfini :

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Verrouiller le Rapport d'Aspect du Tableau**

Le rapport d'aspect d'une forme géométrique est le rapport de ses tailles dans différentes dimensions. Aspose.Slides fournit la propriété `AspectRatioLocked()` pour vous permettre de verrouiller le paramètre de rapport d'aspect pour les tableaux et autres formes.

Ce code C++ vous montre comment verrouiller le rapport d'aspect pour un tableau :

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Verrouiller le rapport d'aspect défini : {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Verrouiller le rapport d'aspect défini : {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```