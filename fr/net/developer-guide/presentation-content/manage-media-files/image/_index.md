---
title: Optimiser la gestion des images dans les présentations en .NET
linktitle: Gestion des images
type: docs
weight: 10
url: /fr/net/image/
keywords:
- ajouter une image
- ajouter une illustration
- remplacer une image
- collection d'images
- cadre d'image
- image liée
- arrière-plan
- ajouter PNG
- ajouter JPG
- ajouter SVG
- SVG en formes
- ressources SVG externes
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à ajouter, réutiliser, lier, remplacer et gérer les images raster et SVG dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour .NET."
---
## **Introduction**

Aspose.Slides for .NET offre plusieurs façons de travailler avec les images, chacune servant un objectif différent. Vous pouvez stocker une image dans une présentation, l’afficher dans un cadre d’image, l’utiliser comme arrière‑plan de diapositive, créer un lien vers une image externe, remplacer une ressource d’image partagée ou convertir le contenu SVG en formes modifiables.

Cet article se concentre sur les ressources d’image et sur la façon dont elles sont utilisées dans une présentation. Pour le recadrage, la transparence, les effets, l’étirement et d’autres mises en forme appliquées à un cadre d’image individuel, consultez [Picture Frame](/slides/fr/net/picture-frame/).

## **Comprendre le modèle d'image**

Les concepts d’API suivants sont étroitement liés mais ne sont pas interchangeables :

- La [presentation image collection](https://reference.aspose.com/slides/fr/net/aspose.slides/iimagecollection/) stocke les ressources d’image utilisées par la présentation. Utilisez [ImageCollection.AddImage](https://reference.aspose.com/slides/fr/net/aspose.slides/imagecollection/addimage/) pour ajouter les données d’image et obtenir une ressource [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/).
- Un [picture frame](https://reference.aspose.com/slides/fr/net/aspose.slides/ipictureframe/) est une forme qui affiche une image sur une diapositive, une disposition ou un masque. Utilisez [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/addpictureframe/) pour placer une ressource d’image sur une diapositive.
- Un arrière‑plan de diapositive utilise une image comme partie du remplissage de la diapositive plutôt que comme une forme. Il ne se comporte donc pas comme un cadre d’image.
- [IPPImage.ReplaceImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/replaceimage/) remplace une ressource d’image. Si plusieurs éléments de la présentation utilisent cette ressource, ils utilisent tous le remplacement.
- La conversion d’un SVG en formes crée des formes de diapositive modifiables. Après conversion, le contenu n’est plus géré en tant que ressource d’image unique.

Un flux de travail typique est donc : ajouter les données d’image à la collection d’images, recevoir un [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/), puis utiliser cette ressource dans un ou plusieurs cadres d’image ou remplissages.

## **Ajouter une image incorporée**

Pour insérer une image locale, lisez le fichier, ajoutez ses données à la collection d’images et créez un cadre d’image qui utilise le `IPPImage` retourné.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

L’image ajoutée de cette manière est incorporée dans la présentation, de sorte que le fichier résultant ne dépend pas de la disponibilité continue du fichier image d’origine.

### **Ajouter une image depuis le Web**

Lorsque une image est disponible via HTTP ou HTTPS, téléchargez ses octets avec `HttpClient`, ajoutez‑les à la collection d’images de la présentation et utilisez la ressource d’image retournée de la même manière qu’une image locale.

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

Dans les applications de longue durée, réutilisez `HttpClient` plutôt que de créer une nouvelle instance pour chaque requête. Validez également les URL distantes, les tailles de réponse et les types de contenu lorsque la source n’est pas fiable.

## **Réutiliser les images entre les diapositives**

Si la même image est nécessaire plusieurs fois, ajoutez‑la une fois à la présentation et réutilisez le [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) retourné lors de la création de cadres d’image supplémentaires. Cela évite de charger à plusieurs reprises les mêmes données sources et rend explicite la relation entre la ressource d’image partagée et ses utilisations.

Pour les graphiques qui doivent apparaître automatiquement sur de nombreuses diapositives, comme le logo d’une entreprise, envisagez de placer le cadre d’image sur un [slide master](/slides/fr/net/slide-master/) ou une disposition plutôt que d’ajouter une forme équivalente à chaque diapositive.

## **Utiliser une image comme arrière‑plan de diapositive**

Une image d’arrière‑plan est affectée au remplissage de la diapositive ; elle n’est pas ajoutée comme forme de cadre d’image. Cela est utile lorsque l’image doit couvrir l’arrière‑plan de la diapositive et ne doit pas être manipulée comme un objet de diapositive normal.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

Pour d’autres options d’arrière‑plan, y compris les arrière‑plans de masques et de dispositions, consultez [Presentation Background](/slides/fr/net/presentation-background/).

## **Images incorporées et images liées**

Les images incorporées et les images liées présentent des compromis différents en termes de portabilité et de taille de fichier :

- **Image incorporée :** les données de l’image sont stockées à l’intérieur de la présentation. La présentation est autonome, mais la taille du fichier inclut les données de l’image.
- **Image liée :** la présentation stocke un chemin ou une URL vers une image externe. Cela peut réduire la taille de la présentation, mais la ressource externe doit rester accessible lorsque la présentation est ouverte ou rendue.

Une image liée peut être créée en attribuant le chemin ou l’URL externe via [ISlidesPicture.LinkPathLong](https://reference.aspose.com/slides/fr/net/aspose.slides/islidespicture/linkpathlong/) plutôt qu’en incorporant les données de l’image.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Utilisez les images liées uniquement lorsque l’environnement de déploiement peut accéder de manière fiable à la ressource externe. Pour les présentations qui doivent fonctionner hors ligne ou être déplacées entre systèmes, les images incorporées sont généralement plus sûres.

## **Travailler avec des images SVG**

SVG est un format vectoriel, il peut donc être utile pour les icônes, diagrammes et autres graphiques qui doivent se mettre à l’échelle sans la même perte de détail que les images matricielles. Aspose.Slides prend en charge le SVG à la fois comme ressource d’image et comme source de formes de diapositive modifiables.

### **Ajouter un SVG en tant qu’image**

Créez un [SvgImage](https://reference.aspose.com/slides/fr/net/aspose.slides/svgimage/), ajoutez‑le à la collection d’images et placez la ressource d’image résultante dans un cadre d’image.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **Fichiers SVG avec ressources externes**

Un SVG peut référencer des images externes, des feuilles de style ou des polices. Dans ces cas, [SvgImage](https://reference.aspose.com/slides/fr/net/aspose.slides/svgimage/) propose des constructeurs qui acceptent un [IExternalResourceResolver](https://reference.aspose.com/slides/fr/net/aspose.slides.import/iexternalresourceresolver/) et une URI de base. Le résolveur peut mapper une URI relative vers une URI absolue autorisée et renvoyer un flux pour la ressource demandée.

Le résolveur rend les ressources externes disponibles pendant que Aspose.Slides traite le SVG, mais il ne réécrit pas le SVG en un document autonome. Si le SVG doit rester portable, incorporez les ressources nécessaires dans le SVG lui‑même, par exemple en utilisant des URI `data:` pour les images liées.

Lorsque les fichiers SVG proviennent de sources non fiables, restreignez les schémas, emplacements de fichiers et hôtes que le résolveur peut accéder. Les résolveurs réseau doivent également appliquer des délais d’attente, des limites de taille de réponse et une validation du contenu.

### **Convertir un SVG en formes modifiables**

Aspose.Slides peut convertir un SVG en un groupe de formes de diapositive modifiables, similaire à la commande correspondante de PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Utilisez la surcharge [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/addgroupshape/) qui accepte un [ISvgImage](https://reference.aspose.com/slides/fr/net/aspose.slides/isvgimage/) pour effectuer la conversion.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

Utilisez la conversion SVG‑vers‑formes lorsque les éléments vectoriels individuels doivent être édités comme des formes PowerPoint. Si le SVG ne doit être affiché que, le garder comme image est plus simple et évite de créer de nombreuses formes séparées.

## **Remplacer une ressource d’image existante**

Utilisez [IPPImage.ReplaceImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/replaceimage/) lorsque vous souhaitez remplacer une ressource d’image existante. Ceci est particulièrement utile pour les graphiques partagés tels que les logos.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Si plusieurs cadres d’image, arrière‑plans, masques ou dispositions utilisent la même ressource d’image, remplacer cette ressource met à jour toutes ces utilisations. Si un seul cadre d’image doit être modifié, attribuez une image différente à ce cadre plutôt que de remplacer la ressource partagée.

`ReplaceImage` propose également des surcharges qui acceptent un [IImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/) ou un autre [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/).

## **Guide pratique de gestion des images**

### **Contrôler la taille de la présentation**

Les grosses images matricielles peuvent rendre une présentation inutilement volumineuse. Utilisez des images sources dont les dimensions sont appropriées à la taille d’affichage prévue, réutilisez les ressources d’image partagées dans la mesure du possible et évitez d’incorporer plusieurs copies du même graphique en pleine résolution.

Pour les images matricielles déjà placées dans des cadres d’image, [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ipicturefillformat/compressimage/) peut réduire les données d’image en fonction de la résolution sélectionnée et des paramètres de recadrage. Il s’agit d’un traitement de cadre d’image plutôt que d’une gestion de la collection d’images, consultez donc [Picture Frame](/slides/fr/net/picture-frame/) pour les opérations de mise en forme associées.

### **Choisir entre contenu incorporé et lié**

L’incorporation rend la présentation portable car toutes les données d’image requises voyagent avec le fichier. Le lien peut réduire la taille du fichier, mais il introduit une dépendance externe. Utilisez les liens uniquement lorsque cette dépendance est acceptable et stable.

### **Réutiliser la marque partagée**

Pour les logos, filigranes ou graphiques décoratifs répétés, utilisez une seule ressource d’image et réutilisez‑la. Si le graphique fait partie du design de la présentation plutôt que du contenu des diapositives, placez‑le sur un masque ou une disposition afin qu’il soit hérité par les diapositives appropriées.

### **Conserver la portabilité des ressources SVG**

Un SVG autonome est plus facile à déplacer et à rendre de manière cohérente qu’un SVG qui dépend de fichiers externes ou de ressources réseau. Lorsque cela est possible, incorporez les ressources requises avant d’importer le SVG. Convertissez le SVG en formes uniquement lorsque les éléments vectoriels individuels doivent être modifiés.

### **Utiliser l’API d’image multiplateforme moderne**

Pour le nouveau code .NET, utilisez les API Aspose.Slides [IImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/) et [Images](https://reference.aspose.com/slides/fr/net/aspose.slides/images/) plutôt que de vous appuyer sur `System.Drawing.Image` ou `Bitmap`. Consultez [Modern API](/slides/fr/net/modern-api/) pour les conseils de migration.

WMF et EMF nécessitent une considération spéciale. Lorsque ces formats sont transmis via un [IImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/), [ImageCollection.AddImage](https://reference.aspose.com/slides/fr/net/aspose.slides/imagecollection/addimage/) convertit le métafichier en une représentation PNG matricielle avant l’insertion. Si la conservation des données du métafichier est importante, utilisez une surcharge [ImageCollection.AddImage](https://reference.aspose.com/slides/fr/net/aspose.slides/imagecollection/addimage/) basée sur un flux. La génération de contenu EMF à partir de feuilles de calcul ou d’autres produits constitue un flux d’intégration distinct et ne fait pas partie de cet article.

## **FAQ**

**Quelle est la différence entre la collection d’images et un cadre d’image ?**  
La collection d’images stocke des ressources d’image réutilisables. Un cadre d’image est une forme de diapositive qui affiche l’une de ces ressources et offre une mise en forme spécifique à l’image, comme le recadrage et les effets.

**Quelle est la meilleure façon de remplacer le même logo partout ?**  
Si le logo est déjà partagé en tant qu’une seule ressource d’image, remplacez cette ressource avec [IPPImage.ReplaceImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/replaceimage/). Pour une marque à l’échelle de la présentation, placer le logo sur un masque ou une disposition peut également réduire le contenu dupliqué des diapositives.

**Pourquoi une image liée disparaît‑elle sur un autre ordinateur ?**  
Une image liée dépend de son fichier ou URL externe. Si cette ressource ne peut pas être atteinte depuis l’autre ordinateur, l’image liée peut être indisponible. Incorporez l’image lorsque la présentation doit être autonome.

**Une SVG insérée peut‑elle être modifiée comme des formes PowerPoint ?**  
Oui. Convertissez le SVG avec [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/addgroupshape/) ; le groupe résultant contient des formes de diapositive modifiables plutôt qu’une seule image SVG.

**Comment puis‑je garder les présentations contenant de nombreuses images plus petites ?**  
Réutilisez les ressources d’image partagées, évitez les sources matricielles inutilement volumineuses, compressez les images matricielles appropriées lorsque cela est pertinent, conservez les éléments de marque répétés sur les masques ou les dispositions, et utilisez les images liées uniquement lorsqu’une dépendance externe est acceptable.