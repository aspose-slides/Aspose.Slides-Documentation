---
title: ActiveX
type: docs
weight: 200
url: /id/python-net/examples/elements/activex/
keywords:
- ActiveX
- kontrol ActiveX
- menambahkan ActiveX
- mengakses ActiveX
- menghapus ActiveX
- properti ActiveX
- contoh kode
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara menemukan, mengedit, dan menghapus kontrol ActiveX di Python dengan Aspose.Slides, termasuk pembaruan properti untuk presentasi PowerPoint."
---
Menunjukkan cara menambahkan, mengakses, menghapus, dan mengonfigurasi kontrol ActiveX dalam sebuah presentasi menggunakan **Aspose.Slides for Python via .NET**.

## **Add an ActiveX Control**
Menyisipkan kontrol ActiveX baru.

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Tambahkan kontrol ActiveX baru (TextBox).
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **Access an ActiveX Control**
Membaca informasi dari kontrol ActiveX pertama pada slide.

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Akses kontrol ActiveX pertama.
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # Cetak nama kontrol.
            print(f"Control Name: {control.name}")
```

## **Remove an ActiveX Control**
Menghapus kontrol ActiveX yang ada dari slide.

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # Hapus kontrol ActiveX pertama.
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **Set ActiveX Properties**
Mengonfigurasi beberapa properti ActiveX.

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Mengasumsikan koleksi Control berisi setidaknya satu Control.
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```