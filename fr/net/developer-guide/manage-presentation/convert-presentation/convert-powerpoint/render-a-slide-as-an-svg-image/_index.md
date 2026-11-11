---
title: Rendu des diapositives de présentation en images SVG sous .NET
linktitle: Diapositive en SVG
type: docs
weight: 50
url: /fr/net/render-a-slide-as-an-svg-image/
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
- .NET
- C#
- Aspose.Slides
description: "Exportez des diapositives PowerPoint en images SVG sous .NET et contrôlez les polices, le texte, les images, les ID et les événements avec Aspose.Slides."
---
## **Vue d'ensemble**

SVG est un format d'image évolutif basé sur XML qui fonctionne bien pour la publication Web, les visionneuses de diapositives, les flux de travail d'accessibilité et le post‑traitement automatisé. Aspose.Slides exporte chaque diapositive vers un fichier SVG séparé et vous permet de contrôler la façon dont le texte, les polices, les images et les éléments SVG sont écrits.

Utilisez [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) lorsque le SVG exporté doit être compact, prévisible sur tous les navigateurs ou prêt à être utilisé de manière interactive.

## **Exporter une diapositive au format SVG**

Créez une [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), sélectionnez une diapositive et écrivez‑la dans un flux. L’exemple suivant exporte chaque diapositive d’une présentation sous forme de fichier SVG séparé.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Le nom de fichier utilise [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) plutôt que l’index de boucle. Vous pouvez également exporter une forme individuelle avec [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) lorsqu’une visionneuse de diapositives ou une page Web ne nécessite que cette forme.

## **Configurer la sortie SVG**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) contrôle le rendu SVG. Pour les zones de texte, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) inclut le cadre de texte dans la zone de rendu, et [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) détermine si la rotation du cadre est appliquée. Réglez [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) sur `true` lorsque le texte doit être rendu sans ligatures.

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

## **Contrôler le rognage d’extrémité de ligne aux pointes de flèche**

SVG 1.1 ne possède aucun paramètre d’insertion de marqueur pour spécifier où une ligne doit s’arrêter sous une pointe de flèche. Par défaut, Aspose.Slides raccourcit la ligne exportée afin que son tracé ne dépasse pas le marqueur. Réglez [SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/) sur `true` pour dessiner le tracé jusqu’à l’extrémité d’origine de la ligne. Ce paramètre n’affecte que la sortie SVG. La ligne conserve sa position et sa longueur sur la diapositive.

L’exemple trace des pointes de flèche triangle et losange sur des lignes de 2 et 10 points de largeur. Il exporte la même diapositive deux fois, ne modifiant que l’option de rognage.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var y = 40;

foreach (var style in new[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond })
{
    foreach (var width in new[] { 2, 10 })
    {
        var line = slide.Shapes.AddAutoShape(ShapeType.Line, 40, y, 200, 0);
        var format = line.LineFormat;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        format.Width = width;
        format.EndArrowheadStyle = style;
        y += 50;
    }
}

var options = new SVGOptions { DisableLineEndCropping = false };
using var cropped = File.Create("cropped.svg");
slide.WriteAsSvg(cropped, options);

options.DisableLineEndCropping = true;
using var uncropped = File.Create("uncropped.svg");
slide.WriteAsSvg(uncropped, options);
```

La comparaison montre la pointe de flèche triangulaire sur la ligne de 10 points. Avec le rognage activé, la pointe est nette. Avec le rognage désactivé, le tracé dépasse les côtés inclinés du marqueur et laisse une extrémité plate.

![Triangle agrandi de 10 points avec une pointe nette quand le rognage est activé et une extrémité plate quand le rognage est désactivé](line-end-cropping.png)

Dans les autres lignes de l’exemple, le tracé dépassant est moins visible sur le triangle de 2 points. Le losange rempli couvre l’extrémité du tracé à deux largeurs.

## **Contrôler le texte et les polices**

Lors de l’exportation de diapositives au format SVG, vous pouvez contrôler si le texte reste du texte ou est converti en graphiques vectoriels, ainsi que la façon dont les polices externes sont incluses ou référencées. Les options suivantes vous aident à équilibrer la cohérence visuelle, la sélection du texte et les dépendances de police dans le SVG exporté.

### **Vectoriser tout le texte**

Réglez [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) sur `true` pour écrire tout le texte de la diapositive sous forme de graphiques vectoriels. Cela élimine les dépendances de police et rend le rendu visuel plus cohérent sur les navigateurs, mais le texte n’est plus sélectionnable ni searchable en tant que texte SVG.

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

### **Choisir la façon dont les polices externes sont gérées**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) utilise une valeur [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) pour les polices chargées externement. Choisissez `AddLinksToFontFiles` pour référencer des fichiers de police séparés, `Embed` pour inclure les données de police dans le SVG, ou `Vectorize` pour rendre uniquement le texte utilisant des polices externes sous forme de graphiques. Vérifiez la licence des polices avant de les intégrer.

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

## **Réduire la taille des images intégrées**

Utilisez [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) pour réduire la résolution des images intégrées, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) pour omettre les zones source recadrées, et [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) pour contrôler la qualité d’encodage JPEG. Ces paramètres réduisent la taille du fichier au prix de la fidélité de l’image ou des données d’image conservées.

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

## **Contrôler la résolution de rasterisation des métafichiers**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) définit la limite de résolution minimale pour la rasterisation des métafichiers lors de l’exportation SVG. Utilisez‑le pour équilibrer le détail et la taille du fichier lorsqu’une image EMF ou WMF est rasterisée. Il ne définit pas de DPI global pour le SVG ni ne force chaque objet de la diapositive à devenir une image raster.

Téléchargez [metafile-rasterization.pptx](metafile-rasterization.pptx), qui contient une image EMF avec des lignes diagonales très rapprochées. L’exemple suivant exporte sa première diapositive à trois résolutions de rasterisation via [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). Tous les autres paramètres d’exportation restent identiques afin de pouvoir comparer les résultats.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("metafile-rasterization.pptx");

foreach (var dpi in new[] { 72, 150, 300 })
{
    var svgOptions = new SVGOptions
    {
        MetafileRasterizationDpi = dpi,
        PicturesCompression = PicturesCompression.Dpi330,
        JpegQuality = 90
    };

    using var svgStream = File.Create($"slide-{dpi}.svg");
    presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
}
```

Dans la sortie, l’EMF est devenu un PNG intégré dans chaque SVG. Les mesures suivantes concernent la présentation fournie ; elles ne constituent pas une formule générale de conversion DPI → dimensions en pixels.

| DPI de rasterisation du métafichier | Dimensions du PNG intégré | Taille du fichier SVG (octets) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

La comparaison ci‑dessous montre la même zone du raster intégré à la même taille d’affichage agrandie. Les lignes diagonales montrent une pixelisation visible à 72 DPI et des bords plus lisses à des résolutions supérieures, tandis que le fichier SVG augmente. Augmenter la valeur n’améliore pas nécessairement chaque détail ou ne change pas chaque image exportée.

![Détail agrandi de lignes diagonales à 72, 150 et 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) contrôle la réduction de la résolution des images et peut masquer l’effet du changement de résolution de rasterisation du métafichier. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) contrôle la qualité d’encodage JPEG, pas la résolution de rasterisation du métafichier.

## **Attribuer des ID stables aux formes et au texte**

Utilisez [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) pour définir [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) pour chaque forme SVG. Pour définir également les valeurs [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) sur les éléments texte `tspan`, implémentez [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Assignez l’un ou l’autre contrôleur avec [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

Le contrôleur suivant utilise [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/), qui reste stable pendant la durée de vie de la forme, ainsi qu’un compteur répétable pour ses fragments de texte. Cela rend les ID générés adaptés au post‑traitement d’une présentation non modifiée.

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

## **Ajouter des gestionnaires d’événements SVG**

Dans un [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/), appelez [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) avec une valeur [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) pour ajouter un gestionnaire d’événement JavaScript à une forme exportée. Assignez le contrôleur avec [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) et définissez la fonction JavaScript dans la page ou le document SVG qui héberge le résultat.

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

La page hôte peut définir la fonction JavaScript référencée par le gestionnaire. L’attribution d’ID et de gestionnaires d’événements permet aux visionneuses de diapositives, aux améliorations d’accessibilité et à d’autres flux de travail SVG interactifs.

## **FAQ**

**Quand devrais‑je utiliser [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) au lieu de [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**

Utilisez [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) lorsque tout le texte doit être indépendant des polices. Utilisez [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) lorsque seul le texte utilisant des polices externes doit être converti en graphiques.

**Quelle est la meilleure façon de rendre un SVG plus petit?**

Commencez par compresser les images intégrées, supprimer les zones d’image recadrées, et choisir des fichiers de police liés lorsque l’environnement cible peut les fournir. Testez le résultat car une résolution d’image plus faible, une qualité JPEG réduite et le texte vectorisé ont chacun des compromis différents en termes de qualité et de taille.

**Puis‑je modifier les éléments SVG exportés après l’exportation?**

Oui. Assignez des ID via un contrôleur de formatage, puis sélectionnez les éléments SVG correspondants dans votre outil de post‑traitement ou script de navigateur.