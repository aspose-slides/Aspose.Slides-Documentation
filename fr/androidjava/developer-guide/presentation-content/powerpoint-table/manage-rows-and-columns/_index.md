---
title: Gérer les lignes et colonnes dans les tableaux PowerPoint sur Android
linktitle: Lignes et colonnes
type: docs
weight: 20
url: /fr/androidjava/manage-rows-and-columns/
keywords:
- ligne de tableau
- colonne de tableau
- première ligne
- en-tête du tableau
- cloner la ligne
- cloner la colonne
- copier la ligne
- copier la colonne
- supprimer la ligne
- supprimer la colonne
- formatage du texte de la ligne
- formatage du texte de la colonne
- style du tableau
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Gérez les lignes et colonnes de tableau dans PowerPoint avec Aspose.Slides pour Android via Java et accélerez la modification des présentations ainsi que la mise à jour des données."
---

Pour vous permettre de gérer les lignes et les colonnes d’un tableau dans une présentation PowerPoint, Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) , l’interface [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) et de nombreux autres types.

## **Définir la première ligne comme en‑tête**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) et chargez la présentation.  
2. Obtenez la référence d’une diapositive via son indice.  
3. Créez un objet [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) et affectez‑lui la valeur null.  
4. Parcourez tous les objets [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) pour trouver le tableau correspondant.  
5. Définissez la première ligne du tableau comme en‑tête.  

Ce code Java montre comment définir la première ligne d’un tableau comme en‑tête :
```java
// Instancie la classe Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Initialise le TableEx nul
    ITable tbl = null;

    // Parcourt les formes et définit une référence au tableau
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Définit la première ligne du tableau comme en‑tête
            tbl.setFirstRow(true);
        }
    }
    
    // Enregistre la présentation sur le disque
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Cloner une ligne ou une colonne de tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) et chargez la présentation,  
2. Obtenez la référence d’une diapositive via son indice.  
3. Définissez un tableau de `columnWidth`.  
4. Définissez un tableau de `rowHeight`.  
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. Clonez la ligne du tableau.  
7. Clonez la colonne du tableau.  
8. Enregistrez la présentation modifiée.  

Ce code Java montre comment cloner une ligne ou une colonne d’un tableau PowerPoint :
```java
 // Instancie la classe Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Ajoute une forme de tableau à la diapositive
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ajoute du texte à la cellule de la ligne 1, colonne 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // Ajoute du texte à la cellule de la ligne 1, colonne 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // Clone la ligne 1 à la fin du tableau
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Ajoute du texte à la cellule de la ligne 2, colonne 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // Ajoute du texte à la cellule de la ligne 2, colonne 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // Clone la ligne 2 comme 4ème ligne du tableau
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Clone la première colonne à la fin
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Clone la deuxième colonne à l'index de la quatrième colonne
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Enregistre la présentation sur le disque
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Supprimer une ligne ou une colonne d’un tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) et chargez la présentation,  
2. Obtenez la référence d’une diapositive via son indice.  
3. Définissez un tableau de `columnWidth`.  
4. Définissez un tableau de `rowHeight`.  
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. Supprimez la ligne du tableau.  
7. Supprimez la colonne du tableau.  
8. Enregistrez la présentation modifiée.  

Ce code Java montre comment supprimer une ligne ou une colonne d’un tableau :
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


## **Définir le format de texte au niveau des lignes du tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) et chargez la présentation,  
2. Obtenez la référence d’une diapositive via son indice.  
3. Accédez à l’objet [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) pertinent depuis la diapositive.  
4. Définissez la hauteur de police des cellules de la première ligne à l’aide de [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Définissez l’alignement des cellules de la première ligne avec [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) et la marge droite avec [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. Définissez le type de texte vertical des cellules de la deuxième ligne avec [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).  
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
    
    // Définit le type de texte vertical des cellules de la deuxième ligne
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // Enregistre la présentation sur le disque
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir le format de texte au niveau des colonnes du tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) et chargez la présentation,  
2. Obtenez la référence d’une diapositive via son indice.  
3. Accédez à l’objet [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) pertinent depuis la diapositive.  
4. Définissez la hauteur de police des cellules de la première colonne avec [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Définissez l’alignement des cellules de la première colonne avec [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) et la marge droite avec [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. Définissez le type de texte vertical des cellules de la deuxième colonne avec [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).  
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

    // Définit l'alignement du texte et la marge droite des cellules de la première colonne en un seul appel
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Définit le type de texte vertical des cellules de la deuxième colonne
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtenir les propriétés de style du tableau**

Aspose.Slides vous permet de récupérer les propriétés de style d’un tableau afin de pouvoir utiliser ces informations pour un autre tableau ou ailleurs. Ce code Java montre comment obtenir les propriétés de style d’un style prédéfini de tableau :
```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // modifie le thème du style prédéfini par défaut
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Puis‑je appliquer des thèmes/styles PowerPoint à un tableau déjà créé ?**  
Oui. Le tableau hérite du thème de la diapositive / mise en page / maître, et vous pouvez toujours remplacer les remplissages, les bordures et les couleurs de texte par-dessus ce thème.

**Puis‑je trier les lignes d’un tableau comme dans Excel ?**  
Non, les tableaux d’Aspose.Slides n’ont pas de fonction de tri ou de filtres intégrée. Triez d’abord vos données en mémoire, puis repopulez les lignes du tableau dans cet ordre.

**Puis‑je avoir des colonnes à bandes (rayées) tout en conservant des couleurs personnalisées sur des cellules spécifiques ?**  
Oui. Activez les colonnes à bandes, puis remplacez les cellules spécifiques par un formatage local ; le formatage au niveau de la cellule l’emporte sur le style du tableau.