---
title: Excel Grafiklerini Oluşturun ve Sunumlarda OLE Nesnesi Olarak Gömün
type: docs
weight: 40
url: /tr/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel grafiği
- grafik gömme
- OLE nesnesi
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Cells for C++ ile bir Excel grafiği oluşturun ve Aspose.Slides ile bir PowerPoint sunumuna çalışma kitabını gömün, grafik önizlemesi dahil."
---
## **Genel Bakış**

Bu makale, Aspose.Cells for C++ ile bir Excel sütun grafik nasıl oluşturulacağını ve bu çalışma kitabının Aspose.Slides for C++ ile bir PowerPoint sunumuna nasıl gömüleceğini gösterir. Gömülü çalışma kitabı hem kaynak verileri hem de grafiği içerir. Ayrı bir PNG önizleme, OLE nesnesi etkinleştirilmeden önce slaytta grafiği gösterir.

Sonuç, yerel bir PowerPoint grafik değil, gömülü bir Excel nesnesidir. OLE aracılığıyla çalışma kitabını düzenlemek, OLE etkinleştirmesini destekleyen bir masaüstü uygulaması ve uyumlu bir Excel kurulumunu gerektirir.

## **Ön Koşullar**

C++ projenizi Aspose.Cells for C++ ve Aspose.Slides for C++ başlıkları ve kütüphaneleriyle yapılandırın. Örnek kodu uygulamanızın giriş noktasına yerleştirin, include deklarasyonları dosya kapsamında olsun. Microsoft Office, bu kütüphanelerle sunumu oluşturmak için gerekli değildir.

Hiçbir giriş dosyasına gerek yoktur: örnek, verileri ve grafiği bellekte oluşturur, ardından `OutputChart.pptx` dosyasını geçerli çalışma dizinine yazar. Değerlendirme modunun dışında çalıştırırken her iki ürün için de lisansları uygulayın.

## **Gömme Nasıl Çalışır**

1. Veri çalışma sayfası ve grafik sayfası içeren bir çalışma kitabı oluşturun.  
2. Çalışma kitabının grafikte açılması için grafik sayfasını aktif hâle getirin.  
3. Çalışma kitabının OLE gösterim aralığını ayarlayın ve grafiği PNG olarak render edin.  
4. Çalışma kitabını bellek içinde XLSX olarak kaydedin ve bu baytları bir slayta gömün.  
5. PNG'yi OLE nesnesinin önizlemesi olarak atayın ve sunumu PPTX olarak kaydedin.

Çalışma kitabı gösterim aralığı ile slayttaki çerçeve farklı görevlere sahiptir. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) sıfır‑bazlı başlangıç/bitiş satır ve sütun indekslerini alır. [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) ise üst satır, sol sütun, alt satır ve sağ sütunu alır. Örnek, alt‑sağ sınır olarak satır indeksi 55 ve sütun indeksi 25'i kullanır; bu değerler düzen tercihleridir, veri satır veya sütun sayısını göstermez.

Slayt çerçevesi nokta birimini kullanır. Örnek, çerçeveyi slayt içinde sığdırır ve PNG'nin en‑boy oranını koruyarak ortalar, önizlemeyi slaytı dolduracak şekilde uzatmaz.

## **Grafiği Oluşturma ve Gömme**

Aşağıdaki tam örnek, `DataSheet`i dört satır ve beş sütun değerle doldurur. Her satır bir grafik serisi olur. Çalışma kitabı kaydedilmeden önce `ChartSheet` aktif sayfa olarak seçilir.

Çalışma kitabı, [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/)’ye geçirilen `xlsx` uzantısıyla eşleşecek şekilde açıkça XLSX olarak kaydedilir. PNG, ara bir bitmap dönüşümü olmadan bellek içi bir akıştan yüklenir. Aspose.Cells bayt vektörleri döndürür; örnek bu vektörleri Aspose.Slides tarafından kabul edilen dizi tipine kopyalar. Aspose.Cells'i nesnelerini kullanmadan önce başlatın ve bu nesneler yok edildikten sonra kaynaklarını serbest bırakın. [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) aracılığıyla atama, varsayılan OLE yer tutucusunu değiştirir.

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

// Cells'i herhangi bir nesne oluşturmadan önce başlatın.
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

    // Grafik önizlemesini renderlayın ve düzenlenebilir çalışma kitabını ayrı ayrı serileştirin.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // Cells tamponlarını Slides tarafından kullanılan dizi tipine kopyalayın.
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

    // Önizlemeyi slayt içinde, en-boy oranını değiştirmeden sığdırın.
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
// Tüm Cells nesneleri yok edildikten sonra Cells kaynaklarını serbest bırakın.
Aspose::Cells::Cleanup();
```

## **Beklenen Sonuç**

`OutputChart.pptx` bir gömülü Excel çalışma kitabı ve bir grafik önizlemesi içeren bir slayt içerir. Çalışma kitabı orijinal verileri ve dört seri içeren bir sütun grafiği barındırır. Önizleme slayt üzerinde ortalanmış ve oranlarını korur.

![Gömülü çalışma kitabının önizlemesi olarak gösterilen Excel sütun grafiği](excel-chart-ole-preview.png)

Excel'in kurulu olduğu uyumlu bir masaüstü PowerPoint ortamında, nesneyi çift tıklayarak gömülü çalışma kitabını etkinleştirebilir ve düzenleyebilirsiniz. Etkinleştirme ve düzenleme, ana uygulamanın OLE desteği ve güvenlik ayarlarına bağlıdır.

## **SSS**

**Neden bir önizleme görüntüsü gerekir?**  
Gömülü çalışma kitabı ve slayt önizlemesi ayrı içeriklerdir. Slaytta varsayılan "EMBEDDED OLE OBJECT" yer tutucusu yerine grafiği göstermek için bir grafik resmi sağlayın. Bakınız [OleObjectFrame Eklerken Nesne Önizleme Sorunu](/slides/tr/cpp/object-preview-issue-when-adding-oleobjectframe/).

**Kod içinde çalışma kitabını değiştirdiğimde önizleme otomatik olarak güncellenir mi?**  
Önizlemeyi bir anlık görüntü olarak kabul edin. Çalışma kitabı verilerini programlı olarak güncellediğinizde, grafik görüntüsünü yeniden oluşturun ve hem önizlemeyi hem de gömülü çalışma kitabı verisini değiştirin.

**XLSX yerine XLS kullanabilir miyim?**  
Evet. Çalışma kitabını XLS formatında kaydedin ve gömülü veri uzantısı olarak `xls` kullanın. Uzantı, gerçek çalışma kitabı formatıyla eşleşmelidir; yalnızca uzantıyı değiştirmek veriyi dönüştürmez.

**Nesne etkinleştirildikten sonra boyutu neden değişebilir?**  
Ana uygulama, çalışma kitabını etkinleştirdiğinde OLE nesnesinin sunumunu güncelleyebilir. Çalışma kitabının OLE gösterim aralığı ve slayt çerçevesi boyutları her ikisi de önemlidir. Bakınız [PPTX'te Grafik Yeniden Boyutlandırma için Çözüm](/slides/tr/cpp/working-solution-for-chart-resizing-in-pptx/).

## **İlgili Bölümler**

- [PPTX'te Grafik Yeniden Boyutlandırma için Çözüm](/slides/tr/cpp/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame Eklerken Nesne Önizleme Sorunu](/slides/tr/cpp/object-preview-issue-when-adding-oleobjectframe/)