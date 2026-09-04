---
title: Passwortgeschützte Präsentationen in C++
linktitle: Passwortschutz
type: docs
weight: 20
url: /de/cpp/password-protected-presentation/
keywords:
- passwortgeschützte Präsentation
- Öffnungskennwort
- PowerPoint verschlüsseln
- PowerPoint entschlüsseln
- Präsentationskennwort validieren
- Präsentationskennwort prüfen
- verschlüsselte Präsentation öffnen
- Verschlüsselung entfernen
- PowerPoint
- PPT
- PPTX
- Präsentation
- C++
- Aspose.Slides
description: "Verschlüsseln, erkennen, validieren, öffnen und entschlüsseln von passwortgeschützten PowerPoint PPT- und PPTX-Präsentationen in C++ mit Aspose.Slides."
---
## **Übersicht**

Ein Öffnungskennwort verschlüsselt eine Präsentation. Das korrekte Kennwort ist erforderlich, um die Präsentationsinhalte zu laden und anzuzeigen, sodass dieser Schutz Vertraulichkeit gewährleistet.

Ein Öffnungskennwort unterscheidet sich von einem Schreibschutzkennwort. Der Schreibschutz beschränkt Änderungen, verschlüsselt aber nicht den Inhalt und verhindert nicht das Laden der Präsentation. Zum Verwalten von Kennwörtern zum Ändern von Präsentationen siehe [Write-Protect Presentations](/slides/de/cpp/write-protected-presentation/).

Die nachstehenden Workflows gelten für sowohl PPT- als auch PPTX-Präsentationen. Die Beispiele verwenden beide Formate, wenn ihr dateibasiertes und streambasiertes Verhalten wichtig ist.

## **Eine Präsentation mit einem Öffnungskennwort verschlüsseln**

Verwenden Sie [IProtectionManager::Encrypt](https://reference.aspose.com/slides/de/cpp/aspose.slides/iprotectionmanager/encrypt/), um ein Öffnungskennwort zuzuweisen. Anschließend verwenden Sie [IPresentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/save/), um die verschlüsselte Präsentation zu speichern.

Das folgende Beispiel verschlüsselt eine PPTX‑Präsentation:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Dokumenteigenschaften öffentlich lassen**

Standardmäßig schließt Aspose.Slides Dokumenteigenschaften in die Präsentationsverschlüsselung ein. [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) steuert dieses Verhalten unabhängig von der Folieninhaltverschlüsselung. Übergeben Sie `false` an diese Methode, bevor Sie [IProtectionManager::Encrypt](https://reference.aspose.com/slides/de/cpp/aspose.slides/iprotectionmanager/encrypt/) aufrufen, wenn ein Indexierungs-, Klassifizierungs-, Such- oder Dokumentenverwaltungssystem Metadaten ohne das Öffnungskennwort lesen muss.

Das folgende Beispiel erstellt eine verschlüsselte PPTX‑Präsentation und lässt dabei die integrierten Dokumenteigenschaften öffentlich:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto properties = presentation->get_DocumentProperties();
properties->set_Author(u"Contoso Knowledge Management");
properties->set_Title(u"Quarterly Product Roadmap");
properties->set_Keywords(u"roadmap, planning, internal");

presentation->get_Slide(0)->set_Name(u"Encrypted presentation content");
presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"public-properties-encrypted.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Das Übergeben von `false` an `set_EncryptDocumentProperties` macht nicht Folien, Master, Layouts, Formen, Medien oder andere Präsentationsinhalte öffentlich. Es wirkt sich nur auf Dokumenteigenschaften aus. Um diese Eigenschaften zu lesen, ohne den verschlüsselten Inhalt zu laden, siehe [Manage Presentation Properties](/slides/de/cpp/presentation-properties/).

## **Eine verschlüsselte Präsentation laden**

Setzen Sie [LoadOptions::set_Password](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_password/) auf das Öffnungskennwort und übergeben Sie die Optionen an [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/), wenn Sie die Datei laden. Das Laden schlägt fehl, wenn ein Öffnungskennwort erforderlich ist, das angegebene Kennwort jedoch fehlt oder falsch ist.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Arbeiten mit der entschlüsselten Präsentation.
```

## **Verschlüsselung einer Präsentation entfernen**

Laden Sie die Präsentation mit ihrem Öffnungskennwort, rufen Sie [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/de/cpp/aspose.slides/iprotectionmanager/removeencryption/) auf und speichern Sie das Ergebnis. Die gespeicherte Präsentation kann anschließend ohne Kennwort geladen werden.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Ein Öffnungskennwort vor dem Laden validieren**

Verwenden Sie [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/), um [IPresentationInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/) zu erhalten, ohne eine vollständige Präsentationsinstanz zu erstellen. Überprüfen Sie [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/), bevor Sie ein Kennwort anfordern oder validieren. Wenn ein Schutz vorhanden ist, validieren Sie den angegebenen Wert mit [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Dateipfad-Workflow**

Das folgende Beispiel validiert ein Öffnungskennwort für eine PPTX-Datei, übergibt den validierten Wert an [LoadOptions::set_Password](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_password/) und lädt anschließend die komplette Präsentation:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

String filePath = u"protected-presentation.pptx";
String password = u"open_password";
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(filePath, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Stream-Workflow**

Die Stream‑Überladung von [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) bietet den gleichen Workflow. Setzen Sie die Position eines suchbaren Streams zurück, bevor Sie die vollständige Präsentation aus diesem Stream laden.

Das folgende Beispiel verwendet eine PPT-Datei:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

String password = u"open_password";
auto presentationStream = File::OpenRead(u"protected-presentation.ppt");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(presentationStream);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    presentationStream->set_Position(0);

    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(presentationStream, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Rückgabewerte von CheckPassword**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/checkpassword/) gibt `true` nur zurück, wenn die Präsentation ein Öffnungskennwort hat und das angegebene Kennwort korrekt ist. Es gibt `false` in jedem dieser Fälle zurück:

- Das Kennwort ist falsch.
- Die Präsentation hat kein Öffnungskennwort.
- Das angegebene Kennwort ist null oder leer.

Das Verhalten ist für PPT‑ und PPTX‑Präsentationen identisch.

## **Überprüfen, ob eine geladene Präsentation verschlüsselt ist**

Nachdem Sie eine Präsentation mit dem korrekten Kennwort geladen haben, prüfen Sie [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/de/cpp/aspose.slides/iprotectionmanager/get_isencrypted/), um zu bestätigen, dass die Quellpräsentation verschlüsselt war. Um den Öffnungskennwortschutz vor dem Laden zu erkennen, verwenden Sie `IPresentationInfo::get_IsPasswordProtected` wie oben gezeigt.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");
auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
Console::WriteLine(isEncrypted ? u"The presentation is encrypted." : u"The presentation is not encrypted.");
```

## **Sicherheitsempfehlungen**

{{% alert color="warning" title="Sicherheit" %}}
Protokollieren Sie Öffnungskennwörter nicht und fügen Sie sie nicht in Diagnosemeldungen ein. Vermeiden Sie unnötige wiederholte Validierungsversuche, halten Sie Kennwörter nur so lange im Speicher, wie sie benötigt werden, und verwenden Sie ein erfolgreiches Validierungsergebnis erneut, wenn die Präsentation sofort geladen wird.

Öffentliche Dokumenteigenschaften können Autorennamen, Titel, Themen, Schlüsselwörter, Unternehmensinformationen, Kommentare und benutzerdefinierte Werte offenlegen, obwohl der Präsentationsinhalt verschlüsselt ist. Verschlüsseln Sie sensible Metadaten zusammen mit der Präsentation. Das öffentliche Belassen von Eigenschaften sollte eine bewusste Entscheidung sein, die nur getroffen wird, wenn Systeme die Datei ohne Öffnungskennwort indexieren, klassifizieren, durchsuchen oder verwalten müssen.
{{% /alert %}}

## **Eine Präsentation online kennwortschützen**

1. Öffnen Sie die Anwendung [Aspose.Slides Lock](https://products.aspose.app/slides/de/lock).
1. Wählen Sie die Präsentation aus oder laden Sie sie hoch.
1. Geben Sie ein Kennwort für den Ansichtsschutz ein.
1. Geben Sie optional ein separates Kennwort für den Bearbeitungsschutz ein.
1. Wenden Sie den Schutz an und laden Sie die resultierende Datei herunter.

{{% alert color="info" title="Siehe auch" %}}
- [Write-Protect Presentations](/slides/de/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/de/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einem Öffnungskennwort und einem Schreibschutzkennwort?**

Ein Öffnungskennwort verschlüsselt die Präsentation und ist erforderlich, um deren Inhalt zu laden. Ein Schreibschutzkennwort beschränkt die Änderung, ohne den Inhalt zu verschlüsseln.

**Kann ich ein Öffnungskennwort validieren, ohne alle Folien zu laden?**

Ja. Holen Sie die Präsentationsinformationen, prüfen Sie, ob ein Öffnungskennwortschutz vorhanden ist, und validieren Sie das Kennwort, bevor Sie eine vollständige Präsentationsinstanz erstellen.

**Kann eine Anwendung Metadaten ohne das Öffnungskennwort lesen?**

Ja, jedoch nur, wenn die Präsentation mit `set_EncryptDocumentProperties(false)` verschlüsselt wurde. Die Anwendung muss dann den nur‑Dokument‑Eigenschaften‑Lademodus verwenden, der in [Manage Presentation Properties](/slides/de/cpp/presentation-properties/) beschrieben ist.

**Unterstützen die Kennwort‑Überprüfungs‑Workflows sowohl PPT als auch PPTX?**

Ja. Dateipfad- und streambasierte Kennworterkennung und -validierung verhalten sich bei PPT‑ und PPTX‑Präsentationen gleich.