---
title: Hantera presentationstabeller i C++
linktitle: Hantera tabell
type: docs
weight: 10
url: /sv/cpp/manage-table/
keywords:
- lägga till tabell
- skapa tabell
- komma åt tabell
- bildförhållande
- justera text
- textformatering
- tabellstil
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Skapa och redigera tabeller i PowerPoint-bilder med Aspose.Slides för C++. Upptäck enkla kodexempel för att förenkla ditt tabellarbetsflöde."
---
## **Introduktion**

En tabell i PowerPoint är ett effektivt sätt att visa och framställa information. Informationen i ett rutnät av celler (ordnade i rader och kolumner) är tydlig och lätt att förstå.

Aspose.Slides tillhandahåller klassen [Table](https://reference.aspose.com/slides/sv/cpp/aspose.slides/table/) , gränssnittet [ITable](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itable/) , klassen [Cell](https://reference.aspose.com/slides/sv/cpp/aspose.slides/cell/) , gränssnittet [ICell](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icell/) och andra typer som gör att du kan skapa, uppdatera och hantera tabeller i alla typer av presentationer. 

## **Skapa en tabell från början**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) .
2. Hämta en referens till en bild genom dess index. 
3. Definiera en array av `columnWidth` .
4. Definiera en array av `rowHeight` .
5. Lägg till ett [ITable](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itable/)‑objekt på bilden via metoden [AddTable()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/addtable/) .
6. Iterera genom varje [ICell](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icell/) för att tillämpa formatering på de övre, nedre, högra och vänstra kanterna.
7. Slå samman de två första cellerna i tabellens första rad. 
8. Få åtkomst till en [ICell](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/textframe/) . 
9. Lägg till lite text i [TextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/textframe/) .
10. Spara den ändrade presentationen.

Denna C++-kod visar hur du skapar en tabell i en presentation:

```c++
// Instansierar en Presentation-klass som representerar en PPTX-fil
auto pres = System::MakeObject<Presentation>();

// Hämtar den första bilden
auto sld = pres->get_Slides()->idx_get(0);

// Definierar kolumner med bredder och rader med höjder
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Lägger till en tabellform på bilden
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Ställer in kantformatet för varje cell
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
// Slår ihop cellerna 1 och 2 i rad 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Lägger till lite text i den sammanslagna cellen
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Sparar presentationen till disk
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Numrering i en standardtabell**

I en standardtabell är numreringen av celler enkel och nollbaserad. Den första cellen i en tabell har indexet 0,0 (kolumn 0, rad 0). 

Till exempel numreras cellerna i en tabell med 4 kolumner och 4 rader på följande sätt:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Denna C++-kod visar hur du specificerar numreringen för celler i en tabell:

```c++
// Instansierar en Presentation-klass som representerar en PPTX-fil
auto pres = System::MakeObject<Presentation>();

// Hämtar den första bilden
auto sld = pres->get_Slides()->idx_get(0);

// Definierar kolumner med bredder och rader med höjder
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Lägger till en tabellform på bilden
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Ställer in kantformatet för varje cell
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

// Sparar presentationen till disk
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Åtkomst till en befintlig tabell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) .
2. Hämta en referens till bilden som innehåller tabellen genom dess index. 
3. Skapa ett [ITable](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itable/)‑objekt och sätt det till null.
4. Iterera genom alla [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/)‑objekt tills tabellen hittas.

   Om du misstänker att bilden du arbetar med innehåller en enda tabell kan du helt enkelt kontrollera alla former den innehåller. När en form identifieras som en tabell kan du typkonvertera den till ett [Table](https://reference.aspose.com/slides/sv/cpp/aspose.slides/table/)‑objekt. Men om bilden du arbetar med innehåller flera tabeller är det bättre att söka efter den tabell du behöver via dess [set_AlternativeText()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/set_alternativetext/) .
5. Använd [ITable](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itable/)‑objektet för att arbeta med tabellen. I exemplet nedan lade vi till en ny rad i tabellen.
6. Spara den ändrade presentationen.

Denna C++-kod visar hur du får åtkomst till och arbetar med en befintlig tabell:

```c++
// Instansierar en Presentation-klass som representerar en PPTX-fil
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Hämtar den första bilden
auto sld = pres->get_Slides()->idx_get(0);

// Initierar null Table
System::SharedPtr<ITable> tbl;

// Itererar genom formerna och sätter en referens till den hittade tabellen
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Sätter texten för den första kolumnen i den andra raden
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Sparar den ändrade presentationen till disk
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Justera text i en tabell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) .
2. Hämta en referens till en bild genom dess index. 
3. Lägg till ett [ITable](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itable/)‑objekt på bilden. 
4. Få åtkomst till ett [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/)‑objekt från tabellen. 
5. Få åtkomst till [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/)‑[IParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/) .
6. Justera texten vertikalt.
7. Spara den ändrade presentationen.

Denna C++-kod visar hur du justerar texten i en tabell:

```c++
// Skapar en instans av Presentation-klassen
auto presentation = System::MakeObject<Presentation>();

// Hämtar den första bilden
auto slide = presentation->get_Slides()->idx_get(0);

// Definierar kolumner med bredder och rader med höjder
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Lägger till tabellformen på bilden
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Hämtar textramen
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Skapar Paragraph-objektet för textramen
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Skapar Portion-objektet för stycket
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Justerar texten vertikalt
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Sparar Presentation till disk
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Ställ in textformatering på tabellnivå**

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑klassen.
2. Hämta en referens till en bild genom dess index. 
3. Få åtkomst till ett [ITable](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itable/)‑objekt från bilden.
4. Ställ in [set_FontHeight()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/baseportionformat/set_fontheight/) för texten. 
5. Ställ in [set_Alignment()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_alignment/) och [set_MarginRight()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_marginright/) .
6. Ställ in [set_TextVerticalType()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/textframeformat/set_textverticaltype/) .
7. Spara den ändrade presentationen. 

Denna C++-kod visar hur du använder dina föredragna formateringsalternativ på texten i en tabell:

```c++
// Skapar en instans av Presentation-klassen
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Anta att den första formen på den första bilden är en tabell
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Ställer in cellernas teckenhöjd i tabellen
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Ställer in cellernas textjustering och högermarginal i ett anrop
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Ställer in cellernas vertikala texttyp
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Hämta tabellstilsattribut**

Aspose.Slides låter dig hämta stilattributen för en tabell så att du kan använda dessa uppgifter för en annan tabell eller någon annanstans. Denna C++-kod visar hur du får stilattributen från en förinställd tabellstil:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Lås bildförhållandet för en tabell**

Bildförhållandet för en geometrisk form är förhållandet mellan dess storlekar i olika dimensioner. Aspose.Slides tillhandahåller egenskapen `AspectRatioLocked()` för att låta dig låsa bildförhållandeinställningen för tabeller och andra former. 

Denna C++-kod visar hur du låser bildförhållandet för en tabell:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Kan jag aktivera läsriktning från höger till vänster (RTL) för en hel tabell och texten i dess celler?**

Ja. Tabellen har en [set_RightToLeft](https://reference.aspose.com/slides/sv/cpp/aspose.slides/table/set_righttoleft/)‑metod, och stycken har [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/sv/cpp/aspose.slides/paragraphformat/set_righttoleft/). Att använda båda säkerställer korrekt RTL‑ordning och rendering i cellerna.

**Hur kan jag förhindra att användare flyttar eller ändrar storlek på en tabell i den slutgiltiga filen?**

Använd [shape locks](/slides/sv/cpp/applying-protection-to-presentation/) för att inaktivera flytt, storleksändring, markering etc. Dessa lås gäller även för tabeller.

**Stöds det att infoga en bild i en cell som bakgrund?**

Ja. Du kan ange en [picture fill](https://reference.aspose.com/slides/sv/cpp/aspose.slides/picturefillformat/) för en cell; bilden kommer att täcka cellområdet enligt valt läge (sträcka eller mosaik).