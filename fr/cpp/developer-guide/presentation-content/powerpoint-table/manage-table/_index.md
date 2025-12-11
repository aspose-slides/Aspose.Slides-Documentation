---
title: Gérer les tables de présentation en C++
linktitle: Gérer la table
type: docs
weight: 10
url: /fr/cpp/manage-table/
keywords:
- ajouter tableau
- créer tableau
- accéder à la table
- ratio d'aspect
- aligner le texte
- formatage du texte
- style de tableau
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Créer et modifier des tables dans les diapositives PowerPoint avec Aspose.Slides pour C++. Découvrez des exemples de code simples pour rationaliser vos flux de travail de tables."
---

Un tableau dans PowerPoint est un moyen efficace d'afficher et de présenter des informations. Les informations présentées sous forme d'une grille de cellules (organisées en lignes et colonnes) sont simples et faciles à comprendre.

Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/), l'interface [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/), la classe [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/), l'interface [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) et d'autres types pour vous permettre de créer, mettre à jour et gérer des tableaux dans tous types de présentations. 

## **Créer un tableau à partir de zéro**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenez la référence d'une diapositive via son indice. 
3. Définissez un tableau de `columnWidth`.
4. Définissez un tableau de `rowHeight`.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) à la diapositive via la méthode [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
6. Parcourez chaque [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) pour appliquer le formatage aux bordures supérieure, inférieure, droite et gauche.
7. Fusionnez les deux premières cellules de la première ligne du tableau. 
8. Accédez au [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) d'un [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/).
9. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/).
10. Enregistrez la présentation modifiée.

```c++
// Instancie une classe Presentation qui représente un fichier PPTX
auto pres = System::MakeObject<Presentation>();

// Accède à la première diapositive
auto sld = pres->get_Slides()->idx_get(0);

// Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Ajoute une forme de tableau à la diapositive
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

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

Dans un tableau standard, la numérotation des cellules est simple et commence à zéro. La première cellule d'un tableau a l'index 0,0 (colonne 0, ligne 0). 

Par exemple, les cellules d'un tableau de 4 colonnes et 4 lignes sont numérotées ainsi :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ce code C++ vous montre comment spécifier la numérotation des cellules dans un tableau :
```c++
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

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive contenant le tableau via son indice. 
3. Créez un objet [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) et affectez-lui la valeur null.
4. Parcourez tous les objets [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) jusqu'à ce que le tableau soit trouvé.

   Si vous pensez que la diapositive que vous traitez ne contient qu'un seul tableau, vous pouvez simplement vérifier toutes les formes qu'elle contient. Lorsqu'une forme est identifiée comme un tableau, vous pouvez la convertir en objet [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/). Mais si la diapositive que vous traitez contient plusieurs tableaux, il est préférable de rechercher le tableau souhaité via sa méthode [set_AlternativeText()](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_alternativetext/).

5. Utilisez l'objet [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) pour travailler avec le tableau. Dans l'exemple ci‑dessous, nous avons ajouté une nouvelle ligne au tableau.
6. Enregistrez la présentation modifiée.

```c++
// Instancie une classe Presentation qui représente un fichier PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Accède à la première diapositive
auto sld = pres->get_Slides()->idx_get(0);

// Initialise la Table à null
System::SharedPtr<ITable> tbl;

// Parcourt les formes et définit une référence vers la table trouvée
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


## **Aligner le texte dans un tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenez la référence d'une diapositive via son indice. 
3. Ajoutez un objet [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) à la diapositive. 
4. Accédez à un objet [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) depuis le tableau. 
5. Accédez à l'[IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) du [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).
6. Alignez le texte verticalement.
7. Enregistrez la présentation modifiée.

```c++
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


## **Définir le formatage du texte au niveau du tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenez la référence d'une diapositive via son indice. 
3. Accédez à un objet [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) depuis la diapositive.
4. Définissez le [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) pour le texte. 
5. Définissez le [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) et le [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Définissez le [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Enregistrez la présentation modifiée. 

```c++
// Crée une instance de la classe Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Supposons que la première forme de la première diapositive soit un tableau
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

Aspose.Slides vous permet de récupérer les propriétés de style d'un tableau afin que vous puissiez réutiliser ces informations pour un autre tableau ou ailleurs. Ce code C++ vous montre comment récupérer les propriétés de style d'un style de tableau prédéfini :
```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```


## **Verrouiller le ratio d'aspect d'un tableau**

Le ratio d'aspect d'une forme géométrique correspond au rapport entre ses dimensions. Aspose.Slides fournit la propriété `AspectRatioLocked()` pour vous permettre de verrouiller le réglage du ratio d'aspect pour les tableaux et d'autres formes. 

Ce code C++ vous montre comment verrouiller le ratio d'aspect d'un tableau :
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Puis-je activer le sens de lecture de droite à gauche (RTL) pour un tableau complet et le texte de ses cellules ?**

Oui. Le tableau expose la méthode [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/) et les paragraphes disposent de [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/). L’utilisation des deux garantit l’ordre RTL correct et le rendu à l’intérieur des cellules.

**Comment puis‑je empêcher les utilisateurs de déplacer ou de redimensionner un tableau dans le fichier final ?**

Utilisez les [shape locks](/slides/fr/cpp/applying-protection-to-presentation/) pour désactiver le déplacement, le redimensionnement, la sélection, etc. Ces verrous s’appliquent également aux tableaux.

**L’insertion d’une image à l’intérieur d’une cellule comme arrière‑plan est‑elle prise en charge ?**

Oui. Vous pouvez définir un [picture fill](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) pour une cellule ; l’image couvrira la zone de la cellule selon le mode choisi (étirement ou mosaïque).