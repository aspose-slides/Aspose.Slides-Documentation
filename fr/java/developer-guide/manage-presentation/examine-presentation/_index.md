---
title: Récupérer et mettre à jour les informations de présentation en Java
linktitle: Informations sur la présentation
type: docs
weight: 30
url: /fr/java/examine-presentation/
keywords:
- format de présentation
- propriétés de présentation
- propriétés du document
- obtenir des propriétés
- lire des propriétés
- changer des propriétés
- modifier des propriétés
- mettre à jour des propriétés
- examiner PPTX
- examiner PPT
- examiner ODP
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Explorez les diapositives, la structure et les métadonnées des présentations PowerPoint et OpenDocument en Java pour des analyses plus rapides et des audits de contenu plus intelligents."
---
## **Vue d'ensemble**

Aspose.Slides peut identifier le format d’une présentation et lire ses métadonnées de document sans créer un modèle d’objet de présentation complet. Cela est utile lorsque vous devez classer des fichiers, établir un inventaire ou inspecter des propriétés avant de décider de charger et de traiter le contenu de la présentation.

Cet article montre l’inspection légère via [PresentationFactory](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationfactory/) et [IPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationinfo/), ainsi que les mises à jour ciblées via [IDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties/).

## **Vérifier le format d’une présentation**

Utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) pour inspecter un fichier sans créer une instance de [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/). La méthode [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) indique le format détecté, tel que PPTX, PPT ou ODP.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **Construire un inventaire léger de présentations**

Lorsque vous traitez de nombreux fichiers de présentation, vous pouvez avoir besoin d’un inventaire compact pour la validation, l’indexation ou un système de gestion de documents. Dans ce scénario, utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) pour obtenir un objet [IPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationinfo/), puis appelez [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) pour lire les métadonnées du document. Cette approche ne crée pas d’instance de [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) et ne nécessite pas de parcourir le modèle d’objet complet de la présentation.

Les propriétés étendues exposées par [IDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties/) fournissent les valeurs d’inventaire suivantes :

| Méthode | Valeur d'inventaire |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties/#getSlides--) | Nombre total de diapositives. |
| [getHiddenSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Nombre de diapositives masquées. |
| [getNotes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties/#getNotes--) | Nombre de diapositives contenant des notes. |
| [getParagraphs](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | Nombre total de paragraphes, lorsqu’il est disponible. |
| [getWords](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties/#getWords--) | Nombre total de mots. |
| [getMultimediaClips](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Nombre total de clips audio et vidéo. |

L’exemple suivant lit ces valeurs sans créer d’objet [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) et affiche un inventaire compact. Il combine également [getHeadingPairs](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) avec [getTitlesOfParts](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) pour afficher les groupes de contenu tels que les polices, les thèmes et les titres de diapositives.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

Chaque [IHeadingPair](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iheadingpair/) fournit un nom de groupe et le nombre d’éléments dans ce groupe. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) renvoie un tableau plat et ordonné, il faut donc consommer le nombre de titres consécutifs indiqué par chaque paire d’en-tête.

### **Métadonnées stockées et limites de format**

Les propriétés d’inventaire retournées par [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) reflètent les métadonnées disponibles dans le document source. Aspose.Slides ne charge pas et ne parcourt pas le modèle d’objet de la présentation pour recalculer ces valeurs lors de cet appel. Les propriétés manquantes sont représentées par des valeurs par défaut, et les valeurs stockées peuvent être périmées si l’application qui a enregistré le fichier en dernier n’a pas mis à jour ses propriétés de document.

- **PPTX :** Le format fournit des propriétés de document étendues pour le nombre de diapositives, de notes, de diapositives masquées, de paragraphes, de mots et de fichiers multimédia, ainsi que les paires d’en‑tête et les titres de parties. Leur disponibilité dépend des propriétés écrites par le producteur du document.
- **PPT :** Le format binaire peut stocker les propriétés de résumé de document correspondantes. Si une propriété est absente ou n’a pas été rafraîchie par le producteur du document, Aspose.Slides renvoie sa valeur stockée ou par défaut plutôt que de la calculer à partir des diapositives.
- **ODP :** Les métadonnées OpenDocument fournissent des statistiques générales du document, telles que le nombre de pages, de paragraphes et de mots, mais ces valeurs ne correspondent pas à chaque propriété étendue spécifique à PowerPoint. Les métadonnées de diapositives masquées, de notes, de multimédia, de paires d’en‑tête et de titres de parties peuvent être indisponibles, et les propriétés d’inventaire peuvent renvoyer des valeurs par défaut. Ne considérez pas une valeur zéro ou un tableau vide comme une preuve définitive de l’absence du contenu correspondant.

Utilisez l’approche de métadonnées légères pour les inventaires et les vérifications préliminaires. Chargez la présentation et inspectez son modèle d’objet en mémoire lorsque le résultat doit refléter les modifications en cours ou lorsque vous devez vérifier le contenu réel de la présentation.

## **Mettre à jour les propriétés d’une présentation**

Les propriétés retournées par [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) peuvent également être modifiées sans créer d’instance de [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/). Appliquez les changements avec [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), puis écrivez la présentation liée avec [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

L’image suivante montre les propriétés de document d’origine.

![Original document properties of the PowerPoint presentation](input_properties.png)

L’exemple suivant modifie le titre et la date de la dernière sauvegarde et écrit le résultat dans un nouveau fichier :

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

L’image suivante montre les propriétés de document mises à jour.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Liens utiles**

Pour les contrôles de sécurité associés et les paramètres de protection, consultez les articles suivants :

- [Password-Protect Presentations](/slides/fr/java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/fr/java/write-protected-presentation/)

## **FAQ**

**Comment vérifier si les polices sont incorporées et lesquelles ?**

Chargez la présentation et utilisez [Presentation.getFontsManager](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getFontsManager--). Appelez [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) pour obtenir les polices incorporées et [IFontsManager.getFonts](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifontsmanager/#getFonts--) pour obtenir les polices utilisées par la présentation. Comparez les deux résultats pour identifier les polices requises pour le rendu mais non incorporées.

**Comment déterminer rapidement si le fichier possède des diapositives masquées et combien ?**

Lorsque les métadonnées stockées du document sont suffisantes, lisez [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) via [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) et [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). Cela convient à un inventaire léger. Si la présentation a été modifiée en mémoire, les métadonnées stockées peuvent être manquantes ou périmées, ou si vous devez vérifier les valeurs en direct, parcourez [Presentation.getSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getSlides--) et inspectez la méthode [ISlide.getHidden](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islide/#getHidden--) de chaque diapositive.

**Puis-je détecter si une taille de diapositive personnalisée et une orientation sont utilisées, et si elles diffèrent des valeurs par défaut ?**

Oui. Chargez la présentation et appelez [Presentation.getSlideSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getSlideSize--). Utilisez [ISlideSize.getType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidesize/#getSize--) et [ISlideSize.getOrientation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidesize/#getOrientation--) pour comparer les paramètres actuels avec les valeurs prédéfinies attendues.

**Existe‑t‑il un moyen rapide de voir si les graphiques référencent des sources de données externes ?**

Oui. Localisez chaque [Chart](https://reference.aspose.com/slides/fr/java/com.aspose.slides/chart/) et appelez [IChartData.getDataSourceType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ichartdata/#getDataSourceType--). Pour un classeur externe, appelez [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). Le type de source de données et le chemin identifient une référence externe, mais la vérification de la disponibilité de la cible nécessite un contrôle de ressource séparé.

**Comment évaluer les diapositives « lourdes » qui pourraient ralentir le rendu ou l’export PDF ?**

Il n’existe pas de propriété unique de complexité. Parcourez [Presentation.getSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getSlides--) et la collection [IBaseSlide.getShapes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseslide/#getShapes--) de chaque diapositive. Utilisez le nombre de formes et la présence d’images volumineuses, d’effets, d’animations ou de fichiers multimédia comme indicateurs de filtrage, et mesurez un rendu ou une exportation représentative avant de considérer une diapositive comme un goulot d’étranglement confirmé.