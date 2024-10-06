---
title: Licence
type: docs
weight: 90
url: /java/licensing/
---

## **Évaluer Aspose.Slides**

{{% alert color="primary" %}} 

Vous pouvez télécharger une version d'évaluation de **Aspose.Slides for Java** depuis sa [page de téléchargement](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). La version d'évaluation offre les mêmes fonctionnalités que la version sous licence du produit. Le package d'évaluation est le même que le package acheté. La version d'évaluation devient simplement sous licence après que vous y ayez ajouté quelques lignes de code (pour appliquer la licence).

Une fois que vous êtes satisfait de votre évaluation de **Aspose.Slides**, vous pouvez [acheter une licence](https://purchase.aspose.com/buy). Nous vous recommandons de passer en revue les différents types d'abonnement. Si vous avez des questions, contactez l'équipe commerciale d'Aspose.

Chaque licence Aspose est accompagnée d'un abonnement d'un an pour des mises à jour gratuites vers de nouvelles versions ou des corrections publiées pendant la période d'abonnement. Les utilisateurs disposant de produits sous licence (ou même de versions d'évaluation) bénéficient d'un support technique gratuit et illimité.

{{% /alert %}} 

**Limitations de la version d'évaluation**

* Bien que la version d'évaluation d'Aspose.Slides (sans licence spécifiée) fournisse la fonctionnalité complète du produit, elle insère un filigrane d'évaluation en haut du document lors des opérations d'ouverture et de sauvegarde.
* Vous êtes limité à une diapositive lors de l'extraction de textes à partir de diapositives de présentation.

{{% alert color="primary" %}} 

Pour tester Aspose.Slides sans limitations, vous pouvez demander une **licence temporaire de 30 jours**. Consultez la page [Comment obtenir une licence temporaire](https://purchase.aspose.com/temporary-license) pour plus d'informations.

{{% /alert %}}

## **Licences dans Aspose.Slides**

* Une version d'évaluation devient sous licence après que vous ayez acheté une licence et ajouté quelques lignes de code (pour appliquer la licence).
* La licence est un fichier XML en texte brut qui contient des détails tels que le nom du produit, le nombre de développeurs auxquels elle est accordée, la date d'expiration de l'abonnement, et ainsi de suite.
* Le fichier de licence est signé numériquement, donc vous ne devez pas modifier le fichier. Même une addition involontaire d'un retour à la ligne supplémentaire dans le contenu du fichier l'invalidaterait.
* Aspose.Slides for Java essaie généralement de trouver la licence dans ces emplacements :
  * Un chemin explicite
  * Le dossier contenant Aspose.Slides.jar
* Pour éviter les limitations associées à la version d'évaluation, vous devez définir une licence avant d'utiliser **Aspose.Slides**. Vous n'avez besoin de définir une licence qu'une seule fois par application ou processus.

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter [Licences à la consommation](/slides/java/metered-licensing/).

{{% /alert %}} 

## **Application d'une Licence**

Une licence peut être chargée à partir d'un **fichier** ou d'un **flux**.

{{% alert color="primary" %}}

Aspose.Slides fournit la classe [License](https://reference.aspose.com/slides/java/com.aspose.slides/License) pour les opérations de licence.

{{% /alert %}} 

### **Fichier**

La méthode la plus simple pour définir une licence nécessite que vous placiez le fichier de licence dans le dossier contenant Aspose.Slides.jar ou le jar de votre application.

Ce code Java montre comment définir un fichier de licence :

``` java
// Instancie la classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Définit le chemin du fichier de licence
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Si vous placez le fichier de licence dans un répertoire différent, lorsque vous appelez la méthode [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.lang.String-), le nom du fichier de licence à la fin de l'explicit spécifié doit être le même que votre fichier de licence.

Par exemple, vous pouvez changer le nom du fichier de licence en *Aspose.Slides.Java.lic.xml*. Ensuite, dans votre code, vous devez passer le chemin du fichier (se terminant par *Aspose.Slides.Java.lic.xml*) à la méthode [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.lang.String-).

{{% /alert %}}

### **Flux**

Vous pouvez charger une licence à partir d'un flux. Ce code Java vous montre comment appliquer une licence à partir d'un flux :

``` java
// Instancie la classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Définit la licence à travers un flux
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **Pont PHP/Java**

Si vous utilisez Aspose.Slides pour PHP via Java, vous pouvez définir une licence via un pont PHP/Java. Ce pont vous permet d'utiliser des classes Java en syntaxe PHP. Pour plus d'informations, consultez [Licence en PHP](/slides/php-java/licensing/).

## **Validation d'une Licence**

Pour vérifier si une licence a été correctement définie, vous pouvez la valider. Ce code Java vous montre comment valider une licence :

```java
License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("La licence est valide !");
}
```

## **Sécurité des Threads**

{{% alert title="Remarque" color="warning" %}} 

La méthode [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.io.InputStream-) n'est pas thread-safe. Si cette méthode doit être appelée simultanément depuis plusieurs threads, vous voudrez peut-être utiliser des primitives de synchronisation (comme un verrou) pour éviter des problèmes.

{{% /alert %}}