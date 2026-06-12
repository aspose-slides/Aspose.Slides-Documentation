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
- Bahasa pemeriksaan
- Bahasa default
- PowerPoint
- OpenDocument
- Presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kuasi properti presentasi di Aspose.Slides untuk Node.js via Java dan permudah pencarian, branding, serta alur kerja dalam file PowerPoint dan OpenDocument Anda."
---
## **Pendahuluan**

Aspose.Slides mendukung dua jenis properti dokumen: **Built-in** dan **Custom**. Kedua jenis properti ini dapat dengan mudah diakses dan dikelola menggunakan API Aspose.Slides.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui kelas [DocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/) . Sebuah instance kelas ini dikembalikan oleh metode [Presentation.getDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getDocumentProperties) . Contoh-contoh berikut menunjukkan cara membaca, memodifikasi, dan mengelola properti-properti ini.

{{% alert color="primary" %}} 

Harap dicatat bahwa Anda tidak dapat mengatur nilai untuk bidang **Application** dan **Producer**, karena Aspose Ltd. dan Aspose.Slides for Node.js via Java x.x.x akan ditampilkan pada bidang tersebut.

{{% /alert %}} 

## **Kelola Properti Presentasi**

Microsoft PowerPoint menyediakan fitur untuk menambahkan beberapa properti ke file presentasi. Properti dokumen ini memungkinkan informasi berguna disimpan bersama dokumen (file presentasi). Ada dua jenis properti dokumen sebagai berikut

- Properti yang Didefinisikan Sistem (Built-in)
- Properti yang Didefinisikan Pengguna (Custom)

**Built-in** properti berisi informasi umum tentang dokumen seperti judul dokumen, nama penulis, statistik dokumen, dan lain-lain. **Custom** properti adalah properti yang didefinisikan pengguna sebagai pasangan **Name/Value**, di mana nama dan nilai ditentukan oleh pengguna. Dengan menggunakan Aspose.Slides for Node.js via Java, pengembang dapat mengakses dan memodifikasi nilai properti built-in maupun custom.

## **Properti Dokumen di PowerPoint**

Microsoft PowerPoint 2007 memungkinkan pengelolaan properti dokumen file presentasi. Yang perlu Anda lakukan hanyalah mengklik ikon Office dan kemudian menu **Prepare | Properties | Advanced Properties** pada Microsoft PowerPoint 2007 seperti yang ditunjukkan di bawah ini:

|**Memilih item menu Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Setelah Anda memilih item menu **Advanced Properties**, sebuah dialog akan muncul yang memungkinkan Anda mengelola properti dokumen file PowerPoint seperti yang ditampilkan pada gambar berikut:

|**Dialog Properti**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Pada **Dialog Properti** di atas, Anda dapat melihat banyak halaman tab seperti **General**, **Summary**, **Statistics**, **Contents**, dan **Custom**. Semua halaman tab ini memungkinkan konfigurasi berbagai informasi terkait file PowerPoint. Tab **Custom** digunakan untuk mengelola properti custom file PowerPoint.

### Bekerja dengan Properti Dokumen Menggunakan Aspose.Slides for Node.js via Java

Seperti yang dijelaskan sebelumnya, Aspose.Slides for Node.js via Java mendukung dua jenis properti dokumen, yaitu **Built-in** dan **Custom**. Oleh karena itu, pengembang dapat mengakses kedua jenis properti tersebut dengan menggunakan API Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java menyediakan kelas [DocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties) yang mewakili properti dokumen yang terkait dengan file presentasi melalui properti **Presentation.DocumentProperties**.

Pengembang dapat menggunakan properti **DocumentProperties** yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation) untuk mengakses properti dokumen file presentasi seperti yang dijelaskan di bawah ini:

## **Akses Properti Built-in**

Properti yang diekspos oleh objek [DocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties) meliputi: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject**, dan **Title**.

```javascript
// Membuat instance kelas Presentation yang mewakili presentasi
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

## **Modifikasi Properti Built-in**

Memodifikasi properti built-in file presentasi semudah mengaksesnya. Anda cukup menetapkan nilai string ke properti yang diinginkan dan nilai properti tersebut akan berubah. Pada contoh di bawah, kami menunjukkan cara memodifikasi properti dokumen built-in file presentasi menggunakan Aspose.Slides for Node.js via Java.

```javascript
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

Contoh ini memodifikasi properti built-in presentasi yang dapat dilihat seperti berikut:

|**Properti dokumen Built-in setelah modifikasi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Tambah Properti Dokumen Custom**

Aspose.Slides for Node.js via Java juga memungkinkan pengembang menambahkan nilai custom untuk properti dokumen presentasi. Contoh di bawah menunjukkan cara mengatur properti custom untuk sebuah presentasi.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Mendapatkan Properti Dokumen
    var dProps = pres.getDocumentProperties();
    // Menambahkan properti Custom
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

|**Properti Dokumen Custom Ditambahkan**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Akses dan Modifikasi Properti Custom**

Aspose.Slides for Node.js via Java juga memungkinkan pengembang mengakses nilai properti custom. Contoh di bawah menunjukkan cara mengakses dan memodifikasi semua properti custom untuk sebuah presentasi.

```javascript
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

Contoh ini memodifikasi properti custom dari presentasi [PPTX](https://docs.fileformat.com/presentation/pptx/). Gambar berikut menampilkan properti custom presentasi sebelum dan sesudah modifikasi:

|**Properti Custom sebelum Modifikasi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Properti Custom setelah Modifikasi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Properti Dokumen Lanjutan**

{{% alert color="primary" %}} 

Metode baru [ReadDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), dan [WriteBindedPresentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) telah ditambahkan ke [PresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo), logika setter properti [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) telah diubah.

{{% /alert %}} 

Dua metode baru [ReadDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) dan [UpdateDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) telah ditambahkan ke kelas [PresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo). Mereka menyediakan akses cepat ke properti dokumen dan memungkinkan perubahan serta pembaruan properti tanpa memuat seluruh presentasi.

Skenario tipikal memuat properti, mengubah nilai tertentu, dan memperbarui dokumen dapat diimplementasikan dengan cara berikut:

```javascript
// baca informasi presentasi
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// dapatkan properti saat ini
var props = info.readDocumentProperties();
// atur nilai baru untuk bidang Author dan Title
props.setAuthor("New Author");
props.setTitle("New Title");
// perbarui presentasi dengan nilai-nilai baru
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Ada cara lain untuk menggunakan properti sebuah presentasi tertentu sebagai template untuk memperbarui properti pada presentasi lain:

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Template baru dapat dibuat dari awal dan kemudian digunakan untuk memperbarui beberapa presentasi:

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Set Bahasa Pemeriksaan**

Aspose.Slides menyediakan properti LanguageId (diekspos oleh kelas PortionFormat) untuk memungkinkan Anda mengatur bahasa pemeriksaan pada dokumen PowerPoint. Bahasa pemeriksaan adalah bahasa yang digunakan untuk memeriksa ejaan dan tata bahasa di PowerPoint.

Kode JavaScript ini menunjukkan cara mengatur bahasa pemeriksaan untuk PowerPoint: xxx Mengapa LanguageId tidak ada pada kelas JavaScript PortionFormat?

```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
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

## **Set Bahasa Default**

Kode JavaScript ini menunjukkan cara mengatur bahasa default untuk seluruh presentasi PowerPoint:

```javascript
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

Coba aplikasi online **[Aspose.Slides Metadata](https://products.aspose.app/slides/id/metadata)** untuk melihat cara bekerja dengan properti dokumen melalui API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/id/metadata)

## ***FAQ**

**Bagaimana cara menghapus properti built-in dari sebuah presentasi?**

Properti built-in merupakan bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau mengosongkannya jika properti tersebut mengizinkan.

**Apa yang terjadi jika saya menambahkan properti custom yang sudah ada?**

Jika Anda menambahkan properti custom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut terlebih dahulu, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Apakah saya dapat mengakses properti presentasi tanpa memuat seluruh presentasi?**

Ya, Anda dapat mengakses properti presentasi tanpa memuat seluruh presentasi dengan menggunakan metode `getPresentationInfo` dari kelas [PresentationFactory](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationfactory/) . Kemudian, manfaatkan metode `readDocumentProperties` yang disediakan oleh kelas [PresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/) untuk membaca properti secara efisien, menghemat memori, dan meningkatkan kinerja.