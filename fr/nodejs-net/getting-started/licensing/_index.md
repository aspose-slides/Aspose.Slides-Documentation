---
title: Licence
description: "Appliquez un fichier de licence à Aspose.Slides pour Node.js via .NET, découvrez les limites de la version d'évaluation et obtenez une licence temporaire gratuite de 30 jours pour les tests."
type: docs
weight: 80
url: /fr/nodejs-net/licensing/
---
## **Vue d'ensemble**

Aspose.Slides for Node.js via .NET est un paquet npm à la fois pour l'évaluation et la production. Sans licence, il fonctionne en mode d'évaluation. Après avoir acheté une licence, ou obtenu une licence temporaire gratuite de 30 jours, vous l'appliquez avec quelques lignes de code, et les limitations d'évaluation ne s'appliquent plus.

{{% alert color="info" title="Note" %}}
Les politiques générales sur la façon d'évaluer, de licencier et d'acheter les produits Aspose sont regroupées dans [Politiques d'achat et FAQ](https://purchase.aspose.com/policies). Les prix sont indiqués sur la page [Informations tarifaires](https://purchase.aspose.com/pricing/slides/fr/family).
{{% /alert %}}

## **Limitations de la version d'évaluation**

- **Filigrane.** Chaque diapositive de chaque présentation que vous enregistrez obtient un filigrane d'évaluation : une zone de texte verrouillée au centre de la diapositive qui indique « Évaluation uniquement ». Le même filigrane est appliqué aux exportations PDF, XPS et HTML ainsi qu'aux images de diapositives.
- **Texte tronqué.** Le texte que votre code lit depuis un cadre de texte, un paragraphe ou une portion est limité aux cinq premiers caractères, suivi de la mention « ... text has been truncated due to evaluation version limitation. ». Les exportations Markdown et HTML5 sont tronquées de la même façon. Le texte que votre code écrit est enregistré en entier.

[Évaluer Aspose.Slides](/slides/fr/nodejs-net/evaluate-aspose-slides/) décrit les deux limitations en détail et comprend un script qui les montre.

{{% alert color="success" title="Tip" %}}
Pour tester Aspose.Slides sans les limitations d'évaluation, demandez une **licence temporaire gratuite de 30 jours**. Voir [Comment obtenir une licence temporaire ?](https://purchase.aspose.com/temporary-license) pour plus de détails.
{{% /alert %}}

## **À propos de la licence**

La licence est un fichier XML texte brut contenant des détails tels que le nom du produit, le nombre de développeurs auxquels elle est accordée et la date d'expiration de l'abonnement. Le fichier est signé numériquement, donc ne le modifiez pas : même une rupture de ligne supplémentaire ajoutée par erreur l'invalide.

## **Appliquer une licence**

Appliquez la licence avec la méthode `setLicense` de la classe `License`. Appelez‑la une fois par processus, avant de créer tout objet `Presentation`. La rappeler ne cause aucun problème, mais cela répète un travail déjà effectué.

Le script suivant applique une licence à partir d'un fichier nommé `Aspose.Slides.lic`. Remplacez le nom par le nom ou le chemin complet de votre fichier de licence ; le fichier peut porter n'importe quel nom.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { License } = asposeSlides;

const license = new License();
try {
    license.setLicense("Aspose.Slides.lic");
    console.log("License applied.");
} catch (error) {
    console.log("License not applied:", error.message);
}
```

Un nom de fichier ou un chemin relatif est résolu par rapport au dossier courant, celui depuis lequel vous lancez `node`. Conservez le fichier de licence dans le dossier de votre projet et exécutez vos scripts depuis ce dossier, ou fournissez le chemin complet.

Si le fichier est introuvable ou n'est pas une licence valide, `setLicense` lève une erreur, et Aspose.Slides reste en mode d'évaluation. Le script intercepte l'erreur et affiche son message. Pour un fichier manquant, le message commence par `License "Aspose.Slides.lic" doesn't exist or access is restricted.` et répertorie chaque emplacement qui a été recherché.

Dans ce paquet, une licence n'est appliquée qu'à partir d'un fichier. `License` n'accepte pas de flux, et le paquet n'expose pas de licence à la consommation. Pour la classe encapsulée par le paquet, voir [License](https://reference.aspose.com/slides/fr/net/aspose.slides/license/) dans la référence API Aspose.Slides for .NET.