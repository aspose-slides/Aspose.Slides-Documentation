---
title: .NET'te Sunumları Açma
linktitle: Sunumu Aç
type: docs
weight: 20
url: /tr/net/open-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "C# dilinde PowerPoint ve OpenDocument sunumlarını açmayı, açma parolaları sağlamayı, kaynak yüklemeyi kontrol etmeyi ve Aspose.Slides for .NET ile bellek kullanımını azaltmayı öğrenin."
---
## **Giriş**

[Aspose.Slides for .NET](https://products.aspose.com/slides/tr/net/) PowerPoint ve OpenDocument sunumlarını dosyalardan ve akışlardan yükleyebilir. Bir sunum yüklendikten sonra, yapısını inceleyebilir, slaytları düzenleyebilir, kaynakları yönetebilir ve orijinal ya da başka bir desteklenen formatta kaydedebilirsiniz.

Yükleme davranışı, [LoadOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/) sınıfı aracılığıyla özelleştirilebilir. Örneğin, bir açma parolası sağlayabilir, büyük ikili nesneleri yönetilen bellek dışında tutabilir, harici kaynakları kontrol edebilir veya yerleşik ikili verileri atlayabilirsiniz.

## **Sunumları Açma**

Bir dosya ya da akış yüklendikten sonra, uygulamanızın nasıl işleyeceğini seçmek için [orijinal sunum formatını belirleyebilir](/slides/tr/net/detect-presentation-source-format/).

Mevcut bir sunumu açmak için, dosya yolunu [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) yapıcısına geçiriniz. Sunumu kullandıktan sonra, dosya tanıtıcıları, geçici veriler ve diğer kaynakların hızlıca serbest bırakılması için Dispose edin.

Aşağıdaki C# örneği, bir sunumu nasıl açıp slayt sayısını alabileceğinizi gösterir:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Parola Koruması Olan Sunumları Açma**

Açma parolası, sunum içeriğini şifreler. Sunumun tamamını yüklemek için doğru parolayı [LoadOptions.Password](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/password/) özelliğine atayın ve seçenekleri [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) yapıcısına iletin. Parola eksik ya da hatalı olduğunda yükleme başarısız olur.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Parola algılama, doğrulama ve şifreleme iş akışları için [Password-Protect Presentations](/slides/tr/net/password-protected-presentation/) bölümüne bakın. Şifreli bir sunum, kasıtlı olarak herkese açık belge özellikleriyle kaydedildiyse, bu özellikler parola olmadan okunabilir; [Manage Presentation Properties](/slides/tr/net/presentation-properties/) bölümüne bakın.

## **Büyük Sunumları Açma**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/blobmanagementoptions/) Aspose.Slides'in görüntüler, ses ve video gibi büyük ikili nesneleri (BLOB) nasıl ele alacağını kontrol eder. Kaynak dosyayı kilitli tutabilir, geçici dosyalara izin verebilir ve bellekte tutulan BLOB veri miktarını sınırlayabilirsiniz.

Aşağıdaki C# kodu, büyük bir sunumu (örneğin 2 GB) nasıl yükleyeceğinizi gösterir:

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
`PresentationLockingBehavior.KeepLocked` ile kaynak dosya, `Presentation` nesnesi dispose edilene kadar kilitli kalır. Bu nesne yaşamdayken kaynak dosyayı taşıma, üzerine yazma veya silme yapmayın.

Aspose.Slides, yükleme sırasında bir giriş akışının içeriğini kopyalayabilir. Büyük sunumlar için dosya yolu genellikle akışa göre daha verimlidir. Ek depolama ve bellek yönetimi seçenekleri için [Manage BLOBs](/slides/tr/net/manage-blob/) bölümüne bakın.
{{% /alert %}}

## **Harici Kaynakları Kontrol Etme**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/resourceloadingcallback/) bir [IResourceLoadingCallback](https://reference.aspose.com/slides/tr/net/aspose.slides/iresourceloadingcallback/) uygulamasını kabul eder. Geri çağrı, yerine geçecek veri sağlayabilir, bir kaynağı yeniden yönlendirebilir, varsayılan yükleyiciyi kullanabilir veya kaynağı atlayabilir. Bu, sunumlarda uygulamaya özgü güvenlik veya depolama kurallarına göre çözülmesi gereken harici görüntüler bulunduğunda faydalıdır.

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

## **Yerleşik İkili Nesneler Olmadan Sunumları Yükleme**

Bir sunum, uygulamanın ihtiyaç duymadığı veya tutmak istemediği yerleşik ikili veri içerebilir. Örnekler:

- VBA projeleri, [IPresentation.VbaProject](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/vbaproject/) aracılığıyla erişilebilir;
- yerleşik OLE verileri, [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/tr/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/) aracılığıyla erişilebilir;
- ActiveX kontrol verileri, [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/tr/net/aspose.slides/icontrol/activexcontrolbinary/) aracılığıyla erişilebilir.

[LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) özelliğini `true` olarak ayarlayarak bu ikili verileri yükleme sırasında kaldırabilirsiniz. Yüklenen sunumu kaydederek temizlenmiş sonucu kalıcı hale getirin.

Bu seçenek, istenmeyen yerleşik yükleri azaltır, ancak tam bir kötü amaçlı yazılım tespiti ya da içerik temizleme sistemi değildir.

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

Aspose.Slides, yükleme sırasında bir ayrıştırma veya format istisnası fırlatır. Uygulamanın nedeni doğru şekilde raporlayabilmesi için bu hatayı hatalı parola hatasından ayrı olarak ele alın.

**Gerekli yazı tipleri eksikse ne olur?**

Sunum yine de yüklenebilir, ancak renderleme ve dışa aktarma sırasında yazı tipleri değiştirilebilir. Çıktıyı daha öngörülebilir hâle getirmek için [font substitution](/slides/tr/net/font-substitution/) yapılandırabilir veya [custom fonts](/slides/tr/net/custom-font/) sağlayabilirsiniz.

**Bir sunumu yüklemek aynı zamanda yerleşik medyasını da yükler mi?**

Yerleşik ses ve video, sunum nesne modeli üzerinden erişilebilir hale gelir. Harici kaynaklar, yapılandırılan kaynak yükleme davranışına göre çözülür ve konumlarına erişilemezse kullanılamayabilir.