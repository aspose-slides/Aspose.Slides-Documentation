---
title: Správa odrážkových a číslovaných seznamů v prezentacích v Javě
linktitle: Spravovat seznamy
type: docs
weight: 60
url: /cs/java/manage-lists/
keywords:
- odrážka
- odrážkový seznam
- číslovaný seznam
- symbolová odrážka
- obrázková odrážka
- vlastní odrážka
- víceúrovňový seznam
- vytvořit odrážku
- přidat odrážku
- přidat seznam
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Naučte se, jak vytvářet a formátovat odrážkové, obrázkové, víceúrovňové a číslované seznamy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Java."
---
## **Přehled**

Aspose.Slides for Java umožňuje vytvářet a formátovat odrážkové a číslované seznamy v prezentacích PowerPoint a OpenDocument. Položka seznamu je odstavec, jehož nastavení odrážky je řízeno formátem odstavce.

Použijte metodu [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/#getParagraphFormat--) k přístupu k nastavením seznamu na úrovni odstavce. Hlavním vstupním bodem je [IParagraphFormat.getBullet](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#getBullet--), který vrací objekt [IBulletFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/). S tímto objektem můžete nastavit typ odrážky, symbol, obrázek, barvu, velikost, styl číslování a počáteční číslo.

Tento článek ukazuje, jak:

- vytvořit odrážkový seznam s vlastním symbolem
- vytvořit obrázkovou odrážku
- vytvořit víceúrovňový seznam nastavením hloubky odstavce
- vytvořit číslovaný seznam
- prohlédnout a změnit formátování seznamu v existující prezentaci

## **Vytvoření odrážkového seznamu**

Chcete‑li vytvořit odrážkový seznam, přidejte objekty [IParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/) do objektu [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) a nastavte [IBulletFormat.setType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setType-byte-) na [BulletType.Symbol](https://reference.aspose.com/slides/cs/java/com.aspose.slides/bullettype/#Symbol). Poté můžete nastavit [IBulletFormat.setChar](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#getColor--) a [IBulletFormat.setHeight](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setHeight-float-) pro ovládání vzhledu odrážky.

Následující kód v jazyce Java ukazuje, jak vytvořit odrážkový seznam na snímku:

```java
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

Výsledek:

![Symboly odrážek](symbol_bullets.png)

## **Vytvoření číslovaného seznamu**

Používejte číslované seznamy, když záleží na pořadí položek. Nastavte [IBulletFormat.setType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setType-byte-) na [BulletType.Numbered](https://reference.aspose.com/slides/cs/java/com.aspose.slides/bullettype/#Numbered). Můžete také zvolit formát číslování pomocí [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) nebo nastavit [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-), pokud má seznam začínat hodnotou jinou než 1.

Následující kód v jazyce Java ukazuje, jak vytvořit číslovaný seznam na snímku:

```java
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

Výsledek:

![Číslované odrážky](numbered_bullets.png)

## **Vytvoření obrázkové odrážky**

Aspose.Slides umožňuje nahradit běžný symbol odrážky obrázkem. Obrázkové odrážky fungují nejlépe u jednoduchých obrázků, které zůstávají čitelné i v malém měřítku, jako jsou ikony nebo malé průhledné soubory PNG.

{{% alert color="primary" %}}
Ideální je, pokud plánujete nahradit běžný symbol odrážky obrázkem, zvolit jednoduchou grafiku s průhledným pozadím. Takové obrázky fungují dobře jako vlastní symboly odrážek.

Mějte na paměti, že obrázek bude zmenšen na velmi malou velikost. Z tohoto důvodu důrazně doporučujeme vybrat obrázek, který zůstane jasný a vizuálně účinný, když se použije jako odrážka v seznamu.
{{% /alert %}}

Chcete‑li vytvořit obrázkovou odrážku, přidejte obrázek do [Presentation.getImages](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getImages--) a přiřaďte vrácený objekt obrázku metodě [IBulletFormat.getPicture](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#getPicture--). Nastavte [IBulletFormat.setType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setType-byte-) na [BulletType.Picture](https://reference.aspose.com/slides/cs/java/com.aspose.slides/bullettype/#Picture) před přiřazením obrázku.

Předpokládejme, že máme soubor „image.png“:

![Obrázek pro odrážky](picture_for_bullets.png)

Následující kód v jazyce Java ukazuje, jak vytvořit obrázkové odrážky na snímku:

```java
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

Výsledek:

![Obrázkové odrážky](picture_bullets.png)

## **Vytvoření víceúrovňového seznamu**

Použijte [IParagraphFormat.setDepth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setDepth-short-) k umístění položek seznamu na různé úrovně. Úroveň 0 je nejvyšší úroveň, úroveň 1 je pod ní a tak dále.

Následující kód v jazyce Java ukazuje, jak vytvořit víceúrovňový odrážkový seznam:

```java
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

Výsledek:

![Víceúrovňový seznam](multilevel_list.png)

## **Změna existujícího seznamu**

Chcete‑li změnit formátování seznamu v existující prezentaci, přistupte k cílovému odstavci a aktualizujte jeho nastavení [IParagraphFormat.getBullet](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#getBullet--). Stejné vlastnosti použité při vytváření seznamů lze použít k prohlížení nebo úpravě seznamů načtených ze souboru PPT, PPTX nebo ODP.

Následující kód v jazyce Java mění první odstavec v textovém rámci tak, aby používal styl číslovaného seznamu:

```java
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

## **Časté dotazy**

**Lze odrážkové a číslované seznamy exportovat do PDF nebo obrázků?**

Ano. Aspose.Slides zachovává formátování seznamu, pokud cílový formát podporuje odpovídající rozvržení textu a funkce odrážek.

**Mohu upravovat seznamy v existujících prezentacích?**

Ano. Načtěte prezentaci, přistupte k cílovému odstavci, prohlédněte nebo aktualizujte jeho nastavení [IParagraphFormat.getBullet](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#getBullet--), a uložte prezentaci.

**Mohou seznamy obsahovat nestandardní (ne‑latinské) texty?**

Ano. Text položky seznamu může obsahovat Unicode znaky, takže můžete vytvářet seznamy ve vícejazyčných prezentacích. Ujistěte se, že použité fonty v prezentaci podporují potřebné znaky.