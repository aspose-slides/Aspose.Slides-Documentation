---
title: Gérer l'accessibilité des présentations en Java
linktitle: Accessibilité des présentations
type: docs
weight: 30
url: /fr/java/presentation-accessibility/
keywords:
- accessibilité des présentations
- texte alternatif
- titre du texte alternatif
- description du texte alternatif
- marquer comme décoratif
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Découvrez comment Aspose.Slides for Java aide à automatiser les vérifications d'accessibilité des présentations dans les fichiers PPT, PPTX et ODP — améliorez l'expérience des lecteurs d'écran et renforcez la conformité."
---
## **Introduction**

Le texte alternatif aide les personnes utilisant des technologies d'assistance à comprendre la signification des images, des graphiques et d'autres formes informatives. Cet article explique comment lire et mettre a jour les titres et les descriptions du texte alternatif avec Aspose.Slides for Java, distinguer les descriptions d'accessibilite des noms de forme utilises dans le code et verifier si une forme est marquee comme decoratif.

Ces fonctionnalites soutiennent l'accessibilite des presentations, mais ne la garantissent pas. L'ordre de lecture, le contraste des couleurs, la lisibilite du texte et d'autres exigences d'accessibilite doivent egalement etre examines.

## **Gerer les titres et les descriptions du texte alternatif**

Utilisez le texte alternatif pour expliquer la signification des images, des graphiques et d'autres formes informatives aux personnes qui ne peuvent pas les voir. Les methodes et le contenu suivants ont des objectifs différents:

| Methode ou contenu | Objectif |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Un titre court pour la description alternative. |
| [getAlternativeText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getAlternativeText--) | Une description significative du contenu ou du but de la forme dans le contexte de la diapositive. |
| [getName](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getName--) | Le nom de la forme, que le code peut utiliser pour trouver une forme specifique dans la presentation. |
| Visible text | Contenu affiche sur la diapositive, tel que le texte d'une forme ou le titre et les libelles d'un graphique. Mettre a jour le texte alternatif ne modifie pas ce contenu. |

Lorsque une presentation est reutilisee comme modele, le code peut trouver une forme par le nom renvoye par [getName](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getName--) avant de le mettre a jour. Ce nom sert a un objectif different du texte alternatif, qui explique ce que le visuel communique au lecteur. La recherche par nom permet aux auteurs d'ameliorer ou de traduire les descriptions sans modifier la facon dont le code trouve la forme. Les noms peuvent etre modifies et ne sont pas garantis d'etre uniques, il faut donc verifier que le nom correspond a la forme prevue; voir [Identify and Find Shapes](/slides/fr/java/shape-manipulations/#identify-and-find-shapes).

L'exemple suivant necessite `input.pptx` contenant une image d'une entree de bureau comme premiere forme de la premiere diapositive. L'image ne doit pas etre marquee comme decoratif. L'exemple lit et affiche le titre et la description actuels du texte alternatif, met a jour les deux valeurs et enregistre la presentation sous `output.pptx`. Adaptez le libelle a l'image reelle et aux informations qu'elle transmet.

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

Ajouter uniquement du texte alternatif ne garantit pas l'accessibilite d'une presentation ni la conformite aux normes d'accessibilite. Verifiez les descriptions pour leur exactite et leur pertinence, et examinez egalement l'ordre de lecture, le contraste des couleurs, le texte lisible et d'autres exigences d'accessibilite. Les visuels informatifs ne doivent pas etre marques comme decoratifs; la section suivante montre comment verifier [isDecorative](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#isDecorative--).

## **Marquer comme decoratif**

Le drapeau "Mark as decorative" indique que les elements purement ornamentaux doivent etre ignores par les lecteurs d'ecran, reduisant le bruit et maintenant le focus sur le contenu significatif. Appliquez-le aux arriere-plans, aux ornaments et aux espaces - jamais aux graphiques, aux icones ou aux images qui transmettent des informations. Aspose.Slides expose ce drapeau pour la detection et la validation, permettant des verifications automatisees d'accessibilite et le nettoyage.

![Marquer comme decoratif](mark_as_decorative.png)

L'exemple de code suivant montre comment determiner si une forme est marquee comme decorative.

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

**Quel texte dois-je mettre dans le titre et la description du texte alternatif ?**

Utilisez un titre court pour identifier le sujet et une description pour expliquer l'information que le visuel transmet dans le contexte de la diapositive. Pour un graphique, décrivez la tendance ou la comparaison pertinente plutot que de simplement dire "graphique".

**Dois-je utiliser le texte alternatif pour localiser des formes dans un modele ?**

Il est prefere de trouver la forme par le nom renvoye par [getName](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getName--) et de verifier que c'est la forme attendue. Le texte alternatif peut etre modifie ou traduit, ce qui peut casser le code qui recherche une description exacte; voir [Identify and Find Shapes](/slides/fr/java/shape-manipulations/).

**Quand une forme doit-elle etre marquee comme decorative ?**

Utilisez le drapeau decoratif pour les visuels qui n'ajoutent aucune information, comme les ornaments decoratifs. Les images et les graphiques qui communiquent une signification necessitent une description appropriee.

**L'ajout de texte alternatif rend-il une presentation totalement accessible ?**

Non. Le texte alternatif ne couvre qu'une partie de l'accessibilite. Il faut egalement verifier l'ordre de lecture, le contraste des couleurs, la lisibilite du texte et d'autres exigences applicables; definir ces proprietes seules ne suffit pas a assurer la conformite.