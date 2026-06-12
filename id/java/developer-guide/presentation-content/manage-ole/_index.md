---
title: Kelola OLE dalam Presentasi Menggunakan Java
linktitle: Kelola OLE
type: docs
weight: 40
url: /id/java/manage-ole/
keywords:
- objek OLE
- Object Linking & Embedding
- tambah OLE
- sematkan OLE
- tambah objek
- sematkan objek
- tambah file
- sematkan file
- objek terhubung
- file terhubung
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
description: "Optimalkan pengelolaan objek OLE di file PowerPoint dan OpenDocument dengan Aspose.Slides untuk Java. Sematkan, perbarui, dan ekspor konten OLE dengan mulus."
---
## **Pendahuluan**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) adalah teknologi Microsoft yang memungkinkan data dan objek yang dibuat dalam satu aplikasi ditempatkan di aplikasi lain melalui penautan atau penyematan. 

{{% /alert %}} 

Pertimbangkan sebuah diagram yang dibuat di MS Excel. Diagram tersebut kemudian ditempatkan di dalam slide PowerPoint. Diagram Excel itu dianggap sebagai objek OLE. 

- Sebuah objek OLE dapat muncul sebagai ikon. Dalam kasus ini, ketika Anda mengklik ganda ikon, diagram akan terbuka di aplikasi terkait (Excel), atau Anda akan diminta memilih aplikasi untuk membuka atau menyunting objek. 
- Sebuah objek OLE dapat menampilkan isi sesungguhnya, seperti isi sebuah diagram. Dalam kasus ini, diagram diaktifkan di PowerPoint, antarmuka diagram dimuat, dan Anda dapat memodifikasi data diagram di dalam PowerPoint. 

[Aspose.Slides for Java](https://products.aspose.com/slides/id/java/) memungkinkan Anda menyisipkan OLE Objects ke dalam slide sebagai bingkai objek OLE ([OleObjectFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/OleObjectFrame)).

## **Menambahkan Bingkai OLE Object ke Slide**

Andaikan Anda telah membuat sebuah diagram di Microsoft Excel dan ingin menyematkannya dalam slide sebagai bingkai objek OLE menggunakan Aspose.Slides for Java, Anda dapat melakukannya dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya. 
3. Baca file Excel sebagai array byte. 
4. Tambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/OleObjectFrame) ke slide yang berisi array byte dan informasi lain tentang objek OLE. 
5. Tulis presentasi yang dimodifikasi sebagai file PPTX. 

Dalam contoh di bawah, kami menambahkan sebuah diagram dari file Excel ke slide sebagai bingkai objek OLE menggunakan Aspose.Slides for Java.  
**Catatan** bahwa konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/OleEmbeddedDataInfo) mengambil ekstensi objek yang dapat disematkan sebagai parameter kedua. Ekstensi ini memungkinkan PowerPoint menafsirkan tipe file dengan benar dan memilih aplikasi yang tepat untuk membuka objek OLE ini.  

``` java 
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

### **Menambahkan Bingkai OLE Object yang Ditautkan**

Aspose.Slides for Java memungkinkan Anda menambahkan sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/OleObjectFrame) tanpa menyematkan data, melainkan hanya dengan tautan ke file.  

Kode Java berikut menunjukkan cara menambahkan sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/OleObjectFrame) dengan file Excel yang ditautkan ke sebuah slide:  

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Tambahkan bingkai objek OLE dengan file Excel yang ditautkan.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Mengakses Bingkai OLE Object**

Jika sebuah objek OLE sudah disematkan dalam slide, Anda dapat dengan mudah menemukannya atau mengaksesnya dengan cara berikut:

1. Muat sebuah presentasi yang berisi objek OLE yang disematkan dengan membuat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) . 
2. Dapatkan referensi slide dengan menggunakan indeksnya. 
3. Akses shape [OleObjectFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/OleObjectFrame). Pada contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang hanya memiliki satu shape pada slide pertama. Kami kemudian *cast* objek tersebut sebagai [IOleObjectFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/IOleObjectFrame). Inilah bingkai OLE yang ingin diakses. 
4. Setelah bingkai objek OLE diakses, Anda dapat melakukan operasi apa pun padanya. 

Dalam contoh di bawah, sebuah bingkai objek OLE (objek diagram Excel yang disematkan dalam slide) dan data file-nya diakses.  

``` java 
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

### **Mengakses Properti Bingkai OLE Object yang Ditautkan**

Aspose.Slides memungkinkan Anda mengakses properti bingkai objek OLE yang ditautkan.  

Kode Java berikut menunjukkan cara memeriksa apakah sebuah objek OLE ditautkan dan kemudian memperoleh jalur ke file yang ditautkan:  

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

## **Mengubah Data OLE Object**

{{% alert color="primary" %}} 

Pada bagian ini, contoh kode di bawah ini menggunakan [Aspose.Cells for Java](/cells/java/). 

{{% /alert %}} 

Jika sebuah objek OLE sudah disematkan dalam slide, Anda dapat dengan mudah mengakses objek tersebut dan memodifikasi datanya dengan cara berikut:

1. Muat sebuah presentasi yang berisi objek OLE yang disematkan dengan membuat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) . 
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses shape bingkai objek OLE. Pada contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang memiliki satu shape pada slide pertama. Kami kemudian *cast* objek tersebut sebagai [IOleObjectFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/IOleObjectFrame). Inilah bingkai OLE yang ingin diakses. 
4. Setelah bingkai objek OLE diakses, Anda dapat melakukan operasi apa pun padanya. 
5. Buat objek `Workbook` dan akses data OLE. 
6. Akses `Worksheet` yang diinginkan dan ubah datanya. 
7. Simpan `Workbook` yang diperbarui ke dalam sebuah stream. 
8. Ubah data objek OLE dari stream tersebut. 

Dalam contoh di bawah, sebuah bingkai objek OLE (objek diagram Excel yang disematkan dalam slide) diakses, dan data file-nya dimodifikasi untuk memperbarui data diagram.  

``` java 
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

## **Menyematkan Jenis File Lain ke Slide**

Selain diagram Excel, Aspose.Slides for Java memungkinkan Anda menyematkan jenis file lain ke dalam slide. Misalnya, Anda dapat menyisipkan file HTML, PDF, dan ZIP sebagai objek. Ketika pengguna mengklik ganda objek yang disisipkan, objek tersebut secara otomatis terbuka di program yang relevan, atau pengguna akan diminta memilih program yang sesuai untuk membukanya.  

Kode Java berikut menunjukkan cara menyematkan HTML dan ZIP ke dalam sebuah slide:  

```java
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

## **Mengatur Tipe File untuk Objek yang Disematkan**

Saat bekerja dengan presentasi, Anda mungkin perlu mengganti objek OLE lama dengan yang baru atau mengganti objek OLE yang tidak didukung dengan yang didukung. Aspose.Slides for Java memungkinkan Anda mengatur tipe file untuk sebuah objek yang disematkan, sehingga Anda dapat memperbarui data bingkai OLE atau ekstensi filenya.  

Kode Java berikut menunjukkan cara mengatur tipe file untuk objek OLE yang disematkan menjadi `zip`:  

```java
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

## **Mengatur Gambar Ikon dan Judul untuk Objek yang Disematkan**

Setelah menyematkan sebuah objek OLE, pratinjau yang terdiri dari gambar ikon secara otomatis ditambahkan. Pratinjau inilah yang dilihat pengguna sebelum mengakses atau membuka objek OLE. Jika Anda ingin menggunakan gambar dan teks tertentu sebagai elemen dalam pratinjau, Anda dapat mengatur gambar ikon dan judul menggunakan Aspose.Slides for Java.  

Kode Java berikut menunjukkan cara mengatur gambar ikon dan judul untuk sebuah objek yang disematkan:  

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Tambahkan gambar ke sumber daya presentasi.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Mencegah Bingkai OLE Object Diubah Ukuran dan Posisi**

Setelah Anda menambahkan objek OLE yang ditautkan ke slide presentasi, ketika Anda membuka presentasi di PowerPoint, Anda mungkin melihat pesan yang meminta Anda memperbarui tautan. Mengklik tombol "Update Links" dapat mengubah ukuran dan posisi bingkai objek OLE karena PowerPoint memperbarui data dari objek OLE yang ditautkan dan menyegarkan pratinjau objek. Untuk mencegah PowerPoint menanyakan pembaruan data objek, atur metode `setUpdateAutomatic` pada antarmuka [IOleObjectFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ioleobjectframe/) menjadi `false`:  

```java
oleFrame.setUpdateAutomatic(false);
```

## **Mengekstrak File yang Disematkan**

Aspose.Slides for Java memungkinkan Anda mengekstrak file yang disematkan dalam slide sebagai objek OLE dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang berisi objek OLE yang ingin Anda ekstrak. 
2. Loop melalui semua shape dalam presentasi dan akses shape [OLEObjectFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/oleobjectframe). 
3. Akses data file yang disematkan dari bingkai objek OLE dan tulis ke disk. 

Kode Java berikut menunjukkan cara mengekstrak file yang disematkan dalam slide sebagai objek OLE:  

```java
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

Yang terlihat pada slide yang dirender—ikon/gambar pengganti (pratinjau). Konten OLE yang “hidup” tidak dieksekusi selama proses rendering. Jika diperlukan, atur gambar pratinjau Anda sendiri untuk memastikan tampilan yang diharapkan dalam PDF yang diekspor.  

**Bagaimana saya dapat mengunci OLE object pada slide sehingga pengguna tidak dapat memindahkan/mengeditnya di PowerPoint?**  

Kunci shape: Aspose.Slides menyediakan [shape-level locks](/slides/id/java/applying-protection-to-presentation/). Ini bukan enkripsi, namun secara efektif mencegah penyuntingan dan pemindahan yang tidak disengaja.  

**Mengapa objek Excel yang ditautkan "melompat" atau mengubah ukuran saat saya membuka presentasi?**  

PowerPoint dapat menyegarkan pratinjau OLE yang ditautkan. Untuk tampilan yang stabil, ikuti praktik [Working Solution for Worksheet Resizing](/slides/id/java/working-solution-for-worksheet-resizing/)—baik menyesuaikan bingkai dengan rentang, atau menskalakan rentang ke bingkai tetap dan menetapkan gambar pengganti yang sesuai.  

**Apakah jalur relatif untuk objek OLE yang ditautkan akan dipertahankan dalam format PPTX?**  

Dalam PPTX, informasi “jalur relatif” tidak tersedia—hanya jalur lengkap. Jalur relatif terdapat pada format PPT yang lebih lama. Untuk portabilitas, sebaiknya gunakan jalur absolut yang dapat diandalkan/URI yang dapat diakses atau menyematkan file.