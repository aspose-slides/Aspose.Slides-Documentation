---
title: VBA-Projekte in Präsentationen in .NET verwalten
linktitle: Präsentation per VBA
type: docs
weight: 250
url: /de/net/presentation-via-vba/
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
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen über VBA mit Aspose.Slides für .NET erstellen und manipulieren, um Ihren Arbeitsablauf zu optimieren."
---
## **Einleitung**

Der [Aspose.Slides.Vba](https://reference.aspose.com/slides/de/net/aspose.slides.vba/) Namespace enthält Klassen und Schnittstellen für die Arbeit mit Makros und VBA-Code.

{{% alert title="Note" color="warning" %}} 

Wenn Sie eine Präsentation, die Makros enthält, in ein anderes Dateiformat (PDF, HTML usw.) konvertieren, ignoriert Aspose.Slides alle Makros (Makros werden nicht in die resultierende Datei übernommen).

Wenn Sie einer Präsentation Makros hinzufügen oder eine Präsentation, die Makros enthält, erneut speichern, schreibt Aspose.Slides lediglich die Bytes der Makros.

Aspose.Slides **niemals** führt die Makros in einer Präsentation aus.

{{% /alert %}}

## **VBA-Makros hinzufügen**

Aspose.Slides stellt die Klasse [VbaProject](https://reference.aspose.com/slides/de/net/aspose.slides.vba/vbaproject/) zur Verfügung, mit der Sie VBA‑Projekte (und Projektverweise) erstellen und vorhandene Module bearbeiten können. Sie können das Interface [IVbaProject](https://reference.aspose.com/slides/de/net/aspose.slides.vba/ivbaproject/) verwenden, um in einer Präsentation eingebettetes VBA zu verwalten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Klasse.  
1. Verwenden Sie den Konstruktor [VbaProject](https://reference.aspose.com/slides/de/net/aspose.slides.vba/vbaproject/vbaproject/#constructor), um ein neues VBA‑Projekt hinzuzufügen.  
1. Fügen Sie dem VbaProject ein Modul hinzu.  
1. Legen Sie den Quellcode des Moduls fest.  
1. Fügen Sie Verweise zu <stdole> hinzu.  
1. Fügen Sie Verweise zu **Microsoft Office** hinzu.  
1. Verknüpfen Sie die Verweise mit dem VBA‑Projekt.  
1. Speichern Sie die Präsentation.  

Dieser C#‑Code zeigt, wie Sie ein VBA‑Makro von Grund auf zu einer Präsentation hinzufügen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

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
    presentation.Save("AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="info" %}} 

Vielleicht möchten Sie sich **Aspose** [Macro Remover](https://products.aspose.app/slides/de/remove-macros) ansehen, eine kostenlose Web‑App, die zum Entfernen von Makros aus PowerPoint-, Excel- und Word‑Dokumenten verwendet wird. 

{{% /alert %}} 

## **VBA-Makros entfernen**
Mit der Eigenschaft [VbaProject](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/vbaproject/) der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) können Sie ein VBA‑Makro entfernen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Klasse und laden Sie die Präsentation, die das Makro enthält.  
1. Greifen Sie auf das Makro‑Modul zu und entfernen Sie es.  
1. Speichern Sie die geänderte Präsentation.  

Dieser C#‑Code zeigt, wie Sie ein VBA‑Makro entfernen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Lädt die Präsentation, die das Makro enthält
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    // Greift auf das Vba-Modul zu und entfernt es
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Speichert die Präsentation
    presentation.Save("RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **VBA-Makros extrahieren**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse und laden Sie die Präsentation, die das Makro enthält.  
2. Überprüfen Sie, ob die Präsentation ein VBA‑Projekt enthält.  
3. Durchlaufen Sie alle im VBA‑Projekt enthaltenen Module, um die Makros anzuzeigen.  

Dieser C#‑Code zeigt, wie Sie VBA‑Makros aus einer Präsentation, die Makros enthält, extrahieren:

```c#
using Aspose.Slides;
using Aspose.Slides.Vba;

    // Lädt die Präsentation, die das Makro enthält
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Prüft, ob die Präsentation ein VBA-Projekt enthält
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **Überprüfen, ob ein VBA‑Projekt passwortgeschützt ist**
Mit der Eigenschaft [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/de/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) können Sie feststellen, ob die Eigenschaften eines Projekts passwortgeschützt sind.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse und laden Sie eine Präsentation, die ein Makro enthält.  
2. Prüfen Sie, ob die Präsentation ein [VBA‑Projekt](https://reference.aspose.com/slides/de/net/aspose.slides.vba/vbaproject/) enthält.  
3. Überprüfen Sie, ob das VBA‑Projekt passwortgeschützt ist, um seine Eigenschaften anzuzeigen.  

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Prüft, ob die Präsentation ein VBA-Projekt enthält.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **FAQ**

### Was passiert mit Makros, wenn ich die Präsentation als PPTX speichere?

Makros werden entfernt, da PPTX VBA nicht unterstützt. Um Makros zu erhalten, wählen Sie PPTM, PPSM oder POTM.

### Kann Aspose.Slides Makros innerhalb einer Präsentation ausführen, um beispielsweise Daten zu aktualisieren?

Nein. Die Bibliothek führt niemals VBA‑Code aus; die Ausführung ist nur innerhalb von PowerPoint mit den entsprechenden Sicherheitseinstellungen möglich.

### Wird die Arbeit mit ActiveX‑Steuerelementen, die mit VBA‑Code verknüpft sind, unterstützt?

Ja, Sie können vorhandene [ActiveX‑Steuerelemente](/slides/de/net/activex/) zugreifen, deren Eigenschaften ändern und sie entfernen. Dies ist nützlich, wenn Makros mit ActiveX interagieren.