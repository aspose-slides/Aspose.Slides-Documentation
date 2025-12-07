---
title: Rendre les diapositives de présentation en images SVG en C++
linktitle: Diapositive vers SVG
type: docs
weight: 50
url: /fr/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint vers SVG
- présentation vers SVG
- diapositive vers SVG
- PPT vers SVG
- PPTX vers SVG
- enregistrer PPT en SVG
- enregistrer PPTX en SVG
- exporter PPT en SVG
- exporter PPTX en SVG
- rendre la diapositive
- convertir la diapositive
- exporter la diapositive
- image vectorielle
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à rendre les diapositives PowerPoint en images SVG en utilisant Aspose.Slides pour C++. Des visuels de haute qualité avec des exemples de code simples."
---

## **Format SVG**

SVG—un acronyme pour Scalable Vector Graphics—est un type ou format graphique standard utilisé pour rendre des images bidimensionnelles. SVG stocke les images sous forme de vecteurs en XML avec des détails qui définissent leur comportement ou apparence. 

SVG est l’un des rares formats d’images qui répond à des exigences très élevées en matière de évolutivité, d’interactivité, de performances, d’accessibilité, de programmabilité et d’autres critères. Pour ces raisons, il est couramment utilisé dans le développement web. 

Vous pouvez choisir d’utiliser des fichiers SVG lorsque vous devez

- **imprimer votre présentation dans un *format très grand*.** Les images SVG peuvent être agrandies à n’importe quelle résolution ou niveau. Vous pouvez redimensionner les images SVG autant de fois que nécessaire sans sacrifier la qualité.
- **utiliser des graphiques et diagrammes de vos diapositives dans *différents supports ou plates‑formes***. La plupart des lecteurs peuvent interpréter les fichiers SVG. 
- **utiliser les *tailles d'image les plus petites possibles***. Les fichiers SVG sont généralement plus petits que leurs équivalents haute résolution dans d’autres formats, en particulier les formats basés sur le bitmap (JPEG ou PNG).

## **Rendre une diapositive en image SVG**

Aspose.Slides for C++ vous permet d’exporter les diapositives de vos présentations sous forme d’images SVG. Suivez ces étapes pour générer des images SVG :

1. Créez une instance de la classe Presentation.  
2. Parcourez toutes les diapositives de la présentation.  
3. Écrivez chaque diapositive dans son propre fichier SVG via FileStream.  

{{% alert color="primary" %}} 

Vous pouvez essayer notre [application web gratuite](https://products.aspose.app/slides/conversion/ppt-to-svg) dans laquelle nous avons implémenté la fonction de conversion PPT vers SVG d'Aspose.Slides for C++. 

{{% /alert %}} 

Ce code exemple en C++ vous montre comment convertir un PPT en SVG à l’aide d’Aspose.Slides :
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
        
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto fileName = String::Format(u"slide-{0}.svg", index);
    auto fileStream = System::MakeObject<FileStream>(fileName, FileMode::Create, FileAccess::Write);

    auto slide = pres->get_Slides()->idx_get(index);
    slide->WriteAsSvg(fileStream);
}
```


## **FAQ**

**Pourquoi le SVG résultant peut-il apparaître différemment selon les navigateurs ?**

La prise en charge de fonctionnalités SVG spécifiques est implémentée différemment par les moteurs des navigateurs. Les paramètres [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) aident à lisser les incompatibilités.

**Est‑il possible d'exporter non seulement les diapositives mais aussi des formes individuelles en SVG ?**

Oui. Toute [forme peut être enregistrée en tant que SVG distinct](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/), ce qui est pratique pour les icônes, pictogrammes et la réutilisation de graphiques.

**Peut‑on combiner plusieurs diapositives en un seul SVG (bande/document) ?**

Le scénario standard est une diapositive → un SVG. Combiner plusieurs diapositives en un seul canevas SVG est une étape de post‑traitement réalisée au niveau de l'application.