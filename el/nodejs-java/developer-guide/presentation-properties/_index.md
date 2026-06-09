---
title: Διαχείριση Ιδιοτήτων Παρουσίασης σε JavaScript
linktitle: Ιδιότητες Παρουσίασης
type: docs
weight: 70
url: /el/nodejs-java/presentation-properties/
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
- Γλώσσα επιδιόρθωσης
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχειριστείτε αποτελεσματικά τις ιδιότητες παρουσίασης στο Aspose.Slides for Node.js via Java και βελτιστοποιήστε την αναζήτηση, το branding και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument σας."
---
## **Εισαγωγή**

Το Aspose.Slides υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Built-in** και **Custom**. Και οι δύο τύποι ιδιοτήτων μπορούν να προσεγγιστούν και να διαχειριστούν εύκολα χρησιμοποιώντας το API του Aspose.Slides.

Το Aspose.Slides σας επιτρέπει να εργάζεστε με τις ιδιότητες εγγράφου παρουσίασης μέσω της κλάσης [DocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/) . Ένα αντικείμενο αυτής της κλάσης επιστρέφεται από τη μέθοδο [Presentation.getDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getDocumentProperties) . Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="primary" %}} 

Λάβετε υπόψη ότι δεν μπορείτε να ορίσετε τιμές στα πεδία **Application** και **Producer**, επειδή το Aspose Ltd. και το Aspose.Slides for Node.js via Java x.x.x θα εμφανιστούν σε αυτά τα πεδία.

{{% /alert %}} 

## **Διαχείριση Ιδιοτήτων Παρουσίασης**

Το Microsoft PowerPoint παρέχει μια δυνατότητα προσθήκης ορισμένων ιδιοτήτων στα αρχεία παρουσίασης. Αυτές οι ιδιότητες εγγράφου επιτρέπουν την αποθήκευση χρήσιμων πληροφοριών μαζί με τα έγγραφα (αρχεία παρουσίασης). Υπάρχουν δύο είδη ιδιοτήτων εγγράφου ως εξής:

- Ιδιότητες ορισμένες από το σύστημα (Built-in)
- Ιδιότητες ορισμένες από τον χρήστη (Custom)

Οι **Built-in** ιδιότητες περιέχουν γενικές πληροφορίες για το έγγραφο, όπως ο τίτλος, το όνομα του δημιουργού, στατιστικά του εγγράφου κ.λπ. Οι **Custom** ιδιότητες είναι εκείνες που ορίζονται από τους χρήστες ως ζεύγη **Όνομα/Τιμή**, όπου τόσο το όνομα όσο και η τιμή καθορίζονται από τον χρήστη. Χρησιμοποιώντας το Aspose.Slides for Node.js via Java, οι προγραμματιστές μπορούν να προσπελάσουν και να τροποποιήσουν τις τιμές των ενσωματωμένων ιδιοτήτων καθώς και των προσαρμοσμένων ιδιοτήτων.

## **Ιδιότητες Εγγράφου στο PowerPoint**

Το Microsoft PowerPoint 2007 επιτρέπει τη διαχείριση των ιδιοτήτων εγγράφου των αρχείων παρουσίασης. Το μόνο που χρειάζεται να κάνετε είναι να κάνετε κλικ στο εικονίδιο Office και στη συνέχεια στο στοιχείο μενού **Prepare | Properties | Advanced Properties** του Microsoft PowerPoint 2007 όπως φαίνεται παρακάτω:

|**Επιλογή στοιχείου μενού Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Μετά την επιλογή του στοιχείου μενού **Advanced Properties**, εμφανίζεται ένας διάλογος που σας επιτρέπει να διαχειριστείτε τις ιδιότητες εγγράφου του αρχείου PowerPoint όπως φαίνεται παρακάτω:

|**Διάλογος Ιδιοτήτων**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Στον παραπάνω **Διάλογο Ιδιοτήτων**, μπορείτε να δείτε ότι υπάρχουν πολλές καρτέλες όπως **General**, **Summary**, **Statistics**, **Contents** και **Custom**. Όλες αυτές οι καρτέλες επιτρέπουν τη διαμόρφωση διαφορετικών ειδών πληροφοριών που σχετίζονται με τα αρχεία PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση των προσαρμοσμένων ιδιοτήτων των αρχείων PowerPoint.

### Εργασία με Ιδιότητες Εγγράφου Χρησιμοποιώντας Aspose.Slides for Node.js via Java

Όπως περιγράψαμε νωρίτερα, το Aspose.Slides for Node.js via Java υποστηρίζει δύο είδη ιδιοτήτων εγγράφου, οι **Built-in** και **Custom**. Έτσι, οι προγραμματιστές μπορούν να προσπελάσουν και τα δύο είδη ιδιοτήτων χρησιμοποιώντας το API του Aspose.Slides for Node.js via Java. Το Aspose.Slides for Node.js via Java παρέχει μια κλάση [DocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties) που αντιπροσωπεύει τις ιδιότητες εγγράφου που σχετίζονται με ένα αρχείο παρουσίασης μέσω της ιδιότητας **Presentation.DocumentProperties**.

Οι προγραμματιστές μπορούν να χρησιμοποιήσουν την ιδιότητα **DocumentProperties** που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation) για να προσπελάσουν τις ιδιότητες εγγράφου των αρχείων παρουσίασης όπως περιγράφεται παρακάτω:

## **Πρόσβαση σε Built-in Ιδιότητες**

Αυτές οι ιδιότητες που εκτίθενται από το αντικείμενο [DocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties) περιλαμβάνουν: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** και **Title**.

```javascript
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει την παρουσίαση
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Δημιουργία αναφοράς στο αντικείμενο IDocumentProperties που σχετίζεται με το Presentation
    var dp = pres.getDocumentProperties();
    // Εμφάνιση των ενσωματωμένων ιδιοτήτων
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Τροποποίηση Built-in Ιδιοτήτων**

Η τροποποίηση των ενσωματωμένων ιδιοτήτων των αρχείων παρουσίασης είναι εξίσου απλή με την πρόσβασή τους. Απλώς εκχωρείτε μια τιμή κειμένου σε οποιαδήποτε επιθυμητή ιδιότητα και η τιμή της ιδιότητας θα τροποποιηθεί. Στο παρακάτω παράδειγμα, έχουμε δείξει πώς μπορούμε να τροποποιήσουμε τις ενσωματωμένες ιδιότητες εγγράφου του αρχείου παρουσίασης χρησιμοποιώντας το Aspose.Slides for Node.js via Java.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Δημιουργία αναφοράς στο αντικείμενο IDocumentProperties που σχετίζεται με το Presentation
    var dp = pres.getDocumentProperties();
    // Ορισμός των ενσωματωμένων ιδιοτήτων
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Αποθήκευση της παρουσίασής σας σε αρχείο
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Αυτό το παράδειγμα τροποποιεί τις ενσωματωμένες ιδιότητες της παρουσίασης, όπως φαίνεται παρακάτω:

|**Ενσωματωμένες ιδιότητες εγγράφου μετά τη τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Εγγράφου**

Το Aspose.Slides for Node.js via Java επιτρέπει επίσης στους προγραμματιστές να προσθέτουν προσαρμοσμένες τιμές για τις ιδιότητες εγγράφου παρουσίασης. Ένα παράδειγμα φαίνεται παρακάτω, το οποίο δείχνει πώς να ορίσετε τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Λήψη ιδιοτήτων εγγράφου
    var dProps = pres.getDocumentProperties();
    // Προσθήκη προσαρμοσμένων ιδιοτήτων
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Λήψη ονόματος ιδιότητας σε συγκεκριμένο δείκτη
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Αφαίρεση επιλεγμένης ιδιότητας
    dProps.removeCustomProperty(getPropertyName);
    // Αποθήκευση παρουσίασης
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Προσαρμοσμένες Ιδιότητες Εγγράφου Προστέθηκαν**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Πρόσβαση και Τροποποίηση Προσαρμοσμένων Ιδιοτήτων**

Το Aspose.Slides for Node.js via Java επιτρέπει επίσης στους προγραμματιστές να προσπελάσουν τις τιμές των προσαρμοσμένων ιδιοτήτων. Ένα παράδειγμα φαίνεται παρακάτω, το οποίο δείχνει πώς μπορείτε να προσπελάσετε και να τροποποιήσετε όλες αυτές τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Δημιουργία αναφοράς στο αντικείμενο DocumentProperties που σχετίζεται με το Presentation
    var dp = pres.getDocumentProperties();
    // Πρόσβαση και τροποποίηση προσαρμοσμένων ιδιοτήτων
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Προβολή ονομάτων και τιμών των προσαρμοσμένων ιδιοτήτων
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Τροποποίηση τιμών των προσαρμοσμένων ιδιοτήτων
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Αποθήκευση της παρουσίασής σας σε αρχείο
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Αυτό το παράδειγμα τροποποιεί τις προσαρμοσμένες ιδιότητες του [PPTX](https://docs.fileformat.com/presentation/pptx/)presentation. Τα παρακάτω σχήματα δείχνουν τις προσαρμοσμένες ιδιότητες της παρουσίασης πριν και μετά τη τροποποίηση:

|**Προσαρμοσμένες Ιδιότητες πριν τη Τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Προσαρμοσμένες Ιδιότητες μετά τη Τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Προηγμένες Ιδιότητες Εγγράφου**

{{% alert color="primary" %}} 

Νέες μέθοδοι [ReadDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) , [UpdateDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) και [WriteBindedPresentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) προστέθηκαν στην κλάση [PresentationInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PresentationInfo) , η λογική του setter της ιδιότητας [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) έχει αλλάξει.

{{% /alert %}} 

Οι δύο νέες μέθοδοι [ReadDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) και [UpdateDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) προστέθηκαν στην κλάση [PresentationInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PresentationInfo) . Παρέχουν γρήγορη πρόσβαση στις ιδιότητες εγγράφου και επιτρέπουν την αλλαγή και ενημέρωση των ιδιοτήτων χωρίς τη φόρτωση ολόκληρης της παρουσίασης.

Το τυπικό σενάριο φόρτωσης των ιδιοτήτων, αλλαγής κάποιας τιμής και ενημέρωσης του εγγράφου μπορεί να υλοποιηθεί με τον ακόλουθο τρόπο:

```javascript
// διαβάστε τις πληροφορίες της παρουσίασης
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// λήψη των τρεχουσών ιδιοτήτων
var props = info.readDocumentProperties();
// ορίστε τις νέες τιμές των πεδίων Συγγραφέας και Τίτλος
props.setAuthor("New Author");
props.setTitle("New Title");
// ενημερώστε την παρουσίαση με νέες τιμές
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Υπάρχει ένας άλλος τρόπος χρήσης των ιδιοτήτων μιας συγκεκριμένης παρουσίασης ως πρότυπο για ενημέρωση ιδιοτήτων σε άλλες παρουσιάσεις:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
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

```javascript
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Μπορεί να δημιουργηθεί ένα νέο πρότυπο από το μηδέν και στη συνέχεια να χρησιμοποιηθεί για την ενημέρωση πολλαπλών παρουσιάσεων:

```javascript
var template = new aspose.slides.DocumentProperties();
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

```javascript
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Ορισμός Γλώσσας Διόρθωσης**

Το Aspose.Slides παρέχει την ιδιότητα LanguageId (εκτεθειμένη από την κλάση PortionFormat) για να σας επιτρέπει να ορίσετε τη γλώσσα διόρθωσης για ένα έγγραφο PowerPoint. Η γλώσσα διόρθωσης είναι η γλώσσα για την οποία ελέγχονται η ορθογραφία και η γραμματική στο PowerPoint.

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε τη γλώσσα διόρθωσης για ένα PowerPoint: xxx Why is LanguageId missing from JavaScript PortionFormat class?

```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// ορίστε το αναγνωριστικό μιας γλώσσας διόρθωσης
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε τη προεπιλεγμένη γλώσσα για ολόκληρη μια παρουσίαση PowerPoint:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Προσθέτει ένα νέο σχήμα ορθογώνιου με κείμενο
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // Ελέγχει τη γλώσσα του πρώτου τμήματος
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ζωντανό Παράδειγμα**

Δοκιμάστε την online εφαρμογή [**Aspose.Slides Metadata**](https://products.aspose.app/slides/el/metadata) για να δείτε πώς να εργάζεστε με τις ιδιότητες εγγράφου μέσω του Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## ***Συχνές Ερωτήσεις**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες αποτελούν αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις ορίσετε ως κενές, εφόσον το επιτρέπει η συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Αν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να προσπελάσω τις ιδιότητες της παρουσίασης χωρίς να φορτώσω ολόκληρη την παρουσίαση;**

Ναι, μπορείτε να προσπελάσετε τις ιδιότητες της παρουσίασης χωρίς να φορτώσετε ολόκληρη την παρουσίαση χρησιμοποιώντας τη μέθοδο `getPresentationInfo` από την κλάση [PresentationFactory](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationfactory/) . Στη συνέχεια, χρησιμοποιήστε τη μέθοδο `readDocumentProperties` που παρέχεται από την κλάση [PresentationInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/) για να διαβάσετε τις ιδιότητες αποδοτικά, εξοικονομώντας μνήμη και βελτιώνοντας την απόδοση.