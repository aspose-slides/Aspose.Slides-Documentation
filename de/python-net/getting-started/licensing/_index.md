---
title: Lizenzierung
type: docs
weight: 80
url: /de/python-net/licensing/
keywords:
- Lizenz
- temporäre Lizenz
- Lizenz setzen
- Lizenz verwenden
- Lizenz validieren
- Lizenzdatei
- Evaluierungsversion
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Lizenzen in Aspose.Slides für Python via .NET anwenden, verwalten und Probleme beheben. Stellen Sie einen ununterbrochenen Zugriff auf alle Funktionen mit unserem Schritt-für-Schritt-Lizenzleitfaden sicher."
---

## **Evaluieren von Aspose.Slides**

Sie können eine Evaluierungsversion von **Aspose.Slides for Python via .NET** von seiner [Download-Seite](https://pypi.org/project/Aspose.Slides/) herunterladen. Die Evaluierungsversion bietet dieselben Funktionen wie das lizenzierte Produkt. Das Evaluierungspaket ist identisch mit dem erworbenen Paket und wird lizenziert, nachdem Sie ein paar Codezeilen hinzugefügt haben, um die Lizenz anzuwenden.

Wenn Sie mit Ihrer Evaluierung von **Aspose.Slides** zufrieden sind, können Sie [eine Lizenz erwerben](https://purchase.aspose.com/buy). Wir empfehlen, die verfügbaren Abonnementoptionen zu prüfen. Bei Fragen kontaktieren Sie das Vertriebsteam von Aspose.

Jede Aspose-Lizenz beinhaltet ein einjähriges Abonnement mit kostenlosen Upgrades auf neue Versionen und Fehlerbehebungen, die in diesem Zeitraum veröffentlicht werden. Sowohl lizenzierte als auch Evaluierungsbenutzer erhalten kostenlosen, unbegrenzten technischen Support.

**Einschränkungen der Evaluierungsversion**

* Während die Aspose.Slides Evaluierungsversion (wenn keine Lizenz angewendet wird) die volle Funktionalität bietet, fügt sie bei jedem Öffnen oder Speichern des Dokuments ein Evaluierungswasserzeichen oben ein.
* Beim Extrahieren von Text aus einer Präsentation sind Sie auf eine Folie beschränkt.

{{% alert color="primary" %}}
Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30‑tägige temporäre Lizenz** anfordern. Weitere Details finden Sie auf der Seite [So erhalten Sie eine temporäre Lizenz](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Lizenzierung in Aspose.Slides**

* Eine Evaluierungsversion wird lizenziert, nachdem Sie eine Lizenz erworben und ein paar Codezeilen hinzugefügt haben, um sie anzuwenden.
* Die Lizenz ist eine reine Text-XML-Datei, die Details wie den Produktnamen, die Anzahl der Entwickler, die abgedeckt werden, das Ablaufdatum des Abonnements usw. enthält.
* Die Lizenzdatei ist digital signiert, daher dürfen Sie sie nicht ändern. Schon das Hinzufügen eines einzigen Zeilenumbruchs macht sie ungültig.
* Aspose.Slides for Python via .NET sucht die Lizenz in der Regel an diesen Orten:
  * Einen expliziten Pfad, den Sie angeben
  * Den Ordner, der das Python‑Skript enthält, das Aspose.Slides for Python via .NET aufruft
* Um die Evaluierungseinschränkungen zu vermeiden, setzen Sie die Lizenz, bevor Sie Aspose.Slides verwenden. Sie müssen sie nur einmal pro Anwendung oder Prozess setzen.

{{% alert color="primary" %}}
Vielleicht möchten Sie auch die [Metered Licensing](/slides/de/python-net/metered-licensing/) überprüfen.
{{% /alert %}}

## **Anwenden einer Lizenz**

Eine Lizenz kann aus einer **Datei**, einem **Stream** oder einer **eingebetteten Ressource** geladen werden.

{{% alert color="primary" %}}
Aspose.Slides stellt die Klasse [License](https://reference.aspose.com/slides/python-net/aspose.slides/license/) zur Lizenzverwaltung bereit.
{{% /alert %}}

{{% alert color="warning" %}}
Neue Lizenzen können Aspose.Slides nur mit Version 21.4 oder höher aktivieren. Frühere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.
{{% /alert %}}

### **Datei**

Der einfachste Weg, eine Lizenz zu setzen, besteht darin, die Lizenzdatei im selben Ordner wie die DLL der Komponente abzulegen und nur den Dateinamen (ohne Pfad) anzugeben.

Der folgende Python‑Code zeigt, wie die Lizenzdatei gesetzt wird:
```py
import aspose.slides as slides

# Instanziiert die Lizenzklasse. 
license = slides.License()

# Setzt den Pfad der Lizenzdatei.
license.set_license("Aspose.Slides.lic")
```


{{% alert color="warning" %}}
Wenn Sie die Lizenzdatei in einem anderen Verzeichnis ablegen, muss beim Aufruf von [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str) der Dateiname am Ende des expliziten Pfads mit dem Namen Ihrer Lizenzdatei übereinstimmen.

Zum Beispiel können Sie die Lizenzdatei in *Aspose.Slides.lic.xml* umbenennen. Dann übergeben Sie in Ihrem Code den vollständigen Pfad zu dieser Datei (der mit Aspose.Slides.lic.xml endet) an die Methode [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str).
{{% /alert %}}

### **Stream**

Sie können eine Lizenz aus einem Stream laden. Das folgende Python‑Beispiel zeigt, wie Sie eine Lizenz aus einem Stream anwenden:
```py
import aspose.slides as slides

# Instanziert die Lizenzklasse.
license = slides.License()

# Setzt die Lizenz aus einem Stream.
license.set_license(stream)
```


## **Validierung einer Lizenz**

Um zu überprüfen, ob die Lizenz korrekt angewendet wurde, können Sie sie validieren. Der folgende Python‑Code demonstriert, wie eine Lizenz validiert wird:
```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```


## **Thread‑Sicherheit**

{{% alert title="Note" color="warning" %}}
Die Methoden [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/) sind nicht threadsicher. Wenn sie gleichzeitig von mehreren Threads aufgerufen werden müssen, verwenden Sie Synchronisations‑primitive (z. B. `threading.Lock`), um Probleme zu vermeiden.
{{% /alert %}}

## **FAQ**

**Kann ich die Lizenz in einer vollständig offline Umgebung (keine Internetverbindung) anwenden?**

Ja. Die Lizenzvalidierung wird lokal anhand der Lizenzdatei durchgeführt; eine Internetverbindung ist nicht erforderlich.

**Was passiert, wenn das einjährige Abonnement abläuft? Hört die Bibliothek auf zu funktionieren?**

Nein. Die Lizenz ist unbefristet: Sie können weiterhin die Versionen verwenden, die vor Ablauf Ihres Abonnements veröffentlicht wurden; Sie können jedoch neuere Releases nicht nutzen, ohne das Abonnement zu erneuern.