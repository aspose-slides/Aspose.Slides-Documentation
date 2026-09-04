---
title: Android'de Sunumları Aç
linktitle: Sunumu Aç
type: docs
weight: 20
url: /tr/androidjava/open-presentation/
keywords:
- PowerPoint'i aç
- Sunumu aç
- PPTX'i aç
- PPT'i aç
- ODP'yi aç
- Sunumu yükle
- PPTX'i yükle
- PPT'i yükle
- ODP'yi yükle
- Korunan sunum
- Büyük sunum
- Harici kaynak
- İkili nesne
- Android
- Java
- Aspose.Slides
description: "Android'de PowerPoint ve OpenDocument sunumlarını nasıl açacağınızı, açma şifreleri sağlayacağınızı, kaynak yüklemesini kontrol edeceğinizi ve Aspose.Slides for Android via Java ile bellek kullanımını nasıl azaltacağınızı öğrenin."
---
## **Giriş**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/tr/androidjava/) PowerPoint ve OpenDocument sunumlarını dosyalardan ve akışlardan yükleyebilir. Bir sunum yüklendikten sonra, yapısını inceleyebilir, slaytları düzenleyebilir, kaynakları yönetebilir ve orijinal ya da başka desteklenen bir formatta kaydedebilirsiniz.

Yükleme davranışı, [LoadOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/) sınıfı aracılığıyla özelleştirilebilir. Örneğin, bir açma şifresi sağlayabilir, büyük ikili nesneleri Java yığın belleğinin dışında tutabilir, harici kaynakları kontrol edebilir veya gömülü ikili verileri atlayabilirsiniz.

## **Sunumları Aç**

Mevcut bir sunumu açmak için dosya yolunu [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) yapıcısına iletin. Sunumu kullandıktan sonra serbest bırakın, böylece dosya tutamaçları, geçici veriler ve diğer kaynaklar hemen serbest bırakılır.

Aşağıdaki Java örneği, bir sunumu nasıl açıp slayt sayısını nasıl alacağınızı gösterir:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Şifre Koruması Olan Sunumları Aç**

Bir açma şifresi, sunum içeriğini şifreler. Tam sunumu yüklemek için doğru şifreyi [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) metoduna iletin ve seçenekleri [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) yapıcısına sağlayın. Şifre eksik veya yanlış olduğunda yükleme başarısız olur.

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

Şifre tespiti, doğrulama ve şifreleme iş akışları için, [Password-Protect Presentations](/slides/tr/androidjava/password-protected-presentation/) bölümüne bakın. Şifrelenmiş bir sunum, özellikle genel belge özellikleriyle kaydedilmişse, bu özellikler şifre olmadan okunabilir; [Manage Presentation Properties](/slides/tr/androidjava/presentation-properties/) bölümüne bakın.

## **Büyük Sunumları Aç**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) Aspose.Slides'in görüntüler, ses ve video gibi büyük ikili nesneleri nasıl yönettiğini kontrol eden seçenekleri döndürür. Kaynak dosyayı kilitli tutabilir, geçici dosyalara izin verebilir ve bellekte tutulan BLOB veri miktarını sınırlayabilirsiniz.

Aşağıdaki Java kodu, büyük bir sunumu (örneğin 2 GB) yüklemeyi gösterir:

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
[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked) ile kaynak dosya, sunum örneği serbest bırakılana kadar kilitli kalır. Bu örnek hâlen mevcutken kaynak dosyayı taşımayın, üzerine yazmayın veya silmeyin.

Aspose.Slides, yükleme sırasında bir giriş akışının içeriğini kopyalayabilir. Büyük sunumlar için dosya yolu, genellikle akışa göre daha verimlidir. Ek depolama ve bellek yönetimi seçenekleri için [Manage BLOBs](/slides/tr/androidjava/manage-blob/) bölümüne bakın.
{{% /alert %}}

## **Harici Kaynakları Kontrol Et**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) bir [IResourceLoadingCallback](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iresourceloadingcallback/) uygulamasını kabul eder. Geri arama, yedek veri sağlayabilir, bir kaynağı yönlendirebilir, varsayılan yükleyiciyi kullanabilir veya kaynağı atlayabilir. Bu, sunumlarda uygulamaya özgü güvenlik veya depolama kurallarına göre çözülmesi gereken harici görüntüler bulunduğunda kullanışlıdır.

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

## **Gömülü İkili Nesneleri Olmadan Sunumları Yükle**

Bir sunum, uygulamanın ihtiyaç duymadığı veya tutmak istemediği gömülü ikili veriler içerebilir. Örnekler:

- VBA projeleri, [IPresentation.getVbaProject](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getVbaProject--) aracılığıyla mevcuttur;
- gömülü OLE verileri, [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) aracılığıyla mevcuttur;
- ActiveX kontrol verileri, [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--) aracılığıyla mevcuttur.

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) `true` olarak ayarlayarak bu ikili verileri yükleme sırasında kaldırabilirsiniz. Temizlenmiş sonucu kalıcı kılmak için yüklenen sunumu kaydedin.

Bu seçenek, istenmeyen gömülü yüklerden korunmayı azaltır, ancak tam bir kötü amaçlı yazılım tespiti veya içerik temizleme sistemi değildir.

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

Aspose.Slides, yükleme sırasında bir ayrıştırma veya format istisnası fırlatır. Bu hatayı, hatalı şifre hatasından ayrı şekilde ele alarak uygulamanın nedeni doğru şekilde raporlamasını sağlayabilirsiniz.

**Gerekli yazı tipleri eksikse ne olur?**

Sunum yine de yüklenebilir, ancak renderleme ve dışa aktarma sırasında yazı tipleri ikame edilebilir. Çıktıyı daha öngörülebilir hâle getirmek için [configure font substitution](/slides/tr/androidjava/font-substitution/) ya da [provide custom fonts](/slides/tr/androidjava/custom-font/) seçeneklerini kullanabilirsiniz.

**Bir sunumu yüklemek, gömülü medyasını da yükler mi?**

Gömülü ses ve video, sunum nesne modeli aracılığıyla kullanılabilir hâle gelir. Harici kaynaklar, yapılandırılmış kaynak‑yükleme davranışına göre çözülür ve konumlarına erişilemezse kullanılamaz olabilir.