---
title: Passwortgeschützte Präsentationen in Python
linktitle: Passwortschutz
type: docs
weight: 20
url: /de/python-net/password-protected-presentation/
keywords:
- passwortgeschützte Präsentation
- Öffnungspasswort
- PowerPoint verschlüsseln
- PowerPoint entschlüsseln
- Präsentationspasswort validieren
- Präsentationspasswort prüfen
- verschlüsselte Präsentation öffnen
- Verschlüsselung entfernen
- PowerPoint
- PPT
- PPTX
- Präsentation
- Python
- Aspose.Slides
description: "Verschlüsseln, erkennen, validieren, öffnen und entschlüsseln Sie passwortgeschützte PowerPoint PPT- und PPTX-Präsentationen in Python mit Aspose.Slides."
---
## **Overview**

Ein Öffnungspasswort verschlüsselt eine Präsentation. Das korrekte Passwort ist erforderlich, um den Präsentationsinhalt zu laden und anzuzeigen, sodass dieser Schutz Vertraulichkeit bietet.

Ein Öffnungspasswort unterscheidet sich von einem Schreibschutz‑Passwort. Der Schreibschutz beschränkt die Bearbeitung, verschlüsselt jedoch nicht den Inhalt und verhindert nicht das Laden der Präsentation. Zum Verwalten von Passwörtern für die Bearbeitung von Präsentationen siehe [Write-Protect Presentations](/slides/de/python-net/write-protected-presentation/).

Die unten dargestellten Workflows gelten sowohl für PPT‑ als auch für PPTX‑Präsentationen. Die Beispiele verwenden beide Formate, wenn das datei‑ bzw. streambasierte Verhalten wichtig ist.

## **Encrypt a Presentation with an Opening Password**

Verwenden Sie [ProtectionManager.encrypt](https://reference.aspose.com/slides/de/python-net/aspose.slides/protectionmanager/encrypt/), um ein Öffnungspasswort zuzuweisen. Anschließend verwenden Sie [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/save/), um die verschlüsselte Präsentation zu speichern.

Das folgende Beispiel verschlüsselt eine PPTX‑Präsentation:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Keep Document Properties Public**

Standardmäßig schließt Aspose.Slides Dokumenteigenschaften in die Präsentationsverschlüsselung ein. Die Eigenschaft [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) steuert dieses Verhalten unabhängig von der Folien‑Inhaltsverschlüsselung. Setzen Sie sie auf `False`, bevor Sie [ProtectionManager.encrypt](https://reference.aspose.com/slides/de/python-net/aspose.slides/protectionmanager/encrypt/) aufrufen, wenn ein Index‑, Klassifizierungs‑, Such‑ oder Dokument‑Management‑System Metadaten ohne das Öffnungspasswort lesen muss.

Das folgende Beispiel erstellt eine verschlüsselte PPTX‑Präsentation, lässt dabei jedoch die integrierten Dokumenteigenschaften öffentlich:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    properties = presentation.document_properties
    properties.author = "Contoso Knowledge Management"
    properties.title = "Quarterly Product Roadmap"
    properties.keywords = "roadmap, planning, internal"

    presentation.slides[0].name = "Encrypted presentation content"
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", slides.export.SaveFormat.PPTX)
```

Das Setzen von `encrypt_document_properties` auf `False` macht nicht Folien, Master, Layouts, Formen, Medien oder anderen Präsentationsinhalt öffentlich. Es betrifft ausschließlich die Dokumenteigenschaften. Um diese Eigenschaften zu lesen, ohne den verschlüsselten Inhalt zu laden, siehe [Manage Presentation Properties](/slides/de/python-net/presentation-properties/).

## **Load an Encrypted Presentation**

Setzen Sie [LoadOptions.password](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/password/) auf das Öffnungspasswort und übergeben Sie die Optionen beim Laden an [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/). Das Laden schlägt fehl, wenn ein Öffnungspasswort erforderlich, das angegebene Passwort jedoch fehlt oder falsch ist.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Arbeiten mit der entschlüsselten Präsentation.
    pass
```

## **Remove Encryption from a Presentation**

Laden Sie die Präsentation mit ihrem Öffnungspasswort, rufen Sie [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/de/python-net/aspose.slides/protectionmanager/remove_encryption/) auf und speichern Sie das Ergebnis. Die gespeicherte Präsentation kann dann ohne Passwort geladen werden.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Validate an Opening Password Before Loading**

Verwenden Sie [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationfactory/get_presentation_info/), um [PresentationInfo](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/) zu erhalten, ohne eine vollständige Präsentationsinstanz zu erstellen. Prüfen Sie [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/is_password_protected/), bevor Sie ein Passwort anfordern oder validieren. Wenn ein Schutz vorhanden ist, validieren Sie den angegebenen Wert mit [PresentationInfo.check_password](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/check_password/).

### **File-Path Workflow**

Das folgende Beispiel validiert ein Öffnungspasswort für eine PPTX‑Datei, übergibt den validierten Wert an [LoadOptions.password](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/password/) und lädt anschließend die vollständige Präsentation:

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **Stream Workflow**

Die Stream‑Überladung von [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationfactory/get_presentation_info/) bietet denselben Workflow. Setzen Sie die Position eines seek‑fähigen Streams zurück, bevor Sie die vollständige Präsentation aus diesem Stream laden.

Das folgende Beispiel verwendet eine PPT‑Datei:

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **CheckPassword Return Values**

[PresentationInfo.check_password](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/check_password/) gibt `True` zurück, nur wenn die Präsentation ein Öffnungspasswort hat und das angegebene Passwort korrekt ist. Es gibt `False` in den folgenden Fällen zurück:

- Das Passwort ist falsch.
- Die Präsentation hat kein Öffnungspasswort.
- Das angegebene Passwort ist `None` oder leer.

Das Verhalten ist für PPT‑ und PPTX‑Präsentationen identisch.

## **Check Whether a Loaded Presentation Is Encrypted**

Nachdem Sie eine Präsentation mit dem korrekten Passwort geladen haben, prüfen Sie [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/de/python-net/aspose.slides/protectionmanager/is_encrypted/), um zu bestätigen, dass die Quellpräsentation verschlüsselt war. Um den Öffnungspasswort‑Schutz vor dem Laden zu erkennen, verwenden Sie `PresentationInfo.is_password_protected` wie oben beschrieben.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Security Recommendations**

{{% alert color="warning" title="Security" %}}
Loggen Sie keine Öffnungspasswörter und fügen Sie sie nicht in Diagnosemeldungen ein. Vermeiden Sie unnötige wiederholte Validierungsversuche, halten Sie Passwörter nur so lange im Speicher wie nötig und verwenden Sie ein erfolgreiches Validierungsergebnis erneut, wenn die Präsentation sofort geladen wird.

Öffentliche Dokumenteigenschaften können Autorennamen, Titel, Betreff, Schlüsselwörter, Unternehmensinformationen, Kommentare und benutzerdefinierte Werte preisgeben, obwohl der Präsentationsinhalt verschlüsselt ist. Verschlüsseln Sie sensible Metadaten zusammen mit der Präsentation. Das Offenlassen von Eigenschaften sollte eine bewusste Entscheidung sein, die nur getroffen wird, wenn Systeme die Datei ohne Öffnungspasswort indexieren, klassifizieren, durchsuchen oder verwalten müssen.
{{% /alert %}}

## **Password-Protect a Presentation Online**

1. Öffnen Sie die Anwendung [Aspose.Slides Lock](https://products.aspose.app/slides/de/lock).
1. Wählen Sie die Präsentation aus oder laden Sie sie hoch.
1. Geben Sie ein Passwort für den Ansichtsschutz ein.
1. Optional geben Sie ein separates Passwort für den Bearbeitungsschutz ein.
1. Wenden Sie den Schutz an und laden Sie die resultierende Datei herunter.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/de/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/de/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**What is the difference between an opening password and a write-protection password?**

Ein Öffnungspasswort verschlüsselt die Präsentation und ist zum Laden des Inhalts erforderlich. Ein Schreibschutz‑Passwort beschränkt die Bearbeitung, ohne den Inhalt zu verschlüsseln.

**Can I validate an opening password without loading all slides?**

Ja. Holen Sie Präsentationsinformationen, prüfen Sie, ob ein Öffnungspasswort‑Schutz vorhanden ist, und validieren Sie das Passwort, bevor Sie eine vollständige Präsentationsinstanz erstellen.

**Can an application read metadata without the opening password?**

Ja, jedoch nur, wenn die Präsentation mit `encrypt_document_properties` auf `False` verschlüsselt wurde. Die Anwendung muss dann den Modus zum Laden nur der Dokumenteigenschaften verwenden, der in [Manage Presentation Properties](/slides/de/python-net/presentation-properties/) beschrieben ist.

**Do the password-checking workflows support both PPT and PPTX?**

Ja. Dateipfad‑ und streambasierte Passworterkennung sowie -validierung verhalten sich für PPT‑ und PPTX‑Präsentationen gleich.