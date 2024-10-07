---
title: Metered Lizenzierung
type: docs
weight: 100
url: /androidjava/metered-licensing/
---

{{% alert color="primary" %}} 

Aspose.Slides ermöglicht Entwicklern, einen metered Schlüssel anzuwenden. Es handelt sich um einen neuen Lizenzierungsmechanismus. Der neue Lizenzierungsmechanismus wird neben den bestehenden Lizenzmethoden verwendet. Kunden, die auf Grundlage ihrer Nutzung von API-Funktionen abgerechnet werden möchten, können die metered Lizenzierung verwenden. Für weitere Informationen siehe den Abschnitt [Metered Lizenzierung FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 
## **Metered Lizenzierung**
Befolgen Sie diese einfachen Schritte, um die Metered-Klasse zu verwenden:

1. Erstellen Sie eine Instanz der Metered-Klasse.

1. Übergeben Sie die öffentlichen und privaten Schlüssel an die setMeteredKey-Methode.

1. Führen Sie die Verarbeitung durch (erledigen Sie die Aufgabe).

1. Rufen Sie die Methode getConsumptionQuantity der Metered-Klasse auf.

   Sie gibt die Menge der API-Anfragen zurück, die Sie bisher konsumiert haben.

Dieser Beispielcode zeigt Ihnen, wie Sie die metered öffentlichen und privaten Schlüssel setzen:

```java
com.aspose.slides.Metered metered=new com.aspose.slides.Metered();
try {
    // Greifen Sie auf die setMeteredKey-Eigenschaft zu und übergeben Sie öffentliche und private Schlüssel als Parameter
    metered.setMeteredKey("<gültiger öffentlicher Schlüssel>", "<gültiger privater Schlüssel>");

    // Holen Sie sich den Wert der konsumierten Menge, bevor Sie auf die API zugreifen
    double quantityOld = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Konsumierte Menge" + quantityOld);


    // Holen Sie sich den Wert der konsumierten Menge, nachdem Sie auf die API zugegriffen haben
    double quantity = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Konsumierte Menge" + quantity);


} catch (Exception ex) {
    ex.printStackTrace();
}
```