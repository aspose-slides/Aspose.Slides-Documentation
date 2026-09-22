---
title: JavaScript'te Sunumları Açma
linktitle: Sunumu Aç
type: docs
weight: 20
url: /tr/nodejs-java/open-presentation/
keywords:
- PowerPoint aç
- sunum aç
- PPTX aç
- PPT aç
- ODP aç
- sunum yükle
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
description: "JavaScript'te PowerPoint ve OpenDocument sunumlarını nasıl açacağınızı, açma parolaları nasıl sağlayacağınızı, kaynak yüklemeyi nasıl kontrol edeceğinizi ve Aspose.Slides for Node.js via Java ile bellek kullanımını nasıl azaltacağınızı öğrenin."
---
## **Giriş**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/tr/nodejs-java/) dosyalar ve akışlardan PowerPoint ve OpenDocument sunumlarını yükleyebilir. Bir sunum yüklendikten sonra, yapısını inceleyebilir, slaytları düzenleyebilir, kaynakları yönetebilir ve orijinal ya da başka desteklenen formatta kaydedebilirsiniz.

Yükleme davranışı, [LoadOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/) sınıfı aracılığıyla özelleştirilebilir. Örneğin, bir açma parolası sağlayabilir, büyük ikili nesneleri Node.js belleği dışında tutabilir, harici kaynakları kontrol edebilir veya gömülü ikili verileri dışarıda bırakabilirsiniz.

## **Sunumları Açma**

Bir dosya veya akış yüklendikten sonra, uygulamanızın nasıl işleyeceğini seçmek için [orijinal sunum formatını belirleyebilirsiniz](/slides/tr/nodejs-java/detect-presentation-source-format/).

Mevcut bir sunumu açmak için, dosya yolunu [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) yapıcısına geçirin. Sunumu kullandıktan sonra dosya tanıtıcıları, geçici veriler ve diğer kaynakların hızlıca serbest bırakılması için sunumu serbest bırakın.

Aşağıdaki JavaScript örneği, bir sunumu nasıl açıp slayt sayısını alabileceğinizi gösterir:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Parola Korumalı Sunumları Açma**

Açma parolası, sunum içeriğini şifreler. Tam sunumu yüklemek için doğru parolayı [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setPassword) metoduna geçirin ve seçenekleri [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) yapıcısına sağlayın. Parola eksik veya hatalı olduğunda yükleme başarısız olur.

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

Parola algılama, doğrulama ve şifreleme iş akışları için [Password-Protect Presentations](/slides/tr/nodejs-java/password-protected-presentation/) sayfasına bakın. Şifreli bir sunum, bilinçli olarak herkese açık belge özellikleriyle kaydedildiyse, bu özellikler parola olmadan okunabilir; bkz. [Manage Presentation Properties](/slides/tr/nodejs-java/presentation-properties/).

## **Büyük Sunumları Açma**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions), Aspose.Slides'in görüntüler, ses ve video gibi büyük ikili nesneleri (BLOB) nasıl yönettiğini kontrol eden seçenekleri döndürür. Kaynak dosyayı kilitli tutabilir, geçici dosyalara izin verebilir ve bellekte tutulan BLOB verisinin miktarını sınırlayabilirsiniz.

Aşağıdaki JavaScript kodu, büyük bir sunumu (örneğin 2 GB) nasıl yükleyeceğinizi gösterir:

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

{{% alert color="info" title="Note" %}}
[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked) ile, kaynak dosya sunum örneği serbest bırakılana kadar kilitli kalır. Bu örnek hâlâ aktifken kaynak dosyayı taşımayın, üzerine yazmayın veya silmeyin.

Aspose.Slides, yükleme sırasında bir giriş akışının içeriğini kopyalayabilir. Büyük sunumlar için bu nedenle dosya yolu, akışa göre genellikle daha verimlidir. Ek depolama ve bellek yönetimi seçenekleri için [Manage BLOBs](/slides/tr/nodejs-java/manage-blob/) sayfasına bakın.
{{% /alert %}}

## **Harici Kaynakları Kontrol Etme**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) bir [IResourceLoadingCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iresourceloadingcallback/) uygulamasını kabul eder. Geri çağırma, yerine geçecek veri sağlayabilir, bir kaynağı yeniden yönlendirebilir, varsayılan yükleyiciyi kullanabilir veya kaynağı atlayabilir. Bu, sunumlarda uygulamaya özgü güvenlik veya depolama kurallarına göre çözülmesi gereken harici görüntüler bulunduğunda yararlıdır.

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

## **Gömülü İkili Nesneler Olmadan Sunumları Yükleme**

Bir sunum, uygulamanın ihtiyaç duymadığı veya tutmak istemediği gömülü ikili veri içerebilir. Örnekler:

- VBA projeleri, [Presentation.getVbaProject](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getVbaProject) üzerinden erişilebilir;
- gömülü OLE verileri, [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) üzerinden erişilebilir;
- ActiveX kontrol verileri, [Control.getActiveXControlBinary](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/control/#getActiveXControlBinary) üzerinden erişilebilir.

Yükleme sırasında bu ikili verileri kaldırmak için [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) değerini `true` olarak ayarlayın. Temizlenmiş sonucu kalıcı hale getirmek için yüklenen sunumu kaydedin.

Bu seçenek, istenmeyen gömülü yüklerden maruziyeti azaltır, ancak tam bir kötü amaçlı yazılım tespiti veya içerik temizleme sistemi değildir.

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

Aspose.Slides, yükleme sırasında bir ayrıştırma veya format istisnası fırlatır. Bu hatayı, hatalı parola hatasından ayrı şekilde ele alın; böylece uygulama nedeni doğru şekilde raporlayabilir.

**Gerekli yazı tipleri eksik olduğunda ne olur?**

Sunum yine de yüklenebilir, ancak renderleme ve dışa aktarma sırasında yazı tipleri değiştirilebilir. Çıktıyı daha öngörülebilir hâle getirmek için [font değiştirmeyi yapılandırabilirsiniz](/slides/tr/nodejs-java/font-substitution/) veya [özel yazı tipleri sağlayabilirsiniz](/slides/tr/nodejs-java/custom-font/).

**Bir sunumu yüklemek, gömülü medyalarını da yükler mi?**

Gömülü ses ve video, sunum nesne modeli üzerinden kullanılabilir hale gelir. Harici kaynaklar, yapılandırılmış kaynak yükleme davranışına göre çözülür ve konumlarına erişilemezse kullanılamaz olabilir.