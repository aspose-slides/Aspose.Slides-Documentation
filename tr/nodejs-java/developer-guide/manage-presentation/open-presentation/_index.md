---
title: JavaScript'te Sunumları Açma
linktitle: Sunumu Aç
type: docs
weight: 20
url: /tr/nodejs-java/open-presentation/
keywords:
- PowerPoint Aç
- OpenDocument Aç
- sunum aç
- PPTX Aç
- PPT Aç
- ODP Aç
- sunum yükle
- PPTX Yükle
- PPT Yükle
- ODP Yükle
- korumalı sunum
- büyük sunum
- harici kaynak
- ikili nesne
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile Java üzerinden PowerPoint (.pptx, .ppt) ve OpenDocument (.odp) sunumlarını zahmetsizce açın—hızlı, güvenilir, tam özellikli."
---
## **Giriş**

Sıfırdan PowerPoint sunumları oluşturmanın ötesinde, Aspose.Slides ayrıca mevcut sunumları açmanıza izin verir. Bir sunumu yükledikten sonra, onunla ilgili bilgileri alabilir, slayt içeriğini düzenleyebilir, yeni slaytlar ekleyebilir, mevcut slaytları kaldırabilir ve daha fazlasını yapabilirsiniz.

## **Sunumları Açma**

Mevcut bir sunumu açmak için, [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfını örnekleyin ve dosya yolunu yapıcıya iletin.

Aşağıdaki JavaScript örneği bir sunumu nasıl açacağınızı ve slayt sayısını nasıl alacağınızı gösterir:

```js
// Presentation sınıfını örnekleyin ve dosya yolunu yapıcıya iletin.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Sunumdaki toplam slayt sayısını yazdır.
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Şifre Koruması Olan Sunumları Açma**

Şifre korumalı bir sunumu açmanız gerektiğinde, şifreyi [LoadOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/) sınıfının [setPassword](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setPassword) yöntemiyle geçirerek şifreyi çözüp yükleyebilirsiniz. Aşağıdaki JavaScript kodu bu işlemi gösterir:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // Şifreli sunum üzerinde işlemler gerçekleştir.
} finally {
    presentation.dispose();
}
```

## **Büyük Sunumları Açma**

Aspose.Slides, özellikle [LoadOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/) sınıfındaki [getBlobManagementOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) yöntemi gibi seçenekler sunarak büyük sunumları yüklemenize yardımcı olur.

Aşağıdaki JavaScript kodu, büyük bir sunumu (örneğin 2 GB) yüklemeyi gösterir:

```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// KeepLocked davranışını seçin—sunum dosyası, Presentation örneğinin ömrü boyunca kilitli kalacak
// Presentation örneği, ancak dosyanın belleğe yüklenmesi veya geçici bir dosyaya kopyalanması gerekmez.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // Büyük sunum yüklendi ve düşük bellek tüketimiyle kullanılabilir.
    
    // Sunumu değiştirin.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Sunumu başka bir dosyaya kaydedin. Bu işlem sırasında bellek tüketimi düşük kalır.
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // Bunu yapmayın! Sunum nesnesi serbest bırakılana kadar dosya kilitli olduğu için bir I/O istisnası fırlatılacaktır.
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// Burada yapmak sorun değil. Kaynak dosya artık sunum nesnesi tarafından kilitli değil.
fs.unlinkSync(filePath);
```

{{% alert color="info" title="Bilgi" %}}
Akışlarla çalışırken bazı sınırlamaları aşmak için Aspose.Slides, bir akışın içeriğini kopyalayabilir. Bir akıştan büyük bir sunum yüklemek, sunumun kopyalanmasına ve yüklemenin yavaşlamasına neden olur. Bu nedenle, büyük bir sunumu yüklemeniz gerektiğinde, akış yerine sunum dosya yolunu kullanmanızı şiddetle öneririz.

Büyük nesneler (video, ses, yüksek çözünürlüklü görüntüler vb.) içeren bir sunum oluştururken, bellek tüketimini azaltmak için [BLOB management](/slides/tr/nodejs-java/manage-blob/) kullanabilirsiniz.
{{%/alert %}}

## **Harici Kaynakları Kontrol Etme**

Aspose.Slides, harici kaynakları yönetmenizi sağlayan [IResourceLoadingCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iresourceloadingcallback/) arabirimini sunar. Aşağıdaki JavaScript kodu, `IResourceLoadingCallback` arabirimini nasıl kullanacağınızı gösterir:

```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Yerine kullanılacak bir görüntü yükle.
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Yerine kullanılacak bir URL ayarla.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // Diğer tüm görüntüleri atla.
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```

## **Gömülü İkili Nesneler Olmadan Sunumları Yükleme**

Bir PowerPoint sunumu aşağıdaki türlerde gömülü ikili nesneler içerebilir:

- VBA projesi (erişmek için [Presentation.getVbaProject](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getVbaProject) kullanılabilir);
- OLE nesnesi gömülü verisi (erişmek için [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) kullanılabilir);
- ActiveX kontrolü ikili verisi (erişmek için [Control.getActiveXControlBinary](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/control/#getActiveXControlBinary) kullanılabilir).

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) yöntemini kullanarak, gömülü ikili nesne içermeyen bir sunumu yükleyebilirsiniz.

Bu yöntem, potansiyel olarak kötü niyetli ikili içeriği kaldırmak için yararlıdır. Aşağıdaki JavaScript kodu, gömülü ikili içerik olmadan bir sunumu nasıl yükleyeceğinizi gösterir:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // Sunum üzerinde işlemler gerçekleştir.
} finally {
    presentation.dispose();
}
```

## **SSS**

**Dosyanın bozuk olduğunu ve açılamadığını nasıl anlayabilirim?**

Yükleme sırasında bir ayrıştırma/biçim doğrulama istisnası alırsınız. Bu tür hatalar genellikle geçersiz bir ZIP yapısı veya bozuk PowerPoint kayıtlarından bahseder.

**Açılışta gerekli yazı tipleri eksik olursa ne olur?**

Dosya açılacak, ancak daha sonra [rendering/export](/slides/tr/nodejs-java/convert-presentation/) yazı tiplerini değiştirebilir. Çalışma zamanına [yazı tipi ikamelerini yapılandırın](/slides/tr/nodejs-java/font-substitution/) veya [gerekli yazı tiplerini ekleyin](/slides/tr/nodejs-java/custom-font/).

**Açılışta gömülü medya (video/ses) ile ne olur?**

Bunlar sunum kaynakları olarak kullanılabilir hale gelir. Medya dış yollarla referans edilirse, bu yolların ortamınızda erişilebilir olduğundan emin olun; aksi takdirde [rendering/export](/slides/tr/nodejs-java/convert-presentation/) medya atlayabilir.