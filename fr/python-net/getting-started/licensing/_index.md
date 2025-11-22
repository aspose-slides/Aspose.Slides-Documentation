---
title: Licence
type: docs
weight: 80
url: /fr/python-net/licensing/
keywords:
- licence
- licence temporaire
- définir licence
- utiliser licence
- valider licence
- fichier de licence
- version d'évaluation
- Python
- Aspose.Slides
description: "Apprenez comment appliquer, gérer et dépanner les licences dans Aspose.Slides for Python via .NET. Assurez un accès ininterrompu à toutes les fonctionnalités grâce à notre guide étape par étape sur la gestion des licences."
---

## **Évaluer Aspose.Slides**

Vous pouvez télécharger une version d'évaluation de **Aspose.Slides for Python via .NET** depuis sa [page de téléchargement](https://pypi.org/project/Aspose.Slides/). La version d'évaluation offre les mêmes fonctionnalités que le produit sous licence. Le package d'évaluation est identique au package acheté et devient sous licence après que vous ayez ajouté quelques lignes de code pour appliquer la licence.

Lorsque vous êtes satisfait de votre évaluation d'**Aspose.Slides**, vous pouvez [acheter une licence](https://purchase.aspose.com/buy). Nous vous recommandons de consulter les options d'abonnement disponibles. Si vous avez des questions, contactez l'équipe commerciale d'Aspose.

Chaque licence Aspose comprend un abonnement d'un an avec des mises à jour gratuites vers les nouvelles versions et les correctifs publiés pendant cette période. Les utilisateurs sous licence et en version d'évaluation bénéficient d'un support technique gratuit et illimité.

**Limitations de la version d'évaluation**

* Bien que la version d'évaluation d'Aspose.Slides (sans licence appliquée) offre toutes les fonctionnalités, elle ajoute un filigrane d'évaluation en haut du document chaque fois que vous l'ouvrez ou l'enregistrez.
* Lors de l'extraction de texte d'une présentation, vous êtes limité à une diapositive.

{{% alert color="primary" %}}
Pour tester Aspose.Slides sans limitations, vous pouvez demander une **licence temporaire de 30 jours**. Consultez la page [Comment obtenir une licence temporaire](https://purchase.aspose.com/temporary-license) pour plus de détails.
{{% /alert %}}

## **Licence dans Aspose.Slides**

* Une version d'évaluation devient sous licence après l'achat d'une licence et l'ajout de quelques lignes de code pour l'appliquer.
* La licence est un fichier XML en texte clair qui contient des détails tels que le nom du produit, le nombre de développeurs qu'elle couvre, la date d'expiration de l'abonnement, etc.
* Le fichier de licence est signé numériquement, vous ne devez donc pas le modifier. Même l'ajout d'un simple saut de ligne l'invalidera.
* Aspose.Slides for Python via .NET recherche généralement la licence aux emplacements suivants :
  * Un chemin explicite que vous fournissez
  * Le dossier contenant le script Python qui appelle Aspose.Slides for Python via .NET
* Pour éviter les limitations d'évaluation, définissez la licence avant d'utiliser Aspose.Slides. Vous n'avez besoin de le faire qu'une fois par application ou processus.

{{% alert color="primary" %}}
Vous pouvez également consulter [Licence au compteur](/slides/fr/python-net/metered-licensing/).
{{% /alert %}}

## **Appliquer une licence**

Une licence peut être chargée depuis un **fichier**, un **flux** ou une **ressource incorporée**.

{{% alert color="primary" %}}
Aspose.Slides fournit la classe [License](https://reference.aspose.com/slides/python-net/aspose.slides/license/) pour gérer la licence.
{{% /alert %}}

{{% alert color="warning" %}}
Les nouvelles licences ne peuvent activer Aspose.Slides qu'avec la version 21.4 ou ultérieure. Les versions antérieures utilisent un système de licence différent et ne reconnaîtront pas ces licences.
{{% /alert %}}

### **Fichier**

La façon la plus simple de définir une licence consiste à placer le fichier de licence dans le même dossier que le DLL du composant et à spécifier uniquement le nom du fichier (sans chemin).

Le code Python suivant montre comment définir le fichier de licence :
```py
import aspose.slides as slides

# Instancie la classe License.
license = slides.License()

# Définit le chemin du fichier de licence.
license.set_license("Aspose.Slides.lic")
```


{{% alert color="warning" %}}
Si vous placez le fichier de licence dans un répertoire différent, lorsque vous appelez [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str), le nom du fichier à la fin du chemin explicite doit correspondre au nom de votre fichier de licence.

Par exemple, vous pouvez renommer le fichier de licence en *Aspose.Slides.lic.xml*. Ensuite, dans votre code, transmettez le chemin complet vers ce fichier (se terminant par Aspose.Slides.lic.xml) à la méthode [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str).
{{% /alert %}}

### **Flux**

Vous pouvez charger une licence depuis un flux. L'exemple Python suivant montre comment appliquer une licence depuis un flux :
```py
import aspose.slides as slides

# Instancie la classe License.
license = slides.License()

# Définit la licence à partir d'un flux.
license.set_license(stream)
```


## **Valider une licence**

Pour vérifier que la licence a été appliquée correctement, vous pouvez la valider. Le code Python suivant montre comment valider une licence :
```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```


## **Sécurité des threads**

{{% alert title="Note" color="warning" %}}
Les méthodes [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/) ne sont pas sûres pour les threads. Si elles doivent être appelées simultanément depuis plusieurs threads, utilisez des primitives de synchronisation (par ex., `threading.Lock`) pour éviter les problèmes.
{{% /alert %}}

## **FAQ**

**Puis-je appliquer la licence dans un environnement complètement hors ligne (sans accès Internet) ?**

Oui. La validation de la licence est effectuée localement à l'aide du fichier de licence ; aucune connexion Internet n'est requise.

**Que se passe-t-il après l'expiration de l'abonnement d'un an ? La bibliothèque cessera-t-elle de fonctionner ?**

Non. La licence est perpétuelle : vous pouvez continuer à utiliser les versions publiées avant la date de fin de votre abonnement ; vous ne pourrez simplement pas utiliser les nouvelles versions sans renouveler.