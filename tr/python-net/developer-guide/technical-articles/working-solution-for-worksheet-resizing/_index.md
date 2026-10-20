---
title: Çalışma Sayfası Yeniden Boyutlandırma İçin Çözüm
type: docs
weight: 40
url: /tr/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- önizleme resmi
- görsel yeniden boyutlandırma
- Excel
- çalışma sayfası
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Sunumlarda Excel çalışma sayfası OLE yeniden boyutlandırmasını düzeltin: nesne çerçevelerini tutarlı tutmanın iki yolu—çerçeveyi veya sayfayı ölçeklendirin—PPT ve PPTX formatlarında."
---
{{% alert color="info" title="Note" %}}
Excel çalışma sayfalarının Aspose bileşenleri kullanılarak bir PowerPoint sunumunda OLE nesneleri olarak gömülmesi, ilk etkinleştirmelerinden sonra beklenmedik şekilde yeniden boyutlandırılmasına neden olabilir. Bu davranış, OLE nesnesinin etkinleştirme öncesi ve sonrası arasında fark edilebilir bir görsel fark oluşturur. Bu makale sorunu açıklıyor ve iki çözüm yolunu anlatıyor.
{{% /alert %}} 

## **Arka Plan**

Bu makalede [OLE'yi Yönet](/slides/tr/python-net/manage-ole/) başlıklı bölümde, Aspose.Slides for Python via .NET kullanarak bir PowerPoint sunumuna OLE çerçevesi eklemenin nasıl yapılacağını açıkladık. [nesne önizleme sorunu](/slides/tr/python-net/object-preview-issue-when-adding-oleobjectframe/) sorununu çözmek için, seçilen çalışma sayfası alanının bir resmini OLE nesne çerçevesine atadık. Çıktı sunumunda, çalışma sayfası resmini gösteren OLE nesne çerçevesine çift tıkladığınızda Excel çalışma kitabı etkinleşir. Son kullanıcılar gerçek Excel çalışma kitabında istedikleri değişiklikleri yapabilir ve ardından etkinleştirilen Excel çalışma kitabının dışına tıklayarak slayta geri dönebilir. Kullanıcı slayta döndüğünde OLE nesne çerçevesinin boyutu değişecektir. Yeniden boyutlandırma faktörü, OLE nesne çerçevesinin ve gömülü Excel çalışma kitabının boyutuna bağlı olarak değişir.

## **Yeniden Boyutlandırma Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğundan, ilk etkinleştirmede orijinal boyutunu korumaya çalışır. Öte yandan, OLE nesne çerçevesinin de kendi boyutu vardır. Microsoft'a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint gömme sürecinin bir parçası olarak doğru oranları korumasını sağlamak için boyutu müzakere eder. Yeniden boyutlandırma, Excel pencere boyutu ile OLE nesne çerçevesinin boyut ve konumu arasındaki farklara dayanır.

## **Çözüm**

Yeniden boyutlandırma etkisini önlemek için iki olası çözüm vardır.

- PowerPoint sunumundaki OLE çerçevesini, seçilen satır ve sütunların toplam yüksekliği ve genişliğiyle eşleşecek şekilde ölçeklendirin.
- OLE çerçevesi boyutunu sabit tutun ve seçilen satır ve sütunları içine sığacak şekilde ölçeklendirin.

### **OLE Çerçeve Boyutunu Ölçeklendirme**

Bu yaklaşım, gömülü Excel çalışma sayfasındaki seçilen satır ve sütunların toplam yüksekliği ve genişliğiyle eşleşecek şekilde OLE çerçeve boyutunu ayarlar.

Örnek, mevcut bir Excel çalışma kitabını yükler ve sıfır tabanlı indeksler kullanarak ilk çalışma sayfasının ilk 10 satırını ve 13 sütununu seçer. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) görüntülenen aralığı tanımlar. Önizleme 96 DPI'de işlenir ve piksel boyutları inç başına 72 nokta kullanılarak puana dönüştürülür. [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) değiştirilmiş çalışma kitabını bu boyutlarda bir çerçeveye gömer. Önizleme, kaydedilen sunumdaki "EMBEDDED OLE OBJECT" yer tutucusunu değiştirmek için [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) aracılığıyla atanır.

Önizleme yardımcı programı, seçilen aralığa [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) ayarlar ve kenar boşluklarını, başlıkları ve dipnotları kaldırır. [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/) etkinleştirildiğinde, [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) aralığı PNG görüntüsü olarak işler. Yardımcı program, sunumda kullanılmak üzere döndürmeden önce görüntü akışını yeniden konumlandırır.

```py
import io
import aspose.cells as cells

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

Aşağıdaki tam örnek, yardımcı programları çalışma kitabı gömme ile birleştirir ve sunumu `output.pptx` olarak kaydeder.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

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

    # OLE görüntüsünün genişlik ve yüksekliğini puan cinsinden alın.
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

Bu yaklaşım, seçilen satırların yüksekliğini ve seçilen sütunların genişliğini özel bir OLE çerçeve boyutuyla eşleşecek şekilde ölçeklendirir.

Örnek, mevcut bir Excel çalışma kitabını yükler ve sıfır tabanlı indeksler kullanarak ilk çalışma sayfasının ilk 10 satırını ve 13 sütununu seçer. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) görüntülenen aralığı tanımlar ve aşağıdaki yardımcı program bu aralığı 400 puan genişliğinde ve 100 puan yüksekliğinde bir çerçeveye sığacak şekilde ölçeklendirir. Değiştirilmiş çalışma kitabı bir akışa kaydedildikten sonra, [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) belirtilen boyutta gömer. 96 DPI'de işlenen bir önizleme, [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) aracılığıyla atanır; böylece kaydedilen sunum, varsayılan yer tutucu yerine seçilen hücreleri gösterir.

Ölçekleme yardımcı programı, seçilen aralık için ayrı genişlik ve yükseklik oranları hesaplar, sütunlarının göreli genişliklerini ve satırlarının göreli yüksekliklerini korur. Hesaplanan boyutları, [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) ve [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/) ile uygulamadan önce puandan inçe dönüştürür. Seçilen aralığın genişliği ve yüksekliği sıfır olmamalıdır.

```py
import aspose.cells as cells

# <param name="width">Hücre aralığının puan cinsinden beklenen genişliği.</param>
# <param name="height">Hücre aralığının puan cinsinden beklenen yüksekliği.</param>
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

Bu önizleme yardımcı programı, yeniden boyutlandırılmış aralığı [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) kullanarak işler. [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) bu aralığa sınırlandırılır, kenar boşlukları, başlıklar ve dipnotlar kaldırılır ve başlangıcında konumlandırılmış bir PNG akışı döndürülür.

```py
import io
import aspose.cells as cells

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

Aşağıdaki tam örnek, yardımcı programları çalışma kitabı gömme ile birleştirir ve sunumu `output.pptx` olarak kaydeder.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

# <param name="width">Hücre aralığının puan cinsinden beklenen genişliği.</param>
# <param name="height">Hücre aralığının puan cinsinden beklenen yüksekliği.</param>
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

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # PowerPoint'te çalışma kitabı dosyası OLE nesnesi olarak kullanıldığında görüntülenen boyutu ayarlayın.
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

{{% alert color="info" title="Note" %}}
Çalışma sayfası yeniden boyutlandırma sorununu çözmek için iki yaklaşım vardır. Gereksinimlerinize ve kullanım durumunuza en uygun yaklaşımı seçin. Her iki yaklaşım da, sunumlar bir şablondan veya sıfırdan oluşturulmuş olsun aynı şekilde çalışır. Ayrıca, bu çözümlerde OLE nesne çerçevesinin boyutu için bir sınır yoktur.
{{% /alert %}}

## **SSS**

**Neden gömülü bir Excel çalışma sayfası PowerPoint'te ilk etkinleştirildiğinde boyut değiştirir?**  
Bu, Excel'in etkinleştirildiğinde orijinal pencere boyutunu korumaya çalışması, PowerPoint'teki OLE nesne çerçevesinin ise kendi boyutlarına sahip olması nedeniyle olur. PowerPoint ve Excel, en boy oranını korumak için boyutu müzakere eder; bu da yeniden boyutlandırmaya neden olabilir.

**Bu yeniden boyutlandırma sorunu tamamen önlenebilir mi?**  
Evet. OLE çerçevesini Excel hücre aralığı boyutuna uygun şekilde ölçeklendirerek veya hücre aralığını istenen OLE çerçeve boyutuna sığacak şekilde ölçeklendirerek istenmeyen yeniden boyutlandırmayı önleyebilirsiniz.

**Hangi ölçekleme yöntemini kullanmalıyım, OLE çerçeve ölçeklendirme mi yoksa hücre aralığı ölçeklendirme mi?**  
Orijinal Excel satır ve sütun boyutlarını korumak istiyorsanız **OLE frame scaling** seçin. Sunumunuzda OLE çerçevesi için sabit bir boyut istiyorsanız **cell range scaling** seçin.

**Bu çözümler, sunumum bir şablona dayalıysa çalışır mı?**  
Evet. Her iki çözüm de şablondan veya sıfırdan oluşturulan sunumlarda çalışır.

**Bu yöntemleri kullanırken OLE çerçevesinin boyutu için bir sınırlama var mı?**  
Hayır. Ölçeği uygun şekilde ayarladığınız sürece OLE nesne çerçevesini istediğiniz boyuta getirebilirsiniz.

**"EMBEDDED OLE OBJECT" yer tutucu metnini PowerPoint'te önlemek için bir yol var mı?**  
Evet. Hedef Excel hücre aralığının bir anlık görüntüsünü alıp OLE çerçevesinin yer tutucu resmi olarak ayarlayarak varsayılan yer tutucu yerine özel bir önizleme resmi gösterebilirsiniz.