---
title: Gestion des licences
type: docs
weight: 90
url: /fr/androidjava/licensing/
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
- Android
- Java
- Aspose.Slides
description: "Appliquer, gérer et dépanner les licences dans Aspose.Slides pour Android via Java. Assurez un accès ininterrompu à toutes les fonctionnalités avec notre guide de licence."
---

## **Évaluer Aspose.Slides**

{{% alert color="primary" %}} 

Vous pouvez télécharger une version d'évaluation de **Aspose.Slides for Android via Java** depuis sa [page de téléchargement](https://releases.aspose.com/slides/androidjava/). La version d'évaluation offre les mêmes fonctionnalités que la version sous licence du produit. Le package d'évaluation est identique au package acheté. La version d'évaluation devient simplement sous licence après que vous ajoutiez quelques lignes de code (pour appliquer la licence).

Une fois que vous êtes satisfait de votre évaluation de **Aspose.Slides**, vous pouvez [acheter une licence](https://purchase.aspose.com/buy). Nous vous recommandons de parcourir les différents types d'abonnement. Si vous avez des questions, contactez l'équipe commerciale d'Aspose.

Chaque licence Aspose comprend un abonnement d'un an pour les mises à jour gratuites vers les nouvelles versions ou les correctifs publiés pendant la période d'abonnement. Les utilisateurs disposant de produits sous licence (ou même de versions d'évaluation) bénéficient d'un support technique gratuit et illimité.

{{% /alert %}} 

**Limites de la version d'évaluation**

* Bien que la version d'évaluation d'Aspose.Slides (sans licence spécifiée) fournisse l'intégralité des fonctionnalités du produit, elle ajoute un filigrane d'évaluation en haut du document lors des opérations d'ouverture et d'enregistrement. 
* Vous êtes limité à une diapositive lors de l'extraction de texte à partir des diapositives de la présentation.

{{% alert color="primary" %}} 

Pour tester Aspose.Slides sans limitations, vous pouvez demander une **Licence temporaire de 30 jours**. Consultez la page [Comment obtenir une licence temporaire](https://purchase.aspose.com/temporary-license) pour plus d'informations.

{{% /alert %}}

## **Licences dans Aspose.Slides**

* Une version d'évaluation devient sous licence après que vous achetiez une licence et ajoutiez quelques lignes de code (pour appliquer la licence).
* La licence est un fichier XML en texte clair qui contient des informations telles que le nom du produit, le nombre de développeurs autorisés, la date d'expiration de l'abonnement, etc. 
* Le fichier de licence est signé numériquement, vous ne devez donc pas le modifier. Même l'ajout accidentel d'un saut de ligne supplémentaire au contenu du fichier l'invalidera.
* Aspose.Slides for Android via Java recherche généralement la licence aux emplacements suivants :
  * Un chemin explicite
  * Le dossier contenant Aspose.Slides.jar
* Pour éviter les limitations liées à la version d'évaluation, vous devez définir une licence avant d'utiliser **Aspose.Slides**. Vous n'avez besoin de définir la licence qu'une seule fois par application ou processus.

## **Appliquer une licence**

Une licence peut être chargée à partir d'un **fichier** ou d'un **flux**.

{{% alert color="primary" %}}

Aspose.Slides fournit la classe [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) pour les opérations de licence.

{{% /alert %}} 

{{% alert color="warning" %}}

Les nouvelles licences peuvent activer Aspose.Slides uniquement avec la version 21.4 ou ultérieure. Les versions antérieures utilisent un système de licence différent et ne reconnaîtront pas ces licences.

{{% /alert %}}

### **Fichier**

La méthode la plus simple pour définir une licence consiste à placer le fichier de licence dans le dossier contenant Aspose.Slides.jar ou le jar de votre application.

Ce code Java montre comment définir un fichier de licence :
``` java
// Instancie la classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Définit le chemin du fichier de licence
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```


{{% alert color="warning" %}} 

Si vous placez le fichier de licence dans un répertoire différent, lorsque vous appelez la méthode [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-), le nom du fichier de licence à la fin du chemin explicite doit être identique à votre fichier de licence.

Par exemple, vous pouvez changer le nom du fichier de licence en *Aspose.Slides.Android.via.Java.lic.xml*. Ensuite, dans votre code, vous devez passer le chemin vers le fichier (se terminant par *Aspose.Slides.Android.via.Java.lic.xml*) à la méthode [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Flux**

Vous pouvez charger une licence à partir d'un flux. Ce code Java montre comment appliquer une licence à partir d'un flux :
``` java
// Instancie la classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Définit la licence via un flux
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```


## **Validation d'une licence**

Pour vérifier qu'une licence a été correctement définie, vous pouvez la valider. Ce code Java montre comment valider une licence :
```java
License license = new License();
license.setLicense("Aspore.Slides.Android.via.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```


## **Sécurité des threads**

{{% alert title="Note" color="warning" %}} 

La méthode [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) n'est pas sûre pour les threads. Si cette méthode doit être appelée simultanément depuis plusieurs threads, vous pouvez utiliser des primitives de synchronisation (comme un verrou) pour éviter les problèmes. 

{{% /alert %}}

## **FAQ**

**Puis-je appliquer la licence dans un environnement complètement hors ligne (sans accès à Internet) ?**

Oui. La validation de la licence s'effectue localement à l'aide du fichier de licence ; aucune connexion Internet n'est requise.

**Que se passe-t-il après l'expiration de l'abonnement d'un an ? La bibliothèque cessera-t-elle de fonctionner ?**

Non. La licence est perpétuelle : vous pouvez continuer à utiliser les versions publiées avant la date de fin de votre abonnement, mais vous ne pourrez pas accéder aux nouvelles versions sans renouveler.