---
title: Prezentáció szerkesztésének megakadályozása alakzatzárolásokkal
linktitle: Prezentáció szerkesztésének megakadályozása
type: docs
weight: 10
url: /hu/cpp/applying-protection-to-presentation/
keywords:
- szerkesztés megakadályozása
- védelme a szerkesztéstől
- alakzat zárolása
- pozíció zárolása
- kijelölés zárolása
- méret zárolása
- csoportosítás zárolása
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel, hogyan zárolja vagy oldja fel az Aspose.Slides for C++ az alakzatokat PPT, PPTX és ODP fájlokban, ezzel biztosítva a prezentációk védelmét, miközben lehetővé teszi a szabályozott szerkesztést és a gyorsabb szállítást."
---
## **Háttér**

Az Aspose.Slides gyakori felhasználási módja, hogy automatikus munkafolyamat részeként Microsoft PowerPoint (PPTX) prezentációkat hozzon létre, frissítsen és mentse. Az Aspose.Slides-et ilyen módon használó alkalmazások felhasználói hozzáférnek a generált prezentációkhoz, így azok szerkesztésének megakadályozása gyakori aggodalom. Fontos, hogy az automatikusan létrehozott prezentációk megőrizzék eredeti formázásukat és tartalmukat.

Ez a cikk bemutatja, hogyan épülnek fel a prezentációk és diaelemek, valamint hogyan tudja az Aspose.Slides for C++ védelmet alkalmazni egy prezentáción, majd később eltávolítani azt. A fejlesztők számára lehetőséget kínál arra, hogy szabályozzák, hogyan használják fel az alkalmazásaik által generált prezentációkat.

## **Dia felépítése**

Egy prezentációs dia olyan összetevőkből áll, mint az automatikus alakzatok, táblázatok, OLE-objektumok, csoportos alakzatok, képkockák, videokockák, csatlakozók és egyéb elemek, amelyeket a prezentáció felépítéséhez használnak. Az Aspose.Slides for C++‑ben a dián lévő minden elem egy olyan objektummal van reprezentálva, amely implementálja a [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) interfészt, vagy egy olyan osztályból származik, amely ezt az interfészt megvalósítja.

A PPTX felépítése összetett, ezért a PPT‑vel ellentétben, ahol egy általános zár használható az összes alakzattípusra, a különböző alakzattípusok különféle zárolásokat igényelnek. A [IBaseShapeLock](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseshapelock/) interfész a PPTX általános zárolási osztálya. Az Aspose.Slides for C++ a PPTX‑hez a következő zártípusokat támogatja:

- [IAutoShapeLock](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshapelock/) zárolja az automatikus alakzatokat.  
- [IConnectorLock](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iconnectorlock/) zárolja a csatlakozó alakzatokat.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/hu/cpp/aspose.slides/igraphicalobjectlock/) zárolja a grafikus objektumokat.  
- [IGroupShapeLock](https://reference.aspose.com/slides/hu/cpp/aspose.slides/igroupshapelock/) zárolja a csoportos alakzatokat.  
- [IPictureFrameLock](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframelock/) zárolja a képkockákat.   

Bármely művelet, amelyet egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektum összes alakzaton hajtunk végre, az egész prezentációra vonatkozik.

## **Védelem alkalmazása és eltávolítása**

A védelem alkalmazása biztosítja, hogy a prezentációt ne lehessen szerkeszteni. Hasznos technika a prezentáció tartalmának védelmére.

### **Védelem alkalmazása PPTX alakzatokra**

Az Aspose.Slides for C++ a [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) interfészt biztosítja az alakzatokkal való munkához egy dián.

Ahogy korábban említettük, minden alakzat osztálynak van egy hozzá tartozó alakzat-záró osztálya a védelemhez. Ez a cikk a NoSelect, NoMove és NoResize zárakra összpontosít. Ezek a zárak biztosítják, hogy az alakzatok ne legyenek kiválaszthatók (egérkattintással vagy egyéb kiválasztási módszerekkel), és ne mozgathatók vagy átméretezhetők legyenek.

Az alábbi kódminták a prezentáció összes alakzattípusára alkalmazzák a védelmet.

```cpp
// Példányosítsa a Presentation osztályt, amely egy PPTX fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Az összes diát végigjárja a prezentációban.
for (auto&& slide : presentation->get_Slides())	{

	// Az összes alakzatot végigjárja a diában.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Áttípusolja az alakzatot egy autoshape-re, és megszerzi annak shape lock-ját.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Áttípusolja az alakzatot egy csoportos alakzatra, és megszerzi annak shape lock-ját.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Áttípusolja az alakzatot egy csatlakozó alakzatra, és megszerzi annak shape lock-ját.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Áttípusolja az alakzatot egy képkockára, és megszerzi annak shape lock-ját.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// Mentse a prezentációfájlt.
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Védelem eltávolítása**

Egy alakzat feloldásához állítsuk a alkalmazott zár értékét `false`‑ra. Az alábbi kódminta bemutatja, hogyan oldhatók fel a zárak egy zárolt prezentációban.

```cpp
// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// Az összes diát végigjárja a prezentációban.
for (auto&& slide : presentation->get_Slides())	{

	// Az összes alakzatot végigjárja a diában.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Áttípusolja az alakzatot autoshape-re, és megszerzi annak shape lock-ját.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Áttípusolja az alakzatot csoportos alakzatra, és megszerzi annak shape lock-ját.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Áttípusolja az alakzatot csatlakozó alakzatra, és megszerzi annak shape lock-ját.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Áttípusolja az alakzatot képkockára, és megszerzi annak shape lock-ját.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// Mentse a prezentációfájlt.
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Következtetés**

Az Aspose.Slides több lehetőséget is kínál az alakzatok prezentációban való védelmére. Egyedi alakzatot zárolhat, vagy végigiterálhat a prezentáció összes alakzatán, és mindegyiket lezárhatja, így hatékonyan védi az egész fájlt. A védelem eltávolítható a zár értékét `false`‑ra állítva.

## **GYIK**

**Kombinálhatok-e alakzat-zárolásokat és jelszóvédelmet ugyanabban a prezentációban?**

Igen. A zárak korlátozzák a fájlon belüli objektumok szerkesztését, míg a [password protection](/slides/hu/cpp/password-protected-presentation/) szabályozza a megnyitáshoz és/vagy a módosítások mentéséhez való hozzáférést. Ezek a mechanizmusok kiegészítik egymást, és együtt működnek.

**Korlátozhatom-e a szerkesztést csak bizonyos diákra, anélkül, hogy a többit érinteném?**

Igen. Alkalmazzon zárakat a kiválasztott diák alakzataira; a többi dia szerkeszthető marad.

**Az alakzat-zárolások vonatkoznak-e csoportos objektumokra és csatlakozókra?**

Igen. Külön dedikált zár típusok támogatottak csoportokra, csatlakozókra, grafikus objektumokra és más alakzatfajtákra.