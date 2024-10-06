---
title: Convertir PowerPoint en PNG
type: docs
weight: 30
url: /cpp/convert-powerpoint-to-png/
keywords: PowerPoint en PNG, PPT en PNG, PPTX en PNG, C++, Aspose.Slides pour C++
description: Convertir une présentation PowerPoint en PNG
---

## **À propos de la conversion de PowerPoint en PNG**

Le format PNG (Portable Network Graphics) n'est pas aussi populaire que le JPEG (Joint Photographic Experts Group), mais il reste très populaire.

**Cas d'utilisation :** Lorsque vous avez une image complexe et que la taille n'est pas un problème, le PNG est un meilleur format d'image que le JPEG.

{{% alert title="Conseil" color="primary" %}} Vous voudrez peut-être consulter les **Convertisseurs PowerPoint en PNG** gratuits d'Aspose : [PPTX en PNG](https://products.aspose.app/slides/conversion/pptx-to-png) et [PPT en PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Ce sont des implémentations en direct du processus décrit sur cette page. {{% /alert %}}

## **Convertir PowerPoint en PNG**

Suivez ces étapes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez l'objet de diapositive de la collection [Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) sous l'interface [ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide). 
3. Utilisez une méthode [ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage) pour obtenir la miniature de chaque diapositive. 
4. Utilisez la méthode [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) pour enregistrer la miniature de la diapositive au format PNG.

Ce code C++ vous montre comment convertir une présentation PowerPoint en PNG :

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **Convertir PowerPoint en PNG avec des dimensions personnalisées**

Si vous souhaitez obtenir des fichiers PNG à une certaine échelle, vous pouvez définir les valeurs pour `desiredX` et `desiredY`, qui déterminent les dimensions de la miniature résultante.

Ce code en C++ démontre l'opération décrite :

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **Convertir PowerPoint en PNG avec une taille personnalisée**

Si vous souhaitez obtenir des fichiers PNG à une certaine taille, vous pouvez passer vos arguments préférés `width` et `height` pour `ImageSize`.

Ce code vous montre comment convertir un PowerPoint en PNG tout en spécifiant la taille des images :

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```