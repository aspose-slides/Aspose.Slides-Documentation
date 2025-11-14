---
title: Licence
description: "Aspose.Slides pour Node.js via Java propose différents plans d'achat ou offre un essai gratuit et une licence temporaire de 30 jours pour évaluation en utilisant les politiques de licence et d'abonnement."
type: docs
weight: 80
url: /fr/nodejs-java/licensing/
---

Parfois, pour obtenir les meilleurs résultats d'évaluation, une approche pratique peut être nécessaire. Pour cette raison, Aspose.Slides propose différents plans d'achat et offre également un essai gratuit et une licence temporaire de 30 jours pour évaluation.

{{% alert color="primary" %}}

Veuillez noter qu'il existe un certain nombre de politiques et de pratiques générales qui vous guident sur la façon d'évaluer, de licencier correctement et d'acheter nos produits. Vous pouvez les trouver dans la section ["Politiques d'achat et FAQ"](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Évaluer Aspose.Slides**
Vous pouvez facilement télécharger Aspose.Slides pour évaluation. Le package d'évaluation est le même que le package acheté. La version d'évaluation devient simplement licenciée après que vous ayez ajouté quelques lignes de code pour appliquer la licence.

## **Limitation de la version d'évaluation**
La version d'évaluation d'Aspose.Slides (sans licence spécifiée) offre l'intégralité des fonctionnalités du produit, mais elle insère un filigrane d'évaluation en haut du document lors de l'ouverture et de l'enregistrement. Vous êtes également limité à une diapositive lors de l'extraction de textes des diapositives de présentation.

{{% alert color="primary" %}} 

Si vous souhaitez tester Aspose.Slides sans les limitations de la version d'évaluation, vous pouvez demander une **licence temporaire de 30 jours**. Veuillez consulter [Comment obtenir une licence temporaire ?](https://purchase.aspose.com/temporary-license) pour plus d'informations.

{{% /alert %}} 

## **À propos de la Licence**
Vous pouvez facilement télécharger une version d'évaluation d'Aspose.Slides pour Node.js via Java depuis sa [page de téléchargement](https://releases.aspose.com/slides/nodejs-java/). La version d'évaluation offre absolument **les mêmes capacités** que la version licenciée d'Aspose.Slides. De plus, la version d'évaluation devient simplement licenciée après que vous ayez acheté une licence et ajouté quelques lignes de code pour appliquer la licence.

La licence est un fichier XML en texte brut qui contient des détails tels que le nom du produit, le nombre de développeurs à qui elle est licenciée, la date d'expiration de l'abonnement, et ainsi de suite. Le fichier est signé numériquement, donc ne modifiez pas le fichier. Même l'ajout involontaire d'un retour à la ligne supplémentaire dans le contenu du fichier l'invalidera.

Pour éviter les limitations associées à la version d'évaluation, vous devez définir une licence avant d'utiliser **Aspose.Slides**. Vous n'êtes tenu de définir une licence qu'une seule fois par application ou processus.

## Licence achetée

Après achat, vous devez appliquer le fichier ou le flux de la licence.

{{% alert color="primary" %}}

Vous devez définir la licence :
* seulement une fois par domaine d'application
* avant d'utiliser d'autres classes Aspose.Slides

{{% /alert %}}

{{% alert color="primary" %}}

Vous pouvez trouver des informations sur les prix sur la page [“Informations sur les prix”](https://purchase.aspose.com/pricing/slides/family).

{{% /alert %}}

### **Définir une licence dans Aspose.Slides pour Node.js via Java**

Les licences peuvent être appliquées à partir de ces emplacements :

* Chemin explicite
* Flux
* En tant que licence à facturation à l'usage – un nouveau mécanisme de licence

{{% alert color="primary" %}}

Utilisez la méthode **setLicense** pour licencier un composant.

Bien que plusieurs appels à **setLicense** ne soient pas nuisibles, ils sont une perte de ressources (processeur).

{{% /alert %}}

#### **Appliquer une licence à l'aide d'un fichier**

Ce snippet de code est utilisé pour définir un fichier de licence :

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```

Lors de l'appel de la méthode setLicense, le nom de la licence doit être le même que celui de votre fichier de licence. Par exemple, vous pouvez changer le nom du fichier de licence en "Aspose.Slides.lic.xml". Ensuite, dans votre code, vous devez passer le nouveau nom de la licence (Aspose.Slides.lic.xml) à la méthode setLicense.

#### **Appliquer une licence à partir d'un flux**

Ce snippet de code est utilisé pour appliquer une licence à partir d'un flux :

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();

var fs = require("fs");

var readStream = fs.createReadStream("Aspose.Slides.lic");

license.setLicense(readStream, function(err, list) {
    if(err) { 
        console.error(err); return; 
    }});
```

#### Appliquer une licence à facturation à l'usage

Aspose.Slides permet aux développeurs d'appliquer une clé à facturation à l'usage. Il s'agit d'un nouveau mécanisme de licence.

Le nouveau mécanisme de licence sera utilisé en plus de la méthode de licence existante. Les clients qui souhaitent être facturés en fonction de l'utilisation des fonctionnalités de l'API peuvent utiliser la licence à facturation à l'usage.

Après avoir complété toutes les étapes nécessaires pour obtenir ce type de licence, vous recevrez les clés, et non le fichier de licence. Cette clé à facturation à l'usage peut être appliquée à l'aide de la classe **Metered** spécialement introduite à cet effet.

L'exemple de code suivant montre comment définir des clés publiques et privées à facturation à l'usage :

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

# Créer une instance de la classe Metered CAD
var metered = new aspose.slides.Metered();

# Accéder à la propriété set_metered_key et passer les clés publique et privée en paramètres
metered.setMeteredKey("*****", "*****");

# Obtenir la quantité de données à facturer avant d'appeler l'API
var amountbefore = aspose.slides.Metered.getConsumptionQuantity();
# Afficher les informations
console.log('Montant consommé avant : " + amountbefore + "' );

# Charger le document depuis le disque.
var pres = new aspose.slides.Presentation();
# Obtenir le nombre de pages du document
console.log('Montant consommé après : " +  pres.getSlides().size()) + "' );
# sauvegarder en PDF
pres.save("out_pdf.pdf", aspose.slides.SaveFormat.Pdf);

# Obtenir la quantité de données à facturer après l'appel de l'API
var amountafter = aspose.slides.Metered.getConsumptionQuantity();
# Afficher les informations
console.log('Montant consommé après : " + amountafter + "' );
```

{{% alert color="primary" %}}

Veuillez noter que vous devez avoir une connexion Internet stable pour l'utilisation correcte de la licence à facturation à l'usage, car le mécanisme à facturation à l'usage nécessite une interaction constante avec nos services pour des calculs corrects. Pour plus de détails, consultez la section [“FAQ sur la licence à facturation à l'usage”](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}