---
title: Εφαρμογή Εφέ Σχημάτων σε Παρουσιάσεις στο Android
linktitle: Εφέ Σχήματος
type: docs
weight: 30
url: /el/androidjava/shape-effect/
keywords:
- εφέ σχήματος
- εφέ σκιάς
- εφέ ανάκλασης
- εφέ λάμψης
- εφέ μαλακών άκρων
- μορφή εφέ
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μετατρέψτε τα αρχεία PPT και PPTX σας με προηγμένα εφέ σχήματος χρησιμοποιώντας το Aspose.Slides για Android μέσω Java—δημιουργήστε εντυπωσιακές, επαγγελματικές διαφάνειες σε δευτερόλεπτα."
---
## **Εισαγωγή**

Ενώ τα εφέ στο PowerPoint μπορούν να χρησιμοποιηθούν για να κάνουν ένα σχήμα να ξεχωρίζει, διαφέρουν από τις [γέμιση](/slides/el/androidjava/shape-formatting/#gradient-fill) ή τα περιγράμματα. Χρησιμοποιώντας τα εφέ του PowerPoint, μπορείτε να δημιουργήσετε πειστικές αντανακλάσεις σε ένα σχήμα, να διαστέλλετε τη λάμψη ενός σχήματος, κ.λπ.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* Το PowerPoint παρέχει έξι εφέ που μπορούν να εφαρμοστούν σε σχήματα. Μπορείτε να εφαρμόσετε ένα ή περισσότερα εφέ σε ένα σχήμα. 

* Ορισμένοι συνδυασμοί εφέ φαίνονται καλύτεροι από άλλους. Για το λόγο αυτό, οι επιλογές του PowerPoint βρίσκονται κάτω από **Preset**. Οι επιλογές Preset είναι ουσιαστικά ένας γνωστός, καλοεμφανιζόμενος συνδυασμός δύο ή περισσότερων εφέ. Με αυτόν τον τρόπο, επιλέγοντας ένα preset, δεν θα χρειαστεί να σπαταλήσετε χρόνο δοκιμάζοντας ή συνδυάζοντας διαφορετικά εφέ για να βρείτε έναν ωραίο συνδυασμό.

Η Aspose.Slides παρέχει ιδιότητες και μεθόδους στην κλάση [EffectFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/EffectFormat) που σας επιτρέπουν να εφαρμόζετε τα ίδια εφέ σε σχήματα σε παρουσιάσεις PowerPoint.

## **Εφαρμογή Εφέ Σκιάς**

Αυτός ο κώδικας Java δείχνει πώς να εφαρμόσετε το εξωτερικό εφέ σκιάς ([OuterShadowEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) σε ένα ορθογώνιο:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εφαρμογή Εφέ Αντανάκλασης**

Αυτός ο κώδικας Java δείχνει πώς να εφαρμόσετε το εφέ ανάκλασης σε ένα σχήμα:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);

    pres.save("reflection.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εφαρμογή Εφέ Λάμψης**

Αυτός ο κώδικας Java δείχνει πώς να εφαρμόσετε το εφέ λάμψης σε ένα σχήμα:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    pres.save("glow.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εφαρμογή Εφέ Μαλακών Άκρων**

Αυτός ο κώδικας Java δείχνει πώς να εφαρμόσετε τα μαλακά άκρα σε ένα σχήμα:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);

    pres.save("softEdges.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω πολλαπλά εφέ στο ίδιο σχήμα;**

Ναι, μπορείτε να συνδυάσετε διαφορετικά εφέ, όπως σκιά, ανάκλαση και λάμψη, σε ένα μόνο σχήμα για να δημιουργήσετε μια πιο δυναμική εμφάνιση.

**Σε ποια σχήματα μπορώ να εφαρμόσω εφέ;**

Μπορείτε να εφαρμόσετε εφέ σε διάφορα σχήματα, συμπεριλαμβανομένων των αυτόματων σχημάτων, διαγραμμάτων, πινάκων, εικόνων, αντικειμένων SmartArt, αντικειμένων OLE και άλλα.

**Μπορώ να εφαρμόσω εφέ σε ομαδοποιημένα σχήματα;**

Ναι, μπορείτε να εφαρμόσετε εφέ σε ομαδοποιημένα σχήματα. Το εφέ θα εφαρμοστεί σε ολόκληρη την ομάδα.