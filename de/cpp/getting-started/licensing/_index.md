---
title: Lizenzierung
type: docs
weight: 120
url: /de/cpp/licensing/
keywords:
- Lizenz
- Temporäre Lizenz
- Lizenz setzen
- Lizenz verwenden
- Lizenz validieren
- Lizenzdatei
- Evaluierungsversion
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Lizenzen in Aspose.Slides für C++ anwenden, verwalten und Fehler beheben. Gewährleisten Sie ununterbrochenen Zugriff auf alle Funktionen mit unserer schrittweisen Lizenzierungsanleitung."
---
## **Übersicht**

Aspose.Slides kann im Evaluierungsmodus oder mit einer gültigen Lizenz verwendet werden. Die Evaluierungsversion bietet dieselbe Funktionalität wie die lizenzierte Version, fügt jedoch ein Evaluierungswasserzeichen hinzu, wenn Präsentationen geöffnet oder gespeichert werden, und beschränkt die Textextraktion auf eine Folie.

Dieser Artikel erklärt, wie die Lizenzierung in Aspose.Slides funktioniert und wie eine Lizenz angewendet wird, bevor die Bibliothek verwendet wird. Eine Lizenz kann aus einer Datei, einem Stream oder einer eingebetteten Ressource mit der Klasse `License` geladen werden. Der Artikel zeigt außerdem, wie geprüft werden kann, ob eine Lizenz korrekt angewendet wurde.

## **Aspose.Slides evaluieren**

{{% alert color="info" %}} 

Sie können eine Evaluierungsversion von **Aspose.Slides for C++** von [seiner NuGet-Downloadseite](https://www.nuget.org/packages/Aspose.Slides.CPP/) herunterladen. Die Evaluierungsversion bietet dieselbe Funktionalität wie das lizenzierte Produkt. Tatsächlich ist das Evaluierungspaket identisch mit dem erworbenen – es wird einfach lizenziert, sobald Sie ein paar Codezeilen hinzufügen, um die Lizenz anzuwenden.

Wenn Sie mit Ihrer Evaluierung von **Aspose.Slides** zufrieden sind, können Sie [eine Lizenz erwerben](https://purchase.aspose.com/buy). Wir empfehlen, die verfügbaren Abonnementtypen zu prüfen. Bei Fragen können Sie sich gerne an das Vertriebsteam von Aspose wenden.

Jede Aspose-Lizenz beinhaltet ein einjähriges Abonnement für kostenlose Updates, einschließlich neuer Versionen und während dieses Zeitraums veröffentlichter Fehlerbehebungen. Unabhängig davon, ob Sie eine lizenzierte oder eine Evaluierungsversion verwenden, erhalten Sie kostenlosen und unbegrenzten technischen Support.

{{% /alert %}} 

**Einschränkungen der Evaluierungsversion**

* Während die Aspose.Slides-Evaluierungsversion (ohne angewandte Lizenz) die vollständige Produktfunktionalität bietet, fügt sie beim Öffnen und Speichern ein Evaluierungswasserzeichen am oberen Rand des Dokuments ein.
* Die Textextraktion ist bei Verwendung der Evaluierungsversion auf eine Folie beschränkt.

{{% alert color="info" %}} 

Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30‑tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie auf der Seite [How to Get a Temporary License](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Lizenzierung in Aspose.Slides**

* Eine Evaluierungsversion wird nach dem Kauf einer Lizenz und deren Anwendung durch Hinzufügen einiger Codezeilen lizenziert.
* Die Lizenz ist eine reine Text‑XML‑Datei, die Details wie den Produktnamen, die Anzahl der lizenzierten Entwickler, das Ablaufdatum des Abonnements und weitere Informationen enthält.
* Die Lizenzdatei ist digital signiert und darf nicht verändert werden. Selbst eine versehentliche Änderung – z. B. das Hinzufügen eines Zeilenumbruchs – macht die Datei ungültig.
* Aspose.Slides for C++ sucht die Lizenzdatei in der Regel an den folgenden Orten:
  * Ein in Ihrem Code explizit angegebener Pfad
  * Der Ordner, der die DLL der Komponente enthält (im Lieferumfang von Aspose.Slides)
  * Der Ordner, der die Assembly enthält, die die DLL der Komponente aufruft
* Um die Einschränkungen der Evaluierungsversion zu vermeiden, müssen Sie die Lizenz vor der Verwendung von Aspose.Slides setzen. Eine Lizenz muss nur einmal pro Anwendung oder Prozess gesetzt werden.

## **Lizenz anwenden**

Eine Lizenz kann aus einer **Datei**, einem **Stream** oder einer **eingebetteten Ressource** geladen werden.

{{% alert color="info" %}}

Aspose.Slides stellt die Klasse [License](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.license/) für Lizenzvorgänge bereit.

{{% /alert %}} 

{{% alert color="warning" %}}

Neue Lizenzen können Aspose.Slides nur ab Version 21.4 aktivieren. Frühere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.

{{% /alert %}}

### **Datei**

Der einfachste Weg, eine Lizenz zu setzen, besteht darin, die Lizenzdatei im selben Ordner wie die DLL der Komponente (im Lieferumfang von Aspose.Slides) zu platzieren und nur den Dateinamen ohne Pfad anzugeben.

Der folgende C++‑Code zeigt, wie eine Lizenzdatei gesetzt wird:

```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

{{% alert color="warning" %}} 

Wenn Sie die Lizenzdatei in einem anderen Verzeichnis ablegen, muss beim Aufruf der Methode [License::SetLicense](https://reference.aspose.com/slides/de/cpp/aspose.slides/license/setlicense/) der Dateiname am Ende des angegebenen expliziten Pfads exakt dem Namen Ihrer Lizenzdatei entsprechen.

Beispielsweise, wenn Sie Ihre Lizenzdatei in *Aspose.Slides.lic.xml* umbenennen, müssen Sie den vollständigen Pfad, der mit *Aspose.Slides.lic.xml* endet, an die Methode [License::SetLicense](https://reference.aspose.com/slides/de/cpp/aspose.slides/license/setlicense/) in Ihrem Code übergeben.

{{% /alert %}}

### **Stream**

Sie können eine Lizenz aus einem Stream laden. Der folgende C++‑Code zeigt, wie eine Lizenz aus einem Stream angewendet wird:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Lizenz prüfen**

Um zu überprüfen, ob eine Lizenz korrekt gesetzt wurde, können Sie sie validieren. Der folgende C++‑Code zeigt, wie eine Lizenz validiert wird:

```c++
#include <Util/License.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **Thread‑Sicherheit**

{{% alert title="Hinweis" color="warning" %}} 

Die Methode [License::SetLicense](https://reference.aspose.com/slides/de/cpp/aspose.slides/license/setlicense/) ist **nicht thread‑sicher**. Wenn Sie diese Methode gleichzeitig aus mehreren Threads aufrufen müssen, wird empfohlen, Synchronisations‑Primitiven (wie einem Lock) zu verwenden, um potenzielle Probleme zu vermeiden.

{{% /alert %}}

## **FAQ**

### Kann ich die Lizenz in einer vollständig offline Umgebung (kein Internetzugang) anwenden?

Ja. Die Lizenzvalidierung erfolgt lokal mithilfe der Lizenzdatei; eine Internetverbindung ist nicht erforderlich.

### Was passiert, wenn das einjährige Abonnement abläuft? Hört die Bibliothek auf zu funktionieren?

Nein. Die Lizenz ist unbefristet: Sie können weiterhin Versionen verwenden, die vor dem Ende Ihres Abonnements veröffentlicht wurden; Sie können jedoch neuere Releases nicht nutzen, solange Sie nicht verlängern.