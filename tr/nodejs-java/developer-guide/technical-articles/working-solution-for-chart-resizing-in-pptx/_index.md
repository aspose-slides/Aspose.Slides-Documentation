---
title: PPTX'te Grafik Yeniden Boyutlandırma için Çalışan Çözüm
type: docs
weight: 40
url: /tr/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafik yeniden boyutlandırma
- Excel grafiği
- OLE nesnesi
- grafik gömme
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak gömülü Excel OLE nesneleriyle PPTX'te beklenmeyen grafik yeniden boyutlandırmayı düzeltin. Grafiğin ve OLE çerçevesinin boyutlarının tutarlı kalması için sabit grafik boyutları ayarlayın."
---
## **Genel Bakış**

Aspose bileşenlerini kullanarak PowerPoint sunumlarına OLE nesneleri olarak gömülmüş Excel grafiklerinin ilk etkinleştirilmelerinin ardından boyutu değişebilir. Bu durum, etkinleştirme öncesi ve sonrası grafiğin görünümünde belirgin bir fark yaratabilir. Bu makale, yeniden boyutlandırmanın neden gerçekleştiğini açıklar ve sabit grafik boyutlarını OLE çerçevesine eşleştirerek nasıl önlenebileceğini gösterir.

Bu [Excel Grafiklerini Oluştur ve Sunumlarda OLE Nesneleri Olarak Göm](/slides/tr/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) makalesinde, Aspose.Cells for Node.js via Java kullanarak bir Excel grafiği oluşturmayı ve Aspose.Slides for Node.js via Java kullanarak bir PowerPoint sunumuna gömülmesini açıkladık. [nesne ön izleme sorunu](/slides/tr/nodejs-java/object-preview-issue-when-adding-oleobjectframe/) ele almak için grafiğin görüntüsünü grafiğin OLE nesne çerçevesine atadık. Çıktı sunumunda, grafiğin görüntüsünü gösteren OLE nesne çerçevesine çift tıkladığınızda Excel grafiği etkinleştirilir. Kullanıcılar gömülü Excel çalışma kitabını düzenleyebilir ve ardından etkinleştirilen çalışma kitabının dışına tıklayarak slayta geri dönebilir. Kullanıcı slayta geri döndüğünde OLE nesne çerçevesinin boyutu değişir ve yeniden boyutlandırma faktörü, OLE nesne çerçevesi ile gömülü Excel çalışma kitabının orijinal boyutlarına bağlı olarak değişir.

## **Yeniden Boyutlandırmanın Nedeni**

Gömülü Excel çalışma kitabının kendi pencere boyutları vardır ve Excel nesne ilk etkinleştirildiğinde bu boyutları korumaya çalışır. Slayttaki OLE çerçevesi bağımsız olarak tanımlanmış boyutlara sahiptir. Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint gömme işleminin bir parçası olarak nesnenin oranlarını korumak için boyut üzerinde anlaşır. Çalışma kitabı penceresi ile OLE çerçevesi arasındaki farklar bu nedenle nesnenin yeniden boyutlandırılmasına neden olabilir.

## **Çalışan Çözüm**

Grafik boyutunu slayttaki OLE çerçevesine eşitleyin ve grafik boyutlarını çalışma kitabı penceresinden bağımsız tutun. Bu çözüm yeni bir sunumla veya mevcut bir şablonla çalışır.

Örnek, Aspose.Cells for Node.js via Java ve Aspose.Slides for Node.js via Java paketlerini gerektirir. `aspose.cells`, `aspose.slides.via.java` ve `java` Node.js paketlerini kurun. Her iki Aspose paketi yükleme sırasında Java köprüsünü başlattığı için aynı çalışma dizinini kullanarak aşağıdaki iki CommonJS betiğini ayrı Node.js süreçlerinde çalıştırın. Bu, etkin bir grafik sayfasında basit bir sütun grafiği oluşturur ve çalışma kitabını XLS formatında gömer. Grafik ön izleme resmi atanmaz; grafik, OLE nesnesi PowerPoint'te etkinleştirildiğinde görünür hâle gelir.

Örnek, sol kenardan 0,5 inç, üstten 1 inç uzaklıkta konumlandırılmış 9,5 × 4 inçlik bir OLE çerçevesiyle yeni bir sunum oluşturur. Slayt koordinatları ve boyutları nokta birimindedir (inç başına 72 nokta). Mevcut bir sunum için, [Şablon Kullan](#use-a-template) bölümüne bakın.

## **Sabit Bir Grafik Boyutu Ayarlama**

[setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow) değerini false yapın, böylece grafik boyutları çalışma kitabı penceresinden bağımsız olur. [getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject) boyutlarını [setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth) ve [setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight) aracılığıyla ayarlayın; nokta birimini inç başına 96 piksel kullanarak piksellere dönüştürün: 684 × 288 nokta ölçen bir çerçeve, 912 × 384 piksel ölçen bir grafik ile eşdeğerdir. [setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize) değerini `PrintSizeType`'ın CUSTOM seçeneğine ayarlayın. Örnek, çalışma kitabını [addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) ile gömer ve 9,5 × 4 inçlik bir OLE çerçevesiyle bir sunum kaydeder.

Bu ilk betiği `create-fixed-chart.js` olarak kaydedin. Bu betik, ikinci betikte kullanılan 684 × 288 nokta çerçevesiyle eşleşen, 912 × 384 piksel ölçen bir grafik içeren `chart-fixed-size.xls` dosyasını oluşturur. Girdi çalışma kitabına ihtiyaç yoktur.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // OLE çerçeve boyutlarını nokta biriminde (inç başına 72 nokta) eşle.
    const width = 684; // 9,5 inç.
    const height = 288; // 4 inç.

    chart.setSizeWithWindow(false);
    // Nokta birimlerini inç başına 96 piksel kullanarak grafik piksellerine dönüştür.
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// Tüm eşzamanlı işler tamamlandı; Java köprü sürecini durdur.
process.exit(0);
```

İkinci betiği `embed-fixed-chart.js` olarak kaydedin ve `create-fixed-chart.js`'den sonra çalıştırın. Bu betik, oluşturulan XLS çalışma kitabını okur ve `chart-fixed-size.pptx` dosyasını kaydeder. Java köprüsü, çalışma kitabı verileri için açık bir Java bayt dizisi ve çerçeve koordinatları ile boyutları için Java float değerleri gerektirir. `xls` uzantısı, çalışma kitabının kaydedilmiş formatına uygundur.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // Slayt koordinatları ve boyutları nokta birimindedir (inç başına 72 nokta).
    const width = 684; // 9,5 inç.
    const height = 288; // 4 inç.
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Tüm eşzamanlı işler tamamlandı; Java köprü sürecini durdur.
process.exit(0);
```

## **Şablon Kullan**

Boyutlandırma mantığı mevcut bir sunum için de aynıdır. Örneği uyarlamak için:

1. Boş bir sunum oluşturmak yerine şablon sunumunu yükleyin.
2. İlk slaytın en az üç şekil içerdiğini kontrol edin, ardından 2 indeksteki şekli yer tutucu olarak kullanın.
3. Çerçeve genişliğini ve yüksekliğini sabit 684 ve 288 değerleri yerine o şekilden alın. Bu boyutları çalışma kitabı oluşturma betiğinde aynı şekilde kullanın, boyutlandırma hesaplamalarını değiştirmeyin ve gömmeden önce XLS çalışma kitabını yeniden oluşturun.
4. OLE çerçevesini sabit 36 ve 72 koordinatları yerine yer tutucunun konumuna ekleyin.
5. Sunumu kaydetmeden önce yer tutucuyu kaldırın.

## **SSS**

**PowerPoint'te etkinleştirdikten sonra gömülü Excel grafiğim neden boyut değiştiriyor?**

Bu, Excel'in ilk etkinleştirildiğinde orijinal pencere boyutunu geri yüklemeye çalışması, PowerPoint'teki OLE nesne çerçevesinin ise kendi boyutlarına sahip olması nedeniyle olur. PowerPoint ve Excel, en boy oranını korumak için boyut üzerinde anlaşır; bu da yeniden boyutlandırmaya yol açabilir.

**Grafik ve OLE çerçevesi boyutlarını tutarlı nasıl tutabilirim?**

Grafiğin sabit boyutlarını OLE çerçevesiyle eşleşecek şekilde ayarlayın ve çalışma kitabını gömmeden önce özel bir grafik yazdırma boyutu kullanın. Yukarıdaki örnek gerekli ayarları ve birim dönüşümlerini gösterir.

**Çalışma kitabı pencere boyutunu eşlemek yeterli mi?**

Çalışma kitabı pencere boyutunu eşlemek tek başına OLE çerçevesinin etkinleştirmeden sonra boyut değişmesini güvenilir bir şekilde önlemez. Örnekte gösterildiği gibi sabit grafik boyutları kullanın.

**Bu çözüm şablon tabanlı sunumlar ve yeni sunumlar için de çalışıyor mu?**

Evet. Şablon için, yer tutucunun boyutlarını ve konumunu kullanın. Yeni bir sunum için ise çerçeve boyutlarını ve konumunu doğrudan belirtin.

**Bu örneği diğer tablo programlarında oluşturulan grafiklerle kullanabilir miyim?**

Örnek, Aspose.Cells ile oluşturulan bir Excel çalışma kitabı kullanır. Diğer tablo programları için etkinleştirme davranışını göstermemektedir.

## **İlgili Bölümler**

- [Excel Grafiklerini Oluştur ve Sunumlarda OLE Nesneleri Olarak Göm](/slides/tr/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)