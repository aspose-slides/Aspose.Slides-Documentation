---
title: PPTX'te Grafik Yeniden Boyutlandırma İçin Çalışan Çözüm
type: docs
weight: 40
url: /tr/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafik yeniden boyutlandırma
- Excel grafiği
- OLE nesnesi
- grafiği gömme
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile gömülü Excel OLE nesneleri kullanıldığında PPTX'te beklenmeyen grafik yeniden boyutlandırma sorununu çözün. Boyutların tutarlı kalması için iki yöntemi ve kod örneklerini öğrenin."
---
## **Arka Plan**

Aspose bileşenleri aracılığıyla bir PowerPoint sunumunda OLE nesneleri olarak gömülü Excel grafiklerinin ilk etkinleştirildikten sonra belirtilmemiş bir ölçeğe yeniden boyutlandırıldığı gözlemlenmiştir. Bu davranış, grafiğin etkinleştirilmeden önceki ve sonraki durumları arasında sunumda dikkat çekici bir görsel fark yaratır. Aspose ekibi sorunu ayrıntılı olarak inceledi ve bir çözüm buldu. Bu makale sorunun nedenlerini ve ilgili düzeltmeyi açıklamaktadır.

Önceki makalede [önceki makale](/slides/tr/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), Aspose.Cells for Python via Java kullanarak bir Excel grafiği oluşturmayı ve Aspose.Slides for Python via Java kullanarak bir PowerPoint sunumuna gömmeyi açıkladık. Nesne önizleme sorunu](/slides/tr/python-java/object-preview-issue-when-adding-oleobjectframe/) ele almak için grafiğin resmini OLE nesne çerçevesine atadık. Çıktı sunumunda, grafik resmini gösteren OLE nesne çerçevesine çift tıkladığınızda Excel grafiği etkinleşir. Kullanıcılar, altındaki Excel çalışma kitabında istedikleri değişiklikleri yapabilir ve etkinleştirilen çalışma kitabının dışına tıklayarak ilgili slayta dönebilir. Kullanıcı slayta geri döndüğünde OLE nesne çerçevesinin boyutu değişir ve yeniden boyutlandırma faktörü, OLE nesne çerçevesi ile gömülü Excel çalışma kitabının orijinal boyutlarına bağlı olarak değişir.

## **Yeniden Boyutlandırmanın Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğu için, ilk etkinleştirildiğinde orijinal boyutunu korumaya çalışır. OLE nesne çerçevesinin ise kendi boyutu vardır. Microsoft'a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint boyutu müzakere eder ve gömme işleminin bir parçası olarak doğru oranları korur. Excel pencere boyutu ile OLE nesne çerçevesinin boyutu veya konumu arasındaki farklara bağlı olarak yeniden boyutlandırma gerçekleşir.

## **Çözüm**

Aspose.Slides for Python via Java kullanarak PowerPoint sunumları oluşturmanın iki olası senaryosu vardır.

**Senaryo 1:** Mevcut bir şablona dayanarak bir sunum oluşturun.

**Senaryo 2:** Sıfırdan bir sunum oluşturun.

Burada sunduğumuz çözüm her iki senaryoya da uygulanır. Tüm çözüm yaklaşımlarının temeli aynıdır: **gömülü OLE nesnesinin pencere boyutu, PowerPoint slaydındaki OLE nesne çerçevesiyle aynı olmalıdır**. Şimdi bu çözümün iki yaklaşımını tartışacağız.

## **Birinci Yaklaşım**

Bu yaklaşımda, gömülü Excel çalışma kitabının pencere boyutunu, PowerPoint slaydındaki OLE nesne çerçevesinin boyutuyla eşleşecek şekilde ayarlamayı öğreneceğiz.

**Senaryo 1**

Bir şablon tanımladığımızı ve buna dayalı sunumlar oluşturmak istediğimizi varsayalım. Şablonda indeks 2'de, gömülü bir Excel çalışma kitabı içeren bir OLE çerçevesi yerleştirmek istediğimiz bir şekil olduğunu varsayalım. Bu senaryoda, OLE nesne çerçevesinin boyutu önceden tanımlıdır—şablondaki indeks 2'deki şeklin boyutuyla eşleşir. Yapmamız gereken tek şey, çalışma kitabının pencere boyutunu o şeklin boyutuna eşitlemek. Aşağıdaki kod snippet'i bu amacı hizmet eder:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Grafiği içeren Excel çalışma kitabını yükleyin.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Çalışma kitabı pencere boyutunu inç cinsinden ayarlayın (PowerPoint inç başına 72 puan kullanır).
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # Çalışma kitabını bir bellek akışına kaydedin.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Gömülü Excel verisiyle bir OLE nesne çerçevesi oluşturun.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Senaryo 2**

Sıfırdan bir sunum oluşturup herhangi bir boyutta gömülü bir Excel çalışma kitabı içeren bir OLE nesne çerçevesi eklemek istediğimizi varsayalım. Aşağıdaki kod snippet'inde, slaytta x = 0.5 inç ve y = 1 inç konumunda yüksekliği 4 inç ve genişliği 9.5 inç olan bir OLE nesne çerçevesi oluşturuyoruz. Ardından Excel çalışma kitabı penceresini aynı boyuta ayarlıyoruz—yüksekliği 4 inç ve genişliği 9.5 inç.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Grafiği içeren Excel çalışma kitabını yükleyin.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 inç (4 * 72).
    desired_width = 684  # 9.5 inç (9.5 * 72).

    # Pencere ile grafik boyutunu tanımlayın.
    chart.setSizeWithWindow(True)

    # Çalışma kitabı pencere boyutunu inç cinsinden ayarlayın (PowerPoint inç başına 72 puan kullanır).
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # Çalışma kitabını bir bellek akışına kaydedin.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Gömülü Excel verisiyle bir OLE nesne çerçevesi oluşturun.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **İkinci Yaklaşım**

Bu yaklaşımda, gömülü Excel çalışma kitabındaki grafiğin boyutunu PowerPoint slaydındaki OLE nesne çerçevesinin boyutuna eşitlemeyi öğreneceğiz. Bu yaklaşım, grafik boyutu önceden biliniyorsa ve hiç değişmeyecekse kullanışlıdır.

**Senaryo 1**

Bir şablon tanımladığımızı ve buna dayalı sunumlar oluşturmak istediğimizi varsayalım. Şablonda indeks 2'de, gömülü bir Excel çalışma kitabı içeren bir OLE çerçevesi yerleştirmeyi planladığımız bir şekil olduğunu varsayalım. Bu senaryoda, OLE çerçeve boyutu önceden tanımlıdır—şablondaki indeks 2'deki şeklin boyutuyla eşleşir. Yapmamız gereken tek şey, çalışma kitabındaki grafiğin boyutunu şeklin boyutuna eşitlemek. Aşağıdaki kod snippet'i bu amacı hizmet eder:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Grafiği içeren Excel çalışma kitabını yükleyin.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Pencere olmadan grafik boyutunu tanımlayın.
    chart.setSizeWithWindow(False)

    # Grafik boyutunu piksel cinsinden ayarlayın (Excel inç başına 96 piksel kullanır).
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # Grafik baskı boyutunu tanımlayın.
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # Çalışma kitabını bir bellek akışına kaydedin.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Gömülü Excel verisiyle bir OLE nesne çerçevesi oluşturun.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Senaryo 2:**  
Sıfırdan bir sunum oluşturup herhangi bir boyutta gömülü bir Excel çalışma kitabı içeren bir OLE nesne çerçevesi eklemek istediğimizi varsayalım. Aşağıdaki kod snippet'inde, slaytta x = 0.5 inç ve y = 1 inç konumunda yüksekliği 4 inç ve genişliği 9.5 inç olan bir OLE nesne çerçevesi oluşturuyoruz. Ayrıca ilgili grafik boyutunu da aynı ölçülere ayarlıyoruz: yüksekliği 4 inç ve genişliği 9.5 inç.

```python
import jpase
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Grafiği içeren Excel çalışma kitabını yükleyin.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 inç (4 * 72).
    desired_width = 684  # 9.5 inç (9.5 * 72).

    # Pencere olmadan grafik boyutunu tanımlayın.
    chart.setSizeWithWindow(False)

    # Grafik boyutunu piksel cinsinden ayarlayın (Excel inç başına 96 piksel kullanır).
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # Çalışma kitabını bir bellek akışına kaydedin.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Gömülü Excel verisiyle bir OLE nesne çerçevesi oluşturun.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Sonuç**

Grafik yeniden boyutlandırma sorununu düzeltmenin iki yaklaşımı vardır. Yaklaşım seçimi gereksinimlere ve kullanım senaryosuna bağlıdır. Her iki yaklaşım da sunumlar bir şablondan oluşturulmuş olsun ya da sıfırdan oluşturulmuş olsun aynı şekilde çalışır. Ayrıca bu çözümlerde OLE nesne çerçevesinin boyutu için bir sınır yoktur.

## **SSS**

**Neden gömülü Excel grafiğim PowerPoint'te etkinleştirildikten sonra boyut değiştiriyor?**  
Bu, Excel'in ilk etkinleştirildiğinde orijinal pencere boyutunu geri yüklemeye çalışması, ancak PowerPoint'teki OLE nesne çerçevesinin kendi boyutlarının olması nedeniyle gerçekleşir. PowerPoint ve Excel boyutu, en boy oranını korumak için müzakere eder; bu da yeniden boyutlandırmaya yol açabilir.

**Bu yeniden boyutlandırma sorununu tamamen önlemek mümkün mü?**  
Evet. Excel çalışma kitabı pencere boyutunu veya grafik boyutunu gömmeden önce OLE nesne çerçevesi boyutuyla eşleştirerek grafik boyutlarını tutarlı tutabilirsiniz.

**Hangı yaklaşımı tercih etmeli, çalışma kitabı pencere boyutunu ayarlamayı mı yoksa grafik boyutunu ayarlamayı mı?**  
Çalışma kitabının en boy oranını korumak ve daha sonra yeniden boyutlandırma olanağı sağlamak istiyorsanız **Yaklaşım 1 (pencere boyutu)** kullanın. Grafik boyutları sabit ve gömülmeden sonra değişmeyecekse **Yaklaşım 2 (grafik boyutu)** kullanın.

**Bu yöntemler şablon tabanlı sunumlar ve yeni sunumlarda da çalışır mı?**  
Evet. Her iki yaklaşım da şablonlardan oluşturulan ve sıfırdan oluşturulan sunumlarda aynı şekilde çalışır.

**OLE nesne çerçevesinin boyutu için bir sınırlama var mı?**  
Hayır. OLE çerçevesini, çalışma kitabı ya da grafik boyutuna uygun şekilde ölçeklendirildiği sürece istediğiniz herhangi bir boyuta ayarlayabilirsiniz.

**Bu yöntemleri diğer tablo programlarında oluşturulan grafiklerle kullanabilir miyim?**  
Örnekler, Aspose.Cells ile oluşturulan Excel grafikleri için tasarlanmıştır, ancak ilkeler, benzer boyutlandırma seçeneklerini destekleyen diğer OLE uyumlu tablo programları için de geçerlidir.

## **İlgili Bölümler**

- [Excel Grafiklerini Oluştur ve OLE Nesneleri Olarak Sunumlara Göm](/slides/tr/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)