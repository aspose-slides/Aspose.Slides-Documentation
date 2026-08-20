---
title: Convertir PPT en PPTX sur Android
linktitle: PPT en PPTX
type: docs
weight: 20
url: /fr/androidjava/convert-ppt-to-pptx/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- PPT en PPTX
- enregistrer PPT en PPTX
- exporter PPT en PPTX
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Convertir les fichiers PPT hérité en PPTX sur Android avec Aspose.Slides. Inclut des exemples Java pour la conversion d'un seul fichier et par lots, la gestion des erreurs et des notes de fidélité."
---
## **Vue d'ensemble**

PPT est le format binaire hérité de PowerPoint, tandis que PPTX est le format Open XML plus récent. Aspose.Slides for Android via Java peut charger un fichier PPT et l’enregistrer en PPTX sans Microsoft PowerPoint. Cet article montre comment convertir un fichier ou un répertoire de fichiers et explique ce qu’il faut vérifier après la conversion.

## **Convertir un fichier PPT en PPTX**

Chargez le fichier source avec la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/), puis appelez [Presentation.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) avec [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/saveformat/#Pptx). Le bloc `finally` libère la présentation et libère ses ressources.

```java
// Charger la présentation PPT héritée.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Enregistrer la présentation au format PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L'extension du fichier ne sélectionne pas le format de sortie par elle‑même ; l'argument [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/saveformat/#Pptx) le fait. Conservez des chemins d'entrée et de sortie différents si vous devez conserver le fichier PPT original.

## **Convertir plusieurs fichiers PPT**

L'exemple suivant convertit chaque fichier `.ppt` dans un répertoire. Chaque fichier est traité indépendamment, ainsi une conversion échouée n'arrête pas le reste du lot.

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

Pour les charges de travail de production, journalisez l'exception complète, décidez si un fichier de sortie existant peut être écrasé, et enregistrez les noms des fichiers ayant échoué dans une file d'attente de réessai ou de révision. Les fichiers corrompus, les fichiers protégés par mot de passe ouverts sans le mot de passe requis, les chemins inaccessibles et le contenu non pris en charge peuvent tous provoquer un échec de conversion. Consultez [Password-Protected Presentations](/androidjava/password-protected-presentation/) pour charger les fichiers chiffrés.

## **Fidélité et fonctionnalités héritées**

La conversion conserve généralement les diapositives, les maîtres, les mises en page, le texte, les formes, les images, les tableaux et les graphiques. Cependant, PPT et PPTX ne représentent pas chaque fonctionnalité exactement de la même manière. Une fonctionnalité héritée qui n'a pas d'équivalent PPTX, ou qui n'est pas prise en charge par la bibliothèque, peut être normalisée, omise ou affichée différemment.

Vérifiez le fichier converti lorsqu'il contient des animations, des transitions, des objets OLE embarqués ou liés, des contrôles ActiveX, des médias intégrés, des polices peu communes ou des macros VBA. Un fichier PPTX ordinaire n'est pas un format activé pour les macros, utilisez donc un flux de travail approprié lorsque VBA doit rester disponible. Vérifiez également que les polices requises et les ressources externes sont présentes dans l'environnement où la présentation convertie sera ouverte ou rendue.

Pour les documents importants, rouvrez le PPTX généré de façon programmatique et inspectez le nombre de diapositives clés et le contenu, puis comparez son apparence et le comportement du diaporama dans le visualiseur prévu. Ne considérez pas qu'un appel réussi à [Presentation.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) constitue la preuve que chaque fonctionnalité héritée possède une représentation PPTX exacte.

## **Quand utiliser PPTX**

Utilisez PPTX lorsque la présentation sera éditée dans les versions actuelles de PowerPoint, échangée avec des systèmes qui travaillent avec des paquets Open XML, ou stockée dans un format plus facile à inspecter et récupérer que le PPT binaire hérité. Conservez le PPT original comme copie d'archivage ou de restauration jusqu'à ce que la présentation convertie ait passé vos contrôles de fidélité.

Si vous avez besoin de PDF, HTML, images, XPS ou d'un autre type de sortie à la place, utilisez les directives spécifiques au format dans [Convert Presentations to Multiple Formats](/androidjava/convert-presentation/) plutôt que de supposer que toutes les cibles conservent les fonctionnalités PowerPoint éditables.

## **Convertisseur en ligne**

Pour un fichier occasionnel ou une comparaison rapide, vous pouvez utiliser le [online PPT to PPTX converter](https://products.aspose.app/slides/fr/conversion/ppt-to-pptx). Pour des conversions récurrentes, un traitement par lots ou la gestion d'erreurs au niveau de l'application, utilisez l'API Android via Java.

## **Articles associés**

- [PPT vs PPTX](/androidjava/ppt-vs-pptx/)
- [Save Presentations on Android](/androidjava/save-presentation/)
- [Supported File Formats](/androidjava/supported-file-formats/)
- [Open Presentations on Android](/androidjava/open-presentation/)

## **FAQ**

**Puis-je convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui. Aspose.Slides for Android via Java charge et enregistre les fichiers de présentation sans nécessiter Microsoft PowerPoint.

**La conversion de PPT en PPTX préservera-t-elle tout le contenu exactement ?**

Elle préserve le contenu de présentation courant, mais une fidélité exacte n’est pas garantie pour chaque fonctionnalité héritée ou non prise en charge. Examinez le fichier généré lorsqu’il contient des macros, des objets OLE ou ActiveX, des médias, des animations spécialisées ou des polices peu communes.

**Puis-je convertir un fichier PPT protégé par mot de passe ?**

Oui, si vous fournissez le mot de passe correct lors du chargement du fichier. Un mot de passe manquant ou incorrect entraîne l’échec de l’opération de chargement.

**Dois-je supprimer le fichier PPT après la conversion ?**

Conservez l'original jusqu’à ce que vous ayez vérifié le PPTX dans les visualiseurs et les flux de travail qui vous importent. Cela fournit une copie de restauration si une fonctionnalité héritée se convertit différemment.