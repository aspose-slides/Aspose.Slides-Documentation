---
title: Kelola Efek Transformasi Gambar dalam Presentasi dengan JavaScript
linktitle: Efek Transformasi Gambar
type: docs
weight: 11
url: /id/nodejs-java/image-transform-effects/
keywords:
- transformasi gambar
- efek gambar
- kecerahan
- kontras
- skala abu-abu
- duotone
- tint
- HSL
- penggantian warna
- blur
- transparansi
- efek alpha
- rantai efek
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Terapkan, rangkai, periksa, hapus, dan verifikasi efek transformasi gambar untuk bingkai gambar dengan Aspose.Slides untuk Node.js via Java."
---
## **Gambaran Umum**

Aspose.Slides merepresentasikan penyesuaian gambar sebagai koleksi terurut dari operasi transformasi gambar. Untuk sebuah bingkai gambar, mulailah dengan [Picture](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picture/) bingkai tersebut dan akses [Picture.getImageTransform](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picture/). [ImageTransformOperationCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) yang dikembalikan memungkinkan Anda menambahkan, menelusuri, memeriksa, menghapus, dan membersihkan efek tanpa menulis ulang byte gambar asli.

Artikel ini mendemonstrasikan alur kerja lengkap untuk kecerahan dan kontras, transformasi warna, blur, transparansi, rantai efek berurutan, nilai efektif, penghapusan, dan verifikasi putar‑balik PPTX.

## **Pahami Kepemilikan Efek dan Penggunaan Ulang Gambar**

Sebuah sumber gambar dan gambar yang menampilkannya adalah objek yang berbeda:

- [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) menyimpan atau merujuk data gambar sumber yang dimiliki oleh presentasi.
- [Picture](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picture/) termasuk dalam isian gambar dan merujuk ke sumber gambar sambil menyimpan koleksi transformasi gambar.
- [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/) adalah bentuk slide yang memiliki isian gambar terkait, geometri, pengaturan pemotongan, dan pemformatan tingkat bingkai lainnya.

Oleh karena itu, operasi transformasi gambar tidak mengubah byte dalam [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/). Ketika [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) yang sama diteruskan ke [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/) lebih dari satu kali, setiap bingkai gambar baru menerima [Picture](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picture/) dan koleksi transformasinya masing‑masing. Menerapkan grayscale pada satu bingkai tidak membuat bingkai lainnya menjadi grayscale, meskipun semuanya menggunakan sumber gambar tersemat yang sama.

Model [Picture.getImageTransform](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picture/) yang sama juga digunakan oleh isian gambar lain, seperti bentuk atau latar belakang slide. Contoh di bawah ini berfokus pada bingkai gambar.

## **Gunakan Rentang Parameter dan Satuan yang Valid**

Metode yang ditunjukkan menggunakan rentang semantik dan satuan berikut. Pertahankan nilai dalam rentang ini meskipun versi pustaka tertentu tidak menolak setiap nilai di luar rentang secara langsung; format presentasi target mungkin menormalkan, menghilangkan, atau menolak data tidak valid saat menyimpan atau saat PowerPoint membuka berkas.

| Operasi | Parameter | Rentang dan satuan yang valid |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` sampai `100`, persentase; `0` membiarkan komponen tidak berubah. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) | None | Tanpa parameter numerik. Alpha tidak berubah. |
| [addDuotoneEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Dua warna untuk piksel gelap dan terang. Saluran RGB dan alpha pada `java.awt.Color` menggunakan `0` sampai `255`. |
| [addTintEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Hue `0` inklusif sampai `360` eksklusif, dalam derajat; amount `-100` sampai `100`, persentase. |
| [addHSLEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Hue `0` inklusif sampai `360` eksklusif, dalam derajat; saturation dan luminance `-100` sampai `100`, persentase. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | Warna pengganti menggunakan nilai saluran dari `0` sampai `255`. Nilai alpha yang ada tidak berubah. |
| [addBlurEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Radius non‑negatif dan diukur dalam point; `grow` adalah Boolean yang mengontrol apakah konten blur dapat melampaui batas asli. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Persentase non‑negatif. Gunakan `0` sampai `100` untuk skala opasitas biasa: `0` sepenuhnya transparan dan `100` mempertahankan alpha yang ada. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` sampai `100`, persentase opasitas. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` sampai `100`, persentase ambang alpha. Nilai di bawah ambang menjadi transparan; nilai pada atau di atas ambang menjadi opak. |

Untuk modulasi alpha tetap, transparansi dan opasitas bersifat komplemen. Misalnya, transparansi 35 % berhubungan dengan nilai modulasi alpha 65 %.

## **Terapkan Kecerahan dan Kontras**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) mengembalikan operasi [BrightnessContrast](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/brightnesscontrast/). Pengaturan skalar disediakan saat operasi dibuat. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/brightnesscontrast/) mengembalikan nilai hanya‑baca yang dihitung yang dapat diperiksa atau dicatat.

Contoh berikut meningkatkan kecerahan sebesar 15 % dan kontras sebesar 20 %, lalu menampilkan pratinjau tanpa mengubah gambar tersemat:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    const brightnessContrast = imageTransform.addBrightnessContrastEffect(15, 20);

    const effectiveValues = brightnessContrast.getEffective();
    console.log("Brightness: " + effectiveValues.getBrightness() + "%");
    console.log("Contrast: " + effectiveValues.getContrast() + "%");

    const preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", aspose.slides.ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/brightnesscontrast/) adalah ekstensi efek gambar Office 2010 dan kurang portabel dibandingkan efek luminansi DrawingML standar. Ketika kecerahan dan kontras harus tetap dapat diedit setelah putar‑balik PPTX, gunakan [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) dan verifikasi hasilnya setelah membuka kembali berkas. Bagian batasan format menjelaskan perbedaan ini secara lebih detail.

## **Terapkan Transformasi Warna**

Efek warna dapat diterapkan secara independen pada bingkai gambar yang berbeda namun menggunakan satu sumber gambar. Contoh berikut membuat lima bingkai dan menerapkan grayscale, duotone, tint, penyesuaian HSL, serta penggantian warna.

[Duotone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/duotone/) memiliki dua parameter warna yang dapat diedit secara terpisah: `color1` memetakan piksel gelap, sementara `color2` memetakan piksel terang. Ini menjadikannya contoh berguna dari efek yang pengaturannya lebih kompleks daripada satu nilai skalar.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const grayFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    const duotoneFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 180, 120, image);
    const duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 128));
    duotone.getColor2().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));

    const tintFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210, 35);

    const hslFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30, 20, -10);

    const replacementFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 320, 170, 180, 120, image);
    const colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(java.newInstanceSync("java.awt.Color", 100, 149, 237));

    presentation.save("color-transformations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) menggantikan setiap warna piksel dengan satu warna tetap sambil mempertahankan alpha. Ini berbeda dari [addColorChangeEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/), yang memetakan satu warna sumber ke warna lain dan menampilkan format warna sumber serta target.

## **Tambahkan Blur, Transparansi, dan Efek Alpha**

[addBlurEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) memengaruhi semua saluran warna, termasuk alpha. Setel `grow` ke `true` ketika tepi blur dapat melampaui batas gambar asli.

Untuk transparansi seragam, gunakan [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/). Ia mengalikan setiap nilai alpha yang ada, sehingga piksel yang sebagian transparan tetap berbeda secara proporsional. [addAlphaReplaceEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) sebaliknya menetapkan satu nilai alpha ke semua piksel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) mengonversi alpha menjadi dua level berdasarkan ambang.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const blurredFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 140, image);
    const blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    const transparentFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 20, 200, 140, image);
    const alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65);
    alphaModulate.setAmount(60);

    const uniformAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55);

    const binaryAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 180, 200, 140, image);
    const alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50);
    alphaBiLevel.setThreshold(45);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Operasi alpha tanpa parameter lain termasuk [addAlphaCeilingEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/), yang membuat setiap alpha non‑nol menjadi sepenuhnya opak; [addAlphaFloorEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/), yang membuat setiap alpha di bawah 100 % menjadi sepenuhnya transparan; dan [addAlphaInverseEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/), yang mengubah alpha menjadi `100% - alpha`.

## **Bangun Rantai Efek Berurutan**

Setiap metode `add...Effect` menambahkan operasi baru ke akhir koleksi. Renderer menggunakan koleksi sebagai pipa berurutan: output operasi 0 menjadi input operasi 1, dan seterusnya. Akibatnya, operasi yang sama dalam urutan berbeda dapat menghasilkan gambar yang berbeda.

Sebagai contoh, grayscale diikuti tint pertama‑tama menghapus informasi kromatik lalu mewarnai kembali hasil luminansi. Tint diikuti grayscale menghilangkan tint kembali. Demikian pula, penggantian alpha dapat menimpa nilai alpha yang dihitung oleh operasi sebelumnya, sementara modulasi alpha mempertahankan perbedaan relatifnya.

Contoh berikut membangun rantai empat operasi, menyimpannya sebagai PPTX, membuka kembali presentasi, memeriksa tipe operasi serta urutannya, dan menampilkan hasil yang dibuka kembali:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220, 25);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80);

    presentation.save("image-transform-chain.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(reopenedShape, "com.aspose.slides.IPictureFrame")) {
        const reopenedTransform = reopenedShape.getPictureFormat().getPicture().getImageTransform();
        const orderIsPreserved = reopenedTransform.size() === 4 &&
            java.instanceOf(reopenedTransform.get_Item(0), "com.aspose.slides.IGrayScale") &&
            java.instanceOf(reopenedTransform.get_Item(1), "com.aspose.slides.ITint") &&
            java.instanceOf(reopenedTransform.get_Item(2), "com.aspose.slides.IBlur") &&
            java.instanceOf(reopenedTransform.get_Item(3), "com.aspose.slides.IAlphaModulateFixed");
        console.log(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        const renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", aspose.slides.ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        console.log("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

Koleksi tidak memberlakukan matriks kompatibilitas yang membatasi operasi warna, alpha, dan blur ke rantai terpisah. Mereka dapat digabungkan, namun kombinasi tidak selalu berguna. Penggantian warna tetap menghapus variasi RGB yang dihasilkan oleh efek warna sebelumnya; grayscale setelah duotone menghilangkan dua warna terpilih; dan operasi ceiling, floor, replacement, atau bi‑level alpha dapat membuang detail alpha yang dibuat sebelumnya. Bangun rantai sesuai urutan pemrosesan piksel yang diinginkan, bukan memperlakukan itemnya sebagai flag pemformatan tidak berurutan.

## **Periksa Nilai yang Dapat Diedit dan Nilai Efektif**

Operasi yang dapat diedit adalah objek yang disimpan dalam [Picture.getImageTransform](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picture/). Tergantung pada efeknya, ia dapat mengekspos anggota yang dapat ditulis secara langsung. Misalnya, [Blur](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/blur/) mengekspos nilai `radius` dan `grow` yang dapat ditulis, [AlphaModulateFixed](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/alphamodulatefixed/) mengekspos `amount` yang dapat ditulis, dan [AlphaBiLevel](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/alphabilevel/) mengekspos `threshold` yang dapat ditulis. Efek warna seperti [Duotone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/duotone/) mengekspos objek [ColorFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/colorformat/) yang dapat diubah.

Beberapa operasi, termasuk [BrightnessContrast](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tint/), dan [AlphaReplace](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/alphareplace/), tidak mengekspos skalar pembuatan mereka sebagai properti yang dapat ditulis. Untuk mengubah pengaturan tersebut, hapus operasi dan tambahkan pengganti pada posisi yang diperlukan.

Data efektif yang dikembalikan oleh `getEffective()` dihitung dan hanya‑baca. Ini berguna untuk menyelesaikan warna yang bergantung pada tema dan membaca nilai normalisasi yang digunakan renderer, tetapi bukan permukaan penyuntingan lain. Contoh berikut menelusuri rantai dan memeriksa nilai efektif di mana API yang bersangkutan menyediakannya:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (let index = 0; index < imageTransform.size(); index++) {
            const operation = imageTransform.get_Item(index);
            console.log(index + ": " + operation.getClass().getSimpleName());

            if (java.instanceOf(operation, "com.aspose.slides.IBrightnessContrast")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.ILuminance")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.IDuotone")) {
                const data = operation.getEffective();
                console.log("  Dark color: " + data.getColor1());
                console.log("  Light color: " + data.getColor2());
            } else if (java.instanceOf(operation, "com.aspose.slides.IColorReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement color: " + data.getColor());
            } else if (java.instanceOf(operation, "com.aspose.slides.IHSL")) {
                const data = operation.getEffective();
                console.log("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (java.instanceOf(operation, "com.aspose.slides.ITint")) {
                const data = operation.getEffective();
                console.log("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (java.instanceOf(operation, "com.aspose.slides.IBlur")) {
                const data = operation.getEffective();
                console.log("  Blur radius: " + data.getRadius() + " pt");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaModulateFixed")) {
                const data = operation.getEffective();
                console.log("  Alpha amount: " + data.getAmount() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaBiLevel")) {
                const data = operation.getEffective();
                console.log("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Efek tanpa parameter seperti grayscale, alpha ceiling, dan alpha inverse tetap memiliki objek data‑efektif, namun tidak ada pengaturan skalar yang dapat dicetak. Keberadaan dan posisinya dalam koleksi merupakan informasi yang penting.

## **Hapus atau Bersihkan Transformasi Gambar**

Gunakan [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) untuk menghapus satu operasi berdasarkan indeks. Karena indeks bergeser setelah penghapusan, cari target terlebih dahulu dan hapus setelah penelusuran. Gunakan [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) untuk menghapus seluruh rantai.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        let blurIndex = -1;

        for (let index = 0; index < imageTransform.size(); index++) {
            if (java.instanceOf(imageTransform.get_Item(index), "com.aspose.slides.IBlur")) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            console.log("The blur operation was removed.");
        }

        imageTransform.clear();
        console.log("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Menghapus atau membersihkan transformasi hanya mengubah pemformatan gambar. Ini tidak menghapus, mengompresi ulang, atau mengubah sumber daya [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) yang digunakan kembali.

## **Pertimbangkan Format Presentasi dan Target Ekspor**

Transformasi gambar berasal dari DrawingML, sehingga PPTX adalah format editabel yang disarankan untuk rantai efek. Bahkan dengan PPTX, tidak setiap operasi memiliki portabilitas yang sama:

- Operasi DrawingML standar seperti luminance, grayscale, duotone, tint, HSL, blur, dan operasi alpha umum memiliki peluang terbaik untuk bertahan setelah putar‑balik PPTX. Selalu buka kembali berkas yang dihasilkan dan periksa koleksinya ketika preservasi menjadi persyaratan.
- [BrightnessContrast](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/brightnesscontrast/) adalah ekstensi Office 2010, bukan operasi luminansi DrawingML standar. Ia dapat digunakan untuk perenderan dalam memori, namun tidak dijamin tetap sebagai operasi [BrightnessContrast](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/brightnesscontrast/) yang dapat diedit setelah menyimpan dan membuka kembali PPTX. Lebih pilih [addLuminanceEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) untuk penyesuaian kecerahan dan kontras yang persisten.
- Format PPT biner mendahului model efek DrawingML penuh. Menyimpan ke PPT dapat menghilangkan operasi yang tidak didukung, mereduksi rantai menjadi subset yang didukung, atau memperkirakan tampilan. Jangan gunakan PPT sebagai format verifikasi untuk rantai editabel yang kompleks.
- Rendering ke PNG, JPEG, TIFF, PDF, SVG, HTML, atau output visual lainnya menerapkan rantai yang didukung pada tampilan yang dirender. Output tersebut tidak berisi [ImageTransformOperationCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagetransformoperationcollection/) yang dapat diedit; format raster menumpuhkan hasil menjadi piksel, dan ekspor dokumen/vektor menyimpan representasi perenderan mereka sendiri.
- Efek tidak membuat gambar tertaut menjadi mandiri. Rendering gambar tertaut tetap bergantung pada sumber daya tertaut yang tersedia saat presentasi dimuat.

Berbagai konsumen presentasi dapat merender kasus tepi secara berbeda, terutama ketika beberapa operasi alpha atau kuantisasi warna digabungkan. Untuk output kritis, uji baik putar‑balik editabel maupun format ekspor final dengan versi Aspose.Slides yang sama seperti yang dipakai di produksi.

## **FAQ**

**Apakah efek transformasi gambar mengubah data gambar yang tersemat?**

Tidak. Operasi berada pada [Picture](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picture/) yang digunakan oleh isian gambar. Byte [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) yang mendasarinya tetap tidak berubah.

**Apakah dua bingkai gambar yang menggunakan gambar yang sama berbagi efeknya?**

Tidak. Menggunakan kembali [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) menghindari duplikasi data gambar, tetapi setiap bingkai gambar biasanya memiliki [Picture](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picture/) dan koleksi transformasi gambar yang terpisah.

**Dapatkah efek warna, blur, dan alpha digabungkan?**

Ya. Koleksi menerima semuanya dalam satu rantai berurutan. Pertimbangkan apa yang dilakukan setiap operasi pada output operasi sebelumnya karena operasi penggantian dan ambang dapat menghapus detail warna atau alpha yang dibuat sebelumnya.

**Mengapa nilai efektif bersifat hanya‑baca?**

Data efektif mewakili nilai yang dihitung untuk perenderan, termasuk warna yang telah diselesaikan. Edit operasi yang disimpan dalam koleksi transformasi di mana anggota yang dapat ditulis ada; bila tidak, hapus operasi tersebut dan tambahkan pengganti dengan parameter pembuatan yang baru.

**Format apa yang sebaiknya saya gunakan untuk mempertahankan rantai transformasi?**

Gunakan PPTX dan verifikasi berkas dengan membuka kembali. PPT lama tidak dapat merepresentasikan model efek DrawingML lengkap, dan format ekspor yang dirender hanya mempertahankan tampilan, bukan operasi transformasi yang dapat diedit.