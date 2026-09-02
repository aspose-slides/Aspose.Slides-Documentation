---
title: Rendre des diapositives de présentation en images SVG dans .NET
linktitle: Diapositive en SVG
type: docs
weight: 50
url: /fr/net/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint vers SVG"
- "présentation vers SVG"
- "diapositive vers SVG"
- "PPT en SVG"
- "PPTX en SVG"
- "options d'exportation SVG"
- "SVG interactif"
- "PowerPoint"
- "présentation"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Exportez les diapositives PowerPoint en images SVG dans .NET et contrôlez les polices, le texte, les images, les ID et les événements avec Aspose.Slides."
---
## **Vue d'ensemble**

SVG est un format d'image extensible basé sur XML qui fonctionne bien pour la publication Web, les visionneuses de diapositives, les flux de travail d'accessibilite et le post-processing automatise. Aspose.Slides exporte chaque diapositive vers un fichier SVG distinct et vous permet de controler la facon dont le texte, les polices, les images et les elements SVG sont ecrits.

Utilisez [SVGOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/svgoptions/) lorsque le SVG exporte doit etre compact, previsible sur tous les navigateurs, ou pret pour une utilisation interactive.

## **Exporter une diapositive au format SVG**

Creez une [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/), selectionnez une diapositive et ecrivez-la dans un flux. L'exemple suivant exporte chaque diapositive d'une presentation sous forme de fichier SVG distinct.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Le nom de fichier utilise [ISlide.SlideNumber](https://reference.aspose.com/slides/fr/net/aspose.slides/islide/slidenumber/) pluto que l'index de la boucle. Vous pouvez egalement exporter une forme individuelle avec [IShape.WriteAsSvg](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/writeassvg/) lorsqu'une visionneuse de diapositives ou une page Web ne necessite que cette forme.

## **Configurer la sortie SVG**

[SVGOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/svgoptions/) controle le rendu SVG. Pour les zones de texte, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/fr/net/aspose.slides.export/svgoptions/useframesize/) inclut le cadre de texte dans la zone de rendu, et [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/fr/net/aspose.slides.export/svgoptions/useframerotation/) determine si la rotation du cadre est appliquee. Reglez [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/fr/net/aspose.slides.export/svgoptions/disablefontligatures/) sur `true` lorsque le texte doit etre rendu sans ligatures.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    DisableFontLigatures = true,
    UseFrameSize = true,
    UseFrameRotation = false
};

using var svgStream = File.Create("slide-with-custom-options.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Controler le texte et les polices**

### **Vectoriser tout le texte**

Definissez [SVGOptions.VectorizeText](https://reference.aspose.com/slides/fr/net/aspose.slides.export/svgoptions/vectorizetext/) sur `true` pour ecrire tout le texte des diapositives sous forme de graphiques vectoriels. Cela elimine les dependances aux polices et rend le rendu visuel plus coherent entre les navigateurs, mais le texte n'est plus selectionnable ni rechercheable en tant que texte SVG.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    VectorizeText = true
};

using var svgStream = File.Create("slide-with-vectorized-text.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

### **Choisir la maniere dont les polices externes sont gerees**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/fr/net/aspose.slides.export/svgoptions/externalfontshandling/) utilise une valeur [SvgExternalFontsHandling](https://reference.aspose.com/slides/fr/net/aspose.slides.export/svgexternalfontshandling/) pour les polices charges de facon externe. Choisissez `AddLinksToFontFiles` pour referencer des fichiers de police separes, `Embed` pour inclure les donnees de police dans le SVG, ou `Vectorize` pour rendre uniquement le texte qui utilise des polices externes sous forme de graphiques. Verifiez les licences de police avant d'integrer les polices.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var linkedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.AddLinksToFontFiles
};

using var linkedFontsStream = File.Create("slide-with-font-links.svg");
presentation.Slides[0].WriteAsSvg(linkedFontsStream, linkedFontsOptions);

var embeddedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Embed
};

using var embeddedFontsStream = File.Create("slide-with-embedded-fonts.svg");
presentation.Slides[0].WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);

var vectorizedExternalFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Vectorize
};

using var vectorizedExternalFontsStream = File.Create("slide-with-vectorized-external-fonts.svg");
presentation.Slides[0].WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
```

## **Reduire la taille des images incorporees**

Utilisez [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/fr/net/aspose.slides.export/svgoptions/picturescompression/) pour reduire la resolution des images incorporees, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/fr/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) pour omettre les zones source decoupees, et [SVGOptions.JpegQuality](https://reference.aspose.com/slides/fr/net/aspose.slides.export/svgoptions/jpegquality/) pour controler la qualite d'encodage JPEG. Ces parametres reduisent la taille du fichier au detriment de la fidelite de l'image ou des donnees d'image conservees.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    PicturesCompression = PicturesCompression.Dpi150,
    DeletePicturesCroppedAreas = true,
    JpegQuality = 80
};

using var svgStream = File.Create("compressed-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Attribuer des IDs stables aux formes et au texte**

Utilisez [ISvgShapeFormattingController](https://reference.aspose.com/slides/fr/net/aspose.slides.export/isvgshapeformattingcontroller/) pour definir [ISvgShape.Id](https://reference.aspose.com/slides/fr/net/aspose.slides.export/isvgshape/id/) pour chaque forme SVG. Pour definir egalement les valeurs [ISvgTSpan.Id](https://reference.aspose.com/slides/fr/net/aspose.slides.export/isvgtspan/id/) sur les elements `tspan` de texte, implémentez [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/fr/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Assignez l'un ou l'autre controleur avec [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/fr/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

Le controleur suivant utilise [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/officeinteropshapeid/), qui est stable pendant la duree de vie de la forme, ainsi qu'un compteur reutilisable pour ses intervalles de texte. Cela rend les IDs genenres adaptes au post-processing d'une presentation non modifiee.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new StableSvgIdController()
};

using var svgStream = File.Create("slide-with-stable-ids.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class StableSvgIdController : ISvgShapeAndTextFormattingController
{
    private string currentShapeId = string.Empty;
    private int textSpanIndex;

    public ISvgShapeFormattingController AsISvgShapeFormattingController => this;

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        currentShapeId = $"shape-{shape.OfficeInteropShapeId}";
        textSpanIndex = 0;
        svgShape.Id = currentShapeId;
    }

    public void FormatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame)
    {
        svgTSpan.Id = $"{currentShapeId}-text-{textSpanIndex++}";
    }
}
```

## **Ajouter des gestionnaires d'evenements SVG**

Dans un [ISvgShapeFormattingController](https://reference.aspose.com/slides/fr/net/aspose.slides.export/isvgshapeformattingcontroller/), appelez [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/fr/net/aspose.slides.export/isvgshape/seteventhandler/) avec une valeur [SvgEvent](https://reference.aspose.com/slides/fr/net/aspose.slides.export/svgevent/) pour ajouter un gestionnaire d'evenement JavaScript a une forme exportee. Assignez le controleur avec [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/fr/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) et definiissez la fonction JavaScript dans la page ou le document SVG qui heberge le resultat.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new SvgEventController()
};

using var svgStream = File.Create("interactive-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class SvgEventController : ISvgShapeFormattingController
{
    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        if (shape.Name == "ActionButton")
        {
            svgShape.Id = "action-button";
            svgShape.SetEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}
```

La page hote peut definir la fonction JavaScript referencee par le gestionnaire. L'assignation d'IDs et de gestionnaires d'evenements permet aux visionneuses de diapositives, aux ameliorations d'accessibilite et a d'autres flux de travail SVG interactifs.

## **FAQ**

**Quand devrais-je utiliser [SVGOptions.VectorizeText](https://reference.aspose.com/slides/fr/net/aspose.slides.export/svgoptions/vectorizetext/) au lieu de [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fr/net/aspose.slides.export/svgexternalfontshandling/)?**

Utilisez [SVGOptions.VectorizeText](https://reference.aspose.com/slides/fr/net/aspose.slides.export/svgoptions/vectorizetext/) lorsque tout le texte doit etre independant des polices. Utilisez [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fr/net/aspose.slides.export/svgexternalfontshandling/) lorsque seul le texte qui utilise des polices externes doit être converti en graphiques.

**Quelle est la meilleure facon de reduire la taille d’un SVG ?**

Commencez par compresser les images incorporees, supprimer les zones d’image decoupees et choisir des fichiers de police lies lorsque l’environnement cible peut les fournir. Testez le resultat car la reduction de la resolution des images, la qualite JPEG moindre et le texte vectorise ont chacun des compromis differents entre qualite et taille.

**Puis-je modifier les elements SVG exportes apres l’exportation ?**

Oui. Attribuez des IDs via un controleur de formatage, puis selectionnez les elements SVG correspondants dans votre outil de post-processing ou script de navigateur.