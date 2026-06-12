---
title: Pokročilé extrahování textu z prezentací v JavaScriptu
linktitle: Extrahovat text
type: docs
weight: 90
url: /cs/nodejs-java/extract-text-from-presentation/
keywords:
- extrahovat text
- extrahovat text ze snímku
- extrahovat text z prezentace
- extrahovat text z PowerPointu
- extrahovat text z OpenDocumentu
- extrahovat text z PPT
- extrahovat text z PPTX
- extrahovat text z ODP
- získat text
- získat text ze snímku
- získat text z prezentace
- získat text z PowerPointu
- získat text z OpenDocumentu
- získat text z PPT
- získat text z PPTX
- získat text z ODP
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Rychle extrahujte text z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js prostřednictvím Java. Postupujte podle našeho jednoduchého, krok za krokem průvodce a ušetřete čas."
---
## **Přehled**

Extrahování textu z prezentací je běžný, ale zásadní úkol pro vývojáře pracující se snímky. Ať už pracujete s soubory Microsoft PowerPoint ve formátu PPT nebo PPTX, nebo s prezentacemi OpenDocument (ODP), přístup a získávání textových dat může být klíčové pro analýzu, automatizaci, indexování nebo migraci obsahu.

Tento článek poskytuje ucelený návod, jak efektivně extrahovat text z různých formátů prezentací, včetně PPT, PPTX a ODP, pomocí Aspose.Slides pro Node.js prostřednictvím Java. Naučíte se, jak systematicky procházet prvky prezentace a přesně získat požadovaný textový obsah.

## **Extrahování textu ze snímku**

Aspose.Slides pro Node.js prostřednictvím Java poskytuje třídu [SlideUtil](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideutil/) . Tato třída nabízí několik přetížených statických metod pro extrahování veškerého textu z prezentace nebo snímku. Pro extrahování textu ze snímku v prezentaci použijte metodu [getAllTextBoxes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) . Tato metoda přijímá jako parametr objekt snímku. Po spuštění metoda prohledá celý snímek a vrátí pole objektů [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) , přičemž zachová veškeré formátování textu.

Následující ukázkový kód extrahuje celý text z prvního snímku v prezentaci:

```javascript
const slideIndex = 0;

const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(slideIndex);

    const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Extrahování textu z prezentace**

Pro prohledání textu v celé prezentaci použijte statickou metodu [getAllTextFrames](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) vystavenou třídou [SlideUtil](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideutil/) . Přijímá dva parametry:

1. První je objekt [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) , který představuje prezentaci PowerPoint nebo OpenDocument, ze které bude text extrahován.
1. Druhý je hodnota typu `boolean`, určující, zda mají být při skenování textu zahrnuty hlavní snímky.

Metoda vrací pole objektů [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) , včetně informací o formátování textu. Níže uvedený kód prohledá text a podrobnosti o formátování v prezentaci, včetně hlavních snímků.

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const includeMasterSlides = true;
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Kategorizované a rychlé extrahování textu**

Třída [PresentationFactory](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationfactory/) také poskytuje metody pro extrahování veškerého textu z prezentací:

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

Argument výčtu [TextExtractionArrangingMode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textextractionarrangingmode/) určuje režim uspořádání výsledku extrakce textu a může nabývat následujících hodnot:
- `Unarranged` – surový text bez ohledu na jeho umístění na snímku.
- `Arranged` – text je uspořádán ve stejném pořadí jako na snímku.

Režim Unarranged lze použít, když je rychlost klíčová; je rychlejší než režim Arranged.

[PresentationText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationtext/) představuje surový text extrahovaný z prezentace. Jeho metoda `getSlidesText` vrací pole objektů, z nichž každý představuje text na příslušném snímku. Každý objekt textu snímku má následující metody:

- Metoda `getText` vrací text uvnitř tvarů snímku.
- Metoda `getMasterText` vrací text uvnitř tvarů hlavního snímku přiřazeného k tomuto snímku.
- Metoda `getLayoutText` vrací text uvnitř tvarů rozložení snímku přiřazeného k tomuto snímku.
- Metoda `getNotesText` vrací text uvnitř tvarů poznámkového snímku přiřazeného k tomuto snímku.
- Metoda `getCommentsText` vrací text v komentářích přiřazených k tomuto snímku.

```javascript
const presentationPath = "presentation.ppt";
const arrangingMode = aspose.slides.TextExtractionArrangingMode.Unarranged;
const presentationText = aspose.slides.PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
const firstSlideText = presentationText.getSlidesText()[0];

console.log(firstSlideText.getText());
console.log(firstSlideText.getLayoutText());
console.log(firstSlideText.getMasterText());
console.log(firstSlideText.getNotesText());
console.log(firstSlideText.getCommentsText());
```

## **Často kladené otázky**

**Jak rychle Aspose.Slides zpracovává velké prezentace během extrakce textu?**

Aspose.Slides je optimalizován pro vysoký výkon a dokáže zpracovat i [velké prezentace](/slides/cs/nodejs-java/open-presentation/) , což ho činí vhodným pro scénáře zpracování v reálném čase nebo hromadně.

**Umí Aspose.Slides extrahovat text z tabulek a grafů v prezentacích?**

Ano. Aspose.Slides dokáže extrahovat text z mnoha prvků snímku, včetně tabulek a objektů souvisejících s grafy, takže můžete přistupovat k textovému obsahu a analyzovat jej v běžných strukturách prezentací.

**Potřebuji speciální licenci Aspose.Slides pro extrakci textu z prezentací?**

Text můžete extrahovat pomocí bezplatné zkušební verze Aspose.Slides, i když bude mít [některá omezení](/slides/cs/nodejs-java/licensing/) , například zpracování pouze omezeného počtu snímků. Pro neomezené použití a práci s většími prezentacemi se doporučuje zakoupení plné licence.