---
title: Sauvegarder une présentation en .NET
linktitle: Sauvegarder la présentation
type: docs
weight: 80
url: /net/save-presentation/
keywords: "Sauvegarder PowerPoint, PPT, PPTX, Sauvegarder présentation, fichier, flux, C#, Csharp, .NET"
description: "Sauvegarder une présentation PowerPoint en tant que fichier ou flux en C# ou .NET"
---

## **Sauvegarder la présentation**
L'ouverture d'une présentation décrivait comment utiliser la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) pour ouvrir une présentation. Cet article explique comment créer et sauvegarder des présentations. La classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contient le contenu d'une présentation. Que ce soit pour créer une présentation à partir de zéro ou pour modifier une présentation existante, une fois terminé, vous souhaitez sauvegarder la présentation. Avec Aspose.Slides pour .NET, elle peut être sauvegardée sous forme de **fichier** ou de **flux**. Cet article explique comment sauvegarder une présentation de différentes manières :

### **Sauvegarde de présentations dans des fichiers**
Sauvegardez une présentation dans des fichiers en appelant la méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). Il suffit de passer le nom de fichier et le format de sauvegarde à la méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index). Les exemples suivants montrent comment sauvegarder une présentation avec Aspose.Slides pour .NET en utilisant C#.

```c#
// Instancier un objet Presentation qui représente un fichier PPT
Presentation presentation= new Presentation();

//...faire un travail ici...

// Sauvegardez votre présentation dans un fichier
presentation.Save("Saved_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


### **Sauvegarde de présentations dans des flux**
Il est possible de sauvegarder une présentation dans un flux en passant un flux de sortie à la méthode Save de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). Il existe de nombreux types de flux vers lesquels une présentation peut être sauvegardée. Dans l'exemple ci-dessous, nous avons créé un nouveau fichier Presentation, ajouté du texte dans une forme et sauvegardé la présentation dans le flux.

```c#
// Instancier un objet Presentation qui représente un fichier PPT
using (Presentation presentation = new Presentation())
{

    IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // Ajouter du texte à la forme
    shape.TextFrame.Text = "Cette démonstration montre comment créer un fichier PowerPoint et le sauvegarder dans un flux.";

    FileStream toStream = new FileStream("Save_As_Stream_out.pptx", FileMode.Create);
    presentation.Save(toStream, Aspose.Slides.Export.SaveFormat.Pptx);
    toStream.Close();
}
```


### **Sauvegarde de présentations avec un type de vue prédéfini**
Aspose.Slides pour .NET offre la possibilité de définir le type de vue pour la présentation générée lorsqu'elle est ouverte dans PowerPoint via la classe [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties). La propriété [LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/lastview) est utilisée pour définir le type de vue en utilisant l'énumérateur [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype).

```csharp
using (Presentation pres = new Presentation())
{
    pres.ViewProperties.LastView = ViewType.SlideMasterView;
    pres.Save("pres-will-open-SlideMasterView.pptx", SaveFormat.Pptx);
}
```

### **Sauvegarde de présentations au format Strict Office Open XML**
Aspose.Slides vous permet de sauvegarder la présentation au format Strict Office Open XML. À cet effet, il fournit la classe [**Aspose.Slides.Export.PptxOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions) où vous pouvez définir la propriété de conformité lors de la sauvegarde du fichier de présentation. Si vous définissez sa valeur comme `Conformance.Iso29500_2008_Strict`, alors le fichier de présentation résultant sera sauvegardé au format Strict Office Open XML.

Le code d'exemple suivant crée une présentation et la sauvegarde au format Strict Office Open XML. Lors de l'appel de la méthode Save pour la présentation, l'objet **[Aspose.Slides.Export.PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions)** est passé avec la propriété **[Conformance](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/properties/conformance)** définie comme **[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/net/aspose.slides.export/conformance)**.

```csharp
   // Instancier un objet Presentation qui représente un fichier de présentation
   using (Presentation presentation = new Presentation())
   {
       // Obtenir la première diapositive
       ISlide slide = presentation.Slides[0];

       // Ajouter une autoforme de type ligne
       slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

       // Sauvegarder la présentation au format Strict Office Open XML
       presentation.Save(dataDir + "NewPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx,
           new PptxOptions() { Conformance = Conformance.Iso29500_2008_Strict });

   }

```

### **Sauvegarde de présentations au format Office Open XML en mode Zip64**
Un fichier Office Open XML est une archive ZIP ayant une limite de 4 Go (2^32 octets) sur la taille non compressée d'un fichier, la taille compressée d'un fichier et la taille totale de l'archive, ainsi qu'une limite de 65 535 (2^16-1) fichiers dans l'archive. Les extensions du format ZIP64 augmentent ces limites à 2^64.

La nouvelle propriété [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/) vous permet de choisir quand utiliser les extensions ZIP64 pour le fichier Office Open XML sauvegardé.

Cette propriété offre les modes suivants :

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/) signifie que les extensions du format ZIP64 ne seront utilisées que si la présentation dépasse les limitations ci-dessus. C'est le mode par défaut.
- [Zip64Mode.Never](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/) signifie que les extensions du format ZIP64 ne seront pas utilisées. 
- [Zip64Mode.Always](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/) signifie que les extensions du format ZIP64 seront toujours utilisées.

Le code C# suivant montre comment sauvegarder la présentation au format PPTX avec les extensions du format ZIP64 :

```c#
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-zip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}

Sauvegarder en mode Zip64Mode.Never lancera une [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) si la présentation ne peut pas être sauvegardée au format ZIP32.

{{% /alert %}}

### **Sauvegarde des mises à jour de progression en pourcentage**
Une nouvelle interface [**IProgressCallback**](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback) a été ajoutée à l'interface [**ISaveOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions) et à la classe abstraite [**SaveOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions). L'interface **IProgressCallback** représente un objet de rappel pour la sauvegarde des mises à jour de progression en pourcentage.

Les extraits de code suivants montrent comment utiliser l'interface IProgressCallback :

```c#
using (Presentation presentation = new Presentation("ConvertToPDF.pptx"))
{
    ISaveOptions saveOptions = new PdfOptions();
    saveOptions.ProgressCallback = new ExportProgressHandler();
    presentation.Save("ConvertToPDF.pdf", SaveFormat.Pdf, saveOptions);
}

```



```c#
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Utiliser le pourcentage de progression ici
        int progress = Convert.ToInt32(progressValue);
        Console.WriteLine(progress + "% fichier converti");
    }
}
```



{{% alert title="Info" color="info" %}}

En utilisant sa propre API, Aspose a développé un [outil gratuit de découpe de PowerPoint](https://products.aspose.app/slides/splitter) qui permet aux utilisateurs de diviser leurs présentations en plusieurs fichiers. Essentiellement, l'application sauvegarde les diapositives sélectionnées d'une présentation donnée en tant que nouveaux fichiers PowerPoint (PPTX ou PPT). 

{{% /alert %}}

<h2>Ouvrir et sauvegarder une présentation</h2>

<a name="csharp-open-save-presentation"><strong>Étapes : Ouvrir et sauvegarder une présentation en C#</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) avec n'importe quel format c'est-à-dire PPT, PPTX, ODP, etc.
2. Sauvegardez la _présentation_ dans n'importe quel format pris en charge par [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)

```c#
// Charger un fichier pris en charge dans Presentation par exemple ppt, pptx, odp, etc.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```