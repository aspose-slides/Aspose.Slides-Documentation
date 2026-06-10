---
title: Mesterdia
type: docs
weight: 30
url: /hu/java/examples/elements/master-slide/
keywords:
- kód példa
- mesterdia
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Java mesterdia példákat: hozzon létre, szerkesszen és formázzon mestereket, helyettesítőket és sablonokat PPT, PPTX és ODP formátumokban világos Java kóddal."
---
A mesterdiák (master slides) a diárok öröklődési hierarchiájának legfelső szintjét alkotják a PowerPoint‑ban. Egy **mesterdiá** (master slide) közös dizájnelemeket definiál, például háttérképeket, logókat és szövegformázást. **Elrendezésdiák** (layout slides) öröklik a mesterdiákat, és a **normál diák** (normal slides) az elrendezésdiákból származnak.

Ez a cikk bemutatja, hogyan hozhatók létre, módosíthatók és kezelhetők a mesterdiák az Aspose.Slides for Java segítségével.

## **Mesterdia hozzáadása**

Ez a példa azt mutatja be, hogyan hozható létre egy új mesterdia a alapértelmezett klónozásával. Ezután egy vállalati névpelenkét ad hozzá az összes diára az elrendezésöröklődésen keresztül.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Klónozza az alapértelmezett mesterdiát.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Adjon hozzá egy vállalati névű banner-t a mesterdia tetejéhez.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Rendelje hozzá az új mesterdiát egy elrendezési diához.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Rendelje hozzá az elrendezési diát a prezentáció első diájához.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Megjegyzés 1:** A mesterdiák lehetővé teszik a konzisztens márkázás vagy megosztott dizájnelemek alkalmazását az összes dián. A mesterdia‑ban végzett módosítások automatikusan megjelennek a függő elrendezés- és normál diákon.
> 
> 💡 **Megjegyzés 2:** A mesterdia‑ra hozzáadott alakzatok vagy formázások öröklődnek az elrendezésdiákra, és továbbá minden olyan normál diasorra, amely ezeket az elrendezéseket használja.  
> Az alábbi kép szemlélteti, hogy egy mesterdia‑ra felvett szövegdoboz hogyan jelenik meg automatikusan a végső dián.

![Mesteröröklődés példa](master-slide-banner.png)

## **Mesterdia elérése**

A mesterdiák a prezentáció mestergyűjteményén (presentation master collection) keresztül érhetők el. Íme, hogyan lehet lekérdezni és dolgozni velük:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // A háttér típusának módosítása.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **Mesterdia eltávolítása**

A mesterdiák eltávolíthatók index vagy referencia alapján.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Master dia eltávolítása index alapján.
        presentation.getMasters().removeAt(0);

        // Master dia eltávolítása referenciával.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Nem használt mesterdiák eltávolítása**

Egyes prezentációk olyan mesterdiákat tartalmaznak, amelyeket nem használnak. Ezek eltávolítása csökkentheti a fájlméretet.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Az összes nem használt mesterdia (még a megőrzésre jelölteket is) eltávolítása.
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```