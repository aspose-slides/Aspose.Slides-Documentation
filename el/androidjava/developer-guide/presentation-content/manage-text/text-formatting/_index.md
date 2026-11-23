---
title: Διαμόρφωση Κειμένου Παρουσίασης σε Android
linktitle: Μορφοποίηση Κειμένου
type: docs
weight: 50
url: /el/androidjava/text-formatting/
keywords:
- ευθυγράμμιση παραγράφου
- στυλ κειμένου
- φόντο κειμένου
- διαφάνεια κειμένου
- απόσταση χαρακτήρων
- ιδιότητες γραμματοσειράς
- οικογένεια γραμματοσειράς
- πριστροφή κειμένου
- γωνία περιστροφής
- πλαίσιο κειμένου
- διάστημα γραμμής
- ιδιότητα autofit
- αγκύρωση πλαισίου κειμένου
- καθορισμός στηλών κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαμορφώστε και εφαρμόστε στυλ σε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Android μέσω Java. Προσαρμόστε γραμματοσειρές, χρώματα, στοίχιση και περισσότερα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Android μέσω Java. Καλύπτεται το χρώμα φόντου, η διαφάνεια, η απόσταση χαρακτήρων, οι ιδιότητες γραμματοσειράς, η περιστροφή, η απόσταση παραγράφων, η συμπεριφορά autofit, η αγκύρωση κειμένου, τα σημεία στήλης και οι ρυθμίσεις γλώσσας.

Κατά προεξοχήν, τα παραδείγματα χρησιμοποιούν το [sample.pptx](sample.pptx). Το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα πλαίσιο κειμένου, και η πρώτη παράγραφος του περιέχει το κείμενο που φαίνεται παρακάτω. Οι δείκτες διαφάνειας και σχήματος είναι μηδενική βάση. Παραδείγματα που επιλέγουν έντονα τμήματα χρησιμοποιούν αποτελεσματική μορφοποίηση, συμπεριλαμβανομένης της κληρονομημένης έντονης μορφοποίησης:

![Sample text](sample_text.png)

Για εύρεση και επισήμανση κυριολεκτικού κειμένου ή αντιστοιχίσεων κανονικής έκφρασης, δείτε το [Search and Replace Text](/slides/el/androidjava/search-and-replace-text/).

## **Ορισμός Χρώματος Φόντου Κειμένου**

Χρησιμοποιήστε το [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης για μια παράγραφο, ή το [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) για μεμονωμένα τμήματα κειμένου.

Το παρακάτω παράδειγμα ορίζει ένα ανοιχτό γκρι ως προεπιλεγμένη επισήμανση για την πρώτη παράγραφο. Οι ρητές χρωματικές επισήμανσεις σε μεμονωμένα τμήματα έχουν προτεραιότητα έναντι της προεπιλογής:

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

Ο κώδικας παρακάτω δείχνει πώς να ορίσετε το χρώμα φόντου για **τμήματα κειμένου με έντονη γραμματοσειρά**:

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

![The gray text portions](gray_text_portions.png)

## **Στοίχιση Παραγράφων Κειμένου**

Χρησιμοποιήστε το [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) για να ορίσετε την στοίχιση παραγράφου μέσα σε ένα πλαίσιο κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερή, δεξιά, διάσπαρτη κ.ά.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να στοιχίσετε την παράγραφο στο **κέντρο**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ορίστε την ευθυγράμμιση της παραγράφου στο κέντρο.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The aligned paragraph](aligned_paragraph.png)

## **Στοίχιση Γραμματοσειρών Μέσα σε Γραμμή**

Χρησιμοποιήστε το [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) για κάθετη στοίχιση τμημάτων κειμένου διαφορετικών μεγεθών γραμματοσειράς μέσα σε μια γραμμή. Αυτή η ρύθμιση ισχύει για ολόκληρη την παράγραφο και ελέγχει τη στοίχιση σε κάθε γραμμή της.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί τέσσερα ετικετοποιημένα πλαίσια κειμένου σε μία διαφάνεια. Κάθε παράγραφος περιέχει το ίδιο κείμενο σε 18, 36 και 54 σημεία, με διαφορετική στοίχιση γραμματοσειράς. Χρησιμοποιεί Arial, απενεργοποιεί το autofit και την αναδίπλωση, και κρατά τα πλαίσια κειμένου αρκετά μεγάλα για μία γραμμή.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] alignments = { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
    String[] alignmentNames = { "Baseline", "Top", "Center", "Bottom" };
    float[] fontSizes = { 18f, 36f, 54f };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);

        IParagraph label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        for (float fontSize : fontSizes) {
            Portion portion = new Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Comparison of Baseline, Top, Center, and Bottom font alignment with mixed font sizes](font_alignment.png)

Η στοίχιση γραμματοσειράς χρησιμοποιεί μετρικές γραμματοσειράς, οπότε οι ορατές άκρες των ατομικών γραμμάτων δεν ευθυγραμμίζονται απαραίτητα ακριβώς. Το παράδειγμα περιλαμβάνει και ένα κεφαλαίο γράμμα και έναν καθοδικό χαρακτήρα για να επιδειχθεί η διαφορά μεταξύ βασικής γραμμής και κάτω στοίχισης. Διαθεσιμότητα γραμματοσειράς και αντικατάσταση, οι χαρακτήρες που χρησιμοποιούνται και η διαφορά στα μεγέθη γραμματοσειράς επηρεάζουν το αποτέλεσμα. Διαστάσεις πλαισίου, περιθώρια, απόσταση γραμμής, αναδίπλωση και autofit επίσης επηρεάζουν τη διάταξη· χρησιμοποιήστε τις ίδιες γραμματοσειρές και ρυθμίσεις διάταξης όταν συγκρίνετε λειτουργίες.

Αυτή η ρύθμιση διαφέρει από το [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-), που ελέγχει την οριζόντια στοίχιση παραγράφου, και το [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-), που τοποθετεί το μπλοκ κειμένου κάθετα μέσα στο σχήμα του. Η υπερ- και υπο-στρογγυλοποίηση μέσω του [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) μετατοπίζει μεμονωμένα τμήματα σχετικά με τη βασική γραμμή αντί να ορίζει τη στοίχιση γραμματοσειράς για τις γραμμές της παραγράφου.

## **Ορισμός Διαφάνειας για Κείμενο**

Η διαφάνεια κειμένου ελέγχεται μέσω του αλφα-συστατικού του χρώματος που αποδίδεται στο [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Στα παραδείγματα παρακάτω, `alpha = 50` είναι τιμή καναλιού ARGB στη κλίμακα 0–255, όχι ποσοστό διαφάνειας.

Ο κώδικας παρακάτω δείχνει πώς να εφαρμόσετε διαφάνεια σε **ολόκληρη την παράγραφο**:

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

Το επόμενο παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

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

![The transparent text portions](transparent_text_portions.png)

## **Ορισμός Απόστασης Χαρακτήρων για Κείμενο**

Χρησιμοποιήστε το [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) για να αυξήσετε ή να μειώσετε την απόσταση μεταξύ χαρακτήρων σε ένα πλαίσιο κειμένου. Τα παραδείγματα προσθέτουν 3 σημεία απόστασης· αρνητικές τιμές συμπιέζουν το κείμενο.

Ο παρακάτω κώδικας Java δείχνει πώς να αυξήσετε την απόσταση χαρακτήρων στο **ολόκληρο το κείμενο**:

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

Ο κώδικας παρακάτω δείχνει πώς να αυξήσετε την απόσταση χαρακτήρων σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

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

### **Απενεργοποίηση Kerning για Συγκεκριμένες Γραμματοσειρές**

Σε ορισμένες περιπτώσεις, το κείμενο που αποδίδει το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο σφιχτό από το ίδιο κείμενο στην PowerPoint. Αυτό μπορεί να συμβαίνει επειδή η PowerPoint αγνοεί τα δεδομένα kerning για ορισμένες γραμματοσειρές, ακόμη και όταν η γραμματοσειρά περιέχει έγκυρα δεδομένα kerning και το kerning είναι ενεργό στις ρυθμίσεις της PowerPoint.

Για να φέρετε το αποτέλεσμα πιο κοντά στην PowerPoint, μπορείτε να απενεργοποιήσετε το kerning για τμήματα κειμένου που χρησιμοποιούν τη συγκεκριμένη γραμματοσειρά. Ορίστε το [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) σε τιμή μεγαλύτερη από το πραγματικό μέγεθος της γραμματοσειράς. Το παράδειγμα απαιτεί το «presentation.pptx» με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια. Ελέγχει τα αποτελεσματικά ονόματα γραμματοσειρών, συμπεριλαμβανομένων των κληρονομημένων, και θέτει ένα κατώφλι 100 σημείων για τμήματα που χρησιμοποιούν το Roboto. Με αυτόν τον τρόπο απενεργοποιείται το kerning για τμήματα με μέγεθος γραμματοσειράς κάτω από 100 σημεία:

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

Για κείμενο που βρίσκεται κάτω από το όριο, αυτή η ρύθμιση αποτρέπει το kerning και μπορεί να βοηθήσει να ευθυγραμμιστεί η απόδοση του Aspose.Slides με το οπτικό αποτέλεσμα της PowerPoint για γραμματοσειρές που επηρεάζονται από αυτή τη συμπεριφορά της PowerPoint.

## **Διαχείριση Ιδιοτήτων Γραμματοσειράς Κειμένου**

Οι ιδιότητες γραμματοσειράς μπορούν να οριστούν σε επίπεδο παραγράφου μέσω του [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) ή σε μεμονωμένα τμήματα μέσω του [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/).

Το παρακάτω παράδειγμα ορίζει τη προεπιλεγμένη γραμματοσειρά της πρώτης παραγράφου σε Times New Roman 12 σημεία με έντονη, πλάγια και διακεκομμένη υπογράμμιση. Η ρητή μορφοποίηση σε μεμονωμένα τμήματα υπερισχύει των προεπιλογών.

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

Το επόμενο παράδειγμα εφαρμόζει Times New Roman 13 σημεία, πλάγια μορφοποίηση και διακεκομμένη υπογράμμιση στα τμήματα των οποίων η αποτελεσματική μορφοποίηση είναι έντονη:

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

![The font properties for text portions](font_properties_for_text_portions.png)

## **Έλεγχος Κανονικοποίησης Ύψους Κειμένου**

Χρησιμοποιήστε το [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) όταν αναπαράγετε τυπογραφία προτύπου ή ερευνάτε διαφορές στο ύψος χαρακτήρων. Στην PowerPoint, η ενεργοποίηση της κανονικοποίησης τεντώνει ή συμπιέζει κάθε χαρακτήρα κάθετα ώστε να έχει ομοιόμορφο ορατό ύψος μέσα στο τμήμα κειμένου. Δεν εγγυάται ίσο ύψος κειμένου μεταξύ διαφορετικών γραμματοσειρών.

Ορίστε την ιδιότητα σε [NullableBool.True ή False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) για να ενεργοποιήσετε ή να απενεργοποιήσετε ρητά την κανονικοποίηση. `NullableBool.NotDefined` αφήνει την τοπική ρύθμιση ακαθόριστη ώστε το τμήμα να κληρονομήσει την τιμή, π.χ. από το [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) της παραγράφου. Δεν σημαίνει `False`. Χρησιμοποιήστε το [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) και διαβάστε το [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) για την επιλυμένη Boolean τιμή.

Το παρακάτω αυτότονο παράδειγμα απαιτεί την εγκατάσταση του **Arial**. Δημιουργεί δύο μπλοκ κειμένου που περιέχουν τα ίδια κεφαλαία γράμματα, πεζά, καθοδικούς χαρακτήρες και τόνους στα 54 σημεία. Και οι δύο παράγραφοι ενεργοποιούν την κανονικοποίηση εξ ορισμού. Το πάνω τμήμα την απενεργοποιεί ρητά· το κάτω τμήμα την κληρονομεί. Τα μεγέθη πλαισίου, τα περιθώρια και η απόσταση παραγράφων είναι τα ίδια, με απενεργοποιημένη την αναδίπλωση και το autofit για να διατηρηθεί η σύγκριση συνεπής. Το παράδειγμα εμφανίζει `False: false` και `NotDefined: true`, στη συνέχεια αποθηκεύει το «text_height_normalization.pptx».

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.False, NullableBool.NotDefined };
    String[] settingNames = { "False", "NotDefined" };

    for (int i = 0; i < settings.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True);

        IPortion portion = paragraph.getPortions().get_Item(0);
        FontData font = new FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        portion.getPortionFormat().setNormaliseHeight(settings[i]);

        System.out.println(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η σύγκριση παρακάτω εξήχθη από την αποθηκευμένη παρουσίαση. Η κορυφαία σειρά έχει την κανονικοποίηση απενεργοποιημένη (`False`); η κάτω σειρά κληρονομεί την ενεργοποιημένη ρύθμιση (`NotDefined` → `True`). Διατηρήστε το Arial εγκατεστημένο για να επαναλάβετε αυτήν την εμφάνιση.

![Arial 54-point text with normalization disabled above and inherited normalization enabled below](text_height_normalization.png)

Η κανονικοποίηση αλλάζει το ύψος των χαρακτήρων χωρίς να αλλάζει την τιμή [getFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) που καθορίζει το μέγεθος γραμματοσειράς σε σημεία. Η μέθοδος [setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) της παραγράφου ελέγχει την απόσταση γραμμής, ενώ το [setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) του πλαισίου κειμένου ελέγχει πώς το κείμενο ή το περιέκτη του προσαρμόζεται για να χωρέσει. Αυτές οι ρυθμίσεις εξυπηρετούν διαφορετικούς σκοπούς και μπορούν ανεξάρτητα να επηρεάσουν τη συνολική διάταξη. Για περισσότερα σχετικά με τη μορφοποίηση παραγράφου και κληρονόμηση, δείτε το [Manage Paragraph](/slides/el/androidjava/manage-paragraph/).

## **Εφαρμογή και Κατάργηση Υπογράμμισης**

Χρησιμοποιήστε το [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) σε τμήμα κειμένου για να εμφανίσετε διορθώσεις, ακυρωμένους όρους ή προηγούμενες τιμές χωρίς διαγραφή του αρχικού κειμένου. Ορίστε το σε [TextStrikethroughType.Single ή Double](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/) για μία ή δύο γραμμές διαμέσου του κειμένου.

Για κατάργηση της υπογράμμισης, περάστε το [TextStrikethroughType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#None). Αυτό απενεργοποιεί ρητά το εφέ, ακόμη και αν η περιβάλλουσα μορφοποίηση το καθορίζει. Αντίθετα, το [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#NotDefined) αφήνει την τοπική ρύθμιση ακαθόριστη, επιτρέποντας στο τμήμα να κληρονομήσει τη μορφοποίηση, π.χ. από την παράγραφο. Δεν εγγυάται ότι η υπογράμμιση θα αφαιρεθεί. Χρησιμοποιήστε το [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) για να διαβάσετε τη φύση της τελικής μορφοποίησης, συμπεριλαμβανομένων των κληρονομημένων τιμών.

Το παρακάτω αυτότονο παράδειγμα δημιουργεί τρεις συγκρίσεις τιμών. Κάθε παράγραφος έχει ξεχωριστά τμήματα για την ετικέτα, την προηγούμενη τιμή και την τρέχουσα τιμή, ώστε μόνο η προηγούμενη τιμή να επηρεάζεται. Η πρώτη σειρά εφαρμόζει και στη συνέχεια αφαιρεί την υπογράμμιση· οι άλλες σειρές διατηρούν τη μονή ή τη διπλή υπογράμμιση. Η αλλαγή αυτής της ρύθμισης διατηρεί το κείμενο και τις άλλες μορφοποιήσεις του, συμπεριλαμβανομένης της έντονης προηγούμενης τιμής.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    String[] labels = { "None: ", "Single: ", "Double: " };

    for (String label : labels) {
        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        FontData font = new FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion labelPortion = new Portion(label);
        paragraph.getPortions().add(labelPortion);

        Portion previousPrice = new Portion("$100");
        previousPrice.getPortionFormat().setFontBold(NullableBool.True);
        paragraph.getPortions().add(previousPrice);
        Portion currentPrice = new Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    IParagraphCollection paragraphs = shape.getTextFrame().getParagraphs();

    // Εφαρμόστε διαγραμμάτωση, στη συνέχεια αφαιρέστε την ρητά από την πρώτη προηγούμενη τιμή.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα, από πάνω προς τα κάτω: χωρίς υπογράμμιση, με μονή υπογράμμιση, και με διπλή υπογράμμιση.

![Previous prices without strikethrough, with single strikethrough, and with double strikethrough](strikethrough.png)

## **Ορισμός Περιστροφής Κειμένου**

Χρησιμοποιήστε το [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) για να ορίσετε μια προεπιλεγμένη προσανατολισμό κειμένου μέσα σε σχήμα.

Το παρακάτω παράδειγμα κώδικα ορίζει τον προσανατολισμό κειμένου στο σχήμα σε [TextVerticalType.Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/), που περιστρέφει το κείμενο **90 μοίρες αριστερόστροφα**:

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

## **Προβολή Ψηφίων Δίπλα-Δίπλα σε Κατακόρυφο Κείμενο**

Για να κρατήσετε έναν διψήφιο αριθμό ενωμένο σε μια κατακόρυφη ιαπωνική ετικέτα, τοποθετήστε και τα δύο ψηφία σε ένα τμήμα κειμένου και καλέστε το [IBasePortionFormat.setKumimoji](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKumimoji-byte-) στο τμήμα αυτό. Το παράδειγμα χρησιμοποιεί το [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/#EastAsianVertical) και γραμματοσειρά 40‑σημεία MS Gothic για και τις δύο ετικέτες. Η τιμή [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) που περνιέται στο αριθμητικό τμήμα διαφέρει.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.True, NullableBool.False };
    float x = 120;

    for (byte kumimoji : settings) {
        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical);

        IParagraph paragraph = frame.getParagraphs().get_Item(0);
        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        FontData font = new FontData("MS Gothic");
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion digits = new Portion("12");
        digits.getPortionFormat().setKumimoji(kumimoji);

        paragraph.getPortions().clear();
        paragraph.getPortions().add(new Portion("令和"));
        paragraph.getPortions().add(digits);
        paragraph.getPortions().add(new Portion("年"));

        x += 240;
    }
    presentation.save("vertical_date.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Στην PowerPoint, η αριστερή ετικέτα (`True`) εμφανίζει τα ψηφία κάθετα και δίπλα-δίπλα μεταξύ των χαρακτήρων 和 και 年. Η δεξιά ετικέτα (`False`) περιστρέφει το ζευγάρι κατά 90 μοίρες δεξιόστροφα. Οι γύρω ιαπωνικοί χαρακτήρες παραμένουν κάθετοι και στις δύο ετικέτες.

![PowerPoint comparison of vertical date labels with upright digits on the left and rotated digits on the right.](vertical_date.png)

## **Ορισμός Προσαρμοσμένης Περιστροφής Πλαισίων Κειμένου**

Χρησιμοποιήστε το [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) για να ορίσετε γωνία προσαρμοσμένης περιστροφής σε ένα [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).

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

![The custom text rotation](custom_text_rotation.png)

## **Ορισμός Απόστασης Γραμμής Παραγράφων**

Το Aspose.Slides παρέχει τα [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) και [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) για τον έλεγχο της απόστασης παραγράφου. Τα χαρακτηριστικά αυτά χρησιμοποιούνται ως εξής:

* Χρησιμοποιήστε θετική τιμή για να ορίσετε την απόσταση γραμμής ως ποσοστό του ύψους της γραμμής.
* Χρησιμοποιήστε αρνητική τιμή για να ορίσετε την απόσταση γραμμής σε σημεία.

Το παρακάτω παράδειγμα ορίζει την εντός‑παράγραφου απόσταση στο 200 % του ύψους γραμμής (διπλή διάσταση):

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

## **Έλεγχος Σπάσματος Γραμμής**

Οι κανόνες σπάσματος γραμμής παραγράφου είναι χρήσιμοι σε στενά τμήματα κειμένου και παρουσιάσεις που συνδυάζουν λατινικό και ασιατικό κείμενο. Οι ακόλουθες μέθοδοι ανήκουν στο [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/), επομένως ισχύουν για ολόκληρη την παράγραφο:

- το [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) ελέγχει τους κανόνες σπάσματος για λατινικό κείμενο. Σε μικτό κείμενο, η αλλαγή του μπορεί επίσης να επηρεάσει το σημείο αναδίπλωσης γειτονικού ασιατικού κειμένου και σημείας στίξης.
- το [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) ελέγχει τους κανόνες σπάσματος για ασιατικό κείμενο, συμπεριλαμβανομένων των περιορισμών σε χαρακτήρες στην αρχή και το τέλος μιας γραμμής.

Αυτοί οι κανόνες δεν αντικαθιστούν το [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-), που ενεργοποιεί την αυτόματη αναδίπλωση μέσα σε πλαίσιο κειμένου. Επηρεάζουν τη διάταξη όταν συμβαίνει η αναδίπλωση· δεν εισάγουν χαρακτήρες newline. Ένα ρητό newline αναγκάζει τη δημιουργία νέας γραμμής στην παράγραφο ανεξάρτητα από το διαθέσιμο πλάτος.

Το παρακάτω αυτότονο παράδειγμα δημιουργεί ένα στενό τμήμα κειμένου που περιέχει κινέζικο και λατινικό κείμενο. Ορίζει ρητά και τις δύο επιλογές σπάσματος και αποθηκεύει το «line_breaking.pptx». Για να πειραματιστείτε με κάποιον από τους κανόνες, αλλάξτε την αντίστοιχη τιμή διατηρώντας τις άλλες αμετάβλητες. Το παράδειγμα χρησιμοποιεί Arial 24 σημεία και SimSun με πλάτος πλαισίου 160 σημεία και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου. Το [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) καλείται με [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/) ώστε το μέγεθος κειμένου και οι διαστάσεις πλαισίου να παραμείνουν σταθερά.

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

## **Έλεγχος Hanging Punctuation**

Η μέθοδος [IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) επιτρέπει σε επιλέξιμη στίξη να εκτείνεται πέρα από το δεξιό άκρο της γραμμής κειμένου αντί να καταλαμβάνει την επόμενη γραμμή. Ισχύει για ολόκληρη την παράγραφο και διαφέρει από ένα «hanging indent».

Το παρακάτω αυτότονο παράδειγμα ενεργοποιεί hanging punctuation σε πλαίσιο κειμένου 100 σημείων πλάτος και αποθηκεύει το «hanging_punctuation.pptx». Με Arial 24 σημεία και μηδενικά οριζόντια περιθώρια, η τελική τελεία παραμένει μετά τη λέξη «sentence» και εκτείνεται πέρα από το δεξιό άκρο. Ορίστε την ιδιότητα σε [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) για σύγκριση: με αυτή τη ρύθμιση η τελεία καταλαμβάνει ξεχωριστή γραμμή. Η αναδίπλωση είναι ενεργή και το autofit απενεργοποιημένο για να διατηρηθεί το διαθέσιμο πλάτος αμετάβλητο.

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

Δεν μπορεί να κρεμαστεί κάθε σημάδι στίξης. Οι [συνθήκες γραμματοσειράς και διάταξης που περιγράφησαν παραπάνω](#control-line-breaking) ισχύουν επίσης για αυτή τη σύγκριση: η αλλαγή γραμματοσειράς, διαθέσιμου πλάτους, περιθωρίων ή ρυθμίσεων autofit μπορεί να αφαιρέσει τη ορατή διαφορά.

## **Ορισμός Τύπου Autofit για Πλαίσια Κειμένου**

Η μέθοδος [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) καθορίζει πώς συμπεριφέρεται το κείμενο όταν υπερβαίνει τα όρια του δοχείου του. Χρησιμοποιήστε την για να ελέγξετε εάν το κείμενο θα μειωθεί, θα υπερχεί ή το σχήμα θα προσαρμοστεί αυτόματα. Το παρακάτω παράδειγμα διαμορφώνει το σχήμα ώστε να προσαρμόζεται ώστε να χωρά το κείμενο και αποθηκεύει το αποτέλεσμα στο «autofit_type.pptx».

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

Για να μετρήσετε τις γραμμές μετά την αυτόματη αναδίπλωση και να δείτε πώς η αλλαγή του πλάτους κειμένου ή σχήματος επηρεάζει το αποτέλεσμα, δείτε το [Count Rendered Lines](/slides/el/androidjava/manage-paragraph/). Ο αριθμός γραμμών μόνο δεν δείχνει αν το κείμενο υπερβαίνει το δοχείο του.

## **Ορισμός Άγκυρας Πλαισίων Κειμένου**

Η μέθοδος [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) ορίζει πώς το κείμενο τοποθετείται κατακόρυφα μέσα σε σχήμα, π.χ. στο πάνω, στη μέση ή στο κάτω μέρος. Το παρακάτω παράδειγμα αγκυροβολεί το κείμενο στο κάτω μέρος του πρώτου σχήματος και αποθηκεύει το αποτέλεσμα στο «text_anchor.pptx».

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

## **Ορισμός Ταμπλώ Κειμένου**

Χρησιμοποιήστε το [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) και το [IParagraphFormat.getTabs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) για να ρυθμίσετε σημεία στήλης σε μια παράγραφο. Το παρακάτω παράδειγμα ορίζει το προεπιλεγμένο διάστημα στήλης σε 100 σημεία και προσθέτει μια αριστερά‑στοιχισμένη στήλη στο 30 σημεία. Αυτές οι ρυθμίσεις επηρεάζουν κείμενο που περιέχει χαρακτήρες στήλης.

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

## **Ορισμός Γλώσσας Διόρθωσης**

Το Aspose.Slides παρέχει το [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) το οποίο σας επιτρέπει να ορίσετε τη γλώσσα διόρθωσης για ένα τμήμα κειμένου. Η γλώσσα διόρθωσης καθορίζει τη γλώσσα που θα χρησιμοποιηθεί για τον ορθογραφικό και γραμματικό έλεγχο στην PowerPoint.

Το επόμενο παράδειγμα απαιτεί το «presentation.pptx» με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον μία παράγραφο. Αντικαθιστά το περιεχόμενο της πρώτης παραγράφου με «1。», ορίζει το SimSun ως γραμματοσειρά της και ορίζει τη γλώσσα διόρθωσης Απλουστευμένων Κινέζων (`zh-CN`). Αποθηκεύει το αποτέλεσμα στο «proofing_language.pptx»:

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

### **Αντιγραφή Μεταδεδομένων Γλώσσας**

Κατά την αντιγραφή πολύγλωσσης κειμένου από πρότυπο, διατηρήστε τόσο το [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getLanguageId--) όσο και το [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--). Το παρακάτω αυτότονο παράδειγμα δημιουργεί ένα πηγαίο τμήμα με US English ως γλώσσα του και French ως εναλλακτική γλώσσα και αντιγράφει το κείμενο και τα αναγνωριστικά σε τμήμα σε μια νέα παρουσίαση.

```java
import com.aspose.slides.*;

Portion source = new Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion destination = new Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Αν η πηγή δεν έχει εναλλακτική γλώσσα, το null διαγράφει την τιμή προορισμού.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για να δοκιμάσετε μια πηγή χωρίς εναλλακτική γλώσσα, παραλείψτε την ανάθεση του `"fr-FR"`. Η εναλλακτική ταυτότητα τότε είναι `null`, και η ίδια εντολή αντιγραφής διατηρεί την απουσία της χωρίς να εισάγει προεπιλεγμένη τιμή, ακόμη και αν ο προορισμός είχε προηγουμένως εναλλακτική γλώσσα.

Αυτά τα αναγνωριστικά αποθηκεύουν μεταδεδομένα γλώσσας. Η διατήρησή τους δεν καθορίζει ποιο λεξικό θα επιλέξει η PowerPoint για ορθογραφικό ή γραμματικό έλεγχο.

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Χρησιμοποιήστε το [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) για να ορίσετε τη προεπιλεγμένη γλώσσα κειμένου κατά τη φόρτωση ή δημιουργία παρουσίασης. Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με US English ως προεπιλεγμένη γλώσσα κειμένου, προσθέτει ένα πλαίσιο κειμένου και εκτυπώνει `en-US` για το πρώτο τμήμα κειμένου.

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

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου σε επίπεδο παρουσίασης, χρησιμοποιήστε το [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Το παρακάτω παράδειγμα ορίζει γραμματοσειρά 14 σημεία, έντονη, ως προεπιλεγμένο στυλ για παραγράφους κορυφαίου επιπέδου σε νέα παρουσίαση και το αποθηκεύει στο «default_text_style.pptx». Το κείμενο μπορεί να κληρονομήσει αυτές τις προεπιλογές εκτός εάν πιο συγκεκριμένη μορφοποίηση τις παρακάμπτει.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Λάβετε τη μορφοποίηση της παραγράφου κορυφαίου επιπέδου.
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

## **Εξαγωγή Κειμένου με Το Εφέ All‑Caps**

Στην PowerPoint, η εφαρμογή του εφέ **All Caps** κάνει το κείμενο να εμφανίζεται με κεφαλαία γράμματα στην διαφάνεια ακόμη και όταν αρχικά πληκτρολογήθηκε με πεζά. Όταν ανακτάτε τέτοιο τμήμα κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως καταχωρήθηκε. Για να ταιριάξετε το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) και μετατρέψτε το επιστραφόμενο string σε κεφαλαία όταν η τιμή είναι `All`.

Αυτό το παράδειγμα απαιτεί το «sample2.pptx» με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια. Η πρώτη παράγραφος του πρώτου τμήματος περιέχει το «Hello, Aspose!» με εφαρμοσμένο το εφέ All Caps, όπως φαίνεται παρακάτω.

![The All Caps effect](all_caps_effect.png)

Ο κώδικας παρακάτω δείχνει πώς να εξάγετε το κείμενο με το εφέ **All Caps**:

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

Έξοδος:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Συχνές Ερωτήσεις**

**Πώς τροποποιώ κείμενο σε πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε κείμενο σε πίνακα σε μια διαφάνεια, χρησιμοποιήστε το [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). Διασχίστε τα κελιά και ενημερώστε το κάθε κελί μέσω του [ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) και τη μορφοποίηση παραγράφου μέσω του [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Πώς εφαρμόζω χρώμα διαβάθμισης σε κείμενο σε διαφάνεια PowerPoint;**

Για να εφαρμόσετε χρώμα διαβάθμισης σε κείμενο, χρησιμοποιήστε το [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Ορίστε το [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) σε [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) και διαμορφώστε τα σημεία διαβάθμισης, την κατεύθυνση και τη διαφάνεια.