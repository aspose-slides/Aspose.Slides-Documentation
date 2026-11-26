---
title: Kelola Kontrol ActiveX dalam Presentasi di .NET
linktitle: ActiveX
type: docs
weight: 80
url: /id/net/activex/
keywords:
- ActiveX
- kontrol ActiveX
- kelola ActiveX
- tambahkan ActiveX
- modifikasi ActiveX
- pemutar media
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Edit kotak teks dan tombol ActiveX, perbarui pratinjau kontrol, dan gunakan kembali kontrol Windows Media Player dalam presentasi PowerPoint dengan Aspose.Slides untuk .NET."
---
## **Pengantar**

Kontrol ActiveX memberikan slide PowerPoint elemen interaktif seperti kotak teks, tombol perintah, dan pemutar media. Aspose.Slides untuk .NET menampilkan kontrol slide melalui [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/). Gunakan koleksi ini untuk mengedit kontrol, memindahkannya pada slide, atau menghapusnya.

## **Daftar Kontrol ActiveX dan Properti yang Disimpan**

Untuk memeriksa templat yang tidak dikenal, bukalah untuk dibaca dan iterasikan kontrol pada setiap slide. Contoh melaporkan nomor slide, nama kontrol, [ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/), dan setiap pasangan kunci‑nilai dalam [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties). Ia membaca presentasi tanpa mengaktifkan kontrol, memanggil event atau makro, mengubah nilai, atau menyimpan file.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("ActiveX.pptm");

for (var i = 0; i < presentation.Slides.Count; i++)
{
    foreach (var control in presentation.Slides[i].Controls)
    {
        Console.WriteLine($"Slide {i + 1} | {control.Name} | {control.ClassId}");
        var properties = control.Properties;

        if (properties == null)
        {
            Console.WriteLine("  Properties unavailable");
            continue;
        }

        if (properties.Count == 0)
            Console.WriteLine("  []");

        foreach (var property in properties)
            Console.WriteLine($"  {property.Key} = {property.Value}");
    }
}
```

Output terpilih dari `ActiveX.pptm` menunjukkan sebuah kotak teks dan sebuah tombol perintah.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Koleksi properti kosong muncul sebagai `[]`. Untuk kontrol yang menggunakan penyimpanan biner, `Properties` dapat mengembalikan `null`, ditampilkan sebagai `Properties unavailable`. Jika Anda hanya membutuhkan nama, gunakan [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/) setelah pemeriksaan null. Laporan mencantumkan properti yang tersedia dari presentasi. Sebuah kontrol mungkin mendukung properti tambahan pada waktu berjalan.

## **Modifikasi Kontrol ActiveX**

Contoh mengharapkan presentasi yang mendukung makro dengan kotak teks bernama `TextBox1` dan tombol perintah bernama `CommandButton1` pada slide pertama. Ia menggunakan [control properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) untuk mengubah nilai kotak teks dan caption tombol. Setiap kontrol juga memiliki pratinjau statis yang dapat ditampilkan PowerPoint sebelum aktivasi. Sediakan PNG untuk setiap kontrol yang menampilkan teks dan penampilan yang diperbarui. Contoh menetapkan gambar ini melalui [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/).

Contoh memindahkan setiap kontrol pada slide pertama ke bawah sebesar 100 poin dengan mengubah [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/). Ia menyimpan presentasi yang diedit dalam format PPTM, kemudian menggunakan [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) untuk menyimpan salinan kedua dengan semua kontrol ActiveX dihapus dari slide tersebut.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");

var controls = presentation.Slides[0].Controls;
var textBox = controls.FirstOrDefault(control => control.Name == "TextBox1");
var button = controls.FirstOrDefault(control => control.Name == "CommandButton1");

if (textBox?.Properties == null || button?.Properties == null)
{
    Console.WriteLine("The first slide must contain both named controls with editable properties.");
    return;
}

if (!File.Exists("text-box-preview.png") || !File.Exists("button-preview.png"))
{
    Console.WriteLine("Supply both preview images before updating the controls.");
    return;
}

textBox.Properties["Value"] = "Changed text";
button.Properties["Caption"] = "Show message";

using var textBoxPreview = File.OpenRead("text-box-preview.png");
using var buttonPreview = File.OpenRead("button-preview.png");
textBox.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(textBoxPreview);
button.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(buttonPreview);

foreach (var control in controls)
{
    var frame = control.Frame;
    control.Frame = new ShapeFrame(frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

presentation.Save("edited-controls.pptm", SaveFormat.Pptm);

controls.Clear();
presentation.Save("removed-controls.pptm", SaveFormat.Pptm);
```

## **Tambahkan Kontrol Media Player ActiveX**

Untuk menggunakan kembali kontrol Windows Media Player yang sudah dikonfigurasi, mulailah dengan templat yang slide pertamanya berisi pemutar bernama `WindowsMediaPlayer1`. [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) menyalin seluruh slide ke presentasi baru. Contoh mengatur `URL` pemutar dalam [properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) dan menyimpan slide yang dikloning sebagai satu‑satunya slide dalam output. Video tetap eksternal, jadi pilih jalur yang dapat diakses pemutar selama pemutaran.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var template = new Presentation("template.pptx");
using var presentation = new Presentation();

var slide = presentation.Slides.AddClone(template.Slides[0]);
var player = slide.Controls.FirstOrDefault(control => control.Name == "WindowsMediaPlayer1");

if (player?.Properties == null)
{
    Console.WriteLine("The template slide must contain a named media player with editable properties.");
    return;
}

player.Properties["URL"] = "Wildlife.mp4";

presentation.Slides.RemoveAt(0);
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Apakah Aspose.Slides dapat mempertahankan kontrol ActiveX tanpa menjalankannya?**

Ya. Aspose.Slides dapat membaca dan menyimpan kontrol, termasuk properti dan posisinya, tanpa mengaktifkannya.

**Bagaimana perbedaan kontrol ActiveX dengan objek OLE?**

Kontrol ActiveX memungkinkan pengguna berinteraksi dengan slide, misalnya dengan memasukkan teks atau mengklik tombol. Sebuah [objek OLE](/slides/id/net/manage-ole/) memungkinkan slide berisi atau menautkan ke konten yang dikelola oleh aplikasi lain, seperti lembar kerja Excel.

**Apakah event ActiveX masih akan memicu makro VBA setelah saya menyimpan presentasi dengan Aspose.Slides?**

Simpan presentasi dalam format yang mendukung makro seperti PPTM untuk mempertahankan proyek VBA‑nya. PowerPoint untuk Windows dapat menjalankan penangan peristiwa yang ada ketika pengaturan keamanannya mengizinkan kedua kontrol ActiveX dan makro.