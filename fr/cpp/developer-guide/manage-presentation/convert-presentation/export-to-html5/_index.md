---
title: Convertir les présentations en HTML5 avec C++
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
description: "Exportez les présentations PowerPoint et OpenDocument en HTML5 réactif avec Aspose.Slides pour C++. Conservez la mise en forme, les animations et l'interactivité."
---
## **Vue d'ensemble**

Cet article explique comment convertir des présentations PowerPoint en HTML5 à l'aide d'Aspose.Slides pour C++. Il couvre l'exportation de base, le contrôle des animations de formes et des transitions de diapositives, ainsi que la mise en page des commentaires. Il compare également la sortie HTML5 avec la sortie basée sur SVG de l'exportation HTML standard.

## **Exporter PowerPoint vers HTML5**

L'exemple suivant charge une présentation depuis le répertoire de travail et l'enregistre au format HTML5. Il utilise les paramètres d'exportation par défaut ; l'exemple suivant montre comment contrôler la lecture des animations explicitement. Remplacez le chemin d'entrée par le chemin de votre présentation.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html5);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
En plus du document HTML, l'exportation écrit des fichiers CSS et JavaScript associés pour le style des diapositives, les animations, les effets et la navigation. Conservez ces fichiers avec le document HTML lors du déplacement ou de la publication du résultat. La page générée charge également jQuery et Anime.js depuis des CDN publics ; sans eux, la navigation des diapositives et les animations ne fonctionnent pas.
{{% /alert %}}

Pour exporter sans lire les animations de formes ou les transitions de diapositives, transmettez `false` à [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) et [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) dans [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Ces paramètres sont indépendants, vous pouvez donc activer l'un tout en désactivant l'autre. L'exemple exporte la présentation avec les deux types d'animation désactivés dans la page générée.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(false);
html5Options->set_AnimateTransitions(false);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Exporter PowerPoint en HTML**

L'exportation HTML standard utilise une approche de rendu différente : le contenu des diapositives est représenté par du SVG à l'intérieur d'une page HTML. L'exemple suivant convertit une présentation en document HTML en utilisant cette approche de rendu.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html);
presentation->Dispose();
```

Le balisage simplifié ci‑dessous illustre la structure de la page générée. L'élément SVG contient le contenu rendu de la diapositive ; le texte de substitution représente ce contenu et n'est pas une sortie d'exportation littérale.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
L'exportation basée sur SVG n'expose pas les formes PowerPoint en tant qu'éléments HTML individuels. Utilisez l'exportation HTML5 lorsque vous avez besoin des options d'animation de formes et de transition de diapositives démontrées dans cet article.
{{% /alert %}}

## **Exporter PowerPoint vers la vue diapositive HTML5**

L'exportation HTML5 produit une page permettant de visualiser et de naviguer les diapositives de la présentation dans un navigateur. Cet exemple transmet `true` à la fois à [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) et à [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) afin que la vue diapositive exportée puisse lire les effets de la présentation source. Utilisez une présentation contenant déjà des animations de formes et des transitions de diapositives pour voir l'effet de ces paramètres. Les activer n'ajoute pas de nouveaux effets aux diapositives qui n'en ont pas. Après l'exportation, ouvrez le document HTML5 généré dans un navigateur avec ses fichiers de support disponibles.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Convertir une présentation en document HTML5 avec commentaires**

Vous pouvez inclure les commentaires de diapositives existants dans la sortie HTML5 afin que les lecteurs puissent voir les remarques à côté du contenu de la diapositive. L'exemple de cette section suppose que la présentation source contient des commentaires, comme illustré ci‑dessous. Il exporte ces commentaires ; il ne crée pas de nouveaux.

![Deux commentaires sur la diapositive de la présentation](two_comments_pptx.png)

Transmettez un objet [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) à la méthode [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) de [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Appelez [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/) avec `CommentsPositions::Right` de l'énumération [CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/) pour placer les commentaires à droite de chaque diapositive.

L'exemple suivant exporte la présentation en HTML5 avec cette mise en page de commentaires. Une présentation sans commentaires n'affichera aucun texte de commentaire.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/CommentsPositions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutOptions);

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

![Les commentaires dans le document HTML5 de sortie](two_comments_html5.png)

## **Exclure les hyperliens JavaScript lors de l'exportation**

Supposons que `hyperlinks.pptx` contienne du texte lié avec une cible `javascript:alert('Hello')` et un lien ordinaire `https://example.com/`. Pour exclure l'hyperlien JavaScript lors de l'exportation, appelez [SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) avec `true`. La valeur par défaut est `false`, donc ces liens ne sont pas filtrés à moins d'activer l'option.

L'exemple suivant charge la présentation depuis le répertoire de travail et l'exporte en utilisant [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/):

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SkipJavaScriptLinks(true);

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");
presentation->Save(u"filtered-html5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Le fichier exporté omet l'hyperlien JavaScript tout en conservant son texte et le lien HTTPS ordinaire. La présentation source reste inchangée.

Cette option filtre les hyperliens JavaScript ; elle ne supprime pas tous les scripts ni tout autre contenu actif, et ne garantit pas la conformité CSP. Par exemple, la sortie HTML5 inclut toujours des scripts pour la navigation des diapositives et les animations.

## **FAQ**

**Puis-je contrôler si les animations d'objets et les transitions de diapositives seront lues en HTML5 ?**

Oui, l'exportation HTML5 offre des options distinctes pour activer ou désactiver les [animations de formes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) et les [transitions de diapositives](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**Les commentaires sont‑ils pris en charge, et où peuvent‑ils être placés par rapport à la diapositive ?**

Oui, les commentaires existants peuvent être inclus dans la sortie HTML5 et positionnés (par exemple, à droite de la diapositive) via les [paramètres de mise en page](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) pour les notes et les commentaires.

**Puis‑je ignorer les liens qui invoquent du JavaScript pour des raisons de sécurité ou de CSP ?**

Oui, la méthode [set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) vous permet d'ignorer les hyperliens contenant des appels JavaScript lors de l'enregistrement. La valeur par défaut est `false`. Consultez [Exclure les hyperliens JavaScript lors de l'exportation](/slides/fr/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export) pour un exemple d'exportation HTML5 et la portée du filtre. Ce paramètre ne supprime pas le JavaScript utilisé par le visualiseur HTML5 pour la navigation et les animations.