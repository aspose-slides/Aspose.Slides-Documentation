---
title: Kelola Kotak Teks dalam Presentasi Menggunakan Java
linktitle: Kelola Kotak Teks
type: docs
weight: 20
url: /id/java/manage-textbox/
keywords:
- kotak teks
- bingkai teks
- tambahkan teks
- perbarui teks
- buat kotak teks
- periksa kotak teks
- tambahkan kolom teks
- tambahkan tautan hiper
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Buat, identifikasi, format, dan perbarui kotak teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Java."
---
## **Pendahuluan**

Di Aspose.Slides for Java, teks slide disimpan dalam bingkai teks yang menjadi bagian dari shape. Antarmuka [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) mewakili shape yang paling umum berisi teks dan mengekspose teksnya melalui metode [IAutoShape.getTextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/#getTextFrame--) .

{{% alert color="info" title="Note" %}}
Setiap auto shape mengimplementasikan [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/), tetapi tidak setiap shape adalah auto shape atau mendukung bingkai teks. Saat memproses presentasi yang ada, periksa bahwa sebuah shape mengimplementasikan [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) sebelum mengakses teksnya.
{{% /alert %}}

## **Buat Kotak Teks pada Slide**

Untuk membuat kotak teks, tambahkan auto shape ke slide, tambahkan teks ke bingkai teksnya, dan simpan presentasi. Contoh berikut membuat kotak teks persegi panjang:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Koordinat dan dimensi yang diberikan ke [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) diukur dalam poin. [IAutoShape.addTextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) menginisialisasi bingkai teks dengan teks yang diberikan.

## **Periksa Shape Kotak Teks**

Gunakan metode [IAutoShape.isTextBox](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/#isTextBox--) untuk menentukan apakah sebuah auto shape diperlakukan sebagai kotak teks. Ini berguna ketika presentasi berisi baik shape yang membawa teks maupun shape grafis murni.

![Kotak teks dan sebuah shape](istextbox.png)

Contoh berikut memeriksa setiap auto shape dalam sebuah presentasi:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Sebuah auto shape yang baru ditambahkan tidak dianggap sebagai kotak teks hingga ia berisi teks tidak kosong. Anda dapat memberikan teks tersebut melalui [IAutoShape.addTextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) atau [ITextFrame.setText](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#setText-java.lang.String-). Menambahkan atau menetapkan string kosong menyebabkan [IAutoShape.isTextBox](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/#isTextBox--) mengembalikan `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

Dua pemanggilan pertama mencetak `true`; dua pemanggilan terakhir mencetak `false`.

## **Temukan Shape yang Memiliki Bingkai Teks**

Kode pemrosesan teks generik dapat menerima sebuah [ITextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/) tanpa mengetahui objek presentasi mana yang memilikinya. Gunakan metode baca-saja [ITextFrame.getParentShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#getParentShape--) untuk menavigasi kembali ke [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/) pemiliknya.

Untuk bingkai teks yang dimiliki oleh auto shape atau shape lain yang membawa teks, [ITextFrame.getParentShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#getParentShape--) mengembalikan pemiliknya dan [ITextFrame.getParentCell](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#getParentCell--) mengembalikan `null`. Periksa nilai yang dikembalikan sebelum mengaksesnya. Untuk mengidentifikasi pemilik shape dan sel tabel, termasuk shape yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/java/search-and-replace-text/).

## **Tambahkan Kolom ke Kotak Teks**

Metode [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframeformat/#setColumnCount-int-) membagi bingkai teks menjadi kolom, sementara [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) mengatur jarak antara kolom dalam poin. Kedua pengaturan termasuk dalam [ITextFrameFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframeformat/) dan dapat diubah melalui bingkai teks pada kotak teks yang ada. Teks mengalir ulang di antara kolom dalam shape yang sama; tidak berlanjut ke shape lain.

Contoh berikut membuat kotak teks tiga kolom dengan jarak 10 poin antara kolom, menyimpan presentasi, dan membaca kembali pengaturan yang disimpan dari file keluaran:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Ekstrak Teks dari Setiap Kolom**

Gunakan [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#splitTextByColumns--) untuk mengambil teks yang ditetapkan ke setiap kolom visual dalam bingkai teks yang ada. Metode ini mengembalikan satu string untuk tiap kolom, dalam urutan baca berdasarkan kolom. Bingkai teks satu kolom menghasilkan array dengan satu elemen, dan kolom kosong diwakili oleh string kosong. String berisi teks polos saja; pemformatan tingkat bagian tidak dipertahankan.

Ini berguna ketika Anda perlu:
- Mengekstrak teks sambil mempertahankan urutan baca berbasis kolom.
- Mengindeks atau membandingkan konten slide multi-kolom.
- Mengekspor setiap kolom ke file terpisah, field basis data, atau tujuan lain.
- Memeriksa bagaimana teks didistribusikan kembali setelah mengubah jumlah kolom dengan [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframeformat/#setColumnCount-int-), jaraknya dengan [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), font, atau ukuran bingkai teks.

Metode ini melaporkan teks yang tersebar dalam [ITextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/) saat ini; ia tidak secara otomatis mengalirkan teks antara shape atau kotak teks yang terpisah. Distribusi kolom dapat bergantung pada font yang tersedia dan pengaturan tata letak teks lainnya, jadi pastikan font yang diperlukan tersedia ketika hasil yang konsisten penting.

Contoh berikut memuat sebuah presentasi, menemukan auto shape multi-kolom pertama dengan bingkai teks, membaca jumlah kolom yang dikonfigurasi, dan menulis teks dari setiap kolom ke file terpisah. Shape yang tidak menyediakan bingkai teks dilewati.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            Path outputPath = Paths.get("Column-" + columnNumber + ".txt");
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try {
                Files.write(outputPath, textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Perbarui Teks**

Untuk memperbarui teks di seluruh presentasi, iterasi melalui slide dan shape, pilih auto shape, dan kemudian edit bagian teksnya. Bekerja pada tingkat bagian memungkinkan Anda mengubah teks dan pemformatan karakter sekaligus.

Contoh berikut mengganti setiap kemunculan `years` dengan `months` dalam teks auto shape dan membuat setiap bagian yang terkena menjadi tebal:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Penelusuran ini memperbarui teks hanya dalam auto shape. Teks yang disimpan dalam tabel, bagan, SmartArt, atau shape yang dikelompokkan memerlukan penelusuran koleksi objek masing‑masing.

## **Tambahkan Kotak Teks dengan Tautan Hiper**

Sebuah tautan hiper dapat ditetapkan ke bagian teks tertentu, sehingga hanya teks tersebut yang berfungsi sebagai tautan yang dapat diklik. Gunakan [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/id/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) untuk mengaitkan bagian tersebut dengan URL eksternal.

Contoh berikut membuat teks bertautan dan menyimpannya ke presentasi:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apa perbedaan antara kotak teks dan placeholder teks pada slide master atau layout?**

Sebuah [placeholder](/slides/id/java/manage-placeholder/) dapat mewarisi posisi dan pemformatannya dari sebuah [master slide](https://reference.aspose.com/slides/id/java/com.aspose.slides/masterslide/) atau [layout slide](https://reference.aspose.com/slides/id/java/com.aspose.slides/layoutslide/). Kotak teks biasa adalah shape independen pada slide tempat ia dibuat dan tidak memperoleh perilaku placeholder ketika tata letak berubah.

**Bagaimana saya dapat mengganti teks tanpa mengubah teks dalam bagan, tabel, atau SmartArt?**

Batasi penelusuran hanya pada shape yang mengimplementasikan [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/), seperti yang ditunjukkan dalam contoh Perbarui Teks. Bagan, tabel, dan SmartArt menyimpan teks dalam model objek masing‑masing, sehingga tidak diubah oleh loop tersebut.