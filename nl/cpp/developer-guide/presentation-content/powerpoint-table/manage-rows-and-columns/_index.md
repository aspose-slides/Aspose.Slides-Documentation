---
title: "Beheer rijen en kolommen in PowerPoint‑tabellen met C++"
linktitle: "Rijen en kolommen"
type: docs
weight: 20
url: /nl/cpp/manage-rows-and-columns/
keywords:
- tabelrij
- tabelkolom
- eerste rij
- tabelkop
- rij klonen
- kolom klonen
- rij kopiëren
- kolom kopiëren
- rij verwijderen
- kolom verwijderen
- tekstopmaak van rij
- tekstopmaak van kolom
- tabelstijl
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Beheer tabelrijen en -kolommen in PowerPoint met Aspose.Slides voor C++ en versnel de bewerking van presentaties en gegevensupdates."
---
## **Inleiding**

Om u in staat te stellen de rijen en kolommen van een tabel in een PowerPoint‑presentatie te beheren, biedt Aspose.Slides de [Table](https://reference.aspose.com/slides/nl/cpp/aspose.slides/table/) klasse, de [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/) interface en vele andere types. 

## **Stel de eerste rij in als koptekst**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse en laad de presentatie. 
2. Haal een referentie naar een dia op via de index. 
3. Maak een [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/) object en stel het in op null. 
4. Doorloop alle [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/) objecten om de betreffende tabel te vinden. 
5. Stel de eerste rij van de tabel in als koptekst. 

Deze C++‑code laat zien hoe u de eerste rij van een tabel als koptekst instelt:

```c++
// Instantiëert de Presentation‑klasse 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// Toegang tot de eerste dia
auto sld = pres->get_Slides()->idx_get(0);

// Initialiseert de null‑TableEx
SharedPtr<ITable> tbl;

// Itereert door de shapes en stelt een referentie naar de tabel in
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Stelt de eerste rij van een tabel in als koptekst 
tbl->set_FirstRow(true);
```

## **Kopieer een tabelrij of -kolom**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse en laad de presentatie, 
2. Haal een referentie naar een dia op via de index. 
3. Definieer een array van `columnWidth`. 
4. Definieer een array van `rowHeight`. 
5. Voeg een [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/) object toe aan de dia via de [AddTable()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/addtable/) methode. 
6. Kopieer de tabelrij. 
7. Kopieer de tabelkolom. 
8. Sla de gewijzigde presentatie op. 

Deze C++‑code laat zien hoe u een PowerPoint‑tabelrij of -kolom kloont:

```c++
 // Het pad naar de documentmap.
const String outPath = u"../out/CloningInTable_out.pptx";

// Instantiëert de Presentation‑klasse
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Toegang tot de eerste dia
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

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

//AddClone voegt een rij toe aan het einde van de tabel
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

//InsertClone voegt een rij toe op een specifieke positie in een tabel
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone voegt een kolom toe aan het einde van de tabel
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone voegt een kolom toe op een specifieke positie in een tabel
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// Slaat de presentatie op naar schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);


```

## **Verwijder een rij of kolom uit een tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse en laad de presentatie, 
2. Haal een referentie naar een dia op via de index. 
3. Definieer een array van `columnWidth`. 
4. Definieer een array van `rowHeight`. 
5. Voeg een [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/) object toe aan de dia via de [AddTable()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/addtable/) methode. 
6. Verwijder de tabelrij. 
7. Verwijder de tabelkolom. 
8. Sla de gewijzigde presentatie op. 

Deze C++‑code laat zien hoe u een rij of kolom uit een tabel verwijdert:

```c++
// Het pad naar de documentmap.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Instantiëert de Presentation‑klasse
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Toegang tot de eerste dia
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definieert de kolommen met breedtes en rijen met hoogtes
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Voegt een tabelvorm toe aan de dia
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// Voegt cellen (1, 1) x (2, 1) samen
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Voegt cellen (1, 2) x (2, 2) samen
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Slaat de presentatie op naar schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);


```

## **Stel tekstopmaak in op rijniveau van de tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse en laad de presentatie, 
2. Haal een referentie naar een dia op via de index. 
3. Toegang tot het relevante [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/) object vanaf de dia. 
4. Stel de [set_FontHeight()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseportionformat/set_fontheight/) van de cellen in de eerste rij in. 
5. Stel de [set_Alignment()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_alignment/) en [set_MarginRight()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_marginright/) van de cellen in de eerste rij in. 
6. Stel de [set_TextVerticalType()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textframeformat/set_textverticaltype/) van de cellen in de tweede rij in. 
7. Sla de gewijzigde presentatie op. 

Deze C++‑code demonstreert de bewerking.

```c++
// Maakt een instantie van de Presentation‑klasse
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Laten we aannemen dat de eerste shape op de eerste dia een tabel is
// Stelt de letterhoogte van de cellen in de eerste rij in
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// Stelt de tekstuitlijning en rechter marge van de cellen in de eerste rij in
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// Stelt het verticale teksttype van de cellen in de tweede rij in
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// Slaat de presentatie op naar schijf
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Stel tekstopmaak in op kolomniveau van de tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse en laad de presentatie, 
2. Haal een referentie naar een dia op via de index. 
3. Toegang tot het relevante [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/) object vanaf de dia. 
4. Stel de [set_FontHeight()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseportionformat/set_fontheight/) van de cellen in de eerste kolom in. 
5. Stel de [set_Alignment()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_alignment/) en [set_MarginRight()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_marginright/) van de cellen in de eerste kolom in. 
6. Stel de [set_TextVerticalType()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textframeformat/set_textverticaltype/) van de cellen in de tweede kolom in. 
7. Sla de gewijzigde presentatie op. 

Deze C++‑code demonstreert de bewerking: 

```c++
// Maakt een instantie van de Presentation‑klasse
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Laten we aannemen dat de eerste shape op de eerste dia een tabel is

// Stelt de letterhoogte van de cellen in de eerste kolom in
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// Stelt de tekstuitlijning en rechter marge van de cellen in de eerste kolom in één oproep
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// Stelt het verticale teksttype van de cellen in de tweede kolom in
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Haal tafel‑stijleigenschappen op**

Aspose.Slides stelt u in staat de stijleigenschappen van een tabel op te halen zodat u die details voor een andere tabel of elders kunt gebruiken. Deze C++‑code laat zien hoe u de stijleigenschappen van een tabel‑preset‑stijl verkrijgt:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Kan ik PowerPoint‑thema’s/stijlen toepassen op een reeds aangemaakte tabel?**

Ja. De tabel erft het thema van de dia/lay‑out/master en u kunt nog steeds vullingen, randen en tekstkleuren bovenop dat thema overschrijven.

**Kan ik tabelrijen sorteren zoals in Excel?**

Nee, Aspose.Slides‑tabellen hebben geen ingebouwde sortering of filters. Sorteer uw gegevens eerst in het geheugen en vul daarna de tabelrijen in die volgorde opnieuw.

**Kan ik banden‑ (gestreepte) kolommen hebben terwijl ik aangepaste kleuren behoud voor specifieke cellen?**

Ja. Schakel banden‑kolommen in en overschrijf vervolgens specifieke cellen met lokale opmaak; opmaak op celniveau heeft voorrang boven de tabel‑stijl.