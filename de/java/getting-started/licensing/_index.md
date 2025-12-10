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
description: "Lizenzen in Aspose.Slides für Java anwenden, verwalten und Fehler beheben. Stellen Sie mit unserer Schritt-für-Schritt-Anleitung zur Lizenzierung einen ununterbrochenen Zugriff auf alle Funktionen sicher."
---

## **Aspose.Slides bewerten**

{{% alert color="primary" %}} 

Sie können eine Evaluierungs‑Version von **Aspose.Slides for Java** von der entsprechenden [Download‑Seite](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) herunterladen. Die Evaluierungs‑Version bietet dieselben Funktionen wie die lizenzierte Produktversion. Das Evaluierungspaket ist identisch mit dem erworbenen Paket. Die Evaluierungs‑Version wird einfach lizenziert, sobald Sie ein paar Code‑Zeilen hinzufügen (um die Lizenz zu aktivieren).

Wenn Sie mit Ihrer Evaluierung von **Aspose.Slides** zufrieden sind, können Sie eine [Lizenz erwerben](https://purchase.aspose.com/buy). Wir empfehlen, die verschiedenen Abonnement‑Modelle zu prüfen. Bei Fragen wenden Sie sich an das Vertriebsteam von Aspose.

Jede Aspose‑Lizenz beinhaltet ein einjähriges Abonnement für kostenlose Upgrades auf neue Versionen oder für innerhalb des Abonnement‑Zeitraums veröffentlichte Fehlerbehebungen. Nutzer mit lizenzierten Produkten (oder sogar Evaluierungs‑Versionen) erhalten kostenlosen und uneingeschränkten technischen Support.

{{% /alert %}} 

**Einschränkungen der Evaluierungs‑Version**

* Obwohl die Evaluierungs‑Version von Aspose.Slides (ohne angegebene Lizenz) die volle Funktionalität bereitstellt, fügt sie bei Öffnen und Speichern ein Evaluierungs‑Wasserzeichen am oberen Rand des Dokuments ein. 
* Beim Extrahieren von Texten aus Präsentationsfolien ist die Anzahl der Folien auf eins begrenzt.

{{% alert color="primary" %}} 

Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30‑tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie auf der Seite [Wie man eine temporäre Lizenz erhält](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Lizenzierung in Aspose.Slides**

* Eine Evaluierungs‑Version wird lizenziert, sobald Sie eine Lizenz erwerben und ein paar Zeilen Code hinzufügen (um die Lizenz zu aktivieren).
* Die Lizenz ist eine reine XML‑Textdatei, die Details wie Produktname, Anzahl der lizenzierten Entwickler, Ablaufdatum des Abonnements usw. enthält. 
* Die Lizenzdatei ist digital signiert, daher darf sie nicht geändert werden. Schon das versehentliche Hinzufügen eines zusätzlichen Zeilenumbruchs macht die Lizenz ungültig.
* Aspose.Slides for Java sucht die Lizenz in der Regel an folgenden Stellen:
  * Ein expliziter Pfad
  * Der Ordner, der Aspose.Slides.jar enthält
* Um die Einschränkungen der Evaluierungs‑Version zu umgehen, müssen Sie vor der Verwendung von **Aspose.Slides** eine Lizenz setzen. Das ist nur einmal pro Anwendung oder Prozess nötig.

{{% alert color="primary" %}} 

Weitere Informationen finden Sie unter [Metered Licensing](/slides/de/java/metered-licensing/).

{{% /alert %}} 


## **Lizenz anwenden**

Eine Lizenz kann aus einer **Datei** oder einem **Stream** geladen werden.

{{% alert color="primary" %}}

Aspose.Slides stellt die Klasse [License](https://reference.aspose.com/slides/java/com.aspose.slides/License) für Lizenz‑Operationen bereit.

{{% /alert %}} 

{{% alert color="warning" %}}

Neue Lizenzen aktivieren Aspose.Slides nur ab Version 21.4 oder höher. Frühere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.

{{% /alert %}}

### **Datei**

Die einfachste Methode, eine Lizenz zu setzen, besteht darin, die Lizenzdatei in den Ordner zu kopieren, der Aspose.Slides.jar oder das JAR Ihrer Anwendung enthält.

Dieses Java‑Beispiel zeigt, wie eine Lizenzdatei gesetzt wird:
``` java
// Instanziiert die License-Klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Setzt den Pfad zur Lizenzdatei
license.setLicense("Aspose.Slides.Java.lic");
```


{{% alert color="warning" %}} 

Wenn Sie die Lizenzdatei in einem anderen Verzeichnis ablegen, muss beim Aufruf der Methode [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.lang.String-) der Dateiname am Ende des angegebenen Pfades exakt mit dem Namen Ihrer Lizenzdatei übereinstimmen.

Beispielsweise können Sie den Lizenzdateinamen in *Aspose.Slides.Java.lic.xml* ändern. Dann müssen Sie in Ihrem Code den Pfad zur Datei (der mit *Aspose.Slides.Java.lic.xml* endet) an die Methode [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.lang.String-) übergeben.

{{% /alert %}}

### **Stream**

Sie können eine Lizenz aus einem Stream laden. Dieses Java‑Beispiel zeigt, wie eine Lizenz aus einem Stream angewendet wird:
``` java
// Instanziert die License-Klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Setzt die Lizenz über einen Stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```


### **PHP/Java Bridge**

Wenn Sie Aspose.Slides for PHP über Java verwenden, können Sie die Lizenz über eine PHP/Java‑Bridge setzen. Diese Bridge ermöglicht die Nutzung von Java‑Klassen in PHP‑Syntax. Weitere Informationen finden Sie unter [License in PHP](/slides/de/php-java/licensing/).

## **Lizenz prüfen**

Um zu überprüfen, ob eine Lizenz korrekt gesetzt wurde, können Sie sie validieren. Dieses Java‑Beispiel zeigt, wie eine Lizenz validiert wird:
```java
License license = new License();
license.setLicense("Asppose.Slides.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```


## **Thread‑Sicherheit**

{{% alert title="Hinweis" color="warning" %}} 

Die Methode [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.io.InputStream-) ist nicht threadsicher. Wenn diese Methode gleichzeitig von vielen Threads aufgerufen werden muss, sollten Sie Synchronisations‑Primitive (wie ein Lock) einsetzen, um Probleme zu vermeiden. 

{{% /alert %}}

## **FAQ**

**Kann ich die Lizenz in einer völlig offline Umgebung (ohne Internetzugang) anwenden?**

Ja. Die Lizenzprüfung erfolgt lokal anhand der Lizenzdatei; eine Internetverbindung ist nicht erforderlich.

**Was passiert, wenn das einjährige Abonnement abläuft? Hört die Bibliothek dann auf zu funktionieren?**

Nein. Die Lizenz ist dauerhaft gültig: Sie können weiterhin Versionen verwenden, die vor dem Ende Ihres Abonnements veröffentlicht wurden; Sie können jedoch neuere Releases nicht ohne Erneuerung nutzen.