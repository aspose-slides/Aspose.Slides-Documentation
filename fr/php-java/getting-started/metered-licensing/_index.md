---
title: Licence à compteur
type: docs
weight: 100
url: /fr/php-java/metered-licensing/
---

{{% alert color="primary" %}} 

La licence à compteur est un nouveau mécanisme de licence qui peut être utilisé parallèlement aux méthodes de licence existantes. Si vous souhaitez être facturé en fonction de votre utilisation des fonctionnalités de l'API Aspose.Slides, vous choisissez la licence à compteur.

Lorsque vous achetez une licence à compteur, vous obtenez des clés (et non un fichier de licence). Cette clé à compteur peut être appliquée en utilisant la classe [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) fournie par Aspose pour les opérations de comptage. Pour plus de détails, consultez la [FAQ sur la licence à compteur](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 
1. Créez une instance de la classe [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/).

1. Passez vos clés publique et privée à la méthode [setMeteredKey](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) .

1. Effectuez un traitement (réalisez des tâches).

1. Appelez la méthode [getConsumptionQuantity](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#getConsumptionQuantity--) de la classe Metered.

   Vous devriez voir le montant/la quantité des demandes d'API que vous avez consommées jusqu'à présent.

Ce code PHP vous montre comment définir les clés publiques et privées à compteur :

```php
  $metered = new Metered();
  try {
    // Accède à la propriété setMeteredKey et passe les clés publique et privée comme paramètres
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");
    // Obtient la valeur de quantité consommée avant d'accéder à l'API
    $quantityOld = Metered->getConsumptionQuantity();
    echo("Quantité consommée" . $quantityOld);
    // Obtient la valeur de quantité consommée après avoir accédé à l'API
    $quantity = Metered->getConsumptionQuantity();
    echo("Quantité consommée" . $quantity);
  } catch (JavaException $ex) {
    $ex->printStackTrace();
  }
```

{{% alert color="warning" title="REMARQUE"  %}} 

Pour utiliser la licence à compteur, vous avez besoin d'une connexion Internet stable car le mécanisme de licence utilise Internet pour interagir en permanence avec nos services et effectuer des calculs.

{{% /alert %}} 