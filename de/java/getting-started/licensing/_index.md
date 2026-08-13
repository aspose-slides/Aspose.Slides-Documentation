---
title: Lizenzierung
type: docs
weight: 90
url: /de/java/licensing/
keywords:
- Lizenz
- Temporäre Lizenz
- Lizenz setzen
- Lizenz verwenden
- Lizenz prüfen
- Lizenzdatei
- Evaluationsversion
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Lizenzen in Aspose.Slides für Java anwenden, verwalten und Fehler beheben. Gewährleisten Sie einen ununterbrochenen Zugriff auf alle Funktionen mit unserer Schritt-für-Schritt-Lizenzierungsanleitung."
---
## **Übersicht**

Aspose.Slides kann im Evaluationsmodus oder mit einer gültigen Lizenz verwendet werden. Die Evaluationsversion bietet dieselbe Funktionalität wie die lizenzierte Version, fügt jedoch ein Evaluationswasserzeichen ein, wenn Präsentationen geöffnet oder gespeichert werden, und beschränkt die Textextraktion auf eine Folie.

Dieser Artikel erklärt, wie die Lizenzierung in Aspose.Slides funktioniert und wie Sie vor der Verwendung der Bibliothek eine Lizenz anwenden. Eine Lizenz kann aus einer Datei, einem Stream oder einer eingebetteten Ressource mithilfe der `License`‑Klasse geladen werden. Der Artikel zeigt außerdem, wie Sie prüfen können, ob eine Lizenz korrekt angewendet wurde.

## **Aspose.Slides evaluieren**

{{% alert color="info" %}} 

Sie können eine Evaluationsversion von **Aspose.Slides for Java** von deren [Download‑Seite](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) herunterladen. Die Evaluationsversion bietet dieselben Funktionalitäten wie die lizenzierte Version des Produkts. Das Evaluationspaket entspricht dem gekauften Paket. Die Evaluationsversion wird einfach lizenziert, nachdem Sie ein paar Codezeilen hinzugefügt haben (um die Lizenz anzuwenden).

Wenn Sie mit Ihrer Evaluierung von **Aspose.Slides** zufrieden sind, können Sie eine [Lizenz erwerben](https://purchase.aspose.com/buy). Wir empfehlen Ihnen, die verschiedenen Abonnementtypen zu prüfen. Bei Fragen kontaktieren Sie das Vertriebsteam von Aspose.

Jede Aspose‑Lizenz enthält ein einjähriges Abonnement für kostenlose Upgrades auf neue Versionen oder Fehlerbehebungen, die während des Abonnementzeitraums veröffentlicht werden. Benutzer mit lizenzierten Produkten (oder sogar Evaluationsversionen) erhalten kostenlosen und unbegrenzten technischen Support.

{{% /alert %}} 

**Einschränkungen der Evaluationsversion**

* Während die Evaluationsversion von Aspose.Slides (ohne angegebene Lizenz) die volle Produktfunktionalität bietet, fügt sie beim Öffnen und Speichern ein Evaluationswasserzeichen oben im Dokument ein. 
* Die Textextraktion aus Präsentationsfolien ist auf eine Folie beschränkt.

{{% alert color="info" %}} 

Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30‑tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie auf der Seite [How to get a Temporary License](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Lizenzierung in Aspose.Slides**

* Eine Evaluationsversion wird lizenziert, nachdem Sie eine Lizenz gekauft und einige Codezeilen hinzugefügt haben (um die Lizenz anzuwenden).
* Die Lizenz ist eine reine Text‑XML‑Datei, die Details wie den Produktnamen, die Anzahl der lizenzierten Entwickler, das Ablaufdatum des Abonnements usw. enthält. 
* Die Lizenzdatei ist digital signiert, daher dürfen Sie die Datei nicht ändern. Selbst das versehentliche Hinzufügen eines zusätzlichen Zeilenumbruchs zum Inhalt der Datei macht sie ungültig.
* Aspose.Slides for Java sucht die Lizenz in der Regel an folgenden Orten:
  * Ein expliziter Pfad
  * Der Ordner, der Aspose.Slides.jar enthält
* Um die mit der Evaluationsversion verbundenen Einschränkungen zu vermeiden, müssen Sie vor der Verwendung von **Aspose.Slides** eine Lizenz setzen. Sie müssen die Lizenz nur einmal pro Anwendung oder Prozess setzen.

{{% alert color="info" %}} 

Vielleicht möchten Sie sich [Metered Licensing](/slides/de/java/metered-licensing/) ansehen.

{{% /alert %}} 


## **Anwenden einer Lizenz**

Eine Lizenz kann aus einer **Datei** oder einem **Stream** geladen werden.

{{% alert color="info" %}}

Aspose.Slides stellt die [License](https://reference.aspose.com/slides/de/java/com.aspose.slides/License)-Klasse für Lizenzvorgänge bereit.

{{% /alert %}} 

{{% alert color="warning" %}}

Neue Lizenzen können Aspose.Slides nur mit Version 21.4 oder höher aktivieren. Ältere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.

{{% /alert %}}

### **Datei**

Die einfachste Methode, eine Lizenz zu setzen, besteht darin, die Lizenzdatei in den Ordner zu legen, der Aspose.Slides.jar oder das JAR Ihrer Anwendung enthält.

Dieser Java‑Code zeigt, wie man eine Lizenzdatei setzt:

``` java
// Instanziert die License-Klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Setzt den Pfad zur Lizenzdatei
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Wenn Sie die Lizenzdatei in einem anderen Verzeichnis ablegen, muss beim Aufruf der [SetLicense](https://reference.aspose.com/slides/de/java/com.aspose.slides/License#setLicense-java.lang.String-)‑Methode der Lizenzdateiname am Ende des angegebenen Pfades mit dem Namen Ihrer Lizenzdatei übereinstimmen.

Beispielsweise können Sie den Lizenzdateinamen zu *Aspose.Slides.Java.lic.xml* ändern. Anschließend müssen Sie in Ihrem Code den Pfad zur Datei (der mit *Aspose.Slides.Java.lic.xml* endet) an die [SetLicense](https://reference.aspose.com/slides/de/java/com.aspose.slides/License#setLicense-java.lang.String-)‑Methode übergeben.

{{% /alert %}}

### **Stream**

Sie können eine Lizenz aus einem Stream laden. Dieser Java‑Code zeigt, wie man eine Lizenz aus einem Stream anwendet:

``` java
// Instanziert die License-Klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Setzt die Lizenz über einen Stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java‑Bridge**

Wenn Sie Aspose.Slides für PHP über Java verwenden, können Sie eine Lizenz über eine PHP/Java‑Bridge setzen. Diese Bridge ermöglicht die Nutzung von Java‑Klassen in PHP‑Syntax. Weitere Informationen finden Sie in [License in PHP](/slides/de/php-java/licensing/).

## **Validieren einer Lizenz**

Um zu prüfen, ob eine Lizenz korrekt gesetzt wurde, können Sie sie validieren. Dieser Java‑Code zeigt, wie man eine Lizenz validiert:

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

{{% alert title="Note" color="warning" %}} 

Die [SetLicense](https://reference.aspose.com/slides/de/java/com.aspose.slides/License#setLicense-java.io.InputStream-)‑Methode ist nicht threadsicher. Wenn diese Methode gleichzeitig von vielen Threads aufgerufen werden muss, sollten Sie Synchronisations‑Primitiven (wie ein Lock) verwenden, um Probleme zu vermeiden. 

{{% /alert %}}

## **FAQ**

### Kann ich die Lizenz in einer vollständig offline‑Umgebung (ohne Internetzugang) anwenden?

Ja. Die Lizenzvalidierung erfolgt lokal mit der Lizenzdatei; eine Internetverbindung ist nicht erforderlich.

### Was passiert, wenn das einjährige Abonnement abläuft? Hört die Bibliothek auf zu funktionieren?

Nein. Die Lizenz ist unbefristet: Sie können weiterhin Versionen nutzen, die vor dem Ende Ihres Abonnements veröffentlicht wurden; Sie können jedoch keine neueren Versionen ohne Erneuerung verwenden.