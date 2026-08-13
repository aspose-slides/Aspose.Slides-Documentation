---
title: "Sichere Präsentationen mit Passwörtern in .NET"
linktitle: "Passwortschutz"
type: docs
weight: 20
url: /de/net/password-protected-presentation/
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
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für .NET PowerPoint- und OpenDocument-Präsentationen mühelos sperren und entsperren können. Schützen Sie Ihre Präsentationen."
---
## **Einführung**

Wenn Sie eine Präsentation mit einem Kennwort schützen, bedeutet das, dass Sie ein Kennwort festlegen, das bestimmte Einschränkungen für die Präsentation durchsetzt. Um diese Einschränkungen zu entfernen, muss das Kennwort eingegeben werden. Eine kennwortgeschützte Präsentation gilt als gesperrte Präsentation.

Typischerweise können Sie ein Kennwort festlegen, um diese Einschränkungen für eine Präsentation durchzusetzen:

- **Änderung**

  Wenn Sie nur bestimmten Benutzern erlauben möchten, Ihre Präsentation zu ändern, können Sie eine Änderungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen Elemente Ihrer Präsentation modifizieren, ändern oder kopieren, es sei denn, sie geben das Kennwort an. 

  Allerdings kann ein Benutzer das Dokument auch ohne Kennwort öffnen und darauf zugreifen. In diesem Nur-Lese-Modus kann der Benutzer den Inhalt – einschließlich Hyperlinks, Animationen, Effekten und anderen Elementen – Ihrer Präsentation ansehen, jedoch keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

  Wenn Sie nur bestimmten Benutzern das Öffnen Ihrer Präsentation erlauben möchten, können Sie eine Öffnungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen überhaupt den Inhalt Ihrer Präsentation sehen, es sei denn, sie geben das Kennwort an.

  Technisch verhindert die Öffnungsbeschränkung ebenfalls, dass Benutzer Ihre Präsentationen ändern – wenn Personen eine Präsentation nicht öffnen können, können sie sie nicht ändern oder bearbeiten.

**Hinweis:** Wenn Sie eine Präsentation mit einem Kennwort schützen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## **Kennwortschutz in Aspose.Slides**

**Unterstützte Formate**

Aspose.Slides unterstützt Kennwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in den folgenden Formaten:

- PPTX und PPT – Microsoft PowerPoint-Präsentationen
- ODP – OpenDocument-Präsentationen
- OTP – OpenDocument-Präsentationsvorlagen

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht die Verwendung von Kennwortschutz für Präsentationen, um Änderungen auf die folgenden Arten zu verhindern:

- Verschlüsseln einer Präsentation
- Festlegen eines Schreibschutzes für eine Präsentation

**Weitere Vorgänge**

Aspose.Slides ermöglicht das Ausführen zusätzlicher Aufgaben im Zusammenhang mit Kennwortschutz und Verschlüsselung auf folgende Weise:

- Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation
- Entfernen der Verschlüsselung; Deaktivieren des Kennwortschutzes
- Entfernen des Schreibschutzes von einer Präsentation
- Abrufen der Eigenschaften einer verschlüsselten Präsentation
- Überprüfen, ob eine Präsentation vor dem Laden kennwortgeschützt ist
- Überprüfen, ob eine Präsentation verschlüsselt ist
- Überprüfen, ob eine Präsentation kennwortgeschützt ist

## **Eine Präsentation mit einem Kennwort schützen**

Sie können eine Präsentation verschlüsseln, indem Sie ein Kennwort festlegen. Um die gesperrte Präsentation zu ändern, muss ein Benutzer das Kennwort eingeben.

Um eine Präsentation zu verschlüsseln (oder kennwortzuschützen), verwenden Sie die `Encrypt`‑Methode von [ProtectionManager](https://reference.aspose.com/slides/de/net/aspose.slides/protectionmanager), um ein Kennwort festzulegen. Übergeben Sie das Kennwort an die `Encrypt`‑Methode und verwenden Sie anschließend die `Save`‑Methode, um die nun verschlüsselte Präsentation zu speichern.

Dieses Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Schreibschutz für eine Präsentation festlegen**

Sie können einer Präsentation einen Hinweis "Nicht ändern" hinzufügen. Dieser weist die Benutzer darauf hin, dass Sie nicht möchten, dass sie Änderungen an der Präsentation vornehmen.

**Hinweis:** Der Schreibschutzvorgang verschlüsselt die Präsentation nicht. Daher können Benutzer – falls sie möchten – die Präsentation ändern, müssen die Änderungen jedoch unter einem anderen Namen speichern.

Um den Schreibschutz festzulegen, verwenden Sie die `SetWriteProtection`‑Methode. Dieser Beispielcode zeigt, wie Sie den Schreibschutz für eine Präsentation festlegen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Verschlüsselte Präsentation laden**

Aspose.Slides ermöglicht das Laden einer verschlüsselten Präsentation, indem das korrekte Kennwort übergeben wird. Dieser Beispielcode zeigt, wie Sie eine verschlüsselte Präsentation laden:

```c#
using Aspose.Slides;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Arbeiten mit der entschlüsselten Präsentation.
}
```

## **Verschlüsselung einer Präsentation entfernen**

Sie können die Verschlüsselung oder den Kennwortschutz einer Präsentation entfernen, sodass Benutzer darauf zugreifen oder sie ohne Einschränkungen ändern können.

Um die Verschlüsselung oder den Kennwortschutz zu entfernen, rufen Sie die [RemoveEncryption](https://reference.aspose.com/slides/de/net/aspose.slides/protectionmanager/methods/removeencryption)‑Methode auf. Dieser Beispielcode zeigt, wie Sie die Verschlüsselung einer Präsentation entfernen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Schreibschutz einer Präsentation entfernen**

Sie können Aspose.Slides verwenden, um den Schreibschutz einer Präsentationsdatei zu entfernen. Auf diese Weise können Benutzer sie nach Belieben ändern – und sie erhalten beim Ausführen solcher Vorgänge keine Warnungen mehr.

Sie können den Schreibschutz entfernen, indem Sie die [RemoveWriteProtection](https://reference.aspose.com/slides/de/net/aspose.slides/protectionmanager/methods/removewriteprotection)‑Methode verwenden. Dieser Beispielcode zeigt, wie Sie den Schreibschutz einer Präsentation entfernen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Eigenschaften einer verschlüsselten Präsentation abrufen**

Typischerweise haben Benutzer Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder kennwortgeschützten Präsentation abzurufen. Aspose.Slides bietet jedoch einen Mechanismus, der es ermöglicht, eine Präsentation zu kennwortschützen und gleichzeitig den Benutzern den Zugriff auf ihre Eigenschaften zu erhalten.

**Hinweis:** Standardmäßig werden beim Verschlüsseln einer Präsentation durch Aspose.Slides auch die Dokumenteigenschaften der Präsentation kennwortgeschützt. Wenn Sie die Dokumenteigenschaften nach der Verschlüsselung weiterhin zugänglich machen möchten, ermöglicht Aspose.Slides genau das.

Wenn Sie den Benutzern ermöglichen möchten, weiterhin auf die Eigenschaften einer verschlüsselten Präsentation zuzugreifen, setzen Sie die `EncryptDocumentProperties`‑Eigenschaft von [IProtectionManager](https://reference.aspose.com/slides/de/net/aspose.slides/iprotectionmanager/) auf `false`. Dieser Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln und gleichzeitig den Benutzern den Zugriff auf ihre Dokumenteigenschaften ermöglichen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Nur Dokumenteigenschaften einer verschlüsselten Präsentation laden**

Um die Metadaten einer verschlüsselten Präsentation zu prüfen, ohne ihre Folien oder andere Inhalte zu laden, erstellen Sie ein [LoadOptions](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/)-Objekt und setzen Sie [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) auf `true`. In diesem Modus ignoriert Aspose.Slides das Kennwort und lädt nur die öffentlich zugänglichen Dokumenteigenschaften.

Das folgende Codebeispiel liest integrierte und benutzerdefinierte Dokumenteigenschaften über [IPresentation.DocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/documentproperties/):

```c#
using Aspose.Slides;

var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Eingebaute Dokumenteigenschaften lesen.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Benutzerdefinierte Dokumenteigenschaften lesen.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

Dieser Workflow funktioniert nur, wenn die Dokumenteigenschaften bei der Verschlüsselung der Präsentation unverschlüsselt (öffentlich) gelassen wurden. Sind die Dokumenteigenschaften verschlüsselt, führt das Setzen von `OnlyLoadDocumentProperties` auf `true` zu einer Ausnahme, da das Kennwort in diesem Modus ignoriert wird. Um verschlüsselte Dokumenteigenschaften zuzugreifen oder die gesamte Präsentation einschließlich ihrer Folien und anderer Inhalte zu laden, geben Sie den korrekten `Password`‑Wert in [LoadOptions](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/) an.

## **Überprüfen, ob eine Präsentation Kennwortgeschützt ist**

Bevor Sie eine Präsentation laden, möchten Sie möglicherweise prüfen, ob sie nicht mit einem Kennwort geschützt ist. Das hilft, Fehler und ähnliche Probleme zu vermeiden, die auftreten, wenn eine kennwortgeschützte Präsentation ohne das korrekte Kennwort geladen wird.

Dieser C#‑Code zeigt, wie Sie eine Präsentation untersuchen können, um festzustellen, ob sie kennwortgeschützt ist, ohne sie tatsächlich zu laden:

```c#
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Überprüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht die Überprüfung, ob eine Präsentation verschlüsselt ist. Dafür können Sie die [IsEncrypted](https://reference.aspose.com/slides/de/net/aspose.slides/protectionmanager/properties/isencrypted)‑Eigenschaft nutzen, die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, andernfalls `false`.

Dieser Beispielcode zeigt, wie Sie prüfen können, ob eine Präsentation verschlüsselt ist:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Überprüfen, ob eine Präsentation schreibgeschützt ist**

Aspose.Slides ermöglicht die Überprüfung, ob eine Präsentation schreibgeschützt ist. Dafür können Sie die [IsWriteProtected](https://reference.aspose.com/slides/de/net/aspose.slides/protectionmanager/properties/iswriteprotected)‑Eigenschaft nutzen, die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, andernfalls `false`.

Dieser Beispielcode zeigt, wie Sie prüfen können, ob eine Präsentation schreibgeschützt ist:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Verifizieren der Kennwortverwendung einer Präsentation**

Möglicherweise möchten Sie prüfen und bestätigen, dass ein bestimmtes Kennwort zum Schutz eines Präsentationsdokuments verwendet wurde. Aspose.Slides bietet die Möglichkeit, ein Kennwort zu validieren.

Dieser Beispielcode zeigt, wie Sie ein Kennwort validieren:

```c#
using Aspose.Slides;

using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Überprüfen, ob das Passwort übereinstimmt.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Er gibt `true` zurück, wenn die Präsentation mit dem angegebenen Kennwort verschlüsselt wurde; andernfalls `false`.

{{% alert color="info" title="Siehe auch" %}} 
- [Digitale Signatur in PowerPoint](/slides/de/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Präsentation online kennwortschützen**

1. Rufen Sie unsere Seite [**Aspose.Slides Lock**](https://products.aspose.app/slides/de/lock) auf. 
2. Klicken Sie auf **Drop or upload your files**. 
3. Wählen Sie die Datei aus, die Sie auf Ihrem Computer kennwortschützen möchten. 
4. Geben Sie Ihr gewünschtes Kennwort für den Bearbeitungsschutz und Ihr gewünschtes Kennwort für den Ansichtsschutz ein. 
5. Wenn Sie möchten, dass Benutzer Ihre Präsentation als Endversion sehen, aktivieren Sie das Kontrollkästchen **Mark as final**. 
6. Klicken Sie auf **PROTECT NOW.** 
7. Klicken Sie auf **DOWNLOAD NOW.**

![PowerPoint‑Präsentationen kennwortschützen](slides-lock.png)

## **FAQ**

**Welche Verschlüsselungsmethoden werden von Aspose.Slides unterstützt?**

Aspose.Slides unterstützt moderne Verschlüsselungsmethoden, einschließlich AES‑basierter Algorithmen, und gewährleistet so ein hohes Maß an Datensicherheit für Ihre Präsentationen.

**Was passiert, wenn beim Versuch, eine Präsentation zu öffnen, ein falsches Kennwort eingegeben wird?**

Es wird eine Ausnahme ausgelöst, wenn ein falsches Kennwort verwendet wird, wodurch Sie darauf hingewiesen werden, dass der Zugriff auf die Präsentation verweigert wird. Dies hilft, unbefugten Zugriff zu verhindern und den Präsentationsinhalt zu schützen.

**Gibt es Leistungsauswirkungen bei der Arbeit mit kennwortgeschützten Präsentationen?**

Der Verschlüsselungs‑ und Entschlüsselungsprozess kann beim Öffnen und Speichern einen leichten Mehraufwand verursachen. In den meisten Fällen ist diese Auswirkung minimal und beeinträchtigt die Gesamtlaufzeit Ihrer Präsentationsaufgaben kaum.