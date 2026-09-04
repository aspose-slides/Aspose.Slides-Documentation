---
title: JavaScript'te Sunumları Aç
linktitle: Sunum Aç
type: docs
weight: 20
url: /tr/nodejs-java/open-presentation/
keywords:
- PowerPoint aç
- sunum aç
- PPTX aç
- PPT aç
- ODP aç
- sunumu yükle
- PPTX yükle
- PPT yükle
- ODP yükle
- korumalı sunum
- büyük sunum
- harici kaynak
- ikili nesne
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript'te PowerPoint ve OpenDocument sunumlarını nasıl açacağınızı, açma şifreleri ekleyeceğinizi, kaynak yüklemeyi kontrol edeceğinizi ve Aspose.Slides for Node.js via Java ile bellek kullanımını nasıl azaltacağınızı öğrenin."
---
## **Giriş**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/tr/nodejs-java/) PowerPoint ve OpenDocument sunumlarını dosyalardan ve akışlardan yükleyebilir. Bir sunum yüklendikten sonra yapısını inceleyebilir, slaytları düzenleyebilir, kaynakları yönetebilir ve orijinal ya da başka bir desteklenen formatta kaydedebilirsiniz.

Yükleme davranışı, [LoadOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/) sınıfı aracılığıyla özelleştirilebilir. Örneğin, bir açma şifresi belirtebilir, büyük ikili nesneleri Node.js belleğinin dışında tutabilir, harici kaynakları kontrol edebilir veya gömülü ikili verileri dışlayabilirsiniz.

## **Sunumları Aç**

Mevcut bir sunumu açmak için dosya yolunu [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) yapıcısına geçirin. Dosya tanıtıcıları, geçici veriler ve diğer kaynakların hızlıca serbest bırakılması için sunumu kullandıktan sonra dağıtın.

Aşağıdaki JavaScript örneği, bir sunumu nasıl açıp slayt sayısını alacağınızı gösterir:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Şifre Koruması Olan Sunumları Aç**

Açma şifresi, sunum içeriğini şifreler. Sunumu tamamen yüklemek için doğru şifreyi [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setPassword) yöntemine verin ve seçenekleri [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) yapıcısına sağlayın. Şifre eksik ya da hatalı olduğunda yükleme başarısız olur.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Şifre algılama, doğrulama ve şifreleme akışları için [Password-Protect Presentations](/slides/tr/nodejs-java/password-protected-presentation/) sayfasına bakın. Şifrelenmiş bir sunum, açık belge özellikleriyle kasıtlı olarak kaydedildiyse, bu özellikler şifre olmadan okunabilir; detaylar için [Manage Presentation Properties](/slides/tr/nodejs-java/presentation-properties/) bölümüne bakabilirsiniz.

## **Büyük Sunumları Aç**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) yöntemi, Aspose.Slides'ın resimler, ses ve video gibi büyük ikili nesneleri nasıl yönettiğini kontrol eden seçenekleri döndürür. Kaynak dosyayı kilitli tutabilir, geçici dosyalara izin verebilir ve bellek içinde tutulan BLOB verisinin miktarını sınırlayabilirsiniz.

Aşağıdaki JavaScript kodu, büyük bir sunumun (örneğin 2 GB) nasıl yükleneceğini gösterir:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Not" %}}

[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked) kullanıldığında, kaynak dosya sunum örneği dağıtılana kadar kilitli kalır. Bu örnek hâlâ aktifken dosyayı taşıma, üzerine yazma veya silme yapmayın.

Aspose.Slides, yükleme sırasında bir giriş akışının içeriğini kopyalayabilir. Büyük sunumlar için dosya yolu, genellikle akışa göre daha verimlidir. Ek depolama ve bellek yönetimi seçenekleri için [Manage BLOBs](/slides/tr/nodejs-java/manage-blob/) sayfasına bakın.

{{% /alert %}}

## **Harici Kaynakları Kontrol Et**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) yöntemi, bir [IResourceLoadingCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iresourceloadingcallback/) uygulaması alır. Geri çağırma, gerektiğinde veri değiştirme, bir kaynağı yönlendirme, varsayılan yükleyiciyi kullanma veya kaynağı atlama imkanı tanır. Bu, sunumların uygulamaya özgü güvenlik ya da depolama kurallarına göre çözülmesi gereken harici görüntüler içerdiği durumlarda faydalıdır.

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Gömülü İkili Nesneler Olmadan Sunumları Yükle**

Bir sunum, uygulamanın ihtiyaç duymadığı veya saklamak istemediği gömülü ikili veriler içerebilir. Örnekler:

- VBA projeleri, [Presentation.getVbaProject](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getVbaProject) aracılığıyla erişilebilir;
- gömülü OLE verileri, [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) aracılığıyla erişilebilir;
- ActiveX denetim verileri, [Control.getActiveXControlBinary](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/control/#getActiveXControlBinary) aracılığıyla erişilebilir.

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) seçeneğini `true` olarak ayarlayarak bu ikili verileri yükleme sırasında kaldırabilirsiniz. Temizlenmiş sonucu kalıcı hale getirmek için yüklenen sunumu kaydedin.

Bu seçenek, istenmeyen gömülü yükleri azaltır, ancak tam bir kötü amaçlı yazılım tespiti veya içerik temizleme sistemi değildir.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Bir dosyanın bozuk olduğunu ve açılamadığını nasıl anlayabilirim?**

Aspose.Slides, yükleme sırasında bir ayrıştırma ya da format istisnası fırlatır. Yanlış şifre hatasından ayrı olarak bu hatayı yakalayarak uygulamanın nedeni doğru şekilde raporlamasını sağlayın.

**Gerekli yazı tipleri eksikse ne olur?**

Sunum hâlâ yüklenebilir, ancak çizim ve dışa aktarma işlemleri yazı tiplerini değiştirebilir. Çıktının daha öngörülebilir olmasını sağlamak için [font substitution](/slides/tr/nodejs-java/font-substitution/) yapılandırabilir veya [özel yazı tipleri](/slides/tr/nodejs-java/custom-font/) sağlayabilirsiniz.

**Bir sunumu yüklemek aynı zamanda gömülü medyayı da yükler mi?**

Gömülü ses ve video, sunum nesne modeli üzerinden erişilebilir hâle gelir. Harici kaynaklar, yapılandırılmış kaynak‑yükleme davranışına göre çözülür ve konumlarına erişilemiyorsa kullanılamaz olabilir.