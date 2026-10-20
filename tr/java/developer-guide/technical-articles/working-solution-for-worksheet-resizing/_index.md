---
title: Çalışma Sayfası Yeniden Boyutlandırma İçin Çözüm
type: docs
weight: 20
url: /tr/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- ön izleme resmi
- görüntü yeniden boyutlandırma
- Excel
- çalışma sayfası
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Sunumlarda Excel çalışma sayfası OLE yeniden boyutlandırmasını düzeltin: nesne çerçevelerini tutarlı tutmak için iki yöntem—çerçeveyi veya sayfayı ölçeklendirin—PPT ve PPTX formatları boyunca."
---
{{% alert color="info" title="Not" %}}

Aspose bileşenlerini kullanarak bir PowerPoint sunumunda OLE nesneleri olarak gömülü Excel çalışma sayfaları, ilk etkinleştirilmeden sonra beklenmedik bir şekilde yeniden boyutlandırılabilir. Bu davranış, OLE nesnesinin etkinleştirme öncesi ve sonrası arasında fark edilebilir bir görsel fark yaratır. Bu makale sorunu açıklar ve iki çözüm yolunu tanımlar.

{{% /alert %}}

## **Arka Plan**

[OLE'yi Yönet](/slides/tr/java/manage-ole/) makalesinde, Aspose.Slides for Java kullanarak bir PowerPoint sunumuna OLE çerçevesi eklemenin nasıl yapılacağını açıkladık. [nesne ön izleme sorunu](/slides/tr/java/object-preview-issue-when-adding-oleobjectframe/) ele almak için, OLE nesne çerçevesine seçilen çalışma sayfası alanının bir görüntüsünü atadık. Çıktı sunumunda, çalışma sayfası görüntüsünü gösteren OLE nesne çerçevesine çift tıkladığınızda Excel çalışma kitabı etkinleşir. Son kullanıcılar gerçek Excel çalışma kitabında istedikleri değişiklikleri yapabilir ve ardından etkinleştirilmiş Excel çalışma kitabının dışına tıklayarak slayta geri dönebilir. Kullanıcı slayta döndüğünde OLE nesne çerçevesinin boyutu değişir. Yeniden boyutlandırma faktörü, OLE nesne çerçevesinin ve gömülü Excel çalışma kitabının boyutuna bağlı olarak değişir.

## **Yeniden Boyutlandırmanın Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğundan, ilk etkinleştirildiğinde orijinal boyutunu korumaya çalışır. Öte yandan OLE nesne çerçevesinin kendine ait bir boyutu vardır. Microsoft’a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint gömme sürecinin bir parçası olarak doğru oranları korumasını sağlamak için boyutu müzakere eder. Yeniden boyutlandırma, Excel pencere boyutu ile OLE nesne çerçevesinin boyut ve konumu arasındaki farklara dayanarak gerçekleşir.

## **Çözüm**

Yeniden boyutlandırma etkisini önlemek için iki olası çözüm vardır.

- OLE çerçevesini PowerPoint sunumunda seçilen satır ve sütunların toplam yüksekliği ve genişliği ile eşleyecek şekilde ölçeklendirin.
- OLE çerçevesi boyutunu sabit tutun ve seçilen satır ve sütunları içine sığacak şekilde ölçeklendirin.

### **OLE Çerçeve Boyutunu Ölçeklendirme**

Bu yaklaşım, gömülü Excel çalışma sayfasındaki seçilen satır ve sütunların toplam yüksekliği ve genişliği ile OLE çerçevesi boyutunu eşleştirir.

Örnek, mevcut bir Excel çalışma kitabını yükler ve sıfır‑tabanlı indeksleri kullanarak ilk çalışma sayfasının ilk 10 satırını ve 13 sütununu seçer. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) görüntülenen aralığı tanımlar. Ön izleme 96 DPI’da oluşturulur ve piksel boyutları inç başına 72 puan kullanılarak puana dönüştürülür. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) değiştirilmiş çalışma kitabını bu boyutlarla bir çerçeveye gömer. Ön izleme, kaydedilen sunumda "EMBEDDED OLE OBJECT" yer tutucusunu değiştirmek için [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) aracılığıyla atanır.

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

// OLE görüntüsünün puan cinsinden genişliğini ve yüksekliğini alın.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// We need to use the modified workbook.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE görüntüsünü sunum kaynaklarına ekleyin.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// OLE nesne çerçevesi oluşturun.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

Ön izleme yardımcı programı, seçilen aralığa [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) atar ve kenar boşluklarını, üstbilgileri ve altbilgileri kaldırır. [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) etkinleştirildiğinde, [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) aralığı PNG resmi olarak oluşturur. Yardımcı, PNG resmini içeren yeni bir giriş akışı döndürür; bu akış sunumda kullanılmak üzere başına konumlandırılmıştır.

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

### **Hücre Aralığı Boyutunu Ölçeklendirme**

Bu yaklaşım, seçilen satırların yüksekliğini ve seçilen sütunların genişliğini özel bir OLE çerçevesi boyutuna uyması için ölçeklendirir.

Örnek, mevcut bir Excel çalışma kitabını yükler ve sıfır‑tabanlı indeksleri kullanarak ilk çalışma sayfasının ilk 10 satırını ve 13 sütununu seçer. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) görüntülenen aralığı tanımlar ve aşağıdaki yardımcı program bu aralığı 400 puan genişliğinde ve 100 puan yüksekliğinde bir çerçeveye sığacak şekilde ölçeklendirir. Değiştirilmiş çalışma kitabı bir akıma kaydedildikten sonra, [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) belirtilen boyutta gömülür. 96 DPI’da oluşturulan bir ön izleme, [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) aracılığıyla atanır; böylece kaydedilen sunumda varsayılan yer tutucu yerine seçilen hücreler gösterilir.

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

Ölçekleme yardımcı programı, seçilen aralık için ayrı genişlik ve yükseklik oranları hesaplar; bu sayede sütunların ve satırların göreceli boyutları korunur. Hesaplanan boyutlar puandan inçe dönüştürülür ve ardından [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) ve [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-) ile uygulanır. Seçilen aralığın sıfır olmayan bir genişliği ve yüksekliği olmalıdır.

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

Bu ön izleme yardımcı programı, yeniden boyutlandırılmış aralığı [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) kullanarak oluşturur. [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) bu aralığa sınırlanır, kenar boşlukları, üstbilgiler ve altbilgiler kaldırılır ve PNG akışı başına konumlandırılarak döndürülür.

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io InputStream;

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

{{% alert color="info" title="Not" %}}

Çalışma sayfası yeniden boyutlandırma sorununu gidermek için iki yaklaşım vardır. Gereksinimlerinize ve kullanım senaryonuza en uygun yaklaşımı seçin. Her iki yaklaşım da sunumların şablondan ya da sıfırdan oluşturulması durumunda aynı şekilde çalışır. Ayrıca bu çözümde OLE nesne çerçevesinin boyutu için bir sınırlama yoktur.

{{% /alert %}}

## **Sıkça Sorulan Sorular**

**Yerleştirilen bir Excel çalışma sayfası PowerPoint’te ilk etkinleştirildiğinde neden boyut değiştirir?**

Excel, etkinleştirildiğinde orijinal pencere boyutunu korumaya çalışır; ancak PowerPoint’teki OLE nesne çerçevesinin kendi boyutları vardır. PowerPoint ve Excel, en boy oranını korumak için boyutu müzakere eder ve bu da yeniden boyutlandırmaya yol açar.

**Bu yeniden boyutlandırma sorunu tamamen önlenebilir mi?**

Evet. OLE çerçevesini Excel hücre aralığı boyutuna uydurarak veya hücre aralığını istediğiniz OLE çerçeve boyutuna sığacak şekilde ölçeklendirerek istenmeyen yeniden boyutlandırmayı önleyebilirsiniz.

**Hangi ölçekleme yöntemini kullanmalıyım, OLE çerçeve ölçeklendirme mi yoksa hücre aralığı ölçeklendirme mi?**

Orijinal Excel satır ve sütun boyutlarını korumak istiyorsanız **OLE çerçeve ölçeklendirmesini** seçin. Sunumunuzda OLE çerçevesinin sabit bir boyutu olmasını istiyorsanız **hücre aralığı ölçeklendirmesini** seçin.

**Bu çözümler, sunumum bir şablona dayanıyorsa da çalışır mı?**

Evet. Her iki çözüm de şablondan oluşturulan ve sıfırdan oluşturulan sunumlarda çalışır.

**Bu yöntemleri kullanırken OLE çerçevesinin boyutu için bir sınırlama var mı?**

Hayır. Ölçeği uygun şekilde ayarladığınız sürece OLE nesne çerçevesini istediğiniz herhangi bir boyutta yapabilirsiniz.

**PowerPoint’te "EMBEDDED OLE OBJECT" yer tutucu metninden nasıl kaçınabilirim?**

Evet. Hedef Excel hücre aralığının bir anlık görüntüsünü alıp bunu OLE çerçevesinin yer tutucu resmi olarak ayarlayarak, varsayılan yer tutucu yerine özel bir ön izleme resmi görüntüleyebilirsiniz.

## **İlgili Makaleler**

[Bir Excel Grafiği Oluşturma ve Sunumda OLE Nesnesi Olarak Gömme](/slides/tr/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint Eklentisi Kullanarak OLE Nesnelerini Otomatik Güncelleme](/slides/tr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)