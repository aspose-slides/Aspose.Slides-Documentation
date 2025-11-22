---
title: Gérer les lignes et les colonnes
type: docs
weight: 20
url: /fr/nodejs-java/manage-rows-and-columns/
keywords: "Table, lignes et colonnes de tableau, présentation PowerPoint, Java, Aspose.Slides pour Node.js via Java"
description: "Gérer les lignes et les colonnes d'un tableau dans les présentations PowerPoint en JavaScript"
---

Pour vous permettre de gérer les lignes et les colonnes d’un tableau dans une présentation PowerPoint, Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) , la classe [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) et de nombreux autres types.

## **Définir la première ligne comme en‑tête**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) et chargez la présentation.  
2. Obtenez la référence d’une diapositive via son index.  
3. Créez un objet [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) et définissez‑le sur null.  
4. Parcourez tous les objets [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) pour trouver le tableau correspondant.  
5. Définissez la première ligne du tableau comme en‑tête.  

Ce code JavaScript vous montre comment définir la première ligne d’un tableau comme en‑tête :
```javascript
// Instancie la classe Presentation
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // Accède à la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Initialise le TableEx nul
    var tbl = null;
    // Itère à travers les formes et définit une référence au tableau
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Définit la première ligne d'un tableau comme son en‑tête
            tbl.setFirstRow(true);
        }
    }
    // Enregistre la présentation sur le disque
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Cloner une ligne ou une colonne de tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) et chargez la présentation,  
2. Obtenez la référence d’une diapositive via son index.  
3. Définissez un tableau de `columnWidth`.  
4. Définissez un tableau de `rowHeight`.  
5. Ajoutez un objet [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
6. Clonez la ligne du tableau.  
7. Clonez la colonne du tableau.  
8. Enregistrez la présentation modifiée.  

Ce code JavaScript vous montre comment cloner une ligne ou une colonne d’un tableau PowerPoint :
```javascript
// Instancie la classe Presentation
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // Accède à la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Ajoute une forme de tableau à la diapositive
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Ajoute du texte à la cellule 1 de la ligne 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // Ajoute du texte à la cellule 2 de la ligne 1
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // Clone la ligne 1 à la fin du tableau
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // Ajoute du texte à la cellule 1 de la ligne 2
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // Ajoute du texte à la cellule 2 de la ligne 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // Clone la ligne 2 comme 4e ligne du tableau
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // Clone la première colonne à la fin
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // Clone la 2e colonne à l'index 4
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // Enregistre la présentation sur le disque
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Supprimer une ligne ou une colonne d’un tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) et chargez la présentation,  
2. Obtenez la référence d’une diapositive via son index.  
3. Définissez un tableau de `columnWidth`.  
4. Définissez un tableau de `rowHeight`.  
5. Ajoutez un objet [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
6. Supprimez la ligne du tableau.  
7. Supprimez la colonne du tableau.  
8. Enregistrez la présentation modifiée.  

Ce code JavaScript vous montre comment supprimer une ligne ou une colonne d’un tableau :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir le format du texte au niveau de la ligne du tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) et chargez la présentation,  
2. Obtenez la référence d’une diapositive via son index.  
3. Accédez à l’objet [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) approprié depuis la diapositive.  
4. Définissez la hauteur de police des cellules de la première ligne avec la méthode [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Définissez l’alignement des cellules de la première ligne avec [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) et la marge droite avec [setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Définissez le type de texte vertical des cellules de la deuxième ligne avec [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Enregistrez la présentation modifiée.  

Ce code JavaScript démontre l’opération.
```javascript
// Crée une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Supposons que la première forme de la première diapositive est un tableau
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Définit la hauteur de police des cellules de la première ligne
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // Définit l'alignement du texte et la marge droite des cellules de la première ligne
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // Définit le type de texte vertical des cellules de la deuxième ligne
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // Enregistre la présentation sur le disque
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir le format du texte au niveau de la colonne du tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) et chargez la présentation,  
2. Obtenez la référence d’une diapositive via son index.  
3. Accédez à l’objet [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) approprié depuis la diapositive.  
4. Définissez la hauteur de police des cellules de la première colonne avec la méthode [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Définissez l’alignement des cellules de la première colonne avec [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) et la marge droite avec [setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Définissez le type de texte vertical des cellules de la deuxième colonne avec [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Enregistrez la présentation modifiée.  

Ce code JavaScript démontre l’opération :
```javascript
// Crée une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Supposons que la première forme de la première diapositive est un tableau
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Définit la hauteur de police des cellules de la première colonne
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // Définit l'alignement du texte et la marge droite des cellules de la première colonne en un seul appel
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // Définit le type de texte vertical des cellules de la deuxième colonne
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtenir les propriétés de style du tableau**

Aspose.Slides vous permet de récupérer les propriétés de style d’un tableau afin de les réutiliser pour un autre tableau ou ailleurs. Ce code JavaScript vous montre comment obtenir les propriétés de style à partir d’un style prédéfini de tableau :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// modifie le style prédéfini par défaut
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Puis-je appliquer des thèmes/styles PowerPoint à un tableau déjà créé ?**

Oui. Le tableau hérite du thème de la diapositive/disposition/maître, et vous pouvez toujours remplacer les remplissages, les bordures et les couleurs de texte par-dessus ce thème.

**Puis-je trier les lignes d’un tableau comme dans Excel ?**

Non, les tableaux Aspose.Slides n’ont pas de tri ou de filtres intégrés. Triez vos données en mémoire d’abord, puis repopulez les lignes du tableau dans cet ordre.

**Puis-je avoir des colonnes à bandes (rayées) tout en conservant des couleurs personnalisées sur des cellules spécifiques ?**

Oui. Activez les colonnes à bandes, puis remplacez les cellules spécifiques avec un formatage local ; le formatage au niveau de la cellule prime sur le style du tableau.