---
title: "Hantera tabellceller i presentationer med C++"
linktitle: "Hantera celler"
type: docs
weight: 30
url: /sv/cpp/manage-cells/
keywords:
- tabellcell
- slå ihop celler
- ta bort kant
- dela cell
- bild i cell
- bakgrundsfärg
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Hantera tabellceller i PowerPoint med Aspose.Slides för C++ utan ansträngning. Bemästra åtkomst, ändring och formatering av celler snabbt för sömlös bildspelsautomatisering."
---
## **Översikt**

Aspose.Slides låter dig komma åt och ändra tabellceller i PowerPoint-presentationer. Den här artikeln förklarar hur du identifierar sammanslagna tabellceller, tar bort cellkanter, arbetar med cellnumrering efter sammanslagning eller delning av celler, ändrar en cells bakgrundsfärg och lägger till en bild i en tabellcell. Exemplen visar hur du skapar eller öppnar en presentation, hämtar en tabell från en bild, uppdaterar cellformat via cellegenskaper och sparar den ändrade presentationen som en PPTX‑fil.

## **Identifiera en sammanslagen cell**
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
2. Hämta tabellen från den första bilden. 
3. Iterera genom tabellens rader och kolumner för att hitta sammanslagna celler.
4. Skriv ut ett meddelande när sammanslagna celler hittas.

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// antag att Slide#0.Shape#0 är en tabell
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

## **Ta bort tabellcellkanter**
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
2. Hämta en bilds referens via dess index. 
3. Definiera en array av kolumner med bredd.
4. Definiera en array av rader med höjd.
5. Lägg till en tabell på bilden via metoden `AddTable`.
6. Iterera genom varje cell för att rensa de övre, nedre, högra och vänstra kanterna.
7. Spara den modifierade presentationen som en PPTX‑fil.

``` cpp
// Skapar en instans av Presentation-klassen som representerar en PPTX-fil
auto pres = MakeObject<Presentation>();
// Hämtar den första bilden
auto sld = pres->get_Slides()->idx_get(0);

// Definierar kolumner med bredder och rader med höjder
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// Lägger till ett tabellobjekt på bilden
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Ställer in kantformatet för varje cell
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

// Skriver PPTX-filen till disk
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Numrering i sammanslagna celler**
Om vi slår ihop 2 par celler (1, 1) x (2, 1) och (1, 2) x (2, 2) kommer den resulterande tabellen att vara numrerad. Den här C#‑koden demonstrerar processen:

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// Laddar den önskade presentationen
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Hämtar den första bilden
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definierar kolumner med bredd och rader med höjd
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Lägger till en tabell på bilden
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Ställer in kantformat för varje cell
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
// Slår ihop celler (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Slår ihop celler (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Sparar PPTX-filen till disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Vi slår sedan ihop cellerna ytterligare genom att slå samman (1, 1) och (1, 2). Resultatet är en tabell som innehåller en stor sammanslagen cell i mitten: 

```c++
// Sökvägen till dokumentkatalogen.
const String outPath = u"../out/MergeCells_out.pptx";

// Laddar den önskade presentationen
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Hämtar den första bilden
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definierar kolumner med bredd och rader med höjd
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Lägger till ett tabellobjekt på bilden
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Ställer in kantformat för varje cell
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

// Slår ihop celler (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Slår ihop celler (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Sparar PPTX-filen till disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Numrering i en delad cell**
I tidigare exempel, när tabellceller slogs ihop, förändrades inte numreringen eller siffersystemet i de andra cellerna. 

Den här gången tar vi en vanlig tabell (en tabell utan sammanslagna celler) och försöker sedan dela cell (1,1) för att få en speciell tabell. Du kan vilja uppmärksamma tabellens numrering, som kan verka märklig. Det är dock så Microsoft PowerPoint numrerar tabellceller och Aspose.Slides gör samma sak. 

Denna C++‑kod demonstrerar processen vi beskrev:

```c++
// Sökvägen till dokumentkatalogen.
const String outPath = u"../out/CellSplit_out.pptx";

// Laddar den önskade presentationen
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Hämtar den första bilden
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definierar kolumner med bredd och rader med höjd
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Lägger till ett tabellobjekt på bilden
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Ställer in kantformat för varje cell
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

// Slår ihop celler (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Slår ihop celler (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// Delar cell (1, 1). 
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// Sparar PPTX-filen till disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Ändra bakgrundsfärgen för en tabellcell**

Den här C++‑koden visar hur du ändrar en tabellcells bakgrundsfärg:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// skapa en ny tabell
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// sätt bakgrundsfärgen för en cell 
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Lägg till en bild i en tabellcell**
1. Skapa en instans av klassen `Presentation`.
2. Hämta en bilds referens via dess index.
3. Definiera en array av kolumner med bredd.
4. Definiera en array av rader med höjd.
5. Lägg till en tabell på bilden via metoden `AddTable`. 
6. Skapa ett `Bitmap`‑objekt för att hålla bildfilen.
7. Lägg till bitmap‑bilden i `IPPImage`‑objektet.
8. Ställ in `FillFormat` för tabellcellen till `Picture`.
9. Lägg till bilden i tabellens första cell.
10. Spara den modifierade presentationen som en PPTX‑fil

```c++
// Sökvägen till dokumentkatalogen.
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Laddar den önskade presentationen
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Hämtar den första bilden
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definierar kolumner med bredd och rader med höjd
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// Lägger till en tabell på bilden
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// Hämtar bilden
auto img = Images::FromFile(ImagePath);

// Lägger till en bild i presentationens bildsamling
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// Lägger till bilden i den första tabellcellen
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Sparar PPTX-filen till disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Vanliga frågor**

**Kan jag ange olika linjetjocklekar och -stilar för olika sidor av en enskild cell?**

Ja. [top](https://reference.aspose.com/slides/sv/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/sv/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/sv/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/sv/cpp/aspose.slides/cellformat/get_borderright/) kanterna har separata egenskaper, så tjocklek och stil för varje sida kan vara olika. Detta följer logiskt av per‑sida kantkontrollen för en cell som demonstrerats i artikeln.

**Vad händer med bilden om jag ändrar kolumn‑/radstorlek efter att ha ställt in en bild som cellens bakgrund?**

Beteendet beror på [fill mode](https://reference.aspose.com/slides/sv/cpp/aspose.slides/picturefillmode/) (stretch/tile). Vid stretching anpassas bilden till den nya cellen; vid tiling räknas rutorna om. Artikeln nämner bildvisningslägen i en cell.

**Kan jag tilldela en hyperlänk till allt innehåll i en cell?**

[Hyperlinks](/slides/sv/cpp/manage-hyperlinks/) sätts på textraden (portion) nivå inom cellens textram eller på hela tabellens/objektets nivå. I praktiken tilldelar du länken till en portion eller till all text i cellen.

**Kan jag ange olika teckensnitt inom en enda cell?**

Ja. En cells textram stödjer [portions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/portion/) (runer) med oberoende formatering — teckensnittsfamilj, stil, storlek och färg.