---
title: .NET'te Sunumları Açma
linktitle: Sunumu Aç
type: docs
weight: 20
url: /tr/net/open-presentation/
keywords:
- PowerPoint Aç
- Sunum Aç
- PPTX Aç
- PPT Aç
- ODP Aç
- Sunumu Yükle
- PPTX Yükle
- PPT Yükle
- ODP Yükle
- Korunan Sunum
- Büyük Sunum
- Harici Kaynak
- İkili Nesne
- .NET
- C#
- Aspose.Slides
description: "C# ile PowerPoint ve OpenDocument sunumlarını nasıl açacağınızı, açma parolaları sağlayarak, kaynak yüklemeyi kontrol ederek ve Aspose.Slides for .NET ile bellek kullanımını nasıl azaltacağınızı öğrenin."
---
## **Giriş**

[Aspose.Slides for .NET](https://products.aspose.com/slides/tr/net/) dosyalardan ve akışlardan PowerPoint ve OpenDocument sunumlarını yükleyebilir. Bir sunum yüklendikten sonra yapısını inceleyebilir, slaytları düzenleyebilir, kaynakları yönetebilir ve orijinal ya da başka bir desteklenen formatta kaydedebilirsiniz.

Yükleme davranışı, [LoadOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/) sınıfı aracılığıyla özelleştirilebilir. Örneğin, bir açma parolası sağlayabilir, büyük ikili nesneleri yönetilen bellek dışında tutabilir, harici kaynakları kontrol edebilir veya gömülü ikili verileri atlayabilirsiniz.

## **Sunumları Aç**

Mevcut bir sunumu açmak için dosya yolunu [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) yapıcısına aktarın. Sunumu kullandıktan sonra, dosya tanıtıcılarının, geçici verilerin ve diğer kaynakların hızla serbest bırakılması için nesneyi dispose edin.

Aşağıdaki C# örneği, bir sunumu nasıl açıp slayt sayısını alacağınızı gösterir:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Parola Koruması Olan Sunumları Aç**

Açma parolası, sunum içeriğini şifreler. Sunumun tamamını yüklemek için doğru parolayı [LoadOptions.Password](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/password/) özelliğine atayın ve seçenekleri [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) yapıcısına gönderin. Parola eksik ya da yanlış olduğunda yükleme başarısız olur.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Parola tespiti, doğrulama ve şifreleme iş akışları için [Password-Protect Presentations](/slides/tr/net/password-protected-presentation/) adresine bakın. Şifreli bir sunum, kasıtlı olarak genel belge özellikleriyle kaydedildiyse, bu özellikler parola olmadan okunabilir; [Manage Presentation Properties](/slides/tr/net/presentation-properties/) bölümüne bakın.

## **Büyük Sunumları Aç**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/blobmanagementoptions/) Aspose.Slides’ın resim, ses ve video gibi ikili büyük nesneleri (BLOB) nasıl yönettiğini kontrol eder. Kaynak dosyayı kilitli tutabilir, geçici dosyalara izin verebilir ve bellekte tutulan BLOB veri miktarını sınırlayabilirsiniz.

Aşağıdaki C# kodu, büyük bir sunumun (örneğin 2 GB) nasıl yükleneceğini gösterir:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
`PresentationLockingBehavior.KeepLocked` ile kaynak dosya, `Presentation` nesnesi dispose edilene kadar kilitli kalır. Bu nesne hâlâ var olduğu sürece kaynak dosyayı taşımayın, üzerine yazmayın veya silmeyin.

Aspose.Slides, yükleme sırasında bir giriş akışının içeriğini kopyalayabilir. Büyük sunumlar için bir dosya yolu genellikle akışa göre daha verimlidir. Ek depolama ve bellek yönetimi seçenekleri için [Manage BLOBs](/slides/tr/net/manage-blob/) adresine bakın.
{{% /alert %}}

## **Harici Kaynakları Kontrol Et**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/resourceloadingcallback/) bir [IResourceLoadingCallback](https://reference.aspose.com/slides/tr/net/aspose.slides/iresourceloadingcallback/) uygulamasını kabul eder. Geri çağırma, yerine veri sağlayabilir, bir kaynağı yönlendirebilir, varsayılan yükleyiciyi kullanabilir veya kaynağı atlayabilir. Bu, sunumların uygulamaya özel güvenlik veya depolama kurallarına göre çözülmesi gereken harici resimler içermesi durumunda yararlıdır.

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **Gömülü İkili Nesneler Olmadan Sunumları Yükle**

Bir sunum, uygulamanın gerektirmediği veya saklamak istemediği gömülü ikili veri içerebilir. Örnekler:

- VBA projeleri, [IPresentation.VbaProject](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/vbaproject/) aracılığıyla kullanılabilir;
- gömülü OLE verileri, [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/tr/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/) aracılığıyla erişilebilir;
- ActiveX kontrol verileri, [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/tr/net/aspose.slides/icontrol/activexcontrolbinary/) aracılığıyla sağlanır.

[LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) özelliğini `true` olarak ayarlayarak bu ikili verileri yükleme sırasında kaldırabilirsiniz. Temizlenmiş sonucu korumak için yüklenen sunumu kaydedin.

Bu seçenek, istenmeyen gömülü yüklerin ortaya çıkmasını azaltır, ancak tam bir kötü amaçlı yazılım tespiti veya içerik temizleme sistemi değildir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **SSS**

**Bir dosyanın bozuk olduğunu ve açılamadığını nasıl anlayabilirim?**

Aspose.Slides, yükleme sırasında bir ayrıştırma veya format istisnası fırlatır. Bu hatayı, yanlış parola hatasından ayrı şekilde yakalayarak uygulamanın nedeni doğru şekilde raporlamasını sağlayın.

**Gerekli yazı tipleri eksikse ne olur?**

Sunum yine de yüklenebilir, ancak renderleme ve dışa aktarma işleminde yazı tipleri değiştirilebilir. Çıktıyı daha öngörülebilir hâle getirmek için [font ikamesini yapılandır](/slides/tr/net/font-substitution/) veya [özel yazı tipleri sağlayın](/slides/tr/net/custom-font/) işlemlerini yapabilirsiniz.

**Bir sunumu yüklemek aynı zamanda gömülü medyasını da yükler mi?**

Gömülü ses ve video, sunum nesne modeli aracılığıyla kullanılabilir hâle gelir. Harici kaynaklar, yapılandırılmış kaynak‑yükleme davranışına göre çözülür ve konumlarına erişilemezse kullanılamayabilir.