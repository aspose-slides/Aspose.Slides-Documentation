---
title: Διαχείριση Συνδέσμων σε Παρουσιάσεις σε .NET
linktitle: Σύνδεσμος
type: docs
weight: 10
url: /el/net/connector/
keywords:
- σύνδεσμος
- τύπος συνδέσμου
- σημείο συνδέσμου
- γραμμή συνδέσμου
- γωνία συνδέσμου
- σημείο σύνδεσης
- σημείο ρύθμισης
- σύνδεση σχημάτων
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, συνδέετε, επαναδρομολογείτε, ρυθμίζετε και ελέγχετε ευθείς, λυγρούς και καμπυλωτούς συνδέσμους PowerPoint με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Ένα σύνδεσμο είναι μια γραμμή που μπορεί να παραμένει συνδεδεμένο με δύο σχήματα όταν κινούνται τα σχήματα. Τα άκρα του συνδέονται σε σημεία σύνδεσης, που απεικονίζονται με πράσινες κουκκίδες στο PowerPoint. Ορισμένοι λυγρές και καμπυλωτές σύνδεσμοι εκθέτουν επίσης σημεία ρύθμισης, που απεικονίζονται με πορτοκαλί κουκκίδες, και ελέγχουν τη θέση των μεμονωμένων τμημάτων του συνδέσμου.

Το Aspose.Slides αντιπροσωπεύει τους συνδέσμους μέσω της διεπαφής [IConnector](https://reference.aspose.com/slides/el/net/aspose.slides/iconnector/). Μπορείτε να τους δημιουργήσετε, να συνδέσετε τα άκρα τους σε σχήματα, να επιλέξετε σημεία σύνδεσης, να αλλάξετε τη διαδρομή τους και να τροποποιήσετε τη γεωμετρία των συνδέσμων που διαθέτουν σημεία ρύθμισης.

## **Τύποι Συνδέσμων**

Η απαρίθμηση [ShapeType](https://reference.aspose.com/slides/el/net/aspose.slides/shapetype/) περιλαμβάνει προκαθορισμένα ευθεία, λυγρά και καμπυλωτά συνδέσμους. Ο παρακάτω πίνακας εμφανίζει τις διαθέσιμες γεωμετρίες συνδέσμων και τον αριθμό των σημείων ρύθμισης που ορίζονται σε κάθε προεπιλογή.

| Σύνδεσμος | Εικόνα | Αριθμός σημείων ρύθμισης |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Ο αριθμός και το νόημα των σημείων ρύθμισης αποτελούν μέρος του επιλεγμένου προεπιλεγμένου συνδέσμου. Μην υποθέτετε ότι δύο διαφορετικοί τύποι συνδέσμων εκθέτουν την ίδια διάταξη συλλογής.

## **Σύνδεση Δύο Σχημάτων**

Χρησιμοποιήστε το [IShapeCollection.AddConnector](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addconnector/) για να προσθέσετε ένα σύνδεσμο και να ορίσετε τις ιδιότητες [StartShapeConnectedTo](https://reference.aspose.com/slides/el/net/aspose.slides/connector/startshapeconnectedto/) και [EndShapeConnectedTo](https://reference.aspose.com/slides/el/net/aspose.slides/connector/endshapeconnectedto/). Αφού συνδεθούν και τα δύο άκρα, το [IConnector.Reroute](https://reference.aspose.com/slides/el/net/aspose.slides/iconnector/reroute/) επιλέγει μια σύντομη διαδρομή μεταξύ των σχημάτων.

Το παρακάτω παράδειγμα συνδέει μια έλλειψη και ένα ορθογώνιο σχήμα με έναν λυγρό σύνδεσμο:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;
connector.Reroute();

presentation.Save("connected-shapes.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Προειδοποίηση" %}}
Η κλήση του `Reroute` μπορεί να αλλάξει τις τιμές των [StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/el/net/aspose.slides/connector/startshapeconnectionsiteindex/) και [EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/el/net/aspose.slides/connector/endshapeconnectionsiteindex/). Αναθέστε συγκεκριμένα σημεία σύνδεσης μετά το ξαναδρόμημα εάν αυτά τα σημεία πρέπει να παραμείνουν σταθερά.
{{% /alert %}}

## **Επιλογή Σημείου Σύνδεσης**

Κάθε σχήμα που μπορεί να συνδεθεί αναφέρει τον αριθμό των σημείων του μέσω του [ConnectionSiteCount](https://reference.aspose.com/slides/el/net/aspose.slides/shape/connectionsitecount/). Επικυρώστε ένα προτιμώμενο δείκτη σημείου με μηδενική βάση πριν τον αναθέσετε σε ένα άκρο συνδέσμου· οι αριθμοί σημείων διαφέρουν ανάλογα με τη γεωμετρία του σχήματος.

Αυτό το παράδειγμα συνδέει τον σύνδεσμο σε ένα συγκεκριμένο σημείο της έλλειψης όταν αυτό το σημείο υπάρχει:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;

uint preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse.ConnectionSiteCount)
{
    connector.StartShapeConnectionSiteIndex = preferredSiteIndex;
}
else
{
    Console.WriteLine($"The ellipse has only {ellipse.ConnectionSiteCount} connection sites.");
}

presentation.Save("specific-connection-site.pptx", SaveFormat.Pptx);
```

## **Ρύθμιση Σημείου Συνδέσμου**

Οι σύνδεσμοι με σημεία ρύθμισης τα εμφανίζουν μέσω του [IGeometryShape.Adjustments](https://reference.aspose.com/slides/el/net/aspose.slides/igeometryshape/adjustments/). Εξετάστε κάθε [IAdjustValue](https://reference.aspose.com/slides/el/net/aspose.slides/iadjustvalue/) και ελέγξτε το [Type](https://reference.aspose.com/slides/el/net/aspose.slides/adjustvalue/type/) πριν αλλάξετε το [RawValue](https://reference.aspose.com/slides/el/net/aspose.slides/adjustvalue/rawvalue/). Οι γενικοί κανόνες για την ταυτοποίηση προεπιλεγμένων ρυθμίσεων σχήματος περιγράφονται στη σελίδα [Shape Manipulation](/slides/el/net/shape-manipulations/).

Ο αριθμός, η σειρά, το νόημα και το έγκυρο εύρος τιμών των ρυθμίσεων του συνδέσμου εξαρτώνται από το προεπιλεγμένο τύπο συνδέσμου. Η ιδιότητα `Type` είναι μόνο για ανάγνωση, ενώ η τιμή της ρύθμισης είναι εγγράψιμη. Η μόνο για ανάγνωση ιδιότητα [Name](https://reference.aspose.com/slides/el/net/aspose.slides/adjustvalue/name/) παρέχει πρόσθετη ταυτοποίηση όταν ένας σύνδεσμος περιέχει περισσότερες από μία ρυθμίσεις του ίδιου σημασιολογικού τύπου.

### **Διαδρομή Περιβάλλοντας Ένα Εμπόδιο**

Στη παρακάτω διάταξη, ένας σύνδεσμος `BentConnector5` μεταξύ δύο σχημάτων περνά μέσα από ένα τρίτο σχήμα:

![connector-obstruction](connector-obstruction.png)

Αυτός ο κώδικας δημιουργεί τον εμπόδιο σύνδεσμο:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

presentation.Save("connector-obstruction.pptx", SaveFormat.Pptx);
```

Μετακινώντας την κατακόρυφη κάμψη αλλάζει τη διαδρομή έτσι ώστε ο σύνδεσμος να παρακάμψει το εμπόδιο:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Αντί να υποθέτετε ότι ο δείκτης συλλογής `1` αντιπροσωπεύει πάντα την κατακόρυφη κάμψη, αυτό το παράδειγμα αναζητά το `ConnectorBendPositionY` και το τροποποιεί μόνο όταν υπάρχει ο αναμενόμενος σημασιολογικός τύπος:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend is null)
{
    Console.WriteLine("The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend.RawValue = 60000;
    presentation.Save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
}
```

Ένα `BentConnector5` διαθέτει δύο ρυθμίσεις `ConnectorBendPositionX` και μία ρύθμιση `ConnectorBendPositionY`. Εάν ο τύπος που χρειάζεστε εμφανίζεται περισσότερες από μία φορές, ελέγξτε το `Name` και τη γνωστή γεωμετρία εκείνης της προεπιλογής προτού επιλέξετε ένα. Εάν μια ρύθμιση αναφέρει `ShapeAdjustmentType.Custom`, θεωρήστε το νόημα και το εύρος της ως ειδικό για την προεπιλογή και μην το αλλάξετε μέχρι να είναι γνωστή αυτή η σύμβαση.

## **Συσχέτιση Τιμών Ρύθμισης με Γεωμετρία Συνδέσμου**

Για λυγρούς συνδέσμους, οι τιμές ρύθμισης μπορούν να χρησιμοποιηθούν για την εκτίμηση των θέσεων μεμονωμένων τμημάτων. Αυτοί οι υπολογισμοί είναι ειδικοί για τον προεπιλεγμένο σύνδεσμο:

- `BentConnector4` συνήθως εκθέτει μία ρύθμιση `ConnectorBendPositionX` και μία ρύθμιση `ConnectorBendPositionY`.
- Για αυτές τις θέσεις κάμψης, το `RawValue / 100000f` παράγει το κλάσμα του πλάτους ή του ύψους του πλαισίου του συνδέσμου που χρησιμοποιείται στα παρακάτω παραδείγματα.
- Ένα πλαίσιο συνδέσμου μπορεί να περιστραφεί ή να αντιστραφεί, επομένως οι συντεταγμένες του πλαισίου πρέπει να μετασχηματιστούν πριν συγκριθούν με τις συντεταγμένες της διαφάνειας.

Τα παρακάτω παραδείγματα χρησιμοποιούν πρώτα το `Type` για την ταυτοποίηση των ρυθμίσεων. Δεν αντιμετωπίζουν τους δείκτες συλλογής ως φορητούς ταυτοποιητές.

### **Μη Περιστρεφόμενος Σύνδεσμος**

Η αρχική διάταξη περιέχει δύο σχήματα κειμένου συνδεδεμένα με έναν `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Αυτό το παράδειγμα εξετάζει το σύνδεσμο και παίρνει τις οριζόντιες και κατακόρυφες ρυθμίσεις κάμψης:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
targetShape.TextFrame.Text = "To";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
}
```

Για να αλλάξετε και τις δύο κάμψεις, εντοπίστε κάθε αναμενόμενο τύπο και τροποποιήστε τις τιμές μόνο αφού και οι δύο έχουν βρεθεί:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;
    presentation.Save("connector-adjusted.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα είναι ένας σύνδεσμος των οποίων τα οριζόντια και κατακόρυφα τμήματα έχουν μετακινηθεί:

![connector-adjusted-1](connector-adjusted-1.png)

Μόλις γνωστοποιηθούν οι σημασιολογικοί τύποι, οι τιμές τους μπορούν να μετατραπούν σε συντεταγμένες πλαισίου συνδέσμου. Αυτό το παράδειγμα σχεδιάζει ένα λεπτό ορθογώνιο πάνω από το κατακόρ

υφο τμήμα που ελέγχεται από τις δύο ρυθμίσεις κάμψης:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    var x = connector.X + connector.Width * horizontalBend.RawValue / 100000f;
    var y = connector.Y;
    var height = connector.Height * verticalBend.RawValue / 100000f;
    slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 1, height);
    presentation.Save("connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

Το σχήμα οδηγίας σηματοδοτεί το υπολογισμένο τμήμα:

![connector-adjusted-2](connector-adjusted-2.png)

### **Περιστρεφόμενος ή Αντεστραμμένος Σύνδεσμος**

Όταν η ίδια γεωμετρία συνδέσμου είναι προσανατολισμένη κατακόρυφα, οι τιμές του [Frame](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/frame/), [FlipH](https://reference.aspose.com/slides/el/net/aspose.slides/shapeframe/fliph/), και [FlipV](https://reference.aspose.com/slides/el/net/aspose.slides/shapeframe/flipv/) επηρεάζουν τη μετατροπή από τις συντεταγμένες πλαισίου συνδέσμου σε συντεταγμένες διαφάνειας.

Αυτό το παράδειγμα δημιουργεί και ρυθμίζει τον κατακόρυφα προσανατολισμένο σύνδεσμο:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
targetShape.TextFrame.Text = "To 1";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        adjustment.RawValue += 20000;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        adjustment.RawValue += 200000;
    }
}

presentation.Save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
```

Ο ρυθμισμένος σύνδεσμος εμφανίζεται κατακόρυφα μεταξύ των σχημάτων:

![connector-adjusted-3](connector-adjusted-3.png)

Για μια αυθαίρετη γωνία περιστροφής `alpha`, περιστρέψτε ένα σημείο πλαισίου συνδέσμου `(x, y)` γύρω από το κέντρο του πλαισίου `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Ο παρακάτω κώδικας διαχειρίζεται τον προσανατολισμό των 90 μοιρών που χρησιμοποιείται σε αυτό το παράδειγμα και σχεδιάζει έναν κόκκινο οδηγό πάνω από το αντίστοιχο τμήμα του συνδέσμου:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;

    var x = connector.X;
    var y = connector.Y;
    if (connector.Frame.FlipH == NullableBool.True)
    {
        x += connector.Width;
    }
    if (connector.Frame.FlipV == NullableBool.True)
    {
        y += connector.Height;
    }

    x += connector.Width * horizontalBend.RawValue / 100000f;
    var rotatedX = connector.Frame.CenterX - y + connector.Frame.CenterY;
    var rotatedY = x - connector.Frame.CenterX + connector.Frame.CenterY;
    var segmentWidth = connector.Height * verticalBend.RawValue / 100000f;
    var guide = slide.Shapes.AddAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    guide.LineFormat.FillFormat.FillType = FillType.Solid;
    guide.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

Ο κόκκινος οδηγός σηματοδοτεί το υπολογισμένο τμήμα μετά τον μετασχηματισμό των συντεταγμένων:

![connector-adjusted-4](connector-adjusted-4.png)

Αυτοί οι τύποι περιγράφουν τις προεπιλογές που χρησιμοποιούνται στα παραδείγματα, όχι ένα καθολικό μοντέλο συνδέσμου. Επικυρώστε τους τύπους ρυθμίσεων, τον προσανατολισμό του πλαισίου και τα εύρη τιμών πριν εφαρμόσετε τον ίδιο υπολογισμό σε διαφορετική προεπιλογή.

## **Εύρεση Γωνίας Κατεύθυνσης Συνδέσμου**

Η κατεύθυνση ενός ευθείου συνδέσμου μπορεί να υπολογιστεί από το πλάτος και το ύψος του, με εφαρμοσμένες οριζόντιες και κατακόρυφες αναστροφές. Το παρακάτω παράδειγμα αναφέρει τη διπλωμένη (clockwise) γωνία από τον θετικό οριζόντιο άξονα στις συντεταγμένες της διαφάνειας:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

var flipH = connector.Frame.FlipH == NullableBool.True;
var flipV = connector.Frame.FlipV == NullableBool.True;
var deltaX = connector.Width * (flipH ? -1 : 1);
var deltaY = connector.Height * (flipV ? -1 : 1);
var angle = Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI;

if (angle < 0)
{
    angle += 360;
}

Console.WriteLine($"Connector direction: {angle:F2} degrees");
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να διαπιστώ αν ένας σύνδεσμος μπορεί να συνδεθεί με ένα σχήμα;**

Ελέγξτε το `ConnectionSiteCount` του σχήματος. Ένας θετικός αριθμός σημαίνει ότι το σχήμα εκθέτει σημεία σύνδεσης. Επικυρώστε τον επιλεγμένο δείκτη σημείου πριν τον αναθέσετε σε οποιοδήποτε άκρο συνδέσμου.

**Μπορώ να ταυτοποιήσω μια ρύθμιση συνδέσμου με τον δείκτη της συλλογής του;**

Ένας δείκτης είναι σημαντικός μόνο για μια γνωστή προεπιλογή συνδέσμου και τη διάταξη της συλλογής. Ελέγξτε το `IAdjustValue.Type` πριν τροποποιήσετε μια τιμή και χρησιμοποιήστε το `IAdjustValue.Name` ως πρόσθετη πληροφορία όταν ο ίδιος σημασιολογικός τύπος εμφανίζεται περισσότερες από μία φορές.

**Τι συμβαίνει όταν ένα συνδεδεμένο σχήμα διαγραφεί;**

Το αντίστοιχο άκρο του συνδέσμου αποσυνδέεται. Ο σύνδεσμος παραμένει στη διαφάνεια και μπορεί να διαγραφεί, να τοποθετηθεί ως ελεύθερη γραμμή ή να συνδεθεί με άλλο σχήμα.

**Διατηρούνται οι δεσμοί των συνδέσμων όταν αντιγράφεται μια διαφάνεια;**

Οι δεσμοί διατηρούνται γενικά όταν τα συνδεδεμένα σχήματα αντιγράφονται μαζί με τη διαφάνεια. Εάν ένας σύνδεσμος αντιγραφεί χωρίς ένα από τα σχήματα-στόχους του, το επηρεαζόμενο άκρο πρέπει να συνδεθεί εκ νέου.