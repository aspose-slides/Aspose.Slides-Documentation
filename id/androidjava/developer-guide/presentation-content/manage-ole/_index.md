---
title: Kelola OLE dalam Presentasi di Android
linktitle: Kelola OLE
type: docs
weight: 40
url: /id/androidjava/manage-ole/
keywords:
- objek OLE
- Penautan & Penyematan Objek
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
- Android
- Java
- Aspose.Slides
description: "Optimalkan manajemen objek OLE dalam file PowerPoint dan OpenDocument dengan Aspose.Slides untuk Android via Java. Sematkan, perbarui, dan ekspor konten OLE dengan mulus."
---
## **Pendahuluan**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) adalah teknologi Microsoft yang memungkinkan data dan objek yang dibuat di satu aplikasi ditempatkan di aplikasi lain melalui penautan atau penyematan. 
{{% /alert %}} 

Pertimbangkan sebuah diagram yang dibuat di MS Excel. Diagram tersebut kemudian ditempatkan di dalam sebuah slide PowerPoint. Diagram Excel itu dianggap sebagai objek OLE. 

- Sebuah objek OLE dapat muncul sebagai ikon. Dalam kasus ini, ketika Anda mengklik ganda ikon, diagram akan dibuka di aplikasi terkait (Excel), atau Anda diminta memilih aplikasi untuk membuka atau menyunting objek tersebut.
- Sebuah objek OLE dapat menampilkan kontennya yang sebenarnya, seperti isi diagram. Dalam kasus ini, diagram diaktifkan di PowerPoint, antarmuka diagram dimuat, dan Anda dapat mengubah data diagram di dalam PowerPoint.

[Aspose.Slides untuk Android via Java](https://products.aspose.com/slides/androidjava/) memungkinkan Anda menyisipkan OLE Objects ke dalam slide sebagai bingkai objek OLE ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **Menambahkan Bingkai Objek OLE ke Slide**

Andaikan Anda sudah membuat diagram di Microsoft Excel dan ingin menyematkannya ke dalam slide sebagai bingkai objek OLE menggunakan Aspose.Slides untuk Android via Java, Anda dapat melakukannya dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
1. Dapatkan referensi slide melalui indeksnya.
1. Baca file Excel sebagai array byte.
1. Tambahkan [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) ke slide dengan menyertakan array byte dan informasi lainnya tentang objek OLE.
1. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Dalam contoh di bawah, kami menambahkan diagram dari file Excel ke slide sebagai bingkai objek OLE menggunakan Aspose.Slides untuk Android via Java.
**Catatan** bahwa konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) menerima ekstensi objek yang dapat disematkan sebagai parameter kedua. Ekstensi ini memungkinkan PowerPoint untuk menginterpretasikan tipe file dengan benar dan memilih aplikasi yang tepat untuk membuka objek OLE ini.

```java 
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Menambahkan Bingkai Objek OLE Tertaut**

Aspose.Slides untuk Android via Java memungkinkan Anda menambahkan sebuah [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) tanpa menyematkan data tetapi hanya dengan tautan ke file.

Kode Java ini menunjukkan cara menambahkan sebuah [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) dengan file Excel yang tertaut ke sebuah slide:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Tambahkan bingkai objek OLE dengan file Excel yang tertaut.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Mengakses Bingkai Objek OLE**

Jika sebuah objek OLE sudah disematkan dalam slide, Anda dapat dengan mudah menemukannya atau mengaksesnya dengan cara berikut:

1. Muat sebuah presentasi dengan objek OLE yang disematkan dengan membuat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. Dapatkan referensi slide dengan menggunakan indeksnya.
3. Akses shape [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) . Dalam contoh kami, kami menggunakan PPTX yang telah dibuat sebelumnya yang hanya memiliki satu shape pada slide pertama. Kami kemudian *cast* objek tersebut sebagai [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) . Ini adalah bingkai objek OLE yang diinginkan untuk diakses.
4. Setelah bingkai objek OLE diakses, Anda dapat melakukan operasi apa pun padanya.

Dalam contoh di bawah, sebuah bingkai objek OLE (objek diagram Excel yang disematkan dalam slide) dan data file-nya diakses.

```java 
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

### **Mengakses Properti Bingkai Objek OLE Tertaut**

Aspose.Slides memungkinkan Anda mengakses properti bingkai objek OLE yang tertaut.

Kode Java ini menunjukkan cara memeriksa apakah sebuah objek OLE tertaut dan kemudian memperoleh jalur ke file yang tertaut:

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
Pada bagian ini, contoh kode di bawah menggunakan [Aspose.Cells untuk Android via Java](https://docs.aspose.com/cells/androidjava/) .
{{% /alert %}}

Jika sebuah objek OLE sudah disematkan dalam slide, Anda dapat dengan mudah mengakses objek itu dan memodifikasi datanya dengan cara berikut:

1. Muat sebuah presentasi dengan objek OLE yang disematkan dengan membuat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses shape bingkai objek OLE. Dalam contoh kami, kami menggunakan PPTX yang telah dibuat sebelumnya yang memiliki satu shape pada slide pertama. Kami kemudian *cast* objek tersebut sebagai [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) . Ini adalah bingkai objek OLE yang diinginkan untuk diakses.
4. Setelah bingkai objek OLE diakses, Anda dapat melakukan operasi apa pun padanya.
5. Buat objek `Workbook` dan akses data OLE.
6. Akses `Worksheet` yang diinginkan dan ubah data.
7. Simpan `Workbook` yang telah diperbarui ke dalam stream.
8. Ubah data objek OLE dari stream.

Dalam contoh di bawah, sebuah bingkai objek OLE (objek diagram Excel yang disematkan dalam slide) diakses, dan data file-nya dimodifikasi untuk memperbarui data diagram.

```java 
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

    // Modifikasi data workbook.
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

## **Menyematkan Jenis File Lain ke dalam Slide**

Selain diagram Excel, Aspose.Slides untuk Android via Java memungkinkan Anda menyematkan jenis file lain ke dalam slide. Misalnya, Anda dapat menyisipkan file HTML, PDF, dan ZIP sebagai objek. Ketika pengguna mengklik ganda objek yang disisipkan, objek tersebut secara otomatis terbuka di program yang relevan, atau pengguna akan diminta memilih program yang sesuai untuk membukanya.

Kode Java ini menunjukkan cara menyematkan HTML dan ZIP ke dalam slide:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Menetapkan Jenis File untuk Objek yang Disematkan**

Saat bekerja dengan presentasi, Anda mungkin perlu mengganti objek OLE lama dengan yang baru atau mengganti objek OLE yang tidak didukung dengan yang didukung. Aspose.Slides untuk Android via Java memungkinkan Anda menetapkan jenis file untuk objek yang disematkan, sehingga Anda dapat memperbarui data bingkai OLE atau ekstensi filenya.

Kode Java ini menunjukkan cara menetapkan jenis file untuk objek OLE yang disematkan menjadi `zip`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Ubah tipe file menjadi ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Menetapkan Gambar Ikon dan Judul untuk Objek yang Disematkan**

Setelah menyematkan sebuah objek OLE, pratinjau yang terdiri dari gambar ikon secara otomatis ditambahkan. Pratinjau inilah yang dilihat pengguna sebelum mengakses atau membuka objek OLE. Jika Anda ingin menggunakan gambar dan teks tertentu sebagai elemen dalam pratinjau, Anda dapat menetapkan gambar ikon dan judul menggunakan Aspose.Slides untuk Android via Java.

Kode Java ini menunjukkan cara menetapkan gambar ikon dan judul untuk objek yang disematkan:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Tambahkan gambar ke sumber daya presentasi.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Atur judul dan gambar untuk pratinjau OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Mencegah Bingkai Objek OLE Diubah Ukuran dan Posisinya**

Setelah Anda menambahkan objek OLE yang tertaut ke slide presentasi, ketika Anda membuka presentasi di PowerPoint, Anda mungkin melihat pesan yang meminta Anda memperbarui tautan. Mengklik tombol "Update Links" dapat mengubah ukuran dan posisi bingkai objek OLE karena PowerPoint memperbarui data dari objek OLE yang tertaut dan menyegarkan pratinjau objek. Untuk mencegah PowerPoint meminta memperbarui data objek, panggil metode [setUpdateAutomatic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) pada antarmuka [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) dengan nilai `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    oleFrame.setUpdateAutomatic(false);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Mengekstrak File yang Disematkan**

Aspose.Slides untuk Android via Java memungkinkan Anda mengekstrak file yang disematkan dalam slide sebagai objek OLE dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) yang berisi objek OLE yang ingin Anda ekstrak.
2. Iterasikan semua shape dalam presentasi dan akses shape [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe) .
3. Akses data file yang disematkan dari bingkai objek OLE dan tulis ke disk.

Kode Java ini menunjukkan cara mengekstrak file yang disematkan dalam slide sebagai objek OLE:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```

## **Tanya Jawab**

**Apakah konten OLE akan dirender saat mengekspor slide ke PDF/gambar?**

Apa yang terlihat pada slide yang dirender—ikon/gambar pengganti (pratinjau). Konten OLE "live" tidak dijalankan selama proses render. Jika diperlukan, atur gambar pratinjau Anda sendiri untuk memastikan tampilan yang diharapkan dalam PDF yang diekspor.

Untuk juga mempertahankan file yang disematkan sebagai lampiran PDF, panggil [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) dengan `true`. Opsi ini dinonaktifkan secara default. Untuk contoh dan instruksi memeriksa lampiran, lihat [Pertahankan File OLE yang Disematkan sebagai Lampiran PDF](/slides/id/androidjava/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Bagaimana saya dapat mengunci objek OLE pada slide sehingga pengguna tidak dapat memindahkan/menyuntingnya di PowerPoint?**

Kunci shape: Aspose.Slides menyediakan kunci pada level shape. Ini bukan enkripsi, tetapi secara efektif mencegah penyuntingan atau pemindahan yang tidak disengaja.

**Mengapa objek Excel yang tertaut "melompat" atau berubah ukuran ketika saya membuka presentasi?**

PowerPoint mungkin menyegarkan pratinjau OLE yang tertaut. Untuk tampilan yang stabil, ikuti praktik [Solusi Praktis untuk Penyesuaian Ukuran Worksheet](/slides/id/androidjava/working-solution-for-worksheet-resizing/) — baik menyesuaikan bingkai dengan rentang, atau menskalakan rentang ke bingkai tetap dan menetapkan gambar pengganti yang sesuai.

**Apakah jalur relatif untuk objek OLE yang tertaut akan dipertahankan dalam format PPTX?**

Dalam PPTX, informasi "jalur relatif" tidak tersedia—hanya jalur lengkap. Jalur relatif ditemukan pada format PPT yang lebih lama. Untuk portabilitas, lebih baik menggunakan jalur absolut yang dapat diandalkan/URI yang dapat diakses atau menyematkan.