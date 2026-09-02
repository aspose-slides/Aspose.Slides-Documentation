---
title: Schreibschutz für Präsentationen in Python
linktitle: Schreibschutz
type: docs
weight: 25
url: /de/python-net/write-protected-presentation/
keywords:
- Schreibschutz
- PowerPoint-Schreibschutz
- Passwort zum Ändern
- Bearbeitung der Präsentation einschränken
- Schreibschutz entfernen
- Passwort für Änderungen validieren
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Setzen, Erkennen, Validieren und Entfernen von Schreibschutz-Passwörtern in PowerPoint-PPT und PPTX-Präsentationen mit Aspose.Slides für Python."
---
## **Einleitung**

Ein Schreibschutz-Passwort schränkt die Änderungen einer Präsentation ein, verschlüsselt jedoch nicht deren Inhalt. Benutzer können eine schreibgeschützte Präsentation ohne das Passwort laden und anzeigen. Je nach Anwendung können sie den Inhalt außerdem bearbeiten und unter einem anderen Namen speichern, sodass Schreibschutz nicht als Vertraulichkeitsmechanismus betrachtet werden sollte.

Ein Öffnungs‑Passwort hat einen anderen Zweck: Es verschlüsselt die Präsentation und ist zum Laden ihres Inhalts erforderlich. Zum Verschlüsseln einer Präsentation oder zum Validieren eines Öffnungs‑Passworts siehe [Password-Protect Presentations](/slides/de/python-net/password-protected-presentation/).

Die Arbeitsabläufe in diesem Artikel gelten sowohl für PPT‑ als auch für PPTX‑Präsentationen. Die Beispiele verwenden PPTX‑Dateien; beim Speichern als PPT verwenden Sie die Dateiendung `.ppt` und das entsprechende PPT‑Speicherformat.

## **Schreibschutz für eine Präsentation festlegen**

Verwenden Sie [ProtectionManager.set_write_protection](https://reference.aspose.com/slides/de/python-net/aspose.slides/protectionmanager/set_write_protection/), um ein Passwort zum Ändern einer Präsentation festzulegen. Das Speichern der Präsentation bewahrt die Schutzeinstellung.

Das folgende Beispiel legt Schreibschutz für eine PPTX‑Präsentation fest:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Eine schreibgeschützte Präsentation laden**

Da Schreibschutz den Präsentationsinhalt nicht verschlüsselt, ist zum Laden der Präsentation kein Passwort erforderlich. Das Passwort ist nur relevant, wenn die Berechtigung zum Ändern der geschützten Präsentation überprüft wird.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Übergeben Sie kein Schreibschutz‑Passwort an [LoadOptions.password](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/password/). Diese Eigenschaft akzeptiert ein Öffnungs‑Passwort für verschlüsselten Inhalt. Wenn eine Präsentation beide Schutzarten besitzt, geben Sie das Öffnungs‑Passwort zum Laden an und behandeln Sie das Schreibschutz‑Passwort separat.

## **Schreibschutz von einer Präsentation entfernen**

Verwenden Sie [ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/de/python-net/aspose.slides/protectionmanager/remove_write_protection/), um die Änderungsbeschränkung zu entfernen, und speichern Sie anschließend die Präsentation.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Prüfen, ob eine Präsentation schreibgeschützt ist**

Um eine Datei zu untersuchen, ohne eine komplette [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Instanz zu erstellen, rufen Sie [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationfactory/get_presentation_info/) auf und prüfen Sie [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/is_write_protected/). Die Eigenschaft verwendet [NullableBool](https://reference.aspose.com/slides/de/python-net/aspose.slides/nullablebool/) und gibt `NullableBool.TRUE` zurück, wenn Schreibschutz erkannt wird.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

Die Stream‑Überladung von [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationfactory/get_presentation_info/) liefert dieselben Informationen für eine als Stream übergebene Präsentation.

## **Ein Schreibschutz‑Passwort validieren**

Verwenden Sie [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/check_write_protection/), um ein Änderungs‑Passwort zu validieren, ohne die komplette Präsentation zu laden. Prüfen Sie zuerst [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/is_write_protected/), damit die Anwendung ein Passwort nur anfordert oder prüft, wenn Schreibschutz vorhanden ist.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/check_write_protection/) prüft nur das Schreibschutz‑Passwort. Es prüft kein Öffnungs‑Passwort und bestimmt nicht, ob verschlüsselter Inhalt geladen werden kann. Im Gegensatz dazu prüft [PresentationInfo.check_password](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/check_password/) ausschließlich ein Öffnungs‑Passwort. Wenn eine komplette Präsentation bereits geladen wurde, bietet [ProtectionManager.check_write_protection](https://reference.aspose.com/slides/de/python-net/aspose.slides/protectionmanager/check_write_protection/) die entsprechende Schreibschutz‑Prüfung über seinen Schutz‑Manager.

In Produktionsanwendungen sollten Passwörter nicht protokolliert oder in Diagnosemeldungen eingefügt werden. Vermeiden Sie unnötige wiederholte Validierungsversuche und behalten Sie Passwörter nur solange im Speicher, wie sie benötigt werden.

{{% alert color="info" title="Siehe auch" %}}
- [Password-Protect Presentations](/slides/de/python-net/password-protected-presentation/)
- [Read-Only Presentations](/slides/de/python-net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/de/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Verschlüsselt der Schreibschutz eine Präsentation?**

Nein. Er schränkt Änderungen ein, lässt jedoch den Präsentationsinhalt zum Laden und Anzeigen verfügbar.

**Ist das Schreibschutz‑Passwort zum Öffnen einer Präsentation erforderlich?**

Nein. Nur ein Öffnungs‑Passwort ist zum Laden verschlüsselten Präsentationsinhalts erforderlich.

**Kann eine Präsentation sowohl ein Öffnungs‑Passwort als auch ein Schreibschutz‑Passwort haben?**

Ja. Geben Sie das Öffnungs‑Passwort über die Ladeoptionen an, um die verschlüsselte Präsentation zu öffnen, und prüfen Sie das Schreibschutz‑Passwort separat, wenn die Berechtigung zur Änderung erforderlich ist.