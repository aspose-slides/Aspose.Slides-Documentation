---
title: Licence
type: docs
weight: 80
url: /fr/net/licensing/
---

## **Évaluer Aspose.Slides**

{{% alert color="primary" %}} 

Vous pouvez télécharger une version d'évaluation d'**Aspose.Slides for NET** depuis [sa page de téléchargement NuGet](https://www.nuget.org/packages/Aspose.Slides.NET/). La version d'évaluation offre les mêmes fonctionnalités que la version sous licence du produit. Le package d'évaluation est identique au package acheté. La version d'évaluation devient simplement sous licence après que vous ayez ajouté quelques lignes de code (pour appliquer la licence).

Une fois que vous êtes satisfait de votre évaluation d'**Aspose.Slides**, vous pouvez [acheter une licence](https://purchase.aspose.com/buy). Nous vous recommandons de parcourir les différents types d'abonnement. Si vous avez des questions, contactez l'équipe commerciale d'Aspose.

Toute licence Aspose comprend un abonnement d'un an pour des mises à jour gratuites vers les nouvelles versions ou les correctifs publiés pendant la période d'abonnement. Les utilisateurs disposant de produits sous licence ou même des versions d'évaluation bénéficient d'un support technique gratuit et illimité.

{{% /alert %}} 

**Limitations de la version d'évaluation**

* Bien que la version d'évaluation d'Aspose.Slides (sans licence spécifiée) offre toutes les fonctionnalités du produit, elle insère un filigrane d'évaluation en haut du document lors des opérations d'ouverture et d'enregistrement. 
* Vous êtes limité à une diapositive lors de l'extraction de texte à partir des diapositives de présentation.

{{% alert color="primary" %}} 

Pour tester Aspose.Slides sans limitations, vous pouvez demander une **Licence temporaire de 30 jours**. Consultez la page [Comment obtenir une licence temporaire](https://purchase.aspose.com/temporary-license) pour plus d'informations.

{{% /alert %}}

## **Licence dans Aspose.Slides**
* Une version d'évaluation devient sous licence après que vous avez acheté une licence et ajouté quelques lignes de code (pour appliquer la licence).
* La licence est un fichier XML en texte brut qui contient des détails tels que le nom du produit, le nombre de développeurs autorisés, la date d'expiration de l'abonnement, etc.
* Le fichier de licence est signé numériquement, vous ne devez donc pas le modifier. Même l'ajout accidentel d'un retour à la ligne supplémentaire dans le contenu du fichier le rendra invalide.
* Aspose.Slides pour .NET recherche généralement la licence aux emplacements suivants :
  * Un chemin explicite
  * Le dossier contenant le dll du composant (inclus dans Aspose.Slides)
  * Le dossier contenant l'assembly qui a appelé le dll du composant (inclus dans Aspose.Slides)
  * Le dossier contenant l'assembly d'entrée (votre .exe)
  * Une ressource incorporée dans l'assembly qui a appelé le dll du composant (inclus dans Aspose.Slides).
* Pour éviter les limitations associées à la version d'évaluation, vous devez définir une licence avant d'utiliser Aspose.Slides. Vous n'avez à définir la licence qu'une seule fois par application ou processus.

{{% alert color="primary" %}} 

Vous pourriez vouloir consulter [Licence au compteur](https://docs.aspose.com/slides/net/metered-licensing/).

{{% /alert %}} 


## **Appliquer une licence**
Une licence peut être chargée à partir d'un **fichier**, d'un **flux** ou d'une **ressource incorporée**. 

{{% alert color="primary" %}}

Aspose.Slides fournit la classe [License](https://reference.aspose.com/slides/net/aspose.slides/license) pour les opérations de licence.

{{% /alert %}} 

{{% alert color="warning" %}} 

Les nouvelles licences peuvent activer Aspose.Slides uniquement à partir de la version 21.4 ou ultérieure. Les versions antérieures utilisent un système de licence différent et ne reconnaîtront pas ces licences.

{{% /alert %}}

### **File**
La méthode la plus simple pour définir une licence consiste à placer le fichier de licence dans le même dossier contenant le DLL du composant (inclus dans Aspose.Slides) et à spécifier uniquement le nom du fichier sans son chemin.

Ce code C# montre comment définir un fichier de licence :
``` csharp
// Instancie la classe License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Définit le chemin du fichier de licence
license.SetLicense("Aspose.Slides.lic");
```


{{% alert color="warning" %}} 

Si vous placez le fichier de licence dans un autre répertoire, lorsque vous appelez la méthode [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1), le nom du fichier de licence à la fin du chemin explicite spécifié doit être identique à votre fichier de licence.

Par exemple, vous pouvez changer le nom du fichier de licence en *Aspose.Slides.lic.xml*. Ensuite, dans votre code, vous devez passer le chemin du fichier (se terminant par *Aspose.Slides.lic.xml*) à la méthode [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1).

{{% /alert %}}

### **Stream**
Vous pouvez charger une licence depuis un flux. Ce code C# montre comment appliquer une licence depuis un flux :
``` csharp
// Instancie la classe License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Définit la licence via un flux
license.SetLicense(myStream);
```


### **Embedded Resource**
Vous pouvez inclure la licence avec votre application (pour éviter de la perdre) en ajoutant la licence en tant que ressource incorporée dans l'une des assemblies qui appellent le DLL du composant (inclus dans Aspose.Slides). 

Voici comment ajouter un fichier de licence en tant que ressource incorporée :

1. Dans Visual Studio, ajoutez le fichier de licence (.lic) au projet de cette manière : Passez par **File** > **Add Existing Item** > **Add**. 
2. Sélectionnez le fichier dans l'**Solution Explorer**.
3. Dans la fenêtre **Properties**, définissez l'**Build Action** sur **Embedded Resource**.
4. Pour accéder à la licence incorporée dans l'assembly, ajoutez le fichier de licence en tant que ressource incorporée au projet, puis passez le nom du fichier de licence à la méthode `SetLicense`.


La classe `License` trouve automatiquement le fichier de licence dans les ressources incorporées. Vous n'avez pas besoin d'appeler les méthodes `GetExecutingAssembly` et `GetManifestResourceStream` de la classe `System.Reflection.Assembly` du Microsoft .NET Framework.

``` csharp
// Instancie la classe License
Aspose.Slides.License license = new Aspose.Slides.License();

// Passe le nom du fichier de licence intégré dans l'assembly
license.SetLicense("Aspose.Slides.lic");
```


## **Valider une licence**

Pour vérifier si une licence a été correctement définie, vous pouvez la valider. Ce code C# montre comment valider une licence :
```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```


## **Sécurité des threads**

{{% alert title="Note" color="warning" %}} 

La méthode [license.SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/) n'est pas sûre pour les threads. Si cette méthode doit être appelée simultanément depuis plusieurs threads, vous pouvez utiliser des primitives de synchronisation (comme un verrou) pour éviter les problèmes. 

{{% /alert %}}

## **FAQ**

**Puis-je appliquer la licence dans un environnement complètement hors ligne (sans accès Internet) ?**

Oui. La validation de la licence se fait localement en utilisant le fichier de licence ; aucune connexion Internet n'est requise.

**Que se passe-t-il après l'expiration de l'abonnement d'un an ? La bibliothèque cessera-t-elle de fonctionner ?**

Non. La licence est perpétuelle : vous pouvez continuer à utiliser les versions publiées avant la date de fin de votre abonnement ; vous ne pourrez simplement pas utiliser les nouvelles versions sans renouveler.