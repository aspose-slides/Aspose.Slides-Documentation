---
title: Batasi Penyuntingan Presentasi dengan Kunci Bentuk di Android
linktitle: Batasi Penyuntingan Presentasi
type: docs
weight: 60
url: /id/androidjava/applying-protection-to-presentation/
keywords:
- mencegah penyuntingan
- melindungi dari penyuntingan
- kunci bentuk
- kunci posisi
- kunci pemilihan
- kunci pengubahan ukuran
- kunci pengelompokan
- PowerPoint
- PPTX
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara mengunci dan membuka kunci bentuk dalam presentasi PPTX dengan Aspose.Slides untuk Android via Java untuk membatasi pemilihan, pergerakan, pengubahan ukuran, dan pengelompokan."
---
## **Ikhtisar**

Penggunaan umum Aspose.Slides for Android via Java adalah untuk membuat, memperbarui, dan menyimpan presentasi PowerPoint (PPTX) sebagai bagian dari alur kerja otomatis. Ketika pengguna menerima presentasi ini, membatasi perubahan pada bentuk dapat membantu mempertahankan tata letak dan konten yang dimaksud.

Artikel ini menjelaskan bagaimana bentuk diatur pada slide dan cara menerapkan serta menghapus kunci bentuk dalam presentasi PPTX. Kunci ini memungkinkan Anda membatasi operasi penyuntingan tertentu pada bentuk individual.

## **Komposisi Slide**

Sebuah slide presentasi terdiri dari komponen seperti autoshape, tabel, objek OLE, bentuk yang dikelompokkan, bingkai gambar, bingkai video, penghubung, dan elemen lain yang digunakan untuk membangun sebuah presentasi. Di Aspose.Slides for Android via Java, setiap elemen pada slide direpresentasikan oleh objek yang mengimplementasikan antarmuka [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) atau mewarisi dari kelas yang melakukannya.

Berbagai tipe bentuk menyediakan opsi kunci yang berbeda. Antarmuka [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) adalah antarmuka dasar untuk kunci bentuk. Aspose.Slides for Android via Java menyediakan antarmuka kunci berikut:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) mengunci autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) mengunci bentuk penghubung.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) mengunci objek grafis.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) mengunci bentuk grup.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) mengunci bingkai gambar.  

Untuk menerapkan kunci pada seluruh [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), iterasi melalui slide-nya dan tetapkan kunci yang sesuai pada setiap bentuk yang didukung.

## **Terapkan dan Hapus Perlindungan**

Editor presentasi yang kompatibel menggunakan kunci bentuk untuk membatasi operasi penyuntingan individual. Enkripsi file dan perlindungan penulisan tingkat dokumen adalah [pengaturan perlindungan presentasi](/slides/id/androidjava/password-protected-presentation/) yang terpisah.

### **Terapkan Perlindungan pada Bentuk PPTX**

Aspose.Slides for Android via Java menyediakan antarmuka [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) untuk bekerja dengan bentuk pada slide.

Contoh memanggil [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), dan [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) dengan `true` untuk autoshape, dengan kunci setara untuk bentuk grup, penghubung, dan bingkai gambar. Penghubung menggunakan [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) untuk pergerakan; grup juga menggunakan [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) untuk membatasi pengelompokan.

Contoh memuat presentasi PPTX yang ada, memeriksa bentuk dalam koleksi bentuk setiap slide, dan menyimpan salinan dengan pembatasan ini diterapkan. Bentuk di luar empat tipe yang ditangani dibiarkan tidak berubah. Loop tidak menelusuri bentuk anak di dalam grup.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Hapus Perlindungan**

Untuk menghapus kunci bentuk, setel nilainya menjadi `false`. Contoh berikut memuat presentasi dengan kunci bentuk dan menghapus pembatasan pemilihan, pergerakan, dan perubahan ukuran melalui [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/), dan [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/). Itu juga menghapus pembatasan pengelompokan dengan memberikan `false` ke [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) dan menyimpan salinan presentasi. Pengaturan kunci lainnya dibiarkan tidak berubah.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Pertahankan Potongan Gambar**

Letakkan foto bernama `photo.jpg` di direktori kerja. Contoh memotong 12% dari kiri dan 8% dari kanan, kemudian memanggil [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) pada kunci bingkai gambar. Memberikan `true` membatasi pemotongan lebih lanjut dan mempertahankan potongan yang ada.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage photo;
    try (FileInputStream input = new FileInputStream("photo.jpg")) {
        photo = presentation.getImages().addImage(input);
    }

    IPictureFrame pictureFrame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);

    IPictureFrameLock pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` menyimpan kunci pemotongan sebagai `true`. Di PowerPoint, perintah **Crop** dinonaktifkan ketika foto dipilih.

### **Pertahankan Diagram Tetap Dikelompokkan**

Contoh mengelompokkan sebuah persegi panjang dan panah, kemudian memanggil [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) pada kunci grup untuk mempertahankan komponen diagram tetap bersama. Penyuntingan lain, seperti memindahkan grup atau mengubah isi sebuah komponen, tetap tersedia.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IGroupShape groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` menyimpan kunci pembongkaran sebagai `true`. Di PowerPoint, perintah **Ungroup** dinonaktifkan ketika seluruh diagram dipilih.

### **Laporkan Kunci Bentuk yang Ada**

Untuk meninjau sebuah templat, buka dan baca objek kunci untuk setiap bentuk. Metode [getNoLocks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/#getNoLocks--) mengembalikan `true` ketika semua flag pada objek tersebut dinonaktifkan dan `false` ketika setidaknya satu diaktifkan. Sebuah grup dan anak‑anaknya memiliki objek kunci terpisah, jadi periksa anak‑anaknya bahkan ketika grup tidak memiliki kunci.

Contoh ini memeriksa pergerakan untuk autoshape, bingkai gambar, dan grup. Ini juga memeriksa pemotongan untuk gambar dan pembongkaran untuk grup. Laporan mencantumkan flag yang diaktifkan yang dikenalnya dan menandai tipe bentuk yang tidak diperiksanya.

```java
import com.aspose.slides.*;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.List;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            List<String> flags = new ArrayList<>();
            IBaseShapeLock shapeLock;

            if (shape instanceof IGroupShape) {
                IGroupShapeLock groupLock = ((IGroupShape) shape).getGroupShapeLock();
                shapeLock = groupLock;
                if (groupLock.getUngroupingLocked()) flags.add("UngroupingLocked");
                if (groupLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IPictureFrame) {
                IPictureFrameLock pictureLock = ((IPictureFrame) shape).getPictureFrameLock();
                shapeLock = pictureLock;
                if (pictureLock.getCropLocked()) flags.add("CropLocked");
                if (pictureLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IAutoShape) {
                IAutoShapeLock autoShapeLock = ((IAutoShape) shape).getAutoShapeLock();
                shapeLock = autoShapeLock;
                if (autoShapeLock.getPositionLocked()) flags.add("PositionLocked");
            } else {
                System.out.println(label + " | Uninspected");
                continue;
            }

            if (!shapeLock.getNoLocks()) {
                String restrictions = !flags.isEmpty() ? TextUtils.join(", ", flags) : "Active flag not identified";
                System.out.println(label + " | " + restrictions);
            }

            if (shape instanceof IGroupShape) {
                inspect(((IGroupShape) shape).getShapes(), slideNumber, path + "/");
            }
        }
    }
}

ShapeLockReport report = new ShapeLockReport();
Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        report.inspect(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

Misalkan slide 1 dari `Sample.pptx` berisi grup bernama `Layout` dengan pembongkaran terkunci, gambar bernama `Photo` di dalamnya dengan pemotongan terkunci, dan persegi panjang yang tidak terkunci bernama `Free`. Laporan melewatkan `Free` dan mencetak dua baris berikut:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Laporan membaca flag penyuntingan tingkat bentuk yang disimpan tanpa mengubahnya atau menyimpan presentasi. Perlindungan penulisan tingkat dokumen adalah pengaturan terpisah, dan penegakan setiap flag bergantung pada editor.

### **Kesimpulan**

Aspose.Slides for Android via Java memungkinkan Anda membatasi operasi penyuntingan tertentu pada bentuk individual atau menerapkan pembatasan yang sama di seluruh slide. Pilih kunci yang didukung oleh setiap tipe bentuk, dan setel nilainya ke `false` ketika Anda perlu menghapus pembatasan tersebut.

## **FAQ**

**Bisakah saya menggabungkan kunci bentuk dan perlindungan password dalam presentasi yang sama?**

Ya. Kunci bentuk membatasi operasi penyuntingan tertentu, sementara [perlindungan password](/slides/id/androidjava/password-protected-presentation/) dapat membatasi pembukaan atau pengubahan presentasi. Anda dapat menggunakan keduanya dalam satu file.

**Apakah saya dapat membatasi penyuntingan pada slide tertentu tanpa memengaruhi yang lain?**

Ya. Terapkan kunci hanya pada bentuk di slide yang dipilih. Ini tidak mengubah pengaturan kunci pada slide lain.

**Bagaimana saya dapat menerapkan kunci pada bentuk individual di dalam grup?**

Iterasi melalui koleksi yang dikembalikan oleh metode [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) grup dan terapkan kunci yang sesuai pada setiap bentuk anak. Ulangi ini untuk setiap grup bersarang, mengikuti penelusuran dalam contoh pelaporan.