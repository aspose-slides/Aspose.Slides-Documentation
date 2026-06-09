---
title: Slaytı Sil
type: docs
weight: 80
url: /tr/net/delete-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

// Sunum nesnesini al ve bir sonraki DeleteSlide metoduna geçir.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // Kaynak belgeyi okuma/yazma olarak aç.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Kaynak belgeyi ve silinecek slaytın indeksini bir sonraki DeleteSlide metoduna geçir.

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// Belirtilen slaytı sunumdan sil.

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Sunumdaki slayt sayısını almak için CountSlides örneğini kullan.

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Sunum belgesinden sunum kısmını al. 

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Sunum kısmından sunumu al.

    Presentation presentation = presentationPart.Presentation;

    // Sunumdaki slayt kimlikleri listesini al.

    SlideIdList slideIdList = presentation.SlideIdList;

    // Belirtilen slaytın kimliğini al

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // Slaytın ilişki kimliğini al.

    string slideRelId = slideId.RelationshipId;

    // Slaytı slayt listesinden kaldır.

    slideIdList.RemoveChild(slideId);

    //

    // Slayta olan referansları tüm özel gösterilerden kaldır.

    if (presentation.CustomShowList != null)

    {

        // Özel gösteriler listesini yinele.

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // Slayt listesi girişlerinin bir bağlantı listesini bildir.

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // Özel gösteriden kaldırılacak slayt referansını bul.

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // Özel gösteriden slayta olan tüm referansları kaldır.

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // Değiştirilmiş sunumu kaydet.

    presentation.Save();

    // Belirtilen slayt için slayt kısmını al.

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // Slayt kısmını kaldır.

    presentationPart.DeletePart(slidePart);

}

// Sunum nesnesini al ve bir sonraki CountSlides metoduna geçir.

public static int CountSlides(string presentationFile)

{

    // Sunumu yalnızca okunur olarak aç.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Sunumu bir sonraki CountSlide metoduna geçir

        // ve slayt sayısını döndür.

        return CountSlides(presentationDocument);

    }

}

// Sunumdaki slaytları say.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Null bir belge nesnesi olup olmadığını kontrol et.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Belgenin sunum kısmını al.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // SlideParts'tan slayt sayısını al.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Slayt sayısını önceki metoda döndür.

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

    // PPTX dosyasını temsil eden bir PresentationEx nesnesi oluştur

    using (Presentation pres = new Presentation(presentationFile))

    {

        // Slayt koleksiyonundaki indeksini kullanarak bir slayta eriş

        ISlide slide = pres.Slides[slideIndex];


        // Slaytı referansını kullanarak kaldır

        pres.Slides.Remove(slide);


        // Sunumu PPTX dosyası olarak kaydet

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide/)