---
title: Sichere Präsentationen mit Passwörtern in Python
linktitle: Passwortschutz
type: docs
weight: 20
url: /de/python-net/password-protected-presentation/
keywords:
- PowerPoint sperren
- Präsentation sperren
- PowerPoint entsperren
- Präsentation entsperren
- PowerPoint schützen
- Präsentation schützen
- Passwort festlegen
- Passwort hinzufügen
- PowerPoint verschlüsseln
- Präsentation verschlüsseln
- PowerPoint entschlüsseln
- Präsentation entschlüsseln
- Schreibschutz
- PowerPoint Sicherheit
- Präsentationssicherheit
- Passwort entfernen
- Schutz entfernen
- Verschlüsselung entfernen
- Passwort deaktivieren
- Schutz deaktivieren
- Schreibschutz entfernen
- PowerPoint Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen mühelos mit Passwortschutz sperren und entsperren können, mithilfe von Aspose.Slides für Python über .NET. Steigern Sie Ihre Produktivität und sichern Sie Ihre Präsentationen mit unserer Schritt‑für‑Schritt‑Anleitung."
---

## **Über Passwortschutz**
### **Wie funktioniert der Passwortschutz für Präsentationen?**
Wenn Sie eine Präsentation mit einem Passwort schützen, legen Sie ein Passwort fest, das bestimmte Einschränkungen für die Präsentation durchsetzt. Um die Einschränkungen zu entfernen, muss das Passwort eingegeben werden. Eine passwortgeschützte Präsentation gilt als gesperrte Präsentation.

In der Regel können Sie ein Passwort festlegen, um diese Einschränkungen für eine Präsentation durchzusetzen:

- **Änderungen**

  Wenn Sie möchten, dass nur bestimmte Benutzer Ihre Präsentation ändern dürfen, können Sie eine Änderungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen Inhalte in Ihrer Präsentation ändern, verändern oder kopieren (es sei denn, sie geben das Passwort an).

  In diesem Fall kann ein Benutzer jedoch Ihr Dokument öffnen und darauf zugreifen, selbst wenn er das Passwort nicht kennt. Im schreibgeschützten Modus kann der Benutzer die Inhalte – Hyperlinks, Animationen, Effekte und weitere – Ihrer Präsentation ansehen, jedoch keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

  Wenn Sie möchten, dass nur bestimmte Benutzer Ihre Präsentation öffnen dürfen, können Sie eine Öffnungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen überhaupt den Inhalt Ihrer Präsentation sehen (es sei denn, sie geben das Passwort an).

  Technisch verhindert die Öffnungsbeschränkung zudem, dass Benutzer Ihre Präsentationen ändern: Wenn Personen eine Präsentation nicht öffnen können, können sie sie nicht ändern oder modifizieren.  
  
  **Hinweis**: Wenn Sie eine Präsentation mit Passwort schützen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## Wie Sie eine Präsentation online mit Passwort schützen

1. Rufen Sie unsere Seite [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) auf.  

   ![todo:image_alt_text](slides-lock.png)

2. Klicken Sie auf **Dateien ziehen oder hochladen**.

3. Wählen Sie die Datei, die Sie mit einem Passwort schützen möchten, auf Ihrem Computer aus.

4. Geben Sie Ihr gewünschtes Passwort für den Bearbeitungsschutz ein; geben Sie Ihr gewünschtes Passwort für den Ansichtsschutz ein.

5. Wenn Sie möchten, dass Benutzer Ihre Präsentation als Endkopie sehen, aktivieren Sie das Kontrollkästchen **Als endgültig markieren**.

6. Klicken Sie auf **JETZT SCHÜTZEN**.

7. Klicken Sie auf **JETZT HERUNTERLADEN**.

## **Passwortschutz für Präsentationen in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Passwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in folgenden Formaten:

- PPTX und PPT – Microsoft PowerPoint-Präsentation
- ODP – OpenDocument-Präsentation
- OTP – OpenDocument-Präsentationsvorlage

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht Ihnen, Passwortschutz für Präsentationen zu verwenden, um Änderungen wie folgt zu verhindern:

- Verschlüsseln einer Präsentation
- Festlegen eines Schreibschutzes für eine Präsentation

**Weitere Vorgänge**

Aspose.Slides ermöglicht Ihnen, weitere Aufgaben im Zusammenhang mit Passwortschutz und Verschlüsselung wie folgt auszuführen:

- Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation
- Entfernen der Verschlüsselung; Deaktivieren des Passwortschutzes
- Entfernen des Schreibschutzes von einer Präsentation
- Abrufen der Eigenschaften einer verschlüsselten Präsentation
- Prüfen, ob eine Präsentation verschlüsselt ist
- Prüfen, ob eine Präsentation passwortgeschützt ist.

## **Eine Präsentation verschlüsseln**

Sie können eine Präsentation verschlüsseln, indem Sie ein Passwort festlegen. Um die gesperrte Präsentation zu ändern, muss ein Benutzer das Passwort eingeben.

Um eine Präsentation zu verschlüsseln oder mit Passwort zu schützen, müssen Sie die `encrypt`‑Methode (aus [ProtectionManager](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)) verwenden, um ein Passwort für die Präsentation festzulegen. Sie übergeben das Passwort an die `encrypt`‑Methode und verwenden die `save`‑Methode, um die jetzt verschlüsselte Präsentation zu speichern.

Der folgende Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Schreibschutz für eine Präsentation festlegen**

Sie können einer Präsentation einen Hinweis „Nicht ändern“ hinzufügen. Auf diese Weise können Sie Benutzern mitteilen, dass Sie nicht möchten, dass sie Änderungen an der Präsentation vornehmen.

**Hinweis**: Der Schreibschutzvorgang verschlüsselt die Präsentation nicht. Daher können Benutzer – falls sie dies wünschen – die Präsentation ändern, aber um die Änderungen zu speichern, müssen sie die Präsentation unter einem anderen Namen speichern.

Um einen Schreibschutz festzulegen, müssen Sie die Methode `setWriteProtection` verwenden. Der folgende Beispielcode zeigt, wie Sie einer Präsentation einen Schreibschutz zuweisen:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Eine Präsentation entschlüsseln; Öffnen einer verschlüsselten Präsentation**

Aspose.Slides ermöglicht Ihnen, eine verschlüsselte Datei zu laden, indem Sie ihr Passwort übergeben. Um eine Präsentation zu entschlüsseln, müssen Sie die Methode [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) ohne Parameter aufrufen. Anschließend müssen Sie das korrekte Passwort eingeben, um die Präsentation zu laden.

Der folgende Beispielcode zeigt, wie Sie eine Präsentation entschlüsseln:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Verschlüsselung entfernen; Passwortschutz deaktivieren**

Sie können die Verschlüsselung oder den Passwortschutz einer Präsentation entfernen. Dadurch können Benutzer die Präsentation ohne Einschränkungen öffnen oder ändern.

Um die Verschlüsselung oder den Passwortschutz zu entfernen, müssen Sie die Methode [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) aufrufen. Der folgende Beispielcode zeigt, wie Sie die Verschlüsselung aus einer Präsentation entfernen:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Schreibschutz von einer Präsentation entfernen**

Sie können mithilfe von Aspose.Slides den Schreibschutz einer Präsentationsdatei entfernen. Auf diese Weise können Benutzer nach Belieben Änderungen vornehmen – und erhalten keine Warnungen mehr, wenn sie solche Vorgänge ausführen.

Sie können den Schreibschutz einer Präsentation entfernen, indem Sie die Methode [remove_write_protection](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) verwenden. Der folgende Beispielcode zeigt, wie Sie den Schreibschutz einer Präsentation entfernen:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Eigenschaften einer verschlüsselten Präsentation abrufen**

In der Regel haben Benutzer Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder passwortgeschützten Präsentation abzurufen. Aspose.Slides bietet jedoch einen Mechanismus, mit dem Sie eine Präsentation mit Passwort schützen können, während Sie gleichzeitig den Benutzern ermöglichen, die Eigenschaften dieser Präsentation zu sehen.

**Hinweis**: Wenn Aspose.Slides eine Präsentation verschlüsselt, werden die Dokumenteigenschaften der Präsentation standardmäßig ebenfalls passwortgeschützt. Wenn Sie jedoch möchten, dass die Eigenschaften der Präsentation auch nach der Verschlüsselung zugänglich bleiben, erlaubt Ihnen Aspose.Slides genau das.

Wenn Sie möchten, dass Benutzer die Möglichkeit behalten, die Eigenschaften einer von Ihnen verschlüsselten Präsentation abzurufen, können Sie die Eigenschaft [EncryptDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) auf `True` setzen. Der folgende Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln und gleichzeitig den Benutzern den Zugriff auf die Dokumenteigenschaften ermöglichen:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```

## **Prüfen, ob eine Präsentation vor dem Laden passwortgeschützt ist**

Bevor Sie eine Präsentation laden, möchten Sie möglicherweise prüfen und bestätigen, dass die Präsentation nicht mit einem Passwort geschützt ist. So vermeiden Sie Fehler und ähnliche Probleme, die auftreten, wenn eine passwortgeschützte Präsentation ohne das Passwort geladen wird.

Der folgende Python‑Code zeigt, wie Sie eine Präsentation prüfen können, ob sie passwortgeschützt ist (ohne die Präsentation selbst zu laden):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("Die Präsentation ist passwortgeschützt: " + str(presentationInfo.is_password_protected))
```

## **Prüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht Ihnen, zu prüfen, ob eine Präsentation verschlüsselt ist. Dazu können Sie die Eigenschaft [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) verwenden, die `True` zurückgibt, wenn die Präsentation verschlüsselt ist, bzw. `False`, wenn sie nicht verschlüsselt ist.

Der folgende Beispielcode zeigt, wie Sie prüfen können, ob eine Präsentation verschlüsselt ist:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Prüfen, ob eine Präsentation schreibgeschützt ist**

Aspose.Slides ermöglicht Ihnen, zu prüfen, ob eine Präsentation schreibgeschützt ist. Dazu können Sie die Eigenschaft [is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) verwenden, die `True` zurückgibt, wenn die Präsentation schreibgeschützt ist, bzw. `False`, wenn sie nicht schreibgeschützt ist.

Der folgende Beispielcode zeigt, wie Sie prüfen können, ob eine Präsentation schreibgeschützt ist:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Validieren oder Bestätigen, dass ein bestimmtes Passwort zum Schutz einer Präsentation verwendet wurde**

Möglicherweise möchten Sie prüfen und bestätigen, dass ein bestimmtes Passwort zum Schutz eines Präsentationsdokuments verwendet wurde. Aspose.Slides stellt die Mittel bereit, ein Passwort zu validieren.

Der folgende Beispielcode zeigt, wie Sie ein Passwort validieren:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # prüfen, ob "pass" mit dem Passwort übereinstimmt
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Er gibt `True` zurück, wenn die Präsentation mit dem angegebenen Passwort verschlüsselt wurde. Andernfalls gibt er `False` zurück.

{{% alert color="primary" title="Siehe auch" %}} 
- [Digitale Signatur in PowerPoint](/slides/de/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welche Verschlüsselungsmethoden werden von Aspose.Slides unterstützt?**

Aspose.Slides unterstützt moderne Verschlüsselungsmethoden, einschließlich AES‑basierter Algorithmen, und sorgt so für ein hohes Maß an Datensicherheit für Ihre Präsentationen.

**Was passiert, wenn ein falsches Passwort beim Versuch, eine Präsentation zu öffnen, eingegeben wird?**

Es wird eine Ausnahme ausgelöst, wenn ein falsches Passwort verwendet wird, wodurch Sie darüber informiert werden, dass der Zugriff auf die Präsentation verweigert wird. Dies hilft, unbefugten Zugriff zu verhindern und den Präsentationsinhalt zu schützen.

**Gibt es Leistungseinbußen bei der Arbeit mit passwortgeschützten Präsentationen?**

Der Verschlüsselungs‑ und Entschlüsselungsprozess kann beim Öffnen und Speichern einen leichten Overhead erzeugen. In den meisten Fällen ist dieser Leistungseinfluss jedoch minimal und beeinträchtigt die Gesamtverarbeitungszeit Ihrer Präsentationsaufgaben nicht.