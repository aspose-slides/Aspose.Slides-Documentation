---
title: Dapatkan semua hyperlink eksternal dalam sebuah presentasi
type: docs
weight: 90
url: /id/net/get-all-the-external-hyperlinks-in-a-presentation/
---
## **Presentasi OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// Mengembalikan semua hyperlink eksternal dalam slide presentasi.

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// Mendeklarasikan daftar string.

List<string> ret = new List<string>();

// Membuka file presentasi dalam mode hanya-baca.

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // Mengiterasi semua bagian slide dalam bagian presentasi.

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // Mengiterasi semua tautan dalam bagian slide.

        foreach (Drawing.HyperlinkType link in links)

        {

            // Mengiterasi semua hubungan eksternal dalam bagian slide. 

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // Jika ID hubungan cocok dengan ID tautan...

                if (relation.Id.Equals(link.Id))

                {

                    // Menambahkan URI hubungan eksternal ke dalam daftar string.

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// Mengembalikan daftar string.

return ret;

}
``` 
## **Aspose.Slides**
Aspose.Slides untuk .NET memungkinkan pengembang mengelola hyperlink dalam presentasi pada tingkat presentasi, slide, dan bingkai teks. Kelas **IHyperlinkQueries** membantu mengelola hyperlink dalam sebuah presentasi.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

//Buat objek Presentation yang mewakili file PPTX

Presentation pres = new Presentation(FileName);

//Dapatkan hyperlink dari presentasi

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

``` 
## **Unduh Contoh Kode Berjalan**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Contoh Kode**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)