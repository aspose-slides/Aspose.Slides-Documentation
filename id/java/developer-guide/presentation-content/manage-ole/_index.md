---
title: Kelola OLE dalam Presentasi dengan Java
linktitle: Kelola OLE
type: docs
weight: 40
url: /id/java/manage-ole/
keywords:
- objek OLE
- Tautan & Penyematan Objek
- tambahkan OLE
- sematkan OLE
- tambahkan objek
- sematkan objek
- tambahkan file
- sematkan file
- objek tertaut
- file tertaut
- ubah OLE
- ikon OLE
- judul OLE
- ekstrak OLE
- ekstrak objek
- ekstrak file
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Optimalkan manajemen objek OLE dalam file PowerPoint dan OpenDocument dengan Aspose.Slides untuk Java. Sematkan, perbarui, dan ekspor konten OLE secara mulus."
---
## **Pendahuluan**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) adalah teknologi Microsoft yang memungkinkan data dan objek yang dibuat di satu aplikasi ditempatkan di aplikasi lain melalui penautan atau penyematan. 

{{% /alert %}} 

Pertimbangkan sebuah diagram yang dibuat di MS Excel. Diagram tersebut kemudian ditempatkan di dalam slide PowerPoint. Diagram Excel itu dianggap sebagai objek OLE. 

- Sebuah objek OLE dapat muncul sebagai ikon. Dalam hal ini, ketika Anda mengklik ganda ikon, diagram akan terbuka di aplikasi terkait (Excel), atau Anda akan diminta untuk memilih aplikasi untuk membuka atau mengedit objek tersebut.
- Sebuah objek OLE dapat menampilkan isi sebenarnya, seperti isi sebuah diagram. Dalam hal ini, diagram diaktifkan di PowerPoint, antarmuka diagram dimuat, dan Anda dapat memodifikasi data diagram di dalam PowerPoint.

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) memungkinkan Anda menyisipkan OLE Objects ke dalam slide sebagai bingkai objek OLE ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **Menambahkan Bingkai Objek OLE ke Slide**

Dengan asumsi Anda telah membuat sebuah diagram di Microsoft Excel dan ingin menyematkannya ke dalam slide sebagai bingkai objek OLE menggunakan Aspose.Slides for Java, Anda dapat melakukannya dengan cara berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Dapatkan referensi slide melalui indeksnya.
1. Baca file Excel sebagai array byte.
1. Tambahkan [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) ke slide yang berisi array byte dan informasi lain tentang objek OLE.
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Dalam contoh di bawah ini, kami menambahkan sebuah diagram dari file Excel ke slide sebagai bingkai objek OLE menggunakan Aspose.Slides for Java.  
**Catatan** bahwa konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) menerima ekstensi objek yang dapat disematkan sebagai parameter kedua. Ekstensi ini memungkinkan PowerPoint untuk menafsirkan jenis file dengan benar dan memilih aplikasi yang tepat untuk membuka objek OLE ini.

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Siapkan data untuk objek OLE.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Tambahkan bingkai objek OLE ke slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Menambahkan Bingkai OLE yang Ditautkan**

Aspose.Slides for Java memungkinkan Anda menambahkan sebuah [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) tanpa menyematkan data tetapi hanya dengan tautan ke file.

Kode Java ini menunjukkan cara menambahkan [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) dengan file Excel yang ditautkan ke slide:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Tambahkan bingkai objek OLE dengan file Excel yang ditautkan.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Mengakses Bingkai Objek OLE**

Jika sebuah objek OLE sudah disematkan dalam slide, Anda dapat dengan mudah menemukannya atau mengaksesnya dengan cara berikut:

1. Muat presentasi yang berisi objek OLE yang disematkan dengan membuat instance dari kelas [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Dapatkan referensi slide dengan menggunakan indeksnya.
3. Akses shape [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame).  
   Dalam contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang hanya memiliki satu shape pada slide pertama. Kami kemudian *cast* objek tersebut sebagai [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Ini adalah bingkai objek OLE yang diinginkan untuk diakses.
4. Setelah bingkai objek OLE diakses, Anda dapat melakukan operasi apa pun padanya.

Dalam contoh di bawah ini, sebuah bingkai objek OLE (objek diagram Excel yang disematkan dalam slide) dan data file-nya diakses.

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Dapatkan data file yang disematkan.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Dapatkan ekstensi file yang disematkan.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Mengakses Properti Bingkai OLE yang Ditautkan**

Aspose.Slides memungkinkan Anda mengakses properti bingkai OLE yang ditautkan.

Kode Java ini menunjukkan cara memeriksa apakah sebuah objek OLE ditautkan dan kemudian memperoleh path ke file yang ditautkan:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Periksa apakah objek OLE ditautkan.
    if (oleFrame.isObjectLink()) {
        // Cetak jalur lengkap ke file yang ditautkan.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Cetak jalur relatif ke file yang ditautkan jika ada.
        // Hanya presentasi PPT yang dapat berisi jalur relatif.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Mengubah Data Objek OLE**

{{% alert color="info" title="Note" %}}

Pada bagian ini, contoh kode di bawah ini menggunakan [Aspose.Cells for Java](https://docs.aspose.com/cells/java/).

{{% /alert %}}

Jika sebuah objek OLE sudah disematkan dalam slide, Anda dapat dengan mudah mengakses objek tersebut dan memodifikasi datanya dengan cara berikut:

1. Muat presentasi yang berisi objek OLE yang disematkan dengan membuat instance dari kelas [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses shape bingkai objek OLE.  
   Dalam contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang memiliki satu shape pada slide pertama. Kami kemudian *cast* objek tersebut sebagai [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Ini adalah bingkai objek OLE yang diinginkan untuk diakses.
4. Setelah bingkai objek OLE diakses, Anda dapat melakukan operasi apa pun padanya.
5. Buat objek `Workbook` dan akses data OLE.
6. Akses `Worksheet` yang diinginkan dan ubah datanya.
7. Simpan `Workbook` yang telah diperbarui ke dalam stream.
8. Ganti data objek OLE dari stream.

Dalam contoh di bawah ini, sebuah bingkai objek OLE (objek diagram Excel yang disematkan dalam slide) diakses, dan data file-nya dimodifikasi untuk memperbarui data diagram.

``` java 
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Baca data objek OLE sebagai objek Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Ubah data workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Ubah data objek bingkai OLE.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Menyematkan Jenis File Lain ke Slide**

Selain diagram Excel, Aspose.Slides for Java memungkinkan Anda menyematkan jenis file lain ke dalam slide. Misalnya, Anda dapat menyisipkan file HTML, PDF, dan ZIP sebagai objek. Ketika pengguna mengklik ganda objek yang disisipkan, objek tersebut secara otomatis terbuka di program yang relevan, atau pengguna akan diminta untuk memilih program yang sesuai untuk membukanya.

Kode Java ini menunjukkan cara menyematkan HTML dan ZIP ke dalam slide:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Menetapkan Jenis File untuk Objek yang Disematkan**

Saat bekerja dengan presentasi, Anda mungkin perlu mengganti objek OLE lama dengan yang baru atau mengganti objek OLE yang tidak didukung dengan yang didukung. Aspose.Slides for Java memungkinkan Anda menetapkan jenis file untuk objek yang disematkan, sehingga Anda dapat memperbarui data bingkai OLE atau ekstensi file-nya.

Kode Java ini menunjukkan cara menetapkan jenis file untuk objek OLE yang disematkan menjadi `zip`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Menetapkan Gambar Ikon dan Judul untuk Objek yang Disematkan**

Setelah menyematkan sebuah objek OLE, pratinjau yang terdiri dari gambar ikon ditambahkan secara otomatis. Pratinjau ini yang dilihat pengguna sebelum mengakses atau membuka objek OLE. Jika Anda ingin menggunakan gambar dan teks tertentu sebagai elemen dalam pratinjau, Anda dapat menetapkan gambar ikon dan judul menggunakan Aspose.Slides for Java.

Kode Java ini menunjukkan cara menetapkan gambar ikon dan judul untuk objek yang disematkan:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Tambahkan gambar ke sumber daya presentasi.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Atur judul dan gambar untuk pratinjau OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Mencegah Bingkai Objek OLE Diubah Ukuran dan Posisinya**

Setelah Anda menambahkan objek OLE yang ditautkan ke slide presentasi, ketika Anda membuka presentasi di PowerPoint, Anda mungkin melihat pesan yang meminta Anda memperbarui tautan. Mengklik tombol "Update Links" dapat mengubah ukuran dan posisi bingkai objek OLE karena PowerPoint memperbarui data dari objek OLE yang ditautkan dan menyegarkan pratinjau objek. Untuk mencegah PowerPoint meminta pembaruan data objek, panggil metode [setUpdateAutomatic](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) pada antarmuka [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) dengan `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Mengekstrak File yang Disematkan**

Aspose.Slides for Java memungkinkan Anda mengekstrak file yang disematkan dalam slide sebagai objek OLE dengan cara berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) yang berisi objek OLE yang ingin Anda ekstrak.
2. Loop melalui semua shape dalam presentasi dan akses shape [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe).
3. Akses data file yang disematkan dari bingkai objek OLE dan tulis ke disk.

Kode Java ini menunjukkan cara mengekstrak file yang disematkan dalam slide sebagai objek OLE:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```

## **FAQ**

**Apakah konten OLE akan dirender saat mengekspor slide ke PDF/gambar?**

Apa yang terlihat di slide yang dirender — ikon/gambar substitusi (pratinjau). Konten OLE yang "hidup" tidak dijalankan selama proses rendering. Jika diperlukan, tetapkan gambar pratinjau Anda sendiri untuk memastikan tampilan yang diharapkan dalam PDF yang diekspor.

Untuk juga mempertahankan file yang disematkan sebagai lampiran PDF, panggil [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) dengan `true`. Opsi ini dinonaktifkan secara default. Untuk contoh dan instruksi memeriksa lampiran, lihat [Preserve Embedded OLE Files as PDF Attachments](/slides/id/java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Bagaimana cara mengunci objek OLE pada slide sehingga pengguna tidak dapat memindahkan/mengeditnya di PowerPoint?**

Kunci shape: Aspose.Slides menyediakan [shape-level locks](/slides/id/java/applying-protection-to-presentation/). Ini bukan enkripsi, tetapi secara efektif mencegah pengeditan dan pemindahan tidak disengaja.

**Mengapa objek Excel yang ditautkan "melompat" atau berubah ukuran saat saya membuka presentasi?**

PowerPoint mungkin menyegarkan pratinjau OLE yang ditautkan. Untuk tampilan yang stabil, ikuti praktik [Working Solution for Worksheet Resizing](/slides/id/java/working-solution-for-worksheet-resizing/) — baik menyesuaikan bingkai dengan rentang, atau menskalakan rentang ke bingkai tetap dan menetapkan gambar substitusi yang sesuai.

**Apakah jalur relatif untuk objek OLE yang ditautkan akan dipertahankan dalam format PPTX?**

Di PPTX, informasi "jalur relatif" tidak tersedia — hanya jalur lengkap. Jalur relatif ditemukan pada format PPT yang lebih lama. Untuk portabilitas, gunakan jalur absolut yang dapat diandalkan/URI yang dapat diakses atau penyematan.