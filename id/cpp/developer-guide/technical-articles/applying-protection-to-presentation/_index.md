---
title: Batasi Penyuntingan Presentasi dengan Kunci Bentuk di C++
linktitle: Batasi Penyuntingan Presentasi
type: docs
weight: 10
url: /id/cpp/applying-protection-to-presentation/
keywords:
- mencegah penyuntingan
- melindungi dari penyuntingan
- kunci bentuk
- kunci posisi
- kunci pemilihan
- kunci mengubah ukuran
- kunci pengelompokan
- PowerPoint
- PPTX
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara mengunci dan membuka kunci bentuk dalam presentasi PPTX dengan Aspose.Slides untuk C++ untuk membatasi pemilihan, pergerakan, pengubahan ukuran, dan pengelompokan."
---
## **Latar Belakang**

Penggunaan umum Aspose.Slides for C++ adalah membuat, memperbarui, dan menyimpan presentasi PowerPoint (PPTX) sebagai bagian dari alur kerja otomatis. Ketika pengguna menerima presentasi ini, membatasi perubahan pada bentuk dapat membantu mempertahankan tata letak dan konten yang dimaksud.

Artikel ini menjelaskan bagaimana bentuk diatur pada slide dan cara menerapkan serta menghapus kunci bentuk dalam presentasi PPTX. Kunci ini memungkinkan Anda membatasi operasi penyuntingan tertentu pada bentuk individual.

## **Komposisi Slide**

Sebuah slide presentasi terdiri dari komponen seperti autoshape, tabel, objek OLE, bentuk yang dikelompokkan, bingkai gambar, bingkai video, connector, dan elemen lain yang digunakan untuk membangun presentasi. Dalam Aspose.Slides for C++, setiap elemen pada slide diwakili oleh objek yang mengimplementasikan antarmuka [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) atau mewarisi dari kelas yang melakukannya.

Berbagai jenis bentuk menawarkan opsi penguncian yang berbeda. Antarmuka [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) adalah antarmuka dasar untuk kunci bentuk. Aspose.Slides for C++ menyediakan antarmuka kunci berikut:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) mengunci autoshape.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) mengunci bentuk connector.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) mengunci objek grafis.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) mengunci bentuk grup.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) mengunci bingkai gambar.

Untuk menerapkan kunci pada seluruh [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), iterasi melalui slide‑slidenya dan tetapkan kunci yang sesuai pada setiap bentuk yang didukung.

## **Terapkan dan Hapus Perlindungan**

Kunci bentuk membatasi operasi seperti memilih, memindahkan, dan mengubah ukuran bentuk. Mereka tidak membuat seluruh presentasi tidak dapat disunting.

### **Terapkan Perlindungan pada Bentuk PPTX**

Aspose.Slides for C++ menyediakan antarmuka [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) untuk bekerja dengan bentuk pada sebuah slide.

Contoh ini mengirimkan `true` ke [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/), dan [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) untuk autoshape, dengan kunci yang setara untuk bentuk grup, connector, dan bingkai gambar. Connector menggunakan [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) untuk pergerakan; grup juga menggunakan [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) untuk membatasi pengelompokan.

Contoh ini memuat presentasi PPTX yang ada, memeriksa bentuk‑bentuk dalam koleksi bentuk tiap slide, dan menyimpan salinan dengan pembatasan ini diterapkan. Bentuk di luar empat tipe yang ditangani dibiarkan tidak berubah. Loop tidak menelusuri bentuk anak dalam sebuah grup.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(true);
            autoShapeLock->set_SelectLocked(true);
            autoShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(true);
            groupShapeLock->set_PositionLocked(true);
            groupShapeLock->set_SelectLocked(true);
            groupShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(true);
            connectorShapeLock->set_SelectLocked(true);
            connectorShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(true);
            pictureFrameLock->set_SelectLocked(true);
            pictureFrameLock->set_SizeLocked(true);
        }
    }
}

presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Hapus Perlindungan**

Untuk menghapus kunci bentuk, atur nilainya menjadi `false`. Contoh berikut memuat presentasi dengan kunci bentuk dan menghapus pembatasan pemilihan, pergerakan, dan pengubahan ukuran melalui [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/), dan [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/). Juga menghapus [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) dan menyimpan salinan presentasi. Pengaturan kunci lain dibiarkan tidak berubah.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(false);
            autoShapeLock->set_SelectLocked(false);
            autoShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(false);
            groupShapeLock->set_PositionLocked(false);
            groupShapeLock->set_SelectLocked(false);
            groupShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(false);
            connectorShapeLock->set_SelectLocked(false);
            connectorShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(false);
            pictureFrameLock->set_SelectLocked(false);
            pictureFrameLock->set_SizeLocked(false);
        }
    }
}

presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Kesimpulan**

Aspose.Slides for C++ memungkinkan Anda membatasi operasi penyuntingan tertentu pada bentuk individual atau menerapkan pembatasan yang sama di seluruh slide. Pilih kunci yang didukung oleh setiap tipe bentuk, dan atur nilainya menjadi `false` ketika Anda perlu menghapus pembatasan tersebut.

## **FAQ**

**Apakah saya dapat menggabungkan kunci bentuk dan perlindungan sandi dalam presentasi yang sama?**

Ya. Kunci bentuk membatasi operasi penyuntingan tertentu, sementara [perlindungan kata sandi](/slides/id/cpp/password-protected-presentation/) dapat membatasi pembukaan atau modifikasi presentasi. Anda dapat menggunakan keduanya dalam file yang sama.

**Apakah saya dapat membatasi penyuntingan pada slide tertentu tanpa memengaruhi yang lain?**

Ya. Terapkan kunci hanya pada bentuk di slide yang dipilih. Ini tidak mengubah pengaturan kunci pada slide lain.

**Bagaimana saya dapat menerapkan kunci pada bentuk individual di dalam grup?**

Iterasikan melalui koleksi yang dikembalikan oleh metode [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) grup dan terapkan kunci yang sesuai pada setiap bentuk anak. Ulangi ini untuk setiap grup bersarang. Contoh di atas memproses hanya koleksi bentuk slide, sehingga mereka tidak menetapkan kunci pada anggota grup individual.