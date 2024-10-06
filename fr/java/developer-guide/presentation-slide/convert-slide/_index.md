---
title: Convertir Diapositive
type: docs
weight: 35
url: /java/convert-slide/
keywords: 
- convertir diapositive en image
- exporter diapositive en tant qu'image
- enregistrer diapositive en tant qu'image
- diapositive en image
- diapositive en PNG
- diapositive en JPEG
- diapositive en bitmap
- Java
- Aspose.Slides pour Java
description: "Convertir une diapositive PowerPoint en image (Bitmap, PNG ou JPG) en Java"
---

Aspose.Slides pour Java vous permet de convertir des diapositives (dans des présentations) en images. Voici les formats d'image pris en charge : BMP, PNG, JPG (JPEG), GIF et autres.

Pour convertir une diapositive en image, procédez comme suit :

1. Tout d'abord, définissez les paramètres de conversion et les objets diapositive à convertir en utilisant :
   * l'interface [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) ou
   * l'interface [IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/IRenderingOptions).

2. Deuxièmement, convertissez la diapositive en image en utilisant la méthode [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-).

## **À propos de Bitmap et d'autres formats d'image**

En Java, un [Images](https://reference.aspose.com/slides/java/com.aspose.slides/Images) est un objet qui vous permet de travailler avec des images définies par des données de pixels. Vous pouvez utiliser une instance de cette classe pour enregistrer des images dans une large gamme de formats (JPG, PNG, etc.).

{{% alert title="Info" color="info" %}}

Aspose a récemment développé un convertisseur [Texte en GIF](https://products.aspose.app/slides/text-to-gif) en ligne.

{{% /alert %}}

## **Conversion de diapositives en bitmap et enregistrement des images en PNG**

Ce code Java vous montre comment convertir la première diapositive d'une présentation en un objet bitmap, puis comment enregistrer l'image au format PNG :

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Convertit la première diapositive de la présentation en un objet Images
    IImage slideImage = pres.getSlides().get_Item(0).getImage();

	// Enregistre l'image au format PNG
	try {
        // enregistre l'image sur le disque.
         slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Ce code exemple vous montre comment convertir la première diapositive d'une présentation en un objet bitmap en utilisant la méthode [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) :

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
	// Obtient la taille de la diapositive de la présentation
	Dimension2D slideSize = new Dimension((int) slideSize.getWidth(), (int) slideSize.getHeight());

	// Crée un Images avec la taille de la diapositive
    IImage slideImage = sld.getImage(new RenderingOptions(), slideSize);
    try {
         // enregistre l'image sur le disque.
          slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Astuce" color="primary" %}} 

Vous pouvez convertir une diapositive en un objet Images puis utiliser l'objet directement quelque part. Ou vous pouvez convertir une diapositive en un Images et ensuite enregistrer l'image en JPEG ou dans tout autre format que vous préférez.

{{% /alert %}}  

## **Conversion de diapositives en images avec des tailles personnalisées**

Vous devrez peut-être obtenir une image d'une certaine taille. En utilisant une surcharge de la méthode [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-), vous pouvez convertir une diapositive en une image avec des dimensions spécifiques (longueur et largeur).

Ce code exemple démontre la conversion proposée en utilisant la méthode [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) en Java :

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Convertit la première diapositive de la présentation en un Bitmap avec la taille spécifiée
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1820, 1040));
	
	// Enregistre l'image au format JPEG
	try {
         // enregistre l'image sur le disque.
          slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Conversion de diapositives avec notes et commentaires en images**

Certaines diapositives contiennent des notes et des commentaires.

Aspose.Slides fournit deux interfaces—[ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) et [IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/IRenderingOptions)—qui vous permettent de contrôler le rendu des diapositives de présentation en images. Les deux interfaces hébergent l'interface [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions) qui vous permet d'ajouter des notes et des commentaires sur une diapositive lorsque vous convertissez cette diapositive en une image.

{{% alert title="Info" color="info" %}} 

Avec l'interface [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions), vous pouvez spécifier votre position préférée pour les notes et les commentaires dans l'image résultante. 

{{% /alert %}} 

Ce code Java démontre le processus de conversion d'une diapositive avec des notes et des commentaires :

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
    // Crée les options de rendu
    IRenderingOptions options = new RenderingOptions();

    // Définit la position des notes sur la page
    options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

    // Définit la position des commentaires sur la page 
    options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

    // Définit la largeur de la zone de sortie des commentaires
    options.getNotesCommentsLayouting().setCommentsAreaWidth(500);

    // Définit la couleur de la zone des commentaires
    options.getNotesCommentsLayouting().setCommentsAreaColor(Color.LIGHT_GRAY);

    // Convertit la première diapositive de la présentation en un objet Bitmap
    IImage slideImage = pres.getSlides().get_Item(0).getImage(options, 2f, 2f);

    // Enregistre l'image au format GIF
    try {
          slideImage.save("Slide_Notes_Comments_0.gif", ImageFormat.Gif);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Ce code Java démontre le processus de conversion d'une diapositive avec des notes en utilisant la méthode [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) :

``` java
Presentation pres = new Presentation("PresentationNotes.pptx");
try {
	// Obtient la taille des notes de la présentation
	Dimension2D notesSize = pres.getNotesSize().getSize();

	// Crée les options de rendu
	IRenderingOptions options = new RenderingOptions();

	// Définit la position des notes
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// Crée un Images avec la taille des notes
    IImage slideImage = pres.getSlides().get_Item(0).getImage(options, notesSize);

	// Enregistre l'image au format PNG
    try {
         // enregistre l'image sur le disque.
          slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Dans tout processus de conversion de diapositive en image, la propriété [NotesPositions](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions#setNotesPosition-int-) ne peut pas être définie sur BottomFull (pour spécifier la position des notes) car le texte d'une note peut être volumineux, ce qui signifie qu'il pourrait ne pas tenir dans la taille d'image spécifiée.

{{% /alert %}} 

## **Conversion de diapositives en images en utilisant ITiffOptions**

L'interface [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) vous donne plus de contrôle (en termes de paramètres) sur l'image résultante. En utilisant cette interface, vous pouvez spécifier la taille, la résolution, la palette de couleurs et d'autres paramètres pour l'image résultante. 

Ce code Java démontre un processus de conversion où ITiffOptions est utilisé pour produire une image en noir et blanc avec une résolution de 300dpi et une taille de 2160 × 2800 :

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
	// Obtient une diapositive par son index
	ISlide slide = pres.getSlides().get_Item(0);

	// Crée un objet TiffOptions
	TiffOptions options = new TiffOptions();
	options.setImageSize(new Dimension(2160, 2880));

	// Définit la police utilisée au cas où la police source ne serait pas trouvée
	options.setDefaultRegularFont("Arial Black");

	// Définit la position des notes sur la page
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// Définit le format de pixel (noir et blanc)
	options.setPixelFormat(ImagePixelFormat.Format1bppIndexed);

	// Définit la résolution
	options.setDpiX(300);
	options.setDpiY(300);

	// Convertit la diapositive en un objet Bitmap
	IImage slideImage = slide.getImage(options);

	// Enregistre l'image au format TIFF
	try {
          slideImage.save("PresentationNotesComments.tiff", ImageFormat.Tiff);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Le support Tiff n'est pas garanti dans les versions antérieures à JDK 9.

{{% /alert %}} 

## **Conversion de toutes les diapositives en images**

Aspose.Slides vous permet de convertir toutes les diapositives d'une seule présentation en images. En gros, vous pouvez convertir la présentation (dans son intégralité) en images.

Ce code exemple vous montre comment convertir toutes les diapositives d'une présentation en images en Java :

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Rendre la présentation sous forme de tableau d'images diapositive par diapositive
    for (int i = 0 ; i < pres.getSlides().size(); i++)
    {
        // Contrôler les diapositives cachées (ne pas rendre les diapositives cachées)
        if (pres.getSlides().get_Item(i).getHidden())
            continue;

        // Convertir la diapositive en un objet Bitmap
        IImage slideImage = pres.getSlides().get_Item(i).getImage(2f, 2f);

        // Enregistrer l'image au format PNG
        try {
              slideImage.save("Slide_" + i + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
} 
```