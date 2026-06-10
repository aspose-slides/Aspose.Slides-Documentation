---
title: Prezentációzárolás
type: docs
weight: 110
url: /hu/net/presentation-locking/
---
## **Prezentációzárolás**
Az **Aspose.Slides** gyakori felhasználási módja, hogy Microsoft PowerPoint 2007 (PPTX) prezentációkat hozzon létre, frissítsen és mentse egy automatizált munkafolyamat részeként. Az alkalmazás felhasználói, amely így használja az Aspose.Slides-ot, hozzáférnek a kimeneti prezentációkhoz. Azok szerkesztés elleni védelme gyakori aggodalom. Fontos, hogy az automatikusan generált prezentációk megőrizzék eredeti formázásukat és tartalmukat.

Ez elmagyarázza, hogyan épülnek fel a prezentációk és diák, valamint hogyan tud az Aspose.Slides for .NET védelmet alkalmazni egy prezentáción, majd eltávolítani azt. Ez a funkció egyedülálló az Aspose.Slides számára, és a megírás időpontjában nem elérhető a Microsoft PowerPointban. A fejlesztőknek lehetőséget ad arra, hogy szabályozzák, hogyan használják fel az alkalmazásaik által létrehozott prezentációkat.

## **Dia összeállítása**
Egy PPTX dia számos komponensből áll, például automatikus alakzatok, táblázatok, OLE-objektumok, csoportosított alakzatok, képkockák, videókockák, csatlakozók és a prezentáció felépítéséhez rendelkezésre álló különféle egyéb elemek.

Az Aspose.Slides for .NET-ben a dia minden eleme Shape objektummá alakul. Más szóval, a dia minden eleme vagy Shape objektum, vagy a Shape objektumból származtatott objektum.

A PPTX felépítése összetett, így a PPT-vel ellentétben, ahol egy általános zárolás használható minden alakzattípusra, a különböző alakzattípusokhoz különféle zárak léteznek. A BaseShapeLock osztály a generikus PPTX zárolási osztály. Az alábbi zár típusok támogatottak az Aspose.Slides for .NET-ben a PPTX-hez.

- AutoShapeLock zárolja az automatikus alakzatokat.
- ConnectorLock zárolja a csatlakozó alakzatokat.
- GraphicalObjectLock zárolja a grafikus objektumokat.
- GroupshapeLock zárolja a csoportos alakzatokat.
- PictureFrameLock zárolja a képkockákat.

Bármely, a Presentation objektum összes Shape objektumán végrehajtott művelet a teljes prezentációra vonatkozik.

## **Védelem alkalmazása és eltávolítása**
A védelem alkalmazása biztosítja, hogy egy prezentációt ne lehessen szerkeszteni. Hasznos technika a prezentáció tartalmának védelmére.

**Védelem alkalmazása PPTX alakzatokra**

Az Aspose.Slides for .NET a Shape osztályt biztosítja a dia alakzatának kezeléséhez.

Ahogy korábban említettük, minden alakzat osztálynak van egy hozzá tartozó shape lock osztálya a védelemhez. Ez a cikk a NoSelect, NoMove és NoResize zárakra összpontosít. Ezek a zárak biztosítják, hogy az alakzatok ne legyenek kiválaszthatók (egérkattintással vagy más kiválasztási módszerekkel), valamint ne mozgathatók vagy átméretezhetők.

Az alábbi kópminták a prezentáció összes alakzattípusára alkalmazzák a védelmet.

``` csharp

 //Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel


 //ISlide objektum a prezentáció diáinak eléréséhez
SlideEx slide = pTemplate.Slides[0];

//IShape objektum az ideiglenes alakzatok tárolásához
ShapeEx shape;

//A prezentáció minden diájának bejárása
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	 //A diák összes alakzatának bejárása
	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//ha az alakzat automatikus alakzat
		if (shape is AutoShapeEx)

		{

			//Típuskonverzió Auto shape-re és az auto shape zárolás lekérése
			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Alakzatok zárolásának alkalmazása
			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//ha az alakzat csoport alakzat
		else if (shape is GroupShapeEx)

		{

			//Típuskonverzió csoport alakzatra és a csoport alakzat zárolásának lekérése
			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Alakzatok zárolásának alkalmazása
			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//ha az alakzat egy csatlakozó
		else if (shape is ConnectorEx)

		{

			//Típuskonverzió csatlakozó alakzatra és a csatlakozó alakzat zárolásának lekérése
			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Alakzatok zárolásának alkalmazása
			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//ha az alakzat képkocka
		else if (shape is PictureFrameEx)

		{

			//Típuskonverzió képkocka alakzatra és a képkocka alakzat zárolásának lekérése
			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Alakzatok zárolásának alkalmazása
			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//A prezentáció fájl mentése
pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 

**Védelem eltávolítása**

Az Aspose.Slides for .NET által alkalmazott védelmet csak az Aspose.Slides for .NET segítségével lehet eltávolítani. Egy alakzat feloldásához állítsa a alkalmazott zár értékét false-ra. Az alábbi kópminta bemutatja, hogyan oldhatók fel a alakzatok egy zárolt prezentációban.

``` csharp

 //Megnyitja a kívánt prezentációt
PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//ISlide objektum a prezentáció diáinak eléréséhez
SlideEx slide = pTemplate.Slides[0];

//IShape objektum az ideiglenes alakzatok tárolásához
ShapeEx shape;

//A prezentáció összes diájának bejárása
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{
	slide = pTemplate.Slides[slideCount];
	 //A diák összes alakzatának bejárása
	for (int count = 0; count < slide.Shapes.Count; count++)
	{
		shape = slide.Shapes[count];
		//ha az alakzat automatikus alakzat
		if (shape is AutoShapeEx)
		{
			//Típuskonverzió Auto shape-re és az automatikus alakzat zárolásának lekérése
			AutoShapeEx Ashp = shape as AutoShapeEx;
			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;
			//Alakzatok zárolásának alkalmazása
			AutoShapeLock.PositionLocked = false;
			AutoShapeLock.SelectLocked = false;
			AutoShapeLock.SizeLocked = false;
		}
		//ha az alakzat csoport alakzat
		else if (shape is GroupShapeEx)
		{
			//Típuskonverzió csoport alakzatra és a csoport alakzat zárolásának lekérése
			GroupShapeEx Group = shape as GroupShapeEx;
			GroupShapeLockEx groupShapeLock = Group.ShapeLock;
			//Alakzatok zárolásának alkalmazása
			groupShapeLock.GroupingLocked = false;
			groupShapeLock.PositionLocked = false;
			groupShapeLock.SelectLocked = false;
			groupShapeLock.SizeLocked = false;
		}
		//ha az alakzat csatlakozó alakzat
		else if (shape is ConnectorEx)
		{
			//Típuskonverzió csatlakozó alakzatra és a csatlakozó alakzat zárolásának lekérése
			ConnectorEx Conn = shape as ConnectorEx;
			ConnectorLockEx ConnLock = Conn.ShapeLock;
			//Alakzatok zárolásának alkalmazása
			ConnLock.PositionMove = false;
			ConnLock.SelectLocked = false;
			ConnLock.SizeLocked = false;
		}
		//ha az alakzat képkocka
		else if (shape is PictureFrameEx)
		{
			//Típuskonverzió képkocka alakzatra és a képkocka alakzat zárolásának lekérése
			PictureFrameEx Pic = shape as PictureFrameEx;
			PictureFrameLockEx PicLock = Pic.ShapeLock;
			//Alakzatok zárolásának alkalmazása
			PicLock.PositionLocked = false;
			PicLock.SelectLocked = false;
			PicLock.SizeLocked = false;
		}
	}
}

//A prezentáció fájl mentése
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 
## **Minta kód letöltése**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)