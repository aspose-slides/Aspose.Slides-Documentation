---
title: Zabránit úpravám prezentace pomocí zamykání tvarů v .NET
linktitle: Zabránit úpravám prezentace
type: docs
weight: 70
url: /cs/net/applying-protection-to-presentation/
keywords:
- zabránit úpravám
- chránit před úpravami
- zamknout tvar
- zamknout polohu
- zamknout výběr
- zamknout velikost
- zamknout seskupení
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro .NET zamyká nebo odemyká tvary v souborech PPT, PPTX a ODP, zabezpečuje prezentace a umožňuje řízené úpravy."
---
## **Background**

Běžným využitím Aspose.Slides je vytváření, aktualizace a ukládání prezentací Microsoft PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Uživatelé aplikací, které používají Aspose.Slides tímto způsobem, mají přístup k vygenerovaným prezentacím, takže jejich ochrana před úpravami je častou starostí. Je důležité, aby automaticky generované prezentace zachovávaly původní formátování a obsah.

Tento článek vysvětluje, jak jsou prezentace a snímky strukturovány a jak může Aspose.Slides pro .NET aplikovat ochranu na prezentaci a později ji odstranit. Poskytuje vývojářům způsob, jak kontrolovat, jak jsou prezentace generované jejich aplikacemi používány.

## **Composition of a Slide**

Prezentace snímku se skládá z komponent, jako jsou automatické tvary, tabulky, OLE objekty, seskupené tvary, rámečky obrázků, video rámečky, propojení a další prvky použité při tvorbě prezentace. V Aspose.Slides pro .NET je každý prvek na snímku reprezentován objektem, který implementuje rozhraní [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/) nebo dědí z třídy, která ho implementuje.

Struktura PPTX je složitá, takže na rozdíl od PPT, kde lze použít obecný zámek pro všechny typy tvarů, různé typy tvarů vyžadují odlišné zámky. Rozhraní [IBaseShapeLock](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseshapelock/) je obecná třída pro zamykání v PPTX. Následující typy zámků jsou v Aspose.Slides pro .NET pro PPTX podporovány:

- [IAutoShapeLock](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshapelock/) zablokuje automatické tvary.  
- [IConnectorLock](https://reference.aspose.com/slides/cs/net/aspose.slides/iconnectorlock/) zablokuje tvary propojení.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cs/net/aspose.slides/igraphicalobjectlock/) zablokuje grafické objekty.  
- [IGroupShapeLock](https://reference.aspose.com/slides/cs/net/aspose.slides/igroupshapelock/) zablokuje skupinové tvary.  
- [IPictureFrameLock](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframelock/) zablokuje rámečky obrázků.  

Jakákoli akce provedená na všech objektech tvarů v objektu [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) se aplikuje na celou prezentaci.

## **Apply and Remove Protection**

Aplikace ochrany zajišťuje, že prezentaci nelze upravovat. Jedná se o užitečnou techniku pro ochranu obsahu prezentace.

### **Apply Protection to PPTX Shapes**

Aspose.Slides pro .NET poskytuje rozhraní [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/) pro práci s tvary na snímku.

Jak bylo zmíněno výše, každá třída tvaru má přiřazenou třídu zamykání tvaru pro ochranu. Tento článek se zaměřuje na zámky NoSelect, NoMove a NoResize. Tyto zámky zajišťují, že tvary nelze vybrat (kliknutím myši nebo jinými metodami výběru) a že je nelze přesunout ani změnit jejich velikost.

Ukázkový kód níže aplikuje ochranu na všechny typy tvarů v prezentaci.

```cs
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
using Presentation presentation = new Presentation("Sample.pptx");

// Procházení všech snímků v prezentaci.
foreach (ISlide slide in presentation.Slides)
{
    // Procházení všech tvarů na snímku.
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

// Ukládání souboru prezentace.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Remove Protection**

Pro odemknutí tvaru nastavte hodnotu použitého zámku na `false`. Následující ukázkový kód ukazuje, jak odemknout tvary v zamčené prezentaci.

```cs
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// Procházení všech snímků v prezentaci.
foreach (ISlide slide in presentation.Slides)
{
    // Procházení všech tvarů na snímku.
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

// Ukládání souboru prezentace.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Conclusion**

Aspose.Slides nabízí několik možností, jak chránit tvary v prezentaci. Můžete zamknout jednotlivý tvar nebo projít všechny tvary v prezentaci a zamknout je, čímž efektivně zabezpečíte celý soubor. Ochranu můžete odstranit nastavením hodnoty zámku na `false`.

## **FAQ**

**Can I combine shape locks and password protection in the same presentation?**

Ano. Zámky omezují úpravy objektů uvnitř souboru, zatímco [password protection](/slides/cs/net/password-protected-presentation/) řídí přístup k otevření a/nebo uložení změn. Tyto mechanismy se doplňují a pracují společně.

**Can I restrict editing on specific slides without affecting others?**

Ano. Aplikujte zámky na tvary na vybraných snímcích; zbylé snímky zůstanou editovatelné.

**Do shape locks apply to grouped objects and connectors?**

Ano. Pro skupiny, propojení, grafické objekty a další typy tvarů jsou podporovány dedikované typy zámků.