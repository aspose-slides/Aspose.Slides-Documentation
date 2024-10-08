---
title: Licence à la consommation
type: docs
weight: 90
url: /fr/net/metered-licensing/
---

{{% alert color="primary" %}} 

La licence à la consommation est un nouveau mécanisme de licence qui peut être utilisé en complément des méthodes de licence existantes. Si vous souhaitez être facturé en fonction de votre utilisation des fonctionnalités de l'API Aspose.Slides, vous choisissez la licence à la consommation.

Lorsque vous achetez une licence à la consommation, vous obtenez des clés (et non un fichier de licence). Cette clé à la consommation peut être appliquée à l'aide de la classe [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) qu'Aspose a fournie pour les opérations de mesure. Pour plus de détails, consultez la [FAQ sur la Licence à la Consommation](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Créez une instance de la classe [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/).
1. Passez vos clés publique et privée à la méthode [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/).
1. Effectuez quelques traitements (réalisez des tâches).
1. Appelez la méthode [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) de la classe Metered.

   Vous devriez voir la quantité de requêtes API que vous avez consommées jusqu'à présent.

Ce code C# vous montre comment définir les clés publique et privée à la consommation :

```c#
//  Crée une instance de la classe Metered
	Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

//  Accède à la propriété SetMeteredKey et passe les clés publique et privée en paramètres
	metered.SetMeteredKey("*****", "*****");

//  Obtient la quantité de données à la consommation avant l'appel de l'API
	decimal amountbefore = Aspose.Slides.Metered.GetConsumptionQuantity();

//  Affiche l'information
	Console.WriteLine("Montant consommé avant : " + amountbefore.ToString());

//  Obtient la quantité de données à la consommation après l'appel de l'API
	decimal amountafter = Aspose.Slides.Metered.GetConsumptionQuantity();

//  Affiche l'information
	Console.WriteLine("Montant consommé après : " + amountafter.ToString());
```

{{% alert color="warning" title="NOTE"  %}} 

Pour utiliser la licence à la consommation, vous avez besoin d'une connexion Internet stable car le mécanisme de licence utilise Internet pour interagir constamment avec nos services et effectuer des calculs.

{{% /alert %}} 