---
title: Çalışma Sayfası Yeniden Boyutlandırma İçin Çalışan Çözüm
type: docs
weight: 20
url: /tr/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- önizleme görüntüsü
- görüntü yeniden boyutlandırma
- Excel
- çalışma sayfası
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Sunumlarda Excel çalışma sayfası OLE yeniden boyutlandırmasını düzeltin: nesne çerçevelerini tutarlı tutmanın iki yolu—çerçeveyi veya sayfayı ölçeklendirin—PPT ve PPTX formatları arasında."
---
{{% alert color="info" %}}

Gözlemlendi ki Aspose bileşenleri aracılığıyla bir PowerPoint sunumuna OLE nesnesi olarak gömülen Excel çalışma sayfaları ilk etkinleştirmenin ardından tanımlanamayan bir ölçeğe yeniden boyutlandırılıyor. Bu davranış, OLE nesnesinin etkinleştirilmeden önceki ve sonraki durumları arasında sunumda gözle görülür bir görsel fark yaratıyor. Bu sorunu ayrıntılı olarak inceledik ve bu makalede ele aldığımız bir çözüm sunduk.

{{% /alert %}}

## **Arka Plan**

Makale [Manage OLE](/slides/tr/java/manage-ole/) içinde, Aspose.Slides for Java kullanarak bir PowerPoint sunumuna OLE çerçevesi eklemenin nasıl yapılacağını açıkladık. [object preview issue](/slides/tr/java/object-preview-issue-when-adding-oleobjectframe/) sorununu ele almak için, seçilen çalışma sayfası alanının bir görüntüsünü OLE nesne çerçevesine atadık. Çıktı sunumunda, çalışma sayfası görüntüsünü gösteren OLE nesne çerçevesine çift tıkladığınızda Excel çalışma kitabı etkinleşir. Son kullanıcılar gerçek Excel çalışma kitabında istedikleri değişiklikleri yapabilir ve ardından etkinleştirilmiş Excel çalışma kitabının dışına tıklayarak slayta geri dönebilir. Kullanıcı slayta döndüğünde OLE nesne çerçevesinin boyutu değişecektir. Yeniden boyutlandırma faktörü, OLE nesne çerçevesinin ve gömülü Excel çalışma kitabının boyutuna bağlı olarak değişir.

## **Yeniden Boyutlandırmanın Nedeni**

Excel çalışma kitabının kendine özgü bir pencere boyutu olduğu için, ilk etkinleştirmede orijinal boyutunu korumaya çalışır. Öte yandan, OLE nesne çerçevesinin kendi boyutu vardır. Microsoft'a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint gömme sürecinin bir parçası olarak doğru oranı korumasını sağlamak için boyutu müzakere eder. Yeniden boyutlandırma, Excel pencere boyutu ile OLE nesne çerçevesinin boyut ve konumu arasındaki farklara dayanarak gerçekleşir.

## **Çözüm**

Yeniden boyutlandırma etkisinden kaçınmak için iki olası çözüm vardır.

- OLE çerçevesinin yüksekliğini ve genişliğini, OLE çerçevesinde istenen satır ve sütun sayısına göre eşleştirmek için PowerPoint sunumundaki OLE çerçeve boyutunu ölçeklendirin.
- OLE çerçeve boyutunu sabit tutun ve katılan satır ve sütunların boyutunu seçilen OLE çerçeve boyutuna sığacak şekilde ölçeklendirin.

### **OLE Çerçeve Boyutunu Ölçeklendir**

Bu yaklaşımda, gömülü Excel çalışma kitabının OLE çerçeve boyutunu, Excel çalışma sayfasındaki katılan satır ve sütunların toplam boyutuna eşleştirmeyi öğreneceğiz.

Bir şablon Excel sayfamız olduğunu ve bunu bir OLE çerçevesi olarak sunuma eklemek istediğimizi varsayalım. Bu senaryoda, OLE nesne çerçevesinin boyutu, çalışma kitabındaki katılan satırların yüksekliklerinin ve sütunların genişliklerinin toplamına göre ilk olarak hesaplanacaktır. Ardından, OLE çerçeve boyutunu bu hesaplanan değere ayarlayacağız. PowerPoint'te OLE çerçevesi için kırmızı "EMBEDDED OLE OBJECT" mesajından kaçınmak için, çalışma kitabındaki istenen satır ve sütun bölümlerinin bir görüntüsünü yakalayacak ve bunu OLE çerçeve resmi olarak ayarlayacağız.

```java
import com.aspose.slides.*;
import java.awt.Image;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import javax.imageio.ImageIO;

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

// Get the width and height of the OLE image in points.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// We need to use the modified workbook.
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
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

### **Hücre Aralığı Boyutunu Ölçeklendir**

Bu yaklaşımda, katılan satırların yüksekliklerini ve katılan sütunların genişliğini, özel bir OLE çerçeve boyutuna eşleştirecek şekilde ölçeklendirmeyi öğreneceğiz.

Bir şablon Excel sayfamız olduğunu ve bunu bir OLE çerçevesi olarak sunuma eklemek istediğimizi varsayalım. Bu senaryoda, OLE çerçeve boyutunu ayarlayacak ve OLE çerçeve alanına katılan satır ve sütunların boyutunu ölçeklendireceğiz. Ardından, değişiklikleri uygulamak için çalışma kitabını bir akıma kaydedecek ve OLE çerçeveye eklemek için bayt dizisine dönüştüreceğiz. PowerPoint'te OLE çerçevesi için kırmızı "EMBEDDED OLE OBJECT" mesajından kaçınmak amacıyla, çalışma kitabındaki istenen satır ve sütun bölümlerinin bir görüntüsünü yakalayıp bunu OLE çerçeve resmi olarak ayarlayacağız.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

// Hücre aralığını çerçeve boyutuna sığacak şekilde ölçeklendirin.
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
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

{{% alert color="info" %}} 

Çalışma sayfası yeniden boyutlandırma sorununu düzeltmek için iki yaklaşım vardır. Uygun yaklaşımın seçimi, belirli gereksinimler ve kullanım durumuna bağlıdır. Her iki yaklaşım da aynı şekilde çalışır, sunumlar bir şablondan veya sıfırdan oluşturulmuş olsun. Ayrıca, bu çözümde OLE nesne çerçevesinin boyutu için bir sınırlama yoktur.

{{% /alert %}}

## **SSS**

### Bir gömülü Excel çalışma sayfası PowerPoint'te ilk etkinleştirildiğinde neden boyut değiştiriyor?

Bu, Excel'in etkinleştirildiğinde orijinal pencere boyutunu korumaya çalışması, PowerPoint'teki OLE nesne çerçevesinin ise kendi boyutlarına sahip olması nedeniyle olur. PowerPoint ve Excel, en boy oranını korumak için boyutu müzakere eder; bu da yeniden boyutlandırmaya yol açabilir.

### Bu yeniden boyutlandırma sorunu tamamen önlenebilir mi?

Evet. OLE çerçevesini Excel hücre aralığı boyutuna göre ölçeklendirerek veya hücre aralığını istediğiniz OLE çerçeve boyutuna sığacak şekilde ölçeklendirerek istenmeyen yeniden boyutlandırmayı önleyebilirsiniz.

### Hangi ölçeklendirme yöntemini kullanmalıyım, OLE çerçeve ölçeklendirme mi yoksa hücre aralığı ölçeklendirme mi?

Sunumunuzda OLE çerçevesi için sabit bir boyut istiyorsanız **OLE çerçeve ölçeklendirme**'yi, orijinal Excel satır ve sütun boyutlarını korumak istiyorsanız **hücre aralığı ölçeklendirme**'yi seçin.

### Sunumum bir şablona dayalıysa bu çözümler çalışır mı?

Evet. Her iki çözüm de şablondan oluşturulan ve sıfırdan oluşturulan sunumlarda çalışır.

### Bu yöntemleri kullanırken OLE çerçeve boyutu için bir sınırlama var mı?

Hayır. Ölçeği uygun şekilde ayarladığınız sürece OLE nesne çerçevesini istediğiniz boyutta yapabilirsiniz.

### PowerPoint'te "EMBEDDED OLE OBJECT" yer tutucu metninden kaçınmanın bir yolu var mı?

Evet. Hedef Excel hücre aralığının bir görüntüsünü alıp bunu OLE çerçevesinin yer tutucu resmi olarak ayarlayarak, varsayılan yer tutucunun yerine özel bir ön izleme resmi gösterebilirsiniz.

## **İlgili Makaleler**

[Bir Excel Çizelgesi Oluşturma ve Sunumda OLE Nesnesi Olarak Gömme](/slides/tr/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint Eklentisi Kullanarak OLE Nesnelerini Otomatik Olarak Güncelleme](/slides/tr/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)