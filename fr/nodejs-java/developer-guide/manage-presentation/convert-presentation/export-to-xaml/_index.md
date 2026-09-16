---
title: Exporter des présentations au format XAML en JavaScript
linktitle: Présentation en XAML
type: docs
weight: 30
url: /fr/nodejs-java/export-to-xaml/
keywords:
- exporter PowerPoint
- exporter OpenDocument
- exporter présentation
- convertir PowerPoint
- convertir OpenDocument
- convertir présentation
- PowerPoint en XAML
- OpenDocument en XAML
- présentation en XAML
- PPT en XAML
- PPTX en XAML
- ODP en XAML
- enregistrer PPT en XAML
- enregistrer PPTX en XAML
- enregistrer ODP en XAML
- exporter PPT en XAML
- exporter PPTX en XAML
- exporter ODP en XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir les diapositives PowerPoint et OpenDocument en XAML avec JavaScript en utilisant Aspose.Slides—solution rapide, sans Office, qui conserve votre mise en page intacte."
---
## **Vue d'ensemble**

Cet article explique comment exporter des présentations PowerPoint vers XAML à l'aide d'Aspose.Slides. Il comprend une brève introduction à XAML, montre comment enregistrer une présentation au format XAML avec les paramètres par défaut, et démontre comment personnaliser l'exportation via [XamlOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/xamloptions/), y compris l'exportation des diapositives masquées. L'article répond également à quelques questions fréquentes liées aux polices de secours, à la compatibilité des piles XAML et au comportement d'exportation des diapositives masquées.

## **À propos de XAML**

XAML est un langage de balisage basé sur XML utilisé pour décrire les interfaces utilisateur dans des frameworks tels que WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin.Forms.

Vous pouvez travailler avec des fichiers XAML dans un concepteur visuel ou écrire et modifier le balisage directement.

## **Exporter des présentations vers XAML avec les options par défaut**

L'exemple JavaScript suivant montre comment exporter une présentation en XAML avec les paramètres par défaut :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Par défaut, les diapositives exportées sont enregistrées dans un sous-dossier `input` du répertoire de travail actuel du processus. Le dossier est créé automatiquement, et toutes les images requises y sont également enregistrées.

Le nom du dossier de sortie est tiré du nom du fichier source sans son extension. Dans Aspose.Slides pour Node.js via Java 26.8, l'exportation de `input.pptx` produit un chemin imbriqué tel que `input/input/Slide_1.xaml`. Conservez les chemins complets générés lors du traitement de la sortie. La sortie par défaut est relative au répertoire de travail actuel, plutôt que nécessairement à côté du fichier d'entrée.

## **Exporter des présentations vers XAML avec des options personnalisées**

Utilisez l'interface [IXamlOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ixamloptions/) pour contrôler la façon dont Aspose.Slides exporte une présentation en XAML.

Pour enregistrer la sortie à un emplacement personnalisé, implémentez [IXamlOutputSaver](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ixamloutputsaver/) et transmettez une instance de votre implémentation à la méthode [setOutputSaver](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) de [XamlOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/xamloptions/).

Pour inclure les diapositives masquées dans la sortie XAML, appelez [setExportHiddenSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) avec `true`, comme le montre l'exemple JavaScript suivant :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Capturer tous les artefacts XAML générés**

Une exportation XAML peut produire un document XAML pour chaque diapositive exportée ainsi que des images et des ressources de support séparées. Assignez un [IXamlOutputSaver](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ixamloutputsaver/) personnalisé à [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) pour recevoir ces artefacts au lieu d'utiliser le sauvegardeur de système de fichiers par défaut. Démarrez l'exportation avec la surcharge spécifique XAML de [Presentation.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#save) qui accepte les options XAML.

Dans Node.js, implémentez l'interface Java avec `java.newProxy` du paquet `java` utilisé par Aspose.Slides. Conservez le proxy accessible jusqu'à ce que l'exportation se termine.

### **Comprendre le cycle de vie du callback**

Le processus d'exportation appelle [IXamlOutputSaver.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) séparément pour chaque artefact généré :

- `path` identifie l'artefact et peut inclure des répertoires relatifs. Conservez cette information car XAML peut référencer des ressources en utilisant des chemins relatifs.
- `data` contient les octets de l'artefact. Les images et autres ressources binaires ne doivent pas être décodées en texte.
- Le sauvegardeur est responsable de conserver ou de persister les données avant de retourner. Les exemples copient chaque tableau d'octets Java dans un tampon Node.js appartenant à l'application.
- Considérez l'exportation comme réussie uniquement lorsque l'opération d'enregistrement de la présentation renvoie et que chaque callback s'est terminé avec succès. Ne masquez pas les erreurs de stockage ni ne lancez d'écritures en arrière-plan non observées. Si la persistance se produit ensuite, signalez le succès global uniquement après que cette étape réussisse également.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) s'applique également à un sauvegardeur personnalisé. Le paramètre par défaut, `false`, exclut les documents XAML des diapositives masquées. Passer `true` les inclut ainsi que toutes les ressources nécessaires à leur exportation. Le nombre de ressources dépend de la présentation ; ne supposez pas un callback par diapositive ou un ordre de callback fixe.

### **Exporter en mémoire et inspecter les artefacts**

Cet exemple complet charge `input.pptx`, collecte chaque artefact dans une map JavaScript de noms vers des tampons, et affiche son nom, son type et le nombre d'octets. Il conserve exactement les noms fournis. Les noms en double marquent la collection comme invalide au lieu d'écraser silencieusement un artefact. L'exemple vérifie cela avant d'utiliser les résultats.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // Décoder uniquement le XAML, et seulement lorsque l'inspection textuelle est nécessaire.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

Les vérifications d'extension sont utiles pour l'inspection ; conservez tous les artefacts, y compris les types de ressources inconnus. Laissez les octets inchangés lors du stockage ou de la transmission. Utilisez le décodage UTF-8 uniquement pour le XAML qui nécessite un traitement textuel.

### **Emballez les artefacts collectés dans une archive ZIP**

Cet exemple autonome collecte l'exportation, valide ses noms et écrit les octets originaux dans une archive ZIP à l'aide du pont Java. Le ZIP est assemblé en mémoire avant d'être sauvegardé sur disque. Un nom d'archive unique sépare les travaux d'exportation concurrents. Les entrées ZIP utilisent des barres obliques (/) et conservent les répertoires relatifs. Les noms dangereux ou les noms qui entrent en collision après normalisation rejettent l'ensemble du paquet avant qu'il ne soit écrit.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const signedBytes = Array.from(data, value => value > 127 ? value - 256 : value);
            const bytes = java.newArray("byte", signedBytes);
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // Fermeture finalise le répertoire ZIP avant que l'archive ne soit persistée.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

L'exemple utilise [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) pour écrire une archive locale ; l'exportateur lui-même n'écrit pas de fichiers XAML ou image séparés. Pour le stockage distant, remplacez l'étape d'écriture de l'archive par le téléversement des tableaux d'octets collectés. Utilisez un identifiant de travail d'exportation plus le nom complet de l'artefact relatif comme clé de blob, ou stockez l'identifiant du travail, le nom relatif et les données binaires dans une ligne de base de données. Publiez le travail uniquement après que tous les téléversements soient terminés ou que la transaction de base de données soit validée. Nettoyez la sortie partielle si la persistance échoue.

Pour les présentations volumineuses, un sauvegardeur personnalisé peut persister chaque artefact directement dans le stockage de l'application afin d'éviter de conserver une copie supplémentaire de l'ensemble de l'exportation en mémoire. Gardez chaque callback synchrone du point de vue de l'exportateur : ne retournez qu'après que la destination ait accepté les octets, et laissez les échecs remonter à l'appelant.

### **Conserver les noms de ressources et vérifier les références**

- Normalisez les séparateurs de chemin lorsque la destination l'exige, mais conservez les répertoires relatifs. N'utilisez que le nom de base que si chaque nom généré est connu pour être unique et que les références de ressources restent valides.
- Appliquez une validation de nom spécifique à la destination. Lors de l'écriture de fichiers séparés, rejetez les chemins absolus et les segments de traversée, résolvez la destination en un chemin absolu, et vérifiez qu'il reste en dessous du répertoire d'exportation prévu, y compris le séparateur de répertoire dans la vérification de contenance. Utilisez un répertoire contrôlé par l'application sans liens symboliques pouvant rediriger les écritures.
- Utilisez un sauvegardeur et un espace de noms de stockage distincts pour chaque travail d'exportation. Détectez les collisions après normalisation des séparateurs et selon les règles de sensibilité à la casse de la destination.
- Avant de publier, analysez chaque document XAML en tant que XML et inspectez ses références de ressources basées sur des fichiers, telles que les attributs `Source` ou `ImageSource` d'image. Résolvez chaque URI relative par rapport au répertoire de l'artefact XAML contenant, normalisez le nom de stockage résultant, et confirmez que la clé de map correspondante, l'entrée ZIP ou l'objet stocké existe. Traitez les URI externes et les expressions de balisage XAML séparément des noms de fichiers relatifs.

Par exemple, si `input/Slide_1.xaml` fait référence à `images/image1.png`, la ressource stockée doit être disponible sous `input/images/image1.png`. Ne garder que `image1.png` rompt cette relation. Pour le stockage d'objets, conservez la même structure sous le préfixe du travail et rendez ces URL de ressources accessibles au consommateur XAML. Rouvrez le ZIP complet pour vérifier les noms d'entrées et les octets de ressources, et chargez des diapositives représentatives dans l'environnement XAML cible afin de confirmer que les images se résolvent correctement.

## **FAQ**

**Comment garantir des polices prévisibles si la police originale n'est pas disponible sur la machine ?**

Appelez [setDefaultRegularFont](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) dans [XamlOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/xamloptions/) — il est utilisé comme police de secours lors de l'exportation lorsque la police originale est manquante. Cela ne garantit pas que le XAML généré fasse référence à la police de secours ou que la police soit disponible sur la machine cible. Assurez‑vous que les polices référencées par le XAML soient disponibles dans l'environnement où il est affiché.

**Le XAML exporté est‑il destiné uniquement à WPF, ou peut‑il être utilisé dans d’autres piles XAML également ?**

Aspose.Slides exporte du XAML WPF via son API publique. La compatibilité avec d'autres piles XAML, comme UWP et Xamarin.Forms, n'est pas garantie. Testez le balisage généré dans votre environnement cible.

**Les diapositives masquées sont‑elles prises en charge, et comment puis‑je empêcher leur exportation par défaut ?**

Par défaut, les diapositives masquées ne sont pas incluses. Vous pouvez contrôler ce comportement via [setExportHiddenSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) dans [XamlOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/xamloptions/) — laissez‑le désactivé si vous n'avez pas besoin de les exporter.