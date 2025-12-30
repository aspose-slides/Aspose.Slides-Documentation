---
title: Lizenzierung
type: docs
weight: 80
url: /de/php-java/licensing/
keywords:
- Lizenz
- Temporäre Lizenz
- Lizenz festlegen
- Lizenz verwenden
- Lizenz validieren
- Lizenzdatei
- Evaluierungsversion
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Lizenzierung anwenden, verwalten und Fehler beheben in Aspose.Slides für PHP via Java. Gewährleisten Sie ununterbrochenen Zugriff auf alle Funktionen mit unserer Schritt-für-Schritt-Lizenzierungsanleitung."
---

Manchmal ist für die besten Evaluierungsergebnisse ein praktischer Ansatz erforderlich. Aus diesem Grund bietet Aspose.Slides verschiedene Kaufpläne sowie eine kostenlose Testversion und eine 30‑tägige temporäre Lizenz zur Evaluierung an.

{{% alert color="primary" %}}
Beachten Sie, dass es eine Reihe von allgemeinen Richtlinien und Praktiken gibt, die Sie bei der Evaluierung, korrekten Lizenzierung und dem Kauf unserer Produkte unterstützen. Sie finden diese im Abschnitt [Kaufrichtlinien und FAQ](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Aspose.Slides evaluieren**
Sie können Aspose.Slides ganz einfach zum Evaluieren herunterladen. Das Evaluierungspaket ist identisch mit dem erworbenen Paket. Die Evaluierungsversion wird einfach lizenziert, sobald Sie einige Codezeilen hinzufügen, um die Lizenz anzuwenden. 

## **Einschränkungen der Evaluierungsversion**
Die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) bietet die vollständige Produktfunktionalität, fügt jedoch beim Öffnen und Speichern ein Evaluierungs‑Wasserzeichen oben im Dokument ein. Zudem sind Sie beim Extrahieren von Texten aus Präsentationsfolien auf eine Folie beschränkt.

{{% alert color="primary" %}} 
Wenn Sie Aspose.Slides ohne die Einschränkungen der Evaluierungsversion testen möchten, können Sie eine **30‑tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie unter [Wie erhält man eine temporäre Lizenz?](https://purchase.aspose.com/temporary-license).
{{% /alert %}} 

## **Über die Lizenz**
Sie können ganz einfach eine Evaluierungsversion von Aspose.Slides für PHP via Java von seiner [Download‑Seite](https://packagist.org/packages/aspose/slides) herunterladen. Die Evaluierungsversion bietet absolut **die gleichen Funktionen** wie die lizenzierte Version von Aspose.Slides. Außerdem wird die Evaluierungsversion einfach lizenziert, sobald Sie eine Lizenz erwerben und ein paar Codezeilen hinzufügen, um die Lizenz anzuwenden.

Die Lizenz ist eine reine Text‑XML‑Datei, die Details wie den Produktnamen, die Anzahl der lizenzierten Entwickler, das Ablaufdatum des Abonnements usw. enthält. Die Datei ist digital signiert, daher dürfen Sie sie nicht ändern. Selbst das versehentliche Hinzufügen eines zusätzlichen Zeilenumbruchs zum Dateiinhalte macht die Lizenz ungültig.

Um die mit der Evaluierungsversion verbundenen Einschränkungen zu vermeiden, müssen Sie vor der Verwendung von **Aspose.Slides** eine Lizenz festlegen. Sie müssen die Lizenz nur einmal pro Anwendung oder Prozess setzen.

{{% alert color="primary" %}} 
Vielleicht möchten Sie sich [Metered Licensing](https://docs.aspose.com/slides/php-java/metered-licensing/) ansehen.
{{% /alert %}} 

## **Gekaufte Lizenz**

Nach dem Kauf müssen Sie die Lizenzdatei oder den Stream anwenden. 

{{% alert color="primary" %}}
Sie müssen die Lizenz setzen:
* nur einmal pro Anwendungsdomäne
* bevor Sie andere Aspose.Slides‑Klassen verwenden
{{% /alert %}}

{{% alert color="primary" %}}
Preisangaben finden Sie auf der Seite [„Preisangaben“](https://purchase.aspose.com/pricing/slides/family).
{{% /alert %}}

### **Lizenz festlegen in Aspose.Slides für PHP via Java**

Lizenzen können aus folgenden Quellen angewendet werden:

* Expliziter Pfad
* Datenstrom
* Als Metered License – ein neuer Lizenzierungsmechanismus

{{% alert color="primary" %}}
Verwenden Sie die **setLicense**‑Methode, um eine Komponente zu lizenzieren.

Obwohl mehrere Aufrufe von **setLicense** nicht schädlich sind, verschwenden sie Ressourcen (Prozessor).
{{% /alert %}}

{{% alert color="warning" %}}
Neue Lizenzen können Aspose.Slides nur mit Version 21.4 oder höher aktivieren. Ältere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.
{{% /alert %}}

#### **Lizenz mit einer Datei anwenden**

Dieses Codeschnipsel wird verwendet, um eine Lizenzdatei zu setzen:

**PHP**
```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense("Aspose.Slides.lic");
?>
```


Beim Aufruf der setLicense‑Methode sollte der Lizenzname derselbe sein wie der Ihrer Lizenzdatei. Zum Beispiel können Sie den Dateinamen der Lizenz in „Aspose.Slides.lic.xml“ ändern. Dann müssen Sie in Ihrem Code den neuen Lizenznamen (Aspose.Slides.lic.xml) an die setLicense‑Methode übergeben.

#### **Lizenz aus einem Stream anwenden**

Dieses Codeschnipsel wird verwendet, um eine Lizenz aus einem Stream anzuwenden:
```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```


## **FAQ**

**Kann ich die Lizenz in einer vollständig offline‑Umgebung (keine Internetverbindung) anwenden?**  
Ja. Die Lizenzvalidierung erfolgt lokal mittels der Lizenzdatei; eine Internetverbindung ist nicht erforderlich.

**Was passiert, wenn das einjährige Abonnement endet? Hört die Bibliothek auf zu funktionieren?**  
Nein. Die Lizenz ist unbefristet: Sie können weiterhin Versionen verwenden, die vor dem Ende Ihres Abonnements veröffentlicht wurden; Sie können jedoch neuere Versionen nur nach einer Verlängerung nutzen.