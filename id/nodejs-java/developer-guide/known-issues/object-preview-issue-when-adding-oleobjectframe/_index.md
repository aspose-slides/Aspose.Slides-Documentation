---
title: Masalah Pratinjau Objek Saat Menambahkan OleObjectFrame
linktitle: Masalah Objek OLE
type: docs
weight: 10
url: /id/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
aliases:
  - /nodejs-java/object-changed-issue-when-adding-oleobjectframe/
keywords:
- OLE
- masalah pratinjau
- objek tertanam
- file tertanam
- objek berubah
- pratinjau objek
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari mengapa EMBEDDED OLE OBJECT muncul saat menambahkan OleObjectFrame di Aspose.Slides untuk Node.js dan cara memperbaiki masalah pratinjau dalam presentasi PPT, PPTX, dan ODP."
---
## **Pendahuluan**

Menggunakan Aspose.Slides for Java, ketika Anda menambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/oleobjectframe/) ke sebuah slide, pesan "EMBEDDED OLE OBJECT" ditampilkan pada slide output. Pesan ini memang sengaja muncul dan BUKAN sebuah bug.

Untuk informasi lebih lanjut tentang bekerja dengan objek OLE, lihat [Manage OLE](/slides/id/nodejs-java/manage-ole/). 

## **Penjelasan dan Solusi**

Aspose.Slides menampilkan pesan "EMBEDDED OLE OBJECT" untuk memberi tahu Anda bahwa objek OLE telah diubah dan gambar pratinjau harus diperbarui. 

Misalnya, jika Anda menambahkan grafik Microsoft Excel sebagai [OleObjectFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/oleobjectframe/) ke sebuah slide (untuk detail lebih lanjut, lihat artikel "Manage OLE") dan kemudian membuka presentasi di Microsoft PowerPoint, Anda akan melihat gambar ini pada slide:

![Pesan objek OLE](OLE_object_message.png)

Jika Anda ingin memeriksa dan memastikan bahwa objek OLE Anda telah ditambahkan ke slide, Anda harus mengklik dua kali pada pesan "EMBEDDED OLE OBJECT", atau Anda dapat mengklik kanan padanya dan memilih opsi **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint kemudian membuka objek OLE yang tertanam.

![Data objek OLE](OLE_object_data.png)

Slide mungkin masih menampilkan pesan "EMBEDDED OLE OBJECT". Setelah Anda mengklik objek OLE, pratinjau slide diperbarui dan pesan "EMBEDDED OLE OBJECT" digantikan oleh gambar sebenarnya untuk objek OLE tersebut. 

![Pratinjau objek OLE](OLE_object_preview.png)

Sekarang, Anda mungkin ingin menyimpan presentasi Anda untuk memastikan gambar untuk Objek OLE diperbarui dengan benar. Dengan cara ini, setelah menyimpan presentasi, ketika Anda membuka presentasi lagi, Anda TIDAK akan melihat pesan "EMBEDDED OLE OBJECT". 

## **Solusi Lain**

### **Solusi 1: Ganti Pesan "Embedded OLE Object" dengan Gambar**

Jika Anda tidak ingin menghapus pesan "EMBEDDED OLE OBJECT" dengan membuka presentasi di PowerPoint lalu menyimpannya, Anda dapat mengganti pesan tersebut dengan gambar pratinjau pilihan Anda. Baris kode berikut menunjukkan prosesnya:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // Tambahkan gambar ke sumber daya presentasi.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // Atur judul dan gambar untuk pratinjau objek OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

![Gambar objek OLE baru](OLE_object_new_image.png)

### **Solusi 2: Buat Add-On untuk PowerPoint**

Anda juga dapat membuat add-on untuk Microsoft PowerPoint yang memperbarui semua objek OLE saat Anda membuka presentasi di program tersebut.