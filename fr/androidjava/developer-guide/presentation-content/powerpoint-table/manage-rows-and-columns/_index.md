---
title: Gérer les lignes et les colonnes
type: docs
weight: 20
url: /fr/androidjava/manage-rows-and-columns/
keywords: "Table, lignes et colonnes de tableau, présentation PowerPoint, Java, Aspose.Slides pour Android via Java"
description: "Gérer les lignes et les colonnes des tableaux dans des présentations PowerPoint en Java"
---

Pour vous permettre de gérer les lignes et les colonnes d'un tableau dans une présentation PowerPoint, Aspose.Slides fournit la class [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/), l'interface [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) et de nombreux autres types.

## **Définir la première ligne comme en-tête**

1. Créez une instance de la class [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) et chargez la présentation.
2. Obtenez la référence d'une diapositive via son index.
3. Créez un objet [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) et définissez-le sur null.
4. Parcourez tous les objets [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) pour trouver le tableau pertinent.
5. Définissez la première ligne du tableau comme son en-tête.

Ce code Java vous montre comment définir la première ligne d'un tableau comme son en-tête :

```java
// Instancie la classe Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Initialise le TableEx null
    ITable tbl = null;

    // Parcourt les formes et définit une référence au tableau
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            // Définit la première ligne d'un tableau comme son en-tête
            tbl.setFirstRow(true);
        }
    }
    
    // Enregistre la présentation sur le disque
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Cloner la ligne ou la colonne du tableau**

1. Créez une instance de la class [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) et chargez la présentation,
2. Obtenez la référence d'une diapositive via son index.
3. Définissez un tableau de `columnWidth`.
4. Définissez un tableau de `rowHeight`.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Clonez la ligne du tableau.
7. Clonez la colonne du tableau.
8. Enregistrez la présentation modifiée.

Ce code Java vous montre comment cloner une ligne ou une colonne d'un tableau PowerPoint :

```java
 // Instancie la classe Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Définit les colonnes avec des largeurs et les lignes avec des hauteurs
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Ajoute une forme de tableau à la diapositive
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ajoute un texte dans la cellule 1 de la ligne 1
    table.get_Item(0, 0).getTextFrame().setText("Cellule 1 Ligne 1");

    // Ajoute un texte dans la cellule 2 de la ligne 1
    table.get_Item(1, 0).getTextFrame().setText("Cellule 2 Ligne 1");

    // Clone la ligne 1 à la fin du tableau
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Ajoute un texte dans la cellule 1 de la ligne 2
    table.get_Item(0, 1).getTextFrame().setText("Cellule 1 Ligne 2");

    // Ajoute un texte dans la cellule 2 de la ligne 2
    table.get_Item(1, 1).getTextFrame().setText("Cellule 2 Ligne 2");

    // Clone la ligne 2 comme la 4ème ligne du tableau
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Clone la première colonne à la fin
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Clone la 2ème colonne à l'index de la 4ème colonne
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Enregistre la présentation sur le disque
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Supprimer une ligne ou une colonne d'un tableau**

1. Créez une instance de la class [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) et chargez la présentation,
2. Obtenez la référence d'une diapositive via son index.
3. Définissez un tableau de `columnWidth`.
4. Définissez un tableau de `rowHeight`.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Supprimez la ligne du tableau.
7. Supprimez la colonne du tableau.
8. Enregistrez la présentation modifiée.

Ce code Java vous montre comment supprimer une ligne ou une colonne d'un tableau :

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir le formatage du texte au niveau des lignes du tableau**

1. Créez une instance de la class [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) et chargez la présentation,
2. Obtenez la référence d'une diapositive via son index.
3. Accédez à l'objet [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) pertinent à partir de la diapositive.
4. Définissez la hauteur de police des cellules de la première ligne avec [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).
5. Définissez l'alignement des cellules de la première ligne avec [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) et [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Définissez le type vertical du texte des cellules de la deuxième ligne avec [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Enregistrez la présentation modifiée.

Ce code Java démontre l'opération.

```java
// Crée une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Supposons que la première forme sur la première diapositive soit un tableau
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // Définit la hauteur de police des cellules de la première ligne
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // Définit l'alignement du texte et la marge droite des cellules de la première ligne
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // Définit le type vertical du texte des cellules de la deuxième ligne
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

    // Enregistre la présentation sur le disque
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir le formatage du texte au niveau des colonnes du tableau**

1. Créez une instance de la class [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) et chargez la présentation,
2. Obtenez la référence d'une diapositive via son index.
3. Accédez à l'objet [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) pertinent à partir de la diapositive.
4. Définissez la hauteur de police des cellules de la première colonne avec [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).
5. Définissez l'alignement et la marge droite des cellules de la première colonne avec [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) et [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Définissez le type vertical du texte des cellules de la deuxième colonne avec [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Enregistrez la présentation modifiée.

Ce code Java démontre l'opération :

```java
// Crée une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Supposons que la première forme sur la première diapositive soit un tableau
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // Définit la hauteur de police des cellules de la première colonne
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // Définit l'alignement du texte et la marge droite des cellules de la première colonne en une seule appel
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Définit le type vertical du texte des cellules de la deuxième colonne
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtenir les propriétés de style du tableau**

Aspose.Slides vous permet de récupérer les propriétés de style d'un tableau afin que vous puissiez utiliser ces détails pour un autre tableau ou ailleurs. Ce code Java vous montre comment obtenir les propriétés de style à partir d'un style de tableau prédéfini :

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // change le thème de style par défaut
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```