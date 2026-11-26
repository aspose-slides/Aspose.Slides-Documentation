---
title: Kelola Kontrol ActiveX dalam Presentasi Menggunakan C++
linktitle: ActiveX
type: docs
weight: 80
url: /id/cpp/activex/
keywords:
- ActiveX
- kontrol ActiveX
- kelola ActiveX
- tambahkan ActiveX
- modifikasi ActiveX
- pemutar media
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Edit kotak teks dan tombol ActiveX, perbarui pratinjau kontrol, serta gunakan kembali kontrol Windows Media Player dalam presentasi PowerPoint dengan Aspose.Slides untuk C++."
---
## **Pendahuluan**

Kontrol ActiveX memberikan slide PowerPoint elemen interaktif seperti kotak teks, tombol perintah, dan pemutar media. Aspose.Slides untuk C++ mengekspos kontrol slide melalui [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/). Gunakan koleksi ini untuk menyunting kontrol, memindahkannya pada slide, atau menghapusnya.

## **Daftar Kontrol ActiveX dan Properti yang Disimpan**

Untuk memeriksa templat yang tidak dikenal, buka untuk dibaca dan iterasi melalui kontrol pada setiap slide. Contoh melaporkan nomor slide, nama kontrol, [ID kelas](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/), dan setiap pasangan kunci-nilai dalam [properti yang disimpan](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/). Ia membaca presentasi tanpa mengaktifkan kontrol, memanggil acara atau makro, mengubah nilai, atau menyimpan file.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");

for (auto i = 0; i < presentation->get_Slides()->get_Count(); ++i)
{
    auto controls = presentation->get_Slide(i)->get_Controls();
    for (auto j = 0; j < controls->get_Count(); ++j)
    {
        auto control = controls->idx_get(j);
        Console::WriteLine(u"Slide {0} | {1} | {2}", i + 1, control->get_Name(), control->get_ClassId().ToString());
        auto properties = control->get_Properties();
        if (!properties)
        {
            Console::WriteLine(u"  Properties unavailable");
            continue;
        }

        if (properties->get_Count() == 0)
            Console::WriteLine(u"  []");

        auto entries = properties->GetEnumerator();
        while (entries->MoveNext())
        {
            auto property = entries->get_Current();
            Console::WriteLine(u"  {0} = {1}", property.get_Key(), property.get_Value());
        }
    }
}
```

Keluaran terpilih dari `ActiveX.pptm` menunjukkan sebuah kotak teks dan sebuah tombol perintah.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Koleksi properti kosong muncul sebagai `[]`. Untuk kontrol yang menggunakan penyimpanan biner, `get_Properties` dapat mengembalikan `nullptr`, ditampilkan sebagai `Properties unavailable`. Jika Anda hanya membutuhkan nama, gunakan [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/) setelah memeriksa bahwa koleksi ada. Laporan mencantumkan properti yang tersedia dari presentasi. Sebuah kontrol mungkin mendukung properti tambahan pada waktu jalan.

## **Ubah Kontrol ActiveX**

Contoh mengharapkan presentasi ber-makro dengan kotak teks bernama `TextBox1` dan tombol perintah bernama `CommandButton1` pada slide pertama. Ia menggunakan [koleksi properti kontrol](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) untuk mengubah nilai kotak teks dan keterangan tombol. Setiap kontrol juga memiliki pratinjau statis yang dapat ditampilkan PowerPoint sebelum aktivasi. Sediakan PNG untuk setiap kontrol yang menunjukkan teks dan tampilan yang diperbarui. Contoh menetapkan gambar-gambar ini melalui [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/).

Contoh memindahkan setiap kontrol pada slide pertama turun sebesar 100 poin dengan mengubah [frame](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/). Ia menyimpan presentasi yang disunting dalam format PPTM, kemudian menggunakan [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/) untuk menyimpan salinan kedua dengan semua kontrol ActiveX dihapus dari slide tersebut.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");
auto controls = presentation->get_Slide(0)->get_Controls();
SharedPtr<IControl> textBox;
SharedPtr<IControl> button;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"TextBox1")
        textBox = control;
    else if (control->get_Name() == u"CommandButton1")
        button = control;
}

if (!textBox || !button || !textBox->get_Properties() || !button->get_Properties())
{
    Console::WriteLine(u"The first slide must contain both named controls with editable properties.");
    return;
}

if (!File::Exists(u"text-box-preview.png") || !File::Exists(u"button-preview.png"))
{
    Console::WriteLine(u"Supply both preview images before updating the controls.");
    return;
}

textBox->get_Properties()->idx_set(u"Value", u"Changed text");
button->get_Properties()->idx_set(u"Caption", u"Show message");

auto textBoxBytes = File::ReadAllBytes(u"text-box-preview.png");
auto buttonBytes = File::ReadAllBytes(u"button-preview.png");
auto textBoxPreview = presentation->get_Images()->AddImage(textBoxBytes);
auto buttonPreview = presentation->get_Images()->AddImage(buttonBytes);
textBox->get_SubstitutePictureFormat()->get_Picture()->set_Image(textBoxPreview);
button->get_SubstitutePictureFormat()->get_Picture()->set_Image(buttonPreview);

for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    auto frame = control->get_Frame();
    auto movedFrame = MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation());
    control->set_Frame(movedFrame);
}

presentation->Save(u"edited-controls.pptm", SaveFormat::Pptm);

controls->Clear();
presentation->Save(u"removed-controls.pptm", SaveFormat::Pptm);
```

## **Tambahkan Kontrol Media Player ActiveX**

Untuk menggunakan kembali kontrol Windows Media Player yang telah dikonfigurasi, mulailah dengan templat yang slide pertamanya berisi pemutar bernama `WindowsMediaPlayer1`. [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) menyalin seluruh slide ke presentasi baru. Contoh menetapkan `URL` pemutar dalam [koleksi properti](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) dan menyimpan slide yang diklon sebagai satu-satunya slide dalam output. Video tetap eksternal, jadi pilih jalur yang dapat diakses pemutar selama pemutaran.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto source = MakeObject<Presentation>(u"template.pptx");
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slides()->AddClone(source->get_Slide(0));
auto controls = slide->get_Controls();

SharedPtr<IControl> player;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"WindowsMediaPlayer1")
    {
        player = control;
        break;
    }
}

if (!player || !player->get_Properties())
{
    Console::WriteLine(u"The template slide must contain a named media player with editable properties.");
    return;
}

player->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

presentation->get_Slides()->RemoveAt(0);
presentation->Save(u"linked-video.pptx", SaveFormat::Pptx);
```

## **Tanya Jawab**

**Apakah Aspose.Slides dapat mempertahankan kontrol ActiveX tanpa menjalankannya?**

Ya. Aspose.Slides dapat membaca dan menyimpan kontrol, termasuk properti dan posisinya, tanpa mengaktifkannya.

**Bagaimana perbedaan kontrol ActiveX dengan objek OLE?**

Kontrol ActiveX memungkinkan pengguna berinteraksi dengan slide, misalnya dengan memasukkan teks atau mengklik tombol. Sebuah [objek OLE](/slides/id/cpp/manage-ole/) memungkinkan slide berisi atau menautkan ke konten yang dikelola oleh aplikasi lain, seperti lembar kerja Excel.

**Apakah peristiwa ActiveX masih akan memicu makro VBA setelah saya menyimpan presentasi dengan Aspose.Slides?**

Simpan presentasi dalam format ber-makro seperti PPTM untuk mempertahankan proyek VBA-nya. PowerPoint untuk Windows dapat menjalankan penangan peristiwa yang ada ketika pengaturan keamanannya mengizinkan baik kontrol ActiveX maupun makro.