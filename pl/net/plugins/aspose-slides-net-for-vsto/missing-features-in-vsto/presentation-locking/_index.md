---
title: Blokowanie prezentacji
type: docs
weight: 110
url: /pl/net/presentation-locking/
---
## **Blokowanie prezentacji**
Typowym zastosowaniem **Aspose.Slides** jest tworzenie, aktualizowanie i zapisywanie prezentacji Microsoft PowerPoint 2007 (PPTX) w ramach zautomatyzowanego przepływu pracy. Użytkownicy aplikacji, które w ten sposób korzystają z Aspose.Slides, uzyskują dostęp do wygenerowanych prezentacji. Ochrona ich przed edycją jest powszechnym zagadnieniem. Ważne jest, aby automatycznie generowane prezentacje zachowywały oryginalne formatowanie i zawartość.

Ten artykuł wyjaśnia, jak budowane są prezentacje i slajdy oraz jak Aspose.Slides dla .NET może zastosować ochronę, a następnie usunąć ją z prezentacji. Ta funkcja jest unikalna dla Aspose.Slides i, w chwili pisania, nie jest dostępna w Microsoft PowerPoint. Daje programistom możliwość kontrolowania sposobu użycia prezentacji tworzonych przez ich aplikacje.
## **Kompozycja slajdu**
Slajd PPTX składa się z wielu elementów, takich jak kształty automatyczne, tabele, obiekty OLE, grupowane kształty, ramki obrazu, ramki wideo, łączniki oraz różne inne elementy dostępne do budowania prezentacji.

W Aspose.Slides dla .NET każdy element na slajdzie jest przekształcany w obiekt Shape. Innymi słowy, każdy element na slajdzie jest obiektem Shape lub obiektem pochodnym od Shape.

Struktura PPTX jest złożona, więc w przeciwieństwie do PPT, gdzie można używać uniwersalnej blokady dla wszystkich typów kształtów, istnieją różne rodzaje blokad dla poszczególnych typów kształtów. Klasa BaseShapeLock jest uniwersalną klasą blokującą PPTX. Następujące rodzaje blokad są obsługiwane w Aspose.Slides dla .NET dla PPTX.

- AutoShapeLock blokuje kształty automatyczne.
- ConnectorLock blokuje kształty łączników.
- GraphicalObjectLock blokuje obiekty graficzne.
- GroupshapeLock blokuje grupowane kształty.
- PictureFrameLock blokuje ramki obrazu.

Każde działanie wykonane na wszystkich obiektach Shape w obiekcie Presentation ma zastosowanie do całej prezentacji.
## **Zastosowanie i usunięcie ochrony**
Zastosowanie ochrony zapewnia, że prezentacja nie może być edytowana. Jest to przydatna technika ochrony zawartości prezentacji.

**Zastosowanie ochrony do kształtów PPTX**

Aspose.Slides dla .NET udostępnia klasę Shape do obsługi kształtu na slajdzie.

Jak wspomniano wcześniej, każda klasa kształtu ma powiązaną klasę blokady kształtu służącą do ochrony. Ten artykuł koncentruje się na blokadach NoSelect, NoMove i NoResize. Blokady te zapewniają, że kształty nie mogą być zaznaczane (przez kliknięcia myszy lub inne metody zaznaczania) oraz nie mogą być przenoszone ani zmieniane rozmiarowo.

Poniższe przykłady kodu stosują ochronę do wszystkich typów kształtów w prezentacji.

``` csharp

 //Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//Utwórz instancję klasy Presentation, która reprezentuje plik PPTX


 //Obiekt ISlide służący do uzyskiwania dostępu do slajdów w prezentacji
SlideEx slide = pTemplate.Slides[0];

//Obiekt IShape przechowujący tymczasowe kształty
ShapeEx shape;

//Iterowanie po wszystkich slajdach w prezentacji
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
	slide = pTemplate.Slides[slideCount];
	 //Iterowanie po wszystkich kształtach na slajdach
	for (int count = 0; count < slide.Shapes.Count; count++)
	{
		shape = slide.Shapes[count];
		 //jeśli kształt jest autoshape
		if (shape is AutoShapeEx)
		{
			 //Rzutowanie do Auto shape i pobieranie blokady autokształtu
			AutoShapeEx Ashp = shape as AutoShapeEx;
			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;
			 //Zastosowanie blokad kształtów
			AutoShapeLock.PositionLocked = true;
			AutoShapeLock.SelectLocked = true;
			AutoShapeLock.SizeLocked = true;
		}
		 //jeśli kształt jest grupą
		else if (shape is GroupShapeEx)
		{
			 //Rzutowanie do group shape i pobieranie blokady grupowego kształtu
			GroupShapeEx Group = shape as GroupShapeEx;
			GroupShapeLockEx groupShapeLock = Group.ShapeLock;
			 //Zastosowanie blokad kształtów
			groupShapeLock.GroupingLocked = true;
			groupShapeLock.PositionLocked = true;
			groupShapeLock.SelectLocked = true;
			groupShapeLock.SizeLocked = true;
		}
		 //jeśli kształt jest łącznikiem
		else if (shape is ConnectorEx)
		{
			 //Rzutowanie do shape łącznika i pobieranie blokady kształtu łącznika
			ConnectorEx Conn = shape as ConnectorEx;
			ConnectorLockEx ConnLock = Conn.ShapeLock;
			 //Zastosowanie blokad kształtów
			ConnLock.PositionMove = true;
			ConnLock.SelectLocked = true;
			ConnLock.SizeLocked = true;
		}
		 //jeśli kształt jest ramką obrazu
		else if (shape is PictureFrameEx)
		{
			 //Rzutowanie do shape ramki obrazu i pobieranie blokady kształtu ramki obrazu
			PictureFrameEx Pic = shape as PictureFrameEx;
			PictureFrameLockEx PicLock = Pic.ShapeLock;
			 //Zastosowanie blokad kształtów
			PicLock.PositionLocked = true;
			PicLock.SelectLocked = true;
			PicLock.SizeLocked = true;
		}
	}
}

//Zapisywanie pliku prezentacji
pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 

**Usuwanie ochrony**

Ochronę zastosowaną przy użyciu Aspose.Slides dla .NET można usunąć wyłącznie przy użyciu Aspose.Slides dla .NET. Aby odblokować kształt, ustaw wartość zastosowanej blokady na false. Poniższy przykład kodu pokazuje, jak odblokować kształty w zablokowanej prezentacji.

``` csharp

 //Otwórz żądaną prezentację
PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//Obiekt ISlide służący do uzyskiwania dostępu do slajdów w prezentacji
SlideEx slide = pTemplate.Slides[0];

//Obiekt IShape przechowujący tymczasowe kształty
ShapeEx shape;

//Iterowanie po wszystkich slajdach w prezentacji
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
	slide = pTemplate.Slides[slideCount];
	 //Iterowanie po wszystkich kształtach na slajdach
	for (int count = 0; count < slide.Shapes.Count; count++)
	{
		shape = slide.Shapes[count];
		 //jeśli kształt jest autoshape
		if (shape is AutoShapeEx)
		{
			 //Rzutowanie do Auto shape i pobieranie blokady autokształtu
			AutoShapeEx Ashp = shape as AutoShapeEx;
			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;
			 //Zastosowanie blokad kształtów
			AutoShapeLock.PositionLocked = false;
			AutoShapeLock.SelectLocked = false;
			AutoShapeLock.SizeLocked = false;
		}
		 //jeśli kształt jest grupą
		else if (shape is GroupShapeEx)
		{
			 //Rzutowanie do group shape i pobieranie blokady grupowego kształtu
			GroupShapeEx Group = shape as GroupShapeEx;
			GroupShapeLockEx groupShapeLock = Group.ShapeLock;
			 //Zastosowanie blokad kształtów
			groupShapeLock.GroupingLocked = false;
			groupShapeLock.PositionLocked = false;
			groupShapeLock.SelectLocked = false;
			groupShapeLock.SizeLocked = false;
		}
		 //jeśli kształt jest łącznikiem
		else if (shape is ConnectorEx)
		{
			 //Rzutowanie do connector shape i pobieranie blokady kształtu łącznika
			ConnectorEx Conn = shape as ConnectorEx;
			ConnectorLockEx ConnLock = Conn.ShapeLock;
			 //Zastosowanie blokad kształtów
			ConnLock.PositionMove = false;
			ConnLock.SelectLocked = false;
			ConnLock.SizeLocked = false;
		}
		 //jeśli kształt jest ramką obrazu
		else if (shape is PictureFrameEx)
		{
			 //Rzutowanie do shape ramki obrazu i pobieranie blokady kształtu ramki obrazu
			PictureFrameEx Pic = shape as PictureFrameEx;
			PictureFrameLockEx PicLock = Pic.ShapeLock;
			 //Zastosowanie blokad kształtów
			PicLock.PositionLocked = false;
			PicLock.SelectLocked = false;
			PicLock.SizeLocked = false;
		}
	}
}

//Zapisywanie pliku prezentacji
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 
## **Pobierz przykładowy kod**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)