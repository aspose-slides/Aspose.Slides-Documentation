---
title: Δημοσίου API και Αλλαγές που δεν είναι συμβατές προς τα πίσω στο Aspose.Slides για .NET 14.4.0
linktitle: Aspose.Slides για .NET 14.4.0
type: docs
weight: 60
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- μεταφορά
- παλαιός κώδικας
- σύγχρονος κώδικας
- παλαιά προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των βελτιώσεων του δημόσιου API και των διατρητικών αλλαγών στο Aspose.Slides για .NET, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
## **Δημόσιο API και Αλλαγές που δεν είναι συμβατές προς τα πίσω**
### **Προστιθέμενα Διεπαφές, Κλάσεις, Μέθοδοι και Ιδιότητες**
#### **Προστέθηκε η Ιδιότητα Aspose.Slides.ILayoutSlide.HasDependingSlides**
Η ιδιότητα Aspose.Slides.ILayoutSlide.HasDependingSlides επιστρέφει true εάν υπάρχει τουλάχιστον μία διαφάνεια που εξαρτάται από αυτή τη διαφάνεια διάταξης. Για παράδειγμα:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Μέθοδος Aspose.Slides.ILayoutSlide.Remove()**
Η μέθοδος Aspose.Slides.ILayoutSlide.Remove() σάς επιτρέπει να αφαιρέσετε μια διάταξη από μια παρουσίαση με ελάχιστο κώδικα. Για παράδειγμα:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Μέθοδος Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
Η μέθοδος Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) σάς επιτρέπει να αφαιρέσετε μια διάταξη από τη συλλογή. Παραδείγματα κώδικα:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

ή

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
Η μέθοδος Aspose.Slides.ILayoutSlideCollection.RemoveUnused() σάς επιτρέπει να αφαιρέσετε αχρησιμοποίητες διαφάνειες διάταξης (διαφάνειες διάταξης των οποίων η HasDependingSlides είναι false). Παραδείγματα κώδικα:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

ή

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Ιδιότητα Aspose.Slides.IMasterSlide.HasDependingSlides**
Η ιδιότητα Aspose.Slides.IMasterSlide.HasDependingSlides επιστρέφει true εάν υπάρχει τουλάχιστον μία διαφάνεια που εξαρτάται από αυτή τη διαφάνεια κύριου. Για παράδειγμα:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Μέθοδος Aspose.Slides.ISlide.Remove()**
Η μέθοδος Aspose.Slides.ISlide.Remove() σάς επιτρέπει να αφαιρέσετε μια διαφάνεια από μια παρουσίαση με ελάχιστο κώδικα. Για παράδειγμα:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
Η ιδιότητα Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat επιστρέφει IFillFormat για το κουκίδα ενός κόμβου SmartArt εάν η διάταξη παρέχει κουκίδες. Μπορεί να χρησιμοποιηθεί για να ορίσετε την εικόνα της κουκίδας.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Ιδιότητα Aspose.Slides.SmartArt.ISmartArtNode.Level**
Η ιδιότητα Aspose.Slides.SmartArt.ISmartArtNode.Level επιστρέφει το επίπεδο ένθεσης για κόμβους SmartArt.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Ιδιότητα Aspose.Slides.SmartArt.ISmartArtNode.Position**
Η ιδιότητα Aspose.Slides.SmartArt.ISmartArtNode.Position επιστρέφει τη θέση ενός κόμβου μεταξύ των αδελφών του.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Προστέθηκε η Μέθοδος Aspose.Slides.SmartArt.ISmartArtNode.Remove()**
Η μέθοδος Aspose.Slides.SmartArt.ISmartArtNode.Remove() επιτρέπει την αφαίρεση ενός κόμβου από ένα διάγραμμα.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **Διεπαφή IGlobalLayoutSlideCollection και Κλάση GlobalLayoutSlideCollection**
Η διεπαφή IGlobalLayoutSlideCollection και η κλάση GlobalLayoutSlideCollection προστέθηκαν στο χώρο ονομάτων Aspose.Slides.

Η κλάση GlobalLayoutSlideCollection υλοποιεί τη διεπαφή IGlobalLayoutSlideCollection.

Η διεπαφή IGlobalLayoutSlideCollection αντιπροσωπεύει μια συλλογή όλων των διαφανειών διάταξης σε μια παρουσίαση. Η ιδιότητα IPresentation.LayoutSlides είναι τύπου IGlobalLayoutSlideCollection. Η IGlobalLayoutSlideCollection επεκτείνει τη διεπαφή ILayoutSlideCollection με μεθόδους για προσθήκη και κλωνοποίηση διαφανειών διάταξης στο πλαίσιο ενοποίησης των μεμονωμένων συλλογών των διαφανειών διάταξης των δασκάλων:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Μπορεί να χρησιμοποιηθεί για να προσθέσει ένα αντίγραφο μιας συγκεκριμένης διαφάνειας διάταξης στην παρουσίαση. Αυτή η μέθοδος διατηρεί τη μορφοποίηση της πηγής (όταν κλωνοποιείται μια διάταξη μεταξύ διαφορετικών παρουσιάσεων, μπορεί να κλωνοποιηθεί επίσης και ο δάσκαλος της διάταξης. Το εσωτερικό μητρώο χρησιμοποιείται για την παρακολούθηση των αυτόματα κλωνοποιημένων δασκάλων ώστε να αποτραπεί η δημιουργία πολλαπλών κλώνων του ίδιου δάσκαλου διαφάνειας).

- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Χρησιμοποιείται για να προσθέσει ένα αντίγραφο μιας συγκεκριμένης διαφάνειας διάταξης σε μια παρουσίαση. Η νέα διάταξη θα συνδεθεί με τον ορισμένο δάσκαλο στην παρουσίαση προορισμού. Αυτή η επιλογή είναι ανάλογη με την αντιγραφή ή επικόλληση με την επιλογή **Use Destination Theme** στο Microsoft PowerPoint.

- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Χρησιμοποιείται για να προσθέσει μια νέα διαφάνεια διάταξης σε μια παρουσίαση. Είδη διατάξεων που υποστηρίζονται: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Το όνομα διάταξης μπορεί να παραχθεί αυτόματα. Μια προστιθέμενη διάταξη του τύπου SlideLayoutType.Custom δεν περιέχει σύμβολα κράτησης θέσης και δεν περιέχει σχήματα. Αντίστοιχο της μεθόδου είναι η μέθοδος IMasterLayoutSlideCollection.Add(SlideLayoutType, string) που προσπελάζεται μέσω της ιδιότητας IMasterSlide.LayoutSlides.

#### **Διεπαφή IMasterLayoutSlideCollection και Κλάση MasterLayoutSlideCollection**
Η διεπαφή IMasterLayoutSlideCollection και η κλάση MasterLayoutSlideCollection προστέθηκαν στο χώρο ονομάτων Aspose.Slides. Η κλάση MasterLayoutSlideCollection υλοποιεί τη διεπαφή IMasterLayoutSlideCollection.

Η διεπαφή IMasterLayoutSlideCollection αντιπροσωπεύει μια συλλογή όλων των διαφανειών διάταξης ενός ορισμένου δάσκαλου διαφάνειας. Επεκτείνει τη διεπαφή ILayoutSlideCollection με μεθόδους για προσθήκη, εισαγωγή, αφαίρεση ή κλωνοποίηση διαφανειών διάταξης στο πλαίσιο των μεμονωμένων συλλογών των διαφανειών διάταξης ενός δάσκαλου:

``` csharp

 // Υπογραφή μεθόδου:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Παράδειγμα κώδικα που προσαρτά το αντίγραφο του sourceLayout στο destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

Η μέθοδος μπορεί να χρησιμοποιηθεί για να προσθέσει ένα αντίγραφο μιας συγκεκριμένης διαφάνειας διάταξης στο τέλος της συλλογής. Η νέα διάταξη θα συνδεθεί με τη γονική διαφάνεια δάσκαλο για αυτήν τη συλλογή διαφανειών διάταξης. Έτσι είναι ανάλογη με την αντιγραφή ή επικόλληση με την επιλογή **Use Destination Theme** στο PowerPoint. Αντίστοιχη μέθοδος είναι η IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) προσπελαζόμενη μέσω της ιδιότητας IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Χρησιμοποιείται για να εισάγει ένα αντίγραφο μιας συγκεκριμένης διαφάνειας διάταξης στην καθορισμένη θέση της συλλογής. Η νέα διάταξη θα συνδεθεί με τη γονική διαφάνεια δάσκαλο για αυτήν τη συλλογή. Έτσι είναι ανάλογη με την αντιγραφή και επικόλληση με την επιλογή **Use Destination Theme** στο PowerPoint.

- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);

- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Χρησιμοποιείται για να προσθέσει ή να εισάγει μια νέα διαφάνεια διάταξης. Είδη διατάξεων που υποστηρίζονται: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Το όνομα διάταξης μπορεί να παραχθεί αυτόματα. Μια προστιθέμενη διάταξη του τύπου SlideLayoutType.Custom δεν περιέχει σύμβολα κράτησης θέσης και δεν περιέχει σχήματα. Αντίστοιχη της μεθόδου είναι η IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) προσπελαζόμενη μέσω της ιδιότητας IPresentation.LayoutSlides.

- void RemoveAt(int index); – Χρησιμοποιείται για να αφαιρέσει τη διάταξη στην καθορισμένη θέση της συλλογής.

- void Reorder(int index, ILayoutSlide layoutSlide); – Χρησιμοποιείται για να μετακινήσει τη διαφάνεια διάταξης στη συλλογή στην καθορισμένη θέση.

### **Αλλαγμένες Μέθοδοι και Ιδιότητες**
#### **Υπογραφή της Μεθόδου Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
Η υπογραφή της μεθόδου ISlideCollection:

`ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);`

είναι παρωχημένη και αντικαθίσταται από την υπογραφή

`ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)`

Η παράμετρος allowCloneMissingLayout καθορίζει τι γίνεται αν δεν υπάρχει κατάλληλη διάταξη στο destMaster για τη νέα (κλωνοποιημένη) διαφάνεια. Η κατάλληλη διάταξη είναι αυτή με τον ίδιο τύπο ή όνομα με τη διάταξη της πηγαίας διαφάνειας. Εάν δεν υπάρχει κατάλληλη διάταξη στον ορισμένο δάσκαλο, η διάταξη της πηγή διαφάνειας θα κλωνοποιηθεί (αν το allowCloneMissingLayout είναι true) ή θα ριχτεί ένα PptxEditException (αν είναι false).

Κλήση της παρωχημένης μεθόδου όπως

`AddClone(sourceSlide, destMaster);`

υποθέτει ότι το allowCloneMissingLayout είναι false (δηλαδή, θα ριχτεί PptxEditException αν δεν υπάρχει κατάλληλη διάταξη). Η λειτουργικά ισοδύναμη κλήση με τη νέα υπογραφή είναι:

`AddClone(sourceSlide, destMaster, false);`

Αν θέλετε οι ελλιπείς διατάξεις να κλωνοποιούνται αυτόματα αντί για ρίψη PptxEditException, περάστε την παράμετρο allowCloneMissingLayout ως true.

Το ίδιο ισχύει για τη μέθοδο ISlideCollection:

`ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);`

που επίσης είναι παρωχημένη και αντικαθίσταται από την υπογραφή

`ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);`

#### **Τύπος της Ιδιότητας Aspose.Slides.IMasterSlide.LayoutSlides**
Ο τύπος της ιδιότητας Aspose.Slides.IMasterSlide.LayoutSlides έχει αλλάξει από ILayoutSlideCollection στο νέο interface IMasterLayoutSlideCollection. Το IMasterLayoutSlideCollection είναι απογόμενος της ILayoutSlideCollection, επομένως ο υπάρχων κώδικας δεν απαιτεί προσαρμογές.

#### **Τύπος της Ιδιότητας Aspose.Slides.IPresentation.LayoutSlides Έχει Αλλαχθεί**
Ο τύπος της ιδιότητας Aspose.Slides.IPresentation.LayoutSlides έχει αλλάξει από ILayoutSlideCollection στο νέο interface IGlobalLayoutSlideCollection. Το IGlobalLayoutSlideCollection είναι απογόμενος της ILayoutSlideCollection, επομένως ο υπάρχων κώδικας δεν απαιτεί προσαρμογές.