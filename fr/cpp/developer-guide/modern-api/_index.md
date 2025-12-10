---
title: Améliorer le traitement d'images avec l'API Moderne
linktitle: API Moderne
type: docs
weight: 280
url: /fr/cpp/modern-api/
keywords:
- System.Drawing
- API moderne
- dessin
- vignette de diapositive
- diapositive en image
- vignette de forme
- forme en image
- vignette de présentation
- présentation en images
- ajouter image
- ajouter illustration
- C++
- Aspose.Slides
description: "Modernisez le traitement des images de diapositives en remplaçant les API d'imagerie obsolètes par l'API Moderne C++ pour une automatisation fluide de PowerPoint et OpenDocument."
---

## **Introduction**

Actuellement, la bibliothèque Aspose.Slides pour C++ possède des dépendances dans son API publique aux classes suivantes de System::Drawing :
- [System::Drawing::Graphics](https://reference.aspose.com/slides/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/cpp/system.drawing/bitmap/)

À partir de la version 24.4, cette API publique est déclarée obsolète.

Afin d’éliminer les dépendances à System::Drawing dans l’API publique, nous avons ajouté la dite « API Moderne ». Les méthodes utilisant System::Drawing::Image et System::Drawing::Bitmap sont déclarées obsolètes et seront remplacées par les méthodes correspondantes de l’API Moderne. Les méthodes utilisant System::Graphics sont déclarées obsolètes et leur support sera retiré de l’API publique.

La suppression de l’API publique obsolète avec des dépendances à System::Drawing sera réalisée dans la version 24.8.

## **API Moderne**

Ajout des classes et énumérations suivantes à l’API publique :

- Aspose::Slides::IImage – représente l’image raster ou vectorielle.
- Aspose::Slides::ImageFormat – représente le format de fichier de l’image.
- Aspose::Slides::Images – méthodes pour créer et manipuler l’interface IImage.

Un scénario typique d’utilisation de la nouvelle API peut ressembler à ce qui suit :
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// instancier une instance jetable d'IImage à partir du fichier sur le disque.  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// créer une image PowerPoint en ajoutant une instance d'IImage aux images de la présentation.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// ajouter une forme image sur la diapositive #1
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// obtenir une instance d'IImage représentant la diapositive #1.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// enregistrer l'image sur le disque.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```


## **Remplacement du code ancien par l'API Moderne**

Pour faciliter la transition, l’interface du nouveau IImage reprend les signatures distinctes des classes Image et Bitmap. En général, il vous suffit de remplacer l’appel à l’ancienne méthode utilisant System::Drawing par la nouvelle.

### **Obtention d'une vignette de diapositive**

Code utilisant une API obsolète :
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```


API Moderne :
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```


### **Obtention d'une vignette de forme**

Code utilisant une API obsolète :
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```


API Moderne :
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```


### **Obtention d'une vignette de présentation**

Code utilisant une API obsolète :
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```


API Moderne :
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```


### **Ajout d'une image à une présentation**

Code utilisant une API obsolète :
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```


API Moderne :
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```


## **Méthodes/Propriétés à supprimer et leurs remplacements dans l'API Moderne**

### **Classe Presentation**
|Signature de méthode|Signature de la méthode de remplacement|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|Will be deleted completely|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|Will be deleted completely|

### **Classe Slide**
|Signature de méthode|Signature de la méthode de remplacement|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|Will be deleted completely|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|Will be deleted completely|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|Will be deleted completely|

### **Classe Shape**
|Signature de méthode|Signature de la méthode de remplacement|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **Classe ImageCollection**
|Signature de méthode|Signature de la méthode de remplacement|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **Classe PPImage**
|Signature de méthode|Signature de la méthode de remplacement|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **Classe PatternFormat**
|Signature de méthode|Signature de la méthode de remplacement|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **Classe IPatternFormatEffectiveData**
|Signature de méthode|Signature de la méthode de remplacement|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **Le support de System::Drawing::Graphics dans l'API sera interrompu**

Les méthodes avec [System::Drawing::Graphics](https://reference.aspose.com/slides/cpp/system.drawing/graphics/) sont déclarées obsolètes et leur support sera retiré de l’API publique.

La partie de l’API qui l’utilise sera supprimée :
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **FAQ**

**Pourquoi System::Drawing::Graphics a-t-il été abandonné ?**

Le support de `Graphics` est supprimé de l’API publique afin d’unifier le travail de rendu et d’image, d’éliminer les dépendances spécifiques à la plateforme et de passer à une approche multiplateforme avec [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/). Toutes les méthodes de rendu vers `Graphics` seront retirées.

**Quel est l’avantage pratique d’IImage par rapport à Image/Bitmap ?**

[IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) unifie la manipulation des images raster et vectorielles, simplifie l’enregistrement dans divers formats via [ImageFormat](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/), réduit la dépendance à `System::Drawing` et rend le code plus portable entre différents environnements.

**L’API Moderne affectera-t-elle les performances de génération des vignettes ?**

Passer de `GetThumbnail` à `GetImage` n’entraîne pas de dégradation : les nouvelles méthodes offrent les mêmes capacités de génération d’images avec options et tailles, tout en conservant le support des options de rendu. Le gain ou la perte spécifique dépend du scénario, mais fonctionnellement les remplacements sont équivalents.