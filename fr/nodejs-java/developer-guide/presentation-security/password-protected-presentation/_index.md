---
title: Protéger les présentations par mot de passe en JavaScript
linktitle: Protection par mot de passe
type: docs
weight: 20
url: /fr/nodejs-java/password-protected-presentation/
keywords:
- présentation protégée par mot de passe
- mot de passe d'ouverture
- chiffrer PowerPoint
- décrypter PowerPoint
- valider le mot de passe de la présentation
- vérifier le mot de passe de la présentation
- ouvrir une présentation chiffrée
- supprimer le chiffrement
- PowerPoint
- PPT
- PPTX
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Chiffrer, détecter, valider, ouvrir et décrypter des présentations PowerPoint PPT et PPTX protégées par mot de passe en JavaScript avec Aspose.Slides."
---
## **Vue d'ensemble**

Un mot de passe d'ouverture chiffre une présentation. Le mot de passe correct est nécessaire pour charger et afficher le contenu de la présentation, ce qui assure la confidentialité.

Un mot de passe d'ouverture diffère d'un mot de passe de protection en écriture. La protection en écriture limite la modification mais ne chiffre pas le contenu et n'empêche pas le chargement de la présentation. Pour gérer les mots de passe permettant de modifier les présentations, consultez [Write-Protect Presentations](/slides/fr/nodejs-java/write-protected-presentation/).

Les flux de travail ci‑dessous s'appliquent aux présentations PPT et PPTX. Les exemples utilisent les deux formats lorsque leur comportement basé sur le fichier ou le flux est important.

## **Chiffrer une présentation avec un mot de passe d'ouverture**

Utilisez [ProtectionManager.encrypt](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/protectionmanager/#encrypt) pour attribuer un mot de passe d'ouverture. Puis utilisez [Presentation.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#save) pour enregistrer la présentation chiffrée.

L'exemple suivant chiffre une présentation PPTX :
```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Charger une présentation chiffrée**

Définissez [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#setPassword) avec le mot de passe d'ouverture et transmettez les options à [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) lors du chargement du fichier. Le chargement échoue lorsqu'un mot de passe d'ouverture est requis mais que le mot de passe fourni est absent ou incorrect.
```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Travailler avec la présentation déchiffrée.
} finally {
    presentation.dispose();
}
```

## **Supprimer le chiffrement d'une présentation**

Chargez la présentation avec son mot de passe d'ouverture, appelez [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) et enregistrez le résultat. La présentation enregistrée peut alors être chargée sans mot de passe.
```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Valider un mot de passe d'ouverture avant le chargement**

Utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) pour obtenir [PresentationInfo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/) sans créer d'instance complète de présentation. Vérifiez [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) avant de demander ou valider un mot de passe. Lorsque la protection est présente, validez la valeur fournie avec [PresentationInfo.checkPassword](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Flux de travail avec chemin de fichier**

L'exemple suivant valide un mot de passe d'ouverture pour un fichier PPTX, transmet la valeur validée à [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#setPassword), puis charge la présentation complète :
```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Flux de travail avec flux**

Utilisez [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) pour inspecter un flux lisible Node.js. Après que le flux d'inspection a été consommé, créez un nouveau flux avant de charger la présentation complète avec [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

L'exemple suivant utilise un fichier PPT :
```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **Valeurs de retour de checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/#checkPassword) renvoie `true` uniquement lorsque la présentation possède un mot de passe d'ouverture et que le mot de passe fourni est correct. Elle renvoie `false` dans chacun de ces cas :
- Le mot de passe est incorrect.
- La présentation n'a pas de mot de passe d'ouverture.
- Le mot de passe fourni est `null` ou vide.

Le comportement est identique pour les présentations PPT et PPTX.

## **Vérifier si une présentation chargée est chiffrée**

Après avoir chargé une présentation avec le mot de passe correct, inspectez [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) pour confirmer que la présentation source était chiffrée. Pour détecter la protection par mot de passe d'ouverture avant le chargement, utilisez [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) comme indiqué précédemment.
```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Recommandations de sécurité**

{{% alert color="warning" title="Security" %}}
Ne consignez pas les mots de passe d'ouverture et ne les incluez pas dans les messages de diagnostic. Évitez les tentatives de validation répétées inutiles, conservez les mots de passe en mémoire uniquement le temps nécessaire, et réutilisez un résultat de validation réussi lors du chargement immédiat de la présentation.
{{% /alert %}}

## **Protéger une présentation par mot de passe en ligne**

1. Ouvrez l'application [Aspose.Slides Lock](https://products.aspose.app/slides/fr/lock).
2. Sélectionnez ou téléchargez la présentation.
3. Saisissez un mot de passe pour la protection en lecture.
4. Optionnellement, saisissez un mot de passe distinct pour la protection en modification.
5. Appliquez la protection et téléchargez le fichier résultant.

{{% alert color="info" title="See also" %}}
- [Protéger les présentations en écriture](/slides/fr/nodejs-java/write-protected-presentation/)
- [Signature numérique dans PowerPoint](/slides/fr/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre un mot de passe d'ouverture et un mot de passe de protection en écriture ?**

Un mot de passe d'ouverture chiffre la présentation et est requis pour charger son contenu. Un mot de passe de protection en écriture limite la modification sans chiffrer le contenu.

**Puis-je valider un mot de passe d'ouverture sans charger toutes les diapositives ?**

Oui. Obtenez les informations de la présentation, vérifiez si une protection par mot de passe d'ouverture est présente, et validez le mot de passe avant de créer une instance complète de la présentation.

**Les flux de travail de vérification de mot de passe prennent-ils en charge à la fois PPT et PPTX ?**

Oui. La détection et la validation des mots de passe basées sur le chemin de fichier ou le flux se comportent de la même manière pour les présentations PPT et PPTX.