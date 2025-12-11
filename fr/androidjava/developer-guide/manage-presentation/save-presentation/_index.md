---
title: Enregistrer des présentations sur Android
linktitle: Enregistrer la présentation
type: docs
weight: 80
url: /fr/androidjava/save-presentation/
keywords:
- enregistrer PowerPoint
- enregistrer OpenDocument
- enregistrer présentation
- enregistrer diapositive
- enregistrer PPT
- enregistrer PPTX
- enregistrer ODP
- présentation vers fichier
- présentation vers flux
- type de vue prédéfini
- Format Office Open XML strict
- mode Zip64
- rafraîchissement de la miniature
- progression de l'enregistrement
- Android
- Java
- Aspose.Slides
description: "Découvrez comment enregistrer des présentations en Java avec Aspose.Slides pour Android — exportez vers PowerPoint ou OpenDocument tout en conservant les mises en page, les polices et les effets."
---

## **Vue d'ensemble**

[Présentations ouvertes sur Android](/slides/fr/androidjava/open-presentation/) décrit comment utiliser la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) pour ouvrir une présentation. Cet article explique comment créer et enregistrer des présentations. La classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) contient le contenu d’une présentation. Que vous créiez une présentation à partir de zéro ou que vous modifiiez une présentation existante, vous voudrez l’enregistrer une fois terminé. Avec Aspose.Slides pour Android, vous pouvez enregistrer dans un **fichier** ou un **flux**. Cet article explique les différentes manières d’enregistrer une présentation.

## **Enregistrer des présentations dans des fichiers**

Enregistrez une présentation dans un fichier en appelant la méthode `save` de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Passez le nom de fichier et le format d’enregistrement à la méthode. L’exemple suivant montre comment enregistrer une présentation avec Aspose.Slides.
```java
// Instancier la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Effectuer du travail ici...

    // Enregistrer la présentation dans un fichier.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Enregistrer des présentations dans des flux**

Vous pouvez enregistrer une présentation dans un flux en transmettant un flux de sortie à la méthode `save` de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Une présentation peut être écrite dans de nombreux types de flux. Dans l’exemple ci‑dessous, nous créons une nouvelle présentation et l’enregistrons dans un flux de fichier.
```java
// Instancier la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Enregistrer la présentation dans le flux.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```


## **Enregistrer des présentations avec un type de vue prédéfini**

Aspose.Slides vous permet de définir la vue initiale que PowerPoint utilise lorsque la présentation générée s’ouvre via la classe [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/). Utilisez la méthode [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) avec une valeur de l’énumération [ViewType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/).
```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Enregistrer des présentations au format Strict Office Open XML**

Aspose.Slides vous permet d’enregistrer une présentation au format Strict Office Open XML. Utilisez la classe [PptxOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions/) et définissez sa propriété `conformance` lors de l’enregistrement. Si vous définissez [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict), le fichier de sortie est enregistré au format Strict Office Open XML.

L’exemple ci‑dessous crée une présentation et l’enregistre au format Strict Office Open XML.
```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Instancier la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Enregistrer la présentation au format Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```


## **Enregistrer des présentations au format Office Open XML en mode Zip64**

Un fichier Office Open XML est une archive ZIP qui impose des limites de 4 Go (2^32 octets) sur la taille non compressée de chaque fichier, la taille compressée de chaque fichier et la taille totale de l’archive, ainsi qu’une limite de 65 535 (2^16‑1) fichiers. Les extensions du format ZIP64 augmentent ces limites à 2^64.

La méthode [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) vous permet de choisir quand utiliser les extensions du format ZIP64 lors de l’enregistrement d’un fichier Office Open XML.

Cette méthode peut être utilisée avec les modes suivants :

- [IfNecessary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#IfNecessary) utilise les extensions ZIP64 uniquement si la présentation dépasse les limitations ci‑dessus. C’est le mode par défaut.
- [Never](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Never) n’utilise jamais les extensions ZIP64.
- [Always](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Always) utilise toujours les extensions ZIP64.

Le code suivant montre comment enregistrer une présentation en PPTX avec les extensions ZIP64 activées :
```java
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
Lorsque vous enregistrez avec [Zip64Mode.Never](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Never), une [PptxException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxexception/) est levée si la présentation ne peut pas être enregistrée au format ZIP32.
{{% /alert %}}

## **Enregistrer des présentations sans rafraîchir la miniature**

La méthode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) contrôle la génération de la miniature lors de l’enregistrement d’une présentation au format PPTX :

- Si la valeur est `true`, la miniature est rafraîchie pendant l’enregistrement. C’est le mode par défaut.
- Si la valeur est `false`, la miniature actuelle est conservée. Si la présentation n’a aucune miniature, aucune n’est générée.

Dans le code ci‑dessous, la présentation est enregistrée en PPTX sans rafraîchir sa miniature.
```java
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
Cette option permet de réduire le temps nécessaire à l’enregistrement d’une présentation au format PPTX.
{{% /alert %}}

## **Mises à jour de progression d’enregistrement en pourcentage**

L’interface [IProgressCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprogresscallback/) est utilisée via la méthode `setProgressCallback` exposée par l’interface [ISaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isaveoptions/) et la classe abstraite [SaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/). Implémentez [IProgressCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprogresscallback/) et transmettez‑lui `setProgressCallback` pour recevoir les mises à jour de progression d’enregistrement sous forme de pourcentage.

Les extraits de code suivants montrent comment utiliser `IProgressCallback`.
```java
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
class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Utilisez la valeur du pourcentage de progression ici.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```


{{% alert title="Info" color="info" %}}
Aspose a développé une [application gratuite PowerPoint Splitter](https://products.aspose.app/slides/splitter) utilisant sa propre API. L’application vous permet de diviser une présentation en plusieurs fichiers en enregistrant les diapositives sélectionnées en tant que nouveaux fichiers PPTX ou PPT.
{{% /alert %}}

## **FAQ**

**La « sauvegarde rapide » (sauvegarde incrémentielle) est‑elle prise en charge afin que seules les modifications soient écrites ?**

Non. La sauvegarde crée le fichier cible complet à chaque fois ; la « sauvegarde rapide » incrémentielle n’est pas prise en charge.

**Est‑il sûr d’enregistrer la même instance de Presentation depuis plusieurs threads ?**

Non. Une instance de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) n’est pas thread‑safe ; enregistrez‑la depuis un seul thread.

**Que se passe‑t‑il avec les hyperliens et les fichiers liés extérieurement lors de l’enregistrement ?**

Les [hyperliens](/slides/fr/androidjava/manage-hyperlinks/) sont conservés. Les fichiers liés extérieurement (par ex. des vidéos via des chemins relatifs) ne sont pas copiés automatiquement ; assurez‑vous que les chemins référencés restent accessibles.

**Puis‑je définir/enregistrer les métadonnées du document (Auteur, Titre, Société, Date) ?**

Oui. Les [propriétés du document](/slides/fr/androidjava/presentation-properties/) standard sont prises en charge et seront écrites dans le fichier lors de l’enregistrement.