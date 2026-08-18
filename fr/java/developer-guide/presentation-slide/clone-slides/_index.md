---
title: Cloner des diapositives de présentation en Java
linktitle: Cloner des diapositives
type: docs
weight: 35
url: /fr/java/clone-slides/
keywords:
- cloner diapositive
- copier diapositive
- enregistrer diapositive
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Dupliquez rapidement des diapositives PowerPoint avec Aspose.Slides for Java. Suivez nos exemples de code clairs pour automatiser la création de PPT en quelques secondes et éliminer le travail manuel."
---
## **Introduction**

Le clonage est le processus consistant à créer une copie exacte ou une réplique de quelque chose. Aspose.Slides for Java permet également de créer une copie ou un clone de n’importe quelle diapositive, puis d’insérer cette diapositive clonée dans la présentation actuelle ou toute autre présentation ouverte. Le processus de clonage de diapositive crée une nouvelle diapositive qui peut être modifiée par les développeurs sans changer la diapositive originale. Il existe plusieurs façons de cloner une diapositive :

- Cloner à la fin d’une présentation.
- Cloner à une autre position dans la même présentation.
- Cloner à la fin dans une autre présentation.
- Cloner à une autre position dans une autre présentation.
- Cloner avec sa diapositive maître dans une autre présentation.

In Aspose.Slides for Java, (une collection d’objets [ISlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlide) exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation)) fournit les méthodes [addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) et [insertClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) pour réaliser les types de clonage de diapositive ci‑dessus.

## **Cloner une diapositive à la fin d’une présentation**
Si vous souhaitez cloner une diapositive puis l’utiliser dans le même fichier de présentation à la fin des diapositives existantes, utilisez la méthode [addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) selon les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation).
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation#getSlides--) en faisant référence à la collection Slides exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation).
1. Appelez la méthode [addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposée par l’objet [ISlideCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation#getSlides--) et transmettez la diapositive à cloner comme paramètre de la méthode [addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Enregistrez le fichier de présentation modifié.

Dans l’exemple ci‑dessous, nous avons cloné une diapositive (située à la première position – indice zéro – de la présentation) à la fin de la présentation.

```java
import com.aspose.slides.*;

// Instanciez la classe Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Clonez la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Enregistrez la présentation modifiée sur le disque
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Cloner une diapositive à une autre position dans une présentation**
Si vous souhaitez cloner une diapositive puis l’utiliser dans le même fichier de présentation mais à une position différente, utilisez la méthode [insertClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation).
1. Instanciez la classe en faisant référence à la collection **Slides** exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation).
1. Appelez la méthode [insertClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) exposée par l’objet [ISlideCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation#getSlides--) et transmettez la diapositive à cloner ainsi que l’indice de la nouvelle position comme paramètres de la méthode [insertClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Enregistrez la présentation modifiée au format PPTX.

Dans l’exemple ci‑dessus, nous avons cloné une diapositive (située à l’indice 1 – position 2 – de la présentation) à l’indice 2 – position 3 – de la présentation.

```java
import com.aspose.slides.*;

// Instanciez la classe Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Obtenez la collection de diapositives de la présentation
    ISlideCollection slds = pres.getSlides();

    // Clonez la diapositive souhaitée à l'index spécifié dans la même présentation
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Enregistrez la présentation modifiée sur le disque
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Cloner une diapositive à la fin d’une autre présentation**
Si vous devez cloner une diapositive d’une présentation et l’utiliser dans un autre fichier de présentation, à la fin des diapositives existantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation) contenant la présentation dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation) contenant la présentation de destination dans laquelle la diapositive sera ajoutée.
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlideCollection) en faisant référence à la collection **Slides** exposée par l’objet Presentation de la présentation de destination.
1. Appelez la méthode [addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposée par l’objet [ISlideCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation#getSlides--) et transmettez la diapositive de la présentation source comme paramètre de la méthode [addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessus, nous avons cloné une diapositive (à partir du premier indice de la présentation source) à la fin de la présentation de destination.

```java
import com.aspose.slides.*;

// Instanciez la classe Presentation pour charger le fichier de présentation source
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanciez la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée)
    Presentation destPres = new Presentation();
    try {
        // Clonez la diapositive souhaitée de la présentation source à la fin de la collection de diapositives dans la présentation de destination
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Enregistrez la présentation de destination sur le disque
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Cloner une diapositive à une autre position dans une autre présentation**
Si vous devez cloner une diapositive d’une présentation et l’utiliser dans un autre fichier de présentation, à une position spécifique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation) contenant la présentation source dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation) contenant la présentation dans laquelle la diapositive sera ajoutée.
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation#getSlides--) en faisant référence à la collection Slides exposée par l’objet Presentation de la présentation de destination.
1. Appelez la méthode [insertClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) exposée par l’objet [ISlideCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation#getSlides--) et transmettez la diapositive de la présentation source ainsi que la position souhaitée comme paramètres de la méthode [insertClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessus, nous avons cloné une diapositive (à partir de l’indice zéro de la présentation source) à l’indice 1 (position 2) de la présentation de destination.

```java
import com.aspose.slides.*;

// Instanciez la classe Presentation pour charger le fichier de présentation source
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanciez la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée)
    Presentation destPres = new Presentation();
    try {
        // Clonez la diapositive souhaitée de la présentation source à l'index spécifié dans la présentation de destination
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Enregistrez la présentation de destination sur le disque
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Cloner une diapositive avec sa diapositive maître dans une autre présentation**
Si vous devez cloner une diapositive avec sa diapositive maître d’une présentation et l’utiliser dans une autre présentation, vous devez d’abord cloner la diapositive maître souhaitée de la présentation source vers la présentation de destination. Vous utiliserez ensuite cette diapositive maîtresse pour cloner la diapositive avec maître. La méthode [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) attend une diapositive maîtresse provenant de la présentation de destination plutôt que de la source. Pour cloner la diapositive avec maître, suivez les étapes ci‑dessus :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation) contenant la présentation source dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation) contenant la présentation de destination vers laquelle la diapositive sera clonée.
1. Accédez à la diapositive à cloner ainsi qu’à sa diapositive maître.
1. Instanciez la classe [IMasterSlideCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IMasterSlideCollection) en faisant référence à la collection Masters exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation) de la présentation de destination.
1. Appelez la méthode [addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposée par l’objet [IMasterSlideCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IMasterSlideCollection) et transmettez le maître du PPTX source à cloner comme paramètre de la méthode [addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation#getSlides--) en définissant la référence à la collection Slides exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation) de la présentation de destination.
1. Appelez la méthode [addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposée par l’objet [ISlideCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation#getSlides--) et transmettez la diapositive de la présentation source à cloner ainsi que la diapositive maître comme paramètres de la méthode [addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessous, nous avons cloné une diapositive avec maître (située à l’indice zéro de la présentation source) à la fin de la présentation de destination en utilisant le maître de la diapositive source.

```java
import com.aspose.slides.*;

// Instanciez la classe Presentation pour charger le fichier de présentation source
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instanciez la classe Presentation pour la présentation de destination (où la diapositive doit être clonée)
    Presentation destPres = new Presentation();
    try {
        // Instanciez ISlide à partir de la collection de diapositives de la présentation source ainsi que
        // la diapositive maître
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Clonez la diapositive maître souhaitée de la présentation source vers la collection de maîtres de la
        // présentation de destination
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = masters.addClone(SourceMaster);

        // Clonez la diapositive souhaitée de la présentation source avec le maître souhaité à la fin de la
        // collection de diapositives de la présentation de destination
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);

        // Enregistrez la présentation de destination sur le disque
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Cloner une diapositive à la fin d’une section spécifiée**
Si vous souhaitez cloner une diapositive puis l’utiliser dans le même fichier de présentation mais dans une autre section, utilisez la méthode [**addClone**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) exposée par l’interface [**ISlideCollection**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlideCollection). Aspose.Slides for Java permet de cloner une diapositive de la première section puis d’insérer cette diapositive clonée dans la deuxième section de la même présentation.

Le fragment de code suivant montre comment cloner une diapositive et insérer la diapositive clonée dans une section spécifiée.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);

    // Enregistrez la présentation de destination sur le disque
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Assurer une taille de diapositive correspondante**

Lors du clonage de diapositives dans une autre présentation, assurez‑vous que la présentation de destination a la même taille de diapositive que la source. Si les tailles de diapositive diffèrent, Aspose.Slides ne redimensionne pas automatiquement les formes clonées ; leurs coordonnées et dimensions d’origine sont conservées, ce qui peut entraîner un mauvais alignement du contenu ou son dépassement des limites de la diapositive.

Vous pouvez définir la taille de diapositive de la présentation de destination pour qu’elle corresponde à celle de la source avant de cloner le maître et la diapositive :

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Faites‑le avant de cloner le maître et la diapositive.

## **FAQ**

**Les notes du présentateur et les commentaires des relecteurs sont-ils clonés ?**

Oui. La page de notes et les commentaires de révision sont inclus dans le clone. Si vous ne les voulez pas, [supprimez‑les](/slides/fr/java/presentation-notes/) après l’insertion.

**Comment les graphiques et leurs sources de données sont‑ils gérés ?**

L’objet graphique, son formatage et les données intégrées sont copiés. Si le graphique était lié à une source externe (par ex., un classeur OLE intégré), ce lien est conservé en tant qu’[objet OLE](/slides/fr/java/manage-ole/). Après le déplacement entre fichiers, vérifiez la disponibilité des données et le comportement de rafraîchissement.

**Puis‑je contrôler la position d’insertion et les sections du clone ?**

Oui. Vous pouvez insérer le clone à un indice de diapositive spécifique et le placer dans une [section](/slides/fr/java/slide-section/) choisie. Si la section cible n’existe pas, créez‑la d’abord puis déplacez la diapositive dedans.