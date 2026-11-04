---
title: Εφαρμογή Εφέ Σχήματος σε Παρουσιάσεις σε Android
linktitle: Εφέ Σχήματος
type: docs
weight: 30
url: /el/androidjava/shape-effect/
keywords:
- εφέ σχήματος
- εφέ σκιάς
- εφέ αντανάκλασης
- εφέ λάμψης
- εφέ μαλακών άκρων
- μορφή εφέ
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μετατρέψτε τα αρχεία PPT και PPTX σας με προχωρημένα εφέ σχήματος χρησιμοποιώντας την Aspose.Slides για Android μέσω Java—δημιουργήστε εντυπωσιακές, επαγγελματικές διαφάνειες σε δευτερόλεπτα."
---
## **Εισαγωγή**

Ενώ τα εφέ στο PowerPoint μπορούν να χρησιμοποιηθούν για να κάνετε ένα σχήμα να ξεχωρίζει, διαφέρουν από τα [συμπληρώματα](/slides/el/androidjava/shape-formatting/#gradient-fill) ή τα περιγράμματα. Χρησιμοποιώντας τα εφέ του PowerPoint, μπορείτε να δημιουργήσετε πειστικές αντανακλάσεις σε ένα σχήμα, να διανείμετε τη λάμψη ενός σχήματος κ.λπ.

![Εφέ σχήματος](shape-effect.png)

Το PowerPoint παρέχει έξι εφέ που μπορούν να εφαρμοστούν σε σχήματα. Μπορείτε να εφαρμόσετε ένα ή περισσότερα εφέ σε ένα σχήμα.

Κάποιες συνδυασμοί εφέ φαίνονται καλύτεροι από άλλους. Για αυτόν τον λόγο, το PowerPoint παρέχει επιλογές κάτω από **Preset**. Οι επιλογές Preset είναι συνδυασμοί δύο ή περισσότερων εφέ που είναι γνωστό ότι δείχνουν ωραία. Έτσι, επιλέγοντας ένα preset, δεν χρειάζεται να σπαταλήσετε χρόνο δοκιμάζοντας ή συνδυάζοντας διαφορετικά εφέ για να βρείτε έναν καλό συνδυασμό.

Η Aspose.Slides παρέχει ιδιότητες και μεθόδους στην κλάση [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) που σας επιτρέπουν να εφαρμόζετε τα ίδια εφέ σε σχήματα σε παρουσιάσεις PowerPoint.

## **Εφαρμογή Εφέ Σκιάς**

Η Aspose.Slides για Android μέσω Java υποστηρίζει εξωτερικές και εσωτερικές σκιές για σχήματα. Μπορείτε να προσαρμόσετε το χρώμα, την κατεύθυνση, την απόσταση και την ακτίνα θολώματος ώστε να ταιριάζουν με το σχέδιο της παρουσίασής σας.

### **Εφαρμογή Εξωτερικής Σκιάς**

Χρησιμοποιήστε μια εξωτερική σκιά ώστε ένα κάρτα ή πίνακας να ξεχωρίζει από το φόντο της διαφάνειας. Η σκιά επεκτείνεται πέρα από τις άκρες του σχήματος, δημιουργώντας την εντύπωση ότι το σχήμα είναι υψωμένο πάνω από τη διαφάνεια. Ρυθμίστε το χρώμα, την κατεύθυνση, την απόσταση και την ακτίνα θολώματος ώστε να ταιριάζουν με τον φωτισμό και το στυλ του προτύπου σας.

Αυτός ο κώδικας Java δείχνει πώς να εφαρμόσετε το [εφέ εξωτερικής σκιάς](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) σε ένα ορθογώνιο:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Εφέ σκιάς](shadow_effect.png)

### **Εφαρμογή Εσωτερικής Σκιάς**

Κατά την αναπαραγωγή του οπτικού στυλ ενός προτύπου, χρησιμοποιήστε μια εσωτερική σκιά για να δώσετε σε μια κάρτα ή πίνακα μια εσοχή. Μια εξωτερική σκιά επεκτείνεται έξω από το σχήμα και το κάνει να φαίνεται υψωμένο, ενώ μια εσωτερική σκιά σκιάζει το εσωτερικό των άκρων του.

Καλέστε το [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--), στη συνέχεια διαμορφώστε τη σκιά που επιστρέφεται από το [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--). Μεγαλύτερες τιμές ακτίνας θολώματος παράγουν πιο απαλά άκρα.

Αυτό το παράδειγμα Java δημιουργεί μια ανοιχτόμπλε κάρτα με μια σκούρο γκρι εσωτερική σκιά και την αποθηκεύει ως αρχείο PPTX. Η κατεύθυνση της σκιάς είναι 225 μοίρες, η απόστασή της είναι 7 σημεία και η ακτίνα θολώματος είναι 6 σημεία:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Ανοιχτό μπλε ορθογώνιο με εσωτερική σκιά](inner_shadow_effect.png)

Για να αφαιρέσετε την εσωτερική σκιά, καλέστε το [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) στη μορφή εφέ του σχήματος.

## **Εφαρμογή Εφέ Αντανάκλασης**

Για να εφαρμόσετε ένα εφέ αντανάκλασης στην Aspose.Slides για Android μέσω Java, μπορείτε να προσθέσετε μια καθρεπτική αντανάκλαση σε σχήματα, ρυθμίζοντας παραμέτρους όπως η απόσταση, η διαφάνεια και το μέγεθος. Αυτό το εφέ ενισχύει την αισθητική των παρουσιάσεών σας προσδίδοντας στα σχήματα μια πιο polished και σοφιστικέ εμφάνιση. Είναι εύκολο να υλοποιηθεί με απλό κώδικα, επιτρέποντας γρήγορη εφαρμογή σε πολλά στοιχεία για συνεπές σχέδιο.

Αυτός ο κώδικας Java δείχνει πώς να εφαρμόσετε το [εφέ αντανάκλασης](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) σε ένα σχήμα:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Εφέ αντανάκλασης](reflection_effect.png)

## **Εφαρμογή Εφέ Λάμψης**

Για να εφαρμόσετε ένα εφέ λάμψης σε ένα σχήμα στην Aspose.Slides για Android μέσω Java, μπορείτε να προσθέσετε μια απαλή, φωτεινή αύρα γύρω από σχήματα, ρυθμίζοντας ιδιότητες όπως το χρώμα και το μέγεθος. Αυτό το εφέ βοηθά τα σχήματα να ξεχωρίζουν και προσθέτει ένα ελκυστικό, εντυπωσιακό οπτικό στοιχείο στην παρουσίασή σας. Είναι εύκολο να υλοποιηθεί με ελάχιστο κώδικα, βελτιώνοντας τη συνολική εμφάνιση των διαφανειών σας.

Αυτός ο κώδικας Java δείχνει πώς να εφαρμόσετε το [εφέ λάμψης](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) σε ένα σχήμα:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Εφέ λάμψης](glow_effect.png)

## **Εφαρμογή Εφέ Μαλακών Άκρων**

Για να εφαρμόσετε ένα εφέ μαλακών άκρων στην Aspose.Slides για Android μέσω Java, μπορείτε να δημιουργήσετε μια ομαλή, θολή μετάβαση γύρω από τις άκρες ενός σχήματος. Αυτό το εφέ προσθέτει μια πιο διακριτική και εκλεπτυσμένη εμφάνιση, ιδανική για σχέδια που χρειάζονται μια ήπια, πιο ήπια παρουσίαση. Μπορείτε εύκολα να ρυθμίσετε παραμέτρους όπως η ακτίνα για να πετύχετε το επιθυμητό αποτέλεσμα σε διάφορα σχήματα της παρουσίασής σας.

Αυτός ο κώδικας Java δείχνει πώς να εφαρμόσετε το [εφέ μαλακών άκρων](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) σε ένα σχήμα:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Εφέ μαλακών άκρων](soft_edges_effect.png)

## **Εφαρμογή Εφέ Θολώματος**

Χρησιμοποιήστε το θόλωση σχήματος για να μαλακώσετε τη γέμιση και το περίγραμμα ενός σχήματος διατηρώντας το σχήμα επεξεργάσιμο. Καλέστε το [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) στη μορφή εφέ του σχήματος. Η ακτίνα μετράται σε σημεία (1/72 ίντσα): χρησιμοποιήστε μια μη αρνητική τιμή, με μεγαλύτερες τιμές να παράγουν ισχυρότερη θόλωση. Μια ακτίνα μηδέν αφήνει την εμφάνιση αμετάβλητη.

Η ρύθμιση [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) ελέγχει τα ορατά όρια του εφέ. Με `false`, η θόλωση περιορίζεται στα αρχικά χρωματισμένα όρια, συμπεριλαμβανομένου του περιγράμματος. Με `true`, η θόλωση μπορεί να επεκταθεί πέρα από αυτά τα όρια. Καμία ρύθμιση δεν αλλάζει τη θέση ή τις διαστάσεις του σχήματος.

Η παρακάτω σύγκριση χρησιμοποιεί την ίδια γέμιση, περίγραμμα και διαστάσεις σχήματος σε όλο το κείμενο. Η πάνω σειρά χρησιμοποιεί `grow = false`; η κάτω σειρά χρησιμοποιεί `grow = true`.

![Πρωτότυπο ορθογώνιο συγκρινόμενο με ακτίνες θολώματος 5 και 15 σημείων, με grow ανενεργό και ενεργό](shape_blur_comparison.png)

Αυτό το παράδειγμα Java δημιουργεί ένα πορτοκαλί ορθογώνιο με σκούρο μπλε περίγραμμα, εφαρμόζει θόλωση 5 σημείων, και στη συνέχεια το ενημερώνει σε θόλωση 15 σημείων καλώντας ξανά το [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-). Αποθηκεύει και τις δύο καταστάσεις θολώματος, στη συνέχεια καλεί το [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) και αποθηκεύει το σχήμα χωρίς θόλωση.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η θόλωση σχήματος επηρεάζει ταυτόχρονα τη γέμιση και το περίγραμμα. Ένα εφέ μαλακών άκρων εξασθενίζει τις άκρες του σχήματος, ενώ η θόλωση σκιάς μαλακώνει μόνο τη σκιά. Τα εφέ μετασχηματισμού εικόνας λειτουργούν στο περιεχόμενο της εικόνας· αυτό το παράδειγμα εφαρμόζει θόλωση απευθείας στη μορφή εφέ του σχήματος χωρίς να μετατρέπει το σχήμα σε εικόνα.

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω πολλαπλά εφέ στο ίδιο σχήμα;**

Ναι, μπορείτε να συνδυάσετε διαφορετικά εφέ, όπως σκιά, αντανάκλαση και λάμψη, σε ένα μόνο σχήμα για να δημιουργήσετε μια πιο δυναμική εμφάνιση.

**Σε ποια σχήματα μπορώ να εφαρμόσω εφέ;**

Μπορείτε να εφαρμόσετε εφέ σε διάφορα σχήματα, συμπεριλαμβανομένων αυτόματων σχημάτων, διαγραμμάτων, πινάκων, εικόνων, αντικειμένων SmartArt, αντικειμένων OLE κ.λπ.

**Μπορώ να εφαρμόσω εφέ σε ομαδοποιημένα σχήματα;**

Ναι, μπορείτε να εφαρμόσετε εφέ σε ομαδοποιημένα σχήματα. Το εφέ θα εφαρμοστεί σε ολόκληρη την ομάδα.