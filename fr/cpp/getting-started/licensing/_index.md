---
title: Licence
type: docs
weight: 120
url: /cpp/licensing/
---

## **Évaluer Aspose.Slides**

{{% alert color="primary" %}} 

Vous pouvez télécharger une version d'évaluation de **Aspose.Slides pour C++** depuis [sa page de téléchargement NuGet](https://www.nuget.org/packages/Aspose.Slides.CPP/). La version d'évaluation fournit les mêmes fonctionnalités que la version sous licence du produit. Le package d'évaluation est le même que le package acheté. La version d'évaluation devient simplement sous licence après avoir ajouté quelques lignes de code pour appliquer la licence.

Une fois que vous êtes satisfait de votre évaluation de **Aspose.Slides**, vous pouvez [acheter une licence](https://purchase.aspose.com/buy). Nous vous recommandons de parcourir les différents types d'abonnement. Si vous avez des questions, contactez l'équipe des ventes d'Aspose.

Chaque licence Aspose comprend un abonnement d'un an pour des mises à jour gratuites vers de nouvelles versions ou des corrections publiées pendant la période d'abonnement. Les utilisateurs de produits sous licence ou même de versions d'évaluation bénéficient d'une assistance technique gratuite et illimitée.

{{% /alert %}} 

**Limitations de la version d'évaluation**

* Bien que la version d'évaluation d'Aspose.Slides (sans licence spécifiée) fournisse l'intégralité des fonctionnalités du produit, elle insère un filigrane d'évaluation en haut du document lors des opérations d'ouverture et d'enregistrement.
* Vous êtes limité à une diapositive lors de l'extraction de textes à partir de diapositives de présentation.

{{% alert color="primary" %}} 

Pour tester Aspose.Slides sans limitations, vous pouvez demander une **licence temporaire de 30 jours**. Consultez la page [Comment obtenir une Licence Temporaire](https://purchase.aspose.com/temporary-license) pour plus d'informations.

{{% /alert %}}

## **Licences dans Aspose.Slides**

* Une version d'évaluation devient sous licence après que vous ayez acheté une licence et ajouté quelques lignes de code pour appliquer la licence.
* La licence est un fichier XML en texte brut qui contient des détails tels que le nom du produit, le nombre de développeurs à qui elle est accordée, la date d'expiration de l'abonnement, etc.
* Le fichier de licence est signé numériquement, vous ne devez donc pas modifier le fichier. Même une addition involontaire d'un saut de ligne supplémentaire dans le contenu du fichier l'invalidera.
* Aspose.Slides pour C++ essaie généralement de trouver la licence dans ces emplacements :
  * Un chemin explicite
  * Le dossier contenant le dll du composant (inclus dans Aspose.Slides)
  * Le dossier contenant l'assemblage qui appelle le dll du composant (inclus dans Aspose.Slides)
* Pour éviter les limitations associées à la version d'évaluation, vous devez définir une licence avant d'utiliser Aspose.Slides. Vous n'avez besoin de définir une licence qu'une seule fois par application ou processus.

## **Application d'une Licence**

Une licence peut être chargée depuis un **fichier**, un **flux**, ou **une ressource intégrée**.

{{% alert color="primary" %}}

Aspose.Slides fournit la classe [License](https://reference.aspose.com/slides/cpp/class/aspose.slides.license/) pour les opérations de licence.

{{% /alert %}} 

### **Fichier**

La méthode la plus simple pour définir une licence nécessite de placer le fichier de licence dans le même dossier que le DLL du composant (inclus dans Aspose.Slides) et de spécifier le nom du fichier sans son chemin.

Ce code C++ vous montre comment définir un fichier de licence :

```c++
SharedPtr<Aspose::Slides::License> lic = MakeObject<Aspose::Slides::License>();

lic->SetLicense(L"Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Si vous placez le fichier de licence dans un répertoire différent, lorsque vous appelez la méthode [License::SetLicense()](https://reference.aspose.com/slides/cpp/class/aspose.slides.license#a44102d1d52a5e45643345448b1814a67), le nom du fichier de licence à la fin de l'explicite spécifié doit être le même que votre fichier de licence.

Par exemple, vous pouvez changer le nom du fichier de licence en *Aspose.Slides.lic.xml*. Ensuite, dans votre code, vous devez passer le chemin vers le fichier (se terminant par *Aspose.Slides.lic.xml*) à la méthode [License::SetLicense()](https://reference.aspose.com/slides/cpp/class/aspose.slides.license#a44102d1d52a5e45643345448b1814a67).

{{% /alert %}}

### **Flux**

Vous pouvez charger une licence à partir d'un flux. Ce code C++ vous montre comment appliquer une licence à partir d'un flux :

```c++
SharedPtr<Aspose::Slides::License> lic = MakeObject<Aspose::Slides::License>();

System::SharedPtr<System::IO::FileStream> stream= System::IO::File::OpenRead(L"Aspose.Slides.lic");

lic->SetLicense(stream); 
```

## **Validation d'une Licence**

Pour vérifier si une licence a été correctement définie, vous pouvez la valider. Ce code C++ vous montre comment valider une licence :

```c++
System::SharedPtr<Aspose::Slides::License> license = System::MakeObject<Aspose::Slides::License>();
license->SetLicense(u"Aspose.Slides.lic");
if (license->IsLicensed())
{
    System::Console::WriteLine(u"Licence valide !");
    System::Console::Read();
}
```

## **Sécurité des Threads**

{{% alert title="Remarque" color="warning" %}} 

La méthode [License::SetLicense()](https://reference.aspose.com/slides/cpp/class/aspose.slides.license#a44102d1d52a5e45643345448b1814a67) n'est pas sûre pour les threads. Si cette méthode doit être appelée simultanément depuis plusieurs threads, vous voudrez peut-être utiliser des primitives de synchronisation (comme un verrou) pour éviter des problèmes. 

{{% /alert %}}