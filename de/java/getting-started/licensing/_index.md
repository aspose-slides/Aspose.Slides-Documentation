---
title: Lizenzierung
type: docs
weight: 90
url: /java/licensing/
---

## **Beurteilen Sie Aspose.Slides**

{{% alert color="primary" %}} 

Sie können eine Evaluierungsversion von **Aspose.Slides für Java** von seiner [Download-Seite](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Die Evaluierungsversion bietet dieselben Funktionen wie die lizenzierte Version des Produkts. Das Evaluierungspaket ist dasselbe wie das gekaufte Paket. Die Evaluierungsversion wird einfach lizenziert, nachdem Sie ein paar Zeilen Code hinzugefügt haben (um die Lizenz anzuwenden).

Sobald Sie mit Ihrer Evaluierung von **Aspose.Slides** zufrieden sind, können Sie eine [Lizenz erwerben](https://purchase.aspose.com/buy). Wir empfehlen Ihnen, die verschiedenen Abonnementtypen durchzugehen. Wenn Sie Fragen haben, kontaktieren Sie das Vertriebsteam von Aspose.

Jede Aspose-Lizenz enthält ein einjähriges Abonnement für kostenlose Upgrades auf neue Versionen oder Fehlerbehebungen, die im Abonnementzeitraum veröffentlicht werden. Benutzer mit lizenzierten Produkten (oder sogar Evaluierungsversionen) erhalten kostenlosen und unbegrenzten technischen Support.

{{% /alert %}} 

**Einschränkungen der Evaluierungsversion**

* Während die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) die vollständige Produktfunktionalität bietet, wird ein Evaluierungswasserzeichen beim Öffnen und Speichern von Dokumenten oben eingefügt. 
* Beim Extrahieren von Texten aus Präsentationsfolien sind Sie auf eine Folie beschränkt.

{{% alert color="primary" %}} 

Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30-Tage-Testlizenz** anfordern. Weitere Informationen finden Sie auf der Seite [So erhalten Sie eine Testlizenz](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Lizenzierung in Aspose.Slides**

* Eine Evaluierungsversion wird lizenziert, nachdem Sie eine Lizenz erworben und ein paar Zeilen Code hinzugefügt haben (um die Lizenz anzuwenden).
* Die Lizenz ist eine einfache XML-Datei, die Details wie den Produktnamen, die Anzahl der lizenzierten Entwickler, das Ablaufdatum des Abonnements usw. enthält. 
* Die Lizenzdatei ist digital signiert, daher dürfen Sie die Datei nicht ändern. Selbst eine unbeabsichtigte Hinzufügung eines zusätzlichen Zeilenumbruchs zum Inhalt der Datei würde sie ungültig machen.
* Aspose.Slides für Java versucht typischerweise, die Lizenz an folgenden Orten zu finden:
  * Ein expliziter Pfad
  * Der Ordner, der Aspose.Slides.jar enthält
* Um die mit der Evaluierungsversion verbundenen Einschränkungen zu vermeiden, müssen Sie eine Lizenz festlegen, bevor Sie **Aspose.Slides** verwenden. Sie müssen nur einmal pro Anwendung oder Prozess eine Lizenz festlegen.

{{% alert color="primary" %}} 

Sie möchten vielleicht [Metered Licensing](/slides/java/metered-licensing/) sehen.

{{% /alert %}} 


## **Anwenden einer Lizenz**

Eine Lizenz kann aus einer **Datei** oder einem **Stream** geladen werden.

{{% alert color="primary" %}}

Aspose.Slides bietet die [License](https://reference.aspose.com/slides/java/com.aspose.slides/License) Klasse für Lizenzoperationen.

{{% /alert %}} 

### **Datei**

Die einfachste Methode zur Festlegung einer Lizenz erfordert, dass Sie die Lizenzdatei in den Ordner mit Aspose.Slides.jar oder das Jar Ihrer Anwendungen legen.

Dieser Java-Code zeigt Ihnen, wie Sie eine Lizenzdatei festlegen:

``` java
// Instanziiert die License-Klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Legt den Lizenzdateipfad fest
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Wenn Sie die Lizenzdatei in einem anderen Verzeichnis platzieren, muss der Lizenzdateiname am Ende des angegebenen expliziten Pfades derselbe wie Ihre Lizenzdatei sein, wenn Sie die [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.lang.String-) Methode aufrufen.

Zum Beispiel können Sie den Lizenzdateinamen in *Aspose.Slides.Java.lic.xml* ändern. Dann müssen Sie in Ihrem Code den Pfad zur Datei (der mit *Aspose.Slides.Java.lic.xml* endet) an die [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.lang.String-) Methode übergeben.

{{% /alert %}}

### **Stream**

Sie können eine Lizenz aus einem Stream laden. Dieser Java-Code zeigt Ihnen, wie Sie eine Lizenz aus einem Stream anwenden:

``` java
// Instanziiert die License-Klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Legt die Lizenz über einen Stream fest
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Wenn Sie Aspose.Slides für PHP über Java verwenden, können Sie eine Lizenz über eine PHP/Java-Brücke festlegen. Diese Brücke ermöglicht es Ihnen, Java-Klassen in PHP-Syntax zu verwenden. Weitere Informationen finden Sie unter [Lizenz in PHP](/slides/php-java/licensing/).

## **Validierung einer Lizenz**

Um zu überprüfen, ob eine Lizenz korrekt festgelegt wurde, können Sie sie validieren. Dieser Java-Code zeigt Ihnen, wie Sie eine Lizenz validieren:

```java
License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("Lizenz ist gültig!");
}
```

## **Thread-Sicherheit**

{{% alert title="Hinweis" color="warning" %}} 

Die [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.io.InputStream-) Methode ist nicht thread-sicher. Wenn diese Methode gleichzeitig von vielen Threads aufgerufen werden muss, sollten Sie Synchronisationsprimitive (wie z.B. einen Lock) verwenden, um Probleme zu vermeiden. 

{{% /alert %}}