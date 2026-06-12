---
title: Masalah Pratinjau Objek Saat Menambahkan OleObjectFrame
linktitle: Masalah Objek OLE
type: docs
weight: 10
url: /id/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- masalah pratinjau
- menyematkan objek
- menyematkan file
- objek diubah
- pratinjau objek
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari mengapa EMBEDDED OLE OBJECT muncul saat menambahkan OleObjectFrame di Aspose.Slides untuk Node.js dan cara memperbaiki masalah pratinjau pada presentasi PPT, PPTX, dan ODP."
---
## **Pengantar**

Dengan menggunakan Aspose.Slides for Java, ketika Anda menambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/oleobjectframe/) ke sebuah slide, pesan "EMBEDDED OLE OBJECT" ditampilkan pada slide output. Pesan ini memang disengaja dan BUKAN merupakan bug.

Untuk informasi lebih lanjut tentang cara bekerja dengan objek OLE, lihat [Kelola OLE](/slides/id/nodejs-java/manage-ole/). 

## **Penjelasan dan Solusi**

Aspose.Slides menampilkan pesan "EMBEDDED OLE OBJECT" untuk memberi tahu Anda bahwa objek OLE telah diubah dan gambar pratinjau harus diperbarui. 

Misalnya, jika Anda menambahkan diagram Microsoft Excel sebagai [OleObjectFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/oleobjectframe/) ke sebuah slide (untuk detail lebih lanjut, lihat artikel "Kelola OLE") dan kemudian membuka presentasi di Microsoft PowerPoint, Anda akan melihat gambar ini pada slide:

![OLE object message](OLE_object_message.png)

Jika Anda ingin memeriksa dan memastikan bahwa objek OLE Anda telah ditambahkan ke slide, Anda harus mengklik dua kali pada pesan "EMBEDDED OLE OBJECT", atau Anda dapat mengklik kanan padanya dan memilih opsi **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint kemudian membuka objek OLE yang disematkan.

![OLE object data](OLE_object_data.png)

Slide dapat tetap menampilkan pesan "EMBEDDED OLE OBJECT". Setelah Anda mengklik objek OLE, pratinjau slide akan diperbarui dan pesan "EMBEDDED OLE OBJECT" digantikan oleh gambar sebenarnya untuk objek OLE. 

![OLE object preview](OLE_object_preview.png)

Sekarang, Anda mungkin ingin menyimpan presentasi Anda untuk memastikan gambar untuk Objek OLE diperbarui dengan benar. Dengan cara ini, setelah menyimpan presentasi, ketika Anda membuka kembali presentasi, Anda TIDAK akan melihat pesan "EMBEDDED OLE OBJECT". 

## **Solusi Lain**

### **Solusi 1: Ganti Pesan "Embedded OLE Object" dengan Gambar**

Jika Anda tidak ingin menghapus pesan "EMBEDDED OLE OBJECT" dengan membuka presentasi di PowerPoint lalu menyimpannya, Anda dapat mengganti pesan tersebut dengan gambar pratinjau pilihan Anda. Baris-baris kode berikut menunjukkan prosesnya:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // Menambahkan gambar ke sumber daya presentasi.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // Menetapkan judul dan gambar untuk pratinjau objek OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Slide yang berisi `OleObjectFrame` kemudian berubah menjadi ini:

![New OLE object image](OLE_object_new_image.png)

### **Solusi 2: Buat Add-On untuk PowerPoint**

Anda juga dapat membuat add-on untuk Microsoft PowerPoint yang memperbarui semua objek OLE saat Anda membuka presentasi dalam program tersebut.