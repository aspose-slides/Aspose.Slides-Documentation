---
title: Enregistrer la présentation
type: docs
weight: 80
url: /fr/androidjava/save-presentation/
---

## **Aperçu**
{{% alert color="primary" %}} 

[L'ouverture de la présentation](/slides/fr/androidjava/open-presentation/) a décrit comment utiliser la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) pour ouvrir une présentation. Cet article explique comment créer et enregistrer des présentations.

{{% /alert %}} 

La classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) contient le contenu d'une présentation. Que vous créiez une présentation de toutes pièces ou que vous modifiiez une présentation existante, lorsque vous avez terminé, vous souhaitez enregistrer la présentation. Avec Aspose.Slides pour Android via Java, elle peut être enregistrée en tant que **fichier** ou **stream**. Cet article explique comment enregistrer une présentation de différentes manières :

## **Enregistrer la présentation dans un fichier**
Enregistrez une présentation dans un fichier en appelant la méthode [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). Passez simplement le nom du fichier et [**SaveFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SaveFormat) à la méthode [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-).

Les exemples suivants montrent comment enregistrer une présentation avec Aspose.Slides pour Android via Java.

```java
// Instancier un objet Presentation qui représente un fichier PPT
Presentation pres = new Presentation();
try {
    // ...faites ici du travail...
    
    // Enregistrer votre présentation dans un fichier
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

## **Enregistrer la présentation dans un stream**
Il est possible d'enregistrer une présentation dans un stream en passant un stream de sortie à la méthode [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.io.OutputStream-int-) de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). Il existe de nombreux types de streams dans lesquels une présentation peut être enregistrée. Dans l'exemple ci-dessous, nous avons créé un nouveau fichier de présentation, ajouté du texte dans une forme et enregistré la présentation dans le stream.

```java
// Instancier un objet Presentation qui représente un fichier PPT
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // Ajouter du texte à la forme
    shape.getTextFrame().setText("Cette démo montre comment créer un fichier PowerPoint et l'enregistrer dans un stream.");

    OutputStream os = new FileOutputStream("Save_As_Stream_out.pptx");

    pres.save(os, com.aspose.slides.SaveFormat.Pptx);

    os.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Enregistrer la présentation avec un type de vue prédéfini**
Aspose.Slides pour Android via Java fournit une fonction permettant de définir le type de vue pour la présentation générée lorsqu'elle est ouverte dans PowerPoint via la classe [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties). La propriété [**setLastView**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#setLastView-int-) est utilisée pour définir le type de vue en utilisant l'énumérateur [**ViewType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewType).

```java
// Ouvrir le fichier de présentation
Presentation pres = new Presentation();
try {
    // Définir le type de vue
    pres.getViewProperties().setLastView((byte) ViewType.SlideMasterView);
    
    // Enregistrer la présentation
    pres.save("newDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Enregistrer les présentations au format Strict Office Open XML**
Aspose.Slides vous permet d'enregistrer la présentation au format Strict Office Open XML. À cette fin, il fournit la classe [**PptxOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions) dans laquelle vous pouvez définir la propriété de conformité lors de l'enregistrement du fichier de présentation. Si vous définissez sa valeur sur [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Conformance#Iso29500_2008_Strict), alors le fichier de présentation de sortie sera enregistré au format Strict Open XML.

Le code d'exemple suivant crée une présentation et l'enregistre au format Strict Office Open XML. Lors de l'appel de la méthode [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) pour la présentation, l'objet [**PptxOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions) est passé avec la propriété de conformité définie sur [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Conformance#Iso29500_2008_Strict).

```java
// Instancier un objet Presentation qui représente un fichier PPT
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter une autoforme de type ligne
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Définir les options d'enregistrement au format Strict Office Open XML
    PptxOptions options = new PptxOptions();
    options.setConformance(Conformance.Iso29500_2008_Strict);
    
    // Enregistrer votre présentation dans un fichier
    pres.save("demoPass.pptx", SaveFormat.Pptx, options);
} finally {
    if (pres != null) pres.dispose();
}

```

## **Enregistrer les présentations au format Office Open XML en mode Zip64**

Un fichier Office Open XML est une archive ZIP qui a une limite de 4 Go (2^32 octets) sur la taille non compressée d'un fichier, la taille compressée d'un fichier, et la taille totale de l'archive, ainsi qu'une limite de 65 535 (2^16-1) fichiers dans l'archive. Les extensions de format ZIP64 augmentent ces limites à 2^64.

La nouvelle propriété [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/) vous permet de choisir quand utiliser les extensions de format ZIP64 pour le fichier Office Open XML enregistré.

Cette propriété fournit les modes suivants :

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#IfNecessary) signifie que les extensions de format ZIP64 ne seront utilisées que si la présentation dépasse les limitations ci-dessus. C'est le mode par défaut.
- [Zip64Mode.Never](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Never) signifie que les extensions de format ZIP64 ne seront pas utilisées.
- [Zip64Mode.Always](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Always) signifie que les extensions de format ZIP64 seront toujours utilisées.

Le code suivant montre comment enregistrer la présentation au format PPTX avec des extensions de format ZIP64 :

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    PptxOptions pptxOptions = new PptxOptions();
    pptxOptions.setZip64Mode(Zip64Mode.Always);
    
    pres.save("Sample-zip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}

Enregistrer en mode Zip64Mode.Never générera une [PptxException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxexception/) si la présentation ne peut pas être enregistrée au format ZIP32.

{{% /alert %}}

## **Enregistrer les mises à jour de progression en pourcentage**
Une nouvelle interface [**IProgressCallback**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProgressCallback) a été ajoutée à l'interface [**ISaveOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISaveOptions) et à la classe abstraite [**SaveOptions** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SaveOptions). L'interface [**IProgressCallback**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProgressCallback) représente un objet de rappel pour l'enregistrement des mises à jour de progression en pourcentage.  

Les extraits de code suivants montrent comment utiliser l'interface [IProgressCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProgressCallback) :

```java
// Ouvrir le fichier de présentation
Presentation pres = new Presentation("ConvertToPDF.pptx");
try {
    ISaveOptions saveOptions = new PdfOptions();
    saveOptions.setProgressCallback((IProgressCallback) new ExportProgressHandler());
    pres.save("ConvertToPDF.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    pres.dispose();
}
```
```java
class ExportProgressHandler implements IProgressCallback 
{
    public void reporting(double progressValue) 
	{
        // Utilisez la valeur de pourcentage de progression ici
        int progress = Double.valueOf(progressValue).intValue();
        System.out.println(progress + "% de fichier converti");
    }
}
```

{{% alert title="Info" color="info" %}}

En utilisant sa propre API, Aspose a développé une [application gratuite de séparation de PowerPoint](https://products.aspose.app/slides/splitter) qui permet aux utilisateurs de diviser leurs présentations en plusieurs fichiers. Essentiellement, l'application enregistre les diapositives sélectionnées d'une présentation donnée en tant que nouveaux fichiers PowerPoint (PPTX ou PPT). 

{{% /alert %}}