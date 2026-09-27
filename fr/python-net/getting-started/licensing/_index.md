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
description: "Apprenez comment appliquer, gérer et dépanner les licences dans Aspose.Slides for Python via .NET. Assurez un accès ininterrompu à toutes les fonctionnalités grâce à notre guide de licence étape par étape."
---
## **Vue d'ensemble**

Aspose.Slides peut être utilisé en mode d'évaluation ou avec une licence valide. La version d'évaluation offre les mêmes fonctionnalités que la version sous licence, mais elle ajoute un filigrane d'évaluation à chaque diapositive de chaque présentation qu'elle enregistre et tronque le texte que votre code lit à partir des présentations.

## **Évaluer Aspose.Slides**

Vous pouvez télécharger une version d'évaluation de **Aspose.Slides for Python via .NET** depuis sa [page de téléchargement](https://pypi.org/project/Aspose.Slides/). La version d'évaluation fournit les mêmes fonctionnalités que le produit sous licence. Le paquet d'évaluation est identique au paquet acheté et devient sous licence après que vous ayez ajouté quelques lignes de code pour appliquer la licence.

Lorsque vous êtes satisfait de votre évaluation d'**Aspose.Slides**, vous pouvez [acheter une licence](https://purchase.aspose.com/pricing/slides/python-net/). Nous vous recommandons de consulter les options d'abonnement disponibles. Si vous avez des questions, contactez l'équipe commerciale d'Aspose.

Chaque licence Aspose comprend un abonnement d'un an avec des mises à jour gratuites vers les nouvelles versions et les correctifs publiés pendant cette période. Les utilisateurs sous licence et en évaluation bénéficient d'un support technique gratuit et illimité.

**Limitations de la version d'évaluation**

* La version d'évaluation (lorsqu'aucune licence n'est appliquée) offre toutes les fonctionnalités, mais elle ajoute une zone de texte de filigrane d'évaluation à chaque diapositive de chaque présentation qu'elle enregistre.
* Le texte que votre code lit à partir d'une présentation est tronqué aux premiers caractères, suivi d'un avis sur la limitation d'évaluation. Le texte que votre code écrit est enregistré en entier.

{{% alert color="info" title="Note" %}}
Pour tester Aspose.Slides sans limitations, vous pouvez demander une **licence temporaire de 30 jours**. Consultez la page [Comment obtenir une licence temporaire](https://purchase.aspose.com/temporary-license) pour plus de détails.
{{% /alert %}}

## **Licences dans Aspose.Slides**

* Une version d'évaluation devient sous licence après que vous ayez acheté une licence et ajouté quelques lignes de code pour l'appliquer.
* La licence est un fichier XML en texte brut qui contient des détails tels que le nom du produit, le nombre de développeurs couverts, la date d'expiration de l'abonnement, etc.
* Le fichier de licence est signé numériquement, vous ne devez donc pas le modifier. Même l'ajout d'un seul retour à la ligne l'invalidera.
* Aspose.Slides for Python via .NET recherche la licence au chemin que vous lui transmettez. Un chemin relatif, ou un nom de fichier sans chemin, est résolu par rapport au répertoire de travail actuel, qui n'est pas nécessairement le dossier contenant votre script Python.
* Pour éviter les limitations d'évaluation, définissez la licence avant d'utiliser Aspose.Slides. Vous n'avez besoin de le faire qu'une seule fois par application ou processus.

{{% alert color="info" title="Note" %}}
Vous pouvez également consulter [Licences à la consommation](/slides/fr/python-net/metered-licensing/).
{{% /alert %}}

## **Appliquer une licence**

Une licence peut être chargée à partir d'un **fichier** ou d'un **flux**.

{{% alert color="info" title="Note" %}}
Aspose.Slides fournit la classe [License](https://reference.aspose.com/slides/python-net/aspose.slides/license/) pour gérer les licences.
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Les nouvelles licences peuvent activer Aspose.Slides uniquement avec la version 21.4 ou ultérieure. Les versions antérieures utilisent un système de licence différent et ne reconnaîtront pas ces licences.
{{% /alert %}}

### **Fichier**

La façon la plus simple de définir une licence consiste à passer le chemin du fichier de licence à la méthode [set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/). Si vous ne transmettez que le nom du fichier, comme dans l'exemple ci‑dessous, Aspose.Slides recherche le fichier dans le répertoire de travail actuel.

Le code Python suivant montre comment définir le fichier de licence :

```py
import aspose.slides as slides

# Instancie la classe License.
license = slides.License()

# Définit le chemin du fichier de licence.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" title="Warning" %}}
Si vous placez le fichier de licence dans un répertoire différent, lorsque vous appelez [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str), le nom de fichier à la fin du chemin explicite doit correspondre au nom de votre fichier de licence.

Par exemple, vous pouvez renommer le fichier de licence en *Aspose.Slides.lic.xml*. Ensuite, dans votre code, transmettez le chemin complet vers ce fichier (se terminant par Aspose.Slides.lic.xml) à la méthode [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str).
{{% /alert %}}

### **Flux**

Vous pouvez charger une licence à partir d'un flux. L'exemple Python suivant montre comment appliquer une licence depuis un flux :

```py
import aspose.slides as slides

# Instancie la classe License.
license = slides.License()

# Définit la licence depuis un flux.
with open("Aspose.Slides.lic", "rb") as stream:
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

{{% alert color="warning" title="Warning" %}}
La méthode [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/) n'est pas sûre pour les threads. Si vous devez l'appeler simultanément depuis plusieurs threads, utilisez un primitive de synchronisation, tel que `threading.Lock`, pour éviter les problèmes.
{{% /alert %}}

## **FAQ**

### Puis‑je appliquer la licence dans un environnement totalement hors ligne (sans accès Internet) ?

Oui. La validation de la licence s'effectue localement à l'aide du fichier de licence ; aucune connexion Internet n'est requise.

### Que se passe‑t‑il après l'expiration de l'abonnement d'un an ? La bibliothèque cesse‑t‑elle de fonctionner ?

Non. La licence est perpétuelle : vous pouvez continuer à utiliser les versions publiées avant la date de fin de votre abonnement ; vous ne pourrez simplement pas accéder aux nouvelles versions sans renouveler.