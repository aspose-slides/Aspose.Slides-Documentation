---
title: Sicher Präsentationen mit Passwörtern in C++
linktitle: Passwortschutz
type: docs
weight: 20
url: /de/cpp/password-protected-presentation/
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
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für C++ mühelos passwortgeschützte PowerPoint- und OpenDocument-Präsentationen sperren und entsperren können. Sichern Sie Ihre Präsentationen."
---

## **Über Passwortschutz**
### **Wie funktioniert Passwortschutz für Präsentationen?**
Wenn Sie eine Präsentation mit einem Passwort schützen, legen Sie ein Passwort fest, das bestimmte Einschränkungen für die Präsentation durchsetzt. Um die Einschränkungen zu entfernen, muss das Passwort eingegeben werden. Eine passwortgeschützte Präsentation wird als gesperrte Präsentation betrachtet.

Typischerweise können Sie ein Passwort festlegen, um diese Einschränkungen für eine Präsentation zu erzwingen:

- **Änderung**

  Wenn Sie nur bestimmten Benutzern erlauben möchten, Ihre Präsentation zu bearbeiten, können Sie eine Änderungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen Ihre Präsentation ändern, anpassen oder Inhalte kopieren (es sei denn, sie geben das Passwort ein).  

  Allerdings kann ein Benutzer in diesem Fall das Dokument auch ohne Passwort öffnen und darauf zugreifen. Im Nur-Lese-Modus kann der Benutzer die Inhalte Ihrer Präsentation – Hyperlinks, Animationen, Effekte und weitere – ansehen, jedoch keine Elemente kopieren oder die Präsentation speichern. 

- **Öffnen**

  Wenn Sie nur bestimmten Benutzern das Öffnen Ihrer Präsentation erlauben möchten, können Sie eine Öffnungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen überhaupt den Inhalt Ihrer Präsentation sehen können (es sei denn, sie geben das Passwort ein).

  Technisch verhindert die Öffnungsbeschränkung ebenfalls, dass Benutzer Ihre Präsentation ändern: Wenn Personen eine Präsentation nicht öffnen können, können sie sie auch nicht bearbeiten oder ändern.  

  **Hinweis**: Wenn Sie eine Präsentation mit einem Passwort schützen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## **Wie Sie eine Präsentation online mit einem Passwort schützen**
1. Rufen Sie unsere Seite [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) auf.  

   ![todo:image_alt_text](slides-lock.png)

2. Klicken Sie auf **Drop or upload your files**.

3. Wählen Sie die Datei aus, die Sie auf Ihrem Computer mit einem Passwort schützen möchten.

4. Geben Sie Ihr gewünschtes Passwort für den Bearbeitungsschutz ein; geben Sie Ihr gewünschtes Passwort für den Ansichtsschutz ein.

5. Wenn Sie möchten, dass Benutzer Ihre Präsentation als endgültige Kopie sehen, aktivieren Sie das Kontrollkästchen **Mark as final**.

6. Klicken Sie auf **PROTECT NOW.** 

7. Klicken Sie auf **DOWNLOAD NOW.**

## **Passwortschutz für Präsentationen in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Passwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in den folgenden Formaten: 

- PPTX und PPT – Microsoft PowerPoint-Präsentation 
- ODP – OpenDocument-Präsentation 
- OTP – OpenDocument-Präsentationsvorlage 

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht Passwortschutz für Präsentationen, um Änderungen auf folgende Weise zu verhindern:

- Verschlüsseln einer Präsentation
- Festlegen eines Schreibschutzes für eine Präsentation

**Weitere Vorgänge**

Aspose.Slides ermöglicht weitere Aufgaben im Zusammenhang mit Passwortschutz und Verschlüsselung auf folgende Weise:

- Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation
- Entfernen der Verschlüsselung; Deaktivieren des Passwortschutzes
- Entfernen des Schreibschutzes von einer Präsentation
- Abrufen der Eigenschaften einer verschlüsselten Präsentation
- Prüfen, ob eine Präsentation verschlüsselt ist
- Prüfen, ob eine Präsentation passwortgeschützt ist.

## **Eine Präsentation verschlüsseln**
Sie können eine Präsentation verschlüsseln, indem Sie ein Passwort festlegen. Um die gesperrte Präsentation zu ändern, muss der Benutzer das Passwort angeben.

Um eine Präsentation zu verschlüsseln oder passwortzuschützen, müssen Sie die encrypt‑Methode (aus [ProtectionManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager)) verwenden, um ein Passwort für die Präsentation festzulegen. Sie übergeben das Passwort an die encrypt‑Methode und verwenden die save‑Methode, um die nun verschlüsselte Präsentation zu speichern.

Der Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```


## **Schreibschutz für eine Präsentation festlegen**
Sie können einer Präsentation einen Hinweis „Do not modify“ hinzufügen. Auf diese Weise teilen Sie den Benutzern mit, dass Sie nicht möchten, dass sie Änderungen an der Präsentation vornehmen.

**Hinweis**: Der Schreibschutzvorgang verschlüsselt die Präsentation nicht. Daher können Benutzer – falls sie möchten – die Präsentation ändern, müssen jedoch zum Speichern der Änderungen eine Präsentation unter einem anderen Namen erstellen.

Um einen Schreibschutz festzulegen, müssen Sie die setWriteProtection‑Methode verwenden. Der Beispielcode zeigt, wie Sie einer Präsentation einen Schreibschutz hinzufügen:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```


## **Eine verschlüsselte Präsentation laden**
Aspose.Slides ermöglicht das Laden einer verschlüsselten Datei, indem das Passwort übergeben wird. Zum Entschlüsseln einer Präsentation müssen Sie die [RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d)-Methode ohne Parameter aufrufen. Anschließend müssen Sie das richtige Passwort eingeben, um die Präsentation zu laden.

Der Beispielcode zeigt, wie Sie eine Präsentation entschlüsseln:
``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// Arbeit mit entschlüsselter Präsentation
```


## **Verschlüsselung einer Präsentation entfernen**
Sie können die Verschlüsselung oder den Passwortschutz einer Präsentation entfernen. Damit können Benutzer die Präsentation ohne Einschränkungen öffnen oder ändern.

Um die Verschlüsselung oder den Passwortschutz zu entfernen, müssen Sie die [RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d)-Methode aufrufen. Der Beispielcode zeigt, wie Sie die Verschlüsselung einer Präsentation entfernen:
``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```


## **Schreibschutz einer Präsentation entfernen**
Mit Aspose.Slides können Sie den Schreibschutz einer Präsentationsdatei entfernen. Damit können Benutzer nach Belieben Änderungen vornehmen, ohne dass Warnungen angezeigt werden.

Sie können den Schreibschutz einer Präsentation mit der [RemoveWriteProtection](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50)-Methode entfernen. Der Beispielcode zeigt, wie Sie den Schreibschutz einer Präsentation entfernen:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```


## **Eigenschaften einer verschlüsselten Präsentation abrufen**
In der Regel haben Benutzer Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder passwortgeschützten Präsentation abzurufen. Aspose.Slides bietet jedoch einen Mechanismus, mit dem Sie eine Präsentation schützen können, während Benutzer weiterhin Zugriff auf deren Eigenschaften haben.

**Hinweis**: Wenn Aspose.Slides eine Präsentation verschlüsselt, werden die Dokumenteigenschaften der Präsentation standardmäßig ebenfalls passwortgeschützt. Wenn Sie jedoch die Eigenschaften der Präsentation auch nach der Verschlüsselung zugänglich machen müssen, ermöglicht Aspose.Slides genau das.

Wenn Sie möchten, dass Benutzer weiterhin die Möglichkeit haben, die Eigenschaften einer verschlüsselten Präsentation abzurufen, können Sie `true` an die [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d)-Methode übergeben. Der Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln und gleichzeitig den Zugriff auf deren Dokumenteigenschaften ermöglichen:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```


## **Prüfen, ob eine Präsentation passwortgeschützt ist**
Bevor Sie eine Präsentation laden, möchten Sie möglicherweise prüfen, ob die Präsentation nicht mit einem Passwort geschützt ist. So können Sie Fehler und ähnliche Probleme vermeiden, die auftreten, wenn eine passwortgeschützte Präsentation ohne Passwort geladen wird.

Der folgende C++‑Code zeigt, wie Sie eine Präsentation überprüfen können, ob sie passwortgeschützt ist (ohne die Präsentation selbst zu laden):
```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```


## **Prüfen, ob eine Präsentation verschlüsselt ist**
Aspose.Slides ermöglicht die Prüfung, ob eine Präsentation verschlüsselt ist. Dafür können Sie die Methode [get_IsEncrypted()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) verwenden, die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, und `false`, wenn sie nicht verschlüsselt ist.

Der Beispielcode zeigt, wie Sie prüfen, ob eine Präsentation verschlüsselt ist:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```


## **Prüfen, ob eine Präsentation schreibgeschützt ist**
Aspose.Slides ermöglicht die Prüfung, ob eine Präsentation schreibgeschützt ist. Dafür können Sie die Methode [get_IsWriteProtected()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) verwenden, die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, und `false`, wenn sie nicht schreibgeschützt ist.

Der Beispielcode zeigt, wie Sie prüfen, ob eine Präsentation schreibgeschützt ist:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```


## **Verifizieren der Passwortverwendung für eine Präsentation**
Möglicherweise möchten Sie prüfen, ob ein bestimmtes Passwort zum Schutz eines Präsentationsdokuments verwendet wurde. Aspose.Slides bietet die Möglichkeit, ein Passwort zu validieren.

Der Beispielcode zeigt, wie Sie ein Passwort validieren:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// prüfen ob "pass" übereinstimmt
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```


Er gibt `true` zurück, wenn die Präsentation mit dem angegebenen Passwort verschlüsselt wurde. Andernfalls gibt er `false` zurück.

{{% alert color="primary" title="Siehe auch" %}} 
- [Digitale Signatur in PowerPoint](/slides/de/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welche Verschlüsselungsmethoden unterstützt Aspose.Slides?**  
Aspose.Slides unterstützt moderne Verschlüsselungsmethoden, einschließlich AES-basierter Algorithmen, und bietet so ein hohes Maß an Datensicherheit für Ihre Präsentationen.

**Was passiert, wenn ein falsches Passwort beim Versuch, eine Präsentation zu öffnen, eingegeben wird?**  
Eine Ausnahme wird ausgelöst, wenn ein falsches Passwort verwendet wird, und warnt Sie, dass der Zugriff auf die Präsentation verweigert wird. Dies verhindert unbefugten Zugriff und schützt den Inhalt der Präsentation.

**Gibt es Leistungsauswirkungen beim Arbeiten mit passwortgeschützten Präsentationen?**  
Der Verschlüsselungs‑ und Entschlüsselungsprozess kann beim Öffnen und Speichern einen geringen Mehraufwand verursachen. In den meisten Fällen ist diese Auswirkung minimal und beeinträchtigt die Gesamtverarbeitungszeit Ihrer Präsentationsaufgaben kaum.