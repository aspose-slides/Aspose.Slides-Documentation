---
title: Hapus Slide
type: docs
weight: 80
url: /id/net/delete-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

// Dapatkan objek presentasi dan berikan ke metode DeleteSlide berikutnya.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // Buka dokumen sumber sebagai baca/tulis.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Berikan dokumen sumber dan indeks slide yang akan dihapus ke metode DeleteSlide berikutnya.

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// Hapus slide yang ditentukan dari presentasi.

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Gunakan contoh CountSlides untuk mendapatkan jumlah slide dalam presentasi.

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Dapatkan bagian presentasi dari dokumen presentasi. 

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Dapatkan presentasi dari bagian presentasi.

    Presentation presentation = presentationPart.Presentation;

    // Dapatkan daftar ID slide dalam presentasi.

    SlideIdList slideIdList = presentation.SlideIdList;

    // Dapatkan ID slide dari slide yang ditentukan

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // Dapatkan ID hubungan slide.

    string slideRelId = slideId.RelationshipId;

    // Hapus slide dari daftar slide.

    slideIdList.RemoveChild(slideId);

    //

    // Hapus referensi ke slide dari semua tampilan khusus.

    if (presentation.CustomShowList != null)

    {

        // Iterasi melalui daftar tampilan khusus.

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // Deklarasikan linked list dari entri daftar slide.

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // Temukan referensi slide yang akan dihapus dari tampilan khusus.

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // Hapus semua referensi ke slide dari tampilan khusus.

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // Simpan presentasi yang telah dimodifikasi.

    presentation.Save();

    // Dapatkan bagian slide untuk slide yang ditentukan.

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // Hapus bagian slide.

    presentationPart.DeletePart(slidePart);

}

// Dapatkan objek presentasi dan berikan ke metode CountSlides berikutnya.

public static int CountSlides(string presentationFile)

{

    // Buka presentasi sebagai baca-saja.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Berikan presentasi ke metode CountSlide berikutnya

        // dan kembalikan jumlah slide.

        return CountSlides(presentationDocument);

    }

}

// Hitung slide dalam presentasi.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Periksa apakah objek dokumen null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Dapatkan bagian presentasi dari dokumen.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Dapatkan jumlah slide dari SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Kembalikan jumlah slide ke metode sebelumnya.

    return slidesCount;

}   

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    //Instansiasi objek PresentationEx yang mewakili file PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Mengakses slide menggunakan indeksnya dalam koleksi slide

        ISlide slide = pres.Slides[slideIndex];


        //Menghapus slide menggunakan referensinya

        pres.Slides.Remove(slide);


        //Menulis presentasi sebagai file PPTX

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **Unduh Kode Contoh**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide/)