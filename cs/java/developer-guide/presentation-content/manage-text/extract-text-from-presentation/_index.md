---
title: Pokročilá extrakce textu z prezentací v Javě
linktitle: Extrahovat text
type: docs
weight: 90
url: /cs/java/extract-text-from-presentation/
keywords:
- extrahovat text
- extrahovat text ze snímku
- extrahovat text z prezentace
- extrahovat text z PowerPointu
- extrahovat text z OpenDocument
- extrahovat text z PPT
- extrahovat text z PPTX
- extrahovat text z ODP
- získat text
- získat text ze snímku
- získat text z prezentace
- získat text z PowerPointu
- získat text z OpenDocument
- získat text z PPT
- získat text z PPTX
- získat text z ODP
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Rychle extrahujte text z PowerPoint a OpenDocument prezentací pomocí Aspose.Slides pro Java. Postupujte podle našeho jednoduchého, krok za krokem průvodce a ušetřete čas."
---
## **Přehled**

Extrahování textu z prezentací je běžný, ale zároveň zásadní úkol pro vývojáře pracující s obsahem snímků. Ať už pracujete se soubory Microsoft PowerPoint ve formátu PPT nebo PPTX, nebo s prezentacemi OpenDocument (ODP), přístup k textovým datům a jejich získání může být klíčové pro analýzu, automatizaci, indexování nebo migraci obsahu.

Tento článek poskytuje komplexní návod, jak efektivně extrahovat text z různých formátů prezentací, včetně PPT, PPTX a ODP, pomocí Aspose.Slides for Java. Naučíte se systematicky procházet prvky prezentace a přesně získat požadovaný textový obsah.

## **Extrahování textu ze snímku**

Aspose.Slides for Java poskytuje třídu [SlideUtil](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideutil/). Tato třída nabízí několik přetížených statických metod pro extrahování veškerého textu z prezentace nebo snímku. Pro extrahování textu ze snímku v prezentaci použijte metodu [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) . Tato metoda přijímá jako parametr objekt typu [IBaseSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseslide/). Po spuštění metoda prohledá celý snímek a vrátí pole objektů typu [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/), přičemž zachová veškeré formátování textu.

Následující úryvek kódu extrahuje celý text z prvního snímku prezentace:

```java
int slideIndex = 0;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(slideIndex);

    ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Extrahování textu z celé prezentace**

Pro skenování textu v celé prezentaci použijte statickou metodu [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) třídy [SlideUtil](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideutil/). Přijímá dva parametry:

1. První je objekt typu [IPresentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/), který představuje prezentaci PowerPoint nebo OpenDocument, ze které bude text extrahován.
1. Druhý je hodnota typu `boolean`, která určuje, zda mají být při skenování textu zahrnuty i hlavní (master) snímky.

Metoda vrací pole objektů typu [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/), včetně informací o formátování textu. Níže uvedený kód skenuje text a podrobnosti o formátování z celé prezentace, včetně hlavních snímků.

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    boolean includeMasterSlides = true;
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Kategorizovaná a rychlá extrakce textu**

Třída [PresentationFactory](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationfactory/) také poskytuje metody pro extrahování veškerého textu z prezentací:

```java
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

Argument výčtu [TextExtractionArrangingMode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textextractionarrangingmode/) určuje režim uspořádání výsledku extrakce textu a může nabývat následujících hodnot:

- `Unarranged` – surový text bez ohledu na jeho pozici na snímku.
- `Arranged` – text je uspořádán ve stejném pořadí jako na snímku.

Režim `Unarranged` lze použít, když je rychlost kritická; je rychlejší než režim `Arranged`.

[IPresentationText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationtext/) představuje surový text extrahovaný z prezentace. Jeho metoda `getSlidesText` vrací pole objektů typu [ISlideText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidetext/). Každý objekt představuje text na příslušném snímku. Objekt typu [ISlideText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidetext/) má následující metody:

- `getText` – Text ve tvarech snímku.
- `getMasterText` – Text ve tvarech hlavního (master) snímku přiřazeného k tomuto snímku.
- `getLayoutText` – Text ve tvarech rozložení (layout) snímku přiřazeného k tomuto snímku.
- `getNotesText` – Text ve tvarech poznámkového snímku přiřazeného k tomuto snímku.
- `getCommentsText` – Text v komentářích přiřazených k tomuto snímku.

```java
String presentationPath = "presentation.ppt";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **Často kladené otázky**

**Jak rychle Aspose.Slides zpracovává velké prezentace při extrakci textu?**

Aspose.Slides je optimalizováno pro vysoký výkon a dokáže zpracovat i [velké prezentace](/slides/cs/java/open-presentation/), což ho činí vhodným pro scénáře v reálném čase nebo hromadného zpracování.

**Umí Aspose.Slides extrahovat text z tabulek a grafů v prezentacích?**

Ano. Aspose.Slides dokáže extrahovat text z mnoha prvků snímku, včetně tabulek a objektů souvisejících s grafy, takže můžete přistupovat k textovému obsahu a analyzovat jej v běžných strukturách prezentací.

**Potřebuji speciální licenci Aspose.Slides pro extrakci textu z prezentací?**

Text můžete extrahovat pomocí bezplatné zkušební verze Aspose.Slides, i když bude mít [určité omezení](/slides/cs/java/licensing/), například zpracování jen omezeného počtu snímků. Pro neomezené používání a práci s většími prezentacemi se doporučuje zakoupit plnou licenci.