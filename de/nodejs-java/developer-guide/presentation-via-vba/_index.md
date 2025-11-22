---
title: Präsentation über VBA
type: docs
weight: 250
url: /de/nodejs-java/presentation-via-vba/
keywords: "Makro, Makros, VBA, VBA-Makro, Makro hinzufügen, Makro entfernen, VBA hinzufügen, VBA entfernen, Makro extrahieren, VBA extrahieren, PowerPoint-Makro, PowerPoint-Präsentation, Java, Aspose.Slides für Node.js via Java"
description: "Hinzufügen, Entfernen und Extrahieren von VBA-Makros in PowerPoint-Präsentationen in JavaScript"
---

{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie eine Präsentation, die Makros enthält, in ein anderes Dateiformat (PDF, HTML usw.) konvertieren, ignoriert Aspose.Slides alle Makros (Makros werden nicht in die resultierende Datei übernommen).

Wenn Sie einer Präsentation Makros hinzufügen oder eine Präsentation, die Makros enthält, erneut speichern, schreibt Aspose.Slides einfach die Bytes für die Makros.

Aspose.Slides führt **nie** Makros in einer Präsentation aus.

{{% /alert %}}

## **VBA‑Makros hinzufügen**

Aspose.Slides stellt die Klasse [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/) bereit, um VBA‑Projekte (und Projektverweise) zu erstellen und vorhandene Module zu bearbeiten. Sie können die Klasse [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/) verwenden, um in einer Präsentation eingebettetes VBA zu verwalten.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Verwenden Sie den Konstruktor [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/#VbaProject--) , um ein neues VBA‑Projekt hinzuzufügen.
1. Fügen Sie dem VbaProject ein Modul hinzu.
1. Legen Sie den Quellcode des Moduls fest.
1. Fügen Sie Verweise zu <stdole> hinzu.
1. Fügen Sie Verweise zu **Microsoft Office** hinzu.
1. Verknüpfen Sie die Verweise mit dem VBA‑Projekt.
1. Speichern Sie die Präsentation.

Dieser JavaScript‑Code zeigt, wie Sie ein VBA‑Makro von Grund auf zu einer Präsentation hinzufügen:
```javascript
// Erstellt eine Instanz der Präsentationsklasse
let pres = new aspose.slides.Presentation();
try {
    // Erstellt ein neues VBA-Projekt
    pres.setVbaProject(new aspose.slides.VbaProject());
    // Fügt dem VBA-Projekt ein leeres Modul hinzu
    let module = pres.getVbaProject().getModules().addEmptyModule("Module");
    // Setzt den Quellcode des Moduls
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    // Erstellt eine Referenz zu <stdole>
    let stdoleReference = new aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    // Erstellt eine Referenz zu Office
    let officeReference = new aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    // Fügt dem VBA-Projekt Referenzen hinzu
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
    // Speichert die Präsentation
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 

Vielleicht möchten Sie den kostenlosen Web‑App **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros) ausprobieren, die zum Entfernen von Makros aus PowerPoint-, Excel‑ und Word‑Dokumenten verwendet wird. 

{{% /alert %}} 

## **VBA‑Makros entfernen**

Mit der Eigenschaft [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getVbaProject--) der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) können Sie ein VBA‑Makro entfernen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) und laden Sie die Präsentation, die das Makro enthält.
1. Greifen Sie auf das Makro‑Modul zu und entfernen Sie es.
1. Speichern Sie die geänderte Präsentation.

Dieser JavaScript‑Code zeigt, wie Sie ein VBA‑Makro entfernen:
```javascript
// Lädt die Präsentation, die das Makro enthält
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Greift auf das Vba-Modul zu und entfernt es
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    // Speichert die Präsentation
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **VBA‑Makros extrahieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) und laden Sie die Präsentation, die das Makro enthält.
2. Prüfen Sie, ob die Präsentation ein VBA‑Projekt enthält.
3. Durchlaufen Sie alle im VBA‑Projekt enthaltenen Module, um die Makros anzuzeigen.

Dieser JavaScript‑Code zeigt, wie Sie VBA‑Makros aus einer Präsentation mit Makros extrahieren:
```javascript
// Lädt die Präsentation, die das Makro enthält
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Prüft, ob die Präsentation ein VBA-Projekt enthält
    if (pres.getVbaProject() != null) {
        for (let i = 0; i < pres.getVbaProject().getModules().size(); i++) {
            let module = pres.getVbaProject().getModules().get_Item(i);
            console.log(module.getName());
            console.log(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Prüfen, ob ein VBA‑Projekt kennwortgeschützt ist**

Mit der Methode [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/#isPasswordProtected) können Sie feststellen, ob die Eigenschaften eines Projekts kennwortgeschützt sind.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) und laden Sie eine Präsentation, die ein Makro enthält.
2. Prüfen Sie, ob die Präsentation ein [VBA project](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/) enthält.
3. Prüfen Sie, ob das VBA‑Projekt kennwortgeschützt ist, um seine Eigenschaften anzuzeigen.
```js
let presentation = new aspose.slides.Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Überprüfen, ob die Präsentation ein VBA-Projekt enthält.
        if (presentation.getVbaProject().isPasswordProtected()) {
            console.log("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Was passiert mit Makros, wenn ich die Präsentation als PPTX speichere?**

Makros werden entfernt, weil PPTX kein VBA unterstützt. Um Makros zu behalten, wählen Sie PPTM, PPSM oder POTM.

**Kann Aspose.Slides Makros innerhalb einer Präsentation ausführen, um beispielsweise Daten zu aktualisieren?**

Nein. Die Bibliothek führt niemals VBA‑Code aus; die Ausführung ist nur innerhalb von PowerPoint mit den entsprechenden Sicherheitseinstellungen möglich.

**Wird die Arbeit mit ActiveX‑Steuerelementen, die mit VBA‑Code verknüpft sind, unterstützt?**

Ja, Sie können vorhandene [ActiveX controls](/slides/de/nodejs-java/activex/) zugreifen, deren Eigenschaften ändern und sie entfernen. Dies ist nützlich, wenn Makros mit ActiveX interagieren.