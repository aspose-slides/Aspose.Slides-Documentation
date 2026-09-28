---
title: Kelola Slide Master Presentasi di Java
linktitle: Slide Master
type: docs
weight: 70
url: /id/java/slide-master/
keywords:
- master slide
- master slide
- master slide PPT
- banyak master slide
- bandingkan master slide
- latar belakang
- placeholder
- kloning master slide
- salin master slide
- duplikasi master slide
- master slide tidak terpakai
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Kelola master slide di Aspose.Slides untuk Java: akses, edit, kloning, bandingkan, dan hapus master slide dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Sebuah **slide master** mendefinisikan pengaturan desain bersama untuk sekelompok slide. Itu dapat berisi bentuk umum, logo, latar belakang, gaya teks, pengaturan tema, dan pengaturan footer. Di PowerPoint, mengedit slide master adalah cara biasanya untuk menjaga konsistensi presentasi tanpa mengulang format yang sama pada setiap slide.

Aspose.Slides untuk Java mendukung model yang sama. Sebuah presentasi dapat berisi satu atau lebih slide master, dan setiap slide master dapat berisi beberapa layout slide. Slide normal biasanya tidak merujuk langsung ke slide master. Sebaliknya, slide normal menggunakan layout slide, dan layout slide tersebut milik sebuah slide master.

Hierarki tersebut adalah:

1. **Slide master** – mendefinisikan desain dan tema bersama.
1. **Layout slide** – mendefinisikan susunan khusus placeholder dan pemformatan tingkat layout.
1. **Normal slide** – berisi konten presentasi aktual dan menggunakan satu layout slide.

![Hierarki slide master, layout slide, dan normal slide](slide-master_2.jpg)

Di Aspose.Slides, sebuah slide master direpresentasikan oleh antarmuka [IMasterSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslide/). Semua slide master dalam sebuah presentasi tersedia melalui koleksi [Presentation.getMasters](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getMasters--) yang mengimplementasikan [IMasterSlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}

Ketika properti yang sama didefinisikan pada lebih dari satu tingkat, tingkat yang lebih spesifik yang menang. Misalnya, jika slide master dan layout slide keduanya mendefinisikan latar belakang, slide yang berbasis pada layout tersebut menggunakan latar belakang layout. Untuk informasi lebih lanjut tentang layout slide, lihat [Terapkan atau Ubah Tata Letak Slide](/slides/id/java/slide-layout/).

{{% /alert %}}

## **Mengakses Slide Master**

Di PowerPoint, Anda dapat membuka tampilan Slide Master melalui **View** > **Slide Master**.

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

Anda juga dapat memperoleh slide master yang digunakan oleh slide normal melalui layout-nya:

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

Slide master adalah objek mirip slide. Ia mengimplementasikan [IBaseSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibaseslide/), sehingga menampilkan banyak properti slide yang sama yang digunakan oleh slide normal dan layout. Anggota khusus master tercantum pada halaman API [IMasterSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslide/).

Anggota slide master yang umum digunakan meliputi:

| Anggota | Tujuan |
| --- | --- |
| `getBackground()` | Mengatur latar belakang slide tingkat master. |
| `getShapes()` | Menyimpan bentuk yang ditempatkan pada master, seperti logo, bingkai gambar, dan teks bersama. |
| `getLayoutSlides()` | Menyimpan layout slide yang menjadi milik master. |
| `getThemeManager()` | Menyediakan akses ke API tema master. |
| `getHeaderFooterManager()` | Mengontrol header, footer, tanggal, dan nomor slide untuk master dan layout turunannya. |
| `getDependingSlides()` | Mengembalikan slide normal yang bergantung pada master melalui layout mereka. |

## **Menambahkan Gambar ke Slide Master**

Ketika Anda menambahkan gambar ke slide master, gambar tersebut muncul pada slide yang menggunakan layout dari master itu. Fitur ini berguna untuk logo, watermark, pita dekoratif, dan elemen visual berulang lainnya.

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

Untuk informasi lebih lanjut tentang bingkai gambar, lihat [Bingkai Gambar](/slides/id/java/picture-frame/).

## **Mengontrol Visibilitas Grafik Master**

Gunakan [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) untuk menyembunyikan grafik master yang diwariskan, seperti logo atau bentuk dekoratif, tanpa menghapusnya dari master. Berikan `false` ke [Slide.setShowMasterShapes](https://reference.aspose.com/slides/id/java/com.aspose.slides/slide/#setShowMasterShapes-boolean-) pada slide yang harus menghilangkan grafik tersebut dan pertahankan `true` pada slide yang harus menampilkannya.

Contoh mandiri berikut membuat pita dekoratif berwarna biru pada master dan dua slide yang menggunakan layout kosong yang sama. Pita tersebut terlihat pada slide pertama dan disembunyikan pada slide kedua. Tidak diperlukan presentasi atau gambar masukan.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    Color bandColor = new Color(70, 130, 180);
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

Contoh ini menggunakan layout **Blank** yang disertakan dengan presentasi baru dan menghapus placeholder slide awalnya.

### **Pilih Lingkup Pengaturan**

Slide normal menggunakan master-nya melalui [ISlide.getLayoutSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/islide/#getLayoutSlide--) dan [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutslide/#getMasterSlide--). Menetapkan properti pada slide individual hanya memengaruhi slide tersebut. Memberikan `false` ke [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/id/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) menyembunyikan grafik master untuk slide yang menggunakan layout bersama itu, bahkan jika pengaturannya `true`. Untuk menyembunyikan grafik hanya pada satu slide, ubah properti slide dan biarkan layout bersama tidak berubah.

Pengaturan ini tidak didukung sebagai kontrol visibilitas pada slide master itu sendiri. Pada master, [getShowMasterShapes](https://reference.aspose.com/slides/id/java/com.aspose.slides/masterslide/#getShowMasterShapes--) selalu mengembalikan `false`, dan memberikan `true` ke [setShowMasterShapes](https://reference.aspose.com/slides/id/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) akan memunculkan pengecualian. Terapkan pada slide normal atau layout saja.

### **Membedakan Grafik dari Latar Belakang**

| Operasi | Efek |
| --- | --- |
| Sembunyikan grafik master | Mengontrol visibilitas bentuk master yang diwariskan tanpa menghapusnya atau mengubah bentuk slide itu sendiri. |
| Ubah isian latar belakang slide | Mengubah warna, gradien, atau gambar latar belakang. Grafik master adalah bentuk terpisah dan dapat tetap terlihat di atas latar tersebut. Lihat [Latar Belakang Presentasi](/slides/id/java/presentation-background/). |
| Hapus bentuk dari master | Menghapus bentuk sumber bersama, sehingga tidak lagi tersedia untuk slide mana pun yang menggunakan master tersebut. |

## **Bekerja dengan Placeholder**

Placeholder biasanya didefinisikan pada layout slide. Slide master menyediakan gaya dan tema bersama yang diwarisi oleh layout tersebut, sementara setiap layout memutuskan placeholder mana yang tersedia dan di mana penempatannya.

Di PowerPoint, perintah placeholder tersedia dalam tampilan Slide Master.

![Perintah Insert Placeholder pada tampilan Slide Master di PowerPoint](slide-master_5.png)

Untuk menambahkan placeholder baru dengan Aspose.Slides, kerja dengan layout slide yang menjadi milik master:

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

![Placeholder judul yang diformat dan diwariskan oleh slide normal](slide-master_8.png)

Untuk opsi placeholder dan pemformatan teks lebih lanjut, lihat [Set Prompt Text in Placeholder](/slides/id/java/manage-placeholder/) dan [Text Formatting](/slides/id/java/text-formatting/).

## **Mengubah Latar Belakang Slide Master**

Latar belakang master diwariskan oleh layout dan slide yang tidak menimpanya. Contoh berikut mengatur warna latar belakang solid untuk slide master pertama:

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

Untuk topik terkait, lihat [Latar Belakang Presentasi](/slides/id/java/presentation-background/) dan [Tema Presentasi](/slides/id/java/presentation-theme/).

## **Mengkloning Slide Master ke Presentasi Lain**

Gunakan [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) untuk menyalin slide master ke presentasi lain. Master yang disalin kemudian dapat digunakan oleh layout dan slide di presentasi tujuan.

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

Jika Anda perlu mengkloning slide normal bersamaan dengan master-nya, lihat [Clone Slides](/slides/id/java/clone-slides/).

## **Menambahkan Beberapa Slide Master**

Sebuah presentasi dapat berisi beberapa slide master. Ini berguna ketika bagian berbeda memerlukan branding, struktur halaman, atau pengaturan tema yang berbeda.

![Perintah PowerPoint untuk menyisipkan dan mengelola slide master](slide-master_9.jpg)

Contoh berikut mengkloning master default, memberi klon latar belakang berbeda, membuat layout di bawah master yang diklon, dan menambahkan slide baru berdasarkan layout tersebut:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

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

## **Membandingkan Slide Master**

Slide master dapat dibandingkan dengan metode `equals` yang diwarisi dari [IBaseSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibaseslide/). Perbandingan memeriksa struktur dan konten statis, seperti bentuk, teks, pemformatan, animasi, dan pengaturan slide lainnya. Ia tidak membandingkan pengenal unik, seperti ID slide, atau nilai placeholder dinamis, seperti tanggal saat ini.

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

Untuk informasi lebih lanjut, lihat [Compare Presentation Slides](/slides/id/java/compare-slides/).

## **Menetapkan Tampilan Slide Master sebagai Tampilan Default**

Gunakan metode `setLastView` pada [ViewProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/viewproperties/) untuk mengontrol tampilan yang pertama kali dibuka PowerPoint. Contoh berikut membuka presentasi dalam tampilan Slide Master:

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

Untuk pengaturan tampilan lainnya, lihat [Save Presentation](/slides/id/java/save-presentation/).

## **Menghapus Slide Master yang Tidak Digunakan**

Presentasi kadang berisi slide master yang tidak lagi dipakai oleh slide normal mana pun. Menghapus master yang tidak digunakan dapat mengurangi ukuran file dan menyederhanakan pemeliharaan templat.

Gunakan `removeUnused` untuk menghapus master yang tidak digunakan dari koleksi `getMasters()`:

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

Anda juga dapat menggunakan metode low‑code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

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

Slide master mendefinisikan pengaturan desain bersama seperti tema, latar belakang, bentuk umum, dan gaya teks. Layout slide merupakan bagian dari slide master dan mendefinisikan susunan khusus placeholder. Slide normal menggunakan layout slide, sehingga ia mewarisi dari layout serta master.

**Apakah satu presentasi dapat berisi beberapa slide master?**

Ya. Sebuah presentasi dapat memiliki beberapa slide master. Gunakan beberapa master ketika bagian berbeda memerlukan sistem visual atau branding yang berbeda.

**Haruskah saya menambahkan placeholder ke slide master atau ke layout slide?**

Dalam kebanyakan kasus, tambahkan placeholder ke layout slide. Letakkan elemen visual bersama dan pemformatan bersama pada slide master, kemudian tempatkan placeholder konten pada layout yang akan digunakan oleh slide normal.

**Dapatkah saya menghapus slide master yang masih digunakan?**

Tidak. Slide master yang memiliki slide tergantung tidak dapat dihapus secara langsung dengan aman. Pindahkan slide tersebut ke layout di bawah master lain terlebih dahulu, atau gunakan metode pembersihan master yang tidak terpakai yang hanya menghapus master yang tidak digunakan.