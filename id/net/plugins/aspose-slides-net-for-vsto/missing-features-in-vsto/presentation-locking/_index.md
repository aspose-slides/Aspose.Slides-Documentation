---
title: Penguncian Presentasi
type: docs
weight: 110
url: /id/net/presentation-locking/
---
## **Penguncian Presentasi**
Penggunaan umum untuk **Aspose.Slides** adalah membuat, memperbarui, dan menyimpan presentasi Microsoft PowerPoint 2007 (PPTX) sebagai bagian dari alur kerja otomatis. Pengguna aplikasi yang menggunakan Aspose.Slides dengan cara ini mendapatkan akses ke presentasi keluaran. Melindungi mereka dari penyuntingan merupakan keprihatinan umum. Penting agar presentasi yang dihasilkan secara otomatis mempertahankan format dan konten aslinya.

Ini menjelaskan bagaimana presentasi dan slide dibangun serta bagaimana Aspose.Slides for .NET dapat menerapkan proteksi, dan kemudian menghapusnya dari sebuah presentasi. Fitur ini unik untuk Aspose.Slides dan, pada saat penulisan, tidak tersedia di Microsoft PowerPoint. Ini memberi pengembang cara mengontrol bagaimana presentasi yang dibuat oleh aplikasi mereka digunakan.
## **Komposisi Slide**
Sebuah slide PPTX terdiri dari sejumlah komponen seperti auto shapes, tabel, objek OLE, grouped shapes, picture frames, video frames, connectors, dan berbagai elemen lain yang tersedia untuk membangun sebuah presentasi.

Dalam Aspose.Slides for .NET, setiap elemen pada slide diubah menjadi objek Shape. Dengan kata lain, setiap elemen pada slide adalah objek Shape atau objek yang diturunkan dari objek Shape.

Struktur PPTX kompleks sehingga tidak seperti PPT, di mana kunci generik dapat digunakan untuk semua jenis shape, ada berbagai jenis kunci untuk tipe shape yang berbeda. Kelas BaseShapeLock adalah kelas kunci PPTX generik. Jenis-jenis kunci berikut didukung dalam Aspose.Slides for .NET untuk PPTX.

- AutoShapeLock mengunci auto shapes.
- ConnectorLock mengunci shape konektor.
- GraphicalObjectLock mengunci objek grafis.
- GroupshapeLock mengunci group shapes.
- PictureFrameLock mengunci picture frames.

Setiap tindakan yang dilakukan pada semua objek Shape dalam objek Presentation diterapkan pada seluruh presentasi.
## **Menerapkan dan Menghapus Proteksi**
Menerapkan proteksi memastikan bahwa sebuah presentasi tidak dapat diedit. Ini merupakan teknik yang berguna untuk melindungi konten presentasi.

**Menerapkan Proteksi ke Shape PPTX**

Aspose.Slides for .NET menyediakan kelas Shape untuk menangani sebuah shape pada slide.

Seperti disebutkan sebelumnya, setiap kelas shape memiliki kelas shape lock terkait untuk proteksi. Artikel ini fokus pada kunci NoSelect, NoMove, dan NoResize. Kunci-kunci ini memastikan bahwa shape tidak dapat dipilih (melalui klik mouse atau metode seleksi lain), dan tidak dapat dipindahkan atau diubah ukurannya.

Contoh kode berikut menerapkan proteksi pada semua jenis shape dalam sebuah presentasi.

``` csharp

 //Instansiasi kelas Presentation yang mewakili file PPTX

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//Instansiasi kelas Presentation yang mewakili file PPTX


//Objek ISlide untuk mengakses slide dalam presentasi

SlideEx slide = pTemplate.Slides[0];

//Objek IShape untuk menampung shape sementara

ShapeEx shape;

//Menelusuri semua slide dalam presentasi

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Menelusuri semua shape dalam slide

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//jika shape adalah autoshape

		if (shape is AutoShapeEx)

		{

			//Casting tipe ke Auto shape dan mendapatkan kunci auto shape

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Menerapkan kunci pada shape

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//jika shape adalah group shape

		else if (shape is GroupShapeEx)

		{

			//Casting tipe ke group shape dan mendapatkan kunci group shape

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Menerapkan kunci pada shape

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//jika shape adalah a connector

		else if (shape is ConnectorEx)

		{

			//Casting tipe ke connector shape dan mendapatkan kunci connector shape

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Menerapkan kunci pada shape

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//jika shape adalah picture frame

		else if (shape is PictureFrameEx)

		{

			//Casting tipe ke picture frame shape dan mendapatkan kunci picture frame shape

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Menerapkan kunci pada shape

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//Menyimpan file presentasi

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**Menghapus Proteksi**

Proteksi yang diterapkan menggunakan Aspose.Slides for .NET hanya dapat dihapus dengan Aspose.Slides for .NET. Untuk membuka kunci sebuah shape, setel nilai kunci yang diterapkan menjadi false. Contoh kode berikut menunjukkan cara membuka kunci shape dalam presentasi yang terkunci.

``` csharp

 //Buka presentasi yang diinginkan
PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//Objek ISlide untuk mengakses slide dalam presentasi
SlideEx slide = pTemplate.Slides[0];

//Objek IShape untuk menampung shape sementara
ShapeEx shape;

//Menelusuri semua slide dalam presentasi
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
	slide = pTemplate.Slides[slideCount];
	//Menelusuri semua shape dalam slide
	for (int count = 0; count < slide.Shapes.Count; count++)
	{
		shape = slide.Shapes[count];
		//jika shape adalah autoshape
		if (shape is AutoShapeEx)
		{
			//Casting tipe ke Auto shape dan mendapatkan kunci auto shape
			AutoShapeEx Ashp = shape as AutoShapeEx;
			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;
			//Menerapkan kunci pada shape
			AutoShapeLock.PositionLocked = false;
			AutoShapeLock.SelectLocked = false;
			AutoShapeLock.SizeLocked = false;
		}
		//jika shape adalah group shape
		else if (shape is GroupShapeEx)
		{
			//Casting tipe ke group shape dan mendapatkan kunci group shape
			GroupShapeEx Group = shape as GroupShapeEx;
			GroupShapeLockEx groupShapeLock = Group.ShapeLock;
			//Menerapkan kunci pada shape
			groupShapeLock.GroupingLocked = false;
			groupShapeLock.PositionLocked = false;
			groupShapeLock.SelectLocked = false;
			groupShapeLock.SizeLocked = false;
		}
		//jika shape adalah Connector shape
		else if (shape is ConnectorEx)
		{
			//Casting tipe ke connector shape dan mendapatkan kunci connector shape
			ConnectorEx Conn = shape as ConnectorEx;
			ConnectorLockEx ConnLock = Conn.ShapeLock;
			//Menerapkan kunci pada shape
			ConnLock.PositionMove = false;
			ConnLock.SelectLocked = false;
			ConnLock.SizeLocked = false;
		}
		//jika shape adalah picture frame
		else if (shape is PictureFrameEx)
		{
			//Casting tipe ke picture frame shape dan mendapatkan kunci picture frame shape
			PictureFrameEx Pic = shape as PictureFrameEx;
			PictureFrameLockEx PicLock = Pic.ShapeLock;
			//Menerapkan kunci pada shape
			PicLock.PositionLocked = false;
			PicLock.SelectLocked = false;
			PicLock.SizeLocked = false;
		}
	}
}

//Menyimpan file presentasi
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 
## **Unduh Kode Contoh**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)