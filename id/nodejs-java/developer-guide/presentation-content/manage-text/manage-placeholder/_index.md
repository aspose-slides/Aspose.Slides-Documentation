---
title: Kelola Placeholder Presentasi di JavaScript
linktitle: Kelola Placeholder
type: docs
weight: 10
url: /id/nodejs-java/manage-placeholder/
keywords:
- placeholder
- placeholder teks
- placeholder gambar
- placeholder diagram
- placeholder konten
- teks prompt
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara memeriksa dan mengedit placeholder teks, gambar, diagram, dan konten serta memahami pewarisan placeholder dengan Aspose.Slides untuk Node.js melalui Java."
---
## **Gambaran Umum**

Placeholder adalah bentuk yang memesan posisi untuk jenis konten tertentu dalam templat presentasi. Contoh umum meliputi placeholder judul, badan, gambar, diagram, dan placeholder konten umum. Tidak seperti bentuk biasa, placeholder dapat mewarisi posisi, ukuran, pemformatan, dan pengaturan lainnya dari slide tata letak atau slide master.

Aspose.Slides mengekspos informasi placeholder melalui metode [Shape.getPlaceholder](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getPlaceholder). Metode tersebut mengembalikan objek [Placeholder](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/placeholder/) atau `null` untuk bentuk biasa. Gunakan [Placeholder.getType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/placeholder/#getType) untuk menentukan apa yang dimaksudkan untuk ditempatkan dalam placeholder.

Kelas bentuk tetap penting setelah Anda mengetahui tipe placeholder:

- Placeholder teks, gambar, diagram, atau konten yang kosong biasanya direpresentasikan oleh sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/).
- Placeholder gambar yang telah terisi dapat direpresentasikan oleh sebuah [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/).
- Placeholder diagram yang telah terisi dapat direpresentasikan oleh sebuah [Chart](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/).
- Placeholder konten dapat berisi beberapa jenis konten. Periksa baik [Placeholder.getType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/placeholder/#getType) maupun kelas bentuk pada waktu proses alih-alih mengasumsikan setiap placeholder adalah sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/placeholder/#getType) menjelaskan peran placeholder; tidak menjamin tipe bentuk pada waktu proses. Selalu gunakan pemeriksaan tipe sebelum mengakses anggota teks, gambar, diagram, tabel, atau media khusus.
{{% /alert %}}

## **Memahami Pewarisan Placeholder**

Placeholder membentuk hierarki:

1. Slide master mendefinisikan gaya yang dapat digunakan kembali dan, dalam beberapa kasus, placeholder tingkat master.
2. Slide tata letak mendefinisikan susunan yang digunakan oleh satu atau lebih slide biasa dan dapat mewarisi dari master.
3. Slide biasa berisi placeholder untuk slide tersebut dan dapat mewarisi dari tata letaknya.

Panggil [Shape.getBasePlaceholder](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getBasePlaceholder) untuk naik satu tingkat dalam hierarki ini. Placeholder slide biasanya mengembalikan placeholder tata letaknya; placeholder tata letak dapat mengembalikan placeholder masternya. Metode ini mengembalikan `null` ketika bentuk tidak memiliki placeholder dasar.

Contoh berikut menampilkan daftar placeholder pada slide pertama dan melaporkan placeholder dasar mereka:

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

Mengedit placeholder pada slide biasa membuat atau mengubah penimpaan lokal untuk slide tersebut. Mengedit tata letak atau master yang terkait dapat memengaruhi semua slide yang masih mewarisi pengaturan tersebut. Sebuah bentuk lokal biasa tidak memiliki placeholder dasar dan tidak mulai mewarisi hanya karena menempati koordinat yang sama.

## **Mengubah Teks dalam Placeholder**

Placeholder judul, judul-tengah, subjudul, badan, dan teks biasanya mendukung teks. Periksa apakah itu [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) sebelum menggunakan metode [getTextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/#getTextFrame).

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

Pola ini menghindari memperlakukan placeholder gambar, diagram, tabel, atau media sebagai objek [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/). Ini juga mengidentifikasi placeholder berdasarkan tujuan alih-alih bergantung pada indeks bentuk yang rapuh.

## **Menetapkan Teks Prompt pada Tata Letak**

Teks prompt adalah instruksi waktu-desain yang ditampilkan dalam placeholder kosong, seperti *Click to add title*. Tetapkan teks prompt khusus pada placeholder tata letak alih-alih mencoba mengaksesnya melalui koleksi bentuk slide biasa. Akses tata letak melalui [Slide.getLayoutSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/#getLayoutSlide) dan iterasi koleksi yang dikembalikan oleh [BaseSlide.getShapes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslide/#getShapes).

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

Teks prompt bukan konten slide biasa. Itu dimaksudkan untuk placeholder kosong dalam aplikasi penyunting seperti PowerPoint. Setelah pengguna atau program menyediakan konten sebenarnya, prompt tidak lagi ditampilkan. Mengubah prompt juga tidak menggantikan teks yang ada pada slide yang menggunakan tata letak tersebut.

## **Memperbarui Placeholder Gambar**

Ada dua kasus yang perlu ditangani:

- Jika placeholder gambar sudah terisi dan direpresentasikan oleh sebuah [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/), ganti gambar melalui [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#getPicture), dan [Picture.setImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picture/#setImage).
- Jika masih berupa placeholder kosong, tambahkan sebuah picture frame pada koordinat placeholder dengan [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) dan hapus placeholder kosong tersebut.

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

Penggantian yang dibuat untuk placeholder kosong adalah sebuah picture frame lokal, bukan placeholder baru, karena [Shape.getPlaceholder](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getPlaceholder) tidak menyediakan setter. Itu mempertahankan posisi yang dipesan tetapi tidak lagi mewarisi perilaku khusus placeholder. Jika mempertahankan hubungan placeholder penting, siapkan dan isi placeholder di PowerPoint terlebih dahulu, kemudian perbarui [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/) yang dihasilkan dengan Aspose.Slides.

Untuk transparansi gambar, pemotongan, dan efek khusus gambar lainnya, lihat [Manage Picture Frames](/slides/id/nodejs-java/picture-frame/). Operasi tersebut merupakan milik picture frame atau picture fill, bukan metadata placeholder.

## **Bekerja dengan Placeholder Diagram dan Konten**

Placeholder diagram yang terisi dapat direpresentasikan oleh sebuah [Chart](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/). Contoh ini menemukan diagram tersebut dengan tipe placeholder dan kelas runtime, mengubah judulnya, dan menyimpan file:

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

Placeholder konten umum biasanya memiliki [PlaceholderType.Object](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/placeholdertype/#Object). Di PowerPoint, ia berfungsi sebagai peluncur untuk beberapa jenis konten, termasuk diagram, tabel, diagram, gambar, dan media. Setelah terisi, periksa kelas bentuk sebenarnya untuk mengetahui apa yang dikandungnya. Tata letak khusus juga dapat menampilkan [PlaceholderType.Chart](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/placeholdertype/#Media), atau [PlaceholderType.Diagram](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides tidak mengubah placeholder [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) yang kosong menjadi [Chart](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/) hanya dengan mengubah [Placeholder.getType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/placeholder/#getType); tipe tidak dapat diubah melalui objek. Untuk mengisi area diagram atau konten kosong secara programatis, tambahkan objek yang diperlukan pada koordinat placeholder kemudian hapus placeholder kosong. Contoh berikut melakukan hal itu untuk sebuah diagram:

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

Diagram yang ditambahkan adalah diagram lokal biasa. Ia menempati area placeholder tetapi tidak mewarisi dari placeholder tata letak. Gunakan artikel manajemen diagram khusus [chart management articles](/slides/id/nodejs-java/powerpoint-charts/) ketika Anda perlu mengganti kategori, seri, atau data workbook-nya.

## **Contoh Lengkap: Memperbarui Konten Teks atau Gambar**

Contoh end-to-end berikut membuka templat, mencari slide pertama untuk placeholder judul atau gambar, memeriksa tipe placeholder dan bentuk, memperbarui konten yang sesuai, dan menyimpan hasilnya. Contoh ini sengaja menghindari asumsi indeks bentuk atau memperlakukan setiap placeholder sebagai kelas yang sama.

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

## **Tanya Jawab**

**Apa itu placeholder dasar?**

Placeholder dasar adalah bentuk yang bersesuaian pada tata letak atau master yang menjadi sumber warisan bagi placeholder lain. Gunakan [Shape.getBasePlaceholder](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getBasePlaceholder) untuk mengambilnya. Sebuah bentuk lokal biasa mengembalikan `null` karena tidak termasuk dalam hierarki placeholder.

**Apakah saya dapat mengubah semua judul slide dengan menyunting placeholder tata letak?**

Anda dapat mengubah pemformatan atau teks prompt yang diwarisi melalui tata letak, tetapi konten judul yang ada disimpan pada slide biasa. Untuk mengganti teks judul sebenarnya di seluruh presentasi, iterasi slide dan perbarui setiap placeholder judul.

**Bagaimana cara mengelola placeholder tanggal, nomor slide, header, dan footer?**

Gunakan pengelola header dan footer pada slide, tata letak, master, catatan, atau lembaran tangan yang sesuai. Lihat [Manage Presentation Header and Footer](/slides/id/nodejs-java/presentation-header-and-footer/) untuk contoh lengkap.