---
title: Rendre les diapositives de présentation en images SVG en C++
linktitle: Diapositive en SVG
type: docs
weight: 50
url: /fr/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint en SVG
- présentation en SVG
- diapositive en SVG
- PPT en SVG
- PPTX en SVG
- enregistrer PPT au format SVG
- enregistrer PPTX au format SVG
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
description: "Apprenez à rendre les diapositives PowerPoint au format SVG à l'aide d'Aspose.Slides pour C++. Des visuels de haute qualité avec des exemples de code simples."
---

## **Format SVG**

SVG—acronyme de Scalable Vector Graphics—est un type ou format graphique standard utilisé pour rendre des images bidimensionnelles. SVG stocke les images sous forme de vecteurs dans du XML avec des détails qui définissent leur comportement ou apparence.  

SVG est l’un des rares formats d’images qui répond à des exigences très élevées en matière de : évolutivité, interactivité, performances, accessibilité, programmabilité, etc. Pour ces raisons, il est couramment utilisé en développement web.  

Vous pouvez choisir les fichiers SVG lorsque vous devez

- **imprimer votre présentation dans un *format très grand*.** Les images SVG peuvent être agrandies à n’importe quelle résolution ou niveau. Vous pouvez redimensionner les images SVG autant de fois que nécessaire sans perdre en qualité.  
- **utiliser les graphiques et diagrammes de vos diapositives sur des *supports ou plateformes différents*.** La plupart des lecteurs savent interpréter les fichiers SVG.  
- **utiliser les *tailles les plus petites possibles pour les images*.** Les fichiers SVG sont généralement plus légers que leurs équivalents haute résolution dans d’autres formats, en particulier les formats basés sur le bitmap (JPEG ou PNG).  

## **Rendre une diapositive en image SVG**

Aspose.Slides for C++ vous permet d’exporter les diapositives de vos présentations sous forme d’images SVG. Suivez ces étapes pour générer des images SVG :

1. Créez une instance de la classe Presentation.  
2. Parcourez toutes les diapositives de la présentation.  
3. Écrivez chaque diapositive dans son propre fichier SVG via FileStream.  

{{% alert color="primary" %}} 

Vous pouvez essayer notre [application web gratuite](https://products.aspose.app/slides/conversion/ppt-to-svg) dans laquelle nous avons implémenté la fonction de conversion PPT vers SVG d’Aspose.Slides for C++.  

{{% /alert %}} 

Ce code d’exemple en C++ montre comment convertir un PPT en SVG avec Aspose.Slides :
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

**Pourquoi le SVG résultant peut-il avoir une apparence différente selon les navigateurs ?**

La prise en charge de certaines fonctionnalités SVG varie selon les moteurs de navigateur. Les paramètres [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) permettent de lisser les incompatibilités.  

**Est‑il possible d’exporter non seulement les diapositives mais aussi des formes individuelles en SVG ?**

Oui. Toute [forme peut être enregistrée comme un SVG séparé](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/), ce qui est pratique pour les icônes, pictogrammes et la réutilisation de graphiques.  

**Peut‑on combiner plusieurs diapositives en un seul SVG (bande/document) ?**

Le scénario standard est : une diapositive → un SVG. Combiner plusieurs diapositives en un seul canevas SVG constitue une étape de post‑traitement effectuée au niveau de l’application.