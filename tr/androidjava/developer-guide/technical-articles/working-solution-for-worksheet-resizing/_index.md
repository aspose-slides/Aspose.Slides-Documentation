---
title: Çalışma Sayfası Yeniden Boyutlandırma İçin Çalışan Çözüm
type: docs
weight: 20
url: /tr/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- önizleme resmi
- görüntü yeniden boyutlandırma
- Excel
- çalışma sayfası
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Sunumlarda Excel çalışma sayfası OLE yeniden boyutlandırmasını düzeltin: nesne çerçevelerini tutarlı tutmanın iki yolu—çerçeveyi veya sayfayı ölçeklendirin—PPT ve PPTX formatları boyunca."
---
{{% alert color="primary" %}}

Aspose bileşenleri aracılığıyla bir PowerPoint sunumuna OLE nesnesi olarak gömülen Excel çalışma sayfalarının, ilk etkinleştirmeden sonra tanımlanamayan bir ölçeğe yeniden boyutlandırıldığı gözlemlenmiştir. Bu davranış, OLE nesnesinin etkinleştirilmeden önceki ve sonraki durumları arasında belirgin bir görsel fark oluşturur. Bu sorunu ayrıntılı olarak araştırdık ve bu makalede ele alınan bir çözüm sağladık.

{{% /alert %}}

## **Background**

[Manage OLE](/slides/tr/androidjava/manage-ole/) makalesinde, Aspose.Slides for Android via Java kullanarak bir PowerPoint sunumuna OLE çerçevesi eklemenin nasıl yapılacağını açıkladık. [object preview issue](/slides/tr/androidjava/object-preview-issue-when-adding-oleobjectframe/) sorununu çözmek için, seçilen çalışma sayfası alanının bir resmini OLE nesne çerçevesine atadık. Çıktı sunumunda, çalışma sayfası görüntüsünü gösteren OLE nesne çerçevesine çift tıkladığınızda Excel çalışma kitabı etkinleştirilir. Son kullanıcılar gerçek Excel çalışma kitabında istedikleri değişiklikleri yapabilir ve ardından etkinleştirilen Excel çalışma kitabının dışına tıklayarak slayta geri dönebilir. Kullanıcı slayta döndüğünde OLE nesne çerçevesinin boyutu değişecektir. Yeniden boyutlandırma faktörü, OLE nesne çerçevesinin ve gömülü Excel çalışma kitabının boyutuna bağlı olarak değişir.

## **Cause of Resizing**

Excel çalışma kitabının kendi pencere boyutu olduğu için ilk etkinleştirmede orijinal boyutunu korumaya çalışır. Öte yandan OLE nesne çerçevesinin kendi boyutu vardır. Microsoft'a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint gömme sürecinin bir parçası olarak doğru oranları korumasını sağlamak için boyutu müzakere eder. Yeniden boyutlandırma, Excel pencere boyutu ile OLE nesne çerçevesinin boyut ve konumu arasındaki farklara göre gerçekleşir.

## **Working Solution**

Yeniden boyutlandırma etkisini önlemek için iki olası çözüm vardır.

- OLE çerçevesinin yüksekliğini ve genişliğini, OLE çerçevesindeki istenen satır ve sütun sayısına uygun şekilde ölçeklendirin.
- OLE çerçevesi boyutunu sabit tutun ve katılan satır ve sütunların boyutlarını seçilen OLE çerçevesi boyutuna sığacak şekilde ölçeklendirin.

### **Scale the OLE Frame Size**

Bu yaklaşımda, gömülü Excel çalışma kitabının OLE çerçevesi boyutunu, Excel çalışma sayfasındaki katılan satır ve sütunların toplam boyutuna eşitlemeyi öğreneceğiz.

Örneğin bir şablon Excel sayfamız var ve bunu bir sunuma OLE çerçevesi olarak eklemek istiyoruz. Bu senaryoda, OLE nesne çerçevesinin boyutu önce çalışma kitabındaki katılan satırların toplam yüksekliği ve sütunların toplam genişliği temelinde hesaplanacaktır. Ardından OLE çerçevesinin boyutunu bu hesaplanan değere ayarlayacağız. PowerPoint'te OLE çerçevesi için kırmızı “EMBEDDED OLE OBJECT” mesajını önlemek amacıyla, çalışma kitabındaki satır ve sütunların istenen bölümlerinin bir görüntüsünü de yakalayarak OLE çerçevesi resmi olarak ayarlayacağız.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Çalışma kitabı dosyası PowerPoint'te bir OLE nesnesi olarak kullanıldığında görüntülenen boyutu ayarlayın.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// OLE görüntüsünün genişliğini ve yüksekliğini puan cinsinden alın.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Değiştirilmiş çalışma kitabını kullanmamız gerekiyor.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add the OLE image to the presentation resources.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Create the OLE object frame.
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

### **Scale the Cell Range Size**

Bu yaklaşımda, katılan satırların yüksekliğini ve katılan sütunların genişliğini özel bir OLE çerçevesi boyutuna uyduracak şekilde ölçeklendirmeyi öğreneceğiz.

Örneğin bir şablon Excel sayfamız var ve bunu bir sunuma OLE çerçevesi olarak eklemek istiyoruz. Bu senaryoda OLE çerçevesinin boyutunu ayarlayacak ve OLE çerçevesi alanına katılan satır ve sütunların boyutunu ölçeklendireceğiz. Daha sonra değişiklikleri uygulamak için çalışma kitabını bir akışa kaydedip OLE çerçevesine eklemek üzere bayt dizisine dönüştüreceğiz. PowerPoint'te OLE çerçevesi için kırmızı “EMBEDDED OLE OBJECT” mesajını önlemek amacıyla, çalışma kitabındaki satır ve sütunların istenen bölümlerinin bir görüntüsünü de yakalayarak OLE çerçevesi resmi olarak ayarlayacağız.

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

// Çerçeve boyutuna sığacak şekilde hücre aralığını ölçeklendirin.
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

## **Conclusion**

{{% alert color="primary" %}} 

Çalışma sayfası yeniden boyutlandırma sorununu düzeltmek için iki yaklaşım vardır. Uygun yaklaşımın seçimi, belirli gereksinimlere ve kullanım senaryosuna bağlıdır. Her iki yaklaşım da sunumlar şablondan ya da sıfırdan oluşturulmuş olsun aynı şekilde çalışır. Ayrıca bu çözümde OLE nesne çerçevesinin boyutu için bir sınırlama yoktur.

{{% /alert %}}

## **FAQ**

**Why does an embedded Excel worksheet change size when first activated in PowerPoint?**  
Bu, Excel etkinleştirildiğinde orijinal pencere boyutunu korumaya çalışması, PowerPoint'teki OLE nesne çerçevesinin ise kendi boyutuna sahip olması nedeniyle gerçekleşir. PowerPoint ve Excel, en boy oranını korumak için boyutu müzakere eder ve bu da yeniden boyutlandırmaya yol açabilir.

**Is it possible to prevent this resizing issue entirely?**  
Evet. OLE çerçevesini Excel hücre aralığı boyutuna uydurarak veya hücre aralığını istenen OLE çerçevesi boyutuna uydurarak istenmeyen yeniden boyutlandırmayı önleyebilirsiniz.

**Which scaling method should I use, OLE frame scaling or cell range scaling?**  
Orijinal Excel satır ve sütun boyutlarını korumak istiyorsanız **OLE çerçeve ölçeklendirmesini** seçin. Sunumunuzda OLE çerçevesi için sabit bir boyut istiyorsanız **hücre aralığı ölçeklendirmesini** seçin.

**Will these solutions work if my presentation is based on a template?**  
Evet. Her iki çözüm de şablondan oluşturulan ve sıfırdan oluşturulan sunumlarda çalışır.

**Is there a limit to the size of the OLE frame when using these methods?**  
Hayır. Ölçeği uygun şekilde ayarladığınız sürece OLE nesne çerçevesini istediğiniz boyutta yapabilirsiniz.

**Is there a way to avoid the "EMBEDDED OLE OBJECT" placeholder text in PowerPoint?**  
Evet. Hedef Excel hücre aralığının bir ekran görüntüsünü alıp bunu OLE çerçevesinin yer tutucu resmi olarak ayarlayarak varsayılan yer tutucu metni kaldırabilirsiniz.