---
title: Präsentationen mit Passwörtern mit Python sichern
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
- PowerPoint-Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen, die mit einem Passwort geschützt sind, mühelos mit Aspose.Slides für Python über .NET sperren und entsperren können. Steigern Sie Ihre Produktivität und sichern Sie Ihre Präsentationen mit unserer Schritt-für-Schritt-Anleitung."
---

## **Über den Passwortschutz**
### **Wie funktioniert der Passwortschutz für Präsentationen?**
Wenn Sie eine Präsentation mit einem Passwort schützen, legen Sie ein Passwort fest, das bestimmte Einschränkungen für die Präsentation erzwingt. Um die Einschränkungen zu entfernen, muss das Passwort eingegeben werden. Eine passwortgeschützte Präsentation gilt als gesperrte Präsentation.

Typischerweise können Sie ein Passwort festlegen, um diese Einschränkungen für eine Präsentation durchzusetzen:

- **Änderung**

  Wenn nur bestimmte Benutzer Ihre Präsentation ändern dürfen, können Sie eine Änderungsbeschränkung setzen. Diese Beschränkung verhindert, dass Personen die Präsentation ändern, bearbeiten oder Inhalte kopieren (es sei denn, sie geben das Passwort ein).

  In diesem Fall kann ein Benutzer das Dokument jedoch öffnen und darauf zugreifen, auch ohne das Passwort. Im Nur-Lese‑Modus kann er den Inhalt – Hyperlinks, Animationen, Effekte und andere Elemente – ansehen, aber keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

  Wenn nur bestimmte Benutzer die Präsentation öffnen dürfen, können Sie eine Öffnungsbeschränkung setzen. Diese Beschränkung verhindert, dass Personen überhaupt den Inhalt der Präsentation sehen (es sei denn, sie geben das Passwort ein).

  Technisch verhindert die Öffnungsbeschränkung auch Änderungen: Wenn Personen eine Präsentation nicht öffnen können, können sie sie nicht ändern.

  **Hinweis**: Wenn Sie eine Präsentation mit einem Passwort schützen, um das Öffnen zu verhindern, wird die Datei verschlüsselt.

## Wie man eine Präsentation online passwortschützt

1. Rufen Sie unsere Seite [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) auf.  

   ![todo:image_alt_text](slides-lock.png)

2. Klicken Sie auf **Drop or upload your files**.

3. Wählen Sie die Datei aus, die Sie auf Ihrem Computer passwortschützen möchten.

4. Geben Sie Ihr bevorzugtes Passwort für den Schreibschutz ein; geben Sie Ihr bevorzugtes Passwort für den Leseschutz ein.

5. Wenn Sie möchten, dass Benutzer Ihre Präsentation als Endkopie sehen, aktivieren Sie das Kontrollkästchen **Mark as final**.

6. Klicken Sie auf **PROTECT NOW.** 

7. Klicken Sie auf **DOWNLOAD NOW.**

## **Passwortschutz für Präsentationen in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Passwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in folgenden Formaten:

- PPTX und PPT – Microsoft PowerPoint Presentation  
- ODP – OpenDocument Presentation  
- OTP – OpenDocument Presentation Template  

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht den Passwortschutz von Präsentationen, um Änderungen auf folgende Weise zu verhindern:

- Verschlüsseln einer Präsentation  
- Setzen eines Schreibschutzes für eine Präsentation  

**Weitere Vorgänge**

Aspose.Slides ermöglicht weitere Aufgaben im Zusammenhang mit Passwortschutz und Verschlüsselung:

- Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation  
- Entfernen der Verschlüsselung; Deaktivieren des Passwortschutzes  
- Entfernen des Schreibschutzes von einer Präsentation  
- Abrufen der Eigenschaften einer verschlüsselten Präsentation  
- Prüfen, ob eine Präsentation verschlüsselt ist  
- Prüfen, ob eine Präsentation passwortgeschützt ist  

## **Verschlüsseln einer Präsentation**

Sie können eine Präsentation verschlüsseln, indem Sie ein Passwort festlegen. Um die gesperrte Präsentation zu ändern, muss der Benutzer das Passwort eingeben.

Zum Verschlüsseln oder zum Passwortschutz einer Präsentation verwenden Sie die `encrypt`‑Methode (aus [ProtectionManager](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)), um ein Passwort für die Präsentation zu setzen. Sie übergeben das Passwort an die `encrypt`‑Methode und verwenden anschließend die `save`‑Methode, um die nun verschlüsselte Präsentation zu speichern.

Dieses Beispiel zeigt, wie Sie eine Präsentation verschlüsseln:
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```


## **Schreibschutz für eine Präsentation setzen**

Sie können einer Präsentation einen Hinweis „Do not modify“ hinzufügen. Auf diese Weise teilen Sie den Benutzern mit, dass sie die Präsentation nicht ändern sollen.

**Hinweis**: Der Schreibschutzvorgang verschlüsselt die Präsentation nicht. Daher können Benutzer – falls gewünscht – die Präsentation ändern, müssen jedoch zum Speichern der Änderungen einen anderen Dateinamen wählen.

Um einen Schreibschutz zu setzen, verwenden Sie die `setWriteProtection`‑Methode. Dieses Beispiel zeigt, wie Sie einen Schreibschutz für eine Präsentation setzen:
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```


## **Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation**

Aspose.Slides ermöglicht das Laden einer verschlüsselten Datei, indem das Passwort übergeben wird. Zum Entschlüsseln einer Präsentation rufen Sie die [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)‑Methode ohne Parameter auf. Anschließend geben Sie das korrekte Passwort ein, um die Präsentation zu laden.

Dieses Beispiel zeigt, wie Sie eine Präsentation entschlüsseln:
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```


## **Entfernen der Verschlüsselung; Deaktivieren des Passwortschutzes**

Sie können die Verschlüsselung oder den Passwortschutz einer Präsentation entfernen. Damit können Benutzer die Präsentation ohne Einschränkungen öffnen oder ändern.

Zum Entfernen der Verschlüsselung bzw. des Passwortschutzes rufen Sie die [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)‑Methode auf. Dieses Beispiel zeigt, wie Sie die Verschlüsselung einer Präsentation entfernen:
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```


## **Entfernen des Schreibschutzes von einer Präsentation**

Mit Aspose.Slides können Sie den Schreibschutz einer Präsentationsdatei entfernen. Dann können Benutzer die Datei nach Belieben ändern, ohne dass Warnungen erscheinen.

Sie entfernen den Schreibschutz mit der [remove_write_protection](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)‑Methode. Dieses Beispiel zeigt, wie Sie den Schreibschutz entfernen:
```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```


## **Abrufen der Eigenschaften einer verschlüsselten Präsentation**

Benutzer haben häufig Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder passwortgeschützten Präsentation zu erhalten. Aspose.Slides bietet jedoch einen Mechanismus, mit dem Sie eine Präsentation passwortschützen und gleichzeitig die Möglichkeit für Benutzer erhalten, die Eigenschaften abzurufen.

**Hinweis**: Wenn Aspose.Slides eine Präsentation verschlüsselt, werden die Dokumenteigenschaften standardmäßig ebenfalls passwortgeschützt. Wenn Sie jedoch möchten, dass die Eigenschaften auch nach der Verschlüsselung zugänglich bleiben, können Sie das `EncryptDocumentProperties`‑Attribut auf `True` setzen. Dieses Beispiel zeigt, wie Sie eine Präsentation verschlüsseln und gleichzeitig den Zugriff auf die Dokumenteigenschaften ermöglichen:
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```


## **Prüfen, ob eine Präsentation vor dem Laden passwortgeschützt ist**

Bevor Sie eine Präsentation laden, möchten Sie möglicherweise prüfen, ob sie bereits mit einem Passwort geschützt ist. So vermeiden Sie Fehler, die beim Laden einer passwortgeschützten Präsentation ohne gültiges Passwort auftreten können.

Dieser Python‑Code zeigt, wie Sie eine Präsentation prüfen, ohne sie zu laden:
```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```


## **Prüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht das Prüfen, ob eine Präsentation verschlüsselt ist. Verwenden Sie dazu die [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)‑Eigenschaft, die `True` zurückgibt, wenn die Präsentation verschlüsselt ist, andernfalls `False`.

Dieses Beispiel zeigt, wie Sie prüfen, ob eine Präsentation verschlüsselt ist:
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```


## **Prüfen, ob eine Präsentation schreibgeschützt ist**

Aspose.Slides ermöglicht das Prüfen, ob eine Präsentation schreibgeschützt ist. Verwenden Sie dazu die [is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)‑Eigenschaft, die `True` zurückgibt, wenn die Präsentation schreibgeschützt ist, andernfalls `False`.

Dieses Beispiel zeigt, wie Sie prüfen, ob eine Präsentation schreibgeschützt ist:
```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```


## **Validieren, ob ein bestimmtes Passwort zum Schutz einer Präsentation verwendet wurde**

Möglicherweise möchten Sie überprüfen, ob ein bestimmtes Passwort zum Schutz einer Präsentationsdatei eingesetzt wurde. Aspose.Slides stellt die Möglichkeit bereit, ein Passwort zu validieren.

Dieses Beispiel zeigt, wie Sie ein Passwort validieren:
```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # prüfen, ob "pass" übereinstimmt
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```


Es gibt `True` zurück, wenn die Präsentation mit dem angegebenen Passwort verschlüsselt wurde, andernfalls `False`.

{{% alert color="primary" title="Siehe auch" %}} 
- [Digital Signature in PowerPoint](/slides/de/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welche Verschlüsselungsmethoden werden von Aspose.Slides unterstützt?**

Aspose.Slides unterstützt moderne Verschlüsselungsmethoden, einschließlich AES‑basierter Algorithmen, und gewährleistet ein hohes Maß an Datensicherheit für Ihre Präsentationen.

**Was passiert, wenn beim Öffnen einer Präsentation ein falsches Passwort eingegeben wird?**

Es wird eine Ausnahme ausgelöst, die anzeigt, dass der Zugriff auf die Präsentation verweigert wird. Dies verhindert unbefugten Zugriff und schützt den Präsentationsinhalt.

**Gibt es Leistungseinbußen bei der Arbeit mit passwortgeschützten Präsentationen?**

Der Vorgang des Verschlüsselns und Entschlüsselns kann beim Öffnen und Speichern einen leichten Overhead verursachen. In den meisten Fällen ist dieser Einfluss minimal und beeinträchtigt die Gesamtverarbeitungszeit Ihrer Präsentationsaufgaben nicht.