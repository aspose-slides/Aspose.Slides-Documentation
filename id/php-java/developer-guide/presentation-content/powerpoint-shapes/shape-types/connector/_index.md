---
title: "Kelola Penghubung dalam Presentasi Menggunakan PHP"
linktitle: "Penghubung"
type: docs
weight: 10
url: /id/php-java/connector/
keywords:
- "penghubung"
- "tipe penghubung"
- "titik penghubung"
- "garis penghubung"
- "sudut penghubung"
- "menghubungkan bentuk"
- "PowerPoint"
- "presentasi"
- "PHP"
- "Aspose.Slides"
description: "Memberdayakan aplikasi PHP untuk menggambar, menghubungkan, dan mengatur otomatis jalur garis pada slide PowerPoint — dapatkan kontrol penuh atas penghubung lurus, siku, dan melengkung."
---
## **Pendahuluan**

Penghubung PowerPoint adalah garis khusus yang menghubungkan atau menautkan dua bentuk bersama-sama dan tetap menempel pada bentuk meskipun dipindahkan atau diposisikan kembali pada slide tertentu.

Penghubung biasanya terhubung ke *titik koneksi* (titik hijau), yang secara default ada pada semua bentuk. Titik koneksi muncul ketika kursor mendekatinya.

*Titk penyesuaian* (titik oranye), yang hanya ada pada penghubung tertentu, digunakan untuk mengubah posisi dan bentuk penghubung.

## **Jenis Penghubung**

Di PowerPoint, Anda dapat menggunakan penghubung lurus, siku (ber sudut), dan melengkung.

Aspose.Slides menyediakan penghubung ini:

| Penghubung | Gambar | Jumlah titik penyesuaian |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType::Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType::BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType::BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType::BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType::CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType::CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

## **Menghubungkan Bentuk dengan Penghubung**

1. Buat instance kelas [Presentation](https://apireference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Dapatkan referensi slide melalui indeksnya.
1. Tambahkan dua [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/AutoShape) ke slide menggunakan metode `addAutoShape` yang disediakan oleh objek `Shapes`.
1. Tambahkan sebuah penghubung menggunakan metode `addConnector` yang disediakan oleh objek `Shapes` dengan mendefinisikan tipe penghubung.
1. Hubungkan bentuk-bentuk tersebut dengan penghubung.
1. Panggil metode `reroute` untuk menerapkan jalur koneksi terpendek.
1. Simpan presentasi.

Kode PHP berikut menunjukkan cara menambahkan penghubung (penghubung bengkok) antara dua bentuk (elips dan persegi panjang):

```php
// Membuat instance kelas presentasi yang mewakili file PPTX
  $pres = new Presentation();
  try {
    # Mengakses koleksi bentuk untuk slide tertentu
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Menambahkan autoshape Elips
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Menambahkan autoshape Persegi Panjang
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Menambahkan bentuk penghubung ke koleksi bentuk slide
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Menghubungkan bentuk-bentuk menggunakan penghubung
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Memanggil reroute yang mengatur jalur terpendek otomatis antara bentuk-bentuk
    $connector->reroute();
    # Menyimpan presentasi
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Metode `Connector.reroute` merutekan ulang penghubung dan memaksa ia mengambil jalur terpendek yang mungkin antara bentuk-bentuk. Untuk mencapai tujuan tersebut, metode dapat mengubah titik `setStartShapeConnectionSiteIndex` dan `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Menentukan Titik Koneksi**

Jika Anda ingin sebuah penghubung menautkan dua bentuk menggunakan titik tertentu pada bentuk, Anda harus menentukan titik koneksi pilihan Anda dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Dapatkan referensi slide melalui indeksnya.
1. Tambahkan dua [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/AutoShape) ke slide menggunakan metode `addAutoShape` yang disediakan oleh objek `Shapes`.
1. Tambahkan sebuah penghubung menggunakan metode `addConnector` yang disediakan oleh objek `Shapes` dengan mendefinisikan tipe penghubung.
1. Hubungkan bentuk-bentuk tersebut dengan penghubung.
1. Tentukan titik koneksi pilihan Anda pada bentuk-bentuk.
1. Simpan presentasi.

Kode PHP berikut mendemonstrasikan operasi di mana sebuah titik koneksi pilihan ditentukan:

```php
  # Membuat instance kelas presentasi yang mewakili file PPTX
  $pres = new Presentation();
  try {
    # Mengakses koleksi bentuk untuk slide tertentu
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Menambahkan autoshape Elips
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Menambahkan autoshape Persegi Panjang
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Menambahkan bentuk penghubung ke koleksi bentuk slide
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Menghubungkan bentuk-bentuk menggunakan penghubung
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Menetapkan indeks titik koneksi pilihan pada bentuk Elips
    $wantedIndex = 6;
    # Memeriksa apakah indeks pilihan lebih kecil dari jumlah maksimum situs koneksi
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # Menetapkan titik koneksi pilihan pada autoshape Elips
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # Menyimpan presentasi
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menyesuaikan Titik Penghubung**

Anda dapat menyesuaikan penghubung yang ada melalui titik penyesuaian-nya. Hanya penghubung dengan titik penyesuaian yang dapat diubah dengan cara ini. Lihat tabel di bawah **[Jenis penghubung](/slides/id/php-java/connector/#types-of-connectors)**

### **Kasus Sederhana**

Pertimbangkan kasus di mana sebuah penghubung antara dua bentuk (A dan B) melewati bentuk ketiga (C):

![connector-obstruction](connector-obstruction.png)

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setStartShapeConnectionSiteIndex(2);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Untuk menghindari atau melewati bentuk ketiga, kita dapat menyesuaikan penghubung dengan menggeser garis vertikalnya ke kiri seperti ini:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);

```

### **Kasus Kompleks** 

Untuk melakukan penyesuaian yang lebih rumit, Anda harus memperhatikan hal-hal berikut:

* Titik penyesuaian penghubung sangat terkait dengan rumus yang menghitung dan menentukan posisinya. Jadi perubahan lokasi titik dapat mengubah bentuk penghubung.
* Titik penyesuaian penghubung didefinisikan dalam urutan yang ketat dalam sebuah array. Titik penyesuaian diberi nomor mulai dari titik awal penghubung hingga titik akhir.
* Nilai titik penyesuaian mencerminkan persentase lebar/tinggi bentuk penghubung. 
  * Bentuk dibatasi oleh titik awal dan akhir penghubung yang dikalikan 1000. 
  * Titik pertama, kedua, dan ketiga masing‑masing menentukan persentase dari lebar, persentase dari tinggi, dan persentase dari lebar (lagi).
* Untuk perhitungan yang menentukan koordinat titik penyesuaian penghubung, Anda harus mempertimbangkan rotasi penghubung dan refleksinya. **Catatan** bahwa sudut rotasi untuk semua penghubung yang ditampilkan di bawah **[Jenis penghubung](/slides/id/php-java/connector/#types-of-connectors)** adalah 0.

#### **Kasus 1**

Pertimbangkan kasus di mana dua objek bingkai teks ditautkan bersama melalui sebuah penghubung:

![connector-shape-complex](connector-shape-complex.png)

```php
  # Membuat instance kelas presentasi yang mewakili file PPTX
  $pres = new Presentation();
  try {
    # Mendapatkan slide pertama dalam presentasi
    $sld = $pres->getSlides()->get_Item(0);
    # Menambahkan bentuk-bentuk yang akan digabungkan melalui penghubung
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # Menambahkan penghubung
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # Menentukan arah penghubung
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # Menentukan warna penghubung
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Menentukan ketebalan garis penghubung
    $connector->getLineFormat()->setWidth(3);
    # Menautkan bentuk-bentuk bersama dengan penghubung
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # Mengambil titik penyesuaian untuk penghubung
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Penyesuaian**

Kita dapat mengubah nilai titik penyesuaian penghubung dengan meningkatkan persentase lebar dan tinggi yang bersesuaian masing‑masing sebesar 20 % dan 200 %:

```php
  # Mengubah nilai titik penyesuaian
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

Hasilnya:

![connector-adjusted-1](connector-adjusted-1.png)

Untuk mendefinisikan model yang memungkinkan kita menentukan koordinat dan bentuk bagian‑bagian individu penghubung, buatlah sebuah bentuk yang mewakili komponen horisontal penghubung pada titik `connector.getAdjustments().get_Item(0)`:

```php
  # Menggambar komponen vertikal penghubung
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```

Hasilnya:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Kasus 2**

Pada **Kasus 1**, kami mendemonstrasikan operasi penyesuaian penghubung sederhana menggunakan prinsip dasar. Pada situasi normal, Anda harus mempertimbangkan rotasi penghubung serta tampilannya (yang diatur oleh `connector.getRotation()`, `connector.getFrame().getFlipH()`, dan `connector.getFrame().getFlipV()`). Kami kini akan mendemonstrasikan proses tersebut.

Pertama, tambahkan objek bingkai teks baru (**To 1**) ke slide (untuk tujuan koneksi) dan buat sebuah penghubung (hijau) yang menghubungkannya dengan objek‑objek yang sudah ada.

```php
  # Membuat objek binding baru
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
  # Membuat penghubung baru
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # Menghubungkan objek menggunakan penghubung yang baru dibuat
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # Mengambil titik penyesuaian penghubung
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # Mengubah nilai titik penyesuaian
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

Hasilnya:

![connector-adjusted-3](connector-adjusted-3.png)

Kedua, buat sebuah bentuk yang akan mewakili komponen horisontal penghubung yang melewati titik penyesuaian penghubung baru `connector.getAdjustments().get_Item(0)`. Gunakan nilai‑nilai dari data penghubung untuk `connector.getRotation()`, `connector.getFrame().getFlipH()`, dan `connector.getFrame().getFlipV()` serta terapkan rumus konversi koordinat populer untuk rotasi mengelilingi titik x₀:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Dalam kasus kami, sudut rotasi objek adalah 90 derajat dan penghubung ditampilkan secara vertikal, sehingga kodenya adalah:

```php
  # Menyimpan koordinat penghubung
  $x = $connector->getX();
  $y = $connector->getY();
  # Mengoreksi koordinat penghubung jika muncul
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # Mengambil nilai titik penyesuaian sebagai koordinat
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # Mengonversi koordinat karena Sin(90) = 1 dan Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # Menentukan lebar komponen horizontal menggunakan nilai titik penyesuaian kedua
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```

Hasilnya:

![connector-adjusted-4](connector-adjusted-4.png)

Kami telah mendemonstrasikan perhitungan yang melibatkan penyesuaian sederhana dan titik penyesuaian yang rumit (titik dengan sudut rotasi). Dengan pengetahuan ini, Anda dapat mengembangkan model Anda sendiri (atau menulis kode) untuk memperoleh objek `GraphicsPath` atau bahkan menetapkan nilai titik penyesuaian penghubung berdasarkan koordinat slide tertentu.

## **Menemukan Sudut Garis Penghubung**

1. Buat instance kelas.
1. Dapatkan referensi slide melalui indeksnya.
1. Akses bentuk garis penghubung.
1. Gunakan lebar, tinggi, tinggi bingkai bentuk, dan lebar bingkai bentuk untuk menghitung sudutnya.

Kode PHP berikut mendemonstrasikan operasi di mana kami menghitung sudut untuk sebuah bentuk garis penghubung:

```php
  $pres = new Presentation("ConnectorLineAngle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
      $dir = 0.0;
      $shape = $slide->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $ashp = $shape;
        if ($ashp->getShapeType() == ShapeType::Line) {
          $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, $ashp->getFrame()->getFlipV() > 0);
        }
      } else if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
        $ashp = $shape;
        $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, java_values($ashp->getFrame()->getFlipV()) > 0);
      }
      echo($dir);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Bagaimana saya dapat mengetahui apakah sebuah penghubung dapat “dilekatkan” pada bentuk tertentu?**

Periksa apakah bentuk tersebut menyediakan [situs koneksi](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getconnectionsitecount/). Jika tidak ada atau jumlahnya nol, pelekatan tidak tersedia; dalam kasus tersebut, gunakan ujung bebas dan posisikan secara manual. Sebaiknya periksa jumlah situs sebelum menempelkan.

**Apa yang terjadi pada penghubung jika saya menghapus salah satu bentuk yang terhubung?**

Ujung‑ujungnya akan terlepas; penghubung tetap berada di slide sebagai garis biasa dengan awal/akhir bebas. Anda dapat menghapusnya atau menetapkan kembali koneksi, dan bila perlu, [reroute](https://reference.aspose.com/slides/id/php-java/aspose.slides/connector/reroute/).

**Apakah ikatan penghubung dipertahankan saat menyalin slide ke presentasi lain?**

Umumnya ya, asalkan bentuk‑bentuk target juga disalin. Jika slide dimasukkan ke file lain tanpa bentuk‑bentuk yang terhubung, ujung‑ujungnya menjadi bebas dan Anda perlu menempelkannya kembali.