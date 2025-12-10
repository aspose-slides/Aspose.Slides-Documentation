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
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen mit Passwortschutz mühelos sperren und entsperren können, mit Aspose.Slides für .NET. Sichern Sie Ihre Präsentationen."
---

## **Übersicht**

Wenn Sie eine Präsentation mit einem Kennwort schützen, legen Sie ein Kennwort fest, das bestimmte Einschränkungen für die Präsentation durchsetzt. Um diese Einschränkungen zu entfernen, muss das Kennwort eingegeben werden. Eine kennwortgeschützte Präsentation gilt als gesperrte Präsentation.

Typischerweise können Sie ein Kennwort festlegen, um diese Einschränkungen für eine Präsentation durchzusetzen:

- **Änderung**

Wenn Sie möchten, dass nur bestimmte Benutzer Ihre Präsentation ändern dürfen, können Sie eine Änderungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen Elemente in Ihrer Präsentation ändern, verändern oder kopieren, solange sie das Kennwort nicht angeben.

Ohne das Kennwort kann ein Benutzer jedoch weiterhin auf das Dokument zugreifen und es öffnen. In diesem Nur‑Lese‑Modus kann der Benutzer den Inhalt – einschließlich Hyperlinks, Animationen, Effekte und anderer Elemente – in Ihrer Präsentation anzeigen, jedoch keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

Wenn Sie möchten, dass nur bestimmte Benutzer Ihre Präsentation öffnen dürfen, können Sie eine Öffnungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen den Inhalt Ihrer Präsentation überhaupt ansehen können, solange sie das Kennwort nicht angeben.

Technisch verhindert die Öffnungsbeschränkung ebenfalls Änderungen an Ihrer Präsentation – wenn Personen eine Präsentation nicht öffnen können, können sie sie nicht ändern oder bearbeiten.

**Hinweis:** Wenn Sie eine Präsentation kennwortschützen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## **Passwortschutz in Aspose.Slides**

**Unterstützte Formate**

Aspose.Slides unterstützt Passwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in folgenden Formaten:

- PPTX und PPT – Microsoft PowerPoint‑Präsentationen
- ODP – OpenDocument‑Präsentationen
- OTP – OpenDocument‑Präsentationsvorlagen

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht Ihnen, Passwortschutz für Präsentationen zu verwenden, um Änderungen auf folgende Weise zu verhindern:

- Verschlüsseln einer Präsentation
- Festlegen von Schreibschutz für eine Präsentation

**Weitere Vorgänge**

Aspose.Slides ermöglicht Ihnen zusätzliche Aufgaben im Zusammenhang mit Passwortschutz und Verschlüsselung:

- Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation
- Entfernen der Verschlüsselung; Deaktivieren des Passwortschutzes
- Entfernen des Schreibschutzes von einer Präsentation
- Abrufen der Eigenschaften einer verschlüsselten Präsentation
- Prüfen, ob eine Präsentation kennwortgeschützt ist, bevor sie geladen wird
- Prüfen, ob eine Präsentation verschlüsselt ist
- Prüfen, ob eine Präsentation kennwortgeschützt ist

## **Eine Präsentation mit einem Kennwort schützen**

Sie können eine Präsentation verschlüsseln, indem Sie ein Kennwort festlegen. Um die gesperrte Präsentation zu ändern, muss ein Benutzer das Kennwort angeben.

Um eine Präsentation zu verschlüsseln (oder kennwortschützen), verwenden Sie die `Encrypt`‑Methode von [ProtectionManager](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager) und geben ein Kennwort an. Übergeben Sie das Kennwort an die `Encrypt`‑Methode und verwenden Sie anschließend die `Save`‑Methode, um die nun verschlüsselte Präsentation zu speichern.

Dieses Beispiel zeigt, wie Sie eine Präsentation verschlüsseln:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```


## **Schreibschutz für eine Präsentation festlegen** 

Sie können eine Markierung mit dem Hinweis „Do not modify“ zu einer Präsentation hinzufügen. Dies teilt den Benutzern mit, dass Sie nicht möchten, dass sie Änderungen an der Präsentation vornehmen.

**Hinweis:** Der Schreibschutzvorgang verschlüsselt die Präsentation nicht. Benutzer können die Präsentation daher – falls sie möchten – ändern, müssen jedoch zum Speichern der Änderungen einen anderen Dateinamen wählen.

Um Schreibschutz festzulegen, verwenden Sie die `SetWriteProtection`‑Methode. Dieses Beispiel zeigt, wie Sie Schreibschutz für eine Präsentation festlegen:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```


## **Eine verschlüsselte Präsentation laden**

Aspose.Slides ermöglicht das Laden einer verschlüsselten Präsentation, indem das korrekte Kennwort übergeben wird. Dieses Beispiel zeigt, wie Sie eine verschlüsselte Präsentation laden:
```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Arbeiten Sie mit der entschlüsselten Präsentation.
}
```


## **Verschlüsselung von einer Präsentation entfernen**

Sie können die Verschlüsselung oder den Kennwortschutz einer Präsentation entfernen, sodass Benutzer ohne Einschränkungen darauf zugreifen oder sie ändern können.

Um die Verschlüsselung oder den Kennwortschutz zu entfernen, rufen Sie die [RemoveEncryption](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removeencryption)‑Methode auf. Dieses Beispiel zeigt, wie Sie die Verschlüsselung von einer Präsentation entfernen:
```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```


## **Schreibschutz von einer Präsentation entfernen**

Mit Aspose.Slides können Sie den Schreibschutz einer Präsentationsdatei entfernen. Benutzer können die Datei dann nach Belieben ändern und erhalten keine Warnungen mehr bei entsprechenden Vorgängen.

Sie können den Schreibschutz entfernen, indem Sie die [RemoveWriteProtection](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removewriteprotection)‑Methode verwenden. Dieses Beispiel zeigt, wie Sie den Schreibschutz von einer Präsentation entfernen:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```


## **Eigenschaften einer verschlüsselten Präsentation abrufen**

Benutzer haben häufig Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder kennwortgeschützten Präsentation abzurufen. Aspose.Slides bietet jedoch einen Mechanismus, der es Ihnen ermöglicht, eine Präsentation kennwortgeschützt zu halten und gleichzeitig den Benutzern Zugriff auf deren Eigenschaften zu gewähren.

**Hinweis:** Standardmäßig verschlüsselt Aspose.Slides beim Verschlüsseln einer Präsentation auch die Dokumenteigenschaften. Wenn Sie möchten, dass die Dokumenteigenschaften auch nach der Verschlüsselung zugänglich bleiben, können Sie dies mit Aspose.Slides einstellen.

Wenn Sie möchten, dass Benutzer weiterhin Zugriff auf die Eigenschaften einer verschlüsselten Präsentation haben, setzen Sie die [EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties)‑Eigenschaft auf `true`. Dieses Beispiel zeigt, wie Sie eine Präsentation verschlüsseln und gleichzeitig den Benutzern Zugriff auf die Dokumenteigenschaften gewähren:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```


## **Prüfen, ob eine Präsentation kennwortgeschützt ist**

Bevor Sie eine Präsentation laden, möchten Sie möglicherweise prüfen, ob sie nicht mit einem Kennwort geschützt ist. Dies hilft, Fehler und ähnliche Probleme zu vermeiden, die auftreten, wenn eine kennwortgeschützte Präsentation ohne das korrekte Kennwort geladen wird.

Dieser C#‑Code zeigt, wie Sie eine Präsentation untersuchen können, um festzustellen, ob sie kennwortgeschützt ist, ohne sie tatsächlich zu laden:
```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```


## **Prüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht Ihnen die Überprüfung, ob eine Präsentation verschlüsselt ist. Verwenden Sie dazu die [IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/isencrypted)‑Eigenschaft, die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, bzw. `false`, wenn nicht.

Dieses Beispiel zeigt, wie Sie prüfen, ob eine Präsentation verschlüsselt ist:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```


## **Prüfen, ob eine Präsentation schreibgeschützt ist**

Aspose.Slides ermöglicht Ihnen die Überprüfung, ob eine Präsentation schreibgeschützt ist. Verwenden Sie dazu die [IsWriteProtected](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/iswriteprotected)‑Eigenschaft, die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, bzw. `false`, wenn nicht.

Dieses Beispiel zeigt, wie Sie prüfen, ob eine Präsentation schreibgeschützt ist:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```


## **Verwendung des Präsentationskennworts verifizieren**

Möglicherweise möchten Sie prüfen und bestätigen, dass ein bestimmtes Kennwort zum Schutz einer Präsentationsdatei verwendet wurde. Aspose.Slides stellt dafür die Möglichkeit bereit, ein Kennwort zu validieren.

Dieses Beispiel zeigt, wie Sie ein Kennwort validieren:
```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Überprüfen, ob das Passwort übereinstimmt.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```


Es gibt `true` zurück, wenn die Präsentation mit dem angegebenen Kennwort verschlüsselt wurde; andernfalls `false`.

{{% alert color="primary" title="Siehe auch" %}} 
- [Digitale Signatur in PowerPoint](/slides/de/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Eine Präsentation online kennwortschützen**

1. Rufen Sie unsere Seite [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) auf.  
1. Klicken Sie auf **Drop or upload your files**.  
1. Wählen Sie die Datei aus, die Sie auf Ihrem Computer kennwortschützen möchten.  
1. Geben Sie das gewünschte Kennwort für den Bearbeitungsschutz und das gewünschte Kennwort für den Anzeige‑schutz ein.  
1. Wenn Sie möchten, dass Benutzer Ihre Präsentation als Endversion sehen, aktivieren Sie das Kontrollkästchen **Mark as final**.  
1. Klicken Sie auf **PROTECT NOW.**  
1. Klicken Sie auf **DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **FAQ**

**Welche Verschlüsselungsmethoden unterstützt Aspose.Slides?**

Aspose.Slides unterstützt moderne Verschlüsselungsmethoden, einschließlich AES‑basierter Algorithmen, und gewährleistet so ein hohes Maß an Datensicherheit für Ihre Präsentationen.

**Was passiert, wenn ein falsches Kennwort beim Versuch, eine Präsentation zu öffnen, eingegeben wird?**

Es wird eine Ausnahme ausgelöst, die darauf hinweist, dass der Zugriff auf die Präsentation verweigert wurde. Dies hilft, unbefugten Zugriff zu verhindern und den Inhalt der Präsentation zu schützen.

**Gibt es Leistungseinbußen beim Arbeiten mit kennwortgeschützten Präsentationen?**

Der Verschlüsselungs‑ und Entschlüsselungsprozess kann beim Öffnen und Speichern einen leichten Mehraufwand verursachen. In den meisten Fällen ist diese Auswirkung jedoch minimal und beeinträchtigt die Gesamtausführungszeit Ihrer Präsentationsaufgaben nicht.