---
title: Ouvrir des présentations dans Node.js via .NET
linktitle: Ouvrir une présentation
type: docs
weight: 20
url: /fr/nodejs-net/open-presentation/
keywords:
- ouvrir présentation
- ouvrir PowerPoint
- ouvrir PPTX
- ouvrir PPT
- ouvrir ODP
- charger présentation
- présentation depuis un tampon
- nombre de diapositives
- convertir présentation
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Ouvrez des présentations PPTX, PPT et ODP en JavaScript avec Aspose.Slides for Node.js via .NET : chargez depuis un chemin de fichier ou un tampon, lisez le nombre de diapositives et enregistrez dans un autre format."
---
## **Vue d'ensemble**

Aspose.Slides for Node.js via .NET ouvre des présentations PowerPoint et OpenDocument, telles que les fichiers PPTX, PPT et ODP, à partir d’un chemin de fichier ou d’un `Buffer` Node.js. Cet article montre les deux méthodes, lit le nombre de diapositives et enregistre une présentation ouverte dans un autre format.

Les exemples s’attendent à une présentation nommée `sample.pptx` dans le dossier du projet que vous avez configuré dans [Installation](/slides/fr/nodejs-net/installation/). Toute présentation PowerPoint convient. Enregistrez chaque exemple en tant que fichier `.js` dans le dossier du projet et exécutez‑le depuis ce dossier avec `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET ne possède pas de référence d’API propre. Il reflète l’API Aspose.Slides for .NET avec des noms camelCase, de sorte que les liens d’API de cet article mènent aux classes et membres correspondants dans la [référence d’API Aspose.Slides for .NET](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Ouvrir une présentation à partir d'un fichier**

Pour ouvrir une présentation, transmettez son chemin au constructeur [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Aspose.Slides détecte le format à partir du contenu du fichier plutôt qu’à partir de l’extension, ainsi le même code ouvre les fichiers PPTX, PPT et ODP. Un chemin relatif est résolu par rapport au répertoire de travail actuel, qui est le dossier du projet lorsque vous exécutez le script depuis celui‑ci.

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Le script affiche le nombre de diapositives dans `sample.pptx`, par exemple `Slide count: 9`. La propriété `count` de la collection [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) inclut les diapositives masquées. Appelez `dispose` dans un bloc `finally`, comme indiqué, afin que les ressources .NET derrière la présentation soient libérées même si votre code échoue.

## **Ouvrir une présentation à partir d'un tampon**

Lorsqu’une présentation provient d’une base de données, d’un téléchargement HTTP ou d’une autre source qui vous fournit des octets plutôt qu’un chemin de fichier, transmettez un `Buffer` Node.js comme deuxième argument du constructeur et `null` comme premier argument. L’exemple suivant lit `sample.pptx` dans un tampon pour représenter une telle source :

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Le script affiche le même nombre de diapositives que l’exemple précédent. Le deuxième argument doit être un `Buffer`. Pour tout autre type, comme un `Uint8Array`, le constructeur ne signale pas d’erreur ; il crée une nouvelle présentation avec une diapositive vide à la place. Convertissez les autres types binaires en `Buffer` avec `Buffer.from` au préalable.

## **Enregistrer une présentation dans un autre format**

Pour convertir une présentation vers un autre format, ouvrez‑la et enregistrez‑la avec une valeur différente de [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). L’exemple suivant affiche le format détecté par Aspose.Slides, que la propriété [sourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) renvoie, et enregistre la présentation au format OpenDocument :

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

Le script affiche `Source format: Pptx` et écrit `sample.odp`, qui contient les mêmes diapositives. `sourceFormat` renvoie `Ppt`, `Pptx` ou `Odp`. Pour enregistrer au format PDF ou sous forme d’images, consultez [Convert PowerPoint to PDF](/slides/fr/nodejs-net/convert-powerpoint-to-pdf/) et [Convert Slides to Images](/slides/fr/nodejs-net/convert-slide/).

## **FAQ**

**Comment ouvrir une présentation protégée par mot de passe ?**

Créez un objet [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/), définissez sa propriété [password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) et transmettez cet objet comme troisième argument du constructeur : `new Presentation("protected.pptx", null, loadOptions)`. Sans le mot de passe correct, le constructeur lève une erreur.

**Pourquoi le constructeur lève‑t‑il une `Error` avec un message vide ?**

Lorsque le constructeur `Presentation` échoue dans .NET, par exemple parce que le fichier est absent, n’est pas une présentation ou nécessite un autre mot de passe, JavaScript reçoit une `Error` dont le message est vide. Avant d’ouvrir un fichier, vérifiez qu’il existe par rapport au répertoire de travail, par exemple avec `fs.existsSync`.

**Quels formats puis‑je ouvrir ?**

Les formats de présentation PowerPoint et OpenDocument, y compris PPT, PPTX, PPS, POT, POTX, PPTM, ODP, OTP et FODP.