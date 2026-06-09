---
title: Kesilebilir Kütüphane Desteği
type: docs
weight: 150
url: /tr/net/support-for-interruptable-library/
keywords:
- kesilebilir kütüphane
- kesinti tokenı
- iptal tokenı
- uzun süren görev
- görevi kes
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile uzun süren görevleri iptal edilebilir hale getirin. PowerPoint ve OpenDocument için renderlemeyi ve dönüşümleri güvenli bir şekilde kesintiye uğratın, örneklerle."
---
## **Genel Bakış**

Aspose.Slides for .NET, serileştirme, serileştirme ve renderleme gibi uzun süren sunum görevleri için kesilebilir bir işleme mekanizması sağlar. Bu mekanizma `InterruptionToken` ve `InterruptionTokenSource` sınıflarına dayanır.

`InterruptionToken`, `LoadOptions`'a atanabilir ve `Presentation` yapıcıya geçirilebilir. `InterruptionTokenSource.Interrupt()` çağrıldığında, ilişkili uzun süren görev kesilir. Makale ayrıca bu mekanizmanın standart .NET `CancellationToken` ile birlikte nasıl kullanılacağını, iptal isteklerini izleyerek ve iptal istendiğinde `Interrupt()` çağırarak gösterir.

## **Kesilebilir Kütüphane**

Aspose.Slides 18.4 sürümünde ([Aspose.Slides 18.4](https://releases.aspose.com/slides/tr/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/)), [InterruptionToken](https://reference.aspose.com/slides/tr/net/aspose.slides/interruptiontoken/) ve [InterruptionTokenSource](https://reference.aspose.com/slides/tr/net/aspose.slides/interruptiontokensource/) sınıflarını tanıttık. Bu sınıflar, serileştirme, serileştirme ve renderleme gibi uzun süren görevleri kesmenize olanak tanır.

- [InterruptionTokenSource](https://reference.aspose.com/slides/tr/net/aspose.slides/interruptiontokensource/) **yönlendirilen token(ler)in kaynağıdır** ve bu token(ler) [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/tr/net/aspose.slides/iloadoptions/interruptiontoken/) üzerinden geçirilir.
- [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/tr/net/aspose.slides/iloadoptions/interruptiontoken/) ayarlandığında ve [LoadOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/) örneği [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) yapıcıya geçirildiğinde, [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/tr/net/aspose.slides/interruptiontokensource/interrupt/) çağrısı o [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) ile ilişkili herhangi bir uzun süren görevi keser.

Aşağıdaki kod parçacığı çalışan bir görevi kesmeyi gösterir:

```c#
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
    tokenSource.Interrupt();        // dönüşümü durdur
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET CancellationToken ve Kesilebilir Kütüphane**

Aspose.Slides Kesilebilir kütüphanesiyle birlikte bir [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) kullanmanız gerektiğinde, [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) işleme sürecini sarmalayıp, [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) `true` olduğunda [InterruptionToken](https://reference.aspose.com/slides/tr/net/aspose.slides/interruptiontoken/) kesintiye uğratmalısınız.

Bu C# kodu işlemi gösterir:

```cs
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

    while (!task.Wait(500)) // bekle ve cancellationToken.IsCancellationRequested'in ayarlanıp ayarlanmadığını izle
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // Presentation işlemini kesintiye uğrat
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

## **FAQ**

**Aspose.Slides kesinti kütüphanesinin amacı nedir?**

Uzun süren işlemleri—sunumları yükleme, kaydetme veya renderleme gibi—tamamlanmadan kesmenizi sağlayan bir mekanizma sunar. İşlem süresi sınırlı olduğunda veya görev artık gerekmediğinde kullanışlıdır.

**[InterruptionToken](https://reference.aspose.com/slides/tr/net/aspose.slides/interruptiontoken/) ile [InterruptionTokenSource](https://reference.aspose.com/slides/tr/net/aspose.slides/iinterruptiontokensource/) arasındaki fark nedir?**

- `InterruptionToken`, Aspose.Slides API'sine geçirilir ve uzun süren işlemler sırasında kontrol edilir.
- `InterruptionTokenSource`, kodunuzda token oluşturmak ve `Interrupt()` çağrısı yaparak kesintiyi tetiklemek için kullanılır.

**.NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) kesinti kütüphanesiyle birlikte kullanılabilir mi?**

Evet. Uygulama mantığınızda [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)'ı izleyebilir ve iptal istendiğinde [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/tr/net/aspose.slides/iinterruptiontokensource/interrupt/) çağırabilirsiniz. Bu, Aspose.Slides'in standart .NET iptal akışlarıyla bütünleşmesini sağlar.

**Hangi görevler kesilebilir?**

[InterruptionToken](https://reference.aspose.com/slides/tr/net/aspose.slides/interruptiontoken/) kabul eden her Aspose.Slides görevi—örneğin `Presentation(path, loadOptions)` ile bir sunumu yükleme veya `Presentation.Save(...)` ile kaydetme—kesilebilir.

**Kesinti hemen gerçekleşir mi?**

Hayır. Kesinti işbirlikçidir: işlem periyodik olarak tokenı kontrol eder ve [Interrupt()](https://reference.aspose.com/slides/tr/net/aspose.slides/iinterruptiontokensource/interrupt/) çağrıldığını tespit ettiğinde durur.

**Bir görev zaten tamamlanmışken [Interrupt()](https://reference.aspose.com/slides/tr/net/aspose.slides/iinterruptiontokensource/interrupt()) çağrılırsa ne olur?**

Hiçbir şey olmaz—görev zaten tamamlanmışsa çağrının bir etkisi yoktur.

**Aynı [InterruptionTokenSource](https://reference.aspose.com/slides/tr/net/aspose.slides/iinterruptiontokensource/) birden çok görev için yeniden kullanılabilir mi?**

Evet—ancak o kaynak üzerinde [Interrupt()](https://reference.aspose.com/slides/tr/net/aspose.slides/iinterruptiontokensource/interrupt/) çağrısı yapıldığında, tokenlarını kullanan tüm görevler kesilir. Görevleri bağımsız yönetmek için ayrı token kaynakları kullanın.