---
title: Licence Mesurée
type: docs
weight: 90
url: /python-net/metered-licensing/
---

{{% alert color="primary" %}} 

La licence mesurée est un nouveau mécanisme de licence qui peut être utilisé en parallèle avec les méthodes de licence existantes. Si vous souhaitez être facturé en fonction de votre utilisation des fonctionnalités de l'API Aspose.Slides, vous choisissez la licence mesurée.

Lorsque vous achetez une licence mesurée, vous recevez des clés (et non un fichier de licence). Cette clé mesurée peut être appliquée à l'aide de la classe [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) fournie par Aspose pour les opérations de mesure. Pour plus de détails, consultez la [FAQ sur la Licence Mesurée](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Créez une instance de la classe [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).
1. Passez vos clés publiques et privées à la méthode `set_metered_key`.
1. Effectuez un traitement (réalisez des tâches).
1. Appelez la méthode `get_consumption_quantity()` de la classe Metered.

   Vous devriez voir le montant/quantité de requêtes API que vous avez consommées jusqu'à présent.

Ce code Python vous montre comment définir les clés publiques et privées mesurées :

```python
import aspose.slides as slides

# Crée une instance de la classe CAD Metered
metered = slides.Metered()

# Accède à la propriété set_metered_key et passe les clés publiques et privées en paramètres
metered.set_metered_key("*****", "*****")

# Obtient le montant de données mesurées avant d'appeler l'API
amountbefore = slides.metered.get_consumption_quantity()
# Affiche l'information
print("Montant Consommé Avant : " + str(amountbefore))

# Charge le document depuis le disque.
with slides.Presentation("Presentation.pptx") as pres:
   # Obtient le nombre de pages du document
   print(len(pres.slides))
   # Sauvegarde en PDF
   pres.save("out_pdf.pdf", slides.export.SaveFormat.PDF)

# Obtient le montant de données mesurées après avoir appelé l'API
amountafter = slides.metered.get_consumption_quantity()
# Affiche l'information
print("Montant Consommé Après : " + str(amountafter))
```

{{% alert color="warning" title="NOTE"  %}} 

Pour utiliser la licence mesurée, vous avez besoin d'une connexion Internet stable car le mécanisme de licence utilise Internet pour interagir constamment avec nos services et effectuer des calculs.

{{% /alert %}}