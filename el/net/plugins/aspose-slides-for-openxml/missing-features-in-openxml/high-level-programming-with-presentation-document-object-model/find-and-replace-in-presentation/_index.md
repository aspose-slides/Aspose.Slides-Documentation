---
title: Εύρεση και Αντικατάσταση σε Παρουσίαση
type: docs
weight: 20
url: /el/net/find-and-replace-in-presentation/
---
Ακολουθούν τα βήματα που πρέπει να ακολουθήσετε:

1. Ανοίξτε μια παρουσίαση.
1. Αναζητήστε το κείμενο.
1. Αντικαταστήστε το κείμενο.
1. Γράψτε την παρουσίαση.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//Ανοίξτε την παρουσίαση

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//Λάβετε όλα τα πλαίσια κειμένου στην παρουσίαση

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //Βρείτε το κείμενο προς αντικατάσταση

        if (port.Text.Contains(strToFind))

        //Αντικαταστήστε το υπάρχον κείμενο με το νέο κείμενο

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);


``` 
## **Κατεβάστε δείγμα κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)