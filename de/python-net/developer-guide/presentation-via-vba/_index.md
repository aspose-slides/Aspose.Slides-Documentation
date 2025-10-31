---
title: "VBA-Projekte in Präsentationen mit Python verwalten"
linktitle: "Präsentation via VBA"
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

## **Überblick**

Dieser Artikel untersucht die wichtigsten Funktionen von Aspose.Slides für Python via .NET für die Arbeit mit Makros in PowerPoint-Präsentationen. Die Bibliothek bietet praktische Werkzeuge zum Hinzufügen, Entfernen und Extrahieren von Makros, wodurch Sie die Erstellung und Änderung von Präsentationen automatisieren können.

Mit Aspose.Slides können Sie:

- Die Präsentationsentwicklung beschleunigen – die Automatisierung routinemäßiger Aufgaben reduziert die für die Vorbereitung von Materialien benötigte Zeit.
- Flexibilität gewährleisten – die Möglichkeit, Makros zu verwalten, erlaubt es Ihnen, Präsentationen an spezifische Aufgaben und Szenarien anzupassen.
- Daten integrieren – die einfache Integration externer Datenquellen hilft, den Folieninhalt aktuell zu halten.
- Die Wartung vereinfachen – zentrales Makro‑Management erleichtert Änderungen und Updates von Präsentationen.

Der Artikel präsentiert praktische Beispiele, wie Sie Aspose.Slides effektiv für die Arbeit mit Makros in PowerPoint einsetzen können.

Der Namespace [aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) stellt Klassen für die Arbeit mit Makros und VBA‑Code bereit.

{{% alert title="Hinweis" color="warning" %}}

Wenn Sie eine Präsentation, die Makros enthält, in ein anderes Format (PDF, HTML usw.) konvertieren, ignoriert Aspose.Slides die Makros – sie werden nicht in die Ausgabedatei übertragen.

Wenn Sie Makros zu einer Präsentation hinzufügen oder eine Präsentation, die Makros enthält, erneut speichern, schreibt Aspose.Slides die Makro‑Bytes unverändert.

Aspose.Slides **führt** Makros in einer Präsentation **nie** aus.

{{% /alert %}}

## **VBA‑Makros hinzufügen**

Aspose.Slides stellt die Klasse [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) bereit, um VBA‑Projekte (und Projekt‑Referenzen) zu erstellen und vorhandene Module zu bearbeiten.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Verwenden Sie den Konstruktor [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors), um ein neues VBA‑Projekt hinzuzufügen.
3. Fügen Sie dem VBA‑Projekt ein Modul hinzu.
4. Setzen Sie den Quellcode des Moduls.
5. Fügen Sie eine Referenz zu `<stdole>` hinzu.
6. Fügen Sie eine Referenz zu **Microsoft Office** hinzu.
7. Verknüpfen Sie die Referenzen mit dem VBA‑Projekt.
8. Speichern Sie die Präsentation.

Der folgende Python‑Code zeigt, wie Sie ein VBA‑Makro von Grund auf zu einer Präsentation hinzufügen:

```python
import aspose.slides as slides

# Erstelle eine Instanz der Presentation‑Klasse.
with slides.Presentation() as presentation:

    # Erstelle ein neues VBA‑Projekt.
    presentation.vba_project = slides.vba.VbaProject()

    # Füge ein leeres Modul zum VBA‑Projekt hinzu.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # Setze den Quellcode des Moduls.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # Erstelle eine Referenz zu <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Erstelle eine Referenz zu Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Füge die Referenzen zum VBA‑Projekt hinzu.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # Speichere die Präsentation.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}

Sie können auch den **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros) ausprobieren, eine kostenlose Web‑App zum Entfernen von Makros aus PowerPoint-, Excel‑ und Word‑Dokumenten.

{{% /alert %}}

## **VBA‑Makros entfernen**

Über die Eigenschaft [vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) können Sie ein VBA‑Makro entfernen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und laden Sie die Präsentation, die das Makro enthält.
2. Greifen Sie auf das Makro‑Modul zu und entfernen Sie es.
3. Speichern Sie die geänderte Präsentation.

Der folgende Python‑Code zeigt, wie Sie ein VBA‑Makro entfernen:

```python
import aspose.slides as slides

# Lade die Präsentation, die das Makro enthält.
with slides.Presentation("VBA.pptm") as presentation:
    
    # Greife auf das VBA‑Modul zu.
    vba_module = presentation.vba_project.modules[0]

    # Entferne das VBA‑Modul.
    presentation.vba_project.modules.remove(vba_module)

    # Speichere die Präsentation.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **VBA‑Makros extrahieren**

Über die Eigenschaft `modules` in der Klasse [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) können Sie auf alle Module eines VBA‑Projekts zugreifen. Die Klasse [VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) lässt sich verwenden, um Modul‑Eigenschaften wie Name und Code zu extrahieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und laden Sie die Präsentation, die das Makro enthält.
2. Prüfen Sie, ob die Präsentation ein VBA‑Projekt enthält.
3. Durchlaufen Sie alle Module im VBA‑Projekt, um die Makros anzuzeigen.

Der folgende Python‑Code zeigt, wie Sie VBA‑Makros aus einer Präsentation extrahieren:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Prüfe, ob die Präsentation ein VBA‑Projekt enthält.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **Prüfen, ob ein VBA‑Projekt mit einem Kennwort geschützt ist**

Über die Eigenschaft [VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/) können Sie feststellen, ob die Eigenschaften eines Projekts kennwortgeschützt sind.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und laden Sie eine Präsentation, die ein Makro enthält.
2. Prüfen Sie, ob die Präsentation ein [VBA‑Projekt](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) enthält.
3. Prüfen Sie, ob das VBA‑Projekt kennwortgeschützt ist, um dessen Eigenschaften anzuzeigen.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Prüfe, ob die Präsentation ein VBA‑Projekt enthält.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **FAQ**

**Was passiert mit Makros, wenn ich die Präsentation als PPTX speichere?**

Makros werden entfernt, da PPTX kein VBA unterstützt. Um Makros zu erhalten, wählen Sie PPTM, PPSM oder POTM.

**Kann Aspose.Slides Makros in einer Präsentation ausführen, um z. B. Daten zu aktualisieren?**

Nein. Die Bibliothek führt niemals VBA‑Code aus; die Ausführung ist nur in PowerPoint mit den entsprechenden Sicherheitseinstellungen möglich.

**Werden ActiveX‑Steuerelemente, die mit VBA‑Code verknüpft sind, unterstützt?**

Ja, Sie können vorhandene [ActiveX controls](/slides/de/python-net/activex/) zugreifen, deren Eigenschaften ändern und sie entfernen. Dies ist nützlich, wenn Makros mit ActiveX interagieren.