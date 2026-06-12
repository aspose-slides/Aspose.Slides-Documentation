---
title: Pokročilá extrakce textu z prezentací v PHP
linktitle: Extrahovat text
type: docs
weight: 90
url: /cs/php-java/extract-text-from-presentation/
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
- PHP
- Aspose.Slides
description: "Rychle extrahujte text z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides for PHP via Java. Postupujte podle našeho jednoduchého, krok za krokem průvodce a ušetřete čas."
---
## **Přehled**

Extrahování textu z prezentací je běžný, ale zásadní úkol pro vývojáře pracující s obsahem snímků. Ať už pracujete se soubory Microsoft PowerPoint ve formátu PPT nebo PPTX, nebo s prezentacemi OpenDocument (ODP), přístup k textovým datům může být klíčový pro analýzu, automatizaci, indexaci nebo migraci obsahu.

Tento článek poskytuje komplexní průvodce, jak efektivně extrahovat text z různých formátů prezentací, včetně PPT, PPTX a ODP, pomocí Aspose.Slides for PHP via Java. Naučíte se systematicky procházet prvky prezentace a přesně získat požadovaný textový obsah.

## **Extrahovat text ze snímku**

Aspose.Slides for PHP via Java poskytuje třídu [SlideUtil](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideutil/). Tato třída poskytuje několik přetížených statických metod pro získání veškerého textu z prezentace nebo snímku. Pro získání textu ze snímku v prezentaci použijte metodu [getAllTextBoxes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideutil/#getAllTextBoxes). Tato metoda přijímá objekt typu [BaseSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslide/) jako parametr. Po spuštění metoda prohledá celý snímek a vrátí pole objektů typu [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/), přičemž zachová veškeré formátování textu.

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Extrahovat text z prezentace**

Pro prohledání textu v celé prezentaci použijte statickou metodu [getAllTextFrames](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideutil/#getAllTextFrames) třídy [SlideUtil](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideutil/). Přijímá dva parametry:

1. Prvním je objekt [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) představující PowerPoint nebo OpenDocument prezentaci, ze které bude text extrahován.
1. Druhým je hodnota typu `boolean`, která udává, zda mají být při skenování textu zahrnuty i hlavní snímky (master slides).

Metoda vrací pole objektů typu [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/), včetně informací o formátování textu. Níže uvedený kód prohledá text a podrobnosti o formátování v prezentaci, včetně hlavních snímků.

```php
$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $includeMasterSlides = true;
    $textFrames = SlideUtil::getAllTextFrames($presentation, $includeMasterSlides);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Kategorizovaná a rychlá extrakce textu**

Třída [PresentationFactory](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/) také poskytuje metody pro extrakci veškerého textu z prezentací:

```php
PresentationText getPresentationText(String, int);
PresentationText getPresentationText(InputStream, int);
PresentationText getPresentationText(InputStream, int, LoadOptions);
```

Argument výčtu [TextExtractionArrangingMode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textextractionarrangingmode/) určuje režim organizace výsledku extrakce textu a může být nastaven na následující hodnoty:
- `Unarranged` – surový text bez ohledu na jeho umístění na snímku.
- `Arranged` – text je uspořádán ve stejném pořadí jako na snímku.

Režim `Unarranged` lze použít, když je rychlost kritická; je rychlejší než režim `Arranged`.

[Třída PresentationText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationtext/) představuje surový text extrahovaný z prezentace. Její metoda `getSlidesText` vrací pole objektů, kde každý objekt představuje text na odpovídajícím snímku. Každý vrácený objekt má následující metody:

- `getText` – Text uvnitř tvarů snímku.
- `getMasterText` – Text uvnitř tvarů hlavního snímku (master slide) spojeného s tímto snímkem.
- `getLayoutText` – Text uvnitř tvarů rozložení (layout slide) spojeného s tímto snímkem.
- `getNotesText` – Text uvnitř tvarů poznámkového snímku (notes slide) spojeného s tímto snímkem.
- `getCommentsText` – Text uvnitř komentářů spojených s tímto snímkem.

```php
$presentationPath = "presentation.ppt";
$arrangingMode = TextExtractionArrangingMode::Unarranged;
$presentationText = PresentationFactory::getInstance()->getPresentationText($presentationPath, $arrangingMode);
$slidesText = $presentationText->getSlidesText();
$firstSlideText = $slidesText[0];

echo($firstSlideText->getText());
echo($firstSlideText->getLayoutText());
echo($firstSlideText->getMasterText());
echo($firstSlideText->getNotesText());
echo($firstSlideText->getCommentsText());
```

## **FAQ**

**Jak rychle Aspose.Slides zpracovává velké prezentace při extrakci textu?**

Aspose.Slides je optimalizováno pro vysoký výkon a dokáže zpracovat i [velké prezentace](/slides/cs/php-java/open-presentation/), což ho činí vhodným pro scénáře v reálném čase nebo hromadného zpracování.

**Může Aspose.Slides extrahovat text z tabulek a grafů v prezentacích?**

Ano. Aspose.Slides může extrahovat text z mnoha prvků snímků, včetně tabulek a objektů souvisejících s grafy, takže můžete přistupovat k textovému obsahu v běžných strukturách prezentací.

**Potřebuji speciální licenci Aspose.Slides k extrakci textu z prezentací?**

Text můžete extrahovat pomocí bezplatné zkušební verze Aspose.Slides, i když bude mít [určité omezení](/slides/cs/php-java/licensing/), například zpracování omezeného počtu snímků. Pro neomezené použití a práci s většími prezentacemi se doporučuje zakoupit plnou licenci.