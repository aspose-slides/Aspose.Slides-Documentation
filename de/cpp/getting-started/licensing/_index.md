---
title: Lizenzierung
type: docs
weight: 120
url: /de/cpp/licensing/
keywords:
- Lizenz
- temporäre Lizenz
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
description: "Lizenzen in Aspose.Slides für C++ anwenden, verwalten und Fehler beheben. Stellen Sie einen unterbrechungsfreien Zugriff auf alle Funktionen mit unserer Schritt-für-Schritt-Lizenzierungsanleitung sicher."
---
## **Übersicht**

Aspose.Slides kann im Evaluierungsmodus oder mit einer gültigen Lizenz verwendet werden. Die Evaluierungsversion bietet dieselbe Funktionalität wie die lizenzierte Version, fügt jedoch jedem Folie jeder Präsentation, die sie speichert, ein Evaluierungswasserzeichen hinzu und kürzt den Text, den Ihr Code aus Präsentationen liest.

Dieser Artikel erklärt, wie die Lizenzierung in Aspose.Slides funktioniert und wie Sie eine Lizenz anwenden, bevor Sie die Bibliothek verwenden. Eine Lizenz kann aus einer Datei oder einem Stream mithilfe der `License`‑Klasse geladen werden. Der Artikel zeigt zudem, wie Sie überprüfen können, ob eine Lizenz korrekt angewendet wurde.

## **Aspose.Slides evaluieren**

{{% alert color="info" title="Note" %}}
Sie können eine Evaluierungsversion von **Aspose.Slides for C++** von [der NuGet-Downloadseite](https://www.nuget.org/packages/Aspose.Slides.Cpp/) oder als ZIP‑Paket von der [Downloadseite](https://releases.aspose.com/slides/cpp/) herunterladen. Die Evaluierungsversion bietet dieselbe Funktionalität wie das lizenzierte Produkt. Tatsächlich ist das Evaluierungspaket identisch mit dem erworbenen – es wird einfach lizenziert, sobald Sie ein paar Codezeilen hinzufügen, um die Lizenz anzuwenden.

Sobald Sie mit Ihrer Evaluierung von **Aspose.Slides** zufrieden sind, können Sie [eine Lizenz erwerben](https://purchase.aspose.com/pricing/slides/cpp/). Wir empfehlen, die verfügbaren Abonnementtypen zu prüfen. Bei Fragen können Sie sich gerne an das Vertriebsteam von Aspose wenden.

Jede Aspose‑Lizenz beinhaltet ein einjähriges Abonnement für kostenlose Upgrades, einschließlich neuer Versionen und Bug‑Fixes, die in diesem Zeitraum veröffentlicht werden. Unabhängig davon, ob Sie eine lizenzierte oder eine Evaluierungsversion verwenden, erhalten Sie kostenlosen und unbegrenzten technischen Support.
{{% /alert %}} 

**Einschränkungen der Evaluierungsversion**

* Die Evaluierungsversion (ohne angegebene Lizenz) bietet die volle Produktfunktionalität, fügt jedoch jeder Folie jeder Präsentation, die sie speichert, ein Evaluierungswasserzeichen‑Textfeld hinzu.
* Text, den Ihr Code aus einer Präsentation liest, wird auf die ersten Zeichen gekürzt und mit einem Hinweis auf die Evaluierungsbeschränkung versehen. Text, den Ihr Code schreibt, wird vollständig gespeichert.

{{% alert color="info" title="Note" %}}
Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30‑Tage‑Temporärlizenz** anfordern. Weitere Informationen finden Sie auf der Seite [Wie man eine temporäre Lizenz erhält](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Lizenzierung in Aspose.Slides**

* Eine Evaluierungsversion wird lizenziert, nachdem Sie eine Lizenz erworben und sie durch Hinzufügen einiger Codezeilen angewendet haben.
* Die Lizenz ist eine reine Text‑XML‑Datei, die Details wie den Produktnamen, die Anzahl der lizenzierten Entwickler, das Ablaufdatum des Abonnements und mehr enthält.
* Die Lizenzdatei ist digital signiert und darf daher nicht verändert werden. Selbst eine versehentliche Änderung, z. B. das Hinzufügen eines Zeilenumbruchs, macht die Datei ungültig.
* Wenn Sie einen Dateinamen ohne Ordner übergeben, sucht Aspose.Slides für C++ die Lizenzdatei ausschließlich im aktuellen Arbeitsverzeichnis. Es durchsucht nicht den Ordner Ihrer ausführbaren Datei oder der Aspose.Slides‑Bibliothek, geben Sie also den vollständigen Pfad an, wenn die Lizenzdatei an einem anderen Ort gespeichert ist.
* Um die Einschränkungen der Evaluierungsversion zu vermeiden, müssen Sie die Lizenz festlegen, bevor Sie Aspose.Slides verwenden. Eine Lizenz muss nur einmal pro Anwendung oder Prozess gesetzt werden.

## **Lizenz anwenden**

Eine Lizenz kann aus einer **Datei** oder einem **Stream** geladen werden.

{{% alert color="info" title="Note" %}}
Aspose.Slides stellt die Klasse [License](https://reference.aspose.com/slides/cpp/aspose.slides/license/) für Lizenzierungs‑Operationen bereit.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Neue Lizenzen können Aspose.Slides nur mit Version 21.4 oder höher aktivieren. Frühere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.
{{% /alert %}}

### **Datei**

Der einfachste Weg, eine Lizenz zu setzen, besteht darin, die Lizenzdatei im Arbeitsverzeichnis Ihres Programms zu platzieren und nur den Dateinamen ohne Pfad anzugeben. Andernfalls geben Sie den vollständigen Pfad zur Datei an.

Der folgende C++‑Code wendet die Lizenzdatei *Aspose.Slides.lic* aus dem Arbeitsverzeichnis des Programms an:
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

Wenn die Lizenz gültig ist, gibt [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) zurück und das Programm endet ohne Ausgabe; ab diesem Zeitpunkt funktioniert Aspose.Slides ohne die Evaluierungsbeschränkungen. Befindet sich die Datei nicht im Arbeitsverzeichnis, wirft die Methode eine [FileNotFoundException](https://reference.aspose.com/slides/cpp/system.io/filenotfoundexception/) mit der Meldung *License "Aspose.Slides.lic" doesn't exist or access is restricted*. Das Beispiel behandelt die Ausnahme nicht, sodass das Programm stoppt.

{{% alert color="warning" title="Warning" %}}
Wenn Sie die Lizenzdatei in einem anderen Verzeichnis ablegen, muss beim Aufruf der Methode [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) der Dateiname am Ende des angegebenen vollständigen Pfads exakt mit dem Namen Ihrer Lizenzdatei übereinstimmen.

Beispielsweise, wenn Sie Ihre Lizenzdatei in *Aspose.Slides.lic.xml* umbenennen, müssen Sie den vollständigen Pfad, der mit *Aspose.Slides.lic.xml* endet, an die Methode [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) in Ihrem Code übergeben.
{{% /alert %}}

### **Stream**

Laden Sie eine Lizenz aus einem Stream, wenn Ihr Programm die Lizenz nicht als Datei speichert, die es benennen kann, zum Beispiel wenn es die Lizenz aus einer Datenbank liest. [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) akzeptiert jeden [Stream](https://reference.aspose.com/slides/cpp/system.io/stream/), der die Lizenz enthält. Um das Beispiel kurz zu halten, öffnet der folgende C++‑Code *Aspose.Slides.lic* im Arbeitsverzeichnis mit [File::OpenRead](https://reference.aspose.com/slides/cpp/system.io/file/openread/) und wendet die Lizenz aus diesem Stream an:
```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

Eine gültige Lizenz liefert dasselbe Ergebnis wie im Datei‑Beispiel. Existiert die Datei nicht, wirft [File::OpenRead](https://reference.aspose.com/slides/cpp/system.io/file/openread/) eine [FileNotFoundException](https://reference.aspose.com/slides/cpp/system.io/filenotfoundexception/) bevor die Lizenz angewendet wird, und das Programm stoppt.

## **Lizenz validieren**

Um zu prüfen, ob eine Lizenz korrekt gesetzt wurde, rufen Sie [License::IsLicensed](https://reference.aspose.com/slides/cpp/aspose.slides/license/islicensed/) auf. Sie gibt `true` nur zurück, nachdem eine gültige Lizenz angewendet wurde, und `false` davor. Der folgende C++‑Code wendet die Lizenzdatei aus dem Arbeitsverzeichnis an und prüft sie anschließend:
```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

Bei einer gültigen Lizenz gibt das Programm *License is good!* aus. Fehlt die Datei oder ist keine Lizenzdatei, wirft [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) vor der Prüfung eine Ausnahme, und das Programm endet ohne Ausgabe. Ist die Datei eine Lizenz, deren Signatur nicht übereinstimmt, zum Beispiel weil sie bearbeitet wurde, gibt SetLicense ohne Fehler zurück, aber `IsLicensed` liefert `false`, sodass nichts ausgegeben wird und Aspose.Slides im Evaluierungsmodus bleibt.

## **Thread‑Sicherheit**

{{% alert color="warning" title="Warning" %}}
Die Methode [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) ist **nicht thread‑sicher**. Wenn Sie diese Methode aus mehreren Threads gleichzeitig aufrufen müssen, wird empfohlen, Synchronisations‑Primitive (wie beispielsweise ein Lock) zu verwenden, um mögliche Probleme zu verhindern.
{{% /alert %}}

## **FAQ**

### Kann ich die Lizenz in einer vollständig offline Umgebung (ohne Internetzugang) anwenden?
Ja. Die Lizenzvalidierung erfolgt lokal anhand der Lizenzdatei; eine Internetverbindung ist nicht erforderlich.

### Was passiert, wenn das einjährige Abonnement abläuft? Hört die Bibliothek auf zu funktionieren?
Nein. Die Lizenz ist unbefristet: Sie können weiterhin die Versionen nutzen, die vor dem Ende Ihres Abonnements veröffentlicht wurden; Sie können jedoch ohne Erneuerung keine neueren Versionen verwenden.