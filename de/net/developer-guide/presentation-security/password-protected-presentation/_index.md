---
title: Passwortgeschützte Präsentation
type: docs
weight: 20
url: /de/net/password-protected-presentation/
keywords: "PowerPoint sperren, PowerPoint entsperren, PowerPoint schützen, Passwort festlegen, Passwort hinzufügen, PowerPoint verschlüsseln, PowerPoint entschlüsseln, Schreibschutz, PowerPoint-Sicherheit, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "PowerPoint-Passwortschutz, Verschlüsselung und Sicherheit in C# oder .NET"

---

## **Über Passwortschutz**
### **Wie funktioniert der Passwortschutz für Präsentationen?**
Wenn Sie eine Präsentation mit einem Passwort schützen, bedeutet dies, dass Sie ein Passwort festlegen, das bestimmte Einschränkungen für die Präsentation durchsetzt. Um die Einschränkungen zu entfernen, muss das Passwort eingegeben werden. Eine passwortgeschützte Präsentation wird als gesperrte Präsentation betrachtet.

Typischerweise können Sie ein Passwort festlegen, um diese Einschränkungen in einer Präsentation durchzusetzen:

- **Änderungen**

  Wenn Sie möchten, dass nur bestimmte Benutzer Ihre Präsentation ändern können, können Sie eine Änderungseinschränkung festlegen. Diese Einschränkung verhindert, dass Personen Dinge in Ihrer Präsentation ändern, verändern oder kopieren (es sei denn, sie geben das Passwort ein).

  In diesem Fall kann ein Benutzer jedoch auch ohne das Passwort auf Ihr Dokument zugreifen und es öffnen. In diesem Nur-Lese-Modus kann der Benutzer die Inhalte oder Dinge – Hyperlinks, Animationen, Effekte und andere – in Ihrer Präsentation anzeigen, aber er kann keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

  Wenn Sie möchten, dass nur bestimmte Benutzer Ihre Präsentation öffnen können, können Sie eine Öffnungseinschränkung festlegen. Diese Einschränkung verhindert, dass Personen sogar die Inhalte Ihrer Präsentation ansehen (es sei denn, sie geben das Passwort ein).

  Technisch gesehen verhindert die Öffnungseinschränkung auch, dass Benutzer Ihre Präsentationen ändern: Wenn Personen eine Präsentation nicht öffnen können, können sie keine Änderungen daran vornehmen.

  **Hinweis**: Wenn Sie eine Präsentation passwortschützen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## So schützen Sie eine Präsentation online mit einem Passwort

1. Gehen Sie zu unserer [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) Seite.

   ![todo:image_alt_text](slides-lock.png)

2. Klicken Sie auf **Dateien hierhin ziehen oder hochladen**.

3. Wählen Sie die Datei aus, die Sie auf Ihrem Computer mit einem Passwort schützen möchten.

4. Geben Sie Ihr bevorzugtes Passwort für den Änderungs- und Ansichtsschutz ein.

5. Wenn Sie möchten, dass Benutzer Ihre Präsentation als endgültige Kopie sehen, aktivieren Sie das Kontrollkästchen **Als endgültig markieren**.

6. Klicken Sie auf **JETZT SCHÜTZEN.**

7. Klicken Sie auf **JETZT HERUNTERLADEN.**

### **Passwortschutz für Präsentationen in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Passwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in diesen Formaten:

- PPTX und PPT - Microsoft PowerPoint-Präsentation
- ODP - OpenDocument-Präsentation
- OTP - OpenDocument-Präsentationsvorlage

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht es Ihnen, Passwortschutz auf Präsentationen anzuwenden, um Änderungen in diesen Weisen zu verhindern:

- Verschlüsselung einer Präsentation
- Festlegen eines Schreibschutzes für eine Präsentation

**Andere Vorgänge**

Aspose.Slides ermöglicht es Ihnen, andere Aufgaben, die Passwortschutz und Verschlüsselung umfassen, in diesen Weisen auszuführen:

- Entschlüsselung einer Präsentation; Öffnen einer verschlüsselten Präsentation
- Entfernen der Verschlüsselung; Deaktivieren des Passwortschutzes
- Entfernen des Schreibschutzes von einer Präsentation
- Abrufen der Eigenschaften einer verschlüsselten Präsentation
- Überprüfen, ob eine Präsentation passwortgeschützt ist, bevor Sie sie laden
- Überprüfen, ob eine Präsentation verschlüsselt ist
- Überprüfen, ob eine Präsentation passwortgeschützt ist.

## Eine Präsentation verschlüsseln

Sie können eine Präsentation verschlüsseln, indem Sie ein Passwort festlegen. Um die gesperrte Präsentation zu ändern, muss der Benutzer das Passwort angeben.

Um eine Präsentation zu verschlüsseln oder mit einem Passwort zu schützen, müssen Sie die Methode encrypt (aus [ProtectionManager](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager)) verwenden, um ein Passwort für die Präsentation festzulegen. Sie übergeben das Passwort an die Methode encrypt und verwenden die Methode save, um die nun verschlüsselte Präsentation zu speichern.

Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation verschlüsseln:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## Schreibschutz für eine Präsentation festlegen

Sie können eine Markierung hinzufügen, die besagt “Nicht ändern”, zu einer Präsentation. So können Sie den Benutzern mitteilen, dass Sie nicht möchten, dass sie Änderungen an der Präsentation vornehmen.

**Hinweis**: Der Schreibschutzprozess verschlüsselt die Präsentation nicht. Daher können Benutzer – falls sie dies wirklich wünschen – die Präsentation ändern, müssen jedoch eine Präsentation mit einem anderen Namen erstellen, um die Änderungen zu speichern.

Um einen Schreibschutz festzulegen, müssen Sie die Methode setWriteProtection verwenden. Dieser Beispielcode zeigt Ihnen, wie Sie einen Schreibschutz für eine Präsentation festlegen:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## Entschlüsselung einer Präsentation; Öffnen einer verschlüsselten Präsentation

Aspose.Slides ermöglicht es Ihnen, eine verschlüsselte Datei zu laden, indem Sie ihr Passwort übergeben. Um eine Präsentation zu entschlüsseln, müssen Sie die Methode [RemoveEncryption](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removeencryption) ohne Parameter aufrufen. Sie müssen dann das richtige Passwort eingeben, um die Präsentation zu laden.

Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation entschlüsseln:

```c#
LoadOptions loadOptions = new LoadOptions {Password = "123123"};
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
  // Arbeiten mit der entschlüsselten Präsentation
}
```

## Entfernung der Verschlüsselung; Deaktivierung des Passwortschutzes

Sie können die Verschlüsselung oder den Passwortschutz für eine Präsentation entfernen. So können Benutzer auf die Präsentation zugreifen oder sie ohne Einschränkungen ändern.

Um die Verschlüsselung oder den Passwortschutz zu entfernen, müssen Sie die Methode [RemoveEncryption](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removeencryption) aufrufen. Dieser Beispielcode zeigt Ihnen, wie Sie die Verschlüsselung von einer Präsentation entfernen:

```c#
LoadOptions loadOptions = new LoadOptions {Password = "123123"};
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## Entfernung des Schreibschutzes von einer Präsentation

Sie können Aspose.Slides verwenden, um den Schreibschutz einer Präsentationsdatei zu entfernen. So können Benutzer nach Belieben Änderungen vornehmen – und sie erhalten keine Warnungen, wenn sie solche Aufgaben ausführen.

Sie können den Schreibschutz von einer Präsentation entfernen, indem Sie die Methode [RemoveWriteProtection](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removewriteprotection) verwenden. Dieser Beispielcode zeigt Ihnen, wie Sie den Schreibschutz von einer Präsentation entfernen:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## Abrufen der Eigenschaften einer verschlüsselten Präsentation

Typischerweise haben Benutzer Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder passwortgeschützten Präsentation zu erhalten. Aspose.Slides bietet jedoch einen Mechanismus, der es Ihnen ermöglicht, eine Präsentation passwortzuschützen, während die Möglichkeit für Benutzer erhalten bleibt, auf die Eigenschaften dieser Präsentation zuzugreifen.

**Hinweis**: Wenn Aspose.Slides eine Präsentation verschlüsselt, sind die Dokumenteigenschaften der Präsentation standardmäßig ebenfalls passwortgeschützt. Aber wenn Sie die Eigenschaften der Präsentation zugänglich machen möchten (auch nachdem die Präsentation verschlüsselt wurde), ermöglicht Ihnen Aspose.Slides genau das.

Wenn Sie möchten, dass Benutzer weiterhin die Möglichkeit behalten, auf die Eigenschaften einer Präsentation zuzugreifen, die Sie verschlüsselt haben, können Sie die [EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties) Eigenschaft auf `true` setzen. Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation verschlüsseln, während Sie den Benutzern die Möglichkeit bieten, auf ihre Dokumenteigenschaften zuzugreifen:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```

## **Überprüfen, ob eine Präsentation passwortgeschützt ist, bevor Sie sie laden**

Bevor Sie eine Präsentation laden, möchten Sie möglicherweise überprüfen und bestätigen, dass die Präsentation nicht mit einem Passwort geschützt ist. So können Sie Fehler und ähnliche Probleme vermeiden, die auftreten können, wenn eine passwortgeschützte Präsentation ohne ihr Passwort geladen wird.

Dieser C#-Code zeigt Ihnen, wie Sie eine Präsentation untersuchen können, um zu sehen, ob sie passwortgeschützt ist (ohne die Präsentation selbst zu laden):

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("Die Präsentation ist passwortgeschützt: " + presentationInfo.IsPasswordProtected);
```

## Überprüfen, ob eine Präsentation verschlüsselt ist

Aspose.Slides ermöglicht es Ihnen zu überprüfen, ob eine Präsentation verschlüsselt ist. Um diese Aufgabe auszuführen, können Sie die [IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/isencrypted) Eigenschaft verwenden, die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, oder `false`, wenn die Präsentation nicht verschlüsselt ist.

Dieser Beispielcode zeigt Ihnen, wie Sie überprüfen können, ob eine Präsentation verschlüsselt ist:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## Überprüfen, ob eine Präsentation schreibgeschützt ist

Aspose.Slides ermöglicht es Ihnen zu überprüfen, ob eine Präsentation schreibgeschützt ist. Um diese Aufgabe auszuführen, können Sie die [IsWriteProtected](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/iswriteprotected) Eigenschaft verwenden, die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, oder `false`, wenn die Präsentation nicht schreibgeschützt ist.

Dieser Beispielcode zeigt Ihnen, wie Sie überprüfen können, ob eine Präsentation schreibgeschützt ist:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isWriteProtected = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Überprüfen oder Bestätigen, dass ein bestimmtes Passwort zum Schutz einer Präsentation verwendet wurde**

Sie möchten möglicherweise überprüfen und bestätigen, dass ein bestimmtes Passwort zum Schutz eines Präsentationsdokuments verwendet wurde. Aspose.Slides bietet Ihnen die Möglichkeit, ein Passwort zu validieren.

Dieser Beispielcode zeigt Ihnen, wie Sie ein Passwort validieren können:

```c#
using (IPresentation pres = new Presentation("pres.pptx"))
{
    // Überprüfen, ob "pass" übereinstimmt
    bool isWriteProtected = pres.ProtectionManager.CheckWriteProtection("my_password");
}
```

Es gibt `true` zurück, wenn die Präsentation mit dem angegebenen Passwort verschlüsselt wurde. Andernfalls wird `false` zurückgegeben.

{{% alert color="primary" title="Siehe auch" %}} 
- [Digitale Signatur in PowerPoint](/slides/de/net/digital-signature-in-powerpoint/)
{{% /alert %}}