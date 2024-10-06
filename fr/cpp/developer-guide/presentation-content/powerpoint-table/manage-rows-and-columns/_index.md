---
title: Gérer les lignes et les colonnes
type: docs
weight: 20
url: /cpp/manage-rows-and-columns/
keywords: "Table, lignes et colonnes de table, présentation PowerPoint, C++, CPP, Aspose.Slides pour C++"
description: "Gérer les lignes et les colonnes de table dans des présentations PowerPoint en C++"

---

Pour vous permettre de gérer les lignes et les colonnes d'une table dans une présentation PowerPoint, Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/), l'interface [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) et de nombreux autres types.

## **Définir la première ligne comme en-tête**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) et chargez la présentation.
2. Obtenez la référence d'une diapositive via son index.
3. Créez un objet [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) et définissez-le sur null.
4. Parcourez tous les objets [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) pour trouver la table pertinente.
5. Définissez la première ligne de la table comme son en-tête.

Ce code C++ vous montre comment définir la première ligne d'une table comme son en-tête :

```c++
// Instancie la classe Presentation 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// Accède à la première diapositive
auto sld = pres->get_Slides()->idx_get(0);

// Initialise le TableEx null
SharedPtr<ITable> tbl;

// Parcourt les formes et définit une référence à la table
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Définit la première ligne d'une table comme son en-tête 
tbl->set_FirstRow(true);
```

## **Cloner une ligne ou une colonne de table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) et chargez la présentation,
2. Obtenez la référence d'une diapositive via son index.
3. Définissez un tableau de `columnWidth`.
4. Définissez un tableau de `rowHeight`.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) à la diapositive via la méthode [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
6. Cloner la ligne de table.
7. Cloner la colonne de table.
8. Sauvegardez la présentation modifiée.

Ce code C++ vous montre comment cloner une ligne ou une colonne d'une table PowerPoint :

```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/CloningInTable_out.pptx";

// Instancie la classe Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accède à la première diapositive
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Définit les colonnes avec des largeurs et les lignes avec des hauteurs
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Ajoute une forme de tableau à la diapositive
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

// Définit le format de la bordure pour chaque cellule
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
    SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
    for (int y = 0; y < row->get_Count(); y++)
    {
        SharedPtr<ICell> cell = row->idx_get(y);

        cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderTop()->set_Width(5);

        cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderBottom()->set_Width(5);

        cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderLeft()->set_Width(5);

        cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderRight()->set_Width(5);

    }

}

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

//AddClone ajoute une ligne à la fin de la table
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

//InsertClone ajoute une ligne à une position spécifique dans une table
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone ajoute une colonne à la fin de la table
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone ajoute une colonne à une position spécifique dans une table
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// Sauvegarde la présentation sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Supprimer une ligne ou une colonne de la table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) et chargez la présentation,
2. Obtenez la référence d'une diapositive via son index.
3. Définissez un tableau de `columnWidth`.
4. Définissez un tableau de `rowHeight`.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) à la diapositive via la méthode [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
6. Supprimez la ligne de la table.
7. Supprimez la colonne de la table.
8. Sauvegardez la présentation modifiée. 

Ce code C++ vous montre comment supprimer une ligne ou une colonne d'une table :

```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Instancie la classe Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accède à la première diapositive
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Définit les colonnes avec des largeurs et les lignes avec des hauteurs
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Ajoute une forme de tableau à la diapositive
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// Fusionne les cellules (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Fusionne les cellules (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Sauvegarde la présentation sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Définir le formatage du texte au niveau de la ligne de la table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) et chargez la présentation,
2. Obtenez la référence d'une diapositive via son index.
3. Accédez à l'objet [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) pertinent depuis la diapositive.
4. Définissez la hauteur de police des cellules de la première ligne avec [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/).
5. Définissez l'alignement des cellules de la première ligne avec [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) et [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/).
6. Définissez le type vertical du texte des cellules de la deuxième ligne avec [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Sauvegardez la présentation modifiée.

Ce code C++ démontre l'opération.

```c++
// Crée une instance de la classe Presentation
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Supposons que la première forme sur la première diapositive est une table
// Définit la hauteur de police des cellules de la première ligne
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// Définit l'alignement du texte et la marge droite des cellules de la première ligne
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// Définit le type vertical du texte des cellules de la deuxième ligne
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// Sauvegarde la présentation sur le disque
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Définir le formatage du texte au niveau de la colonne de la table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) et chargez la présentation,
2. Obtenez la référence d'une diapositive via son index.
3. Accédez à l'objet [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) pertinent depuis la diapositive.
4. Définissez la hauteur de police des cellules de la première colonne avec [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/).
5. Définissez l'alignement et la marge droite des cellules de la première colonne en un seul appel avec [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) et [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/).
6. Définissez le type vertical du texte des cellules de la deuxième colonne avec [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Sauvegardez la présentation modifiée.

Ce code C++ démontre l'opération :

```c++
// Crée une instance de la classe Presentation
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Supposons que la première forme sur la première diapositive est une table

// Définit la hauteur de police des cellules de la première colonne
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// Définit l'alignement et la marge droite des cellules de la première colonne en un seul appel
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// Définit le type vertical du texte des cellules de la deuxième colonne
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Obtenir les propriétés de style de la table**

Aspose.Slides vous permet de récupérer les propriétés de style d'une table afin que vous puissiez utiliser ces détails pour une autre table ou ailleurs. Ce code C++ vous montre comment obtenir les propriétés de style depuis un style de table prédéfini :

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```