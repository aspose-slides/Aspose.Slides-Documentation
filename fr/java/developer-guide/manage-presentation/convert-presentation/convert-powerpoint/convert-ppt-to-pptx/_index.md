---
title: Convertir PPT en PPTX en Java
linktitle: PPT en PPTX
type: docs
weight: 20
url: /fr/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Convertir les fichiers PPT hérités en PPTX en Java avec Aspose.Slides. Inclut des exemples Java pour la conversion d’un seul fichier et par lots, la gestion des erreurs et des notes de fidélité."
---
## **Aperçu**

PPT est le format binaire hérité de PowerPoint, tandis que PPTX est le format Open XML plus récent. Aspose.Slides for Java peut charger un fichier PPT et l’enregistrer au format PPTX sans Microsoft PowerPoint. Cet article montre comment convertir un fichier ou un répertoire de fichiers et explique ce qu’il faut vérifier après la conversion.

## **Convertir un fichier PPT en PPTX**

Chargez le fichier source avec la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) , puis appelez [Presentation.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) avec [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/java/com.aspose.slides/saveformat/#Pptx) . Le bloc `finally` libère la présentation et libère ses ressources.

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

L’extension du fichier ne sélectionne pas le format de sortie à elle seule ; c’est l’argument [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/java/com.aspose.slides/saveformat/#Pptx) qui le fait. Conservez des chemins d’entrée et de sortie différents si vous devez conserver le fichier PPT original.

## **Convertir plusieurs fichiers PPT**

L’exemple suivant convertit chaque fichier `.ppt` d’un répertoire. Chaque fichier est traité indépendamment, de sorte qu’une conversion échouée n’arrête pas le reste du lot.

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

Pour les charges de travail en production, consignez l’exception complète, décidez si un fichier de sortie existant peut être écrasé, et écrivez les noms de fichiers échoués dans une file d’attente de réessai ou de révision. Les fichiers corrompus, les fichiers protégés par mot de passe ouverts sans le mot de passe requis, les chemins inaccessibles et le contenu non pris en charge peuvent tous entraîner un échec de conversion. Voir [Présentations protégées par mot de passe](/slides/fr/java/password-protected-presentation/) pour charger des fichiers chiffrés.

## **Fidélité et fonctionnalités héritées**

La conversion préserve généralement les diapositives, les maîtres, les dispositions, le texte, les formes, les images, les tableaux et les graphiques. Cependant, PPT et PPTX ne représentent pas chaque fonctionnalité de la même manière exacte. Une fonctionnalité héritée qui n’a pas d’équivalent PPTX, ou qui n’est pas prise en charge par la bibliothèque, peut être normalisée, omise ou affichée différemment.

Vérifiez le fichier converti lorsqu’il contient des animations, des transitions, des objets OLE incorporés ou liés, des contrôles ActiveX, des médias incorporés, des polices rares ou des macros VBA. Un fichier PPTX simple n’est pas un format prenant en charge les macros, utilisez donc un flux de travail adéquat avec macros lorsque VBA doit rester disponible. Vérifiez également que les polices requises et les ressources externes sont présentes dans l’environnement où la présentation convertie sera ouverte ou rendue.

Pour les documents importants, rouvrez le PPTX généré programmatiquement et inspectez le nombre de diapositives clés et le contenu, puis comparez son apparence et le comportement du diaporama dans le visualiseur prévu. Ne considérez pas un appel [Presentation.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) réussi comme une preuve que chaque fonctionnalité héritée possède une représentation PPTX exacte.

## **Quand utiliser PPTX**

Utilisez PPTX lorsque la présentation sera éditée avec les versions récentes de PowerPoint, échangée avec des systèmes qui travaillent avec des paquets Open XML, ou stockée dans un format plus facile à inspecter et à récupérer que le PPT binaire hérité. Conservez le PPT original comme copie d’archivage ou de restauration jusqu’à ce que la présentation convertie ait réussi vos vérifications de fidélité.

Si vous avez besoin de PDF, HTML, images, XPS ou d’un autre type de sortie à la place, utilisez les directives spécifiques au format dans [Convertir des présentations en plusieurs formats](/slides/fr/java/convert-presentation/) plutôt que de supposer que toutes les cibles conservent les fonctionnalités éditables de PowerPoint.

## **Convertisseur en ligne**

Pour un fichier ponctuel ou une comparaison rapide, vous pouvez utiliser le [convertisseur en ligne PPT en PPTX](https://products.aspose.app/slides/fr/conversion/ppt-to-pptx). Pour des conversions récurrentes, un traitement par lots ou une gestion des erreurs au niveau de l’application, utilisez l’API Java.

## **Articles associés**

- [PPT vs PPTX](/slides/fr/java/ppt-vs-pptx/)
- [Enregistrer des présentations en Java](/slides/fr/java/save-presentation/)
- [Formats de fichiers pris en charge](/slides/fr/java/supported-file-formats/)
- [Ouvrir des présentations en Java](/slides/fr/java/open-presentation/)

## **FAQ**

**Puis-je convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui. Aspose.Slides for Java charge et enregistre les fichiers de présentation sans nécessiter Microsoft PowerPoint.

**La conversion PPT en PPTX préservera-t-elle tout le contenu exactement ?**

Elle préserve le contenu de présentation commun, mais la fidélité exacte n’est pas garantie pour chaque fonctionnalité héritée ou non prise en charge. Examinez le fichier généré lorsqu’il contient des macros, des objets OLE ou ActiveX, des médias, des animations spécialisées ou des polices rares.

**Puis-je convertir un fichier PPT protégé par mot de passe ?**

Oui, si vous fournissez le mot de passe correct lors du chargement du fichier. Un mot de passe manquant ou incorrect provoque l’échec de l’opération de chargement.

**Dois-je supprimer le fichier PPT après conversion ?**

Conservez l’original jusqu’à ce que vous ayez vérifié le PPTX dans les visualiseurs et les flux de travail qui vous importent. Cela fournit une copie de secours si une fonctionnalité héritée se convertit différemment.