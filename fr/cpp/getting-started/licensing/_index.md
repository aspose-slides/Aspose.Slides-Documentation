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
description: "Appliquer, gérer et dépanner les licences dans Aspose.Slides pour C++. Assurez un accès ininterrompu aux fonctionnalités complètes grâce à notre guide étape par étape sur la gestion des licences."
---
## **Vue d'ensemble**

Aspose.Slides peut être utilisé en mode d'évaluation ou avec une licence valide. La version d'évaluation offre les mêmes fonctionnalités que la version sous licence, mais elle ajoute un filigrane d'évaluation à chaque diapositive de chaque présentation qu'elle enregistre et tronque le texte que votre code lit depuis les présentations.

Cet article explique le fonctionnement de la licence dans Aspose.Slides et comment appliquer une licence avant d'utiliser la bibliothèque. Une licence peut être chargée à partir d'un fichier ou d'un flux en utilisant la classe `License`. L'article montre également comment valider si une licence a été appliquée correctement.

## **Évaluer Aspose.Slides**

{{% alert color="info" title="Note" %}}
Vous pouvez télécharger une version d'évaluation de **Aspose.Slides for C++** depuis [its NuGet download page](https://www.nuget.org/packages/Aspose.Slides.Cpp/) ou, sous forme de package ZIP, depuis la [download page](https://releases.aspose.com/slides/fr/cpp/). La version d'évaluation offre les mêmes fonctionnalités que le produit sous licence. En fait, le package d'évaluation est identique à celui acheté — il devient simplement sous licence une fois que vous ajoutez quelques lignes de code pour appliquer la licence.

Une fois que vous êtes satisfait de votre évaluation de **Aspose.Slides**, vous pouvez [purchase a license](https://purchase.aspose.com/pricing/slides/fr/cpp/). Nous vous recommandons de consulter les différents types d'abonnement disponibles. Si vous avez des questions, n'hésitez pas à contacter l'équipe commerciale d'Aspose.

Chaque licence Aspose comprend un abonnement d'un an pour les mises à jour gratuites, y compris les nouvelles versions et les corrections de bugs publiées pendant cette période. Que vous utilisiez une version sous licence ou d'évaluation, vous bénéficiez d'un support technique gratuit et illimité.
{{% /alert %}} 

**Limitations de la version d'évaluation**

* La version d'évaluation (sans licence spécifiée) fournit toutes les fonctionnalités du produit, mais elle ajoute une zone de texte de filigrane d'évaluation à chaque diapositive de chaque présentation qu'elle enregistre.  
* Le texte que votre code lit depuis une présentation est tronqué aux premiers caractères, suivi d'un avis sur la limitation d'évaluation. Le texte que votre code écrit est enregistré intégralement.

{{% alert color="info" title="Note" %}}
Pour tester Aspose.Slides sans limitations, vous pouvez demander une **licence temporaire de 30 jours**. Pour plus d'informations, consultez la page [How to Get a Temporary License](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Licence dans Aspose.Slides**

* Une version d'évaluation devient sous licence après que vous ayez acheté une licence et l'ayez appliquée en ajoutant quelques lignes de code.  
* La licence est un fichier XML en texte brut qui contient des détails tels que le nom du produit, le nombre de développeurs autorisés, la date d'expiration de l'abonnement, etc.  
* Le fichier de licence est signé numériquement, il ne doit donc pas être modifié. Même un changement accidentel — comme l'ajout d'un retour à la ligne — invalidera le fichier.  
* Lorsque vous transmettez un nom de fichier sans dossier, Aspose.Slides for C++ recherche le fichier de licence uniquement dans le répertoire de travail actuel. Il ne cherche pas dans le dossier de votre exécutable ni dans celui de la bibliothèque Aspose.Slides, donc indiquez le chemin complet si le fichier de licence est stocké ailleurs.  
* Pour éviter les limitations de la version d'évaluation, vous devez définir la licence avant d'utiliser Aspose.Slides. Une licence ne doit être définie qu'une seule fois par application ou processus.

## **Appliquer une licence**

Une licence peut être chargée à partir d'un **file** ou d'un **stream**.

{{% alert color="info" title="Note" %}}
Aspose.Slides fournit la classe [License](https://reference.aspose.com/slides/fr/cpp/aspose.slides/license/) pour les opérations de gestion de licence.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Les nouvelles licences ne peuvent activer Aspose.Slides qu'avec la version 21.4 ou ultérieure. Les versions antérieures utilisent un système de licence différent et ne reconnaîtront pas ces licences.
{{% /alert %}}

### **Fichier**

La façon la plus simple de définir une licence consiste à placer le fichier de licence dans le répertoire de travail de votre programme et à spécifier uniquement le nom du fichier, sans le chemin. Sinon, indiquez le chemin complet vers le fichier.

Le code C++ suivant applique le fichier de licence *Aspose.Slides.lic* depuis le répertoire de travail du programme :

```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

Si la licence est valide, [License::SetLicense](https://reference.aspose.com/slides/fr/cpp/aspose.slides/license/setlicense/) retourne et le programme se termine sans sortie ; à partir de ce moment, Aspose.Slides fonctionne sans les limitations d'évaluation. Si le fichier n'est pas dans le répertoire de travail, la méthode lève une [FileNotFoundException](https://reference.aspose.com/slides/fr/cpp/system.io/filenotfoundexception/) avec le message *License "Aspose.Slides.lic" doesn't exist or access is restricted*. L'exemple ne gère pas l'exception, le programme s'arrête donc.

{{% alert color="warning" title="Warning" %}}
Si vous placez le fichier de licence dans un autre répertoire, alors lors de l'appel de la méthode [License::SetLicense](https://reference.aspose.com/slides/fr/cpp/aspose.slides/license/setlicense/), le nom de fichier à la fin du chemin explicite spécifié doit correspondre exactement au nom de votre fichier de licence.

Par exemple, si vous renommez votre fichier de licence en *Aspose.Slides.lic.xml*, vous devez transmettre le chemin complet se terminant par *Aspose.Slides.lic.xml* à la méthode [License::SetLicense](https://reference.aspose.com/slides/fr/cpp/aspose.slides/license/setlicense/) dans votre code.
{{% /alert %}}

### **Flux**

Chargez une licence depuis un flux lorsque votre programme ne conserve pas la licence sous forme de fichier nommé, par exemple lorsqu'il lit la licence depuis une base de données. [License::SetLicense](https://reference.aspose.com/slides/fr/cpp/aspose.slides/license/setlicense/) accepte tout [Stream](https://reference.aspose.com/slides/fr/cpp/system.io/stream/) contenant la licence. Pour garder l'exemple concis, le code C++ suivant ouvre *Aspose.Slides.lic* dans le répertoire de travail avec [File::OpenRead](https://reference.aspose.com/slides/fr/cpp/system.io/file/openread/) et applique la licence depuis ce flux :

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

Une licence valide donne le même résultat que dans l'exemple fichier. Si le fichier n'existe pas, [File::OpenRead](https://reference.aspose.com/slides/fr/cpp/system.io/file/openread/) lève une [FileNotFoundException](https://reference.aspose.com/slides/fr/cpp/system.io/filenotfoundexception/) avant que la licence ne soit appliquée, et le programme s'arrête.

## **Valider une licence**

Pour vérifier si une licence a été définie correctement, appelez [License::IsLicensed](https://reference.aspose.com/slides/fr/cpp/aspose.slides/license/islicensed/). Elle renvoie `true` uniquement après qu'une licence valide a été appliquée, et `false` sinon. Le code C++ suivant applique le fichier de licence depuis le répertoire de travail puis le vérifie :

```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

Avec une licence valide, le programme affiche *License is good!*. Si le fichier est manquant ou n'est pas un fichier de licence, [License::SetLicense](https://reference.aspose.com/slides/fr/cpp/aspose.slides/license/setlicense/) lève une exception avant la vérification, et le programme s'arrête sans rien afficher. Si le fichier est une licence dont la signature ne correspond pas, par exemple parce qu'il a été modifié, SetLicense retourne sans erreur mais `IsLicensed` renvoie `false`, de sorte qu'aucune sortie n'est affichée et Aspose.Slides reste en mode d'évaluation.

## **Sécurité des threads**

{{% alert color="warning" title="Warning" %}}
La méthode [License::SetLicense](https://reference.aspose.com/slides/fr/cpp/aspose.slides/license/setlicense/) **n'est pas thread‑safe**. Si vous devez appeler cette méthode depuis plusieurs threads simultanément, il est recommandé d'utiliser des primitives de synchronisation (comme un verrou) pour éviter d'éventuels problèmes.
{{% /alert %}}

## **FAQ**

### Puis-je appliquer la licence dans un environnement totalement hors ligne (pas d'accès Internet) ?

Oui. La validation de la licence s'effectue localement à l'aide du fichier de licence ; aucune connexion Internet n'est requise.

### Que se passe-t-il après l'expiration de l'abonnement d'un an ? La bibliothèque cessera-t-elle de fonctionner ?

Non. La licence est perpétuelle : vous pouvez continuer à utiliser les versions publiées avant la date de fin de votre abonnement ; vous ne serez simplement pas éligible à utiliser les nouvelles versions sans renouveler l'abonnement.