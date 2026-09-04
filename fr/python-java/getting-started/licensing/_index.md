---
title: Gestion des licences
type: docs
weight: 80
url: /fr/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- fichier de licence
- licence temporaire
- licence au compteur
- limitations d'évaluation
description: "Appliquer une licence fichier, basée sur des octets ou au compteur dans Aspose.Slides for Python via Java et supprimer les limitations d'évaluation de vos applications."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java peut fonctionner en mode d'évaluation ou avec une licence. Cet article explique comment appliquer une licence à partir d'un fichier ou de octets et comment configurer la licence au compte.

Pour les options d'achat, consultez [Pricing Information](https://purchase.aspose.com/pricing/slides/fr/family). Pour les questions générales sur les licences et les achats, consultez [Purchase Policies and FAQ](https://purchase.aspose.com/policies).

Pour les limitations de l'évaluation et la façon de demander une licence temporaire, consultez [Evaluate Aspose.Slides](/slides/fr/python-java/evaluate-aspose-slides/). Appliquez une licence temporaire de la même manière qu'un fichier de licence acheté.

## **À propos de la licence**

Un fichier de licence contient des informations telles que le nom du produit, le nombre de développeurs licenciés et la date d'expiration de l'abonnement. Le fichier est un XML signé numériquement.

{{% alert color="warning" title="Attention" %}}
Ne modifiez pas le fichier de licence. Même un saut de ligne supplémentaire peut invalider sa signature numérique.
{{% /alert %}}

Appliquez la licence une fois par application ou processus, avant de créer des présentations ou d'effectuer d'autres opérations Aspose.Slides. Pour un fichier de licence, utilisez la classe [License](https://reference.aspose.com/slides/fr/python-java/aspose.slides/license/). La licence au compte utilise une paire de clés publique et privée au lieu d'un fichier de licence.

## **Appliquer une licence**

Les exemples suivants supposent qu'Aspose.Slides for Python via Java et ses prérequis sont installés. Chaque exemple est un script autonome qui démarre la JVM, importe l'API et applique une licence. Dans votre application, effectuez vos opérations de présentation après avoir appliqué la licence et arrêtez la JVM uniquement après que tout le travail Aspose.Slides soit terminé.

### **Appliquer une licence à partir d'un fichier**

Passez le chemin du fichier de licence à [License.setLicense](https://reference.aspose.com/slides/fr/python-java/aspose.slides/license/#setLicense). Remplacez `Aspose.Slides.lic` par le chemin de votre fichier de licence.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # Effectuez les opérations de présentation ici, avant d'arrêter la JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Utilisez le nom de fichier exact, y compris son extension. Par exemple, si le fichier s'appelle `Aspose.Slides.lic.xml`, incluez `.xml` dans le chemin. Un chemin absolu évite toute ambiguïté concernant le répertoire de travail de l'application.

L'exemple utilise [License.isLicensed](https://reference.aspose.com/slides/fr/python-java/aspose.slides/license/#isLicensed) pour vérifier si la licence a été appliquée.

### **Appliquer une licence à partir d'octets**

Utilisez [License.setLicenseFromBytes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/license/#setLicenseFromBytes) lorsque la licence est disponible sous forme d'octets Python. L'exemple suivant lit le fichier en mode binaire et le ferme avant d'appliquer la licence.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # Effectuez les opérations de présentation ici, avant d'arrêter la JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Conservez les octets originaux intacts. Ne décoder, reformater ou modifier le contenu de la licence avant de l'appliquer.

## **Appliquer une licence au compte**

La licence au compte vous facture en fonction de l'utilisation de l'API. Après avoir obtenu une licence au compte, appliquez ses clés publique et privée avec [Metered.setMeteredKey](https://reference.aspose.com/slides/fr/python-java/aspose.slides/metered/#setMeteredKey). Initialise l'objet [Metered](https://reference.aspose.com/slides/fr/python-java/aspose.slides/metered/) et applique les clés une fois au démarrage de l'application.

L'exemple suivant lit les clés à partir des variables d'environnement `ASPOSE_METERED_PUBLIC_KEY` et `ASPOSE_METERED_PRIVATE_KEY`. Définissez les deux variables avant d'exécuter le script.

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # Effectuez les opérations de présentation ici, avant d'arrêter la JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Remarque" %}}
La licence au compte nécessite une connexion Internet pour valider les clés et rapporter l'utilisation. Gardez la clé privée hors du code source et des journaux. Consultez la [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) pour les détails de connectivité et de facturation.
{{% /alert %}}

## **FAQ**

**Dois-je installer un package différent après avoir acheté une licence ?**

Non. Appliquez la licence au même package que vous avez utilisé pour l'évaluation.

**Dois-je appliquer une licence pour chaque présentation ?**

Non. Appliquez‑la une fois au démarrage de l'application, avant de créer ou charger des présentations.

**Puis‑je renommer le fichier de licence ?**

Oui. Utilisez le nouveau nom de fichier exact dans votre code et conservez le contenu du fichier inchangé.

**Puis‑je utiliser une licence temporaire avec l'exemple basé sur les octets ?**

Oui. Lisez le fichier de licence temporaire sous forme d'octets et appliquez‑le de la même façon qu'une licence achetée.