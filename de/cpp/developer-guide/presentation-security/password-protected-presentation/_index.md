---
title: Passwortgeschützte Präsentation
type: docs
weight: 20
url: /cpp/password-protected-presentation/
keywords: "PowerPoint-Präsentation sperren"
description: "PowerPoint-Präsentation sperren. Passwortgeschützte PowerPoint mit Aspose.Slides."
---


## **Über Passwortschutz**
### **Wie funktioniert der Passwortschutz für Präsentationen?**
Wenn Sie eine Präsentation passwortschützen, setzen Sie ein Passwort, das bestimmte Einschränkungen für die Präsentation durchsetzt. Um die Einschränkungen aufzuheben, muss das Passwort eingegeben werden. Eine passwortgeschützte Präsentation gilt als gesperrte Präsentation.

Typischerweise können Sie ein Passwort festlegen, um diese Einschränkungen für eine Präsentation durchzusetzen:

- **Änderung**

  Wenn nur bestimmte Benutzer Ihre Präsentation ändern sollen, können Sie eine Änderungsbeschränkung festlegen. Die Beschränkung verhindert hier, dass Personen Dinge in Ihrer Präsentation ändern, ändern oder kopieren (es sei denn, sie geben das Passwort ein). 

  In diesem Fall kann ein Benutzer jedoch auch ohne Passwort auf Ihr Dokument zugreifen und es öffnen. In diesem Nur-Lese-Modus kann der Benutzer den Inhalt oder Dinge—Hyperlinks, Animationen, Effekte und andere—in Ihrer Präsentation ansehen, aber sie können keine Elemente kopieren oder die Präsentation speichern. 

- **Öffnen**

  Wenn nur bestimmte Benutzer Ihre Präsentation öffnen sollen, können Sie eine Öffnungseinschränkung festlegen. Die Beschränkung verhindert hier, dass Personen den Inhalt Ihrer Präsentation überhaupt ansehen (es sei denn, sie geben das Passwort ein).

  Technisch gesehen verhindert die Öffnungseinschränkung auch, dass Benutzer Ihre Präsentationen ändern: Wenn Personen eine Präsentation nicht öffnen können, können sie sie nicht ändern oder ändern. 

  **Hinweis**: Wenn Sie eine Präsentation passwortschützen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## **So schützen Sie eine Präsentation online mit einem Passwort**

1. Gehen Sie zu unserer [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) Seite. 

   ![todo:image_alt_text](slides-lock.png)

2. Klicken Sie auf **Dateien ziehen oder hochladen**.

3. Wählen Sie die Datei auf Ihrem Computer aus, die Sie passwortschützen möchten. 

4. Geben Sie Ihr bevorzugtes Passwort für den Schreibschutz ein; Geben Sie Ihr bevorzugtes Passwort für den Ansichts-Schutz ein. 

5. Wenn Sie möchten, dass Benutzer Ihre Präsentation als endgültige Kopie ansehen, aktivieren Sie das Kontrollkästchen **Als endgültig markieren**.

6. Klicken Sie auf **JETZT SCHÜTZEN.** 

7. Klicken Sie auf **JETZT HERUNTERLADEN.**

## **Passwortschutz für Präsentationen in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Passwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in diesen Formaten: 

- PPTX und PPT - Microsoft PowerPoint-Präsentation 
- ODP - OpenDocument-Präsentation 
- OTP - OpenDocument-Präsentationsvorlage 

**Unterstützte Operationen**

Aspose.Slides ermöglicht es Ihnen, Passwortschutz auf Präsentationen anzuwenden, um Änderungen auf diese Arten zu verhindern:

- Eine Präsentation verschlüsseln
- Einen Schreibschutz für eine Präsentation festlegen

**Andere Operationen**

Aspose.Slides ermöglicht es Ihnen, andere Aufgaben im Zusammenhang mit Passwortschutz und Verschlüsselung auf diese Arten auszuführen:

- Eine Präsentation entschlüsseln; eine verschlüsselte Präsentation öffnen
- Verschlüsselung entfernen; Passwortschutz deaktivieren
- Schreibschutz von einer Präsentation entfernen
- Die Eigenschaften einer verschlüsselten Präsentation abrufen
- Überprüfen, ob eine Präsentation verschlüsselt ist
- Überprüfen, ob eine Präsentation passwortgeschützt ist.

## **Eine Präsentation verschlüsseln**

Sie können eine Präsentation verschlüsseln, indem Sie ein Passwort festlegen. Um die gesperrte Präsentation zu ändern, muss der Benutzer das Passwort angeben. 

Um eine Präsentation zu verschlüsseln oder passwortgeschützt zu machen, müssen Sie die Verschlüsselungsmethode (aus [ProtectionManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager)) verwenden, um ein Passwort für die Präsentation festzulegen. Sie übergeben das Passwort an die Verschlüsselungsmethode und verwenden die Speichermethode, um die jetzt verschlüsselte Präsentation zu speichern. 

Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation verschlüsseln:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Schreibschutz für eine Präsentation festlegen** 

Sie können ein Zeichen hinzufügen, das "Nicht ändern" angibt, zu einer Präsentation. Auf diese Weise sagen Sie den Benutzern, dass Sie nicht möchten, dass sie Änderungen an der Präsentation vornehmen.  

**Hinweis**: Der Schreibschutzprozess verschlüsselt die Präsentation nicht. Daher können Benutzer—wenn sie es wirklich wollen—die Präsentation ändern, aber um die Änderungen zu speichern, müssen sie eine Präsentation mit einem anderen Namen erstellen. 

Um einen Schreibschutz festzulegen, müssen Sie die Methode setWriteProtection verwenden. Dieser Beispielcode zeigt Ihnen, wie Sie einen Schreibschutz für eine Präsentation festlegen:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Eine Präsentation entschlüsseln; Eine verschlüsselte Präsentation öffnen**

Aspose.Slides erlaubt es Ihnen, eine verschlüsselte Datei zu laden, indem Sie ihr Passwort übergeben. Um eine Präsentation zu entschlüsseln, müssen Sie die Methode [RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) ohne Parameter aufrufen. Sie müssen dann das richtige Passwort eingeben, um die Präsentation zu laden. 

Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation entschlüsseln: 

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// Arbeiten mit der entschlüsselten Präsentation
```

## **Verschlüsselung entfernen; Passwortschutz deaktivieren**

Sie können die Verschlüsselung oder den Passwortschutz auf einer Präsentation entfernen. Auf diese Weise können Benutzer auf die Präsentation zugreifen oder sie ändern, ohne Einschränkungen. 

Um die Verschlüsselung oder den Passwortschutz zu entfernen, müssen Sie die Methode [RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) aufrufen. Dieser Beispielcode zeigt Ihnen, wie Sie die Verschlüsselung von einer Präsentation entfernen:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Schreibschutz von einer Präsentation entfernen**

Sie können Aspose.Slides verwenden, um den Schreibschutz, der auf einer Präsentationsdatei verwendet wird, zu entfernen. Auf diese Weise können Benutzer ändern, wie sie möchten - und sie erhalten keine Warnungen, wenn sie solche Aufgaben ausführen.

Sie können den Schreibschutz von einer Präsentation entfernen, indem Sie die Methode [RemoveWriteProtection](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50) verwenden. Dieser Beispielcode zeigt Ihnen, wie Sie den Schreibschutz von einer Präsentation entfernen:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Die Eigenschaften einer verschlüsselten Präsentation abrufen**

Typischerweise haben Benutzer Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder passwortgeschützten Präsentation zu erhalten. Aspose.Slides bietet jedoch einen Mechanismus, der es Ihnen ermöglicht, eine Präsentation passwortgeschützt zu machen, während die Benutzer die Möglichkeit behalten, auf die Eigenschaften dieser Präsentation zuzugreifen.

**Hinweis**: Wenn Aspose.Slides eine Präsentation verschlüsselt, werden die Dokumenteigenschaften der Präsentation standardmäßig auch passwortgeschützt. Wenn Sie jedoch möchten, dass die Eigenschaften der Präsentation zugänglich sind (auch nachdem die Präsentation verschlüsselt wurde), ermöglicht Ihnen Aspose.Slides genau dies. 

Wenn Sie möchten, dass Benutzer die Möglichkeit behalten, auf die Eigenschaften einer verschlüsselten Präsentation zuzugreifen, können Sie `true` an die Methode [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d) übergeben. Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation verschlüsseln und gleichzeitig die Möglichkeit bieten, auf die Dokumenteigenschaften zuzugreifen:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```

## **Überprüfen, ob eine Präsentation passwortgeschützt ist, bevor Sie sie laden**

Bevor Sie eine Präsentation laden, möchten Sie möglicherweise überprüfen und bestätigen, dass die Präsentation nicht mit einem Passwort geschützt ist. Auf diese Weise vermeiden Sie Fehler und ähnliche Probleme, die auftreten, wenn eine passwortgeschützte Präsentation ohne ihr Passwort geladen wird.

Dieser C++-Code zeigt Ihnen, wie Sie eine Präsentation überprüfen, um zu sehen, ob sie passwortgeschützt ist (ohne die Präsentation selbst zu laden):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"Die Präsentation ist passwortgeschützt: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Überprüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht es Ihnen zu überprüfen, ob eine Präsentation verschlüsselt ist. Um diese Aufgabe auszuführen, können Sie die Methode [get_IsEncrypted()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) verwenden, die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, oder `false`, wenn die Präsentation nicht verschlüsselt ist. 

Dieser Beispielcode zeigt Ihnen, wie Sie überprüfen, ob eine Präsentation verschlüsselt ist:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Überprüfen, ob eine Präsentation schreibgeschützt ist**

Aspose.Slides ermöglicht es Ihnen zu überprüfen, ob eine Präsentation schreibgeschützt ist. Um diese Aufgabe auszuführen, können Sie die Methode [get_IsWriteProtected()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) verwenden, die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, oder `false`, wenn die Präsentation nicht schreibgeschützt ist. 

Dieser Beispielcode zeigt Ihnen, wie Sie überprüfen, ob eine Präsentation schreibgeschützt ist:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Validierung oder Bestätigung, dass ein bestimmtes Passwort zum Schutz einer Präsentation verwendet wurde**

Sie möchten möglicherweise überprüfen und bestätigen, dass ein bestimmtes Passwort zum Schutz eines Präsentationsdokuments verwendet wurde. Aspose.Slides bietet die Mittel, um ein Passwort zu validieren. 

Dieser Beispielcode zeigt Ihnen, wie Sie ein Passwort validieren:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// Überprüfen, ob "pass" übereinstimmt
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Es gibt `true` zurück, wenn die Präsentation mit dem angegebenen Passwort verschlüsselt wurde. Andernfalls wird `false` zurückgegeben. 

{{% alert color="primary" title="Siehe auch" %}} 
- [Digitale Signatur in PowerPoint](/slides/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}