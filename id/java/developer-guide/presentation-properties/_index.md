---
title: Kelola Properti Presentasi di Java
linktitle: Properti Presentasi
type: docs
weight: 70
url: /id/java/presentation-properties/
keywords:
- Properti PowerPoint
- properti presentasi
- properti dokumen
- properti bawaan
- properti kustom
- properti lanjutan
- kelola properti
- modifikasi properti
- metadata dokumen
- sunting metadata
- bahasa pemeriksaan ejaan
- bahasa default
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Kuasai properti presentasi di Aspose.Slides untuk Java dan permudah pencarian, penjenamaan, serta alur kerja dalam file PowerPoint dan OpenDocument Anda."
---
## **Introduction**

Aspose.Slides mendukung dua jenis properti dokumen: **Built-in** dan **Custom**. Kedua jenis properti ini dapat dengan mudah diakses dan dikelola menggunakan API Aspose.Slides.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui antarmuka [IDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/idocumentproperties/) . Sebuah instance antarmuka ini dikembalikan oleh [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentation/#getDocumentProperties--). Contoh berikut menunjukkan cara membaca, memodifikasi, dan mengelola properti‑properti tersebut.

{{% alert color="info" title="Catatan" %}}
Harap dicatat bahwa bidang **Application** dan **AppVersion** tidak dapat dimodifikasi. Aspose.Slides menulis ulang keduanya pada setiap penyimpanan, sehingga presentasi yang disimpan selalu melaporkan "Aspose.Slides for Java" dan versi perpustakaan yang menghasilkan file tersebut. Nilai apa pun yang diberikan ke `setNameOfApplication` akan diabaikan saat presentasi ditulis.
{{% /alert %}}

## **Document Properties in PowerPoint**

Microsoft PowerPoint 2007 memungkinkan pengelolaan properti dokumen file presentasi. Yang perlu Anda lakukan hanyalah mengklik ikon Office dan kemudian memilih menu **Prepare | Properties | Advanced Properties** pada Microsoft PowerPoint 2007 seperti yang ditunjukkan di bawah ini:

|**Memilih item menu Properti Tingkat Lanjut**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Setelah Anda memilih menu **Advanced Properties**, sebuah dialog akan muncul yang memungkinkan Anda mengelola properti dokumen file PowerPoint seperti yang ditunjukkan pada gambar berikut:

|**Dialog Properti**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Di dalam **Dialog Properti** di atas, Anda dapat melihat banyak tab seperti **General**, **Summary**, **Statistics**, **Contents**, dan **Custom**. Semua tab ini memungkinkan konfigurasi berbagai jenis informasi yang terkait dengan file PowerPoint. Tab **Custom** digunakan untuk mengelola properti kustom file PowerPoint.

### **Working with Document Properties Using Aspose.Slides for Java**

Seperti yang telah kami jelaskan sebelumnya, Aspose.Slides for Java mendukung dua jenis properti dokumen, yaitu properti **Built-in** dan **Custom**. Oleh karena itu, pengembang dapat mengakses kedua jenis properti tersebut menggunakan API Aspose.Slides for Java. Aspose.Slides for Java menyediakan kelas [IDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/idocumentproperties) yang mewakili properti dokumen yang terkait dengan sebuah file presentasi melalui properti **Presentation.DocumentProperties**.

Pengembang dapat menggunakan properti **IDocumentProperties** yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation) untuk mengakses properti dokumen file presentasi seperti yang dijelaskan di bawah ini:

## **Read Public Properties from an Encrypted Presentation**

Kata sandi pembuka biasanya melindungi baik konten presentasi maupun properti dokumen. Ketika sebuah presentasi dienkripsi dengan mengirimkan `false` ke [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-), properti dokumennya tetap publik. Aplikasi kemudian dapat mengirimkan `true` ke [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) dan membaca metadata publik tanpa harus menyediakan kata sandi pembuka.

Opsi hanya‑memuat‑properti‑dokumen mengontrol apa yang dimuat oleh Aspose.Slides; ia tidak mendekripsi apa pun. Jika properti‑properti tersebut termasuk dalam enkripsi, memuatnya tanpa kata sandi akan gagal. Jika presentasi tidak dienkripsi, opsi ini diabaikan dan seluruh presentasi dimuat.

Contoh berikut memverifikasi mode pemuatan melalui [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/id/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) dan kemudian membaca properti built‑in melalui [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Dalam mode ini, konten slide tidak dimuat. Slide, master, layout, shape, media, dan objek presentasi lainnya tidak tersedia. Aplikasi sebaiknya selalu memeriksa [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/id/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) sebelum melakukan operasi yang memerlukan model objek presentasi lengkap.

{{% alert color="warning" title="Peringatan" %}}
Metadata publik dapat mengungkapkan nama penulis, judul, subjek, kata kunci, informasi perusahaan, komentar, dan nilai kustom. Enkripsi properti sensitif bersamaan dengan presentasi. Biarkan mereka publik hanya ketika sistem pengindeksan, klasifikasi, pencarian, atau manajemen dokumen memang membutuhkan akses tanpa kata sandi.
{{% /alert %}}

## **Update Properties of an Encrypted Presentation**

Untuk file PPTX yang dienkripsi, sebuah presentasi yang dimuat dalam mode hanya‑memuat‑properti‑dokumen ditujukan untuk membaca metadata publik. Aspose.Slides tidak dapat menyimpan properti yang diubah dari objek yang hanya berisi metadata karena properti publik harus tetap konsisten dengan data yang ada di dalam presentasi yang terenkripsi. Oleh karena itu pembaruan memerlukan kata sandi pembuka yang benar serta pemuatan lengkap.

Contoh berikut membuka presentasi dengan [LoadOptions.setPassword](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), memperbarui properti built‑in publik, dan menyimpan hasilnya. Kemudian contoh tersebut menggunakan [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) untuk memverifikasi bahwa enkripsi tetap terjaga dan membuka kembali metadata publik tanpa kata sandi untuk memeriksa nilai baru:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Jika sebuah aplikasi tidak diizinkan untuk mendekripsi atau memuat konten presentasi, maka harus memperlakukan properti publik dari file PPTX yang terenkripsi sebagai read‑only.

## **Access Built-in Properties**

Properti‑properti yang dipaparkan oleh objek [IDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/idocumentproperties) meliputi: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject**, dan **Title**.

```java
import com.aspose.slides.*;

// Buat instance kelas Presentation yang mewakili presentasi
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Buat referensi ke objek IDocumentProperties yang terkait dengan Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Tampilkan properti built-in
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modify Built-in Properties**

Memodifikasi properti built‑in file presentasi semudah mengaksesnya. Anda cukup menetapkan nilai string ke properti yang diinginkan dan nilai properti tersebut akan berubah. Pada contoh di bawah, kami menunjukkan cara memodifikasi properti dokumen built‑in dari file presentasi menggunakan Aspose.Slides for Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Buat referensi ke objek IDocumentProperties yang terkait dengan Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Set properti built-in
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Simpan presentasi Anda ke file
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Contoh ini memodifikasi properti built‑in presentasi yang dapat dilihat seperti berikut:

|**Properti dokumen built‑in setelah modifikasi**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Add Custom Document Properties**

Aspose.Slides for Java juga memungkinkan pengembang menambahkan nilai kustom untuk properti dokumen presentasi. Contoh di bawah menambahkan tiga properti kustom, kemudian mencari nama yang disimpan pada indeks 2 dan menghapus properti tersebut, sehingga presentasi yang disimpan menyisakan dua properti. Properti kustom diindeks secara alfabetik, bukan sesuai urutan penambahan.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Mendapatkan Properti Dokumen
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Menambahkan properti Kustom
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Mendapatkan nama properti pada indeks tertentu
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Menghapus properti yang dipilih
    dProps.removeCustomProperty(getPropertyName);
    
    // Menyimpan presentasi
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Properti Dokumen Kustom Ditambahkan**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Access and Modify Custom Properties**

Aspose.Slides for Java juga memungkinkan pengembang mengakses nilai properti kustom. Contoh di bawah menunjukkan cara mengakses dan memodifikasi semua properti kustom untuk sebuah presentasi.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Buat referensi ke objek DocumentProperties yang terkait dengan Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Akses dan modifikasi properti kustom
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Tampilkan nama dan nilai properti kustom
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Modifikasi nilai properti kustom
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Simpan presentasi Anda ke file
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Contoh ini memodifikasi properti kustom dari presentasi [PPTX](https://docs.fileformat.com/presentation/pptx/). Gambar berikut memperlihatkan properti kustom sebelum dan sesudah modifikasi:

|**Properti Kustom Sebelum Modifikasi**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Properti Kustom Setelah Modifikasi**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Advanced Document Properties**

{{% alert color="info" title="Catatan" %}}
Metode baru [ReadDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), dan [WriteBindedPresentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) telah ditambahkan ke [IPresentationInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPresentationInfo). Logika setter properti [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/id/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) telah diubah.
{{% /alert %}}

Kedua metode baru [ReadDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) dan [UpdateDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) telah ditambahkan ke antarmuka [IPresentationInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPresentationInfo). Mereka memberikan akses cepat ke properti dokumen dan memungkinkan perubahan serta pembaruan properti tanpa harus memuat seluruh presentasi.

Skenario tipikal memuat properti, mengubah beberapa nilai, dan memperbarui dokumen dapat diimplementasikan seperti berikut:

```java
import com.aspose.slides.*;

// baca info presentasi
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Ada cara lain untuk menggunakan properti sebuah presentasi tertentu sebagai templat untuk memperbarui properti pada presentasi lain:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

```java
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Templat baru dapat dibuat dari awal dan kemudian digunakan untuk memperbarui beberapa presentasi:

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Set Proofing Language**

Aspose.Slides menyediakan properti LanguageId (yang diekspos oleh kelas PortionFormat) untuk memungkinkan Anda mengatur bahasa pemeriksaan ejaan (proofing language) untuk dokumen PowerPoint. Bahasa pemeriksaan ejaan adalah bahasa yang digunakan untuk memeriksa ejaan dan tata bahasa dalam PowerPoint.

Potongan kode Java berikut menunjukkan cara mengatur bahasa pemeriksaan ejaan untuk PowerPoint:

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // atur Id bahasa pemeriksaan ejaan

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Default Language**

Potongan kode Java berikut menunjukkan cara mengatur bahasa default untuk seluruh presentasi PowerPoint:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Menambahkan bentuk persegi panjang baru dengan teks
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Memeriksa bahasa bagian pertama
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Live Example**

Coba aplikasi daring [**Aspose.Slides Metadata**](https://products.aspose.app/slides/id/metadata) untuk melihat cara bekerja dengan properti dokumen melalui API Aspose.Slides:

[![Lihat & Edit Metadata PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/id/metadata)

## **FAQ**

**Bagaimana cara menghapus properti built‑in dari sebuah presentasi?**

Properti built‑in merupakan bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau mengosongkannya jika properti tersebut mengizinkan.

**Apa yang terjadi jika saya menambahkan properti kustom yang sudah ada?**

Jika Anda menambahkan properti kustom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut sebelumnya, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Apakah saya dapat mengakses properti presentasi tanpa memuat seluruh presentasi?**

Ya. Gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) lalu [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) untuk membaca metadata dokumen yang disimpan tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/). Lihat contoh pelaporan lengkap pada [Build a Lightweight Presentation Inventory](/slides/id/java/examine-presentation/) serta batasan spesifik format.

**Apakah saya dapat membaca properti publik dari presentasi yang terenkripsi tanpa kata sandi pembukanya?**

Ya. Enkripsi properti dokumen harus dinonaktifkan sebelum presentasi dienkripsi, dan presentasi harus dimuat dalam mode hanya‑memuat‑properti‑dokumen.

**Apakah saya dapat memperbarui file PPTX yang terenkripsi dalam mode hanya‑memuat‑properti‑dokumen?**

Tidak. Data properti publik dan terenkripsi harus tetap konsisten, sehingga memperbarui file PPTX yang terenkripsi memerlukan pemuatan lengkap presentasi dengan kata sandi pembuka yang benar.