---
title: Präsentation über VBA
type: docs
weight: 250
url: /de/androidjava/presentation-via-vba/
keywords: "Makro, Makros, VBA, VBA-Makro, Makro hinzufügen, Makro entfernen, VBA hinzufügen, VBA entfernen, Makro extrahieren, VBA extrahieren, PowerPoint-Makro, PowerPoint-Präsentation, Java, Aspose.Slides für Android über Java"
description: "Fügen Sie VBA-Makros in PowerPoint-Präsentationen in Java hinzu, entfernen Sie sie und extrahieren Sie sie."
---

{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie eine Präsentation, die Makros enthält, in ein anderes Dateiformat (PDF, HTML usw.) konvertieren, ignoriert Aspose.Slides alle Makros (Makros werden nicht in die resultierende Datei übertragen).

Wenn Sie Makros zu einer Präsentation hinzufügen oder eine Präsentation mit Makros erneut speichern, schreibt Aspose.Slides einfach die Bytes für die Makros.

Aspose.Slides **führt niemals** die Makros in einer Präsentation aus.

{{% /alert %}}

## **VBA-Makros hinzufügen**

Aspose.Slides bietet die [VbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/vbaproject/) Klasse, um Ihnen die Erstellung von VBA-Projekten (und Projektverweisen) zu ermöglichen und bestehende Module zu bearbeiten. Sie können die [IVbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivbaproject/) Schnittstelle verwenden, um VBA, das in einer Präsentation eingebettet ist, zu verwalten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse.
1. Verwenden Sie den [VbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/vbaproject/#VbaProject--) Konstruktor, um ein neues VBA-Projekt hinzuzufügen.
1. Fügen Sie dem VbaProject ein Modul hinzu.
1. Setzen Sie den Quellcode des Moduls.
1. Fügen Sie Verweise auf <stdole> hinzu.
1. Fügen Sie Verweise auf **Microsoft Office** hinzu.
1. Verknüpfen Sie die Verweise mit dem VBA-Projekt.
1. Speichern Sie die Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie ein VBA-Makro von Grund auf zu einer Präsentation hinzufügen:

```java
// Erstellt eine Instanz der Präsentationsklasse
Presentation pres = new Presentation();
try {
    // Erstellt ein neues VBA-Projekt
    pres.setVbaProject(new VbaProject());
    
    // Fügt ein leeres Modul zum VBA-Projekt hinzu
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Modul");
    
    // Setzt den Quellcode des Moduls
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // Erstellt einen Verweis auf <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Erstellt einen Verweis auf Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Objektbibliothek");
    
    // Fügt Verweise zum VBA-Projekt hinzu
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Speichert die Präsentation
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Sie möchten vielleicht **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros) ausprobieren, eine kostenlose Webanwendung zum Entfernen von Makros aus PowerPoint-, Excel- und Word-Dokumenten. 

{{% /alert %}} 

## **VBA-Makros entfernen**

Mit der [VbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getVbaProject--) Eigenschaft der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse können Sie ein VBA-Makro entfernen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse und laden Sie die Präsentation, die das Makro enthält.
1. Greifen Sie auf das Makro-Modul zu und entfernen Sie es.
1. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie ein VBA-Makro entfernen:

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

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse und laden Sie die Präsentation, die das Makro enthält.
2. Überprüfen Sie, ob die Präsentation ein VBA-Projekt enthält.
3. Durchlaufen Sie alle Module, die im VBA-Projekt enthalten sind, um die Makros anzuzeigen.

Dieser Java-Code zeigt Ihnen, wie Sie VBA-Makros aus einer Präsentation mit Makros extrahieren:

```java
// Lädt die Präsentation, die das Makro enthält
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Überprüft, ob die Präsentation ein VBA-Projekt enthält
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