---
title: PPTX'te Grafik Yeniden Boyutlandırma İçin Çalışan Çözüm
type: docs
weight: 60
url: /tr/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafik yeniden boyutlandırma
- Excel grafiği
- OLE nesnesi
- grafiği gömme
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile gömülü Excel OLE nesneleri kullanıldığında PPTX'te beklenmeyen grafik yeniden boyutlandırmayı düzeltin. Grafiği ve OLE çerçevesi boyutlarını tutarlı tutmak için sabit grafik boyutları ayarlayın."
---
## **Arka Plan**

Aspose bileşenlerini kullanan PowerPoint sunumlarında OLE nesneleri olarak gömülmüş Excel grafikleri ilk etkinleştirmelerinden sonra boyutunu değiştirebilir. Bu, grafiğin etkinleştirme öncesi ve sonrası görünümü arasında belirgin bir fark yaratabilir. Bu makale, yeniden boyutlandırmanın neden gerçekleştiğini açıklar ve sabit grafik boyutlarını OLE çerçevesiyle eşleştirerek nasıl önleneceğini gösterir.

In [Excel Grafiklerini Oluştur ve OLE Nesneleri Olarak Sunumlara Göm](/slides/tr/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), we explained how to create an Excel chart with Aspose.Cells for C++ and embed it in a PowerPoint presentation using Aspose.Slides for C++. To address the [nesne önizleme sorunu](/slides/tr/cpp/object-preview-issue-when-adding-oleobjectframe/), we assigned the chart image to the chart’s OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the chart image, the Excel chart is activated. Users can edit the embedded Excel workbook and then return to the slide by clicking outside the activated workbook. The size of the OLE object frame changes when the user returns to the slide, and the resizing factor varies depending on the original sizes of both the OLE object frame and the embedded Excel workbook.

## **Yeniden Boyutlandırmanın Nedeni**

Gömülü Excel çalışma kitabının kendi pencere boyutları vardır ve Excel nesne ilk etkinleştirildiğinde bu boyutları korumaya çalışır. Slayttaki OLE çerçevesi ise bağımsız olarak tanımlanmış boyutlara sahiptir. Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint nesnenin boyutunu, yerleştirme işleminin bir parçası olarak oranını koruyacak şekilde müzakere eder. Çalışma kitabı penceresi ile OLE çerçevesi arasındaki farklar nesnenin yeniden boyutlandırılmasına neden olabilir.

## **Çalışan Çözüm**

Grafiğin boyutunu slayttaki OLE çerçevesiyle eşleştirin ve grafik boyutlarını çalışma kitabı penceresinden bağımsız tutun. Bu çözüm yeni bir sunumda veya mevcut bir şablonda çalışır.

Örnek, Aspose.Cells for C++ ve Aspose.Slides for C++ gerektirir. Aktif bir grafik sayfasında basit bir sütun grafik oluşturur ve çalışma kitabını XLS biçiminde gömer. Grafik önizleme resmi atanmamıştır; grafik PowerPoint'te OLE nesnesi etkinleştirildiğinde görünür hale gelir.

Örnek kodu uygulamanızın giriş noktasına yerleştirin ve include bildirimlerini dosya kapsamına ekleyin. Aspose.Cells nesnelerini oluşturmadan önce başlatın ve bu nesneler yok edildikten sonra kaynaklarını serbest bırakın. Örnek, Aspose.Cells tarafından döndürülen çalışma kitabı bayt vektörünü Aspose.Slides tarafından kabul edilen dizi türüne kopyalar.

Örnek, sol kenardan 0.5 inç ve üstten 1 inç uzaklıkta konumlandırılmış 9.5 × 4 inçlik bir OLE çerçevesiyle yeni bir sunum oluşturur. Slayt koordinatları ve boyutları puan cinsindendir (inç başına 72 puan). Mevcut bir sunum için, [Şablonu Kullan](#use-a-template) bölümüne bakın.

## **Sabit Grafik Boyutu Ayarla**

Set [Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) to false so that the chart dimensions are independent of the workbook window. Set the [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) dimensions through [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) and [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/), converting points to pixels using 96 pixels per inch: a frame measuring 684 × 288 points corresponds to a chart measuring 912 × 384 pixels. Set [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) to the Custom value of [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/). The example embeds the workbook with [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) and saves a presentation with a 9.5 × 4‑inch OLE frame.

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

    // Slayt koordinatları ve boyutları puan cinsindedir (inç başına 72 puan).
    auto width = 684.f; // 9.5 inç.
    auto height = 288.f; // 4 inç.

    chart.SetSizeWithWindow(false);
    // Puanları inç başına 96 piksel kullanarak grafik piksellerine dönüştür.
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // Cells bayt vektörünü Slides tarafından kabul edilen dizi tipine kopyala.
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **Şablonu Kullan**

The sizing logic is the same for an existing presentation. To adapt the example:

1. Load the template presentation instead of creating an empty presentation.
2. Check that the first slide contains at least three shapes, then use the shape at index 2 as the placeholder.
3. Take the frame width and height from that shape instead of using the fixed values 684 and 288. Keep the sizing calculations unchanged.
4. Add the OLE frame at the placeholder's position instead of the fixed coordinates 36 and 72.
5. Remove the placeholder before saving the presentation.

## **SSS**

**Neden gömülü Excel grafiğim PowerPoint'te etkinleştirildikten sonra boyutunu değiştiriyor?**

Excel, nesne ilk etkinleştirildiğinde orijinal pencere boyutunu geri yüklemeye çalışır, ancak PowerPoint'teki OLE nesnesi çerçevesinin kendi boyutları vardır. PowerPoint ve Excel, en boy oranını korumak için boyutu müzakere eder; bu da yeniden boyutlandırmaya neden olabilir.

**Grafik ve OLE çerçevesi boyutlarını nasıl tutarlı hale getirebilirim?**

Grafik boyutlarını OLE çerçevesiyle eşleşecek şekilde sabitleyin ve çalışma kitabını gömmeden önce özel bir grafik baskı boyutu kullanın. Yukarıdaki örnek gerekli ayarları ve birim dönüşümlerini gösterir.

**Çalışma kitabı pencere boyutunu eşleştirmek yeterli mi?**

Çalışma kitabı pencere boyutunu eşleştirmek tek başına OLE çerçevesinin etkinleştirme sonrası boyut değiştirmesini güvenilir şekilde önlemez. Örnekte gösterildiği gibi sabit grafik boyutlarını kullanın.

**Bu çözüm şablon tabanlı sunumlar ve yeni sunumlar için de çalışıyor mu?**

Evet. Şablon için yer tutucunun boyut ve konumunu kullanın. Yeni bir sunum için çerçeve boyutları ve konumunu doğrudan belirtin.

**Bu örneği diğer elektronik tablo programlarında oluşturulan grafiklerle kullanabilir miyim?**

Örnek, Aspose.Cells ile oluşturulmuş bir Excel çalışma kitabı kullanır. Diğer elektronik tablo programları için etkinleştirme davranışını göstermemektedir.

## **İlgili Bölümler**

- [Excel Grafiklerini Oluştur ve OLE Nesneleri Olarak Sunumlara Göm](/slides/tr/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)