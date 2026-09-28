---
title: Placeholder Pratinjau Objek Saat Menambahkan OleObjectFrame
linktitle: Placeholder Pratinjau OLE
type: docs
weight: 10
url: /id/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- masalah pratinjau
- placeholder pratinjau
- sebagaimana dirancang
- objek tersemat
- berkas tersemat
- objek berubah
- pratinjau objek
- presentasi
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Mengapa objek OLE yang ditambahkan dengan Aspose.Slides for .NET menampilkan placeholder EMBEDDED OLE OBJECT hingga pratinjau diperbarui, dan bagaimana menetapkan gambar pratinjau Anda sendiri."
---
## **Pendahuluan**

Menggunakan Aspose.Slides for .NET, ketika Anda menambahkan [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/) ke slide, pesan "EMBEDDED OLE OBJECT" ditampilkan pada slide output. Pesan ini disengaja dan BUKAN bug.

Untuk informasi lebih lanjut tentang bekerja dengan objek OLE, lihat [Manage OLE](/slides/id/net/manage-ole/).

## **Penjelasan dan Solusi**

Aspose.Slides menampilkan pesan "EMBEDDED OLE OBJECT" untuk memberi tahu Anda bahwa objek OLE telah diubah dan gambar pratinjau harus diperbarui.

Misalnya, jika Anda menambahkan diagram Microsoft Excel sebagai [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/) ke slide (untuk detail lebih lanjut, lihat artikel "Manage OLE") dan kemudian membuka presentasi di Microsoft PowerPoint, Anda akan melihat gambar ini pada slide:

![pesan objek OLE](OLE_object_message.png)

Jika Anda ingin memeriksa dan memastikan bahwa objek OLE Anda telah ditambahkan ke slide, Anda harus mengeklik dua kali pada pesan "EMBEDDED OLE OBJECT", atau Anda dapat mengeklik kanan pada pesan tersebut dan melalui opsi **Object > Edit**.

![Objek OLE > Edit](OLE_object_edit.png)

PowerPoint kemudian membuka objek OLE yang tersemat.

![data objek OLE](OLE_object_data.png)

Slide mungkin masih menampilkan pesan "EMBEDDED OLE OBJECT". Setelah Anda mengklik objek OLE, pratinjau slide diperbarui dan pesan "EMBEDDED OLE OBJECT" digantikan oleh gambar sebenarnya untuk objek OLE.

![pratinjau objek OLE](OLE_object_preview.png)

Sekarang, Anda mungkin ingin menyimpan presentasi Anda untuk memastikan gambar untuk OLE Object diperbarui dengan benar. Dengan cara ini, setelah menyimpan presentasi, ketika Anda membuka presentasi lagi, Anda TIDAK akan melihat pesan "EMBEDDED OLE OBJECT".

## **Solusi Lain**

### **Solusi 1: Ganti Pesan "Embedded OLE Object" dengan Gambar**

Jika Anda tidak ingin menghapus pesan "EMBEDDED OLE OBJECT" dengan membuka presentasi di PowerPoint dan kemudian menyimpannya, Anda dapat mengganti pesan tersebut dengan gambar pratinjau pilihan Anda. Baris kode berikut mendemonstrasikan prosesnya:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set the image for the OLE object preview.
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

Slide yang berisi `OleObjectFrame` kemudian berubah menjadi ini:

![gambar objek OLE baru](OLE_object_new_image.png)

### **Solusi 2: Buat Add-On untuk PowerPoint**

Anda juga dapat membuat add-on untuk Microsoft PowerPoint yang memperbarui semua objek OLE saat Anda membuka presentasi di program tersebut.