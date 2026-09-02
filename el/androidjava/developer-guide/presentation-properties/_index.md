---
title: "Διαχείριση Ιδιοτήτων Παρουσίασης σε Android"
linktitle: "Ιδιότητες Παρουσίασης"
type: docs
weight: 70
url: /el/androidjava/presentation-properties/
keywords:
- "Ιδιότητες PowerPoint"
- "Ιδιότητες παρουσίασης"
- "Ιδιότητες εγγράφου"
- "Ενσωματωμένες ιδιότητες"
- "Προσαρμοσμένες ιδιότητες"
- "Προχωρημένες ιδιότητες"
- "Διαχείριση ιδιοτήτων"
- "Τροποποίηση ιδιοτήτων"
- "Μεταδεδομένα εγγράφου"
- "Επεξεργασία μεταδεδομένων"
- "Γλώσσα διορθώσεων"
- "Προεπιλεγμένη γλώσσα"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Διαχειριστείτε τις ιδιότητες παρουσίασης στο Aspose.Slides for Android via Java και βελτιστοποιήστε την αναζήτηση, το branding και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument σας."
---
## **Εισαγωγή**

Το Aspose.Slides υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Ενσωματωμένες** και **Προσαρμοσμένες**. Και οι δύο τύποι ιδιοτήτων μπορούν να προσεγγιστούν και να διαχειριστούν εύκολα μέσω του API του Aspose.Slides.

Το Aspose.Slides σας επιτρέπει να εργαστείτε με ιδιότητες εγγράφου παρουσίασης μέσω της διεπαφής [IDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties/) . Μια παρουσίαση αυτής της διεπαφής επιστρέφεται από τη μέθοδο [Presentation.getDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) . Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="info" title="Σημείωση" %}}

Παρακαλούμε σημειώστε ότι τα πεδία **Application** και **AppVersion** δεν μπορούν να τροποποιηθούν. Το Aspose.Slides τα ξαναγράφει σε κάθε αποθήκευση, έτσι μια αποθηκευμένη παρουσίαση πάντα αναφέρει το όνομα του προϊόντος Aspose.Slides και την έκδοση της βιβλιοθήκης που την δημιούργησε. Οποιαδήποτε τιμή δοθεί στο `setNameOfApplication` απορρίπτεται όταν η παρουσίαση γράφεται.

{{% /alert %}}

## **Ιδιότητες Εγγράφου στο PowerPoint**

Το Microsoft PowerPoint 2007 επιτρέπει τη διαχείριση των ιδιοτήτων εγγράφου των αρχείων παρουσίασης. Το μόνο που χρειάζεται να κάνετε είναι να κάνετε κλικ στο εικονίδιο Office και στη συνέχεια στο μενού **Prepare | Properties | Advanced Properties** του Microsoft PowerPoint 2007 όπως φαίνεται παρακάτω:

|**Επιλογή στοιχείου μενού Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Αφού επιλέξετε το στοιχείο μενού **Advanced Properties**, θα εμφανιστεί ένας διάλογος που σας επιτρέπει να διαχειριστείτε τις ιδιότητες εγγράφου του αρχείου PowerPoint, όπως φαίνεται στην παρακάτω εικόνα:

|**Διάλογος Ιδιοτήτων**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Στον παραπάνω **Διάλογο Ιδιοτήτων**, μπορείτε να δείτε ότι υπάρχουν πολλές καρτέλες όπως **General**, **Summary**, **Statistics**, **Contents** και **Custom**. Όλες αυτές οι καρτέλες επιτρέπουν τη διαμόρφωση διαφόρων τύπων πληροφοριών σχετικών με τα αρχεία PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση των προσαρμοσμένων ιδιοτήτων των αρχείων PowerPoint.

## **Δουλεύοντας με Ιδιότητες Εγγράφου χρησιμοποιώντας Aspose.Slides for Android via Java**

Όπως περιγράψαμε νωρίτερα, το Aspose.Slides for Android via Java υποστηρίζει δύο είδη ιδιοτήτων εγγράφου, που είναι **Ενσωματωμένες** και **Προσαρμοσμένες**. Έτσι, οι προγραμματιστές μπορούν να έχουν πρόσβαση και στα δύο είδη ιδιοτήτων μέσω του API του Aspose.Slides for Android via Java. Το Aspose.Slides for Android via Java παρέχει μια κλάση [IDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties) που αντιπροσωπεύει τις ιδιότητες εγγράφου που συνδέονται με ένα αρχείο παρουσίασης μέσω της ιδιότητας **Presentation.DocumentProperties**.

Οι προγραμματιστές μπορούν να χρησιμοποιήσουν την ιδιότητα **IDocumentProperties** που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) για να έχουν πρόσβαση στις ιδιότητες εγγράφου των αρχείων παρουσίασης όπως περιγράφεται παρακάτω:

## **Πρόσβαση σε Ενσωματωμένες Ιδιότητες**

Αυτές οι ιδιότητες που εκτίθενται από το αντικείμενο [IDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties) περιλαμβάνουν: **Creator** (Συγγραφέας), **Description**, **Keywords**, **Created** (Ημερομηνία Δημιουργίας), **Modified** (Ημερομηνία Τροποποίησης), **Printed** (Τελευταία Ημερομηνία Εκτύπωσης), **LastModifiedBy**, **Keywords**, **SharedDoc** (Κοινόχρηστο μεταξύ διαφορετικών παραγωγών;), **PresentationFormat**, **Subject** και **Title**

```java
import com.aspose.slides.*;

// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει την παρουσίαση
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Δημιουργία αναφοράς στο αντικείμενο IDocumentProperties που σχετίζεται με την Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Εμφάνιση των ενσωματωμένων ιδιοτήτων
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

Η τροποποίηση των ενσωματωμένων ιδιοτήτων των αρχείων παρουσίασης είναι τόσο απλή όσο η πρόσβασή τους. Απλώς αντιστοιχίστε μια τιμή συμβολοσειράς στην επιθυμητή ιδιότητα και η τιμή της ιδιότητας θα τροποποιηθεί. Στο παρακάτω παράδειγμα, δείχνουμε πώς μπορούμε να τροποποιήσουμε τις ενσωματωμένες ιδιότητες εγγράφου της παρουσίασης χρησιμοποιώντας Aspose.Slides for Android via Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Δημιουργία αναφοράς στο αντικείμενο IDocumentProperties που σχετίζεται με την Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Ορισμός των ενσωματωμένων ιδιοτήτων
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Αποθήκευση της παρουσίασης σε αρχείο
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Αυτό το παράδειγμα τροποποιεί τις ενσωματωμένες ιδιότητες της παρουσίασης, όπως φαίνεται παρακάτω:

|**Ενσωματωμένες ιδιότητες εγγράφου μετά την τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Εγγράφου**

Το Aspose.Slides for Android via Java επιτρέπει επίσης στους προγραμματιστές να προσθέτουν προσαρμοσμένες τιμές για τις ιδιότητες εγγράφου παρουσίασης. Το παρακάτω παράδειγμα προσθέτει τρεις προσαρμοσμένες ιδιότητες, στη συνέχεια αναζητά το όνομα που βρίσκεται στο δείκτη 2 και αφαιρεί εκείνη την ιδιότητα, έτσι η αποθηκευμένη παρουσίαση διατηρεί δύο από αυτές. Οι προσαρμοσμένες ιδιότητες ταξινομούνται αλφαβητικά, όχι με τη σειρά που προστέθηκαν.

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

|**Προσαρμοσμένες Ιδιότητες Εγγράφου που Προστέθηκαν**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Πρόσβαση και Τροποποίηση Προσαρμοσμένων Ιδιοτήτων**

Το Aspose.Slides for Android via Java επιτρέπει επίσης στους προγραμματιστές να έχουν πρόσβαση στις τιμές των προσαρμοσμένων ιδιοτήτων. Ένα παράδειγμα δίνεται παρακάτω που δείχνει πώς μπορείτε να προσπελάσετε και να τροποποιήσετε όλες αυτές τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

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

Αυτό το παράδειγμα τροποποιεί τις προσαρμοσμένες ιδιότητες του [PPTX](https://docs.fileformat.com/presentation/pptx/)presentation. Οι παρακάτω εικόνες δείχνουν τις προσαρμοσμένες ιδιότητες της παρουσίασης πριν και μετά την τροποποίηση:

|**Προσαρμοσμένες Ιδιότητες πριν την Τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Προσαρμοσμένες Ιδιότητες μετά την Τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Προηγμένες Ιδιότητες Εγγράφου**

{{% alert color="info" title="Σημείωση" %}}

Νέες μέθοδοι [ReadDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), και [WriteBindedPresentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) προστέθηκαν στο [IPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo), η λογική του setter της ιδιότητας [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) έχει αλλάξει.

{{% /alert %}}

Οι δύο νέες μέθοδοι [ReadDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) και [UpdateDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) προστέθηκαν στη διεπαφή [IPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo). Παρέχουν γρήγορη πρόσβαση στις ιδιότητες εγγράφου και επιτρέπουν την αλλαγή και ενημέρωση των ιδιοτήτων χωρίς τη φόρτωση ολόκληρης της παρουσίασης.

Το τυπικό σενάριο φορτώνει τις ιδιότητες, αλλάζει κάποια τιμή και ενημερώνει το έγγραφο με τον ακόλουθο τρόπο:

```java
import com.aspose.slides.*;

// Ανάγνωση των πληροφοριών της παρουσίασης
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// Απόκτηση των τρεχουσών ιδιοτήτων
IDocumentProperties props = info.readDocumentProperties();

// Ορισμός των νέων τιμών των πεδίων Συγγραφέα και Τίτλου
props.setAuthor("New Author");
props.setTitle("New Title");

// Ενημέρωση της παρουσίασης με νέες τιμές
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Υπάρχει ένας άλλος τρόπος να χρησιμοποιήσετε τις ιδιότητες μιας συγκεκριμένης παρουσίασης ως πρότυπο για την ενημέρωση ιδιοτήτων σε άλλες παρουσιάσεις:

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

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
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

Μπορεί να δημιουργηθεί ένα νέο πρότυπο από το μηδέν και στη συνέχεια να χρησιμοποιηθεί για την ενημέρωση πολλαπλών παρουσιάσεων:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Ορισμός Γλώσσας Διόρθωσης**

Το Aspose.Slides παρέχει την ιδιότητα LanguageId (εμφανιζόμενη από την κλάση PortionFormat) για να επιτρέψει τον ορισμό της γλώσσας διόρθωσης για ένα έγγραφο PowerPoint. Η γλώσσα διόρθωσης είναι η γλώσσα για την οποία ελέγχονται η ορθογραφία και η γραμματική στο PowerPoint.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε τη γλώσσα διόρθωσης για ένα PowerPoint:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε την προεπιλεγμένη γλώσσα για ολόκληρη την παρουσίαση PowerPoint:

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

Δοκιμάστε την εφαρμογή online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/el/metadata) για να δείτε πώς να εργάζεστε με ιδιότητες εγγράφου μέσω του Aspose.Slides API:

[![Προβολή & Επεξεργασία Μεταδεδομένων PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες είναι ενσωματωμένο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις θέσετε σε κενό εάν το επιτρέπει η συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Αν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να προσπελάσω τις ιδιότητες παρουσίασης χωρίς να φορτώσω πλήρως την παρουσίαση;**

Ναι. Χρησιμοποιήστε [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) και στη συνέχεια [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) για να διαβάσετε αποθηκευμένα μεταδεδομένα εγγράφου χωρίς να δημιουργήσετε μια παρουσίαση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) . Δείτε το [Build a Lightweight Presentation Inventory](/slides/el/androidjava/examine-presentation/) για ένα πλήρες παράδειγμα αναφοράς και περιορισμών ανά μορφή.