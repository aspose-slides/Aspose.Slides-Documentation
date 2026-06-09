---
title: Διαμόρφωση Κειμένου Παρουσίασης σε Android
linktitle: Μορφοποίηση Κειμένου
type: docs
weight: 50
url: /el/androidjava/text-formatting/
keywords:
- επισήμανση κειμένου
- κανονική έκφραση
- στοίχιση παραγράφου
- στυλ κειμένου
- φόντο κειμένου
- διαφάνεια κειμένου
- απόσταση χαρακτήρων
- ιδιότητες γραμματοσειράς
- οικογένεια γραμματοσειράς
- περιστροφή κειμένου
- γωνία περιστροφής
- πλαίσιο κειμένου
- διάστιχο
- ιδιότητα αυτόματης προσαρμογής
- άγκυρο πλαισίου κειμένου
- στηλοθέτηση κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαμορφώστε και εφαρμόστε στυλ κειμένου σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Android μέσω Java. Προσαρμόστε γραμματοσειρές, χρώματα, στοίχιση και άλλα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Android μέσω Java. Καλύπτει την επισήμανση, τα χρώματα φόντου, τη διαφάνεια, την απόσταση χαρακτήρων, τις ιδιότητες γραμματοσειράς, την περιστροφή, την απόσταση παραγράφων, τη συμπεριφορά αυτόματης προσαρμογής, την αγκύρωση κειμένου, τις στάσεις καρτέλας και τις ρυθμίσεις γλώσσας.

Στα παρακάτω παραδείγματα, θα χρησιμοποιήσουμε ένα αρχείο με όνομα "sample.pptx", το οποίο περιέχει ένα μοναδικό πλαίσιο κειμένου στην πρώτη διαφάνεια με το παρακάτω κείμενο:

![Δείγμα κειμένου](sample_text.png)

## **Επισήμανση κειμένου**

Χρησιμοποιήστε τη [ITextFrame.highlightText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.lang.Integer-) μέθοδο όταν χρειάζεστε να επισημάνετε κείμενο που ταιριάζει με ένα συγκεκριμένο δείγμα μέσα σε ένα πλαίσιο κειμένου. Η μέθοδος εφαρμόζει χρώμα επισήμανσης στα αντίστοιχα τμήματα κειμένου και μπορεί να χρησιμοποιηθεί με το [ITextSearchOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextSearchOptions) για να ελέγξετε πώς εκτελείται η αναζήτηση, για παράδειγμα, για να ταιριάζει μόνο σε ολόκληρες λέξεις.

Το παρακάτω παράδειγμα κώδικα επισημαίνει όλες τις εμφανίσεις των χαρακτήρων **"try"** και στη συνέχεια επισημαίνει μόνο τη λέξη **"to"**.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Λήψη του πρώτου σχήματος από την πρώτη διαφάνεια.
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Επισήμανση της λέξης "try" στο σχήμα.
    shape.getTextFrame().highlightText("try", Color.rgb(173, 216, 230));

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Επισήμανση της λέξης "to" στο σχήμα.
    int violetColor = Color.rgb(238, 130, 238);
    shape.getTextFrame().highlightText("to", violetColor, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το επισημασμένο κείμενο](highlighted_text.png)

## **Επισήμανση κειμένου με χρήση κανονικών εκφράσεων**

Η μέθοδος [ITextFrame.highlightRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) επισημαίνει ταιριάσματα κειμένου που εντοπίζονται με μια κανονική έκφραση.

Το παρακάτω παράδειγμα κώδικα επισημαίνει όλες τις λέξεις που περιέχουν **επτά ή περισσότερους χαρακτήρες**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // Επισήμανση όλων των λέξεων με επτά ή περισσότερους χαρακτήρες.
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το επισημασμένο κείμενο χρησιμοποιώντας την κανονική έκφραση](highlighted_text_using_regex.png)

## **Ορισμός χρώματος φόντου κειμένου**

Χρησιμοποιήστε το [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης για μια παράγραφο, ή χρησιμοποιήστε το [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IBasePortionFormat#getHighlightColor--) για μεμονωμένα τμήματα κειμένου.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **ολόκληρη την παράγραφο**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ορίστε το χρώμα επισήμανσης για ολόκληρη την παράγραφο.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η γκρι παράγραφος](gray_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **τμήματα κειμένου με έντονη γραμματοσειρά**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Ορίστε το χρώμα επισήμανσης για το τμήμα κειμένου.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Τα γκρίζα τμήματα κειμένου](gray_text_portions.png)

## **Στοίχιση παραγράφων κειμένου**

Χρησιμοποιήστε το [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IParagraphFormat#setAlignment-byte-) για να ορίσετε την ευθυγράμμιση παραγράφων μέσα σε ένα πλαίσιο κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερή, δεξιά, πλήρως ευθυγραμμισμένη κλπ.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ευθυγραμμίσετε την παράγραφο στο **κέντρο**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ορίστε την ευθυγράμμιση της παραγράφου στο κέντρο.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η ευθυγραμμισμένη παράγραφος](aligned_paragraph.png)

## **Ορισμός διαφάνειας για κείμενο**

Η διαφάνεια του κειμένου ελέγχεται μέσω του συστατικού alpha του χρώματος που έχει εκχωρηθεί στο [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--). Στα παρακάτω παραδείγματα, `alpha = 50` είναι μια τιμή καναλιού alpha ARGB στην κλίμακα 0‑255, όχι ποσοστό διαφάνειας.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια στην **ολόκληρη την παράγραφο**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ορίστε το χρώμα γεμίσματος του κειμένου σε διαφανές χρώμα.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η διαφανής παράγραφος](transparent_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Ορίστε τη διαφάνεια του τμήματος κειμένου.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Τα διαφανή τμήματα κειμένου](transparent_text_portions.png)

## **Ορισμός μεταξύ χαρακτήρων για κείμενο**

Χρησιμοποιήστε το [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IBasePortionFormat#setSpacing-float-) για να αυξήσετε ή να μειώσετε την απόσταση μεταξύ χαρακτήρων σε ένα πλαίσιο κειμένου.

Ο παρακάτω κώδικας Java δείχνει πώς να αυξήσετε την απόσταση χαρακτήρων στην **ολόκληρη την παράγραφο**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε την απόσταση χαρακτήρων.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Επέκταση απόστασης χαρακτήρων.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η απόσταση χαρακτήρων στην παράγραφο](character_spacing_in_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να αυξήσετε την απόσταση χαρακτήρων σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε την απόσταση χαρακτήρων.
            portion.getPortionFormat().setSpacing(3); // Επέκταση απόστασης χαρακτήρων.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η απόσταση χαρακτήρων στα τμήματα κειμένου](character_spacing_in_text_portions.png)

### **Απενεργοποίηση του Kerning για συγκεκριμένες γραμματοσειρές**

Σε ορισμένες περιπτώσεις, το κείμενο που αποδίδεται από το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο στενό από το ίδιο κείμενο που εμφανίζεται στο PowerPoint. Αυτό μπορεί να συμβαίνει επειδή το PowerPoint μπορεί να αγνοεί τα δεδομένα kerning για ορισμένες γραμματοσειρές, ακόμη και όταν η γραμματοσειρά περιέχει έγκυρες πληροφορίες kerning και το kerning είναι ενεργοποιημένο στις ρυθμίσεις του PowerPoint.

Για να γίνει η παραγόμενη έξοδος πιο κοντά στο PowerPoint σε τέτοιες περιπτώσεις, μπορείτε να απενεργοποιήσετε το kerning για τμήματα κειμένου που χρησιμοποιούν τηffected γραμματοσειρά. Ορίστε το [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IBasePortionFormat#setKerningMinimalSize-float-) σε μια τιμή σημαντικά μεγαλύτερη από το πραγματικό μέγεθος γραμματοσειράς:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (int paragraphIndex = 0; paragraphIndex < autoShape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

        for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            IFontData latinFont = portion.getPortionFormat().getLatinFont();
            IFontData eastAsianFont = portion.getPortionFormat().getEastAsianFont();
            IFontData complexScriptFont = portion.getPortionFormat().getComplexScriptFont();

            boolean usesTargetFont =
                    latinFont != null && targetFont.equals(latinFont.getFontName()) ||
                    eastAsianFont != null && targetFont.equals(eastAsianFont.getFontName()) ||
                    complexScriptFont != null && targetFont.equals(complexScriptFont.getFontName());

            if (usesTargetFont) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αυτή η ρύθμιση εμποδίζει την εφαρμογή του kerning σε τμήματα κειμένου που ταιριάζουν και μπορεί να βοηθήσει στην ευθυγράμμιση της απόδοσης του Aspose.Slides με την οπτική έξοδο του PowerPoint για τις γραμματοσειρές που επηρεάζονται από αυτήν τη συμπεριφορά ειδική του PowerPoint.

## **Διαχείριση ιδιοτήτων γραμματοσειράς κειμένου**

Οι ιδιότητες γραμματοσειράς μπορούν να οριστούν σε επίπεδο παραγράφου μέσω του [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) ή σε μεμονωμένα τμήματα μέσω του [IPortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPortionFormat).

Ο παρακάτω κώδικας ορίζει τη γραμματοσειρά και το στυλ κειμένου για ολόκληρη την παράγραφο: εφαρμόζει μέγεθος γραμματοσειράς, έντονα, πλάγια, ψαλίδιασμένη υπογράμμιση και τη γραμματοσειρά Times New Roman σε όλα τα τμήματα της παραγράφου.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Το παρακάτω παράδειγμα κώδικα εφαρμόζει παρόμοιες ιδιότητες σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

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

![Οι ιδιότητες γραμματοσειράς για τα τμήματα κειμένου](font_properties_for_text_portions.png)

## **Ορισμός περιστροφής κειμένου**

Χρησιμοποιήστε το [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-) για να ορίσετε μια προκαθορισμένη προσανατολισμό κειμένου μέσα σε ένα σχήμα.

Το παρακάτω παράδειγμα κώδικα ορίζει τον προσανατολισμό κειμένου στο σχήμα σε `Vertical270`, που περιστρέφει το κείμενο **90 μοίρες αριστερόστροφα**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η περιστροφή κειμένου](text_rotation.png)

## **Ορισμός προσαρμοσμένης περιστροφής για πλαίσια κειμένου**

Χρησιμοποιήστε το [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) για να ορίσετε μια προσαρμοσμένη γωνία περιστροφής για ένα [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrame).

Το παρακάτω παράδειγμα κώδικα περιστρέφει το πλαίσιο κειμένου κατά 3 μοίρες δεξιόστροφα μέσα στο σχήμα:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η προσαρμοσμένη περιστροφή κειμένου](custom_text_rotation.png)

## **Ορισμός διαστήματος γραμμών για παραγράφους**

Το Aspose.Slides παρέχει τα [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IParagraphFormat#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IParagraphFormat#setSpaceBefore-float-) και [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IParagraphFormat#setSpaceWithin-float-) για να ελέγξετε το διάστημα παραγράφων. Αυτές οι ιδιότητες χρησιμοποιούνται ως εξής:

* Χρησιμοποιήστε θετική τιμή για να καθορίσετε το διάστημα γραμμών ως ποσοστό του ύψους της γραμμής.
* Χρησιμοποιήστε αρνητική τιμή για να καθορίσετε το διάστημα γραμμών σε μονάδες (points).

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να καθορίσετε το διάστημα γραμμών εντός της παραγράφου:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το διάστημα γραμμών εντός της παραγράφου](line_spacing.png)

## **Ορισμός τύπου αυτόματης προσαρμογής για πλαίσια κειμένου**

Η [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) καθορίζει πώς συμπεριφέρεται το κείμενο όταν υπερβαίνει τα όρια του περιέκτη του. Χρησιμοποιήστε το για να ελέγξετε εάν το κείμενο συρρικνώνεται, υπερέχει ή αλλάζει αυτόματα το μέγεθος του σχήματος.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός αγκύρωσης πλαισίων κειμένου**

Η [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) ορίζει πώς το κείμενο τοποθετείται κατακόρυφα μέσα σε ένα σχήμα, π.χ. στην κορυφή, τη μέση ή το κάτω μέρος.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός στηλοθέτησης κειμένου**

Χρησιμοποιήστε το [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IParagraphFormat#setDefaultTabSize-float-) και το [IParagraphFormat.getTabs](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IParagraphFormat#getTabs--) για να ρυθμίσετε τις στάσεις καρτέλας σε μια παράγραφο.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι στάσεις της παραγράφου](paragraph_tabs.png)

## **Ορισμός γλώσσας ορθογραφικού ελέγχου**

Το Aspose.Slides παρέχει το [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-), το οποίο σας επιτρέπει να ορίσετε τη γλώσσα ελέγχου για ένα τμήμα κειμένου. Η γλώσσα ελέγχου καθορίζει τη γλώσσα που χρησιμοποιείται για τον ορθογραφικό και γραμματικό έλεγχο στο PowerPoint.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε τη γλώσσα ελέγχου για ένα τμήμα κειμένου:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Ορίστε το αναγνωριστικό γλώσσας ελέγχου.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός προεπιλεγμένης γλώσσας**

Χρησιμοποιήστε το [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/LoadOptions#setDefaultTextLanguage-java.lang.String-) για να ορίσετε την προεπιλεγμένη γλώσσα για το κείμενο που δημιουργείται κατά τη φόρτωση ή τη δημιουργία μιας παρουσίασης.

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθήκη νέου σχήματος ορθογωνίου με κείμενο.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Έλεγχος της γλώσσας του πρώτου τμήματος.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Ορισμός προεπιλεγμένου στυλ κειμένου**

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου στο επίπεδο παρουσίασης, χρησιμοποιήστε το [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentation#getDefaultTextStyle--).

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε μια προεπιλεγμένη έντονη γραμματοσειρά με μέγεθος 14 pt για όλο το κείμενο σε όλες τις διαφάνειες σε μια νέα παρουσίαση.

```java
Presentation presentation = new Presentation();
try {
    // Λήψη μορφοποίησης παραγράφου του ανώτερου επιπέδου.
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

## **Εξαγωγή κειμένου με το εφέ Όλων Κεφαλαίων**

Στο PowerPoint, η εφαρμογή του εφέ **All Caps** στην γραμματοσειρά κάνει το κείμενο να εμφανίζεται με κεφαλαία γράμματα στη διαφάνεια ακόμη και όταν είχε πληκτρολογηθεί αρχικά με πεζά. Όταν παίρνετε τέτοιο τμήμα κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως εισήχθηκε. Για να ταιριάξει με το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/TextCapType) και μετατρέψτε τη επιστρεφόμενη συμβολοσειρά σε κεφαλαία όταν η τιμή είναι `All`.

Ας υποθέσουμε ότι έχουμε το παρακάτω πλαίσιο κειμένου στην πρώτη διαφάνεια του αρχείου sample2.pptx.

![Το εφέ Όλων Κεφαλαίων](all_caps_effect.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε το κείμενο με το εφέ **All Caps** εφαρμοσμένο:

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

## **FAQ**

**Πώς να τροποποιήσετε κείμενο σε έναν πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε κείμενο σε έναν πίνακα σε μια διαφάνεια, χρησιμοποιήστε το [ITable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITable). Περάστε από τα κελιά και ενημερώστε κάθε κελί μέσω του [ICell.getTextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ICell#getTextFrame--) και τη μορφοποίηση παραγράφων μέσω του [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IParagraph#getParagraphFormat--).

**Πώς να εφαρμόσετε χρώμα διαβάθμισης σε κείμενο σε μια διαφάνεια PowerPoint;**

Για να εφαρμόσετε χρώμα διαβάθμισης σε κείμενο, χρησιμοποιήστε το [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--). Ορίστε το [IFillFormat.setFillType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IFillFormat#setFillType-int-) σε [FillType.Gradient](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FillType) και διαμορφώστε τις στάσεις διαβάθμισης, την κατεύθυνση και τη διαφάνεια.