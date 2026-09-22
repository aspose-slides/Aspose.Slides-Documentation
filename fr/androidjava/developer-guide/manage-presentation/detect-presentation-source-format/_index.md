---
title: Déterminer le format original de la présentation sur Android
linktitle: Format source
type: docs
weight: 35
url: /fr/androidjava/detect-presentation-source-format/
keywords:
- format source
- détecter le format de la présentation
- PowerPoint
- OpenDocument
- présentation
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Lire le format original d'une présentation chargée sur Android avec Aspose.Slides pour Android via Java, comparer les API de détection et gérer les fichiers, les flux et les formats hérités."
---
## **Vue d'ensemble**

Après avoir chargé une présentation, appelez la méthode [Presentation.getSourceFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getSourceFormat--) pour déterminer son format d'origine. La méthode est également disponible via [IPresentation.getSourceFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--). Utilisez‑la lorsque le traitement ultérieur dépend du format à partir duquel l'instance actuelle a été chargée.

Le format source est distinct du [SaveFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/saveformat/) sélectionné pour un fichier de sortie. Enregistrement dans un autre format ne modifie pas le format source de l'instance existante.

Les exemples utilisent Java et des chemins de fichiers. Sur Android, remplacez les chemins d'exemple par des chemins accessibles à l'application, comme le répertoire de fichiers internes de votre application.

## **Lire le format source d'un fichier**

Cet exemple nécessite un fichier `sample.pptx` existant. Il charge le fichier et sélectionne une politique de traitement d'application en utilisant [Presentation.getSourceFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getSourceFormat--), plutôt que le nom de fichier. Modifiez le chemin d'entrée pour tester d'autres formats. L'exemple affiche la politique sélectionnée ; remplacez les messages par votre logique d'application.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
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

La classe [SourceFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/sourceformat/) définit des constantes entières qui distinguent les formats de présentation suivants. Les extensions ci‑dessous sont des extensions conventionnelles, pas une reconstitution du nom de fichier d'origine.

| Valeur SourceFormat | Extension | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | présentation PowerPoint 97–2003 |
| `Pptx` | `.pptx` | présentation Office Open XML |
| `Pptm` | `.pptm` | présentation Office Open XML avec macros |
| `Pps` | `.pps` | diaporama PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | diaporama Office Open XML |
| `Ppsm` | `.ppsm` | diaporama Office Open XML avec macros |
| `Pot` | `.pot` | modèle PowerPoint 97–2003 |
| `Potx` | `.potx` | modèle Office Open XML |
| `Potm` | `.potm` | modèle Office Open XML avec macros |
| `Odp` | `.odp` | présentation OpenDocument |
| `Otp` | `.otp` | modèle de présentation OpenDocument |
| `Fodp` | `.fodp` | présentation ODF XML plat |
| `Xml` | `.xml` | présentation PowerPoint XML |

## **Lire le format source d'un flux**

Cet exemple nécessite un fichier `sample.pps` existant. Lire ses octets dans un flux mémoire modélise une entrée reçue sans nom de fichier, comme une valeur de base de données ou un tableau d'octets téléchargé. Le constructeur [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) ne reçoit que le flux.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
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

PPT, PPS et POT utilisent le même format binaire sous‑jacent. Lors du chargement par chemin de fichier, l'extension peut aider à distinguer un diaporama ou un modèle. Sans nom de fichier, le contenu PPS et POT legacy peut être signalé comme `SourceFormat.Ppt` ; l'exemple PPS ci‑dessus affiche la valeur entière de `SourceFormat.Ppt`.

Si votre application doit conserver cette distinction, conservez le nom de fichier original ou les métadonnées de sous‑type séparément. Une extension constitue un indice utile pour ces sous‑types legacy, mais ne doit pas être le seul critère d’identification d’un contenu de présentation arbitraire.

## **Comparer la détection avant et après le chargement**

Utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) et [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) lorsque vous devez inspecter un fichier avant de charger son modèle d’objet complet. Utilisez [Presentation.getSourceFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getSourceFormat--) lorsque l'instance existe déjà.

Cet exemple nécessite `sample.pptx` et affiche les valeurs entières de `LoadFormat.Pptx` et `SourceFormat.Pptx`, respectivement. En production, choisissez l’API adaptée à votre étape de traitement ; une présentation déjà chargée ne nécessite pas une seconde inspection uniquement pour obtenir son format source.

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

Les résultats utilisent des constantes de classes différentes : [LoadFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadformat/) et [SourceFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/sourceformat/). Ne comparez pas leurs valeurs numériques ni ne supposez que chaque format possède des résultats de détection identiques. PowerPoint XML peut être signalé comme `LoadFormat.Unknown` avant le chargement et comme `SourceFormat.Xml` après le chargement.

## **Conserver séparés les formats source et de sortie**

Cet exemple nécessite `sample.pptx` et écrit `converted.odp`. Il affiche la valeur entière de `SourceFormat.Pptx` avant et après l’enregistrement de l’instance originale. Seule la nouvelle instance chargée à partir de la sortie ODP signale `Odp`.

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

Une présentation créée de zéro avec `new Presentation()` signale `SourceFormat.Pptx`. Elle n’a pas de fichier d’entrée : il s’agit de la valeur par défaut d’une instance nouvellement créée, pas la preuve qu’un fichier PPTX a été chargé. Suivez séparément si votre application a créé ou chargé l’instance si cette distinction est importante.

## **Mapper un format source à une extension**

L’exemple suivant nécessite `sample.pptx`. Il associe chaque valeur [SourceFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/sourceformat/) actuellement prise en charge à une extension conventionnelle, sans analyser le nom de fichier d’entrée. Le cas de repli évite d’attribuer silencieusement une extension à une valeur non reconnue.

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

Cette correspondance ne convertit pas un fichier ni ne récupère un sous‑type PPS/POT legacy perdu lors du chargement depuis un flux. Pour un enregistrement réel, sélectionnez explicitement un [SaveFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/saveformat/) ou utilisez la conversion présentée dans [Save Presentations in Their Original Format](/slides/fr/androidjava/save-presentation/#save-presentations-in-their-original-format).

## **Vérifier les formats en enregistrant et en rouvrant**

Cet exemple autonome crée une présentation et écrit trois fichiers dans le répertoire de travail, en écrasant les fichiers portant les mêmes noms. Il rouvre chaque sortie à la fois par chemin et via un flux mémoire. Pour PPTX et ODP, les deux voies signalent le format enregistré. Pour PPS, le chargement par chemin signale `Pps`, tandis que le chargement des mêmes octets sans nom de fichier signale `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
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

Le contenu PPS/POT est identifié comme `Ppt` pour les flux sans nom. Le tableau décrit l’identification des formats, pas la préservation de chaque caractéristique de présentation lors de la conversion.

## **FAQ**

**L'enregistrement en ODP modifie-t-il le format source d'une présentation chargée depuis PPTX ?**

Non. L'instance existante indique toujours `Pptx`. Une instance chargée depuis le fichier ODP enregistré indique `Odp`.

**Un flux peut-il toujours distinguer une présentation, un diaporama et un modèle legacy ?**

Non. PPT, PPS et POT partagent le même format binaire. Conservez le nom de fichier ou les métadonnées de sous‑type séparément lorsque cette distinction est requise.

**Quelle API dois-je utiliser si la présentation est déjà chargée ?**

Lisez [Presentation.getSourceFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getSourceFormat--). Utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) pour l'inspection avant le chargement.