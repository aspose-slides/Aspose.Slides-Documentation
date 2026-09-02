---
title: Rendre les diapositives de présentation en images SVG en Java
linktitle: Diapositive en SVG
type: docs
weight: 50
url: /fr/java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint en SVG
- présentation en SVG
- diapositive en SVG
- PPT en SVG
- PPTX en SVG
- options d'export SVG
- SVG interactif
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Exportez les diapositives PowerPoint en images SVG en Java et contrôlez les polices, le texte, les images, les identifiants et les événements avec Aspose.Slides."
---
## **Aperçu**

SVG est un format d'image XML evolutif qui fonctionne bien pour la publication web, les visionneuses de diapositives, les flux de travail d'accessibilite et le post-traitement automatise. Aspose.Slides exporte chaque diapositive vers un fichier SVG distinct et vous permet de controler comment le texte, les polices, les images et les elements SVG sont ecrits.

Utilisez [SVGOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgoptions/) lorsque le SVG exporte doit etre compact, previsible sur tous les navigateurs ou pret pour une utilisation interactive.

## **Exporter une diapositive en SVG**

Creez une [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/), selectionnez une diapositive et ecrivez-la dans un flux avec [ISlide.writeAsSvg](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). L'exemple suivant exporte chaque diapositive d'une presentation sous forme de fichier SVG distinct.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

Le nom de fichier utilise [ISlide.getSlideNumber](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islide/#getSlideNumber--) plutot que l'indice de la boucle. Vous pouvez egalement exporter une forme individuelle avec [IShape.writeAsSvg](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) lorsqu'une visionneuse de diapositives ou une page Web ne nécessite que cette forme.

## **Configurer la sortie SVG**

[SVGOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgoptions/) controle le rendu SVG. Pour les cadres de texte, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) inclut le cadre de texte dans la zone de rendu, et [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) determine si la rotation du cadre est appliquee. Definissez [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) sur `true` lorsque le texte doit etre rendu sans ligatures.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Controler le texte et les polices**

### **Vectoriser tout le texte**

Definissez [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) sur `true` pour ecrire tout le texte de la diapositive sous forme de graphiques vectoriels. Cela elimine les dependances aux polices et rend le resultat visuel plus coherent entre les navigateurs, mais le texte n'est plus selectionnable ou recherchable en tant que texte SVG.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **Choisir la facon dont les polices externes sont gerees**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) utilise une valeur [SvgExternalFontsHandling](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgexternalfontshandling/) pour les polices chargees de facon externe. Choisissez `AddLinksToFontFiles` pour referencer des fichiers de police separes, `Embed` pour inclure les donnees de police dans le SVG, ou `Vectorize` pour rendre uniquement le texte qui utilise des polices externes sous forme de graphiques. Verifiez les licences de police avant d'incorporer les polices.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Reduire la taille des images integrees**

Utilisez [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) pour reduire la resolution des images integrees, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) pour omettre les zones source recadrees, et [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) pour controler la qualite d'encodage JPEG. Ces parametres reduisent la taille du fichier au prix d'une perte de fidelite ou de donnees d'image conservees.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Attribuer des ID stables aux formes et au texte**

Utilisez [ISvgShapeFormattingController](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isvgshapeformattingcontroller/) pour definir [ISvgShape.setId](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) pour chaque forme SVG. Pour definir egalement les valeurs [ISvgTSpan.setId](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) sur les elements de texte `tspan`, implémentez [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Assignez l'un ou l'autre controleur avec [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Le controleur suivant utilise [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--), qui est stable pendant la duree de vie de la forme, et un compteur repetable pour ses segments de texte. Cela rend les ID generes adaptes au post-traitement d'une presentation non modifiee.

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Ajouter des gestionnaires d'evenements SVG**

Dans un [ISvgShapeFormattingController](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isvgshapeformattingcontroller/), appelez [ISvgShape.setEventHandler](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) avec une valeur [SvgEvent](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgevent/) pour ajouter un gestionnaire d'evenement JavaScript a une forme exportee. Assignez le controleur avec [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) et definissez la fonction JavaScript dans la page ou le document SVG qui heberge le resultat.

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

La page hote peut definir la fonction JavaScript referencee par le gestionnaire. L'attribution d'ID et de gestionnaires d'evenements permet aux visionneuses de diapositives, aux ameliorations d'accessibilite et a d'autres flux de travail SVG interactifs.

## **FAQ**

**Quand faut-il utiliser [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) plutot que [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgexternalfontshandling/)?**

Utilisez [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) lorsque tout le texte doit etre independant des polices. Utilisez [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgexternalfontshandling/) lorsque seul le texte qui utilise des polices externes doit etre converti en graphiques.

**Quelle est la meilleure facon de reduire la taille d'un SVG?**

Commencez par compresser les images integrees, supprimer les zones d'image recadrees et choisir des fichiers de police lies lorsque l'environnement cible peut les fournir. Testez le resultat car une resolution d'image plus basse, une qualite JPEG reduite et le texte vectorise ont chacun des compromis differents en termes de qualite et de taille.

**Puis-je modifier les elements SVG exportes apres l'exportation?**

Oui. Assignez des ID via un controleur de formatage, puis selectionnez les elements SVG correspondants dans votre outil de post-traitement ou votre script de navigateur.