---
title: Kelola Proyek VBA dalam Presentasi di .NET
linktitle: Presentasi via VBA
type: docs
weight: 250
url: /id/net/presentation-via-vba/
keywords:
- makro
- VBA
- makro VBA
- tambahkan makro
- hapus makro
- ekstrak makro
- tambahkan VBA
- hapus VBA
- ekstrak VBA
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Temukan cara menghasilkan dan memanipulasi presentasi PowerPoint dan OpenDocument melalui VBA dengan Aspose.Slides untuk .NET guna menyederhanakan alur kerja Anda."
---
## **Pendahuluan**

Namespace [Aspose.Slides.Vba](https://reference.aspose.com/slides/id/net/aspose.slides.vba/) berisi kelas dan antarmuka untuk bekerja dengan makro dan kode VBA.

{{% alert title="Catatan" color="warning" %}} 

Saat Anda mengonversi presentasi yang berisi makro ke format file lain (PDF, HTML, dll.), Aspose.Slides mengabaikan semua makro (makro tidak dibawa ke file hasil).

Ketika Anda menambahkan makro ke presentasi atau menyimpan ulang presentasi yang berisi makro, Aspose.Slides hanya menulis byte makro.

Aspose.Slides **tidak pernah** menjalankan makro dalam sebuah presentasi.

{{% /alert %}}

## **Menambahkan Makro VBA**

Aspose.Slides menyediakan kelas [VbaProject](https://reference.aspose.com/slides/id/net/aspose.slides.vba/vbaproject/) untuk memungkinkan Anda membuat proyek VBA (dan referensi proyek) serta mengedit modul yang ada. Anda dapat menggunakan antarmuka [IVbaProject](https://reference.aspose.com/slides/id/net/aspose.slides.vba/ivbaproject/) untuk mengelola VBA yang tertanam dalam sebuah presentasi.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
1. Gunakan konstruktor [VbaProject](https://reference.aspose.com/slides/id/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) untuk menambahkan proyek VBA baru.
1. Tambahkan modul ke VbaProject.
1. Atur kode sumber modul.
1. Tambahkan referensi ke <stdole>.
1. Tambahkan referensi ke **Microsoft Office**.
1. Hubungkan referensi tersebut dengan proyek VBA.
1. Simpan presentasi.

Kode C# berikut menunjukkan cara menambahkan makro VBA dari awal ke sebuah presentasi:

```c#
    // Membuat instance dari kelas presentasi
using (Presentation presentation = new Presentation())
{
    // Membuat Proyek VBA baru
    presentation.VbaProject = new VbaProject();

    // Menambahkan modul kosong ke proyek VBA
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // Menetapkan kode sumber modul
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Membuat referensi ke <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Membuat referensi ke Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Menambahkan referensi ke proyek VBA
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // Menyimpan Presentasi
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 

Anda mungkin ingin melihat **Aspose** [Macro Remover](https://products.aspose.app/slides/id/remove-macros), yaitu aplikasi web gratis yang digunakan untuk menghapus makro dari dokumen PowerPoint, Excel, dan Word. 

{{% /alert %}} 

## **Menghapus Makro VBA**
Dengan menggunakan properti [VbaProject](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/vbaproject/) pada kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/), Anda dapat menghapus makro VBA.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) dan muat presentasi yang berisi makro.
1. Akses modul Macro dan hapus.
1. Simpan presentasi yang telah dimodifikasi.

Kode C# berikut menunjukkan cara menghapus makro VBA:

```c#
    // Memuat presentasi yang berisi makro
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Mengakses modul Vba dan menghapusnya 
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Menyimpan Presentasi
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **Mengekstrak Makro VBA**
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) dan muat presentasi yang berisi makro.
2. Periksa apakah presentasi mengandung Proyek VBA.
3. Iterasi semua modul yang ada dalam Proyek VBA untuk melihat makro.

Kode C# berikut menunjukkan cara mengekstrak makro VBA dari presentasi yang berisi makro:

```c#
    // Memuat presentasi yang berisi makro
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Memeriksa apakah Presentasi berisi Proyek VBA
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **Memeriksa Apakah Proyek VBA Dilindungi Kata Sandi**

Dengan menggunakan properti [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/id/net/aspose.slides.vba/ivbaproject/ispasswordprotected/), Anda dapat menentukan apakah properti sebuah proyek dilindungi kata sandi.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) dan muat presentasi yang berisi makro.
2. Periksa apakah presentasi mengandung [proyek VBA](https://reference.aspose.com/slides/id/net/aspose.slides.vba/vbaproject/).
3. Periksa apakah proyek VBA dilindungi kata sandi untuk melihat propertinya.

```cs
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Periksa apakah presentasi berisi proyek VBA.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **FAQ**

**Apa yang terjadi pada makro jika saya menyimpan presentasi sebagai PPTX?**

Makro akan dihapus karena PPTX tidak mendukung VBA. Untuk mempertahankan makro, pilih PPTM, PPSM, atau POTM.

**Apakah Aspose.Slides dapat menjalankan makro di dalam presentasi, misalnya untuk menyegarkan data?**

Tidak. Perpustakaan ini tidak pernah mengeksekusi kode VBA; eksekusi hanya dapat dilakukan di dalam PowerPoint dengan pengaturan keamanan yang sesuai.

**Apakah bekerja dengan kontrol ActiveX yang terhubung ke kode VBA didukung?**

Ya, Anda dapat mengakses [kontrol ActiveX](/slides/id/net/activex/) yang ada, mengubah propertinya, dan menghapusnya. Hal ini berguna ketika makro berinteraksi dengan ActiveX.