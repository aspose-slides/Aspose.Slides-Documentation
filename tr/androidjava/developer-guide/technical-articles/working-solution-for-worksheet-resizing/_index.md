---
title: Çalışma Sayfası Yeniden Boyutlandırma için Çalışan Çözüm
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
description: "Sunumlarda Excel çalışma sayfası OLE yeniden boyutlandırmasını düzeltin: nesne çerçevelerini tutarlı tutmanın iki yolu—çerçeveyi veya sayfayı ölçeklendirin—PPT ve PPTX formatları arasında."
---
{{% alert color="info" title="Note" %}}

Aspose bileşenleri kullanılarak bir PowerPoint sunumunda OLE nesneleri olarak gömülü Excel çalışma sayfaları, ilk etkinleştirildikten sonra beklenmedik şekilde yeniden boyutlandırılabilir. Bu davranış, OLE nesnesinin etkinleştirilmeden önceki ve sonraki durumları arasında belirgin bir görsel fark yaratır. Bu makale sorunu açıklamakta ve iki çözüm yolunu tanımlamaktadır.

{{% /alert %}}

## **Arka Plan**

[OLE Yönetimi](/slides/tr/androidjava/manage-ole/) makalesinde, Aspose.Slides for Android via Java kullanarak bir PowerPoint sunumuna OLE çerçevesi eklemenin nasıl yapılacağını açıkladık. [nesne önizleme sorunu](/slides/tr/androidjava/object-preview-issue-when-adding-oleobjectframe/) sorununu çözmek için seçilen çalışma sayfası alanının bir resmini OLE nesne çerçevesine atadık. Çıktı sunumunda, çalışma sayfası resmini gösteren OLE nesne çerçevesine çift tıkladığınızda Excel çalışma kitabı etkinleştirilir. Son kullanıcılar gerçek Excel çalışma kitabında istediği değişiklikleri yapabilir ve ardından etkinleştirilmiş Excel çalışma kitabının dışına tıklayarak slayta geri dönebilir. Kullanıcı slayta döndüğünde OLE nesne çerçevesinin boyutu değişecektir. Yeniden boyutlandırma faktörü, OLE nesne çerçevesinin ve gömülü Excel çalışma kitabının boyutuna bağlı olarak değişir.

## **Yeniden Boyutlandırma Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğundan, ilk etkinleştirmede orijinal boyutunu korumaya çalışır. Öte yandan OLE nesne çerçevesinin kendi boyutu vardır. Microsoft’a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint gömme sürecinin bir parçası olarak doğru oranların korunmasını sağlamak için boyutu müzakere eder. Yeniden boyutlandırma, Excel pencere boyutu ile OLE nesne çerçevesinin boyut ve konumunun farkına dayanarak gerçekleşir.

## **Çözüm**

Yeniden boyutlandırma etkisini önlemek için iki olası çözüm vardır.

- PowerPoint sunumundaki OLE çerçevesini, seçilen satır ve sütunların toplam yüksekliği ve genişliğiyle eşleşecek şekilde ölçeklendirin.
- OLE çerçevesi boyutunu sabit tutun ve seçilen satır ve sütunları çerçeveye sığacak şekilde ölçeklendirin.

### **OLE Çerçeve Boyutunu Ölçeklendirin**

Bu yaklaşım, gömülü Excel çalışma sayfasındaki seçilen satır ve sütunların toplam yüksekliği ve genişliğiyle eşleşecek şekilde OLE çerçeve boyutunu ayarlar.

Örnek, var olan bir Excel çalışma kitabını yükler ve sıfır‑tabanlı dizinler kullanarak ilk çalışma sayfasının ilk 10 satırını ve 13 sütununu seçer. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) görüntülenen aralığı tanımlar. Önizleme 96 DPI’de render edilir ve piksel boyutları inç başına 72 puan kullanılarak puana dönüştürülür. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) değiştirilmiş çalışma kitabını bu boyutlarda bir çerçeveye gömer. Önizleme, kaydedilen sunumdaki “EMBEDDED OLE OBJECT” yer tutucusunu değiştirmek için [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) aracılığıyla atanır.

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

// PowerPoint'te çalışma kitabı dosyası OLE nesnesi olarak kullanıldığında görüntülenen boyutu ayarla.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// OLE görselinin genişliğini ve yüksekliğini puan cinsinden alın.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// Değiştirilmiş çalışma kitabını kullanmamız gerekiyor.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE görselini sunum kaynaklarına ekle.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// OLE nesne çerçevesini oluştur.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

Önizleme yardımcı programı, seçilen aralığa [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) uygulayarak kenar boşluklarını, üstbilgileri ve altbilgileri kaldırır. [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) etkinleştirildiğinde, [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) aralığı PNG görüntüsü olarak render eder. Yardımcı, PNG görüntüsünü içeren yeni bir giriş akışı döndürür; bu akış sunumda kullanılmak üzere başına konumlandırılır.

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

### **Hücre Aralığı Boyutunu Ölçeklendirin**

Bu yaklaşım, seçilen satırların yüksekliğini ve seçilen sütunların genişliğini özel bir OLE çerçeve boyutuna uyacak şekilde ölçeklendirir.

Örnek, var olan bir Excel çalışma kitabını yükler ve sıfır‑tabanlı dizinler kullanarak ilk çalışma sayfasının ilk 10 satırını ve 13 sütununu seçer. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) görüntülenen aralığı tanımlar ve aşağıdaki yardımcı, bu aralığı 400 puan genişliğinde ve 100 puan yüksekliğinde bir çerçeveye sığacak şekilde ölçeklendirir. Değiştirilmiş çalışma kitabı bir akıma kaydedildikten sonra, [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) belirtilen boyutta çerçeveye gömülür. 96 DPI’de render edilen bir önizleme, [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) aracılığıyla atanır; böylece kaydedilen sunum, varsayılan yer tutucu yerine seçilen hücreleri gösterir.

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

// Çalışma kitabı dosyası PowerPoint'te OLE nesnesi olarak kullanıldığında görüntülenen boyutu ayarla.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Hücre aralığını çerçeve boyutuna uyduracak şekilde ölçeklendir.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Değiştirilmiş çalışma kitabını kullanmamız gerekiyor.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE görüntüsünü sunum kaynaklarına ekle.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// OLE nesne çerçevesini oluştur.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

Ölçekleme yardımcı programı, seçilen aralık için ayrı genişlik ve yükseklik oranları hesaplar; bu sayede sütunların ve satırların göreceli genişlik ve yükseklikleri korunur. Hesaplanan boyutlar puandan inçe dönüştürülür ve ardından [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) ve [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-) ile uygulanır. Seçilen aralık sıfır olmayan bir genişlik ve yüksekliğe sahip olmalıdır.

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

Bu önizleme yardımcı programı, yeniden boyutlandırılmış aralığı [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) ile render eder. [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) yalnızca bu aralığa sınırlanır, kenar boşlukları, üstbilgiler ve altbilgiler kaldırılır ve PNG akışı başına konumlandırılarak döndürülür.

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

{{% alert color="info" title="Note" %}}

Çalışma sayfası yeniden boyutlandırma sorununu gidermek için iki yaklaşım vardır. Gereksinimlerinize ve kullanım senaryonuza en uygun olanı seçin. Her iki yaklaşım da sunumun bir şablondan mı yoksa sıfırdan mı oluşturulduğuna bakılmaksızın aynı şekilde çalışır. Ayrıca bu çözümde OLE nesne çerçevesinin boyutu için bir sınırlama yoktur.

{{% /alert %}}

## **SSS**

**Bir PowerPoint sunumunda gömülü bir Excel çalışma sayfası ilk etkinleştirildiğinde neden boyutu değişir?**

Excel, etkinleştirildiğinde orijinal pencere boyutunu korumaya çalışır; PowerPoint’teki OLE nesne çerçevesi ise farklı bir boyuta sahiptir. PowerPoint ve Excel, en boy oranını korumak için boyutu müzakere eder ve bu da yeniden boyutlandırmaya yol açar.

**Bu yeniden boyutlandırma sorunu tamamen önlenebilir mi?**

Evet. OLE çerçevesini Excel hücre aralığı boyutuna göre ölçeklendirerek veya hücre aralığını istediğiniz OLE çerçeve boyutuna göre ölçeklendirerek istenmeyen yeniden boyutlandırmayı önleyebilirsiniz.

**Hangi ölçekleme yöntemini kullanmalıyım, OLE çerçeve ölçeklendirme mi yoksa hücre aralığı ölçeklendirme mi?**

Orijinal Excel satır ve sütun boyutlarını korumak istiyorsanız **OLE çerçeve ölçeklendirmesini** seçin. Sunumunuzda OLE çerçevesi için sabit bir boyut istiyorsanız **hücre aralığı ölçeklendirmesini** seçin.

**Bu çözümler, sunumum bir şablona dayanıyorsa da çalışır mı?**

Evet. Her iki çözüm de şablondan veya sıfırdan oluşturulan sunumlarda çalışır.

**Bu yöntemleri kullanırken OLE çerçevesinin boyutu için bir sınırlama var mı?**

Hayır. Ölçeği uygun şekilde ayarladığınız sürece OLE nesne çerçevesini istediğiniz herhangi bir boyutta yapabilirsiniz.

**PowerPoint’te “EMBEDDED OLE OBJECT” yer tutucu metninden nasıl kaçınabilirim?**

Evet. Hedef Excel hücre aralığının bir anlık görüntüsünü alıp bunu OLE çerçevesinin yer tutucu resmi olarak ayarlarsanız, varsayılan yer tutucu yerine özel bir önizleme resmi görüntülenir.

## **İlgili Makaleler**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/tr/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/tr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)