---
title: PHP'de Sunum BLOB'larını Yöneterek Etkin Bellek Kullanımı
linktitle: BLOB Yönet
type: docs
weight: 10
url: /tr/php-java/manage-blob/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java’da BLOB verilerini yöneterek PowerPoint ve OpenDocument dosya işlemlerini kolaylaştırın ve etkili sunum işleme sağlayın."
---
## **Genel Bakış**

Aspose.Slides, sunumlarda büyük ikili veriler için BLOB tabanlı işleme sağlar; bu sayede büyük görüntüler, ses, video ve sunum dosyalarıyla çalışırken bellek tüketimini azaltır.

Bu makale, BLOB tabanlı işleme kullanarak bir sunuma büyük medya eklemeyi, bir sunumdan büyük medya dışa aktarmayı ve büyük sunumları daha verimli bir şekilde yüklemeyi gösterir. Ayrıca işleme sırasında geçici dosyaların nasıl kullanılacağını ve bu dosyaların depolanacağı klasörün nasıl değiştirileceğini açıklar.

## **BLOB Hakkında**

**BLOB** (**Binary Large Object**) genellikle ikili formatta kaydedilen büyük bir öğedir (fotoğraf, sunum, belge veya medya).

Aspose.Slides for PHP via Java, büyük dosyalar söz konusu olduğunda bellek tüketimini azaltan bir şekilde BLOB'ları nesneler için kullanmanıza olanak tanır.

{{% alert title="Info" color="info" %}}
Akışlarla etkileşimde belirli sınırlamaları aşmak için Aspose.Slides akış içeriğini kopyalayabilir. Bir büyük sunumu akışı üzerinden yüklemek, sunum içeriğinin kopyalanmasına ve yavaş yüklemeye neden olur. Bu nedenle, büyük bir sunumu yüklemeyi planladığınızda, akış yerine sunum dosya yolunu kullanmanız şiddetle tavsiye edilir.
{{% /alert %}}

## **Belleği Azaltmak İçin BLOB Kullanımı**

### **BLOB ile Bir Sunuma Büyük Dosya Eklemek**

[Aspose.Slides](/slides/tr/php-java/) for Java, bellek tüketimini azaltmak için BLOB içeren bir süreçle büyük dosyalar (bu örnekte büyük bir video dosyası) eklemenize olanak tanır.

Bu Java örneği, BLOB süreciyle bir sunuma büyük bir video dosyası nasıl eklenir gösterir:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Videonun ekleneceği yeni bir sunum oluşturur
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Videoyu sunuma ekleyelim - KeepLocked davranışını seçtik çünkü
      # "veryLargeVideo.avi" dosyasına erişmeyi düşünmüyoruz.
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Sunumu kaydeder. Büyük bir sunum çıktılanırken, bellek tüketimi
      # pres nesnesinin yaşam döngüsü boyunca düşük kalır
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **BLOB ile Bir Sunumdan Büyük Dosya Dışa Aktarmak**
Aspose.Slides for PHP via Java, BLOB içeren bir süreçle sunumlardan büyük dosyalar (örneğin ses veya video dosyası) dışa aktarmanıza olanak tanır. Örneğin, bir sunumdan büyük bir medya dosyasını çıkartmanız gerekebilir, ancak dosyanın bilgisayarınızın belleğine yüklenmesini istemezsiniz. BLOB süreciyle dışa aktararak bellek tüketimini düşük tutarsınız.

Bu kod, açıklanan işlemi göstermektedir:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Kaynak dosyayı kilitler ve belleğe yüklemez
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # Sunum örneğini oluşturur, "hugePresentationWithAudiosAndVideos.pptx" dosyasını kilitler.
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Her videoyu bir dosyaya kaydedelim. Yüksek bellek kullanımını önlemek için kullanılacak bir tampon gerekir
    # sunumun video akışından yeni oluşturulan bir video dosyasının akışına veriyi aktarmak için.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Videoları dolaşır
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Sunum video akışını açar. Lütfen, özelliklere erişmekten bilinçli olarak kaçındığımızı unutmayın
      # örneğin video.BinaryData gibi - çünkü bu özellik tam bir videoyu içeren bir byte dizisi döndürür, bu da
      # baytların belleğe yüklenmesine neden olur. video.GetStream'i kullanıyoruz, bu bir Stream döndürür - ve
      # tüm videoyu belleğe yüklememizi gerektirmez.
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # Bellek tüketimi video ya da sunumun boyutuna bakılmaksızın düşük kalacaktır.
    }
    # Gerekirse, aynı adımları ses dosyaları için de uygulayabilirsiniz.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **Bir Görüntüyü BLOB Olarak Sunuma Eklemek**
[ImageCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagecollection/) sınıfının yöntemleriyle büyük bir görüntüyü BLOB olarak işlemek için akış olarak ekleyebilirsiniz.

Bu PHP kodu, BLOB süreciyle büyük bir görüntünün nasıl ekleneceğini gösterir:

```php
  $pathToLargeImage = "large_image.jpg";
  # görüntünün ekleneceği yeni bir sunum oluşturur.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Görüntüyü sunuma ekleyelim - KeepLocked davranışını seçiyoruz çünkü
      # "largeImage.png" dosyasına erişmeyi düşünmüyoruz.
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Sunumu kaydeder. Büyük bir sunum çıktılanırken, bellek tüketimi
      # pres nesnesinin yaşam döngüsü boyunca düşük kalır
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bellek ve Büyük Sunumlar**

Genellikle büyük bir sunumu yüklemek için bilgisayarların çok fazla geçici belleğe ihtiyacı olur. Sunumun tüm içeriği belleğe yüklenir ve sunumun yüklendiği dosya artık kullanılmaz.

1,5 GB video dosyası içeren büyük bir PowerPoint sunumu (large.pptx) düşünün. Bu sunumu yüklemenin standart yöntemi aşağıdaki PHP kodunda açıklanmıştır:

```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ancak bu yöntem yaklaşık 1,6 GB geçici bellek tüketir.

### **BLOB Olarak Büyük Bir Sunumu Yüklemek**

BLOB içeren bir süreçle, az bellek kullanarak büyük bir sunumu yükleyebilirsiniz. Bu PHP kodu, BLOB süreciyle büyük bir sunum dosyasını (large.pptx) nasıl yükleyeceğinizi gösterir:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Geçici Dosyalar İçin Klasörü Değiştirmek**

BLOB süreci kullanıldığında, bilgisayarınız geçici dosyaları varsayılan geçici dosya klasöründe oluşturur. Geçici dosyaların farklı bir klasörde tutulmasını istiyorsanız, `setTempFilesRootPath` yöntemiyle depolama ayarlarını değiştirebilirsiniz:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}
`setTempFilesRootPath` kullandığınızda, Aspose.Slides geçici dosyaları saklamak için otomatik olarak bir klasör oluşturmaz. Klasörü manuel olarak oluşturmanız gerekir.
{{% /alert %}}

### **Belleği Serbest Bırakmak İçin Sunum Nesnelerini Yok Etmek**

Büyük sunumları işlerken, [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneğinin doğru şekilde yok edildiğinden emin olun; böylece bu nesnenin işgal ettiği bellek serbest bırakılır. Sunumu kullanmayı bitirdikten sonra yönetsiz kaynakları serbest bırakmak için `dispose()` metodunu çağırın.

```php
$presentation = new Presentation("large.pptx");

# ...sunumu işleyin...
$presentation->save("large.pdf", SaveFormat::Pdf);

# Kaynakları açıkça serbest bırak.
$presentation->dispose();
```

## **SSS**

**Aspose.Slides bir sunumda hangi veriler BLOB olarak değerlendirilir ve BLOB seçenekleri tarafından kontrol edilir?**

Görüntüler, ses ve video gibi büyük ikili nesneler BLOB olarak değerlendirilir. Sunum dosyasının tamamı da yüklendiğinde veya kaydedildiğinde BLOB işleme tabi tutulur. Bu nesneler, bellek kullanımını yönetmenizi ve gerektiğinde geçici dosyalara yönlendirmenizi sağlayan BLOB politikalarıyla kontrol edilir.

**Sunum yükleme sırasında BLOB işleme kurallarını nerede yapılandırırım?**

[LoadOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/) ile [BlobManagementOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/blobmanagementoptions/) kullanın. Burada BLOB için bellek sınırını ayarlar, geçici dosyaları izin verip vermemeyi belirler, geçici dosyalar için kök yolu seçer ve kaynak kilitleme davranışını seçersiniz.

**BLOB ayarları performansı etkiler mi ve hızı belleğe göre nasıl dengeleyebilirim?**

Evet. BLOB'un bellekte tutulması hızı maksimize eder ancak RAM tüketimini artırır; bellek sınırını düşürmek daha fazla işi geçici dosyalara yönlendirir, RAM'i azaltır ama ek I/O maliyeti getirir. İş yükünüze ve ortamınıza uygun dengeyi sağlamak için [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/tr/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) metodunu kullanın.

**BLOB seçenekleri, çok büyük sunumları (ör. gigabayt seviyesinde) açarken yardımcı olur mu?**

Evet. [BlobManagementOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/blobmanagementoptions/) bu senaryolar için tasarlanmıştır: geçici dosyaları etkinleştirmek ve kaynak kilitlemeyi kullanmak, tepe RAM kullanımını önemli ölçüde azaltır ve çok büyük sunumların işlenmesini istikrarlı hale getirir.

**Akışlardan dosya yerine BLOB politikalarını kullanabilir miyim?**

Evet. Aynı kurallar akışlara da uygulanır: sunum örneği giriş akışını sahiplenebilir ve kilitleyebilir (seçilen kilitleme moduna bağlı olarak) ve izin verildiğinde geçici dosyalar kullanılabilir; bu sayede işleme sırasında bellek kullanımı öngörülebilir.