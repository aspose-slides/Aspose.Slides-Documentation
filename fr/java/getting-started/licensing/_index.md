---
title: Gestion des licences
type: docs
weight: 90
url: /fr/java/licensing/
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
- Java
- Aspose.Slides
description: "Appliquer, gérer et dépanner les licences dans Aspose.Slides pour Java. Garantir un accès ininterrompu à toutes les fonctionnalités grâce à notre guide étape par étape sur la gestion des licences."
---
## **Vue d'ensemble**

Aspose.Slides peut être utilisé en mode d'évaluation ou avec une licence valide. La version d'évaluation offre les mêmes fonctionnalités que la version sous licence, mais elle ajoute un filigrane d'évaluation à chaque diapositive de chaque présentation qu'elle enregistre et tronque le texte que votre code lit via l'API.

Cet article explique comment fonctionne la licence dans Aspose.Slides et comment appliquer une licence avant d'utiliser la bibliothèque. Une licence peut être chargée à partir d'un fichier, d'un flux ou d'une ressource incorporée en utilisant la classe `License`. L'article montre également comment valider si une licence a été appliquée correctement.

## **Évaluer Aspose.Slides**

{{% alert color="info" title="Note" %}}

Vous pouvez télécharger une version d'évaluation d'**Aspose.Slides for Java** depuis sa [page de téléchargement](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). La version d'évaluation fournit les mêmes fonctionnalités que la version sous licence du produit. Le package d'évaluation est identique au package acheté. La version d'évaluation devient simplement sous licence après avoir ajouté quelques lignes de code (pour appliquer la licence).

Une fois que vous êtes satisfait de votre évaluation d'**Aspose.Slides**, vous pouvez [acheter une licence](https://purchase.aspose.com/pricing/slides/java/). Nous vous recommandons de parcourir les différents types d'abonnement. Si vous avez des questions, contactez l'équipe commerciale d'Aspose.

Chaque licence Aspose comprend un abonnement d'un an pour des mises à jour gratuites vers de nouvelles versions ou des correctifs publiés pendant la période d'abonnement. Les utilisateurs de produits sous licence (ou même les versions d'évaluation) bénéficient d'un support technique gratuit et illimité.

{{% /alert %}} 

**Limitations de la version d'évaluation**

* La version d'évaluation (sans licence spécifiée) offre l'intégralité des fonctionnalités du produit, mais ajoute une zone de texte de filigrane d'évaluation à chaque diapositive de chaque présentation qu'elle enregistre.
* Le texte que votre code lit via l'API, y compris le texte qu'il vient de définir, est tronqué aux premiers caractères, suivi d'un avis concernant la limitation d'évaluation. Le texte que votre code écrit est enregistré en totalité.

{{% alert color="info" title="Note" %}}

Pour tester Aspose.Slides sans limitations, vous pouvez demander une **Licence Temporaire de 30 jours**. Consultez la page [Comment obtenir une Licence Temporaire](https://purchase.aspose.com/temporary-license) pour plus d'informations.

{{% /alert %}}

## **Licence dans Aspose.Slides**

* Une version d'évaluation devient sous licence après l'achat d'une licence et l'ajout de quelques lignes de code (pour appliquer la licence).
* La licence est un fichier XML en texte clair qui contient des détails tels que le nom du produit, le nombre de développeurs autorisés, la date d'expiration de l'abonnement, etc.
* Le fichier de licence est signé numériquement, vous ne devez donc pas le modifier. Même l'ajout accidentel d'un retour à la ligne supplémentaire dans le contenu du fichier l'invalidera.
* Aspose.Slides for Java recherche généralement la licence aux emplacements suivants :
  * Un chemin explicite
  * Le dossier contenant Aspose.Slides.jar
* Pour éviter les limitations associées à la version d'évaluation, vous devez définir une licence avant d'utiliser **Aspose.Slides**. Vous n'avez à définir la licence qu'une seule fois par application ou processus.

{{% alert color="info" title="Note" %}}

Vous pouvez consulter [Licence à la consommation](/slides/fr/java/metered-licensing/).

{{% /alert %}} 


## **Appliquer une licence**

Une licence peut être chargée à partir d'un **fichier** ou d'un **flux**.

{{% alert color="info" title="Note" %}}

Aspose.Slides fournit la classe [License](https://reference.aspose.com/slides/java/com.aspose.slides/license/) pour les opérations de licence.

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

Les nouvelles licences peuvent activer Aspose.Slides uniquement avec la version 21.4 ou ultérieure. Les versions antérieures utilisent un système de licence différent et ne reconnaîtront pas ces licences.

{{% /alert %}}

### **Fichier**

La méthode la plus simple pour définir une licence consiste à placer le fichier de licence dans le dossier contenant Aspose.Slides.jar ou le jar de votre application.

Ce code Java montre comment définir un fichier de licence :

``` java
// Instancie la classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Définit le chemin du fichier de licence
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" title="Warning" %}}

Si vous placez le fichier de licence dans un répertoire différent, lorsque vous appelez la méthode [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-), le nom du fichier de licence à la fin du chemin spécifié doit être identique à celui de votre fichier de licence.

Par exemple, vous pouvez changer le nom du fichier de licence en *Aspose.Slides.Java.lic.xml*. Ensuite, dans votre code, vous devez transmettre le chemin vers le fichier (se terminant par *Aspose.Slides.Java.lic.xml*) à la méthode [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Flux**

Vous pouvez charger une licence depuis un flux. Ce code Java montre comment appliquer une licence depuis un flux :

``` java
// Instancie la classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Définit la licence via un flux
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Si vous utilisez Aspose.Slides pour PHP via Java, vous pouvez définir une licence via un pont PHP/Java. Ce pont vous permet d'utiliser des classes Java avec une syntaxe PHP. Pour plus d'informations, consultez [Licence en PHP](/slides/fr/php-java/licensing/).

## **Valider une licence**

Pour vérifier qu'une licence a été correctement définie, vous pouvez la valider. Ce code Java montre comment valider une licence :

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Sécurité des threads**

{{% alert color="warning" title="Warning" %}}

La méthode [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.io.InputStream-) n'est pas sécurisée pour les threads. Si cette méthode doit être appelée simultanément depuis de nombreux threads, vous voudrez peut‑être utiliser des primitives de synchronisation (comme un verrou) pour éviter les problèmes.

{{% /alert %}}

## **FAQ**

### Puis‑je appliquer la licence dans un environnement complètement hors ligne (sans accès Internet) ?

Oui. La validation de la licence s'effectue localement à l'aide du fichier de licence ; aucune connexion Internet n'est requise.

### Que se passe‑t‑il après l'expiration de l'abonnement d'un an ? La bibliothèque cesse‑t‑elle de fonctionner ?

Non. La licence est perpétuelle : vous pouvez continuer à utiliser les versions publiées avant la date de fin de votre abonnement ; vous ne pourrez simplement pas bénéficier des nouvelles versions sans renouveler.