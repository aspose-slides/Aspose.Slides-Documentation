---
title: Cloner des diapositives de présentation sur Android
linktitle: Cloner les diapositives
type: docs
weight: 35
url: /fr/androidjava/clone-slides/
keywords:
- cloner diapositive
- copier diapositive
- enregistrer diapositive
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Dupliquez les diapositives PowerPoint avec Aspose.Slides pour Android. Suivez nos exemples de code Java clairs pour automatiser la création de PPT en quelques secondes et éliminer le travail manuel."
---
## **Introduction**

Le clonage est le processus consistant à créer une copie exacte ou un duplicata de quelque chose. Aspose.Slides for Android via Java rend également possible de créer une copie ou un clone de n'importe quelle diapositive, puis d'insérer cette diapositive clonée dans la présentation actuelle ou toute autre présentation ouverte. Le processus de clonage de diapositives crée une nouvelle diapositive qui peut être modifiée par les développeurs sans modifier la diapositive originale. Il existe plusieurs manières possibles de cloner une diapositive :

- Cloner à la fin d'une présentation.
- Cloner à une autre position dans la même présentation.
- Cloner à la fin d'une autre présentation.
- Cloner à une autre position dans une autre présentation.
- Cloner à une position spécifique dans une autre présentation.

In Aspose.Slides for Android via Java, (une collection d'objets [ISlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlide)) exposée par l'objet [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation) fournit les méthodes [addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) et [insertClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) pour effectuer les types de clonage de diapositives ci‑dessus.

## **Cloner une diapositive à la fin d'une présentation**
If you want to clone a slide and then use it within the same presentation file at the end of the existing slides, use the [addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) method according to the steps listed below:

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation).
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation#getSlides--) en faisant référence à la collection Slides exposée par l'objet [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation).
1. Appelez la méthode [addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation#getSlides--) et transmettez la diapositive à cloner comme paramètre à la méthode [addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Enregistrez le fichier de présentation modifié.

Dans l'exemple ci‑dessous, nous avons cloné une diapositive (située à la première position – indice zéro – de la présentation) à la fin de la présentation.

```java
import com.aspose.slides.*;

// Instancier la classe Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Cloner la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Enregistrer la présentation modifiée sur le disque
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Cloner une diapositive à une autre position dans une présentation**
If you want to clone a slide and then use it within the same presentation file but at a different position, use the [insertClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) method:

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation).
1. Instanciez la classe en faisant référence à la collection **Slides** exposée par l'objet [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation).
1. Appelez la méthode [insertClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation#getSlides--) et transmettez la diapositive à cloner ainsi que l'indice pour la nouvelle position comme paramètre à la méthode [insertClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Enregistrez la présentation modifiée au format PPTX.

Dans l'exemple ci‑dessous, nous avons cloné une diapositive (située à l'indice 1 – position 2 – de la présentation) à l'indice 2 – Position 3 – de la présentation.

```java
import com.aspose.slides.*;

// Instancier la classe Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Obtenir la collection de diapositives dans la même présentation
    ISlideCollection slds = pres.getSlides();

    // Cloner la diapositive souhaitée à l'index spécifié dans la même présentation
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Enregistrer la présentation modifiée sur le disque
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Cloner une diapositive à la fin d'une autre présentation**
If you need to clone a slide from one presentation and use it in another presentation file, at the end of the existing slides:

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation) contenant la présentation dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation) contenant la présentation de destination à laquelle la diapositive sera ajoutée.
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection) en faisant référence à la collection **Slides** exposée par l'objet Presentation de la présentation de destination.
1. Appelez la méthode [addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation#getSlides--) et transmettez la diapositive de la présentation source comme paramètre à la méthode [addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l'exemple ci‑dessous, nous avons cloné une diapositive (à partir du premier indice de la présentation source) à la fin de la présentation de destination.

```java
import com.aspose.slides.*;

// Instancier la classe Presentation pour charger le fichier de présentation source
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instancier la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée)
    Presentation destPres = new Presentation();
    try {
        // Cloner la diapositive souhaitée de la présentation source à la fin de la collection de diapositives de la présentation de destination
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Enregistrer la présentation de destination sur le disque
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Cloner une diapositive à une autre position dans une autre présentation**
If you need to clone a slide from one presentation and use it in another presentation file, at a specific position:

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation) contenant la présentation source dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation) contenant la présentation à laquelle la diapositive sera ajoutée.
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation#getSlides--) en faisant référence à la collection Slides exposée par l'objet Presentation de la présentation de destination.
1. Appelez la méthode [insertClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation#getSlides--) et transmettez la diapositive de la présentation source ainsi que la position souhaitée comme paramètre à la méthode [insertClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l'exemple ci‑dessous, nous avons cloné une diapositive (à partir de l'indice zéro de la présentation source) à l'indice 1 (position 2) de la présentation de destination.

```java
import com.aspose.slides.*;

// Instancier la classe Presentation pour charger le fichier de présentation source
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instancier la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée)
    Presentation destPres = new Presentation();
    try {
        // Cloner la diapositive souhaitée de la présentation source à l'index spécifié dans la présentation de destination
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Enregistrer la présentation de destination sur le disque
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Cloner une diapositive à une position spécifique dans une autre présentation**
If you need to clone a slide with a master slide from one presentation from and use it in another presentation, you need to clone the desired master slide from source presentation to destination presentation first. Then you need to use that master slide for cloning slide with master slide. The [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) expects a master slide from destination presentation rather than from source presentation. In order to clone the slide with a master, please follow the steps below:

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation) contenant la présentation source dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation) contenant la présentation de destination vers laquelle la diapositive sera clonée.
1. Accédez à la diapositive à cloner ainsi qu'à la diapositive maîtresse.
1. Instanciez la classe [IMasterSlideCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IMasterSlideCollection) en faisant référence à la collection Masters exposée par l'objet [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation) de la présentation de destination.
1. Appelez la méthode [addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposée par l'objet [IMasterSlideCollection] et transmettez le maître du PPTX source à cloner comme paramètre à la méthode [addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation#getSlides--) en définissant la référence à la collection Slides exposée par l'objet [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation) de la présentation de destination.
1. Appelez la méthode [addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) exposée par l'objet [ISlideCollection] et transmettez la diapositive de la présentation source à cloner ainsi que la diapositive maîtresse comme paramètre à la méthode [addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l'exemple ci‑dessous, nous avons cloné une diapositive avec un maître (située à l'indice zéro de la présentation source) à la fin de la présentation de destination en utilisant le maître de la diapositive source.

```java
import com.aspose.slides.*;

// Instancier la classe Presentation pour charger le fichier de présentation source
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instancier la classe Presentation pour la présentation de destination (où la diapositive doit être clonée)
    Presentation destPres = new Presentation();
    try {
        // Instancier ISlide à partir de la collection de diapositives de la présentation source ainsi que
        // Diapositive maître
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Cloner la diapositive maître souhaitée de la présentation source vers la collection de maîtres dans la
        // présentation de destination
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Cloner la diapositive souhaitée de la présentation source avec le maître souhaité à la fin de la
        // collection de diapositives de la présentation de destination
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Enregistrer la présentation de destination sur le disque
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Cloner une diapositive à la fin d'une section spécifiée**
If you want to clone a slide and then use it within the same presentation file but at a different section, then use the [**addClone**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-) method exposed by the [**ISlideCollection**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection) interface. Aspose.Slides for Android via Java makes it possible to clone a slide from the first section and then insert that cloned slide to the second section of the same presentation.

The following code snippet shows you how to clone a slide and insert the cloned slide into a specified section.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Enregistrer la présentation de destination sur le disque
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Assurer une taille de diapositive correspondante**

When cloning slides into another presentation, make sure the destination presentation has the same slide size as the source. If the slide sizes differ, Aspose.Slides does not automatically rescale the cloned shapes—their original coordinates and dimensions are preserved, which may cause the content to appear misaligned or extend beyond the slide boundaries.

You can set the destination presentation's slide size to match the source before cloning the master and slide:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Faites cela avant de cloner le master et la diapositive.

## **FAQ**

**Les notes du présentateur et les commentaires des réviseurs sont‑ils clonés ?**

Oui. La page de notes et les commentaires de révision sont inclus dans le clone. Si vous ne les voulez pas, [supprimez‑les](/slides/fr/androidjava/presentation-notes/) après l'insertion.

**Comment les graphiques et leurs sources de données sont‑ils gérés ?**

L'objet du graphique, le formatage et les données intégrées sont copiés. Si le graphique était lié à une source externe (par ex., un classeur OLE intégré), ce lien est conservé sous forme d'[objet OLE](/slides/fr/androidjava/manage-ole/). Après le déplacement entre fichiers, vérifiez la disponibilité des données et le comportement de rafraîchissement.

**Puis‑je contrôler la position d’insertion et les sections du clone ?**

Oui. Vous pouvez insérer le clone à un indice de diapositive spécifique et le placer dans une [section](/slides/fr/androidjava/slide-section/) choisie. Si la section cible n’existe pas, créez‑la d’abord puis déplacez la diapositive dedans.