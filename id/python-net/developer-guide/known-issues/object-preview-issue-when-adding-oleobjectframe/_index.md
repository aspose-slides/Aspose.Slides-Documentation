---
title: Masalah Pratinjau Objek Saat Menambahkan OleObjectFrame
linktitle: Masalah Objek OLE
type: docs
weight: 10
url: /id/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- masalah pratinjau
- menyematkan objek
- menyematkan file
- objek berubah
- pratinjau objek
- presentasi
- PowerPoint
- Python
- Aspose.Slides
description: "Pelajari mengapa EMBEDDED OLE OBJECT muncul saat menambahkan OleObjectFrame di Aspose.Slides untuk Python dan cara memperbaiki masalah pratinjau dalam presentasi PPT, PPTX, dan ODP."
---
## **Pengantar**

Dengan menggunakan Aspose.Slides untuk Python via .NET, ketika Anda menambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/oleobjectframe/) ke sebuah slide, pesan "EMBEDDED OLE OBJECT" ditampilkan pada slide output. Pesan ini memang sengaja ditampilkan dan BUKAN bug.

Untuk informasi lebih lanjut tentang bekerja dengan objek OLE, lihat [Manage OLE](/slides/id/python-net/manage-ole/). 

## **Penjelasan dan Solusi**

Aspose.Slides menampilkan pesan "EMBEDDED OLE OBJECT" untuk memberi tahu Anda bahwa objek OLE telah diubah dan gambar pratinjau perlu diperbarui. 

Misalnya, jika Anda menambahkan grafik Microsoft Excel sebagai [OleObjectFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/oleobjectframe/) ke sebuah slide (untuk detail lebih lanjut, lihat artikel "Manage OLE") dan kemudian membuka presentasi di Microsoft PowerPoint, Anda akan melihat gambar ini pada slide:

![pesan objek OLE](OLE_object_message.png)

Jika Anda ingin memeriksa dan memastikan bahwa objek OLE Anda telah ditambahkan ke slide, Anda harus mengklik ganda pada pesan "EMBEDDED OLE OBJECT", atau Anda dapat mengklik kanan pada pesan tersebut dan memilih opsi **Object > Edit**.

![objek OLE > Edit](OLE_object_edit.png)

PowerPoint kemudian membuka objek OLE yang disematkan.

![data objek OLE](OLE_object_data.png)

Slide mungkin masih menampilkan pesan "EMBEDDED OLE OBJECT". Setelah Anda mengklik objek OLE, pratinjau slide akan diperbarui dan pesan "EMBEDDED OLE OBJECT" akan digantikan oleh gambar sebenarnya untuk objek OLE. 

![pratinjau objek OLE](OLE_object_preview.png)

Sekarang, Anda mungkin ingin menyimpan presentasi Anda untuk memastikan gambar untuk Objek OLE diperbarui dengan benar. Dengan cara ini, setelah menyimpan presentasi, ketika Anda membuka presentasi lagi, Anda tidak akan melihat pesan "EMBEDDED OLE OBJECT". 

## **Solusi Lain**

### **Solusi 1: Ganti Pesan "Embedded OLE Object" dengan Gambar**

Jika Anda tidak ingin menghapus pesan "EMBEDDED OLE OBJECT" dengan membuka presentasi di PowerPoint lalu menyimpannya, Anda dapat mengganti pesan tersebut dengan gambar pratinjau pilihan Anda. Baris kode berikut menunjukkan prosesnya:

```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Tambahkan gambar ke sumber daya presentasi.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # Setel judul dan gambar untuk pratinjau objek OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```

Slide yang berisi `OleObjectFrame` kemudian berubah menjadi ini:

![gambar objek OLE baru](OLE_object_new_image.png)

### **Solusi 2: Buat Add-On untuk PowerPoint**

Anda juga dapat membuat add-on untuk Microsoft PowerPoint yang memperbarui semua objek OLE ketika Anda membuka presentasi di program tersebut.