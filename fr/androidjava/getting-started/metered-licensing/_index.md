---
title: Licence à l'utilisation
type: docs
weight: 100
url: /androidjava/metered-licensing/
---

{{% alert color="primary" %}} 

Aspose.Slides permet aux développeurs d'appliquer une clé à l'utilisation. C'est un nouveau mécanisme de licence. Le nouveau mécanisme de licence sera utilisé en parallèle avec les méthodes de licence existantes. Les clients, qui préfèrent être facturés en fonction de leur utilisation des fonctionnalités de l'API, peuvent utiliser la licence à l'utilisation. Pour plus de détails, veuillez vous référer à la section [FAQ sur la licence à l'utilisation](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 
## **Licence à l'utilisation**
Suivez ces simples étapes pour utiliser la classe Metered :

1. Créez une instance de la classe Metered.

1. Passez les clés publique et privée à la méthode setMeteredKey.

1. Effectuez le traitement (réalisez la tâche).

1. Appelez la méthode getConsumptionQuantity de la classe Metered.

   Cela retournera le montant/la quantité de requêtes API que vous avez consommées jusqu'à présent.

Ce code d'exemple vous montre comment définir des clés publique et privée à l'utilisation :

```java
com.aspose.slides.Metered metered=new com.aspose.slides.Metered();
try {
    // Accédez à la propriété setMeteredKey et passez les clés publique et privée en paramètres
    metered.setMeteredKey("<valid pablic key>", "<valid private key>");

    // Obtenez la valeur de consommation avant d'accéder à l'API
    double quantityOld = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Quantité consommée" + quantityOld);


    // Obtenez la valeur de consommation après avoir accédé à l'API
    double quantity = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Quantité consommée" + quantity);


} catch (Exception ex) {
    ex.printStackTrace();
}
```