---
title: Lizenzierung
type: docs
weight: 90
url: /de/java/licensing/
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
- Java
- Aspose.Slides
description: "Lizenzen in Aspose.Slides für Java anwenden, verwalten und Fehler beheben. Stellen Sie mit unserem schrittweisen Lizenzierungsleitfaden einen ununterbrochenen Zugriff auf alle Funktionen sicher."
---
## **Übersicht**

Aspose.Slides kann im Evaluierungsmodus oder mit einer gültigen Lizenz verwendet werden. Die Evaluierungsversion bietet dieselbe Funktionalität wie die lizenzierte Version, fügt jedoch jedem Folienbereich jeder Präsentation, die sie speichert, ein Evaluierungswasserzeichen hinzu und kürzt Text, den Ihr Code über die API liest.

Dieser Artikel erklärt, wie die Lizenzierung in Aspose.Slides funktioniert und wie man eine Lizenz anwendet, bevor die Bibliothek verwendet wird. Eine Lizenz kann aus einer Datei, einem Stream oder einer eingebetteten Ressource über die Klasse `License` geladen werden. Der Artikel zeigt zudem, wie man überprüft, ob eine Lizenz korrekt angewendet wurde.

## **Aspose.Slides evaluieren**

{{% alert color="info" title="Note" %}}
Sie können eine Evaluierungsversion von **Aspose.Slides for Java** von seiner [Downloadseite](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) herunterladen. Die Evaluierungsversion bietet dieselben Funktionen wie die lizenzierte Version des Produkts. Das Evaluierungspaket entspricht dem erworbenen Paket. Die Evaluierungsversion wird einfach lizenziert, nachdem Sie ein paar Codezeilen hinzugefügt haben (um die Lizenz anzuwenden).

Wenn Sie mit Ihrer Evaluierung von **Aspose.Slides** zufrieden sind, können Sie [eine Lizenz kaufen](https://purchase.aspose.com/pricing/slides/de/java/). Wir empfehlen Ihnen, die verschiedenen Abonnementtypen zu prüfen. Bei Fragen kontaktieren Sie das Vertriebsteam von Aspose.

Jede Aspose-Lizenz enthält ein einjähriges Abonnement für kostenlose Upgrades auf neue Versionen oder Fehlerbehebungen, die innerhalb des Abonnementzeitraums veröffentlicht werden. Benutzer mit lizenzierten Produkten (oder sogar Evaluierungsversionen) erhalten freien und unbegrenzten technischen Support.
{{% /alert %}} 

**Einschränkungen der Evaluierungsversion**

* Die Evaluierungsversion (ohne angegebene Lizenz) bietet die volle Produktfunktionalität, fügt jedoch jedem Folienbereich jeder Präsentation, die sie speichert, ein Evaluierungswasserzeichen‑Textfeld hinzu.
* Text, den Ihr Code über die API liest, einschließlich Text, den er gerade gesetzt hat, wird auf die ersten wenigen Zeichen gekürzt, gefolgt von einem Hinweis auf die Evaluierungsbeschränkung. Text, den Ihr Code schreibt, wird vollständig gespeichert.

{{% alert color="info" title="Note" %}}
Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30‑tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie auf der Seite [Wie man eine temporäre Lizenz erhält](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Lizenzierung in Aspose.Slides**

* Eine Evaluierungsversion wird nach dem Kauf einer Lizenz und dem Hinzufügen einiger Codezeilen (um die Lizenz anzuwenden) lizenziert.
* Die Lizenz ist eine Klartext‑XML‑Datei, die Details wie den Produktnamen, die Anzahl der lizenzierten Entwickler, das Ablaufdatum des Abonnements usw. enthält.
* Die Lizenzdatei ist digital signiert, daher dürfen Sie die Datei nicht ändern. Auch das versehentliche Hinzufügen eines zusätzlichen Zeilenumbruchs zum Inhalt der Datei macht sie ungültig.
* Aspose.Slides for Java sucht die Lizenz typischerweise an folgenden Orten:
  * Einem expliziten Pfad
  * Dem Ordner, der Aspose.Slides.jar enthält
* Um die mit der Evaluierungsversion verbundenen Einschränkungen zu vermeiden, müssen Sie eine Lizenz setzen, bevor Sie **Aspose.Slides** verwenden. Sie müssen die Lizenz nur einmal pro Anwendung oder Prozess setzen.

{{% alert color="info" title="Note" %}}
Vielleicht möchten Sie sich [Nutzungsbasierte Lizenzierung](/slides/de/java/metered-licensing/) ansehen.
{{% /alert %}} 

## **Anwenden einer Lizenz**

Eine Lizenz kann aus einer **Datei** oder einem **Stream** geladen werden.

{{% alert color="info" title="Note" %}}
Aspose.Slides stellt die Klasse [License](https://reference.aspose.com/slides/de/java/com.aspose.slides/license/) für Lizenzvorgänge bereit.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Neue Lizenzen können Aspose.Slides nur ab Version 21.4 aktivieren. Frühere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.
{{% /alert %}}

### **Datei**

Die einfachste Methode, eine Lizenz zu setzen, besteht darin, die Lizenzdatei in den Ordner zu legen, der Aspose.Slides.jar oder das Jar Ihrer Anwendung enthält.

``` java
// Instanziert die License-Klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Setzt den Pfad zur Lizenzdatei
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" title="Warning" %}}
Wenn Sie die Lizenzdatei in einem anderen Verzeichnis ablegen, muss beim Aufruf der Methode [setLicense](https://reference.aspose.com/slides/de/java/com.aspose.slides/license/#setLicense-java.lang.String-) der Dateiname der Lizenz am Ende des angegebenen Pfads mit Ihrem Lizenzdateinamen übereinstimmen.

Beispielsweise können Sie den Lizenzdateinamen in *Aspose.Slides.Java.lic.xml* ändern. Anschließend müssen Sie in Ihrem Code den Pfad zur Datei (beginnend mit *Aspose.Slides.Java.lic.xml*) an die Methode [setLicense](https://reference.aspose.com/slides/de/java/com.aspose.slides/license/#setLicense-java.lang.String-) übergeben.
{{% /alert %}}

### **Stream**

Sie können eine Lizenz aus einem Stream laden. Dieser Java‑Code zeigt, wie man eine Lizenz aus einem Stream anwendet:

``` java
// Instanziert die License-Klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Setzt die Lizenz über einen Stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Wenn Sie Aspose.Slides für PHP über Java verwenden, können Sie eine Lizenz über eine PHP/Java‑Bridge setzen. Diese Bridge ermöglicht es, Java‑Klassen in PHP‑Syntax zu nutzen. Weitere Informationen finden Sie unter [Lizenz in PHP](/slides/de/php-java/licensing/).

## **Validierung einer Lizenz**

Um zu überprüfen, ob eine Lizenz korrekt gesetzt wurde, können Sie sie validieren. Dieser Java‑Code zeigt, wie man eine Lizenz validiert:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Thread‑Sicherheit**

{{% alert color="warning" title="Warning" %}}
Die Methode [setLicense](https://reference.aspose.com/slides/de/java/com.aspose.slides/license/#setLicense-java.io.InputStream-) ist nicht thread‑sicher. Wenn diese Methode gleichzeitig von vielen Threads aufgerufen werden muss, sollten Sie Synchronisations‑Primitive (wie ein Lock) verwenden, um Probleme zu vermeiden.
{{% /alert %}}

## **FAQ**

### Kann ich die Lizenz in einer vollständig offline Umgebung (keine Internetverbindung) anwenden?

Ja. Die Lizenzprüfung erfolgt lokal mit der Lizenzdatei; eine Internetverbindung ist nicht erforderlich.

### Was passiert, wenn das einjährige Abonnement abläuft? Hört die Bibliothek auf zu funktionieren?

Nein. Die Lizenz ist dauerhaft: Sie können weiterhin Versionen verwenden, die vor dem Ende Ihres Abonnements veröffentlicht wurden; Sie können jedoch neuere Releases nicht nutzen, solange Sie nicht erneuern.