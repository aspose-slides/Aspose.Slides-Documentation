---
title: Convertir PowerPoint en TIFF avec des notes
type: docs
weight: 100
url: /androidjava/convert-powerpoint-to-tiff-with-notes/
keywords: "Convertir PowerPoint en TIFF avec des notes"
description: "Convertir PowerPoint en TIFF avec des notes dans Aspose.Slides."
---

## **Convertir PPT(X) en vue de diapositive avec notes en TIFF**
La méthode [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) exposée par la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) peut être utilisée pour convertir l'ensemble de la présentation en vue de diapositive avec notes en TIFF. Les extraits de code ci-dessous mettent à jour la présentation d'exemple en images TIFF en vue de diapositive avec notes, comme indiqué ci-dessous :

```java
//Instancier un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("demo.pptx");
try {
    TiffOptions opts = new TiffOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    //Enregistrer la présentation en notes TIFF
    pres.save("Tiff-Notes.tiff", SaveFormat.Tiff,opts);
} finally {
    if (pres != null) pres.dispose();
}
```

Les extraits de code ci-dessus mettent à jour la présentation d'exemple en images TIFF en vue de diapositive avec notes, comme indiqué ci-dessous :

|**La vue de la présentation source avec les notes de diapositive**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/6HdY6IV.png)| |


|**L'image TIFF générée en vue de diapositive avec notes**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/A3ttT2y.png)| |

{{% alert title="Conseil" color="primary" %}}

Vous voudrez peut-être consulter le [convertisseur GRATUIT de PowerPoint en Poster](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) d'Aspose.

{{% /alert %}}