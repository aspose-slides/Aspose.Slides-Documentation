---
title: Fungující řešení pro změnu velikosti grafu v PPTX
type: docs
weight: 60
url: /cs/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- změna velikosti grafu
- graf Excel
- objekt OLE
- vložit graf
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Opravte neočekávanou změnu velikosti grafu v PPTX při použití vložených objektů Excel OLE s Aspose.Slides pro C++. Nastavte pevné rozměry grafu, aby byly velikosti grafu a OLE rámečku konzistentní."
---
## **Pozadí**

Grafy Excel vložené jako objekty OLE v prezentacích PowerPoint pomocí komponent Aspose mohou po první aktivaci změnit velikost. To může způsobit výrazný rozdíl v vzhledu grafu před a po aktivaci. Tento článek vysvětluje, proč dochází k změně velikosti, a ukazuje, jak tomu zabránit tím, že pevné rozměry grafu přizpůsobíme OLE rámečku.

V [Vytvořit grafy Excel a vložit je jako objekty OLE v prezentacích](/slides/cs/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) jsme vysvětlili, jak vytvořit graf Excel pomocí Aspose.Cells pro C++ a vložit jej do prezentace PowerPoint pomocí Aspose.Slides pro C++. Pro řešení [problém s náhledem objektu](/slides/cs/cpp/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek grafu k OLE objektovému rámečku grafu. Ve výstupní prezentaci, když dvakrát kliknete na OLE objektový rámeček zobrazující obrázek grafu, aktivuje se graf Excel. Uživatelé mohou editovat vložený sešit Excel a poté se vrátit na snímek kliknutím mimo aktivovaný sešit. Velikost OLE objektového rámečku se změní, když se uživatel vrátí na snímek, a faktor změny velikosti se liší v závislosti na původních rozměrech jak OLE rámečku, tak vloženého sešitu Excel.

## **Příčina změny velikosti**

Vložený sešit Excel má vlastní rozměry okna, které se Excel snaží zachovat při první aktivaci objektu. OLE rámeček na snímku má samostatně definované rozměry. Když je sešit Excel aktivován, Excel a PowerPoint dohodnou velikost objektu tak, aby zachovaly jeho proporce jako součást procesu vložení. Rozdíly mezi oknem sešitu a OLE rámečkem proto mohou způsobit změnu velikosti objektu.

## **Funkční řešení**

Přizpůsobte velikost grafu OLE rámečku na snímku a udržujte rozměry grafu nezávislé na okně sešitu. Toto řešení funguje jak s novou prezentací, tak s existujícím šablonou.

Příklad vyžaduje Aspose.Cells pro C++ a Aspose.Slides pro C++. Vytvoří jednoduchý sloupcový graf na aktivním listu grafu a vloží sešit ve formátu XLS. Náhledový obrázek grafu není přiřazen; graf se stane viditelným, když je OLE objekt aktivován v PowerPointu.

Umístěte ukázkový kód do vstupního bodu vaší aplikace, přičemž deklarace include umístěte v souborovém rozsahu. Inicializujte Aspose.Cells před vytvářením jeho objektů a uvolněte jeho zdroje po zničení těchto objektů. Příklad zkopíruje vektor bajtů sešitu vrácený Aspose.Cells do pole typu akceptovaného Aspose.Slides.

Příklad vytvoří novou prezentaci s OLE rámečkem o velikosti 9,5 × 4 palce umístěným 0,5 palce od levého okraje a 1 palec od horního okraje. Souřadnice a rozměry snímku jsou v bodech (72 bodů na palec). Pro existující prezentaci viz [Použít šablonu](#use-a-template).

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartShape.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/PrintSizeType.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <algorithm>
#include <cstdint>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"Data");
    dataSheet.GetCells().Get(u"A1").PutValue(10);
    dataSheet.GetCells().Get(u"A2").PutValue(20);

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, 20, 10);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(u"Data!A1:A2", true);
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Souřadnice a rozměry snímku jsou v bodech (72 bodů na palec).
    auto width = 684.f; // 9,5 palce.
    auto height = 288.f; // 4 palce.

    chart.SetSizeWithWindow(false);
    // Převést body na pixely grafu pomocí 96 pixelů na palec.
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // Zkopírovat vektor bajtů Cells do typu pole akceptovaného Slides.
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **Nastavit pevnou velikost grafu**

Nastavte [Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) na false, aby rozměry grafu byly nezávislé na okně sešitu. Nastavte rozměry pomocí [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) skrze [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) a [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/), přičemž převádíte body na pixely pomocí 96 pixelů na palec: rámec o rozměrech 684 × 288 bodů odpovídá grafu o rozměrech 912 × 384 pixelů. Nastavte [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) na vlastní hodnotu [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/). Příklad vloží sešit pomocí [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) a uloží prezentaci s OLE rámečkem o rozměrech 9,5 × 4 palce.

## **Použít šablonu**

Logika velikosti je stejná pro existující prezentaci. Pro úpravu příkladu:

1. Načtěte šablonu prezentace místo vytváření prázdné prezentace.
2. Zkontrolujte, že první snímek obsahuje alespoň tři objekty, a poté použijte objekt s indexem 2 jako zástupný.
3. Vezměte šířku a výšku rámečku z tohoto objektu místo použití pevných hodnot 684 a 288. Nechte výpočty velikosti beze změny.
4. Přidejte OLE rámeček na pozici zástupného místo pevných souřadnic 36 a 72.
5. Odstraňte zástupný před uložením prezentace.

## **FAQ**

**Proč se můj vložený graf Excel mění po aktivaci v PowerPointu?**

K tomu dochází, protože Excel se při první aktivaci snaží obnovit původní velikost okna, zatímco OLE objektový rámeček v PowerPointu má vlastní rozměry. PowerPoint a Excel dohodnou velikost tak, aby zachovaly poměr stran, což může způsobit změnu velikosti.

**Jak mohu udržet velikosti grafu a OLE rámečku konzistentní?**

Nastavte pevné rozměry grafu, které odpovídají OLE rámečku, a použijte vlastní velikost tisku grafu před vložením sešitu. Výše uvedený příklad ukazuje požadovaná nastavení a převody jednotek.

**Je přizpůsobení velikosti okna sešitu dostatečné?**

Pouhé přizpůsobení velikosti okna sešitu spolehlivě nebrání změně velikosti OLE rámečku po aktivaci. Použijte pevné rozměry grafu, jak je ukázáno v příkladu.

**Funguje toto řešení jak pro prezentace založené na šabloně, tak pro nové prezentace?**

Ano. Pro šablonu použijte rozměry a pozici zástupného. Pro novou prezentaci určete rozměry a pozici rámečku přímo.

**Mohu tento příklad použít s grafy vytvořenými v jiných tabulkových programech?**

Příklad používá sešit Excel vytvořený pomocí Aspose.Cells. Neukazuje chování aktivace pro jiné tabulkové programy.

## **Related Sections**

- [Vytvořit grafy Excel a vložit je jako objekty OLE v prezentacích](/slides/cs/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)