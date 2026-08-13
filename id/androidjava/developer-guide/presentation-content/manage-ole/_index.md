---
title: Mengelola OLE dalam Presentasi di Android
linktitle: Mengelola OLE
type: docs
weight: 40
url: /id/androidjava/manage-ole/
keywords:
- objek OLE
- Object Linking & Embedding
- menambahkan OLE
- menyematkan OLE
- menambahkan objek
- menyematkan objek
- menambahkan file
- menyematkan file
- objek tertaut
- file tertaut
- mengubah OLE
- ikon OLE
- judul OLE
- ekstrak OLE
- mengekstrak objek
- mengekstrak file
- PowerPoint 
- presentasi
- Android
- Java
- Aspose.Slides
description: "Optimalkan manajemen objek OLE dalam file PowerPoint dan OpenDocument dengan Aspose.Slides untuk Android via Java. Sematkan, perbarui, dan ekspor konten OLE dengan mulus."
---
## **Pendahuluan**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) adalah teknologi Microsoft yang memungkinkan data dan objek yang dibuat dalam satu aplikasi ditempatkan di aplikasi lain melalui tautan atau penyematan. 

{{% /alert %}} 

Pertimbangkan sebuah diagram yang dibuat di MS Excel. Diagram tersebut kemudian ditempatkan di dalam slide PowerPoint. Diagram Excel itu dianggap sebagai objek OLE. 

- Sebuah objek OLE dapat muncul sebagai ikon. Dalam hal ini, ketika Anda mengklik ganda ikon, diagram akan dibuka di aplikasi terkait (Excel), atau Anda akan diminta memilih aplikasi untuk membuka atau mengedit objek. 
- Sebuah objek OLE dapat menampilkan isi sebenarnya, seperti isi sebuah diagram. Dalam hal ini, diagram diaktifkan di PowerPoint, antarmuka diagram dimuat, dan Anda dapat memodifikasi data diagram di dalam PowerPoint.

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/id/androidjava/) memungkinkan Anda menyisipkan Objek OLE ke slide sebagai bingkai objek OLE ([OleObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/OleObjectFrame)).

## **Menambahkan Bingkai Objek OLE ke Slide**

Andaikan Anda sudah membuat sebuah diagram di Microsoft Excel dan ingin menyematkannya dalam slide sebagai bingkai objek OLE menggunakan Aspose.Slides for Android via Java, Anda dapat melakukannya dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation). 
1. Dapatkan referensi slide melalui indeksnya. 
1. Baca file Excel sebagai array byte. 
1. Tambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/OleObjectFrame) ke slide dengan menyertakan array byte dan informasi lain tentang objek OLE. 
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX. 

Pada contoh di bawah, kami menambahkan sebuah diagram dari file Excel ke slide sebagai bingkai objek OLE menggunakan Aspose.Slides for Android via Java.  
**Catatan** bahwa konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/OleEmbeddedDataInfo) menerima ekstensi objek yang dapat disematkan sebagai parameter kedua. Ekstensi ini memungkinkan PowerPoint menginterpretasikan tipe file dengan benar dan memilih aplikasi yang tepat untuk membuka objek OLE ini.

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

// Siapkan data untuk objek OLE.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Tambahkan bingkai objek OLE ke slide.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Menambahkan Bingkai Objek OLE Tertaut**

Aspose.Slides for Android via Java memungkinkan Anda menambahkan sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/OleObjectFrame) tanpa menyematkan data, melainkan hanya dengan tautan ke file.

Kode Java berikut menunjukkan cara menambahkan sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/OleObjectFrame) dengan file Excel yang ditautkan ke sebuah slide:

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

Jika sebuah objek OLE sudah disematkan dalam sebuah slide, Anda dapat dengan mudah menemukannya atau mengaksesnya dengan cara berikut:

1. Muat sebuah presentasi yang berisi objek OLE yang disematkan dengan membuat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation). 
2. Dapatkan referensi slide dengan menggunakan indeksnya. 
3. Akses shape [OleObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/OleObjectFrame).  
   Pada contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang hanya memiliki satu shape pada slide pertama. Kami kemudian *cast* objek tersebut menjadi [IOleObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ioleobjectframe/). Inilah bingkai objek OLE yang diinginkan untuk diakses. 
4. Setelah bingkai objek OLE diakses, Anda dapat melakukan operasi apa pun padanya. 

Pada contoh di bawah, sebuah bingkai objek OLE (objek diagram Excel yang disematkan dalam slide) dan data file-nya diakses.

```java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Dapatkan data file yang disematkan.
    // Dapatkan ekstensi file yang disematkan.
    // ...
}
```

### **Mengakses Properti Bingkai Objek OLE Tertaut**

Aspose.Slides memungkinkan Anda mengakses properti bingkai objek OLE yang ditautkan.

Kode Java berikut menunjukkan cara memeriksa apakah sebuah objek OLE ditautkan dan kemudian memperoleh jalur ke file yang ditautkan:

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

{{% alert color="info" %}} 

Di bagian ini, contoh kode di bawah menggunakan [Aspose.Cells for Android via Java](/cells/androidjava/). 

{{% /alert %}}

Jika sebuah objek OLE sudah disematkan dalam sebuah slide, Anda dapat dengan mudah mengakses objek tersebut dan memodifikasi datanya dengan cara berikut:

1. Muat sebuah presentasi yang berisi objek OLE yang disematkan dengan membuat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation). 
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses shape bingkai objek OLE.  
   Pada contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang memiliki satu shape pada slide pertama. Kami kemudian *cast* objek tersebut menjadi [IOleObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ioleobjectframe/). Inilah bingkai objek OLE yang diinginkan untuk diakses. 
4. Setelah bingkai objek OLE diakses, Anda dapat melakukan operasi apa pun padanya. 
5. Buat sebuah objek `Workbook` dan akses data OLE. 
6. Akses `Worksheet` yang diinginkan dan ubah data. 
7. Simpan `Workbook` yang telah diperbarui ke dalam stream. 
8. Ganti data objek OLE dari stream. 

Pada contoh di bawah, sebuah bingkai objek OLE (objek diagram Excel yang disematkan dalam slide) diakses, dan data file-nya dimodifikasi untuk memperbarui data diagram.

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

## **Menyisipkan Jenis File Lain ke Slide**

Selain diagram Excel, Aspose.Slides for Android via Java memungkinkan Anda menyematkan jenis file lain ke dalam slide. Misalnya, Anda dapat menyisipkan file HTML, PDF, dan ZIP sebagai objek. Ketika pengguna mengklik ganda objek yang disisipkan, objek tersebut secara otomatis terbuka di program yang relevan, atau pengguna akan diminta memilih program yang sesuai untuk membukanya.

Kode Java berikut menunjukkan cara menyematkan HTML dan ZIP ke slide:

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

## **Mengatur Jenis File untuk Objek yang Disematkan**

Saat bekerja dengan presentasi, Anda mungkin perlu mengganti objek OLE lama dengan yang baru atau mengganti objek OLE yang tidak didukung dengan yang didukung. Aspose.Slides for Android via Java memungkinkan Anda mengatur jenis file untuk sebuah objek yang disematkan, sehingga Anda dapat memperbarui data bingkai OLE atau ekstensi filenya.

Kode Java berikut menunjukkan cara mengatur jenis file untuk objek OLE yang disematkan menjadi `zip`:

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

Setelah menyematkan sebuah objek OLE, pratinjau berupa gambar ikon ditambahkan secara otomatis. Pratinjau inilah yang dilihat pengguna sebelum mengakses atau membuka objek OLE. Jika Anda ingin menggunakan gambar dan teks tertentu sebagai elemen dalam pratinjau, Anda dapat menetapkan gambar ikon dan judul menggunakan Aspose.Slides for Android via Java.

Kode Java berikut menunjukkan cara menetapkan gambar ikon dan judul untuk objek yang disematkan:

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

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Mencegah Bingkai Objek OLE Diubah Ukuran dan Posisinya**

Setelah Anda menambahkan objek OLE yang ditautkan ke slide presentasi, ketika Anda membuka presentasi di PowerPoint, Anda mungkin melihat pesan yang meminta Anda memperbarui tautan. Mengklik tombol "Update Links" dapat mengubah ukuran dan posisi bingkai objek OLE karena PowerPoint memperbarui data dari objek OLE yang ditautkan dan menyegarkan pratinjau objek. Untuk mencegah PowerPoint meminta pembaruan data objek, atur metode `setUpdateAutomatic` pada antarmuka [IOleObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ioleobjectframe/) menjadi `false`:

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

Aspose.Slides for Android via Java memungkinkan Anda mengekstrak file yang disematkan dalam slide sebagai objek OLE dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang berisi objek OLE yang ingin Anda ekstrak. 
2. Loop melalui semua shape dalam presentasi dan akses shape [OLEObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/oleobjectframe). 
3. Akses data file yang disematkan dari bingkai objek OLE dan tulis ke disk. 

Kode Java berikut menunjukkan cara mengekstrak file yang disematkan dalam slide sebagai objek OLE:

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

## **FAQ**

### Apakah konten OLE akan dirender saat mengekspor slide ke PDF/gambar?

Apa yang terlihat pada slide akan dirender—ikon/gambar pengganti (pratinjau). Konten OLE yang "hidup" tidak dijalankan selama proses rendering. Jika diperlukan, tetapkan gambar pratinjau Anda sendiri untuk memastikan tampilan yang diharapkan pada PDF yang diekspor.

### Bagaimana cara mengunci objek OLE pada slide sehingga pengguna tidak dapat memindahkannya/mengeditnya di PowerPoint?

Kunci shape: Aspose.Slides menyediakan kunci pada level shape. Ini bukan enkripsi, tetapi secara efektif mencegah pengeditan dan pemindahan secara tidak sengaja.

### Mengapa objek Excel yang ditautkan "melompat" atau berubah ukuran ketika saya membuka presentasi?

PowerPoint dapat menyegarkan pratinjau OLE yang ditautkan. Untuk tampilan yang stabil, ikuti praktik [Working Solution for Worksheet Resizing](/slides/id/androidjava/working-solution-for-worksheet-resizing/)—baik sesuaikan bingkai dengan rentang, atau skala rentang ke bingkai tetap dan tetapkan gambar pengganti yang sesuai.

### Apakah jalur relatif untuk objek OLE yang ditautkan akan dipertahankan dalam format PPTX?

Dalam PPTX, informasi "jalur relatif" tidak tersedia—hanya jalur penuh. Jalur relatif ditemukan pada format PPT yang lebih lama. Untuk portabilitas, gunakan jalur absolut yang dapat diandalkan/URI yang dapat diakses atau penyematan.