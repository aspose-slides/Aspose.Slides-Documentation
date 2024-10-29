---
title: Abrechnungslizenzierung
type: docs
weight: 100
url: /de/php-java/metered-licensing/
---

{{% alert color="primary" %}} 

Die Abrechnungslizenzierung ist ein neuer Lizenzmechanismus, der zusammen mit bestehenden Lizenzmethoden verwendet werden kann. Wenn Sie basierend auf Ihrer Nutzung der Aspose.Slides API-Funktionen abgerechnet werden möchten, wählen Sie die Abrechnungslizenzierung.

Wenn Sie eine Abrechnungslizenz erwerben, erhalten Sie Schlüssel (und keine Lizenzdatei). Dieser Abrechnungsschlüssel kann mit der von Aspose bereitgestellten [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) Klasse für Abrechnungsoperationen angewendet werden. Für weitere Einzelheiten siehe [Abrechnungslizenzierung FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 
1. Erstellen Sie eine Instanz der [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) Klasse.

1. Übergeben Sie Ihre öffentlichen und privaten Schlüssel an die [setMeteredKey](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) Methode.

1. Führen Sie einige Verarbeitungen durch (erledigen Sie Aufgaben).

1. Rufen Sie die [getConsumptionQuantity](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#getConsumptionQuantity--) Methode der Metered-Klasse auf.

   Sie sollten die Menge/Anzahl der API-Anfragen sehen, die Sie bisher verbraucht haben.

Dieser PHP-Code zeigt Ihnen, wie Sie die öffentlichen und privaten Abrechnungsschlüssel festlegen:

```php
  $metered = new Metered();
  try {
    // Greift auf die setMeteredKey-Eigenschaft zu und übergibt öffentliche und private Schlüssel als Parameter
    $metered->setMeteredKey("<gültiger öffentlicher Schlüssel>", "<gültiger privater Schlüssel>");
    // Holt den Wert der verbrauchten Menge, bevor die API aufgerufen wird
    $quantityOld = Metered->getConsumptionQuantity();
    echo("Verbrauchte Menge" . $quantityOld);
    // Holt den Wert der verbrauchten Menge, nachdem die API aufgerufen wurde
    $quantity = Metered->getConsumptionQuantity();
    echo("Verbrauchte Menge" . $quantity);
  } catch (JavaException $ex) {
    $ex->printStackTrace();
  }
```

{{% alert color="warning" title="HINWEIS"  %}} 

Um die Abrechnungslizenzierung zu verwenden, benötigen Sie eine stabile Internetverbindung, da der Lizenzmechanismus das Internet nutzt, um ständig mit unseren Diensten zu interagieren und Berechnungen durchzuführen.

{{% /alert %}} 