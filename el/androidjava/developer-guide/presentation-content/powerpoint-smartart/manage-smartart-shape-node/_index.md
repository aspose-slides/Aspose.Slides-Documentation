---
title: Διαχείριση Κόμβων Σχήματος SmartArt σε Παρουσιάσεις στο Android
linktitle: Κόμβος Σχήματος SmartArt
type: docs
weight: 30
url: /el/androidjava/manage-smartart-shape-node/
keywords:
- Κόμβος SmartArt
- Υποκόμβος
- Προσθήκη κόμβου
- Θέση κόμβου
- Πρόσβαση σε κόμβο
- Αφαίρεση κόμβου
- Προσαρμοσμένη θέση
- Βοηθητικός κόμβος
- Μορφή γεμίσματος
- Απόδοση κόμβου
- PowerPoint
- Παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε τους κόμβους σχήματος SmartArt σε PPT και PPTX με την Aspose.Slides για Android. Λάβετε σαφή παραδείγματα κώδικα Java και συμβουλές για τη βελτιστοποίηση των παρουσιάσεών σας."
---
## **Επισκόπηση**

Τα γραφικά SmartArt σε παρουσιάσεις PowerPoint οργανώνονται μέσω κόμβων που περιέχουν κείμενο και ορίζουν τη δομή του διαγράμματος. Η Aspose.Slides επιτρέπει τον προγραμματιστικό χειρισμό αυτών των κόμβων SmartArt: προσθήκη νέων κόμβων και υποκόμβων, εισαγωγή υποκόμβων σε συγκεκριμένη θέση, πρόσβαση σε υπάρχοντες κόμβους και ανάγνωση του κειμένου, του επιπέδου και της θέσης τους.

Αυτό το άρθρο εξηγεί πώς να διαχειριστείτε τους κόμβους σχήματος SmartArt. Δείχνει πώς να αφαιρέσετε κόμβους, να εργαστείτε με υποκόμβους κατά δείκτη ή θέση, να μετατρέψετε έναν βοηθητικό κόμβο σε κανονικό κόμβο, να προσαρμόσετε τη θέση, το μέγεθος και την περιστροφή των σχημάτων κόμβων SmartArt, να ορίσετε μορφές γεμίσματος κόμβων και να δημιουργήσετε μια μικρογραφία για έναν κόμβο SmartArt.

## **Προσθήκη Κόμβου SmartArt**
Η Aspose.Slides for Android μέσω Java παρέχει το πιο απλό API για τη διαχείριση των σχημάτων SmartArt με τον πιο εύκολο τρόπο. Ο παρακάτω κώδικας παραδείγματος θα βοηθήσει στην προσθήκη κόμβου και υποκόμβου μέσα σε σχήμα SmartArt.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Δείκτη της.  
3. Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) και μετατρέψτε (typecast) το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) εφόσον είναι SmartArt.  
5. [Προσθήκη νέου Node](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) στο σχήμα SmartArt [**NodeCollection**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) και ορίστε το κείμενο στο TextFrame.  
6. Τώρα, [Προσθήκη](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) ενός [**Child Node**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) στο πρόσφατα προστεθέν SmartArt Node και ορίστε το κείμενο στο TextFrame.  
7. Αποθηκεύστε την παρουσίαση.

```java
import com.aspose.slides.*;

// Φόρτωση της επιθυμητής παρουσίασης
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Περιήγηση σε όλα τα σχήματα της πρώτης διαφάνειας
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Έλεγχος αν το σχήμα είναι τύπου SmartArt
        if (shape instanceof SmartArt) 
        {
            // Μετατροπή τύπου (typecast) του σχήματος σε SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Προσθήκη νέου κόμβου SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Προσθήκη κειμένου
            TemNode.getTextFrame().setText("Test");
    
            // Προσθήκη νέου υποκόμβου στον γονικό κόμβο. Θα προστεθεί στο τέλος της συλλογής
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Προσθήκη κειμένου
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // Αποθήκευση παρουσίασης
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Προσθήκη Κόμβου SmartArt σε Συγκεκριμένη Θέση**
Στον παρακάτω κώδικα δείχνουμε πώς να προσθέσετε υποκόμβους στα αντίστοιχα κόμβα ενός σχήματος SmartArt σε συγκεκριμένη θέση.

1. Δημιουργήστε μια παρουσία της κλάσης Presentation.  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Δείκτη της.  
3. Προσθέστε σε αυτή τη διαφάνεια σχήμα SmartArt τύπου [**StackedList**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList).  
4. Πρόσβαση στον πρώτο κόμβο του προστεθέντος σχήματος SmartArt.  
5. Τώρα, προσθέστε το [**Child Node**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) για τον επιλεγμένο [**Node**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArtNode) στη θέση 2 και ορίστε το κείμενό του.  
6. Αποθηκεύστε την παρουσίαση.

```java
import com.aspose.slides.*;

// Δημιουργία αντικειμένου παρουσίασης
Presentation pres = new Presentation();
try {
    // Πρόσβαση στη διαφάνεια της παρουσίασης
    ISlide slide = pres.getSlides().get_Item(0);

    // Προσθήκη Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Πρόσβαση στον κόμβο SmartArt στο δείκτη 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Προσθήκη νέου υποκόμβου στη θέση 2 στον γονικό κόμβο
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Προσθήκη κειμένου
    chNode.getTextFrame().setText("Sample Text Added");

    // Αποθήκευση παρουσίασης
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Πρόσβαση σε Κόμβο SmartArt**
Ο παρακάτω κώδικας δείχνει πώς να έχετε πρόσβαση σε κόμβους μέσα σε σχήμα SmartArt. Σημειώστε ότι το LayoutType του SmartArt επιλέγεται όταν το σχήμα προστίθεται· η αλλαγή του αργότερα με **setLayout** ανακατασκευάζει ολόκληρο το διάγραμμα, οπότε οι θέσεις και τα μεγέθη των κόμβων που έχετε ορίσει υπολογίζονται εκ νέου.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Δείκτη της.  
3. Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) εφόσον είναι SmartArt.  
5. Περιηγηθείτε σε όλους τους [**Nodes**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArt#getAllNodes--) μέσα στο σχήμα SmartArt.  
6. Προβάλετε και εμφανίστε πληροφορίες όπως θέση, επίπεδο και κείμενο του κόμβου SmartArt.

```java
import com.aspose.slides.*;

// Δημιουργία αντικειμένου Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Λήψη πρώτης διαφάνειας
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Περιήγηση σε όλα τα σχήματα της πρώτης διαφάνειας
    for (IShape shape : slide.getShapes()) 
    {
        // Έλεγχος αν το σχήμα είναι τύπου SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Μετατροπή τύπου (typecast) του σχήματος σε SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Περιήγηση σε όλους τους κόμβους του SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Πρόσβαση στον κόμβο SmartArt με δείκτη i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // Εκτύπωση παραμέτρων του κόμβου SmartArt
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Πρόσβαση σε Υποκόμβο SmartArt**
Ο παρακάτω κώδικας δείχνει πώς να έχετε πρόσβαση στους υποκόμβους που ανήκουν σε συγκεκριμένους κόμβους ενός σχήματος SmartArt.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Δείκτη της.  
3. Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) εφόσον είναι SmartArt.  
5. Περιηγηθείτε σε όλους τους [**Nodes**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArt#getAllNodes--) μέσα στο σχήμα SmartArt.  
6. Για κάθε επιλεγμένο SmartArt [**Node**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArtNode), περιηγηθείτε σε όλους τους [**Child Nodes**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) του συγκεκριμένου κόμβου.  
7. Προβάλετε και εμφανίστε πληροφορίες όπως θέση, επίπεδο και κείμενο του [**Child Node**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
import com.aspose.slides.*;

// Δημιουργία αντικειμένου Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Λήψη πρώτης διαφάνειας
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Περιήγηση σε κάθε σχήμα της πρώτης διαφάνειας
    for (IShape shape : slide.getShapes()) 
    {
        // Έλεγχος αν το σχήμα είναι τύπου SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Μετατροπή τύπου (typecast) του σχήματος σε SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Περιήγηση σε όλους τους κόμβους του SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Πρόσβαση στον κόμβο SmartArt με δείκτη i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Περιήγηση στα υποκόμβους του κόμβου SmartArt με δείκτη i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Πρόσβαση στον υποκόμβο του κόμβου SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Εκτύπωση των παραμέτρων του υποκόμβου SmartArt
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Πρόσβαση σε Υποκόμβο SmartArt σε Συγκεκριμένη Θέση**
Σε αυτό το παράδειγμα θα μάθουμε πώς να προσπελάσουμε τους υποκόμβους σε ορισμένη θέση που ανήκουν σε αντίστοιχους κόμβους σχήματος SmartArt.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Δείκτη της.  
3. Προσθέστε σχήμα SmartArt τύπου [**StackedList**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList).  
4. Πρόσβαση στο προστιθέμενο σχήμα SmartArt.  
5. Πρόσβαση στον κόμβο με δείκτη 0 του προσπελασμένου σχήματος SmartArt.  
6. Τώρα, προσπελάστε το [**Child Node**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) στη θέση 1 του προσπελασμένου κόμβου SmartArt χρησιμοποιώντας τη μέθοδο **get_Item()**.  
7. Προβάλετε και εμφανίστε πληροφορίες όπως θέση, επίπεδο και κείμενο του [**Child Node**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
import com.aspose.slides.*;

// Δημιουργία παρουσίασης
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Προσθήκη σχήματος SmartArt στην πρώτη διαφάνεια
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Πρόσβαση στον κόμβο SmartArt με δείκτη 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Πρόσβαση στον υποκόμβο στη θέση 1 του γονικού κόμβου
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Εκτύπωση των παραμέτρων του υποκόμβου SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αφαίρεση Κόμβου SmartArt**
Σε αυτό το παράδειγμα θα μάθουμε πώς να αφαιρέσουμε τους κόμβους μέσα σε σχήμα SmartArt.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Δείκτη της.  
3. Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) εφόσον είναι SmartArt.  
5. Ελέγξτε αν το [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) περιέχει περισσότερους από 0 κόμβους.  
6. Επιλέξτε τον κόμβο SmartArt που θα διαγραφεί.  
7. Τώρα, αφαιρέστε τον επιλεγμένο κόμβο χρησιμοποιώντας τη μέθοδο [**RemoveNode**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).  
8. Αποθηκεύστε την παρουσίαση.

```java
import com.aspose.slides.*;

// Φόρτωση της επιλεγμένης παρουσίασης
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Περιήγηση σε όλα τα σχήματα της πρώτης διαφάνειας
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Έλεγχος αν το σχήμα είναι τύπου SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Μετατροπή τύπου (typecast) του σχήματος σε SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Πρόσβαση στον κόμβο SmartArt με δείκτη 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Αφαίρεση του επιλεγμένου κόμβου
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // Αποθήκευση παρουσίασης
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αφαίρεση Κόμβου SmartArt από Συγκεκριμένη Θέση**
Σε αυτό το παράδειγμα θα μάθουμε πώς να αφαιρέσουμε κόμβους μέσα σε σχήμα SmartArt σε συγκεκριμένη θέση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Δείκτη της.  
3. Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) εφόσον είναι SmartArt.  
5. Επιλέξτε τον κόμβο σχήματος SmartArt με δείκτη 0.  
6. Τώρα, ελέγξτε αν ο επιλεγμένος κόμβος SmartArt έχει περισσότερους από 2 υποκόμβους.  
7. Αφαιρέστε τώρα τον κόμβο στη **Θέση 1** χρησιμοποιώντας τη μέθοδο [**RemoveNode**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).  
8. Αποθηκεύστε την παρουσίαση.

```java
import com.aspose.slides.*;

// Φόρτωση της επιλεγμένης παρουσίασης
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Περιήγηση σε όλα τα σχήματα της πρώτης διαφάνειας
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Έλεγχος αν το σχήμα είναι τύπου SmartArt
        if (shape instanceof SmartArt) 
        {
            // Μετατροπή τύπου (typecast) του σχήματος σε SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Πρόσβαση στον κόμβο SmartArt με δείκτη 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Αφαίρεση του υποκόμβου στη θέση 1
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // Αποθήκευση παρουσίασης
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Προσαρμοσμένης Θέσης για Υποκόμβο σε Αντικείμενο SmartArt**
Τώρα η Aspose.Slides for Android μέσω Java υποστηρίζει τον ορισμό ιδιοτήτων [SmartArtShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape#setX-float-) και [Y](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape#setY-float-). Το παρακάτω απόσπασμα κώδικα δείχνει πώς να ορίσετε προσαρμοσμένη θέση, μέγεθος και περιστροφή για SmartArtShape· σημειώστε ότι η προσθήκη νέων κόμβων προκαλεί εκ νέου υπολογισμό θέσεων και μεγεθών όλων των κόμβων. Με τις προσαρμοσμένες ρυθμίσεις θέσης, ο χρήστης μπορεί να ορίσει τους κόμβους σύμφωνα με τις απαιτήσεις.

```java
import com.aspose.slides.*;

// Δημιουργία αντικειμένου Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Μετακίνηση σχήματος SmartArt σε νέα θέση
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Αλλαγή πλάτους σχήματος SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Αλλαγή ύψους σχήματος SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Αλλαγή περιστροφής σχήματος SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Έλεγχος Βοηθητικού Κόμβου**
{{% alert color="info" %}} 

Σε αυτό το άρθρο θα διερευνήσουμε περαιτέρω τις δυνατότητες των σχημάτων SmartArt που προστίθενται σε διαφάνειες παρουσίασης προγραμματιστικά με τη χρήση Aspose.Slides for Android μέσω Java.

{{% /alert %}} 

Θα χρησιμοποιήσουμε το παρακάτω σχήμα SmartArt ως πηγή για την έρευνά μας σε διαφορετικές ενότητες του άρθρου.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Σχήμα: Πηγή SmartArt σε διαφάνεια**|

Στον παρακάτω κώδικα θα εξετάσουμε πώς να εντοπίσουμε **Assistant Nodes** στη συλλογή κόμβων SmartArt και να τα αλλάξουμε.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Δείκτη της.  
3. Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) εφόσον είναι SmartArt.  
5. Περιηγηθείτε σε όλους τους κόμβους μέσα στο σχήμα SmartArt και ελέγξτε αν είναι [**Assistant Nodes**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArtNode#isAssistant--).  
6. Αλλάξτε την κατάσταση του Assistant Node σε κανονικό κόμβο.  
7. Αποθηκεύστε την παρουσίαση.

```java
import com.aspose.slides.*;

// Creating a presentation instance
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Traverse through every shape inside first slide
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Check if shape is of SmartArt type
        if (shape instanceof ISmartArt) 
        {
            // Typecast shape to SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Traversing through all nodes of SmartArt shape
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Check if node is Assistant node
                if (node.isAssistant()) 
                {
                    // Setting Assistant node to false and making it normal node
                    node.setAssistant(false);
                }
            }
        }
    }
    
    // Save Presentation
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Σχήμα: Assistant Nodes Αλλαγμένα σε SmartArt σχήμα**|

## **Ορισμός Μορφής Γέματος για Κόμβο**
Η Aspose.Slides for Android μέσω Java καθιστά δυνατό το πρόσθετο σχήμα SmartArt και τον καθορισμό της μορφής γέματος. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να προσπελάσετε σχήματα SmartArt και να ορίσετε τη μορφή γέματος τους χρησιμοποιώντας Aspose.Slides for Android μέσω Java.

Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).  
2. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της.  
3. Προσθέστε σχήμα [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) ορίζοντας το [**LayoutType**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).  
4. Ορίστε το [**FillFormat**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape#getFillFormat--) για τους κόμβους του σχήματος SmartArt.  
5. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργία παρουσίασης
Presentation pres = new Presentation();
try {
    // Πρόσβαση στη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Προσθήκη σχήματος SmartArt και κόμβων
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Ορισμός χρώματος γεμίσματος του κόμβου
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // Αποθήκευση παρουσίασης
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Δημιουργία Μικρογραφίας Κόμβου SmartArt**
Οι προγραμματιστές μπορούν να δημιουργήσουν μια μικρογραφία ενός κόμβου SmartArt ακολουθώντας τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).  
2. [Προσθήκη SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).  
3. Αποκτήστε την αναφορά ενός κόμβου χρησιμοποιώντας το Δείκτη του.  
4. Λάβετε την εικόνα μικρογραφίας.  
5. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.

```java
import com.aspose.slides.*;

// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Προσθήκη SmartArt
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Απόκτηση της αναφοράς ενός κόμβου χρησιμοποιώντας το Δείκτη του
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Λήψη μικρογραφίας
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Αποθήκευση μικρογραφίας
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

### Υποστηρίζεται η κίνηση SmartArt;

Ναι. Το SmartArt αντιμετωπίζεται ως κανονικό σχήμα, ώστε μπορείτε να [εφαρμόσετε τυπικές κινήσεις](/slides/el/androidjava/shape-animation/) (εισόδους, εξόδους, έμφαση, διαδρομές κίνησης) και να προσαρμόσετε τον χρονοδιάγραμμα. Μπορείτε επίσης να κινήσετε σχήματα μέσα σε κόμβους SmartArt όταν χρειάζεται.

### Πώς μπορώ να βρω αξιόπιστα ένα συγκεκριμένο SmartArt σε μια διαφάνεια αν το εσωτερικό του ID είναι άγνωστο;

Αναθέστε και αναζητήστε με βάση το [εναλλακτικό κείμενο](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#getAlternativeText--). Ορίζοντας ένα χαρακτηριστικό AltText στο SmartArt, μπορείτε να το εντοπίσετε προγραμματιστικά χωρίς να βασίζεστε σε εσωτερικά αναγνωριστικά.

### Θα διατηρηθεί η εμφάνιση του SmartArt κατά τη μετατροπή της παρουσίασης σε PDF;

Ναι. Η Aspose.Slides αποδίδει το SmartArt με υψηλή οπτική πιστότητα κατά την [εξαγωγή PDF](/slides/el/androidjava/convert-powerpoint-to-pdf/), διατηρώντας τη διάταξη, τα χρώματα και τα εφέ.

### Μπορώ να εξάγω εικόνα ολόκληρου του SmartArt (για προεπισκοπήσεις ή εκθέσεις);

Ναι. Μπορείτε να αποδώσετε ένα σχήμα SmartArt σε [μορφές raster](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) ή σε [SVG](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) για κλιμακώσιμη διανυσματική έξοδο, καθιστώντας το κατάλληλο για μικρογραφίες, εκθέσεις ή χρήση στον ιστό.