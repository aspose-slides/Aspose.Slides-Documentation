---
title: Çalışma Sayfası Yeniden Boyutlandırma için Çözüm
type: docs
weight: 40
url: /tr/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- önizleme resmi
- görsel yeniden boyutlandırma
- Excel
- çalışma sayfası
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Sunumlarda Excel çalışma sayfası OLE yeniden boyutlandırmasını düzeltin: nesne çerçevelerini tutarlı tutmanın iki yolu—çerçeveyi veya sayfayı ölçeklendirin—PPT ve PPTX formatlarında."
---
{{% alert color="info" title="Note" %}}

Excel çalışma sayfalarının Aspose bileşenleri kullanılarak bir PowerPoint sunumunda OLE nesneleri olarak gömülmesi, ilk etkinleştirilmelerinden sonra beklenmedik şekilde yeniden boyutlandırılmasına neden olabilir. Bu davranış, OLE nesnesinin etkinleştirme öncesi ve sonrası arasında fark edilir bir görsel fark oluşturur. Bu makale sorunu açıklar ve iki çözüm yolunu tanımlar.

{{% /alert %}} 

## **Arka Plan**

Makale [OLE'yi Yönet](/slides/tr/net/manage-ole/) içinde, Aspose.Slides for .NET kullanarak bir PowerPoint sunumuna OLE çerçevesi eklemenin nasıl yapılacağını açıkladık. [nesne önizleme sorunu](/slides/tr/net/object-preview-issue-when-adding-oleobjectframe/) ele almak için, seçilen çalışma sayfası alanının bir görüntüsünü OLE nesne çerçevesine atadık. Çıktı sunumunda, çalışma sayfası görüntüsünü gösteren OLE nesne çerçevesine çift tıkladığınızda Excel çalışma kitabı etkinleştirilir. Son kullanıcılar gerçek Excel çalışma kitabında istedikleri değişiklikleri yapabilir ve ardından etkinleştirilen Excel çalışma kitabının dışına tıklayarak slayta geri dönebilirler. Kullanıcı slayta döndüğünde OLE nesne çerçevesinin boyutu değişecektir. Yeniden boyutlandırma faktörü, OLE nesne çerçevesinin ve gömülü Excel çalışma kitabının boyutuna bağlı olarak değişecektir.

## **Yeniden Boyutlandırmanın Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğu için, ilk etkinleştirilmede orijinal boyutunu korumaya çalışır. Öte yandan, OLE nesne çerçevesinin kendi boyutu vardır. Microsoft'a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint, gömme sürecinin bir parçası olarak doğru oranların korunmasını sağlamak için boyutu müzakere eder. Yeniden boyutlandırma, Excel pencere boyutu ile OLE nesne çerçevesinin boyut ve konumu arasındaki farklara dayanarak gerçekleşir.

## **Çalışan Çözüm**

Yeniden boyutlandırma etkisini önlemek için iki olası çözüm vardır.

- PowerPoint sunumundaki OLE çerçevesini, seçilen satır ve sütunların toplam yüksekliği ve genişliğiyle eşleşecek şekilde ölçeklendirin.
- OLE çerçevesi boyutunu sabit tutun ve seçilen satır ve sütunları içine sığacak şekilde ölçeklendirin.

### **OLE Çerçeve Boyutunu Ölçeklendirme**

Bu yaklaşım, gömülü Excel çalışma sayfasındaki seçilen satır ve sütunların toplam yüksekliği ve genişliğiyle eşleşecek şekilde OLE çerçeve boyutunu ayarlar.

Örnek, mevcut bir Excel çalışma kitabını yükler ve sıfır tabanlı dizinler kullanarak ilk çalışma sayfasının ilk 10 satırını ve 13 sütununu seçer. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) görüntülenen aralığı tanımlar. Ön izleme 96 DPI'de oluşturulur ve piksel boyutları inç başına 72 puan kullanılarak puana dönüştürülür. [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) değiştirilmiş çalışma kitabını bu boyutlarda bir çerçeveye gömer. Ön izleme, kaydedilen sunumdaki "EMBEDDED OLE OBJECT" yer tutucusunu değiştirmek için [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) aracılığıyla atanır.

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

// Çalışma kitabı dosyası PowerPoint'te OLE nesnesi olarak kullanıldığında görüntülenen boyutu ayarla.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// OLE görüntüsünün genişliğini ve yüksekliğini puan cinsinden al.
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

Ön izleme yardımcı aracı, seçilen aralığa [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) ayarlar ve kenar boşluklarını, üstbilgileri ve altbilgileri kaldırır. [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/) etkinleştirildiğinde, [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) aralığı PNG görüntüsü olarak oluşturur. Yardımcı, sunumda kullanılmak üzere döndürmeden önce görüntü akışının konumunu başa alır.

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

Bu yaklaşım, seçilen satırların yüksekliğini ve seçilen sütunların genişliğini özelleştirilmiş bir OLE çerçeve boyutuna eşit olacak şekilde ölçeklendirir.

Örnek, mevcut bir Excel çalışma kitabını yükler ve sıfır tabanlı dizinler kullanarak ilk çalışma sayfasının ilk 10 satırını ve 13 sütununu seçer. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) görüntülenen aralığı tanımlar ve aşağıdaki yardımcı, bu aralığı 400 puan genişliğinde ve 100 puan yüksekliğinde bir çerçeveye sığacak şekilde ölçeklendirir. Değiştirilmiş çalışma kitabı bir akıma kaydedildikten sonra, [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) belirtilen boyutta gömülür. 96 DPI'de oluşturulan bir ön izleme, [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) aracılığıyla atanır; böylece kaydedilen sunum, varsayılan yer tutucu yerine seçilen hücreleri gösterir.

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

// Çalışma kitabı dosyası PowerPoint'te OLE nesnesi olarak kullanıldığında görüntülenen boyutu ayarla.
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

Ölçekleme yardımcısı, seçilen aralık için ayrı genişlik ve yükseklik oranları hesaplar, sütunların göreceli genişliklerini ve satırların göreceli yüksekliklerini korur. Hesaplanan boyutları, [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) ve [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/) ile uygulamadan önce puandan inçe dönüştürür. Seçilen aralığın sıfırdan farklı bir genişliği ve yüksekliği olmalıdır.

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

Bu ön izleme yardımcı, yeniden boyutlandırılmış aralığı [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) kullanarak oluşturur. [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) bu aralığa sınırlar, kenar boşluklarını, üstbilgileri ve altbilgileri kaldırır ve başına konumlandırılmış bir PNG akışı döndürür.

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

{{% alert color="info" title="Note" %}}

Çalışma sayfası yeniden boyutlandırma sorununu çözmek için iki yaklaşım vardır. Gereksinimlerinize ve kullanım durumunuza en uygun yaklaşımı seçin. Her iki yaklaşım da, sunumlar bir şablondan ya da baştan oluşturulmuş olsun aynı şekilde çalışır. Ayrıca, bu çözümde OLE nesne çerçevesinin boyutu üzerinde bir sınırlama yoktur.

{{% /alert %}}

## **SSS**

**Gömülü bir Excel çalışma sayfası PowerPoint'te ilk etkinleştirildiğinde neden boyut değiştirir?**

Bu, Excel'in etkinleştirildiğinde orijinal pencere boyutunu korumaya çalışması, ancak PowerPoint'teki OLE nesne çerçevesinin kendi boyutlarına sahip olması nedeniyle olur. PowerPoint ve Excel, en boy oranını korumak için boyutu müzakere eder, bu da yeniden boyutlandırmaya neden olabilir.

**Bu yeniden boyutlandırma sorunu tamamen önlenebilir mi?**

Evet. OLE çerçevesini Excel hücre aralığı boyutuna uyacak şekilde ölçeklendirerek ya da hücre aralığını istenen OLE çerçeve boyutuna uyacak şekilde ölçeklendirerek istenmeyen yeniden boyutlandırmayı önleyebilirsiniz.

**Hangi ölçekleme yöntemini kullanmalıyım, OLE çerçeve ölçeklendirme mi yoksa hücre aralığı ölçeklendirme mi?**

Sunumunuzda OLE çerçevesi için sabit bir boyut istiyorsanız **hücre aralığı ölçeklendirmesini** seçin. Orijinal Excel satır ve sütun boyutlarını korumak istiyorsanız **OLE çerçeve ölçeklendirmesini** seçin.

**Bu çözümler, sunumum bir şablona dayalıysa çalışır mı?**

Evet. Her iki çözüm de şablondan oluşturulan ve sıfırdan oluşturulan sunumlarda çalışır.

**Bu yöntemleri kullanırken OLE çerçevesi boyutu için bir sınırlama var mı?**

Hayır. Ölçeği uygun şekilde ayarladığınız sürece OLE nesne çerçevesini istediğiniz büyüklükte yapabilirsiniz.

**PowerPoint'te "EMBEDDED OLE OBJECT" yer tutucu metninden kaçınmanın bir yolu var mı?**

Evet. Hedef Excel hücre aralığının bir anlık görüntüsünü alıp bunu OLE çerçevesinin yer tutucu resmi olarak ayarlayarak, varsayılan yer tutucu yerine özel bir ön izleme resmi gösterebilirsiniz.

## **İlgili Makaleler**

[Excel Grafik Oluşturma ve Bir Sunumda OLE Nesnesi Olarak Gömme](/slides/tr/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint Eklentisi Kullanarak OLE Nesnelerini Otomatik Güncelleme](/slides/tr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)