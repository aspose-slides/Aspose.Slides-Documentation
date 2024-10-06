---
title: Convertir Powerpoint PPT en JPG
type: docs
weight: 60
url: /cpp/convert-powerpoint-to-jpg/
keywords:
- Convertir présentation PowerPoint
- JPG
- JPEG
- PowerPoint en JPG
- PowerPoint en JPEG
- PPT en JPG
- PPTX en JPG
- PPT en JPEG
- PPTX en JPEG
- C++
- Aspose.Slides
description: "Convertir PowerPoint en JPG : PPT en JPG, PPTX en JPG en C++"
---

## **Convertir Présentation en Ensemble d'Images**

Dans certains cas, il est nécessaire de convertir l'ensemble de la présentation en un ensemble d'images, 
comme le permet PowerPoint. Le code C++ vous montre comment convertir une présentation en images JPG :

```c++
auto imageScale = 1.0f;

auto pres = System::MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : pres->get_Slides())
{
    // Crée une image à l'échelle complète
    System::SharedPtr<IImage> image = slide->GetImage(imageScale, imageScale);

    // Sauvegarde l'image sur le disque au format JPEG
    auto imageFileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(imageFileName, ImageFormat::Jpeg);

    image->Dispose();
}

pres->Dispose();
```

{{% alert color="primary" %}} 

Pour voir comment Aspose.Slides convertit PowerPoint en images JPG, vous pouvez essayer ces convertisseurs en ligne gratuits : PowerPoint [PPTX en JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) et [PPT en JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

## Convertir PowerPoint PPT/PPTX en JPG avec Dimensions Personnalisées**

Pour changer la dimension de la miniature résultante et de l'image JPG, vous pouvez définir les valeurs *ScaleX* et *ScaleY* en les passant dans `float scaleX, float Y` de la méthode [**ISlide::GetImage()**](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/#islidegetimagefloat-float-method) :

```c++
auto pres = System::MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

// Définit les dimensions
int32_t desiredX = 1200, desiredY = 800;

// Obtient les valeurs mises à l'échelle de X et Y
float scaleX = (float)(1.0 / pres->get_SlideSize()->get_Size().get_Width()) * desiredX;
float scaleY = (float)(1.0 / pres->get_SlideSize()->get_Size().get_Height()) * desiredY;

for (auto&& slide : pres->get_Slides())
{
    // Crée une image à l'échelle complète
    System::SharedPtr<IImage> image = slide->GetImage(scaleX, scaleY);

    // Sauvegarde l'image sur le disque au format JPEG
    auto imageFileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(imageFileName, ImageFormat::Jpeg);

    image->Dispose();
}

pres->Dispose();
```

{{% alert title="Astuce" color="primary" %}}

Aspose propose une [application web de collage GRATUITE](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner des images [JPG en JPG](https://products.aspose.app/slides/collage/jpg) ou PNG en PNG, créer des [grilles photo](https://products.aspose.app/slides/collage/photo-grid), etc.

En utilisant les mêmes principes décrits dans cet article, vous pouvez convertir des images d'un format à un autre. Pour plus d'informations, consultez ces pages : convertir [image en JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/) ; convertir [JPG en image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/) ; convertir [JPG en PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/) ; convertir [PNG en SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Voir aussi**

Voir d'autres options pour convertir PPT/PPTX en image comme :

- [Conversion PPT/PPTX en SVG](/slides/cpp/render-a-slide-as-an-svg-image/)