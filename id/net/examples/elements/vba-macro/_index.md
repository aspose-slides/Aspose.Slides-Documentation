---
title: Makro VBA
type: docs
weight: 150
url: /id/net/examples/elements/vba-macro/
keywords:
- makro VBA
- menambahkan makro VBA
- mengakses makro VBA
- menghapus makro VBA
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Otomatisasi presentasi dengan Aspose.Slides untuk .NET: buat, jalankan, impor, dan amankan makro VBA dalam PPT, PPTX, dan ODP menggunakan contoh C# yang jelas."
---
Artikel ini menunjukkan cara menambahkan, mengakses, dan menghapus makro VBA menggunakan **Aspose.Slides for .NET**.

## **Menambahkan Makro VBA**

Buat presentasi dengan proyek VBA dan modul makro sederhana.

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **Mengakses Makro VBA**

Ambil modul pertama dari proyek VBA.

```csharp
static void AccessVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    var firstModule = presentation.VbaProject.Modules[0];
}
```

## **Menghapus Makro VBA**

Hapus modul dari proyek VBA.

```csharp
static void RemoveVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    presentation.VbaProject.Modules.Remove(module);
}
```