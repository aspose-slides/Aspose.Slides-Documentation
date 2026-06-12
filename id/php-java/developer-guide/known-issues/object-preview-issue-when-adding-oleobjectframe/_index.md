---
title: Masalah Pratinjau Objek Saat Menambahkan OleObjectFrame
linktitle: Masalah Objek OLE
type: docs
weight: 10
url: /id/php-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- masalah pratinjau
- menyematkan objek
- menyematkan file
- objek berubah
- pratinjau objek
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari mengapa EMBEDDED OLE OBJECT muncul saat menambahkan OleObjectFrame di Aspose.Slides untuk PHP dan bagaimana memperbaiki masalah pratinjau pada presentasi PPT, PPTX, dan ODP."
---
## **Pendahuluan**

Menggunakan Aspose.Slides for PHP via Java, ketika Anda menambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/oleobjectframe/) ke slide, pesan "EMBEDDED OLE OBJECT" ditampilkan pada slide output. Pesan ini memang sengaja ditampilkan dan **bukan** sebuah bug.

Untuk informasi lebih lanjut tentang cara bekerja dengan objek OLE, lihat [Kelola OLE](/slides/id/php-java/manage-ole/). 

## **Penjelasan dan Solusi**

Aspose.Slides menampilkan pesan "EMBEDDED OLE OBJECT" untuk memberi tahu Anda bahwa objek OLE telah diubah dan gambar pratinjau harus diperbarui. 

Sebagai contoh, jika Anda menambahkan grafik Microsoft Excel sebagai [OleObjectFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/oleobjectframe/) ke slide (untuk detail lebih lanjut, lihat artikel "Kelola OLE") dan kemudian membuka presentasi di Microsoft PowerPoint, Anda akan melihat gambar ini pada slide:

![Pesan objek OLE](OLE_object_message.png)

Jika Anda ingin memeriksa dan memastikan bahwa objek OLE Anda telah ditambahkan ke slide, Anda harus mengklik dua kali pada pesan "EMBEDDED OLE OBJECT", atau Anda dapat mengklik kanan pada pesan tersebut dan memilih opsi **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint kemudian membuka objek OLE yang disematkan.

![Data objek OLE](OLE_object_data.png)

Slide dapat tetap menampilkan pesan "EMBEDDED OLE OBJECT". Setelah Anda mengklik objek OLE, pratinjau slide akan diperbarui dan pesan "EMBEDDED OLE OBJECT" akan digantikan oleh gambar aktual untuk objek OLE tersebut. 

![Pratinjau objek OLE](OLE_object_preview.png)

Sekarang, Anda mungkin ingin menyimpan presentasi Anda agar gambar untuk Objek OLE diperbarui dengan benar. Dengan cara ini, setelah menyimpan presentasi, ketika Anda membuka kembali presentasi, Anda **tidak** akan melihat pesan "EMBEDDED OLE OBJECT". 

## **Solusi Lain**

### **Solusi 1: Ganti Pesan "Embedded OLE Object" dengan Gambar**

Jika Anda tidak ingin menghapus pesan "EMBEDDED OLE OBJECT" dengan membuka presentasi di PowerPoint dan kemudian menyimpannya, Anda dapat mengganti pesan tersebut dengan gambar pratinjau pilihan Anda. Baris kode berikut menunjukkan prosesnya:

```php
$presentation = new Presentation("embeddedOLE.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $oleFrame = $slide->getShapes()->get_Item(0);

    // Tambah gambar ke sumber daya presentasi.
    $image = Images::fromFile("myImage.png");
    $oleImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Atur judul dan gambar untuk pratinjau objek OLE.
    $oleFrame->setSubstitutePictureTitle("My title");
    $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
    $oleFrame->setObjectIcon(false);

    $presentation->save("embeddedOLE-newImage.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Slide yang berisi `OleObjectFrame` kemudian berubah menjadi ini:

![Gambar objek OLE baru](OLE_object_new_image.png)

### **Solusi 2: Buat Add-On untuk PowerPoint**

Anda juga dapat membuat add-on untuk Microsoft PowerPoint yang memperbarui semua objek OLE ketika Anda membuka presentasi di program tersebut.