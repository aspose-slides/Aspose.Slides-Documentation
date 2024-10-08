---
title: Gérer OLE
type: docs
weight: 40
url: /fr/java/manage-ole/
keywords:
- ajouter OLE
- intégrer OLE
- ajouter un objet
- intégrer un objet
- intégrer un fichier
- objet lié
- Liaison & Intégration d'Objets
- objet OLE
- PowerPoint 
- présentation
- Java
- Aspose.Slides pour Java
description: Ajouter des objets OLE aux présentations PowerPoint en Java
---

{{% alert color="primary" %}} 

OLE (Liaison & Intégration d'Objets) est une technologie Microsoft qui permet de placer des données et des objets créés dans une application dans une autre application par le biais de liens ou d'intégrations. 

{{% /alert %}} 

Considérez un graphique créé dans MS Excel. Le graphique est ensuite placé à l'intérieur d'une diapositive PowerPoint. Ce graphique Excel est considéré comme un objet OLE. 

- Un objet OLE peut apparaître sous forme d'icône. Dans ce cas, lorsque vous double-cliquez sur l'icône, le graphique s'ouvre dans son application associée (Excel), ou vous êtes invité à sélectionner une application pour ouvrir ou modifier l'objet. 
- Un objet OLE peut afficher les contenus réels, par exemple, les contenus d'un graphique. Dans ce cas, le graphique est activé dans PowerPoint, l'interface du graphique se charge, et vous pouvez modifier les données du graphique dans l'application PowerPoint.

[Aspose.Slides pour Java](https://products.aspose.com/slides/java/) vous permet d'insérer des objets OLE dans des diapositives sous forme de Cadres d'Objet OLE ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **Ajout de Cadres d'Objet OLE aux Diapositives**
Supposons que vous ayez déjà créé un graphique dans Microsoft Excel et que vous souhaitiez intégrer ce graphique dans une diapositive sous forme de Cadre d'Objet OLE à l'aide d'Aspose.Slides pour Java. Vous pouvez procéder de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenez la référence de la diapositive en utilisant son index.
1. Ouvrez le fichier Excel contenant l'objet graphique Excel et enregistrez-le dans `MemoryStream`.
1. Ajoutez le [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) à la diapositive contenant le tableau d'octets et d'autres informations sur l'objet OLE.
1. Écrivez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté un graphique d'un fichier Excel à une diapositive sous forme de Cadre d'Objet OLE à l'aide d'Aspose.Slides pour Java.
**Remarque** : le constructeur [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IOleEmbeddedDataInfo) prend une extension d'objet intégrable comme deuxième paramètre. Cette extension permet à PowerPoint d'interpréter correctement le type de fichier et de choisir la bonne application pour ouvrir cet objet OLE.

``` java 
// Instancie la classe Prseetation qui représente le fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Charge un fichier excel dans le flux
    FileInputStream fs = new FileInputStream("book1.xlsx");
    ByteArrayOutputStream mstream = new ByteArrayOutputStream();
    byte[] buf = new byte[4096];
    while (true)
    {
        int bytesRead = fs.read(buf, 0, buf.length);
        if (bytesRead <= 0)
            break;
        mstream.write(buf, 0, bytesRead);
    }
    fs.close();

    // Crée un objet de données pour l'intégration
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(mstream.toByteArray(), "xlsx");
    mstream.close();

    // Ajoute une forme de Cadre d'Objet Ole 
    IOleObjectFrame oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0,
            (float) pres.getSlideSize().getSize().getWidth(),
            (float) pres.getSlideSize().getSize().getHeight(),
            dataInfo);

    // Écrit le fichier PPTX sur le disque
    pres.save("OleEmbed_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accéder aux Cadres d'Objet OLE**
Si un objet OLE est déjà intégré dans une diapositive, vous pouvez trouver ou accéder facilement à cet objet de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenez la référence de la diapositive en utilisant son index.
1. Accédez à la forme Cadre d'Objet OLE.

   Dans notre exemple, nous avons utilisé le PPTX précédemment créé, qui n'a qu'une seule forme sur la première diapositive. Nous avons ensuite *casté* cet objet en [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame). C'était le cadre d'objet OLE désiré à accéder.
1. Une fois le Cadre d'Objet OLE accédé, vous pouvez effectuer toute opération sur celui-ci.

Dans l'exemple ci-dessous, un Cadre d'Objet OLE (un objet graphique Excel intégré dans une diapositive) est accédé, puis ses données de fichier sont écrites dans un fichier Excel.

``` java 
// Charge le PPTX dans un objet Presentation
Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx");
try {
    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Cast la forme en OleObjectFrame
    OleObjectFrame oleObjectFrame = (OleObjectFrame) sld.getShapes().get_Item(0);

    // Lit l'objet OLE et l'écrit sur le disque
    if (oleObjectFrame != null) {
        // Obtient les données de fichier intégrées
        byte[] data = oleObjectFrame.getEmbeddedData().getEmbeddedFileData();

        // Obtient l'extension du fichier intégré
        String fileExtention = oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension();

        // Crée un chemin pour enregistrer le fichier extrait
        String extractedPath = "excelFromOLE_out" + fileExtention;

        // Enregistre les données extraites
        FileOutputStream fstr = new FileOutputStream(extractedPath);
        try {
            fstr.write(data, 0, data.length);
        } finally {
            fstr.close();
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modifier les Données de l'Objet OLE**

Si un objet OLE est déjà intégré dans une diapositive, vous pouvez facilement accéder à cet objet et modifier ses données de cette manière :

1. Ouvrez la présentation souhaitée avec l'objet OLE intégré en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenez la référence de la diapositive par son index.
1. Accédez à la forme Cadre d'Objet OLE.

   Dans notre exemple, nous avons utilisé le PPTX précédemment créé qui n'a qu'une seule forme sur la première diapositive. Nous avons ensuite *casté* cet objet en [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame). C'était le cadre d'objet OLE désiré à accéder.
1. Une fois le Cadre d'Objet OLE accédé, vous pouvez effectuer toute opération sur celui-ci.
1. Créez l'objet Workbook et accédez aux données OLE.
1. Accédez à la feuille de calcul désirée et modifiez les données.
1. Enregistrez le Workbook mis à jour dans des flux.
1. Modifiez les données de l'objet OLE à partir des données du flux.

Dans l'exemple ci-dessous, un Cadre d'Objet OLE (un objet graphique Excel intégré dans une diapositive) est accédé, et ensuite ses données de fichier sont modifiées pour changer les données du graphique :

``` java 
Presentation pres = new Presentation("ChangeOLEObjectData.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
	
    OleObjectFrame ole = null;

    // Parcourt toutes les formes pour le cadre Ole
    for (IShape shape : slide.getShapes()) 
    {
        if (shape instanceof OleObjectFrame) 
        {
            ole = (OleObjectFrame) shape;
        }
    }

    if (ole != null) {
        ByteArrayInputStream msln = new ByteArrayInputStream(ole.getEmbeddedData().getEmbeddedFileData());
        try {
            // Lit les données de l'objet dans le Workbook
            Workbook Wb = new Workbook(msln);

            ByteArrayOutputStream msout = new ByteArrayOutputStream();
            try {
                // Modifie les données du workbook
                Wb.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
                Wb.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
                Wb.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
                Wb.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

                OoxmlSaveOptions so1 = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
                Wb.save(msout, so1);

                // Change les données de l'objet du cadre Ole
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(msout.toByteArray(), ole.getEmbeddedData().getEmbeddedFileExtension());
                ole.setEmbeddedData(newData);
            } finally {
                if (msout != null) msout.close();
            }
        } finally {
            if (msln != null) msln.close();
        }
    }

    pres.save("OleEdit_out.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Intégrer d'Autres Types de Fichiers dans les Diapositives

En plus des graphiques Excel, Aspose.Slides pour Java vous permet d'intégrer d'autres types de fichiers dans les diapositives. Par exemple, vous pouvez insérer des fichiers HTML, PDF et ZIP en tant qu'objets dans une diapositive. Lorsqu'un utilisateur double-clique sur l'objet inséré, l'objet est automatiquement lancé dans le programme pertinent, ou l'utilisateur est dirigé pour sélectionner un programme approprié pour ouvrir l'objet. 

Ce code Java vous montre comment intégrer du HTML et un ZIP dans une diapositive :

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    byte[] htmlBytes = Files.readAllBytes(Paths.get("embedOle.html"));
    IOleEmbeddedDataInfo dataInfoHtml = new OleEmbeddedDataInfo(htmlBytes, "html");
    IOleObjectFrame oleFrameHtml = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, dataInfoHtml);
    oleFrameHtml.setObjectIcon(true);

    byte[] zipBytes = Files.readAllBytes(Paths.get("embedOle.zip"));
    IOleEmbeddedDataInfo dataInfoZip = new OleEmbeddedDataInfo(zipBytes, "zip");
    IOleObjectFrame oleFrameZip = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, dataInfoZip);
    oleFrameZip.setObjectIcon(true);

    pres.save("embeddedOle.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Définir les Types de Fichiers pour les Objets Intégrés

Lorsque vous travaillez sur des présentations, vous pourriez avoir besoin de remplacer d'anciens objets OLE par de nouveaux. Ou vous pourriez avoir besoin de remplacer un objet OLE non pris en charge par un objet pris en charge. 

Aspose.Slides pour Java vous permet de définir le type de fichier pour un objet intégré. De cette manière, vous pouvez changer les données du cadre OLE ou son extension. 

Ce code Java vous montre comment définir le type de fichier pour un objet OLE intégré :

```java
Presentation pres = new Presentation("embeddedOle.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.getShapes().get_Item(0);
    System.out.println("L'extension des données intégrées actuelles est : " + oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension());

    oleObjectFrame.setEmbeddedData(new OleEmbeddedDataInfo(Files.readAllBytes(Paths.get("embedOle.zip")), "zip"));

    pres.save("embeddedChanged.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Définir des Images d'Icône et des Titres pour les Objets Intégrés

Après avoir intégré un objet OLE, un aperçu consistant en une image d'icône et un titre est automatiquement ajouté. L'aperçu est ce que les utilisateurs voient avant d'accéder ou d'ouvrir l'objet OLE. 

Si vous souhaitez utiliser une image et un texte spécifiques comme éléments dans l'aperçu, vous pouvez définir l'image d'icône et le titre à l'aide d'Aspose.Slides pour Java. 

Ce code Java vous montre comment définir l'image d'icône et le titre pour un objet intégré : 

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

        IPPImage oleImage;
        IImage image = Images.fromFile("image.png");
        try {
             oleImage = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    oleObjectFrame.setSubstitutePictureTitle("Mon titre");
    oleObjectFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleObjectFrame.setObjectIcon(false);

    pres.save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Empêcher un Cadre d'Objet OLE d'Être Redimensionné et Repositionné**

Après avoir ajouté un objet OLE lié à une diapositive de présentation, lorsque vous ouvrez la présentation dans PowerPoint, vous pourriez voir un message vous demandant de mettre à jour les liens. En cliquant sur le bouton "Mettre à jour les liens", la taille et la position du cadre d'objet OLE peuvent être modifiées car PowerPoint met à jour les données de l'objet OLE lié et rafraîchit l'aperçu de l'objet. Pour éviter que PowerPoint ne demande de mettre à jour les données de l'objet, définissez la méthode `setUpdateAutomatic` de l'interface [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) sur `false` :

```java
oleObjectFrame.setUpdateAutomatic(false);
```

## Extraction de Fichiers Intégrés

Aspose.Slides pour Java vous permet d'extraire les fichiers intégrés dans des diapositives sous forme d'objets OLE de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) contenant l'objet OLE que vous souhaitez extraire.
2. Parcourez toutes les formes de la présentation et accédez à la forme [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe).
3. Accédez aux données du fichier intégré à partir du Cadre d'Objet OLE et écrivez-les sur le disque. 

Ce code Java vous montre comment extraire un fichier intégré dans une diapositive sous forme d'objet OLE :

```java
Presentation pres = new Presentation("embeddedOle.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    for (int index = 0; index < slide.getShapes().size(); index++)
    {
        IShape shape = slide.getShapes().get_Item(index);
        IOleObjectFrame oleFrame = (IOleObjectFrame)shape;

        if (oleFrame != null) 
		{
            byte[] data = oleFrame.getEmbeddedData().getEmbeddedFileData();
            String extension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

            // Enregistre les données extraites
            FileOutputStream fstr = new FileOutputStream("oleFrame" + index + extension);
            try {
                fstr.write(data, 0, data.length);
            } finally {
                fstr.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```