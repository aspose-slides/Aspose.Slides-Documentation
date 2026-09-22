---
title: Déterminer le format d'origine de la présentation en Node.js
linktitle: Format source
type: docs
weight: 35
url: /fr/nodejs-java/detect-presentation-source-format/
keywords:
- format source
- détecter le format de présentation
- PowerPoint
- OpenDocument
- présentation
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Lire le format d'origine d'une présentation chargée en Node.js avec Aspose.Slides pour Node.js via Java, comparer les API de détection et gérer les fichiers, les flux et les formats anciens."
---
## **Vue d'ensemble**

Après avoir chargé une présentation, appelez la méthode [Presentation.getSourceFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getSourceFormat) pour déterminer son format d'origine. Utilisez‑la lorsque le traitement ultérieur dépend du format à partir duquel l'instance actuelle a été chargée.

Le format source est distinct du [SaveFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/saveformat/) sélectionné pour un fichier de sortie. Enregistrer dans un autre format ne modifie pas le format source de l'instance existante.

## **Lire le format source d'un fichier**

Cet exemple nécessite un fichier `sample.pptx` existant. Il charge le fichier et sélectionne une politique de traitement d'application en utilisant [Presentation.getSourceFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getSourceFormat), plutôt que le nom de fichier. Modifiez le chemin d'entrée pour essayer d'autres formats. L'exemple affiche la politique sélectionnée ; remplacez les messages par la logique de votre application.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Reconnaître les valeurs prises en charge**

La classe [SourceFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sourceformat/) définit des constantes entières qui différencient les formats de présentation suivants. Les extensions ci‑dessous sont des extensions conventionnelles, pas une reconstruction du nom de fichier d'origine.

| Valeur SourceFormat | Extension | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 presentation |
| `Pptx` | `.pptx` | Office Open XML presentation |
| `Pptm` | `.pptm` | Macro-enabled Office Open XML presentation |
| `Pps` | `.pps` | PowerPoint 97–2003 slide show |
| `Ppsx` | `.ppsx` | Office Open XML slide show |
| `Ppsm` | `.ppsm` | Macro-enabled Office Open XML slide show |
| `Pot` | `.pot` | PowerPoint 97–2003 template |
| `Potx` | `.potx` | Office Open XML template |
| `Potm` | `.potm` | Macro-enabled Office Open XML template |
| `Odp` | `.odp` | OpenDocument presentation |
| `Otp` | `.otp` | OpenDocument presentation template |
| `Fodp` | `.fodp` | Flat XML ODF presentation |
| `Xml` | `.xml` | PowerPoint XML presentation |

## **Lire le format source d'un flux**

Cet exemple nécessite un fichier `sample.pps` existant. Lire ses octets dans un flux mémoire modélise une entrée reçue sans nom de fichier, comme une valeur de base de données ou un tableau d'octets téléchargé. Le constructeur [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) ne reçoit que le flux.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT, PPS et POT utilisent le même format binaire sous‑jacent. Lors du chargement par chemin de fichier, l'extension peut aider à distinguer un diaporama ou un modèle. Sans nom de fichier, le contenu legacy PPS et POT peut être signalé comme `SourceFormat.Ppt` ; l'exemple PPS ci‑dessus affiche la valeur entière de `SourceFormat.Ppt`.

Si votre application doit conserver cette distinction, conservez séparément le nom de fichier original ou les métadonnées de sous‑type. Une extension constitue un indice utile pour ces sous‑types legacy, mais ne doit pas être la seule base pour identifier un contenu de présentation arbitraire.

## **Comparer la détection avant et après le chargement**

Utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) et [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat) lorsque vous devez inspecter un fichier avant de charger son modèle d'objet de présentation complet. Utilisez [Presentation.getSourceFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getSourceFormat) lorsque l'instance existe déjà.

Cet exemple nécessite `sample.pptx` et affiche les valeurs entières de `LoadFormat.Pptx` et `SourceFormat.Pptx`, respectivement. En production, choisissez l'API adaptée à votre étape de traitement ; une présentation déjà chargée n'a pas besoin d'une seconde inspection uniquement pour obtenir son format source.

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Les résultats utilisent des constantes provenant de classes différentes : [LoadFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadformat/) et [SourceFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sourceformat/). Ne comparez pas leurs valeurs numériques et ne supposez pas que chaque format possède les mêmes résultats de détection. PowerPoint XML peut être signalé comme `LoadFormat.Unknown` avant le chargement et `SourceFormat.Xml` après le chargement.

## **Conserver séparés les formats source et de sortie**

Cet exemple nécessite `sample.pptx` et écrit `converted.odp`. Il affiche la valeur entière de `SourceFormat.Pptx` avant et après l'enregistrement de l'instance originale. Seule la nouvelle instance chargée à partir du fichier ODP de sortie signale `Odp`.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Une présentation créée à partir de zéro avec `new Presentation()` signale `SourceFormat.Pptx`. Elle n'a pas de fichier d'entrée : il s'agit de la valeur par défaut pour une instance nouvellement créée, pas d'une preuve qu'un fichier PPTX a été chargé. Suivez séparément si votre application a créé ou chargé l'instance si cette distinction est importante.

## **Mapper un format source à une extension**

L'exemple suivant nécessite `sample.pptx`. Il associe chaque valeur [SourceFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sourceformat/) actuellement prise en charge à une extension conventionnelle, sans analyser le nom de fichier d'entrée. La solution de secours évite d'attribuer silencieusement une extension à une valeur non reconnue.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Cette correspondance ne convertit pas un fichier ni ne restaure un sous‑type legacy PPS/POT perdu lors du chargement du flux. Pour un enregistrement réel, sélectionnez explicitement un [SaveFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/saveformat/), ou utilisez la conversion illustrée dans [Save Presentations in Their Original Format](/slides/fr/nodejs-java/save-presentation/#save-presentations-in-their-original-format).

## **Vérifier les formats en enregistrant et en rouvrant**

Cet exemple autonome crée une présentation et écrit trois fichiers dans le répertoire de travail, en écrasant les fichiers portant le même nom. Il rouvre chaque sortie à la fois par chemin et via un flux mémoire. Pour PPTX et ODP, les deux voies signalent le format enregistré. Pour PPS, le chargement par chemin signale `Pps`, tandis que le chargement des mêmes octets sans nom de fichier signale `Ppt`.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Le tableau suivant résume l'identification du format source pour les présentations avec des extensions correspondantes. Les noms désignent des constantes ; les exemples JavaScript affichent leurs valeurs entières :

| Format enregistré | SourceFormat depuis un chemin de fichier | SourceFormat depuis un flux sans nom |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Same as file path |
| ODP, OTP | `Odp`, `Otp` respectively | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT content is identified as `Ppt` for nameless streams. The table describes format identification, not preservation of every presentation feature during conversion.

## **FAQ**

**Enregistrer au format ODP modifie-t-il le format source d'une présentation chargée à partir d'un PPTX ?**

Non. L'instance existante signale toujours `Pptx`. Une instance chargée à partir du fichier ODP enregistré signale `Odp`.

**Un flux peut-il toujours distinguer une présentation legacy, un diaporama et un modèle ?**

Non. PPT, PPS et POT partagent le même format binaire. Conservez séparément le nom de fichier ou les métadonnées de sous‑type lorsque cette distinction est requise.

**Quelle API dois‑je utiliser si la présentation est déjà chargée ?**

Lisez [Presentation.getSourceFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getSourceFormat). Utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) pour l'inspection avant le chargement.