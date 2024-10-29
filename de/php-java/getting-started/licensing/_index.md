---
title: Lizenzierung
description: "Aspose.Slides für PHP über Java bietet verschiedene Kaufpläne oder bietet eine kostenlose Testversion und eine 30-tägige zeitlich befristete Lizenz zur Evaluierung unter Verwendung von Lizenzierungs- und Abonnementrichtlinien."
type: docs
weight: 80
url: /de/php-java/licensing/
---

Manchmal ist für die besten Evaluierungsergebnisse ein praktischer Ansatz erforderlich. Aus diesem Grund bietet Aspose.Slides verschiedene Kaufpläne an und bietet auch eine kostenlose Testversion und eine 30-tägige temporäre Lizenz zur Evaluierung.

{{% alert color="primary" %}}

Bitte beachten Sie, dass es einige allgemeine Richtlinien und Verfahren gibt, die Ihnen dabei helfen, unsere Produkte ordnungsgemäß zu evaluieren, zu lizenzieren und zu erwerben. Sie finden diese im Abschnitt ["Kaufrichtlinien und FAQ"](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Aspose.Slides evaluieren**
Sie können Aspose.Slides ganz einfach zur Evaluierung herunterladen. Das Evaluierungspaket ist das gleiche wie das gekaufte Paket. Die Evaluierungsversion wird einfach lizenziert, nachdem Sie einige Codezeilen hinzugefügt haben, um die Lizenz anzuwenden.

## **Einschränkung der Evaluierungsversion**
Die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) bietet die volle Produktfunktionalität, aber sie fügt beim Öffnen und Speichern ein Evaluierungs-Wasserzeichen am oberen Rand des Dokuments ein. Außerdem sind Sie beim Extrahieren von Texten aus Präsentationsfolien auf eine Folie beschränkt.

{{% alert color="primary" %}} 

Wenn Sie Aspose.Slides ohne die Einschränkungen der Evaluierungsversion testen möchten, können Sie eine **30-tägige temporäre Lizenz** anfordern. Bitte beachten Sie [Wie erhalte ich eine temporäre Lizenz?](https://purchase.aspose.com/temporary-license) für weitere Informationen.

{{% /alert %}} 

## **Über die Lizenz**
Sie können eine Evaluierungsversion von Aspose.Slides für PHP über Java ganz einfach von seiner [Download-Seite](https://packagist.org/packages/aspose/slides) herunterladen. Die Evaluierungsversion bietet absolut **die gleichen Möglichkeiten** wie die lizenzierte Version von Aspose.Slides. Darüber hinaus wird die Evaluierungsversion einfach lizenziert, nachdem Sie eine Lizenz erworben und ein paar Codezeilen hinzugefügt haben, um die Lizenz anzuwenden.

Die Lizenz ist eine XML-Datei im Klartext, die Details wie den Produktnamen, die Anzahl der Entwickler, für die sie lizenziert ist, das Ablaufdatum des Abonnements usw. enthält. Die Datei ist digital signiert; bitte ändern Sie die Datei nicht. Selbst die unbeabsichtigte Hinzufügung eines zusätzlichen Zeilenumbruchs zu den Inhalten der Datei macht sie ungültig.

Um die mit der Evaluierungsversion verbundenen Einschränkungen zu vermeiden, müssen Sie eine Lizenz festlegen, bevor Sie **Aspose.Slides** verwenden. Sie sind nur verpflichtet, einmal pro Anwendung oder Prozess eine Lizenz festzulegen.

## Gekaufte Lizenz

Nach dem Kauf müssen Sie die Lizenzdatei oder den Lizenzstream anwenden.

{{% alert color="primary" %}}

Sie müssen die Lizenz festlegen:
* nur einmal pro Anwendungsbereich
* bevor Sie andere Klassen von Aspose.Slides verwenden

{{% /alert %}}

{{% alert color="primary" %}}

Preisinformationen finden Sie auf der Seite [„Preisinformationen“](https://purchase.aspose.com/pricing/slides/family).

{{% /alert %}}

### **Festlegen einer Lizenz in Aspose.Slides für PHP über Java**

Lizenzen können aus diesen Orten angewendet werden:

* Expliziter Pfad
* Stream
* Als verbrauchsabhängige Lizenz – ein neues Lizenzierungsmodell

{{% alert color="primary" %}}

Verwenden Sie die Methode **setLicense**, um eine Komponente zu lizenzieren.

Obwohl mehrere Aufrufe von **setLicense** nicht schädlich sind, verschwenden sie Ressourcen (Prozessor).

{{% /alert %}}

#### **Anwenden einer Lizenz aus einer Datei**

Dieser Codeausschnitt wird verwendet, um eine Lizenzdatei festzulegen:

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

Beim Aufruf der setLicense-Methode sollte der Lizenzname mit dem Namen Ihrer Lizenzdatei übereinstimmen. Zum Beispiel können Sie den Namen der Lizenzdatei in "Aspose.Slides.lic.xml" ändern. Dann müssen Sie in Ihrem Code den neuen Lizenznamen (Aspose.Slides.lic.xml) an die setLicense-Methode übergeben.

#### **Anwenden einer Lizenz aus einem Stream**

Dieser Codeausschnitt wird verwendet, um eine Lizenz aus einem Stream anzuwenden:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```

#### Anwenden der verbrauchsabhängigen Lizenz

Aspose.Slides ermöglicht Entwicklern die Verwendung eines verbrauchsabhängigen Schlüssels. Dies ist ein neues Lizenzierungsmodell.

Das neue Lizenzierungsmodell wird zusammen mit der bestehenden Lizenzierungsmethode verwendet. Die Kunden, die basierend auf der Nutzung von API-Funktionen abgerechnet werden möchten, können die verbrauchsabhängige Lizenzierung verwenden.

Nachdem Sie alle notwendigen Schritte zur Erlangung dieses Lizenztyps abgeschlossen haben, erhalten Sie die Schlüssel, nicht die Lizenzdatei. Dieser verbrauchsabhängige Schlüssel kann mithilfe der speziell zu diesem Zweck eingeführten **Metered**-Klasse angewendet werden.

Das folgende Codebeispiel zeigt, wie man die verbrauchsabhängigen öffentlichen und privaten Schlüssel festlegt:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Metered;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

# Erstellen Sie eine Instanz der CAD Metered-Klasse
$metered = new Metered();

# Greifen Sie auf die set_metered_key-Eigenschaft zu und übergeben Sie öffentliche und private Schlüssel als Parameter
$metered->setMeteredKey("*****", "*****");

# Holen Sie sich die verbrauchsabhängige Datenmenge, bevor Sie die API aufrufen
$amountbefore = Metered::getConsumptionQuantity();
# Informationen anzeigen
echo "<script>console.log('Verbrauchte Menge Vorher: " . java_values($amountbefore) . "' );</script>";

# Dokument von der Festplatte laden.
$pres = new Presentation();
# Anzahl der Seiten des Dokuments abrufen
echo "<script>console.log('Verbrauchte Menge Nachher: " . java_values($pres->getSlides()->size()) . "' );</script>";
# als PDF speichern
$pres->save("out_pdf.pdf", SaveFormat::Pdf);

# Holen Sie sich die verbrauchsabhängige Datenmenge nach dem Aufruf der API
$amountafter = Metered::getConsumptionQuantity();
# Informationen anzeigen
echo "<script>console.log('Verbrauchte Menge Nachher: " . java_values($amountafter) . "' );</script>";
?>
```

{{% alert color="primary" %}}

Bitte beachten Sie, dass Sie eine stabile Internetverbindung benötigen, um die verbrauchsabhängige Lizenz korrekt zu verwenden, da der verbrauchsabhängige Mechanismus die ständige Interaktion mit unseren Diensten für genaue Berechnungen erfordert. Weitere Details finden Sie im Abschnitt [„FAQ zur verbrauchsabhängigen Lizenzierung“](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}