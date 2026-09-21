---
title: Kelola Bidang Teks dalam Presentasi PowerPoint di Android
linktitle: Bidang Teks
type: docs
weight: 52
url: /id/androidjava/text-fields/
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
- Android
- Java
- Aspose.Slides
description: "Buat, inspeksi, modifikasi, dan hapus bidang teks dalam presentasi PowerPoint dengan Aspose.Slides untuk Android via Java. Pertahankan pemformatan dan verifikasi file PPTX serta PPT yang disimpan."
---
## **Gambaran Umum**

Sebuah paragraf teks terdiri dari bagian-bagian. Sebuah [IPortion] biasa berisi teks literal; sebuah bagian bidang juga memiliki [IField] yang tipe‑nya mengidentifikasi nilai yang diperbarui secara otomatis, seperti nomor slide atau tanggal. Du​a bagian dapat menampilkan karakter yang sama sementara hanya satu yang berisi bidang.

Gunakan [IPortion.getField] untuk membedakan keduanya: nilainya `null` untuk teks biasa. [IPortion.addField] mengubah bagian yang ada menjadi sebuah bidang. Simpan label dan nilai dinamisnya dalam bagian terpisah sehingga mengubah nilai tidak juga menggantikan label.

Panduan ini mencakup bidang di dalam teks, pemformatannya, dan penyimpanan dalam PPTX dan PPT. Untuk bingkai teks dan paragraf, lihat [Manage Text](/slides/id/androidjava/manage-text/).

## **Buat Bidang Nomor Slide**

Contoh lengkap berikut membuat sebuah kotak teks yang berisi label literal `Slide ` diikuti oleh angka yang diperbarui secara otomatis. Ia mengatur ukuran, ketebalan, dan warna angka sebelum menambahkan bidang, kemudian membuka kembali presentasi yang disimpan dan memeriksa tipe bidang, teks, dan pemformatannya. Tidak diperlukan file masukan.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    int numberColor = Color.rgb(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor() == numberColor;

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Presentasi baru dimulai dengan nomor slide 1, sehingga teksnya adalah `Slide 1`, dan kedua pemeriksaan mencetak `true`. Angka tersebut tetap menjadi bidang setelah dibuka kembali; ia bukan literal `1`. Cast dan indeks dalam verifikasi mengacu pada bentuk dan bagian yang dibuat oleh contoh ini.

## **Pilih Tipe Bidang**

[FieldType] mengimplementasikan [IFieldType] dan menyediakan metode berikut untuk memperoleh nilai yang telah ditentukan. Berikan nilai yang sesuai ke [addField].

| Metode | Tujuan |
|---|---|
| [getSlideNumber] | Nomor slide saat ini. |
| [getDateTime] | Tanggal/waktu dalam format default aplikasi render. |
| [getDateTime1]–[getDateTime9] | Format tanggal yang telah ditentukan atau format gabungan tanggal/waktu. |
| [getDateTime10]–[getDateTime13] | Format waktu yang telah ditentukan, dengan opsi detik dan jam 12‑jam. |
| [getHeader] | Bidang header; lihat batasan placeholder dan format di bawah. |
| [getFooter] | Bidang footer. |

Sebagai contoh, [getDateTime3] mewakili hari, nama bulan lengkap, dan tahun dalam bahasa Inggris. Ini adalah format bidang yang telah ditentukan, bukan string format tanggal Java yang sembarangan. Bahasa yang diatur dengan [setLanguageId] dan aplikasi yang memproses presentasi dapat memengaruhi hasil yang ditampilkan.

## **Buat Bidang dari String Internal**

Overload string dari [addField] menerima pengenal bidang internal. Gunakan ketika mempertahankan pengenal yang disediakan oleh aplikasi lain yang tidak memiliki nilai yang telah ditentukan. Anda juga dapat membuat [FieldType] dari pengenal tersebut. [IFieldType.getInternalString] menampilkan pengenal itu untuk inspeksi.

Contoh ini menyimpan bidang `custom-report-id` khusus aplikasi dengan teks cadangan `Report-042`. Pengenal tersebut tidak mendaftar perhitungan: Aspose.Slides tidak menghasilkan ID laporan untuk tipe yang tidak dikenal. Aplikasi yang memahami pengenal ini harus menyediakan maknanya dan memperbarui nilainya.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Setelah perjalanan PPTX ini, tipe‑nya adalah `custom-report-id` dan teksnya adalah `Report-042`. Mengirimkan string seperti `yyyy-MM-dd` akan menamai tipe bidang; itu tidak akan mengonfigurasi format tanggal khusus. Untuk tanggal tetap dalam format sembarangan, gunakan teks biasa.

## **Inspeksi, Modifikasi, dan Hapus Bidang Tanggal/Waktu**

Ubah bidang yang ada melalui [IField.setType]. Periksa bahwa bidang tersebut ada sebelum mengakses tipenya. Untuk menghentikan pembaruan otomatis, panggil [IPortion.removeField]. Ini mempertahankan bagian dan teks saat ini sambil menghapus asosiasi bidang. Jika Anda membutuhkan nilai tetap tertentu, tetapkan teks itu setelah menghapus bidang.

Untuk pengaturan API yang terkait dengan pemrosesan bidang tanggal/waktu, lihat [Presentation.setCurrentDateTime]. Contoh di bawah ini menggunakan tanggal persetujuan eksplisit saat mengubah bidang menjadi teks biasa.

Unduh [sample.pptx](sample.pptx) dan letakkan di direktori kerja. File tersebut berisi dua bentuk teks bernama, `UpdatedAt` dan `ApprovedDate`, masing‑masing dengan bidang tanggal/waktu, serta label teks biasa. Contoh berikut menelusuri bentuk teks tingkat atas pada slide biasa. Ia mengubah bidang tanggal/waktu menjadi format tanggal panjang dan membuatnya miring, sambil mempertahankan pemformatan lainnya. Hanya bidang di `ApprovedDate` yang menjadi teks tetap.

Contoh ini mengenali pengenal internal bawaan `datetime` serta `datetime1` hingga `datetime13`. Grup, tabel, catatan, tata letak, dan master memerlukan penelusuran kontainer teks mereka masing‑masing dan berada di luar lingkup contoh ini.

```java
import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Date;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    Calendar approvalDate = Calendar.getInstance();
    approvalDate.clear();
    approvalDate.set(2030, Calendar.APRIL, 5);
    SimpleDateFormat dateFormat = new SimpleDateFormat("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        Date dateValue = approvalDate.getTime();
                        String fixedDate = dateFormat.format(dateValue);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Setelah dibuka kembali, `UpdatedAt` memiliki tipe `datetime3` dan tetap dinamis. `ApprovedDate` tidak memiliki bidang dan berisi `05 April 2030`. Kedua bagian tanggal menjadi miring, dan ukuran font, pengaturan tebal, serta warna asli mereka tetap utuh. Label teks biasa tidak berubah. Verifikasi membaca bagian pertama dari dua bentuk yang dikenal dalam contoh yang disediakan.

## **Pertahankan Pemformatan Teks**

Bekerja dengan bagian yang ada saat menambahkan bidang, mengubah tipenya, atau menghapusnya. Operasi ini mempertahankan pemformatan bagian tersebut. Gunakan [IPortion.getPortionFormat] untuk mengubah hanya properti yang diperlukan, seperti yang dilakukan contoh untuk warna atau kemiringan.

Hindari membangun kembali seluruh bingkai teks hanya untuk memperbarui satu bidang: melakukan hal itu dapat menghilangkan batas‑batas bagian asli dan pemformatannya masing‑masing. Juga bedakan pemformatan yang ditetapkan secara eksplisit dari pemformatan yang diwarisi dari paragraf, tata letak, atau tema. Lihat [Text Formatting](/slides/id/androidjava/text-formatting/) untuk opsi pemformatan yang lebih luas.

## **Bidang dan Placeholder Header/Footer**

Bidang adalah bagian dari sebuah bagian teks. Placeholder adalah sebuah bentuk dengan peran presentasi, seperti footer atau nomor slide. Menambahkan bidang ke kotak teks biasa tidak mengubah bentuk tersebut menjadi placeholder.

Manajer header/footer mengontrol teks placeholder dan visibilitas pada slide, tata letak, dan master, termasuk penyebaran ke slide yang tergantung. Oleh karena itu, bidang nomor dalam kotak teks khusus dapat berguna meskipun Anda tidak menggunakan placeholder nomor slide. Sebaliknya, mengubah visibilitas placeholder tidak menghapus bidang dari kotak teks yang tidak terkait.

Tipe header dan footer yang telah ditentukan tidak membuat placeholder yang sesuai atau menyediakan kontennya. Khususnya, slide PowerPoint biasa tidak memiliki placeholder header; header berada pada halaman catatan dan selebaran. Jangan mengasumsikan bahwa bidang header atau footer dalam bentuk apa pun akan secara otomatis mendapatkan teks yang dikonfigurasi melalui manajer placeholder. Untuk alur kerja tersebut, lihat [Presentation Headers and Footers](/slides/id/androidjava/presentation-header-and-footer/).

## **Batasan PPTX dan PPT**

Periksa baik tipe bidang maupun teks hasilnya setelah menyimpan dan membuka kembali. Mempertahankan sebuah pengenal tidak membuktikan bahwa aplikasi dapat menghitung atau menampilkan nilainya.

| Format | Perilaku bidang dan batasan |
|---|---|
| PPTX | Menyimpan pengenal bidang internal bersama teks bidang. Dalam pemeriksaan putar balik, tipe yang telah ditentukan dan pengenal khusus yang digunakan di atas bertahan setelah penyimpanan dan pembukaan kembali. Tipe khusus yang tidak dikenal mempertahankan teks cadangannya; tidak memperoleh logika perhitungan otomatis. Aplikasi lain mungkin memperlakukan pengenal yang tidak didukung secara berbeda. |
| PPT | Menggunakan representasi bidang warisan dan memiliki kompatibilitas yang lebih terbatas. Dalam pemeriksaan putar balik, bidang nomor slide dan bidang tanggal/waktu yang telah ditentukan bertahan setelah penyimpanan dan pembukaan kembali. Bidang khusus dalam kotak teks slide biasa dibuka kembali dengan pengenalannya tetapi dengan `*` sebagai teksnya; bidang header dalam konteks yang sama juga menghasilkan `*`. Jangan mengandalkan bidang khusus atau konteks bidang yang tidak didukung mempertahankan teks terlihatnya. |

Untuk output yang dapat dipindahkan dan tetap, ubah bidang yang tidak didukung menjadi teks biasa dan tetapkan secara eksplisit nilai yang diinginkan sebelum menyimpan. Ini mempertahankan teks yang dipilih tetapi secara sengaja menghentikan pembaruan otomatis. Uji juga aplikasi target ketika perhitungan ulang bidangnya menjadi bagian dari alur kerja Anda.

## **FAQ**

**Bagaimana saya tahu apakah nomor atau tanggal yang ditampilkan adalah bidang?**

Periksa [IPortion.getField]. Nilai yang tidak null mengidentifikasi sebuah bidang; teks yang ditampilkan saja tidak dapat memberi tahu Anda.

**Apakah menghapus bidang menghapus teks atau pemformatannya?**

Tidak. [removeField] mengubah bagian yang ada menjadi teks biasa. Tetapkan nilai eksplisit setelahnya jika Anda memerlukan tanggal beku tertentu atau nilai cadangan.

**Apakah string internal dapat mendefinisikan format tanggal atau formula baru?**

Tidak. Itu mengidentifikasi tipe bidang. Pengenal yang tidak dikenal tidak menyediakan evaluator atau pola format tanggal Java. Gunakan tipe yang didukung atau format nilai secara manual sebagai teks biasa.

**Mengapa memeriksa kembali presentasi setelah menyimpannya?**

Pengenal bidang, teks yang dihitung, dan pemformatan adalah hal terpisah yang harus diverifikasi. Konversi format dapat mengubah hasil yang terlihat meskipun pengenal bidang masih ada.