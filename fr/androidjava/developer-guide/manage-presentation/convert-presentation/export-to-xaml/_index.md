---
title: Exporter des présentations vers XAML sur Android
linktitle: Présentation vers XAML
type: docs
weight: 30
url: /fr/androidjava/export-to-xaml/
keywords:
- exporter PowerPoint
- exporter OpenDocument
- exporter présentation
- convertir PowerPoint
- convertir OpenDocument
- convertir présentation
- PowerPoint vers XAML
- OpenDocument vers XAML
- présentation vers XAML
- PPT vers XAML
- PPTX vers XAML
- ODP vers XAML
- enregistrer PPT au format XAML
- enregistrer PPTX au format XAML
- enregistrer ODP au format XAML
- exporter PPT vers XAML
- exporter PPTX vers XAML
- exporter ODP vers XAML
- Android
- Java
- Aspose.Slides
description: "Convertissez les diapositives PowerPoint et OpenDocument en XAML avec Java en utilisant Aspose.Slides pour Android - solution rapide, sans Office, qui conserve votre mise en page intacte."
---
## **Vue d'ensemble**

Cet article explique comment exporter des présentations PowerPoint vers XAML à l'aide d'Aspose.Slides pour Android via Java. Il comprend une brève introduction à XAML, montre comment enregistrer une présentation au format XAML avec les paramètres par défaut, et démontre comment personnaliser l'exportation via [XamlOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/xamloptions/), y compris l'exportation des diapositives masquées. L'article répond également à quelques questions courantes relatives aux polices de secours, à la compatibilité de la pile XAML et au comportement d'exportation des diapositives masquées.

## **À propos de XAML**

XAML est un langage de balisage basé sur XML utilisé pour décrire les interfaces utilisateur dans des frameworks tels que WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin.Forms.

Vous pouvez travailler avec des fichiers XAML dans un concepteur visuel ou écrire et modifier le balisage directement.

## **Exporter des présentations vers XAML avec les options par défaut**

L'exemple Java suivant montre comment exporter une présentation au format XAML avec les paramètres par défaut :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Par défaut, les diapositives exportées sont enregistrées dans un sous‑dossier `pres` du répertoire de travail actuel du processus. Le dossier est créé automatiquement, et toutes les images requises y sont également enregistrées.

Le nom du dossier de sortie est extrait du nom du fichier source, sans son extension. Pour `pres.pptx`, les fichiers de sortie sont nommés `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, etc. Même si vous fournissez un chemin absolu vers la présentation d'entrée, le dossier de sortie est créé de façon relative au répertoire de travail actuel, plutôt qu'à côté du fichier d'entrée.

Sur Android, utilisez un fichier d'entrée accessible à votre application. Le répertoire de travail actuel peut ne pas être accessible en écriture ; utilisez un enregistreur de sortie personnalisé pour conserver l'exportation en mémoire ou l'écrire dans le stockage de l'application, comme indiqué ci-dessous. Le XAML WPF généré est destiné à un consommateur compatible et n'est pas une ressource de mise en page Android.

## **Exporter des présentations vers XAML avec des options personnalisées**

Utilisez l'interface [IXamlOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ixamloptions/) pour contrôler la façon dont Aspose.Slides exporte une présentation vers XAML.

Pour enregistrer la sortie à un emplacement personnalisé, implémentez [IXamlOutputSaver](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ixamloutputsaver/) et transmettez une instance de votre implémentation à la méthode [setOutputSaver](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) de [XamlOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/xamloptions/).

Pour inclure les diapositives masquées dans la sortie XAML, appelez [setExportHiddenSlides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) avec `true`, comme indiqué dans l'exemple Java suivant :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Capturer tous les artefacts XAML générés**

Une exportation XAML peut produire un document XAML pour chaque diapositive exportée ainsi que des images séparées et des ressources de support. Assignez un [IXamlOutputSaver](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ixamloutputsaver/) personnalisé à [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) pour recevoir ces artefacts au lieu d'utiliser le sauvegardeur de système de fichiers par défaut. Démarrez l'exportation avec la surcharge spécifique à XAML de [Presentation.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) qui accepte des options XAML.

### **Comprendre le cycle de vie du rappel**

Le composant d'exportation appelle [IXamlOutputSaver.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) séparément pour chaque artefact généré :

- `path` identifie l'artefact et peut contenir des répertoires relatifs. Conservez cette information car XAML peut référencer des ressources à l'aide de chemins relatifs.
- `data` contient les octets de l'artefact. Les images et autres ressources binaires ne doivent pas être décodées en texte.
- Le sauvegardeur est responsable de retenir ou de persister les données avant de retourner. Les exemples copient chaque tableau d'octets dans la mémoire appartenant à l'application.
- Considérez l'exportation comme réussie uniquement lorsque l'opération d'enregistrement de la présentation se termine et que chaque rappel a été exécuté avec succès. N'ignorez pas les erreurs de stockage ni ne lancez des écritures en arrière‑plan non observées. Si la persistance se produit ultérieurement, ne signalez le succès global qu'après que cette étape ait également réussi.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) s'applique également à un sauvegardeur personnalisé. Le paramètre par défaut, `false`, exclut les documents XAML des diapositives masquées. Passer `true` les inclut ainsi que toutes les ressources nécessaires à leur exportation. Le nombre de ressources dépend de la présentation ; ne supposez pas un rappel par diapositive ou un ordre de rappel fixe.

### **Exporter en mémoire et inspecter les artefacts**

Cet exemple complet charge `pres.pptx`, collecte chaque artefact dans un [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) et imprime son nom, son type et le nombre d'octets. Il conserve exactement les noms fournis. Les noms en double marquent la collection comme invalide au lieu d'écraser silencieusement un artefact. L'exemple vérifie cela avant d'utiliser les résultats.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.nio.charset.StandardCharsets;
import java.util.Locale;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

boolean inspectXamlText = false;
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String name = artifact.getKey().toLowerCase(Locale.ROOT);
    boolean isXaml = name.endsWith(".xaml");
    boolean isImage = name.matches(".*\\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$");
    String kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
    System.out.println(artifact.getKey() + ": " + artifact.getValue().length + " bytes (" + kind + ")");

    // Décoder uniquement le XAML, et uniquement lorsque l'inspection textuelle est nécessaire.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

Les vérifications d'extension sont utiles pour l'inspection ; conservez tous les artefacts, y compris les types de ressources inconnus. Laissez les octets inchangés lors du stockage ou de la transmission. Utilisez le [constructeur String](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) avec UTF-8 uniquement pour le XAML nécessitant un traitement textuel.

### **Regrouper les artefacts collectés dans une archive ZIP**

Cet exemple indépendant collecte l'exportation, valide ses noms et écrit les octets originaux dans une archive ZIP. Remplacez `/path/to/app/files` par le chemin renvoyé par la méthode [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) de votre contexte Android. Un nom d'archive unique sépare les tâches d'exportation simultanées. Les entrées ZIP utilisent des barres obliques et conservent les répertoires relatifs. Les noms dangereux ou ceux qui entrent en collision après normalisation rejettent l'ensemble du paquet avant son écriture.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;
import java.util.Set;
import java.util.TreeSet;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

Map<String, byte[]> entries = new LinkedHashMap<>();
Set<String> entryNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String entryName = artifact.getKey().replace('\\', '/');
    String[] segments = entryName.split("/", -1);
    boolean unsafeName = entryName.startsWith("/") || entryName.contains(":");
    for (String segment : segments) {
        unsafeName |= segment.trim().isEmpty() || segment.equals(".") || segment.equals("..");
    }

    if (unsafeName || !entryNames.add(entryName)) {
        System.err.println("Export rejected: unsafe or duplicate artifact name: " + artifact.getKey());
        return;
    }
    entries.put(entryName, artifact.getValue());
}

File exportDirectory = new File("/path/to/app/files");
try {
    File archiveFile = File.createTempFile("xaml-", ".zip", exportDirectory);
    try (FileOutputStream archiveOutput = new FileOutputStream(archiveFile); ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // Le répertoire ZIP a été finalisé en fermant avant de signaler le succès.
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

L'exemple utilise [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) pour écrire une archive locale ; l'exportateur lui‑même n'écrit pas de fichiers XAML ou image isolés. Pour le stockage à distance, remplacez l'étape d'écriture de l'archive par le téléchargement des tableaux d'octets collectés. Utilisez un identifiant de tâche d'exportation plus le nom complet de l'artefact relatif comme clé de blob, ou stockez l'identifiant de la tâche, le nom relatif et les données binaires dans une ligne de base de données. Publiez la tâche uniquement après que tous les téléchargements soient terminés ou que la transaction de base de données soit confirmée. Nettoyez la sortie partielle si la persistance échoue.

Pour les présentations volumineuses, un sauvegardeur personnalisé peut persister chaque artefact directement dans le stockage de l'application afin d'éviter de garder une copie supplémentaire de l'exportation complète en mémoire. Gardez chaque rappel synchronisé du point de vue de l'exportateur : ne retournez qu'après que la destination ait accepté les octets, et laissez les échecs remonter à l'appelant.

### **Conserver les noms des ressources et vérifier les références**

- Normalisez les séparateurs de chemin lorsque la destination l'exige, mais conservez les répertoires relatifs. N'utilisez pas uniquement [File.getName](https://developer.android.com/reference/java/io/File#getName()) sauf si chaque nom généré est connu pour être unique et que les références aux ressources restent valides.
- Appliquez une validation de nom spécifique à la destination. Lors de l'écriture de fichiers séparés, rejetez les chemins ancrés et les segments de traversée, résolvez la destination avec [File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath()), et vérifiez qu'elle reste sous le répertoire d'exportation prévu, en incluant le séparateur de répertoire dans la vérification d'appartenance. Utilisez un répertoire contrôlé par l'application sans liens symboliques pouvant rediriger les écritures.
- Utilisez un sauvegardeur et un espace de noms de stockage séparés pour chaque tâche d'exportation. Détectez les collisions après la normalisation des séparateurs et conformément aux règles de sensibilité à la casse de la destination.
- Avant de publier, analysez chaque document XAML en tant que XML et inspectez ses références de ressources basées sur des fichiers, telles que les attributs d'image `Source` ou `ImageSource`. Résolvez chaque URI relative par rapport au répertoire de l'artefact XAML contenant, normalisez le nom de stockage résultant, et confirmez que la clé de carte, l'entrée ZIP ou l'objet stocké correspondant existe. Traitez séparément les URI externes et les expressions de balisage XAML des noms de fichiers relatifs.
- Par exemple, si `pres/Slide_1.xaml` fait référence à `images/image1.png`, la ressource stockée doit être disponible sous `pres/images/image1.png`. Conserver uniquement `image1.png` casserait cette relation. Pour le stockage d'objets, conservez la même structure sous le préfixe de la tâche et rendez ces URL de ressources accessibles au consommateur XAML. Rouvrez le ZIP complété pour vérifier les noms d'entrées et les octets des ressources, et chargez des diapositives représentatives dans l'environnement XAML cible afin de confirmer que les images se résolvent correctement.

## **FAQ**

**Comment garantir des polices prévisibles si la police d'origine n'est pas disponible sur la machine ?**

Appelez [setDefaultRegularFont](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) dans [XamlOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/xamloptions/) — il est utilisé comme police de secours lors de l'exportation lorsque la police d'origine est absente. Cela ne garantit pas que le XAML généré référence la police de secours ou que la police soit disponible sur la machine cible. Assurez‑vous que les polices référencées par le XAML sont disponibles dans l'environnement où il est affiché.

**Le XAML exporté est‑il destiné uniquement à WPF, ou peut‑il être utilisé dans d'autres piles XAML également ?**

Aspose.Slides exporte du XAML WPF via son API publique. La compatibilité avec d'autres piles XAML, telles que UWP et Xamarin.Forms, n'est pas garantie. Testez le balisage généré dans votre environnement cible.

**Les diapositives masquées sont‑elles prises en charge, et comment empêcher leur exportation par défaut ?**

Par défaut, les diapositives masquées ne sont pas incluses. Vous pouvez contrôler ce comportement via [setExportHiddenSlides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) dans [XamlOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/xamloptions/) — laissez‑le désactivé si vous n’avez pas besoin de les exporter.