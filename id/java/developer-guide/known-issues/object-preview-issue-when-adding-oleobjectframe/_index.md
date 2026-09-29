---
title: Placeholder Pratinjau Objek Saat Menambahkan OleObjectFrame
linktitle: Placeholder Pratinjau OLE
type: docs
weight: 10
url: /id/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- masalah pratinjau
- placeholder pratinjau
- disengaja
- objek tertanam
- file tertanam
- objek diubah
- pratinjau objek
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Mengapa sebuah objek OLE yang ditambahkan dengan Aspose.Slides untuk Java menampilkan placeholder EMBEDDED OLE OBJECT sampai pratinjau-nya diperbarui, dan cara menetapkan gambar pratinjau Anda sendiri."
---
## **Pendahuluan**

Menggunakan Aspose.Slides untuk Java, ketika Anda menambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/oleobjectframe/) ke slide, pesan "EMBEDDED OLE OBJECT" ditampilkan pada slide output. Pesan ini bersifat disengaja dan BUKAN bug.

Untuk informasi lebih lanjut tentang cara bekerja dengan objek OLE, lihat [Manage OLE](/slides/id/java/manage-ole/).

## **Penjelasan dan Solusi**

Aspose.Slides menampilkan pesan "EMBEDDED OLE OBJECT" untuk memberi tahu Anda bahwa objek OLE telah diubah dan gambar pratinjau harus diperbarui.

Sebagai contoh, jika Anda menambahkan bagan Microsoft Excel sebagai [OleObjectFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/oleobjectframe/) ke slide (untuk detail lebih lanjut, lihat artikel "Manage OLE") dan kemudian membuka presentasi di Microsoft PowerPoint, Anda akan melihat gambar berikut pada slide:

![pesan objek OLE](OLE_object_message.png)

Jika Anda ingin memeriksa dan memastikan bahwa objek OLE Anda telah ditambahkan ke slide, Anda harus mengklik ganda pada pesan "EMBEDDED OLE OBJECT", atau Anda dapat mengklik kanan pada pesan tersebut dan memilih opsi **Object > Edit**.

![objek OLE > Edit](OLE_object_edit.png)

PowerPoint kemudian membuka objek OLE yang disematkan.

![data objek OLE](OLE_object_data.png)

Slide mungkin masih menampilkan pesan "EMBEDDED OLE OBJECT". Setelah Anda mengklik objek OLE, pratinjau slide akan diperbarui dan pesan "EMBEDDED OLE OBJECT" digantikan oleh gambar sebenarnya untuk objek OLE.

![pratinjau objek OLE](OLE_object_preview.png)

Sekarang, Anda mungkin ingin menyimpan presentasi Anda untuk memastikan gambar untuk Objek OLE diperbarui dengan benar. Dengan cara ini, setelah menyimpan presentasi, ketika Anda membuka kembali presentasi, Anda TIDAK akan melihat pesan "EMBEDDED OLE OBJECT".

## **Solusi Lain**

Jika Anda tidak ingin menghapus pesan "EMBEDDED OLE OBJECT" dengan membuka presentasi di PowerPoint dan kemudian menyimpannya, Anda dapat mengganti pesan tersebut dengan gambar pratinjau pilihan Anda. Baris kode berikut menunjukkan prosesnya. Mereka menganggap bahwa bentuk pertama pada slide pertama dari *embeddedOLE.pptx* adalah frame objek OLE dan bahwa *myImage.png* berisi gambar yang akan ditampilkan, dan mereka menyimpan hasilnya sebagai *embeddedOLE-newImage.pptx*:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Tambahkan gambar ke sumber daya presentasi.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);
    image.dispose();

    // Atur gambar untuk pratinjau objek OLE.
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Slide yang berisi `OleObjectFrame` kemudian berubah menjadi ini:

![gambar objek OLE baru](OLE_object_new_image.png)