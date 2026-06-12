---
title: Mengelola Slide Master Presentasi di Java
linktitle: Slide Master
type: docs
weight: 70
url: /id/java/slide-master/
keywords:
- slide master
- master slide
- slide master PPT
- beberapa slide master
- bandingkan slide master
- latar belakang
- placeholder
- gandakan slide master
- salin slide master
- duplikat slide master
- slide master tidak terpakai
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Kelola slide master di Aspose.Slides untuk Java: akses, edit, gandakan, bandingkan, dan hapus slide master dalam presentasi PowerPoint dan OpenDocument."
---
## **Ikhtisar**

Sebuah **slide master** menentukan pengaturan desain bersama untuk sekelompok slide. Ini dapat berisi bentuk umum, logo, latar belakang, gaya teks, pengaturan tema, dan pengaturan footer. Di PowerPoint, mengedit slide master adalah cara biasa untuk menjaga konsistensi presentasi tanpa mengulang pemformatan yang sama pada setiap slide.

Aspose.Slides for Java mendukung model yang sama. Sebuah presentasi dapat berisi satu atau lebih slide master, dan setiap slide master dapat berisi beberapa layout slide. Slide normal biasanya tidak merujuk langsung ke slide master. Sebaliknya, slide normal menggunakan layout slide, dan layout slide tersebut berada di bawah slide master.

Hierarki nya adalah:

1. **Slide master** - menentukan desain dan tema bersama.  
1. **Layout slide** - menentukan susunan khusus placeholder dan pemformatan tingkat layout.  
1. **Slide normal** - berisi konten presentasi sebenarnya dan menggunakan satu layout slide.

![Hierarki slide master, layout slide, dan slide normal](slide-master_2.jpg)

Dalam Aspose.Slides, slide master direpresentasikan oleh antarmuka [IMasterSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslide/). Semua slide master dalam sebuah presentasi tersedia melalui koleksi [Presentation.getMasters](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getMasters--) yang mengimplementasikan [IMasterSlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Ketika properti yang sama didefinisikan pada lebih dari satu tingkat, tingkat yang lebih spesifik yang menang. Misalnya, jika slide master dan layout slide keduanya mendefinisikan latar belakang, slide yang berbasis pada layout tersebut akan menggunakan latar belakang layout. Untuk informasi lebih lanjut tentang layout slide, lihat [Terapkan atau Ubah Layout Slide](/slides/id/java/slide-layout/).
{{% /alert %}}

## **Akses Slide Master**

Di PowerPoint, Anda dapat membuka tampilan Slide Master melalui **View** > **Slide Master**.

![Perintah Slide Master pada tab View di PowerPoint](slide-master_3.jpg)

Di Aspose.Slides, gunakan koleksi `getMasters()` untuk mengakses slide master:

```java
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

Anda juga dapat memperoleh slide master yang digunakan oleh slide normal melalui layoutnya:

```java
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

## **Isi Slide Master**

Slide master adalah objek mirip slide. Ia mengimplementasikan [IBaseSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibaseslide/), sehingga mengekspos banyak properti slide yang sama digunakan oleh slide normal dan layout. Anggota khusus master tercantum pada halaman API [IMasterSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslide/).

Anggota slide master yang umum digunakan meliputi:

| Anggota | Tujuan |
| --- | --- |
| `getBackground()` | Menetapkan latar belakang slide tingkat master. |
| `getShapes()` | Menyimpan bentuk yang ditempatkan pada master, seperti logo, bingkai gambar, dan teks bersama. |
| `getLayoutSlides()` | Menyimpan layout slide yang termasuk dalam master. |
| `getThemeManager()` | Memberikan akses ke API tema master. |
| `getHeaderFooterManager()` | Mengontrol header, footer, tanggal, dan nomor slide untuk master dan layout anaknya. |
| `getDependingSlides()` | Mengembalikan slide normal yang bergantung pada master melalui layout mereka. |

## **Menambahkan Gambar ke Slide Master**

Saat Anda menambahkan gambar ke slide master, gambar tersebut muncul pada slide yang menggunakan layout dari master tersebut. Ini berguna untuk logo, watermark, pita dekoratif, dan elemen visual berulang lainnya.

Contoh berikut menambahkan logo ke slide master pertama:

```java
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

## **Bekerja dengan Placeholder**

Placeholder biasanya didefinisikan pada layout slide. Slide master menyediakan gaya dan tema bersama yang diwarisi oleh layout tersebut, sementara setiap layout memutuskan placeholder mana yang tersedia dan dimana mereka ditempatkan.

Di PowerPoint, perintah placeholder tersedia dalam tampilan Slide Master.

![Perintah Insert Placeholder di tampilan Slide Master PowerPoint](slide-master_5.png)

Untuk menambahkan placeholder baru dengan Aspose.Slides, kerja pada layout slide yang berada di bawah master:

```java
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

Anda juga dapat memformat shape placeholder yang sudah ada pada slide master. Contoh berikut menemukan placeholder judul dan menerapkan isian gradien linear:

```java
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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Placeholder judul yang diformat dan diwarisi oleh slide normal](slide-master_8.png)

Untuk opsi pemformatan placeholder dan teks lebih lanjut, lihat [Atur Teks Prompt dalam Placeholder](/slides/id/java/manage-placeholder/) dan [Pemformatan Teks](/slides/id/java/text-formatting/).

## **Ubah Latar Belakang Slide Master**

Latar belakang master diwarisi oleh layout dan slide yang tidak menimpanya. Contoh berikut menetapkan warna latar belakang solid untuk slide master pertama:

```java
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

## **Menggandakan Slide Master ke Presentasi Lain**

Gunakan [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) untuk menyalin slide master ke presentasi lain. Master yang disalin kemudian dapat digunakan oleh layout dan slide di presentasi tujuan.

```java
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

Jika Anda perlu menggandakan slide normal bersama masternya, lihat [Gandakan Slide](/slides/id/java/clone-slides/).

## **Menambahkan Beberapa Slide Master**

Sebuah presentasi dapat berisi beberapa slide master. Ini berguna ketika bagian berbeda memerlukan branding, struktur halaman, atau pengaturan tema yang berbeda.

![Perintah PowerPoint untuk menyisipkan dan mengelola slide master](slide-master_9.jpg)

Contoh berikut menggandakan master default, memberi klon latar belakang yang berbeda, membuat layout di bawah master yang digandakan, dan menambahkan slide baru berdasarkan layout tersebut:

```java
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

Slide master dapat dibandingkan dengan metode `equals` yang diwarisi dari [IBaseSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibaseslide/). Perbandingan memeriksa struktur dan konten statis, seperti shape, teks, pemformatan, animasi, dan pengaturan slide lainnya. Ia tidak membandingkan pengidentifikasi unik, seperti ID slide, atau nilai placeholder dinamis, seperti tanggal saat ini.

```java
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

Untuk informasi lebih lanjut, lihat [Bandingkan Slide Presentasi](/slides/id/java/compare-slides/).

## **Menetapkan Tampilan Slide Master sebagai Tampilan Default**

Gunakan metode `setLastView` pada [ViewProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/viewproperties/) untuk mengontrol tampilan yang dibuka pertama kali oleh PowerPoint. Contoh berikut membuka presentasi dalam tampilan Slide Master:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk pengaturan tampilan lebih lanjut, lihat [Simpan Presentasi](/slides/id/java/save-presentation/).

## **Menghapus Slide Master yang Tidak Digunakan**

Presentasi kadang berisi slide master yang tidak lagi dipakai oleh slide normal mana pun. Menghapus master yang tidak digunakan dapat mengurangi ukuran file dan menyederhanakan pemeliharaan templat.

Gunakan `removeUnused` untuk menghapus master yang tidak dipakai dari koleksi `getMasters()`:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Anda juga dapat menggunakan metode low-code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
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

Slide master menentukan pengaturan desain bersama seperti tema, latar belakang, bentuk umum, dan gaya teks. Layout slide berada di bawah slide master dan menentukan susunan khusus placeholder. Slide normal menggunakan layout slide, sehingga ia mewarisi dari layout dan master.

**Apakah satu presentasi dapat berisi beberapa slide master?**

Ya. Sebuah presentasi dapat berisi beberapa slide master. Gunakan banyak master ketika bagian yang berbeda membutuhkan sistem visual atau branding yang berbeda.

**Haruskah saya menambahkan placeholder ke slide master atau layout slide?**

Dalam kebanyakan kasus, tambahkan placeholder ke layout slide. Letakkan elemen visual bersama dan pemformatan bersama pada slide master, kemudian letakkan placeholder konten pada layout yang akan dipakai slide normal.

**Dapatkah saya menghapus slide master yang masih digunakan?**

Tidak. Slide master yang memiliki slide tergantung tidak dapat dihapus secara langsung dengan aman. Pindahkan slide tersebut ke layout di bawah master lain, atau gunakan metode pembersihan master yang tidak terpakai yang hanya menghapus master yang tidak digunakan.