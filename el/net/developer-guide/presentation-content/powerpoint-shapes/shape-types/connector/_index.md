---
title: "Διαχείριση Συνδέσμων σε Παρουσιάσεις στο .NET"
linktitle: "Σύνδεσμος"
type: docs
weight: 10
url: /el/net/connector/
keywords:
- σύνδεσμος
- τύπος συνδέσμου
- σημείο συνδέσμου
- γραμμή συνδέσμου
- γωνία συνδέσμου
- σύνδεση σχημάτων
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ενδυναμώνει τις εφαρμογές .NET να σχεδιάζουν, να συνδέουν και να αυτόματα δρομολογούν γραμμές σε διαφάνειες PowerPoint—αποκτήστε πλήρη έλεγχο πάνω σε ευθείες, αγκόνα και καμπυλωτούς συνδέσμους."
---
## **Εισαγωγή**

Ένας σύνδεσμος PowerPoint είναι μια ειδική γραμμή που συνδέει ή συνδέει δύο σχήματα μεταξύ τους και παραμένει προσαρμοσμένος στα σχήματα ακόμη και όταν αυτά μετακινούνται ή τοποθετούνται ξανά σε μια δεδομένη διαφάνεια. 

Οι σύνδεσμοι συνδέονται συνήθως με *σημεία σύνδεσης* (πράσινα σημεία), τα οποία υπάρχουν εξ' ορισμού σε όλα τα σχήματα. Τα σημεία σύνδεσης εμφανίζονται όταν ο κέρσορας πλησιάσει σε αυτά.

*Σημεία ρύθμισης* (πορτοκαλί σημεία), που υπάρχουν μόνο σε ορισμένους συνδέσμους, χρησιμοποιούνται για την τροποποίηση των θέσεων και των σχημάτων των συνδέσμων.

## **Τύποι Συνδέσμων**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε ευθείς, γωνιακούς (αγκυλωτούς) και καμπυλωτούς συνδέσμους. 

Το Aspose.Slides παρέχει αυτούς τους συνδέσμους:

| Σύνδεσμος                      | Image                                                        | Αριθμός σημείων ρύθμισης |
| ------------------------------ | ------------------------------------------------------------ | ------------------------ |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                        |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                        |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                        |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                        |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                        |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                        |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                        |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                        |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                        |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                        |

## **Συνδέστε Σχήματα Χρησιμοποιώντας Σύνδεσμους**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του ευρετηρίου της.
1. Προσθέστε δύο [AutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/) στη διαφάνεια χρησιμοποιώντας τη μέθοδο `AddAutoShape` που παρέχεται από το αντικείμενο `Shapes`.
1. Προσθέστε έναν σύνδεσμο χρησιμοποιώντας τη μέθοδο `AddConnector` που εκτίθεται από το αντικείμενο `Shapes`, ορίζοντας τον τύπο του συνδέσμου.
1. Συνδέστε τα σχήματα χρησιμοποιώντας τον σύνδεσμο.
1. Καλέστε τη μέθοδο `Reroute` για να εφαρμόσετε τη πιο σύντομη διαδρομή σύνδεσης.
1. Αποθηκεύστε την παρουσίαση. 

```c#
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
using (Presentation input = new Presentation())
{                
    // Πρόσβαση στη συλλογή σχημάτων για μια συγκεκριμένη διαφάνεια
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Προσθέτει ένα αυτόματο σχήμα Έλλειψη
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Προσθέτει ένα αυτόματο σχήμα Ορθογώνιο
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Προσθέτει ένα σχήμα σύνδεσμου στη συλλογή σχημάτων της διαφάνειας
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Συνδέει τα σχήματα χρησιμοποιώντας τον σύνδεσμο
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Καλεί τη μέθοδο reroute που ορίζει τη αυτόματη συντομότερη διαδρομή μεταξύ των σχημάτων
    connector.Reroute();

    // Αποθηκεύει την παρουσίαση
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Η μέθοδος `Connector.Reroute` επαναδρομολογεί ένα σύνδεσμο και τον αναγκάζει να ακολουθήσει τη συντομότερη δυνατή διαδρομή μεταξύ των σχημάτων. Για να πετύχει αυτό, η μέθοδος μπορεί να αλλάξει τα σημεία `StartShapeConnectionSiteIndex` και `EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Καθορίστε Σημείο Σύνδεσης**
Αν θέλετε ένας σύνδεσμος να συνδέει δύο σχήματα χρησιμοποιώντας συγκεκριμένα σημεία στα σχήματα, πρέπει να ορίσετε τα προτιμώμενα σημεία σύνδεσης με αυτόν τον τρόπο:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του ευρετηρίου της.
1. Προσθέστε δύο [AutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/) στη διαφάνεια χρησιμοποιώντας τη μέθοδο `AddAutoShape` που παρέχεται από το αντικείμενο `Shapes`.
1. Προσθέστε έναν σύνδεσμο χρησιμοποιώντας τη μέθοδο `AddConnector` που εκτίθεται από το αντικείμενο `Shapes`, ορίζοντας τον τύπο του συνδέσμου.
1. Συνδέστε τα σχήματα χρησιμοποιώντας τον σύνδεσμο. 
1. Ορίστε τα προτιμώμενα σημεία σύνδεσης στα σχήματα. 
1. Αποθηκεύστε την παρουσίαση.

```c#
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
using (Presentation presentation = new Presentation())
{
    // Πρόσβαση στη συλλογή σχημάτων για μια συγκεκριμένη διαφάνεια
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // Προσθέτει ένα σχήμα σύνδεσμου στη συλλογή σχημάτων της διαφάνειας
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // Προσθέτει ένα αυτόματο σχήμα Έλλειψη
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Προσθέτει ένα αυτόματο σχήμα Ορθογώνιο
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // Συνδέει τα σχήματα χρησιμοποιώντας τον σύνδεσμο
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Ορίζει το προτιμώμενο δείκτη σημείου σύνδεσης στο σχήμα Έλλειψη
    uint wantedIndex = 6;

    // Ελέγχει εάν ο προτιμώμενος δείκτης είναι μικρότερος από τον μέγιστο αριθμό σημείων σύνδεσης
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // Ορίζει το προτιμώμενο σημείο σύνδεσης στο αυτόματο σχήμα Έλλειψη
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // Αποθηκεύει την παρουσίαση
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```

## **Ρυθμίστε Σημείο Συνδέσμου**

Μπορείτε να ρυθμίσετε έναν υπάρχοντα σύνδεσμο μέσω των σημείων ρύθμισης του. Μόνο σύνδεσμοι με σημεία ρύθμισης μπορούν να τροποποιηθούν με αυτόν τον τρόπο. Δείτε τον πίνακα κάτω από **[Τύποι συνδέσμων.](/slides/el/net/connector/#types-of-connectors)** 

### **Απλή Περίπτωση**

Σκεφτείτε μια περίπτωση όπου ένας σύνδεσμος μεταξύ δύο σχημάτων (A και B) περνά από ένα τρίτο σχήμα (C):

![connector-obstruction](connector-obstruction.png)

```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```

Για να αποφύγουμε ή να παρακάμψουμε το τρίτο σχήμα, μπορούμε να ρυθμίσουμε τον σύνδεσμο μετακινώντας την κατακόρυφη γραμμή του προς τα αριστερά με αυτόν τον τρόπο:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **Πολύπλοκες Περιπτώσεις** 

Για να εκτελέσετε πιο σύνθετες ρυθμίσεις, πρέπει να λάβετε υπόψη τα εξής:

* Το ρυθμιζόμενο σημείο ενός συνδέσμου συνδέεται στενά με έναν τύπο που υπολογίζει και καθορίζει τη θέση του. Έτσι, αλλαγές στη θέση του σημείου μπορεί να τροποποιήσουν το σχήμα του συνδέσμου.
* Τα σημεία ρύθμισης ενός συνδέσμου ορίζονται με αυστηρή σειρά σε έναν πίνακα. Τα σημεία ρύθμισης αριθμούνται από το σημείο εκκίνησης του συνδέσμου μέχρι το σημείο τερματισμού του.
* Οι τιμές των σημείων ρύθμισης αντανακλούν το ποσοστό του πλάτους/ύψους του σχήματος του συνδέσμου.
  * Το σχήμα περιορίζεται από τα σημεία εκκίνησης και τερματισμού του συνδέσμου πολλαπλασιασμένα με 1000.
  * Το πρώτο, το δεύτερο και το τρίτο σημείο καθορίζουν αντίστοιχα το ποσοστό από το πλάτος, το ποσοστό από το ύψος και ξανά το ποσοστό από το πλάτος.
* Για τους υπολογισμούς που καθορίζουν τις συντεταγμένες των σημείων ρύθμισης ενός συνδέσμου, πρέπει να λάβετε υπόψη την περιστροφή του συνδέσμου και την αντανάκλασή του. **Σημείωση** ότι η γωνία περιστροφής για όλους τους συνδέσμους που εμφανίζονται κάτω από **[Τύποι συνδέσμων](/slides/el/net/connector/#types-of-connectors)** είναι 0.

#### **Περίπτωση 1**

Σκεφτείτε μια περίπτωση όπου δύο αντικείμενα πλαισίου κειμένου είναι συνδεδεμένα μεταξύ τους μέσω ενός συνδέσμου:

![connector-shape-complex](connector-shape-complex.png)

```c#
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
// Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
ISlide sld = pres.Slides[0];
// Προσθέτει σχήματα που θα συνδεθούν μέσω ενός συνδέσμου
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// Προσθέτει έναν σύνδεσμο
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// Καθορίζει την κατεύθυνση του συνδέσμου
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// Καθορίζει το χρώμα του συνδέσμου
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// Καθορίζει το πάχος της γραμμής του συνδέσμου
connector.LineFormat.Width = 3;

// Συνδέει τα σχήματα μεταξύ τους με τον σύνδεσμο
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// Λαμβάνει τα σημεία ρύθμισης για τον σύνδεσμο
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**Ρύθμιση**

Μπορούμε να αλλάξουμε τις τιμές των σημείων ρύθμισης του συνδέσμου αυξάνοντας το αντίστοιχο ποσοστό πλάτους και ύψους κατά 20% και 200% αντίστοιχα:

```c#
// Αλλάζει τις τιμές των σημείων ρύθμισης
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Το αποτέλεσμα:

![connector-adjusted-1](connector-adjusted-1.png)

Για να ορίσουμε ένα μοντέλο που να μας επιτρέπει να προσδιορίζουμε τις συντεταγμένες και το σχήμα των μεμονωμένων τμημάτων του συνδέσμου, ας δημιουργήσουμε ένα σχήμα που αντιστοιχεί στο οριζόντιο συστατικό του συνδέσμου στο σημείο connector.Adjustments[0]:

```c#
// Σχεδιάζει το κάθετο συστατικό του συνδέσμου

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Το αποτέλεσμα:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Περίπτωση 2**

Στην **Περίπτωση 1**, δείξαμε μια απλή λειτουργία ρύθμισης συνδέσμου χρησιμοποιώντας βασικές αρχές. Σε κανονικές καταστάσεις, πρέπει να λάβετε υπόψη την περιστροφή του συνδέσμου και την απεικόνισή του (που ορίζονται από τα connector.Rotation, connector.Frame.FlipH και connector.Frame.FlipV). Θα δείξουμε τώρα τη διαδικασία.

Αρχικά, ας προσθέσουμε ένα νέο αντικείμενο πλαισίου κειμένου (**To 1**) στη διαφάνεια (για σκοπούς σύνδεσης) και να δημιουργήσουμε έναν νέο (πράσινο) σύνδεσμο που το συνδέει με τα αντικείμενα που έχουμε ήδη δημιουργήσει.

```c#
// Δημιουργεί ένα νέο αντικείμενο σύνδεσης
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// Δημιουργεί έναν νέο σύνδεσμο
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// Συνδέει αντικείμενα χρησιμοποιώντας τον πρόσφατα δημιουργημένο σύνδεσμο
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// Παίρνει τα σημεία ρύθμισης του συνδέσμου
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// Αλλάζει τις τιμές των σημείων ρύθμισης 
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Το αποτέλεσμα:

![connector-adjusted-3](connector-adjusted-3.png)

Δεύτερον, ας δημιουργήσουμε ένα σχήμα που θα αντιστοιχεί στο οριζόντιο συστατικό του συνδέσμου που περνά από το νέο σημείο ρύθμισης του συνδέσμου connector.Adjustments[0]. Θα χρησιμοποιήσουμε τις τιμές από τα δεδομένα του συνδέσμου για connector.Rotation, connector.Frame.FlipH και connector.Frame.FlipV και θα εφαρμόσουμε τον δημοφιλές τύπο μετασχηματισμού συντεταγμένων για περιστροφή γύρω από ένα δεδομένο σημείο x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Στην περίπτωση μας, η γωνία περιστροφής του αντικειμένου είναι 90 μοίρες και το σύνδεσμο εμφανίζεται κάθετα, έτσι αυτός είναι ο αντίστοιχος κώδικας:

```c#
// Αποθηκεύει τις συντεταγμένες του συνδέσμου
x = connector.X;
y = connector.Y;
// Διορθώνει τις συντεταγμένες του συνδέσμου σε περίπτωση που εμφανιστεί
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// Λαμβάνει την τιμή του σημείου ρύθμισης ως συντεταγμένη
x += connector.Width * adjValue_0.RawValue / 100000;
//  Μετατρέπει τις συντεταγμένες καθώς Sin(90) = 1 και Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// Προσδιορίζει το πλάτος του οριζόντιου συστατικού χρησιμοποιώντας την τιμή του δεύτερου σημείου ρύθμισης
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

```

Το αποτέλεσμα:

![connector-adjusted-4](connector-adjusted-4.png)

Δείξαμε υπολογισμούς που περιλαμβάνουν απλές ρυθμίσεις και σύνθετα σημεία ρύθμισης (σημεία ρύθμισης με γωνίες περιστροφής). Χρησιμοποιώντας τις αποκτηθείσες γνώσεις, μπορείτε να αναπτύξετε το δικό σας μοντέλο (ή να γράψετε κώδικα) για να λάβετε ένα αντικείμενο `GraphicsPath` ή ακόμη και να ορίσετε τις τιμές των σημείων ρύθμισης ενός συνδέσμου βάσει συγκεκριμένων συντεταγμένων διαφάνειας.

## **Βρείτε τη Γωνία των Γραμμών Συνδέσμου**
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του ευρετηρίου της.
1. Πρόσβαση στο σχήμα γραμμής του συνδέσμου. 
1. Χρησιμοποιήστε το πλάτος, το ύψος, το ύψος του πλαισίου σχήματος και το πλάτος του πλαισίου σχήματος για να υπολογίσετε τη γωνία.

```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να διαπιστώ αν ένας σύνδεσμος μπορεί να «κολλήσει» σε ένα συγκεκριμένο σχήμα;**

Ελέγξτε ότι το σχήμα εκθέτει [σημεία σύνδεσης](https://reference.aspose.com/slides/el/net/aspose.slides/shape/connectionsitecount/). Εάν δεν υπάρχουν ή ο αριθμός είναι μηδέν, η δυνατότητα «κολλήματος» δεν είναι διαθέσιμη· σε αυτήν την περίπτωση, χρησιμοποιήστε ελεύθερα άκρα και τοποθετήστε τα χειροκίνητα. Είναι λογικό να ελέγχετε τον αριθμό των σημείων πριν την σύνδεση.

**Τι συμβαίνει με έναν σύνδεσμο αν διαγράψω ένα από τα συνδεδεμένα σχήματα;**

Τα άκρα του θα αποσυνδεθούν· ο σύνδεσμος παραμένει στη διαφάνεια ως απλή γραμμή με ελεύθερα άκρα. Μπορείτε είτε να το διαγράψετε είτε να επαναπροσδιορίσετε τις συνδέσεις και, εφόσον χρειαστεί, να το [επαναδρομολογήσετε](https://reference.aspose.com/slides/el/net/aspose.slides/connector/reroute/).

**Διατηρούνται οι συνδέσεις των συνδέσμων όταν αντιγράφεται μια διαφάνεια σε άλλη παρουσίαση;**

Γενικά ναι, εφόσον τα αντίστοιχα σχήματα αντιγραφούν επίσης. Εάν η διαφάνεια εισαχθεί σε άλλο αρχείο χωρίς τα συνδεδεμένα σχήματα, τα άκρα γίνονται ελεύθερα και θα χρειαστεί να τα επανασυνδέσετε.