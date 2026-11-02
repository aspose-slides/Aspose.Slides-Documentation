---
title: Beheer opsommingstekens en genummerde lijsten in presentaties in Java
linktitle: Beheer lijsten
type: docs
weight: 60
url: /nl/java/manage-lists/
keywords:
- opsommingsteken
- opsommingslijst
- genummerde lijst
- symbool opsommingsteken
- afbeelding opsommingsteken
- aangepast opsommingsteken
- meerniveau lijst
- maak opsommingsteken
- voeg opsommingsteken toe
- voeg lijst toe
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u opsommingstekens, afbeelding‑, meerniveau‑ en genummerde lijsten kunt maken en opmaken in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Java."
---
## **Overzicht**

Aspose.Slides for Java stelt u in staat om opsommingstekens en genummerde lijsten te maken en op te maken in PowerPoint- en OpenDocument‑presentaties. Een lijstitem is een alinea waarvan de opsommingstekeninstellingen worden beheerd via de alinea‑indeling.

Gebruik de [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) methode om de lijstopmaak op alinea‑niveau te benaderen. Het belangrijkste toegangspunt is [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--), dat een [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) object retourneert. Met dit object kunt u het type opsommingsteken, symbool, afbeelding, kleur, grootte, nummeringsstijl en beginnummer instellen.

Dit artikel laat zien hoe u:

- een opsomming maken met een aangepast symbool
- een afbeelding‑opsommingsteken maken
- een meerlagige lijst maken door de alinea‑diepte in te stellen
- een genummerde lijst maken
- de opsommingopmaak inspecteren en wijzigen in een bestaande presentatie
- de werkelijke lijstmarkeringen en nummers lezen naast de alinea‑tekst

## **Maak een opsommingslijst**

Om een opsomming te maken, voegt u [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) objecten toe aan een [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) en stelt u [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) in op [BulletType.Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Symbol). Vervolgens kunt u [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getColor--) en [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) instellen om het uiterlijk van het opsommingsteken te regelen.

De volgende Java‑code laat zien hoe u een opsomming maakt in een dia:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

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

Het resultaat:

![De symbool‑opsommingstekens](symbol_bullets.png)

## **Maak een genummerde lijst**

Gebruik genummerde lijsten wanneer de volgorde van elementen van belang is. Stel [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) in op [BulletType.Numbered](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Numbered). U kunt ook een nummeringsformaat kiezen met [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) of [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) instellen wanneer de lijst moet beginnen met een waarde anders dan 1.

De volgende Java‑code toont hoe u een genummerde lijst maakt in een dia:

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

Het resultaat:

![De genummerde opsommingstekens](numbered_bullets.png)

## **Maak een afbeelding‑opsommingsteken**

Aspose.Slides stelt u in staat om een regulier opsommingsteken te vervangen door een afbeelding. Afbeeldings‑opsommingstekens werken het beste met eenvoudige afbeeldingen die leesbaar blijven op een kleine grootte, zoals pictogrammen of kleine transparante PNG‑bestanden.

{{% alert color="info" title="Note" %}}
Idealiter, als u van plan bent het reguliere opsommingsteken te vervangen door een afbeelding, is het het beste een eenvoudige afbeelding met een transparante achtergrond te kiezen. Dergelijke afbeeldingen werken goed als aangepaste opsommingstekens.
{{% /alert %}}

Houd er rekening mee dat de afbeelding wordt verkleind tot een zeer kleine afmeting. Daarom raden wij sterk aan een afbeelding te kiezen die duidelijk en visueel effectief blijft wanneer deze als opsommingsteken in een lijst wordt gebruikt.

Om een afbeelding‑opsommingsteken te maken, voegt u een afbeelding toe aan [Presentation.getImages](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--) en kent u het geretourneerde afbeelding‑object toe aan [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--). Stel [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) in op [BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Picture) voordat u de afbeelding toewijst.

Stel dat we een “image.png” hebben:

![Een afbeelding voor de opsommingstekens](picture_for_bullets.png)

De volgende Java‑code laat zien hoe u afbeelding‑opsommingstekens maakt in een dia:

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

Het resultaat:

![De afbeelding‑opsommingstekens](picture_bullets.png)

## **Maak een meerlagige lijst**

Gebruik [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) om lijstitems op verschillende niveaus te plaatsen. Niveau 0 is het bovenste niveau, niveau 1 is eronder genesteld, enzovoort.

De volgende Java‑code laat zien hoe u een meerlagige opsomming maakt:

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

Het resultaat:

![De meerlagige lijst](multilevel_list.png)

## **Wijzig een bestaande lijst**

Om de opsommingopmaak in een bestaande presentatie te wijzigen, krijgt u toegang tot de betreffende alinea en werkt u de [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--) instellingen bij. Dezelfde eigenschappen die worden gebruikt om lijsten te maken, kunnen worden gebruikt om lijsten die uit een PPT-, PPTX- of ODP‑bestand zijn geladen te inspecteren of te wijzigen.

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

## **Lees de daadwerkelijke opsommingstekenwaarden**

Bij het extraheren van presentatietekst, behoudt u de lijstmarkeringen naast de alinea‑tekst. Roep [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--) aan en krijg toegang tot [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) om het daadwerkelijke opsommingstekenformaat te verkrijgen. Controleer eerst de [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) voordat u [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) uitleest.

Voor genummerde lijsten onderscheidt u deze drie waarden:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) bepaalt het format, zoals Arabische cijfers gevolgd door een punt of kleine letters gevolgd door een punt.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) geeft het beginnummer op voor een groep genummerde alinea's.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) retourneert de opgemaakte markering voor een bepaalde alinea. Bijvoorbeeld, het tweede item in een lijst die bij 5 begint, geeft `6.` terug.

Behoud [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDepth--) bij elke alinea om het geneste niveau te behouden. De daadwerkelijke markering codeert niet de volledige hiërarchie: een geneste item kan `c.` retourneren in plaats van een gecombineerde label zoals `6.c.`.

Het volgende zelfstandige voorbeeld maakt lijsten, slaat ze op in een presentatie, en laadt de presentatie opnieuw om voor elke alinea de tekst, diepte, opsommingsteken‑type en werkelijke waarde te rapporteren. De kleine blauwe afbeelding‑markering is gemaakt van inline‑SVG.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Maak een afbeelding‑markering zonder een extern afbeeldingsbestand.
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

De bronlijsten worden hieronder weergegeven.

![Lijsten beginnend bij 5, geneste letters‑ en Romeinse‑nummeritems, een symbool‑markering, een alinea zonder opsommingsteken, en een blauwe afbeelding‑markering](actual_bullet_values.png)

Het rapport komt overeen met de markeringen die in PowerPoint worden weergegeven:

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

Voor [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/) retourneert [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) `null`, niet een lege string. Behandel deze types afzonderlijk: het eerste heeft geen markering, terwijl het tweede vereist dat de bullet‑afbeelding afzonderlijk wordt geëxtraheerd. Een afbeelding‑opsommingsteken kan niet alleen door het extraheren van een tekst‑markering worden gereproduceerd.

## **Veelgestelde vragen**

**Kunnen opsommingstekens en genummerde lijsten worden geëxporteerd naar PDF of afbeeldingen?**

Ja. Aspose.Slides behoudt de lijstopmaak wanneer het doelformaat de bijbehorende tekstopmaak en opsommingsteken‑functies ondersteunt.

**Kan ik lijsten bewerken in bestaande presentaties?**

Ja. Laad de presentatie, krijg toegang tot de betreffende alinea, inspecteer of werk de [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--) instellingen bij, en sla de presentatie op.

**Kunnen lijsten niet‑latijnse tekst bevatten?**

Ja. De tekst van een lijstitem kan Unicode‑tekens bevatten, zodat u lijsten kunt maken in meertalige presentaties. Zorg ervoor dat de in de presentatie gebruikte lettertypen de benodigde tekens ondersteunen.