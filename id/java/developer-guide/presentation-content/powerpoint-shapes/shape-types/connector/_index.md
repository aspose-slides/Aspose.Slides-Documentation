---
title: Mengelola Penghubung dalam Presentasi Menggunakan Java
linktitle: Penghubung
type: docs
weight: 10
url: /id/java/connector/
keywords:
- penghubung
- jenis penghubung
- titik penghubung
- garis penghubung
- sudut penghubung
- menghubungkan bentuk
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Berdayakan aplikasi Java untuk menggambar, menghubungkan, dan mengatur otomatis jalur garis dalam slide PowerPoint—dapatkan kontrol penuh atas penghubung lurus, siku, dan melengkung."
---
## **Pendahuluan**

Penghubung PowerPoint adalah sebuah garis khusus yang menghubungkan atau menautkan dua bentuk bersama‑sama dan tetap menempel pada bentuk bahkan ketika mereka dipindahkan atau diposisikan ulang pada slide tertentu. 

Penghubung biasanya terhubung ke *titik sambungan* (titik hijau), yang ada pada semua bentuk secara default. Titik sambungan muncul ketika kursor mendekatinya.

*Titik penyesuaian* (titik oranye), yang hanya ada pada beberapa penghubung, digunakan untuk mengubah posisi dan bentuk penghubung.

## **Jenis Penghubung**

Di PowerPoint, Anda dapat menggunakan penghubung lurus, siku (berpola), dan melengkung. 

Aspose.Slides menyediakan penghubung‑penghubung ini:

| Connector                      | Image                                                        | Jumlah titik penyesuaian |
| ------------------------------ | ------------------------------------------------------------ | ------------------------ |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                        |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                        |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                        |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                        |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                        |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                        |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                        |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                        |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                        |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                        |

## **Hubungkan Bentuk Menggunakan Penghubung**

1. Buat sebuah instance dari kelas [Presentation](https://apireference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan dua [AutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/AutoShape) ke slide menggunakan metode `addAutoShape` yang tersedia pada objek `Shapes`.
4. Tambahkan sebuah penghubung menggunakan metode `addConnector` yang tersedia pada objek `Shapes` dengan menentukan tipe penghubung.
5. Hubungkan bentuk‑bentuk menggunakan penghubung.
6. Panggil metode `reroute` untuk menerapkan jalur koneksi terpendek.
7. Simpan presentasi. 

Kode Java ini menunjukkan cara menambahkan sebuah penghubung (penghubung bengkok) antara dua bentuk (sebuah elips dan persegi panjang):

```Java
// Membuat instance kelas presentasi yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mengakses koleksi bentuk untuk slide tertentu
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Menambahkan bentuk otomatis Elips
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Menambahkan bentuk otomatis Persegi Panjang
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Menambahkan bentuk penghubung ke koleksi bentuk slide
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Menghubungkan bentuk menggunakan penghubung
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Memanggil reroute yang mengatur jalur terpendek otomatis antara bentuk
    connector.reroute();
    
    // Menyimpan presentasi
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Metode `Connector.reroute` mengatur ulang sebuah penghubung dan memaksanya mengambil jalur terpendek yang mungkin antara bentuk‑bentuk. Untuk mencapai tujuan tersebut, metode ini dapat mengubah titik `setStartShapeConnectionSiteIndex` dan `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Tentukan Titik Sambungan**

Jika Anda ingin sebuah penghubung menautkan dua bentuk menggunakan titik tertentu pada bentuk‑bentuk tersebut, Anda harus menentukan titik sambungan pilihan Anda dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan dua [AutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/AutoShape) ke slide menggunakan metode `addAutoShape` yang tersedia pada objek `Shapes`.
4. Tambahkan sebuah penghubung menggunakan metode `addConnector` yang tersedia pada objek `Shapes` dengan menentukan tipe penghubung.
5. Hubungkan bentuk‑bentuk menggunakan penghubung.
6. Tentukan titik sambungan pilihan Anda pada bentuk‑bentuk.
7. Simpan presentasi.

Kode Java ini menunjukkan operasi di mana titik sambungan pilihan ditentukan:

```java
// Membuat instance kelas presentasi yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mengakses koleksi bentuk untuk slide tertentu
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Menambahkan bentuk otomatis Elips
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Menambahkan bentuk otomatis Persegi Panjang
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Menambahkan bentuk penghubung ke koleksi bentuk slide
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Menghubungkan bentuk menggunakan penghubung
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Menetapkan indeks titik sambungan pilihan pada bentuk Elips
    int wantedIndex = 6;

    // Memeriksa apakah indeks pilihan lebih kecil dari jumlah maksimum situs sambungan
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Menetapkan titik sambungan pilihan pada bentuk otomatis Elips
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Menyimpan presentasi
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sesuaikan Titik Penghubung**

Anda dapat menyesuaikan sebuah penghubung yang ada melalui titik penyesuaiannya. Hanya penghubung dengan titik penyesuaian yang dapat diubah dengan cara ini. Lihat tabel di bawah **[Jenis penghubung.](/slides/id/java/connector/#types-of-connectors)**

### **Kasus Sederhana**

Pertimbangkan sebuah kasus di mana sebuah penghubung antara dua bentuk (A dan B) melewati bentuk ketiga (C):

![connector-obstruction](connector-obstruction.png)

```java
Presentation pres = new Presentation();
try {

    ISlide sld = pres.getSlides().get_Item(0);
    IShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);

    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

Untuk menghindari atau melewati bentuk ketiga, kita dapat menyesuaikan penghubung dengan memindahkan garis vertikalnya ke kiri seperti ini:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Kasus Kompleks** 

Untuk melakukan penyesuaian yang lebih rumit, Anda harus mempertimbangkan hal‑hal berikut:

* Titik penyesuaian penghubung sangat terkait dengan formula yang menghitung dan menentukan posisinya. Jadi perubahan lokasi titik dapat mengubah bentuk penghubung.
* Titik penyesuaian penghubung didefinisikan dalam urutan yang ketat dalam sebuah array. Titik penyesuaian diberi nomor dari titik awal penghubung hingga akhir.
* Nilai titik penyesuaian mencerminkan persentase lebar/tinggi bentuk penghubung. 
  * Bentuk dibatasi oleh titik awal dan akhir penghubung yang dikalikan 1000. 
  * Titik pertama, kedua, dan ketiga masing‑masing menentukan persentase dari lebar, persentase dari tinggi, dan persentase dari lebar (lagi).
* Untuk perhitungan yang menentukan koordinat titik penyesuaian penghubung, Anda harus memperhitungkan rotasi penghubung dan pantulannya. **Catatan** bahwa sudut rotasi untuk semua penghubung yang ditampilkan di bawah **[Jenis penghubung](/slides/id/java/connector/#types-of-connectors)** adalah 0.

#### **Kasus 1**

Pertimbangkan sebuah kasus di mana dua objek bingkai teks ditautkan bersama melalui sebuah penghubung:

![connector-shape-complex](connector-shape-complex.png)

```java
// Membuat instance kelas presentasi yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mendapatkan slide pertama dalam presentasi
    ISlide sld = pres.getSlides().get_Item(0);
    // Menambahkan bentuk yang akan digabungkan melalui penghubung
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Menambahkan sebuah penghubung
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // Menentukan arah penghubung
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // Menentukan warna penghubung
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // Menentukan ketebalan garis penghubung
    connector.getLineFormat().setWidth(3);
    
    // Menautkan bentuk‑bentuk bersama dengan penghubung
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Mendapatkan titik penyesuaian untuk penghubung
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**Penyesuaian**

Kita dapat mengubah nilai titik penyesuaian penghubung dengan meningkatkan persentase lebar dan tinggi yang bersangkutan masing‑masing sebesar 20% dan 200%:

```java
// Mengubah nilai titik penyesuaian
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Hasilnya:

![connector-adjusted-1](connector-adjusted-1.png)

Untuk mendefinisikan sebuah model yang memungkinkan kami menentukan koordinat dan bentuk bagian‑bagian individual penghubung, mari buat sebuah bentuk yang sesuai dengan komponen horizontal penghubung pada titik connector.getAdjustments().get_Item(0):

```java
// Menggambar komponen vertikal penghubung
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Hasilnya:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Kasus 2**

Pada **Kasus 1**, kami menunjukkan operasi penyesuaian penghubung sederhana menggunakan prinsip dasar. Dalam situasi normal, Anda harus memperhitungkan rotasi penghubung dan tampilannya (yang diatur oleh connector.getRotation(), connector.getFrame().getFlipH(), dan connector.getFrame().getFlipV()). Sekarang kami akan memperlihatkan prosesnya.

Pertama, mari tambahkan sebuah objek bingkai teks baru (**To 1**) ke slide (untuk tujuan koneksi) dan buat sebuah penghubung (hijau) baru yang menghubungkannya dengan objek‑objek yang sudah kami buat.

```java
// Membuat objek binding baru
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Membuat penghubung baru
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// Menghubungkan objek menggunakan penghubung yang baru dibuat
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Mendapatkan titik penyesuaian penghubung
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Mengubah nilai titik penyesuaian
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Hasilnya:

![connector-adjusted-3](connector-adjusted-3.png)

Kedua, mari buat sebuah bentuk yang akan sesuai dengan komponen horizontal penghubung yang melewati titik penyesuaian penghubung baru connector.getAdjustments().get_Item(0). Kami akan menggunakan nilai dari data penghubung untuk connector.getRotation(), connector.getFrame().getFlipH(), dan connector.getFrame().getFlipV() serta menerapkan rumus konversi koordinat populer untuk rotasi mengelilingi titik x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Dalam kasus kami, sudut rotasi objek adalah 90 derajat dan penghubung ditampilkan secara vertikal, sehingga ini adalah kode yang sesuai:

```java
// Menyimpan koordinat penghubung
x = connector.getX();
y = connector.getY();
// Memperbaiki koordinat penghubung jika muncul
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// Mengambil nilai titik penyesuaian sebagai koordinat
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  Mengonversi koordinat karena Sin(90) = 1 dan Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// Menentukan lebar komponen horizontal menggunakan nilai titik penyesuaian kedua
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

Hasilnya:

![connector-adjusted-4](connector-adjusted-4.png)

Kami menunjukkan perhitungan yang melibatkan penyesuaian sederhana dan titik penyesuaian yang rumit (titik penyesuaian dengan sudut rotasi). Dengan pengetahuan yang diperoleh, Anda dapat mengembangkan model Anda sendiri (atau menulis kode) untuk mendapatkan objek `GraphicsPath` atau bahkan mengatur nilai titik penyesuaian penghubung berdasarkan koordinat slide tertentu.

## **Temukan Sudut Garis Penghubung**

1. Buat sebuah instance dari kelas.
2. Dapatkan referensi slide melalui indeksnya.
3. Akses bentuk garis penghubung.
4. Gunakan lebar garis, tinggi, tinggi bingkai bentuk, dan lebar bingkai bentuk untuk menghitung sudut.

Kode Java ini menunjukkan operasi di mana kami menghitung sudut untuk bentuk garis penghubung:

```java
Presentation pres = new Presentation("ConnectorLineAngle.pptx");
try {
    Slide slide = (Slide)pres.getSlides().get_Item(0);
    
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        double dir = 0.0;
        Shape shape = (Shape)slide.getShapes().get_Item(i);
        if (shape instanceof AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.getShapeType() == ShapeType.Line)
            {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                        ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        }
        else if (shape instanceof Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                    ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }

        System.out.println(dir);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public static double getDirection(float w, float h, boolean flipH, boolean flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **FAQ**

**Bagaimana saya dapat mengetahui apakah sebuah penghubung dapat 'menempel' pada bentuk tertentu?**

Periksa apakah bentuk tersebut menyediakan [situs sambungan](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#getConnectionSiteCount--). Jika tidak ada atau jumlahnya nol, penempelan tidak tersedia; dalam hal ini, gunakan titik akhir bebas dan posisikan secara manual. Sebaiknya periksa jumlah situs sebelum menempelkan.

**Apa yang terjadi pada sebuah penghubung jika saya menghapus salah satu bentuk yang terhubung?**

Ujung‑ujungnya akan terlepas; penghubung tetap berada di slide sebagai garis biasa dengan awal/akhir bebas. Anda dapat menghapusnya atau menetapkan kembali koneksi, dan jika diperlukan, [reroute](https://reference.aspose.com/slides/id/java/com.aspose.slides/connector/#reroute--).

**Apakah pengikatan penghubung dipertahankan saat menyalin slide ke presentasi lain?**

Umumnya ya, asalkan bentuk target juga disalin. Jika slide disisipkan ke file lain tanpa bentuk yang terhubung, ujung‑ujungnya menjadi bebas dan Anda perlu menempelkannya kembali.