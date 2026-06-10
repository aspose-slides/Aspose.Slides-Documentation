---
title: Mester dia
type: docs
weight: 30
url: /hu/androidjava/examples/elements/master-slide/
keywords:
- kódpélda
- mester dia
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Android mesterdia példákat: hozza létre, szerkessze és formázza a mestereket, helyettesítőket és témákat PPT, PPTX és ODP formátumokban, egyértelmű Java kóddal."
---
A mesterdiaikonok a diaöröklési hierarchia legfelső szintjét alkotják a PowerPointban. Egy **mesterdia** meghatározza a közös tervezési elemeket, például a háttereket, logókat és a szövegformázást. **Elrendezési diák** öröklődnek a mesterdiákból, és a **normál diák** öröklődnek az elrendezési diákból.

Ez a cikk bemutatja, hogyan hozhatunk létre, módosíthatunk és kezelhetünk mesterdiákat az Aspose.Slides for Android Java-on keresztül.

## **Mesterdia hozzáadása**

Ez a példa azt mutatja, hogyan hozhatunk létre egy új mesterdiát az alapértelmezett klónozásával. Ezután egy vállalatneves bannert ad hozzá az összes diára az elrendezési öröklődésen keresztül.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Klónozza az alapértelmezett mesterdiát.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Céges név bannert ad a mesterdia tetejéhez.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Az új mesterdiát hozzárendeli egy elrendezési diához.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Az elrendezési diát hozzárendeli a bemutató első diájához.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Megjegyzés 1:** A mesterdiák lehetővé teszik a következetes márkázás vagy közös tervezési elemek alkalmazását az összes dián. A mesterben végrehajtott bármely változtatás automatikusan megjelenik a függő elrendezési és normál diákon.

> 💡 **Megjegyzés 2:** A mesterdiára hozzáadott alakzatok vagy formázások öröklődnek az elrendezési diákra, és ezáltal minden olyan normál diára, amely ezeket az elrendezéseket használja.  
> Az alábbi kép szemlélteti, hogyan jelenik meg automatikusan egy mesterdiára felvett szövegdoboz a végső dián.

![Master Inheritance Example](master-slide-banner.png)

## **Mesterdia elérése**

A mesterdiákhoz a prezentáció mestergyűjteményén keresztül férhet hozzá. Íme, hogyan kérheti le és dolgozhat velük:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // Módosítsa a háttér típusát.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **Mesterdia eltávolítása**

A mesterdiák eltávolíthatók index vagy referencia alapján.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Távolítson el egy mesterdiát index alapján.
        presentation.getMasters().removeAt(0);

        // Távolítson el egy mesterdiát referenciával.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Használaton kívüli mesterdiák eltávolítása**

Néhány prezentáció olyan mesterdiákat tartalmaz, amelyek nincsenek használatban. Ezen diák eltávolítása segíthet csökkenteni a fájlméretet.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Távolítsa el az összes használaton kívüli mesterdiát (még azokat is, amelyek Preserve-ként vannak megjelölve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```