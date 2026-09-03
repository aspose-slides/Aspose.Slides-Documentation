---
title: Správa textových polí v prezentacích pomocí Javy
linktitle: Správa textového pole
type: docs
weight: 20
url: /cs/java/manage-textbox/
keywords:
- textové pole
- textový rámec
- přidat text
- aktualizovat text
- vytvořit textové pole
- zkontrolovat textové pole
- přidat textový sloupec
- přidat hypertextový odkaz
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Vytvořte, identifikujte, formátujte a aktualizujte textová pole v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Java."
---
## **Úvod**

V Aspose.Slides pro Java je text snímků ukládán v textových rámcích, které patří k objektům. Rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) představuje nejběžnější objekt nosící text a zpřístupňuje jeho text prostřednictvím metody [IAutoShape.getTextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/#getTextFrame--).

{{% alert color="info" title="Note" %}}
Každý automatický tvar implementuje [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/), ale ne každý tvar je automatický tvar nebo podporuje textový rámec. Při zpracovávání existující prezentace zkontrolujte, že tvar implementuje [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) před přístupem k jeho textu.
{{% /alert %}}

## **Vytvoření textového pole na snímku**

Pro vytvoření textového pole přidejte automatický tvar na snímek, přidejte text do jeho textového rámce a uložte prezentaci. Následující příklad vytvoří obdélníkové textové pole:

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

Souřadnice a rozměry předávané metodě [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) jsou měřeny v bodech. Metoda [IAutoShape.addTextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) inicializuje textový rámec s poskytnutým textem.

## **Kontrola, zda je tvar textovým polem**

Použijte metodu [IAutoShape.isTextBox](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/#isTextBox--) k určení, zda je automatický tvar považován za textové pole. To je užitečné, když prezentace obsahuje jak textové, tak čistě grafické automatické tvary.

![A text box and a shape](istextbox.png)

Následující příklad prověří každý automatický tvar v prezentaci:

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

Nově přidaný automatický tvar není považován za textové pole, dokud neobsahuje neprázdný text. Tento text můžete poskytnout pomocí [IAutoShape.addTextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) nebo [ITextFrame.setText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#setText-java.lang.String-). Přidání nebo přiřazení prázdného řetězce způsobí, že [IAutoShape.isTextBox](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/#isTextBox--) vrátí `false`:

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

První dva volání vytisknou `true`; poslední dvě vytisknou `false`.

## **Nalezení tvaru, který vlastní textový rámec**

Obecný kód pro zpracování textu může získat objekt [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) aniž by věděl, který objekt prezentace jej obsahuje. Použijte jen pro čtení metodu [ITextFrame.getParentShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#getParentShape--) k navigaci zpět k jeho vlastnímu [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/).

U textového rámce vlastněného automatickým tvarem nebo jiným tvarem nesoucím text vrací [ITextFrame.getParentShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#getParentShape--) vlastníka a [ITextFrame.getParentCell](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#getParentCell--) vrací `null`. Před přístupem zkontrolujte vrácenou hodnotu. Pro identifikaci jak tvarů, tak vlastníků buněk tabulky, včetně tvarů spojených s uzly SmartArt, viz [Search and Replace Text](/slides/cs/java/search-and-replace-text/).

## **Přidání sloupců do textového pole**

Metoda [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/#setColumnCount-int-) dělí textový rámec do sloupců, zatímco [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) nastavuje mezeru mezi sloupci v bodech. Oba nastavení patří k [ITextFrameFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/) a lze je změnit prostřednictvím textového rámce existujícího textového pole. Text se přetéká mezi sloupci uvnitř stejného tvaru; nepřechází do jiného tvaru.

V následujícím příkladu je vytvořeno třísloupcové textové pole s 10 body mezi sloupci, prezentace se uloží a uložená nastavení se načtou z výstupního souboru:

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

## **Extrahování textu z jednotlivých sloupců**

Použijte [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#splitTextByColumns--) k získání textu přiřazeného každému vizuálnímu sloupci v existujícím textovém rámci. Metoda vrací jeden řetězec pro každý sloupec v pořadí čtení podle sloupců. Jednosloupcový textový rámec produkuje pole s jedním prvkem a prázdný sloupec je reprezentován prázdným řetězcem. Řetězce obsahují pouze prostý text; formátování na úrovni částí není zachováno.

Toto je užitečné, když potřebujete:
- Extrahovat text při zachování jeho sloupcového pořadí čtení.
- Indexovat nebo porovnávat obsah snímků s více sloupci.
- Exportovat každý sloupec do samostatného souboru, databázového pole nebo jiného cíle.
- Zkontrolovat, jak je text přerozdělen po změně počtu sloupců metodou [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/#setColumnCount-int-), mezery metodou [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), písma nebo velikosti textového rámce.

Metoda uvádí text rozdělený v aktuálním [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/); automaticky nepřetéká text mezi samostatnými tvary nebo textovými poli. Rozložení sloupců může záviset na dostupných fontech a dalších nastaveních rozvržení textu, takže se ujistěte, že požadované fonty jsou k dispozici, pokud jsou důležité konzistentní výsledky.

V následujícím příkladu se načte prezentace, najde první více‑sloupcový automatický tvar s textovým rámcem, přečte jeho nastavený počet sloupců a zapíše text z každého sloupce do samostatného souboru. Tvary, které neposkytují textový rámec, jsou přeskočeny.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
            Path outputPath = Paths.get("Column-" + columnNumber + ".txt");
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try {
                Files.write(outputPath, textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Aktualizace textu**

Pro aktualizaci textu v celé prezentaci projděte snímky a tvary, vyberte automatické tvary a poté upravte jejich textové části. Práce na úrovni částí vám umožní měnit jak text, tak formátování znaků.

Následující příklad nahradí každé výskyt `years` za `months` v textu automatických tvarů a zvýrazní každou dotčenou část tučným písmem:

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

Tento průchod aktualizuje text pouze v automatických tvarech. Text uložený v tabulkách, grafech, SmartArt nebo seskupených tvarech vyžaduje procházení jejich vlastních kolekcí.

## **Přidání textového pole s hyperlinkem**

Hyperlink lze přiřadit konkrétní textové části, takže pouze tento text funguje jako klikací odkaz. Použijte [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) pro asociaci části s externím URL.

Následující příklad vytvoří propojený text a uloží jej do prezentace:

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

## **Často kladené otázky**

**Jaký je rozdíl mezi textovým polem a textovým zástupcem na hlavním nebo rozvrhovém snímku?**

Zástupce ([placeholder](/slides/cs/java/manage-placeholder/)) může zdědit svou pozici a formátování z [hlavního snímku](https://reference.aspose.com/slides/cs/java/com.aspose.slides/masterslide/) nebo [rozvrhového snímku](https://reference.aspose.com/slides/cs/java/com.aspose.slides/layoutslide/). Běžné textové pole je nezávislý tvar na snímku, kde bylo vytvořeno, a nezíská chování zástupce, když se rozvržení změní.

**Jak mohu nahradit text, aniž bych změnil text v grafech, tabulkách nebo SmartArt?**

Omezte procházení na tvary, které implementují [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/), jak je ukázáno v příkladu Aktualizace textu. Grafy, tabulky a SmartArt ukládají text ve svých vlastních modelových objektech, takže nejsou tímto cyklem upraveny.