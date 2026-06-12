---
title: Kelola Konektor dalam Presentasi Menggunakan C++
linktitle: Konektor
type: docs
weight: 10
url: /id/cpp/connector/
keywords:
- konektor
- tipe konektor
- titik konektor
- garis konektor
- sudut konektor
- hubungkan bentuk
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Memberdayakan aplikasi C++ untuk menggambar, menghubungkan, dan mengarahkan otomatis garis pada slide PowerPoint—dapatkan kontrol penuh atas konektor lurus, siku, dan melengkung."
---
## **Pendahuluan**

Konektor PowerPoint adalah garis khusus yang menghubungkan atau menautkan dua bentuk bersama-sama dan tetap terpasang pada bentuk meskipun dipindahkan atau diposisikan kembali pada slide tertentu. 

Konektor biasanya terhubung ke *titik koneksi* (titik hijau), yang secara default ada pada semua bentuk. Titik koneksi muncul ketika kursor mendekatinya.

*Titik penyesuaian* (titik oranye), yang hanya ada pada beberapa konektor, digunakan untuk mengubah posisi dan bentuk konektor.

## **Jenis Konektor**

Di PowerPoint, Anda dapat menggunakan konektor lurus, siku (ber sudut), dan melengkung. 

Aspose.Slides menyediakan konektor berikut:

| Konektor | Gambar | Jumlah titik penyesuaian |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Hubungkan Bentuk Menggunakan Konektor**

1. Buat sebuah instance dari kelas [Presentasi](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation/).
1. Dapatkan referensi slide melalui indeksnya.
1. Tambahkan dua [AutoShape](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.auto_shape) ke slide menggunakan metode `AddAutoShape` yang disediakan oleh objek `Shapes`.
1. Tambahkan sebuah konektor menggunakan metode `AddConnector` yang disediakan oleh objek `Shapes` dengan menentukan tipe konektor.
1. Hubungkan bentuk-bentuk tersebut menggunakan konektor. 
1. Panggil metode `Reroute` untuk menerapkan jalur koneksi terpendek.
1. Simpan presentasi. 

Kode C++ berikut menunjukkan cara menambahkan sebuah konektor (konektor bengkok) antara dua bentuk (sebuah elips dan persegi panjang):

```c++
// Jalur ke direktori dokumen.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Memuat presentasi yang diinginkan
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Mengakses slide pertama
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Mengakses koleksi bentuk untuk slide tertentu
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Menambahkan autoshape Ellipse
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Menambahkan autoshape Persegi Empat
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// Menambahkan bentuk konektor ke koleksi bentuk slide
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// Menghubungkan bentuk menggunakan konektor
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// Memanggil reroute yang mengatur jalur terpendek otomatis antara bentuk
	connector->Reroute();
	
	// Menyimpan presentasi
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 

`Metode connector->Reroute` mengarahkan ulang sebuah konektor dan memaksa ia mengambil jalur terpendek yang memungkinkan antara bentuk-bentuk. Untuk mencapai tujuan tersebut, metode ini dapat mengubah titik `StartShapeConnectionSiteIndex` dan `EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Tentukan Titik Koneksi**

Jika Anda ingin sebuah konektor menautkan dua bentuk menggunakan titik tertentu pada bentuk-bentuk tersebut, Anda harus menentukan titik koneksi yang diinginkan dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentasi](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation/).
1. Dapatkan referensi slide melalui indeksnya.
1. Tambahkan dua [AutoShape](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.auto_shape) ke slide menggunakan metode `AddAutoShape` yang disediakan oleh objek `Shapes`.
1. Tambahkan sebuah konektor menggunakan metode `AddConnector` yang disediakan oleh objek `Shapes` dengan menentukan tipe konektor.
1. Hubungkan bentuk-bentuk tersebut menggunakan konektor. 
1. Tetapkan titik koneksi yang diinginkan pada bentuk-bentuk. 
1. Simpan presentasi.

Kode C++ berikut mendemonstrasikan operasi dimana titik koneksi yang diinginkan ditentukan:

```c++
	// Jalur ke direktori dokumen.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Memuat presentasi yang diinginkan
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Mengakses slide pertama
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Mengakses koleksi bentuk untuk slide tertentu
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Menambahkan autoshape Ellipse
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Menambahkan autoshape Persegi Empat
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// Menambahkan bentuk konektor ke koleksi bentuk slide
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// Menghubungkan bentuk menggunakan konektor
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// Menetapkan indeks titik koneksi yang diinginkan pada bentuk Ellipse
	int wantedIndex = 6;

	// Memeriksa apakah indeks yang diinginkan kurang dari jumlah maksimum situs indeks
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// Menetapkan titik koneksi yang diinginkan pada autoshape Ellipse
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// Menyimpan presentasi
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Sesuaikan Titik Konektor**

Anda dapat menyesuaikan sebuah konektor yang sudah ada melalui titik penyesuaian nya. Hanya konektor dengan titik penyesuaian yang dapat diubah dengan cara ini. Lihat tabel di bawah **[Jenis Konektor.](/slides/id/cpp/connector/#types-of-connectors)** 

### **Kasus Sederhana**

Pertimbangkan sebuah kasus dimana sebuah konektor antara dua bentuk (A dan B) melewati bentuk ketiga (C):

![connector-obstruction](connector-obstruction.png)

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shapes = slide->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 300.0f, 150.0f, 150.0f, 75.0f);
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 400.0f, 100.0f, 50.0f);
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 70.0f, 30.0f);

auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20.0f, 20.0f, 400.0f, 300.0f);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_StartShapeConnectionSiteIndex(2);
```

Untuk menghindari atau melewati bentuk ketiga, kita dapat menyesuaikan konektor dengan memindahkan garis vertikalnya ke kiri seperti ini:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **Kasus Kompleks** 

Untuk melakukan penyesuaian yang lebih rumit, Anda harus mempertimbangkan hal-hal berikut:

* Sebuah titik penyesuaian pada konektor sangat terkait dengan formula yang menghitung dan menentukan posisinya. Jadi perubahan lokasi titik dapat mengubah bentuk konektor.
* Titik penyesuaian pada konektor didefinisikan dalam urutan yang ketat dalam sebuah array. Titik-titik penyesuaian diberi nomor mulai dari titik awal konektor hingga titik akhirnya.
* Nilai titik penyesuaian mencerminkan persentase lebar/tinggi bentuk konektor. 
  * Bentuk dibatasi oleh titik awal dan akhir konektor yang dikalikan dengan 1000. 
  * Titik pertama, titik kedua, dan titik ketiga masing-masing mendefinisikan persentase dari lebar, persentase dari tinggi, dan persentase dari lebar (lagi) secara berurutan.
* Untuk perhitungan yang menentukan koordinat titik penyesuaian konektor, Anda harus memperhitungkan rotasi konektor dan refleksinya. **Catatan** bahwa sudut rotasi untuk semua konektor yang ditampilkan di bawah **[Jenis Konektor](/slides/id/cpp/connector/#types-of-connectors)** adalah 0.

#### **Kasus 1**

Pertimbangkan sebuah kasus dimana dua objek bingkai teks ditautkan bersama melalui sebuah konektor:

![connector-shape-complex](connector-shape-complex.png)

```c++
// Membuat instance kelas presentasi yang mewakili file PPTX
auto pres = System::MakeObject<Presentation>();
// Mengambil slide pertama dalam presentasi
auto slide = pres->get_Slides()->idx_get(0);
// Mengambil bentuk dari slide pertama
auto shapes = slide->get_Shapes();
// Menambahkan bentuk yang akan digabungkan bersama melalui sebuah konektor
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"From");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"To");
// Menambahkan sebuah konektor
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// Menentukan arah konektor
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// Menentukan ketebalan garis konektor
lineFormat->set_Width(3);
// Menentukan warna konektor
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// Menghubungkan bentuk-bentuk bersama dengan konektor
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// Mengambil titik penyesuaian untuk konektor
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**Penyesuaian**

Kita dapat mengubah nilai titik penyesuaian konektor dengan meningkatkan persentase lebar dan tinggi yang bersangkutan masing-masing sebesar 20% dan 200%:

```c++
// Mengubah nilai titik penyesuaian
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Hasilnya:

![connector-adjusted-1](connector-adjusted-1.png)

Untuk mendefinisikan model yang memungkinkan kita menentukan koordinat dan bentuk bagian-bagian individu dari konektor, mari buat sebuah bentuk yang sesuai dengan komponen horizontal konektor pada titik connector.Adjustments[0]:

```c++
// Gambar komponen vertikal dari konektor
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

Hasilnya:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Kasus 2**

Di **Kasus 1**, kami mendemonstrasikan operasi penyesuaian konektor sederhana menggunakan prinsip dasar. Dalam situasi normal, Anda harus mempertimbangkan rotasi konektor dan tampilan nya (yang diatur oleh connector.Rotation, connector.Frame.FlipH, dan connector.Frame.FlipV). Kami sekarang akan mendemonstrasikan prosesnya.

Pertama, mari tambahkan sebuah objek bingkai teks baru (**To 1**) ke slide (untuk tujuan koneksi) dan buat sebuah konektor (hijau) baru yang menghubungkannya ke objek-objek yang sudah kami buat.

```c++
// Membuat objek binding baru
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// Membuat konektor baru
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// Menghubungkan objek menggunakan konektor yang baru dibuat
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// Mengambil titik penyesuaian konektor
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// Mengubah nilai titik penyesuaian
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Hasilnya:

![connector-adjusted-3](connector-adjusted-3.png)

Kedua, mari buat sebuah bentuk yang akan sesuai dengan komponen horizontal konektor yang melewati titik penyesuaian baru connector.Adjustments[0]. Kami akan menggunakan nilai-nilai dari data konektor untuk connector.Rotation, connector.Frame.FlipH, dan connector.Frame.FlipV serta menerapkan formula konversi koordinat populer untuk rotasi sekitar titik x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Dalam kasus kami, sudut rotasi objek adalah 90 derajat dan konektor ditampilkan secara vertikal, sehingga inilah kode yang sesuai:

```c++

```

Hasilnya:

![connector-adjusted-4](connector-adjusted-4.png)

Kami telah mendemonstrasikan perhitungan yang melibatkan penyesuaian sederhana dan titik penyesuaian yang rumit (titik penyesuaian dengan sudut rotasi). Dengan pengetahuan yang diperoleh, Anda dapat mengembangkan model Anda sendiri (atau menulis kode) untuk mendapatkan objek `GraphicsPath` atau bahkan mengatur nilai titik penyesuaian konektor berdasarkan koordinat slide tertentu.

## **Temukan Sudut Garis Konektor**

1. Buat sebuah instance dari kelas [Presentasi](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation/).
1. Dapatkan referensi slide melalui indeksnya.
1. Akses bentuk garis konektor.
1. Gunakan lebar garis, tinggi, tinggi bingkai bentuk, dan lebar bingkai bentuk untuk menghitung sudut.

Kode C++ berikut mendemonstrasikan operasi dimana kami menghitung sudut untuk sebuah bentuk garis konektor:

```c++
void ConnectorLineAngle()
{

	// Jalur ke direktori dokumen.
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Memuat presentasi yang diinginkan
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Mengakses slide pertama
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// Mengakses koleksi bentuk slide
		System::SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(i);

		if (System::ObjectExt::Is<AutoShape>(shape))
		{
			SharedPtr<AutoShape> aShape = ExplicitCast<Aspose::Slides::AutoShape>(shape);
			if (aShape->get_ShapeType() == ShapeType::Line)
			{
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(), aShape->get_Frame()->get_FlipV());

			}
		}

		else if (System::ObjectExt::Is<Connector>(shape))
		{
				SharedPtr<Connector> aShape = ExplicitCast<Aspose::Slides::Connector>(shape);
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(),aShape->get_Frame()->get_FlipV());
		}

		Console::WriteLine(dir);
	
	}


}
//double ConnectorLineAngle::getDirection(float w, float h, NullableBool flipH, NullableBool flipV)
double getDirection(float w, float h, Aspose::Slides::NullableBool flipH, Aspose::Slides::NullableBool flipV)
{
	float endLineX = w;

	if (flipH == NullableBool::True)
		endLineX= endLineX * -1;
	else
		endLineX=endLineX *  1;
	//float endLineX = w * (flipH ? -1 : 1);
	float endLineY = h;
	if (flipV == NullableBool::True)
		endLineY = endLineY * -1;
	else
		endLineY = endLineY *  1;
	//float endLineY = h * (flipV ? -1 : 1);
	float endYAxisX = 0;
	float endYAxisY = h;
	double angle = (Math::Atan2(endYAxisY, endYAxisX) - Math::Atan2(endLineY, endLineX));
	if (angle < 0) angle += 2 * Math::PI;
	return angle * 180.0 / Math::PI;
}
```

## **FAQ**

**Bagaimana saya dapat mengetahui apakah sebuah konektor dapat "menempel" pada bentuk tertentu?**

Periksa apakah bentuk tersebut menyediakan [situs koneksi](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/get_connectionsitecount/). Jika tidak ada atau jumlahnya nol, penempelan tidak tersedia; dalam hal ini, gunakan titik akhir bebas dan posisikan secara manual. Sebaiknya periksa jumlah situs sebelum menempelkan.

**Apa yang terjadi pada sebuah konektor jika saya menghapus salah satu bentuk yang terhubung?**

Ujung-ujungnya akan terlepas; konektor tetap berada di slide sebagai garis biasa dengan awal/akhir bebas. Anda dapat menghapusnya atau menetapkan kembali koneksi, dan bila diperlukan, [reroute](https://reference.aspose.com/slides/id/cpp/aspose.slides/connector/reroute/).

**Apakah ikatan konektor dipertahankan saat menyalin slide ke presentasi lain?**

Secara umum ya, dengan asumsi bentuk target juga disalin. Jika slide dimasukkan ke file lain tanpa bentuk yang terhubung, ujung-ujungnya menjadi bebas dan Anda perlu menempelkannya kembali.