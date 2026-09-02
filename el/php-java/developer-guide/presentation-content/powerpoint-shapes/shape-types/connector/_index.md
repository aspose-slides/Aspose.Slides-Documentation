---
title: Διαχείριση Συνδέσμων σε Παρουσιάσεις με PHP
linktitle: Σύνδεσμος
type: docs
weight: 10
url: /el/php-java/connector/
keywords:
- σύνδεσμος
- τύπος συνδέσμου
- σημείο συνδέσμου
- γραμμή συνδέσμου
- γωνία συνδέσμου
- σημείο σύνδεσης
- σημείο προσαρμογής
- σύνδεση σχημάτων
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, να συνδέετε, να αλλάζετε διαδρομή, να προσαρμόζετε και να ελέγχετε ευθείς, λυγούς και κυρτούς συνδέσμους PowerPoint με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Ένας σύνδεσμος είναι μια γραμμή που μπορεί να παραμείνει προσαρτημένη σε δύο σχήματα όταν μετακινηθεί το ένα ή το άλλο σχήμα. Τα άκρα του συνδέονται με σημεία σύνδεσης, τα οποία απεικονίζονται με πράσινες κουκκίδες στο PowerPoint. Ορισμένοι λυγόμενοι και κυρτοί σύνδεσμοι εκθέτουν επίσης σημεία προσαρμογής, τα οποία απεικονίζονται με πορτοκαλί κουκκίδες, και ελέγχουν τη θέση των μεμονωμένων τμημάτων του συνδέσμου.

Η Aspose.Slides αντιπροσωπεύει τους συνδέσμους μέσω της κλάσης [Connector](https://reference.aspose.com/slides/el/php-java/aspose.slides/connector/) . Μπορείτε να τους δημιουργήσετε, να συνδέσετε τα άκρα τους με σχήματα, να επιλέξετε σημεία σύνδεσης, να τους αλλάξετε διαδρομή και να τροποποιήσετε τη γεωμετρία των συνδέσμων που έχουν σημεία προσαρμογής.

## **Τύποι Συνδέσμων**

Η κλάση [ShapeType](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapetype/) περιλαμβάνει προεπιλεγμένους ευθείς, λυγόμενους και κυρτούς συνδέσμους. Ο παρακάτω πίνακας δείχνει τις διαθέσιμες γεωμετρίες συνδέσμων και τον αριθμό σημείων προσαρμογής που ορίζονται από κάθε προεπιλογή.

| Σύνδεσμος | Εικόνα | Αριθμός σημείων προσαρμογής |
|---|---|---|
| `ShapeType::Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType::BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType::BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType::BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType::CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType::CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Ο αριθμός και το νόημα των σημείων προσαρμογής αποτελούν μέρος της επιλεγμένης προεπιλογής του συνδέσμου. Μην υποθέτετε ότι δύο διαφορετικοί τύποι συνδέσμου εκθέτουν την ίδια διάταξη συλλογής.

## **Σύνδεση Δύο Σχημάτων**

Χρησιμοποιήστε την μέθοδο [ShapeCollection::addConnector](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addconnector/) για να προσθέσετε έναν σύνδεσμο και τις μεθόδους [Connector::setStartShapeConnectedTo](https://reference.aspose.com/slides/el/php-java/aspose.slides/connector/setstartshapeconnectedto/) και [Connector::setEndShapeConnectedTo](https://reference.aspose.com/slides/el/php-java/aspose.slides/connector/setendshapeconnectedto/) για να συνδέσετε τα άκρα του. Αφού συνδέσετε και τα δύο άκρα, η μέθοδος [Connector::reroute](https://reference.aspose.com/slides/el/php-java/aspose.slides/connector/reroute/) επιλέγει μια σύντομη διαδρομή μεταξύ των σχημάτων.

Το παρακάτω παράδειγμα συνδέει μια έλλειψη και ένα ορθογώνιο με έναν λυγό σύνδεσμο:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $ellipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
    $rectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    $connector->reroute();

    $presentation->save("connected-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Προειδοποίηση" %}}

Η κλήση της `reroute` μπορεί να αλλάξει τις τιμές των [Connector::setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/el/php-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) και [Connector::setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/el/php-java/aspose.slides/connector/setendshapeconnectionsiteindex/). Ορίστε συγκεκριμένα σημεία σύνδεσης μετά την επανακατεύθυνση εάν πρέπει να παραμείνουν σταθερά.

{{% /alert %}}

## **Επιλογή Σημείου Σύνδεσης**

Κάθε σχήμα που μπορεί να συνδεθεί αναφέρει τον αριθμό των σημείων μέσω της μεθόδου [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getconnectionsitecount/). Ελέγξτε έναν προτιμώμενο μηδενικά‑βάση δείκτη πριν τον αναθέσετε σε άκρο συνδέσμου· οι μετρήσεις διαφέρουν ανάλογα με τη γεωμετρία του σχήματος.

Αυτό το παράδειγμα συνδέει το σύνδεσμο σε ένα συγκεκριμένο σημείο της έλλειψης όταν αυτό το σημείο υπάρχει:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $ellipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
    $rectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);

    $preferredSiteIndex = 2;
    $connectionSiteCount = java_values($ellipse->getConnectionSiteCount());
    if ($preferredSiteIndex < $connectionSiteCount) {
        $connector->setStartShapeConnectionSiteIndex($preferredSiteIndex);
    } else {
        echo "The ellipse has only " . $connectionSiteCount . " connection sites." . PHP_EOL;
    }

    $presentation->save("specific-connection-site.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ρύθμιση Σημείου Συνδέσμου**

Οι σύνδεσμοι με σημεία προσαρμογής τα εκθέτουν μέσω της μεθόδου [GeometryShape::getAdjustments](https://reference.aspose.com/slides/el/php-java/aspose.slides/geometryshape/#getadjustments). Εξετάστε κάθε [AdjustValue](https://reference.aspose.com/slides/el/php-java/aspose.slides/adjustvalue/) και ελέγξτε την τιμή [AdjustValue::getType](https://reference.aspose.com/slides/el/php-java/aspose.slides/adjustvalue/#gettype) πριν την αλλάξετε με [AdjustValue::setRawValue](https://reference.aspose.com/slides/el/php-java/aspose.slides/adjustvalue/setrawvalue/). Οι γενικοί κανόνες για την αναγνώριση προεπιλεγμένων προσαρμογών σχήματος περιγράφονται στην ενότητα [Shape Manipulation](/slides/el/php-java/shape-manipulations/).

Ο αριθμός, η σειρά, το νόημα και το έγκυρο εύρος τιμών των προσαρμογών συνδέσμου εξαρτώνται από την προεπιλογή του συνδέσμου. Ο τύπος προσαρμογής είναι μόνο για ανάγνωση· η τιμή είναι επεξεργάσιμη. Η μέθοδος μόνο για ανάγνωση [AdjustValue::getName](https://reference.aspose.com/slides/el/php-java/aspose.slides/adjustvalue/getname/) παρέχει πρόσθετη ταυτοποίηση όταν ένας σύνδεσμος περιέχει περισσότερες από μία προσαρμογές του ίδιου εννοιολογικού τύπου.

### **Διαδρομή γύρω από Εμπόδιο**

Στην παρακάτω διάταξη, ένας σύνδεσμος `BentConnector5` μεταξύ δύο σχημάτων περνάει από ένα τρίτο σχήμα:

![connector-obstruction](connector-obstruction.png)

Αυτός ο κώδικας δημιουργεί τον εμποδισμένο σύνδεσμο:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(0, 0, 0));
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setStartShapeConnectionSiteIndex(2);

    $presentation->save("connector-obstruction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η μετακίνηση του κάθετου λυγμού αλλάζει τη διαδρομή έτσι ώστε ο σύνδεσμος να παρακάμπτει το εμπόδιο:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Αντί να υποθέτετε ότι ο δείκτης συλλογής `1` αντιπροσωπεύει πάντα τον κάθετο λυγμό, αυτό το παράδειγμα ψάχνει για `ConnectorBendPositionY` και το αλλάζει μόνο όταν ο αναμενόμενος εννοιολογικός τύπος είναι παρόν:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(0, 0, 0));
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setStartShapeConnectionSiteIndex(2);

    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentName = java_values($adjustment->getName());
        $adjustmentType = java_values($adjustment->getType());
        $rawValue = java_values($adjustment->getRawValue());
        echo $adjustmentName . ": " . $adjustmentType . ", raw value = " . $rawValue . PHP_EOL;
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
            break;
        }
    }

    if ($verticalBend === null) {
        echo "The connector does not expose a vertical bend adjustment." . PHP_EOL;
    } else {
        $verticalBend->setRawValue(60000);
        $presentation->save("connector-obstruction-fixed.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Ένας `BentConnector5` έχει δύο προσαρμογές `ConnectorBendPositionX` και μία προσαρμογή `ConnectorBendPositionY`. Εάν ο τύπος που χρειάζεστε εμφανίζεται περισσότερες από μία φορές, εξετάστε το `getName` και τη γνωστή γεωμετρία της προεπιλογής πριν επιλέξετε. Εάν μια προσαρμογή επιστρέφει `ShapeAdjustmentType::Custom`, θεωρήστε το νόημα και το εύρος της ως ειδικά για αυτήν την προεπιλογή και μην το αλλάξετε μέχρι να είναι γνωστή η σύμβαση.

## **Συσχέτιση Τιμών Προσαρμογής με Γεωμετρία Συνδέσμου**

Για λυγόμενους συνδέσμους, οι τιμές προσαρμογής μπορούν να χρησιμοποιηθούν για την εκτίμηση των θέσεων των μεμονωμένων τμημάτων. Αυτοί οι υπολογισμοί είναι ειδικοί για την προεπιλογή του συνδέσμου:

- Το `BentConnector4` συνήθως εκθέτει μία προσαρμογή `ConnectorBendPositionX` και μία `ConnectorBendPositionY`.
- Για αυτές τις θέσεις λυγμού, η διαίρεση της τιμής που επιστρέφει το `getRawValue` με `100000` παρέχει το κλάσμα του πλάτους ή του ύψους του πλαισίου του συνδέσμου που χρησιμοποιείται στα παραδείγματα παρακάτω.
- Ένα πλαίσιο συνδέσμου μπορεί να περιστραφεί ή να αντιστραφεί, επομένως οι συντεταγμένες του πλαισίου πρέπει να μετατραπούν πριν συγκριθούν με τις συντεταγμένες της διαφάνειας.

Τα παρακάτω παραδείγματα χρησιμοποιούν το `getType` για την αναγνώριση των προσαρμογών πρώτα. Δεν αντιμετωπίζουν τους δείκτες συλλογής ως φορητά αναγνωριστικά.

### **Σύνδεσμος χωρίς Περιστροφή**

Η αρχική διάταξη περιέχει δύο σχήματα κειμένου συνδεδεμένα με ένα `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Αυτό το παράδειγμα εξετάζει τον σύνδεσμο και λαμβάνει τις οριζόντιες και κάθετες προσαρμογές λυγμού:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $sourceShape->getTextFrame()->setText("From");
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $targetShape->getTextFrame()->setText("To");
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(255, 0, 0));
    $connector->getLineFormat()->setWidth(3);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        echo $adjustment->getName() . ": " . $adjustment->getType() . ", raw value = " . $adjustment->getRawValue() . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Για να αλλάξετε και τους δύο λυγμούς, εντοπίστε κάθε αναμενόμενο τύπο και τροποποιήστε τις τιμές μόνο αφού βρεθούν και οι δύο:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $horizontalBendValue += 20000;
        $verticalBendValue += 200000;
        $horizontalBend->setRawValue($horizontalBendValue);
        $verticalBend->setRawValue($verticalBendValue);
        $presentation->save("connector-adjusted.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα είναι ένας σύνδεσμος του οποίου τα οριζόντια και κάθετα τμήματα έχουν μετακινηθεί:

![connector-adjusted-1](connector-adjusted-1.png)

Μόλις γνωστοποιηθούν οι εννοιολογικοί τύποι, οι τιμές τους μπορούν να μετατραπούν σε συντεταγμένες πλαισίου συνδέσμου. Το παράδειγμα αυτό σχεδιάζει ένα λεπτό ορθογώνιο πάνω από το κάθετο τμήμα που ελέγχεται από τις δύο προσαρμογές λυγμού:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $connectorX = java_values($connector->getX());
        $connectorY = java_values($connector->getY());
        $connectorWidth = java_values($connector->getWidth());
        $connectorHeight = java_values($connector->getHeight());
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $x = $connectorX + $connectorWidth * $horizontalBendValue / 100000;
        $y = $connectorY;
        $height = $connectorHeight * $verticalBendValue / 100000;
        $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 1, $height);
        $presentation->save("connector-segment-guide.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Το σχήμα οδηγού σηματοδοτεί το υπολογισμένο τμήμα:

![connector-adjusted-2](connector-adjusted-2.png)

### **Περιστρεφόμενος ή Αντανακλασθείς Σύνδεσμος**

Όταν η ίδια γεωμετρία συνδέσμου τοποθετείται κατακόρυφα, οι τιμές [Shape::getFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getframe/), [ShapeFrame::getFlipH](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapeframe/getfliph/), και [ShapeFrame::getFlipV](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapeframe/getflipv/) επηρεάζουν τη μετατροπή από συντεταγμένες πλαισίου συνδέσμου σε συντεταγμένες διαφάνειας.

Αυτό το παράδειγμα δημιουργεί και ρυθμίζει τον κατακόρυφα προσανατολισμένο σύνδεσμο:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $sourceShape->getTextFrame()->setText("From");
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
    $targetShape->getTextFrame()->setText("To 1");
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(102, 205, 170));
    $connector->getLineFormat()->setWidth(3);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(2);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(3);

    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $rawValue = java_values($adjustment->getRawValue());
            $adjustment->setRawValue($rawValue + 20000);
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $rawValue = java_values($adjustment->getRawValue());
            $adjustment->setRawValue($rawValue + 200000);
        }
    }

    $presentation->save("vertical-connector-adjusted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ο προσαρμοσμένος σύνδεσμος εμφανίζεται κατακόρυφα μεταξύ των σχημάτων:

![connector-adjusted-3](connector-adjusted-3.png)

Για μια αυθαίρετη γωνία περιστροφής `alpha`, περιστρέψτε ένα σημείο πλαισίου συνδέσμου `(x, y)` γύρω από το κέντρο του πλαισίου `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Ο παρακάτω κώδικας χειρίζεται την 90‑μοίρες προσανατολισμό που χρησιμοποιείται σε αυτό το παράδειγμα και σχεδιάζει έναν κόκκινο οδηγό πάνω από το αντίστοιχο τμήμα του συνδέσμου:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(2);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(3);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $horizontalBendValue += 20000;
        $verticalBendValue += 200000;
        $horizontalBend->setRawValue($horizontalBendValue);
        $verticalBend->setRawValue($verticalBendValue);

        $frame = $connector->getFrame();
        $connectorX = java_values($connector->getX());
        $connectorY = java_values($connector->getY());
        $connectorWidth = java_values($connector->getWidth());
        $connectorHeight = java_values($connector->getHeight());
        $flipH = java_values($frame->getFlipH()) == NullableBool::True;
        $flipV = java_values($frame->getFlipV()) == NullableBool::True;
        $centerX = java_values($frame->getCenterX());
        $centerY = java_values($frame->getCenterY());

        $x = $connectorX;
        $y = $connectorY;
        if ($flipH) {
            $x += $connectorWidth;
        }
        if ($flipV) {
            $y += $connectorHeight;
        }

        $x += $connectorWidth * $horizontalBendValue / 100000;
        $rotatedX = $centerX - $y + $centerY;
        $rotatedY = $x - $centerX + $centerY;
        $segmentWidth = $connectorHeight * $verticalBendValue / 100000;
        $guide = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $rotatedX, $rotatedY, $segmentWidth, 1);
        $guide->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $guide->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(255, 0, 0));

        $presentation->save("rotated-connector-segment-guide.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Ο κόκκινος οδηγός σηματοδοτεί το υπολογισμένο τμήμα μετά τη μετατροπή των συντεταγμένων:

![connector-adjusted-4](connector-adjusted-4.png)

Αυτοί οι τύποι περιγράφουν τις προεπιλογές που χρησιμοποιούνται στα παραδείγματα, όχι ένα καθολικό μοντέλο συνδέσμου. Επικυρώστε τους τύπους προσαρμογών, τον προσανατολισμό του πλαισίου και τα εύρη τιμών πριν εφαρμόσετε τον ίδιο υπολογισμό σε διαφορετική προεπιλογή.

## **Εύρεση Γωνίας Κατεύθυνσης Συνδέσμου**

Η κατεύθυνση ενός ευθείου συνδέσμου μπορεί να υπολογιστεί από το πλάτος και το ύψος του, λαμβάνοντας υπόψη τις οριζόντιες και κάθετες αντιστροφές. Το παρακάτω παράδειγμα αναφέρει τη γωνία δεινού ρολογιού από τον θετικό οριζόντιο άξονα στις συντεταγμένες της διαφάνειας:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $connector = $slide->getShapes()->addConnector(ShapeType::StraightConnector1, 100, 100, 200, 100);

    $frame = $connector->getFrame();
    $flipH = java_values($frame->getFlipH()) == NullableBool::True;
    $flipV = java_values($frame->getFlipV()) == NullableBool::True;
    $width = java_values($connector->getWidth());
    $height = java_values($connector->getHeight());
    $deltaX = $width * ($flipH ? -1 : 1);
    $deltaY = $height * ($flipV ? -1 : 1);
    $angle = atan2($deltaY, $deltaX) * 180.0 / pi();

    if ($angle < 0) {
        $angle += 360;
    }

    printf("Connector direction: %.2f degrees%s", $angle, PHP_EOL);
} finally {
    $presentation->dispose();
}
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να καταλάβω αν ένας σύνδεσμος μπορεί να συνδεθεί με ένα σχήμα;**

Ελέγξτε την τιμή [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getconnectionsitecount/) του σχήματος. Ένας θετικός αριθμός σημαίνει ότι το σχήμα εκθέτει σημεία σύνδεσης. Επικυρώστε τον επιλεγμένο δείκτη σημείου πριν τον αναθέσετε σε οποιοδήποτε άκρο του συνδέσμου.

**Μπορώ να ταυτοποιήσω μια προσαρμογή συνδέσμου με τον δείκτη της συλλογής;**

Ένας δείκτης είναι σημαντικός μόνο για μια γνωστή προεπιλογή συνδέσμου και διάταξη συλλογής. Ελέγξτε το [AdjustValue::getType](https://reference.aspose.com/slides/el/php-java/aspose.slides/adjustvalue/#gettype) πριν τροποποιήσετε μια τιμή και χρησιμοποιήστε το [AdjustValue::getName](https://reference.aspose.com/slides/el/php-java/aspose.slides/adjustvalue/getname/) ως πρόσθετη πληροφορία όταν ο ίδιος εννοιολογικός τύπος εμφανίζεται περισσότερες από μία φορές.

**Τι συμβαίνει όταν ένα συνδεδεμένο σχήμα διαγραφεί;**

Το αντίστοιχο άκρο του συνδέσμου αποσυνδέεται. Ο σύνδεσμος παραμένει στη διαφάνεια και μπορεί να διαγραφεί, να τοποθετηθεί ως ελεύθερη γραμμή ή να συνδεθεί με άλλο σχήμα.

**Διατηρούνται οι συνδέσεις όταν αντιγραφεί μια διαφάνεια;**

Οι συνδέσεις διατηρούνται γενικά όταν τα συνδεδεμένα σχήματα αντιγράφονται μαζί με τη διαφάνεια. Εάν ένας σύνδεσμος αντιγραφεί χωρίς ένα από τα σχήματα-στόχους, το επηρεαζόμενο άκρο πρέπει να επανασυνδεθεί.