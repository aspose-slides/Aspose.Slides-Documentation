---
title: "Sichere Präsentationen mit Passwörtern in C++"
linktitle: "Passwortschutz"
type: docs
weight: 20
url: /de/cpp/password-protected-presentation/
keywords:
- "PowerPoint sperren"
- "Präsentation sperren"
- "PowerPoint entsperren"
- "Präsentation entsperren"
- "PowerPoint schützen"
- "Präsentation schützen"
- "Passwort festlegen"
- "Passwort hinzufügen"
- "PowerPoint verschlüsseln"
- "Präsentation verschlüsseln"
- "PowerPoint entschlüsseln"
- "Präsentation entschlüsseln"
- "Schreibschutz"
- "PowerPoint Sicherheit"
- "Präsentationssicherheit"
- "Passwort entfernen"
- "Schutz entfernen"
- "Verschlüsselung entfernen"
- "Passwort deaktivieren"
- "Schutz deaktivieren"
- "Schreibschutz entfernen"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- "C++"
- "Aspose.Slides"
description: "Erfahren Sie, wie Sie mit Aspose.Slides für C++ mühelos passwortgeschützte PowerPoint- und OpenDocument-Präsentationen sperren und entsperren können. Schützen Sie Ihre Präsentationen."
---
## **Einführung**

Wenn Sie eine Präsentation mit einem Kennwort schützen, setzen Sie ein Kennwort, das bestimmte Einschränkungen für die Präsentation durchsetzt. Um die Einschränkungen zu entfernen, muss das Kennwort eingegeben werden. Eine kennwortgeschützte Präsentation gilt als gesperrte Präsentation.

Typischerweise können Sie ein Kennwort festlegen, um diese Einschränkungen für eine Präsentation durchzusetzen:

- **Änderung**

  Wenn Sie nur bestimmten Benutzern erlauben möchten, Ihre Präsentation zu bearbeiten, können Sie eine Änderungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen Ihre Präsentation ändern, verändern oder Inhalte kopieren (es sei denn, sie geben das Kennwort an).

  Allerdings kann ein Benutzer in diesem Fall, selbst ohne Kennwort, auf Ihr Dokument zugreifen und es öffnen. Im Nur‑Lese‑Modus kann der Benutzer den Inhalt – Hyperlinks, Animationen, Effekte und andere – Ihrer Präsentation anzeigen, jedoch keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

  Wenn Sie nur bestimmten Benutzern das Öffnen Ihrer Präsentation erlauben möchten, können Sie eine Öffnungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen überhaupt den Inhalt Ihrer Präsentation sehen können (es sei denn, sie geben das Kennwort an).

  Technisch verhindert die Öffnungsbeschränkung ebenfalls, dass Benutzer Ihre Präsentationen ändern: Wenn Personen eine Präsentation nicht öffnen können, können sie sie nicht ändern oder bearbeiten.  

  **Hinweis** dass, wenn Sie eine Präsentation zum Schutz vor dem Öffnen kennwortschützen, die Präsentationsdatei verschlüsselt wird.

## **Wie Sie eine Präsentation online kennwortschützen**

1. Rufen Sie unsere Seite [**Aspose.Slides Lock**](https://products.aspose.app/slides/de/lock) auf. 

   ![todo:image_alt_text](slides-lock.png)

2. Klicken Sie auf **Drop or upload your files**.

3. Wählen Sie die Datei aus, die Sie auf Ihrem Computer kennwortschützen möchten. 

4. Geben Sie Ihr bevorzugtes Kennwort für den Editierschutz ein; geben Sie Ihr bevorzugtes Kennwort für den Ansichtsschutz ein. 

5. Wenn Sie möchten, dass Benutzer Ihre Präsentation als endgültige Kopie sehen, aktivieren Sie das Kontrollkästchen **Mark as final**.

6. Klicken Sie auf **PROTECT NOW.** 

7. Klicken Sie auf **DOWNLOAD NOW.**

## **Kennwortschutz für Präsentationen in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Kennwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in den folgenden Formaten: 

- PPTX und PPT – Microsoft PowerPoint Präsentation 
- ODP – OpenDocument Präsentation 
- OTP – OpenDocument Präsentationsvorlage 

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht den Kennwortschutz für Präsentationen, um Änderungen auf folgende Weise zu verhindern:

- Verschlüsseln einer Präsentation
- Festlegen eines Schreibschutzes für eine Präsentation

**Weitere Vorgänge**

Aspose.Slides ermöglicht weitere Aufgaben im Zusammenhang mit Kennwortschutz und Verschlüsselung auf folgende Weise:

- Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation
- Entfernen der Verschlüsselung; Deaktivieren des Kennwortschutzes
- Entfernen des Schreibschutzes von einer Präsentation
- Abrufen der Eigenschaften einer verschlüsselten Präsentation
- Prüfen, ob eine Präsentation verschlüsselt ist
- Prüfen, ob eine Präsentation kennwortgeschützt ist.

## **Eine Präsentation verschlüsseln**

Sie können eine Präsentation durch Festlegen eines Kennworts verschlüsseln. Um die gesperrte Präsentation zu ändern, muss ein Benutzer das Kennwort angeben. 

Um eine Präsentation zu verschlüsseln oder kennwortgeschützt zu machen, müssen Sie die encrypt‑Methode (aus [ProtectionManager](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.protection_manager)) verwenden, um ein Kennwort für die Präsentation festzulegen. Sie übergeben das Kennwort an die encrypt‑Methode und verwenden die save‑Methode, um die nun verschlüsselte Präsentation zu speichern. 

Dieses Beispiel zeigt, wie Sie eine Präsentation verschlüsseln:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Schreibschutz für eine Präsentation festlegen** 

Sie können einer Präsentation eine Markierung mit dem Hinweis „Do not modify“ hinzufügen. Auf diese Weise teilen Sie den Benutzern mit, dass Sie nicht möchten, dass sie Änderungen an der Präsentation vornehmen.  

**Hinweis** dass der Schreibschutz die Präsentation nicht verschlüsselt. Daher können Benutzer – falls sie möchten – die Präsentation ändern, aber um die Änderungen zu speichern, müssen sie die Präsentation unter einem anderen Namen speichern. 

Um einen Schreibschutz zu setzen, müssen Sie die setWriteProtection‑Methode verwenden. Dieses Beispiel zeigt, wie Sie einer Präsentation einen Schreibschutz zuweisen:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Eine verschlüsselte Präsentation laden**

Aspose.Slides ermöglicht das Laden einer verschlüsselten Datei, indem das Kennwort übergeben wird. Um eine Präsentation zu entschlüsseln, müssen Sie die [RemoveEncryption](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d)‑Methode ohne Parameter aufrufen. Anschließend müssen Sie das korrekte Kennwort eingeben, um die Präsentation zu laden. 

Dieses Beispiel zeigt, wie Sie eine Präsentation entschlüsseln: 

``` cpp
#include <DOM/LoadOptions.h>
using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// mit entschlüsselter Präsentation arbeiten
```

## **Verschlüsselung einer Präsentation entfernen**

Sie können die Verschlüsselung oder den Kennwortschutz einer Präsentation entfernen. Auf diese Weise können Benutzer die Präsentation ohne Einschränkungen öffnen oder ändern. 

Um die Verschlüsselung oder den Kennwortschutz zu entfernen, müssen Sie die [RemoveEncryption](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d)‑Methode aufrufen. Dieses Beispiel zeigt, wie Sie die Verschlüsselung einer Präsentation entfernen:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Schreibschutz von einer Präsentation entfernen**

Sie können Aspose.Slides verwenden, um den Schreibschutz einer Präsentationsdatei zu entfernen. Auf diese Weise können Benutzer nach Belieben Änderungen vornehmen – und sie erhalten keine Warnungen, wenn sie solche Aufgaben ausführen.

Sie können den Schreibschutz einer Präsentation mithilfe der [RemoveWriteProtection](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50)‑Methode entfernen. Dieses Beispiel zeigt, wie Sie den Schreibschutz einer Präsentation entfernen:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Eigenschaften einer verschlüsselten Präsentation abrufen**

Typischerweise haben Benutzer Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder kennwortgeschützten Präsentation abzurufen. Aspose.Slides bietet jedoch einen Mechanismus, der es ermöglicht, eine Präsentation zu kennwortschützen und gleichzeitig den Zugriff auf ihre Dokumenteigenschaften zu ermöglichen.

**Hinweis:** Standardmäßig werden beim Verschlüsseln einer Präsentation durch Aspose.Slides die Dokumenteigenschaften der Präsentation ebenfalls kennwortgeschützt. Wenn Sie die Dokumenteigenschaften nach der Verschlüsselung weiterhin zugänglich machen müssen, ermöglicht Aspose.Slides genau das.

Wenn Sie möchten, dass Benutzer weiterhin Zugriff auf die Eigenschaften einer verschlüsselten Präsentation haben, übergeben Sie `false` an die Methode `set_EncryptDocumentProperties` von [IProtectionManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/iprotectionmanager/). Dieses Beispiel zeigt, wie Sie eine Präsentation verschlüsseln und gleichzeitig den Benutzern Zugriff auf ihre Dokumenteigenschaften gewähren:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Nur Dokumenteigenschaften einer verschlüsselten Präsentation laden**

Um die Metadaten einer verschlüsselten Präsentation zu prüfen, ohne ihre Folien oder andere Inhalte zu laden, erstellen Sie ein [LoadOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/)‑Objekt und setzen Sie [set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) auf `true`. In diesem Modus ignoriert Aspose.Slides das Kennwort und lädt nur die öffentlich zugänglichen Dokumenteigenschaften.

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

Dieser Workflow funktioniert nur, wenn die Dokumenteigenschaften bei der Verschlüsselung der Präsentation nicht verschlüsselt (öffentlich) gelassen wurden. Sind die Dokumenteigenschaften verschlüsselt, führt das Setzen von `LoadOptions::set_OnlyLoadDocumentProperties` auf `true` zu einer Ausnahme, weil das Kennwort in diesem Modus ignoriert wird. Um verschlüsselte Dokumenteigenschaften zuzugreifen oder die gesamte Präsentation, einschließlich Folien und anderer Inhalte, zu laden, geben Sie das korrekte Kennwort mit `LoadOptions::set_Password` in [LoadOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/) an.

## **Überprüfen, ob eine Präsentation kennwortgeschützt ist**

Bevor Sie eine Präsentation laden, möchten Sie möglicherweise prüfen und bestätigen, dass die Präsentation nicht mit einem Kennwort geschützt ist. So vermeiden Sie Fehler und ähnliche Probleme, die auftreten, wenn eine kennwortgeschützte Präsentation ohne Kennwort geladen wird.

Dieser C++‑Code zeigt, wie Sie eine Präsentation untersuchen, um festzustellen, ob sie kennwortgeschützt ist (ohne die Präsentation selbst zu laden):

```c++
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Überprüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht das Prüfen, ob eine Präsentation verschlüsselt ist. Hierzu können Sie die [get_IsEncrypted()](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68)‑Methode verwenden, die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, bzw. `false`, wenn sie nicht verschlüsselt ist. 

Dieses Beispiel zeigt, wie Sie prüfen, ob eine Präsentation verschlüsselt ist:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Überprüfen, ob eine Präsentation schreibgeschützt ist**

Aspose.Slides ermöglicht das Prüfen, ob eine Präsentation schreibgeschützt ist. Hierzu können Sie die [get_IsWriteProtected()](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2)‑Methode verwenden, die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, bzw. `false`, wenn sie nicht schreibgeschützt ist. 

Dieses Beispiel zeigt, wie Sie prüfen, ob eine Präsentation schreibgeschützt ist:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Verifizieren der Passwortverwendung für eine Präsentation**

Sie möchten möglicherweise prüfen und bestätigen, dass ein bestimmtes Kennwort verwendet wurde, um ein Präsentationsdokument zu schützen. Aspose.Slides stellt Mittel bereit, um ein Kennwort zu validieren. 

Dieses Beispiel zeigt, wie Sie ein Kennwort validieren:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// prüfen ob "pass" übereinstimmt
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Es gibt `true` zurück, wenn die Präsentation mit dem angegebenen Kennwort verschlüsselt wurde. Andernfalls gibt es `false` zurück. 

{{% alert color="info" title="Siehe auch" %}} 
- [Digitale Signatur in PowerPoint](/slides/de/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welche Verschlüsselungsmethoden werden von Aspose.Slides unterstützt?**

Aspose.Slides unterstützt moderne Verschlüsselungsverfahren, einschließlich AES‑basierter Algorithmen, und gewährleistet ein hohes Maß an Datensicherheit für Ihre Präsentationen.

**Was passiert, wenn beim Versuch, eine Präsentation zu öffnen, ein falsches Kennwort eingegeben wird?**

Es wird eine Ausnahme ausgelöst, wenn ein falsches Kennwort verwendet wird, und Sie werden darüber informiert, dass der Zugriff auf die Präsentation verweigert wird. Dies hilft, unbefugten Zugriff zu verhindern und den Inhalt der Präsentation zu schützen.

**Gibt es Leistungs Auswirkungen bei der Arbeit mit kennwortgeschützten Präsentationen?**

Der Verschlüsselungs‑ und Entschlüsselungsprozess kann beim Öffnen und Speichern einen leichten Overhead verursachen. In den meisten Fällen ist diese Auswirkung minimal und beeinträchtigt die Gesamtverarbeitungszeit Ihrer Präsentationsaufgaben nicht wesentlich.