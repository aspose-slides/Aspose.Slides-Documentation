---
title: Kelola Placeholder Presentasi dalam JavaScript
linktitle: Kelola Placeholder
type: docs
weight: 10
url: /id/nodejs-java/manage-placeholder/
keywords:
- placeholder
- placeholder teks
- placeholder gambar
- placeholder grafik
- placeholder konten
- teks prompt
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara memeriksa dan mengedit placeholder teks, gambar, grafik, dan konten serta memahami pewarisan placeholder dengan Aspose.Slides untuk Node.js melalui Java."
---
## **Gambaran Umum**

Placeholder adalah bentuk yang menyimpan posisi untuk jenis konten tertentu dalam templat presentasi. Contoh umum meliputi placeholder judul, badan, gambar, grafik, dan placeholder konten umum. Tidak seperti bentuk biasa, placeholder dapat mewarisi posisi, ukuran, pemformatan, dan pengaturan lainnya dari slide tata letak atau slide master.

Aspose.Slides mengekspos informasi placeholder melalui metode [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder). Metode ini mengembalikan objek [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) atau `null` untuk bentuk normal. Gunakan [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) untuk menentukan apa yang dimaksudkan untuk diisi oleh placeholder tersebut.

Kelas bentuk masih penting setelah Anda mengetahui tipe placeholder:

- Placeholder teks, gambar, grafik, atau konten yang kosong biasanya direpresentasikan oleh sebuah [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
- Placeholder gambar yang sudah terisi dapat direpresentasikan oleh sebuah [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/).
- Placeholder grafik yang sudah terisi dapat direpresentasikan oleh sebuah [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/).
- Placeholder konten dapat berisi beberapa jenis konten. Periksa baik [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) maupun kelas bentuk runtime alih-alih mengasumsikan bahwa setiap placeholder adalah sebuah [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) menjelaskan peran placeholder; itu tidak menjamin tipe runtime bentuk. Selalu lakukan pengecekan tipe sebelum mengakses anggota teks, gambar, grafik, tabel, atau media spesifik.
{{% /alert %}}

## **Memahami Pewarisan Placeholder**

Placeholder membentuk hierarki:

1. Slide master mendefinisikan gaya yang dapat digunakan kembali dan, dalam beberapa kasus, placeholder tingkat master.
2. Slide tata letak mendefinisikan susunan yang digunakan oleh satu atau lebih slide normal dan dapat mewarisi dari master.
3. Slide normal berisi placeholder untuk slide tersebut dan dapat mewarisi dari tata letaknya.

Panggil [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) untuk naik satu tingkat dalam hierarki ini. Sebuah placeholder slide biasanya mengembalikan placeholder tata letaknya; sebuah placeholder tata letak dapat mengembalikan placeholder masternya. Metode ini mengembalikan `null` ketika bentuk tidak memiliki placeholder dasar.

Contoh berikut menampilkan placeholder pada slide pertama dan melaporkan placeholder dasarnya:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Menyunting placeholder pada slide normal membuat atau mengubah penimpaan lokal untuk slide tersebut. Menyunting tata letak atau master yang terkait dapat memengaruhi semua slide yang masih mewarisi pengaturan itu. Sebuah bentuk lokal biasa tidak memiliki placeholder dasar dan tidak mulai mewarisi hanya karena menempati koordinat yang sama.

## **Menghapus Status Placeholder**

Saat menyesuaikan templat, gunakan [Shape.removePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#removePlaceholder) untuk menjaga objek yang ada tetap sebagai bentuk biasa. Metode [getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) mengembalikan `null`, tetapi bentuk tetap berada dalam koleksi slide. Sebaliknya, [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#remove) menghapus bentuk dari koleksi tersebut.

Contoh berikut memerlukan `template.pptx` dengan setidaknya satu slide dan placeholder teks yang tidak kosong pada slide pertama. Gunakan placeholder dengan pemformatan yang diwarisi dari tata letaknya atau master untuk melihat efek menghapus hubungan tersebut. Contoh ini memeriksa bahwa bentuk yang sama tetap ada, memanggil metode lagi pada bentuk yang kini biasa, dan menyimpan hasilnya.

{{% alert color="warning" title="Warning" %}}
Menghapus status placeholder tidak secara otomatis mempertahankan pengaturan tampilan yang diwarisi. Contoh di bawah sengaja membiarkan pengaturan tersebut tidak berubah, sehingga output mungkin terlihat berbeda. Sebuah bentuk yang posisinya dan ukurannya sepenuhnya diwarisi dapat memiliki koordinat dan dimensi nol setelah pemanggilan dan menjadi tidak terlihat meskipun tetap berada dalam koleksi.
{{% /alert %}}

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapes = slide.getShapes();
    let found = false;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || textFrame == null) {
            continue;
        }

        const text = textFrame.getText();
        if (text == null || text.length === 0) {
            continue;
        }

        const shapeCount = shapes.size();
        shape.removePlaceholder();

        console.log("Placeholder removed: " + (shape.getPlaceholder() == null));
        const retainedShape = shapes.get_Item(index);
        console.log("Same shape retained: " + shape.equals(retainedShape));
        console.log("Shape count unchanged: " + (shapes.size() === shapeCount));

        // Memanggil metode pada bentuk biasa tidak memberi efek.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

Untuk placeholder yang cocok, ketiga pemeriksaan mencetak `true`. Teks tetap ada, tetapi posisi, ukuran, rotasi, font, perataan paragraf, margin bingkai teks, penambatan vertikal, isi, dan pengaturan garis yang diwarisi dapat berubah ketika hubungan placeholder dihapus. Misalnya, pemformatan judul yang diwarisi dapat kembali ke pemformatan teks biasa. Lihat [Tata Letak Slide](/slides/id/nodejs-java/slide-layout/) untuk informasi lebih lanjut tentang tata letak.

Untuk mempertahankan tampilan yang dimaksud, rekam posisi, ukuran, dan rotasi yang telah diselesaikan sebelum pemanggilan, dan salin nilai pemformatan efektif yang diperlukan ke variabel terpisah. Dapatkan nilai tersebut melalui [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getEffective), dan [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective). Jangan hanya mengandalkan objek format-efektif, karena nilai pemformatan teks mereka dapat berubah setelah hubungan dihapus. Terapkan secara eksplisit nilai yang direkam ke bentuk biasa setelahnya, termasuk keluarga font, ukuran, gaya, warna, pengaturan paragraf, pengaturan bingkai teks, isi, dan garis yang digunakan oleh templat Anda.

Geometri bentuk yang diwarisi mungkin juga perlu ditetapkan secara eksplisit melalui [GeometryShape.setShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setShapeType). Untuk placeholder teks berbentuk persegi panjang, ini berarti menetapkan [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/#Rectangle); mengembalikan hanya isi dan garis mungkin tidak mengembalikan persegi panjang yang terlihat. Templat dengan efek tambahan atau pemformatan yang lebih kompleks memerlukan penanganan pengaturan tersebut juga.

## **Mengubah Teks dalam Placeholder**

Placeholder judul, judul-terpusat, subjudul, badan, dan teks biasanya mendukung teks. Periksa [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) sebelum menggunakan metode [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) miliknya.

Contoh ini memperbarui placeholder judul pertama pada slide pertama dan menyimpan hasilnya:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pola ini menghindari memperlakukan placeholder gambar, grafik, tabel, atau media sebagai objek [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/). Ia juga mengidentifikasi placeholder berdasarkan tujuan alih-alih bergantung pada indeks bentuk yang rapuh.

## **Menetapkan Teks Prompt pada Tata Letak**

Teks prompt adalah instruksi saat desain yang ditampilkan dalam placeholder kosong, seperti *Click to add title*. Tetapkan teks prompt khusus pada placeholder tata letak alih-alih mencoba mengaksesnya melalui koleksi bentuk slide normal. Akses tata letak melalui [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getLayoutSlide) dan iterasi koleksi yang dikembalikan oleh [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes).

Contoh berikut mengubah prompt judul dan subjudul pada tata letak yang digunakan oleh slide pertama:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Teks prompt bukan konten slide biasa. Ia dimaksudkan untuk placeholder kosong dalam aplikasi penyunting seperti PowerPoint. Setelah pengguna atau program menyediakan konten nyata, prompt tidak lagi ditampilkan. Mengubah prompt juga tidak menggantikan teks yang ada pada slide yang menggunakan tata letak tersebut.

## **Memperbarui Placeholder Gambar**

Ada dua kasus yang harus ditangani:

- Jika placeholder gambar sudah terisi dan direpresentasikan oleh sebuah [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), ganti gambar melalui [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#getPicture), dan [Picture.setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage).
- Jika masih berupa placeholder kosong, tambahkan bingkai gambar pada koordinat placeholder dengan [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) dan hapus placeholder kosong.

Contoh berikut mendukung kedua kasus dan menyimpan presentasi:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pengganti yang dibuat untuk placeholder kosong adalah bingkai gambar lokal, bukan placeholder baru, karena [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) tidak menyediakan setter. Ia menjaga posisi yang dicadangkan tetapi tidak lagi mewarisi perilaku khusus placeholder. Jika mempertahankan hubungan placeholder penting, persiapkan dan isi placeholder di PowerPoint terlebih dahulu, kemudian perbarui [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) yang dihasilkan dengan Aspose.Slides.

Untuk transparansi gambar, pemotongan, dan efek khusus gambar lainnya, lihat [Kelola Bingkai Gambar](/slides/id/nodejs-java/picture-frame/). Operasi tersebut termasuk ke dalam bingkai gambar atau isi gambar, bukan metadata placeholder.

## **Bekerja dengan Placeholder Grafik dan Konten**

Placeholder grafik yang terisi dapat direpresentasikan oleh sebuah [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/). Contoh ini menemukan grafik tersebut baik berdasarkan tipe placeholder maupun kelas runtime, mengubah judulnya, dan menyimpan file:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Placeholder konten umum biasanya memiliki [PlaceholderType.Object](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Object). Di PowerPoint ia berfungsi sebagai peluncur untuk beberapa tipe konten, termasuk grafik, tabel, diagram, gambar, dan media. Setelah terisi, periksa kelas bentuk aktual untuk mengetahui apa yang dikandungnya. Tata letak khusus juga dapat mengekspos [PlaceholderType.Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Media), atau [PlaceholderType.Diagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides tidak mengubah placeholder [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) kosong menjadi [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) hanya dengan mengubah [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType); tipe tidak dapat diubah melalui objek. Untuk mengisi area grafik atau konten kosong secara programatik, tambahkan objek yang diperlukan pada koordinat placeholder kemudian hapus placeholder kosong. Contoh berikut melakukan hal itu untuk sebuah grafik:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Grafik yang ditambahkan adalah grafik lokal biasa. Ia menempati area placeholder tetapi tidak mewarisi dari placeholder tata letak. Gunakan [artikel manajemen diagram](/slides/id/nodejs-java/powerpoint-charts/) ketika Anda perlu mengganti kategori, seri, atau data buku kerja grafik tersebut.

## **Contoh Lengkap: Memperbarui Konten Teks atau Gambar**

Contoh end-to-end berikut membuka sebuah templat, mencari placeholder judul atau gambar pada slide pertama, memeriksa tipe placeholder dan bentuk, memperbarui konten yang sesuai, dan menyimpan output. Contoh ini sengaja menghindari asumsi indeks bentuk atau memperlakukan setiap placeholder sebagai kelas yang sama.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apa itu placeholder dasar?**

Placeholder dasar adalah bentuk yang sesuai pada tata letak atau master dari mana placeholder lain mewarisi. Gunakan [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) untuk mengambilnya. Sebuah bentuk lokal biasa mengembalikan `null` karena tidak termasuk dalam hierarki placeholder.

**Apakah saya dapat mengubah semua judul slide dengan mengedit placeholder tata letak?**

Anda dapat mengubah pemformatan atau teks prompt yang diwarisi melalui tata letak, tetapi konten judul yang ada disimpan pada slide normal. Untuk mengganti teks judul aktual di seluruh presentasi, iterasi slide dan perbarui setiap placeholder judul.

**Bagaimana cara mengelola placeholder tanggal, nomor slide, header, dan footer?**

Gunakan manajer header dan footer pada ruang lingkup slide, tata letak, master, catatan, atau handout yang sesuai. Lihat [Kelola Header dan Footer Presentasi](/slides/id/nodejs-java/presentation-header-and-footer/) untuk contoh lengkap.