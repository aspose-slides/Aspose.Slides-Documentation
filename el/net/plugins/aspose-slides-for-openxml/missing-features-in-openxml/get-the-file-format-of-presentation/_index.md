---
title: Λάβετε τη μορφή αρχείου της παρουσίασης
type: docs
weight: 50
url: /el/net/get-the-file-format-of-presentation/
---
Για να λάβετε τη μορφή του αρχείου, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης **IPresentationInfo**  
- Λάβετε πληροφορίες σχετικά με την παρουσίαση

Στο παρακάτω παράδειγμα, έχουμε λάβει τη μορφή του αρχείου.
## **Παράδειγμα**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Getting the format of a file.pptx";

IPresentationInfo info;

info = PresentationFactory.Instance.GetPresentationInfo(FileName);


switch (info.LoadFormat)

{

    case LoadFormat.Pptx:

        {

            break;

        }

    case LoadFormat.Unknown:

        {

            break;

        }

}

``` 
## **Κατεβάστε δείγμα κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Κατεβάστε εκτελέσιμο παράδειγμα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)