---
title: Rendre une diapositive en tant qu'image SVG
type: docs
weight: 50
url: /fr/cpp/render-a-slide-as-an-svg-image/
---

SVG—un acronyme pour Scalable Vector Graphics—est un type ou format graphique standard utilisé pour rendre des images bidimensionnelles. SVG stocke les images sous forme de vecteurs en XML avec des détails qui définissent leur comportement ou leur apparence.

SVG est l'un des rares formats d'images qui répond à des normes très élevées en termes de : évolutivité, interactivité, performance, accessibilité, programmabilité, et autres. Pour ces raisons, il est couramment utilisé dans le développement web.

Vous voudrez peut-être utiliser des fichiers SVG lorsque vous avez besoin de

- **imprimer votre présentation dans un *format très grand*.** Les images SVG peuvent être redimensionnées à n'importe quelle résolution ou niveau. Vous pouvez redimensionner les images SVG autant de fois que nécessaire sans sacrifier la qualité.
- **utiliser des graphiques et des diagrammes de vos diapositives dans *différents médias ou plateformes***. La plupart des lecteurs peuvent interpréter les fichiers SVG.
- **utiliser les *tailles d'image les plus petites possibles***. Les fichiers SVG sont généralement plus petits que leurs équivalents haute résolution dans d'autres formats, en particulier ceux basés sur des pixels (JPEG ou PNG).

Aspose.Slides pour C++ vous permet d'exporter des diapositives de vos présentations en tant qu'images SVG. Suivez ces étapes pour générer des images SVG :

1. Créez une instance de la classe Presentation.
2. Itérez à travers toutes les diapositives de la présentation.
3. Écrivez chaque diapositive dans son propre fichier SVG via FileStream.

{{% alert color="primary" %}} 

Vous voudrez peut-être essayer notre [application web gratuite](https://products.aspose.app/slides/conversion/ppt-to-svg) dans laquelle nous avons implémenté la fonction de conversion PPT en SVG d'Aspose.Slides pour C++.

{{% /alert %}} 

Ce code exemple en C++ vous montre comment convertir PPT en SVG en utilisant Aspose.Slides :

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