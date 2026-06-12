---
title: Dapatkan Properti Efektif Bentuk dari Presentasi di Android
linktitle: Properti Efektif
type: docs
weight: 50
url: /id/androidjava/shape-effective-properties/
keywords:
- properti bentuk
- properti kamera
- rig cahaya
- bentuk bevel
- bingkai teks
- gaya teks
- tinggi font
- format isian
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Temukan bagaimana Aspose.Slides untuk Android via Java menghitung dan menerapkan properti bentuk efektif untuk rendering PowerPoint yang presisi."
---
## **Gambaran Umum**

Topik ini menjelaskan perbedaan antara properti **lokal** dan **efektif**. Nilai lokal adalah nilai yang ditetapkan langsung pada tingkat format tertentu, seperti:

1. Properti portion pada slide.  
1. Gaya teks bentuk prototipe pada tata letak atau slide master, ketika bentuk bingkai teks portion memiliki satu.  
1. Pengaturan teks global dalam sebuah presentasi.  

Nilai lokal dapat didefinisikan atau diabaikan pada tingkat mana pun. Ketika Aspose.Slides memerlukan format akhir “seperti yang dirender”, ia menyelesaikan rantai pewarisan dan mengembalikan nilai **efektif**. Anda dapat memperolehnya dengan memanggil metode `getEffective()` pada objek format lokal.

Contoh berikut memperlihatkan cara mendapatkan nilai efektif. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) dengan bingkai teks dan setidaknya satu portion.

```java
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

{{% alert color="primary" %}}
Data format efektif mewakili format yang dihitung saat ini setelah pewarisan diterapkan. Pada implementasi saat ini, beberapa objek data efektif, seperti [IPortionFormatEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportionformateffectivedata/), mungkin disimpan dalam cache secara internal. Memanggil `getEffective()` lagi setelah mengubah format induk atau yang diwarisi dapat menyegarkan data yang di-cache, dan objek yang sebelumnya diperoleh mungkin tidak lagi mewakili keadaan sebelumnya. Jika Anda perlu mempertahankan nilai efektif untuk penggunaan kembali nanti, salin properti yang diperlukan, seperti tinggi font, warna isian, gaya font, atau perataan, ke dalam objek data Anda sendiri.
{{% /alert %}}

## **Dapatkan Properti Efektif dari Kamera**

Aspose.Slides memungkinkan Anda mendapatkan properti efektif dari kamera. Antarmuka [ICameraEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icameraeffectivedata/) mewakili sebuah objek tak berubah yang berisi properti kamera yang efektif. Sebuah instance [ICameraEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icameraeffectivedata/) disajikan melalui [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformateffectivedata/), yang menyediakan nilai efektif untuk [IThreeDFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/).

Contoh kode berikut memperlihatkan cara mendapatkan properti efektif untuk kamera. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama memiliki format 3D.

```java
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

## **Dapatkan Properti Efektif dari Light Rig**

Aspose.Slides memungkinkan Anda mendapatkan properti efektif dari light rig. Antarmuka [ILightRigEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilightrigeffectivedata/) mewakili sebuah objek tak berubah yang berisi properti light rig yang efektif. Sebuah instance [ILightRigEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilightrigeffectivedata/) disajikan melalui [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformateffectivedata/), yang menyediakan nilai efektif untuk [IThreeDFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/).

Contoh kode berikut memperlihatkan cara mendapatkan properti efektif untuk light rig. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama memiliki format 3D.

```java
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

## **Dapatkan Properti Efektif dari Bentuk Bevel**

Aspose.Slides memungkinkan Anda mendapatkan properti efektif dari bevel bentuk. Antarmuka [IShapeBevelEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapebeveleffectivedata/) mewakili sebuah objek tak berubah yang berisi properti relief wajah yang efektif untuk sebuah bentuk. Sebuah instance [IShapeBevelEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapebeveleffectivedata/) disajikan melalui [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformateffectivedata/), yang menyediakan nilai efektif untuk [IThreeDFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ithreedformat/).

Contoh kode berikut memperlihatkan cara mendapatkan properti efektif untuk bevel atas sebuah bentuk. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama memiliki format 3D.

```java
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

## **Dapatkan Properti Efektif dari Bingkai Teks**

Dengan Aspose.Slides, Anda dapat memperoleh properti efektif dari bingkai teks. Antarmuka [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframeformateffectivedata/) berisi properti format bingkai teks yang efektif.

Contoh kode berikut memperlihatkan cara mendapatkan properti format bingkai teks yang efektif. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) dengan bingkai teks.

```java
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

## **Dapatkan Properti Efektif dari Gaya Teks**

Dengan Aspose.Slides, Anda dapat memperoleh properti efektif dari gaya teks. Antarmuka [ITextStyleEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextstyleeffectivedata/) berisi properti gaya teks yang efektif.

Contoh kode berikut memperlihatkan cara mendapatkan properti gaya teks yang efektif. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) dengan bingkai teks.

```java
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

## **Dapatkan Nilai Tinggi Font Efektif**

Dengan Aspose.Slides, Anda dapat memperoleh tinggi font yang efektif. Kode berikut menunjukkan bagaimana tinggi font efektif sebuah portion berubah setelah nilai tinggi font lokal ditetapkan pada tingkat struktur presentasi yang berbeda.

```java
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

## **Dapatkan Format Isi Efektif untuk Tabel**

Dengan Aspose.Slides, Anda dapat memperoleh format isi yang efektif untuk berbagai bagian tabel. Antarmuka [IFillFormatEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ifillformateffectivedata/) berisi properti format isi yang efektif. Format sel memiliki prioritas lebih tinggi daripada format baris, format baris memiliki prioritas lebih tinggi daripada format kolom, dan format kolom memiliki prioritas lebih tinggi daripada format seluruh tabel.

Akibatnya, properti [ICellFormatEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icellformateffectivedata/) digunakan untuk menggambar sel tabel. Contoh kode berikut memperlihatkan cara mendapatkan format isi efektif untuk berbagai bagian tabel. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itable/).

```java
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

**Apakah `getEffective()` mengembalikan snapshot?**

Tidak selalu. Data efektif mewakili format yang dihitung setelah pewarisan diterapkan, tetapi beberapa objek data efektif dapat disimpan dalam cache secara internal. Panggilan `getEffective()` berikutnya dapat menghitung ulang format dan menyegarkan data yang di-cache, sehingga objek yang diperoleh sebelumnya tidak boleh dianggap sebagai snapshot yang tahan lama.

**Kapan saya harus membaca properti efektif lagi?**

Panggil `getEffective()` lagi setelah mengubah format lokal, gaya induk, format tata letak, format master, atau default tingkat presentasi. Panggilan berikutnya akan mengevaluasi kembali hierarki format dan mengembalikan hasil efektif saat ini.

**Apakah mengubah atau menghapus slide layout/master memengaruhi properti efektif yang sudah diambil?**

Ya, tetapi perubahan tersebut tercermin pada pemanggilan `getEffective()` berikutnya. Jika sumber format induk diubah atau dihapus, data efektif yang sebelumnya diperoleh mungkin sudah usang. Setelah `getEffective()` dipanggil lagi, Aspose.Slides akan mengevaluasi kembali pohon format dan font, warna, ukuran, atau nilai lainnya dapat berubah.

**Bisakah saya mengubah nilai melalui objek data efektif?**

Tidak. Objek data efektif hanya menampilkan nilai yang dihitung. Lakukan perubahan pada objek format lokal, lalu peroleh nilai efektif kembali.

**Apa yang terjadi jika properti tidak diatur pada tingkat bentuk, maupun pada layout/master, maupun pada pengaturan global?**

Nilai efektif ditentukan oleh mekanisme default, yang mencakup nilai default PowerPoint dan Aspose.Slides. Nilai yang teridentifikasi menjadi bagian dari data efektif saat ini.

**Dari nilai font efektif, dapatkah saya mengetahui level mana yang menyediakan ukuran atau jenis huruf?**

Tidak secara langsung. Data efektif hanya mengembalikan nilai akhir. Untuk menemukan sumbernya, periksa nilai lokal pada portion, paragraf, bingkai teks, dan gaya teks pada tingkat layout, master, dan presentasi untuk melihat di mana definisi eksplisit pertama muncul.

**Mengapa nilai efektif kadang terlihat identik dengan nilai lokal?**

Karena nilai lokal akhirnya menjadi nilai akhir (tidak diperlukan pewarisan dari tingkat yang lebih tinggi). Dalam kasus tersebut, nilai efektif sama dengan nilai lokal.

**Kapan saya harus menggunakan properti efektif, dan kapan saya hanya bekerja dengan properti lokal?**

Gunakan data efektif ketika Anda membutuhkan hasil “seperti yang dirender” setelah semua pewarisan diterapkan, misalnya untuk menyelaraskan warna, indentasi, atau ukuran. Jika Anda perlu mempertahankan nilai-nilai tersebut terlepas dari perubahan format nantinya, salin properti yang diperlukan ke dalam objek Anda sendiri. Jika Anda perlu mengubah format pada tingkat tertentu, ubah properti lokal dan kemudian, bila diperlukan, baca kembali data efektif untuk memverifikasi hasilnya.