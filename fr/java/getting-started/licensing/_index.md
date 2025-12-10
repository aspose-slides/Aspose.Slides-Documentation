---
title: Licences
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
description: "Appliquer, gérer et dépanner les licences dans Aspose.Slides pour Java. Assurez un accès ininterrompu à toutes les fonctionnalités grâce à notre guide de licences étape par étape."
---

## **Évaluer Aspose.Slides**

{{% alert color="primary" %}} 

Vous pouvez télécharger une version d'évaluation de **Aspose.Slides for Java** depuis sa [page de téléchargement](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). La version d'évaluation offre les mêmes fonctionnalités que la version sous licence du produit. Le package d'évaluation est identique au package acheté. La version d'évaluation devient simplement sous licence après que vous ajoutiez quelques lignes de code (pour appliquer la licence).

Une fois que vous êtes satisfait de votre évaluation de **Aspose.Slides**, vous pouvez [acheter une licence](https://purchase.aspose.com/buy). Nous vous recommandons de parcourir les différents types d'abonnement. Si vous avez des questions, contactez l'équipe commerciale d'Aspose.

Chaque licence Aspose inclut un abonnement d'un an pour des mises à jour gratuites vers les nouvelles versions ou les correctifs publiés pendant la période d'abonnement. Les utilisateurs de produits sous licence (ou même les versions d'évaluation) bénéficient d'un support technique gratuit et illimité.

{{% /alert %}} 

**Limitations de la version d'évaluation**

* Bien que la version d'évaluation d'Aspose.Slides (sans licence spécifiée) offre l'intégralité des fonctionnalités du produit, elle ajoute un filigrane d'évaluation en haut du document lors des opérations d'ouverture et d'enregistrement. 
* Vous êtes limité à une diapositive lors de l'extraction de texte à partir des diapositives de la présentation.

{{% alert color="primary" %}} 

Pour tester Aspose.Slides sans limitations, vous pouvez demander une **licence temporaire de 30 jours**. Consultez la page [Comment obtenir une licence temporaire](https://purchase.aspose.com/temporary-license) pour plus d'informations.

{{% /alert %}}

## **Licence dans Aspose.Slides**

* Une version d'évaluation devient sous licence après que vous achetiez une licence et ajoutiez quelques lignes de code (pour appliquer la licence).
* La licence est un fichier XML en texte brut qui contient des informations comme le nom du produit, le nombre de développeurs autorisés, la date d'expiration de l'abonnement, etc.
* Le fichier de licence est signé numériquement, vous ne devez donc pas le modifier. Même l'ajout accidentel d'un retour à la ligne supplémentaire dans le contenu du fichier l'invalidera.
* Aspose.Slides for Java recherche généralement la licence aux emplacements suivants :
  * Un chemin explicite
  * Le dossier contenant Aspose.Slides.jar
* Pour éviter les limitations liées à la version d'évaluation, vous devez définir une licence avant d'utiliser **Aspose.Slides**. Vous n'avez besoin de définir la licence qu'une seule fois par application ou processus.

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter [Licence à la consommation](/slides/fr/java/metered-licensing/).

{{% /alert %}} 


## **Appliquer une licence**

Une licence peut être chargée à partir d'un **fichier** ou d'un **flux**.

{{% alert color="primary" %}}

Aspose.Slides fournit la classe [License](https://reference.aspose.com/slides/java/com.aspose.slides/License) pour les opérations de licence.

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

Si vous placez le fichier de licence dans un répertoire différent, lorsque vous appelez la méthode [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.lang.String-) le nom du fichier de licence à la fin du chemin explicite spécifié doit être identique à votre fichier de licence.

Par exemple, vous pouvez changer le nom du fichier de licence en *Aspose.Slides.Java.lic.xml*. Ensuite, dans votre code, vous devez passer le chemin vers le fichier (terminé par *Aspose.Slides.Java.lic.xml*) à la méthode [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.lang.String-).

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

Si vous utilisez Aspose.Slides pour PHP via Java, vous pouvez définir une licence via un pont PHP/Java. Ce pont permet d'utiliser les classes Java avec une syntaxe PHP. Pour plus d'informations, consultez [Licence en PHP](/slides/fr/php-java/licensing/).

## **Valider une licence**

Pour vérifier qu'une licence a été correctement définie, vous pouvez la valider. Ce code Java vous montre comment valider une licence :
```java
License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```


## **Sécurité des threads**

{{% alert title="Note" color="warning" %}} 

La méthode [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.io.InputStream-) n'est pas sûre pour les threads. Si cette méthode doit être appelée simultanément par de nombreux threads, vous pouvez envisager d'utiliser des primitives de synchronisation (comme un verrou) pour éviter les problèmes. 

{{% /alert %}}

## **FAQ**

**Puis-je appliquer la licence dans un environnement totalement déconnecté (sans accès à Internet) ?**

Oui. La validation de la licence est effectuée localement à l'aide du fichier de licence ; aucune connexion Internet n'est requise.

**Que se passe-t-il une fois l'abonnement d'un an expiré ? La bibliothèque cessera-t-elle de fonctionner ?**

Non. La licence est perpétuelle : vous pouvez continuer à utiliser les versions publiées avant la date de fin de votre abonnement ; vous ne pourrez simplement pas utiliser les nouvelles versions sans renouveler.