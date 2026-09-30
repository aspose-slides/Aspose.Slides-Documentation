---
title: Gérer les tableaux de présentation sur Android
linktitle: Gérer le tableau
type: docs
weight: 10
url: /fr/androidjava/manage-table/
keywords:
- ajouter tableau
- créer tableau
- accéder au tableau
- rapport d'aspect
- aligner le texte
- mise en forme du texte
- style du tableau
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Créer et modifier des tableaux dans les diapositives PowerPoint avec Aspose.Slides pour Android. Découvrez des exemples de code Java simples pour rationaliser vos flux de travail de tableaux."
---
## **Introduction**

Les tableaux dans PowerPoint organisent les informations en lignes et colonnes, ce qui facilite la lecture et la comparaison des valeurs.

Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) , l'interface [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) , la classe [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) , l'interface [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) et d'autres types pour vous permettre de créer, mettre à jour et gérer les tableaux dans les présentations.

## **Créer un tableau à partir de zéro**

Créez un tableau en spécifiant sa position, les largeurs des colonnes et les hauteurs des lignes. Après l'avoir ajouté à une diapositive, vous pouvez formater les bordures des cellules, fusionner les cellules et insérer du texte.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Obtenez une référence à la diapositive par son indice.
3. Définissez un tableau des largeurs de colonnes en points.
4. Définissez un tableau des hauteurs de lignes en points.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) .
6. Parcourez chaque [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) pour appliquer le formatage aux bordures supérieure, inférieure, droite et gauche.
7. Fusionnez les deux premières cellules de la première ligne du tableau.
8. Accédez à la cellule fusionnée via sa méthode [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) .
9. Définissez le texte dans la cellule fusionnée.
10. Enregistrez la présentation modifiée.

L'exemple suivant crée un tableau avec trois colonnes et cinq lignes à (100, 50) points. Il applique des bordures rouges d'une largeur de 5 points, fusionne les deux premières cellules de la première ligne et enregistre le résultat sous `table.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Numérotation dans un tableau standard**

Dans un tableau standard, les indices des cellules commencent à zéro et utilisent l'ordre (colonne, ligne). La première cellule a l'index (0, 0).

Par exemple, les cellules d'un tableau de 4 colonnes et 4 lignes sont numérotées ainsi :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Cet exemple crée le tableau 4 × 4 illustré ci‑dessus, avec des largeurs de colonnes et des hauteurs de lignes de 70 points et des bordures de cellules rouges d’une largeur de 5 points. Les coordonnées illustrent les indices des cellules ; l'exemple laisse les cellules vides et enregistre le tableau sous `StandardTables_out.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Accéder à un tableau existant**

Les tableaux sont stockés dans la collection de formes d’une diapositive. Parcourez les formes pour localiser un tableau, puis utilisez l'interface [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) pour lire ou mettre à jour ses cellules.

1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Obtenez une référence à la diapositive contenant le tableau par son indice.
3. Parcourez les objets [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) et arrêtez‑vous lorsqu'un tableau est trouvé. Si la diapositive contient plusieurs tableaux, utilisez [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getAlternativeText--) pour identifier celui dont vous avez besoin.
4. Mettez à jour le texte dans la cellule cible.
5. Enregistrez la présentation modifiée.

L'exemple suivant ouvre `UpdateExistingTable.pptx` et trouve le premier tableau de la première diapositive. Il définit la cellule de la colonne 0, ligne 1 à `New` et enregistre le résultat sous `table1_out.pptx`. Le fichier d’entrée doit contenir au moins une diapositive, et le premier tableau de cette diapositive doit comporter au moins une colonne et deux lignes.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Pour redimensionner une ligne dans un tableau existant et comprendre pourquoi sa hauteur réelle peut dépasser la hauteur minimale demandée, voir [Contrôler la hauteur des lignes](/slides/fr/androidjava/manage-rows-and-columns/#control-row-height).

## **Trouver la cellule qui possède un cadre de texte**

Lorsque du code générique de traitement de texte reçoit un [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) d’un tableau, utilisez la méthode [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) pour récupérer la [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) propriétaire. Pour un cadre de texte d’une cellule de tableau, [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) renvoie le propriétaire et [ITextFrame.getParentShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentShape--) renvoie `null`, bien que le tableau lui‑même soit une forme.

Les coordonnées de la cellule sont accessibles via les méthodes en lecture seule [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) et [ICell.getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--). [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) fournit également une navigation en lecture seule : elle renvoie le propriétaire mais ne modifie pas la propriété. Vérifiez toujours que la cellule renvoyée n’est pas `null` avant de l’utiliser.

Pour un exemple complet qui identifie les propriétaires de cellules de tableau et de formes, y compris les formes associées aux nœuds SmartArt, voir [Rechercher et remplacer du texte](/slides/fr/androidjava/search-and-replace-text/).

## **Aligner le texte dans un tableau**

Vous pouvez contrôler l’ancrage vertical et la direction du texte des cellules individuelles d’un tableau. L’exemple de cette section centre le texte dans la première cellule et le fait pivoter de 270 degrés.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Obtenez une référence à la diapositive par son indice.
3. Ajoutez un objet [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) à la diapositive.
4. Accédez à un objet [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) du tableau.
5. Accédez au premier [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) et définissez son texte et sa couleur.
6. Définissez l’ancrage vertical et la direction du texte de la cellule à l’aide de [setTextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextAnchorType-byte-) et [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextVerticalType-byte-) .
7. Enregistrez la présentation modifiée.

Cet exemple crée un tableau 4 × 4 avec des largeurs de colonnes de 120 points et des hauteurs de lignes de 100 points. Il formate le texte de la cellule (0, 0), ajoute des valeurs aux cellules restantes de la première ligne et enregistre le résultat sous `Vertical_Align_Text_out.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir le format du texte au niveau du tableau**

Utilisez [setTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) pour appliquer le formatage du texte à toutes les cellules d’un tableau. Ses surcharges acceptent le formatage de portion, de paragraphe et de cadre de texte, vous permettant ainsi de définir ces propriétés sans parcourir chaque cellule.

1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Obtenez une référence à la diapositive par son indice.
3. Accédez à un objet [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) de la diapositive.
4. Définissez la taille de la police avec [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) pour le texte.
5. Définissez l’alignement du paragraphe et la marge droite avec [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) et [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) .
6. Définissez la direction du texte avec [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) .
7. Enregistrez la présentation modifiée.

L’exemple suivant ouvre `table.pptx`, qui doit contenir au moins une diapositive avec un tableau comme première forme. Il définit la taille de la police à 25 points, aligne à droite les paragraphes avec une marge droite de 20 points et rend le texte vertical. La présentation formatée est enregistrée sous `result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obtenir les propriétés du style du tableau**

Utilisez [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) pour lire le style prédéfini d’un tableau et [setStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setStylePreset-int-) pour l’affecter. Cet exemple applique [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/) à un tableau, affiche la valeur du style et affecte le même style à un second tableau. Les deux tableaux sont enregistrés dans `table-style.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verrouiller le ratio d'aspect d'un tableau**

Le ratio d’aspect d’un tableau est le rapport de sa largeur sur sa hauteur. Utilisez [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) pour verrouiller ce ratio pour un tableau.

L’exemple suivant ouvre `pres.pptx`, qui doit contenir au moins une diapositive avec un tableau comme première forme. Il affiche l’état actuel du verrou, active le verrouillage du ratio d’aspect, affiche l’état mis à jour (`true`) et enregistre le résultat sous `pres-out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Puis‑je activer la direction de lecture de droite à gauche (RTL) pour un tableau entier et le texte de ses cellules ?**

Oui. Le tableau expose une méthode [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) , et les paragraphes possèdent [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). L’utilisation des deux assure l’ordre RTL correct et le rendu à l’intérieur des cellules.

**Comment empêcher les utilisateurs de déplacer ou de redimensionner un tableau dans le fichier final ?**

Utilisez les [shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) pour désactiver le déplacement, le redimensionnement, la sélection, etc. Ces verrous s’appliquent également aux tableaux.

**L’insertion d’une image dans une cellule en tant qu’arrière‑plan est‑elle prise en charge ?**

Oui. Vous pouvez définir un [remplissage d'image](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) pour une cellule ; l’image couvrira la zone de la cellule selon le mode choisi (étirement ou mosaïque).