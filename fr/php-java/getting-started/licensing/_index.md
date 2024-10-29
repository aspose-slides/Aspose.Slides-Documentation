---
title: Licence
description: "Aspose.Slides pour PHP via Java propose différents plans d'achat ou offre un essai gratuit et une licence temporaire de 30 jours pour évaluation en utilisant des politiques de Licence et d'Abonnement."
type: docs
weight: 80
url: /fr/php-java/licensing/
---

Parfois, pour obtenir les meilleurs résultats d'évaluation, une approche pratique peut être nécessaire. Pour cette raison, Aspose.Slides propose différents plans d'achat et offre également un essai gratuit et une licence temporaire de 30 jours pour évaluation.

{{% alert color="primary" %}}

Notez qu'il existe un certain nombre de politiques et de pratiques générales qui vous guident sur la manière d'évaluer, de licencier correctement et d'acheter nos produits. Vous pouvez les trouver dans la section ["Politiques d'Achat et FAQ"](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Évaluer Aspose.Slides**
Vous pouvez facilement télécharger Aspose.Slides pour évaluation. Le package d'évaluation est le même que le package acheté. La version d'évaluation devient simplement licenciée après que vous ayez ajouté quelques lignes de code pour appliquer la licence.

## **Limitation de la Version d'Évaluation**
La version d'évaluation d'Aspose.Slides (sans licence spécifiée) offre la fonctionnalité complète du produit, mais insère un filigrane d'évaluation en haut du document lors de l'ouverture et de l'enregistrement. Vous êtes également limité à une diapositive lors de l'extraction de textes à partir des diapositives de présentation.

{{% alert color="primary" %}}

Si vous souhaitez tester Aspose.Slides sans les limitations de la version d'évaluation, vous pouvez demander une **Licence Temporaire de 30 Jours**. Veuillez vous référer à [Comment obtenir une Licence Temporaire ?](https://purchase.aspose.com/temporary-license) pour plus d'informations.

{{% /alert %}}

## **À propos de la Licence**
Vous pouvez facilement télécharger une version d'évaluation d'Aspose.Slides pour PHP via Java depuis sa [page de téléchargement](https://packagist.org/packages/aspose/slides). La version d'évaluation offre absolument **les mêmes capacités** que la version licenciée d'Aspose.Slides. De plus, la version d'évaluation devient simplement licenciée après que vous ayez acheté une licence et ajouté quelques lignes de code pour appliquer la licence.

La licence est un fichier XML en texte brut qui contient des détails tels que le nom du produit, le nombre de développeurs pour lesquels elle est licenciée, la date d'expiration de l'abonnement, etc. Le fichier est signé numériquement, donc ne modifiez pas le fichier. Même l'ajout involontaire d'un saut de ligne supplémentaire aux contenus du fichier l'invalidera.

Pour éviter les limitations associées à la version d'évaluation, vous devez définir une licence avant d'utiliser **Aspose.Slides**. Vous n'êtes tenu de définir une licence qu'une seule fois par application ou processus.

## Licence Achat

Après l'achat, vous devez appliquer le fichier de licence ou le flux.

{{% alert color="primary" %}}

Vous devez définir la licence :
* une seule fois par domaine d'application
* avant d'utiliser toute autre classe Aspose.Slides

{{% /alert %}}

{{% alert color="primary" %}}

Vous pouvez trouver des informations sur les prix sur la page [“Informations sur les Prix”](https://purchase.aspose.com/pricing/slides/family).

{{% /alert %}}

### **Définir une Licence dans Aspose.Slides pour PHP via Java**

Les licences peuvent être appliquées depuis ces emplacements :

* Chemin explicite
* Flux
* En tant que Licence à Facturation à l'Usage – un nouveau mécanisme de licence

{{% alert color="primary" %}}

Utilisez la méthode **setLicense** pour licencier un composant.

Bien que plusieurs appels à **setLicense** ne soient pas nuisibles, ils gaspillent des ressources (processeur).

{{% /alert %}}

#### **Appliquer une Licence à partir d'un Fichier**

Ce morceau de code est utilisé pour définir un fichier de licence :

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense("Aspose.Slides.lic");
?>
```

Lors de l'appel de la méthode setLicense, le nom de la licence doit être le même que celui de votre fichier de licence. Par exemple, vous pouvez changer le nom du fichier de licence en "Aspose.Slides.lic.xml". Ensuite, dans votre code, vous devez passer le nouveau nom de licence (Aspose.Slides.lic.xml) à la méthode setLicense.

#### **Appliquer une Licence à partir d'un Flux**

Ce morceau de code est utilisé pour appliquer une licence à partir d'un flux :

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```

#### Appliquer une Licence à Facturation à l'Usage

Aspose.Slides permet aux développeurs d'appliquer une clé à facturation à l'usage. C'est un nouveau mécanisme de licence.

Le nouveau mécanisme de licence sera utilisé avec la méthode de licence existante. Les clients qui souhaitent être facturés en fonction de l'utilisation des fonctionnalités de l'API peuvent utiliser la facturation à l'usage.

Après avoir complété toutes les étapes nécessaires pour obtenir ce type de licence, vous recevrez les clés, et non le fichier de licence. Cette clé à facturation à l'usage peut être appliquée à l'aide de la classe **Metered** spécialement introduite à cet effet.

L'exemple de code suivant montre comment définir les clés publiques et privées à facturation à l'usage :

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Metered;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

# Créer une instance de la classe Metered
$metered = new Metered();

# Accéder à la propriété set_metered_key et passer les clés publiques et privées comme paramètres
$metered->setMeteredKey("*****", "*****");

# Obtenir le montant de données à facturation à l'usage avant d'appeler l'API
$amountbefore = Metered::getConsumptionQuantity();
# Afficher des informations
echo "<script>console.log('Montant consommé avant : " . java_values($amountbefore) . "' );</script>";

# Charger le document depuis le disque.
$pres = new Presentation();
# Obtenir le nombre de pages du document
echo "<script>console.log('Montant consommé après : " . java_values($pres->getSlides()->size()) . "' );</script>";
# sauvegarder en tant que PDF
$pres->save("out_pdf.pdf", SaveFormat::Pdf);

# Obtenir le montant de données à facturation à l'usage après avoir appelé l'API
$amountafter = Metered::getConsumptionQuantity();
# Afficher des informations
echo "<script>console.log('Montant consommé après : " . java_values($amountafter) . "' );</script>";
?>
```

{{% alert color="primary" %}}

Veuillez noter que vous devez avoir une connexion Internet stable pour l'utilisation correcte de la licence à facturation à l'usage, car le mécanisme à facturation à l'usage nécessite une interaction constante avec nos services pour des calculs corrects. Pour plus de détails, consultez la section [“FAQ sur la Licence à Facturation à l'Usage”](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}