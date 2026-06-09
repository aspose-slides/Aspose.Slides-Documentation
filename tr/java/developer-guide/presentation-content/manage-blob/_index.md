---
title: Java'da Sunum BLOB'larını Verimli Bellek Kullanımı İçin Yönetme
linktitle: BLOB Yönet
type: docs
weight: 10
url: /tr/java/manage-blob/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da BLOB verilerini yöneterek PowerPoint ve OpenDocument dosya işlemlerini basitleştirin ve sunumları verimli bir şekilde işleyin."
---
## **Genel Bakış**

Aspose.Slides, sunumlarda büyük ikili verileri (büyük resimler, ses, video ve sunum dosyaları) işlemek için BLOB tabanlı bir çözüm sunar ve bellek tüketimini azaltmaya yardımcı olur.

Bu makale, BLOB tabanlı işleme kullanarak bir sunuma büyük medya eklemeyi, sunumdan büyük medya dışa aktarmayı ve büyük sunumları daha verimli şekilde yüklemeyi gösterir. Ayrıca işleme sırasında geçici dosyaların nasıl kullanılacağını ve bu dosyaların depolanacağı klasörün nasıl değiştirileceğini açıklar.

## **BLOB Hakkında**

**BLOB** (**Binary Large Object**) genellikle ikili formatta kaydedilen büyük bir öğedir (fotoğraf, sunum, belge veya medya).

Aspose.Slides for Java, büyük dosyalar söz konusu olduğunda bellek tüketimini azaltan bir şekilde nesneler için BLOB kullanmanıza izin verir.

{{% alert title="Info" color="info" %}}
Akışlarla etkileşimde belirli sınırlamaları aşmak için Aspose.Slides akışın içeriğini kopyalayabilir. Bir büyük sunumu akışı üzerinden yüklemek, sunumun içeriğinin kopyalanmasına ve yavaş yüklenmeye neden olur. Bu nedenle büyük bir sunumu yüklemeyi planladığınızda, akış yerine sunum dosya yolunu kullanmanızı şiddetle öneririz.
{{% /alert %}}

## **BLOB Kullanarak Bellek Tüketimini Azaltma**

### **Büyük Bir Dosyayı BLOB Olarak Sunuma Ekle**

[Aspose.Slides](/slides/tr/java/) for Java, büyük dosyaları (bu örnekte büyük bir video dosyası) BLOB süreci aracılığıyla eklemenize ve bellek tüketimini azaltmanıza olanak tanır.

Bu Java örneği, BLOB süreciyle bir sunuma büyük bir video dosyası eklemenizi gösterir:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Yeni bir sunum oluşturur ve video eklenecek
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Sunuma videoyu ekleyelim - KeepLocked davranışını seçtik çünkü
        // "veryLargeVideo.avi" dosyasına erişmeyi amaçlamıyoruz.
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Sunumu kaydeder. Büyük bir sunum çıkartılırken, bellek tüketimi
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

### **Büyük Bir Dosyayı BLOB Olarak Sunumdan Dışa Aktar**
Aspose.Slides for Java, sunumlardan büyük dosyaları (örneğin bir ses veya video dosyasını) BLOB süreci aracılığıyla dışa aktarmanıza olanak tanır. Örneğin, bir sunumdan büyük bir medya dosyasını çıkartmanız gerekebilir ancak dosyanın bilgisayarınızın belleğine yüklenmesini istemezsiniz. BLOB süreciyle dosyayı dışa aktararak bellek tüketimini düşük tutabilirsiniz.

Bu Java kodu, açıklanan işlemi göstermektedir:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Kaynak dosyayı kilitler ve belleğe yüklemez
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// Presentation nesnesinin örneğini oluşturur, "hugePresentationWithAudiosAndVideos.pptx" dosyasını kilitler.
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Her videoyu bir dosyaya kaydedelim. Yüksek bellek kullanımını önlemek için, sunumun video akışından yeni oluşturulan video dosyasına veri aktarımında kullanılacak bir tampon gereklidir.
    // 
    byte[] buffer = new byte[8 * 1024];

    // Videoları yineleyerek dolaşır
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Sunumun video akışını açar. Lütfen, özelliklere erişmekten kasıtlı olarak kaçındığımızı unutmayın
        // video.BinaryData gibi - çünkü bu özellik tam bir video içeren bir bayt dizisi döndürür, bu da
        // baytların belleğe yüklenmesine neden olur. video.GetStream'i kullanıyoruz, bu bir Stream döndürür - ve BELLEĞE
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
        // Bellek tüketimi, video ya da sunumun boyutuna bakılmaksızın düşük kalacaktır.
    }
    // Gerekirse, ses dosyaları için aynı adımları uygulayabilirsiniz. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Bir Görüntüyü BLOB Olarak Sunuma Ekle**
[**IImageCollection**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IImageCollection) arayüzü ve [**ImageCollection**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ImageCollection) sınıfı yöntemleriyle, bir akış olarak büyük bir görüntüyü ekleyebilir ve bunun BLOB olarak işlenmesini sağlayabilirsiniz.

Bu Java kodu, BLOB süreciyle büyük bir görüntünün nasıl ekleneceğini gösterir:

```java
String pathToLargeImage = "large_image.jpg";

// görüntünün ekleneceği yeni bir sunum oluşturur.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Görüntüyü sunuma ekleyelim - KeepLocked davranışını seçiyoruz çünkü
		// "largeImage.png" dosyasına erişmeyi amaçlamıyoruz.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Sunumu kaydeder. Büyük bir sunum çıktısı alınırken, bellek tüketimi
		// pres nesnesinin yaşam döngüsü boyunca düşük kalır.
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

Genellikle büyük bir sunumu yüklemek için bilgisayarların çok fazla geçici bellek gerektirir. Sunumun tüm içeriği belleğe yüklenir ve sunumun yüklendiği dosya artık kullanılmaz.

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

### **Büyük Sunumu BLOB Olarak Yükle**

BLOB sürecini kullanarak, az bellek harcayarak büyük bir sunumu yükleyebilirsiniz. Bu Java kodu, BLOB sürecinin large.pptx dosyasını yüklemek için nasıl kullanıldığını açıklamaktadır:

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

### **Geçici Dosyalar İçin Klasörü Değiştir**

BLOB süreci kullanıldığında, bilgisayarınız geçici dosyaları varsayılan geçici dosya klasöründe oluşturur. Geçici dosyaların farklı bir klasörde tutulmasını istiyorsanız, `TempFilesRootPath` kullanarak depolama ayarlarını değiştirebilirsiniz:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
`TempFilesRootPath` kullandığınızda, Aspose.Slides geçici dosyalar için otomatik olarak bir klasör oluşturmaz. Klasörü manuel olarak oluşturmanız gerekir.
{{% /alert %}}

### **Belleği Serbest Bırakmak İçin Sunum Nesnelerini Yok Et**

Büyük sunumları işlerken, [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) örneğinin doğru bir şekilde yok edildiğinden emin olun; böylece kullandığı bellek serbest bırakılır. Sunumu kullanmayı bitirdiğinizde, yönetilmeyen kaynakları temizlemek için `dispose()` çağırın.

```java
Presentation presentation = new Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **SSS**

**Aspose.Slides sunumunda hangi veriler BLOB olarak ele alınır ve BLOB seçenekleri tarafından kontrol edilir?**  
Görseller, ses ve video gibi büyük ikili nesneler BLOB olarak ele alınır. Sunum dosyasının tamamı da yüklendiğinde veya kaydedildiğinde BLOB işleme dahil olur. Bu nesneler, bellek kullanımını yönetmenize ve gerektiğinde geçici dosyalara dökülmesini sağlayan BLOB politikaları tarafından kontrol edilir.

**Sunum yüklenirken BLOB işleme kurallarını nerede yapılandırırım?**  
[LoadOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/) ile birlikte [BlobManagementOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/blobmanagementoptions/) kullanın. Burada BLOB için bellek sınırını ayarlayabilir, geçici dosyaların izin verilip verilmediğini belirleyebilir, geçici dosyalar için kök yolu seçebilir ve kaynak kilitleme davranışını seçebilirsiniz.

**BLOB ayarları performansı etkiler mi ve hız ile bellek arasındaki dengeyi nasıl kurarım?**  
Evet. BLOB’u bellek içinde tutmak hızı maksimize eder ancak RAM tüketimini artırır; bellek sınırını düşürmek daha fazla işi geçici dosyalara yönlendirir, RAM’i azaltır ancak ekstra I/O maliyeti getirir. Çalışma yükünüze ve ortamınıza uygun dengeyi sağlamak için [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/tr/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) metodunu kullanın.

**BLOB seçenekleri, çok büyük (ör. gigabayt seviyesinde) sunumları açarken yardımcı olur mu?**  
Evet. [BlobManagementOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/blobmanagementoptions/) bu senaryolar için tasarlanmıştır: geçici dosyaları etkinleştirmek ve kaynak kilitlemeyi kullanmak, büyük sunumların en yüksek RAM kullanımını önemli ölçüde azaltabilir ve işleme stabilitesini artırabilir.

**Akışlardan (disk dosyaları yerine) yüklerken BLOB politikalarını kullanabilir miyim?**  
Evet. Aynı kurallar akışlar için de geçerlidir: sunum örneği, seçilen kilitleme moduna bağlı olarak giriş akışını sahiplenebilir ve kilitleyebilir; izin verildiğinde geçici dosyalar kullanılacak ve işleme sırasında bellek kullanımı öngörülebilir olacaktır.