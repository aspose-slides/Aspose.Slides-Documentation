---
title: Java'da Sunumları Aç
linktitle: Sunum Aç
type: docs
weight: 20
url: /tr/java/open-presentation/
keywords:
- PowerPoint Aç
- Sunumu Aç
- PPTX Aç
- PPT Aç
- ODP Aç
- Sunumu Yükle
- PPTX Yükle
- PPT Yükle
- ODP Yükle
- Koruma Altındaki Sunum
- Büyük Sunum
- Harici Kaynak
- İkili Nesne
- Java
- Aspose.Slides
description: "Java'da PowerPoint ve OpenDocument sunumlarını nasıl açacağınızı, açma şifrelerini nasıl sağlayacağınızı, kaynak yüklemeyi nasıl kontrol edeceğinizi ve Aspose.Slides for Java ile bellek kullanımını nasıl azaltacağınızı öğrenin."
---
## **Giriş**

[Aspose.Slides for Java](https://products.aspose.com/slides/tr/java/) PowerPoint ve OpenDocument sunumlarını dosyalardan ve akışlardan yükleyebilir. Bir sunum yüklendikten sonra, yapısını inceleyebilir, slaytları düzenleyebilir, kaynakları yönetebilir ve orijinal ya da başka desteklenen bir formatta kaydedebilirsiniz.

Yükleme davranışı, [LoadOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/) sınıfı aracılığıyla özelleştirilebilir. Örneğin, açma şifresi sağlayabilir, büyük ikili nesneleri Java yığın belleği dışında tutabilir, harici kaynakları kontrol edebilir veya yerleşik ikili verileri atlayabilirsiniz.

## **Sunumları Aç**

Mevcut bir sunumu açmak için, dosya yolunu [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) yapıcısına iletin. Sunumu kullandıktan sonra dosya tutucularının, geçici verilerin ve diğer kaynakların hızlı bir şekilde serbest bırakılması için nesneyi serbest bırakın.

Aşağıdaki Java örneği, bir sunumu nasıl açıp slayt sayısını alacağınızı gösterir:

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

Açma şifresi, sunum içeriğini şifreler. Sunumu tamamen yüklemek için doğru şifreyi [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) yöntemine iletin ve seçenekleri [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) yapıcısına sağlayın. Şifre eksik ya da yanlış olduğunda yükleme başarısız olur.

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

Şifre algılama, doğrulama ve şifreleme iş akışları için [Password-Protect Presentations](/slides/tr/java/password-protected-presentation/) sayfasına bakın. Şifreli bir sunum, bilinçli olarak genel belge özellikleriyle kaydedildiyse, bu özellikler şifre olmadan okunabilir; ayrıntılar için [Manage Presentation Properties](/slides/tr/java/presentation-properties/) sayfasına bakın.

## **Büyük Sunumları Aç**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) görüntüler, ses ve video gibi büyük ikili nesnelerin nasıl işleneceğini kontrol eden seçenekleri döndürür. Kaynak dosyayı kilitli tutabilir, geçici dosyalara izin verebilir ve bellekte tutulacak BLOB verisinin miktarını sınırlayabilirsiniz.

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

[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked) kullanıldığında, kaynak dosya sunum örneği serbest bırakılana kadar kilitli kalır. Bu örnek hayatta olduğu sürece kaynak dosyayı taşıma, üzerine yazma veya silme yapmayın.

Aspose.Slides, yükleme sırasında bir giriş akışının içeriğini kopyalayabilir. Büyük sunumlar için dosya yolu, genellikle akışa göre daha verimlidir. Ek depolama ve bellek yönetimi seçenekleri için [Manage BLOBs](/slides/tr/java/manage-blob/) sayfasına bakın.

{{% /alert %}}

## **Harici Kaynakları Kontrol Et**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) bir [IResourceLoadingCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iresourceloadingcallback/) uygulaması kabul eder. Geri arama, yedek veri sağlayabilir, bir kaynağı yeniden yönlendirebilir, varsayılan yükleyiciyi kullanabilir veya kaynağı atlayabilir. Bu, sunumların uygulamaya özgü güvenlik veya depolama kurallarına göre çözülmesi gereken harici görseller içerdiği durumlarda kullanışlıdır.

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

## **Yerleşik İkili Nesneler Olmadan Sunumları Yükle**

Bir sunum, uygulamanın ihtiyaç duymadığı veya tutmak istemediği yerleşik ikili veri içerebilir. Örnekler:

- VBA projeleri, [IPresentation.getVbaProject](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getVbaProject--) aracılığıyla erişilebilir;
- yerleşik OLE verileri, [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) aracılığıyla erişilebilir;
- ActiveX kontrol verileri, [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icontrol/#getActiveXControlBinary--) aracılığıyla erişilebilir.

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) seçeneğini `true` olarak ayarladığınızda, bu ikili veri yükleme sırasında silinir. Temizlenmiş sonucu kalıcı hâle getirmek için yüklenen sunumu kaydedin.

Bu seçenek, istenmeyen yerleşik yükleri azaltır, ancak tam bir kötü amaçlı yazılım tespiti veya içerik temizleme sistemi değildir.

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

[Aspose.Slides](https://products.aspose.com/slides/tr/java/), yükleme sırasında bir ayrıştırma veya format istisnası fırlatır. Bu hatayı, yanlış şifre hatasından ayrı şekilde ele alın, böylece uygulama nedeni doğru şekilde raporlayabilir.

**Gerekli fontlar eksik olduğunda ne olur?**

Sunum hâlâ yüklenebilir, fakat render ve dışa aktarma sırasında fontlar değiştirilebilir. Çıktıyı daha öngörülebilir hâle getirmek için [font ikamesi yapılandırmasını](/slides/tr/java/font-substitution/) yapabilir veya [özel fontlar](/slides/tr/java/custom-font/) sağlayabilirsiniz.

**Bir sunumu yüklemek, yerleşik medyasını da yükler mi?**

Yerleşik ses ve video, sunum nesne modeli aracılığıyla kullanılabilir hâle gelir. Harici kaynaklar, yapılandırılmış kaynak‑yükleme davranışına göre çözülür ve konumlarına erişilemezse kullanılamaz olabilir.