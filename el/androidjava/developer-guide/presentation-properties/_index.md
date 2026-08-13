---
title: Διαχείριση Ιδιοτήτων Παρουσίασης στο Android
linktitle: Ιδιότητες Παρουσίασης
type: docs
weight: 70
url: /el/androidjava/presentation-properties/
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
- Γλώσσα ελέγχου
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε τις ιδιότητες παρουσίασης στο Aspose.Slides για Android μέσω Java και βελτιστοποιήστε την αναζήτηση, το branding και την ροή εργασιών στα αρχεία PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Το Aspose.Slides υποστηρίζει δύο τύπους ιδιοτήτων εγγράφων: **Built-in** και **Custom**. Και οι δύο τύποι ιδιοτήτων μπορούν εύκολα να προσπελαστούν και να διαχειριστούν χρησιμοποιώντας το API του Aspose.Slides.

Το Aspose.Slides σάς επιτρέπει να εργαστείτε με τις ιδιότητες εγγράφου παρουσίασης μέσω της διεπαφής [IDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties/) . Μια εμφάνιση αυτής της διεπαφής επιστρέφεται από τη μέθοδο [Presentation.getDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) . Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="info" %}} 

Παρακαλούμε σημειώστε ότι τα πεδία **Application** και **AppVersion** δεν μπορούν να τροποποιηθούν. Το Aspose.Slides τα ξαναγράφει σε κάθε αποθήκευση, έτσι ώστε μια αποθηκευμένη παρουσίαση να αναφέρει πάντα το όνομα προϊόντος Aspose.Slides και την έκδοση της βιβλιοθήκης που το παρήγαγε. Οποιαδήποτε τιμή περάσει στη μέθοδο `setNameOfApplication` απορρίπτεται όταν η παρουσίαση γράφεται.

{{% /alert %}} 

## **Ιδιότητες Εγγράφου στο PowerPoint**

Το Microsoft PowerPoint 2007 επιτρέπει τη διαχείριση των ιδιοτήτων εγγράφου των αρχείων παρουσίασης. Το μόνο που χρειάζεται να κάνετε είναι να κάνετε κλικ στο εικονίδιο Office και στη συνέχεια στο στοιχείο μενού **Prepare | Properties | Advanced Properties** του Microsoft PowerPoint 2007 όπως φαίνεται παρακάτω:

|**Επιλογή στοιχείου μενού Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Αφού επιλέξετε το στοιχείο μενού **Advanced Properties**, θα εμφανιστεί ένας διάλογος που επιτρέπει τη διαχείριση των ιδιοτήτων εγγράφου του αρχείου PowerPoint, όπως φαίνεται παρακάτω στη εικόνα:

|**Διάλογος Ιδιοτήτων**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Στον παραπάνω **Διάλογος Ιδιοτήτων**, μπορείτε να δείτε ότι υπάρχουν πολλές καρτέλες όπως **General**, **Summary**, **Statistics**, **Contents** και **Custom**. Όλες αυτές οι καρτέλες επιτρέπουν τη διαμόρφωση διαφορετικών τύπων πληροφοριών που σχετίζονται με τα αρχεία PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση των προσαρμοσμένων ιδιοτήτων των αρχείων PowerPoint.



## **Εργασία με Ιδιότητες Εγγράφου χρησιμοποιώντας Aspose.Slides for Android μέσω Java**

Όπως περιγράφηκε προηγουμένως, το Aspose.Slides for Android μέσω Java υποστηρίζει δύο είδη ιδιοτήτων εγγράφου, που είναι οι ιδιότητες **Built-in** και **Custom**. Έτσι, οι προγραμματιστές μπορούν να έχουν πρόσβαση και στα δύο είδη ιδιοτήτων χρησιμοποιώντας το API του Aspose.Slides for Android μέσω Java. Το Aspose.Slides for Android μέσω Java παρέχει μια κλάση [IDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties) που αντιπροσωπεύει τις ιδιότητες εγγράφου που συνδέονται με ένα αρχείο παρουσίασης μέσω της ιδιότητας **Presentation.DocumentProperties**.

Οι προγραμματιστές μπορούν να χρησιμοποιήσουν την ιδιότητα **IDocumentProperties** που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) για να έχουν πρόσβαση στις ιδιότητες εγγράφου των αρχείων παρουσίασης, όπως περιγράφεται παρακάτω:

## **Πρόσβαση στις Built-in Ιδιότητες**

Αυτές οι ιδιότητες που εκτίθενται από το αντικείμενο [IDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties) περιλαμβάνουν: **Creator** (Συγγραφέας), **Description**, **Keywords**, **Created** (Ημερομηνία Δημιουργίας), **Modified** (Ημερομηνία Τροποποίησης), **Printed** (Ημερομηνία Τελευταίας Εκτύπωσης), **LastModifiedBy**, **Keywords**, **SharedDoc** (Κοινή χρήση μεταξύ διαφορετικών παραγωγών;), **PresentationFormat**, **Subject** και **Title**

```java
import com.aspose.slides.*;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει την παρουσίαση
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Δημιουργία αναφοράς σε αντικείμενο IDocumentProperties που σχετίζεται με Presentation
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

## **Τροποποίηση Built-in Ιδιοτήτων**

Η τροποποίηση των built-in ιδιοτήτων των αρχείων παρουσίασης είναι εξίσου εύκολη με την πρόσβασή τους. Μπορείτε απλώς να αντιστοιχίσετε μια τιμή συμβολοσειράς σε οποιαδήποτε επιθυμητή ιδιότητα και η τιμή της ιδιότητας θα τροποποιηθεί. Στο παρακάτω παράδειγμα, δείξαμε πώς μπορούμε να τροποποιήσουμε τις built-in ιδιότητες εγγράφου του αρχείου παρουσίασης χρησιμοποιώντας το Aspose.Slides for Android μέσω Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Δημιουργία αναφοράς σε αντικείμενο IDocumentProperties που σχετίζεται με Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Ορισμός των ενσωματωμένων ιδιοτήτων
    dp.setAuthor("Aspose.Slides for Android via Java");
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

Αυτό το παράδειγμα τροποποιεί τις built-in ιδιότητες της παρουσίασης που μπορούν να προβληθούν όπως φαίνονται παρακάτω:

|**Built-in ιδιότητες εγγράφου μετά τη τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Εγγράφου**

Το Aspose.Slides for Android μέσω Java επιτρέπει επίσης στους προγραμματιστές να προσθέτουν προσαρμοσμένες τιμές για τις ιδιότητες εγγράφου παρουσίασης. Το παρακάτω παράδειγμα προσθέτει τρεις προσαρμοσμένες ιδιότητες, στη συνέχεια αναζητά το όνομα που είναι αποθηκευμένο στο δείκτη 2 και την αφαιρεί, ώστε η αποθηκευμένη παρουσίαση να διατηρεί μόνο δύο από αυτές. Οι προσαρμοσμένες ιδιότητες ταξινομούνται αλφαβητικά, όχι με τη σειρά που προστέθηκαν.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Λήψη Ιδιοτήτων Εγγράφου
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

Το Aspose.Slides for Android μέσω Java επιτρέπει επίσης στους προγραμματιστές να έχουν πρόσβαση στις τιμές των προσαρμοσμένων ιδιοτήτων. Ένα παράδειγμα δίνεται παρακάτω που δείχνει πώς μπορείτε να αποκτήσετε πρόσβαση και να τροποποιήσετε όλες αυτές τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Δημιουργία αναφοράς σε αντικείμενο DocumentProperties που σχετίζεται με Presentation
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

Αυτό το παράδειγμα τροποποιεί τις προσαρμοσμένες ιδιότητες της παρουσίασης [PPTX](https://docs.fileformat.com/presentation/pptx/). Οι παρακάτω εικόνες δείχνουν τις προσαρμοσμένες ιδιότητες της παρουσίασης πριν και μετά την τροποποίηση:

|**Προσαρμοσμένες Ιδιότητες πριν από την Τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Προσαρμοσμένες Ιδιότητες μετά την Τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Προηγμένες Ιδιότητες Εγγράφου**

{{% alert color="info" %}} 

Προστέθηκαν νέες μέθοδοι [ReadDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) , [UpdateDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) και [WriteBindedPresentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) στο [IPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo) , η λογική του setter της ιδιότητας [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) έχει αλλάξει.

{{% /alert %}} 

Οι δύο νέες μέθοδοι [ReadDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) και [UpdateDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) έχουν προστεθεί στη διεπαφή [IPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo). Παρέχουν γρήγορη πρόσβαση σε ιδιότητες εγγράφου και επιτρέπουν την αλλαγή και ενημέρωση των ιδιοτήτων χωρίς τη φόρτωση ολόκληρης της παρουσίασης.

Το τυπικό σενάριο φόρτωσης των ιδιοτήτων, αλλαγής κάποιας τιμής και ενημέρωσης του εγγράφου μπορεί να υλοποιηθεί με τον ακόλουθο τρόπο:

```java
import com.aspose.slides.*;

// διάβαση των πληροφοριών της παρουσίασης
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// απόκτηση των τρεχουσών ιδιοτήτων
IDocumentProperties props = info.readDocumentProperties();

// ορισμός νέων τιμών για τα πεδία Συγγραφέας και Τίτλος
props.setAuthor("New Author");
props.setTitle("New Title");

// ενημέρωση της παρουσίασης με νέες τιμές
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Υπάρχει ένας άλλος τρόπος χρήσης των ιδιοτήτων ενός συγκεκριμένου παρουσίασης ως πρότυπο για ενημέρωση ιδιοτήτων σε άλλες παρουσιάσεις:

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

Ένα νέο πρότυπο μπορεί να δημιουργηθεί από το μηδέν και στη συνέχεια να χρησιμοποιηθεί για ενημέρωση πολλαπλών παρουσιάσεων:

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

## **Ορισμός Γλώσσας Ελέγχου**

Το Aspose.Slides παρέχει την ιδιότητα LanguageId (εκτεθειμένη από την κλάση PortionFormat) για να σας επιτρέψει να ορίσετε τη γλώσσα ελέγχου για ένα έγγραφο PowerPoint. Η γλώσσα ελέγχου είναι η γλώσσα για την οποία ελέγχονται η ορθογραφία και η γραμματική στο PowerPoint.

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

    portionFormat.setLanguageId("zh-CN"); // ορίστε το Id μιας γλώσσας ελέγχου

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Προσθέτει ένα νέο σχήμα ορθογώνιο με κείμενο
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Ελέγχει τη γλώσσα του πρώτου τμήματος
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ζωντανό Παράδειγμα**

Δοκιμάστε την [**Aspose.Slides Metadata**](https://products.aspose.app/slides/el/metadata) online εφαρμογή για να δείτε πώς να δουλέψετε με ιδιότητες εγγράφου μέσω του Aspose.Slides API:

[![Προβολή & Επεξεργασία Μεταδεδομένων PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## ***ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

### Πώς μπορώ να αφαιρέσω μια built-in ιδιότητα από μια παρουσίαση;

Οι built-in ιδιότητες αποτελούν αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν πλήρως. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις ορίσετε κενές, εφόσον η συγκεκριμένη ιδιότητα το επιτρέπει.

### Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;

Αν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της.

### Μπορώ να έχω πρόσβαση στις ιδιότητες της παρουσίασης χωρίς να φορτώσω ολόκληρη την παρουσίαση;

Ναι, μπορείτε να έχετε πρόσβαση στις ιδιότητες της παρουσίασης χωρίς να φορτώσετε ολόκληρη την παρουσίαση χρησιμοποιώντας τη μέθοδο `getPresentationInfo` από την κλάση [PresentationFactory](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationfactory/) . Στη συνέχεια, χρησιμοποιήστε τη μέθοδο `readDocumentProperties` που παρέχεται από τη διεπαφή [IPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/) για να διαβάσετε τις ιδιότητες αποδοτικά, εξοικονομώντας μνήμη και βελτιώνοντας την απόδοση.