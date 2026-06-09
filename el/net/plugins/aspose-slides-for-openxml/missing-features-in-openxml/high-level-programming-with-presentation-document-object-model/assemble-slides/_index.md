---
title: Συναρμολόγηση Διαφανειών
type: docs
weight: 10
url: /el/net/assemble-slides/
---
## **Προσθήκη διαφάνειας σε παρουσίαση**
Πριν μιλήσουμε για την προσθήκη διαφανειών στα αρχεία παρουσίασης, ας συζητήσουμε μερικά γεγονότα σχετικά με τις διαφάνειες. Κάθε αρχείο παρουσίασης PowerPoint περιέχει διαφάνεια Master / Layout και άλλες κανονικές διαφάνειες. Αυτό σημαίνει ότι ένα αρχείο παρουσίασης περιέχει τουλάχιστον μία ή περισσότερες διαφάνειες. Είναι σημαντικό να γνωρίζετε ότι αρχεία παρουσίασης χωρίς διαφάνειες δεν υποστηρίζονται από το Aspose.Slides for .NET. Κάθε διαφάνεια έχει μοναδικό Id και όλες οι κανονικές διαφάνειες είναι διατεταγμένες με τη σειρά που καθορίζεται από το μηδενικό ευρετήριο.

Το Aspose.Slides for .NET επιτρέπει στους προγραμματιστές να προσθέτουν κενές διαφάνειες στην παρουσίασή τους. Για να προσθέσετε μια κενή διαφάνεια στην παρουσίαση, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης **Presentation**
- Δημιουργήστε μια παρουσία της κλάσης **SlideCollection** θέτοντας μια αναφορά στην ιδιότητα Slides (συλλογή αντικειμένων Slide περιεχομένου) που εκτίθεται από το αντικείμενο Presentation
- Προσθέστε μια κενή διαφάνεια στην παρουσίαση στο τέλος της συλλογής διαφανειών περιεχομένου καλώντας τις μεθόδους **AddEmptySlide** που εκτίθενται από το αντικείμενο **SlideCollection**
- Εκτελέστε κάποια ενέργεια με τη νεοσυγγενή κενή διαφάνεια
- Τέλος, γράψτε το αρχείο παρουσίασης χρησιμοποιώντας το αντικείμενο **Presentation**

``` csharp

 PresentationEx pres = new PresentationEx;

//Δημιουργία αντικειμένου κλάσης SlideCollection

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Προσθήκη κενής διαφάνειας στη συλλογή Slides

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Αποθήκευση του αρχείου PPTX στον δίσκο

pres.Write("EmptySlide.pptx");

``` 
## **Πρόσβαση σε διαφάνειες παρουσίασης**
Το Aspose.Slides for .NET παρέχει την κλάση Presentation που μπορεί να χρησιμοποιηθεί για την εύρεση και πρόσβαση σε οποιαδήποτε επιθυμητή διαφάνεια που βρίσκεται στην παρουσίαση.

**Χρήση Συλλογής Διαφανειών**

**Presentation** class represents a presentation file and exposes all slides in it as a **SlideCollection** collection (that is a collection of **Slide** objects). All of these slides can be accessed from this **Slides** collection using a slide index.

``` csharp

 //Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");
//Πρόσβαση σε διαφάνεια χρησιμοποιώντας το δείκτη της
SlideEx slide = pres.Slides[0];

``` 
## **Αφαίρεση διαφανειών**
Γνωρίζουμε ότι η κλάση Presentation στο **Aspose.Slides for .NET** αντιπροσωπεύει ένα αρχείο παρουσίασης. Η κλάση Presentation περιλαμβάνει μια **SlideCollection** που λειτουργεί ως αποθετήριο όλων των διαφανειών που αποτελούν μέρος της παρουσίασης. Οι προγραμματιστές μπορούν να αφαιρέσουν μια διαφάνεια από αυτή τη συλλογή Slides με δύο τρόπους:

- Χρήση Αναφοράς Διαφάνειας
- Χρήση Δείκτη Διαφάνειας

**Χρήση Αναφοράς Διαφάνειας**

Για να αφαιρέσετε μια διαφάνεια χρησιμοποιώντας την αναφορά της, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης Presentation
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Id ή το Index της
- Αφαιρέστε τη διαφάνεια που αναφέρεται από την παρουσίαση
- Γράψτε το τροποποιημένο αρχείο παρουσίασης

``` csharp

 //Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Πρόσβαση σε διαφάνεια χρησιμοποιώντας το δείκτη της στη συλλογή διαφανειών

SlideEx slide = pres.Slides[0];

//Αφαίρεση διαφάνειας χρησιμοποιώντας την αναφορά της

pres.Slides.Remove(slide);

//Εγγραφή του αρχείου παρουσίασης

pres.Write("modified.pptx");

``` 
## **Αλλαγή θέσης διαφάνειας**
Είναι πολύ απλό να αλλάξετε τη θέση μιας διαφάνειας στην παρουσίαση. Ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης Presentation
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της
- Αλλάξτε το SlideNumber της διαφάνειας που αναφέρεται
- Γράψτε το τροποποιημένο αρχείο παρουσίασης

Στο παρακάτω παράδειγμα, έχουμε αλλάξει τη θέση μιας διαφάνειας (που βρισκόταν στη θέση μηδενικού ευρετηρίου 1) της παρουσίασης σε δείκτη 1 (Θέση 2).

``` csharp

 private static string MyDir = @"..\..\..\Sample Files\";

static void Main(string[] args)

{

AddingSlidetoPresentation();

AccessingSlidesOfPresentation();

RemovingSlides();

ChangingPositionOfSlide();

}

public static void AddingSlidetoPresentation()

{

Presentation pres = new Presentation();

//Δημιουργία κλάσης SlideCollection

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Προσθήκη κενής διαφάνειας στη συλλογή Slides

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Αποθήκευση του αρχείου PPTX στον δίσκο

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Πρόσβαση σε διαφάνεια χρησιμοποιώντας το δείκτη της

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Πρόσβαση σε διαφάνεια χρησιμοποιώντας το δείκτη της στη συλλογή διαφανειών

ISlide slide = pres.Slides[0];

//Αφαίρεση διαφάνειας χρησιμοποιώντας την αναφορά της

pres.Slides.Remove(slide);

//Εγγραφή του αρχείου παρουσίασης

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//Δημιουργία αντικειμένου Presentation για τη φόρτωση του αρχικού αρχείου παρουσίασης

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //Ανάκτηση της διαφάνειας της οποίας η θέση πρέπει να αλλάξει

    ISlide sld = pres.Slides[0];

    //Ορισμός της νέας θέσης για τη διαφάνεια

    sld.SlideNumber = 2;

    //Γραφή της παρουσίασης στον δίσκο

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **Λήψη κώδικα δείγματος**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)