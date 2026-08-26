---
title: Schreibschutz für Präsentationen in C++
linktitle: Schreibschutz
type: docs
weight: 25
url: /de/cpp/write-protected-presentation/
keywords:
- Schreibschutz
- PowerPoint-Schreibschutz
- Passwort zum Ändern
- Präsentationsbearbeitung einschränken
- Schreibschutz entfernen
- Passwort für Änderung prüfen
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Setzen, Erkennen, Validieren und Entfernen von Schreibschutz-Passwörtern in PowerPoint PPT und PPTX Präsentationen mit Aspose.Slides für C++."
---
## **Einleitung**

Ein Schreibschutz-Passwort beschränkt die Änderung einer Präsentation, verschlüsselt jedoch nicht deren Inhalt. Benutzer können eine schreibgeschützte Präsentation ohne das Passwort laden und anzeigen. Je nach Anwendung können sie den Inhalt zudem bearbeiten und unter einem anderen Namen speichern, sodass der Schreibschutz nicht als Vertraulichkeitsmechanismus betrachtet werden sollte.

Ein Öffnungs‑Passwort hat einen anderen Zweck: Es verschlüsselt die Präsentation und ist zum Laden des Inhalts erforderlich. Zum Verschlüsseln einer Präsentation oder zum Validieren eines Öffnungs‑Passworts siehe [Password-Protect Presentations](/slides/de/cpp/password-protected-presentation/).

Die in diesem Artikel beschriebenen Workflows gelten sowohl für PPT‑ als auch für PPTX‑Präsentationen. Die Beispiele verwenden PPTX‑Dateien; beim Speichern als PPT verwenden Sie die Erweiterung `.ppt` und das entsprechende PPT‑Speicherformat.

## **Schreibschutz für eine Präsentation festlegen**

Verwenden Sie [IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/de/cpp/aspose.slides/iprotectionmanager/setwriteprotection/), um ein Passwort für die Änderung einer Präsentation festzulegen. Das Speichern der Präsentation bewahrt die Schutz‑Einstellung.

Das folgende Beispiel legt einen Schreibschutz für eine PPTX‑Präsentation fest:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"modify_password");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Eine schreibgeschützte Präsentation laden**

Da der Schreibschutz den Präsentationsinhalt nicht verschlüsselt, ist zum Laden der Präsentation kein Passwort erforderlich. Das Passwort ist nur relevant, wenn die Berechtigung zur Änderung der geschützten Präsentation überprüft wird.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

Übergeben Sie kein Schreibschutz‑Passwort an [LoadOptions::set_Password](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_password/). Diese Eigenschaft akzeptiert ein Öffnungs‑Passwort für verschlüsselten Inhalt. Hat eine Präsentation beide Schutzarten, geben Sie das Öffnungs‑Passwort zum Laden an und behandeln Sie das Schreibschutz‑Passwort separat.

## **Schreibschutz von einer Präsentation entfernen**

Verwenden Sie [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/de/cpp/aspose.slides/iprotectionmanager/removewriteprotection/), um die Änderungsbeschränkung zu entfernen, und speichern Sie anschließend die Präsentation.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"write-protected-pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Prüfen, ob eine Präsentation schreibgeschützt ist**

Um eine Datei zu prüfen, ohne eine vollständige [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)-Instanz zu erstellen, rufen Sie [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) auf und prüfen Sie [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/). Die Eigenschaft verwendet [NullableBool](https://reference.aspose.com/slides/de/cpp/aspose.slides/nullablebool/) und gibt `NullableBool::True` zurück, wenn ein Schreibschutz erkannt wird.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() == NullableBool::True)
{
    Console::WriteLine(u"The presentation is write protected.");
}
else
{
    Console::WriteLine(u"Write protection was not detected.");
}
```

Die Stream‑Überladung von [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) liefert dieselben Informationen für eine als Stream übergebene Präsentation.

## **Ein Schreibschutz‑Passwort validieren**

Verwenden Sie [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/), um ein Änderungs‑Passwort zu validieren, ohne die vollständige Präsentation zu laden. Prüfen Sie zunächst [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/), damit die Anwendung nur dann ein Passwort anfordert oder validiert, wenn ein Schreibschutz vorhanden ist.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() != NullableBool::True)
{
    Console::WriteLine(u"The presentation is not write protected.");
}
else if (presentationInfo->CheckWriteProtection(u"modify_password"))
{
    Console::WriteLine(u"The write-protection password is correct.");
}
else
{
    Console::WriteLine(u"The write-protection password is incorrect.");
}
```

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) validiert nur das Schreibschutz‑Passwort. Es validiert kein Öffnungs‑Passwort und ermittelt nicht, ob verschlüsselter Inhalt geladen werden kann. Umgekehrt validiert [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/checkpassword/) ausschließlich ein Öffnungs‑Passwort. Wurde bereits eine komplette Präsentation geladen, stellt [IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/de/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) die entsprechende Schreibschutz‑Prüfung über den Schutz‑Manager bereit.

In Produktionsanwendungen sollten Passwörter nicht protokolliert oder in Diagnosemeldungen aufgenommen werden. Vermeiden Sie unnötige wiederholte Validierungsversuche und behalten Sie Passwörter im Speicher nur so lange, wie sie benötigt werden.

{{% alert color="info" title="Siehe auch" %}}
- [Password-Protect Presentations](/slides/de/cpp/password-protected-presentation/)
- [Read-Only Presentations](/slides/de/cpp/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/de/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Verschlüsselt der Schreibschutz eine Präsentation?**

Nein. Er beschränkt die Änderung, lässt jedoch den Präsentationsinhalt zum Laden und Anzeigen verfügbar.

**Ist das Schreibschutz‑Passwort zum Öffnen einer Präsentation erforderlich?**

Nein. Nur ein Öffnungs‑Passwort ist zum Laden von verschlüsseltem Präsentationsinhalt erforderlich.

**Kann eine Präsentation sowohl ein Öffnungs‑Passwort als auch ein Schreibschutz‑Passwort haben?**

Ja. Geben Sie das Öffnungs‑Passwort über die Ladeoptionen an, um die verschlüsselte Präsentation zu öffnen, und validieren Sie das Schreibschutz‑Passwort separat, wenn eine Änderungsberechtigung erforderlich ist.