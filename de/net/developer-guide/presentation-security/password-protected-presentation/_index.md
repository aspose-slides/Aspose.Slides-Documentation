---
title: Sichere Präsentationen mit Passwörtern in .NET
linktitle: Passwortschutz
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
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET mühelos sperren und entsperren können. Sichern Sie Ihre Präsentationen."
---
## **Einleitung**

Wenn Sie eine Präsentation mit einem Passwort schützen, bedeutet das, dass Sie ein Passwort festlegen, das bestimmte Einschränkungen für die Präsentation durchsetzt. Um diese Einschränkungen zu entfernen, muss das Passwort eingegeben werden. Eine passwortgeschützte Präsentation gilt als gesperrte Präsentation.

In der Regel können Sie ein Passwort festlegen, um diese Einschränkungen für eine Präsentation durchzusetzen:

- **Änderung**

  Wenn Sie möchten, dass nur bestimmte Benutzer Ihre Präsentation ändern können, können Sie eine Änderungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen Elemente Ihrer Präsentation ändern, verändern oder kopieren, es sei denn, sie geben das Passwort an.  

  Allerdings kann ein Benutzer auch ohne Passwort auf Ihr Dokument zugreifen und es öffnen. Im schreibgeschützten Modus kann der Benutzer den Inhalt – einschließlich Hyperlinks, Animationen, Effekten und anderen Elementen – Ihrer Präsentation ansehen, jedoch keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

  Wenn Sie möchten, dass nur bestimmte Benutzer Ihre Präsentation öffnen können, können Sie eine Öffnungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen den Inhalt Ihrer Präsentation überhaupt sehen, es sei denn, sie geben das Passwort an.  

  Technisch verhindert die Öffnungsbeschränkung ebenfalls, dass Benutzer Ihre Präsentationen ändern – wenn Personen eine Präsentation nicht öffnen können, können sie sie auch nicht ändern oder bearbeiten.

**Hinweis:** Wenn Sie eine Präsentation mit einem Passwort schützen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## **Passwortschutz in Aspose.Slides**

**Unterstützte Formate**

Aspose.Slides unterstützt Passwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in diesen Formaten:

- PPTX und PPT – Microsoft PowerPoint‑Präsentationen
- ODP – OpenDocument‑Präsentationen
- OTP – OpenDocument‑Präsentationsvorlagen

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht Ihnen, Passwortschutz für Präsentationen zu verwenden, um Änderungen auf folgende Weise zu verhindern:

- Verschlüsseln einer Präsentation
- Festlegen des Schreibschutzes für eine Präsentation

**Weitere Vorgänge**

Aspose.Slides ermöglicht Ihnen, zusätzliche Aufgaben im Zusammenhang mit Passwortschutz und Verschlüsselung wie folgt auszuführen:

- Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation
- Entfernen der Verschlüsselung; Deaktivieren des Passwortschutzes
- Entfernen des Schreibschutzes von einer Präsentation
- Abrufen der Eigenschaften einer verschlüsselten Präsentation
- Prüfen, ob eine Präsentation vor dem Laden passwortgeschützt ist
- Prüfen, ob eine Präsentation verschlüsselt ist
- Prüfen, ob eine Präsentation passwortgeschützt ist

## **Eine Präsentation mit einem Passwort schützen**

Sie können eine Präsentation verschlüsseln, indem Sie ein Passwort festlegen. Um die gesperrte Präsentation zu ändern, muss ein Benutzer das Passwort angeben.

Um eine Präsentation zu verschlüsseln (oder passwortzuschützen), verwenden Sie die `Encrypt`‑Methode von [ProtectionManager](https://reference.aspose.com/slides/de/net/aspose.slides/protectionmanager), um ein Passwort festzulegen. Übergeben Sie das Passwort an die `Encrypt`‑Methode und verwenden Sie anschließend die `Save`‑Methode, um die nun verschlüsselte Präsentation zu speichern.

Dieser Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Schreibschutz für eine Präsentation festlegen**

Sie können einer Präsentation einen Hinweis „Do not modify“ hinzufügen. Dieser informiert die Benutzer, dass Sie nicht möchten, dass Änderungen an der Präsentation vorgenommen werden.

**Hinweis:** Der Schreibschutzvorgang verschlüsselt die Präsentation nicht. Daher können Benutzer – falls sie es wünschen – die Präsentation ändern, müssen sie jedoch zum Speichern der Änderungen einen anderen Dateinamen wählen.

Um Schreibschutz zu aktivieren, verwenden Sie die `SetWriteProtection`‑Methode. Dieser Beispielcode zeigt, wie Sie Schreibschutz für eine Präsentation festlegen:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Verschlüsselte Präsentation laden**

Aspose.Slides ermöglicht das Laden einer verschlüsselten Präsentation, indem das korrekte Passwort übergeben wird. Dieser Beispielcode zeigt, wie Sie eine verschlüsselte Präsentation laden:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Arbeiten mit der entschlüsselten Präsentation.
}
```

## **Verschlüsselung einer Präsentation entfernen**

Sie können die Verschlüsselung oder den Passwortschutz einer Präsentation entfernen, sodass Benutzer ohne Einschränkungen darauf zugreifen oder sie ändern können.

Um die Verschlüsselung oder den Passwortschutz zu entfernen, rufen Sie die Methode [RemoveEncryption](https://reference.aspose.com/slides/de/net/aspose.slides/protectionmanager/methods/removeencryption) auf. Dieser Beispielcode zeigt, wie Sie die Verschlüsselung einer Präsentation entfernen:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Schreibschutz einer Präsentation entfernen**

Sie können mit Aspose.Slides den Schreibschutz einer Präsentationsdatei entfernen. Auf diese Weise können Benutzer sie nach Belieben ändern – und erhalten dabei keine Warnungen.

Den Schreibschutz können Sie mit der Methode [RemoveWriteProtection](https://reference.aspose.com/slides/de/net/aspose.slides/protectionmanager/methods/removewriteprotection) entfernen. Dieser Beispielcode zeigt, wie Sie den Schreibschutz einer Präsentation entfernen:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Eigenschaften einer verschlüsselten Präsentation abrufen**

In der Regel haben Benutzer Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder passwortgeschützten Präsentation abzurufen. Aspose.Slides bietet jedoch einen Mechanismus, mit dem Sie eine Präsentation passwortschützen können und gleichzeitig den Benutzern den Zugriff auf ihre Eigenschaften ermöglichen.

**Hinweis:** Standardmäßig werden beim Verschlüsseln einer Präsentation durch Aspose.Slides auch die Dokumenteigenschaften der Präsentation passwortgeschützt. Wenn Sie die Dokumenteigenschaften nach der Verschlüsselung weiterhin zugänglich machen möchten, ermöglicht Ihnen Aspose.Slides genau dies.

Wenn Sie möchten, dass Benutzer weiterhin die Eigenschaften einer verschlüsselten Präsentation einsehen können, setzen Sie die Eigenschaft `EncryptDocumentProperties` von [IProtectionManager](https://reference.aspose.com/slides/de/net/aspose.slides/iprotectionmanager/) auf `false`. Dieser Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln und dabei den Benutzern Zugriff auf die Dokumenteigenschaften gewähren:

```c#
using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Nur Dokumenteigenschaften einer verschlüsselten Präsentation laden**

Um die Metadaten einer verschlüsselten Präsentation zu prüfen, ohne deren Folien oder andere Inhalte zu laden, erstellen Sie ein [LoadOptions](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/)-Objekt und setzen Sie [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) auf `true`. In diesem Modus ignoriert Aspose.Slides das Passwort und lädt nur die öffentlich zugänglichen Dokumenteigenschaften.

Das folgende Codebeispiel liest integrierte und benutzerdefinierte Dokumenteigenschaften über [IPresentation.DocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/documentproperties/):

```c#
var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Read built-in document properties.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Read custom document properties.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

Dieser Workflow funktioniert nur, wenn die Dokumenteigenschaften beim Verschlüsseln der Präsentation unverschlüsselt (öffentlich) gelassen wurden. Sind die Dokumenteigenschaften verschlüsselt, führt das Setzen von `OnlyLoadDocumentProperties` auf `true` zu einer Ausnahme, da das Passwort in diesem Modus ignoriert wird. Um verschlüsselte Dokumenteigenschaften zuzugreifen oder die vollständige Präsentation einschließlich Folien und sonstigem Inhalt zu laden, geben Sie den korrekten `Password`‑Wert in [LoadOptions](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/) an.

## **Prüfen, ob eine Präsentation passwortgeschützt ist**

Bevor Sie eine Präsentation laden, möchten Sie möglicherweise prüfen, ob sie nicht mit einem Passwort geschützt ist. Dies hilft, Fehler und ähnliche Probleme zu vermeiden, die auftreten, wenn eine passwortgeschützte Präsentation ohne das korrekte Passwort geladen wird.

Dieser C#‑Code zeigt, wie Sie eine Präsentation prüfen können, ob sie passwortgeschützt ist, ohne sie tatsächlich zu laden:

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Prüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht es, zu prüfen, ob eine Präsentation verschlüsselt ist. Dafür können Sie die Eigenschaft [IsEncrypted](https://reference.aspose.com/slides/de/net/aspose.slides/protectionmanager/properties/isencrypted) verwenden, die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, andernfalls `false`.

Dieser Beispielcode zeigt, wie Sie prüfen, ob eine Präsentation verschlüsselt ist:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Prüfen, ob eine Präsentation schreibgeschützt ist**

Aspose.Slides ermöglicht es, zu prüfen, ob eine Präsentation schreibgeschützt ist. Dafür können Sie die Eigenschaft [IsWriteProtected](https://reference.aspose.com/slides/de/net/aspose.slides/protectionmanager/properties/iswriteprotected) verwenden, die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, andernfalls `false`.

Dieser Beispielcode zeigt, wie Sie prüfen, ob eine Präsentation schreibgeschützt ist:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Verifizieren der Passwortverwendung einer Präsentation**

Möglicherweise möchten Sie prüfen und bestätigen, dass ein bestimmtes Passwort zum Schutz eines Präsentationsdokuments verwendet wurde. Aspose.Slides stellt Mittel bereit, um ein Passwort zu validieren.

Dieser Beispielcode zeigt, wie Sie ein Passwort validieren:

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Überprüfen, ob das Passwort übereinstimmt.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Er gibt `true` zurück, wenn die Präsentation mit dem angegebenen Passwort verschlüsselt wurde; andernfalls gibt er `false` zurück.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/de/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Präsentation online passwortschützen**

1. Öffnen Sie unsere Seite [**Aspose.Slides Lock**](https://products.aspose.app/slides/de/lock). 
1. Klicken Sie auf **Drop or upload your files**. 
1. Wählen Sie die Datei aus, die Sie auf Ihrem Computer mit einem Passwort schützen möchten. 
1. Geben Sie Ihr gewünschtes Passwort für den Bearbeitungsschutz und Ihr gewünschtes Passwort für den Ansichtsschutz ein. 
1. Wenn Sie möchten, dass die Benutzer Ihre Präsentation als Endkopie sehen, aktivieren Sie das Kontrollkästchen **Mark as final**. 
1. Klicken Sie auf **PROTECT NOW.** 
1. Klicken Sie auf **DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **FAQ**

**Welche Verschlüsselungsmethoden werden von Aspose.Slides unterstützt?**

Aspose.Slides unterstützt moderne Verschlüsselungsmethoden, einschließlich AES-basierter Algorithmen, und gewährleistet ein hohes Maß an Datensicherheit für Ihre Präsentationen.

**Was passiert, wenn beim Versuch, eine Präsentation zu öffnen, ein falsches Passwort eingegeben wird?**

Wird ein falsches Passwort verwendet, wird eine Ausnahme ausgelöst, die anzeigt, dass der Zugriff auf die Präsentation verweigert wird. Dies verhindert unbefugten Zugriff und schützt den Inhalt der Präsentation.

**Gibt es Leistungseinbußen bei der Arbeit mit passwortgeschützten Präsentationen?**

Der Verschlüsselungs‑ und Entschlüsselungsprozess kann beim Öffnen und Speichern einen geringen Mehraufwand verursachen. In den meisten Fällen ist dieser Einfluss gering und beeinträchtigt die Gesamtdauer Ihrer Präsentationsaufgaben kaum.