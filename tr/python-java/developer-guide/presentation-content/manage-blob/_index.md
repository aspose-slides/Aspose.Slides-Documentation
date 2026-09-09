---
title: Python aracılığıyla Java'da Sunum BLOB'larını Verimli Bellek Kullanımı İçin Yönet
linktitle: BLOB Yönet
type: docs
weight: 10
url: /tr/python-java/manage-blob/
keywords:
- büyük nesne
- büyük öğe
- büyük dosya
- BLOB ekle
- BLOB dışa aktar
- görseli BLOB olarak ekle
- belleği azalt
- bellek tüketimi
- büyük sunum
- geçici dosya
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides için Python aracılığıyla Java'da BLOB verilerini yöneterek PowerPoint ve OpenDocument dosya işlemlerini verimli sunum işleme için düzenleyin."
---
## **Genel Bakış**

Aspose.Slides, sunumlarda büyük ikili verileri (görüntüler, ses, video ve sunum dosyaları) işlemek için BLOB tabanlı işleme sağlar ve büyük dosyalarla çalışırken bellek tüketimini azaltmaya yardımcı olur.

Bu makale, BLOB tabanlı işlemeyi kullanarak bir sunuma büyük medya eklemeyi, bir sunumdan büyük medya dışa aktarmayı ve büyük sunumları daha verimli yüklemeyi gösterir. Ayrıca işleme sırasında geçici dosyaların nasıl kullanılabileceğini ve bunların saklanacağı klasörün nasıl değiştirileceğini açıklar.

## **BLOB Hakkında**

Bir **BLOB** (**Binary Large Object**, İkili Büyük Nesne) genellikle ikili formatta kaydedilen büyük bir öğedir (fotoğraf, sunum, belge veya medya).

Aspose.Slides for Python via Java, büyük dosyalar söz konusu olduğunda bellek tüketimini azaltan bir şekilde nesneler için BLOB kullanmanıza olanak tanır.

{{% alert color="info" title="Not" %}}
Akışlarla etkileşimde belirli sınırlamaları aşmak için Aspose.Slides akışın içeriğini kopyalayabilir. Bir büyük sunumu akışından yüklemek, sunumun içeriğinin kopyalanmasına ve yavaş yüklemeye neden olur. Bu nedenle, büyük bir sunumu yüklemeyi planladığınızda akış yerine sunum dosya yolunu kullanmanızı şiddetle öneririz.
{{% /alert %}}

## **Bellek Tüketimini Azaltmak İçin BLOB Kullanımı**

### **BLOB Kullanarak Sunuma Büyük Bir Dosya Ekleyin**

[Aspose.Slides](/slides/tr/python-java/) for Python via Java, bellek tüketimini azaltmak için BLOB sürecini içeren büyük dosyaları (bu örnekte büyük bir video dosyası) eklemenize olanak tanır.

Bu Python kodu, BLOB süreciyle bir sunuma büyük bir video dosyası eklemenizi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Videonun ekleneceği yeni bir sunum oluştur.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # Video dosyasına erişmeyi planlamadığımız için akışı kilitli tut.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Bellek tüketimini düşük tutarak sunumu kaydet.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **BLOB Kullanarak Sunumdan Büyük Bir Dosya Dışa Aktarın**
Aspose.Slides for Python via Java, BLOB sürecini içeren büyük dosyaları (örneğin bir ses veya video dosyasını) sunumlardan dışa aktarmanıza olanak tanır. Örneğin, bir sunumdan büyük bir medya dosyasını çıkarmak isteyebilir, ancak dosyanın bilgisayar belleğine yüklenmesini istemeyebilirsiniz. BLOB süreciyle dosyayı dışa aktararak bellek tüketimini düşük tutarsınız.

Bu Python kodu, bahsedilen işlemi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# Kaynak dosyayı belleğe yüklemek yerine kilitle.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # Bellek tüketimini düşük tutmak için video verilerini bir tampon aracılığıyla aktar.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # Tüm videoyu bayt dizisine yüklemek yerine akışı kullan.
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # Gerekirse aynı adımları ses dosyalarına da uygulayın.
finally:
    presentation.dispose()
```

### **Bir Görüntüyü BLOB Olarak Sunuma Ekleyin**
[ImageCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagecollection/) sınıfının yöntemleriyle, büyük bir görüntüyü bir akış olarak ekleyebilir ve bunun BLOB olarak işlenmesini sağlayabilirsiniz.

Bu Python kodu, BLOB süreciyle büyük bir görüntüyü eklemenizi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Görüntünün ekleneceği yeni bir sunum oluştur.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Görüntü dosyasına erişmeyi planlamadığımız için akışı kilitli tut.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Bellek tüketimini düşük tutarak sunumu kaydet.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Bellek ve Büyük Sunumlar**

Genellikle bir büyük sunumu yüklemek için bilgisayarlar çok fazla geçici bellek gerektirir. Sunumun tüm içeriği belleğe yüklenir ve sunumun yüklendiği dosya kullanılmaz hale gelir.

1,5 GB video dosyası içeren büyük.pptx adında bir PowerPoint sunumu düşünün. Bu sunumu yüklemenin standart yöntemi aşağıdaki Python kodunda açıklanmıştır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Ancak bu yöntem yaklaşık 1,6 GB geçici bellek harcar.

### **BLOB Olarak Büyük Bir Sunumu Yükleyin**

BLOB işleme kullanarak, az bellek tüketimiyle büyük bir sunumu yükleyebilirsiniz. Bu Python kodu, BLOB işleme ile büyük bir sunum dosyasını (large.pptx) nasıl yükleyeceğinizi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **Geçici Dosyalar İçin Klasörü Değiştirin**

BLOB süreci kullanıldığında bilgisayarınız geçici dosyaları varsayılan geçici dosya klasöründe oluşturur. Geçici dosyaların farklı bir klasörde tutulmasını istiyorsanız, [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) yöntemiyle depolama ayarlarını değiştirebilirsiniz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="Not" %}}
[BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) kullandığınızda Aspose.Slides geçici dosyaları depolamak için otomatik olarak bir klasör oluşturmaz. Klasörü manuel olarak oluşturmanız gerekir.
{{% /alert %}}

### **Belleği Serbest Bırakmak İçin Sunum Nesnelerini Yokedin**

Büyük sunumları işlerken, [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneğinin gerektiği gibi yok edildiğinden emin olun; böylece kullandığı bellek serbest kalır. Sunumu kullandıktan sonra yönetilmeyen kaynakları serbest bırakmak için [Presentation.dispose](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#dispose) metodunu çağırın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...sunumu işleyin...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # Kaynakları açıkça serbest bırak.
    presentation.dispose()
```

## **SSS**

**Aspose.Slides sunumunda hangi veriler BLOB olarak değerlendirilir ve BLOB seçenekleriyle kontrol edilir?**  
Görseller, ses ve video gibi büyük ikili nesneler BLOB olarak değerlendirilir. Sunum dosyasının tamamı da yüklendiğinde veya kaydedildiğinde BLOB işleme dahil olur. Bu nesneler, bellek kullanımını yönetmenize ve gerektiğinde geçici dosyalara dökülmesini sağlayan BLOB politikalarına tabidir.

**Sunum yüklenirken BLOB işleme kurallarını nerede yapılandırırım?**  
[LoadOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/) ile birlikte [BlobManagementOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/blobmanagementoptions/) kullanın. Burada BLOB'ların bellek sınırını, geçici dosyaların izin verilip verilmediğini, geçici dosyalar için kök yolu ve kaynak kilitleme davranışını ayarlarsınız.

**BLOB ayarları performansı etkiler mi ve hız ile bellek arasında nasıl bir denge kurarım?**  
Evet. BLOB'ları bellekte tutmak hızı maksimize eder ancak RAM tüketimini artırır; bellek sınırını düşürmek daha fazla işi geçici dosyalara yönlendirir, RAM'i azaltır ancak ek I/O maliyeti getirir. İş yükünüz ve ortamınız için doğru dengeyi sağlamak amacıyla [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/tr/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) metodunu kullanın.

**BLOB seçenekleri, çok büyük (gigabayt ölçeğinde) sunumları açarken faydalı mı?**  
Evet. [BlobManagementOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/blobmanagementoptions/) bu senaryolar için tasarlanmıştır: geçici dosyaları etkinleştirmek ve kaynak kilitlemeyi kullanmak, en yüksek RAM kullanımını önemli ölçüde azaltır ve çok büyük sunumların işlenmesini stabilize eder.

**Akışlardan (stream) okunurken BLOB politikalarını kullanabilir miyim?**  
Evet. Aynı kurallar akışlara da uygulanır: sunum örneği, seçilen kilitleme moduna bağlı olarak giriş akışını sahiplenebilir ve kilitleyebilir; izin verildiğinde geçici dosyalar kullanılarak işleme sırasında bellek kullanımı öngörülebilir şekilde tutulur.