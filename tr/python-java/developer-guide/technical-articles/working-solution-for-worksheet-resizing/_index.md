---
title: Çalışma Sayfası Yeniden Boyutlandırması İçin Çözüm
type: docs
weight: 20
url: /tr/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- önizleme resmi
- görsel yeniden boyutlandırma
- Excel
- çalışma sayfası
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Sunumlarda Excel çalışma sayfası OLE yeniden boyutlandırmasını düzeltin: nesne çerçevelerini tutarlı tutmanın iki yöntemi—çerçeveyi ya da sayfayı ölçeklendirin—PPT ve PPTX formatları arasında."
---
{{% alert color="info" title="Note" %}}

Excel çalışma sayfaları, Aspose bileşenleri kullanılarak bir PowerPoint sunumunda OLE nesneleri olarak gömüldüğünde, ilk etkinleştirilmelerinden sonra beklenmedik şekilde yeniden boyutlandırılabilir. Bu davranış, OLE nesnesinin etkinleştirilmeden önceki ve sonraki hallerinde belirgin bir görsel fark yaratır. Bu makale sorunu açıklar ve iki çözüm yolunu anlatır.

{{% /alert %}}

## **Arka Plan**

[OLE'yi Yönet](/slides/tr/python-java/manage-ole/) makalesinde, Aspose.Slides for Python via Java kullanarak bir PowerPoint sunumuna OLE çerçevesi eklemenin yollarını açıkladık. [nesne önizleme sorunu](/slides/tr/python-java/object-preview-issue-when-adding-oleobjectframe/) sorununu ele almak için, OLE nesne çerçevesine seçilen çalışma sayfası alanının bir resmini atadık. Çıktı sunumunda, çalışma sayfası görüntüsünü gösteren OLE nesne çerçevesine çift tıkladığınızda Excel çalışma kitabı etkinleşir. Son kullanıcılar gerçek Excel çalışma kitabında istedikleri değişiklikleri yapabilir ve etkinleştirilen Excel çalışma kitabının dışına tıklayarak slayta geri dönebilir. Kullanıcı slayta geri döndüğünde OLE nesne çerçevesinin boyutu değişecektir. Yeniden boyutlandırma faktörü, OLE nesne çerçevesi ve gömülü Excel çalışma kitabının boyutuna bağlı olarak değişir.

## **Yeniden Boyutlandırmanın Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğundan, ilk etkinleştirildiğinde orijinal boyutunu korumaya çalışır. Öte yandan OLE nesne çerçevesinin kendi boyutu vardır. Microsoft'a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint gömme sürecinin bir parçası olarak doğru oranların korunmasını sağlamak için boyutu müzakere eder. Yeniden boyutlandırma, Excel pencere boyutu ile OLE nesne çerçevesinin boyut ve konum farklarına göre gerçekleşir.

## **Çözüm**

Yeniden boyutlandırma etkisini önlemek için iki olası çözüm vardır.

- OLE çerçevesini PowerPoint sunumunda seçilen satır ve sütunların toplam yüksekliği ve genişliğiyle eşleşecek şekilde ölçeklendirin.
- OLE çerçevesi boyutunu sabit tutun ve seçilen satır ve sütunları içine sığacak şekilde ölçeklendirin.

### **OLE Çerçeve Boyutunu Ölçeklendirme**

Bu yaklaşım, gömülü Excel çalışma sayfasındaki seçilen satır ve sütunların toplam yüksekliği ve genişliğiyle OLE çerçevesi boyutunu eşleştirir.

Örnek, mevcut bir Excel çalışma kitabını yükler ve sıfır tabanlı dizinler kullanarak ilk çalışma sayfasının ilk 10 satırını ve 13 sütununu seçer. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) görüntülenen aralığı tanımlar. Önizleme 96 DPI'da render edilir ve piksel boyutları inç başına 72 nokta kullanılarak puana dönüştürülür. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) değiştirilmiş çalışma kitabını bu boyutlardaki bir çerçeve içinde gömer. Önizleme, kaydedilen sunumdaki "EMBEDDED OLE OBJECT" yer tutucusunu değiştirmek için [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) aracılığıyla atanır.

Önizleme yardımcı programı, [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) özelliğini seçili aralığa ayarlar ve kenar boşluklarını, üstbilgileri ve altbilgileri kaldırır. [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea) etkinleştirildiğinde, [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) aralığı PNG görüntüsü olarak render eder. Yardımcı, PNG görüntüsünü içeren yeni bir giriş akışı döndürür; bu akış sunumda kullanılmak üzere başından konumlandırılır.

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

    # Çalışma kitabı PowerPoint'te OLE nesnesi olarak kullanıldığında görüntülenen boyutu ayarlayın.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # OLE görüntüsünün genişlik ve yüksekliğini puan cinsinden alın.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # Değiştirilmiş çalışma kitabını kullanın.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # OLE görüntüsünü sunum kaynaklarına ekleyin.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # OLE nesne çerçevesini oluşturun.
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

Bu yaklaşım, seçilen satırların yüksekliklerini ve seçilen sütunların genişliklerini özel bir OLE çerçevesi boyutuna uyması için ölçeklendirir.

Örnek, mevcut bir Excel çalışma kitabını yükler ve sıfır tabanlı dizinler kullanarak ilk çalışma sayfasının ilk 10 satırını ve 13 sütununu seçer. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) görüntülenen aralığı tanımlar ve scale_cell_range yardımcı programı bu aralığı 400 puan genişliğinde ve 100 puan yüksekliğinde bir çerçeveye sığacak şekilde ölçeklendirir. Değiştirilmiş çalışma kitabı bir akıma kaydedildikten sonra, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) belirtilen boyutta gömülür. 96 DPI'da render edilen bir önizleme, [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) aracılığıyla atanır; böylece kaydedilen sunum, varsayılan yer tutucu yerine seçili hücreleri gösterir.

Ölçekleme yardımcı programı, seçili aralık için ayrı genişlik ve yükseklik oranları hesaplar; bu, sütunların göreceli genişliklerini ve satırların göreceli yüksekliklerini korur. Hesaplanan boyutları puandan inçe çevirir ve [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) ve [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch) ile uygular. Seçili aralığın sıfır olmayan bir genişliği ve yüksekliği olmalıdır.

Bu önizleme yardımcı programı, [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) kullanarak yeniden boyutlandırılmış aralığı render eder. [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) yalnızca bu aralığa sınırlandırılır, kenar boşlukları, üstbilgiler ve altbilgiler kaldırılır ve PNG akışı başından konumlandırılarak döndürülür.

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
ByteArrayOutputStream = jpipe.JClass("java.io.ByteArrayOutputStream")


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
    # Hücre aralığının beklenen genişliği ve yüksekliği puan cinsindedir.
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

    # Çalışma kitabı PowerPoint'te OLE nesnesi olarak kullanıldığında görüntülenen boyutu ayarlayın.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Hücre aralığını çerçeve boyutuna uyması için ölçeklendirin.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # Değiştirilmiş çalışma kitabını kullanın.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # OLE görüntüsünü sunum kaynaklarına ekleyin.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # OLE nesne çerçevesini oluşturun.
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

{{% alert color="info" title="Note" %}} 

Çalışma sayfası yeniden boyutlandırma sorununu düzeltmek için iki yaklaşım vardır. Gereksinimlerinize ve kullanım senaryonuza en uygun yaklaşımı seçin. Her iki yaklaşım da sunumların bir şablondan mı yoksa sıfırdan mı oluşturulduğuna bakılmaksızın aynı şekilde çalışır. Ayrıca bu çözüme göre OLE nesne çerçevesinin boyutu için bir sınırlama yoktur.

{{% /alert %}}

## **SSS**

**PowerPoint'ta ilk etkinleştirildiğinde gömülü bir Excel çalışma sayfası neden boyut değiştirir?**  
Bu, Excel'in etkinleştirildiğinde orijinal pencere boyutunu korumaya çalışması, PowerPoint'teki OLE nesne çerçevesinin ise kendi boyutları olması nedeniyle olur. PowerPoint ve Excel, en-boy oranını korumak için boyutu müzakere eder; bu da yeniden boyutlandırmaya neden olabilir.

**Bu yeniden boyutlandırma sorunu tamamen önlenebilir mi?**  
Evet. OLE çerçevesini Excel hücre aralığı boyutuna uydurarak veya hücre aralığını istenen OLE çerçeve boyutuna uydurarak istenmeyen yeniden boyutlandırmayı önleyebilirsiniz.

**Hangi ölçekleme yöntemi kullanılmalı, OLE çerçeve ölçeklendirme mi yoksa hücre aralığı ölçeklendirme mi?**  
Orijinal Excel satır ve sütun boyutlarını korumak istiyorsanız **OLE çerçeve ölçeklendirmesini** seçin. Sunumunuzda OLE çerçevesi için sabit bir boyut istiyorsanız **hücre aralığı ölçeklendirmesini** seçin.

**Bu çözümler, sunum bir şablondan oluşturulmuşsa da çalışır mı?**  
Evet. Her iki çözüm de şablondan oluşturulan ve sıfırdan oluşturulan sunumlar için çalışır.

**Bu yöntemlerle OLE çerçevesinin boyutu için bir sınırlama var mı?**  
Hayır. Ölçeği uygun şekilde ayarladığınız sürece OLE nesne çerçevesini istediğiniz herhangi bir boyuta getirebilirsiniz.

**PowerPoint'te "EMBEDDED OLE OBJECT" yer tutucu metninden nasıl kaçınılır?**  
Hedef Excel hücre aralığının bir anlık görüntüsünü alıp bunu OLE çerçevesinin yer tutucu resmi olarak ayarlarsanız, varsayılan yer tutucu yerine özel bir önizleme resmi gösterilir.

## **İlgili Makaleler**

[Excel Grafiği Oluşturma ve Sunumda OLE Nesnesi Olarak Gömme](/slides/tr/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint Eklentisi Kullanarak OLE Nesnelerini Otomatik Güncelleme](/slides/tr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)