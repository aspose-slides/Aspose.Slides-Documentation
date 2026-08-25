---
title: Kelola Efek Transformasi Gambar dalam Presentasi di Android
linktitle: Efek Transformasi Gambar
type: docs
weight: 11
url: /id/androidjava/image-transform-effects/
keywords:
- transformasi gambar
- efek gambar
- kecerahan
- kontras
- grayscale
- duotone
- tint
- HSL
- penggantian warna
- blur
- transparansi
- efek alfa
- rantai efek
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Terapkan, rangkai, inspeksi, hapus, dan verifikasi efek transformasi gambar untuk bingkai gambar dengan Aspose.Slides untuk Android via Java."
---
## **Ringkasan**

Aspose.Slides merepresentasikan penyesuaian gambar sebagai koleksi berurutan dari operasi transformasi gambar. Untuk sebuah bingkai gambar, mulailah dengan [ISlidesPicture](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidespicture/) dan akses [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidespicture/#getImageTransform--). Koleksi [IImageTransformOperationCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/) yang dikembalikan memungkinkan Anda menambahkan, menelusuri, memeriksa, menghapus, dan membersihkan efek tanpa menulis ulang byte gambar asli.

Artikel ini menunjukkan alur kerja lengkap untuk kecerahan dan kontras, transformasi warna, blur, transparansi, rantai efek berurutan, nilai efektif, penghapusan, dan verifikasi perjalanan bolak‑balik PPTX.

## **Memahami Kepemilikan Efek dan Penggunaan Ulang Gambar**

Sebuah sumber daya gambar dan gambar yang menampilkannya adalah objek yang berbeda:

- [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/) menyimpan atau merujuk data gambar sumber yang dimiliki oleh presentasi.
- [ISlidesPicture](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidespicture/) milik pengisian gambar dan merujuk ke sumber gambar sambil menyimpan koleksi transformasi gambar.
- [IPictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipictureframe/) adalah bentuk slide yang memiliki pengisian gambar terkait, geometri, pengaturan pemotongan, dan pemformatan tingkat bingkai lainnya.

Karena itu, operasi transformasi gambar tidak mengubah byte di [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/). Ketika `IPPImage` yang sama diteruskan ke [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) lebih dari satu kali, setiap bingkai gambar baru menerima `ISlidesPicture` miliknya sendiri dan koleksi transformasinya sendiri. Menerapkan grayscale pada satu bingkai tidak membuat bingkai lain menjadi grayscale, meskipun semua menggunakan sumber gambar tersemat yang sama.

Model `ISlidesPicture.getImageTransform` yang sama juga digunakan oleh pengisian gambar lainnya, seperti bentuk atau latar belakang slide. Contoh di bawah berfokus pada bingkai gambar.

## **Gunakan Rentang Parameter dan Unit yang Valid**

Metode yang ditunjukkan menggunakan rentang semantik dan unit berikut. Pertahankan nilai dalam rentang ini meskipun versi perpustakaan tertentu tidak menolak setiap nilai di luar rentang secara langsung; format presentasi target dapat menormalkan, mengabaikan, atau menolak data tidak valid saat menyimpan atau ketika PowerPoint membuka berkas.

| Operasi | Parameter | Rentang dan unit yang valid |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` sampai `100`, persen; `0` membiarkan komponen tidak berubah. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Tidak ada | Tidak ada parameter numerik. Alpha tidak berubah. |
| [addDuotoneEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Dua warna untuk piksel gelap dan terang. Nilai saluran RGB dan alpha yang digunakan oleh `android.graphics.Color` berkisar antara `0` hingga `255`. |
| [addTintEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Hue antara `0` inklusif sampai `360` eksklusif, dalam derajat; amount antara `-100` sampai `100`, persen. |
| [addHSLEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Hue antara `0` inklusif sampai `360` eksklusif, dalam derajat; saturation dan luminance antara `-100` sampai `100`, persen. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Warna pengganti menggunakan nilai saluran dari `0` hingga `255`. Nilai alpha yang ada tidak berubah. |
| [addBlurEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Radius tidak negatif dan diukur dalam poin; `grow` adalah Boolean yang mengontrol apakah konten blur dapat melampaui batas asli. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Persen tidak negatif. Gunakan `0` sampai `100` untuk penskalaan opasitas biasa: `0` sepenuhnya transparan dan `100` mempertahankan alpha yang ada. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` sampai `100`, persen opasitas. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` sampai `100`, persen ambang alpha. Nilai di bawah ambang menjadi transparan; nilai pada atau di atas ambang menjadi opak. |

Untuk modulasi alpha tetap, transparansi dan opasitas bersifat komplementer. Misalnya, transparansi 35% sesuai dengan nilai modulasi alpha 65%.

## **Menerapkan Kecerahan dan Kontras**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) mengembalikan operasi [IBrightnessContrast](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibrightnesscontrast/). Pengaturan skalarnya disediakan saat operasi dibuat. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibrightnesscontrast/#getEffective--) mengembalikan nilai baca‑saja yang dihitung yang dapat diperiksa atau dicatat.

Contoh berikut meningkatkan kecerahan sebesar 15 % dan kontras sebesar 20 %, kemudian menampilkan pratinjau tanpa mengubah gambar tersemat:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
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

[BrightnessContrast](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/brightnesscontrast/) adalah ekstensi efek gambar Office 2010 dan kurang portabel dibandingkan efek luminansi DrawingML standar. Ketika kecerahan dan kontras harus tetap dapat diedit setelah perjalanan bolak‑balik PPTX, gunakan [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) dan verifikasi hasilnya setelah membuka kembali berkas. Bagian batasan format menjelaskan perbedaan ini secara lebih rinci.

## **Menerapkan Transformasi Warna**

Efek warna dapat diterapkan secara independen pada bingkai gambar yang menggunakan satu sumber gambar yang sama. Contoh berikut membuat lima bingkai dan menerapkan grayscale, duotone, tint, penyesuaian HSL, dan penggantian warna.

[IDuotone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iduotone/) berisi dua parameter warna yang dapat diedit secara independen: `color1` memetakan piksel gelap, sementara `color2` memetakan piksel terang. Ini menjadikannya contoh berguna dari efek yang pengaturannya lebih kompleks daripada satu nilai skalar.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) mengganti warna setiap piksel dengan satu warna tetap sambil mempertahankan alpha. Ini berbeda dari [addColorChangeEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), yang memetakan satu warna sumber ke warna lain dan mengekspos format warna sumber serta target.

## **Menambahkan Blur, Transparansi, dan Efek Alpha**

[addBlurEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) memengaruhi semua saluran warna, termasuk alpha. Atur `grow` ke `true` ketika tepi blur dapat melampaui batas gambar asli.

Untuk transparansi seragam, gunakan [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Ia mengalikan setiap nilai alpha yang ada, sehingga piksel yang sebagian transparan tetap memiliki perbedaan proporsional. [addAlphaReplaceEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) justru menetapkan satu nilai alpha ke semua piksel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) mengubah alpha menjadi dua level berdasarkan ambang.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

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

Operasi alpha tanpa parameter lainnya meliputi [addAlphaCeilingEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), yang membuat setiap alpha nonnol menjadi sepenuhnya opak; [addAlphaFloorEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), yang menjadikan setiap alpha di bawah 100 % sepenuhnya transparan; dan [addAlphaInverseEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), yang mengubah alpha menjadi `100% - alpha`.

## **Membangun Rantai Efek Berurutan**

Setiap metode `add...Effect` menambahkan operasi baru ke akhir koleksi. Renderer menggunakan koleksi sebagai jalur pemrosesan berurutan: output operasi 0 menjadi input operasi 1, dan seterusnya. Akibatnya, operasi yang sama dalam urutan yang berbeda dapat menghasilkan gambar yang berbeda.

Sebagai contoh, grayscale diikuti tint pertama‑tama menghapus informasi kromatik lalu mewarnai kembali hasil luminansi. Tint diikuti grayscale menghilangkan tint kembali. Demikian pula, penggantian alpha dapat menimpa nilai alpha yang dihitung oleh operasi sebelumnya, sementara modulasi alpha mempertahankan perbedaan relatifnya.

Contoh berikut membangun rantai empat operasi, menyimpannya sebagai PPTX, membuka kembali presentasi, memeriksa jenis operasi serta urutannya, dan merender hasil yang dibuka kembali:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
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

Koleksi tidak memaksakan matriks kompatibilitas yang membatasi operasi warna, alpha, dan blur ke rantai terpisah. Mereka dapat digabungkan, tetapi kombinasi tidak selalu berguna. Penggantian warna tetap menghilangkan variasi RGB yang dihasilkan oleh efek warna sebelumnya; grayscale setelah duotone menghapus dua warna yang dipilih; dan operasi ceiling, floor, replacement, atau bi‑level dapat membuang detail alpha yang dibuat sebelumnya. Bangun rantai menurut urutan pemrosesan piksel yang diinginkan, bukan menganggap item‑itemnya sebagai flag pemformatan tak berurutan.

## **Memeriksa Nilai yang Dapat Disunting dan Nilai Efektif**

Operasi yang dapat disunting adalah objek yang disimpan dalam `ISlidesPicture.getImageTransform`. Tergantung pada efeknya, objek tersebut dapat mengekspos anggota yang dapat ditulis secara langsung. Misalnya, [IBlur](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iblur/) mengekspos nilai `radius` dan `grow` yang dapat ditulis, [IAlphaModulateFixed](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ialphamodulatefixed/) mengekspos `amount` yang dapat ditulis, dan [IAlphaBiLevel](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ialphabilevel/) mengekspos `threshold` yang dapat ditulis. Efek warna seperti [IDuotone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iduotone/) mengekspos objek [IColorFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icolorformat/) yang dapat diubah.

Beberapa antarmuka operasi, termasuk [IBrightnessContrast](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itint/), dan [IAlphaReplace](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ialphareplace/), tidak mengekspos skalar pembuatannya sebagai properti yang dapat ditulis. Untuk mengubah pengaturan tersebut, hapus operasi dan tambahkan pengganti pada posisi yang diinginkan.

Data efektif yang dikembalikan oleh `getEffective()` dihitung dan bersifat baca‑saja. Data ini berguna untuk menyelesaikan warna yang bergantung pada tema serta membaca nilai normalisasi yang digunakan renderer, tetapi bukan permukaan penyuntingan lain. Contoh berikut menelusuri rantai dan memeriksa nilai efektif di mana API yang bersangkutan menyediakannya:

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

Efek tanpa parameter seperti grayscale, alpha ceiling, dan alpha inverse tetap memiliki objek data‑efektif, namun tidak ada pengaturan skalar yang dapat dicetak. Keberadaan dan posisinya dalam koleksi adalah informasi penting.

## **Menghapus atau Mengosongkan Transformasi Gambar**

Gunakan [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) untuk menghapus satu operasi berdasarkan indeks. Karena indeks bergeser setelah penghapusan, cari target terlebih dahulu dan hapus setelah penelusuran. Gunakan [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) untuk menghapus seluruh rantai.

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

Menghapus atau mengosongkan transformasi mengubah hanya pemformatan gambar. Ini tidak menghapus, mengompresi ulang, atau mengubah sumber daya [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/) yang digunakan kembali.

## **Pertimbangkan Format Presentasi dan Target Ekspor**

Transformasi gambar berasal dari DrawingML, sehingga PPTX adalah format yang disarankan untuk rantai efek yang dapat diedit. Bahkan dengan PPTX, tidak semua operasi memiliki portabilitas yang identik:

- Operasi DrawingML standar seperti luminance, grayscale, duotone, tint, HSL, blur, dan operasi alpha umum memiliki peluang terbaik untuk bertahan dalam perjalanan bolak‑balik PPTX. Selalu buka kembali berkas yang dihasilkan dan periksa koleksi bila preservasi menjadi persyaratan.
- [BrightnessContrast](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/brightnesscontrast/) adalah ekstensi Office 2010 bukan operasi luminansi DrawingML standar. Ia dapat digunakan untuk rendering dalam memori, namun tidak dijamin tetap menjadi [IBrightnessContrast](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibrightnesscontrast/) yang dapat diedit setelah menyimpan dan membuka kembali PPTX. Lebih pilih [addLuminanceEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) untuk penyesuaian kecerahan dan kontras yang persisten.
- Format PPT biner mendahului model efek DrawingML penuh. Menyimpan ke PPT dapat menghilangkan operasi yang tidak didukung, mereduksi rantai menjadi subset yang didukung, atau memperkirakan tampilannya. Jangan gunakan PPT sebagai format verifikasi untuk rantai yang kompleks dan dapat diedit.
- Rendering ke PNG, JPEG, TIFF, PDF, SVG, HTML, atau output visual lainnya menerapkan rantai yang didukung pada tampilan yang dirender. Output tersebut tidak berisi koleksi `IImageTransformOperationCollection` yang dapat diedit; format raster meratakan hasil menjadi piksel, dan ekspor dokumen/vektor menyimpan representasi rendering mereka sendiri.
- Efek tidak membuat gambar yang ditautkan menjadi mandiri. Rendering gambar yang ditautkan tetap bergantung pada ketersediaan sumber daya yang ditautkan ketika presentasi dimuat.

Berbagai konsumen presentasi dapat merender kasus tepi secara berbeda, terutama ketika beberapa operasi alpha atau kuantisasi warna digabungkan. Untuk output yang kritis, uji baik perjalanan bolak‑balik yang dapat diedit maupun format ekspor akhir dengan versi Aspose.Slides yang sama seperti yang digunakan dalam produksi.

## **FAQ**

**Apakah efek transformasi gambar mengubah data gambar yang tersemat?**

Tidak. Operasi tersebut milik `ISlidesPicture` yang digunakan oleh pengisian gambar. Byte `IPPImage` yang mendasarinya tetap tidak berubah.

**Apakah dua bingkai gambar yang menggunakan gambar yang sama berbagi efeknya?**

Tidak. Menggunakan `IPPImage` yang sama menghindari duplikasi data gambar, tetapi setiap bingkai gambar biasanya memiliki `ISlidesPicture` dan koleksi transformasi gambar yang terpisah.

**Apakah efek warna, blur, dan alpha dapat digabungkan?**

Ya. Koleksi menerima mereka dalam satu rantai berurutan. Pertimbangkan apa yang dilakukan setiap operasi terhadap output operasi sebelumnya karena operasi penggantian dan ambang dapat membuang detail warna atau alpha sebelumnya.

**Mengapa nilai efektif bersifat baca‑saja?**

Data efektif mewakili nilai yang dihitung dan digunakan untuk rendering, termasuk warna yang telah diselesaikan. Edit operasi yang disimpan dalam koleksi transformasi bila terdapat anggota yang dapat ditulis; jika tidak, hapus dan tambahkan pengganti dengan parameter pembuatan baru.

**Format apa yang harus saya gunakan untuk mempertahankan rantai transformasi?**

Gunakan PPTX dan verifikasi berkas dengan membukanya kembali. PPT lama tidak dapat merepresentasikan model efek DrawingML penuh, dan format ekspor yang dirender mempertahankan tampilan bukan operasi transformasi yang dapat diedit.