---
title: Çalışma Sayfası Yeniden Boyutlandırma İçin Çözüm
type: docs
weight: 40
url: /tr/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- önizleme görseli
- görsel yeniden boyutlandırma
- Excel
- çalışma sayfası
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Sunumlarda Excel çalışma sayfası OLE yeniden boyutlandırmasını düzeltin: nesne çerçevelerini tutarlı tutmanın iki yolu—çerçeveyi veya sayfayı ölçeklendirin—PPT ve PPTX formatları boyunca."
---
{{% alert color="info" %}} 

Excel çalışma sayfalarının Aspose bileşenleri aracılığıyla bir PowerPoint sunumuna OLE nesnesi olarak yerleştirildiğinde, ilk etkinleştirmeden sonra tanımlanamayan bir ölçeğe yeniden boyutlandırıldığı gözlemlenmiştir. Bu davranış, OLE nesnesinin etkinleştirme öncesi ve sonrası durumları arasında sunumda belirgin bir görsel fark yaratır. Bu sorunu ayrıntılı olarak inceledik ve bu makalede ele alınan bir çözüm sağladık.

{{% /alert %}} 

## **Arka Plan**

Makale [Manage OLE](/slides/tr/net/manage-ole/) içinde, Aspose.Slides for .NET kullanarak bir PowerPoint sunumuna OLE çerçevesi eklemenin nasıl yapılacağını açıkladık. [object preview issue](/slides/tr/net/object-preview-issue-when-adding-oleobjectframe/) sorununu ele almak için, seçilen çalışma sayfası alanının bir görüntüsünü OLE nesne çerçevesine atadık. Çıktı sunumunda, çalışma sayfası görüntüsünü gösteren OLE nesne çerçevesine çift tıkladığınızda Excel çalışma kitabı etkinleştirilir. Son kullanıcılar gerçek Excel çalışma kitabında istedikleri değişiklikleri yapabilir ve ardından etkinleştirilen Excel çalışma kitabının dışına tıklayarak slayta dönebilirler. Kullanıcı slayta döndüğünde OLE nesne çerçevesinin boyutu değişecektir. Yeniden boyutlandırma faktörü, OLE nesne çerçevesinin ve gömülü Excel çalışma kitabının boyutuna bağlı olarak değişir.

## **Yeniden Boyutlandırmanın Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğundan, ilk etkinleştirmede orijinal boyutunu korumaya çalışır. Öte yandan, OLE nesne çerçevesinin kendi boyutu vardır. Microsoft'a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint gömme sürecinin bir parçası olarak doğru oranları korumasını sağlamak için boyut üzerinde anlaşır. Yeniden boyutlandırma, Excel pencere boyutu ile OLE nesne çerçevesinin boyutu ve konumu arasındaki farklara dayanarak gerçekleşir.

## **Çözüm**

Yeniden boyutlandırma etkisini önlemek için iki olası çözüm vardır.

- OLE çerçevesinin yüksekliğini ve genişliğini, OLE çerçevesinde istenen satır ve sütun sayısına eşit olacak şekilde PowerPoint sunumunda ölçeklendirin.
- OLE çerçevesi boyutunu sabit tutun ve katılan satır ve sütunların boyutunu seçilen OLE çerçevesine sığacak şekilde ölçeklendirin.

### **OLE Çerçeve Boyutunu Ölçeklendirme**

Bu yaklaşımda, gömülü Excel çalışma kitabının OLE çerçeve boyutunu, Excel çalışma sayfasındaki katılan satır ve sütunların toplam boyutuna eşit olarak ayarlamayı öğreneceğiz.

Bir şablon Excel sayfamız olduğunu ve bunu bir OLE çerçevesi olarak sunuma eklemek istediğimizi varsayalım. Bu senaryoda, OLE nesne çerçevesinin boyutu, çalışma kitabındaki katılan satırların toplam yükseklikleri ve sütunların toplam genişlikleri temel alınarak önce hesaplanacaktır. Ardından, OLE çerçevesinin boyutunu bu hesaplanan değere ayarlayacağız. PowerPoint'teki OLE çerçevesi için kırmızı "EMBEDDED OLE OBJECT" mesajını önlemek amacıyla, çalışma kitabındaki istenen satır ve sütun bölümlerinin bir görüntüsünü yakalayıp OLE çerçeve resmi olarak ayarlayacağız.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Çalışma kitabı dosyası PowerPoint'te OLE nesnesi olarak kullanıldığında görüntülenen boyutu ayarlayın.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// OLE görüntüsünün genişliğini ve yüksekliğini puan cinsinden alın.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// Değiştirilmiş çalışma kitabını kullanmamız gerekiyor.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// OLE görüntüsünü sunum kaynaklarına ekleyin.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// OLE nesne çerçevesini oluşturun.
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

Bu yaklaşımda, katılan satırların yüksekliğini ve katılan sütunların genişliğini, özel bir OLE çerçeve boyutuna uyması için nasıl ölçeklendireceğimizi öğreneceğiz.

Bir şablon Excel sayfamız olduğunu ve bunu bir OLE çerçevesi olarak sunuma eklemek istediğimizi varsayalım. Bu senaryoda, OLE çerçevesinin boyutunu ayarlayacak ve OLE çerçeve alanına katılan satır ve sütunların boyutlarını ölçeklendireceğiz. Ardından, değişiklikleri uygulamak için çalışma kitabını bir akışa kaydedip OLE çerçevesine eklemek üzere bayt dizisine dönüştüreceğiz. PowerPoint'teki OLE çerçevesi için kırmızı "EMBEDDED OLE OBJECT" mesajını önlemek amacıyla, çalışma kitabındaki istenen satır ve sütun bölümlerinin bir görüntüsünü yakalayıp OLE çerçeve resmi olarak ayarlayacağız.

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Çalışma kitabı dosyası PowerPoint'te OLE nesnesi olarak kullanıldığında görüntülenen boyutu ayarlayın.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Hücre aralığını çerçeve boyutuna uyması için ölçeklendirin.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Değiştirilmiş çalışma kitabını kullanmamız gerekiyor.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// OLE görüntüsünü sunum kaynaklarına ekleyin.
var oleImage = presentation.Images.AddImage(imageStream);

// Create the OLE object frame.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
/// <param name="width">Hücre aralığının puan cinsinden beklenen genişliği.</param>
/// <param name="height">Hücre aralığının puan cinsinden beklenen yüksekliği.</param>
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

{{% alert color="info" %}}

Çalışma sayfası yeniden boyutlandırma sorununu çözmek için iki yaklaşım vardır. Uygun yaklaşımın seçimi, belirli gereksinimlere ve kullanım senaryosuna bağlıdır. Her iki yaklaşım da aynı şekilde çalışır; sunumlar bir şablondan ya da sıfırdan oluşturulmuş olsun fark etmez. Ayrıca, bu çözümde OLE nesne çerçevesinin boyutu için bir limit yoktur.

{{% /alert %}}

## **SSS**

### Yerleştirilen bir Excel çalışma sayfası PowerPoint'te ilk etkinleştirildiğinde neden boyut değiştirir?
Bu, Excel'in etkinleştirildiğinde orijinal pencere boyutunu korumaya çalışması, PowerPoint'teki OLE nesne çerçevesinin ise kendi boyutlarına sahip olması nedeniyle olur. PowerPoint ve Excel, en‑boy oranını korumak için boyut üzerinde anlaşma yapar; bu da yeniden boyutlandırmaya yol açabilir.

### Bu yeniden boyutlandırma sorununu tamamen önlemek mümkün mü?
Evet. OLE çerçevesini Excel hücre aralığı boyutuna uyduracak şekilde ölçeklendirerek veya hücre aralığını istenen OLE çerçeve boyutuna uyduracak şekilde ölçeklendirerek istenmeyen yeniden boyutlandırmayı önleyebilirsiniz.

### Hangi ölçekleme yöntemini kullanmalıyım, OLE çerçeve ölçeklendirme mi yoksa hücre aralığı ölçeklendirme mi?
**OLE çerçeve ölçeklendirmesini** seçin eğer orijinal Excel satır ve sütun boyutlarını korumak istiyorsanız. **Hücre aralığı ölçeklendirmesini** seçin eğer sunumunuzda OLE çerçevesi için sabit bir boyut isterseniz.

### Sunumum bir şablona dayalıysa bu çözümler çalışır mı?
Evet. Her iki çözüm de şablondan oluşturulan ve sıfırdan oluşturulan sunumlarda çalışır.

### Bu yöntemleri kullanırken OLE çerçevesinin boyutu için bir limit var mı?
Hayır. Ölçeği uygun şekilde ayarladığınız sürece OLE nesne çerçevesini istediğiniz boyutta yapabilirsiniz.

### PowerPoint'te "EMBEDDED OLE OBJECT" yer tutucu metninden kaçınmanın bir yolu var mı?
Evet. Hedef Excel hücre aralığının bir fotoğrafını alıp bunu OLE çerçevesinin yer tutucu resmi olarak ayarlayarak varsayılan yer tutucu yerine özel bir ön izleme görüntüsü gösterebilirsiniz.

## **İlgili Makaleler**

[Excel Grafiği Oluşturma ve Sunumda OLE Nesnesi Olarak Yerleştirme](/slides/tr/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint Eklentisi Kullanarak OLE Nesnelerini Otomatik Güncelleme](/slides/tr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)