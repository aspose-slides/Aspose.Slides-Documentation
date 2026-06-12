---
title: Menerapkan tema ke presentasi
type: docs
weight: 30
url: /id/net/apply-a-theme-to-a-presentation/
---
## **Presentasi OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// Terapkan tema baru ke presentasi. 

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// Terapkan tema baru ke presentasi. 

public static void ApplyThemeToPresentation(PresentationDocument presentationDocument, PresentationDocument themeDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (themeDocument == null)

    {

        throw new ArgumentNullException("themeDocument");

    }

    // Dapatkan bagian presentasi dari dokumen presentasi.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Dapatkan bagian master slide yang ada.

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // Dapatkan bagian master slide baru.

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // Hapus bagian tema yang ada.

    presentationPart.DeletePart(presentationPart.ThemePart);

    // Hapus bagian master slide lama.

    presentationPart.DeletePart(slideMasterPart);

    // Impor bagian master slide baru, dan gunakan kembali ID hubungan lama.

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // Ganti ke bagian tema baru.

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // Sisipkan kode untuk tata letak contoh ini.

    string defaultLayoutType = "Title and Content";

    // Hapus hubungan tata letak slide pada semua slide. 

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // Tentukan tipe tata letak slide untuk setiap slide.

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // Hapus bagian tata letak lama.

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // Terapkan bagian tata letak baru.

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // Terapkan bagian tata letak default baru.

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// Dapatkan tipe tata letak slide.

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // Catatan: Jika ini digunakan dalam kode produksi, periksa referensi null.

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
Untuk menerapkan tema, kita perlu menyalin slide bersama master, silakan ikuti langkah-langkah di bawah ini:

- Buat instance kelas Presentation yang berisi presentasi sumber tempat slide akan disalin.
- Buat instance kelas Presentation yang berisi presentasi tujuan tempat slide akan disalin.
- Akses slide yang akan disalin bersama master slide.
- Instansiasi kelas IMasterSlideCollection dengan merujuk ke koleksi Masters yang disediakan oleh objek Presentation pada presentasi tujuan.
- Panggil metode AddClone yang tersedia pada objek IMasterSlideCollection dan berikan master dari PPTX sumber yang akan disalin sebagai parameter ke metode AddClone.
- Instansiasi kelas ISlideCollection dengan menetapkan referensi ke koleksi Slides yang disediakan oleh objek Presentation pada presentasi tujuan.
- Panggil metode AddClone yang tersedia pada objek ISlideCollection dan berikan slide dari presentasi sumber yang akan disalin serta master slide sebagai parameter ke metode AddClone.
- Tulis berkas presentasi tujuan yang telah dimodifikasi.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //Instansiasi kelas Presentation untuk memuat file presentasi sumber

    Presentation srcPres = new Presentation(presentationFile);

    //Instansiasi kelas Presentation untuk presentasi tujuan (di mana slide akan disalin)

    Presentation destPres = new Presentation(outputFile);

    //Instansiasi ISlide dari koleksi slide dalam presentasi sumber bersama dengan

    //slide master

    ISlide SourceSlide = srcPres.Slides[0];

    //Salin slide master yang diinginkan dari presentasi sumber ke koleksi master di

    //presentasi tujuan

    IMasterSlideCollection masters = destPres.Masters;

    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

    //Salin slide master yang diinginkan dari presentasi sumber ke koleksi master di

    //presentasi tujuan

    IMasterSlide iSlide = masters.AddClone(SourceMaster);

    //Salin slide yang diinginkan dari presentasi sumber dengan master yang diinginkan ke akhir

    //koleksi slide di presentasi tujuan

    ISlideCollection slds = destPres.Slides;

    slds.AddClone(SourceSlide, iSlide, true);

    //Salin slide master yang diinginkan dari presentasi sumber ke koleksi master di //presentasi tujuan

    //Simpan presentasi tujuan ke disk

    destPres.Save(outputFile, SaveFormat.Pptx);

}

``` 
## **Unduh Contoh Kode yang Dijalankan**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Kode Contoh**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)