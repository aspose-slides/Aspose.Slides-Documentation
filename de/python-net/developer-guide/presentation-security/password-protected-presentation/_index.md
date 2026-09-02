---
title: Präsentationen mit Kennwörtern in Python sichern
linktitle: Kennwortschutz
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
- Kennwort festlegen
- Kennwort hinzufügen
- PowerPoint verschlüsseln
- Präsentation verschlüsseln
- PowerPoint entschlüsseln
- Präsentation entschlüsseln
- Schreibschutz
- PowerPoint Sicherheit
- Präsentationssicherheit
- Kennwort entfernen
- Schutz entfernen
- Verschlüsselung entfernen
- Kennwort deaktivieren
- Schutz deaktivieren
- Schreibschutz entfernen
- PowerPoint Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Python über .NET mühelos kennwortgeschützte PowerPoint- und OpenDocument-Präsentationen sperren und entsperren können. Steigern Sie Ihre Produktivität und sichern Sie Ihre Präsentationen mit unserer Schritt-fuer-Schritt-Anleitung."
---
## **Einleitung**

Wenn Sie eine Präsentation mit einem Kennwort schützen, legen Sie ein Kennwort fest, das bestimmte Einschränkungen für die Präsentation durchsetzt. Um die Einschränkungen zu entfernen, muss das Kennwort eingegeben werden. Eine kennwortgeschützte Präsentation gilt als gesperrte Präsentation.

Typischerweise können Sie ein Kennwort festlegen, um diese Einschränkungen für eine Präsentation durchzusetzen:

- **Änderung**

  Wenn Sie möchten, dass nur bestimmte Benutzer Ihre Präsentation ändern können, können Sie eine Änderungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen Ihre Präsentation ändern, verändern oder Inhalte kopieren (es sei denn, sie geben das Kennwort ein).

  In diesem Fall kann ein Benutzer jedoch ohne Kennwort Ihr Dokument öffnen und anzeigen. Im Nur-Lese‑Modus kann der Benutzer den Inhalt – Hyperlinks, Animationen, Effekte und andere Elemente – in Ihrer Präsentation ansehen, jedoch keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

  Wenn Sie möchten, dass nur bestimmte Benutzer Ihre Präsentation öffnen können, können Sie eine Öffnungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen überhaupt den Inhalt Ihrer Präsentation sehen (es sei denn, sie geben das Kennwort ein).

  Technisch verhindert die Öffnungsbeschränkung auch, dass Benutzer Ihre Präsentationen ändern: Wenn Personen eine Präsentation nicht öffnen können, können sie sie nicht modifizieren oder Änderungen daran vornehmen.  

  **Hinweis**: Wenn Sie eine Präsentation mit einem Kennwort schützen, um ein Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## Wie Sie eine Präsentation online kennwortschützen

1. Gehen Sie zu unserer [**Aspose.Slides Sperren**](https://products.aspose.app/slides/de/lock)‑Seite. 

   ![todo:image_alt_text](slides-lock.png)

2. Klicken Sie auf **Dateien ziehen oder hochladen**.

3. Wählen Sie die Datei aus, die Sie auf Ihrem Computer kennwortschützen möchten. 

4. Geben Sie Ihr gewünschtes Kennwort für den Bearbeitungsschutz ein; geben Sie Ihr gewünschtes Kennwort für den Ansichtsschutz ein. 

5. Wenn Sie möchten, dass Benutzer Ihre Präsentation als endgültige Kopie sehen, aktivieren Sie das Kontrollkästchen **Als final markieren**.

6. Klicken Sie auf **JETZT SCHÜTZEN**. 

7. Klicken Sie auf **JETZT HERUNTERLADEN**.

## **Kennwortschutz für Präsentationen in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Kennwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in diesen Formaten:

- PPTX und PPT – Microsoft PowerPoint‑Präsentation
- ODP – OpenDocument‑Präsentation
- OTP – OpenDocument‑Präsentationsvorlage

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht Ihnen, Kennwortschutz für Präsentationen auf folgende Weise zu verwenden, um Änderungen zu verhindern:

- Verschlüsseln einer Präsentation
- Festlegen eines Schreibschutzes für eine Präsentation

**Weitere Vorgänge**

Aspose.Slides ermöglicht Ihnen weitere Aufgaben im Zusammenhang mit Kennwortschutz und Verschlüsselung:

- Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation
- Entfernen der Verschlüsselung; Deaktivieren des Kennwortschutzes
- Entfernen des Schreibschutzes von einer Präsentation
- Abrufen der Eigenschaften einer verschlüsselten Präsentation
- Prüfen, ob eine Präsentation verschlüsselt ist
- Prüfen, ob eine Präsentation kennwortgeschützt ist.

## **Verschlüsseln einer Präsentation**

Sie können eine Präsentation verschlüsseln, indem Sie ein Kennwort festlegen. Um die gesperrte Präsentation zu ändern, muss ein Benutzer das Kennwort angeben.

Um eine Präsentation zu verschlüsseln oder kennwortzuschützen, verwenden Sie die `encrypt`‑Methode (von [ProtectionManager](https://reference.aspose.com/slides/de/python-net/aspose.slides/protectionmanager/)), um ein Kennwort für die Präsentation festzulegen. Sie übergeben das Kennwort an die `encrypt`‑Methode und verwenden die `save`‑Methode, um die nun verschlüsselte Präsentation zu speichern.

Der folgende Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Festlegen eines Schreibschutzes für eine Präsentation** 

Sie können einer Präsentation einen Hinweis „Nicht ändern“ hinzufügen. Auf diese Weise teilen Sie den Benutzern mit, dass Sie nicht möchten, dass sie Änderungen an der Präsentation vornehmen.

**Hinweis**: Der Schreibschutzvorgang verschlüsselt die Präsentation nicht. Daher können Benutzer – falls sie es wünschen – die Präsentation ändern, aber um die Änderungen zu speichern, müssen sie die Präsentation unter einem anderen Namen speichern.

Um einen Schreibschutz festzulegen, verwenden Sie die `setWriteProtection`‑Methode. Der folgende Beispielcode zeigt, wie Sie einen Schreibschutz für eine Präsentation festlegen:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation**

Aspose.Slides ermöglicht das Laden einer verschlüsselten Datei, indem das Kennwort übergeben wird. Um eine Präsentation zu entschlüsseln, rufen Sie die [remove_encryption](https://reference.aspose.com/slides/de/python-net/aspose.slides/protectionmanager/)‑Methode ohne Parameter auf. Anschließend müssen Sie das richtige Kennwort eingeben, um die Präsentation zu laden.

Der folgende Beispielcode zeigt, wie Sie eine Präsentation entschlüsseln:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Entfernen der Verschlüsselung; Deaktivieren des Kennwortschutzes**

Sie können die Verschlüsselung oder den Kennwortschutz einer Präsentation entfernen. Auf diese Weise können Benutzer die Präsentation ohne Einschränkungen öffnen oder ändern.

Um die Verschlüsselung oder den Kennwortschutz zu entfernen, rufen Sie die [remove_encryption](https://reference.aspose.com/slides/de/python-net/aspose.slides/protectionmanager/)‑Methode auf. Der folgende Beispielcode zeigt, wie Sie die Verschlüsselung aus einer Präsentation entfernen:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Entfernen des Schreibschutzes von einer Präsentation**

Sie können mit Aspose.Slides den Schreibschutz einer Präsentationsdatei entfernen. Auf diese Weise können Benutzer nach Belieben Änderungen vornehmen – und erhalten keine Warnungen mehr, wenn sie solche Vorgänge ausführen.

Sie können den Schreibschutz einer Präsentation entfernen, indem Sie die [remove_write_protection](https://reference.aspose.com/slides/de/python-net/aspose.slides/protectionmanager/)‑Methode verwenden. Der folgende Beispielcode zeigt, wie Sie den Schreibschutz von einer Präsentation entfernen:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Abrufen von Eigenschaften einer verschlüsselten Präsentation**

Typischerweise haben Benutzer Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder kennwortgeschützten Präsentation abzurufen. Aspose.Slides bietet jedoch einen Mechanismus, der es Ihnen ermöglicht, eine Präsentation zu kennwortschützen und gleichzeitig Benutzern den Zugriff auf deren Eigenschaften zu erlauben.

**Hinweis:** Standardmäßig werden beim Verschlüsseln einer Präsentation durch Aspose.Slides die Dokumenteigenschaften ebenfalls kennwortgeschützt. Wenn Sie die Dokumenteigenschaften auch nach der Verschlüsselung zugänglich machen möchten, erlaubt Aspose.Slides genau das.

Wenn Sie möchten, dass Benutzer weiterhin Zugriff auf die Eigenschaften einer verschlüsselten Präsentation haben, setzen Sie die Eigenschaft `encrypt_document_properties` von [ProtectionManager](https://reference.aspose.com/slides/de/python-net/aspose.slides/protectionmanager/) auf `False`. Der folgende Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln und gleichzeitig Benutzern Zugriff auf deren Dokumenteigenschaften gewähren:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("123123")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Nur Dokumenteigenschaften einer verschlüsselten Präsentation laden**

Um die Metadaten einer verschlüsselten Präsentation zu prüfen, ohne ihre Folien oder anderen Inhalte zu laden, erstellen Sie ein [LoadOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/)‑Objekt und setzen Sie [only_load_document_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/only_load_document_properties/) auf `True`. In diesem Modus ignoriert Aspose.Slides das Kennwort und lädt nur die öffentlich zugänglichen Dokumenteigenschaften.

Das folgende Codebeispiel liest integrierte Dokumenteigenschaften und listet benutzerdefinierte Dokumenteigenschaften über [Presentation.document_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/document_properties/) auf:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    document_properties = presentation.document_properties

    # Eingebaute Dokumenteigenschaften lesen.
    print("Title: " + document_properties.title)
    print("Author: " + document_properties.author)

    # Benutzerdefinierte Dokumenteigenschaften auflisten.
    custom_property_count = document_properties.count_of_custom_properties

    for property_index in range(custom_property_count):
        property_name = document_properties.get_custom_property_name(property_index)
        print(property_name)
```

Dieser Workflow funktioniert nur, wenn die Dokumenteigenschaften beim Verschlüsseln der Präsentation unverschlüsselt (öffentlich) gelassen wurden. Sind die Dokumenteigenschaften verschlüsselt, führt das Setzen von `only_load_document_properties` auf `True` zu einer Ausnahme, weil das Kennwort in diesem Modus ignoriert wird. Um verschlüsselte Dokumenteigenschaften zuzugreifen oder die komplette Präsentation einschließlich Folien und anderer Inhalte zu laden, geben Sie den korrekten `password`‑Wert in [LoadOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/) an.

## **Prüfen, ob eine Präsentation kennwortgeschützt ist, bevor sie geladen wird**

Bevor Sie eine Präsentation laden, möchten Sie möglicherweise prüfen, ob die Präsentation nicht mit einem Kennwort geschützt ist. Auf diese Weise können Sie Fehler und ähnliche Probleme vermeiden, die auftreten, wenn eine kennwortgeschützte Präsentation ohne Kennwort geladen wird.

Dieser Python‑Code zeigt, wie Sie eine Präsentation untersuchen, um festzustellen, ob sie kennwortgeschützt ist (ohne die Präsentation selbst zu laden):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **Prüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht die Prüfung, ob eine Präsentation verschlüsselt ist. Verwenden Sie dazu die [is_encrypted](https://reference.aspose.com/slides/de/python-net/aspose.slides/protectionmanager/)‑Eigenschaft, die `True` zurückgibt, wenn die Präsentation verschlüsselt ist, bzw. `False`, wenn sie nicht verschlüsselt ist.

Der folgende Beispielcode zeigt, wie Sie prüfen, ob eine Präsentation verschlüsselt ist:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Prüfen, ob eine Präsentation schreibgeschützt ist**

Aspose.Slides ermöglicht die Prüfung, ob eine Präsentation schreibgeschützt ist. Verwenden Sie dazu die [is_write_protected](https://reference.aspose.com/slides/de/python-net/aspose.slides/protectionmanager/)‑Eigenschaft, die `True` zurückgibt, wenn die Präsentation schreibgeschützt ist, bzw. `False`, wenn sie nicht schreibgeschützt ist.

Der folgende Beispielcode zeigt, wie Sie prüfen, ob eine Präsentation schreibgeschützt ist:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Validieren, ob ein bestimmtes Kennwort zum Schutz einer Präsentation verwendet wurde**

Möglicherweise möchten Sie prüfen und bestätigen, dass ein bestimmtes Kennwort zum Schutz eines Präsentationsdokuments verwendet wurde. Aspose.Slides bietet die Möglichkeit, ein Kennwort zu validieren.

Der folgende Beispielcode zeigt, wie Sie ein Kennwort validieren:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # prüfe, ob "pass" übereinstimmt
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Er gibt `True` zurück, wenn die Präsentation mit dem angegebenen Kennwort verschlüsselt wurde. Andernfalls gibt er `False` zurück.

{{% alert color="primary" title="Siehe auch" %}} 
- [Digital Signature in PowerPoint](/slides/de/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welche Verschlüsselungsmethoden werden von Aspose.Slides unterstützt?**

Aspose.Slides unterstützt moderne Verschlüsselungsmethoden, einschließlich AES‑basierter Algorithmen, wodurch ein hohes Maß an Datensicherheit für Ihre Präsentationen gewährleistet wird.

**Was passiert, wenn ein falsches Kennwort beim Versuch, eine Präsentation zu öffnen, eingegeben wird?**

Wird ein falsches Kennwort verwendet, wird eine Ausnahme ausgelöst, die anzeigt, dass der Zugriff auf die Präsentation verweigert wird. Dies trägt dazu bei, unbefugten Zugriff zu verhindern und den Inhalt der Präsentation zu schützen.

**Gibt es Leistungsauswirkungen bei der Arbeit mit kennwortgeschützten Präsentationen?**

Der Verschlüsselungs‑ und Entschlüsselungsprozess kann beim Öffnen und Speichern einen leichten Mehraufwand verursachen. In den meisten Fällen ist diese Performance‑Auswirkung minimal und beeinträchtigt die Gesamtablaufzeit Ihrer Präsentationsaufgaben kaum.