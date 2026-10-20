---
title: Vytvořit grafy Excel a vložit je do prezentací jako OLE objekty
type: docs
weight: 40
url: /cs/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- graf Excelu
- vložit graf
- OLE objekt
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Vytvořte graf Excel pomocí Aspose.Cells pro C++ a vložte sešit do prezentace PowerPoint s Aspose.Slides, včetně náhledu grafu."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit sloupcový graf Excelu pomocí Aspose.Cells pro C++ a vložit jeho sešit do prezentace PowerPoint pomocí Aspose.Slides pro C++. Vložený sešit obsahuje jak zdrojová data, tak graf. Samostatná ukázka PNG zobrazuje graf na snímku před aktivací objektu OLE.

Výsledkem je vložený objekt Excel, nikoli nativní graf PowerPointu. Úprava sešitu přes OLE vyžaduje desktopovou aplikaci, která podporuje aktivaci OLE, a kompatibilní instalaci Excelu.

## **Požadavky**

Nakonfigurujte svůj projekt C++ s hlavičkami a knihovnami pro Aspose.Cells pro C++ a Aspose.Slides pro C++. Umístěte ukázkový kód do vstupního bodu aplikace, s deklaracemi include na úrovni souboru. Microsoft Office není vyžadován pro generování prezentace s těmito knihovnami.

Nejsou vyžadovány vstupní soubory: ukázka vytvoří data a graf v paměti a poté zapíše `OutputChart.pptx` do aktuálního pracovního adresáře. Použijte licence pro oba produkty při spuštění mimo hodnotící režim.

## **Jak funguje vkládání**

1. Vytvořte sešit s listem dat a listem grafu.
1. Nastavte list grafu jako aktivní, aby se sešit otevřel na grafu.
1. Nastavte OLE zobrazovací oblast sešitu a vykreslete graf do PNG.
1. Uložte sešit jako XLSX v paměti a vložte tyto bajty do snímku.
1. Přiřaďte PNG jako náhled objektu OLE a uložte prezentaci jako PPTX.

Zobrazovací oblast sešitu a rámeček na snímku mají různé role. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) přijímá nulové indexy počátečního/koncového řádku a sloupce. [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) naopak přijímá horní řádek, levý sloupec, dolní řádek a pravý sloupec. Příklad používá index řádku 55 a index sloupce 25 jako pravé dolní hranice; tyto hodnoty jsou volby rozvržení, nikoli počet datových řádků nebo sloupců.

Rámeček snímku používá jednotku point. Příklad jej umístí do snímku a vycentruje, přičemž zachovává poměr stran PNG, místo aby natahoval náhled tak, aby vyplnil snímek.

## **Vytvoření a vložení grafu**

Následující kompletní příklad naplní `DataSheet` čtyřmi řádky a pěti sloupci hodnot. Každý řádek se stane řadou grafu. `ChartSheet` je vybrán jako aktivní list před uložením sešitu.

Sešit je explicitně uložen jako XLSX, což odpovídá příponě `xlsx` předané do [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/). PNG je načteno z paměťového proudu bez mezi-konverze bitmapy. Aspose.Cells vrací vektory bajtů, které příklad kopíruje do pole typu akceptovaného Aspose.Slides. Inicializujte Aspose.Cells před použitím jeho objektů a uvolněte jeho prostředky po zničení těchto objektů. Přiřazení přes [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) nahrazuje výchozí OLE zástupný obrázek.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <Util/Images.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <algorithm>
#include <IImage.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

// Inicializujte Cells před vytvořením jakýchkoli jeho objektů.
Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"DataSheet");

    int32_t values[4][5] =
    {
        { 67, 44, 46, 43, 24 },
        { 86, 64, 97, 29, 40 },
        { 68, 89, 78, 69, 38 },
        { 91, 48, 60, 26, 25 }
    };

    for (auto row = 0; row < 4; row++)
    {
        for (auto column = 0; column < 5; column++)
        {
            dataSheet.GetCells().Get(row, column).PutValue(values[row][column]);
        }
    }

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    chartSheet.SetName(u"ChartSheet");

    auto lastChartRow = 55;
    auto lastChartColumn = 25;
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, lastChartRow, lastChartColumn);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    const char16_t* seriesRanges[] = { u"DataSheet!A1:E1", u"DataSheet!A2:E2", u"DataSheet!A3:E3", u"DataSheet!A4:E4" };
    for (auto range : seriesRanges)
    {
        chart.GetNSeries().Add(range, false);
    }

    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);
    workbook.GetWorksheets().SetOleSize(0, lastChartRow, 0, lastChartColumn);

    // Vykreslete náhled grafu a samostatně serializujte editovatelný sešit.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // Zkopírujte buffery Cells do typu pole používaného v Slides.
    auto toSlidesArray = [](const Aspose::Cells::Vector<uint8_t>& buffer)
    {
        auto result = System::MakeArray<uint8_t>(buffer.GetLength(), 0);
        std::copy(buffer.GetData(), buffer.GetData() + buffer.GetLength(), result->data_ptr());
        return result;
    };
    auto chartImageBytes = toSlidesArray(chartImageData);
    auto workbookBytes = toSlidesArray(workbookData);
    auto chartImageStream = System::MakeObject<System::IO::MemoryStream>(chartImageBytes);
    auto chartImage = Images::FromStream(chartImageStream);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto slideSize = presentation->get_SlideSize()->get_Size();

    // Umístěte náhled do snímku bez změny poměru stran.
    auto scale = (std::min)(slideSize.get_Width() / chartImage->get_Width(), slideSize.get_Height() / chartImage->get_Height());
    auto frameWidth = chartImage->get_Width() * scale;
    auto frameHeight = chartImage->get_Height() * scale;
    auto frameX = (slideSize.get_Width() - frameWidth) / 2;
    auto frameY = (slideSize.get_Height() - frameHeight) / 2;

    auto embeddedData = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xlsx");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
    auto previewImage = presentation->get_Images()->AddImage(chartImage);
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(previewImage);

    presentation->Save(u"OutputChart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
    chartImage->Dispose();
    chartImageStream->Dispose();
}
 // Uvolněte prostředky Cells po zničení všech objektů Cells.
Aspose::Cells::Cleanup();
```

## **Očekávaný výsledek**

`OutputChart.pptx` obsahuje jeden snímek s vloženým sešitem Excel a náhledem grafu. Sešit obsahuje původní data a sloupcový graf se čtyřmi řadami. Náhled je vycentrován na snímku a zachovává své proporce.

![Sloupcový graf Excel zobrazený jako náhled vloženého sešitu](excel-chart-ole-preview.png)

V kompatibilním desktopovém prostředí PowerPoint s nainstalovaným Excelem, dvojklikněte na objekt pro aktivaci a úpravu vloženého sešitu. Aktivace a úpravy závisí na podpoře OLE hostitelské aplikace a nastavení zabezpečení.

## **Často kladené dotazy**

**Proč je potřeba obraz náhledu?**

Vložený sešit a jeho náhled na snímku jsou oddělený obsah. Poskytněte obrázek grafu, aby snímek zobrazoval graf místo výchozího zástupného textu „EMBEDDED OLE OBJECT“. Viz [Problém s náhledem objektu při přidávání OleObjectFrame](/slides/cs/cpp/object-preview-issue-when-adding-oleobjectframe/).

**Aktualizuje se náhled automaticky při změně sešitu v kódu?**

Považujte náhled za snímek. Při programové aktualizaci dat sešitu vygenerujte znovu obrázek grafu a nahraďte náhled i data vloženého sešitu.

**Mohu použít XLS místo XLSX?**

Ano. Uložte sešit ve formátu XLS a použijte `xls` jako rozšíření vložených dat. Rozšíření musí odpovídat skutečnému formátu sešitu; změna rozšíření samotná data nepřevádí.

**Proč se objekt může po aktivaci změnit velikost?**

Hostitelská aplikace může aktualizovat prezentaci objektu OLE při aktivaci sešitu. Zobrazovací oblast OLE sešitu a rozměry rámečku snímku jsou oba důležité. Viz [Řešení pro změnu velikosti grafu v PPTX](/slides/cs/cpp/working-solution-for-chart-resizing-in-pptx/).

## **Související sekce**

- [Řešení pro změnu velikosti grafu v PPTX](/slides/cs/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Problém s náhledem objektu při přidávání OleObjectFrame](/slides/cs/cpp/object-preview-issue-when-adding-oleobjectframe/)