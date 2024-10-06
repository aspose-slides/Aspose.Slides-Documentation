---
title: Gérer les cellules
type: docs
weight: 30
url: /cpp/manage-cells/
keywords: "Table, cellules fusionnées, cellules divisées, image dans la cellule de table, C++, CPP, Aspose.Slides pour C++"
description: "Cellules de tableau dans des présentations PowerPoint en C++"
---

## **Identifier une cellule fusionnée**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez le tableau de la première diapositive.
3. Itérez à travers les lignes et les colonnes du tableau pour trouver les cellules fusionnées.
4. Imprimez un message lorsque des cellules fusionnées sont trouvées.

Ce code C++ vous montre comment identifier les cellules de tableau fusionnées dans une présentation :

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// en supposant que Slide#0.Shape#0 est un tableau
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"Cell {0};{1} fait partie de la cellule fusionnée avec RowSpan={2} et ColSpan={3} commençant à partir de la cellule {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```

## **Supprimer la bordure des cellules de tableau**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez une référence à une diapositive via son index.
3. Définissez un tableau de colonnes avec largeur.
4. Définissez un tableau de lignes avec hauteur.
5. Ajoutez un tableau à la diapositive via la méthode `AddTable`.
6. Itérez à travers chaque cellule pour effacer les bordures supérieure, inférieure, droite et gauche.
7. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code C++ vous montre comment supprimer les bordures des cellules de tableau :

``` cpp
// Instancie la classe Presentation qui représente un fichier PPTX
auto pres = MakeObject<Presentation>();
// Accède à la première diapositive
auto sld = pres->get_Slides()->idx_get(0);

// Définit les colonnes avec largeurs et les lignes avec hauteurs
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// Ajoute une forme de tableau à la diapositive
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Définit le format de la bordure pour chaque cellule
for (const auto& row : System::IterateOver(tbl->get_Rows()))
{
    for (const auto& cell : System::IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }
}

// Écrit le fichier PPTX sur le disque
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Numérotation dans les cellules fusionnées**
Si nous fusionnons 2 paires de cellules (1, 1) x (2, 1) et (1, 2) x (2, 2), le tableau résultant sera numéroté. Ce code C# montre le processus :

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// Charge la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accède à la première diapositive
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Définit les colonnes avec largeurs et les lignes avec hauteurs
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
// Fusionne les cellules (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Fusionne les cellules (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Enregistre le fichier PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Nous fusionnons ensuite les cellules en fusionnant (1, 1) et (1, 2). Le résultat est un tableau contenant une grande cellule fusionnée au centre :

```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/MergeCells_out.pptx";

// Charge la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accède à la première diapositive
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Définit les colonnes avec largeurs et les lignes avec hauteurs
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

// Fusionne les cellules (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Fusionne les cellules (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Enregistre le fichier PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Numérotation dans une cellule divisée**
Dans les exemples précédents, lorsque les cellules de tableau ont été fusionnées, la numérotation ou le système de numération dans d'autres cellules n'a pas changé.

Cette fois, nous prenons un tableau ordinaire (un tableau sans cellules fusionnées) et essayons ensuite de diviser la cellule (1,1) pour obtenir un tableau spécial. Vous voudrez peut-être faire attention à la numérotation de ce tableau, qui peut sembler étrange. Cependant, c'est ainsi que Microsoft PowerPoint numéro un les cellules de tableau et Aspose.Slides fait de même.

Ce code C++ montre le processus que nous avons décrit :

```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/CellSplit_out.pptx";

// Charge la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accède à la première diapositive
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Définit les colonnes avec largeurs et les lignes avec hauteurs
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

// Fusionne les cellules (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Fusionne les cellules (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// divise la cellule (1, 1). 
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// Enregistre le fichier PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Changer la couleur d'arrière-plan d'une cellule de tableau**

Ce code C++ vous montre comment changer la couleur d'arrière-plan d'une cellule de tableau :

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// créer un nouveau tableau
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// définir la couleur d'arrière-plan pour une cellule 
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Ajouter une image à l'intérieur d'une cellule de tableau**
1. Créez une instance de la classe `Presentation`.
2. Obtenez une référence à une diapositive via son index.
3. Définissez un tableau de colonnes avec largeur.
4. Définissez un tableau de lignes avec hauteur.
5. Ajoutez un tableau à la diapositive via la méthode `AddTable`. 
6. Créez un objet `Bitmap` pour contenir le fichier image.
7. Ajoutez l'image bitmap à l'objet `IPPImage`.
8. Définissez le `FillFormat` pour la cellule de tableau sur `Image`.
9. Ajoutez l'image à la première cellule du tableau.
10. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code C# vous montre comment placer une image à l'intérieur d'une cellule de tableau lors de la création d'un tableau :

```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Charge la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accède à la première diapositive
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Définit les colonnes avec largeurs et les lignes avec hauteurs
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// Ajoute une forme de tableau à la diapositive
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// Obtient l'image
auto img = Images::FromFile(ImagePath);

// Ajoute une image à la collection d'images de la présentation
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// Ajoute l'image à la première cellule de tableau
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Enregistre le fichier PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```