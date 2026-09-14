---
title: Schreibschutz von Präsentationen in Python
linktitle: Schreibschutz
type: docs
weight: 25
url: /de/python-java/write-protected-presentation/
keywords:
- Schreibschutz
- PowerPoint-Schreibschutz
- Passwort zum Ändern
- Bearbeitung der Präsentation einschränken
- Schreibschutz entfernen
- Passwort zur Änderung prüfen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Schreibschutz‑Passwörter in PowerPoint PPT‑ und PPTX‑Präsentationen setzen, erkennen, validieren und entfernen mit Aspose.Slides für Python über Java."
---
## **Einleitung**

Ein Schreibschutz‑Passwort schränkt die Änderung einer Präsentation ein, verschlüsselt jedoch nicht deren Inhalt. Benutzer können eine schreibgeschützte Präsentation ohne das Passwort laden und anzeigen. Je nach Anwendung können sie den Inhalt möglicherweise auch bearbeiten und unter einem anderen Namen speichern, daher sollte der Schreibschutz nicht als Vertraulichkeitsmechanismus angesehen werden.

Ein Öffnungs‑Passwort dient einem anderen Zweck: Es verschlüsselt die Präsentation und ist erforderlich, um deren Inhalt zu laden. Zum Verschlüsseln einer Präsentation oder zum Validieren eines Öffnungs‑Passworts siehe [Password-Protect Presentations](/slides/de/python-java/password-protected-presentation/).

Die in diesem Artikel beschriebenen Abläufe gelten sowohl für PPT‑ als auch für PPTX‑Präsentationen. Die Beispiele verwenden PPTX‑Dateien; beim Speichern im PPT‑Format verwenden Sie die Erweiterung `.ppt` und das entsprechende PPT‑Speicherformat.

## **Schreibschutz für eine Präsentation festlegen**

Verwenden Sie [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/de/python-java/aspose.slides/protectionmanager/#setWriteProtection), um ein Passwort für die Änderung einer Präsentation zuzuweisen. Das Speichern der Präsentation bewahrt die Schutzeinstellung.

Das folgende Beispiel legt Schreibschutz für eine PPTX‑Präsentation fest:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Eine schreibgeschützte Präsentation laden**

Da Schreibschutz den Präsentationsinhalt nicht verschlüsselt, ist zum Laden der Präsentation kein Passwort erforderlich. Das Passwort ist nur relevant, wenn die Berechtigung zur Änderung der geschützten Präsentation validiert wird.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

Übergeben Sie kein Schreibschutz‑Passwort an [LoadOptions.setPassword](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setPassword). Diese Methode akzeptiert ein Öffnungs‑Passwort für verschlüsselten Inhalt. Hat eine Präsentation beide Schutzarten, geben Sie das Öffnungs‑Passwort zum Laden an und behandeln Sie das Schreibschutz‑Passwort separat.

## **Schreibschutz von einer Präsentation entfernen**

Verwenden Sie [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/de/python-java/aspose.slides/protectionmanager/#removeWriteProtection), um die Änderungsbeschränkung zu entfernen, und speichern Sie anschließend die Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Prüfen, ob eine Präsentation schreibgeschützt ist**

Um eine Datei zu untersuchen, ohne eine vollständige [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Instanz zu erstellen, rufen Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationfactory/#getPresentationInfo) auf und prüfen Sie [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#isWriteProtected). Die Methode verwendet [NullableBool](https://reference.aspose.com/slides/de/python-java/aspose.slides/nullablebool/) und gibt `NullableBool.True_` zurück, wenn Schreibschutz erkannt wird.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

Die Stream‑Überladung von [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationfactory/#getPresentationInfo) liefert dieselben Informationen für eine als Stream bereitgestellte Präsentation.

## **Ein Schreibschutz‑Passwort validieren**

Verwenden Sie [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#checkWriteProtection), um ein Änderungs‑Passwort zu validieren, ohne die vollständige Präsentation zu laden. Prüfen Sie zuerst [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#isWriteProtected), damit die Anwendung ein Passwort nur anfordert oder validiert, wenn Schreibschutz vorhanden ist.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#checkWriteProtection) validiert ausschließlich das Schreibschutz‑Passwort. Es validiert kein Öffnungs‑Passwort und prüft nicht, ob verschlüsselter Inhalt geladen werden kann. Umgekehrt validiert [PresentationInfo.checkPassword](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#checkPassword) nur ein Öffnungs‑Passwort. Ist bereits eine vollständige Präsentation geladen, liefert [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/de/python-java/aspose.slides/protectionmanager/#checkWriteProtection) die entsprechende Schreibschutz‑Prüfung über den Schutz‑Manager.

In Produktionsanwendungen sollten Passwörter nicht protokolliert oder in Diagnosemeldungen verwendet werden. Vermeiden Sie unnötige wiederholte Validierungsversuche und behalten Sie Passwörter im Speicher nur so lange, wie sie benötigt werden.

{{% alert color="info" title="Siehe auch" %}}
- [Password-Protect Presentations](/slides/de/python-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/de/python-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/de/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Verschlüsselt Schreibschutz eine Präsentation?**

Nein. Er schränkt die Modifikation ein, lässt jedoch den Präsentationsinhalt zum Laden und Anzeigen verfügbar.

**Ist das Schreibschutz‑Passwort zum Öffnen einer Präsentation erforderlich?**

Nein. Es wird nur ein Öffnungs‑Passwort benötigt, um verschlüsselten Präsentationsinhalt zu laden.

**Kann eine Präsentation sowohl ein Öffnungs‑Passwort als auch ein Schreibschutz‑Passwort haben?**

Ja. Das Öffnungs‑Passwort über die Ladeoptionen angeben, um die verschlüsselte Präsentation zu öffnen, und das Schreibschutz‑Passwort separat validieren, wenn eine Änderungsberechtigung erforderlich ist.