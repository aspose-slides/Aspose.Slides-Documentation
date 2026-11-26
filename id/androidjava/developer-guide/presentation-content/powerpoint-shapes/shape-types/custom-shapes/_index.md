---
title: Sesuaikan Bentuk Presentasi di Android
linktitle: Bentuk Kustom
type: docs
weight: 20
url: /id/androidjava/custom-shape/
keywords:
- bentuk kustom
- tambah bentuk
- buat bentuk
- ubah bentuk
- geometri bentuk
- jalur geometri
- titik jalur
- titik edit
- tambah titik
- hapus titik
- operasi penyuntingan
- sudut melengkung
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Buat dan sesuaikan bentuk dalam presentasi PowerPoint dengan Aspose.Slides untuk Android melalui Java: jalur geometri, sudut melengkung, bentuk komposit."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menyesuaikan bentuk presentasi di Aspose.Slides dengan mengedit geometri bentuk melalui titik edit dan jalur geometri. Artikel ini menunjukkan cara bekerja dengan [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) dan [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) untuk memodifikasi bentuk yang ada, melakukan operasi penyuntingan jalur dasar, menambah atau menghapus titik, dan menerapkan geometri yang diperbarui kembali ke sebuah bentuk.

Artikel ini juga mendemonstrasikan cara membuat bentuk kustom dan komposit, membangun bentuk dengan sudut melengkung, menentukan apakah geometri bentuk ditutup, dan memeriksa elemen bentuk menggunakan array titik Android.

## **Ubah Bentuk Menggunakan Titik Edit**

Di PowerPoint, Anda dapat menggunakan **Edit Points** untuk memodifikasi sebuah persegi:

* Memindahkan sudut ke dalam atau ke luar.
* Menyesuaikan kelengkungan pada sebuah titik.
* Menambah titik baru.

Mengedit titik memungkinkan Anda mengubah kontur sebuah bentuk atau menggunakan bentuk yang ada sebagai dasar untuk bentuk baru.

## **Tips Penyuntingan Bentuk**

![overview_image](custom_shape_0.png)

Saat menyunting bentuk PowerPoint, ingat konsep berikut:

* Sebuah bentuk (atau jalurnya) dapat berupa tertutup atau terbuka.
* Jalur sebuah bentuk terdiri dari titik jangkar yang dihubungkan oleh segmen.
* Sebuah segmen dapat lurus atau melengkung. Titik jangkar dan pegangan kontrol menentukan bentuknya.
* Titik jangkar ada sebagai titik sudut, titik lurus, atau titik halus:
  * Pada titik sudut, segmen yang berdekatan dapat bertemu pada sudut.
  * Pada titik halus, dua pegangan kontrol berada dalam satu garis dan berjarak sama dari titik jangkar.
  * Pada titik lurus, dua pegangan kontrol berada dalam satu garis tetapi dapat memiliki jarak yang berbeda dari titik jangkar.
* Memindahkan titik jangkar atau menyesuaikan pegangan kontrolnya mengubah kontur bentuk.

Untuk menyunting bentuk PowerPoint melalui titik edit, **Aspose.Slides** menyediakan kelas [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) dan antarmuka [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).

* Sebuah contoh [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) mewakili jalur geometri dari objek [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/).
* Untuk mengambil [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) dari instance [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/), Anda dapat menggunakan metode [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) .
* Untuk menetapkan [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) pada sebuah bentuk, Anda dapat menggunakan metode berikut: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) untuk bentuk dengan satu jalur dan [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) untuk bentuk dengan banyak jalur.
* Untuk menambahkan segmen, Anda dapat menggunakan metode di bawah [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).
* Dengan menggunakan metode [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) dan [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-), Anda dapat mengatur penampilan jalur geometri.
* Dengan menggunakan metode [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) , Anda dapat mengambil jalur geometri dari sebuah [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) sebagai array segmen jalur.

## **Operasi Penyuntingan Sederhana**

Gunakan metode berikut untuk menyunting jalur geometri. Overload yang menerima indeks menyisipkan segmen pada posisi berbasis nol dalam array segmen jalur.

| Operasi | Metode |
| --- | --- |
| Menambahkan atau menyisipkan garis lurus. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Menambahkan atau menyisipkan kurva Bézier kubik dengan dua titik kontrol dan titik akhir. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Menambahkan atau menyisipkan kurva Bézier kuadratik dengan satu titik kontrol dan titik akhir. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Menambahkan busur elips dengan dimensi dan sudut yang ditentukan dalam derajat. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Menutup gambar saat ini dengan menghubungkan titik akhir ke titik awal. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| Menetapkan titik awal sebuah gambar. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Menghapus sebuah segmen pada indeks berbasis nol. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Tambahkan Titik Kustom ke Bentuk**

Contoh ini menyisipkan dua titik ke dalam bentuk persegi panjang menggunakan [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) dan menerapkan jalur yang telah disunting dengan [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). Koordinat bersifat lokal terhadap bentuk: kedua titik baru berada di pusatnya, 100 poin dari kiri dan 50 poin dari atas. Indeks segmen 1 dan 4 menempatkannya pada tepi atas dan bawah, menarik tepi tersebut ke dalam.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    IGeometryPath geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Hapus Titik dari Bentuk**

Contoh ini mengubah kontur bentuk hati dengan menghapus segmen pada indeks berbasis nol 2 menggunakan [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-). Menerapkan jalur yang dimodifikasi dengan [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) memperbarui kontur bentuk.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Buat Bentuk Kustom**

Contoh ini membangun bintang lima sudut dengan [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/). Jari-jari luar dan dalam yang bergantian sebesar 100 dan 50 poin menentukan puncak dan cekungan; langkah 72 derajat menempatkan lima puncak secara merata. Jalur ditutup dengan [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) dan diterapkan ke bentuk persegi panjang menggunakan [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), menggantikan konturnya.

```java
import com.aspose.slides.*;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.List;

List<PointF> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    PointF point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Buat Bentuk Kustom Komposit**

Contoh ini mendefinisikan dua [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) tertutup untuk sepertiga atas dan bawah sebuah bentuk. Menerapkan kedua jalur dengan [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) menghasilkan satu bentuk komposit dengan celah di sepertiga tengahnya.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath topPath = new GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), shape.getHeight() / 3);
    topPath.lineTo(0, shape.getHeight() / 3);
    topPath.closeFigure();

    GeometryPath bottomPath = new GeometryPath();
    bottomPath.moveTo(0, shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { topPath, bottomPath });
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Buat Bentuk Kustom dengan Sudut Melengkung**

Contoh ini menggabungkan segmen lurus dengan [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) untuk membuat bentuk dengan sudut yang melengkung ke dalam. Setiap ukuran sudut menentukan lebar dan tinggi busur dalam poin, dan ayunan -90 derajat menggambar seperempat elips berlawanan arah jarum jam. Jalur yang selesai diterapkan dengan [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), dan presentasi disimpan dalam format PPTX.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    PointF topLeft = new PointF(leftTopSize, 0);
    PointF topRight = new PointF(shapeWidth - rightTopSize, 0);
    PointF rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    PointF bottomLeft = new PointF(leftBottomSize, shapeHeight);
    PointF leftTop = new PointF(0, leftTopSize);

    GeometryPath geometryPath = new GeometryPath();
    geometryPath.moveTo(topLeft);
    geometryPath.lineTo(topRight);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(rightBottom);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(bottomLeft);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(leftTop);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Temukan Apakah Geometri Bentuk Ditutup**

Helper berikut memeriksa apakah setiap jalur geometri yang tidak kosong berakhir dengan segmen penutup. Ia membaca [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) dan membandingkan perintah segmen terakhir [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) dengan [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/). Ia mengembalikan false bila tidak ada jalur yang tidak kosong. Pemeriksaan ini melihat perintah akhir setiap jalur; ia tidak memeriksa setiap subgambar di dalam jalur. Contoh mencetak `true` untuk sebuah persegi panjang.

```java
import com.aspose.slides.*;

class GeometryInspector {
    boolean isGeometryClosed(IGeometryShape geometryShape) {
        boolean hasNonemptyPath = false;

        for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
            IPathSegment[] segments = geometryPath.getPathData();
            if (segments.length == 0) {
                continue;
            }

            hasNonemptyPath = true;
            IPathSegment lastSegment = segments[segments.length - 1];
            if (lastSegment.getPathCommand() != PathCommandType.Close) {
                return false;
            }
        }

        return hasNonemptyPath;
    }
}

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryInspector inspector = new GeometryInspector();
    boolean closed = inspector.isGeometryClosed(shape);
    System.out.println(closed);
} finally {
    presentation.dispose();
}
```

## **Periksa Perintah Jalur Geometri**

Unduh [contour.pptx](contour.pptx) dan ganti nama file contoh dengan jalurnya di perangkat. Bentuk pertama pada slide pertama memiliki tepi atas lurus, kurva Bézier kubik, dan tepi penutup lurus. Gunakan [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) untuk membaca jalur bentuk dan [getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) untuk membaca setiap segmen jalur dalam urutan gambar. Untuk setiap segmen, [getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) mengidentifikasi perintah dan menentukan cara menafsirkan nilai yang dikembalikan oleh [getSegmentData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getSegmentData--).

```java
import com.aspose.slides.*;
import java.util.Arrays;

Presentation presentation = new Presentation("contour.pptx");
try {
    IGeometryShape shape = (IGeometryShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IGeometryPath[] paths = shape.getGeometryPaths();

    for (int i = 0; i < paths.length; i++) {
        IPathSegment[] segments = paths[i].getPathData();
        for (int j = 0; j < segments.length; j++) {
            byte command = segments[j].getPathCommand();
            float[] data = segments[j].getSegmentData();
            String detail;
            switch (command) {
                case PathCommandType.MoveTo:
                case PathCommandType.LineTo:
                    detail = String.format("destination=(%s, %s)", data[0], data[1]);
                    break;
                case PathCommandType.CubicBezierTo:
                    detail = String.format("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", data[0], data[1], data[2], data[3], data[4], data[5]);
                    break;
                case PathCommandType.Close:
                    detail = "no coordinates";
                    break;
                default:
                    detail = "raw=" + Arrays.toString(data);
            }
            String name = PathCommandType.getName(PathCommandType.class, command);
            System.out.printf("Path %d, segment %d: %s %s%n", i, j, name, detail);
        }
    }
} finally {
    presentation.dispose();
}
```

Bentuk berada pada koordinat (200, 100) poin pada slide. Koordinat yang dilaporkan bersifat lokal terhadap bentuk, dengan (0, 0) di sudut kiri atasnya, x meningkat ke kanan, dan y meningkat ke bawah. Segmen penutup kembali ke titik awal tanpa koordinat tambahan.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Ekstrak dan Periksa Elemen Bentuk**

Gunakan [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) untuk memeriksa bentuk yang ada sebagai elemen yang berisi titik jalur dan tipe titik. Cast setiap [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) yang dikembalikan ke [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) untuk mengambil array titik dan tipe melalui metode [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) dan [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) . Representasi ini berguna untuk analisis kontur atau mengirim geometri ke alat gambar kustom.

Contoh membuka input.pptx, menemukan bentuk geometri pertama langsung pada slide pertama, dan mencetak segmen jalurnya. Gunakan presentasi yang berisi bentuk dengan segmen lurus dan melengkung untuk melihat kedua jenis output. Ia tidak mencari di dalam grup.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IGeometryShape shape = null;
    for (IShape candidate : slide.getShapes()) {
        if (candidate instanceof IGeometryShape) {
            shape = (IGeometryShape) candidate;
            break;
        }
    }

    if (shape == null) {
        System.out.println("No geometry shape found on the first slide.");
    } else {
        for (IShapeElement element : shape.createShapeElements()) {
            ShapeElement shapeElement = (ShapeElement) element;
            PointF[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Pertahankan tipe segmen, kecuali bendera.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Konsumsi kedua titik kontrol dan titik akhir.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    System.out.println("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Array tersebut berkorespondensi berdasarkan indeks: `points[i]` adalah sebuah titik dan `types[i]` menjelaskan perannya. Tipe `0` memulai sebuah gambar, dan tipe `1` menggambar garis dari titik sebelumnya ke titik saat ini. Segmen Bézier kubik dimulai dari titik akhir sebelumnya dan menggunakan tiga entri tipe-`3` berurutan: dua titik kontrol diikuti oleh titik akhir baru. Loop mengonsumsi ketiga entri tersebut sekaligus dan memeriksa titik akhir untuk penutupan.

Tipe titik juga mengandung bendera. Mask dengan `0x07` untuk mengidentifikasi tipe segmen, dan uji `0x80` secara terpisah untuk mendeteksi subjalur tertutup. Misalnya, `129` (`0x81`) berarti titik akhir garis yang menutup subjalur, dan `131` (`0x83`) berarti titik akhir Bézier yang menutup satu. Java menyimpan bendera ini dalam byte bertanda; masking mempertahankan nilai bit yang dimaksud. Membandingkan nilai mentah hanya dengan `1` atau `3` akan melewatkan kasus ini. Bendera lain, seperti dash (`0x10`) dan marker (`0x20`), tidak mengubah tipe segmen dasar.

**Koordinat dan transformasi.** Titik diukur dalam poin (1/72 inci), dengan X meningkat ke kanan dan Y meningkat ke bawah. Untuk bentuk yang tidak dikelompokkan, koordinat yang diekstrak sudah mencakup posisi yang dikembalikan oleh [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) dan [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) serta mencerminkan lebar dan tinggi saat ini. Misalnya, sebuah persegi panjang yang tidak diputar pada `(100, 200)` dengan ukuran `120 × 80` memiliki batas kontur `(100, 200)`‑`(220, 280)`. Jangan menambahkan posisi bentuk lagi. Kurangi X dan Y untuk memperoleh koordinat relatif terhadap bingkai tidak diputar.

Poin yang diekstrak tidak menerapkan rotasi bentuk, yang dikembalikan oleh [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--), atau pembalikan horizontal dan vertikal. Untuk mereproduksi kontur yang ditampilkan, terapkan transformasi tersebut di sekitar pusat bentuk. Untuk bentuk yang dikelompokkan, juga perhitungkan pemetaan koordinat grup dan transformasinya; jangan menganggap bahwa poin yang diekstrak adalah koordinat slide akhir yang dirender atau menerapkan translasi atau skala dua kali bila sudah tercermin dalam bingkai anak.

**Pemeriksaan vs penyuntingan.** Array yang diekstrak menggambarkan kontur; mengubahnya tidak memperbarui bentuk asli. Pilih pendekatan ini ketika analisis atau kode gambar Anda memerlukan array titik/tipe. Gunakan [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) ketika Anda memerlukan perintah geometri dalam sistem koordinat lokal bentuk atau ingin menyunting geometri tersebut. Terapkan jalur yang disunting melalui [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) atau [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **FAQ**

**Apa yang terjadi pada isi dan kontur setelah mengganti geometri?**

Gaya tetap melekat pada bentuk; hanya kontur yang berubah. Isi dan kontur secara otomatis diterapkan ke geometri baru.

**Bagaimana cara memutar bentuk kustom bersama geometri secara benar?**

Gunakan metode [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) pada bentuk; geometri berputar bersama bentuk karena terikat pada sistem koordinat bentuk itu sendiri.

**Bisakah saya mengonversi bentuk kustom menjadi gambar untuk "mengunci" hasilnya?**

Ya. Ekspor area [slide](/slides/id/androidjava/convert-powerpoint-to-png/) yang diperlukan atau [shape](/slides/id/androidjava/create-shape-thumbnails/) itu sendiri ke format raster; ini mempermudah pekerjaan selanjutnya dengan geometri yang kompleks.