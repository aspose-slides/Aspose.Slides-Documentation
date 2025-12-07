---
title: Convertir les présentations en HTML5 en C++
linktitle: Présentation en HTML5
type: docs
weight: 40
url: /fr/cpp/export-to-html5/
keywords:
- PowerPoint en HTML5
- OpenDocument en HTML5
- présentation en HTML5
- diapositive en HTML5
- PPT en HTML5
- PPTX en HTML5
- ODP en HTML5
- enregistrer PPT en HTML5
- enregistrer PPTX en HTML5
- enregistrer ODP en HTML5
- exporter PPT en HTML5
- exporter PPTX en HTML5
- exporter ODP en HTML5
- C++
- Aspose.Slides
description: "Exportez les présentations PowerPoint et OpenDocument vers du HTML5 responsive avec Aspose.Slides pour C++. Conservez le formatage, les animations et l’interactivité."
---

{{% alert title="Info" color="info" %}}

Dans [Aspose.Slides 21.9](/slides/fr/cpp/aspose-slides-for-cpp-21-9-release-notes/), nous avons implémenté la prise en charge de l'exportation HTML5.

{{% /alert %}} 

Le processus d'exportation vers HTML5 permet de convertir PowerPoint en HTML. Ainsi, en utilisant vos propres modèles, vous pouvez appliquer des options très flexibles qui définissent le processus d'exportation et le HTML, CSS, JavaScript et les attributs d'animation résultants. 

## **Exporter PowerPoint vers HTML5**

Ce code C++ montre comment exporter une présentation vers HTML5.
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```


{{% alert color="primary" %}} 

Dans ce cas, vous obtenez du HTML propre. 

{{% /alert %}}

Vous pouvez spécifier les paramètres pour les animations de forme et les transitions de diapositive de cette manière :
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```


## **Exporter PowerPoint vers HTML**

Ce code C++ démontre le processus standard d'exportation de PowerPoint vers HTML :
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```


Dans ce cas, le contenu de la présentation est rendu via SVG sous la forme suivante :
```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```


{{% alert title="Note" color="warning" %}} 

Lorsque vous utilisez cette méthode pour exporter PowerPoint vers HTML, en raison du rendu SVG, vous ne pourrez pas appliquer de styles ou animer des éléments spécifiques. 

{{% /alert %}}

## **Exporter PowerPoint vers la vue diapositive HTML5**

**Aspose.Slides** vous permet de convertir une présentation PowerPoint en document HTML5 dans lequel les diapositives sont présentées en mode vue diapositive. Dans ce cas, lorsque vous ouvrez le fichier HTML5 résultant dans un navigateur, vous voyez la présentation en mode vue diapositive sur une page Web. 

Ce code C++ démontre le processus d'exportation de PowerPoint vers la vue diapositive HTML5 :
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```


## **Convertir une présentation en document HTML5 avec commentaires**

Les commentaires dans PowerPoint sont un outil qui permet aux utilisateurs de laisser des notes ou des retours sur les diapositives de la présentation. Ils sont particulièrement utiles dans les projets collaboratifs, où plusieurs personnes peuvent ajouter leurs suggestions ou remarques à des éléments spécifiques de la diapositive sans modifier le contenu principal. Chaque commentaire indique le nom de l’auteur, ce qui facilite le suivi de qui a laissé la remarque.

Supposons que nous ayons la présentation PowerPoint suivante enregistrée dans le fichier "sample.pptx".

![Deux commentaires sur la diapositive de la présentation](two_comments_pptx.png)

Lorsque vous convertissez une présentation PowerPoint en document HTML5, vous pouvez facilement spécifier si les commentaires de la présentation doivent être inclus dans le document de sortie. Pour ce faire, vous devez spécifier les paramètres d’affichage des commentaires dans la méthode `get_NotesCommentsLayouting` de la classe [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/).

L'exemple de code suivant convertit une présentation en document HTML5 avec les commentaires affichés à droite des diapositives.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```


Le document "output.html" est présenté dans l'image ci-dessous.

![Les commentaires dans le document HTML5 de sortie](two_comments_html5.png)

## **FAQ**

**Puis-je contrôler si les animations d'objets et les transitions de diapositives seront jouées en HTML5 ?**

Oui, HTML5 propose des options distinctes pour activer ou désactiver les [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) et les [slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**La sortie des commentaires est‑elle prise en charge, et où peuvent-ils être placés par rapport à la diapositive ?**

Oui, les commentaires peuvent être ajoutés en HTML5 et positionnés (par exemple, à droite de la diapositive) via les paramètres de mise en page pour les notes et les commentaires.

**Puis‑je ignorer les liens qui invoquent du JavaScript pour des raisons de sécurité ou de CSP ?**

Oui, il existe un [setting](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) qui permet d’ignorer les hyperliens contenant des appels JavaScript lors de l’enregistrement. Cela aide à respecter des politiques de sécurité strictes.