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
description: "Lizenzen in Aspose.Slides für Android via Java anwenden, verwalten und Probleme beheben. Gewährleisten Sie einen ununterbrochenen Zugriff auf alle Funktionen mit unserem Lizenzierungsleitfaden."
---

## **Evaluierung von Aspose.Slides**

{{% alert color="primary" %}} 
Sie können eine Evaluierungsversion von **Aspose.Slides for Android via Java** von der jeweiligen [Download‑Seite](https://releases.aspose.com/slides/androidjava/) herunterladen. Die Evaluierungsversion bietet dieselben Funktionen wie die lizenzierte Version des Produkts. Das Evaluierungspaket entspricht dem erworbenen Paket. Die Evaluierungsversion wird einfach lizenziert, wenn Sie ein paar Codezeilen hinzufügen (um die Lizenz anzuwenden).

Wenn Sie mit Ihrer Evaluierung von **Aspose.Slides** zufrieden sind, können Sie eine [Lizenz kaufen](https://purchase.aspose.com/buy). Wir empfehlen Ihnen, die verschiedenen Abonnementarten zu prüfen. Bei Fragen kontaktieren Sie das Vertriebsteam von Aspose.

Jede Aspose‑Lizenz beinhaltet ein einjähriges Abonnement für kostenlose Upgrades auf neue Versionen oder Fehlerbehebungen, die innerhalb des Abonnementzeitraums veröffentlicht werden. Benutzer mit lizenzierten Produkten (auch Evaluierungsversionen) erhalten kostenlosen und unbegrenzten technischen Support.
{{% /alert %}} 

**Einschränkungen der Evaluierungsversion**

* Während die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) die vollständige Produktfunktionalität bietet, fügt sie bei Öffnungs‑ und Speicheroperationen ein Evaluierungswasserzeichen oben im Dokument ein. 
* Sie sind beim Extrahieren von Texten aus Präsentationsfolien auf eine Folie beschränkt.

{{% alert color="primary" %}} 
Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30‑tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie auf der Seite [How to get a Temporary License](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Lizenzierung in Aspose.Slides**

* Eine Evaluierungsversion wird lizenziert, nachdem Sie eine Lizenz gekauft und ein paar Codezeilen hinzugefügt haben (um die Lizenz anzuwenden).
* Die Lizenz ist eine reine Text‑XML‑Datei, die Details wie den Produktnamen, die Anzahl der lizenzierten Entwickler, das Ablaufdatum des Abonnements usw. enthält. 
* Die Lizenzdatei ist digital signiert und darf daher nicht geändert werden. Schon das versehentliche Hinzufügen eines Zeilenumbruchs zum Inhalt der Datei macht sie ungültig.
* Aspose.Slides for Android via Java sucht die Lizenz typischerweise an folgenden Orten:
  * Ein expliziter Pfad
  * Der Ordner, der Aspose.Slides.jar enthält
* Um die mit der Evaluierungsversion verbundenen Einschränkungen zu vermeiden, müssen Sie vor der Verwendung von **Aspose.Slides** eine Lizenz setzen. Eine Lizenz muss nur einmal pro Anwendung oder Prozess gesetzt werden.

## **Lizenz anwenden**

Eine Lizenz kann aus einer **Datei** oder einem **Stream** geladen werden.

{{% alert color="primary" %}}
Aspose.Slides stellt die Klasse [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) für Lizenzvorgänge bereit.
{{% /alert %}} 

{{% alert color="warning" %}}
Neue Lizenzen können Aspose.Slides nur ab Version 21.4 aktivieren. Frühere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.
{{% /alert %}}

### **Datei**

Die einfachste Methode, eine Lizenz zu setzen, erfordert, dass Sie die Lizenzdatei in den Ordner legen, der Aspose.Slides.jar oder das Jar Ihrer Anwendung enthält.

Dieser Java‑Code zeigt, wie Sie eine Lizenzdatei setzen:
``` java
// Instanziert die Lizenzklasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Setzt den Pfad zur Lizenzdatei
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```


{{% alert color="warning" %}} 
Wenn Sie die Lizenzdatei in einem anderen Verzeichnis ablegen, muss beim Aufruf der Methode [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) der Lizenzdateiname am Ende des angegebenen expliziten Pfads exakt mit Ihrem Lizenzdateinamen übereinstimmen.

Beispielsweise können Sie den Lizenzdateinamen in *Aspose.Slides.Android.via.Java.lic.xml* ändern. Dann müssen Sie in Ihrem Code den Pfad zur Datei (endend mit *Aspose.Slides.Android.via.Java.lic.xml*) an die Methode [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) übergeben.
{{% /alert %}}

### **Stream**

Sie können eine Lizenz aus einem Stream laden. Dieser Java‑Code zeigt, wie Sie eine Lizenz aus einem Stream anwenden:
``` java
// Instanziert die Lizenzklasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Setzt die Lizenz über einen Stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```


## **Lizenz validieren**

Um zu prüfen, ob eine Lizenz korrekt gesetzt wurde, können Sie sie validieren. Dieser Java‑Code zeigt, wie Sie eine Lizenz validieren:
```java
License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```


## **Thread‑Sicherheit**

{{% alert title="Hinweis" color="warning" %}} 
Die Methode [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) ist nicht thread‑sicher. Wenn diese Methode gleichzeitig von vielen Threads aufgerufen werden muss, sollten Sie Synchronisations‑Primitiven (wie ein Lock) verwenden, um Probleme zu vermeiden. 
{{% /alert %}}

## **FAQ**

**Kann ich die Lizenz in einer komplett offline Umgebung (keine Internetverbindung) anwenden?**

Ja. Die Lizenzvalidierung erfolgt lokal anhand der Lizenzdatei; eine Internetverbindung ist nicht erforderlich.

**Was passiert, wenn das einjährige Abonnement abläuft? Hört die Bibliothek auf zu funktionieren?**

Nein. Die Lizenz ist unbefristet: Sie können weiterhin Versionen verwenden, die vor dem Ablaufdatum Ihres Abonnements veröffentlicht wurden; Sie sind jedoch nicht berechtigt, neuere Versionen ohne Verlängerung zu nutzen.