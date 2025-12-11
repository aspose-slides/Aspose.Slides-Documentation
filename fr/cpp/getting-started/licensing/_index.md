---
title: Gestion des licences
type: docs
weight: 120
url: /fr/cpp/licensing/
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
- C++
- Aspose.Slides
description: "Appliquez, gérez et dépannez les licences dans Aspose.Slides pour C++. Assurez un accès ininterrompu à toutes les fonctionnalités grâce à notre guide complet pas à pas sur la gestion des licences."
---

## **Évaluer Aspose.Slides**

{{% alert color="primary" %}} 

Vous pouvez télécharger une version d'évaluation d'**Aspose.Slides for C++** depuis [sa page de téléchargement NuGet](https://www.nuget.org/packages/Aspose.Slides.CPP/). La version d'évaluation offre les mêmes fonctionnalités que le produit sous licence. En fait, le package d'évaluation est identique à celui acheté — il devient simplement sous licence une fois que vous ajoutez quelques lignes de code pour appliquer la licence.

Une fois que vous êtes satisfait de votre évaluation d'**Aspose.Slides**, vous pouvez [acheter une licence](https://purchase.aspose.com/buy). Nous vous recommandons de consulter les types d'abonnement disponibles. Si vous avez des questions, n'hésitez pas à contacter l'équipe commerciale d'Aspose.

Chaque licence Aspose comprend un abonnement d'un an pour des mises à jour gratuites, incluant les nouvelles versions et les correctifs publiés pendant cette période. Que vous utilisiez une version sous licence ou d'évaluation, vous bénéficiez d'un support technique gratuit et illimité.

{{% /alert %}} 

**Limitations de la version d'évaluation**

* Bien que la version d'évaluation d'Aspose.Slides (lorsqu'aucune licence n'est appliquée) fournisse toutes les fonctionnalités du produit, elle insère un filigrane d'évaluation en haut du document lors des opérations d'ouverture et d'enregistrement.
* L'extraction de texte est limitée à une diapositive lors de l'utilisation de la version d'évaluation.

{{% alert color="primary" %}} 

Pour tester Aspose.Slides sans limitations, vous pouvez demander une **licence temporaire de 30 jours**. Pour plus d'informations, consultez la page [Comment obtenir une licence temporaire](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Gestion des licences dans Aspose.Slides**

* Une version d'évaluation devient sous licence après que vous avez acheté une licence et l'avez appliquée en ajoutant quelques lignes de code.
* La licence est un fichier XML en texte clair qui contient des détails tels que le nom du produit, le nombre de développeurs auxquels elle est accordée, la date d'expiration de l'abonnement, etc.
* Le fichier de licence est signé numériquement, il ne doit donc pas être modifié. Même une modification accidentelle—comme l'ajout d'un retour à la ligne—invalidera le fichier.
* Aspose.Slides for C++ recherche généralement le fichier de licence aux emplacements suivants :
  * Un chemin spécifié explicitement dans votre code
  * Le dossier contenant le DLL du composant (inclus dans Aspose.Slides)
  * Le dossier contenant l'assembly qui appelle le DLL du composant
* Pour éviter les limitations de la version d'évaluation, vous devez définir la licence avant d'utiliser Aspose.Slides. Une licence ne doit être définie qu'une seule fois par application ou processus.

## **Appliquer une licence**

Une licence peut être chargée à partir d'un **fichier**, d'un **flux** ou d'une **ressource intégrée**.

{{% alert color="primary" %}}

Aspose.Slides fournit la classe [License](https://reference.aspose.com/slides/cpp/class/aspose.slides.license/) pour les opérations de licence.

{{% /alert %}} 

{{% alert color="warning" %}}

Les nouvelles licences peuvent activer Aspose.Slides uniquement avec la version 21.4 ou ultérieure. Les versions antérieures utilisent un système de licence différent et ne reconnaîtront pas ces licences.

{{% /alert %}}

### **Fichier**

La façon la plus simple de définir une licence consiste à placer le fichier de licence dans le même dossier que le DLL du composant (inclus dans Aspose.Slides) et à spécifier uniquement le nom du fichier, sans le chemin.

Le code C++ suivant montre comment définir un fichier de licence:
```c++
#include <Util/License.h>

using namespace Aspose::Slides;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```


{{% alert color="warning" %}} 

Si vous placez le fichier de licence dans un répertoire différent, alors lors de l'appel de la méthode [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/), le nom du fichier à la fin du chemin explicite spécifié doit correspondre exactement au nom de votre fichier de licence.

Par exemple, si vous renommez votre fichier de licence en *Aspose.Slides.lic.xml*, vous devez fournir le chemin complet se terminant par *Aspose.Slides.lic.xml* à la méthode [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) dans votre code.

{{% /alert %}}

### **Flux**

Vous pouvez charger une licence depuis un flux. Le code C++ suivant montre comment appliquer une licence depuis un flux :
```c++
auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```


## **Valider une licence**

Pour vérifier qu'une licence a été correctement définie, vous pouvez la valider. Le code C++ suivant montre comment valider une licence :
```c++
auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```


## **Sécurité des threads**

{{% alert title="Note" color="warning" %}} 

La méthode [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) n'est **pas sûre pour les threads**. Si vous devez appeler cette méthode depuis plusieurs threads simultanément, il est recommandé d'utiliser des primitives de synchronisation (comme un verrou) pour éviter d'éventuels problèmes.

{{% /alert %}}

## **FAQ**

**Puis-je appliquer la licence dans un environnement totalement hors ligne (sans accès Internet) ?**

Oui. La validation de la licence est effectuée localement à l'aide du fichier de licence ; aucune connexion Internet n'est requise.

**Que se passe-t-il lorsque l'abonnement d'un an expire ? La bibliothèque cessera-t-elle de fonctionner ?**

Non. La licence est perpétuelle : vous pouvez continuer à utiliser les versions publiées avant la date de fin de votre abonnement ; vous ne pourrez simplement pas utiliser les nouvelles versions sans renouveler.