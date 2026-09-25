---
title: Gérer l'accessibilité des présentations sur Android
linktitle: Accessibilité des présentations
type: docs
weight: 30
url: /fr/androidjava/presentation-accessibility/
keywords:
- accessibilité des présentations
- texte alternatif
- titre du texte alternatif
- description du texte alternatif
- marquer comme décoratif
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Découvrez comment Aspose.Slides for Android via Java aide à automatiser les vérifications d'accessibilité des présentations dans les fichiers PPT, PPTX et ODP—améliorez l'expérience des lecteurs d'écran et renforcez la conformité."
---
## **Introduction**

Le texte alternatif aide les personnes utilisant des technologies d'assistance à comprendre la signification des images, graphiques et autres formes informatives. Cet article explique comment lire et mettre à jour les titres et descriptions du texte alternatif avec Aspose.Slides for Android via Java, distinguer les descriptions d’accessibilité des noms de forme utilisés dans le code, et vérifier si une forme est marquée comme décorative.

Ces fonctionnalités prennent en charge l’accessibilité des présentations, mais ne la garantissent pas. L’ordre de lecture, le contraste des couleurs, la lisibilité du texte et d’autres exigences d’accessibilité doivent également être vérifiés.

## **Gérer les titres et descriptions du texte alternatif**

Utilisez le texte alternatif pour expliquer la signification des images, graphiques et autres formes informatives aux personnes qui ne peuvent pas les voir. Les méthodes et contenus suivants servent à des fins différentes :

| Méthode ou contenu | Objectif |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Un titre court pour la description alternative. |
| [getAlternativeText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#getAlternativeText--) | Une description significative du contenu ou du but de la forme dans le contexte de la diapositive. |
| [getName](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#getName--) | Le nom de la forme, que le code peut utiliser pour trouver une forme spécifique dans la présentation. |
| Texte visible | Contenu affiché sur la diapositive, tel que le texte d’une forme ou le titre et les libellés d’un graphique. La mise à jour du texte alternatif ne modifie pas ce contenu. |

Lorsque une présentation est réutilisée comme modèle, le code peut trouver une forme par le nom renvoyé par [getName](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#getName--) avant de la mettre à jour. Ce nom sert un but différent du texte alternatif, qui explique ce que le visuel communique au lecteur. Rechercher par nom permet aux auteurs d’améliorer ou de traduire les descriptions sans changer la façon dont le code trouve la forme. Les noms peuvent être modifiés et ne sont pas garantis d’être uniques, il faut donc vérifier que le nom correspond à la forme prévue ; voir [Identify and Find Shapes](/slides/fr/androidjava/shape-manipulations/#identify-and-find-shapes).

L’exemple suivant nécessite `input.pptx` contenant une image d’une entrée de bureau comme première forme sur la première diapositive. L’image ne doit pas être marquée comme décorative. L’exemple lit et affiche le titre et la description actuels du texte alternatif, met à jour les deux valeurs et enregistre la présentation sous `output.pptx`. Adaptez le libellé à l’image réelle et aux informations qu’elle transmet.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    System.out.println("Alternative text title: " + shape.getAlternativeTextTitle());
    System.out.println("Alternative text description: " + shape.getAlternativeText());

    shape.setAlternativeTextTitle("Office entrance");
    shape.setAlternativeText("The office entrance has a wheelchair ramp to the right of the steps.");

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ajouter uniquement du texte alternatif ne garantit pas l’accessibilité ou la conformité aux normes d’accessibilité. Vérifiez l’exactitude et la pertinence des descriptions, ainsi que l’ordre de lecture, le contraste des couleurs, la lisibilité du texte et d’autres exigences d’accessibilité. Les visuels informatifs ne doivent pas être marqués comme décoratifs ; la section suivante montre comment vérifier [isDecorative](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#isDecorative--).

## **Marquer comme décoratif**

Le drapeau « marquer comme décoratif » indique que les visuels purement ornementaux doivent être ignorés par les lecteurs d’écran, réduisant le bruit et maintenant le focus sur le contenu significatif. Appliquez‑le aux arrière‑plans, aux ornements et aux séparateurs — jamais aux graphiques, icônes ou images véhiculant des informations. Aspose.Slides expose ce drapeau pour la détection et la validation, permettant des contrôles d’accessibilité automatisés et le nettoyage.

![Mark as Decorative](mark_as_decorative.png)

Le fragment de code suivant montre comment déterminer si une forme est marquée comme décorative.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Que dois‑je mettre dans le titre et la description du texte alternatif ?**

Utilisez un titre court pour identifier le sujet et une description pour expliquer l’information que le visuel transmet dans le contexte de la diapositive. Pour un graphique, décrivez la tendance ou la comparaison pertinente plutôt que de dire simplement « graphique ».

**Dois‑je utiliser le texte alternatif pour localiser des formes dans un modèle ?**

Privilégiez la recherche de la forme par le nom renvoyé par [getName](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#getName--) et vérifiez qu’il s’agit de la forme attendue. Le texte alternatif peut être modifié ou traduit, ce qui pourrait casser le code qui recherche une description exacte ; voir [Identify and Find Shapes](/slides/fr/androidjava/shape-manipulations/).

**Quand une forme doit‑elle être marquée comme décorative ?**

Utilisez le drapeau décoratif pour les visuels qui n’apportent aucune information, comme les ornements. Les images et graphiques qui communiquent une signification nécessitent une description appropriée à la place.

**L’ajout de texte alternatif rend‑il une présentation complètement accessible ?**

Non. Le texte alternatif ne traite qu’une partie de l’accessibilité. Il faut également vérifier l’ordre de lecture, le contraste des couleurs, la lisibilité du texte et les autres exigences applicables ; la simple définition de ces propriétés ne garantit pas la conformité.