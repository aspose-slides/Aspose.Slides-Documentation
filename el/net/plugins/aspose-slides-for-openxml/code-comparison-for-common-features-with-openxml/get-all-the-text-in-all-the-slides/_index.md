---
title: Λήψη όλου του κειμένου σε όλες τις διαφάνειες
type: docs
weight: 100
url: /el/net/get-all-the-text-in-all-the-slides/
---
## **OpenXML SDK**
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

    // Ανοίξτε την παρουσίαση μόνο για ανάγνωση.
    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))
    {
        // Μεταβιβάστε την παρουσίαση στην επόμενη μέθοδο CountSlides
        // και επιστρέψτε τον αριθμό των διαφανειών.
        return CountSlides(presentationDocument);
    }
}

// Count the slides in the presentation.
public static int CountSlides(PresentationDocument presentationDocument)

{
    // Ελέγξτε αν το αντικείμενο εγγράφου είναι null.
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
    // Επιστρέψτε τον αριθμό των διαφανειών στην προηγούμενη μέθοδο.
    return slidesCount;
}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{
    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))
    {
        // Αποκτήστε το αναγνωριστικό σχέσης της πρώτης διαφάνειας.
        PresentationPart part = ppt.PresentationPart;
        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;
        string relId = (slideIds[index] as SlideId).RelationshipId;
        // Αποκτήστε το τμήμα διαφάνειας από το αναγνωριστικό σχέσης.
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
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Number of slides = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

slideText = GetSlideText(FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    //Δημιουργία αντικειμένου PresentationEx που αντιπροσωπεύει PPTX
    using (Presentation pres = new Presentation(presentationFile))
    {
        return pres.Slides.Count;
    }
}

public static string GetSlideText(string docName, int index)

{
    string sldText = "";
    //Δημιουργία αντικειμένου PresentationEx που αντιπροσωπεύει PPTX
    using (Presentation pres = new Presentation(docName))
    {
        //Πρόσβαση στη διαφάνεια
        ISlide sld = pres.Slides[index];
        //Διέλευση όλων των σχημάτων για να βρεθεί το placeholder
        foreach (Shape shp in sld.Shapes)
            if (shp.Placeholder != null)
            {
                //Λήψη του κειμένου κάθε placeholder
                sldText += ((AutoShape)shp).TextFrame.Text;
            }
    }
    return sldText;
}
``` 
## **Λήψη παραδειγματικού κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides/)