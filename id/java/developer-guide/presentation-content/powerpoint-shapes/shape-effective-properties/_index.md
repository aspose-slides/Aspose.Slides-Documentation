---
title: Dapatkan Properti Efektif Bentuk dari Presentasi di Java
linktitle: Properti Efektif
type: docs
weight: 50
url: /id/java/shape-effective-properties/
keywords:
- properti bentuk
- properti kamera
- rig cahaya
- bentuk bevel
- bingkai teks
- gaya teks
- tinggi font
- format isi
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Temukan bagaimana Aspose.Slides untuk Java menghitung dan menerapkan properti bentuk efektif untuk render PowerPoint yang presisi."
---
## **Gambaran Umum**

Topik ini menjelaskan perbedaan antara properti **lokal** dan **efektif**. Nilai lokal adalah nilai yang diatur secara langsung pada tingkat pemformatan tertentu, seperti:

1. Properti bagian pada slide.  
1. Gaya teks bentuk prototipe pada tata letak atau slide master, ketika bentuk bingkai teks bagian memiliki satu.  
1. Pengaturan teks global dalam presentasi.

Nilai lokal dapat didefinisikan atau diabaikan pada tingkat mana pun. Ketika Aspose.Slides memerlukan pemformatan akhir "seperti yang dirender", ia menyelesaikan rantai pewarisan dan mengembalikan nilai **efektif**. Anda dapat memperolehnya dengan memanggil metode `getEffective` pada objek format lokal.

Contoh berikut menunjukkan cara mendapatkan nilai efektif. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAutoShape) dengan bingkai teks dan setidaknya satu bagian.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Data pemformatan efektif mewakili pemformatan yang dihitung saat ini setelah pewarisan diterapkan. Dalam implementasi saat ini, beberapa objek data efektif, seperti [IPortionFormatEffectiveData](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPortionFormatEffectiveData), dapat disimpan dalam cache secara internal. Memanggil `getEffective` lagi setelah mengubah pemformatan induk atau yang diwarisi dapat menyegarkan data yang di-cache, dan objek yang diperoleh sebelumnya mungkin tidak lagi mewakili keadaan sebelumnya. Jika Anda perlu mempertahankan nilai efektif untuk penggunaan kembali nanti, salin properti yang diperlukan, seperti tinggi font, warna isi, gaya font, atau perataan, ke dalam objek data Anda sendiri.
{{% /alert %}}

## **Dapatkan Properti Efektif Kamera**

Aspose.Slides memungkinkan Anda mendapatkan properti efektif kamera. Antarmuka [ICameraEffectiveData](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICameraEffectiveData) mewakili objek tak dapat diubah yang berisi properti kamera efektif. Sebuah instance [ICameraEffectiveData](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICameraEffectiveData) diekspos melalui [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/java/com.aspose.slides/IThreeDFormatEffectiveData), yang menyediakan nilai efektif untuk [IThreeDFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/IThreeDFormat).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Dapatkan Properti Efektif Light Rig**

Aspose.Slides memungkinkan Anda mendapatkan properti efektif Light Rig. Antarmuka [ILightRigEffectiveData](https://reference.aspose.com/slides/id/java/com.aspose.slides/ILightRigEffectiveData) mewakili objek tak dapat diubah yang berisi properti Light Rig efektif. Sebuah instance [ILightRigEffectiveData](https://reference.aspose.com/slides/id/java/com.aspose.slides/ILightRigEffectiveData) diekspos melalui [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/java/com.aspose.slides/IThreeDFormatEffectiveData), yang menyediakan nilai efektif untuk [IThreeDFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/IThreeDFormat).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Dapatkan Properti Efektif Bentuk Bevel**

Aspose.Slides memungkinkan Anda mendapatkan properti efektif bevel bentuk. Antarmuka [IShapeBevelEffectiveData](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeBevelEffectiveData) mewakili objek tak dapat diubah yang berisi properti relief‑wajah efektif untuk sebuah bentuk. Sebuah instance [IShapeBevelEffectiveData](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeBevelEffectiveData) diekspos melalui [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/java/com.aspose.slides/IThreeDFormatEffectiveData), yang menyediakan nilai efektif untuk [IThreeDFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/IThreeDFormat).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Dapatkan Properti Efektif Bingkai Teks**

Dengan Aspose.Slides, Anda dapat mendapatkan properti efektif bingkai teks. Antarmuka [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITextFrameFormatEffectiveData) berisi properti pemformatan bingkai teks efektif.

Contoh berikut menunjukkan cara mendapatkan properti pemformatan bingkai teks efektif. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAutoShape) dengan bingkai teks.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Dapatkan Properti Efektif Gaya Teks**

Dengan Aspose.Slides, Anda dapat mendapatkan properti efektif gaya teks. Antarmuka [ITextStyleEffectiveData](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITextStyleEffectiveData) berisi properti gaya teks efektif.

Contoh berikut menunjukkan cara mendapatkan properti gaya teks efektif. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAutoShape) dengan bingkai teks.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Dapatkan Nilai Tinggi Font Efektif**

Dengan Aspose.Slides, Anda dapat mendapatkan tinggi font efektif. Kode berikut menunjukkan bagaimana tinggi font efektif pada sebuah bagian berubah setelah nilai tinggi font lokal diatur pada tingkat struktur presentasi yang berbeda.

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

Dengan Aspose.Slides, Anda dapat mendapatkan format isi efektif untuk berbagai bagian tabel. Antarmuka [IFillFormatEffectiveData](https://reference.aspose.com/slides/id/java/com.aspose.slides/IFillFormatEffectiveData) berisi properti format isi efektif. Pemformatan sel memiliki prioritas lebih tinggi daripada pemformatan baris, pemformatan baris lebih tinggi daripada pemformatan kolom, dan pemformatan kolom lebih tinggi daripada pemformatan seluruh tabel.

Akibatnya, properti [ICellFormatEffectiveData](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICellFormatEffectiveData) digunakan untuk menggambar sel tabel. Contoh berikut menunjukkan cara mendapatkan format isi efektif untuk berbagai bagian tabel. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [ITable](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITable).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah `getEffective` mengembalikan snapshot?**

Tidak selalu. Data efektif mewakili pemformatan yang dihitung setelah pewarisan diterapkan, tetapi beberapa objek data efektif dapat disimpan dalam cache secara internal. Panggilan `getEffective` berikutnya dapat menghitung ulang pemformatan dan menyegarkan data yang di‑cache, sehingga objek yang sebelumnya diperoleh tidak boleh dianggap sebagai snapshot yang tahan lama.

**Kapan saya harus membaca kembali properti efektif?**

Panggil `getEffective` lagi setelah mengubah pemformatan lokal, gaya induk, pemformatan tata letak, pemformatan master, atau nilai default tingkat presentasi. Panggilan berikutnya akan mengevaluasi kembali hierarki pemformatan dan mengembalikan hasil efektif yang saat ini.

**Apakah mengubah atau menghapus slide tata letak/master memengaruhi properti efektif yang sudah diambil?**

Ya, tetapi perubahan tersebut tercermin pada panggilan `getEffective` berikutnya. Jika sumber format induk diubah atau dihapus, data efektif yang sebelumnya diperoleh mungkin sudah usang. Setelah `getEffective` dipanggil lagi, Aspose.Slides mengevaluasi kembali pohon pemformatan dan nilai font, warna, ukuran, atau nilai lainnya dapat berubah.

**Dapatkah saya memodifikasi nilai melalui objek data efektif?**

Tidak. Objek data efektif hanya menampilkan nilai yang telah dihitung. Lakukan perubahan pada objek pemformatan lokal, kemudian peroleh kembali nilai efektif.

**Bagaimana jika suatu properti tidak diatur pada tingkat bentuk, tata letak/master, maupun pengaturan global?**

Nilai efektif ditentukan oleh mekanisme default, yang mencakup nilai bawaan PowerPoint dan Aspose.Slides. Nilai yang diselesaikan tersebut menjadi bagian dari data efektif saat ini.

**Dari nilai font efektif, bisakah saya mengetahui level mana yang menyediakan ukuran atau jenis huruf?**

Tidak secara langsung. Data efektif mengembalikan nilai akhir. Untuk menemukan sumbernya, periksa nilai lokal pada bagian, paragraf, bingkai teks, dan gaya teks pada tata letak, master, serta tingkat presentasi untuk melihat di mana definisi eksplisit pertama muncul.

**Mengapa nilai efektif kadang terlihat identik dengan nilai lokal?**

Karena nilai lokal ternyata menjadi nilai akhir (tidak diperlukan pewarisan dari level yang lebih tinggi). Dalam kasus tersebut, nilai efektif sama dengan nilai lokal.

**Kapan saya harus menggunakan properti efektif, dan kapan saya hanya bekerja dengan properti lokal?**

Gunakan data efektif ketika Anda memerlukan hasil "seperti yang dirender" setelah semua pewarisan diterapkan, misalnya untuk menyelaraskan warna, indentasi, atau ukuran. Jika Anda perlu mempertahankan nilai tersebut terlepas dari perubahan pemformatan selanjutnya, salin properti yang diperlukan ke dalam objek Anda sendiri. Jika Anda perlu mengubah pemformatan pada level tertentu, ubah properti lokal dan kemudian, bila diperlukan, baca kembali data efektif untuk memverifikasi hasilnya.