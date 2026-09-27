---
title: Lizenzierung
type: docs
weight: 80
url: /de/python-net/licensing/
keywords:
- Lizenz
- temporäre Lizenz
- Lizenz festlegen
- Lizenz verwenden
- Lizenz validieren
- Lizenzdatei
- Evaluierungsversion
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Lizenzen in Aspose.Slides für Python via .NET anwenden, verwalten und Probleme beheben. Stellen Sie einen ununterbrochenen Zugang zu allen Funktionen mit unserem Schritt-für-Schritt-Leitfaden zur Lizenzierung sicher."
---
## **Übersicht**

Aspose.Slides kann im Evaluierungsmodus oder mit einer gültigen Lizenz verwendet werden. Die Evaluierungsversion bietet dieselbe Funktionalität wie die lizenzierte Version, fügt jedoch jedem Folienbild jeder Präsentation, die sie speichert, ein Evaluierungswasserzeichen hinzu und kürzt Text, den Ihr Code aus Präsentationen liest.

## **Aspose.Slides evaluieren**

Sie können eine Evaluierungsversion von **Aspose.Slides for Python via .NET** von seiner [download page](https://pypi.org/project/Aspose.Slides/) herunterladen. Die Evaluierungsversion bietet dieselben Funktionen wie das lizenzierte Produkt. Das Evaluierungspaket ist identisch mit dem erworbenen Paket und wird lizenziert, nachdem Sie ein paar Codezeilen hinzugefügt haben, um die Lizenz anzuwenden.

Wenn Sie mit Ihrer Evaluierung von **Aspose.Slides** zufrieden sind, können Sie eine [purchase a license](https://purchase.aspose.com/pricing/slides/de/python-net/) erwerben. Wir empfehlen, die verfügbaren Abonnementoptionen zu prüfen. Bei Fragen kontaktieren Sie das Aspose‑Verkaufsteam.

Jede Aspose‑Lizenz beinhaltet ein einjähriges Abonnement mit kostenlosen Upgrades auf neue Versionen und Fehlerbehebungen, die während dieses Zeitraums veröffentlicht werden. Sowohl lizenzierte als auch Evaluierungsnutzer erhalten kostenlosen, unbegrenzten technischen Support.

**Einschränkungen der Evaluierungsversion**

* Die Evaluierungsversion (wenn keine Lizenz angewendet wird) bietet vollen Funktionsumfang, fügt jedoch jedem Folienbild jeder Präsentation, die sie speichert, ein Evaluierungswasserzeichen‑Textfeld hinzu.
* Text, den Ihr Code aus einer Präsentation liest, wird auf die ersten paar Zeichen gekürzt und mit einem Hinweis auf die Evaluierungseinschränkung versehen. Text, den Ihr Code schreibt, wird vollständig gespeichert.

{{% alert color="info" title="Hinweis" %}}

Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30‑tägige temporäre Lizenz** anfordern. Siehe die Seite [How to Get a Temporary License](https://purchase.aspose.com/temporary-license) für Details.

{{% /alert %}}

## **Lizenzierung in Aspose.Slides**

* Eine Evaluierungsversion wird nach dem Kauf einer Lizenz und dem Hinzufügen einiger Codezeilen zur Anwendung der Lizenz lizenziert.
* Die Lizenz ist eine Klartext‑XML‑Datei, die Details wie den Produktnamen, die Anzahl der Entwickler, die sie abdeckt, das Ablaufdatum des Abonnements usw. enthält.
* Die Lizenzdatei ist digital signiert, daher dürfen Sie sie nicht ändern. Schon das Hinzufügen eines einzelnen Zeilenumbruchs macht sie ungültig.
* Aspose.Slides for Python via .NET sucht die Lizenz am von Ihnen übergebenen Pfad. Ein relativer Pfad oder ein Dateiname ohne Pfad wird relativ zum aktuellen Arbeitsverzeichnis aufgelöst, das nicht unbedingt der Ordner ist, der Ihr Python‑Skript enthält.
* Um die Evaluierungseinschränkungen zu vermeiden, setzen Sie die Lizenz, bevor Sie Aspose.Slides verwenden. Sie müssen sie nur einmal pro Anwendung oder Prozess setzen.

{{% alert color="info" title="Hinweis" %}}

Sie sollten auch [Metered Licensing](/slides/de/python-net/metered-licensing/) prüfen.

{{% /alert %}}

## **Lizenz anwenden**

Eine Lizenz kann aus einer **Datei** oder einem **Stream** geladen werden.

{{% alert color="info" title="Hinweis" %}}

Aspose.Slides stellt die [License](https://reference.aspose.com/slides/de/python-net/aspose.slides/license/)‑Klasse zur Lizenzverwaltung bereit.

{{% /alert %}}

{{% alert color="warning" title="Warnung" %}}

Neue Lizenzen können Aspose.Slides nur mit Version 21.4 oder höher aktivieren. Ältere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.

{{% /alert %}}

### **Datei**

Der einfachste Weg, eine Lizenz zu setzen, besteht darin, den Pfad der Licenzdatei an die [set_license](https://reference.aspose.com/slides/de/python-net/aspose.slides/license/set_license/)‑Methode zu übergeben. Wenn Sie nur den Dateinamen übergeben, wie im Beispiel unten, sucht Aspose.Slides die Datei im aktuellen Arbeitsverzeichnis.

Der folgende Python‑Code zeigt, wie die Lizenzdatei gesetzt wird:

```py
import aspose.slides as slides

# Instanziiert die License-Klasse. 
license = slides.License()

# Legt den Pfad der Lizenzdatei fest.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" title="Warnung" %}}

Wenn Sie die Lizenzdatei in einem anderen Verzeichnis ablegen, muss beim Aufruf von [License.set_license](https://reference.aspose.com/slides/de/python-net/aspose.slides/license/set_license/#str) der Dateiname am Ende des expliziten Pfads exakt dem Namen Ihrer Lizenzdatei entsprechen.

Beispielsweise können Sie die Lizenzdatei in *Aspose.Slides.lic.xml* umbenennen. Dann übergeben Sie in Ihrem Code den vollständigen Pfad zu dieser Datei (endend mit Aspose.Slides.lic.xml) an die [License.set_license](https://reference.aspose.com/slides/de/python-net/aspose.slides/license/set_license/#str)‑Methode.

{{% /alert %}}

### **Stream**

Sie können eine Lizenz aus einem Stream laden. Das folgende Python‑Beispiel zeigt, wie eine Lizenz aus einem Stream angewendet wird:

```py
import aspose.slides as slides

# Instanziiert die License-Klasse.
license = slides.License()

# Setzt die Lizenz aus einem Stream.
with open("Aspose.Slides.lic", "rb") as stream:
    license.set_license(stream)
```

## **Lizenz validieren**

Um zu überprüfen, ob die Lizenz korrekt angewendet wurde, können Sie sie validieren. Der folgende Python‑Code demonstriert, wie eine Lizenz validiert wird:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```


## **Thread‑Sicherheit**

{{% alert color="warning" title="Warnung" %}}

Die Methode [License.set_license](https://reference.aspose.com/slides/de/python-net/aspose.slides/license/set_license/) ist nicht thread‑sicher. Wenn Sie sie gleichzeitig aus mehreren Threads aufrufen müssen, verwenden Sie ein Synchronisations‑Primitive wie `threading.Lock`, um Probleme zu vermeiden.

{{% /alert %}}

## **FAQ**

### Kann ich die Lizenz in einer vollständig offline‑Umgebung (kein Internetzugriff) anwenden?

Ja. Die Lizenzvalidierung erfolgt lokal mittels der Lizenzdatei; eine Internetverbindung ist nicht erforderlich.

### Was passiert, wenn das einjährige Abonnement abläuft? Hört die Bibliothek auf zu funktionieren?

Nein. Die Lizenz ist unbefristet: Sie können weiterhin Versionen verwenden, die vor dem Enddatum Ihres Abonnements veröffentlicht wurden; Sie können jedoch neuere Versionen nur nach einer Verlängerung nutzen.