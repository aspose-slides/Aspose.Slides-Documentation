---
title: Android'de Sunum Oluşturma
linktitle: Sunum Oluştur
type: docs
weight: 10
url: /tr/androidjava/create-presentation/
keywords:
- sunum oluştur
- yeni sunum
- PPT oluştur
- yeni PPT
- PPTX oluştur
- yeni PPTX
- ODP oluştur
- yeni ODP
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile Java'da sunumlar oluşturun—PPT, PPTX ve ODP dosyaları üretin, OpenDocument desteğinden yararlanın ve güvenilir sonuçlar için programlı olarak kaydedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Android'i Java aracılığıyla kullanarak bir sunum nasıl oluşturulur, ilk slaytına bir metin kutusu nasıl eklenir ve sonuç uygulamanızın depolamasına bir dosya olarak nasıl kaydedilir gösterir. Mevcut bir sunumu açmak veya başka bir biçimde kaydetmek için [Open Presentation](/slides/tr/androidjava/open-presentation/) ve [Save Presentation](/slides/tr/androidjava/save-presentation/) bölümlerine bakın. Sondaki kısa SSS, biçimler, şablonlar, slayt boyutu, birimler, bellek kullanımı, çoklu iş parçacığı, lisanslama, dijital imzalar ve VBA desteğiyle ilgili yaygın soruları kapsar.

Başlamadan önce, Aspose.Slides'i Android projenize Aspose'un Maven deposundan ekleyin. Bkz. [Kurulum](/slides/tr/androidjava/install-aspose-slides-for-android-via-java/).

## **PowerPoint Sunumu Oluşturma**

Bir sunum oluşturmak ve ilk slaytına bir metin kutusu eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun. Yeni bir sunum zaten bir boş slayt içerir.  
1. Bu slaytı, [slide collection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/) içerisinden indeksine göre, 0, alın.  
1. [shape collection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/) üzerinden [addAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) yöntemiyle bir dikdörtgen ekleyin ve [text frame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) nin [setText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-) yöntemiyle metnini ayarlayın.  
1. Sunumu, [save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemiyle [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveformat/) biçiminde bir PPTX dosyası olarak kaydedin.

Kod, örneğin `onCreate` metodunda bir `Activity` içinde çalışır. Dosyayı, [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) yöntemiyle dönen dizine kaydeder: uygulamanızın izin istemeden yazabileceği özel depolama.

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dikdörtgenin sol üst köşesi slaytın sol kenarından 50 puan, üst kenarından 50 puan uzakta ve dikdörtgen 400 puan genişliğinde ve 100 puan yüksekliğindedir. Kaydedilen dosya, bu dikdörtgen ve metni içeren bir slayt içerir. Lisans olmadan Aspose.Slides, kaydettiği her slayta bir değerlendirme filigranı ekler; bkz. [Lisanslama](/slides/tr/androidjava/licensing/).

Dosyayı incelemek için Android Studio'nun [Device Explorer](https://developer.android.com/studio/debug/device-file-explorer) kısmını açın ve uygulamanızın *files* klasöründeki *data/data/* altında *hello.pptx* dosyasını bulun. Gerçek bir uygulamada, kullanıcı arayüzünün yanıt vermeye devam etmesi için sunumları arka plan iş parçacığında işleyin.

## **SSS**

### Yeni bir sunumu hangi biçimlerde kaydedebilirim?

[PDF](/slides/tr/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/tr/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/tr/androidjava/convert-powerpoint-to-html/), [SVG](/slides/tr/androidjava/render-a-slide-as-an-svg-image/) ve [görseller](/slides/tr/androidjava/convert-powerpoint-to-png/) gibi diğer biçimlere dışa aktarabileceğiniz gibi, [PPTX, PPT ve ODP](/slides/tr/androidjava/save-presentation/) biçimlerinde de kaydedebilirsiniz.

### Bir şablondan (POTX/POTM) başlayıp normal bir PPTX olarak kaydedebilir miyim?

Evet. Şablonu yükleyin ve istediğiniz biçimde kaydedin; POTX/POTM/PPTM ve benzeri biçimler [desteklenir](/slides/tr/androidjava/supported-file-formats/).

### Sunum oluştururken slayt boyutunu/ en-boy oranını nasıl kontrol edebilirim?

[slide size](/slides/tr/androidjava/slide-size/) ayarını (4:3, 16:9 gibi ön ayarlar veya özel boyutlar) belirleyin ve içeriğin nasıl ölçekleneceğini seçin.

### Boyutlar ve koordinatlar hangi birimlerde ölçülür?

Puan cinsinden: 1 inç 72 birime eşittir.

### Çok büyük sunumları (çok sayıda medya dosyası içeren) bellek kullanımını azaltarak nasıl yönetebilirim?

[BLOB yönetim stratejileri](/slides/tr/androidjava/manage-blob/) kullanın, geçici dosyalarla bellek içi depolamayı sınırlayın ve yalnızca bellek içi akışlar yerine dosya tabanlı iş akışlarını tercih edin.

### Sunumları aynı anda paralel olarak oluşturup/kaydedebilir miyim?

Aynı [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneğine [birden fazla iş parçacığından](/slides/tr/androidjava/multithreading/) erişemezsiniz. Her iş parçacığı veya süreç için ayrı, izole örnekler çalıştırın.

### Deneme filigranı ve kısıtlamaları nasıl kaldırabilirim?

İşlem başına bir kez [bir lisans uygulayın](/slides/tr/androidjava/licensing/). Lisans XML dosyası değiştirilmemeli ve birden fazla iş parçacığı kullanılıyorsa lisans kurulumu senkronize edilmelidir.

### Oluşturduğum PPTX'i dijital olarak imzalayabilir miyim?

Evet. Sunumlar için [dijital imzalar](/slides/tr/androidjava/digital-signature-in-powerpoint/) (ekleme ve doğrulama) desteklenir.

### Oluşturulan sunumlarda makrolar (VBA) destekleniyor mu?

Evet. [VBA projeleri oluşturabilir/düzenleyebilir](/slides/tr/androidjava/presentation-via-vba/) ve PPTM/PPSM gibi makro etkin dosyaları kaydedebilirsiniz.