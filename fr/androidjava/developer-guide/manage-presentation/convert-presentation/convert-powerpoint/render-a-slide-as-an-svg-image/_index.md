---
title: Rendu des diapositives de présentation en images SVG sur Android
linktitle: Diapositive en SVG
type: docs
weight: 50
url: /fr/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint en SVG
- présentation en SVG
- diapositive en SVG
- PPT en SVG
- PPTX en SVG
- options d'exportation SVG
- SVG interactif
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Exportez les diapositives PowerPoint en images SVG sur Android et contrôlez les polices, le texte, les images, les identifiants et les événements avec Aspose.Slides."
---
## **Vue d'ensemble**

SVG est un format d'image XML extensible qui fonctionne bien pour la publication Web, les visionneuses de diapositives, les flux de travail d’accessibilité et le post‑traitement automatisé. Aspose.Slides for Android via Java exporte chaque diapositive vers un fichier SVG distinct et vous permet de contrôler la façon dont le texte, les polices, les images et les éléments SVG sont écrits.

Utilisez [SVGOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgoptions/) lorsque le SVG exporté doit être compact, prévisible sur tous les navigateurs ou prêt pour une utilisation interactive.

## **Exporter une diapositive au format SVG**

Créez une [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/), sélectionnez une diapositive et écrivez‑la dans un flux avec [ISlide.writeAsSvg](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). L’exemple suivant exporte chaque diapositive d’une présentation vers un fichier SVG distinct.

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

Le nom de fichier utilise [ISlide.getSlideNumber](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islide/#getSlideNumber--) plutôt que l’indice de boucle. Vous pouvez également exporter une forme individuelle avec [IShape.writeAsSvg](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) lorsqu’une visionneuse de diapositives ou une page Web ne nécessite que cette forme.

## **Configurer la sortie SVG**

[SVGOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgoptions/) contrôle le rendu du SVG. Pour les cadres de texte, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) inclut le cadre de texte dans la zone de rendu, et [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) détermine si la rotation du cadre est appliquée. Mettez [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) à `true` lorsque le texte doit être rendu sans ligatures.

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

## **Contrôler le texte et les polices**

### **Vectoriser tout le texte**

Définissez [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) sur `true` pour écrire tout le texte de la diapositive sous forme de graphiques vectoriels. Cela élimine les dépendances aux polices et rend le résultat visuel plus cohérent entre les navigateurs, mais le texte n’est plus sélectionnable ni recherchable en tant que texte SVG.

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

### **Choisir la gestion des polices externes**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) utilise une valeur [SvgExternalFontsHandling](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgexternalfontshandling/) pour les polices chargées de façon externe. Choisissez [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgexternalfontshandling/) pour référencer des fichiers de police séparés, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgexternalfontshandling/) pour inclure les données de police dans le SVG, ou [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgexternalfontshandling/) pour rendre uniquement le texte qui utilise des polices externes comme des graphiques. Vérifiez les licences de police avant d’incorporer les polices.

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

## **Réduire la taille des images incorporées**

Utilisez [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) pour réduire la résolution des images incorporées, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) pour omettre les zones recadrées des sources, et [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) pour contrôler la qualité d’encodage JPEG. Ces paramètres réduisent la taille du fichier au prix d’une perte de fidélité ou de données d’image conservées.

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

## **Attribuer des identifiants stables aux formes et au texte**

Utilisez [ISvgShapeFormattingController](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) pour définir [ISvgShape.setId](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) pour chaque forme SVG. Pour définir les valeurs [ISvgTSpan.setId](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) sur les éléments `tspan` du texte également, implémentez [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Assignez l’un ou l’autre contrôleur avec [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Le contrôleur suivant utilise [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) qui est stable pendant toute la durée de vie de la forme, ainsi qu’un compteur répétable pour ses spans de texte. Cela rend les identifiants générés adaptés au post‑traitement d’une présentation inchangée.

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

## **Ajouter des gestionnaires d’événements SVG**

Dans un [ISvgShapeFormattingController](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isvgshapeformattingcontroller/), appelez [ISvgShape.setEventHandler](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) avec une valeur [SvgEvent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgevent/) pour ajouter un gestionnaire d’événement JavaScript à une forme exportée. Assignez le contrôleur avec [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) et définissez la fonction JavaScript dans la page ou le document SVG qui héberge le résultat.

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

La page hôte peut définir la fonction JavaScript référencée par le gestionnaire. L’attribution d’identifiants et de gestionnaires d’événements permet aux visionneuses de diapositives, aux améliorations d’accessibilité et à d’autres flux de travail SVG interactifs.

## **FAQ**

**Quand faut‑il utiliser [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) au lieu de [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

Utilisez [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) lorsque tout le texte doit être indépendant des polices. Utilisez [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgexternalfontshandling/) lorsque seul le texte qui utilise des polices externes doit être converti en graphiques.

**Quelle est la meilleure façon de réduire la taille d’un SVG?**

Commencez par compresser les images incorporées, supprimer les zones d’image recadrées et choisir des fichiers de police liés lorsque l’environnement cible peut les fournir. Testez le résultat car une résolution d’image plus basse, une qualité JPEG inférieure et le texte vectorisé ont chacun des compromis différents entre qualité et taille.

**Puis‑je modifier les éléments SVG exportés après l’exportation?**

Oui. Attribuez des identifiants via un contrôleur de mise en forme, puis sélectionnez les éléments SVG correspondants dans votre outil de post‑traitement ou script de navigateur.