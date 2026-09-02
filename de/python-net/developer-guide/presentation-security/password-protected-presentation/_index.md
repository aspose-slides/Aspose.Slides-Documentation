---
title: Präsentationen in Python passwortschützen
linktitle: Passwortschutz
type: docs
weight: 20
url: /de/python-net/password-protected-presentation/
keywords:
- Passwortgeschützte Präsentation
- Öffnungskennwort
- PowerPoint verschlüsseln
- PowerPoint entschlüsseln
- Präsentationskennwort validieren
- Präsentationskennwort prüfen
- Verschlüsselte Präsentation öffnen
- Verschlüsselung entfernen
- PowerPoint
- PPT
- PPTX
- Präsentation
- Python
- Aspose.Slides
description: "Verschlüsseln, erkennen, validieren, öffnen und entschlüsseln Sie passwortgeschützte PowerPoint-PPT- und PPTX-Präsentationen in Python mit Aspose.Slides."
---
## **Übersicht**

Ein Öffnungskennwort verschlüsselt eine Präsentation. Das korrekte Kennwort ist zum Laden und Anzeigen des Präsentationsinhalts erforderlich, sodass dieser Schutz Vertraulichkeit gewährleistet.

Ein Öffnungskennwort unterscheidet sich von einem Schreibschutzkennwort. Der Schreibschutz beschränkt Änderungen, verschlüsselt den Inhalt jedoch nicht und verhindert nicht das Laden der Präsentation. Um Kennwörter für die Modifikation von Präsentationen zu verwalten, siehe [Write-Protect Presentations](/slides/de/python-net/write-protected-presentation/).

Die nachstehenden Workflows gelten für PPT- und PPTX‑Präsentationen. Die Beispiele verwenden beide Formate, wenn ihr datei‑ und streambasierte Verhalten wichtig ist.

## **Eine Präsentation mit einem Öffnungskennwort verschlüsseln**

Verwenden Sie [ProtectionManager.encrypt](https://reference.aspose.com/slides/de/python-net/aspose.slides/protectionmanager/encrypt/), um ein Öffnungskennwort zuzuweisen. Verwenden Sie anschließend [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/save/), um die verschlüsselte Präsentation zu speichern.

Das folgende Beispiel verschlüsselt eine PPTX‑Präsentation:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Eine verschlüsselte Präsentation laden**

Setzen Sie [LoadOptions.password](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/password/) auf das Öffnungskennwort und übergeben Sie die Optionen an [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/), wenn Sie die Datei laden. Das Laden schlägt fehl, wenn ein Öffnungskennwort erforderlich ist, das bereitgestellte Kennwort jedoch fehlt oder falsch ist.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Arbeiten mit der entschlüsselten Präsentation.
    pass
```

## **Verschlüsselung einer Präsentation entfernen**

Laden Sie die Präsentation mit ihrem Öffnungskennwort, rufen Sie [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/de/python-net/aspose.slides/protectionmanager/remove_encryption/) auf und speichern Sie das Ergebnis. Die gespeicherte Präsentation kann anschließend ohne Kennwort geladen werden.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ein Öffnungskennwort vor dem Laden validieren**

Verwenden Sie [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationfactory/get_presentation_info/), um [PresentationInfo](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/) zu erhalten, ohne eine vollständige Präsentationsinstanz zu erstellen. Überprüfen Sie [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/is_password_protected/), bevor Sie ein Kennwort anfordern oder validieren. Wenn Schutz vorhanden ist, validieren Sie den bereitgestellten Wert mit [PresentationInfo.check_password](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/check_password/).

### **Dateipfad‑Workflow**

Das folgende Beispiel validiert ein Öffnungskennwort für eine PPTX‑Datei, übergibt den validierten Wert an [LoadOptions.password](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/password/) und lädt anschließend die komplette Präsentation:

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

### **Stream‑Workflow**

Die Stream‑Überladung von [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationfactory/get_presentation_info/) bietet denselben Workflow. Setzen Sie die Position eines durchsuchbaren Streams zurück, bevor Sie die vollständige Präsentation aus diesem Stream laden.

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

### **Rückgabewerte von CheckPassword**

[PresentationInfo.check_password](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/check_password/) gibt `True` nur zurück, wenn die Präsentation ein Öffnungskennwort besitzt und das bereitgestellte Kennwort korrekt ist. Sie gibt `False` in jedem der folgenden Fälle zurück:

- Das Kennwort ist inkorrekt.
- Die Präsentation hat kein Öffnungskennwort.
- Das bereitgestellte Kennwort ist `None` oder leer.

Das Verhalten ist für PPT‑ und PPTX‑Präsentationen identisch.

## **Überprüfen, ob eine geladene Präsentation verschlüsselt ist**

Nach dem Laden einer Präsentation mit dem korrekten Kennwort prüfen Sie [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/de/python-net/aspose.slides/protectionmanager/is_encrypted/), um zu bestätigen, dass die Quellpräsentation verschlüsselt war. Um den Öffnungskennwortschutz vor dem Laden zu erkennen, verwenden Sie `PresentationInfo.is_password_protected` wie oben gezeigt.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Sicherheits‑Empfehlungen**

{{% alert color="warning" title="Sicherheit" %}}
Protokollieren Sie Öffnungskennwörter nicht und fügen Sie sie nicht in Fehlermeldungen ein. Vermeiden Sie unnötige wiederholte Validierungsversuche, halten Sie Kennwörter nur so lange im Speicher, wie sie benötigt werden, und verwenden Sie ein erfolgreiches Validierungsergebnis erneut, wenn Sie die Präsentation sofort laden.
{{% /alert %}}

## **Eine Präsentation online passwortschützen**

1. Öffnen Sie die Anwendung [Aspose.Slides Lock](https://products.aspose.app/slides/de/lock).
2. Wählen Sie die Präsentation aus oder laden Sie sie hoch.
3. Geben Sie ein Kennwort zum Schutz der Ansicht ein.
4. Geben Sie optional ein separates Kennwort für den Bearbeitungsschutz ein.
5. Wenden Sie den Schutz an und laden Sie die resultierende Datei herunter.

{{% alert color="info" title="Siehe auch" %}}
- [Präsentationen schreibschützen](/slides/de/python-net/write-protected-presentation/)
- [Digitale Signatur in PowerPoint](/slides/de/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einem Öffnungskennwort und einem Schreibschutzkennwort?**

Ein Öffnungskennwort verschlüsselt die Präsentation und ist zum Laden des Inhalts erforderlich. Ein Schreibschutzkennwort beschränkt Änderungen, ohne den Inhalt zu verschlüsseln.

**Kann ich ein Öffnungskennwort validieren, ohne alle Folien zu laden?**

Ja. Holen Sie Präsentationsinformationen, prüfen Sie, ob ein Öffnungskennwortschutz vorhanden ist, und validieren Sie das Kennwort, bevor Sie eine vollständige Präsentationsinstanz erzeugen.

**Unterstützen die Kennwort‑Prüf‑Workflows sowohl PPT als auch PPTX?**

Ja. Die datei‑ und streambasierte Kennworterkennung und -validierung verhalten sich für PPT‑ und PPTX‑Präsentationen gleich.