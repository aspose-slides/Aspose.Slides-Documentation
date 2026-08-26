---
title: Protéger les présentations par écriture en JavaScript
linktitle: Protection en écriture
type: docs
weight: 25
url: /fr/nodejs-java/write-protected-presentation/
keywords:
- protection en écriture
- PowerPoint à protection en écriture
- mot de passe de modification
- restreindre la modification de la présentation
- supprimer la protection en écriture
- valider le mot de passe de modification
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Définir, détecter, valider et supprimer les mots de passe de protection en écriture dans les présentations PowerPoint PPT et PPTX à l’aide d’Aspose.Slides pour Node.js via Java."
---
## **Introduction**

Un mot de passe de protection en écriture restreint la modification d’une présentation mais n’en chiffre pas le contenu. Les utilisateurs peuvent charger et visualiser une présentation protégée en écriture sans le mot de passe. Selon l’application, ils peuvent également modifier le contenu et l’enregistrer sous un autre nom, ainsi la protection en écriture ne doit pas être considérée comme un mécanisme de confidentialité.

Un mot de passe d’ouverture a un but différent : il chiffre la présentation et est requis pour charger son contenu. Pour chiffrer une présentation ou valider un mot de passe d’ouverture, consultez [Password-Protect Presentations](/slides/fr/nodejs-java/password-protected-presentation/).

Les flux de travail décrits dans cet article s’appliquent aux présentations PPT et PPTX. Les exemples utilisent des fichiers PPTX ; lors de l’enregistrement au format PPT, utilisez l’extension `.ppt` et le format d’enregistrement PPT correspondant.

## **Définir la protection en écriture sur une présentation**

Utilisez [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection) pour attribuer un mot de passe à la modification d’une présentation. L’enregistrement de la présentation persiste le paramètre de protection.

L’exemple suivant définit la protection en écriture sur une présentation PPTX :

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Charger une présentation protégée en écriture**

Comme la protection en écriture ne chiffre pas le contenu de la présentation, aucun mot de passe n’est requis pour charger la présentation. Le mot de passe n’est pertinent que lors de la validation de l’autorisation de modifier la présentation protégée.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Ne transmettez pas de mot de passe de protection en écriture à [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#setPassword). Cette méthode accepte un mot de passe d’ouverture pour le contenu chiffré. Si une présentation possède les deux types de protection, fournissez le mot de passe d’ouverture pour la charger et gérez séparément le mot de passe de protection en écriture.

## **Supprimer la protection en écriture d’une présentation**

Utilisez [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection) pour lever la restriction de modification, puis enregistrez la présentation.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vérifier si une présentation est protégée en écriture**

Pour inspecter un fichier sans créer une instance complète de [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/), appelez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) et examinez [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected). La méthode utilise [NullableBool](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/nullablebool/) et renvoie `NullableBool.True` lorsqu’une protection en écriture est détectée.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

La méthode basée sur les flux [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) fournit les mêmes informations pour une présentation fournie sous la forme d’un flux lisible Node.js.

## **Valider un mot de passe de protection en écriture**

Utilisez [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) pour valider un mot de passe de modification sans charger la présentation complète. Vérifiez d’abord [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) afin que l’application ne demande ou ne valide un mot de passe que lorsqu’une protection en écriture est présente.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) ne valide que le mot de passe de protection en écriture. Il ne valide pas un mot de passe d’ouverture ni ne détermine si le contenu chiffré peut être chargé. Inversement, [PresentationInfo.checkPassword](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/#checkPassword) ne valide qu’un mot de passe d’ouverture. Si une présentation complète a déjà été chargée, [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection) fournit le même contrôle de protection en écriture via son gestionnaire de protection.

Dans les applications de production, ne consignez pas les mots de passe et ne les incluez pas dans les messages de diagnostic. Évitez les tentatives de validation répétées inutiles et ne conservez les mots de passe en mémoire que le temps nécessaire.

{{% alert color="info" title="Voir aussi" %}}
- [Password-Protect Presentations](/slides/fr/nodejs-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/fr/nodejs-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/fr/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**La protection en écriture chiffre‑t‑elle une présentation ?**

Non. Elle restreint la modification mais laisse le contenu de la présentation disponible pour le chargement et la visualisation.

**Le mot de passe de protection en écriture est‑il requis pour ouvrir une présentation ?**

Non. Seul un mot de passe d’ouverture est requis pour charger le contenu chiffré d’une présentation.

**Une présentation peut‑elle avoir à la fois un mot de passe d’ouverture et un mot de passe de protection en écriture ?**

Oui. Fournissez le mot de passe d’ouverture via les options de chargement pour ouvrir la présentation chiffrée, et validez séparément le mot de passe de protection en écriture lorsque l’autorisation de modification est nécessaire.