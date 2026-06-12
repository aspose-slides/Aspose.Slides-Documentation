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
description: "Temukan cara membuat dan menyesuaikan animasi bentuk dalam presentasi PowerPoint dengan Aspose.Slides untuk .NET. Tampil menonjol!"
---
## **Pendahuluan**

Animasi adalah efek visual yang dapat diterapkan pada teks, gambar, bentuk, atau [bagan](/slides/id/net/animated-charts/). Mereka memberikan kehidupan pada presentasi atau komponennya. 

## **Mengapa Menggunakan Animasi dalam Presentasi?**

* mengontrol alur informasi
* menekankan poin penting
* meningkatkan minat atau partisipasi audiens Anda
* mempermudah konten untuk dibaca, dipahami, atau diproses
* menarik perhatian pembaca atau penonton ke bagian penting dalam presentasi

PowerPoint menyediakan banyak pilihan dan alat untuk animasi serta efek animasi di kategori **entrance**, **exit**, **emphasis**, dan **motion paths**. 

## **Animasi di Aspose.Slides**

* Aspose.Slides menyediakan kelas dan tipe yang Anda perlukan untuk bekerja dengan animasi di bawah namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/id/net/aspose.slides.animation/), 
* Aspose.Slides menyediakan lebih dari **150 efek animasi** di dalam enumerasi [EffectType](https://reference.aspose.com/slides/id/net/aspose.slides.animation/effecttype). Efek-efek ini pada dasarnya sama (atau setara) dengan efek yang digunakan di PowerPoint.

## **Terapkan Animasi pada TextBox**

Aspose.Slides untuk .NET memungkinkan Anda menerapkan animasi pada teks dalam sebuah bentuk. 

1. Buat instance dari kelas [Presentation](http://www.aspose.com/api/net/slides/id/aspose.slides/) .
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan `rectangle` [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape). 
4. Tambahkan teks ke [IAutoShape.TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/properties/textframe).
5. Dapatkan urutan utama efek.
6. Tambahkan efek animasi ke [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape).
7. Setel properti [TextAnimation.BuildType](https://reference.aspose.com/slides/id/net/aspose.slides.animation/textanimation/properties/buildtype) ke nilai dari [BuildType Enumeration](https://reference.aspose.com/slides/id/net/aspose.slides.animation/buildtype).
8. Tuliskan presentasi ke disk sebagai file PPTX.

Kode C# ini menunjukkan cara menerapkan efek `Fade` pada AutoShape dan mengatur animasi teks ke nilai *By 1st Level Paragraphs*:

```c#
// Membuat instance kelas presentasi yang mewakili file presentasi.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // Menambahkan AutoShape baru dengan teks
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // Mendapatkan urutan utama slide.
    ISequence sequence = sld.Timeline.MainSequence;

    // Menambahkan efek animasi Fade ke shape
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Menganimasikan teks shape berdasarkan paragraf tingkat pertama
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Menyimpan file PPTX ke disk
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="primary"  %}} 

Selain menerapkan animasi pada teks, Anda juga dapat menerapkan animasi pada sebuah [Paragraph](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph). Lihat [**Animated Text**](/slides/id/net/animated-text/).

{{% /alert %}} 

## **Terapkan Animasi pada PictureFrame**

1. Buat instance dari kelas [Presentation](http://www.aspose.com/api/net/slides/id/aspose.slides/) .
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan atau dapatkan [PictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ipictureframe) pada slide. 
5. Dapatkan urutan utama efek.
6. Tambahkan efek animasi ke [PictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ipictureframe).
8. Tuliskan presentasi ke disk sebagai file PPTX.

```c#
// Membuat instance kelas presentasi yang mewakili file presentasi.
using (Presentation pres = new Presentation())
{
    // Muat gambar yang akan ditambahkan ke koleksi gambar presentasi
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Menambahkan frame gambar ke slide
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Mendapatkan urutan utama slide.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Menambahkan efek animasi Fly dari Kiri ke frame gambar
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Menyimpan file PPTX ke disk
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Terapkan Animasi pada Shape**

1. Buat instance dari kelas [Presentation](http://www.aspose.com/api/net/slides/id/aspose.slides/) .
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan `rectangle` [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape). 
4. Tambahkan `Bevel` [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape) (ketika objek ini diklik, animasi akan diputar).
5. Buat urutan efek pada bentuk bevel.
6. Buat `UserPath` khusus.
7. Tambahkan perintah untuk bergerak ke `UserPath`.
8. Tuliskan presentasi ke disk sebagai file PPTX.

```c#
// Membuat instance kelas Presentation yang mewakili file presentasi.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Membuat efek PathFootball untuk shape yang ada dari nol.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Menambahkan efek animasi PathFootBall.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Membuat semacam "tombol".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Membuat urutan efek untuk tombol.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Membuat jalur pengguna khusus. Objek kami akan dipindahkan hanya setelah tombol diklik.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Menambahkan perintah untuk bergerak karena jalur yang dibuat kosong.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Menulis file PPTX ke disk
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Dapatkan Efek Animasi yang Diterapkan pada Shape**

Contoh berikut menunjukkan cara menggunakan metode `GetEffectsByShape` dari antarmuka [ISequence](https://reference.aspose.com/slides/id/net/aspose.slides.animation/isequence/) untuk mendapatkan semua efek animasi yang diterapkan pada sebuah shape.

**Contoh 1: Dapatkan efek animasi yang diterapkan pada shape di slide normal**

Seb sebelumnya, Anda telah mempelajari cara menambahkan efek animasi pada shape dalam presentasi PowerPoint. Kode contoh berikut menunjukkan cara mendapatkan efek yang diterapkan pada shape pertama pada slide normal pertama dalam presentasi `AnimExample_out.pptx`.

```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Mendapatkan urutan animasi utama slide.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Mendapatkan shape pertama pada slide pertama.
    IShape shape = firstSlide.Shapes[0];

    // Mendapatkan efek animasi yang diterapkan pada shape.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**Contoh 2: Dapatkan semua efek animasi, termasuk yang diwarisi dari placeholder**

Jika sebuah shape pada slide normal memiliki placeholder yang berada pada slide tata letak dan/atau slide master, dan efek animasi telah ditambahkan ke placeholder tersebut, maka semua efek pada shape akan dimainkan selama pertunjukan slide, termasuk yang diwarisi dari placeholder.

Misalkan kita memiliki file presentasi PowerPoint `sample.pptx` dengan satu slide yang hanya berisi shape footer dengan teks "Made with Aspose.Slides" dan efek **Random Bars** diterapkan pada shape tersebut.

![Efek animasi shape slide](slide-shape-animation.png)

Andaikan juga efek **Split** diterapkan pada placeholder footer pada slide **layout**.

![Efek animasi shape layout](layout-shape-animation.png)

Dan akhirnya, efek **Fly In** diterapkan pada placeholder footer pada slide **master**.

![Efek animasi shape master](master-shape-animation.png)

Kode contoh berikut menunjukkan cara menggunakan metode `GetBasePlaceholder` dari antarmuka [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/) untuk mengakses placeholder shape dan mendapatkan efek animasi yang diterapkan pada shape footer, termasuk yang diwarisi dari placeholder yang terletak pada slide tata letak dan master.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Dapatkan efek animasi shape pada slide normal.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Dapatkan efek animasi placeholder pada slide tata letak.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Dapatkan efek animasi placeholder pada slide master.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}
```
```cs
static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```

```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Ubah Properti Timing Efek Animasi**

Aspose.Slides untuk .NET memungkinkan Anda mengubah properti Timing dari sebuah efek animasi.

![Panel Timing Animasi](shape-animation.png)

Ini adalah korespondensi antara PowerPoint Timing dan properti [Effect.Timing](https://reference.aspose.com/slides/id/net/aspose.slides.animation/effect/properties/timing):
- Daftar drop-down PowerPoint Timing **Start** cocok dengan properti [Effect.Timing.TriggerType](https://reference.aspose.com/slides/id/net/aspose.slides.animation/itiming/properties/triggertype). 
- PowerPoint Timing **Duration** cocok dengan properti [Effect.Timing.Duration](https://reference.aspose.com/slides/id/net/aspose.slides.animation/itiming/properties/duration). Durasi animasi (dalam detik) adalah total waktu yang dibutuhkan animasi untuk menyelesaikan satu siklus. 
- PowerPoint Timing **Delay** cocok dengan properti [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/id/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- Daftar drop-down PowerPoint Timing **Repeat** cocok dengan properti:
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/id/net/aspose.slides.animation/itiming/repeatcount) yang menggambarkan *jumlah* pengulangan efek;
  * flag [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/id/net/aspose.slides.animation/itiming/repeatuntilendslide) yang menentukan apakah efek diulang hingga akhir slide;
  * flag [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/id/net/aspose.slides.animation/itiming/repeatuntilnextclick) yang menentukan apakah efek diulang hingga klik berikutnya.
- Kotak centang PowerPoint Timing **Rewind when done playing** cocok dengan properti [Effect.Timing.Rewind](https://reference.aspose.com/slides/id/net/aspose.slides.animation/itiming/rewind/). 

Berikut cara mengubah properti Timing Efek:

1. [Terapkan](#apply-animation-to-shape) atau dapatkan efek animasi.
2. Setel nilai baru untuk properti [Effect.Timing](https://reference.aspose.com/slides/id/net/aspose.slides.animation/effect/properties/timing) yang Anda butuhkan. 
3. Simpan file PPTX yang telah dimodifikasi.

```c#
// Membuat instance kelas presentasi yang mewakili file presentasi.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Mendapatkan urutan utama slide.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Mendapatkan efek pertama dari urutan utama.
    IEffect effect = sequence[0];

    // Mengubah TriggerType efek menjadi mulai saat klik
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Mengubah Durasi efek
    effect.Timing.Duration = 3f;

    // Mengubah TriggerDelayTime efek
    effect.Timing.TriggerDelayTime = 0.5f;

    // Jika nilai Repeat efek adalah "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // Mengubah Repeat efek menjadi "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Mengubah Repeat efek menjadi "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Mengaktifkan Rewind efek
        effect.Timing.Rewind = true;
    
    // Menyimpan file PPTX ke disk
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Suara Efek Animasi**

Aspose.Slides menyediakan properti-properti ini untuk memungkinkan Anda bekerja dengan suara dalam efek animasi: 
- [IEffect.Sound](https://reference.aspose.com/slides/id/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/id/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Tambahkan Suara Efek Animasi**

Kode C# ini menunjukkan cara menambahkan suara efek animasi dan menghentikannya ketika efek berikutnya dimulai:

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Menambahkan audio ke koleksi audio presentasi
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Mendapatkan urutan utama slide.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Mendapatkan efek pertama dari urutan utama
	IEffect firstEffect = sequence[0];

	// Memeriksa efek untuk "No Sound"
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Menambahkan suara untuk efek pertama
		firstEffect.Sound = effectSound;
	}

	// Mendapatkan urutan interaktif pertama dari slide.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Mengatur flag "Stop previous sound" pada efek
	interactiveSequence[0].StopPreviousSound = true;

	// Menulis file PPTX ke disk
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Ekstrak Suara Efek Animasi**

1. Buat instance dari [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
2. Dapatkan referensi slide melalui indeksnya. 
3. Dapatkan urutan utama efek. 
4. Ekstrak [Sound](https://reference.aspose.com/slides/id/net/aspose.slides.animation/effect/sound/) yang tersemat pada setiap efek animasi. 

```c#
// Membuat instance kelas presentasi yang mewakili file presentasi.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Mendapatkan urutan utama slide.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Mengekstrak suara efek dalam array byte
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Setelah Animasi**

Aspose.Slides untuk .NET memungkinkan Anda mengubah properti After animation dari sebuah efek animasi.

![Panel After Animation](shape-after-animation.png)

Daftar drop-down PowerPoint Effect **After animation** cocok dengan properti berikut: 

- Properti [IEffect.AfterAnimationType](https://reference.aspose.com/slides/id/net/aspose.slides.animation/ieffect/afteranimationtype/) yang menggambarkan tipe After animation :
  * PowerPoint **More Colors** cocok dengan tipe [AfterAnimationType.Color](https://reference.aspose.com/slides/id/net/aspose.slides.animation/afteranimationtype/) ;
  * PowerPoint **Don't Dim** cocok dengan tipe [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/id/net/aspose.slides.animation/afteranimationtype/) (tipe after animation default);
  * PowerPoint **Hide After Animation** cocok dengan tipe [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/id/net/aspose.slides.animation/afteranimationtype/) ;
  * PowerPoint **Hide on Next Mouse Click** cocok dengan tipe [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/id/net/aspose.slides.animation/afteranimationtype/) ;
- Properti [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/id/net/aspose.slides.animation/ieffect/afteranimationcolor/) yang menentukan format warna after animation. Properti ini bekerja bersama tipe [AfterAnimationType.Color](https://reference.aspose.com/slides/id/net/aspose.slides.animation/afteranimationtype/). Jika Anda mengubah tipe ke yang lain, warna after animation akan dihapus.

Kode C# ini menunjukkan cara mengubah efek after animation:

```c#
// Membuat instance kelas presentasi yang mewakili file presentasi
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Mendapatkan efek pertama dari urutan utama
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Mengubah tipe after animation menjadi Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Mengatur warna after animation dim
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Menulis file PPTX ke disk
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Animasi Teks**

Aspose.Slides menyediakan properti-properti ini untuk memungkinkan Anda bekerja dengan blok *Animate text* pada efek animasi:
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/id/net/aspose.slides.animation/ieffect/animatetexttype/) yang menggambarkan tipe animate text pada efek. Teks shape dapat dianimasikan:
  - Semua sekaligus ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/id/net/aspose.slides.animation/animatetexttype/) tipe)
  - Per kata ([AnimateTextType.ByWord](https://reference.aspose.com/slides/id/net/aspose.slides.animation/animatetexttype/) tipe)
  - Per huruf ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/id/net/aspose.slides.animation/animatetexttype/) tipe)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/id/net/aspose.slides.animation/ieffect/delaybetweentextparts/) mengatur jeda antara bagian teks yang dianimasikan (kata atau huruf). Nilai positif menentukan persentase durasi efek. Nilai negatif menentukan jeda dalam detik.

Berikut cara Anda dapat mengubah properti Effect Animate text:

1. [Terapkan](#apply-animation-to-shape) atau dapatkan efek animasi.
2. Setel properti [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/id/net/aspose.slides.animation/itextanimation/buildtype/) ke nilai [BuildType.AsOneObject](https://reference.aspose.com/slides/id/net/aspose.slides.animation/buildtype/) untuk menonaktifkan mode animasi *By Paragraphs*.
3. Setel nilai baru untuk properti [IEffect.AnimateTextType](https://reference.aspose.com/slides/id/net/aspose.slides.animation/ieffect/animatetexttype/) dan [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/id/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Simpan file PPTX yang telah dimodifikasi.

```c#
// Membuat instance kelas presentasi yang mewakili file presentasi.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Mendapatkan efek pertama dari urutan utama
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Mengubah tipe animasi teks efek menjadi "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Mengubah tipe animasi teks efek menjadi "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Mengatur jeda antar kata menjadi 20% dari durasi efek
    firstEffect.DelayBetweenTextParts = 20f;

    // Menulis file PPTX ke disk
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Bagaimana saya dapat memastikan animasi tetap terjaga saat mempublikasikan presentasi ke web?**

[Export to HTML5](/slides/id/net/export-to-html5/) dan aktifkan [options](https://reference.aspose.com/slides/id/net/aspose.slides.export/html5options/) yang bertanggung jawab atas animasi [shape](https://reference.aspose.com/slides/id/net/aspose.slides.export/html5options/animateshapes/) dan [transition](https://reference.aspose.com/slides/id/net/aspose.slides.export/html5options/animatetransitions/). HTML biasa tidak memutar animasi slide, sedangkan HTML5 melakukannya.

**Bagaimana perubahan z-order (urutan lapisan) shape memengaruhi animasi?**

Animasi dan urutan gambar bersifat independen: sebuah efek mengontrol timing dan tipe muncul/hilang, sementara [z-order](https://reference.aspose.com/slides/id/net/aspose.slides/shape/zorderposition/) menentukan apa yang menutupi apa. Hasil visual ditentukan oleh kombinasi keduanya. (Ini adalah perilaku umum PowerPoint; model efek-dan-shape Aspose.Slides mengikuti logika yang sama.)

**Apakah ada batasan saat mengonversi animasi ke video untuk efek tertentu?**

Secara umum, [animasi didukung](/slides/id/net/convert-powerpoint-to-video/), tetapi dalam kasus yang jarang atau efek tertentu mungkin ter-render secara berbeda. Disarankan untuk menguji dengan efek yang Anda gunakan dan dengan versi perpustakaan.