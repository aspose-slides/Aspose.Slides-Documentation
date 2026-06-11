---
title: Fungerande lösning för diagramstorleksändring i PPTX
type: docs
weight: 60
url: /sv/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagramstorleksändring
- Excel-diagram
- OLE-objekt
- bädda in diagram
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Åtgärda oväntad diagramstorleksändring i PPTX när du använder inbäddade Excel OLE‑objekt med Aspose.Slides för C++. Lär dig två metoder med kod för att hålla storlekarna konsekventa."
---
## **Bakgrund**

Det har observerats att Excel‑diagram som bäddas in som OLE‑objekt i en PowerPoint‑presentation via Aspose‑komponenter ändrar storlek till en ospecificerad skala efter sin första aktivering. Detta beteende orsakar en märkbar visuell skillnad i presentationen mellan diagrammets tillstånd före och efter aktivering. Aspose‑teamet har undersökt problemet i detalj och har hittat en lösning. Denna artikel beskriver orsakerna till problemet och den motsvarande åtgärden.

I [föregående artikel](/slides/sv/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) förklarade vi hur man skapar ett Excel‑diagram med Aspose.Cells för C++ och bäddar in det i en PowerPoint‑presentation med Aspose.Slides för C++. För att åtgärda [problemet med förhandsgranskning av objekt](/slides/sv/cpp/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi diagrambilden till diagrammets OLE‑objekt‑ram. I den resulterande presentationen, när du dubbelklickar på OLE‑objekt‑ramen som visar diagrambilden, aktiveras Excel‑diagrammet. Slutanvändare kan göra önskade ändringar i den underliggande Excel‑arbetsboken och sedan återgå till motsvarande bild genom att klicka utanför den aktiverade arbetsboken. Storleken på OLE‑objekt‑ramen ändras när användaren återvänder till bilden, och förändringsfaktorn varierar beroende på de ursprungliga storlekarna för både OLE‑objekt‑ramen och den inbäddade Excel‑arbetsboken.

## **Orsak till storleksändring**

Eftersom Excel‑arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid första aktiveringen. OLE‑objekt‑ramen har däremot sin egen storlek. Enligt Microsoft, när Excel‑arbetsboken aktiveras, förhandlar Excel och PowerPoint om storleken och behåller korrekta proportioner som en del av inbäddningsprocessen. Beroende på skillnaderna mellan Excel‑fönsterstorleken och OLE‑objekt‑ramens storlek eller position sker en storleksändring.

## **Fungerande lösning**

Det finns två möjliga scenarier för att skapa PowerPoint‑presentationer med Aspose.Slides för C++.

**Scenario 1:** Skapa en presentation baserad på en befintlig mall.

**Scenario 2:** Skapa en presentation från början.

Lösningen vi presenterar här gäller för båda scenarierna. Grunden för alla lösningsmetoder är densamma: **det inbäddade OLE‑objektets fönsterstorlek ska matcha OLE‑objekt‑ramen i PowerPoint‑bilden**. Vi kommer nu att diskutera de två tillvägagångssätten för denna lösning.

## **Första tillvägagångssättet**

I detta tillvägagångssätt lär vi oss hur man ställer in fönsterstorleken för den inbäddade Excel‑arbetsboken så att den matchar storleken på OLE‑objekt‑ramen i PowerPoint‑bilden.

**Scenario 1**

Anta att vi har en definierad mall och vill skapa presentationer baserade på den. Föreställ dig att det finns en form på index 2 i mallen där vi vill placera en OLE‑ram som innehåller en inbäddad Excel‑arbetsbok. I detta scenario är storleken på OLE‑objekt‑ramen fördefinierad – den matchar storleken på formen på index 2 i mallen. Allt vi behöver göra är att sätta arbetsbokens fönsterstorlek lika med formens storlek. Följande kodsnutt uppfyller detta syfte:

```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// Definiera diagrammets storlek med ett fönster. 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// Ange arbetsbokens fönsterbredd i tum (delat med 72 eftersom PowerPoint använder 72 pixlar per tum).
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// Ange arbetsbokens fönsterhöjd i tum.
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// Spara arbetsboken till en minnesström.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Skapa en OLE‑objekt‑ram med de inbäddade Excel‑data.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```

**Scenario 2**

Låt oss säga att vi vill skapa en presentation från början och inkludera en OLE‑objekt‑ram av vilken storlek som helst med en inbäddad Excel‑arbetsbok. I kodsnutten nedan skapar vi en OLE‑objekt‑ram som är 4 tum hög och 9,5 tum bred på positionen x = 0,5 tum och y = 1 tum på bilden. Därefter sätter vi Excel‑arbetsbokens fönster till samma storlek – 4 tum hög och 9,5 tum bred.

```cpp
// Vår önskade höjd.
int32_t desiredHeight = 288; // 4 tum (4 * 72)

// Vår önskade bredd.
int32_t desiredWidth = 684; // 9,5 tum (9,5 * 72)

// Definiera diagrammets storlek med ett fönster. 
chart->SetSizeWithWindow(true);

// Ange arbetsbokens fönsterbredd i tum.
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// Ange arbetsbokens fönsterhöjd i tum.
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// Spara arbetsboken till en minnesström.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Skapa en OLE‑objekt‑ram med de inbäddade Excel‑data.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **Andra tillvägagångssättet**

I detta tillvägagångssätt lär vi oss hur man ställer in diagrammets storlek i den inbäddade Excel‑arbetsboken så att den matchar storleken på OLE‑objekt‑ramen i PowerPoint‑bilden. Detta tillvägagångssätt är användbart när diagrammets storlek är känd i förväg och aldrig kommer att ändras.

**Scenario 1**

Anta att vi har en definierad mall och vill skapa presentationer baserade på den. Föreställ dig att det finns en form på index 2 i mallen där vi avser att placera en OLE‑ram med en inbäddad Excel‑arbetsbok. I detta scenario är OLE‑ramens storlek fördefinierad – den matchar storleken på formen på index 2 i mallen. Allt vi behöver göra är att sätta diagrammets storlek i arbetsboken lika med formens storlek. Följande kodsnutt uppfyller detta syfte:

```cpp
// Definiera diagrammets storlek utan ett fönster. 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// Ange diagrammets bredd i pixlar (multiplicera med 96 eftersom Excel använder 96 pixlar per tum).    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// Ange diagrammets höjd i pixlar.
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// Definiera diagrammets utskriftsstorlek.
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// Spara arbetsboken till en minnesström.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Skapa en OLE‑objekt‑ram med de inbäddade Excel‑data.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```

**Scenario 2**

Anta att vi vill skapa en presentation från början och inkludera en OLE‑objekt‑ram av vilken storlek som helst med en inbäddad Excel‑arbetsbok. I kodsnutten nedan skapar vi en OLE‑objekt‑ram med en höjd på 4 tum och en bredd på 9,5 tum på bilden på positionen x = 0,5 tum och y = 1 tum. Vi sätter även diagrammets storlek till samma mått: en höjd på 4 tum och en bredd på 9,5 tum.

```cpp
// Vår önskade höjd.
int32_t desiredHeight = 288; // 4 tum (4 * 576)

// Vår önskade bredd.
int32_t desiredWidth = 684; // 9,5 tum(9,5 * 576)

// Definiera diagrammets storlek utan ett fönster. 
chart->SetSizeWithWindow(false);

// Ange diagrammets bredd i pixlar.    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// Ange diagrammets höjd i pixlar.
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// Spara arbetsboken till en minnesström.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Skapa en OLE‑objekt‑ram med de inbäddade Excel‑data.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **Slutsats**

Det finns två tillvägagångssätt för att lösa problemet med diagramstorleksändring. Valet av tillvägagångssätt beror på krav och användningsfall. Båda metoderna fungerar på samma sätt oavsett om presentationerna skapas från en mall eller från början. Dessutom finns det ingen begränsning för storleken på OLE‑objekt‑ramen i denna lösning.

## **FAQ**

**Varför ändrar mitt inbäddade Excel‑diagram storlek efter att det aktiverats i PowerPoint?**

Detta beror på att Excel försöker återställa sin ursprungliga fönsterstorlek vid första aktiveringen, medan OLE‑objekt‑ramen i PowerPoint har egna dimensioner. PowerPoint och Excel förhandlar om storleken för att behålla bildförhållandet, vilket kan leda till storleksändring.

**Är det möjligt att helt förhindra detta storleksproblem?**

Ja. Genom att matcha Excel‑arbetsbokens fönsterstorlek eller diagrammets storlek till OLE‑objekt‑ramens storlek innan inbäddning kan du hålla diagrammen i samma storlek.

**Vilket tillvägagångssätt ska jag välja, att sätta arbetsbokens fönsterstorlek eller diagramstorlek?**

Använd **Tillvägagångssätt 1 (fönsterstorlek)** om du vill behålla arbetsbokens bildförhållande och eventuellt tillåta storleksändring senare.  
Använd **Tillvägagångssätt 2 (diagramstorlek)** om diagrammets dimensioner är fasta och inte kommer att ändras efter inbäddning.

**Fungerar dessa metoder både för mallbaserade presentationer och nya presentationer?**

Ja. Båda tillvägagångssätten fungerar lika för presentationer skapade från mallar och för nya presentationer.

**Finns det någon begränsning för OLE‑objekt‑ramens storlek?**

Nej. Du kan sätta OLE‑ramen till vilken storlek som helst så länge den skalas korrekt i förhållande till arbetsboken eller diagrammet.

**Kan jag använda dessa metoder med diagram skapade i andra kalkylprogram?**

Exemplen är avsedda för Excel‑diagram skapade med Aspose.Cells, men principerna gäller även för andra OLE‑kompatibla kalkylprogram så länge de stödjer liknande storleksalternativ.

## **Relaterade avsnitt**

- [Skapa Excel‑diagram och bädda in dem som OLE‑objekt i presentationer](/slides/sv/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)