---
title: "Kelola Slide Master Presentasi di Android"
linktitle: "Slide Master"
type: docs
weight: 70
url: /id/androidjava/slide-master/
keywords:
- "slide master"
- "slide master"
- "slide master PPT"
- "banyak slide master"
- "bandingkan slide master"
- "latar belakang"
- "placeholder"
- "klon slide master"
- "salin slide master"
- "duplikat slide master"
- "slide master yang tidak terpakai"
- "PowerPoint"
- "OpenDocument"
- "presentasi"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Kelola slide master di Aspose.Slides untuk Android via Java: akses, edit, klon, bandingkan, dan hapus slide master dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Sebuah **slide master** mendefinisikan pengaturan desain bersama untuk sekelompok slide. Ia dapat berisi bentuk umum, logo, latar belakang, gaya teks, pengaturan tema, dan pengaturan footer. Di PowerPoint, mengedit slide master adalah cara umum untuk menjaga konsistensi presentasi tanpa mengulangi pemformatan yang sama pada setiap slide.

Aspose.Slides for Android via Java mendukung model yang sama. Sebuah presentasi dapat berisi satu atau lebih slide master, dan setiap slide master dapat berisi beberapa layout slide. Slide normal biasanya tidak merujuk langsung ke slide master. Sebaliknya, slide normal menggunakan layout slide, dan layout slide tersebut termasuk dalam slide master.

Hierarki nya adalah:

1. **Slide master** - mendefinisikan desain dan tema bersama.  
1. **Layout slide** - mendefinisikan susunan placeholder dan pemformatan tingkat layout yang spesifik.  
1. **Normal slide** - berisi konten presentasi aktual dan menggunakan satu layout slide.

![Hierarki slide master, layout slide, dan slide normal](slide-master_2.jpg)

Di Aspose.Slides, slide master direpresentasikan oleh antarmuka [IMasterSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslide/). Semua slide master dalam sebuah presentasi dapat diakses melalui koleksi [Presentation.getMasters](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getMasters--) yang mengimplementasikan [IMasterSlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslidecollection/). Untuk seluruh API Android via Java, lihat referensi API [com.aspose.slides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}
Ketika properti yang sama didefinisikan pada lebih dari satu level, level yang lebih spesifik yang akan menang. Misalnya, bila slide master dan layout slide keduanya mendefinisikan latar belakang, slide yang berbasis pada layout tersebut akan menggunakan latar belakang layout. Untuk informasi lebih lanjut tentang layout slide, lihat [Terapkan atau Ubah Tata Letak Slide](/slides/id/androidjava/slide-layout/).
{{% /alert %}}

## **Akses Slide Master**

Di PowerPoint, Anda dapat membuka tampilan Slide Master dari **View** > **Slide Master**.

![Perintah Slide Master pada tab View di PowerPoint](slide-master_3.jpg)

Di Aspose.Slides, gunakan koleksi `getMasters()` untuk mengakses slide master:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Anda juga dapat mendapatkan slide master yang digunakan oleh slide normal melalui layout‑nya:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Apa yang Dimiliki Slide Master**

Slide master adalah objek mirip slide. Ia mengimplementasikan [IBaseSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseslide/), sehingga menampilkan banyak properti slide yang sama dengan slide normal dan layout slide.

Anggota master slide yang umum digunakan meliputi:

| Anggota | Tujuan |
| --- | --- |
| `getBackground()` | Menetapkan latar belakang slide tingkat master. |
| `getShapes()` | Menyimpan bentuk‑bentuk yang ditempatkan pada master, seperti logo, bingkai gambar, dan teks bersama. |
| `getLayoutSlides()` | Menyimpan layout slide yang termasuk dalam master. |
| `getThemeManager()` | Menyediakan akses ke API tema master. |
| `getHeaderFooterManager()` | Mengontrol header, footer, tanggal, dan nomor slide untuk master serta layout‑nya. |
| `getDependingSlides()` | Mengembalikan slide normal yang bergantung pada master melalui layout masing‑masing. |

## **Tambahkan Gambar ke Slide Master**

Saat Anda menambahkan gambar ke slide master, gambar tersebut akan muncul pada slide yang menggunakan layout dari master itu. Ini berguna untuk logo, watermark, pita dekoratif, dan elemen visual berulang lainnya.

Contoh berikut menambahkan logo ke slide master pertama:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk informasi lebih lanjut tentang bingkai gambar, lihat [Picture Frame](/slides/id/androidjava/picture-frame/).

## **Kontrol Visibilitas Grafis Master**

Gunakan [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) untuk menyembunyikan grafis master yang diwarisi, seperti logo atau bentuk dekoratif, tanpa menghapusnya dari master. Berikan `false` pada [Slide.setShowMasterShapes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slide/#setShowMasterShapes-boolean-) pada slide yang harus menghilangkan grafis tersebut dan pertahankan `true` pada slide yang harus menampilkannya.

Contoh mandiri berikut membuat pita dekoratif biru pada master dan dua slide yang memakai layout kosong yang sama. Pita terlihat pada slide pertama dan tersembunyi pada slide kedua. Tidak diperlukan presentasi atau gambar input.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    int bandColor = Color.rgb(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Contoh menggunakan layout **Blank** yang disertakan dengan presentasi baru dan menghapus placeholder slide awal.

### **Pilih Lingkup Pengaturan**

Slide normal menggunakan master‑nya melalui [ISlide.getLayoutSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islide/#getLayoutSlide--) dan [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslide/#getMasterSlide--). Menetapkan properti pada slide individual hanya memengaruhi slide tersebut. Memberikan `false` pada [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) menyembunyikan grafis master untuk semua slide yang memakai layout bersama itu, meskipun pengaturan mereka sendiri `true`. Untuk menyembunyikan grafis hanya pada satu slide, ubah properti slide tersebut dan biarkan layout bersama tidak berubah.

Pengaturan ini tidak didukung sebagai kontrol visibilitas pada slide master itu sendiri. Pada master, [getShowMasterShapes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/masterslide/#getShowMasterShapes--) selalu mengembalikan `false`, dan memberikan `true` ke [setShowMasterShapes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) akan menimbulkan pengecualian. Terapkan pada slide normal atau layout saja.

### **Bedakan Grafis dari Latar Belakang**

| Operasi | Efek |
| --- | --- |
| Sembunyikan grafis master | Mengontrol visibilitas bentuk master yang diwarisi tanpa menghapusnya atau mengubah bentuk slide itu sendiri. |
| Ubah isi latar belakang slide | Mengubah warna, gradien, atau gambar latar belakang. Grafis master adalah bentuk terpisah dan dapat tetap terlihat di atas latar tersebut. Lihat [Presentation Background](/slides/id/androidjava/presentation-background/). |
| Hapus bentuk dari master | Menghapus bentuk sumber bersama, sehingga tidak lagi tersedia untuk slide mana pun yang memakai master itu. |

## **Bekerja dengan Placeholder**

Placeholder biasanya didefinisikan pada layout slide. Slide master menyediakan gaya dan tema bersama yang diwarisi oleh layout, sementara tiap layout menentukan placeholder yang tersedia dan penempatannya.

Di PowerPoint, perintah placeholder tersedia dalam tampilan Slide Master.

![Perintah Insert Placeholder dalam tampilan Slide Master PowerPoint](slide-master_5.png)

Untuk menambahkan placeholder baru dengan Aspose.Slides, kerjakan layout slide yang termasuk dalam master:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Anda juga dapat memformat bentuk placeholder yang sudah ada pada slide master. Contoh berikut menemukan placeholder judul dan menerapkan isian gradien linear:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Placeholder judul yang diformat dan diwarisi oleh slide normal](slide-master_8.png)

Untuk opsi pemformatan placeholder dan teks lebih lanjut, lihat [Atur Teks Prompt di Placeholder](/slides/id/androidjava/manage-placeholder/) dan [Pemformatan Teks](/slides/id/androidjava/text-formatting/).

## **Ubah Latar Belakang Slide Master**

Latar belakang master diwarisi oleh layout dan slide yang tidak menimpanya. Contoh berikut menetapkan warna latar belakang solid untuk slide master pertama:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk topik terkait, lihat [Presentation Background](/slides/id/androidjava/presentation-background/) dan [Presentation Theme](/slides/id/androidjava/presentation-theme/).

## **Klon Slide Master ke Presentasi Lain**

Gunakan [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) untuk menyalin slide master ke presentasi lain. Master yang disalin dapat kemudian dipakai oleh layout dan slide di presentasi tujuan.

```java
import com.aspose.slides.*;

Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Jika Anda perlu mengklon slide normal bersama masternya, lihat [Klon Slide](/slides/id/androidjava/clone-slides/).

## **Tambahkan Beberapa Slide Master**

Sebuah presentasi dapat berisi beberapa slide master. Ini berguna ketika bagian‑bagian berbeda memerlukan branding, struktur halaman, atau pengaturan tema yang berbeda.

![Perintah PowerPoint untuk menyisipkan dan mengelola slide master](slide-master_9.jpg)

Contoh berikut mengklon master default, memberikan latar belakang berbeda pada klonnya, membuat layout di bawah master yang diklon, dan menambahkan slide baru berdasarkan layout tersebut:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bandingkan Slide Master**

Slide master dapat dibandingkan dengan metode `equals` yang diwarisi dari [IBaseSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseslide/). Perbandingan memeriksa struktur dan konten statis, seperti bentuk, teks, pemformatan, animasi, dan pengaturan slide lainnya. Ia tidak membandingkan pengidentifikasi unik, seperti ID slide, atau nilai placeholder dinamis, seperti tanggal saat ini.

```java
import com.aspose.slides.*;

Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Untuk informasi lebih lanjut, lihat [Bandingkan Slide Presentasi](/slides/id/androidjava/compare-slides/).

## **Atur Tampilan Slide Master sebagai Tampilan Default**

Gunakan metode `setLastView` pada [ViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/viewproperties/) untuk mengontrol tampilan yang pertama kali dibuka PowerPoint. Contoh berikut membuka presentasi dalam tampilan Slide Master:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk pengaturan tampilan lainnya, lihat [Simpan Presentasi](/slides/id/androidjava/save-presentation/).

## **Hapus Slide Master yang Tidak Digunakan**

Presentasi kadang‑kadang berisi slide master yang tidak lagi dipakai oleh slide normal mana pun. Menghapus master yang tidak terpakai dapat mengurangi ukuran file dan mempermudah pemeliharaan templat.

Gunakan `removeUnused` untuk menghapus master yang tidak terpakai dari koleksi `getMasters()`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Anda juga dapat menggunakan metode low‑code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apa perbedaan antara slide master dan layout slide?**  
Slide master mendefinisikan pengaturan desain bersama seperti tema, latar belakang, bentuk umum, dan gaya teks. Layout slide termasuk dalam slide master dan mendefinisikan susunan placeholder yang spesifik. Slide normal menggunakan layout slide, sehingga ia mewarisi dari layout dan master.

**Apakah satu presentasi dapat berisi beberapa slide master?**  
Ya. Sebuah presentasi dapat berisi beberapa slide master. Gunakan banyak master ketika bagian‑bagian berbeda memerlukan sistem visual atau branding yang berbeda.

**Haruskah saya menambahkan placeholder ke slide master atau ke layout slide?**  
Dalam kebanyakan kasus, tambahkan placeholder ke layout slide. Letakkan elemen visual bersama dan pemformatan bersama pada slide master, kemudian letakkan placeholder konten pada layout yang akan dipakai slide normal.

**Bisakah saya menghapus slide master yang masih digunakan?**  
Tidak. Slide master yang memiliki slide tergantung tidak dapat dihapus secara langsung. Pindahkan dulu slide‑slide tersebut ke layout di bawah master lain, atau gunakan metode pembersihan master yang tidak terpakai yang hanya menghapus master yang tidak digunakan.