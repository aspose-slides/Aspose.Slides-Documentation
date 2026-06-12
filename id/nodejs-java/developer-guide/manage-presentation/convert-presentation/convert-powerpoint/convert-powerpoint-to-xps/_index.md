---
title: Konversi Presentasi PowerPoint ke XPS dalam JavaScript
linktitle: PowerPoint ke XPS
type: docs
weight: 70
url: /id/nodejs-java/convert-powerpoint-to-xps/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konversi PowerPoint PPT/PPTX ke XPS berkualitas tinggi, lintas platform dalam JavaScript menggunakan Aspose.Slides untuk Node.js. Dapatkan panduan langkah demi langkah dan contoh kode."
---
## **Overview**

Aspose.Slides memungkinkan Anda mengonversi presentasi PowerPoint ke XPS dengan menyimpan file PPT atau PPTX dalam format XPS. Artikel ini menjelaskan kapan format XPS dapat berguna dan menunjukkan cara melakukan konversi dengan Aspose.Slides menggunakan pengaturan default atau pengaturan khusus [XpsOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/xpsoptions/).

## **About XPS**

Microsoft mengembangkan [XPS](https://docs.fileformat.com/page-description-language/xps/) sebagai alternatif untuk [PDF](https://docs.fileformat.com/pdf/).  XPS memungkinkan Anda mencetak konten dengan menghasilkan file yang sangat mirip dengan PDF. Format XPS berbasis XML. Tata letak atau struktur file XPS tetap sama pada semua sistem operasi dan printer. 

## **When to Use Microsoft XPS Format**

{{% alert color="primary" %}} 

Untuk melihat bagaimana Aspose.Slides mengonversi presentasi PPT atau PPTX ke format XPS, Anda dapat mencoba [aplikasi konversi online gratis ini](https://products.aspose.app/slides/id/conversion). 

{{% /alert %}} 

Jika Anda ingin mengurangi biaya penyimpanan, Anda dapat mengonversi presentasi Microsoft PowerPoint ke format XPS. Dengan cara ini, Anda akan lebih mudah menyimpan, berbagi, dan mencetak dokumen Anda. 

Microsoft terus menyediakan dukungan kuat untuk XPS di Windows (bahkan di Windows 10), sehingga Anda mungkin ingin mempertimbangkan menyimpan file ke format ini. Jika Anda menggunakan Windows 8.1, Windows 8, Windows 7, atau Windows Vista, maka XPS mungkin menjadi pilihan terbaik untuk beberapa operasi tertentu. 

- **Windows 8** menggunakan format OXPS (Open XPS) untuk file XPS. OXPS adalah versi standar dari format XPS asli. Windows 8 memberikan dukungan yang lebih baik untuk file XPS dibandingkan dengan file PDF. 
  - **XPS:** Penampil/pembaca XPS bawaan dan fitur pencetakan ke XPS tersedia. 
  - **PDF**: Pembaca PDF tersedia tetapi tidak ada fitur pencetakan ke PDF. 

-  **Windows 7 dan Windows Vista** menggunakan format XPS asli. Sistem operasi ini juga memberikan dukungan yang lebih baik untuk file XPS dibandingkan dengan PDF. 
  - **XPS**: Penampil XPS bawaan dan fitur pencetakan ke XPS tersedia. 
  - **PDF**: Tidak ada pembaca PDF. Tidak ada fitur pencetakan ke PDF. 

|<p>**Input PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Output XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft pada akhirnya menambahkan dukungan untuk operasi pencetakan dalam PDF melalui fitur Print to PDF di Windows 10. Sebelumnya, pengguna diharapkan mencetak dokumen melalui format XPS. 

## **XPS Conversion with Aspose.Slides**

Di [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/id/nodejs-java/), Anda dapat menggunakan metode [**save**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) yang disediakan oleh kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) untuk mengonversi seluruh presentasi menjadi dokumen XPS.

Saat mengonversi presentasi ke XPS, Anda harus menyimpan presentasi dengan salah satu pengaturan berikut:

- Pengaturan default (tanpa [**XPSOptions**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/xpsoptions))
- Pengaturan khusus (dengan [**XPSOptions**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/xpsoptions))

### **Converting Presentations to XPS Using Default Settings**

Contoh kode berikut dalam JavaScript menunjukkan cara mengonversi presentasi ke dokumen XPS menggunakan pengaturan standar:

```javascript
// Membuat objek Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("Convert_XPS.pptx");
try {
    // Menyimpan presentasi ke dokumen XPS
    pres.save("XPS_Output_Without_XPSOption.xps", aspose.slides.SaveFormat.Xps);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Converting Presentations to XPS Using Custom Settings**
Contoh kode berikut menunjukkan cara mengonversi presentasi ke dokumen XPS menggunakan pengaturan khusus dalam JavaScript:

```javascript
// Membuat objek Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("Convert_XPS_Options.pptx");
try {
    // Membuat instance kelas TiffOptions
    var options = new aspose.slides.XpsOptions();
    // Simpan MetaFiles sebagai PNG
    options.setSaveMetafilesAsPng(true);
    // Simpan presentasi ke dokumen XPS
    pres.save("XPS_Output_With_Options.xps", aspose.slides.SaveFormat.Xps, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Can I save to XPS into a stream instead of a file?**

Ya—Aspose.Slides memungkinkan Anda mengekspor langsung ke stream, yang ideal untuk API web, pipeline sisi server, atau skenario apa pun di mana Anda ingin mengirim XPS tanpa menyentuh sistem file.

**Are hidden slides carried over to XPS, and can I exclude them?**

Secara default, hanya slide reguler (terlihat) yang dirender. Anda dapat [include or exclude hidden slides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/xpsoptions/setshowhiddenslides/) melalui [export settings](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/xpsoptions/) sebelum menyimpan ke XPS, memastikan output berisi tepat halaman yang Anda inginkan.