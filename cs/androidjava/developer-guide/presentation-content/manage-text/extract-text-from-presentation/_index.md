---
title: Pokročilá extrakce textu z prezentací na Androidu
linktitle: Extrahovat text
type: docs
weight: 90
url: /cs/androidjava/extract-text-from-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Rychle extrahujte text z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Android prostřednictvím Javy. Postupujte podle našeho jednoduchého, krok za krokem průvodce a ušetřete čas."
---
## **Přehled**

Extrahování textu z prezentací je běžný, ale zásadní úkol pro vývojáře pracující s obsahem snímků. Ať už pracujete se soubory Microsoft PowerPoint ve formátu PPT nebo PPTX, nebo s prezentacemi OpenDocument (ODP), přístup k textovým údajům a jejich získání může být klíčové pro analýzu, automatizaci, indexování či migraci obsahu.

V tomto článku najdete komplexní průvodce, jak efektivně extrahovat text z různých formátů prezentací, včetně PPT, PPTX a ODP, pomocí Aspose.Slides pro Android prostřednictvím Javy. Naučíte se systematicky procházet prvky prezentace a přesně získat požadovaný textový obsah.

## **Extrahování textu ze snímku**

Aspose.Slides pro Android prostřednictvím Javy poskytuje třídu [SlideUtil](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideutil/). Tato třída nabízí několik přetížených statických metod pro extrahování veškerého textu z prezentace nebo snímku. K extrahování textu ze snímku v prezentaci použijte metodu [getAllTextBoxes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-). Tato metoda přijímá jako parametr objekt typu [IBaseSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseslide/). Po spuštění prohledá celý snímek na text a vrátí pole objektů typu [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/), přičemž zachová veškeré formátování textu.

Následující úryvek kódu extrahuje veškerý text z prvního snímku prezentace:

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

## **Extrahování textu z prezentace**

Pro skenování textu z celé prezentace použijte statickou metodu [getAllTextFrames](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) vystavenou třídou [SlideUtil](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideutil/). Přijímá dva parametry:

1. Nejprve objekt [IPresentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/) představující PowerPoint nebo OpenDocument prezentaci, ze které bude text extrahován.
1. Dále hodnota typu `boolean` určující, zda mají být při skenování textu zahrnuty hlavní snímky (master slides).

Metoda vrací pole objektů typu [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/), včetně informací o formátování textu. Níže uvedený kód skenuje text a podrobnosti o formátování z prezentace, včetně hlavních snímků.

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

Třída [PresentationFactory](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationfactory/) také poskytuje metody pro extrahování veškerého textu z prezentací:

```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

Argument výčtového typu [TextExtractionArrangingMode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textextractionarrangingmode/) udává režim uspořádání výsledku extrakce textu a může být nastaven na následující hodnoty:
- `Unarranged` – Neuspořádaný text bez ohledu na jeho umístění na snímku.
- `Arranged` – Text je uspořádán ve stejném pořadí jako na snímku.

Neuspořádaný režim lze použít, pokud je rychlost kritická; je rychlejší než uspořádaný režim.

[IPresentationText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationtext/) představuje surový text extrahovaný z prezentace. Jeho metoda `getSlidesText` vrací pole objektů typu [ISlideText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidetext/). Každý objekt představuje text na odpovídajícím snímku. Objekt typu [ISlideText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidetext/) má následující metody:

- `getText` – Text uvnitř tvarů snímku.
- `getMasterText` – Text uvnitř tvarů hlavního snímku (master slide) spojeného s tímto snímkem.
- `getLayoutText` – Text uvnitř tvarů rozložení snímku (layout slide) spojeného s tímto snímkem.
- `getNotesText` – Text uvnitř tvarů poznámkového snímku (notes slide) spojeného s tímto snímkem.
- `getCommentsText` – Text v komentářích spojených s tímto snímkem.

```java
String presentationPath = "presentation.pptx";
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

Aspose.Slides je optimalizováno pro vysoký výkon a dokáže zpracovat i [velké prezentace](/slides/cs/androidjava/open-presentation/), což ho činí vhodným pro scénáře zpracování v reálném čase nebo hromadně.

**Umí Aspose.Slides extrahovat text z tabulek a grafů v prezentacích?**

Ano. Aspose.Slides dokáže extrahovat text z mnoha prvků snímku, včetně tabulek a objektů souvisejících s grafy, takže můžete přistupovat k textovému obsahu a analyzovat jej v běžných strukturách prezentace.

**Potřebuji speciální licenci Aspose.Slides pro extrahování textu z prezentací?**

Text můžete extrahovat pomocí bezplatné zkušební verze Aspose.Slides, i když má [některá omezení](/slides/cs/androidjava/licensing/), například zpracování pouze omezeného počtu snímků. Pro neomezené používání a práci s většími prezentacemi se doporučuje zakoupit plnou licenci.