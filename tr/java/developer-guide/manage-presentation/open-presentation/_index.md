---
title: Java'da Sunumları Açma
linktitle: Sunumu Aç
type: docs
weight: 20
url: /tr/java/open-presentation/
keywords:
- PowerPoint'ı aç
- OpenDocument'ı aç
- sunumu aç
- PPTX'i aç
- PPT'yi aç
- ODP'yi aç
- sunumu yükle
- PPTX'i yükle
- PPT'yi yükle
- ODP'yi yükle
- korumalı sunum
- büyük sunum
- harici kaynak
- ikili nesne
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint (.pptx, .ppt) ve OpenDocument (.odp) sunumlarını zahmetsizce açın—hızlı, güvenilir, tam özellikli."
---
## **Giriş**

PowerPoint sunumlarını sıfırdan oluşturmanın ötesinde, Aspose.Slides mevcut sunumları da açmanıza olanak tanır. Bir sunumu yükledikten sonra, onunla ilgili bilgileri alabilir, slayt içeriğini düzenleyebilir, yeni slaytlar ekleyebilir, mevcutları kaldırabilir ve daha fazlasını yapabilirsiniz.

## **Sunumları Açma**

Mevcut bir sunumu açmak için, [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun ve dosya yolunu yapıcıya geçirin.

İşte aşağıdaki Java örneği, bir sunumu nasıl açıp slayt sayısını alabileceğinizi gösterir:

```java
// Sunum sınıfını örnekleyin ve yapıcıya bir dosya yolu geçirin.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Sunumdaki toplam slayt sayısını yazdırın.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Şifre Korumasına Sahip Sunumları Açma**

Şifre korumalı bir sunumu açmanız gerektiğinde, şifreyi [LoadOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/) sınıfının [setPassword](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) yöntemiyle geçirerek çözüp yükleyebilirsiniz. Aşağıdaki Java kodu bu işlemi gösterir:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Şifre çözülmüş sunum üzerinde işlemler gerçekleştir.
} finally {
    presentation.dispose();
}
```

## **Büyük Sunumları Açma**

Aspose.Slides, büyük sunumları yüklemenize yardımcı olmak için seçenekler sunar—özellikle [LoadOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/) sınıfındaki [getBlobManagementOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) yöntemi.

Aşağıdaki Java kodu, büyük bir sunumun (örneğin 2 GB) nasıl yükleneceğini gösterir:

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// KeepLocked davranışını seçin—sunum dosyası ömrü boyunca
// Presentation örneği için; ancak belleğe yüklenmesi veya geçici bir dosyaya kopyalanması gerekmez.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // Büyük sunum yüklendi ve kullanılabilir, bellek tüketimi düşük kalır.

    // Sunuma değişiklik yapın.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Sunumu başka bir dosyaya kaydedin. Bu işlem sırasında bellek tüketimi düşük kalır.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Bunu yapmayın! Dosya, sunum nesnesi dispose edilene kadar kilitli olduğu için bir I/O istisnası oluşur.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Burada yapmak uygundur. Kaynak dosya artık sunum nesnesi tarafından kilitlenmemiştir.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
Akışlarla çalışırken belirli sınırlamaları aşmak için, Aspose.Slides bir akışın içeriğini kopyalayabilir. Bir akıştan büyük bir sunumu yüklemek, sunumun kopyalanmasına ve yüklemenin yavaşlamasına neden olur. Bu nedenle, büyük bir sunumu yüklemeniz gerektiğinde, bir akış yerine sunum dosya yolunu kullanmanızı şiddetle öneririz.

Büyük nesneler (video, ses, yüksek çözünürlüklü görüntüler vb.) içeren bir sunum oluştururken, bellek tüketimini azaltmak için [BLOB management](/slides/tr/java/manage-blob/) kullanabilirsiniz.
{{%/alert %}}

## **Harici Kaynakları Kontrol Etme**

Aspose.Slides, harici kaynakları yönetmenizi sağlayan [IResourceLoadingCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iresourceloadingcallback/) arayüzünü sunar. Aşağıdaki Java kodu, `IResourceLoadingCallback` arayüzünün nasıl kullanılacağını gösterir:

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
                // Yerine geçecek bir görüntü yükle.
                byte[] imageData = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Yerine geçecek bir URL ayarla.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // Diğer tüm görüntüleri atla.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Gömülü İkili Nesneler Olmadan Sunumları Yükleme**

Bir PowerPoint sunumu aşağıdaki türlerde gömülü ikili nesneler içerebilir:

- VBA projesi (erişilebilir [IPresentation.getVbaProject](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getVbaProject--));
- OLE nesnesi gömülü verisi (erişilebilir [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- ActiveX kontrol ikili verisi (erişilebilir [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

[ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) yöntemini kullanarak, gömülü ikili nesneler olmadan bir sunum yükleyebilirsiniz.

Bu yöntem, potansiyel olarak zararlı ikili içeriği kaldırmak için faydalıdır. Aşağıdaki Java kodu, gömülü ikili içerik olmadan bir sunumun nasıl yükleneceğini gösterir:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // Sunum üzerinde işlemler gerçekleştir.
} finally {
    presentation.dispose();
}
```

## **SSS**

**Bir dosyanın bozuk olduğunu ve açılamadığını nasıl anlayabilirim?**

Yükleme sırasında bir ayrıştırma/biçim doğrulama istisnası alırsınız. Bu tür hatalar genellikle geçersiz bir ZIP yapısı ya da bozuk PowerPoint kayıtlarından bahseder.

**Açarken gerekli yazı tipleri eksikse ne olur?**

Dosya açılır, ancak daha sonra [rendering/export](/slides/tr/java/convert-presentation/) yazı tiplerini değiştirebilir. Çalışma zamanına [Yazı tipi ikamelerini yapılandırın](/slides/tr/java/font-substitution/) veya [gerekli yazı tiplerini ekleyin](/slides/tr/java/custom-font/) ekleyin.

**Açarken gömülü medya (video/ses) ne olur?**

Medya, sunum kaynakları olarak kullanılabilir hale gelir. Medya dış yollarla referans gösteriliyorsa, bu yolların ortamınızda erişilebilir olduğundan emin olun; aksi takdirde [rendering/export](/slides/tr/java/convert-presentation/) medyayı atlayabilir.