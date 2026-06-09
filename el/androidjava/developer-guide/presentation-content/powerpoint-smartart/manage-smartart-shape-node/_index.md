---
title: Διαχείριση κόμβων σχήματος SmartArt σε παρουσιάσεις στο Android
linktitle: Κόμβος σχήματος SmartArt
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
- Κόμβος βοηθού
- Μορφή γεμίσματος
- Απόδοση κόμβου
- PowerPoint
- Παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε τους κόμβους σχήματος SmartArt σε αρχεία PPT και PPTX με το Aspose.Slides για Android. Λάβετε σαφή παραδείγματα κώδικα Java και συμβουλές για βελτιστοποίηση των παρουσιάσεων σας."
---
## **Επισκόπηση**

Τα γραφικά SmartArt σε παρουσιάσεις του PowerPoint οργανώνονται μέσω κόμβων που περιέχουν κείμενο και ορίζουν τη δομή του διαγράμματος. Το Aspose.Slides σας επιτρέπει να εργάζεστε με αυτούς τους κόμβους SmartArt προγραμματιστικά: προσθέτετε νέους κόμβους και υποκόμβους, εισάγετε υποκόμβους σε συγκεκριμένη θέση, έχετε πρόσβαση σε υπάρχοντες κόμβους και διαβάζετε το κείμενο, το επίπεδο και τη θέση τους.

Αυτό το άρθρο εξηγεί πώς να διαχειριστείτε τους κόμβους σχήματος SmartArt. Δείχνει πώς να αφαιρέσετε κόμβους, να εργαστείτε με υποκόμβους κατά δείκτη ή θέση, να μετατρέψετε έναν κόμβο βοηθού σε κανονικό κόμβο, να προσαρμόσετε τη θέση, το μέγεθος και την περιστροφή των σχημάτων κόμβων SmartArt, να ορίσετε μορφές γεμίσματος κόμβων και να δημιουργήσετε μικρογραφία για έναν υποκόμβο SmartArt.

## **Προσθήκη κόμβου SmartArt**
Το Aspose.Slides για Android μέσω Java παρέχει το πιο απλό API για τη διαχείριση των σχημάτων SmartArt με τον πιο εύκολο τρόπο. Ο παρακάτω κώδικας παραδείγματος θα βοηθήσει στην προσθήκη κόμβου και υποκόμβου μέσα σε σχήμα SmartArt.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
3. Περιηγηθείτε σε όλα τα σχήματα μέσα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) εάν είναι SmartArt.  
5. [Προσθέστε έναν νέο Κόμβο](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) στο σχήμα SmartArt [**NodeCollection**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) και ορίστε το κείμενο στο TextFrame.  
6. Τώρα, [Προσθέστε](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) έναν [**Υποκόμβο**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) στον νεοπροστέθηκε [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) Κόμβο και ορίστε το κείμενο στο TextFrame.  
7. Αποθηκεύστε την Παρουσίαση.

```java
// Φορτώστε την επιθυμητή παρουσίαση
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Περιηγηθείτε σε όλα τα σχήματα μέσα στην πρώτη διαφάνεια
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
Στον παρακάτω κώδικα παραδείγματος εξηγήσαμε πώς να προσθέσετε τους υποκόμβους που ανήκουν στους αντίστοιχους κόμβους του σχήματος SmartArt σε συγκεκριμένη θέση.

1. Δημιουργήστε μια παρουσίαση της κλάσης Presentation.  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
3. Προσθέστε ένα σχήμα [**StackedList**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) τύπου [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArt) στη ληφθείσα διαφάνεια.  
4. Προσεγγίστε τον πρώτο κόμβο στο προστιθέμενο σχήμα SmartArt.  
5. Τώρα, προσθέστε τον [**Υποκόμβο**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) για τον επιλεγμένο [**Κόμβο**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArtNode) στη θέση 2 και ορίστε το κείμενό του.  
6. Αποθηκεύστε την Παρουσίαση.

```java
// Δημιουργία στιγμιότυπου παρουσίασης
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
Ο παρακάτω κώδικας παραδείγματος θα βοηθήσει στην πρόσβαση σε κόμβους μέσα σε σχήμα SmartArt. Παρακαλούμε σημειώστε ότι δεν μπορείτε να αλλάξετε το LayoutType του SmartArt καθώς είναι μόνο για ανάγνωση και ορίζεται μόνο όταν προστίθεται το σχήμα SmartArt.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
3. Περιηγηθείτε σε όλα τα σχήματα μέσα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) εάν είναι SmartArt.  
5. Περιηγηθείτε σε όλους τους [**Κόμβους**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArt#getAllNodes--) μέσα στο σχήμα SmartArt.  
6. Πρόσβαση και εμφάνιση πληροφοριών όπως θέση κόμβου SmartArt, επίπεδο και κείμενο.

```java
// Δημιουργία αντικειμένου κλάσης Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Λήψη πρώτης διαφάνειας
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Περιήγηση σε όλα τα σχήματα μέσα στην πρώτη διαφάνεια
    for (IShape shape : slide.getShapes()) 
    {
        // Έλεγχος αν το σχήμα είναι τύπου SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Μετατροπή τύπου σχήματος σε SmartArt
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
Ο παρακάτω κώδικας παραδείγματος θα βοηθήσει στην πρόσβαση στους υποκόμβους που ανήκουν σε αντίστοιχους κόμβους του σχήματος SmartArt.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
3. Περιηγηθείτε σε όλα τα σχήματα μέσα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) εάν είναι SmartArt.  
5. Περιηγηθείτε σε όλους τους [**Κόμβους**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArt#getAllNodes--) μέσα στο σχήμα SmartArt.  
6. Για κάθε επιλεγμένο σχήμα SmartArt [**Κόμβο**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArtNode), περιηγηθείτε σε όλους τους [**Υποκόμβους**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) μέσα στον συγκεκριμένο κόμβο.  
7. Πρόσβαση και εμφάνιση πληροφοριών όπως θέση [**Υποκόμβου**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) , επίπεδο και κείμενο.

```java
// Δημιουργία αντικειμένου κλάσης Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Λήψη πρώτης διαφάνειας
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Περιήγηση σε όλα τα σχήματα μέσα στην πρώτη διαφάνεια
    for (IShape shape : slide.getShapes()) 
    {
        // Έλεγχος αν το σχήμα είναι τύπου SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Μετατροπή τύπου σχήματος σε SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Περιήγηση σε όλους τους κόμβους μέσα στο SmartArt
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

## **Πρόσβαση σε υποκόμβο SmartArt σε συγκεκριμένη θέση**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να προσπεράσουμε τους υποκόμβους σε συγκεκριμένη θέση που ανήκουν σε αντίστοιχους κόμβους του σχήματος SmartArt.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) .  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
3. Προσθέστε ένα σχήμα [**StackedList**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) τύπου SmartArt.  
4. Πρόσβαση στο προστιθέμενο σχήμα SmartArt.  
5. Πρόσβαση στον κόμβο στη θέση 0 για το προσπελάσθουν σχήμα SmartArt.  
6. Τώρα, προσπελάστε τον [**Υποκόμβο**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) στη θέση 1 για τον προσπελάσθουν κόμβο SmartArt χρησιμοποιώντας τη μέθοδο **get_Item()**.  
7. Πρόσβαση και εμφάνιση πληροφοριών όπως θέση [**Υποκόμβου**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) , επίπεδο και κείμενο.

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

## **Κατάργηση κόμβου SmartArt**
Σε αυτό το παράδειγμα, θα μάθουμε να αφαιρέσουμε τους κόμβους μέσα σε σχήμα SmartArt.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
3. Περιηγηθείτε σε όλα τα σχήματα μέσα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) εάν είναι SmartArt.  
5. Ελέγξτε αν το SmartArt έχει περισσότερους από 0 κόμβους.  
6. Επιλέξτε τον κόμβο SmartArt που θα διαγραφεί.  
7. Τώρα, αφαιρέστε τον επιλεγμένο κόμβο χρησιμοποιώντας τη μέθοδο [**RemoveNode**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).  
8. Αποθηκεύστε την Παρουσίαση.

```java
// Φορτώστε την επιθυμητή παρουσίαση
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Περιηγηθείτε σε όλα τα σχήματα μέσα στην πρώτη διαφάνεια
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

## **Κατάργηση κόμβου SmartArt από συγκεκριμένη θέση**
Σε αυτό το παράδειγμα, θα μάθουμε να αφαιρέσουμε τους κόμβους μέσα σε σχήμα SmartArt σε συγκεκριμένη θέση.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
3. Περιηγηθείτε σε όλα τα σχήματα μέσα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) εάν είναι SmartArt.  
5. Επιλέξτε το κόμβο σχήματος SmartArt στη θέση 0.  
6. Τώρα, ελέγξτε αν ο επιλεγμένος κόμβος SmartArt έχει περισσότερους από 2 υποκόμβους.  
7. Τώρα, αφαιρέστε τον κόμβο στη **Θέση 1** χρησιμοποιώντας τη μέθοδο [**RemoveNode**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).  
8. Αποθηκεύστε την Παρουσίαση.

```java
// Φορτώστε την επιθυμητή παρουσίαση
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Περιηγηθείτε σε όλα τα σχήματα μέσα στην πρώτη διαφάνεια
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
Τώρα το Aspose.Slides για Android μέσω Java υποστηρίζει τον ορισμό των ιδιοτήτων [SmartArtShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape#setX-float-) και [Y](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape#setY-float-). Το παρακάτω απόσπασμα κώδικα δείχνει πώς να ορίσετε προσαρμοσμένη θέση, μέγεθος και περιστροφή του SmartArtShape· σημειώστε επίσης ότι η προσθήκη νέων κόμβων προκαλεί επανυπολογισμό των θέσεων και μεγεθών όλων των κόμβων. Με τις προσαρμοσμένες ρυθμίσεις θέσης, ο χρήστης μπορεί να τοποθετήσει τους κόμβους όπως απαιτείται.

```java
// Δημιουργία στιγμιότυπου κλάσης Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Μετακίνηση του σχήματος SmartArt σε νέα θέση
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Αλλαγή πλάτους του σχήματος SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Αλλαγή ύψους του σχήματος SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Αλλαγή περιστροφής του σχήματος SmartArt
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

Σε αυτό το άρθρο θα διερευνήσουμε περαιτέρω τις δυνατότητες των σχημάτων SmartArt που προστίθενται σε διαφάνειες παρουσίασης προγραμματιστικά χρησιμοποιώντας το Aspose.Slides για Android μέσω Java.

{{% /alert %}} 

Θα χρησιμοποιήσουμε το ακόλουθο σχήμα SmartArt ως πηγή για την έρευνά μας σε διαφορετικές ενότητες του άρθρου.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Σχήμα: Πηγή SmartArt στη διαφάνεια**|

Στον παρακάτω κώδικα παραδείγματος θα διερευνήσουμε πώς να εντοπίσουμε **Κόμβους Βοηθού** στη συλλογή κόμβων SmartArt και να τους αλλάξουμε.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.  
2. Αποκτήστε την αναφορά της δεύτερης διαφάνειας χρησιμοποιώντας το Index της.  
3. Περιηγηθείτε σε όλα τα σχήματα μέσα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) εάν είναι SmartArt.  
5. Περιηγηθείτε σε όλους τους κόμβους μέσα στο σχήμα SmartArt και ελέγξτε αν είναι [**Κόμβοι Βοηθού**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArtNode#isAssistant--).  
6. Αλλάξτε την κατάσταση του Κόμβου Βοηθού σε κανονικό κόμβο.  
7. Αποθηκεύστε την Παρουσίαση.

```java
// Δημιουργία στιγμιότυπου παρουσίασης
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Περιήγηση σε όλα τα σχήματα μέσα στην πρώτη διαφάνεια
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
|**Σχήμα: Αλλαγμένοι Κόμβοι Βοηθού στο σχήμα SmartArt μέσα στη διαφάνεια**|

## **Ορισμός μορφής γεμίσματος κόμβου**
Το Aspose.Slides για Android μέσω Java καθιστά δυνατή την προσθήκη προσαρμοσμένων σχημάτων SmartArt και τον ορισμό της μορφής γεμίσματος τους. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να προσπελάσετε σχήματα SmartArt και να ορίσετε τη μορφή γεμίσματος χρησιμοποιώντας το Aspose.Slides για Android μέσω Java.

Παρακαλούμε ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).  
2. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το index της.  
3. Προσθέστε ένα σχήμα [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArt) ορίζοντας τον [**LayoutType**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).  
4. Ορίστε το [**FillFormat**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape#getFillFormat--) για τους κόμβους σχήματος SmartArt.  
5. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```java
// Δημιουργία στιγμιότυπου παρουσίασης
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

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).  
2. [Προσθέστε SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).  
3. Αποκτήστε την αναφορά ενός κόμβου χρησιμοποιώντας το Index του.  
4. Λάβετε την εικόνα μικρογραφίας.  
5. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.

```java
// Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει το αρχείο PPTX 
Presentation pres = new Presentation();
try {
    // Προσθήκη SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Λήψη αναφοράς κόμβου χρησιμοποιώντας το Index του  
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

## **Συχνές ερωτήσεις**

**Υποστηρίζεται η κίνηση (animation) του SmartArt;**

Ναι. Το SmartArt αντιμετωπίζεται ως κανονικό σχήμα, έτσι μπορείτε να [εφαρμόσετε τυπικές κινήσεις](/slides/el/androidjava/shape-animation/) (εισαγωγή, έξοδος, έμφαση, διαδρομές κίνησης) και να προσαρμόσετε το χρονοδιάγραμμα. Μπορείτε επίσης να δημιουργήσετε κινήσεις για σχήματα μέσα σε κόμβους SmartArt όταν απαιτείται.

**Πώς μπορώ να εντοπίσω αξιόπιστα ένα συγκεκριμένο SmartArt σε μια διαφάνεια αν το εσωτερικό του ID είναι άγνωστο;**

Αναθέστε και αναζητήστε με βάση το [alternative text](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#getAlternativeText--). Ορίζοντας ένα διακριτικό AltText στο SmartArt, μπορείτε να το βρείτε προγραμματιστικά χωρίς να εξαρτάσθετε από εσωτερικά αναγνωριστικά.

**Θα διατηρηθεί η εμφάνιση του SmartArt κατά τη μετατροπή της παρουσίασης σε PDF;**

Ναι. Το Aspose.Slides αποδίδει το SmartArt με υψηλή οπτική πιστότητα κατά την [PDF export](/slides/el/androidjava/convert-powerpoint-to-pdf/), διασφαλίζοντας τη διατήρηση της διάταξης, των χρωμάτων και των εφέ.

**Μπορώ να εξάγω μια εικόνα ολόκληρου του SmartArt (για προεπισκοπήσεις ή αναφορές);**

Ναι. Μπορείτε να αποδώσετε ένα σχήμα SmartArt σε [raster formats](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) ή σε [SVG](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) για κλιμακώσιμο διανυσματικό αποτέλεσμα, καθιστώντας το κατάλληλο για μικρογραφίες, αναφορές ή χρήση στο web.