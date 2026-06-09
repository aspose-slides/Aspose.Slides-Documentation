---
title: "JavaScript'te Sunum BLOB'larını Yöneterek Verimli Bellek Kullanımı"
linktitle: "BLOB'u Yönet"
type: docs
weight: 10
url: /tr/nodejs-java/manage-blob/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js için Aspose.Slides ile JavaScript'te BLOB verilerini yöneterek PowerPoint ve OpenDocument dosya işlemlerini kolaylaştırın ve sunumların verimli bir şekilde işlenmesini sağlayın."
---
## **Genel Bakış**

Aspose.Slides, sunumlarda büyük ikili verileri BLOB tabanlı işleyerek büyük resimler, ses, video ve sunum dosyalarıyla çalışırken bellek tüketimini azaltmaya yardımcı olur.

Bu makale, BLOB tabanlı işleme kullanarak bir sunuma büyük medya eklemeyi, bir sunumdan büyük medya dışa aktarmayı ve büyük sunumları daha verimli yüklemeyi gösterir. Ayrıca işleme sırasında geçici dosyaların nasıl kullanılacağını ve bunların depolanacağı klasörün nasıl değiştirileceğini açıklar.

## **BLOB Hakkında**

**BLOB** (**Binary Large Object**) genellikle ikili formatlarda kaydedilen büyük bir öğedir (fotoğraf, sunum, belge veya medya).

Aspose.Slides for Node.js via Java, büyük dosyalar söz konusu olduğunda bellek tüketimini azaltan bir şekilde nesneler için BLOB'ları kullanmanıza olanak tanır.

{{% alert title="Info" color="info" %}}
Akışlarla etkileşimde belirli sınırlamaları aşmak için Aspose.Slides akışın içeriğini kopyalayabilir. Akış üzerinden büyük bir sunumu yüklemek, sunum içeriğinin kopyalanmasına ve yavaş yüklemeye neden olur. Bu nedenle, büyük bir sunumu yüklemeyi planladığınızda, akış yerine sunum dosya yolunu kullanmanızı şiddetle öneririz.
{{% /alert %}}

## **Bellek Tüketimini Azaltmak için BLOB Kullanma**

### **BLOB aracılığıyla Sunuma Büyük Dosya Ekleme**

[Aspose.Slides](/slides/tr/nodejs-java/) for Node.js via Java, büyük dosyaları (bu örnekte büyük bir video dosyası) BLOB içeren bir süreç üzerinden eklemenize ve bellek tüketimini azaltmanıza olanak tanır.

Bu JavaScript, BLOB süreci aracılığıyla bir sunuma büyük bir video dosyasının nasıl ekleneceğini gösterir:

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// Videonun ekleneceği yeni bir sunum oluşturur
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // Videoyu sunuma ekleyelim - KeepLocked davranışını seçtik çünkü
        // "veryLargeVideo.avi" dosyasına erişmeyi amaçlamıyoruz.
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // Sunumu kaydeder. Büyük bir sunum çıktılanırken, bellek tüketimi
        // pres nesnesinin yaşam döngüsü boyunca düşük kalır
        pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **BLOB aracılığıyla Sunumdan Büyük Dosya Dışa Aktarma**

Aspose.Slides for Node.js via Java, sunumlardan büyük dosyaları (bu örnekte bir ses veya video dosyası) BLOB içeren bir süreç aracılığıyla dışa aktarmanıza olanak tanır. Örneğin, bir sunumdan büyük bir medya dosyasını çıkarmanız gerekebilir ancak dosyanın bilgisayarınızın belleğine yüklenmesini istemezsiniz. Dosyayı BLOB süreciyle dışa aktararak bellek tüketimini düşük tutarsınız.

Bu JavaScript kodu, açıklanan işlemi gösterir:

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Kaynak dosyayı kilitler ve belleğe YÜKLEMEZ
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// Sunum örneğini oluşturur, "hugePresentationWithAudiosAndVideos.pptx" dosyasını kilitler.
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Her videoyu bir dosyaya kaydedelim. Yüksek bellek kullanımını önlemek için kullanılacak bir tampon gerekir
    // sunumun video akışından yeni oluşturulan video dosyasının akışına veriyi aktarmak için.
    var buffer = new byte[8 * 1024];
    // Videoları döngüyle iterasyon eder
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // Sunum video akışını açar. Lütfen, kasıtlı olarak özelliklere erişmekten kaçındığımızı not edin
        // örneğin video.BinaryData - çünkü bu özellik tam bir video içeren bir bayt dizisi döndürür, bu da
        // baytların belleğe yüklenmesine neden olur. video.GetStream kullanıyoruz, bu bir Stream döndürür ve YÜKLEMEZ
        // bütün videoyu belleğe yüklememizi gerektirmez.
        var presVideoStream = video.getStream();
        try {
            var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
            try {
                var bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // Bellek tüketimi, videonun ya da sunumun boyutu ne olursa olsun düşük kalacaktır.
    }
    // Gerekirse, aynı adımları ses dosyaları için de uygulayabilirsiniz.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **Sunumda Görüntüyü BLOB Olarak Ekleme**

Bu sınıflardan [**ImageCollection**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ImageCollection) ve [**ImageCollection** ](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ImageCollection) metodlarıyla, büyük bir resmi akış olarak ekleyerek BLOB olarak işlenmesini sağlayabilirsiniz.

Bu JavaScript kodu, BLOB süreciyle büyük bir resmi nasıl ekleyeceğinizi gösterir:

```javascript
var pathToLargeImage = "large_image.jpg";
// görüntünün ekleneceği yeni bir sunum oluşturur.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // Görüntüyü sunuma ekleyelim - KeepLocked davranışını seçiyoruz çünkü
        // "largeImage.png" dosyasına erişmeyi amaçlamıyoruz.
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // Sunumu kaydeder. Büyük bir sunum çıktılanırken, bellek tüketimi
        // pres nesnesinin yaşam döngüsü boyunca düşük kalır
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bellek ve Büyük Sunumlar**

Genellikle, büyük bir sunumu yüklemek için bilgisayarlar çok fazla geçici bellek gerektirir. Sunumun tüm içeriği belleğe yüklenir ve sunumun yüklendiği dosya artık kullanılmaz.

1.5 GB video dosyası içeren büyük bir PowerPoint sunumu (large.pptx) düşünün. Sunumu yüklemenin standart yöntemi bu JavaScript kodunda açıklanmıştır:

```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ancak bu yöntem yaklaşık 1.6 GB geçici bellek tüketir.

### **BLOB olarak Büyük Sunum Yükleme**

BLOB içeren bir süreç sayesinde, az bellek kullanarak büyük bir sunumu yükleyebilirsiniz. Bu JavaScript kodu, BLOB sürecinin büyük bir sunum dosyasını (large.pptx) yüklemek için kullanıldığı uygulamayı açıklamaktadır:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Geçici Dosyalar İçin Klasörü Değiştirme**

BLOB süreci kullanıldığında, bilgisayarınız geçici dosyaları varsayılan geçici dosya klasöründe oluşturur. Geçici dosyaların farklı bir klasörde tutulmasını istiyorsanız, `setTempFilesRootPath` kullanarak depolama ayarlarını değiştirebilirsiniz:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
`setTempFilesRootPath` kullandığınızda, Aspose.Slides geçici dosyaları depolamak için otomatik olarak bir klasör oluşturmaz. Klasörü manuel olarak oluşturmanız gerekir.
{{% /alert %}}

### **Belleği Serbest Bırakmak için Sunum Nesnelerini Yok Etme**

Büyük sunumları işlerken, [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneğinin doğru şekilde yok edildiğinden emin olun, böylece kapladığı bellek serbest bırakılır. Sunumu kullanmayı tamamladıktan sonra `dispose()` çağırarak yönetilmeyen kaynakları serbest bırakın.

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **SSS**

**Aspose.Slides bir sunumunda hangi veriler BLOB olarak ele alınır ve BLOB seçenekleri tarafından kontrol edilir?**

BLOB olarak ele alınan büyük ikili nesneler arasında resimler, ses ve videolar bulunur. Sunum dosyasının tamamı da yüklendiğinde veya kaydedildiğinde BLOB işleme dahildir. Bu nesneler, bellek kullanımını yönetmenize ve gerektiğinde geçici dosyalara dökülmesini sağlayan BLOB politikalarıyla kontrol edilir.

**Sunum yüklenirken BLOB işleme kurallarını nerede yapılandırırım?**

[LoadOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/) ile [BlobManagementOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/blobmanagementoptions/) kullanın. Burada BLOB için bellek içi limitini ayarlayabilir, geçici dosyalara izin verip vermeyeceğinizi belirleyebilir, geçici dosyalar için kök yolu seçebilir ve kaynak kilitleme davranışını seçebilirsiniz.

**BLOB ayarları performansı etkiler mi ve hız ile bellek arasında nasıl bir denge kurarım?**

Evet. BLOB'un bellekte tutulması hızı en üst düzeye çıkarır ancak RAM tüketimini artırır; bellek limitini düşürmek daha fazla işi geçici dosyalara kaydırarak RAM'i azaltır ancak ek I/O maliyeti getirir. Çalışma yükünüze ve ortamınıza uygun dengeyi sağlamak için [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) yöntemini kullanın.

**BLOB seçenekleri, çok büyük sunumları (örneğin gigabayt seviyesinde) açarken yardımcı olur mu?**

Evet. [BlobManagementOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/blobmanagementoptions/) bu senaryolar için tasarlanmıştır: geçici dosyaları etkinleştirmek ve kaynak kilitlemeyi kullanmak, çok büyük sunumların en yüksek RAM kullanımını önemli ölçüde azaltabilir ve işleme sürecini istikrarlı hale getirebilir.

**Disk dosyaları yerine akışlardan yüklerken BLOB politikalarını kullanabilir miyim?**

Evet. Aynı kurallar akışlar için de geçerlidir: sunum örneği giriş akışına sahip olabilir ve onu kilitleyebilir (seçilen kilitleme moduna bağlı olarak), ve izin verildiğinde geçici dosyalar kullanılarak işlem sırasında bellek kullanımı öngörülebilir kalır.