---
title: Enregistrer des présentations sur Android
linktitle: Enregistrer une présentation
type: docs
weight: 80
url: /fr/androidjava/save-presentation/
keywords:
- "enregistrer PowerPoint"
- "enregistrer OpenDocument"
- "enregistrer présentation"
- "enregistrer diapositive"
- "enregistrer PPT"
- "enregistrer PPTX"
- "enregistrer ODP"
- "présentation en fichier"
- "présentation en flux"
- "type de vue prédéfini"
- "Format Strict Office Open XML"
- "mode Zip64"
- "actualisation de la vignette"
- "progression d'enregistrement"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Découvrez comment enregistrer des présentations en Java avec Aspose.Slides pour Android — exportez vers PowerPoint ou OpenDocument tout en conservant la mise en page, les polices et les effets."
---
## **Aperçu**

[Open Presentations on Android](/slides/fr/androidjava/open-presentation/) décrit comment utiliser la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) pour ouvrir une présentation. Cet article explique comment créer et enregistrer des présentations. La classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) contient le contenu d’une présentation. Que vous créiez une présentation à partir de zéro ou que vous en modifiiez une existante, vous voudrez l’enregistrer une fois terminé. Avec Aspose.Slides pour Android, vous pouvez enregistrer dans un **file** ou un **stream**. Cet article décrit les différentes manières d’enregistrer une présentation.

## **Enregistrer les présentations dans des fichiers**

Enregistrez une présentation dans un fichier en appelant la méthode `save` de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/). Passez le nom du fichier et le format d’enregistrement à la méthode. L’exemple suivant montre comment enregistrer une présentation avec Aspose.Slides.

```java
import com.aspose.slides.*;

// Instanciez la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Effectuez un travail ici...

    // Enregistrez la présentation dans un fichier.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Enregistrer les présentations dans des flux**

Vous pouvez enregistrer une présentation dans un flux en transmettant un flux de sortie à la méthode `save` de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/). Une présentation peut être écrite dans de nombreux types de flux. Dans l’exemple ci‑dessous, nous créons une nouvelle présentation et l’enregistrons dans un flux de fichier.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Instanciez la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Enregistrez la présentation dans le flux.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Enregistrer les présentations avec un type de vue prédéfini**

Aspose.Slides vous permet de définir la vue initiale que PowerPoint utilise lorsque la présentation générée s’ouvre via la classe [ViewProperties](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/viewproperties/). Utilisez la méthode [setLastView](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) avec une valeur de l’énumération [ViewType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/viewtype/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Enregistrer les présentations au format Strict Office Open XML**

Aspose.Slides vous permet d’enregistrer une présentation au format Strict Office Open XML. Utilisez la classe [PptxOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pptxoptions/) et définissez sa propriété **conformance** lors de l’enregistrement. Si vous définissez [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict), le fichier de sortie est enregistré au format Strict Office Open XML.

L’exemple ci‑dessous crée une présentation et l’enregistre au format Strict Office Open XML.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Instanciez la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Enregistrez la présentation au format Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Enregistrer les présentations au format Office Open XML en mode Zip64**

Un fichier Office Open XML est une archive ZIP qui impose des limites de 4 Go (2^32 octets) sur la taille non compressée de tout fichier, la taille compressée de tout fichier et la taille totale de l’archive, ainsi qu’une limite de 65 535 (2^16‑1) fichiers. Les extensions de format ZIP64 augmentent ces limites à 2^64.

La méthode [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) vous permet de choisir quand utiliser les extensions de format ZIP64 lors de l’enregistrement d’un fichier Office Open XML.

Cette méthode peut être utilisée avec les modes suivants :

- [IfNecessary](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/zip64mode/#IfNecessary) utilise les extensions ZIP64 uniquement si la présentation dépasse les limitations ci‑dessus. C’est le mode par défaut.
- [Never](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/zip64mode/#Never) n’utilise jamais les extensions ZIP64.
- [Always](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/zip64mode/#Always) utilise toujours les extensions ZIP64.

Le code suivant montre comment enregistrer une présentation en tant que fichier PPTX avec les extensions ZIP64 activées :

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Lorsque vous enregistrez avec [Zip64Mode.Never](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/zip64mode/#Never), une [PptxException](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pptxexception/) est levée si la présentation ne peut pas être enregistrée au format ZIP32.
{{% /alert %}}

## **Enregistrer les présentations au format Office Open XML avec niveaux de compression**

Lorsque vous travaillez avec de grandes présentations, vous pouvez ajuster le niveau de compression afin d’équilibrer la taille du fichier et le temps de traitement. Selon vos besoins, vous préférez peut‑être un traitement plus rapide ou des fichiers de sortie plus petits.

Aspose.Slides fournit la méthode [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) qui vous permet de spécifier le niveau de compression utilisé lors de l’enregistrement d’une présentation au format Office Open XML.

Les niveaux de compression suivants sont disponibles :

- [**None**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compressionlevel/#None) : aucune compression n’est appliquée. Les fichiers sont conservés tels quels.
- [**Level1**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compressionlevel/#Level1) : la compression la plus rapide avec le ratio le plus faible.
- [**Level2**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compressionlevel/#Level2) : compression plus rapide avec un ratio légèrement meilleur que **Level1**.
- [**Level3**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compressionlevel/#Level3) : offre une meilleure compression que **Level2** avec un impact modéré sur le temps de traitement.
- [**Level4**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compressionlevel/#Level4) : offre une meilleure compression que **Level3**.
- [**Level5**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compressionlevel/#Level5) : améliore la compression par rapport à **Level4** avec un temps de traitement supplémentaire.
- [**Level6**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compressionlevel/#Level6) : compression standard qui offre un bon équilibre entre vitesse de traitement et taille du fichier. C’est le *niveau de compression par défaut*.
- [**Level7**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compressionlevel/#Level7) : fournit une meilleure compression que **Level6** avec un traitement plus lent.
- [**Level8**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compressionlevel/#Level8) : fournit une meilleure compression que **Level7**.
- [**Level9**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compressionlevel/#Level9) : compression maximale. Produit la plus petite taille de fichier au prix du temps de traitement le plus long.

L’exemple suivant montre comment enregistrer une présentation en tant que fichier PPTX *sans compression* :

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Cet exemple montre comment enregistrer une présentation en tant que fichier PPTX avec *la compression maximale* :

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Enregistrer les présentations sans actualiser la vignette**

La méthode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) contrôle la génération de la vignette lors de l’enregistrement d’une présentation au format PPTX :

- Si elle est définie sur `true`, la vignette est actualisée pendant l’enregistrement. C’est la valeur par défaut.
- Si elle est définie sur `false`, la vignette actuelle est conservée. Si la présentation ne possède aucune vignette, aucune n’est générée.

Dans le code ci‑dessous, la présentation est enregistrée au format PPTX sans actualiser sa vignette.

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Cette option permet de réduire le temps nécessaire pour enregistrer une présentation au format PPTX.
{{% /alert %}}

## **Enregistrer les mises à jour de progression en pourcentage**

L’interface [IProgressCallback](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iprogresscallback/) est utilisée via la méthode `setProgressCallback` exposée par l’interface [ISaveOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isaveoptions/) et la classe abstraite [SaveOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/saveoptions/). Implémentez [IProgressCallback](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iprogresscallback/) et passez‑la à `setProgressCallback` pour recevoir des mises à jour de la progression d’enregistrement en pourcentage.

Les extraits de code suivants montrent comment utiliser `IProgressCallback`.

```java
import com.aspose.slides.*;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Utilisez la valeur du pourcentage de progression ici.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose a développé une application gratuite **PowerPoint Splitter** ([https://products.aspose.app/slides/fr/splitter](https://products.aspose.app/slides/fr/splitter)) en utilisant sa propre API. L’application vous permet de diviser une présentation en plusieurs fichiers en enregistrant les diapositives sélectionnées comme nouveaux fichiers PPTX ou PPT.
{{% /alert %}}

## **FAQ**

**La « sauvegarde rapide » (sauvegarde incrémentielle) est‑elle prise en charge pour n’écrire que les changements ?**

Non. L’enregistrement crée le fichier cible complet à chaque fois ; la « sauvegarde rapide » incrémentielle n’est pas prise en charge.

**Est‑il sûr d’enregistrer la même instance de Presentation depuis plusieurs threads ?**

Non. Une [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) n’est pas thread‑safe (/slides/fr/androidjava/multithreading/) ; enregistrez‑la depuis un seul thread.

**Que se passe‑t‑il avec les hyperliens et les fichiers liés externes lors de l’enregistrement ?**

Les [Hyperlinks](/slides/fr/androidjava/manage-hyperlinks/) sont conservés. Les fichiers liés externes (par ex. : vidéos via des chemins relatifs) ne sont pas copiés automatiquement — assurez‑vous que les chemins référencés restent accessibles.

**Puis‑je définir/enregistrer les métadonnées du document (Auteur, Titre, Société, Date) ?**

Oui. Les [propriétés du document](/slides/fr/androidjava/presentation-properties/) standard sont prises en charge et seront écrites dans le fichier lors de l’enregistrement.