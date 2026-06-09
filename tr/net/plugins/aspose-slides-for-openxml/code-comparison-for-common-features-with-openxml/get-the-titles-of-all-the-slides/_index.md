---
title: Tüm slaytların başlıklarını alın
type: docs
weight: 120
url: /tr/net/get-the-titles-of-all-the-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get the titles of all the slides.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// Sunumdaki tüm slaytların başlıklarının listesini al.

public static IList<string> GetSlideTitles(string presentationFile)

{

    // Sunumu yalnızca okunur olarak aç.

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// Sunumdaki tüm slaytların başlıklarının listesini al.

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // PresentationDocument nesnesinden bir PresentationPart nesnesi al.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // PresentationPart nesnesinden bir Presentation nesnesi al.

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // Slayt sırasındaki her slaytın başlığını al.

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // Slayt başlığını al.

                string title = GetSlideTitle(slidePart);

                // Boş bir başlık da eklenebilir.

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// Slaytın başlık dizesini al.

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Bir paragraf ayırıcı bildir.

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // Tüm başlık şekillerini bul.

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // Bu şeklin her paragrafındaki metni al.

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // Satır sonu ekle.

                paragraphText.Append(paragraphSeparator);

                foreach (var text in paragraph.Descendants<D.Text>())

                {

                    paragraphText.Append(text.Text);

                }

                paragraphSeparator = "\n";

            }

        }

        return paragraphText.ToString();

    }

    return string.Empty;

}

// Şeklin başlık şekli olup olmadığını belirler.

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // Herhangi bir başlık şekli.

            case PlaceholderValues.Title:

            // Ortalanmış bir başlık.

            case PlaceholderValues.CenteredTitle:

                return true;

            default:

                return false;

        }

    }

    return false;

}
``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Number of slides = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // Sunumu yalnızca okunur olarak aç.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Sunumu sonraki CountSlides yöntemine geçir
        // ve slayt sayısını döndür.

        return CountSlides(presentationDocument);

    }

}

// Sunumdaki slaytları say.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Null belge nesnesi olup olmadığını kontrol et.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Belgenin sunum bölümünü al.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // SlideParts üzerinden slayt sayısını al.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Slayt sayısını önceki metoda döndür.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // İlk slaydın ilişki kimliğini al.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // İlişki kimliğinden slayt kısmını al.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Bir StringBuilder nesnesi oluştur.

        StringBuilder paragraphText = new StringBuilder();

        // Slaydın iç metnini al:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}
``` 
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides/)