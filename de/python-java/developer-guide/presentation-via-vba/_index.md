---
title: Verwalten von VBA-Projekten in Präsentationen mit Python
linktitle: Präsentation via VBA
type: docs
weight: 250
url: /de/python-java/presentation-via-vba/
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
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen über VBA mit Aspose.Slides für Python via Java generieren und bearbeiten, um Ihren Arbeitsablauf zu optimieren."
---
## **Einleitung**

Aspose.Slides stellt Klassen und Schnittstellen zum Arbeiten mit Makros und VBA‑Code bereit.

{{% alert title="Warning" color="warning" %}} 

Wenn Sie eine Präsentation, die Makros enthält, in ein anderes Dateiformat (PDF, HTML usw.) konvertieren, ignoriert Aspose.Slides alle Makros (Makros werden nicht in die resultierende Datei übernommen).

Wenn Sie einer Präsentation Makros hinzufügen oder eine Präsentation, die Makros enthält, erneut speichern, schreibt Aspose.Slides einfach die Bytes für die Makros.

Aspose.Slides **nie** führt die Makros in einer Präsentation aus.

{{% /alert %}}

## **VBA‑Makros hinzufügen**

Aspose.Slides stellt die Klasse [VbaProject](https://reference.aspose.com/slides/de/python-java/aspose.slides/vbaproject/) bereit, mit der Sie VBA‑Projekte (und Projektverweise) erstellen und vorhandene Module bearbeiten können. Sie können die Klasse [VbaProject](https://reference.aspose.com/slides/de/python-java/aspose.slides/vbaproject/) verwenden, um in einer Präsentation eingebettetes VBA zu verwalten.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
1. Verwenden Sie den Konstruktor der [VbaProject](https://reference.aspose.com/slides/de/python-java/aspose.slides/vbaproject/#vbaproject)-Klasse, um ein neues VBA‑Projekt hinzuzufügen.
1. Fügen Sie dem VBA‑Projekt ein Modul hinzu.
1. Legen Sie den Quellcode des Moduls fest.
1. Fügen Sie Verweise zu `stdole` hinzu.
1. Fügen Sie Verweise zu **Microsoft Office** hinzu.
1. Ordnen Sie die Verweise dem VBA‑Projekt zu.
1. Speichern Sie die Präsentation.

Dieser Python‑Code zeigt, wie Sie einer Präsentation von Grund auf ein VBA‑Makro hinzufügen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # Erstelle ein neues VBA-Projekt.
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # Füge ein leeres Modul hinzu und setze dessen Quellcode.
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # Erstelle Verweise auf stdole und Microsoft Office.
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Füge Verweise zum VBA-Projekt hinzu.
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # Speichere die Präsentation.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

Vielleicht möchten Sie den **Aspose** [Macro Remover](https://products.aspose.app/slides/de/remove-macros) ausprobieren, eine kostenlose Web‑App zum Entfernen von Makros aus PowerPoint-, Excel- und Word-Dokumenten. 

{{% /alert %}} 

## **VBA‑Makros entfernen**

Mit der Methode [getVbaProject](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getvbaproject) der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) können Sie ein VBA‑Makro entfernen.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) und laden Sie die Präsentation, die das Makro enthält.
1. Greifen Sie auf das Makro‑Modul zu und entfernen Sie es.
1. Speichern Sie die geänderte Präsentation.

Dieser Python‑Code zeigt, wie Sie ein VBA‑Makro entfernen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Lade die Präsentation, die das Makro enthält.
presentation = Presentation("VBA.pptm")
try:
    # Greife auf das VBA-Modul zu und entferne es.
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # Speichere die Präsentation.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **VBA‑Makros extrahieren**

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) und laden Sie die Präsentation, die das Makro enthält.
2. Prüfen Sie, ob die Präsentation ein VBA‑Projekt enthält.
3. Durchlaufen Sie alle im VBA‑Projekt enthaltenen Module, um die Makros anzuzeigen.

Dieser Python‑Code zeigt, wie Sie VBA‑Makros aus einer Präsentation, die Makros enthält, extrahieren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Lade die Präsentation, die das Makro enthält.
presentation = Presentation("VBA.pptm")
try:
    # Prüfe, ob die Präsentation ein VBA-Projekt enthält.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **Überprüfen, ob ein VBA‑Projekt passwortgeschützt ist**

Mit der Methode [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/de/python-java/aspose.slides/vbaproject/#ispasswordprotected) können Sie feststellen, ob die Eigenschaften eines Projekts passwortgeschützt sind.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) und laden Sie eine Präsentation, die ein Makro enthält.
2. Prüfen Sie, ob die Präsentation ein [VBA‑Projekt](https://reference.aspose.com/slides/de/python-java/aspose.slides/vbaproject/) enthält.
3. Prüfen Sie, ob das VBA‑Projekt passwortgeschützt ist, um seine Eigenschaften anzuzeigen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # Prüfe, ob die Präsentation ein VBA-Projekt enthält.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **FAQ**

**Was passiert mit Makros, wenn ich die Präsentation als PPTX speichere?**

Makros werden entfernt, weil PPTX VBA nicht unterstützt. Um Makros zu erhalten, wählen Sie PPTM, PPSM oder POTM.

**Kann Aspose.Slides Makros in einer Präsentation ausführen, um beispielsweise Daten zu aktualisieren?**

Nein. Die Bibliothek führt VBA‑Code niemals aus; die Ausführung ist nur innerhalb von PowerPoint mit den entsprechenden Sicherheitseinstellungen möglich.

**Wird die Arbeit mit ActiveX‑Steuerelementen, die mit VBA‑Code verknüpft sind, unterstützt?**

Ja, Sie können auf vorhandene [ActiveX‑Steuerelemente](/slides/de/python-java/activex/) zugreifen, deren Eigenschaften ändern und sie entfernen. Dies ist nützlich, wenn Makros mit ActiveX interagieren.