---
title: Terapkan Animasi Bentuk dalam Presentasi di .NET
linktitle: Animasi Bentuk
type: docs
weight: 60
url: /id/net/shape-animation/
keywords:
- bentuk
- animasi
- efek
- bentuk animasi
- teks animasi
- tambahkan animasi
- dapatkan animasi
- ekstrak animasi
- tambahkan efek
- dapatkan efek
- ekstrak efek
- suara efek
- terapkan animasi
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara menambahkan, memeriksa, dan menyesuaikan animasi bentuk, waktu, suara, perilaku setelah animasi, serta teks animasi dengan Aspose.Slides untuk .NET."
---
## **Gambaran Umum**

Aspose.Slides untuk .NET merepresentasikan animasi slide sebagai efek dalam timeline slide. Sebuah efek memiliki bentuk target, jenis dan subtipe animasi, pemicu, pengaturan waktu, dan properti opsional seperti suara atau perilaku setelah animasi.

Timeline berisi dua jenis urutan:

- **Urutan utama** diputar saat slide maju.
- **Urutan interaktif** dimulai ketika bentuk pemicunya diklik.

Karena kotak teks, gambar, diagram, tabel, dan objek slide lainnya mengimplementasikan [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/), Anda menggunakan metode [ISequence.AddEffect](https://reference.aspose.com/slides/id/net/aspose.slides.animation/isequence/addeffect/) yang sama untuk sebagian besar konten slide. Efek yang tersedia tercantum dalam enumerasi [EffectType](https://reference.aspose.com/slides/id/net/aspose.slides.animation/effecttype/).

## **Menambahkan Animasi Bentuk**

Untuk menambahkan animasi, dapatkan urutan utama slide dan panggil [ISequence.AddEffect](https://reference.aspose.com/slides/id/net/aspose.slides.animation/isequence/addeffect/) dengan bentuk target, jenis efek, subtipe, dan pemicu. Untuk efek yang dimulai ketika bentuk lain diklik, buat urutan interaktif yang pemicunya adalah bentuk lain tersebut.

Contoh berikut membuat kedua jenis animasi dan menyimpan hasilnya ke `shape-animations.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var targetShape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Click to animate this shape";

var mainSequence = slide.Timeline.MainSequence;
var entranceEffect = mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
entranceEffect.Timing.Duration = 1.5f;

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

presentation.Save("shape-animations.pptx", SaveFormat.Pptx);
```

Pemicu mengontrol kapan suatu efek dimulai:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/id/net/aspose.slides.animation/effecttriggertype/) menunggu klik pada urutan utama, atau klik pada bentuk pemicu pada urutan interaktif.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/id/net/aspose.slides.animation/effecttriggertype/) dimulai bersamaan dengan efek sebelumnya.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/id/net/aspose.slides.animation/effecttriggertype/) dimulai ketika efek sebelumnya selesai.

Untuk menganimasikan gambar, diagram, atau jenis bentuk lainnya, berikan objek tersebut ke [ISequence.AddEffect](https://reference.aspose.com/slides/id/net/aspose.slides.animation/isequence/addeffect/) alih-alih `targetShape`. Untuk opsi pengelompokan khusus diagram, lihat [Diagram Animasi](/slides/id/net/animated-charts/).

## **Membaca Animasi Bentuk**

Gunakan [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/id/net/aspose.slides.animation/isequence/geteffectsbyshape/) ketika Anda mengetahui bentuk target. Untuk memeriksa setiap efek, enumerasikan urutan utama dan setiap urutan interaktif. Enumerasi menghindari asumsi bahwa suatu urutan berisi efek pada indeks `0`.

Contoh berikut membuat sebuah bentuk dengan efek urutan utama dan interaktif, mengambil efek yang menargetkan bentuk tersebut, dan kemudian mengenumerasikan setiap urutan pada slide.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Animated shape";

var mainSequence = slide.Timeline.MainSequence;
mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

var targetEffects = mainSequence.GetEffectsByShape(targetShape);
Console.WriteLine($"The main sequence contains {targetEffects.Length} effect(s) for {targetShape.Name}.");

PrintSequence("Main sequence", mainSequence);

var interactiveIndex = 1;
foreach (var sequence in slide.Timeline.InteractiveSequences)
{
    var triggerName = sequence.TriggerShape == null ? "unknown" : sequence.TriggerShape.Name;
    var sequenceLabel = $"Interactive sequence {interactiveIndex}, trigger: {triggerName}";
    PrintSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

static void PrintSequence(string label, ISequence sequence)
{
    Console.WriteLine($"  {label}: {sequence.Count} effect(s)");

    foreach (var effect in sequence)
    {
        var targetName = effect.TargetShape == null ? "unknown" : effect.TargetShape.Name;
        var effectDescription = $"{effect.Type} {effect.Subtype}; target: {targetName}; trigger: {effect.Timing.TriggerType}";
        Console.WriteLine($"    {effectDescription}");
    }
}
```

Jika Anda hanya membutuhkan efek untuk satu bentuk, pertama identifikasi bentuk tersebut berdasarkan nama, tipe placeholder, atau properti stabil lainnya; kemudian panggil [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/id/net/aspose.slides.animation/isequence/geteffectsbyshape/). Jangan mengasumsikan bahwa [IShapeCollection.Item](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/item/) pada indeks `0` selalu merupakan objek yang dimaksud.

## **Bekerja dengan Efek Placeholder yang Diwariskan**

Placeholder pada slide biasa dapat mewarisi perilaku animasi dari placeholder yang sesuai pada slide tata letak dan slide master. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/getbaseplaceholder/) mengembalikan placeholder induk tersebut, atau `null` bila tidak ada induk.

Pada contoh presentasi berikut, footer memiliki **Random Bars** pada slide biasa, **Split** pada slide tata letak, dan **Fly In** pada slide master.

![Efek animasi footer pada slide biasa](slide-shape-animation.png)
![Efek animasi placeholder footer pada slide tata letak](layout-shape-animation.png)
![Efek animasi placeholder footer pada slide master](master-shape-animation.png)

Contoh berikutnya membangun hierarki placeholder itu sendiri. Ia menambahkan efek ke placeholder master, placeholder tata letak, dan placeholder yang sesuai pada slide biasa. Setiap pemanggilan [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/id/net/aspose.slides.ishape/getbaseplaceholder/) diperiksa sebelum bentuk yang dikembalikan digunakan.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
var layoutPlaceholder = layoutSlide.PlaceholderManager.AddTextPlaceholder(100, 100, 400, 80);
layoutSlide.Timeline.MainSequence.AddEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
if (masterPlaceholder != null)
{
    var masterSequence = layoutSlide.MasterSlide.Timeline.MainSequence;
    masterSequence.AddEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}

var slide = presentation.Slides.AddEmptySlide(layoutSlide);
var slidePlaceholder = FindPlaceholderWithBase(slide);

if (slidePlaceholder == null)
{
    throw new InvalidOperationException("The slide does not contain a placeholder linked to its layout slide.");
}

slide.Timeline.MainSequence.AddEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
PrintEffects("Normal slide", slide.Timeline.MainSequence.GetEffectsByShape(slidePlaceholder));

var baseLayoutPlaceholder = slidePlaceholder.GetBasePlaceholder();
if (baseLayoutPlaceholder != null)
{
    PrintEffects("Layout slide", layoutSlide.Timeline.MainSequence.GetEffectsByShape(baseLayoutPlaceholder));

    var baseMasterPlaceholder = baseLayoutPlaceholder.GetBasePlaceholder();
    if (baseMasterPlaceholder != null)
    {
        PrintEffects("Master slide", layoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(baseMasterPlaceholder));
    }
}

presentation.Save("placeholder-animations.pptx", SaveFormat.Pptx);

static IShape FindPlaceholderWithBase(ISlide slide)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape.GetBasePlaceholder() != null)
        {
            return shape;
        }
    }

    return null;
}

static void PrintEffects(string source, IEffect[] effects)
{
    Console.WriteLine($"{source}: {effects.Length} effect(s)");

    foreach (var effect in effects)
    {
        Console.WriteLine($"  {effect.Type} {effect.Subtype}");
    }
}
```

## **Mengubah Timing Animasi**

Dialog **Timing** PowerPoint dipetakan ke properti [ITiming](https://reference.aspose.com/slides/id/net/aspose.slides.animation/itiming/).

![Dialog Timing PowerPoint untuk efek animasi](shape-animation.png)

- **Start** dipetakan ke [ITiming.TriggerType](https://reference.aspose.com/slides/id/net/aspose.slides.animation/itiming/triggertype/).
- **Duration** dipetakan ke [ITiming.Duration](https://reference.aspose.com/slides/id/net/aspose.slides.animation/itiming/duration/), dalam detik.
- **Delay** dipetakan ke [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/id/net/aspose.slides.animation/itiming/triggerdelaytime/), dalam detik.
- **Repeat** dipetakan ke [ITiming.RepeatCount](https://reference.aspose.com/slides/id/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/id/net/aspose.slides.animation/itiming/repeatuntilnextclick/), atau [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/id/net/aspose.slides.animation/itiming/repeatuntilendslide/).
- **Rewind when done playing** dipetakan ke [ITiming.Rewind](https://reference.aspose.com/slides/id/net/aspose.slides.animation/itiming/rewind/).

Contoh independen ini menambahkan sebuah efek, mengubah timing-nya melalui objek yang dikembalikan oleh [ISequence.AddEffect](https://reference.aspose.com/slides/id/net/aspose.slides.animation/isequence/addeffect/), dan menyimpan hasilnya. Menjaga referensi [IEffect](https://reference.aspose.com/slides/id/net/aspose.slides.animation/ieffect/) yang dikembalikan menghindari indeks koleksi yang tidak diperlukan.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Timed animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Timing.TriggerType = EffectTriggerType.OnClick;
effect.Timing.Duration = 2.0f;
effect.Timing.TriggerDelayTime = 0.5f;
effect.Timing.RepeatUntilNextClick = false;
effect.Timing.RepeatUntilEndSlide = false;
effect.Timing.RepeatCount = 2.0f;
effect.Timing.Rewind = true;

presentation.Save("shape-animation-timing.pptx", SaveFormat.Pptx);
```

Gunakan satu mode pengulangan secara sengaja. Menggabungkan jumlah pengulangan dengan flag "until" dapat menghasilkan hasil yang membingungkan pada penampil yang berbeda. Saat mengubah mode pengulangan, atur [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/id/net/aspose.slides.animation/itiming/repeatuntilnextclick/) dan [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/id/net/aspose.slides.animation/itiming/repeatuntilendslide/) sebelum [ITiming.RepeatCount](https://reference.aspose.com/slides/id/net/aspose.slides.animation/itiming/repeatcount/), karena mengatur salah satu flag juga mengubah mode pengulangan yang aktif.

## **Menambahkan dan Mengekstrak Suara Animasi**

Sebuah efek animasi dapat merujuk audio tersemat melalui [IEffect.Sound](https://reference.aspose.com/slides/id/net/aspose.slides.animation/ieffect/sound/). [IEffect.StopPreviousSound](https://reference.aspose.com/slides/id/net/aspose.slides.animation/ieffect/stopprevioussound/) memberi tahu sebuah efek untuk menghentikan audio yang dimulai oleh efek sebelumnya.

### **Menambahkan Suara ke Efek**

Contoh berikut mengharapkan file audio lokal bernama `animation-sound.wav`. Ia membuat dua efek, menyematkan file tersebut sebagai suara untuk efek pertama, dan mengonfigurasi efek kedua untuk menghentikan suara. Ia menggunakan objek yang dikembalikan oleh [ISequence.AddEffect](https://reference.aspose.com/slides/id/net/aspose.slides.animation/isequence/addeffect/), jadi tidak diperlukan indeks urutan.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
firstShape.TextFrame.Text = "Starts sound";
secondShape.TextFrame.Text = "Stops sound";

var sequence = slide.Timeline.MainSequence;
var firstEffect = sequence.AddEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
var secondEffect = sequence.AddEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var audioData = File.ReadAllBytes("animation-sound.wav");
var effectSound = presentation.Audios.AddAudio(audioData);
firstEffect.Sound = effectSound;
secondEffect.StopPreviousSound = true;

presentation.Save("shape-animation-sound.pptx", SaveFormat.Pptx);
```

### **Mengekstrak Suara Efek Tersemat**

Contoh berikut mengharapkan presentasi lokal bernama `presentation-with-animation-sounds.pptx`. Ia memindai kedua urutan utama dan interaktif serta menulis setiap suara efek tersemat ke direktori `extracted-animation-sounds`. Ekstensi dipilih dari tipe MIME audio yang ditampilkan oleh [IAudio.ContentType](https://reference.aspose.com/slides/id/net/aspose.slides/iaudio/contenttype/).

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;

var inputPath = "presentation-with-animation-sounds.pptx";
var outputDirectory = "extracted-animation-sounds";

Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation(inputPath);
var soundIndex = 1;

foreach (var slide in presentation.Slides)
{
    SaveSounds(slide.Timeline.MainSequence, outputDirectory, ref soundIndex);

    foreach (var sequence in slide.Timeline.InteractiveSequences)
    {
        SaveSounds(sequence, outputDirectory, ref soundIndex);
    }
}

Console.WriteLine($"Extracted {soundIndex - 1} sound file(s) to {Path.GetFullPath(outputDirectory)}.");

static void SaveSounds(ISequence sequence, string outputDirectory, ref int soundIndex)
{
    foreach (var effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        var extension = GetAudioExtension(effect.Sound.ContentType);
        var outputPath = Path.Combine(outputDirectory, $"effect-sound-{soundIndex}{extension}");
        File.WriteAllBytes(outputPath, effect.Sound.BinaryData);
        soundIndex++;
    }
}

static string GetAudioExtension(string contentType)
{
    var normalizedType = contentType == null ? string.Empty : contentType.ToLowerInvariant();

    if (normalizedType == "audio/mpeg")
        return ".mp3";

    if (normalizedType == "audio/mp4")
        return ".m4a";

    if (normalizedType == "audio/ogg")
        return ".ogg";

    if (normalizedType == "audio/wav" || normalizedType == "audio/x-wav")
        return ".wav";

    return ".bin";
}
```

Untuk objek audio besar, gunakan [IAudio.GetStream](https://reference.aspose.com/slides/id/net/aspose.slides/iaudio/getstream/) dan salin aliran ke file alih-alih memuat seluruh objek ke dalam array byte.

## **Mengatur Perilaku Setelah Animasi**

Opsi **After animation** mengontrol apa yang terjadi pada sebuah bentuk setelah efeknya selesai.

![Dialog Opsi Efek PowerPoint menampilkan pengaturan After animation](shape-after-animation.png)

Enumerasi [AfterAnimationType](https://reference.aspose.com/slides/id/net/aspose.slides.animation/afteranimationtype/) mendukung membiarkan bentuk tidak berubah, mengubah warnanya, menyembunyikannya setelah animasi, atau menyembunyikannya pada klik berikutnya. Ketika tipe adalah [AfterAnimationType.Color](https://reference.aspose.com/slides/id/net/aspose.slides.animation/afteranimationtype/), atur juga [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/id/net/aspose.slides.animation/ieffect/afteranimationcolor/).

Contoh independen ini membuat sebuah efek, mengatur perilaku after-animation melalui objek efek yang dikembalikan, dan menyimpan hasilnya.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Dim after animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.AfterAnimationType = AfterAnimationType.Color;
effect.AfterAnimationColor.Color = Color.LightGray;

presentation.Save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
```

Mengubah tipe dari [AfterAnimationType.Color](https://reference.aspose.com/slides/id/net/aspose.slides.animation/afteranimationtype/) menghapus pengaturan warna after-animation.

## **Menganimasikan Teks**

Animasi teks memiliki dua kontrol terkait:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/id/net/aspose.slides.animation/itextanimation/buildtype/) mengontrol apakah paragraf muncul bersama-sama atau per level paragraf.
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/id/net/aspose.slides.animation/ieffect/animatetexttype/) mengontrol apakah teks muncul sekaligus, per kata, atau per huruf. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/id/net/aspose.slides.animation/ieffect/delaybetweentextparts/) mengatur jeda antara kata atau huruf. Nilai positif adalah persentase dari durasi efek; nilai negatif adalah jeda dalam detik.

Contoh independen berikut menganimasikan kata-kata dalam kotak teks. [BuildType.AsOneObject](https://reference.aspose.com/slides/id/net/aspose.slides.animation/buildtype/) menonaktifkan pembangunan per paragraf sehingga pengaturan kata berlaku untuk seluruh bingkai teks.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
textBox.TextFrame.Text = "Aspose.Slides animates this sentence word by word.";

var effect = slide.Timeline.MainSequence.AddEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.TextAnimation.BuildType = BuildType.AsOneObject;
effect.AnimateTextType = AnimateTextType.ByWord;
effect.DelayBetweenTextParts = 20.0f;

presentation.Save("animated-text.pptx", SaveFormat.Pptx);
```

Untuk membangun kotak teks per paragraf, atur [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/id/net/aspose.slides.animation/buildtype/) (atau level paragraf lainnya). Untuk menargetkan satu paragraf dengan efeknya sendiri, gunakan overload [ISequence.AddEffect](https://reference.aspose.com/slides/id/net/aspose.slides.animation/isequence/addeffect/) yang menerima sebuah [IParagraph](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/). Lihat [Animated Text](/slides/id/net/animated-text/) untuk contoh tingkat paragraf.

## **Catatan Ekspor dan Kompatibilitas**

- Menyimpan ke PPT atau PPTX mempertahankan model animasi, namun pemutaran akhir dikendalikan oleh penampil presentasi.
- PDF dan gambar statis tidak memutar animasi. Gunakan [HTML5 export](/slides/id/net/export-to-html5/), GIF animasi, atau [video conversion](/slides/id/net/convert-powerpoint-to-video/) ketika output harus menunjukkan gerakan.
- Untuk HTML5, aktifkan [Html5Options.AnimateShapes](https://reference.aspose.com/slides/id/net/aspose.slides.export/html5options/animateshapes/) dan, bila diperlukan, [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/id/net/aspose.slides.export/html5options/animatetransitions/).
- Rendering video mendukung banyak efek masuk, penekanan, keluar, dan jalur-gerakan yang umum, tetapi tidak semua efek PowerPoint didukung. Periksa [supported animations and effects](/slides/id/net/convert-powerpoint-to-video/#supported-animations-and-effects) saat ini dan uji presentasi kritis dengan versi Aspose.Slides target Anda.
- Efek khusus lanjutan dan efek yang diimpor dari format presentasi lain mungkin dipertahankan dalam file tetapi dirender secara berbeda di PowerPoint, HTML5, atau video. Validasi hasil ekspor daripada hanya mengandalkan nama efek.

## **FAQ**

**Mengapa animasi muncul di PowerPoint tetapi tidak di PDF?**

PDF adalah format statis, sehingga animasi dan transisi slide tidak diputar. Ekspor ke HTML5, GIF animasi, atau video ketika gerakan harus dipertahankan.

**Mengapa sebuah efek diputar berbeda dalam video?**

Ekspor video merender animasi daripada menyimpan perilaku PowerPoint asli. Beberapa efek lanjutan tidak didukung atau hanya diperkirakan. Tinjau tabel efek yang didukung dan uji presentasi sebenarnya sebelum penggunaan produksi.

**Apakah memindahkan sebuah bentuk ke depan atau ke belakang mengubah urutan animasinya?**

Tidak. Z-order bentuk mengontrol tumpang tindih, sementara urutan urutan dan pemicu mengontrol pemutaran animasi. Ubah timeline jika Anda memerlukan urutan pemutaran yang berbeda.