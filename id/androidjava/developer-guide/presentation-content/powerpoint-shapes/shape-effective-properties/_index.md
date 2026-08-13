---
title: "Mendapatkan Properti Efektif Bentuk dari Presentasi pada Android"
linktitle: "Properti Efektif"
type: docs
weight: 50
url: /id/androidjava/shape-effective-properties/
keywords:
- "properti bentuk"
- "properti kamera"
- "rig cahaya"
- "bentuk bevel"
- "kerangka teks"
- "gaya teks"
- "tinggi font"
- "format isi"
- "PowerPoint"
- "presentasi"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Temukan bagaimana Aspose.Slides untuk Android melalui Java menghitung dan menerapkan properti bentuk efektif untuk rendering PowerPoint yang tepat."
---
## **Ikhtisar**

Topik ini menjelaskan perbedaan antara properti **lokal** dan **efektif**. Nilai lokal adalah nilai yang diatur langsung pada tingkat pemformatan tertentu, seperti:

1. Properti bagian pada sebuah slide.
1. Gaya teks bentuk prototipe pada tata letak atau slide master, ketika bentuk kerangka teks bagian memiliki satu.
1. Pengaturan teks global dalam sebuah presentasi.

Nilai lokal dapat didefinisikan atau diabaikan pada tingkat mana pun. Ketika Aspose.Slides membutuhkan pemformatan akhir “seperti yang dirender”, ia menyelesaikan rantai pewarisan dan mengembalikan nilai **efektif**. Anda dapat memperolehnya dengan memanggil metode `getEffective()` pada objek format lokal.

Contoh berikut menunjukkan cara mendapatkan nilai efektif. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) dengan kerangka teks dan setidaknya satu bagian.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="info" %}}
Data pemformatan efektif mewakili pemformatan terhitung saat ini setelah pewarisan diterapkan. Pada implementasi saat ini, beberapa objek data efektif, seperti [IPortionFormatEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportionformateffectivedata/), dapat disimpan dalam cache secara internal. Memanggil `getEffective()` lagi setelah mengubah pemformatan induk atau yang diwariskan dapat menyegarkan data yang di‑cache, dan objek yang sebelumnya diperoleh mungkin tidak lagi merepresentasikan keadaan sebelumnya. Jika Anda perlu menyimpan nilai efektif untuk digunakan kembali nanti, salin properti yang diperlukan, seperti tinggi font, warna isi, gaya font, atau perataan, ke dalam objek data Anda sendiri.
{{% /alert %}}

## **Mendapatkan Properti Efektif Kamera**

Aspose.Slides memungkinkan Anda mendapatkan properti efektif kamera. Antarmuka [ICameraEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icameraeffectivedata/) merepresentasikan objek tak dapat diubah yang berisi properti kamera efektif. Sebuah instance [ICameraEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icameraeffectivedata/) diakses melalui [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformateffectivedata/), yang menyediakan nilai efektif untuk [IThreeDFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/).

Potongan kode berikut menunjukkan cara mendapatkan properti efektif untuk kamera. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama memiliki pemformatan 3D.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **Mendapatkan Properti Efektif Light Rig**

Aspose.Slides memungkinkan Anda mendapatkan properti efektif light rig. Antarmuka [ILightRigEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilightrigeffectivedata/) merepresentasikan objek tak dapat diubah yang berisi properti light rig efektif. Sebuah instance [ILightRigEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilightrigeffectivedata/) diakses melalui [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformateffectivedata/), yang menyediakan nilai efektif untuk [IThreeDFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/).

Potongan kode berikut menunjukkan cara mendapatkan properti efektif untuk light rig. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama memiliki pemformatan 3D.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **Mendapatkan Properti Efektif Bevel Bentuk**

Aspose.Slides memungkinkan Anda mendapatkan properti efektif bevel bentuk. Antarmuka [IShapeBevelEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapebeveleffectivedata/) merepresentasikan objek tak dapat diubah yang berisi properti relief muka efektif untuk sebuah bentuk. Sebuah instance [IShapeBevelEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapebeveleffectivedata/) diakses melalui [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformateffectivedata/), yang menyediakan nilai efektif untuk [IThreeDFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/).

Potongan kode berikut menunjukkan cara mendapatkan properti efektif untuk bevel atas sebuah bentuk. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama memiliki pemformatan 3D.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **Mendapatkan Properti Efektif Kerangka Teks**

Dengan Aspose.Slides, Anda dapat mendapatkan properti efektif kerangka teks. Antarmuka [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframeformateffectivedata/) berisi properti pemformatan kerangka teks efektif.

Potongan kode berikut menunjukkan cara mendapatkan properti pemformatan kerangka teks efektif. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) dengan kerangka teks.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    presentation.dispose();
}
```

## **Mendapatkan Properti Efektif Gaya Teks**

Dengan Aspose.Slides, Anda dapat mendapatkan properti efektif gaya teks. Antarmuka [ITextStyleEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextstyleeffectivedata/) berisi properti gaya teks efektif.

Potongan kode berikut menunjukkan cara mendapatkan properti gaya teks efektif. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) dengan kerangka teks.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **Mendapatkan Nilai Tinggi Font Efektif**

Dengan Aspose.Slides, Anda dapat mendapatkan tinggi font yang efektif. Kode berikut mendemonstrasikan bagaimana tinggi font efektif bagian berubah setelah nilai tinggi font lokal diatur pada tingkat struktur presentasi yang berbeda.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mendapatkan Format Isi Efektif untuk Tabel**

Dengan Aspose.Slides, Anda dapat mendapatkan pemformatan isi efektif untuk berbagai bagian tabel. Antarmuka [IFillFormatEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ifillformateffectivedata/) berisi properti pemformatan isi efektif. Pemformatan sel memiliki prioritas lebih tinggi daripada pemformatan baris, pemformatan baris lebih tinggi daripada pemformatan kolom, dan pemformatan kolom lebih tinggi daripada pemformatan seluruh tabel.

Akibatnya, properti [ICellFormatEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icellformateffectivedata/) digunakan untuk menggambar sel tabel. Potongan kode berikut menunjukkan cara mendapatkan pemformatan isi efektif untuk berbagai bagian tabel. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itable/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Apakah `getEffective()` mengembalikan snapshot?

Tidak selalu. Data efektif merepresentasikan pemformatan yang dihitung setelah pewarisan diterapkan, tetapi beberapa objek data efektif dapat disimpan dalam cache secara internal. Pemanggilan `getEffective()` berikutnya dapat menghitung ulang pemformatan dan menyegarkan data yang di‑cache, sehingga objek yang sebelumnya diperoleh tidak boleh diperlakukan sebagai snapshot yang tahan lama.

### Kapan saya harus membaca kembali properti efektif?

Panggil `getEffective()` lagi setelah mengubah pemformatan lokal, gaya induk, pemformatan tata letak, pemformatan master, atau nilai default pada tingkat presentasi. Panggilan berikutnya akan mengevaluasi ulang hierarki pemformatan dan mengembalikan hasil efektif saat ini.

### Apakah mengubah atau menghapus slide tata letak/master memengaruhi properti efektif yang sudah diambil?

Ya, tetapi perubahan tersebut tercermin pada pemanggilan `getEffective()` berikutnya. Jika sumber pemformatan induk diubah atau dihapus, data efektif yang sudah diperoleh sebelumnya mungkin sudah usang. Setelah `getEffective()` dipanggil lagi, Aspose.Slides mengevaluasi ulang pohon pemformatan dan font, warna, ukuran, atau nilai lainnya dapat berubah.

### Dapatkah saya memodifikasi nilai melalui objek data efektif?

Tidak. Objek data efektif hanya menampilkan nilai yang telah dihitung. Lakukan perubahan pada objek pemformatan lokal, kemudian peroleh kembali nilai efektif.

### Apa yang terjadi jika sebuah properti tidak diatur pada tingkat bentuk, tata letak/master, maupun pengaturan global?

Nilai efektif ditentukan oleh mekanisme default, yang mencakup nilai default PowerPoint dan Aspose.Slides. Nilai yang diselesaikan tersebut menjadi bagian dari data efektif saat ini.

### Dari nilai font efektif, dapatkah saya mengetahui tingkat mana yang menyediakan ukuran atau jenis hurufnya?

Tidak secara langsung. Data efektif mengembalikan nilai final. Untuk menemukan sumbernya, periksa nilai lokal pada bagian, paragraf, kerangka teks, dan gaya teks pada tata letak, master, serta tingkat presentasi untuk melihat di mana definisi eksplisit pertama muncul.

### Mengapa nilai efektif kadang terlihat identik dengan nilai lokal?

Karena nilai lokal ternyata merupakan nilai final (tidak diperlukan pewarisan tingkat lebih tinggi). Dalam kasus tersebut, nilai efektif sama dengan nilai lokal.

### Kapan saya harus menggunakan properti efektif, dan kapan saya hanya harus bekerja dengan nilai lokal?

Gunakan data efektif ketika Anda memerlukan hasil “seperti yang dirender” setelah semua pewarisan diterapkan, misalnya untuk menyelaraskan warna, indentasi, atau ukuran. Jika Anda perlu mempertahankan nilai tersebut terlepas dari perubahan pemformatan di masa mendatang, salin properti yang diperlukan ke dalam objek Anda sendiri. Jika Anda perlu mengubah pemformatan pada tingkat tertentu, modifikasi properti lokal dan kemudian, bila diperlukan, baca kembali data efektif untuk memverifikasi hasilnya.