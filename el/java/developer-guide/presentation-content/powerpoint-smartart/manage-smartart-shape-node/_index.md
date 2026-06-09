---
title: Διαχείριση Κόμβων Σχήματος SmartArt σε Παρουσιάσεις με Java
linktitle: Κόμβος Σχήματος SmartArt
type: docs
weight: 30
url: /el/java/manage-smartart-shape-node/
keywords:
- Κόμβος SmartArt
- Υποκόμβος
- Προσθήκη κόμβου
- Θέση κόμβου
- Πρόσβαση σε κόμβο
- Αφαίρεση κόμβου
- Προσαρμοσμένη θέση
- Κόμβος βοηθός
- Μορφή γεμίσματος
- Απόδοση κόμβου
- PowerPoint
- Παρουσίαση
- Java
- Aspose.Slides
description: "Διαχειριστείτε τους κόμβους σχήματος SmartArt σε αρχεία PPT και PPTX με το Aspose.Slides for Java. Λάβετε σαφή παραδείγματα κώδικα και συμβουλές για την βελτιστοποίηση των παρουσιάσεων σας."
---
## **Επισκόπηση**

Οι γραφικές παραστάσεις SmartArt σε παρουσιάσεις PowerPoint οργανώνονται μέσω κόμβων που περιέχουν κείμενο και καθορίζουν τη δομή του διαγράμματος. Το Aspose.Slides σάς επιτρέπει να εργάζεστε με αυτούς τους κόμβους SmartArt προγραμματιστικά: να προσθέτετε νέους κόμβους και υποκόμβους, να εισάγετε υποκόμβους σε συγκεκριμένη θέση, να αποκτάτε πρόσβαση σε υπάρχοντες κόμβους και να διαβάζετε το κείμενο, το επίπεδο και τη θέση τους.

Αυτό το άρθρο εξηγεί πώς να διαχειριστείτε τους κόμβους σχήματος SmartArt. Δείχνει πώς να αφαιρέσετε κόμβους, να εργαστείτε με υποκόμβους κατά δείκτη ή θέση, να μετατρέψετε έναν κόμβο βοηθό σε κανονικό κόμβο, να προσαρμόσετε τη θέση, το μέγεθος και την περιστροφή των σχημάτων κόμβων SmartArt, να ορίσετε μορφές γεμίσματος κόμβων και να δημιουργήσετε μια μικρογραφία για έναν υποκόμβο SmartArt.

## **Προσθήκη κόμβου SmartArt**
Το Aspose.Slides for Java παρέχει το πιο απλό API για τη διαχείριση των σχημάτων SmartArt με τον πιο εύκολο τρόπο. Ο παρακάτω κώδικας παραδείγματος θα βοηθήσει στην προσθήκη κόμβου και υποκόμβου μέσα σε σχήμα SmartArt.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
3. Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) και κάντε μετατροπή τύπου (typecast) του επιλεγμένου σχήματος σε [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) εάν είναι SmartArt.
5. [Προσθέστε έναν νέο Κόμβο](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) στο σχήμα SmartArt [**NodeCollection**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt#getAllNodes--) και ορίστε το κείμενο στο TextFrame.
6. Τώρα, [Προσθέστε](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) ένα [**Child Node**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNode#getChildNodes--) σε πρόσφατα προστιθέμενο [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) Node και ορίστε το κείμενο στο TextFrame
7. Αποθηκεύστε την Παρουσίαση.

```java
// Φορτώστε την επιθυμητή παρουσίαση
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Ελέγξτε αν το σχήμα είναι τύπου SmartArt
        if (shape instanceof SmartArt) 
        {
            // Μετατρέψτε τύπο σχήματος σε SmartArt
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

## **Προσθήκη κόμβου SmartArt σε συγκεκριμένη θέση**
Στον παρακάτω κώδικα παραδείγματος εξηγούμε πώς να προσθέσετε τους υποκόμβους που ανήκουν στους αντίστοιχους κόμβους του σχήματος SmartArt σε συγκεκριμένη θέση.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
3. Προσθέστε ένα σχήμα [**StackedList**](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArtLayoutType#StackedList) τύπου [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArt) στη διαφάνεια που αποκτήσατε.
4. Αποκτήστε πρόσβαση στον πρώτο κόμβο στο προστιθέμενο σχήμα SmartArt
5. Τώρα, προσθέστε το [**Child Node**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNode#getChildNodes--) για τον επιλεγμένο [**Node**](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArtNode) στη θέση 2 και ορίστε το κείμενό του.
6. Αποθηκεύστε την Παρουσίαση

```java
// Δημιουργία στιγμιοτύπου παρουσίασης
Presentation pres = new Presentation();
try {
    // Πρόσβαση στη διαφάνεια της παρουσίασης
    ISlide slide = pres.getSlides().get_Item(0);

    // Προσθήκη Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Πρόσβαση στον κόμβο SmartArt με δείκτη 0
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

## **Πρόσβαση σε κόμβο SmartArt**
Ο παρακάτω κώδικας παραδείγματος θα βοηθήσει στην πρόσβαση στους κόμβους μέσα σε σχήμα SmartArt. Παρακαλούμε σημειώστε ότι δεν μπορείτε να αλλάξετε το LayoutType του SmartArt, καθώς είναι μόνο για ανάγνωση και ορίζεται μόνο όταν το σχήμα SmartArt προστίθεται.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
3. Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) και κάντε μετατροπή τύπου (typecast) του επιλεγμένου σ.shape σε [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) εάν είναι SmartArt.
5. Περιηγηθείτε σε όλους τους [**Nodes**](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArt#getAllNodes--) μέσα στο σχήμα SmartArt.
6. Αποκτήστε πρόσβαση και εμφανίστε πληροφορίες όπως η θέση, το επίπεδο και το κείμενο του κόμβου SmartArt.

```java
// Δημιουργία αντικειμένου κλάσης Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Λήψη πρώτης διαφάνειας
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Περιήγηση σε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    for (IShape shape : slide.getShapes()) 
    {
        // Έλεγχος αν το σχήμα είναι τύπου SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Μετατροπή τύπου (typecast) του σχήματος σε SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Περιήγηση σε όλους τους κόμβους μέσα στο SmartArt
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

## **Πρόσβαση σε υποκόμβο SmartArt**
Ο παρακάτω κώδικας παραδείγματος θα βοηθήσει στην πρόσβαση στους υποκόμβους που ανήκουν στους αντίστοιχους κόμβους του σχήματος SmartArt.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
3. Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) και κάντε μετατροπή τύπου (typecast) του επιλεγμένου σ.shape σε [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) εάν είναι SmartArt.
5. Περιηγηθείτε σε όλους τους [**Nodes**](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArt#getAllNodes--) μέσα στο σχήμα SmartArt.
6. Για κάθε επιλεγμένο σχήμα SmartArt [**Node**](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArtNode), περιηγηθείτε σε όλους τους [**Child Nodes**](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArtNode#getChildNodes--) μέσα στον συγκεκριμένο κόμβο.
7. Αποκτήστε πρόσβαση και εμφανίστε πληροφορίες όπως η θέση, το επίπεδο και το κείμενο του [**Child Node**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
// Δημιουργία αντικειμένου κλάσης Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Λήψη πρώτης διαφάνειας
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Περιήγηση σε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    for (IShape shape : slide.getShapes()) 
    {
        // Έλεγχος αν το σχήμα είναι τύπου SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Μετατροπή τύπου (typecast) του σχήματος σε SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Περιήγηση σε όλους τους κόμβους μέσα στο SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Πρόσβαση στον κόμβο SmartArt με δείκτη i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Περιήγηση στους υποκόμβους του κόμβου SmartArt με δείκτη i
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

## **Πρόσβαση σε υποκόμβο SmartArt σε συγκεκριμένη θέση**
Στον παρακάτω κώδικα παραδείγματος θα ερευνήσουμε πώς να αποκτήσουμε πρόσβαση στους υποκόμβους σε κάποια συγκεκριμένη θέση που ανήκουν στους αντίστοιχους κόμβους του σχήματος SmartArt.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) class.
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
3. Προσθέστε ένα σχήμα [**StackedList**](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArtLayoutType#StackedList) τύπου SmartArt.
4. Αποκτήστε πρόσβαση στο προστιθέμενο σχήμα SmartArt.
5. Αποκτήστε πρόσβαση στον κόμβο με δείκτη 0 για το σχήμα SmartArt που έχει προσπελαστεί.
6. Τώρα, αποκτήστε πρόσβαση στο [**Child Node**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNode#getChildNodes--) στη θέση 1 για τον πρόσβαση σχήμα SmartArt node χρησιμοποιώντας τη μέθοδο **get_Item()**.
7. Αποκτήστε πρόσβαση και εμφανίστε πληροφορίες όπως η θέση, το επίπεδο και το κείμενο του [**Child Node**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
// Δημιουργία παρουσίασης
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Προσθήκη του σχήματος SmartArt στην πρώτη διαφάνεια
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Πρόσβαση στον κόμβο SmartArt με δείκτη 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Πρόσβαση στον υποκόμβο στη θέση 1 στον γονικό κόμβο
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Εκτύπωση των παραμέτρων του υποκόμβου SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αφαίρεση κόμβου SmartArt**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να αφαιρέσουμε τους κόμβους μέσα σε σχήμα SmartArt.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
3. Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) και κάντε μετατροπή τύπου (typecast) του επιλεγμένου σ.shape σε [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) εάν είναι SmartArt.
5. Ελέγξτε αν το [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) έχει περισσότερους από 0 κόμβους.
6. Επιλέξτε τον κόμβο SmartArt που θα διαγραφεί.
7. Τώρα, αφαιρέστε τον επιλεγμένο κόμβο χρησιμοποιώντας τη μέθοδο [**RemoveNode**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).
8. Αποθηκεύστε την Παρουσίαση.

```java
// Φορτώστε την επιθυμητή παρουσίαση
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Περιήγηση σε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Έλεγχος αν το σχήμα είναι τύπου SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Μετατροπή τύπου σχήματος σε SmartArt
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

## **Αφαίρεση κόμβου SmartArt από συγκεκριμένη θέση**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να αφαιρέσουμε τους κόμβους μέσα σε σχήμα SmartArt σε συγκεκριμένη θέση.

1. Δημιουργήσετε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
3. Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) και κάντε μετατροπή τύπου (typecast) του επιλεγμένου σ.shape σε [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) εάν είναι SmartArt.
5. Επιλέξτε τον κόμβο σχήματος SmartArt με δείκτη 0.
6. Τώρα, ελέγξτε αν ο επιλεγμένος κόμβος SmartArt έχει περισσότερους από 2 υποκόμβους.
7. Τώρα, αφαιρέστε τον κόμβο στη **Position 1** χρησιμοποιώντας τη μέθοδο [**RemoveNode**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).
8. Αποθηκεύστε την Παρουσίαση.

```java
// Φορτώστε την επιθυμητή παρουσίαση
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Περιήγηση σε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Έλεγχος αν το σχήμα είναι τύπου SmartArt
        if (shape instanceof SmartArt) 
        {
            // Μετατροπή τύπου σχήματος σε SmartArt
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

## **Ορισμός προσαρμοσμένης θέσης για υποκόμβο σε αντικείμενο SmartArt**
Το Aspose.Slides for Java υποστηρίζει πλέον τον ορισμό των ιδιοτήτων [SmartArtShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShape#setX-float-) και [Y](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShape#setY-float-). Το παρακάτω απόσπασμα κώδικα δείχνει πώς να ορίσετε προσαρμοσμένη θέση, μέγεθος και περιστροφή του SmartArtShape, σημειώνοντας επίσης ότι η προσθήκη νέων κόμβων προκαλεί επαναϋπολογισμό των θέσεων και μεγεθών όλων των κόμβων. Επιπλέον, με τις ρυθμίσεις προσαρμοσμένης θέσης, ο χρήστης μπορεί να ορίσει τους κόμβους σύμφωνα με τις απαιτήσεις.

```java
// Δημιουργία αντικειμένου κλάσης Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Μετακίνηση του σχήματος SmartArt σε νέα θέση
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Αλλαγή του πλάτους του σχήματος SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Αλλαγή του ύψους του σχήματος SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Αλλαγή της περιστροφής του σχήματος SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Έλεγχος κόμβου βοηθού**
{{% alert color="primary" %}} 
Σε αυτό το άρθρο θα ερευνήσουμε περαιτέρω τα χαρακτηριστικά των σχημάτων SmartArt που προστέθηκαν σε διαφάνειες παρουσίασης προγραμματιστικά χρησιμοποιώντας το Aspose.Slides for Java.
{{% /alert %}} 

Θα χρησιμοποιήσουμε το παρακάτω σχήμα SmartArt πηγής για την έρευνά μας σε διαφορετικές ενότητες αυτού του άρθρου.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Σχήμα: Σχήμα SmartArt πηγής στη διαφάνεια**|

Στον παρακάτω κώδικα παραδείγματος θα ερευνήσουμε πώς να εντοπίσουμε τους **Assistant Nodes** στη συλλογή κόμβων SmartArt και πώς να τους αλλάξουμε.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
2. Αποκτήστε την αναφορά της δεύτερης διαφάνειας χρησιμοποιώντας το Index της.
3. Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) και κάντε μετατροπή τύπου (typecast) του επιλεγμένου σ.shape σε [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) εάν είναι SmartArt.
5. Περιηγηθείτε σε όλους τους κόμβους μέσα στο σχήμα SmartArt και ελέγξτε αν είναι [**Assistant Nodes**](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArtNode#isAssistant--).
6. Αλλάξτε την κατάσταση του Assistant Node σε κανονικό κόμβο.
7. Αποθηκεύστε την Παρουσίαση.

```java
// Δημιουργία στιγμιότυπου παρουσίασης
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
                // Έλεγχος αν ο κόμβος είναι κόμβος βοηθός
                if (node.isAssistant()) 
                {
                    // Ορισμός του κόμβου βοηθού σε ψευδές και μετατροπή του σε κανονικό κόμβο
                    node.isAssistant();
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
|**Σχήμα: Οι Assistant Nodes άλλαχτηκαν στο σχήμα SmartArt μέσα στη διαφάνεια**|

## **Ορισμός μορφής γεμίσματος κόμβου**
Το Aspose.Slides for Java καθιστά δυνατό το να προσθέσετε προσαρμοσμένα σχήματα SmartArt και να ορίσετε τη μορφή γεμίσματος τους. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να αποκτήσετε πρόσβαση σε σχήματα SmartArt και να ορίσετε τη μορφή γεμίσματος χρησιμοποιώντας το Aspose.Slides for Java.

Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το index της.
3. Προσθέστε ένα σχήμα [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArt) ορίζοντας το [**LayoutType**](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
4. Ορίστε το [**FillFormat**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShape#getFillFormat--) για τους κόμβους του σχήματος SmartArt.
5. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```java
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

## **Δημιουργία μικρογραφίας υποκόμβου SmartArt**
Οι προγραμματιστές μπορούν να δημιουργήσουν μια μικρογραφία του υποκόμβου ενός SmartArt ακολουθώντας τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation).
2. [Προσθέστε SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISmartArtNodeCollection#addNode--).
3. Αποκτήστε την αναφορά ενός κόμβου χρησιμοποιώντας το Index του
4. Αποκτήστε την εικόνα μικρογραφίας.
5. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.

```java
// Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει το αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Προσθήκη SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Λήψη της αναφοράς ενός κόμβου χρησιμοποιώντας το Index του  
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

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Υποστηρίζεται η κίνηση (animation) του SmartArt;**

Ναι. Το SmartArt αντιμετωπίζεται ως κανονικό σχήμα, έτσι μπορείτε να [εφαρμόσετε τυπικές κινήσεις](/slides/el/java/shape-animation/) (είσοδο, έξοδο, έμφαση, διαδρομές κίνησης) και να ρυθμίσετε το χρονοδιάγραμμα. Μπορείτε επίσης να κινήσετε σχήματα μέσα σε κόμβους SmartArt όταν χρειάζεται.

**Πώς μπορώ να εντοπίσω αξιόπιστα ένα συγκεκριμένο SmartArt σε μια διαφάνεια αν το εσωτερικό του ID είναι άγνωστο;**

Αναθέστε και ψάξτε με βάση το [εναλλακτικό κείμενο](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getAlternativeText--). Ορισμός ενός χαρακτηριστικού AltText στο SmartArt σας επιτρέπει να το εντοπίσετε προγραμματιστικά χωρίς εξάρτηση από εσωτερικά αναγνωριστικά.

**Θα διατηρηθεί η εμφάνιση του SmartArt κατά τη μετατροπή της παρουσίασης σε PDF;**

Ναι. Το Aspose.Slides αποδίδει το SmartArt με υψηλή οπτική πιστότητα κατά την [εξαγωγή σε PDF](/slides/el/java/convert-powerpoint-to-pdf/), διατηρώντας τη διάταξη, τα χρώματα και τα εφέ.

**Μπορώ να εξάγω μια εικόνα ολόκληρου του SmartArt (για προεπισκοπήσεις ή αναφορές);**

Ναι. Μπορείτε να αποδώσετε ένα σχήμα SmartArt σε [μορφές raster](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getImage-int-float-float-) ή σε [SVG](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) για κλιμακώσιμη εξαγωγή, καθιστώντας το κατάλληλο για μικρογραφίες, αναφορές ή χρήση στο διαδίκτυο.