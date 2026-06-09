---
title: Διαχειριστείτε Σειρές και Στήλες στους Πίνακες PowerPoint σε Android
linktitle: Σειρές και Στήλες
type: docs
weight: 20
url: /el/androidjava/manage-rows-and-columns/
keywords:
- γραμμή πίνακα
- στήλη πίνακα
- πρώτη γραμμή
- κεφαλίδα πίνακα
- κλωνοποίηση γραμμής
- κλωνοποίηση στήλης
- αντιγραφή γραμμής
- αντιγραφή στήλης
- αφαίρεση γραμμής
- αφαίρεση στήλης
- μορφοποίηση κειμένου γραμμής
- μορφοποίηση κειμένου στήλης
- στυλ πίνακα
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε τις σειρές και τις στήλες πίνακα στο PowerPoint με το Aspose.Slides για Android μέσω Java και επιταχύνετε την επεξεργασία της παρουσίασης και τις ενημερώσεις δεδομένων."
---
## **Εισαγωγή**

Για να μπορείτε να διαχειρίζεστε τις γραμμές και τις στήλες ενός πίνακα σε μια παρουσίαση PowerPoint, το Aspose.Slides παρέχει την κλάση [Table](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/table/) , τη διεπαφή [ITable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITable) και πολλούς άλλους τύπους.

## **Ορισμός της Πρώτης Γραμμής ως Κεφαλίδας**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και φορτώστε την παρουσίαση.  
2. Αποκτήστε μια αναφορά στη διαφάνεια μέσω του δείκτη της.  
3. Δημιουργήστε ένα αντικείμενο [ITable] και θέστε το σε null.  
4. Επαναλάβετε μέσω όλων των αντικειμένων [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/) για να βρείτε τον σχετικό πίνακα.  
5. Ορίστε την πρώτη γραμμή του πίνακα ως κεφαλίδα του.  

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε την πρώτη γραμμή ενός πίνακα ως κεφαλίδα:

```java
// Δημιουργεί μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // Προσπελαύνει την πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Αρχικοποιεί το TableEx ως null
    ITable tbl = null;

    // Διατρέχει τα σχήματα και ορίζει μια αναφορά στον πίνακα
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            // Ορίζει την πρώτη γραμμή ενός πίνακα ως κεφαλίδα του
            tbl.setFirstRow(true);
        }
    }
    
    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Κλωνοποίηση Γραμμής ή Στήλης Πίνακα**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και φορτώστε την παρουσίαση,  
2. Αποκτήστε μια αναφορά στη διαφάνεια μέσω του δείκτη της.  
3. Ορίστε έναν πίνακα `columnWidth`.  
4. Ορίστε έναν πίνακα `rowHeight`.  
5. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITable) στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. Κλωνοποιήστε τη γραμμή του πίνακα.  
7. Κλωνοποιήστε τη στήλη του πίνακα.  
8. Αποθηκεύστε την τροποποιημένη παρουσίαση.  

Αυτός ο κώδικας Java δείχνει πώς να κλωνοποιήσετε τη γραμμή ή τη στήλη ενός πίνακα PowerPoint:

```java
 // Δημιουργεί μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // Προσπελαύνει την πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Ορίζει στήλες με πλάτη και γραμμές με ύψη
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Προσθέτει κάποιο κείμενο στο κελί 1 της γραμμής 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // Προσθέτει κάποιο κείμενο στο κελί 2 της γραμμής 1
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // Κλωνοποιεί τη γραμμή 1 στο τέλος του πίνακα
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Προσθέτει κάποιο κείμενο στο κελί 1 της γραμμής 2
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // Προσθέτει κάποιο κείμενο στο κελί 2 της γραμμής 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // Κλωνοποιεί τη γραμμή 2 ως τέταρτη γραμμή του πίνακα
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Κλωνοποιεί την πρώτη στήλη στο τέλος
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Κλωνοποιεί τη δεύτερη στήλη στη θέση τέταρτης στήλης
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αφαίρεση Γραμμής ή Στήλης από Πίνακα**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και φορτώστε την παρουσίαση,  
2. Αποκτήστε μια αναφορά στη διαφάνεια μέσω του δείκτη της.  
3. Ορίστε έναν πίνακα `columnWidth`.  
4. Ορίστε έναν πίνακα `rowHeight`.  
5. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITable) στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. Αφαιρέστε τη γραμμή του πίνακα.  
7. Αφαιρέστε τη στήλη του πίνακα.  
8. Αποθηκεύστε την τροποποιημένη παρουσίαση.  

Αυτός ο κώδικας Java δείχνει πώς να αφαιρέσετε μια γραμμή ή μια στήλη από έναν πίνακα:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Γραμμής Πίνακα**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και φορτώστε την παρουσίαση,  
2. Αποκτήστε μια αναφορά στη διαφάνεια μέσω του δείκτη της.  
3. Πρόσβαση στο σχετικό αντικείμενο [ITable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITable) από τη διαφάνεια.  
4. Ορίστε το [setFontHeight(float value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) στα κελιά της πρώτης γραμμής.  
5. Ορίστε το [setAlignment(int value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) και το [setMarginRight(float value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) στα κελιά της πρώτης γραμμής.  
6. Ορίστε το [setTextVerticalType(byte value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) στα κελιά της δεύτερης γραμμής.  
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.  

Αυτός ο κώδικας Java επιδεικνύει τη λειτουργία.

```java
// Δημιουργεί μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Ας υποθέσουμε ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι πίνακας
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // Ορίζει το ύψος γραμματοσειράς των κελιών της πρώτης γραμμής
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // Ορίζει την στοίχιση κειμένου και το δεξί περιθώριο των κελιών της πρώτης γραμμής
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // Ορίζει τον κατακόρυφο τύπο κειμένου των κελιών της δεύτερης γραμμής
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Στήλης Πίνακα**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και φορτώστε την παρουσίαση,  
2. Αποκτήστε μια αναφορά στη διαφάνεια μέσω του δείκτη της.  
3. Πρόσβαση στο σχετικό αντικείμενο [ITable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITable) από τη διαφάνεια.  
4. Ορίστε το [setFontHeight(float value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) στα κελιά της πρώτης στήλης.  
5. Ορίστε το [setAlignment(int value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) και το [setMarginRight(float value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) στα κελιά της πρώτης στήλης.  
6. Ορίστε το [setTextVerticalType(byte value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) στα κελιά της δεύτερης στήλης.  
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.  

Αυτός ο κώδικας Java επιδεικνύει τη λειτουργία: 

```java
// Δημιουργεί μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Ας υποθέσουμε ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι πίνακας
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // Ορίζει το ύψος γραμματοσειράς των κελιών της πρώτης στήλης
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // Ορίζει την στοίχιση κειμένου και το δεξί περιθώριο των κελιών της πρώτης στήλης σε μια κλήση
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Ορίζει τον κατακόρυφο τύπο κειμένου των κελιών της δεύτερης στήλης
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Λήψη Ιδιοτήτων Στυλ Πίνακα**

Aspose.Slides σάς επιτρέπει να ανακτήσετε τις ιδιότητες στυλ για έναν πίνακα ώστε να μπορείτε να χρησιμοποιήσετε αυτές τις λεπτομέρειες για άλλο πίνακα ή κάπου αλλού. Αυτός ο κώδικας Java δείχνει πώς να λάβετε τις ιδιότητες στυλ από ένα προεπιλεγμένο στυλ πίνακα:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // αλλάζει το προεπιλεγμένο θέμα στυλ preset
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω θέματα/στυλ PowerPoint σε έναν ήδη δημιουργημένο πίνακα;**

Ναι. Ο πίνακας κληρονομεί το θέμα της διαφάνειας/διάταξης/μαστορά, και μπορείτε ακόμη να υπερκαλύψετε γεμίσματα, περιγράμματα και χρώματα κειμένου πάνω από αυτό το θέμα.

**Μπορώ να ταξινομήσω τις γραμμές του πίνακα όπως στο Excel;**

Όχι, οι πίνακες Aspose.Slides δεν διαθέτουν ενσωματωμένη ταξινόμηση ή φίλτρα. Ταξινομήστε τα δεδομένα στη μνήμη πρώτα, μετά επανασυμπληρώστε τις γραμμές του πίνακα με τη δεδομένη σειρά.

**Μπορώ να έχω ζώνες (γραμμωτές) στήλες ενώ διατηρώ προσαρμοσμένα χρώματα σε συγκεκριμένα κελιά;**

Ναι. Ενεργοποιήστε τις ζώνες στήλης, μετά υπερκεντρώστε συγκεκριμένα κελιά με τοπική μορφοποίηση· η μορφοποίηση σε επίπεδο κελιού έχει προτεραιότητα έναντι του στυλ πίνακα.