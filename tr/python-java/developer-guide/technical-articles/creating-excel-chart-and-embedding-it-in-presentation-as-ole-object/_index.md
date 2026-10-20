---
title: Excel Grafiklerini Oluşturun ve Sunumlara OLE Nesnesi Olarak Yerleştirin
type: docs
weight: 30
url: /tr/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel grafiği
- grafik gömme
- OLE nesnesi
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Cells for Python via Java ile bir Excel grafiği oluşturun ve Aspose.Slides ile bir PowerPoint sunumuna çalışma kitabını, grafik önizlemesi dahil olmak üzere, yerleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Cells for Python via Java kullanarak bir Excel sütun grafiği oluşturmayı ve bu çalışma kitabını Aspose.Slides for Python via Java ile bir PowerPoint sunumuna yerleştirmeyi gösterir. Yerleştirilen çalışma kitabı hem kaynak verileri hem de grafiği içerir. Ayrı bir PNG önizlemesi, OLE nesnesi etkinleştirilmeden önce slaytta grafiği gösterir.

Sonuç, yerel bir PowerPoint grafiği değil, yerleştirilmiş bir Excel nesnesidir. OLE aracılığıyla çalışma kitabını düzenlemek, OLE etkinleştirmesini destekleyen bir masaüstü uygulaması ve uyumlu bir Excel kurulumunu gerektirir.

## **Ön Koşullar**

`aspose-cells` ve `aspose-slides-java` Python paketlerini ve uyumlu bir Java çalışma zamanını kurun. JVM'i başlatmadan önce her iki paketi de içe aktarın, böylece Java kütüphaneleri JPype tarafından kullanılabilir. Microsoft Office, bu kütüphanelerle sunumu oluşturmak için gerekli değildir.

Hiçbir girdi dosyasına gerek yoktur: örnek, verileri ve grafiği bellekte oluşturur, ardından `OutputChart.pptx` dosyasını geçerli çalışma dizinine yazar. Değerlendirme modunun dışında çalıştırırken her iki ürün için de lisansları uygulayın.

## **Yerleştirmenin Nasıl Çalıştığı**

1. Veri çalışma sayfası ve bir grafik sayfası içeren bir çalışma kitabı oluşturun.  
1. Çalışma kitabının grafik üzerinde açılması için grafik sayfasını etkinleştirin.  
1. Çalışma kitabının OLE görüntüleme aralığını ayarlayın ve grafiği PNG olarak render edin.  
1. Çalışma kitabını bellek içinde XLSX olarak kaydedin ve bu baytları bir slayta yerleştirin.  
1. PNG'yi OLE nesnesinin önizlemesi olarak atayın ve sunumu PPTX olarak kaydedin.

Çalışma kitabı görüntüleme aralığı ile slayttaki çerçeve farklı görevler üstlenir. [setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) sıfır tabanlı başlangıç/bitiş satır ve sütun dizinlerini alır. [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) ise üst satır, sol sütun, alt satır ve sağ sütunu alır. Örnek, satır indeksi 55 ve sütun indeksi 25'i sağ‑alt sınır olarak kullanır; bu değerler düzen tercihidir, veri satır veya sütun sayısı değildir.

Slayt çerçevesi puan birimini kullanır. Örnek, çerçeveyi slayt içinde sığdırır ve PNG'nin en‑boy oranını koruyarak ortalar; önizlemeyi slaytı dolduracak şekilde uzatmaktan kaçınır.

## **Grafiği Oluşturma ve Yerleştirme**

Aşağıdaki tam örnek, `DataSheet`'i dört satır ve beş sütun değerle doldurur. Her satır bir grafik serisi olur. Çalışma kitabı kaydedilmeden önce `ChartSheet` aktif sayfa olarak seçilir.

Çalışma kitabı, [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/) metoduna geçirilen `xlsx` uzantısıyla eşleşecek şekilde açıkça XLSX olarak kaydedilir. Java bayt‑dizisi akışları, çalışma kitabını ve görüntüyü bellekte tutar ve Java API'lerinin gerektirdiği bayt dizilerini sağlar. PNG, ara bir bitmap dönüşümü olmadan doğrudan baytlarından yüklenir. [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) aracılığıyla atama, varsayılan OLE yer tutucusunu değiştirir.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # Grafik önizlemesini oluştur ve düzenlenebilir çalışma kitabını ayrı olarak serileştir.
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # Önizlemeyi slayt içinde, en‑boy oranını değiştirmeden sığdır.
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **Beklenen Sonuç**

`OutputChart.pptx`, yerleştirilmiş bir Excel çalışma kitabı ve bir grafik önizlemesi içeren bir slayt içerir. Çalışma kitabı, orijinal verileri ve dört serili bir sütun grafiğini barındırır. Önizleme, slayt üzerinde ortalanmış olup oranlarını korur.

![Yerleştirilmiş bir çalışma kitabının önizlemesi olarak gösterilen Excel sütun grafiği](excel-chart-ole-preview.png)

Excel'in kurulu olduğu uyumlu bir masaüstü PowerPoint ortamında, nesneyi çift tıklayarak yerleştirilmiş çalışma kitabını etkinleştirip düzenleyebilirsiniz. Etkinleştirme ve düzenleme, ana uygulamanın OLE desteği ve güvenlik ayarlarına bağlıdır.

## **SSS**

**Neden bir önizleme resmi gerekir?**

Yerleştirilmiş çalışma kitabı ve slayt önizlemesi ayrı içeriklerdir. Bir grafik resmi sağlayarak slaytın varsayılan "EMBEDDED OLE OBJECT" yer tutucusu yerine grafiği göstermesini sağlayın. Bkz. [OleObjectFrame Eklerken Nesne Önizleme Sorunu](/slides/tr/python-java/object-preview-issue-when-adding-oleobjectframe/).

**Kod içinde çalışma kitabını değiştirdiğimde önizleme otomatik olarak güncellenir mi?**

Önizlemeyi bir anlık görüntü olarak değerlendirin. Çalışma kitabı verilerini program aracılığıyla güncellediğinizde, grafik görüntüsünü yeniden oluşturun ve önizlemeyi ve yerleştirilmiş çalışma kitabı verilerini değiştirin.

**XLSX yerine XLS kullanabilir miyim?**

Evet. Çalışma kitabını XLS formatında kaydedin ve yerleştirilmiş veri uzantısı olarak `xls` kullanın. Uzantı, gerçek çalışma kitabı formatıyla eşleşmelidir; yalnızca uzantıyı değiştirmek veriyi dönüştürmez.

**Nesne etkinleştirildikten sonra boyutu neden değişebilir?**

Ana uygulama, çalışma kitabını etkinleştirdiğinde OLE nesnesinin sunumunu güncelleyebilir. Çalışma kitabının OLE görüntüleme aralığı ve slayt çerçevesi boyutları her ikisi de önemlidir. Bkz. [PPTX'te Grafik Yeniden Boyutlandırma için Çalışan Çözüm](/slides/tr/python-java/working-solution-for-chart-resizing-in-pptx/).

## **İlgili Bölümler**

- [PPTX'te Grafik Yeniden Boyutlandırma için Çalışan Çözüm](/slides/tr/python-java/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame Eklerken Nesne Önizleme Sorunu](/slides/tr/python-java/object-preview-issue-when-adding-oleobjectframe/)