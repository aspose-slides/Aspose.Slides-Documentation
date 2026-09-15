---
title: Excel Grafiklerini Oluşturun ve Sunumlara OLE Nesneleri Olarak Ekleyin
type: docs
weight: 30
url: /tr/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel grafiği
- grafik ekle
- OLE nesnesi
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Python ile Excel grafiklerini oluşturun ve PowerPoint ve OpenDocument sunumlarına OLE nesneleri olarak ekleyin. Adım adım kılavuz ve kod örnekleri."
---
## **Arka Plan**

PowerPoint'te, verileri grafiksel olarak göstermek için düzenlenebilir grafikler kullanmak yaygın bir uygulamadır. Aspose, Aspose.Cells for Python via Java ile Excel grafikleri oluşturmayı destekler ve bu grafikler daha sonra Aspose.Slides for Python via Java aracılığıyla PowerPoint slaytlarına OLE nesneleri olarak yerleştirilebilir. Bu makale gerekli adımları kapsar ve Aspose.Cells ve Aspose.Slides kullanarak bir Excel grafiği oluşturmak ve bunu PowerPoint sunumunda OLE nesnesi olarak yerleştirmek için bir Python kod örneği sunar.

## **Gerekli Adımlar**

PowerPoint slaytına bir Excel grafiği OLE nesnesi olarak oluşturmak ve yerleştirmek için aşağıdaki adımlar sırasını izlemek gerekir:

1. Aspose.Cells kullanarak bir Excel grafiği oluşturun.
2. Aspose.Cells kullanarak Excel grafiğinin OLE boyutunu ayarlayın.
3. Aspose.Cells ile Excel grafiğinin bir görüntüsünü alın.
4. Aspose.Slides kullanarak Excel grafiğini bir PPTX sunumunda OLE nesnesi olarak yerleştirin.
5. Adım 3'te elde edilen görüntüyle "EMBEDDED OLE OBJECT" görüntüsünü değiştirerek [nesne önizleme sorunu](/slides/tr/python-java/object-preview-issue-when-adding-oleobjectframe/) sorununu çözün.
6. Sunumu PPTX formatında diske kaydedin.

## **Gerekli Adımların Uygulanması**

Yukarıdaki adımların Python uygulaması aşağıdaki gibidir:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def add_excel_chart_in_workbook(workbook, chart_rows, chart_columns):
    # Hücre adlarından oluşan bir dizi.
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # Hücre verilerinden oluşan bir dizi.
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # Hücreleri veriyle doldurmak için yeni bir çalışma sayfası ekleyin.
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # Veri sayfasını veriyle doldurun.
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # Bir grafik sayfası ekleyin.
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # Veri sayfasındaki veri serileriyle grafik sayfasına bir grafik ekleyin.
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # Grafik sayfasını etkin sayfa olarak ayarlayın.
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # Çalışma kitabını gömülü OLE verisi olarak tanımlayın.
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# Bir çalışma kitabı oluşturun.
workbook = Workbook()

# Bir Excel grafiği ekleyin.
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# Grafiğin OLE boyutunu ayarlayın.
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# Grafik görüntüsünü alın ve bir akışa kaydedin.
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# Çalışma kitabını bir akışa kaydedin.
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# Bir sunum oluşturun.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Çalışma kitabını bir slayta ekleyin.
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # Sunumu diske kaydedin.
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Yukarıdaki yöntemle oluşturulan sunum, OLE nesne çerçevesine çift tıklanarak etkinleştirilebilen bir OLE nesnesi olarak Excel grafiğini içerecektir.

## **Sonuç**

Aspose.Cells for Python via Java ile Aspose.Slides for Python via Java'ı birlikte kullanarak, Aspose.Cells tarafından desteklenen herhangi bir Excel grafiğini oluşturabilir ve bu grafiği bir PowerPoint slaytına OLE nesnesi olarak yerleştirebiliriz. Excel grafiğinin OLE boyutu da tanımlanabilir. Son kullanıcılar Excel grafiğini diğer OLE nesneleri gibi düzenleyebilir.

## **İlgili Bölümler**

- [PPTX'te Grafik Yeniden Boyutlandırma için Çalışan Çözüm](/slides/tr/python-java/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame Eklerken Nesne Önizleme Sorunu](/slides/tr/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **SSS**

**Excel grafiğini oluşturmak ve yerleştirmek için hangi kütüphaneler kullanılır?**

Aspose.Cells for Python via Java Excel grafiğini oluşturur ve Aspose.Slides for Python via Java bunu bir PowerPoint slaytına OLE nesnesi olarak yerleştirir.

**Kullanıcılar yerleştirilmiş Excel grafiğini nasıl düzenleyebilir?**

Kullanıcılar grafiği etkinleştirmek ve diğer OLE nesneleri gibi düzenlemek için OLE nesne çerçevesine çift tıklayabilir.

**Varsayılan OLE nesne önizlemesi nasıl değiştirilir?**

Örnek, Excel grafiğinin bir görüntüsünü Aspose.Cells ile alır ve bunu "EMBEDDED OLE OBJECT" görüntüsüyle değiştirmek için kullanır.