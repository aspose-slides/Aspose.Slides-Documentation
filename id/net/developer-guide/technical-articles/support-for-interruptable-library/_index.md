---
title: Menginterupsi Operasi Presentasi yang Berjalan Lama di .NET
linktitle: Interupsi Operasi Presentasi
type: docs
weight: 150
url: /id/net/support-for-interruptable-library/
keywords:
- operasi yang dapat diinterupsi
- token interupsi
- token pembatalan
- tugas yang berjalan lama
- interupsi tugas
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara membatalkan operasi presentasi yang berjalan lama di Aspose.Slides untuk .NET dan mengembalikan hasil parsial saat mengekspor slide dalam sebuah loop."
---
## **Gambaran Umum**

Aspose.Slides for .NET dapat menghentikan operasi yang berjalan lama seperti memuat, menyimpan, dan merender presentasi. Aplikasi Anda dapat menggunakan token interupsi yang sama untuk menghentikan sebuah loop sebelum memulai pemrosesan slide berikutnya.

## **Menginterupsi Operasi Presentasi**

Buat sebuah [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/), tetapkan [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) ke [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/), dan berikan opsi pemuatan ke [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Untuk meminta pembatalan, panggil [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) pada sumber tersebut. Operasi yang dapat diinterupsi akan berhenti ketika mendeteksi permintaan.

Contoh ini memulai konversi `sample.pptx` menjadi `sample.ppt` dalam tugas latar belakang dan meminta pembatalan setelah 10 detik. Jika konversi selesai lebih cepat, output sudah lengkap.

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
    Run(action, tokenSource.Token); // jalankan aksi pada thread terpisah
    Thread.Sleep(10000);            // batas waktu
    tokenSource.Interrupt();        // hentikan konversi
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **Hubungkan Pembatalan .NET ke Aspose.Slides**

Jika aplikasi Anda menggunakan .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken), teruskan permintaan pembatalannya ke Aspose.Slides. Contoh ini memulai mengekspor `sample.pptx` ke `sample.pdf` dan menetapkan batas waktu 20 detik. Selama proses ekspor berjalan, ia memeriksa [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) setiap 500 milidetik. Ketika properti menjadi `true`, ia memanggil [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/).

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
    Task task = Run(action, tokenSource.Token); // jalankan aksi pada thread terpisah

    while (!task.Wait(500)) // menunggu dan memantau apakah cancellationToken.IsCancellationRequested sudah diatur
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // menginterupsi pemrosesan Presentation
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

## **Berhenti Sebelum Memproses Slide Berikutnya**

Gunakan [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/) yang sama untuk presentasi dan loop yang mengekspor slide-nya. Periksa [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/) sebelum memulai setiap ekspor. Jika pemanggil dapat menggunakan hasil parsial, kembalikan nomor slide untuk ekspor yang selesai berhasil.

Gunakan presentasi bernama `sample.pptx` dengan minimal dua slide. Contoh ini meminta pembatalan segera setelah mencatat ekspor pertama yang berhasil.

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

Contoh ini menulis `slide-1.pdf` dan mencetak `Starting slide 1` diikuti dengan `Completed: [1]`. Loop melihat permintaan sebelum memulai slide 2. Jika pembatalan malah menginterupsi [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) selama ekspor, blok `catch` keluar dari loop sebelum kode mencatat slide saat ini sebagai selesai.

Jika pemanggil perlu menangani pembatalan, gantikan pemeriksaan `if` dan `break` di bagian atas loop dengan panggilan ke [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) pada token. Hapus `try`/`catch` di sekitar ekspor sehingga pembatalan selama penyimpanan juga mencapai pemanggil. Dengan input yang sama, contoh ini hanya mencetak `Starting slide 1` dan menulis `slide-1.pdf`. Pada awal iterasi kedua, pemanggil menerima [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception) sebelum ekspor dimulai. Metode tidak mengembalikan daftar.

## **FAQ**

**Kapan saya harus meminta pembatalan?**

Minta pembatalan ketika suatu operasi melebihi batas waktu Anda atau ketika aplikasi Anda tidak lagi memerlukan hasilnya.

**Apa perbedaan antara [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) dan [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

Sumber memungkinkan aplikasi Anda meminta pembatalan. Token memungkinkan Aspose.Slides dan aplikasi Anda memeriksa permintaan tersebut.

**Apakah saya dapat menggunakan .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) dengan Aspose.Slides?**

Ya. Ketika token .NET Anda memberi sinyal pembatalan, panggil [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) pada sumber yang terkait dengan presentasi.

**Operasi apa yang dapat saya interupsi?**

Anda dapat menginterupsi pemuatan, penyimpanan, dan perenderan. Berikan token ke [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) melalui [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/). Presentasi kemudian dapat mendeteksi pembatalan selama operasi selanjutnya seperti [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/).

**Apakah operasi berhenti segera?**

Pembatalan bersifat kooperatif. Sebuah operasi memeriksa token secara berkala dan berhenti ketika mendeteksi permintaan.

**Apa yang terjadi jika saya memanggil [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) setelah operasi selesai?**

Operasi yang selesai tetap mempertahankan hasilnya.

**Dapatkah beberapa operasi berbagi [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

Ya. Memanggil [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) meminta pembatalan untuk setiap operasi yang menggunakan token dari sumber tersebut. Gunakan sumber terpisah untuk setiap operasi yang ingin Anda batalkan secara independen.