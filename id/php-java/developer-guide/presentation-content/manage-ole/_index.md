---
title: Kelola OLE dalam Presentasi Menggunakan PHP
linktitle: Kelola OLE
type: docs
weight: 40
url: /id/php-java/manage-ole/
keywords:
- objek OLE
- Penghubungan & Penyematan Objek
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
- PHP
- Aspose.Slides
description: "Optimalkan manajemen objek OLE dalam file PowerPoint dan OpenDocument dengan Aspose.Slides untuk PHP via Java. Sematkan, perbarui, dan ekspor konten OLE secara mulus."
---
## **Pendahuluan**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) adalah teknologi Microsoft yang memungkinkan data dan objek yang dibuat dalam satu aplikasi ditempatkan di aplikasi lain melalui penautan atau penyematan. 

{{% /alert %}} 

Pertimbangkan sebuah diagram yang dibuat di MS Excel. Diagram tersebut kemudian ditempatkan di dalam slide PowerPoint. Diagram Excel itu dianggap sebagai objek OLE. 

- Sebuah objek OLE dapat muncul sebagai ikon. Dalam kasus ini, ketika Anda mengklik ganda ikon, diagram akan dibuka di aplikasi terkait (Excel), atau Anda diminta memilih aplikasi untuk membuka atau mengedit objek. 
- Sebuah objek OLE dapat menampilkan isi sebenarnya, seperti isi sebuah diagram. Dalam kasus ini, diagram diaktifkan di PowerPoint, antarmuka diagram dimuat, dan Anda dapat memodifikasi data diagram di dalam PowerPoint.

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/id/php-java/) memungkinkan Anda menyisipkan OLE Objects ke dalam slide sebagai bingkai objek OLE ([OleObjectFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/oleobjectframe/)).

## **Menambahkan Bingkai Objek OLE ke Slide**

Misalkan Anda sudah membuat diagram di Microsoft Excel dan ingin menyematkannya ke dalam slide sebagai bingkai objek OLE menggunakan Aspose.Slides for PHP via Java, Anda dapat melakukannya dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).  
1. Dapatkan referensi slide melalui indeksnya.  
1. Baca file Excel sebagai array byte.  
1. Tambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/oleobjectframe/) ke slide yang berisi array byte dan informasi lainnya tentang objek OLE.  
1. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.  

Pada contoh di bawah, kami menambahkan diagram dari file Excel ke slide sebagai bingkai objek OLE menggunakan Aspose.Slides for PHP via Java. **Catatan** bahwa konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/oleembeddeddatainfo/) menerima ekstensi objek yang dapat disematkan sebagai parameter kedua. Ekstensi ini memungkinkan PowerPoint untuk menginterpretasikan tipe file dengan benar dan memilih aplikasi yang tepat untuk membuka objek OLE ini.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Prepare data for the OLE object.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Add the OLE object frame to the slide.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Menambahkan Bingkai OLE Object Tertaut**

Aspose.Slides for PHP via Java memungkinkan Anda menambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/oleobjectframe/) tanpa menyematkan data, melainkan hanya dengan tautan ke file.

Kode PHP ini menunjukkan cara menambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/oleobjectframe/) dengan file Excel yang ditautkan ke sebuah slide:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Tambahkan bingkai objek OLE dengan file Excel yang ditautkan.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Mengakses Bingkai Objek OLE**

Jika sebuah objek OLE sudah disematkan dalam sebuah slide, Anda dapat dengan mudah menemukan atau mengaksesnya dengan cara berikut:

1. Muat sebuah presentasi dengan objek OLE yang disematkan dengan membuat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).  
2. Dapatkan referensi slide dengan menggunakan indeksnya.  
3. Akses shape [OleObjectFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/oleobjectframe/). Dalam contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang hanya memiliki satu shape pada slide pertama.  
4. Setelah bingkai objek OLE diakses, Anda dapat melakukan operasi apa pun padanya.  

Pada contoh di bawah, sebuah bingkai objek OLE (objek diagram Excel yang disematkan dalam slide) dan data file-nya diakses.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Dapatkan data file yang disematkan.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // Dapatkan ekstensi file yang disematkan.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **Mengakses Properti Bingkai OLE Object Tertaut**

Aspose.Slides memungkinkan Anda mengakses properti bingkai OLE object yang ditautkan.

Kode PHP ini menunjukkan cara memeriksa apakah sebuah objek OLE ditautkan dan kemudian mendapatkan jalur ke file yang ditautkan:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Periksa apakah objek OLE ditautkan.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // Cetak jalur lengkap ke file yang ditautkan.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // Cetak jalur relatif ke file yang ditautkan jika ada.
        // Hanya presentasi PPT yang dapat berisi jalur relatif.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **Mengubah Data Objek OLE**

{{% alert color="primary" %}} 

Pada bagian ini, contoh kode di bawah menggunakan [Aspose.Cells for PHP via Java](/cells/php-java/).

{{% /alert %}}

Jika sebuah objek OLE sudah disematkan dalam slide, Anda dapat dengan mudah mengakses objek tersebut dan memodifikasi datanya dengan cara berikut:

1. Muat sebuah presentasi dengan objek OLE yang disematkan dengan membuat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).  
2. Dapatkan referensi slide melalui indeksnya.  
3. Akses shape [OleObjectFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/oleobjectframe/). Dalam contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang memiliki satu shape pada slide pertama.  
4. Setelah bingkai objek OLE diakses, Anda dapat melakukan operasi apa pun padanya.  
5. Buat objek `Workbook` dan akses data OLE.  
6. Akses `Worksheet` yang diinginkan dan ubah data.  
7. Simpan `Workbook` yang diperbarui ke dalam stream.  
8. Ubah data objek OLE dari stream.  

Pada contoh di bawah, sebuah bingkai objek OLE (objek diagram Excel yang disematkan dalam slide) diakses, dan data file-nya dimodifikasi untuk memperbarui data diagram.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Baca data objek OLE sebagai objek Workbook.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Modifikasi data workbook.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // Ubah data objek bingkai OLE.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Menyematkan Jenis File Lain ke Slide**

Selain diagram Excel, Aspose.Slides for PHP via Java memungkinkan Anda menyematkan jenis file lain ke dalam slide. Misalnya, Anda dapat menyisipkan file HTML, PDF, dan ZIP sebagai objek. Ketika pengguna mengklik ganda objek yang disisipkan, secara otomatis akan terbuka di program yang relevan, atau pengguna akan diminta memilih program yang sesuai untuk membukanya.

Kode PHP ini menunjukkan cara menyematkan HTML dan ZIP ke dalam slide:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Mengatur Tipe File untuk Objek yang Disematkan**

Saat bekerja dengan presentasi, Anda mungkin perlu mengganti objek OLE lama dengan yang baru atau mengganti objek OLE yang tidak didukung dengan yang didukung. Aspose.Slides for PHP via Java memungkinkan Anda mengatur tipe file untuk objek yang disematkan, sehingga Anda dapat memperbarui data bingkai OLE atau ekstensi-nya.

Kode PHP ini menunjukkan cara mengatur tipe file untuk objek OLE yang disematkan menjadi `zip`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Ubah tipe file menjadi ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Mengatur Gambar Ikon dan Judul untuk Objek yang Disematkan**

Setelah menyematkan objek OLE, preview yang terdiri dari gambar ikon secara otomatis ditambahkan. Preview ini adalah yang dilihat pengguna sebelum mengakses atau membuka objek OLE. Jika Anda ingin menggunakan gambar dan teks tertentu sebagai elemen dalam preview, Anda dapat mengatur gambar ikon dan judul menggunakan Aspose.Slides for PHP via Java.

Kode PHP ini menunjukkan cara mengatur gambar ikon dan judul untuk objek yang disematkan:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Tambahkan gambar ke sumber daya presentasi.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Set a title and the image for the OLE preview.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Mencegah Bingkai OLE Object dari Diubah Ukuran dan Posisi**

Setelah Anda menambahkan objek OLE yang ditautkan ke slide presentasi, ketika Anda membuka presentasi di PowerPoint, Anda mungkin melihat pesan yang meminta Anda memperbarui tautan. Mengklik tombol "Update Links" dapat mengubah ukuran dan posisi bingkai objek OLE karena PowerPoint memperbarui data dari objek OLE yang ditautkan dan memperbarui preview objek. Untuk mencegah PowerPoint menampilkan prompt memperbarui data objek, setel metode `setUpdateAutomatic` dari kelas [OleObjectFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/oleobjectframe/) menjadi `false`:

```php
$oleFrame->setUpdateAutomatic(false);
```

## **Mengekstrak File yang Disematkan**

Aspose.Slides for PHP via Java memungkinkan Anda mengekstrak file yang disematkan dalam slide sebagai objek OLE dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) yang berisi objek OLE yang ingin Anda ekstrak.  
2. Lakukan iterasi melalui semua shape dalam presentasi dan akses shape [OLEObjectFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/oleobjectframe/).  
3. Akses data file yang disematkan dari bingkai objek OLE dan tulis ke disk.  

Kode PHP ini menunjukkan cara mengekstrak file yang disematkan dalam slide sebagai objek OLE:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```

## **FAQ**

**Apakah konten OLE akan dirender saat mengekspor slide ke PDF/gambar?**

Yang terlihat pada slide yang dirender—ikon/gambar pengganti (preview). Konten OLE "live" tidak dieksekusi selama proses rendering. Jika diperlukan, atur gambar preview Anda sendiri untuk memastikan tampilan yang diharapkan dalam PDF yang diekspor.

**Bagaimana cara mengunci objek OLE pada slide sehingga pengguna tidak dapat memindahkan/mengeditnya di PowerPoint?**

Kunci shape: Aspose.Slides menyediakan kunci pada tingkat shape. Ini bukan enkripsi, tetapi secara efektif mencegah pengeditan dan pergerakan yang tidak disengaja.

**Apakah jalur relatif untuk objek OLE yang ditautkan akan dipertahankan dalam format PPTX?**

Pada PPTX, informasi "jalur relatif" tidak tersedia—hanya jalur lengkap. Jalur relatif ditemukan pada format PPT yang lebih lama. Untuk portabilitas, lebih baik menggunakan jalur absolut yang dapat diandalkan/URI yang dapat diakses atau penyematan.