---
title: Καταμετρήστε τον αριθμό των Διαφανειών
type: docs
weight: 50
url: /el/net/count-the-number-of-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",
CountSlides(FileName));

Console.ReadKey();

// Λάβετε το αντικείμενο παρουσίασης και περάστε το στην επόμενη μέθοδο CountSlides.

public static int CountSlides(string presentationFile)
{
    // Ανοίξτε την παρουσίαση μόνο για ανάγνωση.
    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))
    {
        // Περάστε την παρουσίαση στην επόμενη μέθοδο CountSlide
        // και επιστρέψτε τον αριθμό των διαφανειών.
        return CountSlides(presentationDocument);
    }
}

// Μετρήστε τις διαφάνειες στην παρουσίαση.
public static int CountSlides(PresentationDocument presentationDocument)
{
    // Ελέγξτε για αντικείμενο εγγράφου null.
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
``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",
CountSlides(FileName));

Console.ReadKey();

public static int CountSlides(string presentationFile)

{

  //Δημιουργία ενός αντικειμένου PresentationEx που αντιπροσωπεύει ένα αρχείο PPTX
  using (Presentation pres = new Presentation(presentationFile))
  {
     return pres.Slides.Count;
  }

}  
``` 
## **Λήψη Δειγματικού Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides/)