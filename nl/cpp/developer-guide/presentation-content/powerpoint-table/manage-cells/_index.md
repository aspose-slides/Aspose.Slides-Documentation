---
title: Beheer van tabelcellen in presentaties met C++
linktitle: Beheer cellen
type: docs
weight: 30
url: /nl/cpp/manage-cells/
keywords:
- tabelcel
- cellen samenvoegen
- rand verwijderen
- cel splitsen
- afbeelding in cel
- achtergrondkleur
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Beheer tabelcellen in PowerPoint moeiteloos met Aspose.Slides voor C++. Leer snel toegang te krijgen tot, het wijzigen en opmaken van cellen voor een vlekkeloze dia-automatisering."
---
## **Overzicht**

Aspose.Slides stelt u in staat tabellencellen in PowerPoint‑presentaties te benaderen en te wijzigen. Dit artikel legt uit hoe u samengevoegde tabelcellen kunt identificeren, celranden kunt verwijderen, kunt werken met celnummering na het samenvoegen of splitsen van cellen, de achtergrondkleur van een cel kunt wijzigen, en een afbeelding in een tabelcel kunt toevoegen. De voorbeelden laten zien hoe u een presentatie maakt of opent, een tabel van een dia haalt, de opmaak van een cel bijwerkt via cel‑eigenschappen, en de gewijzigde presentatie opslaat als een PPTX‑bestand.

## **Identificeer een samengevoegde cel**
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse.  
2. Haal de tabel op van de eerste dia.  
3. Itereer door de rijen en kolommen van de tabel om samengevoegde cellen te vinden.  
4. Print een bericht wanneer samengevoegde cellen worden gevonden.

Deze C++‑code laat zien hoe u samengevoegde tabelcellen in een presentatie kunt identificeren:

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// aangenomen dat Slide#0.Shape#0 een tabel is
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```

## **Tabelcelranden verwijderen**
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Definieer een array van kolommen met breedte.  
4. Definieer een array van rijen met hoogte.  
5. Voeg een tabel toe aan de dia via de `AddTable`‑methode.  
6. Itereer door elke cel om de boven-, onder-, rechts‑ en linkerrand te wissen.  
7. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze C++‑code laat zien hoe u de randen van tabelcellen kunt verwijderen:

``` cpp
// Instantieert de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
auto pres = MakeObject<Presentation>();
// Toet tot de eerste dia
auto sld = pres->get_Slides()->idx_get(0);

// Definieert kolommen met breedtes en rijen met hoogtes
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// Voegt een tabelvorm toe aan de dia
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Stelt het randformaat in voor elke cel
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

// Schrijft het PPTX‑bestand naar schijf
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Nummering in samengevoegde cellen**
Als we 2 paren cellen (1, 1) x (2, 1) en (1, 2) x (2, 2) samenvoegen, wordt de resulterende tabel genummerd. Deze C#‑code demonstreert het proces:

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// Laadt de gewenste presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Benadert de eerste dia
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definieert kolommen met breedtes en rijen met hoogtes
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Voegt een tabelvorm toe aan de dia
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Stelt het randformaat in voor elke cel
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
// Voegt cellen (1, 1) x (2, 1) samen
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Voegt cellen (1, 2) x (2, 2) samen
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Slaat het PPTX‑bestand op naar schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Vervolgens voegen we de cellen verder samen door (1, 1) en (1, 2) te combineren. Het resultaat is een tabel met een grote samengevoegde cel in het midden:

```c++
// Het pad naar de documentenmap.
const String outPath = u"../out/MergeCells_out.pptx";

// Laadt de gewenste presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Benadert de eerste dia
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definieert kolommen met breedtes en rijen met hoogtes
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Voegt een tabelvorm toe aan de dia
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Stelt het randformaat in voor elke cel
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

// Voegt cellen (1, 1) x (2, 1) samen
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Voegt cellen (1, 2) x (2, 2) samen
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Slaat het PPTX‑bestand op naar schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Nummering in een gesplitste cel**
In eerdere voorbeelden veranderde de nummering of het cijfersysteem in andere cellen niet wanneer tabelcellen werden samengevoegd.

Deze keer nemen we een gewone tabel (een tabel zonder samengevoegde cellen) en proberen vervolgens cel (1,1) te splitsen om een speciale tabel te krijgen. Let op de nummering van deze tabel, die misschien vreemd lijkt. Echter, zo nummeren Microsoft PowerPoint tabelcellen en Aspose.Slides doet precies hetzelfde.

Deze C++‑code demonstreert het beschreven proces:

```c++
// Het pad naar de documentenmap.
const String outPath = u"../out/CellSplit_out.pptx";

// Laadt de gewenste presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Benadert de eerste dia
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definieert kolommen met breedtes en rijen met hoogtes
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Voegt een tabelvorm toe aan de dia
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Stelt het randformaat in voor elke cel
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

// Voegt cellen (1, 1) x (2, 1) samen
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Voegt cellen (1, 2) x (2, 2) samen
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// splitst cel (1, 1). 
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// Slaat het PPTX‑bestand op naar schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **De achtergrondkleur van een tabelcel wijzigen**

Deze C++‑code laat zien hoe u de achtergrondkleur van een tabelcel kunt wijzigen:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// maak een nieuwe tabel
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// stel de achtergrondkleur in voor een cel 
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Een afbeelding toevoegen binnen een tabelcel**
1. Maak een instantie van de `Presentation`‑klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Definieer een array van kolommen met breedte.  
4. Definieer een array van rijen met hoogte.  
5. Voeg een tabel toe aan de dia via de `AddTable`‑methode.  
6. Maak een `Bitmap`‑object aan om het beeldbestand op te slaan.  
7. Voeg de bitmap‑afbeelding toe aan het `IPPImage`‑object.  
8. Stel de `FillFormat` voor de tabelcel in op `Picture`.  
9. Voeg de afbeelding toe aan de eerste cel van de tabel.  
10. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze C#‑code laat zien hoe u een afbeelding in een tabelcel kunt plaatsen bij het maken van een tabel:

```c++
// Het pad naar de documentenmap.
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Laadt de gewenste presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Benadert de eerste dia
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definieert kolommen met breedtes en rijen met hoogtes
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// Voegt een tabelvorm toe aan de dia
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// Haalt de afbeelding op
auto img = Images::FromFile(ImagePath);

// Voegt een afbeelding toe aan de afbeeldingsverzameling van de presentatie
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// Voegt de afbeelding toe aan de eerste tabelcel
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Slaat het PPTX‑bestand op naar schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **FAQ**

**Kan ik verschillende lijndiktes en -stijlen instellen voor de verschillende zijden van één cel?**

Ja. De [boven](https://reference.aspose.com/slides/nl/cpp/aspose.slides/cellformat/get_bordertop/)/[onder](https://reference.aspose.com/slides/nl/cpp/aspose.slides/cellformat/get_borderbottom/)/[linker](https://reference.aspose.com/slides/nl/cpp/aspose.slides/cellformat/get_borderleft/)/[rechter](https://reference.aspose.com/slides/nl/cpp/aspose.slides/cellformat/get_borderright/) randen hebben afzonderlijke eigenschappen, zodat de dikte en stijl van elke zijde kan verschillen. Dit volgt logisch uit de per‑zijde randbesturing voor een cel die in het artikel wordt getoond.

**Wat gebeurt er met de afbeelding als ik de kolom‑/rijgrootte wijzig nadat ik een afbeelding als celachtergrond heb ingesteld?**

Het gedrag hangt af van de [vullingsmodus](https://reference.aspose.com/slides/nl/cpp/aspose.slides/picturefillmode/). Bij stretchen past de afbeelding zich aan de nieuwe cel aan; bij tegelvorm worden de tegels opnieuw berekend. Het artikel noemt de weergavemodi van afbeeldingen in een cel.

**Kan ik een hyperlink toewijzen aan de gehele inhoud van een cel?**

[Hyperlinks](/slides/nl/cpp/manage-hyperlinks/) worden ingesteld op tekstreeksniveau (portion) binnen het tekstframe van de cel of op het niveau van de gehele tabel/vorm. In de praktijk kent u de link toe aan een portion of aan alle tekst in de cel.

**Kan ik verschillende lettertypen binnen één cel instellen?**

Ja. Het tekstframe van een cel ondersteunt [portions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/portion/) (runs) met onafhankelijke opmaak—lettertype, stijl, grootte en kleur.