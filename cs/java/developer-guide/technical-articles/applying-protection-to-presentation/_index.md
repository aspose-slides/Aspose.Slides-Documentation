---
title: Zabránit úpravám prezentace pomocí zamykání tvarů
linktitle: Zabránit úpravám prezentace
type: docs
weight: 60
url: /cs/java/applying-protection-to-presentation/
keywords:
- zabránit úpravám
- chránit před úpravami
- zamknout tvar
- zamknout pozici
- zamknout výběr
- zamknout velikost
- zamknout seskupení
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro Java zamyká nebo odemyká tvary v souborech PPT, PPTX a ODP, zabezpečuje prezentace a zároveň umožňuje řízené úpravy a rychlejší doručení."
---
## **Pozadí**

Běžné využití Aspose.Slides je vytváření, aktualizace a ukládání prezentací Microsoft PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Uživatelé aplikací, které Aspose.Slides tímto způsobem používají, mají přístup k vygenerovaným prezentacím, takže jejich ochrana před úpravami je častým problémem. Je důležité, aby automaticky generované prezentace zachovaly původní formátování a obsah.

Tento článek vysvětluje, jak jsou prezentace a snímky strukturovány a jak může Aspose.Slides pro Java aplikovat ochranu na prezentaci a později ji odebrat. Poskytuje vývojářům způsob, jak kontrolovat, jak jsou prezentace generované jejich aplikacemi používány.

## **Složení snímku**

Snímek prezentace se skládá z komponent, jako jsou automatické tvary, tabulky, OLE objekty, seskupené tvary, rámečky obrázků, video rámečky, spojnice a další prvky používané k vytvoření prezentace. V Aspose.Slides pro Java je každý prvek na snímku reprezentován objektem, který implementuje rozhraní [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/) nebo dědí z třídy, která to dělá.

Struktura PPTX je složitá, takže na rozdíl od PPT, kde lze použít obecný zámek pro všechny typy tvarů, různé typy tvarů vyžadují různé zámky. Rozhraní [IBaseShapeLock](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseshapelock/) je obecná třída pro zamykání v PPTX. Následující typy zámků jsou v Aspose.Slides pro Java pro PPTX podporovány:

- [IAutoShapeLock](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshapelock/) uzamyká automatické tvary.  
- [IConnectorLock](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iconnectorlock/) uzamyká tvary spojnic.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cs/java/com.aspose.slides/igraphicalobjectlock/) uzamyká grafické objekty.  
- [IGroupShapeLock](https://reference.aspose.com/slides/cs/java/com.aspose.slides/igroupshapelock/) uzamyká skupinové tvary.  
- [IPictureFrameLock](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframelock/) uzamyká rámečky obrázků.  

Jakákoli akce provedená na všech objektech tvarů v objektu [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) se aplikuje na celou prezentaci.

## **Použití a odebrání ochrany**

Aplikace ochrany zajišťuje, že prezentaci nelze upravovat. Je to užitečná technika pro ochranu obsahu prezentace.

### **Aplikovat ochranu na tvary PPTX**

Aspose.Slides pro Java poskytuje rozhraní [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/), které umožňuje pracovat s tvary na snímku.

Jak bylo zmíněno dříve, každá třída tvaru má přidruženou třídu zamykání tvaru pro ochranu. Tento článek se zaměřuje na zámky NoSelect, NoMove a NoResize. Tyto zámky zajišťují, že tvary nelze vybrat (pomocí kliknutí myší nebo jiných metod výběru) a že je nelze přesunout ani změnit jejich velikost.

Ukázkový kód níže aplikuje ochranu na všechny typy tvarů v prezentaci.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
Presentation presentation = new Presentation("Sample.pptx");

// Procházení všech snímků v prezentaci.
for (ISlide slide : presentation.getSlides()) {

    // Procházení všech tvarů na snímku.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Přetypování tvaru na automatický tvar a získání jeho zamykání tvaru.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // Přetypování tvaru na skupinový tvar a získání jeho zamykání tvaru.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // Přetypování tvaru na spojnicový tvar a získání jeho zamykání tvaru.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // Přetypování tvaru na rámeček obrázku a získání jeho zamykání tvaru.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// Ukládání souboru prezentace.
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Odebrat ochranu**

Pro odemknutí tvaru nastavte hodnotu použitého zámku na `false`. Následující ukázkový kód ukazuje, jak odemknout tvary v zamčené prezentaci.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
Presentation presentation = new Presentation("ProtectedSample.pptx");

// Procházení všech snímků v prezentaci.
for (ISlide slide : presentation.getSlides()) {

    // Procházení všech tvarů na snímku.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Přetypování tvaru na automatický tvar a získání jeho zamykání tvaru.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // Přetypování tvaru na skupinový tvar a získání jeho zamykání tvaru.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // Přetypování tvaru na spojnicový tvar a získání jeho zamykání tvaru.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // Přetypování tvaru na rámeček obrázku a získání jeho zamykání tvaru.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// Ukládání souboru prezentace.
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Závěr**

Aspose.Slides nabízí několik možností, jak chránit tvary v prezentaci. Můžete zamknout jednotlivý tvar nebo projít všechny tvary v prezentaci a zamknout je, čímž efektivně zabezpečíte celý soubor. Ochranu můžete odebrat nastavením hodnoty zámku na `false`.

## **Často kladené otázky**

**Mohu kombinovat zámky tvarů a chránění heslem ve stejné prezentaci?**

Ano. Zámky omezují úpravy objektů v souboru, zatímco [password protection](/slides/cs/java/password-protected-presentation/) řídí přístup k otevření a/nebo uložení změn. Tyto mechanismy se doplňují a spolupracují.

**Mohu omezit úpravy na konkrétních snímcích, aniž bych ovlivnil ostatní?**

Ano. Použijte zámky na tvary na vybraných snímcích; zbývající snímky zůstanou upravitelně.

**Platí zámky tvarů pro seskupené objekty a spojnice?**

Ano. Pro skupiny, spojnice, grafické objekty a další typy tvarů jsou podporovány samostatné typy zámků.