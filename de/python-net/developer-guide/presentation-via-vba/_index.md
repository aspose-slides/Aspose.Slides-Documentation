---
title: Verwalten von VBA-Projekten in Präsentationen mit Python
linktitle: Präsentation via VBA
type: docs
weight: 250
url: /de/python-net/presentation-via-vba/
keywords:
- macro
- VBA
- VBA macro
- add macro
- remove macro
- extract macro
- add VBA
- remove VBA
- extract VBA
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Entdecken Sie, wie Sie PowerPoint- und OpenDocument‑Präsentationen über VBA mit Aspose.Slides für Python via .NET generieren und manipulieren, um Ihren Arbeitsablauf zu optimieren."
---

## **Übersicht**

Dieser Artikel untersucht die wichtigsten Funktionen von Aspose.Slides für Python via .NET zum Arbeiten mit Makros in PowerPoint‑Präsentationen. Die Bibliothek bietet praktische Werkzeuge zum Hinzufügen, Entfernen und Extrahieren von Makros, wodurch Sie die Erstellung und Modifizierung von Präsentationen automatisieren können.

Mit Aspose.Slides können Sie:

- Die Entwicklung von Präsentationen beschleunigen – die Automatisierung von Routinetasks reduziert die benötigte Zeit für die Vorbereitung von Materialien.
- Flexibilität gewährleisten – die Möglichkeit, Makros zu verwalten, ermöglicht es Ihnen, Präsentationen an spezifische Aufgaben und Szenarien anzupassen.
- Daten integrieren – die einfache Anbindung an externe Datenquellen hilft, den Inhalt der Folien stets aktuell zu halten.
- Die Wartung vereinfachen – zentrales Makro‑Management erleichtert das Anwenden von Änderungen und das Aktualisieren von Präsentationen.

Im weiteren Verlauf werden praxisnahe Beispiele gezeigt, wie Sie Aspose.Slides effektiv zum Arbeiten mit Makros in PowerPoint einsetzen können.

Der Namespace [aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) stellt Klassen für die Arbeit mit Makros und VBA‑Code bereit.

{{% alert title="Hinweis" color="warning" %}}

Wenn Sie eine Präsentation, die Makros enthält, in ein anderes Format (PDF, HTML usw.) konvertieren, ignoriert Aspose.Slides die Makros – sie werden nicht in die Ausgabedatei übernommen.

Wenn Sie einer Präsentation Makros hinzufügen oder eine Präsentation, die Makros enthält, erneut speichern, schreibt Aspose.Slides die Makro‑Bytes unverändert.

Aspose.Slides führt **niemals** Makros in einer Präsentation aus.

{{% /alert %}}

## **VBA‑Makros hinzufügen**

Aspose.Slides stellt die Klasse [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) bereit, um VBA‑Projekte (und Projekt‑Referenzen) zu erstellen und vorhandene Module zu bearbeiten.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Verwenden Sie den Konstruktor [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors), um ein neues VBA‑Projekt hinzuzufügen.
1. Fügen Sie dem VBA‑Projekt ein Modul hinzu.
1. Setzen Sie den Quellcode des Moduls.
1. Fügen Sie eine Referenz zu `<stdole>` hinzu.
1. Fügen Sie eine Referenz zu **Microsoft Office** hinzu.
1. Ordnen Sie die Referenzen dem VBA‑Projekt zu.
1. Speichern Sie die Präsentation.

Der folgende Python‑Code zeigt, wie Sie ein VBA‑Makro von Grund auf zu einer Präsentation hinzufügen:

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:

    # Create a new VBA project.
    presentation.vba_project = slides.vba.VbaProject()

    # Add an empty module to the VBA project.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # Set the module source code.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # Create a reference to <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Create a reference to Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Add the references to the VBA project.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # Save the presentation.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}

Vielleicht möchten Sie den **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros) ausprobieren – eine kostenlose Web‑App zum Entfernen von Makros aus PowerPoint‑, Excel‑ und Word‑Dokumenten.

{{% /alert %}}

## **VBA‑Makros entfernen**

Über die Eigenschaft [vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) können Sie ein VBA‑Makro entfernen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und laden Sie die Präsentation, die das Makro enthält.
1. Greifen Sie auf das Makro‑Modul zu und entfernen Sie es.
1. Speichern Sie die geänderte Präsentation.

Der folgende Python‑Code zeigt, wie Sie ein VBA‑Makro entfernen:

```python
import aspose.slides as slides

# Load the presentation that contains the macro.
with slides.Presentation("VBA.pptm") as presentation:
    
    # Access the VBA module.
    vba_module = presentation.vba_project.modules[0]

    # Remove the VBA module.
    presentation.vba_project.modules.remove(vba_module)

    # Save the presentation.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **VBA‑Makros extrahieren**

Über die Eigenschaft `modules` der Klasse [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) können Sie auf alle Module eines VBA‑Projekts zugreifen. Die Klasse [VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) lässt sich verwenden, um Moduleigenschaften wie Namen und Code zu extrahieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und laden Sie die Präsentation, die das Makro enthält.
1. Prüfen Sie, ob die Präsentation ein VBA‑Projekt enthält.
1. Durchlaufen Sie alle Module des VBA‑Projekts, um die Makros anzuzeigen.

Der folgende Python‑Code zeigt, wie Sie VBA‑Makros aus einer Präsentation extrahieren:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Check whether the presentation contains a VBA project.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **Prüfen, ob ein VBA‑Projekt passwortgeschützt ist**

Über die Eigenschaft [VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/) können Sie feststellen, ob die Projekteigenschaften durch ein Passwort geschützt sind.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und laden Sie eine Präsentation, die ein Makro enthält.
1. Prüfen Sie, ob die Präsentation ein [VBA‑Projekt](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) enthält.
1. Prüfen Sie, ob das VBA‑Projekt passwortgeschützt ist, um die Eigenschaften anzuzeigen.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Check whether the presentation contains a VBA project.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **FAQ**

**Was passiert mit Makros, wenn ich die Präsentation als PPTX speichere?**

Makros werden entfernt, da PPTX VBA nicht unterstützt. Um Makros zu behalten, wählen Sie PPTM, PPSM oder POTM.

**Kann Aspose.Slides Makros in einer Präsentation ausführen, z. B. um Daten zu aktualisieren?**

Nein. Die Bibliothek führt niemals VBA‑Code aus; die Ausführung ist nur in PowerPoint mit den entsprechenden Sicherheitseinstellungen möglich.

**Werden ActiveX‑Steuerelemente, die mit VBA‑Code verknüpft sind, unterstützt?**

Ja, Sie können vorhandene [ActiveX‑Steuerelemente](/slides/de/python-net/activex/) zugreifen, deren Eigenschaften ändern und sie entfernen. Das ist nützlich, wenn Makros mit ActiveX interagieren.