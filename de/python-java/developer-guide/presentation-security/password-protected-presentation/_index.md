---
title: Passwortgeschützte Präsentationen in Python
linktitle: Passwortschutz
type: docs
weight: 20
url: /de/python-java/password-protected-presentation/
keywords:
- passwortgeschützte Präsentation
- Öffnungskennwort
- PowerPoint verschlüsseln
- PowerPoint entschlüsseln
- Präsentationskennwort validieren
- Präsentationskennwort prüfen
- verschlüsselte Präsentation öffnen
- Verschlüsselung entfernen
- PowerPoint
- PPT
- PPTX
- Präsentation
- Python
- Aspose.Slides
description: "Verschlüsseln, erkennen, validieren, öffnen und entschlüsseln Sie passwortgeschützte PowerPoint PPT- und PPTX-Präsentationen mit Aspose.Slides für Python via Java."
---
## **Übersicht**

Ein Öffnungskennwort verschlüsselt eine Präsentation. Das korrekte Kennwort ist erforderlich, um die Präsentationsinhalte zu laden und anzuzeigen, sodass dieser Schutz Vertraulichkeit gewährleistet.

Ein Öffnungskennwort unterscheidet sich von einem Schreibschutzkennwort. Der Schreibschutz schränkt Änderungen ein, verschlüsselt jedoch nicht den Inhalt und verhindert nicht das Laden der Präsentation. Um Kennwörter für die Modifizierung von Präsentationen zu verwalten, siehe [Präsentationen schreibgeschützt](/slides/de/python-java/write-protected-presentation/).

## **Eine Präsentation mit einem Öffnungskennwort verschlüsseln**

Verwenden Sie [ProtectionManager.encrypt](https://reference.aspose.com/slides/de/python-java/aspose.slides/protectionmanager/#encrypt), um ein Öffnungskennwort zuzuweisen. Anschließend verwenden Sie [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save), um die verschlüsselte Präsentation zu speichern.

Das folgende Beispiel verschlüsselt eine PPTX‑Präsentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dokumenteigenschaften öffentlich halten**

Standardmäßig schließt Aspose.Slides Dokumenteigenschaften in die Präsentationsverschlüsselung ein. Die Methode [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) steuert dieses Verhalten unabhängig von der Folieninhaltsverschlüsselung. Übergeben Sie `False`, bevor Sie [ProtectionManager.encrypt](https://reference.aspose.com/slides/de/python-java/aspose.slides/protectionmanager/#encrypt) aufrufen, wenn ein Indexierungs-, Klassifizierungs-, Such- oder Dokumentverwaltungssystem Metadaten ohne das Öffnungskennwort lesen muss.

Das folgende Beispiel erstellt eine verschlüsselte PPTX‑Präsentation, lässt jedoch deren integrierte Dokumenteigenschaften öffentlich:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Übergeben von `False` an [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) macht nicht Folien, Masterfolien, Layouts, Formen, Medien oder andere Präsentationsinhalte öffentlich. Es betrifft ausschließlich Dokumenteigenschaften. Um diese Eigenschaften zu lesen, ohne den verschlüsselten Inhalt zu laden, siehe [Präsentationseigenschaften verwalten](/slides/de/python-java/presentation-properties/).

## **Eine verschlüsselte Präsentation laden**

Setzen Sie [LoadOptions.setPassword](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setPassword) auf das Öffnungskennwort und übergeben Sie die Optionen beim Laden der Datei an [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/). Das Laden schlägt fehl, wenn ein Öffnungskennwort erforderlich ist, das übergebene Kennwort jedoch fehlt oder falsch ist.

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # Mit der entschlüsselten Präsentation arbeiten.
    pass
finally:
    presentation.dispose()
```

## **Verschlüsselung aus einer Präsentation entfernen**

Laden Sie die Präsentation mit ihrem Öffnungskennwort, rufen Sie [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/de/python-java/aspose.slides/protectionmanager/#removeEncryption) auf und speichern Sie das Ergebnis. Die gespeicherte Präsentation kann anschließend ohne Kennwort geladen werden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ein Öffnungskennwort vor dem Laden validieren**

Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationfactory/#getPresentationInfo), um [PresentationInfo](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/) zu erhalten, ohne eine vollständige Präsentationsinstanz zu erstellen. Prüfen Sie [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#isPasswordProtected), bevor Sie ein Kennwort anfordern oder validieren. Ist ein Schutz vorhanden, validieren Sie den angegebenen Wert mit [PresentationInfo.checkPassword](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#checkPassword).

### **Dateipfad‑Workflow**

Das folgende Beispiel validiert ein Öffnungskennwort für eine PPTX‑Datei, übergibt den validierten Wert an [LoadOptions.setPassword](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setPassword) und lädt anschließend die vollständige Präsentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **Stream‑Workflow**

Die Stream‑Überladung von [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationfactory/#getPresentationInfo) bietet denselben Ablauf. Setzen Sie die Position eines durchsuchbaren Streams zurück, bevor Sie die vollständige Präsentation aus diesem Stream laden.

Das folgende Beispiel verwendet eine PPT‑Datei:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **Rückgabewerte von checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#checkPassword) gibt nur dann `True` zurück, wenn die Präsentation ein Öffnungskennwort besitzt und das übergebene Kennwort korrekt ist. In den folgenden Fällen wird `False` zurückgegeben:

- Das Kennwort ist falsch.
- Die Präsentation besitzt kein Öffnungskennwort.
- Das übergebene Kennwort ist `None` oder leer.

Das Verhalten ist für PPT‑ und PPTX‑Präsentationen identisch.

## **Prüfen, ob eine geladene Präsentation verschlüsselt ist**

Nachdem Sie eine Präsentation mit dem korrekten Kennwort geladen haben, prüfen Sie [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/de/python-java/aspose.slides/protectionmanager/#isEncrypted), um zu bestätigen, dass die Quellpräsentation verschlüsselt war. Um einen Öffnungskennwortschutz vor dem Laden zu erkennen, verwenden Sie [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#isPasswordProtected) wie oben gezeigt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **Sicherheitsempfehlungen**

{{% alert color="warning" title="Sicherheit" %}}
Protokollieren Sie Öffnungskennwörter nicht und fügen Sie sie nicht in Diagnosemeldungen ein. Vermeiden Sie unnötige wiederholte Validierungsversuche, halten Sie Kennwörter nur so lange im Speicher, wie sie benötigt werden, und verwenden Sie ein erfolgreiches Validierungsergebnis erneut, wenn die Präsentation sofort geladen wird.

Öffentliche Dokumenteigenschaften können Autorennamen, Titel, Themen, Schlüsselwörter, Unternehmensinformationen, Kommentare und benutzerdefinierte Werte preisgeben, obwohl der Präsentationsinhalt verschlüsselt ist. Verschlüsseln Sie sensible Metadaten zusammen mit der Präsentation. Das Offenlassen von Eigenschaften sollte eine bewusste Entscheidung sein, die nur getroffen wird, wenn Systeme die Datei ohne Öffnungskennwort indexieren, klassifizieren, durchsuchen oder verwalten müssen.
{{% /alert %}}

## **Eine Präsentation online kennwortschützen**

1. Öffnen Sie die Anwendung [Aspose.Slides Lock](https://products.aspose.app/slides/de/lock).
1. Wählen Sie die Präsentation aus oder laden Sie sie hoch.
1. Geben Sie ein Kennwort zum Schutz der Ansicht ein.
1. Optional geben Sie ein separates Kennwort zum Schutz der Bearbeitung ein.
1. Wenden Sie den Schutz an und laden Sie die resultierende Datei herunter.

{{% alert color="info" title="Siehe auch" %}}
- [Präsentationen schreibgeschützt](/slides/de/python-java/write-protected-presentation/)
- [Digitale Signatur in PowerPoint](/slides/de/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einem Öffnungskennwort und einem Schreibschutzkennwort?**

Ein Öffnungskennwort verschlüsselt die Präsentation und ist erforderlich, um deren Inhalt zu laden. Ein Schreibschutzkennwort schränkt die Bearbeitung ein, ohne den Inhalt zu verschlüsseln.

**Kann ich ein Öffnungskennwort validieren, ohne alle Folien zu laden?**

Ja. Rufen Sie Präsentationsinformationen ab, prüfen Sie, ob ein Öffnungskennwortschutz vorhanden ist, und validieren Sie das Kennwort, bevor Sie eine vollständige Präsentationsinstanz erstellen.

**Kann eine Anwendung Metadaten ohne das Öffnungskennwort lesen?**

Ja, jedoch nur, wenn die Präsentation mit deaktivierter Dokument‑Eigenschafts‑Verschlüsselung verschlüsselt wurde. Die Anwendung muss dann den nur‑für‑Dokumenteigenschaften‑Lademodus verwenden, der in [Präsentationseigenschaften verwalten](/slides/de/python-java/presentation-properties/) beschrieben ist.

**Unterstützen die passwortbasierten Workflows sowohl PPT als auch PPTX?**

Ja. Die passwortbasierte Erkennung und Validierung per Dateipfad und Stream verhalten sich für PPT‑ und PPTX‑Präsentationen identisch.