---
title: Bir sunumdaki tüm dış köprüleri al
type: docs
weight: 90
url: /tr/net/get-all-the-external-hyperlinks-in-a-presentation/
---
## **OpenXML Sunumu**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// Bir sunumun slaytlarındaki tüm dış köprüleri döndürür.

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// Bir dize listesi bildir.

List<string> ret = new List<string>();

// Sunum dosyasını salt okunur olarak aç.

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // Sunum parçasındaki tüm slayt bölümlerini dolaş.

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // Slayt bölümündeki tüm bağlantıları dolaş.

        foreach (Drawing.HyperlinkType link in links)

        {

            // Slayt bölümündeki tüm dış ilişkileri dolaş. 

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // Eğer ilişki kimliği bağlantı kimliğiyle eşleşiyorsa...

                if (relation.Id.Equals(link.Id))

                {

                    // Dış ilişkinin URI'sini dize listesine ekle.

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// Dize listesini döndür.

return ret;

}
``` 
## **Aspose.Slides**
Aspose.Slides for .NET, geliştiricilerin sunumda, slayt ve metin çerçevesi seviyesinde köprüleri yönetmesine olanak tanır. **IHyperlinkQueries** sınıfı, bir sunumdaki köprüleri yönetmeye yardımcı olur.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

//Bir PPTX dosyasını temsil eden Presentation nesnesi oluştur
Presentation pres = new Presentation(FileName);

//Sunumdan köprüleri al
IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

``` 
## **Çalışan Kod Örneğini İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Örnek Kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)