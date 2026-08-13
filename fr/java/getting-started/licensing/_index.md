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
description: "Appliquez, gérez et dépannez les licences dans Aspose.Slides pour Java. Garantissez un accès ininterrompu à l’ensemble des fonctionnalités grâce à notre guide de licence étape par étape."
---
## **Vue d'ensemble**

Aspose.Slides peut être utilisé en mode d'évaluation ou avec une licence valide. La version d'évaluation offre les mêmes fonctionnalités que la version sous licence, mais elle ajoute un filigrane d'évaluation lorsque les présentations sont ouvertes ou enregistrées et limite l'extraction de texte à une diapositive.

Cet article explique comment fonctionne la gestion des licences dans Aspose.Slides et comment appliquer une licence avant d'utiliser la bibliothèque. Une licence peut être chargée depuis un fichier, un flux ou une ressource intégrée en utilisant la classe `License`. L'article montre également comment valider si une licence a été appliquée correctement.

## **Évaluer Aspose.Slides**

{{% alert color="info" %}} 

Vous pouvez télécharger une version d'évaluation d'**Aspose.Slides for Java** depuis sa [page de téléchargement](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). La version d'évaluation fournit les mêmes fonctionnalités que la version sous licence du produit. Le package d'évaluation est identique au package acheté. La version d'évaluation devient simplement sous licence après que vous ayez ajouté quelques lignes de code (pour appliquer la licence).

Une fois que vous êtes satisfait de votre évaluation d'**Aspose.Slides**, vous pouvez [acheter une licence](https://purchase.aspose.com/buy). Nous vous recommandons de parcourir les différents types d'abonnement. Si vous avez des questions, contactez l'équipe de vente d'Aspose.

Chaque licence Aspose comprend un abonnement d'un an pour des mises à jour gratuites vers les nouvelles versions ou les correctifs publiés pendant la période d'abonnement. Les utilisateurs de produits sous licence (ou même les versions d'évaluation) bénéficient d'un support technique gratuit et illimité.

{{% /alert %}} 

**Limitations de la version d'évaluation**

* Bien que la version d'évaluation d'Aspose.Slides (sans licence spécifiée) offre la fonctionnalité complète du produit, elle insère un filigrane d'évaluation en haut du document lors des opérations d'ouverture et d'enregistrement. 
* Vous êtes limité à une diapositive lors de l'extraction de texte à partir des diapositives de la présentation.

{{% alert color="info" %}} 

Pour tester Aspose.Slides sans limitations, vous pouvez demander une **Licence temporaire de 30 jours**. Consultez la page [Comment obtenir une licence temporaire](https://purchase.aspose.com/temporary-license) pour plus d'informations.

{{% /alert %}}

## **Gestion des licences dans Aspose.Slides**

* Une version d'évaluation devient sous licence après que vous ayez acheté une licence et ajouté quelques lignes de code (pour appliquer la licence).
* La licence est un fichier XML en texte brut qui contient des détails tels que le nom du produit, le nombre de développeurs auxquels elle est accordée, la date d'expiration de l'abonnement, etc.
* Le fichier de licence est signé numériquement, vous ne devez donc pas le modifier. Même l'ajout involontaire d'un saut de ligne supplémentaire au contenu du fichier le rendra invalide.
* Aspose.Slides for Java tente généralement de trouver la licence à ces emplacements :
  * Un chemin explicite
  * Le dossier contenant Aspose.Slides.jar
* Pour éviter les limitations associées à la version d'évaluation, vous devez définir une licence avant d'utiliser **Aspose.Slides**. Vous n'avez à définir une licence qu'une seule fois par application ou processus.

{{% alert color="info" %}} 

Vous souhaiterez peut-être consulter [Licence à la consommation](/slides/fr/java/metered-licensing/).

{{% /alert %}} 

## **Appliquer une licence**

Une licence peut être chargée depuis un **fichier** ou un **flux**.

{{% alert color="info" %}}

Aspose.Slides fournit la classe [License](https://reference.aspose.com/slides/fr/java/com.aspose.slides/License) pour les opérations de licence.

{{% /alert %}} 

{{% alert color="warning" %}}

Les nouvelles licences peuvent activer Aspose.Slides uniquement à partir de la version 21.4 ou ultérieure. Les versions antérieures utilisent un système de licence différent et ne reconnaîtront pas ces licences.

{{% /alert %}}

### **Fichier**

La méthode la plus simple pour définir une licence consiste à placer le fichier de licence dans le dossier contenant Aspose.Slides.jar ou le jar de votre application.

Ce code Java vous montre comment définir un fichier de licence :

``` java
// Instancie la classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Définit le chemin du fichier de licence
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Si vous placez le fichier de licence dans un autre répertoire, lorsque vous appelez la méthode [SetLicense](https://reference.aspose.com/slides/fr/java/com.aspose.slides/License#setLicense-java.lang.String-), le nom du fichier de licence à la fin du chemin explicite spécifié doit être identique à celui de votre fichier de licence.

Par exemple, vous pouvez changer le nom du fichier de licence en *Aspose.Slides.Java.lic.xml*. Ensuite, dans votre code, vous devez passer le chemin vers le fichier (se terminant par *Aspose.Slides.Java.lic.xml*) à la méthode [SetLicense](https://reference.aspose.com/slides/fr/java/com.aspose.slides/License#setLicense-java.lang.String-).

{{% /alert %}}

### **Flux**

Vous pouvez charger une licence depuis un flux. Ce code Java vous montre comment appliquer une licence depuis un flux :

``` java
// Instancie la classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Définit la licence via un flux
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Si vous utilisez Aspose.Slides pour PHP via Java, vous pouvez définir une licence via un pont PHP/Java. Ce pont vous permet d'utiliser des classes Java avec la syntaxe PHP. Pour plus d'informations, consultez [Licence en PHP](/slides/fr/php-java/licensing/).

## **Validation d'une licence**

Pour vérifier qu'une licence a été correctement définie, vous pouvez la valider. Ce code Java vous montre comment valider une licence :

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

{{% alert title="Note" color="warning" %}} 

La méthode [SetLicense](https://reference.aspose.com/slides/fr/java/com.aspose.slides/License#setLicense-java.io.InputStream-) n'est pas sûre pour les threads. Si cette méthode doit être appelée simultanément depuis plusieurs threads, vous pouvez envisager d'utiliser des primitives de synchronisation (comme un verrou) pour éviter les problèmes. 

{{% /alert %}}

## **FAQ**

### Puis-je appliquer la licence dans un environnement totalement hors ligne (sans accès Internet) ?

Oui. La validation de la licence est effectuée localement à l'aide du fichier de licence ; aucune connexion internet n'est requise.

### Que se passe-t-il une fois que l'abonnement d'un an expire ? La bibliothèque cessera-t-elle de fonctionner ?

Non. La licence est perpétuelle : vous pouvez continuer à utiliser les versions publiées avant la date de fin de votre abonnement ; vous ne serez simplement pas autorisé à utiliser les nouvelles versions sans renouveler.