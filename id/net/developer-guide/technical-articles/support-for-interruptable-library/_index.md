---
title: Dukungan Untuk Perpustakaan yang Dapat Diinterupsi
type: docs
weight: 150
url: /id/net/support-for-interruptable-library/
keywords:
- perpustakaan yang dapat diinterupsi
- token interupsi
- token pembatalan
- tugas yang berjalan lama
- tugas interupsi
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Buat tugas yang berjalan lama dapat dibatalkan dengan Aspose.Slides untuk .NET. Interupsi proses rendering dan konversi untuk PowerPoint dan OpenDocument secara aman, dengan contoh."
---
## **Ikhtisar**

Aspose.Slides untuk .NET menyediakan mekanisme pemrosesan yang dapat diinterupsi untuk tugas presentasi yang memakan waktu lama, seperti deserialisasi, serialisasi, dan rendering. Mekanisme ini didasarkan pada kelas `InterruptionToken` dan `InterruptionTokenSource`.

`InterruptionToken` dapat ditetapkan ke `LoadOptions` dan diteruskan ke konstruktor `Presentation`. Ketika `InterruptionTokenSource.Interrupt()` dipanggil, tugas yang berjalan lama terkait akan diinterupsi. Artikel ini juga menunjukkan cara menggunakan mekanisme ini bersamaan dengan `CancellationToken` standar .NET dengan memantau permintaan pembatalan dan memanggil `Interrupt()` ketika pembatalan diminta.

## **Perpustakaan yang Dapat Diinterupsi**

Di [Aspose.Slides 18.4](https://releases.aspose.com/slides/id/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/), kami memperkenalkan kelas [InterruptionToken](https://reference.aspose.com/slides/id/net/aspose.slides/interruptiontoken/) dan [InterruptionTokenSource](https://reference.aspose.com/slides/id/net/aspose.slides/interruptiontokensource/). Mereka memungkinkan Anda menginterupsi tugas yang berjalan lama seperti deserialisasi, serialisasi, dan rendering.

- [InterruptionTokenSource](https://reference.aspose.com/slides/id/net/aspose.slides/interruptiontokensource/) adalah sumber token yang diteruskan ke [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/id/net/aspose.slides/iloadoptions/interruptiontoken/).
- Ketika [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/id/net/aspose.slides/iloadoptions/interruptiontoken/) diatur dan instance [LoadOptions](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/) diteruskan ke konstruktor [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/), pemanggilan [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/id/net/aspose.slides/interruptiontokensource/interrupt/) menginterupsi semua tugas yang berjalan lama yang terkait dengan [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).

Potongan kode berikut menunjukkan cara menginterupsi tugas yang sedang berjalan:

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
    Run(action, tokenSource.Token); // jalankan aksi dalam thread terpisah
    Thread.Sleep(10000);            // batas waktu
    tokenSource.Interrupt();        // hentikan konversi
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **CancellationToken .NET dan Perpustakaan yang Dapat Diinterupsi**

Ketika Anda perlu menggunakan [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) bersama dengan perpustakaan Interupsi Aspose.Slides, bungkus pemrosesan [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) dan interupsi [InterruptionToken](https://reference.aspose.com/slides/id/net/aspose.slides/interruptiontoken/) ketika [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) bernilai `true`.

Kode C# berikut menunjukkan operasinya:

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
    Task task = Run(action, tokenSource.Token); // jalankan aksi dalam thread terpisah

    while (!task.Wait(500)) // tunggu dan pantau apakah cancellationToken.IsCancellationRequested telah diatur
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // hentikan pemrosesan Presentation
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

**Apa tujuan perpustakaan interupsi Aspose.Slides?**

Ia menyediakan mekanisme untuk menginterupsi operasi yang memakan waktu lama—seperti memuat, menyimpan, atau merender presentasi—sebelum selesai. Hal ini berguna ketika waktu pemrosesan harus dibatasi atau tugas tidak lagi diperlukan.

**Apa perbedaan antara [InterruptionToken](https://reference.aspose.com/slides/id/net/aspose.slides/interruptiontoken/) dan [InterruptionTokenSource](https://reference.aspose.com/slides/id/net/aspose.slides/iinterruptiontokensource/)?**

- `InterruptionToken` diteruskan ke API Aspose.Slides dan diperiksa selama operasi yang memakan waktu lama.
- `InterruptionTokenSource` digunakan dalam kode Anda untuk membuat token dan memicu interupsi dengan memanggil `Interrupt()`.

**Bisakah saya menggunakan .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) dengan perpustakaan interupsi?**

Ya. Anda dapat memantau [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) dalam logika aplikasi Anda dan memanggil [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/id/net/aspose.slides/iinterruptiontokensource/interrupt/) ketika pembatalan diminta. Ini memungkinkan Aspose.Slides untuk berintegrasi dengan alur kerja pembatalan standar .NET.

**Tugas apa yang dapat diinterupsi?**

Setiap tugas Aspose.Slides yang menerima [InterruptionToken](https://reference.aspose.com/slides/id/net/aspose.slides/interruptiontoken/)—seperti memuat presentasi dengan `Presentation(path, loadOptions)` atau menyimpan dengan `Presentation.Save(...)`—dapat diinterupsi.

**Apakah interupsi terjadi segera?**

Tidak. Interupsi bersifat kooperatif: operasi secara berkala memeriksa token dan berhenti segera setelah mendeteksi bahwa [Interrupt()](https://reference.aspose.com/slides/id/net/aspose.slides/iinterruptiontokensource/interrupt/) telah dipanggil.

**Apa yang terjadi jika saya memanggil [Interrupt()](https://reference.aspose.com/slides/id/net/aspose.slides/iinterruptiontokensource/interrupt/) setelah tugas selesai?**

Tidak ada apa‑apa—pemanggilan tidak berpengaruh jika tugas yang bersangkutan sudah selesai.

**Bisakah saya menggunakan kembali [InterruptionTokenSource](https://reference.aspose.com/slides/id/net/aspose.slides/iinterruptiontokensource/) yang sama untuk beberapa tugas?**

Ya—tetapi setelah Anda memanggil [Interrupt()](https://reference.aspose.com/slides/id/net/aspose.slides/iinterruptiontokensource/interrupt/) pada sumber tersebut, semua tugas yang menggunakan tokennya akan diinterupsi. Gunakan sumber token terpisah untuk mengelola tugas secara independen.