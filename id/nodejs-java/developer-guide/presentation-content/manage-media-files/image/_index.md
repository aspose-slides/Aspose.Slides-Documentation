---
title: Optimalkan Manajemen Gambar dalam Presentasi Menggunakan JavaScript
linktitle: Kelola Gambar
type: docs
weight: 10
url: /id/nodejs-java/image/
keywords:
- menambahkan gambar
- menambahkan gambar
- mengganti gambar
- koleksi gambar
- bingkai gambar
- gambar tertaut
- latar belakang
- menambahkan PNG
- menambahkan JPG
- menambahkan SVG
- SVG ke bentuk
- sumber daya SVG eksternal
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara menambahkan, menggunakan kembali, menautkan, mengganti, dan mengelola gambar raster serta SVG dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Node.js via Java."
---
## **Pendahuluan**

Aspose.Slides untuk Node.js via Java menyediakan beberapa cara untuk bekerja dengan gambar, dan masing‑masing melayani tujuan yang berbeda. Anda dapat menyimpan gambar dalam presentasi, menampilkannya dalam bingkai gambar, menggunakannya sebagai latar belakang slide, menautkan ke gambar eksternal, mengganti sumber daya gambar yang berbagi, atau mengonversi konten SVG menjadi bentuk yang dapat diedit.

Artikel ini berfokus pada sumber daya gambar dan cara penggunaannya dalam sebuah presentasi. Untuk memotong, transparansi, efek, peregangan, dan pemformatan lain yang diterapkan pada bingkai gambar individu, lihat [Picture Frame](/slides/id/nodejs-java/picture-frame/).

## **Memahami Model Gambar**

Konsep API berikut saling terkait tetapi tidak dapat dipertukarkan:

- Koleksi gambar presentasi ([presentation image collection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagecollection/)) menyimpan sumber daya gambar yang digunakan oleh presentasi. Gunakan [ImageCollection.addImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagecollection/) untuk menambahkan data gambar dan memperoleh sumber daya [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/).
- Sebuah [picture frame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/) adalah bentuk yang menampilkan gambar pada slide, tata letak, atau master. Gunakan [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/) untuk menempatkan sumber daya gambar pada slide.
- Latar belakang slide menggunakan gambar sebagai bagian dari isian slide alih‑alih sebagai bentuk. Oleh karena itu tidak berperilaku seperti bingkai gambar.
- [PPImage.replaceImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) mengganti sumber daya gambar. Jika beberapa elemen presentasi menggunakan sumber daya tersebut, semuanya akan menggunakan penggantiannya.
- Mengonversi SVG menjadi bentuk menciptakan bentuk slide yang dapat diedit. Setelah konversi, konten tidak lagi dikelola sebagai satu sumber daya gambar.

Alur kerja tipikalnya adalah: tambahkan data gambar ke koleksi gambar, terima sebuah [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/), lalu gunakan sumber daya itu dalam satu atau beberapa bingkai gambar atau isian.

## **Menambahkan Gambar Tersemat**

Untuk menyisipkan gambar lokal, muat file, tambahkan ke koleksi gambar, dan buat bingkai gambar yang menggunakan sumber daya [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) yang dikembalikan.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gambar yang ditambahkan dengan cara ini tersemat dalam presentasi, sehingga file yang dihasilkan tidak bergantung pada ketersediaan file gambar asli.

### **Menambahkan Gambar dari Web**

Ketika gambar tersedia melalui HTTP atau HTTPS, unduh byte‑nya, tambahkan ke koleksi gambar presentasi, dan gunakan sumber daya gambar yang dikembalikan dengan cara yang sama seperti gambar lokal.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const http = require("http");
const https = require("https");
const java = require("java");

function downloadBytes(url) {
    return new Promise((resolve, reject) => {
        const client = url.startsWith("https:") ? https : http;
        client.get(url, (response) => {
            if (response.statusCode < 200 || response.statusCode >= 300) {
                response.resume();
                reject(new Error(`HTTP ${response.statusCode}`));
                return;
            }

            const chunks = [];
            response.on("data", (chunk) => chunks.push(chunk));
            response.on("end", () => resolve(Buffer.concat(chunks)));
        }).on("error", reject);
    });
}

(async () => {
    const imageData = await downloadBytes("https://example.com/image.png");
    const javaBytes = java.newArray("byte", Array.from(imageData));

    const presentation = new aspose.slides.Presentation();
    try {
        const image = presentation.getImages().addImage(javaBytes);
        const slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

        presentation.save("presentation-from-web.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
})();
```

Dalam aplikasi yang berjalan lama, gunakan kembali klien HTTP atau strategi manajemen koneksi yang sesuai dengan aplikasi daripada terus‑menerus membuat infrastruktur jaringan yang tidak diperlukan. Juga validasi URL remote, ukuran respons, dan tipe konten ketika sumbernya tidak dapat dipercaya.

## **Gunakan Ulang Gambar di Seluruh Slide**

Jika gambar yang sama diperlukan lebih dari satu kali, tambahkan ke presentasi satu kali dan gunakan kembali [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) yang dikembalikan saat membuat bingkai gambar tambahan. Hal ini menghindari pemuatan berulang data sumber yang sama dan menjadikan hubungan antara sumber daya gambar berbagi dan penggunaannya menjadi eksplisit.

Untuk grafis yang harus muncul secara otomatis pada banyak slide, seperti logo perusahaan, pertimbangkan menempatkan bingkai gambar pada [slide master](/slides/id/nodejs-java/slide-master/) atau tata letak alih‑alih menambahkan bentuk setara pada setiap slide.

## **Gunakan Gambar sebagai Latar Belakang Slide**

Gambar latar belakang ditetapkan pada isian slide; ia tidak ditambahkan sebagai bentuk bingkai gambar. Ini berguna ketika gambar harus menutupi latar belakang slide dan tidak boleh dimanipulasi sebagai objek slide biasa.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().setType(backgroundType);

    const fillType = java.newByte(aspose.slides.FillType.Picture);
    slide.getBackground().getFillFormat().setFillType(fillType);

    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk opsi latar belakang tambahan, termasuk latar belakang master dan tata letak, lihat [Presentation Background](/slides/id/nodejs-java/presentation-background/).

## **Gambar Tersemat dan Gambar Tertaut**

Gambar tersemat dan gambar tertaut memiliki pertukaran portabilitas dan ukuran file yang berbeda:

- **Gambar tersemat:** data gambar disimpan di dalam presentasi. Presentasi menjadi mandiri, tetapi ukuran file mencakup data gambar.
- **Gambar tertaut:** presentasi menyimpan jalur atau URL ke gambar eksternal. Ini dapat mengurangi ukuran presentasi, tetapi sumber eksternal harus tetap dapat diakses saat presentasi dibuka atau dirender.

Sebuah gambar tertaut dapat dibuat dengan menetapkan jalur atau URL eksternal melalui [Picture.setLinkPathLong](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picture/) alih‑alih menanamkan data gambar.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gunakan gambar tertaut hanya ketika lingkungan penyebaran dapat dengan andal mengakses sumber eksternal. Untuk presentasi yang harus berfungsi secara offline atau dipindahkan antar sistem, gambar tersemat biasanya lebih aman.

## **Bekerja dengan Gambar SVG**

SVG adalah format vektor, sehingga berguna untuk ikon, diagram, dan grafis lain yang harus diskalakan tanpa kehilangan detail seperti gambar raster. Aspose.Slides mendukung SVG baik sebagai sumber daya gambar maupun sebagai sumber untuk bentuk slide yang dapat diedit.

### **Menambahkan SVG sebagai Gambar**

Buat sebuah [SvgImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/svgimage/), tambahkan ke koleksi gambar, dan tempatkan sumber daya gambar yang dihasilkan dalam sebuah bingkai gambar.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("icon.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const image = presentation.getImages().addImage(svgImage);
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **File SVG dengan Sumber Daya Eksternal**

Sebuah SVG dapat merujuk ke gambar, stylesheet, atau font eksternal. Untuk kasus ini, [SvgImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/svgimage/) menyediakan konstruktor yang menerima sebuah [ExternalResourceResolver](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/externalresourceresolver/) dan URI dasar. Resolver dapat memetakan URI relatif ke URI absolut yang diizinkan dan mengembalikan aliran untuk sumber daya yang diminta.

Resolver membuat sumber daya eksternal tersedia saat Aspose.Slides memproses SVG, tetapi tidak menulis ulang SVG menjadi dokumen mandiri. Jika SVG harus tetap portabel, tanamkan sumber daya yang diperlukan ke dalam SVG itu sendiri, misalnya dengan menggunakan `data:` URI untuk gambar tertaut.

Saat file SVG berasal dari sumber yang tidak dipercaya, batasi skema, lokasi file, dan host yang dapat diakses resolver. Resolver jaringan juga harus menerapkan batas waktu, batas ukuran respons, dan validasi konten.

### **Mengonversi SVG menjadi Bentuk yang Dapat Diedit**

Aspose.Slides dapat mengonversi SVG menjadi sekumpulan bentuk slide yang dapat diedit, serupa dengan perintah PowerPoint yang bersangkutan.

![PowerPoint Popup Menu](img_01_01.png)

Gunakan overload [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/) yang menerima gambar SVG untuk melakukan konversi.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("diagram.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const slideSize = presentation.getSlideSize().getSize();
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, slideSize.getWidth(), slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gunakan konversi SVG‑ke‑bentuk ketika elemen vektor individu perlu diedit sebagai bentuk PowerPoint. Jika SVG hanya perlu ditampilkan, menyimpannya sebagai gambar lebih sederhana dan menghindari pembuatan banyak bentuk terpisah.

## **Mengganti Sumber Daya Gambar yang Ada**

Gunakan [PPImage.replaceImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) ketika Anda ingin mengganti sumber daya gambar yang ada. Ini sangat berguna untuk grafis berbagi seperti logo.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const imageToReplace = presentation.getImages().get_Item(0);

    const replacementImage = aspose.slides.Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) {
            replacementImage.dispose();
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jika beberapa bingkai gambar, latar belakang, master, atau tata letak menggunakan sumber daya gambar yang sama, mengganti sumber daya tersebut memperbarui semua penggunaan itu. Jika hanya satu bingkai gambar yang harus berubah, tetapkan gambar yang berbeda ke bingkai itu alih‑alih mengganti sumber daya bersama.

[PPImage.replaceImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) juga menyediakan overload yang menerima array byte atau [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) lain.

## **Panduan Praktis Manajemen Gambar**

### **Mengontrol Ukuran Presentasi**

Gambar raster besar dapat membuat presentasi menjadi terlalu besar. Gunakan gambar sumber dengan dimensi yang sesuai untuk ukuran tampilan yang dimaksud, gunakan kembali sumber daya gambar berbagi bila memungkinkan, dan hindari menanamkan salinan berulang dari grafis resolusi penuh yang sama.

Untuk gambar raster yang sudah ditempatkan dalam bingkai gambar, [PictureFillFormat.compressImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/) dapat mengurangi data gambar sesuai dengan resolusi dan pengaturan pemotongan yang dipilih. Ini merupakan pemrosesan bingkai gambar, bukan manajemen koleksi gambar, jadi lihat [Picture Frame](/slides/id/nodejs-java/picture-frame/) untuk operasi pemformatan terkait.

### **Pilih antara Konten Tersemat dan Tertaut**

Menanamkan membuat presentasi portabel karena semua data gambar yang diperlukan ikut bersama file. Menautkan dapat mengurangi ukuran file, tetapi memperkenalkan ketergantungan eksternal. Gunakan tautan hanya ketika ketergantungan itu dapat diterima dan stabil.

### **Gunakan Ulang Branding Bersama**

Untuk logo, watermark, atau grafis dekoratif yang berulang, gunakan satu sumber daya gambar dan gunakan kembali. Jika grafis tersebut merupakan bagian dari desain presentasi bukan konten slide, letakkan pada master atau tata letak sehingga diwariskan ke slide yang sesuai.

### **Jaga Sumber Daya SVG Tetap Portabel**

SVG yang mandiri lebih mudah dipindahkan dan dirender secara konsisten dibandingkan SVG yang bergantung pada file atau sumber daya jaringan eksternal. Bila memungkinkan, tanamkan sumber daya yang diperlukan sebelum mengimpor SVG. Konversi SVG ke bentuk hanya ketika elemen vektor individu perlu diedit.

### **Gunakan API Gambar Lintas Platform Modern**

Untuk kode Node.js via Java baru, gunakan API Aspose.Slides [IImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/) dan [Images](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/images/) alih‑alih API publik warisan yang berbasis `java.awt.image.BufferedImage`. Lihat [Modern API](/slides/id/nodejs-java/modern-api/) untuk panduan migrasi.

WMF dan EMF memerlukan pertimbangan khusus. Ketika format ini dilewatkan melalui sebuah [IImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/), [ImageCollection.addImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagecollection/) mengonversi metafile menjadi representasi PNG raster sebelum penyisipan. Jika mempertahankan data metafile penting, gunakan overload berbasis aliran dari [ImageCollection.addImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagecollection/) sebagai gantinya. Membuat konten EMF dari spreadsheet atau produk lain merupakan alur kerja integrasi terpisah dan berada di luar lingkup artikel ini.

## **FAQ**

**Apa perbedaan antara koleksi gambar dan bingkai gambar?**

Koleksi gambar menyimpan sumber daya gambar yang dapat digunakan kembali. Sebuah bingkai gambar adalah bentuk slide yang menampilkan salah satu sumber daya tersebut dan menyediakan pemformatan khusus gambar seperti pemotongan dan efek.

**Apa cara terbaik untuk mengganti logo yang sama di semua tempat?**

Jika logo sudah berbagi sebagai satu sumber daya gambar, ganti sumber daya tersebut dengan [PPImage.replaceImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/). Untuk branding seluruh presentasi, menempatkan logo pada master atau tata letak juga dapat mengurangi duplikasi konten slide.

**Mengapa gambar tertaut menghilang di komputer lain?**

Gambar tertaut bergantung pada file atau URL eksternal. Jika sumber daya tersebut tidak dapat dijangkau dari komputer lain, gambar tertaut tidak akan tersedia. Tanamkan gambar ketika presentasi harus mandiri.

**Apakah SVG yang dimasukkan dapat diedit sebagai bentuk PowerPoint?**

Ya. Konversikan SVG dengan [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/); grup yang dihasilkan berisi bentuk slide yang dapat diedit, bukan satu gambar SVG.

**Bagaimana saya dapat menjaga presentasi dengan banyak gambar tetap kecil?**

Gunakan kembali sumber daya gambar berbagi, hindari sumber raster yang terlalu besar, kompres gambar raster yang cocok bila perlu, letakkan branding berulang pada master atau tata letak, dan gunakan gambar tertaut hanya ketika ketergantungan eksternal dapat diterima.