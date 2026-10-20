---
title: PPTX'te Grafik Yeniden Boyutlandırma için Çalışan Çözüm
type: docs
weight: 60
url: /tr/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafik yeniden boyutlandırma
- Excel grafik
- OLE nesnesi
- grafik gömme
- PowerPoint
- sunum
- Python via .NET
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile gömülü Excel OLE nesneleri kullanırken PPTX'te beklenmeyen grafik yeniden boyutlandırmayı düzeltin. Grafik ve OLE çerçeve boyutlarının tutarlı kalması için sabit grafik boyutları ayarlayın."
---
## **Genel Bakış**

Aspose bileşenleri kullanılarak PowerPoint sunumlarına OLE nesneleri olarak gömülen Excel grafiklerinin ilk etkinleştirilmelerinden sonra boyutu değişebilir. Bu, grafiğin etkinleştirme öncesi ve sonrası görünümünde fark yaratabilir. Bu makale, yeniden boyutlandırmanın neden gerçekleştiğini açıklar ve sabit grafik boyutlarını OLE çerçevesiyle eşleştirerek nasıl önleneceğini gösterir.

In [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/tr/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), we explained how to create an Excel chart with Aspose.Cells for Python via .NET and embed it in a PowerPoint presentation using Aspose.Slides for Python via .NET. To address the [object preview issue](/slides/tr/python-net/object-preview-issue-when-adding-oleobjectframe/), we assigned the chart image to the chart’s OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the chart image, the Excel chart is activated. Users can edit the embedded Excel workbook and then return to the slide by clicking outside the activated workbook. The size of the OLE object frame changes when the user returns to the slide, and the resizing factor varies depending on the original sizes of both the OLE object frame and the embedded Excel workbook.

Bu makalede, Aspose.Cells for Python via .NET ile bir Excel grafiği oluşturup ve Aspose.Slides for Python via .NET kullanarak bir PowerPoint sunumuna nasıl gömeceğimizi açıkladık. [object preview issue] bağlantısına değinmek için, grafik görselini grafiğin OLE nesne çerçevesine atadık. Çıktı sunumunda, grafik görselini gösteren OLE nesne çerçevesine çift tıkladığınızda Excel grafiği etkinleşir. Kullanıcılar gömülü Excel çalışma kitabını düzenleyebilir ve etkinleştirilmiş çalışma kitabının dışına tıklayarak slayta geri dönebilir. Kullanıcı slayta döndüğünde OLE nesne çerçevesinin boyutu değişir ve yeniden boyutlandırma faktörü, OLE nesne çerçevesi ile gömülü Excel çalışma kitabının orijinal boyutlarına bağlı olarak değişir.

## **Yeniden Boyutlandırma Nedeni**

Gömülü Excel çalışma kitabının kendine özgü pencere boyutları vardır ve Excel nesne ilk etkinleştirildiğinde bu boyutları korumaya çalışır. Slayttaki OLE çerçevesi bağımsız olarak tanımlanmış boyutlara sahiptir. Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint nesnenin boyutunu, gömme işleminin bir parçası olarak oranlarını koruyacak şekilde müzakere eder. Çalışma kitabı penceresi ile OLE çerçevesi arasındaki farklar nesnenin yeniden boyutlandırılmasına yol açabilir.

## **Çözüm**

Grafik boyutunu slayttaki OLE çerçevesiyle eşleştirin ve grafik boyutlarını çalışma kitabı penceresinden bağımsız tutun. Bu çözüm yeni bir sunumda veya mevcut bir şablonda çalışır.

Örnek, Aspose.Cells for Python via .NET ve Aspose.Slides for Python via .NET gerektirir. Aktif bir grafik sayfasında basit bir sütun grafiği oluşturur ve çalışma kitabını XLS formatında gömer. Grafik önizleme resmi atanmaz; grafik, PowerPoint'te OLE nesnesi etkinleştirildiğinde görünür.

Örnek, sol kenardan 0.5 inç, üstten 1 inç uzaklıkta konumlandırılmış 9.5 × 4 inçlik bir OLE çerçevesiyle yeni bir sunum oluşturur. Slayt koordinatları ve boyutları nokta biriminde (inç başına 72 nokta) verilir. Mevcut bir sunum için, [Şablon Kullan](#use-a-template) bölümüne bakın.

## **Sabit Bir Grafik Boyutu Belirleme**

Grafik boyutlarının çalışma kitabı penceresinden bağımsız olması için [size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/) özelliğini false olarak ayarlayın. [chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/) boyutlarını [width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/) ve [height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/) aracılığıyla ayarlayın; noktaları inç başına 96 piksel kullanarak piksellere dönüştürün: 684 × 288 nokta ölçen bir çerçeve, 912 × 384 piksel ölçen bir grafik ile eşleşir. [print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/) özelliğini [PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/) sınıfının CUSTOM değeri olarak ayarlayın. Örnek, [add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/) ile çalışma kitabını gömer ve 9.5 × 4 inçlik bir OLE çerçevesiyle sunumu kaydeder.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Slayt koordinatları ve boyutları nokta cinsindendir (inç başına 72 nokta).
    width = 684.0  # 9.5 inç.
    height = 288.0  # 4 inç.

    chart.size_with_window = False
    # Nokta birimini, inç başına 96 piksel kullanarak grafik piksellerine dönüştürün.
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Şablon Kullan**

Mevcut bir sunum için boyutlandırma mantığı aynıdır. Örneği uyarlamak için:

1. Şablon sunumu yükleyin, boş bir sunum oluşturmak yerine.
2. İlk slaytın en az üç şekil içerdiğini kontrol edin ve ardından 2. indisteki şekli yer tutucu olarak kullanın.
3. Çerçeve genişliğini ve yüksekliğini, 684 ve 288 sabit değerlerini kullanmak yerine bu şekilden alın. Boyutlandırma hesaplamalarını aynı bırakın.
4. OLE çerçevesini, sabit koordinatlar 36 ve 72 yerine yer tutucunun konumuna ekleyin.
5. Sunumu kaydetmeden önce yer tutucuyu kaldırın.

## **SSS**

**PowerPoint'te gömülü Excel grafiğim etkinleştirildikten sonra boyutu neden değişiyor?**

Bu, Excel'in ilk etkinleştirildiğinde orijinal pencere boyutunu geri yüklemeye çalışması, ancak PowerPoint'teki OLE nesne çerçevesinin kendi boyutlarına sahip olması nedeniyle olur. PowerPoint ve Excel, en‑boy oranını korumak için boyutu müzakere eder; bu da yeniden boyutlandırmaya yol açabilir.

**Grafik ve OLE çerçevesi boyutlarını nasıl tutarlı hale getirebilirim?**

OLE çerçevesiyle eşleşen sabit grafik boyutları belirleyin ve çalışma kitabını gömmeden önce özel bir grafik yazdırma boyutu kullanın. Yukarıdaki örnek gerekli ayarları ve birim dönüşümlerini gösterir.

**Çalışma kitabı pencere boyutunu eşleştirmek yeterli mi?**

Sadece çalışma kitabı pencere boyutunu eşleştirmek, OLE çerçevesinin etkinleştirme sonrası boyutunun değişmesini güvenilir şekilde önlemez. Örnekte gösterildiği gibi sabit grafik boyutları kullanın.

**Bu çözüm, şablon tabanlı sunumlar ve yeni sunumlar için de çalışıyor mu?**

Evet. Şablon için yer tutucunun boyutlarını ve konumunu kullanın. Yeni bir sunum için ise çerçeve boyutlarını ve konumunu doğrudan belirleyin.

**Bu örneği diğer tablo programlarıyla oluşturulan grafiklerle kullanabilir miyim?**

Örnek, Aspose.Cells ile oluşturulan bir Excel çalışma kitabını kullanır. Diğer tablo programları için etkinleştirme davranışını göstermez.

## **İlgili Bölümler**

- [Excel Grafiklerini Oluşturun ve Sunumlarda OLE Nesneleri Olarak Gömün](/slides/tr/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [OLE Nesnelerini PowerPoint Eklentisiyle Otomatik Güncelle](/slides/tr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)