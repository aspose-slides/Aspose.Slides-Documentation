---
title: Sesuaikan Bentuk Presentasi dengan JavaScript
linktitle: Bentuk Khusus
type: docs
weight: 20
url: /id/nodejs-java/custom-shape/
keywords:
- bentuk khusus
- tambahkan bentuk
- buat bentuk
- ubah bentuk
- geometri bentuk
- jalur geometri
- titik jalur
- titik edit
- tambahkan titik
- hapus titik
- operasi penyuntingan
- sudut melengkung
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat dan sesuaikan bentuk dalam presentasi PowerPoint dengan JavaScript dan Aspose.Slides untuk Node.js: jalur geometri, sudut melengkung, bentuk gabungan."
---
## **Ikhtisar**

Artikel ini menjelaskan cara menyesuaikan bentuk presentasi di Aspose.Slides dengan mengedit geometri bentuk melalui titik edit dan jalur geometri. Ini menunjukkan cara bekerja dengan [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) untuk memodifikasi bentuk yang ada, melakukan operasi penyuntingan jalur dasar, menambah atau menghapus titik, dan menerapkan geometri yang diperbarui kembali ke sebuah bentuk.

Ini juga menunjukkan cara membuat bentuk khusus dan gabungan, membangun bentuk dengan sudut melengkung, menentukan apakah geometri bentuk tertutup, memeriksa elemen bentuk, dan mengonversi kontur teks Java AWT menjadi jalur geometri.

## **Ubah Bentuk Menggunakan Titik Edit**

Di PowerPoint, Anda dapat menggunakan **Edit Points** untuk memodifikasi sebuah persegi:

* Pindahkan sebuah sudut ke dalam atau ke luar.
* Sesuaikan kelengkungan pada sebuah titik.
* Tambahkan titik baru.

Menyunting titik memungkinkan Anda mengubah kontur sebuah bentuk atau menggunakan bentuk yang ada sebagai dasar untuk bentuk baru.

## **Tips Penyuntingan Bentuk**

![overview_image](custom_shape_0.png)

Saat menyunting bentuk PowerPoint, ingat konsep-konsep berikut:

* Sebuah bentuk (atau jalurnya) dapat berupa tertutup atau terbuka.
* Jalur sebuah bentuk terdiri dari titik jangkar yang terhubung oleh segmen.
* Sebuah segmen dapat lurus atau melengkung. Titik jangkar dan pegangan kontrol menentukan bentuknya.
* Titik jangkar dapat berupa titik sudut, titik lurus, atau titik halus:
  * Pada titik sudut, segmen yang berdekatan dapat bertemu dengan sudut.
  * Pada titik halus, dua pegangan kontrol sejajar dan berjarak sama dari titik jangkar.
  * Pada titik lurus, dua pegangan kontrol sejajar tetapi dapat memiliki jarak yang berbeda dari titik jangkar.
* Memindahkan titik jangkar atau menyesuaikan pegangan mereka mengubah kontur bentuk.

Untuk menyunting bentuk PowerPoint melalui titik edit, **Aspose.Slides** menyediakan kelas [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

* Sebuah instance [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) mewakili jalur geometri dari objek [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/).
* Untuk mengambil [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) dari instance [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/), Anda dapat menggunakan metode [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths).
* Untuk mengatur [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) untuk sebuah bentuk, Anda dapat menggunakan metode ini: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) untuk bentuk dengan satu jalur dan [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) untuk bentuk dengan beberapa jalur.
* Untuk menambah segmen, Anda dapat menggunakan metode di bawah [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).
* Dengan menggunakan metode [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) dan [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode), Anda dapat mengatur tampilan untuk sebuah jalur geometri.
* Dengan menggunakan metode [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData), Anda dapat mengambil jalur geometri dari sebuah [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) sebagai array segmen jalur.
* Untuk mengakses opsi tambahan penyesuaian geometri bentuk, Anda dapat membaca sebuah [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) melalui [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) dan memutar kembali segmen pada sebuah [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

## **Operasi Penyuntingan Sederhana**

Gunakan metode berikut untuk menyunting jalur geometri. Overload yang menerima indeks menyisipkan segmen pada posisi berbasis nol dalam array segmen jalur.

| Operasi | Metode |
| --- | --- |
| Tambahkan atau sisipkan garis lurus. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| Tambahkan atau sisipkan kurva Bézier kubik dengan dua titik kontrol dan satu titik akhir. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Tambahkan atau sisipkan kurva Bézier kuadratik dengan satu titik kontrol dan satu titik akhir. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Tambahkan busur elips dengan dimensi dan sudut yang ditentukan dalam derajat. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| Tutup gambar saat ini dengan menghubungkan titik akhirnya ke titik awalnya. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| Atur titik mulai sebuah gambar. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| Hapus segmen pada indeks berbasis nol. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **Tambahkan Titik Khusus ke Bentuk**

Contoh ini menyisipkan dua titik ke dalam bentuk persegi panjang menggunakan [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) dan menerapkan jalur yang telah disunting dengan [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath). Koordinat bersifat lokal terhadap bentuk: kedua titik baru berada di tengahnya, 100 poin dari kiri dan 50 poin dari atas. Indeks segmen 1 dan 4 menempatkannya pada tepi atas dan bawah, menarik tepi tersebut ke dalam.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Hapus Titik dari Bentuk**

Contoh ini mengubah kontur berbentuk hati dengan menghapus segmen pada indeks berbasis nol 2 menggunakan [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt). Menerapkan jalur yang dimodifikasi dengan [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) memperbarui kontur bentuk.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Heart, 100, 100, 300, 300);

    const path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Buat Bentuk Khusus**

Contoh ini membangun bintang lima sudut dengan [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/). Radius luar dan dalam yang bergantian sebesar 100 dan 50 poin menentukan ujung dan lekukan; langkah 72 derajat menempatkan lima ujung secara merata. Jalur ditutup dengan [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) dan diterapkan pada bentuk persegi panjang menggunakan [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), menggantikan konturnya.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const points = [];
const outerRadius = 100;
const innerRadius = 50;
const angleStep = 72;

for (let angle = -90; angle < 270; angle += angleStep) {
    let radians = angle * Math.PI / 180;
    points.push({ x: outerRadius * Math.cos(radians) + outerRadius, y: outerRadius * Math.sin(radians) + outerRadius });
    radians = (angle + angleStep / 2) * Math.PI / 180;
    points.push({ x: innerRadius * Math.cos(radians) + outerRadius, y: innerRadius * Math.sin(radians) + outerRadius });
}

const starPath = new slides.GeometryPath();
starPath.moveTo(java.newFloat(points[0].x), java.newFloat(points[0].y));
for (let i = 1; i < points.length; i++) {
    starPath.lineTo(java.newFloat(points[i].x), java.newFloat(points[i].y));
}
starPath.closeFigure();

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Buat Bentuk Khusus Gabungan**

Contoh ini mendefinisikan dua objek [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) tertutup untuk sepertiga atas dan bawah sebuah bentuk. Menerapkan kedua jalur dengan [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) membuat satu bentuk gabungan dengan celah di sepertiga tengahnya.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const topPath = new slides.GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3));
    topPath.lineTo(0, java.newFloat(shape.getHeight() / 3));
    topPath.closeFigure();

    const bottomPath = new slides.GeometryPath();
    bottomPath.moveTo(0, java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    const paths = java.newArray("com.aspose.slides.GeometryPath", [topPath, bottomPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Buat Bentuk Khusus dengan Sudut Melengkung**

Contoh ini menggabungkan segmen lurus dengan [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) untuk membuat bentuk dengan sudut melengkung ke dalam. Setiap ukuran sudut mengatur lebar dan tinggi busur dalam poin, dan sapuan -90 derajat menggambar seperempat elips berlawanan arah jarum jam. Jalur yang selesai diterapkan dengan [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), dan presentasi disimpan dalam format PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const shapeX = 20;
const shapeY = 20;
const shapeWidth = 300;
const shapeHeight = 200;

const leftTopSize = 50;
const rightTopSize = 20;
const rightBottomSize = 40;
const leftBottomSize = 10;

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    const geometryPath = new slides.GeometryPath();
    geometryPath.moveTo(leftTopSize, 0);
    geometryPath.lineTo(shapeWidth - rightTopSize, 0);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(shapeWidth, shapeHeight - rightBottomSize);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(leftBottomSize, shapeHeight);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(0, leftTopSize);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Temukan Apakah Geometri Bentuk Tertutup**

Penolong berikut memeriksa apakah setiap jalur geometri yang tidak kosong berakhir dengan segmen penutup. Ia membaca [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) dan membandingkan perintah segmen terakhir [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) dengan [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/). Ia mengembalikan false bila tidak ada jalur yang tidak kosong. Pemeriksaan ini memeriksa perintah akhir setiap jalur; tidak memeriksa setiap subgambar dalam sebuah jalur. Contoh mencetak `true` untuk sebuah persegi panjang.

```javascript
const slides = require("aspose.slides.via.java");

function isGeometryClosed(geometryShape) {
    let hasNonemptyPath = false;
    for (const geometryPath of geometryShape.getGeometryPaths()) {
        const segments = geometryPath.getPathData();
        if (segments.length === 0) {
            continue;
        }
        hasNonemptyPath = true;
        const lastSegment = segments[segments.length - 1];
        if (lastSegment.getPathCommand() !== slides.PathCommandType.Close) {
            return false;
        }
    }
    return hasNonemptyPath;
}

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const closed = isGeometryClosed(shape);
    console.log(closed);
} finally {
    presentation.dispose();
}
```

## **Periksa Perintah Jalur Geometri**

Unduh [contour.pptx](contour.pptx) dan letakkan di direktori kerja aplikasi. Bentuk pertama pada slide pertama memiliki tepi atas lurus, sebuah kurva Bézier kubik, dan tepi penutup lurus. Gunakan [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) untuk membaca jalur bentuk dan [getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) untuk membaca setiap segmen jalur dalam urutan menggambar. Untuk setiap segmen, [getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) mengidentifikasi perintah dan menentukan cara menafsirkan nilai yang dikembalikan oleh [getSegmentData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getSegmentData).

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("contour.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paths = shape.getGeometryPaths();
    for (const [i, path] of paths.entries()) {
        const segments = path.getPathData();
        for (const [j, segment] of segments.entries()) {
            const command = segment.getPathCommand();
            const data = segment.getSegmentData();
            let detail;
            switch (command) {
                case slides.PathCommandType.MoveTo:
                case slides.PathCommandType.LineTo:
                    const name = command === slides.PathCommandType.MoveTo ? "MoveTo" : "LineTo";
                    detail = `${name} destination=(${data[0]}, ${data[1]})`;
                    break;
                case slides.PathCommandType.CubicBezierTo:
                    detail = `CubicBezierTo control1=(${data[0]}, ${data[1]}) control2=(${data[2]}, ${data[3]}) end=(${data[4]}, ${data[5]})`;
                    break;
                case slides.PathCommandType.Close:
                    detail = "Close no coordinates";
                    break;
                default:
                    detail = `command=${command} raw=[${data.join(", ")}]`;
            }
            console.log(`Path ${i}, segment ${j}: ${detail}`);
        }
    }
} finally {
    presentation.dispose();
}
```

Bentuk berada pada (200, 100) poin pada slide. Koordinat yang dilaporkan bersifat lokal terhadap bentuk, dengan (0, 0) di sudut kiri atasnya, x meningkat ke kanan, dan y meningkat ke bawah. Segmen penutup kembali ke titik awal tanpa koordinat tambahan.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```
![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Ekstrak dan Periksa Elemen Bentuk**

Gunakan [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) untuk memeriksa bentuk yang ada sebagai elemen yang berisi titik jalur dan tipe titik. Gunakan setiap [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) yang dikembalikan untuk mengambil array titik dan tipe melalui metode [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) dan [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes). Representasi ini berguna untuk analisis kontur atau menyampaikan geometri ke alat gambar khusus.

Contoh ini membuka input.pptx, menemukan bentuk geometri pertama langsung pada slide pertama, dan mencetak segmen jalurnya. Gunakan presentasi yang berisi bentuk dengan segmen lurus dan melengkung untuk melihat kedua jenis output. Tidak mencari di dalam grup.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let shape = null;
    for (let index = 0; index < slide.getShapes().size(); index++) {
        const candidate = slide.getShapes().get_Item(index);
        if (java.instanceOf(candidate, "com.aspose.slides.GeometryShape")) {
            shape = candidate;
            break;
        }
    }

    if (shape == null) {
        console.log("No geometry shape found on the first slide.");
    } else {
        for (const shapeElement of shape.createShapeElements()) {
            const points = shapeElement.getPathPoints();
            const types = shapeElement.getPathTypes();
            console.log("Shape element:");

            for (let i = 0; i < points.length; i++) {
                const pointType = types[i] & 0x07; // Simpan tipe segmen, kecuali flag.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Konsumsi kedua titik kontrol dan titik akhir.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    console.log("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Array berkorespondensi berdasarkan indeks: `points[i]` adalah sebuah titik dan `types[i]` menggambarkan perannya. Tipe `0` memulai sebuah gambar, dan tipe `1` menggambar garis dari titik sebelumnya ke titik saat ini. Segmen Bézier kubik dimulai pada titik akhir sebelumnya dan menggunakan tiga entri tipe-`3` berurutan: dua titik kontrol diikuti oleh titik akhir baru. Loop mengonsumsi ketiga entri ini bersama-sama dan memeriksa titik akhir untuk penutupan.

Tipe titik juga mengandung flag. Mask dengan `0x07` untuk mengidentifikasi tipe segmen, dan uji `0x80` secara terpisah untuk mendeteksi subpath tertutup. Misalnya, `129` (`0x81`) berarti titik akhir garis yang menutup subpath, dan `131` (`0x83`) berarti titik akhir Bézier yang menutup satu. Java menyimpan flag ini dalam byte bertanda; mask menjaga nilai bit yang dimaksud. Membandingkan nilai mentah hanya dengan `1` atau `3` akan melewatkan kasus ini. Flag lain, seperti dash (`0x10`) dan marker (`0x20`), tidak mengubah tipe segmen dasar.

**Koordinat dan transformasi.** Titik diukur dalam poin (1/72 inci), dengan X meningkat ke kanan dan Y meningkat ke bawah. Untuk bentuk yang tidak dikelompokkan, koordinat yang diekstrak sudah mencakup posisi yang dikembalikan oleh [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) dan [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) serta mencerminkan lebar dan tinggi saat ini. Misalnya, persegi panjang yang tidak diputar pada `(100, 200)` dengan ukuran `120 × 80` memiliki batas kontur `(100, 200)`–`(220, 280)`. Jangan menambahkan posisi bentuk lagi. Kurangi X dan Y‑nya untuk memperoleh koordinat relatif terhadap kerangka yang tidak diputar.

Titik yang diekstrak tidak menerapkan rotasi bentuk, yang dikembalikan oleh [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation), atau pembalikan horizontal dan vertikal. Untuk mereproduksi kontur yang ditampilkan, terapkan transformasi tersebut di sekitar pusat bentuk. Untuk bentuk yang dikelompokkan, perhitungkan juga pemetaan koordinat grup dan transformasinya; jangan mengasumsikan bahwa titik yang diekstrak adalah koordinat slide akhir yang dirender atau menerapkan translasi atau skala dua kali jika sudah tercermin dalam kerangka anak.

**Inspeksi versus penyuntingan.** Array yang diekstrak menggambarkan kontur; mengubahnya tidak memperbarui bentuk asli. Pilih pendekatan ini ketika analisis atau kode gambar Anda memerlukan array titik/tipe. Gunakan [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) ketika Anda memerlukan perintah geometri dalam sistem koordinat lokal bentuk atau ingin menyunting geometri tersebut. Terapkan jalur yang disunting melalui [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) atau [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Konversi Bentuk Java AWT ke GeometryPath**

Contoh ini menggabungkan kontur persegi panjang dengan teks yang dikonversi menjadi geometri. Metode [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) pada kontur menonaktifkan isian. Sebuah [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) membuat kontur teks dalam [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html)‑nya menyediakan segmen move, line, quadratic, cubic, dan closing, yang contoh ini memutar kembali pada sebuah [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

Jembatan Java menggunakan nilai float dan byte eksplisit untuk parameter Java yang bersesuaian. Iterator menulis koordinat ke dalam array float Java; refleksi membaca nilai yang diperbarui kembali ke JavaScript. Teks menggunakan font Arial 40 poin. Kontur dipindahkan 20 poin secara horizontal dan diposisikan dengan bagian atas visualnya 10 poin di bawah tepi atas bentuk. Jalur teks diisi, sementara persegi panjang asli tetap menjadi kontur. Menerapkan kedua jalur dengan [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) menghasilkan satu bentuk yang berisi persegi panjang dan teks.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 300, 100);
    
    const originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(java.newByte(slides.PathFillModeType.None));

    const font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    const image = java.newInstanceSync("java.awt.image.BufferedImage", 100, 100, java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
    const graphics = image.createGraphics();
    let graphicsPath;
    try {
        const fontContext = graphics.getFontRenderContext();
        const glyphVector = font.createGlyphVector(fontContext, "Text in shape");
        const textBounds = glyphVector.getVisualBounds();
        const baseline = java.newFloat(-textBounds.getY() + 10);
        graphicsPath = glyphVector.getOutline(java.newFloat(20), baseline);
    } finally {
        graphics.dispose();
    }

    const textPath = new slides.GeometryPath();
    const pathIterator = graphicsPath.getPathIterator(null);
    const coordinates = java.newArray("float", [0, 0, 0, 0, 0, 0]);

    while (!pathIterator.isDone()) {
        const segmentType = pathIterator.currentSegment(coordinates);
        const points = [];
        for (let i = 0; i < 6; i++) {
            const coordinate = java.callStaticMethodSync("java.lang.reflect.Array", "getFloat", coordinates, i);
            points.push(java.newFloat(coordinate));
        }
        switch (segmentType) {
            case 0: // Pindah ke.
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // Garis ke.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // Kurva Bézier kuadratik.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // Kurva Bézier kubik.
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // Tutup gambar.
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }
    textPath.setFillMode(java.newByte(slides.PathFillModeType.Normal));
    const paths = java.newArray("com.aspose.slides.GeometryPath", [originalPath, textPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Apa yang terjadi pada isian dan kontur setelah mengganti geometri?**

Gaya tetap pada bentuk; hanya kontur yang berubah. Isian dan kontur secara otomatis diterapkan pada geometri baru.

**Bagaimana cara memutar bentuk khusus bersama geometri secara benar?**

Gunakan metode [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) pada bentuk; geometri berputar bersama bentuk karena terikat pada sistem koordinat bentuk itu sendiri.

**Apakah saya dapat mengonversi bentuk khusus menjadi gambar untuk “mengunci” hasilnya?**

Ya. Ekspor area [slide](/slides/id/nodejs-java/convert-powerpoint-to-png/) yang diperlukan atau [bentuk](/slides/id/nodejs-java/create-shape-thumbnails/) itu sendiri ke format raster; ini menyederhanakan pekerjaan lebih lanjut dengan geometri kompleks.