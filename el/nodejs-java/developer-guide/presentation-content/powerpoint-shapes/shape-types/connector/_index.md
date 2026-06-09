---
title: Διαχείριση συνδέσμων σε παρουσιάσεις με JavaScript
linktitle: Σύνδεσμος
type: docs
weight: 10
url: /el/nodejs-java/connector/
keywords:
- σύνδεσμος
- τύπος συνδέσμου
- σημείο συνδέσμου
- γραμμή συνδέσμου
- γωνία συνδέσμου
- σύνδεση σχημάτων
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Ενδυναμώστε τις εφαρμογές JavaScript να σχεδιάζουν, συνδέουν και αυτοπροσανατολίζουν γραμμές σε διαφάνειες PowerPoint — αποκτήστε πλήρη έλεγχο πάνω σε ευθείες, γωνιακές και καμπυλωτές συνδέσεις."
---
## **Εισαγωγή**

Ένας σύνδεσμος PowerPoint είναι μια ειδική γραμμή που συνδέει ή ενώνει δύο σχήματα μεταξύ τους και παραμένει προσαρτημένος στα σχήματα ακόμη και όταν αυτά μετακινούνται ή επανατοποθετούνται σε μια συγκεκριμένη διαφάνεια. 

Οι σύνδεσμοι συνήθως συνδέονται με *σημεία σύνδεσης* (πράσινα σημεία), τα οποία υπάρχουν σε όλα τα σχήματα από προεπιλογή. Τα σημεία σύνδεσης εμφανίζονται όταν ο δείκτης πλησιάζει σε αυτά.

*Σημεία προσαρμογής* (πορτοκαλί σημεία), τα οποία υπάρχουν μόνο σε ορισμένους συνδέσμους, χρησιμοποιούνται για την τροποποίηση της θέσης και του σχήματος των συνδέσμων.

## **Τύποι Συνδέσμων**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε ευθείες, αγκώνι (γωνιακές) και καμπυλωτές συνδέσεις. 

Το Aspose.Slides παρέχει αυτούς τους συνδέσμους:

| Σύνδεσμος                      | Εικόνα                                                        | Αριθμός σημείων προσαρμογής |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Σύνδεση Σχημάτων με Χρήση Συνδέσμων**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://apireference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Αποκτήστε μια αναφορά σε μία διαφάνεια μέσω του δείκτη της.
1. Προσθέστε δύο [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape) στη διαφάνεια χρησιμοποιώντας τη μέθοδο `addAutoShape` που εκτίθεται από το αντικείμενο `Shapes`.
1. Προσθέστε έναν σύνδεσμο χρησιμοποιώντας τη μέθοδο `addConnector` που εκτίθεται από το αντικείμενο `Shapes`, ορίζοντας τον τύπο του συνδέσμου.
1. Συνδέστε τα σχήματα χρησιμοποιώντας τον σύνδεσμο.
1. Καλέστε τη μέθοδο `reroute` για να εφαρμόσετε τη συντομότερη διαδρομή σύνδεσης.
1. Αποθηκεύστε την παρουσίαση. 

Αυτός ο κώδικας JavaScript δείχνει πώς να προσθέσετε έναν σύνδεσμο (έναν λυγό σύνδεσμο) μεταξύ δύο σχημάτων (μιας έλλειψης και ενός ορθογωνίου):

```javascript
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει το αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Προσπελαύνει τη συλλογή σχημάτων για μια συγκεκριμένη διαφάνεια
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Προσθέτει ένα σχήμα αυτόματης δημιουργίας Έλλειψης
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Προσθέτει ένα σχήμα αυτόματης δημιουργίας Ορθογωνίου
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Προσθέτει ένα σχήμα σύνδεσμου στη συλλογή σχημάτων της διαφάνειας
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Συνδέει τα σχήματα χρησιμοποιώντας τον σύνδεσμο
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Καλεί τη μέθοδο reroute που ορίζει τη συντομότερη αυτόματη διαδρομή μεταξύ των σχημάτων
    connector.reroute();
    // Αποθηκεύει την παρουσίαση
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

`Η μέθοδος Connector.reroute` επαναδρομολογεί έναν σύνδεσμο και τον αναγκάζει να ακολουθήσει τη συντομότερη δυνατή διαδρομή μεταξύ των σχημάτων. Για να επιτύχει τον στόχο του, η μέθοδος μπορεί να τροποποιήσει τα σημεία `setStartShapeConnectionSiteIndex` και `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Καθορισμός Σημείου Σύνδεσης**

Εάν θέλετε ένας σύνδεσμος να συνδέει δύο σχήματα χρησιμοποιώντας συγκεκριμένα σημεία στα σχήματα, πρέπει να καθορίσετε τα προτιμώμενα σημεία σύνδεσης ως εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Αποκτήστε μια αναφορά σε μία διαφάνεια μέσω του δείκτη της.
1. Προσθέστε δύο [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape) στη διαφάνεια χρησιμοποιώντας τη μέθοδο `addAutoShape` που εκτίθεται από το αντικείμενο `Shapes`.
1. Προσθέστε έναν σύνδεσμο χρησιμοποιώντας τη μέθοδο `addConnector` που εκτίθεται από το αντικείμενο `Shapes`, ορίζοντας τον τύπο του συνδέσμου.
1. Συνδέστε τα σχήματα χρησιμοποιώντας τον σύνδεσμο. 
1. Ορίστε τα προτιμώμενα σημεία σύνδεσης στα σχήματα. 
1. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας JavaScript δείχνει πώς να προσθέσετε έναν σύνδεσμο (έναν λυγό σύνδεσμο) μεταξύ δύο σχημάτων (μιας έλλειψης και ενός ορθογωνίου):

```javascript
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Προσπελαύνει τη συλλογή σχημάτων για μια συγκεκριμένη διαφάνεια
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Προσθέτει ένα σχήμα αυτόματης δημιουργίας Έλλειψης
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Προσθέτει ένα σχήμα αυτόματικής δημιουργίας Ορθογωνίου
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Προσθέτει ένα σχήμα σύνδεσμου στη συλλογή σχημάτων της διαφάνειας
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Συνδέει τα σχήματα χρησιμοποιώντας τον σύνδεσμο
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Ορίζει τον προτιμώμενο δείκτη σημείου σύνδεσης στο σχήμα Έλλειψης
    var wantedIndex = 6;
    // Ελέγχει αν ο προτιμώμενος δείκτης είναι μικρότερος από το μέγιστο πλήθος σημείων σύνδεσης
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        // Ορίζει το προτιμώμενο σημείο σύνδεσης στο σχήμα αυτόματης δημιουργίας Έλλειψης
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    // Αποθηκεύει την παρουσίαση
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Προσαρμογή Σημείου Συνδέσμου**

Μπορείτε να προσαρμόσετε έναν υπάρχοντα σύνδεσμο μέσω των σημείων προσαρμογής του. Μόνο οι σύνδεσμοι με σημεία προσαρμογής μπορούν να τροποποιηθούν με αυτόν τον τρόπο. Δείτε τον πίνακα κάτω από **[Τύποι συνδέσμων.](/slides/el/nodejs-java/connector/#types-of-connectors)**

### **Απλή Περίπτωση**

Σκεφτείτε μια περίπτωση όπου ένας σύνδεσμος μεταξύ δύο σχημάτων (A και B) περνάει από ένα τρίτο σχήμα (C):

![connector-obstruction](connector-obstruction.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Για να αποφύγετε ή να παρακάμψετε το τρίτο σχήμα, μπορούμε να προσαρμόσουμε τον σύνδεσμο μετακινώντας την κάθετη γραμμή του προς τα αριστερά ως εξής:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Προηγμένες Περιπτώσεις** 

Για να εκτελέσετε πιο σύνθετες προσαρμογές, πρέπει να λάβετε υπόψη τα εξής:

* Το προσαρμόσιμο σημείο ενός συνδέσμου συνδέεται στενά με έναν τύπο που υπολογίζει και καθορίζει τη θέση του. Επομένως, αλλαγές στη θέση του σημείου μπορεί να τροποποιήσουν το σχήμα του συνδέσμου.
* Τα σημεία προσαρμογής ενός συνδέσμου ορίζονται με αυστηρή σειρά σε έναν πίνακα. Τα σημεία προσαρμογής αριθμούνται από το αρχικό σημείο του συνδέσμου μέχρι το τελικό.
* Οι τιμές των σημείων προσαρμογής αντικατοπτρίζουν το ποσοστό του πλάτους/ύψους του σχήματος του συνδέσμου. 
  * Το σχήμα περιορίζεται από τα αρχικό και τελικό σημείο του συνδέσμου πολλαπλασιασμένα με 1000. 
  * Το πρώτο σημείο, το δεύτερο σημείο και το τρίτο σημείο καθορίζουν αντίστοιχα το ποσοστό από το πλάτος, το ποσοστό από το ύψος και το ποσοστό από το πλάτος (ξανά) respectively.
* Για τους υπολογισμούς που καθορίζουν τις συντεταγμένες των σημείων προσαρμογής ενός συνδέσμου, πρέπει να λάβετε υπόψη την περιστροφή του συνδέσμου και την αντανάκλασή του. **Σημείωση** ότι η γωνία περιστροφής για όλους τους συνδέσμους που εμφανίζονται κάτω από **[Τύποι συνδέσμων](/slides/el/nodejs-java/connector/#types-of-connectors)** είναι 0.

#### **Περίπτωση 1**

Σκεφτείτε μια περίπτωση όπου δύο αντικείμενα πλαισίου κειμένου συνδέονται μεταξύ τους μέσω ενός συνδέσμου:

![connector-shape-complex](connector-shape-complex.png)

```javascript
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Αποκτά την πρώτη διαφάνεια στην παρουσίαση
    var sld = pres.getSlides().get_Item(0);
    // Προσθέτει σχήματα που θα ενωθούν μέσω ενός συνδέσμου
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Προσθέτει ένα σύνδεσμο
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // Καθορίζει την κατεύθυνση του συνδέσμου
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // Καθορίζει το χρώμα του συνδέσμου
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Καθορίζει το πάχος της γραμμής του συνδέσμου
    connector.getLineFormat().setWidth(3);
    // Συνδέει τα σχήματα μεταξύ τους με τον σύνδεσμο
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // Αποκτά τα σημεία προσαρμογής για το σύνδεσμο
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Προσαρμογή**

Μπορούμε να αλλάξουμε τις τιμές των σημείων προσαρμογής του συνδέσμου αυξάνοντας το αντίστοιχο ποσοστό πλάτους και ύψους κατά 20% και 200% αντίστοιχα:

```javascript
// Αλλάζει τις τιμές των σημείων προσαρμογής
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Το αποτέλεσμα:

![connector-adjusted-1](connector-adjusted-1.png)

Για να ορίσουμε ένα μοντέλο που να μας επιτρέπει να καθορίσουμε τις συντεταγμένες και το σχήμα των μεμονωμένων τμημάτων του συνδέσμου, ας δημιουργήσουμε ένα σχήμα που αντιστοιχεί στο οριζόντιο στοιχείο του συνδέσμου στο σημείο connector.getAdjustments().get_Item(0):

```javascript
// Σχεδιάζει το κάθετο στοιχείο του συνδέσμου
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```

Το αποτέλεσμα:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Περίπτωση 2**

Στην **Περίπτωση 1**, παρουσιάσαμε μια απλή λειτουργία προσαρμογής συνδέσμου χρησιμοποιώντας βασικές αρχές. Σε κανονικές συνθήκες, πρέπει να λάβετε υπόψη την περιστροφή του συνδέσμου και την απεικόνισή του (που ορίζονται από τις μεθόδους connector.getRotation(), connector.getFrame().getFlipH() και connector.getFrame().getFlipV()). Θα δείξουμε τώρα τη διαδικασία.

Πρώτα, ας προσθέσουμε ένα νέο αντικείμενο πλαισίου κειμένου (**To 1**) στη διαφάνεια (για σκοπούς σύνδεσης) και να δημιουργήσουμε έναν νέο (πράσινο) σύνδεσμο που θα το συνδέει με τα αντικείμενα που έχουμε ήδη δημιουργήσει.

```javascript
// Δημιουργεί ένα νέο αντικείμενο δέσμευσης
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Δημιουργεί ένα νέο σύνδεσμο
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
connector.getLineFormat().setWidth(3);
// Συνδέει αντικείμενα χρησιμοποιώντας το νεοδημιουργημένο σύνδεσμο
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Λαμβάνει τα σημεία προσαρμογής του συνδέσμου
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Αλλάζει τις τιμές των σημείων προσαρμογής
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Το αποτέλεσμα:

![connector-adjusted-3](connector-adjusted-3.png)

Δεύτερον, ας δημιουργήσουμε ένα σχήμα που θα αντιστοιχεί στο οριζόντιο στοιχείο του συνδέσμου που περνά από το νέο σημείο προσαρμογής του συνδέσμου connector.getAdjustments().get_Item(0). Θα χρησιμοποιήσουμε τις τιμές από τα δεδομένα του συνδέσμου για connector.getRotation(), connector.getFrame().getFlipH() και connector.getFrame().getFlipV() και θα εφαρμόσουμε τον δημοφιλή τύπο μετασχηματισμού συντεταγμένων για περιστροφή γύρω από ένα δεδομένο σημείο x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Στην περίπτωσή μας, η γωνία περιστροφής του αντικειμένου είναι 90 μοίρες και ο σύνδεσμος εμφανίζεται κάθετα, επομένως αυτός είναι ο αντίστοιχος κώδικας:

```javascript
// Αποθηκεύει τις συντεταγμένες του συνδέσμου
x = connector.getX();
y = connector.getY();
// Διορθώνει τις συντεταγμένες του συνδέσμου σε περίπτωση που εμφανίζεται
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// Παίρνει την τιμή του σημείου προσαρμογής ως συντεταγμένη
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// Μετατρέπει τις συντεταγμένες επειδή το Sin(90) = 1 και το Cos(90) = 0
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// Καθορίζει το πλάτος του οριζόντιου στοιχείου χρησιμοποιώντας τη δεύτερη τιμή σημείου προσαρμογής
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

Το αποτέλεσμα:

![connector-adjusted-4](connector-adjusted-4.png)

Δείξαμε υπολογισμούς που αφορούν απλές προσαρμογές και σύνθετα σημεία προσαρμογής (σημεία προσαρμογής με γωνίες περιστροφής). Χρησιμοποιώντας τις αποκτηθείσες γνώσεις, μπορείτε να αναπτύξετε το δικό σας μοντέλο (ή να γράψετε κώδικα) για να αποκτήσετε ένα αντικείμενο `GraphicsPath` ή ακόμη και να ορίσετε τις τιμές των σημείων προσαρμογής ενός συνδέσμου βάσει συγκεκριμένων συντεταγμένων διαφάνειας.

## **Εύρεση Γωνίας Γραμμών Συνδέσμου**

1. Δημιουργήστε μια παρουσία της κλάσης.
1. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.
1. Προσπελάστε το σχήμα γραμμής του συνδέσμου.
1. Χρησιμοποιήστε το πλάτος, το ύψος, το ύψος του πλαισίου του σχήματος και το πλάτος του πλαισίου του σχήματος για να υπολογίσετε τη γωνία.

Αυτός ο κώδικας JavaScript δείχνει μια λειτουργία στην οποία υπολογίσαμε τη γωνία για ένα σχήμα γραμμής σύνδεσμου:

```javascript
var pres = new aspose.slides.Presentation("ConnectorLineAngle.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var dir = 0.0;
        var shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var ashp = shape;
            if (ashp.getShapeType() == aspose.slides.ShapeType.Line) {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        } else if (java.instanceOf(shape, "com.aspose.slides.Connector")) {
            var ashp = shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }
        console.log(dir);
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function getDirection(w, h, flipH, flipV) {
    let endLineX = w * (flipH ? -1 : 1);
    let endLineY = h * (flipV ? -1 : 1);
    
    let endYAxisX = 0;
    let endYAxisY = h;

    let angle = Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX);

    if (angle < 0) {
        angle += 2 * Math.PI;
    }

    return angle * 180.0 / Math.PI;
}
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να καταλάβω αν ένας σύνδεσμος μπορεί να «κολλήσει» σε ένα συγκεκριμένο σχήμα;**

Ελέγξτε ότι το σχήμα εκθέτει [σημεία σύνδεσης](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/getconnectionsitecount/). Εάν δεν υπάρχουν ή ο αριθμός είναι μηδέν, η πρόσδεση δεν είναι διαθέσιμη· σε αυτήν την περίπτωση, χρησιμοποιήστε ελεύθερα άκρα και τοποθετήστε τα χειροκίνητα. Είναι λογικό να ελέγχετε τον αριθμό των σημείων πριν την προσκόλληση.

**Τι συμβαίνει με έναν σύνδεσμο αν διαγράψω ένα από τα συνδεδεμένα σχήματα;**

Τα άκρα του θα αποσυνδεθούν· ο σύνδεσμος παραμένει στη διαφάνεια ως απλή γραμμή με ελεύθερο αρχικό/τελικό σημείο. Μπορείτε είτε να τον διαγράψετε είτε να επαναπεριγράψετε τις συνδέσεις και, εάν χρειάζεται, να κάνετε [reroute](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/connector/reroute/).

**Διατηρούνται οι συνδέσεις του συνδέσμου όταν αντιγράφουμε μια διαφάνεια σε άλλη παρουσίαση;**

Γενικά ναι, εφόσον αντιγραφούν και τα αντίστοιχα σχήματα-στόχοι. Εάν η διαφάνεια εισαχθεί σε άλλο αρχείο χωρίς τα συνδεδεμένα σχήματα, τα άκρα γίνονται ελεύθερα και θα χρειαστεί να τα επανασυνδέσετε.