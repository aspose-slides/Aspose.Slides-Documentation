---
title: Kelola Field Teks dalam Presentasi PowerPoint di Java
linktitle: Field Teks
type: docs
weight: 52
url: /id/java/text-fields/
keywords:
- bidang teks
- teks otomatis
- nomor slide
- tanggal dan waktu
- header
- catatan kaki
- bagian teks
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Buat, periksa, ubah, dan hapus field teks dalam presentasi PowerPoint dengan Aspose.Slides untuk Java. Pertahankan pemformatan dan verifikasi file PPTX dan PPT yang disimpan."
---
## **Gambaran Umum**

Paragraf teks terdiri dari bagian-bagian. [IPortion](https://reference.aspose.com/slides/id/java/com.aspose.slides/iportion/) biasa berisi teks literal; bagian field juga memiliki [IField](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifield/) yang tipenya mengidentifikasi nilai yang diperbarui secara otomatis, seperti nomor slide atau tanggal. Dua bagian dapat menampilkan karakter yang sama sementara hanya satu yang berisi field.

Gunakan [IPortion.getField](https://reference.aspose.com/slides/id/java/com.aspose.slides/iportion/#getField--) untuk membedakannya: nilai akan `null` untuk teks biasa. [IPortion.addField](https://reference.aspose.com/slides/id/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) mengubah bagian yang ada menjadi field. Simpan label dan nilai dinamisnya dalam bagian terpisah sehingga mengonversi nilai tidak juga menggantikan label.

Panduan ini mencakup field di dalam teks, pemformatannya, serta penyimpanan dalam PPTX dan PPT. Untuk kerangka teks dan paragraf, lihat [Manage Text](/slides/id/java/manage-text/).

## **Buat Field Nomor Slide**

Contoh lengkap berikut membuat kotak teks yang berisi label literal `Slide ` diikuti oleh nomor yang diperbarui secara otomatis. Ini mengatur ukuran, tebal, dan warna nomor sebelum menambahkan field, kemudian membuka kembali presentasi yang disimpan dan memeriksa tipe field, teks, serta pemformatannya. Tidak diperlukan file input.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    Color numberColor = new Color(0, 0, 139);
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
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

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

Presentasi baru dimulai dengan nomor slide 1, sehingga teksnya `Slide 1`, dan kedua pemeriksaan mencetak `true`. Nomor tersebut tetap menjadi field setelah dibuka kembali; itu bukan literal `1`. Cast dan indeks dalam verifikasi mengacu pada shape dan bagian yang dibuat oleh contoh ini.

## **Pilih Tipe Field**

[FieldType](https://reference.aspose.com/slides/id/java/com.aspose.slides/fieldtype/) mengimplementasikan [IFieldType](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifieldtype/) dan menyediakan metode berikut untuk memperoleh nilai yang telah ditentukan. Berikan nilai yang sesuai ke [addField](https://reference.aspose.com/slides/id/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Metode | Tujuan |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/id/java/com.aspose.slides/fieldtype/#getSlideNumber--) | Nomor slide saat ini. |
| [getDateTime](https://reference.aspose.com/slides/id/java/com.aspose.slides/fieldtype/#getDateTime--) | Tanggal/waktu dalam format default aplikasi render. |
| [getDateTime1](https://reference.aspose.com/slides/id/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/id/java/com.aspose.slides/fieldtype/#getDateTime9--) | Format tanggal atau kombinasi tanggal/waktu yang telah ditentukan. |
| [getDateTime10](https://reference.aspose.com/slides/id/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/id/java/com.aspose.slides/fieldtype/#getDateTime13--) | Format waktu yang telah ditentukan, dengan opsi detik dan jam 12. |
| [getHeader](https://reference.aspose.com/slides/id/java/com.aspose.slides/fieldtype/#getHeader--) | Field header; lihat batasan placeholder dan format di bawah. |
| [getFooter](https://reference.aspose.com/slides/id/java/com.aspose.slides/fieldtype/#getFooter--) | Field footer. |

Sebagai contoh, [getDateTime3](https://reference.aspose.com/slides/id/java/com.aspose.slides/fieldtype/#getDateTime3--) mewakili hari, nama bulan lengkap, dan tahun dalam bahasa Inggris. Ini adalah format field yang telah ditentukan, bukan string format tanggal Java yang sewenang-wenang. Bahasa yang diatur dengan [setLanguageId](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) dan aplikasi yang memproses presentasi dapat memengaruhi hasil yang ditampilkan.

## **Buat Field dari String Internal**

Overload string dari [addField](https://reference.aspose.com/slides/id/java/com.aspose.slides/iportion/#addField-java.lang.String-) menerima pengidentifikasi field internal. Gunakan ini saat mempertahankan pengidentifikasi yang diberikan oleh aplikasi lain yang tidak memiliki nilai yang telah ditentukan. Anda juga dapat membuat [FieldType](https://reference.aspose.com/slides/id/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) dari pengidentifikasi tersebut. [IFieldType.getInternalString](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifieldtype/#getInternalString--) mengekspos pengidentifikasi itu untuk inspeksi.

Contoh ini menyimpan field khusus aplikasi `custom-report-id` dengan teks fallback `Report-042`. Pengidentifikasi tersebut tidak mendaftarkan perhitungan: Aspose.Slides tidak menghasilkan ID laporan untuk tipe yang tidak dikenal. Aplikasi yang memahami pengidentifikasi ini harus menyediakan maksudnya dan memperbarui nilainya.

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

Setelah siklus PPTX ini, tipe menjadi `custom-report-id` dan teksnya `Report-042`. Mengirim string seperti `yyyy-MM-dd` akan memberi nama tipe field; itu tidak akan mengonfigurasi format tanggal khusus. Untuk tanggal tetap dalam format sewenang-wenang, gunakan teks biasa.

## **Periksa, Modifikasi, dan Hapus Field Tanggal/Waktu**

Ubah field yang ada melalui [IField.setType](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Periksa bahwa field ada sebelum mengakses tipenya. Untuk menghentikan pembaruan otomatis, panggil [IPortion.removeField](https://reference.aspose.com/slides/id/java/com.aspose.slides/iportion/#removeField--). Ini mempertahankan bagian dan teksnya saat ini sambil menghapus asosiasi field. Jika Anda memerlukan nilai tetap tertentu, tetapkan teks itu setelah menghapus field.

Untuk pengaturan API terkait pemrosesan field tanggal/waktu, lihat [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). Contoh di bawah ini menggunakan tanggal persetujuan eksplisit saat mengonversi field menjadi teks biasa.

Unduh [sample.pptx](sample.pptx) dan letakkan di direktori kerja. File ini berisi dua shape teks bernama, `UpdatedAt` dan `ApprovedDate`, masing-masing dengan field tanggal/waktu, serta label teks biasa. Contoh berikut menelusuri shape teks tingkat atas pada slide reguler. Ini mengubah field tanggal/waktu ke format tanggal panjang dan membuatnya miring, sambil mempertahankan format lainnya. Hanya field dalam `ApprovedDate` yang menjadi teks tetap.

Contoh ini mengenali pengidentifikasi internal bawaan `datetime` dan `datetime1` hingga `datetime13`. Grup, tabel, catatan, tata letak, dan master memerlukan penelusuran kontainer teks masing-masing dan berada di luar ruang lingkup contoh ini.

```java
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    LocalDate approvalDate = LocalDate.of(2030, 4, 5);
    DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMMM yyyy", Locale.US);

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
                        String fixedDate = approvalDate.format(dateFormat);
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

Setelah dibuka kembali, `UpdatedAt` memiliki tipe `datetime3` dan tetap dinamis. `ApprovedDate` tidak memiliki field dan berisi `05 April 2030`. Kedua bagian tanggal tersebut miring, dan ukuran font, pengaturan tebal, serta warna asli tetap utuh. Label teks biasa tidak berubah. Verifikasi membaca bagian pertama dari dua shape yang dikenal dalam sampel yang disediakan.

## **Pertahankan Pemformatan Teks**

Bekerja dengan bagian yang ada saat menambahkan field, mengubah tipenya, atau menghapusnya. Operasi ini mempertahankan pemformatan bagian tersebut. Gunakan [IPortion.getPortionFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/iportion/#getPortionFormat--) untuk mengubah hanya properti yang diperlukan, seperti contoh untuk warna atau miring.

Hindari membangun kembali seluruh frame teks hanya untuk memperbarui satu field: hal itu dapat menyebabkan hilangnya batas bagian asli dan pemformatannya masing-masing. Juga bedakan pemformatan yang ditetapkan secara eksplisit dari pemformatan yang diwarisi dari paragraf, tata letak, atau tema. Lihat [Text Formatting](/slides/id/java/text-formatting/) untuk opsi pemformatan yang lebih luas.

## **Field dan Placeholder Header/Footer**

Field merupakan bagian dari sebuah bagian teks. Placeholder adalah shape dengan peran presentasi, seperti footer atau nomor slide. Menambahkan field ke kotak teks biasa tidak mengubah shape tersebut menjadi placeholder.

Manajer header/footer mengontrol teks placeholder dan visibilitas pada slide, tata letak, dan master, termasuk penyebaran ke slide yang bergantung. Field nomor dalam kotak teks khusus dapat berguna meskipun Anda tidak menggunakan placeholder nomor slide. Sebaliknya, mengubah visibilitas placeholder tidak menghapus field dari kotak teks yang tidak terkait.

Tipe header dan footer yang telah ditentukan tidak membuat placeholder yang bersesuaian atau menyediakan kontennya. Khususnya, slide PowerPoint biasa tidak memiliki placeholder header; header berada di halaman catatan dan handout. Jangan menganggap bahwa field header atau footer dalam shape apa pun akan otomatis memperoleh teks yang dikonfigurasi melalui manajer placeholder. Untuk alur kerja itu, lihat [Presentation Headers and Footers](/slides/id/java/presentation-header-and-footer/).

## **Batasan PPTX dan PPT**

Periksa baik tipe field maupun teks hasilnya setelah menyimpan dan membuka kembali. Mempertahankan pengidentifikasi tidak membuktikan bahwa aplikasi dapat menghitung atau menampilkan nilainya.

| Format | Perilaku Field dan Batasan |
|---|---|
| PPTX | Menyimpan pengidentifikasi field internal bersama teks field. Dalam pemeriksaan siklus, tipe yang telah ditentukan dan pengidentifikasi khusus yang digunakan di atas bertahan setelah penyimpanan dan pembukaan kembali. Tipe khusus yang tidak dikenal mempertahankan teks fallback; tidak memperoleh logika perhitungan otomatis. Aplikasi lain mungkin memperlakukan pengidentifikasi yang tidak didukung secara berbeda. |
| PPT | Menggunakan representasi field warisan dan memiliki kompatibilitas yang lebih terbatas. Dalam pemeriksaan siklus, field nomor slide dan field tanggal/waktu yang telah ditentukan bertahan setelah penyimpanan dan pembukaan kembali. Field khusus dalam kotak teks slide biasa dibuka kembali dengan pengidentifikasinya namun dengan teks `*`; field header dalam konteks yang sama juga menghasilkan `*`. Jangan mengandalkan field khusus atau konteks field yang tidak didukung mempertahankan teks yang terlihat. |

Untuk output yang dapat dipindahkan dan tetap, konversi field yang tidak didukung menjadi teks biasa dan tetapkan nilai yang diinginkan secara eksplisit sebelum menyimpan. Ini mempertahankan teks yang dipilih tetapi sengaja menghentikan pembaruan otomatis. Uji aplikasi target juga ketika perhitungan ulang field miliknya menjadi bagian dari alur kerja Anda.

## **FAQ**

**Bagaimana saya dapat mengetahui apakah nomor atau tanggal yang ditampilkan adalah field?**

Periksa [IPortion.getField](https://reference.aspose.com/slides/id/java/com.aspose.slides/iportion/#getField--). Nilai yang tidak null mengidentifikasi field; teks yang ditampilkan saja tidak dapat memberi tahu Anda.

**Apakah menghapus field menghapus teks atau formatnya?**

Tidak. [removeField](https://reference.aspose.com/slides/id/java/com.aspose.slides/iportion/#removeField--) mengubah bagian yang ada menjadi teks biasa. Tetapkan nilai eksplisit setelahnya jika Anda membutuhkan tanggal beku tertentu atau nilai fallback.

**Apakah string internal dapat mendefinisikan format tanggal atau rumus baru?**

Tidak. Itu mengidentifikasi tipe field. Pengidentifikasi yang tidak dikenal tidak menyediakan evaluator atau pola format tanggal Java. Gunakan tipe yang telah ditentukan yang didukung atau format nilai sendiri sebagai teks biasa.

**Mengapa memeriksa presentasi lagi setelah menyimpannya?**

Pengidentifikasi field, teks yang dihitung, dan format adalah hal terpisah yang perlu diverifikasi. Konversi format dapat mengubah hasil yang terlihat bahkan ketika pengidentifikasi field masih ada.