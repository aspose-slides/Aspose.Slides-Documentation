---
title: ActiveX
type: docs
weight: 200
url: /id/net/examples/elements/activex/
keywords:
- ActiveX
- tambahkan ActiveX
- akses ActiveX
- hapus ActiveX
- Properti ActiveX
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Lihat contoh ActiveX Aspose.Slides untuk .NET: sisipkan, konfigurasikan, dan kontrol objek ActiveX dalam presentasi PPT dan PPTX dengan kode C# yang jelas."
---
Artikel ini menunjukkan cara menambahkan, mengakses, menghapus, dan mengonfigurasi kontrol ActiveX dalam sebuah presentasi menggunakan **Aspose.Slides for .NET**.

## **Menambahkan Kontrol ActiveX**

Menyisipkan kontrol ActiveX baru dan secara opsional mengatur propertinya.

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Tambahkan kontrol ActiveX baru.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // Secara opsional atur beberapa properti.
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **Mengakses Kontrol ActiveX**

Membaca informasi dari kontrol ActiveX pertama pada slide.

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // Akses kontrol ActiveX pertama.
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **Menghapus Kontrol ActiveX**

Menghapus kontrol ActiveX yang ada dari slide.

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // Hapus kontrol ActiveX pertama.
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **Mengatur Properti ActiveX**

Menambahkan kontrol dan mengonfigurasi beberapa properti ActiveX.

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Tambahkan CommandButton dan konfigurasikan properti.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```