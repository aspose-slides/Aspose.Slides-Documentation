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
- warna gradasi
- latar belakang gambar
- transparansi latar belakang
- properti latar belakang
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara menetapkan latar belakang dinamis dalam file PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Java, dengan tips kode untuk meningkatkan presentasi Anda."
---
## **Pendahuluan**

Warna solid, gradasi, dan gambar biasanya digunakan sebagai latar belakang slide. Anda dapat mengatur latar belakang untuk **slide normal** (satu slide) atau **slide master** (menerapkan ke banyak slide sekaligus).

![Latar belakang PowerPoint](powerpoint-background.png)

## **Mengatur Latar Belakang Warna Solid untuk Slide Normal**

Aspose.Slides memungkinkan Anda mengatur warna solid sebagai latar belakang untuk slide tertentu dalam presentasi—meskipun presentasi menggunakan slide master. Perubahan ini hanya berlaku pada slide yang dipilih.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
2. Setel [BackgroundType](https://reference.aspose.com/slides/id/java/com.aspose.slides/backgroundtype/) slide ke `OwnBackground` .
3. Setel latar belakang slide [FillType](https://reference.aspose.com/slides/id/java/com.aspose.slides/filltype/) ke `Solid` .
4. Gunakan metode [getSolidFillColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/fillformat/#getSolidFillColor--) pada [FillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/fillformat/) untuk menentukan warna latar belakang solid .
5. Simpan presentasi yang telah dimodifikasi .

Contoh Java berikut menunjukkan cara mengatur warna solid biru sebagai latar belakang untuk slide normal:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Mengatur Latar Belakang Warna Solid untuk Slide Master**

Aspose.Slides memungkinkan Anda mengatur warna solid sebagai latar belakang untuk slide master dalam presentasi. Slide master berfungsi sebagai templat yang mengontrol pemformatan untuk semua slide, sehingga ketika Anda memilih warna solid untuk latar belakang slide master, warna tersebut diterapkan pada setiap slide.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
2. Setel [BackgroundType](https://reference.aspose.com/slides/id/java/com.aspose.slides/backgroundtype/) slide master (melalui `getMasters`) ke `OwnBackground` .
3. Setel latar belakang slide master [FillType](https://reference.aspose.com/slides/id/java/com.aspose.slides/filltype/) ke `Solid` .
4. Gunakan metode [getSolidFillColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/fillformat/#getSolidFillColor--) untuk menentukan warna latar belakang solid .
5. Simpan presentasi yang telah dimodifikasi .

Contoh Java berikut menunjukkan cara mengatur warna solid (hijau) sebagai latar belakang untuk slide master:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Buat sebuah instance dari kelas Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Atur warna latar belakang master slide menjadi hijau.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Simpan presentasi ke disk.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengatur Latar Belakang Gradasi untuk Slide**

Gradasi adalah efek grafis yang dibuat oleh perubahan warna secara bertahap. Ketika digunakan sebagai latar belakang slide, gradasi dapat membuat presentasi terlihat lebih artistik dan profesional. Aspose.Slides memungkinkan Anda mengatur warna gradasi sebagai latar belakang untuk slide.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
2. Setel [BackgroundType](https://reference.aspose.com/slides/id/java/com.aspose.slides/backgroundtype/) slide ke `OwnBackground` .
3. Setel latar belakang slide [FillType](https://reference.aspose.com/slides/id/java/com.aspose.slides/filltype/) ke `Gradient` .
4. Gunakan metode [getGradientFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/fillformat/#getGradientFormat--) pada [FillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/fillformat/) untuk mengkonfigurasi pengaturan gradasi yang Anda inginkan .
5. Simpan presentasi yang telah dimodifikasi .

Contoh Java berikut menunjukkan cara mengatur warna gradasi sebagai latar belakang untuk slide:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Buat sebuah instance dari kelas Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Terapkan efek gradasi pada latar belakang.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // Tambahkan warna gradasi. Tanpa titik henti gradasi, latar belakang akan kembali ke ramp hitam-ke-putih default.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Simpan presentasi ke disk.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengatur Gambar sebagai Latar Belakang Slide**

Selain isian solid dan gradasi, Aspose.Slides memungkinkan Anda menggunakan gambar sebagai latar belakang slide.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
2. Setel [BackgroundType](https://reference.aspose.com/slides/id/java/com.aspose.slides/backgroundtype/) slide ke `OwnBackground` .
3. Setel latar belakang slide [FillType](https://reference.aspose.com/slides/id/java/com.aspose.slides/filltype/) ke `Picture` .
4. Muat gambar yang ingin Anda gunakan sebagai latar belakang slide .
5. Tambahkan gambar ke koleksi gambar presentasi .
6. Gunakan metode [getPictureFillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/fillformat/#getPictureFillFormat--) pada [FillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/fillformat/) untuk menetapkan gambar sebagai latar belakang .
7. Simpan presentasi yang telah dimodifikasi .

Contoh Java berikut menunjukkan cara mengatur gambar sebagai latar belakang untuk slide:

```java
import com.aspose.slides.*;

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

Contoh kode berikut menunjukkan cara mengatur tipe isian latar belakang menjadi gambar ubin dan mengubah properti ubin:

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
Baca selengkapnya: [**Tile Picture As Texture**](/slides/id/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Ubah Transparansi Gambar Latar Belakang**

Anda mungkin ingin menyesuaikan transparansi gambar latar belakang slide agar isi slide lebih menonjol. Kode Java berikut menunjukkan cara mengubah transparansi untuk gambar latar belakang slide:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Sebagai contoh.

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dapatkan koleksi operasi transformasi gambar.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // Temukan efek transparansi persentase tetap yang ada.
    IAlphaModulateFixed transparencyOperation = null;
    for (IImageTransformOperation operation : imageTransform) {
        if (operation instanceof IAlphaModulateFixed) {
            transparencyOperation = (IAlphaModulateFixed)operation;
            break;
        }
    }

    // Setel nilai transparansi baru.
    if (transparencyOperation == null) {
        imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else {
        transparencyOperation.setAmount(100 - transparencyValue);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dapatkan Nilai Latar Belakang Slide**

Aspose.Slides menyediakan antarmuka [IBackgroundEffectiveData](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibackgroundeffectivedata/) untuk mengambil nilai latar belakang efektif slide. Antarmuka ini memberikan akses ke [FillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) dan [EffectFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) yang efektif.

Dengan menggunakan metode `getBackground` pada kelas [BaseSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseslide/), Anda dapat memperoleh latar belakang efektif untuk sebuah slide.

Contoh Java berikut menunjukkan cara mendapatkan nilai latar belakang efektif slide:

```java
import com.aspose.slides.*;

// Buat sebuah instance dari kelas Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dapatkan latar belakang efektif, memperhitungkan master, layout, dan tema.
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

### Bisakah saya mengatur ulang latar belakang khusus dan mengembalikan latar belakang tema/layout?

Ya. Hapus isian khusus slide, dan latar belakang akan diwarisi kembali dari slide [layout](/slides/id/java/slide-layout/)/[master](/slides/id/java/slide-master/) yang bersangkutan (yaitu [tema latar belakang](/slides/id/java/presentation-theme/)).

### Apa yang terjadi pada latar belakang jika saya mengubah tema presentasi nanti?

Jika sebuah slide memiliki isian sendiri, isian tersebut akan tetap tidak berubah. Jika latar belakang diwarisi dari [layout](/slides/id/java/slide-layout/)/[master](/slides/id/java/slide-master/), latar belakang akan diperbarui agar sesuai dengan [tema baru](/slides/id/java/presentation-theme/).