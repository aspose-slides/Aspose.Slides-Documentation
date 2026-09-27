---
title: Licences
type: docs
weight: 80
url: /fr/php-java/licensing/
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
- PHP
- Aspose.Slides
description: "Appliquer, gérer et dépanner les licences dans Aspose.Slides pour PHP via Java. Assurez un accès ininterrompu à toutes les fonctionnalités grâce à notre guide de licence étape par étape."
---
## **Introduction**

Parfois, pour obtenir les meilleurs résultats d'évaluation, une approche pratique peut être nécessaire. Pour cette raison, Aspose.Slides propose différents plans d'achat et offre également un essai gratuit ainsi qu'une licence temporaire de 30 jours pour l'évaluation.

{{% alert color="info" title="Note" %}}
Notez qu'il existe un certain nombre de politiques et pratiques générales qui vous guident sur la façon d'évaluer, de licencier correctement et d'acheter nos produits. Vous pouvez les trouver dans la section ["Politiques d'achat et FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Évaluer Aspose.Slides**
Vous pouvez facilement télécharger Aspose.Slides pour l'évaluation. Le package d'évaluation est identique au package acheté. La version d'évaluation devient simplement sous licence après que vous ayez ajouté quelques lignes de code pour appliquer la licence. 

## **Limitation de la version d'évaluation**
La version d'évaluation d'Aspose.Slides (sans licence spécifiée) fournit l'intégralité des fonctionnalités du produit, avec deux limitations :

* Elle ajoute une zone de texte de filigrane d'évaluation au centre de chaque diapositive de chaque présentation qu'elle enregistre.
* Le texte que votre code lit depuis une présentation est tronqué aux premiers caractères, suivi d'un avis sur la limitation d'évaluation. Le texte que votre code écrit est enregistré en entier.

{{% alert color="info" title="Note" %}}
Si vous souhaitez tester Aspose.Slides sans les limitations de la version d'évaluation, vous pouvez demander une **Licence temporaire de 30 jours**. Veuillez consulter [Comment obtenir une licence temporaire ?](https://purchase.aspose.com/temporary-license) pour plus d'informations.
{{% /alert %}} 

## **À propos de la licence**
Vous pouvez facilement télécharger une version d'évaluation d'Aspose.Slides pour PHP via Java depuis sa [page de téléchargement](https://packagist.org/packages/aspose/slides). La version d'évaluation offre absolument **les mêmes capacités** que la version sous licence d'Aspose.Slides. De plus, la version d'évaluation devient simplement sous licence après que vous ayez acheté une licence et ajouté quelques lignes de code pour l'appliquer.

La licence est un fichier XML en texte brut qui contient des détails tels que le nom du produit, le nombre de développeurs auxquels elle est accordée, la date d'expiration de l'abonnement, etc. Le fichier est signé numériquement, il ne faut donc pas le modifier. Même l'ajout accidentel d'un retour à la ligne supplémentaire dans le contenu du fichier l'invalidera.

Pour éviter les limitations associées à la version d'évaluation, vous devez définir une licence avant d'utiliser **Aspose.Slides**. Vous n'êtes tenu de définir une licence qu'une seule fois par application ou processus.

{{% alert color="info" title="Note" %}}
Vous pouvez consulter [Licensement à la consommation](/slides/fr/php-java/metered-licensing/).
{{% /alert %}} 

## **Licence achetée**

Après l'achat, vous devez appliquer le fichier ou le flux de licence. 

{{% alert color="info" title="Note" %}}
Vous devez définir la licence :
* une seule fois par domaine d'application
* avant d'utiliser toute autre classe Aspose.Slides
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Vous pouvez trouver les informations de tarification sur la page [« Informations tarifaires »](https://purchase.aspose.com/pricing/slides/fr/family).
{{% /alert %}}

### **Définir une licence dans Aspose.Slides pour PHP via Java**

Les licences peuvent être appliquées depuis les emplacements suivants :

* Chemin explicite
* Flux
* En tant que licence à la consommation – un nouveau mécanisme de licence

{{% alert color="info" title="Note" %}}
Utilisez la méthode **setLicense** pour licencier un composant.

Bien que plusieurs appels à **setLicense** ne soient pas nocifs, ils gaspillent des ressources (processeur).
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Les nouvelles licences peuvent activer Aspose.Slides uniquement avec la version 21.4 ou ultérieure. Les versions antérieures utilisent un système de licence différent et ne reconnaîtront pas ces licences.
{{% /alert %}}

#### **Appliquer une licence à l'aide d'un fichier**

Cet extrait de code est utilisé pour définir un fichier de licence :

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/fr/lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense(__DIR__ . "/Aspose.Slides.lic");
```

L'exemple suppose que le fichier de licence se trouve à côté du script et transmet son chemin absolu : Aspose.Slides s'exécute sous Tomcat, il ne résout donc pas un chemin relatif par rapport au dossier de votre script. Lors de l'appel de la méthode setLicense, le nom de la licence doit être identique à celui de votre fichier de licence. Par exemple, vous pouvez renommer le fichier de licence en "Aspose.Slides.lic.xml". Ensuite, dans votre code, vous devez transmettre le nouveau nom de licence (Aspose.Slides.lic.xml) à la méthode setLicense.

#### **Appliquer une licence depuis un flux**

Cet extrait de code est utilisé pour appliquer une licence depuis un flux :

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/fr/lib/aspose.slides.php");

use aspose\slides\License;

$stream = new Java("java.io.FileInputStream", __DIR__ . "/Aspose.Slides.lic");

$license = new License();
$license->setLicense($stream);

$stream->close();
```

## **FAQ**

### Puis-je appliquer la licence dans un environnement totalement hors ligne (sans accès à Internet) ?
Oui. La validation de la licence est effectuée localement à l'aide du fichier de licence ; aucune connexion Internet n'est requise.

### Que se passe-t-il après l'expiration de l'abonnement d'un an ? La bibliothèque cessera-t-elle de fonctionner ?
Non. La licence est perpétuelle : vous pouvez continuer à utiliser les versions publiées avant la date de fin de votre abonnement ; vous ne serez simplement pas éligible à utiliser les nouvelles versions sans renouvellement.