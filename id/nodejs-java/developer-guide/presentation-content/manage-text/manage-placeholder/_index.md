---
title: Kelola Placeholder Presentasi dengan JavaScript
linktitle: Kelola Placeholder
type: docs
weight: 10
url: /id/nodejs-java/manage-placeholder/
keywords:
- placeholder
- placeholder teks
- placeholder gambar
- placeholder bagan
- teks prompt
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola placeholder dengan mudah di Aspose.Slides untuk Node.js via Java: ganti teks, sesuaikan prompt, dan atur transparansi gambar dalam PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengelola placeholder presentasi secara programatis. Artikel ini menjelaskan cara menemukan placeholder pada slide dan mengubah teksnya, menetapkan teks prompt khusus untuk tata letak placeholder, serta menyesuaikan transparansi gambar yang digunakan sebagai latar belakang placeholder. Juga mencakup FAQ singkat yang menjelaskan perbedaan antara placeholder dasar dan bentuk lokal, menjelaskan bagaimana perubahan placeholder dapat diterapkan melalui tata letak atau master, serta mengarahkan ke pengelolaan placeholder header dan footer.

## **Ubah Teks dalam Placeholder**

Menggunakan [Aspose.Slides for Node.js via Java](/slides/id/nodejs-java/), Anda dapat menemukan dan memodifikasi placeholder pada slide dalam presentasi. Aspose.Slides memungkinkan Anda melakukan perubahan pada teks dalam placeholder.

**Prasyarat**: Anda memerlukan sebuah presentasi yang berisi placeholder. Anda dapat membuat presentasi tersebut menggunakan aplikasi Microsoft PowerPoint standar.

Berikut cara Anda menggunakan Aspose.Slides untuk mengganti teks dalam placeholder pada presentasi tersebut:

1. Instansiasi kelas `Presentation` dan berikan presentasi sebagai argumen.
2. Dapatkan referensi slide melalui indeksnya.
3. Iterasi melalui shape untuk menemukan placeholder.
4. Lakukan typecast shape placeholder menjadi `AutoShape` dan ubah teksnya menggunakan `TextFrame` yang terkait dengan `AutoShape`.
5. Simpan presentasi yang telah dimodifikasi.

Kode JavaScript ini menunjukkan cara mengubah teks dalam placeholder:

```javascript
// Membuat instance kelas Presentation
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // Mengakses slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Iterasi melalui shape untuk menemukan placeholder
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // Mengubah teks pada setiap placeholder
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // Menyimpan presentasi ke disk
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Atur Teks Prompt dalam Placeholder**

Tata letak standar dan yang sudah dibangun sebelumnya berisi teks prompt placeholder seperti ***Click to add a title*** atau ***Click to add a subtitle***. Dengan Aspose.Slides, Anda dapat menyisipkan teks prompt pilihan Anda ke dalam tata letak placeholder.

Kode JavaScript ini menunjukkan cara mengatur teks prompt dalam placeholder:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Mengiterasi slide
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // PowerPoint menampilkan "Click to add title"
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // Menambahkan subtitle
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Atur Transparansi Gambar Placeholder**

Aspose.Slides memungkinkan Anda mengatur transparansi gambar latar belakang pada placeholder teks. Dengan menyesuaikan transparansi gambar dalam bingkai tersebut, Anda dapat menonjolkan teks atau gambar (tergantung pada warna teks dan gambar).

Kode JavaScript ini menunjukkan cara mengatur transparansi untuk latar belakang gambar (di dalam shape):

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **FAQ**

**Apa itu placeholder dasar, dan bagaimana perbedaannya dengan bentuk lokal pada slide?**

Placeholder dasar adalah shape asli pada tata letak atau master yang diwariskan kepada shape slide — tipe, posisi, dan beberapa format berasal darinya. Bentuk lokal bersifat independen; jika tidak ada placeholder dasar, pewarisan tidak berlaku.

**Bagaimana saya dapat memperbarui semua judul atau keterangan di seluruh presentasi tanpa iterasi setiap slide?**

Edit placeholder yang bersangkutan pada tata letak atau master. Slide yang berbasis pada tata letak/master tersebut secara otomatis akan mewarisi perubahan.

**Bagaimana cara saya mengontrol placeholder header/footer standar—tanggal & waktu, nomor slide, dan teks footer?**

Gunakan pengelola HeaderFooter pada lingkup yang tepat (slide normal, tata letak, master, catatan/handout) untuk mengaktifkan atau menonaktifkan placeholder tersebut dan mengatur isinya.