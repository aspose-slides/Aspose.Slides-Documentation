---
title: Beheer presentatietabellen in C++
linktitle: Beheer tabel
type: docs
weight: 10
url: /nl/cpp/manage-table/
keywords:
- tabel toevoegen
- tabel maken
- tabel openen
- beeldverhouding
- tekst uitlijnen
- tekstopmaak
- tabelstijl
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Maak & bewerk tabellen in PowerPoint-dia's met Aspose.Slides voor C++. Ontdek eenvoudige codevoorbeelden om je tabelwerkstromen te stroomlijnen."
---
## **Inleiding**

Een tabel in PowerPoint is een efficiënte manier om informatie weer te geven en te presenteren. De informatie in een raster van cellen (geordend in rijen en kolommen) is duidelijk en eenvoudig te begrijpen.

Aspose.Slides biedt de [Table](https://reference.aspose.com/slides/nl/cpp/aspose.slides/table/) klasse, [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/) interface, [Cell](https://reference.aspose.com/slides/nl/cpp/aspose.slides/cell/) klasse, [ICell](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icell/) interface en andere types om tabellen in allerlei presentaties te maken, bij te werken en te beheren.

## **Maak een tabel vanaf nul**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Haal een referentie naar een dia op via de index.
3. Definieer een array van `columnWidth`.
4. Definieer een array van `rowHeight`.
5. Voeg een [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/) object toe aan de dia via de [AddTable()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/addtable/) methode.
6. Loop door elke [ICell](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icell/) om opmaak toe te passen op de boven-, onder-, rechter- en linkerranden.
7. Voeg de eerste twee cellen van de eerste rij van de tabel samen.
8. Open de [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textframe/) van een [ICell](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icell/).
9. Voeg wat tekst toe aan de [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textframe/).
10. Sla de aangepaste presentatie op.

Deze C++‑code laat zien hoe je een tabel in een presentatie maakt:

```c++
// Instantieert een Presentation‑klasse die een PPTX‑bestand representeert
auto pres = System::MakeObject<Presentation>();

// Toegang tot de eerste dia
auto sld = pres->get_Slides()->idx_get(0);

// Definieert kolommen met breedtes en rijen met hoogtes
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Voegt een tabelvorm toe aan de dia
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Stelt het randformaat in voor elke cel
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
// Voegt cellen 1 & 2 van rij 1 samen
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Voegt wat tekst toe aan de samengevoegde cel
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Slaat de presentatie op naar schijf
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Nummering in een standaardtabel**

In een standaardtabel is de nummering van cellen rechttoe rechtaan en nulgebaseerd. De eerste cel in een tabel heeft de index 0,0 (kolom 0, rij 0).

Voorbeeld: de cellen in een tabel met 4 kolommen en 4 rijen worden als volgt genummerd:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Deze C++‑code laat zien hoe je de nummering voor cellen in een tabel specificeert:

```c++
// Instantieert een Presentation‑klasse die een PPTX‑bestand representeert
auto pres = System::MakeObject<Presentation>();

// Toegang tot de eerste dia
auto sld = pres->get_Slides()->idx_get(0);

// Definieert kolommen met breedtes en rijen met hoogtes
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Voegt een tabelvorm toe aan de dia
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Stelt het randformaat in voor elke cel
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

// Slaat de presentatie op naar schijf
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Toegang tot een bestaande tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.

2. Haal een referentie op naar de dia die de tabel bevat via de index.

3. Maak een [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/) object en zet het op null.

4. Doorloop alle [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/) objecten totdat de tabel wordt gevonden.

   Als je vermoedt dat de dia slechts één tabel bevat, kun je simpelweg alle vormen die erin staan controleren. Wanneer een vorm als een tabel wordt geïdentificeerd, kun je deze casten naar een [Table](https://reference.aspose.com/slides/nl/cpp/aspose.slides/table/) object. Maar als de dia meerdere tabellen bevat, is het beter de tabel die je nodig hebt te zoeken via de [set_AlternativeText()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/set_alternativetext/) methode.

5. Gebruik het [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/) object om met de tabel te werken. In het voorbeeld hieronder hebben we een nieuwe rij aan de tabel toegevoegd.

6. Sla de aangepaste presentatie op.

Deze C++‑code laat zien hoe je toegang krijgt tot en werkt met een bestaande tabel:

```c++
// Instantieert een Presentation‑klasse die een PPTX‑bestand representeert
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Toegang tot de eerste dia
auto sld = pres->get_Slides()->idx_get(0);

// Initialiseert een null‑tabel
System::SharedPtr<ITable> tbl;

// Doorloopt de vormen en stelt een referentie in naar de gevonden tabel
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Stelt de tekst in voor de eerste kolom van de tweede rij
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Slaat de aangepaste presentatie op naar schijf
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Tekst uitlijnen in een tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Haal een referentie naar een dia op via de index.
3. Voeg een [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/) object toe aan de dia.
4. Open een [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) object van de tabel.
5. Open de [IParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/) van het [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/).
6. Lijn de tekst verticaal uit.
7. Sla de aangepaste presentatie op.

Deze C++‑code laat zien hoe je de tekst in een tabel uitlijnt:

```c++
// Creëert een instantie van de Presentation‑klasse
auto presentation = System::MakeObject<Presentation>();

// Haalt de eerste dia op 
auto slide = presentation->get_Slides()->idx_get(0);

// Definieert kolommen met breedtes en rijen met hoogtes
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Voegt de tabelvorm toe aan de dia
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Toegang tot het tekstframe
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Creëert het Paragraaf‑object voor het tekstframe
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Creëert het Portion‑object voor de paragraaf
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Lijnt de tekst verticaal uit
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Slaat de presentatie op naar schijf
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Tekstopmaak instellen op tabelniveau**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Haal een referentie naar een dia op via de index.
3. Open een [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/) object van de dia.
4. Stel de [set_FontHeight()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseportionformat/set_fontheight/) in voor de tekst.
5. Stel de [set_Alignment()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_alignment/) en [set_MarginRight()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_marginright/) in.
6. Stel de [set_TextVerticalType()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textframeformat/set_textverticaltype/) in.
7. Sla de aangepaste presentatie op.

Deze C++‑code laat zien hoe je je gewenste opmaakopties toepast op de tekst in een tabel:

```c++
// Maakt een instantie van de Presentation‑klasse
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Laten we aannemen dat de eerste shape op de eerste dia een tabel is
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Stelt de letterhoogte van de tabelcellen in
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Stelt de tekstuitlijning en de rechter marge van de tabelcellen in één oproep in
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Stelt het verticale type van de tekst in de tabelcellen in
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Eigenschappen van tabelstijlen ophalen**

Aspose.Slides stelt je in staat de stijl‑eigenschappen van een tabel op te halen zodat je die details kunt gebruiken voor een andere tabel of elders. Deze C++‑code laat zien hoe je de stijl‑eigenschappen van een tabelpreset‑stijl verkrijgt:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Verhoudingsvergrendeling van een tabel**

De beeldverhouding van een geometrische vorm is de verhouding van de afmetingen in verschillende dimensies. Aspose.Slides biedt de `AspectRatioLocked()` eigenschap om de beeldverhouding voor tabellen en andere vormen vast te zetten.

Deze C++‑code laat zien hoe je de beeldverhouding van een tabel vergrendelt:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Kan ik de leesrichting van rechts‑naar‑links (RTL) inschakelen voor een volledige tabel en de tekst in de cellen?**

Ja. De tabel stelt een [set_RightToLeft](https://reference.aspose.com/slides/nl/cpp/aspose.slides/table/set_righttoleft/) methode beschikbaar, en alinea’s hebben [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraphformat/set_righttoleft/). Door beide te gebruiken zorg je voor de juiste RTL‑volgorde en weergave binnen de cellen.

**Hoe kan ik voorkomen dat gebruikers een tabel in het uiteindelijke bestand verplaatsen of van formaat wijzigen?**

Gebruik [shape locks](/slides/nl/cpp/applying-protection-to-presentation/) om verplaatsen, formaat wijzigen, selecteren, enz. uit te schakelen. Deze vergrendelingen gelden ook voor tabellen.

**Wordt het invoegen van een afbeelding als achtergrond in een cel ondersteund?**

Ja. Je kunt een [picture fill](https://reference.aspose.com/slides/nl/cpp/aspose.slides/picturefillformat/) instellen voor een cel; de afbeelding bedekt dan het celgebied volgens de gekozen modus (strekken of tegelen).