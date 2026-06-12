---
title: Kelola OLE dalam Presentasi di Android
linktitle: Kelola OLE
type: docs
weight: 40
url: /id/androidjava/manage-ole/
keywords:
- objek OLE
- Penghubungan & Penyematan Objek
- tambahkan OLE
- semat OLE
- tambahkan objek
- semat objek
- tambahkan file
- semat file
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
description: "Optimalkan manajemen objek OLE dalam file PowerPoint dan OpenDocument dengan Aspose.Slides untuk Android via Java. Sematkan, perbarui, dan ekspor konten OLE secara mulus."
---
## **Introduction**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) adalah teknologi Microsoft yang memungkinkan data dan objek yang dibuat di satu aplikasi ditempatkan di aplikasi lain melalui penautan atau penyematan. 

{{% /alert %}} 

Pertimbangkan sebuah diagram yang dibuat di MS Excel. Diagram tersebut kemudian ditempatkan di dalam slide PowerPoint. Diagram Excel itu dianggap sebagai objek OLE. 

- Sebuah objek OLE dapat muncul sebagai ikon. Dalam kasus ini, ketika Anda mengklik ganda ikon, diagram akan dibuka di aplikasi terkait (Excel), atau Anda akan diminta memilih aplikasi untuk membuka atau menyunting objek. 
- Sebuah objek OLE dapat menampilkan isi sebenarnya, seperti isi sebuah diagram. Dalam kasus ini, diagram diaktifkan di PowerPoint, antarmuka diagram dimuat, dan Anda dapat memodifikasi data diagram di dalam PowerPoint.

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/id/androidjava/) memungkinkan Anda menyisipkan OLE Objects ke dalam slide sebagai bingkai objek OLE ([OleObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/OleObjectFrame)).

## **Add OLE Object Frames to Slides**

Misalkan Anda sudah membuat sebuah diagram di Microsoft Excel dan ingin menyematkannya dalam slide sebagai bingkai objek OLE menggunakan Aspose.Slides for Android via Java, Anda dapat melakukannya dengan cara berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) .
1. Dapatkan referensi slide melalui indeksnya.
1. Baca file Excel sebagai array byte.
1. Tambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/OleObjectFrame) ke slide yang berisi array byte dan informasi lain tentang objek OLE.
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah, kami menambahkan diagram dari file Excel ke slide sebagai bingkai objek OLE menggunakan Aspose.Slides for Android via Java.  
**Note** bahwa konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/OleEmbeddedDataInfo) menerima ekstensi objek yang dapat disematkan sebagai parameter kedua. Ekstensi ini memungkinkan PowerPoint menginterpretasikan tipe file dengan benar dan memilih aplikasi yang tepat untuk membuka objek OLE ini.

```java
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Siapkan data untuk objek OLE.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Add Linked OLE Object Frames**

Aspose.Slides for Android via Java memungkinkan Anda menambahkan sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/OleObjectFrame) tanpa menyematkan data, melainkan hanya dengan tautan ke file.

Kode Java ini menunjukkan cara menambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/OleObjectFrame) dengan file Excel yang ditautkan ke sebuah slide:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Tambahkan bingkai objek OLE dengan file Excel yang ditautkan.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Access OLE Object Frames**

Jika sebuah objek OLE sudah disematkan dalam slide, Anda dapat dengan mudah menemukan atau mengaksesnya dengan cara berikut:

1. Muat sebuah presentasi yang berisi objek OLE yang disematkan dengan membuat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) .
2. Dapatkan referensi slide dengan menggunakan indeksnya.
3. Akses shape [OleObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/OleObjectFrame).  
   Pada contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang hanya memiliki satu shape pada slide pertama. Kami kemudian *cast* objek tersebut sebagai [IOleObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ioleobjectframe/). Ini adalah bingkai objek OLE yang ingin diakses.
4. Setelah bingkai objek OLE diakses, Anda dapat melakukan operasi apa pun padanya.

Pada contoh di bawah, sebuah bingkai objek OLE (objek diagram Excel yang disematkan dalam slide) dan data file-nya diakses.

```java 
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

### **Access Linked OLE Object Frame Properties**

Aspose.Slides memungkinkan Anda mengakses properti bingkai objek OLE yang ditautkan.

Kode Java ini menunjukkan cara memeriksa apakah sebuah objek OLE ditautkan dan kemudian memperoleh jalur ke file yang ditautkan:

```java
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

## **Change OLE Object Data**

{{% alert color="primary" %}} 

Pada bagian ini, contoh kode di bawah menggunakan [Aspose.Cells for Android via Java](/cells/androidjava/).

{{% /alert %}}

Jika sebuah objek OLE sudah disematkan dalam slide, Anda dapat dengan mudah mengakses objek tersebut dan memodifikasi datanya dengan cara berikut:

1. Muat sebuah presentasi yang berisi objek OLE yang disematkan dengan membuat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses shape bingkai objek OLE.  
   Pada contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang memiliki satu shape pada slide pertama. Kami kemudian *cast* objek tersebut sebagai [IOleObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ioleobjectframe/). Ini adalah bingkai objek OLE yang ingin diakses.
4. Setelah bingkai objek OLE diakses, Anda dapat melakukan operasi apa pun padanya.
5. Buat objek `Workbook` dan akses data OLE.
6. Akses `Worksheet` yang diinginkan dan ubah data.
7. Simpan `Workbook` yang diperbarui ke dalam stream.
8. Ganti data objek OLE dari stream.

Pada contoh di bawah, sebuah bingkai objek OLE (objek diagram Excel yang disematkan dalam slide) diakses, dan data file-nya dimodifikasi untuk memperbarui data diagram.

```java 
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

## **Embed Other File Types in Slides**

Selain diagram Excel, Aspose.Slides for Android via Java memungkinkan Anda menyematkan tipe file lain ke dalam slide. Misalnya, Anda dapat menyisipkan file HTML, PDF, dan ZIP sebagai objek. Ketika pengguna mengklik ganda objek yang disisipkan, ia secara otomatis terbuka di program yang relevan, atau pengguna akan diminta memilih program yang sesuai untuk membukanya.

Kode Java ini menunjukkan cara menyematkan HTML dan ZIP ke dalam slide:

```java
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

## **Set File Types for Embedded Objects**

Saat bekerja dengan presentasi, Anda mungkin perlu mengganti objek OLE lama dengan yang baru atau mengganti objek OLE yang tidak didukung dengan yang didukung. Aspose.Slides for Android via Java memungkinkan Anda mengatur tipe file untuk objek yang disematkan, sehingga Anda dapat memperbarui data bingkai OLE atau ekstensi filenya.

Kode Java ini menunjukkan cara mengatur tipe file untuk objek OLE yang disematkan menjadi `zip`:

```java
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

## **Set Icon Images and Titles for Embedded Objects**

Setelah menyematkan sebuah objek OLE, pratinjau berupa gambar ikon ditambahkan secara otomatis. Pratinjau inilah yang dilihat pengguna sebelum mengakses atau membuka objek OLE. Jika Anda ingin menggunakan gambar dan teks tertentu sebagai elemen dalam pratinjau, Anda dapat mengatur gambar ikon dan judul menggunakan Aspose.Slides for Android via Java.

Kode Java ini menunjukkan cara mengatur gambar ikon dan judul untuk objek yang disematkan:

```java
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

## **Prevent an OLE Object Frame from Being Resized and Pepositioned**

Setelah Anda menambahkan objek OLE yang ditautkan ke slide presentasi, ketika Anda membuka presentasi di PowerPoint, Anda mungkin melihat pesan yang menanyakan apakah akan memperbarui tautan. Mengklik tombol "Update Links" dapat mengubah ukuran dan posisi bingkai objek OLE karena PowerPoint memperbarui data dari objek OLE yang ditautkan dan menyegarkan pratinjau objek. Untuk mencegah PowerPoint meminta pembaruan data objek, atur metode `setUpdateAutomatic` pada antarmuka [IOleObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ioleobjectframe/) menjadi `false`:

```java
oleFrame.setUpdateAutomatic(false);
```

## **Extract Embedded Files**

Aspose.Slides for Android via Java memungkinkan Anda mengekstrak file yang disematkan dalam slide sebagai objek OLE dengan cara berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang berisi objek OLE yang ingin Anda ekstrak.
2. Lakukan iterasi melalui semua shape dalam presentasi dan akses shape [OLEObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/oleobjectframe).
3. Akses data file yang disematkan dari bingkai objek OLE dan tulis ke disk.

Kode Java ini menunjukkan cara mengekstrak file yang disematkan dalam slide sebagai objek OLE:

```java
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

**Apakah konten OLE akan dirender saat mengekspor slide ke PDF/gambar?**

Yang terlihat pada slide yang dirender adalah ikon/gambar pengganti (pratinjau). Konten OLE "langsung" tidak dieksekusi selama proses rendering. Jika diperlukan, setel gambar pratinjau Anda sendiri untuk memastikan tampilan yang diharapkan pada PDF yang diekspor.

**Bagaimana cara mengunci objek OLE pada slide sehingga pengguna tidak dapat memindahkan/mengeditnya di PowerPoint?**

Kunci shape: Aspose.Slides menyediakan kunci pada tingkat shape. Ini bukan enkripsi, tetapi secara efektif mencegah penyuntingan dan pemindahan tidak sengaja.

**Mengapa objek Excel yang ditautkan "melompat" atau berubah ukuran saat saya membuka presentasi?**

PowerPoint mungkin menyegarkan pratinjau OLE yang ditautkan. Untuk tampilan yang stabil, ikuti praktik [Working Solution for Worksheet Resizing](/slides/id/androidjava/working-solution-for-worksheet-resizing/) — baik sesuaikan bingkai dengan rentang, atau skala rentang ke bingkai tetap dan setel gambar pengganti yang tepat.

**Apakah jalur relatif untuk objek OLE yang ditautkan akan dipertahankan dalam format PPTX?**

Dalam PPTX, informasi "jalur relatif" tidak tersedia — hanya jalur penuh. Jalur relatif ditemukan pada format PPT yang lebih lama. Untuk portabilitas, lebih baik menggunakan jalur absolut yang dapat diandalkan/URI yang dapat diakses atau menyematkan file.