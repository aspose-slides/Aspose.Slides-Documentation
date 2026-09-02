---
title: Kelola Efek Transformasi Gambar dalam Presentasi dengan Java
linktitle: Efek Transformasi Gambar
type: docs
weight: 11
url: /id/java/image-transform-effects/
keywords:
- transformasi gambar
- efek gambar
- kecerahan
- kontras
- skala abu-abu
- duotone
- teburan warna
- HSL
- penggantian warna
- blur
- transparansi
- efek alfa
- rantai efek
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Terapkan, rangkai, periksa, hapus, dan verifikasi efek transformasi gambar untuk bingkai gambar dengan Aspose.Slides untuk Java."
---
## **Ikhtisar**

Aspose.Slides merepresentasikan penyesuaian gambar sebagai koleksi terurut dari operasi transformasi gambar. Untuk sebuah bingkai gambar, mulailah dengan [ISlidesPicture](https://reference.aspose.com/slides/id/java/com.aspose.slides/islidespicture/) bingkai dan akses [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/id/java/com.aspose.slides/islidespicture/#getImageTransform--). [IImageTransformOperationCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/) yang dikembalikan memungkinkan Anda menambahkan, mengenumerasi, memeriksa, menghapus, dan membersihkan efek tanpa menulis ulang byte gambar asli.

Artikel ini mendemonstrasikan alur kerja lengkap untuk kecerahan dan kontras, transformasi warna, blur, transparansi, rantai efek berurutan, nilai efektif, penghapusan, dan verifikasi putar‑balik PPTX.

## **Memahami Kepemilikan Efek dan Penggunaan Ulang Gambar**

Sebuah sumber gambar dan gambar yang menampilkannya adalah objek yang berbeda:

- [IPPImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ippimage/) menyimpan atau merujuk data gambar sumber yang dimiliki oleh presentasi.
- [ISlidesPicture](https://reference.aspose.com/slides/id/java/com.aspose.slides/islidespicture/) termasuk dalam isian gambar dan merujuk ke sumber gambar sambil menyimpan koleksi transformasi gambar.
- [IPictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipictureframe/) adalah bentuk slide yang memiliki isian gambar relevan, geometri, pengaturan pemotongan, dan format level bingkai lainnya.

Karena itu, operasi transformasi gambar tidak mengubah byte dalam [IPPImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ippimage/). Ketika `IPPImage` yang sama diteruskan ke [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) lebih dari satu kali, setiap bingkai gambar baru menerima `ISlidesPicture` sendiri dan koleksi transformasi masing‑masing. Menerapkan skala abu‑abu pada satu bingkai tidak membuat bingkai lain menjadi skala abu‑abu, meskipun semuanya memakai sumber gambar tersemat yang sama.

Model `ISlidesPicture.getImageTransform` yang sama juga digunakan oleh isian gambar lain, seperti bentuk atau latar belakang slide. Contoh di bawah ini berfokus pada bingkai gambar.

## **Gunakan Rentang Parameter dan Unit yang Valid**

Metode yang ditunjukkan menggunakan rentang semantik dan unit berikut. Simpan nilai dalam rentang ini meskipun versi perpustakaan tertentu tidak menolak setiap nilai di luar rentang secara langsung; format presentasi target dapat menormalkan, mengabaikan, atau menolak data tidak valid saat menyimpan atau ketika PowerPoint membuka berkas.

| Operasi | Parameter | Rentang dan unit yang valid |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` hingga `100`, persen; `0` tidak mengubah komponen. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Tidak ada | Tidak ada parameter numerik. Alfa tidak berubah. |
| [addDuotoneEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Dua warna untuk piksel gelap dan terang. Saluran RGB dan alfa dalam `java.awt.Color` menggunakan `0` hingga `255`. |
| [addTintEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Hue `0` inklusif hingga `360` eksklusif, dalam derajat; amount `-100` hingga `100`, persen. |
| [addHSLEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Hue `0` inklusif hingga `360` eksklusif, dalam derajat; saturasi dan luminansi `-100` hingga `100`, persen. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Warna pengganti menggunakan nilai saluran `0` hingga `255`. Nilai alfa yang ada tidak berubah. |
| [addBlurEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Radius non‑negatif dan diukur dalam poin; `grow` adalah Boolean yang mengontrol apakah konten yang blur dapat melampaui batas asli. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Persen non‑negatif. Gunakan `0` hingga `100` untuk skala opasitas biasa: `0` sepenuhnya transparan dan `100` mempertahankan alfa yang ada. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` hingga `100`, persen opasitas. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` hingga `100`, persen ambang alfa. Nilai di bawahnya menjadi transparan; nilai pada atau di atasnya menjadi opak. |

Untuk modulasi alfa tetap, transparansi dan opasitas bersifat komplementer. Misalnya, transparansi 35 % bersesuaian dengan nilai modulasi alfa 65 %.

## **Terapkan Kecerahan dan Kontras**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) mengembalikan operasi [IBrightnessContrast](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibrightnesscontrast/). Pengaturan skalarnya disediakan saat operasi dibuat. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibrightnesscontrast/#getEffective--) mengembalikan nilai hanya‑baca yang dihitung dan dapat diperiksa atau dicatat.

Contoh berikut meningkatkan kecerahan sebesar 15 % dan kontras sebesar 20 %, lalu menampilkan pratinjau tanpa mengubah gambar tersemat:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/id/java/com.aspose.slides/brightnesscontrast/) adalah ekstensi efek gambar Office 2010 dan kurang portabel dibandingkan efek luminansi DrawingML standar. Ketika kecerahan dan kontras harus tetap dapat diedit setelah putar‑balik PPTX, gunakan [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) dan verifikasi hasilnya setelah membuka kembali berkas. Bagian batasan format menjelaskan perbedaan ini secara lebih detail.

## **Terapkan Transformasi Warna**

Efek warna dapat diterapkan secara independen pada bingkai gambar yang menggunakan satu sumber gambar. Contoh berikut membuat lima bingkai dan menerapkan skala abu‑abu, duotone, tint, penyesuaian HSL, serta penggantian warna.

[IDuotone](https://reference.aspose.com/slides/id/java/com.aspose.slides/iduotone/) memiliki dua parameter warna yang dapat diedit secara terpisah: `color1` memetakan piksel gelap, sementara `color2` memetakan piksel terang. Ini menjadikannya contoh berguna dari efek yang pengaturannya lebih kompleks daripada nilai skalar tunggal.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(new Color(0, 0, 128));
    duotone.getColor2().setColor(new Color(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(new Color(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) menggantikan setiap warna piksel dengan satu warna tetap sambil mempertahankan alfa. Ini berbeda dari [addColorChangeEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), yang memetakan satu warna sumber ke warna lain dan mengekspos format warna sumber serta target.

## **Tambahkan Blur, Transparansi, dan Efek Alfa**

[addBlurEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) memengaruhi semua saluran warna, termasuk alfa. Setel `grow` ke `true` bila tepi yang blur dapat melampaui batas gambar asli.

Untuk transparansi seragam, gunakan [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Efek ini mengalikan setiap nilai alfa yang ada, sehingga piksel yang sebagian transparan tetap berbeda secara proporsional. [addAlphaReplaceEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) justru menetapkan satu nilai alfa untuk semua piksel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) mengubah alfa menjadi dua level berdasarkan ambang.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Operasi alfa tanpa parameter lainnya meliputi [addAlphaCeilingEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) yang membuat setiap alfa bukan nol menjadi penuh opak; [addAlphaFloorEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) yang membuat setiap alfa di bawah 100 % menjadi sepenuhnya transparan; dan [addAlphaInverseEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) yang mengubah alfa menjadi `100% - alpha`.

## **Bangun Rantai Efek Berurutan**

Setiap metode `add...Effect` menambahkan operasi baru ke akhir koleksi. Renderer menggunakan koleksi sebagai pipeline berurutan: output operasi 0 menjadi input operasi 1, dan seterusnya. Akibatnya, operasi yang sama dalam urutan berbeda dapat menghasilkan gambar yang berbeda.

Misalnya, skala abu‑abu diikuti tint pertama‑tama menghapus informasi kromatik lalu mewarnai kembali hasil luminansi. Tint diikuti skala abu‑abu menghilangkan tint kembali. Demikian pula, penggantian alfa dapat menimpa nilai alfa yang dihitung oleh operasi sebelumnya, sementara modulasi alfa mempertahankan perbedaan relatifnya.

Contoh berikut membangun rantai empat operasi, menyimpannya sebagai PPTX, membuka kembali presentasi, memeriksa jenis operasi serta urutannya, dan menampilkan hasil yang dibuka kembali:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

Koleksi tidak memberlakukan matriks kompatibilitas yang membatasi operasi warna, alfa, dan blur ke rantai terpisah. Mereka dapat digabungkan, namun kombinasi tidak selalu berguna. Penggantian warna tetap menghapus variasi RGB yang dihasilkan oleh efek warna sebelumnya; skala abu‑abu setelah duotone menghapus dua warna terpilih; dan operasi alfa ceiling, floor, replacement, atau bi‑level dapat membuang detail alfa yang dibuat sebelumnya. Bangun rantai sesuai urutan pemrosesan piksel yang diinginkan, bukan memperlakukan item‑itemnya sebagai bendera format yang tidak berurutan.

## **Periksa Nilai yang Dapat Diedit dan Efektif**

Operasi yang dapat diedit adalah objek yang disimpan dalam `ISlidesPicture.getImageTransform`. Bergantung pada efeknya, objek tersebut dapat mengekspos anggota yang dapat ditulisi secara langsung. Misalnya, [IBlur](https://reference.aspose.com/slides/id/java/com.aspose.slides/iblur/) mengekspos nilai `radius` dan `grow` yang dapat ditulisi, [IAlphaModulateFixed](https://reference.aspose.com/slides/id/java/com.aspose.slides/ialphamodulatefixed/) mengekspos `amount` yang dapat ditulisi, dan [IAlphaBiLevel](https://reference.aspose.com/slides/id/java/com.aspose.slides/ialphabilevel/) mengekspos `threshold` yang dapat ditulisi. Efek warna seperti [IDuotone](https://reference.aspose.com/slides/id/java/com.aspose.slides/iduotone/) mengekspos objek [IColorFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/icolorformat/) yang dapat diubah.

Beberapa antarmuka operasi, termasuk [IBrightnessContrast](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/id/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/id/java/com.aspose.slides/itint/), dan [IAlphaReplace](https://reference.aspose.com/slides/id/java/com.aspose.slides/ialphareplace/), tidak mengekspos skalar pembuatan mereka sebagai properti yang dapat ditulisi. Untuk mengubah pengaturan tersebut, hapus operasi dan tambahkan pengganti pada posisi yang diperlukan.

Data efektif yang dikembalikan oleh `getEffective()` dihitung dan hanya‑baca. Ini berguna untuk menyelesaikan warna yang bergantung pada tema serta membaca nilai normalisasi yang digunakan renderer, tetapi bukan permukaan penyuntingan lain. Contoh berikut mengenumerasi rantai dan memeriksa nilai efektif di mana API yang bersangkutan menyediakannya:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Efek tanpa parameter seperti skala abu‑abu, alfa ceiling, dan alfa inverse tetap memiliki objek data‑efektif, namun tidak ada pengaturan skalar untuk dicetak. Keberadaan dan posisinya dalam koleksi adalah informasi penting.

## **Hapus atau Kosongkan Transformasi Gambar**

Gunakan [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) untuk menghapus satu operasi berdasarkan indeks. Karena indeks bergeser setelah penghapusan, cari target terlebih dahulu dan hapus setelah enumerasi. Gunakan [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/id/java/com.aspose.slides/imagetransformoperationcollection/#clear--) untuk menghapus seluruh rantai.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Menghapus atau mengosongkan transformasi hanya mengubah format gambar. Hal ini tidak menghapus, mengompresi ulang, atau mengubah sumber [IPPImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ippimage/) yang dipakai kembali.

## **Pertimbangkan Format Presentasi dan Target Ekspor**

Transformasi gambar berasal dari DrawingML, sehingga PPTX adalah format yang disarankan untuk mengedit rantai efek. Bahkan dengan PPTX, tidak setiap operasi memiliki portabilitas yang identik:

- Operasi DrawingML standar seperti luminansi, skala abu‑abu, duotone, tint, HSL, blur, dan operasi alfa umum memiliki peluang terbaik untuk bertahan pada putar‑balik PPTX. Selalu buka kembali berkas yang dihasilkan dan periksa koleksi bila preservasi menjadi keharusan.
- [BrightnessContrast](https://reference.aspose.com/slides/id/java/com.aspose.slides/brightnesscontrast/) merupakan ekstensi Office 2010, bukan operasi luminansi DrawingML standar. Ini dapat dipakai untuk rendering dalam memori, namun tidak dijamin tetap sebagai [IBrightnessContrast](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibrightnesscontrast/) yang dapat diedit setelah menyimpan dan membuka kembali PPTX. Lebih pilih [addLuminanceEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) untuk penyesuaian kecerahan dan kontras yang persisten.
- Format PPT biner mendahului model efek DrawingML lengkap. Menyimpan ke PPT dapat mengabaikan operasi yang tidak didukung, mereduksi rantai menjadi subset yang didukung, atau memperkirakan tampilan. Jangan gunakan PPT sebagai format verifikasi untuk rantai yang dapat diedit secara kompleks.
- Rendering ke PNG, JPEG, TIFF, PDF, SVG, HTML, atau output visual lainnya menerapkan rantai yang didukung ke tampilan yang dirender. Output tersebut tidak berisi [IImageTransformOperationCollection] yang dapat diedit; format raster meratakan hasil menjadi piksel, dan ekspor dokumen/vektor menyimpan representasi rendering mereka sendiri.
- Efek tidak menjadikan gambar tertaut mandiri. Rendering gambar tertaut tetap bergantung pada ketersediaan sumber tertaut saat presentasi dimuat.

Berbagai konsumen presentasi dapat merender kasus tepi secara berbeda, khususnya ketika beberapa operasi alfa atau kuantisasi warna digabungkan. Untuk output kritis, uji baik putar‑balik yang dapat diedit maupun format ekspor akhir dengan versi Aspose.Slides yang sama digunakan dalam produksi.

## **FAQ**

**Apakah efek transformasi gambar memodifikasi data gambar yang tersemat?**

Tidak. Operasi tersebut milik `ISlidesPicture` yang digunakan oleh isian gambar. Byte `IPPImage` yang mendasarinya tetap tidak berubah.

**Apakah dua bingkai gambar yang memakai gambar yang sama berbagi efeknya?**

Tidak. Menggunakan ulang `IPPImage` menghindari duplikasi data gambar, tetapi setiap bingkai gambar biasanya memiliki `ISlidesPicture` dan koleksi transformasi gambar yang terpisah.

**Apakah efek warna, blur, dan alfa dapat digabungkan?**

Ya. Koleksi menerima semuanya dalam satu rantai berurutan. Pertimbangkan apa yang dilakukan tiap operasi pada output operasi sebelumnya karena operasi penggantian dan ambang dapat menghilangkan detail warna atau alfa sebelumnya.

**Mengapa nilai efektif hanya‑baca?**

Data efektif mewakili nilai yang dihitung untuk rendering, termasuk warna yang telah diselesaikan. Edit operasi yang disimpan dalam koleksi transformasi bila ada anggota yang dapat ditulisi; bila tidak, hapus dan tambahkan pengganti dengan parameter pembuatan baru.

**Format apa yang harus saya gunakan untuk mempertahankan rantai transformasi?**

Gunakan PPTX dan verifikasi berkas dengan membukanya kembali. PPT lama tidak dapat merepresentasikan model efek DrawingML lengkap, dan format ekspor yang dirender hanya mempertahankan tampilan, bukan operasi transformasi yang dapat diedit.