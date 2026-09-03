---
title: Gérer les zones de texte dans les présentations sur Android
linktitle: Gérer la zone de texte
type: docs
weight: 20
url: /fr/androidjava/manage-textbox/
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
- Android
- Java
- Aspose.Slides
description: "Créer, identifier, mettre en forme et mettre à jour les zones de texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Android via Java."
---
## **Introduction**

Dans Aspose.Slides for Android via Java, le texte d'une diapositive est stocké dans des cadres de texte qui appartiennent à des formes. L'interface [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) représente la forme la plus courante contenant du texte et expose son texte via la méthode [IAutoShape.getTextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) .

{{% alert color="info" title="Note" %}}
Toute forme auto implemente [IShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/), mais toutes les formes ne sont pas des formes auto ou ne prennent pas en charge un cadre de texte. Lors du traitement d'une presentation existante, verifiez qu'une forme implemente [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) avant d'acceder a son texte.
{{% /alert %}}

## **Creer une zone de texte sur une diapositive**

Pour creer une zone de texte, ajoutez une forme auto a une diapositive, ajoutez du texte a son cadre de texte, puis enregistrez la presentation. L'exemple suivant cree une zone de texte rectangulaire :

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

Les coordonnees et dimensions passees a [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) sont exprimees en points. [IAutoShape.addTextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) initialise le cadre de texte avec le texte fourni.

## **Verifier la presence d'une forme zone de texte**

Utilisez la methode [IAutoShape.isTextBox](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/#isTextBox--) pour determiner si une forme auto est consideree comme une zone de texte. Cela est utile lorsqu'une presentation contient a la fois des formes auto contenant du texte et des formes purement graphiques.

![Une zone de texte et une forme](istextbox.png)

L'exemple suivant inspecte chaque forme auto d'une presentation :

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

Une forme auto nouvellement ajoutee n'est pas consideree comme une zone de texte tant qu'elle ne contient pas de texte non vide. Vous pouvez fournir ce texte via [IAutoShape.addTextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) ou [ITextFrame.setText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-). Ajouter ou assigner une chaine vide fait retourner `false` par [IAutoShape.isTextBox](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/#isTextBox--) :

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

Les deux premiers appels affichent `true`; les deux derniers affichent `false`.

## **Trouver la forme qui possede un cadre de texte**

Un code de traitement de texte genereique peut recevoir un [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) sans connaitre l'objet de presentation qui le contient. Utilisez la methode en lecture seule [ITextFrame.getParentShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#getParentShape--) pour revenir a sa forme proprietaire [IShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/) .

Pour un cadre de texte detenu par une forme auto ou une autre forme contenant du texte, [ITextFrame.getParentShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#getParentShape--) renvoie le proprietaire et [ITextFrame.getParentCell](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#getParentCell--) renvoie `null`. Verifiez la valeur renvoyee avant de l'utiliser. Pour identifier a la fois les proprietaires de formes et de cellules de tableau, y compris les formes associees aux noeuds SmartArt, voir [Search and Replace Text](/slides/fr/androidjava/search-and-replace-text/) .

## **Ajouter des colonnes a une zone de texte**

La methode [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-) divise le cadre de texte en colonnes, tandis que [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) definit l'espace entre les colonnes en points. Les deux parametres appartiennent a [ITextFrameFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframeformat/) et peuvent etre modifies via le cadre de texte d'une zone de texte existante. Le texte se reajuste entre les colonnes a l'interieur de la meme forme; il ne se poursuit pas dans une autre forme.

L'exemple suivant cree une zone de texte a trois colonnes avec 10 points entre les colonnes, enregistre la presentation et lit les parametres enregistres dans le fichier de sortie :

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

Utilisez [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#splitTextByColumns--) pour recuperer le texte attribue a chaque colonne visuelle d'un cadre de texte existant. La methode renvoie une chaine pour chaque colonne, dans l'ordre de lecture base sur les colonnes. Un cadre de texte a une seule colonne produit un tableau contenant un seul element, et une colonne vide est representee par une chaine vide. Les chaines contiennent uniquement du texte brut; le formatage au niveau des portions n'est pas conserve.

C'est utile lorsque vous devez:

- Extraire le texte tout en conservant son ordre de lecture base sur les colonnes.
- Indexer ou comparer le contenu de diapositives a colonnes multiples.
- Exporter chaque colonne vers un fichier distinct, un champ de base de donnees ou une autre destination.
- Analyser comment le texte est redistribue après avoir modifie le nombre de colonnes avec [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-), l'espacement avec [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), la police ou la taille du cadre de texte.

La methode rapporte le texte repartit dans le [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) actuel; elle ne fait pas automatiquement couler le texte entre des formes ou zones de texte separees. La repartition en colonnes peut dependre des polices disponibles et d'autres parametres de mise en page, assurez-vous donc que les polices requises sont presentes lorsque la coherence des resultats est importante.

L'exemple suivant charge une presentation, trouve la premiere forme auto a colonnes multiples avec un cadre de texte, lit son nombre de colonnes configure et ecrit le texte de chaque colonne dans un fichier distinct. Les formes qui ne fournissent pas de cadre de texte sont ignores.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

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
            String outputPath = "Column-" + columnNumber + ".txt";
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try (FileOutputStream outputStream = new FileOutputStream(outputPath)) {
                outputStream.write(textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Mettre a jour le texte**

Pour mettre a jour le texte dans l'ensemble d'une presentation, parcourez les diapositives et les formes, selectionnez les formes auto, puis modifiez leurs portions de texte. Travailler au niveau des portions permet de changer a la fois le texte et le formatage des caracteres.

L'exemple suivant remplace chaque occurrence de `years` par `months` dans le texte des formes auto et rend chaque portion affectee en gras :

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

Ce parcours met a jour le texte uniquement dans les formes auto. Le texte stocke dans des tableaux, des graphiques, SmartArt ou des formes groupees necessite de parcourir les collections propres a ces objets.

## **Ajouter une zone de texte avec un hyperlien**

Un hyperlien peut etre attribue a une portion de texte specifique, de sorte que seul ce texte agit comme lien cliquable. Utilisez [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) pour associer la portion a une URL externe.

L'exemple suivant cree du texte lie et l'enregistre dans une presentation :

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

**Quelle est la difference entre une zone de texte et un espace reserve de texte sur une diapositive maitre ou de mise en page?**

Un [placeholder](/slides/fr/androidjava/manage-placeholder/) peut heriter de sa position et de son formatage d'une [master slide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/masterslide/) ou d'une [layout slide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/layoutslide/). Une zone de texte ordinaire est une forme independante sur la diapositive ou elle a ete creee et n'acquiert pas le comportement d'espace reserve lorsque la mise en page change.

**Comment remplacer du texte sans modifier le texte dans les graphiques, tableaux ou SmartArt?**

Limitez le parcours aux formes qui implementent [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/), comme le montre l'exemple Mettre a jour le texte. Les graphiques, tableaux et SmartArt stockent le texte dans leurs propres modeles d'objets, ils ne sont donc pas modifies par cette boucle.