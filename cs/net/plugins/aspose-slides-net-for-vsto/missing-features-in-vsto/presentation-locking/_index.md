---
title: Uzamykání prezentace
type: docs
weight: 110
url: /cs/net/presentation-locking/
---
## **Uzamykání prezentace**
Běžné využití **Aspose.Slides** je vytváření, aktualizace a ukládání prezentací Microsoft PowerPoint 2007 (PPTX) jako součást automatizovaného pracovního postupu. Uživatelé aplikace, která Aspose.Slides používá tímto způsobem, získají přístup k výstupním prezentacím. Ochrana před úpravami je běžnou starostí. Je důležité, aby automaticky generované prezentace zachovávaly původní formátování a obsah.

Tento článek vysvětluje, jak jsou prezentace a snímky vytvořeny a jak může Aspose.Slides pro .NET použít ochranu na prezentaci a následně ji z ní odstranit. Tato funkce je unikátní pro Aspose.Slides a v době psaní není dostupná v Microsoft PowerPoint. Poskytuje vývojářům způsob, jak kontrolovat, jak jsou prezentace vytvářené jejich aplikacemi používány.
## **Složení snímku**
Snímek PPTX se skládá z řady komponent, jako jsou automatické tvary, tabulky, OLE objekty, seskupené tvary, rámečky obrázků, rámečky videí, konektory a další různé prvky dostupné pro tvorbu prezentace.

V Aspose.Slides pro .NET je každý prvek na snímku převeden na objekt Shape. Jinými slovy, každý prvek na snímku je buď objekt Shape, nebo objekt odvozený od Shape.

Struktura PPTX je složitá, takže na rozdíl od PPT, kde lze použít obecný zámek pro všechny typy tvarů, existují různé typy zámků pro různé typy tvarů. Třída BaseShapeLock je obecná třída pro zamykání PPTX. Následující typy zámků jsou v Aspose.Slides pro .NET pro PPTX podporovány.

- AutoShapeLock zamyká automatické tvary.
- ConnectorLock zamyká konektory.
- GraphicalObjectLock zamyká grafické objekty.
- GroupshapeLock zamyká seskupené tvary.
- PictureFrameLock zamyká rámečky obrázků.

Jakákoli akce provedená na všech objektech Shape v objektu Presentation se použije na celou prezentaci.
## **Použití a odebrání ochrany**
Aplikace ochrany zajišťuje, že prezentaci nelze upravovat. Jedná se o užitečnou techniku pro ochranu obsahu prezentace.

**Použití ochrany na tvary PPTX**

Aspose.Slides pro .NET poskytuje třídu Shape pro práci s tvarem na snímku.

Jak bylo zmíněno dříve, každá třída tvaru má přiřazenou třídu zámku tvaru pro ochranu. Tento článek se zaměřuje na zámky NoSelect, NoMove a NoResize. Tyto zámky zajišťují, že tvary nelze vybrat (kliknutím myši nebo jinými způsoby výběru) a nelze je přesouvat ani měnit jejich velikost.

Následující ukázky kódu aplikují ochranu na všechny typy tvarů v prezentaci.

``` csharp

 //Vytvoření instance třídy Presentation, která představuje soubor PPTX

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//Vytvoření instance třídy Presentation, která představuje soubor PPTX


//Objekt ISlide pro přístup k snímkům v prezentaci

SlideEx slide = pTemplate.Slides[0];

//Objekt IShape pro ukládání dočasných tvarů

ShapeEx shape;

//Procházení všech snímků v prezentaci

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Procházení všech tvarů ve snímcích

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//pokud je tvar autoshape

		if (shape is AutoShapeEx)

		{

			//Přetypování na AutoShape a získání zámku autoshape

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Aplikování zámků tvarů

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//pokud je tvar skupinový tvar

		else if (shape is GroupShapeEx)

		{

			//Přetypování na skupinový tvar a získání zámku skupinového tvaru

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Aplikování zámků tvarů

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//pokud je tvar konektor

		else if (shape is ConnectorEx)

		{

			//Přetypování na tvar konektoru a získání zámku konektoru

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Aplikování zámků tvarů

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//pokud je tvar rámeček obrázku

		else if (shape is PictureFrameEx)

		{

			//Přetypování na tvar rámečku obrázku a získání zámku rámečku obrázku

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Aplikování zámků tvarů

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//Ukládání souboru prezentace

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**Odebrání ochrany**

Ochrana aplikovaná pomocí Aspose.Slides pro .NET může být odebrána pouze pomocí Aspose.Slides pro .NET. Pro odemčení tvaru nastavte hodnotu aplikovaného zámku na false. Následující ukázka kódu ukazuje, jak odemknout tvary v uzamčené prezentaci.

``` csharp

 //Otevřete požadovanou prezentaci

PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//Objekt ISlide pro přístup k snímkům v prezentaci

SlideEx slide = pTemplate.Slides[0];

//Objekt IShape pro uchování dočasných tvarů

ShapeEx shape;

//Procházení všech snímků v prezentaci

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Procházení všech tvarů ve snímcích

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//pokud je tvar autoshape

		if (shape is AutoShapeEx)

		{

			//Přetypování na Auto shape a  získání zámku autoshape

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Aplikování zámků tvarů

			AutoShapeLock.PositionLocked = false;

			AutoShapeLock.SelectLocked = false;

			AutoShapeLock.SizeLocked = false;

		}

		//pokud je tvar group shape

		else if (shape is GroupShapeEx)

		{

			//Přetypování na group shape a  získání zámku group shape

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Aplikování zámků tvarů

			groupShapeLock.GroupingLocked = false;

			groupShapeLock.PositionLocked = false;

			groupShapeLock.SelectLocked = false;

			groupShapeLock.SizeLocked = false;

		}

		//pokud je tvar Connector shape

		else if (shape is ConnectorEx)

		{

			//Přetypování na connector shape a  získání zámku connector shape

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Aplikování zámků tvarů

			ConnLock.PositionMove = false;

			ConnLock.SelectLocked = false;

			ConnLock.SizeLocked = false;

		}

		//pokud je tvar picture frame

		else if (shape is PictureFrameEx)

		{

			//Přetypování na picture frame shape a  získání zámku picture frame shape

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Aplikování zámků tvarů

			PicLock.PositionLocked = false;

			PicLock.SelectLocked = false;

			PicLock.SizeLocked = false;

		}

	}

}

//Ukládání souboru prezentace

pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Stažení ukázkového kódu**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)