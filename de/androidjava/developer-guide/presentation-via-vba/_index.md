---
title: "Verwalten von VBA-Projekten in Präsentationen auf Android"
linktitle: "Präsentation via VBA"
type: docs
weight: 250
url: /de/androidjava/presentation-via-vba/
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
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen über VBA mit Aspose.Slides für Android über Java erstellen und manipulieren, um Ihren Arbeitsablauf zu optimieren."
---

{{% alert title="Note" color="warning" %}} 

Wenn Sie eine Präsentation, die Makros enthält, in ein anderes Dateiformat (PDF, HTML usw.) konvertieren, ignoriert Aspose.Slides alle Makros (Makros werden nicht in die resultierende Datei übernommen).

Wenn Sie einer Präsentation Makros hinzufügen oder eine Präsentation, die Makros enthält, erneut speichern, schreibt Aspose.Slides einfach die Bytes für die Makros.

Aspose.Slides **führt die Makros in einer Präsentation niemals aus**.

{{% /alert %}}

## **VBA-Makros hinzufügen**

Aspose.Slides stellt die [VbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/vbaproject/)‑Klasse zur Verfügung, um VBA‑Projekte (und Projektverweise) zu erstellen und vorhandene Module zu bearbeiten. Sie können das [IVbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivbaproject/)‑Interface verwenden, um VBA in einer Präsentation zu verwalten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)‑Klasse.  
2. Verwenden Sie den [VbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/vbaproject/#VbaProject--)‑Konstruktor, um ein neues VBA‑Projekt hinzuzufügen.  
3. Fügen Sie dem VbaProject ein Modul hinzu.  
4. Legen Sie den Quellcode des Moduls fest.  
5. Fügen Sie Verweise zu <stdole> hinzu.  
6. Fügen Sie Verweise zu **Microsoft Office** hinzu.  
7. Verknüpfen Sie die Verweise mit dem VBA‑Projekt.  
8. Speichern Sie die Präsentation.

Dieser Java‑Code zeigt, wie man von Grund auf ein VBA‑Makro zu einer Präsentation hinzufügt:
```java
// Erstellt eine Instanz der Präsentationsklasse
Presentation pres = new Presentation();
try {
    // Erstellt ein neues VBA-Projekt
    pres.setVbaProject(new VbaProject());
    
    // Fügt ein leeres Modul zum VBA-Projekt hinzu
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Setzt den Quellcode des Moduls
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // Erstellt einen Verweis auf <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Erstellt einen Verweis auf Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // Fügt dem VBA-Projekt Verweise hinzu
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Speichert die Präsentation
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 

Vielleicht möchten Sie den **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros) ausprobieren, eine kostenlose Web‑App zum Entfernen von Makros aus PowerPoint‑, Excel‑ und Word‑Dokumenten. 

{{% /alert %}} 

## **VBA-Makros entfernen**

Über die [VbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getVbaProject--)‑Eigenschaft der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)‑Klasse können Sie ein VBA‑Makro entfernen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)‑Klasse und laden Sie die Präsentation, die das Makro enthält.  
2. Greifen Sie auf das Makro‑Modul zu und entfernen Sie es.  
3. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt, wie man ein VBA‑Makro entfernt:
```java
// Lädt die Präsentation, die das Makro enthält
Presentation pres = new Presentation("VBA.pptm");
try {
    // Greift auf das VBA-Modul zu und entfernt es 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Speichert die Präsentation
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```


## **VBA-Makros extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)‑Klasse und laden Sie die Präsentation, die das Makro enthält.  
2. Überprüfen Sie, ob die Präsentation ein VBA‑Projekt enthält.  
3. Durchlaufen Sie alle im VBA‑Projekt enthaltenen Module, um die Makros anzuzeigen.

Dieser Java‑Code zeigt, wie man VBA‑Makros aus einer Präsentation, die Makros enthält, extrahiert:
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


## **Überprüfen, ob ein VBA‑Projekt kennwortgeschützt ist**

Mit der Methode [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--) können Sie feststellen, ob die Eigenschaften eines Projekts kennwortgeschützt sind.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse und laden Sie eine Präsentation, die ein Makro enthält.  
2. Prüfen Sie, ob die Präsentation ein [VBA project](https://reference.aspose.com/slides/androidjava/com.aspose.slides/vbaproject/) enthält.  
3. Überprüfen Sie, ob das VBA‑Projekt kennwortgeschützt ist, um seine Eigenschaften anzuzeigen.  
```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Überprüfen, ob die Präsentation ein VBA-Projekt enthält.
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

Makros werden entfernt, da PPTX kein VBA unterstützt. Um Makros beizubehalten, wählen Sie PPTM, PPSM oder POTM.

**Kann Aspose.Slides Makros in einer Präsentation ausführen, z. B. zum Aktualisieren von Daten?**

Nein. Die Bibliothek führt niemals VBA‑Code aus; die Ausführung ist nur in PowerPoint mit entsprechenden Sicherheitseinstellungen möglich.

**Werden ActiveX‑Steuerelemente, die mit VBA‑Code verknüpft sind, unterstützt?**

Ja, Sie können vorhandene [ActiveX controls](/slides/de/androidjava/activex/) ansprechen, deren Eigenschaften ändern und sie entfernen. Das ist nützlich, wenn Makros mit ActiveX interagieren.