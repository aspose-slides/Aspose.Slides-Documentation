---
title: "Hantera rader och kolumner i PowerPoint‑tabeller med C++"
linktitle: "Rader och kolumner"
type: docs
weight: 20
url: /sv/cpp/manage-rows-and-columns/
keywords:
  - "tabellrad"
  - "tabellkolumn"
  - "första raden"
  - "tabellrubrik"
  - "klona rad"
  - "klona kolumn"
  - "kopiera rad"
  - "kopiera kolumn"
  - "ta bort rad"
  - "ta bort kolumn"
  - "textformatering för rad"
  - "textformatering för kolumn"
  - "tabellstil"
  - "PowerPoint"
  - "presentation"
  - "C++"
  - "Aspose.Slides"
description: "Hantera tabellrader och -kolumner i PowerPoint med Aspose.Slides för C++ och snabba upp redigering av presentationer samt datauppdateringar."
---
## **Introduktion**

För att låta dig hantera en tabells rader och kolumner i en PowerPoint-presentation erbjuder Aspose.Slides klassen [Table](https://reference.aspose.com/slides/sv/cpp/aspose.slides/table/) , gränssnittet [ITable](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itable/) och många andra typer. 

## **Ange den första raden som rubrik**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation) och ladda presentationen. 
2. Hämta en bilds referens via dess index. 
3. Skapa ett [ITable](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itable/)‑objekt och sätt det till null. 
4. Iterera genom alla [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/)‑objekt för att hitta den relevanta tabellen. 
5. Ställ in tabellens första rad som dess rubrik. 

Denna C++‑kod visar hur du sätter en tabells första rad som rubrik:

```c++
// Instansierar Presentation‑klassen 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// Hämtar den första bilden
auto sld = pres->get_Slides()->idx_get(0);

// Initierar null TableEx
SharedPtr<ITable> tbl;

// Itererar genom formerna och sätter en referens till tabellen
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Sätter tabellens första rad som rubrik 
tbl->set_FirstRow(true);
```

## **Klona en tabellrad eller -kolumn**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation) och ladda presentationen, 
2. Hämta en bilds referens via dess index. 
3. Definiera en array av `columnWidth`. 
4. Definiera en array av `rowHeight`. 
5. Lägg till ett [ITable](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itable/)‑objekt på bilden via metoden [AddTable()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/addtable/). 
6. Klona tabellraden. 
7. Klona tabellkolumnen. 
8. Spara den ändrade presentationen. 

Denna C++‑kod visar hur du klonar en PowerPoint‑tabells rad eller kolumn:

```c++
 // Sökvägen till dokumentkatalogen.
const String outPath = u"../out/CloningInTable_out.pptx";

// Instansierar Presentation‑klassen
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Hämtar den första bilden
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definierar kolumner med bredder och rader med höjder
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Lägger till en tabellform på bilden
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

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

//AddClone lägger till en rad i slutet av tabellen
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

//InsertClone lägger till en rad på en specifik position i en tabell
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone lägger till en kolumn i slutet av tabellen
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone lägger till en kolumn på en specifik position i en tabell
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// Sparar presentationen till disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ta bort en rad eller kolumn från en tabell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation) och ladda presentationen, 
2. Hämta en bilds referens via dess index. 
3. Definiera en array av `columnWidth`. 
4. Definiera en array av `rowHeight`. 
5. Lägg till ett [ITable](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itable/)‑objekt på bilden via metoden [AddTable()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/addtable/). 
6. Ta bort tabellraden. 
7. Ta bort tabellkolumnen. 
8. Spara den ändrade presentationen. 

Denna C++‑kod visar hur du tar bort en rad eller kolumn från en tabell:

```c++
// Sökvägen till dokumentkatalogen.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Instansierar Presentation-klassen
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Hämtar den första bilden
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definierar kolumner med bredder och rader med höjder
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Lägger till en tabellform på bilden
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// Slår ihop celler (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Slår ihop celler (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Sparar presentationen till disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ställ in textformatering på radnivå i tabellen**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation) och ladda presentationen, 
2. Hämta en bilds referens via dess index. 
3. Få åtkomst till det relevanta [ITable](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itable/)‑objektet från bilden. 
4. Ställ in den första radens cellers [set_FontHeight()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. Ställ in den första radens cellers [set_Alignment()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_alignment/) och [set_MarginRight()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Ställ in den andra radens cellers [set_TextVerticalType()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/textframeformat/set_textverticaltype/). 
7. Spara den ändrade presentationen. 

Denna C++‑kod demonstrerar operationen.

```c++
// Skapar en instans av Presentation-klassen
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Anta att den första formen på den första bilden är en tabell
// Ställer in teckenhöjden för cellerna i första raden
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// Ställer in textriktning och högermarginal för cellerna i första raden
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// Ställer in vertikal texttyp för cellerna i andra raden
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// Sparar presentationen till disk
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Ställ in textformatering på kolumnnivå i tabellen**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation) och ladda presentationen, 
2. Hämta en bilds referens via dess index. 
3. Få åtkomst till det relevanta [ITable](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itable/)‑objektet från bilden. 
4. Ställ in den första kolumnens cellers [set_FontHeight()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. Ställ in den första kolumnens cellers [set_Alignment()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_alignment/) och [set_MarginRight()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Ställ in den andra kolumnens cellers [set_TextVerticalType()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/textframeformat/set_textverticaltype/). 
7. Spara den ändrade presentationen. 

Denna C++‑kod demonstrerar operationen: 

```c++
// Skapar en instans av Presentation-klassen
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Anta att den första formen på den första bilden är en tabell

// Sätter teckenhöjden för cellerna i första kolumnen
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// Sätter textriktning och högermarginal för cellerna i första kolumnen i ett anrop
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// Sätter vertikal texttyp för cellerna i andra kolumnen
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Hämta tabellens stilegenskaper**

Aspose.Slides låter dig hämta stilegenskaperna för en tabell så att du kan använda dessa detaljer för en annan tabell eller någon annanstans. Denna C++‑kod visar hur du hämtar stilegenskaperna från en förinställd tabellstil:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Kan jag tillämpa PowerPoint‑teman/stilar på en redan skapad tabell?**

Ja. Tabellen ärver bildens/layoute­ns/master‑tema, och du kan fortfarande åsidosätta fyllningar, ramar och textfärger ovanpå det temat.

**Kan jag sortera tabellrader som i Excel?**

Nej, Aspose.Slides‑tabeller har ingen inbyggd sortering eller filter. Sortera dina data i minnet först, och fyll sedan tabellraderna på nytt i den ordningen.

**Kan jag ha bandade (randiga) kolumner samtidigt som jag behåller anpassade färger på specifika celler?**

Ja. Aktivera bandade kolumner, och åsidosätt sedan specifika celler med lokal formatering; cellnivå‑formatering har företräde framför tabellstilen.