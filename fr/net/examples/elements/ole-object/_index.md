---
title: Objet OLE
type: docs
weight: 210
url: /fr/net/examples/elements/ole-object/
keywords:
- Objet OLE
- ajouter un objet OLE
- accéder à l'objet OLE
- supprimer l'objet OLE
- mettre à jour l'objet OLE
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Manipulez les objets OLE avec Aspose.Slides pour .NET : insérez, liez, mettez à jour et extrayez le contenu intégré en C# dans les présentations PPT, PPTX et ODP."
---
Cet article montre comment intégrer un fichier en tant qu'objet OLE et mettre à jour ses données à l'aide d'**Aspose.Slides for .NET**.

## **Add an OLE Object**
Intégrez un fichier PDF dans la présentation.

```csharp
static void AddOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);
}
```

## **Access an OLE Object**
Récupérez la première trame d'objet OLE sur une diapositive.

```csharp
static void AccessOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    var firstOleFrame = slide.Shapes.OfType<IOleObjectFrame>().First();
}
```

## **Remove an OLE Object**
Supprimez un objet OLE intégré de la diapositive.

```csharp
static void RemoveOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    slide.Shapes.Remove(oleFrame);
}
```

## **Update OLE Object Data**
Remplacez les données intégrées dans un objet OLE existant.

```csharp
static void UpdateOleObjectData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    var newData = File.ReadAllBytes("Picture.png");
    var newDataInfo = new OleEmbeddedDataInfo(newData, "png");
    oleFrame.SetEmbeddedData(newDataInfo);
}
```