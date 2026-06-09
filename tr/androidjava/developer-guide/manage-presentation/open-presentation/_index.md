---
title: Android'de Sunumları Aç
linktitle: Sunum Aç
type: docs
weight: 20
url: /tr/androidjava/open-presentation/
keywords:
- PowerPoint aç
- OpenDocument aç
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint (.pptx, .ppt) ve OpenDocument (.odp) sunumlarını zahmetsizce açın—hızlı, güvenilir, tam özellikli."
---
## **Giriş**

Sıfırdan PowerPoint sunumları oluşturmanın ötesinde, Aspose.Slides ayrıca mevcut sunumları açmanıza olanak tanır. Bir sunumu yükledikten sonra, onun hakkında bilgi alabilir, slayt içeriğini düzenleyebilir, yeni slaytlar ekleyebilir, mevcut slaytları kaldırabilir ve daha fazlasını yapabilirsiniz.

## **Sunumları Aç**

Mevcut bir sunumu açmak için, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun ve dosya yolunu yapıcıya geçirin.

Aşağıdaki Java örneği, bir sunumu nasıl açıp slayt sayısını alacağınızı gösterir:

```java
// Presentation sınıfını örnekleyin ve yapıcıya bir dosya yolu geçirin.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Sunumdaki toplam slayt sayısını yazdırın.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Şifre Koruması Olan Sunumları Aç**

Şifre korumalı bir sunumu açmanız gerektiğinde, şifreyi [LoadOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/) sınıfının [setPassword](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) yöntemiyle geçirerek çözüp yükleyebilirsiniz. Aşağıdaki Java kodu bu işlemi göstermektedir:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Şifreli sunum üzerinde işlemler gerçekleştirin.
} finally {
    presentation.dispose();
}
```

## **Büyük Sunumları Aç**

Aspose.Slides, özellikle [LoadOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/) sınıfındaki [getBlobManagementOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) yöntemi gibi seçenekler sunarak büyük sunumları yüklemenize yardımcı olur.

Aşağıdaki Java kodu, büyük bir sunumu (örneğin 2 GB) yüklemeyi göstermektedir:

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// KeepLocked davranışını seçin—sunum dosyası ömrü boyunca kilitli kalır
// Presentation örneği, ancak belleğe yüklenmesi veya geçici bir dosyaya kopyalanması gerekmez.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // Büyük sunum yüklendi ve kullanılabilir, bellek tüketimi düşük kalır.

    // Sunumu değiştirin.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Sunumu başka bir dosyaya kaydedin. Bu işlem sırasında bellek tüketimi düşük kalır.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Bunu yapmayın! Dosya, sunum nesnesi serbest bırakılana kadar kilitli olduğu için bir I/O istisnası fırlatılacaktır.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Burada yapmak sorun değil. Kaynak dosya artık sunum nesnesi tarafından kilitlenmemektedir.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
Akışlarla çalışırken belirli sınırlamaları aşmak için, Aspose.Slides akışın içeriğini kopyalayabilir. Bir akıştan büyük bir sunumu yüklemek, sunumun kopyalanmasına ve yüklemenin yavaşlamasına neden olur. Bu nedenle, büyük bir sunumu yüklemeniz gerektiğinde, bir akış yerine sunum dosya yolunu kullanmanızı şiddetle öneririz.

Büyük nesneler (video, ses, yüksek çözünürlüklü görüntüler vb.) içeren bir sunum oluştururken, bellek tüketimini azaltmak için [BLOB management](/slides/tr/androidjava/manage-blob/) kullanabilirsiniz.
{{%/alert %}}

## **Harici Kaynakları Kontrol Et**

Aspose.Slides, harici kaynakları yönetmenizi sağlayan [IResourceLoadingCallback](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iresourceloadingcallback/) arayüzünü sunar. Aşağıdaki Java kodu, `IResourceLoadingCallback` arayüzünün nasıl kullanılacağını gösterir:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Bir yedek resim yükle.
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // Baytları elde etmek için herhangi bir yöntem kullanın
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Bir yedek URL ayarla.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // Diğer tüm resimleri atla.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Gömülü İkili Nesneler Olmadan Sunumları Yükle**

Bir PowerPoint sunumu aşağıdaki türlerde gömülü ikili nesneler içerebilir:

- VBA projesi ( [IPresentation.getVbaProject](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getVbaProject--) aracılığıyla erişilebilir);
- OLE nesnesi gömülü veri ( [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) aracılığıyla erişilebilir);
- ActiveX kontrol ikili verisi ( [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--) aracılığıyla erişilebilir).

[ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) yöntemini kullanarak, bir sunumu gömülü ikili nesneler olmadan yükleyebilirsiniz.

Bu yöntem, potansiyel olarak zararlı ikili içeriği kaldırmak için kullanışlıdır. Aşağıdaki Java kodu, bir sunumu gömülü ikili içerik olmadan nasıl yükleyeceğinizi gösterir:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // Sunum üzerinde işlemler gerçekleştirin.
} finally {
    presentation.dispose();
}
```

## **SSS**

**Bir dosyanın bozuk olduğunu ve açılamadığını nasıl anlayabilirim?**

Yükleme sırasında bir ayrıştırma/form doğrulama istisnası alırsınız. Bu hatalar genellikle geçersiz bir ZIP yapısı veya bozuk PowerPoint kayıtlarını belirtir.

**Açarken gerekli yazı tipleri eksikse ne olur?**

Dosya açılacaktır, ancak daha sonra [rendering/export](/slides/tr/androidjava/convert-presentation/) yazı tiplerini değiştirebilir. Çalışma zamanına [Configure font substitutions](/slides/tr/androidjava/font-substitution/) veya [add the required fonts](/slides/tr/androidjava/custom-font/) ekleyin.

**Açarken gömülü medya (video/ses) ne olur?**

Bunlar sunum kaynakları olarak kullanılabilir hale gelir. Medya dış yollarla referans gösteriliyorsa, bu yolların ortamınızda erişilebilir olduğundan emin olun; aksi takdirde [rendering/export](/slides/tr/androidjava/convert-presentation/) medya atlanabilir.