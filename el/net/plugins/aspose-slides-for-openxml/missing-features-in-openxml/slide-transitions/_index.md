---
title: Μεταβάσεις Διαφανειών
type: docs
weight: 80
url: /el/net/slide-transitions/
---
Για να γίνει πιο εύκολη η κατανόηση, παρουσιάζουμε τη χρήση του Aspose.Slides for .NET για τη διαχείριση απλών μεταβάσεων διαφανειών. Οι προγραμματιστές μπορούν όχι μόνο να εφαρμόσουν διαφορετικά εφέ μετάβασης στις διαφάνειες, αλλά και να προσαρμόσουν τη συμπεριφορά αυτών των εφέ μετάβασης. Για να δημιουργήσετε ένα απλό εφέ μετάβασης διαφάνειας, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης Presentation
- Εφαρμόστε έναν τύπο Slide Transition στο slide από ένα από τα εφέ μετάβασης που προσφέρει το Aspose.Slides for .NET μέσω της **TransitionType** enum
- Γράψτε το τροποποιημένο αρχείο παρουσίασης.
## **Παράδειγμα**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης

using (Presentation pres = new Presentation(FileName))

{

    //Εφαρμόστε μετάβαση τύπου κύκλου στη διαφάνεια 1

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //Εφαρμόστε μετάβαση τύπου χτένι στη διαφάνεια 2

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //Εφαρμόστε μετάβαση τύπου ζουμ στη διαφάνεια 3

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //Αποθηκεύστε την παρουσίαση στο δίσκο

    pres.Save(FileName, SaveFormat.Pptx);

}
``` 
## **Λήψη Δειγματικού Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Λήψη Εκτελούμενου Παραδείγματος**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 
Για περισσότερες λεπτομέρειες, επισκεφθείτε [Διαχείριση Μεταβάσεων Διαφανειών](/slides/el/net/slide-transition/).
{{% /alert %}}