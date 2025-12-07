---
title: Convertir les diapositives PowerPoint en PNG avec C++
linktitle: PowerPoint vers PNG
type: docs
weight: 30
url: /fr/cpp/convert-powerpoint-to-png/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en PNG
- présentation en PNG
- diapositive en PNG
- PPT en PNG
- PPTX en PNG
- enregistrer PPT en PNG
- enregistrer PPTX en PNG
- exporter PPT en PNG
- exporter PPTX en PNG
- C++
- Aspose.Slides
description: "Convertir les présentations PowerPoint en images PNG de haute qualité rapidement avec Aspose.Slides pour C++, garantissant des résultats précis et automatisés."
---

## **À propos de la conversion PowerPoint en PNG**

Le format PNG (Portable Network Graphics) n’est pas aussi répandu que le JPEG (Joint Photographic Experts Group), mais il reste très populaire. 

**Cas d’utilisation :** Lorsque vous avez une image complexe et que la taille n’est pas un problème, le PNG est un meilleur format d’image que le JPEG. 

{{% alert title="Astuce" color="primary" %}} Vous voudrez peut‑être consulter les convertisseurs PowerPoint → PNG gratuits d’Aspose : [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) et [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Ils constituent une implémentation fonctionnelle du processus décrit sur cette page. {{% /alert %}}

## **Convertir PowerPoint en PNG**

Suivez ces étapes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Récupérez l’objet diapositive depuis la collection [Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) sous l’interface [ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide). 
3. Utilisez la méthode [ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage) pour obtenir la vignette de chaque diapositive. 
4. Utilisez la méthode [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) pour enregistrer la vignette de la diapositive au format PNG. 

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

Si vous voulez obtenir des fichiers PNG à une certaine échelle, vous pouvez définir les valeurs de `desiredX` et `desiredY`, qui déterminent les dimensions de la vignette résultante. 

Ce code C++ illustre l’opération décrite :
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

Si vous voulez obtenir des fichiers PNG d’une taille précise, vous pouvez fournir les arguments `width` et `height` souhaités pour `ImageSize`. 

Ce code vous montre comment convertir un PowerPoint en PNG tout en précisant la taille des images : 
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


## **FAQ**

**Comment exporter uniquement une forme spécifique (par ex., un graphique ou une image) plutôt que l’ensemble de la diapositive ?**

Aspose.Slides prend en charge la [génération de vignettes pour des formes individuelles](/slides/fr/cpp/create-shape-thumbnails/) ; vous pouvez rendre une forme sous forme d’image PNG.

**La conversion parallèle est‑elle prise en charge sur un serveur ?**

Oui, mais [ne partagez pas](/slides/fr/cpp/multithreading/) une même instance de présentation entre plusieurs threads. Utilisez une instance distincte par thread ou processus.

**Quelles sont les limitations de la version d’évaluation lors de l’exportation en PNG ?**

Le mode d’évaluation ajoute un filigrane aux images de sortie et impose [d’autres restrictions](/slides/fr/cpp/licensing/) jusqu’à l’application d’une licence.