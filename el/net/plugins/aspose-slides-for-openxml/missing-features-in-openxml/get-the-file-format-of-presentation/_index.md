---
title: Λήψη μορφής αρχείου παρουσίασης
type: docs
weight: 50
url: /el/net/get-the-file-format-of-presentation/
aliases:
  - /net/presentation-format/
---
Για να λάβετε τη μορφή του αρχείου, παρακαλώ ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα στιγμιότυπο της κλάσης **IPresentationInfo**
- Λάβετε πληροφορίες για την παρουσίαση

Στο παρακάτω παράδειγμα, έχουμε τη μορφή του αρχείου.
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
## **Λήψη Δείγματος Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Λήψη Εκτελεστικού Παραδείγματος**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)