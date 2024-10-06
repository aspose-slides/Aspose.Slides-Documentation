---
title: Licences
description: "Aspose.Slides pour Python via .NET propose différents plans d'achat ou offre un essai gratuit et une licence temporaire de 30 jours pour l'évaluation utilisant les politiques de licences et d'abonnement."
type: docs
weight: 80
url: /python-net/licensing/
---

## **Évaluer Aspose.Slides**

{{% alert color="primary" %}} 

Vous pouvez télécharger une version d'évaluation de **Aspose.Slides pour Python via .NET** depuis sa [page de téléchargement](https://pypi.org/project/Aspose.Slides/). La version d'évaluation offre les mêmes fonctionnalités que la version sous licence du produit. Le package d'évaluation est identique au package acheté. La version d'évaluation devient simplement sous licence après que vous y ayez ajouté quelques lignes de code (pour appliquer la licence).

Une fois que vous êtes satisfait de votre évaluation de **Aspose.Slides**, vous pouvez [acheter une licence](https://purchase.aspose.com/buy). Nous vous recommandons de passer en revue les différents types d'abonnement. Si vous avez des questions, contactez l'équipe de vente d'Aspose.

Chaque licence Aspose est accompagnée d'un abonnement d'un an pour des mises à jour gratuites vers de nouvelles versions ou des corrections publiées pendant la période d'abonnement. Les utilisateurs avec des produits sous licence ou même des versions d'évaluation bénéficient d'un support technique gratuit et illimité.

{{% /alert %}} 

**Limitations de la version d'évaluation**

* Bien que la version d'évaluation d'Aspose.Slides (sans licence spécifiée) fournisse la fonctionnalité complète du produit, elle insère un filigrane d'évaluation en haut du document lors des opérations d'ouverture et d'enregistrement. 
* Vous êtes limité à une diapositive lors de l'extraction de textes à partir de diapositives de présentation.

{{% alert color="primary" %}} 

Pour tester Aspose.Slides sans limitations, vous pouvez demander une **licence temporaire de 30 jours**. Consultez la page [Comment obtenir une licence temporaire](https://purchase.aspose.com/temporary-license) pour plus d'informations.

{{% /alert %}}

## **Licences dans Aspose.Slides**

* Une version d'évaluation devient sous licence après que vous ayez acheté une licence et ajouté quelques lignes de code (pour appliquer la licence).
* La licence est un fichier XML en texte brut qui contient des détails tels que le nom du produit, le nombre de développeurs à qui elle est licenciée, la date d'expiration de l'abonnement, etc. 
* Le fichier de licence est signé numériquement, vous ne devez donc pas modifier le fichier. Même une addition inadvertante d'un saut de ligne supplémentaire dans le contenu du fichier l'invalidera.
* Aspose.Slides pour Python via .NET essaie généralement de trouver la licence dans ces emplacements :
  * Un chemin explicite
  * Le dossier contenant le script Python qui appelle Aspose.Slides pour Python via .NET
* Pour éviter les limitations associées à la version d'évaluation, vous devez définir une licence avant d'utiliser Aspose.Slides. Vous n'avez besoin de définir une licence qu'une seule fois par application ou processus.

{{% alert color="primary" %}} 

Vous pouvez consulter [Licences à la consommation](/slides/python-net/metered-licensing/).

{{% /alert %}} 

## **Appliquer une Licence**

Une licence peut être chargée à partir d'un **fichier**, **flux** ou **ressource intégrée**. 

{{% alert color="primary" %}}

Aspose.Slides fournit la classe [License](https://reference.aspose.com/slides/python-net/aspose.slides/license/) pour les opérations de licence.

{{% /alert %}} 

### **Fichier**

La méthode la plus simple pour définir une licence nécessite que vous placiez le fichier de licence dans le même dossier contenant le DLL du composant (inclus dans Aspose.Slides) et que vous spécifiiez le nom du fichier sans son chemin.

Ce code Python vous montre comment définir un fichier de licence :

``` python
import aspose.slides as slides

# Instancie la classe License 
license = slides.License()

# Définit le chemin du fichier de licence
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" %}} 

Si vous placez le fichier de licence dans un autre répertoire, lorsque vous appelez la méthode [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/), le nom du fichier de licence à la fin de l'explicit spécifié doit être le même que votre fichier de licence.

Par exemple, vous pouvez changer le nom du fichier de licence en *Aspose.Slides.lic.xml*. Ensuite, dans votre code, vous devez passer le chemin vers le fichier (se terminant par *Aspose.Slides.lic.xml*) à la méthode [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/).

{{% /alert %}}

### **Flux**

Vous pouvez charger une licence à partir d'un flux. Ce code Python vous montre comment appliquer une licence à partir d'un flux :

``` python
import aspose.slides as slides

# Instancie la classe License 
license = slides.License()

# Définit la licence via un flux
license.set_license(stream)
```

## **Valider une Licence**

Pour vérifier si une licence a été correctement définie, vous pouvez la valider. Ce code Python vous montre comment valider une licence :

```python
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("La licence est valide !")
```

## **Sécurité des Threads**

{{% alert title="Remarque" color="warning" %}} 

La méthode [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/) n'est pas sécurisée pour les threads. Si cette méthode doit être appelée simultanément à partir de plusieurs threads, vous voudrez peut-être utiliser des primitives de synchronisation (comme un verrou) pour éviter des problèmes. 

{{% /alert %}}