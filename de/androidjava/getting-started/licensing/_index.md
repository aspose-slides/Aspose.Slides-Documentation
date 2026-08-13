---
title: Lizenzierung
type: docs
weight: 90
url: /de/androidjava/licensing/
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
- Android
- Java
- Aspose.Slides
description: "Lizenzen in Aspose.Slides für Android via Java anwenden, verwalten und Fehler beheben. Stellen Sie mit unserem Lizenzleitfaden einen ununterbrochenen Zugriff auf alle Funktionen sicher."
---
## **Übersicht**

Aspose.Slides kann im Evaluierungsmodus oder mit einer gültigen Lizenz verwendet werden. Die Evaluierungs‑Version bietet dieselbe Funktionalität wie die lizenzierte Version, fügt jedoch ein Evaluierungs‑Wasserzeichen ein, wenn Präsentationen geöffnet oder gespeichert werden, und beschränkt die Textextraktion auf eine Folie.

Dieser Artikel erklärt, wie die Lizenzierung in Aspose.Slides funktioniert und wie Sie vor der Nutzung der Bibliothek eine Lizenz anwenden. Eine Lizenz kann aus einer Datei, einem Stream oder einer eingebetteten Ressource mithilfe der `License`‑Klasse geladen werden. Der Artikel zeigt zudem, wie Sie prüfen können, ob eine Lizenz korrekt angewendet wurde.

## **Aspose.Slides evaluieren**

{{% alert color="info" %}} 

Sie können eine Evaluierungs‑Version von **Aspose.Slides for Android via Java** von der entsprechenden [Download-Seite](https://releases.aspose.com/slides/de/androidjava/) herunterladen. Die Evaluierungs‑Version bietet dieselben Funktionalitäten wie die lizenzierte Version des Produkts. Das Evaluierungs‑Paket ist identisch mit dem gekauften Paket. Die Evaluierungs‑Version wird einfach lizenziert, sobald Sie ein paar Code‑Zeilen hinzufügen (um die Lizenz anzuwenden).

Sobald Sie mit Ihrer Evaluation von **Aspose.Slides** zufrieden sind, können Sie eine [Lizenz erwerben](https://purchase.aspose.com/buy). Wir empfehlen Ihnen, die verschiedenen Abonnement‑Typen zu prüfen. Bei Fragen kontaktieren Sie bitte das Aspose‑Vertriebsteam.

Jede Aspose‑Lizenz beinhaltet ein einjähriges Abonnement für kostenlose Upgrades auf neue Versionen oder Fehlerbehebungen, die innerhalb des Abonnementzeitraums veröffentlicht werden. Nutzer mit lizenzierten Produkten (oder sogar Evaluierungs‑Versionen) erhalten kostenlosen und unbegrenzten technischen Support.

{{% /alert %}} 

**Einschränkungen der Evaluierungs‑Version**

* Während die Evaluierungs‑Version von Aspose.Slides (ohne angegebene Lizenz) die volle Produktfunktionalität bietet, fügt sie bei Öffnen und Speichern ein Evaluierungs‑Wasserzeichen oben im Dokument ein. 
* Beim Extrahieren von Texten aus Präsentationsfolien sind Sie auf eine Folie beschränkt.

{{% alert color="info" %}} 

Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30‑tägige Temporäre Lizenz** anfordern. Weitere Informationen finden Sie auf der Seite [How to get a Temporary License](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Lizenzierung in Aspose.Slides**

* Eine Evaluierungs‑Version wird nach dem Kauf einer Lizenz und dem Hinzufügen einiger Code‑Zeilen (um die Lizenz anzuwenden) lizenziert. 
* Die Lizenz ist eine reine Text‑XML‑Datei, die Details wie Produktname, Anzahl der lizenzierten Entwickler, Ablaufdatum des Abonnements usw. enthält. 
* Die Lizenzdatei ist digital signiert, daher dürfen Sie die Datei nicht ändern. Selbst das versehentliche Hinzufügen eines zusätzlichen Zeilenumbruchs zum Inhalt der Datei macht sie ungültig. 
* Aspose.Slides for Android via Java sucht die Lizenz typischerweise an folgenden Orten:
  * Ein expliziter Pfad
  * Der Ordner, der Aspose.Slides.jar enthält
* Um die Einschränkungen der Evaluierungs‑Version zu vermeiden, müssen Sie vor der Verwendung von **Aspose.Slides** eine Lizenz setzen. Sie müssen die Lizenz nur einmal pro Anwendung oder Prozess setzen.

## **Lizenz anwenden**

Eine Lizenz kann aus einer **Datei** oder einem **Stream** geladen werden.

{{% alert color="info" %}}

Aspose.Slides stellt die [License](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/license/)‑Klasse für Lizenz‑Operationen bereit.

{{% /alert %}} 

{{% alert color="warning" %}}

Neue Lizenzen können Aspose.Slides nur ab Version 21.4 aktivieren. Frühere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.

{{% /alert %}}

### **Datei**

Die einfachste Methode, eine Lizenz zu setzen, besteht darin, die Lizenzdatei in den Ordner zu legen, der Aspose.Slides.jar oder das JAR Ihrer Anwendung enthält.

Dieses Java‑Beispiel zeigt, wie Sie eine Lizenzdatei setzen:

``` java
// Instanziert die License-Klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Setzt den Pfad zur Lizenzdatei
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 

Wenn Sie die Lizenzdatei in einem anderen Verzeichnis ablegen, muss beim Aufruf der [SetLicense](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-)‑Methode der Lizenzdateiname am Ende des angegebenen expliziten Pfads exakt dem Namen Ihrer Lizenzdatei entsprechen.

Beispielsweise können Sie den Lizenzdateinamen in *Aspose.Slides.Android.via.Java.lic.xml* ändern. Dann müssen Sie in Ihrem Code den Pfad zur Datei (endend mit *Aspose.Slides.Android.via.Java.lic.xml*) an die [SetLicense](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-)‑Methode übergeben.

{{% /alert %}}

### **Stream**

Sie können eine Lizenz aus einem Stream laden. Dieses Java‑Beispiel zeigt, wie Sie eine Lizenz aus einem Stream anwenden:

``` java
// Instanziert die License-Klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Setzt die Lizenz über einen Stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

## **Lizenz validieren**

Um zu prüfen, ob eine Lizenz korrekt gesetzt wurde, können Sie sie validieren. Dieses Java‑Beispiel zeigt, wie Sie eine Lizenz validieren:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Thread‑Sicherheit**

{{% alert title="Note" color="warning" %}} 

Die [SetLicense](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-)‑Methode ist nicht threadsicher. Wenn diese Methode gleichzeitig von vielen Threads aufgerufen werden muss, sollten Sie Synchronisations‑Primitiven (wie ein Lock) verwenden, um Probleme zu vermeiden. 

{{% /alert %}}

## **FAQ**

### Kann ich die Lizenz in einer komplett offline Umgebung (keine Internetverbindung) anwenden?

Ja. Die Lizenzvalidierung wird lokal mithilfe der Lizenzdatei durchgeführt; eine Internetverbindung ist nicht erforderlich.

### Was passiert, wenn das einjährige Abonnement abläuft? Hört die Bibliothek auf zu funktionieren?

Nein. Die Lizenz ist dauerhaft: Sie können weiterhin Versionen verwenden, die vor dem Ende Ihres Abonnements veröffentlicht wurden; Sie können jedoch neuere Releases nur mit einer erneuten Lizenz erwerben.