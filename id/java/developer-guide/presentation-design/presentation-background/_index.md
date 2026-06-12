---
title: Kelola Latar Belakang Presentasi di Java
linktitle: Latar Belakang Slide
type: docs
weight: 20
url: /id/java/presentation-background/
keywords:
- latar belakang presentasi
- latar belakang slide
- warna solid
- warna gradien
- latar belakang gambar
- transparansi latar belakang
- properti latar belakang
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara mengatur latar belakang dinamis dalam file PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Java, dengan tip kode untuk meningkatkan presentasi Anda."
---
## **Pendahuluan**

Warna solid, gradien, dan gambar biasanya digunakan sebagai latar belakang slide. Anda dapat mengatur latar belakang untuk **slide normal** (satu slide) atau **slide master** (berlaku untuk beberapa slide sekaligus).

![Latar belakang PowerPoint](powerpoint-background.png)

## **Atur Latar Belakang Warna Solid untuk Slide Normal**

Aspose.Slides memungkinkan Anda mengatur warna solid sebagai latar belakang untuk slide tertentu dalam sebuah presentasi—bahkan jika presentasi tersebut menggunakan slide master. Perubahan ini hanya berlaku pada slide yang dipilih.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
2. Setel slide’s [BackgroundType](https://reference.aspose.com/slides/id/java/com.aspose.slides/backgroundtype/) ke `OwnBackground` .
3. Setel slide background [FillType](https://reference.aspose.com/slides/id/java/com.aspose.slides/filltype/) ke `Solid` .
4. Gunakan metode [getSolidFillColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/fillformat/#getSolidFillColor--) pada [FillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/fillformat/) untuk menentukan warna latar belakang solid .
5. Simpan presentasi yang telah dimodifikasi .

Contoh Java berikut menunjukkan cara mengatur warna solid biru sebagai latar belakang untuk slide normal:

```java
// Buat sebuah instance dari kelas Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Atur warna latar belakang slide menjadi biru.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Simpan presentasi ke disk.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Latar Belakang Warna Solid untuk Slide Master**

Aspose.Slides memungkinkan Anda mengatur warna solid sebagai latar belakang untuk slide master dalam sebuah presentasi. Slide master berfungsi sebagai templat yang mengontrol pemformatan untuk semua slide, jadi ketika Anda memilih warna solid untuk latar belakang slide master, itu berlaku untuk setiap slide.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
2. Setel master slide’s [BackgroundType](https://reference.aspose.com/slides/id/java/com.aspose.slides/backgroundtype/) (melalui `getMasters`) ke `OwnBackground` .
3. Setel master slide background [FillType](https://reference.aspose.com/slides/id/java/com.aspose.slides/filltype/) ke `Solid` .
4. Gunakan metode [getSolidFillColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/fillformat/#getSolidFillColor--) untuk menentukan warna latar belakang solid .
5. Simpan presentasi yang telah dimodifikasi .

Contoh Java berikut menunjukkan cara mengatur warna solid (hijau) sebagai latar belakang untuk slide master:

```java
// Buat sebuah instance dari kelas Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Atur warna latar belakang slide Master menjadi Hijau Hutan.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Simpan presentasi ke disk.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Latar Belakang Gradien untuk Slide**

Gradien adalah efek grafis yang dibuat oleh perubahan warna secara bertahap. Saat digunakan sebagai latar belakang slide, gradien dapat membuat presentasi terlihat lebih artistik dan profesional. Aspose.Slides memungkinkan Anda mengatur warna gradien sebagai latar belakang untuk slide.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
2. Setel slide’s [BackgroundType](https://reference.aspose.com/slides/id/java/com.aspose.slides/backgroundtype/) ke `OwnBackground` .
3. Setel slide background [FillType](https://reference.aspose.com/slides/id/java/com.aspose.slides/filltype/) ke `Gradient` .
4. Gunakan metode [getGradientFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/fillformat/#getGradientFormat--) pada [FillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/fillformat/) untuk mengonfigurasi pengaturan gradien yang Anda inginkan .
5. Simpan presentasi yang telah dimodifikasi .

Contoh Java berikut menunjukkan cara mengatur warna gradien sebagai latar belakang untuk slide:

```java
// Buat sebuah instance dari kelas Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Terapkan efek gradien pada latar belakang.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // Simpan presentasi ke disk.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Gambar sebagai Latar Belakang Slide**

Selain pengisian solid dan gradien, Aspose.Slides memungkinkan Anda menggunakan gambar sebagai latar belakang slide.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
2. Setel slide’s [BackgroundType](https://reference.aspose.com/slides/id/java/com.aspose.slides/backgroundtype/) ke `OwnBackground` .
3. Setel slide background [FillType](https://reference.aspose.com/slides/id/java/com.aspose.slides/filltype/) ke `Picture` .
4. Muat gambar yang ingin Anda gunakan sebagai latar belakang slide .
5. Tambahkan gambar ke koleksi gambar presentasi .
6. Gunakan metode [getPictureFillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/fillformat/#getPictureFillFormat--) pada [FillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/fillformat/) untuk menetapkan gambar sebagai latar belakang .
7. Simpan presentasi yang telah dimodifikasi .

Contoh Java berikut menunjukkan cara mengatur gambar sebagai latar belakang untuk slide:

```java
// Buat sebuah instance dari kelas Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Atur properti gambar latar belakang.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // Muat gambar.
    IImage image = Images.fromFile("Tulips.jpg");
    // Tambahkan gambar ke koleksi gambar presentasi.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Simpan presentasi ke disk.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Contoh kode berikut menunjukkan cara mengatur tipe isian latar belakang menjadi gambar berulang dan memodifikasi properti pengulangan:

```java
Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Atur gambar yang digunakan untuk isian latar belakang.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Atur mode isian gambar menjadi Tile dan sesuaikan properti ubin.
    backPictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15f);
    backPictureFillFormat.setTileOffsetY(15f);
    backPictureFillFormat.setTileScaleX(46f);
    backPictureFillFormat.setTileScaleY(87f);
    backPictureFillFormat.setTileAlignment(RectangleAlignment.Center);
    backPictureFillFormat.setTileFlip(TileFlip.FlipY);

    presentation.save("TileBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Baca selengkapnya: [**Tile Picture As Texture**](/slides/id/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Ubah Transparansi Gambar Latar Belakang**

Anda mungkin ingin menyesuaikan transparansi gambar latar belakang slide agar konten slide lebih menonjol. Kode Java berikut menunjukkan cara mengubah transparansi untuk gambar latar belakang slide:

```java
int transparencyValue = 30; // Sebagai contoh.

// Get the collection of picture transform operations.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Dapatkan Nilai Latar Belakang Slide**

Aspose.Slides menyediakan antarmuka [IBackgroundEffectiveData](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibackgroundeffectivedata/) untuk mengambil nilai latar belakang efektif slide. Antarmuka ini mengekspos [FillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) dan [EffectFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) yang efektif.

Dengan menggunakan metode `getBackground` pada kelas [BaseSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseslide/), Anda dapat memperoleh latar belakang efektif untuk sebuah slide.

Contoh Java berikut menunjukkan cara mendapatkan nilai latar belakang efektif slide:

```java
// Buat sebuah instance dari kelas Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ambil latar belakang efektif, memperhitungkan master, layout, dan tema.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah saya dapat mengatur ulang latar belakang khusus dan mengembalikan latar belakang tema/layout?**

Ya. Hapus isian khusus slide, dan latar belakang akan kembali diwarisi dari slide [layout](/slides/id/java/slide-layout/)/[master](/slides/id/java/slide-master/) yang sesuai (yaitu, [latar belakang tema](/slides/id/java/presentation-theme/)).

**Apa yang terjadi pada latar belakang jika saya mengubah tema presentasi nanti?**

Jika sebuah slide memiliki isian sendiri, maka tidak akan berubah. Jika latar belakang diwarisi dari [layout](/slides/id/java/slide-layout/)/[master](/slides/id/java/slide-master/), maka akan diperbarui agar sesuai dengan [tema baru](/slides/id/java/presentation-theme/).