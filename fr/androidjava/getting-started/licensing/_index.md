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
description: "Appliquer, gérer et résoudre les problèmes de licences dans Aspose.Slides for Android via Java. Assurez un accès ininterrompu aux fonctionnalités complètes avec notre guide de licences."
---
## **Vue d'ensemble**

Aspose.Slides peut être utilisé en mode d'évaluation ou avec une licence valide. La version d'évaluation offre les mêmes fonctionnalités que la version sous licence, mais elle ajoute un filigrane d'évaluation à chaque diapositive de chaque présentation qu'elle enregistre et tronque le texte que votre code lit à partir des présentations.

Cet article explique comment fonctionne la gestion des licences dans Aspose.Slides et comment appliquer une licence avant d'utiliser la bibliothèque. Une licence peut être chargée à partir d'un fichier, d'un flux ou d'une ressource incorporée en utilisant la classe [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/). L'article montre également comment valider si une licence a été appliquée correctement.

## **Évaluer Aspose.Slides**

{{% alert color="info" title="Note" %}}
Vous pouvez télécharger une version d'évaluation de **Aspose.Slides for Android via Java** depuis sa [page de téléchargement](https://releases.aspose.com/slides/androidjava/). La version d'évaluation fournit les mêmes fonctionnalités que la version sous licence du produit. Le package d'évaluation est identique au package acheté. La version d'évaluation devient simplement sous licence après que vous ayez ajouté quelques lignes de code pour appliquer la licence.
{{% /alert %}}

Une fois que vous êtes satisfait de votre évaluation de **Aspose.Slides**, vous pouvez [acheter une licence](https://purchase.aspose.com/pricing/slides/android-java/). Nous vous recommandons de parcourir les différents types d'abonnement. Si vous avez des questions, contactez l'équipe commerciale d'Aspose.

Chaque licence Aspose comprend un abonnement d’un an pour des mises à jour gratuites vers de nouvelles versions ou des correctifs publiés pendant la période d’abonnement. Les utilisateurs de produits sous licence (ou même de versions d’évaluation) bénéficient d’un support technique gratuit et illimité.

{{% alert color="info" title="Note" %}}
Pour tester Aspose.Slides sans limitations, vous pouvez demander une **licence temporaire de 30 jours**. Consultez la page [How to get a Temporary License](https://purchase.aspose.com/temporary-license) pour plus d’informations.
{{% /alert %}}

**Limitations de la version d'évaluation**

* La version d'évaluation (sans licence spécifiée) offre toutes les fonctionnalités du produit, mais ajoute une zone de texte de filigrane d'évaluation à chaque diapositive de chaque présentation qu'elle enregistre.
* Le texte que votre code lit à partir d’une présentation est tronqué aux premiers caractères, suivi d’un avis sur la limitation d’évaluation. Le texte que votre code écrit est sauvegardé en entier.

## **Licences dans Aspose.Slides**

* Une version d'évaluation devient sous licence après que vous ayez acheté une licence et ajouté quelques lignes de code pour l’appliquer.
* La licence est un fichier XML en texte clair qui contient des détails tels que le nom du produit, le nombre de développeurs autorisés, la date d’expiration de l’abonnement, etc.
* Le fichier de licence est signé numériquement, vous ne devez donc pas le modifier. Même l’ajout accidentel d’un saut de ligne supplémentaire dans le contenu du fichier le rendra invalide.
* Aspose.Slides for Android via Java recherche généralement la licence aux emplacements suivants :
  * Un chemin explicite
  * Le dossier contenant Aspose.Slides.jar
* Pour éviter les limitations associées à la version d’évaluation, vous devez définir une licence avant d’utiliser **Aspose.Slides**. Vous n’avez besoin de définir la licence qu’une seule fois par application ou processus.

## **Appliquer une licence**

Une licence peut être chargée à partir d’un **fichier** ou d’un **flux**.

{{% alert color="info" title="Note" %}}
Aspose.Slides fournit la classe [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) pour les opérations de licence.
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Les nouvelles licences peuvent activer Aspose.Slides uniquement avec la version 21.4 ou ultérieure. Les versions antérieures utilisent un système de licence différent et ne reconnaîtront pas ces licences.
{{% /alert %}}

### **Fichier**

La méthode la plus simple pour définir une licence consiste à placer le fichier de licence dans le dossier contenant Aspose.Slides.jar ou le JAR de votre application.

{{% alert color="info" title="Note" %}}
Sur Android, la bibliothèque et votre application sont emballées dans l’APK, il n’existe donc aucun dossier contenant le fichier JAR de la bibliothèque, et un chemin relatif tel que *Aspose.Slides.Android.via.Java.lic* ne pointe pas vers un fichier dans votre application. Ajoutez le fichier de licence aux actifs de votre application et chargez‑le depuis un flux, comme indiqué dans [Flux depuis les actifs de l'application](#stream-from-app-assets).
{{% /alert %}}

Ce code Java montre comment définir un fichier de licence :

``` java
// Instancie la classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Définit le chemin du fichier de licence
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Warning" %}}
Si vous placez le fichier de licence dans un répertoire différent, lorsque vous appelez la méthode [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-), le nom du fichier de licence à la fin du chemin spécifié doit être identique à celui de votre fichier de licence.

Par exemple, vous pouvez changer le nom du fichier de licence en *Aspose.Slides.Android.via.Java.lic.xml*. Dans ce cas, votre code doit transmettre le chemin vers le fichier (se terminant par *Aspose.Slides.Android.via.Java.lic.xml*) à la méthode [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).
{{% /alert %}}

### **Flux**

Vous pouvez charger une licence depuis un flux. Ce code Java montre comment appliquer une licence à partir d’un flux :

``` java
// Instancie la classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Définit la licence via un flux
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **Flux depuis les actifs de l'application**

Dans une application Android, placez le fichier de licence dans le dossier *assets* du module d’application, *app/src/main/assets*, afin qu’il soit inclus dans l’APK. Ouvrez le fichier avec la méthode [getAssets](https://developer.android.com/reference/android/content/Context#getAssets()) et transmettez le flux à la méthode [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-). Le code s’exécute dans une `Activity`, par exemple dans sa méthode `onCreate`, avant que l’application n’utilise Aspose.Slides :

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

Le nom de fichier passé à la méthode [open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String)) est relatif au dossier *assets*. Si le fichier n’est pas présent, le code journalise l’erreur et Aspose.Slides reste en mode d’évaluation. Pour vérifier si la licence a été appliquée, consultez [Valider une licence](#validating-a-license).

## **Valider une licence**

Pour vérifier qu’une licence a été correctement définie, vous pouvez la valider. Ce code Java montre comment valider une licence :

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Sécurité des threads**

{{% alert color="warning" title="Warning" %}}
La méthode [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) n’est pas sûre pour les threads. Si cette méthode doit être appelée simultanément depuis plusieurs threads, vous devriez envisager d’utiliser des primitives de synchronisation (comme un verrou) pour éviter les problèmes.
{{% /alert %}}

## **FAQ**

### Puis‑je appliquer la licence dans un environnement complètement hors ligne (sans accès à Internet) ?

Oui. La validation de la licence est effectuée localement à l’aide du fichier de licence ; aucune connexion Internet n’est requise.

### Que se passe‑t‑il après l’expiration de l’abonnement d’un an ? La bibliothèque cessera‑t‑elle de fonctionner ?

Non. La licence est perpétuelle : vous pouvez continuer à utiliser les versions publiées avant la date de fin de votre abonnement ; vous ne serez simplement pas autorisé à utiliser les nouvelles versions sans renouveler l’abonnement.