---
title: Figyelmeztető visszahívások lekérése betűtípushelyettesítéshez
type: docs
weight: 90
url: /hu/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- figyelmeztető visszahívás
- betűtípushelyettesítés
- renderelési folyamat
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan kaphat figyelmeztető visszahívásokat a betűtípushelyettesítéshez az Aspose.Slides for Java-ban, és jelenítse meg pontosan a PowerPoint és OpenDocument prezentációkat."
---
## **Bevezetés**

Az Aspose.Slides for Java lehetővé teszi, hogy figyelmeztető visszahívásokat kapjon a betűtípushelyettesítésre, amikor egy szükséges betűtípus nem érhető el a gépen a renderelés során. Ezek a visszahívások segítenek a hiányzó vagy elérhetetlen betűtípusok problémáinak diagnosztizálásában.

## **Figyelmeztető visszahívások engedélyezése**

Az Aspose.Slides for Java egyszerű API-kat biztosít a figyelmeztető visszahívások fogadásához a prezentációs diák renderelésekor. Kövesse az alábbi lépéseket a figyelmeztető visszahívások konfigurálásához:

1. Hozzon létre egy egyéni visszahívásosztályt, amely megvalósítja az [IWarningCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarningcallback/) interfészt a figyelmeztetések kezeléséhez.  
2. Állítsa be a figyelmeztető visszahívást olyan opcióosztályok segítségével, mint a [RenderingOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/renderingoptions/), a [PdfOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pdfoptions/), a [HtmlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/htmloptions/), és egyéb osztályok.  
3. Töltsön be egy prezentációt, amely olyan betűtípust használ, amely nem áll rendelkezésre a célgépen.  
4. Generáljon egy diakép bélyegképet, vagy exportálja a prezentációt a hatás megfigyeléséhez.  

**Egyéni figyelmeztető visszahívás osztály:**

```java
class FontWarningHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss) {
            System.out.println(warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

// Példa kimenet:
//
// A betűtípus a XYZ helyett a {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}} lesz helyettesítve
```

**Diabélyegkép generálása:**

```java
// Állíts be egy figyelmeztető visszahívást a diák renderelése közbeni betűtípusra vonatkozó figyelmeztetések kezeléséhez.
RenderingOptions options = new RenderingOptions();
options.setWarningCallback(new FontWarningHandler());

// Töltsd be a prezentációt a megadott fájl útvonalról.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Generálj egy bélyegkép képet minden diára a prezentációban.
    for (ISlide slide : presentation.getSlides()) {
        // Szerezd meg a diakép bélyegképet a megadott renderelési opciókkal.
        IImage image = slide.getImage(options);
        // ...

        image.dispose();
    }
}
finally {
    presentation.dispose();
}
```

**Exportálás PDF formátumba:**

```java
// Állíts be egy figyelmeztető visszahívást a PDF export közbeni betűtípusra vonatkozó figyelmeztetések kezeléséhez.
SaveOptions options = new PdfOptions();
options.setWarningCallback(new FontWarningHandler());

// Töltsd be a prezentációt a megadott fájl útvonalról.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Exportáld a prezentációt PDF formátumba.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Pdf, options);
    // ...
}
finally {
    presentation.dispose();    
}
```

**Exportálás HTML formátumba:**

```java
// Állíts be egy figyelmeztető visszahívást a HTML export közbeni betűtípusra vonatkozó figyelmeztetések kezeléséhez.
SaveOptions options = new HtmlOptions();
options.setWarningCallback(new FontWarningHandler());

// Töltsd be a prezentációt a megadott fájl útvonalról.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Exportáld a prezentációt HTML formátumba.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Html, options);
    // ...
}
finally {
    presentation.dispose();
}
```