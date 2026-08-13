---
title: Çalışma Sayfası Yeniden Boyutlandırma için Çalışan Çözüm
type: docs
weight: 130
url: /tr/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- önizleme resmi
- görsel yeniden boyutlandırma
- Excel
- çalışma sayfası
- PowerPoint
- sunum
- C++
- Aspose.Slides for C++
description: "C++ kullanarak PowerPoint sunumlarındaki çalışma sayfası yeniden boyutlandırma için çalışan çözüm"
---
{{% alert color="info" %}}

Aspose bileşenleri aracılığıyla PowerPoint sunumuna OLE nesnesi olarak gömülen Excel çalışma sayfalarının, ilk etkinleştirmenin ardından tanımlanamayan bir ölçeğe yeniden boyutlandırıldığı gözlemlenmiştir. Bu davranış, OLE nesnesinin etkinleştirilmeden önceki ve sonraki durumları arasında sunumda belirgin bir görsel fark yaratmaktadır. Bu sorunu ayrıntılı olarak inceledik ve bu makalede ele alınan bir çözüm sunduk.

{{% /alert %}}

## **Arka Plan**

Makale [Manage OLE](/slides/tr/cpp/manage-ole/) içinde, Aspose.Slides for C++ kullanarak bir PowerPoint sunumuna OLE çerçevesi eklemenin nasıl yapılacağını açıkladık. [object preview issue](/slides/tr/cpp/object-preview-issue-when-adding-oleobjectframe/) sorununu ele almak için, seçilen çalışma sayfası alanının bir resmini OLE nesne çerçevesine atadık. Çıktı sunumunda, çalışma sayfası resmini gösteren OLE nesne çerçevesine çift tıkladığınızda Excel çalışma kitabı etkinleştirilir. Son kullanıcılar gerçek Excel çalışma kitabında istedikleri değişiklikleri yapabilir ve etkinleştirilen Excel çalışma kitabının dışına tıklayarak slayta geri dönebilir. Kullanıcı slayta döndüğünde OLE nesne çerçevesinin boyutu değişecektir. Yeniden boyutlandırma faktörü, OLE nesne çerçevesinin ve gömülü Excel çalışma kitabının boyutuna bağlı olarak değişecektir.

## **Yeniden Boyutlandırmanın Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğu için, ilk etkinleştirildiğinde orijinal boyutunu korumaya çalışır. Öte yandan OLE nesne çerçevesinin kendi boyutu vardır. Microsoft'a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint gömme sürecinin bir parçası olarak doğru oranları korumasını sağlamak için boyutu müzakere eder. Yeniden boyutlandırma, Excel pencere boyutu ile OLE nesne çerçevesinin boyut ve konumu arasındaki farklara dayanarak gerçekleşir.

## **Çözüm**

Yeniden boyutlandırma etkisini önlemek için iki olası çözüm vardır.

- OLE çerçeve boyutunu PowerPoint sunumunda, OLE çerçevesinde istenen satır ve sütun sayısının yüksekliği ve genişliğine uygun olarak ölçeklendirin.
- OLE çerçeve boyutunu sabit tutun ve katılan satır ve sütunların boyutunu seçilen OLE çerçeve boyutuna sığacak şekilde ölçeklendirin.

### **OLE Çerçeve Boyutunu Ölçeklendirme**

Bu yöntemde, gömülü Excel çalışma kitabının OLE çerçeve boyutunu, Excel çalışma sayfasındaki katılan satır ve sütunların toplam boyutuna eşit şekilde ayarlamayı öğreneceksiniz.

Diyelim ki bir şablon Excel sayfasına sahibiz ve bunu bir OLE çerçevesi olarak sunuma eklemek istiyoruz. Bu senaryoda, OLE nesne çerçevesinin boyutu önce, çalışma kitabındaki katılan satırların toplam yüksekliği ve sütunların toplam genişliğine göre hesaplanacaktır. Daha sonra OLE çerçevesinin boyutunu bu hesaplanan değere ayarlayacağız. PowerPoint'te OLE çerçevesi için kırmızı "EMBEDDED OLE OBJECT" mesajını önlemek amacıyla, çalışma kitabındaki istenen satır ve sütun bölümlerinin bir görüntüsünü yakalayacak ve bunu OLE çerçeve resmi olarak ayarlayacağız.

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

// Çalışma kitabı dosyası PowerPoint'te OLE nesnesi olarak kullanıldığında görüntülenen boyutu ayarlayın.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// OLE görüntüsünün genişliğini ve yüksekliğini punto cinsinden alın.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// Değiştirilmiş çalışma kitabını kullanmamız gerekiyor.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// OLE görüntüsünü sunum kaynaklarına ekleyin.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// OLE nesne çerçevesini oluşturun.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

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

### **Hücre Aralığı Boyutunu Ölçeklendirme**

Bu yöntemde, katılan satırların yüksekliğini ve katılan sütunların genişliğini, özel bir OLE çerçeve boyutuna uyacak şekilde ölçeklendirmeyi öğreneceksiniz.

Diyelim ki bir şablon Excel sayfasına sahibiz ve bunu bir OLE çerçevesi olarak sunuma eklemek istiyoruz. Bu senaryoda, OLE çerçevesinin boyutunu ayarlayacak ve OLE çerçeve alanına katılan satır ve sütunların boyutunu ölçeklendireceğiz. Ardından değişiklikleri uygulamak için çalışma kitabını bir akışa kaydedip OLE çerçevesine eklemek üzere bir byte dizisine dönüştüreceğiz. PowerPoint'te OLE çerçevesi için kırmızı "EMBEDDED OLE OBJECT" mesajını önlemek amacıyla, çalışma kitabındaki istenen satır ve sütun bölümlerinin bir görüntüsünü yakalayacak ve bunu OLE çerçeve resmi olarak ayarlayacağız.

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

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">Hücre aralığının beklenen genişliği (nokta cinsinden).</param>
/// <param name="height">Hücre aralığının beklenen yüksekliği (nokta cinsinden).</param>
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

{{% alert color="info" %}}

Çalışma sayfası yeniden boyutlandırma sorununu çözmek için iki yaklaşım vardır. Uygun yaklaşımın seçimi, belirli gereksinimler ve kullanım durumuna bağlıdır. Her iki yaklaşım da, sunumların bir şablondan veya sıfırdan oluşturulmasına bakılmaksızın aynı şekilde çalışır. Ayrıca, bu çözümde OLE nesne çerçevesi boyutu için bir sınırlama yoktur.

{{% /alert %}}

## **SSS**

### PowerPoint'te bir gömülü Excel çalışma sayfası ilk etkinleştirildiğinde neden boyutu değişir?

Bu, Excel'in etkinleştirildiğinde orijinal pencere boyutunu korumaya çalışması, PowerPoint'teki OLE nesne çerçevesinin ise kendi boyutlarına sahip olması nedeniyle meydana gelir. PowerPoint ve Excel, en‑boy oranını korumak için boyutu müzakere eder ve bu da yeniden boyutlandırmaya yol açabilir.

### Bu yeniden boyutlandırma sorunu tamamen önlenebilir mi?

Evet. OLE çerçevesini Excel hücre aralığı boyutuna sığacak şekilde ölçeklendirerek veya hücre aralığını istenen OLE çerçeve boyutuna uyacak şekilde ölçeklendirerek istenmeyen yeniden boyutlandırmayı önleyebilirsiniz.

### Hangi ölçeklendirme yöntemini kullanmalıyım, OLE çerçeve ölçeklendirmesi mi yoksa hücre aralığı ölçeklendirmesi mi?

Orijinal Excel satır ve sütun boyutlarını korumak istiyorsanız **OLE çerçeve ölçeklendirmesini** seçin. Sunumunuzda OLE çerçevesi için sabit bir boyut istiyorsanız **hücre aralığı ölçeklendirmesini** seçin.

### Sunumum bir şablona dayanıyorsa bu çözümler çalışır mı?

Evet. Her iki çözüm de şablonlardan ve sıfırdan oluşturulan sunumlarda çalışır.

### Bu yöntemleri kullanırken OLE çerçevesi boyutu için bir sınırlama var mı?

Hayır. Ölçeği uygun şekilde ayarladığınız sürece OLE nesne çerçevesini istediğiniz herhangi bir boyutta yapabilirsiniz.

### PowerPoint'te "EMBEDDED OLE OBJECT" yer tutucu metninden kaçınmanın bir yolu var mı?

Evet. Hedef Excel hücre aralığının bir anlık görüntüsünü alıp bunu OLE çerçevesinin yer tutucu resmi olarak ayarlayarak varsayılan yer tutucu yerine özel bir önizleme resmi gösterebilirsiniz.

## **İlgili Makaleler**

[Bir Excel Grafiği Oluşturma ve Sunumda OLE Nesnesi Olarak Gömme](/slides/tr/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)