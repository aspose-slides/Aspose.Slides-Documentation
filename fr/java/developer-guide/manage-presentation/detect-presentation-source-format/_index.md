---
title: Déterminer le format de présentation d'origine en Java
linktitle: Format source
type: docs
weight: 35
url: /fr/java/detect-presentation-source-format/
keywords:
- format source
- détecter le format de présentation
- PowerPoint
- OpenDocument
- présentation
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Lire le format d'origine d'une présentation chargée en Java avec Aspose.Slides for Java, comparer les API de détection et gérer les fichiers, flux et formats hérités."
---
## **Vue d'ensemble**

Après avoir chargé une présentation, appelez la méthode [Presentation.getSourceFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getSourceFormat--) pour déterminer son format d'origine. La méthode est également disponible via [IPresentation.getSourceFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentation/#getSourceFormat--). Utilisez‑la lorsque le traitement ultérieur dépend du format à partir duquel l'instance actuelle a été chargée.

Le format source est distinct du [SaveFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/saveformat/) sélectionné pour un fichier de sortie. Enregistrer dans un autre format ne modifie pas le format source de l'instance existante.

## **Lire le format source d'un fichier**

Cet exemple nécessite un fichier `sample.pptx` existant. Il charge le fichier et sélectionne une politique de traitement d'application en utilisant [Presentation.getSourceFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getSourceFormat--), plutôt que le nom de fichier. Modifiez le chemin d’entrée pour essayer d’autres formats. L’exemple affiche la politique sélectionnée ; remplacez les messages par la logique de votre application.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt;
        case SourceFormat.Pps;
        case SourceFormat.Pot;
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx;
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Reconnaître les valeurs prises en charge**

La classe [SourceFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/sourceformat/) définit des constantes entières qui distinguent les formats de présentation suivants. Les extensions ci‑dessous sont des extensions conventionnelles, pas une reconstruction du nom de fichier d’origine.

| Valeur SourceFormat | Extension | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | Présentation PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Présentation Office Open XML |
| `Pptm` | `.pptm` | Présentation Office Open XML avec macros |
| `Pps` | `.pps` | Diaporama PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Diaporama Office Open XML |
| `Ppsm` | `.ppsm` | Diaporama Office Open XML avec macros |
| `Pot` | `.pot` | Modèle PowerPoint 97–2003 |
| `Potx` | `.potx` | Modèle Office Open XML |
| `Potm` | `.potm` | Modèle Office Open XML avec macros |
| `Odp` | `.odp` | Présentation OpenDocument |
| `Otp` | `.otp` | Modèle de présentation OpenDocument |
| `Fodp` | `.fodp` | Présentation ODF XML plat |
| `Xml` | `.xml` | Présentation PowerPoint XML |

## **Lire le format source d’un flux**

Cet exemple nécessite un fichier `sample.pps` existant. Lire ses octets dans un flux mémoire modélise une entrée reçue sans nom de fichier, par exemple une valeur de base de données ou un tableau d’octets téléversé. Le constructeur [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) ne reçoit que le flux.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT, PPS et POT utilisent le même format binaire sous‑jacent. Lors du chargement par chemin de fichier, l’extension peut aider à différencier un diaporama ou un modèle. Sans nom de fichier, le contenu hérité PPS et POT peut être signalé comme `SourceFormat.Ppt` ; l’exemple PPS ci‑dessus affiche la valeur entière de `SourceFormat.Ppt`.

Si votre application doit conserver cette distinction, conservez le nom de fichier d’origine ou les métadonnées de sous‑type séparément. Une extension constitue un indice utile pour ces sous‑types hérités, mais ne doit pas être le seul critère d’identification d’un contenu de présentation quelconque.

## **Comparer la détection avant et après le chargement**

Utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) et [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) lorsque vous devez inspecter un fichier avant de charger son modèle d’objet de présentation complet. Utilisez [Presentation.getSourceFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getSourceFormat--) lorsque l’instance existe déjà.

Cet exemple nécessite `sample.pptx` et affiche les valeurs entières de `LoadFormat.Pptx` et `SourceFormat.Pptx`, respectivement. En production, choisissez l’API appropriée à votre stade de traitement ; une présentation déjà chargée ne nécessite pas une seconde inspection uniquement pour obtenir son format source.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Les résultats utilisent des constantes provenant de classes différentes : [LoadFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadformat/) et [SourceFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/sourceformat/). Ne comparez pas leurs valeurs numériques et ne supposez pas que chaque format possède des résultats de détection identiques. Le XML PowerPoint peut être signalé comme `LoadFormat.Unknown` avant le chargement et `SourceFormat.Xml` après le chargement.

## **Conserver les formats source et de sortie séparés**

Cet exemple nécessite `sample.pptx` et écrit `converted.odp`. Il affiche la valeur entière de `SourceFormat.Pptx` avant et après l’enregistrement de l’instance originale. Seule la nouvelle instance chargée depuis la sortie ODP signale `Odp`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Une présentation créée à partir de zéro avec `new Presentation()` signale `SourceFormat.Pptx`. Elle n’a aucun fichier d’entrée : il s’agit de la valeur par défaut pour une instance nouvellement créée, pas d’une preuve qu’un fichier PPTX a été chargé. Suivez séparément si votre application a créé ou chargé l’instance si cette distinction importe.

## **Mapper un format source à une extension**

L’exemple suivant nécessite `sample.pptx`. Il associe chaque valeur actuellement prise en charge de [SourceFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/sourceformat/) à une extension conventionnelle, sans analyser le nom de fichier d’entrée. Le repli évite d’attribuer silencieusement une extension à une valeur non reconnue.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Ce mappage ne convertit pas un fichier ni ne récupère un sous‑type hérités PPS/POT perdu lors du chargement depuis un flux. Pour un enregistrement réel, sélectionnez explicitement un [SaveFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/saveformat/) ou utilisez la conversion présentée dans [Save Presentations in Their Original Format](/slides/fr/java/save-presentation/#save-presentations-in-their-original-format).

## **Vérifier les formats en enregistrant et en rouvrant**

Cet exemple autonome crée une présentation et écrit trois fichiers dans le répertoire de travail, en écrasant les fichiers portant les mêmes noms. Il rouvre chaque sortie à la fois par chemin et via un flux mémoire. Pour PPTX et ODP, les deux voies signalent le format enregistré. Pour PPS, le chargement par chemin signale `Pps`, tandis que le chargement des mêmes octets sans nom de fichier signale `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

Le tableau suivant résume l’identification du format source pour les présentations dont les extensions correspondent. Les noms désignent les constantes ; les exemples Java affichent leurs valeurs entières :

| Format enregistré | SourceFormat depuis un chemin de fichier | SourceFormat depuis un flux sans nom |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectivement | Identique au chemin de fichier |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectivement | Identique au chemin de fichier |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectivement | Identique au chemin de fichier |
| ODP, OTP | `Odp`, `Otp` respectivement | Identique au chemin de fichier |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Le contenu PPS/POT est identifié comme `Ppt` pour les flux sans nom. Le tableau décrit l’identification du format, pas la préservation de chaque fonctionnalité de présentation lors de la conversion.

## **FAQ**

**L’enregistrement au format ODP modifie-t‑il le format source d’une présentation chargée depuis PPTX ?**

Non. L’instance existante signale toujours `Pptx`. Une instance chargée depuis le fichier ODP enregistré signale `Odp`.

**Un flux peut‑il toujours distinguer une présentation héritée, un diaporama et un modèle ?**

Non. PPT, PPS et POT partagent le même format binaire. Conservez le nom de fichier ou les métadonnées de sous‑type séparément lorsque cette distinction est requise.

**Quelle API dois‑je utiliser si la présentation est déjà chargée ?**

Lisez [Presentation.getSourceFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getSourceFormat--). Utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) pour l’inspection avant le chargement.