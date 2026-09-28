---
title: Διαμόρφωση κειμένου παρουσίασης σε Java
linktitle: Μορφοποίηση κειμένου
type: docs
weight: 50
url: /el/java/text-formatting/
keywords:
- στοίχιση παραγράφου
- στυλ κειμένου
- υπόβαθρο κειμένου
- διαφάνεια κειμένου
- διάστημα χαρακτήρων
- ιδιότητες γραμματοσειράς
- οικογένεια γραμματοσειράς
- περιστροφή κειμένου
- γωνία περιστροφής
- πλαίσιο κειμένου
- διάστημα γραμμών
- ιδιότητα αυτόματης προσαρμογής
- άγκυρα πλαισίου κειμένου
- στηλοθέτηση κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Διαμορφώστε και στυλιζάτε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Java. Προσαρμόστε γραμματοσειρές, χρώματα, στοίχιση και άλλα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Java. Καλύπτει χρώματα υποβάθρου, διαφάνεια, διάστημα χαρακτήρων, ιδιότητες γραμματοσειράς, περιστροφή, διάστημα παραγράφων, συμπεριφορά αυτόματης προσαρμογής, αγκίστρωση κειμένου, στάσεις στηλοθετών και ρυθμίσεις γλώσσας.

Εκτός αν αναφέρεται διαφορετικά, τα παραδείγματα χρησιμοποιούν το [sample.pptx](sample.pptx). Το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα πλαίσιο κειμένου και η πρώτη παράγραφος του περιέχει το κείμενο που φαίνεται παρακάτω. Και οι αριθμοί διαφάνειας και σχήματος είναι μηδενικά. Τα παραδείγματα που επιλέγουν έντονα μέρη χρησιμοποιούν αποτελεσματική μορφοποίηση, συμπεριλαμβανομένης της κληρονομημένης έντονης μορφοποίησης:

![Δείγμα κειμένου](sample_text.png)

Για να βρείτε και να επισημάνετε κυριολεκτικό κείμενο ή αντιστοιχίες κανονικής έκφρασης, δείτε [Search and Replace Text](/slides/el/java/search-and-replace-text/).

## **Ορισμός Χρώματος Υποβάθρου Κειμένου**

Χρησιμοποιήστε το [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης για μια παράγραφο ή χρησιμοποιήστε το [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) για μεμονωμένα τμήματα κειμένου.

Το παρακάτω παράδειγμα ορίζει μια ανοιχτόγκρι επισήμανση ως προεπιλογή για την πρώτη παράγραφο. Τα ρητά χρώματα επισήμανσης στα μεμονωμένα τμήματα έχουν προτεραιότητα έναντι αυτής της προεπιλογής:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Το παρακάτω παράδειγμα δείχνει πώς να ορίσετε το χρώμα υποβάθρου για **μέρη κειμένου με έντονη γραμματοσειρά**:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Χρησιμοποιήστε το [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) για να ορίσετε το στοίχισμό της παραγράφου εντός ενός πλαισίου κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερά στοίχιση, δεξιά στοίχιση, πλήρης στοίχιση κλπ.

Το παρακάτω παράδειγμα δείχνει πώς να ευθυγραμμίσετε την παράγραφο στο **κέντρο**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ορίστε τη στοίχιση της παραγράφου στο κέντρο.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η ευθυγραμμισμένη παράγραφος](aligned_paragraph.png)

## **Ορισμός Διαφάνειας για Κείμενο**

Η διαφάνεια του κειμένου ελέγχεται μέσω του στοιχείου άλφα του χρώματος που ανατίθεται στο [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Στα παραδείγματα παρακάτω, `alpha = 50` είναι μια τιμή αλφα‑καναλιού ARGB στην κλίμακα 0–255, όχι ποσοστό διαφάνειας.

Το παρακάτω παράδειγμα δείχνει πώς να εφαρμόσετε διαφάνεια στην **ολόκληρη την παράγραφο**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Το παρακάτω παράδειγμα δείχνει πώς να εφαρμόσετε διαφάνεια σε **μέρη κειμένου με έντονη γραμματοσειρά**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Χρησιμοποιήστε το [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) για να αυξήσετε ή να μειώσετε το διάστημα μεταξύ χαρακτήρων σε ένα πλαίσιο κειμένου. Τα παραδείγματα προσθέτουν 3 σημεία διαστήματος· οι αρνητικές τιμές μειώνουν το κείμενο.

Το παρακάτω κώδικας Java δείχνει πώς να αυξήσετε το διάστημα χαρακτήρων στην **ολόκληρη την παράγραφο**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Αυξήστε το διάστημα χαρακτήρων.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στην παράγραφο](character_spacing_in_paragraph.png)

Το παρακάτω παράδειγμα δείχνει πώς να αυξήσετε το διάστημα χαρακτήρων σε **μέρη κειμένου με έντονη γραμματοσειρά**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
            portion.getPortionFormat().setSpacing(3); // Αυξήστε το διάστημα χαρακτήρων.
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

Σε ορισμένες περιπτώσεις, το κείμενο που αποδίδει το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο πυκνό από το ίδιο κείμενο που εμφανίζεται στο PowerPoint. Αυτό μπορεί να συμβεί επειδή το PowerPoint μπορεί να αγνοεί δεδομένα kerning για ορισμένες γραμματοσειρές, ακόμη και όταν η γραμματοσειρά περιέχει έγκυρες πληροφορίες kerning και το kerning είναι ενεργοποιημένο στις ρυθμίσεις του PowerPoint.

Για να προσεγγίσετε το αποτέλεσμα του PowerPoint σε τέτοιες περιπτώσεις, μπορείτε να απενεργοποιήσετε το kerning για τμήματα κειμένου που χρησιμοποιούν τη συγκεκριμένη γραμματοσειρά. Ορίστε το [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) σε τιμή μεγαλύτερη από το πραγματικό μέγεθος γραμματοσειράς. Αυτό το παράδειγμα απαιτεί το «presentation.pptx» με ένα πλαίσιο κειμένου ως το πρώτο σχήμα στην πρώτη διαφάνεια. Ελέγχει τα αποτελεσματικά ονόματα γραμματοσειρών, συμπεριλαμβανομένων των κληρονομημένων, και θέτει ένα όριο 100 σημείων για τμήματα που χρησιμοποιούν το Roboto. Αυτό απενεργοποιεί το kerning για τμήματα που έχουν μέγεθος γραμματοσειράς κάτω από 100 σημεία:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormatEffectiveData portionFormat = portion.getPortionFormat().getEffective();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για τμήματα κειμένου κάτω από το όριο, αυτή η ρύθμιση αποτρέπει το kerning και μπορεί να βοηθήσει το Aspose.Slides να ταιριάξει την οπτική έξοδο του PowerPoint για τις γραμματοσειρές που επηρεάζονται από αυτή τη συμπεριφορά.

## **Διαχείριση Ιδιοτήτων Γραμματοσειράς Κειμένου**

Οι ιδιότητες γραμματοσειράς μπορούν να οριστούν σε επίπεδο παραγράφου μέσω του [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) ή σε μεμονωμένα τμήματα μέσω του [IPortionFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportionformat/).

Το παρακάτω παράδειγμα ορίζει τη προεπιλεγμένη γραμματοσειρά της πρώτης παραγράφου σε Times New Roman 12 σημείο με έντονη, πλάγια και τελειωμένη με σημείο υπογράμμιση μορφοποίηση. Η ρητή μορφοποίηση σε μεμονωμένα τμήματα έχει προτεραιότητα έναντι αυτών των προεπιλογών:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Το παρακάτω παράδειγμα εφαρμόζει Times New Roman 13 σημεία, πλάγια μορφοποίηση και υπογράμμιση με τελείες σε τμήματα των οποίων η αποτελεσματική μορφοποίηση είναι έντονη:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

![Οι ιδιότητες γραμματοσειράς για τα τμήματα κειμένου](font_properties_for_text_portions.png)

## **Ορισμός Περιστροφής Κειμένου**

Χρησιμοποιήστε το [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) για να ορίσετε μια προεπιλεγμένη προσανατολισμό κειμένου εντός ενός σχήματος.

Το παρακάτω παράδειγμα κώδικα ορίζει τον προσανατολισμό κειμένου στο σχήμα σε [TextVerticalType.Vertical270](https://reference.aspose.com/slides/el/java/com.aspose.slides/textverticaltype/), ο οποίος περιστρέφει το κείμενο **90 μοίρες αριστερά**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η περιστροφή κειμένου](text_rotation.png)

## **Ορισμός Προσαρμοσμένης Περιστροφής για Πλαίσια Κειμένου**

Χρησιμοποιήστε το [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) για να ορίσετε μια προσαρμοσμένη γωνία περιστροφής για ένα [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/).

Ο κώδικας παρακάτω περιστρέφει το πλαίσιο κειμένου κατά 3 μοίρες δεξιόστροφα μέσα στο σχήμα:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η προσαρμοσμένη περιστροφή κειμένου](custom_text_rotation.png)

## **Ορισμός Διαστήματος Γραμμών για Παραγράφους**

Το Aspose.Slides παρέχει τις μεθόδους [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) και [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) για τον έλεγχο του διαστήματος παραγράφων. Αυτές οι ιδιότητες χρησιμοποιούνται ως εξής:

* Χρησιμοποιήστε θετική τιμή για να ορίσετε το διάστημα γραμμών ως ποσοστό του ύψους της γραμμής.
* Χρησιμοποιήστε αρνητική τιμή για να ορίσετε το διάστημα γραμμών σε σημεία.

Το παρακάτω παράδειγμα ορίζει το εσωτερικό διάστημα στην πρώτη παράγραφο στο 200 % του ύψους της γραμμής (διπλό διάστημα):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το διάστημα γραμμών στην παράγραφο](line_spacing.png)

## **Έλεγχος Αλλαγής Γραμμής**

Οι κανόνες αλλαγής γραμμής παραγράφων είναι χρήσιμοι σε στενά τμήματα κειμένου και παρουσιάσεις που συνδυάζουν Λατινικό και Ανατολικό Ασιατικό κείμενο. Οι παρακάτω μέθοδοι ανήκουν στο [IParagraphFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/), επομένως εφαρμόζονται σε ολόκληρη την παράγραφο:

- [setLatinLineBreak](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) ελέγχει τους κανόνες αλλαγής γραμμής Latin. Σε μικτό κείμενο, η αλλαγή του μπορεί επίσης να επηρεάσει το πού το Πειραστικό Ασιατικό κείμενο και η στίξη χωρίζονται.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) ελέγχει τους κανόνες αλλαγής γραμμής East Asian, συμπεριλαμβανομένων των περιορισμών στους χαρακτήρες στην αρχή και στο τέλος μιας γραμμής.

Αυτοί οι κανόνες δεν αντικαθιστούν το [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#setWrapText-byte-), το οποίο ενεργοποιεί αυτόματη αναδίπλωση εντός ενός πλαισίου κειμένου. Επηρεάζουν τη διάταξη όταν γίνεται αναδίπλωση· δεν προσθέτουν χαρακτήρες αλλαγής γραμμής. Μια ρητή αλλαγή γραμμής εξαναγκάζει νέα γραμμή στην παράγραφο ανεξάρτητα από το διαθέσιμο πλάτος.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα στενό τμήμα κειμένου που περιέχει Κινέζικο και Λατινικό κείμενο. Ορίζει και τις δύο επιλογές αλλαγής γραμμής ρητά και αποθηκεύει το «line_breaking.pptx». Για να πειραματιστείτε με κάποιον από τους κανόνες, αλλάξτε την αντίστοιχη τιμή ενώ κρατάτε τις άλλες ρυθμίσεις σταθερές. Το παράδειγμα χρησιμοποιεί Arial 24 σημεία και SimSun με πλάτος πλαισίου 160 σημεία και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου. Το [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) καλείται με το [TextAutofitType.None](https://reference.aspose.com/slides/el/java/com.aspose.slides/textautofittype/) ώστε το μέγεθος κειμένου και οι διαστάσεις του πλαισίου να παραμείνουν σταθερά.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    FontData eastAsianFont = new FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setLatinLineBreak(NullableBool.False);
    format.setEastAsianLineBreak(NullableBool.True);

    presentation.save("line_breaking.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Έλεγχος Κρεμασμού Παύσης**

Το [IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) επιτρέπει σε επιλέξιμη στίξη να εκτείνεται πέρα από την δεξιά άκρη της γραμμής κειμένου αντί να καταλαμβάνει την επόμενη γραμμή. Ισχύει για ολόκληρη την παράγραφο και διαφέρει από το κρεμασμένο εσοχή.

Το παρακάτω αυτόνομο παράδειγμα ενεργοποιεί κρεμασμένη στίξη σε πλαίσιο κειμένου πλάτους 100 σημεία και αποθηκεύει το «hanging_punctuation.pptx». Με Arial 24 σημεία και μηδενικά οριζόντια περιθώρια πλαισίου, η τελική τελεία παραμένει μετά το «sentence» και εκτείνεται πέρα από το δεξιό άκρο του κειμένου. Ορίστε την ιδιότητα σε [NullableBool.False](https://reference.aspose.com/slides/el/java/com.aspose.slides/nullablebool/) για σύγκριση: με αυτές τις ρυθμίσεις, η τελεία καταλαμβάνει ξεχωριστή γραμμή. Η αναδίπλωση είναι ενεργή και η αυτόματη προσαρμογή είναι απενεργοποιημένη για να κρατήσει το διαθέσιμο πλάτος σταθερό.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setHangingPunctuation(NullableBool.True);

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Δεν μπορεί να κρέμεται κάθε σύμβολο στίξης. Το οπτικό αποτέλεσμα εξαρτάται από τη διαθεσιμότητα της γραμματοσειράς και τη διάταξη: η αλλαγή της γραμματοσειράς, του διαθέσιμου πλάτους, των περιθωρίων ή των ρυθμίσεων αυτόματης προσαρμογής μπορεί να αφαιρέσει τη διαφορά.

## **Ορισμός Τύπου Αυτόματης Προσαρμογής για Πλαίσια Κειμένου**

Το [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) καθορίζει πώς συμπεριφέρεται το κείμενο όταν ξεπερνά τα όρια του δοχείου του. Χρησιμοποιήστε το για να ελέγξετε εάν το κείμενο συρρικνώνεται, υπερχειλίζει ή αλλάζει το μέγεθος του σχήματος αυτόματα. Το παρακάτω παράδειγμα ρυθμίζει το σχήμα ώστε να αλλάζει μέγεθος ώστε να ταιριάζει στο κείμενό του και αποθηκεύει το αποτέλεσμα στο «autofit_type.pptx».

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για να μετρήσετε τις γραμμές μετά την αυτόματη αναδίπλωση και να δείτε πώς η αλλαγή του πλάτους κειμένου ή σχήματος επηρεάζει το αποτέλεσμα, δείτε το [Count Rendered Lines](/slides/el/java/manage-paragraph/). Ο αριθμός γραμμών από μόνος του δεν υποδεικνύει εάν το κείμενο υπερχειλίζει το δοχείο του.

## **Ορισμός Άγκυρας Πλαισίων Κειμένου**

Το [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) ορίζει πώς τοποθετείται κατακόρυφα το κείμενο μέσα σε ένα σχήμα, π.χ. στην κορυφή, στη μέση ή στο κάτω μέρος. Το παρακάτω παράδειγμα αγκυροβολεί το κείμενο στο κάτω μέρος του πρώτου σχήματος και αποθηκεύει το αποτέλεσμα στο «text_anchor.pptx».

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Στηλοθετών Κειμένου**

Χρησιμοποιήστε το [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) και το [IParagraphFormat.getTabs](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#getTabs--) για να ρυθμίσετε τις στάσεις στηλοθέτη σε μια παράγραφο. Το παρακάτω παράδειγμα ορίζει το προεπιλεγμένο διάστημα στηλοθέτη στα 100 σημεία και προσθέτει μια αριστερά στοίχιση στηλοθέτη στα 30 σημεία. Αυτές οι ρυθμίσεις επηρεάζουν κείμενο που περιέχει χαρακτήρες στηλοθέτη.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    
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

## **Ορισμός Γλώσσας Διόρθωσης**

Το Aspose.Slides παρέχει το [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), το οποίο σας επιτρέπει να ορίσετε τη γλώσσα διόρθωσης για ένα τμήμα κειμένου. Η γλώσσα διόρθωσης καθορίζει τη γλώσσα που χρησιμοποιείται για ελέγχους ορθογραφίας και γραμματικής στο PowerPoint.

Το παρακάτω παράδειγμα απαιτεί το «presentation.pptx» με ένα πλαίσιο κειμένου ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον μια παράγραφο. Αντικαθιστά το περιεχόμενο της πρώτης παραγράφου με «1。», ορίζει το SimSun ως γραμματοσειρά του και θέτει τη γλώσσα διόρθωσης Simplified Chinese (`zh-CN`). Αποθηκεύει το αποτέλεσμα στο «proofing_language.pptx»:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Ορίστε το Id μιας γλώσσας διόρθωσης.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Χρησιμοποιήστε το [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) για να ορίσετε τη προεπιλεγμένη γλώσσα για κείμενο που δημιουργείται κατά τη φόρτωση ή τη δημιουργία μιας παρουσίασης. Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με US English ως προεπιλεγμένη γλώσσα κειμένου, προσθέτει ένα πλαίσιο κειμένου και εκτυπώνει `en-US` για το πρώτο τμήμα κειμένου.

```java
import com.aspose.slides.*;

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

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου στο επίπεδο της παρουσίασης, χρησιμοποιήστε το [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Το παρακάτω παράδειγμα ορίζει μια γραμματοσειρά 14 σημείο έντονη ως προεπιλογή για παραγράφους κορυφαίου επιπέδου σε μια νέα παρουσίαση και το αποθηκεύει στο «default_text_style.pptx». Το κείμενο μπορεί να κληρονομήσει αυτές τις προεπιλογές εκτός εάν πιο συγκεκριμένη μορφοποίηση τις υπερισχύει.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Λάβετε τη μορφοποίηση παραγράφου ανώτερου επιπέδου.
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

## **Εξαγωγή Κειμένου με το Εφέ Όλων Κεφαλαίων**

Στο PowerPoint, η εφαρμογή του εφέ **All Caps** κάνει το κείμενο να εμφανίζεται με κεφαλαία γράμματα στη διαφάνεια ακόμη και όταν αρχικά πληκτρολογήθηκε με πεζά. Όταν ανακτάτε ένα τέτοιο τμήμα κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως εισήχθη. Για να ταιριάξετε το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/el/java/com.aspose.slides/textcaptype/) και μετατρέψτε τη επιστρεφόμενη συμβολοσειρά σε κεφαλαία όταν η τιμή είναι `All`.

Το παράδειγμα απαιτεί το «sample2.pptx» με ένα πλαίσιο κειμένου ως το πρώτο σχήμα στην πρώτη διαφάνεια. Η πρώτη παράγραφος του πρώτου τμήματος περιέχει «Hello, Aspose!» με το εφέ All Caps εφαρμόσμένο, όπως φαίνεται παρακάτω.

![Το εφέ Όλων Κεφαλαίων](all_caps_effect.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε το κείμενο με το **All Caps** εφέ εφαρμοσμένο:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Αποτέλεσμα:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Συχνές Ερωτήσεις**

**Πώς τροποποιώ κείμενο σε πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε κείμενο σε πίνακα σε μια διαφάνεια, χρησιμοποιήστε το [ITable](https://reference.aspose.com/slides/el/java/com.aspose.slides/itable/). Επανάγετε τα κελιά και ενημερώστε κάθε κελί μέσω του [ICell.getTextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/icell/#getTextFrame--) και τη μορφοποίηση παραγράφων μέσω του [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Πώς εφαρμόζω διαβαθμισμένο χρώμα σε κείμενο σε μια διαφάνεια PowerPoint;**

Για να εφαρμόσετε διαβαθμισμένο χρώμα σε κείμενο, χρησιμοποιήστε το [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Ορίστε το [IFillFormat.setFillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifillformat/#setFillType-byte-) σε [FillType.Gradient](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) και διαμορφώστε τις στάσεις διαβάθμισης, την κατεύθυνση και τη διαφάνεια.