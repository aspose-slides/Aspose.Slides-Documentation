---
title: Διαμόρφωση Κειμένου Παρουσίασης σε Java
linktitle: Μορφοποίηση Κειμένου
type: docs
weight: 50
url: /el/java/text-formatting/
keywords:
- επισήμανση κειμένου
- κανονική έκφραση
- στοίχιση παραγράφου
- στυλ κειμένου
- φόντο κειμένου
- διαφάνεια κειμένου
- διάστημα χαρακτήρων
- ιδιότητες γραμματοσειράς
- οικογένεια γραμματοσειράς
- περιστροφή κειμένου
- γωνία περιστροφής
- πλαίσιο κειμένου
- διάστημα γραμμής
- ιδιότητα autofit
- άγκυρο πλαισίου κειμένου
- στηλοθέτηση κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Διαμορφώστε και στυλιζάρετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Java. Προσαρμόστε γραμματοσειρές, χρώματα, στοίχιση και άλλα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides for Java. Καλύπτει την επισήμανση, τα χρώματα φόντου, τη διαφάνεια, το διάστημα χαρακτήρων, τις ιδιότητες γραμματοσειράς, την περιστροφή, το διάστημα παραγράφων, τη συμπεριφορά autofit, την αγκύρωση κειμένου, τις στάσεις στηλοθέτη και τις ρυθμίσεις γλώσσας.

Στα παρακάτω παραδείγματα, θα χρησιμοποιήσουμε ένα αρχείο με όνομα "sample.pptx", το οποίο περιέχει ένα μόνο πλαίσιο κειμένου στην πρώτη διαφάνεια με το ακόλουθο κείμενο:

![Δείγμα κειμένου](sample_text.png)

## **Επισήμανση Κειμένου**

Χρησιμοποιήστε τη μέθοδο [ITextFrame.highlightText](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-) όταν χρειάζεται να επισημάνετε κείμενο που ταιριάζει με ένα συγκεκριμένο δείγμα εντός ενός πλαισίου κειμένου. Η μέθοδος εφαρμόζει χρώμα επισήμανσης στα τμήματα κειμένου που ταιριάζουν και μπορεί να χρησιμοποιηθεί με το [TextSearchOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/textsearchoptions/) για να ελέγξετε πώς εκτελείται η αναζήτηση, π.χ. για να ταιριάζει μόνο σε ολόκληρες λέξεις.

Το παρακάτω παράδειγμα κώδικα επισημαίνει όλες τις εμφανίσεις των χαρακτήρων **"try"** και στη συνέχεια επισημαίνει μόνο τη λέξη **"to"**.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Λάβετε το πρώτο σχήμα από την πρώτη διαφάνεια.
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Επισημάνετε τη λέξη "try" στο σχήμα.
    shape.getTextFrame().highlightText("try", Color.LIGHT_GRAY);

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Επισημάνετε τη λέξη "to" στο σχήμα.
    shape.getTextFrame().highlightText("to", Color.MAGENTA, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το επισημασμένο κείμενο](highlighted_text.png)

## **Επισήμανση Κειμένου με Χρήση Κανονικών Εκφράσεων**

Η μέθοδος [ITextFrame.highlightRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) επισημαίνει τις αντιστοιχίες κειμένου που βρέθηκαν από μια κανονική έκφραση. Στη Java, αυτό το API εκτίθεται στο [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/).

Το παρακάτω παράδειγμα κώδικα επισημαίνει όλες τις λέξεις που περιέχουν **εφτά ή περισσότερους χαρακτήρες**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // Επiσiμaνeστε όλeς τiς λεξeί μe επτα ή πλeίσeρoυσeς χαρακτήρες.
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το επισημασμένο κείμενο με χρήση κανονικής έκφρασης](highlighted_text_using_regex.png)

## **Ορισμός Χρώματος Φόντου Κειμένου**

Χρησιμοποιήστε το [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης για μια παράγραφο, ή το [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) για μεμονωμένα τμήματα κειμένου.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **ολόκληρη την παράγραφο**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ορίστε το χρώμα επισήμανσης για ολόκληρη την παράγραφο.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η γκρι παράγραφος](gray_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **τμήματα κειμένου με έντονη γραφή**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Ορίστε το χρώμα επισήμανσης για το τμήμα κειμένου.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Τα γκρι τμήματα κειμένου](gray_text_portions.png)

## **Στοίχιση Παραγράφων Κειμένου**

Χρησιμοποιήστε το [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) για να ορίσετε στοίχιση παραγράφου εντός ενός πλαισίου κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερή, δεξιά, πλήρως στοιχισμένη κ.λπ.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να στοιχίσετε την παράγραφο **στο κέντρο**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ορίστε το στοίχισμα της παραγράφου στο κέντρο.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η στοιχισμένη παράγραφος](aligned_paragraph.png)

## **Ορισμός Διαφάνειας για Κείμενο**

Η διαφάνεια κειμένου ελέγχεται μέσω του συστατικού άλφα του χρώματος που έχει οριστεί στο [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Στα παρακάτω παραδείγματα, `alpha = 50` είναι μια τιμή καναλιού άλφα ARGB στην κλίμακα 0‑255, όχι ποσοστό διαφάνειας.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **ολόκληρη την παράγραφο**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ορίστε το χρώμα γεμίσματος του κειμένου σε διαφανές χρώμα.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η διαφανής παράγραφος](transparent_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **τμήματα κειμένου με έντονη γραφή**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Ορίστε τη διαφάνεια του τμήματος κειμένου.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Τα διαφανή τμήματα κειμένου](transparent_text_portions.png)

## **Ορισμός Διαστήματος Χαρακτήρων για Κείμενο**

Χρησιμοποιήστε το [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) για να αυξήσετε ή να μειώσετε το διάστημα μεταξύ χαρακτήρων σε ένα πλαίσιο κειμένου.

Το παρακάτω Java κώδικα δείχνει πώς να αυξήσετε το διάστημα χαρακτήρων σε **ολόκληρη την παράγραφο**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Επεκτείνετε το διάστημα χαρακτήρων.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στην παράγραφο](character_spacing_in_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να αυξήσετε το διάστημα χαρακτήρων σε **τμήματα κειμένου με έντονη γραφή**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
            portion.getPortionFormat().setSpacing(3); // Επεκτείνετε το διάστημα χαρακτήρων.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στα τμήματα κειμένου](character_spacing_in_text_portions.png)

### **Απενεργοποίηση Kerning για Συγκεκριμένες Γραμματοσειρές**

Σε ορισμένες περιπτώσεις, το κείμενο που δημιουργείται από το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο πυκνό από το ίδιο κείμενο που εμφανίζεται στο PowerPoint. Αυτό μπορεί να συμβαίνει επειδή το PowerPoint μπορεί να αγνοεί τα δεδομένα kerning για ορισμένες γραμματοσειρές, ακόμη και όταν η γραμματοσειρά περιέχει έγκυρες πληροφορίες kerning και το kerning είναι ενεργοποιημένο στις ρυθμίσεις του PowerPoint.

Για να προσεγγίσετε πιο κοντά το αποτέλεσμα που εμφανίζει το PowerPoint, μπορείτε να απενεργοποιήσετε το kerning για τμήματα κειμένου που χρησιμοποιούν τη σχετική γραμματοσειρά. Ορίστε το [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) σε μια τιμή σημαντικά μεγαλύτερη από το πραγματικό μέγεθος γραμματοσειράς:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormat portionFormat = portion.getPortionFormat();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αυτή η ρύθμιση αποτρέπει την εφαρμογή του kerning σε τμήματα κειμένου που ταιριάζουν και μπορεί να βοηθήσει στην ευθυγράμμιση της απόδοσης του Aspose.Slides με το οπτικό αποτέλεσμα του PowerPoint για γραμματοσειρές που επηρεάζονται από αυτή τη συμπεριφορά ειδική του PowerPoint.

## **Διαχείριση Ιδιοτήτων Γραμματοσειράς Κειμένου**

Οι ιδιότητες γραμματοσειράς μπορούν να οριστούν σε επίπεδο παραγράφου μέσω του [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) ή σε μεμονωμένα τμήματα μέσω του [IPortionFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportionformat/).

Ο παρακάτω κώδικας ορίζει τη γραμματοσειρά και το στυλ κειμένου για ολόκληρη την παράγραφο: εφαρμόζει μέγεθος γραμματοσειράς, έντονη γραφή, πλάγια, υπογράμμιση με κουκκίδες και τη γραμματοσειρά Times New Roman σε όλα τα τμήματα της παραγράφου.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ορίστε τις ιδιότητες γραμματοσειράς για την παράγραφο.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για την παράγραφο](font_properties_for_paragraph.png)

Το παρακάτω παράδειγμα κώδικα εφαρμόζει παρόμοιες ιδιότητες σε **τμήματα κειμένου με έντονη γραφή**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Ορίστε τις ιδιότητες γραμματοσειράς για το τμήμα κειμένου.
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για τμήματα κειμένου](font_properties_for_text_portions.png)

## **Ορισμός Περιστροφής Κειμένου**

Χρησιμοποιήστε το [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) για να ορίσετε έναν προκαθορισμένο προσανατολισμό κειμένου μέσα σε ένα σχήμα.

Το παρακάτω παράδειγμα κώδικα ορίζει τον προσανατολισμό κειμένου στο σχήμα σε `Vertical270`, που περιστρέφει το κείμενο **90 μοίρες αριστερόστροφα**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η περιστροφή του κειμένου](text_rotation.png)

## **Ορισμός Προσαρμοσμένης Περιστροφής για Πλαίσια Κειμένου**

Χρησιμοποιήστε το [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) για να ορίσετε προσαρμοσμένη γωνία περιστροφής για ένα [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/).

Το παρακάτω παράδειγμα κώδικα περιστρέφει το πλαίσιο κειμένου κατά 3 μοίρες αριστερόστροφα μέσα στο σχήμα:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η προσαρμοσμένη περιστροφή κειμένου](custom_text_rotation.png)

## **Ορισμός Διαστήματος Γραμμής Παραγράφων**

Το Aspose.Slides παρέχει τις μεθόδους [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) και [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) για να ελέγξετε το διάστημα παραγράφων. Οι ιδιότητες αυτές χρησιμοποιούνται ως εξής:

* Χρησιμοποιήστε θετική τιμή για να καθορίσετε το διάστημα γραμμής ως ποσοστό του ύψους γραμμής.
* Χρησιμοποιήστε αρνητική τιμή για να καθορίσετε το διάστημα γραμμής σε σημεία.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το διάστημα γραμμής στην παράγραφο:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το διάστημα γραμμής στην παράγραφο](line_spacing.png)

## **Ορισμός Τύπου Autofit για Πλαίσια Κειμένου**

Η μέθοδος [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) καθορίζει πώς συμπεριφέρεται το κείμενο όταν υπερβαίνει τα όρια του δοχείου του. Χρησιμοποιήστε την για να ελέγξετε εάν το κείμενο θα μικρύνει, θα υπερχειλίσει ή θα προσαρμόσει αυτόματα το σχήμα.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Αγκύρωσης Πλαισίων Κειμένου**

Η μέθοδος [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) ορίζει πώς το κείμενο τοποθετείται κάθετα μέσα σε ένα σχήμα, π.χ. στην κορυφή, στο μέσο ή στο τέλος.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Στηλοθετή Κειμένου**

Χρησιμοποιήστε τις μεθόδους [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) και [IParagraphFormat.getTabs](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#getTabs--) για να διαμορφώσετε τις στάσεις στηλοθέτη σε μια παράγραφο.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι στηλοθέτες της παραγράφου](paragraph_tabs.png)

## **Ορισμός Γλώσσας Ελέγχου Αρθογραφίας**

Το Aspose.Slides παρέχει τη μέθοδο [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) που επιτρέπει τον ορισμό της γλώσσας ελέγχου (proofing) για ένα τμήμα κειμένου. Η γλώσσα ελέγχου καθορίζει τη γλώσσα που χρησιμοποιείται για ελέγχους ορθογραφίας και γραμματικής στο PowerPoint.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε τη γλώσσα ελέγχου για ένα τμήμα κειμένου:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Ορίστε το Id της γλώσσας ελέγχου.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Χρησιμοποιήστε τη μέθοδο [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) για να ορίσετε τη προεπιλεγμένη γλώσσα για κείμενο που δημιουργείται κατά τη φόρτωση ή δημιουργία μιας παρουσίασης.

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα νέο σχήμα ορθογωνίου με κείμενο.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Ελέγξτε τη γλώσσα του πρώτου τμήματος.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Ορισμός Προεπιλεγμένου Στυλ Κειμένου**

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου σε επίπεδο παρουσίασης, χρησιμοποιήστε το [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε μια προεπιλεγμένη έντονη γραμματοσειρά με μέγεθος 14 pt για όλο το κείμενο σε όλες τις διαφάνειες μιας νέας παρουσίασης.

```java
Presentation presentation = new Presentation();
try {
    // Λάβετε τη μορφοποίηση παραγράφου του ανώτερου επιπέδου.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Εξαγωγή Κειμένου με Εφέ Όλων Σε Κεφαλαία**

Στο PowerPoint, η εφαρμογή του εφέ **All Caps** κάνει το κείμενο να εμφανίζεται με κεφαλαία γράμματα στη διαφάνεια ακόμη και αν αρχικά είχε πληκτρολογηθεί με πεζά. Όταν εξάγετε ένα τέτοιο τμήμα κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως εισήχθη. Για να ταιριάξετε το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/el/java/com.aspose.slides/textcaptype/) και μετατρέψτε το επιστρεφόμενο string σε κεφαλαία όταν η τιμή είναι `All`.

Ας υποθέσουμε ότι έχουμε το παρακάτω πλαίσιο κειμένου στην πρώτη διαφάνεια του αρχείου sample2.pptx.

![Το εφέ All Caps](all_caps_effect.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε το κείμενο με το εφαρμόσμένο εφέ **All Caps**:

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

Έξοδος:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Συχνές Ερωτήσεις**

**Πώς να τροποποιήσετε κείμενο σε πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε κείμενο σε πίνακα σε μια διαφάνεια, χρησιμοποιήστε το [ITable](https://reference.aspose.com/slides/el/java/com.aspose.slides/itable/). Περιηγηθείτε στα κελιά και ενημερώστε κάθε κελί μέσω του [ICell.getTextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/icell/#getTextFrame--) και τη μορφοποίηση παραγράφων μέσω του [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Πώς να εφαρμόσετε χρώμα διαβάθμισης σε κείμενο σε διαφάνεια PowerPoint;**

Για να εφαρμόσετε χρώμα διαβάθμισης σε κείμενο, χρησιμοποιήστε το [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Ορίστε το [IFillFormat.setFillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifillformat/#setFillType-byte-) σε [FillType.Gradient](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) και διαμορφώστε τις στάσεις διαβάθμισης, την κατεύθυνση και τη διαφάνεια.