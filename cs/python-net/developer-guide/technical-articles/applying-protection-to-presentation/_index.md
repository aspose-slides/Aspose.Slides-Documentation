---
title: Zabránit úpravám prezentace pomocí zamykání tvarů v Pythonu
linktitle: Zabránit úpravám prezentace
type: docs
weight: 70
url: /cs/python-net/applying-protection-to-presentation/
keywords:
- zabránit úpravám
- chránit před úpravami
- zamknout tvar
- zamknout pozici
- zamknout výběr
- zamknout velikost
- zamknout seskupování
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro Python prostřednictvím .NET zamyká nebo odemyká tvary v souborech PPT, PPTX a ODP, zabezpečuje prezentace při povolení řízených úprav a rychlejšího dodání."
---
## **Pozadí**

Běžné využití Aspose.Slides je vytváření, aktualizace a ukládání prezentací Microsoft PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Uživatelé aplikací, které takto používají Aspose.Slides, mají přístup k vygenerovaným prezentacím, takže jejich ochrana před úpravami je častým problémem. Je důležité, aby automaticky generované prezentace zachovaly původní formátování a obsah.

Tento článek vysvětluje, jak jsou prezentace a snímky strukturovány a jak může Aspose.Slides pro Python použít ochranu na prezentaci a později ji odstranit. Poskytuje vývojářům způsob, jak kontrolovat, jak jsou prezentace generované jejich aplikacemi používány.

## **Složení snímku**

Snímek prezentace se skládá z komponent, jako jsou automatické tvary, tabulky, OLE objekty, seskupené tvary, rámy obrázků, rámy videí, konektory a další prvky používané k vytvoření prezentace. V Aspose.Slides pro Python je každý prvek na snímku reprezentován objektem, který dědí třídu [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/).

Struktura PPTX je složitá, takže na rozdíl od PPT, kde lze použít generické zamknutí pro všechny typy tvarů, různé typy tvarů vyžadují různá zamknutí. Třída [BaseShapeLock](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseshapelock/) je generická třída zamykání pro PPTX. V Aspose.Slides pro Python pro PPTX jsou podporovány následující typy zamykání:

- [AutoShapeLock](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshapelock/) zamyká automatické tvary.  
- [ConnectorLock](https://reference.aspose.com/slides/cs/python-net/aspose.slides/connectorlock/) zamyká tvary konektorů.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/cs/python-net/aspose.slides/graphicalobjectlock/) zamyká grafické objekty.  
- [GroupShapeLock](https://reference.aspose.com/slides/cs/python-net/aspose.slides/groupshapelock/) zamyká seskupené tvary.  
- [PictureFrameLock](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframelock/) zamyká rámy obrázků.  

Jakákoli akce provedená na všech objektech tvaru v objektu [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) se aplikuje na celou prezentaci.

## **Použití a odebrání ochrany**

Použití ochrany zajišťuje, že prezentaci nelze upravovat. Jedná se o užitečnou techniku pro ochranu obsahu prezentace.

### **Použití ochrany na tvary PPTX**

Aspose.Slides pro Python poskytuje třídu [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/) pro práci s tvary na snímku.

Jak bylo zmíněno dříve, každá třída tvaru má přiřazenou třídu zamykání tvaru pro ochranu. Tento článek se zaměřuje na zamykání NoSelect, NoMove a NoResize. Tato zamykání zajišťují, že tvary nelze vybrat (pomocí kliknutí myší nebo jiných metod výběru) a že je nelze přesunout ani změnit jejich velikost.

Následující ukázkový kód aplikuje ochranu na všechny typy tvarů v prezentaci.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
with slides.Presentation("Sample.pptx") as presentation:
    # Procházení všech snímků v prezentaci.
    for slide in presentation.slides:
        # Procházení všech tvarů na snímku.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # Ukládání souboru prezentace.
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Odebrání ochrany**

Pro odemknutí tvaru nastavte hodnotu aplikovaného zámku na `False`. Následující ukázkový kód ukazuje, jak odemknout tvary v zamčené prezentaci.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # Procházení všech snímků v prezentaci.
    for slide in presentation.slides:
        # Procházení všech tvarů na snímku.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # Ukládání souboru prezentace.
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Závěr**

Aspose.Slides nabízí několik možností pro ochranu tvarů v prezentaci. Můžete zamknout jednotlivý tvar nebo projít všechny tvary v prezentaci a zamknout každý z nich, čímž efektivně zabezpečíte celý soubor. Ochranu můžete odstranit nastavením hodnoty zámku na `False`.

## **Často kladené otázky**

**Mohu kombinovat zamykání tvarů a ochranu heslem ve stejné prezentaci?**

Ano. Zamykání omezuje úpravy objektů v souboru, zatímco [password protection](/slides/cs/python-net/password-protected-presentation/) řídí přístup k otevření a/nebo uložení změn. Tyto mechanismy se doplňují a spolupracují.

**Mohu omezit úpravy na konkrétních snímcích bez ovlivnění ostatních?**

Ano. Aplikujte zamykání na tvary na vybraných snímcích; ostatní snímky zůstanou upravitelné.

**Platí zamykání tvarů na seskupené objekty a konektory?**

Ano. Pro skupiny, konektory, grafické objekty a další typy tvarů jsou podporovány speciální typy zamykání.