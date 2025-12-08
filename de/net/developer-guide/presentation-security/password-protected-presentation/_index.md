---
title: Secure PowerPoint Presentations with Passwords Using C#
linktitle: Passwortgeschützte Präsentation
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
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET mühelos sperren und entsperren können. Steigern Sie Ihre Produktivität und sichern Sie Ihre Präsentationen mit unserer Schritt‑für‑Schritt‑Anleitung."
---

## **Übersicht**

Wenn Sie eine Präsentation mit einem Kennwort schützen, legen Sie ein Kennwort fest, das bestimmte Beschränkungen für die Präsentation erzwingt. Um diese Beschränkungen zu entfernen, muss das Kennwort eingegeben werden. Eine kennwortgeschützte Präsentation gilt als gesperrte Präsentation.

Typischerweise können Sie ein Kennwort festlegen, um diese Beschränkungen für eine Präsentation zu erzwingen:

- **Änderung**

Wenn Sie nur bestimmten Benutzern erlauben möchten, Ihre Präsentation zu ändern, können Sie eine Änderungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen Elemente in Ihrer Präsentation ändern, verändern oder kopieren, solange sie nicht das Kennwort angeben.

Auch ohne das Kennwort kann ein Benutzer Ihr Dokument weiterhin öffnen und darauf zugreifen. In diesem Nur-Lese‑Modus kann der Benutzer den Inhalt – einschließlich Hyperlinks, Animationen, Effekte und anderer Elemente – in Ihrer Präsentation ansehen, jedoch keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

Wenn Sie nur bestimmten Benutzern das Öffnen Ihrer Präsentation erlauben möchten, können Sie eine Öffnungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen überhaupt den Inhalt Ihrer Präsentation ansehen, solange sie nicht das Kennwort angeben.

Technisch verhindert die Öffnungsbeschränkung ebenfalls das Ändern Ihrer Präsentationen – wenn Personen eine Präsentation nicht öffnen können, können sie sie nicht ändern oder bearbeiten.

**Hinweis:** Wenn Sie eine Präsentation mit Kennwortschutz versehen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## **Kennwortschutz in Aspose.Slides**

**Unterstützte Formate**

Aspose.Slides unterstützt Kennwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in folgenden Formaten:

- PPTX und PPT – Microsoft PowerPoint‑Präsentationen
- ODP – OpenDocument‑Präsentationen
- OTP – OpenDocument‑Präsentationsvorlagen

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht den Kennwortschutz von Präsentationen, um Änderungen auf folgende Weise zu verhindern:

- Eine Präsentation verschlüsseln
- Schreibschutz für eine Präsentation setzen

**Weitere Vorgänge**

Aspose.Slides ermöglicht zusätzliche Aufgaben im Zusammenhang mit Kennwortschutz und Verschlüsselung auf folgende Weise:

- Eine Präsentation entschlüsseln; eine verschlüsselte Präsentation öffnen
- Verschlüsselung entfernen; Kennwortschutz deaktivieren
- Schreibschutz von einer Präsentation entfernen
- Eigenschaften einer verschlüsselten Präsentation abrufen
- Prüfen, ob eine Präsentation kennwortgeschützt ist, bevor sie geladen wird
- Prüfen, ob eine Präsentation verschlüsselt ist
- Prüfen, ob eine Präsentation kennwortgeschützt ist

## **Eine Präsentation mit einem Kennwort schützen**

Sie können eine Präsentation verschlüsseln, indem Sie ein Kennwort festlegen. Um die gesperrte Präsentation zu ändern, muss ein Benutzer das Kennwort angeben.

Um eine Präsentation zu verschlüsseln (oder kennwortgeschützt zu machen), verwenden Sie die `Encrypt`‑Methode von [ProtectionManager](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager) und setzen ein Kennwort. Übergeben Sie das Kennwort an die `Encrypt`‑Methode und verwenden Sie anschließend die `Save`‑Methode, um die nun verschlüsselte Präsentation zu speichern.

Dieser Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```


## **Schreibschutz für eine Präsentation festlegen** 

Sie können einer Präsentation einen Hinweis „Nicht ändern“ hinzufügen. Dies informiert die Benutzer, dass Sie nicht möchten, dass Änderungen an der Präsentation vorgenommen werden.

**Hinweis:** Der Schreibschutzvorgang verschlüsselt die Präsentation nicht. Daher können Benutzer – falls sie wollen – die Präsentation ändern, müssen jedoch zum Speichern der Änderungen einen anderen Dateinamen wählen.

Um Schreibschutz zu setzen, verwenden Sie die `SetWriteProtection`‑Methode. Dieser Beispielcode zeigt, wie Sie Schreibschutz für eine Präsentation festlegen:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```


## **Eine verschlüsselte Präsentation laden**

Aspose.Slides ermöglicht das Laden einer verschlüsselten Präsentation, indem das korrekte Kennwort übergeben wird. Dieser Beispielcode zeigt, wie Sie eine verschlüsselte Präsentation laden:
```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Arbeiten Sie mit der entschlüsselten Präsentation.
}
```


## **Verschlüsselung einer Präsentation entfernen**

Sie können die Verschlüsselung oder den Kennwortschutz einer Präsentation entfernen, sodass Benutzer ohne Beschränkungen darauf zugreifen oder sie ändern können.

Um die Verschlüsselung oder den Kennwortschutz zu entfernen, rufen Sie die [RemoveEncryption](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removeencryption)‑Methode auf. Dieser Beispielcode zeigt, wie Sie die Verschlüsselung einer Präsentation entfernen:
```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```


## **Schreibschutz einer Präsentation entfernen**

Sie können mit Aspose.Slides den Schreibschutz einer Präsentationsdatei entfernen. Damit können Benutzer die Datei nach Belieben ändern – und erhalten dabei keine Warnungen.

Sie können den Schreibschutz entfernen, indem Sie die [RemoveWriteProtection](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removewriteprotection)‑Methode verwenden. Dieser Beispielcode zeigt, wie Sie den Schreibschutz einer Präsentation entfernen:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```


## **Eigenschaften einer verschlüsselten Präsentation abrufen**

In der Regel haben Benutzer Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder kennwortgeschützten Präsentation abzurufen. Aspose.Slides bietet jedoch einen Mechanismus, der es ermöglicht, eine Präsentation zu kennwortschützen und gleichzeitig Benutzern den Zugriff auf deren Eigenschaften zu gestatten.

**Hinweis:** Standardmäßig werden bei der Verschlüsselung einer Präsentation durch Aspose.Slides auch die Dokumenteigenschaften kennwortgeschützt. Wenn Sie die Dokumenteigenschaften auch nach der Verschlüsselung zugänglich machen möchten, erlaubt Aspose.Slides genau das.

Wenn Sie Benutzern ermöglichen wollen, die Eigenschaften einer verschlüsselten Präsentation weiterhin abzurufen, können Sie die Eigenschaft [EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties) auf `true` setzen. Dieser Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln und gleichzeitig den Zugriff auf die Dokumenteigenschaften ermöglichen:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```


## **Überprüfen, ob eine Präsentation kennwortgeschützt ist**

Bevor Sie eine Präsentation laden, möchten Sie möglicherweise prüfen, ob sie nicht bereits mit einem Kennwort geschützt ist. Das hilft, Fehler und ähnliche Probleme zu vermeiden, die auftreten, wenn eine kennwortgeschützte Präsentation ohne das richtige Kennwort geladen wird.

Dieser C#‑Code zeigt, wie Sie eine Präsentation untersuchen können, um festzustellen, ob sie kennwortgeschützt ist, ohne sie tatsächlich zu laden:
```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```


## **Überprüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht das Prüfen, ob eine Präsentation verschlüsselt ist. Verwenden Sie dafür die [IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/isencrypted)‑Eigenschaft, die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, und `false`, wenn nicht.

Dieser Beispielcode zeigt, wie Sie prüfen, ob eine Präsentation verschlüsselt ist:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```


## **Überprüfen, ob eine Präsentation schreibgeschützt ist**

Aspose.Slides ermöglicht das Prüfen, ob eine Präsentation schreibgeschützt ist. Verwenden Sie dafür die [IsWriteProtected](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/iswriteprotected)‑Eigenschaft, die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, und `false`, wenn nicht.

Dieser Beispielcode zeigt, wie Sie prüfen, ob eine Präsentation schreibgeschützt ist:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```


## **Verwendung des Präsentationskennworts verifizieren**

Möglicherweise möchten Sie prüfen und bestätigen, dass ein bestimmtes Kennwort zum Schutz eines Präsentationsdokuments verwendet wurde. Aspose.Slides stellt die Möglichkeit bereit, ein Kennwort zu validieren.

Dieser Beispielcode zeigt, wie Sie ein Kennwort validieren:
```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Prüfen, ob das Passwort übereinstimmt.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```


Er gibt `true` zurück, wenn die Präsentation mit dem angegebenen Kennwort verschlüsselt wurde; andernfalls `false`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/de/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Eine Präsentation online kennwortschützen**

1. Öffnen Sie unsere Seite [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).
1. Klicken Sie **Drop or upload your files**.
1. Wählen Sie die Datei aus, die Sie auf Ihrem Computer kennwortschützen möchten.
1. Geben Sie Ihr gewünschtes Kennwort für den Bearbeitungsschutz und Ihr gewünschtes Kennwort für den Ansichtsschutz ein.
1. Wenn Sie möchten, dass Benutzer Ihre Präsentation als Endfassung sehen, aktivieren Sie das Kontrollkästchen **Mark as final**.
1. Klicken Sie **PROTECT NOW.** 
1. Klicken Sie **DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **FAQ**

**Welche Verschlüsselungsmethoden unterstützt Aspose.Slides?**

Aspose.Slides unterstützt moderne Verschlüsselungsmethoden, einschließlich AES‑basierter Algorithmen, und gewährleistet damit ein hohes Maß an Datensicherheit für Ihre Präsentationen.

**Was passiert, wenn beim Öffnen einer Präsentation ein falsches Kennwort eingegeben wird?**

Es wird eine Ausnahme ausgelöst, wenn ein falsches Kennwort verwendet wird, wodurch Sie darüber informiert werden, dass der Zugriff auf die Präsentation verweigert wurde. Dies hilft, unbefugten Zugriff zu verhindern und den Inhalt der Präsentation zu schützen.

**Gibt es Leistungsauswirkungen bei der Arbeit mit kennwortgeschützten Präsentationen?**

Der Verschlüsselungs‑ und Entschlüsselungsprozess kann beim Öffnen und Speichern einen leichten Mehraufwand verursachen. In den meisten Fällen ist dieser Einfluss minimal und beeinträchtigt die Gesamtverarbeitungszeit Ihrer Präsentationsaufgaben kaum.