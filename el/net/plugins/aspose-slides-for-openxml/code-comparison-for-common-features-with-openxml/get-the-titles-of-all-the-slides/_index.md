---
title: Αποκτήστε τους τίτλους όλων των διαφανειών
type: docs
weight: 120
url: /el/net/get-the-titles-of-all-the-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get the titles of all the slides.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// Λάβετε μια λίστα με τους τίτλους όλων των διαφανειών στην παρουσίαση.

public static IList<string> GetSlideTitles(string presentationFile)

{

    // Ανοίξτε την παρουσίαση σε κατάσταση μόνο‑ανάγνωση.

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// Λάβετε μια λίστα με τους τίτλους όλων των διαφανειών στην παρουσίαση.

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Αποκτήστε ένα αντικείμενο PresentationPart από το αντικείμενο PresentationDocument.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // Αποκτήστε ένα αντικείμενο Presentation από το αντικείμενο PresentationPart.

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // Αποκτήστε τον τίτλο κάθε διαφάνειας με τη σειρά των διαφανειών.

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // Αποκτήστε τον τίτλο της διαφάνειας.

                string title = GetSlideTitle(slidePart);

                // Μπορεί επίσης να προστεθεί κενός τίτλος.

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// Αποκτήστε τη συμβολοσειρά του τίτλου της διαφάνειας.

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Δήλωση ενός διαχωριστικού παραγράφου.

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // Βρείτε όλα τα σχήματα τίτλου.

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // Αποκτήστε το κείμενο σε κάθε παράγραφο σε αυτό το σχήμα.

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // Προσθέστε αλλαγή γραμμής.

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

// Καθορίζει αν το σχήμα είναι σχήμα τίτλου.

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // Οποιοδήποτε σχήμα τίτλου.

            case PlaceholderValues.Title:

            // Κεντραρισμένος τίτλος.

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

    // Ανοίξτε την παρουσίαση σε κατάσταση μόνο‑ανάγνωση.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Περάστε την παρουσίαση στην επόμενη μέθοδο CountSlides

        // και επιστρέψτε τον αριθμό των διαφανειών.

        return CountSlides(presentationDocument);

    }

}

// Μετρήστε τις διαφάνειες στην παρουσίαση.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Ελέγξτε αν το αντικείμενο εγγράφου είναι μηδενικό.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Αποκτήστε το τμήμα παρουσίασης του εγγράφου.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Αποκτήστε τον αριθμό των διαφανειών από τα SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Επιστρέψτε τον αριθμό των διαφανειών στη προηγούμενη μέθοδο.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Αποκτήστε το ID σχέσης της πρώτης διαφάνειας.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Αποκτήστε το τμήμα της διαφάνειας από το ID σχέσης.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Δημιουργήστε ένα αντικείμενο StringBuilder.

        StringBuilder paragraphText = new StringBuilder();

        // Αποκτήστε το εσωτερικό κείμενο της διαφάνειας:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **Λήψη Δείγματος Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides/)