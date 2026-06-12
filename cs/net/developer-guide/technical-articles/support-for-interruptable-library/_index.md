---
title: Podpora přerušitelné knihovny
type: docs
weight: 150
url: /cs/net/support-for-interruptable-library/
keywords:
- přerušitelná knihovna
- token přerušení
- token zrušení
- dlouho běžící úloha
- přerušit úlohu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Umožněte zrušení dlouho běžících úloh pomocí Aspose.Slides pro .NET. Bezpečně přerušte vykreslování a konverze pro PowerPoint a OpenDocument s příklady."
---
## **Přehled**

Aspose.Slides for .NET poskytuje přerušitelný mechanismus zpracování pro dlouho běžící úlohy prezentací, jako jsou deserializace, serializace a vykreslování. Tento mechanismus je založen na třídách `InterruptionToken` a `InterruptionTokenSource`.

`InterruptionToken` může být přiřazen k `LoadOptions` a předán konstruktoru `Presentation`. Když je zavoláno `InterruptionTokenSource.Interrupt()`, přidružená dlouho běžící úloha je přerušena. Článek také ukazuje, jak použít tento mechanismus spolu se standardním .NET `CancellationToken` sledováním požadavků na zrušení a voláním `Interrupt()`, když je zrušení požadováno.

## **Přerušitelná knihovna**

V [Aspose.Slides 18.4](https://releases.aspose.com/slides/cs/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/) jsme představili třídy [InterruptionToken](https://reference.aspose.com/slides/cs/net/aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/cs/net/aspose.slides/interruptiontokensource/). Umožňují přerušit dlouho běžící úlohy jako deserializaci, serializaci a vykreslování.

- [InterruptionTokenSource](https://reference.aspose.com/slides/cs/net/aspose.slides/interruptiontokensource/) je zdrojem tokenu(ů) předávaných do [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/cs/net/aspose.slides/iloadoptions/interruptiontoken/).
- Když je [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/cs/net/aspose.slides/iloadoptions/interruptiontoken/) nastaven a instance [LoadOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/) je předána konstruktoru [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/), zavolání [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/cs/net/aspose.slides/interruptiontokensource/interrupt/) přeruší jakoukoli dlouho běžící úlohu spojenou s touto [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).

Následující úryvek kódu ukazuje přerušení běžící úlohy:

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
    Run(action, tokenSource.Token); // spusťte akci v samostatném vlákně
    Thread.Sleep(10000);            // časový limit
    tokenSource.Interrupt();        // zastavte konverzi
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET CancellationToken a přerušitelná knihovna**

Když potřebujete použít [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) společně s přerušitelnou knihovnou Aspose.Slides, zabalte zpracování [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a přerušte [InterruptionToken](https://reference.aspose.com/slides/cs/net/aspose.slides/interruptiontoken/), když je [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) nastaven na `true`.

Tento C# kód demonstruje operaci:

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
    Task task = Run(action, tokenSource.Token); // spusťte akci v samostatném vlákně

    while (!task.Wait(500)) // čekejte a sledujte, zda je nastaveno cancellationToken.IsCancellationRequested
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // přerušte zpracování prezentace
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

## **Často kladené otázky**

**Jaký je účel přerušitelné knihovny Aspose.Slides?**

Poskytuje mechanismus pro přerušení dlouho běžících operací — například načítání, ukládání nebo vykreslování prezentací — před jejich dokončením. To je užitečné, když je nutné omezit čas zpracování nebo už úloha není potřeba.

**Jaký je rozdíl mezi [InterruptionToken](https://reference.aspose.com/slides/cs/net/aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/cs/net/aspose.slides/iinterruptiontokensource/)?**

- `InterruptionToken` je předáván API Aspose.Slides a kontrolován během dlouho běžících operací.  
- `InterruptionTokenSource` se používá ve vašem kódu k vytvoření tokenů a vyvolání přerušení voláním `Interrupt()`.

**Mohu použít .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) s přerušitelnou knihovnou?**

Ano. Můžete sledovat [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) ve své aplikační logice a zavolat [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/cs/net/aspose.slides/iinterruptiontokensource/interrupt/), když je zrušení požadováno. To umožňuje Aspose.Slides integrovat se se standardními .NET workflow pro zrušení.

**Jaké úlohy lze přerušit?**

Jakákoli úloha Aspose.Slides, která přijímá [InterruptionToken](https://reference.aspose.com/slides/cs/net/aspose.slides/interruptiontoken/) — například načtení prezentace pomocí `Presentation(path, loadOptions)` nebo ukládání pomocí `Presentation.Save(...)` — může být přerušena.

**Probíhá přerušení okamžitě?**

Ne. Přerušení je kooperativní: operace periodicky kontroluje token a zastaví se, jakmile zjistí, že bylo zavoláno [Interrupt()](https://reference.aspose.com/slides/cs/net/aspose.slides/iinterruptiontokensource/interrupt/).

**Co se stane, když zavolám [Interrupt()](https://reference.aspose.com/slides/cs/net/aspose.slides/iinterruptiontokensource/interrupt/) po dokončení úlohy?**

Nic — volání nemá žádný účinek, pokud již byla příslušná úloha dokončena.

**Mohu znovu použít stejný [InterruptionTokenSource](https://reference.aspose.com/slides/cs/net/aspose.slides/iinterruptiontokensource/) pro více úloh?**

Ano — ale po zavolání [Interrupt()](https://reference.aspose.com/slides/cs/net/aspose.slides/iinterruptiontokensource/interrupt/) na tomto zdroji budou všechny úlohy používající jeho tokeny přerušeny. Používejte samostatné zdroje tokenů pro nezávislé řízení úloh.