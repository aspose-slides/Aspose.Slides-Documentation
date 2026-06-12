---
title: Kelola Konektor dalam Presentasi di .NET
linktitle: Konektor
type: docs
weight: 10
url: /id/net/connector/
keywords:
- konektor
- jenis konektor
- titik konektor
- garis konektor
- sudut konektor
- hubungkan bentuk
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Memberdayakan aplikasi .NET untuk menggambar, menghubungkan, dan mengatur otomatis garis di slide PowerPoint—dapatkan kontrol penuh atas konektor lurus, siku, dan melengkung."
---
## **Pendahuluan**

Connector PowerPoint adalah garis khusus yang menghubungkan atau menautkan dua bentuk bersama dan tetap melekat pada bentuk meskipun bentuk tersebut dipindahkan atau diposisikan kembali pada slide tertentu.

Connector biasanya terhubung ke *titik koneksi* (titik hijau), yang secara default ada pada semua bentuk. Titik koneksi muncul ketika kursor mendekatinya.

*Titik penyesuaian* (titik oranye), yang hanya ada pada beberapa connector, digunakan untuk mengubah posisi dan bentuk connector.

## **Jenis Konektor**

Di PowerPoint, Anda dapat menggunakan connector lurus, siku (ber sudut), dan melengkung.

Aspose.Slides menyediakan connector berikut:

| Konektor | Gambar | Jumlah titik penyesuaian |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

## **Hubungkan Bentuk Menggunakan Konektor**

1. Buat instance kelas [Presentasi](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
1. Dapatkan referensi slide melalui indeksnya.
1. Tambahkan dua [AutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/autoshape/) ke slide menggunakan metode `AddAutoShape` yang disediakan oleh objek `Shapes`.
1. Tambahkan sebuah konektor menggunakan metode `AddConnector` yang disediakan oleh objek `Shapes` dengan mendefinisikan tipe konektor.
1. Hubungkan bentuk‑bentuk menggunakan konektor.
1. Panggil metode `Reroute` untuk menerapkan jalur koneksi terpendek.
1. Simpan presentasi.

Kode C# berikut menunjukkan cara menambahkan sebuah konektor (konektor bengkok) antara dua bentuk (sebuah elips dan persegi panjang):

```c#
// Membuat instance kelas presentasi yang mewakili file PPTX
using (Presentation input = new Presentation())
{                
    // Mengakses koleksi shape untuk slide tertentu
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Menambahkan autoshape Ellipse
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Menambahkan autoshape Rectangle
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Menambahkan shape konektor ke koleksi shape slide
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Menghubungkan shape menggunakan konektor
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Memanggil reroute yang menetapkan jalur terpendek otomatis antara shape
    connector.Reroute();

    // Menyimpan presentasi
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Metode `Connector.Reroute` mengarahkan ulang sebuah konektor dan memaksa ia mengambil jalur terpendek yang mungkin antara bentuk‑bentuk. Untuk mencapai tujuan tersebut, metode ini dapat mengubah titik `StartShapeConnectionSiteIndex` dan `EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Tentukan Titik Koneksi**
Jika Anda ingin sebuah konektor menautkan dua bentuk menggunakan titik‑titik spesifik pada bentuk, Anda harus menentukan titik koneksi pilihan Anda sebagai berikut:

1. Buat instance kelas [Presentasi](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
1. Dapatkan referensi slide melalui indeksnya.
1. Tambahkan dua [AutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/autoshape/) ke slide menggunakan metode `AddAutoShape` yang disediakan oleh objek `Shapes`.
1. Tambahkan sebuah konektor menggunakan metode `AddConnector` yang disediakan oleh objek `Shapes` dengan mendefinisikan tipe konektor.
1. Hubungkan bentuk‑bentuk menggunakan konektor.
1. Atur titik‑titik koneksi pilihan Anda pada bentuk.
1. Simpan presentasi.

Kode C# berikut mendemonstrasikan operasi di mana sebuah titik koneksi pilihan ditentukan:

```c#
// Membuat instance kelas presentasi yang mewakili file PPTX
using (Presentation presentation = new Presentation())
{
    // Mengakses koleksi shape untuk slide tertentu
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // Menambahkan shape konektor ke koleksi shape slide
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // Menambahkan autoshape Ellipse
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Menambahkan autoshape Rectangle
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // Menghubungkan shape menggunakan konektor
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Menetapkan indeks titik koneksi yang diinginkan pada shape Ellipse
    uint wantedIndex = 6;

    // Memeriksa apakah indeks yang diinginkan lebih kecil dari jumlah maksimum situs koneksi
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // Menetapkan titik koneksi yang diinginkan pada autoshape Ellipse
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // Menyimpan presentasi
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```

## **Sesuaikan Titik Konektor**

Anda dapat menyesuaikan sebuah konektor yang ada melalui titik penyesuaian nya. Hanya konektor dengan titik penyesuaian yang dapat diubah dengan cara ini. Lihat tabel di bawah **[Jenis Konektor](/slides/id/net/connector/#types-of-connectors)** 

### **Kasus Sederhana**

Pertimbangkan sebuah kasus di mana sebuah konektor antara dua bentuk (A dan B) melewati bentuk ketiga (C):

![connector-obstruction](connector-obstruction.png)

Kode:

```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```

Untuk menghindari atau melewati bentuk ketiga, kita dapat menyesuaikan konektor dengan memindahkan garis vertikalnya ke kiri seperti berikut:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **Kasus Kompleks** 

Untuk melakukan penyesuaian yang lebih rumit, Anda harus memperhatikan hal‑hal berikut:

* Titik yang dapat disesuaikan pada konektor sangat terkait dengan formula yang menghitung dan menentukan posisinya. Jadi perubahan lokasi titik dapat mengubah bentuk konektor.
* Titik penyesuaian konektor didefinisikan dalam urutan yang ketat dalam sebuah array. Titik‑titik tersebut diberi nomor dari titik awal konektor hingga titik akhirnya.
* Nilai titik penyesuaian mencerminkan persentase lebar/tinggi bentuk konektor. 
  * Bentuk dibatasi oleh titik awal dan akhir konektor yang dikalikan dengan 1000. 
  * Titik pertama, kedua, dan ketiga masing‑masing mendefinisikan persentase dari lebar, persentase dari tinggi, dan persentase dari lebar (lagi).
* Untuk perhitungan yang menentukan koordinat titik penyesuaian konektor, Anda harus memperhitungkan rotasi konektor dan refleksinya. **Catatan** bahwa sudut rotasi untuk semua konektor yang ditampilkan di bawah **[Jenis Konektor](/slides/id/net/connector/#types-of-connectors)** adalah 0.

#### **Kasus 1**

Pertimbangkan sebuah kasus di mana dua objek bingkai teks ditautkan bersama melalui sebuah konektor:

![connector-shape-complex](connector-shape-complex.png)

Kode:

```c#
// Membuat instance kelas presentasi yang mewakili file PPTX
Presentation pres = new Presentation();
// Mengambil slide pertama dalam presentasi
ISlide sld = pres.Slides[0];
// Menambahkan bentuk yang akan digabungkan melalui sebuah konektor
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// Menambahkan konektor
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// Menentukan arah konektor
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// Menentukan warna konektor
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// Menentukan ketebalan garis konektor
connector.LineFormat.Width = 3;

// Menautkan bentuk-bentuk bersama dengan konektor
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// Mengambil titik penyesuaian untuk konektor
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**Penyesuaian**

Kita dapat mengubah nilai titik penyesuaian konektor dengan meningkatkan persentase lebar dan tinggi yang bersangkutan masing‑masing sebesar 20% dan 200%:

```c#
// Mengubah nilai titik penyesuaian
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Hasilnya:

![connector-adjusted-1](connector-adjusted-1.png)

Untuk mendefinisikan sebuah model yang memungkinkan kita menentukan koordinat dan bentuk bagian‑bagian individual konektor, mari buat sebuah bentuk yang sesuai dengan komponen horizontal konektor pada titik `connector.Adjustments[0]`:

```c#
 // Gambar komponen vertikal dari konektor

 float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
 float y = connector.Y;
 float height = connector.Height * adjValue_1.RawValue / 100000;
 sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Hasilnya:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Kasus 2**

Dalam **Kasus 1**, kami mendemonstrasikan operasi penyesuaian konektor sederhana menggunakan prinsip dasar. Dalam situasi normal, Anda harus memperhitungkan rotasi konektor dan tampilanannya (yang diatur oleh `connector.Rotation`, `connector.Frame.FlipH`, dan `connector.Frame.FlipV`). Kami akan mendemonstrasikan prosesnya sekarang.

Pertama, tambahkan sebuah objek bingkai teks baru (**To 1**) ke slide (untuk tujuan koneksi) dan buat sebuah konektor (hijau) yang menghubungkannya dengan objek‑objek yang telah kami buat.

```c#
// Membuat objek binding baru
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// Membuat konektor baru
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// Menghubungkan objek menggunakan konektor yang baru dibuat
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// Mengambil titik penyesuaian konektor
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// Mengubah nilai titik penyesuaian 
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Hasilnya:

![connector-adjusted-3](connector-adjusted-3.png)

Kedua, buat sebuah bentuk yang akan sesuai dengan komponen horizontal konektor yang melewati titik penyesuaian baru `connector.Adjustments[0]`. Kami akan menggunakan nilai‑nilai dari data konektor untuk `connector.Rotation`, `connector.Frame.FlipH`, dan `connector.Frame.FlipV` serta menerapkan formula konversi koordinat populer untuk rotasi mengelilingi titik tertentu x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Dalam kasus kami, sudut rotasi objek adalah 90 derajat dan konektor ditampilkan secara vertikal, sehingga kode yang bersangkutan adalah:

```c#
 // Menyimpan koordinat konektor
 x = connector.X;
 y = connector.Y;
 // Memperbaiki koordinat konektor jika muncul
 if (connector.Frame.FlipH == NullableBool.True)
 {
     x += connector.Width;
 }
 if (connector.Frame.FlipV == NullableBool.True)
 {
     y += connector.Height;
 }
 // Menggunakan nilai titik penyesuaian sebagai koordinat
 x += connector.Width * adjValue_0.RawValue / 100000;
 //  Mengonversi koordinat karena Sin(90) = 1 dan Cos(90) = 0
 float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
 float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
 // Menentukan lebar komponen horizontal menggunakan nilai titik penyesuaian kedua
 float width = connector.Height * adjValue_1.RawValue / 100000;
 IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
 shape.LineFormat.FillFormat.FillType = FillType.Solid;
 shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
```

Hasilnya:

![connector-adjusted-4](connector-adjusted-4.png)

Kami telah mendemonstrasikan perhitungan yang melibatkan penyesuaian sederhana dan titik penyesuaian rumit (titik penyesuaian dengan sudut rotasi). Dengan pengetahuan yang diperoleh, Anda dapat mengembangkan model Anda sendiri (atau menulis kode) untuk mendapatkan objek `GraphicsPath` atau bahkan mengatur nilai‑nilai titik penyesuaian konektor berdasarkan koordinat slide tertentu.

## **Temukan Sudut Garis Konektor**
1. Buat instance kelas [Presentasi](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
1. Dapatkan referensi slide melalui indeksnya.
1. Akses bentuk garis konektor. 
1. Gunakan lebar, tinggi, tinggi bingkai bentuk, dan lebar bingkai bentuk untuk menghitung sudutnya.

Kode C# berikut mendemonstrasikan operasi di mana kami menghitung sudut untuk sebuah bentuk garis konektor:

```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **FAQ**

**Bagaimana saya dapat mengetahui apakah sebuah konektor dapat “dilekatkan” pada bentuk tertentu?**

Periksa bahwa bentuk tersebut mengekspos [situs koneksi](https://reference.aspose.com/slides/id/net/aspose.slides/shape/connectionsitecount/). Jika tidak ada atau jumlahnya nol, pelekatan tidak tersedia; dalam hal itu, gunakan titik akhir bebas dan posisikan secara manual. Disarankan untuk memeriksa jumlah situs sebelum menempelkan.

**Apa yang terjadi pada sebuah konektor jika saya menghapus salah satu bentuk yang terhubung?**

Ujung‑ujungnya akan terlepas; konektor tetap berada di slide sebagai garis biasa dengan titik awal/akhir bebas. Anda dapat menghapusnya atau menetapkan kembali koneksi dan, jika diperlukan, [mengarahkan ulang](https://reference.aspose.com/slides/id/net/aspose.slides/connector/reroute/).

**Apakah ikatan konektor dipertahankan ketika menyalin slide ke presentasi lain?**

Secara umum ya, asalkan bentuk‑bentuk target juga disalin. Jika slide dimasukkan ke file lain tanpa bentuk‑bentuk yang terhubung, ujung‑ujungnya menjadi bebas dan Anda perlu menempelkan kembali.