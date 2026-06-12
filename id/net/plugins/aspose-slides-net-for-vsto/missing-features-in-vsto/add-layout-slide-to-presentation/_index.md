---
title: Tambahkan Slide Layout ke Presentasi
type: docs
weight: 10
url: /id/net/add-layout-slide-to-presentation/
---
Aspose.Slides for .NET memungkinkan pengembang menambahkan slide Layout baru dalam presentasi. Untuk menambahkan Slide Layout, ikuti langkah-langkah berikut:

- Buat instance dari kelas Presentation
- Akses koleksi Master Slide
- Coba temukan Layout slide yang sudah ada untuk melihat apakah yang dibutuhkan sudah tersedia di koleksi Layout Slide atau tidak
- Tambahkan Layout slide baru jika layout yang diinginkan tidak tersedia
- Tambahkan slide kosong dengan Layout slide yang baru ditambahkan
- Terakhir, tulis file presentasi menggunakan objek Presentation.
## **Contoh**
``` csharp

 //Instansiasi kelas Presentation yang mewakili file presentasi

using (Presentation p = new Presentation("Test.pptx"))

{

   //Coba cari berdasarkan tipe slide layout

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     //Situasi ketika sebuah presentasi tidak berisi beberapa jenis layout.

     //Presentasi Technographics.pptx hanya berisi jenis layout Blank dan Custom.

     //Namun slide layout dengan tipe Custom memiliki nama slide yang berbeda,

     //seperti "Title", "Title and Content", dll. Dan memungkinkan untuk menggunakan ini

     //nama untuk pemilihan slide layout.

     //Juga memungkinkan untuk menggunakan sekumpulan tipe placeholder shape. Misalnya,

     //Slide judul harus hanya memiliki tipe placeholder Title, dll.

     foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)

     {

       if (titleAndObjectLayoutSlide.Name == "Title and Object")

       {

          layoutSlide = titleAndObjectLayoutSlide;

          break;

       }

      }

      if (layoutSlide == null)

      {

         foreach (ILayoutSlide titleLayoutSlide in layoutSlides)

         {

            if (titleLayoutSlide.Name == "Title")

            {

                layoutSlide = titleLayoutSlide;

                break;

            }

          }

          if (layoutSlide == null)

          {

             layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);

             if (layoutSlide == null)

             {

                  layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");

             }

          }

      }

  }

  //Menambahkan slide kosong dengan slide layout yang ditambahkan

  p.Slides.InsertEmptySlide(0, layoutSlide);

  //Simpan presentasi

  p.Save("Output.pptx", SaveFormat.Pptx);

}


``` 
## **Unduh Contoh yang Berjalan**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **Unduh Kode Contoh**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Untuk detail lebih lanjut, kunjungi [Terapkan atau Ubah Layout Slide di .NET](/slides/id/net/slide-layout/).
{{% /alert %}}