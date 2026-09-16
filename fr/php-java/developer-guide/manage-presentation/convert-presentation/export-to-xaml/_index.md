---
title: Exporter des présentations vers XAML en PHP
linktitle: Présentation vers XAML
type: docs
weight: 30
url: /fr/php-java/export-to-xaml/
keywords:
- exporter PowerPoint
- exporter OpenDocument
- exporter la présentation
- convertir PowerPoint
- convertir OpenDocument
- convertir la présentation
- PowerPoint vers XAML
- OpenDocument vers XAML
- présentation vers XAML
- PPT vers XAML
- PPTX vers XAML
- ODP vers XAML
- enregistrer PPT en XAML
- enregistrer PPTX en XAML
- enregistrer ODP en XAML
- exporter PPT vers XAML
- exporter PPTX vers XAML
- exporter ODP vers XAML
- PHP
- Aspose.Slides
description: "Convertissez les diapositives PowerPoint et OpenDocument en XAML à l’aide d’Aspose.Slides pour PHP via Java — solution rapide, sans Office, qui conserve votre mise en page intacte."
---
## **Vue d'ensemble**

Cet article explique comment exporter des présentations PowerPoint vers XAML à l'aide d'Aspose.Slides. Il comprend une brève introduction à XAML, montre comment enregistrer une présentation au format XAML avec les paramètres par défaut, et démontre comment personnaliser l'exportation via [XamlOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/xamloptions/), y compris l'exportation des diapositives masquées. L'article répond également à quelques questions fréquentes concernant les polices de secours, la compatibilité des piles XAML et le comportement d'exportation des diapositives masquées.

## **À propos de XAML**

XAML est un langage de balisage basé sur XML utilisé pour décrire les interfaces utilisateur dans des frameworks tels que WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin.Forms.

Vous pouvez travailler avec des fichiers XAML dans un concepteur visuel ou écrire et modifier le balisage directement.

## **Exporter des présentations vers XAML avec les options par défaut**

L'exemple PHP suivant montre comment exporter une présentation vers XAML avec les paramètres par défaut. Initialise le PHP Java Bridge et charge `aspose.slides.php` avant d'exécuter les exemples de cet article. Placez `pres.pptx` dans le répertoire de travail du serveur Java Bridge, ou fournissez un chemin absolu accessible à ce serveur.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

Par défaut, les diapositives exportées sont enregistrées dans un sous‑dossier `pres` du répertoire de travail actuel du serveur Java Bridge. Le dossier est créé automatiquement, et toutes les images requises y sont également enregistrées.

Le nom du dossier de sortie est dérivé du nom du fichier source sans son extension. Pour `pres.pptx`, les fichiers de sortie sont nommés `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, etc. Même si vous passez un chemin absolu vers la présentation d’entrée, le dossier de sortie est créé par rapport au répertoire de travail actuel du serveur Java Bridge, et non à côté du fichier d’entrée.

## **Exporter des présentations vers XAML avec des options personnalisées**

Utilisez l’interface [IXamlOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ixamloptions/) pour contrôler la façon dont Aspose.Slides exporte une présentation vers XAML.

Pour enregistrer la sortie à un emplacement personnalisé, fournissez un proxy Java implémentant [IXamlOutputSaver](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ixamloutputsaver/) et passez une instance de votre implémentation à la méthode [setOutputSaver](https://reference.aspose.com/slides/fr/php-java/aspose.slides/xamloptions/#setOutputSaver) de [XamlOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/xamloptions/).

Pour inclure les diapositives masquées dans la sortie XAML, appelez [setExportHiddenSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) avec `true`, comme le montre l’exemple PHP suivant :

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

## **Capturer tous les artefacts XAML générés**

Une exportation XAML peut produire un document XAML pour chaque diapositive exportée ainsi que des images séparées et des ressources de support. Assignez un [IXamlOutputSaver](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ixamloutputsaver/) personnalisé à [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/fr/php-java/aspose.slides/xamloptions/#setOutputSaver) pour recevoir ces artefacts au lieu d’utiliser le sauvegardeur de système de fichiers par défaut. Démarrez l’exportation avec la surcharge spécifique XAML de [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#save) qui accepte les options XAML.

La fonction `java_closure` du PHP Java Bridge expose un objet PHP en tant qu’interface Java. Conservez à la fois le sauvegardeur PHP et son proxy actifs jusqu’à la fin de l’exportation. Les liens d’interface pointent vers l’API Java implémentée par le proxy.

### **Comprendre le cycle de vie du rappel**

L’exportateur appelle [IXamlOutputSaver::save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) séparément pour chaque artefact généré :

- `path` identifie l’artefact et peut inclure des répertoires relatifs. Conservez cette information car XAML peut référencer des ressources à l’aide de chemins relatifs.
- `data` contient les octets de l’artefact. Les images et autres ressources binaires ne doivent pas être décodées en texte.
- Le sauvegardeur est responsable de retenir ou de persister les données avant de retourner. Les exemples convertissent chaque tableau d’octets Java en une chaîne binaire PHP appartenant à l’application.
- Considérez l’exportation comme réussie uniquement lorsque l’opération d’enregistrement de la présentation retourne et que chaque rappel a été exécuté avec succès. Ne supprimez pas les erreurs de stockage ni ne lancez des écritures d’arrière‑plan non observées. Si la persistance se produit ultérieurement, ne signalez le succès global qu’après que cette étape ait également réussi.

[XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) s’applique également à un sauvegardeur personnalisé. Le paramètre par défaut, `false`, exclut les documents XAML des diapositives masquées. Passer `true` les inclut ainsi que toutes les ressources requises pour leur exportation. Le nombre de ressources dépend de la présentation ; ne supposez pas un rappel par diapositive ou un ordre de rappel fixe.

### **Exporter en mémoire et inspecter les artefacts**

Cet exemple complet charge `pres.pptx`, collecte chaque artefact dans un tableau associatif PHP de chaînes binaires, et affiche son nom, son type et son nombre d’octets. Il conserve exactement les noms fournis. Les noms dupliqués marquent la collection comme invalide au lieu d’écraser silencieusement un artefact. L’exemple vérifie cela avant d’utiliser les résultats.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$inspectXamlText = false;
foreach ($saver->artifacts as $name => $bytes) {
    $extension = strtolower(pathinfo($name, PATHINFO_EXTENSION));
    $isXaml = $extension === "xaml";
    $isImage = in_array($extension, ["png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff", "svg"], true);
    $kind = $isXaml ? "slide XAML" : ($isImage ? "image" : "supporting resource");
    echo $name . ": " . strlen($bytes) . " bytes (" . $kind . ")" . PHP_EOL;

    // Seul le XAML est traité comme texte UTF-8 pour une inspection facultative.
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

Les vérifications d’extension sont utiles pour l’inspection ; conservez tous les artefacts, y compris les types de ressources inconnus. Ne modifiez pas les octets lors du stockage ou de la transmission. Les chaînes PHP peuvent retenir des données binaires, y compris des octets zéro. Traitez une chaîne comme du texte UTF‑8 uniquement lors de l’inspection du XAML ; ne transcodez pas les octets d’image ou de ressource.

### **Regrouper les artefacts collectés dans une archive ZIP**

Cet exemple autonome collecte l’exportation, valide ses noms, et écrit les octets originaux dans une archive ZIP. Un répertoire de travail créé exclusivement sépare les tâches d’exportation simultanées. Cet exemple nécessite l’extension PHP Phar avec prise en charge ZIP. Les entrées ZIP utilisent des barres obliques avant et conservent les répertoires relatifs. Les noms non sûrs ou les noms qui entrent en collision après normalisation entraînent le rejet complet du paquet avant son écriture.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(false);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$entries = [];
$entryNames = [];
foreach ($saver->artifacts as $name => $bytes) {
    $entryName = str_replace("\\", "/", $name);
    $unsafeName = substr($entryName, 0, 1) === "/" || strpos($entryName, ":") !== false;
    foreach (explode("/", $entryName) as $segment) {
        $unsafeName = $unsafeName || trim($segment) === "" || $segment === "." || $segment === "..";
    }
    $key = strtolower($entryName);
    if ($unsafeName || isset($entryNames[$key])) {
        echo "Export rejected: unsafe or duplicate artifact name: " . $name . PHP_EOL;
        return;
    }
    $entryNames[$key] = true;
    $entries[$entryName] = $bytes;
}

$jobDirectory = "xaml-" . bin2hex(random_bytes(16));
if (!mkdir($jobDirectory, 0700)) {
    echo "Cannot create the export directory." . PHP_EOL;
    return;
}
$archivePath = $jobDirectory . "/export.zip";
try {
    $archive = new PharData($archivePath, 0, null, Phar::ZIP);
    foreach ($entries as $name => $bytes) {
        $archive->addFromString($name, $bytes);
    }
    unset($archive);
    echo "Saved " . count($entries) . " artifacts to " . $archivePath . PHP_EOL;
} catch (Throwable $exception) {
    unset($archive);
    echo "Archive persistence failed: " . $exception->getMessage() . PHP_EOL;
}
```

L’exemple utilise [PharData](https://www.php.net/manual/en/class.phardata.php) pour écrire une archive ZIP locale dans le répertoire de travail du processus PHP ; l’exportateur lui‑même n’écrit aucun fichier XAML ou image détaché. Pour un stockage distant, remplacez l’étape d’écriture d’archive par le téléchargement des chaînes binaires collectées. Utilisez un identifiant de tâche d’exportation plus le nom complet de l’artefact relatif comme clé de blob, ou stockez l’identifiant de tâche, le nom relatif et les données binaires dans une ligne de base de données. Publiez la tâche uniquement après que tous les téléchargements soient terminés ou que la transaction de base de données soit validée. Nettoyez la sortie partielle si la persistance échoue.

Pour les présentations volumineuses, un sauvegardeur personnalisé peut persister chaque artefact directement dans le stockage de l’application afin d’éviter de garder une copie supplémentaire de l’ensemble de l’exportation en mémoire. Gardez chaque rappel synchrone du point de vue de l’exportateur : ne retournez qu’après que la destination ait accepté les octets, et laissez les échecs remonter à l’appelant.

### **Conserver les noms de ressources et vérifier les références**

- Normalisez les séparateurs de chemin lorsque la destination l’exige, mais conservez les répertoires relatifs. N’utilisez pas seulement [basename](https://www.php.net/manual/en/function.basename.php) à moins que chaque nom généré ne soit connu comme unique et que les références de ressources restent valides.
- Appliquez une validation de nom spécifique à la destination. Lors de l’écriture de fichiers détachés, rejetez les chemins absolus et les segments de traversée, résolvez la destination vers un chemin absolu, et vérifiez qu’il reste sous le répertoire d’exportation prévu, y compris le séparateur de répertoire dans la vérification de containment. Utilisez un répertoire contrôlé par l’application sans liens symboliques pouvant rediriger les écritures.
- Utilisez un sauvegardeur et un espace de noms de stockage séparés pour chaque tâche d’exportation. Détectez les collisions après normalisation des séparateurs et selon les règles de sensibilité à la casse de la destination.
- Avant la publication, analysez chaque document XAML en tant qu’XML et inspectez ses références de ressources basées sur les fichiers, telles que les attributs `Source` ou `ImageSource` des images. Résolvez chaque URI relative par rapport au répertoire de l’artefact XAML contenant, normalisez le nom de stockage résultant, et confirmez que la clé correspondante, l’entrée ZIP ou l’objet stocké existe. Traitez séparément les URI externes et les expressions de balisage XAML des noms de fichiers relatifs.

Par exemple, si `pres/Slide_1.xaml` fait référence à `images/image1.png`, la ressource stockée doit être disponible sous `pres/images/image1.png`. Conserver uniquement `image1.png` rompt cette relation. Pour le stockage d’objets, conservez la même hiérarchie sous le préfixe de la tâche et rendez ces URLs de ressources accessibles au consommateur XAML. Rouvrez le ZIP complet pour vérifier les noms d’entrées et les octets des ressources, et chargez des diapositives représentatives dans l’environnement XAML cible afin de confirmer que les images se résolvent correctement.

## **FAQ**

**Comment garantir des polices prévisibles si la police d’origine n’est pas disponible sur la machine ?**

Appelez [setDefaultRegularFont](https://reference.aspose.com/slides/fr/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) dans [XamlOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/xamloptions/) — elle est utilisée comme police de secours pendant l’exportation lorsque l’original manque. Cela ne garantit pas que le XAML généré référence la police de secours ou que la police soit disponible sur la machine cible. Assurez‑vous que les polices référencées par le XAML soient présentes dans l’environnement où il est affiché.

**Le XAML exporté est‑il destiné uniquement à WPF ou peut‑il être utilisé dans d’autres piles XAML ?**

Aspose.Slides exporte le XAML WPF via son API publique. La compatibilité avec d’autres piles XAML, telles que UWP et Xamarin.Forms, n’est pas garantie. Testez le balisage généré dans votre environnement cible.

**Les diapositives masquées sont‑elles prises en charge, et comment empêcher leur exportation par défaut ?**

Par défaut, les diapositives masquées ne sont pas incluses. Vous pouvez contrôler ce comportement via [setExportHiddenSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) dans [XamlOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/xamloptions/) — laissez‑la désactivée si vous n’avez pas besoin de les exporter.