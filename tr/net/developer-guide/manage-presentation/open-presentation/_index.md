---
title: .NET'te Sunumları Aç
linktitle: Sunumu Aç
type: docs
weight: 20
url: /tr/net/open-presentation/
keywords:
- PowerPoint'ı aç
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint (.pptx, .ppt) ve OpenDocument (.odp) sunumlarını zahmetsizce açın—hızlı, güvenilir, tam özellikli."
---
## **Giriş**

Sıfırdan PowerPoint sunumları oluşturmanın yanı sıra Aspose.Slides mevcut sunumları da açmanıza olanak tanır. Bir sunumu yükledikten sonra hakkında bilgi alabilir, slayt içeriğini düzenleyebilir, yeni slaytlar ekleyebilir, mevcut slaytları kaldırabilir ve daha fazlasını yapabilirsiniz.

## **Sunumları Aç**

Mevcut bir sunumu açmak için [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturup dosya yolunu yapıcıya geçirin.

Aşağıdaki C# örneği, bir sunumu nasıl açıp slayt sayısını alacağınızı gösterir:

```cs
// Presentation sınıfını örnekleyin ve yapıcıya bir dosya yolu geçirin.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Sunumdaki toplam slayt sayısını yazdır.
    System.Console.WriteLine(presentation.Slides.Count);
}
```

## **Şifre Koruması Olan Sunumları Aç**

Şifre korumalı bir sunumu açmanız gerektiğinde, şifreyi [Password](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/password/) özelliğiyle [LoadOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/) sınıfına geçirerek şifreyi çözüp yükleyebilirsiniz. Aşağıdaki C# kodu bu işlemi gösterir:

```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Şifre çözülmüş sunum üzerinde işlemler gerçekleştirin.
}
```

## **Büyük Sunumları Aç**

Aspose.Slides, özellikle [LoadOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/) sınıfındaki [BlobManagementOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/blobmanagementoptions/) özelliği gibi seçenekler sunarak büyük sunumları yüklemenize yardımcı olur.

Aşağıdaki C# kodu, büyük bir sunumun (örneğin 2 GB) nasıl yükleneceğini gösterir:

```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // KeepLocked davranışını seçin—sunum dosyası, yaşam süresi boyunca kilitli kalacaktır 
        // Presentation örneği için, ancak belleğe yüklenmesi veya geçici bir dosyaya kopyalanması gerekmez.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // Büyük sunum yüklendi ve kullanılabilir, bellek tüketimi düşük kalır.

    // Sunumu değiştirin.
    presentation.Slides[0].Name = "Large presentation";

    // Sunumu başka bir dosyaya kaydedin. Bu işlem sırasında bellek tüketimi düşük kalır.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Bunu yapmayın! Dosya, presentation nesnesi serbest bırakılana kadar kilitli olduğu için bir I/O istisnası fırlatılır.
    File.Delete(filePath);
}

// Burada yapmak güvenlidir. Kaynak dosya artık presentation nesnesi tarafından kilitli değildir.
File.Delete(filePath);
```

{{% alert color="info" title="Info" %}}
Akışlarla çalışırken bazı sınırlamaları aşmak için Aspose.Slides bir akışın içeriğini kopyalayabilir. Bir akıştan büyük bir sunum yüklemek, sunumun kopyalanmasına ve yükleme süresinin yavaşlamasına neden olur. Bu nedenle, büyük bir sunumu yüklemeniz gerektiğinde akış yerine sunum dosya yolunu kullanmanızı şiddetle öneririz.

Büyük nesneler (video, ses, yüksek çözünürlüklü görseller vb.) içeren bir sunum oluştururken bellek tüketimini azaltmak için [BLOB yönetimini](/slides/tr/net/manage-blob/) kullanabilirsiniz.
{{%/alert %}}

## **Harici Kaynakları Kontrol Et**

Aspose.Slides, harici kaynakları yönetmenize olanak tanıyan [IResourceLoadingCallback](https://reference.aspose.com/slides/tr/net/aspose.slides/iresourceloadingcallback/) arayüzünü sağlar. Aşağıdaki C# kodu, `IResourceLoadingCallback` arayüzünün nasıl kullanılacağını gösterir:

```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // Yerine bir resim yükle.
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // Yerine bir URL ayarla.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Diğer tüm resimleri atla.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Gömülü İkili Nesneler Olmadan Sunumları Yükle**

Bir PowerPoint sunumu aşağıdaki türde gömülü ikili nesneler içerebilir:

- VBA projesi (erişim: [IPresentation.VbaProject](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/vbaproject/));
- OLE nesnesi gömülü verisi (erişim: [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/tr/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- ActiveX kontrol ikili verisi (erişim: [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/tr/net/aspose.slides/icontrol/activexcontrolbinary/)).

[ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/tr/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) özelliğini kullanarak gömülü ikili nesneler içermeyen bir sunum yükleyebilirsiniz.

Bu özellik, potansiyel olarak zararlı ikili içeriği kaldırmak için faydalıdır. Aşağıdaki C# kodu, gömülü ikili içerik olmadan bir sunumun nasıl yükleneceğini göstermektedir:

```cs
LoadOptions loadOptions = new LoadOptions()
{
    DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // Sunum üzerinde işlemler gerçekleştir.
}
```

## **SSS**

**Bir dosyanın bozuk olduğunu ve açılamadığını nasıl anlayabilirim?**

Yükleme sırasında bir ayrıştırma/biçim doğrulama hatası alırsınız. Bu hatalar genellikle geçersiz ZIP yapısı veya bozuk PowerPoint kayıtlarından bahseder.

**Açarken gerekli yazı tipleri eksikse ne olur?**

Dosya açılır, ancak daha sonra [renderlama/dönüştürme](/slides/tr/net/convert-presentation/) sırasında yazı tipleri değiştirilmiş olabilir. Çalışma zaman ortamına [yazı tipi ikameleri yapılandırın](/slides/tr/net/font-substitution/) veya [gerekli yazı tiplerini ekleyin](/slides/tr/net/custom-font/).

**Açarken gömülü medya (video/ses) ne olur?**

Medya, sunum kaynakları olarak kullanılabilir hâle gelir. Medya dış yollarla referanslanıyorsa, bu yolların ortamınızda erişilebilir olduğundan emin olun; aksi takdirde [renderlama/dönüştürme](/slides/tr/net/convert-presentation/) medya atlanabilir.