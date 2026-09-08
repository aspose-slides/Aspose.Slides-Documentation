---
title: Python Kullanarak Sunumlarda OLE Yönetimi
linktitle: OLE Yönetimi
type: docs
weight: 40
url: /tr/python-java/manage-ole/
keywords:
- OLE nesnesi
- Nesne Bağlantısı ve Gömme
- OLE ekle
- OLE göm
- nesne ekle
- nesne göm
- dosya ekle
- dosya göm
- bağlantılı nesne
- bağlantılı dosya
- OLE değiştir
- OLE simgesi
- OLE başlığı
- OLE çıkar
- nesne çıkar
- dosya çıkar
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint ve OpenDocument dosyalarında OLE nesne yönetimini optimize edin. OLE içeriğini sorunsuz bir şekilde gömün, güncelleyin ve dışa aktarın."
---
## **Giriş**

{{% alert color="info" title="Not" %}}

OLE (Object Linking & Embedding), bir uygulamada oluşturulan veri ve nesnelerin başka bir uygulamaya bağlanma veya gömme yoluyla yerleştirilmesine izin veren bir Microsoft teknolojisidir.

{{% /alert %}}

MS Excel'de oluşturulmuş bir grafiği düşünün. Grafik daha sonra bir PowerPoint slaytına yerleştirilir. Bu Excel grafiği bir OLE nesnesi olarak kabul edilir.

- Bir OLE nesnesi bir simge olarak görünebilir. Bu durumda, simgeye çift tıkladığınızda grafik ilişkili uygulamasında (Excel) açılır veya nesneyi açma/düzenleme için bir uygulama seçmeniz istenir.
- Bir OLE nesnesi gerçek içeriğini, örneğin bir grafiğin içeriğini, gösterebilir. Bu durumda, grafik PowerPoint içinde etkinleşir, grafik arabirimi yüklenir ve grafiğin verilerini PowerPoint içinde değiştirebilirsiniz.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/tr/python-java/) slide'lara OLE nesnelerini OLE nesne çerçeveleri ([OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/)) olarak eklemenizi sağlar.

## **Slide'lara OLE Nesne Çerçeveleri Ekleme**

Microsoft Excel'de zaten bir grafik oluşturduğunuzu ve bunu Aspose.Slides for Python via Java kullanarak bir slayta OLE nesne çerçevesi olarak gömmek istediğinizi varsayalım; bunu şu şekilde yapabilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Slaytın indeksine göre referansını alın.  
1. Excel dosyasını bayt dizisi olarak okuyun.  
1. OleObjectFrame'i, bayt dizisini ve OLE nesnesiyle ilgili diğer bilgileri içerecek şekilde slayta ekleyin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnekte, bir Excel dosyasındaki grafiği Aspose.Slides for Python via Java kullanarak OLE nesne çerçevesi olarak bir slayta ekledik.  
**Not** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleembeddeddatainfo/) yapıcı metodunun ikinci parametresi, gömülebilir nesne uzantısını alır. Bu uzantı, PowerPoint'in dosya türünü doğru yorumlamasını ve OLE nesnesini açmak için uygun uygulamayı seçmesini sağlar.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # OLE nesnesi için veriyi hazırlayın.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # OLE nesne çerçevesini slayta ekleyin.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Bağlantılı OLE Nesne Çerçeveleri Ekleme**

Aspose.Slides for Python via Java, veriyi gömmeden yalnızca dosyaya bir bağlantı ile bir [OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/) eklemenizi sağlar.

Bu Python kodu, bir slayta bağlantılı bir Excel dosyasıyla bir [OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/) eklemenin nasıl yapılacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Bağlantılı bir Excel dosyasıyla bir OLE nesne çerçevesi ekleyin.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **OLE Nesne Çerçevelerine Erişme**

Bir OLE nesnesi zaten bir slayta gömülmüşse, ona şu şekilde kolayca ulaşabilir veya bulabilirsiniz:

1. Gömülü OLE nesnesi içeren bir sunumu, [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturarak yükleyin.  
2. Slaytın indeksine göre referansını alın.  
3. [OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/) şekline erişin. Örneğimizde, yalnızca bir şekli olan ilk slayttaki önceden oluşturulmuş PPTX'i kullandık. Ardından nesnenin bir [OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/) olduğunu doğruladık. Bu, erişilmek istenen OLE nesne çerçevesiydi.  
4. OLE nesne çerçevesine erişildikten sonra, üzerinde istediğiniz herhangi bir işlemi gerçekleştirebilirsiniz.

Aşağıdaki örnekte, bir OLE nesne çerçevesi (bir slayta gömülmüş bir Excel grafik nesnesi) ve dosya verileri erişilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Gömülü dosya verisini alın.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Gömülü dosyanın uzantısını alın.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Bağlantılı OLE Nesne Çerçevesi Özelliklerine Erişme**

Aspose.Slides, bağlantılı OLE nesne çerçevesi özelliklerine erişmenizi sağlar.

Bu Python kodu, bir OLE nesnesinin bağlantılı olup olmadığını kontrol etmeyi ve ardından bağlantılı dosyanın yolunu elde etmeyi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # OLE nesnesinin bağlantılı olup olmadığını kontrol edin.
        if ole_frame.isObjectLink():
            # Bağlantılı dosyanın tam yolunu yazdır.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Bağlantılı dosyanın göreli yolu mevcutsa yazdır.
            # Yalnızca PPT sunumları göreli yolu içerebilir.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **OLE Nesne Verisini Değiştirme**

{{% alert color="info" title="Not" %}}

Bu bölümdeki kod örneği, [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/) kullanmaktadır.

{{% /alert %}}

Bir OLE nesnesi zaten bir slayta gömülmüşse, o nesneye kolayca erişebilir ve verisini şu şekilde değiştirebilirsiniz:

1. Gömülü OLE nesnesi içeren bir sunumu, [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturarak yükleyin.  
2. Slaytın indeksine göre referansını alın.  
3. OLE nesne çerçevesi şekline erişin. Örneğimizde, ilk slaytta bir şekli olan önceden oluşturulmuş PPTX'i kullandık. Ardından nesnenin bir [OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/) olduğunu doğruladık. Bu, erişilmek istenen OLE nesne çerçevesiydi.  
4. OLE nesne çerçevesine erişildikten sonra, üzerinde istediğiniz herhangi bir işlemi gerçekleştirebilirsiniz.  
5. [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) nesnesi oluşturun ve OLE verisine erişin.  
6. İstenen [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) erişin ve verileri değiştirin.  
7. Güncellenmiş [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) nesnesini bir akışa kaydedin.  
8. OLE nesne verisini akıştan değiştirin.

Aşağıdaki örnekte, bir OLE nesne çerçevesi (bir slayta gömülmüş bir Excel grafik nesnesi) erişilir ve dosya verileri grafiğin verilerini güncelleyecek şekilde değiştirilir.

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # OLE nesnesi verisini Workbook nesnesi olarak okuyun.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # Çalışma kitabı verisini değiştirin.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # OLE çerçeve nesnesi verisini değiştirin.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Slide'lara Diğer Dosya Türlerini Gömme**

Excel grafiklerinin yanı sıra, Aspose.Slides for Python via Java, slide'lara HTML, PDF ve ZIP gibi diğer dosya türlerini nesne olarak gömmenize olanak tanır. Kullanıcı eklenen nesneye çift tıkladığında, ilgili program otomatik olarak açılır veya kullanıcıdan uygun bir program seçmesi istenir.

Bu Python kodu, bir slayta HTML ve ZIP dosyalarını nasıl gömeceğinizi gösterir:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gömülü Nesneler İçin Dosya Türlerini Ayarlama**

Sunumlarla çalışırken eski OLE nesnelerini yenileriyle değiştirmek veya desteklenmeyen bir OLE nesnesini desteklenen bir nesneyle değiştirmek isteyebilirsiniz. Aspose.Slides for Python via Java, gömülü bir nesne için dosya türünü ayarlamanıza olanak tanır; böylece OLE çerçeve verilerini veya uzantısını güncelleyebilirsiniz.

Bu Python kodu, gömülü bir OLE nesnesinin dosya türünü `zip` olarak ayarlamayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # Dosya türünü ZIP olarak değiştir.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gömülü Nesneler İçin Simge Görüntüleri ve Başlıkları Ayarlama**

Bir OLE nesnesi gömüldükten sonra, otomatik olarak bir simge görüntüsünden oluşan bir ön izleme eklenir. Bu ön izleme, kullanıcıların OLE nesnesine erişmeden/ açmadan önce gördükleri şeydir. Ön izlemeye belirli bir görüntü ve metin eklemek istiyorsanız, Aspose.Slides for Python via Java kullanarak simge görüntüsü ve başlığı ayarlayabilirsiniz.

Bu Python kodu, gömülü bir nesne için simge görüntüsü ve başlığı nasıl ayarlayacağınızı gösterir:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Sunum kaynaklarına bir resim ekleyin.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # OLE önizlemesi için bir başlık ve resmi ayarlayın.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **OLE Nesne Çerçevesinin Yeniden Boyutlandırılmasını ve Konumlandırılmasını Önleme**

Bir bağlantılı OLE nesnesini bir sunum slaytına ekledikten sonra, PowerPoint'te sunumu açtığınızda bağlamaları güncellemek isteyip istemediğinizi soran bir ileti görebilirsiniz. “Bağlantıları Güncelle” düğmesine tıklamak, PowerPoint'in bağlantılı OLE nesnesinden verileri güncellemesi ve ön izlemeyi yenilemesi nedeniyle OLE nesne çerçevesinin boyut ve konumunu değiştirebilir. PowerPoint'in nesne verilerini güncelleme istemesini önlemek için, [OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/) sınıfının **setUpdateAutomatic** metodunu `False` olarak ayarlayın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gömülü Dosyaları Çıkarma**

Aspose.Slides for Python via Java, slaytlara OLE nesneleri olarak gömülmüş dosyaları şu şekilde çıkarmanıza izin verir:

1. Çıkarmak istediğiniz OLE nesnelerini içeren bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.  
2. Sunumdaki tüm şekiller üzerinden döngü yapın ve [OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/) şekillerine erişin.  
3. OLE nesne çerçevelerinden gömülü dosya verilerine erişin ve diske yazın.

Bu Python kodu, bir slayttaki OLE nesneleri olarak gömülü dosyaları nasıl çıkaracağınızı gösterir:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **SSS**

**OLE içeriği slaytlar PDF/görsellere dışa aktarılırken renderlanacak mı?**

Slaytta görülen şey renderlanır—simge/yer tutucu görüntü (ön izleme). “Canlı” OLE içeriği renderleme sırasında yürütülmez. Gerekirse, dışa aktarılan PDF'de beklenen görünümü sağlamak için kendi ön izleme görüntünüzü ayarlayın.

**Bir OLE nesnesini bir slaytta kilitleyerek kullanıcıların PowerPoint'te onu taşımalarını/düzenlemelerini nasıl engelleyebilirim?**

Şekli kilitleyin: Aspose.Slides, [şekil düzeyinde kilitler](/slides/tr/python-java/applying-protection-to-presentation/) sağlar. Bu şifreleme değildir, ancak kazara düzenlemeleri ve hareketi etkili bir şekilde önler.

**Bağlantılı bir Excel nesnesi, sunumu açtığımda “atlar” ya da boyutu değişiyor, neden?**

PowerPoint, bağlantılı OLE'nin ön izlemesini yenileyebilir. Sabit bir görünüm için, [Worksheet Yeniden Boyutlandırma için Çalışma Çözümü](/slides/tr/python-java/working-solution-for-worksheet-resizing/) uygulamalarını izleyin—ya çerçeveyi aralığa göre ayarlayın, ya da aralığı sabit bir çerçeveye ölçeklendirin ve uygun bir yer tutucu görüntü belirleyin.

**Bağlantılı OLE nesneleri için relatif yollar PPTX formatında korunur mu?**

PPTX içinde “relatif yol” bilgisi bulunmaz—yalnızca tam yol mevcuttur. Relatif yollar, eski PPT formatında bulunur. Taşınabilirlik için güvenilir mutlak yollar/erişilebilir URI'lar veya gömme tercih edin.