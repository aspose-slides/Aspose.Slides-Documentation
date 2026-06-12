---
title: Makro VBA
type: docs
weight: 150
url: /id/cpp/examples/elements/vba-macro/
keywords:
- contoh kode
- VBA
- makro
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Otomatisasi presentasi dengan Aspose.Slides untuk C++: buat, jalankan, impor, dan amankan makro VBA dalam PPT, PPTX, dan ODP menggunakan contoh C++ yang jelas."
---
Artikel ini menunjukkan cara menambah, mengakses, dan menghapus makro VBA menggunakan **Aspose.Slides for C++**.

## **Tambah Makro VBA**

Buat presentasi dengan proyek VBA dan modul makro sederhana.

```cpp
static void AddVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    presentation->Dispose();
}
```

## **Akses Makro VBA**

Ambil modul pertama dari proyek VBA.

```cpp
static void AccessVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    auto firstModule = presentation->get_VbaProject()->get_Module(0);

    presentation->Dispose();
}
```

## **Hapus Makro VBA**

Hapus modul dari proyek VBA.

```cpp
static void RemoveVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    presentation->get_VbaProject()->get_Modules()->Remove(module);

    presentation->Dispose();
}
```