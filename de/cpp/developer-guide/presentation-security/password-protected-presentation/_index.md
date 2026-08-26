---
title: Passwortschutz für Präsentationen in C++
linktitle: Passwortschutz
type: docs
weight: 20
url: /de/cpp/password-protected-presentation/
keywords:
- passwortgeschützte Präsentation
- Öffnungspasswort
- PowerPoint verschlüsseln
- PowerPoint entschlüsseln
- Präsentationspasswort validieren
- Präsentationspasswort prüfen
- verschlüsselte Präsentation öffnen
- Verschlüsselung entfernen
- PowerPoint
- PPT
- PPTX
- Präsentation
- C++
- Aspose.Slides
description: "Verschlüsseln, Erkennen, Validieren, Öffnen und Entschlüsseln passwortgeschützter PowerPoint PPT- und PPTX-Präsentationen in C++ mit Aspose.Slides."
---
## **Übersicht**

Ein Öffnungspasswort verschlüsselt eine Präsentation. Das korrekte Passwort ist erforderlich, um die Präsentationsinhalte zu laden und anzuzeigen, sodass dieser Schutz Vertraulichkeit bietet.

Ein Öffnungspasswort unterscheidet sich von einem Schreibschutz‑Passwort. Der Schreibschutz beschränkt die Bearbeitung, verschlüsselt jedoch nicht den Inhalt und verhindert nicht das Laden der Präsentation. Um Passwörter für die Bearbeitung von Präsentationen zu verwalten, siehe [Write-Protect Presentations](/slides/de/cpp/write-protected-presentation/).

Die nachstehenden Workflows gelten sowohl für PPT- als auch für PPTX-Präsentationen. Die Beispiele verwenden beide Formate, wo ihr dateibasiertes und strombasiertes Verhalten wichtig ist.

## **Verschlüsseln einer Präsentation mit einem Öffnungspasswort**

Verwenden Sie [IProtectionManager::Encrypt](https://reference.aspose.com/slides/de/cpp/aspose.slides/iprotectionmanager/encrypt/), um ein Öffnungspasswort zuzuweisen. Verwenden Sie anschließend [IPresentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/save/), um die verschlüsselte Präsentation zu speichern.

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

## **Laden einer verschlüsselten Präsentation**

Setzen Sie [LoadOptions::set_Password](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_password/) auf das Öffnungspasswort und übergeben Sie die Optionen beim Laden der Datei an [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/). Das Laden schlägt fehl, wenn ein Öffnungspasswort erforderlich ist, das bereitgestellte Passwort jedoch fehlt oder falsch ist.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Arbeiten Sie mit der entschlüsselten Präsentation.
```

## **Entfernen der Verschlüsselung aus einer Präsentation**

Laden Sie die Präsentation mit ihrem Öffnungspasswort, rufen Sie [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/de/cpp/aspose.slides/iprotectionmanager/removeencryption/) auf und speichern Sie das Ergebnis. Die gespeicherte Präsentation kann anschließend ohne Passwort geladen werden.

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

## **Validieren eines Öffnungspassworts vor dem Laden**

Verwenden Sie [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/), um [IPresentationInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/) zu erhalten, ohne eine vollständige Präsentationsinstanz zu erstellen. Prüfen Sie [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/), bevor Sie ein Passwort anfordern oder validieren. Ist ein Schutz vorhanden, validieren Sie den bereitgestellten Wert mit [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Dateipfad-Workflow**

Das folgende Beispiel validiert ein Öffnungspasswort für eine PPTX‑Datei, übergibt den validierten Wert an [LoadOptions::set_Password](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_password/) und lädt anschließend die vollständige Präsentation:

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

### **Strom-Workflow**

Die Stream‑Überladung von [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) bietet denselben Workflow. Setzen Sie die Position eines seekfähigen Streams zurück, bevor Sie die vollständige Präsentation aus diesem Stream laden.

Das folgende Beispiel verwendet eine PPT‑Datei:

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

### **CheckPassword Rückgabewerte**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/checkpassword/) gibt `true` zurück, nur wenn die Präsentation ein Öffnungspasswort hat und das bereitgestellte Passwort korrekt ist. Es gibt `false` zurück in jedem dieser Fälle:

- Das Passwort ist falsch.
- Die Präsentation hat kein Öffnungspasswort.
- Das bereitgestellte Passwort ist null oder leer.

Das Verhalten ist für PPT‑ und PPTX‑Präsentationen identisch.

## **Prüfen, ob eine geladene Präsentation verschlüsselt ist**

Nachdem Sie eine Präsentation mit dem korrekten Passwort geladen haben, prüfen Sie [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/de/cpp/aspose.slides/iprotectionmanager/get_isencrypted/), um zu bestätigen, dass die Quellpräsentation verschlüsselt war. Um den Öffnungspasswortschutz vor dem Laden zu erkennen, verwenden Sie `IPresentationInfo::get_IsPasswordProtected` wie oben gezeigt.

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
Protokollieren Sie Öffnungspasswörter nicht und fügen Sie sie nicht in Diagnosemeldungen ein. Vermeiden Sie unnötige wiederholte Validierungsversuche, halten Sie Passwörter nur so lange im Speicher, wie sie benötigt werden, und verwenden Sie ein erfolgreiches Validierungsergebnis erneut, wenn die Präsentation sofort geladen wird.
{{% /alert %}}

## **Präsentation online mit einem Passwort schützen**

1. Öffnen Sie die Anwendung [Aspose.Slides Lock](https://products.aspose.app/slides/de/lock).
1. Wählen Sie die Präsentation aus oder laden Sie sie hoch.
1. Geben Sie ein Passwort zum Schutz der Anzeige ein.
1. Geben Sie optional ein separates Passwort zum Schutz der Bearbeitung ein.
1. Wenden Sie den Schutz an und laden Sie die resultierende Datei herunter.

{{% alert color="info" title="Siehe auch" %}}
- [Write-Protect Presentations](/slides/de/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/de/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einem Öffnungspasswort und einem Schreibschutz‑Passwort?**

Ein Öffnungspasswort verschlüsselt die Präsentation und ist zum Laden des Inhalts erforderlich. Ein Schreibschutz‑Passwort beschränkt die Bearbeitung, ohne den Inhalt zu verschlüsseln.

**Kann ich ein Öffnungspasswort validieren, ohne alle Folien zu laden?**

Ja. Holen Sie Präsentationsinformationen, prüfen Sie, ob ein Öffnungspasswortschutz vorhanden ist, und validieren Sie das Passwort, bevor Sie eine vollständige Präsentationsinstanz erstellen.

**Unterstützen die Passwort‑Überprüfungs‑Workflows sowohl PPT als auch PPTX?**

Ja. Dateipfad‑ und strombasierte Passworterkennung und -validierung verhalten sich für PPT‑ und PPTX‑Präsentationen identisch.