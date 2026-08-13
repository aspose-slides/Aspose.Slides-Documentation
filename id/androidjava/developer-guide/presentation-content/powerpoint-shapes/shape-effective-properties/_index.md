---
title: Dapatkan Properti Efektif Shape dari Presentasi di Android
linktitle: Properti Efektif
type: docs
weight: 50
url: /id/androidjava/shape-effective-properties/
keywords:
- properti shape
- properti kamera
- rig cahaya
- bevel shape
- bingkai teks
- gaya teks
- tinggi font
- format isian
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara menggunakan Aspose.Slides untuk Android via Java untuk membedakan pemformatan shape lokal, warisan, dan efektif dalam presentasi PowerPoint."
---
## **Pahami Properti Lokal, Warisan, dan Efektif**

Pemformatan PowerPoint dapat berasal dari beberapa tempat. Nilai yang disimpan langsung pada sebuah objek adalah **nilai lokal**. Jika nilai tersebut tidak ditetapkan, PowerPoint melihat sumber pemformatan induk, seperti nilai default paragraf, gaya teks, tata letak atau slide master, tema, atau default tingkat presentasi. Nilai‑nilai tersebut adalah **nilai yang diwariskan**. Nilai yang tersisa setelah seluruh hierarki diselesaikan adalah **nilai efektif**—nilai yang digunakan untuk merender objek.

Sebagai contoh, sebuah bagian teks mungkin tidak menentukan tinggi fontnya sendiri. Nilai lokal [getFontHeight](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--)‑nya kemudian menjadi `Float.NaN`, yang berarti "tidak ditetapkan di sini." Bagian tersebut dapat mewarisi tinggi dari paragrafnya, gaya teks default presentasi, atau sumber lain yang berlaku. Memanggil [getEffective](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportionformat/#getEffective--) pada format bagian mengembalikan tinggi yang telah diselesaikan akhir.

Gunakan dua jenis data pemformatan untuk tujuan yang berbeda:

- Baca atau ubah objek format lokal, seperti [IPortionFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportionformat/), ketika Anda perlu mengendalikan di mana nilai ditetapkan.
- Baca objek data efektif, seperti [IPortionFormatEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportionformateffectivedata/), ketika Anda memerlukan hasil akhir yang dirender. Data efektif bersifat read-only.

## **Bandingkan Nilai Lokal, Warisan, dan Efektif**

Contoh lengkap berikut membuat sebuah shape dan menerapkan tinggi font pada tingkat presentasi, paragraf, dan bagian. Setiap langkah mencetak nilai yang ditetapkan pada tingkat tersebut serta nilai efektif yang dihasilkan untuk bagian teks yang sama. Contoh ini juga menunjukkan mengapa data efektif harus dibaca kembali setelah perubahan pemformatan.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
            ITextFrame textFrame = shape.addTextFrame("Effective formatting");
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            // Tentukan nilai yang diwariskan pada dua level berbeda.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // Nilai lokal pada bagian menggantikan kedua nilai yang diwariskan.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // Mengubah nilai yang diwariskan tidak menggantikan nilai lokal yang sudah ada.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // Hapus nilai lokal. Bagian kini mewarisi dari paragraf lagi.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // Hapus nilai paragraf. Default presentasi kini menyediakan hasil.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

            presentation.save("effective-properties.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static void printFontHeights(String caption, Presentation presentation, IParagraph paragraph, IPortion portion) {
        float presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
        float paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
        float localValue = portion.getPortionFormat().getFontHeight();

        // Baca data efektif setelah perubahan sebelumnya.
        float effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

        System.out.println(caption);
        System.out.println("  Presentation default: " + formatLocalValue(presentationValue));
        System.out.println("  Paragraph default:    " + formatLocalValue(paragraphValue));
        System.out.println("  Portion local:        " + formatLocalValue(localValue));
        System.out.println("  Portion effective:    " + effectiveValue);
    }

    private static String formatLocalValue(float value) {
        return Float.isNaN(value) ? "<not set>" : Float.toString(value);
    }
}
```

Prioritas dalam contoh ini adalah pemformatan lokal bagian, kemudian pemformatan paragraf, lalu default presentasi. Objek lain dapat memiliki rantai pewarisan yang berbeda, tetapi prinsipnya tetap sama: nilai eksplisit yang lebih spesifik menang, dan [getEffective](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportionformat/#getEffective--) mengembalikan hasil akhir.

## **Dapatkan Properti Teks Efektif**

Pemformatan teks dibagi menjadi beberapa objek:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframeformat/#getEffective--) menyelesaikan properti bingkai teks seperti margin, penancapan, autofit, dan arah teks vertikal.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextstyle/#getEffective--) menyelesaikan pemformatan paragraf untuk setiap tingkat gaya teks.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#getEffective--) menyelesaikan properti paragraf seperti perataan, indentasi, dan bullet.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportionformat/#getEffective--) menyelesaikan properti karakter seperti tinggi font, jenis huruf, warna, tebal, dan miring.

Untuk contoh berikut, `text-formatting.pptx` harus berisi setidaknya satu slide dan satu [AutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/autoshape/) dengan bingkai teks yang tidak kosong. AutoShape dapat muncul pada posisi mana pun dalam koleksi shape; kode mencari objek yang sesuai dan memvalidasinya sebelum digunakan.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("text-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            IAutoShape shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
            if (shape == null) {
                throw new IllegalStateException("The first slide must contain an AutoShape with non-empty text.");
            }

            ITextFrame textFrame = shape.getTextFrame();
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            ITextFrameFormatEffectiveData textFrameEffective = textFrame.getTextFrameFormat().getEffective();
            IParagraphFormatEffectiveData paragraphEffective = paragraph.getParagraphFormat().getEffective();
            IPortionFormatEffectiveData portionEffective = portion.getPortionFormat().getEffective();

            System.out.println("Text frame margins:");
            System.out.println("  Left: " + textFrameEffective.getMarginLeft());
            System.out.println("  Top: " + textFrameEffective.getMarginTop());
            System.out.println("  Right: " + textFrameEffective.getMarginRight());
            System.out.println("  Bottom: " + textFrameEffective.getMarginBottom());
            System.out.println("Paragraph alignment: " + paragraphEffective.getAlignment());
            System.out.println("Font height: " + portionEffective.getFontHeight());
            System.out.println("Bold: " + portionEffective.getFontBold());

            ITextStyleEffectiveData effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
            for (int level = 0; level < 9; level++) {
                IParagraphFormatEffectiveData levelEffective = effectiveTextStyle.getLevel(level);
                System.out.println("Level " + level + " indent: " + levelEffective.getIndent());
            }
        } finally {
            presentation.dispose();
        }
    }

    private static IAutoShape findAutoShapeWithText(ISlide slide) {
        for (IShape candidate : slide.getShapes()) {
            if (candidate instanceof IAutoShape && hasNonEmptyText((IAutoShape)candidate)) {
                return (IAutoShape)candidate;
            }
        }
        return null;
    }

    private static boolean hasNonEmptyText(IAutoShape shape) {
        if (shape.getTextFrame() == null) {
            return false;
        }
        if (shape.getTextFrame().getParagraphs().getCount() == 0) {
            return false;
        }
        return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
    }
}
```

## **Dapatkan Properti 3D Efektif**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/#getEffective--) mengembalikan satu objek [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformateffectivedata/) yang mengelompokkan semua pengaturan 3D yang telah diselesaikan. Metode [getCamera](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--), dan [getBevelBottom](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) mengekspos data efektif yang bersangkutan. Membaca pengaturan terkait secara bersamaan memudahkan pemahaman tampilan 3D akhir sebuah shape.

Untuk contoh ini, `shape-3d.pptx` harus berisi setidaknya satu shape pada slide pertama. Terapkan pengaturan kamera 3D, pencahayaan, atau bevel pada shape tersebut jika Anda menginginkan output berisi nilai selain default.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("shape-3d.pptx");
        try {
            if (presentation.getSlides().size() == 0 || presentation.getSlides().get_Item(0).getShapes().size() == 0) {
                throw new IllegalStateException("The first slide must contain a shape.");
            }

            IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
            IThreeDFormatEffectiveData threeDEffective = shape.getThreeDFormat().getEffective();

            System.out.println("Camera:");
            System.out.println("  Type: " + threeDEffective.getCamera().getCameraType());
            System.out.println("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
            System.out.println("  Zoom: " + threeDEffective.getCamera().getZoom());

            System.out.println("Light rig:");
            System.out.println("  Type: " + threeDEffective.getLightRig().getLightType());
            System.out.println("  Direction: " + threeDEffective.getLightRig().getDirection());

            System.out.println("Top bevel:");
            System.out.println("  Type: " + threeDEffective.getBevelTop().getBevelType());
            System.out.println("  Width: " + threeDEffective.getBevelTop().getWidth());
            System.out.println("  Height: " + threeDEffective.getBevelTop().getHeight());
        } finally {
            presentation.dispose();
        }
    }
}
```

## **Dapatkan Pemformatan Tabel Efektif**

Pemformatan tabel dapat berasal dari gaya tabel dan dari format yang diterapkan pada seluruh tabel, kolom, baris, atau sel individual. Untuk konflik di antara isian yang didefinisikan secara eksplisit, prioritasnya adalah sel, baris, kolom, dan kemudian seluruh tabel. Format efektif sebuah sel adalah format akhir yang digunakan untuk menggambar sel tersebut.

Untuk contoh ini, `table-formatting.pptx` harus berisi setidaknya satu tabel pada slide pertama. Tabel harus memiliki setidaknya satu baris dan satu kolom. Kode mencari sebuah [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itable/) alih-alih mengasumsikan bahwa `getShapes().get_Item(0)` adalah sebuah tabel.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("table-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            ITable table = findTable(presentation.getSlides().get_Item(0));
            if (table == null) {
                throw new IllegalStateException("The first slide must contain a table.");
            }
            if (table.getRows().size() == 0 || table.getColumns().size() == 0) {
                throw new IllegalStateException("The table must contain at least one cell.");
            }

            ITableFormatEffectiveData tableEffective = table.getTableFormat().getEffective();
            IRowFormatEffectiveData rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
            IColumnFormatEffectiveData columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
            ICellFormatEffectiveData cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

            System.out.println("Table fill: " + tableEffective.getFillFormat().getFillType());
            System.out.println("Row fill: " + rowEffective.getFillFormat().getFillType());
            System.out.println("Column fill: " + columnEffective.getFillFormat().getFillType());
            System.out.println("Final cell fill: " + cellEffective.getFillFormat().getFillType());
        } finally {
            presentation.dispose();
        }
    }

    private static ITable findTable(ISlide slide) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                return (ITable)shape;
            }
        }
        return null;
    }
}
```

Jika Anda memerlukan warna alih-alih hanya tipe isian, pertama periksa [getFillType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ifillformateffectivedata/#getFillType--) yang efektif, lalu baca metode yang berlaku untuk tipe tersebut—misalnya, [getSolidFillColor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) untuk isian solid.

## **Baca Ulang Data Efektif Setelah Perubahan**

Data efektif menggambarkan hierarki pemformatan pada saat diselesaikan. Panggil `getEffective` lagi setelah mengubah apa pun yang dapat berpartisipasi dalam hierarki tersebut, termasuk:

- pemformatan lokal objek;
- default paragraf atau bingkai teks;
- gaya tabel, tabel, kolom, baris, atau format sel;
- pemformatan tata letak atau slide master;
- data tema atau default tingkat presentasi;
- tata letak atau master yang ditetapkan ke slide.

Jangan menyimpan objek data efektif sebagai snapshot permanen. Aspose.Slides dapat menyimpan beberapa data efektif dalam cache secara internal, dan panggilan `getEffective` berikutnya dapat memperbarui data tersebut. Jika Anda perlu membandingkan nilai sebelum dan sesudah perubahan, salin nilai skalar yang diperlukan—seperti tinggi font, warna, perataan, atau lebar bevel—ke variabel Anda sendiri sebelum melakukan perubahan.

Untuk mengubah nilai, perbarui objek format lokal yang sesuai lalu panggil `getEffective` untuk memverifikasi hasilnya. Objek data efektif sendiri bersifat read-only.

## **FAQ**

**Bagaimana saya dapat mengetahui level mana yang memberikan nilai efektif?**

Data efektif berisi nilai akhir, bukan sumbernya. Periksa objek lokal yang berlaku mulai dari level paling spesifik ke luar. Untuk teks, ini dapat mencakup bagian, paragraf, bingkai teks, tata letak, master, tema, dan default presentasi. Nilai yang tidak terdefinisi seperti `Float.NaN` atau `null` menunjukkan bahwa pencarian berlanjut ke level lain.

**Apa yang terjadi ketika tidak ada level yang mendefinisikan properti?**

Aspose.Slides menyelesaikan default PowerPoint atau perpustakaan yang sesuai. Nilai yang telah diselesaikan muncul dalam data efektif meskipun tidak ada objek lokal yang secara eksplisit mendefinisikannya.

**Mengapa nilai efektif kadang sama dengan nilai lokal?**

Nilai lokal memenangkan perhitungan pewarisan. Hal ini diharapkan ketika properti secara eksplisit diatur pada objek dan tidak ada aturan yang lebih spesifik yang menimpanya.

**Kapan saya harus menggunakan data lokal alih-alih data efektif?**

Gunakan data lokal untuk memeriksa atau mengedit level pemformatan tertentu. Gunakan data efektif ketika Anda membutuhkan tampilan akhir setelah pewarisan, aturan tema, dan gaya yang berlaku diselesaikan. [contoh perbandingan lengkap](#compare-local-inherited-and-effective-values) menunjukkan keduanya dalam alur kerja yang sama.