---
title: Cegah Penyuntingan Presentasi dengan Kunci Shape
linktitle: Cegah Penyuntingan Presentasi
type: docs
weight: 10
url: /id/cpp/applying-protection-to-presentation/
keywords:
- mencegah penyuntingan
- melindungi dari penyuntingan
- kunci shape
- kunci posisi
- kunci pilihan
- kunci ukuran
- kunci pengelompokan
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Temukan cara Aspose.Slides untuk C++ mengunci atau membuka kunci shape dalam file PPT, PPTX, dan ODP, mengamankan presentasi sambil memungkinkan penyuntingan terkontrol dan pengiriman yang lebih cepat."
---
## **Latar Belakang**

Penggunaan umum Aspose.Slides adalah membuat, memperbarui, dan menyimpan presentasi Microsoft PowerPoint (PPTX) sebagai bagian dari alur kerja otomatis. Pengguna aplikasi yang memakai Aspose.Slides dengan cara ini memiliki akses ke presentasi yang dihasilkan, sehingga melindungi mereka dari penyuntingan menjadi keprihatinan umum. Penting agar presentasi yang dihasilkan secara otomatis mempertahankan format dan konten aslinya.

Artikel ini menjelaskan bagaimana presentasi dan slide disusun serta bagaimana Aspose.Slides untuk C++ dapat menerapkan perlindungan pada sebuah presentasi dan kemudian menghapusnya. Artikel ini memberikan pengembang cara mengontrol bagaimana presentasi yang dihasilkan aplikasi mereka digunakan.

## **Komposisi Slide**

Sebuah slide presentasi terdiri dari komponen seperti autoshape, tabel, objek OLE, shape yang dikelompokkan, bingkai gambar, bingkai video, konektor, dan elemen lain yang digunakan untuk membangun presentasi. Dalam Aspose.Slides untuk C++, setiap elemen pada slide direpresentasikan oleh objek yang mengimplementasikan antarmuka [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/) atau mewarisi dari kelas yang melakukannya.

Struktur PPTX bersifat kompleks, sehingga tidak seperti PPT, di mana kunci generik dapat digunakan untuk semua jenis shape, tipe shape yang berbeda memerlukan kunci yang berbeda. Antarmuka [IBaseShapeLock](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseshapelock/) adalah kelas penguncian generik untuk PPTX. Tipe kunci berikut didukung dalam Aspose.Slides untuk C++ untuk PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshapelock/) mengunci autoshape.  
- [IConnectorLock](https://reference.aspose.com/slides/id/cpp/aspose.slides/iconnectorlock/) mengunci shape konektor.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/id/cpp/aspose.slides/igraphicalobjectlock/) mengunci objek grafis.  
- [IGroupShapeLock](https://reference.aspose.com/slides/id/cpp/aspose.slides/igroupshapelock/) mengunci shape grup.  
- [IPictureFrameLock](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframelock/) mengunci bingkai gambar.  

Setiap tindakan yang dilakukan pada semua objek shape dalam objek [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) diterapkan pada seluruh presentasi.

## **Terapkan dan Hapus Perlindungan**

Menerapkan perlindungan memastikan bahwa sebuah presentasi tidak dapat diedit. Ini merupakan teknik yang berguna untuk melindungi konten presentasi.

### **Terapkan Perlindungan pada Shape PPTX**

Aspose.Slides untuk C++ menyediakan antarmuka [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/) untuk bekerja dengan shape pada slide.

Seperti yang disebutkan sebelumnya, setiap kelas shape memiliki kelas shape‑lock yang terkait untuk perlindungan. Artikel ini fokus pada kunci NoSelect, NoMove, dan NoResize. Kunci ini memastikan bahwa shape tidak dapat dipilih (melalui klik mouse atau metode seleksi lainnya) serta tidak dapat dipindahkan atau diubah ukuran.

Contoh kode berikut menerapkan perlindungan pada semua tipe shape dalam sebuah presentasi.

```cpp
// Membuat instance kelas Presentation yang mewakili file PPTX.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Menelusuri semua slide dalam presentasi.
for (auto&& slide : presentation->get_Slides())	{

	// Menelusuri semua shape dalam slide.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Mengubah tipe shape menjadi autoshape dan memperoleh kunci shape-nya.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Mengubah tipe shape menjadi group shape dan memperoleh kunci shape-nya.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Mengubah tipe shape menjadi connector shape dan memperoleh kunci shape-nya.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Mengubah tipe shape menjadi picture frame dan memperoleh kunci shape-nya.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// Menyimpan file presentasi.
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Hapus Perlindungan**

Untuk membuka kunci sebuah shape, setel nilai kunci yang diterapkan menjadi `false`. Contoh kode berikut menunjukkan cara membuka kunci shape dalam presentasi yang terkunci.

```cpp
// Membuat instance kelas Presentation yang mewakili file PPTX.
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// Menelusuri semua slide dalam presentasi.
for (auto&& slide : presentation->get_Slides())	{

	// Menelusuri semua shape dalam slide.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Mengubah tipe shape menjadi autoshape dan memperoleh kunci shape-nya.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Mengubah tipe shape menjadi group shape dan memperoleh kunci shape-nya.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Mengubah tipe shape menjadi connector shape dan memperoleh kunci shape-nya.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Mengubah tipe shape menjadi picture frame dan memperoleh kunci shape-nya.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// Menyimpan file presentasi.
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Kesimpulan**

Aspose.Slides menawarkan beberapa opsi untuk melindungi shape dalam sebuah presentasi. Anda dapat mengunci shape secara individu atau iterasi melalui semua shape dalam presentasi dan mengunci masing‑masing untuk secara efektif mengamankan seluruh file. Anda dapat menghapus perlindungan dengan mengatur nilai kunci menjadi `false`.

## **FAQ**

**Apakah saya dapat menggabungkan kunci shape dan perlindungan kata sandi dalam presentasi yang sama?**

Ya. Kunci membatasi penyuntingan objek di dalam file, sementara [perlindungan kata sandi](/slides/id/cpp/password-protected-presentation/) mengontrol akses untuk membuka dan/atau menyimpan perubahan. Mekanisme ini saling melengkapi dan bekerja bersama.

**Apakah saya dapat membatasi penyuntingan pada slide tertentu tanpa memengaruhi yang lain?**

Ya. Terapkan kunci pada shape di slide yang dipilih; slide yang tersisa tetap dapat diedit.

**Apakah kunci shape diterapkan pada objek yang dikelompokkan dan konektor?**

Ya. Tipe kunci khusus didukung untuk grup, konektor, objek grafis, dan jenis shape lainnya.