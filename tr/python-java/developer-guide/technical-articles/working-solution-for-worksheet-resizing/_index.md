---
title: Çalışma Sayfası Yeniden Boyutlandırma İçin Çalışan Çözüm
type: docs
weight: 20
url: /tr/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- önizleme resmi
- görüntü yeniden boyutlandırma
- Excel
- çalışma sayfası
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Sunumlarda Excel çalışma sayfası OLE yeniden boyutlandırmasını düzeltin: nesne çerçevelerini tutarlı tutmak için iki yöntem—çerçeveyi veya sayfayı ölçeklendirin—PPT ve PPTX formatlarında."
---
{{% alert color="info" title="Not" %}}

Excel çalışma sayfalarının Aspose bileşenleri aracılığıyla bir PowerPoint sunumuna OLE nesnesi olarak yerleştirildiğinde, ilk etkinleştirmeden sonra belirtilmemiş bir ölçeğe yeniden boyutlandırıldığı gözlemlenmiştir. Bu davranış, OLE nesnesinin etkinleştirilmeden önceki ve sonraki durumları arasında belirgin bir görsel fark yaratır. Bu sorunu detaylı olarak inceledik ve bu makalede ele alınan bir çözüm sunduk.

{{% /alert %}}

## **Arka Plan**

[Manage OLE](/slides/tr/python-java/manage-ole/) makalesinde, Aspose.Slides for Python via Java kullanarak bir PowerPoint sunumuna OLE çerçevesi eklemeyi açıkladık. [object preview issue](/slides/tr/python-java/object-preview-issue-when-adding-oleobjectframe/) sorununu çözmek için, seçilen çalışma sayfası alanının bir görüntüsünü OLE nesnesi çerçevesine atadık. Çıktı sunumunda, çalışma sayfası görüntüsünü gösteren OLE nesnesi çerçevesine çift tıkladığınızda Excel çalışma kitabı etkinleşir. Son kullanıcılar gerçek Excel çalışma kitabında istedikleri değişiklikleri yapabilir ve etkinleştirilen Excel çalışma kitabının dışına tıklayarak slayta geri dönebilir. Kullanıcı slayta döndüğünde OLE nesnesi çerçevesinin boyutu değişecektir. Yeniden boyutlandırma faktörü, OLE nesnesi çerçevesinin ve gömülü Excel çalışma kitabının boyutuna bağlı olarak değişir.

## **Boyutlandırmanın Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğu için ilk etkinleştirmede orijinal boyutunu korumaya çalışır. Öte yandan OLE nesnesi çerçevesinin de kendi boyutu vardır. Microsoft'a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint gömme sürecinin bir parçası olarak doğru oranları korumasını sağlamak için boyutu müzakere eder. Yeniden boyutlandırma, Excel pencere boyutu ile OLE nesnesi çerçevesinin boyut ve konumu arasındaki farklara dayanarak gerçekleşir.

## **Çözüm**

Yeniden boyutlandırma etkisini önlemek için iki olası çözüm vardır.

- OLE çerçevesinin yüksekliğini ve genişliğini, OLE çerçevesindeki istenen satır ve sütun sayısına göre ölçeklendirin.
- OLE çerçevesi boyutunu sabit tutun ve katılan satır ve sütunların boyutunu seçili OLE çerçevesi boyutuna sığacak şekilde ölçeklendirin.

### **OLE Çerçeve Boyutunu Ölçeklendirme**

Bu yaklaşımla, gömülü Excel çalışma kitabının OLE çerçevesi boyutunu, Excel çalışma sayfasındaki katılan satır ve sütunların kümülatif boyutuna eşit şekilde ayarlamayı öğreneceğiz.

Örneğin bir şablon Excel sayfamız var ve bunu bir OLE çerçevesi olarak sunuma eklemek istiyoruz. Bu senaryoda, OLE nesnesi çerçevesinin boyutu önce çalışma kitabındaki katılan satırların yüksekliği ve sütunların genişliğinin kümülatif toplamına göre hesaplanır. Daha sonra OLE çerçevesinin boyutunu bu hesaplanan değere ayarlarız. PowerPoint’te OLE çerçevesi için kırmızı “EMBEDDED OLE OBJECT” mesajını önlemek amacıyla, çalışma kitabındaki istenen satır ve sütun bölümlerinin bir görüntüsünü yakalar ve bunu OLE çerçevesi resmi olarak ayarlarız.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96

workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Çalışma kitabı PowerPoint'te OLE nesnesi olarak kullanıldığında görüntülenen boyutu ayarla.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # OLE görselinin genişlik ve yüksekliğini point cinsinden al.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # Değiştirilmiş çalışma kitabını kullan.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # OLE görselini sunum kaynaklarına ekle.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # OLE nesne çerçevesini oluştur.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

### **Hücre Aralığı Boyutunu Ölçeklendirme**

Bu yaklaşımla, katılan satırların yüksekliğini ve katılan sütunların genişliğini, özel bir OLE çerçevesi boyutuna uyduracak şekilde ölçeklendirmeyi öğreneceğiz.

Örneğin bir şablon Excel sayfamız var ve bunu bir OLE çerçevesi olarak sunuma eklemek istiyoruz. Bu senaryoda OLE çerçevesinin boyutunu ayarlar ve OLE çerçevesi alanına katılan satır ve sütunların boyutunu ölçeklendiririz. Ardından değişiklikleri uygulamak için çalışma kitabını bir akıma kaydeder ve OLE çerçevesine eklemek üzere bayt dizisine dönüştürürüz. PowerPoint’te OLE çerçevesi için kırmızı “EMBEDDED OLE OBJECT” mesajını önlemek amacıyla, çalışma kitabındaki istenen satır ve sütun bölümlerinin bir görüntüsünü yakalar ve bunu OLE çerçevesi resmi olarak ayarlarız.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpage.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpage.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


def scale_cell_range(cell_range, width, height):
    # Hücre aralığının beklenen genişlik ve yüksekliği point cinsindendir.
    range_width = cell_range.getWidth()
    range_height = cell_range.getHeight()
    cells = cell_range.getWorksheet().getCells()

    for i in range(cell_range.getColumnCount()):
        column_index = cell_range.getFirstColumn() + i
        column_width = cells.getColumnWidth(column_index, False, CellsUnitType.POINT)
        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72.0
        cells.setColumnWidthInch(column_index, width_in_inches)

    for i in range(cell_range.getRowCount()):
        row_index = cell_range.getFirstRow() + i
        row_height = cells.getRowHeight(row_index, False, CellsUnitType.POINT)
        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72.0
        cells.setRowHeightInch(row_index, height_in_inches)


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96
frame_width, frame_height = 400.0, 100.0
workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Çalışma kitabı PowerPoint'te OLE nesnesi olarak kullanıldığında görüntülenen boyutu ayarla.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Hücre aralığını çerçeve boyutuna sığacak şekilde ölçeklendir.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # Değiştirilmiş çalışma kitabını kullan.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # OLE görselini sunum kaynaklarına ekle.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # OLE nesne çerçevesini oluştur.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

## **Sonuç**

{{% alert color="info" title="Not" %}} 

Çalışma sayfası yeniden boyutlandırma sorununu gidermek için iki yaklaşım vardır. Uygun yaklaşımın seçimi, belirli gereksinimlere ve kullanım senaryosuna bağlıdır. Her iki yaklaşım da aynı şekilde çalışır; sunumlar bir şablondan ya da sıfırdan oluşturulmuş olsun fark etmez. Ayrıca bu çözümde OLE nesnesi çerçevesinin boyutu için bir sınırlama yoktur.

{{% /alert %}}

## **SSS**

**Bir gömülü Excel çalışma sayfası PowerPoint’te ilk kez etkinleştirildiğinde neden boyutu değişir?**

Bu, Excel’in etkinleştirildiğinde orijinal pencere boyutunu korumaya çalışması, PowerPoint’te OLE nesnesi çerçevesinin ise kendi boyutlarına sahip olması nedeniyle olur. PowerPoint ve Excel, en-boy oranını korumak için boyutu müzakere eder, bu da yeniden boyutlandırmaya yol açar.

**Bu yeniden boyutlandırma sorunu tamamen engellenebilir mi?**

Evet. OLE çerçevesini Excel hücre aralığı boyutuna uydurarak veya hücre aralığını istenen OLE çerçevesi boyutuna uydurarak istenmeyen yeniden boyutlandırmayı önleyebilirsiniz.

**Hangi ölçeklendirme yöntemi kullanılmalı, OLE çerçeve ölçeklendirme mi yoksa hücre aralığı ölçeklendirme mi?**

Orijinal Excel satır ve sütun boyutlarını korumak istiyorsanız **OLE çerçeve ölçeklendirmesini** seçin. Sunumunuzda OLE çerçevesi için sabit bir boyut istiyorsanız **hücre aralığı ölçeklendirmesini** seçin.

**Bu çözümler, sunum bir şablona dayalıysa da çalışır mı?**

Evet. Her iki çözüm de şablondan oluşturulan ve sıfırdan oluşturulan sunumlarda çalışır.

**Bu yöntemleri kullanırken OLE çerçevesi boyutunda bir sınırlama var mı?**

Hayır. Ölçeği uygun şekilde ayarladığınız sürece OLE nesnesi çerçevesini istediğiniz boyutta yapabilirsiniz.

**PowerPoint’te “EMBEDDED OLE OBJECT” yer tutucu metninden nasıl kaçınılır?**

Evet. Hedef Excel hücre aralığının bir ekran görüntüsünü alıp bunu OLE çerçevesinin yer tutucu resmi olarak ayarlayarak varsayılan yer tutucu metni yerine özel bir ön izleme resmi gösterebilirsiniz.

## **İlgili Makaleler**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/tr/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)