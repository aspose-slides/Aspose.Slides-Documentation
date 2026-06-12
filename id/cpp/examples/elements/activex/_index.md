---
title: ActiveX
type: docs
weight: 200
url: /id/cpp/examples/elements/activex/
keywords:
- contoh kode
- ActiveX
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Lihat contoh ActiveX Aspose.Slides for C++: menyisipkan, mengkonfigurasi, dan mengontrol objek ActiveX dalam presentasi PPT dan PPTX dengan kode C++ yang jelas."
---
Artikel ini menunjukkan cara menambahkan, mengakses, menghapus, dan mengkonfigurasi kontrol ActiveX dalam presentasi menggunakan **Aspose.Slides for C++**.

## **Menambahkan Kontrol ActiveX**

Menyisipkan kontrol ActiveX baru dan secara opsional mengatur propertinya.

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Tambah kontrol ActiveX baru.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // Atur beberapa properti secara opsional.
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Mengakses Kontrol ActiveX**

Membaca informasi dari kontrol ActiveX pertama pada slide.

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Akses kontrol ActiveX pertama.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **Menghapus Kontrol ActiveX**

Menghapus kontrol ActiveX yang ada dari slide.

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Hapus kontrol ActiveX pertama.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Mengatur Properti ActiveX**

Menambahkan kontrol dan mengkonfigurasi beberapa properti ActiveX.

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Tambah kontrol Windows Media Player dan konfigurasikan properti.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```