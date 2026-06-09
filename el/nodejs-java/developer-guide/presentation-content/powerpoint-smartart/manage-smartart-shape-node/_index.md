---
title: Διαχειριστείτε τους κόμβους σχήματος SmartArt σε παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Κόμβος σχήματος SmartArt
type: docs
weight: 30
url: /el/nodejs-java/manage-smartart-shape-node/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχειριστείτε τους κόμβους σχήματος SmartArt σε αρχεία PPT και PPTX με το Aspose.Slides για Node.js. Λάβετε σαφή παραδείγματα κώδικα JavaScript και συμβουλές για να βελτιστοποιήσετε τις παρουσιάσεις σας."
---
## **Επισκόπηση**

Τα γραφικά SmartArt στις παρουσιάσεις PowerPoint οργανώνονται μέσω κόμβων που περιέχουν κείμενο και ορίζουν τη δομή του διαγράμματος. Το Aspose.Slides σας επιτρέπει να εργάζεστε με αυτούς τους κόμβους SmartArt προγραμματιστικά: να προσθέτετε νέους κόμβους και υποκόμβους, να εισάγετε υποκόμβους σε συγκεκριμένη θέση, να προσπελάζετε υπάρχοντες κόμβους και να διαβάζετε το κείμενό τους, το επίπεδο και τη θέση.

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε τους κόμβους σχήματος SmartArt. Εμφανίζει πώς να αφαιρείτε κόμβους, να εργάζεστε με υποκόμβους κατά δείκτη ή θέση, να μετατρέπετε έναν κόμβο βοηθού σε κανονικό κόμβο, να προσαρμόζετε τη θέση, το μέγεθος και την περιστροφή των σχημάτων κόμβου SmartArt, να ορίζετε μορφές γεμίσματος κόμβων και να δημιουργείτε μια μικρογραφία για έναν υποκόμβο SmartArt.

## **Προσθήκη κόμβου SmartArt σε παρουσίαση PowerPoint χρησιμοποιώντας JavaScript**
Το Aspose.Slides for Node.js via Java παρέχει το πιο απλό API για τη διαχείριση των σχημάτων SmartArt με τον πιο εύκολο τρόπο. Ο παρακάτω κώδικας δείγμα θα σας βοηθήσει να προσθέσετε κόμβο και υποκόμβο μέσα σε σχήμα SmartArt.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
1. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
1. Περπατήστε μέσα από κάθε σχήμα στην πρώτη διαφάνεια.
1. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt) εάν είναι SmartArt.
1. **Προσθέστε έναν νέο Node**(https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) στο σχήμα SmartArt **NodeCollection**(https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt#getAllNodes--) και ορίστε το κείμενο στο TextFrame.
1. Τώρα, **Προσθέστε**(https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) έναν **Child Node**(https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) στο πρόσφατα προστεθέν SmartArt Node και ορίστε το κείμενο στο TextFrame.
1. Αποθηκεύστε την παρουσίαση.

```javascript
// Φορτώστε την επιθυμητή παρουσίαση
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Περιηγηθείτε σε κάθε σχήμα στην πρώτη διαφάνεια
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Ελέγξτε αν το σχήμα είναι τύπου SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Κάντε μετατροπή τύπου του σχήματος σε SmartArt
            var smart = shape;
            // Προσθήκη νέου κόμβου SmartArt
            var TemNode = smart.getAllNodes().addNode();
            // Προσθήκη κειμένου
            TemNode.getTextFrame().setText("Test");
            // Προσθήκη νέου υποκόμβου στον γονικό κόμβο. Θα προστεθεί στο τέλος της συλλογής
            var newNode = TemNode.getChildNodes().addNode();
            // Προσθήκη κειμένου
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // Αποθήκευση παρουσίασης
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Προσθήκη κόμβου SmartArt σε συγκεκριμένη θέση**
Στον παρακάτω κώδικα δείγμα εξηγούμε πώς να προσθέσετε τους υποκόμβους που ανήκουν σε αντίστοιχους κόμβους του σχήματος SmartArt σε συγκεκριμένη θέση.

1. Δημιουργήστε μια παρουσίαση της κλάσης Presentation.
1. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
1. Προσθέστε ένα σχήμα SmartArt τύπου [StackedList](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) στη διαφάνεια.
1. Προσπελάστε τον πρώτο κόμβο στο προστεθέν σχήμα SmartArt.
1. Τώρα, προσθέστε τον **Child Node**(https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) για τον επιλεγμένο **Node**(https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArtNode) στη θέση 2 και ορίστε το κείμενό του.
1. Αποθηκεύστε την παρουσίαση.

```javascript
// Δημιουργία παρουσίασης
var pres = new aspose.slides.Presentation();
try {
    // Πρόσβαση στη διαφάνεια της παρουσίασης
    var slide = pres.getSlides().get_Item(0);
    // Προσθήκη Smart Art IShape
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Πρόσβαση στον κόμβο SmartArt στη θέση 0
    var node = smart.getAllNodes().get_Item(0);
    // Προσθήκη νέου υποκόμβου στη θέση 2 στον γονικό κόμβο
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // Προσθήκη κειμένου
    chNode.getTextFrame().setText("Sample Text Added");
    // Αποθήκευση παρουσίασης
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Πρόσβαση σε κόμβο SmartArt σε παρουσίαση PowerPoint χρησιμοποιώντας JavaScript**
Ο παρακάτω κώδικας δείγμα θα σας βοηθήσει να προσπελάσετε τους κόμβους μέσα σε σχήμα SmartArt. Παρακαλούμε σημειώστε ότι δεν μπορείτε να αλλάξετε το LayoutType του SmartArt καθώς είναι μόνο για ανάγνωση και ορίζεται μόνο όταν το σχήμα SmartArt προστίθεται.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
1. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
1. Περπατήστε μέσα από κάθε σχήμα στην πρώτη διαφάνεια.
1. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt) εάν είναι SmartArt.
1. Περπατήστε μέσα από όλους τους **Nodes**(https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt#getAllNodes--) μέσα στο σχήμα SmartArt.
1. Προσπελάστε και εμφανίστε πληροφορίες όπως η θέση, το επίπεδο και το κείμενο του κόμβου SmartArt.

```javascript
// Δημιουργία αντικειμένου Presentation
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // Λήψη πρώτης διαφάνειας
    var slide = pres.getSlides().get_Item(0);
    // Περιήγηση σε κάθε σχήμα στην πρώτη διαφάνεια
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Έλεγχος αν το σχήμα είναι τύπου SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Μετατροπή τύπου του σχήματος σε SmartArt
            var smart = shape;
            // Περιήγηση σε όλους τους κόμβους μέσα στο SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // Πρόσβαση στον κόμβο SmartArt στη θέση i
                var node = smart.getAllNodes().get_Item(j);
                // Εκτύπωση των παραμέτρων του κόμβου SmartArt
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Πρόσβαση σε υποκόμβο SmartArt**
Ο παρακάτω κώδικας δείγμα θα σας βοηθήσει να προσπελάσετε τους υποκόμβους που ανήκουν σε αντίστοιχους κόμβους του σχήματος SmartArt.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
1. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
1. Περπατήστε μέσα από κάθε σχήμα στην πρώτη διαφάνεια.
1. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt) εάν είναι SmartArt.
1. Περπατήστε μέσα από όλους τους **Nodes**(https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt#getAllNodes--) μέσα στο σχήμα SmartArt.
1. Για κάθε επιλεγμένο SmartArt **Node**(https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArtNode), περπατήστε μέσα από όλα τα **Child Nodes**(https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) του συγκεκριμένου κόμβου.
1. Προσπελάστε και εμφανίστε πληροφορίες όπως η θέση, το επίπεδο και το κείμενο του **Child Node**(https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--).

```javascript
// Δημιουργία αντικειμένου Presentation
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // Λήψη πρώτης διαφάνειας
    var slide = pres.getSlides().get_Item(0);
    // Περιήγηση σε κάθε σχήμα στην πρώτη διαφάνεια
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // Έλεγχος αν το σχήμα είναι τύπου SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Μετατροπή τύπου του σχήματος σε SmartArt
            var smart = shape;
            // Περιήγηση σε όλους τους κόμβους μέσα στο SmartArt
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // Πρόσβαση στον κόμβο SmartArt στη θέση i
                var node0 = smart.getAllNodes().get_Item(i);
                // Περιήγηση στους υποκόμβους του κόμβου SmartArt στη θέση i
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // Πρόσβαση στον υποκόμβο του κόμβου SmartArt
                    var node = node0.getChildNodes().get_Item(j);
                    // Εκτύπωση των παραμέτρων του υποκόμβου SmartArt
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Πρόσβαση σε υποκόμβο SmartArt σε συγκεκριμένη θέση**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να προσπελάζουμε τους υποκόμβους σε κάποια συγκεκριμένη θέση που ανήκουν σε αντίστοιχους κόμβους του σχήματος SmartArt.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
1. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
1. Προσθέστε ένα σχήμα SmartArt τύπου [StackedList](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList).
1. Προσπελάστε το προστεθέν σχήμα SmartArt.
1. Προσπελάστε τον κόμβο στη θέση 0 του προσπελασμένου σχήματος SmartArt.
1. Τώρα, προσπελάστε τον **Child Node**(https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) στη θέση 1 για τον προσπελασμένο κόμβο SmartArt χρησιμοποιώντας τη μέθοδο **get_Item()**.
1. Προσπελάστε και εμφανίστε πληροφορίες όπως η θέση, το επίπεδο και το κείμενο του **Child Node**(https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--).

```javascript
// Δημιουργία παρουσίασης
var pres = new aspose.slides.Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    var slide = pres.getSlides().get_Item(0);
    // Προσθήκη σχήματος SmartArt στην πρώτη διαφάνεια
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Πρόσβαση στον κόμβο SmartArt στη θέση 0
    var node = smart.getAllNodes().get_Item(0);
    // Πρόσβαση στον υποκόμβο στη θέση 1 στον γονικό κόμβο
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // Εκτύπωση των παραμέτρων του υποκόμβου SmartArt
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αφαίρεση κόμβου SmartArt σε παρουσίαση PowerPoint χρησιμοποιώντας JavaScript**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να αφαιρέσουμε τους κόμβους μέσα σε σχήμα SmartArt.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
1. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
1. Περπατήστε μέσα από κάθε σχήμα στην πρώτη διαφάνεια.
1. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt) εάν είναι SmartArt.
1. Ελέγξτε αν το SmartArt έχει περισσότερους από 0 κόμβους.
1. Επιλέξτε τον κόμβο SmartArt που θα διαγραφεί.
1. Τώρα, αφαιρέστε τον επιλεγμένο κόμβο χρησιμοποιώντας τη μέθοδο **RemoveNode**(https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-).
1. Αποθηκεύστε την παρουσίαση.

```javascript
// Φορτώστε την επιθυμητή παρουσίαση
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Περιηγηθείτε σε κάθε σχήμα στην πρώτη διαφάνεια
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Ελέγξτε αν το σχήμα είναι τύπου SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Κάντε μετατροπή τύπου του σχήματος σε SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Πρόσβαση στον κόμβο SmartArt στη θέση 0
                var node = smart.getAllNodes().get_Item(0);
                // Αφαίρεση του επιλεγμένου κόμβου
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // Αποθήκευση παρουσίασης
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αφαίρεση κόμβου SmartArt σε συγκεκριμένη θέση**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να αφαιρέσουμε τους κόμβους μέσα σε σχήμα SmartArt σε συγκεκριμένη θέση.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
1. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
1. Περπατήστε μέσα από κάθε σχήμα στην πρώτη διαφάνεια.
1. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt) εάν είναι SmartArt.
1. Επιλέξτε τον κόμβο σχήματος SmartArt στη θέση 0.
1. Τώρα, ελέγξτε αν ο επιλεγμένος κόμβος SmartArt έχει περισσότερους από 2 υποκόμβους.
1. Τώρα, αφαιρέστε τον κόμβο στη **Θέση 1** χρησιμοποιώντας τη μέθοδο **RemoveNode**(https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-).
1. Αποθηκεύστε την παρουσίαση.

```javascript
// Φορτώστε την επιθυμητή παρουσίαση
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Περιηγηθείτε σε κάθε σχήμα στην πρώτη διαφάνεια
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Ελέγξτε αν το σχήμα είναι τύπου SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Κάντε μετατροπή τύπου του σχήματος σε SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Πρόσβαση στον κόμβο SmartArt στη θέση 0
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // Αφαίρεση του υποκόμβου στη θέση 1
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // Αποθήκευση παρουσίασης
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός προσαρμοσμένης θέσης για υποκόμβο σε SmartArt**
Τώρα το Aspose.Slides for Node.js via Java υποστηρίζει τον ορισμό των ιδιοτήτων [SmartArtShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#setX-float-) και [Y](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#setY-float-). Το παρακάτω τμήμα κώδικα δείχνει πώς να ορίσετε προσαρμοσμένη θέση, μέγεθος και περιστροφή του SmartArtShape· επίσης σημειώστε ότι η προσθήκη νέων κόμβων προκαλεί επαναϋπολογισμό των θέσεων και μεγεθών όλων των κόμβων. Με τις προσαρμοσμένες ρυθμίσεις θέσης, ο χρήστης μπορεί να ορίσει τους κόμβους όπως απαιτείται.

```javascript
// Δημιουργία αντικειμένου Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // Μετακίνηση σχήματος SmartArt σε νέα θέση
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // Αλλαγή πλάτους σχήματος SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // Αλλαγή ύψους σχήματος SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // Αλλαγή περιστροφής σχήματος SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Έλεγχος κόμβου βοηθού**
{{% alert color="primary" %}} 

Σε αυτό το άρθρο θα διερευνήσουμε περαιτέρω τις δυνατότητες των σχημάτων SmartArt που έχουν προστεθεί στις διαφάνειες παρουσίασης προγραμματιστικά χρησιμοποιώντας το Aspose.Slides for Node.js via Java.

{{% /alert %}} 

Θα χρησιμοποιήσουμε το ακόλουθο σχήμα SmartArt ως πηγή για την έρευνά μας σε διαφορετικά τμήματα του άρθρου.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Σχήμα: Πηγαίο σχήμα SmartArt στη διαφάνεια**|

Στον παρακάτω κώδικα δείγμα θα διερευνήσουμε πώς να εντοπίσουμε **Assistant Nodes** στη συλλογή κόμβων SmartArt και πώς να τους αλλάξουμε.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
1. Αποκτήστε την αναφορά της δεύτερης διαφάνειας χρησιμοποιώντας το Index της.
1. Περπατήστε μέσα από κάθε σχήμα στην πρώτη διαφάνεια.
1. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt) εάν είναι SmartArt.
1. Περπατήστε μέσα από όλους τους κόμβους του σχήματος SmartArt και ελέγξτε αν είναι **Assistant Nodes**(https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArtNode#isAssistant--).
1. Αλλάξτε την κατάσταση του κόμβου βοηθού σε κανονικό κόμβο.
1. Αποθηκεύστε την παρουσίαση.

```javascript
// Δημιουργία παρουσίασης
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // Περιήγηση σε κάθε σχήμα στην πρώτη διαφάνεια
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Έλεγχος αν το σχήμα είναι τύπου SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Μετατροπή τύπου του σχήματος σε SmartArt
            var smart = shape;
            // Περιήγηση σε όλους τους κόμβους του σχήματος SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // Έλεγχος αν ο κόμβος είναι κόμβος βοηθού
                if (node.isAssistant()) {
                    // Ορισμός του κόμβου βοηθού σε ψευδές και μετατροπή σε κανονικό κόμβο
                    node.isAssistant();
                }
            }
        }
    }
    // Αποθήκευση παρουσίασης
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Σχήμα: Οι κόμβοι βοηθοί άλλαξαν στο σχήμα SmartArt μέσα στη διαφάνεια**|

## **Ορισμός μορφής γεμίσματος για κόμβο**
Το Aspose.Slides for Node.js via Java κάνει δυνατό το να προσθέσετε προσαρμοσμένα σχήματα SmartArt και να ορίσετε τη μορφή γεμίσματος τους. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να προσπελάσετε σχήματα SmartArt και να ορίσετε τη μορφή γεμίσματος χρησιμοποιώντας το Aspose.Slides for Node.js via Java.

Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα σχήμα [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt) ορίζοντας τον **LayoutType**(https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Ορίστε το **FillFormat**(https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#getFillFormat--) για τους κόμβους του σχήματος SmartArt.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```javascript
// Δημιουργία παρουσίασης
var pres = new aspose.slides.Presentation();
try {
    // Πρόσβαση στη διαφάνεια
    var slide = pres.getSlides().get_Item(0);
    // Προσθήκη σχήματος SmartArt και κόμβων
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // Ορισμός χρώματος γεμίσματος κόμβου
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // Αποθήκευση παρουσίασης
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Δημιουργία μικρογραφίας για υποκόμβο SmartArt**
Οι προγραμματιστές μπορούν να δημιουργήσουν μια μικρογραφία του υποκόμβου ενός SmartArt ακολουθώντας τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
1. **Προσθέστε SmartArt**(https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--).
1. Αποκτήστε την αναφορά ενός κόμβου χρησιμοποιώντας το Index του.
1. Λάβετε τη μικρογραφία.
1. Αποθηκεύστε τη μικρογραφία σε οποιαδήποτε επιθυμητή μορφή εικόνας.

```javascript
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Προσθήκη SmartArt
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // Λήψη αναφοράς σε κόμβο χρησιμοποιώντας το Index του
    var node = smart.getNodes().get_Item(1);
    // Λήψη μικρογραφίας
    var slideImage = node.getShapes().get_Item(0).getImage();
    // Αποθήκευση μικρογραφίας
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές ερωτήσεις**

**Υποστηρίζεται η κίνηση (animation) του SmartArt;**

Ναι. Το SmartArt αντιμετωπίζεται ως κανονικό σχήμα, ώστε μπορείτε να [εφαρμόσετε τυπικές κινήσεις](/slides/el/nodejs-java/shape-animation/) (είσοδο, έξοδο, έμφαση, μονοπάτια κίνησης) και να ρυθμίσετε τον χρόνο. Μπορείτε επίσης να κινήσετε σχήματα μέσα σε κόμβους SmartArt όταν χρειάζεται.

**Πώς μπορώ αξιόπιστα να εντοπίσω ένα συγκεκριμένο SmartArt σε μια διαφάνεια αν το εσωτερικό του ID είναι άγνωστο;**

Αναθέστε και αναζητήστε με βάση το [εναλλακτικό κείμενο]https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/getalternativetext/. Ορισμός ενός χαρακτηριστικού AltText στο SmartArt σας επιτρέπει να το βρείτε χωρίς να βασίζεστε σε εσωτερικά αναγνωριστικά.

**Θα διατηρηθεί η εμφάνιση του SmartArt κατά τη μετατροπή της παρουσίασης σε PDF;**

Ναι. Το Aspose.Slides αποδίδει το SmartArt με υψηλή οπτική πιστότητα κατά την [εξαγωγή σε PDF](/slides/el/nodejs-java/convert-powerpoint-to-pdf/), διατηρώντας τη διάταξη, τα χρώματα και τα εφέ.

**Μπορώ να εξάγω εικόνα ολόκληρου του SmartArt (για προεπισκοπήσεις ή εκθέσεις);**

Ναι. Μπορείτε να αποδώσετε ένα σχήμα SmartArt σε [μορφές raster]https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getImage) ή σε [SVG](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/writeassvg/) για κλίμακα διανυσματική έξοδο, καθιστώντας το κατάλληλο για μικρογραφίες, εκθέσεις ή χρήση στο web.