---
title: Změna velikosti tvarů na snímcích prezentací
type: docs
weight: 110
url: /cs/java/re-sizing-shapes-on-slide/
keywords:
- změna velikosti tvaru
- změnit velikost tvaru
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Jednoduše změňte velikost tvarů na snímcích PowerPoint a OpenDocument pomocí Aspose.Slides pro Java - automatizujte úpravy rozložení snímků a zvýšte produktivitu."
---
## **Přehled**

Jedna z nejčastějších otázek zákazníků Aspose.Slides pro Java je, jak změnit velikost tvarů tak, aby se při změně velikosti snímku data neodříznula. Tento stručný technický článek ukazuje, jak to provést.

## **Změnit velikost tvarů**

Aby se zabránilo posunutí tvarů při změně velikosti snímku, aktualizujte pozici a rozměry každého tvaru tak, aby odpovídaly novému rozložení snímku.

```java
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

    // Změnit velikost a pozici tvarů na každém snímku.
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

{{% alert color="primary" %}} 
Pokud snímek obsahuje tabulku, výše uvedený kód nebude fungovat správně. V takovém případě je třeba změnit velikost každé buňky v tabulce.
{{% /alert %}} 

Použijte následující kód na své straně k změně velikosti snímků, které obsahují tabulky. Pro tabulky je nastavení šířky nebo výšky speciální případ: musíte upravit výšky jednotlivých řádků a šířky sloupců, aby se změnila celková velikost tabulky.

```java
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
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Proč jsou tvary po změně velikosti snímku deformované nebo oříznuté?**

Při změně velikosti snímku si tvary zachovávají původní pozici a velikost, pokud se měřítko explicitně nezmění. To může vést k oříznutí obsahu nebo k nesprávnému zarovnání tvarů.

**Funguje poskytnutý kód pro všechny typy tvarů?**

Základní příklad funguje pro většinu typů tvarů (textboxy, obrázky, grafy atd.). U tabulek však musíte zacházet s řádky a sloupci samostatně, protože výška a šířka tabulky jsou určeny rozměry jednotlivých buněk.

**Jak změním velikost tabulek při změně velikosti snímku?**

Musíte projít všechny řádky a sloupce tabulky a změnit jejich výšku a šířku úměrně, jak je ukázáno ve druhém příkladu kódu.

**Bude tato změna velikosti fungovat pro hlavní snímky a snímky rozvržení?**

Ano, ale měli byste také projít [Masters](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getMasters--) a [Layout slides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getLayoutSlides--) a použít stejnou logiku škálování na jejich tvary, aby byla zajištěna konzistence v celé prezentaci.

**Mohu změnit orientaci snímku (na výšku/do šířky) spolu se změnou velikosti?**

Ano. K změně orientace můžete použít [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidesize/#setOrientation-int-). Ujistěte se, že podle toho nastavíte logiku škálování, aby bylo zachováno rozložení.

**Existuje omezení velikosti snímku, kterou mohu nastavit?**

Aspose.Slides podporuje vlastní velikosti, ale velmi velké rozměry mohou ovlivnit výkon nebo kompatibilitu s některými verzemi PowerPointu.

**Jak mohu zabránit deformaci tvarů se zafixovaným poměrem stran?**

Můžete před škálováním zkontrolovat metodu `getAspectRatioLocked` tvaru. Pokud je poměr stran zamčen, upravte šířku nebo výšku úměrně místo individuálního škálování.