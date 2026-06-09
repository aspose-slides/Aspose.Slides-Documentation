---
title: ActiveX
type: docs
weight: 200
url: /el/androidjava/examples/elements/activex/
keywords:
- παράδειγμα κώδικα
- ActiveX
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Δείτε παραδείγματα ActiveX του Aspose.Slides for Android: εισαγωγή, διαμόρφωση και έλεγχο αντικειμένων ActiveX σε παρουσιάσεις PPT και PPTX με σαφή κώδικα Java."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε, να αποκτήσετε πρόσβαση, να αφαιρέσετε και να διαμορφώσετε ελέγχους ActiveX σε μια παρουσίαση χρησιμοποιώντας **Aspose.Slides for Android via Java**.

## **Προσθήκη ελέγχου ActiveX**

Εισάγετε έναν νέο έλεγχο ActiveX και προαιρετικά ορίστε τις ιδιότητές του.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Προσθήκη νέου ελέγχου ActiveX.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // Προαιρετικά ορισμός ορισμένων ιδιοτήτων.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε έλεγχο ActiveX**

Διαβάστε πληροφορίες από τον πρώτο έλεγχο ActiveX στη διαφάνεια.

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Πρόσβαση στον πρώτο έλεγχο ActiveX.
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση ελέγχου ActiveX**

Διαγράψτε έναν υπάρχοντα έλεγχο ActiveX από τη διαφάνεια.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Αφαίρεση του πρώτου ελέγχου ActiveX.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Ορισμός ιδιοτήτων ActiveX**

Προσθέστε ένα έλεγχο και διαμορφώστε αρκετές ιδιότητες ActiveX.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Προσθήκη ελέγχου Windows Media Player και διαμόρφωση ιδιοτήτων.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```