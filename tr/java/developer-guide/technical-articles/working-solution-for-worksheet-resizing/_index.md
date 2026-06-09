---
title: Çalışma Sayfası Yeniden Boyutlandırma İçin Çalışan Çözüm
type: docs
weight: 20
url: /tr/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- önizleme resmi
- görsel yeniden boyutlandırma
- Excel
- çalışma sayfası
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Sunumlarda Excel çalışma sayfası OLE yeniden boyutlandırmasını düzeltin: nesne çerçevelerini tutarlı tutmanın iki yolu—çerçeveyi veya sayfayı ölçeklendirin—PPT ve PPTX formatları boyunca."
---
{{% alert color="primary" %}}
Gözlemlenmiştir ki Aspose bileşenleri aracılığıyla PowerPoint sunumuna OLE nesneleri olarak gömülen Excel çalışma sayfaları, ilk etkinleştirmenin ardından tanımlanamayan bir ölçeğe yeniden boyutlandırılmaktadır. Bu davranış, OLE nesnesinin etkinleştirme öncesi ve sonrası durumları arasında sunumda fark edilebilir bir görsel farklılık yaratmaktadır. Bu sorunu detaylı olarak inceledik ve bu makalede yer alan bir çözüm sunduk.
{{% /alert %}}

## **Arka Plan**

Bu makalede [OLE Yönetimi](/slides/tr/java/manage-ole/) adlı makalede, Aspose.Slides for Java kullanarak bir PowerPoint sunumuna OLE çerçevesi eklemenin nasıl yapılacağını açıkladık. [nesne önizleme sorunu](/slides/tr/java/object-preview-issue-when-adding-oleobjectframe/) sorununu çözmek için, seçilen çalışma sayfası alanının bir görüntüsünü OLE nesne çerçevesine atadık. Çıktı sunumunda, çalışma sayfası görüntüsünü gösteren OLE nesne çerçevesine çift tıkladığınızda Excel çalışma kitabı etkinleştirilir. Son kullanıcılar gerçek Excel çalışma kitabında istedikleri değişiklikleri yapabilir ve etkinleştirilmiş Excel çalışma kitabının dışına tıklayarak slayta geri dönebilir. Kullanıcı slayta döndüğünde OLE nesne çerçevesinin boyutu değişecektir. Yeniden boyutlandırma faktörü, OLE nesne çerçevesinin ve gömülü Excel çalışma kitabının boyutuna bağlı olarak değişecektir.

## **Yeniden Boyutlandırmanın Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğu için, ilk etkinleştirmede orijinal boyutunu korumaya çalışır. Öte yandan OLE nesne çerçevesinin de kendi boyutu vardır. Microsoft'a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint gömme sürecinin bir parçası olarak doğru oranların korunmasını sağlamak için boyut üzerinde uzlaşır. Yeniden boyutlandırma, Excel pencere boyutu ile OLE nesne çerçevesinin boyut ve konumu arasındaki farklara göre gerçekleşir.

## **Çözüm**

Bu yeniden boyutlandırma etkisini önlemek için iki olası çözüm vardır.

- OLE çerçevesindeki satır ve sütun sayısına göre yüksekliği ve genişliği eşleyecek şekilde PowerPoint sunumundaki OLE çerçeve boyutunu ölçeklendirin.
- OLE çerçeve boyutunu sabit tutun ve katılan satır ve sütunların boyutlarını seçili OLE çerçeve boyutuna sığacak şekilde ölçeklendirin.

### **OLE Çerçeve Boyutunu Ölçeklendirme**

Bu yaklaşımda, gömülü Excel çalışma kitabının OLE çerçeve boyutunu, Excel çalışma sayfasındaki katılan satır ve sütunların toplam boyutuna eşit olacak şekilde ayarlamayı öğreneceğiz.

Bir şablon Excel sayfamız olduğunu ve bunu bir OLE çerçevesi olarak sunuma eklemek istediğimizi varsayalım. Bu senaryoda, OLE nesne çerçevesinin boyutu, çalışma kitabındaki katılan satırların yüksekliği ve sütunların genişliğinin toplamına göre önce hesaplanacaktır. Daha sonra OLE çerçeve boyutunu bu hesaplanan değere ayarlayacağız. PowerPoint'te OLE çerçevesi için kırmızı "EMBEDDED OLE OBJECT" mesajından kaçınmak için, çalışma kitabındaki istenen satır ve sütun bölümlerinin bir görüntüsünü alıp OLE çerçeve resmi olarak ayarlayacağız.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Çalışma kitabı dosyası PowerPoint'te OLE nesnesi olarak kullanıldığında görüntülenen boyutu ayarlayın.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// OLE görüntüsünün genişliğini ve yüksekliğini puan cinsinden alın.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Değiştirilmiş çalışma kitabını kullanmamız gerekiyor.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE görüntüsünü sunum kaynaklarına ekleyin.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// OLE nesne çerçevesini oluşturun.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

### **Hücre Aralığı Boyutunu Ölçeklendirme**

Bu yaklaşımda, katılan satırların yüksekliğini ve katılan sütunların genişliğini, özel bir OLE çerçeve boyutuna uyduracak şekilde ölçeklendirmeyi öğreneceğiz.

Bir şablon Excel sayfamız olduğunu ve bunu OLE çerçevesi olarak bir sunuma eklemek istediğimizi varsayalım. Bu senaryoda, OLE çerçeve boyutunu belirleyecek ve OLE çerçeve alanına katılan satır ve sütunların boyutunu ölçeklendireceğiz. Ardından değişiklikleri uygulamak için çalışma kitabını bir akıma kaydedip OLE çerçevesine eklemek üzere bir bayt dizisine dönüştüreceğiz. PowerPoint'te OLE çerçevesi için kırmızı "EMBEDDED OLE OBJECT" mesajından kaçınmak için, çalışma kitabındaki istenen satır ve sütun bölümlerinin bir görüntüsünü alıp OLE çerçeve resmi olarak ayarlayacağız.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Çalışma kitabı dosyası PowerPoint'te OLE nesnesi olarak kullanıldığında görüntülenen boyutu ayarlayın.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Hücre aralığını çerçeve boyutuna uyması için ölçeklendirin.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Değiştirilmiş çalışma kitabını kullanmamız gerekiyor.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE görüntüsünü sunum kaynaklarına ekleyin.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// OLE nesne çerçevesini oluşturun.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
/**
 * @param width     Hücre aralığının noktalar cinsinden beklenen genişliği.
 * @param height    Hücre aralığının noktalar cinsinden beklenen yüksekliği.
 */
static void ScaleCellRange(com.aspose.cells.Range cellRange, float width, float height) {
    double rangeWidth = cellRange.getWidth();
    double rangeHeight = cellRange.getHeight();

    for (int i = 0; i < cellRange.getColumnCount(); i++) {
        int columnIndex = cellRange.getFirstColumn() + i;
        double columnWidth = cellRange.getWorksheet()
                .getCells()
                .getColumnWidth(columnIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newColumnWidth = columnWidth * width / rangeWidth;
        double widthInInches = newColumnWidth / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.getRowCount(); i++) {
        int rowIndex = cellRange.getFirstRow() + i;
        double rowHeight = cellRange.getWorksheet()
                .getCells()
                .getRowHeight(rowIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newRowHeight = rowHeight * height / rangeHeight;
        double heightInInches = newRowHeight / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setRowHeightInch(rowIndex, heightInInches);
    }
}
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

## **Sonuç**

{{% alert color="primary" %}}
Çalışma sayfası yeniden boyutlandırma sorununu gidermek için iki yaklaşım vardır. Uygun yaklaşımın seçimi, belirli gereksinimlere ve kullanım senaryosuna bağlıdır. Her iki yaklaşım da aynı şekilde çalışır; sunumlar bir şablondan ya da sıfırdan oluşturulmuş olsun fark etmez. Ayrıca bu çözüme OLE nesne çerçevesi boyutu için bir sınır yoktur.
{{% /alert %}}

## **SSS**

**Gömülü bir Excel çalışma sayfası, PowerPoint'te ilk etkinleştirildiğinde neden boyut değiştirir?**

Bu, Excel etkinleştirildiğinde orijinal pencere boyutunu korumaya çalışması, PowerPoint'teki OLE nesne çerçevesinin ise kendi boyutlarına sahip olması nedeniyle olur. PowerPoint ve Excel doğru en‑boy oranını korumak için boyut üzerinde uzlaşır ve bu da yeniden boyutlandırmaya neden olabilir.

**Bu yeniden boyutlandırma sorunu tamamen önlenebilir mi?**

Evet. OLE çerçevesini Excel hücre aralığı boyutuna uydurarak veya hücre aralığını istenen OLE çerçeve boyutuna sığacak şekilde ölçeklendirerek istenmeyen yeniden boyutlandırmayı önleyebilirsiniz.

**Hangi ölçeklendirme yöntemini kullanmalıyım, OLE çerçeve ölçeklendirme mi yoksa hücre aralığı ölçeklendirme mi?**

Orijinal Excel satır ve sütun boyutlarını korumak istiyorsanız **OLE çerçeve ölçeklendirmesini** seçin. Sunumunuzda OLE çerçevesi için sabit bir boyut istiyorsanız **hücre aralığı ölçeklendirmesini** seçin.

**Sunumum bir şablona dayalıysa bu çözümler işe yarar mı?**

Evet. Her iki çözüm de şablondan veya sıfırdan oluşturulan sunumlar için çalışır.

**Bu yöntemleri kullanırken OLE çerçevesi boyutu için bir limit var mı?**

Hayır. Ölçeği uygun şekilde ayarladığınız sürece OLE nesne çerçevesini istediğiniz boyutta yapabilirsiniz.

**PowerPoint'te "EMBEDDED OLE OBJECT" yer tutucu metninden kaçınmanın bir yolu var mı?**

Evet. Hedef Excel hücre aralığının bir anlık görüntüsünü alıp bunu OLE çerçeve yer tutucu resmi olarak ayarlayarak varsayılan yer tutucu yerine özel bir önizleme resmi gösterebilirsiniz.

## **İlgili Makaleler**

[Excel Grafiği Oluşturma ve OLE Nesnesi Olarak Sunuma Gömme](/slides/tr/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint eklentisi kullanarak OLE Nesnelerini otomatik güncelleme](/slides/tr/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)