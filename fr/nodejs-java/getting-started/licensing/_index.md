---
title: Gestion des licences
type: docs
weight: 80
url: /fr/nodejs-java/licensing/
keywords:
- licence
- licence temporaire
- définir licence
- utiliser licence
- valider licence
- fichier de licence
- version d'évaluation
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Appliquer, gérer et dépanner les licences dans Aspose.Slides pour Node.js. Assurez un accès ininterrompu à toutes les fonctionnalités grâce à notre guide de licence étape par étape."
---
## **Introduction**

Parfois, pour obtenir les meilleurs résultats d’évaluation, une approche pratique peut être nécessaire. Pour cette raison, Aspose.Slides propose différents plans d’achat et offre également un essai gratuit ainsi qu’une licence temporaire de 30 jours pour l’évaluation.

{{% alert color="info" title="Note" %}}

Notez qu’il existe un certain nombre de politiques et de pratiques générales qui vous guident sur la façon d’évaluer, de licencier correctement et d’acheter nos produits. Vous les trouverez dans la section ["Politiques d'achat et FAQ"](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Évaluer Aspose.Slides**
Vous pouvez facilement télécharger Aspose.Slides pour l’évaluation. Le package d’évaluation est identique au package acheté. La version d’évaluation devient simplement sous licence après que vous ayez ajouté quelques lignes de code pour appliquer la licence.

## **Limitation de la version d’évaluation**
La version d’évaluation d’Aspose.Slides (sans licence spécifiée) offre l’ensemble des fonctionnalités du produit, avec deux limitations :

* Elle ajoute une zone de texte de filigrane d’évaluation à chaque diapositive de chaque présentation qu’elle enregistre.
* Le texte de plus de cinq caractères que votre code lit à partir d’une présentation est tronqué aux cinq premiers caractères, suivi de `... text has been truncated due to evaluation version limitation.` Le texte de cinq caractères ou moins est renvoyé tel quel, et le texte que votre code écrit est enregistré en totalité.

{{% alert color="info" title="Note" %}}

Si vous souhaitez tester Aspose.Slides sans les limitations de la version d’évaluation, vous pouvez demander une **Licence Temporaire de 30 jours**. Veuillez consulter [Comment obtenir une licence temporaire ?](https://purchase.aspose.com/temporary-license) pour plus d’informations.

{{% /alert %}}

## **À propos de la licence**
Vous pouvez facilement télécharger une version d’évaluation d’Aspose.Slides pour Node.js via Java depuis sa [page de téléchargement](https://releases.aspose.com/slides/nodejs-java/). La version d’évaluation possède les mêmes fonctionnalités que la version sous licence, avec les limitations décrites ci‑above. De plus, la version d’évaluation devient simplement sous licence après que vous achetiez une licence et ajoutiez quelques lignes de code pour l’appliquer.

La licence est un fichier XML en texte clair qui contient des informations telles que le nom du produit, le nombre de développeurs autorisés, la date d’expiration de l’abonnement, etc. Le fichier est signé numériquement, ne le modifiez donc pas. Même l’ajout accidentel d’une ligne vide supplémentaire dans le contenu du fichier l’invalidera.

Pour éviter les limitations associées à la version d’évaluation, vous devez définir une licence avant d’utiliser **Aspose.Slides**. Vous n’avez besoin de définir la licence qu’une seule fois par application ou processus.

{{% alert color="info" title="Note" %}}

Vous voudrez peut‑être consulter [Metered Licensing](/slides/fr/nodejs-java/metered-licensing/).

{{% /alert %}}

## **Licence achetée**

Après l’achat, vous devez appliquer le fichier ou le flux de licence.

{{% alert color="info" title="Note" %}}

Vous devez définir la licence :
* une seule fois par processus
* avant d’utiliser toute autre classe Aspose.Slides

{{% /alert %}}

{{% alert color="info" title="Note" %}}

Vous pouvez trouver les informations de tarification sur la page ["Informations sur les tarifs"](https://purchase.aspose.com/pricing/slides/family).

{{% /alert %}}

### **Définir une licence dans Aspose.Slides pour Node.js via Java**

Les licences peuvent être appliquées depuis ces emplacements :

* Chemin explicite
* Flux
* En tant que licence mesurée – un nouveau mécanisme de licence

{{% alert color="info" title="Note" %}}

Utilisez la méthode **setLicense** pour licencier un composant.

Bien que plusieurs appels à **setLicense** ne soient pas nuisibles, ils représentent un gaspillage de ressources (processeur).

{{% /alert %}}

#### **Appliquer une licence à l’aide d’un fichier**

Ce fragment de code sert à définir un fichier de licence :

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");

const license = new asposeSlides.License();
license.setLicense("Aspose.Slides.lic");
console.log("The license was applied.");

// Aspose.Slides s'exécute dans une machine virtuelle Java qui maintient Node.js en cours d'exécution, donc terminez le processus explicitement.
process.exit(0);
```

Lors de l’appel de la méthode setLicense, le nom de la licence doit être identique à celui de votre fichier de licence. Par exemple, vous pouvez renommer le fichier de licence en « Aspose.Slides.lic.xml ». Ensuite, dans votre code, vous devez passer ce nouveau nom de licence (Aspose.Slides.lic.xml) à la méthode setLicense. Si le fichier est absent ou ne contient pas une licence valide, [setLicense](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/setlicense/) lève une exception, ce qui termine le script avec une erreur.

#### **Appliquer une licence à partir d’un flux**

Pour appliquer une licence à partir d’un flux, transmettez l’objet [License](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/) et un flux lisible à la méthode statique [setLicenseFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/setlicense/). Le flux est lu de façon asynchrone, et le rappel reçoit une erreur si le flux ne contient pas une licence valide :

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");

const license = new asposeSlides.License();
const readStream = fs.createReadStream("Aspose.Slides.lic");
asposeSlides.License.setLicenseFromStream(license, readStream, function (error) {
    if (error) {
        console.error("The license was not applied:", error.message);
    } else {
        console.log("The license was applied.");
    }

    // Aspose.Slides s'exécute dans une machine virtuelle Java qui maintient Node.js en cours d'exécution, donc terminez le processus explicitement.
    process.exit(0);
});
```

La licence est appliquée lorsque le flux complet a été lu, juste avant l’exécution du rappel, vous pouvez donc démarrer d’autres travaux Aspose.Slides depuis le rappel.

Les deux exemples appellent `process.exit(0)` à la fin, car la machine virtuelle Java qui exécute Aspose.Slides maintient Node.js en cours d’exécution. Dans une application, poursuivez votre code Aspose.Slides au lieu de terminer le processus.

## **FAQ**

### Puis‑je appliquer la licence dans un environnement complètement hors ligne (sans accès Internet) ?

Oui. La validation de la licence s’effectue localement à l’aide du fichier de licence ; aucune connexion Internet n’est requise.

### Que se passe‑t‑il après l’expiration de l’abonnement d’un an ? La bibliothèque cesse‑t‑elle de fonctionner ?

Non. La licence est permanente : vous pouvez continuer à utiliser les versions publiées avant la date de fin de votre abonnement ; vous ne serez simplement pas éligible aux nouvelles versions sans renouvellement.