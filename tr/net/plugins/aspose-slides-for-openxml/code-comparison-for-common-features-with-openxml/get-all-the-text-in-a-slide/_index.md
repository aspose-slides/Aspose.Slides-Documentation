---
title: Bir slayttaki tüm metni al
type: docs
weight: 110
url: /tr/net/get-all-the-text-in-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Bir slayttaki tüm metni al.

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // Sunumu yalnızca okuma izniyle aç.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Sunumu ve slayt indeksini aktar

        // sonraki GetAllTextInSlide metoduna, ve

        // daha sonra döndürdüğü dize dizisini geri döndür.

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // Sunum belgesinin varlığını doğrula.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Slayt indeksinin aralık dışında olmadığını doğrula.

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Sunum belgesinin sunum bölümünü al.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Sunum bölümünün ve sunumun varlığını doğrula.

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // Sunum bölümünden Presentation nesnesini al.

        Presentation presentation = presentationPart.Presentation;

        // Slayt ID listesinin varlığını doğrula.

        if (presentation.SlideIdList != null)

        {

            // Slayt ID listesinden slayt ID koleksiyonunu al.

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // Eğer slayt ID'si aralık içindeyse...

            if (slideIndex < slideIds.Count)

            {

                // Slaytın ilişki ID'sini al.

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // Belirtilen slayt bölümünü ilişki ID'sinden al.

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // Slayt bölümünü bir sonraki metoda aktar, ve

                // daha sonra o metodun döndürdüğü dize dizisini

                // önceki metoda geri döndür.

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // Aksi takdirde, null dön.

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // Slayt bölümünün varlığını doğrula.

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // Yeni bir dize bağlı listesi oluştur.

    LinkedList<string> texts = new LinkedList<string>();

    // Eğer slayt mevcutsa...

    if (slidePart.Slide != null)

    {

        // Slayttaki tüm paragraflar arasında gezin.

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // Yeni bir StringBuilder oluştur.                    

            StringBuilder paragraphText = new StringBuilder();

            // Paragraf satırları arasında döngü yap.

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // Her satırı önceki satırlara ekle.

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // Her paragrafı bağlı listeye ekle.

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // Bir dize dizisi döndür.

        return texts.ToArray();

    }

    else

    {

        return null;

    }

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Bir slayttaki tüm metni al.

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// Yeni bir dize listesi oluştur.

List<string> texts = new List<string>();

//Instantiate PresentationEx class that represents PPTX
//PPTX'i temsil eden PresentationEx sınıfını örnekle

using (Presentation pres = new Presentation(presentationFile))

{

    // Access the slide
    // Slayta eriş

    ISlide sld = pres.Slides[slideIndex];

    // Iterate through shapes to find the placeholder
    // Yer tutucuyu bulmak için şekiller arasında döngü yap

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            // get the text of each placeholder
            // her yer tutucunun metnini al

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// Return an array of strings.

return texts;

}
``` 
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide/)