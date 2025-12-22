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
description: "Lizenzen anwenden, verwalten und Fehlersuche in Aspose.Slides für Android via Java. Sicherstellen des ununterbrochenen Zugriffs auf alle Funktionen mit unserem Lizenzierungsleitfaden."
---

## **Bewerten von Aspose.Slides**

{{% alert color="primary" %}} 

Sie können eine Evaluierungsversion von **Aspose.Slides for Android via Java** von der entsprechenden [Download-Seite](https://releases.aspose.com/slides/androidjava/) herunterladen. Die Evaluierungsversion bietet dieselben Funktionen wie die lizenzierte Produktversion. Das Evaluierungspaket ist identisch mit dem erworbenen Paket. Die Evaluierungsversion wird einfach lizenziert, sobald Sie ein paar Code‑Zeilen hinzufügen (um die Lizenz anzuwenden).

Sobald Sie mit Ihrer Evaluierung von **Aspose.Slides** zufrieden sind, können Sie eine [Lizenz erwerben](https://purchase.aspose.com/buy). Wir empfehlen, die verschiedenen Abonnement‑Typen zu prüfen. Bei Fragen kontaktieren Sie das Aspose‑Verkaufsteam.

Jede Aspose‑Lizenz beinhaltet ein einjähriges Abonnement für kostenlose Upgrades auf neue Versionen oder Korrekturen, die innerhalb des Abonnementzeitraums veröffentlicht werden. Benutzer mit lizenzierten Produkten (oder sogar Evaluierungsversionen) erhalten kostenlosen und unbegrenzten technischen Support.

{{% /alert %}} 

**Einschränkungen der Evaluierungsversion**

* Während die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) die volle Produktfunktionalität bereitstellt, fügt sie bei Öffnen und Speichern ein Evaluierungs‑Wasserzeichen oben im Dokument ein. 
* Beim Extrahieren von Texten aus Präsentationsfolien ist die Ausgabe auf eine Folie begrenzt.

{{% alert color="primary" %}} 

Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30‑tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie auf der Seite [How to get a Temporary License](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Lizenzierung in Aspose.Slides**

* Eine Evaluierungsversion wird lizenziert, sobald Sie eine Lizenz erwerben und ein paar Code‑Zeilen hinzufügen (um die Lizenz anzuwenden).
* Die Lizenz ist eine reine Text‑XML‑Datei, die Details wie Produktname, Anzahl der lizenzierten Entwickler, Ablaufdatum des Abonnements usw. enthält. 
* Die Lizenzdatei ist digital signiert, daher dürfen Sie die Datei nicht verändern. Schon das versehentliche Hinzufügen eines zusätzlichen Zeilenumbruchs zum Dateiinhalt macht die Lizenz ungültig.
* Aspose.Slides for Android via Java sucht die Lizenz typischerweise an folgenden Stellen:
  * Ein expliziter Pfad
  * Der Ordner, der Aspose.Slides.jar enthält
* Um die mit der Evaluierungsversion verbundenen Einschränkungen zu vermeiden, müssen Sie vor der Nutzung von **Aspose.Slides** eine Lizenz setzen. Sie müssen die Lizenz nur einmal pro Anwendung oder Prozess setzen.

{{% alert color="primary" %}} 

Vielleicht möchten Sie sich die [Metered Licensing](/slides/de/androidjava/metered-licensing/) ansehen.

{{% /alert %}} 


## **Anwenden einer Lizenz**

Eine Lizenz kann aus einer **Datei** oder einem **Stream** geladen werden.

{{% alert color="primary" %}}

Aspose.Slides stellt die [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/)‑Klasse für Lizenzvorgänge bereit.

{{% /alert %}} 

{{% alert color="warning" %}}

Neue Lizenzen aktivieren Aspose.Slides nur ab Version 21.4 oder später. Ältere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.

{{% /alert %}}

### **Datei**

Die einfachste Methode, eine Lizenz zu setzen, besteht darin, die Lizenzdatei im Ordner zu platzieren, der Aspose.Slides.jar oder das JAR Ihrer Anwendung enthält.

Dieses Java‑Beispiel zeigt, wie Sie eine Lizenzdatei setzen:
``` java
// Instanziiert die License-Klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Setzt den Pfad zur Lizenzdatei
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```


{{% alert color="warning" %}} 

Wenn Sie die Lizenzdatei in einem anderen Verzeichnis ablegen, muss beim Aufruf der [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-)‑Methode der Dateiname am Ende des angegebenen expliziten Pfads genau dem Ihrer Lizenzdatei entsprechen.

Beispielsweise können Sie den Lizenzdateinamen in *Aspose.Slides.Android.via.Java.lic.xml* ändern. Dann müssen Sie in Ihrem Code den Pfad zur Datei (der mit *Aspose.Slides.Android.via.Java.lic.xml* endet) an die [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-)‑Methode übergeben.

{{% /alert %}}

### **Stream**

Sie können eine Lizenz aus einem Stream laden. Dieses Java‑Beispiel zeigt, wie Sie eine Lizenz aus einem Stream anwenden:
``` java
// Instanziert die License-Klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Setzt die Lizenz über einen Stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```


## **Validierung einer Lizenz**

Um zu prüfen, ob eine Lizenz korrekt gesetzt wurde, können Sie sie validieren. Dieses Java‑Beispiel zeigt, wie Sie eine Lizenz validieren:
```java
License license = new License();
license.setLicense("Aspuse.Slides.Android.via.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```


## **Thread‑Sicherheit**

{{% alert title="Note" color="warning" %}} 

Die [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-)‑Methode ist nicht thread‑sicher. Wenn diese Methode gleichzeitig von vielen Threads aufgerufen werden muss, sollten Sie Synchronisations‑Primitive (wie ein Lock) verwenden, um Probleme zu vermeiden. 

{{% /alert %}}

## **FAQ**

**Kann ich die Lizenz in einer komplett offline Umgebung (kein Internetzugang) anwenden?**

Ja. Die Lizenzvalidierung erfolgt lokal anhand der Lizenzdatei; eine Internetverbindung ist nicht erforderlich.

**Was passiert, wenn das einjährige Abonnement abläuft? Hört die Bibliothek auf zu funktionieren?**

Nein. Die Lizenz ist unbegrenzt gültig: Sie können weiterhin Versionen nutzen, die vor dem Ende Ihres Abonnements veröffentlicht wurden; Sie können jedoch neuere Releases nur nach einer Verlängerung des Abonnements verwenden.