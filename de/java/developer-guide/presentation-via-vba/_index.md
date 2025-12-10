---
title: VBA-Projekte in Präsentationen mit Java verwalten
linktitle: Präsentation über VBA
type: docs
weight: 250
url: /de/java/presentation-via-vba/
keywords:
- Makro
- VBA
- VBA-Makro
- Makro hinzufügen
- Makro entfernen
- Makro extrahieren
- VBA hinzufügen
- VBA entfernen
- VBA extrahieren
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Entdecken Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen über VBA mit Aspose.Slides für Java generieren und bearbeiten, um Ihren Arbeitsablauf zu optimieren."
---

{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie eine Präsentation, die Makros enthält, in ein anderes Dateiformat (PDF, HTML usw.) konvertieren, ignoriert Aspose.Slides alle Makros (Makros werden nicht in die resultierende Datei übernommen).

Wenn Sie einer Präsentation Makros hinzufügen oder eine Präsentation, die Makros enthält, erneut speichern, schreibt Aspose.Slides einfach die Bytes für die Makros.

Aspose.Slides **führt Makros in einer Präsentation niemals aus**.

{{% /alert %}}

## **VBA-Makros hinzufügen**

Aspose.Slides stellt die Klasse [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/) zur Verfügung, um VBA‑Projekte (und Projektverweise) zu erstellen und vorhandene Module zu bearbeiten. Sie können das Interface [IVbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/ivbaproject/) verwenden, um VBA in einer Präsentation zu verwalten.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
2. Verwenden Sie den Konstruktor der [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/#VbaProject--) , um ein neues VBA‑Projekt hinzuzufügen.
3. Fügen Sie dem VbaProject ein Modul hinzu.
4. Setzen Sie den Quellcode des Moduls.
5. Fügen Sie Verweise zu <stdole> hinzu.
6. Fügen Sie Verweise zu **Microsoft Office** hinzu.
7. Verknüpfen Sie die Verweise mit dem VBA‑Projekt.
8. Speichern Sie die Präsentation.

```java
// Erstellt eine Instanz der Präsentationsklasse
Presentation pres = new Presentation();
try {
    // Erstellt ein neues VBA-Projekt
    pres.setVbaProject(new VbaProject());
    
    // Fügt dem VBA-Projekt ein leeres Modul hinzu
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Setzt den Quellcode des Moduls
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // Erstellt eine Referenz zu <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Erstellt eine Referenz zu Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // Fügt dem VBA-Projekt Referenzen hinzu
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Speichert die Präsentation
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 

Vielleicht möchten Sie den **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros) ausprobieren, eine kostenlose Web‑App zum Entfernen von Makros aus PowerPoint-, Excel‑ und Word‑Dokumenten. 

{{% /alert %}} 

## **VBA-Makros entfernen**

Durch die Verwendung der Eigenschaft [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getVbaProject--) unter der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) können Sie ein VBA‑Makro entfernen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)-Klasse und laden Sie die Präsentation, die das Makro enthält.
2. Greifen Sie auf das Makro‑Modul zu und entfernen Sie es.
3. Speichern Sie die geänderte Präsentation.

```java
// Lädt die Präsentation, die das Makro enthält
Presentation pres = new Presentation("VBA.pptm");
try {
    // Greift auf das Vba-Modul zu und entfernt es 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Speichert die Präsentation
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```


## **VBA-Makros extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)-Klasse und laden Sie die Präsentation, die das Makro enthält.
2. Prüfen Sie, ob die Präsentation ein VBA‑Projekt enthält.
3. Durchlaufen Sie alle im VBA‑Projekt enthaltenen Module, um die Makros anzuzeigen.

```java
// Lädt die Präsentation, die das Makro enthält
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Prüft, ob die Präsentation ein VBA-Projekt enthält
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Überprüfen, ob ein VBA‑Projekt passwortgeschützt ist**

Mit der Methode [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) können Sie feststellen, ob die Projekteigenschaften passwortgeschützt sind.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse und laden Sie eine Präsentation, die ein Makro enthält.
2. Prüfen Sie, ob die Präsentation ein [VBA project](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/) enthält.
3. Prüfen Sie, ob das VBA‑Projekt passwortgeschützt ist, um seine Eigenschaften anzuzeigen.

```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Prüfen, ob die Präsentation ein VBA-Projekt enthält.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Was passiert mit Makros, wenn ich die Präsentation als PPTX speichere?**

Makros werden entfernt, da PPTX VBA nicht unterstützt. Um Makros zu behalten, wählen Sie PPTM, PPSM oder POTM.

**Kann Aspose.Slides Makros in einer Präsentation ausführen, um beispielsweise Daten zu aktualisieren?**

Nein. Die Bibliothek führt niemals VBA‑Code aus; die Ausführung ist nur innerhalb von PowerPoint mit den entsprechenden Sicherheitseinstellungen möglich.

**Wird die Arbeit mit ActiveX‑Steuerelementen, die an VBA‑Code gebunden sind, unterstützt?**

Ja, Sie können vorhandene [ActiveX controls](/slides/de/java/activex/) zugreifen, ihre Eigenschaften ändern und sie entfernen. Das ist nützlich, wenn Makros mit ActiveX interagieren.