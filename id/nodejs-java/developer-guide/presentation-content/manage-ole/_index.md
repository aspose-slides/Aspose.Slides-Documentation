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
description: "Optimalkan pengelolaan objek OLE dalam file PowerPoint dan OpenDocument dengan Aspose.Slides untuk Node.js via Java. Sematkan, perbarui, dan ekspor konten OLE secara mulus."
---
## **Pendahuluan**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) adalah teknologi Microsoft yang memungkinkan data dan objek yang dibuat di satu aplikasi ditempatkan di aplikasi lain melalui penautan atau penyisipan. 

{{% /alert %}} 

Pertimbangkan sebuah diagram yang dibuat di MS Excel. Diagram tersebut kemudian ditempatkan di dalam slide PowerPoint. Diagram Excel itu dianggap sebagai objek OLE. 

- Sebuah objek OLE dapat muncul sebagai ikon. Dalam hal ini, ketika Anda mengklik ganda ikon, diagram akan dibuka di aplikasi yang terkait (Excel), atau Anda akan diminta memilih aplikasi untuk membuka atau menyunting objek. 
- Sebuah objek OLE dapat menampilkan isi sebenarnya, seperti isi sebuah diagram. Dalam hal ini, diagram diaktifkan di PowerPoint, antarmuka diagram dimuat, dan Anda dapat mengubah data diagram di dalam PowerPoint.

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/id/nodejs-java/) memungkinkan Anda menyisipkan OLE Objects ke dalam slide sebagai frame objek OLE ([OleObjectFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/OleObjectFrame)).

## **Menambahkan Frame OLE Object ke Slide**

Misalkan Anda telah membuat diagram di Microsoft Excel dan ingin menyisipkannya ke dalam slide sebagai frame objek OLE menggunakan Aspose.Slides for Node.js via Java, Anda dapat melakukannya dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation). 
1. Dapatkan referensi slide melalui indeksnya. 
1. Baca file Excel sebagai array byte. 
1. Tambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/OleObjectFrame) ke slide yang berisi array byte dan informasi lain tentang objek OLE. 
1. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX. 

Pada contoh di bawah ini, kami menambahkan diagram dari file Excel ke slide sebagai frame objek OLE menggunakan Aspose.Slides for Node.js via Java.  
**Catatan** bahwa konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/OleEmbeddedDataInfo) menerima ekstensi objek yang dapat disisipkan sebagai parameter kedua. Ekstensi ini memungkinkan PowerPoint menafsirkan jenis file dengan benar dan memilih aplikasi yang tepat untuk membuka objek OLE ini.

```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Siapkan data untuk objek OLE.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Tambahkan frame objek OLE ke slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Menambahkan Frame OLE Object yang Ditautkan**

Aspose.Slides for Node.js via Java memungkinkan Anda menambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/OleObjectFrame) tanpa menyisipkan data, melainkan hanya dengan tautan ke file.

Kode JavaScript berikut menunjukkan cara menambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/OleObjectFrame) dengan file Excel yang ditautkan ke slide:

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Tambahkan frame objek OLE dengan file Excel yang ditautkan.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Mengakses Frame OLE Object**

Jika sebuah objek OLE sudah disisipkan dalam slide, Anda dapat dengan mudah menemukannya atau mengaksesnya dengan cara berikut:

1. Muat presentasi yang berisi objek OLE yang disisipkan dengan membuat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation). 
2. Dapatkan referensi slide dengan menggunakan indeksnya. 
3. Akses shape [OleObjectFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/OleObjectFrame). Dalam contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang hanya memiliki satu shape pada slide pertama. 
4. Setelah frame objek OLE diakses, Anda dapat melakukan operasi apa pun padanya. 

Pada contoh di bawah ini, sebuah frame objek OLE (objek diagram Excel yang disisipkan dalam slide) dan data file‑nya diakses.

```javascript
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

### **Mengakses Properti Frame OLE Object yang Ditautkan**

Aspose.Slides memungkinkan Anda mengakses properti frame OLE object yang ditautkan.

Kode JavaScript berikut menunjukkan cara memeriksa apakah sebuah objek OLE ditautkan dan kemudian memperoleh jalur ke file yang ditautkan:

```javascript
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

{{% alert color="primary" %}} 

Pada bagian ini, contoh kode di bawah ini menggunakan [Aspose.Cells for Java](/cells/java/). 

{{% /alert %}}

Jika sebuah objek OLE sudah disisipkan dalam slide, Anda dapat dengan mudah mengakses objek tersebut dan mengubah data‑nya dengan cara berikut:

1. Muat presentasi yang berisi objek OLE yang disisipkan dengan membuat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation). 
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses shape frame objek OLE. Dalam contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang memiliki satu shape pada slide pertama. 
4. Setelah frame objek OLE diakses, Anda dapat melakukan operasi apa pun padanya. 
5. Buat objek `Workbook` dan akses data OLE. 
6. Akses `Worksheet` yang diinginkan dan ubah datanya. 
7. Simpan `Workbook` yang telah diperbarui ke dalam stream. 
8. Ganti data objek OLE dari stream. 

Pada contoh di bawah ini, sebuah frame objek OLE (objek diagram Excel yang disisipkan dalam slide) diakses, dan data file‑nya dimodifikasi untuk memperbarui data diagram.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Baca data objek OLE sebagai objek Workbook.
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Ubah data workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Ubah data objek frame OLE.
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Menyisipkan Jenis File Lain ke dalam Slide**

Selain diagram Excel, Aspose.Slides for Node.js via Java memungkinkan Anda menyisipkan jenis file lain ke dalam slide. Misalnya, Anda dapat menyisipkan file HTML, PDF, dan ZIP sebagai objek. Ketika pengguna mengklik ganda objek yang disisipkan, objek tersebut otomatis terbuka di program yang relevan, atau pengguna akan diminta memilih program yang sesuai untuk membukanya.

Kode JavaScript berikut menunjukkan cara menyisipkan HTML dan ZIP ke dalam slide:

```javascript
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

## **Menentukan Jenis File untuk Objek yang Disisipkan**

Saat bekerja dengan presentasi, Anda mungkin perlu mengganti objek OLE lama dengan yang baru atau mengganti objek OLE yang tidak didukung dengan yang didukung. Aspose.Slides for Node.js via Java memungkinkan Anda menentukan jenis file untuk objek yang disisipkan, sehingga Anda dapat memperbarui data frame OLE atau ekstensinya.

Kode JavaScript berikut menunjukkan cara menetapkan jenis file untuk objek OLE yang disisipkan menjadi `zip`:

```javascript
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

## **Menentukan Gambar Ikon dan Judul untuk Objek yang Disisipkan**

Setelah menyisipkan objek OLE, pratinjau yang terdiri dari gambar ikon ditambahkan secara otomatis. Pratinjau inilah yang dilihat pengguna sebelum mengakses atau membuka objek OLE. Jika Anda ingin menggunakan gambar dan teks tertentu sebagai elemen dalam pratinjau, Anda dapat mengatur gambar ikon dan judul menggunakan Aspose.Slides for Node.js via Java.

Kode JavaScript berikut menunjukkan cara menetapkan gambar ikon dan judul untuk objek yang disisipkan:

```javascript
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

## **Mencegah Frame OLE Object Diubah Ukuran dan Posisinya**

Setelah Anda menambahkan objek OLE yang ditautkan ke slide presentasi, ketika Anda membuka presentasi di PowerPoint, mungkin muncul pesan yang meminta Anda memperbarui tautan. Mengklik tombol "Update Links" dapat mengubah ukuran dan posisi frame objek OLE karena PowerPoint memperbarui data dari objek OLE yang ditautkan dan menyegarkan pratinjau objek. Untuk mencegah PowerPoint meminta pembaruan data objek, gunakan metode `setUpdateAutomatic` dari kelas [OleObjectFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/oleobjectframe/) dengan nilai `false`:

```javascript
oleFrame.setUpdateAutomatic(false);
```

## **Mengekstrak File yang Disisipkan**

Aspose.Slides for Node.js via Java memungkinkan Anda mengekstrak file yang disisipkan dalam slide sebagai objek OLE dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang berisi objek OLE yang ingin Anda ekstrak. 
2. Loop melalui semua shape dalam presentasi dan akses shape [OleObjectFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/oleobjectframe). 
3. Akses data file yang disisipkan dari frame objek OLE dan tulis ke disk. 

Kode JavaScript berikut menunjukkan cara mengekstrak file yang disisipkan dalam slide sebagai objek OLE:

```javascript
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

Yang terlihat pada slide yang dirender adalah ikon/gambar pengganti (pratinjau). Konten OLE "live" tidak dieksekusi selama proses render. Jika diperlukan, setel gambar pratinjau Anda sendiri untuk memastikan tampilan yang diharapkan pada PDF yang diekspor.

**Bagaimana cara mengunci objek OLE pada slide sehingga pengguna tidak dapat memindahkannya atau menyuntingnya di PowerPoint?**

Kunci shape: Aspose.Slides menyediakan kunci pada tingkat shape. Ini bukan enkripsi, tetapi secara efektif mencegah penyuntingan dan pemindahan yang tidak sengaja.

**Apakah jalur relatif untuk objek OLE yang ditautkan akan dipertahankan dalam format PPTX?**

Dalam PPTX, informasi "jalur relatif" tidak tersedia—hanya jalur lengkap. Jalur relatif ditemukan dalam format PPT yang lebih lama. Untuk portabilitas, gunakan jalur absolut yang dapat diandalkan/URI yang dapat diakses atau menyisipkan file.