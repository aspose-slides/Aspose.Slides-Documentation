---
title: Convertir les présentations PowerPoint en Markdown avec Java
linktitle: PowerPoint en Markdown
type: docs
weight: 140
url: /fr/java/convert-powerpoint-to-markdown/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en MD
- présentation en MD
- diapositive en MD
- PPT en MD
- PPTX en MD
- enregistrer PowerPoint au format Markdown
- enregistrer la présentation au format Markdown
- enregistrer la diapositive au format Markdown
- enregistrer PPT en MD
- enregistrer PPTX en MD
- exporter PPT en MD
- exporter PPTX en MD
- exportation d'images Markdown
- liens d'images CDN
- PowerPoint
- présentation
- Markdown
- Java
- Aspose.Slides
description: "Convertissez les présentations PPT et PPTX en Markdown avec Java et contrôlez où les images bitmap, métafichier et SVG exportées sont enregistrées et référencées."
---
## **Vue d'ensemble**

Aspose.Slides for Java peut convertir des présentations PPT et PPTX en Markdown pour la documentation, les sites statiques, la migration de contenu et les flux de travail de contrôle de version. Vous pouvez choisir une variante de Markdown, contrôler la façon dont le contenu des diapositives est rendu, et décider où les images exportées sont stockées et comment le Markdown généré les référence.

Par défaut, l'exportation en Markdown utilise une sortie texte uniquement. Pour exporter du contenu visuel, définissez le type d'exportation avec la méthode [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/markdownsaveoptions/) sur la valeur `Sequential` ou `Visual` de l'énumération [MarkdownExportType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/markdownexporttype/). `Sequential` rend les éléments de diapositive séparément et dans l'ordre, tandis que `Visual` garde les éléments groupés ensemble pour préserver leur relation visuelle. La valeur `TextOnly` n'émet pas de ressources image, de sorte que les callbacks d'enregistrement d'image ne sont pas invoqués dans ce mode.

## **Convertir une présentation en Markdown**

Chargez le fichier source avec la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/), puis appelez la méthode [Presentation.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) avec la valeur `Md` de l'énumération [SaveFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/saveformat/).

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Sélectionner une variante Markdown**

La méthode [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/markdownsaveoptions/) contrôle la spécification Markdown utilisée pour la sortie. L'énumération [Flavor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/flavor/) comprend CommonMark, GitHub Flavored Markdown et d'autres variantes prises en charge.

L'exemple suivant exporte une présentation au format CommonMark :

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Exporter les images en utilisant le comportement d'enregistrement local par défaut**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/markdownsaveoptions/) fournit deux méthodes pour configurer les images enregistrées localement :

- [setBasePath](https://reference.aspose.com/slides/fr/java/com.aspose.slides/markdownsaveoptions/) spécifie le répertoire de base pour le document Markdown et ses ressources.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/fr/java/com.aspose.slides/markdownsaveoptions/) spécifie le sous‑répertoire des images. Sa valeur par défaut est `Images`.

L'exemple suivant rend le contenu visuel, écrit les images dans `output/assets` et crée des références d'image relatives dans le document Markdown :

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Ce comportement sert également de solution de secours lorsqu'un gestionnaire d'enregistrement d'image personnalisé renvoie `false`.

## **Personnaliser l'enregistrement des images et les liens Markdown**

Utilisez la méthode [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/fr/java/com.aspose.slides/markdownsaveoptions/) pour enregistrer un rappel pour les ressources bitmap et métafile non SVG émises lors de l'exportation en Markdown. Son rappel `MarkdownImageSavingHandler` reçoit l'objet [IImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/), sa valeur [ImageFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imageformat/), et le lien Markdown généré sous forme d'un tableau `String[]` à un élément. Enregistrez ou téléversez l'image avec le format fourni, et remplacez `link[0]` par la référence qui doit apparaître dans le Markdown.

Les ressources émises au format SVG sont traitées séparément. Enregistrez un rappel avec la méthode [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/fr/java/com.aspose.slides/markdownsaveoptions/). Son rappel `MarkdownSvgImageSavingHandler` reçoit un objet [ISvgImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isvgimage/) et le paramètre `String[] link` à un élément. Un SVG n'a pas d'argument `ImageFormat` ; écrivez ou téléversez ses données XML à partir de la méthode [ISvgImage.getSvgData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isvgimage/). Selon le mode d'exportation et le groupement visuel, un SVG dans la présentation source peut être rasterisé ou combiné avec d'autres contenus ; la ressource non‑SVG résultante est alors transmise au rappel d'enregistrement d'image. Enregistrez les deux rappels lorsque chaque ressource visuelle exportée nécessite un traitement personnalisé.

La valeur de retour du gestionnaire détermine qui traite l'image :

- Retournez `true` après que le gestionnaire a enregistré, téléversé, transformé ou autrement traité l'image et assigné une valeur valide à `link[0]`. Aspose.Slides écrit cette valeur dans le document Markdown et n'effectue pas son enregistrement local par défaut.
- Retournez `false` pour laisser Aspose.Slides enregistrer l'image localement et générer son lien en fonction des valeurs définies par [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/fr/java/com.aspose.slides/markdownsaveoptions/) et [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/fr/java/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Un gestionnaire qui renvoie `true` prend la responsabilité de l'image. S'il renvoie `true` sans assigner un lien valide et non vide, l'exportation échoue avec une `InvalidOperationException`.
{{% /alert %}}

### **Enregistrer les images dans un répertoire d'origine CDN et utiliser des URL externes**

L'exemple suivant considère `cdn-origin/presentations/quarterly-report` comme un répertoire d'origine CDN monté ou synchronisé. Chaque gestionnaire extrait le nom de fichier généré, enregistre l'image dans ce répertoire personnalisé, et remplace la référence locale générée par une URL CDN publique. L'exemple lui‑même n'effectue aucun téléversement réseau : l'URL devient valide seulement après que le répertoire soit monté comme origine CDN ou que ses fichiers soient publiés sur le CDN. Pour le stockage d'objets, remplacez l'écriture sur le système de fichiers par l'opération de téléversement du SDK de stockage et assignez `link[0]` seulement après que le téléversement a réussi.

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Le gestionnaire bitmap renvoie délibérément `false` pour les images plus petites que 128 × 128 pixels, ainsi Aspose.Slides enregistre ces images dans `output/fallback-images` en utilisant le comportement par défaut. Les ressources bitmap et métafile plus grandes, ainsi que les ressources SVG, sont gérées par le code personnalisé. Par exemple, une référence locale générée telle que `fallback-images/image1.png` devient `https://cdn.example.com/presentations/quarterly-report/image1.png`. Les gestionnaires utilisent les chemins du système d'exploitation uniquement lors de l'écriture des fichiers ; les liens écrits dans le Markdown utilisent des barres obliques (`/`) et des noms de fichiers encodés en URL. Appliquez la même règle lors de la création de liens relatifs : utilisez `/`, pas le séparateur de répertoire propre à la plateforme.

## **FAQ**

**Un gestionnaire peut‑il traiter à la fois les images raster et les images SVG ?**

Non. Utilisez [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/fr/java/com.aspose.slides/markdownsaveoptions/) pour les ressources bitmap et métafile émises et [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/fr/java/com.aspose.slides/markdownsaveoptions/) pour les ressources émises au format SVG. Le premier fournit un objet [IImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/) et une valeur [ImageFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imageformat/); le second fournit un objet [ISvgImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isvgimage/) dont les données SVG peuvent être lues avec [ISvgImage.getSvgData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isvgimage/). Un SVG source qui est rasterisé lors de l'exportation est traité par le rappel d'enregistrement d'image à la place.

**Que se passe‑t‑il lorsqu'un gestionnaire d'enregistrement d'image renvoie `false` ?**

Aspose.Slides utilise son comportement d'enregistrement local par défaut. L'emplacement de l'image et la référence générée sont contrôlés par les valeurs définies avec [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/fr/java/com.aspose.slides/markdownsaveoptions/) et [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/fr/java/com.aspose.slides/markdownsaveoptions/).

**Un gestionnaire peut‑il fournir une URL sans enregistrer l'image localement ?**

Oui. Le gestionnaire peut téléverser l'image vers un stockage d'objets ou la transmettre à un autre service, assigner l'URL résultante à `link[0]`, et renvoyer `true`. Le gestionnaire doit effectuer lui‑même le traitement ; retourner `true` empêche l'enregistrement local par défaut.

**Pourquoi l'exportation Markdown lève‑t‑elle une `InvalidOperationException` depuis un gestionnaire ?**

Cette exception se produit lorsque le gestionnaire renvoie `true` mais ne fournit pas de lien valide. Assignez le chemin relatif ou l'URL externe qui doit être écrit dans le Markdown avant de renvoyer `true`.

**Quel séparateur de chemin les liens d'image doivent‑ils utiliser ?**

Utilisez des barres obliques (`/`) dans les liens Markdown et les URL. Utilisez `Path.resolve` uniquement pour les chemins du système de fichiers, puis construisez ou normalisez séparément la référence Markdown.

**Les hyperliens sont‑ils conservés lors de l'exportation en Markdown ?**

Oui. Le texte [hyperlinks](/slides/fr/java/manage-hyperlinks/) est conservé sous forme de liens Markdown standard. Les [transitions](/slides/fr/java/slide-transition/) et [animations](/slides/fr/java/powerpoint-animation/) des diapositives ne sont pas convertis.

**Les présentations peuvent‑elles être converties en Markdown en parallèle ?**

Vous pouvez traiter différents fichiers de présentation en parallèle, mais ne partagez pas la même instance [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) entre les threads. Suivez les [multithreading guidelines](/slides/fr/java/multithreading/) et utilisez une instance distincte pour chaque fichier.