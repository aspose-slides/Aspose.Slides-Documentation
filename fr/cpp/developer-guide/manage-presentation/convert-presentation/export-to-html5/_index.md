---
title: Exporter en HTML5
type: docs
weight: 40
url: /fr/cpp/export-to-html5/
keywords:
- PowerPoint vers HTML
- diapositives vers HTML
- HTML5
- export HTML
- exporter présentation
- convertir présentation
- convertir diapositives
- C++
- Aspose.Slides pour C++
description: "Exporter PowerPoint en HTML5 en C++" 
---

{{% alert title="Info" color="info" %}}

Dans [Aspose.Slides 21.9](/slides/fr/cpp/aspose-slides-for-cpp-21-9-release-notes/), nous avons implémenté la prise en charge de l'exportation en HTML5.

{{% /alert %}} 

Le processus d'exportation en HTML5 ici vous permet de convertir PowerPoint en HTML. De cette manière, en utilisant vos propres modèles, vous pouvez appliquer des options très flexibles qui définissent le processus d'exportation ainsi que le HTML, CSS, JavaScript et les attributs d'animation résultants.

## **Exporter PowerPoint en HTML5**

Ce code C++ montre comment exporter une présentation en HTML5.

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="primary" %}} 

Dans ce cas, vous obtenez un HTML propre.

{{% /alert %}}

Vous pouvez vouloir spécifier les paramètres pour les animations des formes et les transitions des diapositives de cette manière :

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **Exporter PowerPoint en HTML**

Ce C++ démontre le processus standard d'exportation de PowerPoint en HTML :

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

Dans ce cas, le contenu de la présentation est rendu via SVG sous une forme comme ceci :

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> LE CONTENU DE LA DIAPOSITIVE VA ICI </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 

Lorsque vous utilisez cette méthode pour exporter PowerPoint en HTML, en raison du rendu SVG, vous ne pourrez pas appliquer de styles ou animer des éléments spécifiques.

{{% /alert %}}

## **Exporter PowerPoint en HTML5 en mode diapositive**

**Aspose.Slides** vous permet de convertir une présentation PowerPoint en un document HTML5 dans lequel les diapositives sont présentées en mode diapositive. Dans ce cas, lorsque vous ouvrez le fichier HTML5 résultant dans un navigateur, vous voyez la présentation en mode diapositive sur une page web.

Ce code C++ démontre le processus d'exportation PowerPoint en HTML5 en mode diapositive :

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## Convertir une Présentation en Document HTML5 avec Commentaires

Les commentaires dans PowerPoint sont un outil qui permet aux utilisateurs de laisser des notes ou des retours sur les diapositives de présentation. Ils sont particulièrement utiles dans des projets collaboratifs, où plusieurs personnes peuvent ajouter des suggestions ou des remarques à des éléments de diapositive spécifiques sans modifier le contenu principal. Chaque commentaire affiche le nom de l'auteur, ce qui facilite le suivi de qui a laissé la remarque.

Disons que nous avons la présentation PowerPoint suivante enregistrée dans le fichier "sample.pptx".

![Deux commentaires sur la diapositive de présentation](two_comments_pptx.png)

Lorsque vous convertissez une présentation PowerPoint en document HTML5, vous pouvez facilement spécifier si vous souhaitez inclure les commentaires de la présentation dans le document de sortie. Pour ce faire, vous devez spécifier les paramètres d'affichage des commentaires dans la méthode `get_NotesCommentsLayouting` de la classe [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/).

L'exemple de code suivant convertit une présentation en document HTML5 avec les commentaires affichés à droite des diapositives.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Le document "output.html" est montré dans l'image ci-dessous.

![Les commentaires dans le document HTML5 de sortie](two_comments_html5.png)