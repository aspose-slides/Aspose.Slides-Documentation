---
title: Kelola Master Slide Presentasi di Android
linktitle: Master Slide
type: docs
weight: 70
url: /id/androidjava/slide-master/
keywords:
- master slide
- master slide
- master slide PPT
- banyak master slide
- bandingkan master slide
- latar belakang
- placeholder
- gandakan master slide
- salin master slide
- duplikat master slide
- master slide tidak terpakai
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kelola master slide di Aspose.Slides untuk Android via Java: mengakses, mengedit, menggandakan, membandingkan, dan menghapus master slide dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Sebuah **master slide** mendefinisikan pengaturan desain bersama untuk sekumpulan slide. Ia dapat berisi bentuk umum, logo, latar belakang, gaya teks, pengaturan tema, dan pengaturan footer. Di PowerPoint, mengedit master slide merupakan cara biasa untuk menjaga konsistensi presentasi tanpa harus mengulangi pemformatan yang sama pada setiap slide.

Aspose.Slides for Android via Java mendukung model yang sama. Sebuah presentasi dapat berisi satu atau lebih master slide, dan setiap master slide dapat berisi beberapa layout slide. Slide normal biasanya tidak merujuk langsung ke master slide. Sebagai gantinya, slide normal menggunakan layout slide, dan layout slide tersebut milik sebuah master slide.

Hierarki tersebut adalah:

1. **Master slide** – mendefinisikan desain dan tema bersama.  
1. **Slide tata letak** – mendefinisikan susunan placeholder tertentu dan pemformatan level tata letak.  
1. **Slide normal** – berisi konten presentasi aktual dan menggunakan satu slide tata letak.

![Hierarki master slide, slide tata letak, dan slide normal](slide-master_2.jpg)

Di Aspose.Slides, master slide direpresentasikan oleh antarmuka [IMasterSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslide/). Semua master slide dalam sebuah presentasi tersedia melalui koleksi [Presentation.getMasters](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getMasters--) yang mengimplementasikan [IMasterSlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslidecollection/). Untuk seluruh permukaan API Android via Java, lihat referensi API [com.aspose.slides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}
Ketika properti yang sama didefinisikan pada lebih dari satu tingkat, tingkat yang lebih spesifik yang akan dipakai. Misalnya, jika sebuah master slide dan sebuah slide tata letak keduanya mendefinisikan latar belakang, slide yang berbasis tata letak tersebut akan menggunakan latar belakang tata letak. Untuk informasi lebih lanjut tentang slide tata letak, lihat [Apply or Change Slide Layouts](/slides/id/androidjava/slide-layout/).
{{% /alert %}}

## **Akses Master Slide**

Di PowerPoint, Anda dapat membuka tampilan Master Slide lewat **View** > **Slide Master**.

![Perintah Slide Master pada tab View di PowerPoint](slide-master_3.jpg)

Di Aspose.Slides, gunakan koleksi `getMasters()` untuk mengakses master slide:

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

Anda juga dapat memperoleh master slide yang digunakan oleh slide normal melalui tata letaknya:

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

## **Apa yang Dimiliki oleh Master Slide**

Sebuah master slide adalah objek mirip slide. Ia mengimplementasikan [IBaseSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseslide/), sehingga mengekspos banyak properti slide yang sama yang digunakan oleh slide normal dan slide tata letak.

Anggota master slide yang sering digunakan meliputi:

| Anggota | Tujuan |
| --- | --- |
| `getBackground()` | Menetapkan latar belakang slide pada level master. |
| `getShapes()` | Menyimpan bentuk‑bentuk yang ditempatkan pada master, seperti logo, bingkai gambar, dan teks bersama. |
| `getLayoutSlides()` | Menyimpan slide tata letak yang termasuk dalam master. |
| `getThemeManager()` | Menyediakan akses ke API tema master. |
| `getHeaderFooterManager()` | Mengontrol header, footer, tanggal, dan nomor slide untuk master dan tata letak turunannya. |
| `getDependingSlides()` | Mengembalikan slide normal yang bergantung pada master melalui tata letaknya. |

## **Menambahkan Gambar ke Master Slide**

Saat Anda menambahkan gambar ke master slide, gambar tersebut muncul pada slide yang menggunakan tata letak dari master itu. Ini berguna untuk logo, watermark, pita dekoratif, dan elemen visual berulang lainnya.

Contoh berikut menambahkan logo ke master slide pertama:

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

Untuk informasi lebih lanjut tentang bingkai gambar, lihat [Picture Frame](/slides/id/androidjava/picture-frame/).

## **Bekerja dengan Placeholder**

Placeholder biasanya didefinisikan pada slide tata letak. Master slide menyediakan gaya dan tema bersama yang diwarisi oleh tata letak tersebut, sementara masing‑masing tata letak menentukan placeholder apa yang tersedia dan di mana letaknya.

Di PowerPoint, perintah placeholder tersedia di tampilan Master Slide.

![Perintah Insert Placeholder di tampilan Master Slide PowerPoint](slide-master_5.png)

Untuk menambahkan placeholder baru dengan Aspose.Slides, kerjakan slide tata letak yang termasuk dalam master:

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

Anda juga dapat memformat bentuk placeholder yang sudah ada pada master slide. Contoh berikut menemukan placeholder judul dan menerapkan isian gradien linier:

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
        int redGradientColor = Color.valueOf(255, 0, 0).toArgb();
        int purpleGradientColor = Color.valueOf(128, 0, 128).toArgb();

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

![Placeholder judul yang diformat, diwarisi oleh slide normal](slide-master_8.png)

Untuk opsi pemformatan placeholder dan teks lebih lanjut, lihat [Set Prompt Text in Placeholder](/slides/id/androidjava/manage-placeholder/) dan [Text Formatting](/slides/id/androidjava/text-formatting/).

## **Mengubah Latar Belakang Master Slide**

Latar belakang master diwarisi oleh tata letak dan slide yang tidak menimpanya. Contoh berikut menetapkan warna latar belakang padat untuk master slide pertama:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    int masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk topik terkait, lihat [Presentation Background](/slides/id/androidjava/presentation-background/) dan [Presentation Theme](/slides/id/androidjava/presentation-theme/).

## **Menggandakan Master Slide ke Presentasi Lain**

Gunakan [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) untuk menyalin master slide ke presentasi lain. Master yang disalin kemudian dapat dipakai oleh tata letak dan slide di presentasi tujuan.

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

Jika Anda perlu menggandakan slide normal bersama masternya, lihat [Clone Slides](/slides/id/androidjava/clone-slides/).

## **Menambahkan Beberapa Master Slide**

Sebuah presentasi dapat berisi banyak master slide. Ini berguna ketika bagian‑bagian berbeda memerlukan branding, struktur halaman, atau pengaturan tema yang berbeda.

![Perintah PowerPoint untuk menyisipkan dan mengelola master slide](slide-master_9.jpg)

Contoh berikut menggandakan master default, memberi clone latar belakang yang berbeda, membuat tata letak di bawah master yang digandakan, dan menambahkan slide baru berdasarkan tata letak tersebut:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    int sectionMasterBackgroundColor = Color.GRAY;

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

## **Membandingkan Master Slide**

Master slide dapat dibandingkan dengan metode `equals` yang diwarisi dari [IBaseSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseslide/). Perbandingan memeriksa struktur dan konten statis, seperti bentuk, teks, pemformatan, animasi, dan pengaturan slide lainnya. Ia tidak membandingkan pengenal unik, seperti ID slide, atau nilai placeholder dinamis, seperti tanggal saat ini.

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

Untuk informasi lebih lanjut, lihat [Compare Presentation Slides](/slides/id/androidjava/compare-slides/).

## **Menetapkan Tampilan Master Slide sebagai Tampilan Default**

Gunakan metode `setLastView` pada [ViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/viewproperties/) untuk mengontrol tampilan yang pertama kali dibuka PowerPoint. Contoh berikut membuka presentasi dalam tampilan Master Slide:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk pengaturan tampilan lainnya, lihat [Save Presentation](/slides/id/androidjava/save-presentation/).

## **Menghapus Master Slide yang Tidak Digunakan**

Presentasi kadang‑kadang berisi master slide yang tidak lagi dipakai oleh slide normal mana pun. Menghapus master yang tidak digunakan dapat mengurangi ukuran file dan menyederhanakan pemeliharaan templat.

Gunakan `removeUnused` untuk menghapus master yang tidak digunakan dari koleksi `getMasters()`:

```java
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
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apa perbedaan antara master slide dan slide tata letak?**

Master slide mendefinisikan pengaturan desain bersama seperti tema, latar belakang, bentuk umum, dan gaya teks. Slide tata letak termasuk dalam master slide dan mendefinisikan susunan placeholder tertentu. Slide normal menggunakan slide tata letak, sehingga ia mewarisi dari tata letak serta master.

**Apakah satu presentasi dapat berisi beberapa master slide?**

Ya. Sebuah presentasi dapat berisi beberapa master slide. Gunakan banyak master ketika bagian‑bagian berbeda memerlukan sistem visual atau branding yang berbeda.

**Haruskah saya menambahkan placeholder ke master slide atau ke slide tata letak?**

Dalam kebanyakan kasus, tambahkan placeholder ke slide tata letak. Letakkan elemen visual bersama dan pemformatan bersama pada master slide, kemudian letakkan placeholder konten pada tata letak yang akan dipakai slide normal.

**Bisakah saya menghapus master slide yang masih digunakan?**

Tidak. Master slide yang memiliki slide turunan tidak dapat dihapus secara langsung dengan aman. Pindahkan terlebih dahulu slide‑slide tersebut ke tata letak di bawah master lain, atau gunakan metode pembersihan master yang tidak terpakai yang hanya menghapus master yang tidak digunakan.