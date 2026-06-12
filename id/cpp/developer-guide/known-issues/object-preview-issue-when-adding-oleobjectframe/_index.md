---
title: Masalah Pratinjau Objek Saat Menambahkan OleObjectFrame
linktitle: Masalah Objek OLE
type: docs
weight: 10
url: /id/cpp/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- masalah pratinjau
- objek tersemat
- file tersemat
- objek berubah
- pratinjau objek
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari mengapa EMBEDDED OLE OBJECT muncul saat menambahkan OleObjectFrame di Aspose.Slides untuk C++ dan cara memperbaiki masalah pratinjau pada presentasi PPT, PPTX, dan ODP."
---
## **Pendahuluan**

Menggunakan Aspose.Slides untuk C++, ketika Anda menambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/oleobjectframe/) ke sebuah slide, pesan "EMBEDDED OLE OBJECT" ditampilkan pada slide output. Pesan ini memang sengaja ditampilkan dan BUKAN bug.

Untuk informasi lebih lanjut tentang bekerja dengan objek OLE, lihat [Manage OLE](/slides/id/cpp/manage-ole/). 

## **Penjelasan dan Solusi**

Aspose.Slides menampilkan pesan "EMBEDDED OLE OBJECT" untuk memberi tahu Anda bahwa objek OLE telah berubah dan gambar pratinjau harus diperbarui. 

Sebagai contoh, jika Anda menambahkan bagan Microsoft Excel sebagai [OleObjectFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/oleobjectframe/) ke sebuah slide (untuk detail lebih lanjut, lihat artikel "Manage OLE") dan kemudian membuka presentasi di Microsoft PowerPoint, Anda akan melihat gambar ini pada slide:

![OLE object message](OLE_object_message.png)

Jika Anda ingin memeriksa dan memastikan bahwa objek OLE Anda telah ditambahkan ke slide, Anda harus mengklik ganda pada pesan "EMBEDDED OLE OBJECT", atau Anda dapat mengklik kanan dan melalui opsi **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint kemudian membuka objek OLE yang disematkan.

![OLE object data](OLE_object_data.png)

Slide mungkin masih menampilkan pesan "EMBEDDED OLE OBJECT". Setelah Anda mengklik objek OLE, pratinjau slide diperbarui dan pesan "EMBEDDED OLE OBJECT" digantikan oleh gambar sebenarnya untuk objek OLE. 

![OLE object preview](OLE_object_preview.png)

Sekarang, Anda mungkin ingin menyimpan presentasi Anda untuk memastikan gambar untuk OLE Object diperbarui dengan benar. Dengan cara ini, setelah menyimpan presentasi, ketika Anda membuka presentasi lagi, Anda TIDAK akan melihat pesan "EMBEDDED OLE OBJECT". 

## **Solusi Lain**

### **Solusi 1: Ganti Pesan "Embedded OLE Object" dengan Gambar**

Jika Anda tidak ingin menghapus pesan "EMBEDDED OLE OBJECT" dengan membuka presentasi di PowerPoint lalu menyimpannya, Anda dapat mengganti pesan tersebut dengan gambar pratinjau pilihan Anda. Baris kode berikut menunjukkan prosesnya:

```cpp
auto presentation = MakeObject<Presentation>(u"embeddedOLE.pptx");

auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to presentation resources.
auto imageStream = File::OpenRead(u"myImage.png");
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Set a title and the image for the OLE object preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"embeddedOLE-newImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Slide yang berisi `OleObjectFrame` kemudian berubah menjadi ini:

![New OLE object image](OLE_object_new_image.png)

### **Solusi 2: Buat Add-On untuk PowerPoint**

Anda juga dapat membuat add-on untuk Microsoft PowerPoint yang memperbarui semua objek OLE ketika Anda membuka presentasi di program tersebut.