---
title: Kelola Bidang Teks dalam Presentasi PowerPoint di JavaScript
linktitle: Bidang Teks
type: docs
weight: 52
url: /id/nodejs-java/text-fields/
keywords:
- bidang teks
- teks otomatis
- nomor slide
- tanggal dan waktu
- header
- footer
- bagian teks
- PowerPoint
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat, inspeksi, modifikasi, dan hapus bidang teks dalam presentasi PowerPoint dengan Aspose.Slides untuk Node.js via Java. Pertahankan pemformatan dan verifikasi file PPTX dan PPT yang disimpan."
---
## **Gambaran Umum**

Sebuah paragraf teks terdiri dari bagian-bagian. Sebuah [Portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/) biasa berisi teks literal; bagian field juga memiliki [Field](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/field/) yang tipenya mengidentifikasi nilai yang diperbarui secara otomatis, seperti nomor slide atau tanggal. Dua bagian dapat menampilkan karakter yang sama sementara hanya satu yang berisi field.

Gunakan [Portion.getField](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/#getField) untuk membedakannya: nilai tersebut `null` untuk teks biasa. [Portion.addField](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/#addField) mengubah sebuah bagian yang ada menjadi field. Simpan label dan nilai dinamisnya dalam bagian terpisah agar mengubah nilai tidak juga menggantikan label.

Panduan ini mencakup field di dalam teks, pemformatannya, dan penyimpanan dalam PPTX serta PPT. Untuk bingkai teks dan paragraf, lihat [Manage Text](/slides/id/nodejs-java/manage-text/).

## **Buat Field Nomor Slide**

Contoh lengkap berikut membuat sebuah kotak teks yang berisi label literal `Slide ` diikuti oleh nomor yang diperbarui secara otomatis. Ia mengatur ukuran, ketebalan, dan warna nomor sebelum menambahkan field, lalu membuka kembali presentasi yang disimpan dan memeriksa tipe field, teks, serta pemformatannya. Tidak diperlukan file input.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    const numberPortion = new aspose.slides.Portion();
    const numberColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    numberPortion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(aspose.slides.FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("slide_number.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        const savedField = savedNumber.getField();
        const hasNumberField = savedField != null && aspose.slides.FieldType.getSlideNumber().getInternalString() === savedField.getType().getInternalString();
        const format = savedNumber.getPortionFormat();
        let formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == aspose.slides.NullableBool.True;
        formattingPreserved = formattingPreserved && format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        console.log("Text: " + savedShape.getTextFrame().getText());
        console.log("Slide number field: " + hasNumberField);
        console.log("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Presentasi baru dimulai dengan nomor slide 1, jadi teksnya menjadi `Slide 1`, dan kedua pemeriksaan mencetak `true`. Nomor tersebut tetap menjadi field setelah dibuka kembali; itu bukan literal `1`. Indeks dalam verifikasi mengacu pada shape dan bagian yang dibuat oleh contoh ini.

## **Pilih Tipe Field**

[FieldType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fieldtype/) menyediakan metode berikut untuk mendapatkan nilai yang telah ditentukan. Berikan nilai yang sesuai ke [addField](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/#addField).

| Metode | Tujuan |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | Nomor slide saat ini. |
| [getDateTime](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fieldtype/#getDateTime) | Tanggal/waktu dalam format default aplikasi rendering. |
| [getDateTime1](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | Format tanggal atau kombinasi tanggal/waktu yang telah ditentukan. |
| [getDateTime10](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | Format waktu yang telah ditentukan, dengan opsi detik dan jam 12. |
| [getHeader](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fieldtype/#getHeader) | Field header; lihat batasan placeholder dan format di bawah. |
| [getFooter](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fieldtype/#getFooter) | Field footer. |

Sebagai contoh, [getDateTime3](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fieldtype/#getDateTime3) mewakili hari, nama bulan lengkap, dan tahun dalam bahasa Inggris. Ini adalah format field yang telah ditentukan, bukan string format tanggal arbitrer. Bahasa yang diatur dengan [setLanguageId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) dan aplikasi yang memproses presentasi dapat memengaruhi hasil yang ditampilkan.

## **Buat Field dari String Internal**

Versi overload string dari [addField](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/#addField) menerima sebuah pengenal field internal. Gunakan ini saat mempertahankan pengenal yang diberikan oleh aplikasi lain yang tidak memiliki nilai yang telah ditentukan. Anda juga dapat membuat sebuah [FieldType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fieldtype/) dari pengenal tersebut. [FieldType.getInternalString](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fieldtype/#getInternalString) mengungkapkan pengenal itu untuk inspeksi.

Contoh ini menyimpan field khusus aplikasi `custom-report-id` dengan teks cadangan `Report-042`. Pengenal tersebut tidak mendaftarkan perhitungan: Aspose.Slides tidak menghasilkan ID laporan untuk tipe yang tidak dikenal. Aplikasi yang memahami pengenal ini harus menyediakan maknanya dan memperbarui nilainya.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("custom_field.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const savedField = savedPortion.getField();
        const typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        console.log("Type: " + typeName);
        console.log("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Setelah perjalanan balik PPTX ini, tipe menjadi `custom-report-id` dan teksnya `Report-042`. Mengirimkan string seperti `yyyy-MM-dd` akan menamai tipe field; itu tidak akan mengonfigurasi format tanggal khusus. Untuk tanggal tetap dalam format apa pun, gunakan teks biasa.

## **Inspeksi, Modifikasi, dan Hapus Field Tanggal/Waktu**

Ubah field yang ada melalui [Field.setType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/field/#setType). Periksa bahwa field tersebut ada sebelum mengakses tipenya. Untuk menghentikan pembaruan otomatis, panggil [Portion.removeField](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/#removeField). Ini mempertahankan bagian dan teksnya saat ini sambil menghapus asosiasi field. Jika Anda memerlukan nilai tetap tertentu, tetapkan teks itu setelah menghapus field.

Untuk pengaturan API yang terkait dengan pemrosesan field tanggal/waktu, lihat [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#setCurrentDateTime). Contoh di bawah ini menggunakan tanggal persetujuan eksplisit saat mengonversi field menjadi teks biasa.

Unduh [sample.pptx](sample.pptx) dan letakkan di direktori kerja. File tersebut berisi dua shape teks bernama, `UpdatedAt` dan `ApprovedDate`, masing-masing dengan field tanggal/waktu, serta label teks biasa. Contoh berikut menjelajahi shape teks tingkat atas pada slide reguler. Ia mengubah field tanggal/waktu menjadi format tanggal panjang dan menjadikannya miring, sambil mempertahankan pemformatan lainnya. Hanya field dalam `ApprovedDate` yang menjadi teks tetap.

Tanggal persetujuan adalah 5 April 2030; indeks bulan JavaScript mulai dari nol, jadi April adalah `3`. UTC digunakan baik untuk pembuatan maupun pemformatan agar tanggal tidak dipengaruhi zona waktu lokal.

Contoh ini mengenali pengenal internal bawaan `datetime` dan `datetime1` hingga `datetime13`. Grup, tabel, catatan, tata letak, dan master memerlukan penelusuran kontainer teks mereka sendiri dan berada di luar cakupan contoh ini.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const approvalDate = new Date(Date.UTC(2030, 3, 5));
    const dateFormat = new Intl.DateTimeFormat("en-GB", { day: "2-digit", month: "long", year: "numeric", timeZone: "UTC" });

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < shape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    const typeName = field.getType().getInternalString();
                    const isDateTime = typeName != null && /^datetime([1-9]|1[0-3])?$/.test(typeName);
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(aspose.slides.FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

                    if (shape.getName() === "ApprovedDate") {
                        portion.removeField();
                        const fixedDate = dateFormat.format(approvalDate);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("updated_dates.pptx");
    try {
        for (let shapeIndex = 0; shapeIndex < reopened.getSlides().get_Item(0).getShapes().size(); shapeIndex++) {
            const shape = reopened.getSlides().get_Item(0).getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }
            if (shape.getName() !== "UpdatedAt" && shape.getName() !== "ApprovedDate") {
                continue;
            }

            const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            const field = portion.getField();
            const typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            console.log(shape.getName() + ": " + typeName + "; " + portion.getText());
            console.log("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Setelah dibuka kembali, `UpdatedAt` memiliki tipe `datetime3` dan tetap dinamis. `ApprovedDate` tidak memiliki field dan berisi `05 April 2030`. Kedua bagian tanggal tersebut miring, dan ukuran font, pengaturan tebal, serta warna asli tetap tidak berubah. Label teks biasa tidak berubah. Verifikasi membaca bagian pertama dari dua shape yang dikenal dalam contoh yang diberikan.

## **Pertahankan Pemformatan Teks**

Bekerja dengan bagian yang ada saat menambahkan field, mengubah tipenya, atau menghapusnya. Operasi ini mempertahankan pemformatan bagian tersebut. Gunakan [Portion.getPortionFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/#getPortionFormat) untuk mengubah hanya properti yang diperlukan, seperti contoh untuk warna atau miring.

Hindari membangun ulang seluruh bingkai teks hanya untuk memperbarui satu field: hal itu dapat menghilangkan batasan bagian asli dan pemformatannya masing-masing. Juga bedakan pemformatan yang ditetapkan secara eksplisit dari pemformatan yang diwarisi dari paragraf, tata letak, atau tema. Lihat [Text Formatting](/slides/id/nodejs-java/text-formatting/) untuk opsi pemformatan yang lebih luas.

## **Field dan Placeholder Header/Footer**

Field adalah bagian dari sebuah bagian teks. Placeholder adalah sebuah shape dengan peran presentasi, seperti footer atau nomor slide. Menambahkan field ke kotak teks biasa tidak mengubah shape tersebut menjadi placeholder.

Manajer header/footer mengontrol teks placeholder dan visibilitasnya pada slide, tata letak, dan master, termasuk propagasi ke slide turunan. Field nomor dalam kotak teks khusus dapat berguna bahkan ketika Anda tidak menggunakan placeholder nomor slide. Sebaliknya, mengubah visibilitas placeholder tidak menghapus field dari kotak teks yang tidak terkait.

Tipe header dan footer yang telah ditentukan tidak membuat placeholder yang bersesuaian atau menyediakan kontennya. Khususnya, slide PowerPoint standar tidak memiliki placeholder header; header berada pada halaman catatan dan handout. Jangan berasumsi bahwa field header atau footer dalam shape apa pun akan secara otomatis memperoleh teks yang dikonfigurasi melalui manajer placeholder. Untuk alur kerja itu, lihat [Presentation Headers and Footers](/slides/id/nodejs-java/presentation-header-and-footer/).

## **Batasan PPTX dan PPT**

Periksa baik tipe field maupun teks hasilnya setelah menyimpan dan membuka kembali. Mempertahankan sebuah pengenal tidak membuktikan bahwa aplikasi dapat menghitung atau menampilkan nilainya.

| Format | Perilaku dan batasan field |
|---|---|
| PPTX | Menyimpan pengenal field internal bersamaan dengan teks field. Dalam pemeriksaan putar balik, tipe yang telah ditentukan dan pengenal khusus yang digunakan di atas tetap ada setelah menyimpan dan membuka kembali. Tipe khusus yang tidak diketahui mempertahankan teks cadangannya; tidak memperoleh logika perhitungan otomatis. Aplikasi lain dapat memperlakukan pengenal yang tidak didukung secara berbeda. |
| PPT | Menggunakan representasi field warisan dan memiliki kompatibilitas yang lebih terbatas. Dalam pemeriksaan putar balik, field nomor slide dan field tanggal/waktu yang telah ditentukan tetap ada setelah menyimpan dan membuka kembali. Field khusus dalam kotak teks slide biasa dibuka kembali dengan pengenal tetapi dengan `*` sebagai teksnya; field header dalam konteks yang sama juga menghasilkan `*`. Jangan mengandalkan field khusus atau konteks field yang tidak didukung mempertahankan teks yang terlihat. |

Untuk output yang dapat dipindahkan dan tetap, ubah field yang tidak didukung menjadi teks biasa dan tetapkan nilai yang diinginkan secara eksplisit sebelum menyimpan. Ini mempertahankan teks yang dipilih tetapi secara sengaja menghentikan pembaruan otomatis. Uji juga aplikasi target ketika perhitungan ulang field miliknya merupakan bagian dari alur kerja Anda.

## **FAQ**

**Bagaimana saya dapat mengetahui apakah angka atau tanggal yang ditampilkan adalah field?**

Periksa [Portion.getField](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/#getField). Nilai yang tidak null mengidentifikasi sebuah field; teks yang ditampilkan saja tidak dapat memberitahukannya.

**Apakah menghapus field menghapus teks atau pemformatannya?**

Tidak. [removeField](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/#removeField) mengonversi bagian yang ada menjadi teks biasa. Tetapkan nilai eksplisit setelahnya jika Anda memerlukan tanggal beku tertentu atau nilai cadangan.

**Apakah string internal dapat mendefinisikan format tanggal atau rumus baru?**

Tidak. Itu mengidentifikasi tipe field. Pengenal yang tidak dikenal tidak menyediakan evaluator atau pola format tanggal. Gunakan tipe yang telah ditentukan yang didukung atau format nilai sendiri sebagai teks biasa.

**Mengapa memeriksa kembali presentasi setelah menyimpannya?**

Pengenal field, teks yang dihitung, dan pemformatan adalah hal terpisah yang harus diverifikasi. Konversi format dapat mengubah hasil yang terlihat bahkan ketika pengenal field masih ada.