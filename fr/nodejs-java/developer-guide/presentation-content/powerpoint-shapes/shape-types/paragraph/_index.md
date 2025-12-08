---
title: Paragraphe
type: docs
weight: 60
url: /fr/nodejs-java/paragraph/
---

## **Obtenir les coordonnées du paragraphe et de la portion dans TextFrame**
En utilisant Aspose.Slides for Node.js via Java, les développeurs peuvent désormais obtenir les coordonnées rectangulaires du paragraphe à l'intérieur de la collection de paragraphes du TextFrame. Cela permet également d'obtenir [les coordonnées de la portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getCoordinates--) à l'intérieur de la collection de portions d'un paragraphe. Dans ce sujet, nous allons démontrer à l'aide d'un exemple comment obtenir les coordonnées rectangulaires du paragraphe ainsi que la position de la portion à l'intérieur d'un paragraphe.
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```


## **Obtenir les coordonnées rectangulaires du paragraphe**
En utilisant la méthode [**getRect()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph#getRect--) les développeurs peuvent obtenir le rectangle des limites du paragraphe.
```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtenir la taille du paragraphe et de la portion à l'intérieur du cadre de texte d'une cellule de tableau**
Pour obtenir la taille et les coordonnées de la [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) ou du [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph) dans le cadre de texte d'une cellule de tableau, vous pouvez utiliser les méthodes [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getRect--) et [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph#getRect--).
Ce code d'exemple illustre l'opération décrite :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Dans quelles unités les coordonnées retournées pour un paragraphe et les portions de texte sont‑elles mesurées ?**  
En points, où 1 pouce = 72 points. Cela s'applique à toutes les coordonnées et dimensions sur la diapositive.

**Le retour à la ligne affecte‑t‑il les limites d'un paragraphe ?**  
Oui. Si [wrapping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) est activé dans le [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/), le texte se coupe pour s'adapter à la largeur de la zone, ce qui modifie les limites réelles du paragraphe.

**Les coordonnées du paragraphe peuvent‑elles être mappées de façon fiable aux pixels dans l'image exportée ?**  
Oui. Convertissez les points en pixels en utilisant : pixels = points × (DPI / 72). Le résultat dépend du DPI choisi pour le rendu/l'exportation.

**Comment obtenir les paramètres de mise en forme « effectifs » du paragraphe, en tenant compte de l'héritage des styles ?**  
Utilisez la [structure de données de la mise en forme de paragraphe effective](/slides/fr/nodejs-java/shape-effective-properties/); elle renvoie les valeurs finales consolidées pour les retraits, l'espacement, le retour à la ligne, le RTL et bien plus.