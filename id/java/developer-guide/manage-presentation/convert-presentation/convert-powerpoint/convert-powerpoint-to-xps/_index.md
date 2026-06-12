---
title: Konversi Presentasi PowerPoint ke XPS di Java
linktitle: PowerPoint ke XPS
type: docs
weight: 70
url: /id/java/convert-powerpoint-to-xps/
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
- Java
- Aspose.Slides
description: "Konversi PowerPoint PPT/PPTX ke XPS berkualitas tinggi dan independen platform di Java menggunakan Aspose.Slides. Dapatkan panduan langkah demi langkah dan contoh kode."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda mengonversi presentasi PowerPoint ke XPS dengan menyimpan file PPT atau PPTX dalam format XPS. Artikel ini menjelaskan kapan format XPS mungkin berguna dan menunjukkan cara melakukan konversi dengan Aspose.Slides menggunakan pengaturan default atau pengaturan khusus [XpsOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/xpsoptions/) .

## **Tentang XPS**
Microsoft mengembangkan [XPS](https://docs.fileformat.com/page-description-language/xps/) sebagai alternatif untuk [PDF](https://docs.fileformat.com/pdf/). Ini memungkinkan Anda mencetak konten dengan menghasilkan file yang sangat mirip dengan PDF. Format XPS berbasis XML. Tata letak atau struktur file XPS tetap sama di semua sistem operasi dan printer. 

## **Kapan Menggunakan Format XPS Microsoft**

{{% alert color="primary" %}} 

Untuk melihat bagaimana Aspose.Slides mengonversi presentasi PPT atau PPTX ke format XPS, Anda dapat melihat [aplikasi konverter online gratis ini](https://products.aspose.app/slides/id/conversion). 

{{% /alert %}} 

Jika Anda ingin mengurangi biaya penyimpanan, Anda dapat mengonversi presentasi Microsoft PowerPoint Anda ke format XPS. Dengan cara ini, Anda akan lebih mudah menyimpan, berbagi, dan mencetak dokumen Anda. 

Microsoft terus memberikan dukungan kuat untuk XPS di Windows (bahkan di Windows 10), jadi Anda mungkin ingin mempertimbangkan menyimpan file ke format ini. Jika Anda bekerja dengan Windows 8.1, Windows 8, Windows 7, dan Windows Vista, maka XPS mungkin menjadi pilihan terbaik untuk operasi tertentu. 

- **Windows 8** menggunakan format OXPS (Open XPS) untuk file XPS. OXPS adalah versi standar dari format XPS asli. Windows 8 memberikan dukungan yang lebih baik untuk file XPS dibandingkan dengan file PDF. 
  - **XPS:** Penampil/pembaca XPS bawaan serta fitur pencetakan ke XPS tersedia. 
  - **PDF:** Pembaca PDF tersedia tetapi tidak ada fitur pencetakan ke PDF. 

- **Windows 7 dan Windows Vista** menggunakan format XPS asli. Sistem operasi ini juga memberikan dukungan yang lebih baik untuk file XPS dibandingkan dengan PDF. 
  - **XPS:** Penampil XPS bawaan serta fitur pencetakan ke XPS tersedia. 
  - **PDF:** Tidak ada pembaca PDF. Tidak ada fitur pencetakan ke PDF. 

|<p>**Masukan PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Keluaran XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft akhirnya mengimplementasikan dukungan untuk operasi pencetakan dalam PDF melalui fitur Print to PDF di Windows 10. Sebelumnya, pengguna diharapkan mencetak dokumen melalui format XPS. 

## **Konversi XPS dengan Aspose.Slides**

Di [**Aspose.Slides**](https://products.aspose.com/slides/id/java/) untuk Java, Anda dapat menggunakan metode [**Save**](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) yang disediakan oleh kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) untuk mengonversi seluruh presentasi menjadi dokumen XPS. 

Ketika mengonversi presentasi ke XPS, Anda harus menyimpan presentasi menggunakan salah satu pengaturan berikut:

- Pengaturan default (tanpa [**XPSOptions**](https://reference.aspose.com/slides/id/java/com.aspose.slides/xpsoptions))
- Pengaturan khusus (dengan [**XPSOptions**](https://reference.aspose.com/slides/id/java/com.aspose.slides/xpsoptions))

### **Mengonversi Presentasi ke XPS dengan Pengaturan Default**

Contoh kode berikut dalam Java menunjukkan cara mengonversi presentasi menjadi dokumen XPS menggunakan pengaturan standar:

```java
// Instansiasi objek Presentation yang mewakili file presentasi
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Menyimpan presentasi ke dokumen XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Mengonversi Presentasi ke XPS dengan Pengaturan Khusus**
Contoh kode ini menunjukkan cara mengonversi presentasi menjadi dokumen XPS menggunakan pengaturan khusus dalam Java:

```java
// Instansiasi objek Presentation yang mewakili file presentasi
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Instansiasi kelas TiffOptions
    XpsOptions options = new XpsOptions();

    // Simpan MetaFiles sebagai PNG
    options.setSaveMetafilesAsPng(true);

    // Simpan presentasi ke dokumen XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat menyimpan ke XPS ke dalam stream alih-alih file?**

Ya—Aspose.Slides memungkinkan Anda mengekspor langsung ke stream, yang ideal untuk API web, pipeline sisi server, atau skenario apa pun di mana Anda ingin mengirim XPS tanpa menyentuh sistem file.

**Apakah slide tersembunyi dibawa ke XPS, dan dapatkah saya mengecualikannya?**

Secara default, hanya slide reguler (terlihat) yang dirender. Anda dapat [include or exclude hidden slides](https://reference.aspose.com/slides/id/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) melalui [export settings](https://reference.aspose.com/slides/id/java/com.aspose.slides/xpsoptions/) sebelum menyimpan ke XPS, memastikan output berisi tepat halaman yang Anda inginkan.