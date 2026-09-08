---
title: Verimli Bellek Kullanımı için Python via Java'da Sunum BLOB'larını Yönetin
linktitle: BLOB'u Yönet
type: docs
weight: 10
url: /tr/python-java/manage-blob/
keywords:
- büyük nesne
- büyük öğe
- büyük dosya
- BLOB ekle
- BLOB dışa aktar
- görüntüyü BLOB olarak ekle
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
description: "Aspose.Slides for Python via Java'da BLOB verilerini yönetin ve PowerPoint ve OpenDocument dosya işlemlerini verimli sunum yönetimi için basitleştirin."
---
## **Genel Bakış**

Aspose.Slides, büyük resimler, ses, video ve sunum dosyalarıyla çalışırken bellek tüketimini azaltmak için sunularda büyük ikili verileri (BLOB) işleme imkanı sağlar.

Bu makale, bir sunuma büyük medya eklemek, bir sunumdan büyük medya dışa aktarmak ve büyük sunumları daha verimli şekilde yüklemek için BLOB tabanlı işlemenin nasıl kullanılacağını gösterir. Ayrıca işlem sırasında geçici dosyaların nasıl kullanılacağını ve bu dosyaların saklanacağı klasörün nasıl değiştirileceğini açıklar.

## **BLOB Hakkında**

**BLOB** (**Binary Large Object**), genellikle ikili formatta kaydedilmiş büyük bir öğe (fotoğraf, sunum, belge veya medya) anlamına gelir.

Aspose.Slides for Python via Java, büyük dosyalar söz konusu olduğunda bellek tüketimini azaltan bir yöntem olarak nesneler için BLOB kullanmanıza izin verir.

{{% alert color="info" title="Not" %}}
Akışlarla etkileşimde belirli sınırlamaları aşmak için Aspose.Slides akışın içeriğini kopyalayabilir. Bir büyük sunumu akış üzerinden yüklemek, sunumun içeriğinin kopyalanmasına ve yavaş yüklemeye neden olur. Bu nedenle, büyük bir sunumu yüklemeyi planladığınızda, akış yerine sunum dosya yolunu kullanmanızı şiddetle öneririz.
{{% /alert %}}

## **Bellek Tüketimini Azaltmak İçin BLOB Kullanma**

### **BLOB ile Bir Sunuma Büyük Dosya Ekleme**

[Aspose.Slides](/slides/tr/python-java/) for Python via Java, bellek tüketimini azaltmak için BLOB içeren bir süreç aracılığıyla büyük dosyalar (bu örnekte büyük bir video dosyası) eklemenize olanak tanır.

Bu Python kodu, BLOB süreci kullanılarak bir sunuma büyük bir video dosyasının nasıl ekleneceğini gösterir:

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
        # Video dosyasına erişmeyi amaçlamadığımız için akışı kilitli tut.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Bellek tüketimini düşük tutarak sunumu kaydet.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **BLOB ile Sunumdan Büyük Dosya Dışa Aktarma**
Aspose.Slides for Python via Java, BLOB içeren bir süreç aracılığıyla sunumlardan büyük dosyalar (örneğin ses veya video dosyası) dışa aktarmanıza izin verir. Örneğin, bir sunumdan büyük bir medya dosyasını çıkarmanız gerekebilir, ancak dosyanın bilgisayar belleğine yüklenmesini istemezsiniz. Dosyayı BLOB süreciyle dışa aktararak bellek tüketimini düşük tutarsınız.

Bu Python kodu, açıklanan işlemi gösterir:

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
    # Bellek tüketimini düşük tutmak için video verilerini bir tampon üzerinden aktar.
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
    # Gerekirse, aynı adımları ses dosyalarına uygulayın.
finally:
    presentation.dispose()
```

### **Bir Görüntüyü BLOB Olarak Sunuma Ekleme**
[ImageCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagecollection/) sınıfının yöntemleriyle, büyük bir görüntüyü BLOB olarak işlemek için akış olarak ekleyebilirsiniz.

Bu Python kodu, BLOB süreci kullanılarak büyük bir görüntünün nasıl ekleneceğini gösterir:

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
        # Görüntü dosyasına erişmeyi amaçlamadığımız için akışı kilitli tut.
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

Genellikle büyük bir sunumu yüklemek için bilgisayarlar çok fazla geçici bellek gerekir. Sunumun tüm içeriği belleğe yüklenir ve sunumun yüklendiği dosya artık kullanılmaz.

1,5 GB video dosyası içeren büyük bir PowerPoint sunumu (large.pptx) düşünün. Sunumu yüklemek için standart yöntem aşağıdaki Python kodunda açıklanmıştır:

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

Ancak bu yöntem yaklaşık 1,6 GB geçici bellek tüketir.

### **BLOB Olarak Büyük Sunum Yükleme**

BLOB içeren bir süreç sayesinde, az bellek kullanarak büyük bir sunumu yükleyebilirsiniz. Bu Python kodu, BLOB süreci kullanılarak büyük bir sunum dosyasının (large.pptx) nasıl yükleneceğini açıklar:

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

### **Geçici Dosyalar İçin Klasörü Değiştirme**

BLOB süreci kullanıldığında, bilgisayarınız geçici dosyaları varsayılan geçici dosya klasöründe oluşturur. Geçici dosyaların farklı bir klasörde tutulmasını istiyorsanız, [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) yöntemiyle depolama ayarlarını değiştirebilirsiniz:

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
[BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) yöntemini kullandığınızda, Aspose.Slides geçici dosyaları saklamak için bir klasör otomatik olarak oluşturmaz. Klasörü manuel olarak oluşturmanız gerekir.
{{% /alert %}}

### **Belleği Serbest Bırakmak İçin Sunum Nesnelerini Yok Etme**

Büyük sunumları işlerken, [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneğinin doğru şekilde yok edildiğinden emin olun; böylece kullandığı bellek serbest bırakılır. Sunumu kullandıktan sonra, yönetilmeyen kaynakları temizlemek için [Presentation.dispose](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#dispose) metodunu çağırın.

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

**Bir Aspose.Slides sunumunda hangi veriler BLOB olarak ele alınır ve BLOB seçenekleriyle kontrol edilir?**

Resimler, ses ve video gibi büyük ikili nesneler BLOB olarak ele alınır. Sunum dosyasının tamamı da yüklendiğinde veya kaydedildiğinde BLOB işleme dahildir. Bu nesneler, bellek kullanımını yönetmenize ve gerektiğinde geçici dosyalara dökülmesini kontrol eden BLOB politikalarıyla yönlendirilir.

**Sunum yüklenirken BLOB işleme kurallarını nerede yapılandırırım?**

[LoadOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/) ile [BlobManagementOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/blobmanagementoptions/) kullanın. Burada BLOB için bellek sınırını ayarlar, geçici dosyaların izin verilip verilmeyeceğini belirler, geçici dosyalar için kök yolu seçer ve kaynak kilitleme davranışını seçersiniz.

**BLOB ayarları performansı etkiler mi ve hız ile bellek arasında nasıl bir denge kurarım?**

Evet. BLOB’u bellek içinde tutmak hızı maksimize eder ancak RAM tüketimini artırır; bellek sınırını düşürmek daha çok işi geçici dosyalara yönlendirir, RAM’i azaltır ama ek I/O maliyeti getirir. İş yükünüz ve ortamınız için doğru dengeyi bulmak amacıyla [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/tr/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) metodunu kullanın.

**BLOB seçenekleri, çok büyük (örneğin gigabayt) sunumları açarken yardımcı olur mu?**

Evet. [BlobManagementOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/blobmanagementoptions/) bu senaryolar için tasarlanmıştır: geçici dosyaları etkinleştirmek ve kaynak kilitlemeyi kullanmak, tepe RAM kullanımını önemli ölçüde azaltabilir ve çok büyük slayt desteleri için işleme istikrarı sağlayabilir.

**Akışlardan disk dosyalarına göre BLOB politikalarını kullanabilir miyim?**

Evet. Aynı kurallar akışlar için de geçerlidir: sunum örneği (seçilen kilitleme moduna bağlı olarak) giriş akışına sahip olabilir ve kilitleyebilir, ve izin verildiğinde geçici dosyalar kullanılarak işlem sırasında bellek kullanımı öngörülebilir tutulur.