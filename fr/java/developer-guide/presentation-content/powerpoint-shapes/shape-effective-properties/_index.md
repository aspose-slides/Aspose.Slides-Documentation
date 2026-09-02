---
title: Obtenir les propriétés effectives des formes à partir des présentations en Java
linktitle: Propriétés effectives
type: docs
weight: 50
url: /fr/java/shape-effective-properties/
keywords:
- propriétés de forme
- propriétés de la caméra
- système d'éclairage
- forme biseautée
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à utiliser Aspose.Slides pour Java afin de distinguer le formatage local, hérité et effectif des formes dans les présentations PowerPoint."
---
## **Comprendre les propriétés locales, héritées et effectives**

Le formatage PowerPoint peut provenir de plusieurs sources. La valeur stockée directement sur un objet est sa **valeur locale**. Si cette valeur n’est pas définie, PowerPoint examine les sources de formatage parentes, comme le paramètre par défaut d’un paragraphe, un style de texte, une diapositive de mise en page ou maîtresse, un thème ou les paramètres par défaut au niveau de la présentation. Ces valeurs sont des **valeurs héritées**. La valeur qui reste après la résolution de toute la hiérarchie est la **valeur effective** — la valeur utilisée pour rendre l’objet.

Par exemple, une portion de texte peut ne pas définir sa propre hauteur de police. Sa valeur locale [getFontHeight](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) est alors `Float.NaN`, ce qui signifie « non défini ici ». La portion peut hériter d’une hauteur de son paragraphe, du style de texte par défaut de la présentation, ou d’une autre source applicable. Appeler [getEffective](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportionformat/#getEffective--) sur le format de la portion renvoie la hauteur résolue finale.

Utilisez les deux types de données de formatage à des fins différentes :

- Lire ou modifier un objet de format local, tel que [IPortionFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportionformat/), lorsque vous devez contrôler où une valeur est définie.
- Lire un objet de données effectives, tel que [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportionformateffectivedata/), lorsque vous avez besoin du résultat final rendu. Les données effectives sont en lecture seule.

## **Comparer les valeurs locales, héritées et effectives**

L’exemple complet suivant crée une forme et applique des hauteurs de police au niveau de la présentation, du paragraphe et de la portion. Chaque étape affiche les valeurs définies à ces niveaux et la valeur effective résultante pour la même portion de texte. Il montre également pourquoi les données effectives doivent être relues après des modifications de formatage.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
            ITextFrame textFrame = shape.addTextFrame("Effective formatting");
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            // Définir les valeurs héritées à deux niveaux différents.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // Une valeur locale sur la portion remplace les deux valeurs héritées.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // Modifier une valeur héritée ne remplace pas une valeur locale existante.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // Effacer la valeur locale. La portion hérite à nouveau du paragraphe.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // Effacer la valeur du paragraphe. La valeur par défaut de la présentation fournit maintenant le résultat.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

            presentation.save("effective-properties.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static void printFontHeights(String caption, Presentation presentation, IParagraph paragraph, IPortion portion) {
        float presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
        float paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
        float localValue = portion.getPortionFormat().getFontHeight();

        // Lire les données effectives après les changements précédents.
        float effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

        System.out.println(caption);
        System.out.println("  Presentation default: " + formatLocalValue(presentationValue));
        System.out.println("  Paragraph default:    " + formatLocalValue(paragraphValue));
        System.out.println("  Portion local:        " + formatLocalValue(localValue));
        System.out.println("  Portion effective:    " + effectiveValue);
    }

    private static String formatLocalValue(float value) {
        return Float.isNaN(value) ? "<not set>" : Float.toString(value);
    }
}
```

La priorité dans cet exemple est le formatage local de la portion, suivi du formatage du paragraphe, puis du paramètre par défaut de la présentation. D’autres objets peuvent avoir des chaînes d’héritage différentes, mais le principe reste le même : une valeur explicite plus spécifique l’emporte, et [getEffective](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportionformat/#getEffective--) renvoie le résultat final.

## **Obtenir les propriétés de texte effectives**

Le formatage du texte est réparti sur plusieurs objets :

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframeformat/#getEffective--) résout les propriétés du cadre de texte telles que les marges, l’ancrage, l’ajustement automatique et la direction verticale du texte.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextstyle/#getEffective--) résout le formatage de paragraphe pour chaque niveau de style de texte.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#getEffective--) résout les propriétés de paragraphe telles que l’alignement, l’indentation et les puces.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportionformat/#getEffective--) résout les propriétés de caractère telles que la hauteur de police, la police, la couleur, le gras et l’italique.

Pour l’exemple suivant, `text-formatting.pptx` doit contenir au moins une diapositive et une [AutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/autoshape/) avec un cadre de texte non vide. L’AutoShape peut se trouver à n’importe quelle position dans la collection de formes ; le code recherche un objet approprié et le valide avant utilisation.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("text-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            IAutoShape shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
            if (shape == null) {
                throw new IllegalStateException("The first slide must contain an AutoShape with non-empty text.");
            }

            ITextFrame textFrame = shape.getTextFrame();
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            ITextFrameFormatEffectiveData textFrameEffective = textFrame.getTextFrameFormat().getEffective();
            IParagraphFormatEffectiveData paragraphEffective = paragraph.getParagraphFormat().getEffective();
            IPortionFormatEffectiveData portionEffective = portion.getPortionFormat().getEffective();

            System.out.println("Text frame margins:");
            System.out.println("  Left: " + textFrameEffective.getMarginLeft());
            System.out.println("  Top: " + textFrameEffective.getMarginTop());
            System.out.println("  Right: " + textFrameEffective.getMarginRight());
            System.out.println("  Bottom: " + textFrameEffective.getMarginBottom());
            System.out.println("Paragraph alignment: " + paragraphEffective.getAlignment());
            System.out.println("Font height: " + portionEffective.getFontHeight());
            System.out.println("Bold: " + portionEffective.getFontBold());

            ITextStyleEffectiveData effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
            for (int level = 0; level < 9; level++) {
                IParagraphFormatEffectiveData levelEffective = effectiveTextStyle.getLevel(level);
                System.out.println("Level " + level + " indent: " + levelEffective.getIndent());
            }
        } finally {
            presentation.dispose();
        }
    }

    private static IAutoShape findAutoShapeWithText(ISlide slide) {
        for (IShape candidate : slide.getShapes()) {
            if (candidate instanceof IAutoShape && hasNonEmptyText((IAutoShape)candidate)) {
                return (IAutoShape)candidate;
            }
        }
        return null;
    }

    private static boolean hasNonEmptyText(IAutoShape shape) {
        if (shape.getTextFrame() == null) {
            return false;
        }
        if (shape.getTextFrame().getParagraphs().getCount() == 0) {
            return false;
        }
        return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
    }
}
```

## **Obtenir les propriétés 3D effectives**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ithreedformat/#getEffective--) renvoie un objet [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ithreedformateffectivedata/) qui regroupe tous les paramètres 3D résolus. Ses méthodes [getCamera](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--), et [getBevelBottom](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) exposent les données effectives correspondantes. Lire ces paramètres associés ensemble facilite la compréhension de l’apparence 3D finale d’une forme.

Pour cet exemple, `shape-3d.pptx` doit contenir au moins une forme sur sa première diapositive. Appliquez des paramètres de caméra 3D, d’éclairage ou de biseau à cette forme si vous souhaitez que la sortie contienne des valeurs autres que les valeurs par défaut.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("shape-3d.pptx");
        try {
            if (presentation.getSlides().size() == 0 || presentation.getSlides().get_Item(0).getShapes().size() == 0) {
                throw new IllegalStateException("The first slide must contain a shape.");
            }

            IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
            IThreeDFormatEffectiveData threeDEffective = shape.getThreeDFormat().getEffective();

            System.out.println("Camera:");
            System.out.println("  Type: " + threeDEffective.getCamera().getCameraType());
            System.out.println("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
            System.out.println("  Zoom: " + threeDEffective.getCamera().getZoom());

            System.out.println("Light rig:");
            System.out.println("  Type: " + threeDEffective.getLightRig().getLightType());
            System.out.println("  Direction: " + threeDEffective.getLightRig().getDirection());

            System.out.println("Top bevel:");
            System.out.println("  Type: " + threeDEffective.getBevelTop().getBevelType());
            System.out.println("  Width: " + threeDEffective.getBevelTop().getWidth());
            System.out.println("  Height: " + threeDEffective.getBevelTop().getHeight());
        } finally {
            presentation.dispose();
        }
    }
}
```

## **Obtenir le formatage de tableau effectif**

Le formatage d’un tableau peut provenir du style de tableau et des formats appliqués à l’ensemble du tableau, à une colonne, à une ligne ou à une cellule individuelle. En cas de conflit entre des remplissages définis explicitement, la priorité est : cellule, ligne, colonne, puis tableau entier. Le format effectif d’une cellule est le format final utilisé pour dessiner cette cellule.

Pour cet exemple, `table-formatting.pptx` doit contenir au moins un tableau sur sa première diapositive. Le tableau doit comporter au moins une ligne et une colonne. Le code recherche un [ITable](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itable/) plutôt que de supposer que `getShapes().get_Item(0)` est un tableau.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("table-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            ITable table = findTable(presentation.getSlides().get_Item(0));
            if (table == null) {
                throw new IllegalStateException("The first slide must contain a table.");
            }
            if (table.getRows().size() == 0 || table.getColumns().size() == 0) {
                throw new IllegalStateException("The table must contain at least one cell.");
            }

            ITableFormatEffectiveData tableEffective = table.getTableFormat().getEffective();
            IRowFormatEffectiveData rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
            IColumnFormatEffectiveData columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
            ICellFormatEffectiveData cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

            System.out.println("Table fill: " + tableEffective.getFillFormat().getFillType());
            System.out.println("Row fill: " + rowEffective.getFillFormat().getFillType());
            System.out.println("Column fill: " + columnEffective.getFillFormat().getFillType());
            System.out.println("Final cell fill: " + cellEffective.getFillFormat().getFillType());
        } finally {
            presentation.dispose();
        }
    }

    private static ITable findTable(ISlide slide) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                return (ITable)shape;
            }
        }
        return null;
    }
}
```

Si vous avez besoin de la couleur plutôt que du seul type de remplissage, vérifiez d’abord le [getFillType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifillformateffectivedata/#getFillType--) effectif, puis lisez la méthode correspondant à ce type — par exemple, [getSolidFillColor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) pour un remplissage plein.

## **Relire les données effectives après des modifications**

Les données effectives décrivent la hiérarchie de formatage au moment où elles sont résolues. Appelez à nouveau `getEffective` après avoir modifié quoi que ce soit pouvant participer à cette hiérarchie, y compris :

- le formatage local de l’objet ;
- les paramètres par défaut du paragraphe ou du cadre de texte ;
- un style de tableau, un tableau, une colonne, une ligne ou un format de cellule ;
- le formatage de la mise en page ou de la diapositive maîtresse ;
- les données du thème ou les paramètres par défaut au niveau de la présentation ;
- la mise en page ou le maître affecté à une diapositive.

Ne conservez pas un objet de données effectives comme une capture d’écran permanente. Aspose.Slides peut mettre en cache certaines données effectives en interne, et un appel ultérieur à `getEffective` peut actualiser ces données. Si vous devez comparer les valeurs avant et après une modification, copiez les valeurs scalaires dont vous avez besoin — par exemple une hauteur de police, une couleur, un alignement ou une largeur de biseau — dans vos propres variables avant d’effectuer la modification.

Pour modifier une valeur, mettez à jour l’objet de format local approprié puis appelez `getEffective` pour vérifier le résultat. Les objets de données effectives eux‑mêmes sont en lecture seule.

## **FAQ**

**Comment savoir quel niveau a fourni une valeur effective ?**

Les données effectives contiennent la valeur finale, pas sa source. Inspectez les objets locaux applicables du niveau le plus spécifique vers l’extérieur. Pour le texte, cela peut inclure la portion, le paragraphe, le cadre de texte, la mise en page, le maître, le thème et les paramètres par défaut de la présentation. Les valeurs non définies comme `Float.NaN` ou `null` indiquent que la recherche se poursuit à un autre niveau.

**Que se passe-t-il lorsqu’aucun niveau ne définit une propriété ?**

Aspose.Slides résout la valeur par défaut PowerPoint ou de la bibliothèque appropriée. Cette valeur résolue apparaît dans les données effectives même si aucun objet local ne la définit explicitement.

**Pourquoi une valeur effective est‑elle parfois égale à la valeur locale ?**

La valeur locale a prévalu dans le calcul d’héritage. C’est attendu lorsque la propriété est définie explicitement sur l’objet et qu’aucune règle plus spécifique ne la remplace.

**Quand devrais‑je utiliser les données locales au lieu des données effectives ?**

Utilisez les données locales pour inspecter ou modifier un niveau de formatage spécifique. Utilisez les données effectives lorsque vous avez besoin de l’apparence finale après résolution de l’héritage, des règles de thème et des styles applicables. L’exemple de [complete comparison example](#compare-local-inherited-and-effective-values) montre les deux dans le même flux de travail.