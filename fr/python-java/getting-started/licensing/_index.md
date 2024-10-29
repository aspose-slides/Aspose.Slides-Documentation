---
title: Licences
description: "Aspose.Slides pour Python via Java propose différents plans d'achat ou offre un essai gratuit et une licence temporaire de 30 jours pour l'évaluation en utilisant des politiques de licence et d'abonnement."
type: docs
weight: 80
url: /fr/python-java/licensing/
---

Parfois, pour obtenir les meilleurs résultats d'évaluation, une approche pratique peut être nécessaire. Pour cette raison, Aspose.Slides propose différents plans d'achat et offre également un essai gratuit ainsi qu'une licence temporaire de 30 jours pour l'évaluation.

{{% alert color="primary" %}}

Notez qu'il existe un certain nombre de politiques et de pratiques générales qui vous guident sur la manière d'évaluer, de licencier correctement et d'acheter nos produits. Vous pouvez les trouver dans la section ["Politiques d'Achat et FAQ"](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Évaluer Aspose.Slides**
Vous pouvez facilement télécharger Aspose.Slides pour évaluation. Le package d'évaluation est le même que le package acheté. La version d'évaluation devient simplement licenciée après que vous ayez ajouté quelques lignes de code pour appliquer la licence.

## **Limitation de la Version d'Évaluation**
La version d'évaluation d'Aspose.Slides (sans licence spécifiée) offre l'ensemble des fonctionnalités du produit, mais elle insère un filigrane d'évaluation en haut du document lors de l'ouverture et de l'enregistrement. Vous êtes également limité à une diapositive lorsque vous extrayez du texte des diapositives de présentation.

{{% alert color="primary" %}} 

Si vous souhaitez tester Aspose.Slides sans les limitations de la version d'évaluation, vous pouvez demander une **Licence Temporaire de 30 Jours**. Veuillez consulter [Comment obtenir une Licence Temporaire ?](https://purchase.aspose.com/temporary-license) pour plus d'informations.

{{% /alert %}} 

## **À Propos de la Licence**
Vous pouvez facilement télécharger une version d'évaluation d'Aspose.Slides pour Python via Java depuis sa [page de téléchargement](https://releases.aspose.com/slides/python-java/). La version d'évaluation offre absolument **les mêmes capacités** que la version licenciée d'Aspose.Slides. De plus, la version d'évaluation devient simplement licenciée après l'achat d'une licence et l'ajout de quelques lignes de code pour appliquer la licence.

La licence est un fichier XML en texte clair qui contient des détails tels que le nom du produit, le nombre de développeurs à qui elle est licenciée, la date d'expiration de l'abonnement, etc. Le fichier est numériquement signé, donc ne modifiez pas le fichier. Même une addition involontaire d'un saut de ligne supplémentaire dans le contenu du fichier l'invaliderez.

Pour éviter les limitations associées à la version d'évaluation, vous devez définir une licence avant d'utiliser **Aspose.Slides**. Vous n'êtes obligé de définir une licence qu'une seule fois par application ou processus.

## Licence Achat

Après l'achat, vous devez appliquer le fichier ou le flux de licence. 

{{% alert color="primary" %}}

Vous devez définir la licence :
* une seule fois par domaine d'application
* avant d'utiliser d'autres classes Aspose.Slides

{{% /alert %}}

{{% alert color="primary" %}}

Vous pouvez trouver des informations de tarification sur la page [“Informations de Tarification”](https://purchase.aspose.com/pricing/slides/family).

{{% /alert %}}

### **Définir une Licence dans Aspose.Slides pour Python via Java**

Les licences peuvent être appliquées depuis les emplacements suivants :

* Chemin explicite
* Flux
* En tant que Licence à Mesure – un nouveau mécanisme de licence

{{% alert color="primary" %}}

Utilisez la méthode **setLicense** pour licencier un composant.

Bien que plusieurs appels à **setLicense** ne soient pas nuisibles, ils sont une perte de ressources (processeur).

{{% /alert %}}

#### **Appliquer une Licence à Partir d'un Fichier**

Ce extrait de code est utilisé pour définir un fichier de licence :

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
pres = Presentation()
license.setLicense("Aspose.Slides.lic");

jpype.shutdownJVM()
```

Lors de l'appel à la méthode setLicense, le nom de la licence doit être le même que celui de votre fichier de licence. Par exemple, vous pouvez changer le nom du fichier de licence en "Aspose.Slides.lic.xml". Ensuite, dans votre code, vous devez passer le nouveau nom de licence (Aspose.Slides.lic.xml) à la méthode setLicense.

#### **Appliquer une Licence à Partir d'un Bytes**

Ce extrait de code est utilisé pour appliquer une licence à partir d'un bytes :

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
input = open("Aspose.Slides.lic", mode="rb")
data = input.read()
pres = Presentation()
license.setLicenseFromBytes(data);

jpype.shutdownJVM()
```

#### Appliquer la Licence à Mesure

Aspose.Slides permet aux développeurs d'appliquer une clé à mesurer. C'est un nouveau mécanisme de licence.

Le nouveau mécanisme de licence sera utilisé avec la méthode de licence existante. Les clients qui souhaitent être facturés en fonction de l'utilisation des fonctionnalités de l'API peuvent utiliser la Licence à Mesure.

Après avoir complété toutes les étapes nécessaires pour obtenir ce type de licence, vous recevrez les clés, et non le fichier de licence. Cette clé à mesurer peut être appliquée en utilisant la classe **Metered** spécialement introduite à cet effet.

L'exemple de code suivant montre comment définir les clés publiques et privées à mesurer :

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, Metered, SaveFormat

# Créer une instance de la classe Metered
metered = Metered();

# Accéder à la propriété set_metered_key et passer les clés publiques et privées en paramètres
metered.setMeteredKey("*****", "*****");

# Obtenir la quantité de données mesurées avant d'appeler l'API
amountbefore = Metered.getConsumptionQuantity()

# Afficher les informations
print("Montant Consommé Avant: \" + amountbefore + \"" )

# Charger le document depuis le disque.
pres = Presentation();

# Obtenir le nombre de pages du document
print("Montant Consommé Après: \" +  pres.getSlides().size()) + \"" )

# enregistrer en PDF
pres.save("out_pdf.pdf", SaveFormat.Pdf);

# Obtenir la quantité de données mesurées après l'appel de l'API
amountafter = Metered.getConsumptionQuantity()

# Afficher les informations
print("Montant Consommé Après: \" + amountafter + \"" )

jpype.shutdownJVM()
```

{{% alert color="primary" %}}

Veuillez noter que vous devez disposer d'une connexion Internet stable pour le bon usage de la licence à mesure, car le mécanisme à mesure nécessite une interaction constante avec nos services pour des calculs corrects. Pour plus de détails, consultez la section [“FAQ sur les Licences à Mesure”](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}