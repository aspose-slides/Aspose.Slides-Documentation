---
title: Kelola Properti Presentasi di Java
linktitle: Properti Presentasi
type: docs
weight: 70
url: /id/java/presentation-properties/
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
- presentasi
- Java
- Aspose.Slides
description: "Kuasi properti presentasi di Aspose.Slides untuk Java dan permudah pencarian, branding, serta alur kerja dalam file PowerPoint dan OpenDocument Anda."
---
## **Pengantar**

Aspose.Slides mendukung dua jenis properti dokumen: **Built-in** dan **Custom**. Kedua jenis properti ini dapat dengan mudah diakses dan dikelola menggunakan API Aspose.Slides.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui antarmuka [IDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/idocumentproperties/) . Sebuah instance antarmuka ini dikembalikan oleh metode [Presentation.getDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getDocumentProperties--) . Contoh-contoh berikut menunjukkan cara membaca, memodifikasi, dan mengelola properti ini.

{{% alert color="info" title="Note" %}}
Harap dicatat bahwa bidang **Application** dan **AppVersion** tidak dapat diubah. Aspose.Slides menulis ulang bidang tersebut pada setiap penyimpanan, sehingga presentasi yang disimpan selalu melaporkan "Aspose.Slides for Java" dan versi pustaka yang menghasilkan presentasi tersebut. Setiap nilai yang diberikan ke `setNameOfApplication` akan diabaikan ketika presentasi ditulis.
{{% /alert %}} 

## **Properti Dokumen di PowerPoint**

Microsoft PowerPoint 2007 memungkinkan pengelolaan properti dokumen file presentasi. Yang perlu Anda lakukan adalah mengklik ikon Office dan kemudian pilih menu **Prepare | Properties | Advanced Properties** pada Microsoft PowerPoint 2007 seperti yang ditunjukkan di bawah ini:

|**Memilih item menu Advanced Properties**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)||

Setelah Anda memilih item menu **Advanced Properties**, sebuah dialog akan muncul yang memungkinkan Anda mengelola properti dokumen file PowerPoint seperti yang ditunjukkan pada gambar di bawah ini:

|**Dialog Properti**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)||

Pada **Dialog Properti** di atas, Anda dapat melihat bahwa terdapat banyak tab seperti **General**, **Summary**, **Statistics**, **Contents**, dan **Custom**. Semua tab ini memungkinkan konfigurasi berbagai informasi yang berhubungan dengan file PowerPoint. Tab **Custom** digunakan untuk mengelola properti khusus file PowerPoint.

### Bekerja dengan Properti Dokumen Menggunakan Aspose.Slides untuk Java

Seperti yang telah kami jelaskan sebelumnya, Aspose.Slides untuk Java mendukung dua jenis properti dokumen, yaitu properti **Built-in** dan **Custom**. Jadi, pengembang dapat mengakses kedua jenis properti tersebut menggunakan API Aspose.Slides untuk Java. Aspose.Slides untuk Java menyediakan kelas [IDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/idocumentproperties) yang merepresentasikan properti dokumen yang terkait dengan file presentasi melalui properti **Presentation.DocumentProperties**.

Pengembang dapat menggunakan properti **IDocumentProperties** yang diekspose oleh objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation) untuk mengakses properti dokumen file presentasi sebagaimana dijelaskan di bawah ini:

## **Akses Properti Built-in**

Properti-properti yang diekspos oleh objek [IDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/idocumentproperties) meliputi: **Creator** (Penulis), **Description**, **Keywords**, **Created** (Tanggal Pembuatan), **Modified** (Tanggal Modifikasi), **Printed** (Tanggal Cetak Terakhir), **LastModifiedBy**, **Keywords**, **SharedDoc** (Apakah dibagi antara produsen yang berbeda?), **PresentationFormat**, **Subject**, dan **Title**.

```java
import com.aspose.slides.*;

// Membuat instance kelas Presentation yang mewakili presentasi
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Membuat referensi ke objek IDocumentProperties yang terkait dengan Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Menampilkan properti bawaan
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

## **Modifikasi Properti Built-in**

Memodifikasi properti built-in file presentasi semudah mengaksesnya. Anda cukup menetapkan nilai string ke properti yang diinginkan dan nilai properti tersebut akan berubah. Pada contoh di bawah, kami menunjukkan cara memodifikasi properti dokumen built-in file presentasi menggunakan Aspose.Slides untuk Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Buat referensi ke objek IDocumentProperties yang terkait dengan Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Set properti bawaan
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

Contoh ini memodifikasi properti built-in presentasi yang dapat dilihat seperti ditunjukkan di bawah ini:

|**Properti dokumen built-in setelah modifikasi**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)||

## **Menambahkan Properti Dokumen Kustom**

Aspose.Slides untuk Java juga memungkinkan pengembang menambahkan nilai kustom untuk properti Dokumen presentasi. Contoh di bawah menambahkan tiga properti kustom, kemudian mencari nama yang disimpan pada indeks 2 dan menghapus properti tersebut, sehingga presentasi yang disimpan menyisakan dua properti. Properti kustom diindeks secara alfabetik, bukan berdasarkan urutan penambahan.

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

|**Properti Dokumen Kustom Ditambahkan**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)||

## **Akses dan Modifikasi Properti Kustom**

Aspose.Slides untuk Java juga memungkinkan pengembang mengakses nilai properti kustom. Contoh di bawah menunjukkan cara mengakses dan memodifikasi semua properti kustom untuk sebuah presentasi.

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

Contoh ini memodifikasi properti kustom dari presentasi [PPTX](https://docs.fileformat.com/presentation/pptx/). Gambar berikut menunjukkan properti kustom presentasi sebelum dan sesudah modifikasi:

|**Properti Kustom sebelum Modifikasi**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)||

|**Properti Kustom setelah Modifikasi**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)||

## **Properti Dokumen Tingkat Lanjut**

{{% alert color="info" title="Note" %}}
Metode baru [ReadDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), dan [WriteBindedPresentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) telah ditambahkan ke [IPresentationInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPresentationInfo), logika setter properti [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/id/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) telah diubah.
{{% /alert %}} 

Metode baru [ReadDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) dan [UpdateDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) telah ditambahkan ke antarmuka [IPresentationInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPPresentationInfo). Mereka memberikan akses cepat ke properti dokumen dan memungkinkan mengubah serta memperbarui properti tanpa memuat seluruh presentasi.

Skenario umum memuat properti, mengubah beberapa nilai, dan memperbarui dokumen dapat diimplementasikan dengan cara berikut:

```java
import com.aspose.slides.*;

// baca informasi presentasi
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// peroleh properti saat ini
IDocumentProperties props = info.readDocumentProperties();

// atur nilai baru untuk bidang Author dan Title
props.setAuthor("New Author");
props.setTitle("New Title");

// perbarui presentasi dengan nilai baru
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Ada cara lain untuk menggunakan properti sebuah presentasi tertentu sebagai templat untuk memperbarui properti di presentasi lain:

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

Template baru dapat dibuat dari awal dan kemudian digunakan untuk memperbarui banyak presentasi:

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

## **Atur Bahasa Pemeriksaan**

Aspose.Slides menyediakan properti LanguageId (diekspos oleh kelas PortionFormat) untuk memungkinkan Anda mengatur bahasa pemeriksaan ejaan untuk dokumen PowerPoint. Bahasa pemeriksaan adalah bahasa yang digunakan untuk memeriksa ejaan dan tata bahasa dalam PowerPoint.

Kode Java berikut menunjukkan cara mengatur bahasa pemeriksaan untuk PowerPoint:

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

    portionFormat.setLanguageId("zh-CN"); // atur Id bahasa pemeriksaan

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Atur Bahasa Default**

Kode Java berikut menunjukkan cara mengatur bahasa default untuk seluruh presentasi PowerPoint:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Tambahkan bentuk persegi panjang baru dengan teks
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Periksa bahasa bagian pertama
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Contoh Langsung**

Coba aplikasi daring [**Aspose.Slides Metadata**](https://products.aspose.app/slides/id/metadata) untuk melihat cara bekerja dengan properti dokumen melalui API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/id/metadata)

## **FAQ**

**Bagaimana cara menghapus properti built-in dari sebuah presentasi?**

Properti built-in merupakan bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau mengosongkannya jika properti tersebut mengizinkan.

**Apa yang terjadi jika saya menambahkan properti kustom yang sudah ada?**

Jika Anda menambahkan properti kustom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut terlebih dahulu, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Apakah saya dapat mengakses properti presentasi tanpa memuat seluruh presentasi?**

Ya. Gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) lalu [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) untuk membaca metadata dokumen yang disimpan tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/). Lihat [Build a Lightweight Presentation Inventory](/slides/id/java/examine-presentation/) untuk contoh pelaporan lengkap dan batasan format tertentu.