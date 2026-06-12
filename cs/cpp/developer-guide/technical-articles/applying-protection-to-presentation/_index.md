---
title: Zabránit úpravám prezentace pomocí zámků tvarů
linktitle: Zabránit úpravám prezentace
type: docs
weight: 10
url: /cs/cpp/applying-protection-to-presentation/
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
- C++
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro C++ zamyká nebo odemyká tvary v souborech PPT, PPTX a ODP, zabezpečuje prezentace a zároveň umožňuje kontrolované úpravy a rychlejší doručení."
---
## **Pozadí**

Běžné použití Aspose.Slides je vytvářet, aktualizovat a ukládat prezentace Microsoft PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Uživatelé aplikací, které Aspose.Slides tímto způsobem využívají, mají přístup k vygenerovaným prezentacím, takže jejich ochrana před úpravami je častou starostí. Je důležité, aby automaticky generované prezentace zachovaly původní formátování a obsah.

Tento článek vysvětluje, jak jsou prezentace a snímky strukturovány a jak může Aspose.Slides for C++ aplikovat ochranu na prezentaci a později ji odebrat. Poskytuje vývojářům způsob, jak kontrolovat, jak jsou prezentace generované jejich aplikacemi využívány.

## **Složení snímku**

Snímek prezentace se skládá z komponent, jako jsou automatické tvary, tabulky, OLE objekty, seskupené tvary, rámečky obrázků, video rámečky, propojení a další prvky používané k vytvoření prezentace. V Aspose.Slides for C++ je každý prvek na snímku reprezentován objektem, který implementuje rozhraní [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/) nebo dědí z třídy, která to dělá.

Struktura PPTX je složitá, takže na rozdíl od PPT, kde lze použít obecný zámek pro všechny typy tvarů, různé typy tvarů vyžadují různé zámky. Rozhraní [IBaseShapeLock](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseshapelock/) je obecná třída pro zamykání v PPTX. Následující typy zámků jsou podporovány v Aspose.Slides for C++ pro PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshapelock/) zamyká automatické tvary.  
- [IConnectorLock](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iconnectorlock/) zamyká propojené tvary.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cs/cpp/aspose.slides/igraphicalobjectlock/) zamyká grafické objekty.  
- [IGroupShapeLock](https://reference.aspose.com/slides/cs/cpp/aspose.slides/igroupshapelock/) zamyká skupinové tvary.  
- [IPictureFrameLock](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipictureframelock/) zamyká rámečky obrázků.   

Jakákoli akce provedená na všech objektech tvarů v objektu [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) se aplikuje na celou prezentaci.

## **Aplikace a odebrání ochrany**

Aplikace ochrany zajišťuje, že prezentaci nelze upravovat. Jedná se o užitečnou techniku pro ochranu obsahu prezentace.

### **Aplikovat ochranu na tvary PPTX**

Aspose.Slides for C++ poskytuje rozhraní [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/) pro práci s tvary na snímku.

Jak bylo zmíněno dříve, každá třída tvaru má přiřazenou třídu zamykání tvaru pro ochranu. Tento článek se zaměřuje na zámky NoSelect, NoMove a NoResize. Tyto zámky zajišťují, že tvary nelze vybrat (kliknutím myší nebo jinými metodami výběru) a že je nelze přesunout ani změnit jejich velikost.

Ukázkový kód níže aplikuje ochranu na všechny typy tvarů v prezentaci.

```cpp
// Vytvořte třídu Presentation, která představuje soubor PPTX.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Procházení všech snímků v prezentaci.
for (auto&& slide : presentation->get_Slides())	{

	// Procházení všech tvarů na snímku.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Přetypování tvaru na automatický tvar a získání jeho zámku tvaru.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Přetypování tvaru na skupinový tvar a získání jeho zámku tvaru.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Přetypování tvaru na spojovací tvar a získání jeho zámku tvaru.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Přetypování tvaru na rámeček obrázku a získání jeho zámku tvaru.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// Ukládání souboru prezentace.
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Odebrat ochranu**

Pro odemknutí tvaru nastavte hodnotu aplikovaného zámku na `false`. Následující ukázkový kód ukazuje, jak odemknout tvary v zamčené prezentaci.

```cpp
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// Procházení všech snímků v prezentaci.
for (auto&& slide : presentation->get_Slides())	{

	// Procházení všech tvarů na snímku.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Přetypování tvaru na automatický tvar a získání jeho zámku tvaru.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Přetypování tvaru na skupinový tvar a získání jeho zámku tvaru.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Přetypování tvaru na spojovací tvar a získání jeho zámku tvaru.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Přetypování tvaru na rámeček obrázku a získání jeho zámku tvaru.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// Ukládání souboru prezentace.
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Závěr**

Aspose.Slides nabízí několik možností, jak chránit tvary v prezentaci. Můžete zamknout jednotlivý tvar nebo projít všechny tvary v prezentaci a zamknout každý z nich, abyste efektivně zabezpečili celý soubor. Ochranu můžete odebrat nastavením hodnoty zámku na `false`.

## **Často kladené otázky**

**Mohu kombinovat zámky tvarů a ochranu heslem ve stejné prezentaci?**

Ano. Zámky omezují úpravy objektů uvnitř souboru, zatímco [ochrana heslem](/slides/cs/cpp/password-protected-presentation/) řídí přístup k otevření a/nebo uložení změn. Tyto mechanismy se doplňují a pracují společně.

**Mohu omezit úpravy na konkrétních snímcích, aniž by to ovlivnilo ostatní?**

Ano. Aplikujte zámky na tvary na vybraných snímcích; zbývající snímky zůstanou upravitelně.

**Platí zámky tvarů i na seskupené objekty a propojení?**

Ano. Pro skupiny, propojení, grafické objekty a další typy tvarů jsou podporovány vyhrazené typy zámků.