---
title: Excel Grafiklerini Oluştur ve Sunumlara OLE Nesneleri Olarak Yerleştir
type: docs
weight: 50
url: /tr/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel grafik
- grafiği yerleştir
- OLE nesnesi
- PowerPoint
- sunum
- Python
- Python via .NET
- Aspose.Slides
description: "Aspose.Cells for Python via .NET kullanarak bir Excel grafiği oluştur ve çalışma kitabını Aspose.Slides ile bir PowerPoint sunumuna, grafik önizlemesi dahil, yerleştir."
---
## **Genel Bakış**

Bu makale, Aspose.Cells for Python via .NET kullanarak bir Excel sütun grafiği oluşturmayı ve bu çalışma kitabını Aspose.Slides for Python via .NET ile bir PowerPoint sunumuna yerleştirmeyi gösterir. Yerleştirilmiş çalışma kitabı hem kaynak verileri hem de grafiği içerir. Ayrı bir PNG önizlemesi, OLE nesnesi etkinleştirilmeden önce grafiği slaytta gösterir.

Sonuç, yerel bir PowerPoint grafiği değil, yerleştirilmiş bir Excel nesnesidir. OLE aracılığıyla çalışma kitabını düzenlemek, OLE etkinleştirmesini destekleyen bir masaüstü uygulaması ve uyumlu bir Excel kurulumunu gerektirir.

## **Önkoşullar**

`aspose-cells-python` ve `aspose-slides` paketlerini Python ortamınıza kurun. Bu kütüphanelerle sunumu oluşturmak için Microsoft Office gerekli değildir.

Herhangi bir giriş dosyasına gerek yoktur: örnek veri ve grafiği bellek içinde oluşturur, ardından `OutputChart.pptx` dosyasını geçerli çalışma dizinine yazar. Değerlendirme modunun dışındayken her iki ürün için de lisansları uygulayın.

## **Gömmenin Nasıl Çalıştığı**

1. Veri çalışma sayfası ve grafik sayfası içeren bir çalışma kitabı oluşturun.  
1. Çalışma kitabı grafikte açılacak şekilde grafik sayfasını aktif hâle getirin.  
1. Çalışma kitabının OLE görüntüleme aralığını ayarlayın ve grafiği PNG olarak render edin.  
1. Çalışma kitabını bellek içinde XLSX olarak kaydedin ve bu baytları bir slayda yerleştirin.  
1. PNG'yi OLE nesnesinin önizlemesi olarak atayın ve sunumu PPTX olarak kaydedin.

Çalışma kitabının görüntüleme aralığı ile slayttaki çerçeve farklı görevler üstlenir. [set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) sıfır‑tabanlı başlangıç/bitiş satır ve sütun indekslerini alır. [ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) ise üst satır, sol sütun, alt satır ve sağ sütunu alır. Örnek, alt‑sağ sınır olarak satır indeksi 55 ve sütun indeksi 25'i kullanır; bu değerler veri satırı veya sütun sayısını değil, yerleşim tercihlerini gösterir.

Slayt çerçevesi point birimini kullanır. Örnek, çerçeveyi slayt içinde uyarlar ve PNG'nin en‑boy oranını koruyarak ortalar; önizlemeyi slaytı dolduracak şekilde uzatmaktan kaçınır.

## **Grafiği Oluşturma ve Yerleştirme**

Aşağıdaki tam örnek `DataSheet`'i dört satır ve beş sütun değerle doldurur. Her satır bir grafik serisi olur. Çalışma kitabı kaydedilmeden önce `ChartSheet` aktif sayfa olarak seçilir.

Çalışma kitabı, [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) metoduna geçirilen `xlsx` uzantısıyla eşleşecek şekilde açıkça XLSX olarak kaydedilir. PNG, ara bir bitmap dönüşümü olmadan doğrudan akışından yüklenir. [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) aracılığıyla atandığında varsayılan OLE yer tutucusunun yerine geçer.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# Grafik önizlemesini oluştur ve düzenlenebilir çalışma kitabını ayrı olarak serileştir.
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # Önizlemeyi slayt içinde, en‑boy oranını değiştirmeden uyarla.
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Beklenen Sonuç**

`OutputChart.pptx`, yerleştirilmiş bir Excel çalışma kitabı ve bir grafik önizlemesi içeren bir slayt içerir. Çalışma kitabı orijinal verileri ve dört serili bir sütun grafiğini barındırır. Önizleme slayt üzerinde ortalanmış ve orantılarını korur.

![Yerleştirilmiş bir çalışma kitabının önizlemesi olarak gösterilen Excel sütun grafiği](excel-chart-ole-preview.png)

Excel'in yüklü olduğu uyumlu bir masaüstü PowerPoint ortamında, nesneyi çift tıklayarak yerleştirilmiş çalışma kitabını etkinleştirip düzenleyebilirsiniz. Etkinleştirme ve düzenleme, ana uygulamanın OLE desteği ve güvenlik ayarlarına bağlıdır.

## **SSS**

**Neden bir önizleme resmi gerekir?**

Yerleştirilmiş çalışma kitabı ve slayt önizlemesi ayrı içeriklerdir. Slaytın varsayılan "EMBEDDED OLE OBJECT" yer tutucusu yerine grafiği göstermesi için bir grafik resmi sağlayın. Bkz. [OleObjectFrame Eklenirken Nesne Önizleme Sorunu](/slides/tr/python-net/object-preview-issue-when-adding-oleobjectframe/).

**Kod içinde çalışma kitabını değiştirdiğimde önizleme otomatik olarak güncellenir mi?**

Önizlemeyi bir anlık görüntü olarak değerlendirin. Çalışma kitabı verilerini programlı olarak güncellediğinizde, grafik resmini yeniden oluşturun ve önizlemeyi, aynı zamanda yerleştirilmiş çalışma kitabı verisini de değiştirin.

**XLS'i XLSX yerine kullanabilir miyim?**

Evet. Çalışma kitabını XLS formatında kaydedin ve gömülü veri uzantısı olarak `xls` kullanın. Uzantı, gerçek çalışma kitabı formatıyla eşleşmelidir; yalnızca uzantıyı değiştirmek veri formatını dönüştürmez.

**Nesne etkinleştirildikten sonra boyutu neden değişir?**

Ana uygulama, çalışma kitabını etkinleştirdiğinde OLE nesnesinin sunumunu güncelleyebilir. Çalışma kitabının OLE görüntüleme aralığı ve slayt çerçevesi boyutları her ikisi de önemlidir. Bkz. [PowerPoint Sunumlarında OLE Nesnelerini Otomatik Olarak Yeniden Boyutlandırma](/slides/tr/python-net/working-solution-for-worksheet-resizing/).

## **İlgili Bölümler**

- [PowerPoint Sunumlarında OLE Nesnelerini Otomatik Olarak Yeniden Boyutlandırma](/slides/tr/python-net/working-solution-for-worksheet-resizing/)
- [OleObjectFrame Eklenirken Nesne Önizleme Sorunu](/slides/tr/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [OLE Nesnelerini Yönetme](/slides/tr/python-net/manage-ole/)