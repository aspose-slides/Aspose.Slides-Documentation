---
title: Modifier la taille et l'orientation de la page de notes dans .NET
linktitle: Taille de la page de notes
type: docs
weight: 10
url: /fr/net/notes-size/
keywords:
- taille de la page de notes
- orientation des notes
- notes en paysage
- notes en portrait
- taille du feuillet
- PowerPoint
- présentation
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Lire et modifier les dimensions de la page de notes dans Aspose.Slides pour .NET, changer l'orientation, vérifier les tailles enregistrées, et exporter les notes ou les feuillets en PDF et images."
---
## **Vue d'ensemble**

Utilisez [Presentation.NotesSize](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/notessize/) pour accéder aux paramètres de la page de notes de la présentation. Elle renvoie un objet [INotesSize](https://reference.aspose.com/slides/fr/net/aspose.slides/inotessize/) dont la propriété [Size](https://reference.aspose.com/slides/fr/net/aspose.slides/inotessize/size/) est modifiable. Bien que l'objet de paramètres lui‑même soit en lecture seule, vous pouvez affecter de nouvelles dimensions à sa propriété de taille.

La largeur et la hauteur sont spécifiées en **points**, avec 72 points par pouce. Par exemple, 900 × 600 points correspondent à 12,5 × 8⅓ pouces. Ces paramètres s’appliquent à la présentation, et non aux notes d’une diapositive individuelle.

| Paramètre | Objet |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/notessize/) | Contrôle les dimensions de la page de notes et les dimensions de page utilisées pour l’exportation des documents de main. |
| [Presentation.SlideSize](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/slidesize/) | Contrôle les dimensions des diapositives de présentation normales via [ISlideSize](https://reference.aspose.com/slides/fr/net/aspose.slides/islidesize/). |

Modifier l’un ou l’autre paramètre ne modifie pas automatiquement l’autre. Modifier l’orientation de la page de notes ne fait pas non plus pivoter les diapositives normales. Voir [Slide Size](/slides/fr/net/slide-size/) pour redimensionner les diapositives normales.

Les exemples ci‑dessous utilisent un fichier `sample.pptx` existant. Pour les exemples d’exportation, utilisez une présentation contenant au moins une diapositive avec des notes de présentateur. Chaque exemple peut être exécuté indépendamment.

## **Lire la taille et l’orientation de la page de notes**

Lisez la largeur et la hauteur et comparez‑les pour déterminer l’orientation : une page plus large est en mode paysage, une page plus haute est en mode portrait, et des dimensions égales décrivent une page carrée. Cet exemple affiche les dimensions réelles en points, sans supposer un format de papier standard.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **Passer en paysage sans modifier la taille du papier**

Pour ne modifier que l’orientation, échangez la largeur et la hauteur existantes. Cela préserve les longueurs des deux côtés, y compris celles d’un format de papier personnalisé. La condition ci‑dessous empêche qu’une page déjà en paysage soit basculée en portrait et laisse une page carrée inchangée.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

Pour l’orientation portrait, utilisez la même affectation lorsque `size.Width > size.Height`. Ne remplacez pas les dimensions A4 ou Letter, sauf si vous souhaitez également modifier la taille du papier.

## **Définir et vérifier une taille de page de notes personnalisée**

Affectez les deux dimensions simultanément, puis utilisez [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/) pour enregistrer la présentation. Cet exemple définit une page paysage de 900 × 600 points, l’enregistre au format PPTX, puis rouvre le fichier enregistré pour vérifier les valeurs persistées. La comparaison autorise une tolérance de 0,01 point pour les valeurs en virgule flottante ; ce n’est pas une garantie de précision pour chaque format de fichier.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

Le résultat attendu est `900 x 600 points` et `Size preserved: True`. Vérifier une présentation nouvellement ouverte confirme le fichier enregistré, plutôt que les seuls paramètres en mémoire.

## **Exporter les notes et les feuillets**

Les dimensions de la page définissent la zone disponible pour les mises en page des notes ou des feuillets. Elles n’activent pas ces mises en page seules : configurez également les options d’exportation. L’exportation des diapositives normales continue d’utiliser les dimensions des diapositives.

### **Exporter les notes en PDF et PNG**

Affectez [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/notescommentslayoutingoptions/) à [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/slideslayoutoptions/) pour inclure les notes dans le PDF. Cet exemple rend également la première diapositive avec notes en PNG à l’aide de [Slide.GetImage](https://reference.aspose.com/slides/fr/net/aspose.slides/slide/getimage/) et [RenderingOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/renderingoptions/).

Le mode [BottomTruncated](https://reference.aspose.com/slides/fr/net/aspose.slides.export/notespositions/) maintient les notes sur une seule page ; les notes qui ne tiennent pas peuvent être tronquées. Le PDF utilise des pages de 900 × 600 points. À l’échelle d’image de 1 × 1 utilisée ci‑dessus, le PNG mesure 900 × 600 pixels. Les points décrivent la géométrie de la page ; les pixels décrivent la sortie raster, dont les dimensions dépendent également de l’échelle de rendu.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

Pour l’exportation PDF avec des notes longues, [BottomFull](https://reference.aspose.com/slides/fr/net/aspose.slides.export/notespositions/) permet des pages supplémentaires selon les besoins. N’utilisez pas ce mode avec l’appel d’image d’une seule diapositive ci‑dessus, qui ne le prend pas en charge. Après le redimensionnement, examinez la sortie pour détecter les notes coupées et le placement des objets notes‑master existants ; modifier uniquement les dimensions de la page ne garantit pas que tout le contenu s’ajuste. Consultez [Convert PowerPoint to PDF with Notes](/slides/fr/net/convert-powerpoint-to-pdf-with-notes/) pour plus d’informations sur l’export des notes.

### **Exporter les feuillets en PDF**

Utilisez [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/handoutlayoutingoptions/) pour plusieurs vignettes de diapositives sur une page. L’exemple suivant définit une page de 900 × 600 points et utilise [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/fr/net/aspose.slides.export/handouttype/) pour disposer jusqu’à quatre diapositives par page. Le préréglage horizontal contrôle l’ordre des diapositives ; l’orientation de la page provient de sa largeur et de sa hauteur.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

Modifier la taille de la page modifie la zone disponible pour la grille du feuillet sans modifier les dimensions des diapositives sources. Pour les images de feuillets, utilisez [Presentation.GetImages](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/getimages/) avec la mise en page du feuillet, plutôt que la méthode d’image d’une diapositive individuelle. Dans Aspose.Slides, le rendu de feuillet au niveau de la présentation utilise les dimensions de la page de notes, tandis que l’appel d’image d’une diapositive individuelle ne produit pas la page du feuillet. Consultez [Handout Mode](/slides/fr/net/convert-powerpoint-in-handout-mode/) pour les options de mise en page.

## **Taille de page dans les visionneuses, l’exportation et l’impression**

Conservez séparément la taille de la présentation stockée, la taille de page exportée et la taille du papier imprimé :

- **Visionneuses de présentation :** Une visionneuse peut afficher ou imprimer les notes en utilisant ses propres règles de mise en page. Si une autre application enregistre le fichier, rouvrez‑le et vérifiez à nouveau les dimensions ; la conversion de format de cette application peut les normaliser.
- **Formats d’exportation :** Les exemples de PDF de notes et de feuillets ci‑dessus utilisent les dimensions de page configurées. Les images raster utilisent des dimensions en pixels entiers et une échelle de rendu, si bien que les valeurs fractionnaires de points peuvent être arrondies dans la sortie d’image. L’exportation des diapositives normales n’applique pas la taille de page des notes.
- **Pilotes d’imprimante :** La sélection du papier, la rotation automatique et les paramètres ajuster‑à‑la‑page peuvent modifier le rendu physique sans modifier les dimensions stockées dans la présentation ou le PDF. Pour un format de papier spécifique, alignez les paramètres de l’imprimante et examinez l’aperçu avant impression.

## **FAQ**

**Puis‑je définir la taille des notes pour une seule diapositive ?**

La taille de la page de notes est un paramètre au niveau de la présentation. Les diapositives individuelles peuvent contenir des notes différentes, mais cette propriété ne fournit pas de taille de page distincte pour chaque diapositive.

**Pourquoi le changement d’orientation des notes n’a‑t‑il pas modifié mes diapositives ?**

Les pages de notes et les diapositives normales ont des dimensions indépendantes. Utilisez les paramètres de taille de diapositive normale lorsque vous souhaitez redimensionner les diapositives elles‑mêmes.

**Pourquoi mon résultat enregistré ou imprimé a‑t‑il une taille différente ?**

Tout d’abord, rouvrez la présentation enregistrée et comparez ses dimensions de notes. Si elles ont changé, vérifiez si l’enregistrement ou la conversion du fichier dans une autre application a modifié les paramètres de page. Si ce n’est pas le cas, examinez la mise en page d’exportation, l’échelle de l’image, les paramètres du visionneur et la sélection du papier d’imprimante.