---
title: Präsentation über VBA
type: docs
weight: 250
url: /net/presentation-via-vba/
keywords: "Makro, Makros, VBA, VBA-Makro, Makro hinzufügen, Makro entfernen, VBA hinzufügen, VBA entfernen, Makro extrahieren, VBA extrahieren, PowerPoint-Makro, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Fügen Sie VBA-Makros in PowerPoint-Präsentationen in C# oder .NET hinzu, entfernen und extrahieren."
---

Der [Aspose.Slides.Vba](https://reference.aspose.com/slides/net/aspose.slides.vba/) Namespace enthält Klassen und Schnittstellen für die Arbeit mit Makros und VBA-Code.

{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie eine Präsentation, die Makros enthält, in ein anderes Dateiformat (PDF, HTML usw.) konvertieren, ignoriert Aspose.Slides alle Makros (Makros werden nicht in die resultierende Datei übernommen).

Wenn Sie Makros zu einer Präsentation hinzufügen oder eine Präsentation mit Makros erneut speichern, schreibt Aspose.Slides einfach die Bytes für die Makros.

Aspose.Slides **führt niemals** die Makros in einer Präsentation aus.

{{% /alert %}}

## **VBA-Makros hinzufügen**

Aspose.Slides stellt die [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/) Klasse zur Verfügung, um Ihnen zu ermöglichen, VBA-Projekte (und Projektverweise) zu erstellen und vorhandene Module zu bearbeiten. Sie können die [IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/) Schnittstelle verwenden, um VBA, das in einer Präsentation eingebettet ist, zu verwalten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
1. Verwenden Sie den [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) Konstruktor, um ein neues VBA-Projekt hinzuzufügen.
1. Fügen Sie dem VbaProject ein Modul hinzu.
1. Setzen Sie den Quellcode des Moduls.
1. Fügen Sie Verweise auf <stdole> hinzu.
1. Fügen Sie Verweise auf **Microsoft Office** hinzu.
1. Verknüpfen Sie die Verweise mit dem VBA-Projekt.
1. Speichern Sie die Präsentation.

Dieser C#-Code zeigt, wie Sie ein VBA-Makro von Grund auf zu einer Präsentation hinzufügen:

```c#
    // Erstellt eine Instanz der Präsentationsklasse
using (Presentation presentation = new Presentation())
{
    // Erstellt ein neues VBA-Projekt
    presentation.VbaProject = new VbaProject();

    // Fügt dem VBA-Projekt ein leeres Modul hinzu
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Modul");
  
    // Setzt den Quellcode des Moduls
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

Sie möchten möglicherweise **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros) ausprobieren, eine kostenlose Webanwendung zum Entfernen von Makros aus PowerPoint-, Excel- und Word-Dokumenten. 

{{% /alert %}} 

## **VBA-Makros entfernen**
Mit der [VbaProject](https://reference.aspose.com/slides/net/aspose.slides/presentation/vbaproject/) Eigenschaft der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse können Sie ein VBA-Makro entfernen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse und laden Sie die Präsentation, die das Makro enthält.
1. Greifen Sie auf das Makromodul zu und entfernen Sie es.
1. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code zeigt, wie Sie ein VBA-Makro entfernen:

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


## **VBA-Makros extrahieren**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse und laden Sie die Präsentation, die das Makro enthält.
2. Überprüfen Sie, ob die Präsentation ein VBA-Projekt enthält.
3. Schleifen Sie durch alle Module, die im VBA-Projekt enthalten sind, um die Makros anzuzeigen.

Dieser C#-Code zeigt, wie Sie VBA-Makros aus einer Präsentation mit Makros extrahieren:

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

## **Überprüfen, ob ein VBA-Projekt passwortgeschützt ist**

Mit der [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) Eigenschaft können Sie überprüfen, ob die Projekteigenschaften passwortgeschützt sind.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse und laden Sie die Präsentation, die das Makro enthält.
2. Überprüfen Sie, ob die Präsentation ein [VBA-Projekt](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/) enthält.
3. Überprüfen Sie, ob das VBA-Projekt durch ein Passwort geschützt ist, um die Projekteigenschaften anzuzeigen.

Dieser C#-Code demonstriert die Operation:

```c#
using (Presentation pres = new Presentation("VBA.pptm"))
{
    if (pres.VbaProject == null) // Überprüft, ob die Präsentation ein VBA-Projekt enthält
        return;

    if (pres.VbaProject.IsPasswordProtected)
    {
        Console.WriteLine("Das VBA-Projekt '" + pres.VbaProject.Name +
                            "' ist durch ein Passwort geschützt, um die Projekteigenschaften anzuzeigen.");
    }
}
```