---
title: Terapkan Animasi Bentuk dalam Presentasi Menggunakan JavaScript
linktitle: Animasi Bentuk
type: docs
weight: 60
url: /id/nodejs-java/shape-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Temukan cara membuat dan menyesuaikan animasi bentuk dalam presentasi PowerPoint dengan JavaScript dan Aspose.Slides untuk Node.js via Java. Tampil menonjol!"
---
## **Pendahuluan**

Animasi adalah efek visual yang dapat diterapkan pada teks, gambar, bentuk, atau [bagan](/slides/id/nodejs-java/animated-charts/). Mereka memberi kehidupan pada presentasi atau bagiannya.

## **Mengapa Menggunakan Animasi dalam Presentasi?**

* mengendalikan alur informasi
* menekankan poin penting
* meningkatkan minat atau partisipasi di antara audiens Anda
* mempermudah konten untuk dibaca, dipahami, atau diproses
* menarik perhatian pembaca atau penonton Anda ke bagian penting dalam presentasi

PowerPoint menyediakan banyak opsi dan alat untuk animasi serta efek animasi di kategori **entrance**, **exit**, **emphasis**, dan **motion paths**.

## **Animasi di Aspose.Slides**

* Aspose.Slides menyediakan kelas dan tipe yang Anda butuhkan untuk bekerja dengan animasi di bawah namespace `Aspose.Slides.Animation`,
* Aspose.Slides menyediakan lebih dari **150 efek animasi** di bawah enumerasi [EffectType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effecttype). Efek-efek ini pada dasarnya sama (atau setara) dengan efek yang digunakan di PowerPoint.

## **Terapkan Animasi ke TextBox**

Aspose.Slides untuk Node.js via Java memungkinkan Anda menerapkan animasi pada teks dalam sebuah bentuk.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan sebuah `rectangle` [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape).
4. Tambahkan teks menggunakan [AutoShape.addTextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-).
5. Dapatkan urutan utama efek.
6. Tambahkan efek animasi ke [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape).
7. Panggil metode `TextAnimation.setBuildType` dengan nilai dari enumerasi `BuildType`.
8. Tuliskan presentasi ke disk sebagai file PPTX.

Kode Javascript ini menunjukkan cara menerapkan efek `Fade` ke AutoShape dan mengatur animasi teks ke nilai *By 1st Level Paragraphs*:

```javascript
// Membuat instance kelas presentasi yang mewakili file presentasi.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Menambahkan AutoShape baru dengan teks
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // Mendapatkan urutan utama slide.
    var sequence = sld.getTimeline().getMainSequence();
    // Menambahkan efek animasi Fade ke shape
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Menganimasi teks shape berdasarkan paragraf tingkat pertama
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // Menyimpan file PPTX ke disk
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert color="primary"  %}} 
Selain menerapkan animasi pada teks, Anda juga dapat menerapkan animasi pada satu [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph). Lihat [**Animated Text**](/slides/id/nodejs-java/animated-text/).
{{% /alert %}} 

## **Terapkan Animasi ke PictureFrame**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan atau dapatkan sebuah [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe) pada slide.
4. Dapatkan urutan utama efek.
5. Tambahkan efek animasi ke [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe).
6. Tuliskan presentasi ke disk sebagai file PPTX.

```javascript
// Membuat instance kelas presentasi yang mewakili file presentasi.
var pres = new aspose.slides.Presentation();
try {
    // Memuat gambar yang akan ditambahkan ke koleksi gambar presentasi
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Menambahkan frame gambar ke slide
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // Mendapatkan urutan utama slide.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Menambahkan efek animasi Fly dari Kiri ke frame gambar
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // Menyimpan file PPTX ke disk
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Terapkan Animasi ke Shape**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan sebuah `rectangle` [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape).
4. Tambahkan sebuah `Bevel` [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape) (ketika objek ini diklik, animasi akan diputar).
5. Buat urutan efek pada bentuk bevel.
6. Buat `UserPath` khusus.
7. Tambahkan perintah untuk bergerak ke `UserPath`.
8. Tuliskan presentasi ke disk sebagai file PPTX.

```javascript
// Membuat instance kelas Presentation yang mewakili file PPTX.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Membuat efek PathFootball untuk shape yang ada dari awal.
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // Menambahkan efek animasi PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Membuat semacam "tombol".
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // Membuat urutan efek untuk tombol ini.
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // Membuat jalur pengguna khusus. Objek kami akan dipindahkan hanya setelah tombol diklik.
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Menambahkan perintah pergerakan karena jalur yang dibuat kosong.
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // Menulis file PPTX ke disk
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dapatkan Efek Animasi yang Diterapkan pada Shape**

Contoh berikut menunjukkan cara menggunakan metode `getEffectsByShape` dari kelas [Sequence](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sequence/) untuk mendapatkan semua efek animasi yang diterapkan pada sebuah shape.

**Contoh 1: Dapatkan efek animasi yang diterapkan pada shape di slide normal**

Sebelumnya, Anda telah mempelajari cara menambahkan efek animasi ke shape dalam presentasi PowerPoint. Kode contoh berikut menunjukkan cara mendapatkan efek yang diterapkan pada shape pertama di slide normal pertama dalam presentasi `AnimExample_out.pptx`.

```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // Mendapatkan urutan animasi utama slide.
    var sequence = firstSlide.getTimeline().getMainSequence();

    // Mendapatkan shape pertama pada slide pertama.
    var shape = firstSlide.getShapes().get_Item(0);

    // Mendapatkan efek animasi yang diterapkan pada shape.
    var shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0) {
        console.log("The shape", shape.getName(), "has", shapeEffects.length, "animation effects.");
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

**Contoh 2: Dapatkan semua efek animasi, termasuk yang diwarisi dari placeholder**

Jika sebuah shape pada slide normal memiliki placeholder yang berada pada slide tata letak dan/atau master, dan efek animasi telah ditambahkan ke placeholder tersebut, maka semua efek shape akan diputar selama pertunjukan slide, termasuk yang diwarisi dari placeholder.

Misalkan kami memiliki file presentasi PowerPoint `sample.pptx` dengan satu slide yang hanya berisi shape footer dengan teks "Made with Aspose.Slides" dan efek **Random Bars** diterapkan pada shape tersebut.

![Efek animasi shape slide](slide-shape-animation.png)

Anggap juga bahwa efek **Split** diterapkan pada placeholder footer pada slide **layout**.

![Efek animasi shape layout](layout-shape-animation.png)

Dan akhirnya, efek **Fly In** diterapkan pada placeholder footer pada slide **master**.

![Efek animasi shape master](master-shape-animation.png)

Kode contoh berikut menunjukkan cara menggunakan metode `getBasePlaceholder` dari kelas [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/) untuk mengakses placeholder shape dan mendapatkan efek animasi yang diterapkan pada shape footer, termasuk yang diwarisi dari placeholder yang terletak pada slide layout dan master.

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
var masterShape = layoutShape.getBasePlaceholder();
var masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

console.log("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```js
function printEffects(effects) {
    for (const effect of effects) {
        console.log("Type:", effect.getType() + ", subtype:", effect.getSubtype());
    }
}
```

```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Terbang, Bawah
Type: 134, subtype: 45            // Pisah, VertikalMasuk
Type: 126, subtype: 22            // BilahAcak, Horizontal
```

## **Ubah Properti Timing Efek Animasi**

Aspose.Slides untuk Node.js via Java memungkinkan Anda mengubah properti Timing dari sebuah efek animasi.

Berikut adalah panel Timing Animasi di Microsoft PowerPoint:

![Panel Timing Animasi](shape-animation.png)

Berikut adalah korespondensi antara PowerPoint Timing dan properti [Effect.Timing](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Effect#getTiming--):

- Daftar drop-down **Start** pada PowerPoint Timing cocok dengan properti [Effect.Timing.TriggerType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Timing#getTriggerType--).
- PowerPoint Timing **Duration** cocok dengan properti [Effect.Timing.Duration](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Timing#getDuration--). Durasi sebuah animasi (dalam detik) adalah total waktu yang dibutuhkan animasi untuk menyelesaikan satu siklus.
- PowerPoint Timing **Delay** cocok dengan properti [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--).

Berikut cara mengubah properti Timing Efek:

1. [Terapkan](#apply-animation-to-shape) atau dapatkan efek animasi.
2. Tetapkan nilai baru untuk properti [Effect.Timing](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Effect#getTiming--) yang Anda perlukan.
3. Simpan file PPTX yang dimodifikasi.

```javascript
// Membuat instance kelas presentasi yang mewakili file presentasi.
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Mendapatkan urutan utama slide.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Mendapatkan efek pertama dari urutan utama.
    var effect = sequence.get_Item(0);
    // Mengubah TriggerType efek menjadi mulai saat diklik
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // Mengubah Durasi efek
    effect.getTiming().setDuration(3.0);
    // Mengubah TriggerDelayTime efek
    effect.getTiming().setTriggerDelayTime(0.5);
    // Menyimpan file PPTX ke disk
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Suara Efek Animasi**

Aspose.Slides menyediakan properti-properti berikut untuk memungkinkan Anda bekerja dengan suara dalam efek animasi: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Tambahkan Suara Efek Animasi**

Kode Javascript ini menunjukkan cara menambahkan suara efek animasi dan menghentikannya ketika efek berikutnya dimulai:

```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Menambahkan audio ke koleksi audio presentasi
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // Mendapatkan urutan utama slide.
    var sequence = firstSlide.getTimeline().getMainSequence();
    // Mendapatkan efek pertama dari urutan utama
    var firstEffect = sequence.get_Item(0);
    // Memeriksa efek untuk "No Sound"
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // Menambahkan suara untuk efek pertama
        firstEffect.setSound(effectSound);
    }
    // Mendapatkan urutan interaktif pertama slide.
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // Mengatur flag efek "Stop previous sound"
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // Menyimpan file PPTX ke disk
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Ekstrak Suara Efek Animasi**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Dapatkan referensi slide melalui indeksnya. 
3. Dapatkan urutan utama efek. 
4. Ekstrak [setSound(IAudio value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-) yang tertanam pada setiap efek animasi.

Kode Javascript ini menunjukkan cara mengekstrak suara yang tertanam dalam efek animasi:

```javascript
// Membuat instance kelas presentasi yang mewakili file presentasi.
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Mendapatkan urutan utama slide.
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // Mengekstrak suara efek ke dalam array byte
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Setelah Animasi**

Aspose.Slides untuk Node.js via Java memungkinkan Anda mengubah properti After animation dari sebuah efek animasi.

Berikut adalah panel Efek Animasi dan menu tambahan di Microsoft PowerPoint:

![Panel Efek Animasi](shape-after-animation.png)

Daftar drop-down **After animation** pada PowerPoint Effect cocok dengan properti-properti berikut: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) metode yang menjelaskan tipe After animation;
  * PowerPoint **More Colors** cocok dengan tipe [AfterAnimationType.Color](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** cocok dengan tipe [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) (tipe after animation default);
  * PowerPoint **Hide After Animation** cocok dengan tipe [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** cocok dengan tipe [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) metode yang mendefinisikan format warna after animation. Metode ini bekerja bersama dengan tipe [AfterAnimationType.Color](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/afteranimationtype/#Color). Jika Anda mengubah tipe ke yang lain, warna after animation akan dihapus.

```javascript
// Membuat instance kelas presentasi yang mewakili file presentasi
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Mendapatkan efek pertama dari urutan utama
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Mengubah tipe after animation menjadi Color
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // Mengatur warna after animation
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Menulis file PPTX ke disk
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animasi Teks**

Aspose.Slides menyediakan properti-properti berikut untuk memungkinkan Anda bekerja dengan blok *Animate text* pada efek animasi:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) yang menjelaskan tipe animate text dari efek. Teks shape dapat dianimasikan:
  - Semua sekaligus ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce) tipe)
  - Per kata ([AnimateTextType.ByWord](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/animatetexttype/#ByWord) tipe)
  - Per huruf ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/animatetexttype/#ByLetter) tipe)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) mengatur jeda antara bagian teks yang dianimasikan (kata atau huruf). Nilai positif menentukan persentase durasi efek. Nilai negatif menentukan jeda dalam detik.

Berikut cara Anda dapat mengubah properti Animate text pada Efek:

1. [Terapkan](#apply-animation-to-shape) atau dapatkan efek animasi.
2. Tetapkan metode [setBuildType(int value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textanimation/#setBuildType-int-) ke nilai [BuildType.AsOneObject](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/buildtype/#AsOneObject) untuk menonaktifkan mode animasi *By Paragraphs*.
3. Tetapkan nilai baru untuk properti [setAnimateTextType(int value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) dan [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-).
4. Simpan file PPTX yang dimodifikasi.

```javascript
// Membuat instance kelas presentasi yang mewakili file presentasi.
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Mendapatkan efek pertama dari urutan utama
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Mengubah tipe animasi teks efek menjadi "As One Object"
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // Mengubah tipe Animate text efek menjadi "By word"
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // Menetapkan jeda antara kata menjadi 20% dari durasi efek
    firstEffect.setDelayBetweenTextParts(20.0);
    // Menulis file PPTX ke disk
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Bagaimana saya dapat memastikan animasi tetap terjaga saat mempublikasikan presentasi ke web?**

[Export to HTML5](/slides/id/nodejs-java/export-to-html5/) dan aktifkan [options](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/html5options/) yang bertanggung jawab atas animasi [shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/html5options/setanimateshapes/) dan [transition](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/html5options/setanimatetransitions/). HTML biasa tidak memutar animasi slide, sedangkan HTML5 melakukannya.

**Bagaimana mengubah z-order (urutan lapisan) shape memengaruhi animasi?**

Animasi dan urutan gambar bersifat independen: sebuah efek mengontrol timing dan jenis muncul/hilang, sementara [z-order](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/getzorderposition/) menentukan apa yang menutupi apa. Hasil yang terlihat ditentukan oleh kombinasi keduanya. (Ini adalah perilaku umum PowerPoint; model efek-dan-shape Aspose.Slides mengikuti logika yang sama.)

**Apakah ada batasan ketika mengonversi animasi ke video untuk efek tertentu?**

Secara umum, [animasi didukung](/slides/id/nodejs-java/convert-powerpoint-to-video/), tetapi kasus yang jarang atau efek tertentu mungkin dirender secara berbeda. Disarankan untuk menguji dengan efek yang Anda gunakan dan dengan versi perpustakaan.