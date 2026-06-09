---
title: Çalışma Sayfası Yeniden Boyutlandırması İçin Çalışan Çözüm
type: docs
weight: 40
url: /tr/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- ön izleme resmi
- görsel yeniden boyutlandırma
- Excel
- çalışma sayfası
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Sunumlardaki Excel çalışma sayfası OLE yeniden boyutlandırmasını düzeltin: nesne çerçevelerini tutarlı tutmanın iki yolu—çerçeveyi ya da sayfayı ölçeklendirin—PPT ve PPTX formatları boyunca."
---
{{% alert color="primary" %}} 

Aspose bileşenleri aracılığıyla bir PowerPoint sunumuna OLE nesnesi olarak gömülen Excel çalışma sayfalarının, ilk etkinleştirmenin ardından tanımlanamayan bir ölçeğe yeniden boyutlandırıldığını gözlemledik. Bu davranış, OLE nesnesinin etkinleştirme öncesi ve sonrası durumları arasında sunumda belirgin bir görsel fark yaratmaktadır. Bu sorunu ayrıntılı olarak inceledik ve bu makalede ele alınan bir çözüm sunduk.

{{% /alert %}} 

## **Arka Plan**

Makale [OLE Yönetimi](/slides/tr/net/manage-ole/) adresinde, Aspose.Slides for .NET kullanarak bir PowerPoint sunumuna OLE çerçevesi eklemenin nasıl yapılacağını açıkladık. [nesne önizleme sorunu](/slides/tr/net/object-preview-issue-when-adding-oleobjectframe/) sorununu gidermek için, seçilen çalışma sayfası alanının bir görüntüsünü OLE nesne çerçevesine atadık. Çıktı sunumunda, çalışma sayfası görüntüsünü gösteren OLE nesne çerçevesine çift tıkladığınızda Excel çalışma kitabı etkinleştirilir. Son kullanıcılar gerçek Excel çalışma kitabında istedikleri değişiklikleri yaptıktan sonra etkinleştirilmiş Excel çalışma kitabının dışına tıklayarak slayta geri dönebilir. Kullanıcı slayta döndüğünde OLE nesne çerçevesinin boyutu değişir. Yeniden boyutlandırma faktörü, OLE nesne çerçevesinin ve gömülü Excel çalışma kitabının boyutuna bağlı olarak değişir. 

## **Yeniden Boyutlandırmanın Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğundan, ilk etkinleştirmede orijinal boyutunu korumaya çalışır. Öte yandan OLE nesne çerçevesinin kendi boyutu vardır. Microsoft’a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint gömme işlemi sırasında doğru oranları korumak için boyutu müzakere eder. Yeniden boyutlandırma, Excel pencere boyutu ile OLE nesne çerçevesinin boyutu ve konumu arasındaki farklara dayanarak gerçekleşir.

## **Çözüm**

Yeniden boyutlandırma etkisini önlemek için iki olası çözüm vardır.

- PowerPoint sunumundaki OLE çerçeve boyutunu, OLE çerçevesindeki istenen satır ve sütun sayısının yüksekliği ve genişliğiyle eşleşecek şekilde ölçeklendirin.  
- OLE çerçeve boyutunu sabit tutun ve katılan satır ve sütun boyutlarını seçili OLE çerçeve boyutuna sığacak şekilde ölçeklendirin.  

### **OLE Çerçevesi Boyutunu Ölçeklendirme**

Bu yöntemde, gömülü Excel çalışma kitabının OLE çerçevesi boyutunu, çalışma sayfasındaki katılan satır ve sütunların toplam boyutuna eşitleştirmeyi öğreneceğiz.

Şablon bir Excel sayfamız olduğunu ve bunu bir OLE çerçevesi olarak sunuma eklemek istediğimizi varsayalım. Bu senaryoda, OLE nesne çerçevesinin boyutu önce çalışma kitabındaki katılan satırların yüksekliği ve sütunların genişliğinin toplamına göre hesaplanacaktır. Ardından, OLE çerçevesinin boyutunu bu hesaplanan değere ayarlayacağız. PowerPoint’te OLE çerçevesi için kırmızı “EMBEDDED OLE OBJECT” mesajının oluşmasını önlemek amacıyla, çalışma kitabındaki istenen satır ve sütun bölümlerinin bir görüntüsünü yakalayıp OLE çerçevesi resmi olarak ayarlayacağız.

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Çalışma kitabı dosyası PowerPoint'te OLE nesnesi olarak kullanıldığında gösterilen boyutu ayarla.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// OLE görüntüsünün genişliğini ve yüksekliğini nokta cinsinden al.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// Değiştirilmiş çalışma kitabını kullanmamız gerekiyor.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// OLE görüntüsünü sunum kaynaklarına ekle.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// OLE nesne çerçevesini oluştur.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
static MemoryStream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

### **Hücre Aralığı Boyutunu Ölçeklendirme**

Bu yöntemde, katılan satırların yüksekliğini ve katılan sütunların genişliğini, özel bir OLE çerçevesi boyutuna uyduracak şekilde ölçeklendirmeyi öğreneceğiz.

Şablon bir Excel sayfamız olduğunu ve bunu bir OLE çerçevesi olarak sunuma eklemek istediğimizi varsayalım. Bu senaryoda, OLE çerçevesi boyutunu ayarlayacak ve OLE çerçevesi alanına katılan satır ve sütunların boyutunu ölçeklendireceğiz. Ardından, değişiklikleri uygulamak için çalışma kitabını bir akışa kaydedip OLE çerçevesine eklemek üzere bayt dizisine dönüştüreceğiz. PowerPoint’te OLE çerçevesi için kırmızı “EMBEDDED OLE OBJECT” mesajının oluşmasını önlemek amacıyla, çalışma kitabındaki istenen satır ve sütun bölümlerinin bir görüntüsünü yakalayıp OLE çerçevesi resmi olarak ayarlayacağız.

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Çalışma kitabı dosyası PowerPoint'te OLE nesnesi olarak kullanıldığında gösterilen boyutu ayarla.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Hücre aralığını çerçeve boyutuna sığacak şekilde ölçeklendir.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Değiştirilmiş çalışma kitabını kullanmamız gerekiyor.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// OLE görüntüsünü sunum kaynaklarına ekle.
var oleImage = presentation.Images.AddImage(imageStream);

// OLE nesne çerçevesini oluştur.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
/// <param name="width">Hücre aralığının nokta cinsinden beklenen genişliği.</param>
/// <param name="height">Hücre aralığının nokta cinsinden beklenen yüksekliği.</param>
static void ScaleCellRange(Aspose.Cells.Range cellRange, float width, float height)
{
    var rangeWidth = cellRange.Width;
    var rangeHeight = cellRange.Height;

    for (int i = 0; i < cellRange.ColumnCount; i++)
    {
        var columnIndex = cellRange.FirstColumn + i;
        var columnWidth = cellRange.Worksheet.Cells.GetColumnWidth(columnIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newColumnWidth = columnWidth * width / rangeWidth;
        var widthInInches = newColumnWidth / 72;
        cellRange.Worksheet.Cells.SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.RowCount; i++)
    {
        var rowIndex = cellRange.FirstRow + i;
        var rowHeight = cellRange.Worksheet.Cells.GetRowHeight(rowIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newRowHeight = rowHeight * height / rangeHeight;
        var heightInInches = newRowHeight / 72;
        cellRange.Worksheet.Cells.SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **Sonuç**

{{% alert color="primary" %}}

Çalışma sayfası yeniden boyutlandırma sorununu gidermek için iki yaklaşım vardır. Uygun yaklaşımın seçimi, belirli gereksinimler ve kullanım senaryosuna bağlıdır. Her iki yaklaşım da, sunumlar bir şablondan ya da sıfırdan oluşturulmuş olsun aynı şekilde çalışır. Ayrıca bu çözümde OLE nesne çerçevesinin boyutu için bir sınırlama yoktur.

{{% /alert %}}

## **SSS**

**Bir gömülü Excel çalışma sayfası PowerPoint’te ilk etkinleştirildiğinde neden boyutu değişir?**  
Bu, Excel’in etkinleştirildiğinde orijinal pencere boyutunu korumaya çalışması, PowerPoint’teki OLE nesne çerçevesinin ise kendi boyutlarına sahip olması nedeniyle olur. PowerPoint ve Excel, en-boy oranını korumak için boyutu müzakere eder ve bu da yeniden boyutlandırmaya yol açabilir.

**Bu yeniden boyutlandırma sorunu tamamen önlenebilir mi?**  
Evet. OLE çerçevesini Excel hücre aralığı boyutuna sığacak şekilde ölçeklendirerek ya da hücre aralığını istenen OLE çerçeve boyutuna uydurarak istenmeyen yeniden boyutlandırmayı önleyebilirsiniz.

**Hangi ölçeklendirme yöntemini kullanmalıyım, OLE çerçeve ölçeklendirme mi yoksa hücre aralığı ölçeklendirme mi?**  
Orijinal Excel satır ve sütun boyutlarını korumak istiyorsanız **OLE çerçeve ölçeklendirme** seçin. Sunumunuzda OLE çerçevesi için sabit bir boyut istiyorsanız **hücre aralığı ölçeklendirme** seçin.

**Bu çözümler, sunumum bir şablona dayanıyorsa da çalışır mı?**  
Evet. Her iki çözüm de şablondan oluşturulan ya da sıfırdan oluşturulan sunumlarda çalışır.

**Bu yöntemleri kullanırken OLE çerçevesinin boyutu için bir sınırlama var mı?**  
Hayır. Ölçeği uygun şekilde ayarladığınız sürece OLE nesne çerçevesini istediğiniz büyüklükte yapabilirsiniz.

**PowerPoint’te “EMBEDDED OLE OBJECT” yer tutucu metninden nasıl kaçınılır?**  
Evet. Hedef Excel hücre aralığının bir fotoğrafını alıp bunu OLE çerçevesinin yer tutucu resmi olarak ayarladığınızda, varsayılan yer tutucu yerine özel bir ön izleme resmi görüntülenir.

## **İlgili Makaleler**

[Excel Grafik Oluşturma ve Sunuma OLE Nesnesi Olarak Gömme](/slides/tr/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint Eklentisi Kullanarak OLE Nesnelerini Otomatik Güncelleme](/slides/tr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)