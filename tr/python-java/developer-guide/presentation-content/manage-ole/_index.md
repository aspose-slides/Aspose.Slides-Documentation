---
title: Python Kullanarak Sunumlarda OLE Yönetimi
linktitle: OLE Yönetimi
type: docs
weight: 40
url: /tr/python-java/manage-ole/
keywords:
- OLE nesnesi
- Nesne Bağlama ve Gömme
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
- OLE çıkart
- nesne çıkart
- dosya çıkart
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint ve OpenDocument dosyalarında OLE nesne yönetimini optimize edin. OLE içeriğini sorunsuz bir şekilde gömün, güncelleyin ve dışa aktarın."
---
## **Giriş**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding), bir Microsoft teknolojisidir ve bir uygulamada oluşturulan veri ve nesnelerin bağlama veya gömme yoluyla başka bir uygulamada yer almasını sağlar.

{{% /alert %}}

MS Excel’de oluşturulmuş bir grafiği düşünün. Bu grafik daha sonra bir PowerPoint slaytına yerleştirilir. Bu Excel grafiği bir OLE nesnesi olarak kabul edilir.

- Bir OLE nesnesi simge olarak görünebilir. Bu durumda, simgeye çift tıkladığınızda grafik ilişkili uygulamasında (Excel) açılır veya nesneyi açmak/düzenlemek için bir uygulama seçmeniz istenir.
- Bir OLE nesnesi gerçek içeriğini, örneğin grafiğin içeriğini, görüntüleyebilir. Bu durumda grafik PowerPoint içinde etkinleşir, grafik arabirimi yüklenir ve grafiğin verilerini PowerPoint içinde değiştirebilirsiniz.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/tr/python-java/) OLE nesnelerini slaytlara OLE nesne çerçeveleri ([OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/)) olarak eklemenizi sağlar.

## **OLE Nesne Çerçevelerini Slaytlara Ekleme**

Microsoft Excel’de zaten bir grafik oluşturduğunuzu ve Aspose.Slides for Python via Java kullanarak bu grafiği bir OLE nesne çerçevesi olarak bir slayta gömmek istediğinizi varsayalım; bunu aşağıdaki şekilde yapabilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksiyle bir slayta referans alın.  
1. Excel dosyasını bir bayt dizisi olarak okuyun.  
1. Bayt dizisini ve OLE nesnesiyle ilgili diğer bilgileri içeren [OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/) nesnesini slayta ekleyin.  
1. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

Aşağıdaki örnekte, bir Excel dosyasından bir grafiği Aspose.Slides for Python via Java kullanarak OLE nesne çerçevesi olarak bir slayta ekledik. **Not** ki [OleEmbeddedDataInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleembeddeddatainfo/) yapıcısı, ikinci parametre olarak gömülebilir bir nesne uzantısı alır. Bu uzantı, PowerPoint’in dosya türünü doğru bir şekilde yorumlamasını ve OLE nesnesini açmak için uygun uygulamayı seçmesini sağlar.

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

### **Bağlantılı OLE Nesne Çerçevelerini Ekleme**

Aspose.Slides for Python via Java, gömülü veri yerine dosyaya bir bağlantı içeren bir [OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/) eklemenize olanak tanır.

Bu Python kodu, bir Excel dosyasına bağlantılı bir [OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/) nesnesini bir slayta nasıl ekleyeceğinizi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Bağlantılı bir Excel dosyasıyla OLE nesne çerçevesi ekleyin.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **OLE Nesne Çerçevelerine Erişim**

Bir OLE nesnesi zaten bir slayta gömülü ise, ona bu şekilde kolayca ulaşabilir veya bulabilirsiniz:

1. Gömülü OLE nesnesi içeren bir sunumu, [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturarak yükleyin.  
2. İndeksiyle slayta referans alın.  
3. [OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/) şekline erişin. Örneğimizde, ilk slaytta yalnızca bir şekil bulunan önceden oluşturulmuş PPTX’i kullandık. Ardından nesnenin bir [OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/) olduğunu doğruladık. Bu, erişilmek istenen OLE nesne çerçevesiydi.  
4. OLE nesne çerçevesine erişildikten sonra, üzerinde istediğiniz herhangi bir işlemi gerçekleştirebilirsiniz.

Aşağıdaki örnekte bir OLE nesne çerçevesi (slayta gömülmüş bir Excel grafik nesnesi) ve dosya verisi erişilmiştir.

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

        # Gömülü dosya verisini al.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Gömülü dosyanın uzantısını al.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Bağlantılı OLE Nesne Çerçeve Özelliklerine Erişim**

Aspose.Slides, bağlantılı OLE nesne çerçevesi özelliklerine erişmenizi sağlar.

Bu Python kodu, bir OLE nesnesinin bağlantılı olup olmadığını kontrol etmeyi ve ardından bağlantılı dosyanın yolunu elde etmeyi gösterir:

```python
import jpide
import asposeslides

if not jpide.isJVMStarted():
    jpide.startJVM()

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

            # Varsa bağlantılı dosyanın göreli yolunu yazdır.
            # Yalnızca PPT sunumları göreli yolu içerebilir.
            relative_path = ole_frame.getLinkPathRelative()
finally:
    presentation.dispose()
```

## **OLE Nesne Verisini Değiştirme**

{{% alert color="info" title="Note" %}}

Bu bölümdeki kod örneği aşağıda [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/) kullanmaktadır.

{{% /alert %}}

Bir OLE nesnesi zaten bir slayta gömülü ise, o nesneye kolayca erişebilir ve verisini aşağıdaki şekilde değiştirebilirsiniz:

1. Gömülü OLE nesnesi içeren bir sunumu, [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturarak yükleyin.  
2. İndeksiyle slayta referans alın.  
3. OLE nesne çerçevesi şekline erişin. Örneğimizde, ilk slaytta bir şekil bulunan önceden oluşturulmuş PPTX’i kullandık. Ardından nesnenin bir [OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/) olduğunu doğruladık. Bu, erişilmek istenen OLE nesne çerçevesiydi.  
4. OLE nesne çerçevesine erişildikten sonra, üzerinde istediğiniz herhangi bir işlemi gerçekleştirebilirsiniz.  
5. [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) nesnesi oluşturun ve OLE verisine erişin.  
6. İstenen [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) öğesine erişin ve veriyi düzenleyin.  
7. Güncellenmiş [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) nesnesini bir akışa kaydedin.  
8. Akıştan OLE nesne verisini değiştirin.

Aşağıdaki örnekte bir OLE nesne çerçevesi (slayta gömülmüş bir Excel grafik nesnesi) erişilmiş ve dosya verisi grafik verilerini güncelleyecek şekilde değiştirilmiştir.

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

## **Diğer Dosya Türlerini Slaytlara Gömme**

Excel grafiklerinin yanı sıra, Aspose.Slides for Python via Java, slaytlara HTML, PDF ve ZIP gibi diğer dosya türlerini nesne olarak gömmenize olanak tanır. Kullanıcı eklenen nesneye çift tıkladığında, ilgili program otomatik olarak açılır veya kullanıcıdan dosyayı açmak için uygun bir program seçmesi istenir.

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

Sunumlarla çalışırken, eski OLE nesnelerini yenileriyle değiştirmek veya desteklenmeyen bir OLE nesnesini desteklenen bir nesneyle değiştirmek isteyebilirsiniz. Aspose.Slides for Python via Java, gömülü bir nesnenin dosya türünü ayarlamanıza izin verir; bu sayede OLE çerçeve verisini veya uzantısını güncelleyebilirsiniz.

Bu Python kodu, gömülü bir OLE nesnesinin dosya türünü `zip` olarak nasıl ayarlayacağınızı gösterir:

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

Bir OLE nesnesi gömüldükten sonra, otomatik olarak bir simge görüntüsü içeren bir ön izleme eklenir. Bu ön izleme, kullanıcıların OLE nesnesine erişmeden veya açmadan önce gördükleri şeydir. Ön izlemede belirli bir resim ve metin kullanmak isterseniz, Aspose.Slides for Python via Java ile simge görüntüsünü ve başlığı ayarlayabilirsiniz.

Bu Python kodu, gömülü bir nesne için simge görüntüsünü ve başlığını nasıl ayarlayacağınızı gösterir:

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

    # OLE ön izlemesi için bir başlık ve resmi ayarlayın.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **OLE Nesne Çerçevesinin Yeniden Boyutlandırılmasını ve Yeniden Konumlandırılmasını Önleme**

Bağlantılı bir OLE nesnesini bir sunum slaytına ekledikten sonra, PowerPoint’te sunumu açtığınızda “Bağlantıları Güncelle” mesajı görebilirsiniz. “Bağlantıları Güncelle” düğmesine tıklamak, PowerPoint bağlantılı OLE nesnesinden verileri güncellediği ve nesne ön izlemesini yenilediği için OLE nesne çerçevesinin boyut ve konumunu değiştirebilir. Nesnenin verileri güncellenmek üzere istemeyi önlemek için [OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/) sınıfının **setUpdateAutomatic** metodunu `False` olarak ayarlayın:

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

Aspose.Slides for Python via Java, slaytlarda OLE nesneleri olarak gömülü dosyaları aşağıdaki şekilde çıkarabilir:

1. Çıkarmak istediğiniz OLE nesnelerini içeren bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneği oluşturun.  
2. Sunumdaki tüm şekillerin üzerinden döngü oluşturarak [OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/) şekillerine erişin.  
3. Gömülü dosyaların verilerine OLE nesne çerçevelerinden ulaşın ve diske yazın.

Bu Python kodu, bir slaytta OLE nesnesi olarak gömülü dosyaları nasıl çıkaracağınızı gösterir:

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

**Slaytlar PDF/görsellere dışa aktarılırken OLE içeriği renderlanacak mı?**

Slaytta görünen şey renderlanır — simge/ikame görüntüsü (ön izleme). “Canlı” OLE içeriği renderlama sırasında çalıştırılmaz. Gerekiyorsa, dışa aktarılan PDF'de beklenen görünümü sağlamak için kendi ön izleme resminizi ayarlayın.

**Bir OLE nesnesini bir slaytta kilitleyerek kullanıcıların PowerPoint’te nesneyi taşımasını/düzenlemesini nasıl engelleyebilirim?**

Şekli kilitleyin: Aspose.Slides [şekil‑seviyesi kilitler](/slides/tr/python-java/applying-protection-to-presentation/) sağlar. Bu bir şifreleme değildir, ancak yanlışlıkla düzenleme ve taşıma işlemlerini etkili bir şekilde önler.

**Bağlantılı bir Excel nesnesi, sunumu açtığımda “atlıyor” ya da boyutu değişiyor, neden?**

PowerPoint, bağlantılı OLE nesnesinin ön izlemesini yenileyebilir. Stabil bir görünüm elde etmek için [Worksheet Resizing için Çalışma Çözümü](/slides/tr/python-java/working-solution-for-worksheet-resizing/) uygulamalarını izleyin — ya çerçeveyi aralığa göre ayarlayın ya da aralığı sabit bir çerçeveye ölçekleyin ve uygun bir ikame görüntüsü belirleyin.

**Bağlantılı OLE nesneleri için göreli yollar PPTX formatında korunur mu?**

PPTX’te “göreli yol” bilgisi bulunmaz — yalnızca tam yol vardır. Göreli yollar, eski PPT formatında mevcuttur. Taşınabilirliği artırmak için güvenilir mutlak yollar/erişilebilir URI’ler veya gömme kullanın.