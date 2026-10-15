---
title: Spravovat odstavce textu PowerPointu v Javě
linktitle: Spravovat odstavec
type: docs
weight: 40
url: /cs/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- přidat text
- přidat odstavec
- spravovat text
- spravovat odstavec
- spravovat odrážku
- odsazení odstavce
- závěsné odsazení
- odrážka odstavce
- číslovaný seznam
- odrážkový seznam
- vlastnosti odstavce
- importovat HTML
- text do HTML
- odstavec do HTML
- odstavec do obrázku
- text do obrázku
- exportovat odstavec
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se vytvářet a formátovat odstavce, části, odrážky, číslované seznamy, odsazení, HTML obsah a obrázky odstavců pomocí Aspose.Slides pro Javu."
---
## **Přehled**

Aspose.Slides pro Java představuje text jako hierarchii textových rámců, odstavců a částí:

* [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) představuje kontejner textu ve tvaru a poskytuje přístup k jeho kolekci odstavců.
* [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) představuje jeden odstavec v textovém rámci a poskytuje přístup k jeho částem a formátování na úrovni odstavce.
* [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) představuje běh textu v rámci odstavce. Každá část může mít vlastní text a formátování na úrovni znaků.

Odstavec tak může obsahovat text s různými písmy, barvami, velikostmi a dalším formátováním pomocí více částí.

## **Vytváření a formátování odstavců**

Vytvářejte odstavce v textovém rámci tvaru a použijte části k formátování jednotlivých běhů textu. Tato sekce ukazuje, jak kombinovat více částí v každém odstavci a použít různé barvy, velikosti písma a styly.

### **Vytvořit odstavce s více částmi**

Následující Java příklad vytváří tři odstavce, z nichž každý obsahuje tři běhy textu ve sbírce vrácené metodou [IParagraph.getPortions](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getPortions--) . Znovu používá výchozí odstavec a jeho prázdnou část, poté přidává zbývající odstavce a části. Formátování se aplikuje pomocí [IPortion.getPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getPortionFormat--): první část v každém odstavci je červená, tučná a 15 bodů; druhá je modrá, kurzíva a 18 bodů. Třetí část si zachovává výchozí formátování:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vytváření odrážkových a číslovaných seznamů**

Uspořádejte text odstavců do seznamů se symboly, čísly nebo vlastními obrázky. Příklady v této sekci pokrývají formátování odrážek, vícestupňové seznamy a vlastní počáteční čísla.

### **Vytvořit odrážkový nebo číslovaný seznam**

Odrážky a číslování usnadňují skenování souvisejících položek. V Aspose.Slides jsou nastavení seznamu definována přes [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/).

Tento Java příklad přidává do stejného textového rámce symbolickou odrážku a číslovanou položku. [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) vybírá typ odrážky, zatímco [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) dodává symbol a [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) vybírá styl číslování. Obě položky používají černé odrážky s výškou 100 % a odsazením odstavce 25 bodů:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Použít obrázkové odrážky**

Obrázkové odrážky vám umožní použít vlastní obrázek místo symbolu nebo čísla.

Tento Java příklad přidává obrázek do kolekce obrázků prezentace jako [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) a používá jej jako odrážku odstavce. Volá [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) pro použití obrázkové odrážky a přiřazuje obrázek přes [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--). [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) je nastaveno na 100 % pro velikost odrážky relativně k textu odstavce:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Vytvořit vícestupňový seznam**

Nastavte [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) pro umístění odstavců na různé úrovně seznamu. Nejvyšší úroveň má hloubku `0`.

Tento Java příklad přiřazuje hodnoty [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) od 0 do 3 čtyřem odstavcům, čímž vytváří hierarchii v jediném textovém rámci. Každý odstavec používá symbolickou odrážku, přičemž [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) střídavě používá kulatou odrážku a pomlčku pro rozlišení sousedních úrovní:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Zahájit číslované položky seznamu vlastními hodnotami**

Použijte [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) pro nastavení počátečního čísla zobrazeného u číslovaného odstavce.

Tento Java příklad nastavuje [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) pro číslování tří odstavců a přiřazuje hodnoty [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 2, 3 a 7. Počáteční hodnota je konfigurována samostatně pro každý odstavec, což umožňuje přeskočit hodnoty:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Řízení rozvržení odstavce a koncových vlastností**

Upravte okraje a odsazení odstavců pro kontrolu polohy první řádky a řádků zabalujících se. Můžete také formátovat koncový znak odstavce odděleně od viditelných textových částí.

### **Nastavit odsazení první řádky**

Použijte metodu [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) ke kontrole odsazení první řádky odstavce. Toto nastavení posouvá pouze první řádku relativně k levému okraji odstavce. Kladná hodnota posouvá první řádku doprava, zatímco zbývající řádky zůstávají zarovnané k tělu odstavce.

Použijte [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) když potřebujete posunout celý odstavec. Použijte [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) když chcete posunout jen první řádku.

Následující příklad přiřazuje třem odstavcům stejný [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 20 bodů a [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) hodnoty 0, 20 a 40 bodů. První řádky začínají postupně většími posuny, zatímco zalomené řádky si zachovávají stejný levý okraj:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Odsazení první řádky odstavců](first_line_indent.png)

### **Nastavit závěsné odsazení**

Závěsné odsazení je rozvržení odstavce, kdy první řádka začíná vlevo od zbývajících řádků. V Aspose.Slides vytvoříte tento efekt pomocí vlastnosti [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Nastavte `Indent` na zápornou hodnotu pro posunutí první řádky doleva relativně k tělu odstavce.

V praxi [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) určuje levou pozici těla odstavce a [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) určuje pozici první řádky relativně k tomuto okraji. Pro vytvoření závěsného odsazení nastavte kladnou hodnotu `MarginLeft` a zápornou hodnotu `Indent`.

Toto formátování je užitečné pro bibliografie, odkazy, položky glosáře a další odstavce, kde musí zarovnávat zalomené řádky pod tělo odstavce, nikoli pod první znak první řádky.

Následující Java příklad spojuje hodnoty [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 40 a 60 bodů s hodnotami [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) –20 a –30 bodů. V každém odstavci první řádka začíná vlevo od zalomených řádků; druhý odstavec má hlubší závěsné odsazení:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Závěsné odsazení odstavců](hanging_indent.png)

### **Nastavit vlastnosti koncového běhu odstavce**

Metoda [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) řídí formátování koncového znaku odstavce. Následující příklad vytváří [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) s [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) nastaveným na 48 bodů a [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) nastaveným na Times New Roman. Tento formát přiřadí druhému odstavci k jeho koncovému znaku, přičemž viditelné textové části zůstávají nezměněny:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Počítání vykreslených řádků**

Pro pravidla odstavců, která ovlivňují automatické zalamování a interpunkci na koncích řádků, viz [Řízení zalomení řádků](/slides/cs/java/text-formatting/#control-line-breaking) a [Řízení závěsné interpunkce](/slides/cs/java/text-formatting/#control-hanging-punctuation).

Použijte [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) pro spočítání řádků obsazených odstavcem po rozvržení textu, včetně automatického zalamování. To je užitečné při kontrole délky textu a rozvržení v šablonách prezentací.

Odstavec je jednou položkou v [ITextFrame.getParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParagraphs--), a může zabírat několik vykreslených řádků. Výslovný zalomení řádku uvnitř odstavce vynutí nový řádek, aniž by vytvořilo nový odstavec. Automatické zalamování vytváří řádky na základě dostupné šířky, aniž by vkládalo výslovné znaky konce řádku do textu. Počítání odstavců nebo znaků konců řádků proto nedává počet vykreslených řádků.

Následující příklad vytváří textový tvar, počítá jeho řádky, zužuje tvar a pak nahrazuje text kratším řetězcem. Příklad povoluje zalamování pomocí [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) a vypíná automatické přizpůsobení pomocí [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-), takže šířka tvaru kontroluje zalamování bez automatického zmenšování textu nebo změny velikosti tvaru. Každé měření používá [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--). Rozměry tvaru jsou v bodech. Nakonec příklad přidá další odstavec a sečte počet řádků napříč textovým rámcem.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

S tímto textem a těmito rozměry zužování tvaru zvyšuje počet řádků, zatímco nahrazení textu krátkým řetězcem ho snižuje. Přesné počty se mohou lišit podle dostupnosti písma a substituce, velikosti písma, okrajů, odsazení, zalamování a nastavení automatického přizpůsobení. Použijte písma a nastavení rozvržení určená pro cílové prostředí při kontrole šablony.

Samotný počet řádků neurčuje, zda text přesahuje svůj kontejner. Důležitá je také dostupná výška, výšky řádků, mezery mezi odstavci a řádky a chování automatického přizpůsobení; i jediný řádek může překročit dostupnou šířku, pokud je zalamování vypnuté.

## **Import a export obsahu odstavců**

Použijte HTML pro vložení textu do prezentace nebo exportujte existující odstavce pro použití mimo ni. Tato sekce také ukazuje, jak vykreslit jednotlivé odstavce jako obrázky, včetně odstavců v buňkách tabulek.

### **Importovat HTML text do odstavců**

Použijte [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) pro převod HTML značek na odstavce a části v textovém rámci.

Tento Java příklad čte HTML ze souboru a předává značky metodě [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-). Vyčistí výchozí odstavec textového rámce, takže rámec obsahuje jen importovaný obsah. Obdélníkový tvar ponechává na každé straně snímku okraj 10 bodů:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Exportovat text odstavce do HTML**

Použijte [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) pro export vybraného rozsahu odstavců jako HTML. Při opětovném použití textu prezentace na webových stránkách možná budete chtít zachovat místní zvýraznění, aniž byste přenesli písmo, velikost nebo styly textového pole prezentace. Nastavte [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) pro řízení, jak daleko exportér následuje dědění formátování.

Stáhněte [vzorek prezentace](text-inheritance.pptx) a umístěte jej do pracovního adresáře aplikace. Jeho první snímek obsahuje jeden textový tvar s textem "Inherited text; explicit red 18pt". Vstup vědomě používá několik úrovní formátování:

- Výchozí styl textu prezentace poskytuje písmo Calibri a velikost 28 pt.
- Styl textu první úrovně textového rámce poskytuje modrý text a kurzívu.
- Odstavec explicitně nastavuje tučný text.
- Druhá část, "explicit red 18pt", explicitně nastavuje červený text a velikost 18 pt.

Následující kompletní příklad exportuje stejné odstavce třikrát. Předává [TextToHtmlConversionOptions](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/) metodě exportu a zapisuje každý výsledek jako samostatný UTF‑8 HTML soubor:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("text-inheritance.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            
            int[] modes = { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };
            String[] fileNames = { "All.html", "TextBox.html", "ParagraphOnly.html" };

            for (int i = 0; i < modes.length; i++) {
                TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                String html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                byte[] htmlBytes = html.getBytes(StandardCharsets.UTF_8);
                try {
                    Files.write(Paths.get(fileNames[i]), htmlBytes);
                } catch (IOException exception) {
                    System.out.println("The HTML file could not be written: " + exception.getMessage());
                }
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Vygenerované HTML obsahuje následující CSS pro první část, "Inherited text; ". Tabulka uvádí relevantní deklarace; ostatní vygenerované vlastnosti jsou vynechány pro přehlednost.

| Výstup | Relevantní CSS pro první část | Vzhled |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Modrý, tučný, kurzíva text o velikosti 28 pt v Calibri, pokud je toto písmo k dispozici. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Modrý, tučný, kurzíva text; okolní stránka nebo prohlížeč poskytuje rodinu písma a velikost. |
| `ParagraphOnly.html` | `font-weight:bold` | Tučný text; okolní stránka nebo prohlížeč poskytuje rodinu písma, velikost, barvu a kurzívu. |

Druhá část zachovává `color:#ff0000`, `font-size:18pt` a `font-weight:bold` ve všech třech výstupech. Také zachovává kurzívu v `All` a `TextBox`, ale ne v `ParagraphOnly`. Omezení dědění tedy neodstraňuje formátování explicitně přiřazené odstavci nebo části.

Otevřete soubory ve stejném prohlížeči pro jejich porovnání. Ve dvou omezených režimech jsou vynechané CSS vlastnosti řešeny styly cílové stránky nebo výchozími hodnotami prohlížeče, takže výsledný vzhled závisí na tom, kde je HTML použito.

### **Vykreslit odstavec jako obrázek**

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) vykresluje jednotlivý odstavec přímo a vrací [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/). Uložte výsledek do souboru nebo proudu pomocí [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-). Nemusíte vykreslovat celý tvar nebo ručně ořezávat bitmapu.

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) může vrátit `null`, pokud odstavec nelze najít v jeho nadřazené kolekci, nemá platné vykreslovací ohraničení nebo jej nelze vykreslit. Zkontrolujte výsledek před uložením a po použití uvolněte vrácený obrázek.

#### **Vykreslit odstavec v výchozím měřítku**

Příklad používá prezentaci s jedním snímkem, jehož první tvar je textové pole obsahující tři odstavce.

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

Následující příklad vybírá druhý odstavec s indexem 1 a volá [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) bez parametrů měřítka. Ověřuje, že tvar obsahuje požadovaný odstavec a že vykreslení vrací obrázek, předtím než zavolá [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) pro uložení ve formátu PNG. Blok `finally` uvolní obrázek po použití.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Výsledek:

![Obrázek odstavce](paragraph_to_image_output.png)

#### **Vykreslit odstavec v buňce tabulky se škálováním**

Použijte přetížení [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage-float-float-) přijímající parametry `float scaleX` a `float scaleY` pro nastavení horizontálního a vertikálního měřítka. Následující příklad vytvoří tabulku, vykreslí odstavec v její první buňce dvojnásobně v šířce i výšce oproti výchozímu a uloží výsledek jako PNG obrázek.

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Faktor měřítka `1` zachová danou osu v její výchozí velikosti pixelů. Například `2` pro oba faktory vytvoří obrázek, jehož šířka a výška jsou přibližně dvojnásobné výchozích rozměrů, což vede ke čtyřnásobku pixelů. Větší faktory obecně poskytují ostřejší text pro zvětšení nebo výstup ve vysokém rozlišení, ale také zvyšují spotřebu paměti a velikost souboru. Faktory pod `1` produkují menší obrázky s méně podrobným obsahem. Použijte stejné faktory k zachování poměru stran odstavce; různé horizontální a vertikální faktory roztačí výstup nezávisle.

Vykreslování celého tvaru pomocí [IShape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getImage--) zůstává užitečné, když výstup musí zahrnovat výplň, okraj nebo jiný vizuální kontext tvaru. Pro obrázek pouze odstavce použijte [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--).

## **Často kladené otázky**

**Mohu zcela zakázat zalamování řádků uvnitř textového rámce?**

Ano. Nastavte [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) pro vypnutí zalamování, aby řádky neprováděly přerušení na okrajích textového rámce.

**Jak mohu získat přesné ohraničení konkrétního odstavce na snímku?**

Použijte [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getRect--) k získání ohraničujícího obdélníku odstavce. [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getRect--) poskytuje ohraničení jednotlivé části.

**Kde se řídí zarovnání odstavce (vlevo, vpravo, na střed nebo do bloku)?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) je nastavení na úrovni odstavce a platí pro celý odstavec bez ohledu na formátování jednotlivých částí.

Pro vertikální zarovnání částí s různými velikostmi písma v rámci každého řádku viz [Zarovnat písma v řádku](/slides/cs/java/text-formatting/#align-fonts-within-a-line).

**Mohu nastavit jazyk kontroly pravopisu pro část odstavce?**

Ano. Nastavte [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) pro jednotlivé části, aby jeden odstavec mohl obsahovat text v několika jazycích.