---
title: Transisi Slide
type: docs
weight: 110
url: /id/cpp/examples/elements/slide-transition/
keywords:
- contoh kode
- transisi slide
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Kuasi transisi slide di Aspose.Slides untuk C++: tambahkan, sesuaikan, dan urutkan efek serta durasi dengan contoh C++ untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara menerapkan efek transisi slide dan pengaturan waktu dengan **Aspose.Slides for C++**.

## **Menambahkan Transisi Slide**
Terapkan efek transisi memudar pada slide pertama.

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // Terapkan transisi memudar.
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **Mengakses Transisi Slide**
Baca jenis transisi yang saat ini ditetapkan pada slide.

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // Akses jenis transisi.
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **Menghapus Transisi Slide**
Hapus semua efek transisi dengan mengatur jenisnya ke `None`.

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // Hapus transisi dengan mengatur ke none.
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **Mengatur Durasi Transisi**
Tentukan berapa lama slide ditampilkan sebelum maju secara otomatis.

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // Dalam milidetik.

    presentation->Dispose();
}
```