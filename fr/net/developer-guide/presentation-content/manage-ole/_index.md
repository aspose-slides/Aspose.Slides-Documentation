---
title: Gérer les objets OLE dans les présentations en .NET
linktitle: Gérer OLE
type: docs
weight: 40
url: /fr/net/manage-ole/
keywords:
- objet OLE
- liaison et incorporation d'objets
- ajouter OLE
- intégrer OLE
- ajouter objet
- intégrer objet
- ajouter fichier
- intégrer fichier
- objet lié
- fichier lié
- modifier OLE
- icône OLE
- titre OLE
- extraire OLE
- extraire objet
- extraire fichier
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Optimisez la gestion des objets OLE dans les fichiers PowerPoint et OpenDocument avec Aspose.Slides for .NET. Intégrez, mettez à jour et exportez le contenu OLE de manière fluide."
---

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) est une technologie Microsoft qui permet aux données et aux objets créés dans une application d'être placés dans une autre application via le lien ou l'incorporation. 

{{% /alert %}} 

Considérez un graphique créé dans MS Excel. Le graphique est ensuite placé dans une diapositive PowerPoint. Ce graphique Excel est considéré comme un objet OLE. 

- Un objet OLE peut apparaître sous forme d'icône. Dans ce cas, lorsque vous double-cliquez sur l'icône, le graphique s'ouvre dans son application associée (Excel), ou on vous demande de sélectionner une application pour ouvrir ou éditer l'objet. 
- Un objet OLE peut afficher son contenu réel, comme le contenu d'un graphique. Dans ce cas, le graphique est activé dans PowerPoint, l'interface du graphique se charge, et vous pouvez modifier les données du graphique directement dans PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) vous permet d'insérer des objets OLE dans les diapositives sous forme de cadres d'objets OLE ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **Ajout de cadres d'objets OLE aux diapositives**

En supposant que vous avez déjà créé un graphique dans Microsoft Excel et que vous souhaitez l'incorporer dans une diapositive sous forme de cadre d'objet OLE à l'aide d'Aspose.Slides for .NET, vous pouvez procéder ainsi :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez la référence d'une diapositive via son indice.
3. Lisez le fichier Excel sous forme de tableau d'octets.
4. Ajoutez le [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) à la diapositive en incluant le tableau d'octets et les autres informations relatives à l'objet OLE.
5. Enregistrez la présentation modifiée au format PPTX.

Dans l'exemple ci-dessous, nous avons ajouté un graphique à partir d'un fichier Excel à une diapositive sous forme de [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) à l'aide d'Aspose.Slides for .NET.  
**Remarque** que le constructeur [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) accepte une extension d'objet incorporable comme second paramètre. Cette extension permet à PowerPoint d'interpréter correctement le type de fichier et de choisir la bonne application pour ouvrir cet objet OLE.
```csharp 
using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Préparer les données pour l'objet OLE.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Ajouter le cadre d'objet OLE à la diapositive.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


### **Ajout de cadres d'objets OLE liés**

Aspose.Slides for .NET vous permet d'ajouter un [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) sans incorporer les données, mais uniquement avec un lien vers le fichier.

Ce code C# vous montre comment ajouter un [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) avec un fichier Excel lié à une diapositive :
```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ajouter un cadre d'objet OLE avec un fichier Excel lié.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Accès aux cadres d'objets OLE**

Si un objet OLE est déjà incorporé dans une diapositive, vous pouvez facilement le trouver ou y accéder de cette manière :

1. Chargez une présentation contenant l'objet OLE incorporé en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez la référence de la diapositive en utilisant son indice.
3. Accédez à la forme [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). Dans notre exemple, nous avons utilisé le PPTX créé précédemment qui ne possède qu'une seule forme sur la première diapositive. Nous avons ensuite *casté* cet objet en tant que [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). C'était le cadre d'objet OLE souhaité à accéder.
4. Une fois le cadre d'objet OLE accédé, vous pouvez effectuer toute opération dessus.

Dans l'exemple ci-dessous, un cadre d'objet OLE (un objet graphique Excel incorporé dans une diapositive) et ses données de fichier sont accédés.
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtenir la première forme en tant que cadre d'objet OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Obtenir les données du fichier incorporé.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Obtenir l'extension du fichier incorporé.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```


### **Accès aux propriétés du cadre d'objet OLE lié**

Aspose.Slides vous permet d'accéder aux propriétés du cadre d'objet OLE lié.

Ce code C# vous montre comment vérifier si un objet OLE est lié puis obtenir le chemin du fichier lié :
```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Obtenir la première forme en tant que cadre d'objet OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Vérifier si l'objet OLE est lié.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Afficher le chemin complet du fichier lié.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Afficher le chemin relatif du fichier lié s'il est présent.
        // Seules les présentations PPT peuvent contenir le chemin relatif.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```


## **Modification des données d'un objet OLE**

{{% alert color="primary" %}} 

Dans cette section, l'exemple de code ci‑dessous utilise [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

Si un objet OLE est déjà incorporé dans une diapositive, vous pouvez accéder à cet objet et modifier ses données de cette façon :

1. Chargez une présentation contenant l'objet OLE incorporé en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez la référence de la diapositive via son indice. 
3. Accédez à la forme [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). Dans notre exemple, nous avons utilisé le PPTX créé précédemment qui possède une forme sur la première diapositive. Nous avons ensuite *casté* cet objet en tant que [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). C'était le cadre d'objet OLE souhaité à accéder.
4. Une fois le cadre d'objet OLE accédé, vous pouvez effectuer toute opération dessus.
5. Créez un objet `Workbook` et accédez aux données OLE.
6. Accédez à la `Worksheet` souhaitée et modifiez les données.
7. Enregistrez le `Workbook` mis à jour dans un flux.
8. Changez les données de l'objet OLE à partir du flux.

Dans l'exemple ci-dessous, un cadre d'objet OLE (un objet graphique Excel incorporé dans une diapositive) est accédé, et ses données de fichier sont modifiées pour mettre à jour les données du graphique.
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtenir la première forme en tant que cadre d'objet OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Lire les données de l'objet OLE en tant qu'objet Workbook.
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Modifier les données du classeur.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Modifier les données de l'objet du cadre OLE.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Incorporation d'autres types de fichiers dans les diapositives**

En plus des graphiques Excel, Aspose.Slides for .NET vous permet d'incorporer d'autres types de fichiers dans les diapositives. Par exemple, vous pouvez insérer des fichiers HTML, PDF et ZIP en tant qu'objets. Lorsqu'un utilisateur double-clique sur l'objet inséré, il s'ouvre automatiquement dans le programme approprié, ou l'utilisateur est invité à sélectionner un programme adéquat pour l'ouvrir.

Ce code C# vous montre comment incorporer du HTML et du ZIP dans une diapositive :
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Définition des types de fichiers pour les objets incorporés**

Lorsque vous travaillez avec des présentations, il peut être nécessaire de remplacer d'anciens objets OLE par de nouveaux ou de remplacer un objet OLE non pris en charge par un objet pris en charge. Aspose.Slides for .NET vous permet de définir le type de fichier d'un objet incorporé, ce qui vous permet de mettre à jour les données du cadre OLE ou son extension.

Ce code C# vous montre comment définir le type de fichier d'un objet OLE incorporé sur `zip` :
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // Modifier le type de fichier en ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Définition des images d'icône et des titres pour les objets incorporés**

Après avoir incorporé un objet OLE, un aperçu composé d'une image d'icône est ajouté automatiquement. Cet aperçu est ce que les utilisateurs voient avant d'accéder ou d'ouvrir l'objet OLE. Si vous souhaitez utiliser une image et un texte spécifiques comme éléments de l'aperçu, vous pouvez définir l'image d'icône et le titre à l'aide d'Aspose.Slides for .NET.

Ce code C# vous montre comment définir l'image d'icône et le titre pour un objet incorporé : 
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Ajouter une image aux ressources de la présentation.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Définir un titre et l'image pour l'aperçu OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Empêcher le redimensionnement et le repositionnement d'un cadre d'objet OLE**

Après avoir ajouté un objet OLE lié à une diapositive de présentation, lorsque vous ouvrez la présentation dans PowerPoint, il se peut qu'un message vous invite à mettre à jour les liens. Cliquer sur le bouton "Update Links" peut modifier la taille et la position du cadre d'objet OLE parce que PowerPoint met à jour les données de l'objet OLE lié et rafraîchit l'aperçu de l'objet. Pour empêcher PowerPoint de proposer de mettre à jour les données de l'objet, définissez la propriété `UpdateAutomatic` de l'interface [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) sur `false` :
```cs
oleFrame.UpdateAutomatic = false;
```


## **Extraction des fichiers incorporés**

Aspose.Slides for .NET vous permet d'extraire les fichiers incorporés dans les diapositives sous forme d'objets OLE de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant les objets OLE que vous souhaitez extraire.
2. Parcourez toutes les formes de la présentation et accédez aux formes [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
3. Accédez aux données des fichiers incorporés à partir des cadres d'objet OLE et enregistrez-les sur le disque.

Ce code C# vous montre comment extraire les fichiers incorporés dans une diapositive sous forme d'objets OLE :
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```


## **FAQ**

**Le contenu OLE sera-t-il rendu lors de l'exportation des diapositives vers PDF/images ?**

Ce qui est visible sur la diapositive est rendu — l'icône/l'image de substitution (aperçu). Le contenu OLE « en direct » n'est pas exécuté lors du rendu. Si nécessaire, définissez votre propre image d'aperçu pour garantir l'apparence attendue dans le PDF exporté.

**Comment verrouiller un objet OLE sur une diapositive afin que les utilisateurs ne puissent pas le déplacer/éditer dans PowerPoint ?**

Verrouillez la forme : Aspose.Slides propose des [verrous au niveau de la forme](/slides/fr/net/applying-protection-to-presentation/). Ce n'est pas du chiffrement, mais cela empêche efficacement les modifications et déplacements accidentels.

**Pourquoi un objet Excel lié « saute » ou change de taille lorsque j'ouvre la présentation ?**

PowerPoint peut actualiser l'aperçu de l'OLE lié. Pour un rendu stable, suivez les bonnes pratiques de la [Solution de mise à l'échelle des feuilles de calcul](/slides/fr/net/working-solution-for-worksheet-resizing/) — ajustez le cadre à la plage, ou redimensionnez la plage à un cadre fixe et définissez une image de substitution appropriée.

**Les chemins relatifs des objets OLE liés seront-ils conservés dans le format PPTX ?**

Dans le PPTX, les informations de « chemin relatif » ne sont pas disponibles—seul le chemin complet l'est. Les chemins relatifs existent dans le format PPT plus ancien. Pour la portabilité, privilégiez des chemins absolus fiables/URI accessibles ou l'incorporation.