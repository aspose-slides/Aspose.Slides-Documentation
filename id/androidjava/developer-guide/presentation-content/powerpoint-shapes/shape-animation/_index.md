---
title: Menerapkan Animasi Bentuk pada Presentasi di Android
linktitle: Animasi Bentuk
type: docs
weight: 60
url: /id/androidjava/shape-animation/
keywords:
- bentuk
- animasi
- efek
- bentuk teranimasi
- teks teranimasi
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
- Android
- Java
- Aspose.Slides
description: "Pelajari cara menambahkan, memeriksa, dan menyesuaikan animasi bentuk, penjadwalan, suara, perilaku setelah animasi, serta teks teranimasi dengan Aspose.Slides untuk Android via Java."
---
## **Ringkasan**

Aspose.Slides for Android via Java merepresentasikan animasi slide sebagai efek dalam timeline slide. Sebuah efek memiliki bentuk target, tipe animasi dan subtipe, pemicu, pengaturan waktu, serta properti opsional seperti suara atau perilaku setelah animasi.

Timeline berisi dua jenis urutan:

- **urutan utama** diputar saat slide maju.
- **urutan interaktif** dimulai ketika bentuk pemicunya diklik.

Karena kotak teks, gambar, diagram, tabel, dan objek slide lainnya mengimplementasikan [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/), Anda menggunakan metode [ISequence.addEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) yang sama untuk sebagian besar konten slide. Efek yang tersedia terdaftar dalam kelas [EffectType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/effecttype/).

## **Tambahkan Animasi Bentuk**

Untuk menambahkan animasi, dapatkan urutan utama slide dan panggil [ISequence.addEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) dengan bentuk target, tipe efek, subtipe, dan pemicu. Untuk efek yang dimulai ketika bentuk lain diklik, buat urutan interaktif yang pemicunya adalah bentuk lain tersebut.

Contoh berikut membuat kedua jenis animasi dan menyimpan hasilnya ke `shape-animations.pptx`.

```java
import com.aspose.slides.*;

public class AddShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);

            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Click to animate this shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            IEffect entranceEffect = mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            entranceEffect.getTiming().setDuration(1.5f);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            presentation.save("shape-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Pemicu mengontrol kapan sebuah efek dimulai:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/effecttriggertype/#OnClick) menunggu klik pada urutan utama, atau klik pada bentuk pemicu dalam urutan interaktif.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) dimulai bersamaan dengan efek sebelumnya.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) dimulai ketika efek sebelumnya selesai.

Untuk memberi animasi pada gambar, diagram, atau tipe bentuk lainnya, lewati objek tersebut ke [ISequence.addEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) alih-alih `targetShape`. Untuk opsi pengelompokan khusus diagram, lihat [Animated Charts](/slides/id/androidjava/animated-charts/).

## **Baca Animasi Bentuk**

Gunakan [ISequence.getEffectsByShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) ketika Anda mengetahui bentuk target. Untuk memeriksa setiap efek, enumerasi urutan utama dan setiap urutan interaktif. Enumerasi menghindari asumsi bahwa sebuah urutan berisi efek pada indeks `0`.

Contoh berikut membuat sebuah bentuk dengan efek urutan utama dan interaktif, mengambil efek yang menargetkan bentuk tersebut, lalu mengenumerasi setiap urutan pada slide.

```java
import com.aspose.slides.*;

public class ReadShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Animated shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            IEffect[] targetEffects = mainSequence.getEffectsByShape(targetShape);
            System.out.println("The main sequence contains " + targetEffects.length + " effect(s) for " + targetShape.getName() + ".");

            printSequence("Main sequence", mainSequence);

            int interactiveIndex = 1;
            for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                String triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
                String sequenceLabel = "Interactive sequence " + interactiveIndex + ", trigger: " + triggerName;
                printSequence(sequenceLabel, sequence);
                interactiveIndex++;
            }
        } finally {
            presentation.dispose();
        }
    }

    private static void printSequence(String label, ISequence sequence) {
        System.out.println("  " + label + ": " + sequence.getCount() + " effect(s)");

        for (IEffect effect : sequence) {
            String targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            String triggerName = EffectTriggerType.getName(EffectTriggerType.class, effect.getTiming().getTriggerType());
            String effectDescription = typeName + " " + subtypeName + "; target: " + targetName + "; trigger: " + triggerName;
            System.out.println("    " + effectDescription);
        }
    }
}
```

Jika Anda hanya membutuhkan efek untuk satu bentuk, pertama identifikasi bentuk tersebut berdasarkan nama, tipe placeholder, atau properti stabil lainnya; kemudian panggil [ISequence.getEffectsByShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). Jangan mengasumsikan bahwa [IShapeCollection.get_Item](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) pada indeks `0` selalu merupakan objek yang dimaksud.

## **Bekerja dengan Efek Placeholder yang Diwariskan**

Sebuah placeholder pada slide normal dapat mewarisi perilaku animasi dari placeholder yang sesuai pada slide tata letak dan slide master. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) mengembalikan placeholder induk tersebut, atau `null` bila tidak ada induk.

Pada contoh presentasi berikut, footer memiliki **Random Bars** pada slide normal, **Split** pada slide tata letak, dan **Fly In** pada slide master.

![Footer animation effect on the normal slide](slide-shape-animation.png)

![Footer placeholder animation effect on the layout slide](layout-shape-animation.png)

![Footer placeholder animation effect on the master slide](master-shape-animation.png)

Contoh berikutnya menggunakan hierarki placeholder dari presentasi baru. Ia menambahkan efek ke placeholder master, placeholder tata letak, dan placeholder yang bersesuaian pada slide normal. Setiap pemanggilan [IShape.getBasePlaceholder](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) diperiksa sebelum bentuk yang dikembalikan digunakan.

```java
import com.aspose.slides.*;

public class InheritedPlaceholderAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);
            IShape layoutPlaceholder = findPlaceholderWithBase(layoutSlide);

            if (layoutPlaceholder == null) {
                throw new IllegalStateException("The layout slide does not contain a placeholder linked to its master slide.");
            }

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
            layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

            ISlide slide = presentation.getSlides().addEmptySlide(layoutSlide);
            IShape slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

            if (slidePlaceholder == null) {
                throw new IllegalStateException("The slide does not contain a placeholder linked to its layout slide.");
            }

            slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
            printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

            IShape baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
            if (baseLayoutPlaceholder != null) {
                printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

                IShape baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
                if (baseMasterPlaceholder != null) {
                    printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
                }
            }

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static IShape findPlaceholderWithBase(ILayoutSlide layoutSlide) {
        for (IShape shape : layoutSlide.getShapes()) {
            if (shape.getBasePlaceholder() != null) {
                return shape;
            }
        }

        return null;
    }

    private static IShape findPlaceholderWithBase(ISlide slide, IShape expectedBase) {
        for (IShape shape : slide.getShapes()) {
            if (shape.getBasePlaceholder() == expectedBase) {
                return shape;
            }
        }

        return null;
    }

    private static void printEffects(String source, IEffect[] effects) {
        System.out.println(source + ": " + effects.length + " effect(s)");

        for (IEffect effect : effects) {
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            System.out.println("  " + typeName + " " + subtypeName);
        }
    }
}
```

## **Ubah Timing Animasi**

Dialog **Timing** PowerPoint dipetakan ke properti [ITiming](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/).

![PowerPoint Timing dialog for an animation effect](shape-animation.png)

- **Start** dipetakan ke [ITiming.getTriggerType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/#getTriggerType--).
- **Duration** dipetakan ke [ITiming.getDuration](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/#getDuration--), dalam detik.
- **Delay** dipetakan ke [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--), dalam detik.
- **Repeat** dipetakan ke [ITiming.getRepeatCount](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--), atau [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Rewind when done playing** dipetakan ke [ITiming.getRewind](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/#getRewind--).

Contoh independen ini menambahkan sebuah efek, mengubah timing‑nya melalui objek yang dikembalikan oleh [ISequence.addEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), dan menyimpan hasilnya. Menyimpan referensi [IEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ieffect/) yang dikembalikan menghindari kebutuhan indeks koleksi yang tidak perlu.

```java
import com.aspose.slides.*;

public class ChangeAnimationTiming {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Timed animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTiming().setTriggerType(EffectTriggerType.OnClick);
            effect.getTiming().setDuration(2.0f);
            effect.getTiming().setTriggerDelayTime(0.5f);
            effect.getTiming().setRepeatUntilNextClick(false);
            effect.getTiming().setRepeatUntilEndSlide(false);
            effect.getTiming().setRepeatCount(2.0f);
            effect.getTiming().setRewind(true);

            presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Gunakan satu mode pengulangan secara sengaja. Menggabungkan jumlah pengulangan dengan flag “until” dapat menghasilkan hasil yang membingungkan di viewer yang berbeda. Saat mengubah mode pengulangan, setel [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) dan [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) sebelum [ITiming.setRepeatCount](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-), karena menyetel salah satu flag juga mengubah mode pengulangan yang aktif.

## **Tambahkan dan Ekstrak Suara Animasi**

Sebuah efek animasi dapat merujuk audio tersemat melalui [IEffect.getSound](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ieffect/#getSound--). [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) memberi tahu efek untuk menghentikan audio yang dimulai oleh efek sebelumnya.

### **Tambahkan Suara ke Efek**

Contoh berikut mengharapkan file audio lokal bernama `animation-sound.wav`. Ia membuat dua efek, menyematkan file tersebut sebagai suara untuk efek pertama, dan mengonfigurasi efek kedua untuk menghentikan suara. Ia menggunakan objek yang dikembalikan oleh [ISequence.addEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), sehingga indeks urutan tidak diperlukan.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

public class AddAnimationSound {
    public static void main(String[] args) throws IOException {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
            IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
            firstShape.addTextFrame("Starts sound");
            secondShape.addTextFrame("Stops sound");

            ISequence sequence = slide.getTimeline().getMainSequence();
            IEffect firstEffect = sequence.addEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            IEffect secondEffect = sequence.addEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            byte[] audioData = Files.readAllBytes(Paths.get("animation-sound.wav"));
            IAudio effectSound = presentation.getAudios().addAudio(audioData);
            firstEffect.setSound(effectSound);
            secondEffect.setStopPreviousSound(true);

            presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

### **Ekstrak Suara Efek Tersemat**

Contoh berikut mengharapkan sebuah presentasi lokal bernama `presentation-with-animation-sounds.pptx`. Ia memindai urutan utama dan interaktif, kemudian menulis setiap suara efek tersemat ke direktori `extracted-animation-sounds`. Ekstensi dipilih dari tipe MIME audio yang disediakan oleh [IAudio.getContentType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iaudio/#getContentType--).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

public class ExtractAnimationSounds {
    public static void main(String[] args) throws IOException {
        Path inputPath = Paths.get("presentation-with-animation-sounds.pptx");
        Path outputDirectory = Paths.get("extracted-animation-sounds");

        Files.createDirectories(outputDirectory);

        Presentation presentation = new Presentation(inputPath.toString());
        try {
            int soundIndex = 1;

            for (ISlide slide : presentation.getSlides()) {
                soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

                for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                    soundIndex = saveSounds(sequence, outputDirectory, soundIndex);
                }
            }

            System.out.println("Extracted " + (soundIndex - 1) + " sound file(s) to " + outputDirectory.toAbsolutePath() + ".");
        } finally {
            presentation.dispose();
        }
    }

    private static int saveSounds(ISequence sequence, Path outputDirectory, int soundIndex) throws IOException {
        for (IEffect effect : sequence) {
            if (effect.getSound() == null) {
                continue;
            }

            String extension = getAudioExtension(effect.getSound().getContentType());
            Path outputPath = outputDirectory.resolve("effect-sound-" + soundIndex + extension);
            Files.write(outputPath, effect.getSound().getBinaryData());
            soundIndex++;
        }

        return soundIndex;
    }

    private static String getAudioExtension(String contentType) {
        String normalizedType = contentType == null ? "" : contentType.toLowerCase(Locale.ROOT);

        if (normalizedType.equals("audio/mpeg")) {
            return ".mp3";
        }

        if (normalizedType.equals("audio/mp4")) {
            return ".m4a";
        }

        if (normalizedType.equals("audio/ogg")) {
            return ".ogg";
        }

        if (normalizedType.equals("audio/wav") || normalizedType.equals("audio/x-wav")) {
            return ".wav";
        }

        return ".bin";
    }
}
```

Untuk objek audio berukuran besar, gunakan [IAudio.getStream](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iaudio/#getStream--) dan salin stream ke file alih-alih memuat seluruh objek ke dalam array byte.

## **Setel Perilaku Setelah Animasi**

Opsi **After animation** mengontrol apa yang terjadi pada sebuah bentuk setelah efek selesai.

![PowerPoint Effect Options dialog showing After animation settings](shape-after-animation.png)

Kelas [AfterAnimationType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/afteranimationtype/) mendukung membiarkan bentuk tidak berubah, mengubah warnanya, menyembunyikannya setelah animasi, atau menyembunyikannya pada klik berikutnya. Ketika tipe adalah [AfterAnimationType.Color](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/afteranimationtype/#Color), setel juga [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--).

Contoh independen ini membuat sebuah efek, menetapkan perilaku setelah‑animasi melalui objek efek yang dikembalikan, dan menyimpan hasilnya.

```java
import com.aspose.slides.*;
import android.graphics.Color;

public class SetAfterAnimationBehavior {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Dim after animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.setAfterAnimationType(AfterAnimationType.Color);
            effect.getAfterAnimationColor().setColor(Color.LTGRAY);

            presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Mengubah tipe dari [AfterAnimationType.Color](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/afteranimationtype/#Color) menghapus pengaturan warna setelah‑animasi.

## **Animasi Teks**

Animasi teks memiliki dua kontrol terkait:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextanimation/#getBuildType--) mengontrol apakah paragraf muncul bersamaan atau per tingkat paragraf.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) mengontrol apakah teks muncul sekaligus, per kata, atau per huruf. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) menetapkan jeda antara kata atau huruf. Nilai positif adalah persentase dari durasi efek; nilai negatif adalah jeda dalam detik.

Contoh independen berikut menganimasikan kata‑kata dalam sebuah kotak teks. [BuildType.AsOneObject](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/buildtype/#AsOneObject) menonaktifkan pembangunan paragraf‑per‑paragraf sehingga pengaturan kata berlaku untuk seluruh bingkai teks.

```java
import com.aspose.slides.*;

public class AnimateTextByWord {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
            textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTextAnimation().setBuildType(BuildType.AsOneObject);
            effect.setAnimateTextType(AnimateTextType.ByWord);
            effect.setDelayBetweenTextParts(20.0f);

            presentation.save("animated-text.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Untuk membangun kotak teks per paragraf, setel [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1) (atau tingkat paragraf lainnya). Untuk menargetkan satu paragraf dengan efeknya sendiri, gunakan overload [ISequence.addEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) yang menerima [IParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/). Lihat [Animated Text](/slides/id/androidjava/animated-text/) untuk contoh tingkat paragraf.

## **Ekspor dan Catatan Kompatibilitas**

- Menyimpan ke PPT atau PPTX mempertahankan model animasi, tetapi pemutaran akhir dikendalikan oleh viewer presentasi.
- PDF dan gambar statis tidak memutar animasi. Gunakan [HTML5 export](/slides/id/androidjava/export-to-html5/), GIF animasi, atau [konversi video](/slides/id/androidjava/convert-powerpoint-to-video/) ketika output harus menampilkan gerakan.
- Untuk HTML5, aktifkan [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) dan, bila diperlukan, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- Rendering video mendukung banyak efek masuk, penekanan, keluar, dan jalur‑gerak umum, namun tidak semua efek PowerPoint didukung. Periksa [animasi dan efek yang didukung](/slides/id/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) saat ini dan uji presentasi kritis dengan versi Aspose.Slides Anda.
- Efek khusus lanjutan dan efek yang diimpor dari format presentasi lain mungkin dipertahankan dalam file tetapi dirender berbeda di PowerPoint, HTML5, atau video. Validasi hasil ekspor daripada hanya mengandalkan nama efek.

## **FAQ**

**Mengapa sebuah animasi muncul di PowerPoint tetapi tidak di PDF?**

PDF adalah format statis, sehingga animasi dan transisi slide tidak diputar. Ekspor ke HTML5, GIF animasi, atau video ketika gerakan harus dipertahankan.

**Mengapa sebuah efek diputar berbeda pada video?**

Ekspor video merender animasi alih‑alih menyimpan perilaku asli PowerPoint. Beberapa efek lanjutan tidak didukung atau hanya diperkirakan. Tinjau tabel efek yang didukung dan uji presentasi aktual sebelum penggunaan produksi.

**Apakah memindahkan sebuah bentuk ke depan atau ke belakang mengubah urutan animasinya?**

Tidak. Urutan z‑order bentuk mengontrol tumpang tindih, sementara urutan urutan dan pemicu mengontrol pemutaran animasi. Ubah timeline jika Anda membutuhkan urutan pemutaran yang berbeda.