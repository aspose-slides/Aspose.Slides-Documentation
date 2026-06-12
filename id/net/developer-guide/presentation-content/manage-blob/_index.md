---
title: Kelola BLOB Presentasi di .NET untuk Penggunaan Memori yang Efisien
linktitle: Kelola BLOB
type: docs
weight: 10
url: /id/net/manage-blob/
keywords:
- objek besar
- item besar
- file besar
- tambahkan BLOB
- ekspor BLOB
- tambahkan gambar sebagai BLOB
- kurangi memori
- konsumsi memori
- presentasi besar
- file sementara
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kelola data BLOB di Aspose.Slides untuk .NET guna mempermudah operasi file PowerPoint dan OpenDocument untuk penanganan presentasi yang efisien."
---
## **Ikhtisar**

Aspose.Slides menyediakan penanganan berbasis BLOB untuk data biner besar dalam presentasi guna membantu mengurangi konsumsi memori saat bekerja dengan gambar, audio, video, dan file presentasi yang besar.

Artikel ini menunjukkan cara menggunakan pemrosesan berbasis BLOB untuk menambahkan media besar ke presentasi, mengekspor media besar dari presentasi, dan memuat presentasi besar dengan lebih efisien. Artikel ini juga menjelaskan cara menggunakan file sementara selama pemrosesan dan cara mengubah folder yang digunakan untuk menyimpannya.

## **Tentang BLOB**

**BLOB** (**Binary Large Object**) biasanya merupakan item besar (foto, presentasi, dokumen, atau media) yang disimpan dalam format biner. 

Aspose.Slides untuk .NET memungkinkan Anda menggunakan BLOB untuk objek dengan cara yang mengurangi konsumsi memori ketika berurusan dengan file berukuran besar. 

## **Gunakan BLOB untuk Mengurangi Konsumsi Memori**

### **Tambahkan File Besar melalui BLOB ke Presentasi**

[Aspose.Slides](/slides/id/net/) untuk .NET memungkinkan Anda menambahkan file besar (dalam hal ini, file video besar) melalui proses yang melibatkan BLOB untuk mengurangi konsumsi memori.

Kode C# berikut menunjukkan cara menambahkan file video besar melalui proses BLOB ke sebuah presentasi:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Membuat presentasi baru yang akan ditambahkan video
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Mari tambahkan video ke presentasi - kami memilih perilaku KeepLocked karena kami
        // tidak bermaksud mengakses file "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Menyimpan presentasi. Saat presentasi besar dihasilkan, konsumsi memori
        // tetap rendah selama siklus hidup objek pres 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```


### **Ekspor File Besar melalui BLOB dari Presentasi**
Aspose.Slides untuk .NET memungkinkan Anda mengekspor file besar (misalnya file audio atau video) melalui proses yang melibatkan BLOB dari presentasi. Sebagai contoh, Anda mungkin perlu mengekstrak file media besar dari sebuah presentasi tetapi tidak ingin file tersebut dimuat ke memori komputer Anda. Dengan mengekspor file melalui proses BLOB, Anda dapat menjaga konsumsi memori tetap rendah. 

Kode C# berikut mendemonstrasikan operasi yang dijelaskan:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Mengunci file sumber dan TIDAK memuatnya ke memori
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Membuat instance Presentation, mengunci file "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Mari simpan setiap video ke file. Untuk mencegah penggunaan memori yang tinggi, kita membutuhkan buffer yang akan digunakan
	// untuk mentransfer data dari aliran video presentasi ke aliran untuk file video yang baru dibuat.
	byte[] buffer = new byte[8 * 1024];

	// Mengiterasi video-video
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Membuka aliran video presentasi. Harap dicatat bahwa kami sengaja menghindari mengakses properti
		// seperti video.BinaryData - karena properti ini mengembalikan array byte yang berisi video lengkap, yang kemudian
		// menyebabkan byte-byte dimuat ke memori. Kami menggunakan video.GetStream, yang akan mengembalikan Stream - dan TIDAK
		//  mengharuskan kami memuat seluruh video ke memori.
		using (Stream presVideoStream = video.GetStream())
		{
			using (FileStream outputFileStream = File.OpenWrite($"video{index}.avi"))
			{
				int bytesRead;
				while ((bytesRead = presVideoStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					outputFileStream.Write(buffer, 0, bytesRead);
				}
			}
		}

		// Konsumsi memori akan tetap rendah terlepas dari ukuran video atau presentasi,
	}

	// Jika diperlukan, Anda dapat menerapkan langkah yang sama untuk file audio. 
}
```

### **Tambahkan Gambar sebagai BLOB ke Presentasi**
Dengan metode dari antarmuka [**IImageCollection**](https://reference.aspose.com/slides/id/net/aspose.slides/iimagecollection) dan kelas [**ImageCollection**](https://reference.aspose.com/slides/id/net/aspose.slides/imagecollection), Anda dapat menambahkan gambar besar sebagai stream sehingga diperlakukan sebagai BLOB. 

Kode C# berikut menunjukkan cara menambahkan gambar besar melalui proses BLOB:

```c#
string pathToLargeImage = "large_image.jpg";

// creates a new presentation to which the image will be added.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Let's add the image to the presentation - we choose KeepLocked behavior because we do
		// NOT intend to access the "largeImage.png" file.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Saves the presentation. While a large presentation gets outputted, the memory consumption 
		// stays low through the pres object's lifecycle
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **Memori dan Presentasi Besar**

Biasanya, untuk memuat presentasi besar, komputer memerlukan banyak memori sementara. Semua konten presentasi dimuat ke dalam memori dan file (yang menjadi sumber presentasi) tidak lagi digunakan. 

Pertimbangkan sebuah presentasi PowerPoint besar (large.pptx) yang berisi file video 1,5 GB. Metode standar untuk memuat presentasi dijelaskan dalam kode C# berikut:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

Namun metode ini mengkonsumsi sekitar 1,6 GB memori sementara. 

### **Muat Presentasi Besar sebagai BLOB**

Melalui proses yang melibatkan BLOB, Anda dapat memuat presentasi besar dengan penggunaan memori yang sedikit. Kode C# berikut menjelaskan implementasi di mana proses BLOB digunakan untuk memuat file presentasi besar (large.pptx):

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true
   }
};
 
using (Presentation pres = new Presentation("large.pptx", loadOptions))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

### **Ubah Folder untuk File Sementara**

Saat proses BLOB digunakan, komputer Anda membuat file sementara di folder default untuk file sementara. Jika Anda ingin file sementara disimpan di folder lain, Anda dapat mengubah pengaturan penyimpanan menggunakan `TempFilesRootPath`:

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true,
       TempFilesRootPath = "temp"
   }
};
```

{{% alert title="Info" color="info" %}}
Ketika Anda menggunakan `TempFilesRootPath`, Aspose.Slides tidak secara otomatis membuat folder untuk menyimpan file sementara. Anda harus membuat folder tersebut secara manual. 
{{% /alert %}}

### **Buang Objek Presentasi untuk Membebaskan Memori**

Saat memproses presentasi besar, pastikan instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) dibuang dengan benar agar memori yang ditempati dapat dilepaskan. Cara yang direkomendasikan adalah dengan menggunakan pernyataan `using` atau deklarasi seperti yang ditunjukkan dalam contoh di atas; secara otomatis akan membuang presentasi dan membebaskan sumber daya tak terkelola ketika blok berakhir.

Jika Anda membuat presentasi tanpa blok `using`, panggil `Dispose()` secara eksplisit setelah selesai menggunakannya.

```cs
Presentation presentation = new Presentation("large.pptx");

// ...proses presentasi...
presentation.Save("large.pdf", SaveFormat.Pdf);

// Lepaskan sumber daya secara eksplisit.
presentation.Dispose();
```

## **FAQ**

**Data apa dalam presentasi Aspose.Slides yang diperlakukan sebagai BLOB dan dikontrol oleh opsi BLOB?**

Objek biner besar seperti gambar, audio, dan video diperlakukan sebagai BLOB. Seluruh file presentasi juga melibatkan penanganan BLOB saat dimuat atau disimpan. Objek-objek ini diatur oleh kebijakan BLOB yang memungkinkan Anda mengelola penggunaan memori dan menumpahkan ke file sementara bila diperlukan.

**Di mana saya mengkonfigurasi aturan penanganan BLOB saat memuat presentasi?**

Gunakan [LoadOptions](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/) dengan [BlobManagementOptions](https://reference.aspose.com/slides/id/net/aspose.slides/blobmanagementoptions/). Di sana Anda dapat menetapkan batas memori dalam untuk BLOB, mengizinkan atau melarang file sementara, memilih jalur root untuk file sementara, dan memilih perilaku penguncian sumber.

**Apakah pengaturan BLOB memengaruhi kinerja, dan bagaimana menyeimbangkan kecepatan vs memori?**

Ya. Menyimpan BLOB di memori memaksimalkan kecepatan tetapi meningkatkan konsumsi RAM; menurunkan batas memori mengalihkan lebih banyak pekerjaan ke file sementara, mengurangi RAM dengan biaya I/O tambahan. Sesuaikan ambang [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/id/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) untuk mencapai keseimbangan yang tepat bagi beban kerja dan lingkungan Anda.

**Apakah opsi BLOB membantu saat membuka presentasi yang sangat besar (misalnya gigabita)?**

Ya. [BlobManagementOptions](https://reference.aspose.com/slides/id/net/aspose.slides/blobmanagementoptions/) dirancang untuk skenario tersebut: mengaktifkan file sementara dan menggunakan penguncian sumber dapat secara signifikan mengurangi penggunaan RAM puncak dan menstabilkan pemrosesan untuk dek yang sangat besar.

**Bisakah saya menggunakan kebijakan BLOB saat memuat dari stream alih-alih file disk?**

Ya. Aturan yang sama berlaku untuk stream: instance presentasi dapat memiliki dan mengunci stream input (tergantung pada mode penguncian yang dipilih), dan file sementara digunakan bila diizinkan, menjaga penggunaan memori tetap dapat diprediksi selama pemrosesan.