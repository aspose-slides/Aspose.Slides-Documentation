---
title: Kelola Node Bentuk SmartArt dalam Presentasi Menggunakan JavaScript
linktitle: Node Bentuk SmartArt
type: docs
weight: 30
url: /id/nodejs-java/manage-smartart-shape-node/
keywords:
- node SmartArt
- node anak
- tambahkan node
- posisi node
- akses node
- hapus node
- posisi kustom
- node asisten
- format isi
- render node
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola node bentuk SmartArt dalam PPT dan PPTX dengan Aspose.Slides untuk Node.js. Dapatkan contoh kode JavaScript yang jelas dan tips untuk menyederhanakan presentasi Anda."
---
## **Ikhtisar**

Grafik SmartArt dalam presentasi PowerPoint diatur melalui node yang berisi teks dan menentukan struktur diagram. Aspose.Slides memungkinkan Anda bekerja dengan node SmartArt ini secara programatis: menambahkan node baru dan node anak, menyisipkan node anak pada posisi tertentu, mengakses node yang ada, serta membaca teks, level, dan posisi mereka.

Artikel ini menjelaskan cara mengelola node bentuk SmartArt. Ia menunjukkan cara menghapus node, bekerja dengan node anak berdasarkan indeks atau posisi, mengubah node asisten menjadi node normal, menyesuaikan posisi, ukuran, dan rotasi bentuk node SmartArt, mengatur format isian node, dan menghasilkan gambar thumbnail untuk node anak SmartArt.

## **Menambahkan Node SmartArt dalam Presentasi PowerPoint menggunakan JavaScript**
Aspose.Slides untuk Node.js via Java telah menyediakan API termudah untuk mengelola bentuk SmartArt dengan cara paling mudah. Kode contoh berikut akan membantu menambahkan node dan node anak di dalam bentuk SmartArt.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) dan muat presentasi dengan bentuk SmartArt.
2. Dapatkan referensi slide pertama dengan menggunakan Index‑nya.
3. Telusuri setiap shape di dalam slide pertama.
4. Periksa apakah shape bertipe [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) dan lakukan typecast shape yang dipilih ke [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) jika memang SmartArt.
5. [Tambahkan Node baru](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) dalam bentuk SmartArt [**NodeCollection**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt#getAllNodes--) dan set teks di TextFrame.
6. Sekarang, [Tambahkan](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) sebuah [**Child Node**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) pada Node [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) yang baru ditambahkan dan set teks di TextFrame.
7. Simpan Presentasi.

```javascript
// Muat presentasi yang diinginkan
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Telusuri setiap shape di dalam slide pertama
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Periksa apakah shape bertipe SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Lakukan typecast shape ke SmartArt
            var smart = shape;
            // Menambahkan Node SmartArt baru
            var TemNode = smart.getAllNodes().addNode();
            // Menambahkan teks
            TemNode.getTextFrame().setText("Test");
            // Menambahkan child node baru dalam node induk. Akan ditambahkan di akhir koleksi
            var newNode = TemNode.getChildNodes().addNode();
            // Menambahkan teks
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // Menyimpan Presentasi
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menambahkan Node SmartArt pada Posisi Tertentu**
Dalam contoh kode berikut kami menjelaskan cara menambahkan node anak yang terkait dengan node masing‑masing dari bentuk SmartArt pada posisi tertentu.

1. Buat instance kelas Presentation.
2. Dapatkan referensi slide pertama dengan menggunakan Index‑nya.
3. Tambahkan sebuah shape [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) tipe [**StackedList**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) pada slide yang diakses.
4. Akses node pertama dalam shape SmartArt yang ditambahkan.
5. Sekarang, tambahkan [**Child Node**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) untuk [**Node**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArtNode) yang dipilih pada posisi 2 dan set teksnya.
6. Simpan Presentasi.

```javascript
// Membuat instance presentasi
var pres = new aspose.slides.Presentation();
try {
    // Mengakses slide presentasi
    var slide = pres.getSlides().get_Item(0);
    // Menambahkan Smart Art IShape
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Mengakses node SmartArt pada indeks 0
    var node = smart.getAllNodes().get_Item(0);
    // Menambahkan child node baru pada posisi 2 di node induk
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // Menambahkan Teks
    chNode.getTextFrame().setText("Sample Text Added");
    // Menyimpan Presentasi
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mengakses Node SmartArt dalam Presentasi PowerPoint menggunakan JavaScript**
Kode contoh berikut akan membantu mengakses node di dalam shape SmartArt. Harap dicatat bahwa Anda tidak dapat mengubah LayoutType SmartArt karena bersifat read‑only dan hanya diatur saat shape SmartArt ditambahkan.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation) dan muat presentasi dengan shape SmartArt.
2. Dapatkan referensi slide pertama dengan menggunakan Index‑nya.
3. Telusuri setiap shape di dalam slide pertama.
4. Periksa apakah shape bertipe [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) dan lakukan typecast shape yang dipilih ke [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) jika memang SmartArt.
5. Telusuri semua [**Nodes**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt#getAllNodes--) di dalam shape SmartArt.
6. Akses dan tampilkan informasi seperti posisi Node SmartArt, level, dan Teks.

```javascript
// Instansiasi Kelas Presentation
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // Dapatkan slide pertama
    var slide = pres.getSlides().get_Item(0);
    // Telusuri setiap shape di dalam slide pertama
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Periksa apakah shape bertipe SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Lakukan typecast shape ke SmartArt
            var smart = shape;
            // Telusuri semua node di dalam SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // Mengakses node SmartArt pada indeks i
                var node = smart.getAllNodes().get_Item(j);
                // Mencetak parameter node SmartArt
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mengakses Child Node SmartArt**
Kode contoh berikut akan membantu mengakses child node yang terkait dengan node masing‑masing dari shape SmartArt.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation) dan muat presentasi dengan shape SmartArt.
2. Dapatkan referensi slide pertama dengan menggunakan Index‑nya.
3. Telusuri setiap shape di dalam slide pertama.
4. Periksa apakah shape bertipe [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) dan lakukan typecast shape yang dipilih ke [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) jika memang SmartArt.
5. Telusuri semua [**Nodes**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt#getAllNodes--) di dalam shape SmartArt.
6. Untuk setiap [**Node**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArtNode) SmartArt yang dipilih, telusuri semua [**Child Nodes**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) di dalam node tertentu.
7. Akses dan tampilkan informasi seperti posisi, level, dan Teks [**Child Node**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--).

```javascript
// Instansiasi Kelas Presentation
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // Dapatkan slide pertama
    var slide = pres.getSlides().get_Item(0);
    // Menelusuri setiap shape di dalam slide pertama
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // Periksa apakah shape bertipe SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Lakukan typecast shape ke SmartArt
            var smart = shape;
            // Menelusuri semua node di dalam SmartArt
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // Mengakses node SmartArt pada indeks i
                var node0 = smart.getAllNodes().get_Item(i);
                // Menelusuri child node dalam node SmartArt pada indeks i
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // Mengakses child node dalam node SmartArt
                    var node = node0.getChildNodes().get_Item(j);
                    // Mencetak parameter child node SmartArt
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mengakses Child Node SmartArt pada Posisi Tertentu**
Dalam contoh ini, kita akan mempelajari cara mengakses child node pada posisi tertentu yang terkait dengan node masing‑masing dari shape SmartArt.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
2. Dapatkan referensi slide pertama dengan menggunakan Index‑nya.
3. Tambahkan sebuah shape SmartArt tipe [**StackedList**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList).
4. Akses shape SmartArt yang ditambahkan.
5. Akses node pada indeks 0 untuk shape SmartArt yang diakses.
6. Sekarang, akses [**Child Node**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) pada posisi 1 untuk node SmartArt yang diakses menggunakan metode **get_Item()**.
7. Akses dan tampilkan informasi seperti posisi, level, dan Teks [**Child Node**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--).

```javascript
// Instansiasi presentasi
var pres = new aspose.slides.Presentation();
try {
    // Mengakses slide pertama
    var slide = pres.getSlides().get_Item(0);
    // Menambahkan shape SmartArt di slide pertama
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Mengakses node SmartArt pada indeks 0
    var node = smart.getAllNodes().get_Item(0);
    // Mengakses child node pada posisi 1 di node induk
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // Mencetak parameter child node SmartArt
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menghapus Node SmartArt dalam Presentasi PowerPoint menggunakan JavaScript**
Dalam contoh ini, kita akan mempelajari cara menghapus node di dalam shape SmartArt.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation) dan muat presentasi dengan shape SmartArt.
2. Dapatkan referensi slide pertama dengan menggunakan Index‑nya.
3. Telusuri setiap shape di dalam slide pertama.
4. Periksa apakah shape bertipe [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) dan lakukan typecast shape yang dipilih ke [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) jika memang SmartArt.
5. Periksa apakah [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) memiliki lebih dari 0 node.
6. Pilih node SmartArt yang akan dihapus.
7. Sekarang, hapus node yang dipilih menggunakan metode [**RemoveNode**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-).
8. Simpan Presentasi.

```javascript
// Muat presentasi yang diinginkan
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Telusuri setiap shape di dalam slide pertama
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Periksa apakah shape bertipe SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Lakukan typecast shape ke SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Mengakses node SmartArt pada indeks 0
                var node = smart.getAllNodes().get_Item(0);
                // Menghapus node yang dipilih
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // Simpan Presentasi
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menghapus Node SmartArt pada Posisi Tertentu**
Dalam contoh ini, kita akan mempelajari cara menghapus node di dalam shape SmartArt pada posisi tertentu.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation) dan muat presentasi dengan shape SmartArt.
2. Dapatkan referensi slide pertama dengan menggunakan Index‑nya.
3. Telusuri setiap shape di dalam slide pertama.
4. Periksa apakah shape bertipe [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) dan lakukan typecast shape yang dipilih ke [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) jika memang SmartArt.
5. Pilih node shape SmartArt pada indeks 0.
6. Sekarang, periksa apakah node SmartArt yang dipilih memiliki lebih dari 2 child node.
7. Sekarang, hapus node pada **Posisi 1** menggunakan metode [**RemoveNode**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-).
8. Simpan Presentasi.

```javascript
// Muat presentasi yang diinginkan
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Telusuri setiap shape di dalam slide pertama
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Periksa apakah shape bertipe SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Lakukan typecast shape ke SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Mengakses node SmartArt pada indeks 0
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // Menghapus child node pada posisi 1
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // Simpan Presentasi
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menetapkan Posisi Kustom untuk Child Node dalam SmartArt**
Sekarang Aspose.Slides untuk Node.js via Java mendukung pengaturan properti [SmartArtShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#setX-float-) dan [Y](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#setY-float-). Potongan kode di bawah ini menunjukkan cara mengatur posisi, ukuran, dan rotasi SmartArtShape secara kustom, juga perhatikan bahwa menambahkan node baru menyebabkan perhitungan ulang posisi dan ukuran semua node. Dengan pengaturan posisi kustom, pengguna dapat mengatur node sesuai kebutuhan.

```javascript
// Instansiasi Kelas Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // Pindahkan shape SmartArt ke posisi baru
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // Ubah lebar shape SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // Ubah tinggi shape SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // Ubah rotasi shape SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Memeriksa Node Asisten**
{{% alert color="primary" %}} 

Dalam artikel ini kami akan menyelidiki lebih lanjut fitur-fitur shape SmartArt yang ditambahkan ke slide presentasi secara programatis menggunakan Aspose.Slides untuk Node.js via Java.

{{% /alert %}} 

Kami akan menggunakan shape SmartArt sumber berikut untuk penyelidikan kami dalam berbagai bagian artikel ini.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Gambar: Shape SmartArt sumber dalam slide**|

Dalam contoh kode berikut kami akan menyelidiki cara mengidentifikasi **Assistant Nodes** dalam koleksi node SmartArt dan mengubahnya.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation) dan muat presentasi dengan shape SmartArt.
2. Dapatkan referensi slide kedua dengan menggunakan Index‑nya.
3. Telusuri setiap shape di dalam slide pertama.
4. Periksa apakah shape bertipe [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) dan lakukan typecast shape yang dipilih ke [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) jika memang SmartArt.
5. Telusuri semua node di dalam shape SmartArt dan periksa apakah mereka merupakan [**Assistant Nodes**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArtNode#isAssistant--).
6. Ubah status Assistant Node menjadi node normal.
7. Simpan Presentasi.

```javascript
// Membuat instance presentasi
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // Menelusuri setiap shape di dalam slide pertama
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Periksa apakah shape bertipe SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Lakukan typecast shape ke SmartArt
            var smart = shape;
            // Menelusuri semua node dari shape SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // Periksa apakah node adalah node Asisten
                if (node.isAssistant()) {
                    // Mengatur node Asisten menjadi false dan menjadikannya node normal
                    node.isAssistant();
                }
            }
        }
    }
    // Simpan Presentasi
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Gambar: Assistant Nodes Diubah dalam shape SmartArt di dalam slide**|

## **Mengatur Format Isian Node**
Aspose.Slides untuk Node.js via Java memungkinkan penambahan shape SmartArt kustom dan pengaturan format isian mereka. Artikel ini menjelaskan cara membuat dan mengakses shape SmartArt serta mengatur format isian menggunakan Aspose.Slides untuk Node.js via Java.

Silakan ikuti langkah‑langkah di bawah ini:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
2. Dapatkan referensi slide menggunakan indeksnya.
3. Tambahkan shape [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) dengan menetapkan [**LayoutType**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
4. Atur [**FillFormat**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#getFillFormat--) untuk node shape SmartArt.
5. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

```javascript
// Instansiasi presentasi
var pres = new aspose.slides.Presentation();
try {
    // Mengakses slide
    var slide = pres.getSlides().get_Item(0);
    // Menambahkan shape SmartArt dan node
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // Mengatur warna isi node
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // Simpan presentasi
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menghasilkan Thumbnail Child Node SmartArt**
Pengembang dapat menghasilkan thumbnail dari Child node SmartArt dengan mengikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
2. [Tambahkan SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--).
3. Dapatkan referensi sebuah node dengan menggunakan Index‑nya.
4. Dapatkan gambar thumbnail.
5. Simpan gambar thumbnail dalam format gambar apa pun yang diinginkan.

```javascript
// Instansiasi kelas Presentation yang mewakili file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Tambahkan SmartArt
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // Dapatkan referensi node dengan menggunakan indeksnya
    var node = smart.getNodes().get_Item(1);
    // Dapatkan thumbnail
    var slideImage = node.getShapes().get_Item(0).getImage();
    // Simpan thumbnail
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah animasi SmartArt didukung?**

Ya. SmartArt diperlakukan sebagai shape biasa, sehingga Anda dapat [menerapkan animasi standar](/slides/id/nodejs-java/shape-animation/) (masuk, keluar, penekanan, jalur gerak) dan menyesuaikan timing. Anda juga dapat menganimasikan shape di dalam node SmartArt bila diperlukan.

**Bagaimana saya dapat secara andal menemukan SmartArt tertentu pada slide jika ID internalnya tidak diketahui?**

Berikan dan cari menggunakan [teks alternatif](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/getalternativetext/). Menetapkan AltText yang khas pada SmartArt memungkinkan Anda menemukannya tanpa bergantung pada pengidentifikasi internal.

**Apakah tampilan SmartArt akan dipertahankan saat mengonversi presentasi ke PDF?**

Ya. Aspose.Slides merender SmartArt dengan fidelitas visual tinggi selama [ekspor PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/), mempertahankan tata letak, warna, dan efek.

**Dapatkah saya mengekstrak gambar seluruh SmartArt (untuk preview atau laporan)?**

Ya. Anda dapat merender shape SmartArt ke [format raster](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getImage) atau ke [SVG](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/writeassvg/) untuk output vektor yang dapat diskalakan, menjadikannya cocok untuk thumbnail, laporan, atau penggunaan web.