---
title: Menambahkan Layout Slides ke Presentasi
type: docs
weight: 20
url: /id/net/add-layout-slides-to-presentation/
---
Aspose.Slides for .NET memungkinkan pengembang menambahkan Layout slide baru dalam presentasi. Untuk menambahkan Layout Slide, ikuti langkah-langkah di bawah ini:

- Buat instance kelas Presentation
- Akses koleksi Master Slide
- Coba temukan Layout slide yang ada untuk melihat apakah yang dibutuhkan sudah tersedia di koleksi Layout Slide atau tidak
- Tambahkan Layout slide baru jika tata letak yang diinginkan tidak tersedia
- Tambahkan slide kosong dengan Layout slide yang baru ditambahkan
- Terakhir, tulis file presentasi menggunakan objek Presentation
## **Contoh**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//Menginstansiasi kelas Presentation yang mewakili file presentasi

using (Presentation p = new Presentation(FileName))

{
    // Mencoba mencari berdasarkan jenis layout slide

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        // Situasi ketika sebuah presentasi tidak berisi beberapa jenis layout.

        // Presentasi Technographics.pptx hanya berisi jenis layout Blank dan Custom.

        // Namun layout slide dengan tipe Custom memiliki nama slide yang berbeda,

        // seperti "Title", "Title and Content", dll. Dan dapat menggunakan ini

        // nama untuk pemilihan layout slide.

        // Juga memungkinkan menggunakan sekumpulan tipe shape placeholder. Sebagai contoh,

        // Slide judul harus hanya memiliki tipe placeholder Title, dll.

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

    //Menambahkan slide kosong dengan layout slide yang telah ditambahkan 

    p.Slides.InsertEmptySlide(0, layoutSlide);

    //Menyimpan presentasi    

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Unduh Contoh yang Dijalankan**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 
Untuk detail lebih lanjut, kunjungi [Terapkan atau Ubah Tata Letak Slide di .NET](/slides/id/net/slide-layout/).
{{% /alert %}}