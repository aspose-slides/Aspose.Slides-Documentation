---
title: Python ile Sunumlarda BLOB'ları Yöneterek Verimli Bellek Kullanımı
linktitle: BLOB Yönetimi
type: docs
weight: 10
url: /tr/python-net/manage-blob/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET içinde BLOB verilerini yöneterek PowerPoint ve OpenDocument dosya işlemlerini kolaylaştırıp sunumların verimli işlenmesini sağlayın."
---
## **Genel Bakış**

Aspose.Slides, sunularda büyük ikili verileri (görseller, ses, video ve sunum dosyaları) işlemek için BLOB tabanlı bir işlem sağlar ve büyük dosyalarla çalışırken bellek tüketimini azaltmaya yardımcı olur.

Bu makale, bir sunuma büyük ortam eklemek, bir sunumdan büyük ortam dışa aktarmak ve büyük sunumları daha verimli bir şekilde yüklemek için BLOB tabanlı işlemenin nasıl kullanılacağını gösterir. Ayrıca işlem sırasında geçici dosyaların nasıl kullanılacağını ve bunların depolanacağı klasörün nasıl değiştirileceğini açıklar.

## **BLOB Hakkında**

**BLOB** (**Binary Large Object**), genellikle ikili formatta kaydedilen büyük bir öğe (fotoğraf, sunum, belge veya medya) anlamına gelir.

Aspose.Slides for Python via .NET, büyük dosyalar söz konusu olduğunda bellek tüketimini azaltacak şekilde nesneler için BLOB'ları kullanmanıza olanak tanır.

## **Belleği Azaltmak İçin BLOB Kullanımı**

### **Büyük Dosyayı BLOB Üzerinden Sunuma Ekleyin**

[Aspose.Slides](/slides/tr/python-net/) for .NET, bellek tüketimini azaltmak için BLOB içeren bir süreç aracılığıyla büyük dosyalar (bu örnekte büyük bir video dosyası) eklemenizi sağlar.

Bu Python örneği, bir video dosyasını BLOB süreciyle bir sunuma nasıl ekleyeceğinizi gösterir:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Videonun ekleneceği yeni bir sunum oluşturur
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Videoyu sunuma ekleyelim - KeepLocked davranışını seçtik çünkü
        # "veryLargeVideo.avi" dosyasına erişmeyi planlamıyoruz.
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Sunumu kaydeder. Büyük bir sunum dışa aktarılırken, bellek tüketimi
        # pres nesnesinin yaşam döngüsü boyunca düşük kalır
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **Büyük Dosyayı BLOB Üzerinden Sunumdan Dışa Aktarın**

Aspose.Slides for Python via .NET, sunumlardan BLOB içeren bir süreç aracılığıyla büyük dosyaları (bu örnekte bir ses veya video dosyası) dışa aktarmanıza olanak tanır. Örneğin, bir sunumdan büyük bir medya dosyasını çıkarmanız gerekebilir ancak dosyanın bilgisayarınızın belleğine yüklenmesini istemezsiniz. Dosyayı BLOB süreciyle dışa aktararak bellek tüketimini düşük tutarsınız.

Bu Python kodu, açıklanan işlemi gösterir:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Her videoyu bir dosyaya kaydedelim. Yüksek bellek kullanımını önlemek için kullanılacak bir tampon gereklidir
	# sunumun video akışından yeni oluşturulan video dosyası için bir akışa veriyi aktarmak için.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Videoları dolaşır
    index = 0
    # Gerekirse, aynı adımları ses dosyaları için de uygulayabilirsiniz. 
    for video in pres.videos:
		# Sunumun video akışını açar. Lütfen, özelliklere erişimden kasıtlı olarak kaçındığımızı unutmayın
		# örneğin video.BinaryData gibi - çünkü bu özellik tam bir video içeren bir bayt dizisi döndürür, bu da
		# baytların belleğe yüklenmesine neden olur. video.GetStream'i kullanıyoruz, bu bir Stream döndürür - ve
		#  bütün videoyu belleğe yüklememizi gerektirmez.
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **Sunuma Görüntüyü BLOB Olarak Ekleyin**

[**ImageCollection**](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imagecollection/) sınıfının yöntemleriyle, büyük bir görüntüyü akış olarak ekleyerek BLOB olarak işlenmesini sağlayabilirsiniz.

Bu Python kodu, bir görüntüyü BLOB süreciyle nasıl ekleyeceğinizi gösterir:

```py
import aspose.slides as slides

# görselin ekleneceği yeni bir sunum oluşturur.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Bellek ve Büyük Sunumlar**

Genellikle büyük bir sunumu yüklemek için bilgisayarlar çok miktarda geçici bellek gerektirir. Sunumun tüm içeriği belleğe yüklenir ve sunumun yüklendiği dosya artık kullanılmaz.

1,5 GB bir video dosyası içeren büyük bir PowerPoint sunumu (large.pptx) düşünün. Sunumu yüklemek için standart yöntem bu Python kodunda açıklanmıştır:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Ancak bu yöntem yaklaşık 1,6 GB geçici bellek tüketir.

### **Büyük Sunumu BLOB Olarak Yükleyin**

BLOB içeren bir süreç sayesinde büyük bir sunumu az bellek kullanarak yükleyebilirsiniz. Bu Python kodu, BLOB süreciyle büyük bir sunum dosyasını (large.pptx) nasıl yükleyeceğinizi açıklar:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **Geçici Dosyalar İçin Klasörü Değiştirin**

BLOB süreci kullanıldığında, bilgisayarınız geçici dosyaları varsayılan geçici dosya klasöründe oluşturur. Geçici dosyaların farklı bir klasörde tutulmasını istiyorsanız, `temp_files_root_path` kullanarak depolama ayarlarını değiştirebilirsiniz:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
`temp_files_root_path` kullandığınızda, Aspose.Slides geçici dosyaları saklamak için bir klasör otomatik olarak oluşturmaz. Klasörü manuel olarak oluşturmanız gerekir.
{{% /alert %}}

### **Sunum Nesnelerini Serbest Bırakarak Belleği Açın**

Büyük sunumları işlerken, [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneğinin düzgün bir şekilde sonlandırıldığından ve kapladığı belleğin serbest bırakıldığından emin olun. Önerilen yöntem, yukarıdaki örneklerde gösterildiği gibi bağlam yöneticisini (`with slides.Presentation(...) as presentation:`) kullanmaktır; blok sona erdiğinde sunumu otomatik olarak kapatır ve yönetilmeyen kaynakları serbest bırakır.

`with` bloğu kullanmadan bir sunum oluşturursanız, işiniz bittiğinde açıkça `presentation.dispose()` çağırın ve Python'un çöp toplayıcısının belleği geri kazanabilmesi için kalan referansları kaldırın.

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...sunumu işleyin...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# Kaynakları açıkça serbest bırak.
presentation.dispose()
```

## **SSS**

**Aspose.Slides sunumunda hangi veriler BLOB olarak işlenir ve BLOB seçenekleri tarafından kontrol edilir?**  
Görüntüler, ses ve video gibi büyük ikili nesneler BLOB olarak işlenir. Sunumun tamamı da yüklendiğinde veya kaydedildiğinde BLOB işleme tabi tutulur. Bu nesneler, bellek kullanımını yönetmenizi ve gerektiğinde geçici dosyalara geçiş yapmanızı sağlayan BLOB politikalarıyla denetlenir.

**Sunumu yüklerken BLOB işleme kurallarını nerede yapılandırırım?**  
[LoadOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/) ile [BlobManagementOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/blobmanagementoptions/) kullanın. Bu seçeneklerde BLOB için bellek içi sınırı ayarlayabilir, geçici dosyaları izin verip vermemeyi belirleyebilir, geçici dosyalar için kök yolu seçebilir ve kaynak kilitleme davranışını seçebilirsiniz.

**BLOB ayarları performansı etkiler mi ve hız ile bellek arasında nasıl bir denge kurarım?**  
Evet. BLOB'u bellek içinde tutmak hızı en üst düzeye çıkarır ancak RAM tüketimini artırır; bellek sınırını düşürmek daha fazla işi geçici dosyalara yönlendirir, RAM'i azaltır ancak ek I/O maliyeti getirir. İş yükünüz ve ortamınız için doğru dengeyi bulmak amacıyla [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/tr/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) eşiğini ayarlayın.

**BLOB seçenekleri çok büyük sunumları (örneğin gigabayt ölçeğinde) açarken yardımcı olur mu?**  
Evet. [BlobManagementOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/blobmanagementoptions/) bu senaryolar için tasarlanmıştır: geçici dosyaları etkinleştirmek ve kaynak kilitlemeyi kullanmak, tepe RAM kullanımını önemli ölçüde azaltabilir ve çok büyük sunumların işlenmesini istikrara kavuşturabilir.

**Disk dosyaları yerine akışlardan yüklerken BLOB politikalarını kullanabilir miyim?**  
Evet. Aynı kurallar akışlar için de geçerlidir: sunum örneği, seçilen kilitleme moduna bağlı olarak giriş akışını sahiplenebilir ve kilitleyebilir; izin verildiği takdirde geçici dosyalar kullanılır ve işlem sırasında bellek kullanımı tahmin edilebilir olur.