---
title: Terapkan Animasi Bentuk dalam Presentasi Menggunakan Java
linktitle: Animasi Bentuk
type: docs
weight: 60
url: /id/java/shape-animation/
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
- Java
- Aspose.Slides
description: "Temukan cara membuat dan menyesuaikan animasi bentuk dalam presentasi PowerPoint dengan Aspose.Slides untuk Java. Tampil beda!"
---
## **Pendahuluan**

Animasi adalah efek visual yang dapat diterapkan pada teks, gambar, bentuk, atau [charts](https://docs.aspose.com/slides/id/java/animated-charts/). Mereka memberi kehidupan pada presentasi atau komponennya. 

## **Mengapa Menggunakan Animasi dalam Presentasi?**

Menggunakan animasi, Anda dapat 

* mengontrol aliran informasi
* menekankan poin penting
* meningkatkan minat atau partisipasi audiens Anda
* membuat konten lebih mudah dibaca, dipahami, atau diproses
* menarik perhatian pembaca atau penonton ke bagian penting dalam presentasi

PowerPoint menyediakan banyak pilihan dan alat untuk animasi serta efek animasi dalam kategori **entrance**, **exit**, **emphasis**, dan **motion paths**. 

## **Animasi di Aspose.Slides**

* Aspose.Slides menyediakan kelas dan tipe yang Anda butuhkan untuk bekerja dengan animasi di bawah namespace `Aspose.Slides.Animation`,
* Aspose.Slides menyediakan lebih dari **150 efek animasi** di dalam enumerasi [EffectType](https://reference.aspose.com/slides/id/java/com.aspose.slides/effecttype). Efek-efek ini pada dasarnya sama (atau setara) dengan efek yang digunakan di PowerPoint.

## **Terapkan Animasi ke TextBox**

Aspose.Slides untuk Java memungkinkan Anda menerapkan animasi pada teks dalam sebuah bentuk. 

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan sebuah `rectangle` [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape). 
4. Tambahkan teks ke [IAutoShape.TextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Dapatkan urutan utama efek.
6. Tambahkan efek animasi ke [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape). 
7. Atur properti `TextAnimation.BuildType` ke nilai dari enumerasi `BuildType`.
8. Simpan presentasi ke disk sebagai file PPTX.

Kode Java berikut menunjukkan cara menerapkan efek `Fade` ke AutoShape dan mengatur animasi teks ke nilai *By 1st Level Paragraphs*:

```java
import com.aspose.slides.*;

// Membuat instance kelas presentasi yang mewakili file presentasi.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Menambahkan AutoShape baru dengan teks
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Mendapatkan urutan utama slide.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Menambahkan efek animasi Fade ke shape
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Menganimasikan teks shape berdasarkan paragraf tingkat pertama
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Menyimpan file PPTX ke disk
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

Selain menerapkan animasi pada teks, Anda juga dapat menerapkan animasi pada satu [Paragraph](https://reference.aspose.com/slides/id/java/com.aspose.slides/iparagraph). Lihat [**Animated Text**](/slides/id/java/animated-text/).

{{% /alert %}} 

## **Terapkan Animasi ke PictureFrame**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan atau dapatkan sebuah [PictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/pictureframe) pada slide. 
4. Dapatkan urutan utama efek.
5. Tambahkan efek animasi ke [PictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/pictureframe).
6. Simpan presentasi ke disk sebagai file PPTX.

Kode Java berikut menunjukkan cara menerapkan efek `Fly` ke picture frame:

```java
import com.aspose.slides.*;

// Membuat instance kelas presentasi yang mewakili file presentasi.
Presentation pres = new Presentation();
try {
    // Memuat gambar yang akan ditambahkan ke koleksi gambar presentasi
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Menambahkan picture frame ke slide
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Mendapatkan urutan utama slide.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Menambahkan efek animasi Fly dari Kiri ke picture frame
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Menyimpan file PPTX ke disk
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Terapkan Animasi ke Shape**

1. Buat instance dari [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan sebuah `rectangle` [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape). 
4. Tambahkan sebuah `Bevel` [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape) (ketika objek ini diklik, animasi akan diputar).
5. Buat urutan efek pada bentuk bevel.
6. Buat `UserPath` khusus.
7. Tambahkan perintah untuk bergerak ke `UserPath`.
8. Simpan presentasi ke disk sebagai file PPTX.

Kode Java berikut menunjukkan cara menerapkan efek `PathFootball` (path football) ke sebuah shape:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// Membuat instance kelas Presentation yang mewakili file PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Membuat efek PathFootball untuk shape yang ada dari awal.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Menambahkan efek animasi PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Membuat semacam "button".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Membuat urutan efek untuk tombol ini.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Membuat jalur pengguna khusus. Objek kami akan dipindahkan hanya setelah tombol diklik.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Menambahkan perintah untuk bergerak karena jalur yang dibuat kosong.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Menulis file PPTX ke disk
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dapatkan Efek Animasi yang Diterapkan pada Shape**

Contoh berikut menunjukkan cara menggunakan metode `getEffectsByShape` dari antarmuka [ISequence](https://reference.aspose.com/slides/id/java/com.aspose.slides/isequence/) untuk mendapatkan semua efek animasi yang diterapkan pada sebuah shape.

**Contoh 1: Dapatkan efek animasi yang diterapkan pada shape di slide normal**

Sebelumnya, Anda telah belajar cara menambahkan efek animasi ke shape dalam presentasi PowerPoint. Kode contoh berikut menunjukkan cara mendapatkan efek yang diterapkan pada shape pertama di slide normal pertama dalam presentasi `AnimExample_out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Mendapatkan urutan animasi utama slide.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Mendapatkan shape pertama pada slide pertama.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Mendapatkan efek animasi yang diterapkan pada shape.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**Contoh 2: Dapatkan semua efek animasi, termasuk yang diwarisi dari placeholder**

Jika sebuah shape pada slide normal memiliki placeholder yang berada pada slide tata letak dan/atau master slide, dan efek animasi telah ditambahkan ke placeholder tersebut, maka semua efek shape akan diputar selama pertunjukan slide, termasuk yang diwarisi dari placeholder.

Misalkan kita memiliki file presentasi PowerPoint `sample.pptx` dengan satu slide yang hanya berisi shape footer dengan teks "Made with Aspose.Slides" dan efek **Random Bars** diterapkan pada shape tersebut.

![Slide shape animation effect](slide-shape-animation.png)

Misalkan juga efek **Split** diterapkan pada placeholder footer di slide **layout**.

![Layout shape animation effect](layout-shape-animation.png)

Dan akhirnya, efek **Fly In** diterapkan pada placeholder footer di slide **master**.

![Master shape animation effect](master-shape-animation.png)

Kode contoh berikut menunjukkan cara menggunakan metode `getBasePlaceholder` dari antarmuka [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/) untuk mengakses placeholder shape dan mendapatkan efek animasi yang diterapkan pada shape footer, termasuk yang diwarisi dari placeholder yang berada pada slide tata letak dan master.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Dapatkan efek animasi shape pada slide normal.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Dapatkan efek animasi placeholder pada slide tata letak.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Dapatkan efek animasi placeholder pada slide master.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
for (IEffect[] effects : new IEffect[][] { masterShapeEffects, layoutShapeEffects, shapeEffects }) {
    for (IEffect effect : effects) {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}

presentation.dispose();
```
```java
import com.aspose.slides.*;

static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Ubah Properti Timing Efek Animasi**

Ini adalah panel Animation Timing di Microsoft PowerPoint:

![example1_image](shape-animation.png)

Berikut adalah korespondensi antara PowerPoint Timing dan properti [Effect.Timing](https://reference.aspose.com/slides/id/java/com.aspose.slides/IEffect#getTiming--):

- Drop-down **Start** pada PowerPoint Timing cocok dengan properti [Effect.Timing.TriggerType](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITiming#getTriggerType--). 
- **Duration** pada PowerPoint Timing cocok dengan properti [Effect.Timing.Duration](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITiming#getDuration--). Durasi animasi (dalam detik) adalah total waktu yang diperlukan animasi untuk menyelesaikan satu siklus. 
- **Delay** pada PowerPoint Timing cocok dengan properti [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITiming#getTriggerDelayTime--). 

Berikut cara mengubah properti Timing efek:

1. [Terapkan](#apply-animation-to-shape) atau dapatkan efek animasi.
2. Atur nilai baru untuk properti [Effect.Timing](https://reference.aspose.com/slides/id/java/com.aspose.slides/IEffect#getTiming--) yang Anda butuhkan. 
3. Simpan file PPTX yang telah dimodifikasi.

```java
import com.aspose.slides.*;

// Membuat instance kelas presentasi yang mewakili file presentasi.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Mendapatkan urutan utama slide.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Mendapatkan efek pertama dari urutan utama.
    IEffect effect = sequence.get_Item(0);

    // Mengubah TriggerType efek menjadi mulai saat klik
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Mengubah Durasi efek
    effect.getTiming().setDuration(3f);

    // Mengubah TriggerDelayTime efek
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Menyimpan file PPTX ke disk
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Suara Efek Animasi**

Aspose.Slides menyediakan properti berikut untuk memungkinkan Anda bekerja dengan suara dalam efek animasi: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/id/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/id/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Tambahkan Suara Efek Animasi**

Kode Java berikut menunjukkan cara menambahkan suara efek animasi dan menghentikannya ketika efek berikutnya dimulai:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Menambahkan audio ke koleksi audio presentasi
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Mendapatkan urutan utama slide.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Mendapatkan efek pertama dari urutan utama
    IEffect firstEffect = sequence.get_Item(0);

    // Memeriksa efek untuk "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Menambahkan suara untuk efek pertama
        firstEffect.setSound(effectSound);
    }

    // Mendapatkan urutan interaktif pertama dari slide.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Mengatur flag efek "Stop previous sound"
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Menulis file PPTX ke disk
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ekstrak Suara Efek Animasi**

1. Buat instance dari [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
2. Dapatkan referensi slide melalui indeksnya. 
3. Dapatkan urutan utama efek. 
4. Ekstrak [setSound(IAudio value)](https://reference.aspose.com/slides/id/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) yang tertanam pada setiap efek animasi. 

Kode Java berikut menunjukkan cara mengekstrak suara yang tertanam dalam sebuah efek animasi:

```java
import com.aspose.slides.*;

// Membuat instance kelas presentasi yang mewakili file presentasi.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Mendapatkan urutan utama slide.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Mengekstrak suara efek ke dalam array byte
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Setelah Animasi**

Aspose.Slides untuk Java memungkinkan Anda mengubah properti After animation dari sebuah efek animasi.

Ini adalah panel Effect Animation dan menu yang diperluas di Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Drop-down **After animation** pada PowerPoint Effect cocok dengan properti berikut: 

- Properti [setAfterAnimationType(int value)] yang menggambarkan tipe After animation :
  * PowerPoint **More Colors** cocok dengan tipe [AfterAnimationType.Color](https://reference.aspose.com/slides/id/java/com.aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** cocok dengan tipe [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/id/java/com.aspose.slides/afteranimationtype/#DoNotDim) (tipe after animation default);
  * PowerPoint **Hide After Animation** cocok dengan tipe [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/id/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** cocok dengan tipe [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/id/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Properti [setAfterAnimationColor(IColorFormat value)] yang menentukan format warna after animation. Properti ini bekerja bersama dengan tipe [AfterAnimationType.Color](https://reference.aspose.com/slides/id/java/com.aspose.slides/afteranimationtype/#Color). Jika Anda mengubah tipe ke yang lain, warna after animation akan dihapus.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Membuat instance kelas presentasi yang mewakili file presentasi
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Mendapatkan efek pertama dari urutan utama
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Mengubah tipe after animation menjadi Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Mengatur warna after animation dim
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Menulis file PPTX ke disk
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animasi Teks**

Aspose.Slides menyediakan properti berikut untuk memungkinkan Anda bekerja dengan blok *Animate text* pada sebuah efek animasi:

- [setAnimateTextType(int value)] yang menggambarkan tipe animate text dari efek. Teks shape dapat dianimasikan:
  - Semua sekaligus ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/id/java/com.aspose.slides/animatetexttype/#AllAtOnce) type)
  - Per kata ([AnimateTextType.ByWord](https://reference.aspose.com/slides/id/java/com.aspose.slides/animatetexttype/#ByWord) type)
  - Per huruf ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/id/java/com.aspose.slides/animatetexttype/#ByLetter) type)
- [setDelayBetweenTextParts(float value)] mengatur jeda antara bagian teks yang dianimasikan (kata atau huruf). Nilai positif menentukan persentase durasi efek. Nilai negatif menentukan jeda dalam detik.

Berikut cara mengubah properti Animate text pada Effect:

1. [Terapkan](#apply-animation-to-shape) atau dapatkan efek animasi.
2. Atur properti [setBuildType(int value)] ke nilai [BuildType.AsOneObject] untuk mematikan mode animasi *By Paragraphs*.
3. Atur nilai baru untuk properti [setAnimateTextType(int value)] dan [setDelayBetweenTextParts(float value)].
4. Simpan file PPTX yang telah dimodifikasi.

```java
import com.aspose.slides.*;

// Membuat instance kelas presentasi yang mewakili file presentasi.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Mendapatkan efek pertama dari urutan utama
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Mengubah tipe animasi teks efek menjadi "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Mengubah tipe animasi teks efek menjadi "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Mengatur jeda antar kata menjadi 20% dari durasi efek
    firstEffect.setDelayBetweenTextParts(20f);

    // Menulis file PPTX ke disk
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Bagaimana saya dapat memastikan animasi tetap terjaga saat memublikasikan presentasi ke web?

[Export to HTML5](/slides/id/java/export-to-html5/) dan aktifkan [options](https://reference.aspose.com/slides/id/java/com.aspose.slides/html5options/) yang bertanggung jawab atas animasi [shape](https://reference.aspose.com/slides/id/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) dan [transition](https://reference.aspose.com/slides/id/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). HTML biasa tidak memutar animasi slide, sedangkan HTML5 melakukannya.

### Bagaimana mengubah urutan z (urutan lapisan) shape memengaruhi animasi?

Urutan animasi dan gambar bersifat independen: sebuah efek mengontrol timing dan tipe muncul/hilang, sementara [z-order](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#getZOrderPosition--) menentukan apa yang menutupi apa. Hasil yang terlihat ditentukan oleh kombinasi keduanya. (Ini adalah perilaku umum PowerPoint; model effects-and-shapes Aspose.Slides mengikuti logika yang sama.)

### Apakah ada batasan ketika mengonversi animasi ke video untuk efek tertentu?

Secara umum, [animasi didukung](/slides/id/java/convert-powerpoint-to-video/), namun kasus langka atau efek tertentu mungkin dirender secara berbeda. Disarankan untuk menguji dengan efek yang Anda gunakan dan dengan versi pustaka.