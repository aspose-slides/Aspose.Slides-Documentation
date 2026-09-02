---
title: Διαχείριση Ιδιοτήτων Παρουσίασης σε Java
linktitle: Ιδιότητες Παρουσίασης
type: docs
weight: 70
url: /el/java/presentation-properties/
keywords:
- Ιδιότητες PowerPoint
- Ιδιότητες παρουσίασης
- Ιδιότητες εγγράφου
- Ενσωματωμένες ιδιότητες
- Προσαρμοσμένες ιδιότητες
- Προχωρημένες ιδιότητες
- Διαχείριση ιδιοτήτων
- Τροποποίηση ιδιοτήτων
- Μεταδεδομένα εγγράφου
- Επεξεργασία μεταδεδομένων
- Γλώσσα ορθογραφικού ελέγχου
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- Παρουσίαση
- Java
- Aspose.Slides
description: "Κατακτήστε τις ιδιότητες παρουσίασης στο Aspose.Slides για Java και βελτιστοποιήστε την αναζήτηση, την εμπορία και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument σας."
---
## **Εισαγωγή**

Aspose.Slides υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Built-in** και **Custom**. Και οι δύο τύποι αυτών των ιδιοτήτων μπορούν εύκολα να προσπελαστούν και να διαχειριστούν χρησιμοποιώντας το API του Aspose.Slides.

Aspose.Slides σας επιτρέπει να εργάζεστε με τις ιδιότητες εγγράφου παρουσίασης μέσω της διεπαφής [IDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties/) . Μια παρουσίαση αυτής της διεπαφής επιστρέφεται από τη μέθοδο [Presentation.getDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getDocumentProperties--) . Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, τροποποιήσετε και διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="info" title="Note" %}}
Παρακαλώ σημειώστε ότι τα πεδία **Application** και **AppVersion** δεν μπορούν να τροποποιηθούν. Το Aspose.Slides τα ξαναγράφει σε κάθε αποθήκευση, έτσι μια αποθηκευμένη παρουσίαση πάντα αναφέρει «Aspose.Slides for Java» και τη έκδοση της βιβλιοθήκης που την δημιούργησε. Οποιαδήποτε τιμή περάσει στη `setNameOfApplication` απορρίπτεται όταν γράφεται η παρουσίαση.
{{% /alert %}}

## **Ιδιότητες Εγγράφου στο PowerPoint**

Το Microsoft PowerPoint 2007 επιτρέπει τη διαχείριση των ιδιοτήτων εγγράφου των αρχείων παρουσίασης. Το μόνο που χρειάζεται να κάνετε είναι να κάνετε κλικ στο εικονίδιο Office και στη συνέχεια στο στοιχείο μενού **Prepare | Properties | Advanced Properties** του Microsoft PowerPoint 2007 όπως φαίνεται παρακάτω:

|**Επιλογή στοιχείου μενού Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Αφού επιλέξετε το στοιχείο μενού **Advanced Properties**, θα εμφανιστεί ένας διάλογος που επιτρέπει τη διαχείριση των ιδιοτήτων εγγράφου του αρχείου PowerPoint, όπως φαίνεται παρακάτω:

|**Διάλογος Ιδιοτήτων**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Στον παραπάνω **Διάλογος Ιδιοτήτων**, μπορείτε να δείτε ότι υπάρχουν πολλές καρτέλες όπως **General**, **Summary**, **Statistics**, **Contents** και **Custom**. Όλες αυτές οι καρτέλες επιτρέπουν τη ρύθμιση διαφορετικών τύπων πληροφοριών σχετικών με τα αρχεία PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση των προσαρμοσμένων ιδιοτήτων των αρχείων PowerPoint.

## **Εργασία με Ιδιότητες Εγγράφου χρησιμοποιώντας το Aspose.Slides for Java**

Όπως περιγράψαμε προηγουμένως, το Aspose.Slides for Java υποστηρίζει δύο είδη ιδιοτήτων εγγράφου, τις **Built-in** και τις **Custom**. Έτσι, οι προγραμματιστές μπορούν να έχουν πρόσβαση και στα δύο είδη ιδιοτήτων χρησιμοποιώντας το API του Aspose.Slides for Java. Το Aspose.Slides for Java παρέχει μια κλάση [IDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties) που αντιπροσωπεύει τις ιδιότητες εγγράφου που σχετίζονται με ένα αρχείο παρουσίασης μέσω της ιδιότητας **Presentation.DocumentProperties**.

Οι προγραμματιστές μπορούν να χρησιμοποιήσουν την ιδιότητα **IDocumentProperties** που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) για να έχουν πρόσβαση στις ιδιότητες εγγράφου των αρχείων παρουσίασης όπως περιγράφεται παρακάτω:

## **Πρόσβαση σε Built-in Ιδιότητες**

Αυτές οι ιδιότητες που εκτίθενται από το αντικείμενο [IDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties) περιλαμβάνουν: **Creator** (Συγγραφέας), **Description**, **Keywords**, **Created** (Ημερομηνία Δημιουργίας), **Modified** (Ημερομηνία Τροποποίησης), **Printed** (Τελευταία Εκτύπωση), **LastModifiedBy**, **Keywords**, **SharedDoc** (Κοινή χρήση μεταξύ διαφορετικών παραγωγών;), **PresentationFormat**, **Subject** και **Title**.

```java
import com.aspose.slides.*;

// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει την παρουσίαση
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Δημιουργία αναφοράς στο αντικείμενο IDocumentProperties που σχετίζεται με την Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Display the built-in properties
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

## **Τροποποίηση Built-in Ιδιοτήτων**

Η τροποποίηση των ενσωματωμένων ιδιοτήτων των αρχείων παρουσίασης είναι τόσο εύκολη όσο η πρόσβαση σε αυτές. Απλώς αντιστοιχίστε μια τιμή κειμένου σε οποιαδήποτε επιθυμητή ιδιότητα και η τιμή της ιδιότητας θα τροποποιηθεί. Στο παρακάτω παράδειγμα, δείξαμε πώς μπορούμε να τροποποιήσουμε τις ενσωματωμένες ιδιότητες εγγράφου της παρουσίασης χρησιμοποιώντας το Aspose.Slides for Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Δημιουργία αναφοράς στο αντικείμενο IDocumentProperties που σχετίζεται με την Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Ορισμός των ενσωματωμένων ιδιοτήτων
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Αποθήκευση της παρουσίασής σας σε αρχείο
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Αυτό το παράδειγμα τροποποιεί τις ενσωματωμένες ιδιότητες της παρουσίασης όπως φαίνεται παρακάτω:

|**Built-in document properties after modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Εγγράφου**

Το Aspose.Slides for Java επιτρέπει επίσης στους προγραμματιστές να προσθέτουν προσαρμοσμένες τιμές για τις ιδιότητες εγγράφου παρουσίασης. Το παρακάτω παράδειγμα προσθέτει τρεις προσαρμοσμένες ιδιότητες, στη συνέχεια αναζητά το όνομα αποθηκευμένο στο δείκτη 2 και αφαιρεί αυτήν την ιδιότητα, έτσι η αποθηκευμένη παρουσίαση κρατά δύο από αυτές. Οι προσαρμοσμένες ιδιότητες ταξινομούνται αλφαβητικά, όχι με τη σειρά προσθήκης.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Λήψη Ιδιοτήτων Εγγράφου
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Προσθήκη Προσαρμοσμένων ιδιοτήτων
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

|**Custom Document Properties Added**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Πρόσβαση και Τροποποίηση Προσαρμοσμένων Ιδιοτήτων**

Το Aspose.Slides for Java επιτρέπει επίσης στους προγραμματιστές να έχουν πρόσβαση στις τιμές των προσαρμοσμένων ιδιοτήτων. Ένα παράδειγμα παρατίθεται παρακάτω που δείχνει πώς μπορείτε να προσπελάσετε και να τροποποιήσετε όλες αυτές τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Δημιουργία αναφοράς στο αντικείμενο DocumentProperties που σχετίζεται με την Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Πρόσβαση και τροποποίηση προσαρμοσμένων ιδιοτήτων
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Εμφάνιση ονομάτων και τιμών των προσαρμοσμένων ιδιοτήτων
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Τροποποίηση τιμών των προσαρμοσμένων ιδιοτήτων
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Αποθήκευση της παρουσίασής σας σε αρχείο
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Αυτό το παράδειγμα τροποποιεί τις προσαρμοσμένες ιδιότητες του [PPTX](https://docs.fileformat.com/presentation/pptx/)presentation. Τα παρακάτω σχήματα δείχνουν τις προσαρμοσμένες ιδιότητες παρουσίασης πριν και μετά τη τροποποίηση:

|**Custom Properties before Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Custom Properties after Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Προηγμένες Ιδιότητες Εγγράφου**

{{% alert color="info" title="Note" %}}
Νέες μέθοδοι [ReadDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) , [UpdateDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) και [WriteBindedPresentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) προστέθηκαν στην [IPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo) , η λογική του setter της ιδιότητας [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) άλλαξε.
{{% /alert %}}

Οι δύο νέες μέθοδοι [ReadDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) και [UpdateDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) προστέθηκαν στη διεπαφή [IPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo) . Παρέχουν γρήγορη πρόσβαση στις ιδιότητες εγγράφου και επιτρέπουν την αλλαγή και ενημέρωση των ιδιοτήτων χωρίς τη φόρτωση ολόκληρης της παρουσίασης.

Το τυπικό σενάριο φορτώνει τις ιδιότητες, αλλάζει κάποια τιμή και ενημερώνει το έγγραφο όπως φαίνεται παρακάτω:

```java
import com.aspose.slides.*;

// ανάγνωση πληροφοριών της παρουσίασης
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// λήψη των τρεχουσών ιδιοτήτων
IDocumentProperties props = info.readDocumentProperties();

// ορισμός των νέων τιμών για τα πεδία Συγγραφέας και Τίτλος
props.setAuthor("New Author");
props.setTitle("New Title");

// ενημέρωση της παρουσίασης με νέες τιμές
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Υπάρχει ένας άλλος τρόπος χρήσης των ιδιοτήτων μιας συγκεκριμένης παρουσίασης ως πρότυπο για ενημέρωση ιδιοτήτων σε άλλες παρουσιάσεις:

```java
import com.aspose.slides.*;

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

```java
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Μπορεί να δημιουργηθεί νέο πρότυπο από το μηδέν και στη συνέχεια να χρησιμοποιηθεί για ενημέρωση πολλαπλών παρουσιάσεων:

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Ορισμός Γλώσσας Ελέγχου**

Το Aspose.Slides παρέχει την ιδιότητα LanguageId (εκτείνεται από την κλάση PortionFormat) για να σας επιτρέψει να ορίσετε τη γλώσσα ελέγχου για ένα έγγραφο PowerPoint. Η γλώσσα ελέγχου είναι η γλώσσα για την οποία ελέγχονται η ορθογραφία και η γραμματική στο PowerPoint.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε τη γλώσσα ελέγχου για ένα PowerPoint:

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

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

    portionFormat.setLanguageId("zh-CN"); // ορίστε το Id μιας γλώσσας ελέγχου

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε τη προεπιλεγμένη γλώσσα για ολόκληρη την παρουσίαση PowerPoint:

```java
import com.aspose.slides.*;

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

Δοκιμάστε την εφαρμογή online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/el/metadata) για να δείτε πώς να εργάζεστε με τις ιδιότητες εγγράφου μέσω του API του Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες είναι αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις θέσετε σε κενό εάν το επιτρέπει η συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Αν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με την καινούργια. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα τη τιμή της ιδιότητας.

**Μπορώ να προσπελάσω τις ιδιότητες παρουσίασης χωρίς να φορτώσω ολόκληρη την παρουσίαση;**

Ναι. Χρησιμοποιήστε [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) και έπειτα [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) για να διαβάσετε τα αποθηκευμένα μεταδεδομένα εγγράφου χωρίς να δημιουργήσετε μια παρουσίαση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) . Δείτε το παράδειγμα [Build a Lightweight Presentation Inventory](/slides/el/java/examine-presentation/) για μια πλήρη αναφορά και περιορισμούς ανά τύπο μορφής.