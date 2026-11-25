---
title: ".NET'te Uzun Süreli Sunum İşlemlerini Kesintiye Uğratma"
linktitle: "Sunum İşlemlerini Kesintiye Uğrat"
type: docs
weight: 150
url: /tr/net/support-for-interruptable-library/
keywords:
- kesintiye uğrayabilir işlemler
- kesinti belirteci
- iptal belirteci
- uzun süreli görev
- görevi kesintiye uğrat
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te uzun süren sunum işlemlerini nasıl iptal edeceğinizi ve slaytları bir döngü içinde dışa aktarırken kısmi bir sonuç nasıl döndüreceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for .NET, sunumları yükleme, kaydetme ve oluşturma gibi uzun süren işlemleri kesintiye uğratabilir. Uygulamanız aynı interruption token'ı kullanarak bir döngüyü, bir sonraki slaytı işlemeye başlamadan durdurabilir.

## **Sunum İşlemini Kesintiye Uğratma**

Bir [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) oluşturun, onun [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) özelliğini [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/) üzerine atayın ve yükleme seçeneklerini [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) metoduna geçirin. İptali talep etmek için kaynağın [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) metodunu çağırın. Kesintiye uğrayabilir bir işlem, isteği gördüğünde durur.

Örnek, `sample.pptx` dosyasını `sample.ppt` biçimine arka plan görevinde dönüştürmeye başlar ve 10 saniye sonra iptal talep eder. Dönüştürme daha erken tamamlanırsa, çıktı zaten tamamlanmış olur.

```c#
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

public static void Run()
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions { InterruptionToken = token };
        using (Presentation presentation = new Presentation("sample.pptx", options))
        {
            presentation.Save("sample.ppt", SaveFormat.Ppt);
        }
    };

    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Run(action, tokenSource.Token); // eylemi ayrı bir iş parçacığında çalıştır
    Thread.Sleep(10000);            // zaman aşımı
    tokenSource.Interrupt();        // dönüştürmeyi durdur
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET İptalini Aspose.Slides ile Bağlamak**

Eğer uygulamanız bir .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) kullanıyorsa, iptal isteğini Aspose.Slides'e iletin. Örnek, `sample.pptx` dosyasını `sample.pdf` olarak dışa aktarmaya başlar ve 20 saniyelik bir zaman aşımı ayarlar. Dışa aktarma çalışırken, her 500 milisaniyede bir [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) kontrol eder. Özellik `true` olduğunda, [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) metodunu çağırır.

```cs
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

public static void Main()
{
    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    ProcessPresentation("sample.pptx", "sample.pdf", tokenSource.Token);
}

static void ProcessPresentation(string path, string outPath, CancellationToken cancellationToken)
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions {InterruptionToken = token};
        using (Presentation presentation = new Presentation(path, options))
        {
            presentation.Save(outPath, SaveFormat.Pdf);
        }
    };
    
    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Task task = Run(action, tokenSource.Token); // eylemi ayrı bir iş parçacığında çalıştır

    while (!task.Wait(500)) // bekle ve cancellationToken.IsCancellationRequested ayarlanıp ayarlanmadığını izle
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // Presentation işleme işlemini kesintiye uğrat
        }
    }
}

private static Task Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    return Task.Run(() =>
    {
        action(token);
    });
}
```

## **Bir Sonraki Slaytı İşlemeye Başlamadan Durdurmak**

Sunum ve onun slaytlarını dışa aktaran döngü için aynı [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/) kullanın. Her dışa aktarmaya başlamadan önce [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/) kontrol edin. Çağıran kısmi bir sonuç kullanabiliyorsa, başarılı bir şekilde tamamlanan dışa aktarmaların slayt numaralarını geri döndürün.

`sample.pptx` adlı ve en az iki slayta sahip bir sunum kullanın. Örnek, ilk başarılı dışa aktarmayı kaydettikten hemen sonra iptal talep eder.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new InterruptionTokenSource();
var completed = ExportSlides("sample.pptx", source);
Console.WriteLine($"Completed: [{string.Join(", ", completed)}]");

static List<int> ExportSlides(string path, IInterruptionTokenSource source)
{
    var completed = new List<int>();
    IInterruptionToken token = source.Token;
    var options = new LoadOptions { InterruptionToken = token };
    using var presentation = new Presentation(path, options);

    for (var number = 1; number <= presentation.Slides.Count; number++)
    {
        if (token.IsInterruptionRequested)
            break;

        Console.WriteLine($"Starting slide {number}");
        try
        {
            presentation.Save($"slide-{number}.pdf", new[] { number }, SaveFormat.Pdf);
        }
        catch (OperationCanceledException) when (token.IsInterruptionRequested)
        {
            break;
        }

        completed.Add(number);
        if (number == 1)
            source.Interrupt();
    }

    return completed;
}
```

Örnek `slide-1.pdf` dosyasını yazar ve `Starting slide 1` ardından `Completed: [1]` mesajını verir. Döngü, slayt 2'ye başlamadan önce isteği görür. Eğer iptal, dışa aktarma sırasında [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) yöntemini kesintiye uğratırsa, `catch` bloğu kodun mevcut slaytı tamamlandı olarak kaydetmeden döngüyü sonlandırır.

Eğer çağıranın iptali ele alması gerekiyorsa, döngünün başındaki `if` kontrolünü ve `break` ifadesini token üzerinde [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) çağrısı ile değiştirin. Dışa aktarma etrafındaki `try`/`catch` bloklarını kaldırın, böylece kaydetme sırasında iptal de çağırana ulaşır. Aynı girdiyle örnek yalnızca `Starting slide 1` yazdırır ve `slide-1.pdf` dosyasını yazar. İkinci yinelemenin başında, dışa aktarma başlamadan önce çağıran bir [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception) alır. Metot hiçbir liste döndürmez.

## **SSS**

**İptali ne zaman talep etmeliyim?**

İşlem zaman sınırınızı aşarsa veya uygulamanız artık sonuca ihtiyaç duymuyorsa iptali talep edin.

**[InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) ve [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) arasındaki fark nedir?**

Kaynak, uygulamanızın iptali talep etmesini sağlar. Belirteç ise Aspose.Slides ve uygulamanızın bu talebi kontrol etmesine olanak tanır.

**Bir .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) ile Aspose.Slides'i kullanabilir miyim?**

Evet. .NET belirteciniz iptali işaret ettiğinde, sunumla ilişkili kaynaktaki [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) metodunu çağırın.

**Hangi işlemleri kesintiye uğratabilirim?**

Yükleme, kaydetme ve oluşturma işlemlerini kesintiye uğratabilirsiniz. Belirteci, [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/) aracılığıyla [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) metoduna iletin. Böylece sunum, sonraki işlemler sırasında, örneğin [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) gibi, iptal durumunu gözlemleyebilir.

**İşlem hemen durur mu?**

İptal işbirlikçi bir şekilde gerçekleşir. İşlem belirteci periyodik olarak kontrol eder ve isteği gördüğünde durur.

**Bir işlem bitmişken [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) çağrısı yaparsam ne olur?**

Tamamlanan işlem sonucunu korur.

**Birden fazla işlem aynı [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) paylaşabilir mi?**

Evet. [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) çağrısı, o kaynaktan bir belirteç kullanan tüm işlemler için iptali talep eder. Bağımsız olarak iptal etmek istediğiniz her işlem için ayrı bir kaynak kullanın.