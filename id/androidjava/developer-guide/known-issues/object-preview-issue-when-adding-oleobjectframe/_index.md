---
title: "Masalah Pratinjau Objek Saat Menambahkan OleObjectFrame"
linktitle: "Masalah Objek OLE"
type: docs
weight: 10
url: /id/androidjava/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- masalah pratinjau
- menyisipkan objek
- menyisipkan berkas
- objek berubah
- pratinjau objek
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari mengapa EMBEDDED OLE OBJECT muncul saat menambahkan OleObjectFrame di Aspose.Slides untuk Android via Java dan cara memperbaiki masalah pratinjau di presentasi PPT, PPTX, dan ODP."
---
## **Pendahuluan**

Dengan menggunakan Aspose.Slides untuk Android via Java, ketika Anda menambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/oleobjectframe/) ke sebuah slide, pesan "EMBEDDED OLE OBJECT" ditampilkan pada slide output. Pesan ini memang disengaja dan BUKAN sebuah bug.

Untuk informasi lebih lanjut tentang cara bekerja dengan objek OLE, lihat [Manage OLE](/slides/id/androidjava/manage-ole/). 

## **Penjelasan dan Solusi**

Aspose.Slides menampilkan pesan "EMBEDDED OLE OBJECT" untuk memberi tahu Anda bahwa objek OLE telah berubah dan gambar pratinjau harus diperbarui. 

Sebagai contoh, jika Anda menambahkan diagram Microsoft Excel sebagai [OleObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/oleobjectframe/) ke sebuah slide (untuk detail lebih lanjut, lihat artikel "Manage OLE") dan kemudian membuka presentasi di Microsoft PowerPoint, Anda akan melihat gambar ini pada slide:

![Pesan objek OLE](OLE_object_message.png)

Jika Anda ingin memeriksa dan memastikan bahwa objek OLE Anda telah ditambahkan ke slide, Anda harus mengklik dua kali pada pesan "EMBEDDED OLE OBJECT", atau Anda dapat mengklik kanan pada pesan tersebut dan memilih opsi **Object > Edit**.

![Objek OLE > Edit](OLE_object_edit.png)

PowerPoint kemudian membuka objek OLE yang disematkan.

![Data objek OLE](OLE_object_data.png)

Slide mungkin masih menampilkan pesan "EMBEDDED OLE OBJECT". Setelah Anda mengklik objek OLE, pratinjau slide akan diperbarui dan pesan "EMBEDDED OLE OBJECT" digantikan oleh gambar sesungguhnya untuk objek OLE tersebut. 

![Pratinjau objek OLE](OLE_object_preview.png)

Sekarang, Anda mungkin ingin menyimpan presentasi Anda untuk memastikan gambar untuk Objek OLE diperbarui dengan benar. Dengan cara ini, setelah menyimpan presentasi, ketika Anda membuka kembali presentasi, Anda tidak akan melihat pesan "EMBEDDED OLE OBJECT". 

## **Solusi Lain**

### **Solusi 1: Ganti Pesan "Embedded OLE Object" dengan Gambar**

Jika Anda tidak ingin menghapus pesan "EMBEDDED OLE OBJECT" dengan membuka presentasi di PowerPoint dan kemudian menyimpannya, Anda dapat mengganti pesan tersebut dengan gambar pratinjau pilihan Anda. Baris-baris kode berikut menunjukkan prosesnya:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Tambahkan gambar ke sumber daya presentasi.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // Atur judul dan gambar untuk pratinjau objek OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

Slide yang berisi `OleObjectFrame` kemudian berubah menjadi ini:

![Gambar objek OLE baru](OLE_object_new_image.png)

### **Solusi 2: Buat Add-On untuk PowerPoint**

Anda juga dapat membuat add-on untuk Microsoft PowerPoint yang memperbarui semua objek OLE ketika Anda membuka presentasi di program tersebut.