---
title: Kelola Placeholder Presentasi di Android
linktitle: Kelola Placeholder
type: docs
weight: 10
url: /id/androidjava/manage-placeholder/
keywords:
- placeholder
- placeholder teks
- placeholder gambar
- placeholder diagram
- placeholder konten
- teks prompt
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara memeriksa dan menyunting placeholder teks, gambar, diagram, dan konten serta memahami pewarisan placeholder dengan Aspose.Slides untuk Android melalui Java."
---
## **Gambaran Umum**

Placeholder adalah sebuah bentuk (shape) yang memesan posisi untuk jenis konten tertentu dalam template presentasi. Contoh umum meliputi placeholder judul, isi, gambar, diagram, dan placeholder konten serbaguna. Tidak seperti bentuk biasa, placeholder dapat mewarisi posisi, ukuran, pemformatan, dan pengaturan lain dari slide tata letak atau slide master.

Aspose.Slides mengekspor informasi placeholder melalui metode [IShape.getPlaceholder](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/) . Metode ini mengembalikan objek [IPlaceholder](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/placeholder/) atau `null` untuk bentuk biasa. Gunakan [IPlaceholder.getType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/placeholder/) untuk menentukan apa yang dimaksudkan placeholder tersebut.

Antarmuka bentuk tetap penting setelah Anda mengetahui tipe placeholder:

- Placeholder teks, gambar, diagram, atau konten kosong biasanya direpresentasikan oleh sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/).
- Placeholder gambar yang telah terisi dapat direpresentasikan oleh sebuah [IPictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipictureframe/).
- Placeholder diagram yang telah terisi dapat direpresentasikan oleh sebuah [IChart](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichart/).
- Placeholder konten dapat berisi beberapa jenis konten. Periksa baik [IPlaceholder.getType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/placeholder/) maupun antarmuka bentuk runtime alih‑alih mengasumsikan setiap placeholder adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Peringatan" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/placeholder/) menjelaskan peran placeholder; ia tidak menjamin tipe runtime bentuk. Selalu lakukan pemeriksaan tipe sebelum mengakses anggota teks, gambar, diagram, tabel, atau media‑spesifik.
{{% /alert %}}

## **Memahami Pewarisan Placeholder**

Placeholder membentuk hierarki:

1. Slide master mendefinisikan gaya yang dapat digunakan kembali dan, dalam beberapa kasus, placeholder pada tingkat master.
2. Slide tata letak menentukan susunan yang digunakan oleh satu atau lebih slide normal dan dapat mewarisi dari master.
3. Slide normal berisi placeholder untuk slide tersebut dan dapat mewarisi dari tata letaknya.

Panggil [IShape.getBasePlaceholder](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/) untuk naik satu tingkat dalam hierarki ini. Placeholder slide biasanya mengembalikan placeholder tata letaknya; placeholder tata letak dapat mengembalikan placeholder masternya. Metode ini mengembalikan `null` ketika bentuk tidak memiliki placeholder dasar.

Contoh berikut mencantumkan placeholder pada slide pertama dan melaporkan placeholder dasarnya:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Mengedit placeholder pada slide normal membuat atau mengubah penimpaan lokal untuk slide tersebut. Mengedit tata letak atau master yang terkait dapat memengaruhi semua slide yang masih mewarisi pengaturan itu. Sebuah bentuk biasa lokal tidak memiliki placeholder dasar dan tidak mulai mewarisi hanya karena berada pada koordinat yang sama.

## **Mengubah Teks dalam Placeholder**

Placeholder judul, judul‑tengah, subjudul, isi, dan teks biasanya mendukung teks. Periksa apakah bentuk adalah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) sebelum menggunakan metode [getTextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/)‑nya.

Contoh ini memperbarui placeholder judul pertama pada slide pertama dan menyimpan hasilnya:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pola ini menghindari casting placeholder gambar, diagram, tabel, atau media menjadi [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/). Ia juga mengidentifikasi placeholder berdasarkan tujuan alih‑alih mengandalkan indeks bentuk yang rapuh.

## **Mengatur Teks Prompt pada Tata Letak**

Teks prompt adalah instruksi waktu‑desain yang ditampilkan dalam placeholder kosong, seperti *Klik untuk menambahkan judul*. Atur teks prompt khusus pada placeholder tata letak daripada mencoba mencapainya melalui koleksi bentuk slide normal. Akses tata letak melalui [ISlide.getLayoutSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islide/) dan iterasi koleksi yang dikembalikan oleh [ILayoutSlide.getShapes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseslide/).

Contoh berikut mengubah prompt judul dan subjudul pada tata letak yang digunakan oleh slide pertama:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Teks prompt bukan konten slide normal. Ia dimaksudkan untuk placeholder kosong dalam aplikasi pengeditan seperti PowerPoint. Setelah pengguna atau program menyediakan konten nyata, prompt tidak lagi ditampilkan. Mengubah prompt juga tidak menggantikan teks yang sudah ada pada slide yang menggunakan tata letak tersebut.

## **Memperbarui Placeholder Gambar**

Ada dua kasus yang perlu ditangani:

- Jika placeholder gambar sudah terisi dan direpresentasikan oleh sebuah [IPictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipictureframe/), ganti gambar melalui [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipicturefillformat/) dan [ISlidesPicture.setImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidespicture/).
- Jika masih merupakan placeholder kosong, tambahkan sebuah picture frame pada koordinat placeholder menggunakan [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/) dan hapus placeholder kosong tersebut.

Contoh berikut mendukung kedua kasus dan menyimpan presentasi:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pengganti yang dibuat untuk placeholder kosong adalah picture frame lokal, bukan placeholder baru, karena [IShape.getPlaceholder](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/) tidak menyediakan setter. Ia mempertahankan posisi yang dipesan namun tidak lagi mewarisi perilaku khusus placeholder. Jika mempertahankan hubungan placeholder sangat penting, siapkan dan isi placeholder di PowerPoint terlebih dahulu, lalu perbarui [IPictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipictureframe/) yang dihasilkan dengan Aspose.Slides.

Untuk transparansi gambar, pemotongan, dan efek gambar lainnya, lihat [Manage Picture Frames](/slides/id/androidjava/picture-frame/). Operasi tersebut termasuk dalam picture frame atau picture fill, bukan dalam metadata placeholder.

## **Bekerja dengan Placeholder Diagram dan Konten**

Placeholder diagram yang telah terisi dapat direpresentasikan oleh sebuah [IChart](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichart/). Contoh ini menemukan diagram tersebut berdasarkan tipe placeholder dan antarmuka runtime, mengubah judulnya, dan menyimpan file:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Placeholder konten umum biasanya memiliki [PlaceholderType.Object](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/placeholdertype/). Di PowerPoint ia berfungsi sebagai peluncur untuk berbagai tipe konten, termasuk diagram, tabel, diagram alur, gambar, dan media. Setelah terisi, periksa antarmuka bentuk aktual untuk mengetahui apa yang dikandungnya. Tata letak khusus juga dapat mengekspos [PlaceholderType.Chart](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/placeholdertype/), atau [PlaceholderType.Diagram](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/placeholdertype/).

Aspose.Slides tidak mengonversi placeholder [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) kosong menjadi [IChart](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichart/) hanya dengan mengubah [IPlaceholder.getType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/placeholder/); tipe tidak dapat diubah melalui antarmuka. Untuk mengisi area diagram atau konten kosong secara programatis, tambahkan objek yang dibutuhkan pada koordinat placeholder dan kemudian hapus placeholder kosong. Contoh berikut melakukannya untuk sebuah diagram:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Diagram yang ditambahkan adalah diagram lokal biasa. Ia menempati area placeholder tetapi tidak mewarisi dari placeholder tata letak. Gunakan artikel khusus manajemen diagram [/slides/id/androidjava/powerpoint-charts/] ketika Anda perlu mengganti kategori, seri, atau data workbook‑nya.

## **Contoh Lengkap: Memperbarui Teks atau Konten Gambar**

Contoh end‑to‑end berikut membuka sebuah templat, mencari slide pertama untuk placeholder judul atau gambar, memeriksa tipe placeholder dan bentuk, memperbarui konten yang sesuai, dan menyimpan output. Contoh ini sengaja menghindari asumsi indeks bentuk atau casting setiap placeholder ke antarmuka yang sama.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apa itu placeholder dasar?**

Placeholder dasar adalah bentuk yang bersesuaian pada tata letak atau master dari mana placeholder lain mewarisi. Gunakan [IShape.getBasePlaceholder](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/) untuk mengambilnya. Sebuah bentuk lokal biasa mengembalikan `null` karena tidak termasuk dalam hierarki placeholder.

**Apakah saya dapat mengubah semua judul slide dengan mengedit placeholder tata letak?**

Anda dapat mengubah pemformatan atau teks prompt yang diwariskan melalui tata letak, tetapi konten judul yang ada disimpan pada slide normal. Untuk mengganti teks judul aktual di seluruh presentasi, iterasi slide‑slide dan perbarui setiap placeholder judul.

**Bagaimana cara mengelola placeholder tanggal, nomor‑slide, header, dan footer?**

Gunakan manajer header dan footer pada skop slide, tata letak, master, catatan, atau handout yang tepat. Lihat [Manage Presentation Header and Footer](/slides/id/androidjava/presentation-header-and-footer/) untuk contoh lengkap.