---
title: Kelola Placeholder Presentasi di Java
linktitle: Kelola Placeholder
type: docs
weight: 10
url: /id/java/manage-placeholder/
keywords:
- tempat penampung
- placeholder teks
- placeholder gambar
- placeholder diagram
- placeholder konten
- teks prompt
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara memeriksa dan mengedit placeholder teks, gambar, diagram, dan konten serta memahami pewarisan placeholder dengan Aspose.Slides untuk Java."
---
## **Gambaran Umum**

Placeholder adalah bentuk yang memesan posisi untuk jenis konten tertentu dalam templat presentasi. Contoh umum meliputi placeholder judul, isi, gambar, diagram, dan placeholder konten serbaguna. Tidak seperti bentuk biasa, placeholder dapat mewarisi posisi, ukuran, pemformatan, dan pengaturan lainnya dari slide tata letak atau slide master.

Aspose.Slides mengekspose informasi placeholder melalui metode [IShape.getPlaceholder](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/) . Metode ini mengembalikan objek [IPlaceholder](https://reference.aspose.com/slides/id/java/com.aspose.slides/placeholder/) atau `null` untuk bentuk normal. Gunakan [IPlaceholder.getType](https://reference.aspose.com/slides/id/java/com.aspose.slides/placeholder/) untuk menentukan apa yang dimaksudkan untuk ditempatkan dalam placeholder.

Antarmuka bentuk tetap penting setelah Anda mengetahui tipe placeholder:

- Placeholder teks, gambar, diagram, atau konten yang kosong biasanya direpresentasikan oleh [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/).
- Placeholder gambar yang sudah terisi dapat direpresentasikan oleh [IPictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipictureframe/).
- Placeholder diagram yang sudah terisi dapat direpresentasikan oleh [IChart](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichart/).
- Placeholder konten dapat berisi beberapa jenis konten. Periksa baik [IPlaceholder.getType](https://reference.aspose.com/slides/id/java/com.aspose.slides/placeholder/) maupun antarmuka bentuk pada runtime alih-alih mengasumsikan bahwa setiap placeholder adalah [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/id/java/com.aspose.slides/placeholder/) menjelaskan peran placeholder; tidak menjamin tipe runtime bentuk. Selalu lakukan pemeriksaan tipe sebelum mengakses anggota khusus teks, gambar, diagram, tabel, atau media.
{{% /alert %}}

## **Memahami Pewarisan Placeholder**

Placeholder membentuk hierarki:

1. Slide master mendefinisikan gaya yang dapat digunakan kembali dan, dalam beberapa kasus, placeholder pada level master.
2. Slide tata letak mendefinisikan susunan yang digunakan oleh satu atau beberapa slide normal dan dapat mewarisi dari master.
3. Slide normal berisi placeholder untuk slide tersebut dan dapat mewarisi dari tata letaknya.

Panggil [IShape.getBasePlaceholder](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/) untuk naik satu tingkat dalam hierarki ini. Placeholder slide biasanya mengembalikan placeholder tata letaknya; placeholder tata letak dapat mengembalikan placeholder masternya. Metode ini mengembalikan `null` ketika bentuk tidak memiliki placeholder dasar.

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

Mengedit placeholder pada slide normal membuat atau mengubah penimpaan lokal untuk slide tersebut. Mengedit tata letak atau master terkait dapat memengaruhi semua slide yang masih mewarisi pengaturan itu. Bentuk lokal biasa tidak memiliki placeholder dasar dan tidak mulai mewarisi hanya karena menempati koordinat yang sama.

## **Mengubah Teks dalam Placeholder**

Placeholder judul, judul-berpusat, subjudul, isi, dan teks biasanya mendukung teks. Periksa keberadaan [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) sebelum menggunakan metodenya [getTextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) .

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

Pola ini menghindari casting placeholder gambar, diagram, tabel, atau media menjadi [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/). Ia juga mengidentifikasi placeholder berdasarkan tujuan alih-alih bergantung pada indeks bentuk yang rapuh.

## **Mengatur Teks Prompt pada Tata Letak**

Teks prompt adalah instruksi pada waktu desain yang ditampilkan dalam placeholder kosong, misalnya *Click to add title*. Atur teks prompt khusus pada placeholder tata letak daripada mencoba mengaksesnya melalui koleksi bentuk slide normal. Akses tata letak melalui [ISlide.getLayoutSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/islide/) dan iterasi koleksi yang dikembalikan oleh [ILayoutSlide.getShapes](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibaseslide/) .

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

Teks prompt bukan konten slide normal. Ia ditujukan untuk placeholder kosong di aplikasi penyunting seperti PowerPoint. Setelah pengguna atau program menyediakan konten nyata, prompt tidak lagi ditampilkan. Mengubah prompt juga tidak menggantikan teks yang sudah ada pada slide yang menggunakan tata letak tersebut.

## **Memperbarui Placeholder Gambar**

Ada dua kasus yang harus ditangani:

- Jika placeholder gambar sudah terisi dan direpresentasikan oleh [IPictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipictureframe/), gantilah gambar melalui [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/) dan [ISlidesPicture.setImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/islidespicture/) .
- Jika masih berupa placeholder kosong, tambahkan frame gambar pada koordinat placeholder dengan [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/) dan hapus placeholder kosong tersebut.

Contoh berikut mendukung kedua kasus dan menyimpan presentasi:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

    Path imagePath = Paths.get("replacement.png");
    byte[] imageBytes = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageBytes);

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

Penggantian yang dibuat untuk placeholder kosong adalah frame gambar lokal, bukan placeholder baru, karena [IShape.getPlaceholder](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/) tidak menyediakan setter. Ia mempertahankan posisi yang dipesan tetapi tidak lagi mewarisi perilaku khusus placeholder. Jika mempertahankan hubungan placeholder penting, persiapkan dan isi placeholder di PowerPoint terlebih dahulu, kemudian perbarui [IPictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipictureframe/) yang dihasilkan dengan Aspose.Slides.

Untuk transparansi gambar, pemotongan, dan efek khusus gambar lainnya, lihat [Manage Picture Frames](/slides/id/java/picture-frame/). Operasi tersebut merupakan bagian dari frame gambar atau isian gambar, bukan metadata placeholder.

## **Bekerja dengan Placeholder Diagram dan Konten**

Placeholder diagram yang sudah terisi dapat direpresentasikan oleh [IChart](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichart/). Contoh ini menemukan diagram tersebut dengan menggunakan tipe placeholder dan antarmuka runtime, mengubah judulnya, dan menyimpan file:

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

Placeholder konten umum biasanya memiliki [PlaceholderType.Object](https://reference.aspose.com/slides/id/java/com.aspose.slides/placeholdertype/). Di PowerPoint ia berfungsi sebagai peluncur untuk beberapa tipe konten, termasuk diagram, tabel, diagram, gambar, dan media. Setelah terisi, periksa antarmuka bentuk sebenarnya untuk mengetahui apa yang terkandung di dalamnya. Tata letak khusus juga dapat mengekspos [PlaceholderType.Chart](https://reference.aspose.com/slides/id/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/id/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/id/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/id/java/com.aspose.slides/placeholdertype/), atau [PlaceholderType.Diagram](https://reference.aspose.com/slides/id/java/com.aspose.slides/placeholdertype/) .

Aspose.Slides tidak mengubah placeholder [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) yang kosong menjadi [IChart](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichart/) hanya dengan mengubah [IPlaceholder.getType](https://reference.aspose.com/slides/id/java/com.aspose.slides/placeholder/) ; tipe tidak dapat diubah melalui antarmuka. Untuk mengisi area diagram atau konten kosong secara programatis, tambahkan objek yang diperlukan pada koordinat placeholder dan kemudian hapus placeholder kosong. Contoh berikut melakukan hal itu untuk sebuah diagram:

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

Diagram yang ditambahkan adalah diagram lokal biasa. Ia menempati area placeholder tetapi tidak mewarisi dari placeholder tata letak. Gunakan artikel manajemen diagram khusus ([chart management articles](/slides/id/java/powerpoint-charts/)) ketika Anda perlu mengganti kategori, seri, atau data workbook‑nya.

## **Contoh Lengkap: Memperbarui Konten Teks atau Gambar**

Contoh end‑to‑end berikut membuka sebuah templat, mencari placeholder judul atau gambar pada slide pertama, memeriksa tipe placeholder dan bentuk, memperbarui konten yang sesuai, dan menyimpan output. Contoh ini sengaja menghindari asumsi indeks bentuk atau casting setiap placeholder ke antarmuka yang sama.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
            Path imagePath = Paths.get("replacement.png");
            byte[] imageBytes = Files.readAllBytes(imagePath);
            IPPImage image = presentation.getImages().addImage(imageBytes);

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

Placeholder dasar adalah bentuk yang bersangkutan pada tata letak atau master yang dari situ placeholder lain mewarisi. Gunakan [IShape.getBasePlaceholder](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/) untuk mengambilnya. Bentuk lokal biasa mengembalikan `null` karena tidak termasuk dalam hierarki placeholder.

**Apakah saya dapat mengubah semua judul slide dengan mengedit placeholder tata letak?**

Anda dapat mengubah pemformatan atau teks prompt yang diwarisi melalui tata letak, tetapi konten judul yang ada disimpan pada slide normal. Untuk mengganti teks judul sebenarnya di seluruh presentasi, iterasikan slide‑slide dan perbarui masing‑masing placeholder judul.

**Bagaimana cara mengelola placeholder tanggal, nomor slide, header, dan footer?**

Gunakan pengelola header dan footer pada slide, tata letak, master, catatan, atau ruang handout yang sesuai. Lihat [Manage Presentation Header and Footer](/slides/id/java/presentation-header-and-footer/) untuk contoh lengkap.