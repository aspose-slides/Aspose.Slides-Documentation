---
title: Μακροεντολή VBA
type: docs
weight: 150
url: /el/androidjava/examples/elements/vba-macro/
keywords:
- παράδειγμα κώδικα
- VBA
- μακροεντολή
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Αυτοματοποιήστε τις παρουσιάσεις με το Aspose.Slides για Android: δημιουργήστε, εκτελέστε, εισάγετε και εξασφαλίστε μακροεντολές VBA σε PPT, PPTX και ODP χρησιμοποιώντας σαφή παραδείγματα Java."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε, να έχετε πρόσβαση και να αφαιρέσετε μακροεντολές VBA χρησιμοποιώντας **Aspose.Slides for Android via Java**.

## **Προσθήκη μιας μακροεντολής VBA**

Δημιουργήστε μια παρουσίαση με ένα έργο VBA και μια απλή μονάδα μακροεντολής.

```java
static void addVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε μια μακροεντολή VBA**

Ανακτήστε την πρώτη μονάδα από το έργο VBA.

```java
static void accessVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        IVbaModule firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση μιας μακροεντολής VBA**

Διαγράψτε μια μονάδα από το έργο VBA.

```java
static void removeVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.getVbaProject().getModules().remove(module);
    } finally {
        presentation.dispose();
    }
}
```