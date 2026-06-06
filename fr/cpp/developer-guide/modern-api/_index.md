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
- diapositive vers image
- vignette de forme
- forme vers image
- vignette de présentation
- présentation vers images
- ajouter image
- ajouter image
- C++
- Aspose.Slides
description: "Modernisez le traitement des images des diapositives en remplaçant les API d'imagerie obsolètes par l'API Moderne C++ pour une automatisation fluide de PowerPoint et OpenDocument."
---
## **Introduction**

Actuellement, la bibliothèque Aspose.Slides for C++ possède des dépendances dans son API publique aux classes suivantes de System::Drawing :
- [System::Drawing::Graphics](https://reference.aspose.com/slides/fr/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/fr/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/fr/cpp/system.drawing/bitmap/)

Depuis la version 24.4, cette API publique est déclarée obsolète.

Afin d’éliminer les dépendances à System::Drawing dans l’API publique, nous avons ajouté ce que l’on appelle l’« Modern API ». Les méthodes utilisant [System::Drawing::Image](https://reference.aspose.com/slides/fr/cpp/system.drawing/image/) et [System::Drawing::Bitmap](https://reference.aspose.com/slides/fr/cpp/system.drawing/bitmap/) sont déclarées obsolètes et doivent être remplacées par les méthodes correspondantes de la Modern API. Les méthodes utilisant [System::Drawing::Graphics](https://reference.aspose.com/slides/fr/cpp/system.drawing/graphics/) sont déclarées obsolètes et ne possèdent aucun équivalent direct dans la Modern API.

Dans les versions actuelles, considérez l’API publique qui dépend des types System::Drawing comme héritée/obsolète. Utilisez la Modern API pour les nouveaux développements et lors de la migration des flux de traitement d’image existants.

## **Modern API**

Ajout des classes et énumérations suivantes à l’API publique :

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/) - représente l’image raster ou vectorielle.
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imageformat/) - représente le format de fichier de l’image.
- [Aspose::Slides::Images](https://reference.aspose.com/slides/fr/cpp/aspose.slides/images/) - méthodes pour instancier et travailler avec l’interface [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/).

Utilisez `GetImage` pour rendre une seule diapositive ou forme. Utilisez `GetImages` pour rendre plusieurs diapositives d’une présentation. Utilisez les méthodes de [Images](https://reference.aspose.com/slides/fr/cpp/aspose.slides/images/) pour charger des images, `AddImage` avec [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/) pour les ajouter à une présentation, et `ReplaceImage` avec [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/) pour mettre à jour une image existante d’une présentation.

Un scénario typique d’utilisation de la nouvelle API peut ressembler à ce qui suit :

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// instancier une instance jetable d'IImage depuis le fichier sur le disque.  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// créer une image PowerPoint en ajoutant une instance d'IImage aux images de la présentation.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// ajouter une forme image sur la diapositive #1
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// obtenir une instance de IImage représentant la diapositive #1.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// enregistrer l'image sur le disque.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **Remplacement du code ancien par la Modern API**

Pour faciliter la transition, l’interface du nouveau [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/) reprend les signatures distinctes des classes [System::Drawing::Image](https://reference.aspose.com/slides/fr/cpp/system.drawing/image/) et [System::Drawing::Bitmap](https://reference.aspose.com/slides/fr/cpp/system.drawing/bitmap/). En général, il vous suffit de remplacer l’appel à l’ancienne méthode utilisant System::Drawing par le nouveau.

### **Obtention d’une vignette de diapositive**

API héritée / obsolète :

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

Modern API :

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **Obtention d’une vignette de forme**

API héritée / obsolète :

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

Modern API :

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **Obtention d’une vignette de présentation**

API héritée / obsolète :

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```

Modern API :

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```

### **Ajout d’une image à une présentation**

API héritée / obsolète :

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

Modern API :

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

## **Méthodes/Propriétés obsolètes et leurs remplacements dans la Modern API**

### **Classe Presentation**
|Signature de méthode|Signature de méthode de remplacement|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|Pas de remplacement dans la Modern API|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|Pas de remplacement dans la Modern API|

### **Classe Slide**
|Signature de méthode|Signature de méthode de remplacement|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|Pas de remplacement dans la Modern API|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|Pas de remplacement dans la Modern API|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|Pas de remplacement dans la Modern API|

### **Classe Shape**
|Signature de méthode|Signature de méthode de remplacement|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **Classe ImageCollection**
|Signature de méthode|Signature de méthode de remplacement|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **Classe PPImage**
|Signature de méthode|Signature de méthode de remplacement|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **Classe PatternFormat**
|Signature de méthode|Signature de méthode de remplacement|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **Classe IPatternFormatEffectiveData**
|Signature de méthode|Signature de méthode de remplacement|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **Support API pour System::Drawing::Graphics**

Les méthodes avec [System::Drawing::Graphics](https://reference.aspose.com/slides/fr/cpp/system.drawing/graphics/) sont déclarées obsolètes et n’ont aucun remplacement direct dans la Modern API.

Utilisez les méthodes de rendu d’image de la Modern API à la place de l’API qui rend vers [System::Drawing::Graphics](https://reference.aspose.com/slides/fr/cpp/system.drawing/graphics/) :
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **FAQ**

**Pourquoi [System::Drawing::Graphics](https://reference.aspose.com/slides/fr/cpp/system.drawing/graphics/) a-t-il été retiré ?**

Le support de [System::Drawing::Graphics](https://reference.aspose.com/slides/fr/cpp/system.drawing/graphics/) est obsolète dans l’API publique afin d’unifier le travail de rendu et d’images, d’éliminer les dépendances spécifiques à une plateforme et de passer à une approche multiplateforme avec [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/). Utilisez `GetImage` ou `GetImages` au lieu de rendre vers [System::Drawing::Graphics](https://reference.aspose.com/slides/fr/cpp/system.drawing/graphics/).

**Quel est l’avantage pratique de [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/) par rapport à [System::Drawing::Image](https://reference.aspose.com/slides/fr/cpp/system.drawing/image/)/[System::Drawing::Bitmap](https://reference.aspose.com/slides/fr/cpp/system.drawing/bitmap/)?**

[IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/) unifie le travail avec les images raster et vectorielles, simplifie l’enregistrement dans différents formats via [ImageFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imageformat/), réduit la dépendance à `System::Drawing` et rend le code plus portable entre les environnements.

**La Modern API affectera-t-elle les performances de génération de vignettes ?**

Passer de `GetThumbnail` à `GetImage` n’aggrave pas les scénarios : les nouvelles méthodes offrent les mêmes capacités de production d’images avec options et tailles, tout en conservant le support des options de rendu. Le gain ou la perte spécifique dépend du scénario, mais fonctionnellement les remplacements sont équivalents.