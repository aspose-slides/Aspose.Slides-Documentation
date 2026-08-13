---
title: Convertir les présentations en HTML5 en C++
linktitle: Présentation en HTML5
type: docs
weight: 40
url: /fr/cpp/export-to-html5/
keywords:
- PowerPoint vers HTML5
- OpenDocument vers HTML5
- présentation vers HTML5
- diapositive vers HTML5
- PPT vers HTML5
- PPTX vers HTML5
- ODP vers HTML5
- enregistrer PPT en HTML5
- enregistrer PPTX en HTML5
- enregistrer ODP en HTML5
- exporter PPT en HTML5
- exporter PPTX en HTML5
- exporter ODP en HTML5
- C++
- Aspose.Slides
description: "Exportez les présentations PowerPoint et OpenDocument en HTML5 adaptatif avec Aspose.Slides pour C++. Conservez la mise en forme, les animations et l'interactivité."
---
## **Aperçu**

Cet article explique comment convertir des présentations PowerPoint en HTML5 à l'aide d'Aspose.Slides. Il couvre l'exportation HTML5 de base sans extensions Web ni dépendances supplémentaires, ainsi que les options de contrôle des animations de formes et des transitions de diapositives. L'article montre également le processus d'exportation standard de PowerPoint vers HTML, explique comment générer une sortie HTML5 en mode affichage des diapositives, et démontre comment inclure des commentaires dans le document exporté en configurant leur mise en page.

## **Exporter PowerPoint en HTML5**

Ce code C++ montre comment exporter une présentation en HTML5.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="info" %}}
Dans ce cas, vous obtenez un HTML propre.
{{% /alert %}}

Vous pouvez spécifier les paramètres des animations de formes et des transitions de diapositives de cette manière :

```cpp
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **Exporter PowerPoint en HTML**

Ce C++ montre le processus standard d'exportation de PowerPoint vers HTML :

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

Dans ce cas, le contenu de la présentation est rendu via SVG sous une forme similaire à celle-ci :

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
Lorsque vous utilisez cette méthode pour exporter PowerPoint en HTML, en raison du rendu SVG, vous ne pourrez pas appliquer de styles ni animer des éléments spécifiques.
{{% /alert %}}

## **Exporter PowerPoint en affichage diapositive HTML5**

**Aspose.Slides** permet de convertir une présentation PowerPoint en un document HTML5 dans lequel les diapositives sont présentées en mode affichage diapositive. Dans ce cas, lorsque vous ouvrez le fichier HTML5 résultant dans un navigateur, vous voyez la présentation en mode affichage diapositive sur une page Web.

Ce code C++ montre le processus d'exportation de PowerPoint vers HTML5 en affichage diapositive :

```c++
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **Convertir une présentation en document HTML5 avec commentaires**

Les commentaires dans PowerPoint sont un outil qui permet aux utilisateurs de laisser des notes ou des retours sur les diapositives de la présentation. Ils sont particulièrement utiles dans les projets collaboratifs, où plusieurs personnes peuvent ajouter leurs suggestions ou remarques à des éléments spécifiques des diapositives sans modifier le contenu principal. Chaque commentaire indique le nom de l'auteur, ce qui facilite le suivi de la personne qui a laissé la remarque.

Imaginons que nous ayons la présentation PowerPoint suivante enregistrée dans le fichier "sample.pptx".

![Deux commentaires sur la diapositive de la présentation](two_comments_pptx.png)

Lorsque vous convertissez une présentation PowerPoint en document HTML5, vous pouvez facilement spécifier si les commentaires de la présentation doivent être inclus dans le document de sortie. Pour ce faire, vous devez spécifier les paramètres d'affichage des commentaires dans la méthode `get_NotesCommentsLayouting` de la classe [Html5Options](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/html5options/).

L'exemple de code suivant convertit une présentation en document HTML5 avec les commentaires affichés à droite des diapositives.
```cpp
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Le document "output.html" est affiché dans l'image ci‑dessous.

![Les commentaires dans le document HTML5 de sortie](two_comments_html5.png)

## **FAQ**

### Puis‑je contrôler si les animations d'objets et les transitions de diapositives seront lues en HTML5 ?

Oui, HTML5 propose des options distinctes pour activer ou désactiver les [animations de formes](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/html5options/set_animateshapes/) et les [transitions de diapositives](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/html5options/set_animatetransitions/).

### Le rendu des commentaires est‑il pris en charge, et où peuvent‑ils être placés par rapport à la diapositive ?

Oui, les commentaires peuvent être ajoutés en HTML5 et positionnés (par exemple, à droite de la diapositive) grâce aux paramètres de mise en page des notes et des commentaires.

### Puis‑je ignorer les liens qui invoquent du JavaScript pour des raisons de sécurité ou de CSP ?

Oui, il existe un [paramètre](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) qui permet d'ignorer les hyperliens contenant des appels JavaScript lors de l'enregistrement. Cela aide à respecter des politiques de sécurité strictes.