---
title: Menyusun Slide
type: docs
weight: 10
url: /id/net/assemble-slides/
---
## **Menambahkan Slide ke Presentasi**
Sebelum membahas penambahan slide ke file presentasi, mari kita bahas beberapa fakta tentang slide. Setiap file presentasi PowerPoint berisi slide Master / Layout dan slide Normal lainnya. Artinya sebuah file presentasi berisi setidaknya satu atau lebih slide. Penting untuk diketahui bahwa file presentasi tanpa slide tidak didukung oleh Aspose.Slides for .NET. Setiap slide memiliki Id unik dan semua Slide Normal diatur dalam urutan yang ditentukan oleh indeks berbasis nol.

Aspose.Slides for .NET memungkinkan pengembang menambahkan slide kosong ke presentasi mereka. Untuk menambahkan slide kosong dalam presentasi, ikuti langkah-langkah berikut:

- Buat sebuah instance dari kelas **Presentation** 
- Instansiasi kelas **SlideCollection** dengan mengatur referensi ke properti Slides (koleksi objek Slide konten) yang diekspos oleh objek Presentation. 
- Tambahkan slide kosong ke presentasi di akhir koleksi slide konten dengan memanggil metode **AddEmptySlide** yang diekspos oleh objek **SlideCollection**. 
- Lakukan beberapa pekerjaan dengan slide kosong yang baru ditambahkan 
- Akhirnya, tulis file presentasi menggunakan objek **Presentation** 

``` csharp

 PresentationEx pres = new PresentationEx;

//Instansiasi kelas SlideCollection

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Tambahkan slide kosong ke koleksi Slides

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Simpan file PPTX ke Disk

pres.Write("EmptySlide.pptx");

``` 
## **Mengakses Slide dalam Presentasi**
Aspose.Slides for .NET menyediakan kelas Presentation yang dapat digunakan untuk menemukan dan mengakses slide apa pun yang diinginkan dalam presentasi.

**Menggunakan Koleksi Slides**

Kelas **Presentation** mewakili file presentasi dan mengekspose semua slide di dalamnya sebagai koleksi **SlideCollection** (yaitu koleksi objek **Slide**). Semua slide ini dapat diakses dari koleksi **Slides** ini menggunakan indeks slide.

``` csharp

 //Instansiasi objek Presentation yang mewakili file presentasi
PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");
//Mengakses slide menggunakan indeks slide-nya
SlideEx slide = pres.Slides[0];
``` 
## **Menghapus Slide**
Kami tahu bahwa kelas Presentation dalam **Aspose.Slides for .NET** mewakili sebuah file presentasi. Kelas Presentation mengenkapsulasi sebuah **SlideCollection** yang berfungsi sebagai repositori semua slide yang merupakan bagian dari presentasi. Pengembang dapat menghapus slide dari koleksi Slides ini dengan dua cara:

- Menggunakan Referensi Slide
- Menggunakan Indeks Slide

**Menggunakan Referensi Slide**

Untuk menghapus slide menggunakan referensinya, ikuti langkah-langkah berikut:

- Buat sebuah instance dari kelas Presentation 
- Dapatkan referensi sebuah slide dengan menggunakan Id atau Indeksnya 
- Hapus slide yang direferensikan dari presentasi 
- Tulis file presentasi yang telah dimodifikasi 

``` csharp

 //Instansiasi objek Presentation yang mewakili file presentasi
PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Mengakses slide menggunakan indeksnya dalam koleksi slides
SlideEx slide = pres.Slides[0];

//Menghapus slide menggunakan referensinya
pres.Slides.Remove(slide);

//Menulis file presentasi
pres.Write("modified.pptx");

``` 
## **Mengubah Posisi Slide**
Sangat mudah untuk mengubah posisi slide dalam presentasi. Cukup ikuti langkah-langkah berikut:

- Buat sebuah instance dari kelas Presentation 
- Dapatkan referensi sebuah slide dengan menggunakan Indeksnya 
- Ubah SlideNumber dari slide yang direferensikan 
- Tulis file presentasi yang telah dimodifikasi 

Dalam contoh di bawah ini, kami telah mengubah posisi slide (yang berada di posisi indeks nol 1) dalam presentasi menjadi indeks 1 (Posisi 2).

``` csharp

 private static string MyDir = @"..\..\..\Sample Files\";

static void Main(string[] args)

{

AddingSlidetoPresentation();

AccessingSlidesOfPresentation();

RemovingSlides();

ChangingPositionOfSlide();

}

public static void AddingSlidetoPresentation()

{

Presentation pres = new Presentation();

//Instansiasi kelas SlideCollection

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Tambahkan slide kosong ke koleksi Slides

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Simpan file PPTX ke Disk

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//Instansiasi objek Presentation yang mewakili file presentasi

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Mengakses slide menggunakan indeks slide-nya

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//Instansiasi objek Presentation yang mewakili file presentasi

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Mengakses slide menggunakan indeksnya dalam koleksi slides

ISlide slide = pres.Slides[0];

//Menghapus slide menggunakan referensinya

pres.Slides.Remove(slide);

//Menulis file presentasi

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//Instansiasi kelas Presentation untuk memuat file presentasi sumber

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //Dapatkan slide yang posisinya akan diubah

    ISlide sld = pres.Slides[0];

    //Atur posisi baru untuk slide

    sld.SlideNumber = 2;

    //Tulis presentasi ke disk

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}
``` 
## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)