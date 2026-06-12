---
title: Konversi Presentasi PowerPoint ke XPS di .NET
linktitle: PowerPoint ke XPS
type: docs
weight: 70
url: /id/net/convert-powerpoint-to-xps/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke XPS
- presentasi ke XPS
- slide ke XPS
- PPT ke XPS
- PPTX ke XPS
- simpan PPT sebagai XPS
- simpan PPTX sebagai XPS
- ekspor PPT ke XPS
- ekspor PPTX ke XPS
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Konversi PowerPoint PPT/PPTX ke XPS berkualitas tinggi dan bersifat lintas platform di .NET menggunakan Aspose.Slides. Dapatkan panduan langkah demi langkah dan contoh kode C#."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda mengonversi presentasi PowerPoint ke XPS dengan menyimpan file PPT atau PPTX dalam format XPS. Artikel ini menjelaskan kapan format XPS dapat berguna dan menunjukkan cara melakukan konversi dengan Aspose.Slides menggunakan pengaturan bawaan atau pengaturan khusus [XpsOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/xpsoptions/) .

## **Tentang XPS**
Microsoft mengembangkan [XPS](https://docs.fileformat.com/page-description-language/xps/) sebagai alternatif bagi [PDF](https://docs.fileformat.com/pdf/). Ini memungkinkan Anda mencetak konten dengan menghasilkan file yang sangat mirip dengan PDF. Format XPS berbasis XML. Tata letak atau struktur file XPS tetap sama di semua sistem operasi dan printer. 

## **Kapan Menggunakan Format XPS Microsoft**

{{% alert color="primary" %}} 

Untuk melihat cara Aspose.Slides mengonversi presentasi PPT atau PPTX ke format XPS, Anda dapat mencoba [aplikasi konversi online gratis ini](https://products.aspose.app/slides/id/conversion). 

{{% /alert %}} 

Jika Anda ingin mengurangi biaya penyimpanan, Anda dapat mengonversi presentasi Microsoft PowerPoint Anda ke format XPS. Dengan cara ini, Anda akan lebih mudah menyimpan, berbagi, dan mencetak dokumen Anda. 

Microsoft terus memberikan dukungan kuat untuk XPS di Windows (bahkan di Windows 10), sehingga Anda mungkin ingin mempertimbangkan menyimpan file ke format ini. Jika Anda menggunakan Windows 8.1, Windows 8, Windows 7, dan Windows Vista, maka XPS mungkin menjadi pilihan terbaik untuk operasi tertentu. 

- **Windows 8** menggunakan format OXPS (Open XPS) untuk file XPS. OXPS adalah versi standar dari format XPS asli. Windows 8 menyediakan dukungan yang lebih baik untuk file XPS dibandingkan file PDF. 
  - **XPS:** Penampil/pembaca XPS bawaan dan fitur mencetak ke XPS tersedia. 
  - **PDF:** Pembaca PDF tersedia tetapi tidak ada fitur mencetak ke PDF. 

- **Windows 7 dan Windows Vista** menggunakan format XPS asli. Sistem operasi ini juga menyediakan dukungan yang lebih baik untuk file XPS dibandingkan PDF. 
  - **XPS:** Penampil XPS bawaan dan fitur mencetak ke XPS tersedia. 
  - **PDF:** Tidak ada pembaca PDF. Tidak ada fitur mencetak ke PDF. 

|<p>**Masukan PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Keluaran XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft akhirnya menambahkan dukungan untuk operasi pencetakan dalam PDF melalui fitur Print to PDF di Windows 10. Sebelumnya, pengguna diharapkan mencetak dokumen melalui format XPS. 

## **Konversi XPS dengan Aspose.Slides**

Di [**Aspose.Slides**](https://products.aspose.com/slides/id/net/) untuk .NET, Anda dapat menggunakan metode [**Save**](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/methods/save/index) yang disediakan oleh kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) untuk mengonversi seluruh presentasi menjadi dokumen XPS. 

Saat mengonversi presentasi ke XPS, Anda harus menyimpan presentasi menggunakan salah satu pengaturan berikut:

- Pengaturan bawaan (tanpa [**XPSOptions**](https://reference.aspose.com/slides/id/net/aspose.slides.export/xpsoptions))
- Pengaturan khusus (dengan [**XPSOptions**](https://reference.aspose.com/slides/id/net/aspose.slides.export/xpsoptions))

### **Konversi Presentasi ke XPS Menggunakan Pengaturan Bawaan**

Kode contoh ini dalam C# menunjukkan cara mengonversi presentasi ke dokumen XPS menggunakan pengaturan standar:

```c#
// Instansiasi objek Presentation yang mewakili file presentasi
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Menyimpan presentasi ke dokumen XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **Konversi Presentasi ke XPS Menggunakan Pengaturan Khusus**

Kode contoh ini menunjukkan cara mengonversi presentasi ke dokumen XPS menggunakan pengaturan khusus dalam C#:

```c#
// Instansiasi objek Presentation yang mewakili file presentasi
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Instansiasi kelas TiffOptions
    XpsOptions options = new XpsOptions();

    // Simpan MetaFiles sebagai PNG
    options.SaveMetafilesAsPng = true;

    // Simpan presentasi ke dokumen XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **FAQ**

**Apakah saya dapat menyimpan ke XPS dalam stream alih-alih ke file?**

Ya—Aspose.Slides memungkinkan Anda mengekspor langsung ke stream, yang ideal untuk API web, pipeline sisi server, atau skenario apa pun di mana Anda ingin mengirim XPS tanpa menyentuh sistem file.

**Apakah slide tersembunyi termasuk dalam XPS, dan dapatkah saya mengecualikannya?**

Secara default, hanya slide reguler (terlihat) yang dirender. Anda dapat [menyertakan atau mengecualikan slide tersembunyi](https://reference.aspose.com/slides/id/net/aspose.slides.export/xpsoptions/showhiddenslides/) melalui [pengaturan ekspor](https://reference.aspose.com/slides/id/net/aspose.slides.export/xpsoptions/) sebelum menyimpan ke XPS, memastikan output berisi tepat halaman yang Anda inginkan.