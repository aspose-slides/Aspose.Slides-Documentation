---
title: Kelola Proyek VBA dalam Presentasi Menggunakan C++
linktitle: Presentasi via VBA
type: docs
weight: 250
url: /id/cpp/presentation-via-vba/
keywords:
- makro
- VBA
- makro VBA
- tambah makro
- hapus makro
- ekstrak makro
- tambah VBA
- hapus VBA
- ekstrak VBA
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Temukan cara menghasilkan dan memanipulasi presentasi PowerPoint dan OpenDocument via VBA dengan Aspose.Slides untuk C++ guna memperlancar alur kerja Anda."
---
## **Pendahuluan**

Namespace [Aspose.Slides.Vba](https://reference.aspose.com/slides/id/cpp/namespace/aspose.slides.vba/) berisi kelas dan antarmuka untuk bekerja dengan makro dan kode VBA.

{{% alert title="Note" color="warning" %}} 
Saat Anda mengonversi presentasi yang berisi makro ke format file lain (PDF, HTML, dll.), Aspose.Slides mengabaikan semua makro (makro tidak dibawa ke file hasil).

Saat Anda menambahkan makro ke presentasi atau menyimpan ulang presentasi yang berisi makro, Aspose.Slides hanya menulis byte-byte untuk makro tersebut.

Aspose.Slides **tidak pernah** menjalankan makro dalam sebuah presentasi.
{{% /alert %}}

## **Tambahkan Makro VBA**

Aspose.Slides menyediakan kelas [VbaProject](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.vba.vba_project) yang memungkinkan Anda membuat proyek VBA (dan referensi proyek) serta mengedit modul yang ada. Anda dapat menggunakan antarmuka [IVbaProject](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.vba.i_vba_project/) untuk mengelola VBA yang tertanam dalam sebuah presentasi.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
1. Gunakan konstruktor [VbaProject](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) untuk menambahkan proyek VBA baru.
1. Tambahkan modul ke VbaProject.
1. Tetapkan kode sumber modul.
1. Tambahkan referensi ke <stdole>.
1. Tambahkan referensi ke **Microsoft Office**.
1. Hubungkan referensi dengan proyek VBA.
1. Simpan presentasi.

Kode C++ ini menunjukkan cara menambahkan makro VBA dari awal ke sebuah presentasi: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaReferenceCollection.h>
#include <DOM/Vba/VbaProject.h>
#include <DOM/Vba/VbaReferenceOleTypeLib.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Vba;
using namespace System;

// Jalur ke direktori dokumen.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Membuat instance dari kelas presentasi
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Membuat Proyek VBA baru
presentation->set_VbaProject(MakeObject<VbaProject>());

// Menambahkan modul kosong ke proyek VBA
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Menetapkan kode sumber modul
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// Membuat referensi ke <stdole>
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Membuat referensi ke Office
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Menambahkan referensi ke proyek VBA
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Menyimpan Presentasi
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="info" %}} 
Anda mungkin ingin mencoba **Aspose** [Macro Remover](https://products.aspose.app/slides/id/remove-macros), sebuah aplikasi web gratis yang digunakan untuk menghapus makro dari dokumen PowerPoint, Excel, dan Word. 
{{% /alert %}} 

## **Hapus Makro VBA**

Dengan menggunakan properti [VbaProject](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) pada kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation), Anda dapat menghapus makro VBA.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation) dan muat presentasi yang berisi makro.
1. Akses modul Makro dan hapus.
1. Simpan presentasi yang telah dimodifikasi.

Kode C++ ini menunjukkan cara menghapus makro VBA: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

// Jalur ke direktori dokumen.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Memuat presentasi yang berisi makro
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Mengakses modul Vba dan menghapusnya
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Menyimpan Presentasi
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **Ekstrak Makro VBA**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation) dan muat presentasi yang berisi makro.
2. Periksa apakah presentasi berisi Proyek VBA.
3. Loop melalui semua modul yang terdapat dalam Proyek VBA untuk melihat makro.

Kode C++ ini menunjukkan cara mengekstrak makro VBA dari presentasi yang berisi makro: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

	// Jalur ke direktori dokumen.
	const String templatePath = u"../templates/VBA.pptm";

	// Memuat presentasi yang berisi makro
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // Memeriksa apakah Presentasi berisi Proyek VBA
	{
		
		//for (SharedPtr<IVbaModule> module : pres->get_VbaProject()->get_Modules())
		for (int i = 0; i < pres->get_VbaProject()->get_Modules()->get_Count(); i++)
		{
			SharedPtr<IVbaModule> module = pres->get_VbaProject()->get_Modules()->idx_get(i);

			System::Console::WriteLine(module->get_Name());
			System::Console::WriteLine(module->get_SourceCode());
		}
	}
```

## **Periksa Apakah Proyek VBA Dilindungi Kata Sandi**

Dengan menggunakan properti [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/id/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) , Anda dapat menentukan apakah properti proyek dilindungi kata sandi.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) dan muat presentasi yang berisi makro.
2. Periksa apakah presentasi berisi [proyek VBA](https://reference.aspose.com/slides/id/cpp/aspose.slides.vba/vbaproject/).
3. Periksa apakah proyek VBA dilindungi kata sandi untuk melihat propertinya.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Memeriksa apakah presentasi berisi proyek VBA.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **FAQ**

### Apa yang terjadi pada makro jika saya menyimpan presentasi sebagai PPTX?

Makro akan dihapus karena PPTX tidak mendukung VBA. Untuk mempertahankan makro, pilih PPTM, PPSM, atau POTM.

### Apakah Aspose.Slides dapat menjalankan makro di dalam presentasi untuk, misalnya, memperbarui data?

Tidak. Perpustakaan ini tidak pernah mengeksekusi kode VBA; eksekusi hanya memungkinkan di dalam PowerPoint dengan pengaturan keamanan yang sesuai.

### Apakah bekerja dengan kontrol ActiveX yang terhubung ke kode VBA didukung?

Ya, Anda dapat mengakses [kontrol ActiveX](/slides/id/cpp/activex/), memodifikasi propertinya, dan menghapusnya. Hal ini berguna ketika makro berinteraksi dengan ActiveX.