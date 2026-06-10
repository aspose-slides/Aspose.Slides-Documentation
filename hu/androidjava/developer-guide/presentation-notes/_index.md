---
title: Prezentációs jegyzetek kezelése Androidon
linktitle: Prezentációs jegyzetek
type: docs
weight: 110
url: /hu/androidjava/presentation-notes/
keywords:
- jegyzetek
- jegyzet dia
- jegyzetek hozzáadása
- jegyzetek eltávolítása
- jegyzet stílus
- főjegyzetek
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Testre szabhatja a prezentációs jegyzeteket az Aspose.Slides for Android segítségével Java nyelven. Zökkenőmentesen dolgozhat a PowerPoint és OpenDocument jegyzetekkel a termelékenység növelése érdekében."
---
## **Áttekintés**

Az Aspose.Slides támogatja a jegyzet diák eltávolítását egy prezentációból. Ebben a témában bemutatjuk ezt a funkciót, beleértve a jegyzetek eltávolítását és a jegyzet diák stílusának alkalmazását a prezentációban. Az Aspose.Slides lehetővé teszi, hogy jegyzeteket távolítson el bármely diáról, illetve stílusokat alkalmazzon a meglévő jegyzetekre. A fejlesztők a következő módokon távolíthatják el a jegyzeteket:

- Jegyzetek eltávolítása egy meghatározott diáról a prezentációban.
- Jegyzetek eltávolítása minden diáról a prezentációban.

## **Jegyzetek eltávolítása egy diáról**
Egy adott diára vonatkozó jegyzetek eltávolíthatók az alábbi példában bemutatott módon:

```java
// Egy Presentation objektum példányosítása, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Az első dia jegyzeteinek eltávolítása
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Prezentáció mentése lemezre
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Jegyzetek eltávolítása a prezentációból**
A prezentáció összes diájáról eltávolíthatók a jegyzetek, ahogyan az alábbi példában látható:

```java
// Egy Presentation objektum példányosítása, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Az összes dia jegyzeteinek eltávolítása
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Prezentáció mentése lemezre
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Jegyzetstílus hozzáadása**
[getNotesStyle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) metódus került hozzáadásra a [IMasterNotesSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IMasterNotesSlide) interfészhez és a [MasterNotesSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/MasterNotesSlide) osztályhoz. Ez a tulajdonság a jegyzet szövegének stílusát határozza meg. A megvalósítás az alábbi példában van bemutatva.

```java
// Egy Presentation objektum példányosítása, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // A MasterNotesSlide szövegstílusának lekérése
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Szimbólum golyót állít be az első szintű bekezdésekhez
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Melyik API-elem biztosít hozzáférést egy adott dia jegyzeteihez?**

A jegyzetek a dia jegyzetkezelőjén keresztül érhetők el: a diának van egy [NotesSlideManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/notesslidemanager/) és egy [method](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) amely visszaadja a jegyzet objektumot, vagy `null`‑t, ha nincs jegyzet.

**Vannak-e különbségek a jegyzetek támogatásában a PowerPoint különböző verziói között, amelyekkel a könyvtár működik?**

A könyvtár a Microsoft PowerPoint széles körű formátumtartományát (97‑újabb) és az ODP‑t célozza; a jegyzetek támogatottak ezekben a formátumokban, anélkül hogy a PowerPoint telepített példányára lenne szükség.