---
title: Megszakítható könyvtár támogatása
type: docs
weight: 150
url: /hu/net/support-for-interruptable-library/
keywords:
- megszakítható könyvtár
- megszakítási token
- leállítási token
- hosszú ideig futó feladat
- feladat megszakítása
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tegye megszakíthatóvá a hosszú ideig futó feladatokat az Aspose.Slides for .NET használatával. Biztonságosan szakítsa meg a PowerPoint és OpenDocument megjelenítést és konverziókat, példákkal."
---
## **Áttekintés**

Az Aspose.Slides for .NET egy megszakítható feldolgozási mechanizmust biztosít a hosszú ideig futó prezentációs feladatokhoz, például a deszerializációhoz, sorosításhoz és megjelenítéshez. Ez a mechanizmus a `InterruptionToken` és a `InterruptionTokenSource` osztályokon alapul.

Egy `InterruptionToken` hozzárendelhető a `LoadOptions`-hez, és átadható a `Presentation` konstruktorának. Amikor a `InterruptionTokenSource.Interrupt()` meghívásra kerül, a kapcsolódó hosszú ideig futó feladat megszakad. A cikk bemutatja, hogyan lehet ezt a mechanizmust együtt használni a szabványos .NET `CancellationToken`-nel a leállítási kérések figyelésével, és a `Interrupt()` meghívásával, amikor a leállítás kérése érkezik.

## **Megszakítható Könyvtár**

Az [Aspose.Slides 18.4](https://releases.aspose.com/slides/hu/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/) bevezetésével felvettük a [InterruptionToken](https://reference.aspose.com/slides/hu/net/aspose.slides/interruptiontoken/) és a [InterruptionTokenSource](https://reference.aspose.com/slides/hu/net/aspose.slides/interruptiontokensource/) osztályokat. Ezek lehetővé teszik a hosszú ideig futó feladatok, például a deszerializáció, sorosítás és megjelenítés megszakítását.

- [InterruptionTokenSource](https://reference.aspose.com/slides/hu/net/aspose.slides/interruptiontokensource/) a token(ek) forrása, amely(ek)et a [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/hu/net/aspose.slides/iloadoptions/interruptiontoken/) kapja.
- Amikor a [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/hu/net/aspose.slides/iloadoptions/interruptiontoken/) be van állítva, és a [LoadOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/) példány átadásra kerül a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) konstruktorába, a [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/hu/net/aspose.slides/interruptiontokensource/interrupt/) meghívása megszakítja a hozzá kapcsolódó hosszú ideig futó feladatot.

A következő kódrészlet bemutatja egy futó feladat megszakítását:

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
    Run(action, tokenSource.Token); // a művelet futtatása külön szálon
    Thread.Sleep(10000);            // időkorlát
    tokenSource.Interrupt();        // a konverzió leállítása
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET CancellationToken és Megszakítható Könyvtár**

Amikor egy [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) használata szükséges az Aspose.Slides Megszakítható könyvtárral együtt, csomagolja be a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) feldolgozást, és szakítsa meg a [InterruptionToken](https://reference.aspose.com/slides/hu/net/aspose.slides/interruptiontoken/), ha a [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) értéke `true`.

Ez a C# kód bemutatja a működést:

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
    Task task = Run(action, tokenSource.Token); // a művelet futtatása külön szálon

    while (!task.Wait(500)) // várakozik és figyeli, hogy a cancellationToken.IsCancellationRequested be legyen állítva
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // a Presentation feldolgozásának megszakítása
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

## **GYIK**

**Mi a célja az Aspose.Slides megszakítási könyvtárnak?**

Ez egy mechanizmust biztosít a hosszú ideig futó műveletek — például a prezentációk betöltése, mentése vagy renderelése — megszakítására, mielőtt befejeződnek. Hasznos, ha a feldolgozási időt korlátozni kell, vagy a feladat már nem szükséges.

**Mi a különbség a [InterruptionToken](https://reference.aspose.com/slides/hu/net/aspose.slides/interruptiontoken/) és a [InterruptionTokenSource](https://reference.aspose.com/slides/hu/net/aspose.slides/iinterruptiontokensource/)?**

- `InterruptionToken` átadásra kerül az Aspose.Slides API-nak, és a hosszú ideig futó műveletek során ellenőrzésre kerül.
- `InterruptionTokenSource` a kódban használatos tokenek létrehozására és a megszakítások kiváltására a `Interrupt()` meghívásával.

**Használhatom a .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)-t a megszakítási könyvtárral?**

Igen. Figyelheti a [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)-t az alkalmazás logikájában, és a leállítás kérésére meghívhatja a [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/hu/net/aspose.slides/iinterruptiontokensource/interrupt/)-t. Ez lehetővé teszi, hogy az Aspose.Slides integrálódjon a szabványos .NET leállítási munkafolyamatokkal.

**Milyen feladatok szakíthatók meg?**

Bármely Aspose.Slides feladat, amely elfogad egy [InterruptionToken](https://reference.aspose.com/slides/hu/net/aspose.slides/interruptiontoken/)-t — például egy prezentáció betöltése a `Presentation(path, loadOptions)` vagy mentése a `Presentation.Save(...)` segítségével — megszakítható.

**A megszakítás azonnal megtörténik?**

Nem. A megszakítás együttműködésen alapul: a művelet időről‑időre ellenőrzi a tokent, és akkor áll le, amikor észleli, hogy a [Interrupt()](https://reference.aspose.com/slides/hu/net/aspose.slides/iinterruptiontokensource/interrupt/) meghívásra került.

**Mi történik, ha a [Interrupt()](https://reference.aspose.com/slides/hu/net/aspose.slides/iinterruptiontokensource/interrupt/) meghívását egy már befejezett feladat után hajtom végre?**

Semmi — a hívás nem lesz hatással, ha a kapcsolódó feladat már befejeződött.

**Újra felhasználhatom ugyanazt a [InterruptionTokenSource](https://reference.aspose.com/slides/hu/net/aspose.slides/iinterruptiontokensource/)‑t több feladathoz?**

Igen — de miután a [Interrupt()](https://reference.aspose.com/slides/hu/net/aspose.slides/iinterruptiontokensource/interrupt/) meghívásra került azon a forráson, az összes, a tokenjeit használó feladat megszakad. Használjon külön tokenforrásokat a feladatok független kezeléséhez.