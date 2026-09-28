---
title: Μορφοποίηση κειμένου παρουσίασης σε Android
linktitle: Μορφοποίηση κειμένου
type: docs
weight: 50
url: /el/androidjava/text-formatting/
keywords:
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
- ιδιότητα autofit
- άγκυρο πλαισίου κειμένου
- στηλοθέτηση κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μορφοποιήστε και σχεδιάστε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Android μέσω Java. Προσαρμόστε γραμματοσειρές, χρώματα, στοίχιση και άλλα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Android μέσω Java. Καλύπτει χρώματα φόντου, διαφάνεια, απόσταση χαρακτήρων, ιδιότητες γραμματοσειράς, περιστροφή, διάστημα παραγράφων, συμπεριφορά autofit, αγκύρωση κειμένου, σημεία διαστημάτων και ρυθμίσεις γλώσσας.

Εκτός εάν αναφέρεται διαφορετικά, τα παραδείγματα χρησιμοποιούν το [sample.pptx](sample.pptx). Το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα πλαίσιο κειμένου και η πρώτη παράγραφος του περιέχει το κείμενο που φαίνεται παρακάτω. Οι δείκτες διαφανειών και σχημάτων είναι μηδενικής βάσης. Τα παραδείγματα που επιλέγουν έντονες (bold) ενότητες χρησιμοποιούν αποτελεσματική μορφοποίηση, συμπεριλαμβανομένης της κληρονομημένης έντονης μορφοποίησης:

![Sample text](sample_text.png)

Για να βρείτε και να επισημάνετε κυριολεκτικό κείμενο ή ταιριάσματα κανονικής έκφρασης, δείτε [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/androidjava/search-and-replace-text/).

## **Ορισμός Χρώματος Φόντου Κειμένου**

Χρησιμοποιήστε [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης για μια παράγραφο, ή χρησιμοποιήστε [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) για μεμονωμένες ενότητες κειμένου.

Το παρακάτω παράδειγμα ορίζει ελαφρύ γκρι χρώμα επισήμανσης ως προεπιλογή για την πρώτη παράγραφο. Τα ρητά χρώματα επισήμανσης σε μεμονωμένες ενότητες υπερισχύουν αυτής της προεπιλογής:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ορίστε το χρώμα επισήμανσης για ολόκληρη την παράγραφο.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The gray paragraph](gray_paragraph.png)

Το παρακάτω παράδειγμα κώδικα παρουσιάζει πώς να ορίσετε το χρώμα φόντου για **ενότητες κειμένου με έντονη γραμματοσειρά**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Ορίστε το χρώμα επισήμανσης για την ενότητα κειμένου.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The gray text portions](gray_text_portions.png)

## **Στοίχιση Παραγράφων Κειμένου**

Χρησιμοποιήστε [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) για να ορίσετε την στοίχιση παραγράφου εντός ενός πλαισίου κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερή, δεξιά, με στοίχιση σε στήλες (justified) κλπ.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να στοιχίσετε την παράγραφο στο **κέντρο**:

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

![The aligned paragraph](aligned_paragraph.png)

## **Ορισμός Διαφάνειας για Κείμενο**

Η διαφάνεια του κειμένου ελέγχεται μέσω του συνιστώσας άλφα του χρώματος που έχει οριστεί στο [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Στα παραδείγματα παρακάτω, `alpha = 50` είναι τιμή καναλιού άλφα ARGB στην κλίμακα 0–255, όχι ποσοστό διαφάνειας.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **ολόκληρη την παράγραφο**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

![The transparent paragraph](transparent_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **ενότητες κειμένου με έντονη γραμματοσειρά**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Ορίστε τη διαφάνεια της ενότητας κειμένου.
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

![The transparent text portions](transparent_text_portions.png)

## **Ορισμός Απόστασης Χαρακτήρων για Κείμενο**

Χρησιμοποιήστε [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) για να αυξήσετε ή να μειώσετε την απόσταση μεταξύ χαρακτήρων σε ένα πλαίσιο κειμένου. Τα παραδείγματα προσθέτουν 3 σημεία απόστασης· οι αρνητικές τιμές μειώνουν το κείμενο.

Ο ακόλουθος κώδικας Java δείχνει πώς να αυξήσετε την απόσταση χαρακτήρων στην **ολόκληρη την παράγραφο**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε την απόσταση χαρακτήρων.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Επεκτείνετε την απόσταση χαρακτήρων.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να αυξήσετε την απόσταση χαρακτήρων σε **ενότητες κειμένου με έντονη γραμματοσειρά**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε την απόσταση χαρακτήρων.
            portion.getPortionFormat().setSpacing(3); // Επεκτείνετε την απόσταση χαρακτήρων.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Απενεργοποίηση Kerning για Συγκεκριμένες Γραμματοσείρες**

Σε ορισμένες περιπτώσεις, το κείμενο που αποδίδεται από το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο πυκνό από το ίδιο κείμενο στο PowerPoint. Αυτό μπορεί να συμβεί επειδή το PowerPoint μπορεί να αγνοήσει τα δεδομένα kerning για ορισμένες γραμματοσειρές, ακόμα και όταν η γραμματοσειρά περιέχει έγκυρες πληροφορίες kerning και το kerning είναι ενεργό στις ρυθμίσεις του PowerPoint.

Για να φέρετε το αποτέλεσμα πιο κοντά στο PowerPoint, μπορείτε να απενεργοποιήσετε το kerning για ενότητες κειμένου που χρησιμοποιούν τη συγκεκριμένη γραμματοσειρά. Ορίστε [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) σε τιμή μεγαλύτερη από το πραγματικό μέγεθος γραμματοσειράς. Αυτό το παράδειγμα απαιτεί το "presentation.pptx" με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια. Ελέγχει τα αποτελεσματικά ονόματα γραμματοσειράς, συμπεριλαμβανομένων των κληρονομημένων, και θέτει κατώφλι 100 σημείων για ενότητες που χρησιμοποιούν Roboto. Αυτό απενεργοποιεί το kerning για τις αντίστοιχες ενότητες με μέγεθος γραμματοσειράς κάτω από 100 σημεία:

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

Για κείμενο που ταιριάζει κάτω από το κατώφλι, αυτή η ρύθμιση αποτρέπει το kerning και μπορεί να βοηθήσει το rendering του Aspose.Slides να ταιριάζει με το οπτικό αποτέλεσμα του PowerPoint για γραμματοσείρες που επηρεάζονται από αυτή τη συμπεριφορά του PowerPoint.

## **Διαχείριση Ιδιοτήτων Γραμματοσειράς Κειμένου**

Οι ιδιότητες γραμματοσειράς μπορούν να οριστούν στο επίπεδο παραγράφου μέσω [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) ή σε μεμονωμένες ενότητες μέσω [IPortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportionformat/).

Το παρακάτω παράδειγμα ορίζει την προεπιλεγμένη γραμματοσειρά της πρώτης παραγράφου σε Times New Roman 12 σημείο με έντονη, πλάγια και υπογράμμιση με κουκίδες. Η ρητή μορφοποίηση σε μεμονωμένες ενότητες υπερισχύει αυτών των προεπιλογών:

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

![The font properties for the paragraph](font_properties_for_paragraph.png)

Το παρακάτω παράδειγμα εφαρμόζει Times New Roman 13 σημείο, πλάγια μορφοποίηση και υπογράμμιση με κουκίδες σε ενότητες των οποίων η αποτελεσματική μορφοποίηση είναι έντονη:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Ορίστε τις ιδιότητες γραμματοσειράς για την ενότητα κειμένου.
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

![The font properties for text portions](font_properties_for_text_portions.png)

## **Ορισμός Περιστροφής Κειμένου**

Χρησιμοποιήστε [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) για να ορίσετε προεπιλεγμένη προσανατολισμό κειμένου μέσα σε σχήμα.

Το παρακάτω παράδειγμα κώδικα ορίζει τον προσανατολισμό κειμένου στο σχήμα σε [TextVerticalType.Vertical270](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textverticaltype/), που περιστρέφει το κείμενο **90 μοίρες αριστερά**:

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

![The text rotation](text_rotation.png)

## **Ορισμός Προσαρμοσμένης Περιστροφής για Πλαίσια Κειμένου**

Χρησιμοποιήστε [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) για να ορίσετε προσαρμοσμένη γωνία περιστροφής για ένα [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/).

Ο παρακάτω κώδικας περιστρέφει το πλαίσιο κειμένου κατά 3 μοίρες δεξιόστροφα μέσα στο σχήμα:

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

![The custom text rotation](custom_text_rotation.png)

## **Ορισμός Διάστιχου Παραγράφων**

Το Aspose.Slides παρέχει [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) και [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) για τον έλεγχο του διαστήματος παραγράφων. Αυτές οι ιδιότητες χρησιμοποιούνται ως εξής:

* Χρησιμοποιήστε θετική τιμή για να ορίσετε το διάστιχο ως ποσοστό του ύψους γραμμής.
* Χρησιμοποιήστε αρνητική τιμή για να ορίσετε το διάστιχο σε σημεία.

Το παρακάτω παράδειγμα ορίζει το διάστιχο εντός της πρώτης παραγράφου στο 200 % του ύψους γραμμής (διπλό διάστιχο):

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

![The line spacing within the paragraph](line_spacing.png)

## **Έλεγχος Διακοπής Γραμμής**

Οι κανόνες διακοπής γραμμής παραγράφων είναι χρήσιμοι σε στενά μπλοκ κειμένου και παρουσιάσεις που συνδυάζουν λατινικό και ασιατικό κείμενο. Οι ακόλουθες μέθοδοι ανήκουν στο [IParagraphFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/), επομένως εφαρμόζονται σε ολόκληρη την παράγραφο:

- [setLatinLineBreak](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) ελέγχει τους κανόνες διακοπής για λατινικό κείμενο. Σε μεικτό κείμενο, η αλλαγή του μπορεί επίσης να αλλάξει το σημείο όπου το γειτονικό ασιατικό κείμενο και η στίξη σβήνουν.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) ελέγχει τους κανόνες διακοπής για ασιατικό κείμενο, συμπεριλαμβανομένων των περιορισμών χαρακτήρων στην αρχή και το τέλος μιας γραμμής.

Αυτοί οι κανόνες δεν αντικαθιστούν το [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-), το οποίο ενεργοποιεί την αυτόματη αναδίπλωση εντός ενός πλαισίου κειμένου. Επηρεάζουν τη διάταξη όταν γίνεται αναδίπλωση· δεν εισάγουν χαρακτήρες αλλαγής γραμμής. Μια ρητή αλλαγή γραμμής αναγκάζει νέα γραμμή μέσα στην παράγραφο ανεξάρτητα από το διαθέσιμο πλάτος.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα στενό μπλοκ κειμένου που περιέχει κινέζικο και λατινικό κείμενο. Ορίζει και τις δύο επιλογές διακοπής γραμμής ρητά και αποθηκεύει το «line_breaking.pptx». Για να πειραματιστείτε με κάθε κανόνα, αλλάξτε την αντίστοιχη τιμή διατηρώντας τις άλλες ρυθμίσεις αμετάβλητες. Το παράδειγμα χρησιμοποιεί Arial 24 σημείο και SimSun με πλάτος πλαισίου 160 σημείο και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου. Το [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) καλείται με [TextAutofitType.None](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textautofittype/) ώστε το μέγεθος κειμένου και οι διαστάσεις πλαισίου να παραμείνουν σταθερά.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Έλεγχος Κρεμαστών Στίγματων**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) επιτρέπει σε επιλέξιμη στίγμα να εκτείνεται πέρα από το δεξιό άκρο της γραμμής αντί να καταλαμβάνει την επόμενη γραμμή. Εφαρμόζεται σε ολόκληρη την παράγραφο και διαφέρει από το κρεμαστό εσοχή.

Το παρακάτω αυτόνομο παράδειγμα ενεργοποιεί κρεμαστά στίγματα σε πλαίσιο κειμένου πλάτους 100 σημείο και αποθηκεύει το «hanging_punctuation.pptx». Με Arial 24 σημείο και μηδενικά οριζόντια περιθώρια, η τελική τελεία παραμένει μετά τη λέξη «sentence» και εκτείνεται πέρα από το δεξιό άκρο του κειμένου. Ορίστε την ιδιότητα σε [NullableBool.False](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/nullablebool/) για σύγκριση: με αυτές τις ρυθμίσεις, η τελεία καταλαμβάνει ξεχωριστή γραμμή. Η αναδίπλωση είναι ενεργή και το autofit είναι απενεργοποιημένο για να διατηρηθεί το διαθέσιμο πλάτος σταθερό.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Δεν μπορεί να κρεμαστεί κάθε στίγμα. Το ορατό αποτέλεσμα εξαρτάται από τη διαθεσιμότητα της γραμματοσειράς και τη διάταξη: η αλλαγή της γραμματοσειράς, του διαθέσιμου πλάτους, των περιθωρίων ή των ρυθμίσεων autofit μπορεί να αφαιρέσει τη διακριτή διαφορά.

## **Ορισμός Τύπου Autofit για Πλαίσια Κειμένου**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) καθορίζει πώς συμπεριφέρεται το κείμενο όταν ξεπερνά τα όρια του περιέκτη του. Χρησιμοποιήστε το για να ελέγξετε αν το κείμενο μειώνεται, υπερχειλίζεται ή το σχήμα προσαρμόζεται αυτόματα. Το παρακάτω παράδειγμα διαμορφώνει το σχήμα ώστε να αλλάζει μέγεθος για να χωρά το κείμενό του και αποθηκεύει το αποτέλεσμα σε «autofit_type.pptx».

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

Για να μετρήσετε τις γραμμές μετά την αυτόματη αναδίπλωση και να δείτε πώς η αλλαγή του πλάτους κειμένου ή σχήματος επηρεάζει το αποτέλεσμα, δείτε [Count Rendered Lines](/slides/el/androidjava/manage-paragraph/). Ο μόνος ο αριθμός γραμμών δεν υποδεικνύει αν το κείμενο υπερχειλίζει το περιέκτη του.

## **Ορισμός Άγκυρας Πλαισίων Κειμένου**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) ορίζει πώς τοποθετείται το κείμενο κάθετα μέσα σε σχήμα, π.χ. στην κορυφή, στο κέντρο ή στο κάτω μέρος. Το παρακάτω παράδειγμα αγκυροβολεί το κείμενο στο κάτω μέρος του πρώτου σχήματος και αποθηκεύει το αποτέλεσμα σε «text_anchor.pptx».

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

## **Ορισμός Στηλοθεσίας Κειμένου**

Χρησιμοποιήστε [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) και [IParagraphFormat.getTabs](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) για να ρυθμίσετε σημεία διαστήματος (tab stops) σε μια παράγραφο. Το παρακάτω παράδειγμα θέτει το προεπιλεγμένο διάστημα tab στα 100 σημεία και προσθέτει αριστερά στολισμένο tab στα 30 σημεία. Αυτές οι ρυθμίσεις επηρεάζουν κείμενο που περιέχει χαρακτήρες tab.

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

![The paragraph tabs](paragraph_tabs.png)

## **Ορισμός Γλώσσας Ελέγχου**

Το Aspose.Slides παρέχει [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), το οποίο επιτρέπει τον ορισμό της γλώσσας ελέγχου για μια ενότητα κειμένου. Η γλώσσα ελέγχου καθορίζει τη γλώσσα που χρησιμοποιείται για ορθογραφικό και γραμματικό έλεγχο στο PowerPoint.

Το παρακάτω παράδειγμα απαιτεί το «presentation.pptx» με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον μία παράγραφο. Αντικαθιστά το περιεχόμενο της πρώτης παραγράφου με «1。», θέτει το SimSun ως γραμματοσειρά της και αντιστοιχίζει τη γλώσσα ελέγχου απλούκινγκ (**Simplified Chinese**) (`zh-CN`). Αποθηκεύει το αποτέλεσμα σε «proofing_language.pptx»:

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

    // Ορίστε το Id της γλώσσας ελέγχου.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Χρησιμοποιήστε [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) για να ορίσετε την προεπιλεγμένη γλώσσα για κείμενο που δημιουργείται κατά τη φόρτωση ή δημιουργία παρουσίασης. Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με τις ΗΠΑ Αγγλικά ως προεπιλεγμένη γλώσσα κειμένου, προσθέτει ένα πλαίσιο κειμένου και εκτυπώνει `en-US` για την πρώτη ενότητα κειμένου.

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

    // Ελέγξτε τη γλώσσα της πρώτης ενότητας.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Ορισμός Προεπιλεγμένου Στυλ Κειμένου**

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου σε επίπεδο παρουσίασης, χρησιμοποιήστε [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Το παρακάτω παράδειγμα ορίζει γραμματοσειρά 14 σημείο, έντονη, ως προεπιλογή για παραγράφους κορυφαίου επιπέδου σε νέα παρουσίαση και αποθηκεύει το αρχείο σε «default_text_style.pptx». Το κείμενο μπορεί να κληρονομήσει αυτές τις προεπιλογές εκτός εάν πιο συγκεκριμένη μορφοποίηση τις παρακάμπτει.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Λάβετε τη μορφοποίηση παραγράφου κορυφαίου επιπέδου.
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

Στο PowerPoint, η εφαρμογή του εφέ **All Caps** σε γραμματοσειρά κάνει το κείμενο να εμφανίζεται σε κεφαλαία στην διαφάνεια ακόμη και όταν αρχικά είχε πληκτρολογηθεί με πεζά. Όταν ανακτάτε μια τέτοια ενότητα κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως εισήχθη. Για να ταιριάξετε το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textcaptype/) και μετατρέψτε το επιστρεφόμενο string σε κεφαλαία όταν η τιμή είναι `All`.

Το παράδειγμα απαιτεί το «sample2.pptx» με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια. Η πρώτη παράγραφος της πρώτης ενότητας περιέχει το «Hello, Aspose!» με το εφέ All Caps εφαρμόσμένο, όπως φαίνεται παρακάτω.

![The All Caps effect](all_caps_effect.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε το κείμενο με το εφέ **All Caps** εφαρμοσμένο:

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

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Πώς τροποποιώ το κείμενο σε έναν πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε το κείμενο σε έναν πίνακα σε μια διαφάνεια, χρησιμοποιήστε [ITable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itable/). Διασχίστε τα κελιά και ενημερώστε κάθε κελί μέσω του [ICell.getTextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icell/#getTextFrame--) και μορφοποίησης παραγράφων μέσω του [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Πώς εφαρμόζω ένα διαβαθμισμένο χρώμα σε κείμενο σε μια διαφάνεια PowerPoint;**

Για να εφαρμόσετε διαβαθμισμένο χρώμα σε κείμενο, χρησιμοποιήστε [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Ορίστε το [IFillFormat.setFillType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) σε [FillType.Gradient](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/filltype/) και ρυθμίστε τα σημεία διαβάθμισης, την κατεύθυνση και τη διαφάνεια.