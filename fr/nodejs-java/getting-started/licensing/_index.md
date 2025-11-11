---
title: Licence
description: "Aspose.Slides pour Node.js via Java propose différents plans d'achat ou offre un essai gratuit et une licence temporaire de 30 jours pour l'évaluation selon les politiques de licence et d'abonnement."
type: docs
weight: 80
url: /fr/nodejs-java/licensing/
---

Parfois, pour obtenir les meilleurs résultats d'évaluation, une approche pratique peut être nécessaire. Pour cette raison, Aspose.Slides propose différents plans d'achat et offre également un essai gratuit et une licence temporaire de 30 jours pour l'évaluation.

{{% alert color="primary" %}}
Notez qu'il existe un certain nombre de politiques et de pratiques générales qui vous guident sur la manière d'évaluer, de licencier correctement et d'acheter nos produits. Vous pouvez les consulter dans la section ["Purchase Policies and FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Évaluer Aspose.Slides**
Vous pouvez facilement télécharger Aspose.Slides pour l'évaluation. Le package d'évaluation est identique au package acheté. La version d'évaluation devient simplement licenciée après que vous ayez ajouté quelques lignes de code pour appliquer la licence.

## **Limitation de la version d'évaluation**
La version d'évaluation d'Aspose.Slides (sans licence spécifiée) offre toutes les fonctionnalités du produit, mais elle insère un filigrane d'évaluation en haut du document à l'ouverture et à l'enregistrement. Vous êtes également limité à une diapositive lors de l'extraction de texte à partir des diapositives de la présentation.

{{% alert color="primary" %}} 
Si vous souhaitez tester Aspose.Slides sans les limitations de la version d'évaluation, vous pouvez demander une **licence temporaire de 30 jours**. Consultez [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) pour plus d'informations.
{{% /alert %}} 

## **À propos de la licence**
Vous pouvez facilement télécharger une version d'évaluation d'Aspose.Slides pour Node.js via Java depuis sa [page de téléchargement](https://releases.aspose.com/slides/nodejs-java/). La version d'évaluation fournit absolument **les mêmes capacités** que la version licenciée d'Aspose.Slides. De plus, la version d'évaluation devient simplement licenciée après que vous avez acheté une licence et ajouté quelques lignes de code pour l'appliquer.

La licence est un fichier XML en texte brut qui contient des détails tels que le nom du produit, le nombre de développeurs auxquels elle est accordée, la date d'expiration de l'abonnement, etc. Le fichier est signé numériquement, il ne faut donc pas le modifier. Même l'ajout accidentel d'un retour à la ligne supplémentaire dans le contenu du fichier le rendra invalide.

Pour éviter les limitations associées à la version d'évaluation, vous devez définir une licence avant d'utiliser **Aspose.Slides**. Vous n'êtes tenu de définir une licence qu'une seule fois par application ou processus.

{{% alert color="primary" %}} 
Vous pouvez consulter [Metered Licensing](https://docs.aspose.com/slides/nodejs-java/metered-licensing/).
{{% /alert %}} 

## **Licence achetée**

Après l'achat, vous devez appliquer le fichier ou le flux de licence. 

{{% alert color="primary" %}}
Vous devez définir la licence :
* une seule fois par domaine d'application
* avant d'utiliser toute autre classe Aspose.Slides
{{% /alert %}}

{{% alert color="primary" %}}
Vous trouverez les informations tarifaires sur la page [“Pricing Information”](https://purchase.aspose.com/pricing/slides/family).
{{% /alert %}}

### **Définir une licence dans Aspose.Slides pour Node.js via Java**

Les licences peuvent être appliquées depuis les emplacements suivants :

* Chemin explicite
* Flux
* En tant que licence métrée – un nouveau mécanisme de licence

{{% alert color="primary" %}}
Utilisez la méthode **setLicense** pour licencier un composant.

Bien que plusieurs appels à **setLicense** ne soient pas nocifs, ils constituent un gaspillage de ressources (processeur).
{{% /alert %}}

{{% alert color="warning" %}}
Les nouvelles licences peuvent activer Aspose.Slides uniquement à partir de la version 21.4 ou ultérieure. Les versions antérieures utilisent un système de licence différent et ne reconnaîtront pas ces licences.
{{% /alert %}}

#### **Appliquer une licence à l'aide d'un fichier**

Ce fragment de code sert à définir un fichier de licence :

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```

Lors de l'appel à la méthode setLicense, le nom de la licence doit être identique à celui de votre fichier de licence. Par exemple, vous pouvez renommer le fichier de licence en "Aspose.Slides.lic.xml". Ensuite, dans votre code, vous devez passer le nouveau nom de licence (Aspose.Slides.lic.xml) à la méthode setLicense.

#### **Appliquer une licence à partir d'un flux**

Ce fragment de code sert à appliquer une licence à partir d'un flux :

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

## **FAQ**

**Puis-je appliquer la licence dans un environnement totalement hors ligne (sans accès Internet) ?**

Oui. La validation de la licence s’effectue localement à l’aide du fichier de licence ; aucune connexion Internet n’est requise.

**Que se passe-t-il après l'expiration de l'abonnement d'un an ? La bibliothèque cessera-t-elle de fonctionner ?**

Non. La licence est perpétuelle : vous pouvez continuer à utiliser les versions publiées avant la date de fin de votre abonnement ; vous ne pourrez simplement pas bénéficier des nouvelles versions sans renouveler.