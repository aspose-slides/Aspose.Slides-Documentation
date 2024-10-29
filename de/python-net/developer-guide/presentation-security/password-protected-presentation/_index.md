---
title: Passwortgeschützte Präsentation
type: docs
weight: 20
url: /de/python-net/password-protected-presentation/
keywords: "PowerPoint sperren, PowerPoint entsperren, PowerPoint schützen, Passwort festlegen, Passwort hinzufügen, PowerPoint verschlüsseln, PowerPoint entschlüsseln, Schreibschutz, PowerPoint-Sicherheit, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Passwortschutz, Verschlüsselung und Sicherheit für PowerPoint in Python"

---

## **Über Passwortschutz**
### **Wie funktioniert der Passwortschutz für Präsentationen?**
Wenn Sie eine Präsentation passwortschützen, bedeutet das, dass Sie ein Passwort festlegen, das bestimmte Einschränkungen für die Präsentation durchsetzt. Um die Einschränkungen zu entfernen, muss das Passwort eingegeben werden. Eine passwortgeschützte Präsentation gilt als gesperrt.

Typischerweise können Sie ein Passwort festlegen, um diese Einschränkungen für eine Präsentation durchzusetzen:

- **Änderung**

  Wenn Sie nur bestimmten Benutzern erlauben möchten, Ihre Präsentation zu ändern, können Sie eine Änderungsbeschränkung festlegen. Die Einschränkung verhindert hier, dass Personen Dinge in Ihrer Präsentation modifizieren, ändern oder kopieren (es sei denn, sie geben das Passwort ein).

  In diesem Fall kann ein Benutzer jedoch, auch ohne das Passwort, auf Ihr Dokument zugreifen und es öffnen. In diesem schreibgeschützten Modus kann der Benutzer den Inhalt oder Dinge—Hyperlinks, Animationen, Effekte und andere—innerhalb Ihrer Präsentation ansehen, aber er kann keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

  Wenn Sie nur bestimmten Benutzern erlauben möchten, Ihre Präsentation zu öffnen, können Sie eine Öffnungsbeschränkung festlegen. Die Einschränkung verhindert hier, dass Personen den Inhalt Ihrer Präsentation überhaupt ansehen (es sei denn, sie geben das Passwort ein).

  Technisch verhindert die Öffnungsbeschränkung auch, dass Benutzer Ihre Präsentationen ändern: Wenn Personen eine Präsentation nicht öffnen können, können sie sie nicht ändern oder modifizieren.

  **Hinweis**: Wenn Sie eine Präsentation passwortschützen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## So schützen Sie eine Präsentation online mit einem Passwort

1. Gehen Sie zu unserer [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) Seite.

   ![todo:image_alt_text](slides-lock.png)

2. Klicken Sie auf **Dateien ziehen oder hochladen**.

3. Wählen Sie die Datei aus, die Sie auf Ihrem Computer passwortschützen möchten.

4. Geben Sie Ihr bevorzugtes Passwort für den Schreibschutz ein; Geben Sie Ihr bevorzugtes Passwort für den Ansichtsschutz ein.

5. Wenn Sie möchten, dass Benutzer Ihre Präsentation als endgültige Kopie sehen, markieren Sie das Kontrollkästchen **Als endgültig markieren**.

6. Klicken Sie auf **JETZT SCHÜTZEN**.

7. Klicken Sie auf **JETZT HERUNTERLADEN**.

## **Passwortschutz für Präsentationen in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Passwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in diesen Formaten:

- PPTX und PPT - Microsoft PowerPoint-Präsentation
- ODP - OpenDocument-Präsentation
- OTP - OpenDocument-Präsentationsvorlage

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht es Ihnen, Passwortschutz für Präsentationen zu verwenden, um Änderungen auf folgende Weise zu verhindern:

- Verschlüsselung einer Präsentation
- Festlegen eines Schreibschutzes für eine Präsentation

**Weitere Vorgänge**

Aspose.Slides ermöglicht es Ihnen, weitere Aufgaben im Zusammenhang mit Passwortschutz und Verschlüsselung auf folgende Weise durchzuführen:

- Entziffern einer Präsentation; Öffnen einer verschlüsselten Präsentation
- Entfernen der Verschlüsselung; Deaktivieren des Passwortschutzes
- Entfernen des Schreibschutzes von einer Präsentation
- Abrufen der Eigenschaften einer verschlüsselten Präsentation
- Überprüfen, ob eine Präsentation verschlüsselt ist
- Überprüfen, ob eine Präsentation passwortgeschützt ist.

## **Verschlüsseln einer Präsentation**

Sie können eine Präsentation verschlüsseln, indem Sie ein Passwort festlegen. Um die gesperrte Präsentation zu ändern, muss der Benutzer das Passwort angeben.

Um eine Präsentation zu verschlüsseln oder passwortzu schützen, müssen Sie die Methode encrypt (von [ProtectionManager](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)) verwenden, um ein Passwort für die Präsentation festzulegen. Sie übergeben das Passwort an die encrypt-Methode und verwenden die save-Methode, um die nun verschlüsselte Präsentation zu speichern.

Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation verschlüsseln:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Schreibschutz für eine Präsentation festlegen**

Sie können eine Markierung hinzufügen, die "Nicht ändern" angibt, zu einer Präsentation. Auf diese Weise können Sie den Benutzern mitteilen, dass Sie möchten, dass sie keine Änderungen an der Präsentation vornehmen.

**Hinweis**: Der Schreibschutzprozess verschlüsselt die Präsentation nicht. Daher können Benutzer—wenn sie das wirklich wollen—die Präsentation ändern, aber um die Änderungen zu speichern, müssen sie eine Präsentation mit einem anderen Namen erstellen.

Um einen Schreibschutz festzulegen, müssen Sie die Methode setWriteProtection verwenden. Dieser Beispielcode zeigt Ihnen, wie Sie einen Schreibschutz für eine Präsentation festlegen:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation**

Aspose.Slides ermöglicht es Ihnen, eine verschlüsselte Datei zu laden, indem Sie ihr Passwort übergeben. Um eine Präsentation zu entschlüsseln, müssen Sie die Methode [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) ohne Parameter aufrufen. Dann müssen Sie das richtige Passwort eingeben, um die Präsentation zu laden.

Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation entschlüsseln:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Entfernen der Verschlüsselung; Deaktivieren des Passwortschutzes**

Sie können die Verschlüsselung oder den Passwortschutz für eine Präsentation entfernen. Auf diese Weise können Benutzer auf die Präsentation zugreifen oder sie ohne Einschränkungen ändern.

Um die Verschlüsselung oder den Passwortschutz zu entfernen, müssen Sie die Methode [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) aufrufen. Dieser Beispielcode zeigt Ihnen, wie Sie die Verschlüsselung von einer Präsentation entfernen:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Entfernen des Schreibschutzes von einer Präsentation**

Sie können Aspose.Slides verwenden, um den Schreibschutz, der auf einer Präsentationsdatei verwendet wird, zu entfernen. Auf diese Weise können Benutzer nach Belieben Änderungen vornehmen—und sie erhalten keine Warnungen, wenn sie solche Aufgaben durchführen.

Sie können den Schreibschutz von einer Präsentation entfernen, indem Sie die Methode [remove_write_protection](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) verwenden. Dieser Beispielcode zeigt Ihnen, wie Sie den Schreibschutz von einer Präsentation entfernen:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Abrufen der Eigenschaften einer verschlüsselten Präsentation**

Typischerweise haben Benutzer Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder passwortgeschützten Präsentation zu erhalten. Aspose.Slides bietet jedoch einen Mechanismus, der es Ihnen ermöglicht, eine Präsentation passwortzuschützen und gleichzeitig den Benutzern den Zugang zu den Eigenschaften dieser Präsentation zu ermöglichen.

**Hinweis**: Wenn Aspose.Slides eine Präsentation verschlüsselt, werden die Dokumenteigenschaften der Präsentation standardmäßig ebenfalls passwortgeschützt. Aber wenn Sie die Eigenschaften der Präsentation zugänglich machen möchten (auch nachdem die Präsentation verschlüsselt wurde), erlaubt Ihnen Aspose.Slides genau das.

Wenn Sie möchten, dass Benutzer die Möglichkeit behalten, auf die Eigenschaften einer von Ihnen verschlüsselten Präsentation zuzugreifen, können Sie die [EncryptDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) Eigenschaft auf `True` setzen. Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation verschlüsseln, während Sie den Benutzern ermöglichen, auf ihre Dokumenteigenschaften zuzugreifen:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```

## **Überprüfen, ob eine Präsentation passwortgeschützt ist, bevor Sie sie laden**

Bevor Sie eine Präsentation laden, möchten Sie möglicherweise überprüfen und bestätigen, dass die Präsentation nicht mit einem Passwort geschützt ist. Auf diese Weise vermeiden Sie Fehler und ähnliche Probleme, die auftreten, wenn eine passwortgeschützte Präsentation ohne ihr Passwort geladen wird.

Dieser Python-Code zeigt Ihnen, wie Sie eine Präsentation untersuchen, um zu sehen, ob sie passwortgeschützt ist (ohne die Präsentation selbst zu laden):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("Die Präsentation ist passwortgeschützt: " + str(presentationInfo.is_password_protected))
```

## **Überprüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht es Ihnen, zu überprüfen, ob eine Präsentation verschlüsselt ist. Um diese Aufgabe auszuführen, können Sie die [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) Eigenschaft verwenden, die `True` zurückgibt, wenn die Präsentation verschlüsselt ist, oder `False`, wenn die Präsentation nicht verschlüsselt ist.

Dieser Beispielcode zeigt Ihnen, wie Sie überprüfen, ob eine Präsentation verschlüsselt ist:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Überprüfen, ob eine Präsentation schreibgeschützt ist**

Aspose.Slides ermöglicht es Ihnen, zu überprüfen, ob eine Präsentation schreibgeschützt ist. Um diese Aufgabe auszuführen, können Sie die [is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) Eigenschaft verwenden, die `True` zurückgibt, wenn die Präsentation schreibgeschützt ist, oder `False`, wenn die Präsentation nicht schreibgeschützt ist.

Dieser Beispielcode zeigt Ihnen, wie Sie überprüfen, ob eine Präsentation schreibgeschützt ist:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Validieren oder Bestätigen, dass ein bestimmtes Passwort zum Schutz einer Präsentation verwendet wurde**

Sie möchten möglicherweise überprüfen und bestätigen, dass ein bestimmtes Passwort verwendet wurde, um ein Präsentationsdokument zu schützen. Aspose.Slides bietet Ihnen die Möglichkeit, ein Passwort zu validieren.

Dieser Beispielcode zeigt Ihnen, wie Sie ein Passwort validieren:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # Überprüfen, ob "pass" übereinstimmt
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Es gibt `True` zurück, wenn die Präsentation mit dem angegebenen Passwort verschlüsselt wurde. Andernfalls gibt es `False` zurück.

{{% alert color="primary" title="Siehe auch" %}} 
- [Digitale Signatur in PowerPoint](/slides/de/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}