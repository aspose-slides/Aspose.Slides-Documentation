---
title: Präsentation über VBA
type: docs
weight: 250
url: /de/net/presentation-via-vba/
keywords: "Makro, Makros, VBA, VBA-Makro, Makro hinzufügen, Makro entfernen, VBA hinzufügen, VBA entfernen, Makro extrahieren, VBA extrahieren, PowerPoint-Makro, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "VBA-Makros in PowerPoint-Präsentationen in C# oder .NET hinzufügen, entfernen und extrahieren"
---

Der [Aspose.Slides.Vba](https://reference.aspose.com/slides/net/aspose.slides.vba/) Namensraum enthält Klassen und Schnittstellen zur Arbeit mit Makros und VBA‑Code.

{{% alert title="Note" color="warning" %}} 

Wenn Sie eine Präsentation, die Makros enthält, in ein anderes Dateiformat (PDF, HTML usw.) konvertieren, ignoriert Aspose.Slides alle Makros (Makros werden nicht in die resultierende Datei übernommen).

Wenn Sie Makros zu einer Präsentation hinzufügen oder eine Präsentation, die Makros enthält, erneut speichern, schreibt Aspose.Slides einfach die Bytes für die Makros.

Aspose.Slides **never** führt die Makros in einer Präsentation aus.

{{% /alert %}}

## **VBA‑Makros hinzufügen**

Aspose.Slides stellt die [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/)‑Klasse zur Verfügung, mit der Sie VBA‑Projekte (und Projektverweise) erstellen und vorhandene Module bearbeiten können. Sie können das [IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/)‑Interface verwenden, um VBA, das in einer Präsentation eingebettet ist, zu verwalten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse.  
2. Verwenden Sie den [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/vbaproject/#constructor)‑Konstruktor, um ein neues VBA‑Projekt hinzuzufügen.  
3. Fügen Sie dem VbaProject ein Modul hinzu.  
4. Legen Sie den Quellcode des Moduls fest.  
5. Fügen Sie Verweise zu <stdole> hinzu.  
6. Fügen Sie Verweise zu **Microsoft Office** hinzu.  
7. Verknüpfen Sie die Verweise mit dem VBA‑Projekt.  
8. Speichern Sie die Präsentation.  

```c#
    // Erstellt eine Instanz der Präsentationsklasse
using (Presentation presentation = new Presentation())
{
    // Erstellt ein neues VBA-Projekt
    presentation.VbaProject = new VbaProject();

    // Fügt dem VBA-Projekt ein leeres Modul hinzu
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // Legt den Quellcode des Moduls fest
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Erstellt einen Verweis auf <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Erstellt einen Verweis auf Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Fügt Verweise zum VBA-Projekt hinzu
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // Speichert die Präsentation
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


{{% alert color="primary" %}} 

Vielleicht möchten Sie **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros) prüfen, eine kostenlose Web‑App zum Entfernen von Makros aus PowerPoint-, Excel‑ und Word‑Dokumenten. 

{{% /alert %}} 

## **VBA‑Makros entfernen**
Mit der [VbaProject](https://reference.aspose.com/slides/net/aspose.slides/presentation/vbaproject/)‑Eigenschaft der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse können Sie ein VBA‑Makro entfernen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse und laden Sie die Präsentation, die das Makro enthält.  
2. Greifen Sie auf das Makro‑Modul zu und entfernen Sie es.  
3. Speichern Sie die geänderte Präsentation.  

```c#
    // Lädt die Präsentation, die das Makro enthält
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Greift auf das Vba-Modul zu und entfernt es 
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Speichert die Präsentation
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


## **VBA‑Makros extrahieren**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse und laden Sie die Präsentation, die das Makro enthält.  
2. Prüfen Sie, ob die Präsentation ein VBA‑Projekt enthält.  
3. Durchlaufen Sie alle im VBA‑Projekt enthaltenen Module, um die Makros anzuzeigen.  

```c#
    // Lädt die Präsentation, die das Makro enthält
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Überprüft, ob die Präsentation ein VBA-Projekt enthält
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```


## **Prüfen, ob ein VBA‑Projekt passwortgeschützt ist**
Über die [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/ispasswordprotected/)‑Eigenschaft können Sie feststellen, ob die Eigenschaften eines Projekts passwortgeschützt sind.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse und laden Sie eine Präsentation, die ein Makro enthält.  
2. Prüfen Sie, ob die Präsentation ein [VBA project](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/) enthält.  
3. Prüfen Sie, ob das VBA‑Projekt passwortgeschützt ist, um seine Eigenschaften einzusehen.  

```cs
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Überprüft, ob die Präsentation ein VBA-Projekt enthält.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```


## **FAQ**

**Was passiert mit Makros, wenn ich die Präsentation als PPTX speichere?**  
Makros werden entfernt, da PPTX kein VBA unterstützt. Um Makros zu erhalten, wählen Sie PPTM, PPSM oder POTM.

**Kann Aspose.Slides Makros innerhalb einer Präsentation ausführen, um beispielsweise Daten zu aktualisieren?**  
Nein. Die Bibliothek führt niemals VBA‑Code aus; die Ausführung ist nur in PowerPoint mit den entsprechenden Sicherheitseinstellungen möglich.

**Wird die Arbeit mit ActiveX‑Steuerelementen, die an VBA‑Code gebunden sind, unterstützt?**  
Ja, Sie können vorhandene [ActiveX controls](/slides/de/net/activex/) ansprechen, deren Eigenschaften ändern und sie entfernen. Das ist nützlich, wenn Makros mit ActiveX interagieren.