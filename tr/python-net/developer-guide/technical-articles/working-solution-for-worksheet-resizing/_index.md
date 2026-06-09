---
title: Çalışma Sayfası Yeniden Boyutlandırma İçin Çalışan Çözüm
type: docs
weight: 40
url: /tr/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- önizleme görüntüsü
- görüntü yeniden boyutlandırma
- Excel
- çalışma sayfası
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Sunumlarda Excel çalışma sayfası OLE yeniden boyutlandırmasını düzeltin: nesne çerçevelerini tutarlı tutmanın iki yolu—çerçeveyi veya sayfayı ölçeklendirin—PPT ve PPTX formatları boyunca."
---
{{% alert color="primary" %}} 

Aspose bileşenleri aracılığıyla PowerPoint sunumuna OLE nesneleri olarak gömülen Excel çalışma sayfalarının, ilk etkinleştirmeden sonra tanımlanamayan bir ölçeğe yeniden boyutlandırıldığı gözlemlenmiştir. Bu davranış, OLE nesnesinin etkinleştirmeden önceki ve sonraki durumları arasında sunumda belirgin bir görsel fark yaratır. Bu sorunu ayrıntılı olarak araştırdık ve bu makalede ele alınan bir çözüm sağladık.

{{% /alert %}} 

## **Arka Plan**

Makale [OLE'yi Yönet](/slides/tr/python-net/manage-ole/) içinde, Aspose.Slides for Python via .NET kullanarak bir PowerPoint sunumuna OLE çerçevesi eklemenin nasıl yapılacağını açıkladık. [nesne önizleme sorunu](/slides/tr/python-net/object-preview-issue-when-adding-oleobjectframe/) çözmek için, seçilen çalışma sayfası alanının bir görüntüsünü OLE nesne çerçevesine atadık. Çıktı sunumunda, çalışma sayfası görüntüsünü gösteren OLE nesne çerçevesine çift tıkladığınızda Excel çalışma kitabı etkinleştirilir. Son kullanıcılar gerçek Excel çalışma kitabında istedikleri değişiklikleri yapabilir ve etkinleştirilen Excel çalışma kitabının dışına tıklayarak slayta geri dönebilir. Kullanıcı slayta döndüğünde OLE nesne çerçevesinin boyutu değişecektir. Yeniden boyutlandırma faktörü, OLE nesne çerçevesinin ve gömülü Excel çalışma kitabının boyutuna bağlı olarak değişir.

## **Yeniden Boyutlandırmanın Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğu için ilk etkinleştirmede orijinal boyutunu korumaya çalışır. Öte yandan, OLE nesne çerçevesinin kendi boyutu vardır. Microsoft'a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint gömme işleminin bir parçası olarak doğru oranları korumasını sağlamak için boyut üzerinde anlaşır. Yeniden boyutlandırma, Excel pencere boyutu ile OLE nesne çerçevesinin boyut ve konumu arasındaki farklara dayanarak gerçekleşir.

## **Çözüm**

Yeniden boyutlandırma etkisini önlemek için iki olası çözüm vardır.

- OLE çerçevesinin yüksekliği ve genişliğini, OLE çerçevesinde istediğiniz satır ve sütun sayısına uygun olacak şekilde PowerPoint sunumunda ölçeklendirin.
- OLE çerçevesi boyutunu sabit tutun ve katılan satır ve sütunların boyutunu seçilen OLE çerçevesi boyutuna sığacak şekilde ölçeklendirin.

### **OLE Çerçeve Boyutunu Ölçeklendirme**

Bu yaklaşımda, gömülü Excel çalışma kitabının OLE çerçeve boyutunu, Excel çalışma sayfasındaki katılan satır ve sütunların toplam boyutuna eşitlemeyi öğreneceğiz.

Bir şablon Excel sayfamız olduğunu ve bunu bir OLE çerçevesi olarak bir sunuma eklemek istediğimizi varsayalım. Bu senaryoda, OLE nesne çerçevesinin boyutu önce çalışma kitabındaki katılan satırların yüksekliği ve sütunların genişliği toplamına göre hesaplanacaktır. Daha sonra, OLE çerçevesinin boyutunu bu hesaplanmış değere ayarlayacağız. PowerPoint'teki OLE çerçevesi için kırmızı "EMBEDDED OLE OBJECT" mesajını önlemek amacıyla, çalışma kitabındaki istenen satır ve sütun bölümlerinin bir görüntüsünü yakalayıp OLE çerçeve görüntüsü olarak ayarlayacağız.

```py
def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Çalışma kitabı dosyası PowerPoint'te OLE nesnesi olarak kullanıldığında görüntülenen boyutu ayarlayın.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # OLE görüntüsünün genişliğini ve yüksekliğini nokta biriminde alın.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # Değiştirilmiş çalışma kitabını kullanmamız gerekiyor.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # OLE görüntüsünü sunum kaynaklarına ekleyin.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # OLE nesne çerçevesini oluşturun.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Hücre Aralığı Boyutunu Ölçeklendirme**

Bu yaklaşımda, katılan satırların yüksekliğini ve katılan sütunların genişliğini, özel bir OLE çerçeve boyutuna eşitlemek için nasıl ölçeklendireceğimizi öğreneceğiz.

Bir şablon Excel sayfamız olduğunu ve bunu bir OLE çerçevesi olarak bir sunuma eklemek istediğimizi varsayalım. Bu senaryoda, OLE çerçevesinin boyutunu ayarlayacak ve OLE çerçevesi alanına katılan satır ve sütunların boyutunu ölçeklendireceğiz. Daha sonra, değişiklikleri uygulamak için çalışma kitabını bir akışa kaydedip OLE çerçevesine eklemek üzere bir bayt dizisine dönüştüreceğiz. PowerPoint'teki OLE çerçevesi için kırmızı "EMBEDDED OLE OBJECT" mesajını önlemek amacıyla, çalışma kitabındaki istenen satır ve sütun bölümlerinin bir görüntüsünü yakalayıp OLE çerçeve görüntüsü olarak ayarlayacağız.

```py
# <param name="width">Hücre aralığının nokta cinsinden beklenen genişliği.</param>
# <param name="height">Hücre aralığının nokta cinsinden beklenen yüksekliği.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)
```

```py
def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Çalışma kitabı dosyası PowerPoint'te OLE nesnesi olarak kullanıldığında görüntülenen boyutu ayarlayın.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Hücre aralığını çerçeve boyutuna sığacak şekilde ölçeklendirin.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # Değiştirilmiş çalışma kitabını kullanmamız gerekiyor.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # OLE görüntüsünü sunum kaynaklarına ekleyin.
            ole_image = presentation.images.add_image(image_stream)

            # OLE nesne çerçevesini oluşturun.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Sonuç**

{{% alert color="primary" %}}

Çalışma sayfası yeniden boyutlandırma sorununu çözmek için iki yaklaşım vardır. Uygun yaklaşımın seçimi, belirli gereksinimlere ve kullanım durumuna bağlıdır. Her iki yaklaşım da aynı şekilde çalışır; sunumlar bir şablondan veya sıfırdan oluşturulmuş olsun fark etmez. Ayrıca, bu çözümde OLE nesne çerçevesinin boyutu için bir sınırlama yoktur.

{{% /alert %}}