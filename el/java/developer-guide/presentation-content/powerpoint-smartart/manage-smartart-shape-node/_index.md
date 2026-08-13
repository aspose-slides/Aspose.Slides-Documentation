---
title: Διαχείριση Κόμβων Σχήματος SmartArt σε Παρουσιάσεις με Java
linktitle: Κόμβος Σχήματος SmartArt
type: docs
weight: 30
url: /el/java/manage-smartart-shape-node/
keywords:
- Κόμβος SmartArt
- Υπο‑κόμβος
- Προσθήκη κόμβου
- Θέση κόμβου
- Πρόσβαση σε κόμβο
- Αφαίρεση κόμβου
- Προσαρμοσμένη θέση
- Κόμβος βοηθού
- Μορφή γεμίσματος
- Απόδοση κόμβου
- PowerPoint
- Παρουσίαση
- Java
- Aspose.Slides
description: "Διαχειριστείτε κόμβους σχήματος SmartArt σε PPT και PPTX με το Aspose.Slides for Java. Λάβετε σαφή παραδείγματα κώδικα και συμβουλές για την οργάνωση των παρουσιάσεών σας."
---
## **Επισκόπηση**

Τα γραφικά SmartArt σε παρουσιάσεις PowerPoint οργανώνονται μέσω κόμβων που περιέχουν κείμενο και ορίζουν τη δομή του διαγράμματος. Το Aspose.Slides σας επιτρέπει να εργάζεστε με αυτούς τους κόμβους SmartArt προγραμματιστικά: να προσθέτετε νέους κόμβους και υπο-κόμβους, να εισάγετε υπο-κόμβους σε συγκεκριμένη θέση, να προσπελάζετε υπάρχοντες κόμβους και να διαβάζετε το κείμενό τους, το επίπεδο και τη θέση.

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε τους κόμβους σχήματος SmartArt. Δείχνει πώς να αφαιρείτε κόμβους, να εργάζεστε με υπο-κόμβους με βάση το δείκτη ή τη θέση, να μετατρέπετε έναν κόμβο βοηθού σε κανονικό κόμβο, να ρυθμίζετε τη θέση, το μέγεθος και την περιστροφή των σ shapes SmartArt, να ορίζετε μορφές γεμίσματος κόμβων και να δημιουργείτε μια μικρογραφία για έναν υπο-κόμβο SmartArt.

## **Προσθήκη Κόμβου SmartArt**
Το Aspose.Slides for Java παρέχει το πιο απλό API για τη διαχείριση των σχημάτων SmartArt με τον ευκολότερο τρόπο. Ο παρακάτω κώδικας δείγματος θα σας βοηθήσει να προσθέσετε κόμβο και υπο‑κόμβο μέσα σε σχήμα SmartArt.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
3. Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) εάν είναι SmartArt.  
5. [Add a new Node](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) στο σχήμα SmartArt [**NodeCollection**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt#getAllNodes--) και ορίστε το κείμενο στο TextFrame.  
6. Τώρα, [Add](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) ένα [**Child Node**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNode#getChildNodes--) στον πρόσφατα προστιθέμενο κόμβο [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArt) και ορίστε το κείμενο στο TextFrame.  
7. Αποθηκεύστε την Παρουσίαση.

```java
import com.aspose.slides.*;

// Φορτώστε την επιθυμητή παρουσίαση
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Ελέγξτε αν το σχήμα είναι τύπου SmartArt
        if (shape instanceof SmartArt) 
        {
            // Μετατρέψτε το σχήμα σε SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Προσθήκη νέου κόμβου SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Προσθήκη κειμένου
            TemNode.getTextFrame().setText("Test");
    
            // Προσθήκη νέου υπο‑κόμβου στον γονικό κόμβο. Θα προστεθεί στο τέλος της συλλογής
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
Στον παρακάτω κώδικα δείγματος εξηγούμε πώς να προσθέσετε υπο‑κόμβους που ανήκουν σε αντίστοιχους κόμβους σχήματος SmartArt σε συγκεκριμένη θέση.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
3. Προσθέστε ένα σχήμα [**StackedList**](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArtLayoutType#StackedList) τύπου SmartArt στη διαφάνεια.  
4. Προσπελάστε τον πρώτο κόμβο στο προστεθέν σχήμα SmartArt.  
5. Τώρα, προσθέστε το [**Child Node**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNode#getChildNodes--) για τον επιλεγμένο [**Node**](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArtNode) στη θέση 2 και ορίστε το κείμενό του.  
6. Αποθηκεύστε την Παρουσίαση.

```java
import com.aspose.slides.*;

// Δημιουργία παρουσίασης
Presentation pres = new Presentation();
try {
    // Πρόσβαση στη διαφάνεια παρουσίασης
    ISlide slide = pres.getSlides().get_Item(0);

    // Προσθήκη Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Πρόσβαση στον κόμβο SmartArt με δείκτη 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Προσθήκη νέου υπο‑κόμβου στη θέση 2 στον γονικό κόμβο
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Προσθήκη κειμένου
    chNode.getTextFrame().setText("Sample Text Added");

    // Αποθήκευση παρουσίασης
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Προσπέλαση Κόμβου SmartArt**
Ο παρακάτω κώδικας δείγματος θα σας βοηθήσει να προσπελάσετε κόμβους μέσα σε σχήμα SmartArt. Σημειώστε ότι δεν μπορείτε να αλλάξετε το LayoutType του SmartArt καθώς είναι μόνο για ανάγνωση και ορίζεται μόνο όταν προστίθεται το σχήμα.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
3. Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) εάν είναι SmartArt.  
5. Περιηγηθείτε σε όλους τους [**Nodes**](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArt#getAllNodes--) μέσα στο σχήμα SmartArt.  
6. Προσπελάστε και εμφανίστε πληροφορίες όπως η θέση του κόμβου SmartArt, το επίπεδο και το κείμενο.

```java
import com.aspose.slides.*;

// Δημιουργία αντικειμένου Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Λήψη της πρώτης διαφάνειας
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Περιήγηση σε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    for (IShape shape : slide.getShapes()) 
    {
        // Έλεγχος αν το σχήμα είναι τύπου SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Μετατροπή τύπου σχήματος σε SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Περιήγηση σε όλους τους κόμβους του SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Πρόσβαση στον κόμβο SmartArt με δείκτη i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // Εκτύπωση των παραμέτρων του κόμβου SmartArt
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Προσπέλαση Υπο‑Κόμβου SmartArt**
Ο παρακάτω κώδικας δείγματος θα σας βοηθήσει να προσπελάσετε τους υπο‑κόμβους που ανήκουν σε αντίστοιχους κόμβους σχήματος SmartArt.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
3. Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) εάν είναι SmartArt.  
5. Περιηγηθείτε σε όλους τους [**Nodes**](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArt#getAllNodes--) μέσα στο σχήμα SmartArt.  
6. Για κάθε επιλεγμένο [**Node**](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArtNode) του SmartArt, περιηγηθείτε σε όλους τους [**Child Nodes**](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArtNode#getChildNodes--) του συγκεκριμένου κόμβου.  
7. Προσπελάστε και εμφανίστε πληροφορίες όπως η θέση, το επίπεδο και το κείμενο του [**Child Node**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
import com.aspose.slides.*;

// Δημιουργία αντικειμένου Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Λήψη της πρώτης διαφάνειας
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Περιήγηση σε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    for (IShape shape : slide.getShapes()) 
    {
        // Έλεγχος αν το σχήμα είναι τύπου SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Μετατροπή τύπου σχήματος σε SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Περιήγηση σε όλους τους κόμβους του SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Πρόσβαση στον κόμβο SmartArt με δείκτη i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Περιήγηση στους υπο‑κόμβους του κόμβου SmartArt με δείκτη i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Πρόσβαση στον υπο‑κόμβο του κόμβου SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Εκτύπωση των παραμέτρων του υπο‑κόμβου SmartArt
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Προσπέλαση Υπο‑Κόμβου SmartArt σε Συγκεκριμένη Θέση**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να προσπελάσουμε τους υπο‑κόμβους σε συγκεκριμένη θέση που ανήκουν σε αντίστοιχους κόμβους σχήματος SmartArt.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation).  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
3. Προσθέστε ένα σχήμα τύπου [**StackedList**](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArtLayoutType#StackedList) SmartArt.  
4. Προσπελάστε το προστεθέν σχήμα SmartArt.  
5. Προσπελάστε τον κόμβο με δείκτη 0 του σχήματος SmartArt.  
6. Τώρα, προσπελάστε το [**Child Node**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNode#getChildNodes--) στη θέση 1 του κόμβου SmartArt χρησιμοποιώντας τη μέθοδο **get_Item()**.  
7. Προσπελάστε και εμφανίστε πληροφορίες όπως η θέση, το επίπεδο και το κείμενο του [**Child Node**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
import com.aspose.slides.*;

// Δημιουργία παρουσίασης
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Προσθήκη του σχήματος SmartArt στην πρώτη διαφάνεια
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Πρόσβαση στον κόμβο SmartArt με δείκτη 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Πρόσβαση στον υπο‑κόμβο στη θέση 1 στον γονικό κόμβο
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Εκτύπωση των παραμέτρων του υπο‑κόμβου SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αφαίρεση Κόμβου SmartArt**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να αφαιρέσουμε κόμβους μέσα σε σχήμα SmartArt.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
3. Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) εάν είναι SmartArt.  
5. Ελέγξτε αν το [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) διαθέτει περισσότερους από 0 κόμβους.  
6. Επιλέξτε τον κόμβο SmartArt που θα διαγραφεί.  
7. Τώρα, αφαιρέστε τον επιλεγμένο κόμβο χρησιμοποιώντας τη μέθοδο [**RemoveNode**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).  
8. Αποθηκεύστε την Παρουσίαση.

```java
import com.aspose.slides.*;

// Φορτώστε την επιθυμητή παρουσίαση
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Ελέγξτε αν το σχήμα είναι τύπου SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Μετατρέψτε το σχήμα σε SmartArt
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
Σε αυτό το παράδειγμα, θα μάθουμε πώς να αφαιρέσουμε κόμβους μέσα σε σχήμα SmartArt σε συγκεκριμένη θέση.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
3. Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) εάν είναι SmartArt.  
5. Επιλέξτε το κόμβο του σχήματος SmartArt με δείκτη 0.  
6. Τώρα, ελέγξτε αν ο επιλεγμένος κόμβος SmartArt έχει περισσότερους από 2 υπο‑κόμβους.  
7. Στη συνέχεια, αφαιρέστε τον κόμβο στη **Position 1** χρησιμοποιώντας τη μέθοδο [**RemoveNode**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).  
8. Αποθηκεύστε την Παρουσίαση.

```java
import com.aspose.slides.*;

// Φορτώστε την επιθυμητή παρουσίαση
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Ελέγξτε αν το σχήμα είναι τύπου SmartArt
        if (shape instanceof SmartArt) 
        {
            // Μετατρέψτε το σχήμα σε SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Πρόσβαση στον κόμβο SmartArt με δείκτη 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Αφαίρεση του υπο-κόμβου στη θέση 1
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

## **Ορισμός Προσαρμοσμένης Θέσης για Υπο‑Κόμβο σε Αντικείμενο SmartArt**
Τώρα το Aspose.Slides for Java υποστηρίζει τον ορισμό των ιδιοτήτων [SmartArtShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShape#setX-float-) και [Y](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShape#setY-float-). Το παρακάτω απόσπασμα κώδικα δείχνει πώς να ορίσετε προσαρμοσμένη θέση, μέγεθος και περιστροφή του SmartArtShape· παρακαλούμε σημειώστε ότι η προσθήκη νέων κόμβων προκαλεί επανυπολογισμό των θέσεων και των μεγεθών όλων των κόμβων. Με τις προσαρμοσμένες ρυθμίσεις θέσης, ο χρήστης μπορεί να τοποθετήσει τους κόμβους σύμφωνα με τις απαιτήσεις.

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

## **Έλεγχος Κόμβου Βοηθού**
{{% alert color="info" %}} 

Σε αυτό το άρθρο θα διερευνήσουμε περαιτέρω τις δυνατότητες των σχημάτων SmartArt που προστίθενται στις διαφάνειες παρουσίασης προγραμματιστικά χρησιμοποιώντας το Aspose.Slides for Java.

{{% /alert %}} 

Θα χρησιμοποιήσουμε το παρακάτω σχήμα SmartArt ως πηγή για την έρευνά μας σε διαφορετικά τμήματα του άρθρου.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Σχήμα: Πηγαίο σχήμα SmartArt στη διαφάνεια**|

Στον παρακάτω κώδικα δείγματος θα ερευνήσουμε πώς να εντοπίσουμε **Assistant Nodes** στη συλλογή κόμβων SmartArt και να τα αλλάξουμε.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.  
2. Αποκτήστε την αναφορά της δεύτερης διαφάνειας χρησιμοποιώντας το Index της.  
3. Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) εάν είναι SmartArt.  
5. Περιηγηθείτε σε όλους τους κόμβους μέσα στο σχήμα SmartArt και ελέγξτε αν είναι [**Assistant Nodes**](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArtNode#isAssistant--).  
6. Αλλάξτε την κατάσταση του Assistant Node σε κανονικό κόμβο.  
7. Αποθηκεύστε την Παρουσίαση.

```java
import com.aspose.slides.*;

// Δημιουργία παρουσίασης
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Περιήγηση σε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Έλεγχος αν το σχήμα είναι τύπου SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Μετατροπή τύπου σχήματος σε SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Περιήγηση σε όλους τους κόμβους του σχήματος SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Έλεγχος αν ο κόμβος είναι κόμβος βοηθού
                if (node.isAssistant()) 
                {
                    // Ορισμός του κόμβου βοηθού σε false και μετατροπή του σε κανονικό κόμβο
                    node.setAssistant(false);
                }
            }
        }
    }
    
    // Αποθήκευση παρουσίασης
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Σχήμα: Assistant Nodes Αλλαγμένα σε σχήμα SmartArt στη διαφάνεια**|

## **Ορισμός Μορφής Γεμίσματος Κόμβου**
Το Aspose.Slides for Java επιτρέπει την προσθήκη προσαρμοσμένων σχημάτων SmartArt και τον ορισμό της μορφής γεμίσματος τους. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να προσπελάσετε σχήματα SmartArt και να ορίσετε τη μορφή γεμίσματος τους χρησιμοποιώντας το Aspose.Slides for Java.

Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation).  
2. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας τον δείκτη της.  
3. Προσθέστε ένα σχήμα [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) ορίζοντας το [**LayoutType**](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).  
4. Ορίστε το [**FillFormat**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShape#getFillFormat--) για τους κόμβους του σχήματος SmartArt.  
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
    
    // Ορισμός χρώματος γεμίσματος κόμβου
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

## **Δημιουργία Μικρογραφίας Υπο‑Κόμβου SmartArt**
Οι προγραμματιστές μπορούν να δημιουργήσουν μικρογραφία του υπο‑κόμβου ενός SmartArt ακολουθώντας τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation).  
2. [Add SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNodeCollection#addNode--).  
3. Αποκτήστε την αναφορά ενός κόμβου χρησιμοποιώντας το Index του.  
4. Λάβετε την εικόνα μικρογραφίας.  
5. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.

```java
import com.aspose.slides.*;

// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το αρχείο PPTX 
Presentation pres = new Presentation();
try {
    // Προσθήκη SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Απόκτηση της αναφοράς ενός κόμβου χρησιμοποιώντας το Index του  
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

Ναι. Το SmartArt θεωρείται κανονικό σχήμα, ώστε να μπορείτε να [εφαρμόσετε τυπικές κινήσεις](/slides/el/java/shape-animation/) (εισόδους, εξόδους, τονισμούς, διαδρομές κίνησης) και να ρυθμίσετε τον χρόνο. Μπορείτε επίσης να κινήσετε σχήματα μέσα σε κόμβους SmartArt όταν είναι απαραίτητο.

### Πώς μπορώ αξιόπιστα να εντοπίσω ένα συγκεκριμένο SmartArt σε μια διαφάνεια εάν το εσωτερικό του ID είναι άγνωστο;

Αναθέστε και αναζητήστε με βάση το [εναλλακτικό κείμενο](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getAlternativeText--). Ορίζοντας μια χαρακτηριστική AltText στο SmartArt, μπορείτε να το βρείτε προγραμματιστικά χωρίς να βασίζεστε σε εσωτερικά αναγνωριστικά.

### Θα διατηρηθεί η εμφάνιση του SmartArt κατά τη μετατροπή της παρουσίασης σε PDF;

Ναι. Το Aspose.Slides αποδίδει το SmartArt με υψηλή οπτική πιστότητα κατά την [εξαγωγή σε PDF](/slides/el/java/convert-powerpoint-to-pdf/), διατηρώντας τη διάταξη, τα χρώματα και τα εφέ.

### Μπορώ να εξάγω εικόνα του ολόκληρου SmartArt (για προεπισκοπήσεις ή αναφορές);

Ναι. Μπορείτε να αποδώσετε ένα σχήμα SmartArt σε [αρθριακές μορφές](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getImage-int-float-float-) ή σε [SVG](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) για κλιμακώσιμο διανυσματικό αποτέλεσμα, καθιστώντας το κατάλληλο για μικρογραφίες, αναφορές ή χρήση στο web.