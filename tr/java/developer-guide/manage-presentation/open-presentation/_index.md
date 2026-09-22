---
title: Java'da Sunumları Açma
linktitle: Sunumu Aç
type: docs
weight: 20
url: /tr/java/open-presentation/
keywords:
- PowerPoint Aç
- Sunum Aç
- PPTX Aç
- PPT Aç
- ODP Aç
- Sunum Yükle
- PPTX Yükle
- PPT Yükle
- ODP Yükle
- Korunan Sunum
- Büyük Sunum
- Harici Kaynak
- İkili Nesne
- Java
- Aspose.Slides
description: "Java’da PowerPoint ve OpenDocument sunumlarını nasıl açacağınızı, açma şifreleri sağlayarak, kaynak yüklemeyi kontrol ederek ve Aspose.Slides for Java ile bellek kullanımını nasıl azaltacağınızı öğrenin."
---
## **Giriş**

[Aspose.Slides for Java](https://products.aspose.com/slides/tr/java/) dosyalar ve akışlar üzerinden PowerPoint ve OpenDocument sunumlarını yükleyebilir. Bir sunum yüklendikten sonra yapısını inceleyebilir, slaytları düzenleyebilir, kaynakları yönetebilir ve orijinal ya da başka bir desteklenen formatta kaydedebilirsiniz.

Yükleme davranışı, [LoadOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/) sınıfı aracılığıyla özelleştirilebilir. Örneğin bir açma şifresi sağlayabilir, büyük ikili nesneleri Java yığın belleği dışında tutabilir, dış kaynakları kontrol edebilir veya gömülü ikili verileri atlayabilirsiniz.

## **Sunumları Açma**

Bir dosya ya da akış yüklendikten sonra, uygulamanızın nasıl işleyeceğini belirlemek için [orijinal sunum formatını belirleyin](/slides/tr/java/detect-presentation-source-format/).

Mevcut bir sunumu açmak için dosya yolunu [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) yapıcısına geçirin. Dosya tutamaçları, geçici veriler ve diğer kaynakların derhal serbest bırakılması için sunumu kullandıktan sonra serbest bırakın.

Aşağıdaki Java örneği bir sunumu nasıl açıp slayt sayısını alacağınızı gösterir:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Şifre Koruması Olan Sunumları Açma**

Açma şifresi, sunum içeriğini şifreler. Tam sunumu yüklemek için doğru şifreyi [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) metoduna geçirin ve seçenekleri [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) yapıcısına sağlayın. Şifre eksik veya hatalı olduğunda yükleme başarısız olur.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Şifre algılama, doğrulama ve şifreleme iş akışları için [Sunumları Şifreyle Koruma](/slides/tr/java/password-protected-presentation/) bölümüne bakın. Şifrelenmiş bir sunum, kasıtlı olarak genel belge özellikleriyle kaydedildiyse, bu özellikler şifresiz olarak okunabilir; ayrıntılar için [Sunum Özelliklerini Yönetme](/slides/tr/java/presentation-properties/) bölümüne bakın.

## **Büyük Sunumları Açma**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) yöntemi, Aspose.Slides’ın resimler, ses ve video gibi büyük ikili nesneleri nasıl yöneteceğini kontrol eden seçenekleri döndürür. Kaynak dosyayı kilitli tutabilir, geçici dosyalara izin verebilir ve bellekte tutulan BLOB verisinin miktarını sınırlayabilirsiniz.

Aşağıdaki Java kodu büyük bir sunumu (örneğin 2 GB) nasıl yükleyeceğinizi gösterir:

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked) kullanıldığında, kaynak dosya sunum örneği serbest bırakılana kadar kilitli kalır. Bu örnek yaşamaktadırken dosyayı taşımayın, üzerine yazmayın veya silmeyin.

Aspose.Slides, yükleme sırasında bir giriş akışının içeriğini kopyalayabilir. Büyük sunumlar için dosya yolu, akışa göre genellikle daha verimlidir. Ek depolama ve bellek yönetimi seçenekleri için [BLOB’ları Yönetme](/slides/tr/java/manage-blob/) bölümüne bakın.
{{% /alert %}}

## **Harici Kaynakları Kontrol Etme**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) metodu, bir [IResourceLoadingCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iresourceloadingcallback/) uygulaması kabul eder. Geri arama, değiştirme verisi sağlayabilir, bir kaynağı yönlendirebilir, varsayılan yükleyiciyi kullanabilir veya kaynağı atlayabilir. Bu, sunumların uygulamaya özgü güvenlik veya depolama kurallarına göre çözülmesi gereken dış görüntüler içermesi durumunda faydalıdır.

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Gömülü İkili Nesneler Olmadan Sunumları Yükleme**

Bir sunum, uygulamanın ihtiyaç duymadığı veya tutmak istemediği gömülü ikili veriler içerebilir. Örnekler:

- VBA projeleri, [IPresentation.getVbaProject](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getVbaProject--) aracılığıyla erişilebilir;
- gömülü OLE verileri, [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) aracılığıyla erişilebilir;
- ActiveX denetim verileri, [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icontrol/#getActiveXControlBinary--) aracılığıyla erişilebilir.

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) seçeneğini `true` olarak ayarlayın; bu, yükleme sırasında bu ikili verileri kaldırır. Temizlenmiş sonucu kalıcı hâle getirmek için yüklü sunumu kaydedin.

Bu seçenek istenmeyen gömülü yükleri azaltır, ancak tam bir kötü amaçlı yazılım tespit veya içerik temizleme sistemi değildir.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Bir dosyanın bozuk olduğunu ve açılamadığını nasıl anlayabilirim?**  
Aspose.Slides, yükleme sırasında bir ayrıştırma veya format istisnası fırlatır. Bu hatayı, hatalı şifre hatasından ayrı olarak ele alın; böylece uygulama nedeni doğru bir şekilde raporlayabilir.

**Gerekli yazı tipleri eksik olursa ne olur?**  
Sunum yine de yüklenebilir, ancak render ve dışa aktarma sırasında yazı tipleri değiştirilebilir. Çıktıyı daha öngörülebilir hâle getirmek için [yazı tipi ikamesini yapılandırın](/slides/tr/java/font-substitution/) veya [özel yazı tipleri sağlayın](/slides/tr/java/custom-font/).

**Bir sunumu yüklemek, gömülü medyasını da yüklüyor mu?**  
Gömülü ses ve video, sunum nesne modeli aracılığıyla erişilebilir hale gelir. Dış kaynaklar, yapılandırılmış kaynak‑yükleme davranışına göre çözülür ve konumlarına erişilemezse bulunamaz.