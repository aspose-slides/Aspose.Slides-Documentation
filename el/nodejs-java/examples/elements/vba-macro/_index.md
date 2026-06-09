---
title: Μακροεντολή VBA
type: docs
weight: 150
url: /el/nodejs-java/examples/elements/vba-macro/
keywords:
- παράδειγμα κώδικα
- VBA
- μακροεντολή
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Αυτοματοποιήστε τις παρουσιάσεις με το Aspose.Slides για Node.js μέσω Java: δημιουργήστε, εισαγάγετε και προστατέψτε μακροεντολές VBA σε PPT, PPTX και ODP χρησιμοποιώντας σαφή παραδείγματα JavaScript."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε, να έχετε πρόσβαση και να καταργήσετε μακροεντολές VBA χρησιμοποιώντας **Aspose.Slides for Node.js via Java**.

## **Προσθήκη μακροεντολής VBA**

Δημιουργήστε μια παρουσίαση με ένα έργο VBA και μια απλή μονάδα μακροεντολής.

```js
function addVbaMacro() {
    let presentation = new aspose.slides.Presentation();
    try {
        presentation.setVbaProject(new aspose.slides.VbaProject());

        let module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.save("vba_macro.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε μακροεντολή VBA**

Ανακτήστε την πρώτη μονάδα από το έργο VBA.

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Υποθέτοντας ότι η παρουσίαση περιέχει τουλάχιστον μία μονάδα VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Κατάργηση μακροεντολής VBA**

Διαγράψτε μια μονάδα από το έργο VBA.

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Υποθέτοντας ότι η παρουσίαση περιέχει τουλάχιστον μία μονάδα VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```