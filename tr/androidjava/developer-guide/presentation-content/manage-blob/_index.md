---
title: "Android'de Sunum BLOB'larını Yöneterek Verimli Bellek Kullanımı"
linktitle: "BLOB'u Yönet"
type: docs
weight: 10
url: /tr/androidjava/manage-blob/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'da BLOB verilerini yöneterek PowerPoint ve OpenDocument dosya işlemlerini verimli sunum işleme için basitleştirin."
---
## **Genel Bakış**

Aspose.Slides, sunumlardaki büyük ikili verileri (görüntüler, ses, video ve sunum dosyaları) BLOB tabanlı işleyerek bellek tüketimini azaltmaya yardımcı olur.

Bu makale, BLOB tabanlı işleme kullanarak bir sunuma büyük medya eklemeyi, bir sunumdan büyük medya dışa aktarmayı ve büyük sunumları daha verimli yüklemeyi gösterir. Ayrıca işleme sırasında geçici dosyaların nasıl kullanılacağını ve bunların depolanacağı klasörün nasıl değiştirileceğini açıklar.

## **BLOB Hakkında**

**BLOB** (**Binary Large Object**), genellikle ikili biçimde kaydedilen büyük bir öğe (fotoğraf, sunum, belge veya medya) anlamına gelir.  

Aspose.Slides for Android via Java, büyük dosyalar söz konusu olduğunda bellek tüketimini azaltan bir yöntemle nesneler için BLOB kullanmanıza olanak tanır.

{{% alert title="Info" color="info" %}}
Akışlarla etkileşimde belirli sınırlamaları aşmak için Aspose.Slides akışın içeriğini kopyalayabilir. Bir büyük sunumu akış üzerinden yüklemek, sunum içeriğinin kopyalanmasına ve yavaş yüklemeye neden olur. Bu nedenle, büyük bir sunumu yüklemeyi planladığınızda, akış yerine sunum dosya yolunu kullanmanızı şiddetle öneririz.
{{% /alert %}}

## **Bellek Tüketimini Azaltmak için BLOB Kullanma**

### **BLOB aracılığıyla bir sunuma büyük bir dosya ekleme**

[Aspose.Slides](/slides/tr/androidjava/) for Java, bellek tüketimini azaltmak için BLOB sürecini kullanarak büyük dosyalar (bu örnekte büyük bir video dosyası) eklemenizi sağlar.

Bu Java örneği, bir BLOB süreciyle büyük bir video dosyasını bir sunuma nasıl ekleyeceğinizi gösterir:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Videonun ekleneceği yeni bir sunum oluşturur
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Videoyu sunuma ekleyelim - KeepLocked davranışını seçtik çünkü
        // "veryLargeVideo.avi" dosyasına erişmeyi amaçlamıyoruz.
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Sunumu kaydeder. Büyük bir sunum çıktısı alınırken, bellek tüketimi
        // pres nesnesinin yaşam döngüsü boyunca düşük kalır 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **BLOB kullanarak bir sunumdan büyük bir dosya dışa aktarma**
Aspose.Slides for Android via Java, BLOB sürecini kullanarak sunumlardan büyük dosyalar (örneğin ses veya video dosyaları) dışa aktarabilir. Örneğin, bir sunumdan büyük bir medya dosyasını çıkarmanız gerekebilir ancak dosyanın bilgisayarınızın belleğine yüklenmesini istemezsiniz. Dosyayı BLOB süreciyle dışa aktararak bellek tüketimini düşük tutabilirsiniz.

Bu Java kodu, anlatılan işlemi gösterir:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Kaynak dosyayı kilitler ve belleğe YÜKLEMEZ
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// Presentation örneğini oluşturur, "hugePresentationWithAudiosAndVideos.pptx" dosyasını kilitler.
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Her videoyu bir dosyaya kaydedelim. Yüksek bellek kullanımını önlemek için bir tampon gereklidir
    // bu tampon, sunumun video akışından yeni video dosyası için bir akışa verileri aktarmak için kullanılacaktır.
    byte[] buffer = new byte[8 * 1024];

    // Videoları iterasyonla dolaşır
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Sunum video akışını açar. Lütfen, özelliklere erişmekten kasten kaçındığımızı unutmayın
        // video.BinaryData gibi - çünkü bu özellik tam bir video içeren bir bayt dizisi döndürür, bu da
        // baytların belleğe yüklenmesine neden olur. video.GetStream'i kullanıyoruz, bu bir Stream döndürür ve YÜKLEMEZ
        //  bütün videoyu belleğe yüklememizi gerektirmez.
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // Bellek tüketimi, video ya da sunum boyutundan bağımsız olarak düşük kalacaktır.
    }
    // Gerekirse, aynı adımları ses dosyaları için de uygulayabilirsiniz. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Bir sunuma BLOB olarak resim ekleme**
[IImageCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IImageCollection) arabirimi ve [ImageCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ImageCollection) sınıfındaki yöntemlerle, büyük bir resmi bir akış olarak ekleyip BLOB olarak işleyebilirsiniz.

Bu Java kodu, BLOB süreciyle büyük bir resmi nasıl ekleyeceğinizi gösterir:

```java
String pathToLargeImage = "large_image.jpg";

// yeni bir sunum oluşturur ve görüntünün ekleneceği sunumu hazırlar.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Görüntüyü sunuma ekleyelim - KeepLocked davranışını seçiyoruz çünkü
		// “largeImage.png” dosyasına erişmeyi amaçlamıyoruz.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Sunumu kaydeder. Büyük bir sunum üretilirken, bellek tüketimi
		// pres nesnesinin yaşam döngüsü boyunca düşük kalır
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Bellek ve Büyük Sunumlar**

Genellikle, büyük bir sunumu yüklemek için bilgisayarların çok fazla geçici belleğe ihtiyacı olur. Sunumun tüm içeriği belleğe yüklenir ve sunumun yüklendiği dosya artık kullanılmaz.

1,5 GB video dosyası içeren büyük bir PowerPoint sunumu (large.pptx) düşünün. Sunumu yüklemek için standart yöntem aşağıdaki Java kodunda açıklanmıştır:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Ancak bu yöntem yaklaşık 1,6 GB geçici bellek tüketir.

### **BLOB olarak büyük bir sunumu yükleme**

BLOB süreci sayesinde, çok az bellek kullanarak büyük bir sunumu yükleyebilirsiniz. Aşağıdaki Java kodu, BLOB süreci kullanılarak büyük bir sunum dosyasının (large.pptx) nasıl yükleneceğini açıklar:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Geçici Dosyalar İçin Klasörü Değiştirme**

BLOB süreci kullanıldığında, bilgisayarınız geçici dosyaları varsayılan geçici dosya klasöründe oluşturur. Geçici dosyaların farklı bir klasörde tutulmasını istiyorsanız, `TempFilesRootPath` kullanarak depolama ayarlarını değiştirebilirsiniz:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
`TempFilesRootPath` kullandığınızda Aspose.Slides geçici dosyaları depolamak için otomatik olarak bir klasör oluşturmaz. Klasörü manuel olarak oluşturmanız gerekir.
{{% /alert %}}

### **Belleği Serbest Bırakmak İçin Sunum Nesnelerini Yok Etme**

Büyük sunumları işlerken, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneğinin doğru bir şekilde yok edildiğinden emin olun; böylece kapladığı bellek serbest bırakılır. Sunumu kullandıktan sonra `dispose()` metodunu çağırarak yönetilmeyen kaynakları serbest bırakın.

```java
Presentation presentation = new Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **SSS**

**Aspose.Slides sunumunda hangi veriler BLOB olarak ele alınır ve BLOB seçenekleriyle kontrol edilir?**  
Görseller, ses ve video gibi büyük ikili nesneler BLOB olarak ele alınır. Sunum dosyasının tamamı da yüklendiğinde veya kaydedildiğinde BLOB işleme dahil olur. Bu nesneler, bellek kullanımını yönetmenizi ve gerektiğinde geçici dosyalara yönlendirmenizi sağlayan BLOB politikalarıyla yönetilir.

**Sunum yüklerken BLOB işleme kurallarını nerede yapılandırırım?**  
[LoadOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/) ile [BlobManagementOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/blobmanagementoptions/) kullanın. Burada BLOB için bellek sınırını ayarlar, geçici dosyaların kullanılmasını izin verip vermeyeceğinizi belirler, geçici dosyalar için kök yolu seçer ve kaynak kilitleme davranışını seçersiniz.

**BLOB ayarları performansı etkiler mi ve hız ile bellek arasındaki dengeyi nasıl kurarım?**  
Evet. BLOB’u bellek içinde tutmak hızı maksimize eder ancak RAM tüketimini artırır; bellek sınırını düşürmek daha fazla işi geçici dosyalara yönlendirir, RAM’i azaltır ancak ek I/O maliyeti getirir. İş yükünüze ve ortamınıza uygun dengeyi sağlamak için [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) metodunu kullanın.

**BLOB seçenekleri, çok büyük (örneğin gigabayt seviyesinde) sunumları açarken yardımcı olur mu?**  
Evet. [BlobManagementOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/blobmanagementoptions/) bu senaryolar için tasarlanmıştır: geçici dosyaları etkinleştirmek ve kaynak kilitlemeyi kullanmak, tepe RAM kullanımını önemli ölçüde azaltabilir ve çok büyük sunumların işlenmesini istikrarlı hale getirebilir.

**Akışlardan dosya yerine yükleme yaparken BLOB politikalarını kullanabilir miyim?**  
Evet. Aynı kurallar akışlar için de geçerlidir: sunum örneği, seçilen kilitleme moduna bağlı olarak giriş akışını sahiplenebilir ve kilitleyebilir; izin verildiğinde geçici dosyalar kullanılır ve işlem sırasında bellek kullanımı öngörülebilir olur.