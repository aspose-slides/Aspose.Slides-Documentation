---
title: Gérer les zones de texte dans les présentations avec Java
linktitle: Gérer la zone de texte
type: docs
weight: 20
url: /fr/java/manage-textbox/
keywords:
- zone de texte
- cadre de texte
- ajouter du texte
- mettre à jour le texte
- créer une zone de texte
- vérifier la zone de texte
- ajouter une colonne de texte
- ajouter un hyperlien
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Créer, identifier, formater et mettre à jour des zones de texte dans les présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour Java."
---
## **Introduction**

Dans Aspose.Slides for Java, le texte d’une diapositive est stocké dans des cadres de texte appartenant à des formes. L’interface [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) représente la forme la plus courante contenant du texte et expose son texte via la méthode [IAutoShape.getTextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/#getTextFrame--).

{{% alert color="info" title="Note" %}}

Chaque forme automatique implémente [IShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/), mais toutes les formes ne sont pas des formes automatiques ni ne prennent en charge un cadre de texte. Lors du traitement d’une présentation existante, vérifiez qu’une forme implémente [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) avant d’accéder à son texte.

{{% /alert %}}

## **Créer une zone de texte sur une diapositive**

Pour créer une zone de texte, ajoutez une forme automatique à une diapositive, ajoutez du texte à son cadre de texte, puis enregistrez la présentation. L’exemple suivant crée une zone de texte rectangulaire :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Les coordonnées et dimensions passées à [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) sont exprimées en points. [IAutoShape.addTextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) initialise le cadre de texte avec le texte fourni.

## **Vérifier la présence d’une forme de zone de texte**

Utilisez la méthode [IAutoShape.isTextBox](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/#isTextBox--) pour déterminer si une forme automatique est considérée comme une zone de texte. Ceci est utile lorsqu’une présentation contient à la fois des formes automatiques contenant du texte et des formes purement graphiques.

![Une zone de texte et une forme](istextbox.png)

L’exemple suivant examine chaque forme automatique d’une présentation :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Une forme automatique nouvellement ajoutée n’est pas considérée comme une zone de texte tant qu’elle ne contient pas de texte non vide. Vous pouvez fournir ce texte via [IAutoShape.addTextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) ou [ITextFrame.setText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#setText-java.lang.String-). Ajouter ou affecter une chaîne vide laisse [IAutoShape.isTextBox](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/#isTextBox--) renvoyer `false` :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

Les deux premiers appels affichent `true` ; les deux derniers affichent `false`.

## **Trouver la forme qui possède un cadre de texte**

Un code de traitement de texte générique peut recevoir un [ITextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/) sans savoir quel objet de présentation le contient. Utilisez la méthode en lecture seule [ITextFrame.getParentShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#getParentShape--) pour revenir à son [IShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/) propriétaire.

Pour un cadre de texte appartenant à une forme automatique ou à une autre forme contenant du texte, [ITextFrame.getParentShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#getParentShape--) renvoie le propriétaire et [ITextFrame.getParentCell](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#getParentCell--) renvoie `null`. Vérifiez la valeur renvoyée avant de l’utiliser. Pour identifier à la fois les propriétaires de forme et de cellule de tableau, y compris les formes associées aux nœuds SmartArt, consultez [Search and Replace Text](/slides/fr/java/search-and-replace-text/).

## **Ajouter des colonnes à une zone de texte**

La méthode [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframeformat/#setColumnCount-int-) divise le cadre de texte en colonnes, tandis que [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) définit l’espace entre les colonnes en points. Les deux réglages appartiennent à [ITextFrameFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframeformat/) et peuvent être modifiés via le cadre de texte d’une zone de texte existante. Le texte s’écoule entre les colonnes à l’intérieur de la même forme ; il ne continue pas dans une autre forme.

L’exemple suivant crée une zone de texte à trois colonnes avec 10 points d’espacement entre les colonnes, enregistre la présentation et lit les paramètres enregistrés dans le fichier de sortie :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Extraire le texte des colonnes individuelles**

Utilisez [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#splitTextByColumns--) pour récupérer le texte attribué à chaque colonne visuelle d’un cadre de texte existant. La méthode renvoie une chaîne pour chaque colonne, dans l’ordre de lecture basé sur les colonnes. Un cadre de texte à une seule colonne produit un tableau contenant un élément, et une colonne vide est représentée par une chaîne vide. Les chaînes contiennent uniquement du texte brut ; le formatage au niveau des portions n’est pas conservé.

Ceci est utile lorsque vous devez :

- Extraire le texte tout en préservant son ordre de lecture basé sur les colonnes.
- Indexer ou comparer le contenu de diapositives à colonnes multiples.
- Exporter chaque colonne vers un fichier distinct, un champ de base de données ou une autre destination.
- Examiner comment le texte est redistribué après modification du nombre de colonnes avec [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframeformat/#setColumnCount-int-), de l’espacement avec [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), de la police ou de la taille du cadre de texte.

La méthode rapporte le texte réparti dans le [ITextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/) actuel ; elle ne fait pas circuler automatiquement le texte entre des formes ou zones de texte distinctes. La distribution des colonnes peut dépendre des polices disponibles et d’autres paramètres de mise en page du texte, assurez‑vous donc que les polices requises sont présentes lorsque la cohérence des résultats est importante.

L’exemple suivant charge une présentation, trouve la première forme automatique à colonnes multiples contenant un cadre de texte, lit le nombre de colonnes configuré et écrit le texte de chaque colonne dans un fichier distinct. Les formes ne fournissant pas de cadre de texte sont ignorées.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            Path outputPath = Paths.get("Column-" + columnNumber + ".txt");
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try {
                Files.write(outputPath, textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Mettre à jour le texte**

Pour mettre à jour le texte dans l’ensemble d’une présentation, parcourez les diapositives et les formes, sélectionnez les formes automatiques, puis modifiez leurs portions de texte. Travailler au niveau des portions permet de modifier à la fois le texte et le formatage des caractères.

L’exemple suivant remplace chaque occurrence de `years` par `months` dans le texte des formes automatiques et rend chaque portion concernée en gras :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ce parcours met à jour le texte uniquement dans les formes automatiques. Le texte stocké dans les tableaux, graphiques, SmartArt ou formes groupées nécessite le parcours des collections propres à ces objets.

## **Ajouter une zone de texte avec un lien hypertexte**

Un lien hypertexte peut être affecté à une portion de texte spécifique, de sorte que seul ce texte agit comme lien cliquable. Utilisez [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) pour associer la portion à une URL externe.

L’exemple suivant crée du texte lié et l’enregistre dans une présentation :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Quelle est la différence entre une zone de texte et un espace réservé de texte sur une diapositive maître ou de disposition ?**

Un [espace réservé](/slides/fr/java/manage-placeholder/) peut hériter de sa position et de son formatage d’une [diapositive maître](https://reference.aspose.com/slides/fr/java/com.aspose.slides/masterslide/) ou d’une [diapositive de disposition](https://reference.aspose.com/slides/fr/java/com.aspose.slides/layoutslide/). Une zone de texte ordinaire est une forme indépendante sur la diapositive où elle a été créée et n’acquiert pas le comportement d’espace réservé lorsque la disposition change.

**Comment remplacer du texte sans modifier le texte des graphiques, tableaux ou SmartArt ?**

Limitez le parcours aux formes qui implémentent [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/), comme montré dans l’exemple Mettre à jour le texte. Les graphiques, tableaux et SmartArt stockent le texte dans leurs propres modèles d’objets, ils ne sont donc pas modifiés par cette boucle.