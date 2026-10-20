---
title: Çalışma Sayfası Yeniden Boyutlandırması İçin Çalışan Çözüm
type: docs
weight: 130
url: /tr/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- önizleme görüntüsü
- görüntü yeniden boyutlandırma
- Excel
- çalışma sayfası
- PowerPoint
- sunum
- C++
- Aspose.Slides for C++
description: "C++ kullanarak PowerPoint sunumlarında çalışma sayfası yeniden boyutlandırması için çalışan çözüm"
---
{{% alert color="info" title="Note" %}}

Aspose bileşenleri kullanılarak PowerPoint sunumuna OLE nesnesi olarak gömülen Excel çalışma sayfaları, ilk etkinleştirildikten sonra beklenmedik şekilde yeniden boyutlandırılabilir. Bu davranış, OLE nesnesinin etkinleştirilmeden önceki ve sonraki hallerinde belirgin bir görsel fark oluşturur. Bu makale sorunu açıklamakta ve çözmek için iki yolu tanımlamaktadır.

{{% /alert %}}

## **Arka Plan**

Bu makalede [OLE'yi Yönet](/slides/tr/cpp/manage-ole/), Aspose.Slides for C++ kullanarak bir PowerPoint sunumuna OLE çerçevesi eklemenin nasıl yapılacağını açıkladık. [nesne önizleme sorunu](/slides/tr/cpp/object-preview-issue-when-adding-oleobjectframe/) çözmek için, seçilen çalışma sayfası alanının bir görüntüsünü OLE nesne çerçevesine atadık. Çıktı sunumunda, çalışma sayfası görüntüsünü gösteren OLE nesne çerçevesine çift tıkladığınızda Excel çalışma kitabı etkinleştirilir. Son kullanıcılar gerçek Excel çalışma kitabında istedikleri değişiklikleri yapabilir ve etkinleştirilmiş Excel çalışma kitabının dışına tıklayarak slayta geri dönebilirler. Kullanıcı slayta döndüğünde OLE nesne çerçevesinin boyutu değişecektir. Yeniden boyutlandırma faktörü, OLE nesne çerçevesinin ve gömülü Excel çalışma kitabının boyutuna bağlı olarak değişir.

## **Yeniden Boyutlandırmanın Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğundan, ilk etkinleştirildiğinde orijinal boyutunu korumaya çalışır. Öte yandan, OLE nesne çerçevesinin kendi boyutu vardır. Microsoft'a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint gömme sürecinin bir parçası olarak doğru oranların korunmasını sağlamak için boyutu müzakere eder. Yeniden boyutlandırma, Excel pencere boyutu ile OLE nesne çerçevesinin boyut ve konumundaki farklara göre gerçekleşir.

## **Çalışan Çözüm**

Yeniden boyutlandırma etkisini önlemek için iki olası çözüm vardır.

- PowerPoint sunumunda OLE çerçevesini seçilen satır ve sütunların toplam yüksekliği ve genişliğine uyacak şekilde ölçeklendirin.
- OLE çerçevesi boyutunu sabit tutup seçilen satır ve sütunları çerçeveye sığacak şekilde ölçeklendirin.

### **OLE Çerçeve Boyutunu Ölçekle**

Bu yaklaşım, gömülü Excel çalışma sayfasındaki seçilen satır ve sütunların toplam yüksekliği ve genişliğine uyacak şekilde OLE çerçevesi boyutunu ayarlar.

Örnek, mevcut bir Excel çalışma kitabını yükler ve sıfır tabanlı indeksler kullanarak ilk çalışma sayfasının ilk 10 satırını ve 13 sütununu seçer. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) görüntülenen aralığı tanımlar. Önizleme 96 DPI'de işlenir ve piksel boyutları inç başına 72 puan kullanılarak puana dönüştürülür. [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) değiştirilmiş çalışma kitabını bu boyutlardaki bir çerçeve içinde gömer. Önizleme, kaydedilen sunumdaki "EMBEDDED OLE OBJECT" yer tutucusunu değiştirmek için [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) aracılığıyla atanır.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/image.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// We need to use the modified workbook.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Add the OLE image to the presentation resources.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

Önizleme yardımcı programı, aralığı seçmek için [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) kullanır ve kenar boşluklarını, üstbilgileri ve altbilgileri kaldırır. [ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/) etkinleştirildiğinde, [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) aralığı PNG görüntüsü olarak işler. Yardımcı program, işlenmiş görüntü verilerini sunumda kullanılmak üzere başlangıcına konumlandırılmış yeni bir bellek akışına kopyalar.

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

### **Hücre Aralığı Boyutunu Ölçekle**

Bu yaklaşım, seçilen satırların yüksekliklerini ve seçilen sütunların genişliklerini özel bir OLE çerçeve boyutuna uyacak şekilde ölçeklendirir.

Örnek, mevcut bir Excel çalışma kitabını yükler ve sıfır tabanlı indeksler kullanarak ilk çalışma sayfasının ilk 10 satırını ve 13 sütununu seçer. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) görüntülenen aralığı tanımlar ve aşağıdaki yardımcı program bu aralığı 400 puan genişliğinde ve 100 puan yüksekliğinde bir çerçeveye sığacak şekilde ölçeklendirir. Değiştirilmiş çalışma kitabı bir bayt dizisine kaydedildikten sonra, [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) belirtilen boyutta gömülür. 96 DPI'de işlenen bir önizleme, [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) aracılığıyla atanır, böylece kaydedilen sunum varsayılan yer tutucu yerine seçilen hücreleri gösterir.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Çalışma kitabı dosyası PowerPoint'te OLE nesnesi olarak kullanıldığında görüntülenen boyutu ayarlayın.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Hücre aralığını çerçeve boyutuna sığacak şekilde ölçeklendirin.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Değiştirilmiş çalışma kitabını kullanmamız gerekiyor.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// OLE görüntüsünü sunum kaynaklarına ekleyin.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// OLE nesne çerçevesini oluşturun.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

Ölçekleme yardımcı programı, seçilen aralık için ayrı genişlik ve yükseklik oranları hesaplar, sütunların göreceli genişliklerini ve satırların göreceli yüksekliklerini korur. Hesaplanan boyutları puandan inçe dönüştürür ve ardından [Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/) ve [Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/) ile uygular. Seçilen aralığın sıfır olmayan bir genişliği ve yüksekliği olmalıdır.

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">Hücre aralığının puan cinsinden beklenen genişliği.</param>
/// <param name="height">Hücre aralığının puan cinsinden beklenen yüksekliği.</param>
void ScaleCellRange(Aspose::Cells::Range cellRange, float width, float height)
{
    auto rangeWidth = cellRange.GetWidth();
    auto rangeHeight = cellRange.GetHeight();

    for (int i = 0; i < cellRange.GetColumnCount(); i++)
    {
        auto columnIndex = cellRange.GetFirstColumn() + i;
        auto columnWidth = cellRange.GetWorksheet().GetCells().GetColumnWidth(columnIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newColumnWidth = columnWidth * width / rangeWidth;
        auto widthInInches = newColumnWidth / 72;
        cellRange.GetWorksheet().GetCells().SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.GetRowCount(); i++)
    {
        auto rowIndex = cellRange.GetFirstRow() + i;
        auto rowHeight = cellRange.GetWorksheet().GetCells().GetRowHeight(rowIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newRowHeight = rowHeight * height / rangeHeight;
        auto heightInInches = newRowHeight / 72;
        cellRange.GetWorksheet().GetCells().SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

Bu önizleme yardımcı programı, yeniden boyutlandırılmış aralığı [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) kullanarak işler. [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) ile yazdırmayı bu aralığa sınırlamayı, kenar boşluklarını, üstbilgileri ve altbilgileri kaldırmayı ve başlangıcına konumlandırılmış bir PNG akışı döndürmeyi sağlar.

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

## **Sonuç**

{{% alert color="info" title="Note" %}}

Çalışma sayfası yeniden boyutlandırma sorununu çözmek için iki yaklaşım vardır. Gereksinimlerinize ve kullanım senaryonuza en uygun yaklaşımı seçin. Her iki yaklaşım da aynı şekilde çalışır; sunumlar bir şablondan ya da sıfırdan oluşturulmuş olsun. Ayrıca bu çözümlerde OLE nesne çerçevesinin boyutu için bir sınırlama yoktur.

{{% /alert %}}

## **FAQ**

**Neden gömülü bir Excel çalışma sayfası PowerPoint'te ilk etkinleştirildiğinde boyut değiştirir?**

Bu durum, Excel'in etkinleştirildiğinde orijinal pencere boyutunu korumaya çalışması, PowerPoint'teki OLE nesne çerçevesinin ise kendi boyutlarına sahip olması nedeniyle ortaya çıkar. PowerPoint ve Excel, en-boy oranını korumak için boyutu müzakere eder; bu da yeniden boyutlandırmaya neden olabilir.

**Bu yeniden boyutlandırma sorunu tamamen önlenebilir mi?**

Evet. OLE çerçevesini Excel hücre aralığı boyutuna uydurarak veya hücre aralığını istenen OLE çerçeve boyutuna uydurarak istenmeyen yeniden boyutlandırmayı önleyebilirsiniz.

**Hangi ölçekleme yöntemini kullanmalıyım, OLE çerçeve ölçekleme mi yoksa hücre aralığı ölçekleme mi?**

**OLE çerçeve ölçekleme**'yi seçin, eğer Excel satır ve sütun boyutlarını korumak istiyorsanız. **Hücre aralığı ölçekleme**'yi seçin, eğer sunumunuzda OLE çerçevesi için sabit bir boyut istiyorsanız.

**Bu çözümler sunumum bir şablona dayalıysa çalışır mı?**

Evet. Her iki çözüm de şablonlardan ve sıfırdan oluşturulan sunumlar için çalışır.

**Bu yöntemler kullanılırken OLE çerçevesinin boyutu için bir sınırlama var mı?**

Hayır. Ölçeği uygun şekilde ayarladığınız sürece OLE nesne çerçevesini istediğiniz herhangi bir boyuta getirebilirsiniz.

**PowerPoint'te "EMBEDDED OLE OBJECT" yer tutucu metninden kaçınmanın bir yolu var mı?**

Evet. Hedef Excel hücre aralığının bir anlık görüntüsünü alıp bunu OLE çerçevesinin yer tutucu resmi olarak ayarlayarak, varsayılan yer tutucu yerine özel bir önizleme görüntüsü gösterebilirsiniz.

## **İlgili Makaleler**

[Excel Grafiği Oluşturma ve Sunuma OLE Nesnesi Olarak Gömme](/slides/tr/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)