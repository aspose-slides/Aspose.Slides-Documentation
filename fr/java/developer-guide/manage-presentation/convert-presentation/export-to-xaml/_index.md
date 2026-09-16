---
title: Exporter des présentations en XAML avec Java
linktitle: Présentation en XAML
type: docs
weight: 30
url: /fr/java/export-to-xaml/
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
- enregistrer PPT en XAML
- enregistrer PPTX en XAML
- enregistrer ODP en XAML
- exporter PPT en XAML
- exporter PPTX en XAML
- exporter ODP en XAML
- Java
- Aspose.Slides
description: "Convertissez les diapositives PowerPoint et OpenDocument en XAML avec Java en utilisant Aspose.Slides — une solution rapide, sans Office, qui préserve votre mise en page."
---
## **Vue d'ensemble**

Cet article explique comment exporter des présentations PowerPoint vers XAML à l'aide d'Aspose.Slides. Il comprend une brève introduction à XAML, montre comment enregistrer une présentation en XAML avec les paramètres par défaut, et démontre comment personnaliser l'exportation via [XamlOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/xamloptions/), y compris l'exportation des diapositives masquées. L'article répond également à quelques questions fréquentes concernant les polices de secours, la compatibilité des piles XAML et le comportement d'exportation des diapositives masquées.

## **À propos de XAML**

XAML est un langage de balisage basé sur XML utilisé pour décrire les interfaces utilisateur dans des frameworks tels que WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin.Forms.

Vous pouvez travailler avec des fichiers XAML dans un concepteur visuel ou écrire et modifier directement le balisage.

## **Exporter des présentations vers XAML avec les options par défaut**

L'exemple Java suivant montre comment exporter une présentation en XAML avec les paramètres par défaut :

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

Par défaut, les diapositives exportées sont enregistrées dans un sous‑dossier `pres` du répertoire de travail actuel du processus, résolu à partir d'un chemin vide avec [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...). Le dossier est créé automatiquement, et toutes les images requises y sont également enregistrées.

Le nom du dossier de sortie est dérivé du nom du fichier source sans son extension. Pour `pres.pptx`, les fichiers de sortie sont nommés `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, etc. Même si vous fournissez un chemin absolu pour la présentation d'entrée, le dossier de sortie est créé relativement au répertoire de travail actuel, et non à côté du fichier d'entrée.

## **Exporter des présentations vers XAML avec des options personnalisées**

Utilisez l'interface [IXamlOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ixamloptions/) pour contrôler la façon dont Aspose.Slides exporte une présentation en XAML.

Pour enregistrer la sortie à un emplacement personnalisé, implémentez [IXamlOutputSaver](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ixamloutputsaver/) et transmettez une instance de votre implémentation à la méthode [setOutputSaver](https://reference.aspose.com/slides/fr/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) de [XamlOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/xamloptions/).

Pour inclure les diapositives masquées dans la sortie XAML, appelez [setExportHiddenSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) avec `true`, comme le montre l'exemple Java suivant :

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

Une exportation XAML peut produire un document XAML pour chaque diapositive exportée plus des images séparées et des ressources de support. Assignez un [IXamlOutputSaver](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ixamloutputsaver/) personnalisé à [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/fr/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) pour recevoir ces artefacts au lieu d'utiliser le sauvegardeur de système de fichiers par défaut. Démarrez l'exportation avec la surcharge [Presentation.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) spécifique à XAML qui accepte les options XAML.

### **Comprendre le cycle de vie du rappel**

L'exportateur appelle [IXamlOutputSaver.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) séparément pour chaque artefact généré :

- `path` identifie l'artefact et peut inclure des répertoires relatifs. Conservez cette information car XAML peut faire référence à des ressources en utilisant des chemins relatifs.
- `data` contient les octets de l'artefact. Les images et autres ressources binaires ne doivent pas être décodées en texte.
- Le sauvegardeur est responsable de conserver ou de persister les données avant de retourner. Les exemples copient chaque tableau d'octets dans la mémoire appartenant à l'application.
- Considérez l'exportation comme réussie uniquement lorsque l'opération d'enregistrement de la présentation renvoie et que chaque rappel s'est terminé avec succès. N'ignorez pas les erreurs de stockage ni ne lancez des écritures en arrière‑plan non observées. Si la persistance se produit ultérieurement, ne signalez le succès global qu'après que cette étape réussisse également.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) s'applique également à un sauvegardeur personnalisé. Le paramètre par défaut, `false`, exclut les documents XAML des diapositives masquées. Passer `true` les inclut ainsi que toutes les ressources nécessaires à leur exportation. Le nombre de ressources dépend de la présentation ; ne supposez pas un rappel par diapositive ou un ordre de rappel fixe.

### **Exporter en mémoire et inspecter les artefacts**

Cet exemple complet charge `pres.pptx`, collecte chaque artefact dans un [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) et affiche son nom, son type et le nombre d'octets. Il préserve exactement les noms fournis. Les noms en double marquent la collection comme invalide au lieu d'écraser silencieusement un artefact. L'exemple vérifie cela avant d'utiliser les résultats.

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

    // Décoder uniquement le XAML, et seulement lorsque l'inspection textuelle est nécessaire.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

Les vérifications d'extension sont utiles pour l'inspection ; conservez tous les artefacts, y compris les types de ressources inconnus. Laissez les octets inchangés lors du stockage ou de la transmission. Utilisez le constructeur [String](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) avec UTF-8 uniquement pour le XAML qui nécessite un traitement textuel.

### **Empaqueter les artefacts collectés dans une archive ZIP**

Cet exemple indépendant collecte l'exportation, valide ses noms et écrit les octets originaux dans une archive ZIP. Un nom d'archive unique sépare les tâches d'exportation simultanées. Les entrées ZIP utilisent des barres obliques et conservent les répertoires relatifs. Les noms dangereux ou les collisions après normalisation rejettent l'ensemble du paquet avant son écriture.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.Set;
import java.util.TreeSet;
import java.util.UUID;
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

Path archivePath = Paths.get("xaml-" + UUID.randomUUID() + ".zip");
try {
    OutputStream output = Files.newOutputStream(archivePath, StandardOpenOption.CREATE_NEW, StandardOpenOption.WRITE);
    try (OutputStream archiveOutput = output; ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // Le répertoire ZIP a été finalisé par la fermeture avant de signaler le succès.
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

L'exemple utilise [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) pour écrire une archive locale ; l'exportateur lui‑même n'écrit pas de fichiers XAML ou d'images isolés. Pour un stockage distant, remplacez l'étape d'écriture d'archive par des téléchargements des tableaux d'octets collectés. Utilisez un identifiant de tâche d'exportation plus le nom complet de l'artefact relatif comme clé de blob, ou stockez l'identifiant de tâche, le nom relatif et les données binaires dans une ligne de base de données. Publiez la tâche uniquement après que tous les téléchargements soient terminés ou que la transaction de base de données soit validée. Nettoyez la sortie partielle si la persistance échoue.

Pour les présentations volumineuses, un sauvegardeur personnalisé peut persister chaque artefact directement dans le stockage de l'application afin d'éviter de conserver une copie supplémentaire de l'ensemble de l'exportation en mémoire. Gardez chaque rappel synchrone du point de vue de l'exportateur : retournez uniquement après que la destination ait accepté les octets, et laissez les échecs remonter à l'appelant.

### **Conserver les noms de ressources et vérifier les références**

- Normalisez les séparateurs de chemin lorsque la destination l'exige, mais conservez les répertoires relatifs. N'utilisez pas uniquement [Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--) sauf si chaque nom généré est connu pour être unique et que les références aux ressources restent valides.
- Appliquez une validation des noms propre à la destination. Lors de l'écriture de fichiers isolés, rejetez les chemins absolus et les segments de traversal, résolvez la destination avec [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--), et vérifiez qu'elle reste en dessous du répertoire d'exportation prévu, en incluant le séparateur de répertoire dans la vérification de contenance. Utilisez un répertoire contrôlé par l'application sans liens symboliques pouvant rediriger les écritures.
- Utilisez un sauvegardeur et un espace de noms de stockage distincts pour chaque tâche d'exportation. Détectez les collisions après normalisation des séparateurs et selon les règles de sensibilité à la casse de la destination.
- Avant la publication, analysez chaque document XAML comme XML et inspectez ses références de ressources basées sur des fichiers, telles que les attributs `Source` ou `ImageSource` des images. Résolvez chaque URI relative par rapport au répertoire de l'artefact XAML contenant, normalisez le nom de stockage résultant, et confirmez que la clé de carte correspondante, l'entrée ZIP ou l'objet stocké existe. Traitez séparément les URI externes et les expressions de balisage XAML des noms de fichiers relatifs.

Par exemple, si `pres/Slide_1.xaml` référence `images/image1.png`, la ressource stockée doit être disponible sous `pres/images/image1.png`. Conserver uniquement `image1.png` rompt cette relation. Pour le stockage d'objets, préservez la même structure sous le préfixe de tâche et rendez ces URL de ressources accessibles au consommateur XAML. Rouvrez le ZIP complet pour vérifier les noms d'entrée et les octets des ressources, et chargez des diapositives représentatives dans l'environnement XAML cible afin de confirmer que les images se résolvent correctement.

## **FAQ**

**Comment garantir des polices prévisibles si la police d'origine n'est pas disponible sur la machine ?**

Appelez [setDefaultRegularFont](https://reference.aspose.com/slides/fr/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) dans [XamlOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/xamloptions/) — elle est utilisée comme police de secours pendant l'exportation lorsque l'originale est manquante. Cela ne garantit pas que le XAML généré référence la police de secours ou que la police soit disponible sur la machine cible. Assurez‑vous que les polices référencées par le XAML soient disponibles dans l'environnement où il est affiché.

**Le XAML exporté est‑il destiné uniquement à WPF, ou peut‑il être utilisé dans d'autres piles XAML également ?**

Aspose.Slides exporte du XAML WPF via son API publique. La compatibilité avec d'autres piles XAML, telles que UWP et Xamarin.Forms, n'est pas garantie. Testez le balisage généré dans votre environnement cible.

**Les diapositives masquées sont‑elles prises en charge, et comment les empêcher d'être exportées par défaut ?**

Par défaut, les diapositives masquées ne sont pas incluses. Vous pouvez contrôler ce comportement via [setExportHiddenSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) dans [XamlOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/xamloptions/) — laissez‑le désactivé si vous n'avez pas besoin de les exporter.