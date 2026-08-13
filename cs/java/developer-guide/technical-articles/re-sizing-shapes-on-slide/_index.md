---
title: Změna velikosti tvarů na snímcích prezentace
type: docs
weight: 110
url: /cs/java/re-sizing-shapes-on-slide/
keywords:
- změna velikosti tvaru
- úprava velikosti tvaru
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Jednoduše změňte velikost tvarů na snímcích PowerPoint a OpenDocument pomocí Aspose.Slides pro Java—automatizujte úpravy rozložení snímků a zvýšte produktivitu."
---
## **Přehled**

Jednou z nejčastějších otázek zákazníků Aspose.Slides pro Java je, jak změnit velikost tvarů tak, aby se při změně velikosti snímku data neořízla. Tento stručný technický článek ukazuje, jak to provést.

## **Změna velikosti tvarů**

Aby se tvarům zabránilo v posunutí při změně velikosti snímku, aktualizujte pozici a rozměry každého tvaru tak, aby odpovídaly novému rozložení snímku.

```java
import com.aspose.slides.*;

// Načíst soubor prezentace.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Získat původní velikost snímku.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Změnit velikost snímku bez škálování existujících tvarů.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Získat novou velikost snímku.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Změnit velikost a přemístit tvary na každém snímku.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Škálovat velikost tvaru.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Škálovat pozici tvaru.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" %}} 
Tabulky nevyžadují žádné zvláštní zacházení: nastavení šířky a výšky tabulky přepočítá její sloupce a řádky úměrně, takže opětovné škálování výšek řádků a šířek sloupců by poměr použilo podruhé.
{{% /alert %}} 

Kód výše mění pouze tvary na snímcích. Hlavní snímky a rozložení snímků mají své vlastní tvary, proto je také přizpůsobte, pokud chcete, aby celá prezentace odpovídala nové velikosti snímku:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Získat původní velikost snímku.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Změnit velikost snímku bez škálování existujících tvarů.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Získat novou velikost snímku.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Škálovat velikost tvaru.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Škálovat pozici tvaru.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Škálovat velikost tvaru.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Škálovat pozici tvaru.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Škálovat velikost tvaru.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Škálovat pozici tvaru.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

### Proč jsou tvary po změně velikosti snímku deformované nebo oříznuté?

Při změně velikosti snímku tvary zachovají svou původní pozici a rozměry, pokud není měřítko výslovně změněno. To může způsobit oříznutí obsahu nebo posunutí tvarů.

### Funguje poskytnutý kód pro všechny typy tvarů?

Ano. Nastavení výšky a šířky funguje stejně pro textová pole, obrázky, grafy i tabulky.

### Jak změnit velikost tabulek při změně velikosti snímku?

Změňte velikost samotného tvaru tabulky, stejně jako u jakéhokoli jiného tvaru. Její řádky a sloupce se přizpůsobí úměrně, takže je po té znovu škálovat není třeba.

### Bude tato změna velikosti fungovat i pro hlavní snímky a rozložení snímků?

Ano, ale měli byste také projít [Masters](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getMasters--) a [Layout slides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getLayoutSlides--) a aplikovat stejnou logiku škálování na jejich tvary, aby byla zajištěna konzistence v celé prezentaci.

### Mohu při změně velikosti změnit orientaci snímku (na výšku/na šířku)?

Ano. Můžete použít [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidesize/#setOrientation-int-) k změně orientace. Ujistěte se, že logiku škálování nastavíte odpovídajícím způsobem, aby bylo rozložení zachováno.

### Existuje nějaký limit velikosti snímku, kterou mohu nastavit?

Aspose.Slides podporuje vlastní velikosti, avšak velmi velké rozměry mohou ovlivnit výkon nebo kompatibilitu s některými verzemi PowerPointu.

### Jak mohu zabránit deformaci tvarů s pevně nastaveným poměrem stran?

Můžete před škálováním zkontrolovat metodu `getAspectRatioLocked` tvaru. Pokud je zamčený, upravte šířku nebo výšku úměrně místo samostatného škálování.