---
title: Εκτύπωση Παρουσίασης
type: docs
url: /el/net/print-the-presentation/
---
Το Aspose.Slides for .NET παρέχει τέσσερις υπερφορτωμένες μεθόδους για εκτύπωση των παρουσιάσεων. Αυτές οι μέθοδοι είναι αρκετά ευέλικτες ώστε να εκτυπώνουν την παρουσίαση στον προεπιλεγμένο εκτυπωτή ή σε οποιονδήποτε διαθέσιμο εκτυπωτή με προσαρμοσμένες ρυθμίσεις. Απλώς χρειάζεται να επιλέξετε τη σωστή μέθοδο εκτύπωσης ανάλογα με τις απαιτήσεις.
## **Print to the Default Printer**
Η εκτύπωση της παρουσίασης στον προεπιλεγμένο εκτυπωτή είναι αρκετά απλή στο Aspose.Slides for .NET. Εκτελέστε τα παρακάτω βήματα για να εκτυπώσετε την παρουσίαση στον προεπιλεγμένο εκτυπωτή:

- Δημιουργήστε μια παρουσία της κλάσης Presentation για να φορτώσετε μια παρουσίαση που πρόκειται να εκτυπωθεί
- Καλέστε τη μέθοδο Print χωρίς παραμέτρους, όπως παρέχεται από το αντικείμενο Presentation

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Φορτώνει την παρουσίαση

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Καλεί τη μέθοδο εκτύπωσης για να εκτυπώσει ολόκληρη την παρουσίαση στον προεπιλεγμένο εκτυπωτή

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Φορτώνει την παρουσίαση

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Καλεί τη μέθοδο εκτύπωσης για να εκτυπώσει ολόκληρη την παρουσίαση στον επιθυμητό εκτυπωτή

    asposePresentation.Print("LaserJet1100");


``` 
## **Print to a Specific Printer**
Η εκτύπωση της παρουσίασης σε συγκεκριμένο εκτυπωτή απαιτεί το όνομα του εκτυπωτή ως παράμετρο στη μέθοδο Print του Presentation. Εκτελέστε τα παρακάτω βήματα για να εκτυπώσετε την παρουσίαση στον επιθυμητό εκτυπωτή:

- Δημιουργήστε μια παρουσία της κλάσης Presentation για να φορτώσετε μια παρουσίαση που πρόκειται να εκτυπωθεί
- Καλέστε τη μέθοδο Print της κλάσης Presentation με το όνομα του εκτυπωτή ως παράμετρο τύπου string

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Φορτώνει την παρουσίαση

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Καλεί τη μέθοδο εκτύπωσης για να εκτυπώσει ολόκληρη την παρουσίαση στον επιθυμητό εκτυπωτή

    asposePresentation.Print("LaserJet1100");

}

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)