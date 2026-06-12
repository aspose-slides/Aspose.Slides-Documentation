---
title: Mengelola Proyek VBA dalam Presentasi Menggunakan C++
linktitle: Presentasi melalui VBA
type: docs
weight: 250
url: /id/cpp/presentation-via-vba/
keywords:
- makro
- VBA
- makro VBA
- menambahkan makro
- menghapus makro
- mengekstrak makro
- menambahkan VBA
- menghapus VBA
- mengekstrak VBA
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Temukan cara membuat dan memanipulasi presentasi PowerPoint dan OpenDocument melalui VBA dengan Aspose.Slides untuk C++ guna menyederhanakan alur kerja Anda."
---
## **Pendahuluan**

Namespace [Aspose.Slides.Vba](https://reference.aspose.com/slides/id/cpp/namespace/aspose.slides.vba/) berisi kelas dan antarmuka untuk bekerja dengan makro dan kode VBA.

{{% alert title="Catatan" color="warning" %}} 
Saat Anda mengonversi presentasi yang berisi makro ke format file yang berbeda (PDF, HTML, dll.), Aspose.Slides mengabaikan semua makro (makro tidak dibawa ke dalam file hasil).

Saat Anda menambahkan makro ke presentasi atau menyimpan ulang presentasi yang berisi makro, Aspose.Slides hanya menulis byte untuk makro.

Aspose.Slides **tidak pernah** menjalankan makro dalam presentasi.
{{% /alert %}}

## **Menambahkan Makro VBA**

Aspose.Slides menyediakan kelas [VbaProject](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.vba.vba_project) untuk memungkinkan Anda membuat proyek VBA (dan referensi proyek) serta mengedit modul yang ada. Anda dapat menggunakan antarmuka [IVbaProject](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.vba.i_vba_project/) untuk mengelola VBA yang tertanam dalam presentasi.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
1. Gunakan konstruktor [VbaProject](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) untuk menambahkan proyek VBA baru.
1. Tambahkan modul ke VbaProject.
1. Atur kode sumber modul.
1. Tambahkan referensi ke <stdole>.
1. Tambahkan referensi ke **Microsoft Office**.
1. Hubungkan referensi dengan proyek VBA.
1. Simpan presentasi.

Kode C++ ini menunjukkan cara menambahkan makro VBA dari awal ke sebuah presentasi: 

```c++
// Jalur ke direktori dokumen.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Membuat instance kelas presentasi
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Membuat Proyek VBA baru
presentation->set_VbaProject(MakeObject<VbaProject>());

// Menambahkan modul kosong ke proyek VBA
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Mengatur kode sumber modul
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

{{% alert color="primary" %}} 
Anda mungkin ingin melihat **Aspose** [Macro Remover](https://products.aspose.app/slides/id/remove-macros), yang merupakan aplikasi web gratis untuk menghapus makro dari dokumen PowerPoint, Excel, dan Word. 
{{% /alert %}} 

## **Menghapus Makro VBA**

Dengan menggunakan properti [VbaProject](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) di bawah kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation), Anda dapat menghapus makro VBA.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation) dan muat presentasi yang berisi makro.
1. Akses modul Macro dan hapus.
1. Simpan presentasi yang telah dimodifikasi.

Kode C++ ini menunjukkan cara menghapus makro VBA: 

```c++
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

## **Mengekstrak Makro VBA**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation) dan muat presentasi yang berisi makro.
2. Periksa apakah presentasi berisi Proyek VBA.
3. Iterasikan semua modul yang terdapat dalam Proyek VBA untuk melihat makro.

Kode C++ ini menunjukkan cara mengekstrak makro VBA dari sebuah presentasi yang berisi makro: 

```c++

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

## **Memeriksa Apakah Proyek VBA Dilindungi Kata Sandi**

Dengan menggunakan properti [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/id/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) Anda dapat menentukan apakah properti proyek dilindungi kata sandi.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) dan muat presentasi yang berisi makro.
2. Periksa apakah presentasi berisi [VBA project](https://reference.aspose.com/slides/id/cpp/aspose.slides.vba/vbaproject/).
3. Periksa apakah proyek VBA dilindungi kata sandi untuk melihat propertinya.

```cpp
auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Periksa apakah presentasi berisi proyek VBA.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **FAQ**

**Apa yang terjadi pada makro jika saya menyimpan presentasi sebagai PPTX?**

Makro akan dihapus karena PPTX tidak mendukung VBA. Untuk mempertahankan makro, pilih PPTM, PPSM, atau POTM.

**Apakah Aspose.Slides dapat menjalankan makro di dalam presentasi untuk, misalnya, memperbarui data?**

Tidak. Perpustakaan tidak pernah mengeksekusi kode VBA; eksekusi hanya dimungkinkan di dalam PowerPoint dengan pengaturan keamanan yang sesuai.

**Apakah bekerja dengan kontrol ActiveX yang terhubung ke kode VBA didukung?**

Ya, Anda dapat mengakses [ActiveX controls](/slides/id/cpp/activex/), mengubah propertinya, dan menghapusnya. Ini berguna ketika makro berinteraksi dengan ActiveX.