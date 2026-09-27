---
title: Lizenzierung
type: docs
weight: 80
url: /de/php-java/licensing/
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
- PHP
- Aspose.Slides
description: "Anwenden, Verwalten und Fehlerbeheben von Lizenzen in Aspose.Slides für PHP via Java. Gewährleisten Sie einen ununterbrochenen Zugriff auf alle Funktionen mit unserem Schritt‑für‑Schritt‑Leitfaden zur Lizenzierung."
---
## **Einleitung**

Manchmal ist für optimale Evaluationsergebnisse ein praktischer Ansatz erforderlich. Aus diesem Grund bietet Aspose.Slides verschiedene Kaufpläne sowie eine kostenlose Testversion und eine 30‑tägige temporäre Lizenz zur Evaluierung an.

{{% alert color="info" title="Note" %}}
Beachten Sie, dass es eine Reihe von allgemeinen Richtlinien und Praktiken gibt, die Sie darüber informieren, wie Sie unsere Produkte evaluieren, ordnungsgemäß lizenzieren und kaufen. Sie finden sie im Abschnitt [Kaufrichtlinien und FAQ](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Aspose.Slides evaluieren**
Sie können Aspose.Slides ganz einfach zum Evaluieren herunterladen. Das Evaluierungspaket ist identisch mit dem gekauften Paket. Die Evaluierungsversion wird einfach lizenziert, sobald Sie ein paar Codezeilen hinzufügen, um die Lizenz anzuwenden.

## **Einschränkungen der Evaluierungsversion**
Die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) bietet die volle Produktfunktionalität, jedoch mit zwei Einschränkungen:

* Sie fügt jedem gespeicherten Folienpräsentation eine Wasserzeichen‑Textbox mit dem Hinweis „Evaluation“ in die Mitte jeder Folie ein.
* Text, den Ihr Code aus einer Präsentation liest, wird auf die ersten wenigen Zeichen gekürzt und mit einem Hinweis auf die Evaluierungsbeschränkung versehen. Text, den Ihr Code schreibt, wird vollständig gespeichert.

{{% alert color="info" title="Note" %}}
Wenn Sie Aspose.Slides ohne die Einschränkungen der Evaluierungsversion testen möchten, können Sie eine **30‑tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie unter [Wie erhalte ich eine temporäre Lizenz?](https://purchase.aspose.com/temporary-license).
{{% /alert %}} 

## **Über die Lizenz**
Sie können eine Evaluierungsversion von Aspose.Slides für PHP via Java ganz einfach von der [Download‑Seite](https://packagist.org/packages/aspose/slides) herunterladen. Die Evaluierungsversion bietet absolut **die gleichen Funktionen** wie die lizenzierte Version von Aspose.Slides. Darüber hinaus wird die Evaluierungsversion einfach lizenziert, sobald Sie eine Lizenz erwerben und ein paar Codezeilen hinzufügen, um die Lizenz anzuwenden.

Die Lizenz ist eine reine XML‑Textdatei, die Details wie Produktnamen, Anzahl der lizenzierten Entwickler, Ablaufdatum des Abonnements usw. enthält. Die Datei ist digital signiert, ändern Sie sie also nicht. Selbst das versehentliche Einfügen eines zusätzlichen Zeilenumbruchs macht die Lizenz ungültig.

Um die mit der Evaluierungsversion verbundenen Einschränkungen zu vermeiden, müssen Sie vor der Verwendung von **Aspose.Slides** eine Lizenz setzen. Dies ist pro Anwendung oder Prozess nur einmal erforderlich.

{{% alert color="info" title="Note" %}}
Vielleicht möchten Sie sich die [Nutzungsbasierte Lizenzierung](/slides/de/php-java/metered-licensing/) ansehen.
{{% /alert %}} 

## **Gekaufte Lizenz**

Nach dem Kauf müssen Sie die Lizenzdatei oder den Lizenz‑Stream anwenden.

{{% alert color="info" title="Note" %}}
Sie müssen die Lizenz setzen:
* nur einmal pro Anwendungsdomäne
* bevor Sie irgendeine andere Aspose.Slides‑Klasse verwenden
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Preisangaben finden Sie auf der Seite [Preisinformationen](https://purchase.aspose.com/pricing/slides/de/family).
{{% /alert %}}

### **Lizenz festlegen in Aspose.Slides für PHP via Java**

Lizenzen können von folgenden Stellen aus angewendet werden:

* Expliziter Pfad
* Stream
* Als nutzungsbasierte Lizenz – ein neuer Lizenzierungsmechanismus

{{% alert color="info" title="Note" %}}
Verwenden Sie die **setLicense**‑Methode, um eine Komponente zu lizenzieren.

Mehrere Aufrufe von **setLicense** sind zwar nicht schädlich, verschwenden jedoch Ressourcen (Prozessor).
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Neue Lizenzen können Aspose.Slides nur ab Version 21.4 aktivieren. Frühere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.
{{% /alert %}}

#### **Lizenz mit einer Datei anwenden**

Dieses Code‑Snippet wird verwendet, um eine Lizenzdatei zu setzen:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/de/lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense(__DIR__ . "/Aspose.Slides.lic");
```

Das Beispiel erwartet die Lizenzdatei neben dem Skript und übergibt deren absoluten Pfad: Aspose.Slides läuft innerhalb von Tomcat und löst keinen relativen Pfad relativ zu Ihrem Skriptordner auf. Beim Aufruf der setLicense‑Methode sollte der Lizenzname dem Namen Ihrer Lizenzdatei entsprechen. Beispielsweise können Sie den Lizenzdateinamen zu „Aspose.Slides.lic.xml“ ändern. Dann müssen Sie in Ihrem Code den neuen Lizenznamen (Aspose.Slides.lic.xml) an die setLicense‑Methode übergeben.

#### **Lizenz aus einem Stream anwenden**

Dieses Code‑Snippet wird verwendet, um eine Lizenz aus einem Stream anzuwenden:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/de/lib/aspose.slides.php");

use aspose\slides\License;

$stream = new Java("java.io.FileInputStream", __DIR__ . "/Aspose.Slides.lic");

$license = new License();
$license->setLicense($stream);

$stream->close();
```

## **FAQ**

### Kann ich die Lizenz in einer komplett offline Umgebung (keine Internetverbindung) anwenden?

Ja. Die Lizenzprüfung erfolgt lokal mithilfe der Lizenzdatei; eine Internetverbindung ist nicht erforderlich.

### Was passiert, wenn das einjährige Abonnement abläuft? Hört die Bibliothek auf zu funktionieren?

Nein. Die Lizenz ist unbefristet: Sie können weiterhin Versionen nutzen, die vor dem Ende Ihres Abonnements veröffentlicht wurden; Sie sind jedoch nicht berechtigt, neuere Versionen zu verwenden, ohne das Abonnement zu verlängern.