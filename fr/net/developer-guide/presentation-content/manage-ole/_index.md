---
title: Gérer OLE
type: docs
weight: 40
url: /net/manage-ole/
keywords:
- ajouter OLE
- intégrer OLE
- ajouter un objet
- intégrer un objet
- intégrer un fichier
- objet lié
- Liaison et Intégration d'Objets
- objet OLE
- PowerPoint 
- présentation
- C#
- Csharp
- Aspose.Slides pour .NET
description: Ajoutez des objets OLE aux présentations PowerPoint en C# ou .NET
---

{{% alert title="Info" color="info" %}}

OLE (Liaison et Intégration d'Objets) est une technologie Microsoft qui permet à des données et des objets créés dans une application d'être placés dans une autre application par le biais de liaisons ou d'intégrations. 

{{% /alert %}} 

Considérons un graphique créé dans MS Excel. Le graphique est ensuite placé à l'intérieur d'une diapositive PowerPoint. Ce graphique Excel est considéré comme un objet OLE. 

- Un objet OLE peut apparaître sous forme d'icône. Dans ce cas, lorsque vous double-cliquez sur l'icône, le graphique s'ouvre dans son application associée (Excel), ou vous êtes invité à sélectionner une application pour ouvrir ou modifier l'objet. 
- Un objet OLE peut afficher des contenus réels, par exemple, le contenu d'un graphique. Dans ce cas, le graphique est activé dans PowerPoint, l'interface du graphique se charge et vous pouvez modifier les données du graphique dans l'application PowerPoint.

[Aspose.Slides pour .NET](https://products.aspose.com/slides/net/) vous permet d'insérer des objets OLE dans des diapositives sous forme de Cadres d'Objet OLE ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **Ajouter des Cadres d'Objet OLE aux Diapositives**
Supposons que vous ayez déjà créé un graphique dans Microsoft Excel et que vous souhaitiez intégrer ce graphique dans une diapositive sous forme de Cadre d'Objet OLE en utilisant Aspose.Slides pour .NET, vous pouvez le faire de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Obtenez la référence d'une diapositive par le biais de son index. 
3. Ouvrez le fichier Excel contenant l'objet graphique Excel et enregistrez-le dans `MemoryStream`. 
4. Ajoutez le [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) à la diapositive contenant le tableau d'octets et d'autres informations sur l'objet OLE. 
5. Écrivez la présentation modifiée sous forme de fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté un graphique d'un fichier Excel à une diapositive sous forme de [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) en utilisant Aspose.Slides pour .NET.  
**Remarque** : le constructeur [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo) prend une extension d'objet intégrable comme deuxième paramètre. Cette extension permet à PowerPoint d'interpréter correctement le type de fichier et de choisir l'application appropriée pour ouvrir cet objet OLE.

``` csharp 
// Instancie la classe Presentation qui représente le fichier PPTX
using (Presentation pres = new Presentation())
{
    // Accède à la première diapositive
    ISlide sld = pres.Slides[0];

    // Charge un fichier excel dans le flux
    MemoryStream mstream = new MemoryStream();
    using (FileStream fs = new FileStream("book1.xlsx", FileMode.Open, FileAccess.Read))
    {
        byte[] buf = new byte[4096];

        while (true)
        {
            int bytesRead = fs.Read(buf, 0, buf.Length);
            if (bytesRead <= 0)
                break;
            mstream.Write(buf, 0, bytesRead);
        }
    }

    // Crée un objet de données pour l'intégration
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(mstream.ToArray(), "xlsx");

    // Ajoute une forme de Cadre d'Objet Ole 
    IOleObjectFrame oleObjectFrame = sld.Shapes.AddOleObjectFrame(0, 0, pres.SlideSize.Size.Width,
        pres.SlideSize.Size.Height, dataInfo);

    // Écrit le fichier PPTX sur le disque
    pres.Save("OleEmbed_out.pptx", SaveFormat.Pptx);
}
```
### Ajouter des Cadres d'Objet OLE Liés

Aspose.Slides pour .NET vous permet d'ajouter un [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) sans intégrer de données mais uniquement avec un lien vers le fichier.

Ce code C# vous montre comment ajouter un [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) avec un fichier Excel lié à une diapositive :

``` csharp 
using (Presentation pres = new Presentation())
{
	// Accède à la première diapositive
	ISlide slide = pres.Slides[0];

	// Ajoute un Cadre d'Objet Ole avec un fichier Excel lié
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book1.xlsx");

	// Écrit le fichier PPTX sur le disque
	pres.Save("OleLinked_out.pptx", SaveFormat.Pptx);
}
```

## **Accéder aux Cadres d'Objet OLE**
Si un objet OLE est déjà intégré dans une diapositive, vous pouvez facilement trouver ou accéder à cet objet de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Obtenez la référence de la diapositive en utilisant son index. 
3. Accédez à la forme [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). 
   Dans notre exemple, nous avons utilisé le PPTX créé précédemment qui n'a qu'une seule forme sur la première diapositive. Nous avons ensuite *casté* cet objet en tant qu'[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). C'était le Cadre d'Objet OLE désiré à accéder. 
4. Une fois que le Cadre d'Objet OLE est accessible, vous pouvez effectuer toute opération dessus. 
Dans l'exemple ci-dessous, un Cadre d'Objet OLE (un objet graphique Excel intégré dans une diapositive) est accessible, puis ses données de fichier sont écrites dans un fichier Excel : 
``` csharp 
// Charge le PPTX dans un objet présentation
using (Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx"))
{
    // Accède à la première diapositive
    ISlide sld = pres.Slides[0];

    // Cast le forme en OleObjectFrame
    OleObjectFrame oleObjectFrame = sld.Shapes[0] as OleObjectFrame;

    // Lit l'objet OLE et l'écrit sur le disque
    if (oleObjectFrame != null)
    {
        // Obtient les données de fichier intégrées
        byte[] data = oleObjectFrame.EmbeddedData.EmbeddedFileData;

        // Obtient l'extension de fichier intégrée
        string fileExtention = oleObjectFrame.EmbeddedData.EmbeddedFileExtension;

        // Crée un chemin pour enregistrer le fichier extrait
        string extractedPath = "excelFromOLE_out" + fileExtention;

        // Enregistre les données extraites
        using (FileStream fstr = new FileStream(extractedPath, FileMode.Create, FileAccess.Write))
        {
            fstr.Write(data, 0, data.Length);
        }
    }
}
```

### Accéder aux Propriétés des Cadres d'Objet OLE Liés

Aspose.Slides vous permet d'accéder aux propriétés des Cadres d'Objet OLE liés.

Ce code C# vous montre comment vérifier si un objet OLE est lié, puis obtenir le chemin vers le fichier lié : 
```csharp
using (Presentation pres = new Presentation("OleLinked.ppt"))
{
	// Accède à la première diapositive
	ISlide slide = pres.Slides[0];

	// Obtient la première forme en tant que Cadre d'Objet Ole
	OleObjectFrame oleObjectFrame = slide.Shapes[0] as OleObjectFrame;

	// Vérifie si l'objet Ole est lié.
	if (oleObjectFrame != null && oleObjectFrame.IsObjectLink)
	{
		// Affiche le chemin complet vers un fichier lié
		Console.WriteLine("Le Cadre d'Objet Ole est lié à : " + oleObjectFrame.LinkPathLong);

		// Affiche le chemin relatif vers un fichier lié si présent.
		// Seules les présentations PPT peuvent contenir le chemin relatif.
		string relativePath = oleObjectFrame.LinkPathRelative;
		if (!string.IsNullOrEmpty(relativePath))
		{
			Console.WriteLine("Chemin relatif du Cadre d'Objet Ole : " + oleObjectFrame.LinkPathRelative);
		}
	}
}
```
## **Modifier les Données de l'Objet OLE**

Si un objet OLE est déjà intégré dans une diapositive, vous pouvez facilement accéder à cet objet et modifier ses données de cette manière : 

1. Ouvrez la présentation désirée contenant l'objet OLE intégré en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Obtenez la référence de la diapositive par son index. 
3. Accédez à la forme [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). 
   Dans notre exemple, nous avons utilisé le PPTX créé précédemment qui a une forme sur la première diapositive. Nous avons ensuite *casté* cet objet en tant qu'[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). C'était le Cadre d'Objet OLE désiré à accéder. 
4. Une fois que le Cadre d'Objet OLE est accessible, vous pouvez effectuer toute opération dessus. 
5. Créez l'objet Workbook et accédez aux données OLE. 
6. Accédez à la feuille de calcul désirée et modifiez les données. 
7. Enregistrez le Workbook mis à jour dans des flux. 
8. Changez les données de l'objet OLE à partir des données de flux. 
Dans l'exemple ci-dessous, un Cadre d'Objet OLE (un objet graphique Excel intégré dans une diapositive) est accessible, puis ses données de fichier sont modifiées pour changer les données du graphique : 
``` csharp 
using (Presentation pres = new Presentation("ChangeOLEObjectData.pptx"))
{
    ISlide slide = pres.Slides[0];

    OleObjectFrame ole = null;

    // Parcourt toutes les formes pour le Cadre Ole
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is OleObjectFrame)
        {
            ole = (OleObjectFrame)shape;
        }
    }

    if (ole != null)
    {
        using (MemoryStream msln = new MemoryStream(ole.EmbeddedData.EmbeddedFileData))
        {
            // Lit les données de l'objet dans le Workbook
            Workbook Wb = new Workbook(msln);

            using (MemoryStream msout = new MemoryStream())
            {
                // Modifie les données du Workbook
                Wb.Worksheets[0].Cells[0, 4].PutValue("E");
                Wb.Worksheets[0].Cells[1, 4].PutValue(12);
                Wb.Worksheets[0].Cells[2, 4].PutValue(14);
                Wb.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions so1 = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                Wb.Save(msout, so1);

                // Change les données de l'objet du cadre Ole
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(msout.ToArray(), ole.EmbeddedData.EmbeddedFileExtension);
                ole.SetEmbeddedData(newData);
            }
        }
    }

    pres.Save("OleEdit_out.pptx", SaveFormat.Pptx);
}
```
## **Intégrer D'autres Types de Fichiers dans les Diapositives**

Outre les graphiques Excel, Aspose.Slides pour .NET vous permet d'intégrer d'autres types de fichiers dans des diapositives. Par exemple, vous pouvez insérer des fichiers HTML, PDF et ZIP en tant qu'objets dans une diapositive. Lorsqu'un utilisateur double-clique sur l'objet inséré, l'objet se lance automatiquement dans le programme pertinent, ou l'utilisateur est dirigé pour sélectionner un programme approprié pour ouvrir l'objet. 

Ce code C# vous montre comment intégrer HTML et ZIP dans une diapositive :

```c#
using (Presentation pres = new Presentation())
{
  ISlide slide = pres.Slides[0];
  
  byte[] htmlBytes = File.ReadAllBytes("embedOle.html");
  IOleEmbeddedDataInfo dataInfoHtml = new OleEmbeddedDataInfo(htmlBytes, "html");
  IOleObjectFrame oleFrameHtml = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, dataInfoHtml);
  oleFrameHtml.IsObjectIcon = true;

  byte[] zipBytes = File.ReadAllBytes("embedOle.zip");
  IOleEmbeddedDataInfo dataInfoZip = new OleEmbeddedDataInfo(zipBytes, "zip");
  IOleObjectFrame oleFrameZip = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, dataInfoZip);
  oleFrameZip.IsObjectIcon = true;

  pres.Save("embeddedOle.pptx", SaveFormat.Pptx);
}
```
## **Définir les Types de Fichiers pour les Objets Intégrés**

Lorsque vous travaillez sur des présentations, vous pouvez avoir besoin de remplacer d'anciens objets OLE par de nouveaux. Ou vous pourriez avoir besoin de remplacer un objet OLE non pris en charge par un objet pris en charge. 

Aspose.Slides pour .NET vous permet de définir le type de fichier pour un objet intégré. De cette manière, vous pouvez changer les données du cadre OLE ou son extension. 

Ce code C# vous montre comment définir le type de fichier pour un objet OLE intégré : 

```c#
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];
    Console.WriteLine($"L'extension des données intégrées actuelles est : {oleObjectFrame.EmbeddedData.EmbeddedFileExtension}");
   
    oleObjectFrame.SetEmbeddedData(new OleEmbeddedDataInfo(File.ReadAllBytes("embedOle.zip"), "zip"));
   
    pres.Save("embeddedChanged.pptx", SaveFormat.Pptx);
}
```
## **Définir des Images d'Icônes et des Titres pour les Objets Intégrés**

Après avoir intégré un objet OLE, un aperçu constitué d'une image icône et d'un titre est ajouté automatiquement. L'aperçu est ce que les utilisateurs voient avant d'accéder ou d'ouvrir l'objet OLE. 

Si vous souhaitez utiliser une image spécifique et du texte comme éléments dans l'aperçu, vous pouvez définir l'image d'icône et le titre à l'aide d'Aspose.Slides pour .NET.

Ce code C# vous montre comment définir l'image d'icône et le titre pour un objet intégré : 

```c#
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];

    IPPImage oleImage = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    oleObjectFrame.SubstitutePictureTitle = "Mon titre";
    oleObjectFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleObjectFrame.IsObjectIcon = false;

    pres.Save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
}
```

## **Empêcher un Cadre d'Objet OLE d'être Redimensionné et Repositionné**

Après avoir ajouté un objet OLE lié à une diapositive de présentation, lorsque vous ouvrez la présentation dans PowerPoint, vous pourriez voir un message vous demandant de mettre à jour les liens. Cliquer sur le bouton "Mettre à jour les liens" peut changer la taille et la position du cadre d'objet OLE car PowerPoint met à jour les données de l'objet OLE lié et rafraîchit l'aperçu de l'objet. Pour empêcher PowerPoint de demander la mise à jour des données de l'objet, définissez la propriété `UpdateAutomatic` de l'interface [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) sur `false`:

```cs
oleObjectFrame.UpdateAutomatic = false;
```

## **Extraction des Fichiers Intégrés**

Aspose.Slides pour .NET vous permet d'extraire les fichiers intégrés dans des diapositives en tant qu'objets OLE de cette manière : 
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant l'objet OLE que vous souhaitez extraire. 
2. Parcourez toutes les formes de la présentation et accédez à la forme [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). 
3. Accédez aux données du fichier intégré à partir du Cadre d'Objet OLE et écrivez-le sur le disque. 
Ce code C# vous montre comment extraire un fichier intégré dans une diapositive en tant qu'objet OLE : 
```c#
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];

    for (var index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;
        
        if (oleFrame != null)
        {
            byte[] data = oleFrame.EmbeddedData.EmbeddedFileData;
            string extension = oleFrame.EmbeddedData.EmbeddedFileExtension;
            
            File.WriteAllBytes($"oleFrame{index}{extension}", data);
        }
    }
}
```