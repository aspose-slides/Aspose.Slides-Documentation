---
title: Cloner des diapositives
type: docs
weight: 35
url: /fr/androidjava/cloner-des-diapositives/
---


## **Cloner des diapositives dans une présentation**
Le clonage est le processus de création d'une copie exacte ou d'une réplique de quelque chose. Aspose.Slides pour Android via Java permet également de faire une copie ou un clone de n'importe quelle diapositive et de l'insérer dans la présentation actuelle ou dans toute autre présentation ouverte. Le processus de clonage de diapositive crée une nouvelle diapositive qui peut être modifiée par les développeurs sans changer la diapositive originale. Il existe plusieurs façons possibles de cloner une diapositive :

- Cloner à la fin d'une présentation.
- Cloner à une autre position dans la présentation.
- Cloner à la fin d'une autre présentation.
- Cloner à une autre position dans une autre présentation.
- Cloner à une position spécifique dans une autre présentation.

Dans Aspose.Slides pour Android via Java, (une collection d'objets [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) exposée par l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)) fournit les méthodes [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) et [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) pour effectuer les types de clonage de diapositives ci-dessus.

## **Cloner à la fin d'une présentation**
Si vous souhaitez cloner une diapositive et l'utiliser dans le même fichier de présentation à la fin des diapositives existantes, utilisez la méthode [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) selon les étapes énumérées ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) en vous référant à la collection de diapositives exposée par l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
3. Appelez la méthode [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) et passez la diapositive à cloner comme paramètre de la méthode [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
4. Écrivez le fichier de présentation modifié.

Dans l'exemple ci-dessous, nous avons cloné une diapositive (située à la première position – index zéro – de la présentation) à la fin de la présentation.

```java
// Instancier la classe Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Cloner la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Écrire la présentation modifiée sur le disque
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Cloner à une autre position dans une présentation**
Si vous souhaitez cloner une diapositive et l'utiliser dans le même fichier de présentation mais à une position différente, utilisez la méthode [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Instanciez la classe en vous référant à la collection [**Slides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) exposée par l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
3. Appelez la méthode [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) et passez la diapositive à cloner ainsi que l'index de la nouvelle position comme paramètre de la méthode [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
4. Écrivez la présentation modifiée sous forme de fichier PPTX.

Dans l'exemple ci-dessous, nous avons cloné une diapositive (située à l'index zéro – position 1 – de la présentation) à l'index 1 – Position 2 – de la présentation.

```java
// Instancier la classe Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Cloner la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation
    ISlideCollection slds = pres.getSlides();

    // Cloner la diapositive souhaitée à l'index spécifié dans la même présentation
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Écrire la présentation modifiée sur le disque
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Cloner à la fin dans une autre présentation**
Si vous devez cloner une diapositive d'une présentation et l'utiliser dans un autre fichier de présentation, à la fin des diapositives existantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) contenant la présentation dont la diapositive sera clonée.
2. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) contenant la présentation de destination à laquelle la diapositive sera ajoutée.
3. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) en vous référant à la collection de diapositives exposée par l'objet Presentation de la présentation de destination.
4. Appelez la méthode [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) et passez la diapositive de la présentation source comme paramètre de la méthode [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
5. Écrivez le fichier de présentation de destination modifié.

Dans l'exemple ci-dessous, nous avons cloné une diapositive (de l'index premier de la présentation source) à la fin de la présentation de destination.

```java
// Instancier la classe Presentation pour charger le fichier de présentation source
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instancier la classe Presentation pour la destination PPTX (où la diapositive doit être clonée)
    Presentation destPres = new Presentation();
    try {
        // Cloner la diapositive souhaitée de la présentation source à la fin de la collection de diapositives dans la présentation de destination
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Écrire la présentation de destination sur le disque
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Cloner à une autre position dans une autre présentation**
Si vous devez cloner une diapositive d'une présentation et l'utiliser dans un autre fichier de présentation, à une position spécifique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) contenant la présentation source dont la diapositive sera clonée.
2. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) contenant la présentation à laquelle la diapositive sera ajoutée.
3. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) en vous référant à la collection de diapositives exposée par l'objet Presentation de la présentation de destination.
4. Appelez la méthode [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) et passez la diapositive de la présentation source ainsi que la position souhaitée comme paramètre de la méthode [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
5. Écrivez le fichier de présentation de destination modifié.

Dans l'exemple ci-dessous, nous avons cloné une diapositive (de l'index zéro de la présentation source) à l'index 1 (position 2) de la présentation de destination.

```java
// Instancier la classe Presentation pour charger le fichier de présentation source
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instancier la classe Presentation pour la destination PPTX (où la diapositive doit être clonée)
    Presentation destPres = new Presentation();
    try {
        // Cloner la diapositive souhaitée de la présentation source à la fin de la collection de diapositives dans la présentation de destination
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Écrire la présentation de destination sur le disque
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Cloner à une position spécifique dans une autre présentation**
Si vous devez cloner une diapositive avec une diapositive maître d'une présentation et l'utiliser dans une autre présentation, vous devez d'abord cloner la diapositive maître souhaitée de la présentation source vers la présentation de destination. Ensuite, vous devez utiliser cette diapositive maître pour cloner la diapositive avec la diapositive maître. La méthode [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) attend une diapositive maître de la présentation de destination plutôt que de la présentation source. Afin de cloner la diapositive avec un maître, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) contenant la présentation source dont la diapositive sera clonée.
2. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) contenant la présentation de destination à laquelle la diapositive sera clonée.
3. Accédez à la diapositive à cloner ainsi qu'à la diapositive maître.
4. Instanciez la classe [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) en vous référant à la collection de maîtres exposée par l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) de la présentation de destination.
5. Appelez la méthode [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposée par l'objet [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) et passez le maître de la source PPTX à cloner comme paramètre de la méthode [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
6. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) en définissant la référence à la collection de diapositives exposée par l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) de la présentation de destination.
7. Appelez la méthode [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) et passez la diapositive de la présentation source à cloner et le maître comme paramètre de la méthode [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) méthode.
8. Écrivez le fichier de présentation de destination modifié.

Dans l'exemple ci-dessous, nous avons cloné une diapositive avec un maître (située à l'index zéro de la présentation source) à la fin de la présentation de destination en utilisant un maître de la diapositive source.

```java
// Instancier la classe Presentation pour charger le fichier de présentation source
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instancier la classe Presentation pour la présentation de destination (où la diapositive doit être clonée)
    Presentation destPres = new Presentation();
    try {
        // Instancier ISlide de la collection de diapositives dans la présentation source avec
        // Diapositive maître
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Cloner la diapositive maître souhaitée de la présentation source vers la collection de maîtres dans le
        // Présentation de destination
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Cloner la diapositive maître souhaitée de la présentation source vers la collection de maîtres dans le
        // Présentation de destination
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Cloner la diapositive souhaitée de la présentation source avec le maître souhaité à la fin de la
        // Collection de diapositives dans la présentation de destination
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Sauvegarder la présentation de destination sur le disque
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Cloner à la fin dans une section spécifique**
Si vous souhaitez cloner une diapositive et l'utiliser dans le même fichier de présentation mais à une section différente, utilisez la méthode [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) exposée par l'interface [**ISlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection). Aspose.Slides pour Android via Java permet de cloner une diapositive de la première section et d'insérer cette diapositive clonée dans la deuxième section de la même présentation.

Le snippet de code suivant montre comment cloner une diapositive et insérer la diapositive clonée dans une section spécifiée.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Sauvegarder la présentation de destination sur le disque
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```