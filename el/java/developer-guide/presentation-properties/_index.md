---
title: Διαχείριση ιδιοτήτων παρουσίασης σε Java
linktitle: Ιδιότητες παρουσίασης
type: docs
weight: 70
url: /el/java/presentation-properties/
keywords:
- Ιδιότητες PowerPoint
- Ιδιότητες παρουσίασης
- Ιδιότητες εγγράφου
- Ενσωματωμένες ιδιότητες
- Προσαρμοσμένες ιδιότητες
- Προηγμένες ιδιότητες
- Διαχείριση ιδιοτήτων
- Τροποποίηση ιδιοτήτων
- Μεταδεδομένα εγγράφου
- Επεξεργασία μεταδεδομένων
- Γλώσσα διορθωτικού ελέγχου
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Διαχειριστείτε τις ιδιότητες παρουσίασης στο Aspose.Slides για Java και βελτιώστε την αναζήτηση, την εμπορική σήμανση και τη ροή εργασιών στα αρχεία PowerPoint και OpenDocument σας."
---
## **Εισαγωγή**

Το Aspose.Slides υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Built-in** και **Custom**. Και οι δύο τύποι ιδιοτήτων μπορούν εύκολα να προσπελαστούν και να διαχειριστούν χρησιμοποιώντας το API του Aspose.Slides.

Το Aspose.Slides σας επιτρέπει να εργαστείτε με τις ιδιότητες εγγράφου παρουσίασης μέσω της διεπαφής [IDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties/) . Μια παρουσίαση αυτής της διεπαφής επιστρέφεται από τη μέθοδο [Presentation.getDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getDocumentProperties--) . Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="primary" %}} 

Παρακαλώ σημειώστε ότι τα πεδία **Application** και **Producer** δεν μπορούν να τροποποιηθούν, καθώς αυτά τα πεδία θα εμφανίζουν πάντα "Aspose Ltd." και "Aspose.Slides for Java x.x.x".

{{% /alert %}} 

## **Ιδιότητες εγγράφου στο PowerPoint**

Το Microsoft PowerPoint 2007 επιτρέπει τη διαχείριση των ιδιοτήτων εγγράφου των αρχείων παρουσίασης. Το μόνο που χρειάζεται να κάνετε είναι να κάνετε κλικ στο εικονίδιο Office και, στη συνέχεια, στο στοιχείο μενού **Prepare | Properties | Advanced Properties** του Microsoft PowerPoint 2007 όπως φαίνεται παρακάτω:

|**Επιλογή στοιχείου μενού Προχωρημένες Ιδιότητες**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Αφού επιλέξετε το στοιχείο μενού **Advanced Properties**, θα εμφανιστεί ένας διάλογος που σας επιτρέπει να διαχειριστείτε τις ιδιότητες εγγράφου του αρχείου PowerPoint, όπως φαίνεται παρακάτω στη εικόνα:

|**Διάλογος Ιδιοτήτων**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Στον παραπάνω **Διάλογος Ιδιοτήτων**, μπορείτε να δείτε ότι υπάρχουν πολλές καρτέλες όπως **General**, **Summary**, **Statistics**, **Contents** και **Custom**. Όλες αυτές οι καρτέλες επιτρέπουν τη διαμόρφωση διαφορετικών τύπων πληροφοριών σχετικών με τα αρχεία PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση των προσαρμοσμένων ιδιοτήτων των αρχείων PowerPoint.

### Εργασία με Ιδιότητες Εγγράφου Χρησιμοποιώντας το Aspose.Slides για Java

Όπως περιγράφηκε νωρίτερα, το Aspose.Slides για Java υποστηρίζει δύο είδη ιδιοτήτων εγγράφου, οι **Built-in** και **Custom**. Έτσι, οι προγραμματιστές μπορούν να έχουν πρόσβαση και στα δύο είδη ιδιοτήτων χρησιμοποιώντας το API του Aspose.Slides για Java. Το Aspose.Slides για Java παρέχει την κλάση [IDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties) που αντιπροσωπεύει τις ιδιότητες εγγράφου που σχετίζονται με ένα αρχείο παρουσίασης μέσω της ιδιότητας **Presentation.DocumentProperties**.

Οι προγραμματιστές μπορούν να χρησιμοποιήσουν την ιδιότητα **IDocumentProperties** που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) για να έχουν πρόσβαση στις ιδιότητες εγγράφου των αρχείων παρουσίασης όπως περιγράφεται παρακάτω:

## **Πρόσβαση σε Ενσωματωμένες Ιδιότητες**

Αυτές οι ιδιότητες που εκτίθενται από το αντικείμενο [IDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties) περιλαμβάνουν: **Creator** (Συγγραφέας), **Description**, **Keywords**, **Created** (Ημερομηνία δημιουργίας), **Modified** (Ημερομηνία τροποποίησης), **Printed** (Τελευταία ημερομηνία εκτύπωσης), **LastModifiedBy**, **Keywords**, **SharedDoc** (Κοινή χρήση μεταξύ διαφορετικών παραγωγών;), **PresentationFormat**, **Subject** και **Title**

```java
// Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει την παρουσίαση
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Δημιουργήστε μια αναφορά στο αντικείμενο IDocumentProperties που σχετίζεται με την Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Εμφανίστε τις ενσωματωμένες ιδιότητες
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Τροποποίηση Ενσωματωμένων Ιδιοτήτων**

Η τροποποίηση των ενσωματωμένων ιδιοτήτων των αρχείων παρουσίασης είναι τόσο εύκολη όσο η πρόσβασή τους. Απλώς αντιστοιχίστε μια τιμή κειμένου σε οποιαδήποτε επιθυμητή ιδιότητα και η τιμή της ιδιότητας θα τροποποιηθεί. Στο παρακάτω παράδειγμα, δείχνουμε πώς μπορούμε να τροποποιήσουμε τις ενσωματωμένες ιδιότητες εγγράφου της παρουσίασης χρησιμοποιώντας το Aspose.Slides για Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Δημιουργήστε μια αναφορά στο αντικείμενο IDocumentProperties που σχετίζεται με την Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Ορίστε τις ενσωματωμένες ιδιότητες
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Αποθηκεύστε την παρουσίασή σας σε ένα αρχείο
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Το παράδειγμα αυτό τροποποιεί τις ενσωματωμένες ιδιότητες της παρουσίασης, όπως φαίνεται παρακάτω:

|**Ενσωματωμένες ιδιότητες εγγράφου μετά την τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Εγγράφου**

Το Aspose.Slides για Java επιτρέπει επίσης στους προγραμματιστές να προσθέσουν προσαρμοσμένες τιμές για τις ιδιότητες εγγράφου παρουσίασης. Ένα παράδειγμα παρατίθεται παρακάτω που δείχνει πώς να ορίσετε τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```java
Presentation pres = new Presentation();
try {
    // Λήψη ιδιοτήτων εγγράφου
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Προσθήκη προσαρμοσμένων ιδιοτήτων
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Λήψη ονόματος ιδιότητας σε συγκεκριμένο δείκτη
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Αφαίρεση επιλεγμένης ιδιότητας
    dProps.removeCustomProperty(getPropertyName);
    
    // Αποθήκευση παρουσίασης
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Προσαρμοσμένες Ιδιότητες Εγγράφου Προστέθηκαν**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Πρόσβαση και Τροποποίηση Προσαρμοσμένων Ιδιοτήτων**

Το Aspose.Slides για Java επιτρέπει επίσης στους προγραμματιστές να έχουν πρόσβαση στις τιμές των προσαρμοσμένων ιδιοτήτων. Ένα παράδειγμα παρατίθεται παρακάτω που δείχνει πώς μπορείτε να αποκτήσετε πρόσβαση και να τροποποιήσετε όλες αυτές τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Δημιουργήστε μια αναφορά στο αντικείμενο DocumentProperties που σχετίζεται με την Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Πρόσβαση και τροποποίηση προσαρμοσμένων ιδιοτήτων
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Εμφάνιση ονομάτων και τιμών των προσαρμοσμένων ιδιοτήτων
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Τροποποίηση τιμών των προσαρμοσμένων ιδιοτήτων
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Αποθηκεύστε την παρουσίασή σας σε ένα αρχείο
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Αυτό το παράδειγμα τροποποιεί τις προσαρμοσμένες ιδιότητες της [PPTX ](https://docs.fileformat.com/presentation/pptx/)παρουσίασης. Οι παρακάτω εικόνες δείχνουν τις προσαρμοσμένες ιδιότητες της παρουσίασης πριν και μετά την τροποποίηση:

|**Προσαρμοσμένες Ιδιότητες πριν την Τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Προσαρμοσμένες Ιδιότητες μετά την Τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Προηγμένες Ιδιότητες Εγγράφου**

{{% alert color="primary" %}} 

Νέες μέθοδοι [ReadDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), και [WriteBindedPresentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) προστέθηκαν στο [IPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo), η λογική του setter της ιδιότητας [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) έχει αλλάξει.

{{% /alert %}} 

Οι δύο νέες μέθοδοι [ReadDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) και [UpdateDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) προστέθηκαν στο πρόσωπο [IPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo). Παρέχουν γρήγορη πρόσβαση στις ιδιότητες εγγράφου και επιτρέπουν την αλλαγή και ενημέρωση των ιδιοτήτων χωρίς φόρτωση ολόκληρης της παρουσίασης.

Το τυπικό σενάριο φόρτωσης των ιδιοτήτων, αλλαγής κάποιας τιμής και ενημέρωσης του εγγράφου μπορεί να υλοποιηθεί με τον ακόλουθο τρόπο:

```java
// διαβάστε τις πληροφορίες της παρουσίασης
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// αποκτήστε τις τρέχουσες ιδιότητες
IDocumentProperties props = info.readDocumentProperties();

// ορίστε τις νέες τιμές των πεδίων Συγγραφέας και Τίτλου
props.setAuthor("New Author");
props.setTitle("New Title");

// ενημερώστε την παρουσίαση με νέες τιμές
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Υπάρχει άλλος τρόπος να χρησιμοποιήσετε τις ιδιότητες μιας συγκεκριμένης παρουσίασης ως πρότυπο για την ενημέρωση ιδικοτήτων σε άλλες παρουσιάσεις:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Μπορεί να δημιουργηθεί ένα νέο πρότυπο από το μηδέν και στη συνέχεια να χρησιμοποιηθεί για την ενημέρωση πολλαπλών παρουσιάσεων:

```java
DocumentProperties template = new DocumentProperties();\

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Ορισμός Γλώσσας Διόρθωσης**

Το Aspose.Slides παρέχει την ιδιότητα LanguageId (εκτείνεται από την κλάση PortionFormat) ώστε να μπορείτε να ορίσετε τη γλώσσα διόρθωσης για ένα έγγραφο PowerPoint. Η γλώσσα διόρθωσης είναι η γλώσσα για την οποία ελέγχονται ορθογραφία και γραμματικούς κανόνες στο PowerPoint.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε τη γλώσσα διόρθωσης για ένα PowerPoint: xxx Why is LanguageId missing from Java PortionFormat class?

```java
Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // ορίστε το Id μιας γλώσσας ελέγχου ορθογραφίας

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε τη προεπιλεγμένη γλώσσα για ολόκληρη την παρουσίαση PowerPoint:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Προσθέτει ένα νέο σχήμα ορθογωνίου με κείμενο
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Ελέγχει τη γλώσσα του πρώτου τμήματος
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ζωντανό Παράδειγμα**

Δοκιμάστε το [**Aspose.Slides Metadata**](https://products.aspose.app/slides/el/metadata) online app για να δείτε πώς να εργαστείτε με τις ιδιότητες εγγράφου μέσω του Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## ***Συχνές ερωτήσεις**

**Πώς μπορώ να καταργήσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες αποτελούν αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις θέσετε κενές, εφόσον το επιτρέπει η συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Αν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να έχω πρόσβαση στις ιδιότητες της παρουσίασης χωρίς να την φορτώσω πλήρως;**

Ναι, μπορείτε να έχετε πρόσβαση στις ιδιότητες της παρουσίασης χωρίς να την φορτώσετε πλήρως χρησιμοποιώντας τη μέθοδο `getPresentationInfo` από την κλάση [PresentationFactory](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationfactory/). Στη συνέχεια, χρησιμοποιήστε τη μέθοδο `readDocumentProperties` που παρέχεται από το πρόσωπο [IPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/) για να διαβάσετε τις ιδιότητες αποδοτικά, εξοικονομώντας μνήμη και βελτιώνοντας την απόδοση.