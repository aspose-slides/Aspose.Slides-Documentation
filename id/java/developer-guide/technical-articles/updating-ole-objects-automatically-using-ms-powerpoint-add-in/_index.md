---
title: Perbarui Objek OLE Secara Otomatis Menggunakan Add-In PowerPoint
type: docs
weight: 10
url: /id/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- objek OLE
- perbarui OLE
- otomatis
- add-in
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Temukan cara memperbarui otomatis diagram dan objek OLE di PowerPoint dengan add-in dan Aspose.Slides untuk Java, dilengkapi contoh kode praktis dan tip optimasi."
---
## **Introduction**

Salah satu pertanyaan yang paling sering diajukan oleh pelanggan Aspose.Slides for Java adalah bagaimana cara membuat atau memodifikasi diagram yang dapat diedit (atau objek OLE lainnya) sehingga mereka memperbarui secara otomatis ketika presentasi dibuka. Sayangnya, PowerPoint tidak mendukung makro otomatis dengan cara yang sama seperti Excel dan Word. Satu-satunya makro yang tersedia adalah `Auto_Open` dan `Auto_Close`, dan makro ini hanya berjalan otomatis dari sebuah add-in. Tips teknis singkat ini menunjukkan cara mencapainya.

## **Update OLE Objects Automatically**

Pertama, ada beberapa add-in freeware yang menambahkan fitur macro Auto_Open ke PowerPoint, misalnya [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) dan [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Setelah menginstal salah satu add-in tersebut, cukup tambahkan macro `Auto_Open()` (atau `OnPresentationOpen()` jika Anda menggunakan Event Generator) ke presentasi templat Anda seperti yang ditunjukkan di bawah ini:

```java
// Loop melalui setiap slide dalam presentasi.
for (var oSlide : ActivePresentation.Slides) {
    // Loop melalui semua shape pada slide saat ini.
    for (var oShape : oSlide.Shapes) {
        // Periksa apakah shape tersebut merupakan objek OLE.
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // Ditemukan objek OLE. Dapatkan referensi objeknya lalu perbarui.
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // Sekarang, keluar dari program server OLE.
            // Ini membebaskan memori, dan mencegah masalah apapun.
            // Juga, set oObject ke Nothing untuk melepaskan objek.
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```

Setiap perubahan yang dibuat pada objek OLE dengan Aspose.Slides for Java akan secara otomatis diperbarui ketika PowerPoint membuka presentasi. Jika Anda memiliki banyak objek OLE dan tidak ingin memperbarui semuanya, cukup tambahkan tag khusus pada shape yang perlu diproses dan periksa tag tersebut dalam macro.