---
title: Masalah Pratinjau Objek Saat Menambahkan OleObjectFrame
linktitle: Masalah Objek OLE
type: docs
weight: 10
url: /id/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- masalah pratinjau
- menyematkan objek
- menyematkan berkas
- objek berubah
- pratinjau objek
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari mengapa EMBEDDED OLE OBJECT muncul saat menambahkan OleObjectFrame di Aspose.Slides untuk Java dan cara memperbaiki masalah pratinjau pada presentasi PPT, PPTX, dan ODP."
---
## **Pendahuluan**

Menggunakan Aspose.Slides for Java, ketika Anda menambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/oleobjectframe/) ke sebuah slide, pesan "EMBEDDED OLE OBJECT" ditampilkan pada slide output. Pesan ini memang disengaja dan BUKAN bug.

Untuk informasi lebih lanjut tentang cara bekerja dengan objek OLE, lihat [Manage OLE](/slides/id/java/manage-ole/).

## **Penjelasan dan Solusi**

Aspose.Slides menampilkan pesan "EMBEDDED OLE OBJECT" untuk memberi tahu Anda bahwa objek OLE telah diubah dan gambar pratinjau harus diperbarui. 

Sebagai contoh, jika Anda menambahkan diagram Microsoft Excel sebagai [OleObjectFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/oleobjectframe/) ke sebuah slide (untuk detail lebih lanjut, lihat artikel "Manage OLE") dan kemudian membuka presentasi di Microsoft PowerPoint, Anda akan melihat gambar ini pada slide:

![OLE object message](OLE_object_message.png)

Jika Anda ingin memeriksa dan memastikan bahwa objek OLE Anda telah ditambahkan ke slide, Anda harus mengklik dua kali pada pesan "EMBEDDED OLE OBJECT", atau Anda dapat mengklik kanan padanya dan memilih opsi **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint kemudian membuka objek OLE yang disematkan.

![OLE object data](OLE_object_data.png)

Slide tersebut mungkin tetap menampilkan pesan "EMBEDDED OLE OBJECT". Setelah Anda mengklik objek OLE, pratinjau slide diperbarui dan pesan "EMBEDDED OLE OBJECT" digantikan oleh gambar sebenarnya untuk objek OLE. 

![OLE object preview](OLE_object_preview.png)

Sekarang, Anda mungkin ingin menyimpan presentasi Anda untuk memastikan gambar untuk Objek OLE diperbarui dengan benar. Dengan cara ini, setelah menyimpan presentasi, ketika Anda membuka presentasi lagi, Anda TIDAK akan melihat pesan "EMBEDDED OLE OBJECT". 

## **Solusi Lain**

Jika Anda tidak ingin menghapus pesan "EMBEDDED OLE OBJECT" dengan membuka presentasi di PowerPoint lalu menyimpannya, Anda dapat mengganti pesan tersebut dengan gambar pratinjau pilihan Anda. Baris kode berikut menunjukkan prosesnya:

```java
import com.aspose.slides.*;

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

![New OLE object image](OLE_object_new_image.png)