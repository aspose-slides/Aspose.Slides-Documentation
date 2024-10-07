---
title: Präsentation über VBA
type: docs
weight: 250
url: /python-net/presentation-via-vba/
keywords: "Makro, Makros, VBA, VBA-Makro, Makro hinzufügen, Makro entfernen, VBA hinzufügen, VBA entfernen, Makro extrahieren, VBA extrahieren, PowerPoint-Makro, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Fügen Sie VBA-Makros in PowerPoint-Präsentationen in Python hinzu, entfernen und extrahieren Sie sie."
---

Der [Aspose.Slides.Vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) Namespace enthält Klassen und Schnittstellen zum Arbeiten mit Makros und VBA-Code.

{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie eine Präsentation, die Makros enthält, in ein anderes Dateiformat (PDF, HTML usw.) konvertieren, ignoriert Aspose.Slides alle Makros (Makros werden nicht in die resultierende Datei übertragen).

Wenn Sie Makros zu einer Präsentation hinzufügen oder eine Präsentation speichern, die Makros enthält, schreibt Aspose.Slides einfach die Bytes für die Makros.

Aspose.Slides **führt niemals** die Makros in einer Präsentation aus.

{{% /alert %}}

## **VBA-Makros hinzufügen**

Aspose.Slides bietet die [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) Klasse, mit der Sie VBA-Projekte (und Projektverweise) erstellen und vorhandene Module bearbeiten können. Sie können die [IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/) Schnittstelle verwenden, um VBA in einer Präsentation zu verwalten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Verwenden Sie den Konstruktor der [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors), um ein neues VBA-Projekt hinzuzufügen.
1. Fügen Sie ein Modul zum VbaProject hinzu.
1. Setzen Sie den Quellcode des Moduls.
1. Fügen Sie Verweise auf <stdole> hinzu.
1. Fügen Sie Verweise auf **Microsoft Office** hinzu.
1. Verknüpfen Sie die Verweise mit dem VBA-Projekt.
1. Speichern Sie die Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie ein VBA-Makro von Grund auf zu einer Präsentation hinzufügen:

```python
import aspose.slides as slides

# Erstellt eine Instanz der Präsentationsklasse
with slides.Presentation() as presentation:
    # Erstellt ein neues VBA-Projekt
    presentation.vba_project = slides.vba.VbaProject()

    # Fügt ein leeres Modul zum VBA-Projekt hinzu
    module = presentation.vba_project.modules.add_empty_module("Modul")
  
    # Setzt den Quellcode des Moduls
    module.source_code = "Sub Test(oShape As Shape) MsgBox ""Test"" End Sub"

    # Erstellt einen Verweis auf <stdole>
    stdoleReference = slides.vba.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Erstellt einen Verweis auf Office
    officeReference =slides.vba.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Fügt Verweise zum VBA-Projekt hinzu
    presentation.vba_project.references.add(stdoleReference)
    presentation.vba_project.references.add(officeReference)

            
    # Speichert die Präsentation
    presentation.save("AddVBAMacros_out.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}} 

Sie sollten sich **Aspose** [Makro-Entferner](https://products.aspose.app/slides/remove-macros) ansehen, eine kostenlose Webanwendung, die verwendet wird, um Makros aus PowerPoint-, Excel- und Word-Dokumenten zu entfernen. 

{{% /alert %}} 

## **VBA-Makros entfernen**

Über die [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#properties) Eigenschaft der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse können Sie ein VBA-Makro entfernen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und laden Sie die Präsentation, die das Makro enthält.
1. Greifen Sie auf das Makro-Modul zu und entfernen Sie es.
1. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie ein VBA-Makro entfernen:

```python
import aspose.slides as slides

# Lädt die Präsentation, die das Makro enthält
with slides.Presentation(path + "VBA.pptm") as presentation:
    # Greift auf das Vba-Modul zu und entfernt es  
    presentation.vba_project.modules.remove(presentation.vba_project.modules[0])

    # Speichert die Präsentation
    presentation.save("RemovedVBAMacros_out.pptm", slides.export.SaveFormat.PPTM)
```

## **VBA-Makros extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und laden Sie die Präsentation, die das Makro enthält.
2. Überprüfen Sie, ob die Präsentation ein VBA-Projekt enthält.
3. Durchlaufen Sie alle Module, die im VBA-Projekt enthalten sind, um die Makros anzuzeigen.

Dieser Python-Code zeigt Ihnen, wie Sie VBA-Makros aus einer Präsentation, die Makros enthält, extrahieren:

```python
import aspose.slides as slides

with slides.Presentation(path + "VBA.pptm") as pres:
    if pres.vba_project is not None: # Überprüft, ob die Präsentation ein VBA-Projekt enthält
        for module in pres.vba_project.modules:
            print(module.name)
            print(module.source_code)
```