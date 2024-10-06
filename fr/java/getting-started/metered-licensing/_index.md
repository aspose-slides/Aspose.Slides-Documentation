---  
title: Licence Mesurée  
type: docs  
weight: 100  
url: /java/metered-licensing/  
---  

{{% alert color="primary" %}}  

La licence mesurée est un nouveau mécanisme de licence qui peut être utilisé en plus des méthodes de licence existantes. Si vous souhaitez être facturé en fonction de votre utilisation des fonctionnalités de l'API Aspose.Slides, vous choisissez la licence mesurée.  

Lorsque vous achetez une licence mesurée, vous obtenez des clés (et non un fichier de licence). Cette clé mesurée peut être appliquée en utilisant la classe [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) fournie par Aspose pour les opérations de mesure. Pour plus de détails, consultez la [FAQ sur la licence mesurée](https://purchase.aspose.com/faqs/licensing/metered).  

{{% /alert %}}  
1. Créez une instance de la classe [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/).  

1. Passez vos clés publique et privée à la méthode [setMeteredKey](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) .  

1. Effectuez des traitements (exécutez des tâches).  

1. Appelez la méthode [getConsumptionQuantity](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#getConsumptionQuantity--) de la classe Metered.  

   Vous devriez voir le montant/quantity des requêtes API que vous avez consommées jusqu'à présent.  

Ce code Java vous montre comment définir les clés publiques et privées mesurées :  

```java  
com.aspose.slides.Metered metered=new com.aspose.slides.Metered();  
try {  
    // Accède à la propriété setMeteredKey et passe les clés publique et privée en tant que paramètres  
    metered.setMeteredKey("<valid pablic key>", "<valid private key>");  

    // Obtient la valeur de la quantité consommée avant d'accéder à l'API  
    double quantityOld = com.aspose.slides.Metered.getConsumptionQuantity();  
    System.out.println("Quantité de consommation" + quantityOld);  

    // Obtient la valeur de la quantité consommée après avoir accédé à l'API  
    double quantity = com.aspose.slides.Metered.getConsumptionQuantity();  
    System.out.println("Quantité de consommation" + quantity);  
} catch (Exception ex) {  
    ex.printStackTrace();  
}  
```  

{{% alert color="warning" title="NOTE"  %}}  

Pour utiliser la licence mesurée, vous avez besoin d'une connexion Internet stable car le mécanisme de licence utilise Internet pour interagir en permanence avec nos services et effectuer des calculs.  

{{% /alert %}}  