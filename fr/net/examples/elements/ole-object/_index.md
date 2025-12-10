---
title: Objet OLE
type: docs
weight: 210
url: /fr/net/examples/elements/ole-object/
keywords:
- Exemple d'objet OLE
- ajouter un objet OLE
- accéder à un objet OLE
- supprimer un objet OLE
- mettre à jour un objet OLE
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Travaillez avec les objets OLE en C# avec Aspose.Slides : insérez ou mettez à jour des fichiers intégrés, définissez des icônes ou des liens, extrayez le contenu, contrôlez le comportement pour PPT, PPTX et ODP."
---

Démontre l'intégration d'un fichier en tant qu'objet OLE et la mise à jour de ses données à l'aide de **Aspose.Slides for .NET**.

## **Ajouter un objet OLE**
Intégrez un fichier PDF dans la présentation.
```csharp
static void Add_Ole_Object()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);
}
```


## **Accéder à un objet OLE**
Récupérez le premier cadre d'objet OLE d'une diapositive.
```csharp
static void Access_Ole_Object()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);

    var firstOle = slide.Shapes.OfType<IOleObjectFrame>().First();
}
```


## **Supprimer un objet OLE**
Supprimez un objet OLE intégré de la diapositive.
```csharp
static void Remove_Ole_Object()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);

    slide.Shapes.Remove(ole);
}
```


## **Mettre à jour les données d'un objet OLE**
Remplacez les données intégrées dans un objet OLE existant.
```csharp
static void Update_Ole_Object_Data()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);

    var newData = new OleEmbeddedDataInfo(File.ReadAllBytes("Picture.png"), "png");
    ole.SetEmbeddedData(newData);
}
```
