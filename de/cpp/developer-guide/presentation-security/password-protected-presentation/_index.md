---
title: Sichere Präsentationen mit Passwörtern in C++
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
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für C++ mühelos sperren und entsperren können. Schützen Sie Ihre Präsentationen."
---
## **Einleitung**

Wenn Sie eine Präsentation mit einem Passwort schützen, bedeutet dies, dass Sie ein Passwort festlegen, das bestimmte Einschränkungen für die Präsentation durchsetzt. Um die Einschränkungen zu entfernen, muss das Passwort eingegeben werden. Eine passwortgeschützte Präsentation wird als gesperrte Präsentation betrachtet.

Typischerweise können Sie ein Passwort festlegen, um diese Einschränkungen für eine Präsentation durchzusetzen:

- **Änderung**

  Wenn Sie möchten, dass nur bestimmte Benutzer Ihre Präsentation ändern können, können Sie eine Änderungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen Ihre Präsentation ändern, anpassen oder Inhalte kopieren (sofern sie nicht das Passwort angeben).

  In diesem Fall kann ein Benutzer jedoch auch ohne Passwort auf Ihr Dokument zugreifen und es öffnen. Im Nur-Lese‑Modus kann der Benutzer den Inhalt – Hyperlinks, Animationen, Effekte und andere Elemente – Ihrer Präsentation ansehen, aber keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

  Wenn Sie möchten, dass nur bestimmte Benutzer Ihre Präsentation öffnen können, können Sie eine Öffnungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen überhaupt den Inhalt Ihrer Präsentation sehen (sofern sie nicht das Passwort angeben).

  Technisch verhindert die Öffnungsbeschränkung ebenfalls, dass Benutzer Ihre Präsentationen ändern: Wenn Personen eine Präsentation nicht öffnen können, können sie sie nicht verändern oder bearbeiten.

  **Hinweis**: Wenn Sie eine Präsentation mit einem Passwort schützen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## **Wie Sie eine Präsentation online mit einem Passwort schützen**

1. Rufen Sie unsere [**Aspose.Slides Lock**](https://products.aspose.app/slides/de/lock) Seite auf. 

   ![todo:image_alt_text](slides-lock.png)

2. Klicken Sie auf **Drop or upload your files**.

3. Wählen Sie die Datei aus, die Sie auf Ihrem Computer mit einem Passwort schützen möchten. 

4. Geben Sie Ihr gewünschtes Passwort für den Editierschutz ein; geben Sie Ihr gewünschtes Passwort für den Ansichtsschutz ein. 

5. Wenn Sie möchten, dass Benutzer Ihre Präsentation als endgültige Kopie sehen, aktivieren Sie das Kontrollkästchen **Mark as final**.

6. Klicken Sie auf **PROTECT NOW.** 

7. Klicken Sie auf **DOWNLOAD NOW.**

## **Passwortschutz für Präsentationen in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Passwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in diesen Formaten: 

- PPTX und PPT - Microsoft PowerPoint Präsentation 
- ODP - OpenDocument Präsentation 
- OTP - OpenDocument Präsentationsvorlage 

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht es Ihnen, Passwortschutz für Präsentationen zu verwenden, um Änderungen auf folgende Weise zu verhindern:

- Verschlüsseln einer Präsentation
- Festlegen eines Schreibschutzes für eine Präsentation

**Weitere Vorgänge**

Aspose.Slides ermöglicht Ihnen, weitere Aufgaben im Zusammenhang mit Passwortschutz und Verschlüsselung auf folgende Weise durchzuführen:

- Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation
- Entfernen der Verschlüsselung; Deaktivieren des Passwortschutzes
- Entfernen des Schreibschutzes von einer Präsentation
- Abrufen der Eigenschaften einer verschlüsselten Präsentation
- Prüfen, ob eine Präsentation verschlüsselt ist
- Prüfen, ob eine Präsentation passwortgeschützt ist.

## **Verschlüsseln einer Präsentation**

Sie können eine Präsentation verschlüsseln, indem Sie ein Passwort festlegen. Um die gesperrte Präsentation zu ändern, muss ein Benutzer das Passwort angeben. 

Um eine Präsentation zu verschlüsseln oder passwortzu schützen, müssen Sie die `encrypt`‑Methode (aus [ProtectionManager](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.protection_manager)) verwenden, um ein Passwort für die Präsentation festzulegen. Sie übergeben das Passwort an die `encrypt`‑Methode und verwenden die `save`‑Methode, um die nun verschlüsselte Präsentation zu speichern. 

Dieses Beispiel demonstriert, wie Sie eine Präsentation verschlüsseln:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Schreibschutz für eine Präsentation festlegen** 

Sie können einer Präsentation einen Hinweis „Do not modify“ hinzufügen. Auf diese Weise können Sie Benutzern signalisieren, dass Sie nicht möchten, dass sie Änderungen an der Präsentation vornehmen.  

**Hinweis**: Der Schreibschutzvorgang verschlüsselt die Präsentation nicht. Daher können Benutzer – falls sie es wünschen – die Präsentation ändern, müssen jedoch zum Speichern der Änderungen eine Präsentation unter einem anderen Namen erstellen. 

Um einen Schreibschutz festzulegen, müssen Sie die `setWriteProtection`‑Methode verwenden. Dieses Beispiel zeigt, wie Sie einen Schreibschutz für eine Präsentation festlegen:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Laden einer verschlüsselten Präsentation**

Aspose.Slides ermöglicht das Laden einer verschlüsselten Datei durch Übergabe des Passworts. Um eine Präsentation zu entschlüsseln, müssen Sie die [RemoveEncryption](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d)‑Methode ohne Parameter aufrufen. Anschließend geben Sie das korrekte Passwort ein, um die Präsentation zu laden. 

Dieses Beispiel zeigt, wie Sie eine Präsentation entschlüsseln: 

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// Arbeiten mit entschlüsselter Präsentation
```

## **Verschlüsselung einer Präsentation entfernen**

Sie können die Verschlüsselung oder den Passwortschutz einer Präsentation entfernen. Damit können Benutzer die Präsentation ohne Einschränkungen öffnen oder ändern. 

Um die Verschlüsselung oder den Passwortschutz zu entfernen, müssen Sie die [RemoveEncryption](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d)‑Methode aufrufen. Dieses Beispiel zeigt, wie Sie die Verschlüsselung einer Präsentation entfernen:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Schreibschutz von einer Präsentation entfernen**

Sie können mit Aspose.Slides den Schreibschutz, der auf einer Präsentationsdatei angewendet wurde, entfernen. Damit können Benutzer nach Belieben Änderungen vornehmen – und erhalten dabei keine Warnungen. 

Sie können den Schreibschutz einer Präsentation mithilfe der [RemoveWriteProtection](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50)‑Methode entfernen. Dieses Beispiel zeigt, wie Sie den Schreibschutz einer Präsentation entfernen:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Eigenschaften einer verschlüsselten Präsentation abrufen**

Typischerweise haben Benutzer Probleme, die Dokumenteigenschaften einer verschlüsselten oder passwortgeschützten Präsentation abzurufen. Aspose.Slides bietet jedoch einen Mechanismus, mit dem Sie eine Präsentation passwortschützen können und gleichzeitig Zugriff auf ihre Dokumenteigenschaften ermöglichen.

**Hinweis:** Standardmäßig werden beim Verschlüsseln einer Präsentation durch Aspose.Slides auch die Dokumenteigenschaften der Präsentation passwortgeschützt. Wenn Sie die Dokumenteigenschaften auch nach der Verschlüsselung zugänglich machen möchten, ermöglicht Ihnen Aspose.Slides genau das.

Wenn Sie Benutzern weiterhin ermöglichen wollen, auf die Eigenschaften einer verschlüsselten Präsentation zuzugreifen, übergeben Sie `false` an die `set_EncryptDocumentProperties`‑Methode von [IProtectionManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/iprotectionmanager/). Dieses Beispiel zeigt, wie Sie eine Präsentation verschlüsseln und gleichzeitig den Benutzern Zugriff auf die Dokumenteigenschaften gewähren:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Nur Dokumenteigenschaften einer verschlüsselten Präsentation laden**

Um die Metadaten einer verschlüsselten Präsentation zu prüfen, ohne deren Folien oder anderen Inhalt zu laden, erstellen Sie ein [LoadOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/)‑Objekt und setzen Sie [set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) auf `true`. In diesem Modus ignoriert Aspose.Slides das Passwort und lädt nur die öffentlich zugänglichen Dokumenteigenschaften.

Der folgende Code liest integrierte und benutzerdefinierte Dokumenteigenschaften über [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/get_documentproperties/):

``` cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);
auto documentProperties = presentation->get_DocumentProperties();

// Read built-in document properties.
auto title = documentProperties->get_Title();
auto author = documentProperties->get_Author();
Console::WriteLine(String(u"Title: ") + title);
Console::WriteLine(String(u"Author: ") + author);

// Read custom document properties.
int customPropertyCount = documentProperties->get_CountOfCustomProperties();

for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(propertyIndex);
    auto propertyValue = documentProperties->idx_get(propertyName);
    auto propertyValueText = ObjectExt::ToString(propertyValue);

    Console::WriteLine(propertyName + u": " + propertyValueText);
}

presentation->Dispose();
```

Dieser Workflow funktioniert nur, wenn die Dokumenteigenschaften beim Verschlüsseln der Präsentation unverschlüsselt (öffentlich) gelassen wurden. Sind die Dokumenteigenschaften verschlüsselt, führt das Setzen von `LoadOptions::set_OnlyLoadDocumentProperties` auf `true` zu einer Ausnahme, da das Passwort in diesem Modus ignoriert wird. Um verschlüsselte Dokumenteigenschaften zuzugreifen oder die komplette Präsentation einschließlich Folien und anderem Inhalt zu laden, übergeben Sie das korrekte Passwort mit `LoadOptions::set_Password` in [LoadOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/).

## **Überprüfen, ob eine Präsentation passwortgeschützt ist**

Bevor Sie eine Präsentation laden, möchten Sie eventuell prüfen, ob die Präsentation nicht mit einem Passwort geschützt ist. So vermeiden Sie Fehler und ähnliche Probleme, die auftreten, wenn eine passwortgeschützte Präsentation ohne das entsprechende Passwort geladen wird.

Dieser C++‑Code zeigt, wie Sie eine Präsentation untersuchen, um festzustellen, ob sie passwortgeschützt ist (ohne die Präsentation selbst zu laden):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Überprüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht die Prüfung, ob eine Präsentation verschlüsselt ist. Verwenden Sie dazu die [get_IsEncrypted()](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68)‑Methode, die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, bzw. `false`, wenn sie nicht verschlüsselt ist. 

Dieses Beispiel demonstriert, wie Sie prüfen, ob eine Präsentation verschlüsselt ist:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Überprüfen, ob eine Präsentation schreibgeschützt ist**

Aspose.Slides ermöglicht die Prüfung, ob eine Präsentation schreibgeschützt ist. Verwenden Sie dazu die [get_IsWriteProtected()](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2)‑Methode, die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, bzw. `false`, wenn sie nicht schreibgeschützt ist. 

Dieses Beispiel zeigt, wie Sie prüfen, ob eine Präsentation schreibgeschützt ist:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Verifizieren der Passwortverwendung für die Präsentation**

Vielleicht möchten Sie prüfen und bestätigen, dass ein bestimmtes Passwort zum Schutz eines Präsentationsdokuments verwendet wurde. Aspose.Slides stellt Mittel bereit, um ein Passwort zu validieren. 

Dieses Beispiel zeigt, wie Sie ein Passwort validieren:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// prüfen, ob "pass" übereinstimmt mit
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Es gibt `true` zurück, wenn die Präsentation mit dem angegebenen Passwort verschlüsselt wurde. Andernfalls wird `false` zurückgegeben. 

{{% alert color="primary" title="Siehe auch" %}} 
- [Digitale Signatur in PowerPoint](/slides/de/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welche Verschlüsselungsmethoden werden von Aspose.Slides unterstützt?**

Aspose.Slides unterstützt moderne Verschlüsselungsmethoden, einschließlich AES‑basierter Algorithmen, und gewährleistet ein hohes Maß an Datensicherheit für Ihre Präsentationen.

**Was passiert, wenn beim Versuch, eine Präsentation zu öffnen, ein falsches Passwort eingegeben wird?**

Es wird eine Ausnahme ausgelöst, wenn ein falsches Passwort verwendet wird, wodurch Sie erfahren, dass der Zugriff auf die Präsentation verweigert wird. Dies hilft, unautorisierten Zugriff zu verhindern und den Präsentationsinhalt zu schützen.

**Gibt es Leistungseinbußen bei der Arbeit mit passwortgeschützten Präsentationen?**

Der Vorgang des Verschlüsselns und Entschlüsselns kann beim Öffnen und Speichern einen leichten Mehraufwand verursachen. In den meisten Fällen ist dieser Einfluss gering und beeinträchtigt die Gesamtausführungszeit Ihrer Präsentationsaufgaben kaum.