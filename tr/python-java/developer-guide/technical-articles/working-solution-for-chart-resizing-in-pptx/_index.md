---
title: PPTX'te Grafik Yeniden Boyutlandırma İçin Çalışan Çözüm
type: docs
weight: 40
url: /tr/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafik yeniden boyutlandırma
- Excel grafiği
- OLE nesnesi
- grafiği gömme
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile gömülü Excel OLE nesneleri kullanırken PPTX'te beklenmeyen grafik yeniden boyutlandırmayı düzeltin. Grafiği ve OLE çerçevesi boyutlarının tutarlı kalması için sabit grafik boyutları ayarlayın."
---
## **Arka Plan**

Aspose bileşenlerini kullanan PowerPoint sunumlarında OLE nesnesi olarak gömülü Excel grafikler, ilk etkinleştirmelerinden sonra boyutlarını değiştirebilir. Bu, grafiğin etkinleştirme öncesi ve sonrası görünümünde fark edilebilir bir değişikliğe neden olur. Bu makale, yeniden boyutlandırmanın neden gerçekleştiğini açıklar ve sabit grafik boyutlarını OLE çerçevesiyle eşleştirerek nasıl önlenebileceğini gösterir.

Bu [Excel Grafiklerini Oluşturun ve Sunumlarda OLE Nesneleri Olarak Gömün](/slides/tr/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) makalesinde, Aspose.Cells for Python via Java ile bir Excel grafiği oluşturmayı ve Aspose.Slides for Python via Java kullanarak bir PowerPoint sunumuna gömmeyi açıkladık. [nesne önizleme sorunu](/slides/tr/python-java/object-preview-issue-when-adding-oleobjectframe/) ele almak için, grafik görüntüsünü grafiğin OLE nesne çerçevesine atadık. Çıktı sunumunda, grafik görüntüsünü gösteren OLE nesne çerçevesine çift tıkladığınızda Excel grafiği etkinleşir. Kullanıcılar gömülü Excel çalışma kitabını düzenleyebilir ve ardından etkinleştirilen çalışma kitabının dışına tıklayarak slayta geri dönebilir. Kullanıcı slayta döndüğünde OLE nesne çerçevesinin boyutu değişir ve yeniden boyutlandırma faktörü, OLE nesne çerçevesi ile gömülü Excel çalışma kitabının orijinal boyutlarına bağlı olarak değişir.

## **Yeniden Boyutlandırmanın Nedeni**

Gömülü Excel çalışma kitabının kendine özgü pencere boyutları vardır ve Excel nesne ilk kez etkinleştirildiğinde bu boyutları korumaya çalışır. Slayttaki OLE çerçevesinin ise bağımsız olarak tanımlanmış boyutları bulunur. Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint gömme işlemi sırasında nesnenin oranlarını korumak için boyut üzerinde uzlaşır. Çalışma kitabı penceresi ile OLE çerçevesi arasındaki farklar, nesnenin yeniden boyutlandırılmasına neden olabilir.

## **Çözüm**

Grafik boyutunu slayttaki OLE çerçevesiyle eşleştirin ve grafik boyutlarını çalışma kitabı penceresinden bağımsız tutun. Bu çözüm yeni bir sunumda veya mevcut bir şablonda çalışır.

Örnek, Aspose.Cells for Python via Java ve Aspose.Slides for Python via Java gerektirir. Etkin bir grafik sayfasında basit bir sütun grafik oluşturur ve çalışma kitabını XLS formatında gömer. Hiçbir grafik önizleme resmi atanmaz; grafik, PowerPoint'te OLE nesnesi etkinleştirildiğinde görünür hale gelir.

Bu örnek, sol kenardan 0.5 inç ve üstten 1 inç uzaklıkta konumlandırılmış 9.5 × 4 inçlik bir OLE çerçevesi ile yeni bir sunum oluşturur. Slayt koordinatları ve boyutları nokta cinsindendir (inç başına 72 nokta). Mevcut bir sunum için [Şablon Kullan](#use-a-template) bölümüne bakın.

## **Sabit Bir Grafik Boyutu Ayarlama**

[setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) değerini false yapın, böylece grafik boyutları çalışma kitabı penceresinden bağımsız olur. [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) boyutlarını [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) ve [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height) aracılığıyla ayarlayın, nokta birimlerini inç başına 96 piksel kullanarak piksele dönüştürün: 684 × 288 nokta ölçen bir çerçeve, 912 × 384 piksel ölçen bir grafik ile eşleşir. [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) değerini [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/) içinde CUSTOM değerine ayarlayın. Örnek, çalışma kitabını [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) ile gömer ve 9.5 × 4 inçlik bir OLE çerçevesi ile sunumu kaydeder.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # Slayt koordinatları ve boyutları nokta cinsindendir (inç başına 72 nokta).
        width = 684.0  # 9.5 inç.
        height = 288.0  # 4 inç.

        chart.setSizeWithWindow(False)
        # Noktaları, inç başına 96 piksel kullanarak grafik piksellerine dönüştür.
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **Şablon Kullan**

Mevcut bir sunum için boyutlandırma mantığı aynıdır. Örneği uyarlamak için:

1. Boş bir sunum oluşturmak yerine şablon sunumunu yükleyin.
1. İlk slaytın en az üç şekil içerdiğini kontrol edin, ardından 2. indeksteki şekli yer tutucu olarak kullanın.
1. Sabit değerler 684 ve 288 yerine o şekilden çerçeve genişliği ve yüksekliğini alın. Boyutlandırma hesaplamalarını aynı tutun.
1. Sabit koordinatlar 36 ve 72 yerine yer tutucunun konumuna OLE çerçevesi ekleyin.
1. Sunumu kaydetmeden önce yer tutucuyu kaldırın.

## **SSS**

**Excel grafiğim PowerPoint'te etkinleştirildikten sonra neden boyut değiştiriyor?**

Bu, Excel'in ilk etkinleştirildiğinde orijinal pencere boyutunu geri yüklemeye çalışması, oysa PowerPoint'teki OLE nesne çerçevesinin kendi boyutları olması nedeniyle olur. PowerPoint ve Excel, en boy oranını korumak için boyutu uzlaşır; bu da yeniden boyutlandırmaya neden olabilir.

**Grafik ve OLE çerçevesi boyutlarını nasıl tutarlı tutabilirim?**

Grafik boyutlarını OLE çerçevesiyle eşleşecek şekilde sabit tutun ve çalışma kitabını gömmeden önce özel bir grafik baskı boyutu kullanın. Yukarıdaki örnek gerekli ayarları ve birim dönüşümlerini gösterir.

**Çalışma kitabı pencere boyutunu eşleştirmek yeterli mi?**

Sadece çalışma kitabı pencere boyutunu eşleştirmek, OLE çerçevesinin etkinleştirme sonrası boyutunun değişmesini güvenilir bir şekilde önlemez. Örnekte gösterildiği gibi sabit grafik boyutları kullanın.

**Bu çözüm hem şablon tabanlı hem de yeni sunumlarla çalışır mı?**

Evet. Şablon için yer tutucunun boyut ve konumunu kullanın. Yeni bir sunum için çerçeve boyutlarını ve konumunu doğrudan belirtin.

**Bu örneği diğer elektronik tablo programlarında oluşturulan grafiklerle kullanabilir miyim?**

Örnek, Aspose.Cells ile oluşturulmuş bir Excel çalışma kitabı kullanır. Diğer elektronik tablo programları için etkinleştirme davranışını göstermez.

## **İlgili Bölümler**

- [Excel Grafiklerini Oluşturun ve Sunumlarda OLE Nesneleri Olarak Gömün](/slides/tr/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)