---
title: Εφαρμογή Εφέ Σχημάτων σε Παρουσιάσεις με PHP
linktitle: Εφέ Σχήματος
type: docs
weight: 30
url: /el/php-java/shape-effect/
keywords:
- εφέ σχήματος
- εφέ σκιάς
- εφέ αντανάκλασης
- εφέ λάμψης
- εφέ μαλακών άκρων
- μορφή εφέ
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μετατρέψτε τα αρχεία PPT και PPTX σας με προηγμένα εφέ σχημάτων χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java—δημιουργήστε εντυπωσιακές, επαγγελματικές διαφάνειες σε δευτερόλεπτα."
---
## **Εισαγωγή**

Ενώ τα εφέ στο PowerPoint μπορούν να χρησιμοποιηθούν για να κάνουν ένα σχήμα να ξεχωρίσει, διαφέρουν από τα [γέμισματα](/slides/el/php-java/shape-formatting/#gradient-fill) ή τα περιγράμματα. Χρησιμοποιώντας τα εφέ του PowerPoint, μπορείτε να δημιουργήσετε πειστικές ανακλαστικές επιρροές σε ένα σχήμα, να διαχέετε τη λάμψη ενός σχήματος κ.λπ.

![Εφέ σχήματος](shape-effect.png)

Το PowerPoint παρέχει έξι εφέ που μπορούν να εφαρμοστούν σε σχήματα. Μπορείτε να εφαρμόσετε ένα ή περισσότερα εφέ σε ένα σχήμα.

Κάποιες συνδυασμοί εφέ φαίνονται καλύτεροι από άλλους. Για αυτό το λόγο, το PowerPoint παρέχει επιλογές κάτω από **Preset**. Οι επιλογές Preset είναι συνδυασμοί δύο ή περισσότερων εφέ που είναι γνωστό ότι φαίνονται καλά. Έτσι, επιλέγοντας ένα preset, δεν χρειάζεται να σπαταλήσετε χρόνο δοκιμάζοντας ή συνδυάζοντας διαφορετικά εφέ για να βρείτε έναν καλό συνδυασμό.

Το Aspose.Slides παρέχει ιδιότητες και μεθόδους στην κλάση [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) που σας επιτρέπουν να εφαρμόζετε τα ίδια εφέ σε σχήματα σε παρουσιάσεις PowerPoint.

## **Εφαρμογή Σκιάς**

Το Aspose.Slides για PHP μέσω Java υποστηρίζει εξωτερικές και εσωτερικές σκιές για σχήματα. Μπορείτε να προσαρμόσετε το χρώμα, την κατεύθυνση, την απόσταση και την ακτίνα θολώματος ώστε να ταιριάζουν με το σχέδιο της παρουσίασής σας.

### **Εφαρμογή Εξωτερικής Σκιάς**

Χρησιμοποιήστε μια εξωτερική σκιά για να κάνετε μια κάρτα ή πίνακα να ξεχωρίζει από το φόντο της διαφάνειας. Η σκιά εκτείνεται πέρα από τις άκρες του σχήματος, δημιουργώντας την εντύπωση ότι το σχήμα είναι ανυψωμένο πάνω από τη διαφάνεια. Ρυθμίστε το χρώμα, την κατεύθυνση, την απόσταση και την ακτίνα θολώματος ώστε να ταιριάζουν με το φωτισμό και το στυλ του προτύπου σας.

Αυτός ο κώδικας PHP δείχνει πώς να εφαρμόσετε το [εφέ εξωτερικής σκιάς](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) σε ένα ορθογώνιο:
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Εφέ σκιάς](shadow_effect.png)

### **Εφαρμογή Εσωτερικής Σκιάς**

Όταν αναπαράγετε το οπτικό στυλ ενός προτύπου, χρησιμοποιήστε μια εσωτερική σκιά για να δώσετε σε μια κάρτα ή πίνακα μια εσοχή. Μια εξωτερική σκιά εκτείνεται έξω από το σχήμα και το κάνει να φαίνεται ανυψωμένο, ενώ μια εσωτερική σκιά σκιάζει το εσωτερικό των άκρων του.

Καλέστε [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect), στη συνέχεια διαμορφώστε τη σκιά που επιστρέφεται από το [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Μεγαλύτερες τιμές ακτίνας θολώματος παράγουν πιο μαλακές άκρες.

Αυτό το παράδειγμα PHP δημιουργεί μια ανοιλό μπλε κάρτα με εσωτερική σκιά σκούρου γκρι και την αποθηκεύει ως αρχείο PPTX. Η κατεύθυνση της σκιάς είναι 225 μοίρες, η απόσταση 7 σημεία και η ακτίνα θολώματος 6 σημεία:
```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Ανοιχτό μπλε ορθογώνιο με εσωτερική σκιά](inner_shadow_effect.png)

Για να αφαιρέσετε την εσωτερική σκιά, καλέστε [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) στη μορφή εφέ του σχήματος.

## **Εφαρμογή Εφέ Αντανάκλασης**

Για να εφαρμόσετε ένα εφέ αντανάκλασης στο Aspose.Slides για PHP μέσω Java, μπορείτε να προσθέσετε μια καθρέφτικη αντανάκλαση σε σχήματα, ρυθμίζοντας παραμέτρους όπως η απόσταση, η διαφάνεια και το μέγεθος. Αυτό το εφέ ενισχύει την αισθητική των παρουσιάσεών σας δίνοντας στα σχήματα μια πιο γυαλιστερή και εκλεπτυσμένη εμφάνιση. Είναι εύκολο στην υλοποίηση με απλό κώδικα, επιτρέποντας γρήγορη εφαρμογή σε πολλά στοιχεία για ένα συνεπές σχέδιο.

Αυτός ο κώδικας PHP δείχνει πώς να εφαρμόσετε το [εφέ αντανάκλασης](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) σε ένα σχήμα:
```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Εφέ αντανάκλασης](reflection_effect.png)

## **Εφαρμογή Εφέ Λάμψης**

Για να εφαρμόσετε ένα εφέ λάμψης σε ένα σχήμα στο Aspose.Slides για PHP μέσω Java, μπορείτε να προσθέσετε μια ήπια, φωτεινή αύρα γύρω από τα σχήματα, ρυθμίζοντας ιδιότητες όπως το χρώμα και το μέγεθος. Αυτό το εφέ βοηθά τα σχήματα να ξεχωρίζουν και προσθέτει ένα ελκυστικό, εντυπωσιακό οπτικό στοιχείο στην παρουσίασή σας. Είναι εύκολο στην υλοποίηση με ελάχιστο κώδικα, βελτιώνοντας τη γενική εμφάνιση των διαφανειών σας.

Αυτός ο κώδικας PHP δείχνει πώς να εφαρμόσετε το [εφέ λάμψης](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) σε ένα σχήμα:
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Εφέ λάμψης](glow_effect.png)

## **Εφαρμογή Εφέ Μαλακών Άκρων**

Για να εφαρμόσετε ένα εφέ μαλακών άκρων στο Aspose.Slides για PHP μέσω Java, μπορείτε να δημιουργήσετε μια ομαλή, θολή μετάβαση γύρω από τις άκρες ενός σχήματος. Αυτό το εφέ προσθέτει μια πιο διακριτική και εκλεπτυσμένη εμφάνιση, ιδανική για σχέδια που χρειάζονται απαλό, πιο ήπιο στυλ. Μπορείτε εύκολα να ρυθμίσετε παραμέτρους όπως η ακτίνα για να πετύχετε το επιθυμητό αποτέλεσμα σε διάφορα σχήματα στην παρουσίασή σας.

Αυτός ο κώδικας PHP δείχνει πώς να εφαρμόσετε το [εφέ μαλακών άκρων](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) σε ένα σχήμα:
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Εφέ μαλακών άκρων](soft_edges_effect.png)

## **Εφαρμογή Εφέ Θολώματος**

Χρησιμοποιήστε το θόλωμα σχήματος για να μαλακώσετε τη γεμιστική και την περιγράμμιση ενός σχήματος ενώ διατηρείτε το σχήμα επεξεργάσιμο. Καλέστε [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) στη μορφή εφέ του σχήματος. Η ακτίνα μετράται σε σημεία (1/72 ίντσα): χρησιμοποιήστε μια μη αρνητική τιμή, με μεγαλύτερες τιμές να παράγουν πιο ισχυρό θόλωμα. Μια ακτίνα μηδέν αφήνει την εμφάνιση αμετάβλητη.

Η ρύθμιση [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) ελέγχει τα ορατά όρια του εφέ. Με `false`, το θόλωμα περιορίζεται στα αρχικά χρωματισμένα όρια, συμπεριλαμβανομένης της περιγράμμισης. Με `true`, το θόλωμα μπορεί να επεκταθεί πέρα από αυτά τα όρια. Καμία από τις ρυθμίσεις δεν αλλάζει τη θέση ή τις διαστάσεις του σχήματος.

Η παρακάτω σύγκριση χρησιμοποιεί την ίδια γεμιστική, περιγράμμιση και διαστάσεις σχήματος σε όλη τη διαδικασία. Η επάνω σειρά χρησιμοποιεί `grow = false`; η κάτω σειρά χρησιμοποιεί `grow = true`.

![Αρχικό ορθογώνιο συγκρινόμενο με ακτίνες θολώματος 5 και 15 σημείων, με grow απενεργοποιημένο και ενεργοποιημένο](shape_blur_comparison.png)

Αυτό το παράδειγμα PHP δημιουργεί ένα πορτοκαλί ορθογώνιο με σκουρό μπλε περιγράμμιση, εφαρμόζει θόλωμα 5 σημείων και στη συνέχεια το ενημερώνει σε θόλωμα 15 σημείων καλώντας ξανά το [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect). Αποθηκεύει και τις δύο καταστάσεις με θόλωμα, στη συνέχεια καλεί το [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) και αποθηκεύει το σχήμα χωρίς θόλωμα.
```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το θόλωμα σχήματος επηρεάζει τη γεμιστική και την περιγράμμιση μαζί. Ένα εφέ μαλακών άκρων ξεθωριάζει τις άκρες του σχήματος, ενώ το θόλωμα σκιάς μαλακώνει μόνο τη σκιά. Τα εφέ μετασχηματισμού εικόνας λειτουργούν στο περιεχόμενο της εικόνας· αυτό το παράδειγμα εφαρμόζει θόλωμα άμεσα στη μορφή εφέ του σχήματος χωρίς να μετατρέπει το σχήμα σε εικόνα.

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω πολλαπλά εφέ στο ίδιο σχήμα;**

Ναι, μπορείτε να συνδυάσετε διαφορετικά εφέ, όπως σκιά, αντανάκλαση και λάμψη, σε ένα μόνο σχήμα για να δημιουργήσετε μια πιο δυναμική εμφάνιση.

**Σε ποια σχήματα μπορώ να εφαρμόσω εφέ;**

Μπορείτε να εφαρμόσετε εφέ σε διάφορα σχήματα, συμπεριλαμβανομένων των αυτόματων σχημάτων, διαγραμμάτων, πινάκων, εικόνων, αντικειμένων SmartArt, αντικειμένων OLE και άλλα.

**Μπορώ να εφαρμόσω εφέ σε ομαδοποιημένα σχήματα;**

Ναι, μπορείτε να εφαρμόσετε εφέ σε ομαδοποιημένα σχήματα. Το εφέ θα εφαρμοστεί σε ολόκληρη την ομάδα.