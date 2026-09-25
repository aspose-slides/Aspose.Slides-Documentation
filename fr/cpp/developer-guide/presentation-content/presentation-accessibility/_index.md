---
title: Gérer l'accessibilité des présentations en C++
linktitle: Accessibilité des présentations
type: docs
weight: 30
url: /fr/cpp/presentation-accessibility/
keywords:
- accessibilité des présentations
- texte alternatif
- titre du texte alternatif
- description du texte alternatif
- marquer comme décoratif
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Automatisez les vérifications d'accessibilité des présentations dans les fichiers PPT, PPTX et ODP avec Aspose.Slides pour C++ — améliorez l'expérience des lecteurs d'écran et renforcez la conformité."
---
## **Introduction**

Le texte alternatif aide les personnes utilisant des technologies d’assistance à comprendre la signification des images, des graphiques et d’autres formes informatives. Cet article explique comment lire et mettre à jour les titres et descriptions du texte alternatif avec Aspose.Slides pour C++, comment distinguer les descriptions d’accessibilité des noms de forme utilisés dans le code, et comment vérifier si une forme est marquée comme décorative.

Ces fonctionnalités soutiennent l’accessibilité des présentations, mais ne la garantissent pas. L’ordre de lecture, le contraste des couleurs, la lisibilité du texte et d’autres exigences d’accessibilité doivent également être vérifiés.

## **Manage Alternative Text Titles and Descriptions**

Utilisez le texte alternatif pour expliquer la signification des images, des graphiques et d’autres formes informatives aux personnes qui ne peuvent pas les voir. Les propriétés suivantes servent des objectifs différents :

| Propriété ou contenu | Objectif |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/get_alternativetexttitle/) | Un titre court pour la description alternative. |
| [AlternativeText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/get_alternativetext/) | Une description significative du contenu ou de l’objectif de la forme dans le contexte de la diapositive. |
| [Name](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/get_name/) | Le nom de la forme, que le code peut utiliser pour trouver une forme spécifique dans la présentation. |
| Texte visible | Contenu affiché sur la diapositive, tel que le texte d’une forme ou le titre et les étiquettes d’un graphique. La mise à jour du texte alternatif ne modifie pas ce contenu. |

Lorsqu’une présentation est réutilisée comme modèle, le code peut trouver une forme par son [Name](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/get_name/) avant de la mettre à jour. Ce nom sert un objectif différent du texte alternatif, qui explique ce que le visuel communique au lecteur. La recherche par nom permet aux auteurs d’améliorer ou de traduire les descriptions sans modifier la façon dont le code trouve la forme. Les noms peuvent être édités et ne sont pas garantis comme uniques, il faut donc vérifier que le nom correspond à la forme prévue ; voir [Identify and Find Shapes](/slides/fr/cpp/shape-manipulations/#identify-and-find-shapes).

L’exemple suivant nécessite `input.pptx` contenant une image d’une entrée de bureau comme première forme sur la première diapositive. L’image ne doit pas être marquée comme décorative. L’exemple lit et affiche le titre et la description actuels du texte alternatif, met à jour les deux valeurs, puis enregistre la présentation sous `output.pptx`. Adaptez le libellé à l’image réelle et aux informations qu’elle transmet.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

Console::WriteLine(u"Alternative text title: {0}", shape->get_AlternativeTextTitle());
Console::WriteLine(u"Alternative text description: {0}", shape->get_AlternativeText());

shape->set_AlternativeTextTitle(u"Office entrance");
shape->set_AlternativeText(u"The office entrance has a wheelchair ramp to the right of the steps.");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ajouter uniquement du texte alternatif ne garantit pas l’accessibilité de la présentation ni la conformité aux normes d’accessibilité. Vérifiez l’exactitude et la pertinence des descriptions et examinez également l’ordre de lecture, le contraste des couleurs, la lisibilité du texte et d’autres exigences d’accessibilité. Les visuels informatifs ne doivent pas être marqués comme décoratifs ; la section suivante montre comment lire [IsDecorative](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/get_isdecorative/).

## **Mark as Decorative**

Marquer comme décoratif indique que les éléments purement ornementaux doivent être ignorés par les lecteurs d’écran, réduisant le bruit et maintenant le focus sur le contenu significatif. Appliquez‑le aux arrière‑plans, aux ornements et aux espaces — jamais aux graphiques, icônes ou images qui transmettent des informations. Aspose.Slides expose ce drapeau pour la détection et la validation, permettant des vérifications d’accessibilité automatisées et un nettoyage.

![Marquer comme décoratif](mark_as_decorative.png)

L’exemple de code suivant montre comment déterminer si une forme est marquée comme décorative.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```

## **FAQ**

**Que dois‑je mettre dans le titre et la description du texte alternatif ?**

Utilisez un titre court pour identifier le sujet et une description pour expliquer l’information que le visuel transmet dans le contexte de la diapositive. Pour un graphique, décrivez la tendance ou la comparaison pertinente plutôt que de dire simplement « graphique ».

**Dois‑je utiliser le texte alternatif pour localiser des formes dans un modèle ?**

Préférez trouver la forme par son [Name](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/get_name/) et vérifier qu’il s’agit bien de la forme attendue. Le texte alternatif peut être édité ou traduit, ce qui peut casser le code qui recherche une description exacte ; voir [Identify and Find Shapes](/slides/fr/cpp/shape-manipulations/).

**Quand une forme doit‑elle être marquée comme décorative ?**

Utilisez le drapeau décoratif pour les visuels qui n’ajoutent aucune information, comme les ornements. Les images et graphiques qui communiquent du sens nécessitent une description appropriée à la place.

**L’ajout de texte alternatif rend‑il une présentation totalement accessible ?**

Non. Le texte alternatif ne traite qu’une partie de l’accessibilité. Il faut également examiner l’ordre de lecture, le contraste des couleurs, la lisibilité du texte et les autres exigences applicables ; le fait de définir ces propriétés seules ne garantit pas la conformité.