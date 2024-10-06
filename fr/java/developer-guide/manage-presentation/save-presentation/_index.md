---
title: Sauvegarder la Présentation
type: docs
weight: 80
url: /java/save-presentation/
---

## **Aperçu**
{{% alert color="primary" %}} 

[L'ouverture de la présentation](/slides/java/open-presentation/) décrit comment utiliser la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) pour ouvrir une présentation. Cet article explique comment créer et sauvegarder des présentations.

{{% /alert %}} 

La classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) contient le contenu d'une présentation. Que vous créiez une présentation à partir de zéro ou que vous en modifiiez une existante, une fois terminé, vous souhaiterez sauvegarder la présentation. Avec Aspose.Slides pour Java, elle peut être sauvegardée sous forme de **fichier** ou de **flux**. Cet article explique comment sauvegarder une présentation de différentes manières :

## **Sauvegarder la Présentation dans un Fichier**
Sauvegardez une présentation dans un fichier en appelant la méthode [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). Il suffit de passer le nom du fichier et le [**SaveFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/SaveFormat) à la méthode [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-).

Les exemples qui suivent montrent comment sauvegarder une présentation avec Aspose.Slides pour Java.

```java
// Instancier un objet Presentation représentant un fichier PPT
Presentation pres = new Presentation();
try {
    // ...faire des travaux ici...
    
    // Sauvegarder votre présentation dans un fichier
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

## **Sauvegarder la Présentation dans un Flux**
Il est possible de sauvegarder une présentation dans un flux en passant un flux de sortie à la méthode [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.io.OutputStream-int-) de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). Il existe de nombreux types de flux dans lesquels une présentation peut être sauvegardée. Dans l'exemple ci-dessous, nous avons créé un nouveau fichier de Présentation, ajouté du texte dans une forme et sauvegardé la présentation dans le flux.

```java
// Instancier un objet Presentation représentant un fichier PPT
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // Ajouter du texte à la forme
    shape.getTextFrame().setText("Cette démo montre comment créer un fichier PowerPoint et le sauvegarder dans un flux.");

    OutputStream os = new FileOutputStream("Save_As_Stream_out.pptx");

    pres.save(os, com.aspose.slides.SaveFormat.Pptx);

    os.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sauvegarder la Présentation avec un Type de Vue Prédefini**
Aspose.Slides pour Java propose une fonction permettant de définir le type de vue pour la présentation générée lorsqu'elle est ouverte dans PowerPoint via la classe [ViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties). La propriété [**setLastView**](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#setLastView-int-) est utilisée pour définir le type de vue en utilisant l'énumérateur [**ViewType**](https://reference.aspose.com/slides/java/com.aspose.slides/ViewType).

```java
// Ouverture du fichier de présentation
Presentation pres = new Presentation();
try {
    // Définir le type de vue
    pres.getViewProperties().setLastView((byte) ViewType.SlideMasterView);
    
    // Sauvegarder la présentation
    pres.save("newDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sauvegarde des Présentations au Format Strict Office Open XML**
Aspose.Slides vous permet de sauvegarder la présentation dans un format Strict Office Open XML. À cet effet, il fournit la classe [**PptxOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/pptxoptions) où vous pouvez définir la propriété Conformance lors de la sauvegarde du fichier de présentation. Si vous définissez sa valeur comme [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/java/com.aspose.slides/Conformance#Iso29500_2008_Strict), alors le fichier de présentation de sortie sera sauvegardé au format Strict Open XML.

Le code exemple suivant crée une présentation et la sauvegarde au format Strict Office Open XML. Lors de l'appel de la méthode [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) pour la présentation, l'objet [**PptxOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/pptxoptions) est passé avec la propriété Conformance définie comme [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/java/com.aspose.slides/Conformance#Iso29500_2008_Strict).

```java
// Instancier un objet Presentation représentant un fichier PPT
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter une forme auto de type ligne
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    //Définir les options de sauvegarde au format Strict Office Open XML
    PptxOptions options = new PptxOptions();
    options.setConformance(Conformance.Iso29500_2008_Strict);
    
    // Sauvegarder votre présentation dans un fichier
    pres.save("demoPass.pptx", SaveFormat.Pptx, options);
} finally {
    if (pres != null) pres.dispose();
}

```

## **Sauvegarde des Présentations au format Office Open XML en mode Zip64**

Un fichier Office Open XML est une archive ZIP qui a une limite de 4 Go (2^32 octets) sur la taille non compressée d'un fichier, la taille compressée d'un fichier et la taille totale de l'archive, ainsi qu'une limite de 65 535 (2^16-1) fichiers dans l'archive. Les extensions de format ZIP64 augmentent les limites à 2^64.

La nouvelle propriété [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/) vous permet de choisir quand utiliser les extensions de format ZIP64 pour le fichier Office Open XML sauvegardé.

Cette propriété fournit les modes suivants :

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#IfNecessary) signifie que les extensions de format ZIP64 ne seront utilisées que si la présentation dépasse les limitations énoncées. C'est le mode par défaut.
- [Zip64Mode.Never](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#Never) signifie que les extensions de format ZIP64 ne seront pas utilisées. 
- [Zip64Mode.Always](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#Always) signifie que les extensions de format ZIP64 seront toujours utilisées.

Le code suivant démontre comment sauvegarder la présentation au format PPTX avec les extensions de format ZIP64 :

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

Sauvegarder en mode Zip64Mode.Never générera une [PptxException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxexception/) si la présentation ne peut pas être sauvegardée au format ZIP32.

{{% /alert %}}

## **Sauvegarder les Mises à Jour de Progrès en Pourcentage**
Une nouvelle interface [**IProgressCallback**](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback) a été ajoutée à l'interface [**ISaveOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/ISaveOptions) et à la classe abstraite [**SaveOptions** ](https://reference.aspose.com/slides/java/com.aspose.slides/SaveOptions). L'interface [**IProgressCallback**](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback) représente un objet de rappel pour les mises à jour de progrès en pourcentage.  

Les extraits de code suivants montrent comment utiliser l'interface [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback) :

```java
// Ouverture du fichier de présentation
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
        // Utiliser la valeur de pourcentage de progrès ici
        int progress = Double.valueOf(progressValue).intValue();
        System.out.println(progress + "% fichier converti");
    }
}
```

{{% alert title="Info" color="info" %}}

En utilisant sa propre API, Aspose a développé une [application gratuite de découpage PowerPoint](https://products.aspose.app/slides/splitter) qui permet aux utilisateurs de découper leurs présentations en plusieurs fichiers. Essentiellement, l'application sauvegarde des diapositives sélectionnées d'une présentation donnée en tant que nouveaux fichiers PowerPoint (PPTX ou PPT). 

{{% /alert %}}