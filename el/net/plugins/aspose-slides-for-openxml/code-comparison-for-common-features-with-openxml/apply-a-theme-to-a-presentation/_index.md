---
title: Εφαρμογή θέματος σε παρουσίαση
type: docs
weight: 30
url: /el/net/apply-a-theme-to-a-presentation/
---
## **Παρουσίαση OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// Εφαρμογή νέου θέματος στην παρουσίαση. 

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// Εφαρμογή νέου θέματος στην παρουσίαση. 

public static void ApplyThemeToPresentation(PresentationDocument presentationDocument, PresentationDocument themeDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (themeDocument == null)

    {

        throw new ArgumentNullException("themeDocument");

    }

    // Λήψη του τμήματος παρουσίασης του εγγράφου παρουσίασης.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Λήψη του υπάρχοντος τμήματος master διαφάνειας.

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // Λήψη του νέου τμήματος master διαφάνειας.

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // Αφαίρεση του υπάρχοντος τμήματος θέματος.

    presentationPart.DeletePart(presentationPart.ThemePart);

    // Αφαίρεση του παλιού τμήματος master διαφάνειας.

    presentationPart.DeletePart(slideMasterPart);

    // Εισαγωγή του νέου τμήματος master διαφάνειας και επαναχρήση του παλιού αναγνωριστικού σχέσης.

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // Αλλαγή στο νέο τμήμα θέματος.

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // Εισαγωγή κώδικα για τη διάταξη σε αυτό το παράδειγμα.

    string defaultLayoutType = "Title and Content";

    // Αφαίρεση της σχέσης διάταξης διαφάνειας σε όλες τις διαφάνειες. 

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // Προσδιορισμός του τύπου διάταξης διαφάνειας για κάθε διαφάνεια.

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // Διαγραφή του παλιού τμήματος διάταξης.

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // Εφαρμογή του νέου τμήματος διάταξης.

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // Εφαρμογή του νέου προεπιλεγμένου τμήματος διάταξης.

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// Λήψη του τύπου διάταξης διαφάνειας.

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // Σχόλια: Εάν αυτό χρησιμοποιείται σε κώδικα παραγωγής, ελέγξτε για αναφορά null.

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
Για να εφαρμόσουμε θέμα, πρέπει να κλωνοποιήσουμε τη διαφάνεια μαζί με το master, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια περίπτωση της κλάσης Presentation που περιέχει την πηγή παρουσίασης από την οποία θα κλωνοποιηθεί η διαφάνεια.
- Δημιουργήστε μια περίπτωση της κλάσης Presentation που περιέχει την προορισμιακή παρουσίαση στην οποία θα κλωνοποιηθεί η διαφάνεια.
- Προσπελάστε τη διαφάνεια που θα κλωνοποιηθεί μαζί με τη διαφάνεια master.
- Δημιουργήστε ένα αντικείμενο της κλάσης IMasterSlideCollection κάνοντας αναφορά στη συλλογή Masters που εκτίθεται από το αντικείμενο Presentation της προορισμιακής παρουσίασης.
- Κληθείτε τη μέθοδο AddClone που εκτίθεται από το αντικείμενο IMasterSlideCollection και περάστε το master από το πηγαίο PPTX που θα κλωνοποιηθεί ως παράμετρο στην μέθοδο AddClone.
- Δημιουργήστε ένα αντικείμενο της κλάσης ISlideCollection ορίζοντας την αναφορά στη συλλογή Slides που εκτίθεται από το αντικείμενο Presentation της προορισμιακής παρουσίασης.
- Κληθείτε τη μέθοδο AddClone που εκτίθεται από το αντικείμενο ISlideCollection και περάστε τη διαφάνεια από την πηγαία παρουσίαση που θα κλωνοποιηθεί καθώς και τη διαφάνεια master ως παραμέτρους στην μέθοδο AddClone.
- Γράψτε το τροποποιημένο αρχείο προορισμιακής παρουσίασης.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //Δημιουργία αντικειμένου Presentation για φόρτωση του αρχείου πηγαίας παρουσίασης
    Presentation srcPres = new Presentation(presentationFile);
    //Δημιουργία αντικειμένου Presentation για την προορισμιακή παρουσίαση (όπου θα κλωνοποιηθεί η διαφάνεια)
    Presentation destPres = new Presentation(outputFile);
    //Δημιουργία ISlide από τη συλλογή διαφάνειων στην πηγαία παρουσίαση μαζί με
    //master διαφάνεια
    ISlide SourceSlide = srcPres.Slides[0];
    //Κλωνοποίηση του επιθυμητού master slide από την πηγαία παρουσίαση στη συλλογή των master στη
    //προορισμιακή παρουσίαση
    IMasterSlideCollection masters = destPres.Masters;
    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;
    //Κλωνοποίηση του επιθυμητού master slide από την πηγαία παρουσίαση στη συλλογή των master στη
    //προορισμιακή παρουσίαση
    IMasterSlide iSlide = masters.AddClone(SourceMaster);
    //Κλωνοποίηση της επιθυμητής διαφάνειας από την πηγαία παρουσίαση με το επιθυμητό master στο τέλος της
    //συλλογής διαφάνειων στην προορισμιακή παρουσίαση
    ISlideCollection slds = destPres.Slides;
    slds.AddClone(SourceSlide, iSlide, true);
    //Κλωνοποίηση του επιθυμητού master slide από την πηγαία παρουσίαση στη συλλογή των master στη//προορισμιακή παρουσίαση
    //Αποθήκευση της προορισμιακής παρουσίασης στο δίσκο
    destPres.Save(outputFile, SaveFormat.Pptx);

}
``` 
## **Λήψη Παραδείγματος Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Δείγμα Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)