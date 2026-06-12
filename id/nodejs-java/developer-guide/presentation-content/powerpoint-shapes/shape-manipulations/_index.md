---
title: Kelola Bentuk Presentasi dengan JavaScript
linktitle: Manipulasi Bentuk
type: docs
weight: 40
url: /id/nodejs-java/shape-manipulations/
keywords:
- Bentuk PowerPoint
- Bentuk presentasi
- Bentuk pada slide
- temukan bentuk
- gandakan bentuk
- hapus bentuk
- sembunyikan bentuk
- ubah urutan bentuk
- dapatkan ID bentuk Interop
- teks alternatif bentuk
- format tata letak bentuk
- bentuk sebagai SVG
- bentuk menjadi SVG
- sejajarkan bentuk
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara membuat, mengedit, dan mengoptimalkan bentuk menggunakan JavaScript dan Aspose.Slides untuk Node.js via Java serta menghasilkan presentasi PowerPoint berkinerja tinggi."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan bentuk dalam presentasi menggunakan Aspose.Slides. Artikel ini menunjukkan cara menemukan bentuk pada slide, menggandakannya, menghapusnya, menyembunyikannya, mengubah urutannya, mendapatkan ID bentuk Interop, dan mengatur teks alternatif untuk identifikasi serta pemrosesan lebih lanjut.

Artikel ini juga mencakup cara mengakses format tata letak untuk bentuk, merender sebuah bentuk sebagai SVG, menyelaraskan bentuk pada slide, dan menggunakan properti flip untuk pencerminan horizontal dan vertikal. Selain itu, artikel ini menyertakan FAQ singkat tentang kombinasi bentuk, urutan tumpukan, dan penguncian bentuk.

## **Temukan Bentuk di Slide**

Topik ini akan menjelaskan teknik sederhana untuk mempermudah pengembang menemukan bentuk tertentu pada slide tanpa menggunakan Id internalnya. Penting untuk diketahui bahwa file Presentasi PowerPoint tidak memiliki cara untuk mengidentifikasi bentuk pada slide kecuali melalui Id unik internal. Hal ini membuat pengembang kesulitan menemukan bentuk menggunakan Id unik internalnya. Semua bentuk yang ditambahkan ke slide memiliki beberapa Teks Alternatif. Kami menyarankan pengembang menggunakan teks alternatif untuk menemukan bentuk tertentu. Anda dapat menggunakan MS PowerPoint untuk menentukan teks alternatif untuk objek yang akan Anda ubah di masa mendatang.

Setelah menetapkan teks alternatif pada bentuk yang diinginkan, Anda dapat membuka presentasi tersebut menggunakan Aspose.Slides for Node.js via Java dan mengulangi semua bentuk yang ditambahkan ke slide. Pada setiap iterasi, Anda dapat memeriksa teks alternatif bentuk tersebut dan bentuk dengan teks alternatif yang cocok akan menjadi bentuk yang Anda butuhkan. Untuk mendemonstrasikan teknik ini dengan lebih baik, kami telah membuat metode, [findShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-) yang melakukan pencarian bentuk tertentu dalam slide dan kemudian mengembalikan bentuk tersebut.

```javascript
// Instansiasi kelas Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Teks alternatif dari bentuk yang akan ditemukan
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```

## **Gandakan Bentuk**

Untuk menggandakan sebuah bentuk ke slide menggunakan Aspose.Slides for Node.js via Java:

1. Buat sebuah instansi dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide dengan menggunakan indeksnya.
3. Akses koleksi bentuk slide sumber.
4. Tambahkan slide baru ke presentasi.
5. Gandakan bentuk dari koleksi bentuk slide sumber ke slide baru.
6. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Contoh di bawah menambahkan bentuk grup ke slide.

```javascript
// Instansiasi kelas Presentation
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // Tuliskan file PPTX ke disk
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hapus Bentuk**

Aspose.Slides for Node.js via Java memungkinkan pengembang menghapus bentuk apa pun. Untuk menghapus bentuk dari slide mana pun, ikuti langkah-langkah berikut:

1. Buat sebuah instansi dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Akses slide pertama.
3. Temukan bentuk dengan AlternativeText tertentu.
4. Hapus bentuk.
5. Simpan file ke disk.

```javascript
// Buat objek Presentation
var pres = new aspose.slides.Presentation();
try {
    // Dapatkan slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Tambahkan autoshape tipe persegi panjang
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // Simpan presentasi ke disk
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sembunyikan Bentuk**

Aspose.Slides for Node.js via Java memungkinkan pengembang menyembunyikan bentuk apa pun. Untuk menyembunyikan bentuk dari slide mana pun, ikuti langkah-langkah berikut:

1. Buat sebuah instansi dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Akses slide pertama.
3. Temukan bentuk dengan AlternativeText tertentu.
4. Sembunyikan bentuk.
5. Simpan file ke disk.

```javascript
// Instansiasi kelas Presentation yang mewakili file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Dapatkan slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Tambahkan autoshape tipe persegi panjang
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // Simpan presentasi ke disk
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ubah Urutan Bentuk**

Aspose.Slides for Node.js via Java memungkinkan pengembang mengubah urutan bentuk. Mengubah urutan bentuk menentukan bentuk mana yang berada di depan atau di belakang. Untuk mengubah urutan bentuk pada slide mana pun, ikuti langkah-langkah berikut:

1. Buat sebuah instansi dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Akses slide pertama.
3. Tambahkan sebuah bentuk.
4. Tambahkan beberapa teks dalam frame teks bentuk.
5. Tambahkan bentuk lain dengan koordinat yang sama.
6. Ubah urutan bentuk.
7. Simpan file ke disk.

```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dapatkan ID Bentuk Interop**

Aspose.Slides for Node.js via Java memungkinkan pengembang memperoleh pengidentifikasi bentuk unik dalam lingkup slide, berbeda dengan metode [getUniqueId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#getUniqueId--) yang memungkinkan memperoleh pengidentifikasi unik dalam lingkup presentasi. Metode [getOfficeInteropShapeId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) telah ditambahkan ke kelas [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape) dan kelas [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape) masing‑masing. Nilai yang dikembalikan oleh metode [getOfficeInteropShapeId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) sesuai dengan nilai Id dari objek Microsoft.Office.Interop.PowerPoint.Shape. Di bawah ini diberikan contoh kode.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Mendapatkan pengidentifikasi bentuk unik dalam lingkup slide
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Atur Teks Alternatif untuk Bentuk**

Aspose.Slides for Node.js via Java memungkinkan pengembang mengatur AlternateText pada bentuk apa pun. Bentuk dalam presentasi dapat dibedakan dengan metode [AlternativeText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) atau [Shape Name](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#setName-java.lang.String-). Metode [setAlternativeText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) dan [getAlternativeText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#getAlternativeText--) dapat dibaca atau diatur menggunakan Aspose.Slides maupun Microsoft PowerPoint. Dengan menggunakan metode ini, Anda dapat menandai sebuah bentuk dan melakukan berbagai operasi seperti Menghapus bentuk, Menyembunyikan bentuk, atau Mengubah urutan bentuk pada slide. Untuk mengatur AlternateText sebuah bentuk, ikuti langkah-langkah berikut:

1. Buat sebuah instansi dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Akses slide pertama.
3. Tambahkan bentuk apa pun ke slide.
4. Lakukan beberapa pekerjaan dengan bentuk yang baru ditambahkan.
5. Telusuri bentuk-bentuk untuk menemukan sebuah bentuk.
6. Atur AlternativeText.
7. Simpan file ke disk.

```javascript
// Instansiasi kelas Presentation yang mewakili file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Dapatkan slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Tambahkan autoshape tipe persegi panjang
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // Simpan presentasi ke disk
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Akses Format Tata Letak untuk Bentuk**

Aspose.Slides for Node.js via Java menyediakan API sederhana untuk mengakses format tata letak sebuah bentuk. Artikel ini menunjukkan cara mengakses format tata letak. Contoh kode di bawah diberikan.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Render Bentuk sebagai SVG**

Sekarang Aspose.Slides for Node.js via Java mendukung render bentuk sebagai SVG. Metode [writeAsSvg](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (dan overload-nya) telah ditambahkan ke kelas [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape). Metode ini memungkinkan menyimpan konten bentuk sebagai file SVG. Potongan kode di bawah menunjukkan cara mengekspor bentuk slide ke file SVG.

```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Penyelarasan Bentuk**

Aspose.Slides memungkinkan penyelarasan bentuk baik relatif terhadap margin slide maupun relatif terhadap satu sama lain. Untuk keperluan ini, metode overload [SlidesUtil.alignShape()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-) telah ditambahkan. Enumerasi [ShapesAlignmentType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapesAlignmentType) menetapkan opsi penyelarasan yang mungkin.

**Contoh 1**

Kode sumber di bawah menyelaraskan bentuk dengan indeks 1,2, dan 4 sepanjang tepi atas slide.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Contoh 2**

Contoh di bawah menunjukkan cara menyelaraskan seluruh koleksi bentuk relatif terhadap bentuk paling bawah dalam koleksi.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Properti Flip**

Di Aspose.Slides, kelas [ShapeFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapeframe/) memberikan kontrol atas pencerminan horizontal dan vertikal bentuk melalui properti `flipH` dan `flipV`. Kedua properti bertipe `byte`, dengan nilai `1` menandakan pencerminan, `0` tanpa pencerminan, atau `-1` untuk menggunakan perilaku default. Nilai-nilai ini dapat diakses dari [Frame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getFrame) sebuah bentuk.

Untuk mengubah pengaturan flip, sebuah instansi baru [ShapeFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapeframe/) dibuat dengan posisi dan ukuran saat ini dari bentuk, nilai yang diinginkan untuk `flipH` dan `flipV`, serta sudut rotasi. Menetapkan instansi ini ke [Frame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getFrame) bentuk dan menyimpan presentasi akan menerapkan transformasi cermin dan mengaplikasikannya ke file output.

Misalkan kita memiliki file sample.pptx di mana slide pertama berisi satu bentuk dengan pengaturan flip default, seperti yang ditunjukkan di bawah.

![Bentuk yang akan diputar](shape_to_be_flipped.png)

Contoh kode berikut mengambil properti flip saat ini dari bentuk dan memutarnya secara horizontal dan vertikal.

```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // Dapatkan properti flip horizontal dari bentuk.
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // Dapatkan properti flip vertikal dari bentuk.
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // Flip horizontally.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // Flip vertically.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Bentuk yang diputar](flipped_shape.png)

## **FAQ**

**Apakah saya dapat menggabungkan bentuk (union/intersect/subtract) pada slide seperti di editor desktop?**

Tidak ada API operasi Boolean bawaan. Anda dapat mendekatinya dengan membangun kontur yang diinginkan secara manual—misalnya, menghitung geometri hasil (melalui [GeometryPath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/geometrypath/)) dan membuat bentuk baru dengan kontur tersebut, dengan opsi menghapus yang asli.

**Bagaimana saya dapat mengontrol urutan tumpukan (z-order) sehingga sebuah bentuk selalu berada di atas?**

Ubah urutan sisip/move dalam koleksi [shapes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslide/#getShapes) slide. Untuk hasil yang dapat diprediksi, selesaikan z-order setelah semua modifikasi slide lainnya.

**Apakah saya dapat "mengunci" sebuah bentuk untuk mencegah pengguna mengeditnya di PowerPoint?**

Ya. Atur flag perlindungan tingkat bentuk (misalnya, kunci pemilihan, pergerakan, perubahan ukuran, edit teks). Jika diperlukan, terapkan pembatasan pada master atau tata letak. Perhatikan bahwa ini adalah perlindungan level UI, bukan fitur keamanan; untuk perlindungan yang lebih kuat, gabungkan dengan pembatasan tingkat file seperti [rekomendasi read‑only atau kata sandi](/slides/id/nodejs-java/password-protected-presentation/).