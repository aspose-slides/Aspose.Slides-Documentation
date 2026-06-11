---
title: Zapobiegaj edycjom prezentacji przy użyciu blokad kształtów
linktitle: Zapobiegaj edycjom prezentacji
type: docs
weight: 10
url: /pl/cpp/applying-protection-to-presentation/
keywords:
- zapobieganie edycjom
- ochrona przed edycją
- blokada kształtu
- blokada pozycji
- blokada wyboru
- blokada rozmiaru
- blokada grupowania
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak Aspose.Slides for C++ blokuje lub odblokowuje kształty w plikach PPT, PPTX i ODP, zabezpieczając prezentacje, jednocześnie umożliwiając kontrolowaną edycję i szybsze dostarczanie."
---
## **Tło**

Typowym zastosowaniem Aspose.Slides jest tworzenie, aktualizowanie i zapisywanie prezentacji Microsoft PowerPoint (PPTX) w ramach zautomatyzowanego przepływu pracy. Użytkownicy aplikacji wykorzystujących Aspose.Slides w ten sposób mają dostęp do wygenerowanych prezentacji, dlatego ochrona ich przed edycją jest powszechnym zmartwieniem. Ważne jest, aby automatycznie generowane prezentacje zachowały pierwotne formatowanie i zawartość.

Ten artykuł wyjaśnia, jak są zbudowane prezentacje i slajdy oraz jak Aspose.Slides for C++ może zastosować ochronę do prezentacji i później ją usunąć. Dostarcza programistom sposobu kontrolowania sposobu użycia prezentacji generowanych przez ich aplikacje.

## **Skład slajdu**

Slajd prezentacji składa się z elementów takich jak autokształty, tabele, obiekty OLE, grupowane kształty, ramki obrazu, ramki wideo, łączniki i inne elementy używane do budowy prezentacji. W Aspose.Slides for C++ każdy element na slajdzie jest reprezentowany przez obiekt implementujący interfejs [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/) lub dziedziczący po klasie, która to robi.

Struktura PPTX jest złożona, więc w przeciwieństwie do PPT, gdzie można używać ogólnego blokowania dla wszystkich typów kształtów, różne typy kształtów wymagają różnych blokad. Interfejs [IBaseShapeLock](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseshapelock/) jest ogólną klasą blokującą dla PPTX. Następujące typy blokad są obsługiwane w Aspose.Slides for C++ dla PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshapelock/) blokuje autokształty.  
- [IConnectorLock](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iconnectorlock/) blokuje łączniki.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/pl/cpp/aspose.slides/igraphicalobjectlock/) blokuje obiekty graficzne.  
- [IGroupShapeLock](https://reference.aspose.com/slides/pl/cpp/aspose.slides/igroupshapelock/) blokuje grupowane kształty.  
- [IPictureFrameLock](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframelock/) blokuje ramki obrazu.   

Każde działanie wykonane na wszystkich obiektach kształtów w obiekcie [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) jest stosowane do całej prezentacji.

## **Zastosowanie i usunięcie ochrony**

Zastosowanie ochrony zapewnia, że prezentacja nie może być edytowana. Jest to przydatna technika ochrony zawartości prezentacji.

### **Zastosuj ochronę do kształtów PPTX**

Aspose.Slides for C++ udostępnia interfejs [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/) do pracy z kształtami na slajdzie.

Jak wspomniano wcześniej, każda klasa kształtu ma powiązaną klasę blokady kształtu służącą do ochrony. Ten artykuł koncentruje się na blokadach NoSelect, NoMove i NoResize. Blokady te zapewniają, że kształty nie mogą być zaznaczane (poprzez kliknięcia myszy lub inne metody wyboru) oraz nie mogą być przenoszone ani zmieniane rozmiarem.

Przykład kodu poniżej stosuje ochronę do wszystkich typów kształtów w prezentacji.

```cpp
// Utwórz obiekt klasy Presentation, który reprezentuje plik PPTX.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Przeglądanie wszystkich slajdów w prezentacji.
for (auto&& slide : presentation->get_Slides())	{

	// Przeglądanie wszystkich kształtów na slajdzie.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Rzutowanie kształtu na autokształt i uzyskanie jego blokady kształtu.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Rzutowanie kształtu na grupowany kształt i uzyskanie jego blokady kształtu.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Rzutowanie kształtu na łącznik i uzyskanie jego blokady kształtu.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Rzutowanie kształtu na ramkę obrazu i uzyskanie jej blokady kształtu.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// Zapisywanie pliku prezentacji.
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Usuń ochronę**

Aby odblokować kształt, ustaw wartość zastosowanej blokady na `false`. Poniższy przykład kodu pokazuje, jak odblokować kształty w zablokowanej prezentacji.

```cpp
// Utwórz obiekt klasy Presentation, który reprezentuje plik PPTX.
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// Przeglądanie wszystkich slajdów w prezentacji.
for (auto&& slide : presentation->get_Slides())	{

	// Przeglądanie wszystkich kształtów na slajdzie.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Rzutowanie kształtu na autokształt i uzyskanie jego blokady kształtu.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Rzutowanie kształtu na grupowany kształt i uzyskanie jego blokady kształtu.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Rzutowanie kształtu na łącznik i uzyskanie jego blokady kształtu.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Rzutowanie kształtu na ramkę obrazu i uzyskanie jej blokady kształtu.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// Zapisywanie pliku prezentacji.
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Wniosek**

Aspose.Slides oferuje kilka opcji ochrony kształtów w prezentacji. Możesz zablokować pojedynczy kształt lub iterować po wszystkich kształtach w prezentacji i zablokować każdy z nich, aby skutecznie zabezpieczyć cały plik. Ochronę można usunąć, ustawiając wartość blokady na `false`.

## **FAQ**

**Czy mogę łączyć blokady kształtów i ochronę hasłem w tej samej prezentacji?**

Tak. Blokady ograniczają edycję obiektów wewnątrz pliku, natomiast [password protection](/slides/pl/cpp/password-protected-presentation/) kontroluje dostęp do otwierania i/lub zapisywania zmian. Mechanizmy te uzupełniają się i działają razem.

**Czy mogę ograniczyć edycję na konkretnych slajdach bez wpływu na inne?**

Tak. Zastosuj blokady do kształtów na wybranych slajdach; pozostałe slajdy pozostaną edytowalne.

**Czy blokady kształtów obowiązują grupowane obiekty i łączniki?**

Tak. Obsługiwane są dedykowane typy blokad dla grup, łączników, obiektów graficznych i innych rodzajów kształtów.