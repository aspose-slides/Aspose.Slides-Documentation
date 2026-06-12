---
title: Perbarui Objek OLE Secara Otomatis Menggunakan Add-In PowerPoint
type: docs
weight: 10
url: /id/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- objek OLE
- perbarui OLE
- secara otomatis
- add-in
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Temukan cara otomatis memperbarui diagram dan objek OLE di PowerPoint dengan add-in dan Aspose.Slides untuk .NET, menyertakan contoh kode praktis dan tips optimalisasi."
---
## **Pendahuluan**

Salah satu pertanyaan paling sering diajukan oleh pelanggan Aspose.Slides for .NET adalah bagaimana membuat atau memodifikasi diagram yang dapat diedit (atau objek OLE lainnya) sehingga mereka secara otomatis diperbarui ketika presentasi dibuka. Sayangnya, PowerPoint tidak mendukung makro otomatis dengan cara yang sama seperti Excel dan Word. Satu-satunya makro yang tersedia adalah `Auto_Open` dan `Auto_Close`, dan keduanya hanya berjalan otomatis dari sebuah add‑in. Tips teknis singkat ini menunjukkan cara mencapainya.

## **Perbarui Objek OLE Secara Otomatis**

Pertama, beberapa add‑in freeware tersedia yang menambahkan fitur makro Auto_Open ke PowerPoint, misalnya [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) dan [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Setelah menginstal salah satu add‑in ini, cukup tambahkan makro `Auto_Open()` (atau `OnPresentationOpen()` jika Anda menggunakan Event Generator) ke presentasi templat Anda seperti yang ditunjukkan di bawah ini:

```cs
public void Auto_Open()
{
    // Iterasi setiap slide dalam presentasi.
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // Iterasi semua shape pada slide saat ini.
        foreach (var oShape in oSlide.Shapes)
        {
            // Periksa apakah shape adalah objek OLE.
            if (oShape.Type == msoEmbeddedOLEObject)
            {
                // Objek OLE ditemukan. Dapatkan referensi objeknya kemudian perbarui.
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // Sekarang, keluar dari program server OLE.
                // Ini membebaskan memori, dan mencegah masalah apa pun.
                // Juga, setel oObject ke Nothing untuk melepaskan objek.
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```

Setiap perubahan yang dibuat pada objek OLE dengan Aspose.Slides for .NET akan secara otomatis diperbarui saat PowerPoint membuka presentasi. Jika Anda memiliki banyak objek OLE dan tidak ingin memperbarui semuanya, cukup tambahkan tag khusus pada shape yang perlu diproses dan periksa tag tersebut dalam makro.