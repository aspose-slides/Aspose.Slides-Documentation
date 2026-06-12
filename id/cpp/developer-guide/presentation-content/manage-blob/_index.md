---
title: Kelola BLOB Presentasi di C++ untuk Penggunaan Memori yang Efisien
linktitle: Kelola BLOB
type: docs
weight: 10
url: /id/cpp/manage-blob/
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
- C++
- Aspose.Slides
description: "Kelola data BLOB di Aspose.Slides untuk C++ guna mempermudah operasi file PowerPoint dan OpenDocument untuk penanganan presentasi yang efisien."
---
## **Gambaran Umum**

Aspose.Slides menyediakan penanganan berbasis BLOB untuk data biner besar dalam presentasi guna membantu mengurangi konsumsi memori saat bekerja dengan gambar, audio, video, dan file presentasi berukuran besar.

Artikel ini menunjukkan cara menggunakan pemrosesan berbasis BLOB untuk menambahkan media besar ke presentasi, mengekspor media besar dari presentasi, dan memuat presentasi besar dengan lebih efisien. Artikel ini juga menjelaskan cara menggunakan file sementara selama pemrosesan dan cara mengubah folder yang digunakan untuk menyimpannya.

## **Tentang BLOB**

**BLOB** (**Binary Large Object**) biasanya merupakan item besar (foto, presentasi, dokumen, atau media) yang disimpan dalam format biner.

Aspose.Slides for C++ memungkinkan Anda menggunakan BLOB untuk objek dengan cara yang mengurangi konsumsi memori ketika file besar terlibat.

## **Gunakan BLOB untuk Mengurangi Konsumsi Memori**

### **Tambahkan File Besar melalui BLOB ke Presentasi**

[Aspose.Slides](/slides/id/cpp/) for C++ memungkinkan Anda menambahkan file besar (dalam hal ini, file video besar) melalui proses yang melibatkan BLOB untuk mengurangi konsumsi memori.

Kode C++ berikut menunjukkan cara menambahkan file video besar melalui proses BLOB ke presentasi:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Membuat presentasi baru yang akan ditambahkan video
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Tambahkan video ke presentasi - kami memilih perilaku KeepLocked karena kami
// tidak bermaksud mengakses file "veryLargeVideo.avi".
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Menyimpan presentasi. Saat presentasi besar dihasilkan, konsumsi memori
// tetap rendah selama siklus hidup objek pres 
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **Ekspor File Besar melalui BLOB dari Presentasi**
Aspose.Slides for C++ memungkinkan Anda mengekspor file besar (misalnya, file audio atau video) melalui proses yang melibatkan BLOB dari presentasi. Misalnya, Anda mungkin perlu mengekstrak file media besar dari presentasi tetapi tidak ingin file tersebut dimuat ke memori komputer Anda. Dengan mengekspor file melalui proses BLOB, Anda dapat menjaga konsumsi memori tetap rendah.

Kode C++ berikut mendemonstrasikan operasi yang dijelaskan:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Membuat instance Presentation, mengunci file "hugePresentationWithAudiosAndVideos.pptx".

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Mari simpan setiap video ke file. Untuk mencegah penggunaan memori yang tinggi, kita memerlukan buffer yang akan digunakan
// untuk mentransfer data dari aliran video presentasi ke aliran untuk file video yang baru dibuat.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Mengiterasi video-video
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Membuka aliran video presentasi. Harap dicatat bahwa kami dengan sengaja menghindari mengakses metode
	// seperti video->get_BinaryData - karena metode ini mengembalikan array byte yang berisi video lengkap, yang kemudian
	// menyebabkan byte-byte dimuat ke memori. Kami menggunakan video->GetStream, yang akan mengembalikan Stream - dan TIDAK
	// memerlukan kami untuk memuat seluruh video ke memori.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// Konsumsi memori akan tetap rendah terlepas dari ukuran video atau presentasi,
}

// Jika diperlukan, Anda dapat menerapkan langkah yang sama untuk file audio.
```

### **Tambahkan Gambar sebagai BLOB ke Presentasi**
Dengan metode dari antarmuka [**IImageCollection**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_image_collection) dan kelas [**ImageCollection**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.image_collection), Anda dapat menambahkan gambar besar sebagai aliran sehingga diperlakukan sebagai BLOB.

Kode C++ berikut menunjukkan cara menambahkan gambar besar melalui proses BLOB:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// membuat presentasi baru yang akan ditambahkan gambar.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Mari tambahkan gambar ke presentasi - kami memilih perilaku KeepLocked karena kami
// TIDAK berniat mengakses file "largeImage.png" file.
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Menyimpan presentasi. Saat presentasi besar dihasilkan, konsumsi memori 
// tetap rendah selama siklus hidup objek pres
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **Memori dan Presentasi Besar**

Biasanya, untuk memuat presentasi besar, komputer memerlukan banyak memori sementara. Semua konten presentasi dimuat ke memori dan file (dari mana presentasi dimuat) tidak lagi digunakan.

Pertimbangkan presentasi PowerPoint besar (large.pptx) yang berisi file video 1,5 GB. Metode standar untuk memuat presentasi dijelaskan dalam kode C++ berikut:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

Namun metode ini mengonsumsi sekitar 1,6 GB memori sementara.

### **Muat Presentasi Besar sebagai BLOB**

Melalui proses yang melibatkan BLOB, Anda dapat memuat presentasi besar sambil menggunakan sedikit memori. Kode C++ berikut menjelaskan implementasi di mana proses BLOB digunakan untuk memuat file presentasi besar (large.pptx):

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **Ubah Folder untuk File Sementara**

Ketika proses BLOB digunakan, komputer Anda membuat file sementara di folder default untuk file sementara. Jika Anda ingin file sementara disimpan di folder lain, Anda dapat mengubah pengaturan penyimpanan menggunakan `TempFilesRootPath`:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
Saat Anda menggunakan `TempFilesRootPath`, Aspose.Slides tidak secara otomatis membuat folder untuk menyimpan file sementara. Anda harus membuat folder tersebut secara manual.
{{% /alert %}}

### **Buang Objek Presentasi untuk Membebaskan Memori**

Saat memproses presentasi besar, pastikan instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) dibuang dengan benar sehingga memori yang ditempati dilepaskan. Panggil `Dispose()` setelah selesai menggunakan presentasi untuk membebaskan sumber daya yang tidak dikelola.

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...proses presentasi...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// Bebaskan sumber daya secara eksplisit.
presentation->Dispose();
```

## **FAQ**

**Data apa dalam presentasi Aspose.Slides yang diperlakukan sebagai BLOB dan dikendalikan oleh opsi BLOB?**  
Objek biner besar seperti gambar, audio, dan video diperlakukan sebagai BLOB. Seluruh file presentasi juga melibatkan penanganan BLOB ketika dimuat atau disimpan. Objek‑objek ini diatur oleh kebijakan BLOB yang memungkinkan Anda mengelola penggunaan memori dan menumpahkan ke file sementara bila diperlukan.

**Di mana saya mengonfigurasi aturan penanganan BLOB saat memuat presentasi?**  
Gunakan [LoadOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/) dengan [BlobManagementOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/blobmanagementoptions/). Di sana Anda menetapkan batas memori dalam untuk BLOB, mengizinkan atau melarang file sementara, memilih jalur akar untuk file sementara, dan memilih perilaku penguncian sumber.

**Apakah pengaturan BLOB memengaruhi kinerja, dan bagaimana menyeimbangkan kecepatan vs memori?**  
Ya. Menyimpan BLOB di memori memaksimalkan kecepatan tetapi meningkatkan konsumsi RAM; menurunkan batas memori memindahkan lebih banyak pekerjaan ke file sementara, mengurangi RAM dengan biaya I/O tambahan. Gunakan metode [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/id/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) untuk menemukan keseimbangan yang tepat bagi beban kerja dan lingkungan Anda.

**Apakah opsi BLOB membantu saat membuka presentasi yang sangat besar (misalnya gigabyte)?**  
Ya. [BlobManagementOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/blobmanagementoptions/) dirancang untuk skenario tersebut: mengaktifkan file sementara dan menggunakan penguncian sumber dapat secara signifikan mengurangi penggunaan RAM puncak dan menstabilkan pemrosesan untuk dek yang sangat besar.

**Bisakah saya menggunakan kebijakan BLOB saat memuat dari aliran alih‑alih file disk?**  
Ya. Aturan yang sama berlaku untuk aliran: instance presentasi dapat memiliki dan mengunci aliran input (tergantung pada mode penguncian yang dipilih), dan file sementara digunakan bila diizinkan, sehingga penggunaan memori tetap dapat diprediksi selama pemrosesan.