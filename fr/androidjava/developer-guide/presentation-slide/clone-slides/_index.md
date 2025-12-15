---
title: Cloner des diapositives de présentation sur Android
linktitle: Cloner des diapositives
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

## **Cloner des diapositives dans une présentation**
Le clonage est le processus de création d'une copie exacte ou d'un replica de quelque chose. Aspose.Slides pour Android via Java rend également possible la création d'une copie ou d'un clone de n'importe quelle diapositive, puis l'insertion de cette diapositive clonée dans la présentation actuelle ou toute autre présentation ouverte. Le processus de clonage d'une diapositive crée une nouvelle diapositive qui peut être modifiée par les développeurs sans changer la diapositive originale. Plusieurs méthodes possibles existent pour cloner une diapositive :

- Cloner à la fin dans une présentation.
- Cloner à une autre position dans la même présentation.
- Cloner à la fin dans une autre présentation.
- Cloner à une autre position dans une autre présentation.
- Cloner à une position spécifique dans une autre présentation.

Dans Aspose.Slides pour Android via Java, (une collection d'objets [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) exposée par l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)) fournit les méthodes [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) et [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) pour réaliser les types de clonage de diapositives ci‑dessus.

## **Cloner une diapositive à la fin d'une présentation**
Si vous souhaitez cloner une diapositive puis l'utiliser dans le même fichier de présentation à la fin des diapositives existantes, utilisez la méthode [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) selon les étapes ci‑dessus :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Instancier la classe [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) en référant la collection Slides exposée par l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Appeler la méthode [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) et transmettre la diapositive à cloner comme paramètre à la méthode [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Enregistrer le fichier de présentation modifié.

Dans l'exemple ci‑dessous, nous avons cloné une diapositive (située à la première position – index zéro – de la présentation) à la fin de la présentation.
```java
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
Si vous souhaitez cloner une diapositive puis l'utiliser dans le même fichier de présentation mais à une position différente, utilisez la méthode [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Instancier la classe en référant la collection [**Slides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) exposée par l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Appeler la méthode [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) et transmettre la diapositive à cloner ainsi que l'index de la nouvelle position comme paramètres à la méthode [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Enregistrer la présentation modifiée au format PPTX.

Dans l'exemple ci‑dessus, nous avons cloné une diapositive (située à l'index zéro – position 1 – de la présentation) à l'index 1 – Position 2 – de la présentation.
```java
// Instancier la classe Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Cloner la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation
    ISlideCollection slds = pres.getSlides();

    // Cloner la diapositive souhaitée à l'index indiqué dans la même présentation
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Enregistrer la présentation modifiée sur le disque
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Cloner une diapositive à la fin d'une autre présentation**
Si vous devez cloner une diapositive d'une présentation et l'utiliser dans un autre fichier de présentation, à la fin des diapositives existantes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) contenant la présentation dont la diapositive sera clonée.
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) contenant la présentation de destination à laquelle la diapositive sera ajoutée.
1. Instancier la classe [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) en référant la collection [**Slides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) exposée par l'objet Presentation de la présentation de destination.
1. Appeler la méthode [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) et transmettre la diapositive de la présentation source comme paramètre à la méthode [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Enregistrer le fichier de présentation de destination modifié.

Dans l'exemple ci‑dessus, nous avons cloné une diapositive (du premier index de la présentation source) à la fin de la présentation de destination.
```java
// Instancier la classe Presentation pour charger le fichier de présentation source
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instancier la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée)
    Presentation destPres = new Presentation();
    try {
        // Cloner la diapositive souhaitée de la présentation source à la fin de la collection de diapositives dans la présentation de destination
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
Si vous devez cloner une diapositive d'une présentation et l'utiliser dans un autre fichier de présentation, à une position spécifique :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) contenant la présentation source dont la diapositive sera clonée.
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) contenant la présentation à laquelle la diapositive sera ajoutée.
1. Instancier la classe [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) en référant la collection Slides exposée par l'objet Presentation de la présentation de destination.
1. Appeler la méthode [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) et transmettre la diapositive de la présentation source ainsi que la position souhaitée comme paramètres à la méthode [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Enregistrer le fichier de présentation de destination modifié.

Dans l'exemple ci‑dessus, nous avons cloné une diapositive (de l'index zéro de la présentation source) à l'index 1 (position 2) de la présentation de destination.
```java
    // Instancier la classe Presentation pour charger le fichier de présentation source
    Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
    try {
        // Instancier la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée)
        Presentation destPres = new Presentation();
        try {
            // Cloner la diapositive souhaitée de la présentation source à la fin de la collection de diapositives dans la présentation de destination
            ISlideCollection slds = destPres.getSlides();

            slds.insertClone(2, srcPres.getSlides().get_Item(0));

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
Si vous devez cloner une diapositive avec une diapositive maîtresse d'une présentation et l'utiliser dans une autre présentation, vous devez d'abord cloner la diapositive maîtresse souhaitée de la présentation source vers la présentation de destination. Vous utiliserez ensuite cette diapositive maîtresse pour cloner la diapositive avec maître. La méthode [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) attend une diapositive maîtresse provenant de la présentation de destination plutôt que de la source. Pour cloner la diapositive avec maître, suivez les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) contenant la présentation source dont la diapositive sera clonée.
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) contenant la présentation de destination vers laquelle la diapositive sera clonée.
1. Accéder à la diapositive à cloner ainsi qu'à sa diapositive maîtresse.
1. Instancier la classe [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) en référant la collection Masters exposée par l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) de la présentation de destination.
1. Appeler la méthode [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposée par l'objet [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) et transmettre le maître du PPTX source à cloner comme paramètre à la méthode [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Instancier la classe [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) en définissant la référence à la collection Slides exposée par l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) de la présentation de destination.
1. Appeler la méthode [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) et transmettre la diapositive de la présentation source à cloner ainsi que la diapositive maîtresse comme paramètres à la méthode [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Enregistrer le fichier de présentation de destination modifié.

Dans l'exemple ci‑dessus, nous avons cloné une diapositive avec maître (située à l'index zéro de la présentation source) à la fin de la présentation de destination en utilisant le maître de la diapositive source.
```java
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

        // Cloner la diapositive maîtresse souhaitée de la présentation source vers la collection de maîtres dans la
        // Présentation de destination
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Cloner la diapositive maîtresse souhaitée de la présentation source vers la collection de maîtres dans la
        // Présentation de destination
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Cloner la diapositive souhaitée de la présentation source avec le maître souhaité à la fin de la
        // Collection de diapositives dans la présentation de destination
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
Si vous souhaitez cloner une diapositive puis l'utiliser dans le même fichier de présentation mais dans une section différente, utilisez la méthode [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) exposée par l'interface [**ISlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection). Aspose.Slides pour Android via Java permet de cloner une diapositive de la première section puis d'insérer cette diapositive clonée dans la deuxième section de la même présentation.

Le fragment de code suivant montre comment cloner une diapositive et insérer la diapositive clonée dans une section spécifiée.
```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Enregistrer la présentation de destination sur le disque
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **FAQ**

**Les notes du présentateur et les commentaires des réviseurs sont-ils clonés ?**

Oui. La page de notes et les commentaires de révision sont inclus dans le clone. Si vous ne les désirez pas, [supprimez‑les](/slides/fr/androidjava/presentation-notes/) après l'insertion.

**Comment les graphiques et leurs sources de données sont‑ils gérés ?**

L'objet graphique, son formatage et les données intégrées sont copiés. Si le graphique était lié à une source externe (p. ex., un classeur OLE intégré), ce lien est conservé sous forme d'[objet OLE](/slides/fr/androidjava/manage-ole/). Après le déplacement entre fichiers, vérifiez la disponibilité des données et le comportement de rafraîchissement.

**Puis‑je contrôler la position d’insertion et les sections du clone ?**

Oui. Vous pouvez insérer le clone à un index de diapositive spécifique et le placer dans une [section](/slides/fr/androidjava/slide-section/) choisie. Si la section cible n’existe pas, créez‑la d’abord puis déplacez la diapositive dedans.