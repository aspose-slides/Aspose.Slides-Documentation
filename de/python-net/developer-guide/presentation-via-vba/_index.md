---
title: VBA-Projekte in Präsentationen mit Python verwalten
linktitle: Präsentation über VBA
type: docs
weight: 250
url: /de/python-net/presentation-via-vba/
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
- Aspose.Slides
description: "Entdecken Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen über VBA mit Aspose.Slides für Python via .NET erstellen und manipulieren, um Ihren Arbeitsablauf zu optimieren."
---

## **Übersicht**

Dieser Artikel untersucht die wichtigsten Fähigkeiten von Aspose.Slides für Python über .NET zur Arbeit mit Makros in PowerPoint‑Präsentationen. Die Bibliothek stellt praktische Werkzeuge zum Hinzufügen, Entfernen und Extrahieren von Makros bereit, wodurch Sie die Erstellung und Änderung von Präsentationen automatisieren können.

Mit Aspose.Slides können Sie:

- Die Entwicklung von Präsentationen beschleunigen – die Automatisierung routinemäßiger Aufgaben reduziert die benötigte Zeit für die Vorbereitung von Material.
- Flexibilität gewährleisten – die Möglichkeit, Makros zu verwalten, erlaubt es Ihnen, Präsentationen an spezifische Aufgaben und Szenarien anzupassen.
- Daten integrieren – die einfache Integration externer Datenquellen hilft, den Inhalt der Folien aktuell zu halten.
- Wartung vereinfachen – zentrales Makro‑Management erleichtert das Anwenden von Änderungen und das Aktualisieren von Präsentationen.

Der Artikel präsentiert anschließend praktische Beispiele, wie Aspose.Slides effektiv zum Arbeiten mit Makros in PowerPoint verwendet wird.

Der [aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) Namensraum stellt Klassen zur Arbeit mit Makros und VBA‑Code bereit.

{{% alert title="Note" color="warning" %}}
Wenn Sie eine Präsentation, die Makros enthält, in ein anderes Format (PDF, HTML usw.) konvertieren, ignoriert Aspose.Slides die Makros – sie werden nicht in die Ausgabedatei übernommen.

Wenn Sie einer Präsentation Makros hinzufügen oder eine Präsentation, die Makros enthält, erneut speichern, schreibt Aspose.Slides die Makro‑Bytes unverändert.

Aspose.Slides **nie** führt Makros in einer Präsentation aus.
{{% /alert %}}

## **VBA‑Makros hinzufügen**

Aspose.Slides stellt die Klasse [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) bereit, um VBA‑Projekte (und Projektverweise) zu erstellen und vorhandene Module zu bearbeiten.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Verwenden Sie den Konstruktor [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors), um ein neues VBA‑Projekt hinzuzufügen.
3. Fügen Sie dem VBA‑Projekt ein Modul hinzu.
4. Legen Sie den Quellcode des Moduls fest.
5. Fügen Sie einen Verweis auf `<stdole>` hinzu.
6. Fügen Sie einen Verweis auf **Microsoft Office** hinzu.
7. Verknüpfen Sie die Verweise mit dem VBA‑Projekt.
8. Speichern Sie die Präsentation.

Der folgende Python‑Code zeigt, wie Sie ein VBA‑Makro von Grund auf zu einer Präsentation hinzufügen:
```python
import aspose.slides as slides

# Erstelle eine Instanz der Präsentationsklasse.
with slides.Presentation() as presentation:

    # Erstelle ein neues VBA-Projekt.
    presentation.vba_project = slides.vba.VbaProject()

    # Füge ein leeres Modul zum VBA-Projekt hinzu.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # Setze den Quellcode des Moduls.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # Erstelle einen Verweis auf <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Erstelle einen Verweis auf Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Füge die Verweise dem VBA-Projekt hinzu.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # Speichere die Präsentation.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```


{{% alert color="primary" %}}
Vielleicht möchten Sie den **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros) ausprobieren, eine kostenlose Web‑App zum Entfernen von Makros aus PowerPoint-, Excel‑ und Word‑Dokumenten.
{{% /alert %}}

## **VBA‑Makros entfernen**

Mit der Eigenschaft [vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) können Sie ein VBA‑Makro entfernen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und laden Sie die Präsentation, die das Makro enthält.
2. Greifen Sie auf das Makro‑Modul zu und entfernen Sie es.
3. Speichern Sie die geänderte Präsentation.

Der folgende Python‑Code zeigt, wie Sie ein VBA‑Makro entfernen:
```python
import aspose.slides as slides

# Laden Sie die Präsentation, die das Makro enthält.
with slides.Presentation("VBA.pptm") as presentation:
    
    # Greifen Sie auf das VBA-Modul zu.
    vba_module = presentation.vba_project.modules[0]

    # Entfernen Sie das VBA-Modul.
    presentation.vba_project.modules.remove(vba_module)

    # Speichern Sie die Präsentation.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```


## **VBA‑Makros extrahieren**

Mit der Eigenschaft `modules` in der Klasse [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) können Sie auf alle Module eines VBA‑Projekts zugreifen. Die Klasse [VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) kann verwendet werden, um Moduleigenschaften wie Name und Code zu extrahieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und laden Sie die Präsentation, die das Makro enthält.
2. Prüfen Sie, ob die Präsentation ein VBA‑Projekt enthält.
3. Durchlaufen Sie alle Module im VBA‑Projekt, um die Makros anzuzeigen.

Der folgende Python‑Code zeigt, wie Sie VBA‑Makros aus einer Präsentation extrahieren:
```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Prüfen, ob die Präsentation ein VBA-Projekt enthält.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```


## **Überprüfen, ob ein VBA‑Projekt passwortgeschützt ist**

Mit der Eigenschaft [VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/) können Sie feststellen, ob die Eigenschaften eines Projekts passwortgeschützt sind.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und laden Sie eine Präsentation, die ein Makro enthält.
2. Prüfen Sie, ob die Präsentation ein [VBA‑Projekt](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) enthält.
3. Prüfen Sie, ob das VBA‑Projekt passwortgeschützt ist, um seine Eigenschaften anzuzeigen.
```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Prüfen, ob die Präsentation ein VBA-Projekt enthält.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```


## **FAQ**

**Was passiert mit Makros, wenn ich die Präsentation als PPTX speichere?**

Makros werden entfernt, da PPTX kein VBA unterstützt. Um Makros zu erhalten, wählen Sie PPTM, PPSM oder POTM.

**Kann Aspose.Slides Makros in einer Präsentation ausführen, um beispielsweise Daten zu aktualisieren?**

Nein. Die Bibliothek führt niemals VBA‑Code aus; die Ausführung ist nur innerhalb von PowerPoint mit den entsprechenden Sicherheitseinstellungen möglich.

**Wird die Arbeit mit ActiveX‑Steuerelementen, die mit VBA‑Code verknüpft sind, unterstützt?**

Ja, Sie können auf vorhandene [ActiveX‑Steuerelemente](/slides/de/python-net/activex/) zugreifen, deren Eigenschaften ändern und sie entfernen. Dies ist nützlich, wenn Makros mit ActiveX interagieren.