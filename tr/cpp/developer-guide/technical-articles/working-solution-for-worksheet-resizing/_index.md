---
title: Çalışma Sayfası Yeniden Boyutlandırma İçin Çözüm
type: docs
weight: 130
url: /tr/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- önizleme resmi
- resim yeniden boyutlandırma
- Excel
- çalışma sayfası
- PowerPoint
- sunum
- C++
- Aspose.Slides for C++
description: "C++ kullanarak PowerPoint sunumlarında çalışma sayfası yeniden boyutlandırma için çalışan çözüm"
---
{{% alert color="primary" %}}

Excel çalışma sayfalarının Aspose bileşenleri aracılığıyla bir PowerPoint sunumuna OLE nesnesi olarak yerleştirildiğinde, ilk etkinleştirmenin ardından tanımlanamayan bir ölçeğe yeniden boyutlandırıldığı gözlemlenmiştir. Bu davranış, OLE nesnesinin etkinleştirilmeden önceki ve sonraki durumları arasında belirgin bir görsel fark yaratır. Bu sorunu ayrıntılı olarak inceledik ve bu makalede bir çözüm sunduk.

{{% /alert %}}

## **Arka Plan**

[OLE'yi Yönet](/slides/tr/cpp/manage-ole/) makalesinde, Aspose.Slides for C++ kullanarak bir PowerPoint sunumuna OLE çerçevesi eklemenin nasıl yapılacağını açıklamıştık. [nesne önizleme sorunu](/slides/tr/cpp/object-preview-issue-when-adding-oleobjectframe/) ile başa çıkmak için, seçilen çalışma sayfası alanının bir görüntüsünü OLE nesne çerçevesine atadık. Çıktı sunumunda, çalışma sayfası görüntüsünü gösteren OLE nesne çerçevesine çift‑tıkladığınızda Excel çalışma kitabı etkinleşir. Son kullanıcılar gerçek Excel çalışma kitabında istedikleri değişiklikleri yapabilir ve ardından etkinleştirilen Excel çalışma kitabının dışına tıklayarak slayta geri dönebilir. Kullanıcı slayta geri döndüğünde OLE nesne çerçevesinin boyutu değişecektir. Yeniden boyutlandırma faktörü, OLE nesne çerçevesinin ve gömülü Excel çalışma kitabının boyutuna bağlı olarak değişir. 

## **Yeniden Boyutlandırmanın Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğundan, ilk etkinleştirme sırasında orijinal boyutunu korumaya çalışır. Öte yandan OLE nesne çerçevesinin kendi boyutu vardır. Microsoft'a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint gömme sürecinin bir parçası olarak doğru oranları korumasını sağlamak için boyutu müzakere eder. Yeniden boyutlandırma, Excel penceresi ile OLE nesne çerçevesinin boyut ve konum farklarından kaynaklanır.

## **Çözüm**

Yeniden boyutlandırma etkisini önlemenin iki olası yolu vardır.

- OLE çerçevesinin yüksekliğini ve genişliğini, OLE çerçevesindeki istenen satır ve sütun sayısına göre ayarlamak.
- OLE çerçevesinin boyutunu sabit tutup, katılan satır ve sütunların boyutunu seçili OLE çerçevesine sığacak şekilde ölçeklemek.

### **OLE Çerçevesi Boyutunu Ölçekleme**

Bu yaklaşımda, gömülü Excel çalışma kitabının OLE çerçevesi boyutunu, Excel çalışma sayfasındaki katılan satır ve sütunların toplam boyutuna eşit olacak şekilde ayarlamayı öğreneceğiz.

Örnek olarak bir şablon Excel sayfasına sahip olduğumuzu ve bunu bir OLE çerçevesi olarak sunuma eklemek istediğimizi varsayalım. Bu senaryoda, OLE nesne çerçevesinin boyutu önce çalışma kitabındaki katılan satırların toplam yüksekliği ve sütunların toplam genişliği temel alınarak hesaplanır. Daha sonra OLE çerçevesinin boyutunu bu hesaplanan değere ayarlarız. PowerPoint'te OLE çerçevesi için kırmızı “EMBEDDED OLE OBJECT” mesajını önlemek amacıyla, çalışma kitabındaki istenen satır ve sütun bölümlerinin bir görüntüsünü yakalar ve bunu OLE çerçevesi görüntüsü olarak ayarlarız.

```cpp
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

// OLE görüntüsünün genişlik ve yüksekliğini nokta cinsinden alın.
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

### **Hücre Aralığı Boyutunu Ölçekleme**

Bu yaklaşımda, katılan satırların yüksekliğini ve katılan sütunların genişliğini, özel bir OLE çerçevesi boyutuna uyduracak şekilde ölçeklemeyi öğreneceğiz.

Yine bir şablon Excel sayfasına sahip olduğumuzu ve bunu bir OLE çerçevesi olarak sunuma eklemek istediğimizi varsayalım. Bu senaryoda, OLE çerçevesinin boyutunu belirler ve OLE çerçevesi alanına katılan satır ve sütunların boyutunu ölçekleriz. Ardından değişiklikleri uygulamak için çalışma kitabını bir akıma kaydeder ve OLE çerçevesine eklemek üzere bayt dizisine dönüştürürüz. PowerPoint'te OLE çerçevesi için kırmızı “EMBEDDED OLE OBJECT” mesajını önlemek amacıyla, çalışma kitabındaki istenen satır ve sütun bölümlerinin bir görüntüsünü yakalar ve bunu OLE çerçevesi görüntüsü olarak ayarlarız.

```cpp
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

// Hücre aralığını çerçeve boyutuna uyduracak şekilde ölçekleyin.
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

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
/// <param name="width">Hücre aralığının nokta cinsinden beklenen genişliği.</param>
/// <param name="height">Hücre aralığının nokta cinsinden beklenen yüksekliği.</param>
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

{{% alert color="primary" %}}

Çalışma sayfası yeniden boyutlandırma sorununu çözmenin iki yolu vardır. Uygun yöntemin seçimi, belirli gereksinimlere ve kullanım senaryosuna bağlıdır. Her iki yöntem de sunumlar şablondan ya da sıfırdan oluşturulmuş olsun aynı şekilde çalışır. Ayrıca bu çözümde OLE nesne çerçevesinin boyutu için bir sınırlama bulunmamaktadır.

{{% /alert %}}

## **SSS**

**Gömülü bir Excel çalışma sayfası PowerPoint’te ilk etkinleştirildiğinde neden boyut değiştirir?**

Excel, etkinleştirildiğinde orijinal pencere boyutunu korumaya çalışır, ancak PowerPoint’teki OLE nesne çerçevesinin kendi boyutları vardır. PowerPoint ve Excel, en‑boy oranını korumak için boyutu müzakere eder; bu da yeniden boyutlandırmaya yol açar.

**Bu yeniden boyutlandırma sorunu tamamen önlenebilir mi?**

Evet. OLE çerçevesini Excel hücre aralığı boyutuna uyacak şekilde ölçekleyerek ya da hücre aralığını istediğiniz OLE çerçevesi boyutuna uyacak şekilde ölçekleyerek istenmeyen yeniden boyutlandırmayı önleyebilirsiniz.

**Hangi ölçekleme yöntemi kullanılmalı, OLE çerçevesi ölçekleme mi yoksa hücre aralığı ölçekleme mi?**

Orijinal Excel satır ve sütun boyutlarını korumak istiyorsanız **OLE çerçevesi ölçekleme**’yi seçin. Sunumunuzda OLE çerçevesi için sabit bir boyut istiyorsanız **hücre aralığı ölçekleme**’yi seçin.

**Bu çözümler, sunum şablonuna dayanıyorsa da çalışır mı?**

Evet. Her iki çözüm de şablondan veya sıfırdan oluşturulan sunumlar için çalışır.

**Bu yöntemlerde OLE çerçevesi boyutu için bir sınırlama var mı?**

Hayır. Ölçeği uygun şekilde ayarladığınız sürece OLE nesne çerçevesini istediğiniz herhangi bir boyutta yapabilirsiniz.

**PowerPoint’te “EMBEDDED OLE OBJECT” yer tutucu metninden nasıl kaçınılır?**

Evet. Hedef Excel hücre aralığının bir anlık görüntüsünü alıp bunu OLE çerçevesinin yer tutucu resmi olarak ayarlayarak varsayılan yer tutucu yerine özel bir ön izleme resmi gösterebilirsiniz.

## **İlgili Makaleler**

[Excel Grafiği Oluşturma ve PowerPoint’te OLE Nesnesi Olarak Gömme](/slides/tr/cpp/create-excel-chart-and-embedding-it-in-presentation-as-ole-object/)