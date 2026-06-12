---
title: API Publik dan Perubahan Tidak Kompatibel ke Belakang di Aspose.Slides untuk .NET 14.4.0
linktitle: Aspose.Slides untuk .NET 14.4.0
type: docs
weight: 60
url: /id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- migrasi
- kode warisan
- kode modern
- pendekatan warisan
- pendekatan modern
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Tinjau pembaruan API publik dan perubahan yang memecah di Aspose.Slides untuk .NET untuk memigrasi solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan mulus."
---
## **API Publik dan Perubahan Tidak Kompatibel ke Belakang**
### **Antarmuka, Kelas, Metode, dan Properti yang Ditambahkan**
#### **Properti Aspose.Slides.ILayoutSlide.HasDependingSlides Telah Ditambahkan**
Properti Aspose.Slides.ILayoutSlide.HasDependingSlides mengembalikan true jika ada setidaknya satu slide yang bergantung pada layout slide ini. Misalnya:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Metode Aspose.Slides.ILayoutSlide.Remove()**
Metode Aspose.Slides.ILayoutSlide.Remove() memungkinkan Anda menghapus layout dari presentasi dengan kode minimal. Misalnya:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Metode Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
Metode Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) memungkinkan Anda menghapus layout dari koleksi. Contoh kode:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

atau

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
Metode Aspose.Slides.ILayoutSlideCollection.RemoveUnused() memungkinkan Anda menghapus layout slide yang tidak digunakan (layout slide yang HasDependingSlides‑nya false). Contoh kode:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

atau

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Properti Aspose.Slides.IMasterSlide.HasDependingSlides**
Properti Aspose.Slides.IMasterSlide.HasDependingSlides mengembalikan true jika ada setidaknya satu slide yang bergantung pada master slide ini. Misalnya:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Metode Aspose.Slides.ISlide.Remove()**
Metode Aspose.Slides.ISlide.Remove() memungkinkan Anda menghapus slide dari presentasi dengan kode minimal. Misalnya:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
Properti Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat mengembalikan IFillFormat untuk bullet node SmartArt jika tata letak menyediakan bullet. Properti ini dapat digunakan untuk mengatur gambar bullet.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Properti Aspose.Slides.SmartArt.ISmartArtNode.Level**
Properti Aspose.Slides.SmartArt.ISmartArtNode.Level mengembalikan tingkat bersarang untuk node SmartArt.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Properti Aspose.Slides.SmartArt.ISmartArtNode.Position**
Properti Aspose.Slides.SmartArt.ISmartArtNode.Position mengembalikan posisi sebuah node di antara saudara‑saudaranya.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Metode Aspose.Slides.SmartArt.ISmartArtNode.Remove() Telah Ditambahkan**
Metode Aspose.Slides.SmartArt.ISmartArtNode.Remove() memungkinkan penghapusan sebuah node dari diagram.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **Antarmuka IGlobalLayoutSlideCollection dan Kelas GlobalLayoutSlideCollection**
Antarmuka IGlobalLayoutSlideCollection dan kelas GlobalLayoutSlideCollection telah ditambahkan ke ruang nama Aspose.Slides.

Kelas GlobalLayoutSlideCollection mengimplementasikan antarmuka IGlobalLayoutSlideCollection.

Antarmuka IGlobalLayoutSlideCollection mewakili koleksi semua layout slide dalam sebuah presentasi. Properti IPresentation.LayoutSlides bertipe IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection memperluas antarmuka ILayoutSlideCollection dengan metode untuk menambahkan dan mengkloning layout slide dalam konteks penggabungan koleksi individual layout slide master:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Dapat digunakan untuk menambahkan salinan layout slide yang ditentukan ke presentasi. Metode ini mempertahankan format sumber (ketika mengkloning layout antara presentasi yang berbeda, master layout juga dapat dikloning. Registry internal digunakan untuk melacak master yang dikloning secara otomatis guna mencegah pembuatan banyak klon dari master slide yang sama.)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Digunakan untuk menambahkan salinan layout slide yang ditentukan ke sebuah presentasi. Layout baru akan terhubung dengan master yang ditentukan di presentasi tujuan. Opsi ini analog dengan menyalin atau menempel dengan opsi **Use Destination Theme** di Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Digunakan untuk menambahkan layout slide baru ke sebuah presentasi. Jenis layout yang didukung: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Nama layout dapat dihasilkan secara otomatis. Layout yang ditambahkan dengan tipe SlideLayoutType.Custom tidak berisi placeholder maupun shape. Metode analognya adalah IMasterLayoutSlideCollection.Add(SlideLayoutType, string) yang diakses melalui properti IMasterSlide.LayoutSlides.
#### **Antarmuka IMasterLayoutSlideCollection dan Kelas MasterLayoutSlideCollection**
Antarmuka IMasterLayoutSlideCollection dan kelas MasterLayoutSlideCollection telah ditambahkan ke ruang nama Aspose.Slides. Kelas MasterLayoutSlideCollection mengimplementasikan antarmuka IMasterLayoutSlideCollection.

Antarmuka IMasterLayoutSlideCollection mewakili koleksi semua layout slide dari sebuah master slide yang ditentukan. Antarmuka ini memperluas antarmuka ILayoutSlideCollection dengan metode untuk menambahkan, menyisipkan, menghapus, atau mengkloning layout slide dalam konteks koleksi individual layout slide master:

``` csharp

 // Tanda tangan metode:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Contoh kode yang menempelkan salinan sourceLayout ke destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

Metode ini dapat digunakan untuk menambahkan salinan layout slide yang ditentukan ke akhir koleksi. Layout baru akan terhubung dengan master slide induk untuk koleksi layout slide ini. Jadi ini analog dengan menyalin atau menempel dengan opsi **Use Destination Theme** di PowerPoint. Metode analognya adalah IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) yang diakses melalui properti IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Digunakan untuk menyisipkan salinan layout slide yang ditentukan ke posisi tertentu dalam koleksi. Layout baru akan terhubung dengan master slide induk untuk koleksi layout slide ini. Jadi ini analog dengan menyalin dan menempel dengan opsi **Use Destination Theme** di PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Digunakan untuk menambahkan atau menyisipkan layout slide baru. Jenis layout yang didukung: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Nama layout dapat dihasilkan secara otomatis. Layout yang ditambahkan dengan tipe SlideLayoutType.Custom tidak berisi placeholder maupun shape. Metode analognya adalah IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) yang diakses melalui properti IPresentation.LayoutSlides.
- void RemoveAt(int index); – Digunakan untuk menghapus layout pada indeks yang ditentukan dalam koleksi.
- void Reorder(int index, ILayoutSlide layoutSlide); – Digunakan untuk memindahkan layout slide dalam koleksi ke posisi yang ditentukan.
### **Metode dan Properti yang Diubah**
#### **Signature of the Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide) Method**
Signature metode ISlideCollection:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);
telah usang dan digantikan dengan signature

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

Parameter `allowCloneMissingLayout` menentukan tindakan jika tidak ada layout yang sesuai di `destMaster` untuk slide (klon) baru. Layout yang sesuai adalah layout dengan tipe atau nama yang sama dengan layout slide sumber. Jika tidak ada layout yang sesuai di master yang ditentukan, maka layout slide sumber akan dikloning (jika `allowCloneMissingLayout` true) atau `PptxEditException` akan dilempar (jika `allowCloneMissingLayout` false).

Pemanggilan metode yang usang seperti

AddClone(sourceSlide, destMaster);

mengasumsikan `allowCloneMissingLayout` bernilai false (artinya `PptxEditException` akan dilempar jika tidak ada layout yang sesuai). Pemanggilan yang secara fungsional identik dengan signature baru adalah:

AddClone(sourceSlide, destMaster, false);

Jika Anda ingin layout yang hilang otomatis dikloning alih‑alih melempar `PptxEditException`, maka berikan nilai `true` pada parameter `allowCloneMissingLayout`.

Hal yang sama berlaku untuk metode ISlideCollection:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

juga usang dan digantikan dengan signature

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Type of the Aspose.Slides.IMasterSlide.LayoutSlides Property**
Tipe properti Aspose.Slides.IMasterSlide.LayoutSlides telah diubah dari ILayoutSlideCollection menjadi antarmuka IMasterLayoutSlideCollection yang baru. Antarmuka IMasterLayoutSlideCollection merupakan turunan dari ILayoutSlideCollection sehingga kode yang ada tidak memerlukan adaptasi.
#### **Type of the Aspose.Slides.IPresentation.LayoutSlides Property Has Been Changed**
Tipe properti Aspose.Slides.IPresentation.LayoutSlides telah diubah dari ILayoutSlideCollection menjadi antarmuka IGlobalLayoutSlideCollection yang baru. Antarmuka IGlobalLayoutSlideCollection merupakan turunan dari ILayoutSlideCollection sehingga kode yang ada tidak memerlukan adaptasi.