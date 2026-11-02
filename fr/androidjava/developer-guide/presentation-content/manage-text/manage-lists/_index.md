---
title: Gérer les listes à puces et numérotées dans les présentations sur Android
linktitle: Gérer les listes
type: docs
weight: 60
url: /fr/androidjava/manage-lists/
keywords:
- puce
- liste à puces
- liste numérotée
- puce symbole
- puce image
- puce personnalisée
- liste à plusieurs niveaux
- créer une puce
- ajouter une puce
- ajouter une liste
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez comment créer et mettre en forme des listes à puces, image, à plusieurs niveaux et numérotées dans des présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour Android via Java."
---
## **Vue d'ensemble**

Aspose.Slides for Android via Java vous permet de créer et de mettre en forme des listes à puces et numérotées dans des présentations PowerPoint et OpenDocument. Un élément de liste est un paragraphe dont les paramètres de puce sont contrôlés via le format de paragraphe.

Utilisez la méthode [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) pour accéder aux paramètres de liste au niveau du paragraphe. Le point d’entrée principal est [IParagraphFormat.getBullet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getBullet--), qui renvoie un objet [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/). Avec cet objet, vous pouvez définir le type de puce, le symbole, l’image, la couleur, la taille, le style de numérotation et le numéro de départ.

Cet article montre comment :

- créer une liste à puces avec un symbole personnalisé
- créer une puce image
- créer une liste à plusieurs niveaux en définissant la profondeur du paragraphe
- créer une liste numérotée
- examiner et modifier la mise en forme des listes dans une présentation existante
- lire les repères et numéros de liste réels à côté du texte du paragraphe

## **Créer une liste à puces**

Pour créer une liste à puces, ajoutez des paragraphes à un [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) et définissez [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) sur [BulletType.Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/). Vous pouvez ensuite définir [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getColor--) et [IBulletFormat.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) pour contrôler l’apparence de la puce.

Le code Java suivant montre comment créer une liste à puces dans une diapositive :

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    int bulletColor = Color.rgb(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les puces symboles](symbol_bullets.png)

## **Créer une liste numérotée**

Utilisez les listes numérotées lorsque l’ordre des éléments est important. Définissez [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) sur [BulletType.Numbered](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/). Vous pouvez également choisir un format de numérotation avec [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) ou définir [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) lorsque la liste doit commencer à une valeur autre que 1.

Le code Java suivant montre comment créer une liste numérotée dans une diapositive :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les puces numérotées](numbered_bullets.png)

## **Créer une puce image**

Aspose.Slides vous permet de remplacer un symbole de puce standard par une image. Les puces image fonctionnent mieux avec des images simples qui restent lisibles à petite taille, comme des icônes ou de petits fichiers PNG transparents.

{{% alert color="info" title="Remarque" %}}
Idéalement, si vous prévoyez de remplacer le symbole de puce standard par une image, il est préférable de choisir un graphique simple avec un fond transparent. Ce type d’image fonctionne bien comme symbole de puce personnalisé.

Gardez à l’esprit que l’image sera réduite à une très petite taille. Pour cette raison, nous recommandons fortement de choisir une image qui reste claire et visuellement efficace lorsqu’elle est utilisée comme puce dans une liste.
{{% /alert %}}

Pour créer une puce image, ajoutez une image à [Presentation.getImages](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getImages--) et affectez l’objet [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) retourné à [IBulletFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getPicture--). Définissez [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) sur [BulletType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/) avant d’affecter l’image.

Supposons que nous ayons un « image.png » :

![Une image pour les puces](picture_for_bullets.png)

Le code Java suivant montre comment créer des puces image dans une diapositive :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les puces image](picture_bullets.png)

## **Créer une liste à plusieurs niveaux**

Utilisez [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) pour placer les éléments de liste à différents niveaux. Le niveau 0 est le niveau supérieur, le niveau 1 est imbriqué en dessous, etc.

Le code Java suivant montre comment créer une liste à plusieurs niveaux :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![La liste à plusieurs niveaux](multilevel_list.png)

## **Modifier une liste existante**

Pour modifier la mise en forme d’une liste dans une présentation existante, accédez au paragraphe cible et mettez à jour ses paramètres [IParagraphFormat.getBullet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getBullet--). Les mêmes méthodes utilisées pour créer des listes peuvent être employées pour inspecter ou modifier des listes chargées depuis un fichier PPT, PPTX ou ODP.

Le code Java suivant modifie le premier paragraphe d’un cadre texte pour utiliser un style de liste numérotée :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lire les valeurs réelles des puces**

Lors de l’extraction du contenu d’une présentation, conservez les repères de liste à côté du texte du paragraphe. Appelez [IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--) et accédez à [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) pour obtenir le format de puce effectif. Vérifiez son [getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getType--) avant de lire [getActualBulletValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--).

Pour les listes numérotées, distinguez ces trois valeurs :

- [getNumberedBulletStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) détermine le format, tel que les nombres arabes suivis d’un point ou les lettres minuscules suivies d’un point.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) spécifie le numéro de départ pour un groupe de paragraphes numérotés.
- [getActualBulletValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) renvoie le repère formaté pour un paragraphe particulier. Par exemple, le deuxième élément d’une liste commençant à 5 renvoie `6.`.

Conservez [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDepth--) avec chaque paragraphe pour retenir son niveau d’imbrication. Le repère réel n’encode pas toute la hiérarchie : un élément imbriqué peut renvoyer `c.` plutôt qu’une étiquette combinée telle que `6.c.`.

Le code auto‑contenu suivant crée des listes, les enregistre dans une présentation, puis recharge la présentation pour rapporter le texte, la profondeur, le type de puce et la valeur réelle de chaque paragraphe. Le petit repère image bleu est créé à partir de SVG en ligne.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Créer un repère image sans fichier d'image externe.
    SvgImage svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    IPPImage bulletImage = presentation.getImages().addImage(svg);

    class ListBuilder {
        void addParagraph(String text, short depth, byte type, short start, byte style) {
            Paragraph paragraph = new Paragraph();
            paragraph.setText(text);

            IParagraphFormat format = paragraph.getParagraphFormat();
            format.setDepth(depth);
            format.setMarginLeft(30 + depth * 40);
            format.setIndent(-28);
            format.setSpaceAfter(8);
            format.getDefaultPortionFormat().setFontHeight(22);
            format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
            format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
            format.getBullet().setType(type);
            format.getBullet().setBulletHardColor(NullableBool.True);
            format.getBullet().getColor().setColor(Color.BLACK);
            if (type == BulletType.Numbered) {
                format.getBullet().setNumberedBulletStyle(style);
                format.getBullet().setNumberedBulletStartWith(start);
            } else if (type == BulletType.Symbol) {
                format.getBullet().setChar('\u2022');
            } else if (type == BulletType.Picture) {
                format.getBullet().getPicture().setImage(bulletImage);
            }

            textFrame.getParagraphs().add(paragraph);
        }
    }

    ListBuilder list = new ListBuilder();
    list.addParagraph("First item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Second item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Next nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Deep item", (short) 2, BulletType.Numbered, (short) 4, NumberedBulletStyle.BulletRomanLCPeriod);
    list.addParagraph("Back to top level", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Symbol marker", (short) 0, BulletType.Symbol, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("No bullet", (short) 0, BulletType.None, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Picture marker", (short) 0, BulletType.Picture, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    IAutoShape loadedShape = (IAutoShape) loadedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Text | Depth | Type | Actual value");
    for (IParagraph paragraph : loadedShape.getTextFrame().getParagraphs()) {
        IBulletFormatEffectiveData bullet = paragraph.getParagraphFormat().getEffective().getBullet();
        String marker;
        switch (bullet.getType()) {
            case BulletType.Numbered:
            case BulletType.Symbol:
                marker = bullet.getActualBulletValue();
                break;
            case BulletType.None:
                marker = bullet.getActualBulletValue() + " (no bullet)";
                break;
            case BulletType.Picture:
                marker = bullet.getActualBulletValue() + " (image required)";
                break;
            default:
                marker = "unsupported bullet type";
                break;
        }
        String typeName = BulletType.getName(BulletType.class, bullet.getType());
        System.out.println(paragraph.getText() + " | " + paragraph.getParagraphFormat().getDepth() + " | " + typeName + " | " + marker);
    }
} finally {
    loadedPresentation.dispose();
}
```

Les listes source sont affichées ci‑dessous.

![Listes commençant à 5, éléments imbriqués en lettres et en chiffres romains, un repère symbole, un paragraphe sans puce, et un repère image bleu](actual_bullet_values.png)

Le rapport correspond aux repères affichés dans PowerPoint :

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

Pour [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/), [getActualBulletValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) renvoie `null`, pas une chaîne vide. Gérez ces types séparément : le premier n’a aucun repère, tandis que le second nécessite d’extraire l’image de la puce séparément. Une puce image ne peut pas être reproduite uniquement en extrayant un repère texte.

## **FAQ**

**Les listes à puces et numérotées peuvent‑elles être exportées en PDF ou en images ?**

Oui. Aspose.Slides conserve la mise en forme des listes lorsque le format cible prend en charge la disposition de texte et les fonctionnalités de puces correspondantes.

**Puis‑je modifier des listes dans des présentations existantes ?**

Oui. Chargez la présentation, accédez au paragraphe cible, inspectez ou mettez à jour ses paramètres [IParagraphFormat.getBullet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getBullet--), puis enregistrez la présentation.

**Les listes peuvent‑elles contenir du texte non latin ?**

Oui. Le texte des éléments de liste peut contenir des caractères Unicode, ce qui vous permet de créer des listes dans des présentations multilingues. Assurez‑vous que les polices utilisées dans la présentation prennent en charge les caractères dont vous avez besoin.