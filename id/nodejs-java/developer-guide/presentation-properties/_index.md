---
title: Kelola Properti Presentasi dalam JavaScript
linktitle: Properti Presentasi
type: docs
weight: 70
url: /id/nodejs-java/presentation-properties/
keywords:
- properti PowerPoint
- properti presentasi
- properti dokumen
- properti bawaan
- properti kustom
- properti lanjutan
- mengelola properti
- memodifikasi properti
- metadata dokumen
- mengedit metadata
- bahasa pemeriksaan
- bahasa default
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kuasai properti presentasi di Aspose.Slides untuk Node.js via Java dan tingkatkan pencarian, branding, serta alur kerja dalam file PowerPoint dan OpenDocument Anda."
---
## **Pendahuluan**

Aspose.Slides mendukung dua jenis properti dokumen: **Bawaan** dan **Kustom**. Kedua jenis properti ini dapat dengan mudah diakses dan dikelola menggunakan API Aspose.Slides.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui kelas [DocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/). Sebuah instance dari kelas ini dikembalikan oleh metode [Presentation.getDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getDocumentProperties). Contoh berikut menunjukkan cara membaca, memodifikasi, dan mengelola properti‑properti tersebut.

{{% alert color="info" title="Note" %}}
Harap dicatat bahwa bidang **Application** dan **AppVersion** tidak dapat diubah. Aspose.Slides menulis ulang keduanya pada setiap penyimpanan, sehingga presentasi yang disimpan selalu melaporkan “Aspose.Slides for Node.js via Java” dan versi perpustakaan yang menghasilkan file tersebut. Nilai apapun yang diberikan ke `setNameOfApplication` akan diabaikan saat presentasi ditulis.
{{% /alert %}}

## **Kelola Properti Presentasi**

Microsoft PowerPoint menyediakan fitur untuk menambahkan beberapa properti ke file presentasi. Properti dokumen ini memungkinkan penyimpanan informasi berguna bersama dengan dokumen (file presentasi). Ada dua jenis properti dokumen sebagai berikut:

- Properti yang Ditentukan Sistem (Bawaan)
- Properti yang Ditentukan Pengguna (Kustom)

Properti **Bawaan** berisi informasi umum tentang dokumen seperti judul dokumen, nama penulis, statistik dokumen, dan sebagainya. Properti **Kustom** adalah pasangan **Nama/Nilai** yang didefinisikan oleh pengguna, di mana baik nama maupun nilai ditentukan oleh pengguna. Menggunakan Aspose.Slides for Node.js via Java, pengembang dapat mengakses dan memodifikasi nilai properti bawaan maupun properti kustom.

## **Properti Dokumen di PowerPoint**

Microsoft PowerPoint 2007 memungkinkan pengelolaan properti dokumen file presentasi. Yang perlu Anda lakukan hanyalah mengklik ikon Office dan kemudian memilih menu **Prepare | Properties | Advanced Properties** pada Microsoft PowerPoint 2007 seperti yang ditunjukkan di bawah ini:

|**Memilih item menu Advanced Properties**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Setelah Anda memilih item menu **Advanced Properties**, sebuah dialog akan muncul yang memungkinkan Anda mengelola properti dokumen file PowerPoint seperti yang ditunjukkan pada gambar di bawah:

|**Dialog Properti**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Di dalam **Dialog Properti** di atas, Anda dapat melihat banyak tab seperti **General**, **Summary**, **Statistics**, **Contents**, dan **Custom**. Semua tab ini memungkinkan konfigurasi berbagai jenis informasi terkait file PowerPoint. Tab **Custom** digunakan untuk mengelola properti kustom file PowerPoint.

### Bekerja dengan Properti Dokumen Menggunakan Aspose.Slides for Node.js via Java

Seperti yang telah dijelaskan sebelumnya, Aspose.Slides for Node.js via Java mendukung dua jenis properti dokumen, yaitu **Bawaan** dan **Kustom**. Oleh karena itu, pengembang dapat mengakses kedua jenis properti tersebut melalui API Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java menyediakan kelas [DocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties) yang merepresentasikan properti dokumen yang terkait dengan file presentasi melalui properti **Presentation.DocumentProperties**.

Pengembang dapat menggunakan properti **DocumentProperties** yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation) untuk mengakses properti dokumen file presentasi seperti dijelaskan di bawah ini:

## **Akses Properti Bawaan**

Properti yang diekspos oleh objek [DocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties) meliputi: **Creator** (Penulis), **Description**, **Keywords**, **Created** (Tanggal Pembuatan), **Modified** (Tanggal Modifikasi), **Printed** (Tanggal Cetak Terakhir), **LastModifiedBy**, **SharedDoc** (Apakah dibagikan antar produsen?), **PresentationFormat**, **Subject**, dan **Title**.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Membuat instance kelas Presentation yang merepresentasikan presentasi
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Membuat referensi ke objek IDocumentProperties yang terkait dengan Presentation
    var dp = pres.getDocumentProperties();
    // Menampilkan properti bawaan
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

## **Modifikasi Properti Bawaan**

Memodifikasi properti bawaan file presentasi semudah mengaksesnya. Anda cukup menetapkan nilai string ke properti yang diinginkan dan nilai properti tersebut akan berubah. Pada contoh di bawah, kami mendemonstrasikan cara memodifikasi properti dokumen bawaan file presentasi menggunakan Aspose.Slides for Node.js via Java.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Membuat referensi ke objek IDocumentProperties yang terkait dengan Presentation
    var dp = pres.getDocumentProperties();
    // Atur properti bawaan
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

Contoh ini memodifikasi properti bawaan presentasi yang dapat dilihat seperti berikut:

|**Properti dokumen bawaan setelah modifikasi**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Menambahkan Properti Dokumen Kustom**

Aspose.Slides for Node.js via Java juga memungkinkan pengembang menambahkan nilai kustom untuk properti dokumen presentasi. Contoh di bawah menunjukkan cara menetapkan properti kustom untuk sebuah presentasi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Mendapatkan Properti Dokumen
    var dProps = pres.getDocumentProperties();
    // Menambahkan properti Kustom
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Mendapatkan nama properti pada indeks tertentu
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Menghapus properti yang dipilih
    dProps.removeCustomProperty(getPropertyName);
    // Menyimpan presentasi
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Properti Dokumen Kustom yang Ditambahkan**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Akses dan Modifikasi Properti Kustom**

Aspose.Slides for Node.js via Java juga memungkinkan pengembang mengakses nilai properti kustom. Contoh di bawah menunjukkan cara mengakses dan memodifikasi semua properti kustom untuk sebuah presentasi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Buat referensi ke objek DocumentProperties yang terkait dengan Presentation
    var dp = pres.getDocumentProperties();
    // Akses dan modifikasi properti kustom
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Tampilkan nama dan nilai properti kustom
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Modifikasi nilai properti kustom
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

Contoh ini memodifikasi properti kustom dari presentasi [PPTX](https://docs.fileformat.com/presentation/pptx/). Gambar berikut memperlihatkan properti kustom presentasi sebelum dan sesudah modifikasi:

|**Properti Kustom Sebelum Modifikasi**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Properti Kustom Setelah Modifikasi**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Properti Dokumen Lanjutan**

{{% alert color="info" title="Note" %}}
Metode baru [ReadDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), dan [WriteBindedPresentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) telah ditambahkan ke [PresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo); logika setter properti [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) telah diubah.
{{% /alert %}}

Dua metode baru [ReadDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) dan [UpdateDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) telah ditambahkan ke kelas [PresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo). Metode ini memberikan akses cepat ke properti dokumen dan memungkinkan perubahan serta pembaruan properti tanpa memuat seluruh presentasi.

Skenario tipikal: memuat properti, mengubah beberapa nilai, dan memperbarui dokumen dapat diimplementasikan sebagai berikut:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// baca info presentasi
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// obtain the current properties
var props = info.readDocumentProperties();
// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");
// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Ada cara lain untuk menggunakan properti presentasi tertentu sebagai templat untuk memperbarui properti di presentasi lain:

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

Sebuah templat baru dapat dibuat dari awal dan kemudian digunakan untuk memperbarui banyak presentasi:

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

## **Set Bahasa Pemeriksaan (Proofing Language)**

Aspose.Slides menyediakan properti LanguageId (diekspos oleh kelas PortionFormat) untuk memungkinkan Anda mengatur bahasa pemeriksaan (proofing) untuk dokumen PowerPoint. Bahasa pemeriksaan adalah bahasa yang digunakan untuk memeriksa ejaan dan tata bahasa di PowerPoint.

Kode JavaScript berikut menunjukkan cara mengatur bahasa pemeriksaan untuk PowerPoint: xxx Mengapa LanguageId tidak ada pada kelas PortionFormat di JavaScript?

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
    portionFormat.setLanguageId("zh-CN");// set Id bahasa pemeriksaan
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Bahasa Default**

Kode JavaScript berikut menunjukkan cara mengatur bahasa default untuk seluruh presentasi PowerPoint:

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

Coba aplikasi daring [**Aspose.Slides Metadata**](https://products.aspose.app/slides/id/metadata) untuk melihat cara bekerja dengan properti dokumen melalui API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/id/metadata)

## **FAQ**

**Bagaimana cara menghapus properti bawaan dari sebuah presentasi?**

Properti bawaan merupakan bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau mengosongkannya bila diperbolehkan oleh properti tersebut.

**Apa yang terjadi jika saya menambahkan properti kustom yang sudah ada?**

Jika Anda menambahkan properti kustom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut terlebih dahulu, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Apakah saya dapat mengakses properti presentasi tanpa memuat seluruh presentasi?**

Ya. Gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) lalu [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) untuk membaca metadata dokumen yang disimpan tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/). Lihat [Build a Lightweight Presentation Inventory](/slides/id/nodejs-java/examine-presentation/) untuk contoh pelaporan lengkap dan batasan spesifik format.