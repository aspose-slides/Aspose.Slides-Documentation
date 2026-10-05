---
title: Kelola OLE dalam Presentasi Menggunakan JavaScript
linktitle: Kelola OLE
type: docs
weight: 40
url: /id/nodejs-java/manage-ole/
keywords:
- objek OLE
- Object Linking & Embedding
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Optimalkan pengelolaan objek OLE dalam file PowerPoint dan OpenDocument dengan Aspose.Slides untuk Node.js via Java. Sematkan, perbarui, dan ekspor konten OLE dengan mulus."
---
## **Pendahuluan**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) adalah teknologi Microsoft yang memungkinkan data dan objek yang dibuat di satu aplikasi ditempatkan di aplikasi lain melalui penautan atau penyematan. 

{{% /alert %}} 

Pertimbangkan sebuah diagram yang dibuat di MS Excel. Diagram tersebut kemudian ditempatkan di dalam slide PowerPoint. Diagram Excel itu dianggap sebagai objek OLE. 

- Sebuah objek OLE dapat muncul sebagai ikon. Dalam kasus ini, ketika Anda mengklik ganda ikon, diagram akan dibuka di aplikasi terkait (Excel), atau Anda diminta memilih aplikasi untuk membuka atau mengedit objek tersebut.
- Sebuah objek OLE dapat menampilkan konten aslinya, seperti konten sebuah diagram. Dalam kasus ini, diagram diaktifkan di PowerPoint, antarmuka diagram dimuat, dan Anda dapat memodifikasi data diagram di dalam PowerPoint.

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) memungkinkan Anda menyisipkan OLE Objects ke dalam slide sebagai bingkai objek OLE ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)).

## **Menambahkan Bingkai OLE Object ke Slide**

Misalkan Anda telah membuat sebuah diagram di Microsoft Excel dan ingin menyematkannya dalam slide sebagai bingkai objek OLE menggunakan Aspose.Slides for Node.js via Java, Anda dapat melakukannya dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Baca file Excel sebagai array byte.
4. Tambahkan [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) ke slide yang berisi array byte dan informasi lainnya tentang objek OLE.
5. Tuliskan presentasi yang dimodifikasi sebagai file PPTX.

Dalam contoh di bawah, kami menambahkan sebuah diagram dari file Excel ke slide sebagai bingkai objek OLE menggunakan Aspose.Slides for Node.js via Java.  
**Catatan** bahwa konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) menerima ekstensi objek yang dapat disematkan sebagai parameter kedua. Ekstensi ini memungkinkan PowerPoint untuk menginterpretasikan tipe file dengan benar dan memilih aplikasi yang tepat untuk membuka objek OLE ini.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Menambahkan Bingkai OLE Object Tertaut**

Aspose.Slides for Node.js via Java memungkinkan Anda menambahkan sebuah [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) tanpa menyematkan data tetapi hanya dengan tautan ke file.  

Kode JavaScript ini menunjukkan cara menambahkan sebuah [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) dengan file Excel yang ditautkan ke sebuah slide:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Tambahkan bingkai objek OLE dengan file Excel yang ditautkan.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Mengakses Bingkai OLE Object**

Jika sebuah objek OLE sudah disematkan dalam slide, Anda dapat dengan mudah menemukan atau mengaksesnya dengan cara berikut:

1. Muat sebuah presentasi dengan objek OLE yang disematkan dengan membuat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide dengan menggunakan indeksnya.
3. Akses bentuk [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame). Dalam contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang hanya memiliki satu bentuk pada slide pertama.
4. Setelah bingkai objek OLE diakses, Anda dapat melakukan operasi apa pun padanya.

Dalam contoh di bawah, sebuah bingkai objek OLE (objek diagram Excel yang disematkan dalam slide) dan data file-nya diakses.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Dapatkan data file yang disematkan.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Dapatkan ekstensi file yang disematkan.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Mengakses Properti Bingkai OLE Object Tertaut**

Aspose.Slides memungkinkan Anda mengakses properti bingkai objek OLE yang ditautkan.  

Kode JavaScript ini menunjukkan cara memeriksa apakah sebuah objek OLE ditautkan dan kemudian mendapatkan jalur ke file yang ditautkan:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Periksa apakah objek OLE ditautkan.
    if (oleFrame.isObjectLink()) {
        // Cetak jalur lengkap ke file yang ditautkan.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Cetak jalur relatif ke file yang ditautkan jika ada.
        // Hanya presentasi PPT yang dapat berisi jalur relatif.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Mengubah Data OLE Object**

{{% alert color="info" title="Note" %}}

Di bagian ini, contoh kode di bawah menggunakan [Aspose.Cells for Java](https://docs.aspose.com/cells/java/).

{{% /alert %}}

Jika sebuah objek OLE sudah disematkan dalam slide, Anda dapat dengan mudah mengakses objek tersebut dan memodifikasi datanya dengan cara berikut:

1. Muat sebuah presentasi dengan objek OLE yang disematkan dengan membuat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses bentuk bingkai objek OLE. Dalam contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang memiliki satu bentuk pada slide pertama.
4. Setelah bingkai objek OLE diakses, Anda dapat melakukan operasi apa pun padanya.
5. Buat objek `Workbook` dan akses data OLE.
6. Akses `Worksheet` yang diinginkan dan ubah data.
7. Simpan `Workbook` yang diperbarui ke dalam stream.
8. Ubah data objek OLE dari stream.

Dalam contoh di bawah, sebuah bingkai objek OLE (objek diagram Excel yang disematkan dalam slide) diakses, dan data file-nya dimodifikasi untuk memperbarui data diagram.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var embeddedData = Array.from(oleFrame.getEmbeddedData().getEmbeddedFileData());
    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", java.newArray("byte", embeddedData));

    // Baca data objek OLE sebagai objek Workbook.
    var workbook = java.newInstanceSync("com.aspose.cells.Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Modifikasi data workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("com.aspose.cells.OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Ubah data objek bingkai OLE.
    var newFileData = java.newArray("byte", Array.from(newOleStream.toByteArray()));
    var newData = new asposeSlides.OleEmbeddedDataInfo(newFileData, oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Menyematkan Tipe File Lain ke Slide**

Selain diagram Excel, Aspose.Slides for Node.js via Java memungkinkan Anda menyematkan tipe file lain ke dalam slide. Misalnya, Anda dapat menyisipkan file HTML, PDF, dan ZIP sebagai objek. Ketika pengguna mengklik ganda objek yang disisipkan, objek tersebut otomatis terbuka di program terkait, atau pengguna diminta memilih program yang tepat untuk membukanya.

Kode JavaScript ini menunjukkan cara menyematkan HTML dan ZIP ke dalam slide:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Mengatur Tipe File untuk Objek yang Disematkan**

Saat bekerja dengan presentasi, Anda mungkin perlu mengganti objek OLE lama dengan yang baru atau mengganti objek OLE yang tidak didukung dengan yang didukung. Aspose.Slides for Node.js via Java memungkinkan Anda mengatur tipe file untuk objek yang disematkan, sehingga Anda dapat memperbarui data bingkai OLE atau ekstensi-nya.

Kode JavaScript ini menunjukkan cara mengatur tipe file untuk objek OLE yang disematkan menjadi `zip`:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Ubah tipe file menjadi ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Mengatur Gambar Ikon dan Judul untuk Objek yang Disematkan**

Setelah menyematkan objek OLE, pratinjau yang terdiri dari gambar ikon secara otomatis ditambahkan. Pratinjau ini adalah apa yang dilihat pengguna sebelum mengakses atau membuka objek OLE. Jika Anda ingin menggunakan gambar dan teks tertentu sebagai elemen dalam pratinjau, Anda dapat mengatur gambar ikon dan judul menggunakan Aspose.Slides for Node.js via Java.

Kode JavaScript ini menunjukkan cara mengatur gambar ikon dan judul untuk objek yang disematkan:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Tambahkan gambar ke sumber daya presentasi.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Atur judul dan gambar untuk pratinjau OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Mencegah Bingkai OLE Object Diubah Ukuran dan Posisi**

Setelah Anda menambahkan objek OLE yang ditautkan ke slide presentasi, ketika Anda membuka presentasi di PowerPoint, Anda mungkin melihat pesan yang meminta Anda memperbarui tautan. Mengklik tombol "Update Links" dapat mengubah ukuran dan posisi bingkai objek OLE karena PowerPoint memperbarui data dari objek OLE yang ditautkan dan menyegarkan pratinjau objek. Untuk mencegah PowerPoint meminta pembaruan data objek, panggil metode [setUpdateAutomatic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) dari kelas [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) dengan `false`:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Mengekstrak File yang Disematkan**

Aspose.Slides for Node.js via Java memungkinkan Anda mengekstrak file yang disematkan dalam slide sebagai objek OLE dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) yang berisi objek OLE yang ingin Anda ekstrak.
2. Iterasi semua bentuk dalam presentasi dan akses bentuk [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe).
3. Akses data file yang disematkan dari bingkai objek OLE dan tulis ke disk.

Kode JavaScript ini menunjukkan cara mengekstrak file yang disematkan dalam slide sebagai objek OLE:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```

## **FAQ**

**Apakah konten OLE akan dirender saat mengekspor slide ke PDF/gambar?**

Yang terlihat pada slide yang dirender—ikon/gambar pengganti (pratinjau). Konten OLE "live" tidak dieksekusi selama proses rendering. Jika diperlukan, atur gambar pratinjau Anda sendiri untuk memastikan tampilan yang diharapkan dalam PDF yang diekspor.  

Untuk juga mempertahankan file yang disematkan sebagai lampiran PDF, panggil [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) dengan `true`. Opsi ini dinonaktifkan secara default. Untuk contoh dan petunjuk memeriksa lampiran, lihat [Preserve Embedded OLE Files as PDF Attachments](/slides/id/nodejs-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Bagaimana saya dapat mengunci objek OLE pada slide sehingga pengguna tidak dapat memindahkan/mengeditnya di PowerPoint?**

Kunci bentuk: Aspose.Slides menyediakan kunci pada tingkat bentuk. Ini bukan enkripsi, tetapi secara efektif mencegah edit dan pergerakan tidak sengaja.

**Apakah jalur relatif untuk objek OLE yang ditautkan akan dipertahankan dalam format PPTX?**

Dalam PPTX, informasi "jalur relatif" tidak tersedia—hanya jalur lengkap. Jalur relatif ditemukan pada format PPT yang lebih lama. Untuk portabilitas, lebih baik gunakan jalur absolut yang dapat diandalkan/URI yang dapat diakses atau penyematan.