---
title: Ανάκτηση όλων των εξωτερικών υπερσυνδέσεων σε μια παρουσίαση
type: docs
weight: 90
url: /el/net/get-all-the-external-hyperlinks-in-a-presentation/
---
## **Παρουσίαση OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// Επιστρέφει όλες τις εξωτερικές υπερσυνδέσεις στις διαφάνειες μιας παρουσίασης.

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// Δηλώνει μια λίστα συμβολοσειρών.

List<string> ret = new List<string>();

// Ανοίγει το αρχείο παρουσίασης μόνο για ανάγνωση.

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // Διασχίζει όλα τα τμήματα διαφάνειας στο τμήμα παρουσίασης.

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // Διασχίζει όλες τις συνδέσεις στο τμήμα διαφάνειας.

        foreach (Drawing.HyperlinkType link in links)

        {

            // Διασχίζει όλες τις εξωτερικές σχέσεις στο τμήμα διαφάνειας. 

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // Αν το αναγνωριστικό της σχέσης ταιριάζει με το αναγνωριστικό της σύνδεσης...

                if (relation.Id.Equals(link.Id))

                {

                    // Προσθέτει το URI της εξωτερικής σχέσης στη λίστα συμβολοσειρών.

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// Επιστρέφει τη λίστα συμβολοσειρών.

return ret;

}


```
## **Aspose.Slides**
Το Aspose.Slides for .NET επιτρέπει στους προγραμματιστές να διαχειρίζονται τις υπερσυνδέσεις στην παρουσίαση σε επίπεδο παρουσίασης, διαφάνειας και πλαισίου κειμένου. Η κλάση **IHyperlinkQueries** βοηθά στη διαχείριση των υπερσυνδέσεων σε μια παρουσίαση.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

//Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο PPTX

Presentation pres = new Presentation(FileName);

//Ανακτά τις υπερσυνδέσεις από την παρουσίαση

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

```
## **Λήψη Παραδείγματος Εκτελέσιμου Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Παράδειγμα Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)