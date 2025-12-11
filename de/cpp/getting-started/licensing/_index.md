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
description: "Lizenzen in Aspose.Slides für C++ anwenden, verwalten und Fehler beheben. Gewährleisten Sie ununterbrochenen Zugriff auf alle Funktionen mit unserem Schritt‑für‑Schritt‑Leitfaden zur Lizenzierung."
---

## **Aspose.Slides bewerten**

{{% alert color="primary" %}} 

Sie können eine Evaluierungsversion von **Aspose.Slides for C++** von [ihrer NuGet-Downloadseite](https://www.nuget.org/packages/Aspose.Slides.CPP/) herunterladen. Die Evaluierungsversion bietet dieselbe Funktionalität wie das lizenzierte Produkt. Tatsächlich ist das Evaluierungspaket identisch mit dem gekauften – es wird lediglich lizenziert, sobald Sie ein paar Codezeilen hinzufügen, um die Lizenz anzuwenden.

Sobald Sie mit Ihrer Evaluierung von **Aspose.Slides** zufrieden sind, können Sie [eine Lizenz erwerben](https://purchase.aspose.com/buy). Wir empfehlen, die verfügbaren Abonnementtypen zu prüfen. Wenn Sie Fragen haben, können Sie sich gerne an das Aspose-Vertriebsteam wenden.

Jede Aspose-Lizenz beinhaltet ein einjähriges Abonnement für kostenlose Upgrades, einschließlich neuer Versionen und Fehlerbehebungen, die in diesem Zeitraum veröffentlicht werden. Egal, ob Sie eine lizenzierte oder eine Evaluierungsversion verwenden, erhalten Sie kostenlosen und unbegrenzten technischen Support.

{{% /alert %}} 

**Einschränkungen der Evaluierungsversion**

* Während die Aspose.Slides-Evaluierungsversion (wenn keine Lizenz angewendet wird) die volle Produktfunktionalität bietet, fügt sie bei Öffnungs- und Speicheroperationen ein Evaluierungswasserzeichen oben im Dokument ein.
* Die Textextraktion ist bei Verwendung der Evaluierungsversion auf eine Folie begrenzt.

{{% alert color="primary" %}} 

Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30‑tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie auf der Seite [Wie man eine temporäre Lizenz erhält](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Lizenzierung in Aspose.Slides**

* Eine Evaluierungsversion wird lizenziert, nachdem Sie eine Lizenz gekauft und sie durch Hinzufügen einiger Codezeilen angewendet haben.
* Die Lizenz ist eine reine Text‑XML‑Datei, die Details wie den Produktnamen, die Anzahl der lizenzierten Entwickler, das Ablaufdatum des Abonnements und mehr enthält.
* Die Lizenzdatei ist digital signiert und darf daher nicht geändert werden. Selbst eine unbeabsichtigte Änderung, etwa das Hinzufügen eines Zeilenumbruchs, macht die Datei ungültig.
* Aspose.Slides for C++ sucht die Lizenzdatei normalerweise an folgenden Orten:
  * Ein in Ihrem Code explizit angegebener Pfad
  * Der Ordner, der die DLL der Komponente enthält (in Aspose.Slides enthalten)
  * Der Ordner, der die Assembly enthält, die die DLL der Komponente aufruft
* Um die Einschränkungen der Evaluierungsversion zu vermeiden, müssen Sie die Lizenz vor der Verwendung von Aspose.Slides setzen. Eine Lizenz muss nur einmal pro Anwendung oder Prozess gesetzt werden.

## **Lizenz anwenden**

Eine Lizenz kann aus einer **Datei**, einem **Stream** oder einer **eingebetteten Ressource** geladen werden.

{{% alert color="primary" %}}

Aspose.Slides stellt die Klasse [License](https://reference.aspose.com/slides/cpp/class/aspose.slides.license/) für Lizenzvorgänge bereit.

{{% /alert %}} 

{{% alert color="warning" %}}

Neue Lizenzen können Aspose.Slides nur ab Version 21.4 oder später aktivieren. Ältere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.

{{% /alert %}}

### **Datei**

Der einfachste Weg, eine Lizenz zu setzen, besteht darin, die Lizenzdatei im selben Ordner wie die DLL der Komponente (in Aspose.Slides enthalten) abzulegen und nur den Dateinamen ohne Pfad anzugeben.

Der folgende C++‑Code zeigt, wie man eine Lizenzdatei setzt:
```c++
#include <Util/License.h>

using namespace Aspose::Slides;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```


{{% alert color="warning" %}} 

Wenn Sie die Lizenzdatei in einem anderen Verzeichnis ablegen, muss beim Aufruf der Methode [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) der Dateiname am Ende des angegebenen expliziten Pfads exakt mit dem Namen Ihrer Lizenzdatei übereinstimmen.

Beispielsweise, wenn Sie Ihre Lizenzdatei in *Aspose.Slides.lic.xml* umbenennen, müssen Sie den vollständigen Pfad, der mit *Aspose.Slides.lic.xml* endet, an die Methode [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) in Ihrem Code übergeben.

{{% /alert %}}

### **Stream**

Sie können eine Lizenz aus einem Stream laden. Der folgende C++‑Code zeigt, wie man eine Lizenz aus einem Stream anwendet:
```c++
auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```


## **Lizenz validieren**

Um zu prüfen, ob eine Lizenz korrekt gesetzt wurde, können Sie sie validieren. Der folgende C++‑Code zeigt, wie man eine Lizenz validiert:
```c++
auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```


## **Thread‑Sicherheit**

{{% alert title="Note" color="warning" %}} 

Die Methode [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) ist **nicht thread‑sicher**. Wenn Sie diese Methode gleichzeitig aus mehreren Threads aufrufen müssen, wird empfohlen, Synchronisations‑Primitiven (wie z. B. ein Lock) zu verwenden, um mögliche Probleme zu verhindern.

{{% /alert %}}

## **FAQ**

**Kann ich die Lizenz in einer vollständig offline Umgebung (kein Internetzugang) anwenden?**

Ja. Die Lizenzvalidierung erfolgt lokal mithilfe der Lizenzdatei; eine Internetverbindung ist nicht erforderlich.

**Was passiert, wenn das einjährige Abonnement abläuft? Hört die Bibliothek auf zu funktionieren?**

Nein. Die Lizenz ist dauerhaft: Sie können weiterhin Versionen verwenden, die vor dem Ende Ihres Abonnements veröffentlicht wurden; Sie können jedoch neuere Versionen ohne Verlängerung nicht nutzen.