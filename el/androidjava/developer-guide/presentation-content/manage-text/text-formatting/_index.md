---
title: Μορφοποίηση κειμένου παρουσίασης σε Android
linktitle: Μορφοποίηση κειμένου
type: docs
weight: 50
url: /el/androidjava/text-formatting/
keywords:
- στοίχιση παραγράφου
- στυλ κειμένου
- υπόβαθρο κειμένου
- διαφάνεια κειμένου
- απόσταση χαρακτήρων
- ιδιότητες γραμματοσειράς
- οικογένεια γραμματοσειράς
- περιστροφή κειμένου
- γωνία περιστροφής
- πλαίσιο κειμένου
- απόσταση γραμμών
- ιδιότητα autofit
- άγκυρα πλαισίου κειμένου
- στηλοθέτηση κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μορφοποίηση και στυλιζάρισμα κειμένου σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Android μέσω Java. Προσαρμόστε γραμματοσειρές, χρώματα, στοίχιση και άλλα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε το κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Android μέσω Java. Καλύπτει χρώματα υποβάθρου, διαφάνεια, απόσταση χαρακτήρων, ιδιότητες γραμματοσειράς, περιστροφή, απόσταση παραγράφων, συμπεριφορά autofit, αγκύρωση κειμένου, διακοσμητές στηλοθέτη και ρυθμίσεις γλώσσας.

Εκτός αν αναφέρεται διαφορετικά, τα παραδείγματα χρησιμοποιούν το [sample.pptx](sample.pptx). Το πρώτο σχήμα στην πρώτη διαφάνειά του είναι ένα πλαίσιο κειμένου, και η πρώτη παράγραφος του περιέχει το κείμενο που φαίνεται παρακάτω. Και οι δείκτες διαφάνειας και σχήματος είναι μηδενικής βάσης. Παραδείγματα που επιλέγουν έντονα τμήματα χρησιμοποιούν αποτελεσματική μορφοποίηση, συμπεριλαμβανομένης της κληρονομημένης έντονης μορφοποίησης:

![Δείγμα κειμένου](sample_text.png)

Για να βρείτε και να επισημάνετε κυριολεκτικό κείμενο ή αντιστοιχίες κανονικής έκφρασης, δείτε [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/androidjava/search-and-replace-text/).

## **Ορισμός Χρώματος Υποβάθρου Κειμένου**

Χρησιμοποιήστε [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης για μια παράγραφο, ή χρησιμοποιήστε [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) για μεμονωμένα τμήματα κειμένου.

Το παρακάτω παράδειγμα ορίζει μια ανοιχτόγκρι επισήμανση ως προεπιλογή για την πρώτη παράγραφο. Τα ρητά χρώματα επισήμανσης στα μεμονωμένα τμήματα έχουν προτεραιότητα απέναντι σε αυτήν την προεπιλογή:

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

![Η γκρίζα παράγραφος](gray_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα υποβάθρου για **τμήματα κειμένου με έντονη γραμματοσειρά**:

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

![Τα γκρι τμήματα κειμένου](gray_text_portions.png)

## **Στοίχιση Παραγράφων Κειμένου**

Χρησιμοποιήστε [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) για να ορίσετε την ευθυγράμμιση παραγράφου μέσα σε ένα πλαίσιο κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερά, δεξιά, με στοίχιση πλήρους ευρυότητας κ.ά.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ευθυγραμμίσετε την παράγραφο στο **κέντρο**:

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

![Η ευθυγραμμισμένη παράγραφος](aligned_paragraph.png)

## **Στοίχιση Γραμματοσειρών Μέσα σε Μία Γραμμή**

Χρησιμοποιήστε [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) για να στοίχειτε κατακόρυφα τμήματα κειμένου διαφορετικών μεγεθών γραμματοσειράς μέσα σε μια γραμμή. Αυτή η ρύθμιση εφαρμόζεται σε ολόκληρη την παράγραφο και ελέγχει τη στοίχιση σε κάθε της γραμμή.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί τέσσερα ετικετοποιημένα πλαίσια κειμένου σε μια διαφάνεια. Κάθε παράγραφος περιέχει το ίδιο κείμενο σε 18, 36 και 54 σημεία, με διαφορετική στοίχιση γραμματοσειράς. Χρησιμοποιεί Arial, απενεργοποιεί το autofit και τη συσπείρωση, και διατηρεί τα πλαίσια κειμένου αρκετά μεγάλα για μία γραμμή.

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

![Σύγκριση Στοίχισης Baseline, Top, Center, Bottom με μικτά μεγέθη γραμματοσειράς](font_alignment.png)

Η στοίχιση γραμματοσειράς χρησιμοποιεί μετρικές γραμματοσειράς, έτσι ώστε οι ορατές άκρες των ατομικών χαρακτήρων να μην ευθυγραμμίζονται ακριβώς. Το παράδειγμα περιλαμβάνει τόσο ένα κεφαλαίο γράμμα όσο και ένα φθίνουσες χαρακτήρες για να δείξει τη διαφορά μεταξύ στοίχισης baseline και bottom. Η διαθεσιμότητα και η αντικατάσταση γραμματοσειρών, οι χαρακτήρες που χρησιμοποιούνται και η διαφορά στο μέγεθος των γραμματοσειρών επηρεάζουν το αποτέλεσμα. Διαστάσεις πλαισίου, περιθώρια, απόσταση γραμμής, συσπείρωση και autofit επηρεάζουν επίσης τη διάταξη· χρησιμοποιήστε τις ίδιες γραμματοσειρές και ρυθμίσεις διάταξης όταν συγκρίνετε τις λειτουργίες.

Αυτή η ρύθμιση διαφέρει από [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-), η οποία ελέγχει την οριζόντια στοίχιση παραγράφου, και από [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-), η οποία τοποθετεί το μπλοκ κειμένου κατακόρυφα μέσα στο σχήμα του. Η μορφοποίηση υπερ- και υπο-δείκτη μέσω [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) μετατοπίζει ατομικά τμήματα σχετικά με τη baseline αντί να ορίζει τη στοίχιση γραμματοσειράς για τις γραμμές της παραγράφου.

## **Ορισμός Διαφάνειας για Κείμενο**

Η διαφάνεια του κειμένου ελέγχεται μέσω του άλφα στοιχείου του χρώματος που έχει εκχωρηθεί σε [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Στα παρακάτω παραδείγματα, `alpha = 50` είναι μια τιμή καναλιού ARGB αλφα στην κλίμακα 0‑255, όχι ποσοστό διαφάνειας.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια στην **ολόκληρη την παράγραφο**:

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

![Η διαφανής παράγραφος](transparent_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

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

![Τα διαφανή τμήματα κειμένου](transparent_text_portions.png)

## **Ορισμός Απόστασης Χαρακτήρων για Κείμενο**

Χρησιμοποιήστε [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) για να αυξήσετε ή να μειώσετε την απόσταση μεταξύ χαρακτήρων σε ένα πλαίσιο κειμένου. Τα παραδείγματα προσθέτουν 3 σημεία απόσταση· αρνητικές τιμές μειώνουν την απόσταση.

Ο ακόλουθος κώδικας Java δείχνει πώς να αυξήσετε την απόσταση χαρακτήρων στην **ολόκληρη την παράγραφο**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για συμπίεση της απόστασης χαρακτήρων.
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
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για συμπίεση της απόστασης χαρακτήρων.
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

### **Απενεργοποίηση Kerning για Συγκεκριμένες Γραμματοσειρές**

Σε ορισμένες περιπτώσεις, το κείμενο που αποδίδει το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο πυκνό από το ίδιο κείμενο που εμφανίζεται στο PowerPoint. Αυτό μπορεί να συμβαίνει επειδή το PowerPoint μπορεί να αγνοεί τα δεδομένα kerning για ορισμένες γραμματοσειρές, ακόμη και όταν η γραμματοσειρά περιέχει έγκυρες πληροφορίες kerning και το kerning είναι ενεργοποιημένο στις ρυθμίσεις του PowerPoint.

Για να φέρετε την απόδοση πιο κοντά στο PowerPoint σε τέτοιες περιπτώσεις, μπορείτε να απενεργοποιήσετε το kerning για τμήματα κειμένου που χρησιμοποιούν τη γραμματοσειρά που επηρεάζεται. Ορίστε [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) σε τιμή μεγαλύτερη από το πραγματικό μέγεθος γραμματοσειράς. Αυτό το παράδειγμα απαιτεί το "presentation.pptx" με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια. Ελέγχει τα αποτελεσματικά ονόματα γραμματοσειρών, συμπεριλαμβανομένων των κληρονομημένων, και θέτει ένα όριο 100 σημείων για τμήματα που χρησιμοποιούν το Roboto. Αυτό απενεργοποιεί το kerning για τα τμήματα που έχουν μέγεθος γραμματοσειράς κάτω από 100 σημεία:

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

Για κείμενο που ταιριάζει κάτω από το όριο, αυτή η ρύθμιση αποτρέπει το kerning και μπορεί να βοηθήσει στο να ταιριάζει η απόδοση του Aspose.Slides με το οπτικό αποτέλεσμα του PowerPoint για τις γραμματοσειρές που επηρεάζονται από αυτήν τη συμπεριφορά ειδική του PowerPoint.

## **Διαχείριση Ιδιοτήτων Γραμματοσειράς Κειμένου**

Οι ιδιότητες γραμματοσειράς μπορούν να οριστούν στο επίπεδο παραγράφου μέσω [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) ή σε μεμονωμένα τμήματα μέσω [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/).

Το παρακάτω παράδειγμα ορίζει τη προεπιλεγμένη γραμματοσειρά της πρώτης παραγράφου σε Times New Roman 12 σημείων με έντονη, πλάγια και υπογραμμισμένη με τελείες μορφοποίηση. Η ρητή μορφοποίηση σε μεμονωμένα τμήματα έχει προτεραιότητα επί των προεπιλογών.

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

Το παρακάτω παράδειγμα εφαρμόζει Times New Roman 13 σημείων, πλάγια μορφοποίηση και υπογράμμιση με τελείες σε τμήματα των οποίων η αποτελεσματική μορφοποίηση είναι έντονη:

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

Χρησιμοποιήστε [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) για να ορίσετε μια προκαθορισμένη προσανατολισμό κειμένου μέσα σε ένα σχήμα.

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

![Η περιστροφή κειμένου](text_rotation.png)

## **Ορισμός Προσαρμοσμένης Περιστροφής για Πλαίσια Κειμένου**

Χρησιμοποιήστε [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) για να ορίσετε μια προσαρμοσμένη γωνία περιστροφής για ένα [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).

Το παρακάτω παράδειγμα κώδικα περιστρέφει το πλαίσιο κειμένου κατά 3 μοίρες δεξιόστροφα μέσα στο σχήμα:

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

## **Ορισμός Απόστασης Γραμμών για Παραγράφους**

Το Aspose.Slides παρέχει [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), και [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) για τον έλεγχο της απόστασης παραγράφων. Αυτές οι ιδιότητες χρησιμοποιούνται ως εξής:

* Χρησιμοποιήστε θετική τιμή για να ορίσετε την απόσταση γραμμής ως ποσοστό του ύψους γραμμής.
* Χρησιμοποιήστε αρνητική τιμή για να ορίσετε την απόσταση γραμμής σε σημεία.

Το παρακάτω παράδειγμα ορίζει την απόσταση εντός της πρώτης παραγράφου στο 200 % του ύψους γραμμής (διπλή απόσταση):

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

![Η απόσταση γραμμής μέσα στην παράγραφο](line_spacing.png)

## **Έλεγχος Σπασίματος Γραμμής**

Οι κανόνες σπασίματος γραμμής παραγράφου είναι χρήσιμοι σε στενούς οίκο κειμένου και παρουσιάσεις που συνδυάζουν Λατινικό και Ανατολικοασιατικό κείμενο. Οι παρακάτω μέθοδοι ανήκουν στο [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/), οπότε εφαρμόζονται σε ολόκληρη την παράγραφο:

- [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) ελέγχει τους κανόνες σπασίματος Λατινικού κειμένου. Σε μεικτό κείμενο, η αλλαγή του μπορεί επίσης να αλλάξει το σημείο όπου το διπλανό Ανατολικοασιατικό κείμενο και η στίξη θα περιτυλίγονται.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) ελέγχει τους κανόνες σπασίματος Ανατολικοασιατικού κειμένου, συμπεριλαμβανομένων των περιορισμών στους χαρακτήρες στην αρχή ή στο τέλος μιας γραμμής.

Αυτοί οι κανόνες δεν αντικαθιστούν το [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-), το οποίο ενεργοποιεί την αυτόματη περιτύλιξη μέσα σε ένα πλαίσιο κειμένου. Επηρεάζουν τη διάταξη όταν γίνεται η περιτύλιξη· δεν εισάγουν χαρακτήρες αλλαγής γραμμής. Μια ρητή αλλαγή γραμμής αναγκάζει νέα γραμμή μέσα στην παράγραφο ανεξάρτητα από το διαθέσιμο πλάτος.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα στενό μπλοκ κειμένου που περιέχει Κινέζικο και Λατινικό κείμενο. Ορίζει ρητά και τις δύο επιλογές σπασίματος και αποθηκεύει το «line_breaking.pptx». Για να πειραματιστείτε με κάποιον κανόνα, αλλάξτε την αντίστοιχη τιμή διατηρώντας τις άλλες ρυθμίσεις σταθερές. Το παράδειγμα χρησιμοποιεί Arial 24 σημείων και SimSun με πλάτος πλαισίου 160 σημείων και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου. Το [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) καλείται με [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/) ώστε το μέγεθος του κειμένου και οι διαστάσεις του πλαισίου να παραμείνουν σταθερές.

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

## **Έλεγχος Κρεμαστής Στίξης**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) επιτρέπει σε επιλέξιμη στίξη να εκτείνεται πέρα από τη δεξιά άκρη της γραμμής κειμένου αντί να καταλαμβάνει την επόμενη γραμμή. Εφαρμόζεται σε ολόκληρη την παράγραφο και διαφέρει από μια κρεμαστή εσοχή.

Το παρακάτω αυτόνομο παράδειγμα ενεργοποιεί την κρεμαστή στίξη σε πλαίσιο κειμένου πλάτους 100 σημεία και αποθηκεύει το «hanging_punctuation.pptx». Με Arial 24 σημεία και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου, το τελικό τελεία παραμένει μετά τη λέξη «sentence» και εκτείνεται πέρα από την άκρη του κειμένου. Ορίστε την ιδιότητα σε [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) για σύγκριση: με αυτές τις ρυθμίσεις, η τελεία καταλαμβάνει ξεχωριστή γραμμή. Η περιτύλιξη είναι ενεργοποιημένη και το autofit είναι απενεργοποιημένο για να παραμείνει το διαθέσιμο πλάτος σταθερό.

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

Δεν μπορεί να κρεμαστεί κάθε στίξη. Οι [συνθήκες γραμματοσειράς και διάταξης που περιγράφονται παραπάνω](#control-line-breaking) ισχύουν επίσης για αυτή τη σύγκριση: η αλλαγή της γραμματοσειράς, του διαθέσιμου πλάτους, των περιθωρίων ή των ρυθμίσεων autofit μπορεί να αφαιρέσει τη διακριτή διαφορά.

## **Ορισμός Τύπου Autofit για Πλαίσια Κειμένου**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) καθορίζει πώς συμπεριφέρεται το κείμενο όταν υπερβαίνει τα όρια του περιέκτη του. Χρησιμοποιήστε το για να ελέγξετε αν το κείμενο θα συρρικνωθεί, θα κατακλύσει ή θα αλλάξει μέγεθος του σχήματος αυτόματα. Το παρακάτω παράδειγμα ρυθμίζει το σχήμα ώστε να αλλάζει μέγεθος ώστε να ταιριάζει με το κείμενο και αποθηκεύει το αποτέλεσμα στο «autofit_type.pptx».

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

Για να μετρήσετε τις γραμμές μετά την αυτόματη περιτύλιξη και να δείτε πώς η αλλαγή του μεγέθους κειμένου ή σχήματος επηρεάζει το αποτέλεσμα, δείτε [Count Rendered Lines](/slides/el/androidjava/manage-paragraph/). Ο μόνος ο αριθμός γραμμών δεν υποδεικνύει αν το κείμενο υπερβαίνει το περιέκτη του.

## **Ορισμός Άγκυρας Πλαισίων Κειμένου**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) ορίζει πώς τοποθετείται το κείμενο κατακόρυφα μέσα σε ένα σχήμα, π.χ. στο επάνω, στο μέσο ή στο κάτω μέρος. Το παρακάτω παράδειγμα αγκυροβολεί το κείμενο στο κάτω μέρος του πρώτου σχήματος και αποθηκεύει το αποτέλεσμα στο «text_anchor.pptx».

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

## **Ορισμός Στηλοθετησης Κειμένου**

Χρησιμοποιήστε [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) και [IParagraphFormat.getTabs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) για να διαμορφώσετε διακοσμητές στηλοθέτη σε μια παράγραφο. Το παρακάτω παράδειγμα ορίζει το προεπιλεγμένο διάστημα στηλοθέτη σε 100 σημεία και προσθέτει έναν αριστερά στοιχισμένο διακοσμητή στηλοθέτη στα 30 σημεία. Αυτές οι ρυθμίσεις επηρεάζουν κείμενο που περιέχει χαρακτήρες στηλοθέτη.

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

![Οι στηλοθετήσεις της παραγράφου](paragraph_tabs.png)

## **Ορισμός Γλώσσας Ελέγχου**

Το Aspose.Slides παρέχει [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), που σας επιτρέπει να ορίσετε τη γλώσσα ελέγχου για ένα τμήμα κειμένου. Η γλώσσα ελέγχου καθορίζει τη γλώσσα που χρησιμοποιείται για ορθογραφικό και γραμματικό έλεγχο στο PowerPoint.

Το παρακάτω παράδειγμα απαιτεί το «presentation.pptx» με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον μία παράγραφο. Αντικαθιστά τα περιεχόμενα της πρώτης παραγράφου με «1。», ορίζει το SimSun ως γραμματοσειρά της και αντιστοιχεί τη γλώσσα ελέγχου απλοποιημένων Κινέζικων (`zh-CN`). Αποθηκεύει το αποτέλεσμα στο «proofing_language.pptx»:

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

    // Ορίστε το Id μιας γλώσσας ελέγχου.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Χρησιμοποιήστε [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) για να ορίσετε τη προεπιλεγμένη γλώσσα για κείμενο που δημιουργείται κατά τη φόρτωση ή τη δημιουργία μιας παρουσίασης. Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με Αμερικανική αγγλική ως προεπιλεγμένη γλώσσα κειμένου, προσθέτει ένα πλαίσιο κειμένου και εκτυπώνει `en-US` για το πρώτο τμήμα κειμένου.

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

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου σε επίπεδο παρουσίασης, χρησιμοποιήστε [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Το παρακάτω παράδειγμα ορίζει μια γραμματοσειρά 14 σημείων με έντονη μορφή ως προεπιλογή για τις παραγράφους πρώτου επιπέδου σε μια νέα παρουσίαση και το αποθηκεύει στο «default_text_style.pptx». Το κείμενο μπορεί να κληρονομήσει αυτές τις προεπιλογές εκτός εάν πιο συγκεκριμένη μορφοποίηση τις υπερχειρίζεται.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Πάρτε τη μορφοποίηση παραγράφου του πρώτου επιπέδου.
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

Στο PowerPoint, η εφαρμογή του **All Caps** εφέ γραμματοσειράς κάνει το κείμενο να εμφανίζεται με κεφαλαία γράμματα στη διαφάνεια ακόμη και αν αρχικά πληκτρολογήθηκε με πεζά. Όταν ανακτάτε ένα τέτοιο τμήμα κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως εισήχθη. Για να ταιριάξει το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) και μετατρέψτε την επιστρεφόμενη συμβολοσειρά σε κεφαλαία όταν η τιμή είναι `All`.

Το παράδειγμα απαιτεί το «sample2.pptx» με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια. Το πρώτο τμήμα της πρώτης παραγράφου του περιέχει το «Hello, Aspose!» με το εφέ All Caps εφαρμοσμένο, όπως φαίνεται παρακάτω.

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

Έξοδος:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να τροποποιήσω το κείμενο σε έναν πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε το κείμενο σε έναν πίνακα σε μια διαφάνεια, χρησιμοποιήστε [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). Επανάληψη μέσω των κελιών και ενημέρωση κάθε κελιού μέσω του [ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) και μορφοποίηση παραγράφων μέσω του [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Πώς μπορώ να εφαρμόσω διαβαθμισμένο χρώμα σε κείμενο σε μια διαφάνεια PowerPoint;**

Για να εφαρμόσετε διαβαθμισμένο χρώμα σε κείμενο, χρησιμοποιήστε [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Ορίστε το [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) σε [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) και διαμορφώστε τις διαβάσεις, την κατεύθυνση και τη διαφάνεια.