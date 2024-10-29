---
title: Licence
type: docs
weight: 80
url: /fr/net/licensing/
---

## **Évaluez Aspose.Slides**

{{% alert color="primary" %}} 

Vous pouvez télécharger une version d'évaluation de **Aspose.Slides for NET** depuis [sa page de téléchargement NuGet](https://www.nuget.org/packages/Aspose.Slides.NET/). La version d'évaluation fournit les mêmes fonctionnalités que la version sous licence du produit. Le package d'évaluation est identique au package acheté. La version d'évaluation devient simplement sous licence après que vous ayez ajouté quelques lignes de code (pour appliquer la licence).

Une fois que vous êtes satisfait de votre évaluation de **Aspose.Slides**, vous pouvez [acheter une licence](https://purchase.aspose.com/buy). Nous vous recommandons de passer en revue les différents types d'abonnement. Si vous avez des questions, contactez l'équipe commerciale d'Aspose.

Chaque licence Aspose inclut un abonnement d'un an pour les mises à jour gratuites vers de nouvelles versions ou les correctifs publiés pendant la période d'abonnement. Les utilisateurs de produits sous licence ou même de versions d'évaluation bénéficient d'un support technique gratuit et illimité.

{{% /alert %}} 

**Limitations de la version d'évaluation**

* Bien que la version d'évaluation d'Aspose.Slides (sans licence spécifiée) fournisse l'ensemble des fonctionnalités du produit, elle insère un filigrane d'évaluation en haut du document lors des opérations d'ouverture et d'enregistrement. 
* Vous êtes limité à une diapositive lors de l'extraction de textes à partir des diapositives de présentation.

{{% alert color="primary" %}} 

Pour tester Aspose.Slides sans limitations, vous pouvez demander une **Licence Temporaire de 30 Jours**. Consultez la page [Comment obtenir une Licence Temporaire](https://purchase.aspose.com/temporary-license) pour plus d'informations.

{{% /alert %}}

## **Licences dans Aspose.Slides**
* Une version d'évaluation devient sous licence après que vous ayez acheté une licence et ajouté quelques lignes de code (pour appliquer la licence).
* La licence est un fichier XML en texte brut qui contient des détails tels que le nom du produit, le nombre de développeurs à qui elle est sous licence, la date d'expiration de l'abonnement, etc. 
* Le fichier de licence est signé numériquement, donc vous ne devez pas modifier le fichier. Même une addition involontaire d'un saut de ligne supplémentaire dans le contenu du fichier l'invalidé.
* Aspose.Slides pour .NET essaie généralement de trouver la licence dans ces emplacements :
  * Un chemin explicite
  * Le dossier contenant le dll du composant (inclus dans Aspose.Slides)
  * Le dossier contenant l'assembly qui a appelé le dll du composant (inclus dans Aspose.Slides)
  * Le dossier contenant l'assembly d'entrée (votre .exe)
  * Une ressource intégrée dans l'assembly qui a appelé le dll du composant (inclus dans Aspose.Slides).
* Pour éviter les limitations associées à la version d'évaluation, vous devez définir une licence avant d'utiliser Aspose.Slides. Vous devez uniquement définir une licence une fois par application ou processus.

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter [Licence à la consommation](https://docs.aspose.com/slides/net/metered-licensing/).

{{% /alert %}} 

## **Application d'une Licence**
Une licence peut être chargée à partir d'un **fichier**, d'un **flux** ou d'une **ressource intégrée**. 

{{% alert color="primary" %}}

Aspose.Slides fournit la classe [License](https://reference.aspose.com/slides/net/aspose.slides/license) pour les opérations de licence.

{{% /alert %}} 

### **Fichier**
La méthode la plus simple pour définir une licence nécessite que vous placiez le fichier de licence dans le même dossier que le DLL du composant (inclus dans Aspose.Slides) et que vous spécifiez uniquement le nom du fichier sans son chemin.

Ce code C# vous montre comment définir un fichier de licence :

``` csharp
// Instancie la classe License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Définit le chemin du fichier de licence
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Si vous placez le fichier de licence dans un répertoire différent, lorsque vous appelez la méthode [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1), le nom du fichier de licence à la fin de l'explicite spécifié doit être le même que votre fichier de licence.

Par exemple, vous pouvez changer le nom du fichier de licence en *Aspose.Slides.lic.xml*. Ensuite, dans votre code, vous devez passer le chemin vers le fichier (se terminant par *Aspose.Slides.lic.xml*) à la méthode [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1).

{{% /alert %}}

### **Flux**
Vous pouvez charger une licence à partir d'un flux. Ce code C# vous montre comment appliquer une licence à partir d'un flux :

``` csharp
// Instancie la classe License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Définit la licence à travers un flux
license.SetLicense(myStream);
```

### **Ressource intégrée**
Vous pouvez emballer la licence avec votre application (pour éviter de la perdre) en ajoutant la licence en tant que ressource intégrée dans l'une des assemblies qui appellent le DLL du composant (inclus dans Aspose.Slides). 

Voici comment ajouter un fichier de licence comme ressource intégrée :

1. Dans Visual Studio, ajoutez le fichier de licence (.lic) au projet de cette manière : Allez dans **Fichier** > **Ajouter un élément existant** > **Ajouter**. 
2. Sélectionnez le fichier dans l'**Explorateur de solutions**.
3. Dans la fenêtre des **Propriétés**, définissez l'**Action de compilation** sur **Ressource intégrée**.
4. Pour accéder à la licence intégrée dans l'assembly, ajoutez le fichier de licence comme ressource intégrée au projet, puis passez le nom du fichier de licence à la méthode `SetLicense`. 

La classe `License` trouve automatiquement le fichier de licence dans les ressources intégrées. Vous n'avez pas besoin d'appeler les méthodes `GetExecutingAssembly` et `GetManifestResourceStream` de la classe `System.Reflection.Assembly` dans le cadre de Microsoft .NET Framework.

Ce code C# vous montre comment définir une licence en tant que ressource intégrée :

``` csharp
// Instancie la classe License
Aspose.Slides.License license = new Aspose.Slides.License();

// Passe le nom du fichier de licence intégré dans l'assembly
license.SetLicense("Aspose.Slides.lic");
```

## **Validation d'une Licence**

Pour vérifier si une licence a été correctement définie, vous pouvez la valider. Ce code C# vous montre comment valider une licence :

```csharp
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("La licence est valide !");
    Console.Read();
}
```

## **Sécurité des Threads**

{{% alert title="Remarque" color="warning" %}} 

La méthode [license.SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/) n'est pas thread-safe. Si cette méthode doit être appelée simultanément depuis plusieurs threads, vous souhaiterez peut-être utiliser des primitives de synchronisation (comme un verrou) pour éviter des problèmes. 

{{% /alert %}}