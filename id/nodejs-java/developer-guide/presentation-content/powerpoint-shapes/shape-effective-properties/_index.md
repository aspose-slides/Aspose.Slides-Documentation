---
title: Dapatkan Properti Efektif Bentuk dari Presentasi di JavaScript
linktitle: Properti Efektif
type: docs
weight: 50
url: /id/nodejs-java/shape-effective-properties/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Temukan bagaimana Aspose.Slides untuk Node.js via Java menghitung dan menerapkan properti bentuk efektif untuk rendering PowerPoint yang tepat."
---
## **Ikhtisar**

Topik ini menjelaskan perbedaan antara properti **lokal** dan **efektif**. Nilai lokal adalah nilai yang ditetapkan langsung pada tingkat pemformatan tertentu, seperti:

1. Properti bagian pada slide.
1. Gaya teks bentuk prototipe pada tata letak atau slide master, ketika bentuk bingkai teks bagian memiliki satu.
1. Pengaturan teks global dalam presentasi.

Nilai lokal dapat didefinisikan atau dihilangkan pada tingkat mana saja. Ketika Aspose.Slides membutuhkan pemformatan akhir "sebagaimana ditampilkan", ia menyelesaikan rantai pewarisan dan mengembalikan nilai **efektif**. Anda dapat memperolehnya dengan memanggil metode `getEffective` pada objek format lokal.

Contoh berikut menunjukkan cara mendapatkan nilai efektif. Diasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) dengan bingkai teks dan setidaknya satu bagian.

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Data pemformatan efektif mewakili pemformatan yang dihitung saat ini setelah pewarisan diterapkan. Pada implementasi saat ini, beberapa objek data efektif dapat disimpan dalam cache secara internal. Memanggil `getEffective` lagi setelah mengubah pemformatan induk atau yang diwarisi dapat menyegarkan data yang di‑cache, dan objek yang sebelumnya diperoleh mungkin tidak lagi mewakili keadaan sebelumnya. Jika Anda perlu menyimpan nilai efektif untuk digunakan kembali nanti, salin properti yang diperlukan, seperti tinggi font, warna isian, gaya font, atau perataan, ke dalam objek data Anda sendiri.
{{% /alert %}}

## **Dapatkan Properti Efektif Kamera**

Aspose.Slides memungkinkan Anda mendapatkan properti efektif kamera. Objek data kamera efektif berisi properti kamera yang tidak dapat diubah dan disajikan melalui nilai efektif yang dikembalikan untuk [ThreeDFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/).

Contoh kode berikut menunjukkan cara mendapatkan properti efektif untuk kamera. Diasumsikan bahwa bentuk pertama pada slide pertama memiliki pemformatan 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Dapatkan Properti Efektif Light Rig**

Aspose.Slides memungkinkan Anda mendapatkan properti efektif rig cahaya. Objek data rig cahaya efektif berisi properti rig cahaya yang tidak dapat diubah dan disajikan melalui nilai efektif yang dikembalikan untuk [ThreeDFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/).

Contoh kode berikut menunjukkan cara mendapatkan properti efektif untuk rig cahaya. Diasumsikan bahwa bentuk pertama pada slide pertama memiliki pemformatan 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Dapatkan Properti Efektif Bentuk Bevel**

Aspose.Slides memungkinkan Anda mendapatkan properti efektif bentuk bevel. Objek data bevel bentuk efektif berisi properti relief‑wajah yang tidak dapat diubah untuk sebuah bentuk dan disajikan melalui nilai efektif yang dikembalikan untuk [ThreeDFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/).

Contoh kode berikut menunjukkan cara mendapatkan properti efektif untuk bevel atas sebuah bentuk. Diasumsikan bahwa bentuk pertama pada slide pertama memiliki pemformatan 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Dapatkan Properti Efektif Bingkai Teks**

Dengan Aspose.Slides, Anda dapat mendapatkan properti efektif bingkai teks. Objek data yang dikembalikan berisi properti pemformatan bingkai teks.

Contoh kode berikut menunjukkan cara mendapatkan properti pemformatan bingkai teks yang efektif. Diasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) dengan bingkai teks.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Dapatkan Properti Efektif Gaya Teks**

Dengan Aspose.Slides, Anda dapat mendapatkan properti efektif gaya teks. Objek data yang dikembalikan berisi properti gaya teks.

Contoh kode berikut menunjukkan cara mendapatkan properti gaya teks yang efektif. Diasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) dengan bingkai teks.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Dapatkan Nilai Tinggi Font Efektif**

Dengan Aspose.Slides, Anda dapat memperoleh tinggi font yang efektif. Kode berikut menunjukkan bagaimana tinggi font efektif sebuah bagian berubah setelah nilai tinggi font lokal ditetapkan pada tingkat struktur presentasi yang berbeda.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **Dapatkan Format Isian Efektif untuk Tabel**

Dengan Aspose.Slides, Anda dapat memperoleh pemformatan isian efektif untuk bagian tabel yang berbeda. Objek data efektif yang dikembalikan berisi properti pemformatan isian. Pemformatan sel memiliki prioritas lebih tinggi daripada pemformatan baris, pemformatan baris memiliki prioritas lebih tinggi daripada pemformatan kolom, dan pemformatan kolom memiliki prioritas lebih tinggi daripada pemformatan seluruh tabel.

Akibatnya, properti pemformatan sel yang efektif digunakan untuk menggambar sel tabel. Contoh kode berikut menunjukkan cara mendapatkan pemformatan isian efektif untuk bagian tabel yang berbeda. Diasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [Table](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/table/).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah `getEffective` mengembalikan snapshot?**

Tidak selalu. Data efektif mewakili pemformatan yang dihitung setelah pewarisan diterapkan, tetapi beberapa objek data efektif dapat di‑cache secara internal. Panggilan `getEffective` berikutnya mungkin menghitung ulang pemformatan dan menyegarkan data yang di‑cache, sehingga objek yang sebelumnya diperoleh tidak boleh dianggap sebagai snapshot yang tahan lama.

**Kapan saya harus membaca properti efektif lagi?**

Panggil `getEffective` lagi setelah mengubah pemformatan lokal, gaya induk, pemformatan tata letak, pemformatan master, atau nilai default pada tingkat presentasi. Panggilan berikutnya akan mengevaluasi ulang hierarki pemformatan dan mengembalikan hasil efektif saat ini.

**Apakah mengubah atau menghapus slide tata letak/master memengaruhi properti efektif yang sudah diambil?**

Ya, tetapi perubahan tersebut tercermin pada panggilan `getEffective` berikutnya. Jika sumber pemformatan induk diubah atau dihapus, data efektif yang sebelumnya diperoleh mungkin usang. Setelah `getEffective` dipanggil lagi, Aspose.Slides akan mengevaluasi ulang pohon pemformatan dan font, warna, ukuran, atau nilai lain yang dihasilkan dapat berubah.

**Apakah saya dapat memodifikasi nilai melalui objek data efektif?**

Tidak. Objek data efektif hanya menampilkan nilai yang dihitung. Lakukan perubahan pada objek pemformatan lokal, kemudian peroleh kembali nilai efektif.

**Apa yang terjadi jika suatu properti tidak diatur pada tingkat bentuk, tata letak/master, maupun pengaturan global?**

Nilai efektif ditentukan oleh mekanisme default, yang mencakup nilai default PowerPoint dan Aspose.Slides. Nilai yang terpecahkan tersebut menjadi bagian dari data efektif saat ini.

**Dari nilai font efektif, dapatkah saya mengetahui level mana yang menyediakan ukuran atau jenis huruf?**

Tidak secara langsung. Data efektif mengembalikan nilai akhir. Untuk menemukan sumbernya, periksa nilai lokal pada bagian, paragraf, bingkai teks, dan gaya teks pada tata letak, master, serta tingkat presentasi untuk melihat di mana definisi eksplisit pertama muncul.

**Mengapa nilai efektif kadang tampak identik dengan nilai lokal?**

Karena nilai lokal ternyata menjadi nilai akhir (tidak diperlukan pewarisan tingkat lebih tinggi). Pada kasus seperti itu, nilai efektif sama dengan nilai lokal.

**Kapan saya harus menggunakan properti efektif, dan kapan harus bekerja hanya dengan yang lokal?**

Gunakan data efektif ketika Anda memerlukan hasil "sebagaimana ditampilkan" setelah semua pewarisan diterapkan, seperti untuk menyelaraskan warna, indentasi, atau ukuran. Jika Anda perlu menyimpan nilai tersebut terlepas dari perubahan pemformatan nanti, salin properti yang diperlukan ke dalam objek Anda sendiri. Jika Anda perlu mengubah pemformatan pada tingkat tertentu, modifikasi properti lokal dan kemudian, jika diperlukan, baca kembali data efektif untuk memverifikasi hasilnya.