---
title: Masalah Pratinjau Objek Saat Menambahkan OleObjectFrame
linktitle: Masalah Objek OLE
type: docs
weight: 10
url: /id/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- masalah pratinjau
- menyematkan objek
- menyematkan file
- objek berubah
- pratinjau objek
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari mengapa EMBEDDED OLE OBJECT muncul saat menambahkan OleObjectFrame di Aspose.Slides untuk Python via Java dan cara memperbaiki masalah pratinjau pada presentasi PPT, PPTX, dan ODP."
---
## **Pendahuluan**

Saat Anda menggunakan Aspose.Slides for Python via Java untuk menambahkan sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleobjectframe/) ke slide, pesan "EMBEDDED OLE OBJECT" akan ditampilkan pada slide output. Pesan ini memang disengaja dan bukan bug.

Untuk informasi lebih lanjut tentang bekerja dengan objek OLE, lihat [Manage OLE](/slides/id/python-java/manage-ole/).

## **Penjelasan dan Solusi**

Aspose.Slides menampilkan pesan "EMBEDDED OLE OBJECT" untuk memberi tahu Anda bahwa objek OLE telah diubah dan gambar pratinjau harus diperbarui.

Sebagai contoh, jika Anda menambahkan grafik Microsoft Excel sebagai [OleObjectFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleobjectframe/) ke slide (untuk detail lebih lanjut, lihat artikel "Manage OLE") dan kemudian membuka presentasi di Microsoft PowerPoint, Anda akan melihat gambar ini pada slide:

![Pesan objek OLE](OLE_object_message.png)

Untuk memastikan bahwa objek OLE Anda telah ditambahkan ke slide, klik dua kali pada pesan "EMBEDDED OLE OBJECT", atau klik kanan dan pilih **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint kemudian membuka objek OLE yang disematkan.

![Data objek OLE](OLE_object_data.png)

Slide mungkin tetap menampilkan pesan "EMBEDDED OLE OBJECT". Setelah Anda mengklik objek OLE, pratinjau slide diperbarui dan pesan "EMBEDDED OLE OBJECT" digantikan oleh gambar aktual untuk objek OLE tersebut.

![Pratinjau objek OLE](OLE_object_preview.png)

Simpan presentasi Anda untuk mempertahankan gambar pratinjau objek OLE yang telah diperbarui. Ketika Anda membuka kembali presentasi, pesan "EMBEDDED OLE OBJECT" tidak akan muncul lagi.

## **Solusi Lain**

Jika Anda tidak ingin menghapus pesan "EMBEDDED OLE OBJECT" dengan membuka presentasi di PowerPoint dan kemudian menyimpannya, Anda dapat mengganti pesan tersebut dengan gambar pratinjau pilihan Anda. Kode berikut menunjukkan prosesnya:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Tambahkan gambar ke sumber daya presentasi.
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Setel judul dan gambar untuk pratinjau objek OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Slide yang berisi [OleObjectFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleobjectframe/) kemudian berubah menjadi ini:

![Gambar objek OLE baru](OLE_object_new_image.png)

## **FAQ**

**Mengapa pesan "EMBEDDED OLE OBJECT" muncul?**

Pesan tersebut menunjukkan bahwa objek OLE telah berubah dan gambar pratinjau perlu diperbarui. Perilaku ini memang disengaja.

**Bagaimana cara memperbarui pratinjau di PowerPoint?**

Klik dua kali pada pesan atau pilih **Object > Edit** untuk membuka objek OLE yang disematkan. Klik objek OLE untuk memperbarui pratinjau, kemudian simpan presentasi.

**Apakah saya dapat mengganti pesan tanpa membuka presentasi di PowerPoint?**

Ya. Anda dapat menetapkan gambar pratinjau pilihan ke objek OLE, seperti yang ditunjukkan dalam contoh kode di atas.