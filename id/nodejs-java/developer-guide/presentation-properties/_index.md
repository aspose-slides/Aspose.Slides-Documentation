---
title: Kelola Properti Presentasi dalam JavaScript
linktitle: Properti Presentasi
type: docs
weight: 70
url: /id/nodejs-java/presentation-properties/
keywords:
- Properti PowerPoint
- Properti presentasi
- Properti dokumen
- Properti bawaan
- Properti khusus
- Properti lanjutan
- Kelola properti
- Modifikasi properti
- Metadata dokumen
- Edit metadata
- Bahasa pemeriksaan ejaan
- Bahasa default
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kuasi properti presentasi di Aspose.Slides untuk Node.js via Java dan permudah pencarian, branding, serta alur kerja dalam file PowerPoint dan OpenDocument Anda."
---
## **Pendahuluan**

Aspose.Slides mendukung dua jenis properti dokumen: **Built-in** dan **Custom**. Kedua jenis properti ini dapat dengan mudah diakses dan dikelola menggunakan API Aspose.Slides.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui kelas [DocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/) . Sebuah instance kelas ini dikembalikan oleh metode [Presentation.getDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getDocumentProperties) . Contoh berikut menunjukkan cara membaca, memodifikasi, dan mengelola properti-properti tersebut.

{{% alert color="info" title="Catatan" %}}

Harap perhatikan bahwa bidang **Application** dan **AppVersion** tidak dapat diubah. Aspose.Slides menimpa bidang tersebut setiap kali disimpan, sehingga presentasi yang disimpan selalu melaporkan "Aspose.Slides for Node.js via Java" dan versi perpustakaan yang menghasilkan file tersebut. Nilai apa pun yang diberikan ke `setNameOfApplication` akan diabaikan ketika presentasi ditulis.

{{% /alert %}} 

## **Kelola Properti Presentasi**

Microsoft PowerPoint menyediakan fitur untuk menambahkan beberapa properti ke file presentasi. Properti dokumen ini memungkinkan informasi berguna disimpan bersama dokumen (file presentasi). Ada dua jenis properti dokumen sebagai berikut

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

Properti **Built-in** berisi informasi umum tentang dokumen seperti judul dokumen, nama penulis, statistik dokumen, dan sebagainya. Properti **Custom** adalah properti yang didefinisikan oleh pengguna sebagai pasangan **Name/Value**, di mana baik nama maupun nilai ditentukan oleh pengguna. Menggunakan Aspose.Slides for Node.js via Java, pengembang dapat mengakses dan memodifikasi nilai properti built‑in maupun custom.

## **Properti Dokumen di PowerPoint**

Microsoft PowerPoint 2007 memungkinkan pengelolaan properti dokumen file presentasi. Yang perlu Anda lakukan hanyalah mengklik ikon Office dan kemudian menu **Prepare | Properties | Advanced Properties** pada Microsoft PowerPoint 2007 seperti yang ditunjukkan di bawah ini:

|**Memilih Item Menu Properti Lanjutan**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Setelah Anda memilih item menu **Advanced Properties**, sebuah dialog akan muncul yang memungkinkan Anda mengelola properti dokumen file PowerPoint seperti yang ditunjukkan pada gambar berikut:

|**Dialog Properti**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Pada **Dialog Properti** di atas, Anda dapat melihat banyak tab seperti **General**, **Summary**, **Statistics**, **Contents**, dan **Custom**. Semua tab ini memungkinkan konfigurasi berbagai jenis informasi terkait file PowerPoint. Tab **Custom** digunakan untuk mengelola properti custom file PowerPoint.

### Bekerja dengan Properti Dokumen Menggunakan Aspose.Slides for Node.js via Java

Seperti yang dijelaskan sebelumnya, Aspose.Slides for Node.js via Java mendukung dua jenis properti dokumen, yaitu **Built-in** dan **Custom**. Jadi, pengembang dapat mengakses kedua jenis properti tersebut dengan menggunakan API Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java menyediakan kelas [DocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties) yang mewakili properti dokumen yang terkait dengan file presentasi melalui properti **Presentation.DocumentProperties**.

Pengembang dapat menggunakan properti **DocumentProperties** yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation) untuk mengakses properti dokumen file presentasi seperti yang dijelaskan di bawah ini:

## **Baca Properti Publik dari Presentasi yang Dikenkripsi**

Password pembuka biasanya melindungi baik konten presentasi maupun properti dokumen. Ketika sebuah presentasi dienkripsi dengan memberikan `false` ke [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), properti dokumennya tetap publik. Aplikasi kemudian dapat memberikan `true` ke [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) dan membaca metadata publik tanpa menyediakan password pembuka.

Opsi “document‑properties‑only” mengontrol apa yang dimuat oleh Aspose.Slides; ia tidak mendekripsi apa pun. Jika properti termasuk dalam enkripsi, memuatnya tanpa password akan gagal. Jika presentasi tidak dienkripsi, opsi ini diabaikan dan seluruh presentasi dimuat.

Contoh berikut memverifikasi mode pemuatan melalui [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) dan kemudian membaca properti built‑in melalui [Presentation.getDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Dalam mode ini, konten slide tidak dimuat. Slide, master, layout, shape, media, dan objek presentasi lainnya tidak tersedia. Aplikasi harus selalu memeriksa [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) sebelum melakukan operasi yang memerlukan model objek presentasi lengkap.

{{% alert color="warning" title="Peringatan" %}}
Metadata publik dapat mengungkapkan nama penulis, judul, subjek, kata kunci, informasi perusahaan, komentar, dan nilai custom. Enkripsi properti sensitif bersama dengan presentasi. Biarkan mereka publik hanya ketika sistem pengindeksan, klasifikasi, pencarian, atau manajemen dokumen memiliki kebutuhan khusus untuk mengaksesnya tanpa password.
{{% /alert %}}

## **Perbarui Properti Presentasi yang Dikenkripsi**

Untuk file PPTX yang dienkripsi, presentasi yang dimuat dalam mode “document‑properties‑only” ditujukan untuk membaca metadata publik. Aspose.Slides tidak dapat menyimpan perubahan properti dari objek “metadata‑only” tersebut karena properti publik harus tetap konsisten dengan data yang bersesuaian di dalam presentasi yang dienkripsi. Oleh karena itu, memperbarui properti memerlukan password pembuka yang benar dan pemuatan lengkap.

Contoh berikut membuka presentasi dengan [LoadOptions.setPassword](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setPassword), memperbarui properti built‑in publik, dan menyimpan hasilnya. Kemudian menggunakan [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/#isEncrypted) untuk memverifikasi bahwa enkripsi tetap terjaga dan membuka kembali metadata publik tanpa password untuk memverifikasi nilai baru:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Jika sebuah aplikasi tidak diizinkan mendekripsi atau memuat konten presentasi, ia harus memperlakukan properti publik dari file PPTX yang dienkripsi sebagai **read‑only**.

## **Akses Properti Built‑in**

Properti yang diekspos oleh objek [DocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties) meliputi: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (Apakah dibagikan antar pembuat?), **PresentationFormat**, **Subject**, dan **Title**.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Membuat instance kelas Presentation yang mewakili presentasi
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Membuat referensi ke objek IDocumentProperties yang terkait dengan Presentation
    var dp = pres.getDocumentProperties();
    // Tampilkan properti built-in
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modifikasi Properti Built‑in**

Memodifikasi properti built‑in file presentasi semudah mengaksesnya. Anda cukup menetapkan nilai string ke properti yang diinginkan dan nilai properti tersebut akan berubah. Pada contoh di bawah, kami menunjukkan cara memodifikasi properti dokumen built‑in presentasi menggunakan Aspose.Slides for Node.js via Java.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Buat referensi ke objek IDocumentProperties yang terkait dengan Presentation
    var dp = pres.getDocumentProperties();
    // Setel properti built-in
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Simpan presentasi Anda ke file
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Contoh ini memodifikasi properti built‑in presentasi yang dapat dilihat seperti berikut:

|**Properti dokumen built‑in setelah modifikasi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Menambahkan Properti Dokumen Custom**

Aspose.Slides for Node.js via Java juga memungkinkan pengembang menambahkan nilai custom untuk properti dokumen presentasi. Contoh di bawah menunjukkan cara menetapkan properti custom untuk sebuah presentasi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Mendapatkan Properti Dokumen
    var dProps = pres.getDocumentProperties();
    // Menambahkan Properti Custom
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Mendapatkan Nama Properti pada Indeks Tertentu
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Menghapus Properti Terpilih
    dProps.removeCustomProperty(getPropertyName);
    // Menyimpan Presentasi
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Properti Dokumen Custom Ditambahkan**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Akses dan Modifikasi Properti Custom**

Aspose.Slides for Node.js via Java juga memungkinkan pengembang mengakses nilai properti custom. Contoh di bawah menunjukkan cara mengakses dan memodifikasi semua properti custom untuk sebuah presentasi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Buat referensi ke objek DocumentProperties yang terkait dengan Presentation
    var dp = pres.getDocumentProperties();
    // Akses dan modifikasi properti custom
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Tampilkan nama dan nilai properti custom
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Modifikasi nilai properti custom
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Simpan presentasi Anda ke file
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Contoh ini memodifikasi properti custom dari [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentation. Gambar berikut menampilkan properti custom presentasi sebelum dan sesudah modifikasi:

|**Properti Custom Sebelum Modifikasi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Properti Custom Setelah Modifikasi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Properti Dokumen Lanjutan**

{{% alert color="info" title="Catatan" %}}

Metode baru [ReadDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), dan [WriteBindedPresentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) telah ditambahkan ke [PresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo), logika setter properti [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) telah diubah.

{{% /alert %}} 

Dua metode baru [ReadDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) dan [UpdateDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) telah ditambahkan ke kelas [PresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo). Mereka menyediakan akses cepat ke properti dokumen dan memungkinkan perubahan serta pembaruan properti tanpa memuat seluruh presentasi.

Skenario tipikal: memuat properti, mengubah beberapa nilai, dan memperbarui dokumen dapat diimplementasikan sebagai berikut:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// baca informasi presentasi
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// dapatkan properti saat ini
var props = info.readDocumentProperties();
// setel nilai baru untuk bidang Author dan Title
props.setAuthor("New Author");
props.setTitle("New Title");
// perbarui presentasi dengan nilai baru
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Ada cara lain untuk menggunakan properti sebuah presentasi tertentu sebagai templat untuk memperbarui properti pada presentasi lain:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Template baru dapat dibuat dari awal dan kemudian digunakan untuk memperbarui banyak presentasi:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Set Proofing Language**

Aspose.Slides menyediakan properti LanguageId (diekspor oleh kelas PortionFormat) untuk memungkinkan Anda mengatur bahasa pemeriksaan ejaan untuk dokumen PowerPoint. Bahasa pemeriksaan ejaan adalah bahasa yang akan digunakan untuk memeriksa ejaan dan tata bahasa dalam PowerPoint.

Kode JavaScript ini menunjukkan cara mengatur bahasa pemeriksaan ejaan untuk PowerPoint: xxx Why is LanguageId missing from JavaScript PortionFormat class?

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// set the Id of a proofing language
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Default Language**

Kode JavaScript ini menunjukkan cara mengatur bahasa default untuk seluruh presentasi PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Menambahkan bentuk persegi panjang baru dengan teks
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // Memeriksa bahasa bagian pertama
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Contoh Langsung**

Coba aplikasi online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/id/metadata) untuk melihat cara bekerja dengan properti dokumen melalui API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/id/metadata)

## **FAQ**

**Bagaimana cara menghapus properti built‑in dari sebuah presentasi?**

Properti built‑in merupakan bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau mengosongkannya jika properti tersebut mengizinkan.

**Apa yang terjadi jika saya menambahkan properti custom yang sudah ada?**

Jika Anda menambahkan properti custom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut terlebih dahulu, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Dapatkah saya mengakses properti presentasi tanpa memuat seluruh presentasi?**

Ya. Gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) dan kemudian [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) untuk membaca metadata dokumen yang disimpan tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) . Lihat [Build a Lightweight Presentation Inventory](/slides/id/nodejs-java/examine-presentation/) untuk contoh pelaporan lengkap dan batasan spesifik format.

**Dapatkah saya membaca properti publik dari presentasi yang dienkripsi tanpa password pembukanya?**

Ya. Enkripsi properti dokumen harus dinonaktifkan sebelum presentasi dienkripsi, dan presentasi harus dimuat dalam mode “document‑properties‑only”.

**Dapatkah saya memperbarui file PPTX yang dienkripsi dalam mode “document‑properties‑only”?**

Tidak. Data properti publik dan terenkripsi harus tetap konsisten, sehingga memperbarui file PPTX yang dienkripsi memerlukan pemuatan lengkap presentasi dengan password pembuka yang tepat.