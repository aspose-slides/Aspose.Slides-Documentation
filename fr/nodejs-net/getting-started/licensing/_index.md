---
title: Licence
description: "Aspose.Slides pour Node.js via .NET propose différents plans d'achat ou offre un essai gratuit et une licence temporaire de 30 jours pour évaluation utilisant les politiques de Licence et d'Abonnement."
type: docs
weight: 80
url: /nodejs-net/licensing/
---

Parfois, pour obtenir les meilleurs résultats d'évaluation, une approche pratique peut être nécessaire. Pour cette raison, Aspose.Slides propose différents plans d'achat et offre également un essai gratuit ainsi qu'une licence temporaire de 30 jours pour évaluation.

{{% alert color="primary" %}}

Notez qu'il existe un certain nombre de politiques et de pratiques générales qui vous orientent sur la manière d'évaluer, de licencier correctement et d'acheter nos produits. Vous pouvez les trouver dans la section ["Politiques d'Achat et FAQ"](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Évaluer Aspose.Slides**
Vous pouvez facilement télécharger Aspose.Slides pour une évaluation. Le package d'évaluation est le même que le package acheté. La version d'évaluation devient simplement sous licence après que vous ayez ajouté quelques lignes de code pour appliquer la licence.

## **Limitation de la Version d'Évaluation**
La version d'évaluation d'Aspose.Slides (sans licence spécifiée) offre l'ensemble des fonctionnalités du produit, mais elle insère un filigrane d'évaluation en haut du document à l'ouverture et à l'enregistrement. Vous êtes également limité à une diapositive lors de l'extraction de textes à partir de diapositives de présentation.

{{% alert color="primary" %}} 

Si vous souhaitez tester Aspose.Slides sans les limitations de la version d'évaluation, vous pouvez demander une **Licence Temporaire de 30 Jours**. Veuillez consulter [Comment obtenir une Licence Temporaire ?](https://purchase.aspose.com/temporary-license) pour plus d'informations.

{{% /alert %}} 

## **À propos de la Licence**
Vous pouvez facilement télécharger une version d'évaluation d'Aspose.Slides pour Node.js via .NET depuis sa [page de téléchargement](https://releases.aspose.com/slides/nodejs-net/). La version d'évaluation offre absolument **les mêmes capacités** que la version sous licence d'Aspose.Slides. De plus, la version d'évaluation devient simplement sous licence après que vous ayez acheté une licence et ajouté quelques lignes de code pour appliquer la licence.

La licence est un fichier XML en texte brut qui contient des détails tels que le nom du produit, le nombre de développeurs pour lesquels elle est sous licence, la date d'expiration de l'abonnement, etc. Le fichier est numériquement signé, donc ne modifiez pas le fichier. Même l'ajout involontaire d'un saut de ligne supplémentaire dans le contenu du fichier l'invalidera.

Pour éviter les limitations associées à la version d'évaluation, vous devez définir une licence avant d'utiliser **Aspose.Slides**. Vous n'êtes tenu de définir une licence qu'une seule fois par application ou processus.

## Licence Achetiée

Après achat, vous devez appliquer le fichier ou le flux de licence. 

{{% alert color="primary" %}}

Vous devez définir la licence :
* une seule fois par domaine d'application
* avant d'utiliser d'autres classes Aspose.Slides

{{% /alert %}}

{{% alert color="primary" %}}

Vous pouvez trouver des informations sur les prix sur la page [“Informations sur les Prix”](https://purchase.aspose.com/pricing/slides/family).

{{% /alert %}}

### **Définir une Licence dans Aspose.Slides pour Node.js via .NET**

Les licences peuvent être appliquées depuis ces emplacements :

* Chemin explicite
* Flux
* En tant que Licence Mesurée – un nouveau mécanisme de licence

{{% alert color="primary" %}}

Utilisez la méthode **setLicense** pour licencier un composant.

Bien que plusieurs appels à **setLicense** ne soient pas nuisibles, ils sont une perte de ressources (processeur).

{{% /alert %}}

#### **Appliquer une Licence à l'aide d'un Fichier**

Ce extrait de code est utilisé pour définir un fichier de licence :

**Node.js**

```javascript
// Importer le module Aspose.Slides pour la manipulation de fichiers PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Cette fonction configure la bibliothèque Aspose.Slides avec une licence
function setupAsposeSlidesLicense() {

    // Initialiser la classe License du module Aspose.Slides
    var license = new asposeSlides.License();

    // Appliquer la licence depuis un fichier
    // Remplacez "votre_fichier_de_licence.lic" par le chemin de votre fichier de licence réel
    license.setLicense("votre_fichier_de_licence.lic");
}

// Exécuter la fonction pour configurer la licence pour Aspose.Slides
setupAsposeSlidesLicense();
```
{{% alert color="primary" %}}

Lors de l'appel de la méthode setLicense, le nom de la licence doit être le même que celui de votre fichier de licence. Par exemple, vous pouvez changer le nom du fichier de licence en "Aspose.Slides.lic.xml". Ensuite, dans votre code, vous devez passer le nouveau nom de licence (Aspose.Slides.lic.xml) à la méthode setLicense.

{{% /alert %}}