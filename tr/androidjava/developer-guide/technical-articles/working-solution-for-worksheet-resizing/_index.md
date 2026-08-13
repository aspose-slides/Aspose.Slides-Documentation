---
title: Çalışma Sayfası Yeniden Boyutlandırma için Çözüm
type: docs
weight: 20
url: /tr/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- ön izleme görüntüsü
- görüntü yeniden boyutlandırma
- Excel
- çalışma sayfası
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Sunumlarda Excel çalışma sayfası OLE yeniden boyutlandırmasını düzeltin: nesne çerçevelerini tutarlı tutmanın iki yolu—çerçeveyi veya sayfayı ölçeklendirmek—PPT ve PPTX formatlarında."
---
{{% alert color="info" %}}

Excel çalışma sayfalarının OLE nesneleri olarak PowerPoint sunumuna Aspose bileşenleri aracılığıyla gömülmesi sonrasında ilk etkinleştirmeden sonra tanımlanamayan bir ölçeğe yeniden boyutlandırıldığı gözlemlenmiştir. Bu davranış, OLE nesnesinin etkinleştirilmeden önceki ve sonraki durumları arasında belirgin bir görsel fark yaratmaktadır. Bu sorunu ayrıntılı olarak inceledik ve bu makalede ele alınan bir çözüm sunduk.

{{% /alert %}}

## **Arka Plan**

Makale [OLE'yi Yönet](/slides/tr/androidjava/manage-ole/) içinde, Aspose.Slides for Android via Java kullanarak bir PowerPoint sunumuna OLE çerçevesi eklemenin nasıl yapılacağını açıkladık. [nesne ön izleme sorunu](/slides/tr/androidjava/object-preview-issue-when-adding-oleobjectframe/) sorununu gidermek için seçilen çalışma sayfası alanının bir resmini OLE nesne çerçevesine atadık. Çıktı sunumunda, çalışma sayfası resmini gösteren OLE nesne çerçevesine çift tıkladığınızda Excel çalışma kitabı etkinleştirilir. Son kullanıcılar gerçek Excel çalışma kitabında istedikleri değişiklikleri yapabilir ve ardından etkinleştirilen Excel çalışma kitabının dışına tıklayarak slayta geri dönebilir. Kullanıcı slayta geri döndüğünde OLE nesne çerçevesinin boyutu değişir. Yeniden boyutlandırma faktörü, OLE nesne çerçevesinin ve gömülü Excel çalışma kitabının boyutuna bağlı olarak değişir.

## **Yeniden Boyutlandırmanın Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğundan, ilk etkinleştirmede orijinal boyutunu korumaya çalışır. Öte yandan, OLE nesne çerçevesinin de kendi boyutu vardır. Microsoft'a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint gömme sürecinin bir parçası olarak doğru oranların korunmasını sağlamak amacıyla boyutu müzakere eder. Yeniden boyutlandırma, Excel pencere boyutu ile OLE nesne çerçevesinin boyut ve konumundaki farklara dayanarak gerçekleşir.

## **Çözüm**

Yeniden boyutlandırma etkisini önlemek için iki olası çözüm vardır.

- OLE çerçevesinin yüksekliğini ve genişliğini, OLE çerçevesinde istenen satır ve sütun sayısına göre eşleyecek şekilde PowerPoint sunumunda ölçeklendirin.
- OLE çerçevesinin boyutunu sabit tutun ve katılan satır ve sütunların boyutlarını seçilen OLE çerçevesi boyutuna sığacak şekilde ölçeklendirin.

### **OLE Çerçeve Boyutunu Ölçekle**

Bu yaklaşımla, gömülü Excel çalışma kitabının OLE çerçeve boyutunu, Excel çalışma sayfasındaki katılan satır ve sütunların toplu boyutuna eşleştirmeyi öğreneceğiz.

Bir şablon Excel sayfasına sahibiz ve bunu bir OLE çerçevesi olarak sunuma eklemek istiyoruz. Bu senaryoda, OLE nesne çerçevesinin boyutu önce çalışma kitabındaki katılan satırların yüksekliği ve sütunların genişliğinin toplamına dayanarak hesaplanır. Ardından, OLE çerçevesinin boyutunu bu hesaplanmış değere ayarlarız. PowerPoint'te OLE çerçevesi için kırmızı “EMBEDDED OLE OBJECT” mesajını önlemek amacıyla, çalışma kitabındaki istenen satır ve sütun bölümlerinin bir görüntüsünü yakalar ve bunu OLE çerçeve resmi olarak ayarlarız.

```java
import com.aspose.slides.*;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Workbook dosyası PowerPoint'te OLE nesnesi olarak kullanıldığında görüntülenen boyutu ayarlayın.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// OLE görüntüsünün genişliğini ve yüksekliğini puan cinsinden alın.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

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

### **Hücre Aralığı Boyutunu Ölçekle**

Bu yaklaşımla, katılan satırların yüksekliğini ve katılan sütunların genişliğini, özel bir OLE çerçeve boyutuna eşit olacak şekilde ölçeklendirmeyi öğreneceğiz.

Bir şablon Excel sayfasına sahibiz ve bunu bir OLE çerçevesi olarak sunuma eklemek istiyoruz. Bu senaryoda, OLE çerçevesinin boyutunu ayarlar ve OLE çerçeve alanına katılan satır ve sütunların boyutunu ölçeklendiririz. Ardından, değişiklikleri uygulamak için çalışma kitabını bir akıma kaydeder ve OLE çerçevesine eklemek üzere bir bayt dizisine dönüştürürüz. PowerPoint'te OLE çerçevesi için kırmızı “EMBEDDED OLE OBJECT” mesajını önlemek amacıyla, çalışma kitabındaki istenen satır ve sütun bölümlerinin bir görüntüsünü yakalar ve bunu OLE çerçeve resmi olarak ayarlarız.

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

// Workbook dosyası PowerPoint'te OLE nesnesi olarak kullanıldığında görüntülenen boyutu ayarlayın.
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
 * @param width     Hücre aralığının puan cinsinden beklenen genişliği.
 * @param height    Hücre aralığının puan cinsinden beklenen yüksekliği.
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

Çalışma sayfası yeniden boyutlandırma sorununu çözmek için iki yaklaşım vardır. Uygun yaklaşımın seçimi, belirli gereksinimler ve kullanım senaryosuna bağlıdır. Her iki yaklaşım da sunumlar bir şablondan veya sıfırdan oluşturulsa aynı şekilde çalışır. Ayrıca bu çözümde OLE nesne çerçevesinin boyutu için bir sınırlama bulunmamaktadır.

{{% /alert %}}

## **SSS**

### Yerleşik bir Excel çalışma sayfası PowerPoint’te ilk etkinleştirildiğinde neden boyut değiştirir?

Excel, etkinleştirildiğinde orijinal pencere boyutunu korumaya çalışırken, PowerPoint’teki OLE nesne çerçevesinin kendi boyutları vardır. PowerPoint ve Excel, en-boy oranını korumak için boyutu müzakere eder; bu da yeniden boyutlandırmaya yol açabilir.

### Bu yeniden boyutlandırma sorunu tamamen önlenebilir mi?

Evet. OLE çerçevesini Excel hücre aralığı boyutuna göre ölçeklendirmek ya da hücre aralığını istediğiniz OLE çerçeve boyutuna göre ölçeklendirmek, istenmeyen yeniden boyutlandırmayı önler.

### Hangi ölçekleme yöntemi kullanılmalı, OLE çerçevesi ölçekleme mi yoksa hücre aralığı ölçekleme mi?

Orijinal Excel satır ve sütun boyutlarını korumak istiyorsanız **OLE çerçevesi ölçekleme** seçin. Sunumunuzda OLE çerçevesi için sabit bir boyut istiyorsanız **hücre aralığı ölçekleme** seçin.

### Bu çözümler, sunumum bir şablondan oluşturulmuşsa çalışır mı?

Evet. Her iki çözüm de şablondan ve sıfırdan oluşturulmuş sunumlarda çalışır.

### Bu yöntemleri kullanırken OLE çerçevesi boyutu için bir limit var mı?

Hayır. Ölçeği uygun şekilde ayarladığınız sürece OLE nesne çerçevesini istediğiniz herhangi bir boyutta yapabilirsiniz.

### PowerPoint’te “EMBEDDED OLE OBJECT” yer tutucu metninden nasıl kaçınabilirim?

Evet. Hedef Excel hücre aralığının bir anlık görüntüsünü alıp bunu OLE çerçevesinin yer tutucu resmi olarak ayarlayarak, varsayılan yer tutucu yerine özel bir ön izleme resmi gösterebilirsiniz.